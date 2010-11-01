Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class GoodsReceiptFilterSubPanel
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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnShowLCIDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowLCI As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblLCI As System.Windows.Forms.Label
    Friend WithEvents txtLCI As System.Windows.Forms.TextBox
    Friend WithEvents txtLCIName As System.Windows.Forms.TextBox
    Friend WithEvents txtToolName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowTool As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblTool As System.Windows.Forms.Label
    Friend WithEvents ibtnShowToolDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtTool As System.Windows.Forms.TextBox
    Friend WithEvents lblBlank As System.Windows.Forms.Label
    Friend WithEvents txtBlank As System.Windows.Forms.TextBox
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtToCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents btnToCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtToCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents lblToCCPerson As System.Windows.Forms.Label
    Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnToCCPersonPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblToCC As System.Windows.Forms.Label
    Friend WithEvents btnToCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents btnSupplierPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbDueDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtDueDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblDueDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDueDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDueDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherDocCode As System.Windows.Forms.TextBox
    Friend WithEvents lblOtherDocCode As System.Windows.Forms.Label
    Friend WithEvents grbPV As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtPVCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPVStart As System.Windows.Forms.Label
    Friend WithEvents btnPVStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtPVCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblPVEnd As System.Windows.Forms.Label
    Friend WithEvents btnPVEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowEquipment As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEquipmentName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowEquipmentDiaog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEquipmentCode As System.Windows.Forms.TextBox
    Friend WithEvents grbApprove As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbApproveLevel As System.Windows.Forms.ComboBox
    Friend WithEvents lblApproveLevel As System.Windows.Forms.Label
    Friend WithEvents txtApprovePerson As System.Windows.Forms.TextBox
    Friend WithEvents txtApprovePersonName As System.Windows.Forms.TextBox
    Friend WithEvents lblApprovePerson As System.Windows.Forms.Label
    Friend WithEvents btnFineApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEquipment As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodsReceiptFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbApprove = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbApproveLevel = New System.Windows.Forms.ComboBox()
      Me.lblApproveLevel = New System.Windows.Forms.Label()
      Me.txtApprovePerson = New System.Windows.Forms.TextBox()
      Me.txtApprovePersonName = New System.Windows.Forms.TextBox()
      Me.lblApprovePerson = New System.Windows.Forms.Label()
      Me.btnFineApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbDueDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDueDateStart = New System.Windows.Forms.TextBox()
      Me.txtDueDateEnd = New System.Windows.Forms.TextBox()
      Me.lblDueDateStart = New System.Windows.Forms.Label()
      Me.lblDueDateEnd = New System.Windows.Forms.Label()
      Me.dtpDueDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDueDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblBlank = New System.Windows.Forms.Label()
      Me.txtBlank = New System.Windows.Forms.TextBox()
      Me.ibtnShowLCIDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowLCI = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblLCI = New System.Windows.Forms.Label()
      Me.txtLCI = New System.Windows.Forms.TextBox()
      Me.txtLCIName = New System.Windows.Forms.TextBox()
      Me.txtToolName = New System.Windows.Forms.TextBox()
      Me.ibtnShowTool = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblTool = New System.Windows.Forms.Label()
      Me.ibtnShowToolDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtTool = New System.Windows.Forms.TextBox()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnShowEquipment = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtEquipmentName = New System.Windows.Forms.TextBox()
      Me.ibtnShowEquipmentDiaog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtEquipmentCode = New System.Windows.Forms.TextBox()
      Me.lblEquipment = New System.Windows.Forms.Label()
      Me.btnSupplierPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.btnSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.txtToCCPersonCode = New System.Windows.Forms.TextBox()
      Me.btnToCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtToCCPersonName = New System.Windows.Forms.TextBox()
      Me.lblToCCPerson = New System.Windows.Forms.Label()
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnToCCPersonPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblToCC = New System.Windows.Forms.Label()
      Me.btnToCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtOtherDocCode = New System.Windows.Forms.TextBox()
      Me.lblOtherDocCode = New System.Windows.Forms.Label()
      Me.grbPV = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtPVCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblPVEnd = New System.Windows.Forms.Label()
      Me.txtPVCodeStart = New System.Windows.Forms.TextBox()
      Me.lblPVStart = New System.Windows.Forms.Label()
      Me.btnPVStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnPVEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtRemark = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.grbDetail.SuspendLayout()
      Me.grbApprove.SuspendLayout()
      Me.grbDueDate.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbItem.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      Me.grbPV.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
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
      Me.txtCode.Location = New System.Drawing.Point(95, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(278, 21)
      Me.txtCode.TabIndex = 1
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbApprove)
      Me.grbDetail.Controls.Add(Me.grbDueDate)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbItem)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.Controls.Add(Me.grbPV)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(6, 2)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(770, 327)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'grbApprove
      '
      Me.grbApprove.Controls.Add(Me.cmbApproveLevel)
      Me.grbApprove.Controls.Add(Me.lblApproveLevel)
      Me.grbApprove.Controls.Add(Me.txtApprovePerson)
      Me.grbApprove.Controls.Add(Me.txtApprovePersonName)
      Me.grbApprove.Controls.Add(Me.lblApprovePerson)
      Me.grbApprove.Controls.Add(Me.btnFineApprove)
      Me.grbApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbApprove.Location = New System.Drawing.Point(399, 217)
      Me.grbApprove.Name = "grbApprove"
      Me.grbApprove.Size = New System.Drawing.Size(362, 77)
      Me.grbApprove.TabIndex = 24
      Me.grbApprove.TabStop = False
      Me.grbApprove.Text = "การอนุมัติ"
      '
      'cmbApproveLevel
      '
      Me.cmbApproveLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbApproveLevel.Location = New System.Drawing.Point(103, 38)
      Me.cmbApproveLevel.Name = "cmbApproveLevel"
      Me.cmbApproveLevel.Size = New System.Drawing.Size(225, 21)
      Me.cmbApproveLevel.TabIndex = 12
      '
      'lblApproveLevel
      '
      Me.lblApproveLevel.BackColor = System.Drawing.Color.Transparent
      Me.lblApproveLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblApproveLevel.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblApproveLevel.Location = New System.Drawing.Point(7, 38)
      Me.lblApproveLevel.Name = "lblApproveLevel"
      Me.lblApproveLevel.Size = New System.Drawing.Size(96, 18)
      Me.lblApproveLevel.TabIndex = 13
      Me.lblApproveLevel.Text = "ระดับการอนุมัติ:"
      Me.lblApproveLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtApprovePerson
      '
      Me.Validator.SetDataType(Me.txtApprovePerson, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtApprovePerson, "")
      Me.Validator.SetGotFocusBackColor(Me.txtApprovePerson, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtApprovePerson, System.Drawing.Color.Empty)
      Me.txtApprovePerson.Location = New System.Drawing.Point(103, 15)
      Me.Validator.SetMinValue(Me.txtApprovePerson, "")
      Me.txtApprovePerson.Name = "txtApprovePerson"
      Me.Validator.SetRegularExpression(Me.txtApprovePerson, "")
      Me.Validator.SetRequired(Me.txtApprovePerson, False)
      Me.txtApprovePerson.Size = New System.Drawing.Size(80, 20)
      Me.txtApprovePerson.TabIndex = 1
      '
      'txtApprovePersonName
      '
      Me.Validator.SetDataType(Me.txtApprovePersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtApprovePersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtApprovePersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtApprovePersonName, System.Drawing.Color.Empty)
      Me.txtApprovePersonName.Location = New System.Drawing.Point(184, 15)
      Me.Validator.SetMinValue(Me.txtApprovePersonName, "")
      Me.txtApprovePersonName.Name = "txtApprovePersonName"
      Me.txtApprovePersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtApprovePersonName, "")
      Me.Validator.SetRequired(Me.txtApprovePersonName, False)
      Me.txtApprovePersonName.Size = New System.Drawing.Size(143, 20)
      Me.txtApprovePersonName.TabIndex = 8
      Me.txtApprovePersonName.TabStop = False
      '
      'lblApprovePerson
      '
      Me.lblApprovePerson.BackColor = System.Drawing.Color.Transparent
      Me.lblApprovePerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblApprovePerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblApprovePerson.Location = New System.Drawing.Point(6, 15)
      Me.lblApprovePerson.Name = "lblApprovePerson"
      Me.lblApprovePerson.Size = New System.Drawing.Size(99, 18)
      Me.lblApprovePerson.TabIndex = 5
      Me.lblApprovePerson.Text = "ผู้อนุมัติ:"
      Me.lblApprovePerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnFineApprove
      '
      Me.btnFineApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnFineApprove.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFineApprove.ForeColor = System.Drawing.SystemColors.Control
      Me.btnFineApprove.Location = New System.Drawing.Point(327, 15)
      Me.btnFineApprove.Name = "btnFineApprove"
      Me.btnFineApprove.Size = New System.Drawing.Size(24, 23)
      Me.btnFineApprove.TabIndex = 10
      Me.btnFineApprove.TabStop = False
      Me.btnFineApprove.ThemedImage = CType(resources.GetObject("btnFineApprove.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbDueDate
      '
      Me.grbDueDate.Controls.Add(Me.txtDueDateStart)
      Me.grbDueDate.Controls.Add(Me.txtDueDateEnd)
      Me.grbDueDate.Controls.Add(Me.lblDueDateStart)
      Me.grbDueDate.Controls.Add(Me.lblDueDateEnd)
      Me.grbDueDate.Controls.Add(Me.dtpDueDateStart)
      Me.grbDueDate.Controls.Add(Me.dtpDueDateEnd)
      Me.grbDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDueDate.Location = New System.Drawing.Point(399, 77)
      Me.grbDueDate.Name = "grbDueDate"
      Me.grbDueDate.Size = New System.Drawing.Size(362, 69)
      Me.grbDueDate.TabIndex = 4
      Me.grbDueDate.TabStop = False
      Me.grbDueDate.Text = "วันที่เอกสาร"
      '
      'txtDueDateStart
      '
      Me.txtDueDateStart.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDueDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
      Me.txtDueDateStart.Location = New System.Drawing.Point(103, 14)
      Me.Validator.SetMinValue(Me.txtDueDateStart, "")
      Me.txtDueDateStart.Name = "txtDueDateStart"
      Me.Validator.SetRegularExpression(Me.txtDueDateStart, "")
      Me.Validator.SetRequired(Me.txtDueDateStart, False)
      Me.txtDueDateStart.Size = New System.Drawing.Size(114, 20)
      Me.txtDueDateStart.TabIndex = 20
      '
      'txtDueDateEnd
      '
      Me.txtDueDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDueDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
      Me.txtDueDateEnd.Location = New System.Drawing.Point(103, 40)
      Me.Validator.SetMinValue(Me.txtDueDateEnd, "")
      Me.txtDueDateEnd.Name = "txtDueDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDueDateEnd, "")
      Me.Validator.SetRequired(Me.txtDueDateEnd, False)
      Me.txtDueDateEnd.Size = New System.Drawing.Size(114, 20)
      Me.txtDueDateEnd.TabIndex = 21
      '
      'lblDueDateStart
      '
      Me.lblDueDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDueDateStart.Location = New System.Drawing.Point(16, 15)
      Me.lblDueDateStart.Name = "lblDueDateStart"
      Me.lblDueDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDueDateStart.TabIndex = 8
      Me.lblDueDateStart.Text = "ตั้งแต่:"
      Me.lblDueDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDueDateEnd
      '
      Me.lblDueDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDueDateEnd.Location = New System.Drawing.Point(16, 39)
      Me.lblDueDateEnd.Name = "lblDueDateEnd"
      Me.lblDueDateEnd.Size = New System.Drawing.Size(88, 18)
      Me.lblDueDateEnd.TabIndex = 9
      Me.lblDueDateEnd.Text = "ถึง:"
      Me.lblDueDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDueDateStart
      '
      Me.dtpDueDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDateStart.Location = New System.Drawing.Point(104, 14)
      Me.dtpDueDateStart.Name = "dtpDueDateStart"
      Me.dtpDueDateStart.Size = New System.Drawing.Size(137, 20)
      Me.dtpDueDateStart.TabIndex = 10
      Me.dtpDueDateStart.TabStop = False
      '
      'dtpDueDateEnd
      '
      Me.dtpDueDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDateEnd.Location = New System.Drawing.Point(104, 40)
      Me.dtpDueDateEnd.Name = "dtpDueDateEnd"
      Me.dtpDueDateEnd.Size = New System.Drawing.Size(137, 20)
      Me.dtpDueDateEnd.TabIndex = 11
      Me.dtpDueDateEnd.TabStop = False
      '
      'grbDocDate
      '
      Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
      Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocDate.Location = New System.Drawing.Point(399, 10)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(362, 67)
      Me.grbDocDate.TabIndex = 3
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "วันที่เอกสาร"
      '
      'txtDocDateStart
      '
      Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(112, 20)
      Me.txtDocDateStart.TabIndex = 18
      '
      'txtDocDateEnd
      '
      Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(104, 40)
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(112, 20)
      Me.txtDocDateEnd.TabIndex = 19
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(27, 17)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(78, 18)
      Me.lblDocDateStart.TabIndex = 8
      Me.lblDocDateStart.Text = "ตั้งแต่:"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(27, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(78, 18)
      Me.lblDocDateEnd.TabIndex = 9
      Me.lblDocDateEnd.Text = "ถึง:"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 10
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(104, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 11
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(688, 297)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 22
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(607, 297)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 23
      Me.btnReset.Text = "Reset"
      '
      'grbItem
      '
      Me.grbItem.Controls.Add(Me.lblBlank)
      Me.grbItem.Controls.Add(Me.txtBlank)
      Me.grbItem.Controls.Add(Me.ibtnShowLCIDialog)
      Me.grbItem.Controls.Add(Me.ibtnShowLCI)
      Me.grbItem.Controls.Add(Me.lblLCI)
      Me.grbItem.Controls.Add(Me.txtLCI)
      Me.grbItem.Controls.Add(Me.txtLCIName)
      Me.grbItem.Controls.Add(Me.txtToolName)
      Me.grbItem.Controls.Add(Me.ibtnShowTool)
      Me.grbItem.Controls.Add(Me.lblTool)
      Me.grbItem.Controls.Add(Me.ibtnShowToolDialog)
      Me.grbItem.Controls.Add(Me.txtTool)
      Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbItem.Location = New System.Drawing.Point(8, 225)
      Me.grbItem.Name = "grbItem"
      Me.grbItem.Size = New System.Drawing.Size(385, 94)
      Me.grbItem.TabIndex = 1
      Me.grbItem.TabStop = False
      Me.grbItem.Text = "สิ่งที่ซื้อ"
      '
      'lblBlank
      '
      Me.lblBlank.BackColor = System.Drawing.Color.Transparent
      Me.lblBlank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBlank.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblBlank.Location = New System.Drawing.Point(8, 64)
      Me.lblBlank.Name = "lblBlank"
      Me.lblBlank.Size = New System.Drawing.Size(88, 18)
      Me.lblBlank.TabIndex = 208
      Me.lblBlank.Text = "อื่น:"
      Me.lblBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBlank
      '
      Me.Validator.SetDataType(Me.txtBlank, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBlank, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBlank, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBlank, System.Drawing.Color.Empty)
      Me.txtBlank.Location = New System.Drawing.Point(96, 64)
      Me.Validator.SetMinValue(Me.txtBlank, "")
      Me.txtBlank.Name = "txtBlank"
      Me.Validator.SetRegularExpression(Me.txtBlank, "")
      Me.Validator.SetRequired(Me.txtBlank, False)
      Me.txtBlank.Size = New System.Drawing.Size(229, 20)
      Me.txtBlank.TabIndex = 13
      '
      'ibtnShowLCIDialog
      '
      Me.ibtnShowLCIDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowLCIDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowLCIDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowLCIDialog.Location = New System.Drawing.Point(326, 16)
      Me.ibtnShowLCIDialog.Name = "ibtnShowLCIDialog"
      Me.ibtnShowLCIDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowLCIDialog.TabIndex = 10
      Me.ibtnShowLCIDialog.TabStop = False
      Me.ibtnShowLCIDialog.ThemedImage = CType(resources.GetObject("ibtnShowLCIDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowLCI
      '
      Me.ibtnShowLCI.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowLCI.Location = New System.Drawing.Point(350, 16)
      Me.ibtnShowLCI.Name = "ibtnShowLCI"
      Me.ibtnShowLCI.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowLCI.TabIndex = 205
      Me.ibtnShowLCI.TabStop = False
      Me.ibtnShowLCI.ThemedImage = CType(resources.GetObject("ibtnShowLCI.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblLCI
      '
      Me.lblLCI.BackColor = System.Drawing.Color.Transparent
      Me.lblLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLCI.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblLCI.Location = New System.Drawing.Point(8, 16)
      Me.lblLCI.Name = "lblLCI"
      Me.lblLCI.Size = New System.Drawing.Size(88, 18)
      Me.lblLCI.TabIndex = 203
      Me.lblLCI.Text = "วัสดุ:"
      Me.lblLCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtLCI
      '
      Me.Validator.SetDataType(Me.txtLCI, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLCI, "")
      Me.Validator.SetGotFocusBackColor(Me.txtLCI, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLCI, System.Drawing.Color.Empty)
      Me.txtLCI.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMinValue(Me.txtLCI, "")
      Me.txtLCI.Name = "txtLCI"
      Me.Validator.SetRegularExpression(Me.txtLCI, "")
      Me.Validator.SetRequired(Me.txtLCI, False)
      Me.txtLCI.Size = New System.Drawing.Size(80, 20)
      Me.txtLCI.TabIndex = 9
      '
      'txtLCIName
      '
      Me.Validator.SetDataType(Me.txtLCIName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLCIName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLCIName, System.Drawing.Color.Empty)
      Me.txtLCIName.Location = New System.Drawing.Point(176, 16)
      Me.Validator.SetMinValue(Me.txtLCIName, "")
      Me.txtLCIName.Name = "txtLCIName"
      Me.txtLCIName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtLCIName, "")
      Me.Validator.SetRequired(Me.txtLCIName, False)
      Me.txtLCIName.Size = New System.Drawing.Size(149, 20)
      Me.txtLCIName.TabIndex = 204
      Me.txtLCIName.TabStop = False
      '
      'txtToolName
      '
      Me.Validator.SetDataType(Me.txtToolName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToolName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToolName, System.Drawing.Color.Empty)
      Me.txtToolName.Location = New System.Drawing.Point(176, 40)
      Me.Validator.SetMinValue(Me.txtToolName, "")
      Me.txtToolName.Name = "txtToolName"
      Me.txtToolName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToolName, "")
      Me.Validator.SetRequired(Me.txtToolName, False)
      Me.txtToolName.Size = New System.Drawing.Size(149, 20)
      Me.txtToolName.TabIndex = 204
      Me.txtToolName.TabStop = False
      '
      'ibtnShowTool
      '
      Me.ibtnShowTool.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowTool.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowTool.Location = New System.Drawing.Point(350, 40)
      Me.ibtnShowTool.Name = "ibtnShowTool"
      Me.ibtnShowTool.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowTool.TabIndex = 205
      Me.ibtnShowTool.TabStop = False
      Me.ibtnShowTool.ThemedImage = CType(resources.GetObject("ibtnShowTool.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblTool
      '
      Me.lblTool.BackColor = System.Drawing.Color.Transparent
      Me.lblTool.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTool.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTool.Location = New System.Drawing.Point(8, 40)
      Me.lblTool.Name = "lblTool"
      Me.lblTool.Size = New System.Drawing.Size(88, 18)
      Me.lblTool.TabIndex = 203
      Me.lblTool.Text = "เครื่องมือ:"
      Me.lblTool.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowToolDialog
      '
      Me.ibtnShowToolDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowToolDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToolDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToolDialog.Location = New System.Drawing.Point(326, 40)
      Me.ibtnShowToolDialog.Name = "ibtnShowToolDialog"
      Me.ibtnShowToolDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToolDialog.TabIndex = 12
      Me.ibtnShowToolDialog.TabStop = False
      Me.ibtnShowToolDialog.ThemedImage = CType(resources.GetObject("ibtnShowToolDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtTool
      '
      Me.Validator.SetDataType(Me.txtTool, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTool, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTool, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTool, System.Drawing.Color.Empty)
      Me.txtTool.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMinValue(Me.txtTool, "")
      Me.txtTool.Name = "txtTool"
      Me.Validator.SetRegularExpression(Me.txtTool, "")
      Me.Validator.SetRequired(Me.txtTool, False)
      Me.txtTool.Size = New System.Drawing.Size(80, 20)
      Me.txtTool.TabIndex = 11
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.txtRemark)
      Me.grbMainDetail.Controls.Add(Me.Label1)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowEquipment)
      Me.grbMainDetail.Controls.Add(Me.txtEquipmentName)
      Me.grbMainDetail.Controls.Add(Me.ibtnShowEquipmentDiaog)
      Me.grbMainDetail.Controls.Add(Me.txtEquipmentCode)
      Me.grbMainDetail.Controls.Add(Me.lblEquipment)
      Me.grbMainDetail.Controls.Add(Me.btnSupplierPanel)
      Me.grbMainDetail.Controls.Add(Me.txtSupplierCode)
      Me.grbMainDetail.Controls.Add(Me.txtSupplierName)
      Me.grbMainDetail.Controls.Add(Me.btnSupplierDialog)
      Me.grbMainDetail.Controls.Add(Me.lblSupplier)
      Me.grbMainDetail.Controls.Add(Me.cmbStatus)
      Me.grbMainDetail.Controls.Add(Me.lblStatus)
      Me.grbMainDetail.Controls.Add(Me.txtToCCPersonCode)
      Me.grbMainDetail.Controls.Add(Me.btnToCostCenterPanel)
      Me.grbMainDetail.Controls.Add(Me.txtToCostCenterCode)
      Me.grbMainDetail.Controls.Add(Me.txtToCCPersonName)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.lblToCCPerson)
      Me.grbMainDetail.Controls.Add(Me.txtToCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.Controls.Add(Me.btnToCostCenterDialog)
      Me.grbMainDetail.Controls.Add(Me.btnToCCPersonPanel)
      Me.grbMainDetail.Controls.Add(Me.lblToCC)
      Me.grbMainDetail.Controls.Add(Me.btnToCCPersonDialog)
      Me.grbMainDetail.Controls.Add(Me.txtOtherDocCode)
      Me.grbMainDetail.Controls.Add(Me.lblOtherDocCode)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 10)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(385, 209)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'ibtnShowEquipment
      '
      Me.ibtnShowEquipment.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEquipment.Location = New System.Drawing.Point(349, 182)
      Me.ibtnShowEquipment.Name = "ibtnShowEquipment"
      Me.ibtnShowEquipment.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEquipment.TabIndex = 27
      Me.ibtnShowEquipment.TabStop = False
      Me.ibtnShowEquipment.ThemedImage = CType(resources.GetObject("ibtnShowEquipment.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEquipmentName
      '
      Me.txtEquipmentName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtEquipmentName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEquipmentName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEquipmentName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEquipmentName, System.Drawing.Color.Empty)
      Me.txtEquipmentName.Location = New System.Drawing.Point(175, 182)
      Me.Validator.SetMinValue(Me.txtEquipmentName, "")
      Me.txtEquipmentName.Name = "txtEquipmentName"
      Me.txtEquipmentName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEquipmentName, "")
      Me.Validator.SetRequired(Me.txtEquipmentName, False)
      Me.txtEquipmentName.Size = New System.Drawing.Size(150, 20)
      Me.txtEquipmentName.TabIndex = 25
      Me.txtEquipmentName.TabStop = False
      '
      'ibtnShowEquipmentDiaog
      '
      Me.ibtnShowEquipmentDiaog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEquipmentDiaog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEquipmentDiaog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEquipmentDiaog.Location = New System.Drawing.Point(325, 182)
      Me.ibtnShowEquipmentDiaog.Name = "ibtnShowEquipmentDiaog"
      Me.ibtnShowEquipmentDiaog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEquipmentDiaog.TabIndex = 26
      Me.ibtnShowEquipmentDiaog.TabStop = False
      Me.ibtnShowEquipmentDiaog.ThemedImage = CType(resources.GetObject("ibtnShowEquipmentDiaog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEquipmentCode
      '
      Me.txtEquipmentCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtEquipmentCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEquipmentCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEquipmentCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEquipmentCode, System.Drawing.Color.Empty)
      Me.txtEquipmentCode.Location = New System.Drawing.Point(95, 182)
      Me.Validator.SetMinValue(Me.txtEquipmentCode, "")
      Me.txtEquipmentCode.Name = "txtEquipmentCode"
      Me.Validator.SetRegularExpression(Me.txtEquipmentCode, "")
      Me.Validator.SetRequired(Me.txtEquipmentCode, False)
      Me.txtEquipmentCode.Size = New System.Drawing.Size(80, 20)
      Me.txtEquipmentCode.TabIndex = 24
      '
      'lblEquipment
      '
      Me.lblEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEquipment.Location = New System.Drawing.Point(16, 182)
      Me.lblEquipment.Name = "lblEquipment"
      Me.lblEquipment.Size = New System.Drawing.Size(80, 18)
      Me.lblEquipment.TabIndex = 23
      Me.lblEquipment.Text = "เครื่องจักร:"
      Me.lblEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSupplierPanel
      '
      Me.btnSupplierPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierPanel.Location = New System.Drawing.Point(349, 112)
      Me.btnSupplierPanel.Name = "btnSupplierPanel"
      Me.btnSupplierPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierPanel.TabIndex = 18
      Me.btnSupplierPanel.TabStop = False
      Me.btnSupplierPanel.ThemedImage = CType(resources.GetObject("btnSupplierPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierCode
      '
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(95, 112)
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, False)
      Me.txtSupplierCode.Size = New System.Drawing.Size(80, 20)
      Me.txtSupplierCode.TabIndex = 15
      '
      'txtSupplierName
      '
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(175, 112)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(150, 20)
      Me.txtSupplierName.TabIndex = 16
      Me.txtSupplierName.TabStop = False
      '
      'btnSupplierDialog
      '
      Me.btnSupplierDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierDialog.Location = New System.Drawing.Point(325, 112)
      Me.btnSupplierDialog.Name = "btnSupplierDialog"
      Me.btnSupplierDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierDialog.TabIndex = 17
      Me.btnSupplierDialog.TabStop = False
      Me.btnSupplierDialog.ThemedImage = CType(resources.GetObject("btnSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSupplier
      '
      Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSupplier.Location = New System.Drawing.Point(16, 112)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(80, 18)
      Me.lblSupplier.TabIndex = 14
      Me.lblSupplier.Text = "ผู้ขาย:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(95, 88)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(230, 21)
      Me.cmbStatus.TabIndex = 13
      '
      'lblStatus
      '
      Me.lblStatus.BackColor = System.Drawing.Color.Transparent
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblStatus.Location = New System.Drawing.Point(16, 88)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(80, 18)
      Me.lblStatus.TabIndex = 12
      Me.lblStatus.Text = "สถานะ:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToCCPersonCode
      '
      Me.Validator.SetDataType(Me.txtToCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.txtToCCPersonCode.Location = New System.Drawing.Point(95, 40)
      Me.Validator.SetMinValue(Me.txtToCCPersonCode, "")
      Me.txtToCCPersonCode.Name = "txtToCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtToCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtToCCPersonCode, False)
      Me.txtToCCPersonCode.Size = New System.Drawing.Size(80, 20)
      Me.txtToCCPersonCode.TabIndex = 3
      '
      'btnToCostCenterPanel
      '
      Me.btnToCostCenterPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToCostCenterPanel.Location = New System.Drawing.Point(349, 64)
      Me.btnToCostCenterPanel.Name = "btnToCostCenterPanel"
      Me.btnToCostCenterPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnToCostCenterPanel.TabIndex = 11
      Me.btnToCostCenterPanel.TabStop = False
      Me.btnToCostCenterPanel.ThemedImage = CType(resources.GetObject("btnToCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(95, 64)
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, False)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(80, 20)
      Me.txtToCostCenterCode.TabIndex = 8
      '
      'txtToCCPersonName
      '
      Me.Validator.SetDataType(Me.txtToCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.txtToCCPersonName.Location = New System.Drawing.Point(175, 40)
      Me.Validator.SetMinValue(Me.txtToCCPersonName, "")
      Me.txtToCCPersonName.Name = "txtToCCPersonName"
      Me.txtToCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCCPersonName, "")
      Me.Validator.SetRequired(Me.txtToCCPersonName, False)
      Me.txtToCCPersonName.Size = New System.Drawing.Size(150, 20)
      Me.txtToCCPersonName.TabIndex = 4
      Me.txtToCCPersonName.TabStop = False
      '
      'lblToCCPerson
      '
      Me.lblToCCPerson.BackColor = System.Drawing.Color.Transparent
      Me.lblToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCPerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblToCCPerson.Location = New System.Drawing.Point(16, 40)
      Me.lblToCCPerson.Name = "lblToCCPerson"
      Me.lblToCCPerson.Size = New System.Drawing.Size(80, 24)
      Me.lblToCCPerson.TabIndex = 2
      Me.lblToCCPerson.Text = "ผู้รับ:"
      Me.lblToCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToCostCenterName
      '
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(175, 64)
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.txtToCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(150, 20)
      Me.txtToCostCenterName.TabIndex = 9
      Me.txtToCostCenterName.TabStop = False
      '
      'btnToCostCenterDialog
      '
      Me.btnToCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToCostCenterDialog.Location = New System.Drawing.Point(325, 64)
      Me.btnToCostCenterDialog.Name = "btnToCostCenterDialog"
      Me.btnToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnToCostCenterDialog.TabIndex = 10
      Me.btnToCostCenterDialog.TabStop = False
      Me.btnToCostCenterDialog.ThemedImage = CType(resources.GetObject("btnToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnToCCPersonPanel
      '
      Me.btnToCCPersonPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToCCPersonPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToCCPersonPanel.Location = New System.Drawing.Point(349, 40)
      Me.btnToCCPersonPanel.Name = "btnToCCPersonPanel"
      Me.btnToCCPersonPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnToCCPersonPanel.TabIndex = 6
      Me.btnToCCPersonPanel.TabStop = False
      Me.btnToCCPersonPanel.ThemedImage = CType(resources.GetObject("btnToCCPersonPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblToCC
      '
      Me.lblToCC.BackColor = System.Drawing.Color.Transparent
      Me.lblToCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblToCC.Location = New System.Drawing.Point(-2, 56)
      Me.lblToCC.Name = "lblToCC"
      Me.lblToCC.Size = New System.Drawing.Size(98, 32)
      Me.lblToCC.TabIndex = 7
      Me.lblToCC.Text = "CostCenter รับ:"
      Me.lblToCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnToCCPersonDialog
      '
      Me.btnToCCPersonDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToCCPersonDialog.Location = New System.Drawing.Point(325, 40)
      Me.btnToCCPersonDialog.Name = "btnToCCPersonDialog"
      Me.btnToCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnToCCPersonDialog.TabIndex = 5
      Me.btnToCCPersonDialog.TabStop = False
      Me.btnToCCPersonDialog.ThemedImage = CType(resources.GetObject("btnToCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtOtherDocCode
      '
      Me.Validator.SetDataType(Me.txtOtherDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtOtherDocCode, "")
      Me.txtOtherDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtOtherDocCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtOtherDocCode, System.Drawing.Color.Empty)
      Me.txtOtherDocCode.Location = New System.Drawing.Point(95, 136)
      Me.Validator.SetMinValue(Me.txtOtherDocCode, "")
      Me.txtOtherDocCode.Name = "txtOtherDocCode"
      Me.Validator.SetRegularExpression(Me.txtOtherDocCode, "")
      Me.Validator.SetRequired(Me.txtOtherDocCode, False)
      Me.txtOtherDocCode.Size = New System.Drawing.Size(278, 21)
      Me.txtOtherDocCode.TabIndex = 20
      '
      'lblOtherDocCode
      '
      Me.lblOtherDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOtherDocCode.ForeColor = System.Drawing.Color.Black
      Me.lblOtherDocCode.Location = New System.Drawing.Point(16, 136)
      Me.lblOtherDocCode.Name = "lblOtherDocCode"
      Me.lblOtherDocCode.Size = New System.Drawing.Size(80, 18)
      Me.lblOtherDocCode.TabIndex = 19
      Me.lblOtherDocCode.Text = "เลขที่ใบส่งของ:"
      Me.lblOtherDocCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbPV
      '
      Me.grbPV.Controls.Add(Me.txtPVCodeEnd)
      Me.grbPV.Controls.Add(Me.lblPVEnd)
      Me.grbPV.Controls.Add(Me.txtPVCodeStart)
      Me.grbPV.Controls.Add(Me.lblPVStart)
      Me.grbPV.Controls.Add(Me.btnPVStartFind)
      Me.grbPV.Controls.Add(Me.btnPVEndFind)
      Me.grbPV.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbPV.Location = New System.Drawing.Point(399, 146)
      Me.grbPV.Name = "grbPV"
      Me.grbPV.Size = New System.Drawing.Size(362, 71)
      Me.grbPV.TabIndex = 2
      Me.grbPV.TabStop = False
      Me.grbPV.Text = "เลขที่ใบสำคัญจ่าย"
      '
      'txtPVCodeEnd
      '
      Me.Validator.SetDataType(Me.txtPVCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPVCodeEnd, "")
      Me.txtPVCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPVCodeEnd, System.Drawing.Color.Empty)
      Me.txtPVCodeEnd.Location = New System.Drawing.Point(103, 40)
      Me.Validator.SetMinValue(Me.txtPVCodeEnd, "")
      Me.txtPVCodeEnd.Name = "txtPVCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtPVCodeEnd, "")
      Me.Validator.SetRequired(Me.txtPVCodeEnd, False)
      Me.txtPVCodeEnd.Size = New System.Drawing.Size(114, 21)
      Me.txtPVCodeEnd.TabIndex = 16
      '
      'lblPVEnd
      '
      Me.lblPVEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPVEnd.ForeColor = System.Drawing.Color.Black
      Me.lblPVEnd.Location = New System.Drawing.Point(16, 40)
      Me.lblPVEnd.Name = "lblPVEnd"
      Me.lblPVEnd.Size = New System.Drawing.Size(88, 18)
      Me.lblPVEnd.TabIndex = 209
      Me.lblPVEnd.Text = "ถึง:"
      Me.lblPVEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPVCodeStart
      '
      Me.Validator.SetDataType(Me.txtPVCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPVCodeStart, "")
      Me.txtPVCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPVCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPVCodeStart, System.Drawing.Color.Empty)
      Me.txtPVCodeStart.Location = New System.Drawing.Point(103, 16)
      Me.Validator.SetMinValue(Me.txtPVCodeStart, "")
      Me.txtPVCodeStart.Name = "txtPVCodeStart"
      Me.Validator.SetRegularExpression(Me.txtPVCodeStart, "")
      Me.Validator.SetRequired(Me.txtPVCodeStart, False)
      Me.txtPVCodeStart.Size = New System.Drawing.Size(114, 21)
      Me.txtPVCodeStart.TabIndex = 14
      '
      'lblPVStart
      '
      Me.lblPVStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPVStart.ForeColor = System.Drawing.Color.Black
      Me.lblPVStart.Location = New System.Drawing.Point(16, 16)
      Me.lblPVStart.Name = "lblPVStart"
      Me.lblPVStart.Size = New System.Drawing.Size(88, 18)
      Me.lblPVStart.TabIndex = 33
      Me.lblPVStart.Text = "ตั้งแต่:"
      Me.lblPVStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnPVStartFind
      '
      Me.btnPVStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPVStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPVStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPVStartFind.Location = New System.Drawing.Point(217, 15)
      Me.btnPVStartFind.Name = "btnPVStartFind"
      Me.btnPVStartFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPVStartFind.TabIndex = 15
      Me.btnPVStartFind.TabStop = False
      Me.btnPVStartFind.ThemedImage = CType(resources.GetObject("btnPVStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnPVEndFind
      '
      Me.btnPVEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPVEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPVEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPVEndFind.Location = New System.Drawing.Point(217, 40)
      Me.btnPVEndFind.Name = "btnPVEndFind"
      Me.btnPVEndFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPVEndFind.TabIndex = 17
      Me.btnPVEndFind.TabStop = False
      Me.btnPVEndFind.ThemedImage = CType(resources.GetObject("btnPVEndFind.ThemedImage"), System.Drawing.Bitmap)
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
      'txtRemark
      '
      Me.Validator.SetDataType(Me.txtRemark, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRemark, "")
      Me.txtRemark.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRemark, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRemark, System.Drawing.Color.Empty)
      Me.txtRemark.Location = New System.Drawing.Point(95, 160)
      Me.Validator.SetMinValue(Me.txtRemark, "")
      Me.txtRemark.Name = "txtRemark"
      Me.Validator.SetRegularExpression(Me.txtRemark, "")
      Me.Validator.SetRequired(Me.txtRemark, False)
      Me.txtRemark.Size = New System.Drawing.Size(278, 21)
      Me.txtRemark.TabIndex = 22
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 160)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(80, 18)
      Me.Label1.TabIndex = 21
      Me.Label1.Text = "Remark:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'GoodsReceiptFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "GoodsReceiptFilterSubPanel"
      Me.Size = New System.Drawing.Size(787, 336)
      Me.grbDetail.ResumeLayout(False)
      Me.grbApprove.ResumeLayout(False)
      Me.grbApprove.PerformLayout()
      Me.grbDueDate.ResumeLayout(False)
      Me.grbDueDate.PerformLayout()
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      Me.grbItem.ResumeLayout(False)
      Me.grbItem.PerformLayout()
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
      Me.grbPV.ResumeLayout(False)
      Me.grbPV.PerformLayout()
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

#Region "Members"
    Private m_toccperson As Employee
    Private m_tocc As CostCenter
    Private m_lci As LCIItem
    Private m_tool As Tool
    Private m_supplier As Supplier
    Private docDateStart As Date
    Private docDateEnd As Date
    Private dueDateStart As Date
    Private dueDateEnd As Date
    Private receivingDateStart As Date
    Private receivingDateEnd As Date
    Private m_dummyCC As CostCenter
    Private m_dummyLCI As LCIItem

    Private m_asset As Asset
    Private m_user As New User
#End Region

#Region "Methods"
    Public Sub Initialize()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDueDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDueDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDueDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDueDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      PopulateStatus()
      ClearCriterias()
    End Sub
    Private m_dateSetting As Boolean
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "dtpdocdatestart"
          If Not Me.docDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.docDateStart = dtpDocDateStart.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.docDateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.docDateStart = dtpDocDateStart.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDateStart.Value = Date.Now
            Me.docDateStart = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpdocdateend"
          If Not Me.docDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.docDateEnd = dtpDocDateEnd.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.docDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.docDateEnd = dtpDocDateEnd.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.docDateEnd = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpduedatestart"
          If Not Me.dueDateStart.Equals(dtpDueDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDateStart.Text = MinDateToNull(dtpDueDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.dueDateStart = dtpDueDateStart.Value
            End If
            dirtyFlag = True
          End If
        Case "txtduedatestart"
          m_dateSetting = True
          If Not Me.txtDueDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDueDateStart.Text)
            If Not Me.dueDateStart.Equals(theDate) Then
              dtpDueDateStart.Value = theDate
              Me.dueDateStart = dtpDueDateStart.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDueDateStart.Value = Date.Now
            Me.dueDateStart = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpduedateend"
          If Not Me.dueDateEnd.Equals(dtpDueDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDateEnd.Text = MinDateToNull(dtpDueDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.dueDateEnd = dtpDueDateEnd.Value
            End If
            dirtyFlag = True
          End If
        Case "txtduedateend"
          m_dateSetting = True
          If Not Me.txtDueDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDueDateEnd.Text)
            If Not Me.dueDateEnd.Equals(theDate) Then
              dtpDueDateEnd.Value = theDate
              Me.dueDateEnd = dtpDueDateEnd.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDueDateEnd.Value = Date.Now
            Me.dueDateEnd = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case Else
      End Select
    End Sub
    Private Sub ClearCriterias()
      Me.txtEquipmentCode.Text = ""
      Me.txtEquipmentName.Text = ""
      Me.m_asset = New Asset

      Me.txtCode.Text = ""
      Me.txtOtherDocCode.Text = ""
      Me.txtToCostCenterCode.Text = ""
      Me.txtToCostCenterName.Text = ""
      Me.m_tocc = New CostCenter

      Me.txtToCCPersonCode.Text = ""
      Me.txtToCCPersonName.Text = ""
      Me.m_toccperson = New Employee

      Me.txtSupplierCode.Text = ""
      Me.txtSupplierName.Text = ""
      Me.m_supplier = New Supplier

      Me.txtLCI.Text = ""
      Me.txtLCIName.Text = ""
      Me.m_lci = New LCIItem

      Me.txtTool.Text = ""
      Me.txtToolName.Text = ""
      Me.m_tool = New Tool

      Me.txtBlank.Text = ""

      Dim grDocDateStartBeforeToday As Long = Configuration.GetConfig("GRDocDateStartBeforeToday")
      Dim grDocDateEndAfterToday As Long = Configuration.GetConfig("GRDocDateEndAfterToday")
      Dim grDueDateStartBeforeToday As Long = Configuration.GetConfig("GRDueDateStartBeforeToday")
      Dim grDueDateEndAfterToday As Long = Configuration.GetConfig("GRDueDateEndAfterToday")

      Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, grDocDateStartBeforeToday, Now.Date)
      Me.dtpDocDateEnd.Value = DateAdd(DateInterval.Day, grDocDateEndAfterToday, Now.Date)

      Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, grDocDateStartBeforeToday, Now.Date), "")
      Me.txtDocDateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, grDocDateEndAfterToday, Now.Date), "")

      Me.docDateStart = DateAdd(DateInterval.Day, grDocDateStartBeforeToday, Now.Date)
      Me.docDateEnd = DateAdd(DateInterval.Day, grDocDateEndAfterToday, Now.Date)

      Me.dtpDueDateStart.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, grDueDateStartBeforeToday, Now.Date), "")
      Me.dtpDueDateEnd.Value = Me.MinDateToNull(DateAdd(DateInterval.Month, grDueDateEndAfterToday, Now.Date), "")

      Me.txtDueDateStart.Text = ""
      Me.txtDueDateEnd.Text = ""

      Me.txtPVCodeStart.Text = ""
      Me.txtPVCodeEnd.Text = ""

      Me.dueDateStart = Date.MinValue
      Me.dueDateEnd = Date.MinValue

      cmbStatus.SelectedIndex = 0

      Me.cmbApproveLevel.SelectedIndex = 0
      Me.txtApprovePerson.Text = ""
      Me.txtApprovePersonName.Text = ""
      Me.m_user = New User

      EntityRefresh()
    End Sub
    Private Sub PopulateStatus()
      Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      'Dim lvString As String = Me.StringParserService.Parse("${res:Global.Level}")
      Dim waitLVSApprove As String = Me.StringParserService.Parse("${res:Global.WaitForOtherLevelApprove}")
      Dim notAppear As String = Me.StringParserService.Parse("${res:Global.Unspecified}")
      Dim maxGRApproveLevel As Integer = CType(Configuration.GetConfig("MaxLevelApproveDO"), Integer)

      Dim dt1 As DataTable

      CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "goodsreceipt_status", True)
      dt1 = CodeDescription.GetCodeList("reference_status")
      For Each row As DataRow In dt1.Rows
        Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
        cmbStatus.Items.Add(item)
      Next

      dt1 = CodeDescription.GetCodeList("approve_status")
      Dim itemApprove1 As IdValuePair = Nothing
      Dim itemApprove2 As IdValuePair = Nothing
      Dim itemApprove3 As IdValuePair = Nothing

      For Each row As DataRow In dt1.Rows
        If Not row.IsNull("code_value") Then
          If CInt(row("code_value")) = 201 Then
            itemApprove1 = New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
          End If
          'If CInt(row("code_value")) = "202" Then
          '  itemApprove2 = New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
          'End If
          If CInt(row("code_value")) = 203 Then
            itemApprove3 = New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
          End If
        End If
      Next

      cmbApproveLevel.Items.Clear()
      cmbApproveLevel.Items.Insert(0, New IdValuePair(-1, notAppear))
      For i As Integer = 1 To maxGRApproveLevel 'User.MaxLevel
        Dim item As New IdValuePair(i - 1, String.Format(waitLVSApprove, i))
        cmbApproveLevel.Items.Add(item)
      Next
      If Not itemApprove1 Is Nothing Then
        cmbApproveLevel.Items.Insert(maxGRApproveLevel + 1, itemApprove1)
      End If
      If Not itemApprove3 Is Nothing Then
        cmbApproveLevel.Items.Insert(maxGRApproveLevel + 2, itemApprove3)
      End If
    End Sub
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblDocDateEnd}")
      Me.grbDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbdueDate}")
      Me.lblDueDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lbldueDateStart}")
      Me.lblDueDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lbldueDateEnd}")
      Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblToCCPerson}")
      Me.lblToCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblToCC}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblStatus}")
      Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbItem}")
      Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblLCI}")
      Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblTool}")
      Me.lblBlank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblBlank}")
      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblSupplier}")
      Me.lblOtherDocCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblOtherDocCode}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbMainDetail}")
      Me.grbPV.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbPV}")
      Me.lblPVStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblPVStart}")
      Me.lblPVEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblPVEnd}")
      Me.lblEquipment.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblEquipment}")

      Me.grbApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.grbApprove}")
      Me.lblApprovePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblApprovePerson}")
      Me.lblApproveLevel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptFilterSubPanel.lblApproveLevel}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(19) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("toccperson_id", IIf(Me.m_toccperson.Originated, Me.m_toccperson.Id, DBNull.Value))
      arr(2) = New Filter("tocc_id", IIf(Me.m_tocc.Originated, Me.m_tocc.Id, DBNull.Value))
      arr(3) = New Filter("docdatestart", ValidDateOrDBNull(docDateStart))
      arr(4) = New Filter("docdateend", ValidDateOrDBNull(docDateEnd))
      arr(5) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
      arr(6) = New Filter("lci_id", IIf(Me.m_lci.Originated, Me.m_lci.Id, DBNull.Value))
      arr(7) = New Filter("tool_id", IIf(Me.m_tool.Originated, Me.m_tool.Id, DBNull.Value))
      arr(8) = New Filter("stocki_itemName", IIf(Me.txtBlank.Text.Length = 0, DBNull.Value, Me.txtBlank.Text))
      arr(9) = New Filter("supplier_id", IIf(Me.m_supplier.Originated, Me.m_supplier.Id, DBNull.Value))
      arr(10) = New Filter("duedatestart", ValidDateOrDBNull(dueDateStart))
      arr(11) = New Filter("duedateend", ValidDateOrDBNull(dueDateEnd))
      arr(12) = New Filter("otherdoccode", IIf(Me.txtOtherDocCode.Text.Length = 0, DBNull.Value, Me.txtOtherDocCode.Text))
      arr(13) = New Filter("PVCodeStart", IIf(txtPVCodeStart.TextLength > 0, txtPVCodeStart.Text, DBNull.Value))
      arr(14) = New Filter("PVCodeEnd", IIf(txtPVCodeEnd.TextLength > 0, txtPVCodeEnd.Text, DBNull.Value))
      arr(15) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(16) = New Filter("stock_asset", ValidIdOrDBNull(Me.m_asset))
      arr(17) = New Filter("ApprovePerson", ValidIdOrDBNull(m_user))
      arr(18) = New Filter("ApproveLevel", IIf(cmbApproveLevel.SelectedItem Is Nothing, DBNull.Value, CType(cmbApproveLevel.SelectedItem, IdValuePair).Id))
      arr(19) = New Filter("Note", IIf(txtRemark.TextLength > 0, txtRemark.Text, DBNull.Value))
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub txtApprovePerson_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApprovePerson.Validated
      User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
    End Sub
    Private Sub txtToCCPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToCCPersonCode.Validated
      Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_toccperson)
    End Sub
    Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToCostCenterCode.Validated
      CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub ibtnShowLCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowLCI.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(DummyLCI)
    End Sub

    Private Sub ibtnShowTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowTool.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Tool)
    End Sub
    Private Sub txtLCI_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLCI.Validated
      LCIItem.GetLCIItem(txtLCI, txtLCIName, Me.m_lci)
    End Sub
    Private Sub SetLCi(ByVal e As ISimpleEntity)
      Me.txtLCI.Text = e.Code
      LCIItem.GetLCIItem(txtLCI, txtLCIName, Me.m_lci)
    End Sub
    Private Sub txtTool_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTool.Validated
      Tool.GetTool(txtTool, txtToolName, Me.m_tool)
    End Sub
    Private Sub SetTool(ByVal e As ISimpleEntity)
      Me.txtTool.Text = e.Code
      Tool.GetTool(txtTool, txtToolName, Me.m_tool)
    End Sub
    Private Sub SetUser(ByVal e As ISimpleEntity)
      Me.txtApprovePerson.Text = e.Code
      User.GetUser(txtApprovePerson, txtApprovePersonName, Me.m_user)
    End Sub
    Private Sub btnFineApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFineApprove.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New User, AddressOf SetUser)
    End Sub
    Private Sub ibtnShowLCIDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowLCIDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCi)
    End Sub
    Private Sub ibtnShowToolDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToolDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Tool, AddressOf SetTool)
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
    Private Sub btnToCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToCCPerson)
    End Sub
    Private Sub SetToCCPerson(ByVal e As ISimpleEntity)
      Me.txtToCCPersonCode.Text = e.Code
      Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_toccperson)
    End Sub
    Private Sub btnToCCPersonPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCCPersonPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
    End Sub
    Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
      Me.txtToCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub btnToCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(DummyCC)
    End Sub
    Private Sub txtSupplierCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Validated
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
    End Sub
    Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    End Sub
    Private Sub btnSupplierPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_supplier)
    End Sub
    Private Sub btnPVStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPVStartFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVStartDialog)
    End Sub
    Private Sub btnPVEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPVEndFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Payment, AddressOf SetPVEndDialog)
    End Sub
    Private Sub SetPVStartDialog(ByVal e As ISimpleEntity)
      Me.txtPVCodeStart.Text = e.Code
    End Sub
    Private Sub SetPVEndDialog(ByVal e As ISimpleEntity)
      Me.txtPVCodeEnd.Text = e.Code
    End Sub

    Private Sub txtEquipmentCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEquipmentCode.Validated
      Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_asset)
    End Sub
    Private Sub ibtnShowEquipmentDiaog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEquipmentDiaog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAsset)
    End Sub
    Private Sub ibtnShowEquipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEquipment.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Asset)
    End Sub
    Private Sub SetAsset(ByVal e As ISimpleEntity)
      Me.txtEquipmentCode.Text = e.Code
      Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_asset)
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property DummyCC() As CostCenter      Get        If m_dummyCC Is Nothing Then          m_dummyCC = New CostCenter
        End If        Return m_dummyCC      End Get    End Property
    Public ReadOnly Property DummyLCI() As LCIItem      Get        If m_dummyLCI Is Nothing Then          m_dummyLCI = New LCIItem
        End If        Return m_dummyLCI      End Get    End Property#End Region

