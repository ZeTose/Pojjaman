Imports Longkong.Pojjaman.Gui.XmlForms
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Dialogs
  Public Class AboutPojjamanTabPage
    Inherits UserControl

#Region "Members"
    Friend WithEvents m_versionLabel As System.Windows.Forms.Label
    Friend WithEvents m_versionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents m_buildLabel As System.Windows.Forms.Label
    Friend WithEvents m_buildTextBox As System.Windows.Forms.TextBox
    Friend WithEvents m_dbVersionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents m_dbVersionLabel As System.Windows.Forms.Label
    Friend WithEvents lblLicense As System.Windows.Forms.Label
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      Dim pjmVersion As Version = [Assembly].GetEntryAssembly.GetName.Version
      Dim pjmVersionArray As Object() = New Object() {pjmVersion.Major, ".", pjmVersion.Minor.ToString("00"), ".", pjmVersion.Build.ToString("0000")}
      Me.m_versionTextBox.Text = String.Concat(pjmVersionArray)
      Me.m_buildTextBox.Text = pjmVersion.Revision.ToString
      Dim service1 As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
      Me.m_versionLabel.Text = service1.GetString("Dialog.About.m_versionLabelText")
      Me.m_buildLabel.Text = service1.GetString("Dialog.About.m_buildLabelText")
      Me.m_dbVersionLabel.Text = service1.GetString("Dialog.About.m_dbVersionLabel")
      Me.m_dbVersionTextBox.Text = Longkong.Pojjaman.DataAccessLayer.SqlHelper.GetRealVersion

      lblLicense.Text = ""

      Dim validLicense As Boolean = False
      Dim availableLicense As Integer = 0
      Dim licenseCount As Integer = 0

      Dim ds As DataSet = User.GetLicenseInfo

      'If ds.Tables(0).Rows(0).IsNull("machineCode") Then
      If Not ds.Tables(0).Rows(0).IsNull("licenseday") Then
        'No View
        Dim remainingDay As Integer = CInt(ds.Tables(2).Rows(0)("remainingday"))
        If remainingDay > 0 Then
          lblLicense.Text = String.Format("Demo time Left:{0} Days", remainingDay)
        End If
      Else
        'ау view
        Dim machineCode As String = User.BytesToHexSmall(CType(ds.Tables(0).Rows(0)("machineCode"), Byte())) 'ds.Tables(0).Rows(0)("machineCode").ToString()
        availableLicense = CInt(ds.Tables(0).Rows(0)("license"))
        Dim s As String = availableLicense.ToString() + User.SALT + machineCode
        s = User.GetMD5Hash(s)
        Dim checkSum As String = ds.Tables(0).Rows(0)("pepper").ToString.ToLower 'User.BytesToHexSmall(CType(ds.Tables(0).Rows(0)("pepper"), Byte()))
        If s <> checkSum Then
          availableLicense = -1
          lblLicense.Text = String.Format("License is Changed: machineCode = {0}, available = {1} , checksum = {2}", machineCode, availableLicense, checkSum)
        Else
          licenseCount = CInt(ds.Tables(1).Rows(0)("hostnumber"))
          lblLicense.Text = String.Format("License Usage: {0} / {1} ", licenseCount, availableLicense)
        End If
      End If
    End Sub
    Private Sub InitializeComponent()
      Me.m_versionLabel = New System.Windows.Forms.Label
      Me.m_versionTextBox = New System.Windows.Forms.TextBox
      Me.m_buildLabel = New System.Windows.Forms.Label
      Me.m_buildTextBox = New System.Windows.Forms.TextBox
      Me.m_dbVersionTextBox = New System.Windows.Forms.TextBox
      Me.m_dbVersionLabel = New System.Windows.Forms.Label
      Me.lblLicense = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'm_versionLabel
      '
      Me.m_versionLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.m_versionLabel.Location = New System.Drawing.Point(8, 16)
      Me.m_versionLabel.Name = "m_versionLabel"
      Me.m_versionLabel.TabIndex = 0
      Me.m_versionLabel.Text = "m_versionLabel"
      Me.m_versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'm_versionTextBox
      '
      Me.m_versionTextBox.Location = New System.Drawing.Point(120, 17)
      Me.m_versionTextBox.Name = "m_versionTextBox"
      Me.m_versionTextBox.ReadOnly = True
      Me.m_versionTextBox.Size = New System.Drawing.Size(144, 20)
      Me.m_versionTextBox.TabIndex = 1
      Me.m_versionTextBox.Text = ""
      '
      'm_buildLabel
      '
      Me.m_buildLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.m_buildLabel.Location = New System.Drawing.Point(8, 48)
      Me.m_buildLabel.Name = "m_buildLabel"
      Me.m_buildLabel.TabIndex = 2
      Me.m_buildLabel.Text = "m_buildLabel"
      Me.m_buildLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'm_buildTextBox
      '
      Me.m_buildTextBox.Location = New System.Drawing.Point(120, 49)
      Me.m_buildTextBox.Name = "m_buildTextBox"
      Me.m_buildTextBox.ReadOnly = True
      Me.m_buildTextBox.Size = New System.Drawing.Size(144, 20)
      Me.m_buildTextBox.TabIndex = 3
      Me.m_buildTextBox.Text = ""
      '
      'm_dbVersionTextBox
      '
      Me.m_dbVersionTextBox.Location = New System.Drawing.Point(120, 81)
      Me.m_dbVersionTextBox.Name = "m_dbVersionTextBox"
      Me.m_dbVersionTextBox.ReadOnly = True
      Me.m_dbVersionTextBox.Size = New System.Drawing.Size(144, 20)
      Me.m_dbVersionTextBox.TabIndex = 5
      Me.m_dbVersionTextBox.Text = ""
      '
      'm_dbVersionLabel
      '
      Me.m_dbVersionLabel.Location = New System.Drawing.Point(8, 81)
      Me.m_dbVersionLabel.Name = "m_dbVersionLabel"
      Me.m_dbVersionLabel.TabIndex = 4
      Me.m_dbVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLicense
      '
      Me.lblLicense.Location = New System.Drawing.Point(48, 120)
      Me.lblLicense.Name = "lblLicense"
      Me.lblLicense.Size = New System.Drawing.Size(432, 23)
      Me.lblLicense.TabIndex = 6
      Me.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'AboutPojjamanTabPage
      '
      Me.Controls.Add(Me.lblLicense)
      Me.Controls.Add(Me.m_buildTextBox)
      Me.Controls.Add(Me.m_buildLabel)
      Me.Controls.Add(Me.m_versionTextBox)
      Me.Controls.Add(Me.m_versionLabel)
      Me.Controls.Add(Me.m_dbVersionTextBox)
      Me.Controls.Add(Me.m_dbVersionLabel)
      Me.Name = "AboutPojjamanTabPage"
      Me.Size = New System.Drawing.Size(528, 168)
      Me.ResumeLayout(False)

    End Sub
#End Region

  End Class
End Namespace

