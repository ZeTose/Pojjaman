Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Collections.Generic
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Telerik.WinControls
Imports System.IO
Imports Longkong.Pojjaman.Commands

Public Class RefPrintDialog
  Private Sub RefPrintDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    RadGridView1.EnableGrouping = False
    RadGridView1.EnableSorting = False

    GetColumns()
    Me.RadGridView1.MasterGridViewTemplate.AllowAddNewRow = False
    RefreshItems()
  End Sub
  Public Sub PopulateRow(ByVal row As DataRow, ByVal tr As GridViewDataRowInfo)
    If tr Is Nothing Then
      Return
    End If

    Dim deh As New DataRowHelper(row)
    Dim printTime As String = deh.GetValue(Of Date)("printtime").ToString
    Dim printUser As String = deh.GetValue(Of String)("user_name")
    Dim theData() As Byte = CType(row("XPS"), Byte())

    tr.Cells("User").Value = printUser

    tr.Cells("Time").Value = printTime

    tr.Tag = theData

  End Sub
  Public dt1 As DataTable
  Private Sub RefreshItems()
    Me.RadGridView1.Rows.Clear()
    Dim i As Integer = 1
    For Each row As DataRow In dt1.Rows
      Dim gridRow As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
      PopulateRow(row, gridRow)
      gridRow.Cells("Linenumber").Value = i
      i += 1
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

    Dim gcCBS As New GridViewTextBoxColumn("User")
    gcCBS.HeaderText = "User"
    gcCBS.Width = 200
    gcCBS.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcCBS)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcCBS)
    colNum += 1

    Dim gcName As New GridViewTextBoxColumn("Time")
    gcName.HeaderText = "Time"
    gcName.Width = 200
    gcName.ReadOnly = True
    Me.RadGridView1.Columns.Add(gcName)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcName)
    colNum += 1

  End Sub
  Private Sub RadGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles RadGridView1.CellDoubleClick
    If e.Row Is Nothing OrElse Not TypeOf e.Row.Tag Is Byte() Then
      Return
    End If
    Dim ctrl As Control = CType(sender, Control)
    Dim data() As Byte = CType(ctrl.Tag, Byte())
    Try
      Dim xpsDIR As String = System.IO.Path.GetTempPath
      Dim fileName As String = xpsDIR & Path.DirectorySeparatorChar & Now.Ticks.ToString & "tmp.xps"
      Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)
      Dim bw As New BinaryWriter(fs)
      bw.Write(data)
      bw.Close()
      Me.Close()
      Process.Start(fileName)
      ShowPrintLog.FileList.Add(fileName)
    Catch ex As Exception
      MessageBox.Show(ex.ToString)
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
