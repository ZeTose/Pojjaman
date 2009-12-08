Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MaterialDetailFilterSubpanel
        Inherits AbstractFilterSubPanel

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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents txtManagerCode As System.Windows.Forms.TextBox
        Friend WithEvents lblManager As System.Windows.Forms.Label
        Friend WithEvents lblAdmin As System.Windows.Forms.Label
        Friend WithEvents txtAdminCode As System.Windows.Forms.TextBox
        Friend WithEvents txtManagerName As System.Windows.Forms.TextBox
        Friend WithEvents txtAdminName As System.Windows.Forms.TextBox
        Friend WithEvents btnManagerEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnManagerFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAdminEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAdminFind As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MaterialDetailFilterSubpanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnManagerEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnManagerFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnAdminEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnAdminFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtManagerCode = New System.Windows.Forms.TextBox
            Me.lblManager = New System.Windows.Forms.Label
            Me.lblAdmin = New System.Windows.Forms.Label
            Me.txtAdminCode = New System.Windows.Forms.TextBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.txtManagerName = New System.Windows.Forms.TextBox
            Me.txtAdminName = New System.Windows.Forms.TextBox
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 25)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 6
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCode.Location = New System.Drawing.Point(112, 24)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(416, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnManagerEdit)
            Me.grbDetail.Controls.Add(Me.btnManagerFind)
            Me.grbDetail.Controls.Add(Me.btnAdminEdit)
            Me.grbDetail.Controls.Add(Me.btnAdminFind)
            Me.grbDetail.Controls.Add(Me.txtManagerCode)
            Me.grbDetail.Controls.Add(Me.lblManager)
            Me.grbDetail.Controls.Add(Me.lblAdmin)
            Me.grbDetail.Controls.Add(Me.txtAdminCode)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.txtManagerName)
            Me.grbDetail.Controls.Add(Me.txtAdminName)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(808, 136)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            '
            'btnManagerEdit
            '
            Me.btnManagerEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnManagerEdit.Image = CType(resources.GetObject("btnManagerEdit.Image"), System.Drawing.Image)
            Me.btnManagerEdit.Location = New System.Drawing.Point(504, 45)
            Me.btnManagerEdit.Name = "btnManagerEdit"
            Me.btnManagerEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnManagerEdit.TabIndex = 249
            Me.btnManagerEdit.TabStop = False
            Me.btnManagerEdit.ThemedImage = CType(resources.GetObject("btnManagerEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnManagerFind
            '
            Me.btnManagerFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnManagerFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnManagerFind.Image = CType(resources.GetObject("btnManagerFind.Image"), System.Drawing.Image)
            Me.btnManagerFind.Location = New System.Drawing.Point(480, 45)
            Me.btnManagerFind.Name = "btnManagerFind"
            Me.btnManagerFind.Size = New System.Drawing.Size(24, 23)
            Me.btnManagerFind.TabIndex = 248
            Me.btnManagerFind.TabStop = False
            Me.btnManagerFind.ThemedImage = CType(resources.GetObject("btnManagerFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAdminEdit
            '
            Me.btnAdminEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAdminEdit.Image = CType(resources.GetObject("btnAdminEdit.Image"), System.Drawing.Image)
            Me.btnAdminEdit.Location = New System.Drawing.Point(504, 69)
            Me.btnAdminEdit.Name = "btnAdminEdit"
            Me.btnAdminEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnAdminEdit.TabIndex = 250
            Me.btnAdminEdit.TabStop = False
            Me.btnAdminEdit.ThemedImage = CType(resources.GetObject("btnAdminEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAdminFind
            '
            Me.btnAdminFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAdminFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAdminFind.Image = CType(resources.GetObject("btnAdminFind.Image"), System.Drawing.Image)
            Me.btnAdminFind.Location = New System.Drawing.Point(480, 69)
            Me.btnAdminFind.Name = "btnAdminFind"
            Me.btnAdminFind.Size = New System.Drawing.Size(24, 23)
            Me.btnAdminFind.TabIndex = 247
            Me.btnAdminFind.TabStop = False
            Me.btnAdminFind.ThemedImage = CType(resources.GetObject("btnAdminFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtManagerCode
            '
            Me.txtManagerCode.Location = New System.Drawing.Point(112, 48)
            Me.txtManagerCode.Name = "txtManagerCode"
            Me.txtManagerCode.Size = New System.Drawing.Size(112, 20)
            Me.txtManagerCode.TabIndex = 1
            Me.txtManagerCode.Text = ""
            '
            'lblManager
            '
            Me.lblManager.BackColor = System.Drawing.Color.Transparent
            Me.lblManager.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblManager.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblManager.Location = New System.Drawing.Point(8, 48)
            Me.lblManager.Name = "lblManager"
            Me.lblManager.Size = New System.Drawing.Size(104, 18)
            Me.lblManager.TabIndex = 191
            Me.lblManager.Text = "ผู้จัดการ"
            Me.lblManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAdmin
            '
            Me.lblAdmin.BackColor = System.Drawing.Color.Transparent
            Me.lblAdmin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAdmin.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblAdmin.Location = New System.Drawing.Point(8, 72)
            Me.lblAdmin.Name = "lblAdmin"
            Me.lblAdmin.Size = New System.Drawing.Size(104, 18)
            Me.lblAdmin.TabIndex = 192
            Me.lblAdmin.Text = "ธุรการ"
            Me.lblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAdminCode
            '
            Me.txtAdminCode.Location = New System.Drawing.Point(112, 72)
            Me.txtAdminCode.Name = "txtAdminCode"
            Me.txtAdminCode.Size = New System.Drawing.Size(112, 20)
            Me.txtAdminCode.TabIndex = 2
            Me.txtAdminCode.Text = ""
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(728, 104)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(648, 104)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 4
            Me.btnReset.Text = "Reset"
            '
            'txtManagerName
            '
            Me.txtManagerName.Location = New System.Drawing.Point(224, 48)
            Me.txtManagerName.Name = "txtManagerName"
            Me.txtManagerName.ReadOnly = True
            Me.txtManagerName.Size = New System.Drawing.Size(256, 20)
            Me.txtManagerName.TabIndex = 196
            Me.txtManagerName.TabStop = False
            Me.txtManagerName.Text = ""
            '
            'txtAdminName
            '
            Me.txtAdminName.Location = New System.Drawing.Point(224, 72)
            Me.txtAdminName.Name = "txtAdminName"
            Me.txtAdminName.ReadOnly = True
            Me.txtAdminName.Size = New System.Drawing.Size(256, 20)
            Me.txtAdminName.TabIndex = 196
            Me.txtAdminName.TabStop = False
            Me.txtAdminName.Text = ""
            '
            'MaterialDetailFilterSubpanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "MaterialDetailFilterSubpanel"
            Me.Size = New System.Drawing.Size(832, 160)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()

        End Sub
#End Region

#Region "Members"
        Private m_manage As New Employee
        Private m_admin As New User
#End Region

#Region "Methods"
        Public Sub Initialize()
            PopulateStatus()
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""

            Me.txtAdminCode.Text = ""
            Me.txtAdminName.Text = ""

            Me.txtManagerCode.Text = ""
            Me.txtManagerName.Text = ""
        End Sub
        Private Sub PopulateStatus()

        End Sub
        Public Sub SetLabelText()
            'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbDetail}")
            'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblCode}")
            'Me.btnSearch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.btnSearch}")
            'Me.btnReset.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.btnReset}")
            'Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbDocDate}")
            'Me.grbReceivingDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbReceivingDate}")
            'Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblDocDateStart}")
            'Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblDocDateEnd}")
            'Me.lblReceivingDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblReceivingDateStart}")
            'Me.lblReceivingDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblReceivingDateEnd}")
            'Me.lblManager.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblManager}")
            'Me.lblAdmin.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblAdmin}")
            'Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblStatus}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(2) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("manager", IIf(Me.m_manage.Valid, Me.m_manage.Id, DBNull.Value))
            arr(2) = New Filter("admin", IIf(Me.m_admin.Valid, Me.m_admin.Id, DBNull.Value))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

#End Region

#Region "Event Handlers"
        Private Sub txtManagerCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtManagerCode.Validated
            Dim em As New Employee(txtManagerCode.Text)
            Me.m_manage = em
            Me.txtManagerCode.Text = m_manage.Code
            Me.txtManagerName.Text = m_manage.Name
        End Sub
        Private Sub txtAdminCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdminCode.Validated
            Dim admin As New User(txtAdminCode.Text)
            Me.m_admin = admin
            Me.txtAdminCode.Text = m_admin.Code
            Me.txtAdminName.Text = m_admin.Name
        End Sub
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub

        Private Sub ibtnShowReturnPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'myEntityPanelService.OpenPanel(New Employee)
        End Sub

        Private Sub btnAdminEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'myEntityPanelService.OpenPanel(New User)
        End Sub
#End Region

        Private Sub txtManagerCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManagerCode.TextChanged

        End Sub
    End Class
End Namespace

