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
Imports System.Text.RegularExpressions
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptWBSMonitor3
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_cc As CostCenter
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
    Public Shared Function CreateWBSMonitorTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csCol1 As New TreeTextColumn
      csCol1.MappingName = "Col1"
      csCol1.HeaderText = "CODE"
      csCol1.NullText = ""
      csCol1.DataAlignment = HorizontalAlignment.Left
      csCol1.Width = 100
      csCol1.ReadOnly = True
      dst.GridColumnStyles.Add(csCol1)

      Dim csCol3 As New TreeTextColumn
      csCol3.MappingName = "Col2"
      csCol3.HeaderText = "DESCRIPTION"
      csCol3.NullText = ""
      csCol3.DataAlignment = HorizontalAlignment.Left
      csCol3.Width = 250
      csCol3.ReadOnly = True
      dst.GridColumnStyles.Add(csCol3)

      Dim arr As New ArrayList
      arr.Add("CONTRACT VALUE")
      arr.Add("CURRENT ESTIMATE")
      arr.Add("EXPENSE PO UP TO LAST PERIOD")
      arr.Add("EXPENSE PO THIS PERIOD")
      arr.Add("EXPENSE PO TOTAL")
      arr.Add("EXPENSE CONTRACT UP TO DATE")
      arr.Add("EXPENSE non PO UP TO DATE")
      arr.Add("EXPENSE LOA&LOI UP TO DATE")
      arr.Add("TOTAL EXPENSE")
      arr.Add("BUDGET")
      arr.Add("ESTIMATE TO Completetion")
      arr.Add("BUDGET REMAIN At Completion")
      arr.Add("% VARIANCE")

      For i As Integer = 3 To 15
        Dim cs As New TreeTextColumn
        cs.MappingName = "Col" & i.ToString
        cs.HeaderText = arr(i - 3)
        cs.NullText = ""
        cs.DataAlignment = HorizontalAlignment.Right
        cs.Format = "#,###.##"
        cs.Width = 150
        If i <> 13 Then
          cs.ReadOnly = True
        Else
          cs.ReadOnly = False
        End If
        dst.GridColumnStyles.Add(cs)
      Next

      Return dst
    End Function
    Public Shared Function GetWBSMonitorSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      For i As Integer = 1 To 15
        myDatatable.Columns.Add(New DataColumn("Col" & i.ToString, GetType(String)))
      Next
      Return myDatatable
    End Function
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return Me.GetWBSMonitorSchemaTable 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return Me.CreateWBSMonitorTableStyle 'BOQ.CreateWBSMonitorTableStyle
    End Function
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_updating = True
      m_grid = grid
      RemoveHandler m_grid.CurrentCellValidating, AddressOf tgItem_CurrentCellValidating
      AddHandler m_grid.CurrentCellValidating, AddressOf tgItem_CurrentCellValidating

      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() { _
      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 0, 1, 0) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 1, 1, 1) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 2, 1, 2) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 3, 1, 3) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 4, 1, 4) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 5, 1, 5) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 6, 1, 6) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 7, 1, 7) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 8, 1, 8) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 9, 1, 9) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 10, 1, 10) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 11, 1, 11) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 12, 1, 12) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 13, 1, 13) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 14, 1, 14) _
      , Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 15, 1, 15) _
      })

      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New Treemanager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Cols.FrozenCount = 2
      lkg.Rows.HeaderCount = 1
      lkg.Rows.FrozenCount = 1
      lkg.HilightGroupParentText = True
      lkg.Refresh()

      m_updating = False
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
      Me.m_treemanager = tm
      If m_cc Is Nothing OrElse Not m_cc.Originated  Then
        Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
        dt.Clear()
        tm.Treetable = dt
        Return
      End If
      If TypeOf Me.Filters(2).Value Is Date Then
        Dim nodigit As Boolean = False
        If Me.Filters(4).Name.ToLower = "nodigit" Then
          nodigit = CBool(Me.Filters(4).Value)
        End If
        PopulateWBSMonitorListing(tm.Treetable, CDate(Me.Filters(2).Value), nodigit)
      End If
    End Sub
    Public Sub PopulateWBSMonitorListing(ByVal dt As TreeTable, ByVal toDate As Date, Optional ByVal noDigit As Boolean = False)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      dt.Clear()

      'Dim arr As New ArrayList
      'arr.Add("")
      'arr.Add("")
      'arr.Add("VALUE")
      'arr.Add("ESTIMATE")
      'arr.Add("UP TO LAST PERIOD")
      'arr.Add("THIS PERIOD")
      'arr.Add("TOTAL")
      'arr.Add("UP TO DATE")
      'arr.Add("UP TO DATE")
      'arr.Add("UP TO DATE")
      'arr.Add("UP TO DATE")
      'arr.Add("REMAIN")
      'arr.Add("COMPLETION")
      'arr.Add("AT COMPLETION")
      'arr.Add("")

      'Dim headNode As TreeRow = dt.Childs.Add
      'For i As Integer = 0 To 14
      '  headNode(i) = arr(i)
      'Next
      Dim headNode As TreeRow = dt.Childs.Add

      Dim dt2 As DataTable = Me.DataSet.Tables(0)
      If dt2.Rows.Count <= 0 Then
        Return
      End If

      ' WBS ##################################################################################################
      '#######################################################################################################
      Dim Nodes As New Hashtable
      Dim myParent As String
      Dim parentNode As TreeRow = Nothing
      Dim myTempId As Integer = 0
      Dim tr As TreeRow
      Dim stage As String = ""
      Try
        'แบบไม่เลือก Option WBS 
        Dim reg As New Regex("\d+")
        Dim TExpensePO As Decimal = 0
        Dim TExpenseContract As Decimal = 0
        Dim TExpenseNonPO As Decimal = 0
        Dim TExpenseLOALOI As Decimal = 0

        Dim TCurrExpensePO As Decimal = 0
        Dim TCurrExpenseContract As Decimal = 0
        Dim TCurrExpenseNonPO As Decimal = 0
        Dim TCurrExpenseLOALOI As Decimal = 0

        Dim Tbudget2 As Decimal = 0
        Dim TG As Decimal = 0

        For Each wbsrow As DataRow In dt2.Rows
          If CInt(wbsrow("wbs_level")) = 4 Then
            parentNode = dt.Childs.Add
            If Not parentNode Is Nothing Then
              Nodes(CStr(wbsrow("wbs_code"))) = parentNode
              'แสดงแต่ละ wbs
              tr = parentNode
              Dim code As String = wbsrow("wbs_code")
              If reg.IsMatch(code) Then
                code = reg.Match(code).Value
              End If
              tr("Col1") = code
              tr("Col2") = wbsrow("wbs_name")

              Dim budget1 As Decimal = CDec(wbsrow("wbs_budget1"))
              Dim budget2 As Decimal = CDec(wbsrow("wbs_budget2"))
              Tbudget2 += budget2
              tr("Col3") = Configuration.FormatToString(budget1, dgt)
              tr("Col4") = Configuration.FormatToString(budget2, dgt)


              Dim ExpensePO As Decimal = CDec(wbsrow("ExpensePO"))
              TExpensePO += ExpensePO
              Dim ExpenseContract As Decimal = CDec(wbsrow("ExpenseContract"))
              TExpenseContract += ExpenseContract
              Dim ExpenseNonPO As Decimal = CDec(wbsrow("ExpenseNonPO"))
              TExpenseNonPO += ExpenseNonPO
              Dim ExpenseLOALOI As Decimal = CDec(wbsrow("ExpenseLOALOI"))
              TExpenseLOALOI += ExpenseLOALOI

              Dim CurrExpensePO As Decimal = CDec(wbsrow("CurrExpensePO"))
              TCurrExpensePO += CurrExpensePO
              Dim CurrExpenseContract As Decimal = CDec(wbsrow("CurrExpenseContract"))
              TCurrExpenseContract += CurrExpenseContract
              Dim CurrExpenseNonPO As Decimal = CDec(wbsrow("CurrExpenseNonPO"))
              TCurrExpenseNonPO += CurrExpenseNonPO
              Dim CurrExpenseLOALOI As Decimal = CDec(wbsrow("CurrExpenseLOALOI"))
              TCurrExpenseLOALOI += CurrExpenseLOALOI
              '-----------------------

              tr("Col5") = Configuration.FormatToString(ExpensePO, dgt)
              tr("Col6") = Configuration.FormatToString(CurrExpensePO, dgt)
              tr("Col7") = Configuration.FormatToString(ExpensePO + CurrExpensePO, dgt)

              tr("Col8") = Configuration.FormatToString(ExpenseContract + CurrExpenseContract, dgt)
              tr("Col9") = Configuration.FormatToString(ExpenseNonPO + CurrExpenseNonPO, dgt)
              tr("Col10") = Configuration.FormatToString(ExpenseLOALOI + CurrExpenseLOALOI, dgt)
              Dim E As Decimal = _
              (ExpensePO + CurrExpensePO) + _
              (ExpenseContract + CurrExpenseContract) + _
              (ExpenseNonPO + CurrExpenseNonPO) + _
              (ExpenseLOALOI + CurrExpenseLOALOI)

              tr("Col11") = Configuration.FormatToString(E, dgt)

              tr("Col12") = Configuration.FormatToString(budget2 - E, dgt)

              'Dim G As Decimal = 0
              'TG += G
              'tr("Col13") = Configuration.FormatToString(G, dgt)

              'tr("Col14") = Configuration.FormatToString(budget2 - E - G, dgt)

              'If budget2 <> 0 Then
              '  tr("Col15") = Configuration.FormatToString(((budget2 - E - G) / budget2) * 100, dgt)
              'End If

              stage = "2"
            End If
          End If
        Next
        tr = dt.Childs.Add

        tr("Col2") = "TOTAL"

        tr("Col4") = Configuration.FormatToString(Tbudget2, dgt)

        tr("Col5") = Configuration.FormatToString(TExpensePO, dgt)
        tr("Col6") = Configuration.FormatToString(TCurrExpensePO, dgt)
        tr("Col7") = Configuration.FormatToString(TExpensePO + TCurrExpensePO, dgt)

        tr("Col8") = Configuration.FormatToString(TExpenseContract + TCurrExpenseContract, dgt)
        tr("Col9") = Configuration.FormatToString(TExpenseNonPO + TCurrExpenseNonPO, dgt)
        tr("Col10") = Configuration.FormatToString(TExpenseLOALOI + TCurrExpenseLOALOI, dgt)
        Dim TE As Decimal = _
        (TExpensePO + TCurrExpensePO) + _
        (TExpenseContract + TCurrExpenseContract) + _
        (TExpenseNonPO + TCurrExpenseNonPO) + _
        (TExpenseLOALOI + TCurrExpenseLOALOI)
        tr("Col11") = Configuration.FormatToString(TE, dgt)

        tr("Col12") = Configuration.FormatToString(Tbudget2 - TE, dgt)

        'tr("Col13") = Configuration.FormatToString(TG, dgt)

        'tr("Col14") = Configuration.FormatToString(Tbudget2 - TE - TG, dgt)

        tr.State = RowExpandState.Expanded
        '#######################################################################################################

        If dt.Rows.Count > 0 Then
          dt.AcceptChanges()
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try

    End Sub
    Private m_system As String = ""
    Public Overrides Sub RefreshDataSet()
      m_cc = New CostCenter
      If TypeOf Me.Filters(0).Value Is CostCenter Then
        m_cc = CType(Me.Filters(0).Value, CostCenter)
      End If
      'เปลี่ยนค่าที่จะส่งไป StoredProcedure ที่ส่งเป็น Object เป็น ID
      If Not Me.Filters(0).Value Is DBNull.Value Then
        Me.Filters(0).Value = m_cc.Id
      End If
      If Not Me.Filters(5).Value Is Nothing AndAlso TypeOf Me.Filters(5).Value Is Employee Then
        Me.Filters(5).Value = Me.Filters(6).Value.Id
      End If
      If Not Me.Filters(1).Value Is DBNull.Value Then
        Dim code As String = Me.Filters(1).Value.ToString
        Dim reg As New Regex("\d+")
        If reg.IsMatch(code) Then
          code = reg.Match(code).Value
        End If
        Select Case code.Substring(0, 1)
          Case "1"
            code = "1000 - ELECTRICAL SYSTEM"
          Case "2"
            code = "2000 - PLUMBLING SYSTEM"
          Case "3"
            code = "3000 - HVAC SYSTEM"
          Case "4"
            code = "4000 - CIVIL SYSTEM"
          Case "9"
            code = "9000 - INDIRECT COST"
        End Select
        m_system = code
      End If
      MyBase.RefreshDataSet()
    End Sub
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As GridCellClickEventArgs)
      If e.RowIndex >= 2 OrElse e.ColIndex <> 13 Then
        Return
      End If

      For i As Integer = 2 To m_grid.RowCount - 1
        Dim _b As Decimal = 0
        SetVal(_b, m_grid(i, 4).CellValue)
        Dim _f As Decimal = 0
        SetVal(_f, m_grid(i, 12).CellValue)
        Dim _g As Decimal = Math.Max(_f, 0)
        m_grid(i, e.ColIndex).Text = Configuration.FormatToString(_f, DigitConfig.Price)

        Dim _h As Decimal = _f - _g

        m_grid(i, 14).CellValue = Configuration.FormatToString(_h, DigitConfig.Price)

        If _b <> 0 Then
          m_grid(i, 15).CellValue = Configuration.FormatToString(100 * (_h / _b), DigitConfig.Price)
        End If
      Next

      UpdateSum()

    End Sub
    Private m_updating As Boolean = False
    Private Sub tgItem_CurrentCellValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
      If m_updating Then
        Return
      End If
      Dim cc As GridCurrentCell = m_grid.CurrentCell
      If cc.RowIndex < 2 OrElse cc.RowIndex = m_grid.RowCount OrElse cc.ColIndex <> 13 Then
        e.Cancel = True
        Return
      End If
      m_updating = True
      Try        
        Dim _b As Decimal = 0
        SetVal(_b, m_grid(cc.RowIndex, 4).CellValue)
        Dim _f As Decimal = 0
        SetVal(_f, m_grid(cc.RowIndex, 12).CellValue)
        Dim _g As Decimal = CDec(TextParser.Evaluate(cc.Renderer.ControlText))
        m_grid(cc.RowIndex, cc.ColIndex).CellValue = Configuration.FormatToString(_g, DigitConfig.Price)
        cc.Renderer.ControlText = Configuration.FormatToString(_g, DigitConfig.Price)

        Dim _h As Decimal = _f - _g

        m_grid(cc.RowIndex, 14).CellValue = Configuration.FormatToString(_h, DigitConfig.Price)

        If _b <> 0 Then
          m_grid(cc.RowIndex, 15).CellValue = Configuration.FormatToString(100 * (_h / _b), DigitConfig.Price)
        End If

        UpdateSum()

      Catch ex As Exception
        e.Cancel = True
        MessageBox.Show(ex.ToString)
      End Try
      m_updating = False
    End Sub
    Private Sub UpdateSum()
      Dim _b As Decimal = 0
      Dim _f As Decimal = 0
      Dim _g As Decimal = 0
      Dim _h As Decimal = 0

      SumCol(13)

      SetVal(_b, m_grid(m_grid.RowCount, 4).CellValue)
      SetVal(_f, m_grid(m_grid.RowCount, 12).CellValue)
      SetVal(_g, m_grid(m_grid.RowCount, 13).CellValue)
      _h = _f - _g

      m_grid(m_grid.RowCount, 14).CellValue = Configuration.FormatToString(_h, DigitConfig.Price)

      If _b <> 0 Then
        m_grid(m_grid.RowCount, 15).CellValue = Configuration.FormatToString(100 * (_h / _b), DigitConfig.Price)
      End If
    End Sub
    Private Sub SetVal(ByRef var As Decimal, ByVal o As Object)
      If IsNumeric(o) Then
        var = CDec(o)
      End If
    End Sub
    Private Sub SumCol(ByVal col As Integer)
      Dim total As Decimal = 0
      For i As Integer = 2 To m_grid.RowCount - 1
        Dim val As Decimal = 0
        SetVal(val, m_grid(i, col).CellValue)
        total += val
      Next
      m_grid(m_grid.RowCount, col).CellValue = Configuration.FormatToString(total, DigitConfig.Price)
    End Sub
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
        Return "RptWBSMonitor3"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitor3.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor3"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor3"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitor3.ListLabel}"
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
      Return "RptWBSBudgetUsage"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptWBSBudgetUsage"
    End Function

    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      'dpi = New DocPrintingItem
      'dpi.Mapping = "CostCode"
      'dpi.Value = m_cc.Code  'Me.Filters(0).Value
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      Dim parent As CostCenter = m_cc
      If Not parent Is Nothing AndAlso parent.Originated Then
        dpi = New DocPrintingItem
        dpi.Mapping = "Project"
        dpi.Value = parent.Code & " - " & parent.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      dpi = New DocPrintingItem
      dpi.Mapping = "System"
      dpi.Value = m_system
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      If IsDate(Me.Filters(2).Value) Then
        dpi.Value = CDate(Me.Filters(2).Value).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Dim typeString As String = ""
      'Dim type As BOQ.WBSReportType
      'If TypeOf Me.Filters(3).Value Is BOQ.WBSReportType Then
      '  type = CType(Me.Filters(3).Value, BOQ.WBSReportType)
      'End If
      'Select Case type
      '  Case BOQ.WBSReportType.PR
      '    typeString = "ขอซื้อ"
      '  Case BOQ.WBSReportType.PO
      '    typeString = "สั่งซื้อ"
      '  Case BOQ.WBSReportType.GoodsReceipt
      '    typeString = "รับของ"
      '  Case BOQ.WBSReportType.MatWithdraw
      '    typeString = "เบิกของ"
      'End Select
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Type"
      'dpi.Value = typeString
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'dpi = New DocPrintingItem
      'dpi.Mapping = "Requester"
      'If Not IsDBNull(Me.Filters(6).Value) Then
      '  dpi.Value = New Employee(CInt(Me.Filters(6).Value)).Name
      'End If
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      Dim i As Integer = 0
      For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
        If i > 0 Then
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = i
          dpi.DataType = "System.Integer"
          dpi.Row = i
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          For j As Integer = 0 To Me.Treemanager.Treetable.Columns.Count - 1
            dpi = New DocPrintingItem
            dpi.Mapping = "col" & j + 1
            dpi.Value = itemRow(Me.Treemanager.Treetable.Columns(j))
            dpi.DataType = "System.String"
            dpi.Row = i
            dpi.Table = "Item"
            dpiColl.Add(dpi)
            If i = Me.Treemanager.Treetable.Rows.Count - 2 Then
              dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            End If
          Next
        End If
        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

