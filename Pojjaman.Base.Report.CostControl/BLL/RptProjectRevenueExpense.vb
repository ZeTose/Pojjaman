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
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptProjectRevenueExpense
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_cc As CostCenter
    Private m_hashData As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
      MyBase.New(filters, fixValueCollection)
    End Sub
#End Region

#Region "Style"
    Public Shared Function CreateCBSMonitorTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "CBS"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csHeader As New TreeTextColumn
      csHeader.MappingName = "header"
      csHeader.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CBSCODEHeaderText}")
      csHeader.NullText = ""
      csHeader.Width = 90
      csHeader.DataAlignment = HorizontalAlignment.Left
      csHeader.ReadOnly = True
      csHeader.TextBox.Name = "cbs_code"

      Dim csCBSCode As New PlusMinusTreeTextColumn
      csCBSCode.MappingName = "cbs_code"
      csCBSCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CBSCODEHeaderText}")
      csCBSCode.NullText = ""
      csCBSCode.Width = 190
      csCBSCode.DataAlignment = HorizontalAlignment.Left
      csCBSCode.ReadOnly = True
      csCBSCode.TextBox.Name = "cbs_code"

      Dim csCBSName As New TreeTextColumn
      csCBSName.MappingName = "cbs_Name"
      csCBSName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CNBHeaderText}")
      csCBSName.NullText = ""
      csCBSName.Width = 290
      csCBSName.DataAlignment = HorizontalAlignment.Left
      csCBSName.TextBox.Name = "CBS_name"
      csCBSName.ReadOnly = True

      Dim csBarrier0 As New DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier0"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
      csBarrier0.ReadOnly = True

      Dim csBudget As New TreeTextColumn
      csBudget.MappingName = "BudgetCost"
      csBudget.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.BudgetCostHeaderText}")
      csBudget.NullText = ""
      csBudget.DataAlignment = HorizontalAlignment.Right
      csBudget.Format = "#,###.##"
      csBudget.Width = 120
      csBudget.TextBox.Name = "BudgetCost"
      csBudget.ReadOnly = True

      Dim csActualTotalPO As New TreeTextColumn
      csActualTotalPO.MappingName = "ActualPOCost"
      csActualTotalPO.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPOCostHeaderText}")
      csActualTotalPO.NullText = ""
      csActualTotalPO.DataAlignment = HorizontalAlignment.Right
      csActualTotalPO.Format = "#,###.##"
      csActualTotalPO.Width = 120
      csActualTotalPO.TextBox.Name = "ActualPOCost"
      csActualTotalPO.ReadOnly = True

      Dim csPODiff As New TreeTextColumn
      csPODiff.MappingName = "PODiff"
      csPODiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csPODiff.NullText = ""
      csPODiff.DataAlignment = HorizontalAlignment.Right
      csPODiff.Format = "#,###.##"
      csPODiff.Width = 120
      csPODiff.TextBox.Name = "PODiff"
      csPODiff.ReadOnly = True

      Dim csActualTotalGR As New TreeTextColumn
      csActualTotalGR.MappingName = "ActualGRCost"
      csActualTotalGR.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualGRCostHeaderText}")
      csActualTotalGR.NullText = ""
      csActualTotalGR.DataAlignment = HorizontalAlignment.Right
      csActualTotalGR.Format = "#,###.##"
      csActualTotalGR.Width = 120
      csActualTotalGR.TextBox.Name = "ActualGRCost"
      csActualTotalGR.ReadOnly = True

      Dim csGRDiff As New TreeTextColumn
      csGRDiff.MappingName = "GRDiff"
      csGRDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csGRDiff.NullText = ""
      csGRDiff.DataAlignment = HorizontalAlignment.Right
      csGRDiff.Format = "#,###.##"
      csGRDiff.Width = 120
      csGRDiff.TextBox.Name = "GRDiff"
      csGRDiff.ReadOnly = True

      dst.GridColumnStyles.Add(csHeader)

      dst.GridColumnStyles.Add(csCBSCode)
      dst.GridColumnStyles.Add(csCBSName)
      dst.GridColumnStyles.Add(csBarrier0)

      dst.GridColumnStyles.Add(csBudget)

      dst.GridColumnStyles.Add(csActualTotalPO)
      dst.GridColumnStyles.Add(csPODiff)
      dst.GridColumnStyles.Add(csActualTotalGR)
      dst.GridColumnStyles.Add(csGRDiff)

      Return dst
    End Function
    Public Shared Function GetCBSMonitorSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("CBS")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("header", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("cbs_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("cbs_name", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier0", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("BudgetCost", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("ActualPOCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PODiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("ActualGRCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("GRDiff", GetType(String)))

      Return myDatatable
    End Function

    Private Function CreateHeader(ByVal dt As TreeTable) As TreeRow
      If dt Is Nothing Then
        Return Nothing
      End If

      'dt.Clear()

      Dim tr As TreeRow = dt.Childs.Add
      tr("header") = ""

      tr("cbs_code") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CBSCODEHeaderText}")       '"CBS Code"
      tr("cbs_name") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CNBHeaderText}")       '"CBS NAME"
      tr("BudgetCost") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.BudgetCostHeaderText}")
      tr("ActualPOCost") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPOCostHeaderText}")
      tr("PODiff") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      tr("ActualGRCost") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualGRCostHeaderText}")
      tr("GRDiff") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")

      'm_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
      '                              {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 2, 2, 2), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 3, 2, 3)}) ' _

      Return tr

    End Function
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return RptProjectRevenueExpense.GetCBSMonitorSchemaTable() 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return RptProjectRevenueExpense.CreateCBSMonitorTableStyle() 'BOQ.CreateWBSMonitorTableStyle
    End Function
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Private dtcc As DataTable
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick

      'dtcc = Me.DataSet.Tables(0)

      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetCBSMonitorSchemaTable, New TreeGrid)
      ListInGrid(tm)


      lkg.TreeTableStyle = CreateCBSMonitorTableStyle()
      lkg.Model.Rows.Hidden(0) = True
      'lkg.Model.ColWidths(5) = 0
      lkg.TreeTable = tm.Treetable
      lkg.Rows.HeaderCount = 0
      lkg.Cols.HeaderCount = 2
      lkg.Rows.FrozenCount = 0
      lkg.Cols.FrozenCount = 0
      'm_grid.Model.Cols.Hidden(m_grid.ColCount) = True
      lkg.HilightGroupParentText = True
      lkg.RefreshHeights()
      lkg.Refresh()
    End Sub

    Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
      Me.m_treemanager = tm
      NoDigit = False
      If Me.Filters(1).Value = 1 Then
        NoDigit = True
      End If
      If Me.Filters(0).Value <> 0 Then
        Me.m_cc = New CostCenter(CInt(Me.Filters(0).Value))
      Else
        Me.m_cc = New CostCenter
      End If
      If Me.DataSet.Tables(3).Rows.Count > 0 Then
        Me.CBSNumber = CInt(Me.DataSet.Tables(3).Rows(0)(0))
      End If
      PopulateCBSMonitorListing(tm.Treetable)
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

      'Dim tr As Object = m_hashData(e.RowIndex)
      'If tr Is Nothing Then
      '  Return
      'End If

      'If TypeOf tr Is DataRow Then
      '  Dim dr As DataRow = CType(tr, DataRow)
      '  Dim drh As New DataRowHelper(dr)

      '  Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
      '  Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

      '  If docId > 0 AndAlso docType > 0 Then
      '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '    Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
      '    myEntityPanelService.OpenDetailPanel(en)
      '  End If
      'End If


      'If IsNumeric(m_grid(e.RowIndex, m_grid.ColCount).CellValue) Then
      '  Dim docId As Integer
      '  Dim docType As Integer
      '  docType = 6
      '  docId = CInt(m_grid(e.RowIndex, m_grid.ColCount).CellValue)
      '  If docId <> 0 Then
      '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '    Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
      '    myEntityPanelService.OpenDetailPanel(en)
      '  End If
      'End If
    End Sub
    Private dicdata As Dictionary(Of String, CBSAmount)
    Private Class CBSAmount
      Sub New(ByVal drh As DataRowHelper)
        CCID = drh.GetValue(Of Integer)("ccid")
        CBS = drh.GetValue(Of Integer)("cbs")
        Budget = drh.GetValue(Of Decimal)("Budget")
        PRActual = drh.GetValue(Of Decimal)("practual")
        POActual = drh.GetValue(Of Decimal)("poactual")
        GRActual = drh.GetValue(Of Decimal)("gractual")
        MWActual = drh.GetValue(Of Decimal)("mwactual")
      End Sub
      Public Property CCID As Integer
      Public Property CBS As Integer
      Public Property Budget As Decimal
      Public Property PRActual As Decimal
      Public Property POActual As Decimal
      Public Property GRActual As Decimal
      Public Property MWActual As Decimal
    End Class
    Private Function Parent(ByVal dt As TreeTable, ByVal value As String, Optional ByVal expand As RowExpandState = RowExpandState.Expanded) As TreeRow
      Dim tr As TreeRow = dt.Childs.Add
      tr("cbs_code") = value
      tr("header") = value
      tr.State = expand
      Return tr
    End Function
    Private Function Child(ByVal dr As TreeRow, ByVal codedesc As String, ByVal valuedese As Decimal, Optional ByVal expand As RowExpandState = RowExpandState.Expanded) As TreeRow
      Dim dgt As DigitConfig = DigitConfig.Price
      If NoDigit Then
        dgt = DigitConfig.Int
      End If

      Dim tr As TreeRow = dr.Childs.Add
      If codedesc.Length > 0 Then
        tr("cbs_code") = codedesc
        tr("budgetcost") = Configuration.FormatToString(valuedese, dgt)
      End If
      tr.State = expand
      Return tr
    End Function
    Private Function Blank(ByVal dt As TreeTable) As TreeRow
      Dim tr As TreeRow = dt.Childs.Add
      tr.State = RowExpandState.None
      Return tr
    End Function
    Public Sub PopulateCBSMonitorListing(ByVal dt As TreeTable)
      If Me.m_cc Is Nothing OrElse Not Me.m_cc.Originated Then
        Return
      End If

      Dim dgt As DigitConfig = DigitConfig.Price
      If NoDigit Then
        dgt = DigitConfig.Int
      End If

      Dim main As Decimal = 0
      Dim retention As Decimal = 0
      Dim advance As Decimal = 0
      Dim vo As Decimal = 0
      Dim penalty As Decimal = 0
      Dim other As Decimal = 0
      Dim bf As Decimal = 0
      Dim totalprice As Decimal = 0

      Dim deliver As Decimal = 0
      Dim bill As Decimal = 0
      Dim receievd As Decimal = 0
      Dim Recretention As Decimal = 0
      Dim Recadvance As Decimal = 0
      Dim remain As Decimal = 0

      If Me.DataSet.Tables(0).Rows.Count > 0 Then
        Dim drh As New DataRowHelper(Me.DataSet.Tables(0).Rows(0))
        main = drh.GetValue(Of Decimal)("main")
        retention = drh.GetValue(Of Decimal)("retention")
        advance = drh.GetValue(Of Decimal)("advance")
        vo = drh.GetValue(Of Decimal)("vo")
        penalty = drh.GetValue(Of Decimal)("penalty")
        other = drh.GetValue(Of Decimal)("other")
        bf = drh.GetValue(Of Decimal)("bf")

        totalprice = (main + vo + other) - (penalty + retention + advance)
      End If
      If Me.DataSet.Tables(1).Rows.Count > 0 Then
        Dim drh As New DataRowHelper(Me.DataSet.Tables(1).Rows(0))
        deliver = drh.GetValue(Of Decimal)("deliver")
        bill = drh.GetValue(Of Decimal)("bill")
        receievd = drh.GetValue(Of Decimal)("receivedtaxbase")
        'receievd = drh.GetValue(Of Decimal)("received")
        Recretention = drh.GetValue(Of Decimal)("Recretention")
        Recadvance = drh.GetValue(Of Decimal)("Recadvance")
        remain = drh.GetValue(Of Decimal)("remain")
      End If

      Dim tr As TreeRow = Parent(dt, "Price")
      Child(tr, "Main", main)
      Child(tr, "Retention", retention)
      Child(tr, "Advance", advance)
      Child(tr, "VO", vo)
      Child(tr, "Penalty", penalty)
      Child(tr, "Other", other)
      Child(tr, "BF", bf)
      Child(tr, "Total", totalprice)
      Blank(dt)

      tr = Parent(dt, "Received")
      Child(tr, "Deliver", deliver)
      Child(tr, "Bill", bill)
      Child(tr, "Received", receievd)
      Child(tr, "Retention", Recretention)
      Child(tr, "Advance", Recadvance)
      Child(tr, "Remain", remain)
      Blank(dt)

      Dim headertr As TreeRow = Me.CreateHeader(dt)
      headertr("header") = "Cost"
      headertr.State = RowExpandState.Expanded

      Dim cctr As TreeRow = headertr.Childs.Add
      cctr("cbs_code") = Me.m_cc.Code
      cctr("cbs_name") = Me.m_cc.Name
      cctr.State = RowExpandState.Expanded


      Dim Nodes As New Hashtable
      Dim myParent As String
      Dim parentNode As TreeRow = Nothing

      Dim sbudget As Decimal = 0
      Dim spoactual As Decimal = 0
      Dim sgractual As Decimal = 0

      Try
        'แบบไม่เลือก Option WBS 
        For Each cbsrow As DataRow In Me.DataSet.Tables(2).Rows
          Dim cbrh As New DataRowHelper(cbsrow)
          If cbrh.GetValue(Of Integer)("cbs_level") = 0 Then
            parentNode = cctr.Childs.Add 'dt.Childs.Add
          Else
            myParent = cbsrow("Parent")
            Try
              parentNode = Nodes(myParent).Childs.Add
            Catch ex As Exception

            End Try
          End If

          If Not parentNode Is Nothing Then
            Nodes(cbrh.GetValue(Of String)("cbs_path")) = parentNode

            'แสดงแต่ละ wbs
            tr = parentNode
            tr.Tag = cbsrow
            tr("cbs_code") = cbrh.GetValue(Of String)("cbs_code")
            tr("cbs_name") = cbrh.GetValue(Of String)("cbs_name")

            tr("BudgetCost") = Configuration.FormatToString(cbrh.GetValue(Of Decimal)("budgetamt"), dgt)
            tr("ActualPOCost") = Configuration.FormatToString(cbrh.GetValue(Of Decimal)("poactual"), dgt)
            tr("PODiff") = Configuration.FormatToString(cbrh.GetValue(Of Decimal)("budgetamt") - cbrh.GetValue(Of Decimal)("poactual"), dgt)

            tr("ActualGRCost") = Configuration.FormatToString(cbrh.GetValue(Of Decimal)("gractual"), dgt)
            tr("GRDiff") = Configuration.FormatToString(cbrh.GetValue(Of Decimal)("budgetamt") - cbrh.GetValue(Of Decimal)("gractual"), dgt)

            sbudget += cbrh.GetValue(Of Decimal)("budgetamt")
            spoactual += cbrh.GetValue(Of Decimal)("poactual")
            sgractual += cbrh.GetValue(Of Decimal)("gractual")

            tr.State = RowExpandState.Expanded
          End If

        Next

        Dim str As TreeRow = dt.Childs.Add
        str.State = RowExpandState.Expanded
        str("cbs_name") = "Total Cost"
        str("BudgetCost") = Configuration.FormatToString(sbudget, dgt)
        str("ActualPOCost") = Configuration.FormatToString(spoactual, dgt)
        str("PODiff") = Configuration.FormatToString(sbudget - spoactual, dgt)
        str("ActualGRCost") = Configuration.FormatToString(sgractual, dgt)
        str("GRDiff") = Configuration.FormatToString(sbudget - sgractual, dgt)

        Blank(dt)

        tr = Parent(dt, "Profit")
        Child(tr, "Contract - Budget", Configuration.FormatToString(totalprice - sbudget, dgt))
        Child(tr, "Received - PO Actual", Configuration.FormatToString(totalprice - spoactual, dgt))
        Child(tr, "Received - PO Actual", Configuration.FormatToString(receievd - spoactual, dgt))
        Child(tr, "Received - GR Actual", Configuration.FormatToString(totalprice - sgractual, dgt))
        Child(tr, "Received - GR Actual", Configuration.FormatToString(receievd - sgractual, dgt))
        Blank(dt)

        MargeHeaderRows()

        dt.AcceptChanges()
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

    End Sub
    Private Sub MargeHeaderRows()
      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                  {
                                   Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 2, 8, 2),
                                   Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(10, 2, 16, 2),
                                   Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(18, 2, 20 + Me.CBSNumber, 2),
                                   Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(22 + Me.CBSNumber, 2, 27 + Me.CBSNumber, 2)
                                  }) ' _
    End Sub
    'Private Function SumValueInDataTable(ByVal dr() As DataRow, ByVal field As String) As Decimal
    '    Dim ret As Decimal = 0
    '    For Each drtmp As DataRow In dr
    '        If Not drtmp.IsNull(field) Then
    '            ret += CDec(drtmp(field))
    '        End If
    '    Next
    '    Return ret
    'End Function
    'Public Overrides Sub RefreshDataSet()
    '  m_cc = New CostCenter
    '  'If TypeOf Me.Filters(0).Value Is CostCenter Then
    '  '  m_cc = CType(Me.Filters(0).Value, CostCenter)
    '  'End If
    '  ''เปลี่ยนค่าที่จะส่งไป StoredProcedure ที่ส่งเป็น Object เป็น ID
    '  'If Not Me.Filters(0).Value Is DBNull.Value Then
    '  '  Me.Filters(0).Value = m_cc.Id
    '  'End If
    '  'If Not Me.Filters(6).Value Is Nothing AndAlso TypeOf Me.Filters(6).Value Is Employee Then
    '  '  Me.Filters(6).Value = Me.Filters(6).Value.Id
    '  'End If
    '  '
    '  If Not m_cc Is Nothing AndAlso m_cc.Originated Then
    '    MyBase.RefreshDataSet()
    '  End If
    'End Sub
