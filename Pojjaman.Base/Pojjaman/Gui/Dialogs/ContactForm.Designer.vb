<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContactForm
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
    Me.components = New System.ComponentModel.Container()
    Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
    Me.txtSubject = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.btnSend = New System.Windows.Forms.Button()
    Me.btnCancel = New System.Windows.Forms.Button()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.txtEmail = New System.Windows.Forms.TextBox()
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.SuspendLayout()
    '
    'RichTextBox1
    '
    Me.RichTextBox1.Location = New System.Drawing.Point(13, 64)
    Me.RichTextBox1.Name = "RichTextBox1"
    Me.RichTextBox1.Size = New System.Drawing.Size(488, 236)
    Me.RichTextBox1.TabIndex = 8
    Me.RichTextBox1.Text = ""
    Me.ToolTip1.SetToolTip(Me.RichTextBox1, "กรอกรายละเอียด เช่น งานที่กำลังทำขณะเกิด Error หรือข้อความที่ต้องการติชม")
    '
    'txtSubject
    '
    Me.txtSubject.Location = New System.Drawing.Point(87, 38)
    Me.txtSubject.Name = "txtSubject"
    Me.txtSubject.Size = New System.Drawing.Size(414, 20)
    Me.txtSubject.TabIndex = 7
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(27, 41)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(46, 13)
    Me.Label1.TabIndex = 6
    Me.Label1.Text = "Subject:"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'btnSend
    '
    Me.btnSend.Location = New System.Drawing.Point(345, 306)
    Me.btnSend.Name = "btnSend"
    Me.btnSend.Size = New System.Drawing.Size(75, 23)
    Me.btnSend.TabIndex = 9
    Me.btnSend.Text = "Send"
    Me.btnSend.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(426, 306)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 10
    Me.btnCancel.Text = "Cancel"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(35, 15)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(35, 13)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Email:"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtEmail
    '
    Me.txtEmail.Location = New System.Drawing.Point(87, 12)
    Me.txtEmail.Name = "txtEmail"
    Me.txtEmail.Size = New System.Drawing.Size(414, 20)
    Me.txtEmail.TabIndex = 3
    '
    'ContactForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(513, 333)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtEmail)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.btnSend)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtSubject)
    Me.Controls.Add(Me.RichTextBox1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "ContactForm"
    Me.ShowInTaskbar = False
    Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
    Me.Text = "Contact Form"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
  Friend WithEvents txtSubject As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btnSend As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtEmail As System.Windows.Forms.TextBox
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
