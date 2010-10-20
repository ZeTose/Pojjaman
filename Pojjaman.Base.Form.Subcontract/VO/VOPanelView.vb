Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class VOPanelView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable, Commands.IPreviewable
    'Inherits UserControl

#Region " Windows Form Designer generated code "
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
    Friend WithEvents txtBeforeTax As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxAmount As System.Windows.Forms.Label
    Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAfterTax As System.Windows.Forms.Label
    Friend WithEvents txtAfterTax As System.Windows.Forms.TextBox
    Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents lblTaxType As System.Windows.Forms.Label
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxRate As System.Windows.Forms.Label
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnGetFromBOQ As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSCCode As System.Windows.Forms.Label
    Friend WithEvents txtSCCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowSCDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents lblSubcontractor As System.Windows.Forms.Label
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDiscountRate As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnBlankSubItem As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowWR As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRetention As System.Windows.Forms.TextBox
    Friend WithEvents txtAdvancePay As System.Windows.Forms.TextBox
    Friend WithEvents lblRetention As System.Windows.Forms.Label
    Friend WithEvents lblAdvancePay As System.Windows.Forms.Label
    Friend WithEvents chkClosed As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VOPanelView))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.lblBeforeTax = New System.Windows.Forms.Label()
      Me.txtBeforeTax = New System.Windows.Forms.TextBox()
      Me.lblTaxAmount = New System.Windows.Forms.Label()
      Me.txtTaxAmount = New System.Windows.Forms.TextBox()
      Me.lblAfterTax = New System.Windows.Forms.Label()
      Me.txtAfterTax = New System.Windows.Forms.TextBox()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.lblTaxRate = New System.Windows.Forms.Label()
      Me.lblSubcontractor = New System.Windows.Forms.Label()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtSCCode = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtRealGross = New System.Windows.Forms.TextBox()
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
      Me.txtDiscountRate = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.txtRetention = New System.Windows.Forms.TextBox()
      Me.txtAdvancePay = New System.Windows.Forms.TextBox()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblRetention = New System.Windows.Forms.Label()
      Me.lblAdvancePay = New System.Windows.Forms.Label()
      Me.ibtnShowWR = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkClosed = New System.Windows.Forms.CheckBox()
      Me.ibtnBlankSubItem = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSCCode = New System.Windows.Forms.Label()
      Me.ibtnShowSCDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnGetFromBOQ = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblPercent = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.ImageButton1 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowDrop = True
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 142)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 316)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 18)
      Me.lblCode.TabIndex = 11
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(352, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDate.TabIndex = 59
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(272, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(80, 18)
      Me.lblDocDate.TabIndex = 14
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGross.BackColor = System.Drawing.Color.Transparent
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(208, 464)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(80, 18)
      Me.lblGross.TabIndex = 50
      Me.lblGross.Text = "ยอดเงินรวม :"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGross
      '
      Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtGross.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(296, 464)
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(80, 21)
      Me.txtGross.TabIndex = 51
      Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(184, 512)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(112, 18)
      Me.lblBeforeTax.TabIndex = 53
      Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
      Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBeforeTax
      '
      Me.txtBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBeforeTax.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBeforeTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBeforeTax, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.txtBeforeTax.Location = New System.Drawing.Point(296, 512)
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(192, 21)
      Me.txtBeforeTax.TabIndex = 54
      Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(496, 488)
      Me.lblTaxAmount.Name = "lblTaxAmount"
      Me.lblTaxAmount.Size = New System.Drawing.Size(88, 18)
      Me.lblTaxAmount.TabIndex = 47
      Me.lblTaxAmount.Text = "ภาษีมูลค่าเพิ่ม :"
      Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTaxAmount
      '
      Me.txtTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.txtTaxAmount.Location = New System.Drawing.Point(584, 488)
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(80, 21)
      Me.txtTaxAmount.TabIndex = 57
      Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAfterTax
      '
      Me.lblAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAfterTax.BackColor = System.Drawing.Color.Transparent
      Me.lblAfterTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAfterTax.Location = New System.Drawing.Point(512, 512)
      Me.lblAfterTax.Name = "lblAfterTax"
      Me.lblAfterTax.Size = New System.Drawing.Size(72, 18)
      Me.lblAfterTax.TabIndex = 48
      Me.lblAfterTax.Text = "ยอดสุทธิ :"
      Me.lblAfterTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAfterTax
      '
      Me.txtAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAfterTax.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAfterTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAfterTax, "")
      Me.txtAfterTax.ForeColor = System.Drawing.Color.Blue
      Me.Validator.SetGotFocusBackColor(Me.txtAfterTax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAfterTax, System.Drawing.Color.Empty)
      Me.txtAfterTax.Location = New System.Drawing.Point(584, 512)
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(184, 21)
      Me.txtAfterTax.TabIndex = 58
      Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbTaxType
      '
      Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(584, 464)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(80, 21)
      Me.cmbTaxType.TabIndex = 43
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(504, 464)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(80, 18)
      Me.lblTaxType.TabIndex = 42
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTaxRate
      '
      Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(720, 464)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, True)
      Me.txtTaxRate.Size = New System.Drawing.Size(32, 21)
      Me.txtTaxRate.TabIndex = 45
      Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(656, 464)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
      Me.lblTaxRate.TabIndex = 44
      Me.lblTaxRate.Text = "อัตราภาษี :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSubcontractor
      '
      Me.lblSubcontractor.BackColor = System.Drawing.Color.Transparent
      Me.lblSubcontractor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubcontractor.Location = New System.Drawing.Point(8, 64)
      Me.lblSubcontractor.Name = "lblSubcontractor"
      Me.lblSubcontractor.Size = New System.Drawing.Size(88, 18)
      Me.lblSubcontractor.TabIndex = 20
      Me.lblSubcontractor.Text = "ผู้รับเหมา:"
      Me.lblSubcontractor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierCode
      '
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(96, 64)
      Me.txtSupplierCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.txtSupplierCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, False)
      Me.txtSupplierCode.Size = New System.Drawing.Size(77, 21)
      Me.txtSupplierCode.TabIndex = 4
      '
      'txtSupplierName
      '
      Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(174, 64)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(142, 21)
      Me.txtSupplierName.TabIndex = 24
      Me.txtSupplierName.TabStop = False
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark
      Me.lblStatus.Location = New System.Drawing.Point(248, 117)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(38, 13)
      Me.lblStatus.TabIndex = 38
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -13)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(352, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDate.TabIndex = 1
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(96, 88)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.txtCostCenterCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(77, 21)
      Me.txtCostCenterCode.TabIndex = 5
      '
      'txtSCCode
      '
      Me.Validator.SetDataType(Me.txtSCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSCCode, "")
      Me.txtSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSCCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.txtSCCode.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMinValue(Me.txtSCCode, "")
      Me.txtSCCode.Name = "txtSCCode"
      Me.Validator.SetRegularExpression(Me.txtSCCode, "")
      Me.Validator.SetRequired(Me.txtSCCode, True)
      Me.txtSCCode.Size = New System.Drawing.Size(128, 21)
      Me.txtSCCode.TabIndex = 334
      Me.txtSCCode.TabStop = False
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(174, 88)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(142, 21)
      Me.txtCostCenterName.TabIndex = 25
      Me.txtCostCenterName.TabStop = False
      '
      'txtRealGross
      '
      Me.txtRealGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.txtRealGross.Location = New System.Drawing.Point(400, 464)
      Me.Validator.SetMinValue(Me.txtRealGross, "")
      Me.txtRealGross.Name = "txtRealGross"
      Me.Validator.SetRegularExpression(Me.txtRealGross, "")
      Me.Validator.SetRequired(Me.txtRealGross, False)
      Me.txtRealGross.Size = New System.Drawing.Size(88, 21)
      Me.txtRealGross.TabIndex = 61
      Me.txtRealGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxAmount
      '
      Me.txtRealTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(688, 488)
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(80, 21)
      Me.txtRealTaxAmount.TabIndex = 63
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxBase
      '
      Me.txtRealTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(400, 488)
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(88, 21)
      Me.txtRealTaxBase.TabIndex = 339
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTaxBase
      '
      Me.txtTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.txtTaxBase.Location = New System.Drawing.Point(296, 488)
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(80, 21)
      Me.txtTaxBase.TabIndex = 338
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDiscountAmount
      '
      Me.txtDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.txtDiscountAmount.Location = New System.Drawing.Point(664, 86)
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtDiscountAmount.TabIndex = 61
      Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtDiscountAmount.Visible = False
      '
      'txtDiscountRate
      '
      Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDiscountRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.txtDiscountRate.Location = New System.Drawing.Point(560, 86)
      Me.Validator.SetMinValue(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Name = "txtDiscountRate"
      Me.txtDiscountRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
      Me.Validator.SetRequired(Me.txtDiscountRate, False)
      Me.txtDiscountRate.Size = New System.Drawing.Size(80, 21)
      Me.txtDiscountRate.TabIndex = 51
      Me.txtDiscountRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtDiscountRate.Visible = False
      '
      'txtNote
      '
      Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(16, 488)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(136, 48)
      Me.txtNote.TabIndex = 343
      Me.txtNote.WordWrap = False
      '
      'txtRetention
      '
      Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.txtRetention.Location = New System.Drawing.Point(385, 64)
      Me.Validator.SetMinValue(Me.txtRetention, "")
      Me.txtRetention.Name = "txtRetention"
      Me.Validator.SetRegularExpression(Me.txtRetention, "")
      Me.Validator.SetRequired(Me.txtRetention, False)
      Me.txtRetention.Size = New System.Drawing.Size(103, 21)
      Me.txtRetention.TabIndex = 348
      Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAdvancePay
      '
      Me.Validator.SetDataType(Me.txtAdvancePay, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvancePay, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvancePay, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvancePay, System.Drawing.Color.Empty)
      Me.txtAdvancePay.Location = New System.Drawing.Point(385, 88)
      Me.Validator.SetMinValue(Me.txtAdvancePay, "")
      Me.txtAdvancePay.Name = "txtAdvancePay"
      Me.Validator.SetRegularExpression(Me.txtAdvancePay, "")
      Me.Validator.SetRequired(Me.txtAdvancePay, False)
      Me.txtAdvancePay.Size = New System.Drawing.Size(103, 21)
      Me.txtAdvancePay.TabIndex = 349
      Me.txtAdvancePay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 117)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(144, 18)
      Me.lblItem.TabIndex = 33
      Me.lblItem.Text = "รายการเปลี่ยนแปลงงาน"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.txtRetention)
      Me.grbDetail.Controls.Add(Me.txtAdvancePay)
      Me.grbDetail.Controls.Add(Me.lblRetention)
      Me.grbDetail.Controls.Add(Me.lblAdvancePay)
      Me.grbDetail.Controls.Add(Me.ibtnShowWR)
      Me.grbDetail.Controls.Add(Me.btnApprove)
      Me.grbDetail.Controls.Add(Me.chkClosed)
      Me.grbDetail.Controls.Add(Me.ibtnBlankSubItem)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.txtRealTaxBase)
      Me.grbDetail.Controls.Add(Me.Label2)
      Me.grbDetail.Controls.Add(Me.txtTaxBase)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxBase)
      Me.grbDetail.Controls.Add(Me.lblSCCode)
      Me.grbDetail.Controls.Add(Me.txtSCCode)
      Me.grbDetail.Controls.Add(Me.ibtnShowSCDialog)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.txtRealGross)
      Me.grbDetail.Controls.Add(Me.ibtnResetGross)
      Me.grbDetail.Controls.Add(Me.txtRealTaxAmount)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.txtGross)
      Me.grbDetail.Controls.Add(Me.lblBeforeTax)
      Me.grbDetail.Controls.Add(Me.txtSupplierName)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblGross)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.txtBeforeTax)
      Me.grbDetail.Controls.Add(Me.lblTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtTaxAmount)
      Me.grbDetail.Controls.Add(Me.lblAfterTax)
      Me.grbDetail.Controls.Add(Me.txtAfterTax)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.cmbTaxType)
      Me.grbDetail.Controls.Add(Me.lblTaxType)
      Me.grbDetail.Controls.Add(Me.txtTaxRate)
      Me.grbDetail.Controls.Add(Me.lblTaxRate)
      Me.grbDetail.Controls.Add(Me.lblSubcontractor)
      Me.grbDetail.Controls.Add(Me.txtSupplierCode)
      Me.grbDetail.Controls.Add(Me.ibtnGetFromBOQ)
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.Controls.Add(Me.lblPercent)
      Me.grbDetail.Controls.Add(Me.txtDiscountAmount)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.txtDiscountRate)
      Me.grbDetail.Controls.Add(Me.ImageButton1)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(0, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(776, 544)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'lblRetention
      '
      Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetention.Location = New System.Drawing.Point(322, 64)
      Me.lblRetention.Name = "lblRetention"
      Me.lblRetention.Size = New System.Drawing.Size(56, 18)
      Me.lblRetention.TabIndex = 350
      Me.lblRetention.Text = "Retention:"
      Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAdvancePay
      '
      Me.lblAdvancePay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvancePay.Location = New System.Drawing.Point(322, 88)
      Me.lblAdvancePay.Name = "lblAdvancePay"
      Me.lblAdvancePay.Size = New System.Drawing.Size(56, 18)
      Me.lblAdvancePay.TabIndex = 351
      Me.lblAdvancePay.Text = "มัดจำ:"
      Me.lblAdvancePay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowWR
      '
      Me.ibtnShowWR.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowWR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnShowWR.Location = New System.Drawing.Point(650, 54)
      Me.ibtnShowWR.Name = "ibtnShowWR"
      Me.ibtnShowWR.Size = New System.Drawing.Size(48, 24)
      Me.ibtnShowWR.TabIndex = 347
      Me.ibtnShowWR.TabStop = False
      Me.ibtnShowWR.Text = "WR"
      Me.ibtnShowWR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ibtnShowWR.ThemedImage = CType(resources.GetObject("ibtnShowWR.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnShowWR, "WR")
      Me.ibtnShowWR.Visible = False
      '
      'btnApprove
      '
      Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApprove.ForeColor = System.Drawing.Color.Black
      Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnApprove.Location = New System.Drawing.Point(664, 113)
      Me.btnApprove.Name = "btnApprove"
      Me.btnApprove.Size = New System.Drawing.Size(104, 23)
      Me.btnApprove.TabIndex = 335
      Me.btnApprove.Text = "อนุมัติเอกสาร"
      Me.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnApprove.ThemedImage = CType(resources.GetObject("btnApprove.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkClosed
      '
      Me.chkClosed.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkClosed.Location = New System.Drawing.Point(480, 16)
      Me.chkClosed.Name = "chkClosed"
      Me.chkClosed.Size = New System.Drawing.Size(80, 21)
      Me.chkClosed.TabIndex = 346
      Me.chkClosed.Text = "ปิด VO"
      Me.chkClosed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnBlankSubItem
      '
      Me.ibtnBlankSubItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlankSubItem.Location = New System.Drawing.Point(186, 113)
      Me.ibtnBlankSubItem.Name = "ibtnBlankSubItem"
      Me.ibtnBlankSubItem.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlankSubItem.TabIndex = 345
      Me.ibtnBlankSubItem.TabStop = False
      Me.ibtnBlankSubItem.ThemedImage = CType(resources.GetObject("ibtnBlankSubItem.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(20, 463)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(88, 18)
      Me.lblNote.TabIndex = 344
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(161, 113)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 342
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.Location = New System.Drawing.Point(176, 488)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(112, 18)
      Me.Label2.TabIndex = 337
      Me.Label2.Text = "มูลค่าสินค้าบริการ :"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(376, 488)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 340
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSCCode
      '
      Me.lblSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSCCode.ForeColor = System.Drawing.Color.Black
      Me.lblSCCode.Location = New System.Drawing.Point(8, 40)
      Me.lblSCCode.Name = "lblSCCode"
      Me.lblSCCode.Size = New System.Drawing.Size(88, 18)
      Me.lblSCCode.TabIndex = 335
      Me.lblSCCode.Text = "เลขที่ SC:"
      Me.lblSCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowSCDialog
      '
      Me.ibtnShowSCDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowSCDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSCDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowSCDialog.Location = New System.Drawing.Point(224, 40)
      Me.ibtnShowSCDialog.Name = "ibtnShowSCDialog"
      Me.ibtnShowSCDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSCDialog.TabIndex = 336
      Me.ibtnShowSCDialog.TabStop = False
      Me.ibtnShowSCDialog.ThemedImage = CType(resources.GetObject("ibtnShowSCDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(96, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(128, 21)
      Me.cmbCode.TabIndex = 333
      '
      'ibtnResetGross
      '
      Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetGross.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetGross.Location = New System.Drawing.Point(376, 464)
      Me.ibtnResetGross.Name = "ibtnResetGross"
      Me.ibtnResetGross.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetGross.TabIndex = 64
      Me.ibtnResetGross.TabStop = False
      Me.ibtnResetGross.ThemedImage = CType(resources.GetObject("ibtnResetGross.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxAmount
      '
      Me.ibtnResetTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(664, 488)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 66
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCostCenter
      '
      Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCostCenter.Location = New System.Drawing.Point(8, 88)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(88, 18)
      Me.lblCostCenter.TabIndex = 21
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(224, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 12
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(211, 113)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 37
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
      '
      'ibtnGetFromBOQ
      '
      Me.ibtnGetFromBOQ.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnGetFromBOQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnGetFromBOQ.Location = New System.Drawing.Point(704, 54)
      Me.ibtnGetFromBOQ.Name = "ibtnGetFromBOQ"
      Me.ibtnGetFromBOQ.Size = New System.Drawing.Size(48, 24)
      Me.ibtnGetFromBOQ.TabIndex = 35
      Me.ibtnGetFromBOQ.TabStop = False
      Me.ibtnGetFromBOQ.Text = "BOQ"
      Me.ibtnGetFromBOQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ibtnGetFromBOQ.ThemedImage = CType(resources.GetObject("ibtnGetFromBOQ.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnGetFromBOQ, "BOQ")
      Me.ibtnGetFromBOQ.Visible = False
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(246, 16)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 13
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtnCopyMe.Visible = False
      '
      'lblPercent
      '
      Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(752, 464)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 46
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.Location = New System.Drawing.Point(472, 86)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(80, 18)
      Me.Label1.TabIndex = 50
      Me.Label1.Text = "ยอดลด :"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.Label1.Visible = False
      '
      'ImageButton1
      '
      Me.ImageButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ImageButton1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ImageButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ImageButton1.Location = New System.Drawing.Point(640, 86)
      Me.ImageButton1.Name = "ImageButton1"
      Me.ImageButton1.Size = New System.Drawing.Size(24, 20)
      Me.ImageButton1.TabIndex = 64
      Me.ImageButton1.TabStop = False
      Me.ImageButton1.ThemedImage = CType(resources.GetObject("ImageButton1.ThemedImage"), System.Drawing.Bitmap)
      Me.ImageButton1.Visible = False
      '
      'VOPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "VOPanelView"
      Me.Size = New System.Drawing.Size(784, 552)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
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

#Region "Members"
    Private m_entity As VO
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_enableState As Hashtable
    Private m_readOnlyState As Hashtable
    Private m_tableStyleEnable As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      '            Dim rs As ResourceService = CType(ServiceManager.Services.GetService(GetType(ResourceService)), ResourceService)
      '            Me.ibtnCopyMe.ThemedImage = rs.GetBitmap("Icons.16x16.Copy")

      SaveEnableState()

      Dim dt As TreeTable = VO.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf VOItemDelete


      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      m_readOnlyState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
        If TypeOf ctrl Is TextBox Then
          m_readOnlyState.Add(CType(ctrl, TextBox), CType(ctrl, TextBox).ReadOnly)
        End If
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
        If TypeOf ctrl Is TextBox Then
          m_readOnlyState.Add(CType(ctrl, TextBox), CType(ctrl, TextBox).ReadOnly)
        End If
      Next
    End Sub
#End Region

#Region "Style"
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "VO"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)


      'SC Items
      Dim voSciLineNumber As New TreeTextColumn
      voSciLineNumber.MappingName = "sci_linenumber"
      voSciLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.SciLineNumberHeaderText}")   '"No."
      voSciLineNumber.NullText = ""
      voSciLineNumber.Width = 30
      voSciLineNumber.DataAlignment = HorizontalAlignment.Center
      voSciLineNumber.ReadOnly = True
      voSciLineNumber.TextBox.Name = "sci_linenumber"

      Dim voSciItemName As New TreeTextColumn
      voSciItemName.MappingName = "sci_itemName"
      voSciItemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.SciSCItemNameHeaderText}")   '"รายการ sc"
      voSciItemName.NullText = ""
      voSciItemName.Width = 180
      'csCode.ReadOnly = True
      voSciItemName.TextBox.Name = "sci_itemName"

      Dim voEntity As DataGridComboColumn
      voEntity = New DataGridComboColumn("voi_entityType" _
      , CodeDescription.GetCodeList("sci_entitytype", "code_value not in (19)") _
      , "code_description", "code_value")
      voEntity.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.VoTypeHeaderText}")   '"ประเภท"
      voEntity.Width = 100
      voEntity.NullText = String.Empty

      Dim voVoiCode As New TreeTextColumn
      voVoiCode.MappingName = "voi_code"
      voVoiCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.SciCodeHeaderText}")   '"รหัส"
      voVoiCode.NullText = ""
      'csCode.ReadOnly = True
      voVoiCode.TextBox.Name = "voi_code"

      Dim voItemButton As New DataGridButtonColumn
      voItemButton.MappingName = "Button"
      voItemButton.HeaderText = ""
      voItemButton.NullText = ""

      'Dim voVoiItemName As New TreeTextColumn
      'voVoiItemName.MappingName = "voi_itemName"
      'voVoiItemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.SciItemNameHeaderText}")   '"รายการเปลี่ยนแปลง"
      'voVoiItemName.NullText = ""
      'voVoiItemName.Width = 180
      'voVoiItemName.TextBox.Name = "voi_itemName"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      Dim csBarrier As New DataGridBarrierColumn
      csBarrier.MappingName = "Barrier"
      csBarrier.HeaderText = ""
      csBarrier.NullText = ""
      csBarrier.ReadOnly = True

      Dim voLineNumber As New TreeTextColumn
      voLineNumber.MappingName = "voi_linenumber"
      voLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.LineNumberHeaderText}")   '"No."
      voLineNumber.NullText = ""
      voLineNumber.Width = 30
      voLineNumber.DataAlignment = HorizontalAlignment.Center
      voLineNumber.ReadOnly = True
      voLineNumber.TextBox.Name = "voi_linenumber"

      Dim voItemName As New TreeTextColumn
      voItemName.MappingName = "voi_itemName"
      voItemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.ItemNameHeaderText}")   '"รายการเปลี่ยนแปลง"
      voItemName.NullText = ""
      voItemName.Width = 180
      voItemName.TextBox.Name = "voi_itemName"

      Dim voUnit As New TreeTextColumn
      voUnit.MappingName = "voi_unitName"
      voUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.UnitHeaderText}")   '"หน่วย"
      voUnit.NullText = ""
      voUnit.TextBox.Name = "voi_unitName"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      voUnit.DataAlignment = HorizontalAlignment.Center

      Dim voUnitButton As New DataGridButtonColumn
      voUnitButton.MappingName = "UnitButton"
      voUnitButton.HeaderText = ""
      voUnitButton.NullText = ""
      AddHandler voUnitButton.Click, AddressOf ButtonClicked

      Dim voQty As New TreeTextColumn
      voQty.MappingName = "voi_qty"
      voQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.QtyHeaderText}")
      voQty.NullText = ""
      voQty.DataAlignment = HorizontalAlignment.Right
      voQty.Format = "#,###.##"
      voQty.TextBox.Name = "voi_qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      Dim voUnitPRice As New TreeTextColumn
      voUnitPRice.MappingName = "voi_unitprice"
      voUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.UnitpriceHeaderText}")   '"ราคาต่อหน่วย"
      voUnitPRice.NullText = ""
      voUnitPRice.DataAlignment = HorizontalAlignment.Right
      voUnitPRice.Format = "#,###.##"
      voUnitPRice.TextBox.Name = "voi_unitprice"

      Dim voAmount As New TreeTextColumn
      voAmount.MappingName = "amount"
      voAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.AmountHeaderText}")   '"จำนวนเงิน"
      voAmount.NullText = ""
      voAmount.DataAlignment = HorizontalAlignment.Right
      voAmount.Format = "#,###.##"
      voAmount.TextBox.Name = "amount"
      voAmount.ReadOnly = True
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim voMat As New TreeTextColumn
      voMat.MappingName = "voi_mat"
      voMat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.MatHeaderText}")   '"MAT"
      voMat.NullText = ""
      voMat.DataAlignment = HorizontalAlignment.Right
      voMat.Format = "#,###.##"
      voMat.TextBox.Name = "voi_mat"

      Dim voLab As New TreeTextColumn
      voLab.MappingName = "voi_lab"
      voLab.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.LabHeaderText}")   '"LAB"
      voLab.NullText = ""
      voLab.DataAlignment = HorizontalAlignment.Right
      voLab.Format = "#,###.##"
      voLab.TextBox.Name = "voi_lab"

      Dim voEq As New TreeTextColumn
      voEq.MappingName = "voi_eq"
      voEq.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.EqHeaderText}")   '"EQ"
      voEq.NullText = ""
      voEq.DataAlignment = HorizontalAlignment.Right
      voEq.Format = "#,###.##"
      voEq.TextBox.Name = "voi_eq"

      Dim voReceivedAmount As New TreeTextColumn
      voReceivedAmount.MappingName = "ReceivedAmount"
      voReceivedAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.ReceivedAmount}")   '"ReceivedAmount"
      voReceivedAmount.NullText = ""
      voReceivedAmount.DataAlignment = HorizontalAlignment.Right
      voReceivedAmount.Format = "#,###.##"
      voReceivedAmount.TextBox.Name = "ReceivedAmount"

      Dim voNote As New TreeTextColumn
      voNote.MappingName = "voi_note"
      voNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.NoteHeaderText}")   '"หมายเหตุ"
      voNote.NullText = ""
      voNote.Width = 180
      voNote.TextBox.Name = "voi_note"

      Dim voVatable As New DataGridCheckBoxColumn
      voVatable.MappingName = "voi_unvatable"
      voVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.UnVatableHeaderText}")   '"ยกเว้นภาษี"
      voVatable.Width = 100
      voVatable.InvisibleWhenUnspcified = True

      'dst.GridColumnStyles.Add(voSciItemName)
      dst.GridColumnStyles.Add(voEntity)
      'dst.GridColumnStyles.Add(voSciLineNumber)
      dst.GridColumnStyles.Add(voVoiCode)
      dst.GridColumnStyles.Add(voItemButton)
      dst.GridColumnStyles.Add(voItemName)
      'dst.GridColumnStyles.Add(csBarrier)

      'dst.GridColumnStyles.Add(voLineNumber)

      dst.GridColumnStyles.Add(voUnit)
      dst.GridColumnStyles.Add(voUnitButton)
      dst.GridColumnStyles.Add(voQty)
      dst.GridColumnStyles.Add(voUnitPRice)
      dst.GridColumnStyles.Add(voAmount)
      dst.GridColumnStyles.Add(csBarrier1)
      dst.GridColumnStyles.Add(voMat)
      dst.GridColumnStyles.Add(voLab)
      dst.GridColumnStyles.Add(voEq)
      dst.GridColumnStyles.Add(voReceivedAmount)
      dst.GridColumnStyles.Add(voNote)
      'dst.GridColumnStyles.Add(voVatable)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 2 Then
        Me.ItemButtonClick(e)
      Else
        Me.UnitButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentTagItem() As VOItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is VOItem Then
          Return Nothing
        End If
        Return CType(row.Tag, VOItem)
      End Get
    End Property
    Private ReadOnly Property CurrentRealTagItem() As VOItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow

        Try
          Dim lastIndex As Integer = row.Index
          Dim startIndex As Integer = row.Index

          For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
            If i > startIndex Then
              If CType(Me.m_treeManager.Treetable.Childs(i).Tag, VOItem).Level = 0 Then
                Exit For
              End If
              lastIndex = i
            End If
          Next

          Dim parentRow As TreeRow = Me.m_treeManager.Treetable.Childs(lastIndex)

          Return CType(parentRow.Tag, VOItem)
        Catch ex As Exception
          Return Nothing
        End Try

      End Get
    End Property
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
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
      Dim doc As VOItem = Me.m_entity.ItemCollection.CurrentItem

      'If tick checkbox that not in the current hilight row
      If e.Column.ColumnName.ToLower = "voi_unvatable" Then
        Me.m_treeManager.SelectedRow = e.Row
        doc = Me.m_entity.ItemCollection.CurrentItem
      End If

      If doc Is Nothing Then
        doc = New VOItem
        If Me.m_entity.ItemCollection.Count = 0 Then
          doc.ItemType = New SCIItemType(289)
        Else
          doc.ItemType = New SCIItemType(0)
          doc.Level = 1
        End If
        Me.m_entity.ItemCollection.Add(doc)
      End If
      If doc.RefSequence > 0 AndAlso doc.Level = 0 Then
        'ถ้าเป็นรายการที่ดึงมาจากเอกสาร sc ไม่ให้แก้ไข
        msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.CanNotChangeRefData}")
        Return
      End If
      Me.m_entity.ItemCollection.CurrentItem = doc
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "voi_code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "sci_itemname"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.EntityName = CStr(e.ProposedValue)
          Case "voi_itemname"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.EntityName = CStr(e.ProposedValue)
          Case "voi_unitname"
            'If doc.ItemType.Value = 289 Then
            '  Return
            'End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            doc.Unit = myUnit
            'Case "voi_originqty"
            '    If IsDBNull(e.ProposedValue) Then
            '        e.ProposedValue = ""
            '    End If
            '    Dim value As Decimal = 0
            '    If Not e.ProposedValue = "" Then
            '        If IsNumeric(e.ProposedValue) Then
            '            value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            '        End If
            '    End If
            '    doc.OriginQty = value
          Case "voi_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0     'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Qty = value
          Case "voi_entitytype"
            Dim value As SCIItemType
            If IsNumeric(e.ProposedValue) Then
              value = New SCIItemType(CInt(e.ProposedValue))
            End If
            doc.ItemType = value
          Case "voi_unitprice"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0     'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.UnitPrice = value
            'Case "voi_discrate"
            '    If IsDBNull(e.ProposedValue) Then
            '        e.ProposedValue = ""
            '    End If
            '    doc.Discount = New Discount(e.ProposedValue.ToString)
          Case "voi_mat"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Mat = value
          Case "voi_lab"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Lab = value
          Case "voi_eq"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Eq = value
          Case "voi_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
          Case "voi_unvatable"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = False
            End If
            doc.UnVatable = CBool(e.ProposedValue)

        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub VOItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "TreeTable Handlers"
    '        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '            If Not m_wbsdInitialized Then
    '                Return
    '            End If
    '            Dim index As Integer = Me.m_treeManager2.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
    '            If ValidateRow(CType(e.Row, TreeRow)) Then
    '                'UpdateAmount(e)
    '                Me.m_treeManager2.Treetable.AcceptChanges()
    '            End If
    '            RefreshWBS()
    '            Me.WorkbenchWindow.ViewContent.IsDirty = True
    '        End Sub
    '        Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
    '            Dim item As WBSDistribute = Me.CurrentWsbsd
    '            If item Is Nothing Then
    '                Return
    '            End If
    '            Dim view As Integer = 6
    '            Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
    '            If doc Is Nothing Then
    '                Return
    '            End If
    '            e.Row("Amount") = Configuration.FormatToString(item.Percent * doc.BeforeTax / 100, DigitConfig.Price)
    '            If Not item.IsMarkup Then
    '                e.Row("BudgetRemain") = Configuration.FormatToString(item.WBS.GetTotal - item.WBS.GetActualTotal(Me.m_entity, view) + Me.m_entity.GetCurrentAmountForWBS(item.WBS, doc.ItemType), DigitConfig.Price)
    '                e.Row("QtyRemain") = Configuration.FormatToString(0 - item.WBS.GetActualTotalQty(Me.m_entity, view) - 0, DigitConfig.Price)
    '            Else
    '                Dim mk As Markup = Me.m_entity.CostCenter.Boq.MarkupCollection.GetMarkupFromId(item.WBS.Id)
    '                If Not mk Is Nothing Then
    '                    e.Row("BudgetRemain") = Configuration.FormatToString(mk.TotalAmount - mk.GetActualTotal(Me.m_entity, view) - Me.m_entity.GetCurrentAmountForMarkup(mk), DigitConfig.Price)
    '                End If
    '            End If
    '        End Sub
    '        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '            If Not m_wbsdInitialized Then
    '                Return
    '            End If
    '            Try
    '                Select Case e.Column.ColumnName.ToLower
    '                    Case "wbs"
    '                        SetCode(e)
    '                    Case "percent"
    '                        SetPercent(e)
    '                End Select
    '                ValidateRow(e)
    '            Catch ex As Exception
    '                MessageBox.Show(ex.ToString)
    '            End Try
    '        End Sub
    '        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
    '            Dim wbs As Object = e.Row("wbs")
    '            Dim percent As Object = e.Row("percent")

    '            Select Case e.Column.ColumnName.ToLower
    '                Case "wbs"
    '                    wbs = e.ProposedValue
    '                Case "percent"
    '                    percent = e.ProposedValue
    '                Case Else
    '                    Return
    '            End Select

    '            Dim isBlankRow As Boolean = False
    '            If IsDBNull(wbs) Then
    '                isBlankRow = True
    '            End If

    '            If Not isBlankRow Then
    '                If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
    '                    e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
    '                Else
    '                    e.Row.SetColumnError("percent", "")
    '                End If
    '                If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
    '                    e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
    '                Else
    '                    e.Row.SetColumnError("wbs", "")
    '                End If
    '            End If

    '        End Sub
    '        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
    '            If row.IsNull("WBS") Then
    '                Return False
    '            End If
    '            Return True
    '        End Function
    '        Private m_updating As Boolean = False
    '        Public Sub SetPercent(ByVal e As DataColumnChangeEventArgs)
    '            If m_updating Then
    '                Return
    '            End If
    '            Dim item As WBSDistribute = Me.CurrentWsbsd
    '            If item Is Nothing Then
    '                Return
    '            End If
    '            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
    '                e.ProposedValue = ""
    '                Return
    '            End If
    '            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
    '            Dim value As Decimal = CDec(e.ProposedValue)
    '            Dim oldvalue As Decimal = 0
    '            If Not e.Row.IsNull(e.Column) Then
    '                oldvalue = CDec(e.Row(e.Column))
    '            End If
    '            Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
    '            If doc Is Nothing Then
    '                Return
    '            End If
    '            Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
    '            If wsdColl.GetSumPercent - oldvalue + value > 100 Then
    '                e.ProposedValue = e.Row(e.Column)
    '                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '                msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
    '                Return
    '            End If

    '            m_updating = True
    '            item.Percent = value
    '            m_updating = False
    '        End Sub

    '        'Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
    '        '    If e.Row.IsNull("stocki_entityType") Then
    '        '        Return False
    '        '    End If
    '        '    If IsDBNull(e.ProposedValue) Then
    '        '        Return False
    '        '    End If
    '        '    For Each row As TreeRow In Me.ItemTable.Childs
    '        '        If Not row Is e.Row Then
    '        '            If Not row.IsNull("stocki_entityType") Then
    '        '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
    '        '                    If Not row.IsNull("code") Then
    '        '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
    '        '                            Return True
    '        '                        End If
    '        '                    End If
    '        '                End If
    '        '            End If
    '        '        End If
    '        '    Next
    '        '    Return False
    '        'End Function
    '        Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
    '            'If m_updating Then
    '            '    Return
    '            'End If
    '            'm_updating = True
    '            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '            'If e.Row.IsNull("stocki_entityType") Then
    '            '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '            '    e.ProposedValue = e.Row(e.Column)
    '            '    m_updating = False
    '            '    Return
    '            'End If
    '            'If DupCode(e) Then
    '            '    Dim item As New GoodsReceiptItem
    '            '    item.CopyFromDataRow(CType(e.Row, TreeRow))
    '            '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
    '            '    e.ProposedValue = e.Row(e.Column)
    '            '    m_updating = False
    '            '    Return
    '            'End If
    '            'Select Case CInt(e.Row("stocki_entityType"))
    '            '    Case 0 'Blank
    '            '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
    '            '        e.ProposedValue = e.Row(e.Column)
    '            '        m_updating = False
    '            '        Return
    '            '    Case 28 'F/A
    '            '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
    '            '        e.ProposedValue = e.Row(e.Column)
    '            '        m_updating = False
    '            '        Return
    '            '    Case 19 'Tool
    '            '        If e.ProposedValue.ToString.Length = 0 Then
    '            '            If e.Row(e.Column).ToString.Length <> 0 Then
    '            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
    '            '                    ClearRow(e)
    '            '                Else
    '            '                    e.ProposedValue = e.Row(e.Column)
    '            '                End If
    '            '            End If
    '            '            m_updating = False
    '            '            Return
    '            '        End If
    '            '        Dim myTool As New Tool(e.ProposedValue.ToString)
    '            '        If Not myTool.Originated Then
    '            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
    '            '            e.ProposedValue = e.Row(e.Column)
    '            '            m_updating = False
    '            '            Return
    '            '        Else
    '            '            Dim myUnit As Unit = myTool.Unit
    '            '            e.Row("stocki_entity") = myTool.Id
    '            '            e.ProposedValue = myTool.Code
    '            '            e.Row("stocki_itemName") = myTool.Name
    '            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '            '                e.Row("stocki_unit") = myUnit.Id
    '            '                e.Row("Unit") = myUnit.Name
    '            '            Else
    '            '                e.Row("stocki_unit") = DBNull.Value
    '            '                e.Row("Unit") = DBNull.Value
    '            '            End If
    '            '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
    '            '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
    '            '                e.Row("stocki_acct") = ga.Account.Id
    '            '                e.Row("AccountCode") = ga.Account.Code
    '            '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '            '            Else
    '            '                e.Row("stocki_acct") = DBNull.Value
    '            '                e.Row("AccountCode") = DBNull.Value
    '            '                e.Row("Account") = DBNull.Value
    '            '            End If
    '            '        End If
    '            '    Case 42 'LCI
    '            '        If e.ProposedValue.ToString.Length = 0 Then
    '            '            If e.Row(e.Column).ToString.Length <> 0 Then
    '            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
    '            '                    ClearRow(e)
    '            '                Else
    '            '                    e.ProposedValue = e.Row(e.Column)
    '            '                End If
    '            '            End If
    '            '            m_updating = False
    '            '            Return
    '            '        End If
    '            '        Dim lci As New LCIItem(e.ProposedValue.ToString)
    '            '        If Not lci.Originated Then
    '            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
    '            '            e.ProposedValue = e.Row(e.Column)
    '            '            m_updating = False
    '            '            Return
    '            '        Else
    '            '            Dim myUnit As Unit = lci.DefaultUnit
    '            '            e.Row("stocki_entity") = lci.Id
    '            '            e.ProposedValue = lci.Code
    '            '            e.Row("stocki_itemName") = lci.Name
    '            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '            '                e.Row("stocki_unit") = myUnit.Id
    '            '                e.Row("Unit") = myUnit.Name
    '            '            Else
    '            '                e.Row("stocki_unit") = DBNull.Value
    '            '                e.Row("Unit") = DBNull.Value
    '            '            End If
    '            '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
    '            '                e.Row("stocki_acct") = lci.Account.Id
    '            '                e.Row("AccountCode") = lci.Account.Code
    '            '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '            '            Else
    '            '                e.Row("stocki_acct") = DBNull.Value
    '            '                e.Row("AccountCode") = DBNull.Value
    '            '                e.Row("Account") = DBNull.Value
    '            '            End If
    '            '        End If
    '            '    Case Else
    '            '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '            '        e.ProposedValue = e.Row(e.Column)
    '            '        m_updating = False
    '            '        Return
    '            'End Select
    '            'e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
    '            'm_updating = False
    '        End Sub
    '        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    '        End Sub
