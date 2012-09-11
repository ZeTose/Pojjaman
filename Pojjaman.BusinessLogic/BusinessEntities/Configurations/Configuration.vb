Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns
Imports Longkong.Core.Properties
Imports System.Xml
Imports System.Text.RegularExpressions

Namespace Longkong.Pojjaman.BusinessLogic
  Public Enum DigitConfig
    Qty
    UnitPrice
    Price
    Cost
    Int
    CurrencyText
    CheckAmount
  End Enum
  Public Class Configuration

#Region "Members"
    Private m_name As String
    Private m_value As Object

    Private Shared m_logo As System.Drawing.Image

    Private Shared m_configHash As Hashtable
#End Region

#Region "Constructors"
    Shared Sub New()
      RefreshConfigurationList()
    End Sub
#End Region

#Region "Properties"
    Public Property Name() As String      Get        Return m_name      End Get      Set(ByVal Value As String)        m_name = Value      End Set    End Property    Public Property Value() As Object      Get        Return m_value      End Get      Set(ByVal Value As Object)        m_value = Value      End Set    End Property#End Region

#Region "Shared"
    Private Shared Function GetDigit(ByVal config As DigitConfig) As Integer
      Select Case config
        Case DigitConfig.Cost
          Return CInt(GetConfig("CompanyCostDigit"))
        Case DigitConfig.Price
          Return CInt(GetConfig("CompanyPriceDigit"))
        Case DigitConfig.Qty
          Return CInt(GetConfig("CompanyQtyDigit"))
        Case DigitConfig.UnitPrice
          Return CInt(GetConfig("CompanyUnitPriceDigit"))
        Case DigitConfig.Int
          Return 0
        Case DigitConfig.CurrencyText
          Return CInt(GetConfig("CompanyPriceDigit"))
        Case DigitConfig.CheckAmount
          Return GetDigit(DigitConfig.Price)
      End Select
    End Function

