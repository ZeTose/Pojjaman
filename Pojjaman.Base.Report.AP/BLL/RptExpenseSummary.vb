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
  Public Class RptExpenseSummary
    Inherits Report

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
    Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
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
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.SupplierCode}") '"รหัสผู้ขาย"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.SupplierName}") '"ชื่อผู้ขาย"

      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.ItemCode}") '"รหัสสินค้า"
      tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.ItemName}") '"ชื่อสินค้า"

      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.PaymentDate}") '"วันที่จ่าย"
      tr("col2") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.Amount}") '"ราคา"
      tr("col3") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.PaymentType}") '"วิธีจ่าย"
      tr("col4") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.CqCode}") '"เลขที่เช็ค"

    End Sub
    Private m_maxDataLevel As Integer = 1
    Private m_maxLevel As Integer = 1
    Private Sub PopulateData()
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      Dim dsh As New DataSetHelper
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentSupplierCode As String = ""
      Dim currentItemCode As String = ""

      Dim SupplierTr As TreeRow
      Dim ItemTr As TreeRow
      Dim DocTr As TreeRow
      Dim ResultTr As TreeRow
      Dim indent As String = Space(3)
      Dim tmpItemAmt As Decimal = 0
      Dim tmpSupplierAmt As Decimal = 0
      For Each row As DataRow In dt.Rows
        If row("SupplierCode").ToString & row("SupplierName").ToString <> currentSupplierCode Then
          If currentSupplierCode <> "" Then
            ResultTr = ItemTr.Childs.Add
            ResultTr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.SumItemAmount}")
            ResultTr("col2") = Configuration.FormatToString(tmpItemAmt, DigitConfig.Price)

            ResultTr = SupplierTr.Childs.Add
            ResultTr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.SumSupplierAmount}")
            ResultTr("col2") = Configuration.FormatToString(tmpSupplierAmt, DigitConfig.Price)
            ResultTr.State = RowExpandState.Expanded

            tmpItemAmt = 0
            tmpSupplierAmt = 0
          End If
          SupplierTr = Me.m_treemanager.Treetable.Childs.Add
          SupplierTr("col0") = row("SupplierCode")
          SupplierTr("col1") = row("SupplierName")
          currentSupplierCode = row("SupplierCode").ToString & row("SupplierName").ToString
          currentItemCode = ""
          SupplierTr.State = RowExpandState.Expanded
        End If
        If row("ItemCode").ToString & row("ItemName").ToString <> currentItemCode Then
          If currentItemCode <> "" Then
            ResultTr = ItemTr.Childs.Add
            ResultTr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.SumItemAmount}")
            ResultTr("col2") = Configuration.FormatToString(tmpItemAmt, DigitConfig.Price)
            tmpItemAmt = 0
          End If
          ItemTr = SupplierTr.Childs.Add
          If Not row.IsNull("ItemCode") Then
            ItemTr("col0") = indent & row("ItemCode").ToString
          End If
          If Not row.IsNull("ItemName") Then
            ItemTr("col1") = indent & row("ItemName").ToString
          End If
          currentItemCode = row("ItemCode").ToString & row("ItemName").ToString
          ItemTr.State = RowExpandState.Expanded
          tmpItemAmt = 0
        End If
        DocTr = ItemTr.Childs.Add
        If IsDate(row("DocDate")) Then
          DocTr("col0") = indent & indent & CDate(row("DocDate")).ToShortDateString
        End If
        If IsNumeric(row("Pay")) Then
          DocTr("col2") = indent & indent & Configuration.FormatToString(CDec(row("Pay")), DigitConfig.Price)
          tmpItemAmt += CDec(row("Pay"))
          tmpSupplierAmt += CDec(row("Pay"))
        End If
        If Not row.IsNull("PayType") Then
          DocTr("col3") = indent & indent & row("PayType").ToString
        End If
        If Not row.IsNull("CqCode") Then
          DocTr("col4") = indent & indent & row("CqCode").ToString
        End If
      Next

      'ResultTr = ItemTr.Childs.Add
      ResultTr = Me.m_treemanager.Treetable.Childs.Add
      ResultTr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.SumItemAmount}")
      ResultTr("col2") = Configuration.FormatToString(tmpItemAmt, DigitConfig.Price)

      'ResultTr = SupplierTr.Childs.Add
      ResultTr = Me.m_treemanager.Treetable.Childs.Add
      ResultTr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.SumSupplierAmount}")
      ResultTr("col2") = Configuration.FormatToString(tmpSupplierAmt, DigitConfig.Price)
      ResultTr.State = RowExpandState.Expanded
      'dt.AcceptChanges()
      ResultTr.State = RowExpandState.Expanded

    End Sub
    Public Overrides Function GetSimpleSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Report")
      myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      widths.Add(150)
      widths.Add(200)
      widths.Add(150)
      widths.Add(200)
      widths.Add(200)

      Dim alignments As New ArrayList
      alignments.Add(HorizontalAlignment.Left)
      alignments.Add(HorizontalAlignment.Left)
      alignments.Add(HorizontalAlignment.Right)
      alignments.Add(HorizontalAlignment.Left)
      alignments.Add(HorizontalAlignment.Left)

      For i As Integer = 0 To 4
        Dim cs As New TreeTextColumn(i, True, Color.Khaki)
        cs.MappingName = "col" & i
        cs.HeaderText = ""
        cs.Width = CInt(widths(i))
        cs.NullText = ""
        cs.Alignment = HorizontalAlignment.Left
        cs.DataAlignment = CType(alignments(i), HorizontalAlignment)
        cs.ReadOnly = True
        cs.Format = "d"
        AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
        dst.GridColumnStyles.Add(cs)
      Next
      Return dst
    End Function
    Public Overrides Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If e.Row <= 2 Then
        e.HilightValue = True
      End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptExpenseSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptExpenseSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptExpenseSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptExpenseSummary.ListLabel}"
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
      Return "RptExpenseSummary"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptExpenseSummary"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim i As Integer = 0
      For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
        If i > 2 Then
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = itemRow("col0")
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          dpi.Value = itemRow("col1")
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col2"
          dpi.Value = itemRow("col2")
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col3"
          dpi.Value = itemRow("col3")
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col4"
          dpi.Value = itemRow("col4")
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
          n += 1
        End If
        i += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

