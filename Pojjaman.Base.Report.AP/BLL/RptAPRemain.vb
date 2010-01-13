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
  Public Class RptAPRemain
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
        lkg.Rows.HeaderCount = 1
        lkg.Rows.FrozenCount = 1
      Else
        lkg.Rows.HeaderCount = 2
        lkg.Rows.FrozenCount = 2
      End If

      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Treemanager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      m_showDetailInGrid = CInt(Me.Filters(7).Value)
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String = Space(3)

      If m_showDetailInGrid = 0 Then
        ' Level 1.
        Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierCode}") '"รหัสเจ้าหนี้"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierName}") '"ชื่อเจ้าหนี้"
        tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.OpenningBalance}") '"ยอดยกมา"
        tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Debt}") '"ยอดซื้อเชื่อ"
        tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Dicount}") '"ยอดลดหนี้"
        tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Pay}") '"ยอดจ่ายชำระ"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.EndingBalance}") '"ยอดยกไป"
        tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionOpeningBalance}") '"ยอด Retention ยกมา"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Retention}") '"ยอด Retention"
        tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.PayRetention}") '"ยอดจ่ายชำระ Retention"
        tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionEndingBalance}") '"ยอด Retention ยกไป"
        tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"หมายเหตุ"
      Else
        ' Level 1.
        Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierCode}") '"รหัสเจ้าหนี้"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierName}") '"ชื่อเจ้าหนี้"
        tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.OpenningBalance}") '"ยอดยกมา"
        tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Debt}") '"ยอดซื้อเชื่อ"
        tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Dicount}") '"ยอดลดหนี้"
        tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Pay}") '"ยอดจ่ายชำระ"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.EndingBalance}") '"ยอดยกไป"
        tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionOpeningBalance}") '"ยอด Retention ยกมา"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Retention}") '"ยอด Retention"
        tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.PayRetention}") '"ยอดจ่ายชำระ Retention"
        tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionEndingBalance}") '"ยอด Retention ยกไป"
        tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"หมายเหตุ"
        ' Level 2.
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DocType}") '"ประเภทเอกสาร"
        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DNDocNo}") '"เลขที่เอกสาร"
        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DocDate}") '"วันที่เอกสาร"
        tr("col3") = indent & Me.StringParserService.Parse("เลขที่ใบสำคัญ") '"เลขที่ใบสำคัญ"
      End If
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(1)
      'Dim dt2 As DataTable = Me.DataSet.Tables(2)

      If dt.Rows.Count = 0 Then
        Return
      End If
      Dim indent As String = Space(3)

      Dim trSupplier As TreeRow
      Dim trDetail As TreeRow

      Dim sumOpenningBalance As Decimal = 0
      Dim sumAmount As Decimal = 0
      Dim sumPCNAmount As Decimal = 0
      Dim sumPayAmount As Decimal = 0
      Dim sumEndingBalance As Decimal = 0
      Dim sumOpeningBalanceRetention As Decimal = 0
      Dim sumRetention As Decimal = 0
      Dim sumPaysRetention As Decimal = 0
      Dim sumEndingBalanceRetention As Decimal = 0

      For Each supplierRow As DataRow In dt.Rows
        trSupplier = Me.Treemanager.Treetable.Childs.Add
        trSupplier.Tag = "Font.Bold"
        If Not supplierRow.IsNull("supplier_code") Then
          trSupplier("col0") = supplierRow("supplier_code").ToString
        End If
        If Not supplierRow.IsNull("supplier_name") Then
          trSupplier("col1") = supplierRow("supplier_name").ToString
        End If
        If Not supplierRow.IsNull("OpeningBalance") Then
          trSupplier("col4") = Configuration.FormatToString(CDec(supplierRow("OpeningBalance")), DigitConfig.Price)
          sumOpenningBalance += CDec(supplierRow("OpeningBalance"))
        End If
        If Not supplierRow.IsNull("Amount") Then
          If CDec(supplierRow("Amount")) <> 0 Then
            trSupplier("col5") = Configuration.FormatToString(CDec(supplierRow("Amount")), DigitConfig.Price)
            sumAmount += CDec(supplierRow("Amount"))
          End If
        End If
        If Not supplierRow.IsNull("PCN") Then
          If CDec(supplierRow("PCN")) <> 0 Then
            trSupplier("col6") = Configuration.FormatToString(CDec(supplierRow("PCN")), DigitConfig.Price)
            sumPCNAmount += CDec(supplierRow("PCN"))
          End If
        End If
        If Not supplierRow.IsNull("Pays") Then
          If CDec(supplierRow("Pays")) <> 0 Then
            trSupplier("col7") = Configuration.FormatToString(CDec(supplierRow("Pays")), DigitConfig.Price)
            sumPayAmount += CDec(supplierRow("Pays"))
          End If
        End If
        If Not supplierRow.IsNull("EndingBalance") Then
          trSupplier("col8") = Configuration.FormatToString(CDec(supplierRow("EndingBalance")), DigitConfig.Price)
          sumEndingBalance += CDec(supplierRow("EndingBalance"))
        End If

        If Not supplierRow.IsNull("OpeningBalanceRetention") Then
          trSupplier("col9") = Configuration.FormatToString(CDec(supplierRow("OpeningBalanceRetention")), DigitConfig.Price)
          sumOpeningBalanceRetention += CDec(supplierRow("OpeningBalanceRetention"))
        End If
        If Not supplierRow.IsNull("Retention") Then
          If CDec(supplierRow("Retention")) <> 0 Then
            trSupplier("col10") = Configuration.FormatToString(CDec(supplierRow("Retention")), DigitConfig.Price)
            sumRetention += CDec(supplierRow("Retention"))
          End If
        End If
        If Not supplierRow.IsNull("PayRetention") Then
          If CDec(supplierRow("PayRetention")) <> 0 Then
            trSupplier("col11") = Configuration.FormatToString(CDec(supplierRow("PayRetention")), DigitConfig.Price)
            sumPaysRetention += CDec(supplierRow("PayRetention"))
          End If
        End If
        If Not supplierRow.IsNull("EndingBalanceRetention") Then
          trSupplier("col12") = Configuration.FormatToString(CDec(supplierRow("EndingBalanceRetention")), DigitConfig.Price)
          sumEndingBalanceRetention += CDec(supplierRow("EndingBalanceRetention"))
        End If


        If m_showDetailInGrid <> 0 Then
          Dim dt2 As DataTable = Me.DataSet.Tables(2)
          trSupplier.State = RowExpandState.Expanded
          For Each detailRow As DataRow In dt2.Select("Supplier=" & supplierRow("Supplier_ID").ToString)
            Dim deh As New DataRowHelper(detailRow)
            If Not trSupplier Is Nothing Then
              trDetail = trSupplier.Childs.Add
              If Not detailRow.IsNull("entity_description") Then
                trDetail("col0") = indent & detailRow("entity_description").ToString
              End If
              If Not detailRow.IsNull("doccode") Then
                trDetail("col1") = indent & detailRow("doccode").ToString
              End If
              If Not detailRow.IsNull("docdate") Then
                If IsDate(detailRow("docdate")) Then
                  trDetail("col2") = indent & CDate(detailRow("docdate")).ToShortDateString
                End If
              End If

              trDetail("col3") = indent & deh.GetValue(Of String)("glcode", "-")

              If Not detailRow.IsNull("OpeningBalance") Then
                trDetail("col4") = Configuration.FormatToString(CDec(detailRow("OpeningBalance")), DigitConfig.Price)
              End If
              If Not detailRow.IsNull("Amount") Then
                If CDec(detailRow("Amount")) <> 0 Then
                  trDetail("col5") = Configuration.FormatToString(CDec(detailRow("Amount")), DigitConfig.Price)
                End If
              End If
              If Not detailRow.IsNull("PCN") Then
                If CDec(detailRow("PCN")) <> 0 Then
                  trDetail("col6") = Configuration.FormatToString(CDec(detailRow("PCN")), DigitConfig.Price)
                End If
              End If
              If Not detailRow.IsNull("Pays") Then
                If CDec(detailRow("Pays")) <> 0 Then
                  trDetail("col7") = Configuration.FormatToString(CDec(detailRow("Pays")), DigitConfig.Price)
                End If
              End If
              If Not detailRow.IsNull("EndingBalance") Then
                trDetail("col8") = Configuration.FormatToString(CDec(detailRow("EndingBalance")), DigitConfig.Price)
              End If
              If Not detailRow.IsNull("OpeningBalanceRetention") Then
                trDetail("col9") = Configuration.FormatToString(CDec(detailRow("OpeningBalanceRetention")), DigitConfig.Price)
              End If
              If Not detailRow.IsNull("Retention") Then
                If CDec(detailRow("Retention")) <> 0 Then
                  trDetail("col10") = Configuration.FormatToString(CDec(detailRow("Retention")), DigitConfig.Price)
                End If
              End If
              If Not detailRow.IsNull("PayRetention") Then
                If CDec(detailRow("PayRetention")) <> 0 Then
                  trDetail("col11") = Configuration.FormatToString(CDec(detailRow("PayRetention")), DigitConfig.Price)
                End If
              End If
              trDetail("col12") = Configuration.FormatToString(deh.GetValue(Of Decimal)("EndingBalanceRetention"), DigitConfig.Price)
              trDetail("col13") = indent & deh.GetValue(Of String)("glNote", "-")
            End If
          Next
        End If
      Next
      'ตูดรายงาน
      trSupplier = Me.Treemanager.Treetable.Childs.Add
      trSupplier.Tag = "Font.Bold"
      trSupplier("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Total}")  'รวม
      trSupplier("col4") = Configuration.FormatToString(sumOpenningBalance, DigitConfig.Price)
      If sumAmount > 0 Then
        trSupplier("col5") = Configuration.FormatToString(sumAmount, DigitConfig.Price)
      End If
      If sumPCNAmount > 0 Then
        trSupplier("col6") = Configuration.FormatToString(sumPCNAmount, DigitConfig.Price)
      End If
      If sumPayAmount > 0 Then
        trSupplier("col7") = Configuration.FormatToString(sumPayAmount, DigitConfig.Price)
      End If
      trSupplier("col8") = Configuration.FormatToString(sumEndingBalance, DigitConfig.Price)

      trSupplier("col9") = Configuration.FormatToString(sumOpeningBalanceRetention, DigitConfig.Price)
      If sumRetention > 0 Then
        trSupplier("col10") = Configuration.FormatToString(sumRetention, DigitConfig.Price)
      End If
      If sumPaysRetention > 0 Then
        trSupplier("col11") = Configuration.FormatToString(sumPaysRetention, DigitConfig.Price)
      End If
      trSupplier("col12") = Configuration.FormatToString(sumEndingBalanceRetention, DigitConfig.Price)

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

      widths.Add(90)
      widths.Add(180)
      widths.Add(80 * CInt(Me.Filters(7).Value))
      widths.Add(95 * CInt(Me.Filters(7).Value))
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(180 * CInt(Me.Filters(7).Value))

