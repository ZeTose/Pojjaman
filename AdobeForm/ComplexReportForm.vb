Imports System.Xml
Imports System.Drawing.Printing
Imports System.Reflection
Imports System.IO
Imports System.Text.RegularExpressions
Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Core.Services
Imports Longkong.Core.Properties
Namespace Longkong.AdobeForm
    Public Class ComplexReportForm

#Region "Members"
        Private m_controls As IDrawableCollection
        Private m_vMargin As Integer
        Private m_hMargin As Integer
        Private m_printerSettings As PrinterSettings

        Protected m_tbs As ArrayList
        Protected m_entity As ComplexReport
        Protected m_coll As DocPrintingItemCollection
        Protected m_currentPage As Integer
        Protected m_pageCount As Integer

        Private m_filePath As String
        Private Shared FormPath As String = ""
        Private Shared ReportPath As String = ""
#End Region

#Region "Constructors"
        Shared Sub New()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            FormPath = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
            ReportPath = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
        End Sub
        Public Sub New()
            m_controls = New IDrawableCollection
            m_printerSettings = New PrinterSettings
        End Sub
        Public Sub New(ByVal prinTableEntity As IPrintableEntity)
            Me.New()
            Dim thePath As String = ""

            thePath = ReportPath & Path.DirectorySeparatorChar & CType(prinTableEntity, Report).ClassName & ".xml"

            If Not File.Exists(thePath) Then
                Return
            End If
            m_filePath = Path.GetFullPath(thePath).Replace(Path.GetFileName(thePath), "").TrimEnd(Path.DirectorySeparatorChar)
            Dim doc As New XmlDocument
            doc.Load(thePath)
            m_entity = CType(prinTableEntity, ComplexReport)
            Me.Construct(doc.DocumentElement)
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
            m_entity = CType(prinTableEntity, ComplexReport)
            Me.Construct(doc.DocumentElement)
            Init()
        End Sub
        Private Sub Construct(ByVal xmlNode As XmlNode)
            ProcessXmlNode(xmlNode)
        End Sub
#End Region

#Region "Init"
        Public Sub Init()
            m_pageCount = 0
            m_currentPage = 0
            m_tbs = New ArrayList
            For Each ctrl As Object In Me.Controls
                If TypeOf ctrl Is TableControl Then
                    m_tbs.Add(ctrl)
                End If
            Next
            m_coll = Me.m_entity.GetDocPrintingEntries
            If m_coll Is Nothing Then
                m_coll = New DocPrintingItemCollection
            End If
            If TypeOf m_entity Is IHasCustomNote Then
                Dim coll As CustomNoteCollection = CType(m_entity, IHasCustomNote).GetCustomNoteCollection
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
                    m_coll.Add(dpi)
                Next
            End If
            SetPageCount()
        End Sub
        Public Sub SetPageCount()
            If m_tbs.Count > 0 Then
                Dim tb As TableControl = CType(m_tbs(0), TableControl)
                If tb.RowsPerPage > 0 Then
                    Dim arr As ArrayList = Me.m_entity.ItemCollection.GetPageCountSets
                    Dim ret As Integer = 0
                    For Each cnt As Integer In arr
                        ret += CInt(Math.Ceiling(cnt / tb.RowsPerPage))
                    Next
                    m_pageCount = ret
                End If
            End If
        End Sub
        Public Function GetPageCount() As Integer
            Return m_pageCount
        End Function
#End Region

