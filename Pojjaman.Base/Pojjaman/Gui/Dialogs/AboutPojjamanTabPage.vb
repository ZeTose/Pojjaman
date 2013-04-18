Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.XmlForms
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Dialogs
  Public Class AboutPojjamanTabPage
    Inherits UserControl

#Region "Members"
    Friend WithEvents m_versionLabel As System.Windows.Forms.Label
    Friend WithEvents m_versionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents m_dbVersionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents m_dbVersionLabel As System.Windows.Forms.Label
    Friend WithEvents lblLicense As System.Windows.Forms.Label
    Private m_availableLicense As Integer
    Public Shared timerT As Timer
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      Dim pjmVersion As Version = [Assembly].GetEntryAssembly.GetName.Version
      Dim pjmRealVersion As String = clsAssInfo.RealVersion
      Dim pjmVersionArray As Object() = New Object() {pjmVersion.Major, ".", _
                                                      pjmVersion.Minor.ToString("00"), ".", _
                                                      pjmVersion.Build.ToString("0000"), "", _
                                                      pjmRealVersion}

      Me.m_versionTextBox.Text = String.Concat(pjmVersionArray)
      'Me.m_buildTextBox.Text = Me.m_versionTextBox.Text.Trim & "" & pjmRealVersion   'pjmVersion.Revision.ToString
      Dim service1 As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
      If Longkong.Pojjaman.BusinessLogic.Configuration.CheckGigaSiteRight Then
        Me.m_versionLabel.Text = "Gigasite Version"
      Else
      Me.m_versionLabel.Text = service1.GetString("Dialog.About.m_versionLabelText")
      End If
      'Me.m_buildLabel.Text = service1.GetString("Dialog.About.m_buildLabelText")
      Me.m_dbVersionLabel.Text = service1.GetString("Dialog.About.m_dbVersionLabel")
      Me.m_dbVersionTextBox.Text = Longkong.Pojjaman.DataAccessLayer.SqlHelper.GetRealVersion

      lblLicense.Text = ""
      m_availableLicense = 0
      User.LicenseCount = 0

      Dim validLicense As Boolean = False
      'Dim availableLicense As Integer = 0
      'Dim licenseCount As Integer = 0

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
        m_availableLicense = CInt(ds.Tables(0).Rows(0)("license"))
        Dim s As String = m_availableLicense.ToString() + User.SALT + machineCode
        s = User.GetMD5Hash(s)
        Dim checkSum As String = ds.Tables(0).Rows(0)("pepper").ToString.ToLower 'User.BytesToHexSmall(CType(ds.Tables(0).Rows(0)("pepper"), Byte()))
        If s <> checkSum Then
          m_availableLicense = -1
          lblLicense.Text = String.Format("License is Changed: machineCode = {0}, available = {1} , checksum = {2}", machineCode, m_availableLicense, checkSum)
        Else
          User.LicenseCount = CInt(ds.Tables(1).Rows(0)("hostnumber"))
          lblLicense.Text = String.Format("License Usage : {0} / {1} ", User.LicenseCount, m_availableLicense)

          timerT = New Timer
          timerT.Interval = 1000
          AddHandler timerT.Tick, AddressOf TimerEvent
          timerT.Start()
        End If
      End If

    End Sub
    Private Sub TimerEvent(ByVal sender As Object, ByVal e As EventArgs)
      lblLicense.Text = String.Format("License Usage : {0} / {1} ", User.LicenseCount, m_availableLicense)
    End Sub
    Private Sub InitializeComponent()
      Me.m_versionLabel = New System.Windows.Forms.Label()
      Me.m_versionTextBox = New System.Windows.Forms.TextBox()
      Me.m_dbVersionTextBox = New System.Windows.Forms.TextBox()
      Me.m_dbVersionLabel = New System.Windows.Forms.Label()
      Me.lblLicense = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'm_versionLabel
      '
      Me.m_versionLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.m_versionLabel.Location = New System.Drawing.Point(16, 11)
      Me.m_versionLabel.Name = "m_versionLabel"
      Me.m_versionLabel.Size = New System.Drawing.Size(100, 23)
      Me.m_versionLabel.TabIndex = 0
      Me.m_versionLabel.Text = "m_versionLabel"
      Me.m_versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'm_versionTextBox
      '
      Me.m_versionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.m_versionTextBox.Location = New System.Drawing.Point(120, 11)
      Me.m_versionTextBox.Name = "m_versionTextBox"
      Me.m_versionTextBox.ReadOnly = True
      Me.m_versionTextBox.Size = New System.Drawing.Size(263, 20)
      Me.m_versionTextBox.TabIndex = 1
      '
      'm_dbVersionTextBox
      '
      Me.m_dbVersionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.m_dbVersionTextBox.Location = New System.Drawing.Point(120, 37)
      Me.m_dbVersionTextBox.Name = "m_dbVersionTextBox"
      Me.m_dbVersionTextBox.ReadOnly = True
      Me.m_dbVersionTextBox.Size = New System.Drawing.Size(263, 20)
      Me.m_dbVersionTextBox.TabIndex = 5
      '
      'm_dbVersionLabel
      '
      Me.m_dbVersionLabel.Location = New System.Drawing.Point(17, 37)
      Me.m_dbVersionLabel.Name = "m_dbVersionLabel"
      Me.m_dbVersionLabel.Size = New System.Drawing.Size(100, 23)
      Me.m_dbVersionLabel.TabIndex = 4
      Me.m_dbVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLicense
      '
      Me.lblLicense.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblLicense.Location = New System.Drawing.Point(38, 68)
      Me.lblLicense.Name = "lblLicense"
      Me.lblLicense.Size = New System.Drawing.Size(345, 23)
      Me.lblLicense.TabIndex = 6
      Me.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'AboutPojjamanTabPage
      '
      Me.Controls.Add(Me.lblLicense)
      Me.Controls.Add(Me.m_versionTextBox)
      Me.Controls.Add(Me.m_versionLabel)
      Me.Controls.Add(Me.m_dbVersionTextBox)
      Me.Controls.Add(Me.m_dbVersionLabel)
      Me.Name = "AboutPojjamanTabPage"
      Me.Size = New System.Drawing.Size(407, 241)
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub
#End Region

    Private Sub AboutPojjamanTabPage_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
      Try
        timerT.Stop()
        timerT.Dispose()
      Catch ex As Exception

      End Try
    End Sub
  End Class
End Namespace

