Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class MatReturnForOperationDetailView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "
    Friend WithEvents chkShowCost As System.Windows.Forms.CheckBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grbFromCC As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
    Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowFromCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowFromCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowFromCCPerson As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowFromCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbToCC As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnShowToCCPerson As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowToCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowToCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents lblToCCPerson As System.Windows.Forms.Label
    Friend WithEvents lbltoCC As System.Windows.Forms.Label
    Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtToCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCustomerPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents btnCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MatReturnForOperationDetailView))
      Me.chkShowCost = New System.Windows.Forms.CheckBox
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblStatus = New System.Windows.Forms.Label
      Me.grbFromCC = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox
      Me.lblFromCCPerson = New System.Windows.Forms.Label
      Me.lblFromCostCenter = New System.Windows.Forms.Label
      Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox
      Me.txtFromCCPersonName = New System.Windows.Forms.TextBox
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox
      Me.ibtnShowFromCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowFromCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowFromCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowFromCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbToCC = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.ibtnShowToCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowToCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowToCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtToCCPersonCode = New System.Windows.Forms.TextBox
      Me.lblToCCPerson = New System.Windows.Forms.Label
      Me.lbltoCC = New System.Windows.Forms.Label
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox
      Me.txtToCCPersonName = New System.Windows.Forms.TextBox
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblItem = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtCustomerCode = New System.Windows.Forms.TextBox
      Me.txtCustomerName = New System.Windows.Forms.TextBox
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.btnCustomerPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblCustomer = New System.Windows.Forms.Label
      Me.cmbCode = New System.Windows.Forms.ComboBox
      Me.grbFromCC.SuspendLayout()
      Me.grbToCC.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'chkShowCost
      '
      Me.chkShowCost.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowCost.Location = New System.Drawing.Point(240, 160)
      Me.chkShowCost.Name = "chkShowCost"
      Me.chkShowCost.TabIndex = 9
      Me.chkShowCost.Text = "chkShowCost"
      Me.chkShowCost.Visible = False
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(160, 160)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 7
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(184, 160)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 8
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblStatus.Location = New System.Drawing.Point(392, 160)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(35, 17)
      Me.lblStatus.TabIndex = 6
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'grbFromCC
      '
      Me.grbFromCC.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbFromCC.Controls.Add(Me.lblFromCCPerson)
      Me.grbFromCC.Controls.Add(Me.lblFromCostCenter)
      Me.grbFromCC.Controls.Add(Me.txtFromCCPersonCode)
      Me.grbFromCC.Controls.Add(Me.txtFromCCPersonName)
      Me.grbFromCC.Controls.Add(Me.txtFromCostCenterName)
      Me.grbFromCC.Controls.Add(Me.ibtnShowFromCostCenter)
      Me.grbFromCC.Controls.Add(Me.ibtnShowFromCostCenterDialog)
      Me.grbFromCC.Controls.Add(Me.ibtnShowFromCCPerson)
      Me.grbFromCC.Controls.Add(Me.ibtnShowFromCCPersonDialog)
      Me.grbFromCC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbFromCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbFromCC.Location = New System.Drawing.Point(16, 72)
      Me.grbFromCC.Name = "grbFromCC"
      Me.grbFromCC.Size = New System.Drawing.Size(384, 72)
      Me.grbFromCC.TabIndex = 1
      Me.grbFromCC.TabStop = False
      Me.grbFromCC.Text = "ผู้คืน"
      '
      'txtFromCostCenterCode
      '
      Me.txtFromCostCenterCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(144, 16)
      Me.txtFromCostCenterCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtFromCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, True)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(64, 21)
      Me.txtFromCostCenterCode.TabIndex = 5
      Me.txtFromCostCenterCode.Text = ""
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.Location = New System.Drawing.Point(8, 40)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(128, 18)
      Me.lblFromCCPerson.TabIndex = 9
      Me.lblFromCCPerson.Text = "ผู้คืน:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.Location = New System.Drawing.Point(8, 16)
      Me.lblFromCostCenter.Name = "lblFromCostCenter"
      Me.lblFromCostCenter.Size = New System.Drawing.Size(128, 18)
      Me.lblFromCostCenter.TabIndex = 8
      Me.lblFromCostCenter.Text = "คืนจาก Cost Center:"
      Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFromCCPersonCode
      '
      Me.txtFromCCPersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(144, 40)
      Me.txtFromCCPersonCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtFromCCPersonCode, "")
      Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonCode, True)
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(64, 21)
      Me.txtFromCCPersonCode.TabIndex = 6
      Me.txtFromCCPersonCode.Text = ""
      '
      'txtFromCCPersonName
      '
      Me.Validator.SetDataType(Me.txtFromCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(208, 40)
      Me.Validator.SetMaxValue(Me.txtFromCCPersonName, "")
      Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(120, 21)
      Me.txtFromCCPersonName.TabIndex = 3
      Me.txtFromCCPersonName.TabStop = False
      Me.txtFromCCPersonName.Text = ""
      '
      'txtFromCostCenterName
      '
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(208, 16)
      Me.Validator.SetMaxValue(Me.txtFromCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(120, 21)
      Me.txtFromCostCenterName.TabIndex = 2
      Me.txtFromCostCenterName.TabStop = False
      Me.txtFromCostCenterName.Text = ""
      '
      'ibtnShowFromCostCenter
      '
      Me.ibtnShowFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenter.Image = CType(resources.GetObject("ibtnShowFromCostCenter.Image"), System.Drawing.Image)
      Me.ibtnShowFromCostCenter.Location = New System.Drawing.Point(352, 16)
      Me.ibtnShowFromCostCenter.Name = "ibtnShowFromCostCenter"
      Me.ibtnShowFromCostCenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCostCenter.TabIndex = 7
      Me.ibtnShowFromCostCenter.TabStop = False
      Me.ibtnShowFromCostCenter.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowFromCostCenterDialog
      '
      Me.ibtnShowFromCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowFromCostCenterDialog.Image = CType(resources.GetObject("ibtnShowFromCostCenterDialog.Image"), System.Drawing.Image)
      Me.ibtnShowFromCostCenterDialog.Location = New System.Drawing.Point(328, 16)
      Me.ibtnShowFromCostCenterDialog.Name = "ibtnShowFromCostCenterDialog"
      Me.ibtnShowFromCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCostCenterDialog.TabIndex = 4
      Me.ibtnShowFromCostCenterDialog.TabStop = False
      Me.ibtnShowFromCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowFromCCPerson
      '
      Me.ibtnShowFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCCPerson.Image = CType(resources.GetObject("ibtnShowFromCCPerson.Image"), System.Drawing.Image)
      Me.ibtnShowFromCCPerson.Location = New System.Drawing.Point(352, 40)
      Me.ibtnShowFromCCPerson.Name = "ibtnShowFromCCPerson"
      Me.ibtnShowFromCCPerson.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCCPerson.TabIndex = 6
      Me.ibtnShowFromCCPerson.TabStop = False
      Me.ibtnShowFromCCPerson.ThemedImage = CType(resources.GetObject("ibtnShowFromCCPerson.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowFromCCPersonDialog
      '
      Me.ibtnShowFromCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowFromCCPersonDialog.Image = CType(resources.GetObject("ibtnShowFromCCPersonDialog.Image"), System.Drawing.Image)
      Me.ibtnShowFromCCPersonDialog.Location = New System.Drawing.Point(328, 40)
      Me.ibtnShowFromCCPersonDialog.Name = "ibtnShowFromCCPersonDialog"
      Me.ibtnShowFromCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCCPersonDialog.TabIndex = 5
      Me.ibtnShowFromCCPersonDialog.TabStop = False
      Me.ibtnShowFromCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbToCC
      '
      Me.grbToCC.Controls.Add(Me.ibtnShowToCCPerson)
      Me.grbToCC.Controls.Add(Me.ibtnShowToCCPersonDialog)
      Me.grbToCC.Controls.Add(Me.ibtnShowToCostCenter)
      Me.grbToCC.Controls.Add(Me.ibtnShowToCostCenterDialog)
      Me.grbToCC.Controls.Add(Me.txtToCCPersonCode)
      Me.grbToCC.Controls.Add(Me.lblToCCPerson)
      Me.grbToCC.Controls.Add(Me.lbltoCC)
      Me.grbToCC.Controls.Add(Me.txtToCostCenterCode)
      Me.grbToCC.Controls.Add(Me.txtToCCPersonName)
      Me.grbToCC.Controls.Add(Me.txtToCostCenterName)
      Me.grbToCC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbToCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbToCC.Location = New System.Drawing.Point(408, 72)
      Me.grbToCC.Name = "grbToCC"
      Me.grbToCC.Size = New System.Drawing.Size(384, 72)
      Me.grbToCC.TabIndex = 2
      Me.grbToCC.TabStop = False
      Me.grbToCC.Text = "ผู้รับคืน"
      '
      'ibtnShowToCCPerson
      '
      Me.ibtnShowToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPerson.Image = CType(resources.GetObject("ibtnShowToCCPerson.Image"), System.Drawing.Image)
      Me.ibtnShowToCCPerson.Location = New System.Drawing.Point(352, 40)
      Me.ibtnShowToCCPerson.Name = "ibtnShowToCCPerson"
      Me.ibtnShowToCCPerson.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPerson.TabIndex = 16
      Me.ibtnShowToCCPerson.TabStop = False
      Me.ibtnShowToCCPerson.ThemedImage = CType(resources.GetObject("ibtnShowToCCPerson.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowToCCPersonDialog
      '
      Me.ibtnShowToCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCCPersonDialog.Image = CType(resources.GetObject("ibtnShowToCCPersonDialog.Image"), System.Drawing.Image)
      Me.ibtnShowToCCPersonDialog.Location = New System.Drawing.Point(328, 40)
      Me.ibtnShowToCCPersonDialog.Name = "ibtnShowToCCPersonDialog"
      Me.ibtnShowToCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPersonDialog.TabIndex = 15
      Me.ibtnShowToCCPersonDialog.TabStop = False
      Me.ibtnShowToCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowToCostCenter
      '
      Me.ibtnShowToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCostCenter.Image = CType(resources.GetObject("ibtnShowToCostCenter.Image"), System.Drawing.Image)
      Me.ibtnShowToCostCenter.Location = New System.Drawing.Point(352, 16)
      Me.ibtnShowToCostCenter.Name = "ibtnShowToCostCenter"
      Me.ibtnShowToCostCenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCostCenter.TabIndex = 14
      Me.ibtnShowToCostCenter.TabStop = False
      Me.ibtnShowToCostCenter.ThemedImage = CType(resources.GetObject("ibtnShowToCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowToCostCenterDialog
      '
      Me.ibtnShowToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCostCenterDialog.Image = CType(resources.GetObject("ibtnShowToCostCenterDialog.Image"), System.Drawing.Image)
      Me.ibtnShowToCostCenterDialog.Location = New System.Drawing.Point(328, 16)
      Me.ibtnShowToCostCenterDialog.Name = "ibtnShowToCostCenterDialog"
      Me.ibtnShowToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCostCenterDialog.TabIndex = 13
      Me.ibtnShowToCostCenterDialog.TabStop = False
      Me.ibtnShowToCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCCPersonCode
      '
      Me.txtToCCPersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtToCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.txtToCCPersonCode.Location = New System.Drawing.Point(144, 40)
      Me.txtToCCPersonCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtToCCPersonCode, "")
      Me.Validator.SetMinValue(Me.txtToCCPersonCode, "")
      Me.txtToCCPersonCode.Name = "txtToCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtToCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtToCCPersonCode, True)
      Me.txtToCCPersonCode.Size = New System.Drawing.Size(64, 21)
      Me.txtToCCPersonCode.TabIndex = 8
      Me.txtToCCPersonCode.Text = ""
      '
      'lblToCCPerson
      '
      Me.lblToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCPerson.Location = New System.Drawing.Point(8, 40)
      Me.lblToCCPerson.Name = "lblToCCPerson"
      Me.lblToCCPerson.Size = New System.Drawing.Size(128, 16)
      Me.lblToCCPerson.TabIndex = 5
      Me.lblToCCPerson.Text = "ผู้รับคืน:"
      Me.lblToCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbltoCC
      '
      Me.lbltoCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lbltoCC.Location = New System.Drawing.Point(8, 16)
      Me.lbltoCC.Name = "lbltoCC"
      Me.lbltoCC.Size = New System.Drawing.Size(128, 16)
      Me.lbltoCC.TabIndex = 4
      Me.lbltoCC.Text = "คืนเข้า Cost Center:"
      Me.lbltoCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToCostCenterCode
      '
      Me.txtToCostCenterCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(144, 16)
      Me.txtToCostCenterCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtToCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, True)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(64, 21)
      Me.txtToCostCenterCode.TabIndex = 7
      Me.txtToCostCenterCode.Text = ""
      '
      'txtToCCPersonName
      '
      Me.Validator.SetDataType(Me.txtToCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.txtToCCPersonName.Location = New System.Drawing.Point(208, 40)
      Me.Validator.SetMaxValue(Me.txtToCCPersonName, "")
      Me.Validator.SetMinValue(Me.txtToCCPersonName, "")
      Me.txtToCCPersonName.Name = "txtToCCPersonName"
      Me.txtToCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCCPersonName, "")
      Me.Validator.SetRequired(Me.txtToCCPersonName, False)
      Me.txtToCCPersonName.Size = New System.Drawing.Size(120, 21)
      Me.txtToCCPersonName.TabIndex = 11
      Me.txtToCCPersonName.TabStop = False
      Me.txtToCCPersonName.Text = ""
      '
      'txtToCostCenterName
      '
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(208, 16)
      Me.Validator.SetMaxValue(Me.txtToCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.txtToCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(120, 21)
      Me.txtToCostCenterName.TabIndex = 12
      Me.txtToCostCenterName.TabStop = False
      Me.txtToCostCenterName.Text = ""
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.Khaki
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.BackColor = System.Drawing.Color.LemonChiffon
      Me.tgItem.CaptionForeColor = System.Drawing.SystemColors.Window
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.tgItem.GridLineColor = System.Drawing.Color.FromArgb(CType(210, Byte), CType(200, Byte), CType(120, Byte))
      Me.tgItem.HeaderBackColor = System.Drawing.Color.DarkGoldenrod
      Me.tgItem.HeaderForeColor = System.Drawing.Color.White
      Me.tgItem.Location = New System.Drawing.Point(16, 184)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
      Me.tgItem.Size = New System.Drawing.Size(780, 328)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 10
      Me.tgItem.TreeManager = Nothing
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbDetail.Location = New System.Drawing.Point(16, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(776, 64)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ทั่วไป"
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(216, 15)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 5
      Me.chkAutorun.TabStop = False
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(344, 15)
      Me.txtDocDate.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(124, 21)
      Me.txtDocDate.TabIndex = 2
      Me.txtDocDate.Text = ""
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDocDate.Location = New System.Drawing.Point(248, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(96, 18)
      Me.lblDocDate.TabIndex = 6
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(344, 15)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 3
      Me.dtpDocDate.TabStop = False
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(576, 21)
      Me.txtNote.TabIndex = 4
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 40)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(80, 18)
      Me.lblNote.TabIndex = 4
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 3
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(16, 160)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(104, 19)
      Me.lblItem.TabIndex = 4
      Me.lblItem.Text = "รายการเบิกวัสดุ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'txtCustomerCode
      '
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(552, 144)
      Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, False)
      Me.txtCustomerCode.Size = New System.Drawing.Size(64, 21)
      Me.txtCustomerCode.TabIndex = 208
      Me.txtCustomerCode.Text = ""
      '
      'txtCustomerName
      '
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(616, 144)
      Me.Validator.SetMaxValue(Me.txtCustomerName, "")
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(120, 21)
      Me.txtCustomerName.TabIndex = 210
      Me.txtCustomerName.TabStop = False
      Me.txtCustomerName.Text = ""
      '
      'btnCustomerPanel
      '
      Me.btnCustomerPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustomerPanel.Image = CType(resources.GetObject("btnCustomerPanel.Image"), System.Drawing.Image)
      Me.btnCustomerPanel.Location = New System.Drawing.Point(760, 144)
      Me.btnCustomerPanel.Name = "btnCustomerPanel"
      Me.btnCustomerPanel.Size = New System.Drawing.Size(24, 23)
      Me.btnCustomerPanel.TabIndex = 211
      Me.btnCustomerPanel.TabStop = False
      Me.btnCustomerPanel.ThemedImage = CType(resources.GetObject("btnCustomerPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCustomerDialog
      '
      Me.btnCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCustomerDialog.Image = CType(resources.GetObject("btnCustomerDialog.Image"), System.Drawing.Image)
      Me.btnCustomerDialog.Location = New System.Drawing.Point(736, 144)
      Me.btnCustomerDialog.Name = "btnCustomerDialog"
      Me.btnCustomerDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnCustomerDialog.TabIndex = 212
      Me.btnCustomerDialog.TabStop = False
      Me.btnCustomerDialog.ThemedImage = CType(resources.GetObject("btnCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCustomer
      '
      Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCustomer.Location = New System.Drawing.Point(440, 144)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(104, 18)
      Me.lblCustomer.TabIndex = 209
      Me.lblCustomer.Text = "ลูกค้า:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(96, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 9
      '
      'MatReturnForOperationDetailView
      '
      Me.Controls.Add(Me.btnCustomerPanel)
      Me.Controls.Add(Me.txtCustomerCode)
      Me.Controls.Add(Me.txtCustomerName)
      Me.Controls.Add(Me.btnCustomerDialog)
      Me.Controls.Add(Me.lblCustomer)
      Me.Controls.Add(Me.chkShowCost)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.lblStatus)
      Me.Controls.Add(Me.grbFromCC)
      Me.Controls.Add(Me.grbToCC)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.lblItem)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "MatReturnForOperationDetailView"
      Me.Size = New System.Drawing.Size(808, 528)
      Me.grbFromCC.ResumeLayout(False)
      Me.grbToCC.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub
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
#End Region

#Region "Members"
    Private m_entity As MatReturn
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
    Private m_combocodeindex As Integer
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dt As TreeTable = MatReturn.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf MRItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbFromCC.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbToCC.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Return CreateTableStyle(True)
    End Function
    Public Function CreateTableStyle(ByVal group As Boolean) As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "MatReturn"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "stocki_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "stocki_linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = Not group
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""


      Dim csstocki_itemName As New TreeTextColumn
      csstocki_itemName.MappingName = "stocki_itemName"
      csstocki_itemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.DescriptionHeaderText}")
      csstocki_itemName.NullText = ""
      csstocki_itemName.Width = 180
      csstocki_itemName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      csstocki_itemName.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      csUnit.ReadOnly = Not group

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClicked

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "stocki_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      csQty.ReadOnly = Not group

      Dim csStockQty As New TreeTextColumn
      csStockQty.MappingName = "StockQty"
      csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.StockQtyHeaderText}")
      csStockQty.NullText = ""
      csStockQty.DataAlignment = HorizontalAlignment.Right
      csStockQty.Format = "#,###.##"
      csStockQty.ReadOnly = True

      Dim csTransferUnitPrice As New TreeTextColumn
      csTransferUnitPrice.MappingName = "stocki_transferunitprice"
      csTransferUnitPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.TransferUnitPriceHeaderText}")
      csTransferUnitPrice.NullText = ""
      csTransferUnitPrice.DataAlignment = HorizontalAlignment.Right
      csTransferUnitPrice.Format = "#,###.##"
      csTransferUnitPrice.ReadOnly = Not group

      Dim csTransferAmount As New TreeTextColumn
      csTransferAmount.MappingName = "stocki_transferamt"
      csTransferAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.TransferAmountHeaderText}")
      csTransferAmount.NullText = ""
      csTransferAmount.DataAlignment = HorizontalAlignment.Right
      csTransferAmount.Format = "#,###.##"
      csTransferAmount.ReadOnly = True

      Dim csUnitCost As New TreeTextColumn
      csUnitCost.MappingName = "stocki_unitcost"
      csUnitCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.UnitCostHeaderText}")
      csUnitCost.NullText = ""
      csUnitCost.TextBox.Name = "stocki_unitcost"
      csUnitCost.ReadOnly = True
      If group Then
        csUnitCost.Width = 0
      Else
        csUnitCost.Width = 80
      End If

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "stocki_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "stocki_note"
      csNote.ReadOnly = Not group

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csstocki_itemName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csStockQty)
      'dst.GridColumnStyles.Add(csUnitCost)
      'dst.GridColumnStyles.Add(csTransferUnitPrice)
      'dst.GridColumnStyles.Add(csTransferAmount)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Private Sub ToggleStyle(ByVal dst As DataGridTableStyle)
      For Each col As DataGridColumnStyle In dst.GridColumnStyles
        Select Case col.MappingName.ToLower
          Case "code", "unit", "stocki_qty", "stocki_note"
            If Me.m_entity.Grouping Then
              col.ReadOnly = CBool(Me.m_tableStyleEnable(col))
            Else
              col.ReadOnly = True
            End If
          Case "stocki_unitcost"
            If Me.m_entity.Grouping Then
              col.Width = 0
            Else
              col.Width = 80
            End If
        End Select
      Next
    End Sub
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 5 Then
        Me.UnitClicked(e)
      ElseIf e.Column = 2 Then
        Me.LCIClicked(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As MatReturnItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is MatReturnItem Then
          Return Nothing
        End If
        Return CType(row.Tag, MatReturnItem)
      End Get
    End Property

    Private Property ComboCodeIndex() As Integer
      Get
        If m_combocodeindex = -1 Then
          If cmbCode.Items.Count > 0 Then
            m_combocodeindex = 0
          End If
        End If
        Return m_combocodeindex
      End Get
      Set(ByVal Value As Integer)
        m_combocodeindex = Value
      End Set
    End Property
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As MatReturnItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New MatReturnItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "unit"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            doc.Unit = myUnit
          Case "stocki_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            If IsNumeric(e.ProposedValue.ToString) Then
              Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              doc.Qty = value
            End If
          Case "stocki_transferunitprice"
              If IsDBNull(e.ProposedValue) Then
                e.ProposedValue = ""
              End If
              Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              doc.TransferUnitPrice = value
          Case "stocki_note"
              If IsDBNull(e.ProposedValue) Then
                e.ProposedValue = ""
              End If
              doc.Note = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub MRItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
      OrElse m_entityRefed = 1 _
      Then
        For Each ctrl As Control In Me.grbDetail.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.grbFromCC.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.grbToCC.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In Me.grbDetail.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.grbFromCC.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.grbToCC.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
      ToggleStyle(Me.m_treeManager.GridTableStyle)
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each grb As Control In Me.Controls
        If TypeOf grb Is FixedGroupBox Then
          For Each crlt As Control In grb.Controls
            If crlt.Name.StartsWith("txt") Then
              crlt.Text = ""
            End If
          Next
        End If
      Next
      Me.dtpDocDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.grbDetail}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(Me.txtDocDate, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.lblNote}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.lblCode}")
      Me.Validator.SetDisplayName(Me.cmbCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.lblItem}")
      Me.grbFromCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.grbFromCC}")

      Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.lblFromCCPerson}")
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblFromCCPerson.Text, ":"))

      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.lblFromCostCenter}")
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblFromCostCenter.Text, ":"))

      Me.grbToCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.grbToCC}")
      Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.lblToCCPerson}")
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblToCCPerson.Text, ":"))

      Me.lbltoCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.lbltoCC}")
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lbltoCC.Text, ":"))


      Me.chkShowCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.chkShowCost}")
    End Sub
    Protected Overrides Sub EventWiring()
      'AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtToCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToCCPersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtFromCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtFromCCPersonCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtToCostCenterCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtToCCPersonCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtFromCostCenterCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtFromCCPersonCode.TextChanged, AddressOf Me.TextHandler

    End Sub

    Private toCCCodeChanged As Boolean = False
    Private toCCPersonCodeChanged As Boolean = False
    Private fromCCCodeChanged As Boolean = False
    Private fromCCPersonCodeChanged As Boolean = False

    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txttoccpersoncode"
          toCCPersonCodeChanged = True
        Case "txttocostcentercode"
          toCCCodeChanged = True
        Case "txtfromccpersoncode"
          fromCCPersonCodeChanged = True
        Case "txtfromcostcentercode"
          fromCCCodeChanged = True
      End Select
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      'txtCode.Text = m_entity.Code
      'cmbCode.Items.Clear()
      'cmbCode.DropDownStyle = ComboBoxStyle.Simple
      'cmbCode.Text = m_entity.Code
      'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
      'txtNote.Text = m_entity.Note
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
      txtToCostCenterName.Text = m_entity.ToCostCenter.Name
      txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
      txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name

      txtFromCostCenterCode.Text = m_entity.FromCostCenter.Code
      txtFromCostCenterName.Text = m_entity.FromCostCenter.Name
      txtFromCCPersonCode.Text = m_entity.FromCostCenterPerson.Code
      txtFromCCPersonName.Text = m_entity.FromCostCenterPerson.Name

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      RefreshDocs()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False

      'HACK
      If Me.m_entity.ItemCollection Is Nothing Then
        Me.m_entity.ItemCollection = New MatReturnItemCollection(Me.m_entity, Me.m_entity.Grouping)
      End If
      'END HACK

      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub UpdateAmount()
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("stocki_linenumber") = i + 1
        i += 1
      Next
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          If m_entity.AutoGen Then
            'เพิ่ม AutoCode
            If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
              Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
              Me.m_entity.Code = m_entity.AutoCodeFormat.Format
              Me.m_entity.OnGlChanged()
            End If
          Else
            Me.m_entity.Code = cmbCode.Text
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            Me.m_entity.DocDate = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "txttoccpersoncode"
          If toCCPersonCodeChanged Then
            dirtyFlag = Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_entity.ToCostCenterPerson)
            toCCPersonCodeChanged = False
          End If
        Case "txttocostcentercode"
          If toCCCodeChanged Then
            dirtyFlag = CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            UpdateDestAdmin()
            toCCCodeChanged = False
          End If
        Case "txtfromccpersoncode"
          If fromCCPersonCodeChanged Then
            dirtyFlag = Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromCostCenterPerson)
            fromCCPersonCodeChanged = False
          End If
        Case "txtfromcostcentercode"
          If fromCCCodeChanged Then
            dirtyFlag = CostCenter.GetCostCenterWithoutRight(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter)
            UpdateOriginAdmin()
            fromCCCodeChanged = False
          End If
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
      CheckFormEnable()
    End Sub
    Private Sub UpdateDestAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_entity.ToCostCenterPerson = Me.m_entity.ToCostCenter.Admin
      txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
      txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateOriginAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_entity.FromCostCenterPerson = Me.m_entity.FromCostCenter.Admin
      txtFromCCPersonCode.Text = m_entity.FromCostCenterPerson.Code
      txtFromCCPersonName.Text = m_entity.FromCostCenterPerson.Name
      Me.m_isInitialized = flag
    End Sub
    Public Sub SetStatus()
    MyBase.SetStatusBarMessage()
    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, MatReturn)
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
    End Sub
