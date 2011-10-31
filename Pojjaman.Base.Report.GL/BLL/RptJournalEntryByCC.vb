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
Imports Telerik.WinControls.UI
Imports System.Collections.Generic
Imports Telerik.WinControls

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptJournalEntryByCC
    Inherits Report
    Implements IUseTelerikGridReportStyle 'IUseTelerikGridReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private columnGroupsView As ColumnGroupsViewDefinition
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
    Dim viewDef As ColumnGroupsViewDefinition
    Private m_grid As RadGridView

    Dim template As GridViewTemplate
    Private rowInfo As GridViewDataRowInfo
    Private Property radRadioHierarchyFromDataSet As Object

    Private Property Theme As Object

    Public Overrides Sub ListInNewGrid(ByVal grid As RadGridView)
      'm_grid = New RadGridView
      m_grid = grid
      m_grid.GridElement.BeginUpdate()
      m_grid.MasterGridViewTemplate.ChildGridViewTemplates.Clear()
      m_grid.MasterGridViewTemplate.AllowAddNewRow = False
      m_grid.MasterGridViewTemplate.AllowDeleteRow = False
      m_grid.MasterGridViewTemplate.AllowCellContextMenu = False

      'm_grid.MasterGridViewTemplate.AllowColumnReorder = False

      template = New GridViewTemplate
      CreateHeader()
      'AddHandler m_grid.GridElement.HScrollBar.ValueChanged ,
      Me.SetFrozenColumn(m_grid, 2)

      'CreateDocHeader()
      Setdatasource()
      ''PopulateData()
      'PopulateMasterData()
      'PopulateDocData()
      'SetRelation()
      ExpandAllRows(m_grid, True)
      'SetColumnProperties()
      m_grid.GridElement.EndUpdate()
    End Sub
    Private Sub SetFrozenColumn(ByVal grid As RadGridView, ByVal ColumnIndex As Integer)
      For i As Integer = 0 To ColumnIndex
        grid.Columns(i).IsPinned = True
      Next
    End Sub
    'Private Shared Sub FreezeBand(ByVal band As DataGridViewBand)

    '  band.Frozen = True
    '  Dim style As DataGridViewCellStyle = New DataGridViewCellStyle()
    '  style.BackColor = Color.WhiteSmoke
    '  band.DefaultCellStyle = style

    'End Sub

    Private Sub SetTheme()
      m_grid.ThemeName = CStr(Theme)
      'Me.radGroupHierarchyOptions.ThemeName = Theme

    End Sub

    Private Sub Configure(ByVal template As GridViewTemplate, ByVal enableFiltering As Boolean)
      template.EnableFiltering = enableFiltering

      For i As Integer = 0 To template.ChildGridViewTemplates.Count - 1
        Configure(template.ChildGridViewTemplates(i), enableFiltering)
      Next i
    End Sub

    Private Sub ResetGridView()
      m_grid.GridElement.RowHeight = 20
      m_grid.AutoGenerateHierarchy = False

      m_grid.CurrentRow = Nothing
      m_grid.Relations.Clear()
      m_grid.MasterGridViewTemplate.ChildGridViewTemplates.Clear()
      m_grid.MasterGridViewTemplate.Columns.Clear()
      m_grid.DataSource = Nothing

      m_grid.MasterGridViewTemplate.AllowAddNewRow = False
      m_grid.MasterGridViewTemplate.AllowEditRow = False
      m_grid.MasterGridViewTemplate.AllowDeleteRow = False
      m_grid.MasterGridViewTemplate.ShowFilteringRow = False
    End Sub

    Private Sub CreateHeader()
      'arr(0) = New Filter("DocDateStart", ValidCodeOrDBNullText(Me.dtpDocDateStart.Text))
      'arr(1) = New Filter("DocDateEnd", ValidCodeOrDBNullText(Me.dtpDocDateEnd.Text))
      'arr(2) = New Filter("AcctCodeStart", ValidCodeOrDBNullText(Me.cmbAccountCodeStart.Text))
      'arr(3) = New Filter("AcctCodeEnd", ValidCodeOrDBNullText(Me.cmbAccountCodeEnd.Text))
      'arr(4) = New Filter("AcctBookCodeStart", ValidCodeOrDBNullText(Me.cmbAccountBookCodeStart.Text))
      'arr(5) = New Filter("AcctBookCodeEnd", ValidCodeOrDBNullText(Me.cmbAccountBookCodeEnd.Text))
      'arr(6) = New Filter("CCCodeStart", ValidCodeOrDBNullText(Me.cmbCostCenterCodeStart.Text))
      'arr(7) = New Filter("CCCodeEnd", ValidCodeOrDBNullText(Me.cmbCostCenterCodeEnd.Text))


      Dim ccStartFilter As String = ""
      If Not Me.Filters(6).Value.Equals(DBNull.Value) Then
        ccStartFilter = CType(Me.Filters(6).Value, String)
      End If
      Dim ccEndFilter As String = ""
      If Not Me.Filters(6).Value.Equals(DBNull.Value) Then
        ccEndFilter = CType(Me.Filters(7).Value, String)
      End If

      m_grid.Columns.Clear()
      viewDef = New ColumnGroupsViewDefinition

      'Dim headerTextList As New List(Of String)
      'Dim FieldNameList As New List(Of String)
      ''headerTextList.Add("")
      ''FieldNameList.Add("acct_parid")
      'headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountCode}")) '"รหัส"
      'FieldNameList.Add("acct_code")
      'headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentMovement.AccountName}")) '"ชื่อ"
      'FieldNameList.Add("acct_name")

      Dim gridColumn As New GridViewTextBoxColumn("lineNumber")
      gridColumn.Width = 35
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = "#"
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("acct_code")
      gridColumn.Width = 100
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountCode}")
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)

      gridColumn = New GridViewTextBoxColumn("acct_name")
      gridColumn.Width = 190
      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
      gridColumn.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountName}")
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)

      Dim dt As DataTable = CostCenter.GetCostCenterSet
      Dim costCenterDataSourceStart As DataTable = SetDataSourceFiltered(dt, "cc_code", ccStartFilter, ccEndFilter)

      Dim ccId As Integer = 0
      Dim ccCode As String = ""
      Dim colIndex As Integer = 1
      For Each row As DataRow In costCenterDataSourceStart.Rows
        Dim drh As New DataRowHelper(row)
        ccId = drh.GetValue(Of Integer)("cc_id")
        ccCode = drh.GetValue(Of String)("cc_code")

        'gridColumn = New GridViewTextBoxColumn(ccCode)
        'gridColumn.Width = 100
        'gridColumn.TextAlignment = ContentAlignment.MiddleRight
        'gridColumn.HeaderText = ccCode & " [" & colIndex.ToString & "]"
        'gridColumn.FieldName = ccId.ToString
        'gridColumn.FormatString = "{0:#,#}"
        'gridColumn.ExcelExportFormatString = ""
        'gridColumn.ReadOnly = True

        Dim gridDecColumn As New GridViewDecimalColumn(ccCode)
        gridDecColumn.Width = 100
        gridDecColumn.TextAlignment = ContentAlignment.MiddleRight
        gridDecColumn.HeaderText = ccCode & " [" & colIndex.ToString & "]"
        gridDecColumn.FieldName = ccId.ToString
        gridDecColumn.ReadOnly = True

        m_grid.Columns.Add(gridDecColumn)
        'm_grid.Columns.Add(gridColumn)

        colIndex += 1
      Next

      gridColumn = New GridViewTextBoxColumn("rowstotal")
      gridColumn.Width = 150
      gridColumn.TextAlignment = ContentAlignment.MiddleRight
      gridColumn.HeaderText = "รวม" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.AccountName}")
      gridColumn.ReadOnly = True
      m_grid.Columns.Add(gridColumn)
      colIndex += 1

    End Sub
    Private Function SetDataSourceFiltered(ByVal dt As DataTable, ByVal columnSource As String, ByVal codestart As String, ByVal codeend As String) As DataTable
      Dim newdt As New DataTable
      Dim filterString As String = ""

      If codestart.Length = 0 AndAlso codeend.Length = 0 Then
        Return dt
      ElseIf codestart.Length > 0 AndAlso codeend.Length = 0 Then
        filterString = columnSource & " >= '" & codestart & "'"
      ElseIf codestart.Length = 0 AndAlso codeend.Length < 0 Then
        filterString = columnSource & " <= '" & codeend & "'"
      Else
        filterString = columnSource & " >= '" & codestart & "' and " & columnSource & " <='" & codeend & "'"
      End If

      For Each dcol As DataColumn In dt.Columns
        newdt.Columns.Add(New DataColumn(dcol.ColumnName))
      Next

      For Each drow As DataRow In dt.Select(filterString)
        Dim newDrow As DataRow = newdt.NewRow

        For Each dcol As DataColumn In dt.Columns
          newDrow(dcol.ColumnName) = drow(dcol.ColumnName)
        Next
        newdt.Rows.Add(newDrow)
      Next

      Return newdt
    End Function
    'Private Sub CreateDocHeader()
    '  Dim costCenterDataSourceStart As DataTable = CostCenter.GetCostCenterSet

    '  viewDef = New ColumnGroupsViewDefinition

    '  Dim headerTextList As New List(Of String)
    '  Dim FieldNameList As New List(Of String)
    '  headerTextList.Add("")
    '  FieldNameList.Add("acct_id")
    '  headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCC.AccountCode}")) '"รหัส"
    '  FieldNameList.Add("acct_code")
    '  headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCC.AccountName}")) '"ชื่อ"
    '  FieldNameList.Add("acct_name")
    '  'headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCC.CC}")) '"CCเจ้าของ"
    '  'FieldNameList.Add("Costcenter")
    '  'headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCC.Buycost}")) '"ราคาซื้อ"
    '  'FieldNameList.Add("eqi_buycost")
    '  'headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCC.ReturnAmount}")) '"ค่าเช่าภายใน"
    '  'FieldNameList.Add("ReturnAmount")
    '  ''headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentMovement.Status}")) '"สถานะ"
    '  ''FieldNameList.Add(" ")
    '  'headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCC.MaintenanceAmount}")) '"ซ่อมบำรุง"
    '  'FieldNameList.Add("MaintenanceAmount")
    '  ''headerTextList.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentMovement.Status}")) '"สถานะ"
    '  ''FieldNameList.Add(" ")

    '  template.Columns.Clear()
    '  For i As Integer = 0 To 2
    '    Dim gridColumn As New GridViewTextBoxColumn("Col" & i.ToString)
    '    If i = 0 Then
    '      gridColumn.Width = 0
    '    Else
    '      gridColumn.Width = 100
    '    End If
    '    If i = 6 Then
    '      gridColumn.TextAlignment = ContentAlignment.MiddleRight
    '    Else
    '      gridColumn.TextAlignment = ContentAlignment.MiddleLeft
    '    End If
    '    gridColumn.HeaderText = headerTextList(i)
    '    gridColumn.FieldName = FieldNameList(i)
    '    gridColumn.ReadOnly = True
    '    template.Columns.Add(gridColumn)
    '  Next

    'End Sub
    Private Sub Setdatasource()
      Dim dt As DataTable = SetDataSet(DataSet.Tables(0))

      'Dim dtchilds As DataTable = DataSet.Tables(0)

      m_grid.DataSource = dt
      'template.DataSource = dtchilds
      'template.AllowDeleteRow = True
      'template.AllowAddNewRow = False

      'm_grid.MasterGridViewTemplate.ChildGridViewTemplates.Add(template)

    End Sub

    Public Function SetDataSet(ByVal sourceData As DataTable) As DataTable
      Dim accountCodeStartFilter As String = ""
      If Not Me.Filters(2).Value.Equals(DBNull.Value) Then
        accountCodeStartFilter = CType(Me.Filters(2).Value, String)
      End If
      Dim accountCodeEndFilter As String = ""
      If Not Me.Filters(3).Value.Equals(DBNull.Value) Then
        accountCodeEndFilter = CType(Me.Filters(3).Value, String)
      End If

      Dim dt As DataTable = Account.GetAccountSet
      Dim acctDataSourceStart As DataTable = SetDataSourceFiltered(dt, "acct_code", accountCodeStartFilter, accountCodeEndFilter)

      Dim costCenterDataSourceStart As DataTable = CostCenter.GetCostCenterSet

      Dim newDt As New DataTable
      Dim lineNumber As Integer = 1

      newDt.Columns.Add(New DataColumn("LineNumber"))

      For Each col As DataColumn In acctDataSourceStart.Columns
        newDt.Columns.Add(New DataColumn(col.ColumnName))
      Next
      For Each row As DataRow In costCenterDataSourceStart.Rows
        Dim ccrow As New DataRowHelper(row)
        newDt.Columns.Add(New DataColumn(ccrow.GetValue(Of String)("cc_id")))
      Next
      newDt.Columns.Add(New DataColumn("rowstotal"))

      Dim total As Decimal = 0
      For Each acctrow As DataRow In acctDataSourceStart.Rows
        Dim accth As New DataRowHelper(acctrow)

        Dim dr As DataRow = newDt.NewRow
        dr("LineNumber") = lineNumber

        For Each col As DataColumn In acctDataSourceStart.Columns
          dr(col.ColumnName) = acctrow(col.ColumnName)
        Next

        '--Summary ผลรวมในแนวตั้ง-- ===========================
        Dim rowtotal As Decimal = 0
        For Each ccrow As DataRow In costCenterDataSourceStart.Rows
          Dim cch As New DataRowHelper(ccrow)
          Dim ccid As String = cch.GetValue(Of String)("cc_id")
          Dim drf As DataRow() = sourceData.Select("gli_acct=" & accth.GetValue(Of String)("acct_id") & " and gli_cc=" & ccid)
          If drf.Length > 0 Then
            dr(ccid) = Configuration.FormatToString(CDec(drf(0)("amount")), DigitConfig.Price)
            'dr(ccid) = CDbl(drf(0)("amount"))
            rowtotal += CDec(drf(0)("amount"))
            total += CDec(drf(0)("amount"))
          End If
        Next
        dr("rowstotal") = Configuration.FormatToString(rowtotal, DigitConfig.Price)
        '--Summary ผลรวมในแนวตั้ง-- ===========================

        newDt.Rows.Add(dr)
        lineNumber += 1
      Next

      '--Summary ผลรวมในแนวนอน-- ===========================
      Dim drt As DataRow = newDt.NewRow
      drt("acct_name") = "รวม"
      For Each ccrow As DataRow In costCenterDataSourceStart.Rows
        Dim cch As New DataRowHelper(ccrow)
        Dim ccid As String = cch.GetValue(Of String)("cc_id")
        Trace.WriteLine(ccid)
        Dim coltotal As Decimal = 0
        For Each drow As DataRow In sourceData.Select("gli_cc=" & ccid)
          Dim drh As New DataRowHelper(drow)
          coltotal += drh.GetValue(Of Decimal)("amount", 0)
        Next
        drt(ccid) = Configuration.FormatToString(coltotal, DigitConfig.Price)
      Next
      drt("rowstotal") = Configuration.FormatToString(total, DigitConfig.Price)
      newDt.Rows.Add(drt)
      '--Summary ผลรวมในแนวนอน-- ===========================

      Return newDt
    End Function

    Private Sub PopulateMasterData()
      Dim dt As DataTable = DataSet.Tables(0)
      For Each row As DataRow In dt.Rows
        Dim deh As New DataRowHelper(row)
        Dim currentGridRow As GridViewDataRowInfo = m_grid.Rows.AddNew()
        currentGridRow.Cells(0).Value = deh.GetValue(Of Integer)("")
        currentGridRow.Cells(1).Value = deh.GetValue(Of String)("eq_code")
        currentGridRow.Cells(2).Value = deh.GetValue(Of String)("eq_name")
      Next

    End Sub
    Private Sub PopulateDocData()
      Dim dt As DataTable = DataSet.Tables(1)

      For Each row As DataRow In dt.Rows
        Dim deh As New DataRowHelper(row)
        Dim currentGridRow As GridViewDataRowInfo = template.Rows.AddNew()
        currentGridRow.Cells(0).Value = deh.GetValue(Of String)("")
        currentGridRow.Cells(1).Value = deh.GetValue(Of String)("eqi_code")
        currentGridRow.Cells(2).Value = deh.GetValue(Of String)("eqi_name")
        currentGridRow.Cells(3).Value = deh.GetValue(Of String)("Costcenter")
        currentGridRow.Cells(4).Value = Configuration.FormatToString(deh.GetValue(Of Decimal)("eqi_buycost"), DigitConfig.Price)
        currentGridRow.Cells(5).Value = Configuration.FormatToString(deh.GetValue(Of Decimal)("ReturnAmount"), DigitConfig.Price)
        'currentGridRow.colls(6).value = Configuration.FormatToString(deh.GetValue(Of Decimal)(" "), DigitConfig.Price)
        currentGridRow.Cells(6).Value = Configuration.FormatToString(deh.GetValue(Of Decimal)("MaintenanceAmount"), DigitConfig.Price)
        'currentGridRow.colls(8).value = Configuration.FormatToString(deh.GetValue(Of Decimal)(" "), DigitConfig.Price)
      Next

      m_grid.MasterGridViewTemplate.ChildGridViewTemplates.Add(template)

    End Sub
    Private Sub SetRelation()
      Dim relation As GridViewRelation = New GridViewRelation(m_grid.MasterGridViewTemplate)
      relation.ChildTemplate = template
      relation.RelationName = "leve0"
      relation.ParentColumnNames.Add("acct_parid")
      relation.ChildColumnNames.Add("acct_id")
      m_grid.Relations.Add(relation)
    End Sub
    Private Sub ExpandAllRows(ByVal grid As RadGridView, ByVal expand As Boolean)
      grid.GridElement.BeginUpdate()
      For Each row As GridViewRowInfo In grid.Rows
        row.IsExpanded = expand
      Next
      grid.GridElement.EndUpdate()
    End Sub

