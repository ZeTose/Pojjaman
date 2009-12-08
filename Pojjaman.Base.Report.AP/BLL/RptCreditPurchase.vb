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
  Public Class RptCreditPurchase
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

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New Treemanager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      If CInt(Me.Filters(14).Value) = 0 Then
        lkg.Rows.HeaderCount = 2
        lkg.Rows.FrozenCount = 2
      Else
        lkg.Rows.HeaderCount = 3
        lkg.Rows.FrozenCount = 3
      End If
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Treemanager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String = Space(3)
      Dim tr As TreeRow

      If CInt(Me.Filters(14).Value) = 0 Then
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.ItemCode}") '"รหัสสินค้า"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.ItemName}") '"ชื่อสินค้า"

        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.DocDate}")  '"วันที่เอกสาร"
        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.DocID}")  '"เลขที่เอกสาร"
        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.RefCode}")  '"เลขที่ใบกำกับ"
        tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.POCode}") '"เลขที่ใบรับของ"
        tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.PO}")  '"เลขที่ใบรับของ"
        tr("col5") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.SupplierName}")  '"ชื่อผู้ขาย"
        tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Num}")  '"จำนวน"
        tr("col7") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Unit}")  '"หน่วยนับ"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.UnitPrice}")  '"ราคา/หน่วย"
        tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.DiscAmount}")  '"ส่วนลดสินค้า(เป็นเงิน)"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Amount}")  '"จำนวนเงิน"
      Else
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.SupplierCode}")  '"ชื่อรหัส"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.SupplierName}")  '"ชื่อผู้ขาย"

        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.POCode}") '"เลขที่ใบรับของ"
        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.DocDate}")  '"วันที่เอกสาร"
        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.DocID}")  '"เลขที่เอกสาร"
        tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.RefCode}")  '"เลขที่ใบกำกับ"
        tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.PO}")  '"เลขที่PO"
        'tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Amount}")  '"จำนวนเงิน"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.BeforeTaxAmount}") '"ก่อน Vat"
        tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.TaxAmount}") '"Vat"
        tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.AfterTaxAmount}") '"หลัง Vat"

        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.ItemCode}")    '"รหัสสินค้า"
        tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.ItemName}")   '"ชื่อสินค้า"
        tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Num}")  '"จำนวน"
        tr("col6") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Unit}")   '"หน่วยนับ"
        tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.UnitPrice}")  '"ราคา/หน่วย"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.DiscAmount}")  '"ส่วนลดสินค้า(เป็นเงิน)"
        tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Amount}")  '"จำนวนเงิน"
      End If

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0) 'Me.DataSet.Tables(m_ShowPeriod + 1)

      If dt.Rows.Count = 0 Then
        Return
      End If

      Dim indent As String = Space(3)
      Dim currentItemCode As String = ""
      Dim currentSupplierCode As String = ""
      Dim currentStockCode As String = ""

      Dim trSupplier As TreeRow
      Dim trItem As TreeRow
      Dim trStock As TreeRow

      Dim itemQty As Decimal = 0
      Dim itemDiscAmt As Decimal = 0
      Dim itemAmt As Decimal = 0
      Dim totalItemQty As Decimal = 0
      Dim totalItemDiscAmt As Decimal = 0
      Dim totalItemAmt As Decimal = 0

      Dim totalQty As Decimal = 0
      Dim totalDiscAmt As Decimal = 0
      Dim totalAmt As Decimal = 0
      Dim totalStockQty As Decimal = 0
      Dim totalStockDiscAmt As Decimal = 0
      Dim totalStockAmt As Decimal = 0
      Dim totalBeforTax As Decimal = 0
      Dim totalTaxAmt As Decimal = 0
      Dim totalAfterTax As Decimal = 0
      Dim countRow As Integer = 0
      Dim sumCountRow As Integer = 0

      If CInt(Me.Filters(14).Value) = 0 Then
        For Each row As DataRow In dt.Rows
          If row("ItemCode").ToString & row("ItemName").ToString <> currentItemCode Then
            If Not trItem Is Nothing Then
              trItem("col2") = Configuration.FormatToString(countRow, DigitConfig.Int)
              trItem("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Description}") '"รายการ"
              trItem("col6") = Configuration.FormatToString(itemQty, DigitConfig.Qty)
              trItem("col9") = Configuration.FormatToString(itemDiscAmt, DigitConfig.Price)
              trItem("col10") = Configuration.FormatToString(itemAmt, DigitConfig.Price)

              itemQty = 0
              itemDiscAmt = 0
              itemAmt = 0
              countRow = 0
            End If

            trItem = Me.m_treemanager.Treetable.Childs.Add
            trItem("col0") = row("ItemCode").ToString
            trItem("col1") = row("ItemName").ToString
            trItem.Tag = "Font.Bold"
            trItem.State = RowExpandState.Expanded
            currentItemCode = row("ItemCode").ToString & row("ItemName").ToString
          End If
          If Not trItem Is Nothing Then
            trStock = trItem.Childs.Add
            If Not row.IsNull("DocDate") Then
              If IsDate(row("DocDate")) Then
                trStock("col0") = indent & CDate(row("DocDate")).ToShortDateString
              End If
            End If
            trStock("col1") = indent & row("DocCode").ToString
            trStock("col2") = indent & row("RefCode").ToString
            trStock("col3") = indent & row("PurCode").ToString
            trStock("col4") = indent & row("PO").ToString
            trStock("col5") = indent & row("SupplierName").ToString
            trStock("col6") = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
            trStock("col7") = indent & row("Unit").ToString
            trStock("col8") = Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
            trStock("col9") = Configuration.FormatToString(CDec(row("DiscAmount")), DigitConfig.Price)
            trStock("col10") = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)

            itemQty += CDec(row("Qty"))
            totalItemQty += CDec(row("Qty"))
            itemDiscAmt += CDec(row("DiscAmount"))
            totalItemDiscAmt += CDec(row("DiscAmount"))
            itemAmt += CDec(row("Amount"))
            totalItemAmt += CDec(row("Amount"))
            countRow += 1
            sumCountRow += 1
          End If

        Next

        'สำหรับ Item สุดท้าย
        If Not trItem Is Nothing Then
          trItem("col2") = Configuration.FormatToString(countRow, DigitConfig.Int)
          trItem("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Description}") '"รายการ"
          trItem("col6") = Configuration.FormatToString(itemQty, DigitConfig.Qty)
          trItem("col9") = Configuration.FormatToString(itemDiscAmt, DigitConfig.Price)
          trItem("col10") = Configuration.FormatToString(itemAmt, DigitConfig.Price)
        End If

        trItem = Me.m_treemanager.Treetable.Childs.Add
        trItem("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Sum}") '"รวม"
        trItem("col2") = Configuration.FormatToString(sumCountRow, DigitConfig.Int)
        trItem("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Description}") '"รายการ"
        trItem("col6") = Configuration.FormatToString(totalItemQty, DigitConfig.Qty)
        trItem("col9") = Configuration.FormatToString(totalItemDiscAmt, DigitConfig.Price)
        trItem("col10") = Configuration.FormatToString(totalItemAmt, DigitConfig.Price)
        trItem.Tag = "Font.Bold"

      Else
        For Each row As DataRow In dt.Rows
          If row("SupplierCode").tostring <> currentSupplierCode Then
            trSupplier = Me.m_treemanager.Treetable.Childs.Add
            trSupplier("col0") = row("SupplierCode").ToString
            trSupplier("col1") = row("SupplierName").ToString
            trSupplier.Tag = "Font.Bold"
            trSupplier.State = RowExpandState.Expanded
            currentSupplierCode = row("SupplierCode").Tostring
          End If

          If row("PurCode").tostring <> currentStockCode Then
            If Not trStock Is Nothing Then
              trStock("col5") = Configuration.FormatToString(totalStockQty, DigitConfig.Qty)
              trStock("col8") = Configuration.FormatToString(totalStockDiscAmt, DigitConfig.Price)
              trStock("col9") = Configuration.FormatToString(totalStockAmt, DigitConfig.Price)
              totalStockQty = 0
              totalStockDiscAmt = 0
              totalStockAmt = 0
            End If

            trStock = trSupplier.Childs.Add
            trStock("col0") = indent & row("PurCode").ToString
            If Not row.IsNull("DocDate") Then
              If IsDate(row("DocDate")) Then
                trStock("col1") = indent & CDate(row("DocDate")).ToShortDateString
              End If
            End If
            trStock("col2") = indent & row("DocCode").ToString
            trStock("col3") = indent & row("RefCode").ToString
            trStock("col4") = indent & row("PO").ToString
            trStock("col10") = Configuration.FormatToString(CDec(row("BeforeTax")), DigitConfig.Price)
            trStock("col11") = Configuration.FormatToString(CDec(row("TaxAmount")), DigitConfig.Price)
            trStock("col12") = Configuration.FormatToString(CDec(row("AfterTax")), DigitConfig.Price)
            trStock.State = RowExpandState.Expanded
            currentStockCode = row("PurCode").tostring

            totalBeforTax += CDec(row("BeforeTax"))
            totalTaxAmt += CDec(row("TaxAmount"))
            totalAfterTax += CDec(row("AfterTax"))
          End If

          If Not trStock Is Nothing Then
            trItem = trStock.Childs.Add
            trItem("col0") = indent & indent & row("itemCode").toString
            trItem("col1") = indent & indent & row("itemName").toString
            trItem("col5") = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
            trItem("col6") = indent & indent & row("Unit").ToString
            trItem("col7") = Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
            trItem("col8") = Configuration.FormatToString(CDec(row("DiscAmount")), DigitConfig.Price)
            trItem("col9") = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)

            totalStockQty += CDec(row("Qty"))
            totalStockDiscAmt += CDec(row("DiscAmount"))
            totalStockAmt += CDec(row("Amount"))
            totalQty += CDec(row("Qty"))
            totalDiscAmt += CDec(row("DiscAmount"))
            totalAmt += CDec(row("Amount"))
          End If
        Next

        'สำหรับ Stock ตัวสุดท้าย
        If Not trStock Is Nothing Then
          trStock("col5") = Configuration.FormatToString(totalStockQty, DigitConfig.Qty)
          trStock("col8") = Configuration.FormatToString(totalStockDiscAmt, DigitConfig.Price)
          trStock("col9") = Configuration.FormatToString(totalStockAmt, DigitConfig.Price)
        End If

        trSupplier = Me.m_treemanager.Treetable.Childs.Add
        trSupplier("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.Sum}") '"รวม"
        trSupplier("col5") = Configuration.FormatToString(totalQty, DigitConfig.Price)
        trSupplier("col8") = Configuration.FormatToString(totalDiscAmt, DigitConfig.Price)
        trSupplier("col9") = Configuration.FormatToString(totalAmt, DigitConfig.Price)
        trSupplier("col10") = Configuration.FormatToString(totalBeforTax, DigitConfig.Price)
        trSupplier("col11") = Configuration.FormatToString(totalTaxAmt, DigitConfig.Price)
        trSupplier("col12") = Configuration.FormatToString(totalAfterTax, DigitConfig.Price)
        trSupplier.Tag = "Font.Bold"

      End If

    End Sub
    Private Function SearchTag(ByVal id As Integer) As TreeRow
      If Me.m_treemanager Is Nothing Then
        Return Nothing
      End If
      Dim dt As TreeTable = m_treemanager.Treetable
      For Each row As TreeRow In dt.Rows
        If IsNumeric(row.Tag) AndAlso CInt(row.Tag) = id Then
          Return row
        End If
      Next
    End Function
    Public Overrides Function GetSimpleSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Report")

      myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col6", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col7", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      Dim colCount As Integer = 0
      If CInt(Me.Filters(14).Value) = 0 Then
        colCount = 10
        widths.Add(120)
        widths.Add(200)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(120)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
      Else
        colCount = 12
        widths.Add(120)
        widths.Add(200)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(120)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
        widths.Add(100)
      End If


      For i As Integer = 0 To colCount
        If CInt(Me.Filters(14).Value) = 0 Then
          If i = 1 Then
            Dim cs As New PlusMinusTreeTextColumn
            cs.MappingName = "col" & i
            cs.HeaderText = ""
            cs.Width = CInt(widths(i))
            cs.NullText = ""
            cs.Alignment = HorizontalAlignment.Left
            cs.ReadOnly = True
            cs.Format = "s"
            AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
            dst.GridColumnStyles.Add(cs)
          Else
            Dim cs As New TreeTextColumn(i, True, Color.Khaki)
            cs.MappingName = "col" & i
            cs.HeaderText = ""
            cs.Width = CInt(widths(i))
            cs.NullText = ""
            cs.Alignment = HorizontalAlignment.Left
            Select Case i
              Case 6, 8, 9, 10
                cs.Alignment = HorizontalAlignment.Right
                cs.DataAlignment = HorizontalAlignment.Right
                cs.Format = "d"
              Case Else
                cs.Alignment = HorizontalAlignment.Left
                cs.DataAlignment = HorizontalAlignment.Left
                cs.Format = "s"
            End Select
            cs.ReadOnly = True

            AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
            dst.GridColumnStyles.Add(cs)
          End If

        Else
          If i = 1 Then
            Dim cs As New PlusMinusTreeTextColumn
            cs.MappingName = "col" & i
            cs.HeaderText = ""
            cs.Width = CInt(widths(i))
            cs.NullText = ""
            cs.Alignment = HorizontalAlignment.Left
            cs.ReadOnly = True
            cs.Format = "s"
            AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
            dst.GridColumnStyles.Add(cs)
          Else
            Dim cs As New TreeTextColumn(i, True, Color.Khaki)
            cs.MappingName = "col" & i
            cs.HeaderText = ""
            cs.Width = CInt(widths(i))
            cs.NullText = ""
            cs.Alignment = HorizontalAlignment.Left
            Select Case i
              Case 5, 7, 8, 9, 10, 11, 12
                cs.Alignment = HorizontalAlignment.Right
                cs.DataAlignment = HorizontalAlignment.Right
                cs.Format = "d"
              Case Else
                cs.Alignment = HorizontalAlignment.Left
                cs.DataAlignment = HorizontalAlignment.Left
                cs.Format = "s"
            End Select
            cs.ReadOnly = True

            AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
            dst.GridColumnStyles.Add(cs)
          End If
        End If
      Next

      Return dst
    End Function
    Public Overrides Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If e.Row <= 1 Then
        e.HilightValue = True
      End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptCreditPurchase"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptCreditPurchase"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptCreditPurchase"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCreditPurchase.ListLabel}"
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
      Return "RptCreditPurchase"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptCreditPurchase"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Dim fn As Font

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim startRow As Integer = 0
      If CInt(Me.Filters(14).Value) = 0 Then
        startRow = 3
      Else
        startRow = 4
      End If
      Dim n As Integer = 0
      For rowIndex As Integer = startRow To m_grid.RowCount

        If Not CType(Me.m_treemanager.Treetable.Rows(rowIndex - 1), TreeRow).Tag Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If

        For colIndex As Integer = 0 To m_grid.ColCount - 1
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & colIndex.ToString
          dpi.Value = m_grid(rowIndex, colIndex + 1).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpi.Font = fn
          dpiColl.Add(dpi)
        Next

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

