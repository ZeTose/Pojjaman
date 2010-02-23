Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.Drawing.Printing
Imports System.Reflection
Imports System.IO
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Core.Services
Imports Longkong.Core.Properties
Namespace Longkong.AdobeForm
  Public Class PJMPaper
    Public Shared A3 As New PaperSize("A3", 1169, 1653)
    Public Shared A4 As New PaperSize("A4", 826, 1169)
    Public Shared A5 As New PaperSize("A5", 583, 826)
    Public Shared Letter As New PaperSize("Letter", 850, 1100)
    Public Shared A4Extra As New PaperSize("A4Extra", 826, 1169)
    Public Shared NineByEleven As New PaperSize("9by11inch", 882, 1078)
  End Class
  Public Class DesignerForm

#Region "Members"
    Private m_controls As IDrawableCollection
    Private m_vMargin As Integer
    Private m_hMargin As Integer
    Private Shared m_printerSettings As New PrinterSettings

    Protected m_tbs As ArrayList
    Protected m_entity As IPrintableEntity
    Private m_lvitem As ListView
    Protected m_tableColl As DocPrintingItemCollection
    Protected m_currentPage As Integer
    Protected m_pageCount As Integer

    Private m_filePath As String
    Private Shared FormPath As String = ""
    Private Shared ReportPath As String = ""

    Private m_sumHash As New Hashtable
    Private m_sumPageHash As New Hashtable
    Private m_sumPageColHash As New Hashtable

#End Region

    Private Function GetFunc(ByVal expr) As StringNameValuePair
      Dim functionRegex As New Regex("\=([^=\r\n]+)\((.+)\)", RegexOptions.IgnoreCase)
      If functionRegex.IsMatch(expr) Then
        Dim m As Match = functionRegex.Match(expr)
        Dim func As String = m.Groups(1).Value
        Dim map As String = m.Groups(2).Value
        Dim ret As New StringNameValuePair(func, map)
        Return ret
      End If
      Return Nothing
		End Function

