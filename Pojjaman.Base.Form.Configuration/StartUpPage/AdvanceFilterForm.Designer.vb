<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvanceFilterForm
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
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
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.chkCostCenterList = New System.Windows.Forms.CheckedListBox()
    Me.btnClear = New System.Windows.Forms.Button()
    Me.btnOK = New System.Windows.Forms.Button()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.chkCostCenterList)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 29)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(401, 378)
    Me.GroupBox1.TabIndex = 15
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Cost Center"
    '
    'chkCostCenterList
    '
    Me.chkCostCenterList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.chkCostCenterList.CheckOnClick = True
    Me.chkCostCenterList.FormattingEnabled = True
    Me.chkCostCenterList.Location = New System.Drawing.Point(0, 29)
    Me.chkCostCenterList.Name = "chkCostCenterList"
    Me.chkCostCenterList.Size = New System.Drawing.Size(401, 349)
    Me.chkCostCenterList.TabIndex = 3
    '
    'btnClear
    '
    Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnClear.Location = New System.Drawing.Point(317, 413)
    Me.btnClear.Name = "btnClear"
    Me.btnClear.Size = New System.Drawing.Size(96, 23)
    Me.btnClear.TabIndex = 13
    Me.btnClear.Text = "Clear"
    '
    'btnOK
    '
    Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnOK.Location = New System.Drawing.Point(215, 413)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(96, 23)
    Me.btnOK.TabIndex = 10
    Me.btnOK.Text = "OK"
    '
    'AdvanceFilterForm
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(425, 444)
    Me.Controls.Add(Me.btnClear)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.btnOK)
    Me.Name = "AdvanceFilterForm"
    Me.Text = "Advance Filters Box"
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents btnClear As System.Windows.Forms.Button
  Friend WithEvents btnOK As System.Windows.Forms.Button
  Friend WithEvents chkCostCenterList As System.Windows.Forms.CheckedListBox
End Class