#Region "BathText"
    Public Shared Function FormatToString(number As String, lang As String, bigEng As String, smallEng As String) As String
      If Not IsNumeric(number) Then
        Return ""
      End If
      Dim minusSign As Integer = CInt(Configuration.GetConfig("CompanyMinusSign")) ' 1:ใช้ ()
      Dim minusText As String = ""
      Dim formatValue As String = ""
      If lang.ToLower.Trim = "th" Then
        minusText = "ลบ"
        formatValue = BahtText(number)
      Else
        minusText = "Minus "
        formatValue = EngText(number, bigEng, smallEng)
      End If

      If CDec(number) >= 0 Then
        Return String.Format("{0}", formatValue)
      Else
        If CInt(minusSign) = 1 Then 'ใช้ ()
          Return String.Format("({0})", formatValue)
        Else
          Return String.Format("{0}{1}", minusText, formatValue)
        End If
      End If



    End Function
    Public Shared Function EngText(number As String, bigEng As String, smallEng As String) As String
      If IsNumeric(number) Then
        Return MoneyConverter.Convert(CDec(number), bigEng, smallEng)
      End If
      Return ""
    End Function
    Public Shared Function BahtText(ByVal number As String) As String
      Dim parser As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim OnlyText As String = parser.Parse("${res:Global.OnlyMoney}") 'Only

      Dim BigUnit As String = Configuration.GetConfig("BigMoney").ToString 'parser.Parse("${res:Global.BigMoney}")
      Dim SmallUnit As String = Configuration.GetConfig("SmallMoney").ToString 'parser.Parse("${res:Global.SmallMoney}")

      Dim sixSet(,) As String
      Dim num As String
      Dim remain, sets, i, dgt, digt As Integer
      Dim Bfpoint, Aftpoint, satang, dgttxt As String
      'First.... the Baht Value
      Bfpoint = Trim(Split(Replace(CStr(number), ",", ""), ".")(0))
      remain = Len(Bfpoint) Mod 6
      Dim count As Integer = 0
      If remain <> 0 Then
        count = 6 - remain
      End If
      For i = 1 To count
        Bfpoint = "0" & Bfpoint
      Next
      sets = Len(Bfpoint) \ 6
      ReDim sixSet(sets, 6)
      For i = 1 To sets
        For dgt = 1 To 6
          num = Mid(Mid(Bfpoint, (6 * (i - 1) + 1), 6), dgt, 1) 'เริ่มทีละหลักตั้งแต่ซ้ายสุด
          If num = "0" Then
            num = ""
            dgttxt = ""
            If dgt = 6 Then
              If Len(Bfpoint) > 6 * i Then
                dgttxt = DigiText(6)
              End If
            End If
          ElseIf num = "1" And dgt = 5 Then
            num = ""
            dgttxt = "สิบ"
          ElseIf num = "1" And dgt = 6 And CDbl(Bfpoint) <> 1 And CDbl(Mid(Bfpoint, (6 * (i - 1) + 5), 1)) <> 0 Then
            num = "เอ็ด"
            dgttxt = ""
            If dgt = 6 Then
              If Len(Bfpoint) > 6 * i Then
                dgttxt = DigiText(6)
              End If
            End If
          ElseIf num = "2" And dgt = 5 Then
            num = "ยี่"
            dgttxt = "สิบ"
          Else
            num = numTotext(num)
            dgttxt = DigiText(dgt)
          End If
          If i = sets And dgt = 6 Then 'ครบถึงหลักสุดท้ายแล้ว
            sixSet(i, dgt) = num
          Else
            sixSet(i, dgt) = num & dgttxt
          End If
          BahtText = BahtText & sixSet(i, dgt)
        Next
      Next

      'Second ...... the Satang Value
      Dim stng(3) As String
      If UBound(Split(CStr(number), "."), 1) <> 0 Then
        Aftpoint = Left(Trim(Split(CStr(number), ".")(1)), 2)
        If Len(Aftpoint) = 1 Then
          Aftpoint = Aftpoint & "0"
        End If
        For digt = 1 To 2
          num = Mid(Aftpoint, digt, 1)
          If num = "0" Then
            num = ""
            dgttxt = ""
          ElseIf num = "1" And digt = 1 Then
            num = ""
            dgttxt = "สิบ"
          ElseIf num = "1" And digt = 2 And CDbl(Aftpoint) <> 1 Then
            num = "เอ็ด"
          ElseIf num = "2" And digt = 1 Then
            num = "ยี่"
            dgttxt = "สิบ"
          Else
            num = numTotext(num)
            dgttxt = DigiText(digt + 4)
          End If
          If digt = 1 Then
            stng(digt) = num & dgttxt
          Else
            stng(digt) = num
          End If
          satang = satang & stng(digt)
        Next
        If satang = "" Then
          satang = "ถ้วน"
        Else
          If SmallUnit Is Nothing OrElse SmallUnit.Length = 0 Then
            If CBool(Configuration.GetConfig("ShowCents")) Then
              satang = " " + Aftpoint + "/100"
            Else
              satang = ""
            End If
          Else
            satang = satang & SmallUnit
          End If
        End If
      Else
        satang = "ถ้วน"
      End If

      If BahtText = "" Then
        BahtText = satang
      Else
        BahtText = BahtText & BigUnit & satang
      End If
      If (BahtText = "บาทถ้วน") Or (BahtText = "ถ้วน") Then
        BahtText = "ศูนย์บาทถ้วน"
      End If

    End Function
    Private Shared Function DigiText(ByVal dg As Integer) As String
      Select Case dg
        Case 6
          DigiText = "ล้าน"
        Case 5
          DigiText = "สิบ"
        Case 4
          DigiText = "ร้อย"
        Case 3
          DigiText = "พัน"
        Case 2
          DigiText = "หมื่น"
        Case 1
          DigiText = "แสน"
      End Select
    End Function
    Private Shared Function numTotext(ByVal num As String) As String
      Select Case num
        Case "1"
          numTotext = "หนึ่ง"
        Case "2"
          numTotext = "สอง"
        Case "3"
          numTotext = "สาม"
        Case "4"
          numTotext = "สี่"
        Case "5"
          numTotext = "ห้า"
        Case "6"
          numTotext = "หก"
        Case "7"
          numTotext = "เจ็ด"
        Case "8"
          numTotext = "แปด"
        Case "9"
          numTotext = "เก้า"
      End Select
    End Function
    Private Shared Function ToCurrenyText(ByVal number As Decimal) As String
      Dim CurrencyFormat As Object = Configuration.GetConfig("UseEnglishCurrencyText").ToString  'EngText or ThaiText
      If CBool(CurrencyFormat) Then
        Return EnglishText(number)
      End If
      Dim txt As String = Configuration.FormatToString(Math.Abs(number), 2)
      If number < 0 Then
        Return "ลบ" & BahtText(txt)
      End If
      Return BahtText(txt)
    End Function
    Private Shared Function ToCurrenyText(ByVal number As Double) As String
      Return ToCurrenyText(CDec(number))
    End Function
#End Region

#Region "EngCurencyText"
    Private Shared Function EnglishText(ByVal number As Decimal) As String
      Dim BigMoneyEng As Object = Configuration.GetConfig("BigMoneyEng").ToString  'Currency Unit
      Dim SmallMoneyEng As Object = Configuration.GetConfig("SmallMoneyEng").ToString  'Currency Unit
      Dim MinusText As String = ""
      If number < 0 Then
        MinusText = "Minus "
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(RecentCompanies.CurrentCompany.ConnectionString _
         , CommandType.Text _
         , "SELECT dbo.fnMoneyToEnglish (" & Math.Abs(number) & ",'" & CStr(BigMoneyEng) & "','" & CStr(SmallMoneyEng) & "')" _
         )
      If ds.Tables(0).Rows.Count = 1 Then
        Return MinusText & CStr(ds.Tables(0).Rows(0)(0))
      End If
      Return ""
    End Function
