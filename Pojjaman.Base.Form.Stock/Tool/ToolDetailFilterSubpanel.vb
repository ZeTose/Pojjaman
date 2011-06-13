Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ToolDetailFilterSubpanel
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
        Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
        Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnGroupEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ToolDetailFilterSubpanel))
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtName = New System.Windows.Forms.TextBox
      Me.lblName = New System.Windows.Forms.Label
      Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnGroupEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.txtGroupCode = New System.Windows.Forms.TextBox
      Me.lblGroup = New System.Windows.Forms.Label
      Me.txtGroupName = New System.Windows.Forms.TextBox
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 25)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(72, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtCode.Location = New System.Drawing.Point(88, 24)
      Me.txtCode.MaxLength = 255
      Me.txtCode.Name = "txtCode"
      Me.txtCode.Size = New System.Drawing.Size(288, 21)
      Me.txtCode.TabIndex = 1
      Me.txtCode.Text = ""
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.btnGroupFind)
      Me.grbDetail.Controls.Add(Me.btnGroupEdit)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.txtGroupCode)
      Me.grbDetail.Controls.Add(Me.lblGroup)
      Me.grbDetail.Controls.Add(Me.txtGroupName)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(408, 136)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'txtName
      '
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtName.Location = New System.Drawing.Point(88, 48)
      Me.txtName.MaxLength = 255
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(288, 21)
      Me.txtName.TabIndex = 10
      Me.txtName.Text = ""
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(24, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(56, 18)
      Me.lblName.TabIndex = 9
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnGroupFind
      '
      Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnGroupFind.Image = CType(resources.GetObject("btnGroupFind.Image"), System.Drawing.Image)
      Me.btnGroupFind.Location = New System.Drawing.Point(328, 72)
      Me.btnGroupFind.Name = "btnGroupFind"
      Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupFind.TabIndex = 5
      Me.btnGroupFind.TabStop = False
      Me.btnGroupFind.ThemedImage = CType(resources.GetObject("btnGroupFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnGroupEdit
      '
      Me.btnGroupEdit.Image = CType(resources.GetObject("btnGroupEdit.Image"), System.Drawing.Image)
      Me.btnGroupEdit.Location = New System.Drawing.Point(352, 72)
      Me.btnGroupEdit.Name = "btnGroupEdit"
      Me.btnGroupEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupEdit.TabIndex = 6
      Me.btnGroupEdit.TabStop = False
      Me.btnGroupEdit.ThemedImage = CType(resources.GetObject("btnGroupEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(304, 104)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 8
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(216, 104)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 7
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "Reset"
      '
      'txtGroupCode
      '
      Me.txtGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtGroupCode.Location = New System.Drawing.Point(88, 72)
      Me.txtGroupCode.MaxLength = 20
      Me.txtGroupCode.Name = "txtGroupCode"
      Me.txtGroupCode.Size = New System.Drawing.Size(96, 21)
      Me.txtGroupCode.TabIndex = 3
      Me.txtGroupCode.Text = ""
      '
      'lblGroup
      '
      Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGroup.ForeColor = System.Drawing.Color.Black
      Me.lblGroup.Location = New System.Drawing.Point(8, 72)
      Me.lblGroup.Name = "lblGroup"
      Me.lblGroup.Size = New System.Drawing.Size(72, 18)
      Me.lblGroup.TabIndex = 2
      Me.lblGroup.Text = "กลุ่มเครื่องมือ:"
      Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGroupName
      '
      Me.txtGroupName.BackColor = System.Drawing.SystemColors.Control
      Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtGroupName.Location = New System.Drawing.Point(184, 72)
      Me.txtGroupName.Name = "txtGroupName"
      Me.txtGroupName.ReadOnly = True
      Me.txtGroupName.Size = New System.Drawing.Size(144, 21)
      Me.txtGroupName.TabIndex = 4
      Me.txtGroupName.TabStop = False
      Me.txtGroupName.Text = ""
      '
      'ToolDetailFilterSubpanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "ToolDetailFilterSubpanel"
      Me.Size = New System.Drawing.Size(424, 152)
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
        Dim m_toolgroup As New ToolGroup
#End Region

#Region "Methods"
        Public Sub Initialize()
            PopulateStatus()
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()
      Me.txtCode.Text = ""
      Me.txtName.Text = ""
            Me.Group = New ToolGroup
        End Sub
        Private Sub PopulateStatus()

        End Sub
        Public Sub SetLabelText()
            'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.grbDetail}")
            'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
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
      Dim arr(3) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("name", IIf(Me.txtName.TextLength = 0, DBNull.Value, Me.txtName.Text))
      arr(2) = New Filter("group", IIf(Me.Group.Valid, Me.Group.Id, DBNull.Value))
      arr(3) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      Return arr
    End Function
        
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

#End Region

#Region "Event Handlers"

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub

        Private Sub ibtnShowReturnPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Property Group() As ToolGroup
            Get
                Return m_toolgroup
            End Get
            Set(ByVal Value As ToolGroup)
                m_toolgroup = Value
            End Set
        End Property
        Private Sub btnAdminEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'myEntityPanelService.OpenPanel(New User)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New ToolGroup).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtgroupcode", "txtgroupname"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New ToolGroup).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New ToolGroup).FullClassName))
                Dim entity As New ToolGroup(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtgroupcode", "txtgroupname"
                            Me.SetToolGroup(entity)
                    End Select
                End If
            End If
            
        End Sub
#End Region

#Region "Event of Control"
        Private Sub txtGroupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupCode.Validated
            ToolGroup.GetToolGroup(txtGroupCode, txtGroupName, Me.Group)
        End Sub

        Private Sub btnGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New ToolGroup, AddressOf SetToolGroup)
        End Sub
        Private Sub SetToolGroup(ByVal e As ISimpleEntity)
            Me.txtGroupCode.Text = e.Code
            ToolGroup.GetToolGroup(txtGroupCode, txtGroupName, Me.Group)
        End Sub

        Private Sub btnGroupEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New ToolGroup)
        End Sub
#End Region

        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                For Each entity As ISimpleEntity In Value

                    If TypeOf entity Is Tool Then
                        Dim obj As Tool
                        obj = CType(entity, Tool)
                        ' Account ...
                        If obj.Group.Originated Then
                            Me.SetToolGroup(obj.Group)
                            Me.txtGroupCode.Enabled = False
                            Me.txtGroupName.Enabled = False
                            Me.btnGroupEdit.Enabled = False
                            Me.btnGroupFind.Enabled = False
                        End If
                    End If
                Next
            End Set
        End Property

   

    End Class
End Namespace