#End Region

#Region "CheckPJMModule"
    Private m_ApproveDocModule As New PJMModule("approvedoc")
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      'ถ้าไม่เปิดอนุมัติเอกสาร ให้ซ่อนปุ่ม
      If Not CBool(Configuration.GetConfig("ApproveSC")) Then
        Me.btnApprove.Visible = False
      Else
        Me.btnApprove.Visible = True
      End If

      'จากการอนุมัติเอกสาร
      If CBool(Configuration.GetConfig("ApproveSC")) Then
        'ถ้าใช้การอนุมัติแบบใหม่ PJMModule
        If m_ApproveDocModule.Activated Then
          'Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
          'Dim ApprovalDocLevelColl As New ApprovalDocLevelCollection(mySService.CurrentUser) 'ระดับสิทธิแต่ละผู้ใช้
          Dim ApproveDocColl As New ApproveDocCollection(Me.m_entity) 'ระดับสิทธิที่ได้ทำการ approve
          If ApproveDocColl.MaxLevel > 0 Then
            '(ApprovalDocLevelColl.GetItem(m_entity.EntityId).Level < ApproveDocColl.MaxLevel) OrElse _
            '(Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id) Then
            For Each ctrl As Control In grbDetail.Controls
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso Not ctrl.Name = "chkClosed" Then
                If TypeOf ctrl Is TextBox Then
                  CType(ctrl, TextBox).ReadOnly = True
                Else
                  ctrl.Enabled = False
                End If
              End If
            Next
            tgItem.Enabled = True
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = True
            Next
            Me.btnApprove.Enabled = True
            Return
          Else
            For Each ctrl As Control In grbDetail.Controls
              If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).ReadOnly = CBool(m_readOnlyState(ctrl))
              Else
                ctrl.Enabled = CBool(m_enableState(ctrl))
              End If
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If
        Else
          'ถ้าใช้การอนุมัติแบบเก่า
          If Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then
            For Each ctrl As Control In grbDetail.Controls
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso Not ctrl.Name = "chkClosed" Then
                If TypeOf ctrl Is TextBox Then
                  CType(ctrl, TextBox).ReadOnly = True
                Else
                  ctrl.Enabled = False
                End If
              End If
            Next
            tgItem.Enabled = True
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = True
            Next
            Me.btnApprove.Enabled = True
            Return
          Else
            For Each ctrl As Control In grbDetail.Controls
              If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).ReadOnly = CBool(m_readOnlyState(ctrl))
              Else
                ctrl.Enabled = CBool(m_enableState(ctrl))
              End If
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If
        End If
      End If

      ''จาก Status ของเอกสารเอง
      If Me.m_entity.Status.Value = 0 OrElse m_entityRefed = 1 OrElse Me.m_entity.Closed Then
        For Each ctrl As Control In grbDetail.Controls
          If Not ctrl.Name = "chkClosed" Then
            ctrl.Enabled = False
          ElseIf ctrl.Name = "chkClosed" Then
            If Me.m_entity.Status.Value = 0 Then
              chkClosed.Enabled = False
            End If
          End If
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In grbDetail.Controls
          If TypeOf ctrl Is TextBox Then
            CType(ctrl, TextBox).ReadOnly = CBool(m_readOnlyState(ctrl))
          Else
            ctrl.Enabled = CBool(m_enableState(ctrl))
          End If
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If

      ''Me.chkClosed.Enabled = True
      Me.ibtnCopyMe.Enabled = True
      Me.btnApprove.Enabled = True
      ''CheckWBSRight()
    End Sub

    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each ctrl As Control In Me.Controls
        If ctrl.Name.StartsWith("txt") Then
          ctrl.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
      If cmbTaxType.Items.Count >= 1 Then
        cmbTaxType.SelectedIndex = 1
      End If
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblCode}")   '"รหัส"
      Me.lblSCCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblSCCode}")   '"เลขที่ SC"
      Me.lblSubcontractor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblSubcontractor}")   '"ผู้รับเหมา"
      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblCostCenter}")   '"Cost Center"
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")

      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblCode}")
      'Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Global.SubContractText}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblCode}")
      Me.Validator.SetDisplayName(Me.txtSCCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))
      Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblRetention}")

      '            Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblGross}")

      '            'Me.lblReceivingDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblReceivingDate}")
      '            'Me.Validator.SetDisplayName(Me.txtReceivingDate, StringHelper.GetRidOfAtEnd(Me.lblReceivingDate.Text, ":"))

      '            ' Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblDiscountAmount}")
      '            Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblBeforeTax}")
      '            Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblTaxAmount}")
      '            Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblAfterTax}")
      '            Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblTaxType}")
      '            Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblTaxRate}")


      '            Me.Validator.SetDisplayName(Me.txtSupplierCode, StringHelper.GetRidOfAtEnd(Me.lblSupplier.Text, ":"))

      '            'Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Global.DueDate}")
      '            'Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblCreditPrd}")

      '            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.grbDetail}")
      '            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblItem}")
      '            'Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")
      '            Me.lblPercent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblPercent}")
      '            Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblTaxBase}")


      '            '    Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblRequestor}")

      '            'Me.grbRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.grbRetention}")
      '            'Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblRetention}")
      '            'Me.lblRetentionNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.lblRetentionNote}")

      '            'Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.btnApprove}")

      '            'Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.chkClosed}")
      '            'ไปกำหนดข้างล่าง
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtSCCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSCCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty   'Todo: .... จะแก้ได้หรือปล่าว
      AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCostCenterCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtRetention.Validated, AddressOf Me.TextHandler

      AddHandler txtAdvancePay.Validated, AddressOf Me.TextHandler


      '            ' AddHandler txtRequestorCode.Validated, AddressOf Me.ChangeProperty
      '            ' AddHandler txtRequestorCode.TextChanged, AddressOf Me.TextHandler

      'AddHandler txtRetentionNote.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtRetention.Validated, AddressOf Me.TextHandler
      'AddHandler txtRetention.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealGross.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealGross.Validated, AddressOf Me.TextHandler
    End Sub
    '        Private requestorCodeChanged As Boolean = False
    'Private pOCodeChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        '                Case "txtrequestorcode"
        '                    requestorCodeChanged = True
        'Case "txtcostcentercode"
        '    toCCCodeChanged = True
        Case "txtsccode"
          scCodeChanged = True
          'Case "txtretention"
          '            'Dim txt As String = Me.txtRetention.Text
          '            'txt = txt.Replace(",", "")
          '                    '            'If txt.Length = 0 Then
          '                    '            Me.m_entity.Retention = 0
          '                    '  Else
          '                    '    Try
          '                    '      Me.m_entity.Retention = Math.Min(CDec(TextParser.Evaluate(txt)), Me.m_entity.AfterTax)
          '                    '    Catch ex As Exception
          '                    '      Me.m_entity.Retention = 0
          '                    '    End Try
          '                    '  End If
          '                    '  Me.txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)
          'Case "txtrealtaxbase"
          '  Dim txt As String = Me.txtRealTaxBase.Text
          '  txt = txt.Replace(",", "")
          '  If txt.Length = 0 Then
          '    Me.m_entity.RealTaxBase = 0
          '  Else
          '    Try
          '      Me.m_entity.RealTaxBase = CDec(TextParser.Evaluate(txt))
          '    Catch ex As Exception
          '      Me.m_entity.RealTaxBase = 0
          '    End Try
          '  End If
          '  UpdateAmount(True)
        Case "txtrealgross"
          Dim txt As String = Me.txtRealGross.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealGross = 0
          Else
            Try
              Me.m_entity.RealGross = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.RealGross = 0
            End Try
          End If
        Case "txtretention"
          If IsNumeric(txtRetention.Text) Then
            dirtyFlag = True
            m_entity.Retention = txtRetention.Text
            txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)
          Else
            txtRetention.Text = Configuration.FormatToString(0, DigitConfig.Price)
          End If
          Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
        Case "txtadvancepay"
          If IsNumeric(txtAdvancePay.Text) Then
            dirtyFlag = True
            m_entity.AdvancePay = txtAdvancePay.Text
            txtAdvancePay.Text = Configuration.FormatToString(m_entity.AdvancePay, DigitConfig.Price)
          Else
            txtAdvancePay.Text = Configuration.FormatToString(0, DigitConfig.Price)
          End If
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          UpdateAmount(True)
          'Case "txtrealtaxamount"
          '  Dim txt As String = Me.txtRealTaxAmount.Text
          '  txt = txt.Replace(",", "")
          '  If txt.Length = 0 Then
          '    Me.m_entity.RealTaxAmount = 0
          '  Else
          '    Try
          '      Me.m_entity.RealTaxAmount = CDec(TextParser.Evaluate(txt))
          '    Catch ex As Exception
          '      Me.m_entity.RealTaxAmount = 0
          '    End Try
          '  End If
          '  UpdateAmount(True)
      End Select
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      cmbCode.Items.Clear()
      cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_entity.Code
      '            'txtCreditPrd.Text = m_entity.CreditPeriod.ToString
      Me.m_oldCode = Me.m_entity.Code
      'oldCCId = Me.m_entity.CostCenter.Id
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      Me.chkClosed.Checked = Me.m_entity.Closed

      If Me.m_entity.Closed Then
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.chkClosedCancel}")
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.chkClosed}")
      End If

      'Me.SetColumnOriginQty()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtSCCode.Text = m_entity.SC.Code

      txtSupplierCode.Text = m_entity.SC.SubContractor.Code
      txtSupplierName.Text = m_entity.SC.SubContractor.Name

      txtCostCenterCode.Text = m_entity.SC.CostCenter.Code
      txtCostCenterName.Text = m_entity.SC.CostCenter.Name

      txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)
      txtAdvancePay.Text = Configuration.FormatToString(m_entity.AdvancePay, DigitConfig.Price)

      txtNote.Text = m_entity.Note

      '            'txtRequestorCode.Text = m_entity.Requestor.Code
      '            'txtRequestorName.Text = m_entity.Requestor.Name

      '            ' txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)
      '            ' txtRetentionNote.Text = m_entity.RetentionNote

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next

      RefreshDocs()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    '        Private Sub SetColumnOriginQty()
    '            For Each colStyle As DataGridColumnStyle In Me.tgItem.TableStyles(0).GridColumnStyles
    '                If colStyle.MappingName.ToLower = "poi_originqty" Then
    '                    If Not Me.m_entity.Closed Then
    '                        colStyle.Width = 0
    '                    Else
    '                        colStyle.Width = 80
    '                    End If
    '                End If
    '            Next
    'End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable, tgItem)
      'RefreshBlankGrid()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount(True)
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Or e.Name = "QtyChanged" Then
        If e.Name = "QtyChanged" Then
          Me.UpdateAmount(True)
        End If
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    'Private toCCCodeChanged As Boolean = False
    Private scCodeChanged As Boolean = False
    '        Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    '        Private CCCodeBlankFlag As Boolean = False
    '        Private Sub SetCCCodeBlankFlag()
    '            If Me.txtCostCenterCode.Text.Length = 0 Then
    '                CCCodeBlankFlag = True
    '            Else
    '                CCCodeBlankFlag = False
    '            End If
    '        End Sub
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
        Case "txtrealgross"
          dirtyFlag = True
        Case "cmbcode"
          If m_entity.AutoGen Then
            'เพิ่ม AutoCode
            If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
              Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
              Me.m_entity.Code = m_entity.AutoCodeFormat.Format
            End If
          Else
            Me.m_entity.Code = cmbCode.Text
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
          'Case "txtsuppliercode"
          '    If Me.m_entity.VO Is Nothing Then
          '        Me.m_entity.VO = New SC
          '    End If
          '    If Me.m_entity.VO.Supplier Is Nothing Then
          '        Me.m_entity.VO.Supplier = New Supplier
          '    End If
          '    dirtyFlag = Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.VO.Supplier, True)
          '    m_isInitialized = False
          '    'Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
          '    'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
          '    m_isInitialized = True
        Case "dtpdocdate"
          If Not m_dateSetting Then
            If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
              ' Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              dirtyFlag = True
            End If
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtsccode"
          If scCodeChanged Then
            If Me.m_entity.SC Is Nothing Then
              Me.m_entity.SC = New SC
            End If
            'Dim txtName As TextBox
            'm_isInitialized = False
            If Me.txtSCCode.Text.Length > 0 Then
              dirtyFlag = SC.GetSC(txtSCCode, Me.m_entity.SC)
            Else
              If Me.m_entity.SC.Code.Length > 0 Then
                dirtyFlag = True
              End If
              Me.m_entity.SC = New SC
            End If

            'm_isInitialized = True
            Me.UpdateEntityProperties()
          End If
          scCodeChanged = False

          '                Case "dtpreceivingdate"
          '                    'If Not Me.m_entity.ReceivingDate.Equals(dtpReceivingDate.Value) Then
          '                    '  If Not m_dateSetting Then
          '                    '                  ' Me.txtReceivingDate.Text = MinDateToNull(dtpReceivingDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '                    '    Me.m_entity.ReceivingDate = dtpReceivingDate.Value
          '                    '  End If
          '                    '  dirtyFlag = True
          '                    '            'End If
          '                    'Case "txtreceivingdate"
          '                    '  m_dateSetting = True
          '                    '            'If Not Me.txtReceivingDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceivingDate) = "" Then
          '                    '            '  Dim theDate As Date = CDate(Me.txtReceivingDate.Text)
          '                    '            '  If Not Me.m_entity.ReceivingDate.Equals(theDate) Then
          '                    '            '    dtpReceivingDate.Value = theDate
          '                    '            '    Me.m_entity.ReceivingDate = dtpReceivingDate.Value
          '                    '            '    dirtyFlag = True
          '                    '            '  End If
          '                    '            'Else
          '                    '            '  Me.dtpReceivingDate.Value = Date.Now
          '                    '            '  Me.m_entity.ReceivingDate = Date.MinValue
          '                    '            '  dirtyFlag = True
          '                    '            'End If
          '                    '  m_dateSetting = False
          '                    'Case "txtcreditprd"
          '                    '  If IsNumeric(txtCreditPrd.Text) Then
          '                    '    Me.m_entity.CreditPeriod = CInt(txtCreditPrd.Text)
          '                    '    Me.dtpDueDate.Value = Me.m_entity.DueDate
          '                    '  End If
          '                    '  dirtyFlag = True
          '                    'Case "txtretentionnote"
          '                    '  Me.m_entity.RetentionNote = txtRetentionNote.Text
          '                    '  dirtyFlag = True
          '                Case "txtretention"
          '                    dirtyFlag = True
        Case "txttaxbase"
          'Todo
          '                    'Case "txtdiscountrate"
          '                    '    Me.m_entity.Discount.Rate = txtDiscountRate.Text
          '                    '    forceUpdateTaxBase = True
          '                    '    forceUpdateTaxAmount = True
          '                    '    forceUpdateGross = True
          '                    '    UpdateAmount(True)
          '                    '    dirtyFlag = True
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Dim newTaxType As New TaxType(item.Id)
          'Me.m_entity.TaxType.Value = item.Id
          Me.m_entity.TaxType = newTaxType
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount(True)
          dirtyFlag = True
          'Case "txtrequestorcode"
          '    If requestorCodeChanged Then
          '        dirtyFlag = Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_entity.Requestor)
          '        requestorCodeChanged = False
          '    End If
          'Case "txtcostcentercode"
          '                    If toCCCodeChanged Then
          '                        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          '                        If Not CCCodeBlankFlag Then
          '                            If Me.txtCostCenterCode.Text.ToLower <> Me.m_entity.CostCenter.Code.ToLower Then
          '                                If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
          '                                    If Me.txtCostCenterCode.TextLength <> 0 Then
          '                                        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          '                                        If dirtyFlag Then
          '                                            UpdateDestAdmin()
          '                                        End If
          '                                    Else
          '                                        Me.m_entity.CostCenter = New CostCenter
          '                                        txtCostCenterName.Text = ""
          '                                    End If
          '                                    Try
          '                                        If oldCCId <> Me.m_entity.CostCenter.Id Then
          '                                            Me.WorkbenchWindow.ViewContent.IsDirty = True
          '                                            oldCCId = Me.m_entity.CostCenter.Id
          '                                            ChangeCC()
          '                                        End If
          '                                    Catch ex As Exception

          '                                    End Try
          '                                    toCCCodeChanged = False
          '                                Else
          '                                    Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
          '                                    toCCCodeChanged = False
          '                                End If
          '                            End If
          '                        Else
          '                            If Me.txtCostCenterCode.TextLength <> 0 Then
          '                                dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          '                                If dirtyFlag Then
          '                                    'If Me.txtRequestorName.TextLength = 0 Then
          '                                    '    UpdateDestAdmin()
          '                                    'End If
          '                                End If
          '                            Else
          '                                Me.m_entity.CostCenter = New CostCenter
          '                                txtCostCenterName.Text = ""
          '                            End If
          '                            Try
          '                                If oldCCId <> Me.m_entity.CostCenter.Id Then
          '                                    Me.WorkbenchWindow.ViewContent.IsDirty = True
          '                                    oldCCId = Me.m_entity.CostCenter.Id
          '                                    ChangeCC()
          '                                End If
          '                            Catch ex As Exception

          '                            End Try
          '                            toCCCodeChanged = False
          '                        End If
          '                    End If
          '                    If toCCCodeChanged Then
          '                        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          '                        'If Me.txtRequestorName.TextLength = 0 Then
          '                        '    UpdateDestAdmin()
          '                        'End If
          '                        toCCCodeChanged = False
          '                    End If
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
      '            SetCCCodeBlankFlag()
    End Sub
    Private Sub ibtnResetGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetGross.Click
      If Me.m_entity.RealGross <> Me.m_entity.Gross Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealGross = Me.m_entity.Gross
      UpdateAmount(True)
    End Sub
    Private Sub ibtnResetTaxBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxBase.Click
      If Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
      UpdateAmount(True)
    End Sub
    Private Sub ibtnResetTaxAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxAmount.Click
      If Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
      UpdateAmount(True)
    End Sub
    Private forceUpdateTaxBase As Boolean = False
    Private forceUpdateGross As Boolean = False
    Private forceUpdateTaxAmount As Boolean = False
    Private Sub UpdateAmount(ByVal refresh As Boolean)
      m_isInitialized = False
      If refresh Then
        Me.m_entity.RefreshTaxBase()
      End If

      'HACK: forceUpdateGross ต้องอยู่อันแรกนะจ๊ะ
      If forceUpdateGross OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
        Me.m_entity.RealGross = Me.m_entity.Gross
        forceUpdateGross = False
      End If
      If forceUpdateTaxBase OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
        Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
        forceUpdateTaxBase = False
      End If
      If forceUpdateTaxAmount OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount) Then
        Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
        forceUpdateTaxAmount = False
      End If

      txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
      ' txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
      txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
      txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
      txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
      ' txtDiscountRate.Text = m_entity.Discount.Rate
      txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
      txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)

      txtRealGross.Text = Configuration.FormatToString(m_entity.RealGross, DigitConfig.Price)
      txtRealTaxAmount.Text = Configuration.FormatToString(m_entity.RealTaxAmount, DigitConfig.Price)
      txtRealTaxBase.Text = Configuration.FormatToString(m_entity.RealTaxBase, DigitConfig.Price)

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next

      m_isInitialized = True
      '            RefreshWBS()
    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, VO)
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
      SetTaxTypeComboBox()
    End Sub
    ' 
    Private Sub SetTaxTypeComboBox()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
      If cmbTaxType.Items.Count > 0 Then
        'cmbTaxType.Items.RemoveAt(1)
        Dim index As Object = Configuration.GetConfig("CompanyTaxType")
        cmbTaxType.SelectedIndex = CInt(index)
      End If
    End Sub
