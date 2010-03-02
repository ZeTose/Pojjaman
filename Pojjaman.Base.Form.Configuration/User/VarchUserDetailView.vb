Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class VarchUserDetailView
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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents chkDocType2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDocType1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDocType0 As System.Windows.Forms.CheckBox
    Friend WithEvents grbUser As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbUser = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.chkDocType1 = New System.Windows.Forms.CheckBox()
      Me.chkDocType2 = New System.Windows.Forms.CheckBox()
      Me.chkDocType0 = New System.Windows.Forms.CheckBox()
      Me.grbUser.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(40, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(56, 24)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.txtCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(56, 21)
      Me.txtCode.TabIndex = 1
      Me.txtCode.TabStop = False
      '
      'grbUser
      '
      Me.grbUser.Controls.Add(Me.lblCode)
      Me.grbUser.Controls.Add(Me.txtCode)
      Me.grbUser.Controls.Add(Me.txtName)
      Me.grbUser.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbUser.Location = New System.Drawing.Point(8, 8)
      Me.grbUser.Name = "grbUser"
      Me.grbUser.Size = New System.Drawing.Size(552, 56)
      Me.grbUser.TabIndex = 0
      Me.grbUser.TabStop = False
      Me.grbUser.Text = "ผู้ใช้"
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(112, 24)
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.txtName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, False)
      Me.txtName.Size = New System.Drawing.Size(432, 21)
      Me.txtName.TabIndex = 2
      Me.txtName.TabStop = False
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
      'chkDocType1
      '
      Me.chkDocType1.AutoSize = True
      Me.chkDocType1.Location = New System.Drawing.Point(8, 93)
      Me.chkDocType1.Name = "chkDocType1"
      Me.chkDocType1.Size = New System.Drawing.Size(245, 17)
      Me.chkDocType1.TabIndex = 2
      Me.chkDocType1.Text = "สามารถมองเห็นเอกสารเบิกเงินสดย่อยได้ทุกใบ"
      Me.chkDocType1.UseVisualStyleBackColor = True
      '
      'chkDocType2
      '
      Me.chkDocType2.AutoSize = True
      Me.chkDocType2.Location = New System.Drawing.Point(8, 116)
      Me.chkDocType2.Name = "chkDocType2"
      Me.chkDocType2.Size = New System.Drawing.Size(193, 17)
      Me.chkDocType2.TabIndex = 3
      Me.chkDocType2.Text = "สามารถมองเห็นเอกสารคีย์เงินเดือน"
      Me.chkDocType2.UseVisualStyleBackColor = True
      '
      'chkDocType0
      '
      Me.chkDocType0.AutoSize = True
      Me.chkDocType0.Location = New System.Drawing.Point(8, 70)
      Me.chkDocType0.Name = "chkDocType0"
      Me.chkDocType0.Size = New System.Drawing.Size(250, 17)
      Me.chkDocType0.TabIndex = 1
      Me.chkDocType0.Text = "สามารถมองเห็นเอกสารซื้อสินค้า/บริการได้ทุกใบ"
      Me.chkDocType0.UseVisualStyleBackColor = True
      '
      'VarchUserDetailView
      '
      Me.Controls.Add(Me.chkDocType0)
      Me.Controls.Add(Me.chkDocType2)
      Me.Controls.Add(Me.chkDocType1)
      Me.Controls.Add(Me.grbUser)
      Me.Name = "VarchUserDetailView"
      Me.Size = New System.Drawing.Size(568, 496)
      Me.grbUser.ResumeLayout(False)
      Me.grbUser.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As User
    Private m_isInitialized As Boolean
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      UpdateEntityProperties()
      EventWiring()
    End Sub

#End Region

#Region "Method"
    Protected Overrides Sub EventWiring()
    End Sub
#End Region

#Region "IListDetail"

    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()

    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      txtCode.Text = ""
      txtName.Text = ""

    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.lblCode}")
      Me.grbUser.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.grbUser}")
      Me.chkDocType1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.chkDocType1}")
      Me.chkDocType2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.chkDocType2}")
      Me.chkDocType0.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.chkDocType0}")
    End Sub
    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()

      If m_entity Is Nothing Then
        Return
      End If

      ' ทำการผูก Property ต่าง ๆ ของเข้ากับ control
      With Me
        .txtCode.Text = .m_entity.Code
        If TypeOf .m_entity Is IHasName Then
          .txtName.Text = CType(.m_entity, IHasName).Name
        End If
      End With

      If TypeOf Me.m_entity Is IHasAccess Then
        If CType(Me.m_entity, IHasAccess).AccessCollection Is Nothing Then
          CType(Me.m_entity, IHasAccess).SetAccessCollection()
        End If
      End If

      Me.chkDocType1.Checked = Me.m_entity.CanSeeAllDocType1
      Me.chkDocType2.Checked = Me.m_entity.CanSeeAllDocType2
      Me.chkDocType0.Checked = Me.m_entity.CanSeeAllDocType0

      SetLabelText()
      CheckFormEnable()

      m_isInitialized = True

    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Value
        UpdateEntityProperties()
        EventWiring()
      End Set
    End Property
    Public Overrides Sub Initialize()

    End Sub

#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get

      End Get
    End Property
#End Region

    Private Sub chkDocType1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDocType1.CheckedChanged
      If Not m_isInitialized Then
        Return
      End If
      Me.m_entity.CanSeeAllDocType1 = chkDocType1.Checked
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub chkDocType2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDocType2.CheckedChanged
      If Not m_isInitialized Then
        Return
      End If
      Me.m_entity.CanSeeAllDocType2 = chkDocType2.Checked
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub chkDocType0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDocType0.CheckedChanged
      If Not m_isInitialized Then
        Return
      End If
      Me.m_entity.CanSeeAllDocType0 = chkDocType0.Checked
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
  End Class
End Namespace