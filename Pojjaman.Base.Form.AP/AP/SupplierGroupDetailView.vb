Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class SupplierGroupDetailView
    Inherits AbstractEntityDetailPanelView
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
    Friend WithEvents lblAltName As System.Windows.Forms.Label
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblParent As System.Windows.Forms.Label
    Friend WithEvents txtParent As System.Windows.Forms.TextBox
    Friend WithEvents txtAltName As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SupplierGroupDetailView))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.lblAltName = New System.Windows.Forms.Label
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.lblParent = New System.Windows.Forms.Label
      Me.txtParent = New System.Windows.Forms.TextBox
      Me.txtAltName = New System.Windows.Forms.TextBox
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblName = New System.Windows.Forms.Label
      Me.txtName = New System.Windows.Forms.TextBox
      Me.grbDetail.SuspendLayout()
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
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'lblAltName
      '
      Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAltName.Location = New System.Drawing.Point(24, 72)
      Me.lblAltName.Name = "lblAltName"
      Me.lblAltName.Size = New System.Drawing.Size(88, 20)
      Me.lblAltName.TabIndex = 124
      Me.lblAltName.Text = "ชื่ออื่น:"
      Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.lblParent)
      Me.grbDetail.Controls.Add(Me.txtParent)
      Me.grbDetail.Controls.Add(Me.lblAltName)
      Me.grbDetail.Controls.Add(Me.txtAltName)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.Location = New System.Drawing.Point(8, 24)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(384, 136)
      Me.grbDetail.TabIndex = 1
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(197, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 132
      '
      'lblParent
      '
      Me.lblParent.Location = New System.Drawing.Point(8, 96)
      Me.lblParent.Name = "lblParent"
      Me.lblParent.Size = New System.Drawing.Size(104, 20)
      Me.lblParent.TabIndex = 127
      Me.lblParent.Text = "อยู่ภายใต้กลุ่มแม่:"
      Me.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtParent
      '
      Me.txtParent.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtParent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtParent, "")
      Me.Validator.SetGotFocusBackColor(Me.txtParent, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtParent, System.Drawing.Color.Empty)
      Me.txtParent.Location = New System.Drawing.Point(112, 96)
      Me.Validator.SetMaxValue(Me.txtParent, "")
      Me.Validator.SetMinValue(Me.txtParent, "")
      Me.txtParent.Name = "txtParent"
      Me.txtParent.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtParent, "")
      Me.Validator.SetRequired(Me.txtParent, False)
      Me.txtParent.Size = New System.Drawing.Size(248, 21)
      Me.txtParent.TabIndex = 5
      Me.txtParent.Text = ""
      '
      'txtAltName
      '
      Me.txtAltName.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAltName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
      Me.txtAltName.Location = New System.Drawing.Point(112, 72)
      Me.Validator.SetMaxValue(Me.txtAltName, "")
      Me.Validator.SetMinValue(Me.txtAltName, "")
      Me.txtAltName.Name = "txtAltName"
      Me.Validator.SetRegularExpression(Me.txtAltName, "")
      Me.Validator.SetRequired(Me.txtAltName, False)
      Me.txtAltName.Size = New System.Drawing.Size(248, 21)
      Me.txtAltName.TabIndex = 4
      Me.txtAltName.Text = ""
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(112, 24)
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(84, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.Text = ""
      '
      'lblCode
      '
      Me.lblCode.Location = New System.Drawing.Point(24, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 20)
      Me.lblCode.TabIndex = 123
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblName
      '
      Me.lblName.Location = New System.Drawing.Point(24, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(88, 20)
      Me.lblName.TabIndex = 122
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.txtName.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(112, 48)
      Me.Validator.SetMaxValue(Me.txtName, "")
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(248, 21)
      Me.txtName.TabIndex = 3
      Me.txtName.Text = ""
      '
      'SupplierGroupDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "SupplierGroupDetailView"
      Me.Size = New System.Drawing.Size(400, 184)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not Me.m_entity Is Nothing Then
        Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      End If
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.lblCode}")
      Me.Validator.SetDisplayName(Me.txtCode, Me.lblCode.Text.TrimEnd(":".ToCharArray))
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.lblName}")
      Me.Validator.SetDisplayName(Me.txtName, Me.lblName.Text.TrimEnd(":".ToCharArray))
      Me.lblAltName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.lblAltName}")
      Me.Validator.SetDisplayName(Me.txtAltName, Me.lblAltName.Text.TrimEnd(":".ToCharArray))
      Me.lblParent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupDetailView.lblParent}")
      Me.Validator.SetDisplayName(Me.txtParent, Me.lblParent.Text.TrimEnd(":".ToCharArray))

      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Global.grbDetail}")
    End Sub
#End Region

#Region "Properties"

#End Region

#Region "Members"
    Private m_entity As TreeBaseEntity
    Private m_owner As IListPanel
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()
      'Me.m_helpers = New HelperCollection(Me)
      'Me.LoadHelpers()
    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Overrides"
    Public Overrides Sub CheckFormEnable()

    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, TreeBaseEntity)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property


    Public Overrides Sub ClearDetail()
      txtCode.Text = ""
      txtName.Text = ""
      txtAltName.Text = ""
    End Sub
    Public Overrides Sub Initialize()

    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAltName.TextChanged, AddressOf Me.ChangeProperty
    End Sub

    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      txtCode.Text = m_entity.Code
      txtName.Text = m_entity.Name
      txtAltName.Text = m_entity.AlternateName
      If Not m_entity.Parent Is Nothing AndAlso m_entity.Parent.Originated Then
        Me.txtParent.Text = m_entity.Parent.Name
      Else
        Me.txtParent.Text = "Root" 'Todo
      End If

      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      'Todo: Remove this line
      Me.StatusBarService.SetMessage(Me.m_entity.Level.ToString)
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
        Case "txtname"
          Me.m_entity.Name = txtName.Text
        Case "txtaltname"
          Me.m_entity.AlternateName = txtAltName.Text
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      CheckFormEnable()
    End Sub
#End Region

#Region "Event"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        m_oldCode = Me.txtCode.Text
        Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
#End Region

    Private Sub GroupDetailView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
      Dim myListPanelView As GroupPanelView = CType(Me.WorkbenchWindow.SubViewContents(0), GroupPanelView)
      AddHandler myListPanelView.Saved, AddressOf EntitySaved
    End Sub
    Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

    End Sub

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

  End Class

End Namespace
