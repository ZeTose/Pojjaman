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
  Public Class StockConfigurationView_
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
    Friend WithEvents pnl6 As System.Windows.Forms.Panel
    Friend WithEvents rd18 As System.Windows.Forms.RadioButton
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents rd17 As System.Windows.Forms.RadioButton
    Friend WithEvents rd16 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rd21 As System.Windows.Forms.RadioButton
    Friend WithEvents rd19 As System.Windows.Forms.RadioButton
    Friend WithEvents lbl7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rd24 As System.Windows.Forms.RadioButton
    Friend WithEvents rd23 As System.Windows.Forms.RadioButton
    Friend WithEvents rd22 As System.Windows.Forms.RadioButton
    Friend WithEvents lbl8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.pnl6 = New System.Windows.Forms.Panel
      Me.rd18 = New System.Windows.Forms.RadioButton
      Me.rd17 = New System.Windows.Forms.RadioButton
      Me.rd16 = New System.Windows.Forms.RadioButton
      Me.lbl6 = New System.Windows.Forms.Label
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.rd21 = New System.Windows.Forms.RadioButton
      Me.rd19 = New System.Windows.Forms.RadioButton
      Me.lbl7 = New System.Windows.Forms.Label
      Me.Panel2 = New System.Windows.Forms.Panel
      Me.rd24 = New System.Windows.Forms.RadioButton
      Me.rd23 = New System.Windows.Forms.RadioButton
      Me.rd22 = New System.Windows.Forms.RadioButton
      Me.lbl8 = New System.Windows.Forms.Label
      Me.grbDetail.SuspendLayout()
      Me.pnl6.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.Panel2)
      Me.grbDetail.Controls.Add(Me.pnl6)
      Me.grbDetail.Controls.Add(Me.Panel1)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(480, 312)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'pnl6
      '
      Me.pnl6.Controls.Add(Me.rd18)
      Me.pnl6.Controls.Add(Me.rd17)
      Me.pnl6.Controls.Add(Me.rd16)
      Me.pnl6.Controls.Add(Me.lbl6)
      Me.pnl6.Location = New System.Drawing.Point(16, 64)
      Me.pnl6.Name = "pnl6"
      Me.pnl6.Size = New System.Drawing.Size(470, 48)
      Me.pnl6.TabIndex = 1
      '
      'rd18
      '
      Me.rd18.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd18.Location = New System.Drawing.Point(368, 13)
      Me.rd18.Name = "rd18"
      Me.rd18.Size = New System.Drawing.Size(104, 32)
      Me.rd18.TabIndex = 3
      Me.rd18.Text = "ราคาซื้อล่าสุด"
      '
      'rd17
      '
      Me.rd17.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd17.Location = New System.Drawing.Point(256, 17)
      Me.rd17.Name = "rd17"
      Me.rd17.Size = New System.Drawing.Size(112, 24)
      Me.rd17.TabIndex = 2
      Me.rd17.Text = "ราคาซื้อล่าสุด (supplier)"
      '
      'rd16
      '
      Me.rd16.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd16.Location = New System.Drawing.Point(168, 13)
      Me.rd16.Name = "rd16"
      Me.rd16.Size = New System.Drawing.Size(104, 32)
      Me.rd16.TabIndex = 1
      Me.rd16.Text = "ฐานข้อมูล"
      '
      'lbl6
      '
      Me.lbl6.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lbl6.Location = New System.Drawing.Point(8, 18)
      Me.lbl6.Name = "lbl6"
      Me.lbl6.Size = New System.Drawing.Size(160, 23)
      Me.lbl6.TabIndex = 0
      Me.lbl6.Text = "ราคาที่ใช้ในการออก PO"
      Me.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.rd21)
      Me.Panel1.Controls.Add(Me.rd19)
      Me.Panel1.Controls.Add(Me.lbl7)
      Me.Panel1.Location = New System.Drawing.Point(16, 16)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(470, 48)
      Me.Panel1.TabIndex = 0
      '
      'rd21
      '
      Me.rd21.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd21.Location = New System.Drawing.Point(256, 17)
      Me.rd21.Name = "rd21"
      Me.rd21.Size = New System.Drawing.Size(112, 24)
      Me.rd21.TabIndex = 2
      Me.rd21.Text = "ราคาขอซื้อล่าสุด"
      '
      'rd19
      '
      Me.rd19.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd19.Location = New System.Drawing.Point(168, 13)
      Me.rd19.Name = "rd19"
      Me.rd19.Size = New System.Drawing.Size(104, 32)
      Me.rd19.TabIndex = 1
      Me.rd19.Text = "ฐานข้อมูล"
      '
      'lbl7
      '
      Me.lbl7.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lbl7.Location = New System.Drawing.Point(8, 18)
      Me.lbl7.Name = "lbl7"
      Me.lbl7.Size = New System.Drawing.Size(160, 23)
      Me.lbl7.TabIndex = 0
      Me.lbl7.Text = "ราคาที่ใช้ในการออก PR"
      Me.lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.rd24)
      Me.Panel2.Controls.Add(Me.rd23)
      Me.Panel2.Controls.Add(Me.rd22)
      Me.Panel2.Controls.Add(Me.lbl8)
      Me.Panel2.Location = New System.Drawing.Point(16, 112)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(470, 48)
      Me.Panel2.TabIndex = 0
      '
      'rd24
      '
      Me.rd24.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd24.Location = New System.Drawing.Point(368, 13)
      Me.rd24.Name = "rd24"
      Me.rd24.Size = New System.Drawing.Size(104, 32)
      Me.rd24.TabIndex = 2
      Me.rd24.Text = "ราคาซื้อล่าสุด"
      '
      'rd23
      '
      Me.rd23.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd23.Location = New System.Drawing.Point(256, 17)
      Me.rd23.Name = "rd23"
      Me.rd23.Size = New System.Drawing.Size(112, 24)
      Me.rd23.TabIndex = 1
      Me.rd23.Text = "ราคาซื้อล่าสุด (supplier)"
      '
      'rd22
      '
      Me.rd22.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd22.Location = New System.Drawing.Point(168, 13)
      Me.rd22.Name = "rd22"
      Me.rd22.Size = New System.Drawing.Size(104, 32)
      Me.rd22.TabIndex = 0
      Me.rd22.Text = "ฐานข้อมูล"
      '
      'lbl8
      '
      Me.lbl8.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lbl8.Location = New System.Drawing.Point(8, 18)
      Me.lbl8.Name = "lbl8"
      Me.lbl8.Size = New System.Drawing.Size(160, 23)
      Me.lbl8.TabIndex = 0
      Me.lbl8.Text = "ราคาที่ใช้ในการรับสินค้า"
      Me.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'StockConfigurationView_
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "StockConfigurationView_"
      Me.Size = New System.Drawing.Size(500, 328)
      Me.grbDetail.ResumeLayout(False)
      Me.pnl6.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.Panel2.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean
    Public ConfigFilters(2) As Filter
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
      Me.rd16.PerformClick()
      Me.rd19.PerformClick()
      Me.rd22.PerformClick()
    End Sub
    Public Sub SetLabelText()
      Me.rd18.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.rd18}")
      Me.lbl6.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.lbl6}")
      Me.rd17.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.rd17}")
      Me.rd16.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.rd16}")
      Me.rd21.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.rd21}")
      Me.rd19.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.rd19}")
      Me.lbl7.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.lbl7}")
      Me.rd24.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.rd24}")
      Me.rd23.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.rd23}")
      Me.rd22.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.rd22}")
      Me.lbl8.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.StockConfigurationView_.lbl8}")
    End Sub
    Protected Sub EventWiring()
      AddHandler rd16.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd17.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd18.CheckedChanged, AddressOf ChangeProperty

      AddHandler rd19.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd21.CheckedChanged, AddressOf ChangeProperty

      AddHandler rd22.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd23.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd24.CheckedChanged, AddressOf ChangeProperty
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "rd16", "rd17", "rd18"
          If rd16.Checked Then
            SetFilterValue("CompanyPOPricing", 0)
          ElseIf rd17.Checked Then
            SetFilterValue("CompanyPOPricing", 1)
          Else
            SetFilterValue("CompanyPOPricing", 2)
          End If
          dirtyFlag = True
        Case "rd19", "rd21"
          If rd19.Checked Then
            SetFilterValue("CompanyPRPricing", 0)
          ElseIf rd21.Checked Then
            SetFilterValue("CompanyPRPricing", 2)
          End If
          dirtyFlag = True
        Case "rd22", "rd23", "rd24"
          If rd22.Checked Then
            SetFilterValue("CompanyGRPricing", 0)
          ElseIf rd23.Checked Then
            SetFilterValue("CompanyGRPricing", 1)
          Else
            SetFilterValue("CompanyGRPricing", 2)
          End If
          dirtyFlag = True
      End Select
      Dirty = Dirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub Initialize()
      ConfigFilters(0) = New Filter("CompanyPOPricing", Configuration.GetConfig("CompanyPOPricing"))
      ConfigFilters(1) = New Filter("CompanyPRPricing", Configuration.GetConfig("CompanyPRPricing"))
      ConfigFilters(2) = New Filter("CompanyGRPricing", Configuration.GetConfig("CompanyGRPricing"))
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

      Dim tmp As Integer = CInt(GetFilterValue("CompanyPOPricing"))
      If tmp = 0 Then
        rd16.PerformClick()
      ElseIf tmp = 1 Then
        rd17.PerformClick()
      Else
        rd18.PerformClick()
      End If

      tmp = CInt(GetFilterValue("CompanyPRPricing"))
      If tmp = 0 Then
        rd19.PerformClick()
        'ElseIf tmp = 1 Then
        '    rd20.PerformClick()
      Else
        rd21.PerformClick()
      End If

      tmp = CInt(GetFilterValue("CompanyGRPricing"))
      If tmp = 0 Then
        rd22.PerformClick()
      ElseIf tmp = 1 Then
        rd23.PerformClick()
      Else
        rd24.PerformClick()
      End If

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