#End Region

#Region "Select Distinct From DataTable"
    'Public Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
    '    Dim lastValues() As Object
    '    Dim newTable As DataTable

    '    If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
    '        Throw New ArgumentNullException("FieldNames")
    '    End If

    '    lastValues = New Object(FieldNames.Length - 1) {}
    '    newTable = New DataTable

    '    For Each field As String In FieldNames
    '        newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
    '    Next

    '    For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
    '        If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
    '            newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

    '            setLastValues(lastValues, Row, FieldNames)
    '        End If
    '    Next

    '    Return newTable
    'End Function
    Private Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
      Dim areEqual As Boolean = True

      For i As Integer = 0 To fieldNames.Length - 1
        If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
          areEqual = False
          Exit For
        End If
      Next

      Return areEqual
    End Function
    Private Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
      For Each field As String In fieldNames
        newRow(field) = sourceRow(field)
      Next

      Return newRow
    End Function
    Private Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
      For i As Integer = 0 To fieldNames.Length - 1
        lastValues(i) = sourceRow(fieldNames(i))
      Next
    End Sub
#End Region

#Region "Shared"
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptProjectRevenueExpense"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptProjectRevenueExpense.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptProjectRevenueExpense.ListLabel}"
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
    Public Property NoDigit As Boolean
    Public Property CBSNumber As Integer
    'Public Property AdvanceFindCollection() As AdvanceFindCollection