#Region "IClipboardHandler Overrides"         'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject

        If data.GetDataPresent((DummyCC).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txttocostcentercode", "txttocostcentername"
              Return True
          End Select
        End If
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txttoccpersoncode", "txttoccpersonname"
              Return True
          End Select
        End If
        If data.GetDataPresent((DummyLCI).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtlci", "txtlciname"
              Return True
          End Select
        End If
        If data.GetDataPresent((New Tool).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txttool", "txttoolname"
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
      If data.GetDataPresent((DummyCC).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((DummyCC).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txttocostcentercode", "txttocostcentername"
            Me.SetToCostCenter(entity)
        End Select
      End If
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txttoccpersoncode", "txttoccpersonname"
            Me.SetToCCPerson(entity)
        End Select
      End If
      If data.GetDataPresent((DummyLCI).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((DummyLCI).FullClassName))
        Dim entity As New LCIItem(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtlci", "txtlciname"
            Me.SetLCi(entity)
        End Select
      End If
      If data.GetDataPresent((New Tool).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Tool).FullClassName))
        Dim entity As New Tool(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txttool", "txttoolname"
            Me.SetTool(entity)
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
        EntityRefresh()
      End Set
    End Property
    Private Sub EntityRefresh()
      If Entities Is Nothing Then
        Return
      End If
      For Each entity As ISimpleEntity In Entities

        If TypeOf entity Is GoodsReceipt Then
          Dim obj As GoodsReceipt
          obj = CType(entity, GoodsReceipt)
          ' Supplier ...
          If obj.Supplier.Originated Then
            Me.SetSupplier(obj.Supplier)
            Me.txtSupplierCode.Enabled = False
            Me.txtSupplierName.Enabled = False
            Me.btnSupplierDialog.Enabled = False
            Me.btnSupplierPanel.Enabled = False
          End If
          If entity.Status.Value <> -1 Then
            CodeDescription.ComboSelect(Me.cmbStatus, entity.Status)
            Me.cmbStatus.Enabled = False
          End If
        End If
        If TypeOf entity Is Supplier Then
          Me.SetSupplier(entity)
          Me.txtSupplierCode.Enabled = False
          Me.txtSupplierName.Enabled = False
          Me.btnSupplierDialog.Enabled = False
          Me.btnSupplierPanel.Enabled = False
        End If
      Next
    End Sub

  End Class
End Namespace