#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptJournalEntryByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCC.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptJournalEntryByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptJournalEntryByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCC.ListLabel}"
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
      Return "RptJournalEntryByCC"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptJournalEntryByCC"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim cRow As Integer = 0
      For rowIndex As Integer = 0 To m_grid.RowCount - 1
        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid.Rows(rowIndex).Cells(1).Value
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = m_grid.Rows(rowIndex).Cells(2).Value
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col2"
        'dpi.Value = m_grid.Rows(rowIndex).Cells(3).Value
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col3"
        'dpi.Value = m_grid.Rows(rowIndex).Cells(4).Value
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col4"
        'dpi.Value = m_grid.Rows(rowIndex).Cells(5).Value
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'Dim childRowInfo As GridViewRowInfo = m_grid.Rows(rowIndex)
        'Dim childRows As GridViewRowInfo() = childRowInfo.ViewTemplate.ChildGridViewTemplates(0).GetChildRows(childRowInfo)

        'For i As Integer = 0 To childRows.Length - 1

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col0"
        '  dpi.Value = childRows(i).Cells(1).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col1"
        '  dpi.Value = childRows(i).Cells(2).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col2"
        '  dpi.Value = childRows(i).Cells(3).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col3"
        '  dpi.Value = childRows(i).Cells(4).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col4"
        '  dpi.Value = childRows(i).Cells(5).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "col5"
        '  dpi.Value = childRows(i).Cells(6).Value
        '  dpi.DataType = "System.String"
        '  dpi.Row = cRow + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        n += 1
        'cRow += 1
      Next
      ' Next
      Return dpiColl
    End Function
#End Region
    Private Function radGroupHierarchyOptions() As Object
      Throw New NotImplementedException
    End Function



  End Class
End Namespace

