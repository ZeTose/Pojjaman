Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Text.RegularExpressions
Namespace Pojjaman.DatabaseSetting
    Public Class DBSettingForm
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
        Friend WithEvents lvItem As System.Windows.Forms.ListView
        Friend WithEvents txtConnString As System.Windows.Forms.TextBox
        Friend WithEvents lblConnString As System.Windows.Forms.Label
        Friend WithEvents lblSiteConnString As System.Windows.Forms.Label
        Friend WithEvents txtSiteConnString As System.Windows.Forms.TextBox
        Friend WithEvents ibtnBlank As System.Windows.Forms.Button
        Friend WithEvents ibtnDelRow As System.Windows.Forms.Button
        Friend WithEvents ibtnShowConnString As System.Windows.Forms.Button
        Friend WithEvents ibtnShowSiteConnString As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lvItem = New System.Windows.Forms.ListView
            Me.txtConnString = New System.Windows.Forms.TextBox
            Me.lblConnString = New System.Windows.Forms.Label
            Me.lblSiteConnString = New System.Windows.Forms.Label
            Me.txtSiteConnString = New System.Windows.Forms.TextBox
            Me.ibtnBlank = New System.Windows.Forms.Button
            Me.ibtnDelRow = New System.Windows.Forms.Button
            Me.ibtnShowConnString = New System.Windows.Forms.Button
            Me.ibtnShowSiteConnString = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'lvItem
            '
            Me.lvItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lvItem.FullRowSelect = True
            Me.lvItem.GridLines = True
            Me.lvItem.HideSelection = False
            Me.lvItem.Location = New System.Drawing.Point(8, 64)
            Me.lvItem.MultiSelect = False
            Me.lvItem.Name = "lvItem"
            Me.lvItem.Size = New System.Drawing.Size(744, 392)
            Me.lvItem.TabIndex = 4
            Me.lvItem.View = System.Windows.Forms.View.Details
            '
            'txtConnString
            '
            Me.txtConnString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtConnString.Location = New System.Drawing.Point(192, 8)
            Me.txtConnString.Name = "txtConnString"
            Me.txtConnString.ReadOnly = True
            Me.txtConnString.Size = New System.Drawing.Size(536, 20)
            Me.txtConnString.TabIndex = 7
            Me.txtConnString.TabStop = False
            Me.txtConnString.Text = ""
            '
            'lblConnString
            '
            Me.lblConnString.Location = New System.Drawing.Point(88, 7)
            Me.lblConnString.Name = "lblConnString"
            Me.lblConnString.TabIndex = 5
            Me.lblConnString.Text = "DB หลัก:"
            Me.lblConnString.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSiteConnString
            '
            Me.lblSiteConnString.Location = New System.Drawing.Point(88, 31)
            Me.lblSiteConnString.Name = "lblSiteConnString"
            Me.lblSiteConnString.TabIndex = 6
            Me.lblSiteConnString.Text = "DB Site:"
            Me.lblSiteConnString.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSiteConnString
            '
            Me.txtSiteConnString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtSiteConnString.Location = New System.Drawing.Point(192, 32)
            Me.txtSiteConnString.Name = "txtSiteConnString"
            Me.txtSiteConnString.ReadOnly = True
            Me.txtSiteConnString.Size = New System.Drawing.Size(536, 20)
            Me.txtSiteConnString.TabIndex = 8
            Me.txtSiteConnString.TabStop = False
            Me.txtSiteConnString.Text = ""
            '
            'ibtnBlank
            '
            Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnBlank.Location = New System.Drawing.Point(8, 32)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 23)
            Me.ibtnBlank.TabIndex = 2
            Me.ibtnBlank.Text = "+"
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnDelRow.Location = New System.Drawing.Point(40, 32)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 23)
            Me.ibtnDelRow.TabIndex = 3
            Me.ibtnDelRow.Text = "-"
            '
            'ibtnShowConnString
            '
            Me.ibtnShowConnString.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowConnString.Location = New System.Drawing.Point(728, 8)
            Me.ibtnShowConnString.Name = "ibtnShowConnString"
            Me.ibtnShowConnString.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowConnString.TabIndex = 0
            Me.ibtnShowConnString.Text = "?"
            '
            'ibtnShowSiteConnString
            '
            Me.ibtnShowSiteConnString.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowSiteConnString.Location = New System.Drawing.Point(728, 32)
            Me.ibtnShowSiteConnString.Name = "ibtnShowSiteConnString"
            Me.ibtnShowSiteConnString.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowSiteConnString.TabIndex = 1
            Me.ibtnShowSiteConnString.Text = "?"
            '
            'DBSettingForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(760, 470)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.lblConnString)
            Me.Controls.Add(Me.txtConnString)
            Me.Controls.Add(Me.txtSiteConnString)
            Me.Controls.Add(Me.lvItem)
            Me.Controls.Add(Me.lblSiteConnString)
            Me.Controls.Add(Me.ibtnShowConnString)
            Me.Controls.Add(Me.ibtnShowSiteConnString)
            Me.Name = "DBSettingForm"
            Me.ShowInTaskbar = False
            Me.Text = "ตั้งค่าฐานข้อมูล"
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_properties As PropertyService
        Private m_recentCompanies As RecentCompanies
        Private StringParserService As StringParserService
        Private m_selectedCompany As Company
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
        Private m_isInit As Boolean = False
        Private Sub Initialize()
            Me.m_recentCompanies = CType(m_properties.GetProperty("Longkong.Pojjaman.RecentCompanies", New RecentCompanies), RecentCompanies)
            lvItem.Columns.Add("ชื่อ", 100, HorizontalAlignment.Center)
            lvItem.Columns.Add("Database หลัก", 300, HorizontalAlignment.Center)
            lvItem.Columns.Add("Database Site", 300, HorizontalAlignment.Center)
            UpdateDBList()
        End Sub
        Private Sub UpdateDBList()
            m_isInit = False
            Dim oldIndex As Integer = 0
            If lvItem.SelectedItems.Count > 0 Then
                oldIndex = lvItem.Items.IndexOf(lvItem.SelectedItems(0))
            End If
            lvItem.Items.Clear()
            For Each co As Company In m_recentCompanies.RecentCompanies
                Dim item As ListViewItem = lvItem.Items.Add(co.Name)
                item.SubItems.Add(co.ConnectionString)
                item.SubItems.Add(co.SiteConnectionString)
                item.Tag = co
            Next
            If Me.lvItem.Items.Count = 0 Then
                m_isInit = True
                Return
            End If
            If Me.lvItem.Items.Count - 1 < oldIndex Then
                oldIndex = Me.lvItem.Items.Count - 1
            End If
            lvItem.Items(oldIndex).Selected = True
            m_isInit = True
        End Sub
        Private Sub SetLabelText()
            'Me.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.Text}")
            'Me.btnOK.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.btnOK}")
            'Me.btnCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.btnCancel}")
            'Me.lblLoginName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.lblLoginName}")
            'Me.lblCompany.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.lblCompany}")
            'Me.lblPassword.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.LoginDialog.lblPassword}")
        End Sub
