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
    Friend WithEvents nudMaxLevelApproveWR As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMaxLevelApproveWR As System.Windows.Forms.Label
    Friend WithEvents chkWR As System.Windows.Forms.CheckBox
    Friend WithEvents chkPA As System.Windows.Forms.CheckBox
    Friend WithEvents nudMaxLevelApprovePA As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMaxLevelApprovePA As System.Windows.Forms.Label
    Friend WithEvents chkSCApproveBeforePrint As System.Windows.Forms.CheckBox
    Friend WithEvents chkSC As System.Windows.Forms.CheckBox
    Friend WithEvents nudMaxLevelApproveSC As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMaxLevelApproveSC As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkDR As System.Windows.Forms.CheckBox
    Friend WithEvents nudMaxLevelApproveDR As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMaxLevelApproveDR As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.grbItems = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkPA = New System.Windows.Forms.CheckBox()
      Me.nudMaxLevelApprovePA = New System.Windows.Forms.NumericUpDown()
      Me.lblMaxLevelApprovePA = New System.Windows.Forms.Label()
      Me.chkSCApproveBeforePrint = New System.Windows.Forms.CheckBox()
      Me.chkSC = New System.Windows.Forms.CheckBox()
      Me.nudMaxLevelApproveSC = New System.Windows.Forms.NumericUpDown()
      Me.lblMaxLevelApproveSC = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.nudMaxLevelApproveWR = New System.Windows.Forms.NumericUpDown()
      Me.lblMaxLevelApproveWR = New System.Windows.Forms.Label()
      Me.chkWR = New System.Windows.Forms.CheckBox()
      Me.chkPOApproveBeforePrint = New System.Windows.Forms.CheckBox()
      Me.chkApprovePR = New System.Windows.Forms.CheckBox()
      Me.nudMaxLevelApprovePR = New System.Windows.Forms.NumericUpDown()
      Me.lblMaxLevelApprovePR = New System.Windows.Forms.Label()
      Me.chkPR = New System.Windows.Forms.CheckBox()
      Me.chkPO = New System.Windows.Forms.CheckBox()
      Me.chkDO = New System.Windows.Forms.CheckBox()
      Me.nudMaxLevelApprovePO = New System.Windows.Forms.NumericUpDown()
      Me.lblMaxLevelApprovePO = New System.Windows.Forms.Label()
      Me.nudMaxLevelApproveDO = New System.Windows.Forms.NumericUpDown()
      Me.lblMaxLevelApproveDO = New System.Windows.Forms.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.chkDR = New System.Windows.Forms.CheckBox()
      Me.nudMaxLevelApproveDR = New System.Windows.Forms.NumericUpDown()
      Me.lblMaxLevelApproveDR = New System.Windows.Forms.Label()
      Me.grbItems.SuspendLayout()
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'grbItems
      '
      Me.grbItems.Controls.Add(Me.chkDR)
      Me.grbItems.Controls.Add(Me.nudMaxLevelApproveDR)
      Me.grbItems.Controls.Add(Me.lblMaxLevelApproveDR)
      Me.grbItems.Controls.Add(Me.chkPA)
      Me.grbItems.Controls.Add(Me.nudMaxLevelApprovePA)
      Me.grbItems.Controls.Add(Me.lblMaxLevelApprovePA)
      Me.grbItems.Controls.Add(Me.chkSCApproveBeforePrint)
      Me.grbItems.Controls.Add(Me.chkSC)
      Me.grbItems.Controls.Add(Me.nudMaxLevelApproveSC)
      Me.grbItems.Controls.Add(Me.lblMaxLevelApproveSC)
      Me.grbItems.Controls.Add(Me.Panel2)
      Me.grbItems.Controls.Add(Me.nudMaxLevelApproveWR)
      Me.grbItems.Controls.Add(Me.lblMaxLevelApproveWR)
      Me.grbItems.Controls.Add(Me.chkWR)
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
      Me.grbItems.Size = New System.Drawing.Size(424, 285)
      Me.grbItems.TabIndex = 0
      Me.grbItems.TabStop = False
      Me.grbItems.Text = "เอกสารที่ต้องการการอนุมัติ"
      '
      'chkPA
      '
      Me.chkPA.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPA.Location = New System.Drawing.Point(24, 244)
      Me.chkPA.Name = "chkPA"
      Me.chkPA.Size = New System.Drawing.Size(176, 24)
      Me.chkPA.TabIndex = 20
      Me.chkPA.Tag = "NotGigaSite"
      Me.chkPA.Text = "ใบรับงาน (PA)"
      '
      'nudMaxLevelApprovePA
      '
      Me.nudMaxLevelApprovePA.Location = New System.Drawing.Point(336, 244)
      Me.nudMaxLevelApprovePA.Name = "nudMaxLevelApprovePA"
      Me.nudMaxLevelApprovePA.Size = New System.Drawing.Size(48, 21)
      Me.nudMaxLevelApprovePA.TabIndex = 22
      Me.nudMaxLevelApprovePA.Tag = "NotGigaSite"
      Me.nudMaxLevelApprovePA.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblMaxLevelApprovePA
      '
      Me.lblMaxLevelApprovePA.Location = New System.Drawing.Point(208, 244)
      Me.lblMaxLevelApprovePA.Name = "lblMaxLevelApprovePA"
      Me.lblMaxLevelApprovePA.Size = New System.Drawing.Size(128, 21)
      Me.lblMaxLevelApprovePA.TabIndex = 21
      Me.lblMaxLevelApprovePA.Tag = "NotGigaSite"
      Me.lblMaxLevelApprovePA.Text = "ระดับสูงสุดในการอนุมัติ"
      Me.lblMaxLevelApprovePA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkSCApproveBeforePrint
      '
      Me.chkSCApproveBeforePrint.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkSCApproveBeforePrint.Location = New System.Drawing.Point(40, 170)
      Me.chkSCApproveBeforePrint.Name = "chkSCApproveBeforePrint"
      Me.chkSCApproveBeforePrint.Size = New System.Drawing.Size(176, 24)
      Me.chkSCApproveBeforePrint.TabIndex = 18
      Me.chkSCApproveBeforePrint.Tag = "NotGigaSite"
      Me.chkSCApproveBeforePrint.Text = "ป้องกันการพิมพ์ก่อนการอนุมัติ"
      '
      'chkSC
      '
      Me.chkSC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkSC.Location = New System.Drawing.Point(24, 146)
      Me.chkSC.Name = "chkSC"
      Me.chkSC.Size = New System.Drawing.Size(176, 24)
      Me.chkSC.TabIndex = 15
      Me.chkSC.Tag = "NotGigaSite"
      Me.chkSC.Text = "ใบสั่งจ้าง(SC,VO)"
      '
      'nudMaxLevelApproveSC
      '
      Me.nudMaxLevelApproveSC.Location = New System.Drawing.Point(336, 146)
      Me.nudMaxLevelApproveSC.Name = "nudMaxLevelApproveSC"
      Me.nudMaxLevelApproveSC.Size = New System.Drawing.Size(48, 21)
      Me.nudMaxLevelApproveSC.TabIndex = 17
      Me.nudMaxLevelApproveSC.Tag = "NotGigaSite"
      Me.nudMaxLevelApproveSC.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblMaxLevelApproveSC
      '
      Me.lblMaxLevelApproveSC.Location = New System.Drawing.Point(208, 146)
      Me.lblMaxLevelApproveSC.Name = "lblMaxLevelApproveSC"
      Me.lblMaxLevelApproveSC.Size = New System.Drawing.Size(128, 21)
      Me.lblMaxLevelApproveSC.TabIndex = 16
      Me.lblMaxLevelApproveSC.Tag = "NotGigaSite"
      Me.lblMaxLevelApproveSC.Text = "ระดับสูงสุดในการอนุมัติ"
      Me.lblMaxLevelApproveSC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel2
      '
      Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel2.Location = New System.Drawing.Point(32, 154)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(104, 24)
      Me.Panel2.TabIndex = 19
      '
      'nudMaxLevelApproveWR
      '
      Me.nudMaxLevelApproveWR.Location = New System.Drawing.Point(336, 70)
      Me.nudMaxLevelApproveWR.Name = "nudMaxLevelApproveWR"
      Me.nudMaxLevelApproveWR.Size = New System.Drawing.Size(48, 21)
      Me.nudMaxLevelApproveWR.TabIndex = 14
      Me.nudMaxLevelApproveWR.Tag = "NotGigaSite"
      Me.nudMaxLevelApproveWR.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblMaxLevelApproveWR
      '
      Me.lblMaxLevelApproveWR.Location = New System.Drawing.Point(208, 70)
      Me.lblMaxLevelApproveWR.Name = "lblMaxLevelApproveWR"
      Me.lblMaxLevelApproveWR.Size = New System.Drawing.Size(128, 21)
      Me.lblMaxLevelApproveWR.TabIndex = 13
      Me.lblMaxLevelApproveWR.Tag = "NotGigaSite"
      Me.lblMaxLevelApproveWR.Text = "ระดับสูงสุดในการอนุมัติ"
      Me.lblMaxLevelApproveWR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkWR
      '
      Me.chkWR.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkWR.Location = New System.Drawing.Point(24, 68)
      Me.chkWR.Name = "chkWR"
      Me.chkWR.Size = New System.Drawing.Size(176, 24)
      Me.chkWR.TabIndex = 12
      Me.chkWR.Tag = "NotGigaSite"
      Me.chkWR.Text = "ใบขอจ้าง (WR)"
      '
      'chkPOApproveBeforePrint
      '
      Me.chkPOApproveBeforePrint.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPOApproveBeforePrint.Location = New System.Drawing.Point(40, 127)
      Me.chkPOApproveBeforePrint.Name = "chkPOApproveBeforePrint"
      Me.chkPOApproveBeforePrint.Size = New System.Drawing.Size(176, 24)
      Me.chkPOApproveBeforePrint.TabIndex = 10
      Me.chkPOApproveBeforePrint.Text = "ป้องกันการพิมพ์ก่อนการอนุมัติ"
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
      Me.chkPO.Location = New System.Drawing.Point(24, 103)
      Me.chkPO.Name = "chkPO"
      Me.chkPO.Size = New System.Drawing.Size(176, 24)
      Me.chkPO.TabIndex = 4
      Me.chkPO.Text = "ใบสั่งซื้อ (PO)"
      '
      'chkDO
      '
      Me.chkDO.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkDO.Location = New System.Drawing.Point(24, 223)
      Me.chkDO.Name = "chkDO"
      Me.chkDO.Size = New System.Drawing.Size(176, 24)
      Me.chkDO.TabIndex = 7
      Me.chkDO.Text = "ใบรับสินค้า"
      '
      'nudMaxLevelApprovePO
      '
      Me.nudMaxLevelApprovePO.Location = New System.Drawing.Point(336, 103)
      Me.nudMaxLevelApprovePO.Name = "nudMaxLevelApprovePO"
      Me.nudMaxLevelApprovePO.Size = New System.Drawing.Size(48, 21)
      Me.nudMaxLevelApprovePO.TabIndex = 6
      Me.nudMaxLevelApprovePO.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblMaxLevelApprovePO
      '
      Me.lblMaxLevelApprovePO.Location = New System.Drawing.Point(208, 103)
      Me.lblMaxLevelApprovePO.Name = "lblMaxLevelApprovePO"
      Me.lblMaxLevelApprovePO.Size = New System.Drawing.Size(128, 21)
      Me.lblMaxLevelApprovePO.TabIndex = 5
      Me.lblMaxLevelApprovePO.Text = "ระดับสูงสุดในการอนุมัติ"
      Me.lblMaxLevelApprovePO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'nudMaxLevelApproveDO
      '
      Me.nudMaxLevelApproveDO.Location = New System.Drawing.Point(336, 223)
      Me.nudMaxLevelApproveDO.Name = "nudMaxLevelApproveDO"
      Me.nudMaxLevelApproveDO.Size = New System.Drawing.Size(48, 21)
      Me.nudMaxLevelApproveDO.TabIndex = 9
      Me.nudMaxLevelApproveDO.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblMaxLevelApproveDO
      '
      Me.lblMaxLevelApproveDO.Location = New System.Drawing.Point(208, 223)
      Me.lblMaxLevelApproveDO.Name = "lblMaxLevelApproveDO"
      Me.lblMaxLevelApproveDO.Size = New System.Drawing.Size(128, 21)
      Me.lblMaxLevelApproveDO.TabIndex = 8
      Me.lblMaxLevelApproveDO.Text = "ระดับสูงสุดในการอนุมัติ"
      Me.lblMaxLevelApproveDO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel1
      '
      Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel1.Location = New System.Drawing.Point(32, 111)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(104, 24)
      Me.Panel1.TabIndex = 11
      '
      'chkDR
      '
      Me.chkDR.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkDR.Location = New System.Drawing.Point(24, 193)
      Me.chkDR.Name = "chkDR"
      Me.chkDR.Size = New System.Drawing.Size(176, 24)
      Me.chkDR.TabIndex = 23
      Me.chkDR.Text = "ใบหักค่าใช้จ่าย(DR)"
      '
      'nudMaxLevelApproveDR
      '
      Me.nudMaxLevelApproveDR.Location = New System.Drawing.Point(336, 193)
      Me.nudMaxLevelApproveDR.Name = "nudMaxLevelApproveDR"
      Me.nudMaxLevelApproveDR.Size = New System.Drawing.Size(48, 21)
      Me.nudMaxLevelApproveDR.TabIndex = 25
      Me.nudMaxLevelApproveDR.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'lblMaxLevelApproveDR
      '
      Me.lblMaxLevelApproveDR.Location = New System.Drawing.Point(208, 193)
      Me.lblMaxLevelApproveDR.Name = "lblMaxLevelApproveDR"
      Me.lblMaxLevelApproveDR.Size = New System.Drawing.Size(128, 21)
      Me.lblMaxLevelApproveDR.TabIndex = 24
      Me.lblMaxLevelApproveDR.Text = "ระดับสูงสุดในการอนุมัติ"
      Me.lblMaxLevelApproveDR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ApproveConfigurationView
      '
      Me.Controls.Add(Me.grbItems)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "ApproveConfigurationView"
      Me.Size = New System.Drawing.Size(472, 322)
      Me.grbItems.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean
    Public ConfigFilters(16) As Filter
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
      DisableGigaSiteControl()
    End Sub
    Private Sub DisableGigaSiteControl()
      If Longkong.Pojjaman.BusinessLogic.Configuration.CheckGigaSiteRight Then
        Me.chkDR.Enabled = False
        Me.nudMaxLevelApproveDR.Enabled = False
        Me.lblMaxLevelApproveDR.Enabled = False
        Me.chkPA.Enabled = False
        Me.nudMaxLevelApprovePA.Enabled = False
        Me.lblMaxLevelApprovePA.Enabled = False
        Me.chkSCApproveBeforePrint.Enabled = False
        Me.chkSC.Enabled = False
        Me.nudMaxLevelApproveSC.Enabled = False
        Me.lblMaxLevelApproveSC.Enabled = False
        Me.nudMaxLevelApproveWR.Enabled = False
        Me.lblMaxLevelApproveWR.Enabled = False
        Me.chkWR.Enabled = False
      End If
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

        Me.lblMaxLevelApproveWR.Visible = False
        Me.lblMaxLevelApproveSC.Visible = False
        Me.lblMaxLevelApprovePA.Visible = False

        Me.nudMaxLevelApprovePR.Visible = False
        Me.nudMaxLevelApprovePO.Visible = False
        Me.nudMaxLevelApproveDO.Visible = False

        Me.nudMaxLevelApproveWR.Visible = False
        Me.nudMaxLevelApproveSC.Visible = False
        Me.nudMaxLevelApprovePA.Visible = False
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

      Me.nudMaxLevelApproveWR.Enabled = chkWR.Checked
      Me.nudMaxLevelApproveSC.Enabled = chkSC.Checked
      Me.nudMaxLevelApproveDR.Enabled = chkDR.Checked
      Me.nudMaxLevelApprovePA.Enabled = chkPA.Checked

      Me.chkPOApproveBeforePrint.Enabled = chkPO.Checked
      Me.chkSCApproveBeforePrint.Enabled = chkSC.Checked

    End Sub
    Public Sub ClearDetail()
    End Sub
    Public Sub SetLabelText()
      Me.grbItems.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.grbItems}")
      Me.chkPR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkPR}")
      Me.chkWR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkWR}")
      Me.chkPO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkPO}")
      Me.chkSC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkSC}")
      Me.chkDR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkDR}")
      Me.chkPOApproveBeforePrint.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkPOApproveBeforePrint}")
      Me.chkSCApproveBeforePrint.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkSCApproveBeforePrint}")
      Me.chkDO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkDO}")
      Me.chkPA.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkPA}")
      Me.chkApprovePR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkApprovePR}")

      Me.lblMaxLevelApprovePR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApprovePR}")
      Me.lblMaxLevelApprovePO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApprovePO}")
      Me.lblMaxLevelApproveDO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApproveDO}")

      Me.lblMaxLevelApproveWR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApprovePR}")
      Me.lblMaxLevelApproveSC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApprovePO}")
      Me.lblMaxLevelApproveDR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApprovePO}")
      Me.lblMaxLevelApprovePA.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.lblMaxLevelApproveDO}")
    End Sub
    Protected Sub EventWiring()
      AddHandler chkPR.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkApprovePR.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkWR.CheckedChanged, AddressOf ChangeProperty

      AddHandler chkPO.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPOApproveBeforePrint.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkSC.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkSCApproveBeforePrint.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkDR.CheckedChanged, AddressOf ChangeProperty

      AddHandler chkDO.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPA.CheckedChanged, AddressOf ChangeProperty

      AddHandler nudMaxLevelApprovePR.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApprovePR.Click, AddressOf ChangeProperty
      AddHandler nudMaxLevelApprovePO.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApprovePO.Click, AddressOf ChangeProperty
      AddHandler nudMaxLevelApproveDO.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApproveDO.Click, AddressOf ChangeProperty

      AddHandler nudMaxLevelApproveWR.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApproveWR.Click, AddressOf ChangeProperty
      AddHandler nudMaxLevelApproveSC.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApproveSC.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApproveDR.Click, AddressOf ChangeProperty
      AddHandler nudMaxLevelApproveDR.Click, AddressOf ChangeProperty
      AddHandler nudMaxLevelApprovePA.Validated, AddressOf ChangeProperty
      AddHandler nudMaxLevelApprovePA.Click, AddressOf ChangeProperty
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
        Case "chkwr"
          Me.SetFilterValue("ApproveWR", chkWR.Checked)
          dirtyFlag = True
        Case "chkpo"
          Me.SetFilterValue("ApprovePO", chkPO.Checked)
          dirtyFlag = True
        Case "chkpoapprovebeforeprint"
          Me.SetFilterValue("POApproveBeforePrint", chkPOApproveBeforePrint.Checked)
          dirtyFlag = True
        Case "chksc"
          Me.SetFilterValue("ApproveSC", chkSC.Checked)
          dirtyFlag = True
        Case "chkdr"
          Me.SetFilterValue("ApproveDR", chkDR.Checked)
          dirtyFlag = True
        Case "chkscapprovebeforeprint"
          Me.SetFilterValue("SCApproveBeforePrint", chkSCApproveBeforePrint.Checked)
          dirtyFlag = True
        Case "chkdo"
          Me.SetFilterValue("ApproveDO", chkDO.Checked)
          dirtyFlag = True
        Case "chkpa"
          Me.SetFilterValue("ApprovePA", chkPA.Checked)
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
        Case "nudmaxlevelapprovewr"
          Me.SetFilterValue("MaxLevelApproveWR", nudMaxLevelApproveWR.Text)
          dirtyFlag = True
        Case "nudmaxlevelapprovesc"
          Me.SetFilterValue("MaxLevelApproveSC", nudMaxLevelApproveSC.Text)
          dirtyFlag = True
        Case "nudmaxlevelapprovedr"
          Me.SetFilterValue("MaxLevelApproveDR", nudMaxLevelApproveDR.Text)
          dirtyFlag = True
        Case "nudmaxlevelapprovepa"
          Me.SetFilterValue("MaxLevelApprovePA", nudMaxLevelApprovePA.Text)
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

      ConfigFilters(8) = New Filter("ApproveWR", Configuration.GetConfig("ApproveWR"))
      ConfigFilters(9) = New Filter("ApproveSC", Configuration.GetConfig("ApproveSC"))
      ConfigFilters(10) = New Filter("ApproveDR", Configuration.GetConfig("ApproveDR"))
      ConfigFilters(11) = New Filter("ApprovePA", Configuration.GetConfig("ApprovePA"))
      ConfigFilters(12) = New Filter("MaxLevelApproveWR", Configuration.GetConfig("MaxLevelApproveWR"))
      ConfigFilters(13) = New Filter("MaxLevelApproveSC", Configuration.GetConfig("MaxLevelApproveSC"))
      ConfigFilters(14) = New Filter("MaxLevelApproveDR", Configuration.GetConfig("MaxLevelApproveDR"))
      ConfigFilters(15) = New Filter("MaxLevelApprovePA", Configuration.GetConfig("MaxLevelApprovePA"))
      ConfigFilters(16) = New Filter("SCApproveBeforePrint", Configuration.GetConfig("SCApproveBeforePrint"))
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

      Me.chkWR.Checked = CBool(GetFilterValue("ApproveWR"))
      Me.chkSC.Checked = CBool(GetFilterValue("ApproveSC"))
      Me.chkDR.Checked = CBool(GetFilterValue("ApproveDR"))
      Me.chkSCApproveBeforePrint.Checked = CBool(GetFilterValue("SCApproveBeforePrint"))
      Me.chkPA.Checked = CBool(GetFilterValue("ApprovePA"))
      Me.nudMaxLevelApproveWR.Text = CInt(GetFilterValue("MaxLevelApproveWR"))
      Me.nudMaxLevelApproveSC.Text = CInt(GetFilterValue("MaxLevelApproveSC"))
      Me.nudMaxLevelApproveDR.Text = CInt(GetFilterValue("MaxLevelApproveDR"))
      Me.nudMaxLevelApprovePA.Text = CInt(GetFilterValue("MaxLevelApprovePA"))

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
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region


  End Class
End Namespace