#End Region

#Region "Event Handler"
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      'If tgItem.CurrentRowIndex <> currentY Then
      Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
      Me.m_entity.ItemCollection.CurrentRealItem = Me.CurrentRealTagItem
      'RefreshWBS()
      'currentY = tgItem.CurrentRowIndex
      'End If
    End Sub

    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList
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
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As VOItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
        'doc = New VOItem
        'doc.ItemType = New SCIItemType(0)
        'Me.m_entity.ItemCollection.Add(doc)
        'Me.m_entity.ItemCollection.CurrentItem = doc
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
      Me.m_treeManager.SelectedRow("voi_unitName") = unit.Code
    End Sub
    Private m_targetType As Integer
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As VOItem = Me.m_entity.ItemCollection.CurrentItem
      m_targetType = -1
      If doc Is Nothing Then
        Return
        'doc = New VOItem
        'doc.ItemType = New SCIItemType(0)
        'Me.m_entity.ItemCollection.Add(doc)
        'Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      If doc.ItemType.Value = 19 Or doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
        m_targetType = doc.ItemType.Value
        Dim entities(2) As ISimpleEntity
        entities(0) = New LCIItem
        entities(1) = New LCIForList
        entities(2) = New Tool
        Dim activeIndex As Integer = -1
        If Not doc.ItemType Is Nothing Then
          If doc.ItemType.Value = 19 Then
            activeIndex = 1
          Else 'If doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
            activeIndex = 0
          End If
        End If
        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, activeIndex)
      End If
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items, m_targetType)
      'Me.txtReceivingDate.Text = Me.m_entity.ReceivingDate.ToShortDateString
      tgItem.CurrentRowIndex = index
      'Dim cc As CostCenter = Me.m_entity.GetCCFromPR
      'If Not cc Is Nothing AndAlso cc.Id <> Me.m_entity.CostCenter.Id Then
      '    Me.SetCostCenterDialog(cc)
      'End If
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      dirtyFlag = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      'Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As VOItem = Me.m_entity.ItemCollection.CurrentRealItem
      If doc Is Nothing Then
        Return
      End If
      'If Not doc.SCItem Is Nothing Then
      '    Return
      'End If
      'Dim newItem As New BlankItem("")
      Dim theItem As New VOItem
      'theItem.Entity = newItem
      theItem.Level = 0
      theItem.ItemType = New SCIItemType(289)
      theItem.Qty = 0
      Dim index As Integer = Me.m_entity.ItemCollection.IndexOf(doc)
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index + 1
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnBlankSubItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlankSubItem.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As VOItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      'If Not doc.SCItem Is Nothing Then
      '    Return
      'End If
      Dim newItem As New BlankItem("")
      Dim theItem As New VOItem
      theItem.Level = 1
      theItem.Entity = newItem
      theItem.ItemType = New SCIItemType(0)
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index + 1
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim doc As VOItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      'If Not Me.m_entity.ItemCollection.Contains(doc) Then
      '  Return
      'End If

      Dim arrList As New ArrayList
      Dim index As Integer = tgItem.CurrentRowIndex

      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing Then
          Dim row As TreeRow = CType(Obj, TreeRow)
          If Not row Is Nothing Then
            index = row.Index
            For Each childRow As TreeRow In row.Childs
              If Not arrList.Contains(childRow) Then
                arrList.Add(childRow)
              End If
            Next
            If Not arrList.Contains(row) Then
              arrList.Add(row)
            End If
          End If
        End If
      Next

      For Each row As TreeRow In arrList
        If Not row Is Nothing AndAlso TypeOf row.Tag Is VOItem Then
          Dim itm As VOItem = CType(row.Tag, VOItem)
          If Not itm Is Nothing Then
            If Me.m_entity.ItemCollection.Contains(itm) Then
              Me.m_entity.ItemCollection.Remove(itm)
              Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
          End If
        End If
      Next

      ''Me.m_entity.ItemCollection.Remove(doc)

      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim isSetIndex As Boolean = False

      'Dim hashParent As New Hashtable

      'Dim rowIndex As Integer = 0
      'Dim key As String = ""

      'For Each Obj As Object In Me.m_treeManager.SelectedRows
      '  If Not Obj Is Nothing Then
      '    Dim row As TreeRow = CType(Obj, TreeRow)
      '    If Not row Is Nothing Then
      '      If Not isSetIndex Then
      '        index = row.Index
      '        isSetIndex = True
      '      End If
      '      Dim sitem As VOItem = CType(row.Tag, VOItem)
      '      If sitem.Level = 0 Then
      '        rowIndex += 1
      '        key = rowIndex.ToString
      '        hashParent.Add(key, sitem)

      '        Dim startIndex As Integer = row.Index
      '        Dim lastIndex As Integer = row.Index
      '        For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
      '          If i > startIndex Then
      '            Dim sitem2 As VOItem = Me.m_entity.ItemCollection(i)
      '            If sitem2.Level = 0 Then
      '              Exit For
      '            End If
      '            rowIndex += 1
      '            key = rowIndex.ToString
      '            hashParent.Add(key, sitem2)
      '          End If
      '        Next
      '      Else
      '        rowIndex += 1
      '        key = rowIndex.ToString
      '        hashParent.Add(key, sitem)
      '      End If
      '    End If
      '  End If
      'Next

      'For i As Integer = 1 To hashParent.Count
      '  key = CStr(i)
      '  Dim sitem As VOItem = CType(hashParent(key), VOItem)
      '  If Not sitem Is Nothing Then
      '    If Me.m_entity.ItemCollection.Contains(sitem) Then
      '      Me.m_entity.ItemCollection.Remove(sitem)
      '      Me.WorkbenchWindow.ViewContent.IsDirty = True
      '    End If
      '  End If
      'Next

      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()


      If index > 0 Then
        If Me.m_entity.ItemCollection.Count = 0 Then
          tgItem.CurrentRowIndex = 0
        Else
          If index > Me.m_entity.ItemCollection.Count Then
            tgItem.CurrentRowIndex = Me.m_entity.ItemCollection.Count - 1
          Else
            tgItem.CurrentRowIndex = index - 1
          End If
        End If
      Else
        tgItem.CurrentRowIndex = 0
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

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New PO).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    '        ' Requestor
    '        Private Sub btnRequestorEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '            myEntityPanelService.OpenPanel(dummyEmployee)
    '        End Sub
    '        'Private Sub btnRequestorFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    Dim myEntityPanelService As IEntityPanelService = _
    '        '    CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '        '    myEntityPanelService.OpenListDialog(dummyEmployee, AddressOf SetEmployeeDialog)
    '        'End Sub

    '        'Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
    '        '    Me.txtRequestorCode.Text = e.Code
    '        '    Me.WorkbenchWindow.ViewContent.IsDirty = _
    '        '        Me.WorkbenchWindow.ViewContent.IsDirty _
    '        '        Or Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_entity.Requestor)
    '        'End Sub
    '        ' Costcenter
    '        Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
    '            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '            Dim myEntityPanelService As IEntityPanelService = _
    '                        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '            myEntityPanelService.OpenTreeDialog(dummyCC, AddressOf SetCostCenterDialog)
    '        End Sub
    '        Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
    '            If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
    '                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '                If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
    '                    'If Me.txtCostCenterCode.TextLength = 0 Then
    '                    '    Me.m_entity.CostCenter = New CostCenter
    '                    'End If
    '                    Me.txtCostCenterCode.Text = e.Code
    '                    dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    '                    If dirtyFlag Then
    '                        UpdateDestAdmin()
    '                    End If
    '                    Try
    '                        If oldCCId <> Me.m_entity.CostCenter.Id Then
    '                            Me.WorkbenchWindow.ViewContent.IsDirty = True
    '                            oldCCId = Me.m_entity.CostCenter.Id
    '                            ChangeCC()
    '                        End If
    '                    Catch ex As Exception
    '                    End Try
    '                    toCCCodeChanged = False
    '                Else
    '                    Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
    '                    toCCCodeChanged = False
    '                End If
    '            ElseIf Me.txtCostCenterCode.Text.Length = 0 Then
    '                Me.txtCostCenterCode.Text = e.Code
    '                Me.WorkbenchWindow.ViewContent.IsDirty = True
    '                dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    '                If dirtyFlag Then
    '                    UpdateDestAdmin()
    '                End If
    '            End If
    '            SetCCCodeBlankFlag()
    '        End Sub
    '        Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
    '            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '            myEntityPanelService.OpenPanel(dummyCC)
    '        End Sub
    '        Private Sub ChangeCC()
    '            'For Each item As POItem In Me.m_entity.ItemCollection
    '            '    item.WBSDistributeCollection.Clear()
    '            'Next
    '            RefreshWBS()
    '        End Sub
    '        Private Sub UpdateDestAdmin()
    '            If Me.m_entity Is Nothing Then
    '                Return
    '            End If
    '            Dim flag As Boolean = Me.m_isInitialized
    '            Me.m_isInitialized = False
    '            Try
    '                Me.m_entity.Requestor = Me.m_entity.CostCenter.Admin
    '                '  Me.txtRequestorCode.Text = m_entity.Requestor.Code
    '                '  txtRequestorName.Text = m_entity.Requestor.Name
    '            Catch ex As Exception
    '            Finally
    '                Me.m_isInitialized = flag
    '            End Try
    '        End Sub

    Private Sub ibtnShowSCDialog_click(ByVal sendr As Object, ByVal e As EventArgs) Handles ibtnShowSCDialog.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.SC Is Nothing OrElse Not Me.m_entity.SC.Originated OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangePO}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangePO}") Then
        If Me.m_entity.SC Is Nothing Then
          Me.m_entity.SC = New SC
        End If
        Dim myEntityPanelService As IEntityPanelService = _
        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim entities As New ArrayList
        entities.Add(New SC)
        'entities.Add(New CostCenter)
        'If Me.m_entity.SC.SubContractor.Originated Then
        '	entities.Add(Me.m_entity.SC.SubContractor)
        'End If
        'If Me.m_entity.SC.CostCenter.Originated Then
        '	entities.Add(Me.m_entity.SC.CostCenter)
        'End If
        'Dim poNeedsApproval As Boolean = False
        ''poNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
        'Dim filters(0) As Filter
        'filters(0) = New Filter("poNeedsApproval", poNeedsApproval)
        ''filters(0) = New Filter("excludeCanceled", True)
        ''filters(1) = New Filter("excludedepleted", True)
        ''filters(2) = New Filter("excludeclosed", True)
        myEntityPanelService.OpenListDialog(New SC, AddressOf SetSC, entities)
      End If
    End Sub
    Private Sub SetSC(ByVal e As ISimpleEntity)
      'Dim poNeedsApproval As Boolean = False
      'poNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
      'Dim newSc As SC = CType(e, SC)
      If Me.m_entity Is Nothing Then
        Return
      End If
      'Me.m_entity.SC = New SC(e.Code)
      If Me.m_entity.SC Is Nothing Then
        Me.m_entity.SC = New SC
      End If
      Me.txtSCCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
      Me.WorkbenchWindow.ViewContent.IsDirty _
      Or SC.GetSC(txtSCCode, Me.m_entity.SC)
      Me.txtSCCode.Text = Me.m_entity.SC.Code

      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      Me.txtSupplierCode.Text = Me.m_entity.SC.SubContractor.Code
      Me.txtSupplierName.Text = Me.m_entity.SC.SubContractor.Name
      Me.txtCostCenterCode.Text = Me.m_entity.SC.CostCenter.Code
      Me.txtCostCenterName.Text = Me.m_entity.SC.CostCenter.Name
      'For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
      '    vitem.PrintName = Me.m_entity.Supplier.Name
      '    vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
      'Next
      'Me.m_entity.AdvancePayItemCollection.Clear()
      m_isInitialized = flag

      RefreshDocs()

      'pOCodeChanged = False
    End Sub
    Private Function GetSCExcludeList() As String
      Dim ret As String = ""
      For Each item As POItem In Me.m_entity.ItemCollection
        If Not item.Pritem Is Nothing Then
          ret &= "|" & item.Pritem.Pr.Id.ToString & ":" & item.Pritem.LineNumber.ToString & "|"
        End If
      Next
      Return ret
    End Function
    Private Sub ibtnGetFromBOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnGetFromBOQ.Click
      Dim arr As New ArrayList
      arr.Add(Me.m_entity.SC.CostCenter)
      Dim myEntityPanelService As IEntityPanelService = _
        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BOQForSelection, AddressOf SetItems, arr)
    End Sub
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Not Me.m_entity.Originated Then
        msgServ.ShowMessageFormatted("${res:Global.SaveDocumentFirst}", New String() {Me.m_entity.Code})
        Return
      End If
      'Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.vo.NoItem}"))
      'PJMModule
      Dim x As Form
      If m_ApproveDocModule.Activated Then
        x = New AdvanceApprovalCommentForm(Me.Entity)
      Else
        x = New ApprovalCommentForm(Me.Entity)
      End If
      x.ShowDialog()
      CheckFormEnable()
    End Sub

    ' Supplier

