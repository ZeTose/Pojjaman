Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.XmlForms
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Dialogs
  Public Class AboutLicenseTabPage
    Inherits UserControl

#Region "Members"
    'Friend WithEvents m_dbVersionLabel As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      'Dim pjmVersion As Version = [Assembly].GetEntryAssembly.GetName.Version
      'Dim pjmRealVersion As String = clsAssInfo.RealVersion
      'Dim pjmVersionArray As Object() = New Object() {pjmVersion.Major, ".", _
      '                                                pjmVersion.Minor.ToString("00"), ".", _
      '                                                pjmVersion.Build.ToString("0000"), ".", _
      '                                                pjmRealVersion}

      'Me.m_versionTextBox.Text = String.Concat(pjmVersionArray)
      ''Me.m_buildTextBox.Text = Me.m_versionTextBox.Text.Trim & "" & pjmRealVersion   'pjmVersion.Revision.ToString
      'Dim service1 As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
      'Me.m_versionLabel.Text = service1.GetString("Dialog.About.m_versionLabelText")
      ''Me.m_buildLabel.Text = service1.GetString("Dialog.About.m_buildLabelText")
      'Me.m_dbVersionLabel.Text = service1.GetString("Dialog.About.m_dbVersionLabel")
      'Me.m_dbVersionTextBox.Text = Longkong.Pojjaman.DataAccessLayer.SqlHelper.GetRealVersion

      'lblLicense.Text = ""

      'Dim validLicense As Boolean = False
      'Dim availableLicense As Integer = 0
      'Dim licenseCount As Integer = 0

      'Dim ds As DataSet = User.GetLicenseInfo

      ''If ds.Tables(0).Rows(0).IsNull("machineCode") Then
      'If Not ds.Tables(0).Rows(0).IsNull("licenseday") Then
      '  'No View
      '  Dim remainingDay As Integer = CInt(ds.Tables(2).Rows(0)("remainingday"))
      '  If remainingDay > 0 Then
      '    lblLicense.Text = String.Format("Demo time Left:{0} Days", remainingDay)
      '  End If
      'Else
      '  'ау view
      '  Dim machineCode As String = User.BytesToHexSmall(CType(ds.Tables(0).Rows(0)("machineCode"), Byte())) 'ds.Tables(0).Rows(0)("machineCode").ToString()
      '  availableLicense = CInt(ds.Tables(0).Rows(0)("license"))
      '  Dim s As String = availableLicense.ToString() + User.SALT + machineCode
      '  s = User.GetMD5Hash(s)
      '  Dim checkSum As String = ds.Tables(0).Rows(0)("pepper").ToString.ToLower 'User.BytesToHexSmall(CType(ds.Tables(0).Rows(0)("pepper"), Byte()))
      '  If s <> checkSum Then
      '    availableLicense = -1
      '    lblLicense.Text = String.Format("License is Changed: machineCode = {0}, available = {1} , checksum = {2}", machineCode, availableLicense, checkSum)
      '  Else
      '    licenseCount = CInt(ds.Tables(1).Rows(0)("hostnumber"))
      '    lblLicense.Text = String.Format("License Usage : {0} / {1} ", licenseCount, availableLicense)
      '  End If
      'End If

      Me.SetListview()

    End Sub
    Private Sub SetListview()
      Dim ds As DataSet = User.GetUserConnecting
      If ds Is Nothing OrElse ds.Tables(0).Rows.Count = 0 Then
        ListView1.Visible = False
      Else
        ListView1.Visible = True
      End If

      ListView1.Columns.Add("#", 25)
      ListView1.Columns.Add("Database", 90)
      ListView1.Columns.Add("Client", 80)
      ListView1.Columns.Add("Account", 80)
      ListView1.Columns.Add("Login", 80)

      Dim linenumber As Integer = 0
      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        linenumber += 1

        Dim itx As New ListViewItem
        itx.Text = linenumber.ToString
        itx.SubItems.Add(drh.GetValue(Of String)("dbname"))
        itx.SubItems.Add(drh.GetValue(Of String)("hostname"))
        SetAccountName(itx, drh.GetValue(Of String)("program_name"))
        ListView1.Items.Add(itx)
      Next

    End Sub
    Private Sub SetAccountName(ByVal lvi As ListViewItem, ByVal progname As String)
      If progname.Length = 0 Then
        lvi.SubItems.Add("")
        lvi.SubItems.Add("")
      End If
      Dim newprogname() As String = progname.Split("-"c)

      lvi.SubItems.Add(newprogname(1))
      lvi.SubItems.Add(newprogname(2))
    End Sub
    Private Sub InitializeComponent()
      Me.ListView1 = New System.Windows.Forms.ListView()
      Me.SuspendLayout()
      '
      'ListView1
      '
      Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ListView1.Location = New System.Drawing.Point(10, 10)
      Me.ListView1.Name = "ListView1"
      Me.ListView1.Size = New System.Drawing.Size(371, 168)
      Me.ListView1.TabIndex = 7
      Me.ListView1.UseCompatibleStateImageBehavior = False
      Me.ListView1.View = System.Windows.Forms.View.Details
      '
      'AboutLicenseTabPage
      '
      Me.Controls.Add(Me.ListView1)
      Me.Name = "AboutLicenseTabPage"
      Me.Size = New System.Drawing.Size(407, 241)
      Me.ResumeLayout(False)

    End Sub
#End Region

  End Class
End Namespace