For i As Integer = 0 To iCol
        If i = 1 Then
          If CInt(Me.Filters(7).Value) <> 0 Then
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
            Dim cs As New TreeTextColumn(1, True, Color.White)
            cs.MappingName = "col" & i
            cs.HeaderText = ""
            cs.Width = CInt(widths(i))
            cs.NullText = ""
            cs.Alignment = HorizontalAlignment.Left
            cs.ReadOnly = True
            cs.Format = "s"
            AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
            dst.GridColumnStyles.Add(cs)
          End If
        Else
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          If CInt(Me.Filters(7).Value) <> 0 Then
            Select Case i
              Case 0, 1, 2, 3
                cs.Alignment = HorizontalAlignment.Left
                cs.DataAlignment = HorizontalAlignment.Left
                cs.Format = "s"
              Case Else
                cs.Alignment = HorizontalAlignment.Right
                cs.DataAlignment = HorizontalAlignment.Right
                cs.Format = "d"
            End Select
          Else
            Select Case i
              Case 0, 1, 9
                cs.Alignment = HorizontalAlignment.Left
                cs.DataAlignment = HorizontalAlignment.Left
                cs.Format = "s"
              Case Else
                cs.Alignment = HorizontalAlignment.Right
                cs.DataAlignment = HorizontalAlignment.Right
                cs.Format = "d"
            End Select
          End If

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
#End Region

#Region "Shared"
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAPRemain"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPRemain"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPRemain"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.ListLabel}"
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
#End Region

#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
    End Function
    Public Overrides Function GetDefaultForm() As String

    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        Select Case fixDpi.Mapping.ToLower
          Case "month", "year", "today"
            dpiColl.Add(fixDpi)
          Case "docdatestart", "docdateend"
            dpiColl.Add(fixDpi)
          Case "supplierstart", "supplierend"
            dpiColl.Add(fixDpi)
          Case "costcenterstart", "costcenterend"
            dpiColl.Add(fixDpi)
        End Select
      Next

      Dim i As Integer = 0
      Dim iRow As Integer = 0
      If m_showDetailInGrid = 0 Then
        iRow = 2
      Else
        iRow = 3
      End If
      Dim fn As Font

      For rowIndex As Integer = iRow To Me.m_grid.RowCount

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
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Font = fn
          dpiColl.Add(dpi)
        Next

        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

