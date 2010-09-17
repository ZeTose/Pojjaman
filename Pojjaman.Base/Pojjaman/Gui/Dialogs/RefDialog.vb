Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Collections.Generic
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Telerik.WinControls

Public Class RefDialog
  Private Sub RefDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RadGridView1.EnableGrouping = False
    RadGridView1.EnableSorting = False

    GetColumns()
    Me.RadGridView1.MasterGridViewTemplate.AllowAddNewRow = False
    RefreshItems()
  End Sub
  Public Sub PopulateRow(ByVal row As DataRow, ByVal tr As GridViewDataRowInfo, ByVal t As Integer)
    If tr Is Nothing Then
      Return
    End If

    Dim deh As New DataRowHelper(row)
    Dim prefix As String = deh.GetValue(Of String)("entity_prefix")
    Dim theDescription As String = deh.GetValue(Of String)("entity_description")
    Dim fullClassName As String = deh.GetValue(Of String)("entity_fullClassName")
    Dim isCanceled As Boolean = deh.GetValue(Of Boolean)("refto_iscanceled")
    Dim CancledTxt As String = ""

    Dim thisMessage As String
    Dim dr As DataRow
    If t = Reftable.reffrom Then
      dr = Longkong.Pojjaman.BusinessLogic.SimpleBusinessEntityBase.GetEntityRow(CInt(row("entity_id")), CInt(row("entity_type")))
    ElseIf t = Reftable.refto Then
      dr = Longkong.Pojjaman.BusinessLogic.SimpleBusinessEntityBase.GetEntityRow(CInt(row("refto_id")), CInt(row("refto_type")))
      If isCanceled Then
        CancledTxt = "(ยกเลิก)"
      End If
    End If


    deh = New DataRowHelper(dr)

    Dim theCode As String = deh.GetValue(Of String)(prefix & "_code")
    Dim theId As Integer = deh.GetValue(Of Integer)(prefix & "_id")

    thisMessage = theDescription & ":" & theCode

    tr.Cells("Description").Value = thisMessage

    tr.Cells("Code").Value = CancledTxt & theCode

    tr.Tag = New KeyValuePair(Of Integer, String)(theId, fullClassName)

  End Sub
  Public dt1 As DataTable 'Ref to
  Public dt2 As DataTable 'Ref from
  Private Enum Reftable
    refto
    reffrom
  End Enum
  Private Sub RefreshItems()
    Me.RadGridView1.Rows.Clear()
    Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    Dim headRow As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
    headRow.Cells("Description").Value = myStringParserService.Parse("${res:Commands.ShowRef.lbl}") '"ถูกอ้างอิงไปที่: (ดับเบิ้ลคลิกเพื่อไปยังเอกสาร)"
    Dim i As Integer = 1
    For Each row As DataRow In dt1.Rows
      Dim gridRow As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
      PopulateRow(row, gridRow, reftable.refto)
      gridRow.Cells("Linenumber").Value = i
      i += 1
    Next

    Dim headRow2 As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
    headRow2.Cells("Description").Value = myStringParserService.Parse("${res:Commands.ShowRef.lbl2}") '"อ้างอิงมาจาก: (ดับเบิ้ลคลิกเพื่อไปยังเอกสาร)"        
    Dim i2 As Integer = 1
    For Each row As DataRow In dt2.Rows
      Dim gridRow As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
      PopulateRow(row, gridRow, Reftable.reffrom)
      gridRow.Cells("Linenumber").Value = i2
      i2 += 1
    Next
  End Sub
  Dim viewDef As ColumnGroupsViewDefinition
  Private Sub GetColumns()

    viewDef = New ColumnGroupsViewDefinition
    Dim colNum As Integer = 0
    Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    Dim gcLineNumber As New GridViewDecimalColumn("Linenumber")
    gcLineNumber.HeaderText = "No."
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

    Dim gcCBS As New GridViewTextBoxColumn("Description")
    gcCBS.HeaderText = "Description"
    gcCBS.Width = 300
    gcCBS.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcCBS)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcCBS)
    colNum += 1

    Dim gcName As New GridViewTextBoxColumn("Code")
    gcName.HeaderText = "Code"
    gcName.Width = 200
    gcName.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcName)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcName)
    colNum += 1

  End Sub
  Private Sub RadGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles RadGridView1.CellDoubleClick
    If e.Row Is Nothing OrElse Not TypeOf e.Row.Tag Is Global.System.Collections.Generic.KeyValuePair(Of Integer, String) Then
      Return
    End If
    Try
      Dim kv As KeyValuePair(Of Integer, String) = CType(e.Row.Tag, Global.System.Collections.Generic.KeyValuePair(Of Integer, String))
      Dim theId As Integer = kv.Key
      Dim theType As String = kv.Value
      Dim theEntity As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(theType, theId)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenDetailPanel(theEntity)
      Me.Close()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub RadGridView1_RowFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles RadGridView1.RowFormatting
    If e.RowElement Is Nothing OrElse e.RowElement.RowInfo Is Nothing OrElse e.RowElement.RowInfo.Tag Is Nothing Then
      Dim bgColor As Color = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Dim fColor As Color
      If CInt(bgColor.R) + CInt(bgColor.G) + CInt(bgColor.B) > 128 * 3 Then
        fColor = Color.Black
      Else
        fColor = Color.Black
      End If
      e.RowElement.NumberOfColors = 1
      e.RowElement.BackColor = bgColor
      e.RowElement.DrawFill = True
      e.RowElement.ForeColor = fColor
    Else
      e.RowElement.DrawFill = False
      e.RowElement.ResetValue(VisualElement.BackColorProperty)
      e.RowElement.ResetValue(VisualElement.ForeColorProperty)
    End If
  End Sub
End Class
