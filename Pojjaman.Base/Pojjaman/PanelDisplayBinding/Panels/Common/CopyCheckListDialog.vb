Imports Longkong.Core.Services
Imports System.Collections.Generic
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CopyCheckListDialog
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
    Friend WithEvents grbCheckList As System.Windows.Forms.GroupBox
    Friend WithEvents grbSource As System.Windows.Forms.GroupBox
    Friend WithEvents lblColNum As System.Windows.Forms.Label
    Friend WithEvents nudColNum As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.clbItemList = New System.Windows.Forms.CheckedListBox()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.chkSelectAll = New System.Windows.Forms.CheckBox()
      Me.grbCheckList = New System.Windows.Forms.GroupBox()
      Me.grbSource = New System.Windows.Forms.GroupBox()
      Me.nudColNum = New System.Windows.Forms.NumericUpDown()
      Me.lblColNum = New System.Windows.Forms.Label()
      Me.grbCheckList.SuspendLayout()
      Me.grbSource.SuspendLayout()
      CType(Me.nudColNum, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'clbItemList
      '
      Me.clbItemList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.clbItemList.CheckOnClick = True
      Me.clbItemList.Location = New System.Drawing.Point(15, 42)
      Me.clbItemList.Name = "clbItemList"
      Me.clbItemList.Size = New System.Drawing.Size(199, 292)
      Me.clbItemList.TabIndex = 0
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnOK.ForeColor = System.Drawing.Color.Black
      Me.btnOK.Location = New System.Drawing.Point(36, 430)
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
      Me.btnCancel.Location = New System.Drawing.Point(140, 430)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(96, 23)
      Me.btnCancel.TabIndex = 4
      Me.btnCancel.Text = "btnCancel"
      '
      'chkSelectAll
      '
      Me.chkSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkSelectAll.Location = New System.Drawing.Point(15, 14)
      Me.chkSelectAll.Name = "chkSelectAll"
      Me.chkSelectAll.Size = New System.Drawing.Size(104, 24)
      Me.chkSelectAll.TabIndex = 5
      Me.chkSelectAll.Text = "chkSelectAll"
      '
      'grbCheckList
      '
      Me.grbCheckList.Controls.Add(Me.chkSelectAll)
      Me.grbCheckList.Controls.Add(Me.clbItemList)
      Me.grbCheckList.Location = New System.Drawing.Point(13, 82)
      Me.grbCheckList.Name = "grbCheckList"
      Me.grbCheckList.Size = New System.Drawing.Size(227, 342)
      Me.grbCheckList.TabIndex = 6
      Me.grbCheckList.TabStop = False
      Me.grbCheckList.Text = "Copy List"
      '
      'grbSource
      '
      Me.grbSource.Controls.Add(Me.lblColNum)
      Me.grbSource.Controls.Add(Me.nudColNum)
      Me.grbSource.Location = New System.Drawing.Point(13, 3)
      Me.grbSource.Name = "grbSource"
      Me.grbSource.Size = New System.Drawing.Size(226, 73)
      Me.grbSource.TabIndex = 7
      Me.grbSource.TabStop = False
      Me.grbSource.Text = "Column ต้นฉบับ"
      '
      'nudColNum
      '
      Me.nudColNum.Location = New System.Drawing.Point(67, 31)
      Me.nudColNum.Name = "nudColNum"
      Me.nudColNum.Size = New System.Drawing.Size(120, 21)
      Me.nudColNum.TabIndex = 0
      '
      'lblColNum
      '
      Me.lblColNum.AutoSize = True
      Me.lblColNum.Location = New System.Drawing.Point(12, 33)
      Me.lblColNum.Name = "lblColNum"
      Me.lblColNum.Size = New System.Drawing.Size(53, 13)
      Me.lblColNum.TabIndex = 1
      Me.lblColNum.Text = "Column ที่"
      '
      'CopyCheckListDialog
      '
      Me.Controls.Add(Me.grbSource)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.grbCheckList)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "CopyCheckListDialog"
      Me.Size = New System.Drawing.Size(254, 467)
      Me.grbCheckList.ResumeLayout(False)
      Me.grbSource.ResumeLayout(False)
      Me.grbSource.PerformLayout()
      CType(Me.nudColNum, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
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
    Public Sub New(ByVal ColNum As Integer, ByVal ffcol As FFormatColumnCollection)
      Me.New()
      Me.nudColNum.Value = 1
      Me.nudColNum.Maximum = ColNum

      Me.clbItemList.Items.Clear()
      For Each ff As FFormatColumn In ffcol

        Me.clbItemList.Items.Add(ff.LineNumber.ToString & ":" & ff.Name)

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
    Public ReadOnly Property CheckedCopyColumn() As List(Of Integer)
      Get
        Dim result As New List(Of Integer)
        For Each item As Object In Me.clbItemList.CheckedItems
          If Me.clbItemList.Items.IndexOf(item) + 1 <> SourceColumn Then
            result.Add(Me.clbItemList.Items.IndexOf(item) + 1)
          End If
        Next
       
        Return result
      End Get
    End Property
    Public ReadOnly Property SourceColumn As Integer
      Get
        Return CInt(nudColNum.Value)
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