#End Region

        Private Sub lvItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.SelectedIndexChanged
            If Not m_isInit Then
                Return
            End If
            If lvItem.SelectedItems.Count > 0 Then
                m_selectedCompany = CType(lvItem.SelectedItems(0).Tag, Company)
            Else
                m_selectedCompany = Nothing
            End If
            UpdateCompany()
        End Sub
        Private Sub UpdateCompany()
            If m_selectedCompany Is Nothing Then
                Me.txtConnString.Text = ""
                Me.txtSiteConnString.Text = ""
            Else
                Me.txtConnString.Text = m_selectedCompany.ConnectionString
                Me.txtSiteConnString.Text = m_selectedCompany.SiteConnectionString
            End If
        End Sub
        Private Sub ibtnShowConnString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowConnString.Click, ibtnShowSiteConnString.Click
            If m_selectedCompany Is Nothing Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "ibtnshowconnstring"
                    m_selectedCompany.ConnectionString = SqlHelper.GetConnString(m_selectedCompany.ConnectionString)
                Case "ibtnshowsiteconnstring"
                    m_selectedCompany.SiteConnectionString = SqlHelper.GetConnString(m_selectedCompany.SiteConnectionString)
            End Select
            UpdateDBList()
            UpdateCompany()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim id As Integer = MaxIndex()
            Dim name As String = Microsoft.VisualBasic.InputBox("กรุณาระบุชื่อบริษัท", "ชื่อบริษัท", "DB" & id.ToString)
            If name.Length = 0 Then
                name = "DB" & id.ToString
            End If
            m_recentCompanies.AddCompany(name, "")
            UpdateDBList()
            If lvItem.Items.Count > 0 Then
                lvItem.Items(0).Selected = True
            End If
            UpdateCompany()
            m_selectedCompany.ConnectionString = SqlHelper.GetConnString(m_selectedCompany.ConnectionString)
            m_selectedCompany.SiteConnectionString = m_selectedCompany.ConnectionString
            UpdateDBList()
            UpdateCompany()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            If m_selectedCompany Is Nothing Then
                Return
            End If
            If lvItem.Items.Count = 1 Then
                Return
            End If
            m_recentCompanies.RecentCompanies.Remove(m_selectedCompany)
            UpdateDBList()
            UpdateCompany()
        End Sub
        Private Function MaxIndex() As Integer
            Dim re As New Regex("DB(\d+)$")
            Dim maxId As Integer = 0
            For Each co As Company In m_recentCompanies.RecentCompanies
                If re.IsMatch(co.Name) Then
                    Dim m As Match = re.Match(co.Name)
                    Dim num As String = m.Groups(1).Value
                    If maxId < CInt(num) Then
                        maxId = CInt(num)
                    End If
                End If
            Next
            Return maxId + 1
        End Function
    End Class
End Namespace

