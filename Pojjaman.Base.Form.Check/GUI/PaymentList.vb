Imports Telerik.WinControls.UI
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Collections.Generic

Public Class PaymentList
  Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    RefreshItems()
  End Sub

  Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierFind.Click

  End Sub

  Private Sub PaymentList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.RadGridView1.MasterGridViewTemplate.AllowAddNewRow = False
    GetColumns()
    RefreshItems()
  End Sub
  Public Sub PopulateRow(ByVal p As PaymentForList, ByVal tr As GridViewDataRowInfo)
    If tr Is Nothing Then
      Return
    End If

    tr.Cells("PaymentCode").Value = p.Code
    tr.Cells("RefCode").Value = p.RefCode
    tr.Cells("RefType").Value = p.RefType
    tr.Cells("RefDueDate").Value = p.RefDueDate.ToShortDateString
    tr.Cells("Amount").Value = Configuration.FormatToString(p.RefAmount, DigitConfig.Price)
    tr.Cells("Remain").Value = Configuration.FormatToString(p.RefRemain, DigitConfig.Price)

    tr.Tag = p

  End Sub
  Property Supplier As Supplier
  Private Function GetFilterArray() As Filter()
    Dim arr(2) As Filter
    arr(0) = New Filter("supplier_id", Supplier.ValidIdOrDBNull(Supplier))
    arr(1) = New Filter("startdate", Me.dtpDocDateStart.Value)
    arr(2) = New Filter("enddate", Me.dtpDocDateEnd.Value)
    Return arr
  End Function
  Private Sub RefreshItems()
    Me.RadGridView1.GridElement.BeginUpdate()
    Me.RadGridView1.Rows.Clear()
    Dim list As List(Of PaymentForList) = PaymentForList.GetPaymentList(GetFilterArray())
    For Each p As PaymentForList In list
      Dim row As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
      PopulateRow(p, row)
    Next
    Dim i As Integer = 1
    For Each row As GridViewDataRowInfo In Me.RadGridView1.Rows
      row.Cells("Linenumber").Value = i
      i += 1
    Next
    Me.RadGridView1.GridElement.EndUpdate(True)
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

    Dim gcPaymentCode As New GridViewTextBoxColumn("PaymentCode")
    gcPaymentCode.HeaderText = "เลขที่ PV" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
    gcPaymentCode.Width = 100
    gcPaymentCode.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcPaymentCode)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcPaymentCode)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcRefCode As New GridViewTextBoxColumn("RefCode")
    gcRefCode.HeaderText = "เอกสารอ้างอิง" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
    gcRefCode.Width = 100
    gcRefCode.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcRefCode)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefCode)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcRefType As New GridViewTextBoxColumn("RefType")
    gcRefType.HeaderText = "ประเภท" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
    gcRefType.Width = 100
    gcRefType.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcRefType)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefType)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcRefDueDate As New GridViewTextBoxColumn("RefDueDate")
    gcRefDueDate.HeaderText = "วันที่ครบกำหนด" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
    gcRefDueDate.Width = 100
    gcRefDueDate.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcRefDueDate)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefDueDate)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim csAmount As New GridViewTextBoxColumn("Amount")
    csAmount.HeaderText = "จำนวนเงินที่ต้องจ่าย" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.AmountHeaderText}")
    csAmount.Width = 150
    csAmount.TextAlignment = ContentAlignment.MiddleRight
    csAmount.ReadOnly = True
    Me.RadGridView1.Columns.Add(csAmount)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csAmount)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim csRemain As New GridViewTextBoxColumn("Remain")
    csRemain.HeaderText = "คงเหลือ" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
    csRemain.ReadOnly = True
    csRemain.Width = 150
    csRemain.TextAlignment = ContentAlignment.MiddleRight
    csRemain.ReadOnly = True
    Me.RadGridView1.Columns.Add(csRemain)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csRemain)
    viewDef.ColumnGroups(colNum).IsPinned = True

  End Sub
  Private Sub ibtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAdd.Click

  End Sub
  Private Sub ibtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelete.Click

  End Sub
  Private Sub ibtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnClear.Click

  End Sub
End Class