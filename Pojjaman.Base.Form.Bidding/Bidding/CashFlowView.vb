Imports Telerik.WinControls.UI
Imports Longkong.Core.Services
Imports System.Collections.Generic
Imports Longkong.Pojjaman.BusinessLogic

Public Class CashFlowView

  Private Sub CashFlowView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RadGridView1.EnableGrouping = False
    RadGridView1.EnableSorting = False
    RadGridView1.Enabled = False

    GetColumns()
    Me.RadGridView1.MasterGridViewTemplate.AllowAddNewRow = False
    UpdateWeeks()
    RefreshItems()
  End Sub
  Public Sub PopulateRow(ByVal c As CBS, ByVal tr As GridViewDataRowInfo)
    If tr Is Nothing Then
      Return
    End If

    If c.IdOrNull.HasValue Then
      tr.Cells("CBS").Value = c.Code
    Else
      tr.Cells("CBS").Value = ""
    End If

    tr.Cells("Name").Value = c.Name

    For Each p As CBSValue In c.Plan(Budget.Id)
      For Each wk As Week In m_weekList.Keys
        If wk.Equals(p.Week) Then
          tr.Cells(m_weekList(wk).Index).Value = Configuration.FormatToString(p.Amount, DigitConfig.UnitPrice)
        End If
      Next
    Next

    'tr.Cells("Amount").Value = Configuration.FormatToString(c.Amount, DigitConfig.Price)
    tr.Cells("Planned").Value = Configuration.FormatToString(c.GetPlannedValue(Budget.Id), DigitConfig.Price)

    tr.Tag = c

  End Sub
  Private Sub RefreshItems()
    Me.RadGridView1.Rows.Clear()
    For Each w As CBS In CBS.CBSTree
      Dim row As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
      PopulateRow(w, row)
    Next
    Dim i As Integer = 1
    For Each row As GridViewDataRowInfo In Me.RadGridView1.Rows
      row.Cells("Linenumber").Value = i
      i += 1
    Next
  End Sub
  Dim viewDef As ColumnGroupsViewDefinition
  Private Sub GetColumns()

    viewDef = New ColumnGroupsViewDefinition
    Dim colNum As Integer = 0
    Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    Dim gcLineNumber As New GridViewDecimalColumn("Linenumber")
    gcLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.LineNumberHeaderText}")
    gcLineNumber.Width = 45
    gcLineNumber.ReadOnly = True
    gcLineNumber.DecimalPlaces = 0
    gcLineNumber.TextAlignment = ContentAlignment.MiddleCenter
    Me.RadGridView1.Columns.Add(gcLineNumber)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcLineNumber)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcCBS As New GridViewTextBoxColumn("CBS")
    gcCBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
    gcCBS.Width = 60
    Me.RadGridView1.Columns.Add(gcCBS)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcCBS)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcName As New GridViewTextBoxColumn("Name")
    gcName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
    gcName.Width = 150
    Me.RadGridView1.Columns.Add(gcName)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcName)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim csAmount As New GridViewTextBoxColumn("Amount")
    csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.AmountHeaderText}")
    csAmount.Width = 80
    csAmount.TextAlignment = ContentAlignment.MiddleRight
    Me.RadGridView1.Columns.Add(csAmount)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csAmount)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim csPlanned As New GridViewTextBoxColumn("Planned")
    csPlanned.HeaderText = "ประมาณการ" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
    csPlanned.ReadOnly = True
    csPlanned.Width = 80
    csPlanned.TextAlignment = ContentAlignment.MiddleRight
    Me.RadGridView1.Columns.Add(csPlanned)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csPlanned)
    viewDef.ColumnGroups(colNum).IsPinned = True

  End Sub
  Private m_colList As List(Of GridViewTextBoxColumn)
  Private m_colGroupList As List(Of GridViewColumnGroup)
  Private m_weekList As Dictionary(Of Week, GridViewTextBoxColumn)
  Public Budget As Budget
  Private Sub UpdateWeeks()
    If Not m_colGroupList Is Nothing Then
      For Each col As GridViewColumnGroup In m_colGroupList
        viewDef.ColumnGroups.Remove(col)
      Next
    End If
    If Not m_colList Is Nothing Then
      For Each col As GridViewTextBoxColumn In m_colList
        RadGridView1.Columns.Remove(col)
      Next
    End If
    m_colList = New List(Of GridViewTextBoxColumn)
    m_colGroupList = New List(Of GridViewColumnGroup)
    m_weekList = New Dictionary(Of Week, GridViewTextBoxColumn)
    Dim ws As List(Of Week) = Budget.GetWeeks
    Dim i As Integer = 0
    Dim dateList As New List(Of String)
    dateList.Add("1-7")
    dateList.Add("8-14")
    dateList.Add("15-21")
    dateList.Add("22-31")

    For Each w As Week In ws
      Dim colGroup As GridViewColumnGroup
      If w.Number = 1 Then
        Dim gc As New GridViewTextBoxColumn("Col" & i.ToString)
        gc.HeaderText = ""
        gc.Width = 10
        m_colList.Add(gc)
        RadGridView1.Columns.Add(gc)

        colGroup = New GridViewColumnGroup(MonthName(w.Month) & " " & w.Year)
        m_colGroupList.Add(colGroup)
        viewDef.ColumnGroups.Add(colGroup)
        colGroup.Rows.Add(New GridViewColumnGroupRow())
        i += 1
      End If

      Dim col As New GridViewTextBoxColumn("Col" & i.ToString)
      col.HeaderText = dateList(w.Number - 1)
      col.TextAlignment = ContentAlignment.MiddleRight
      col.Width = 90
      RadGridView1.Columns.Add(col)
      colGroup.Rows(0).Columns.Add(col)
      m_weekList(w) = col

      i += 1
    Next
    Me.RadGridView1.ViewDefinition = viewDef
  End Sub
End Class