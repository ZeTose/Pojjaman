Option Strict On
Option Explicit On 

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
  Public Class RptAPAdvancePay
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_showDetailInGrid As Integer
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
      If m_showDetailInGrid = 0 Then
        lkg.Rows.HeaderCount = 2
        lkg.Rows.FrozenCount = 2
      Else
        lkg.Rows.HeaderCount = 3
        lkg.Rows.FrozenCount = 3
      End If

      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      m_showDetailInGrid = CInt(Me.Filters(10).Value)
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String = Space(3)

      'If m_showDetailInGrid = 0 Then
      ' Level 0
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.SupplierCode}")  '"รหัสเจ้าหนี้"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.SupplierName}")  '"ชื่อเจ้าหนี้"
      ' Level 1
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.DocCode}")  '"เลขที่เอกสาร"
      tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.DocDate}")  '"วันที่เอกสาร"
      tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.GLCode}")  '"เลขที่ GL"
      tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.VatInvoice}")  '"เลขที่ใบกำกับ"
      tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.CostcenterCode}")  '"รหัส Cost Center"
      tr("col5") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.CostcenterName}")  '"ชื่อ Cost Center"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.BeforeTax}")  '"ยอดก่อนภาษี"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.TaxAmount}") '"เงินภาษี"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.AfterTax}")  '"รวม"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.OpenningBalance}")  '"ยอดคงเหลือยกมา"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.CreditAmt}")  '"ยอดหักมัดจำ"
      tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.RemainingAmt}")  '"ยอดคงเหลือ"
      tr("col12") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Status}")  '"สถานะ"
      tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.GLNote}")  '"หมายเหตุ GL"
      If m_showDetailInGrid = 1 Then
        'Else
        ' Level 2
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.RefDocCode}")  '"เลขที่เอกสาร"
        tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.RefDocDate}")  '"วันที่เอกสาร"
        tr("col3") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.GLCode}")  '"เลขที่GL"
        tr("col4") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.RefDocType}")  '"ประเภทเอกสาร"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.AdvanceAmt}")  '"ยอดหัก" 
        tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Remain}")  '"คงเหลือ" 
        tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.GLNote}")  '"หมายเหตุ GL"

      End If
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt1 As DataTable = Me.DataSet.Tables(1)

      If dt.Rows.Count = 0 Then
        Return
      End If

      Dim indent As String = Space(3)

      Dim trSupplier As TreeRow
      Dim trDoc As TreeRow
      Dim trDetail As TreeRow

      Dim advanceRemain As Decimal = 0
      Dim totalAdvanceAmount As Decimal = 0

      Dim totalBeforeTax As Decimal = 0
      Dim totalTaxAmount As Decimal = 0
      Dim totalAfterTax As Decimal = 0
      Dim totalAdvance As Decimal = 0
      Dim totalBalance As Decimal = 0

      Dim currentSupplier As String = ""
      For Each supplierRow As DataRow In dt.Rows
        If currentSupplier <> supplierRow("suppliercode").ToString Then
          currentSupplier = supplierRow("suppliercode").ToString

          trSupplier = Me.Treemanager.Treetable.Childs.Add
          trSupplier.Tag = "Font.Bold"
          If Not supplierRow.IsNull("suppliercode") Then
            trSupplier("col0") = supplierRow("suppliercode").ToString
          End If
          If Not supplierRow.IsNull("suppliername") Then
            trSupplier("col1") = supplierRow("suppliername").ToString
          End If

          For Each advanceRow As DataRow In dt.Select("supplier_Id=" & supplierRow("supplier_Id").ToString)
            trDoc = trSupplier.Childs.Add
            If Not advanceRow.IsNull("doccode") Then
              trDoc("col0") = indent & advanceRow("doccode").ToString
            End If
            If Not advanceRow.IsNull("docdate") Then
              If IsDate(advanceRow("docdate")) Then
                trDoc("col1") = CDate(advanceRow("docdate")).ToShortDateString
              End If
            End If
            If Not advanceRow.IsNull("AdvPglCode") Then
              trDoc("col2") = indent & advanceRow("AdvPglCode").ToString
            End If
            If Not advanceRow.IsNull("VatInvoice") Then
              trDoc("col3") = indent & advanceRow("VatInvoice").ToString
            End If
            If Not advanceRow.IsNull("CostCenterCode") Then
              trDoc("col4") = indent & advanceRow("CostCenterCode").ToString
            End If
            If Not advanceRow.IsNull("CostCenterName") Then
              trDoc("col5") = indent & advanceRow("CostCenterName").ToString
            End If
            If Not advanceRow.IsNull("beforetax") Then
              trDoc("col6") = Configuration.FormatToString(CDec(advanceRow("beforetax")), DigitConfig.Price)
              totalBeforeTax += CDec(advanceRow("beforetax"))
            End If
            If Not advanceRow.IsNull("taxamt") Then
              trDoc("col7") = Configuration.FormatToString(CDec(advanceRow("taxamt")), DigitConfig.Price)
              totalTaxAmount += CDec(advanceRow("taxamt"))
            End If
            If Not advanceRow.IsNull("aftertax") Then
              trDoc("col8") = Configuration.FormatToString(CDec(advanceRow("aftertax")), DigitConfig.Price)
              totalAfterTax += CDec(advanceRow("aftertax"))
            End If
            If Not advanceRow.IsNull("openningbalanceremain") Then
              trDoc("col9") = Configuration.FormatToString(CDec(advanceRow("openningbalanceremain")), DigitConfig.Price)
              advanceRemain = CDec(advanceRow("openningbalanceremain"))
            End If
            If Not advanceRow.IsNull("status") Then
              If CInt(advanceRow("status")) = 0 Then
                advanceRow("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Canceled}")  '"ถูกยกเลิก"
              End If
            End If
            If Not advanceRow.IsNull("AdvPglNote") Then
              trDoc("col13") = indent & advanceRow("AdvPglNote").ToString
            End If

            totalAdvanceAmount = 0

            For Each detailRow As DataRow In dt1.Select("id=" & advanceRow("advp_id").ToString)

              If CDec(detailRow("OpenningRecord")) = 0 Then


                If Not detailRow.IsNull("currentamount") Then
                  totalAdvanceAmount += CDec(detailRow("currentamount"))
                  totalAdvance += CDec(detailRow("currentamount"))
                  advanceRemain -= CDec(detailRow("currentamount"))
                End If

                If m_showDetailInGrid <> 0 Then
                  trDetail = trDoc.Childs.Add
                  If Not detailRow.IsNull("refcode") Then
                    trDetail("col0") = indent & indent & detailRow("refcode").ToString
                  End If
                  If Not detailRow.IsNull("refdate") Then
                    If IsDate(detailRow("refdate")) Then
                      trDetail("col1") = CDate(detailRow("refdate")).ToShortDateString
                    End If
                  End If
                  If Not detailRow.IsNull("refGlCode") Then
                    If IsDate(detailRow("refGlCode")) Then
                      trDetail("col1") = CDate(detailRow("refGlCode")).ToShortDateString
                    End If
                  End If
                  If Not detailRow.IsNull("entity_description") Then
                    trDetail("col4") = indent & indent & detailRow("entity_description").ToString
                  End If
                  If Not detailRow.IsNull("currentamount") Then
                    trDetail("col10") = Configuration.FormatToString(CDec(detailRow("currentamount")), DigitConfig.Price)
                  End If
                  trDetail("col11") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)
                  If Not detailRow.IsNull("refGlNote") Then
                    If IsDate(detailRow("refGlNote")) Then
                      trDetail("col13") = CDate(detailRow("refGlNote")).ToShortDateString
                    End If
                  End If
                End If
              End If
            Next

            trDoc("col10") = Configuration.FormatToString(totalAdvanceAmount, DigitConfig.Price)
            trDoc("col11") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)

            totalBalance += advanceRemain

            trDoc.State = RowExpandState.Expanded

          Next

          trSupplier.State = RowExpandState.Expanded

        End If

      Next

      trSupplier = Me.m_treemanager.Treetable.Childs.Add
      trSupplier.Tag = "Font.Bold"
      trSupplier("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Total}") '"รวม"
      'trSupplier("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Total}") '"รวม"
      trSupplier("col6") = Configuration.FormatToString(totalBeforeTax, DigitConfig.Price)
      trSupplier("col7") = Configuration.FormatToString(totalTaxAmount, DigitConfig.Price)
      trSupplier("col8") = Configuration.FormatToString(totalAfterTax, DigitConfig.Price)

      trSupplier("col10") = Configuration.FormatToString(totalAdvance, DigitConfig.Price)
      trSupplier("col11") = Configuration.FormatToString(totalBalance, DigitConfig.Price)

      Return

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
      myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      Dim iCol As Integer = 13 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

      widths.Add(120)    'Code
      widths.Add(200)    'date
      widths.Add(100)    'glcode
      widths.Add(100)    'vat
      widths.Add(150)    'cc code
      widths.Add(120)    'cc name
      widths.Add(100)    '
      widths.Add(100)
      widths.Add(120)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)      'Status
      widths.Add(200)      'หมายเหตุ

      For i As Integer = 0 To iCol
        If i = 1 Then
          'If m_showDetailInGrid <> 0 Then
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
          'If Me.m_showDetailInGrid <> 0 Then
          Select Case i
            Case 0, 1, 2, 3, 4, 5, 12, 13
              cs.Alignment = HorizontalAlignment.Left
              cs.DataAlignment = HorizontalAlignment.Left
              cs.Format = "s"
            Case Else
              cs.Alignment = HorizontalAlignment.Right
              cs.DataAlignment = HorizontalAlignment.Right
              cs.Format = "d"
          End Select

          cs.ReadOnly = True

          AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
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
        Return "RptAPAdvancePay"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPAdvancePay"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPAdvancePay"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.ListLabel}"
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
      Return "RptAPAdvancePay"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAPAdvancePay"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      'Dim fn1 As Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      'Dim fn2 As Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))

      'docdate start
      dpi = New DocPrintingItem
      dpi.Mapping = "docdatestart"
      If Not IsDBNull(Filters(0).Value) Then
        dpi.Value = CDate((Filters(0).Value)).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'docdate end
      dpi = New DocPrintingItem
      dpi.Mapping = "docdateend"
      If Not IsDBNull(Filters(1).Value) Then
        dpi.Value = CDate((Filters(1).Value)).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'supplier start
      dpi = New DocPrintingItem
      dpi.Mapping = "supplierstart"
      If Not IsDBNull(Filters(2).Value) Then
        dpi.Value = CStr((Filters(2).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'supplier end
      dpi = New DocPrintingItem
      dpi.Mapping = "supplierend"
      If Not IsDBNull(Filters(3).Value) Then
        dpi.Value = CStr((Filters(3).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'costcenter start
      dpi = New DocPrintingItem
      dpi.Mapping = "costcenterstart"
      If Not IsDBNull(Filters(6).Value) Then
        dpi.Value = CStr((Filters(6).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'costcenter end
      dpi = New DocPrintingItem
      dpi.Mapping = "costcenterend"
      If Not IsDBNull(Filters(7).Value) Then
        dpi.Value = CStr((Filters(7).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim n As Integer = 0
      Dim SumTaxBase As Decimal = 0
      Dim SumTaxAmt As Decimal = 0
      Dim SumTotal As Decimal = 0
      Dim StartRow As Integer = 0
      Dim fn As Font
      If Me.m_showDetailInGrid = 0 Then
        StartRow = 3
      Else
        StartRow = 4
      End If

      For rowIndex As Integer = StartRow To m_grid.RowCount
        fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))

        If Me.m_showDetailInGrid <> 0 Then
          If Not CType(Me.Treemanager.Treetable.Rows(rowIndex - 1), TreeRow).Tag Is Nothing Then
            fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
        End If

        For colIndex As Integer = 1 To Me.m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & colIndex.ToString
          dpi.Value = m_grid(rowIndex, colIndex).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpi.Font = fn
          dpiColl.Add(dpi)
        Next

        If rowIndex = m_grid.RowCount Then
          'SumText
          dpi = New DocPrintingItem
          dpi.Mapping = "SumText"
          dpi.Value = m_grid(rowIndex, 3).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumBeforeTax
          dpi = New DocPrintingItem
          dpi.Mapping = "SumBeforeTax"
          dpi.Value = m_grid(rowIndex, 4).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumTaxAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "SumTaxAmount"
          dpi.Value = m_grid(rowIndex, 5).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumAfterTax
          dpi = New DocPrintingItem
          dpi.Mapping = "SumAfterTax"
          dpi.Value = m_grid(rowIndex, 6).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumAdvanceAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "SumAdvanceAmount"
          dpi.Value = m_grid(rowIndex, 8).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumBalance
          dpi = New DocPrintingItem
          dpi.Mapping = "SumBalance"
          dpi.Value = m_grid(rowIndex, 9).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)
        End If

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

