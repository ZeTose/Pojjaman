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
  Public Class OverBudgetConfigurationView
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
    Friend WithEvents grbDetail As FixedGroupBox
    Friend WithEvents pnl1 As System.Windows.Forms.Panel
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents rd2 As System.Windows.Forms.RadioButton
    Friend WithEvents rd1 As System.Windows.Forms.RadioButton
    Friend WithEvents pnl2 As System.Windows.Forms.Panel
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents rd5 As System.Windows.Forms.RadioButton
    Friend WithEvents rd4 As System.Windows.Forms.RadioButton
    Friend WithEvents pnl3 As System.Windows.Forms.Panel
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents rd8 As System.Windows.Forms.RadioButton
    Friend WithEvents rd7 As System.Windows.Forms.RadioButton
    Friend WithEvents rd3 As System.Windows.Forms.RadioButton
    Friend WithEvents rd6 As System.Windows.Forms.RadioButton
    Friend WithEvents rd9 As System.Windows.Forms.RadioButton
    Friend WithEvents chkPR As System.Windows.Forms.CheckBox
    Friend WithEvents chkPO As System.Windows.Forms.CheckBox
    Friend WithEvents chkPRWBSOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkGRWBSOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkPOWBSOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkPUR As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.pnl1 = New System.Windows.Forms.Panel()
      Me.chkPRWBSOnly = New System.Windows.Forms.CheckBox()
      Me.chkPR = New System.Windows.Forms.CheckBox()
      Me.rd3 = New System.Windows.Forms.RadioButton()
      Me.lbl1 = New System.Windows.Forms.Label()
      Me.rd2 = New System.Windows.Forms.RadioButton()
      Me.rd1 = New System.Windows.Forms.RadioButton()
      Me.pnl2 = New System.Windows.Forms.Panel()
      Me.rd6 = New System.Windows.Forms.RadioButton()
      Me.lbl2 = New System.Windows.Forms.Label()
      Me.rd5 = New System.Windows.Forms.RadioButton()
      Me.rd4 = New System.Windows.Forms.RadioButton()
      Me.chkPOWBSOnly = New System.Windows.Forms.CheckBox()
      Me.chkPO = New System.Windows.Forms.CheckBox()
      Me.pnl3 = New System.Windows.Forms.Panel()
      Me.rd9 = New System.Windows.Forms.RadioButton()
      Me.lbl3 = New System.Windows.Forms.Label()
      Me.rd8 = New System.Windows.Forms.RadioButton()
      Me.rd7 = New System.Windows.Forms.RadioButton()
      Me.chkGRWBSOnly = New System.Windows.Forms.CheckBox()
      Me.chkPUR = New System.Windows.Forms.CheckBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnl1.SuspendLayout()
      Me.pnl2.SuspendLayout()
      Me.pnl3.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'pnl1
      '
      Me.pnl1.Controls.Add(Me.chkPRWBSOnly)
      Me.pnl1.Controls.Add(Me.chkPR)
      Me.pnl1.Controls.Add(Me.rd3)
      Me.pnl1.Controls.Add(Me.lbl1)
      Me.pnl1.Controls.Add(Me.rd2)
      Me.pnl1.Controls.Add(Me.rd1)
      Me.pnl1.Location = New System.Drawing.Point(8, 24)
      Me.pnl1.Name = "pnl1"
      Me.pnl1.Size = New System.Drawing.Size(408, 81)
      Me.pnl1.TabIndex = 0
      '
      'chkPRWBSOnly
      '
      Me.chkPRWBSOnly.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPRWBSOnly.Location = New System.Drawing.Point(156, 57)
      Me.chkPRWBSOnly.Name = "chkPRWBSOnly"
      Me.chkPRWBSOnly.Size = New System.Drawing.Size(237, 24)
      Me.chkPRWBSOnly.TabIndex = 1
      Me.chkPRWBSOnly.Text = "Lock ตาม WBS(ไม่รวม Budget ลูก) ด้วย"
      '
      'chkPR
      '
      Me.chkPR.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPR.Location = New System.Drawing.Point(136, 36)
      Me.chkPR.Name = "chkPR"
      Me.chkPR.Size = New System.Drawing.Size(160, 24)
      Me.chkPR.TabIndex = 1
      Me.chkPR.Text = "Lock ตาม CostCenter เท่านั้น"
      '
      'rd3
      '
      Me.rd3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd3.Location = New System.Drawing.Point(288, 16)
      Me.rd3.Name = "rd3"
      Me.rd3.Size = New System.Drawing.Size(104, 24)
      Me.rd3.TabIndex = 4
      Me.rd3.Text = "ไม่เตือน"
      '
      'lbl1
      '
      Me.lbl1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lbl1.Location = New System.Drawing.Point(8, 18)
      Me.lbl1.Name = "lbl1"
      Me.lbl1.Size = New System.Drawing.Size(96, 23)
      Me.lbl1.TabIndex = 0
      Me.lbl1.Text = "ใบขอซื้อ (PR)"
      Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'rd2
      '
      Me.rd2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd2.Location = New System.Drawing.Point(200, 16)
      Me.rd2.Name = "rd2"
      Me.rd2.Size = New System.Drawing.Size(104, 24)
      Me.rd2.TabIndex = 3
      Me.rd2.Text = "เตือน"
      '
      'rd1
      '
      Me.rd1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd1.Location = New System.Drawing.Point(112, 16)
      Me.rd1.Name = "rd1"
      Me.rd1.Size = New System.Drawing.Size(104, 24)
      Me.rd1.TabIndex = 2
      Me.rd1.Text = "ไม่อนุญาต"
      '
      'pnl2
      '
      Me.pnl2.Controls.Add(Me.rd6)
      Me.pnl2.Controls.Add(Me.lbl2)
      Me.pnl2.Controls.Add(Me.rd5)
      Me.pnl2.Controls.Add(Me.rd4)
      Me.pnl2.Controls.Add(Me.chkPOWBSOnly)
      Me.pnl2.Controls.Add(Me.chkPO)
      Me.pnl2.Location = New System.Drawing.Point(8, 109)
      Me.pnl2.Name = "pnl2"
      Me.pnl2.Size = New System.Drawing.Size(408, 81)
      Me.pnl2.TabIndex = 2
      '
      'rd6
      '
      Me.rd6.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd6.Location = New System.Drawing.Point(288, 16)
      Me.rd6.Name = "rd6"
      Me.rd6.Size = New System.Drawing.Size(104, 24)
      Me.rd6.TabIndex = 4
      Me.rd6.Text = "ไม่เตือน"
      '
      'lbl2
      '
      Me.lbl2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lbl2.Location = New System.Drawing.Point(8, 18)
      Me.lbl2.Name = "lbl2"
      Me.lbl2.Size = New System.Drawing.Size(96, 23)
      Me.lbl2.TabIndex = 0
      Me.lbl2.Text = "ใบสั่งซื้อ (PO)"
      Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'rd5
      '
      Me.rd5.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd5.Location = New System.Drawing.Point(200, 16)
      Me.rd5.Name = "rd5"
      Me.rd5.Size = New System.Drawing.Size(104, 24)
      Me.rd5.TabIndex = 3
      Me.rd5.Text = "เตือน"
      '
      'rd4
      '
      Me.rd4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd4.Location = New System.Drawing.Point(112, 16)
      Me.rd4.Name = "rd4"
      Me.rd4.Size = New System.Drawing.Size(104, 24)
      Me.rd4.TabIndex = 2
      Me.rd4.Text = "ไม่อนุญาต"
      '
      'chkPOWBSOnly
      '
      Me.chkPOWBSOnly.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPOWBSOnly.Location = New System.Drawing.Point(156, 57)
      Me.chkPOWBSOnly.Name = "chkPOWBSOnly"
      Me.chkPOWBSOnly.Size = New System.Drawing.Size(236, 24)
      Me.chkPOWBSOnly.TabIndex = 1
      Me.chkPOWBSOnly.Text = "Lock ตาม WBS(ไม่รวม Budget ลูก) ด้วย"
      '
      'chkPO
      '
      Me.chkPO.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPO.Location = New System.Drawing.Point(136, 36)
      Me.chkPO.Name = "chkPO"
      Me.chkPO.Size = New System.Drawing.Size(160, 24)
      Me.chkPO.TabIndex = 1
      Me.chkPO.Text = "Lock ตาม CostCenter เท่านั้น"
      '
      'pnl3
      '
      Me.pnl3.Controls.Add(Me.rd9)
      Me.pnl3.Controls.Add(Me.lbl3)
      Me.pnl3.Controls.Add(Me.rd8)
      Me.pnl3.Controls.Add(Me.rd7)
      Me.pnl3.Controls.Add(Me.chkGRWBSOnly)
      Me.pnl3.Controls.Add(Me.chkPUR)
      Me.pnl3.Location = New System.Drawing.Point(8, 194)
      Me.pnl3.Name = "pnl3"
      Me.pnl3.Size = New System.Drawing.Size(408, 81)
      Me.pnl3.TabIndex = 1
      '
      'rd9
      '
      Me.rd9.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd9.Location = New System.Drawing.Point(288, 16)
      Me.rd9.Name = "rd9"
      Me.rd9.Size = New System.Drawing.Size(105, 24)
      Me.rd9.TabIndex = 4
      Me.rd9.Text = "ไม่เตือน"
      '
      'lbl3
      '
      Me.lbl3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lbl3.Location = New System.Drawing.Point(8, 18)
      Me.lbl3.Name = "lbl3"
      Me.lbl3.Size = New System.Drawing.Size(96, 23)
      Me.lbl3.TabIndex = 0
      Me.lbl3.Text = "ใบซื้อสินค้า/บริการ"
      Me.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'rd8
      '
      Me.rd8.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd8.Location = New System.Drawing.Point(200, 16)
      Me.rd8.Name = "rd8"
      Me.rd8.Size = New System.Drawing.Size(112, 24)
      Me.rd8.TabIndex = 3
      Me.rd8.Text = "เตือน"
      '
      'rd7
      '
      Me.rd7.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd7.Location = New System.Drawing.Point(112, 16)
      Me.rd7.Name = "rd7"
      Me.rd7.Size = New System.Drawing.Size(112, 24)
      Me.rd7.TabIndex = 2
      Me.rd7.Text = "ไม่อนุญาต"
      '
      'chkGRWBSOnly
      '
      Me.chkGRWBSOnly.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkGRWBSOnly.Location = New System.Drawing.Point(156, 57)
      Me.chkGRWBSOnly.Name = "chkGRWBSOnly"
      Me.chkGRWBSOnly.Size = New System.Drawing.Size(237, 24)
      Me.chkGRWBSOnly.TabIndex = 1
      Me.chkGRWBSOnly.Text = "Lock ตาม WBS(ไม่รวม Budget ลูก) ด้วย"
      '
      'chkPUR
      '
      Me.chkPUR.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPUR.Location = New System.Drawing.Point(136, 36)
      Me.chkPUR.Name = "chkPUR"
      Me.chkPUR.Size = New System.Drawing.Size(160, 24)
      Me.chkPUR.TabIndex = 1
      Me.chkPUR.Text = "Lock ตาม CostCenter เท่านั้น"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.pnl1)
      Me.grbDetail.Controls.Add(Me.pnl3)
      Me.grbDetail.Controls.Add(Me.pnl2)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(424, 312)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'OverBudgetConfigurationView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "OverBudgetConfigurationView"
      Me.Size = New System.Drawing.Size(440, 328)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnl1.ResumeLayout(False)
      Me.pnl2.ResumeLayout(False)
      Me.pnl3.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean
    Public ConfigFilters(8) As Filter
    Private Dirty As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()
    End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
    Public Sub CheckFormEnable()
    End Sub
    Public Sub ClearDetail()
      Me.rd3.PerformClick()
      Me.rd6.PerformClick()
      Me.rd9.PerformClick()
    End Sub
    Public Sub SetLabelText()
      Me.lbl1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OverBudgetConfigurationView.lbl1}")
      Me.chkPR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OverBudgetConfigurationView.chkPR}")
      Me.chkPRWBSOnly.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OverBudgetConfigurationView.chkPRWBSOnly}")
      Me.rd1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView.NotAllow}")
      Me.rd2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView.Warn}")
      Me.rd3.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView.NotWarn}")

      Me.lbl2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OverBudgetConfigurationView.lbl2}")
      Me.chkPO.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OverBudgetConfigurationView.chkPO}")
      Me.chkPOWBSOnly.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OverBudgetConfigurationView.chkPOWBSOnly}")
      Me.rd4.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView.NotAllow}")
      Me.rd5.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView.Warn}")
      Me.rd6.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView.NotWarn}")

      Me.lbl3.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OverBudgetConfigurationView.lbl3}")
      Me.chkPUR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OverBudgetConfigurationView.chkPUR}")
      Me.chkGRWBSOnly.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OverBudgetConfigurationView.chkGRWBSOnly}")
      Me.rd7.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView.NotAllow}")
      Me.rd8.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView.Warn}")
      Me.rd9.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView.NotWarn}")
    End Sub
    Protected Sub EventWiring()
      AddHandler rd1.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd2.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd3.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPR.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPRWBSOnly.CheckedChanged, AddressOf ChangeProperty

      AddHandler rd4.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd5.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd6.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPO.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPOWBSOnly.CheckedChanged, AddressOf ChangeProperty

      AddHandler rd7.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd8.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd9.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPUR.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkGRWBSOnly.CheckedChanged, AddressOf ChangeProperty
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "rd1", "rd2", "rd3"
          If rd1.Checked Then
            SetFilterValue("PROverBudget", 0)
          ElseIf rd2.Checked Then
            SetFilterValue("PROverBudget", 1)
          Else
            SetFilterValue("PROverBudget", 2)
          End If
          dirtyFlag = True
        Case "rd4", "rd5", "rd6"
          If rd4.Checked Then
            SetFilterValue("POOverBudget", 0)
          ElseIf rd5.Checked Then
            SetFilterValue("POOverBudget", 1)
          Else
            SetFilterValue("POOverBudget", 2)
          End If
          dirtyFlag = True
        Case "rd7", "rd8", "rd9"
          If rd7.Checked Then
            SetFilterValue("GROverBudget", 0)
          ElseIf rd8.Checked Then
            SetFilterValue("GROverBudget", 1)
          Else
            SetFilterValue("GROverBudget", 2)
          End If
          dirtyFlag = True

        Case "chkpr"
          SetFilterValue("PROverBudgetOnlyCC", chkPR.Checked)
          'If chkPR.Checked Then
          '  chkPRWBSOnly.Checked = False
          'End If
          dirtyFlag = True
        Case "chkpo"
          SetFilterValue("POOverBudgetOnlyCC", chkPO.Checked)
          'If chkPO.Checked Then
          '  chkPOWBSOnly.Checked = False
          'End If
          dirtyFlag = True
        Case "chkpur"
          SetFilterValue("GROverBudgetOnlyCC", chkPUR.Checked)
          'If chkPUR.Checked Then
          '  chkGRWBSOnly.Checked = False
          'End If
          dirtyFlag = True

        Case "chkprwbsonly"
          SetFilterValue("PROverBudgetOnlyWBSAllocate", chkPRWBSOnly.Checked)
          'If chkPRWBSOnly.Checked Then
          '  chkPR.Checked = False
          'End If
          dirtyFlag = True
        Case "chkpowbsonly"
          SetFilterValue("POOverBudgetOnlyWBSAllocate", chkPOWBSOnly.Checked)
          'If chkPOWBSOnly.Checked Then
          '  chkPO.Checked = False
          'End If
          dirtyFlag = True
        Case "chkgrwbsonly"
          SetFilterValue("GROverBudgetOnlyWBSAllocate", chkGRWBSOnly.Checked)
          'If chkGRWBSOnly.Checked Then
          '  chkPUR.Checked = False
          'End If
          dirtyFlag = True
      End Select
      Dirty = Dirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub Initialize()
      ConfigFilters(0) = New Filter("PROverBudget", Configuration.GetConfig("PROverBudget"))
      ConfigFilters(1) = New Filter("POOverBudget", Configuration.GetConfig("POOverBudget"))
      ConfigFilters(2) = New Filter("GROverBudget", Configuration.GetConfig("GROverBudget"))
      ConfigFilters(3) = New Filter("PROverBudgetOnlyCC", Configuration.GetConfig("PROverBudgetOnlyCC"))
      ConfigFilters(4) = New Filter("POOverBudgetOnlyCC", Configuration.GetConfig("POOverBudgetOnlyCC"))
      ConfigFilters(5) = New Filter("GROverBudgetOnlyCC", Configuration.GetConfig("GROverBudgetOnlyCC"))
      ConfigFilters(6) = New Filter("PROverBudgetOnlyWBSAllocate", Configuration.GetConfig("PROverBudgetOnlyWBSAllocate"))
      ConfigFilters(7) = New Filter("POOverBudgetOnlyWBSAllocate", Configuration.GetConfig("POOverBudgetOnlyWBSAllocate"))
      ConfigFilters(8) = New Filter("GROverBudgetOnlyWBSAllocate", Configuration.GetConfig("GROverBudgetOnlyWBSAllocate"))
    End Sub
    Private Sub SetFilterValue(ByVal name As String, ByVal value As Object)
      For Each filter As filter In ConfigFilters
        If filter.Name.ToLower = name.ToLower Then
          filter.Value = value
          Exit For
        End If
      Next
    End Sub
    Private Function GetFilterValue(ByVal name As String) As Object
      For Each filter As filter In ConfigFilters
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

      Dim tmp As Integer = CInt(GetFilterValue("PROverBudget"))
      If tmp = 0 Then
        rd1.PerformClick()
      ElseIf tmp = 1 Then
        rd2.PerformClick()
      Else
        rd3.PerformClick()
      End If

      tmp = CInt(GetFilterValue("POOverBudget"))
      If tmp = 0 Then
        rd4.PerformClick()
      ElseIf tmp = 1 Then
        rd5.PerformClick()
      Else
        rd6.PerformClick()
      End If

      tmp = CInt(GetFilterValue("GROverBudget"))
      If tmp = 0 Then
        rd7.PerformClick()
      ElseIf tmp = 1 Then
        rd8.PerformClick()
      Else
        rd9.PerformClick()
      End If

      Dim tmp2 As Boolean = CBool(GetFilterValue("PROverBudgetOnlyCC"))
      chkPR.Checked = tmp2
      tmp2 = CBool(GetFilterValue("POOverBudgetOnlyCC"))
      chkPO.Checked = tmp2
      tmp2 = CBool(GetFilterValue("GROverBudgetOnlyCC"))
      chkPUR.Checked = tmp2


      Dim tmp3 As Boolean = CBool(GetFilterValue("PROverBudgetOnlyWBSAllocate"))
      chkPRWBSOnly.Checked = tmp3
      tmp3 = CBool(GetFilterValue("POOverBudgetOnlyWBSAllocate"))
      chkPOWBSOnly.Checked = tmp3
      tmp3 = CBool(GetFilterValue("GROverBudgetOnlyWBSAllocate"))
      chkGRWBSOnly.Checked = tmp3

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