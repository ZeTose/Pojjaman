Imports Telerik.WinControls.UI
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.BusinessLogic

Public Class GLListForm

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshItems()
    End Sub
    Private Sub GetColumns()

        Dim colNum As Integer = 0
        Dim gcLineNumber As New GridViewDecimalColumn("Linenumber")
        gcLineNumber.HeaderText = "No."
        gcLineNumber.Width = 45
        gcLineNumber.ReadOnly = True
        gcLineNumber.DecimalPlaces = 0
        gcLineNumber.TextAlignment = ContentAlignment.MiddleCenter
        Me.RadGridView1.Columns.Add(gcLineNumber)
        colNum += 1

        Dim gcMapping As New GridViewTextBoxColumn("Mapping")
        gcMapping.HeaderText = "Mapping"
        gcMapping.Width = 100
        gcMapping.ReadOnly = True
        Me.RadGridView1.Columns.Add(gcMapping)
        colNum += 1

        Dim gcCC As New GridViewTextBoxColumn("CostCenter")
        gcCC.HeaderText = "Cost Center"
        gcCC.Width = 200
        gcCC.ReadOnly = True
        Me.RadGridView1.Columns.Add(gcCC)
        colNum += 1

        Dim gcDebit As New GridViewTextBoxColumn("Debit")
        gcDebit.HeaderText = "Debit"
        gcDebit.Width = 200
        gcDebit.ReadOnly = True
        gcDebit.TextAlignment = ContentAlignment.MiddleRight
        Me.RadGridView1.Columns.Add(gcDebit)
        colNum += 1

        Dim gcCredit As New GridViewTextBoxColumn("Credit")
        gcCredit.HeaderText = "Credit"
        gcCredit.Width = 200
        gcCredit.ReadOnly = True
        gcCredit.TextAlignment = ContentAlignment.MiddleRight
        Me.RadGridView1.Columns.Add(gcCredit)
        colNum += 1

        Dim gcNote As New GridViewTextBoxColumn("Note")
        gcNote.HeaderText = "Note"
        gcNote.Width = 200
        gcNote.ReadOnly = True
        Me.RadGridView1.Columns.Add(gcNote)
        colNum += 1
    End Sub
    Private Sub RefreshItems()
        Me.RadGridView1.Rows.Clear()
        Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
        If TypeOf window.ActiveViewContent Is Longkong.Pojjaman.Gui.Panels.ISimpleEntityPanel Then
            If TypeOf CType(window.ActiveViewContent, ISimpleEntityPanel).Entity Is IGLAble Then
                Dim glable As IGLAble = CType(CType(window.ActiveViewContent, ISimpleEntityPanel).Entity, IGLAble)
                Dim i As Integer = 1
                For Each item As JournalEntryItem In glable.GetJournalEntries
                    Dim gridRow As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
                    gridRow.Cells("Linenumber").Value = i

                    gridRow.Cells("Mapping").Value = item.Mapping
                    gridRow.Cells("CostCenter").Value = item.CostCenter.Code & ":" & item.CostCenter.Name
                    If item.IsDebit Then
                        gridRow.Cells("Debit").Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
                    Else
                        gridRow.Cells("Credit").Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
                    End If
                    gridRow.Cells("Note").Value = item.Note
                    gridRow.Tag = item
                    i += 1
                Next
            End If
        End If
    End Sub

    Private Sub GLListForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadGridView1.EnableGrouping = False
        RadGridView1.EnableSorting = False
        GetColumns()
        Me.RadGridView1.MasterGridViewTemplate.AllowAddNewRow = False
        RefreshItems()
    End Sub
End Class