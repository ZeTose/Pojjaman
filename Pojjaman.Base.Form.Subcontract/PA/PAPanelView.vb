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
Imports Longkong.Pojjaman.Commands

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class PAPanelView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable, IPreviewable
    'Inherits UserControl

#Region " Windows Form Designer generated code "
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
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
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtRealGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents lblDiscountAmount As System.Windows.Forms.Label
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
    Friend WithEvents lblGross As System.Windows.Forms.Label
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
    Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxBase As System.Windows.Forms.Label
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents lblAdvancePay As System.Windows.Forms.Label
    Friend WithEvents txtAdvancePayAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowAdvancePay As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRetention As System.Windows.Forms.TextBox
    Friend WithEvents lblRetention As System.Windows.Forms.Label
    Friend WithEvents txtWHT As System.Windows.Forms.TextBox
    Friend WithEvents lblWHT As System.Windows.Forms.Label
    Friend WithEvents txtSCCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSCCode As System.Windows.Forms.Label
    Friend WithEvents txtSubContractorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSubContractorName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowSCDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnBlankSubItem As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnDirectorEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnDirectorFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDirectorName As System.Windows.Forms.TextBox
    Friend WithEvents txtDirectorCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbContact As System.Windows.Forms.ComboBox
    Friend WithEvents txtCredit As System.Windows.Forms.TextBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents gbCostCenter As System.Windows.Forms.GroupBox
    Friend WithEvents gbSubContract As System.Windows.Forms.GroupBox
    Friend WithEvents lblPACode As System.Windows.Forms.Label
    Friend WithEvents txtPACode As System.Windows.Forms.TextBox
    Friend WithEvents txtPADocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpPADocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPADocDate As System.Windows.Forms.Label
    Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblDirector As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PAPanelView))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.txtSubContractorCode = New System.Windows.Forms.TextBox()
      Me.txtSubContractorName = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtRetention = New System.Windows.Forms.TextBox()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtSCCode = New System.Windows.Forms.TextBox()
      Me.txtRealGross = New System.Windows.Forms.TextBox()
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
      Me.txtBeforeTax = New System.Windows.Forms.TextBox()
      Me.txtTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtAfterTax = New System.Windows.Forms.TextBox()
      Me.txtDiscountRate = New System.Windows.Forms.TextBox()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.txtAdvancePayAmount = New System.Windows.Forms.TextBox()
      Me.txtWHT = New System.Windows.Forms.TextBox()
      Me.txtDirectorName = New System.Windows.Forms.TextBox()
      Me.txtDirectorCode = New System.Windows.Forms.TextBox()
      Me.txtCredit = New System.Windows.Forms.TextBox()
      Me.txtDueDate = New System.Windows.Forms.TextBox()
      Me.txtPACode = New System.Windows.Forms.TextBox()
      Me.txtPADocDate = New System.Windows.Forms.TextBox()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.gbCostCenter = New System.Windows.Forms.GroupBox()
      Me.btnDirectorEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.btnDirectorFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblDirector = New System.Windows.Forms.Label()
      Me.gbSubContract = New System.Windows.Forms.GroupBox()
      Me.cmbContact = New System.Windows.Forms.ComboBox()
      Me.lblContact = New System.Windows.Forms.Label()
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDueDate = New System.Windows.Forms.Label()
      Me.lblCredit = New System.Windows.Forms.Label()
      Me.lblDay = New System.Windows.Forms.Label()
      Me.ibtnBlankSubItem = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblWHT = New System.Windows.Forms.Label()
      Me.lblRetention = New System.Windows.Forms.Label()
      Me.lblAdvancePay = New System.Windows.Forms.Label()
      Me.ibtnShowAdvancePay = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblDiscountAmount = New System.Windows.Forms.Label()
      Me.lblBeforeTax = New System.Windows.Forms.Label()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.lblTaxAmount = New System.Windows.Forms.Label()
      Me.lblAfterTax = New System.Windows.Forms.Label()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.lblTaxRate = New System.Windows.Forms.Label()
      Me.lblTaxBase = New System.Windows.Forms.Label()
      Me.lblPercent = New System.Windows.Forms.Label()
      Me.lblPACode = New System.Windows.Forms.Label()
      Me.lblSCCode = New System.Windows.Forms.Label()
      Me.ibtnShowSCDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.dtpPADocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblPADocDate = New System.Windows.Forms.Label()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.gbCostCenter.SuspendLayout()
      Me.gbSubContract.SuspendLayout()
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
      Me.tgItem.Location = New System.Drawing.Point(8, 206)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 210)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 14
      Me.tgItem.TreeManager = Nothing
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(12, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 18)
      Me.lblCode.TabIndex = 11
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(342, 17)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(125, 21)
      Me.dtpDocDate.TabIndex = 59
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(270, 17)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(72, 18)
      Me.lblDocDate.TabIndex = 14
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSupplier
      '
      Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(6, 15)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(86, 18)
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
      Me.txtSubContractorCode.Location = New System.Drawing.Point(92, 15)
      Me.txtSubContractorCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtSubContractorCode, "")
      Me.txtSubContractorCode.Name = "txtSubContractorCode"
      Me.txtSubContractorCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSubContractorCode, "")
      Me.Validator.SetRequired(Me.txtSubContractorCode, False)
      Me.txtSubContractorCode.Size = New System.Drawing.Size(72, 21)
      Me.txtSubContractorCode.TabIndex = 1
      '
      'txtSubContractorName
      '
      Me.txtSubContractorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSubContractorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.txtSubContractorName.Location = New System.Drawing.Point(164, 15)
      Me.Validator.SetMinValue(Me.txtSubContractorName, "")
      Me.txtSubContractorName.Name = "txtSubContractorName"
      Me.txtSubContractorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSubContractorName, "")
      Me.Validator.SetRequired(Me.txtSubContractorName, False)
      Me.txtSubContractorName.Size = New System.Drawing.Size(206, 21)
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
      Me.txtNote.Location = New System.Drawing.Point(8, 444)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(151, 93)
      Me.txtNote.TabIndex = 13
      Me.txtNote.WordWrap = False
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(6, 420)
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
      Me.lblStatus.Location = New System.Drawing.Point(180, 184)
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
      Me.txtDocDate.Location = New System.Drawing.Point(342, 17)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(104, 21)
      Me.txtDocDate.TabIndex = 1
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(91, 15)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.txtCostCenterCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(72, 21)
      Me.txtCostCenterCode.TabIndex = 5
      '
      'txtRetention
      '
      Me.txtRetention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRetention, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.txtRetention.Location = New System.Drawing.Point(584, 493)
      Me.Validator.SetMinValue(Me.txtRetention, "")
      Me.txtRetention.Name = "txtRetention"
      Me.Validator.SetRegularExpression(Me.txtRetention, "")
      Me.Validator.SetRequired(Me.txtRetention, False)
      Me.txtRetention.Size = New System.Drawing.Size(184, 21)
      Me.txtRetention.TabIndex = 12
      Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(163, 15)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(206, 21)
      Me.txtCostCenterName.TabIndex = 25
      Me.txtCostCenterName.TabStop = False
      '
      'txtSCCode
      '
      Me.Validator.SetDataType(Me.txtSCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSCCode, "")
      Me.txtSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.txtSCCode.Location = New System.Drawing.Point(100, 64)
      Me.Validator.SetMinValue(Me.txtSCCode, "")
      Me.txtSCCode.Name = "txtSCCode"
      Me.Validator.SetRegularExpression(Me.txtSCCode, "")
      Me.Validator.SetRequired(Me.txtSCCode, False)
      Me.txtSCCode.Size = New System.Drawing.Size(120, 21)
      Me.txtSCCode.TabIndex = 4
      Me.txtSCCode.TabStop = False
      '
      'txtRealGross
      '
      Me.txtRealGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.txtRealGross.Location = New System.Drawing.Point(398, 421)
      Me.Validator.SetMinValue(Me.txtRealGross, "")
      Me.txtRealGross.Name = "txtRealGross"
      Me.Validator.SetRegularExpression(Me.txtRealGross, "")
      Me.Validator.SetRequired(Me.txtRealGross, False)
      Me.txtRealGross.Size = New System.Drawing.Size(80, 21)
      Me.txtRealGross.TabIndex = 7
      Me.txtRealGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxAmount
      '
      Me.txtRealTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(688, 445)
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(80, 21)
      Me.txtRealTaxAmount.TabIndex = 10
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxBase
      '
      Me.txtRealTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(398, 517)
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(80, 21)
      Me.txtRealTaxBase.TabIndex = 9
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtGross
      '
      Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtGross.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(294, 421)
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(80, 21)
      Me.txtGross.TabIndex = 7
      Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDiscountAmount
      '
      Me.txtDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.txtDiscountAmount.Location = New System.Drawing.Point(390, 445)
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.txtDiscountAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtDiscountAmount.TabIndex = 10
      Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBeforeTax
      '
      Me.txtBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBeforeTax.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBeforeTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBeforeTax, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
      Me.txtBeforeTax.Location = New System.Drawing.Point(294, 493)
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(184, 21)
      Me.txtBeforeTax.TabIndex = 352
      Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTaxAmount
      '
      Me.txtTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
      Me.txtTaxAmount.Location = New System.Drawing.Point(584, 445)
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(80, 21)
      Me.txtTaxAmount.TabIndex = 13
      Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.txtAfterTax.Location = New System.Drawing.Point(584, 517)
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(184, 21)
      Me.txtAfterTax.TabIndex = 356
      Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDiscountRate
      '
      Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.txtDiscountRate.Location = New System.Drawing.Point(294, 445)
      Me.Validator.SetMinValue(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Name = "txtDiscountRate"
      Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
      Me.Validator.SetRequired(Me.txtDiscountRate, False)
      Me.txtDiscountRate.Size = New System.Drawing.Size(96, 21)
      Me.txtDiscountRate.TabIndex = 8
      '
      'txtTaxRate
      '
      Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(723, 421)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, False)
      Me.txtTaxRate.Size = New System.Drawing.Size(37, 21)
      Me.txtTaxRate.TabIndex = 17
      Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTaxBase
      '
      Me.txtTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.txtTaxBase.Location = New System.Drawing.Point(294, 517)
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(80, 21)
      Me.txtTaxBase.TabIndex = 11
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAdvancePayAmount
      '
      Me.txtAdvancePayAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAdvancePayAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAdvancePayAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvancePayAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvancePayAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvancePayAmount, System.Drawing.Color.Empty)
      Me.txtAdvancePayAmount.Location = New System.Drawing.Point(318, 469)
      Me.Validator.SetMinValue(Me.txtAdvancePayAmount, "")
      Me.txtAdvancePayAmount.Name = "txtAdvancePayAmount"
      Me.txtAdvancePayAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAdvancePayAmount, "")
      Me.Validator.SetRequired(Me.txtAdvancePayAmount, False)
      Me.txtAdvancePayAmount.Size = New System.Drawing.Size(160, 21)
      Me.txtAdvancePayAmount.TabIndex = 364
      Me.txtAdvancePayAmount.TabStop = False
      Me.txtAdvancePayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtWHT
      '
      Me.txtWHT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtWHT.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtWHT, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWHT, "")
      Me.txtWHT.ForeColor = System.Drawing.Color.Blue
      Me.Validator.SetGotFocusBackColor(Me.txtWHT, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWHT, System.Drawing.Color.Empty)
      Me.txtWHT.Location = New System.Drawing.Point(584, 469)
      Me.Validator.SetMinValue(Me.txtWHT, "")
      Me.txtWHT.Name = "txtWHT"
      Me.txtWHT.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWHT, "")
      Me.Validator.SetRequired(Me.txtWHT, False)
      Me.txtWHT.Size = New System.Drawing.Size(184, 21)
      Me.txtWHT.TabIndex = 368
      Me.txtWHT.TabStop = False
      Me.txtWHT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDirectorName
      '
      Me.txtDirectorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDirectorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDirectorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDirectorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDirectorName, System.Drawing.Color.Empty)
      Me.txtDirectorName.Location = New System.Drawing.Point(163, 39)
      Me.Validator.SetMinValue(Me.txtDirectorName, "")
      Me.txtDirectorName.Name = "txtDirectorName"
      Me.txtDirectorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDirectorName, "")
      Me.Validator.SetRequired(Me.txtDirectorName, False)
      Me.txtDirectorName.Size = New System.Drawing.Size(158, 21)
      Me.txtDirectorName.TabIndex = 375
      Me.txtDirectorName.TabStop = False
      '
      'txtDirectorCode
      '
      Me.Validator.SetDataType(Me.txtDirectorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDirectorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDirectorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDirectorCode, System.Drawing.Color.Empty)
      Me.txtDirectorCode.Location = New System.Drawing.Point(91, 39)
      Me.Validator.SetMinValue(Me.txtDirectorCode, "")
      Me.txtDirectorCode.Name = "txtDirectorCode"
      Me.Validator.SetRegularExpression(Me.txtDirectorCode, "")
      Me.Validator.SetRequired(Me.txtDirectorCode, True)
      Me.txtDirectorCode.Size = New System.Drawing.Size(72, 21)
      Me.txtDirectorCode.TabIndex = 0
      '
      'txtCredit
      '
      Me.Validator.SetDataType(Me.txtCredit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCredit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCredit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCredit, System.Drawing.Color.Empty)
      Me.txtCredit.Location = New System.Drawing.Point(92, 39)
      Me.Validator.SetMinValue(Me.txtCredit, "")
      Me.txtCredit.Name = "txtCredit"
      Me.Validator.SetRegularExpression(Me.txtCredit, "")
      Me.Validator.SetRequired(Me.txtCredit, False)
      Me.txtCredit.Size = New System.Drawing.Size(37, 21)
      Me.txtCredit.TabIndex = 2
      Me.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDueDate
      '
      Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDueDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.txtDueDate.Location = New System.Drawing.Point(244, 39)
      Me.Validator.SetMinValue(Me.txtDueDate, "")
      Me.txtDueDate.Name = "txtDueDate"
      Me.Validator.SetRegularExpression(Me.txtDueDate, "")
      Me.Validator.SetRequired(Me.txtDueDate, False)
      Me.txtDueDate.Size = New System.Drawing.Size(104, 21)
      Me.txtDueDate.TabIndex = 3
      '
      'txtPACode
      '
      Me.Validator.SetDataType(Me.txtPACode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPACode, "")
      Me.txtPACode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPACode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPACode, System.Drawing.Color.Empty)
      Me.txtPACode.Location = New System.Drawing.Point(100, 40)
      Me.Validator.SetMinValue(Me.txtPACode, "")
      Me.txtPACode.Name = "txtPACode"
      Me.Validator.SetRegularExpression(Me.txtPACode, "")
      Me.Validator.SetRequired(Me.txtPACode, False)
      Me.txtPACode.Size = New System.Drawing.Size(120, 21)
      Me.txtPACode.TabIndex = 2
      Me.txtPACode.TabStop = False
      '
      'txtPADocDate
      '
      Me.Validator.SetDataType(Me.txtPADocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPADocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPADocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPADocDate, System.Drawing.Color.Empty)
      Me.txtPADocDate.Location = New System.Drawing.Point(342, 41)
      Me.Validator.SetMinValue(Me.txtPADocDate, "")
      Me.txtPADocDate.Name = "txtPADocDate"
      Me.Validator.SetRegularExpression(Me.txtPADocDate, "")
      Me.Validator.SetRequired(Me.txtPADocDate, False)
      Me.txtPADocDate.Size = New System.Drawing.Size(104, 21)
      Me.txtPADocDate.TabIndex = 3
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(11, 182)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(88, 18)
      Me.lblItem.TabIndex = 33
      Me.lblItem.Text = "รายการรับงาน"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.btnApprove)
      Me.grbDetail.Controls.Add(Me.gbCostCenter)
      Me.grbDetail.Controls.Add(Me.gbSubContract)
      Me.grbDetail.Controls.Add(Me.ibtnBlankSubItem)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.txtWHT)
      Me.grbDetail.Controls.Add(Me.lblWHT)
      Me.grbDetail.Controls.Add(Me.txtRetention)
      Me.grbDetail.Controls.Add(Me.lblRetention)
      Me.grbDetail.Controls.Add(Me.lblAdvancePay)
      Me.grbDetail.Controls.Add(Me.txtAdvancePayAmount)
      Me.grbDetail.Controls.Add(Me.ibtnShowAdvancePay)
      Me.grbDetail.Controls.Add(Me.txtRealGross)
      Me.grbDetail.Controls.Add(Me.ibtnResetGross)
      Me.grbDetail.Controls.Add(Me.txtRealTaxAmount)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtRealTaxBase)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxBase)
      Me.grbDetail.Controls.Add(Me.txtGross)
      Me.grbDetail.Controls.Add(Me.lblDiscountAmount)
      Me.grbDetail.Controls.Add(Me.txtDiscountAmount)
      Me.grbDetail.Controls.Add(Me.lblBeforeTax)
      Me.grbDetail.Controls.Add(Me.lblGross)
      Me.grbDetail.Controls.Add(Me.txtBeforeTax)
      Me.grbDetail.Controls.Add(Me.lblTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtTaxAmount)
      Me.grbDetail.Controls.Add(Me.lblAfterTax)
      Me.grbDetail.Controls.Add(Me.txtAfterTax)
      Me.grbDetail.Controls.Add(Me.txtDiscountRate)
      Me.grbDetail.Controls.Add(Me.cmbTaxType)
      Me.grbDetail.Controls.Add(Me.lblTaxType)
      Me.grbDetail.Controls.Add(Me.txtTaxRate)
      Me.grbDetail.Controls.Add(Me.lblTaxRate)
      Me.grbDetail.Controls.Add(Me.txtTaxBase)
      Me.grbDetail.Controls.Add(Me.lblTaxBase)
      Me.grbDetail.Controls.Add(Me.lblPercent)
      Me.grbDetail.Controls.Add(Me.lblPACode)
      Me.grbDetail.Controls.Add(Me.lblSCCode)
      Me.grbDetail.Controls.Add(Me.txtPACode)
      Me.grbDetail.Controls.Add(Me.txtSCCode)
      Me.grbDetail.Controls.Add(Me.ibtnShowSCDialog)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.txtPADocDate)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.dtpPADocDate)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblPADocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(0, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(776, 544)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'btnApprove
      '
      Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApprove.ForeColor = System.Drawing.Color.Black
      Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnApprove.Location = New System.Drawing.Point(662, 181)
      Me.btnApprove.Name = "btnApprove"
      Me.btnApprove.Size = New System.Drawing.Size(104, 23)
      Me.btnApprove.TabIndex = 335
      Me.btnApprove.Text = "อนุมัติเอกสาร"
      Me.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnApprove.ThemedImage = CType(resources.GetObject("btnApprove.ThemedImage"), System.Drawing.Bitmap)
      '
      'gbCostCenter
      '
      Me.gbCostCenter.Controls.Add(Me.txtDirectorName)
      Me.gbCostCenter.Controls.Add(Me.txtCostCenterCode)
      Me.gbCostCenter.Controls.Add(Me.btnDirectorEdit)
      Me.gbCostCenter.Controls.Add(Me.lblCostCenter)
      Me.gbCostCenter.Controls.Add(Me.btnDirectorFind)
      Me.gbCostCenter.Controls.Add(Me.txtDirectorCode)
      Me.gbCostCenter.Controls.Add(Me.txtCostCenterName)
      Me.gbCostCenter.Controls.Add(Me.lblDirector)
      Me.gbCostCenter.Location = New System.Drawing.Point(392, 85)
      Me.gbCostCenter.Name = "gbCostCenter"
      Me.gbCostCenter.Size = New System.Drawing.Size(379, 92)
      Me.gbCostCenter.TabIndex = 6
      Me.gbCostCenter.TabStop = False
      Me.gbCostCenter.Text = "Cost Center"
      '
      'btnDirectorEdit
      '
      Me.btnDirectorEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDirectorEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDirectorEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDirectorEdit.Location = New System.Drawing.Point(345, 38)
      Me.btnDirectorEdit.Name = "btnDirectorEdit"
      Me.btnDirectorEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnDirectorEdit.TabIndex = 377
      Me.btnDirectorEdit.TabStop = False
      Me.btnDirectorEdit.ThemedImage = CType(resources.GetObject("btnDirectorEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCostCenter
      '
      Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCostCenter.Location = New System.Drawing.Point(17, 15)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(74, 18)
      Me.lblCostCenter.TabIndex = 21
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnDirectorFind
      '
      Me.btnDirectorFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDirectorFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDirectorFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDirectorFind.Location = New System.Drawing.Point(321, 38)
      Me.btnDirectorFind.Name = "btnDirectorFind"
      Me.btnDirectorFind.Size = New System.Drawing.Size(24, 23)
      Me.btnDirectorFind.TabIndex = 376
      Me.btnDirectorFind.TabStop = False
      Me.btnDirectorFind.ThemedImage = CType(resources.GetObject("btnDirectorFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDirector
      '
      Me.lblDirector.BackColor = System.Drawing.Color.Transparent
      Me.lblDirector.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDirector.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDirector.Location = New System.Drawing.Point(17, 39)
      Me.lblDirector.Name = "lblDirector"
      Me.lblDirector.Size = New System.Drawing.Size(74, 18)
      Me.lblDirector.TabIndex = 374
      Me.lblDirector.Text = "ผู้สั่งจ้าง:"
      Me.lblDirector.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'gbSubContract
      '
      Me.gbSubContract.Controls.Add(Me.cmbContact)
      Me.gbSubContract.Controls.Add(Me.txtCredit)
      Me.gbSubContract.Controls.Add(Me.lblContact)
      Me.gbSubContract.Controls.Add(Me.txtSubContractorCode)
      Me.gbSubContract.Controls.Add(Me.txtDueDate)
      Me.gbSubContract.Controls.Add(Me.lblSupplier)
      Me.gbSubContract.Controls.Add(Me.dtpDueDate)
      Me.gbSubContract.Controls.Add(Me.txtSubContractorName)
      Me.gbSubContract.Controls.Add(Me.lblDueDate)
      Me.gbSubContract.Controls.Add(Me.lblCredit)
      Me.gbSubContract.Controls.Add(Me.lblDay)
      Me.gbSubContract.Location = New System.Drawing.Point(8, 85)
      Me.gbSubContract.Name = "gbSubContract"
      Me.gbSubContract.Size = New System.Drawing.Size(379, 92)
      Me.gbSubContract.TabIndex = 5
      Me.gbSubContract.TabStop = False
      Me.gbSubContract.Text = "ผู้รับเหมา"
      '
      'cmbContact
      '
      Me.cmbContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbContact.Location = New System.Drawing.Point(92, 63)
      Me.cmbContact.Name = "cmbContact"
      Me.cmbContact.Size = New System.Drawing.Size(278, 21)
      Me.cmbContact.TabIndex = 4
      '
      'lblContact
      '
      Me.lblContact.BackColor = System.Drawing.Color.Transparent
      Me.lblContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblContact.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblContact.Location = New System.Drawing.Point(5, 63)
      Me.lblContact.Name = "lblContact"
      Me.lblContact.Size = New System.Drawing.Size(88, 18)
      Me.lblContact.TabIndex = 385
      Me.lblContact.Text = "ผู้ติดต่อ:"
      Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDueDate
      '
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDate.Location = New System.Drawing.Point(248, 39)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(122, 21)
      Me.dtpDueDate.TabIndex = 380
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.Location = New System.Drawing.Point(174, 40)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(69, 18)
      Me.lblDueDate.TabIndex = 383
      Me.lblDueDate.Text = "ครบกำหนด:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCredit
      '
      Me.lblCredit.BackColor = System.Drawing.Color.Transparent
      Me.lblCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCredit.Location = New System.Drawing.Point(5, 40)
      Me.lblCredit.Name = "lblCredit"
      Me.lblCredit.Size = New System.Drawing.Size(88, 18)
      Me.lblCredit.TabIndex = 384
      Me.lblCredit.Text = "ระยะเครดิต:"
      Me.lblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDay
      '
      Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDay.Location = New System.Drawing.Point(130, 40)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(34, 18)
      Me.lblDay.TabIndex = 382
      Me.lblDay.Text = "วัน"
      Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnBlankSubItem
      '
      Me.ibtnBlankSubItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlankSubItem.Location = New System.Drawing.Point(148, 179)
      Me.ibtnBlankSubItem.Name = "ibtnBlankSubItem"
      Me.ibtnBlankSubItem.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlankSubItem.TabIndex = 372
      Me.ibtnBlankSubItem.TabStop = False
      Me.ibtnBlankSubItem.ThemedImage = CType(resources.GetObject("ibtnBlankSubItem.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtnBlankSubItem.Visible = False
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(124, 179)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 370
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
      Me.ibtnBlank.Visible = False
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(100, 179)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 371
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
      '
      'lblWHT
      '
      Me.lblWHT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblWHT.BackColor = System.Drawing.Color.Transparent
      Me.lblWHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWHT.Location = New System.Drawing.Point(488, 469)
      Me.lblWHT.Name = "lblWHT"
      Me.lblWHT.Size = New System.Drawing.Size(96, 18)
      Me.lblWHT.TabIndex = 369
      Me.lblWHT.Text = "ภาษีหัก ณ ที่จ่าย :"
      Me.lblWHT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRetention
      '
      Me.lblRetention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblRetention.BackColor = System.Drawing.Color.Transparent
      Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetention.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRetention.Location = New System.Drawing.Point(484, 493)
      Me.lblRetention.Name = "lblRetention"
      Me.lblRetention.Size = New System.Drawing.Size(100, 18)
      Me.lblRetention.TabIndex = 367
      Me.lblRetention.Text = "Retention:"
      Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAdvancePay
      '
      Me.lblAdvancePay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAdvancePay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvancePay.Location = New System.Drawing.Point(183, 469)
      Me.lblAdvancePay.Name = "lblAdvancePay"
      Me.lblAdvancePay.Size = New System.Drawing.Size(111, 18)
      Me.lblAdvancePay.TabIndex = 363
      Me.lblAdvancePay.Text = "มัดจำ :"
      Me.lblAdvancePay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowAdvancePay
      '
      Me.ibtnShowAdvancePay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnShowAdvancePay.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAdvancePay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAdvancePay.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAdvancePay.Location = New System.Drawing.Point(294, 469)
      Me.ibtnShowAdvancePay.Name = "ibtnShowAdvancePay"
      Me.ibtnShowAdvancePay.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAdvancePay.TabIndex = 365
      Me.ibtnShowAdvancePay.TabStop = False
      Me.ibtnShowAdvancePay.ThemedImage = CType(resources.GetObject("ibtnShowAdvancePay.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetGross
      '
      Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetGross.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetGross.Location = New System.Drawing.Point(374, 421)
      Me.ibtnResetGross.Name = "ibtnResetGross"
      Me.ibtnResetGross.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetGross.TabIndex = 360
      Me.ibtnResetGross.TabStop = False
      Me.ibtnResetGross.ThemedImage = CType(resources.GetObject("ibtnResetGross.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxAmount
      '
      Me.ibtnResetTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(664, 445)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 362
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(374, 517)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 361
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDiscountAmount
      '
      Me.lblDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscountAmount.Location = New System.Drawing.Point(183, 445)
      Me.lblDiscountAmount.Name = "lblDiscountAmount"
      Me.lblDiscountAmount.Size = New System.Drawing.Size(111, 18)
      Me.lblDiscountAmount.TabIndex = 347
      Me.lblDiscountAmount.Text = "ส่วนลด :"
      Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(172, 493)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(122, 18)
      Me.lblBeforeTax.TabIndex = 351
      Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
      Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGross.BackColor = System.Drawing.Color.Transparent
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(183, 421)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(111, 18)
      Me.lblGross.TabIndex = 348
      Me.lblGross.Text = "ยอดเงินรวม :"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(484, 445)
      Me.lblTaxAmount.Name = "lblTaxAmount"
      Me.lblTaxAmount.Size = New System.Drawing.Size(100, 18)
      Me.lblTaxAmount.TabIndex = 345
      Me.lblTaxAmount.Text = "ภาษีมูลค่าเพิ่ม :"
      Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAfterTax
      '
      Me.lblAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAfterTax.BackColor = System.Drawing.Color.Transparent
      Me.lblAfterTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAfterTax.Location = New System.Drawing.Point(484, 515)
      Me.lblAfterTax.Name = "lblAfterTax"
      Me.lblAfterTax.Size = New System.Drawing.Size(100, 18)
      Me.lblAfterTax.TabIndex = 346
      Me.lblAfterTax.Text = "ยอดสุทธิ :"
      Me.lblAfterTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbTaxType
      '
      Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(584, 421)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(80, 21)
      Me.cmbTaxType.TabIndex = 11
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(484, 421)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(99, 18)
      Me.lblTaxType.TabIndex = 340
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(659, 421)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
      Me.lblTaxRate.TabIndex = 342
      Me.lblTaxRate.Text = "อัตราภาษี :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxBase
      '
      Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.Location = New System.Drawing.Point(172, 517)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(122, 18)
      Me.lblTaxBase.TabIndex = 353
      Me.lblTaxBase.Text = "มูลค่าสินค้า/บริการ :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPercent
      '
      Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(762, 421)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 344
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPACode
      '
      Me.lblPACode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPACode.ForeColor = System.Drawing.Color.Black
      Me.lblPACode.Location = New System.Drawing.Point(12, 40)
      Me.lblPACode.Name = "lblPACode"
      Me.lblPACode.Size = New System.Drawing.Size(88, 18)
      Me.lblPACode.TabIndex = 335
      Me.lblPACode.Text = "เลขที่ใบส่งงาน:"
      Me.lblPACode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSCCode
      '
      Me.lblSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSCCode.ForeColor = System.Drawing.Color.Black
      Me.lblSCCode.Location = New System.Drawing.Point(12, 64)
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
      Me.ibtnShowSCDialog.Location = New System.Drawing.Point(221, 63)
      Me.ibtnShowSCDialog.Name = "ibtnShowSCDialog"
      Me.ibtnShowSCDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSCDialog.TabIndex = 336
      Me.ibtnShowSCDialog.TabStop = False
      Me.ibtnShowSCDialog.ThemedImage = CType(resources.GetObject("ibtnShowSCDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(100, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 0
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(221, 15)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 12
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'dtpPADocDate
      '
      Me.dtpPADocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpPADocDate.Location = New System.Drawing.Point(342, 41)
      Me.dtpPADocDate.Name = "dtpPADocDate"
      Me.dtpPADocDate.Size = New System.Drawing.Size(125, 21)
      Me.dtpPADocDate.TabIndex = 59
      '
      'lblPADocDate
      '
      Me.lblPADocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPADocDate.Location = New System.Drawing.Point(270, 41)
      Me.lblPADocDate.Name = "lblPADocDate"
      Me.lblPADocDate.Size = New System.Drawing.Size(72, 18)
      Me.lblPADocDate.TabIndex = 14
      Me.lblPADocDate.Text = "วันที่ส่งงาน:"
      Me.lblPADocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(243, 15)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 13
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtnCopyMe.Visible = False
      '
      'PAPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "PAPanelView"
      Me.Size = New System.Drawing.Size(784, 552)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.gbCostCenter.ResumeLayout(False)
      Me.gbCostCenter.PerformLayout()
      Me.gbSubContract.ResumeLayout(False)
      Me.gbSubContract.PerformLayout()
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
    Private m_entity As PA
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    'Private dummyCC As New CostCenter
    'Private dummyEmployee As New Employee

    'Private m_treeManager2 As TreeManager
    'Private m_wbsdInitialized As Boolean

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

      Dim rs As ResourceService = CType(ServiceManager.Services.GetService(GetType(ResourceService)), ResourceService)
      Me.ibtnCopyMe.ThemedImage = rs.GetBitmap("Icons.16x16.Copy")

      SaveEnableState()

      Dim dt As TreeTable = PA.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf PAItemDelete

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
      For Each ctrl As Control In gbCostCenter.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
        If TypeOf ctrl Is TextBox Then
          m_readOnlyState.Add(CType(ctrl, TextBox), CType(ctrl, TextBox).ReadOnly)
        End If
      Next

      For Each ctrl As Control In gbSubContract.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
        If TypeOf ctrl Is TextBox Then
          m_readOnlyState.Add(CType(ctrl, TextBox), CType(ctrl, TextBox).ReadOnly)
        End If
      Next
    End Sub
#End Region

#Region "Style"
    Public Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      '    e.HilightValue = False
      '    e.RedText = False
      '    Dim i As Integer = 0
      '    For Each row As DataRow In Me.m_treeManager2.Treetable.Rows
      '        For Each col As DataColumn In Me.m_treeManager2.Treetable.Columns
      '            If col.Ordinal > 0 Then
      '                If Not row.IsNull(col) AndAlso IsNumeric(row(col)) Then
      '                    If CDec(row(col)) < 0 Then
      '                        If e.Column = col.Ordinal And e.Row = i Then
      '                            e.HilightValue = True
      '                            e.RedText = True
      '                        End If
      '                    End If
      '                End If
      '            End If
      '        Next
      '        i += 1
      '    Next
    End Sub
    'ปุ่ม CC
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
      'Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
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
      'Dim view As Integer = 45
      'm_wbsdInitialized = False
      ''wsdColl.Populate(dt, doc, view)
      'm_wbsdInitialized = True
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "PA"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'PA Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "pai_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.LineNumberHeaderText}")           '"No."
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "pai_linenumber"

      'Dim csBarrier As New DataGridBarrierColumn
      'csBarrier.MappingName = "Barrier"
      'csBarrier.HeaderText = ""
      'csBarrier.NullText = ""
      'csBarrier.ReadOnly = True

      '"รายการ sc"
      Dim csPADesc As New TreeTextColumn
      csPADesc.MappingName = "pai_paDesc"
      csPADesc.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.DescriptionHeaderText}")
      csPADesc.NullText = ""
      csPADesc.Width = 175
      csPADesc.ReadOnly = True
      csPADesc.TextBox.Name = "pai_paDesc"

      '"อ้างอิง"
      Dim csRefCode As New TreeTextColumn
      csRefCode.MappingName = "pai_refDoc"
      csRefCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.RefDocHeaderText}")          '"เอกสารอ้างอิง"
      csRefCode.NullText = ""
      csRefCode.Width = 75
      csRefCode.ReadOnly = True
      csRefCode.TextBox.Name = "pai_refDoc"

      '"ประเภท"
      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("pai_entityType" _
      , CodeDescription.GetCodeList("pai_entitytype") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.TypeHeaderText}")
      csType.ReadOnly = True
      csType.NullText = String.Empty

      '"รหัส"
      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      '"รายการ"
      Dim csName As New TreeTextColumn
      csName.MappingName = "pai_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 210
      csName.ReadOnly = True
      csName.TextBox.Name = "pai_itemName"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.Width = 60
      csUnit.ReadOnly = True
      csUnit.TextBox.Name = "Unit"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center


      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      'AddHandler csUnitButton.Click, AddressOf ButtonClicked

      '"มูลค่าตามสัญญา"
      Dim csSCCost As New TreeTextColumn
      csSCCost.MappingName = "CostAmount"
      csSCCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCCostHeaderText}")           '"มูลค่าตามสัญญา"
      csSCCost.NullText = ""
      csSCCost.DataAlignment = HorizontalAlignment.Right
      csSCCost.Format = "#,###.##"
      csSCCost.Width = 100
      csSCCost.ReadOnly = True
      csSCCost.TextBox.Name = "CostAmount"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      '"ปริมาณตามสัญญา"
      Dim csSCQty As New TreeTextColumn
      csSCQty.MappingName = "QtyCostAmount"
      csSCQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCQtyHeaderText}")         '"ปริมาณตามสัญญา"
      csSCQty.NullText = ""
      csSCQty.DataAlignment = HorizontalAlignment.Right
      csSCQty.Format = "#,###.##"
      csSCQty.Width = 100
      csSCQty.ReadOnly = True
      csSCQty.TextBox.Name = "QtyCostAmount"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      '"รวมมูลค่างวดก่อนหน้า"
      Dim csSumSCCostBofore As New TreeTextColumn
      csSumSCCostBofore.MappingName = "ReceivedAmount"
      csSumSCCostBofore.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SumSCCostBoforeHeaderText}")         '"รวมมูลค่างวดก่อนหน้า"
      csSumSCCostBofore.NullText = ""
      csSumSCCostBofore.DataAlignment = HorizontalAlignment.Right
      csSumSCCostBofore.Width = 100
      csSumSCCostBofore.Format = "#,###.##"
      csSumSCCostBofore.ReadOnly = True
      csSumSCCostBofore.TextBox.Name = "ReceivedAmount"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      '"รวมปริมาณงวดก่อนหน้า"
      Dim csSumSCQtyBofore As New TreeTextColumn
      csSumSCQtyBofore.MappingName = "ReceivedQty"
      csSumSCQtyBofore.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SumSCQtyBoforeHeaderText}")           '"รวมปริมาณงวดก่อนหน้า"
      csSumSCQtyBofore.NullText = ""
      csSumSCQtyBofore.DataAlignment = HorizontalAlignment.Right
      csSumSCQtyBofore.Format = "#,###.##"
      csSumSCQtyBofore.Width = 100
      csSumSCQtyBofore.ReadOnly = True
      csSumSCQtyBofore.TextBox.Name = "ReceivedQty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      Dim csBarrier2 As New DataGridBarrierColumn
      csBarrier2.MappingName = "Barrier2"
      csBarrier2.HeaderText = ""
      csBarrier2.NullText = ""
      csBarrier2.ReadOnly = True

      '"ปริมาณ"
      Dim csQty As New TreeTextColumn
      csQty.MappingName = "pai_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      'csQty.ReadOnly = True
      csQty.TextBox.Name = "pai_qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      '"ราคา/หน่วย"
      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "pai_unitprice"
      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.UnitPriceHeaderTextt}")            '"ราคาต่อหน่วย"
      csUnitPRice.NullText = ""
      csUnitPRice.DataAlignment = HorizontalAlignment.Right
      'csUnitPRice.ReadOnly = True
      csUnitPRice.TextBox.Name = "pai_unitprice"
      csUnitPRice.Width = 100
      csUnitPRice.Format = "#,###.##"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      csUnit.DataAlignment = HorizontalAlignment.Center

      '"รวม"
      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.TextBox.Name = "Amount"
      csAmount.Width = 100
      csAmount.Format = "#,###.##"
      'csAmount.ReadOnly = True
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csBarrier3 As New DataGridBarrierColumn
      csBarrier3.MappingName = "Barrier3"
      csBarrier3.HeaderText = ""
      csBarrier3.NullText = ""
      csBarrier3.ReadOnly = True

      Dim csMat As New TreeTextColumn
      csMat.MappingName = "pai_mat"
      csMat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.MatHeaderText}")
      csMat.NullText = ""
      csMat.DataAlignment = HorizontalAlignment.Right
      csMat.ReadOnly = True
      csMat.TextBox.Name = "pai_mat"
      csMat.Width = 100
      csMat.Format = "#,###.##"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csLab As New TreeTextColumn
      csLab.MappingName = "pai_lab"
      csLab.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.LABHeaderText}")
      csLab.NullText = ""
      csLab.DataAlignment = HorizontalAlignment.Right
      csLab.ReadOnly = True
      csLab.TextBox.Name = "pai_lab"
      csLab.Width = 100
      csLab.Format = "#,###.##"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csEq As New TreeTextColumn
      csEq.MappingName = "pai_eq"
      csEq.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.EQHeaderText}")
      csEq.NullText = ""
      csEq.DataAlignment = HorizontalAlignment.Right
      csEq.ReadOnly = True
      csEq.TextBox.Name = "pai_eq"
      csEq.Width = 100
      csEq.Format = "#,###.##"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csAccountCode As New TreeTextColumn
      csAccountCode.MappingName = "AccountCode"
      csAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountCodeHeaderText}")
      csAccountCode.NullText = ""
      csAccountCode.TextBox.Name = "AccountCode"

      Dim csAccountButton As New DataGridButtonColumn
      csAccountButton.MappingName = "AccountButton"
      csAccountButton.HeaderText = ""
      csAccountButton.NullText = ""
      AddHandler csAccountButton.Click, AddressOf ButtonClicked

      Dim csAccount As New TreeTextColumn
      csAccount.MappingName = "Account"
      csAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountHeaderText}")
      csAccount.NullText = ""
      csAccount.ReadOnly = True
      csAccount.TextBox.Name = "Account"

      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "pai_unvatable"
      csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.UnVatableHeaderText}")
      csVatable.Width = 100
      'csVatable.ReadOnly = True
      csVatable.InvisibleWhenUnspcified = True

      '"หมายเหตุ"
      Dim csNote As New TreeTextColumn
      csNote.MappingName = "pai_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "pai_note"




      'dst.GridColumnStyles.Add(csPADesc)
      dst.GridColumnStyles.Add(csRefCode)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      'dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      'dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csSCQty)
      dst.GridColumnStyles.Add(csSCCost)
      dst.GridColumnStyles.Add(csBarrier1)
      dst.GridColumnStyles.Add(csSumSCQtyBofore)
      dst.GridColumnStyles.Add(csSumSCCostBofore)
      dst.GridColumnStyles.Add(csBarrier2)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csBarrier3)
      dst.GridColumnStyles.Add(csMat)
      dst.GridColumnStyles.Add(csLab)
      dst.GridColumnStyles.Add(csEq)
      'dst.GridColumnStyles.Add(csAccountCode)
      'dst.GridColumnStyles.Add(csAccountButton)
      'dst.GridColumnStyles.Add(csAccount)
      dst.GridColumnStyles.Add(csNote)
      dst.GridColumnStyles.Add(csVatable)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    'สร้างปุ่ม Unit
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 3 Then
        Me.ItemButtonClick(e)
      ElseIf e.Column = 6 Then
        Me.UnitButtonClick(e)
      Else
        Me.AcctButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentTagItem() As PAItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is PAItem Then
          Return Nothing
        End If
        Return CType(row.Tag, PAItem)
      End Get
    End Property
    Private ReadOnly Property CurrentRealTagItem() As PAItem
      Get
        'Return CType(childRow.Tag, SCItem)
        Dim row As TreeRow = Me.m_treeManager.SelectedRow

        Try
          Dim lastIndex As Integer = row.Index
          Dim startIndex As Integer = row.Index

          For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
            If i > startIndex Then
              If CType(Me.m_treeManager.Treetable.Childs(i).Tag, PAItem).Level = 0 Then
                Exit For
              End If
              lastIndex = i
            End If
          Next

          Dim parentRow As TreeRow = Me.m_treeManager.Treetable.Childs(lastIndex)

          Return CType(parentRow.Tag, PAItem)
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
    Dim doc As PAItem = Nothing
    Dim value As Decimal = 0
    Dim paType As PAIItemType = Nothing
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
      doc = Me.m_entity.ItemCollection.CurrentItem
      'doc = CType(Me.m_treeManager.SelectedRow.Tag, PAItem)

      '    ''If tick checkbox that not in the current hilight row
      If doc Is Nothing Then
        Return
      End If
      'If e.Column.ColumnName.ToLower = "pai_unvatable" Then
      '  Me.m_treeManager.SelectedRow = e.Row
      '  doc = Me.m_entity.ItemCollection.CurrentItem
      'End If
      'If doc Is Nothing Then
      '  doc = New PAItem
      '  doc.ItemType = New PAIItemType(289)
      '  doc.RefEntity = New RefEntity
      '  Me.m_entity.ItemCollection.Add(doc)
      '  Me.m_entity.ItemCollection.CurrentItem = doc

      'End If
      Select Case e.Column.ColumnName.ToLower

        Case "unit", "pai_qty", "amount", "pai_note", "pai_mat", "pai_lab", "pai_eq", "accountcode", "account", "pai_unvatable"
          'รายการที่แก้ไขได้
        Case Else
          If doc.RefEntity.Id > 0 Then
            'ถ้าเป็นรายการที่ดึงมาจากเอกสาร sc ให้แก้ได้เฉพาะยอดรับ
            msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.CanNotChangeRefData}")
            Return
          End If
      End Select
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "pai_itemname"
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
          Case "pai_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            'doc.Qty = value
            doc.SetQty(value)
            UpdateAmount()
          Case "amount"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.ReceiveAmount = value
            UpdateAmount()
          Case "pai_entitytype"
            If IsNumeric(e.ProposedValue) Then
              paType = New PAIItemType(CInt(e.ProposedValue))
            End If
            doc.ItemType = paType
          Case "pai_unitprice"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.UnitPrice = value
            UpdateAmount()
          Case "accountcode"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetAccountCode(CStr(e.ProposedValue))
          Case "pai_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
          Case "pai_unvatable"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = False
            End If
            doc.UnVatable = CBool(e.ProposedValue)
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub

    Private Sub PAItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "TreeTable Handlers"
    'Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '    If Not m_wbsdInitialized Then
    '        Return
    '    End If
    '    Dim index As Integer = Me.m_treeManager2.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
    '    If ValidateRow(CType(e.Row, TreeRow)) Then
    '        'UpdateAmount(e)
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
    '    Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
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
    '-------------------------------------
    'Private Sub UpdateAmount()
    '    Dim flag As Boolean = m_isInitialized
    '    m_isInitialized = False
    '    Me.m_entity.RefreshTaxBase()

    '    'HACK: forceUpdateGross ต้องอยู่อันแรกนะจ๊ะ
    '    If forceUpdateGross OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
    '        Me.m_entity.RealGross = Me.m_entity.Gross
    '        forceUpdateGross = False
    '    End If
    '    If forceUpdateTaxBase OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
    '        Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
    '        forceUpdateTaxBase = False
    '    End If
    '    If forceUpdateTaxAmount OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount) Then
    '        Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
    '        forceUpdateTaxAmount = False
    '    End If

    '    txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
    '    txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
    '    If m_entity.TaxType.Value = 0 OrElse m_entity.TaxType.Value = 1 Then
    '        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
    '    Else
    '        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
    '    End If
    '    txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
    '    txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
    '    txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
    '    If IsNumeric(Me.m_entity.Discount.Rate) Then
    '        If Me.m_entity.Discount.Rate.IndexOf(".") > 0 Then
    '            Dim digit() As String
    '            Dim digit1 As String = 0
    '            digit = m_entity.Discount.Rate.Split(".")
    '            digit1 = digit(0)
    '            digit = Configuration.FormatToString(CDec("0." & digit(1)), DigitConfig.Price).Split(".")
    '            If DigitConfig.Price > 0 Then
    '                txtDiscountRate.Text = digit1 & "." & digit(1)
    '            Else
    '                txtDiscountRate.Text = m_entity.Discount.Rate
    '            End If
    '        Else
    '            txtDiscountRate.Text = m_entity.Discount.Rate
    '        End If
    '    Else
    '        txtDiscountRate.Text = m_entity.Discount.Rate
    '    End If

    '    txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
    '    txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)
    '    CodeDescription.ComboSelect(Me.cmbTaxType, Me.m_entity.TaxType)

    '    txtRealGross.Text = Configuration.FormatToString(m_entity.RealGross, DigitConfig.Price)
    '    txtRealTaxAmount.Text = Configuration.FormatToString(m_entity.RealTaxAmount, DigitConfig.Price)
    '    txtRealTaxBase.Text = Configuration.FormatToString(m_entity.RealTaxBase, DigitConfig.Price)

    '    Me.txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)
    '    m_isInitialized = flag
    '    'SetVatInputAfterAmountChange()
    '    'RefreshWBS()
    'End Sub
    '----------------------------------------------------
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
    '  If row.IsNull("WBS") Then
    '    Return False
    '  End If
    '  Return True
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
    '    Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
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
    '    '    For Each row As TreeRow In Me.ItemTable.Childs
    '    '        If Not row Is e.Row Then
    '    '            If Not row.IsNull("stocki_entityType") Then
    '    '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
    '    '                    If Not row.IsNull("code") Then
    '    '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
    '    '                            Return True
    '    '                        End If
    '    '                    End If
    '    '                End If
    '    '            End If
    '    '        End If
    '    '    Next
    '    '    Return False
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
    '        'item.CopyFromDataRow(CType(e.Row, TreeRow))
    '        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
    '        e.ProposedValue = e.Row(e.Column)
    '        m_updating = False
    '        Return
    '    End If
    '    'Select Case CInt(e.Row("stocki_entityType"))
    '    '    Case 0 'Blank
    '    '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
    '    '        e.ProposedValue = e.Row(e.Column)
    '    '        m_updating = False
    '    '        Return
    '    '    Case 28 'F/A
    '    '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
    '    '        e.ProposedValue = e.Row(e.Column)
    '    '        m_updating = False
    '    '        Return
    '    '    Case 19 'Tool
    '    '        If e.ProposedValue.ToString.Length = 0 Then
    '    '            If e.Row(e.Column).ToString.Length <> 0 Then
    '    '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
    '    '                    ClearRow(e)
    '    '                Else
    '    '                    e.ProposedValue = e.Row(e.Column)
    '    '                End If
    '    '            End If
    '    '            m_updating = False
    '    '            Return
    '    '        End If
    '    '        Dim myTool As New Tool(e.ProposedValue.ToString)
    '    '        If Not myTool.Originated Then
    '    '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
    '    '            e.ProposedValue = e.Row(e.Column)
    '    '            m_updating = False
    '    '            Return
    '    '        Else
    '    '            Dim myUnit As Unit = myTool.Unit
    '    '            e.Row("stocki_entity") = myTool.Id
    '    '            e.ProposedValue = myTool.Code
    '    '            e.Row("stocki_itemName") = myTool.Name
    '    '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '    '                e.Row("stocki_unit") = myUnit.Id
    '    '                e.Row("Unit") = myUnit.Name
    '    '            Else
    '    '                e.Row("stocki_unit") = DBNull.Value
    '    '                e.Row("Unit") = DBNull.Value
    '    '            End If
    '    '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
    '    '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
    '    '                e.Row("stocki_acct") = ga.Account.Id
    '    '                e.Row("AccountCode") = ga.Account.Code
    '    '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '    '            Else
    '    '                e.Row("stocki_acct") = DBNull.Value
    '    '                e.Row("AccountCode") = DBNull.Value
    '    '                e.Row("Account") = DBNull.Value
    '    '            End If
    '    '        End If
    '    '    Case 42 'LCI
    '    '        If e.ProposedValue.ToString.Length = 0 Then
    '    '            If e.Row(e.Column).ToString.Length <> 0 Then
    '    '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
    '    '                    ClearRow(e)
    '    '                Else
    '    '                    e.ProposedValue = e.Row(e.Column)
    '    '                End If
    '    '            End If
    '    '            m_updating = False
    '    '            Return
    '    '        End If
    '    '        Dim lci As New LCIItem(e.ProposedValue.ToString)
    '    '        If Not lci.Originated Then
    '    '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
    '    '            e.ProposedValue = e.Row(e.Column)
    '    '            m_updating = False
    '    '            Return
    '    '        Else
    '    '            Dim myUnit As Unit = lci.DefaultUnit
    '    '            e.Row("stocki_entity") = lci.Id
    '    '            e.ProposedValue = lci.Code
    '    '            e.Row("stocki_itemName") = lci.Name
    '    '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '    '                e.Row("stocki_unit") = myUnit.Id
    '    '                e.Row("Unit") = myUnit.Name
    '    '            Else
    '    '                e.Row("stocki_unit") = DBNull.Value
    '    '                e.Row("Unit") = DBNull.Value
    '    '            End If
    '    '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
    '    '                e.Row("stocki_acct") = lci.Account.Id
    '    '                e.Row("AccountCode") = lci.Account.Code
    '    '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '    '            Else
    '    '                e.Row("stocki_acct") = DBNull.Value
    '    '                e.Row("AccountCode") = DBNull.Value
    '    '                e.Row("Account") = DBNull.Value
    '    '            End If
    '    '        End If
    '    '    Case Else
    '    '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '    '        e.ProposedValue = e.Row(e.Column)
    '    '        m_updating = False
    '    '        Return
    '    'End Select
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

      'ถ้าไม่เปิดอนุมัติเอกสาร(ให้ซ่อนปุ่ม)
      If Not CBool(Configuration.GetConfig("ApprovePa")) Then
        Me.btnApprove.Visible = False
      Else
        Me.btnApprove.Visible = True
      End If

      'จากการอนุมัติเอกสาร()
      If CBool(Configuration.GetConfig("ApprovePa")) Then
        'ถ้าใช้การอนุมัติแบบใหม่(PJMModule)
        'If m_ApproveDocModule.Activated Then
        Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
        Dim ApprovalDocLevelColl As New ApprovalDocLevelCollection(mySService.CurrentUser)      'ระดับสิทธิแต่ละผู้ใช้
        Dim ApproveDocColl As New ApproveDocCollection(Me.m_entity)     'ระดับสิทธิที่ได้ทำการ approve
        If ApproveDocColl.MaxLevel > 0 Then
          '(ApprovalDocLevelColl.GetItem(m_entity.EntityId).Level < ApproveDocColl.MaxLevel) OrElse _
          '(Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id) Then
          For Each ctrl As Control In grbDetail.Controls
            If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" Then
              If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).ReadOnly = True
              Else
                If Not TypeOf ctrl Is GroupBox Then
                  ctrl.Enabled = False
                End If
              End If
            End If
          Next
          tgItem.Enabled = True
          For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
            colStyle.ReadOnly = True
          Next
          Me.btnApprove.Enabled = True
          CheckWBSRight()
          Me.SetEnalbleGroupBox(True)
          Return
        Else
          For Each ctrl As Control In grbDetail.Controls
            If TypeOf ctrl Is TextBox Then
              CType(ctrl, TextBox).ReadOnly = CBool(m_readOnlyState(ctrl))
            Else
              If Not TypeOf ctrl Is GroupBox Then
                ctrl.Enabled = CBool(m_enableState(ctrl))
              End If
            End If
          Next
          If Me.m_entity.IsMeLastedPADoc Then
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          Else
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = True
            Next
            Me.ibtnDelRow.Enabled = False
            Me.ibtnResetGross.Enabled = False
            Me.txtRealGross.ReadOnly = True
            Me.txtDiscountRate.ReadOnly = True
            Me.ibtnResetTaxBase.Enabled = False
            Me.txtRealTaxBase.ReadOnly = True
            Me.cmbTaxType.Enabled = False
            Me.ibtnResetTaxAmount.Enabled = False
            Me.txtRealTaxAmount.ReadOnly = True
            Me.txtRetention.ReadOnly = True
          End If
        End If
        Me.SetEnalbleGroupBox()
        'Else
        '  'ถ้าใช้การอนุมัติแบบเก่า()
        '  If Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then
        '    For Each ctrl As Control In grbDetail.Controls
        '      If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" Then
        '        If TypeOf ctrl Is TextBox Then
        '          CType(ctrl, TextBox).ReadOnly = True
        '        Else
        '          ctrl.Enabled = False
        '        End If
        '      End If
        '    Next
        '    tgItem.Enabled = True
        '    For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
        '      colStyle.ReadOnly = True
        '    Next
        '    'Me.btnApprove.Enabled = True
        '    CheckWBSRight()
        '    Return
        '  Else
        '    For Each ctrl As Control In grbDetail.Controls
        '      ctrl.Enabled = CBool(m_enableState(ctrl))
        '    Next
        '    For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
        '      colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        '    Next
        '  End If
        'End If
      End If


      ' จาก Status ของเอกสารเอง
      If Me.m_entity.Status.Value = 0 OrElse m_entityRefed = 1 Then
        For Each ctrl As Control In grbDetail.Controls
          If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" Then
            If TypeOf ctrl Is TextBox Then
              CType(ctrl, TextBox).ReadOnly = True
            Else
              If Not TypeOf ctrl Is GroupBox Then
                ctrl.Enabled = False
              End If
            End If
          End If
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
        Me.SetEnalbleGroupBox(True)
      Else
        For Each ctrl As Control In grbDetail.Controls
          If TypeOf ctrl Is TextBox Then
            CType(ctrl, TextBox).ReadOnly = CBool(m_readOnlyState(ctrl))
          Else
            If Not TypeOf ctrl Is GroupBox Then
              ctrl.Enabled = CBool(m_enableState(ctrl))
            End If
          End If
        Next
        'For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
        '  colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        'Next
        If Me.m_entity.IsMeLastedPADoc Then
          For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
            colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
          Next
        Else
          For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
            colStyle.ReadOnly = True
          Next
          Me.ibtnDelRow.Enabled = False
          Me.ibtnResetGross.Enabled = False
          Me.txtRealGross.ReadOnly = True
          Me.txtDiscountRate.ReadOnly = True
          Me.ibtnResetTaxBase.Enabled = False
          Me.txtRealTaxBase.ReadOnly = True
          Me.cmbTaxType.Enabled = False
          Me.ibtnResetTaxAmount.Enabled = False
          Me.txtRealTaxAmount.ReadOnly = True
          Me.txtRetention.ReadOnly = True
        End If
        Me.SetEnalbleGroupBox()
      End If

      'Me.chkClosed.Enabled = True
      'Me.ibtnCopyMe.Enabled = True

      'Me.btnApprove.Enabled = True
      'CheckWBSRight()
    End Sub
    Private Sub SetEnalbleGroupBox(Optional ByVal SetReadOnly As Boolean = False)
      'Dim CtrlEnble As Boolean = grbCostCenter.Enabled
      'Dim initFlag As Boolean = m_isInitialized
      'grbCostCenter.Enabled = True
      'grbSubContractor.Enabled = True

      If Not SetReadOnly Then
        For Each ctrl As Control In gbCostCenter.Controls
          If TypeOf ctrl Is TextBox Then
            CType(ctrl, TextBox).ReadOnly = CBool(m_readOnlyState(ctrl))
          Else
            ctrl.Enabled = CBool(m_enableState(ctrl))
          End If
        Next

        For Each ctrl As Control In gbSubContract.Controls
          If TypeOf ctrl Is TextBox Then
            CType(ctrl, TextBox).ReadOnly = CBool(m_readOnlyState(ctrl))
          Else
            ctrl.Enabled = CBool(m_enableState(ctrl))
          End If
        Next
      Else
        For Each ctrl As Control In gbCostCenter.Controls
          If TypeOf ctrl Is TextBox Then
            CType(ctrl, TextBox).ReadOnly = True
          Else
            ctrl.Enabled = False
          End If
        Next

        For Each ctrl As Control In gbSubContract.Controls
          If TypeOf ctrl Is TextBox Then
            CType(ctrl, TextBox).ReadOnly = True
          Else
            ctrl.Enabled = False
          End If
        Next
      End If

      m_isInitialized = True
      Me.ibtnCopyMe.Enabled = True
      Me.btnApprove.Enabled = True
    End Sub
    Private Sub CheckWBSRight()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(256)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      If Not CBool(checkString.Substring(0, 1)) Then
        'ห้ามเห็น
        'Me.lblWBS.Visible = False
        'Me.tgWBS.Visible = False
        'Me.ibtnAddWBS.Visible = False
        'Me.ibtnDelWBS.Visible = False
      ElseIf Not CBool(checkString.Substring(1, 1)) Then
        'ห้ามแก้
        'Me.lblWBS.Visible = True
        'Me.tgWBS.Visible = True
        'Me.ibtnAddWBS.Visible = True
        'Me.ibtnDelWBS.Visible = True

        'Me.tgWBS.Enabled = False
        'Me.ibtnAddWBS.Enabled = False
        'Me.ibtnDelWBS.Enabled = False
      Else
        'Me.lblWBS.Visible = True
        'Me.tgWBS.Visible = True
        'Me.ibtnAddWBS.Visible = True
        'Me.ibtnDelWBS.Visible = True

        'Me.tgWBS.Enabled = True
        'Me.ibtnAddWBS.Enabled = True
        'Me.ibtnDelWBS.Enabled = True
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
      Me.dtpPADocDate.Value = Now
      cmbTaxType.SelectedIndex = 1
      If cmbTaxType.Items.Count >= 1 Then
        cmbTaxType.SelectedIndex = 1
      End If
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
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblCode}")           '"เลขที่ PA:"

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblDocDate}")
      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))
      Me.lblSCCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblSCCode}")           '"เลขที่ SC:"
      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblSupplier}")
      'Me.Validator.SetDisplayName(Me.txtSubContractorCode, StringHelper.GetRidOfAtEnd(Me.lblSupplier.Text, ":"))
      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblCostCenter}")           '"Cost Center:"
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")            '"หมายเหตุ"
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblGross}")         '"ยอดเงินรวม:"
      Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblDiscountAmount}")           '"ส่วนลด:"
      Me.lblAdvancePay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblAdvancePay}")           '"ส่วนลด:"
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblTaxBase}")   '"มูลค่าสินค้า/บริการ:"
      Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblTaxAmount}")         '"ภาษีมูลค่าเพิ่ม:"
      Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblRetention}")   '"Retention:"
      Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblAfterTax}")           '"ยอดสุทธิ:"
      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblBeforeTax}")         '"ยอดเงินไม่รวมภาษี:"
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblTaxType}")         '"ประเภทภาษี:"
      Me.lblWHT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblWHT}")         '"ประเภทภาษี:"
      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblTaxRate}")   '"อัตราภาษี "
      Me.lblDirector.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblDirector}") '"ผูู้รับงาน "

      Me.lblCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblCredit}")   '"ระยะเครดิต "
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblDay}")   '"วัน "
      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblDueDate}")   '"กำหนดชำระ "
      Me.lblContact.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblContact}")   '"ผู้ติดต่อ "

      Me.lblPACode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblPACode}")   '"เลขที่ใบส่งของ "
      Me.lblPADocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblPADocDate}")   '"วันที่ส่งของ "
      Me.gbSubContract.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.gbSubContract}")   '"ผู้รับเหมา"
      Me.gbCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.gbCostCenter}")   '"Cost Center "

      Me.Validator.SetDisplayName(Me.txtDirectorCode, StringHelper.GetRidOfAtEnd(Me.lblDirector.Text, ":"))

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtSCCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSCCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtPACode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtPACode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtPADocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpPADocDate.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtSubContractorCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtSubContractorCode.TextChanged, AddressOf Me.TextHandler

      'AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtCostCenterCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDirectorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDirectorCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtRealGross.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealGross.Validated, AddressOf Me.TextHandler

      AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtRetention.Validated, AddressOf Me.ChangeProperty
      AddHandler txtRetention.TextChanged, AddressOf Me.TextHandler

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDueDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCredit.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCredit.TextChanged, AddressOf Me.TextHandler

      AddHandler cmbContact.SelectedIndexChanged, AddressOf Me.ChangeProperty
    End Sub
    Private m_dateSetting As Boolean = False
    Private m_OtherdateSetting As Boolean = False
    Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    Private CCCodeBlankFlag As Boolean = False
    Private scCodeChanged As Boolean = False

    'Private ccCodeChanged As Boolean = False
    'Private subContractorChanged As Boolean = False
    Private directorCodeChanged As Boolean = False
    'Private retensionChanged As Boolean = False
    Private txtcreditprdChanged As Boolean = False
    Private m_dueSetting As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtsccode"
          scCodeChanged = True
        Case "txtdocdate"
          m_dateSetting = True
          'scCodeChanged = True
          'Case "txtsubcontractorcode"
          '	subContractorChanged = True
          'Case "txtcostcentercode"
          '	ccCodeChanged = True
          'Case "txtsubcontractorcode"
          '	subContractorChanged = True
        Case "txtdirectorcode"
          directorCodeChanged = True
        Case "txtretention"
          Dim txt As String = Me.txtRetention.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.Retention = 0
          Else
            Try
              Me.m_entity.Retention = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.Retention = 0
            End Try
          End If
          'Me.txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)
          'retensionChanged = True
        Case "txtrealtaxbase"
          Dim txt As String = Me.txtRealTaxBase.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealTaxBase = 0
          Else
            Try
              Me.m_entity.RealTaxBase = CDec(TextParser.Evaluate(txt))
              forceUpdateTaxAmount = True
            Catch ex As Exception
              Me.m_entity.RealTaxBase = 0
            End Try
          End If
          UpdateAmount()
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
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
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
        Case "txtcredit"
          txtcreditprdChanged = True
      End Select
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      'cmbCode.Items.Clear()
      'cmbCode.DropDownStyle = ComboBoxStyle.Simple
      'cmbCode.Text = m_entity.Code
      Me.m_oldCode = Me.m_entity.Code
      oldCCId = Me.m_entity.Sc.CostCenter.Id
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()
      Me.InitialCombo()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtCredit.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)

      txtPADocDate.Text = MinDateToNull(Me.m_entity.OtherDocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpPADocDate.Value = MinDateToNow(Me.m_entity.OtherDocDate)

      txtPACode.Text = m_entity.OtherDocCode

      txtSCCode.Text = Me.m_entity.Sc.Code

      txtSubContractorCode.Text = m_entity.Sc.SubContractor.Code
      txtSubContractorName.Text = m_entity.Sc.SubContractor.Name

      txtDirectorCode.Text = m_entity.Receiver.Code
      txtDirectorName.Text = m_entity.Receiver.Name

      txtCostCenterCode.Text = m_entity.Sc.CostCenter.Code
      txtCostCenterName.Text = m_entity.Sc.CostCenter.Name

      txtNote.Text = Me.m_entity.Note
      txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)

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
      'txtDiscountRate.Text = m_entity.Discount.Rate
      'txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
      txtWHT.Text = Configuration.FormatToString(m_entity.WitholdingTax, DigitConfig.Price)

      RefreshDocs()
      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable, tgItem)
      'RefreshBlankGrid()
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
      If Me.m_entity Is Nothing OrElse Not m_isInitialized OrElse Not Me.cmbCode.Enabled Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtrealtaxbase"
          dirtyFlag = True
        Case "txtrealtaxamount"
          dirtyFlag = True
        Case "txtrealgross"
          Me.m_entity.RealGross = Me.txtRealGross.Text
          forceUpdateGross = False
          dirtyFlag = True
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
        Case "txtsccode"
          If scCodeChanged Then
            If txtSCCode.Text.Length > 0 Then
              dirtyFlag = SC.GetSC(txtSCCode, Me.m_entity.Sc, False, m_entity)
              SetSC(Me.m_entity.Sc)
            Else
              Me.m_entity.Sc = New SC
              SetSC(Me.m_entity.Sc)
              dirtyFlag = False
            End If
          End If
        Case "txtpacode"
          Me.m_entity.OtherDocCode = txtPACode.Text
          dirtyFlag = True
        Case "dtppadocdate"
          If Not Me.m_entity.OtherDocDate.Equals(dtpPADocDate.Value) Then
            If Not m_OtherdateSetting Then
              Me.txtPADocDate.Text = MinDateToNull(dtpPADocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.OtherDocDate = dtpPADocDate.Value
              ' Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
            End If
            dirtyFlag = True
          End If
        Case "txtpadocdate"
          m_OtherdateSetting = True
          If Not Me.txtPADocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtPADocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtPADocDate.Text)
            If Not Me.m_entity.OtherDocDate.Equals(theDate) Then
              dtpPADocDate.Value = theDate
              Me.m_entity.OtherDocDate = dtpPADocDate.Value
              'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              dirtyFlag = True
            End If
          Else
            Me.dtpPADocDate.Value = Date.Now
            Me.m_entity.OtherDocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_OtherdateSetting = False

        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
          'Case "txtsubcontractorcode"
          '    dirtyFlag = Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.SubContractor, True)
          '    m_isInitialized = False
          '    'Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
          '    'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
          '    'm_isInitialized = True
        Case "txtdirectorcode"
          If directorCodeChanged Then
            dirtyFlag = Employee.GetEmployee(txtDirectorCode, txtDirectorName, Me.m_entity.Receiver)
            'directorCodeChanged = False
          End If
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
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Dim newTaxType As New TaxType(item.Id)
          'Me.m_entity.TaxType.Value = item.Id
          Me.m_entity.TaxType = newTaxType
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount()
          dirtyFlag = True
        Case "txtretention"
          UpdateAmount()
          dirtyFlag = True
        Case "txtdiscountrate"
          Me.m_entity.Discount.Rate = txtDiscountRate.Text
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount()
          dirtyFlag = True
        Case "txtcostcentercode"

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
        Case "cmbcontact"
          Me.m_entity.ContactPerson = cmbContact.Text
          dirtyFlag = True
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
      SetCCCodeBlankFlag()
    End Sub
    Private Sub ibtnResetGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity.RealGross <> Me.m_entity.Gross Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealGross = Me.m_entity.Gross
      UpdateAmount()
    End Sub
    'Private Sub ibtnResetTaxBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase Then
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    '    Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
    '    UpdateAmount(True)
    'End Sub
    Private Sub ibtnResetTaxAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
      Dim flag As Boolean = Me.m_isInitialized
      m_isInitialized = False
      Me.m_entity.RefreshTaxBase()

      'HACK:       forceUpdateGross(ต้องอยู่อันแรกนะจ๊ะ)
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
      txtDiscountRate.Text = m_entity.Discount.Rate
      txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
      If m_entity.TaxType.Value = 0 OrElse m_entity.TaxType.Value = 1 Then
        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
      End If
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
      txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next
      m_isInitialized = flag
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
        Me.m_entity = CType(Value, PA)
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        'AdvancePay เมื่อ save
        AddHandler m_entity.AdvanceClick, AddressOf ibtnShowAdvancePay_Click
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
      SetTaxTypeComboBox()
    End Sub

    Private Sub SetTaxTypeComboBox()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
      If cmbTaxType.Items.Count > 0 Then
        cmbTaxType.SelectedIndex = 1
      End If
    End Sub
