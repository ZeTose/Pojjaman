<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimpleListDialog
  Inherits System.Windows.Forms.UserControl

  'UserControl overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.lbTheList = New System.Windows.Forms.ListBox()
    Me.lblSimpleListName = New System.Windows.Forms.Label()
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lbTheList
    '
    Me.lbTheList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lbTheList.ContextMenuStrip = Me.ContextMenuStrip1
    Me.lbTheList.FormattingEnabled = True
    Me.lbTheList.Location = New System.Drawing.Point(13, 28)
    Me.lbTheList.Name = "lbTheList"
    Me.lbTheList.Size = New System.Drawing.Size(199, 381)
    Me.lbTheList.TabIndex = 0
    '
    'lblSimpleListName
    '
    Me.lblSimpleListName.AutoSize = True
    Me.lblSimpleListName.Location = New System.Drawing.Point(13, 9)
    Me.lblSimpleListName.Name = "lblSimpleListName"
    Me.lblSimpleListName.Size = New System.Drawing.Size(39, 13)
    Me.lblSimpleListName.TabIndex = 1
    Me.lblSimpleListName.Text = "Label1"
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
    '
    'CopyToolStripMenuItem
    '
    Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
    Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
    Me.CopyToolStripMenuItem.Text = "Copy"
    '
    'SimpleListDialog
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.lblSimpleListName)
    Me.Controls.Add(Me.lbTheList)
    Me.Name = "SimpleListDialog"
    Me.Size = New System.Drawing.Size(230, 433)
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lbTheList As System.Windows.Forms.ListBox
  Friend WithEvents lblSimpleListName As System.Windows.Forms.Label
  Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
