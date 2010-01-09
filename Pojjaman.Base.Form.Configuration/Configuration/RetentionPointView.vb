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
  Public Class RetentionPointView
    'Inherits UserControl
    Inherits AbstractOptionPanel
    Implements IValidatable

#Region " Windows Form Designer generated code "
    'UserControl overrides dispose to clean up the component list.
    Private Property rd7 As Object
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
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.pnl1 = New System.Windows.Forms.Panel()
      Me.lbl1 = New System.Windows.Forms.Label()
      Me.rd2 = New System.Windows.Forms.RadioButton()
      Me.rd1 = New System.Windows.Forms.RadioButton()
      Me.pnl2 = New System.Windows.Forms.Panel()
      Me.lbl2 = New System.Windows.Forms.Label()
      Me.rd5 = New System.Windows.Forms.RadioButton()
      Me.rd4 = New System.Windows.Forms.RadioButton()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.pnl1.SuspendLayout()
      Me.pnl2.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'pnl1
      '
      Me.pnl1.Controls.Add(Me.lbl1)
      Me.pnl1.Controls.Add(Me.rd2)
      Me.pnl1.Controls.Add(Me.rd1)
      Me.pnl1.Location = New System.Drawing.Point(8, 24)
      Me.pnl1.Name = "pnl1"
      Me.pnl1.Size = New System.Drawing.Size(408, 72)
      Me.pnl1.TabIndex = 0
      '
      'lbl1
      '
      Me.lbl1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lbl1.Location = New System.Drawing.Point(8, 18)
      Me.lbl1.Name = "lbl1"
      Me.lbl1.Size = New System.Drawing.Size(58, 23)
      Me.lbl1.TabIndex = 0
      Me.lbl1.Text = "ฝั่งจ่าย"
      Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'rd2
      '
      Me.rd2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd2.Location = New System.Drawing.Point(256, 17)
      Me.rd2.Name = "rd2"
      Me.rd2.Size = New System.Drawing.Size(149, 24)
      Me.rd2.TabIndex = 2
      Me.rd2.Text = "คิด Retention เมื่อจ่าย"
      '
      'rd1
      '
      Me.rd1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd1.Location = New System.Drawing.Point(87, 16)
      Me.rd1.Name = "rd1"
      Me.rd1.Size = New System.Drawing.Size(152, 24)
      Me.rd1.TabIndex = 1
      Me.rd1.Text = "คิด Retention เมื่อตั้งหนี้"
      '
      'pnl2
      '
      Me.pnl2.Controls.Add(Me.lbl2)
      Me.pnl2.Controls.Add(Me.rd5)
      Me.pnl2.Controls.Add(Me.rd4)
      Me.pnl2.Location = New System.Drawing.Point(8, 104)
      Me.pnl2.Name = "pnl2"
      Me.pnl2.Size = New System.Drawing.Size(408, 72)
      Me.pnl2.TabIndex = 1
      '
      'lbl2
      '
      Me.lbl2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lbl2.Location = New System.Drawing.Point(8, 18)
      Me.lbl2.Name = "lbl2"
      Me.lbl2.Size = New System.Drawing.Size(58, 23)
      Me.lbl2.TabIndex = 0
      Me.lbl2.Text = "ฝั่งรับ"
      Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'rd5
      '
      Me.rd5.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd5.Location = New System.Drawing.Point(256, 16)
      Me.rd5.Name = "rd5"
      Me.rd5.Size = New System.Drawing.Size(149, 24)
      Me.rd5.TabIndex = 2
      Me.rd5.Text = "คิด Retention เมื่อรับ"
      '
      'rd4
      '
      Me.rd4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.rd4.Location = New System.Drawing.Point(87, 16)
      Me.rd4.Name = "rd4"
      Me.rd4.Size = New System.Drawing.Size(152, 24)
      Me.rd4.TabIndex = 1
      Me.rd4.Text = "คิด Retention เมื่อตั้งหนี้"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.pnl1)
      Me.grbDetail.Controls.Add(Me.pnl2)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(424, 312)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'RetentionPointView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RetentionPointView"
      Me.Size = New System.Drawing.Size(440, 328)
      Me.pnl1.ResumeLayout(False)
      Me.pnl2.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean
    Public ConfigFilters(1) As Filter
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
      Me.rd1.PerformClick()
      Me.rd4.PerformClick()
    End Sub
    Public Sub SetLabelText()
      Me.lbl1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RetentionPointView.lbl1}")
      Me.rd1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RetentionPointView.AtAP}")
      Me.rd2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RetentionPointView.AtPaid}")

      Me.lbl2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RetentionPointView.lbl2}")
      Me.rd4.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RetentionPointView.AtAR}")
      Me.rd5.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RetentionPointView.AtReceive}")
    End Sub
    Protected Sub EventWiring()
      AddHandler rd1.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd2.CheckedChanged, AddressOf ChangeProperty

      AddHandler rd4.CheckedChanged, AddressOf ChangeProperty
      AddHandler rd5.CheckedChanged, AddressOf ChangeProperty
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "rd1", "rd2", "rd3"
          If rd1.Checked Then
            SetFilterValue("APRetentionPoint", 0)
          Else
            SetFilterValue("APRetentionPoint", 1)
          End If
          dirtyFlag = True
        Case "rd4", "rd5"
          If rd4.Checked Then
            SetFilterValue("ARRetentionPoint", 0)
          Else
            SetFilterValue("ARRetentionPoint", 1)
          End If
          dirtyFlag = True
      End Select
      Dirty = Dirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub Initialize()
      ConfigFilters(0) = New Filter("APRetentionPoint", Configuration.GetConfig("APRetentionPoint"))
      ConfigFilters(1) = New Filter("ARRetentionPoint", Configuration.GetConfig("ARRetentionPoint"))
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

      Dim tmp As Integer = CInt(GetFilterValue("APRetentionPoint"))
      If tmp = 0 Then
        rd1.PerformClick()
      ElseIf tmp = 1 Then
        rd2.PerformClick()
      End If

      tmp = CInt(GetFilterValue("ARRetentionPoint"))
      If tmp = 0 Then
        rd4.PerformClick()
      ElseIf tmp = 1 Then
        rd5.PerformClick()
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