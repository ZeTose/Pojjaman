<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActionForm
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
    Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
    Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
    Me.btnPrint = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.FixedGroupBox1.SuspendLayout()
    Me.FlowLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'FixedGroupBox1
    '
    Me.FixedGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.FixedGroupBox1.Controls.Add(Me.TextBox1)
    Me.FixedGroupBox1.Controls.Add(Me.FlowLayoutPanel1)
    Me.FixedGroupBox1.Location = New System.Drawing.Point(3, 3)
    Me.FixedGroupBox1.Name = "FixedGroupBox1"
    Me.FixedGroupBox1.Size = New System.Drawing.Size(304, 122)
    Me.FixedGroupBox1.TabIndex = 16
    Me.FixedGroupBox1.TabStop = False
    Me.FixedGroupBox1.Text = "Possible Actions:"
    '
    'FlowLayoutPanel1
    '
    Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.FlowLayoutPanel1.Controls.Add(Me.btnPrint)
    Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 45)
    Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
    Me.FlowLayoutPanel1.Size = New System.Drawing.Size(294, 69)
    Me.FlowLayoutPanel1.TabIndex = 6
    '
    'btnPrint
    '
    Me.btnPrint.Location = New System.Drawing.Point(3, 3)
    Me.btnPrint.Name = "btnPrint"
    Me.btnPrint.Size = New System.Drawing.Size(75, 23)
    Me.btnPrint.TabIndex = 0
    Me.btnPrint.Text = "Print"
    Me.btnPrint.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(9, 19)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(289, 20)
    Me.TextBox1.TabIndex = 7
    '
    'ActionForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.FixedGroupBox1)
    Me.Name = "ActionForm"
    Me.Size = New System.Drawing.Size(310, 132)
    Me.FixedGroupBox1.ResumeLayout(False)
    Me.FixedGroupBox1.PerformLayout()
    Me.FlowLayoutPanel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
  Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents btnPrint As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
