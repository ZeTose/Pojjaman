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
    Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
    Me.txtSubject = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtCompany = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtName = New System.Windows.Forms.TextBox()
    Me.btnSend = New System.Windows.Forms.Button()
    Me.btnCancel = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'RichTextBox1
    '
    Me.RichTextBox1.Location = New System.Drawing.Point(13, 90)
    Me.RichTextBox1.Name = "RichTextBox1"
    Me.RichTextBox1.Size = New System.Drawing.Size(488, 210)
    Me.RichTextBox1.TabIndex = 6
    Me.RichTextBox1.Text = ""
    '
    'txtSubject
    '
    Me.txtSubject.Location = New System.Drawing.Point(87, 64)
    Me.txtSubject.Name = "txtSubject"
    Me.txtSubject.Size = New System.Drawing.Size(414, 20)
    Me.txtSubject.TabIndex = 5
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(27, 67)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(46, 13)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Subject:"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(19, 41)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(54, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Company:"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtCompany
    '
    Me.txtCompany.Location = New System.Drawing.Point(87, 38)
    Me.txtCompany.Name = "txtCompany"
    Me.txtCompany.Size = New System.Drawing.Size(414, 20)
    Me.txtCompany.TabIndex = 3
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(35, 15)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(38, 13)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "Name:"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(87, 12)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(414, 20)
    Me.txtName.TabIndex = 1
    '
    'btnSend
    '
    Me.btnSend.Location = New System.Drawing.Point(345, 306)
    Me.btnSend.Name = "btnSend"
    Me.btnSend.Size = New System.Drawing.Size(75, 23)
    Me.btnSend.TabIndex = 7
    Me.btnSend.Text = "Send"
    Me.btnSend.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(426, 306)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 8
    Me.btnCancel.Text = "Cancel"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'ContactForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(513, 333)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.btnSend)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtName)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtCompany)
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
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtCompany As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents btnSend As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