#Region "Properties"
        Public ReadOnly Property FilePath() As String            Get                Return m_filePath            End Get        End Property
        Public Property Controls() As IDrawableCollection            Get                Return m_controls            End Get            Set(ByVal Value As IDrawableCollection)                m_controls = Value            End Set        End Property
        Public Property VMargin() As Integer            Get                Return m_vMargin            End Get            Set(ByVal Value As Integer)                m_vMargin = Value            End Set        End Property        Public Property HMargin() As Integer            Get                Return m_hMargin            End Get            Set(ByVal Value As Integer)                m_hMargin = Value            End Set        End Property
        Public Sub UpdatePrinterSettings(ByVal pd As PrintDocument)
            pd.DefaultPageSettings.Landscape = Me.m_printerSettings.DefaultPageSettings.Landscape
            pd.DefaultPageSettings.PaperSize = Me.m_printerSettings.DefaultPageSettings.PaperSize
            pd.DefaultPageSettings.Margins.Bottom = Me.m_vMargin
            pd.DefaultPageSettings.Margins.Top = Me.m_vMargin
            pd.DefaultPageSettings.Margins.Left = Me.m_hMargin
            pd.DefaultPageSettings.Margins.Right = Me.m_hMargin
        End Sub
        Public ReadOnly Property PrintDocument() As PrintDocument
            Get
                Dim pd As New PrintDocument
                AddHandler pd.BeginPrint, AddressOf BeginPrint_Handler
                AddHandler pd.PrintPage, AddressOf PrintPage_Handler
                UpdatePrinterSettings(pd)
                Return pd
            End Get
        End Property
        Private m_lastpage As Integer = 0
        Protected Overridable Sub BeginPrint_Handler(ByVal sender As Object, ByVal pe As PrintEventArgs)
            Dim pd As PrintDocument = CType(sender, PrintDocument)
            Dim firstPage As Integer = 1
            m_lastpage = Me.m_pageCount
            If pd.PrinterSettings.PrintRange = PrintRange.SomePages Then
                firstPage = pd.PrinterSettings.FromPage
                m_lastpage = pd.PrinterSettings.ToPage
            End If
            Me.m_currentPage = firstPage - 1
        End Sub
        Private m_currentRow As Integer
        Protected Overridable Sub PrintPage_Handler(ByVal sender As Object, ByVal pe As PrintPageEventArgs)
            Dim g As Graphics = pe.Graphics
            'Undone: Refactor please!!!!
            Me.m_currentPage += 1
            Try
                For Each ctrl As IDrawable In Me.Controls
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
                        'tb.Draw(pe.Graphics)
                        If Not Me.m_entity Is Nothing Then
                            Dim startRow As Integer = m_currentRow + 1
                            Dim colOffset As Integer = 0
                            Dim verticalInterval As Integer = 5
                            Dim horizontalInterval As Integer = 5

                            Dim colIndex As Integer = 0
                            For Each col As ComplexReportColumn In Me.m_entity.ColumnCollection
                                colIndex += 1
                                Dim colWidth As Integer = CInt((col.WidthPercent / 100) * tb.Width)
                                colOffset = colWidth + colOffset

                                Dim headerFont As Font
                                headerFont = New Font(tb.Font.FontFamily.Name, tb.Font.Size, tb.Font.Style, System.Drawing.GraphicsUnit.Point, tb.Font.GdiCharSet)
                                Dim colstf As New StringFormat
                                colstf.Trimming = StringTrimming.EllipsisWord
                                Select Case col.Alignment
                                    Case HorizontalAlignment.Center
                                        colstf.LineAlignment = StringAlignment.Center
                                        colstf.Alignment = StringAlignment.Center
                                    Case HorizontalAlignment.Left
                                        colstf.LineAlignment = StringAlignment.Center
                                        colstf.Alignment = StringAlignment.Near
                                    Case HorizontalAlignment.Right
                                        colstf.LineAlignment = StringAlignment.Center
                                        colstf.Alignment = StringAlignment.Far
                                End Select
                                Dim colx1 As Integer = tb.Location.X + colOffset - colWidth '+ horizontalInterval
                                Dim coly1 As Integer = tb.Location.Y - tb.RowHeight
                                Dim colDrawRect As New RectangleF(colx1, coly1, colWidth, tb.RowHeight)
                                pe.Graphics.DrawString(col.Name, headerFont, New SolidBrush(tb.ForeColor), colDrawRect, colstf)

                                Dim rowOffset As Integer = 0
                                Dim rowsInPage As Integer = 0
                                For i As Integer = startRow To (tb.RowsPerPage + startRow - 1)
                                    rowsInPage += 1
                                    If rowsInPage > tb.RowsPerPage Then
                                        Exit For
                                    End If
                                    If colIndex = 1 Then
                                        m_currentRow += 1
                                    End If
                                    If i > Me.m_entity.ItemCollection.Count Then
                                        'เกินจำนวนแล้ว
                                        Exit For
                                    End If
                                    Dim ffi As ComplexReportItem = Me.m_entity.ItemCollection(i - 1)
                                    If ffi.IsNewPage And i <> startRow Then
                                        'ขึ้นหน้าใหม่
                                        If colIndex = 1 Then
                                            m_currentRow -= 1
                                        End If
                                        Exit For
                                    End If
                                    If Not ffi.IsInvisible Then
                                        rowOffset += tb.RowHeight
                                        Dim data As String
                                        Dim fff As ComplexReportData = ffi.DataCollection(col)
                                        If Not fff Is Nothing Then
                                            Dim val As Decimal = 0
                                            Dim valString As String = fff.FormulaText
                                            If fff.IsAcctFormula Or fff.IsFormula Then
                                                Dim o As Object = fff.GetUltimateValue
                                                Dim sp As String = ""
                                                For x As Integer = 1 To fff.Indentation
                                                    sp &= " "
                                                Next
                                                If IsNumeric(o) Then
                                                    val = CDec(o)
                                                    valString = sp & Configuration.FormatToString(val, DigitConfig.Price)
                                                ElseIf Not o Is Nothing Then
                                                    valString = sp & o.ToString
                                                End If
                                            End If
                                            data = valString
                                            Dim dataFont As Font
                                            dataFont = ComplexReport.StringToFont(fff.Style)
                                            If dataFont Is Nothing Then
                                                dataFont = ComplexReport.StringToFont(ffi.Style)
                                            End If
                                            If dataFont Is Nothing Then
                                                dataFont = New Font(tb.Font.FontFamily.Name, tb.Font.Size, tb.Font.Style, System.Drawing.GraphicsUnit.Point, tb.Font.GdiCharSet)
                                            End If

                                            Dim textSize As SizeF = pe.Graphics.MeasureString(data, dataFont)
                                            Dim x1 As Integer = tb.Location.X + colOffset - colWidth
                                            Dim y1 As Integer = tb.Location.Y + rowOffset
                                            Dim lineX1 As Integer
                                            Dim stf As New StringFormat
                                            stf.Trimming = StringTrimming.EllipsisWord
                                            Select Case col.Alignment
                                                Case HorizontalAlignment.Center
                                                    lineX1 = x1 + CInt((colWidth - textSize.Width) / 2)
                                                    stf.LineAlignment = StringAlignment.Center
                                                    stf.Alignment = StringAlignment.Center
                                                Case HorizontalAlignment.Left
                                                    lineX1 = x1
                                                    stf.LineAlignment = StringAlignment.Center
                                                    stf.Alignment = StringAlignment.Near
                                                Case HorizontalAlignment.Right
                                                    lineX1 = x1 + colWidth - textSize.Width
                                                    stf.LineAlignment = StringAlignment.Center
                                                    stf.Alignment = StringAlignment.Far
                                            End Select
                                            Dim drawRect As New RectangleF(x1, y1, colWidth, tb.RowHeight)
                                            pe.Graphics.DrawString(data, dataFont, New SolidBrush(tb.ForeColor), drawRect, stf)

                                            Select Case fff.Linestyle 'ffi
                                                Case 0 'None
                                                Case 1 'Single
                                                    pe.Graphics.DrawLine(Pens.Black, lineX1, y1 + tb.RowHeight, lineX1 + textSize.Width, y1 + tb.RowHeight)
                                                Case 2 'Double
                                                    pe.Graphics.DrawLine(Pens.Black, lineX1, y1 + tb.RowHeight - 2, lineX1 + textSize.Width, y1 + tb.RowHeight - 2)
                                                    pe.Graphics.DrawLine(Pens.Black, lineX1, y1 + tb.RowHeight - 4, lineX1 + textSize.Width, y1 + tb.RowHeight - 4)
                                            End Select
                                        End If 'Not fff Is Nothing 
                                    End If 'Not ffi.IsInvisible
                                Next
                            Next
                        End If
                    End If
                Next 'ctrl
                If m_currentPage < m_lastpage Then 'Me.m_pageCount Then
                    pe.HasMorePages = True
                Else
                    pe.HasMorePages = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Protected Function ProcessControl(ByVal ctrl As IDrawable, ByVal f As DocPrintingItem.Frequency) As Boolean
            If Me.m_entity Is Nothing Then
                Return True
            End If
            Dim candraw As Boolean = True
            If TypeOf ctrl Is BorderyControl Then
                Dim data As String = ""
                If TypeOf ctrl Is TextControl Then
                    data = CType(ctrl, TextControl).MapCaption
                    If Not data Is Nothing Then
                        If data.ToLower = "=page" Then
                            data = Me.m_currentPage.ToString
                        ElseIf data.ToLower = "=pages" Then
                            data = Me.m_pageCount.ToString
                        ElseIf data.ToLower = "=date" Then
                            data = Now.ToShortDateString
                        ElseIf data.ToLower = "=fulldate" Then
                            data = Now.ToLongDateString
                        ElseIf data.ToLower = "=time" Then
                            data = Now.ToShortTimeString
                        ElseIf data.ToLower.StartsWith("=fdate(") Then
                            Dim dt As String = data.Substring(7, data.Length - 8)
                            Dim item As DocPrintingItem = m_coll.GetMappingItem(dt)
                            If Not item Is Nothing AndAlso IsDate(item.Value) Then
                                Dim d As Date = CDate(item.Value)
                                data = d.ToLongDateString
                            ElseIf IsDate(dt) Then
                                data = CDate(dt).ToLongDateString
                            Else
                                data = ""
                            End If
                        ElseIf data.ToLower.StartsWith("=ctext(") Then
                            Dim num As String = data.Substring(7, data.Length - 8)
                            Dim item As DocPrintingItem = m_coll.GetMappingItem(num)
                            If Not item Is Nothing AndAlso IsNumeric(item.Value) Then
                                '=CText(Amount)
                                Dim number As Decimal = CDec(item.Value)
                                data = "(" & Configuration.FormatToString(number, DigitConfig.CurrencyText) & ")"
                            ElseIf IsNumeric(num) Then
                                '=CText(500)
                                data = "(" & Configuration.FormatToString(CDec(num), DigitConfig.CurrencyText) & ")"
                            Else
                                '.....
                                data = ""
                            End If
                        ElseIf data.ToLower.StartsWith("=lock(") Then
                            Dim tmpData() As String = data.Split(","c)
                            '=Lock(Amount,=)
                            'tmpData(0) = "=Lock(Amount"
                            'tmpData(1) = "=)"

                            Dim num As String = tmpData(0).Substring(6, tmpData(0).Length - 6) 'num="Amount"
                            Dim s As String = tmpData(1).Substring(0, tmpData(1).Length - 1) 's="="
                            Dim item As DocPrintingItem = m_coll.GetMappingItem(num)
                            If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
                                data = s & item.Value.ToString & s '=700.00=
                            Else
                                data = s & num & s '=Amount=
                            End If

                            'Fixed Value ทุกอันต้องอยู่ก่อนบรรทัดนี้:
                        ElseIf data.StartsWith("=") Then
                            Dim map As String = data.Substring(1, Len(data) - 1)
                            Dim item As DocPrintingItem = m_coll.GetMappingItem(map)
                            If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
                                data = item.Value.ToString
                            End If
                            If data.StartsWith("=") Then
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
                        ElseIf data.ToLower.StartsWith("company") Then
                            Dim config As Object = Configuration.GetConfig(data)
                            If Not config Is Nothing Then
                                data = config.ToString
                            End If
                        End If
                    End If 'Not data Is Nothing
                    CType(ctrl, TextControl).Caption = data
                ElseIf TypeOf ctrl Is TextFieldControl Then
                    CType(ctrl, TextFieldControl).Caption = Me.Parse(CType(ctrl, TextFieldControl).Caption)
                    data = CType(ctrl, TextFieldControl).MapText
                    If Not data Is Nothing Then
                        If data.ToLower = "=page" Then
                            data = Me.m_currentPage.ToString
                        ElseIf data.ToLower = "=pages" Then
                            data = Me.m_pageCount.ToString
                        ElseIf data.ToLower = "=date" Then
                            data = Now.ToShortDateString
                        ElseIf data.ToLower = "=fulldate" Then
                            data = Now.ToLongDateString
                        ElseIf data.ToLower = "=time" Then
                            data = Now.ToShortTimeString
                        ElseIf data.ToLower.StartsWith("=fdate(") Then
                            Dim dt As String = data.Substring(7, data.Length - 8)
                            Dim item As DocPrintingItem = m_coll.GetMappingItem(dt)
                            If Not item Is Nothing AndAlso IsDate(item.Value) Then
                                Dim d As Date = CDate(item.Value)
                                data = d.ToLongDateString
                            ElseIf IsDate(dt) Then
                                data = CDate(dt).ToLongDateString
                            Else
                                data = ""
                            End If
                        ElseIf data.ToLower.StartsWith("=ctext(") Then
                            Dim num As String = data.Substring(7, data.Length - 8)
                            Dim item As DocPrintingItem = m_coll.GetMappingItem(num)
                            If Not item Is Nothing AndAlso IsNumeric(item.Value) Then
                                Dim number As Decimal = CDec(item.Value)
                                data = "(" & Configuration.FormatToString(number, DigitConfig.CurrencyText) & ")"
                            ElseIf IsNumeric(num) Then
                                data = "(" & Configuration.FormatToString(CDec(num), DigitConfig.CurrencyText) & ")"
                            Else
                                data = ""
                            End If
                        ElseIf data.ToLower.StartsWith("=lock(") Then
                            Dim tmpData() As String = data.Split(","c)
                            '=Lock(Amount,=)
                            'tmpData(0) = "=Lock(Amount"
                            'tmpData(1) = "=)"

                            Dim num As String = tmpData(0).Substring(6, tmpData(0).Length - 6) 'num="Amount"
                            Dim s As String = tmpData(1).Substring(0, tmpData(1).Length - 1) 's="="
                            Dim item As DocPrintingItem = m_coll.GetMappingItem(num)
                            If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
                                data = s & item.Value.ToString & s '=700.00=
                            Else
                                data = s & num & s '=Amount=
                            End If

                            'Fixed Value ทุกอันต้องอยู่ก่อนบรรทัดนี้:
                        ElseIf data.StartsWith("=") Then
                            Dim map As String = data.Substring(1, Len(data) - 1)
                            Dim item As DocPrintingItem = m_coll.GetMappingItem(map)
                            If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
                                data = item.Value.ToString
                            End If
                            If data.StartsWith("=") Then
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
                        ElseIf data.ToLower.StartsWith("company") Then
                            Dim config As Object = Configuration.GetConfig(data)
                            If Not config Is Nothing Then
                                data = config.ToString
                            End If
                        End If
                    End If
                    CType(ctrl, TextFieldControl).Text = data
                End If
            End If
            If TypeOf ctrl Is ImageControl Then
                Dim imgc As ImageControl = CType(ctrl, ImageControl)
                If imgc.Path.StartsWith("=") Then
                    imgc.Image = CType(GetObject(imgc.Path), Image)
                End If
            End If
            Return candraw
        End Function
        Protected Function GetObject(ByVal data As String) As Object
            If Not data Is Nothing Then
                If data.ToLower.StartsWith("=pic") Then
                    Dim map As String = data.Substring(1, Len(data) - 1)
                    Dim item As DocPrintingItem = m_coll.GetMappingItem(map)
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
        Protected Function Parse(ByVal data As String) As String
            If Not data Is Nothing Then
                If data.ToLower = "=page" Then
                    data = Me.m_currentPage.ToString
                ElseIf data.ToLower = "=pages" Then
                    data = Me.m_pageCount.ToString
                ElseIf data.ToLower = "=date" Then
                    data = Now.ToShortDateString
                ElseIf data.ToLower = "=fulldate" Then
                    data = Now.ToLongDateString
                ElseIf data.ToLower = "=time" Then
                    data = Now.ToShortTimeString
                ElseIf data.ToLower.StartsWith("=fdate(") Then
                    Dim dt As String = data.Substring(7, data.Length - 8)
                    Dim item As DocPrintingItem = m_coll.GetMappingItem(dt)
                    If Not item Is Nothing AndAlso IsDate(item.Value) Then
                        Dim d As Date = CDate(item.Value)
                        data = d.ToLongDateString
                    ElseIf IsDate(dt) Then
                        data = CDate(dt).ToLongDateString
                    Else
                        data = ""
                    End If
                ElseIf data.ToLower.StartsWith("=ctext(") Then
                    Dim num As String = data.Substring(7, data.Length - 8)
                    Dim item As DocPrintingItem = m_coll.GetMappingItem(num)
                    If Not item Is Nothing AndAlso IsNumeric(item.Value) Then
                        Dim number As Decimal = CDec(item.Value)
                        data = "(" & Configuration.FormatToString(number, DigitConfig.CurrencyText) & ")"
                    ElseIf IsNumeric(num) Then
                        data = "(" & Configuration.FormatToString(CDec(num), DigitConfig.CurrencyText) & ")"
                    Else
                        data = ""
                    End If
                ElseIf data.ToLower.StartsWith("=lock(") Then
                    Dim tmpData() As String = data.Split(","c)
                    '=Lock(Amount,=)
                    'tmpData(0) = "=Lock(Amount"
                    'tmpData(1) = "=)"

                    Dim num As String = tmpData(0).Substring(6, tmpData(0).Length - 6) 'num="Amount"
                    Dim s As String = tmpData(1).Substring(0, tmpData(1).Length - 1) 's="="
                    Dim item As DocPrintingItem = m_coll.GetMappingItem(num)
                    If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
                        data = s & item.Value.ToString & s '=700.00=
                    Else
                        data = s & num & s '=Amount=
                    End If

                    'Fixed Value ทุกอันต้องอยู่ก่อนบรรทัดนี้:
                ElseIf data.StartsWith("=") Then
                    Dim map As String = data.Substring(1, Len(data) - 1)
                    Dim item As DocPrintingItem = m_coll.GetMappingItem(map)
                    If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
                        data = item.Value.ToString
                    End If
                    If data.StartsWith("=") Then
                        data = ""
                    End If
                ElseIf data.ToLower.StartsWith("company") Then
                    Dim config As Object = Configuration.GetConfig(data)
                    If Not config Is Nothing Then
                        data = config.ToString
                    End If
                End If
            End If
            Return data
        End Function
#End Region

#Region "Methods"
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
                                            Me.m_printerSettings.DefaultPageSettings.Landscape = True
                                        End If
                                        Dim thePaper As PaperSize = PJMPaper.Letter
                                        If Not mediumNode.Attributes("stock") Is Nothing Then
                                            Select Case mediumNode.Attributes("stock").Value.ToLower
                                                Case "default"
                                                    thePaper = PJMPaper.Letter
                                                Case "a3"
                                                    thePaper = PJMPaper.A4
                                                Case "a4"
                                                    thePaper = PJMPaper.A4
                                                Case "a5"
                                                    thePaper = PJMPaper.A5
                                                Case "a4extra"
                                                    thePaper = PJMPaper.A4Extra
                                            End Select
                                        End If
                                        Me.m_printerSettings.DefaultPageSettings.PaperSize = thePaper
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
#End Region

#Region "Shared"
        Private Const dpi As Integer = 98
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
                Case Else
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
End Namespace