#Region "Constructors"
		Shared Sub New()
			Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
			FormPath = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
			ReportPath = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
		End Sub
		Public Sub New()
			m_controls = New IDrawableCollection
		End Sub
		Public Sub New(ByVal prinTableEntity As IPrintableEntity)
			Me.New()
			Dim thePath As String = ""

			If TypeOf prinTableEntity Is Report Then
				thePath = ReportPath & Path.DirectorySeparatorChar & CType(prinTableEntity, Report).ClassName & ".xml"
			ElseIf TypeOf prinTableEntity Is ISimpleEntity Then
				thePath = FormPath & Path.DirectorySeparatorChar & CType(prinTableEntity, ISimpleEntity).ClassName & ".xml"
			Else
				Return
			End If
			If Not File.Exists(thePath) Then
				Return
			End If
			m_filePath = Path.GetFullPath(thePath).Replace(Path.GetFileName(thePath), "").TrimEnd(Path.DirectorySeparatorChar)
			Dim doc As New XmlDocument
			doc.Load(thePath)
			m_entity = prinTableEntity
			'Me.Construct(doc.DocumentElement)
			Me.Construct(doc)
			Init()
		End Sub
		Public Sub New(ByVal fileName As String, ByVal prinTableEntity As IPrintableEntity)
			Me.New()
			If Not File.Exists(fileName) Then
				Return
			End If
			m_filePath = Path.GetFullPath(fileName).Replace(Path.GetFileName(fileName), "").TrimEnd(Path.DirectorySeparatorChar)
			Dim doc As New XmlDocument
			doc.Load(fileName)
			m_entity = prinTableEntity
			'Me.Construct(doc.DocumentElement)
			Me.Construct(doc)
			Init()
		End Sub
		Public Sub New(ByVal xmlNode As XmlNode)
			Me.New()
			Me.Construct(xmlNode)
			Init()
		End Sub
		''' -----------------------------------------------------------------------------
		''' <summary>
		''' Constructor แบบอยากได้ฟอร์มไม่มี data
		''' </summary>
		''' <param name="fileName"></param>
		''' <remarks>
		''' </remarks>
		''' <history>
		''' 	[Administrator]	12/3/2549	Created
		''' </history>
		''' -----------------------------------------------------------------------------
		Public Sub New(ByVal fileName As String)
			Me.New()
			If Not File.Exists(fileName) Then
				Return
			End If
			m_filePath = Path.GetFullPath(fileName).Replace(Path.GetFileName(fileName), "").TrimEnd(Path.DirectorySeparatorChar)
			Dim doc As New XmlDocument
			doc.Load(fileName)
			'Me.Construct(doc.DocumentElement)
			Me.Construct(doc)
			m_tbs = New ArrayList
			For Each ctrl As Object In Me.Controls
				If TypeOf ctrl Is TableControl Then
					m_tbs.Add(ctrl)
				End If
			Next
		End Sub
		Public Sub New(ByVal fileName As String, ByVal lvItem As ListView)
			Me.New()
			If Not File.Exists(fileName) Then
				Return
			End If
			m_filePath = Path.GetFullPath(fileName).Replace(Path.GetFileName(fileName), "").TrimEnd(Path.DirectorySeparatorChar)
			Dim doc As New XmlDocument
			doc.Load(fileName)
			'Me.Construct(doc.DocumentElement)
			Me.Construct(doc)
			m_tbs = New ArrayList
			For Each ctrl As Object In Me.Controls
				If TypeOf ctrl Is TableControl Then
					m_tbs.Add(ctrl)
				End If
			Next

			m_lvitem = lvItem
			Dim tb As TableControl
			If m_tbs.Count > 0 Then
				tb = CType(m_tbs(0), TableControl)
			End If
			tb.Font = New Font("BrowalliaUPC", 12, FontStyle.Regular, GraphicsUnit.Point, CType(222, Byte))
			tb.Columns.Clear()
			Dim colOffset As Integer = 0
			For Each col As ColumnHeader In m_lvitem.Columns
				Dim tc As New TextControl
				tc.Width = col.Width
				tc.Height = 36
				tc.BorderThickness = 0
				tc.BorderStyle = Drawing2D.DashStyle.Solid
				tc.Location = New Point(tb.Location.X + colOffset, tb.Location.Y - tc.Height)
				colOffset += col.Width
				tc.Caption = col.Text
				tc.CaptionColor = SystemColors.ControlText
				tc.MapCaption = col.Text
				tc.CaptionFont = tb.Font
				tc.HAlignment = col.TextAlign
				tc.VAlignment = VerticalAlignment.Middle
				Me.Controls.Add(tc)
				tb.Columns.Add(New AdobeForm.Column(col.Text, col.Text, "Item." & col.Text, col.Width, col.TextAlign, tc.CaptionFont))
			Next
			Init()
		End Sub
		Private Sub Construct(ByVal xmlNode As XmlNode)
			ProcessXmlNode(xmlNode)
		End Sub
		Private Sub Construct(ByVal xmlDoc As XmlDocument)
			Dim templateNode As XmlNode
			templateNode = xmlDoc.SelectSingleNode("template")
			If templateNode Is Nothing Then
				Dim outputForm As New XmlDocument
				outputForm.LoadXml(Transformer(xmlDoc))
				ProcessXmlNode(outputForm.SelectSingleNode("xdp/template"))
			Else
				ProcessXmlNode(templateNode)
			End If
		End Sub
#End Region

#Region "Parser"
		Public Function Transformer(ByVal doc As System.Xml.XmlDocument) As String
			Dim xslt As New XslTransform
			Dim fullpath As String
			fullpath = Application.StartupPath()
			fullpath = Strings.Replace(fullpath, "bin", "data\forms\")
			xslt.Load(fullpath & "remove-namespace.xsl")

			Dim fs As New StringWriter
			Dim output As String
			xslt.Transform(doc, Nothing, fs, Nothing)
			output = fs.ToString
			Return output
		End Function

		Public Function Evaluate(ByVal expr As String) As String
			If expr Is Nothing Then
				Return expr
			End If
			If expr.IndexOf("[") < 0 Then
				Return expr
			End If
			'expr = Replace(expr, ",", "")
			If expr.Length = 0 Then
				Return 0
			End If

			'ตัวแปร
			Const Var As String = "(\[[^\[^\]]+\])"

			' จำนวน คือการเรียงกันของตัวเลข 1 ตัวขึ้นไป อาจจะตามด้วย . และตัวเลขอื่นๆ 1 ตัวขึ้นไป 
			' ที่ใส่วงเล็บไว้เพื่อให้เป็น unnamed group 
			Const Num As String = "(\-?\d+\.?\d*)"
			' List ของ 1-operand functions 
			Const Func1 As String = _
			"(exp|log|log10|abs|sqr|sqrt|sin|cos|tan|asin|acos|atan)"
			' List ของ 2-operands functions 
      Const Func2 As String = "(atan2)"
			' List ของ N-operands functions 
			Const FuncN As String = "(min|max)"

			' Define แต่ละ Regex object สำหรับแต่ละ operation 
			Dim rePower As New Regex(Num & "\s*(\^)\s*" & Num)
			Dim reAddSub As New Regex(Num & "\s*([-+])\s*" & Num)
			Dim reMulDiv As New Regex(Num & "\s*([*/])\s*" & Num)
			' Regex objects แก๊งนี้จะ resolve การเรียก functions 
			Dim reFunc1 As New Regex(Func1 & "\(\s*" & Num & "\s*\)", _
			RegexOptions.IgnoreCase)
			Dim reFunc2 As New Regex(Func2 & _
			"\(\s*" & Num & "\s*,\s*" & Num & "\s*\)", RegexOptions.IgnoreCase)
			Dim reFuncN As New Regex(FuncN & _
			"\((\s*" & Num & "\s*,)+\s*" & Num & "\s*\)", RegexOptions.IgnoreCase)
			' เอา + ออกถ้าตามหลัง operator อื่น 
			Dim reSign1 As New Regex("([-+/*^])\s*\+")
			'-- เป็น บวก 
			Dim reSign2 As New Regex("\-\s*-")
			'เอา () ออกจากตัวเลข (แต่วงเล็บต้องไม่ตามหลังตัวอักษร เพราะนั่นอาจเป็นชื่อ function) 
			Dim rePar As New Regex("(?<![A-Za-z0-9])\(\s*([-+]?\d+.?\d*)\s*\)")
			'อันนี้บอกว่าเราได้ผลสำเร็จแล้ว 
			'Dim reNum As New Regex("^\s*[-+]?\d+\.?\d*\s*$")
			Dim reNum As New Regex("^\s*[-+]?(\d+)*\.?\d*\s*$")

			Dim reVar As New Regex("\s*" & Var & "\s*", RegexOptions.IgnoreCase)
			'จัดการมัน(Variables) ซะ 
			expr = reVar.Replace(expr, AddressOf DoVars)

			'*************************************************** 
			' Loop จนกว่า expr จะกลายเป็นแค่จำนวน 
			'*************************************************** 
			Do Until reNum.IsMatch(expr)
				'จำ expr นี้ไว้ 
				Dim saveExpr As String = expr

				'ยกกำลังก่อน 
				Do While rePower.IsMatch(expr)
					expr = rePower.Replace(expr, AddressOf DoPower)
				Loop

				' คูณ/หาร ตามมา 
				Do While reMulDiv.IsMatch(expr)
					expr = reMulDiv.Replace(expr, AddressOf DoMulDiv)
				Loop

				'function หลาย arguments 
				Do While reFuncN.IsMatch(expr)
					expr = reFuncN.Replace(expr, AddressOf DoFuncN)
				Loop

				'function with 2 arguments 
				Do While reFunc2.IsMatch(expr)
					expr = reFunc2.Replace(expr, AddressOf DoFunc2)
				Loop

				'function with 1 argument 
				Do While reFunc1.IsMatch(expr)
					expr = reFunc1.Replace(expr, AddressOf DoFunc1)
				Loop

				'เอา unary pluses ออก 
				expr = reSign1.Replace(expr, "$1")
				'ลบลบเป็นบวก 
				expr = reSign2.Replace(expr, "+")

				'บวกลบ 
				Do While reAddSub.IsMatch(expr)
					expr = reAddSub.Replace(expr, AddressOf DoAddSub)
				Loop

				' เอา () ออกจากตัวเลข 
				expr = rePar.Replace(expr, "$1")

				'ถ้ามันผ่าน Process บ้าบอข้างต้นมาโดยไม่สะทกสะท้าน แปลว่า syntax error 
				If expr = saveExpr Then Exit Do
			Loop
			Return expr
		End Function
		Private Function DoVars(ByVal m As Match) As String
			Dim map As String = m.Groups(1).Value

			If map Like "*[[]*]*" Then
				map = map.Replace("[", "").Replace("]", "")
			End If

			If map.StartsWith("=") Then
				map = map.Substring(1, Len(map) - 1)
			End If

			Dim data As String = map			'ถ้าหาไม่เจอก็บ้วนกลับไป
			If Not Me.m_entity Is Nothing Then
				Dim item As DocPrintingItem
				If workTableRow > 0 Then
					item = m_tableColl.GetMappingItem(workTable, map, workTableRow)
				Else
					item = m_tableColl.GetMappingItem(map)
				End If
				If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
					data = item.Value.ToString
				Else
					data = 0
				End If
				If data.StartsWith("=") Then
					data = ""
				End If
			End If

			data = Replace(data, ",", "")

			Return data
		End Function
		Private Function DoPower(ByVal m As Match) As String
			Dim n1 As Double = CDbl(m.Groups(1).Value)
			Dim n2 As Double = CDbl(m.Groups(3).Value)
			' Groups(3) คือ "^" นั่นเอง 
			Return (n1 ^ n2).ToString
		End Function
		Private Function DoMulDiv(ByVal m As Match) As String
			Dim n1 As Double = CDbl(m.Groups(1).Value)
			Dim n2 As Double = CDbl(m.Groups(3).Value)
			Select Case m.Groups(2).Value
				Case "/"
					Return (n1 / n2).ToString
				Case "*"
					Return (n1 * n2).ToString
			End Select
		End Function
		Private Function DoAddSub(ByVal m As Match) As String
			Dim n1 As Double = CDbl(m.Groups(1).Value)
			Dim n2 As Double = CDbl(m.Groups(3).Value)
			Select Case m.Groups(2).Value
				Case "+"
					Return (n1 + n2).ToString
				Case "-"
					Return (n1 - n2).ToString
			End Select
		End Function
		Private Function DoFunc1(ByVal m As Match) As String
			Dim n1 As Double = CDbl(m.Groups(2).Value)
			Select Case m.Groups(1).Value.ToUpper
				Case "EXP"
					Return Math.Exp(n1).ToString
				Case "LOG"
					Return Math.Log(n1).ToString
				Case "LOG10"
					Return Math.Log10(n1).ToString
				Case "ABS"
					Return Math.Abs(n1).ToString
				Case "SQR", "SQRT"
					Return Math.Sqrt(n1).ToString
				Case "SIN"
					Return Math.Sin(n1).ToString
				Case "COS"
					Return Math.Cos(n1).ToString
				Case "TAN"
					Return Math.Tan(n1).ToString
				Case "ASIN"
					Return Math.Asin(n1).ToString
				Case "ACOS"
					Return Math.Acos(n1).ToString
				Case "ATAN"
					Return Math.Atan(n1).ToString
				Case "HideZero"
					If n1 = 0 Then
						Return " "
					Else
						Return n1.ToString
					End If
			End Select
		End Function
		Private Function DoFunc2(ByVal m As Match) As String
			'arguments 2 ตัวคือ Groups(2),Groups(3) 
			Dim n1 As Double = CDbl(m.Groups(2).Value)
			Dim n2 As Double = CDbl(m.Groups(3).Value)
			'Groups(1) คือชื่อ function 
			Select Case m.Groups(1).Value.ToUpper
				Case "ATAN2"
          Return Math.Atan2(n1, n2).ToString        
      End Select
		End Function
		Private Function DoFuncN(ByVal m As Match) As String
			'arguments คือ ตั้งแต่ Groups(2) เป็นต้นไป 
			Dim args As New ArrayList
			Dim i As Integer = 2
			Do While m.Groups(i).Value <> ""
				args.Add(CDbl(m.Groups(i).Value.Replace(","c, " "c)))
				i += 1
			Loop
			'Groups(1) คือชื่อ function 
			Select Case m.Groups(1).Value.ToUpper
				Case "MIN"
					args.Sort()
					Return args(0).ToString
				Case "MAX"
					args.Sort()
					Return args(args.Count - 1).ToString
			End Select
		End Function
		Private Function Parse(ByVal data As String) As String
			If Not data Is Nothing Then
				Dim savedData As String = data
				Const Func1 As String = "(fdate|sumpage|sum|ctext)"
        Const Func2 As String = "(lock|line|format|formatdate)"
        Const Func3 As String = "(subtext|formatdate)"
        Const Func5 As String = "(btext)"
				'Const Var As String = "(.+)"
				Const Var As String = "([^\(\),]*)"
				'ตัวแปร
				Const DVar As String = "(\{[^\{\},]*\})"

				Dim reFunc1 As New Regex(Func1 & "\(\s*" & Var & "\s*\)", _
				RegexOptions.IgnoreCase)

				Dim reFunc2 As New Regex(Func2 & _
				"\(\s*" & Var & "\s*,\s*" & Var & "\s*\)", RegexOptions.IgnoreCase)

				Dim reFunc3 As New Regex(Func3 & _
				"\(\s*" & Var & "\s*,\s*" & Var & "\s*,\s*" & Var & "\s*\)", RegexOptions.IgnoreCase)

        Dim reFunc5 As New Regex(Func5 & _
        "\(\s*" & Var & _
        "\s*,\s*" & Var & _
        "\s*,\s*" & Var & _
        "\s*,\s*" & Var & _
        "\s*,\s*" & Var & _
        "\s*\)", RegexOptions.IgnoreCase)

				Dim reVar As New Regex("\s*" & DVar & "\s*", RegexOptions.IgnoreCase)
				'จัดการมัน(Variables) ซะ 
				data = reVar.Replace(data, AddressOf DoStringVars)

				Const Constants As String = "(pages|page|fulldate|date|time)"
				'อันนี้จัดการกับ constants 
				Dim reConst As New Regex("\=\s*" & Constants & "\s*", RegexOptions.IgnoreCase)
				'จัดการมัน(constants) ซะ 
				data = reConst.Replace(data, AddressOf DoStringConstants)

				Do
					If reFunc1.IsMatch(data) Then
						data = reFunc1.Replace(data, AddressOf DoStringFunc1)
					ElseIf reFunc2.IsMatch(data) Then
						data = reFunc2.Replace(data, AddressOf DoStringFunc2)
					ElseIf reFunc3.IsMatch(data) Then
            data = reFunc3.Replace(data, AddressOf DoStringFunc3)
          ElseIf reFunc5.IsMatch(data) Then
            data = reFunc5.Replace(data, AddressOf DoStringFunc5)
					Else
						Exit Do
					End If
				Loop

				''function with 3 arguments 
				'Do While reFunc3.IsMatch(data)
				'	data = reFunc3.Replace(data, AddressOf DoStringFunc3)
				'Loop

				''function with 2 arguments 
				'Do While reFunc2.IsMatch(data)
				'	data = reFunc2.Replace(data, AddressOf DoStringFunc2)
				'Loop

				''function with 1 argument 
				'Do While reFunc1.IsMatch(data)
				'	data = reFunc1.Replace(data, AddressOf DoStringFunc1)
				'Loop

				If data.ToLower.StartsWith("company") Then
					Dim config As Object = Configuration.GetConfig(data)
					If Not config Is Nothing Then
						data = config.ToString
					End If
				End If

				If data <> savedData Then
					If data.StartsWith("=") Then
						data = data.Substring(1, Len(data) - 1)
					End If
				End If
			End If
			Return data
		End Function
		Private Function DoStringVars(ByVal m As Match) As String
			Dim map As String = m.Groups(1).Value

			If map Like "*{*}*" Then
				map = map.Replace("{", "").Replace("}", "")
			End If

			If map.StartsWith("=") Then
				map = map.Substring(1, Len(map) - 1)
			End If

			Dim data As String = map			'ถ้าหาไม่เจอก็บ้วนกลับไป
			If Not Me.m_entity Is Nothing Then
				Dim item As DocPrintingItem
				If workTableRow > 0 Then
					item = m_tableColl.GetMappingItem(workTable, map, workTableRow)
				Else
					item = m_tableColl.GetMappingItem(map)
				End If
				If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
					data = item.Value.ToString
				Else
					data = ""
				End If
				If data.StartsWith("=") Then
					data = ""
				End If
			End If
			data = Replace(data, ",", "")
			Return data
		End Function
		Private Function DoStringFunc1(ByVal m As Match) As String
			'arguments คือ Groups(2) 
			Dim s1 As String = m.Groups(2).Value
			'Groups(1) คือชื่อ function 
			Select Case m.Groups(1).Value.ToUpper
				Case "FDATE"
					Dim item As DocPrintingItem
					If workTableRow > 0 Then
						item = m_tableColl.GetMappingItem(workTable, s1, workTableRow)
					Else
						item = m_tableColl.GetMappingItem(s1)
					End If
					If Not item Is Nothing AndAlso IsDate(item.Value) Then
						Dim d As Date = CDate(item.Value)
						Return d.ToLongDateString
					ElseIf IsDate(s1) Then
						Return CDate(s1).ToLongDateString
					End If
				Case "SUM"
					Dim obj As Object = Me.m_sumHash(s1.ToLower)
					If IsNumeric(obj) Then
						Return Configuration.FormatToString(CDec(obj), DigitConfig.Price)
					End If
				Case "SUMPAGE"
					Dim obj As Object = Me.m_sumPageHash(s1.ToLower)
					If IsNumeric(obj) Then
						Return Configuration.FormatToString(CDec(obj), DigitConfig.Price)
					End If
				Case "CTEXT"
					If Not m_tableColl Is Nothing Then
						Dim item As DocPrintingItem
						If workTableRow > 0 Then
							item = m_tableColl.GetMappingItem(workTable, s1, workTableRow)
						Else
							item = m_tableColl.GetMappingItem(s1)
						End If
						If Not item Is Nothing AndAlso IsNumeric(item.Value) Then
							Dim number As Decimal = CDec(item.Value)
							Return "(" & Configuration.FormatToString(number, DigitConfig.CurrencyText) & ")"
						ElseIf IsNumeric(s1) Then
							Return "(" & Configuration.FormatToString(CDec(s1), DigitConfig.CurrencyText) & ")"
						End If
					End If
			End Select
			Return ""
		End Function
		Private Function DoStringFunc2(ByVal m As Match) As String
			'arguments 2 ตัวคือ Groups(2),Groups(3) 
			Dim s1 As String = m.Groups(2).Value
			Dim s2 As String = m.Groups(3).Value
			'Groups(1) คือชื่อ function 
			'lock|line
			Select Case m.Groups(1).Value.ToUpper
				Case "FORMAT"
					Dim dcfg As DigitConfig = CType([Enum].Parse(GetType(DigitConfig), s2), DigitConfig)
					If IsNumeric(s1) Then
						Return Configuration.FormatToString(CDec(s1), dcfg)
					Else
						Dim item As DocPrintingItem
						If workTableRow > 0 Then
							item = m_tableColl.GetMappingItem(workTable, s1, workTableRow)
						Else
							item = m_tableColl.GetMappingItem(s1)
						End If

						If Not item Is Nothing Then
							If Not item.Value Is Nothing Then
								If IsNumeric(item.Value) Then
									Return Configuration.FormatToString(CDec(item.Value), dcfg)
								End If
							End If
						End If
						Return s1
					End If
				Case "FORMATDATE"
					Try
						Dim MyCulture As CultureInfo
						MyCulture = Application.CurrentCulture
						Dim MyDateTime As Date = Date.Parse(s1)
						Return MyDateTime.ToString(s2)
					Catch ex As Exception
						Return s1
					End Try
				Case "LOCK"
					'=Lock(Amount,=)
					'tmpData(0) = "=Lock(Amount"
					'tmpData(1) = "=)"

					Dim item As DocPrintingItem
					If workTableRow > 0 Then
						item = m_tableColl.GetMappingItem(workTable, s1, workTableRow)
					Else
						item = m_tableColl.GetMappingItem(s1)
					End If
					If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
						Return s2 & item.Value.ToString & s2						'=700.00=
					Else
						Return s2 & s1 & s2						'=Amount=
					End If
				Case "LINE"
					Dim item As DocPrintingItem
					If workTableRow > 0 Then
						item = m_tableColl.GetMappingItem(workTable, s1, workTableRow)
					Else
						item = m_tableColl.GetMappingItem(s1)
					End If
					If IsNumeric(s2) Then
						Dim lineNum As Integer = CInt(s2)
						If Not item Is Nothing Then
							If Not item.Value Is Nothing Then
								Dim itemString As String = CStr(item.Value)
								Dim lines As String() = itemString.Split(vbCrLf)
								If lines.Length >= lineNum Then
									Return lines(lineNum - 1)
								End If
							End If
						End If
          End If
      End Select
			Return ""
		End Function
		Private Function DoStringFunc3(ByVal m As Match) As String
			'arguments 3 ตัวคือ Groups(2),Groups(3),Groups(4) 
			Dim s1 As String = m.Groups(2).Value
			Dim s2 As String = m.Groups(3).Value
			Dim s3 As String = m.Groups(4).Value
			'Groups(1) คือชื่อ function 
			Select Case m.Groups(1).Value.ToUpper
        'Case "SUBTEXT"
        'If CInt(s2) > 0 And CInt(s2) <= s1.Length And ((CInt(s2) + CInt(s3)) - 1) <= s1.Length Then
        'Return Strings.Mid(s1, CInt(s2), CInt(s3))
        'End If
        Case "SUBTEXT"
          Dim start As Integer = CInt(s2)
          Dim len As Integer = CInt(s3)
          Dim item As DocPrintingItem = m_tableColl.GetMappingItem(s1)
          If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
            Dim val As String = item.Value.ToString
            Return GetSubText(val, start, len)
          Else
            Dim val As String = s1
            Return GetSubText(val, start, len)
          End If
        Case "FORMATDATE"
          Try
            Dim MyCulture As CultureInfo
            MyCulture = Application.CurrentCulture
            Dim MyDateTime As Date = Date.Parse(s1, MyCulture)
            Return MyDateTime.ToString(s2, New CultureInfo(s3))
          Catch ex As Exception
            Return s1
          End Try
      End Select
			Return ""
    End Function
    Private Function GetSubText(ByVal val As String, ByVal startPos As Integer, ByVal length As Integer) As Object
      If startPos < 1 Then
        startPos = 1
      End If
      If startPos > val.Length Then
        startPos = val.Length + 1
      End If
      Dim maxLength As Integer = val.Length - startPos + 1
      length = Math.Min(length, maxLength)
      Return val.Substring(startPos - 1, length)
    End Function
    Private Function DoStringFunc5(ByVal m As Match) As String
      'arguments 4 ตัวคือ Groups(2),Groups(3),Groups(4) ,Groups(5) ,Groups(6)
      Dim s1 As String = m.Groups(2).Value
      Dim s2 As String = m.Groups(3).Value
      Dim s3 As String = m.Groups(4).Value
      Dim s4 As String = m.Groups(5).Value
      Dim s5 As String = m.Groups(6).Value
      'Groups(1) คือชื่อ function 
      Select Case m.Groups(1).Value.ToUpper
        Case "BTEXT"
          If Not m_tableColl Is Nothing Then
            Dim item As DocPrintingItem
            If workTableRow > 0 Then
              item = m_tableColl.GetMappingItem(workTable, s1, workTableRow)
            Else
              item = m_tableColl.GetMappingItem(s1)
            End If
            Dim number As Nullable(Of Decimal) = Nothing
            If Not item Is Nothing AndAlso IsNumeric(item.Value) Then
              number = CDec(item.Value)
            ElseIf IsNumeric(s1) Then
              number = CDec(s1)
            End If
            If number.HasValue Then
              Dim numberToFormat As Decimal = number.Value
              If s1.ToLower = "th" Then
                Dim minusText As String = ""
                If numberToFormat < 0 Then
                  minusText = "ลบ"
                  numberToFormat = -numberToFormat
                End If
                Return "(" & minusText & Configuration.BahtText(numberToFormat.ToString) & ")"
              Else
                Dim minusText As String = ""
                If numberToFormat < 0 Then
                  minusText = "Minus "
                  numberToFormat = -numberToFormat
                End If
                Return "(" & minusText & MoneyConverter.Convert(numberToFormat, s3, s4, s5) & ")"
              End If
            End If
          End If
      End Select
      Return ""
    End Function
		Private Function DoStringConstants(ByVal m As Match) As String
			Select Case m.Groups(1).Value.ToUpper
				Case "PAGES"
					Return Me.m_pageCount.ToString
				Case "PAGE"
					Return Me.m_currentPage.ToString
				Case "DATE"
					Return Now.ToShortDateString
				Case "FULLDATE"
					Return Now.ToLongDateString
				Case "TIME"
					Return Now.ToShortTimeString
			End Select
		End Function
		Protected Function ParseTableItem(ByVal tableName As String, ByVal dat As String, ByVal row As Integer) As DocPrintingItem
			Dim item As DocPrintingItem
			If Not dat Is Nothing Then
				Dim tryMatch As StringNameValuePair = Me.GetItemFunc(dat)
				If Not tryMatch Is Nothing Then
					Select Case tryMatch.Name.ToLower
						Case "fdate"
							Dim tmpItem As DocPrintingItem = m_tableColl.GetMappingItem(tableName, tryMatch.Value, row)
							If Not tmpItem Is Nothing Then
								item = tmpItem.Clone
							End If
							If Not item Is Nothing AndAlso IsDate(item.Value) Then
								Dim d As Date = CDate(item.Value)
								item.Value = d.ToLongDateString
							End If
						Case "ctext"
							Dim tmpItem As DocPrintingItem = m_tableColl.GetMappingItem(tableName, tryMatch.Value, row)
							If Not tmpItem Is Nothing Then
								item = tmpItem.Clone
							End If
							If Not item Is Nothing AndAlso IsNumeric(item.Value) Then
								Dim number As Decimal = CDec(item.Value)
								item.Value = "(" & Configuration.FormatToString(number, DigitConfig.CurrencyText) & ")"
							End If
						Case "lock"
							Dim tmpData() As String = tryMatch.Value.Split(","c)
							'Lock(Amount,=)
							'tmpData(0) = "Lock(Amount"
							'tmpData(1) = "="

							Dim num As String = tmpData(0)							'num="Amount"
							Dim s As String = tmpData(1)							's="="

							Dim tmpItem As DocPrintingItem = m_tableColl.GetMappingItem(tableName, num, row)
							If Not tmpItem Is Nothing Then
								item = tmpItem.Clone
							End If
							If Not item Is Nothing AndAlso Not item.Value Is Nothing AndAlso item.Value.ToString.Length > 0 Then
								item.Value = s & item.Value.ToString & s								'=700.00=
							End If
					End Select
				End If
			End If
			If item Is Nothing Then
				item = m_tableColl.GetMappingItem(tableName, dat, row)
			End If
			Return item
		End Function


#End Region

#Region "Init"
		Private Function GetDPICollFromListview(ByVal lv As ListView) As DocPrintingItemCollection
			Dim dpiColl As New DocPrintingItemCollection
			Dim i As Integer = 0
			For Each item As ListViewItem In m_lvitem.Items
				i += 1
				For Each col As ColumnHeader In m_lvitem.Columns
					Dim data As String = item.SubItems(col.Index).Text
					Dim dpi As New DocPrintingItem
					dpi.Mapping = "Item." & col.Text
					dpi.Value = data
					dpi.Row = i
					dpi.Table = "Item"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Next
			Next

			Return dpiColl
		End Function
		Private Function GetItemFunc(ByVal expr) As StringNameValuePair
			Dim functionRegex As New Regex("([^=\r\n]+)\((.+)\)", RegexOptions.IgnoreCase)
			If functionRegex.IsMatch(expr) Then
				Dim m As Match = functionRegex.Match(expr)
				Dim func As String = m.Groups(1).Value
				Dim map As String = m.Groups(2).Value
				Dim ret As New StringNameValuePair(func, map)
				Return ret
			End If
			Return Nothing
		End Function
		Public Sub Init()
			m_pageCount = 0
			m_currentPage = 0
			m_tbs = New ArrayList
			For Each ctrl As Object In Me.Controls
				If TypeOf ctrl Is TableControl Then
					m_tbs.Add(ctrl)
				End If
			Next
			For Each table As TableControl In m_tbs
				If table.TableName.ToLower.StartsWith("table") Then
					table.TableName = "Item"
				End If
			Next
			If Not m_lvitem Is Nothing Then
				m_tableColl = GetDPICollFromListview(m_lvitem)
			Else
				m_tableColl = Me.m_entity.GetDocPrintingEntries
			End If
			If m_tableColl Is Nothing Then
				m_tableColl = New DocPrintingItemCollection
			End If
			If TypeOf m_entity Is IHasCustomNote Then
				Dim coll As CustomNoteCollection				' = CType(m_entity, IHasCustomNote).GetCustomNoteCollection
				If TypeOf m_entity Is IHasMainDoc Then
					If Not (TypeOf (m_entity) Is JournalEntry) Then
						coll = CType(CType(m_entity, IHasMainDoc).MainDoc, IHasCustomNote).GetCustomNoteCollection
					Else
						coll = CType(m_entity, IHasCustomNote).GetCustomNoteCollection
					End If
				Else
					coll = CType(m_entity, IHasCustomNote).GetCustomNoteCollection
				End If
				For Each note As CustomNote In coll
					Dim dpi As New DocPrintingItem
					dpi.Mapping = "Note." & note.NoteName
					If note.IsDropDown Then
						dpi.Value = Boolean.Parse(CStr(note.Note))
						dpi.DataType = "System.Boolean"
					Else
						dpi.Value = CStr(note.Note)
						dpi.DataType = "System.String"
					End If
					m_tableColl.Add(dpi)
				Next
			End If

			''''''''''''''---------------------
			Dim g As Graphics = Graphics.FromImage(New Bitmap(Me.m_printerSettings.DefaultPageSettings.PaperSize.Width, Me.m_printerSettings.DefaultPageSettings.PaperSize.Height))
			For Each ctrl As IDrawable In Me.Controls
				If TypeOf ctrl Is TableControl Then
					Dim tb As TableControl = CType(ctrl, TableControl)
					tb.RowCount = m_tableColl.GetRowCount(tb.TableName)
					tb.PrintRowCount = tb.RowCount
					If Not m_tableColl Is Nothing Then
						Dim verticalInterval As Integer = 5
						Dim horizontalInterval As Integer = 5
						Dim currentPageRow As Integer = 0
						Dim rowOffset As Integer = 0
						For i As Integer = 0 To tb.RowCount
							If i > tb.RowCount Then
								'เกินจำนวนแล้ว
								Exit For
							End If
							Dim maxLines As Integer = 0
							For Each col As Column In tb.Columns
								Dim item As DocPrintingItem = Me.ParseTableItem(tb.TableName, col.ReportField, i)
								'Dim item As DocPrintingItem = m_tableColl.GetMappingItem(tb.TableName, col.ReportField, i)
								If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
									If item.DataType.ToLower <> "system.boolean" Then
										Dim data As String
										Select Case item.DataType.ToLower
											Case "system.datetime"
												If IsDate(item.Value) Then
													Dim itemDate As DateTime = CDate(item.Value)
													data = itemDate.ToShortDateString
												Else
													data = item.Value.ToString
												End If
											Case "system.integer"
												Dim itemValue As Integer
												If item.Value.ToString.Length > 0 Then
													If IsNumeric(item.Value) Then
														itemValue = CInt(item.Value)
														data = Configuration.FormatToString(itemValue, DigitConfig.Int)
													Else
														data = item.Value.ToString
													End If
												Else
													data = item.Value.ToString
												End If
											Case "system.decimal"
												Dim itemValue As Decimal
												If item.Value.ToString.Length > 0 Then
													If IsNumeric(item.Value) Then
														itemValue = CDec(item.Value)
														If itemvalue = 0 Then
															data = ""
														Else
															data = Configuration.FormatToString(itemValue, DigitConfig.Price)
														End If
													Else
														data = item.Value.ToString
													End If
												Else
													data = item.Value.ToString
												End If
											Case Else
												data = item.Value.ToString
										End Select

										Dim dataFont As Font

										If Not col.Font Is Nothing Then
											dataFont = New Font(col.Font.FontFamily.Name, col.Font.Size, col.Font.Style, GraphicsUnit.Point, CType(222, Byte))
										ElseIf Not item.Font Is Nothing Then
											dataFont = New Font(item.Font.FontFamily.Name, item.Font.Size, item.Font.Style, GraphicsUnit.Point, CType(222, Byte))
											'dataFont = New Font(tb.Font.FontFamily.Name, tb.Font.Size, item.Font.Style, System.Drawing.GraphicsUnit.Point, tb.Font.GdiCharSet)
										Else
											dataFont = New Font(tb.Font.FontFamily.Name, tb.Font.Size, tb.Font.Style, System.Drawing.GraphicsUnit.Point, tb.Font.GdiCharSet)
										End If
										Dim stf As New StringFormat
										stf.Trimming = StringTrimming.None
										stf.FormatFlags = StringFormatFlags.NoClip
										Select Case col.Alignment
											Case HorizontalAlignment.Center
												stf.LineAlignment = StringAlignment.Near
												stf.Alignment = StringAlignment.Center
											Case HorizontalAlignment.Left
												stf.LineAlignment = StringAlignment.Near
												stf.Alignment = StringAlignment.Near
											Case HorizontalAlignment.Right
												stf.LineAlignment = StringAlignment.Near
												stf.Alignment = StringAlignment.Far
										End Select

										Dim p As New PointF(0, 0)
										Dim textSize As SizeF = g.MeasureString(data, dataFont, p, stf)
										Dim lines As Integer = CInt(Math.Ceiling((textSize.Width) / col.Width))										'+6?
										If lines > maxLines Then
											'If lines > 1 Then
											'    MessageBox.Show(data)
											'End If
											maxLines = lines
										End If
									End If
								End If
							Next							'Col
							'''''
							currentPageRow += 1
							If maxLines > 1 Then
								rowOffset += maxLines - 1
							End If
						Next						'Row
						'MessageBox.Show(String.Format("{0}+={1}", tb.PrintRowCount, rowOffset))
						tb.PrintRowCount += rowOffset
					End If
				End If				' IS TABLE
			Next
			'------------------------
			SetPageCount()
		End Sub
		Public Sub SetPageCount()
			Dim maxPGs As Integer = 0
			For Each tb As TableControl In m_tbs
				If tb.RowsPerPage > 0 Then
					Dim pgs As Integer = CInt(Math.Ceiling((tb.PrintRowCount + (tb.RowsPerPage - tb.RowsPerLastPage)) / tb.RowsPerPage))
					'MessageBox.Show(String.Format("({0}+({1}-{2}))/{3}={4}", tb.PrintRowCount, tb.RowsPerPage, tb.RowsPerLastPage, tb.RowsPerPage, pgs))
					If pgs > maxPGs Then
						maxPGs = pgs
					End If
				End If
			Next
			m_pageCount = maxPGs
		End Sub
		Public Function GetPageCount() As Integer
			Return m_pageCount
		End Function
