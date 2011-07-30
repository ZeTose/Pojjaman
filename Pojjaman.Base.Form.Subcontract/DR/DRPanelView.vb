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
  Public Class DRPanelView
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
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
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
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
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
    Friend WithEvents lbltoCC As System.Windows.Forms.Label
    Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents lblSCCode As System.Windows.Forms.Label
    Friend WithEvents txtSubContractorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSubContractorName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowSCDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSubcontractDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkClosed As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DRPanelView))
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
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.txtSubContractorCode = New System.Windows.Forms.TextBox()
      Me.txtSubContractorName = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtSCCode = New System.Windows.Forms.TextBox()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.txtRealGross = New System.Windows.Forms.TextBox()
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox()
      Me.txtFromCCPersonName = New System.Windows.Forms.TextBox()
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnSubcontractDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkClosed = New System.Windows.Forms.CheckBox()
      Me.lblSCCode = New System.Windows.Forms.Label()
      Me.ibtnShowSCDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblTaxBase = New System.Windows.Forms.Label()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblPercent = New System.Windows.Forms.Label()
      Me.lbltoCC = New System.Windows.Forms.Label()
      Me.ibtnShowFromCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowFromCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblFromCostCenter = New System.Windows.Forms.Label()
      Me.lblFromCCPerson = New System.Windows.Forms.Label()
      Me.ibtnShowFromCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowFromCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton()
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
      Me.tgItem.Size = New System.Drawing.Size(824, 278)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(33, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 18)
      Me.lblCode.TabIndex = 11
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(496, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(160, 21)
      Me.dtpDocDate.TabIndex = 59
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(432, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(64, 18)
      Me.lblDocDate.TabIndex = 14
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGross.BackColor = System.Drawing.Color.Transparent
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(312, 424)
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
      Me.txtGross.Location = New System.Drawing.Point(392, 424)
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
      Me.lblBeforeTax.Location = New System.Drawing.Point(280, 448)
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
      Me.txtBeforeTax.Location = New System.Drawing.Point(392, 448)
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(176, 21)
      Me.txtBeforeTax.TabIndex = 54
      Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(568, 448)
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
      Me.txtTaxAmount.Location = New System.Drawing.Point(656, 448)
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
      Me.lblAfterTax.Location = New System.Drawing.Point(584, 472)
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
      Me.txtAfterTax.Location = New System.Drawing.Point(656, 472)
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(176, 21)
      Me.txtAfterTax.TabIndex = 58
      Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbTaxType
      '
      Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(656, 424)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(72, 21)
      Me.cmbTaxType.TabIndex = 43
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(576, 424)
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
      Me.txtTaxRate.Location = New System.Drawing.Point(784, 424)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, False)
      Me.txtTaxRate.Size = New System.Drawing.Size(48, 21)
      Me.txtTaxRate.TabIndex = 45
      Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(720, 424)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
      Me.lblTaxRate.TabIndex = 44
      Me.lblTaxRate.Text = "อัตราภาษี :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSupplier
      '
      Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(49, 64)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(72, 18)
      Me.lblSupplier.TabIndex = 20
      Me.lblSupplier.Text = "ผู้รับเหมา:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSubContractorCode
      '
      Me.Validator.SetDataType(Me.txtSubContractorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorCode, System.Drawing.Color.Empty)
      Me.txtSubContractorCode.Location = New System.Drawing.Point(121, 64)
      Me.txtSubContractorCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtSubContractorCode, "")
      Me.txtSubContractorCode.Name = "txtSubContractorCode"
      Me.Validator.SetRegularExpression(Me.txtSubContractorCode, "")
      Me.Validator.SetRequired(Me.txtSubContractorCode, True)
      Me.txtSubContractorCode.Size = New System.Drawing.Size(72, 21)
      Me.txtSubContractorCode.TabIndex = 4
      '
      'txtSubContractorName
      '
      Me.txtSubContractorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSubContractorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.txtSubContractorName.Location = New System.Drawing.Point(193, 64)
      Me.Validator.SetMinValue(Me.txtSubContractorName, "")
      Me.txtSubContractorName.Name = "txtSubContractorName"
      Me.txtSubContractorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSubContractorName, "")
      Me.Validator.SetRequired(Me.txtSubContractorName, False)
      Me.txtSubContractorName.Size = New System.Drawing.Size(168, 21)
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
      Me.txtNote.Location = New System.Drawing.Point(12, 441)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(216, 48)
      Me.txtNote.TabIndex = 7
      Me.txtNote.WordWrap = False
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(10, 418)
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
      Me.lblStatus.Location = New System.Drawing.Point(200, 117)
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
      Me.txtDocDate.Location = New System.Drawing.Point(496, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(136, 21)
      Me.txtDocDate.TabIndex = 1
      '
      'txtSCCode
      '
      Me.Validator.SetDataType(Me.txtSCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSCCode, "")
      Me.txtSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSCCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.txtSCCode.Location = New System.Drawing.Point(121, 40)
      Me.Validator.SetMinValue(Me.txtSCCode, "")
      Me.txtSCCode.Name = "txtSCCode"
      Me.Validator.SetRegularExpression(Me.txtSCCode, "")
      Me.Validator.SetRequired(Me.txtSCCode, False)
      Me.txtSCCode.Size = New System.Drawing.Size(160, 21)
      Me.txtSCCode.TabIndex = 334
      Me.txtSCCode.TabStop = False
      '
      'txtTaxBase
      '
      Me.txtTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.txtTaxBase.Location = New System.Drawing.Point(392, 472)
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(80, 21)
      Me.txtTaxBase.TabIndex = 56
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealGross
      '
      Me.txtRealGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.txtRealGross.Location = New System.Drawing.Point(496, 424)
      Me.Validator.SetMinValue(Me.txtRealGross, "")
      Me.txtRealGross.Name = "txtRealGross"
      Me.Validator.SetRegularExpression(Me.txtRealGross, "")
      Me.Validator.SetRequired(Me.txtRealGross, False)
      Me.txtRealGross.Size = New System.Drawing.Size(72, 21)
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
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(760, 448)
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(72, 21)
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
      Me.txtRealTaxBase.Location = New System.Drawing.Point(496, 472)
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(72, 21)
      Me.txtRealTaxBase.TabIndex = 62
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtFromCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(496, 40)
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, True)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(64, 21)
      Me.txtFromCostCenterCode.TabIndex = 0
      '
      'txtFromCCPersonCode
      '
      Me.Validator.SetDataType(Me.txtFromCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(496, 64)
      Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonCode, True)
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(64, 21)
      Me.txtFromCCPersonCode.TabIndex = 1
      '
      'txtFromCCPersonName
      '
      Me.Validator.SetDataType(Me.txtFromCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(560, 64)
      Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(168, 21)
      Me.txtFromCCPersonName.TabIndex = 3
      Me.txtFromCCPersonName.TabStop = False
      '
      'txtFromCostCenterName
      '
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(560, 40)
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(168, 21)
      Me.txtFromCostCenterName.TabIndex = 2
      Me.txtFromCostCenterName.TabStop = False
      '
      'txtToCostCenterName
      '
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(193, 88)
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.txtToCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(168, 21)
      Me.txtToCostCenterName.TabIndex = 12
      Me.txtToCostCenterName.TabStop = False
      '
      'txtToCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(121, 88)
      Me.txtToCostCenterCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, False)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(72, 21)
      Me.txtToCostCenterCode.TabIndex = 4
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(16, 117)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(120, 18)
      Me.lblItem.TabIndex = 33
      Me.lblItem.Text = "รายการหักค่าใช้จ่าย"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.btnCostCenterDialog)
      Me.grbDetail.Controls.Add(Me.btnSubcontractDialog)
      Me.grbDetail.Controls.Add(Me.btnApprove)
      Me.grbDetail.Controls.Add(Me.chkClosed)
      Me.grbDetail.Controls.Add(Me.lblSCCode)
      Me.grbDetail.Controls.Add(Me.txtSCCode)
      Me.grbDetail.Controls.Add(Me.ibtnShowSCDialog)
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
      Me.grbDetail.Controls.Add(Me.lblBeforeTax)
      Me.grbDetail.Controls.Add(Me.txtSubContractorName)
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
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.cmbTaxType)
      Me.grbDetail.Controls.Add(Me.lblTaxType)
      Me.grbDetail.Controls.Add(Me.txtTaxRate)
      Me.grbDetail.Controls.Add(Me.lblTaxRate)
      Me.grbDetail.Controls.Add(Me.lblSupplier)
      Me.grbDetail.Controls.Add(Me.txtSubContractorCode)
      Me.grbDetail.Controls.Add(Me.txtTaxBase)
      Me.grbDetail.Controls.Add(Me.lblTaxBase)
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.Controls.Add(Me.lblPercent)
      Me.grbDetail.Controls.Add(Me.lbltoCC)
      Me.grbDetail.Controls.Add(Me.txtToCostCenterName)
      Me.grbDetail.Controls.Add(Me.ibtnShowFromCostCenterDialog)
      Me.grbDetail.Controls.Add(Me.ibtnShowFromCostCenter)
      Me.grbDetail.Controls.Add(Me.lblFromCostCenter)
      Me.grbDetail.Controls.Add(Me.lblFromCCPerson)
      Me.grbDetail.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbDetail.Controls.Add(Me.txtFromCCPersonCode)
      Me.grbDetail.Controls.Add(Me.txtFromCCPersonName)
      Me.grbDetail.Controls.Add(Me.txtFromCostCenterName)
      Me.grbDetail.Controls.Add(Me.ibtnShowFromCCPersonDialog)
      Me.grbDetail.Controls.Add(Me.ibtnShowFromCCPerson)
      Me.grbDetail.Controls.Add(Me.txtToCostCenterCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(0, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(840, 504)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'btnCostCenterDialog
      '
      Me.btnCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostCenterDialog.Location = New System.Drawing.Point(358, 86)
      Me.btnCostCenterDialog.Name = "btnCostCenterDialog"
      Me.btnCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnCostCenterDialog.TabIndex = 349
      Me.btnCostCenterDialog.TabStop = False
      Me.btnCostCenterDialog.ThemedImage = CType(resources.GetObject("btnCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnSubcontractDialog
      '
      Me.btnSubcontractDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSubcontractDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSubcontractDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSubcontractDialog.Location = New System.Drawing.Point(358, 63)
      Me.btnSubcontractDialog.Name = "btnSubcontractDialog"
      Me.btnSubcontractDialog.Size = New System.Drawing.Size(24, 23)
      Me.btnSubcontractDialog.TabIndex = 348
      Me.btnSubcontractDialog.TabStop = False
      Me.btnSubcontractDialog.ThemedImage = CType(resources.GetObject("btnSubcontractDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnApprove
      '
      Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApprove.ForeColor = System.Drawing.Color.Black
      Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnApprove.Location = New System.Drawing.Point(728, 114)
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
      Me.chkClosed.Location = New System.Drawing.Point(664, 16)
      Me.chkClosed.Name = "chkClosed"
      Me.chkClosed.Size = New System.Drawing.Size(80, 21)
      Me.chkClosed.TabIndex = 347
      Me.chkClosed.Text = "ปิด DR"
      Me.chkClosed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblSCCode
      '
      Me.lblSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSCCode.ForeColor = System.Drawing.Color.Black
      Me.lblSCCode.Location = New System.Drawing.Point(41, 40)
      Me.lblSCCode.Name = "lblSCCode"
      Me.lblSCCode.Size = New System.Drawing.Size(80, 18)
      Me.lblSCCode.TabIndex = 335
      Me.lblSCCode.Text = "เลขที่ SC:"
      Me.lblSCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowSCDialog
      '
      Me.ibtnShowSCDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowSCDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSCDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowSCDialog.Location = New System.Drawing.Point(281, 40)
      Me.ibtnShowSCDialog.Name = "ibtnShowSCDialog"
      Me.ibtnShowSCDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSCDialog.TabIndex = 336
      Me.ibtnShowSCDialog.TabStop = False
      Me.ibtnShowSCDialog.ThemedImage = CType(resources.GetObject("ibtnShowSCDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(121, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(160, 21)
      Me.cmbCode.TabIndex = 333
      '
      'ibtnResetGross
      '
      Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetGross.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetGross.Location = New System.Drawing.Point(472, 424)
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
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(736, 448)
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
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(472, 472)
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
      Me.chkAutorun.Location = New System.Drawing.Point(281, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 12
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(144, 113)
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
      Me.ibtnDelRow.Location = New System.Drawing.Point(168, 113)
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
      Me.lblTaxBase.Location = New System.Drawing.Point(256, 472)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(136, 18)
      Me.lblTaxBase.TabIndex = 55
      Me.lblTaxBase.Text = "มูลค่าหักค่าใช้จ่าย :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(303, 16)
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
      Me.lblPercent.Location = New System.Drawing.Point(816, 360)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 46
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbltoCC
      '
      Me.lbltoCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lbltoCC.Location = New System.Drawing.Point(8, 88)
      Me.lbltoCC.Name = "lbltoCC"
      Me.lbltoCC.Size = New System.Drawing.Size(113, 18)
      Me.lbltoCC.TabIndex = 4
      Me.lbltoCC.Text = "Cost Center:"
      Me.lbltoCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowFromCostCenterDialog
      '
      Me.ibtnShowFromCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowFromCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowFromCostCenterDialog.Location = New System.Drawing.Point(728, 40)
      Me.ibtnShowFromCostCenterDialog.Name = "ibtnShowFromCostCenterDialog"
      Me.ibtnShowFromCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCostCenterDialog.TabIndex = 4
      Me.ibtnShowFromCostCenterDialog.TabStop = False
      Me.ibtnShowFromCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowFromCostCenter
      '
      Me.ibtnShowFromCostCenter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenter.Location = New System.Drawing.Point(752, 40)
      Me.ibtnShowFromCostCenter.Name = "ibtnShowFromCostCenter"
      Me.ibtnShowFromCostCenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCostCenter.TabIndex = 7
      Me.ibtnShowFromCostCenter.TabStop = False
      Me.ibtnShowFromCostCenter.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.Location = New System.Drawing.Point(384, 40)
      Me.lblFromCostCenter.Name = "lblFromCostCenter"
      Me.lblFromCostCenter.Size = New System.Drawing.Size(112, 18)
      Me.lblFromCostCenter.TabIndex = 8
      Me.lblFromCostCenter.Text = "Cost Center ที่ให้เบิก:"
      Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.Location = New System.Drawing.Point(432, 64)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(64, 18)
      Me.lblFromCCPerson.TabIndex = 9
      Me.lblFromCCPerson.Text = "ผู้ให้เบิก:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowFromCCPersonDialog
      '
      Me.ibtnShowFromCCPersonDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowFromCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowFromCCPersonDialog.Location = New System.Drawing.Point(728, 64)
      Me.ibtnShowFromCCPersonDialog.Name = "ibtnShowFromCCPersonDialog"
      Me.ibtnShowFromCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCCPersonDialog.TabIndex = 5
      Me.ibtnShowFromCCPersonDialog.TabStop = False
      Me.ibtnShowFromCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowFromCCPerson
      '
      Me.ibtnShowFromCCPerson.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCCPerson.Location = New System.Drawing.Point(752, 64)
      Me.ibtnShowFromCCPerson.Name = "ibtnShowFromCCPerson"
      Me.ibtnShowFromCCPerson.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCCPerson.TabIndex = 6
      Me.ibtnShowFromCCPerson.TabStop = False
      Me.ibtnShowFromCCPerson.ThemedImage = CType(resources.GetObject("ibtnShowFromCCPerson.ThemedImage"), System.Drawing.Bitmap)
      '
      'DRPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "DRPanelView"
      Me.Size = New System.Drawing.Size(848, 512)
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
    Private m_entity As DR
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private dummyCC As New CostCenter
    Private dummyEmployee As New Employee

    'Private m_treeManager2 As TreeManager
    'Private m_wbsdInitialized As Boolean

    Private m_enableState As Hashtable
    Private m_readOnlyState As Hashtable
    Private m_tableStyleEnable As Hashtable
    Private m_supcontractor As Supplier
    'Private m_toCC As CostCenter
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim rs As ResourceService = CType(ServiceManager.Services.GetService(GetType(ResourceService)), ResourceService)
      Me.ibtnCopyMe.ThemedImage = rs.GetBitmap("Icons.16x16.Copy")

      SaveEnableState()

      Dim dt As TreeTable = DR.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf DRItemDelete


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
      dst.MappingName = "DR"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'DR Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "dri_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.LineNumberHeaderText}") '"No."
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "dri_linenumber"

      'Dim csBarrier As New DataGridBarrierColumn
      'csBarrier.MappingName = "Barrier"
      'csBarrier.HeaderText = ""
      'csBarrier.NullText = ""
      'csBarrier.ReadOnly = True

      '"รายละเอียด"
      Dim csDRDesc As New TreeTextColumn
      csDRDesc.MappingName = "dri_paDesc"
      csDRDesc.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.DescriptionHeaderText}")
      csDRDesc.NullText = ""
      csDRDesc.Width = 180
      csDRDesc.TextBox.Name = "dri_paDesc"

      '"ประเภท"
      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("dri_entityType" _
      , CodeDescription.GetCodeList("dri_entityType") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.TypeHeaderText}")
      csType.NullText = String.Empty

      '"รหัส"
      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      '"รายการ"
      Dim csName As New TreeTextColumn
      csName.MappingName = "dri_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.DeialHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "dri_itemName"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center


      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClicked


      '"ปริมาณ"
      Dim csQty As New TreeTextColumn
      csQty.MappingName = "dri_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "dri_qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      '"ราคา/หน่วย"
      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "dri_unitprice"
      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.UnitPriceHeaderTextt}") '"ราคาต่อหน่วย"
      csUnitPRice.NullText = ""
      csUnitPRice.TextBox.Name = "dri_unitprice"
      AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim csMat As New TreeTextColumn
      csMat.MappingName = "dri_mat"
      csMat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.MatHeaderText}")
      csMat.NullText = ""
      csMat.TextBox.Name = "dri_mat"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csLab As New TreeTextColumn
      csLab.MappingName = "dri_lab"
      csLab.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.LABHeaderText}")
      csLab.NullText = ""
      csLab.TextBox.Name = "dri_lab"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csEq As New TreeTextColumn
      csEq.MappingName = "dri_eq"
      csEq.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.EQHeaderText}")
      csEq.NullText = ""
      csEq.TextBox.Name = "dri_eq"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      '"รวม"
      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csReceivedAmount As New TreeTextColumn
      csReceivedAmount.MappingName = "ReceivedAmount"
      csReceivedAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.ReceivedAmountHeaderText}")
      csReceivedAmount.NullText = ""
      csReceivedAmount.TextBox.Name = "ReceivedAmount"
      csReceivedAmount.ReadOnly = True

      '"หมายเหตุ"
      Dim csNote As New TreeTextColumn
      csNote.MappingName = "dri_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "dri_note"


      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "dri_unvatable"
      csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.UnVatableHeaderText}")
      csVatable.Width = 100
      csVatable.InvisibleWhenUnspcified = True


      'dst.GridColumnStyles.Add(csDRDesc)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csBarrier1)
      dst.GridColumnStyles.Add(csMat)
      dst.GridColumnStyles.Add(csLab)
      dst.GridColumnStyles.Add(csEq)
      dst.GridColumnStyles.Add(csReceivedAmount)
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
    Private ReadOnly Property CurrentTagItem() As DRItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is DRItem Then
          Return Nothing
        End If
        Return (CType(row.Tag, DRItem))
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
      Dim doc As DRItem = Me.m_entity.ItemCollection.CurrentItem

      '    'If tick checkbox that not in the current hilight row
      If e.Column.ColumnName.ToLower = "dri_unvatable" Then
        Me.m_treeManager.SelectedRow = e.Row
        doc = Me.m_entity.ItemCollection.CurrentItem
      End If

      If doc Is Nothing Then
        doc = New DRItem
        doc.ItemType = New DRIItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc

      End If

      Try
        Select Case e.Column.ColumnName.ToLower
          Case "dri_entitytype"
            Dim value As DRIItemType
            If IsNumeric(e.ProposedValue) Then
              value = New DRIItemType(CInt(e.ProposedValue))
            End If
            doc.ItemType = value
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "dri_itemname"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.EntityName = CStr(e.ProposedValue)
          Case "unit"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            doc.Unit = myUnit
          Case "dri_qty"
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
          Case "dri_unitprice"
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
          Case "dri_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
            'Case "dri_unvatable"
            '  If IsDBNull(e.ProposedValue) Then
            '    e.ProposedValue = False
            '  End If
            '  doc.UnVatable = CBool(e.ProposedValue)
          Case "dri_mat"
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
          Case "dri_lab"
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
          Case "dri_eq"
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
          Case "dri_unvatable"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = False
            End If
            doc.UnVatable = CBool(e.ProposedValue)
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub DRItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "TreeTable Handlers"
    'Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '    If Not m_wbsdInitialized Then
    '        Return
    '    End If
    '    Dim index As Integer = Me.m_treeManager2.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
    '    If ValidateRow(CType(e.Row, TreeRow)) Then
    '        UpdateAmount(e)
    '        Me.m_treeManager2.Treetable.AcceptChanges()
    '    End If
    '    RefreshWBS()
    '    Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub
    'Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
    '    Dim item As WBSDistribute = Me.CurrentWsbsd
    '    If item Is Nothing Then
    '        Return
    '    End If
    '    Dim view As Integer = 6
    '    Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
    '    If doc Is Nothing Then
    '        Return
    '    End If
    '    e.Row("Amount") = Configuration.FormatToString(item.Percent * doc.BeforeTax / 100, DigitConfig.Price)
    '    If Not item.IsMarkup Then
    '        e.Row("BudgetRemain") = Configuration.FormatToString(item.WBS.GetTotal - item.WBS.GetActualTotal(Me.m_entity, view) + Me.m_entity.GetCurrentAmountForWBS(item.WBS, doc.ItemType), DigitConfig.Price)
    '        e.Row("QtyRemain") = Configuration.FormatToString(0 - item.WBS.GetActualTotalQty(Me.m_entity, view) - 0, DigitConfig.Price)
    '    Else
    '        Dim mk As Markup = Me.m_entity.CostCenter.Boq.MarkupCollection.GetMarkupFromId(item.WBS.Id)
    '        If Not mk Is Nothing Then
    '            e.Row("BudgetRemain") = Configuration.FormatToString(mk.TotalAmount - mk.GetActualTotal(Me.m_entity, view) - Me.m_entity.GetCurrentAmountForMarkup(mk), DigitConfig.Price)
    '        End If
    '    End If
    'End Sub
    'Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '    If Not m_wbsdInitialized Then
    '        Return
    '    End If
    '    Try
    '        Select Case e.Column.ColumnName.ToLower
    '            Case "wbs"
    '                SetCode(e)
    '            Case "percent"
    '                SetPercent(e)
    '        End Select
    '        ValidateRow(e)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub
    'Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
    '    Dim wbs As Object = e.Row("wbs")
    '    Dim percent As Object = e.Row("percent")

    '    Select Case e.Column.ColumnName.ToLower
    '        Case "wbs"
    '            wbs = e.ProposedValue
    '        Case "percent"
    '            percent = e.ProposedValue
    '        Case Else
    '            Return
    '    End Select

    '    Dim isBlankRow As Boolean = False
    '    If IsDBNull(wbs) Then
    '        isBlankRow = True
    '    End If

    '    If Not isBlankRow Then
    '        If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
    '            e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
    '        Else
    '            e.Row.SetColumnError("percent", "")
    '        End If
    '        If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
    '            e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
    '        Else
    '            e.Row.SetColumnError("wbs", "")
    '        End If
    '    End If

    'End Sub
    'Public Function ValidateRow(ByVal row As TreeRow) As Boolean
    '    If row.IsNull("WBS") Then
    '        Return False
    '    End If
    '    Return True
    'End Function
    'Private m_updating As Boolean = False
    'Public Sub SetPercent(ByVal e As DataColumnChangeEventArgs)
    '    If m_updating Then
    '        Return
    '    End If
    '    Dim item As WBSDistribute = Me.CurrentWsbsd
    '    If item Is Nothing Then
    '        Return
    '    End If
    '    If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
    '        e.ProposedValue = ""
    '        Return
    '    End If
    '    e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
    '    Dim value As Decimal = CDec(e.ProposedValue)
    '    Dim oldvalue As Decimal = 0
    '    If Not e.Row.IsNull(e.Column) Then
    '        oldvalue = CDec(e.Row(e.Column))
    '    End If
    '    Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
    '    If doc Is Nothing Then
    '        Return
    '    End If
    '    Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
    '    If wsdColl.GetSumPercent - oldvalue + value > 100 Then
    '        e.ProposedValue = e.Row(e.Column)
    '        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
    '        Return
    '    End If

    '    m_updating = True
    '    item.Percent = value
    '    m_updating = False
    'End Sub

    'Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
    '    If e.Row.IsNull("stocki_entityType") Then
    '        Return False
    '    End If
    '    If IsDBNull(e.ProposedValue) Then
    '        Return False
    '    End If
    '    For Each row As TreeRow In Me.ItemTable.Childs
    '        If Not row Is e.Row Then
    '            If Not row.IsNull("stocki_entityType") Then
    '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
    '                    If Not row.IsNull("code") Then
    '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
    '                            Return True
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next
    '    Return False
    'End Function
    'Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
    '    If m_updating Then
    '        Return
    '    End If
    '    m_updating = True
    '    Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '    If e.Row.IsNull("stocki_entityType") Then
    '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '        e.ProposedValue = e.Row(e.Column)
    '        m_updating = False
    '        Return
    '    End If
    '    If DupCode(e) Then
    '        Dim item As New GoodsReceiptItem
    '        item.CopyFromDataRow(CType(e.Row, TreeRow))
    '        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
    '        e.ProposedValue = e.Row(e.Column)
    '        m_updating = False
    '        Return
    '    End If
    '    Select Case CInt(e.Row("stocki_entityType"))
    '        Case 0 'Blank
    '            msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
    '            e.ProposedValue = e.Row(e.Column)
    '            m_updating = False
    '            Return
    '        Case 28 'F/A
    '            msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
    '            e.ProposedValue = e.Row(e.Column)
    '            m_updating = False
    '            Return
    '        Case 19 'Tool
    '            If e.ProposedValue.ToString.Length = 0 Then
    '                If e.Row(e.Column).ToString.Length <> 0 Then
    '                    If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
    '                        ClearRow(e)
    '                    Else
    '                        e.ProposedValue = e.Row(e.Column)
    '                    End If
    '                End If
    '                m_updating = False
    '                Return
    '            End If
    '            Dim myTool As New Tool(e.ProposedValue.ToString)
    '            If Not myTool.Originated Then
    '                msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
    '                e.ProposedValue = e.Row(e.Column)
    '                m_updating = False
    '                Return
    '            Else
    '                Dim myUnit As Unit = myTool.Unit
    '                e.Row("stocki_entity") = myTool.Id
    '                e.ProposedValue = myTool.Code
    '                e.Row("stocki_itemName") = myTool.Name
    '                If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '                    e.Row("stocki_unit") = myUnit.Id
    '                    e.Row("Unit") = myUnit.Name
    '                Else
    '                    e.Row("stocki_unit") = DBNull.Value
    '                    e.Row("Unit") = DBNull.Value
    '                End If
    '                Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
    '                If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
    '                    e.Row("stocki_acct") = ga.Account.Id
    '                    e.Row("AccountCode") = ga.Account.Code
    '                    e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '                Else
    '                    e.Row("stocki_acct") = DBNull.Value
    '                    e.Row("AccountCode") = DBNull.Value
    '                    e.Row("Account") = DBNull.Value
    '                End If
    '            End If
    '        Case 42 'LCI
    '            If e.ProposedValue.ToString.Length = 0 Then
    '                If e.Row(e.Column).ToString.Length <> 0 Then
    '                    If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
    '                        ClearRow(e)
    '                    Else
    '                        e.ProposedValue = e.Row(e.Column)
    '                    End If
    '                End If
    '                m_updating = False
    '                Return
    '            End If
    '            Dim lci As New LCIItem(e.ProposedValue.ToString)
    '            If Not lci.Originated Then
    '                msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
    '                e.ProposedValue = e.Row(e.Column)
    '                m_updating = False
    '                Return
    '            Else
    '                Dim myUnit As Unit = lci.DefaultUnit
    '                e.Row("stocki_entity") = lci.Id
    '                e.ProposedValue = lci.Code
    '                e.Row("stocki_itemName") = lci.Name
    '                If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '                    e.Row("stocki_unit") = myUnit.Id
    '                    e.Row("Unit") = myUnit.Name
    '                Else
    '                    e.Row("stocki_unit") = DBNull.Value
    '                    e.Row("Unit") = DBNull.Value
    '                End If
    '                If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
    '                    e.Row("stocki_acct") = lci.Account.Id
    '                    e.Row("AccountCode") = lci.Account.Code
    '                    e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '                Else
    '                    e.Row("stocki_acct") = DBNull.Value
    '                    e.Row("AccountCode") = DBNull.Value
    '                    e.Row("Account") = DBNull.Value
    '                End If
    '            End If
    '        Case Else
    '            msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '            e.ProposedValue = e.Row(e.Column)
    '            m_updating = False
    '            Return
    '    End Select
    '    e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
    '    m_updating = False
    'End Sub
    'Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    'End Sub
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
      If Not CBool(Configuration.GetConfig("ApproveDR")) Then
        Me.btnApprove.Visible = False
      Else
        Me.btnApprove.Visible = True
      End If
      '------------------ เช็คสิทธิการมองเห็นปุ่มปิดเอกสาร ---------------------
      CType(Me.Entity, DR).Closed = Me.chkClosed.Checked
      If CType(Me.Entity, DR).Closed Then
        CheckCancelClosed()
      Else
        CheckClosed()
      End If
      'จากการอนุมัติเอกสาร

      If CBool(Configuration.GetConfig("ApproveDR")) Then
        'ถ้าใช้การอนุมัติแบบใหม่ PJMModule
        'If m_ApproveDocModule.Activated Then
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
      End If

      'จาก Status ของเอกสารเอง
      If Me.m_entity.Status.Value = 0 OrElse m_entityRefed = 1 OrElse Me.m_entity.Closed Then
        For Each ctrl As Control In grbDetail.Controls
          If Not ctrl.Name = "chkClosed" Then
            If TypeOf ctrl Is TextBox Then
              CType(ctrl, TextBox).ReadOnly = True
            Else
              ctrl.Enabled = False
            End If
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

      'Me.chkClosed.Enabled = True
      Me.ibtnCopyMe.Enabled = True
      Me.btnApprove.Enabled = True

      'CheckWBSRight()
    End Sub
    Private Sub CheckClosed()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(367)            'ตรวจสอบ สิทธิการปิดDR
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)           'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
      checkString = BinaryHelper.RevertString(checkString)
      If CBool(checkString.Substring(0, 1)) Then
        Me.chkClosed.Visible = True
      Else
        Me.chkClosed.Visible = False
      End If
    End Sub
    Private Sub CheckCancelClosed()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(377)            'ตรวจสอบ สิทธิการปิดDR
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)           'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
      checkString = BinaryHelper.RevertString(checkString)
      If CBool(checkString.Substring(0, 1)) Then
        Me.chkClosed.Visible = True
      Else
        Me.chkClosed.Visible = False
      End If
    End Sub
    '        Private Sub CheckWBSRight()
    '            Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
    '            Dim level As Integer = secSrv.GetAccess(256)
    '            Dim checkString As String = BinaryHelper.DecToBin(level, 5)
    '            checkString = BinaryHelper.RevertString(checkString)
    '            If Not CBool(checkString.Substring(0, 1)) Then
    '                ห้ามเห็น()
    '                Me.lblWBS.Visible = False
    '                Me.tgWBS.Visible = False
    '                Me.ibtnAddWBS.Visible = False
    '                Me.ibtnDelWBS.Visible = False
    '            ElseIf Not CBool(checkString.Substring(1, 1)) Then
    '                ห้ามแก้()
    '                Me.lblWBS.Visible = True
    '                Me.tgWBS.Visible = True
    '                Me.ibtnAddWBS.Visible = True
    '                Me.ibtnDelWBS.Visible = True

    '                Me.tgWBS.Enabled = False
    '                Me.ibtnAddWBS.Enabled = False
    '                Me.ibtnDelWBS.Enabled = False
    '            Else
    '                Me.lblWBS.Visible = True
    '                Me.tgWBS.Visible = True
    '                Me.ibtnAddWBS.Visible = True
    '                Me.ibtnDelWBS.Visible = True

    '                Me.tgWBS.Enabled = True
    '                Me.ibtnAddWBS.Enabled = True
    '                Me.ibtnDelWBS.Enabled = True
    '            End If
    'End Sub
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

      'Me.dtpReceivingDate.Value = Now
      'cmbTaxType.SelectedIndex = 1
      'If Me.CurrentTagItem Is Nothing AndAlso Me.m_entity.ItemCollection.Count > 0 Then
      '  tgItem.CurrentRowIndex = 1
      'End If

    End Sub
    Public Overrides Sub SetLabelText()
      '            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblCode}") '"เลขที่ DR"

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblDocDate}")
      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblSupplier}") '"ผู้รับเหมา"
      Me.Validator.SetDisplayName(Me.txtSubContractorCode, StringHelper.GetRidOfAtEnd(Me.lblSupplier.Text, ":"))
      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblFromCostCenter}") '"Cost Center เบิก"
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, StringHelper.GetRidOfAtEnd(Me.lblFromCostCenter.Text, ":"))
      Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblFromCCPerson}") '"ผู้จ่าย"
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, StringHelper.GetRidOfAtEnd(Me.lblFromCCPerson.Text, ":"))

      Me.lblSCCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblSCCode}") '"เลขที่ SC"
      Me.Validator.SetDisplayName(Me.txtSCCode, StringHelper.GetRidOfAtEnd(Me.lblSCCode.Text, ":"))
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.lbltoCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lbltoCC}")
      'Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblToCCPerson}")
      'Me.lblEquipment.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblEquipment}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblGross}")
      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblBeforeTax}")
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblTaxBase}")
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblTaxType}")
      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblTaxRate}")
      Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblTaxAmount}")
      Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.lblAfterTax}")

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtSCCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSCCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDocDate.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtSubContractorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSubContractorCode.TextChanged, AddressOf Me.TextHandler
      ' AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtFromCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtFromCostCenterCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtFromCCPersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtFromCCPersonCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtToCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToCostCenterCode.TextChanged, AddressOf Me.TextHandler

      '            AddHandler txtRealGross.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealGross.Validated, AddressOf Me.TextHandler

      'AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty 'Todo: .... จะแก้ได้หรือปล่าว

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.TextHandler
    End Sub
    Private ccCodeChanged As Boolean = False
    Private requestorCodeChanged As Boolean = False
    Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    Private CCCodeBlankFlag As Boolean = False
    Private scCodeChanged As Boolean = False

    Private txtsubcontractorChanged As Boolean = False
    Private directorCodeChanged As Boolean = False
    Private txtfromcostcentercodeChanged As Boolean = False
    Private txttocostcentercodeChanged As Boolean = False
    Private txtfromccpersoncodeChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtrequestorcode"
          requestorCodeChanged = True
          'Case "txtcostcentercode"
          '  CCCodeChanged = True
        Case "txtsccode"
          scChanged = True


        Case "txtfromcostcentercode"
          txtfromcostcentercodeChanged = True
        Case "txttocostcentercode"
          txttocostcentercodeChanged = True
        Case "txtfromccpersoncode"
          txtfromccpersoncodeChanged = True
        Case "txtsubcontractorcode"
          txtsubcontractorChanged = True
          '                Case "txtretention"
          '                    Dim txt As String = Me.txtRetention.Text
          '                    txt = txt.Replace(",", "")
          '                    If txt.Length = 0 Then
          '                        Me.m_entity.Retention = 0
          '                    Else
          '                        Try
          '                            Me.m_entity.Retention = Math.Min(CDec(TextParser.Evaluate(txt)), Me.m_entity.AfterTax)
          '                        Catch ex As Exception
          '                            Me.m_entity.Retention = 0
          '                        End Try
          '                    End If
          '                    Me.txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)
          '                Case "txtrealtaxbase"
          '                    Dim txt As String = Me.txtRealTaxBase.Text
          '                    txt = txt.Replace(",", "")
          '                    If txt.Length = 0 Then
          '                        Me.m_entity.RealTaxBase = 0
          '                    Else
          '                        Try
          '                            Me.m_entity.RealTaxBase = CDec(TextParser.Evaluate(txt))
          '                        Catch ex As Exception
          '                            Me.m_entity.RealTaxBase = 0
          '                        End Try
          '                    End If
          '                    UpdateAmount(True)
          '                Case "txtrealgross"
          '                    Dim txt As String = Me.txtRealGross.Text
          '                    txt = txt.Replace(",", "")
          '                    If txt.Length = 0 Then
          '                        Me.m_entity.RealGross = 0
          '                    Else
          '                        Try
          '                            Me.m_entity.RealGross = CDec(TextParser.Evaluate(txt))
          '                        Catch ex As Exception
          '                            Me.m_entity.RealGross = 0
          '                        End Try
          '                    End If
          '                    forceUpdateTaxBase = True
          '                    forceUpdateTaxAmount = True
          '                    UpdateAmount(True)
          '                Case "txtrealtaxamount"
          '                    Dim txt As String = Me.txtRealTaxAmount.Text
          '                    txt = txt.Replace(",", "")
          '                    If txt.Length = 0 Then
          '                        Me.m_entity.RealTaxAmount = 0
          '                    Else
          '                        Try
          '                            Me.m_entity.RealTaxAmount = CDec(TextParser.Evaluate(txt))
          '                        Catch ex As Exception
          '                            Me.m_entity.RealTaxAmount = 0
          '                        End Try
          '                    End If
          '                    UpdateAmount(True)
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
      oldCCId = Me.m_entity.ToCostCenter.Id
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      Me.chkClosed.Checked = Me.m_entity.Closed

      If Me.m_entity.Closed Then
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.chkClosedCancel}")
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.chkClosed}")
      End If

      '            Me.SetColumnOriginQty()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
      txtSCCode.Text = Me.m_entity.Sc.Code



      txtFromCostCenterCode.Text = m_entity.FromCostCenter.Code
      txtFromCostCenterName.Text = m_entity.FromCostCenter.Name

      txtSubContractorCode.Text = m_entity.Sc.SubContractor.Code
      txtSubContractorName.Text = m_entity.Sc.SubContractor.Name

      txtToCostCenterCode.Text = m_entity.Sc.CostCenter.Code
      txtToCostCenterName.Text = m_entity.Sc.CostCenter.Name

      txtFromCCPersonCode.Text = m_entity.FromEmployee.Code
      txtFromCCPersonName.Text = m_entity.FromEmployee.Name

      txtNote.Text = Me.m_entity.Note

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
    '        End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
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
    Private Sub SetCCCodeBlankFlag()
      If Me.txtFromCostCenterCode.Text.Length = 0 Then
        CCCodeBlankFlag = True
      Else
        CCCodeBlankFlag = False
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    'Private toCCCodeChanged As Boolean = False
    Private scChanged As Boolean = False
    'Private oldCCId As Integer
    'Private dirtyFlag As Boolean = False
    'Private CCCodeBlankFlag As Boolean = False
    'Private Sub SetCCCodeBlankFlag()
    '    If Me.txtCostCenterCode.Text.Length = 0 Then
    '        CCCodeBlankFlag = True
    '    Else
    '        CCCodeBlankFlag = False
    '    End If
    'End Sub
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
            End If
          Else
            Me.m_entity.Code = cmbCode.Text
          End If
          dirtyFlag = True
        Case "txtsccode"
          If scChanged Then
            If Me.m_entity.Sc Is Nothing Then
              Me.m_entity.Sc = New SC
            End If
            dirtyFlag = SC.GetSC(txtSCCode, Me.m_entity.Sc)

            Me.txtSubContractorCode.Text = Me.m_entity.Sc.SubContractor.Code
            Me.txtSubContractorName.Text = Me.m_entity.Sc.SubContractor.Name
            Me.txtToCostCenterCode.Text = Me.m_entity.Sc.CostCenter.Code
            Me.txtToCostCenterName.Text = Me.m_entity.Sc.CostCenter.Name
            scChanged = False
          End If
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
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
          'Case "txtSubContractorCode"
          '    Me.m_entity.Sc.CostCenter = txtSubContractorCode.Text
        Case "txtrealtaxbase"
          dirtyFlag = True
        Case "txtrealtaxamount"
          dirtyFlag = True
        Case "txtrealgross"
          dirtyFlag = True
        Case "cmbcode"
          Me.m_entity.Code = cmbCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtsubcontractorcode"
          If txtsubcontractorChanged Then
            dirtyFlag = Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.SubContractor)
            txttocostcentercodeChanged = False
          End If
          'dirtyFlag = Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.SubContractor, True)
          'm_isInitialized = False
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
            Me.dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
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
        Case "txtfromcostcentercode"
            If txtfromcostcentercodeChanged Then
            dirtyFlag = CostCenter.GetCostCenterWithoutRight(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter)
              txtfromcostcentercodeChanged = False
            End If
        Case "txttocostcentercode"
          If txttocostcentercodeChanged Then
            If txttocostcentercodeChanged Then
              dirtyFlag = CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.Sc.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
              txttocostcentercodeChanged = False
            End If
          End If
        Case "txtfromccpersoncode"
          If txtfromccpersoncodeChanged Then
            dirtyFlag = Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromEmployee)
            txtfromccpersoncodeChanged = False
          End If
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
      SetCCCodeBlankFlag()
    End Sub
    'Private Sub ibtnResetGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetGross.Click
    '    If Me.m_entity.RealGross <> Me.m_entity.Gross Thenf 
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    '    Me.m_entity.RealGross = Me.m_entity.Gross
    '    UpdateAmount(True)
    'End Sub
    'Private Sub ibtnResetTaxBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxBase.Click
    '    If Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase Then
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    '    Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
    '    UpdateAmount(True)
    'End Sub
    'Private Sub ibtnResetTaxAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxAmount.Click
    '    If Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount Then
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    '    Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
    '    UpdateAmount(True)
    'End Sub
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
      'txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
      txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
      txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
      txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
      'txtDiscountRate.Text = m_entity.Discount.Rate
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
      'RefreshWBS()
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
        Me.m_entity = CType(Value, DR)
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

    Private Sub SetTaxTypeComboBox()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
      If cmbTaxType.Items.Count > 0 Then
        Dim index As Object = Configuration.GetConfig("CompanyTaxType")
        cmbTaxType.SelectedIndex = CInt(index)
      End If
    End Sub