#End Region

    Public Shared Function IsFormatString(ByVal st As String, ByVal config As DigitConfig) As Boolean
      Dim pattern As String = "^[+-]?[0-9]{1,3}(?:,?[0-9]{3})*\.[0-9]{" & GetDigit(config).ToString & "}$"
      Dim ret As Boolean = Regex.IsMatch(st, pattern)
      If Not ret Then
        If CInt(Configuration.GetConfig("CompanyMinusSign")) = 1 Then 'ใช้ ()
          pattern = "^\([+-]?[0-9]{1,3}(?:,?[0-9]{3})*\.[0-9]{" & GetDigit(config).ToString & "}\)$"
        Else
          pattern = "^[+-]?[0-9]{1,3}(?:,?[0-9]{3})*\.[0-9]{" & GetDigit(config).ToString & "}$"
        End If
        ret = Regex.IsMatch(st, pattern)
      End If
      Return ret
    End Function
    Public Shared Function FormatToString(ByVal number As Decimal, ByVal mindigit As Integer, ByVal maxdigit As Integer) As String
      Dim formatString As String = "N" & CStr(maxdigit)
      Return number.ToString(formatString)
      Dim digit As Integer = maxdigit
      Dim currentNumber As Decimal = number
      While digit > mindigit
        Dim currentString As String = FormatToString(currentNumber, digit)
        If currentString.EndsWith("0") Then

        End If
      End While
    End Function
    Public Shared Function FormatToString(ByVal number As Decimal, ByVal digit As Integer) As String
      Dim formatString As String = "N" & CStr(digit)
      Dim ret As String = number.ToString(formatString)
      If CInt(Configuration.GetConfig("CompanyMinusSign")) = 1 Then 'ใช้ ()
        If number < 0 Then
          ret = "(" & ret.Substring(1, Len(ret) - 1) & ")"
        End If
      End If
      Return ret
    End Function
    'Public Shared Function FormatToString(ByVal number As Decimal, ByVal config As DigitConfig, ByVal lang As String = "th") As String
    '  If config = DigitConfig.CurrencyText Then
    '    Dim minusEgText As String
    '    Dim minusThText As String
    '    If number < 0 Then
    '      minusEgText = "Minus"
    '      minusThText = "ลบ"
    '    End If
    '    number = Math.Abs(number)
    '    'Dim parser As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    '    If lang = "th" AndAlso Configuration.GetConfig("BigMoney").ToString = "บาท" Then 'parser.Parse("${res:Global.BigMoney}") = "บาท" Then
    '      Return minusThText & ToCurrenyText(number)
    '    End If
    '    Return minusEgText & " " & MoneyConverter.Convert(number)
    '  End If
    '  Dim digit As Integer = GetDigit(config)
    '  If config = DigitConfig.CheckAmount AndAlso CInt(number) = number Then
    '    digit = GetDigit(DigitConfig.Int)
    '  End If
    '  Dim formatString As String = "N" & CStr(digit)
    '  Dim ret As String = number.ToString(formatString)
    '  If CInt(Configuration.GetConfig("CompanyMinusSign")) = 1 Then 'ใช้ ()
    '    If number < 0 Then
    '      ret = "(" & ret.Substring(1, Len(ret) - 1) & ")"
    '    End If
    '  End If
    '  Return ret
    'End Function
    Public Shared Function FormatToString(ByVal number As Decimal, ByVal config As DigitConfig, Optional ByVal lang As String = "th") As String
      If config = DigitConfig.CurrencyText Then
        Dim minusEgText As String
        Dim minusThText As String
        If number < 0 Then
          minusEgText = "Minus"
          minusThText = "ลบ"
        End If
        number = Math.Abs(number)
        'Dim parser As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        If lang = "th" AndAlso Configuration.GetConfig("BigMoney").ToString = "บาท" Then 'parser.Parse("${res:Global.BigMoney}") = "บาท" Then
          Return minusThText & ToCurrenyText(number)
        End If
        Return minusEgText & " " & MoneyConverter.Convert(number)
      End If
      Dim digit As Integer = GetDigit(config)
      If config = DigitConfig.CheckAmount AndAlso CInt(number) = number Then
        digit = GetDigit(DigitConfig.Int)
      End If
      Dim formatString As String = "N" & CStr(digit)
      Dim ret As String = number.ToString(formatString)
      If CInt(Configuration.GetConfig("CompanyMinusSign")) = 1 Then 'ใช้ ()
        If number < 0 Then
          ret = "(" & ret.Substring(1, Len(ret) - 1) & ")"
        End If
      End If
      Return ret
    End Function
    Public Shared Function FormatToString(ByVal number As Decimal, ByVal config As DigitConfig, ByVal NoZero As Boolean) As String
      Dim lang As String = "th"
      If config = DigitConfig.CurrencyText Then
        Dim minusEgText As String
        Dim minusThText As String
        If number < 0 Then
          minusEgText = "Minus"
          minusThText = "ลบ"
        End If
        number = Math.Abs(number)
        'Dim parser As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        If lang = "th" AndAlso Configuration.GetConfig("BigMoney").ToString = "บาท" Then 'parser.Parse("${res:Global.BigMoney}") = "บาท" Then
          Return minusThText & ToCurrenyText(number)
        End If
        Return minusEgText & " " & MoneyConverter.Convert(number)
      End If
      Dim digit As Integer = GetDigit(config)
      If config = DigitConfig.CheckAmount AndAlso CInt(number) = number Then
        digit = GetDigit(DigitConfig.Int)
      End If
      Dim formatString As String = "N" & CStr(digit)
      Dim ret As String = number.ToString(formatString)
      If CInt(Configuration.GetConfig("CompanyMinusSign")) = 1 Then 'ใช้ ()
        If number < 0 Then
          ret = "(" & ret.Substring(1, Len(ret) - 1) & ")"
        End If
      End If
      If number = 0 AndAlso NoZero Then
        ret = ""
      End If
      Return ret
    End Function
    Public Shared Function FormatToString(ByVal number As Double, ByVal config As DigitConfig) As String
      If config = DigitConfig.CurrencyText Then
        'Dim parser As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        If Configuration.GetConfig("BigMoney").ToString = "บาท" Then
          Return ToCurrenyText(number)
        End If
        Return MoneyConverter.Convert(CDec(number))
      End If
      Dim digit As Integer = GetDigit(config)
      Dim formatString As String = "N" & CStr(digit)
      Dim ret As String = number.ToString(formatString)
      If CInt(Configuration.GetConfig("CompanyMinusSign")) = 1 Then 'ใช้ ()
        If number < 0 Then
          ret = "(" & ret.Substring(1, Len(ret) - 1) & ")"
        End If
      End If
      Return ret
    End Function
    Public Shared Function Format(ByVal number As Decimal, ByVal config As DigitConfig) As Decimal
      If config = DigitConfig.CurrencyText Then
        Return number
      End If
      Dim digit As Integer = GetDigit(config)
      Dim formatString As String = "N" & CStr(digit)
      Dim ret As String = number.ToString(formatString)
      Return CDec(ret)
    End Function
    Public Shared Function Compare(ByVal number1 As Decimal, ByVal number2 As Decimal) As Integer
      Return Compare(number1, number2, DigitConfig.Price)
    End Function
    Public Shared Function Compare(ByVal number1 As Decimal, ByVal number2 As Decimal, ByVal config As DigitConfig) As Integer
      Return Decimal.Compare(Configuration.Format(number1, config), Configuration.Format(number2, config))
    End Function
    Public Shared Function GetConfig(ByVal name As String) As Object
      If name.Length <> 0 Then
        ' Hack : สุด ๆ เลย
        If name.ToLower = "logo" Then
          Return LoadImage()
        End If
        Dim row As DataRow = CType(m_configHash(name.ToLower), DataRow)
        If Not row Is Nothing Then
          Return row("config_value")
        End If
      End If
    End Function
    Public Shared Function GetConfigDesc(ByVal name As String) As Object
      If name.Length <> 0 Then
        Dim row As DataRow = CType(m_configHash(name.ToLower), DataRow)
        If Not row Is Nothing Then
          Return row("config_description")
        End If
      End If
    End Function
    Public Shared Sub RefreshConfigurationList()
      m_configHash = New Hashtable
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select cm.*,isnull(c.config_value,cm.config_default) config_value from configuration c " & _
      "right join configurationmeta cm on cm.config_id = c.config_id")
      Dim myTable As DataTable = ds.Tables(0)
      For Each row As DataRow In myTable.Rows
        m_configHash(row("config_name").ToString.ToLower) = row
      Next
    End Sub
    Public Shared Function GetConfigId(ByVal name As String) As Integer
      If name.Length <> 0 Then
        Dim row As DataRow = CType(m_configHash(name.ToLower), DataRow)
        If Not row Is Nothing Then
          Return CInt(row("config_id"))
        End If
      End If
    End Function
