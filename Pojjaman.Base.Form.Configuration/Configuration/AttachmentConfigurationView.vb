Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AttachmentConfigurationView
        'Inherits UserControl
        Inherits AbstractOptionPanel
        Implements IValidatable

#Region " Windows Form Designer generated code "
        'UserControl overrides dispose to clean up the component list.
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
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents grbDetail As FixedGroupBox
        Friend WithEvents chkUseAttachment As System.Windows.Forms.CheckBox
        Friend WithEvents grbFTP As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtInternalFTP As System.Windows.Forms.TextBox
        Friend WithEvents txtExternalFTP As System.Windows.Forms.TextBox
        Friend WithEvents txtUsername As System.Windows.Forms.TextBox
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents txtPath As System.Windows.Forms.TextBox
        Friend WithEvents lblIn As System.Windows.Forms.Label
        Friend WithEvents lblEx As System.Windows.Forms.Label
        Friend WithEvents lblUsername As System.Windows.Forms.Label
        Friend WithEvents lblPass As System.Windows.Forms.Label
        Friend WithEvents lblPath As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkUseAttachment = New System.Windows.Forms.CheckBox
            Me.grbFTP = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtInternalFTP = New System.Windows.Forms.TextBox
            Me.lblIn = New System.Windows.Forms.Label
            Me.txtExternalFTP = New System.Windows.Forms.TextBox
            Me.txtUsername = New System.Windows.Forms.TextBox
            Me.txtPassword = New System.Windows.Forms.TextBox
            Me.txtPath = New System.Windows.Forms.TextBox
            Me.lblEx = New System.Windows.Forms.Label
            Me.lblUsername = New System.Windows.Forms.Label
            Me.lblPass = New System.Windows.Forms.Label
            Me.lblPath = New System.Windows.Forms.Label
            Me.grbDetail.SuspendLayout()
            Me.grbFTP.SuspendLayout()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.chkUseAttachment)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(424, 56)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "การแนบเอกสาร"
            '
            'chkUseAttachment
            '
            Me.chkUseAttachment.Location = New System.Drawing.Point(56, 24)
            Me.chkUseAttachment.Name = "chkUseAttachment"
            Me.chkUseAttachment.Size = New System.Drawing.Size(232, 24)
            Me.chkUseAttachment.TabIndex = 1
            Me.chkUseAttachment.Text = "เปิดการใช้งานการแนบไฟล์"
            '
            'grbFTP
            '
            Me.grbFTP.Controls.Add(Me.txtInternalFTP)
            Me.grbFTP.Controls.Add(Me.lblIn)
            Me.grbFTP.Controls.Add(Me.txtExternalFTP)
            Me.grbFTP.Controls.Add(Me.txtUsername)
            Me.grbFTP.Controls.Add(Me.txtPassword)
            Me.grbFTP.Controls.Add(Me.txtPath)
            Me.grbFTP.Controls.Add(Me.lblEx)
            Me.grbFTP.Controls.Add(Me.lblUsername)
            Me.grbFTP.Controls.Add(Me.lblPass)
            Me.grbFTP.Controls.Add(Me.lblPath)
            Me.grbFTP.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbFTP.Location = New System.Drawing.Point(8, 72)
            Me.grbFTP.Name = "grbFTP"
            Me.grbFTP.Size = New System.Drawing.Size(424, 168)
            Me.grbFTP.TabIndex = 0
            Me.grbFTP.TabStop = False
            Me.grbFTP.Text = "ข้อมูลเกี่ยวกับ Server"
            '
            'txtInternalFTP
            '
            Me.txtInternalFTP.Location = New System.Drawing.Point(144, 32)
            Me.txtInternalFTP.Name = "txtInternalFTP"
            Me.txtInternalFTP.Size = New System.Drawing.Size(248, 21)
            Me.txtInternalFTP.TabIndex = 3
            Me.txtInternalFTP.Text = ""
            '
            'lblIn
            '
            Me.lblIn.Location = New System.Drawing.Point(32, 32)
            Me.lblIn.Name = "lblIn"
            Me.lblIn.Size = New System.Drawing.Size(100, 24)
            Me.lblIn.TabIndex = 2
            Me.lblIn.Text = "FTP Server ภายใน"
            Me.lblIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtExternalFTP
            '
            Me.txtExternalFTP.Location = New System.Drawing.Point(144, 56)
            Me.txtExternalFTP.Name = "txtExternalFTP"
            Me.txtExternalFTP.Size = New System.Drawing.Size(248, 21)
            Me.txtExternalFTP.TabIndex = 3
            Me.txtExternalFTP.Text = ""
            '
            'txtUsername
            '
            Me.txtUsername.Location = New System.Drawing.Point(144, 80)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(160, 21)
            Me.txtUsername.TabIndex = 3
            Me.txtUsername.Text = ""
            '
            'txtPassword
            '
            Me.txtPassword.Location = New System.Drawing.Point(144, 104)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.Size = New System.Drawing.Size(160, 21)
            Me.txtPassword.TabIndex = 3
            Me.txtPassword.Text = ""
            '
            'txtPath
            '
            Me.txtPath.Location = New System.Drawing.Point(144, 128)
            Me.txtPath.Name = "txtPath"
            Me.txtPath.Size = New System.Drawing.Size(248, 21)
            Me.txtPath.TabIndex = 3
            Me.txtPath.Text = ""
            '
            'lblEx
            '
            Me.lblEx.Location = New System.Drawing.Point(16, 56)
            Me.lblEx.Name = "lblEx"
            Me.lblEx.Size = New System.Drawing.Size(112, 24)
            Me.lblEx.TabIndex = 2
            Me.lblEx.Text = "FTP Server ภายนอก"
            Me.lblEx.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUsername
            '
            Me.lblUsername.Location = New System.Drawing.Point(32, 80)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.Size = New System.Drawing.Size(100, 24)
            Me.lblUsername.TabIndex = 2
            Me.lblUsername.Text = "ชื่อผู้ใช้"
            Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPass
            '
            Me.lblPass.Location = New System.Drawing.Point(32, 104)
            Me.lblPass.Name = "lblPass"
            Me.lblPass.Size = New System.Drawing.Size(100, 24)
            Me.lblPass.TabIndex = 2
            Me.lblPass.Text = "รหัสผ่าน"
            Me.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPath
            '
            Me.lblPath.Location = New System.Drawing.Point(32, 128)
            Me.lblPath.Name = "lblPath"
            Me.lblPath.Size = New System.Drawing.Size(100, 24)
            Me.lblPath.TabIndex = 2
            Me.lblPath.Text = "Path ในการใช้งาน"
            Me.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'AttachmentConfigurationView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.grbFTP)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "AttachmentConfigurationView"
            Me.Size = New System.Drawing.Size(448, 280)
            Me.grbDetail.ResumeLayout(False)
            Me.grbFTP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_isInitialized As Boolean
        Public ConfigFilters(5) As Filter
        Private Dirty As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Me.SetLabelText()
            Initialize()
            EventWiring()
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
        Public Sub CheckFormEnable()
        End Sub
        Public Sub ClearDetail()
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AttachmentConfigurationView.grbDetail}")
            Me.grbFTP.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AttachmentConfigurationView.grbFTP}")

            Me.chkUseAttachment.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AttachmentConfigurationView.chkUseAttachment}")

            Me.lblIn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AttachmentConfigurationView.lblIn}")
            Me.lblEx.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AttachmentConfigurationView.lblEx}")
            Me.lblUsername.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AttachmentConfigurationView.lblUsername}")
            Me.lblPass.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AttachmentConfigurationView.lblPass}")
            Me.lblPath.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AttachmentConfigurationView.lblPath}")
        End Sub
        Protected Sub EventWiring()
            AddHandler chkUseAttachment.CheckedChanged, AddressOf ChangeProperty

            AddHandler txtInternalFTP.TextChanged, AddressOf ChangeProperty
            AddHandler txtExternalFTP.TextChanged, AddressOf ChangeProperty
            AddHandler txtUsername.TextChanged, AddressOf ChangeProperty
            AddHandler txtPassword.TextChanged, AddressOf ChangeProperty
            AddHandler txtPath.TextChanged, AddressOf ChangeProperty

            AddHandler txtInternalFTP.Validated, AddressOf TextHandler
            AddHandler txtExternalFTP.Validated, AddressOf TextHandler
            AddHandler txtUsername.Validated, AddressOf TextHandler
            AddHandler txtPassword.Validated, AddressOf TextHandler
            AddHandler txtPath.Validated, AddressOf TextHandler
        End Sub
        Public Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "txtinternalftp"
                    Me.SetFilterValue("InternalFTPServer", Me.txtInternalFTP.Text)
                Case "txtexternalftp"
                    Me.SetFilterValue("ExternalFTPServer", Me.txtExternalFTP.Text)
                Case "txtusername"
                    Me.SetFilterValue("FTPUsername", Me.txtUsername.Text)
                Case "txtpassword"
                    Me.SetFilterValue("FTPPassword", Me.txtPassword.Text)
                Case "txtpath"
                    Me.SetFilterValue("FTPDefaultPath", Me.txtPath.Text)
            End Select
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "chkuseattachment"
                    Me.SetFilterValue("UseAttachment", chkUseAttachment.Checked)
                    dirtyFlag = True
                Case "txtinternalftp"
                    dirtyFlag = True
                Case "txtexternalftp"
                    dirtyFlag = True
                Case "txtusername"
                    dirtyFlag = True
                Case "txtpassword"
                    dirtyFlag = True
                Case "txtpath"
                    dirtyFlag = True
            End Select
            Dirty = Dirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Sub Initialize()
            ConfigFilters(0) = New Filter("UseAttachment", Configuration.GetConfig("UseAttachment"))
            ConfigFilters(1) = New Filter("InternalFTPServer", Configuration.GetConfig("InternalFTPServer"))
            ConfigFilters(2) = New Filter("ExternalFTPServer", Configuration.GetConfig("ExternalFTPServer"))
            ConfigFilters(3) = New Filter("FTPUsername", Configuration.GetConfig("FTPUsername"))
            ConfigFilters(4) = New Filter("FTPPassword", Configuration.GetConfig("FTPPassword"))
            ConfigFilters(5) = New Filter("FTPDefaultPath", Configuration.GetConfig("FTPDefaultPath"))
        End Sub
        Private Sub SetFilterValue(ByVal name As String, ByVal value As Object)
            For Each filter As filter In ConfigFilters
                If filter.Name.ToLower = name.ToLower Then
                    filter.Value = value
                    Exit For
                End If
            Next
        End Sub
        Private Function GetFilterValue(ByVal name As String) As Object
            For Each filter As filter In ConfigFilters
                If filter.Name.ToLower = name.ToLower Then
                    Return filter.Value
                End If
            Next
        End Function
#End Region

#Region "Methods"
#End Region

#Region "Event Handers"
        Private Sub ibtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
#End Region

#Region "Overrides"
        Public Overloads Overrides Sub LoadPanelContents()
            m_isInitialized = False
            ClearDetail()

            Me.chkUseAttachment.Checked = CBool(GetFilterValue("UseAttachment"))

            Me.txtInternalFTP.Text = GetFilterValue("InternalFTPServer")
            Me.txtExternalFTP.Text = GetFilterValue("ExternalFTPServer")
            Me.txtUsername.Text = GetFilterValue("FTPUsername")
            Me.txtPassword.Text = GetFilterValue("FTPPassword")
            Me.txtPath.Text = GetFilterValue("FTPDefaultPath")

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Overloads Overrides Function StorePanelContents() As Boolean
            If Not m_isInitialized Then
                Return True
            End If
            If Not Dirty Then
                Return True
            End If
            Configuration.Save(Me.ConfigFilters)
            Return True
        End Function
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

    End Class
End Namespace