#End Region

#Region "Event Handler"
    Private currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      'If tgItem.CurrentRowIndex <> currentY Then
      Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
      'Me.m_entity.ItemCollection.CurrentRealItem = Me.CurrentRealTagItem
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
        ''Me.Validator.SetRequired(Me.txtCode, False)
        ''Me.ErrorProvider1.SetError(Me.txtCode, "")
        'Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDown
        'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
        'm_oldCode = Me.cmbCode.Text
        'Me.m_entity.Code = m_oldCode
        'Me.m_entity.AutoGen = True

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
      Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New PAItem
        doc.ItemType = New PAIItemType(289)
        doc.RefEntity = New RefEntity
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
      End If

      Dim tr As TreeRow = Me.m_treeManager.SelectedRow
      Dim isSummaryRow As Boolean
      If Not tr.IsNull("isSummaryRow") Then
        isSummaryRow = CBool(tr("isSummaryRow"))
      End If

      If Not isSummaryRow Then
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
      End If
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
    Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New PAItem
        doc.ItemType = New PAIItemType(289)
        doc.RefEntity = New RefEntity
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      'If Not doc.IsSummaryRow Then
      Dim tr As TreeRow = Me.m_treeManager.SelectedRow
      Dim isSummaryRow As Boolean
      If Not tr.IsNull("isSummaryRow") Then
        isSummaryRow = CBool(tr("isSummaryRow"))
      End If

      If Not isSummaryRow Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAcct)
      End If
    End Sub
    Private Sub SetAcct(ByVal acct As ISimpleEntity)
      Me.m_treeManager.SelectedRow("AccountCode") = acct.Code
    End Sub
    Private m_targetType As Integer
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Try
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
        m_targetType = -1
        If doc Is Nothing Then
          doc = New PAItem
          doc.ItemType = New PAIItemType(0)
          Me.m_entity.ItemCollection.Add(doc)
          Me.m_entity.ItemCollection.CurrentItem = doc
        End If

        Dim tr As TreeRow = Me.m_treeManager.SelectedRow
        Dim isSummaryRow As Boolean
        If Not tr.IsNull("isSummaryRow") Then
          isSummaryRow = CBool(tr("isSummaryRow"))
        End If

        If (doc.ItemType.Value = 19 OrElse _
           doc.ItemType.Value = 42 OrElse _
           doc.ItemType.Value = 88 OrElse _
           doc.ItemType.Value = 89 OrElse _
           doc.ItemType.Value = 289) AndAlso _
           Not isSummaryRow AndAlso _
           doc.RefEntity.Id = 0 Then
          m_targetType = doc.ItemType.Value
          Dim entities(2) As ISimpleEntity
          entities(0) = New LCIItem
          entities(1) = New LCIForList
          entities(2) = New Tool
          Dim activeIndex As Integer = -1
          If Not doc.ItemType Is Nothing Then
            If doc.ItemType.Value = 19 Then
              activeIndex = 1
            ElseIf doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Or doc.ItemType.Value = 289 Then
              activeIndex = 0
            End If
          End If
          myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, activeIndex)
        End If
      Catch ex1 As System.IndexOutOfRangeException
        Return
      End Try
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items, m_targetType)
      '    'Me.txtReceivingDate.Text = Me.m_entity.ReceivingDate.ToShortDateString
      tgItem.CurrentRowIndex = index
      '    Dim cc As CostCenter = Me.m_entity.GetCCFromPR
      '    If Not cc Is Nothing AndAlso cc.Id <> Me.m_entity.CostCenter.Id Then
      '        Me.SetCostCenterDialog(cc)
      '    End If
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      dirtyFlag = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      'Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentLastItem
      If doc Is Nothing Then
        If Me.m_entity.ItemCollection.Count = 0 Then
          doc = New PAItem
        End If
        Return
      End If
      'If Not doc.SCItem Is Nothing Then
      '    Return
      'End If
      Dim newItem As New BlankItem("")
      Dim theItem As New PAItem
      theItem.Entity = newItem
      theItem.RefEntity = New RefEntity
      theItem.Level = 0
      theItem.ItemType = New PAIItemType(289)
      theItem.Qty = 0
      'Dim index As Integer = Me.m_entity.ItemCollection.IndexOf(doc)
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      RefreshDocs()
      Dim index As Integer = Me.m_entity.ItemCollection.Count - 1
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnBlankSubItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlankSubItem.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      If doc.RefEntity.Id <> 0 Then
        msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.ConnotHasSubItem}")
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim theItem As New PAItem
      theItem.Level = 1
      theItem.Entity = newItem
      theItem.RefEntity = New RefEntity
      theItem.ItemType = New PAIItemType(0)
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index + 1
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      If Not Me.m_entity.ItemCollection.Contains(doc) Then
        Return
      End If

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
        If Not row Is Nothing AndAlso TypeOf row.Tag Is PAItem Then
          Dim itm As PAItem = CType(row.Tag, PAItem)
          If Not itm Is Nothing Then
            If Me.m_entity.ItemCollection.Contains(itm) Then
              Me.m_entity.ItemCollection.Remove(itm)
              Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
          End If
        End If
      Next

      'Me.m_entity.ItemCollection.Remove(doc)

      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim isSetIndex As Boolean = False

      'Dim hashParent As New Hashtable
      'Dim hashChild As New Hashtable

      'Dim key As String = ""
      'Dim parent As String = ""
      'Dim child As String = ""

      'For Each Obj As Object In Me.m_treeManager.SelectedRows
      '  If Not Obj Is Nothing AndAlso TypeOf Obj Is TreeRow Then
      '    Dim row As TreeRow = CType(Obj, TreeRow)
      '    If Not row Is Nothing AndAlso TypeOf row.Tag Is PAItem Then

      '      Dim sitem As PAItem = CType(row.Tag, PAItem)
      '      key = sitem.RefDocType.ToString & ":" & sitem.RefSequence.ToString
      '      If sitem.Level = 0 Then
      '        If Not hashParent.Contains(key) Then
      '          hashParent(key) = sitem
      '        End If
      '      Else
      '        If Not hashChild.Contains(key) Then
      '          hashChild(key) = sitem
      '        End If
      '      End If

      '    End If
      '  End If
      'Next

      'For Each sitem As PAItem In Me.m_entity.ItemCollection 'หาลูกทั้งหมด
      '  For Each pitem As PAItem In hashParent.Values
      '    If sitem.Parent = pitem.Parent AndAlso sitem.Level = 1 Then
      '      key = sitem.RefDocType.ToString & ":" & sitem.RefSequence.ToString
      '      If Not hashChild.Contains(key) Then
      '        hashChild(key) = sitem
      '      End If
      '    End If
      '  Next
      'Next

      'For Each pitm As PAItem In hashChild.Values
      '  If Me.m_entity.ItemCollection.Contains(pitm) Then
      '    Me.m_entity.ItemCollection.Remove(pitm)
      '    Me.WorkbenchWindow.ViewContent.IsDirty = True
      '  End If
      'Next

      'For Each pitm As PAItem In hashParent.Values
      '  If Me.m_entity.ItemCollection.Contains(pitm) Then
      '    Me.m_entity.ItemCollection.Remove(pitm)
      '    Me.WorkbenchWindow.ViewContent.IsDirty = True
      '  End If
      'Next



      'hashParent = New Hashtable
      'Dim countParent As Integer = 0
      'For Each pcol As PAItem In Me.m_entity.ItemCollection
      '  parent = pcol.Parent.ToString
      '  If pcol.Level = 0 Then
      '    hashParent(key) = pcol
      '  Else
      '    If hashParent.Contains(key) Then
      '      If pcol.Parent = CType(hashParent(key), PAItem).Parent Then
      '        countParent += 1

      '        'Dim ix As Integer = Me.m_entity.ItemCollection.IndexOf(CType(hashParent(key), PAItem))
      '        'If Me.m_entity.ItemCollection(ix).HashOnlyOneChild = True Then
      '        '  Me.m_entity.ItemCollection(ix).HashOnlyOneChild = False
      '        'Else
      '        '  Me.m_entity.ItemCollection(ix).HashOnlyOneChild = True
      '        'End If

      '      End If
      '    End If
      '  End If
      'Next

      'hashParent = New Hashtable
      'For Each pitm As PAItem In hashChild.Values
      '  For Each pcol As PAItem In Me.m_entity.ItemCollection
      '    If pitm.Parent = pcol.Parent Then
      '      parent = pitm.Parent.ToString
      '      If pcol.Level = 0 AndAlso pcol.HashOnlyOneChild Then
      '        'MessageBox.Show(pcol.Level.ToString & vbCrLf & pcol.HashOnlyOneChild.ToString)
      '        hashParent(parent) = pcol
      '      End If
      '    End If
      '  Next
      'Next
      'For Each itm As PAItem In hashParent.Values
      '  'MessageBox.Show(itm.EntityName)
      '  If Me.m_entity.ItemCollection.Contains(itm) Then
      '    Me.m_entity.ItemCollection.Remove(itm)
      '    Me.WorkbenchWindow.ViewContent.IsDirty = True
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

      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New PA).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Requestor
    Private Sub btnDirectorEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectorEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(Me.m_entity.Receiver)
    End Sub
    Private Sub btnRequestorFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectorFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(Me.m_entity.Receiver, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtDirectorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtDirectorCode, txtDirectorName, Me.m_entity.Receiver)
    End Sub
    ' Costcenter
    'PO
    Private Sub ibtnShowSCDialog_click(ByVal sendr As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSCDialog.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.Sc Is Nothing OrElse Not Me.m_entity.Sc.Originated OrElse _
          msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.PADetail.Message.ChangeSC}", _
          "${res:Longkong.Pojjaman.Gui.Panels.PADetail.Caption.ChangeSC}") Then
        Dim myEntityPanelService As IEntityPanelService = _
        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim entities As New ArrayList
        entities.Add(New SCForPA)
        If Not Me.m_entity.CostCenter Is Nothing Then
          entities.Add(Me.m_entity.CostCenter)
        End If

        'If Me.m_entity.Sc.SubContractor.Originated Then
        '    entities.Add(Me.m_entity.Sc.SubContractor)
        'End If
        'If Me.m_entity.Sc.CostCenter.Originated Then
        '    entities.Add(Me.m_entity.Sc.CostCenter)
        'End If

        Dim scNeedsApproval As Boolean = False
        scNeedsApproval = CBool(Configuration.GetConfig("ApproveSC"))
        Dim filters(1) As Filter
        filters(0) = New Filter("scNeedsApproval", scNeedsApproval)
        filters(1) = New Filter("excludedepleted", True)
        myEntityPanelService.OpenListDialog(New SCForPA, AddressOf SetSC, filters)
        'myEntityPanelService.OpenListDialog(Me.m_entity.Sc, AddressOf SetSC, filters)
      End If
    End Sub
    Private Sub SetSC(ByVal e As ISimpleEntity)
      'Dim scNeedsApproval As Boolean = False
      'scNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
      'Dim newSc As SC = CType(e, SC)
      If Me.m_entity Is Nothing Then
        Return
      End If

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
      Me.txtSubContractorCode.Text = Me.m_entity.Sc.SubContractor.Code
      Me.txtSubContractorName.Text = Me.m_entity.Sc.SubContractor.Name
      Me.txtCostCenterCode.Text = Me.m_entity.Sc.CostCenter.Code
      Me.txtCostCenterName.Text = Me.m_entity.Sc.CostCenter.Name
      'For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
      '    vitem.PrintName = Me.m_entity.Supplier.Name
      '    vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
      'Next
      'Me.m_entity.AdvancePayItemCollection.Clear()

      Me.m_entity.CreditPeriod = Me.m_entity.Sc.CreditPeriod
      Me.m_entity.ContactPerson = Me.m_entity.Sc.ContactPerson
      Me.txtCredit.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)

      Me.InitialCombo()

      If Not m_entity.SubContractor Is Nothing Then
        For itemIndex As Integer = 0 To Me.cmbContact.Items.Count - 1
          If Me.m_entity.ContactPerson = Me.cmbContact.Items(itemIndex) Then
            Me.cmbContact.SelectedIndex = itemIndex
          End If
        Next
      End If

      m_isInitialized = flag

      RefreshDocs()

      UpdateAmount()
      'scCodeChanged = False
    End Sub
    'Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
    '    Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '    Dim myEntityPanelService As IEntityPanelService = _
    '                CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenTreeDialog(Me.m_entity.CostCenter, AddressOf SetCostCenterDialog)
    'End Sub
    'Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
    '    If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
    '        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
    '            If Me.txtCostCenterCode.TextLength = 0 Then
    '                Me.m_entity.CostCenter = New CostCenter
    '            End If
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
    '            ccCodeChanged = False
    '        Else
    '            Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
    '            ccCodeChanged = False
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
    'Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
    '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenPanel(Me.m_entity.CostCenter)
    'End Sub
    'Private Sub ChangeCC()
    '    'For Each item As PAItem In Me.m_entity.ItemCollection
    '    '    item.WBSDistributeCollection.Clear()
    '    'Next
    '    'RefreshWBS()
    'End Sub
    Private Sub UpdateDestAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Try
        'Me.m_entity.Requestor = Me.m_entity.CostCenter.Admin
        'Me.txtRequestorCode.Text = m_entity.Requestor.Code
        'txtRequestorName.Text = m_entity.Requestor.Name
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
    '    For Each item As PaItem In Me.m_entity.ItemCollection
    '        If Not item.Pritem Is Nothing Then
    '            ret &= "|" & item.Pritem.Pr.Id.ToString & ":" & item.Pritem.LineNumber.ToString & "|"
    '        End If
    '    Next
    '    Return ret
    'End Function
    'Private Sub ibtnGetFromBOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim arr As New ArrayList
    '    arr.Add(Me.m_entity.CostCenter)
    '    Dim myEntityPanelService As IEntityPanelService = _
    '                CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenListDialog(New BOQForSelection, AddressOf SetItems, arr)
    'End Sub

    ' Supplier
    'Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierEdit.Click
    '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenPanel(New Supplier)
    'End Sub
    'Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierFind.Click
    '    Dim myEntityPanelService As IEntityPanelService = _
    '    CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    'End Sub
    'Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
    '    Me.txtSubContractorCode.Text = e.Code
    '    Me.WorkbenchWindow.ViewContent.IsDirty = _
    '        Me.WorkbenchWindow.ViewContent.IsDirty _
    '        Or Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.Sc.SubContractor, True)
    '    m_isInitialized = False
    '    '    'Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
    '    '    'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
    '    '    m_isInitialized = True
    'End Sub
    'Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ''PJMModule
    '    'Dim x As Form
    '    '   If m_ApproveDocModule.Activated Then
    '    '	x = New AdvanceApprovalCommentForm(Me.Entity)
    '    '   Else
    '    '	x = New ApprovalCommentForm(Me.Entity)
    '    'End If
    '    'x.ShowDialog()
    '    'CheckFormEnable()
    'End Sub
    Private Sub ibtnShowAdvancePay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAdvancePay.Click
      Dim dlg As New AdvancePaySelection(Me.m_entity)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        forceUpdateTaxBase = True
        forceUpdateTaxAmount = True
        forceUpdateGross = True
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
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
            'Case "txtsuppliercode", "txtsuppliername"
            '    Me.SetSupplierDialog(entity)
            Case ""
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
      'RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      'If Me.tgItem.Height = 0 Then
      '  Return
      'End If
      'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      'Dim index As Integer = tgItem.CurrentRowIndex

      ''Dim index As Integer = tgItem.CurrentRowIndex
      ''Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentRealItem
      ''If doc Is Nothing Then
      ''  Return
      ''End If
      ' ''If Not doc.SCItem Is Nothing Then
      ' ''    Return
      ' ''End If
      ' ''Dim newItem As New BlankItem("")
      ''Dim theItem As New SCItem
      ' ''theItem.Entity = newItem
      ''theItem.Level = 0
      ' ''theItem.ItemType = New ItemType(0)
      ''theItem.Qty = 0
      ''Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      ''RefreshDocs()
      ''tgItem.CurrentRowIndex = index + 1
      ''Me.WorkbenchWindow.ViewContent.IsDirty = True

      'Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
      '  'เพิ่มแถวจนเต็ม
      '  'Me.m_treeManager.Treetable.Childs.Add()
      '  Dim newRow As TreeRow
      '  newRow = Me.m_treeManager.Treetable.Childs.Add()
      '  newRow("pai_level") = 0
      '  newRow("Button") = "invisible"
      'Loop

      'If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
      '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '  'Me.m_treeManager.Treetable.Childs.Add()
      '  Dim newRow As TreeRow
      '  newRow = Me.m_treeManager.Treetable.Childs.Add()
      '  newRow("pai_level") = 0
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
    End Sub

#End Region

    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub chkClosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Not m_isInitialized Then
        Return
      End If
      'Me.m_entity.Closed = Me.chkClosed.Checked
      'If Me.m_entity.Closed Then
      '    Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.chkClosedCancel}")
      'Else
      '    Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.chkClosed}")
      'End If
      'Me.SetColumnOriginQty()
      'Me.RefreshDocs()
      'Me.RefreshWBS()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

#Region "Customization"
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Try
          Dim approveDocColl As New ApproveDocCollection(m_entity)
          Dim paNeedsApproval As Boolean = CBool(Configuration.GetConfig("PaApproveBeforePrint"))
          If paNeedsApproval Then
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

#Region "IPreviewable"
    Public ReadOnly Property CanPreview As Boolean Implements Commands.IPreviewable.CanPreview
      Get
        Return True
      End Get
    End Property
#End Region

  End Class
End Namespace

