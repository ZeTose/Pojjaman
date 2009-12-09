Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Commands
Namespace Longkong.Pojjaman.Gui.Dialogs

    Public Class ChangePasswordDialog
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
        'Form overrides dispose to clean up the component list.
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
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents txtUserName As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents txtOldPassword As System.Windows.Forms.TextBox
        Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
        Friend WithEvents txtConfirmNewPassword As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblUserName = New System.Windows.Forms.Label
            Me.txtUserName = New System.Windows.Forms.TextBox
            Me.txtOldPassword = New System.Windows.Forms.TextBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.txtNewPassword = New System.Windows.Forms.TextBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.txtConfirmNewPassword = New System.Windows.Forms.TextBox
            Me.Label3 = New System.Windows.Forms.Label
            Me.btnOK = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'lblUserName
            '
            Me.lblUserName.Location = New System.Drawing.Point(13, 23)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(123, 23)
            Me.lblUserName.TabIndex = 5
            Me.lblUserName.Text = "ผู้ใช้งาน:"
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtUserName
            '
            Me.txtUserName.Location = New System.Drawing.Point(136, 24)
            Me.txtUserName.Name = "txtUserName"
            Me.txtUserName.ReadOnly = True
            Me.txtUserName.Size = New System.Drawing.Size(232, 21)
            Me.txtUserName.TabIndex = 6
            Me.txtUserName.TabStop = False
            Me.txtUserName.Text = ""
            '
            'txtOldPassword
            '
            Me.txtOldPassword.Location = New System.Drawing.Point(136, 48)
            Me.txtOldPassword.Name = "txtOldPassword"
            Me.txtOldPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtOldPassword.Size = New System.Drawing.Size(232, 21)
            Me.txtOldPassword.TabIndex = 0
            Me.txtOldPassword.Text = ""
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(13, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(123, 20)
            Me.Label1.TabIndex = 7
            Me.Label1.Text = "รหัสผ่านเดิม:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNewPassword
            '
            Me.txtNewPassword.Location = New System.Drawing.Point(136, 72)
            Me.txtNewPassword.Name = "txtNewPassword"
            Me.txtNewPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtNewPassword.Size = New System.Drawing.Size(232, 21)
            Me.txtNewPassword.TabIndex = 1
            Me.txtNewPassword.Text = ""
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(13, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(123, 23)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "รหัสผ่านใหม่:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtConfirmNewPassword
            '
            Me.txtConfirmNewPassword.Location = New System.Drawing.Point(136, 96)
            Me.txtConfirmNewPassword.Name = "txtConfirmNewPassword"
            Me.txtConfirmNewPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtConfirmNewPassword.Size = New System.Drawing.Size(232, 21)
            Me.txtConfirmNewPassword.TabIndex = 2
            Me.txtConfirmNewPassword.Text = ""
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(0, 96)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(136, 23)
            Me.Label3.TabIndex = 9
            Me.Label3.Text = "ใส่รหัสผ่านใหม่อีกครั้ง:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnOK
            '
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Location = New System.Drawing.Point(248, 136)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.TabIndex = 3
            Me.btnOK.Text = "OK"
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Location = New System.Drawing.Point(328, 136)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Cancel"
            '
            'ChangePasswordDialog
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(416, 166)
            Me.ControlBox = False
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.txtConfirmNewPassword)
            Me.Controls.Add(Me.txtNewPassword)
            Me.Controls.Add(Me.txtOldPassword)
            Me.Controls.Add(Me.txtUserName)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.lblUserName)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.KeyPreview = True
            Me.Name = "ChangePasswordDialog"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "เปลี่ยนรหัสผ่าน"
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_user As User
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Dim mySecurityService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            Me.m_user = mySecurityService.CurrentUser
            Me.txtUserName.Text = m_user.Name
        End Sub
#End Region

        Private Sub ChangePasswordDialog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            Select Case e.KeyCode
                Case Keys.Enter
          If StartPojjamanWorkbenchCommand.ALLOWTAB Then
                    SendKeys.Send("{tab}")
          End If
                    e.Handled = True
            End Select
        End Sub

        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            If Not m_user.ValidPassword(Me.txtOldPassword.Text) Then
                MessageBox.Show("Invalid Old Password!")
            ElseIf Me.txtNewPassword.Text <> Me.txtConfirmNewPassword.Text Then
                MessageBox.Show("new password not match!")
            Else
                m_user.Password = m_user.GeneratePassword(Me.txtNewPassword.Text)
                Dim msg As String = m_user.Save(m_user.Id).Message
                If IsNumeric(msg) Then
                    MessageBox.Show("Password has been changed!")
                    Me.DialogResult = DialogResult.OK
                Else
                    MessageBox.Show("Error Saving Password!" & ":" & msg)
                    Me.DialogResult = DialogResult.Abort
                End If

            End If
        End Sub
    End Class

End Namespace
