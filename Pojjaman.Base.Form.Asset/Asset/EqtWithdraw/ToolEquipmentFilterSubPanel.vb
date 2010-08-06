Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ToolEquipmentFilterSubPanel
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
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtStoreCCName As System.Windows.Forms.TextBox
    Friend WithEvents btnStoreCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnStoreCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtStoreCCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblStoreCC As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolEquipmentFilterSubPanel))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.txtStoreCCName = New System.Windows.Forms.TextBox()
      Me.btnStoreCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblStoreCC = New System.Windows.Forms.Label()
      Me.btnStoreCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtStoreCCCode = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbGeneral.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.grbGeneral)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(508, 119)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'grbGeneral
      '
      Me.grbGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbGeneral.Controls.Add(Me.txtCode)
      Me.grbGeneral.Controls.Add(Me.lblCode)
      Me.grbGeneral.Controls.Add(Me.txtStoreCCName)
      Me.grbGeneral.Controls.Add(Me.txtStoreCCCode)
      Me.grbGeneral.Controls.Add(Me.btnStoreCCFind)
      Me.grbGeneral.Controls.Add(Me.lblStoreCC)
      Me.grbGeneral.Controls.Add(Me.btnStoreCCEdit)
      Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbGeneral.Location = New System.Drawing.Point(8, 10)
      Me.grbGeneral.Name = "grbGeneral"
      Me.grbGeneral.Size = New System.Drawing.Size(491, 72)
      Me.grbGeneral.TabIndex = 0
      Me.grbGeneral.TabStop = False
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(112, 16)
      Me.txtCode.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(352, 21)
      Me.txtCode.TabIndex = 1
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(96, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่เอกสาร"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(425, 87)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 4
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(345, 87)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 3
      Me.btnReset.Text = "Reset"
      '
      'txtStoreCCName
      '
      Me.Validator.SetDataType(Me.txtStoreCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStoreCCName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStoreCCName, System.Drawing.Color.Empty)
      Me.txtStoreCCName.Location = New System.Drawing.Point(192, 43)
      Me.Validator.SetMinValue(Me.txtStoreCCName, "")
      Me.txtStoreCCName.Name = "txtStoreCCName"
      Me.txtStoreCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtStoreCCName, "")
      Me.Validator.SetRequired(Me.txtStoreCCName, False)
      Me.txtStoreCCName.Size = New System.Drawing.Size(96, 20)
      Me.txtStoreCCName.TabIndex = 0
      Me.txtStoreCCName.TabStop = False
      '
      'btnStoreCCEdit
      '
      Me.btnStoreCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStoreCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStoreCCEdit.Location = New System.Drawing.Point(312, 43)
      Me.btnStoreCCEdit.Name = "btnStoreCCEdit"
      Me.btnStoreCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnStoreCCEdit.TabIndex = 4
      Me.btnStoreCCEdit.TabStop = False
      Me.btnStoreCCEdit.ThemedImage = CType(resources.GetObject("btnStoreCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblStoreCC
      '
      Me.lblStoreCC.BackColor = System.Drawing.Color.Transparent
      Me.lblStoreCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStoreCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStoreCC.Location = New System.Drawing.Point(6, 43)
      Me.lblStoreCC.Name = "lblStoreCC"
      Me.lblStoreCC.Size = New System.Drawing.Size(98, 18)
      Me.lblStoreCC.TabIndex = 0
      Me.lblStoreCC.Text = "Cost Center"
      Me.lblStoreCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnStoreCCFind
      '
      Me.btnStoreCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnStoreCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnStoreCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnStoreCCFind.Location = New System.Drawing.Point(288, 43)
      Me.btnStoreCCFind.Name = "btnStoreCCFind"
      Me.btnStoreCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnStoreCCFind.TabIndex = 3
      Me.btnStoreCCFind.TabStop = False
      Me.btnStoreCCFind.ThemedImage = CType(resources.GetObject("btnStoreCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtStoreCCCode
      '
      Me.Validator.SetDataType(Me.txtStoreCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStoreCCCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStoreCCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStoreCCCode, System.Drawing.Color.Empty)
      Me.txtStoreCCCode.Location = New System.Drawing.Point(112, 43)
      Me.txtStoreCCCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtStoreCCCode, "")
      Me.txtStoreCCCode.Name = "txtStoreCCCode"
      Me.Validator.SetRegularExpression(Me.txtStoreCCCode, "")
      Me.Validator.SetRequired(Me.txtStoreCCCode, False)
      Me.txtStoreCCCode.Size = New System.Drawing.Size(80, 20)
      Me.txtStoreCCCode.TabIndex = 1
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'ToolEquipmentFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "ToolEquipmentFilterSubPanel"
      Me.Size = New System.Drawing.Size(525, 127)
      Me.grbDetail.ResumeLayout(False)
      Me.grbGeneral.ResumeLayout(False)
      Me.grbGeneral.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()
      Initialize()
      SetLabelText()
      Me.LoopControl(Me)
    End Sub
#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.lblStoreCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawFilterSubPanel.lblStoreCC}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawFilterSubPanel.lblCode}")
      Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolWithdrawFilterSubPanel.grbGeneral}")
    End Sub
#End Region

#Region "Members"
    Private m_storecc As CostCenter
#End Region

#Region "Methods"
    Public Sub Initialize()
      PopulateStatus()
      ClearCriterias()
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""

      Me.txtStoreCCCode.Text = ""
      Me.txtStoreCCName.Text = ""
      Me.m_storecc = New CostCenter

    End Sub
    Private Sub PopulateStatus()

    End Sub

    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(2) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("fromCC", IIf(Me.m_storecc.Originated, Me.m_storecc.Id, DBNull.Value))
      arr(2) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    ' Withdraw Person ...
    'Private Sub txtWithdrawPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Employee.GetEmployee(txtWithdrawPersonCode, txtWithdrawPersonName, Me.m_withdrawperson)
    'End Sub
    'Private Sub btnWithdrawPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New Employee)
    'End Sub
    'Private Sub btnWithdrawPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Employee, AddressOf SetWithdrawPerson)
    'End Sub
    'Private Sub SetWithdrawPerson(ByVal e As ISimpleEntity)
    '  Me.txtWithdrawPersonCode.Text = e.Code
    '  Employee.GetEmployee(txtWithdrawPersonCode, txtWithdrawPersonName, Me.m_withdrawperson)
    'End Sub
    '' Withdraw Costcenter ...
    'Private Sub txtWithdrawCCCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  CostCenter.GetCostCenterWithoutRight(txtWithdrawCCCode, txtWithdrawCCName, Me.m_withdrawcc)
    'End Sub
    'Private Sub btnWithdrawCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New CostCenter)
    'End Sub
    'Private Sub btnWithdrawCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetWithdrawCC, New Filter() {New Filter("checkright", False)})
    'End Sub
    'Private Sub SetWithdrawCC(ByVal e As ISimpleEntity)
    '  Me.txtWithdrawCCCode.Text = e.Code
    '  CostCenter.GetCostCenterWithoutRight(txtWithdrawCCCode, txtWithdrawCCName, Me.m_withdrawcc)
    'End Sub
    '' Store Person ...
    'Private Sub txtStorePersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Employee.GetEmployee(txtStorePersonCode, txtStorePersonName, Me.m_storeperson)
    'End Sub
    'Private Sub btnStorePersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New Employee)
    'End Sub
    'Private Sub btnStorePersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Employee, AddressOf SetStorePerson)
    'End Sub
    'Private Sub SetStorePerson(ByVal e As ISimpleEntity)
    '  Me.txtStorePersonCode.Text = e.Code
    '  Employee.GetEmployee(txtStorePersonCode, txtStorePersonName, Me.m_storeperson)
    'End Sub
    ' Store Costcenter ...
    Private Sub txtStoreCCCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStoreCCCode.Validated
      CostCenter.GetCostCenter(txtStoreCCCode, txtStoreCCName, Me.m_storecc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub btnStoreCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStoreCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnStoreCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStoreCCFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetStoreCC)
    End Sub
    Private Sub SetStoreCC(ByVal e As ISimpleEntity)
      Me.txtStoreCCCode.Text = e.Code
      CostCenter.GetCostCenter(txtStoreCCCode, txtStoreCCName, Me.m_storecc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    ' Reset Button ...
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub

#End Region

#Region "IClipboardHandler Overrides" 'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject
        ' withdraw person ...
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
              Return True
          End Select
        End If
        ' store person ...
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtstorepersoncode", "txtstorepersonname"
              Return True
          End Select
        End If
        ' withdraw costcenter ...
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtwithdrawcccode", "txtwithdrawccname"
              Return True
            Case "txtstorecccode", "txtstoreccname"
              Return True
          End Select
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If Me.ActiveControl Is Nothing Then
        Return
      End If
      Dim data As IDataObject = Clipboard.GetDataObject
      ' Withdraw person ...
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtwithdrawpersoncode", "txtwithdrawpersonname"
            'Me.SetWithdrawPerson(entity)
        End Select
      End If
      ' Store Person ...
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtstorepersoncode", "txtstorepersonname"
            'Me.SetStorePerson(entity)
        End Select
      End If
      ' Costcenter ...
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtwithdrawcccode", "txtwithdrawccname"
            'Me.SetWithdrawCC(entity)
          Case "txtstorecccode", "txtstoreccname"
            Me.SetStoreCC(entity)
        End Select
      End If
    End Sub
#End Region

    Public Overrides Property Entities() As System.Collections.ArrayList
      Get
        Return MyBase.Entities
      End Get
      Set(ByVal Value As System.Collections.ArrayList)
        MyBase.Entities = Value
        For Each entity As ISimpleEntity In Value
          If TypeOf entity Is EquipmentToolWithdraw Then
            Dim obj As EquipmentToolWithdraw = CType(entity, EquipmentToolWithdraw)

            'If obj.Withdrawperson.Originated Then
            '  Me.SetWithdrawPerson(obj.Withdrawperson)
            'End If

            'If obj.WithdrawCostcenter.Originated Then
            '  Me.SetWithdrawCC(obj.WithdrawCostcenter)
            'End If

            'If obj.Storeperson.Originated Then
            '  Me.SetStorePerson(obj.Storeperson)
            'End If

            'If obj.StoreCostcenter.Originated Then
            '  Me.SetStoreCC(obj.StoreCostcenter)
            '  Me.txtStoreCCCode.Enabled = False
            '  Me.txtStoreCCName.Enabled = False
            '  Me.btnStoreCCEdit.Enabled = False
            '  Me.btnStoreCCFind.Enabled = False
            'End If
          ElseIf TypeOf entity Is CostCenter Then
            Me.SetStoreCC(entity)
            Me.txtStoreCCCode.Enabled = False
            Me.txtStoreCCName.Enabled = False
            Me.btnStoreCCEdit.Enabled = False
            Me.btnStoreCCFind.Enabled = False
          End If
        Next
      End Set
    End Property


  End Class
End Namespace

