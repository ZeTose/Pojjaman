Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Syncfusion.Windows.Forms.Grid

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptCCPOSummary
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private MasterTotal As Decimal = 0
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
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 2
      m_grid.ColCount = 8

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 200
      m_grid.ColWidths(4) = 120
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 120
      m_grid.ColWidths(7) = 120
      m_grid.ColWidths(8) = 120
      'm_grid.ColWidths(9) = 120

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 2

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.CCID}")  '"รหัส Cost Center"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.CCName}")  '"ชื่อ Cost Center"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.FDate}")  '"วันที่เริ่มต้นโครงการ"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.EDate}")  '"วันที่สิ้นสุดโครงการ"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.NumDay}")  '"จำนวนวัน"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.PoID}")   '"เลขที่ PO"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.PoDate}")   '"วันที่สั่งซื้อ"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.Company}")  '"บริษัท"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.DueDate}")   '"กำหนดส่งของ"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.DiscAmount}")  '"ส่วนลดท้ายบิล"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.AfterTax}")  '"จำนวนเงินรวมภาษี"

      m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.PrID}")   '"เลขที่ PR"
      m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.Description}")  '"รายละเอียด"
      m_grid(2, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.Num}")   '"จำนวน"
      m_grid(2, 4).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.Unit}")   '"หน่วย"
      m_grid(2, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.UnitPrice}")   '"ราคาต่อหน่วย"
      m_grid(2, 7).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.Discount}")   '"จำนวนส่วนลด"
      m_grid(2, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.Amount}")   '"จำนวนเงิน"
      'm_grid(2, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.Remark}")   '"หมายเหตุ"


      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(2, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)

      Dim currentCCId As String = ""
      Dim currentDocId As String = ""
      Dim currentItem As String = ""
      Dim currCCName As String = ""

      Dim currCCIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim currItemIndex As Integer = -1

      Dim indent As String = Space(3)
      Dim SumAmount As Decimal = 0
      Dim tmpAmount As Decimal = 0
      Dim tmpTaxAmount As Decimal = 0
      Dim tmpTaxType As Integer = 0
      Dim tmpTaxBase As Decimal = 0
      Dim tmpDocDiscountAmount As Decimal = 0
      Dim SumBeforeTax As Decimal = 0
      Dim SumVatAmount As Decimal = 0
      Dim SumAfterTax As Decimal = 0
      Dim SumTaxBase As Decimal = 0
      Dim SumNoTax As Decimal = 0
      Dim GridRangeStyle1 As GridRangeStyle  '= New GridRangeStyle

      For Each row As DataRow In dt.Rows
        If row("CCId").ToString <> currentCCId Then
          If tmpDocDiscountAmount > 0 And currentCCId <> "" Then
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            GridRangeStyle1 = New GridRangeStyle
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
            GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
            GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.PODiscAmt}")     '"Retention"
            GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
            m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(tmpDocDiscountAmount), DigitConfig.Price)
          End If
          If (tmpTaxType = 1 Or tmpTaxType = 2) And IsNumeric(tmpTaxAmount) And currentDocId <> "" And currentCCId <> "" Then

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            GridRangeStyle1 = New GridRangeStyle
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
            GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
            GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxBase}")      '"Retention"
            GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
            m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
            'm_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxBase}")					'"ฐานภาษี"
            'm_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(tmpTaxBase), DigitConfig.Price)

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            GridRangeStyle1 = New GridRangeStyle
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
            GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
            GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxAmount}")      '"Retention"
            GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
            m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
            'm_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxAmount}")			 '"ค่าภาษีมูลค่าเพิ่ม"
            'm_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(tmpTaxAmount), DigitConfig.Price)
          End If
          If currentCCId <> "" Then
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            GridRangeStyle1 = New GridRangeStyle
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
            GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
            GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.CostAllProj}")      '"Retention"
            GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
            m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
            'm_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.CostAllProj}") & " " & currCCName					'"จำนวนเงินรวม"
            'm_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
            tmpAmount = 0
          End If
          m_grid.RowCount += 1
          currCCIndex = m_grid.RowCount
          m_grid.RowStyles(currCCIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currCCIndex).Font.Bold = True
          m_grid.RowStyles(currCCIndex).ReadOnly = True
          m_grid(currCCIndex, 1).CellValue = row("CCCode")
          m_grid(currCCIndex, 2).CellValue = row("CCName")
          currentCCId = row("CCId").ToString
          currCCName = row("CCName")
          currentDocId = ""
        End If
        '----------------------------------------------------------------
        If row("DocId").ToString <> currentDocId Then
          If tmpDocDiscountAmount > 0 And currentDocId <> "" Then
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            GridRangeStyle1 = New GridRangeStyle
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
            GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
            GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.PODiscAmt}")       '"Retention"
            GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
            m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(tmpDocDiscountAmount), DigitConfig.Price)
          End If
          If (tmpTaxType = 1 Or tmpTaxType = 2) And IsNumeric(tmpTaxAmount) And currentDocId <> "" Then
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            GridRangeStyle1 = New GridRangeStyle
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
            GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
            GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxBase}")       '"Retention"
            GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
            m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(tmpTaxBase), DigitConfig.Price)

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            GridRangeStyle1 = New GridRangeStyle
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
            GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
            GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxAmount}")       '"Retention"
            GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
            m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
            'm_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxAmount}")					'"ค่าภาษีมูลค่าเพิ่ม"
            'm_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(tmpTaxAmount), DigitConfig.Price)
          End If
          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          m_grid.RowStyles(currDocIndex).BackColor = Color.AntiqueWhite
          m_grid.RowStyles(currDocIndex).Font.Bold = True
          m_grid.RowStyles(currDocIndex).ReadOnly = True
          If Not row.IsNull("DocCode") Then
            m_grid(currDocIndex, 1).CellValue = indent & row("DocCode").ToString
          End If
          If IsDate(row("DocDate")) Then
            m_grid(currDocIndex, 2).CellValue = indent & CDate(row("DocDate")).ToShortDateString
          End If
          If Not row.IsNull("SupplierName") Then
            m_grid(currDocIndex, 3).CellValue = indent & row("SupplierName").ToString
          End If
          If IsDate(row("DueDate")) Then
            m_grid(currDocIndex, 4).CellValue = indent & CDate(row("DueDate")).ToShortDateString
          End If
          If IsNumeric(row("DiscAmount")) And CDec(row("DiscAmount")) > 0 Then
            m_grid(currDocIndex, 6).CellValue = indent & indent & Configuration.FormatToString(CDec(row("DiscAmount")), DigitConfig.Price)
          End If
          If IsNumeric(row("AfterTax")) Then
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(row("AfterTax")), DigitConfig.Price)
            tmpAmount += CDec(row("AfterTax"))
            SumAfterTax += CDec(row("AfterTax"))
          End If
          If IsNumeric(row("DocDiscountAmount")) Then
            tmpDocDiscountAmount = CDec(row("DocDiscountAmount"))
            SumBeforeTax -= CDec(row("DocDiscountAmount"))
          Else
            tmpDocDiscountAmount = 0
          End If
          If (row("TaxType") = 1 Or row("TaxType") = 2) And IsNumeric(row("TaxAmount")) Then
            tmpTaxType = row("TaxType")
            tmpTaxAmount = CDec(row("TaxAmount"))
            tmpTaxBase = CDec(row("TaxBase"))
                        SumVatAmount += CDec(row("TaxAmount"))
            SumTaxBase += CDec(row("TaxBase"))
          Else
            tmpTaxType = 0
            tmpTaxAmount = 0
            'SumNoTax += CDec(row("AfterTax"))
          End If

          If Not row.IsNull("po_beforetax") Then
            SumNoTax += CDec(row("po_beforetax"))
          End If

          currentDocId = row("DocId").ToString
          currentItem = ""
        End If
        '---------------------------------------------------------------
        If row("ItemId").ToString & row("ItemName").ToString <> currentItem Then
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          m_grid.RowStyles(currItemIndex).ReadOnly = True
          If Not row.IsNull("RefCode") Then
            m_grid(currItemIndex, 1).CellValue = indent & indent & row("RefCode").ToString
          End If
          If Not row.IsNull("ItemName") Then
            m_grid(currItemIndex, 2).CellValue = indent & indent & row("ItemName").ToString
          End If
          If IsNumeric(row("Qty")) Then
            m_grid(currItemIndex, 3).CellValue = indent & indent & Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
            m_grid(currItemIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
          End If
          If Not row.IsNull("Unit") Then
            m_grid(currItemIndex, 4).CellValue = indent & indent & row("Unit").ToString
          End If
          If IsNumeric(row("UnitPrice")) Then
            m_grid(currItemIndex, 5).CellValue = indent & indent & Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
          End If

          If IsNumeric(row("DiscountAmount")) Then
            m_grid(currItemIndex, 7).CellValue = indent & indent & Configuration.FormatToString(CDec(row("DiscountAmount")), DigitConfig.Price)
            'If CDec(row("DiscountAmount")) > 0 Then
            '    m_grid(currItemIndex, 7).CellValue = "-"
            'End If
          End If
          If IsNumeric(row("Amount")) Then
            m_grid(currItemIndex, 8).CellValue = indent & indent & Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
            SumBeforeTax += CDec(row("Amount"))
          End If
          currentItem = row("ItemId").ToString & row("ItemName").ToString & row("ItemLine").ToString
          'If Not row.IsNull("Remark") Then
          '    m_grid(currItemIndex, 9).CellValue = indent & indent & row("Remark").ToString
          'End If
        End If
      Next
      '---------------------------------------------------------------
      If tmpDocDiscountAmount > 0 And currentDocId <> "" Then
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True
        GridRangeStyle1 = New GridRangeStyle
        m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
        GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
        GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.PODiscAmt}")     '"Retention"
        GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
        m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
        m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(tmpDocDiscountAmount), DigitConfig.Price)
      End If
      If (tmpTaxType = 1 Or tmpTaxType = 2) And IsNumeric(tmpTaxAmount) Then

        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True
        GridRangeStyle1 = New GridRangeStyle
        m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
        GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
        GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxBase}")     '"Retention"
        GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
        m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
        'm_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxBase}")			 '"ฐานภาษี"
        'm_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
        m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(tmpTaxBase), DigitConfig.Price)

        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True
        GridRangeStyle1 = New GridRangeStyle
        m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
        GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
                GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxAmount}")     '"ค่าภาษีมูลค่าเพิ่ม"
        GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
        m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
        'm_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.TaxAmount}")			 '"ค่าภาษีมูลค่าเพิ่ม"
        'm_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
        m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(tmpTaxAmount), DigitConfig.Price)
      End If

      '------------------------------------------------------------------

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      GridRangeStyle1 = New GridRangeStyle
      m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
      GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
      GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.CostAllProj}")    '"Retention"
      GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
      m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
      '-----------------------------------------------------------------------------
      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(167, 214, 231)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      GridRangeStyle1 = New GridRangeStyle
      m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
      GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
      GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.SumBeforeTax}")    'ยอดรวมมูลค่าสินค้า/บริการ 
      GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
      m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(SumTaxBase, DigitConfig.Price)

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(167, 214, 231)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      GridRangeStyle1 = New GridRangeStyle
      m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
      GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
            GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.SumVatAmount}")    '"ยอดรวมภาษี"
      GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
      m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(SumVatAmount, DigitConfig.Price)

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(167, 214, 231)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      GridRangeStyle1 = New GridRangeStyle
      m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
      GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
      GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.SumNoTax}")    '"Retention"
      GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
      m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(SumNoTax, DigitConfig.Price)

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(167, 214, 231)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      GridRangeStyle1 = New GridRangeStyle
      m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(currItemIndex, 4, currItemIndex, 6)})
      GridRangeStyle1.Range = GridRangeInfo.Cell(currItemIndex, 4)
      GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.SumAllCC}")    '"Retention"
      GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Left
      m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(SumAfterTax, DigitConfig.Price)

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptCCPOSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptCCPOSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptCCPOSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCCPOSummary.ListLabel}"
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
      Return "RptCCPOSummary"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptCCPOSummary"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim SumAmt As Decimal = 0
      For rowIndex As Integer = 3 To m_grid.RowCount
        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid(rowIndex, 1).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = m_grid(rowIndex, 2).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = m_grid(rowIndex, 3).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = m_grid(rowIndex, 4).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        dpi.Value = m_grid(rowIndex, 5).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col5"
        dpi.Value = m_grid(rowIndex, 6).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col6"
        dpi.Value = m_grid(rowIndex, 7).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col7"
        dpi.Value = m_grid(rowIndex, 8).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col8"
        'dpi.Value = m_grid(rowIndex, 9).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)
        n += 1
        If IsNumeric(m_grid(rowIndex, 7).CellValue) Then
          SumAmt += CDec(m_grid(rowIndex, 7).CellValue)
        End If
      Next

      'SumText
      dpi = New DocPrintingItem
      dpi.Mapping = "SumText"
      dpi.Value = "รวม"
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCol6
      dpi = New DocPrintingItem
      dpi.Mapping = "sumCol6"
      dpi.Value = Configuration.FormatToString(SumAmt, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