#End Region

#Region "Methods"
    Public Shared Sub Save(ByVal filters As Filter())
      Dim dt As New DataTable
      dt.Columns.Add(New DataColumn("config_id", GetType(Integer)))
      dt.Columns.Add(New DataColumn("config_value", GetType(String)))
      For Each myfilter As Filter In filters
        Dim row As DataRow = dt.NewRow
        row("config_id") = GetConfigId(myfilter.Name)
        row("config_value") = myfilter.Value
        If myfilter.Name.ToLower = "logo" Then
          m_logo = CType(myfilter.Value, Image)
          SaveImage()
        Else
          dt.Rows.Add(row)
        End If
      Next
      Save(dt)
    End Sub
    Public Shared Sub Save(ByVal configTable As DataTable)

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlClient.SqlConnection(sqlConString)
      Try
        conn.Open()
        Dim da As New SqlDataAdapter("Select * from configuration", conn)
        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.Fill(ds, "config")

        With ds.Tables("config")
          For Each row As DataRow In configTable.Rows
            Dim drs As DataRow() = .Select("config_id=" & row("config_id").ToString)
            If drs.Length = 1 Then
              drs(0)("config_value") = row("config_value")
            ElseIf drs.Length = 0 Then
              Dim dr As DataRow = .NewRow
              dr("config_id") = row("config_id")
              dr("config_value") = row("config_value")
              .Rows.Add(dr)
            End If
          Next
        End With
        Dim dt As DataTable = ds.Tables("config")
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        ' Update ConfigurationLogo ...
        SaveImage()

        RefreshConfigurationList()
        Entity.RefreshEntityList()
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      Finally
        conn.Close()
      End Try



    End Sub
    Private Shared Sub SaveImage()
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlClient.SqlConnection(sqlConString)
      Dim trans As SqlTransaction
      Try
        conn.Open()
        trans = conn.BeginTransaction()

        Dim paramArrayList As New ArrayList
        paramArrayList.Add(New SqlParameter("@config_id", 45))
        paramArrayList.Add(New SqlParameter("@config_logo", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(m_logo)))
        Dim imageparams() As SqlParameter
        imageparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertConfigurationImage", imageparams)

        trans.Commit()
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
        trans.Rollback()
      Finally
        conn.Close()
      End Try
    End Sub
