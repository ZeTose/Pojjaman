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
    Private hashListConnect As Hashtable
    Private lvt As Timer
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
      hashListConnect = New Hashtable
      Me.SetListview()

    End Sub
    Private Sub SetListview()
      ListView1.Columns.Add("#", 25)
      ListView1.Columns.Add("Database", 90)
      ListView1.Columns.Add("Client", 80)
      ListView1.Columns.Add("Account", 80)
      ListView1.Columns.Add("Login", 80)

      RefreshList()

      lvt = New Timer
      lvt.Interval = 1000
      AddHandler lvt.Tick, AddressOf TimerEvent
      lvt.Start()
    End Sub
    Private Sub TimerEvent(ByVal sender As Object, ByVal e As EventArgs)
      RefreshList()
    End Sub
    Private Sub RefreshList()
      Dim ds As DataSet = User.GetUserConnecting

      Dim spid As Decimal = 0

      'If ds Is Nothing OrElse ds.Tables(0).Rows.Count = 0 Then
      '  ListView1.Visible = False
      'Else
      '  ListView1.Visible = True
      'End If

      'ListView1.Items.Clear()

      Dim linenumber As Integer = 0
      For Each row As DataRow In ds.Tables(0).Rows
        'For i As Integer = ds.Tables(0).Rows.Count - 1 To 0 Step -1
        '  Dim row As DataRow = ds.Tables(0).Rows(i)
        Dim drh As New DataRowHelper(row)
        linenumber += 1
        spid = drh.GetValue(Of Decimal)("spid")

        If Not hashListConnect.ContainsKey(spid) Then
          Dim itx As New ListViewItem
          'itx.Text = linenumber.ToString
          itx.SubItems.Add(drh.GetValue(Of String)("dbname"))
          itx.SubItems.Add(drh.GetValue(Of String)("hostname"))
          SetAccountName(itx, drh.GetValue(Of String)("program_name"))
          itx.Tag = spid
          ListView1.Items.Insert(0, itx)
          hashListConnect(spid) = itx
          'Else
          '  Dim itxd As ListViewItem = Nothing
          '  Dim found As Boolean = False
          '  For Each itx As ListViewItem In ListView1.Items
          '    If CInt(itx.Tag) = spid Then
          '      found = True
          '      Exit For
          '    End If
          '    itxd = itx
          '  Next
          '  If Not found Then
          '    ListView1.Items.Remove(itxd)
          '  End If
        End If

      Next

      Dim itxList As New ArrayList
      For Each itx As ListViewItem In ListView1.Items
        spid = CDec(itx.Tag)
        Dim dr() As DataRow = ds.Tables(0).Select("spid='" & spid.ToString & "'")
        If dr.Length = 0 Then
          itxList.Add(itx)
        End If
      Next
      For Each itx As ListViewItem In itxList
        ListView1.Items.Remove(itx)
      Next

      Dim crAllListCout As Integer = ListView1.Items.Count
      For Each itx As ListViewItem In ListView1.Items
        itx.Text = crAllListCout.ToString
        crAllListCout -= 1
      Next

      User.LicenseCount = linenumber
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
      Me.ListView1.MultiSelect = True
      Me.ListView1.FullRowSelect = True
      '
      'AboutLicenseTabPage
      '
      Me.Controls.Add(Me.ListView1)
      Me.Name = "AboutLicenseTabPage"
      Me.Size = New System.Drawing.Size(407, 241)
      Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub AboutLicenseTabPage_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
      lvt.Stop()
      lvt.Dispose()
    End Sub
  End Class
End Namespace