#End Region

#Region "Properties"
		Public ReadOnly Property Tables() As ArrayList
			Get
				Return m_tbs
			End Get
		End Property
		Public ReadOnly Property FilePath() As String
			Get
				Return m_filePath
			End Get
		End Property
		Public Property Controls() As IDrawableCollection
			Get
				Return m_controls
			End Get
			Set(ByVal Value As IDrawableCollection)
				m_controls = Value
			End Set
		End Property
		Public Property VMargin() As Integer
			Get
				Return m_vMargin
			End Get
			Set(ByVal Value As Integer)
				m_vMargin = Value
			End Set
		End Property
		Public Property HMargin() As Integer
			Get
				Return m_hMargin
			End Get
			Set(ByVal Value As Integer)
				m_hMargin = Value
			End Set
		End Property
		Public ReadOnly Property PrintDocument() As PrintDocument
			Get
				Dim pd As New PrintDocument
				AddHandler pd.BeginPrint, AddressOf BeginPrint_Handler
				AddHandler pd.PrintPage, AddressOf PrintPage_Handler
				UpdatePrinterSettings(pd)
				Me.m_countPage = True
				m_rowOffsetHash = New Hashtable
				Me.m_pageCount = PageCountPrintController.GetPageCount(pd)
				Me.m_countPage = False
				Return pd
			End Get
		End Property
