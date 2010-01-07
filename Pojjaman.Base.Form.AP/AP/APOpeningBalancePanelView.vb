Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class APOpeningBalancePanelView
    Inherits AbstractEntityDetailPanelView
    'Inherits UserControl

#Region " Windows Form Designer generated code "
    Friend WithEvents ImbSupplier As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ddgSupplier As Longkong.Pojjaman.Gui.Components.DropDownGrid
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditPrd As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblCreditPrd As System.Windows.Forms.Label
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSupplierEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblInvoiceCode As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceCode As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ibtnEnableVatInput As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
    Friend WithEvents txtBeforeTax As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxAmount As System.Windows.Forms.Label
    Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents lblTaxType As System.Windows.Forms.Label
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxRate As System.Windows.Forms.Label
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxBase As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(APOpeningBalancePanelView))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtCreditPrd = New System.Windows.Forms.TextBox()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.txtInvoiceDate = New System.Windows.Forms.TextBox()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.txtInvoiceCode = New System.Windows.Forms.TextBox()
      Me.txtBeforeTax = New System.Windows.Forms.TextBox()
      Me.txtTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.lblTaxBase = New System.Windows.Forms.Label()
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDueDate = New System.Windows.Forms.Label()
      Me.lblPercent = New System.Windows.Forms.Label()
      Me.lblBeforeTax = New System.Windows.Forms.Label()
      Me.lblTaxAmount = New System.Windows.Forms.Label()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.lblTaxRate = New System.Windows.Forms.Label()
      Me.lblInvoiceCode = New System.Windows.Forms.Label()
      Me.lblInvoiceDate = New System.Windows.Forms.Label()
      Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
      Me.ibtnEnableVatInput = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.lblDay = New System.Windows.Forms.Label()
      Me.btnSupplierEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblCreditPrd = New System.Windows.Forms.Label()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtSupplierCode
      '
      Me.txtSupplierCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.ErrorProvider1.SetError(Me.txtSupplierCode, "กำหนดผู้ขาย")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(136, 96)
      Me.txtSupplierCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, True)
      Me.txtSupplierCode.Size = New System.Drawing.Size(120, 21)
      Me.txtSupplierCode.TabIndex = 5
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(384, 24)
      Me.txtDocDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(107, 21)
      Me.txtDocDate.TabIndex = 2
      '
      'txtCreditPrd
      '
      Me.txtCreditPrd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCreditPrd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int64Type)
      Me.Validator.SetDisplayName(Me.txtCreditPrd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCreditPrd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
      Me.txtCreditPrd.Location = New System.Drawing.Point(136, 48)
      Me.txtCreditPrd.MaxLength = 15
      Me.Validator.SetMinValue(Me.txtCreditPrd, "")
      Me.txtCreditPrd.Name = "txtCreditPrd"
      Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
      Me.Validator.SetRequired(Me.txtCreditPrd, False)
      Me.txtCreditPrd.Size = New System.Drawing.Size(120, 21)
      Me.txtCreditPrd.TabIndex = 3
      Me.txtCreditPrd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAmount
      '
      Me.txtAmount.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(136, 72)
      Me.txtAmount.MaxLength = 15
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(120, 21)
      Me.txtAmount.TabIndex = 4
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(136, 144)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(360, 21)
      Me.txtNote.TabIndex = 6
      '
      'txtInvoiceDate
      '
      Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.txtInvoiceDate.Location = New System.Drawing.Point(344, 168)
      Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
      Me.txtInvoiceDate.Name = "txtInvoiceDate"
      Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
      Me.Validator.SetRequired(Me.txtInvoiceDate, False)
      Me.txtInvoiceDate.Size = New System.Drawing.Size(126, 21)
      Me.txtInvoiceDate.TabIndex = 330
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.ErrorProvider1.SetError(Me.txtCostCenterCode, "กำหนด Cost Center")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(136, 120)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, True)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(120, 21)
      Me.txtCostCenterCode.TabIndex = 363
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
      'txtSupplierName
      '
      Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(256, 96)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(192, 21)
      Me.txtSupplierName.TabIndex = 186
      Me.txtSupplierName.TabStop = False
      '
      'txtInvoiceCode
      '
      Me.Validator.SetDataType(Me.txtInvoiceCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtInvoiceCode, "")
      Me.txtInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
      Me.txtInvoiceCode.Location = New System.Drawing.Point(136, 168)
      Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
      Me.txtInvoiceCode.Name = "txtInvoiceCode"
      Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
      Me.Validator.SetRequired(Me.txtInvoiceCode, False)
      Me.txtInvoiceCode.Size = New System.Drawing.Size(110, 21)
      Me.txtInvoiceCode.TabIndex = 329
      '
      'txtBeforeTax
      '
      Me.txtBeforeTax.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBeforeTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBeforeTax, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.txtBeforeTax.Location = New System.Drawing.Point(136, 216)
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(120, 21)
      Me.txtBeforeTax.TabIndex = 349
      Me.txtBeforeTax.TabStop = False
      Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTaxAmount
      '
      Me.txtTaxAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.txtTaxAmount.Location = New System.Drawing.Point(136, 264)
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(120, 21)
      Me.txtTaxAmount.TabIndex = 351
      Me.txtTaxAmount.TabStop = False
      Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTaxRate
      '
      Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(264, 192)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, True)
      Me.txtTaxRate.Size = New System.Drawing.Size(40, 21)
      Me.txtTaxRate.TabIndex = 347
      Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxAmount
      '
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(280, 264)
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(120, 21)
      Me.txtRealTaxAmount.TabIndex = 358
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxBase
      '
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(280, 240)
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(120, 21)
      Me.txtRealTaxBase.TabIndex = 357
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTaxBase
      '
      Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.txtTaxBase.Location = New System.Drawing.Point(136, 240)
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(120, 21)
      Me.txtTaxBase.TabIndex = 362
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(256, 120)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(192, 21)
      Me.txtCostCenterName.TabIndex = 365
      Me.txtCostCenterName.TabStop = False
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.btnCCEdit)
      Me.grbDetail.Controls.Add(Me.btnCCFind)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.txtTaxBase)
      Me.grbDetail.Controls.Add(Me.lblTaxBase)
      Me.grbDetail.Controls.Add(Me.txtRealTaxAmount)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtRealTaxBase)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxBase)
      Me.grbDetail.Controls.Add(Me.dtpDueDate)
      Me.grbDetail.Controls.Add(Me.lblDueDate)
      Me.grbDetail.Controls.Add(Me.lblPercent)
      Me.grbDetail.Controls.Add(Me.lblBeforeTax)
      Me.grbDetail.Controls.Add(Me.txtBeforeTax)
      Me.grbDetail.Controls.Add(Me.lblTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtTaxAmount)
      Me.grbDetail.Controls.Add(Me.cmbTaxType)
      Me.grbDetail.Controls.Add(Me.lblTaxType)
      Me.grbDetail.Controls.Add(Me.txtTaxRate)
      Me.grbDetail.Controls.Add(Me.lblTaxRate)
      Me.grbDetail.Controls.Add(Me.lblInvoiceCode)
      Me.grbDetail.Controls.Add(Me.txtInvoiceCode)
      Me.grbDetail.Controls.Add(Me.lblInvoiceDate)
      Me.grbDetail.Controls.Add(Me.txtInvoiceDate)
      Me.grbDetail.Controls.Add(Me.dtpInvoiceDate)
      Me.grbDetail.Controls.Add(Me.ibtnEnableVatInput)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.lblBaht)
      Me.grbDetail.Controls.Add(Me.lblDay)
      Me.grbDetail.Controls.Add(Me.btnSupplierEdit)
      Me.grbDetail.Controls.Add(Me.btnSupplierDialog)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.txtCreditPrd)
      Me.grbDetail.Controls.Add(Me.lblSupplier)
      Me.grbDetail.Controls.Add(Me.lblAmount)
      Me.grbDetail.Controls.Add(Me.txtAmount)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblCreditPrd)
      Me.grbDetail.Controls.Add(Me.txtSupplierName)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.txtSupplierCode)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(608, 336)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "เจ้าหนี้ยกมา"
      '
      'btnCCEdit
      '
      Me.btnCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCEdit.Location = New System.Drawing.Point(472, 120)
      Me.btnCCEdit.Name = "btnCCEdit"
      Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCCEdit.TabIndex = 367
      Me.btnCCEdit.TabStop = False
      Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCFind
      '
      Me.btnCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCFind.Location = New System.Drawing.Point(448, 120)
      Me.btnCCFind.Name = "btnCCFind"
      Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCCFind.TabIndex = 366
      Me.btnCCFind.TabStop = False
      Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCostCenter
      '
      Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCostCenter.Location = New System.Drawing.Point(40, 120)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(88, 18)
      Me.lblCostCenter.TabIndex = 364
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxBase
      '
      Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.Location = New System.Drawing.Point(40, 240)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(96, 18)
      Me.lblTaxBase.TabIndex = 361
      Me.lblTaxBase.Text = "ฐานภาษี :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnResetTaxAmount
      '
      Me.ibtnResetTaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(256, 264)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 360
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(256, 240)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 359
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'dtpDueDate
      '
      Me.dtpDueDate.Enabled = False
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDate.Location = New System.Drawing.Point(384, 48)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(128, 21)
      Me.dtpDueDate.TabIndex = 356
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.ForeColor = System.Drawing.Color.Black
      Me.lblDueDate.Location = New System.Drawing.Point(296, 49)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDueDate.TabIndex = 355
      Me.lblDueDate.Text = "วันที่ครบกำหนด:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPercent
      '
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(312, 192)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 348
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(24, 216)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(112, 18)
      Me.lblBeforeTax.TabIndex = 352
      Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
      Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(32, 264)
      Me.lblTaxAmount.Name = "lblTaxAmount"
      Me.lblTaxAmount.Size = New System.Drawing.Size(104, 18)
      Me.lblTaxAmount.TabIndex = 350
      Me.lblTaxAmount.Text = "ภาษี :"
      Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbTaxType
      '
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(136, 192)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
      Me.cmbTaxType.TabIndex = 346
      '
      'lblTaxType
      '
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(40, 192)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(96, 18)
      Me.lblTaxType.TabIndex = 353
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxRate
      '
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(200, 192)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(61, 18)
      Me.lblTaxRate.TabIndex = 354
      Me.lblTaxRate.Text = "อัตราภาษี :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInvoiceCode
      '
      Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceCode.Location = New System.Drawing.Point(40, 168)
      Me.lblInvoiceCode.Name = "lblInvoiceCode"
      Me.lblInvoiceCode.Size = New System.Drawing.Size(96, 18)
      Me.lblInvoiceCode.TabIndex = 332
      Me.lblInvoiceCode.Text = "เลขที่ใบกำกับภาษี:"
      Me.lblInvoiceCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInvoiceDate
      '
      Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceDate.Location = New System.Drawing.Point(256, 168)
      Me.lblInvoiceDate.Name = "lblInvoiceDate"
      Me.lblInvoiceDate.Size = New System.Drawing.Size(88, 18)
      Me.lblInvoiceDate.TabIndex = 331
      Me.lblInvoiceDate.Text = "วันที่:"
      Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpInvoiceDate
      '
      Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpInvoiceDate.Location = New System.Drawing.Point(344, 168)
      Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
      Me.dtpInvoiceDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpInvoiceDate.TabIndex = 334
      Me.dtpInvoiceDate.TabStop = False
      '
      'ibtnEnableVatInput
      '
      Me.ibtnEnableVatInput.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnEnableVatInput.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnEnableVatInput.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnEnableVatInput.Location = New System.Drawing.Point(488, 168)
      Me.ibtnEnableVatInput.Name = "ibtnEnableVatInput"
      Me.ibtnEnableVatInput.Size = New System.Drawing.Size(24, 24)
      Me.ibtnEnableVatInput.TabIndex = 333
      Me.ibtnEnableVatInput.TabStop = False
      Me.ibtnEnableVatInput.ThemedImage = CType(resources.GetObject("ibtnEnableVatInput.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(256, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 319
      Me.chkAutorun.TabStop = False
      '
      'lblBaht
      '
      Me.lblBaht.AutoSize = True
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.Location = New System.Drawing.Point(264, 72)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(27, 13)
      Me.lblBaht.TabIndex = 204
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblDay
      '
      Me.lblDay.AutoSize = True
      Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDay.Location = New System.Drawing.Point(264, 48)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(19, 13)
      Me.lblDay.TabIndex = 203
      Me.lblDay.Text = "วัน"
      Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'btnSupplierEdit
      '
      Me.btnSupplierEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierEdit.Location = New System.Drawing.Point(472, 96)
      Me.btnSupplierEdit.Name = "btnSupplierEdit"
      Me.btnSupplierEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierEdit.TabIndex = 202
      Me.btnSupplierEdit.TabStop = False
      Me.btnSupplierEdit.ThemedImage = CType(resources.GetObject("btnSupplierEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnSupplierDialog
      '
      Me.btnSupplierDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierDialog.Location = New System.Drawing.Point(448, 96)
      Me.btnSupplierDialog.Name = "btnSupplierDialog"
      Me.btnSupplierDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierDialog.TabIndex = 201
      Me.btnSupplierDialog.TabStop = False
      Me.btnSupplierDialog.ThemedImage = CType(resources.GetObject("btnSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Enabled = False
      Me.lblStatus.Location = New System.Drawing.Point(8, 304)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 13)
      Me.lblStatus.TabIndex = 198
      Me.lblStatus.Text = "lblStatus"
      '
      'lblSupplier
      '
      Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(8, 96)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(120, 18)
      Me.lblSupplier.TabIndex = 194
      Me.lblSupplier.Text = "Supplier:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAmount
      '
      Me.lblAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.Location = New System.Drawing.Point(8, 72)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(120, 18)
      Me.lblAmount.TabIndex = 192
      Me.lblAmount.Text = "จำนวนเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(280, 24)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(104, 18)
      Me.lblDocDate.TabIndex = 191
      Me.lblDocDate.Text = "Document Date:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(120, 18)
      Me.lblCode.TabIndex = 190
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCreditPrd
      '
      Me.lblCreditPrd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCreditPrd.Location = New System.Drawing.Point(8, 48)
      Me.lblCreditPrd.Name = "lblCreditPrd"
      Me.lblCreditPrd.Size = New System.Drawing.Size(120, 18)
      Me.lblCreditPrd.TabIndex = 193
      Me.lblCreditPrd.Text = "ระยะเวลาเครดิต:"
      Me.lblCreditPrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 144)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(120, 18)
      Me.lblNote.TabIndex = 195
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(384, 24)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(128, 21)
      Me.dtpDocDate.TabIndex = 185
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(136, 24)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 368
      '
      'APOpeningBalancePanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "APOpeningBalancePanelView"
      Me.Size = New System.Drawing.Size(624, 352)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
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

#Region " SetLabeltext "
    Public Sub SetStatus()
      If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
        lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name
      ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
        lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name
      ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
        lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
      Else
        lblStatus.Text = "ยังไม่ได้บันทึก"
      End If
    End Sub
#End Region

#Region "Members"
    Private m_entity As APOpeningBalance
    Private m_printDocument As PrintDocument
    Private m_printingStringFormat As StringFormat
    Private m_isInitialized As Boolean = False

    Private dummyCC As New CostCenter

    Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Global.SupplierText}")
      Me.Validator.SetDisplayName(Me.txtSupplierCode, Me.lblSupplier.Text)

      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Global.CostCenterText}")
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, Me.lblCostCenter.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(Me.txtDocDate, Me.lblDocDate.Text)

      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOpeningBalancePanelView.lblAmount}")
      Me.Validator.SetDisplayName(Me.txtAmount, Me.lblAmount.Text)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOpeningBalancePanelView.lblCode}")
      Me.Validator.SetDisplayName(Me.cmbCode, Me.lblCode.Text)

      Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOpeningBalancePanelView.lblCreditPrd}")
      Me.Validator.SetDisplayName(Me.txtCreditPrd, Me.lblCreditPrd.Text)

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.Validator.SetDisplayName(Me.txtNote, Me.lblNote.Text)

      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.APOpeningBalancePanelView.grbDetail}")

      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCreditPrd.TextChanged, AddressOf Me.TextHandler
      AddHandler txtAmount.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPrd.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCostCenterCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtInvoiceCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtInvoiceDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpInvoiceDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler
    End Sub
    Public Overrides Sub Initialize()
      SetTaxTypeComboBox()
    End Sub
    Private Sub SetTaxTypeComboBox()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType", "code_Value <> 1")
      cmbTaxType.SelectedIndex = 1
    End Sub
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Not Me.m_entity.Status Is Nothing Then
        If Me.m_entity.Status.Value = 0 _
        OrElse m_entityRefed = 1 _
        Then
          For Each ctrl As Control In Me.grbDetail.Controls
            ctrl.Enabled = False
          Next
        Else
          For Each ctrl As Control In Me.grbDetail.Controls
            ctrl.Enabled = CBool(m_enableState(ctrl))
          Next
        End If
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each ctrl As Control In grbDetail.Controls
        If TypeOf ctrl Is TextBox Then
          ctrl.Text = ""
        End If
      Next
      txtDocDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      dtpDocDate.Value = Now
    End Sub
    Private supplierCodeChanged As Boolean = False
    Private txtcreditprdChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcostcentercode"
          toCCCodeChanged = True
        Case "txtsuppliercode"
          supplierCodeChanged = True
        Case "txtcreditprd"
          txtcreditprdChanged = True
        Case "txtamount"
          Dim txt As String = Me.txtAmount.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.Amount = 0
          Else
            Try
              Me.m_entity.Amount = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.Amount = 0
            End Try
          End If
          Me.txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          UpdateAmount()
        Case "txtrealtaxbase"
          Dim txt As String = Me.txtRealTaxBase.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealTaxBase = 0
          Else
            Try
              Me.m_entity.RealTaxBase = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.RealTaxBase = 0
            End Try
          End If
          UpdateAmount()
        Case "txtrealtaxamount"
          Dim txt As String = Me.txtRealTaxAmount.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealTaxAmount = 0
          Else
            Try
              Me.m_entity.RealTaxAmount = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.RealTaxAmount = 0
            End Try
          End If
          UpdateAmount()
      End Select
    End Sub
    Private m_oldInvoiceCode As String = ""
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If Me.m_entity Is Nothing Then
        Return
      End If
      oldSupId = Me.m_entity.Supplier.Id
      ' txtCode.Text = Me.m_entity.Code
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)

      txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)

      If Not Me.m_entity.Supplier Is Nothing Then
        txtSupplierCode.Text = Me.m_entity.Supplier.Code
        txtSupplierName.Text = Me.m_entity.Supplier.Name
      End If

      If Not Me.m_entity.CostCenter Is Nothing Then
        txtCostCenterCode.Text = m_entity.CostCenter.Code
        txtCostCenterName.Text = m_entity.CostCenter.Name
      End If

      txtNote.Text = Me.m_entity.Note

      Dim myVat As Vat = Me.m_entity.Vat
      If Not myVat Is Nothing Then
        If myVat.ItemCollection.Count <= 0 Then  ' No Vat
          VatInputEnabled(True)
          Me.txtInvoiceCode.Text = ""
          Me.txtInvoiceDate.Text = ""
          Me.dtpInvoiceDate.Value = Now
        ElseIf myVat.ItemCollection.Count = 1 Then
          VatInputEnabled(True)
          Dim vi As VatItem
          vi = myVat.ItemCollection(0)
          Me.txtInvoiceCode.Text = vi.Code
          Me.txtInvoiceDate.Text = MinDateToNull(vi.DocDate, "") 'Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          Me.dtpInvoiceDate.Value = MinDateToNow(vi.DocDate)
        Else
          VatInputEnabled(False)
          Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
          Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
          Me.dtpInvoiceDate.Value = Now
        End If
      End If
      m_oldInvoiceCode = Me.txtInvoiceCode.Text

      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
      txtDocDate.Text = Me.MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      UpdateAmount()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub VatInputEnabled(ByVal enable As Boolean)
      Me.txtInvoiceCode.Enabled = enable
      Me.txtInvoiceDate.Enabled = enable
      Me.dtpInvoiceDate.Enabled = enable
      If enable Then
        'Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.DateTimeType)
        'Me.Validator.SetRequired(Me.txtInvoiceCode, True)
        '--------------
        Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.StringType)
        Me.Validator.SetRequired(Me.txtInvoiceCode, False)
        '---------------
        If Me.m_isInitialized Then
          'ไม่ได้มาจาก UpdateEntityProperties
          SetVatToOneDoc()
        End If
      Else
        Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.StringType)
        Me.Validator.SetRequired(Me.txtInvoiceCode, False)
      End If
    End Sub
    Private m_dateSetting As Boolean
    Private oldSupId As Integer
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtrealtaxbase"
          dirtyFlag = True
        Case "txtrealtaxamount"
          dirtyFlag = True
        Case "cmbcode"
          'เพิ่ม AutoCode
          If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
            Me.m_entity.OnGlChanged()
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtsuppliercode"
          If supplierCodeChanged Then
            supplierCodeChanged = False
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim oldSupplier As Supplier = Me.m_entity.Supplier
            If Me.txtSupplierCode.TextLength <> 0 Then
              Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
            Else
              Me.m_entity.Supplier = New Supplier
              txtSupplierName.Text = ""
            End If
            Try
              If oldSupId <> Me.m_entity.Supplier.Id Then
                If oldSupId = 0 OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeSupplier}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeSupplier}") Then
                  oldSupId = Me.m_entity.Supplier.Id
                  dirtyFlag = True
                  ChangeSupplier()
                Else
                  dirtyFlag = False
                  Me.m_entity.Supplier = oldSupplier
                  Me.txtSupplierCode.Text = oldSupplier.Code
                  Me.txtSupplierName.Text = oldSupplier.Name
                  supplierCodeChanged = False
                End If
              End If
            Catch ex As Exception

            End Try
          End If
        Case "dtpdocdate"
          If Not m_dateSetting Then
            If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
              If Not m_dateSetting Then
                Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                Me.m_entity.DocDate = dtpDocDate.Value
                Me.m_entity.Payment.DocDate = dtpDocDate.Value
                Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
                dirtyFlag = True
              End If
            End If
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              Me.m_entity.Payment.DocDate = dtpDocDate.Value
              Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            Me.m_entity.Payment.DocDate = Date.MinValue
          End If
          m_dateSetting = False
        Case "txtcreditprd"
          If txtcreditprdChanged Then
            txtcreditprdChanged = False
            Dim txt As String = Me.txtCreditPrd.Text
            If txt.Length > 0 AndAlso IsNumeric(txt) Then
              Me.m_entity.CreditPeriod = CInt(txt)
            Else
              Me.m_entity.CreditPeriod = 0
            End If
            txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
            Me.dtpDueDate.Value = Me.m_entity.DueDate
            dirtyFlag = True
          End If
        Case "txtamount"
          dirtyFlag = True
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Me.m_entity.TaxType.Value = item.Id
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          UpdateAmount()
          dirtyFlag = True
        Case "txtinvoicecode"
          If m_oldInvoiceCode <> Me.txtInvoiceCode.Text Then
            Me.m_entity.Vat.CodeChanged(Me.txtInvoiceCode.Text)
            m_oldInvoiceCode = Me.txtInvoiceCode.Text
            dirtyFlag = True
          End If
        Case "txtinvoicedate"
          m_dateSetting = True
          dirtyFlag = Me.m_entity.Vat.DateTextChanged(txtInvoiceDate, dtpInvoiceDate, Me.Validator)
          m_dateSetting = False
        Case "dtpinvoicedate"
          dirtyFlag = Me.m_entity.Vat.DatePickerChanged(dtpInvoiceDate, txtInvoiceDate, m_dateSetting)
        Case "txtcostcentercode"
          If toCCCodeChanged Then
            If Me.txtCostCenterCode.TextLength <> 0 Then
              dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            Else
              Me.m_entity.CostCenter = New CostCenter
              txtCostCenterName.Text = ""
            End If
            Try
              If oldCCId <> Me.m_entity.CostCenter.Id Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
                oldCCId = Me.m_entity.CostCenter.Id
              End If
            Catch ex As Exception

            End Try
            toCCCodeChanged = False
          End If
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      SetStatus()
      CheckFormEnable()
    End Sub
    Private Sub ChangeSupplier()
      oldSupId = Me.m_entity.Supplier.Id
      For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
        vitem.PrintName = Me.m_entity.Supplier.Name
        vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
      Next
      supplierCodeChanged = False
      Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
      txtcreditprdChanged = False
    End Sub
    Private Sub SetVatToNoDoc()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_entity.Vat.ItemCollection.Clear()
      Me.txtInvoiceCode.Text = ""
      Me.txtInvoiceDate.Text = ""
      Me.dtpInvoiceDate.Value = Now
      Me.m_isInitialized = flag
    End Sub
    Private Sub SetVatToOneDoc()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_entity.Vat.SetVatToOneDoc(txtInvoiceCode _
      , txtInvoiceDate _
      , dtpInvoiceDate)
      Me.m_isInitialized = flag
    End Sub
    Private Sub ibtnResetTaxBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxBase.Click
      If Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
      UpdateAmount()
    End Sub
    Private Sub ibtnResetTaxAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxAmount.Click
      If Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
      UpdateAmount()
    End Sub
    Private forceUpdateTaxBase As Boolean = False
    Private forceUpdateTaxAmount As Boolean = False
    Private Sub UpdateAmount()
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False

      'HACK: forceUpdateGross ต้องอยู่อันแรกนะจ๊ะ
      If forceUpdateTaxBase OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
        Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
        forceUpdateTaxBase = False
      End If
      If forceUpdateTaxAmount OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount) Then
        Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
        forceUpdateTaxAmount = False
      End If

      txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
      txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)
      Me.txtAmount.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
      txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
      txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
      CodeDescription.ComboSelect(Me.cmbTaxType, Me.m_entity.TaxType)

      txtRealTaxAmount.Text = Configuration.FormatToString(m_entity.RealTaxAmount, DigitConfig.Price)
      txtRealTaxBase.Text = Configuration.FormatToString(m_entity.RealTaxBase, DigitConfig.Price)

      m_isInitialized = flag
      SetVatInputAfterAmountChange()
    End Sub
    Private Sub SetVatInputAfterAmountChange()
      If Me.m_entity.TaxType.Value = 0 Then
        'ไม่มี Vat
        SetVatToNoDoc()
        Me.VatInputEnabled(False)
        Me.ibtnEnableVatInput.Enabled = False
        Dim flag As Boolean = m_isInitialized
        Me.m_isInitialized = False
        Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.NoTaxText}")
        Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.NoTaxText}")
        Me.dtpInvoiceDate.Value = Now
        Me.m_isInitialized = flag
      ElseIf Me.m_entity.Vat.ItemCollection.Count > 1 Then
        'มี Vatitem มากกว่า 1 ใบ
        Me.VatInputEnabled(False)
        Me.ibtnEnableVatInput.Enabled = True
        Dim flag As Boolean = m_isInitialized
        Me.m_isInitialized = False
        Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
        Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
        Me.dtpInvoiceDate.Value = Now
        Me.m_isInitialized = flag
      ElseIf Me.m_entity.Vat.ItemCollection.Count <= 0 Then
        'ไม่มี Vatitem
        Dim flag As Boolean = m_isInitialized
        Me.m_isInitialized = False
        Me.txtInvoiceCode.Text = ""
        Me.txtInvoiceDate.Text = ""
        Me.dtpInvoiceDate.Value = Now
        Me.m_isInitialized = True
        Me.VatInputEnabled(True)
        Me.m_isInitialized = flag
        Me.ibtnEnableVatInput.Enabled = True
      Else
        'มี Vatitem ใบเดียว
        Dim flag As Boolean = m_isInitialized
        Me.m_isInitialized = True
        Me.VatInputEnabled(True)
        Me.m_isInitialized = flag
        Me.ibtnEnableVatInput.Enabled = True
      End If
    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, APOpeningBalance)
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        UpdateEntityProperties()
      End Set
    End Property

#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercode", "txtsuppliername"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsuppliercode", "txtsuppliername"
              Me.SetSupplier(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub ibtnEnableVatInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnEnableVatInput.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.Vat.ItemCollection.Count > 1 Then
        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.MultipleVatDoc}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.InputTax}") Then
          Me.VatInputEnabled(True)
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      End If
    End Sub
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
    Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    End Sub
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
    End Sub
    Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    ' Costcenter
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(dummyCC, AddressOf SetCostCenterDialog)
    End Sub
    Private toCCCodeChanged As Boolean = False
    Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
      If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
        Me.txtCostCenterCode.Text = e.Code
        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Try
          If oldCCId <> Me.m_entity.CostCenter.Id Then
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            oldCCId = Me.m_entity.CostCenter.Id
          End If
        Catch ex As Exception
        End Try
        toCCCodeChanged = False
      ElseIf Me.txtCostCenterCode.Text.Length = 0 Then
        Me.txtCostCenterCode.Text = e.Code
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      End If
    End Sub
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyCC)
    End Sub
#End Region

    Protected Overrides Sub Finalize()
      MyBase.Finalize()
    End Sub
  End Class
End Namespace

