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
  Public Class CheckConfigurationView
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
    Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkCheckRegist As System.Windows.Forms.CheckBox
    Friend WithEvents chkOneCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllowNoCQCodeDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllowNoCQCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkCanChangeRecipient As System.Windows.Forms.CheckBox
    Friend WithEvents chkCheckDateFromWHT As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAllowNoCQCodeDate = New System.Windows.Forms.CheckBox()
      Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkCheckRegist = New System.Windows.Forms.CheckBox()
      Me.chkOneCheck = New System.Windows.Forms.CheckBox()
      Me.chkAllowNoCQCode = New System.Windows.Forms.CheckBox()
      Me.chkCheckDateFromWHT = New System.Windows.Forms.CheckBox()
      Me.chkCanChangeRecipient = New System.Windows.Forms.CheckBox()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.grbItem.SuspendLayout()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.chkAllowNoCQCodeDate)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(408, 56)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Tag = "NotGigaSite"
      Me.grbDetail.Text = "เลขที่เช็ค"
      '
      'chkAllowNoCQCodeDate
      '
      Me.chkAllowNoCQCodeDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkAllowNoCQCodeDate.Location = New System.Drawing.Point(32, 24)
      Me.chkAllowNoCQCodeDate.Name = "chkAllowNoCQCodeDate"
      Me.chkAllowNoCQCodeDate.Size = New System.Drawing.Size(336, 24)
      Me.chkAllowNoCQCodeDate.TabIndex = 0
      Me.chkAllowNoCQCodeDate.Text = "อนุญาตให้สร้างเช็คโดยไม่ต้องใส่เลขที่และวันที่"
      '
      'grbItem
      '
      Me.grbItem.Controls.Add(Me.chkCanChangeRecipient)
      Me.grbItem.Controls.Add(Me.chkCheckRegist)
      Me.grbItem.Controls.Add(Me.chkOneCheck)
      Me.grbItem.Controls.Add(Me.chkAllowNoCQCode)
      Me.grbItem.Controls.Add(Me.chkCheckDateFromWHT)
      Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbItem.Location = New System.Drawing.Point(8, 72)
      Me.grbItem.Name = "grbItem"
      Me.grbItem.Size = New System.Drawing.Size(408, 162)
      Me.grbItem.TabIndex = 2
      Me.grbItem.TabStop = False
      Me.grbItem.Tag = "NotGigaSite"
      Me.grbItem.Text = "อื่นๆ"
      '
      'chkCheckRegist
      '
      Me.chkCheckRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkCheckRegist.Location = New System.Drawing.Point(32, 48)
      Me.chkCheckRegist.Name = "chkCheckRegist"
      Me.chkCheckRegist.Size = New System.Drawing.Size(344, 24)
      Me.chkCheckRegist.TabIndex = 1
      Me.chkCheckRegist.Text = "ใช้ระบบทะเบียนเช็ค"
      '
      'chkOneCheck
      '
      Me.chkOneCheck.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkOneCheck.Location = New System.Drawing.Point(32, 24)
      Me.chkOneCheck.Name = "chkOneCheck"
      Me.chkOneCheck.Size = New System.Drawing.Size(344, 24)
      Me.chkOneCheck.TabIndex = 0
      Me.chkOneCheck.Text = "มีเช็คได้เพียง 1 ใบ/ใบสำคัญจ่าย"
      '
      'chkAllowNoCQCode
      '
      Me.chkAllowNoCQCode.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkAllowNoCQCode.Location = New System.Drawing.Point(32, 72)
      Me.chkAllowNoCQCode.Name = "chkAllowNoCQCode"
      Me.chkAllowNoCQCode.Size = New System.Drawing.Size(344, 24)
      Me.chkAllowNoCQCode.TabIndex = 2
      Me.chkAllowNoCQCode.Text = "ไม่ต้องใส่เลขที่เช็ค หากเป็นการโอนเงินระหว่างบัญชีแบบกระแสรายวัน"
      '
      'chkCheckDateFromWHT
      '
      Me.chkCheckDateFromWHT.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkCheckDateFromWHT.Location = New System.Drawing.Point(32, 96)
      Me.chkCheckDateFromWHT.Name = "chkCheckDateFromWHT"
      Me.chkCheckDateFromWHT.Size = New System.Drawing.Size(360, 24)
      Me.chkCheckDateFromWHT.TabIndex = 2
      Me.chkCheckDateFromWHT.Text = "วันที่บนเช็คที่สร้างใหม่ใน Tab จ่ายเงิน ให้มีค่าเริ่มต้นเป็นตามใบหัก ณ ที่จ่าย"
      '
      'chkCanChangeRecipient
      '
      Me.chkCanChangeRecipient.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkCanChangeRecipient.Location = New System.Drawing.Point(32, 117)
      Me.chkCanChangeRecipient.Name = "chkCanChangeRecipient"
      Me.chkCanChangeRecipient.Size = New System.Drawing.Size(360, 25)
      Me.chkCanChangeRecipient.TabIndex = 3
      Me.chkCanChangeRecipient.Text = "สามารถเปลี่ยนชื่อผู้รับเช็คจ่ายได้"
      '
      'CheckConfigurationView
      '
      Me.Controls.Add(Me.grbItem)
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "CheckConfigurationView"
      Me.Size = New System.Drawing.Size(424, 304)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grbItem.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean
    Public ConfigFilters(5) As Filter
    Private Dirty As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()
      DisableGigaSiteControl()
    End Sub
    Private Sub DisableGigaSiteControl()
      If Longkong.Pojjaman.BusinessLogic.Configuration.CheckGigaSiteRight Then
        Me.grbDetail.Enabled = False
        Me.grbItem.Enabled = False
      End If
    End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
    Public Sub CheckFormEnable()
    End Sub
    Public Sub ClearDetail()
    End Sub
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckConfigurationView.grbDetail}")
      Me.chkAllowNoCQCodeDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckConfigurationView.chkAllowNoCQCodeDate}")
      Me.chkOneCheck.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckConfigurationView.chkOneCheck}")
      Me.chkCheckRegist.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckConfigurationView.chkCheckRegist}")
      Me.chkAllowNoCQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckConfigurationView.chkAllowNoCqCode}")
      Me.chkCheckDateFromWHT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckConfigurationView.chkCheckDateFromWHT}")
      'Me.chkCanChangeRecipeint.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckConfigurationView.chkCheckDateFromWHT}")
    End Sub
    Protected Sub EventWiring()
      AddHandler chkAllowNoCQCodeDate.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkOneCheck.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkCheckRegist.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkAllowNoCQCode.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkCheckDateFromWHT.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkCanChangeRecipient.CheckedChanged, AddressOf ChangeProperty
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "chkallownocqcodedate"
          Me.SetFilterValue("AllowNoCqCodeDate", chkAllowNoCQCodeDate.Checked)
          dirtyFlag = True
        Case "chkonecheck"
          Me.SetFilterValue("OneCheckPerPV", chkOneCheck.Checked)
          dirtyFlag = True
        Case "chkcheckregist"
          Me.SetFilterValue("UseCheckRegistration", chkCheckRegist.Checked)
          dirtyFlag = True
        Case "chkallownocqcode"
          Me.SetFilterValue("AllowNoCqCode", chkAllowNoCQCode.Checked)
          dirtyFlag = True
        Case "chkcheckdatefromwht"
          Me.SetFilterValue("CheckDateFromWHT", chkCheckDateFromWHT.Checked)
          dirtyFlag = True
        Case "chkcanchangerecipient"
          Me.SetFilterValue("CanEditOutgoingCheckRecipient", chkCanChangeRecipient.Checked)
          dirtyFlag = True
      End Select
      Dirty = Dirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub Initialize()
      ConfigFilters(0) = New Filter("AllowNoCqCodeDate", Configuration.GetConfig("AllowNoCqCodeDate"))
      ConfigFilters(1) = New Filter("OneCheckPerPV", Configuration.GetConfig("OneCheckPerPV"))
      ConfigFilters(2) = New Filter("UseCheckRegistration", Configuration.GetConfig("UseCheckRegistration"))
      ConfigFilters(3) = New Filter("AllowNoCqCode", Configuration.GetConfig("AllowNoCqCode"))
      ConfigFilters(4) = New Filter("CheckDateFromWHT", Configuration.GetConfig("CheckDateFromWHT"))
      ConfigFilters(5) = New Filter("CanEditOutgoingCheckRecipient", Configuration.GetConfig("CanEditOutgoingCheckRecipient"))
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

      Me.chkAllowNoCQCodeDate.Checked = CBool(GetFilterValue("AllowNoCqCodeDate"))
      Me.chkOneCheck.Checked = CBool(GetFilterValue("OneCheckPerPV"))
      Me.chkCheckRegist.Checked = CBool(GetFilterValue("UseCheckRegistration"))
      Me.chkAllowNoCQCode.Checked = CBool(GetFilterValue("AllowNoCqCode"))
      Me.chkCheckDateFromWHT.Checked = CBool(GetFilterValue("CheckDateFromWHT"))
      Me.chkCanChangeRecipient.Checked = CBool(GetFilterValue("CanEditOutgoingCheckRecipient"))

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