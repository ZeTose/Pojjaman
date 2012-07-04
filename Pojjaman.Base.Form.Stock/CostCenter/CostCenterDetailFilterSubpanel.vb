Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CostCenterDetailFilterSubpanel
    'Inherits UserControl
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
    Friend WithEvents cmbCCType As System.Windows.Forms.ComboBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblCCType As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CostCenterDetailFilterSubpanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkActive = New System.Windows.Forms.CheckBox()
      Me.btnManagerEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnManagerFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAdminEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAdminFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtManagerCode = New System.Windows.Forms.TextBox()
      Me.lblManager = New System.Windows.Forms.Label()
      Me.lblAdmin = New System.Windows.Forms.Label()
      Me.txtAdminCode = New System.Windows.Forms.TextBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.txtManagerName = New System.Windows.Forms.TextBox()
      Me.txtAdminName = New System.Windows.Forms.TextBox()
      Me.lblCCType = New System.Windows.Forms.Label()
      Me.cmbCCType = New System.Windows.Forms.ComboBox()
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
      Me.lblCode.TabIndex = 4
      Me.lblCode.Text = "Code/Name:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtCode.Location = New System.Drawing.Point(112, 24)
      Me.txtCode.Name = "txtCode"
      Me.txtCode.Size = New System.Drawing.Size(416, 21)
      Me.txtCode.TabIndex = 0
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.chkActive)
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
      Me.grbDetail.Controls.Add(Me.lblCCType)
      Me.grbDetail.Controls.Add(Me.cmbCCType)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(715, 128)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "CostCenter"
      '
      'chkActive
      '
      Me.chkActive.Checked = True
      Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkActive.Location = New System.Drawing.Point(534, 25)
      Me.chkActive.Name = "chkActive"
      Me.chkActive.Size = New System.Drawing.Size(175, 24)
      Me.chkActive.TabIndex = 16
      Me.chkActive.Text = "Only Active"
      '
      'btnManagerEdit
      '
      Me.btnManagerEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnManagerEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnManagerEdit.Location = New System.Drawing.Point(504, 47)
      Me.btnManagerEdit.Name = "btnManagerEdit"
      Me.btnManagerEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnManagerEdit.TabIndex = 15
      Me.btnManagerEdit.TabStop = False
      Me.btnManagerEdit.ThemedImage = CType(resources.GetObject("btnManagerEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnManagerFind
      '
      Me.btnManagerFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnManagerFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnManagerFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnManagerFind.Location = New System.Drawing.Point(480, 47)
      Me.btnManagerFind.Name = "btnManagerFind"
      Me.btnManagerFind.Size = New System.Drawing.Size(24, 23)
      Me.btnManagerFind.TabIndex = 12
      Me.btnManagerFind.TabStop = False
      Me.btnManagerFind.ThemedImage = CType(resources.GetObject("btnManagerFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAdminEdit
      '
      Me.btnAdminEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAdminEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAdminEdit.Location = New System.Drawing.Point(504, 71)
      Me.btnAdminEdit.Name = "btnAdminEdit"
      Me.btnAdminEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnAdminEdit.TabIndex = 14
      Me.btnAdminEdit.TabStop = False
      Me.btnAdminEdit.ThemedImage = CType(resources.GetObject("btnAdminEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAdminFind
      '
      Me.btnAdminFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAdminFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAdminFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAdminFind.Location = New System.Drawing.Point(480, 71)
      Me.btnAdminFind.Name = "btnAdminFind"
      Me.btnAdminFind.Size = New System.Drawing.Size(24, 23)
      Me.btnAdminFind.TabIndex = 13
      Me.btnAdminFind.TabStop = False
      Me.btnAdminFind.ThemedImage = CType(resources.GetObject("btnAdminFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtManagerCode
      '
      Me.txtManagerCode.Location = New System.Drawing.Point(112, 48)
      Me.txtManagerCode.Name = "txtManagerCode"
      Me.txtManagerCode.Size = New System.Drawing.Size(112, 20)
      Me.txtManagerCode.TabIndex = 1
      '
      'lblManager
      '
      Me.lblManager.BackColor = System.Drawing.Color.Transparent
      Me.lblManager.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblManager.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblManager.Location = New System.Drawing.Point(8, 48)
      Me.lblManager.Name = "lblManager"
      Me.lblManager.Size = New System.Drawing.Size(104, 18)
      Me.lblManager.TabIndex = 5
      Me.lblManager.Text = "Manager:"
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
      Me.lblAdmin.TabIndex = 6
      Me.lblAdmin.Text = "Admin:"
      Me.lblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAdminCode
      '
      Me.txtAdminCode.Location = New System.Drawing.Point(112, 72)
      Me.txtAdminCode.Name = "txtAdminCode"
      Me.txtAdminCode.Size = New System.Drawing.Size(112, 20)
      Me.txtAdminCode.TabIndex = 2
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(511, 96)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 11
      Me.btnSearch.Text = "Find"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(431, 96)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 10
      Me.btnReset.Text = "Reset"
      '
      'txtManagerName
      '
      Me.txtManagerName.Location = New System.Drawing.Point(224, 48)
      Me.txtManagerName.Name = "txtManagerName"
      Me.txtManagerName.ReadOnly = True
      Me.txtManagerName.Size = New System.Drawing.Size(256, 20)
      Me.txtManagerName.TabIndex = 8
      Me.txtManagerName.TabStop = False
      '
      'txtAdminName
      '
      Me.txtAdminName.Location = New System.Drawing.Point(224, 72)
      Me.txtAdminName.Name = "txtAdminName"
      Me.txtAdminName.ReadOnly = True
      Me.txtAdminName.Size = New System.Drawing.Size(256, 20)
      Me.txtAdminName.TabIndex = 9
      Me.txtAdminName.TabStop = False
      '
      'lblCCType
      '
      Me.lblCCType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCType.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCCType.Location = New System.Drawing.Point(8, 96)
      Me.lblCCType.Name = "lblCCType"
      Me.lblCCType.Size = New System.Drawing.Size(104, 18)
      Me.lblCCType.TabIndex = 7
      Me.lblCCType.Text = "CostCenter Type:"
      Me.lblCCType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbCCType
      '
      Me.cmbCCType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbCCType.ItemHeight = 13
      Me.cmbCCType.Location = New System.Drawing.Point(112, 96)
      Me.cmbCCType.Name = "cmbCCType"
      Me.cmbCCType.Size = New System.Drawing.Size(256, 21)
      Me.cmbCCType.TabIndex = 3
      '
      'CostCenterDetailFilterSubpanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "CostCenterDetailFilterSubpanel"
      Me.Size = New System.Drawing.Size(731, 152)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()
      Initialize()
      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Members"
    Private m_manage As New Employee
    Private m_admin As New Employee
#End Region

#Region "Methods"
    Public Sub Initialize()
      PopulateType()
      ClearCriterias()
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""

      Me.m_admin = New Employee
      Me.txtAdminCode.Text = ""
      Me.txtAdminName.Text = ""

      Me.m_manage = New Employee
      Me.txtManagerCode.Text = ""
      Me.txtManagerName.Text = ""
      Me.cmbCCType.SelectedIndex = 0
      Me.chkActive.Checked = True

      EntityRefresh()
    End Sub
    Private Sub PopulateType()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbCCType, "cc_type", True)
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(5) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("manager", IIf(Me.m_manage.Valid, Me.m_manage.Id, DBNull.Value))
      arr(2) = New Filter("admin", IIf(Me.m_admin.Valid, Me.m_admin.Id, DBNull.Value))
      Dim myType As Object
      If Not Me.cmbCCType.SelectedItem Is Nothing AndAlso TypeOf Me.cmbCCType.SelectedItem Is IdValuePair Then
        myType = CType(Me.cmbCCType.SelectedItem, IdValuePair).Id
        If CInt(myType) = -1 Then
          myType = DBNull.Value
        End If
      Else
        myType = DBNull.Value
      End If
      arr(3) = New Filter("type", myType)
      arr(4) = New Filter("userright", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(5) = New Filter("onlyactive", chkActive.Checked)
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

    Private Sub txtManagerCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtManagerCode.Validated
      Employee.GetEmployee(txtManagerCode, txtManagerName, m_manage)
    End Sub
    Private Sub btnManagerFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetManager)
    End Sub
    Private Sub SetManager(ByVal e As ISimpleEntity)
      Me.txtManagerCode.Text = e.Code
      Employee.GetEmployee(txtManagerCode, txtManagerName, m_manage)
    End Sub
    Private Sub btnManagerEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub

    Private Sub txtAdminCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdminCode.Validated
      Employee.GetEmployee(txtAdminCode, txtAdminName, m_admin)
    End Sub
    Private Sub btnAdminFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetAdmin)
    End Sub
    Private Sub SetAdmin(ByVal e As ISimpleEntity)
      Me.txtAdminCode.Text = e.Code
      Employee.GetEmployee(txtAdminCode, txtAdminName, m_admin)
    End Sub
    Private Sub btnAdminEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Employee).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtmanagercode", "txtmanagername", "txtadmincode", "txtadminname"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtmanagercode", "txtmanagername"
              Me.SetManager(entity)
            Case "txtadmincode", "txtadminname"
              Me.SetAdmin(entity)
          End Select
        End If
      End If
    End Sub
#End Region


    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailFilterSubpanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailFilterSubpanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.lblManager.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailFilterSubpanel.lblManager}")
      Me.lblAdmin.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailFilterSubpanel.lblAdmin}")
      Me.lblCCType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterDetailFilterSubpanel.lblCCType}")
      Me.chkActive.Text = "โครงการที่ยังไม่แล้วเสร็จเท่านั้น"
    End Sub

    Public Overrides Property Entities() As System.Collections.ArrayList
      Get
        Return MyBase.Entities
      End Get
      Set(ByVal Value As System.Collections.ArrayList)
        MyBase.Entities = Value
        EntityRefresh()
      End Set
    End Property
    Private Sub EntityRefresh()
      If Entities Is Nothing Then
        Return
      End If

      For Each entity As ISimpleEntity In Entities
        If TypeOf entity Is CostCenter Then
          Dim obj As CostCenter = CType(entity, CostCenter)
          If Not obj.Type Is Nothing AndAlso obj.Type.Value > -1 Then
            CodeDescription.ComboSelect(Me.cmbCCType, obj.Type)
            Me.cmbCCType.Enabled = False
          End If
          ' Admin 
          If obj.Admin.Originated Then
            Me.SetAdmin(obj.Admin)
            Me.txtAdminCode.Enabled = False
            Me.txtAdminName.Enabled = False
            Me.btnAdminEdit.Enabled = False
            Me.btnAdminFind.Enabled = False
          End If
          If obj.Manager.Originated Then
            Me.SetManager(obj.Admin)
            Me.txtManagerCode.Enabled = False
            Me.txtManagerName.Enabled = False
            Me.btnManagerEdit.Enabled = False
            Me.btnManagerFind.Enabled = False
          End If
        End If
      Next
    End Sub

  End Class
End Namespace

