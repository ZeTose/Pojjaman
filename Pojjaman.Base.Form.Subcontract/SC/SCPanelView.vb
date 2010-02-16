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
  Public Class SCPanelView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable
    'Inherits UserControl

#Region " Windows Form Designer generated code "
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
    Friend WithEvents txtBeforeTax As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxAmount As System.Windows.Forms.Label
    Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAfterTax As System.Windows.Forms.Label
    Friend WithEvents txtAfterTax As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountRate As System.Windows.Forms.TextBox
    Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents lblTaxType As System.Windows.Forms.Label
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxRate As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxBase As System.Windows.Forms.Label
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnGetFromBOQ As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkClosed As System.Windows.Forms.CheckBox
    Friend WithEvents txtRealGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRetention As System.Windows.Forms.TextBox
    Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
    Friend WithEvents txtEndDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSubContractor As System.Windows.Forms.Label
    Friend WithEvents txtSubContractorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSubContractorName As System.Windows.Forms.TextBox
    Friend WithEvents btnSubContractorFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSubContractorEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDirectorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDirectorName As System.Windows.Forms.TextBox
    Friend WithEvents btnDirectorEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnDirectorFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblDirector As System.Windows.Forms.Label
    Friend WithEvents lblRetention As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblDiscount As System.Windows.Forms.Label
        Friend WithEvents lblAdvancePay As System.Windows.Forms.Label
    Friend WithEvents txtAdvancePay As System.Windows.Forms.TextBox
    Friend WithEvents txtCredit As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents cmbContact As System.Windows.Forms.ComboBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbSubContractor As System.Windows.Forms.GroupBox
    Friend WithEvents grbCostCenter As System.Windows.Forms.GroupBox
    Friend WithEvents btnWRFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtWRCode As System.Windows.Forms.TextBox
    Friend WithEvents lblWRCode As System.Windows.Forms.Label
    Friend WithEvents ibtnBlankSubItem As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SCPanelView))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.lblDiscount = New System.Windows.Forms.Label()
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
      Me.lblBeforeTax = New System.Windows.Forms.Label()
      Me.txtBeforeTax = New System.Windows.Forms.TextBox()
      Me.lblTaxAmount = New System.Windows.Forms.Label()
      Me.txtTaxAmount = New System.Windows.Forms.TextBox()
      Me.lblAfterTax = New System.Windows.Forms.Label()
      Me.txtAfterTax = New System.Windows.Forms.TextBox()
      Me.txtDiscountRate = New System.Windows.Forms.TextBox()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.lblTaxRate = New System.Windows.Forms.Label()
      Me.lblSubContractor = New System.Windows.Forms.Label()
      Me.txtSubContractorCode = New System.Windows.Forms.TextBox()
      Me.txtSubContractorName = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtStartDate = New System.Windows.Forms.TextBox()
      Me.txtEndDate = New System.Windows.Forms.TextBox()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtDirectorCode = New System.Windows.Forms.TextBox()
      Me.txtRetention = New System.Windows.Forms.TextBox()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtDirectorName = New System.Windows.Forms.TextBox()
      Me.txtRealGross = New System.Windows.Forms.TextBox()
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
      Me.txtAdvancePay = New System.Windows.Forms.TextBox()
      Me.txtCredit = New System.Windows.Forms.TextBox()
      Me.txtDueDate = New System.Windows.Forms.TextBox()
      Me.txtWRCode = New System.Windows.Forms.TextBox()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.btnSubContractorFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnWRFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblWRCode = New System.Windows.Forms.Label()
      Me.ibtnBlankSubItem = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
      Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblTaxBase = New System.Windows.Forms.Label()
      Me.ibtnGetFromBOQ = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkClosed = New System.Windows.Forms.CheckBox()
      Me.lblPercent = New System.Windows.Forms.Label()
      Me.grbSubContractor = New System.Windows.Forms.GroupBox()
      Me.cmbContact = New System.Windows.Forms.ComboBox()
      Me.btnSubContractorEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCredit = New System.Windows.Forms.Label()
      Me.lblDay = New System.Windows.Forms.Label()
      Me.lblDueDate = New System.Windows.Forms.Label()
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblContact = New System.Windows.Forms.Label()
      Me.grbCostCenter = New System.Windows.Forms.GroupBox()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblDirector = New System.Windows.Forms.Label()
      Me.btnDirectorFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnDirectorEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblRetention = New System.Windows.Forms.Label()
      Me.lblAdvancePay = New System.Windows.Forms.Label()
      Me.lblEndDate = New System.Windows.Forms.Label()
      Me.lblStartDate = New System.Windows.Forms.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip()
      Me.grbDetail.SuspendLayout()
      Me.grbSubContractor.SuspendLayout()
      Me.grbCostCenter.SuspendLayout()
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
      Me.tgItem.Location = New System.Drawing.Point(8, 200)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 239)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(11, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(78, 18)
      Me.lblCode.TabIndex = 11
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(311, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(95, 21)
      Me.dtpDocDate.TabIndex = 2
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(243, 17)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(68, 18)
      Me.lblDocDate.TabIndex = 14
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGross.BackColor = System.Drawing.Color.Transparent
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(200, 442)
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
      Me.txtGross.Location = New System.Drawing.Point(280, 442)
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(88, 21)
      Me.txtGross.TabIndex = 51
      Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiscount
      '
      Me.lblDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscount.Location = New System.Drawing.Point(232, 466)
      Me.lblDiscount.Name = "lblDiscount"
      Me.lblDiscount.Size = New System.Drawing.Size(48, 18)
      Me.lblDiscount.TabIndex = 49
      Me.lblDiscount.Text = "ส่วนลด :"
      Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDiscountAmount
      '
      Me.txtDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.txtDiscountAmount.Location = New System.Drawing.Point(392, 466)
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.txtDiscountAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtDiscountAmount.TabIndex = 52
      Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(176, 490)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(104, 18)
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
      Me.txtBeforeTax.Location = New System.Drawing.Point(280, 490)
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(200, 21)
      Me.txtBeforeTax.TabIndex = 54
      Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(480, 466)
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
      Me.txtTaxAmount.Location = New System.Drawing.Point(568, 466)
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtTaxAmount.TabIndex = 57
      Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAfterTax
      '
      Me.lblAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAfterTax.BackColor = System.Drawing.Color.Transparent
      Me.lblAfterTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAfterTax.Location = New System.Drawing.Point(496, 514)
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
      Me.txtAfterTax.Location = New System.Drawing.Point(568, 514)
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(200, 21)
      Me.txtAfterTax.TabIndex = 58
      Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDiscountRate
      '
      Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.txtDiscountRate.Location = New System.Drawing.Point(280, 466)
      Me.Validator.SetMinValue(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Name = "txtDiscountRate"
      Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
      Me.Validator.SetRequired(Me.txtDiscountRate, False)
      Me.txtDiscountRate.Size = New System.Drawing.Size(112, 21)
      Me.txtDiscountRate.TabIndex = 14
      '
      'cmbTaxType
      '
      Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(568, 442)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(88, 21)
      Me.cmbTaxType.TabIndex = 12
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(488, 442)
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
      Me.txtTaxRate.Location = New System.Drawing.Point(720, 442)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, True)
      Me.txtTaxRate.Size = New System.Drawing.Size(37, 21)
      Me.txtTaxRate.TabIndex = 13
      Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(652, 442)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
      Me.lblTaxRate.TabIndex = 44
      Me.lblTaxRate.Text = "อัตราภาษี :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSubContractor
      '
      Me.lblSubContractor.BackColor = System.Drawing.Color.Transparent
      Me.lblSubContractor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubContractor.Location = New System.Drawing.Point(2, 13)
      Me.lblSubContractor.Name = "lblSubContractor"
      Me.lblSubContractor.Size = New System.Drawing.Size(80, 18)
      Me.lblSubContractor.TabIndex = 20
      Me.lblSubContractor.Text = "ผู้รับเหมา:"
      Me.lblSubContractor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSubContractorCode
      '
      Me.Validator.SetDataType(Me.txtSubContractorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorCode, System.Drawing.Color.Empty)
      Me.txtSubContractorCode.Location = New System.Drawing.Point(82, 13)
      Me.txtSubContractorCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtSubContractorCode, "")
      Me.txtSubContractorCode.Name = "txtSubContractorCode"
      Me.Validator.SetRegularExpression(Me.txtSubContractorCode, "")
      Me.Validator.SetRequired(Me.txtSubContractorCode, True)
      Me.txtSubContractorCode.Size = New System.Drawing.Size(80, 21)
      Me.txtSubContractorCode.TabIndex = 1
      '
      'txtSubContractorName
      '
      Me.txtSubContractorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSubContractorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.txtSubContractorName.Location = New System.Drawing.Point(161, 13)
      Me.Validator.SetMinValue(Me.txtSubContractorName, "")
      Me.txtSubContractorName.Name = "txtSubContractorName"
      Me.txtSubContractorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSubContractorName, "")
      Me.Validator.SetRequired(Me.txtSubContractorName, False)
      Me.txtSubContractorName.Size = New System.Drawing.Size(193, 21)
      Me.txtSubContractorName.TabIndex = 24
      Me.txtSubContractorName.TabStop = False
      '
      'txtNote
      '
      Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(8, 464)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(96, 72)
      Me.txtNote.TabIndex = 10
      Me.txtNote.WordWrap = False
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(16, 440)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(88, 18)
      Me.lblNote.TabIndex = 23
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark
      Me.lblStatus.Location = New System.Drawing.Point(230, 179)
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
      Me.txtDocDate.Location = New System.Drawing.Point(310, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(77, 21)
      Me.txtDocDate.TabIndex = 2
      '
      'txtStartDate
      '
      Me.Validator.SetDataType(Me.txtStartDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtStartDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStartDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtStartDate, -13)
      Me.Validator.SetInvalidBackColor(Me.txtStartDate, System.Drawing.Color.Empty)
      Me.txtStartDate.Location = New System.Drawing.Point(500, 16)
      Me.Validator.SetMinValue(Me.txtStartDate, "")
      Me.txtStartDate.Name = "txtStartDate"
      Me.Validator.SetRegularExpression(Me.txtStartDate, "")
      Me.Validator.SetRequired(Me.txtStartDate, True)
      Me.txtStartDate.Size = New System.Drawing.Size(77, 21)
      Me.txtStartDate.TabIndex = 5
      '
      'txtEndDate
      '
      Me.Validator.SetDataType(Me.txtEndDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtEndDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEndDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEndDate, -13)
      Me.Validator.SetInvalidBackColor(Me.txtEndDate, System.Drawing.Color.Empty)
      Me.txtEndDate.Location = New System.Drawing.Point(500, 40)
      Me.Validator.SetMinValue(Me.txtEndDate, "")
      Me.txtEndDate.Name = "txtEndDate"
      Me.Validator.SetRegularExpression(Me.txtEndDate, "")
      Me.Validator.SetRequired(Me.txtEndDate, True)
      Me.txtEndDate.Size = New System.Drawing.Size(77, 21)
      Me.txtEndDate.TabIndex = 6
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(80, 13)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, True)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(80, 21)
      Me.txtCostCenterCode.TabIndex = 1
      '
      'txtDirectorCode
      '
      Me.Validator.SetDataType(Me.txtDirectorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDirectorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDirectorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDirectorCode, System.Drawing.Color.Empty)
      Me.txtDirectorCode.Location = New System.Drawing.Point(80, 37)
      Me.Validator.SetMinValue(Me.txtDirectorCode, "")
      Me.txtDirectorCode.Name = "txtDirectorCode"
      Me.Validator.SetRegularExpression(Me.txtDirectorCode, "")
      Me.Validator.SetRequired(Me.txtDirectorCode, True)
      Me.txtDirectorCode.Size = New System.Drawing.Size(80, 21)
      Me.txtDirectorCode.TabIndex = 2
      '
      'txtRetention
      '
      Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.txtRetention.Location = New System.Drawing.Point(500, 64)
      Me.Validator.SetMinValue(Me.txtRetention, "")
      Me.txtRetention.Name = "txtRetention"
      Me.Validator.SetRegularExpression(Me.txtRetention, "")
      Me.Validator.SetRequired(Me.txtRetention, False)
      Me.txtRetention.Size = New System.Drawing.Size(127, 21)
      Me.txtRetention.TabIndex = 7
      Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTaxBase
      '
      Me.txtTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.txtTaxBase.Location = New System.Drawing.Point(280, 514)
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(88, 21)
      Me.txtTaxBase.TabIndex = 16
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(159, 13)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(137, 21)
      Me.txtCostCenterName.TabIndex = 25
      Me.txtCostCenterName.TabStop = False
      '
      'txtDirectorName
      '
      Me.txtDirectorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDirectorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDirectorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDirectorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDirectorName, System.Drawing.Color.Empty)
      Me.txtDirectorName.Location = New System.Drawing.Point(159, 37)
      Me.Validator.SetMinValue(Me.txtDirectorName, "")
      Me.txtDirectorName.Name = "txtDirectorName"
      Me.txtDirectorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDirectorName, "")
      Me.Validator.SetRequired(Me.txtDirectorName, False)
      Me.txtDirectorName.Size = New System.Drawing.Size(137, 21)
      Me.txtDirectorName.TabIndex = 26
      Me.txtDirectorName.TabStop = False
      '
      'txtRealGross
      '
      Me.txtRealGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.txtRealGross.Location = New System.Drawing.Point(392, 442)
      Me.Validator.SetMinValue(Me.txtRealGross, "")
      Me.txtRealGross.Name = "txtRealGross"
      Me.Validator.SetRegularExpression(Me.txtRealGross, "")
      Me.Validator.SetRequired(Me.txtRealGross, False)
      Me.txtRealGross.Size = New System.Drawing.Size(88, 21)
      Me.txtRealGross.TabIndex = 11
      Me.txtRealGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxAmount
      '
      Me.txtRealTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(680, 466)
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtRealTaxAmount.TabIndex = 15
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxBase
      '
      Me.txtRealTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(392, 514)
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(88, 21)
      Me.txtRealTaxBase.TabIndex = 17
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAdvancePay
      '
      Me.Validator.SetDataType(Me.txtAdvancePay, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvancePay, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvancePay, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvancePay, System.Drawing.Color.Empty)
      Me.txtAdvancePay.Location = New System.Drawing.Point(500, 88)
      Me.Validator.SetMinValue(Me.txtAdvancePay, "")
      Me.txtAdvancePay.Name = "txtAdvancePay"
      Me.Validator.SetRegularExpression(Me.txtAdvancePay, "")
      Me.Validator.SetRequired(Me.txtAdvancePay, False)
      Me.txtAdvancePay.Size = New System.Drawing.Size(127, 21)
      Me.txtAdvancePay.TabIndex = 8
      Me.txtAdvancePay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCredit
      '
      Me.Validator.SetDataType(Me.txtCredit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCredit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCredit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCredit, System.Drawing.Color.Empty)
      Me.txtCredit.Location = New System.Drawing.Point(82, 37)
      Me.Validator.SetMinValue(Me.txtCredit, "")
      Me.txtCredit.Name = "txtCredit"
      Me.Validator.SetRegularExpression(Me.txtCredit, "")
      Me.Validator.SetRequired(Me.txtCredit, False)
      Me.txtCredit.Size = New System.Drawing.Size(80, 21)
      Me.txtCredit.TabIndex = 2
      Me.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDueDate
      '
      Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDueDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.txtDueDate.Location = New System.Drawing.Point(303, 38)
      Me.Validator.SetMinValue(Me.txtDueDate, "")
      Me.txtDueDate.Name = "txtDueDate"
      Me.Validator.SetRegularExpression(Me.txtDueDate, "")
      Me.Validator.SetRequired(Me.txtDueDate, False)
      Me.txtDueDate.Size = New System.Drawing.Size(77, 21)
      Me.txtDueDate.TabIndex = 3
      '
      'txtWRCode
      '
      Me.Validator.SetDataType(Me.txtWRCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWRCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWRCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWRCode, System.Drawing.Color.Empty)
      Me.txtWRCode.Location = New System.Drawing.Point(89, 40)
      Me.txtWRCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtWRCode, "")
      Me.txtWRCode.Name = "txtWRCode"
      Me.Validator.SetRegularExpression(Me.txtWRCode, "")
      Me.Validator.SetRequired(Me.txtWRCode, False)
      Me.txtWRCode.Size = New System.Drawing.Size(111, 21)
      Me.txtWRCode.TabIndex = 3
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(1, 177)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(88, 18)
      Me.lblItem.TabIndex = 33
      Me.lblItem.Text = "รายการสั่งจ้าง"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSubContractorFind
      '
      Me.btnSubContractorFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSubContractorFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSubContractorFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSubContractorFind.Location = New System.Drawing.Point(353, 13)
      Me.btnSubContractorFind.Name = "btnSubContractorFind"
      Me.btnSubContractorFind.Size = New System.Drawing.Size(24, 23)
      Me.btnSubContractorFind.TabIndex = 27
      Me.btnSubContractorFind.TabStop = False
      Me.btnSubContractorFind.ThemedImage = CType(resources.GetObject("btnSubContractorFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.Controls.Add(Me.btnApprove)
      Me.grbDetail.Controls.Add(Me.btnWRFind)
      Me.grbDetail.Controls.Add(Me.txtWRCode)
      Me.grbDetail.Controls.Add(Me.lblWRCode)
      Me.grbDetail.Controls.Add(Me.ibtnBlankSubItem)
      Me.grbDetail.Controls.Add(Me.txtRetention)
      Me.grbDetail.Controls.Add(Me.txtEndDate)
      Me.grbDetail.Controls.Add(Me.dtpEndDate)
      Me.grbDetail.Controls.Add(Me.txtStartDate)
      Me.grbDetail.Controls.Add(Me.dtpStartDate)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.txtRealGross)
      Me.grbDetail.Controls.Add(Me.ibtnResetGross)
      Me.grbDetail.Controls.Add(Me.txtRealTaxAmount)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtRealTaxBase)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxBase)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.txtGross)
      Me.grbDetail.Controls.Add(Me.lblDiscount)
      Me.grbDetail.Controls.Add(Me.txtDiscountAmount)
      Me.grbDetail.Controls.Add(Me.lblBeforeTax)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblGross)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.txtBeforeTax)
      Me.grbDetail.Controls.Add(Me.lblTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtTaxAmount)
      Me.grbDetail.Controls.Add(Me.lblAfterTax)
      Me.grbDetail.Controls.Add(Me.txtAfterTax)
      Me.grbDetail.Controls.Add(Me.txtDiscountRate)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.cmbTaxType)
      Me.grbDetail.Controls.Add(Me.lblTaxType)
      Me.grbDetail.Controls.Add(Me.txtTaxRate)
      Me.grbDetail.Controls.Add(Me.lblTaxRate)
      Me.grbDetail.Controls.Add(Me.txtTaxBase)
      Me.grbDetail.Controls.Add(Me.lblTaxBase)
      Me.grbDetail.Controls.Add(Me.ibtnGetFromBOQ)
      Me.grbDetail.Controls.Add(Me.chkClosed)
      Me.grbDetail.Controls.Add(Me.lblPercent)
      Me.grbDetail.Controls.Add(Me.txtAdvancePay)
      Me.grbDetail.Controls.Add(Me.grbSubContractor)
      Me.grbDetail.Controls.Add(Me.grbCostCenter)
      Me.grbDetail.Controls.Add(Me.lblRetention)
      Me.grbDetail.Controls.Add(Me.lblAdvancePay)
      Me.grbDetail.Controls.Add(Me.lblEndDate)
      Me.grbDetail.Controls.Add(Me.lblStartDate)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(0, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(776, 544)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.Enabled = False
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(221, 16)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 13
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtnCopyMe.Visible = False
      '
      'btnApprove
      '
      Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApprove.ForeColor = System.Drawing.Color.Black
      Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnApprove.Location = New System.Drawing.Point(664, 174)
      Me.btnApprove.Name = "btnApprove"
      Me.btnApprove.Size = New System.Drawing.Size(104, 23)
      Me.btnApprove.TabIndex = 334
      Me.btnApprove.Text = "อนุมัติเอกสาร"
      Me.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnApprove.ThemedImage = CType(resources.GetObject("btnApprove.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnWRFind
      '
      Me.btnWRFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWRFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWRFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnWRFind.Location = New System.Drawing.Point(200, 38)
      Me.btnWRFind.Name = "btnWRFind"
      Me.btnWRFind.Size = New System.Drawing.Size(24, 23)
      Me.btnWRFind.TabIndex = 27
      Me.btnWRFind.TabStop = False
      Me.btnWRFind.ThemedImage = CType(resources.GetObject("btnWRFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblWRCode
      '
      Me.lblWRCode.BackColor = System.Drawing.Color.Transparent
      Me.lblWRCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWRCode.Location = New System.Drawing.Point(3, 40)
      Me.lblWRCode.Name = "lblWRCode"
      Me.lblWRCode.Size = New System.Drawing.Size(86, 18)
      Me.lblWRCode.TabIndex = 20
      Me.lblWRCode.Text = "เลขที่ใบขอจ้าง:"
      Me.lblWRCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlankSubItem
      '
      Me.ibtnBlankSubItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlankSubItem.Location = New System.Drawing.Point(165, 174)
      Me.ibtnBlankSubItem.Name = "ibtnBlankSubItem"
      Me.ibtnBlankSubItem.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlankSubItem.TabIndex = 346
      Me.ibtnBlankSubItem.TabStop = False
      Me.ibtnBlankSubItem.ThemedImage = CType(resources.GetObject("ibtnBlankSubItem.ThemedImage"), System.Drawing.Bitmap)
      '
      'dtpEndDate
      '
      Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpEndDate.Location = New System.Drawing.Point(500, 40)
      Me.dtpEndDate.Name = "dtpEndDate"
      Me.dtpEndDate.Size = New System.Drawing.Size(95, 21)
      Me.dtpEndDate.TabIndex = 13
      '
      'dtpStartDate
      '
      Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpStartDate.Location = New System.Drawing.Point(500, 16)
      Me.dtpStartDate.Name = "dtpStartDate"
      Me.dtpStartDate.Size = New System.Drawing.Size(95, 21)
      Me.dtpStartDate.TabIndex = 11
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(89, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(111, 21)
      Me.cmbCode.TabIndex = 1
      '
      'ibtnResetGross
      '
      Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetGross.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetGross.Location = New System.Drawing.Point(368, 442)
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
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(656, 466)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 66
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(368, 514)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 65
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(200, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 12
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(140, 174)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 36
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(190, 174)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 37
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
      '
      'lblTaxBase
      '
      Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.Location = New System.Drawing.Point(176, 514)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(104, 18)
      Me.lblTaxBase.TabIndex = 55
      Me.lblTaxBase.Text = "มูลค่าสินค้าาบริการ :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnGetFromBOQ
      '
      Me.ibtnGetFromBOQ.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnGetFromBOQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnGetFromBOQ.Location = New System.Drawing.Point(89, 174)
      Me.ibtnGetFromBOQ.Name = "ibtnGetFromBOQ"
      Me.ibtnGetFromBOQ.Size = New System.Drawing.Size(48, 24)
      Me.ibtnGetFromBOQ.TabIndex = 35
      Me.ibtnGetFromBOQ.TabStop = False
      Me.ibtnGetFromBOQ.Text = "BOQ"
      Me.ibtnGetFromBOQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ibtnGetFromBOQ.ThemedImage = CType(resources.GetObject("ibtnGetFromBOQ.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnGetFromBOQ, "BOQ")
      '
      'chkClosed
      '
      Me.chkClosed.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkClosed.Location = New System.Drawing.Point(598, 16)
      Me.chkClosed.Name = "chkClosed"
      Me.chkClosed.Size = New System.Drawing.Size(80, 21)
      Me.chkClosed.TabIndex = 12
      Me.chkClosed.Text = "ปิด SC"
      Me.chkClosed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblPercent
      '
      Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(758, 442)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 46
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbSubContractor
      '
      Me.grbSubContractor.Controls.Add(Me.txtDueDate)
      Me.grbSubContractor.Controls.Add(Me.cmbContact)
      Me.grbSubContractor.Controls.Add(Me.btnSubContractorEdit)
      Me.grbSubContractor.Controls.Add(Me.btnSubContractorFind)
      Me.grbSubContractor.Controls.Add(Me.txtSubContractorCode)
      Me.grbSubContractor.Controls.Add(Me.lblSubContractor)
      Me.grbSubContractor.Controls.Add(Me.lblCredit)
      Me.grbSubContractor.Controls.Add(Me.lblDay)
      Me.grbSubContractor.Controls.Add(Me.lblDueDate)
      Me.grbSubContractor.Controls.Add(Me.txtCredit)
      Me.grbSubContractor.Controls.Add(Me.dtpDueDate)
      Me.grbSubContractor.Controls.Add(Me.txtSubContractorName)
      Me.grbSubContractor.Controls.Add(Me.lblContact)
      Me.grbSubContractor.Location = New System.Drawing.Point(7, 59)
      Me.grbSubContractor.Name = "grbSubContractor"
      Me.grbSubContractor.Size = New System.Drawing.Size(409, 111)
      Me.grbSubContractor.TabIndex = 4
      Me.grbSubContractor.TabStop = False
      '
      'cmbContact
      '
      Me.cmbContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbContact.Location = New System.Drawing.Point(82, 61)
      Me.cmbContact.Name = "cmbContact"
      Me.cmbContact.Size = New System.Drawing.Size(318, 21)
      Me.cmbContact.TabIndex = 7
      '
      'btnSubContractorEdit
      '
      Me.btnSubContractorEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSubContractorEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSubContractorEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSubContractorEdit.Location = New System.Drawing.Point(377, 13)
      Me.btnSubContractorEdit.Name = "btnSubContractorEdit"
      Me.btnSubContractorEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnSubContractorEdit.TabIndex = 32
      Me.btnSubContractorEdit.TabStop = False
      Me.btnSubContractorEdit.ThemedImage = CType(resources.GetObject("btnSubContractorEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCredit
      '
      Me.lblCredit.BackColor = System.Drawing.Color.Transparent
      Me.lblCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCredit.Location = New System.Drawing.Point(2, 38)
      Me.lblCredit.Name = "lblCredit"
      Me.lblCredit.Size = New System.Drawing.Size(80, 18)
      Me.lblCredit.TabIndex = 20
      Me.lblCredit.Text = "ระยะเครดิต:"
      Me.lblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDay
      '
      Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDay.Location = New System.Drawing.Point(165, 38)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(59, 18)
      Me.lblDay.TabIndex = 14
      Me.lblDay.Text = "วัน"
      Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.Location = New System.Drawing.Point(224, 38)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(81, 18)
      Me.lblDueDate.TabIndex = 14
      Me.lblDueDate.Text = "ครบกำหนด:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDueDate
      '
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDate.Location = New System.Drawing.Point(303, 38)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(95, 21)
      Me.dtpDueDate.TabIndex = 5
      '
      'lblContact
      '
      Me.lblContact.BackColor = System.Drawing.Color.Transparent
      Me.lblContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblContact.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblContact.Location = New System.Drawing.Point(2, 61)
      Me.lblContact.Name = "lblContact"
      Me.lblContact.Size = New System.Drawing.Size(80, 18)
      Me.lblContact.TabIndex = 21
      Me.lblContact.Text = "ผู้ติดต่อ:"
      Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbCostCenter
      '
      Me.grbCostCenter.Controls.Add(Me.txtCostCenterName)
      Me.grbCostCenter.Controls.Add(Me.txtCostCenterCode)
      Me.grbCostCenter.Controls.Add(Me.lblCostCenter)
      Me.grbCostCenter.Controls.Add(Me.btnCCFind)
      Me.grbCostCenter.Controls.Add(Me.btnCCEdit)
      Me.grbCostCenter.Controls.Add(Me.lblDirector)
      Me.grbCostCenter.Controls.Add(Me.txtDirectorCode)
      Me.grbCostCenter.Controls.Add(Me.txtDirectorName)
      Me.grbCostCenter.Controls.Add(Me.btnDirectorFind)
      Me.grbCostCenter.Controls.Add(Me.btnDirectorEdit)
      Me.grbCostCenter.Location = New System.Drawing.Point(420, 107)
      Me.grbCostCenter.Name = "grbCostCenter"
      Me.grbCostCenter.Size = New System.Drawing.Size(350, 63)
      Me.grbCostCenter.TabIndex = 9
      Me.grbCostCenter.TabStop = False
      '
      'lblCostCenter
      '
      Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCostCenter.Location = New System.Drawing.Point(0, 13)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(80, 18)
      Me.lblCostCenter.TabIndex = 21
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCCFind
      '
      Me.btnCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCFind.Location = New System.Drawing.Point(296, 13)
      Me.btnCCFind.Name = "btnCCFind"
      Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCCFind.TabIndex = 28
      Me.btnCCFind.TabStop = False
      Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCEdit
      '
      Me.btnCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCEdit.Location = New System.Drawing.Point(320, 13)
      Me.btnCCEdit.Name = "btnCCEdit"
      Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCCEdit.TabIndex = 31
      Me.btnCCEdit.TabStop = False
      Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDirector
      '
      Me.lblDirector.BackColor = System.Drawing.Color.Transparent
      Me.lblDirector.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDirector.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDirector.Location = New System.Drawing.Point(0, 37)
      Me.lblDirector.Name = "lblDirector"
      Me.lblDirector.Size = New System.Drawing.Size(80, 18)
      Me.lblDirector.TabIndex = 22
      Me.lblDirector.Text = "ผู้สั่งจ้าง:"
      Me.lblDirector.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnDirectorFind
      '
      Me.btnDirectorFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDirectorFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDirectorFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDirectorFind.Location = New System.Drawing.Point(296, 37)
      Me.btnDirectorFind.Name = "btnDirectorFind"
      Me.btnDirectorFind.Size = New System.Drawing.Size(24, 23)
      Me.btnDirectorFind.TabIndex = 29
      Me.btnDirectorFind.TabStop = False
      Me.btnDirectorFind.ThemedImage = CType(resources.GetObject("btnDirectorFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnDirectorEdit
      '
      Me.btnDirectorEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDirectorEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDirectorEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDirectorEdit.Location = New System.Drawing.Point(320, 37)
      Me.btnDirectorEdit.Name = "btnDirectorEdit"
      Me.btnDirectorEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnDirectorEdit.TabIndex = 30
      Me.btnDirectorEdit.TabStop = False
      Me.btnDirectorEdit.ThemedImage = CType(resources.GetObject("btnDirectorEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblRetention
      '
      Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetention.Location = New System.Drawing.Point(404, 64)
      Me.lblRetention.Name = "lblRetention"
      Me.lblRetention.Size = New System.Drawing.Size(96, 18)
      Me.lblRetention.TabIndex = 344
      Me.lblRetention.Text = "Retention:"
      Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAdvancePay
      '
      Me.lblAdvancePay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvancePay.Location = New System.Drawing.Point(404, 88)
      Me.lblAdvancePay.Name = "lblAdvancePay"
      Me.lblAdvancePay.Size = New System.Drawing.Size(96, 18)
      Me.lblAdvancePay.TabIndex = 345
      Me.lblAdvancePay.Text = "มัดจำ:"
      Me.lblAdvancePay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblEndDate
      '
      Me.lblEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEndDate.Location = New System.Drawing.Point(407, 40)
      Me.lblEndDate.Name = "lblEndDate"
      Me.lblEndDate.Size = New System.Drawing.Size(93, 18)
      Me.lblEndDate.TabIndex = 343
      Me.lblEndDate.Text = "วันที่เสร็จงาน:"
      Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStartDate
      '
      Me.lblStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStartDate.Location = New System.Drawing.Point(407, 16)
      Me.lblStartDate.Name = "lblStartDate"
      Me.lblStartDate.Size = New System.Drawing.Size(93, 18)
      Me.lblStartDate.TabIndex = 335
      Me.lblStartDate.Text = "วันที่เริ่มงาน:"
      Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'SCPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "SCPanelView"
      Me.Size = New System.Drawing.Size(784, 552)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbSubContractor.ResumeLayout(False)
      Me.grbSubContractor.PerformLayout()
      Me.grbCostCenter.ResumeLayout(False)
      Me.grbCostCenter.PerformLayout()
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
    Private m_entity As SC
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_enableState As Hashtable
    Private m_tableStyleEnable As Hashtable

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()

      Dim dt As TreeTable = SC.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf SCItemDelete
      AddHandler dt.RowExpandStateChanged, AddressOf RowExpandCollapseHandler

      EventWiring()
    End Sub

    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"

    Public Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      'e.HilightValue = False
      'e.RedText = False
      'Dim i As Integer = 0
      'For Each row As DataRow In Me.m_treeManager2.Treetable.Rows
      '    For Each col As DataColumn In Me.m_treeManager2.Treetable.Columns
      '        If col.Ordinal > 0 Then
      '            If Not row.IsNull(col) AndAlso IsNumeric(row(col)) Then
      '                If CDec(row(col)) < 0 Then
      '                    If e.Column = col.Ordinal And e.Row = i Then
      '                        'e.HilightValue = True
      '                        e.RedText = True
      '                    End If
      '                End If
      '            End If
      '        End If
      '    Next
      '    i += 1
      'Next
    End Sub
    Public Sub CCButtonClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.CostCenter Is Nothing Then
        Return
      End If
      If Me.m_entity.CostCenter.BoqId = 0 Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New CostCenter
      Dim entities As New ArrayList
      myEntityPanelService.OpenListDialog(entity, AddressOf SetCostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal myEntity As ISimpleEntity)
      'Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      'If doc Is Nothing Then
      '    Return
      'End If
      'Dim dt As TreeTable = Me.m_treeManager2.Treetable
      'Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      'Dim row As TreeRow = Me.m_treeManager2.SelectedRow
      'If TypeOf myEntity Is CostCenter Then
      '    CType(row.Tag, WBSDistribute).CostCenter = CType(myEntity, CostCenter)
      '    CType(row.Tag, WBSDistribute).WBS = New WBS
      'End If
      'Dim view As Integer = 6
      'm_wbsdInitialized = False
      'wsdColl.Populate(dt, doc, view)
      'm_wbsdInitialized = True
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "SC"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)


      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("sci_entityType" _
      , CodeDescription.GetCodeList("sci_entitytype") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.TypeHeaderText}")
      csType.NullText = String.Empty
      csType.Width = 80

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      Dim csName As New TreeTextColumn
      csName.MappingName = "sci_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "sci_itemName"

      ''WR ============================================================================================================
      Dim csWRUnit As New TreeTextColumn
      csWRUnit.MappingName = "WRUnit"
      csWRUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.WRUnitHeaderText}")
      csWRUnit.NullText = ""
      csWRUnit.TextBox.Name = "WRUnit"
      csWRUnit.ReadOnly = True

      Dim csWRQty As New TreeTextColumn
      csWRQty.MappingName = "sci_wriQty"
      csWRQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.WRQtyHeaderText}")
      csWRQty.NullText = ""
      csWRQty.DataAlignment = HorizontalAlignment.Right
      csWRQty.Format = "#,###.##"
      csWRQty.TextBox.Name = "sci_wriQty"
      ''===============================================================================================================

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClicked

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "sci_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "sci_qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty


      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "sci_unitprice"
      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.poi_unitpriceHeaderText}")
      csUnitPRice.NullText = ""
      csUnitPRice.TextBox.Name = "sci_unitprice"
      csUnitPRice.DataAlignment = HorizontalAlignment.Right
      AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csMat As New TreeTextColumn
      csMat.MappingName = "sci_mat"
      csMat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.MatAmountHeaderText}")
      csMat.NullText = ""
      csMat.TextBox.Name = "sci_mat"
      csMat.DataAlignment = HorizontalAlignment.Right
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim csLab As New TreeTextColumn
      csLab.MappingName = "sci_lab"
      csLab.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.LabAmountHeaderText}")
      csLab.NullText = ""
      csLab.TextBox.Name = "sci_lab"
      csLab.DataAlignment = HorizontalAlignment.Right
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csEq As New TreeTextColumn
      csEq.MappingName = "sci_eq"
      csEq.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.EQAmountHeaderText}")
      csEq.NullText = ""
      csEq.TextBox.Name = "sci_eq"
      csEq.DataAlignment = HorizontalAlignment.Right
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.DataAlignment = HorizontalAlignment.Right
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csPAAmount As New TreeTextColumn
      csPAAmount.MappingName = "PAAmount"
      csPAAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.PAAmountHeaderText}")
      csPAAmount.NullText = ""
      csPAAmount.DataAlignment = HorizontalAlignment.Right
      csPAAmount.Format = "#,###.##"
      csPAAmount.ReadOnly = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "sci_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "sci_note"

      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "sci_unvatable"
      csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.UnVatableHeaderText}")
      csVatable.Width = 100
      csVatable.InvisibleWhenUnspcified = True

      'dst.GridColumnStyles.Add(csLineNumber)
      'dst.GridColumnStyles.Add(csSCDesc)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csWRUnit)
      dst.GridColumnStyles.Add(csWRQty)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      'dst.GridColumnStyles.Add(csOriginQty)

      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csBarrier1)
      dst.GridColumnStyles.Add(csMat)
      dst.GridColumnStyles.Add(csLab)
      dst.GridColumnStyles.Add(csEq)
      dst.GridColumnStyles.Add(csPAAmount)
      dst.GridColumnStyles.Add(csNote)
      'dst.GridColumnStyles.Add(csVatable)

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
    Private ReadOnly Property CurrentTagItem() As SCItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is SCItem Then
          Return Nothing
        End If
        Return CType(row.Tag, SCItem)
      End Get
    End Property
    Private ReadOnly Property CurrentRealTagItem() As SCItem
      Get
        'Return CType(childRow.Tag, SCItem)
        Dim row As TreeRow = Me.m_treeManager.SelectedRow

        Try
          Dim lastIndex As Integer = row.Index
          Dim startIndex As Integer = row.Index

          For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
            If i > startIndex Then
              If CType(Me.m_treeManager.Treetable.Childs(i).Tag, SCItem).Level = 0 Then
                Exit For
              End If
              lastIndex = i
            End If
          Next

          Dim parentRow As TreeRow = Me.m_treeManager.Treetable.Childs(lastIndex)

          Return CType(parentRow.Tag, SCItem)
        Catch ex As Exception
          Return Nothing
        End Try

        'Dim childRow As TreeRow = row.LastChild 'ลูกที่เลือกแถวสุดท้าย ถ้าเลือกแม่อยู่
        'Dim lastChild As TreeRow = row.Parent.LastChild 'ลูกที่แลือกแถวสุดท้าย ถ้าเลือกลูกอยู่แล้ว

        '''เลือกลูก ๆ อยู่แล้ว หรือ ที่เลือกอยู่ไม่มีลูก ๆ (อาจเป็นแม่ ที่ไม่มีลูก หรือ ลูกก็ได้)
        'If Not lastChild Is Nothing And childRow Is Nothing Then
        '  If TypeOf lastChild.Tag Is SCItem Then
        '    If CType(lastChild.Tag, SCItem).Level = 0 Then
        '      Return CType(row.Tag, SCItem)
        '    End If
        '    Return CType(lastChild.Tag, SCItem)
        '  End If
        'End If

        '''เลือกแม่ที่มีลูก ๆ อยู่
        'If Not childRow Is Nothing Then
        '  If TypeOf childRow.Tag Is SCItem Then
        '    Return CType(childRow.Tag, SCItem)
        '  End If
        'End If



      End Get
    End Property
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub RowExpandCollapseHandler(ByVal e As RowExpandCollapseEventArgs)
      'If TypeOf e.Row.Tag Is SCItem Then
      '  If Not m_isInitialized Then
      '    Return
      '  End If
      '  If Me.m_treeManager.SelectedRow Is Nothing Then
      '    Return
      '  End If
      '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      '  If Me.m_entity Is Nothing Then
      '    Return
      '  End If
      '  Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      '  doc.State = e.Row.State
      '  RefreshDocs()
      'End If
    End Sub
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
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      ''If tick checkbox that not in the current hilight row

      'If e.Column.ColumnName.ToLower = "sci_unvatable" Then
      '  Me.m_treeManager.SelectedRow = e.Row
      '  doc = Me.m_entity.ItemCollection.CurrentItem
      'End If
      If doc Is Nothing Then
        doc = New SCItem
        doc.Level = 0
        doc.ItemType = New SCIItemType(289)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      'If doc.ItemType Is Nothing Then
      '  doc.ItemType = New SCIItemType(289)
      'End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "sci_itemname"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.EntityName = CStr(e.ProposedValue)
          Case "unit"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing OrElse e.ProposedValue.ToString.Trim.Length = 0 Then
              e.ProposedValue = ""
            End If
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            doc.Unit = myUnit
          Case "sci_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Qty = value
          Case "sci_entitytype"
            Dim value As SCIItemType
            If IsNumeric(e.ProposedValue) Then
              value = New SCIItemType(CInt(e.ProposedValue))
            End If
            doc.ItemType = value
          Case "sci_unitprice"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.UnitPrice = value
          Case "sci_mat"
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
          Case "sci_lab"
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
          Case "sci_eq"
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
          Case "sci_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
          Case "sci_unvatable"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = False
            End If
            doc.Unvatable = CBool(e.ProposedValue)
          Case "sci_wriqty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.WRIQty = value
        End Select
        'End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub SCItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "TreeTable Handlers"
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
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" Then
                ctrl.Enabled = False
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
              ctrl.Enabled = CBool(m_enableState(ctrl))
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If
        Else
          'ถ้าใช้การอนุมัติแบบเก่า
          If Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then
            For Each ctrl As Control In grbDetail.Controls
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" Then
                ctrl.Enabled = False
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
              ctrl.Enabled = CBool(m_enableState(ctrl))
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If
        End If
      End If

      'จาก Status ของเอกสารเอง
      If Me.m_entity.Status.Value = 0 OrElse m_entityRefed = 1 OrElse Me.m_entity.Closed Then
        For Each ctrl As Control In grbDetail.Controls
          If Not ctrl.Name = "chkClosed" Then
            ctrl.Enabled = False
          End If
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If

      If Me.m_entity.WR Is Nothing OrElse Me.m_entity.WR.Id = 0 Then
        Me.txtCostCenterCode.Enabled = True
        Me.btnCCFind.Enabled = True
      Else
        Me.txtCostCenterCode.Enabled = False
        Me.btnCCFind.Enabled = False
      End If

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
      Me.dtpStartDate.Value = Now

      Me.dtpEndDate.Value = Now
      'Me.dtpReceivingDate.Value = Now
      If cmbTaxType.Items.Count >= 1 Then
        cmbTaxType.SelectedIndex = 1
      End If

    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblCode}")
      Me.Validator.SetDisplayName(Me.lblCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblStartDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblstartDate}")
      Me.Validator.SetDisplayName(Me.txtStartDate, StringHelper.GetRidOfAtEnd(Me.lblStartDate.Text, ":"))

      Me.lblEndDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblEndDate}")
      Me.Validator.SetDisplayName(Me.txtEndDate, StringHelper.GetRidOfAtEnd(Me.lblEndDate.Text, ":"))

      Me.lblSubContractor.Text = Me.StringParserService.Parse("${res:Global.SubContractorText}")
      Me.Validator.SetDisplayName(Me.txtSubContractorCode, StringHelper.GetRidOfAtEnd(Me.lblSubContractor.Text, ":"))

      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Global.CostCenterText}")
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, StringHelper.GetRidOfAtEnd(Me.lblCostCenter.Text, ":"))

      Me.lblDirector.Text = Me.StringParserService.Parse("${res:Global.DirectorText}")
      Me.Validator.SetDisplayName(Me.txtDirectorCode, StringHelper.GetRidOfAtEnd(Me.lblDirector.Text, ":"))

      Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblRetention}")
      'Me.lblWitholdingTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblAdvancePay}")
      'Me.lblWitholdingTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblWitholdingTax}")
      Me.lblWRCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblWRCode}")

      'Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosed}")

      Me.lblCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblCredit}")
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblDay}")
      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblDueDate}")
      Me.lblContact.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblContact}")

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblItem}")
      Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.btnApprove}")

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblNote}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblGross}")
      Me.lblDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblDiscount}")
      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblBeforeTax}")
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblTaxBase}")
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblTaxType}")
      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblTaxRate}")
      Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblTaxAmount}")
      Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblAfterTax}")

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDueDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCredit.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCredit.TextChanged, AddressOf Me.TextHandler

      AddHandler txtStartDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpStartDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtEndDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpEndDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtSubContractorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSubContractorCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCostCenterCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDirectorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDirectorCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtRetention.Validated, AddressOf Me.ChangeProperty
      AddHandler txtRetention.TextChanged, AddressOf Me.TextHandler

      'AddHandler txtWitholdingTax.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtWitholdingTax.TextChanged, AddressOf Me.TextHandler

      AddHandler txtWRCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtWRCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtAdvancePay.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAdvancePay.TextChanged, AddressOf Me.TextHandler

      AddHandler cmbContact.SelectedIndexChanged, AddressOf Me.ChangeProperty

      '            ''AddHandler txtReceivingDate.Validated, AddressOf Me.ChangeProperty
      '            ''AddHandler dtpReceivingDate.ValueChanged, AddressOf Me.ChangeProperty

      '            ''AddHandler txtCreditPrd.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty 'Todo: .... จะแก้ได้หรือปล่าว
      AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      '            ''AddHandler txtRetentionNote.TextChanged, AddressOf Me.ChangeProperty
      '            ''AddHandler txtRetention.Validated, AddressOf Me.TextHandler
      '            ''AddHandler txtRetention.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealGross.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealGross.Validated, AddressOf Me.TextHandler

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.TextHandler
    End Sub
    Private m_dateSetting As Boolean = False
    Private m_dueSetting As Boolean = False
    Private m_startDateSetting As Boolean = False
    Private m_endDateSetting As Boolean = False

    Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    Private CCCodeBlankFlag As Boolean = False

    Private ccCodeChanged As Boolean = False
    Private subContractorChanged As Boolean = False
    Private directorCodeChanged As Boolean = False
    Private txtcreditprdChanged As Boolean = False
    Private txtWRCodeChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower

        Case "txtrequestorcode"
          directorCodeChanged = True
        Case "txtcostcentercode"
          ccCodeChanged = True
        Case "txtsubcontractorcode"
          subContractorChanged = True
        Case "txtcostcentercode"
          ccCodeChanged = True
        Case "txtcredit"
          txtcreditprdChanged = True
        Case "txtwrcode"
          txtWRCodeChanged = True
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
      Me.m_oldCode = Me.m_entity.Code
      oldCCId = Me.m_entity.CostCenter.Id
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()
      Me.InitialCombo()

      Me.chkClosed.Checked = Me.m_entity.Closed

      If Me.m_entity.Closed Then
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosedCancel}")
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosed}")
      End If

      'Me.SetColumnOriginQty()

      If Not Me.m_entity.WR Is Nothing Then
        Me.txtWRCode.Text = Me.m_entity.WR.Code
      End If

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtCredit.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)

      txtStartDate.Text = MinDateToNull(Me.m_entity.StartDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpStartDate.Value = MinDateToNow(Me.m_entity.StartDate)
      txtEndDate.Text = MinDateToNull(Me.m_entity.EndDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpEndDate.Value = MinDateToNow(Me.m_entity.EndDate)


      txtSubContractorCode.Text = m_entity.SubContractor.Code
      txtSubContractorName.Text = m_entity.SubContractor.Name

      txtCostCenterCode.Text = m_entity.CostCenter.Code
      txtCostCenterName.Text = m_entity.CostCenter.Name

      txtDirectorCode.Text = m_entity.Director.Code
      txtDirectorName.Text = m_entity.Director.Name
      txtNote.Text = m_entity.Note

      If Not m_entity.SubContractor Is Nothing Then
        For itemIndex As Integer = 0 To Me.cmbContact.Items.Count - 1
          If Me.m_entity.ContactPerson = Me.cmbContact.Items(itemIndex) Then
            Me.cmbContact.SelectedIndex = itemIndex
          End If
        Next
      End If

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next

      txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)
      txtAdvancePay.Text = Configuration.FormatToString(m_entity.AdvancePay, DigitConfig.Price)
      'txtWitholdingTax.Text = Configuration.FormatToString(m_entity.WitholdingTax, DigitConfig.Price)

      RefreshDocs()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Or e.Name = "QtyChanged" Then
        If e.Name = "QtyChanged" Then
          Me.UpdateAmount()
        End If
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub

    Private Sub SetCCCodeBlankFlag()
      If Me.txtCostCenterCode.Text.Length = 0 Then
        CCCodeBlankFlag = True
      Else
        CCCodeBlankFlag = False
      End If
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        Case "txtcredit"
          If txtcreditprdChanged Then
            txtcreditprdChanged = False
            Dim txt As String = Me.txtCredit.Text
            If txt.Length > 0 AndAlso IsNumeric(txt) Then
              Me.m_entity.CreditPeriod = CInt(txt)
            Else
              Me.m_entity.CreditPeriod = 0
            End If
            txtCredit.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
            Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
            Me.dtpDueDate.Value = Me.m_entity.DueDate
            dirtyFlag = True
          End If
        Case "cmbcontact"
          Me.m_entity.ContactPerson = cmbContact.Text
          dirtyFlag = True
        Case "txtsubcontractorcode"
          dirtyFlag = Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.SubContractor, True)
          m_isInitialized = False
          Me.txtCredit.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
          Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
          m_isInitialized = True
          InitialCombo()
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
              ' Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
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
              'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "dtpduedate"
          If Not Me.m_entity.DueDate.Equals(dtpDueDate.Value) Then
            If Not m_dueSetting Then
              Me.txtDueDate.Text = MinDateToNull(dtpDueDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DueDate = dtpDueDate.Value
              ' Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              Me.txtCredit.Text = Me.m_entity.CreditPeriod
              dirtyFlag = True
            End If
          End If
        Case "txtduedate"
          m_dueSetting = True
          If Not Me.txtDueDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDueDate.Text)
            If Not Me.m_entity.DueDate.Equals(theDate) Then
              dtpDueDate.Value = theDate
              Me.m_entity.DueDate = dtpDueDate.Value
              'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              Me.txtCredit.Text = Me.m_entity.CreditPeriod
              dirtyFlag = True
            End If
          Else
            Me.dtpDueDate.Value = Date.Now
            Me.m_entity.DueDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dueSetting = False

        Case "dtpstartdate"
          If Not Me.m_entity.StartDate.Equals(dtpStartDate.Value) Then
            If Not m_startDateSetting Then
              Me.txtStartDate.Text = MinDateToNull(dtpStartDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.StartDate = dtpStartDate.Value
              dirtyFlag = True
            End If
          End If
        Case "txtstartdate"
          m_startDateSetting = True
          If Not Me.txtStartDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtStartDate) = "" Then
            Dim theDate As Date = CDate(Me.txtStartDate.Text)
            If Not Me.m_entity.StartDate.Equals(theDate) Then
              dtpStartDate.Value = theDate
              Me.m_entity.StartDate = dtpStartDate.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpStartDate.Value = Date.Now
            Me.m_entity.StartDate = Date.MinValue
            dirtyFlag = True
          End If
          m_startDateSetting = False
        Case "dtpenddate"
          If Not Me.m_entity.EndDate.Equals(dtpEndDate.Value) Then
            If Not m_endDateSetting Then
              Me.txtEndDate.Text = MinDateToNull(dtpEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.EndDate = dtpEndDate.Value
              dirtyFlag = True
            End If
          End If
        Case "txtenddate"
          m_endDateSetting = True
          If Not Me.txtEndDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtEndDate) = "" Then
            Dim theDate As Date = CDate(Me.txtEndDate.Text)
            If Not Me.m_entity.EndDate.Equals(theDate) Then
              dtpEndDate.Value = theDate
              Me.m_entity.EndDate = dtpEndDate.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpEndDate.Value = Date.Now
            Me.m_entity.EndDate = Date.MinValue
            dirtyFlag = True
          End If
          m_endDateSetting = False
        Case "txtretention"
          If IsNumeric(txtRetention.Text) Then
            dirtyFlag = True
            m_entity.Retention = txtRetention.Text
            txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)
          Else
            txtRetention.Text = Configuration.FormatToString(0, DigitConfig.Price)
          End If
        Case "txtadvancepay"
          If IsNumeric(txtAdvancePay.Text) Then
            dirtyFlag = True
            m_entity.AdvancePay = txtAdvancePay.Text
            txtAdvancePay.Text = Configuration.FormatToString(m_entity.AdvancePay, DigitConfig.Price)
          Else
            txtAdvancePay.Text = Configuration.FormatToString(0, DigitConfig.Price)
          End If
          'Case "txtwitholdingtax"
          'dirtyFlag = True
          'm_entity.WitholdingTax = txtWitholdingTax.Text
        Case "txttaxbase"
          '                    'Todo
        Case "txtdiscountrate"
          Me.m_entity.Discount.Rate = txtDiscountRate.Text
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount()
          dirtyFlag = True
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Me.m_entity.TaxType.Value = item.Id
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount()
          dirtyFlag = True
        Case "txtdirectorcode"
          If directorCodeChanged Then
            dirtyFlag = Employee.GetEmployee(txtDirectorCode, txtDirectorName, Me.m_entity.Director)
            directorCodeChanged = False
          End If
        Case "txtcostcentercode"
          If ccCodeChanged Then
            dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            'If Me.txtRequestorName.TextLength = 0 Then
            '  UpdateDestAdmin()
            'End If
            ccCodeChanged = False
          End If
        Case "txtwrcode"
          If txtWRCodeChanged Then
            Dim wrCode As String = txtWRCode.Text
            If Me.m_entity.WR.Code = wrCode Then
              Return
            End If
            If Me.m_entity.ItemCollection.Count > 0 Then
              If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeWRCode}") Then
                dirtyFlag = WR.Getwr(txtWRCode, Me.m_entity.WR)
                SetWRToNothing(wrCode)
              Else
                Me.txtWRCode.Text = Me.m_entity.WR.Code
                SetWRToNothing(wrCode)
              End If
            Else
              dirtyFlag = WR.Getwr(txtWRCode, Me.m_entity.WR)
              SetWRToNothing(wrCode)
            End If
            txtWRCodeChanged = False
            RefreshDocs()
            UpdateEntityProperties()
            'UpdateAmount()
          End If
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
      SetCCCodeBlankFlag()
    End Sub
    Private Sub SetWRToNothing(ByVal WRCode As String)
      If WRCode.Length = 0 Then
        Me.m_entity.WR = New WR
      End If
    End Sub
    Private Sub ibtnResetGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetGross.Click
      If Me.m_entity.RealGross <> Me.m_entity.Gross Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealGross = Me.m_entity.Gross
      UpdateAmount()
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
    Private forceUpdateGross As Boolean = False
    Private forceUpdateTaxAmount As Boolean = False
    Private Sub UpdateAmount()
      'มูลค่ารวมของเอกสาร
      m_isInitialized = False
      Me.m_entity.RefreshTaxBase()

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
      txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
      txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)

      txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)

      txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
      txtDiscountRate.Text = m_entity.Discount.Rate
      txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
      txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)

      txtRealGross.Text = Configuration.FormatToString(m_entity.RealGross, DigitConfig.Price)
      txtRealTaxAmount.Text = Configuration.FormatToString(m_entity.RealTaxAmount, DigitConfig.Price)
      txtRealTaxBase.Text = Configuration.FormatToString(m_entity.RealTaxBase, DigitConfig.Price)

      m_isInitialized = True
      'RefreshWBS()
    End Sub
    Private Sub InitialCombo()
      If Not m_entity.SubContractor Is Nothing Then
        Me.cmbContact.Items.Clear()

        Me.cmbContact.Items.Add(Me.m_entity.SubContractor.Contact)
        For Each citem As SupplierContact In Me.m_entity.SubContractor.ContactCollection
          Me.cmbContact.Items.Add(citem.Name)
        Next
      End If
      If Me.cmbContact.Items.Count > 0 Then
        Me.cmbContact.SelectedIndex = 0
      End If
    End Sub
    Public Sub SetStatus()
      If m_entity.Canceled Then
        lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name
      ElseIf m_entity.Edited Then
        lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
        lblStatus.Text &= ",แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name
      ElseIf Me.m_entity.Originated Then
        lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
      Else
        lblStatus.Text = ""
      End If
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
        Me.m_entity = CType(Value, SC)
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
        Dim Vattype As Object = Configuration.GetConfig("CompanyTaxType")
        If IsNumeric(Vattype) Then
          cmbTaxType.SelectedIndex = CInt(Vattype)
        End If
        'cmbTaxType.Items.RemoveAt(1)
      End If
    End Sub
