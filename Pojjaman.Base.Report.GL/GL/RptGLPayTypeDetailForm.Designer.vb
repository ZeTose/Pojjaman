<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptGLPayTypeDetailForm
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
    Me.ListView1 = New Longkong.Pojjaman.Gui.Components.PJMListView()
    Me.SuspendLayout()
    '
    'ListView1
    '
    Me.ListView1.AllowSort = True
    Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListView1.Location = New System.Drawing.Point(0, 0)
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(284, 262)
    Me.ListView1.SortIndex = -1
    Me.ListView1.SortOrder = System.Windows.Forms.SortOrder.None
    Me.ListView1.TabIndex = 1
    Me.ListView1.UseCompatibleStateImageBehavior = False
    '
    'RptGLPayTypeDetailForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 262)
    Me.Controls.Add(Me.ListView1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
    Me.Name = "RptGLPayTypeDetailForm"
    Me.Text = "ShowListDetailForm"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents ListView1 As Longkong.Pojjaman.Gui.Components.PJMListView
End Class
