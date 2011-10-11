Imports Telerik.WinControls.UI
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.BusinessLogic

Public Class GLAtomListForm2
  Public je As JournalEntry
  
  Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
    RefreshItems()
  End Sub
  Private Sub GetColumns()

    Dim colNum As Integer = 0
    Dim gcLineNumber As New GridViewDecimalColumn("Linenumber")
    gcLineNumber.HeaderText = "No."
    gcLineNumber.Width = 15
    gcLineNumber.ReadOnly = True
    gcLineNumber.DecimalPlaces = 0
    gcLineNumber.TextAlignment = ContentAlignment.MiddleCenter
    Me.RadGridView1.Columns.Add(gcLineNumber)
    colNum += 1

    Dim gcMapping As New GridViewTextBoxColumn("Mapping")
    gcMapping.HeaderText = "Mapping"
    gcMapping.Width = 40
    gcMapping.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcMapping)
    colNum += 1

    Dim gcACCT As New GridViewTextBoxColumn("Account")
    gcACCT.HeaderText = "Account"
    gcACCT.Width = 70
    gcACCT.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcACCT)
    colNum += 1

    Dim gcDebit As New GridViewTextBoxColumn("Debit")
    gcDebit.HeaderText = "Debit"
    gcDebit.Width = 80
    gcDebit.ReadOnly = True
    gcDebit.TextAlignment = ContentAlignment.MiddleRight
    Me.RadGridView1.Columns.Add(gcDebit)
    colNum += 1

    Dim gcCredit As New GridViewTextBoxColumn("Credit")
    gcCredit.HeaderText = "Credit"
    gcCredit.Width = 80
    gcCredit.ReadOnly = True
    gcCredit.TextAlignment = ContentAlignment.MiddleRight
    Me.RadGridView1.Columns.Add(gcCredit)
    colNum += 1

    Dim gcCC As New GridViewTextBoxColumn("CostCenter")
    gcCC.HeaderText = "Cost Center"
    gcCC.Width = 70
    gcCC.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcCC)
    colNum += 1

    Dim gcNote As New GridViewTextBoxColumn("Note")
    gcNote.HeaderText = "Note"
    gcNote.Width = 100
    gcNote.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcNote)
    colNum += 1

    Dim gcEntity As New GridViewTextBoxColumn("Entity")
    gcEntity.HeaderText = "Entity"
    gcEntity.Width = 40
    gcEntity.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcEntity)
    colNum += 1

    Dim gcEntityType As New GridViewTextBoxColumn("EntityType")
    gcEntityType.HeaderText = "EntityType"
    gcEntityType.Width = 40
    gcEntityType.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcEntityType)
    colNum += 1

    Dim gcCustStr As New GridViewTextBoxColumn("CustStr")
    gcCustStr.HeaderText = "CustStr"
    gcCustStr.Width = 40
    gcCustStr.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcCustStr)
    colNum += 1

    Dim gcCustType As New GridViewTextBoxColumn("CustType")
    gcCustType.HeaderText = "CustType"
    gcCustType.Width = 20
    gcCustType.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcCustType)
    colNum += 1

    Dim gcAtomNote As New GridViewTextBoxColumn("AtomNote")
    gcAtomNote.HeaderText = "AtomNote"
    gcAtomNote.Width = 100
    gcAtomNote.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcAtomNote)
    colNum += 1
  End Sub
  Private Sub RefreshItems()
    Me.RadGridView1.Rows.Clear()
    Dim i As Integer = 1
    If Not je Is Nothing Then
      For Each item As JournalEntryItem In je.ItemCollection2
        Dim gridRow As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
        gridRow.Cells("Linenumber").Value = i

        gridRow.Cells("Mapping").Value = item.Mapping
        gridRow.Cells("Account").Value = item.Account.Code & ":" & item.Account.Name
        gridRow.Cells("CostCenter").Value = item.CostCenter.Code & ":" & item.CostCenter.Name
        If item.IsDebit Then
          gridRow.Cells("Debit").Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        Else
          gridRow.Cells("Credit").Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        End If
        gridRow.Cells("Note").Value = item.Note
        gridRow.Cells("Entity").Value = item.EntityItem.ToString
        gridRow.Cells("EntityType").Value = item.EntityItemType.ToString
        gridRow.Cells("CustStr").Value = item.CustomRefstr
        gridRow.Cells("CustType").Value = item.CustomRefType
        gridRow.Cells("AtomNote").Value = item.AtomNote
        gridRow.Tag = item
        i += 1
      Next
    Else
      Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
      If TypeOf window.ActiveViewContent Is Longkong.Pojjaman.Gui.Panels.ISimpleEntityPanel Then
        If TypeOf CType(window.ActiveViewContent, ISimpleEntityPanel).Entity Is INewGLAble Then
          Dim glable As INewGLAble = CType(CType(window.ActiveViewContent, ISimpleEntityPanel).Entity, INewGLAble)
          For Each item As JournalEntryItem In glable.NewGetJournalEntries
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
            gridRow.Cells("Entity").Value = item.EntityItem.ToString
            gridRow.Cells("EntityType").Value = item.EntityItemType.ToString
            gridRow.Cells("CustStr").Value = item.CustomRefstr
            gridRow.Cells("CustType").Value = item.CustomRefType
            gridRow.Cells("AtomNote").Value = item.AtomNote
            gridRow.Tag = item
            i += 1
          Next
        End If
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