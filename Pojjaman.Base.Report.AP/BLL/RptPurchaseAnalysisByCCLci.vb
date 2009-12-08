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
  Public Class RptPurchaseAnalysisByCCLci
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
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 13

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 150
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 150
      m_grid.ColWidths(11) = 150
      m_grid.ColWidths(12) = 150
      m_grid.ColWidths(12) = 150

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.CCCode}") '"รหัสโครงการ"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.CCName}") '"ชื่อโครงการ"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.DocDate}")  '"วันที่"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.ItemName}")  '"รายละเอียด"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.ItemNote}")  '"หมายเหตุ"
      m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Qty}")  '"จำนวน"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.UnitName}") '"หน่วย"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.UnitPrice}")  '"ราคาต่อหน่วย"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Amt}")  '"ราคารวม"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.TaxAmt}")  '"มูลค่าภาษี"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.AfterTax}")  '"รวมเงิน"
      m_grid(1, 10).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Supplier}")  '"ชื่อผู้ขาย"
      m_grid(1, 11).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.ToCCPerson}")  '"พนักงานผู้รับผิดชอบ"
      m_grid(1, 12).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.PVCode}")  '"รหัสใบสำคัญจ่าย"
      m_grid(1, 13).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.DocRef}")  '"เอกสารอ้างอิง"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
        Return
      End If
      Dim currentCCId As String = ""
      Dim currentItemId As String = ""
      Dim tmpAmount As Decimal = 0
      Dim tmpEachAmount As Decimal = 0
      Dim SumAmount As Decimal = 0
      Dim tmpTaxAmt As Decimal = 0
      Dim tmpEachTaxAmt As Decimal = 0
      Dim SumTaxAmt As Decimal = 0
      Dim tmpAfterTax As Decimal = 0
      Dim tmpEachAfterTax As Decimal = 0
      Dim SumAfterTax As Decimal = 0
      Dim SumCC As Decimal = 0
      Dim SumItem As Decimal = 0

      Dim currCCTIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)

      For Each row As DataRow In dt.Rows
        If row("CCId").ToString <> currentCCId Then
          If SumCC > 0 Then
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.SumEachItem}") 'รวมตามรายการ
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpEachAmount, DigitConfig.Price)
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpEachTaxAmt, DigitConfig.Price)
            m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpEachAfterTax, DigitConfig.Price)
            tmpEachAmount = 0
            tmpEachTaxAmt = 0
            tmpEachAfterTax = 0

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Sum}") 'รวม
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpTaxAmt, DigitConfig.Price)
            m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpAfterTax, DigitConfig.Price)
            tmpAmount = 0
            tmpTaxAmt = 0
            tmpAfterTax = 0
          End If

          m_grid.RowCount += 1
          currCCTIndex = m_grid.RowCount
          m_grid.RowStyles(currCCTIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currCCTIndex).Font.Bold = True
          m_grid.RowStyles(currCCTIndex).ReadOnly = True
          m_grid(currCCTIndex, 1).CellValue = row("CCCode")
          m_grid(currCCTIndex, 2).CellValue = row("CCName")
          currentCCId = row("CCId").ToString
          currentItemId = ""
          SumCC += 1
          SumItem = 0


        'If Not row.IsNull("ccid") Then

        For Each rowitem As DataRow In dt.Select("ccid=" & row("ccid").ToString)
          If SumItem > 0 Then
            If currentItemId <> rowitem("ItemId").ToString & rowitem("ItemCode").ToString & rowitem("ItemName").ToString & rowitem("UnitName").ToString Then
              m_grid.RowCount += 1
              currItemIndex = m_grid.RowCount
              m_grid.RowStyles(currItemIndex).ReadOnly = True
              m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.SumEachItem}") 'รวมตามรายการ
              m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpEachAmount, DigitConfig.Price)
              m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpEachTaxAmt, DigitConfig.Price)
              m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpEachAfterTax, DigitConfig.Price)
              tmpEachAmount = 0
              tmpEachTaxAmt = 0
              tmpEachAfterTax = 0
            End If
          End If

          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          m_grid.RowStyles(currItemIndex).ReadOnly = True
          If IsDate(rowitem("DocDate")) Then
            m_grid(currItemIndex, 1).CellValue = indent & CDate(rowitem("DocDate")).ToShortDateString
          End If
          If Not rowitem.IsNull("ItemName") Then
            m_grid(currItemIndex, 2).CellValue = indent & rowitem("ItemName").ToString
          End If
          If Not rowitem.IsNull("ItemNote") Then
            m_grid(currItemIndex, 3).CellValue = indent & rowitem("ItemNote").ToString
          End If
          If IsNumeric(rowitem("Qty")) Then
            m_grid(currItemIndex, 4).CellValue = indent & Configuration.FormatToString(CDec(rowitem("Qty")), DigitConfig.Qty)
          End If
          If Not rowitem.IsNull("UnitName") Then
            m_grid(currItemIndex, 5).CellValue = indent & rowitem("UnitName").ToString
          End If
          If IsNumeric(rowitem("UnitPrice")) Then
            m_grid(currItemIndex, 6).CellValue = indent & Configuration.FormatToString(CDec(rowitem("UnitPrice")), DigitConfig.Price)
          End If
          If IsNumeric(rowitem("Amount")) Then
            m_grid(currItemIndex, 7).CellValue = indent & Configuration.FormatToString(CDec(rowitem("Amount")), DigitConfig.Price)
            tmpEachAmount += CDec(rowitem("Amount"))
            tmpAmount += CDec(rowitem("Amount"))
            SumAmount += CDec(rowitem("Amount"))
          End If
          If IsNumeric(rowitem("TaxAmt")) Then
            m_grid(currItemIndex, 8).CellValue = indent & Configuration.FormatToString(CDec(rowitem("TaxAmt")), DigitConfig.Price)
            tmpEachTaxAmt += CDec(rowitem("TaxAmt"))
            tmpTaxAmt += CDec(rowitem("TaxAmt"))
            SumTaxAmt += CDec(rowitem("TaxAmt"))
          End If
          If IsNumeric(rowitem("AfterTax")) Then
            m_grid(currItemIndex, 9).CellValue = indent & Configuration.FormatToString(CDec(rowitem("AfterTax")), DigitConfig.Price)
            tmpEachAfterTax += CDec(rowitem("AfterTax"))
            tmpAfterTax += CDec(rowitem("AfterTax"))
            SumAfterTax += CDec(rowitem("AfterTax"))
          End If
          If Not rowitem.IsNull("SupplierInfo") Then
            m_grid(currItemIndex, 10).CellValue = indent & rowitem("SupplierInfo").ToString
          End If
          If Not rowitem.IsNull("EmployeeName") Then
            m_grid(currItemIndex, 11).CellValue = indent & rowitem("EmployeeName").ToString
          End If
          If Not rowitem.IsNull("PVCode") Then
            m_grid(currItemIndex, 12).CellValue = indent & rowitem("PVCode").ToString
          End If
          If Not rowitem.IsNull("stock_code") Then
            m_grid(currItemIndex, 13).CellValue = indent & rowitem("stock_code").ToString
          End If
          currentItemId = rowitem("ItemId").ToString & rowitem("ItemCode").ToString & rowitem("ItemName").ToString & rowitem("UnitName").ToString
          SumItem += 1
        Next
        'End If
        'If currentItemId <> row("ItemId").ToString & row("ItemCode").ToString & row("ItemName").ToString & row("UnitName").ToString Then
        '    m_grid.RowCount += 1
        '    currItemIndex = m_grid.RowCount
        '    m_grid.RowStyles(currItemIndex).ReadOnly = True
        '    m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.SumEachItem}") 'รวมตามรายการ
        '    m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpEachAmount, DigitConfig.Price)
        '    m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpEachTaxAmt, DigitConfig.Price)
        '    m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpEachAfterTax, DigitConfig.Price)
        '    tmpEachAmount = 0
        '    tmpEachTaxAmt = 0
        '    tmpEachAfterTax = 0
        'End If
        'm_grid.RowCount += 1
        'currItemIndex = m_grid.RowCount
        'm_grid.RowStyles(currItemIndex).ReadOnly = True
        'If IsDate(row("DocDate")) Then
        '    m_grid(currItemIndex, 1).CellValue = indent & CDate(row("DocDate")).ToShortDateString
        'End If
        'If Not row.IsNull("ItemName") Then
        '    m_grid(currItemIndex, 2).CellValue = indent & row("ItemName").ToString
        'End If
        'If Not row.IsNull("ItemNote") Then
        '    m_grid(currItemIndex, 3).CellValue = indent & row("ItemNote").ToString
        'End If
        'If IsNumeric(row("Qty")) Then
        '    m_grid(currItemIndex, 4).CellValue = indent & Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
        'End If
        'If Not row.IsNull("UnitName") Then
        '    m_grid(currItemIndex, 5).CellValue = indent & row("UnitName").ToString
        'End If
        'If IsNumeric(row("UnitPrice")) Then
        '    m_grid(currItemIndex, 6).CellValue = indent & Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
        'End If
        'If IsNumeric(row("Amount")) Then
        '    m_grid(currItemIndex, 7).CellValue = indent & Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
        '    tmpEachAmount += CDec(row("Amount"))
        '    tmpAmount += CDec(row("Amount"))
        '    SumAmount += CDec(row("Amount"))
        'End If
        'If IsNumeric(row("TaxAmt")) Then
        '    m_grid(currItemIndex, 8).CellValue = indent & Configuration.FormatToString(CDec(row("TaxAmt")), DigitConfig.Price)
        '    tmpEachTaxAmt += CDec(row("TaxAmt"))
        '    tmpTaxAmt += CDec(row("TaxAmt"))
        '    SumTaxAmt += CDec(row("TaxAmt"))
        'End If
        'If IsNumeric(row("AfterTax")) Then
        '    m_grid(currItemIndex, 9).CellValue = indent & Configuration.FormatToString(CDec(row("AfterTax")), DigitConfig.Price)
        '    tmpEachAfterTax += CDec(row("AfterTax"))
        '    tmpAfterTax += CDec(row("AfterTax"))
        '    SumAfterTax += CDec(row("AfterTax"))
        'End If
        'If Not row.IsNull("SupplierInfo") Then
        '    m_grid(currItemIndex, 10).CellValue = indent & row("SupplierInfo").ToString
        'End If
        'If Not row.IsNull("EmployeeName") Then
        '    m_grid(currItemIndex, 11).CellValue = indent & row("EmployeeName").ToString
        'End If
        'If Not row.IsNull("PVCode") Then
        '    m_grid(currItemIndex, 12).CellValue = indent & row("PVCode").ToString
        'End If
        'If Not row.IsNull("stock_code") Then
        '    m_grid(currItemIndex, 13).CellValue = indent & row("stock_code").ToString
        'End If
        'currentItemId = row("ItemId").ToString & row("ItemCode").ToString & row("ItemName").ToString & row("UnitName").ToString
				End If
			Next

      'm_grid.RowCount += 1
      'currItemIndex = m_grid.RowCount
      'm_grid.RowStyles(currItemIndex).ReadOnly = True
      'm_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.SumEachItem}") 'รวมตามรายการ
      'm_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpEachAmount, DigitConfig.Price)
      'm_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpEachTaxAmt, DigitConfig.Price)
      'm_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpEachAfterTax, DigitConfig.Price)

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.Sum}") 'รวม
      m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpTaxAmt, DigitConfig.Price)
      m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpAfterTax, DigitConfig.Price)

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.SumAll}") 'รวมทั้งหมด
      m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price)
      m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(SumAfterTax, DigitConfig.Price)

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptPurchaseAnalysisByCCLci"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptPurchaseAnalysisByCCLci"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptPurchaseAnalysisByCCLci"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysisByCCLci.ListLabel}"
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
      Return "RptPurchaseAnalysisByCCLci"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptPurchaseAnalysisByCCLci"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 2 To m_grid.RowCount
        'If i > 1 Then
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

        dpi = New DocPrintingItem
        dpi.Mapping = "col8"
        dpi.Value = m_grid(rowIndex, 9).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col9"
        dpi.Value = m_grid(rowIndex, 10).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col10"
        dpi.Value = m_grid(rowIndex, 11).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col11"
        dpi.Value = m_grid(rowIndex, 12).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)


        dpi = New DocPrintingItem
        dpi.Mapping = "col12"
        dpi.Value = m_grid(rowIndex, 13).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