#End Region

#Region "Event Handlers"
    Private Function IsOut() As Boolean
      Return True
    End Function
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
    End Sub
    Public Sub LCIClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.FromCostCenter Is Nothing OrElse Not Me.m_entity.FromCostCenter.Originated Then
        msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.MatReturnDetailView.Message.InputFromCC}")
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New LCIForSelection
      entity.CC = Me.m_entity.FromCostCenter
      entity.FromWip = True
      entity.RefEntityId = Me.Entity.EntityId
      myEntityPanelService.OpenListDialog(entity, AddressOf SetLCIItems)
    End Sub
    Private Sub ibtnLCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIItems)
    End Sub
    Private Sub SetLCIItem(ByVal lci As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Code") = lci.Code
    End Sub
    'Private Sub txtCustomerCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerCode.Validated
    '  Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_customer)
    'End Sub
    'Private Sub btnCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerDialog.Click
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
    'End Sub
    'Private Sub btnCustomerPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerPanel.Click
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New Customer)
    'End Sub
    'Private Sub SetCustomer(ByVal e As ISimpleEntity)
    '  Me.txtCustomerCode.Text = e.Code
    '  Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_customer)
    'End Sub
    Private Sub SetLCIItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim itemEntityLevel As Integer
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As IHasName
        Dim newType As Integer = -1
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.lciitem"
            newItem = New LCIItem(item.Id)
            newType = 42
            itemEntityLevel = CType(newItem, LCIItem).Level
          Case "longkong.pojjaman.businesslogic.tool"
            newItem = New Tool(item.Id)
            newType = 19
            itemEntityLevel = 5
        End Select
        If itemEntityLevel = 5 Then
          If i = items.Count - 1 Then
            If Me.m_entity.ItemCollection.Count = 0 Then
              Dim doc As New MatReturnItem
              Me.m_entity.ItemCollection.Add(doc)
              doc.Entity = newItem
            Else
              Dim doc As New MatReturnItem
              If Not Me.CurrentItem Is Nothing Then
                doc = Me.CurrentItem
              Else
                Me.m_entity.ItemCollection.Add(doc)
              End If
              doc.Entity = newItem
            End If
          Else
            Dim doc As New MatReturnItem
            Me.m_entity.ItemCollection.Insert(index, doc)
            doc.Entity = newItem
          End If
        End If
      Next
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub

    Public Sub UnitClicked(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As MatReturnItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New MatReturnItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Dim includeFilter As Boolean = False
      If TypeOf doc.Entity Is Tool Then
        Dim mytool As Tool = CType(doc.Entity, Tool)
        If Not mytool.Unit Is Nothing AndAlso mytool.Unit.Originated Then
          filters(0) = New Filter("includedId", mytool.Unit.Id)
          includeFilter = True
        End If
      ElseIf TypeOf doc.Entity Is LCIItem Then
        Dim idList As String = CType(doc.Entity, LCIItem).GetUnitIdList
        If idList.Length > 0 Then
          filters(0) = New Filter("includedId", idList)
          includeFilter = True
        End If
      End If
      If includeFilter Then
        myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
      Else
        myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
      End If
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As MatReturnItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim theItem As New MatReturnItem
      theItem.Entity = newItem
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc), theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim doc As MatReturnItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Me.m_entity.ItemCollection.Remove(doc)
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Button Events"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        'Me.txtCode.ReadOnly = True
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
        If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
          If Me.cmbCode.Items.Count > 0 Then
            Me.m_entity.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
            Me.cmbCode.SelectedIndex = 0
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(Me.m_entity.Code)
          If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
          End If
        End If
        m_oldCode = Me.cmbCode.Text
        'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        'Me.m_entity.Code = ""
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        ' Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_oldCode
        'Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Private Sub chkShowCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowCost.CheckedChanged
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Not Me.m_isInitialized Then
        Return
      End If
      Me.m_entity.Grouping = Not Me.chkShowCost.Checked
      Me.m_entity.ItemCollection = New MatReturnItemCollection(Me.m_entity, Me.m_entity.Grouping)
      Me.ToggleStyle(Me.tgItem.TableStyles(0))
      RefreshDocs()
      'tgItem.Width += 1
      'tgItem.Width -= 1
      Me.Entity = m_entity
    End Sub

    Private Sub ibtnShowToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
    End Sub
    Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
      Me.txtToCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      UpdateDestAdmin()
      toCCCodeChanged = False
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ibtnShowToCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToPerson)
    End Sub
    Private Sub SetToPerson(ByVal e As ISimpleEntity)
      Me.txtToCCPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_entity.ToCostCenterPerson)
      toCCPersonCodeChanged = False
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ibtnShowFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCostCenter, New Filter() {New Filter("checkright", False)})
    End Sub
    Private Sub SetFromCostCenter(ByVal e As ISimpleEntity)
      Me.txtFromCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenterWithoutRight(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter)
      UpdateOriginAdmin()
      fromCCCodeChanged = False
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ibtnShowFromCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetFromPerson)
    End Sub
    Private Sub SetFromPerson(ByVal e As ISimpleEntity)
      Me.txtFromCCPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromCostCenterPerson)
      fromCCPersonCodeChanged = False
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCostCenter.Click, ibtnShowFromCostCenter.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub ShowCCPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCCPerson.Click, ibtnShowFromCCPerson.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New MatReturn).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

    Public Overrides Sub NotifyBeforeSave()
      If Not Me.m_entity.JournalEntry Is Nothing AndAlso Not Me.m_entity.JournalEntry.ManualFormat Then
        If Me.m_entity.JournalEntry.GLFormat Is Nothing OrElse Not Me.m_entity.JournalEntry.GLFormat.Originated Then
          Me.m_entity.JournalEntry.GLFormat = Me.m_entity.GetDefaultGLFormat
        End If
        Me.m_entity.JournalEntry.SetGLFormat(Me.m_entity.JournalEntry.GLFormat)
      End If
    End Sub

  End Class
End Namespace

