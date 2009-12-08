Option Explicit On 
Option Strict On
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptAPEnumerate
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
      MyBase.New(filters, fixValueCollection)
    End Sub
#End Region

#Region "Methods"
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid
      m_grid.BeginUpdate()
      m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      m_grid.Model.Options.NumberedColHeaders = False
      m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
      m_grid.HorizontalThumbTrack = True
      m_grid.VerticalThumbTrack = True
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 30

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 120
      m_grid.ColWidths(4) = 140
      m_grid.ColWidths(5) = 140
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 100
      m_grid.ColWidths(12) = 100
      m_grid.ColWidths(13) = 100
      m_grid.ColWidths(14) = 100
      m_grid.ColWidths(15) = 100
      m_grid.ColWidths(16) = 100
      m_grid.ColWidths(17) = 100
      m_grid.ColWidths(18) = 100
      m_grid.ColWidths(19) = 100
      m_grid.ColWidths(20) = 100
      m_grid.ColWidths(21) = 100
      m_grid.ColWidths(22) = 100
      m_grid.ColWidths(23) = 100
      m_grid.ColWidths(24) = 100
      m_grid.ColWidths(25) = 100
      m_grid.ColWidths(26) = 100
      m_grid.ColWidths(27) = 100
      m_grid.ColWidths(28) = 100
      m_grid.ColWidths(29) = 100
      m_grid.ColWidths(30) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.ColStyles(14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(19).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(20).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(21).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(22).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(23).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(24).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(25).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(26).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(27).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(28).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(29).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(30).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.ApID}")              '"รหัสเจ้าหนี้"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.ApName}")            '"ชื่อเจ้าหนี้"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.CreditAmount}")      '"วงเงินเครดิต"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.RemainingCreditAmount}")  '"วงเงินเครดิตคงเหลือ"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.ApStatus}")          '"สถานะเจ้าหนี้"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.DocDate}") '"วันที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.DocCode}") '"เลขที่เอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.InVoid}")  '"เลขที่ใบกำกับ"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.DocType}") '"ประเภทเอกสาร"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.PpCode}")  '"เลขที่ใบสำคัญจ่าย"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Purchase}")   '"ซื้อ"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.SaleCN}")    '"ลดหนี้"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Paid}")   '"จ่ายชำระหนี้"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Status}")   '"คงเหลือ"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Term}")     '"เทอม"

      m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Retention}")    '"หัก Retention"
      m_grid(1, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.PaysRetention}")    '"คืน Retention"
      m_grid(1, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.RetentionBalance}")    '"Retention คงเหลือ"

      m_grid(1, 14).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Cash}")     '"ยอดที่เป็นเงินสด"
      m_grid(1, 15).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Check}")     '"ยอดที่เป็นเช็ค"
      m_grid(1, 16).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.AdvancePay}")     '"ยอดที่จ่ายโดยมัดจำ"
      m_grid(1, 17).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Interest}")     '"ดอกเบี้ยจ่าย"
      m_grid(1, 18).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.AmtIncrease}")     '"ยอดเพิ่มจำนวนจ่าย"
      m_grid(1, 19).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Discount}")     '"ส่วนลด"
      m_grid(1, 20).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.WHT}")     '"ภาษี ณ ที่จ่าย"
      m_grid(1, 21).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.AmtDeduct}")     '"ยอดหักจำนวนจ่าย"
      m_grid(1, 22).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Note}")     '"หมายเหตุ"
      m_grid(1, 23).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.CheckCode}")     '"เลขที่เช็ค"
      m_grid(1, 24).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.CheckDueDate}")     '"วันที่บนเช็ค"
      m_grid(1, 25).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.CheckBankAcct}")     '"บัญชีธนาคาร"
      m_grid(1, 26).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.CheckStatus}")     '"สถานะเช็ค"
      m_grid(1, 27).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.RefDocCode}")     '"เอกสารต้นทาง"
      m_grid(1, 28).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.RefDocDate}")     '"วันที่เอกสารต้นทาง"
      m_grid(1, 29).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.RefDocBill}")     '"เลขที่บิล"
      m_grid(1, 30).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.RefDocPayAmt}")     '"ยอดเงินที่นำมาวางบิล"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 19).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 20).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 21).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 22).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 23).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 24).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 25).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 26).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 27).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 28).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 29).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 30).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt2 As DataTable = Me.DataSet.Tables(1)
      Dim currentSupplierCode As String = ""
      Dim currentDocCode As String = ""
      Dim currentCheckCode As String = ""

      Dim indent As String = Space(3)

      Dim tmpRemain As Decimal = 0
      Dim tmpPurchase As Decimal = 0
      Dim tmpPaid As Decimal = 0
      Dim tmpSaleCN As Decimal = 0
      Dim tmpOpnBalance As Decimal = 0
      Dim tmpRetention As Decimal = 0
      Dim tmpPaysRetention As Decimal = 0

      Dim SumSupplier As Int32 = 0
      Dim SumOpnBalance As Decimal = 0
      Dim SumOpnRetentionBalance As Decimal = 0
      Dim SumPurchase As Decimal = 0
      Dim SumPaid As Decimal = 0
      Dim sumSaleCN As Decimal = 0
      Dim sumRetention As Decimal = 0
			Dim sumPaysRetention As Decimal = 0
			Dim SumWHT As Decimal = 0
      Dim LastSupplierCrAmtRecord As Decimal = 0

      Dim currSupplierIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim currCheckTrIndex As Integer = -1
      Dim currRefDocIndex As Integer = -1

      For Each row As DataRow In dt.Rows
        Dim supRows As DataRow() = Me.DataSet.Tables(1).Select("SupplierCode ='" & row("SupplierCode").ToString & "'")
        If suprows.Length = 0 Then
          Dim dr As DataRow = Me.DataSet.Tables(1).NewRow()
          dr(0) = row(0)
          dr(1) = row(1)
          dr(2) = row(2)
          dr(3) = row(3)
          dr(4) = ""
          dr(5) = Now
          dr(6) = 0
          dr(7) = ""
          dr(8) = ""
          dr(9) = ""
          dr(10) = 0
          dr(11) = 0
          dr(12) = 0
          dr(13) = 0
          dr(14) = 0
          dr(15) = 0
          dt2.Rows.Add(dr)
        End If
      Next

      For Each row As DataRow In dt2.Rows
        If row("SupplierCode").ToString <> currentSupplierCode Then
          SumSupplier += 1
          If SumSupplier > 1 Then
            'วงเงินเครดิตคงเหลือ
            m_grid(currSupplierIndex, 4).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")) - tmpRemain, DigitConfig.Price)
            m_grid(currSupplierIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 3).CellValue = "รวมเงิน"
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(tmpPurchase, DigitConfig.Price)
            m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(tmpSaleCN, DigitConfig.Price)
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(tmpPaid, DigitConfig.Price)
            m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(tmpRetention, DigitConfig.Price)
            m_grid(currDocIndex, 12).CellValue = Configuration.FormatToString(tmpPaysRetention, DigitConfig.Price)

            tmpPurchase = 0
            tmpPaid = 0
            tmpSaleCN = 0
            tmpRemain = 0
            tmpRetention = 0
            tmpPaysRetention = 0
          End If
          m_grid.RowCount += 1
          currSupplierIndex = m_grid.RowCount
          m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currSupplierIndex).Font.Bold = True
          m_grid.RowStyles(currSupplierIndex).ReadOnly = True

          m_grid(currSupplierIndex, 1).CellValue = row("SupplierCode")
          m_grid(currSupplierIndex, 2).CellValue = row("SupplierName")
          m_grid(currSupplierIndex, 3).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")), DigitConfig.Price)
          m_grid(currSupplierIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
          m_grid(currSupplierIndex, 5).CellValue = row("Status")
          currentSupplierCode = row("SupplierCode").ToString
          LastSupplierCrAmtRecord = CDec(row("CreditAmount"))
          Dim supRows As DataRow() = Me.DataSet.Tables(0).Select("SupplierCode ='" & currentSupplierCode & "'")
          If supRows.Length = 1 Then
            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.OpenningBalance}")  '"ยอดยกมา"
            m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(CDec(supRows(0)("OpenningBalance")), DigitConfig.Price)
            m_grid(currDocIndex, 13).CellValue = Configuration.FormatToString(CDec(suprows(0)("RetentionOpenningBalance")), DigitConfig.Price)
            SumOpnBalance += CDec(supRows(0)("OpenningBalance"))
            tmpRemain = CDec(supRows(0)("OpenningBalance"))
            SumOpnRetentionBalance += CDec(suprows(0)("RetentionOpenningBalance"))
            'tmpRetentionRemain = CDec(suprows(0)("RetentionOpenningBalance"))
          End If
          currentDocCode = ""
        End If

        If row("DocCode").ToString <> currentDocCode Then
          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          m_grid.RowStyles(currDocIndex).ReadOnly = True

          If IsDate(row("DocDate")) Then
            m_grid(currDocIndex, 1).CellValue = indent & CDate(row("DocDate")).ToShortDateString
          End If
          If Not row.IsNull("DocCode") Then
            m_grid(currDocIndex, 2).CellValue = indent & row("DocCode").ToString
          End If
          If Not row.IsNull("RefCode") Then
            m_grid(currDocIndex, 3).CellValue = indent & row("RefCode").ToString
          End If
          If Not row.IsNull("Type") Then
            m_grid(currDocIndex, 4).CellValue = indent & row("Type").ToString
          End If
          If Not row.IsNull("PVCode") Then
            m_grid(currDocIndex, 5).CellValue = indent & row("PVCode").ToString
          End If
          If IsNumeric(row("Purchase")) Then
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Purchase")), DigitConfig.Price)
            tmpRemain += CDec(row("Purchase"))
            tmpPurchase += CDec(row("Purchase"))
            SumPurchase += CDec(row("Purchase"))
          End If
          If IsNumeric(row("SaleCN")) Then
            m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("SaleCN")), DigitConfig.Price)
            tmpRemain -= CDec(row("SaleCN"))
            tmpSaleCN += CDec(row("SaleCN"))
            sumSaleCN += CDec(row("SaleCN"))
          End If
          If IsNumeric(row("Paid")) Then
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(row("Paid")), DigitConfig.Price)
            tmpRemain -= CDec(row("Paid"))
            tmpPaid += CDec(row("Paid"))
            SumPaid += CDec(row("Paid"))
          End If
          m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
          If Not row.IsNull("Period") Then
            m_grid(currDocIndex, 10).CellValue = indent & row("Period").ToString
          End If
          If IsNumeric(row("Retention")) Then
            m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(CDec(row("Retention")), DigitConfig.Price)
            sumRetention += CDec(row("Retention"))
            tmpRetention += CDec(row("Retention"))
            SumOpnRetentionBalance += CDec(row("Retention"))
          End If
          If IsNumeric(row("PaysRetention")) Then
            m_grid(currDocIndex, 12).CellValue = Configuration.FormatToString(CDec(row("PaysRetention")), DigitConfig.Price)
            sumPaysRetention += CDec(row("PaysRetention"))
            tmpPaysRetention += CDec(row("PaysRetention"))
            SumOpnRetentionBalance -= CDec(row("PaysRetention"))
          End If
          m_grid(currDocIndex, 13).CellValue = Configuration.FormatToString(SumOpnRetentionBalance, DigitConfig.Price)

          If Not row.IsNull("Cash") Then
            m_grid(currDocIndex, 14).CellValue = indent & Configuration.FormatToString(CDec(row("Cash")), DigitConfig.Price)
          End If
          If Not row.IsNull("Check") Then
            m_grid(currDocIndex, 15).CellValue = indent & Configuration.FormatToString(CDec(row("Check")), DigitConfig.Price)
          End If
          If Not row.IsNull("AdvancePay") Then
            m_grid(currDocIndex, 16).CellValue = indent & Configuration.FormatToString(CDec(row("AdvancePay")), DigitConfig.Price)
          End If
          If Not row.IsNull("Interest") Then
            m_grid(currDocIndex, 17).CellValue = indent & Configuration.FormatToString(CDec(row("Interest")), DigitConfig.Price)
          End If
          If Not row.IsNull("AmtIncrease") Then
            m_grid(currDocIndex, 18).CellValue = indent & Configuration.FormatToString(CDec(row("AmtIncrease")), DigitConfig.Price)
          End If
          If Not row.IsNull("Discount") Then
            m_grid(currDocIndex, 19).CellValue = indent & Configuration.FormatToString(CDec(row("Discount")), DigitConfig.Price)
          End If
          If Not row.IsNull("WHT") Then
            m_grid(currDocIndex, 20).CellValue = indent & Configuration.FormatToString(CDec(row("WHT")), DigitConfig.Price)
            'tmpRemain += CDec(row("WHT"))
						SumWHT += CDec(row("WHT"))
            'm_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
					End If
					If Not row.IsNull("AmtDeduct") Then
						m_grid(currDocIndex, 21).CellValue = indent & Configuration.FormatToString(CDec(row("AmtDeduct")), DigitConfig.Price)
					End If
					If Not row.IsNull("Note") Then
						m_grid(currDocIndex, 22).CellValue = indent & row("Note").ToString
					End If
					currentDocCode = row("DocCode").ToString
				End If

				If row("CheckCode").ToString <> currentCheckCode AndAlso Not row.IsNull("CheckCode") Then
					m_grid.RowCount += 1
					currCheckTrIndex = m_grid.RowCount
					m_grid.RowStyles(currCheckTrIndex).ReadOnly = True

					If Not row.IsNull("CheckCode") Then
						m_grid(currCheckTrIndex, 23).CellValue = indent & row("CheckCode").ToString
					End If
					If Not row.IsNull("CheckDueDate") Then
						m_grid(currCheckTrIndex, 24).CellValue = indent & CDate(row("CheckDueDate")).ToShortDateString
					End If
					If Not row.IsNull("CheckBankAcct") Then
						m_grid(currCheckTrIndex, 25).CellValue = indent & row("CheckBankAcct").ToString
					End If
					If Not row.IsNull("CheckStatus") Then
						m_grid(currCheckTrIndex, 26).CellValue = indent & row("CheckStatus").ToString
					End If

					currentCheckCode = row("CheckCode").ToString
				End If

				If Not row.IsNull("RefDocCode") Then
					m_grid.RowCount += 1
					currRefDocIndex = m_grid.RowCount
					m_grid.RowStyles(currRefDocIndex).ReadOnly = True

					If Not row.IsNull("RefDocCode") Then
						m_grid(currRefDocIndex, 27).CellValue = indent & row("RefDocCode").ToString
					End If
					If Not row.IsNull("RefDocDate") Then
						m_grid(currRefDocIndex, 28).CellValue = indent & CDate(row("RefDocDate")).ToShortDateString
					End If
					If Not row.IsNull("RefDocBill") Then
						m_grid(currRefDocIndex, 29).CellValue = indent & row("RefDocBill").ToString
					End If
					If Not row.IsNull("RefDocPayAmt") Then
						m_grid(currRefDocIndex, 30).CellValue = indent & Configuration.FormatToString(CDec(row("RefDocPayAmt")), DigitConfig.Price)
					End If
				End If
			Next

      'วงเงินเครดิตคงเหลือ
      m_grid(currSupplierIndex, 4).CellValue = Configuration.FormatToString(LastSupplierCrAmtRecord - tmpRemain, DigitConfig.Price)
      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid.RowStyles(currDocIndex).ReadOnly = True

      m_grid(currDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Total}")      '"รวมเงิน"
      m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(tmpPurchase, DigitConfig.Price)
      m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(tmpSaleCN, DigitConfig.Price)
      m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(tmpPaid, DigitConfig.Price)

      m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(tmpRetention, DigitConfig.Price)
      m_grid(currDocIndex, 12).CellValue = Configuration.FormatToString(tmpPaysRetention, DigitConfig.Price)

      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currDocIndex).Font.Bold = True
      m_grid.RowStyles(currDocIndex).ReadOnly = True
      m_grid(currDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.SumAp}")   '"รวมเจ้าหนี้(ราย)"
      m_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.OpenningBalance}")  '"ยอดยกมา"
      m_grid(currDocIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Purchase}")  '"ซื้อ"
      m_grid(currDocIndex, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.SaleCN}")    '"ลดหนี้"
      m_grid(currDocIndex, 8).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Paid}")  '"จ่ายชำระหนี้"
      m_grid(currDocIndex, 9).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Status}")  '"คงเหลือ"

      m_grid(currDocIndex, 11).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.Retention}")    '"Retention"
      m_grid(currDocIndex, 12).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.PaysRetention}")    '"คืน Retention"
      m_grid(currDocIndex, 13).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.RetentionBalance}")    '"Retention คงเหลือ"

      m_grid(currDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(currDocIndex, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currDocIndex).Font.Bold = True
      m_grid.RowStyles(currDocIndex).ReadOnly = True
      m_grid(currDocIndex, 3).CellValue = SumSupplier
      m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(SumOpnBalance, DigitConfig.Price)
      m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(SumPurchase, DigitConfig.Price)
      m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumSaleCN, DigitConfig.Price)
      m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(SumPaid, DigitConfig.Price)
			m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(SumOpnBalance + (SumPurchase - SumPaid - sumSaleCN - SumWHT), DigitConfig.Price)

      m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(sumRetention, DigitConfig.Price)
      m_grid(currDocIndex, 12).CellValue = Configuration.FormatToString(sumPaysRetention, DigitConfig.Price)
      m_grid(currDocIndex, 13).CellValue = Configuration.FormatToString(SumOpnRetentionBalance, DigitConfig.Price)

      m_grid(currDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(currDocIndex, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currDocIndex, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAPEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPEnumerate.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "RptAPEnumerate"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAPEnumerate"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0

      For rowIndex As Integer = 2 To m_grid.RowCount
        For j As Integer = 0 To m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & j.ToString
          dpi.Value = m_grid(rowIndex, j + 1).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Next
        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

