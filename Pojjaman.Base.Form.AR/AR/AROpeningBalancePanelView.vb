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
    Public Class AROpeningBalancePanelView
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region "Windows Form Designer generated code "
        Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents txtCreditPrd As System.Windows.Forms.TextBox
        Friend WithEvents lblAmount As System.Windows.Forms.Label
        Friend WithEvents txtAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblCreditPrd As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents btnCustomerEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblDay As System.Windows.Forms.Label
        Friend WithEvents lblBaht As System.Windows.Forms.Label
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCostCenter As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxBase As System.Windows.Forms.Label
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
    Friend WithEvents txtBeforeTax As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxAmount As System.Windows.Forms.Label
    Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents lblTaxType As System.Windows.Forms.Label
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxRate As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceCode As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceCode As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents ibtnEnableVatInput As Longkong.Pojjaman.Gui.Components.ImageButton
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AROpeningBalancePanelView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.lblTaxBase = New System.Windows.Forms.Label()
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblPercent = New System.Windows.Forms.Label()
      Me.lblBeforeTax = New System.Windows.Forms.Label()
      Me.txtBeforeTax = New System.Windows.Forms.TextBox()
      Me.lblTaxAmount = New System.Windows.Forms.Label()
      Me.txtTaxAmount = New System.Windows.Forms.TextBox()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.lblTaxRate = New System.Windows.Forms.Label()
      Me.lblInvoiceCode = New System.Windows.Forms.Label()
      Me.txtInvoiceCode = New System.Windows.Forms.TextBox()
      Me.lblInvoiceDate = New System.Windows.Forms.Label()
      Me.txtInvoiceDate = New System.Windows.Forms.TextBox()
      Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
      Me.ibtnEnableVatInput = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.btnCustomerEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.txtCreditPrd = New System.Windows.Forms.TextBox()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblCreditPrd = New System.Windows.Forms.Label()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.lblDay = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.txtTaxBase)
      Me.grbDetail.Controls.Add(Me.lblTaxBase)
      Me.grbDetail.Controls.Add(Me.txtRealTaxAmount)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtRealTaxBase)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxBase)
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
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.btnCCEdit)
      Me.grbDetail.Controls.Add(Me.btnCCFind)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.btnCustomerEdit)
      Me.grbDetail.Controls.Add(Me.btnCustomerDialog)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblCustomer)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.txtCreditPrd)
      Me.grbDetail.Controls.Add(Me.lblAmount)
      Me.grbDetail.Controls.Add(Me.txtAmount)
      Me.grbDetail.Controls.Add(Me.lblCreditPrd)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCustomerCode)
      Me.grbDetail.Controls.Add(Me.txtCustomerName)
      Me.grbDetail.Controls.Add(Me.lblBaht)
      Me.grbDetail.Controls.Add(Me.lblDay)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(616, 344)
      Me.grbDetail.TabIndex = 170
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ลูกหนี้ยกมา"
      '
      'txtTaxBase
      '
      Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.txtTaxBase.Location = New System.Drawing.Point(128, 256)
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(120, 21)
      Me.txtTaxBase.TabIndex = 393
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxBase
      '
      Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.Location = New System.Drawing.Point(32, 256)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(96, 18)
      Me.lblTaxBase.TabIndex = 392
      Me.lblTaxBase.Text = "ฐานภาษี :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRealTaxAmount
      '
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(272, 280)
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(120, 21)
      Me.txtRealTaxAmount.TabIndex = 389
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ibtnResetTaxAmount
      '
      Me.ibtnResetTaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(248, 280)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 391
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtRealTaxBase
      '
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(272, 256)
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(120, 21)
      Me.txtRealTaxBase.TabIndex = 388
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(248, 256)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 390
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblPercent
      '
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(304, 208)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 381
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(16, 232)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(112, 18)
      Me.lblBeforeTax.TabIndex = 385
      Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
      Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBeforeTax
      '
      Me.txtBeforeTax.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBeforeTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBeforeTax, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.txtBeforeTax.Location = New System.Drawing.Point(128, 232)
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(120, 21)
      Me.txtBeforeTax.TabIndex = 382
      Me.txtBeforeTax.TabStop = False
      Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(24, 280)
      Me.lblTaxAmount.Name = "lblTaxAmount"
      Me.lblTaxAmount.Size = New System.Drawing.Size(104, 18)
      Me.lblTaxAmount.TabIndex = 383
      Me.lblTaxAmount.Text = "ภาษี :"
      Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTaxAmount
      '
      Me.txtTaxAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.txtTaxAmount.Location = New System.Drawing.Point(128, 280)
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(120, 21)
      Me.txtTaxAmount.TabIndex = 384
      Me.txtTaxAmount.TabStop = False
      Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbTaxType
      '
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(128, 208)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
      Me.cmbTaxType.TabIndex = 379
      '
      'lblTaxType
      '
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(32, 208)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(96, 18)
      Me.lblTaxType.TabIndex = 386
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTaxRate
      '
      Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(256, 208)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, True)
      Me.txtTaxRate.Size = New System.Drawing.Size(40, 21)
      Me.txtTaxRate.TabIndex = 380
      Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxRate
      '
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(192, 208)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(61, 18)
      Me.lblTaxRate.TabIndex = 387
      Me.lblTaxRate.Text = "อัตราภาษี :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInvoiceCode
      '
      Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceCode.Location = New System.Drawing.Point(32, 184)
      Me.lblInvoiceCode.Name = "lblInvoiceCode"
      Me.lblInvoiceCode.Size = New System.Drawing.Size(96, 18)
      Me.lblInvoiceCode.TabIndex = 376
      Me.lblInvoiceCode.Text = "เลขที่ใบกำกับภาษี:"
      Me.lblInvoiceCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtInvoiceCode
      '
      Me.Validator.SetDataType(Me.txtInvoiceCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtInvoiceCode, "")
      Me.txtInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
      Me.txtInvoiceCode.Location = New System.Drawing.Point(128, 184)
      Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
      Me.txtInvoiceCode.Name = "txtInvoiceCode"
      Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
      Me.Validator.SetRequired(Me.txtInvoiceCode, False)
      Me.txtInvoiceCode.Size = New System.Drawing.Size(110, 21)
      Me.txtInvoiceCode.TabIndex = 373
      '
      'lblInvoiceDate
      '
      Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceDate.Location = New System.Drawing.Point(248, 184)
      Me.lblInvoiceDate.Name = "lblInvoiceDate"
      Me.lblInvoiceDate.Size = New System.Drawing.Size(88, 18)
      Me.lblInvoiceDate.TabIndex = 375
      Me.lblInvoiceDate.Text = "วันที่:"
      Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtInvoiceDate
      '
      Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.txtInvoiceDate.Location = New System.Drawing.Point(336, 184)
      Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
      Me.txtInvoiceDate.Name = "txtInvoiceDate"
      Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
      Me.Validator.SetRequired(Me.txtInvoiceDate, False)
      Me.txtInvoiceDate.Size = New System.Drawing.Size(126, 21)
      Me.txtInvoiceDate.TabIndex = 374
      '
      'dtpInvoiceDate
      '
      Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpInvoiceDate.Location = New System.Drawing.Point(336, 184)
      Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
      Me.dtpInvoiceDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpInvoiceDate.TabIndex = 378
      Me.dtpInvoiceDate.TabStop = False
      '
      'ibtnEnableVatInput
      '
      Me.ibtnEnableVatInput.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnEnableVatInput.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnEnableVatInput.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnEnableVatInput.Location = New System.Drawing.Point(480, 184)
      Me.ibtnEnableVatInput.Name = "ibtnEnableVatInput"
      Me.ibtnEnableVatInput.Size = New System.Drawing.Size(24, 24)
      Me.ibtnEnableVatInput.TabIndex = 377
      Me.ibtnEnableVatInput.TabStop = False
      Me.ibtnEnableVatInput.ThemedImage = CType(resources.GetObject("ibtnEnableVatInput.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(272, 136)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(192, 21)
      Me.txtCostCenterName.TabIndex = 370
      Me.txtCostCenterName.TabStop = False
      '
      'btnCCEdit
      '
      Me.btnCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCEdit.Location = New System.Drawing.Point(488, 136)
      Me.btnCCEdit.Name = "btnCCEdit"
      Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCCEdit.TabIndex = 372
      Me.btnCCEdit.TabStop = False
      Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCFind
      '
      Me.btnCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCFind.Location = New System.Drawing.Point(464, 136)
      Me.btnCCFind.Name = "btnCCFind"
      Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCCFind.TabIndex = 371
      Me.btnCCFind.TabStop = False
      Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCostCenter
      '
      Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCostCenter.Location = New System.Drawing.Point(40, 136)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(88, 18)
      Me.lblCostCenter.TabIndex = 369
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.ErrorProvider1.SetError(Me.txtCostCenterCode, "กำหนด Cost Center")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(128, 136)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, True)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(144, 21)
      Me.txtCostCenterCode.TabIndex = 368
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(272, 40)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 322
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Enabled = False
      Me.lblStatus.Location = New System.Drawing.Point(16, 320)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 13)
      Me.lblStatus.TabIndex = 200
      Me.lblStatus.Text = "lblStatus"
      '
      'btnCustomerEdit
      '
      Me.btnCustomerEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCustomerEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustomerEdit.Location = New System.Drawing.Point(488, 112)
      Me.btnCustomerEdit.Name = "btnCustomerEdit"
      Me.btnCustomerEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCustomerEdit.TabIndex = 199
      Me.btnCustomerEdit.TabStop = False
      Me.btnCustomerEdit.ThemedImage = CType(resources.GetObject("btnCustomerEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCustomerDialog
      '
      Me.btnCustomerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCustomerDialog.Location = New System.Drawing.Point(464, 112)
      Me.btnCustomerDialog.Name = "btnCustomerDialog"
      Me.btnCustomerDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnCustomerDialog.TabIndex = 198
      Me.btnCustomerDialog.TabStop = False
      Me.btnCustomerDialog.ThemedImage = CType(resources.GetObject("btnCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.ErrorProvider1.SetError(Me.txtDocDate, "กำหนดวันที่เอกสาร")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(384, 40)
      Me.txtDocDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(104, 21)
      Me.txtDocDate.TabIndex = 2
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(128, 160)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(384, 21)
      Me.txtNote.TabIndex = 7
      '
      'lblCustomer
      '
      Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.Location = New System.Drawing.Point(8, 112)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(120, 18)
      Me.lblCustomer.TabIndex = 172
      Me.lblCustomer.Text = "Customer:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 160)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(120, 18)
      Me.lblNote.TabIndex = 173
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCreditPrd
      '
      Me.txtCreditPrd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCreditPrd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
      Me.Validator.SetDisplayName(Me.txtCreditPrd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCreditPrd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
      Me.txtCreditPrd.Location = New System.Drawing.Point(128, 64)
      Me.Validator.SetMinValue(Me.txtCreditPrd, "")
      Me.txtCreditPrd.Name = "txtCreditPrd"
      Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
      Me.Validator.SetRequired(Me.txtCreditPrd, False)
      Me.txtCreditPrd.Size = New System.Drawing.Size(144, 21)
      Me.txtCreditPrd.TabIndex = 3
      Me.txtCreditPrd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAmount
      '
      Me.lblAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.Location = New System.Drawing.Point(8, 88)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(120, 18)
      Me.lblAmount.TabIndex = 151
      Me.lblAmount.Text = "จำนวนเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAmount
      '
      Me.txtAmount.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(128, 88)
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(144, 21)
      Me.txtAmount.TabIndex = 4
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCreditPrd
      '
      Me.lblCreditPrd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCreditPrd.Location = New System.Drawing.Point(8, 64)
      Me.lblCreditPrd.Name = "lblCreditPrd"
      Me.lblCreditPrd.Size = New System.Drawing.Size(120, 18)
      Me.lblCreditPrd.TabIndex = 152
      Me.lblCreditPrd.Text = "ระยะเวลาเครดิต:"
      Me.lblCreditPrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(384, 40)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(128, 21)
      Me.dtpDocDate.TabIndex = 129
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(296, 38)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(88, 24)
      Me.lblDocDate.TabIndex = 130
      Me.lblDocDate.Text = "Document Date:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 40)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(120, 18)
      Me.lblCode.TabIndex = 126
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustomerCode
      '
      Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.ErrorProvider1.SetError(Me.txtCustomerCode, "กำหนดลูกค้า")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCustomerCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(128, 112)
      Me.txtCustomerCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, True)
      Me.txtCustomerCode.Size = New System.Drawing.Size(144, 21)
      Me.txtCustomerCode.TabIndex = 5
      '
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(272, 112)
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(192, 21)
      Me.txtCustomerName.TabIndex = 6
      '
      'lblBaht
      '
      Me.lblBaht.AutoSize = True
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.Location = New System.Drawing.Point(280, 88)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(27, 13)
      Me.lblBaht.TabIndex = 130
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblDay
      '
      Me.lblDay.AutoSize = True
      Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDay.Location = New System.Drawing.Point(280, 64)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(19, 13)
      Me.lblDay.TabIndex = 130
      Me.lblDay.Text = "วัน"
      Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(128, 40)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(144, 21)
      Me.cmbCode.TabIndex = 394
      '
      'AROpeningBalancePanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "AROpeningBalancePanelView"
      Me.Size = New System.Drawing.Size(632, 360)
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

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AROpeningBalancePanelView.lblCode}")
      Me.Validator.SetDisplayName(Me.cmbCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AROpeningBalancePanelView.txtCodeAlert}"))


            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
            Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

            Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AROpeningBalancePanelView.lblAmount}")
            Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

            Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AROpeningBalancePanelView.lblCreditPrd}")
            Me.Validator.SetDisplayName(txtCreditPrd, lblCreditPrd.Text)

            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AROpeningBalancePanelView.lblCustomer}")
            Me.Validator.SetDisplayName(Me.txtCustomerCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AROpeningBalancePanelView.txtCustomerCodeAlert}"))

            Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Global.CostCenterText}")
            Me.Validator.SetDisplayName(Me.txtCostCenterCode, Me.lblCostCenter.Text)

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")

            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AROpeningBalancePanelView.grbDetail}")
        End Sub
