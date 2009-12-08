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
  Public Class ApproveConfigurationView
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
    Friend WithEvents grbItems As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkPR As System.Windows.Forms.CheckBox
    Friend WithEvents chkPO As System.Windows.Forms.CheckBox
    Friend WithEvents chkDO As System.Windows.Forms.CheckBox
    Friend WithEvents lblMaxLevelApprovePR As System.Windows.Forms.Label
    Friend WithEvents nudMaxLevelApprovePR As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMaxLevelApprovePO As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMaxLevelApprovePO As System.Windows.Forms.Label
    Friend WithEvents nudMaxLevelApproveDO As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMaxLevelApproveDO As System.Windows.Forms.Label
    Friend WithEvents chkApprovePR As System.Windows.Forms.CheckBox
    Friend WithEvents chkPOApproveBeforePrint As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbItems = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkApprovePR = New System.Windows.Forms.CheckBox
      Me.nudMaxLevelApprovePR = New System.Windows.Forms.NumericUpDown
      Me.lblMaxLevelApprovePR = New System.Windows.Forms.Label
      Me.chkPR = New System.Windows.Forms.CheckBox
      Me.chkPO = New System.Windows.Forms.CheckBox
      Me.chkDO = New System.Windows.Forms.CheckBox
      Me.nudMaxLevelApprovePO = New System.Windows.Forms.NumericUpDown
      Me.lblMaxLevelApprovePO = New System.Windows.Forms.Label
      Me.nudMaxLevelApproveDO = New System.Windows.Forms.NumericUpDown
      Me.lblMaxLevelApproveDO = New System.Windows.Forms.Label
      Me.chkPOApproveBeforePrint = New System.Windows.Forms.CheckBox
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.grbItems.SuspendLayout()
      CType(Me.nudMaxLevelApprovePR, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudMaxLevelApprovePO, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudMaxLevelApproveDO, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Nothing
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'grbItems
      '
      Me.grbItems.Controls.Add(Me.chkPOApproveBeforePrint)
      Me.grbItems.Controls.Add(Me.chkApprovePR)
      Me.grbItems.Controls.Add(Me.nudMaxLevelApprovePR)
      Me.grbItems.Controls.Add(Me.lblMaxLevelApprovePR)
      Me.grbItems.Controls.Add(Me.chkPR)
      Me.grbItems.Controls.Add(Me.chkPO)
      Me.grbItems.Controls.Add(Me.chkDO)
      Me.grbItems.Controls.Add(Me.nudMaxLevelApprovePO)
      Me.grbItems.Controls.Add(Me.lblMaxLevelApprovePO)
      Me.grbItems.Controls.Add(Me.nudMaxLevelApproveDO)
      Me.grbItems.Controls.Add(Me.lblMaxLevelApproveDO)
      Me.grbItems.Controls.Add(Me.Panel1)
      Me.grbItems.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbItems.Location = New System.Drawing.Point(24, 16)
      Me.grbItems.Name = "grbItems"
      Me.grbItems.Size = New System.Drawing.Size(424, 160)
      Me.grbItems.TabIndex = 0
      Me.grbItems.TabStop = False
      Me.grbItems.Text = "เอกสารที่ต้องการการอนุมัติ"
      '
      'chkApprovePR
      '
      Me.chkApprovePR.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkApprovePR.Location = New System.Drawing.Point(24, 48)
      Me.chkApprovePR.Name = "chkApprovePR"
      Me.chkApprovePR.Size = New System.Drawing.Size(176, 24)
      Me.chkApprovePR.TabIndex = 3
      Me.chkApprovePR.Text = "ใบขอซื้อ (PR) โดยคลัง"
      '
      'nudMaxLevelApprovePR
      '
      Me.nudMaxLevelApprovePR.Location = New System.Drawing.Point(336, 26)
      Me.nudMaxLevelApprovePR.Name = "nudMaxLevelApprovePR"
      Me.nudMaxLevelApprovePR.Size = New System.Drawing.Size(48, 21)
      Me.nudMaxLevelApprovePR.TabIndex = 2
      Me.nudMaxLevelApprovePR.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblMaxLevelApprovePR
      '
      Me.lblMaxLevelApprovePR.Location = New System.Drawing.Point(208, 26)
      Me.lblMaxLevelApprovePR.Name = "lblMaxLevelApprovePR"
      Me.lblMaxLevelApprovePR.Size = New System.Drawing.Size(128, 21)
      Me.lblMaxLevelApprovePR.TabIndex = 1
      Me.lblMaxLevelApprovePR.Text = "ระดับสูงสุดในการอนุมัติ"
      Me.lblMaxLevelApprovePR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkPR
      '
      Me.chkPR.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPR.Location = New System.Drawing.Point(24, 24)
      Me.chkPR.Name = "chkPR"
      Me.chkPR.Size = New System.Drawing.Size(176, 24)
      Me.chkPR.TabIndex = 0
      Me.chkPR.Text = "ใบขอซื้อ (PR)"
      '
      'chkPO
      '
      Me.chkPO.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPO.Location = New System.Drawing.Point(24, 72)
      Me.chkPO.Name = "chkPO"
      Me.chkPO.Size = New System.Drawing.Size(176, 24)
      Me.chkPO.TabIndex = 4
      Me.chkPO.Text = "ใบสั่งซื้อ (PO)"
      '
      'chkDO
      '
      Me.chkDO.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkDO.Location = New System.Drawing.Point(24, 120)
      Me.chkDO.Name = "chkDO"
      Me.chkDO.Size = New System.Drawing.Size(176, 24)
      Me.chkDO.TabIndex = 7
      Me.chkDO.Text = "ใบรับสินค้า"
      '
      'nudMaxLevelApprovePO
      '
      Me.nudMaxLevelApprovePO.Location = New System.Drawing.Point(336, 72)
      Me.nudMaxLevelApprovePO.Name = "nudMaxLevelApprovePO"
      Me.nudMaxLevelApprovePO.Size = New System.Drawing.Size(48, 21)
      Me.nudMaxLevelApprovePO.TabIndex = 6
      Me.nudMaxLevelApprovePO.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblMaxLevelApprovePO
      '
      Me.lblMaxLevelApprovePO.Location = New System.Drawing.Point(208, 72)
      Me.lblMaxLevelApprovePO.Name = "lblMaxLevelApprovePO"
      Me.lblMaxLevelApprovePO.Size = New System.Drawing.Size(128, 21)
      Me.lblMaxLevelApprovePO.TabIndex = 5
      Me.lblMaxLevelApprovePO.Text = "ระดับสูงสุดในการอนุมัติ"
      Me.lblMaxLevelApprovePO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'nudMaxLevelApproveDO
      '
      Me.nudMaxLevelApproveDO.Location = New System.Drawing.Point(336, 120)
      Me.nudMaxLevelApproveDO.Name = "nudMaxLevelApproveDO"
      Me.nudMaxLevelApproveDO.Size = New System.Drawing.Size(48, 21)
      Me.nudMaxLevelApproveDO.TabIndex = 9
      Me.nudMaxLevelApproveDO.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblMaxLevelApproveDO
      '
      Me.lblMaxLevelApproveDO.Location = New System.Drawing.Point(208, 120)
      Me.lblMaxLevelApproveDO.Name = "lblMaxLevelApproveDO"
      Me.lblMaxLevelApproveDO.Size = New System.Drawing.Size(128, 21)
      Me.lblMaxLevelApproveDO.TabIndex = 8
      Me.lblMaxLevelApproveDO.Text = "ระดับสูงสุดในการอนุมัติ"
      Me.lblMaxLevelApproveDO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkPOApproveBeforePrint
      '
      Me.chkPOApproveBeforePrint.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPOApproveBeforePrint.Location = New System.Drawing.Point(40, 96)
      Me.chkPOApproveBeforePrint.Name = "chkPOApproveBeforePrint"
      Me.chkPOApproveBeforePrint.Size = New System.Drawing.Size(176, 24)
      Me.chkPOApproveBeforePrint.TabIndex = 10
      Me.chkPOApproveBeforePrint.Text = "ป้องกันการพิมพ์ก่อนการอนุมัติ"
      '
      'Panel1
      '
      Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel1.Location = New System.Drawing.Point(32, 80)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(104, 24)
      Me.Panel1.TabIndex = 11
      '
      'ApproveConfigurationView
      '
      Me.Controls.Add(Me.grbItems)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "ApproveConfigurationView"
      Me.Size = New System.Drawing.Size(472, 192)
      Me.grbItems.ResumeLayout(False)
      CType(Me.nudMaxLevelApprovePR, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudMaxLevelApprovePO, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudMaxLevelApproveDO, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean
    Public ConfigFilters(7) As Filter
    Private Dirty As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()

      'Check Module
      CheckModuleActivation()
    End Sub
#End Region

#Region "CheckPJMModule"
    Private m_ApproveDocModule As New PJMModule("approvedoc")
    ReadOnly Property Activated() As Boolean
      Get
        Return m_ApproveDocModule.Activated
      End Get
    End Property
    Public Sub CheckModuleActivation()
      If Not Me.Activated Then
        Me.lblMaxLevelApprovePR.Visible = False
        Me.lblMaxLevelApprovePO.Visible = False
        Me.lblMaxLevelApproveDO.Visible = False

        Me.nudMaxLevelApprovePR.Visible = False
        Me.nudMaxLevelApprovePO.Visible = False
        Me.nudMaxLevelApproveDO.Visible = False
      End If
    End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
    Public Sub CheckFormEnable()
      Me.nudMaxLevelApprovePR.Enabled = chkPR.Checked
      Me.nudMaxLevelApprovePO.Enabled = chkPO.Checked
      Me.nudMaxLevelApproveDO.Enabled = chkDO.Checked

      Me.chkPOApproveBeforePrint.Enabled = chkPO.Checked

    End Sub
    Public Sub ClearDetail()
    End Sub
    Public Sub SetLabelText()
      Me.grbItems.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.grbItems}")
      Me.chkPR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkPR}")
      Me.chkPO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkPO}")
      Me.chkPOApproveBeforePrint.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkPOApproveBeforePrint}")
      Me.chkDO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkDO}")
      Me.chkApprovePR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkApprovePR}")

      Me.lblMaxLevelApprovePR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApprovePR}")
      Me.lblMaxLevelApprovePO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApprovePO}")
      Me.lblMaxLevelApproveDO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApproveDO}")
    End Sub
    Protected Sub EventWiring()
      AddHandler chkPR.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkApprovePR.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPO.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPOApproveBeforePrint.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkDO.CheckedChanged, AddressOf ChangeProperty
      AddHandler nudMaxLevelApprovePR.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApprovePR.Click, AddressOf ChangeProperty
      AddHandler nudMaxLevelApprovePO.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApprovePO.Click, AddressOf ChangeProperty
      AddHandler nudMaxLevelApproveDO.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApproveDO.Click, AddressOf ChangeProperty
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "chkpr"
          Me.SetFilterValue("ApprovePR", chkPR.Checked)
          dirtyFlag = True
        Case "chkapprovepr"
          Me.SetFilterValue("PRNeedStoreApprove", chkApprovePR.Checked)
          dirtyFlag = True
        Case "chkpo"
          Me.SetFilterValue("ApprovePO", chkPO.Checked)
          dirtyFlag = True
        Case "chkpoapprovebeforeprint"
          Me.SetFilterValue("POApproveBeforePrint", chkPOApproveBeforePrint.Checked)
          dirtyFlag = True
        Case "chkdo"
          Me.SetFilterValue("ApproveDO", chkDO.Checked)
          dirtyFlag = True
        Case "nudmaxlevelapprovepr"
          Me.SetFilterValue("MaxLevelApprovePR", nudMaxLevelApprovePR.Text)
          dirtyFlag = True
        Case "nudmaxlevelapprovepo"
          Me.SetFilterValue("MaxLevelApprovePO", nudMaxLevelApprovePO.Text)
          dirtyFlag = True
        Case "nudmaxlevelapprovedo"
          Me.SetFilterValue("MaxLevelApproveDO", nudMaxLevelApproveDO.Text)
          dirtyFlag = True
      End Select
      Dirty = Dirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub Initialize()
      ConfigFilters(0) = New Filter("ApprovePR", Configuration.GetConfig("ApprovePR"))
      ConfigFilters(1) = New Filter("ApprovePO", Configuration.GetConfig("ApprovePO"))
      ConfigFilters(2) = New Filter("ApproveDO", Configuration.GetConfig("ApproveDO"))
      ConfigFilters(3) = New Filter("MaxLevelApprovePR", Configuration.GetConfig("MaxLevelApprovePR"))
      ConfigFilters(4) = New Filter("MaxLevelApprovePO", Configuration.GetConfig("MaxLevelApprovePO"))
      ConfigFilters(5) = New Filter("MaxLevelApproveDO", Configuration.GetConfig("MaxLevelApproveDO"))
      ConfigFilters(6) = New Filter("PRNeedStoreApprove", Configuration.GetConfig("PRNeedStoreApprove"))
      ConfigFilters(7) = New Filter("POApproveBeforePrint", Configuration.GetConfig("POApproveBeforePrint"))
    End Sub
    Private Sub SetFilterValue(ByVal name As String, ByVal value As Object)
      For Each filter As Filter In ConfigFilters
        If filter.Name.ToLower = name.ToLower Then
          filter.Value = value
          Exit For
        End If
      Next
    End Sub
    Private Function GetFilterValue(ByVal name As String) As Object
      For Each filter As Filter In ConfigFilters
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
      Me.chkPR.Checked = CBool(GetFilterValue("ApprovePR"))
      Me.chkPO.Checked = CBool(GetFilterValue("ApprovePO"))
      Me.chkPOApproveBeforePrint.Checked = CBool(GetFilterValue("POApproveBeforePrint"))
      Me.chkDO.Checked = CBool(GetFilterValue("ApproveDO"))
      Me.nudMaxLevelApprovePR.Text = CInt(GetFilterValue("MaxLevelApprovePR"))
      Me.nudMaxLevelApprovePO.Text = CInt(GetFilterValue("MaxLevelApprovePO"))
      Me.nudMaxLevelApproveDO.Text = CInt(GetFilterValue("MaxLevelApproveDO"))
      Me.chkApprovePR.Checked = CBool(GetFilterValue("PRNeedStoreApprove"))

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