#End Region

#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "RptWBSBudgetUsage"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptWBSBudgetUsage"
    End Function

    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCode"
      dpi.Value = m_cc.Code  'Me.Filters(0).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterName"
      dpi.Value = m_cc.Name 'Me.Filters(0).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      For rowindex As Integer = 2 To 8
        dpi = New DocPrintingItem
        dpi.Mapping = m_grid(rowindex, 3).CellValue
        dpi.Value = m_grid(rowindex, 5).CellValue
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      Next

      For rowindex As Integer = 11 To 16
        dpi = New DocPrintingItem
        dpi.Mapping = m_grid(rowindex, 3).CellValue
        dpi.Value = m_grid(rowindex, 5).CellValue
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      Next

      Dim c As Integer = 0
      Dim r As Integer = 0
      For rowindex As Integer = 19 To 19 + Me.CBSNumber
        r += 1
        For colindex As Integer = 2 To 9
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & c.ToString
          dpi.Value = m_grid(rowindex, colindex).CellValue
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = r
          dpiColl.Add(dpi)
          c += 1
        Next
      Next

      For rowindex As Integer = 22 + Me.CBSNumber To 25 + Me.CBSNumber
        dpi = New DocPrintingItem
        dpi.Mapping = m_grid(rowindex, 3).CellValue
        dpi.Value = m_grid(rowindex, 5).CellValue
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