#End Region

#Region "Members"
        Private m_entity As AROpeningBalance
        Private m_printDocument As PrintDocument
        Private m_printingStringFormat As StringFormat

        Private dummyCC As New CostCenter

        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.Initialize()

            Me.UpdateEntityProperties()
            Me.EventWiring()

            m_isInitialized = True
        End Sub
#End Region

#Region "Overrides"

    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPrd.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtInvoiceCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtInvoiceDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpInvoiceDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCostCenterCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty
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
          Me.grbDetail.Enabled = False
        Else
          Me.grbDetail.Enabled = True
        End If
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        End If
      Next

      txtDocDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      dtpDocDate.Value = MinDateToNow(Date.Now)

    End Sub
    Private m_oldInvoiceCode As String = ""
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If Me.m_entity Is Nothing Then
        Return
      End If

      'txtCode.Text = Me.m_entity.Code

      txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
      ' Auto Gen Code
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      If Not Me.m_entity.Customer Is Nothing Then
        txtCustomerCode.Text = Me.m_entity.Customer.Code
        txtCustomerName.Text = Me.m_entity.Customer.Name
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

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
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
    Private toCCCodeChanged As Boolean = False
    Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcostcentercode"
          toCCCodeChanged = True
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
      End Select
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          'เพิ่ม AutoCode
          If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
            Me.m_entity.OnGlChanged()
          End If
          dirtyFlag = True
        Case "txtcreditprd"
          If IsNumeric(txtCreditPrd.Text) Then
            Me.m_entity.CreditPeriod = CInt(Me.txtCreditPrd.Text)
          End If
          dirtyFlag = True
        Case "txtamount"
          If IsNumeric(txtAmount.Text) Then
            Me.m_entity.Amount = CDec(Me.txtAmount.Text)
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = Me.txtNote.Text
          dirtyFlag = True

        Case "txtcustomercode"
          dirtyFlag = Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)

        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              Me.dtpDocDate.Value = MaxDtpDate(Me.m_entity.DocDate)
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
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
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
              Me.dtpDocDate.Value = MaxDtpDate(Me.m_entity.DocDate)
            End If
            dirtyFlag = True
          End If
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Me.m_entity.TaxType.Value = item.Id
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          UpdateAmount()
          dirtyFlag = True
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
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, AROpeningBalance)
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        UpdateEntityProperties()
      End Set
    End Property
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
      Me.txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
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
    Private Sub SetVatToOneDoc()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_entity.Vat.SetVatToOneDoc(txtInvoiceCode _
      , txtInvoiceDate _
      , dtpInvoiceDate)
      Me.m_isInitialized = flag
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
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Customer).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcustomercode", "txtcustomername"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Customer).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
                Dim entity As New Customer(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcustomercode", "txtcustomername"
                            Me.SetCustomerDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

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

        Private Sub SupplierDetailView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
            AddHandler Me.WorkbenchWindow.ViewContent.Saved, AddressOf EntitySaved
        End Sub

        Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)
            If Me.m_entity.Canceled Then
                Me.m_entity.CancelPerson = Me.SecurityService.CurrentUser
                Me.m_entity.CancelDate = Now
            Else
                Me.m_entity.CancelPerson = New User
                Me.m_entity.CancelDate = Date.MinValue
                Me.m_entity.LastEditor = Me.SecurityService.CurrentUser
                Me.m_entity.LastEditDate = Now
            End If
            SetStatus()
            CheckFormEnable()
        End Sub

#Region "Properties"

#End Region

#Region "Event of Button Controls"
        Private Sub btnCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomerDialog)
        End Sub

        Private Sub SetCustomerDialog(ByVal e As ISimpleEntity)
            Me.txtCustomerCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
        End Sub

        Private Sub btnCustomerEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Customer)
        End Sub

        ' Costcenter
        Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim myEntityPanelService As IEntityPanelService = _
                         CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(dummyCC, AddressOf SetCostCenterDialog)
        End Sub
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

#Region " AutoGenCode "
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
#End Region

        Private Sub grbDetail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbDetail.Enter

        End Sub

    Protected Overrides Sub Finalize()
      MyBase.Finalize()
    End Sub
  End Class
End Namespace