#End Region

#Region " Logo Configuration "
    Public Shared Function LoadImage(ByVal reader As IDataReader) As System.Drawing.Image
      m_logo = Field.GetImage(reader, "config_logo")
      Return m_logo
    End Function
    Public Shared Function LoadImage() As System.Drawing.Image
      ' Hack :
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select * from ConfigurationImage where config_id = 45 "
      Dim reader As SqlDataReader
      Try
        conn.Open()
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = sql
        reader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))
        If reader.Read Then
          Return LoadImage(reader)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      Finally
        conn.Close()
        reader = Nothing
        conn = Nothing
      End Try
      Return Nothing
    End Function
#End Region

    Public Shared Function CheckGigaSiteRight() As Boolean
      Dim properties As ConfigurationService = CType(ServiceManager.Services.GetService(GetType(ConfigurationService)), ConfigurationService)
      Dim r As Object = properties.GetProperty("Longkong.Pojjaman.GigaSiteConfiguration")
      Dim isGigaSiteRight As Boolean = False
      If r IsNot Nothing AndAlso TypeOf r Is XmlElement Then
        Dim element As XmlElement = CType(r, XmlElement)
        Dim nodes As XmlNodeList = element.Item("GigaSiteRelease").ChildNodes
        For Each chilenodes As XmlElement In nodes
          If chilenodes.Name = "RealGigaSiteRelease" Then
            For Each el As XmlElement In chilenodes
              If el.Name = "RealGigaSiteRelease" Then
                isGigaSiteRight = CBool(el.Attributes("right").InnerText) 'el.Attributes("current").InnerText
              End If
            Next
          End If
        Next

      End If

      Return isGigaSiteRight

    End Function

    Public Shared Function GetColorConfiguration(ByVal dcolor As DocumentColor) As Color
      Dim properties As ConfigurationService = CType(ServiceManager.Services.GetService(GetType(ConfigurationService)), ConfigurationService)
      Dim p As Object = properties.GetProperty("Longkong.Pojjaman.ColorConfiguration")

      Dim lkc As Color

      Dim desc As String
      Dim a As Integer
      Dim r As Integer
      Dim g As Integer
      Dim b As Integer

      If p IsNot Nothing AndAlso TypeOf p Is XmlElement Then
        Dim element As XmlElement = CType(p, XmlElement)
        Dim nodes As XmlNodeList = element.Item("ColorConfiguration").ChildNodes
        For Each chilenodes As XmlElement In nodes
          If chilenodes.Name.ToLower = "DocumentStatusColor".ToLower Then
            For Each el As XmlElement In chilenodes
              If el.Name.ToLower = [Enum].GetName(GetType(DocumentColor), dcolor).ToLower Then
                desc = CStr(el.Attributes("description").InnerText)
                a = CInt(el.Attributes("a").InnerText)
                r = CInt(el.Attributes("r").InnerText)
                g = CInt(el.Attributes("g").InnerText)
                b = CInt(el.Attributes("b").InnerText)

                lkc = Color.FromArgb(a, r, g, b)
              End If
              'Exit For
            Next
          End If
        Next

      End If

      Return lkc

    End Function
  End Class
  Public Enum DocumentColor
    Normal
    Referenced
    HoldReferenced
    PassGL
    Cancel
    Closed
    NonApprove
    Approved
    Reject
    Authorized
  End Enum

  Public Class MoneyConverter


    Private Shared oneWords As String
    Private Shared ones() As String
    Private Shared tenWords As String
    Private Shared tens() As String
    Private Shared BigUnit As String
    Private Shared SmallUnit As String
    Private Shared BigMoneyEng As String
    Private Shared SmallMoneyEng As String
    Private Shared OnlyText As String
    Shared Sub New()
      Dim parser As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      oneWords = parser.Parse("${res:Global.OneWordMoney}") '",One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Eleven,Twelve,Thirteen,Fourteen,Fifteen,Sixteen,Seventeen,Eighteen,Nineteen"
      tenWords = parser.Parse("${res:Global.TenWordMoney}") '",Ten,Twenty,Thirty,Forty,Fifty,Sixty,Seventy,Eighty,Ninety"
      OnlyText = parser.Parse("${res:Global.OnlyMoney}") 'Only

      ones = oneWords.Split(","c)
      tens = tenWords.Split(","c)

      BigUnit = Configuration.GetConfig("BigMoney").ToString 'parser.Parse("${res:Global.BigMoney}")
      SmallUnit = Configuration.GetConfig("SmallMoney").ToString 'parser.Parse("${res:Global.SmallMoney}")
      BigMoneyEng = Configuration.GetConfig("BigMoneyEng").ToString 'parser.Parse("${res:Global.BigMoney}")
      SmallMoneyEng = Configuration.GetConfig("SmallMoneyEng").ToString 'parser.Parse("${res:Global.SmallMoney}")
    End Sub

    Public Shared Function Convert(ByVal inputDec As Decimal) As String
      Return Convert(inputDec, BigUnit, SmallUnit, OnlyText)
    End Function

    Public Shared Function Convert(ByVal inputDec As Decimal, _bigEng As String, _smallEng As String) As String
      Dim bEng As String = BigMoneyEng
      Dim sEng As String = SmallMoneyEng
      If _bigEng.Length > 0 Then
        bEng = _bigEng
      End If
      If _smallEng.Length > 0 Then
        sEng = _smallEng
      End If
      Return Convert(inputDec, bEng, sEng, OnlyText)
    End Function

    Public Shared Function Convert(ByVal inputDec As Decimal, ByVal bigU As String, ByVal smallU As String, ByVal onlyT As String) As String
      Dim input As String = ""
      input = String.Format("{0:0.00}", inputDec)
      input = input.Replace("$", "").Replace(",", "")
      If input.Length > 33 Then Return "Error in input value"
      Dim output, dollars, octis, septs, sexts, quins, quads, trils, bills, mills, thous, hunds, cents As String
      Dim octi, sept, sext, quin, quad, tril, bill, mill, thou, hund, cent As Integer
      Dim centText As String = ""
      If input.IndexOf(".") > 0 Then
        dollars = input.Substring(0, input.IndexOf(".")).PadLeft(30, "0"c)
        cents = input.Substring(input.IndexOf(".") + 1).PadRight(2, "0"c)
        centText = cents
        If cents = "00" Then cents = "0"
      Else
        dollars = input.PadLeft(30, "0"c) : cents = "0"
      End If

      octi = CType(dollars.Substring(0, 3), Integer) : octis = convertHundreds(octi)
      sept = CType(dollars.Substring(3, 3), Integer) : septs = convertHundreds(sept)
      sext = CType(dollars.Substring(6, 3), Integer) : sexts = convertHundreds(sext)
      quin = CType(dollars.Substring(9, 3), Integer) : quins = convertHundreds(quin)
      quad = CType(dollars.Substring(12, 3), Integer) : quads = convertHundreds(quad)
      tril = CType(dollars.Substring(15, 3), Integer) : trils = convertHundreds(tril)
      bill = CType(dollars.Substring(18, 3), Integer) : bills = convertHundreds(bill)
      mill = CType(dollars.Substring(21, 3), Integer) : mills = convertHundreds(mill)
      thou = CType(dollars.Substring(24, 3), Integer) : thous = convertHundreds(thou)
      hund = CType(dollars.Substring(27, 3), Integer) : hunds = convertHundreds(hund)
      cent = CType(cents, Integer) : cents = convertHundreds(cent)

      output = IIf(octis.Trim = "", "", octis + " Octillion ").ToString
      output += IIf(septs.Trim = "", "", septs + " Septillion ").ToString
      output += IIf(sexts.Trim = "", "", sexts + " Sextillion ").ToString
      output += IIf(quins.Trim = "", "", quins + " Quintillion ").ToString
      output += IIf(quads.Trim = "", "", quads + " Quadrillion ").ToString
      output += IIf(trils.Trim = "", "", trils + " Trilion ").ToString
      output += IIf(bills.Trim = "", "", bills + " Billion ").ToString
      output += IIf(mills.Trim = "", "", mills + " Million ").ToString
      output += IIf(thous.Trim = "", "", thous + " Thousand ").ToString
      output += IIf(hunds.Trim = "", "", hunds).ToString
      output = IIf(output.Length = 0, "Zero " & bigU & "s and ", output + " " & bigU & "s and ").ToString
      output = IIf(output = "One " & bigU & "s and ", "One " & bigU & " and ", output).ToString

      If cents = "" Then
        If output.EndsWith("and ") Then
          output = output.Substring(0, output.Length - 4)
        End If
        output += onlyT
      Else
        If smallU Is Nothing OrElse smallU.Length = 0 Then
          If output.EndsWith("and ") Then
            output = output.Substring(0, output.Length - 4)
          End If
          If CBool(Configuration.GetConfig("ShowCents")) Then
            output += " " + centText + "/100"
          End If
        Else
          output += cents + IIf(cents = "One", " " & smallU & "", " " & smallU & "s").ToString
        End If
      End If


      Return output
    End Function

    Private Shared Function convertHundreds(ByVal input As Integer) As String
      Dim output As String
      If input <= 99 Then
        output = (convertTens(input))
      Else
        output = ones(CInt(Math.Floor(input / 100)))
        output += " Hundred "
        If input - Math.Floor(input / 100) * 100 = 0 Then
          output += ""
        Else
          output += "" + convertTens(CInt(input - Math.Floor(input / 100) * 100))
        End If
      End If
      Return output
    End Function

    Private Shared Function convertTens(ByVal input As Integer) As String
      Dim output As String
      If input < 20 Then
        output = ones(input)
        input = 0
      Else
        output = tens(CType(Math.Floor(input / 10), Integer))
        input -= CInt(Math.Floor(input / 10) * 10)
      End If
      output = output + IIf(ones(input).Trim = "", "", "-" + ones(input)).ToString
      Return output
    End Function
  End Class
  Public Class ConfigurationUser

