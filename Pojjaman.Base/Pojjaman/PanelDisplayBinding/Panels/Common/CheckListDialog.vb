Imports Longkong.Core.Services
Imports System.Collections.Generic
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CheckListDialog
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents clbItemList As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.clbItemList = New System.Windows.Forms.CheckedListBox()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.chkSelectAll = New System.Windows.Forms.CheckBox()
      Me.SuspendLayout()
      '
      'clbItemList
      '
      Me.clbItemList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.clbItemList.CheckOnClick = True
      Me.clbItemList.Location = New System.Drawing.Point(8, 32)
      Me.clbItemList.Name = "clbItemList"
      Me.clbItemList.Size = New System.Drawing.Size(248, 292)
      Me.clbItemList.TabIndex = 0
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnOK.ForeColor = System.Drawing.Color.Black
      Me.btnOK.Location = New System.Drawing.Point(56, 344)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(96, 23)
      Me.btnOK.TabIndex = 3
      Me.btnOK.Text = "btnOK"
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.Black
      Me.btnCancel.Location = New System.Drawing.Point(160, 344)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(96, 23)
      Me.btnCancel.TabIndex = 4
      Me.btnCancel.Text = "btnCancel"
      '
      'chkSelectAll
      '
      Me.chkSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkSelectAll.Location = New System.Drawing.Point(10, 8)
      Me.chkSelectAll.Name = "chkSelectAll"
      Me.chkSelectAll.Size = New System.Drawing.Size(104, 24)
      Me.chkSelectAll.TabIndex = 5
      Me.chkSelectAll.Text = "chkSelectAll"
      '
      'CheckListDialog
      '
      Me.Controls.Add(Me.chkSelectAll)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.clbItemList)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "CheckListDialog"
      Me.Size = New System.Drawing.Size(264, 384)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Dim IsIDescripable As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()

      Dim sps As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Me.btnCancel.Text = sps.Parse("${res:Global.CancelButtonText}")
      Me.btnOK.Text = sps.Parse("${res:Global.OKButtonText}")
      Me.chkSelectAll.Text = sps.Parse("${res:Global.SelectAll}")
    End Sub
    Public Sub New(ByVal list As Object(), ByVal checkedList As Object())
      Me.New()

      Me.clbItemList.Items.Clear()
      For Each item As Object In list
        Me.clbItemList.Items.Add(item)
      Next
      If checkedList.Length = 0 Then
        Return
      End If
      For Each item As Object In checkedList
        Me.clbItemList.SetItemChecked(Array.IndexOf(list, item), True)
      Next
    End Sub
    Public Sub New(ByVal list As Object(), ByVal checkedListString As String)
      Me.New()

      Me.clbItemList.Items.Clear()
      For Each item As Object In list
        Me.clbItemList.Items.Add(item)
      Next

      If checkedListString Is Nothing OrElse checkedListString.Length = 0 Then
        Return
      End If
      Dim checkedList As Object() = checkedListString.Split(","c)
      For Each index As Integer In checkedList
        Me.clbItemList.SetItemChecked(index, True)
      Next
    End Sub
    Public Sub New(ByVal list As List(Of IDescripable), ByVal checkedListString As String)
      Me.New()

      Me.clbItemList.Items.Clear()
      For Each item As IDescripable In list
        Me.clbItemList.Items.Add(item)
      Next
      If clbItemList.Items.Count > 0 Then
        IsIDescripable = True
      End If
      If checkedListString Is Nothing OrElse checkedListString.Length = 0 Then
        Return
      End If
      Dim checkedList As Object() = checkedListString.Split(","c)
      For Each index As Integer In checkedList
        Me.clbItemList.SetItemChecked(index, True)
      Next
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property CheckedItems() As CheckedListBox.CheckedItemCollection
      Get
        Return Me.clbItemList.CheckedItems
      End Get
    End Property
    Public ReadOnly Property CheckedItemsString() As String
      Get
        Dim result As String = ""
        For Each item As Object In Me.clbItemList.CheckedItems
          result &= item.ToString & ","
        Next
        If result.Length <> 0 Then
          result = result.TrimEnd(","c)
        End If
        Return result
      End Get
    End Property
    Public ReadOnly Property CheckedValuesString() As String
      Get
        Dim result As String = ""
        For Each item As Object In Me.clbItemList.CheckedItems
          result &= Me.clbItemList.Items.IndexOf(item).ToString & ","
        Next
        If result.Length <> 0 Then
          result = result.TrimEnd(","c)
        End If
        Return result
      End Get
    End Property
    Public ReadOnly Property CheckedItemValuesString() As String
      Get
        Dim result As String = ""
        If Not IsIDescripable Then
          Return result
        End If
        For Each item As IDescripable In Me.clbItemList.CheckedItems
          result &= item.id.ToString & ","
        Next
        If result.Length <> 0 Then
          result = result.TrimEnd(","c)
        End If
        Return result
      End Get
    End Property
#End Region

#Region "Methods"
    Private checking As Boolean = False
    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
      If checking Then
        Return
      End If
      For i As Integer = 0 To Me.clbItemList.Items.Count - 1
        Me.clbItemList.SetItemChecked(i, chkSelectAll.Checked)
      Next
    End Sub
    Private Sub clbItemList_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clbItemList.MouseUp
      CheckChanged()
    End Sub
    Private Sub clbItemList_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles clbItemList.KeyUp
      CheckChanged()
    End Sub
    Private Sub CheckChanged()
      checking = True
      If clbItemList.CheckedItems.Count = 0 Then
        chkSelectAll.CheckState = CheckState.Unchecked
      ElseIf clbItemList.CheckedItems.Count = clbItemList.Items.Count Then
        chkSelectAll.CheckState = CheckState.Checked
      Else
        chkSelectAll.CheckState = CheckState.Indeterminate
      End If
      checking = False
    End Sub
#End Region

  End Class
End Namespace