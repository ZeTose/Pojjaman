Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Commands
Namespace Longkong.Pojjaman.Gui.Dialogs
  Public Class LoginDialog
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
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblLoginName As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents cmbCompanyList As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.lblLoginName = New System.Windows.Forms.Label
      Me.txtUserName = New System.Windows.Forms.TextBox
      Me.txtPassword = New System.Windows.Forms.TextBox
      Me.lblPassword = New System.Windows.Forms.Label
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.cmbCompanyList = New System.Windows.Forms.ComboBox
      Me.lblCompany = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'lblLoginName
      '
      Me.lblLoginName.Location = New System.Drawing.Point(24, 40)
      Me.lblLoginName.Name = "lblLoginName"
      Me.lblLoginName.Size = New System.Drawing.Size(72, 23)
            Me.lblLoginName.TabIndex = 5
      Me.lblLoginName.Text = "Login:"
      Me.lblLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtUserName
      '
      Me.txtUserName.Location = New System.Drawing.Point(96, 40)
      Me.txtUserName.Name = "txtUserName"
      Me.txtUserName.Size = New System.Drawing.Size(320, 21)
            Me.txtUserName.TabIndex = 0
      Me.txtUserName.Text = ""
      '
      'txtPassword
      '
      Me.txtPassword.Location = New System.Drawing.Point(96, 64)
      Me.txtPassword.Name = "txtPassword"
      Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
      Me.txtPassword.Size = New System.Drawing.Size(320, 21)
            Me.txtPassword.TabIndex = 1
      Me.txtPassword.Text = ""
      '
      'lblPassword
      '
      Me.lblPassword.Location = New System.Drawing.Point(24, 64)
      Me.lblPassword.Name = "lblPassword"
      Me.lblPassword.Size = New System.Drawing.Size(72, 20)
            Me.lblPassword.TabIndex = 7
      Me.lblPassword.Text = "Password:"
      Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnOK
      '
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Location = New System.Drawing.Point(240, 88)
      Me.btnOK.Name = "btnOK"
            Me.btnOK.TabIndex = 2
      Me.btnOK.Text = "เข้าสู่ระบบ"
      '
      'btnCancel
      '
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Location = New System.Drawing.Point(320, 88)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(96, 23)
            Me.btnCancel.TabIndex = 3
      Me.btnCancel.Text = "ออกจากโปรแกรม"
      '
      'cmbCompanyList
      '
      Me.cmbCompanyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCompanyList.Location = New System.Drawing.Point(96, 16)
      Me.cmbCompanyList.Name = "cmbCompanyList"
      Me.cmbCompanyList.Size = New System.Drawing.Size(320, 21)
            Me.cmbCompanyList.TabIndex = 8
            Me.cmbCompanyList.MaxDropDownItems = 10
      '
      'lblCompany
      '
      Me.lblCompany.Location = New System.Drawing.Point(24, 16)
      Me.lblCompany.Name = "lblCompany"
      Me.lblCompany.Size = New System.Drawing.Size(72, 23)
            Me.lblCompany.TabIndex = 5
      Me.lblCompany.Text = "Company:"
      Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'LoginDialog
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
            Me.ClientSize = New System.Drawing.Size(434, 128)
      Me.ControlBox = False
      Me.Controls.Add(Me.cmbCompanyList)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.txtPassword)
      Me.Controls.Add(Me.txtUserName)
      Me.Controls.Add(Me.lblPassword)
      Me.Controls.Add(Me.lblLoginName)
      Me.Controls.Add(Me.lblCompany)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.KeyPreview = True
      Me.Name = "LoginDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Login"
      Me.TopMost = True
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_user As User
    Private m_properties As PropertyService
    Private m_recentCompanies As RecentCompanies
    Private StringParserService As StringParserService
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      m_properties = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Initialize()
      SetLabelText()
    End Sub
#End Region

#Region "Methods"
    Private m_isInit As Boolean = False
    Private Sub Initialize()
      Me.m_recentCompanies = CType(m_properties.GetProperty("Longkong.Pojjaman.RecentCompanies", New RecentCompanies), RecentCompanies)
      For Each co As Company In m_recentCompanies.RecentCompanies
        Me.cmbCompanyList.Items.Add(co)
      Next
      If Me.cmbCompanyList.Items.Count = 0 Then
        Return
      End If
      cmbCompanyList.SelectedIndex = 0
      m_isInit = True
    End Sub
    Private Sub SetLabelText()
      Me.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.Text}")
      Me.btnOK.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.btnOK}")
      Me.btnCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.btnCancel}")
      Me.lblLoginName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.lblLoginName}")
      Me.lblCompany.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.lblCompany}")
      Me.lblPassword.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.lblPassword}")
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property UserName() As String
      Get
        Return Me.txtUserName.Text
      End Get
    End Property
    Public ReadOnly Property Password() As String
      Get
        Return Me.txtPassword.Text
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub LoginDiaog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
      Select Case e.KeyCode
        Case Keys.Enter
          If StartPojjamanWorkbenchCommand.ALLOWTAB Then
            SendKeys.Send("{tab}")
          End If
          e.Handled = True
      End Select
    End Sub
    Private Sub cmbCompanyList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompanyList.SelectedIndexChanged
      If Not m_isInit Then
        Return
      End If
      If Me.cmbCompanyList.Items.Count = 0 Then
        Return
      End If
      Dim co As Company = CType(Me.cmbCompanyList.SelectedItem, Company)
      Me.m_recentCompanies.ChangeCurrentCompany(co.Name)
      If Me.m_recentCompanies Is Nothing Then
        Return
      End If
      If Me.m_recentCompanies.CurrentCompany Is Nothing Then
        Return
      End If
      Try
        BusinessLogic.Entity.RefreshEntityList()
      Catch ex As Exception
        MessageBox.Show("Cannot connect to this database, please select another one")
        Return
      End Try
    End Sub
#End Region

  End Class

End Namespace