#Region "Member"
    Private Shared m_hashData As Hashtable
#End Region

#Region "Constructor"
    Sub New(ByVal UserId As Integer)
      RefreshConfigurationList(UserId)
    End Sub
#End Region

#Region "Method"
    Public Shared Function Save(ByVal UserId As Integer, ByVal name As String, ByVal value As Object) As SaveErrorException
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlClient.SqlConnection(sqlConString)
        SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, _
                                  "UpdateConfigurationUserByName", _
                                  New SqlParameter("@UserId", UserId), _
                                  New SqlParameter("@name", name), _
                                  New SqlParameter("@value", value))

        ConfigurationUser.SetConfig(name, value)
        Return New SaveErrorException("0")
      Catch ex As SaveErrorException
        Return New SaveErrorException(ex.Message & vbCrLf & ex.InnerException.ToString)
      End Try
    End Function
    Public Shared Function GetConfig(ByVal UserId As Integer, ByVal name As String) As Object
      If name.Length <> 0 Then
        If m_hashData Is Nothing Then
          RefreshConfigurationList(UserId)
        End If
        Dim row As DataRow = CType(m_hashData(name.ToLower), DataRow)
        If Not row Is Nothing Then
          Return row("config_value")
        End If
      End If
    End Function
    Public Shared Sub SetConfig(ByVal name As String, ByVal value As Object)
      If m_hashData.Contains(name.ToLower) Then
        Dim row As DataRow = CType(m_hashData(name.ToLower), DataRow)
        row("config_value") = value
      End If
    End Sub
    'Public Shared Function GetConfigDesc(ByVal UserId As Integer, ByVal name As String) As Object
    '  If name.Length <> 0 Then
    '    If m_hashData Is Nothing Then
    '      RefreshConfigurationList(UserId)
    '    End If
    '    Dim row As DataRow = CType(m_hashData(name.ToLower), DataRow)
    '    If Not row Is Nothing Then
    '      Return row("config_description")
    '    End If
    '  End If
    'End Function

    Public Shared Function GetConfigurationUserMulltiApproveCollumnsList(ByVal UserId As Integer) As ArrayList
      Dim myArrayList As New ArrayList
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, _
                                                   CommandType.StoredProcedure, _
                                                   "GetConfigurationUserMulltiApproveCollumnsList", _
                                                   New SqlParameter("@UserId", UserId) _
                                                   )
      Dim myTable As DataTable = ds.Tables(0)
      For Each row As DataRow In myTable.Rows
        Dim drh As New DataRowHelper(row)
        Dim collName() As String = drh.GetValue(Of String)("config_name").Split("."c)
        myArrayList.Add(collName(1))
      Next

      Return myArrayList
    End Function
    Public Shared Function GetConfigurationUserMulltiApproveCollumnsList2(ByVal UserId As Integer) As Hashtable
      Dim myHash As New Hashtable
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, _
                                                   CommandType.StoredProcedure, _
                                                   "GetConfigurationUserMulltiApproveCollumnsList2", _
                                                   New SqlParameter("@UserId", UserId) _
                                                   )
      Dim myTable As DataTable = ds.Tables(0)
      For Each row As DataRow In myTable.Rows
        Dim drh As New DataRowHelper(row)
        myHash.Add(drh.GetValue(Of String)("config_name"), drh.GetValue(Of String)("config_value"))
      Next

      Return myHash
    End Function
    Public Shared Sub RefreshConfigurationList(ByVal UserId As Integer)
      m_hashData = New Hashtable
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, _
                                                   CommandType.StoredProcedure, _
                                                   "GetConfigurationUserList", _
                                                   New SqlParameter("@UserId", UserId) _
                                                   )
      Dim myTable As DataTable = ds.Tables(0)
      For Each row As DataRow In myTable.Rows
        m_hashData(row("config_name").ToString.ToLower) = row
      Next
    End Sub
    Public Shared Function GetColorConfiguration(ByVal UserId As Integer, ByVal name As String) As Color
      Dim cvalue As String = ConfigurationUser.GetConfig(UserId, name).ToString
      Dim cvaluetex() As String = cvalue.Split("/"c)
      Return Color.FromArgb(CInt(cvaluetex(0)), CInt(cvaluetex(1)), CInt(cvaluetex(2)), CInt(cvaluetex(3)))
    End Function
    'Public Shared Function GetConfigId(ByVal UserId As Integer, ByVal name As String) As Integer
    '  If name.Length <> 0 Then
    '    If m_hashData Is Nothing Then
    '      RefreshConfigurationList(UserId)
    '    End If
    '    Dim row As DataRow = CType(m_hashData(name.ToLower), DataRow)
    '    If Not row Is Nothing Then
    '      Return CInt(row("config_id"))
    '    End If
    '  End If
    'End Function