#End Region

#Region "Event Handler"
    'Private currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      ' If tgItem.CurrentRowIndex <> currentY Then
      Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
      Me.m_entity.ItemCollection.CurrentRealItem = Me.CurrentRealTagItem
      'RefreshWBS()
      ' currentY = tgItem.CurrentRowIndex
      ' End If
    End Sub
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDown
        BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
        If Me.cmbCode.Items.Count > 0 Then
          Me.cmbCode.SelectedIndex = 0
        End If
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New SCItem
        'doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
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
    Private m_targetType As Integer
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      m_targetType = -1
      If doc Is Nothing Then
        Return
        'doc = New SCItem
        ''doc.ItemType = New ItemType(0)
        'Me.m_entity.ItemCollection.Add(doc)
        'Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      If doc.ItemType.Value = 19 Or doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
        m_targetType = doc.ItemType.Value
        Dim entities(1) As ISimpleEntity
        entities(0) = New LCIItem
        entities(1) = New Tool
        Dim activeIndex As Integer = -1
        If Not doc.ItemType Is Nothing Then
          If doc.ItemType.Value = 19 Then
            activeIndex = 1
          ElseIf doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
            activeIndex = 0
          End If
        End If
        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, activeIndex)
      End If
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      'If tgItem.CurrentRowIndex = 0 Then
      '  'Hack
      '  tgItem.CurrentRowIndex = 1
      'End If
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
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      dirtyFlag = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      'Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentRealItem
      If doc Is Nothing Then
        Return
      End If
      'If Not doc.SCItem Is Nothing Then
      '    Return
      'End If
      'Dim newItem As New BlankItem("")
      Dim theItem As New SCItem
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
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      'If Not doc.SCItem Is Nothing Then
      '    Return
      'End If
      Dim newItem As New BlankItem("")
      Dim theItem As New SCItem
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
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      If Not Me.m_entity.ItemCollection.Contains(doc) Then
        Return
      End If

      'Me.m_entity.ItemCollection.Remove(doc)

      Dim index As Integer = tgItem.CurrentRowIndex
      Dim isSetIndex As Boolean = False

      Dim hashParent As New Hashtable

      Dim rowIndex As Integer = 0
      Dim key As String = ""

      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing Then
          Dim row As TreeRow = CType(Obj, TreeRow)
          If Not row Is Nothing Then
            If Not isSetIndex Then
              index = row.Index
              isSetIndex = True
            End If
            Dim sitem As SCItem = CType(row.Tag, SCItem)
            If sitem.Level = 0 Then
              rowIndex += 1
              key = rowIndex.ToString
              hashParent.Add(key, sitem)

              Dim startIndex As Integer = row.Index
              Dim lastIndex As Integer = row.Index
              For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
                If i > startIndex Then
                  Dim sitem2 As SCItem = Me.m_entity.ItemCollection(i)
                  If sitem2.Level = 0 Then
                    Exit For
                  End If
                  rowIndex += 1
                  key = rowIndex.ToString
                  hashParent.Add(key, sitem2)
                End If
              Next
            Else
              rowIndex += 1
              key = rowIndex.ToString
              hashParent.Add(key, sitem)
            End If
          End If
        End If
      Next

      For i As Integer = 1 To hashParent.Count
        key = CStr(i)
        Dim sitem As SCItem = CType(hashParent(key), SCItem)
        If Not sitem Is Nothing Then
          If Me.m_entity.ItemCollection.Contains(sitem) Then
            Me.m_entity.ItemCollection.Remove(sitem)
            Me.WorkbenchWindow.ViewContent.IsDirty = True
          End If
        End If
      Next

      'Dim row As TreeRow = Me.m_treeManager.SelectedRow

      'Dim lastIndex As Integer = row.Index
      'Dim startIndex As Integer = row.Index

      'For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
      '  If i > startIndex Then
      '    If CType(Me.m_treeManager.Treetable.Childs(i).Tag, SCItem).Level = 0 Then
      '      Exit For
      '    End If
      '    lastIndex = i
      '  End If
      'Next

      'If lastIndex = startIndex Then
      '  Me.m_entity.ItemCollection.Remove(doc)
      'Else
      '  For i As Integer = startIndex To lastIndex
      '    Me.m_entity.ItemCollection.Remove(i)
      '  Next
      'End If

      'Dim rowsCount As Integer = 0
      'For Each Obj As Object In Me.m_treeManager.SelectedRows
      '  If Not Obj Is Nothing Then
      '    rowsCount += 1
      '    Dim row As TreeRow = CType(Obj, TreeRow)
      '    If row.Childs.Count > 0 Then
      '      For Each childRow As TreeRow In row.Childs
      '        If Not childRow Is Nothing Then
      '          Dim doc As SCItem = CType(childRow.Tag, SCItem)
      '          If Not doc Is Nothing Then
      '            Me.m_entity.ItemCollection.Remove(doc) 'ลบลูก ๆ
      '          End If
      '        End If
      '      Next
      '    End If
      '    If Not row Is Nothing Then
      '      If TypeOf row.Tag Is SCItem Then
      '        Dim doc As SCItem = CType(row.Tag, SCItem)
      '        If Not doc Is Nothing Then
      '          If Me.m_entity.ItemCollection.Contains(doc) Then
      '            Me.m_entity.ItemCollection.Remove(doc) 'ลบแม่ ๆ
      '          End If
      '        End If
      '      End If
      '    End If
      '  End If
      'Next

      'If rowsCount.Equals(0) Then
      '  Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      '  If doc Is Nothing Then
      '    Return
      '  End If
      '  Me.m_entity.ItemCollection.Remove(doc)
      'End If


      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()


      If index > 0 Then
        If index > Me.m_entity.ItemCollection.Count Then
          tgItem.CurrentRowIndex = Me.m_entity.ItemCollection.Count - 1
        Else
          tgItem.CurrentRowIndex = index - 1
        End If
      Else
        tgItem.CurrentRowIndex = 0
      End If

      'Me.WorkbenchWindow.ViewContent.IsDirty = True
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
        Return (New SC).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Requestor
    Private Sub btnDirectorEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectorEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(Me.m_entity.Director)
    End Sub
    Private Sub btnRequestorFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectorFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(Me.m_entity.Director, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtDirectorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtDirectorCode, txtDirectorName, Me.m_entity.Director)
    End Sub
    ' WR
    Private Sub btnWRFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWRFind.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If Me.m_entity.ItemCollection.Count > 0 Then
        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeWRCode}") Then
          myEntityPanelService.OpenListDialog(Me.m_entity.WR, AddressOf SetWRDialog)
        End If
      Else
        myEntityPanelService.OpenListDialog(Me.m_entity.WR, AddressOf SetWRDialog)
      End If
    End Sub
    Private Sub SetWRDialog(ByVal e As ISimpleEntity)
      Me.txtWRCode.Text = e.Code
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Me.WorkbenchWindow.ViewContent.IsDirty = WR.Getwr(txtWRCode, Me.m_entity.WR)

      RefreshDocs()
      'UpdateAmount()
      UpdateEntityProperties()
    End Sub
    ' Costcenter
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(Me.m_entity.CostCenter, AddressOf SetCostCenterDialog)
    End Sub
    Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
      If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
          If Me.txtCostCenterCode.TextLength = 0 Then
            Me.m_entity.CostCenter = New CostCenter
          End If
          Me.txtCostCenterCode.Text = e.Code
          dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          If dirtyFlag Then
            'UpdateDestAdmin()
          End If
          Try
            If oldCCId <> Me.m_entity.CostCenter.Id Then
              Me.WorkbenchWindow.ViewContent.IsDirty = True
              oldCCId = Me.m_entity.CostCenter.Id
              ChangeCC()
            End If
          Catch ex As Exception
          End Try
          ccCodeChanged = False
        Else
          Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
          ccCodeChanged = False
        End If
      ElseIf Me.txtCostCenterCode.Text.Length = 0 Then
        Me.txtCostCenterCode.Text = e.Code
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        If dirtyFlag Then
          'UpdateDestAdmin()
        End If
      End If
      SetCCCodeBlankFlag()
    End Sub
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(Me.m_entity.CostCenter)
    End Sub
    'Private Sub CheckToggleCostCenter()
    'If Me.m_entity.WR Is Nothing OrElse Me.m_entity.WR.Id = 0 Then
    'Me.txtCostCenterCode.Enabled = True
    'Me.btnCCFind.Enabled = True
    'Else
    'Me.txtCostCenterCode.Enabled = False
    'Me.btnCCFind.Enabled = False
    'End If
    'End Sub
    Private Sub ChangeCC()
      'For Each item As SCItem In Me.m_entity.ItemCollection
      '    item.WBSDistributeCollection.Clear()
      'Next
      'RefreshWBS()

    End Sub
    'Private Sub UpdateDestAdmin()
    '  If Me.m_entity Is Nothing Then
    '    Return
    '  End If
    '  Dim flag As Boolean = Me.m_isInitialized
    '  Me.m_isInitialized = False
    '  Try
    '            Me.m_entity.Director = Me.m_entity.CostCenter.Admin
    '            Me.txtDirectorCode.Text = m_entity.Director.Code
    '            txtDirectorName.Text = m_entity.Director.Name
    '  Catch ex As Exception
    '  Finally
    '    Me.m_isInitialized = flag
    '  End Try
    'End Sub
    '        Private Sub ibtnShowPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '            Dim dlg As New BasketDialog
    '            AddHandler dlg.EmptyBasket, AddressOf SetItems

    '            Dim filters(4) As Filter
    '            Dim excludeList As Object = ""
    '            excludeList = GetPRExcludeList()
    '            If excludeList.ToString.Length = 0 Then
    '                excludeList = DBNull.Value
    '            End If
    '            Dim prNeedsApproval As Boolean = False
    '            Dim prNeedsStoreApproval As Boolean = False
    '            prNeedsApproval = CBool(Configuration.GetConfig("ApprovePR"))
    '            prNeedsStoreApproval = CBool(Configuration.GetConfig("PRNeedStoreApprove"))
    '            filters(0) = New Filter("excludeList", excludeList)
    '            filters(1) = New Filter("prNeedsApproval", prNeedsApproval)
    '            filters(2) = New Filter("excludeCanceled", True)
    '            filters(3) = New Filter("PRNeedStoreApprove", prNeedsStoreApproval)
    '            filters(4) = New Filter("formEntity", Me.m_entity.EntityId)

    '            Dim Entities As New ArrayList
    '            If Not Me.m_entity.CostCenter Is Nothing AndAlso Me.m_entity.CostCenter.Originated Then
    '                Entities.Add(Me.m_entity.CostCenter)
    '            End If

    '            Dim view As AbstractEntityPanelViewContent = New PRSelectionView(New PR, New BasketDialog, filters, Entities)
    '            dlg.Lists.Add(view)
    '            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
    '            myDialog.ShowDialog()
    '        End Sub
    '        Private Function GetPRExcludeList() As String
    '            Dim ret As String = ""
    '            For Each item As SCItem In Me.m_entity.ItemCollection
    '                If Not item.SCItem Is Nothing Then
    '                    ret &= "|" & item.SCItem.Pr.Id.ToString & ":" & item.SCItem.LineNumber.ToString & "|"
    '                End If
    '            Next
    '            Return ret
    '        End Function
    Private Sub ibtnGetFromBOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnGetFromBOQ.Click
      Dim arr As New ArrayList
      arr.Add(Me.m_entity.CostCenter)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BOQWBSForSelection, AddressOf SetItems, arr)
    End Sub

    ' Supplier
    Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubContractorEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubContractorFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    End Sub
    Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
      Me.txtSubContractorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.SubContractor, True)
      m_isInitialized = False
      Me.txtCredit.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
      m_isInitialized = True
      InitialCombo()
    End Sub
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
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
              Me.SetSupplierDialog(entity)
          End Select
        End If
      End If
    End Sub
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
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex

      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentRealItem
      'If doc Is Nothing Then
      '  Return
      'End If
      ''If Not doc.SCItem Is Nothing Then
      ''    Return
      ''End If
      ''Dim newItem As New BlankItem("")
      'Dim theItem As New SCItem
      ''theItem.Entity = newItem
      'theItem.Level = 0
      ''theItem.ItemType = New ItemType(0)
      'theItem.Qty = 0
      'Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      'RefreshDocs()
      'tgItem.CurrentRowIndex = index + 1
      'Me.WorkbenchWindow.ViewContent.IsDirty = True

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        'Me.m_treeManager.Treetable.Childs.Add()
        Dim newRow As TreeRow
        newRow = Me.m_treeManager.Treetable.Childs.Add()
        newRow("sci_level") = 0
        newRow("Button") = "invisible"
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        'Me.m_treeManager.Treetable.Childs.Add()
        Dim newRow As TreeRow
        newRow = Me.m_treeManager.Treetable.Childs.Add()
        newRow("sci_level") = 0
        newRow("Button") = "invisible"
      End If

      'For rowIndex As Integer = 0 To Me.m_treeManager.Treetable.Rows.Count
      '  Dim n As TreeRow = Me.m_treeManager.Treetable.Childs(rowIndex)
      '  If n("sci_level") = 0 Then
      '    Me.tgItem.TableStyles(0).GridColumnStyles(0).c()
      '  End If
      'Next

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
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
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosedCancel}")
        If Not Me.m_entity.Closed Then
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        Else
          Me.WorkbenchWindow.ViewContent.IsDirty = False
        End If
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosed}")
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
      'Me.RefreshWBS()


    End Sub

#Region "Customization"
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Try
          Dim approveDocColl As New ApproveDocCollection(m_entity)
          Dim poNeedsApproval As Boolean = CBool(Configuration.GetConfig("POApproveBeforePrint"))
          If poNeedsApproval Then
            If Not approveDocColl.IsApproved Then
              Return False
            End If
          End If
        Catch ex As Exception
        End Try
        Return MyBase.CanPrint
      End Get
    End Property
#End Region

  End Class
End Namespace

