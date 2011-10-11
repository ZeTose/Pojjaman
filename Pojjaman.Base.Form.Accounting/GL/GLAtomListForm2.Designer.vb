<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GLAtomListForm2
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
    Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
    Me.btnRefresh = New System.Windows.Forms.Button()
    CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'RadGridView1
    '
    Me.RadGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.RadGridView1.Location = New System.Drawing.Point(12, 41)
    Me.RadGridView1.Name = "RadGridView1"
    Me.RadGridView1.Size = New System.Drawing.Size(1029, 654)
    Me.RadGridView1.TabIndex = 1
    '
    'btnRefresh
    '
    Me.btnRefresh.Location = New System.Drawing.Point(12, 12)
    Me.btnRefresh.Name = "btnRefresh"
    Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
    Me.btnRefresh.TabIndex = 2
    Me.btnRefresh.Text = "Refresh"
    Me.btnRefresh.UseVisualStyleBackColor = True
    '
    'GLListForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1053, 707)
    Me.Controls.Add(Me.btnRefresh)
    Me.Controls.Add(Me.RadGridView1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "GLListForm"
    Me.ShowInTaskbar = False
    Me.Text = "GL List"
    CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
  Friend WithEvents btnRefresh As System.Windows.Forms.Button
End Class