#End Region

  End Class

  Public Enum ConfigType
    Configuration
    AddIns
    Propeties
  End Enum
  Public Class ConfigurationUserControl

#Region "Member"
    Private Shared m_hashData As Hashtable
#End Region

#Region "Constructor"
    Sub New(ByVal UserId As Integer)
      RefreshConfigurationList(UserId)
    End Sub
#End Region

#Region "Method"
    'Public Shared Function Save(ByVal UserId As Integer, ByVal name As String, ByVal value As Object) As SaveErrorException
    '  Try
    '    Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
    '    Dim conn As New SqlClient.SqlConnection(sqlConString)
    '    SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, _
    '                              "UpdateConfigurationUserByName", _
    '                              New SqlParameter("@UserId", UserId), _
    '                              New SqlParameter("@name", name), _
    '                              New SqlParameter("@value", value))

    '    ConfigurationUser.SetConfig(name, value)
    '    Return New SaveErrorException("0")
    '  Catch ex As SaveErrorException
    '    Return New SaveErrorException(ex.Message & vbCrLf & ex.InnerException.ToString)
    '  End Try
    'End Function
    Public Shared Function GetConfig(ByVal UserId As Integer, ByVal configType As ConfigType, ByVal name As String) As Boolean
      If name.Length <> 0 Then
        If configType = BusinessLogic.ConfigType.Configuration Then
          If m_hashData Is Nothing Then
            RefreshConfigurationList(UserId)
          End If
          Dim row As DataRow = CType(m_hashData(name.ToLower), DataRow)
          If Not row Is Nothing Then
            Return CBool(row("config_value"))
          End If
        ElseIf configType = BusinessLogic.ConfigType.AddIns Then
          If HasAddIns(name) Then
            Return True
          End If
        ElseIf configType = BusinessLogic.ConfigType.Propeties Then
          'TODO 
          'ConfigurationPropeties อยู่ใน ..\Pojjaman\Data\Options\PojjamanConfigurations.xml
        End If
      Else
        Return False
      End If
    End Function
    Private Shared Function HasAddIns(ByVal name As String) As Boolean
      Dim result As Boolean = False
      For Each a As AddIn In AddInTreeSingleton.AddInTree.AddIns
        If a.FileName.ToLower.Contains(name.ToLower) Then
          result = True
        End If
      Next
      Return result
    End Function
    'Public Shared Sub SetConfig(ByVal name As String, ByVal value As Object)
    '  If m_hashData.Contains(name.ToLower) Then
    '    Dim row As DataRow = CType(m_hashData(name.ToLower), DataRow)
    '    row("config_value") = value
    '  End If
    'End Sub
    'Public Shared Function GetConfigDesc(ByVal UserId As Integer, ByVal name As String) As Object
    '  If name.Length <> 0 Then
    '    If m_hashData Is Nothing Then
    '      RefreshConfigurationList(UserId)
    '    End If
    '    Dim row As DataRow = CType(m_hashData(name.ToLower), DataRow)
    '    If Not row Is Nothing Then
    '      Return row("config_description")
    '    End If
    '  End If
    'End Function
    Public Shared Sub RefreshConfigurationList(ByVal UserId As Integer)
      m_hashData = New Hashtable
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, _
                                                   CommandType.StoredProcedure, _
                                                   "GetConfigurationUserList", _
                                                   New SqlParameter("@UserId", UserId) _
                                                   )
      Dim myTable As DataTable = ds.Tables(0)
      For Each row As DataRow In myTable.Rows
        m_hashData(row("config_name").ToString.ToLower) = row
      Next
    End Sub
    'Public Shared Function GetConfigId(ByVal UserId As Integer, ByVal name As String) As Integer
    '  If name.Length <> 0 Then
    '    If m_hashData Is Nothing Then
    '      RefreshConfigurationList(UserId)
    '    End If
    '    Dim row As DataRow = CType(m_hashData(name.ToLower), DataRow)
    '    If Not row Is Nothing Then
    '      Return CInt(row("config_id"))
    '    End If
    '  End If
    'End Function
#End Region

  End Class
End Namespace
