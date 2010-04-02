<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class History
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
    Me.lstLogs = New System.Windows.Forms.ListBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'lstLogs
    '
    Me.lstLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lstLogs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
    Me.lstLogs.FormattingEnabled = True
    Me.lstLogs.Location = New System.Drawing.Point(6, 32)
    Me.lstLogs.Name = "lstLogs"
    Me.lstLogs.Size = New System.Drawing.Size(697, 199)
    Me.lstLogs.TabIndex = 20
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label2.Location = New System.Drawing.Point(3, 13)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(209, 20)
    Me.Label2.TabIndex = 19
    Me.Label2.Text = "History of this document:"
    '
    'Document
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.lstLogs)
    Me.Controls.Add(Me.Label2)
    Me.Name = "Document"
    Me.Size = New System.Drawing.Size(721, 247)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lstLogs As System.Windows.Forms.ListBox
  Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