#End Region

#Region "Methods"
		Public Sub UpdatePrinterSettings(ByVal pd As PrintDocument)
			pd.PrinterSettings = Me.m_printerSettings
			pd.PrinterSettings.PrintRange = PrintRange.AllPages
			pd.DefaultPageSettings.Landscape = Me.m_printerSettings.DefaultPageSettings.Landscape
			pd.DefaultPageSettings.PaperSize = Me.m_printerSettings.DefaultPageSettings.PaperSize
			pd.DefaultPageSettings.Margins.Bottom = Me.m_vMargin
			pd.DefaultPageSettings.Margins.Top = Me.m_vMargin
			pd.DefaultPageSettings.Margins.Left = Me.m_hMargin
			pd.DefaultPageSettings.Margins.Right = Me.m_hMargin
		End Sub
		Private Sub ProcessXmlNode(ByVal xmlnode As XmlNode)
			Dim noRecur As Boolean = False
			Select Case xmlnode.NodeType
				Case XmlNodeType.Element
					Dim ctrl As AdobeControl
					For Each xmlAttr As XmlAttribute In xmlnode.Attributes
						If xmlAttr.Name.ToLower = "layout" Then
							Select Case xmlAttr.Value.ToLower
								Case "lr-tb", "tb", "rl-tb", "position"
									'Form
									Dim myNode As xmlnode = xmlnode.SelectSingleNode("descendant::contentArea")
									If Not myNode Is Nothing Then
										Dim x As String = myNode.Attributes("x").Value
										Dim y As String = myNode.Attributes("y").Value
										Me.m_hMargin = AnyThingToPixel(x)
										Me.m_vMargin = AnyThingToPixel(y)
									End If
									Dim mediumNode As xmlnode = xmlnode.SelectSingleNode("descendant::medium")
									If Not mediumNode Is Nothing Then
										If Not mediumNode.Attributes("orientation") Is Nothing Then
                      DesignerForm.m_printerSettings.DefaultPageSettings.Landscape = True
										Else
                      DesignerForm.m_printerSettings.DefaultPageSettings.Landscape = False
										End If
										Dim thePaper As PaperSize = PJMPaper.Letter
										If Not mediumNode.Attributes("stock") Is Nothing Then
											Dim found As Boolean = False
                      'หาตาม PaperSize
                      For Each pz As PaperSize In DesignerForm.m_printerSettings.PaperSizes
                        If pz.PaperName.ToLower = mediumNode.Attributes("stock").Value.ToLower Then
                          thePaper = pz
                          found = True
                          Exit For
                        End If
                      Next
                      If Not found Then
                        'หาตาม Kind
                        For Each pz As PaperSize In DesignerForm.m_printerSettings.PaperSizes
                          If pz.Kind.ToString.ToLower = mediumNode.Attributes("stock").Value.ToLower Then
                            thePaper = pz
                            found = True
                            Exit For
                          End If
                        Next
                      End If
											If Not found Then
												Select Case mediumNode.Attributes("stock").Value.ToLower
													Case "default"
														thePaper = PJMPaper.Letter
													Case "a3"
														thePaper = PJMPaper.A3
													Case "a4"
														thePaper = PJMPaper.A4
													Case "a5"
														thePaper = PJMPaper.A5
													Case "a4extra"
														thePaper = PJMPaper.A4Extra
													Case "9by11inch"
                            thePaper = PJMPaper.NineByEleven
                          Case Else
                            thePaper = GetPaperSize(mediumNode.Attributes("stock").Value, mediumNode.Attributes("stock").Value)
                        End Select
											End If
										End If
                    DesignerForm.m_printerSettings.DefaultPageSettings.PaperSize = thePaper
									End If
									Exit For
								Case "table"
									'Table
									noRecur = True
									ctrl = New TableControl(xmlnode)
									Exit For
								Case Else
									'subform
									Exit For
							End Select
						End If
					Next
					Dim foundedNode As xmlnode = xmlnode.SelectSingleNode("assist")
					If Not foundedNode Is Nothing Then
						For Each attr As XmlAttribute In foundedNode.Attributes
							If attr.Name.ToLower = "role" Then
								Select Case attr.Value.ToLower
									Case "th"
									Case "tr"
								End Select
							End If
						Next
					Else
						Dim foundedNodes As XmlNodeList = xmlnode.SelectNodes("ui/textEdit")
						If foundedNodes.Count > 0 Then
						End If
					End If
					foundedNode = xmlnode.SelectSingleNode("value/image")
					If Not foundedNode Is Nothing Then
						ctrl = New ImageControl(xmlnode)
					End If
					foundedNode = xmlnode.SelectSingleNode("ui/checkButton")
					If Not foundedNode Is Nothing Then
						ctrl = New CheckboxControl(xmlnode)
					End If
					foundedNode = xmlnode.SelectSingleNode("value/arc")
					If Not foundedNode Is Nothing Then
						ctrl = New CircleControl(xmlnode)
					End If
					foundedNode = xmlnode.SelectSingleNode("value/line")
					If Not foundedNode Is Nothing Then
						ctrl = New LineControl(xmlnode)
					End If
					foundedNode = xmlnode.SelectSingleNode("value/rectangle")
					If Not foundedNode Is Nothing Then
						ctrl = New RectangleControl(xmlnode)
					End If
					foundedNode = xmlnode.SelectSingleNode("ui/textEdit")
					If Not foundedNode Is Nothing Then
						foundedNode = xmlnode.SelectSingleNode("caption")
						If Not foundedNode Is Nothing Then
							noRecur = True
							ctrl = New TextFieldControl(xmlnode)
						Else
							foundedNode = xmlnode.SelectSingleNode("value/text")
							If Not foundedNode Is Nothing Then
								ctrl = New TextControl(xmlnode)
							Else
								foundedNode = xmlnode.SelectSingleNode("value/exData/body")
								If Not foundedNode Is Nothing Then
									ctrl = New TextControl(xmlnode)
								Else
									ctrl = New TextControl(xmlnode)
								End If
							End If
						End If
					End If
					If Not ctrl Is Nothing Then
						If TypeOf ctrl Is IHasRootPath Then
							CType(ctrl, IHasRootPath).RootPath = Me.FilePath
						End If
						Me.Controls.Add(ctrl)
					End If
				Case XmlNodeType.Text, XmlNodeType.CDATA
				Case XmlNodeType.Comment
				Case XmlNodeType.ProcessingInstruction, XmlNodeType.XmlDeclaration
				Case Else
					' Ignore other node types.
			End Select
			' Call this routine recursively for each child node.
			If Not noRecur Then
				Dim xmlChild As xmlnode = xmlnode.FirstChild
				Do Until xmlChild Is Nothing
					ProcessXmlNode(xmlChild)
					' Continue with the next child node.
					xmlChild = xmlChild.NextSibling
				Loop
			End If
		End Sub
		Private m_lastpage As Integer = 0
		Private m_countPage As Boolean = False
		Private m_rowOffsetHash As Hashtable
		Protected Overridable Sub BeginPrint_Handler(ByVal sender As Object, ByVal pe As PrintEventArgs)
			Dim pd As PrintDocument = CType(sender, PrintDocument)
			Dim firstPage As Integer = 1
			Dim func As String
			m_lastpage = Integer.MaxValue			'Me.m_pageCount
			If pd.PrinterSettings.PrintRange = PrintRange.SomePages Then
				firstPage = pd.PrinterSettings.FromPage
				m_lastpage = pd.PrinterSettings.ToPage
				'MessageBox.Show(firstPage.ToString)
				'MessageBox.Show(m_lastpage.ToString)
			End If
			Me.m_currentPage = firstPage - 1

			Dim column As String
			Dim tryMatch As StringNameValuePair

			For Each ctrl As IDrawable In Me.Controls
				If TypeOf ctrl Is TableControl Then
					Dim tb As TableControl = CType(ctrl, TableControl)
					'tb.CurrentRow = 0
					tb.CurrentRow = (firstPage - 1) * tb.RowsPerPage
					If Not (Me.m_countPage) And firstPage > 1 Then
						tb.CurrentRow = tb.CurrentRow - CInt(Me.m_rowOffsetHash(firstPage - 1))
					End If
				Else
					'check sum column
					If TypeOf ctrl Is TextControl Then
						func = CType(ctrl, TextControl).MapCaption
						If Not func Is Nothing Then
							tryMatch = Me.GetFunc(func)
							If Not tryMatch Is Nothing Then
								Select Case tryMatch.Name.ToLower
									Case "sum"
										column = tryMatch.Value.ToLower
										Me.m_sumHash(column) = 0
									Case "sumpage"
										column = tryMatch.Value.ToLower
										Me.m_sumPageColHash(column) = 0
								End Select
							End If
						End If
					End If
					'end check sum column
				End If
			Next
			If m_sumHash.Count > 0 Then
				Dim oldValue As Decimal = 0
				Dim level As String = ""
				Dim row As Integer = 0
				Dim dummyitem As DocPrintingItem

				For Each item As DocPrintingItem In m_tableColl

					If row < item.Row AndAlso Not (level = "nothing") Then
						row = item.Row
						dummyitem = m_tableColl.GetMappingItem(item.Table, "Group Level", item.Row)
						If dummyitem Is Nothing Then
							level = "nothing"
						Else
							level = CStr(dummyitem.Value)
						End If

					End If

					If Me.m_sumHash.Contains(item.Mapping.ToLower) Then

						If level = "0" OrElse level = "nothing" Then

							Dim obj As Object = Me.m_sumHash(item.Mapping.ToLower)
							If IsNumeric(obj) Then
								oldValue = CDec(obj)
							End If
							If IsNumeric(item.Value) Then
								Me.m_sumHash(item.Mapping.ToLower) = oldValue + Configuration.Format(CDec(item.Value), DigitConfig.Price)
							End If

						End If
					End If
				Next
			End If
		End Sub
		Protected Overridable Sub PrintPage_Handler(ByVal sender As Object, ByVal pe As PrintPageEventArgs)
			Dim g As Graphics = pe.Graphics
			Me.m_currentPage += 1
			m_sumPageHash = New Hashtable

			Dim eot As Boolean = True
			Try
				For Each ctrl As IDrawable In Me.Controls
					workTableRow = -1
					If Not TypeOf ctrl Is TableControl Then
						Dim f As DocPrintingItem.Frequency = DocPrintingItem.Frequency.EveryPage
						If Me.m_currentPage = 1 Then
							f = DocPrintingItem.Frequency.FirstPage
						ElseIf Me.m_currentPage = Me.m_pageCount Then
							f = DocPrintingItem.Frequency.LastPage
						End If
						If ProcessControl(ctrl, f) Then
							ctrl.Draw(pe.Graphics)
						End If
          Else            
            Dim tb As TableControl = CType(ctrl, TableControl)
            If Me.m_pageCount = 1 OrElse Not tb.LastPage OrElse Me.m_currentPage = Me.m_pageCount Then
              tb.Draw(pe.Graphics)
              If Not m_tableColl Is Nothing Then
                Dim startRow As Integer = tb.CurrentRow + 1
                Dim verticalInterval As Integer = 5
                Dim horizontalInterval As Integer = 5
                Dim currentPageRow As Integer = 0
                Dim rowOffset As Integer = 0
                For i As Integer = startRow To (tb.RowsPerPage + startRow - 1)
                  If i > tb.RowCount Then
                    'เกินจำนวนแล้ว
                    Exit For
                  End If

                  '---------------แบบนี้จะไปขึ้นหน้าสุดท้ายแบบตลกๆ
                  'Dim checking As Integer = tb.RowsPerPage
                  'If Me.m_currentPage = Me.m_pageCount - 1 Then
                  '    checking = tb.RowsPerLastPage
                  'End If
                  'If currentPageRow + rowOffset + 1 > checking Then
                  '    'เกินจำนวนแล้ว
                  '    Exit For
                  'End If
                  '----------------------------------------------------

                  If currentPageRow + rowOffset + 1 > tb.RowsPerPage Then
                    'เกินจำนวนแล้ว
                    Exit For
                  End If


                  tb.CurrentRow = i
                  Dim colOffset As Integer = 0
                  Dim maxLines As Integer = 0
                  Dim rowInfoItem As DocPrintingItem
                  rowInfoItem = Me.ParseTableItem(tb.TableName, "Group Level", i)
                  For Each col As Column In tb.Columns
                    colOffset = col.Width + colOffset
                    Dim _DataType As String = ""
                    Dim _Value As Object = Nothing
                    Dim _Mapping As String = ""
                    Dim _LineStyle As Integer = 0
                    Dim _Font As Font = Nothing
                    Dim item As DocPrintingItem = Nothing
                    Dim data As String = ""

                    If col.ReportField Like "=*" Then
                      data = col.ReportField.Replace("=", "")
                      data = ProcessTableItem(tb.TableName, data, i)
                    Else
                      item = Me.ParseTableItem(tb.TableName, col.ReportField, i)
                      If Not item Is Nothing Then
                        If Not item.DataType Is Nothing Then
                          _DataType = item.DataType
                        End If
                        If Not item.Value Is Nothing Then
                          _Value = item.Value
                        End If
                        If Not item.Mapping Is Nothing Then
                          _Mapping = item.Mapping.ToLower
                        End If
                        _LineStyle = item.LineStyle
                        If Not item.Font Is Nothing Then
                          _Font = item.Font
                        End If
                      End If
                    End If

                    If Not (_Value Is Nothing) And Not (_Mapping = "") Then
                      Dim oldValue As Decimal = 0
                      If Me.m_sumPageColHash.Contains(_Mapping) Then
                        If rowInfoItem Is Nothing OrElse (Not (rowInfoItem Is Nothing) AndAlso (CStr(rowInfoItem.Value) = "0")) Then

                          Dim obj As Object = Me.m_sumPageHash(_Mapping)
                          If IsNumeric(obj) Then
                            oldValue = CDec(obj)
                          End If
                          If IsNumeric(item.Value) Then
                            Me.m_sumPageHash(_Mapping) = oldValue + Configuration.Format(CDec(_Value), DigitConfig.Price)
                          End If

                        End If
                      End If
                    End If

                    If Not (_Value Is Nothing) And Not (_DataType = "") Then
                      If _DataType = "System.Boolean" Then
                        If CBool(item.Value) = True Then
                          Dim glyphSize As Integer = 15
                          Dim startPoint As Integer
                          Select Case col.Alignment
                            Case HorizontalAlignment.Center
                              startPoint = CInt((col.Width / 2) - (glyphSize / 2)) + colOffset - col.Width
                            Case HorizontalAlignment.Left
                              startPoint = colOffset - col.Width + horizontalInterval
                            Case HorizontalAlignment.Right
                              startPoint = CInt(colOffset - glyphSize - horizontalInterval)
                          End Select
                          ControlPaint.DrawMenuGlyph(pe.Graphics, tb.Location.X + startPoint, tb.Location.Y + (i - startRow) * tb.RowHeight + verticalInterval, glyphSize, glyphSize, MenuGlyph.Checkmark)
                        End If
                      Else
                        Select Case _DataType.ToLower
                          Case "system.datetime"
                            If IsDate(_Value) Then
                              Dim itemDate As DateTime = CDate(_Value)
                              data = itemDate.ToShortDateString
                            Else
                              data = _Value.ToString
                            End If
                          Case "system.integer"
                            Dim itemValue As Integer
                            If _Value.ToString.Length > 0 Then
                              If IsNumeric(_Value) Then
                                itemValue = CInt(_Value)
                                data = Configuration.FormatToString(itemValue, DigitConfig.Int)
                              Else
                                data = _Value.ToString
                              End If
                            Else
                              data = _Value.ToString
                            End If
                          Case "system.decimal"
                            Dim itemValue As Decimal
                            If _Value.ToString.Length > 0 Then
                              If IsNumeric(_Value) Then
                                itemValue = CDec(_Value)
                                If itemValue = 0 Then
                                  data = ""
                                Else
                                  data = Configuration.FormatToString(itemValue, DigitConfig.Price)
                                End If
                              Else
                                data = _Value.ToString
                              End If
                            Else
                              data = _Value.ToString
                            End If
                          Case Else
                            data = _Value.ToString
                        End Select
                      End If
                      'Else
                      '	data = ProcessTableItem(tb.TableName, data, i)
                    End If

                    If Not (data = "") Then


                      Dim dataFont As Font
                      If Not col.Font Is Nothing Then
                        If Not _Font Is Nothing Then
                          'ใช้ Style จาก font ใน item
                          dataFont = New Font(col.Font.FontFamily.Name, col.Font.Size, _Font.Style, GraphicsUnit.Point, CType(222, Byte))
                        Else
                          dataFont = New Font(col.Font.FontFamily.Name, col.Font.Size, col.Font.Style, GraphicsUnit.Point, CType(222, Byte))
                        End If
                      ElseIf Not _Font Is Nothing Then
                        dataFont = New Font(_Font.FontFamily.Name, _Font.Size, _Font.Style, GraphicsUnit.Point, CType(222, Byte))
                      Else
                        dataFont = New Font(tb.Font.FontFamily.Name, tb.Font.Size, tb.Font.Style, System.Drawing.GraphicsUnit.Point, tb.Font.GdiCharSet)
                      End If
                      Dim stf As New StringFormat
                      stf.Trimming = StringTrimming.None
                      stf.FormatFlags = StringFormatFlags.NoClip
                      Select Case col.Alignment
                        Case HorizontalAlignment.Center
                          stf.LineAlignment = StringAlignment.Near
                          stf.Alignment = StringAlignment.Center
                        Case HorizontalAlignment.Left
                          stf.LineAlignment = StringAlignment.Near
                          stf.Alignment = StringAlignment.Near
                        Case HorizontalAlignment.Right
                          stf.LineAlignment = StringAlignment.Near
                          stf.Alignment = StringAlignment.Far
                      End Select
                      Dim innerRow() As String = Split(data, "|br|")
                      Dim p As New PointF(0, 0)
                      Dim indentSize As SizeF = g.MeasureString("|", dataFont, p, stf)
                      Dim x1 As Integer
                      Dim y1 As Integer

                      If innerRow.Length > 1 Then
                        Dim allLine As Integer = 0
                        For irow As Integer = 0 To innerRow.Length - 1 Step 1
                          Dim textSize As SizeF = g.MeasureString(Trim(innerRow(irow)), dataFont, p, stf)
                          Dim indent As Integer = indentSize.Width * IndentCount(innerRow(irow))
                          Dim lines As Integer = CInt(Math.Ceiling((textSize.Width) / (col.Width - indent)))                        '+6?
                          allLine += lines
                        Next
                        maxLines = allLine
                        If (currentPageRow + rowOffset + maxLines) > tb.RowsPerPage Then
                          'เกินจำนวนแล้ว
                          tb.CurrentRow -= 1
                          Exit For
                        End If
                        Dim passLine As Integer = 0
                        For irow As Integer = 0 To innerRow.Length - 1 Step 1
                          x1 = (tb.Location.X + colOffset) - col.Width
                          y1 = tb.Location.Y + ((i - startRow + rowOffset + passLine) * tb.RowHeight)
                          Dim textSize As SizeF = g.MeasureString(Trim(innerRow(irow)), dataFont, p, stf)
                          Dim indent As Integer = indentSize.Width * IndentCount(innerRow(irow))
                          Dim lines As Integer = CInt(Math.Ceiling((textSize.Width) / (col.Width - indent)))                        '+6?
                          passLine += lines
                          Dim drawRect As New RectangleF(x1 + indent, y1, col.Width - indent, tb.RowHeight * maxLines)
                          pe.Graphics.DrawString(Trim(innerRow(irow)), dataFont, New SolidBrush(tb.ForeColor), drawRect, stf)
                        Next
                      Else
                        x1 = (tb.Location.X + colOffset) - col.Width
                        y1 = tb.Location.Y + ((i - startRow + rowOffset) * tb.RowHeight)
                        Dim textSize As SizeF = g.MeasureString(Trim(data), dataFont, p, stf)
                        Dim indent As Integer = indentSize.Width * IndentCount(data)
                        Dim lines As Integer = CInt(Math.Ceiling((textSize.Width) / (col.Width - indent)))                      '+6?
                        If lines > maxLines Then
                          maxLines = lines
                        End If
                        If (currentPageRow + rowOffset + maxLines) > tb.RowsPerPage Then
                          'เกินจำนวนแล้ว
                          tb.CurrentRow -= 1
                          Exit For
                        End If
                        Dim drawRect As New RectangleF(x1 + indent, y1, col.Width - indent, tb.RowHeight * maxLines)
                        pe.Graphics.DrawString(Trim(data), dataFont, New SolidBrush(tb.ForeColor), drawRect, stf)

                      End If

                      ' DrawLine Style
                      x1 = (tb.Location.X + colOffset) - col.Width
                      y1 = tb.Location.Y + ((i - startRow + rowOffset) * tb.RowHeight)
                      Select Case _LineStyle
                        Case 0                      'None
                        Case 1                      'Single
                          pe.Graphics.DrawLine(Pens.Black, x1 + 5, y1 + (tb.RowHeight * maxLines), x1 + col.Width - 5, y1 + (tb.RowHeight * maxLines))
                        Case 2                      'Double
                          pe.Graphics.DrawLine(Pens.Black, x1 + 5, y1 + (tb.RowHeight * maxLines) - 2, x1 + col.Width - 5, y1 + (tb.RowHeight * maxLines) - 2)
                          pe.Graphics.DrawLine(Pens.Black, x1 + 5, y1 + (tb.RowHeight * maxLines) - 4, x1 + col.Width - 5, y1 + (tb.RowHeight * maxLines) - 4)
                      End Select
                    End If

                  Next                'Col
                  '''''
                  currentPageRow += 1
                  If maxLines > 1 Then
                    rowOffset += maxLines - 1
                  End If
                Next              'Row
                If Me.m_countPage Then
                  If Me.m_rowOffsetHash.Contains(Me.m_currentPage - 1) Then
                    Me.m_rowOffsetHash(Me.m_currentPage) = rowOffset + Me.m_rowOffsetHash(Me.m_currentPage - 1)
                  Else
                    Me.m_rowOffsetHash(Me.m_currentPage) = rowOffset
                  End If
                End If
              End If
              eot = eot And tb.EndOfTable
            End If 'Me.m_pageCount = 1 OrElse Not tb.LastPage OrElse Me.m_currentPage = Me.m_pageCount Then
					End If					' IS TABLE
				Next
			Catch ex As Exception
				MessageBox.Show(ex.ToString)
			End Try
			If (Not eot OrElse (Me.m_currentPage = Me.m_pageCount - 1)) AndAlso m_currentPage < m_lastpage Then
				pe.HasMorePages = True
			Else
				pe.HasMorePages = False
			End If
		End Sub
		Protected Function ProcessControl(ByVal ctrl As IDrawable, ByVal f As DocPrintingItem.Frequency) As Boolean
			Dim candraw As Boolean = True
			If TypeOf ctrl Is BorderyControl Then
				If TypeOf ctrl Is TextControl Then
					Dim data As String = CType(ctrl, TextControl).MapCaption
					data = Me.Evaluate(data)
					data = Me.Parse(data)
					If Not Me.m_entity Is Nothing AndAlso Not data Is Nothing AndAlso data.StartsWith("=") AndAlso Not data.EndsWith("=") Then
						data = data.Substring(1, Len(data) - 1)
						Dim item As DocPrintingItem = m_tableColl.GetMappingItem(data)
						If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
							data = item.Value.ToString
						Else
							data = ""
						End If
						If Not item Is Nothing Then
							If Me.m_pageCount = 1 Then
								candraw = True
							Else
								Select Case item.PrintingFrequency
									Case DocPrintingItem.Frequency.EveryPage
										candraw = True
									Case DocPrintingItem.Frequency.FirstPage
										If f <> DocPrintingItem.Frequency.FirstPage Then
											candraw = False
										End If
									Case DocPrintingItem.Frequency.LastPage
										If f <> DocPrintingItem.Frequency.LastPage Then
											candraw = False
										End If
								End Select
							End If
						End If
					End If
					CType(ctrl, TextControl).Caption = data
				ElseIf Not Me.m_entity Is Nothing AndAlso TypeOf ctrl Is CheckboxControl Then
					Dim chk As CheckboxControl = CType(ctrl, CheckboxControl)
					Dim item As DocPrintingItem = m_tableColl.GetMappingItem(chk.CheckCondition)
					If Not item Is Nothing Then
						chk.Checked = CheckState.On
					End If
				ElseIf Not Me.m_entity Is Nothing AndAlso TypeOf ctrl Is TextFieldControl Then
					'หาค่า Caption:
					Dim caption As String = CType(ctrl, TextFieldControl).Caption
					caption = Me.Evaluate(caption)
					caption = Me.Parse(caption)
					CType(ctrl, TextFieldControl).Caption = caption

					Dim data As String = CType(ctrl, TextFieldControl).MapText
					'หาค่า Text:
					data = Me.Evaluate(data)
					data = Me.Parse(data)
					If Not Me.m_entity Is Nothing AndAlso Not data Is Nothing AndAlso data.StartsWith("=") AndAlso Not data.EndsWith("=") Then
						data = data.Substring(1, Len(data) - 1)
						Dim item As DocPrintingItem = m_tableColl.GetMappingItem(data)
						If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
							data = item.Value.ToString
						Else
							data = ""
						End If
						If Not item Is Nothing Then
							If Me.m_pageCount = 1 Then
								candraw = True
							Else
								Select Case item.PrintingFrequency
									Case DocPrintingItem.Frequency.EveryPage
										candraw = True
									Case DocPrintingItem.Frequency.FirstPage
										If f <> DocPrintingItem.Frequency.FirstPage Then
											candraw = False
										End If
									Case DocPrintingItem.Frequency.LastPage
										If f <> DocPrintingItem.Frequency.LastPage Then
											candraw = False
										End If
								End Select
							End If
						End If
					End If
					CType(ctrl, TextFieldControl).Text = data
				End If
			End If
			If TypeOf ctrl Is ImageControl Then
				Dim imgc As ImageControl = CType(ctrl, ImageControl)
				If Not imgc.Path Is Nothing AndAlso imgc.Path.StartsWith("=") Then
					imgc.Image = CType(GetObject(imgc.Path), Image)
				End If
			End If

			If TypeOf ctrl Is AdobeControl Then
				Dim actrl As AdobeControl = CType(ctrl, AdobeControl)
				If Me.m_pageCount = 1 Then
					candraw = True
				Else
					If actrl.Name Is Nothing Then
						candraw = True
					Else
						Dim isFirstPage As Boolean = (actrl.Name.ToLower.StartsWith("firstpage"))
						Dim isLastPage As Boolean = (actrl.Name.ToLower.StartsWith("lastpage"))
						Select Case f
							Case DocPrintingItem.Frequency.EveryPage
								candraw = True
								If isFirstPage OrElse isLastPage Then
									candraw = False
								End If
							Case DocPrintingItem.Frequency.FirstPage
								candraw = True
								If isLastPage Then
									candraw = False
								End If
							Case DocPrintingItem.Frequency.LastPage
								candraw = True
								If isFirstPage Then
									candraw = False
								End If
						End Select
					End If
				End If
			End If
			Return candraw
		End Function
		Private workTableRow As Integer
		Private workTable As String
		Private Function ProcessTableItem(ByVal tableName As String, ByVal dat As String, ByVal row As Integer) As String
			Dim ret As String
			workTableRow = row
			workTable = tableName
			ret = Evaluate(dat)
			ret = Parse(ret)
			Return ret
		End Function
		Protected Function GetObject(ByVal data As String) As Object
			If Not data Is Nothing Then
				If data.ToLower.StartsWith("=pic") Then
					Dim map As String = data.Substring(1, Len(data) - 1)
					Dim item As DocPrintingItem = m_tableColl.GetMappingItem(map)
					If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
						Return item.Value
					End If
				ElseIf data.StartsWith("=") Then
					Dim map As String = data.Substring(1, Len(data) - 1)
					Dim config As Object = Configuration.GetConfig(map)
					If Not config Is Nothing Then
						Return config
					End If
				End If
			End If
		End Function
		Private Function IndentCount(ByVal data As String) As Integer
			Dim diff As Integer
			diff = Len(data) - Len(LTrim(data))
			Return diff
		End Function
#End Region

#Region "Shared"
    Private Const dpi As Integer = 98
    Public Shared Function GetPaperSize(ByVal name As String, ByVal size As String) As PaperSize
      Dim re As New Regex("(?<Num>[0-9][0-9]*(?:\.[0-9]*)?)(?<Unit>[a-zA-Z]*)")
      Dim ms As MatchCollection = re.Matches(size)
      Dim w As Decimal = 0
      Dim h As Decimal = 0
      If ms.Count = 2 Then
        w = AnyThingToPixel(ms(0).Value)
        h = AnyThingToPixel(ms(1).Value)
      End If
      Return New PaperSize(name, w, h)
    End Function
		Public Shared Function AnyThingToPixel(ByVal valueString As String) As Integer
			Dim re As New Regex("(?<Num>[0-9][0-9]*(?:\.[0-9]*)?)(?<Unit>[a-zA-Z]*)")
			Dim value As Decimal
			Dim unit As String
			Dim m As Match = re.Match(valueString)
			value = CDec(m.Groups("Num").Value)
			unit = m.Groups("Unit").Value
			Select Case unit.ToLower
				Case "mm", "mm."
					value = CDec(0.0393700787 * dpi * value)
				Case "cm", "cm."
					value = CDec(0.393700787 * dpi * value)
				Case "in", "in."
          value = dpi * value
          'Case Else
          'value = dpi * value
      End Select
			Return CInt(value)
		End Function
		Public Shared Function GetFontFromNode(ByVal xmlNode As XmlNode) As Font
			Dim size As Integer = 10
			Dim face As String = "Tahoma"
			Dim style As FontStyle = FontStyle.Regular
			For Each xmlAttr As XmlAttribute In xmlNode.Attributes
				Select Case xmlAttr.Name.ToLower
					Case "typeface"
						face = xmlAttr.Value
					Case "weight"
						style = style Or FontStyle.Bold
					Case "posture"
						style = style Or FontStyle.Italic
					Case "underline"
						style = style Or FontStyle.Underline
					Case "linethrough"
						style = style Or FontStyle.Strikeout
					Case "size"
						'Hack แอบใช้ function นี้ (ขี้เกียจเขียน)
						size = AnyThingToPixel(xmlAttr.Value)
				End Select
			Next
			Dim f As Font = New Font(face, size, style, GraphicsUnit.Point, CType(222, Byte))
			Return f
		End Function
#End Region

	End Class

  Public Class StringNameValuePair
    Public Name As String
    Public Value As String
    Public Sub New(ByVal _name As String, ByVal _value As String)
      Name = _name
      Value = _value
    End Sub
  End Class
  Public Interface IDrawable
    Sub Draw(ByVal g As Graphics)
    Sub Draw(ByVal g As Graphics, ByVal loc As Point)
    Sub Draw(ByVal g As Graphics, ByVal loc As Point, ByVal data As String)
    Sub Draw(ByVal g As Graphics, ByVal loc As Point, ByVal image As Image)
    Property Data() As String
  End Interface

  <Serializable(), DefaultMember("Item")> _
  Public Class IDrawableCollection
    Inherits CollectionBase

#Region "Members"
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As IDrawable
      Get
        Return CType(MyBase.List.Item(index), IDrawable)
      End Get
      Set(ByVal value As IDrawable)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region


#Region "Collection Methods"
    Public Function Add(ByVal value As IDrawable) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As IDrawableCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As IDrawable())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As IDrawable) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As IDrawable(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As IDrawableEnumerator
      Return New IDrawableEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As IDrawable) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As IDrawable)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As IDrawable)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As IDrawableCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class IDrawableEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As IDrawableCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, IDrawable)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class
  End Class
  Public Interface IHasRootPath
    Property RootPath() As String
  End Interface
  Public Class PageCountPrintController
    Inherits PreviewPrintController

#Region "Members"
    Private m_pageCount As Integer = 0
#End Region

#Region "Methods"
    Public Overrides Sub OnStartPrint(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintEventArgs)
      MyBase.OnStartPrint(document, e)
      Me.m_pageCount = 0
    End Sub
    Public Overrides Function OnStartPage(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintPageEventArgs) As System.Drawing.Graphics
      Me.m_pageCount += 1
      Return MyBase.OnStartPage(document, e)
    End Function
    Public Shared Function GetPageCount(ByVal document As PrintDocument) As Integer
      If document Is Nothing Then
        Throw New ArgumentException("PrintDocument must be set.")
      End If
      Dim existingController As PrintController = document.PrintController
      Dim controller As New PageCountPrintController
      document.PrintController = controller
      document.Print()
      document.PrintController = existingController
      Return controller.PageCount
    End Function
#End Region

#Region "Properties"
    Public ReadOnly Property PageCount() As Integer
      Get
        Return Me.m_pageCount
      End Get
    End Property
#End Region

  End Class
End Namespace
