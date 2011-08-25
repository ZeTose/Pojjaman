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
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BOQPanelView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          'Clear the memory
          Me.m_entity = Nothing
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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ibtnShowEstimator As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowEstimatorDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtEstimatorName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowProject As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowProjectDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEstimatorCode As System.Windows.Forms.TextBox
    Friend WithEvents lblEstimator As System.Windows.Forms.Label
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnImportFromExcel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BOQPanelView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblStatus = New System.Windows.Forms.Label
      Me.ibtnShowEstimator = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowEstimatorDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtProjectName = New System.Windows.Forms.TextBox
      Me.txtEstimatorName = New System.Windows.Forms.TextBox
      Me.ibtnShowProject = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowProjectDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEstimatorCode = New System.Windows.Forms.TextBox
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.lblEstimator = New System.Windows.Forms.Label
      Me.lblProject = New System.Windows.Forms.Label
      Me.txtProjectCode = New System.Windows.Forms.TextBox
      Me.ibtnImportFromExcel = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.ibtnShowEstimator)
      Me.grbDetail.Controls.Add(Me.ibtnShowEstimatorDialog)
      Me.grbDetail.Controls.Add(Me.txtProjectName)
      Me.grbDetail.Controls.Add(Me.txtEstimatorName)
      Me.grbDetail.Controls.Add(Me.ibtnShowProject)
      Me.grbDetail.Controls.Add(Me.ibtnShowProjectDialog)
      Me.grbDetail.Controls.Add(Me.txtEstimatorCode)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.lblEstimator)
      Me.grbDetail.Controls.Add(Me.lblProject)
      Me.grbDetail.Controls.Add(Me.txtProjectCode)
      Me.grbDetail.Controls.Add(Me.ibtnImportFromExcel)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(616, 118)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด:"
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblStatus.Location = New System.Drawing.Point(120, 96)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(35, 17)
      Me.lblStatus.TabIndex = 6
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnShowEstimator
      '
      Me.ibtnShowEstimator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEstimator.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEstimator.Image = CType(resources.GetObject("ibtnShowEstimator.Image"), System.Drawing.Image)
      Me.ibtnShowEstimator.Location = New System.Drawing.Point(560, 40)
      Me.ibtnShowEstimator.Name = "ibtnShowEstimator"
      Me.ibtnShowEstimator.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEstimator.TabIndex = 13
      Me.ibtnShowEstimator.TabStop = False
      Me.ibtnShowEstimator.ThemedImage = CType(resources.GetObject("ibtnShowEstimator.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowEstimatorDialog
      '
      Me.ibtnShowEstimatorDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEstimatorDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEstimatorDialog.Image = CType(resources.GetObject("ibtnShowEstimatorDialog.Image"), System.Drawing.Image)
      Me.ibtnShowEstimatorDialog.Location = New System.Drawing.Point(536, 40)
      Me.ibtnShowEstimatorDialog.Name = "ibtnShowEstimatorDialog"
      Me.ibtnShowEstimatorDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEstimatorDialog.TabIndex = 10
      Me.ibtnShowEstimatorDialog.TabStop = False
      Me.ibtnShowEstimatorDialog.ThemedImage = CType(resources.GetObject("ibtnShowEstimatorDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtProjectName
      '
      Me.txtProjectName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.txtProjectName.Location = New System.Drawing.Point(264, 64)
      Me.Validator.SetMaxValue(Me.txtProjectName, "")
      Me.Validator.SetMinValue(Me.txtProjectName, "")
      Me.txtProjectName.Name = "txtProjectName"
      Me.txtProjectName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProjectName, "")
      Me.Validator.SetRequired(Me.txtProjectName, False)
      Me.txtProjectName.Size = New System.Drawing.Size(272, 21)
      Me.txtProjectName.TabIndex = 8
      Me.txtProjectName.TabStop = False
      Me.txtProjectName.Text = ""
      '
      'txtEstimatorName
      '
      Me.txtEstimatorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtEstimatorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEstimatorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEstimatorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEstimatorName, System.Drawing.Color.Empty)
      Me.txtEstimatorName.Location = New System.Drawing.Point(264, 40)
      Me.Validator.SetMaxValue(Me.txtEstimatorName, "")
      Me.Validator.SetMinValue(Me.txtEstimatorName, "")
      Me.txtEstimatorName.Name = "txtEstimatorName"
      Me.txtEstimatorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEstimatorName, "")
      Me.Validator.SetRequired(Me.txtEstimatorName, False)
      Me.txtEstimatorName.Size = New System.Drawing.Size(272, 21)
      Me.txtEstimatorName.TabIndex = 7
      Me.txtEstimatorName.TabStop = False
      Me.txtEstimatorName.Text = ""
      '
      'ibtnShowProject
      '
      Me.ibtnShowProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowProject.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowProject.Image = CType(resources.GetObject("ibtnShowProject.Image"), System.Drawing.Image)
      Me.ibtnShowProject.Location = New System.Drawing.Point(560, 64)
      Me.ibtnShowProject.Name = "ibtnShowProject"
      Me.ibtnShowProject.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowProject.TabIndex = 12
      Me.ibtnShowProject.TabStop = False
      Me.ibtnShowProject.ThemedImage = CType(resources.GetObject("ibtnShowProject.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowProjectDialog
      '
      Me.ibtnShowProjectDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowProjectDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowProjectDialog.Image = CType(resources.GetObject("ibtnShowProjectDialog.Image"), System.Drawing.Image)
      Me.ibtnShowProjectDialog.Location = New System.Drawing.Point(536, 64)
      Me.ibtnShowProjectDialog.Name = "ibtnShowProjectDialog"
      Me.ibtnShowProjectDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowProjectDialog.TabIndex = 11
      Me.ibtnShowProjectDialog.TabStop = False
      Me.ibtnShowProjectDialog.ThemedImage = CType(resources.GetObject("ibtnShowProjectDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEstimatorCode
      '
      Me.Validator.SetDataType(Me.txtEstimatorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEstimatorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEstimatorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEstimatorCode, System.Drawing.Color.Empty)
      Me.txtEstimatorCode.Location = New System.Drawing.Point(120, 40)
      Me.Validator.SetMaxValue(Me.txtEstimatorCode, "")
      Me.Validator.SetMinValue(Me.txtEstimatorCode, "")
      Me.txtEstimatorCode.Name = "txtEstimatorCode"
      Me.Validator.SetRegularExpression(Me.txtEstimatorCode, "")
      Me.Validator.SetRequired(Me.txtEstimatorCode, False)
      Me.txtEstimatorCode.Size = New System.Drawing.Size(144, 21)
      Me.txtEstimatorCode.TabIndex = 1
      Me.txtEstimatorCode.Text = ""
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(112, 18)
      Me.lblCode.TabIndex = 3
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.txtCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -13)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(120, 16)
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(416, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.Text = ""
      '
      'lblEstimator
      '
      Me.lblEstimator.BackColor = System.Drawing.Color.Transparent
      Me.lblEstimator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEstimator.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblEstimator.Location = New System.Drawing.Point(8, 40)
      Me.lblEstimator.Name = "lblEstimator"
      Me.lblEstimator.Size = New System.Drawing.Size(112, 18)
      Me.lblEstimator.TabIndex = 4
      Me.lblEstimator.Text = "ผู้ประเมิน:"
      Me.lblEstimator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblProject
      '
      Me.lblProject.BackColor = System.Drawing.Color.Transparent
      Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProject.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblProject.Location = New System.Drawing.Point(8, 64)
      Me.lblProject.Name = "lblProject"
      Me.lblProject.Size = New System.Drawing.Size(112, 18)
      Me.lblProject.TabIndex = 5
      Me.lblProject.Text = "โครงการ:"
      Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtProjectCode
      '
      Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.txtProjectCode.Location = New System.Drawing.Point(120, 64)
      Me.Validator.SetMaxValue(Me.txtProjectCode, "")
      Me.Validator.SetMinValue(Me.txtProjectCode, "")
      Me.txtProjectCode.Name = "txtProjectCode"
      Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
      Me.Validator.SetRequired(Me.txtProjectCode, False)
      Me.txtProjectCode.Size = New System.Drawing.Size(144, 21)
      Me.txtProjectCode.TabIndex = 2
      Me.txtProjectCode.Text = ""
      '
      'ibtnImportFromExcel
      '
      Me.ibtnImportFromExcel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnImportFromExcel.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnImportFromExcel.Image = CType(resources.GetObject("ibtnImportFromExcel.Image"), System.Drawing.Image)
      Me.ibtnImportFromExcel.Location = New System.Drawing.Point(560, 16)
      Me.ibtnImportFromExcel.Name = "ibtnImportFromExcel"
      Me.ibtnImportFromExcel.Size = New System.Drawing.Size(24, 23)
      Me.ibtnImportFromExcel.TabIndex = 13
      Me.ibtnImportFromExcel.TabStop = False
      Me.ibtnImportFromExcel.ThemedImage = CType(resources.GetObject("ibtnImportFromExcel.ThemedImage"), System.Drawing.Bitmap)
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Image = CType(resources.GetObject("ibtnCopyMe.Image"), System.Drawing.Image)
      Me.ibtnCopyMe.Location = New System.Drawing.Point(536, 16)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 327
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      '
      'BOQPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "BOQPanelView"
      Me.Size = New System.Drawing.Size(640, 136)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As BOQ
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      dummyProject = New Project
      dummyEmployee = New Employee
      EventWiring()
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      'If Me.m_entity Is Nothing OrElse Not Me.m_entity.Originated Then
      '    Me.ibtnCopy.Enabled = True
      'Else
      '    Me.ibtnCopy.Enabled = False
      'End If
      Me.ibtnCopyMe.Enabled = True
    End Sub
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPanelView.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPanelView.lblCode}")
      Me.lblEstimator.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPanelView.lblEstimator}")
      Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPanelView.lblProject}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtEstimatorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtProjectCode.Validated, AddressOf Me.ChangeProperty

    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      txtCode.Text = m_entity.Code

      txtProjectCode.Text = m_entity.Project.Code
      txtProjectName.Text = m_entity.Project.Name
      txtEstimatorCode.Text = m_entity.Estimator.Code
      txtEstimatorName.Text = m_entity.Estimator.Name

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtestimatorcode"
          dirtyFlag = Employee.GetEmployee(txtEstimatorCode, txtEstimatorName, Me.m_entity.Estimator)
        Case "txtprojectcode"
          dirtyFlag = Project.GetProject(txtProjectCode, txtProjectName, Me.m_entity.Project)
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()
      If m_entity.Canceled Then
        lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name
      ElseIf m_entity.Edited Then
        lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name
      ElseIf m_entity.Originated Then
        lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
      Else
        lblStatus.Text = "ยังไม่บันทึก"
      End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          If Not Me.m_entity Is Nothing Then
            Me.m_entity.Dispose()
            Me.m_entity = Nothing
          End If
          Me.m_entity = CType(Value, BOQ)
        End If
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      'PopulateRequestor()
      'PopulateCostCenter()
    End Sub
#End Region

#Region "Event Handlers"

#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Requestor
    Private Sub ibtnShowEstimator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEstimator.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyEmployee)
    End Sub
    Private Sub ibtnShowEstimatorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEstimatorDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtEstimatorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtEstimatorCode, txtEstimatorName, Me.m_entity.Estimator)
    End Sub

    Private Sub ibtnShowProjectDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowProjectDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
                   CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Project, AddressOf SetProjectDialog)
    End Sub
    Private Sub SetProjectDialog(ByVal e As ISimpleEntity)
      If Not Me.m_entity.Project.Id = e.Id Then
        If TypeOf e Is Project Then
          Me.m_entity.Project = CType(e, Project)
          Me.txtProjectCode.Text = e.Code
          Me.txtProjectName.Text = Me.m_entity.Project.Name
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      End If

      'Me.WorkbenchWindow.ViewContent.IsDirty = _
      '    Me.WorkbenchWindow.ViewContent.IsDirty _
      '    Or Project.GetProject(txtProjectCode, txtProjectName, Me.m_entity.Project)
    End Sub
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowProject.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyProject)
    End Sub
    'Private Sub ibtnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim myEntityPanelService As IEntityPanelService = _
    '                             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenListDialog(New BOQ, AddressOf CopyBoq)
    'End Sub
    'Private Sub CopyBoq(ByVal e As ISimpleEntity)
    '    If e Is Nothing Then
    '        Return
    '    End If
    '    Dim newBoq As BOQ = CType(CType(e, BOQ).GetNewEntity, BOQ)
    '    CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newBoq
    '    Me.Entity = newBoq
    '    Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Private dummyProject As Project
    Private dummyEmployee As Employee
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent(dummyEmployee.FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtestimatorcode", "txtestimatorname"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent(dummyProject.FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtprojectcode", "txtprojectname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent(dummyEmployee.FullClassName) Then
        Dim id As Integer = CInt(data.GetData(dummyEmployee.FullClassName))
        Dim entity As New Employee(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtestimatorcode", "txtestimatorname"
              Me.SetEmployeeDialog(entity)
          End Select
        End If
      End If
      If data.GetDataPresent(dummyProject.FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New Project(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtprojectcode", "txtprojectname"
              Me.SetProjectDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

    Private Sub ibtnImportFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnImportFromExcel.Click
      Dim opdlg As New OpenFileDialog
      opdlg.Filter = "Excel files (*.xls)|*.xls"
      If opdlg.ShowDialog = DialogResult.OK Then
        Dim i As New Excel.Import(opdlg.FileName)
        i.Where = "Type in ('WBS','item')"
        i.Fields = "Type,[Level],EntityType,Code,Description,Note,Qty,Unit,QtyPerWBS,UMC,UEC,ULC,MCBS,LCBS,ECBS"
        Dim dt As DataTable = i.Query()

        Dim MissingCode As List(Of ArrayList) = Me.m_entity.Import(dt)
        Me.m_entity.SetUpWBSChildCollation()
        If Me.txtCode.Text.Trim.Length = 0 Then
          Me.txtCode.Text = opdlg.SafeFileName.Split(".")(0)
        End If

        Dim lciMissingCode As New List(Of String)
        Dim unitMissingCode As New List(Of String)

        For Each Str As String In MissingCode(0)
          lciMissingCode.Add(Str)
        Next
        For Each Str As String In MissingCode(1)
          unitMissingCode.Add(Str)
        Next
        If lciMissingCode.Count > 0 Then
          Dim listdlq As New SimpleListDialog(lciMissingCode, "Lci ที่ไม่มีใน Database")
          Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(listdlq)
          myDialog.ShowDialog()
        End If
        If unitMissingCode.Count > 0 Then
          Dim listdlq As New SimpleListDialog(unitMissingCode, "Unit ที่ไม่มีใน Database")
          Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(listdlq)
          myDialog.ShowDialog()
        End If
      End If
    End Sub
    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
  End Class
End Namespace