#End Region

#Region "Event Handler"
    'Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '    If Me.m_entity Is Nothing Then
    '        Return
    '    End If
    '    If Me.m_entity.CostCenter Is Nothing Then
    '        msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
    '        Return
    '    End If
    '    If Me.m_entity.CostCenter.BoqId = 0 Then
    '        msgServ.ShowMessage("${res:Global.Error.SpecifyCCWithBOQ}")
    '        Return
    '    End If
    '    Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
    '    If doc Is Nothing Then
    '        Return
    '    End If
    '    Dim dt As TreeTable = Me.m_treeManager2.Treetable
    '    dt.Clear()
    '    Dim view As Integer = 6
    '    Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
    '    If wsdColl.GetSumPercent >= 100 Then
    '        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
    '    ElseIf doc.ItemType.Value = 160 Or doc.ItemType.Value = 162 Then
    '        msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveWBS}")
    '    Else
    '        Dim wbsd As New WBSDistribute
    '        wbsd.CostCenter = Me.m_entity.CostCenter
    '        wbsd.Percent = 100 - wsdColl.GetSumPercent
    '        wsdColl.Add(wbsd)
    '    End If
    '    m_wbsdInitialized = False
    '    wsdColl.Populate(dt, doc, view)
    '    m_wbsdInitialized = True
    '    Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub
    'Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dt As TreeTable = Me.m_treeManager2.Treetable
    '    dt.Clear()
    '    Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
    '    If doc Is Nothing Then
    '        Return
    '    End If
    '    Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
    '    If wsdColl.Count > 0 Then
    '        wsdColl.Remove(wsdColl.Count - 1)
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    '    Dim view As Integer = 6
    '    m_wbsdInitialized = False
    '    wsdColl.Populate(dt, doc, view)
    '    m_wbsdInitialized = True
    'End Sub
    'Private currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      'If tgItem.CurrentRowIndex <> currentY Then
      Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
      'RefreshWBS()
      'currentY = tgItem.CurrentRowIndex
      'End If
    End Sub
    'Private Sub tgItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.Click
    '  If Not Me.CurrentTagItem Is Nothing Then
    '    Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
    '  Else
    '    If Me.m_entity.ItemCollection.Count = 1 Then
    '      Dim doc As New DRItem
    '      doc.ItemType = New ItemType(0)
    '      Me.m_entity.ItemCollection.Add(doc)
    '      Me.m_entity.ItemCollection.CurrentItem = doc
    '    End If
    '  End If
    'End Sub
    'Private Sub RefreshWBS()
    '    Dim dt As TreeTable = Me.m_treeManager2.Treetable
    '    dt.Clear()
    '    Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
    '    If Me.m_entity.ItemCollection.CurrentItem Is Nothing Then
    '        Return
    '    End If
    '    Dim item As POItem = Me.m_entity.ItemCollection.CurrentItem
    '    Dim wsdColl As WBSDistributeCollection = item.WBSDistributeCollection
    '    Dim view As Integer = 6
    '    m_wbsdInitialized = False
    '    wsdColl.Populate(dt, item, view)
    '    m_wbsdInitialized = True
    'End Sub
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
      Dim doc As DRItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
        'doc = New DRItem
        'doc.ItemType = New DRIItemType(0)
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
      Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
    Private m_targetType As Integer
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As DRItem = Me.m_entity.ItemCollection.CurrentItem
      m_targetType = -1
      If doc Is Nothing Then
        Return
        'doc = New DRItem
        'doc.ItemType = New DRIItemType(0)
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
          ElseIf doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
            activeIndex = 0
          End If
        End If
        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, activeIndex)
      End If
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      'If tgItem.CurrentRowIndex = 0 Then
      '  '        'Hack
      '  tgItem.CurrentRowIndex = 1
      'End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items, m_targetType)
      '    'Me.txtReceivingDate.Text = Me.m_entity.ReceivingDate.ToShortDateString

      '    'Dim cc As CostCenter = Me.m_entity.GetCCFromPR
      '    'If Not cc Is Nothing AndAlso cc.Id <> Me.m_entity.CostCenter.Id Then
      '    '    Me.SetCostCenterDialog(cc)
      '    'End If
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      dirtyFlag = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As DRItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim theItem As New DRItem
      theItem.Entity = newItem
      theItem.ItemType = New DRIItemType(0)
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc), theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      'Dim doc As DRItem = Me.m_entity.ItemCollection.CurrentItem
      'If doc Is Nothing Then
      '  Return
      'End If
      'Me.m_entity.ItemCollection.Remove(doc)

      Dim rowsCount As Integer = 0
      Dim firstRowSelected As Integer = 0
      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing Then
          rowsCount += 1
          Dim row As TreeRow = CType(Obj, TreeRow)
          If Not row Is Nothing Then
            If firstRowSelected = 0 Then
              firstRowSelected = row.Index
            End If
            If TypeOf row.Tag Is DRItem Then
              Dim doc As DRItem = CType(row.Tag, DRItem)
              If Not doc Is Nothing Then
                Me.m_entity.ItemCollection.Remove(doc)
              End If
            End If
          End If
        End If
      Next

      If rowsCount.Equals(0) Then
        Dim doc As DRItem = Me.m_entity.ItemCollection.CurrentItem
        If doc Is Nothing Then
          Return
        End If
        Me.m_entity.ItemCollection.Remove(doc)
      End If


      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      Me.tgItem.CurrentRowIndex = firstRowSelected
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

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New DR).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    Private Sub ibtnShowSCDialog_click(ByVal sendr As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSCDialog.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.Sc Is Nothing OrElse Not Me.m_entity.Sc.Originated OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.DRDeatail.Message.ChangeSC}", "${res:Longkong.Pojjaman.Gui.Panels.DRDetail.Caption.ChangeSC}") Then
        Dim myEntityPanelService As IEntityPanelService = _
        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim entities As New ArrayList

        entities.Add(New SC)

        If Me.m_entity.Sc.SubContractor.Originated Then
          entities.Add(Me.m_entity.Sc.SubContractor)
        End If
        If Me.m_entity.Sc.CostCenter.Originated Then
          entities.Add(Me.m_entity.Sc.CostCenter)
        Else
          entities.Add(New CostCenter)
        End If
        'Dim poNeedsApproval As Boolean = False
        'poNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
        'Dim filters(3) As Filter
        'filters(0) = New Filter("poNeedsApproval", poNeedsApproval)
        'filters(1) = New Filter("excludeCanceled", True)
        'filters(2) = New Filter("excludedepleted", True)
        'filters(3) = New Filter("excludeclosed", True)
        myEntityPanelService.OpenListDialog(Me.m_entity.Sc, AddressOf SetSC, entities)
      End If
    End Sub
    Private Sub SetSC(ByVal e As ISimpleEntity)
      'Dim scNeedsApproval As Boolean = False
      'scNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
      'Dim newSc As SC = CType(e, SC)
      If Me.m_entity Is Nothing Then
        Return
      End If
      'Me.m_entity.Sc = New SC(e.Code)
      'If scNeedsApproval AndAlso newSc.ApproveDate.Equals(Date.MinValue) Then
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ThisPOIsNotApproved}", New String() {Me.m_entity.Sc.Code})
      'Return
      'End If
      '-------------ขึ้นดาว
      If Me.m_entity.Sc Is Nothing Then
        Me.m_entity.Sc = New SC
      End If
      Me.txtSCCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or SC.GetSC(txtSCCode, Me.m_entity.Sc)
      Me.txtSCCode.Text = Me.m_entity.Sc.Code

      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      'Me.txtPODate.Text = MinDateToNull(Me.m_entity.Po.DocDate, "")
      Me.txtSubContractorCode.Text = Me.m_entity.Sc.SubContractor.Code
      Me.txtSubContractorName.Text = Me.m_entity.Sc.SubContractor.Name
      Me.txtToCostCenterCode.Text = Me.m_entity.Sc.CostCenter.Code
      Me.txtToCostCenterName.Text = Me.m_entity.Sc.CostCenter.Name
      'Me.txtFromCostCenterCode.Text = Me.m_entity.CostCenter.Code
      'Me.txtFromCostCenterName.Text = Me.m_entity.CostCenter.Name
      'Me.txtFromCCPersonCode.Text = Me.m_entity.Director.Code
      'Me.txtFromCCPersonName.Text = Me.m_entity.Director.Name
      'For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
      '    vitem.PrintName = Me.m_entity.Supplier.Name
      '    vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
      'Next
      'Me.m_entity.AdvancePayItemCollection.Clear()
      m_isInitialized = flag

      RefreshDocs()

      scCodeChanged = False
    End Sub
    Private Sub btnSubcontractDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubcontractDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    End Sub
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSubContractorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.Sc.SubContractor)
    End Sub
    Private Sub btnCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetfromCostCenter)
    End Sub
    Private Sub SettoCostcenter(ByVal e As ISimpleEntity)
      Me.txtToCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.Sc.CostCenter)
    End Sub
    'If Me.txtToCostCenterCode.Text <> e.Code AndAlso Me.txtToCostCenterCode.Text.Length > 0 Then
    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
    '    If Me.txtToCostCenterCode.TextLength = 0 Then
    '      Me.m_entity.ToCostCenter = New CostCenter
    '    End If
    '    Me.txtToCostCenterCode.Text = e.Code
    '    dirtyFlag = CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    '    If dirtyFlag Then
    '      UpdateDestAdmin()
    '    End If
    '    Try
    '      If oldCCId <> Me.m_entity.ToCostCenter.Id Then
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '        oldCCId = Me.m_entity.ToCostCenter.Id
    '        ChangeCC()
    '      End If
    '    Catch ex As Exception
    '    End Try
    '    ccCodeChanged = False
    '  Else
    '    Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
    '    ccCodeChanged = False
    '  End If
    'ElseIf Me.txtToCostCenterCode.Text.Length = 0 Then
    '  Me.txtToCostCenterCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = True
    '  dirtyFlag = CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    '  If dirtyFlag Then
    '    UpdateDestAdmin()
    '  End If
    'End If
    'SetCCCodeBlankFlag()
    'End Sub
    Private Sub ibtnShowFromCostCenter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowFromCostCenter.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub

    Private Sub ibtnShowFromCCPerson_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowFromCCPerson.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    ' From Costcenter
    'Private Sub ibtnShowFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCostCenterDialog.Click
    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  Dim myEntityPanelService As IEntityPanelService = _
    '        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenTreeDialog(Me.m_entity.FromCostCenter, AddressOf SetCostCenterDialog)
    'End Sub
    Private Sub ibtnShowFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCostCenterDialog.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.ToCostCenter Is Nothing OrElse Not Me.m_entity.ToCostCenter.Originated OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetailView.Caption.ChangeCC}") Then
        Dim myEntityPanelService As IEntityPanelService = _
                    CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterDialog, New Filter() {New Filter("checkright", False)})
      End If
    End Sub
    Private Sub SetfromCostCenter(ByVal e As ISimpleEntity)
      Me.txtToCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenterWithoutRight(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter)
      Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
      Me.txtToCostCenterName.Text = Me.m_entity.ToCostCenter.Name
      'ListType()
      UpdateDestAdmin()
      Try
        If oldCCId <> Me.m_entity.ToCostCenter.Id Then
          oldCCId = Me.m_entity.ToCostCenter.Id
          ChangeCC()
        End If
      Catch ex As Exception

      End Try
      Me.txtfromcostcentercodeChanged = False
      'Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    ' To Costcenter
    Private Sub ibtnShowToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(Me.m_entity.FromCostCenter, AddressOf SetCostCenterDialog)
    End Sub
    Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
      If Me.txtFromCostCenterCode.Text <> e.Code AndAlso Me.txtFromCostCenterCode.Text.Length > 0 Then
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
          If Me.txtFromCostCenterCode.TextLength = 0 Then
            Me.m_entity.FromCostCenter = New CostCenter
          End If
          Me.txtFromCostCenterCode.Text = e.Code
          dirtyFlag = CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          If dirtyFlag Then
            UpdateDestAdmin()
          End If
          Try
            If oldCCId <> Me.m_entity.FromCostCenter.Id Then
              Me.WorkbenchWindow.ViewContent.IsDirty = True
              oldCCId = Me.m_entity.FromCostCenter.Id
              ChangeCC()
            End If
          Catch ex As Exception
          End Try
          ccCodeChanged = False
        Else
          Me.txtFromCostCenterCode.Text = Me.m_entity.FromCostCenter.Code
          ccCodeChanged = False
        End If
      ElseIf Me.txtFromCostCenterCode.Text.Length = 0 Then
        Me.txtFromCostCenterCode.Text = e.Code
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        dirtyFlag = CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        If dirtyFlag Then
          UpdateDestAdmin()
        End If
      End If
      SetCCCodeBlankFlag()
    End Sub
    'ผู้ให้เบิก
    Private Sub ibtnShowFromCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(Me.m_entity.FromEmployee, AddressOf SetEmployeeDialog)
    End Sub
    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtFromCCPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromEmployee)
    End Sub

    ' Requestor
    Private Sub btnRequestorEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      'myEntityPanelService.OpenPanel(dummyEmployee)
    End Sub
    Private Sub btnRequestorFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '  myEntityPanelService.OpenListDialog(dummyEmployee, AddressOf SetEmployeeDialog)
    End Sub
    ' Costcenter
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '  myEntityPanelService.OpenTreeDialog(dummyCC, AddressOf SetCostCenterDialog)
    End Sub
    'Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
    '    If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
    '        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
    '            'If Me.txtCostCenterCode.TextLength = 0 Then
    '            '    Me.m_entity.CostCenter = New CostCenter
    '            'End If
    '            Me.txtCostCenterCode.Text = e.Code
    '            dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    '            If dirtyFlag Then
    '                UpdateDestAdmin()
    '            End If
    '            Try
    '                If oldCCId <> Me.m_entity.CostCenter.Id Then
    '                    Me.WorkbenchWindow.ViewContent.IsDirty = True
    '                    oldCCId = Me.m_entity.CostCenter.Id
    '                    ChangeCC()
    '                End If
    '            Catch ex As Exception
    '            End Try
    '            toCCCodeChanged = False
    '        Else
    '            Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
    '            toCCCodeChanged = False
    '        End If
    '    ElseIf Me.txtCostCenterCode.Text.Length = 0 Then
    '        Me.txtCostCenterCode.Text = e.Code
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    '        If dirtyFlag Then
    '            UpdateDestAdmin()
    '        End If
    '    End If
    '    SetCCCodeBlankFlag()
    'End Sub
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyCC)
    End Sub
    Private Sub ChangeCC()
      '    'For Each item As POItem In Me.m_entity.ItemCollection
      '    '    item.WBSDistributeCollection.Clear()
      '    'Next
      '    RefreshWBS()
    End Sub
    Private Sub UpdateDestAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Try
        Me.m_entity.FromEmployee = Me.m_entity.FromCostCenter.Admin
        Me.txtFromCCPersonCode.Text = m_entity.FromEmployee.Code
        txtFromCCPersonName.Text = m_entity.FromEmployee.Name
      Catch ex As Exception
      Finally
        Me.m_isInitialized = flag
      End Try
    End Sub
    'Private Sub ibtnShowPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dlg As New BasketDialog
    '    AddHandler dlg.EmptyBasket, AddressOf SetItems

    '    Dim filters(4) As Filter
    '    Dim excludeList As Object = ""
    '    excludeList = GetPRExcludeList()
    '    If excludeList.ToString.Length = 0 Then
    '        excludeList = DBNull.Value
    '    End If
    '    Dim prNeedsApproval As Boolean = False
    '    Dim prNeedsStoreApproval As Boolean = False
    '    prNeedsApproval = CBool(Configuration.GetConfig("ApprovePR"))
    '    prNeedsStoreApproval = CBool(Configuration.GetConfig("PRNeedStoreApprove"))
    '    filters(0) = New Filter("excludeList", excludeList)
    '    filters(1) = New Filter("prNeedsApproval", prNeedsApproval)
    '    filters(2) = New Filter("excludeCanceled", True)
    '    filters(3) = New Filter("PRNeedStoreApprove", prNeedsStoreApproval)
    '    filters(4) = New Filter("formEntity", Me.m_entity.EntityId)

    '    Dim Entities As New ArrayList
    '    If Not Me.m_entity.CostCenter Is Nothing AndAlso Me.m_entity.CostCenter.Originated Then
    '        Entities.Add(Me.m_entity.CostCenter)
    '    End If

    '    Dim view As AbstractEntityPanelViewContent = New PRSelectionView(New PR, New BasketDialog, filters, Entities)
    '    dlg.Lists.Add(view)
    '    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
    '    myDialog.ShowDialog()
    'End Sub
    'Private Function GetPRExcludeList() As String
    '    Dim ret As String = ""
    '    For Each item As POItem In Me.m_entity.ItemCollection
    '        If Not item.Pritem Is Nothing Then
    '            ret &= "|" & item.Pritem.Pr.Id.ToString & ":" & item.Pritem.LineNumber.ToString & "|"
    '        End If
    '    Next
    '    Return ret
    'End Function
    'Private Sub ibtnGetFromBOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnGetFromBOQ.Click
    '    Dim arr As New ArrayList
    '    arr.Add(Me.m_entity.CostCenter)
    '    Dim myEntityPanelService As IEntityPanelService = _
    '                CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenListDialog(New BOQForSelection, AddressOf SetItems, arr)
    'End Sub

    '' Supplier
    'Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierEdit.Click
    '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenPanel(New Supplier)
    'End Sub
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    End Sub
    Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
      Me.txtSubContractorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          'Or Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
      'm_isInitialized = False
      'Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
      'm_isInitialized = True
    End Sub
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Not Me.m_entity.Originated Then
        msgServ.ShowMessageFormatted("${res:Global.SaveDocumentFirst}", New String() {Me.m_entity.Code})
        Return
      End If
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
              'ibtnDelRow_Click(Nothing, Nothing)
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

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      'If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
      '    'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '    Me.m_treeManager.Treetable.Childs.Add()
      'End If

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
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.chkClosedCancel}")
        If Not Me.m_entity.Closed Then
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        Else
          Me.WorkbenchWindow.ViewContent.IsDirty = False
        End If
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DRPanelView.chkClosed}")
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
    'Public Overrides ReadOnly Property CanPrint() As Boolean
    '    Get
    '        Try
    '            Dim approveDocColl As New ApproveDocCollection(m_entity)
    '            Dim poNeedsApproval As Boolean = CBool(Configuration.GetConfig("POApproveBeforePrint"))
    '            If poNeedsApproval Then
    '                If Not approveDocColl.IsApproved Then
    '                    Return False
    '                End If
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        Return MyBase.CanPrint
    '    End Get
    'End Property
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