#End Region

#Region "IClipboardHandler Overrides"
    '        Public Overrides ReadOnly Property EnablePaste() As Boolean
    '            Get
    '                Dim data As IDataObject = Clipboard.GetDataObject
    '                If data.GetDataPresent((New Supplier).FullClassName) Then
    '                    If Not Me.ActiveControl Is Nothing Then
    '                        Select Case Me.ActiveControl.Name.ToLower
    '                            Case "txtsuppliercode", "txtsuppliername"
    '                                Return True
    '                        End Select
    '                    End If
    '                End If
    '                Return False
    '            End Get
    '        End Property
    '        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
    '            Dim data As IDataObject = Clipboard.GetDataObject
    '            If data.GetDataPresent((New Supplier).FullClassName) Then
    '                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
    '                Dim entity As New Supplier(id)
    '                If Not Me.ActiveControl Is Nothing Then
    '                    Select Case Me.ActiveControl.Name.ToLower
    '                        Case "txtsuppliercode", "txtsuppliername"
    '                            Me.SetSupplierDialog(entity)
    '                    End Select
    '                End If
    '            End If
    '        End Sub
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          Case Keys.Insert
            ibtnBlank_Click(Nothing, Nothing)
            Return True
          Case Keys.Delete
            If Me.tgItem.Focused Then
              ibtnDelRow_Click(Nothing, Nothing)
              Return True
            Else
              Return False
            End If
          Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      'If Me.tgItem.Height = 0 Then
      '  Return
      'End If
      'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      'Dim index As Integer = tgItem.CurrentRowIndex

      'Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
      '  'เพิ่มแถวจนเต็ม
      '  'Me.m_treeManager.Treetable.Childs.Add()
      '  Dim newRow As TreeRow
      '  newRow = Me.m_treeManager.Treetable.Childs.Add()
      '  newRow("voi_level") = 0
      '  newRow("Button") = "invisible"
      'Loop

      'If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
      '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '  'Me.m_treeManager.Treetable.Childs.Add()
      '  Dim newRow As TreeRow
      '  newRow = Me.m_treeManager.Treetable.Childs.Add()
      '  newRow("voi_level") = 0
      '  newRow("Button") = "invisible"
      'End If

      ''For rowIndex As Integer = 0 To Me.m_treeManager.Treetable.Rows.Count
      ''  Dim n As TreeRow = Me.m_treeManager.Treetable.Childs(rowIndex)
      ''  If n("sci_level") = 0 Then
      ''    Me.tgItem.TableStyles(0).GridColumnStyles(0).c()
      ''  End If
      ''Next

      'Me.m_treeManager.Treetable.AcceptChanges()
      'tgItem.CurrentRowIndex = Math.Max(0, index)
      'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
      ''If Me.tgItem.Height = 0 Then
      ''  Return
      ''End If
      ''Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      ''Dim index As Integer = tgItem.CurrentRowIndex

      ''Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
      ''  'เพิ่มแถวจนเต็ม
      ''  Me.m_treeManager.Treetable.Childs.Add()
      ''Loop

      ' ''If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
      ' ''    'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      ' ''    Me.m_treeManager.Treetable.Childs.Add()
      ' ''End If

      ''Me.m_treeManager.Treetable.AcceptChanges()
      ''tgItem.CurrentRowIndex = Math.Max(0, index)
      ''Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub chkClosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClosed.CheckedChanged
      If Not m_isInitialized Then
        Return
      End If
      Me.m_entity.Closing = Me.chkClosed.Checked
      If Me.m_entity.Closing Then
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.chkClosedCancel}")
        If Not Me.m_entity.Closed Then
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        Else
          Me.WorkbenchWindow.ViewContent.IsDirty = False
        End If
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VOPanelView.chkClosed}")
        If Not Me.m_entity.Closed Then
          Me.WorkbenchWindow.ViewContent.IsDirty = False
        Else
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      End If
      'Me.SetColumnOriginQty()
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      Me.RefreshDocs()
    End Sub

#Region "Customization"
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Try
          'Dim approveDocColl As New ApproveDocCollection(m_entity)
          'Dim poNeedsApproval As Boolean = CBool(Configuration.GetConfig("POApproveBeforePrint"))
          'If poNeedsApproval Then
          '    If Not approveDocColl.IsApproved Then
          '        Return False
          '    End If
          'End If
        Catch ex As Exception
        End Try
        Return MyBase.CanPrint
      End Get
    End Property
#End Region

#Region "IPreviewable"
    Public ReadOnly Property CanPreview As Boolean Implements Commands.IPreviewable.CanPreview
      Get
        Return True
      End Get
    End Property
#End Region

  End Class
End Namespace

