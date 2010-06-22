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
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Namespace Longkong.Pojjaman.Gui.Panels
	Public Class GoodsReceiptDetail
		Inherits AbstractEntityDetailPanelView
    Implements IValidatable, ICanRefreshAutoComplete

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
		Friend WithEvents txtNote As System.Windows.Forms.TextBox
		Friend WithEvents lblNote As System.Windows.Forms.Label
		Friend WithEvents lblItem As System.Windows.Forms.Label
		Friend WithEvents grbReceive As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents grbDelivery As Longkong.Pojjaman.Gui.Components.FixedGroupBox
		Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
		Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
		Friend WithEvents lblCode As System.Windows.Forms.Label
		Friend WithEvents lblDeliveryCode As System.Windows.Forms.Label
		Friend WithEvents txtDeliveryCode As System.Windows.Forms.TextBox
		Friend WithEvents lblDeliveryDocDate As System.Windows.Forms.Label
		Friend WithEvents lblInvoiceCode As System.Windows.Forms.Label
		Friend WithEvents txtInvoiceCode As System.Windows.Forms.TextBox
		Friend WithEvents txtPOCode As System.Windows.Forms.TextBox
		Friend WithEvents ibtnShowPODialog As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
		Friend WithEvents lblDocDate As System.Windows.Forms.Label
		Friend WithEvents lblPOCode As System.Windows.Forms.Label
		Friend WithEvents lblPODate As System.Windows.Forms.Label
		Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
		Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
		Friend WithEvents txtDeliveryDocDate As System.Windows.Forms.TextBox
		Friend WithEvents dtpDeliveryDocDate As System.Windows.Forms.DateTimePicker
		Friend WithEvents txtPODate As System.Windows.Forms.TextBox
		Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
		Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
		Friend WithEvents txtInvoiceDate As System.Windows.Forms.TextBox
		Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents lblTaxAmount As System.Windows.Forms.Label
		Friend WithEvents lblAfterTax As System.Windows.Forms.Label
		Friend WithEvents txtGross As System.Windows.Forms.TextBox
		Friend WithEvents lblDiscountAmount As System.Windows.Forms.Label
		Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
		Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
		Friend WithEvents lblGross As System.Windows.Forms.Label
		Friend WithEvents txtBeforeTax As System.Windows.Forms.TextBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
		Friend WithEvents txtAfterTax As System.Windows.Forms.TextBox
		Friend WithEvents txtDiscountRate As System.Windows.Forms.TextBox
		Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
		Friend WithEvents lblTaxType As System.Windows.Forms.Label
		Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
		Friend WithEvents lblTaxRate As System.Windows.Forms.Label
		Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
		Friend WithEvents lblTaxBase As System.Windows.Forms.Label
		Friend WithEvents lblPercent As System.Windows.Forms.Label
		Friend WithEvents txtToCCPersonName As System.Windows.Forms.TextBox
		Friend WithEvents txtToCCPersonCode As System.Windows.Forms.TextBox
		Friend WithEvents ibtShowToCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
		Friend WithEvents ibtnShowToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
		Friend WithEvents lblToCCPerson As System.Windows.Forms.Label
		Friend WithEvents lblToCostCenter As System.Windows.Forms.Label
		Friend WithEvents ibtnShowSupplier As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
		Friend WithEvents ibtnShowSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents lblSupplier As System.Windows.Forms.Label
		Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
		Friend WithEvents txtCreditPrd As System.Windows.Forms.TextBox
		Friend WithEvents lblCreditPrd As System.Windows.Forms.Label
		Friend WithEvents lblDay As System.Windows.Forms.Label
		Friend WithEvents ibtnEnableVatInput As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
		Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
		Friend WithEvents txtDeliveryPerson As System.Windows.Forms.TextBox
		Friend WithEvents lblDeliveryPerson As System.Windows.Forms.Label
		Friend WithEvents ibtnShowToCCPerson As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents ibtnShowToCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbDocType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDocType As System.Windows.Forms.Label
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents txtRetention As System.Windows.Forms.TextBox
    Friend WithEvents lblRetention As System.Windows.Forms.Label
    Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents txtRealGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblAdvancePay As System.Windows.Forms.Label
    Friend WithEvents txtAdvancePayAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowAdvancePay As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtWHT As System.Windows.Forms.TextBox
    Friend WithEvents lblWHT As System.Windows.Forms.Label
    Friend WithEvents ibtnShowEquipment As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEquipmentName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowEquipmentDiaog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEquipmentCode As System.Windows.Forms.TextBox
    Friend WithEvents lblEquipment As System.Windows.Forms.Label
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents ibtUnlocker As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodsReceiptDetail))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbReceive = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnShowEquipment = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtEquipmentName = New System.Windows.Forms.TextBox()
      Me.ibtnShowEquipmentDiaog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtEquipmentCode = New System.Windows.Forms.TextBox()
      Me.lblEquipment = New System.Windows.Forms.Label()
      Me.cmbDocType = New System.Windows.Forms.ComboBox()
      Me.lblDocType = New System.Windows.Forms.Label()
      Me.txtToCCPersonName = New System.Windows.Forms.TextBox()
      Me.txtToCCPersonCode = New System.Windows.Forms.TextBox()
      Me.ibtShowToCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox()
      Me.ibtnShowToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox()
      Me.lblToCCPerson = New System.Windows.Forms.Label()
      Me.lblToCostCenter = New System.Windows.Forms.Label()
      Me.ibtnShowToCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowToCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbDelivery = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDueDate = New System.Windows.Forms.TextBox()
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDueDate = New System.Windows.Forms.Label()
      Me.ibtnShowSupplier = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.ibtnShowSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.lblCreditPrd = New System.Windows.Forms.Label()
      Me.lblDay = New System.Windows.Forms.Label()
      Me.txtCreditPrd = New System.Windows.Forms.TextBox()
      Me.txtDeliveryPerson = New System.Windows.Forms.TextBox()
      Me.lblDeliveryPerson = New System.Windows.Forms.Label()
      Me.lblPOCode = New System.Windows.Forms.Label()
      Me.lblPODate = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblDeliveryCode = New System.Windows.Forms.Label()
      Me.txtDeliveryCode = New System.Windows.Forms.TextBox()
      Me.lblDeliveryDocDate = New System.Windows.Forms.Label()
      Me.lblInvoiceCode = New System.Windows.Forms.Label()
      Me.txtInvoiceCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtDeliveryDocDate = New System.Windows.Forms.TextBox()
      Me.txtPODate = New System.Windows.Forms.TextBox()
      Me.txtInvoiceDate = New System.Windows.Forms.TextBox()
      Me.txtRetention = New System.Windows.Forms.TextBox()
      Me.txtPOCode = New System.Windows.Forms.TextBox()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
      Me.txtBeforeTax = New System.Windows.Forms.TextBox()
      Me.txtTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtAfterTax = New System.Windows.Forms.TextBox()
      Me.txtDiscountRate = New System.Windows.Forms.TextBox()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
      Me.txtRealGross = New System.Windows.Forms.TextBox()
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtAdvancePayAmount = New System.Windows.Forms.TextBox()
      Me.txtWHT = New System.Windows.Forms.TextBox()
      Me.ibtnShowPODialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.dtpDeliveryDocDate = New System.Windows.Forms.DateTimePicker()
      Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
      Me.lblInvoiceDate = New System.Windows.Forms.Label()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblTaxAmount = New System.Windows.Forms.Label()
      Me.lblAfterTax = New System.Windows.Forms.Label()
      Me.lblDiscountAmount = New System.Windows.Forms.Label()
      Me.lblBeforeTax = New System.Windows.Forms.Label()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.lblTaxRate = New System.Windows.Forms.Label()
      Me.lblTaxBase = New System.Windows.Forms.Label()
      Me.lblPercent = New System.Windows.Forms.Label()
      Me.ibtnEnableVatInput = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.lblRetention = New System.Windows.Forms.Label()
      Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.lblAdvancePay = New System.Windows.Forms.Label()
      Me.ibtnShowAdvancePay = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblWHT = New System.Windows.Forms.Label()
      Me.ibtUnlocker = New Longkong.Pojjaman.Gui.Components.ImageButton()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbReceive.SuspendLayout()
      Me.grbDelivery.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 166)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(847, 432)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 19
      Me.tgItem.TreeManager = Nothing
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 7)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(94, 18)
      Me.lblCode.TabIndex = 13
      Me.lblCode.Text = "เลขที่ใบรับของ:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(256, 10)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblDocDate.TabIndex = 16
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 145)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 29
      Me.lblItem.Text = "รายการรับของ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbReceive
      '
      Me.grbReceive.Controls.Add(Me.ibtnShowEquipment)
      Me.grbReceive.Controls.Add(Me.txtEquipmentName)
      Me.grbReceive.Controls.Add(Me.ibtnShowEquipmentDiaog)
      Me.grbReceive.Controls.Add(Me.txtEquipmentCode)
      Me.grbReceive.Controls.Add(Me.lblEquipment)
      Me.grbReceive.Controls.Add(Me.cmbDocType)
      Me.grbReceive.Controls.Add(Me.lblDocType)
      Me.grbReceive.Controls.Add(Me.txtToCCPersonName)
      Me.grbReceive.Controls.Add(Me.txtToCCPersonCode)
      Me.grbReceive.Controls.Add(Me.ibtShowToCostCenter)
      Me.grbReceive.Controls.Add(Me.txtToCostCenterName)
      Me.grbReceive.Controls.Add(Me.ibtnShowToCostCenterDialog)
      Me.grbReceive.Controls.Add(Me.txtToCostCenterCode)
      Me.grbReceive.Controls.Add(Me.lblToCCPerson)
      Me.grbReceive.Controls.Add(Me.lblToCostCenter)
      Me.grbReceive.Controls.Add(Me.ibtnShowToCCPerson)
      Me.grbReceive.Controls.Add(Me.ibtnShowToCCPersonDialog)
      Me.grbReceive.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbReceive.Location = New System.Drawing.Point(400, 51)
      Me.grbReceive.Name = "grbReceive"
      Me.grbReceive.Size = New System.Drawing.Size(369, 114)
      Me.grbReceive.TabIndex = 9
      Me.grbReceive.TabStop = False
      Me.grbReceive.Text = "รับของ"
      '
      'ibtnShowEquipment
      '
      Me.ibtnShowEquipment.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEquipment.Location = New System.Drawing.Point(339, 86)
      Me.ibtnShowEquipment.Name = "ibtnShowEquipment"
      Me.ibtnShowEquipment.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEquipment.TabIndex = 38
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
      Me.txtEquipmentName.Location = New System.Drawing.Point(167, 86)
      Me.Validator.SetMinValue(Me.txtEquipmentName, "")
      Me.txtEquipmentName.Name = "txtEquipmentName"
      Me.txtEquipmentName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEquipmentName, "")
      Me.Validator.SetRequired(Me.txtEquipmentName, False)
      Me.txtEquipmentName.Size = New System.Drawing.Size(149, 20)
      Me.txtEquipmentName.TabIndex = 280
      Me.txtEquipmentName.TabStop = False
      '
      'ibtnShowEquipmentDiaog
      '
      Me.ibtnShowEquipmentDiaog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEquipmentDiaog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEquipmentDiaog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEquipmentDiaog.Location = New System.Drawing.Point(315, 86)
      Me.ibtnShowEquipmentDiaog.Name = "ibtnShowEquipmentDiaog"
      Me.ibtnShowEquipmentDiaog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEquipmentDiaog.TabIndex = 37
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
      Me.txtEquipmentCode.Location = New System.Drawing.Point(94, 86)
      Me.Validator.SetMinValue(Me.txtEquipmentCode, "")
      Me.txtEquipmentCode.Name = "txtEquipmentCode"
      Me.Validator.SetRegularExpression(Me.txtEquipmentCode, "")
      Me.Validator.SetRequired(Me.txtEquipmentCode, False)
      Me.txtEquipmentCode.Size = New System.Drawing.Size(72, 20)
      Me.txtEquipmentCode.TabIndex = 14
      '
      'lblEquipment
      '
      Me.lblEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEquipment.Location = New System.Drawing.Point(10, 86)
      Me.lblEquipment.Name = "lblEquipment"
      Me.lblEquipment.Size = New System.Drawing.Size(80, 18)
      Me.lblEquipment.TabIndex = 277
      Me.lblEquipment.Text = "เครื่องจักร:"
      Me.lblEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbDocType
      '
      Me.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDocType.Location = New System.Drawing.Point(94, 61)
      Me.cmbDocType.Name = "cmbDocType"
      Me.cmbDocType.Size = New System.Drawing.Size(248, 21)
      Me.cmbDocType.TabIndex = 13
      '
      'lblDocType
      '
      Me.lblDocType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocType.Location = New System.Drawing.Point(9, 61)
      Me.lblDocType.Name = "lblDocType"
      Me.lblDocType.Size = New System.Drawing.Size(82, 18)
      Me.lblDocType.TabIndex = 11
      Me.lblDocType.Text = "ซื้อเพื่อ:"
      Me.lblDocType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToCCPersonName
      '
      Me.Validator.SetDataType(Me.txtToCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.txtToCCPersonName.Location = New System.Drawing.Point(167, 37)
      Me.Validator.SetMinValue(Me.txtToCCPersonName, "")
      Me.txtToCCPersonName.Name = "txtToCCPersonName"
      Me.txtToCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCCPersonName, "")
      Me.Validator.SetRequired(Me.txtToCCPersonName, False)
      Me.txtToCCPersonName.Size = New System.Drawing.Size(149, 20)
      Me.txtToCCPersonName.TabIndex = 5
      Me.txtToCCPersonName.TabStop = False
      '
      'txtToCCPersonCode
      '
      Me.Validator.SetDataType(Me.txtToCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.txtToCCPersonCode.Location = New System.Drawing.Point(94, 37)
      Me.Validator.SetMinValue(Me.txtToCCPersonCode, "")
      Me.txtToCCPersonCode.Name = "txtToCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtToCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtToCCPersonCode, True)
      Me.txtToCCPersonCode.Size = New System.Drawing.Size(72, 20)
      Me.txtToCCPersonCode.TabIndex = 12
      '
      'ibtShowToCostCenter
      '
      Me.ibtShowToCostCenter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtShowToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtShowToCostCenter.Location = New System.Drawing.Point(339, 12)
      Me.ibtShowToCostCenter.Name = "ibtShowToCostCenter"
      Me.ibtShowToCostCenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtShowToCostCenter.TabIndex = 34
      Me.ibtShowToCostCenter.TabStop = False
      Me.ibtShowToCostCenter.ThemedImage = CType(resources.GetObject("ibtShowToCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCostCenterName
      '
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(167, 13)
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(149, 20)
      Me.txtToCostCenterName.TabIndex = 4
      Me.txtToCostCenterName.TabStop = False
      '
      'ibtnShowToCostCenterDialog
      '
      Me.ibtnShowToCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCostCenterDialog.Location = New System.Drawing.Point(315, 12)
      Me.ibtnShowToCostCenterDialog.Name = "ibtnShowToCostCenterDialog"
      Me.ibtnShowToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCostCenterDialog.TabIndex = 33
      Me.ibtnShowToCostCenterDialog.TabStop = False
      Me.ibtnShowToCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(94, 13)
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, True)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(72, 20)
      Me.txtToCostCenterCode.TabIndex = 11
      '
      'lblToCCPerson
      '
      Me.lblToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCPerson.Location = New System.Drawing.Point(9, 37)
      Me.lblToCCPerson.Name = "lblToCCPerson"
      Me.lblToCCPerson.Size = New System.Drawing.Size(82, 18)
      Me.lblToCCPerson.TabIndex = 3
      Me.lblToCCPerson.Text = "ผู้รับ:"
      Me.lblToCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblToCostCenter
      '
      Me.lblToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCostCenter.Location = New System.Drawing.Point(9, 13)
      Me.lblToCostCenter.Name = "lblToCostCenter"
      Me.lblToCostCenter.Size = New System.Drawing.Size(82, 18)
      Me.lblToCostCenter.TabIndex = 2
      Me.lblToCostCenter.Text = "คลัง:"
      Me.lblToCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowToCCPerson
      '
      Me.ibtnShowToCCPerson.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPerson.Location = New System.Drawing.Point(339, 36)
      Me.ibtnShowToCCPerson.Name = "ibtnShowToCCPerson"
      Me.ibtnShowToCCPerson.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPerson.TabIndex = 36
      Me.ibtnShowToCCPerson.TabStop = False
      Me.ibtnShowToCCPerson.ThemedImage = CType(resources.GetObject("ibtnShowToCCPerson.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowToCCPersonDialog
      '
      Me.ibtnShowToCCPersonDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowToCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCCPersonDialog.Location = New System.Drawing.Point(315, 36)
      Me.ibtnShowToCCPersonDialog.Name = "ibtnShowToCCPersonDialog"
      Me.ibtnShowToCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPersonDialog.TabIndex = 35
      Me.ibtnShowToCCPersonDialog.TabStop = False
      Me.ibtnShowToCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbDelivery
      '
      Me.grbDelivery.Controls.Add(Me.txtDueDate)
      Me.grbDelivery.Controls.Add(Me.dtpDueDate)
      Me.grbDelivery.Controls.Add(Me.lblDueDate)
      Me.grbDelivery.Controls.Add(Me.ibtnShowSupplier)
      Me.grbDelivery.Controls.Add(Me.txtSupplierName)
      Me.grbDelivery.Controls.Add(Me.ibtnShowSupplierDialog)
      Me.grbDelivery.Controls.Add(Me.lblSupplier)
      Me.grbDelivery.Controls.Add(Me.txtSupplierCode)
      Me.grbDelivery.Controls.Add(Me.lblCreditPrd)
      Me.grbDelivery.Controls.Add(Me.lblDay)
      Me.grbDelivery.Controls.Add(Me.txtCreditPrd)
      Me.grbDelivery.Controls.Add(Me.txtDeliveryPerson)
      Me.grbDelivery.Controls.Add(Me.lblDeliveryPerson)
      Me.grbDelivery.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDelivery.Location = New System.Drawing.Point(8, 51)
      Me.grbDelivery.Name = "grbDelivery"
      Me.grbDelivery.Size = New System.Drawing.Size(388, 87)
      Me.grbDelivery.TabIndex = 7
      Me.grbDelivery.TabStop = False
      Me.grbDelivery.Text = "ส่งของ"
      '
      'txtDueDate
      '
      Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDueDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.txtDueDate.Location = New System.Drawing.Point(216, 37)
      Me.Validator.SetMinValue(Me.txtDueDate, "")
      Me.txtDueDate.Name = "txtDueDate"
      Me.Validator.SetRegularExpression(Me.txtDueDate, "")
      Me.Validator.SetRequired(Me.txtDueDate, True)
      Me.txtDueDate.Size = New System.Drawing.Size(84, 20)
      Me.txtDueDate.TabIndex = 9
      '
      'dtpDueDate
      '
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDate.Location = New System.Drawing.Point(216, 37)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(104, 20)
      Me.dtpDueDate.TabIndex = 32
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.ForeColor = System.Drawing.Color.Black
      Me.lblDueDate.Location = New System.Drawing.Point(144, 37)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(72, 18)
      Me.lblDueDate.TabIndex = 16
      Me.lblDueDate.Text = "ครบกำหนด:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowSupplier
      '
      Me.ibtnShowSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplier.Location = New System.Drawing.Point(358, 13)
      Me.ibtnShowSupplier.Name = "ibtnShowSupplier"
      Me.ibtnShowSupplier.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplier.TabIndex = 31
      Me.ibtnShowSupplier.TabStop = False
      Me.ibtnShowSupplier.ThemedImage = CType(resources.GetObject("ibtnShowSupplier.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierName
      '
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(176, 13)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(158, 20)
      Me.txtSupplierName.TabIndex = 8
      Me.txtSupplierName.TabStop = False
      '
      'ibtnShowSupplierDialog
      '
      Me.ibtnShowSupplierDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowSupplierDialog.Location = New System.Drawing.Point(334, 13)
      Me.ibtnShowSupplierDialog.Name = "ibtnShowSupplierDialog"
      Me.ibtnShowSupplierDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplierDialog.TabIndex = 30
      Me.ibtnShowSupplierDialog.TabStop = False
      Me.ibtnShowSupplierDialog.ThemedImage = CType(resources.GetObject("ibtnShowSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSupplier
      '
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(14, 13)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(80, 18)
      Me.lblSupplier.TabIndex = 3
      Me.lblSupplier.Text = "Supplier:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierCode
      '
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(96, 13)
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, True)
      Me.txtSupplierCode.Size = New System.Drawing.Size(79, 20)
      Me.txtSupplierCode.TabIndex = 7
      '
      'lblCreditPrd
      '
      Me.lblCreditPrd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCreditPrd.Location = New System.Drawing.Point(14, 37)
      Me.lblCreditPrd.Name = "lblCreditPrd"
      Me.lblCreditPrd.Size = New System.Drawing.Size(80, 18)
      Me.lblCreditPrd.TabIndex = 4
      Me.lblCreditPrd.Text = "ระยะเครดิต:"
      Me.lblCreditPrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDay
      '
      Me.lblDay.AutoSize = True
      Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDay.Location = New System.Drawing.Point(128, 39)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(19, 13)
      Me.lblDay.TabIndex = 7
      Me.lblDay.Text = "วัน"
      Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtCreditPrd
      '
      Me.Validator.SetDataType(Me.txtCreditPrd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
      Me.Validator.SetDisplayName(Me.txtCreditPrd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
      Me.txtCreditPrd.Location = New System.Drawing.Point(96, 37)
      Me.Validator.SetMinValue(Me.txtCreditPrd, "0")
      Me.txtCreditPrd.Name = "txtCreditPrd"
      Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
      Me.Validator.SetRequired(Me.txtCreditPrd, False)
      Me.txtCreditPrd.Size = New System.Drawing.Size(32, 20)
      Me.txtCreditPrd.TabIndex = 8
      '
      'txtDeliveryPerson
      '
      Me.Validator.SetDataType(Me.txtDeliveryPerson, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDeliveryPerson, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDeliveryPerson, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDeliveryPerson, System.Drawing.Color.Empty)
      Me.txtDeliveryPerson.Location = New System.Drawing.Point(96, 61)
      Me.Validator.SetMinValue(Me.txtDeliveryPerson, "")
      Me.txtDeliveryPerson.Name = "txtDeliveryPerson"
      Me.Validator.SetRegularExpression(Me.txtDeliveryPerson, "")
      Me.Validator.SetRequired(Me.txtDeliveryPerson, False)
      Me.txtDeliveryPerson.Size = New System.Drawing.Size(224, 20)
      Me.txtDeliveryPerson.TabIndex = 10
      '
      'lblDeliveryPerson
      '
      Me.lblDeliveryPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDeliveryPerson.Location = New System.Drawing.Point(6, 61)
      Me.lblDeliveryPerson.Name = "lblDeliveryPerson"
      Me.lblDeliveryPerson.Size = New System.Drawing.Size(88, 18)
      Me.lblDeliveryPerson.TabIndex = 6
      Me.lblDeliveryPerson.Text = "DeliveryPerson:"
      Me.lblDeliveryPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPOCode
      '
      Me.lblPOCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPOCode.ForeColor = System.Drawing.Color.Black
      Me.lblPOCode.Location = New System.Drawing.Point(374, 7)
      Me.lblPOCode.Name = "lblPOCode"
      Me.lblPOCode.Size = New System.Drawing.Size(96, 18)
      Me.lblPOCode.TabIndex = 20
      Me.lblPOCode.Text = "เลขที่ PO:"
      Me.lblPOCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPODate
      '
      Me.lblPODate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPODate.ForeColor = System.Drawing.Color.Black
      Me.lblPODate.Location = New System.Drawing.Point(614, 7)
      Me.lblPODate.Name = "lblPODate"
      Me.lblPODate.Size = New System.Drawing.Size(32, 18)
      Me.lblPODate.TabIndex = 23
      Me.lblPODate.Text = "วันที่:"
      Me.lblPODate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(8, 625)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(236, 93)
      Me.txtNote.TabIndex = 15
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 605)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(94, 18)
      Me.lblNote.TabIndex = 32
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblDeliveryCode
      '
      Me.lblDeliveryCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDeliveryCode.ForeColor = System.Drawing.Color.Black
      Me.lblDeliveryCode.Location = New System.Drawing.Point(8, 31)
      Me.lblDeliveryCode.Name = "lblDeliveryCode"
      Me.lblDeliveryCode.Size = New System.Drawing.Size(94, 18)
      Me.lblDeliveryCode.TabIndex = 14
      Me.lblDeliveryCode.Text = "เลขที่ใบส่งของ:"
      Me.lblDeliveryCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDeliveryCode
      '
      Me.Validator.SetDataType(Me.txtDeliveryCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDeliveryCode, "")
      Me.txtDeliveryCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDeliveryCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDeliveryCode, System.Drawing.Color.Empty)
      Me.txtDeliveryCode.Location = New System.Drawing.Point(104, 31)
      Me.Validator.SetMinValue(Me.txtDeliveryCode, "")
      Me.txtDeliveryCode.Name = "txtDeliveryCode"
      Me.Validator.SetRegularExpression(Me.txtDeliveryCode, "")
      Me.Validator.SetRequired(Me.txtDeliveryCode, False)
      Me.txtDeliveryCode.Size = New System.Drawing.Size(112, 21)
      Me.txtDeliveryCode.TabIndex = 3
      Me.txtDeliveryCode.TabStop = False
      '
      'lblDeliveryDocDate
      '
      Me.lblDeliveryDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDeliveryDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDeliveryDocDate.Location = New System.Drawing.Point(222, 34)
      Me.lblDeliveryDocDate.Name = "lblDeliveryDocDate"
      Me.lblDeliveryDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblDeliveryDocDate.TabIndex = 17
      Me.lblDeliveryDocDate.Text = "วันที่:"
      Me.lblDeliveryDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInvoiceCode
      '
      Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceCode.Location = New System.Drawing.Point(370, 31)
      Me.lblInvoiceCode.Name = "lblInvoiceCode"
      Me.lblInvoiceCode.Size = New System.Drawing.Size(100, 18)
      Me.lblInvoiceCode.TabIndex = 21
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
      Me.txtInvoiceCode.Location = New System.Drawing.Point(470, 31)
      Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
      Me.txtInvoiceCode.Name = "txtInvoiceCode"
      Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
      Me.Validator.SetRequired(Me.txtInvoiceCode, False)
      Me.txtInvoiceCode.Size = New System.Drawing.Size(112, 21)
      Me.txtInvoiceCode.TabIndex = 5
      Me.txtInvoiceCode.TabStop = False
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
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(298, 7)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDocDate.TabIndex = 1
      '
      'txtDeliveryDocDate
      '
      Me.Validator.SetDataType(Me.txtDeliveryDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDeliveryDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDeliveryDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDeliveryDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDeliveryDocDate, System.Drawing.Color.Empty)
      Me.txtDeliveryDocDate.Location = New System.Drawing.Point(264, 31)
      Me.Validator.SetMinValue(Me.txtDeliveryDocDate, "")
      Me.txtDeliveryDocDate.Name = "txtDeliveryDocDate"
      Me.Validator.SetRegularExpression(Me.txtDeliveryDocDate, "")
      Me.Validator.SetRequired(Me.txtDeliveryDocDate, False)
      Me.txtDeliveryDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDeliveryDocDate.TabIndex = 4
      '
      'txtPODate
      '
      Me.txtPODate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtPODate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtPODate, "")
      Me.txtPODate.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtPODate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPODate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtPODate, System.Drawing.Color.Empty)
      Me.txtPODate.Location = New System.Drawing.Point(646, 7)
      Me.Validator.SetMinValue(Me.txtPODate, "")
      Me.txtPODate.Name = "txtPODate"
      Me.Validator.SetRegularExpression(Me.txtPODate, "")
      Me.Validator.SetRequired(Me.txtPODate, False)
      Me.txtPODate.Size = New System.Drawing.Size(96, 20)
      Me.txtPODate.TabIndex = 25
      '
      'txtInvoiceDate
      '
      Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.txtInvoiceDate.Location = New System.Drawing.Point(646, 31)
      Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
      Me.txtInvoiceDate.Name = "txtInvoiceDate"
      Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
      Me.Validator.SetRequired(Me.txtInvoiceDate, False)
      Me.txtInvoiceDate.Size = New System.Drawing.Size(78, 20)
      Me.txtInvoiceDate.TabIndex = 6
      '
      'txtRetention
      '
      Me.txtRetention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRetention, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.txtRetention.Location = New System.Drawing.Point(678, 677)
      Me.Validator.SetMinValue(Me.txtRetention, "")
      Me.txtRetention.Name = "txtRetention"
      Me.Validator.SetRegularExpression(Me.txtRetention, "")
      Me.Validator.SetRequired(Me.txtRetention, False)
      Me.txtRetention.Size = New System.Drawing.Size(176, 20)
      Me.txtRetention.TabIndex = 21
      Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtPOCode
      '
      Me.Validator.SetDataType(Me.txtPOCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPOCode, "")
      Me.txtPOCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPOCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPOCode, System.Drawing.Color.Empty)
      Me.txtPOCode.Location = New System.Drawing.Point(470, 7)
      Me.Validator.SetMinValue(Me.txtPOCode, "")
      Me.txtPOCode.Name = "txtPOCode"
      Me.Validator.SetRegularExpression(Me.txtPOCode, "")
      Me.Validator.SetRequired(Me.txtPOCode, False)
      Me.txtPOCode.Size = New System.Drawing.Size(112, 21)
      Me.txtPOCode.TabIndex = 2
      Me.txtPOCode.TabStop = False
      '
      'txtGross
      '
      Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtGross.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(407, 602)
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(77, 20)
      Me.txtGross.TabIndex = 34
      Me.txtGross.TabStop = False
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
      Me.txtDiscountAmount.Location = New System.Drawing.Point(491, 625)
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.txtDiscountAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(93, 20)
      Me.txtDiscountAmount.TabIndex = 36
      Me.txtDiscountAmount.TabStop = False
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
      Me.txtBeforeTax.Location = New System.Drawing.Point(408, 674)
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(176, 20)
      Me.txtBeforeTax.TabIndex = 37
      Me.txtBeforeTax.TabStop = False
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
      Me.txtTaxAmount.Location = New System.Drawing.Point(678, 628)
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(76, 20)
      Me.txtTaxAmount.TabIndex = 39
      Me.txtTaxAmount.TabStop = False
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
      Me.txtAfterTax.Location = New System.Drawing.Point(678, 699)
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(176, 20)
      Me.txtAfterTax.TabIndex = 40
      Me.txtAfterTax.TabStop = False
      Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDiscountRate
      '
      Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.txtDiscountRate.Location = New System.Drawing.Point(405, 625)
      Me.Validator.SetMinValue(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Name = "txtDiscountRate"
      Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
      Me.Validator.SetRequired(Me.txtDiscountRate, False)
      Me.txtDiscountRate.Size = New System.Drawing.Size(84, 20)
      Me.txtDiscountRate.TabIndex = 17
      '
      'txtTaxRate
      '
      Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(790, 603)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, True)
      Me.txtTaxRate.Size = New System.Drawing.Size(45, 20)
      Me.txtTaxRate.TabIndex = 44
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
      Me.txtTaxBase.Location = New System.Drawing.Point(407, 698)
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(76, 20)
      Me.txtTaxBase.TabIndex = 38
      Me.txtTaxBase.TabStop = False
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxBase
      '
      Me.txtRealTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(507, 698)
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(77, 20)
      Me.txtRealTaxBase.TabIndex = 18
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealGross
      '
      Me.txtRealGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.txtRealGross.Location = New System.Drawing.Point(508, 602)
      Me.Validator.SetMinValue(Me.txtRealGross, "")
      Me.txtRealGross.Name = "txtRealGross"
      Me.Validator.SetRegularExpression(Me.txtRealGross, "")
      Me.Validator.SetRequired(Me.txtRealGross, False)
      Me.txtRealGross.Size = New System.Drawing.Size(76, 20)
      Me.txtRealGross.TabIndex = 16
      Me.txtRealGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxAmount
      '
      Me.txtRealTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(778, 629)
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(76, 20)
      Me.txtRealTaxAmount.TabIndex = 20
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAdvancePayAmount
      '
      Me.txtAdvancePayAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAdvancePayAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAdvancePayAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvancePayAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvancePayAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvancePayAmount, System.Drawing.Color.Empty)
      Me.txtAdvancePayAmount.Location = New System.Drawing.Point(431, 651)
      Me.Validator.SetMinValue(Me.txtAdvancePayAmount, "")
      Me.txtAdvancePayAmount.Name = "txtAdvancePayAmount"
      Me.txtAdvancePayAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAdvancePayAmount, "")
      Me.Validator.SetRequired(Me.txtAdvancePayAmount, False)
      Me.txtAdvancePayAmount.Size = New System.Drawing.Size(153, 20)
      Me.txtAdvancePayAmount.TabIndex = 36
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
      Me.txtWHT.Location = New System.Drawing.Point(678, 653)
      Me.Validator.SetMinValue(Me.txtWHT, "")
      Me.txtWHT.Name = "txtWHT"
      Me.txtWHT.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWHT, "")
      Me.Validator.SetRequired(Me.txtWHT, False)
      Me.txtWHT.Size = New System.Drawing.Size(176, 20)
      Me.txtWHT.TabIndex = 333
      Me.txtWHT.TabStop = False
      Me.txtWHT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ibtnShowPODialog
      '
      Me.ibtnShowPODialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowPODialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowPODialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowPODialog.Location = New System.Drawing.Point(582, 7)
      Me.ibtnShowPODialog.Name = "ibtnShowPODialog"
      Me.ibtnShowPODialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowPODialog.TabIndex = 25
      Me.ibtnShowPODialog.TabStop = False
      Me.ibtnShowPODialog.ThemedImage = CType(resources.GetObject("ibtnShowPODialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(300, 7)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDocDate.TabIndex = 24
      Me.dtpDocDate.TabStop = False
      '
      'dtpDeliveryDocDate
      '
      Me.dtpDeliveryDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDeliveryDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDeliveryDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDeliveryDocDate.Location = New System.Drawing.Point(266, 31)
      Me.dtpDeliveryDocDate.Name = "dtpDeliveryDocDate"
      Me.dtpDeliveryDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDeliveryDocDate.TabIndex = 27
      Me.dtpDeliveryDocDate.TabStop = False
      '
      'dtpInvoiceDate
      '
      Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpInvoiceDate.Location = New System.Drawing.Point(648, 31)
      Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
      Me.dtpInvoiceDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpInvoiceDate.TabIndex = 28
      Me.dtpInvoiceDate.TabStop = False
      '
      'lblInvoiceDate
      '
      Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceDate.Location = New System.Drawing.Point(614, 31)
      Me.lblInvoiceDate.Name = "lblInvoiceDate"
      Me.lblInvoiceDate.Size = New System.Drawing.Size(32, 18)
      Me.lblInvoiceDate.TabIndex = 24
      Me.lblInvoiceDate.Text = "วันที่:"
      Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(104, 141)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 39
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(128, 141)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 40
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(555, 724)
      Me.lblTaxAmount.Name = "lblTaxAmount"
      Me.lblTaxAmount.Size = New System.Drawing.Size(56, 18)
      Me.lblTaxAmount.TabIndex = 286
      Me.lblTaxAmount.Text = "ภาษี :"
      Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAfterTax
      '
      Me.lblAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAfterTax.BackColor = System.Drawing.Color.Transparent
      Me.lblAfterTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAfterTax.Location = New System.Drawing.Point(598, 701)
      Me.lblAfterTax.Name = "lblAfterTax"
      Me.lblAfterTax.Size = New System.Drawing.Size(73, 18)
      Me.lblAfterTax.TabIndex = 45
      Me.lblAfterTax.Text = "ยอดสุทธิ :"
      Me.lblAfterTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDiscountAmount
      '
      Me.lblDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscountAmount.Location = New System.Drawing.Point(321, 624)
      Me.lblDiscountAmount.Name = "lblDiscountAmount"
      Me.lblDiscountAmount.Size = New System.Drawing.Size(80, 18)
      Me.lblDiscountAmount.TabIndex = 35
      Me.lblDiscountAmount.Text = "ส่วนลด :"
      Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(298, 674)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(104, 18)
      Me.lblBeforeTax.TabIndex = 48
      Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
      Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGross.BackColor = System.Drawing.Color.Transparent
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(325, 602)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(77, 18)
      Me.lblGross.TabIndex = 33
      Me.lblGross.Text = "ยอดเงินรวม :"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.Location = New System.Drawing.Point(585, 628)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(87, 18)
      Me.Label1.TabIndex = 42
      Me.Label1.Text = "ภาษีมูลค่าเพิ่ม :"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbTaxType
      '
      Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(678, 602)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(49, 21)
      Me.cmbTaxType.TabIndex = 19
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(596, 603)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(76, 18)
      Me.lblTaxType.TabIndex = 47
      Me.lblTaxType.Text = "ประเภทภาษี :"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(726, 603)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
      Me.lblTaxRate.TabIndex = 46
      Me.lblTaxRate.Text = "อัตราภาษี :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxBase
      '
      Me.lblTaxBase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.Location = New System.Drawing.Point(266, 698)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(135, 18)
      Me.lblTaxBase.TabIndex = 43
      Me.lblTaxBase.Text = "ฐานภาษี :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPercent
      '
      Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(841, 604)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 41
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnEnableVatInput
      '
      Me.ibtnEnableVatInput.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnEnableVatInput.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnEnableVatInput.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnEnableVatInput.Location = New System.Drawing.Point(745, 29)
      Me.ibtnEnableVatInput.Name = "ibtnEnableVatInput"
      Me.ibtnEnableVatInput.Size = New System.Drawing.Size(24, 24)
      Me.ibtnEnableVatInput.TabIndex = 29
      Me.ibtnEnableVatInput.TabStop = False
      Me.ibtnEnableVatInput.ThemedImage = CType(resources.GetObject("ibtnEnableVatInput.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(232, 7)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 23
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'lblRetention
      '
      Me.lblRetention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblRetention.BackColor = System.Drawing.Color.Transparent
      Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetention.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRetention.Location = New System.Drawing.Point(582, 679)
      Me.lblRetention.Name = "lblRetention"
      Me.lblRetention.Size = New System.Drawing.Size(90, 18)
      Me.lblRetention.TabIndex = 288
      Me.lblRetention.Text = "Retention :"
      Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnApprove
      '
      Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApprove.ForeColor = System.Drawing.Color.Black
      Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnApprove.Location = New System.Drawing.Point(750, 5)
      Me.btnApprove.Name = "btnApprove"
      Me.btnApprove.Size = New System.Drawing.Size(104, 23)
      Me.btnApprove.TabIndex = 26
      Me.btnApprove.Text = "อนุมัติเอกสาร"
      Me.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnApprove.ThemedImage = CType(resources.GetObject("btnApprove.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(483, 697)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 45
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetGross
      '
      Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetGross.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetGross.Location = New System.Drawing.Point(484, 602)
      Me.ibtnResetGross.Name = "ibtnResetGross"
      Me.ibtnResetGross.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetGross.TabIndex = 43
      Me.ibtnResetGross.TabStop = False
      Me.ibtnResetGross.ThemedImage = CType(resources.GetObject("ibtnResetGross.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxAmount
      '
      Me.ibtnResetTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(754, 628)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 46
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(104, 7)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(128, 21)
      Me.cmbCode.TabIndex = 0
      '
      'lblAdvancePay
      '
      Me.lblAdvancePay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAdvancePay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvancePay.Location = New System.Drawing.Point(321, 653)
      Me.lblAdvancePay.Name = "lblAdvancePay"
      Me.lblAdvancePay.Size = New System.Drawing.Size(80, 18)
      Me.lblAdvancePay.TabIndex = 35
      Me.lblAdvancePay.Text = "มัดจำ :"
      Me.lblAdvancePay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowAdvancePay
      '
      Me.ibtnShowAdvancePay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnShowAdvancePay.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAdvancePay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAdvancePay.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAdvancePay.Location = New System.Drawing.Point(407, 647)
      Me.ibtnShowAdvancePay.Name = "ibtnShowAdvancePay"
      Me.ibtnShowAdvancePay.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAdvancePay.TabIndex = 44
      Me.ibtnShowAdvancePay.TabStop = False
      Me.ibtnShowAdvancePay.ThemedImage = CType(resources.GetObject("ibtnShowAdvancePay.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblWHT
      '
      Me.lblWHT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblWHT.BackColor = System.Drawing.Color.Transparent
      Me.lblWHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWHT.Location = New System.Drawing.Point(567, 653)
      Me.lblWHT.Name = "lblWHT"
      Me.lblWHT.Size = New System.Drawing.Size(105, 18)
      Me.lblWHT.TabIndex = 334
      Me.lblWHT.Text = "ภาษีหัก ณ ที่จ่าย :"
      Me.lblWHT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtUnlocker
      '
      Me.ibtUnlocker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtUnlocker.BackColor = System.Drawing.Color.White
      Me.ibtUnlocker.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtUnlocker.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtUnlocker.ForeColor = System.Drawing.Color.White
      Me.ibtUnlocker.GenerateDisabledImage = True
      Me.ibtUnlocker.Location = New System.Drawing.Point(821, 29)
      Me.ibtUnlocker.Name = "ibtUnlocker"
      Me.ibtUnlocker.Size = New System.Drawing.Size(32, 24)
      Me.ibtUnlocker.TabIndex = 335
      Me.ibtUnlocker.TabStop = False
      Me.ibtUnlocker.ThemedImage = CType(resources.GetObject("ibtUnlocker.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtUnlocker.UseVisualStyleBackColor = False
      '
      'GoodsReceiptDetail
      '
      Me.Controls.Add(Me.txtDeliveryDocDate)
      Me.Controls.Add(Me.txtDeliveryCode)
      Me.Controls.Add(Me.txtInvoiceCode)
      Me.Controls.Add(Me.txtInvoiceDate)
      Me.Controls.Add(Me.grbDelivery)
      Me.Controls.Add(Me.ibtUnlocker)
      Me.Controls.Add(Me.txtWHT)
      Me.Controls.Add(Me.lblWHT)
      Me.Controls.Add(Me.cmbCode)
      Me.Controls.Add(Me.btnApprove)
      Me.Controls.Add(Me.txtRetention)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.txtGross)
      Me.Controls.Add(Me.txtDiscountAmount)
      Me.Controls.Add(Me.txtBeforeTax)
      Me.Controls.Add(Me.txtTaxAmount)
      Me.Controls.Add(Me.txtAfterTax)
      Me.Controls.Add(Me.txtDiscountRate)
      Me.Controls.Add(Me.cmbTaxType)
      Me.Controls.Add(Me.txtTaxRate)
      Me.Controls.Add(Me.txtTaxBase)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.lblTaxAmount)
      Me.Controls.Add(Me.txtDocDate)
      Me.Controls.Add(Me.dtpDocDate)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.grbReceive)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.lblDocDate)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblPOCode)
      Me.Controls.Add(Me.lblPODate)
      Me.Controls.Add(Me.lblDeliveryCode)
      Me.Controls.Add(Me.lblDeliveryDocDate)
      Me.Controls.Add(Me.txtPOCode)
      Me.Controls.Add(Me.ibtnShowPODialog)
      Me.Controls.Add(Me.txtPODate)
      Me.Controls.Add(Me.lblInvoiceDate)
      Me.Controls.Add(Me.dtpInvoiceDate)
      Me.Controls.Add(Me.ibtnEnableVatInput)
      Me.Controls.Add(Me.txtRealGross)
      Me.Controls.Add(Me.ibtnResetGross)
      Me.Controls.Add(Me.txtRealTaxAmount)
      Me.Controls.Add(Me.ibtnResetTaxAmount)
      Me.Controls.Add(Me.txtRealTaxBase)
      Me.Controls.Add(Me.ibtnResetTaxBase)
      Me.Controls.Add(Me.lblRetention)
      Me.Controls.Add(Me.lblDiscountAmount)
      Me.Controls.Add(Me.lblGross)
      Me.Controls.Add(Me.lblTaxRate)
      Me.Controls.Add(Me.lblTaxBase)
      Me.Controls.Add(Me.lblAfterTax)
      Me.Controls.Add(Me.lblTaxType)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblBeforeTax)
      Me.Controls.Add(Me.lblPercent)
      Me.Controls.Add(Me.lblAdvancePay)
      Me.Controls.Add(Me.txtAdvancePayAmount)
      Me.Controls.Add(Me.ibtnShowAdvancePay)
      Me.Controls.Add(Me.dtpDeliveryDocDate)
      Me.Controls.Add(Me.lblInvoiceCode)
      Me.Name = "GoodsReceiptDetail"
      Me.Size = New System.Drawing.Size(869, 728)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbReceive.ResumeLayout(False)
      Me.grbReceive.PerformLayout()
      Me.grbDelivery.ResumeLayout(False)
      Me.grbDelivery.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As GoodsReceipt
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable

    Private m_treeManager2 As TreeManager
    Private m_wbsdInitialized As Boolean
    Private m_Unlock As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dt As TreeTable = GoodsReceipt.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf GRItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDelivery.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbReceive.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Dim m_wbsColl As WBSCollection
    Dim m_mrkColl As MarkupCollection
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "GoodsReceipt"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csPOItemCode As New TreeTextColumn
      csPOItemCode.MappingName = "POItemCode"
      csPOItemCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.POItemCodeHeaderText}")
      csPOItemCode.NullText = ""
      csPOItemCode.ReadOnly = True
      csPOItemCode.TextBox.Name = "POItemCode"

      Dim csPOItemName As New TreeTextColumn
      csPOItemName.MappingName = "POItemName"
      csPOItemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.POItemNameHeaderText}")
      csPOItemName.NullText = ""
      csPOItemName.ReadOnly = True
      csPOItemName.TextBox.Name = "POItemName"

      Dim csPOItemUnit As New TreeTextColumn
      csPOItemUnit.MappingName = "POItemUnit"
      csPOItemUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.POItemUnitHeaderText}")
      csPOItemUnit.NullText = ""
      csPOItemUnit.ReadOnly = True
      csPOItemUnit.TextBox.Name = "POItemUnit"

      Dim csPOItemQty As New TreeTextColumn
      csPOItemQty.MappingName = "poi_qty"
      csPOItemQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.POItemQtyHeaderText}")
      csPOItemQty.NullText = ""
      csPOItemQty.DataAlignment = HorizontalAlignment.Right
      csPOItemQty.ReadOnly = True
      csPOItemQty.TextBox.Name = "poi_qty"

      Dim csPOItemRemainingQty As New TreeTextColumn
      csPOItemRemainingQty.MappingName = "POItemRemainingQty"
      csPOItemRemainingQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.POItemRemainingQtyHeaderText}")
      csPOItemRemainingQty.NullText = ""
      csPOItemRemainingQty.DataAlignment = HorizontalAlignment.Right
      csPOItemRemainingQty.Format = "#,###.##"
      csPOItemRemainingQty.TextBox.Name = "POItemRemainingQty"
      csPOItemRemainingQty.ReadOnly = True

      'Stock Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "stocki_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "stocki_linenumber"

      Dim csBarrier As New DataGridBarrierColumn
      csBarrier.MappingName = "Barrier"
      csBarrier.HeaderText = ""
      csBarrier.NullText = ""
      csBarrier.ReadOnly = True

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("stocki_entityType" _
      , CodeDescription.GetCodeList("stocki_enitytype") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.TypeHeaderText}")
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      Dim csName As New TreeTextColumn
      csName.MappingName = "stocki_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 200
      csName.TextBox.Name = "Description"

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      'AddHandler csUnitButton.Click, AddressOf ButtonClicked

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "stocki_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"

      Dim csStockQty As New TreeTextColumn
      csStockQty.MappingName = "StockQty"
      csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.StockQtyHeaderText}")
      csStockQty.NullText = ""
      csStockQty.DataAlignment = HorizontalAlignment.Right
      csStockQty.Format = "#,###.##"
      csStockQty.ReadOnly = True

      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "stocki_unitprice"
      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnitpriceHeaderText}")
      csUnitPRice.NullText = ""
      csUnitPRice.TextBox.Name = "stocki_unitprice"
      csUnitPRice.DataAlignment = HorizontalAlignment.Right

      Dim csDiscount As New TreeTextColumn
      csDiscount.MappingName = "stocki_discrate"
      csDiscount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.DiscountHeaderText}")
      csDiscount.NullText = ""
      csDiscount.TextBox.Name = "stocki_discrate"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"
      csAmount.DataAlignment = HorizontalAlignment.Right

      Dim csAccountCode As New TreeTextColumn
      csAccountCode.MappingName = "AccountCode"
      csAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountCodeHeaderText}")
      csAccountCode.NullText = ""
      csAccountCode.TextBox.Name = "AccountCode"

      Dim csAccount As New TreeTextColumn
      csAccount.MappingName = "Account"
      csAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountHeaderText}")
      csAccount.NullText = ""
      csAccount.ReadOnly = True
      csAccount.TextBox.Name = "Account"

      Dim csAccountButton As New DataGridButtonColumn
      csAccountButton.MappingName = "AccountButton"
      csAccountButton.HeaderText = ""
      csAccountButton.NullText = ""
      AddHandler csAccountButton.Click, AddressOf ButtonClicked

      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "stocki_unvatable"
      csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnVatableHeaderText}")
      csVatable.Width = 100
      csVatable.InvisibleWhenUnspcified = True

      Dim csQuality As New TreeTextColumn
      csQuality.MappingName = "stocki_quality"
      csQuality.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.QualityHeaderText}")
      csQuality.NullText = ""
      csQuality.Width = 180
      csQuality.TextBox.Name = "stocki_quality"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "stocki_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "stocki_note"




      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      'dst.GridColumnStyles.Add(csPOItemQty)
      dst.GridColumnStyles.Add(csPOItemRemainingQty)
      dst.GridColumnStyles.Add(csQty)
      'dst.GridColumnStyles.Add(csStockQty)
      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csDiscount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csAccountCode)
      dst.GridColumnStyles.Add(csAccountButton)
      dst.GridColumnStyles.Add(csAccount)
      dst.GridColumnStyles.Add(csVatable)
      dst.GridColumnStyles.Add(csQuality)
      dst.GridColumnStyles.Add(csNote)

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Public Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      Dim unitButtonColumn As Boolean
      Dim itemButtonColumn As Boolean

      For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
        If colStyle.MappingName.ToLower = "button" Then
          itemButtonColumn = colStyle.ReadOnly
        End If
        If colStyle.MappingName.ToLower = "unitbutton" Then
          unitButtonColumn = colStyle.ReadOnly
        End If
      Next
      If e.Column = 5 Then
        If Not unitButtonColumn Then
          Me.UnitButtonClick(e)
        End If
      ElseIf e.Column = 2 Then
        If Not itemButtonColumn Then
          Me.ItemButtonClick(e)
        End If
      Else
        Me.AcctButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentTagItem() As GoodsReceiptItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is GoodsReceiptItem Then
          Return Nothing
        End If
        Return CType(row.Tag, GoodsReceiptItem)
      End Get
    End Property
    Private Property Unlock() As Boolean
      Get
        Return m_Unlock
      End Get
      Set(ByVal Value As Boolean)
        m_Unlock = Value
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
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      'Me.m_entity.SetRealGross()
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
      Dim doc As GoodsReceiptItem = Me.m_entity.ItemCollection.CurrentItem

      'If tick checkbox that not in the current hilight row
      If e.Column.ColumnName.ToLower = "stocki_unvatable" Then
        Me.m_treeManager.SelectedRow = e.Row
        doc = Me.m_entity.ItemCollection.CurrentItem
      End If

      If doc Is Nothing Then
        doc = New GoodsReceiptItem
        doc.ItemType = New ItemType(0)
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
          Case "stocki_itemname"
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
          Case "stocki_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0       'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            If Not doc.POitem Is Nothing Then
              Try
                Dim percentDoOverPo As Object = Configuration.GetConfig("PercentDoOverPo")
                If Not percentDoOverPo Is Nothing Then
                  If CStr(percentDoOverPo).Length > 0 Then
                    Dim percent As Decimal = CDec(TextParser.Evaluate(CStr(percentDoOverPo)))
                    Dim tolerance As Decimal = (percent * doc.POitem.Qty) / 100
                    'MessageBox.Show(String.Format("{0}-({1}-{2}+{3})", value, doc.POitem.Qty, Math.Min(doc.POitem.ReceivedQty, doc.POitem.Qty), Math.Min(doc.POitem.ReceivedQty, doc.Qty)))
                    If Configuration.Compare(tolerance, value - (doc.POitem.Qty - Math.Min(doc.POitem.ReceivedQty, doc.POitem.Qty) + Math.Min(doc.POitem.ReceivedQty, doc.Qty)), DigitConfig.Qty) < 0 Then
                      msgServ.ShowMessageFormatted("${res:Global.Error.PercentDoOverPoExceeded}", New String() {Configuration.FormatToString(value, DigitConfig.Qty), Configuration.FormatToString(doc.POitem.Qty, DigitConfig.Qty), Configuration.FormatToString(percent, 2)})
                      value = Math.Min(value, doc.POitem.Qty - Math.Min(doc.POitem.ReceivedQty, doc.POitem.Qty) + Math.Min(doc.POitem.ReceivedQty, doc.Qty) + tolerance)
                    End If
                  End If
                End If
              Catch ex As Exception

              End Try
            End If
            doc.Qty = value
          Case "accountcode"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetAccountCode(CStr(e.ProposedValue))
          Case "stocki_entitytype"
            Dim value As ItemType
            If IsNumeric(e.ProposedValue) Then
              value = New ItemType(CInt(e.ProposedValue))
            End If
            doc.ItemType = value
          Case "stocki_unitprice"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0       'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.UnitPrice = value
          Case "stocki_discrate"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Discount = New Discount(e.ProposedValue.ToString)
          Case "stocki_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
          Case "stocki_quality"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Quality = e.ProposedValue.ToString
          Case "stocki_unvatable"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = False
            End If
            doc.UnVatable = CBool(e.ProposedValue)
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub GRItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
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
      If Not CBool(Configuration.GetConfig("ApproveDO")) Then
        Me.btnApprove.Visible = False
      Else
        Me.btnApprove.Visible = True
      End If

      Me.ibtUnlocker.Visible = False
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(321)       'ตรวจสอบ สิทธิปลดล๊อคใบรับของ
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)      'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
      checkString = BinaryHelper.RevertString(checkString)
      If CBool(checkString.Substring(0, 1)) Then
        Me.ibtUnlocker.Visible = True
      Else
        Me.ibtUnlocker.Visible = False
      End If

      'จากการอนุมัติเอกสาร
      If CBool(Configuration.GetConfig("ApproveDO")) Then

        'ถ้าใช้การอนุมัติแบบใหม่ PJMModule
        If m_ApproveDocModule.Activated Then
          Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
          'Dim ApprovalDocLevelColl As New ApprovalDocLevelCollection(mySService.CurrentUser) 'ระดับสิทธิแต่ละผู้ใช้

          Dim ApproveDocColl As New ApproveDocCollection(Me.m_entity)         'ระดับสิทธิที่ได้ทำการ approve
          If Not Me.Unlock AndAlso ApproveDocColl.MaxLevel > 0 Then         '(ApprovalDocLevelColl.GetItem(m_entity.EntityId).Level < ApproveDocColl.MaxLevel) OrElse _
            '(Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id) Then
            For Each ctrl As Control In Me.Controls
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso Not ctrl.Name = "ibtUnlocker" Then
                ctrl.Enabled = False
              End If
            Next
            Me.ibtUnlocker.Enabled = True
            tgItem.Enabled = True
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              If colStyle.MappingName.ToLower = "accountcode" _
              Or colstyle.MappingName.ToLower = "accountbutton" Then
                colStyle.ReadOnly = False
              Else
                colStyle.ReadOnly = True
              End If
            Next
            Me.btnApprove.Enabled = True
            CheckWBSRight()
            Return
          Else
            For Each ctrl As Control In Me.Controls
              ctrl.Enabled = CBool(m_enableState(ctrl))
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If
        Else
          'ถ้าใช้การอนุมัติแบบเก่า
          If Not Me.Unlock AndAlso Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then
            For Each ctrl As Control In Me.Controls
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso Not ctrl.Name = "ibtUnlocker" Then
                ctrl.Enabled = False
              End If
            Next
            Me.ibtUnlocker.Enabled = True
            tgItem.Enabled = True
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              If colStyle.MappingName.ToLower = "accountcode" _
              Or colstyle.MappingName.ToLower = "accountbutton" Then
                colStyle.ReadOnly = False
              Else
                colStyle.ReadOnly = True
              End If
            Next
            Me.btnApprove.Enabled = True
            CheckWBSRight()
            Return
          Else
            For Each ctrl As Control In Me.Controls
              ctrl.Enabled = CBool(m_enableState(ctrl))
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If
        End If
      End If

      'จาก Status ของเอกสารเอง
      If Not Me.Unlock AndAlso (Me.m_entity.Status.Value = 0 _
      OrElse m_entityRefed = 1 _
      OrElse Me.m_entity.Payment.Status.Value = 0 _
      OrElse Me.m_entity.Payment.Status.Value >= 3 _
      ) Then
        For Each ctrl As Control In Me.grbDelivery.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.grbReceive.Controls
          ctrl.Enabled = False
        Next
        'For Each ctrl As Control In Me.Controls
        '  If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" Then
        'ctrl.Enabled = False
        cmbCode.Enabled = False : chkAutorun.Enabled = False
        txtDocDate.Enabled = False : dtpDocDate.Enabled = False
        txtPOCode.Enabled = False : ibtnShowPODialog.Enabled = False
        txtDeliveryCode.Enabled = False : txtDeliveryDocDate.Enabled = False
        dtpDeliveryDocDate.Enabled = False : txtInvoiceCode.Enabled = False
        txtPODate.Enabled = False : ibtnEnableVatInput.Enabled = False
        dtpInvoiceDate.Enabled = False : txtInvoiceDate.Enabled = False
        '  End If
        'Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          If colStyle.MappingName.ToLower = "accountcode" _
          Or colstyle.MappingName.ToLower = "accountbutton" Then
            colStyle.ReadOnly = False
          Else
            colStyle.ReadOnly = True
          End If
        Next

        'Unlock ส่วนท้ายถ้าเอกสารไม่ถูกอ้างอิง ยกเว้น การเบิก
        If Me.m_entity.IsMathwidthdrawReferenced Then
          txtRealGross.Enabled = True
          txtDiscountRate.Enabled = True
          txtRealTaxBase.Enabled = True
          cmbTaxType.Enabled = True
          txtRealTaxAmount.Enabled = True
          txtRetention.Enabled = True
          ibtnResetGross.Enabled = True
          ibtnResetTaxBase.Enabled = True
          ibtnResetTaxAmount.Enabled = True
          txtCreditPrd.Enabled = True
          txtDueDate.Enabled = True
          dtpDueDate.Enabled = True

        Else
          txtRealGross.Enabled = False
          txtDiscountRate.Enabled = False
          txtRealTaxBase.Enabled = False
          cmbTaxType.Enabled = False
          txtRealTaxAmount.Enabled = False
          txtRetention.Enabled = False
          ibtnResetGross.Enabled = False
          ibtnResetTaxBase.Enabled = False
          ibtnResetTaxAmount.Enabled = False
        End If
      Else
        For Each ctrl As Control In Me.grbDelivery.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.grbReceive.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If

      Me.btnApprove.Enabled = True

      If Me.Unlock Then
        ibtUnlocker.Enabled = False
      Else
        ibtUnlocker.Enabled = True
      End If

      CheckWBSRight()

      'For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '    If colStyle.MappingName.ToLower = "accountcode" _
      '    Or colstyle.MappingName.ToLower = "accountbutton" Then
      '        MessageBox.Show(colstyle.MappingName.ToLower.ToString)
      '    End If
      'Next
    End Sub
    Private Sub CheckWBSRight()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(256)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      'If Not CBool(checkString.Substring(0, 1)) Then
      '  'ห้ามเห็น
      '  Me.lblWBS.Visible = False
      '  Me.tgWBS.Visible = False
      '  Me.ibtnAddWBS.Visible = False
      '  Me.ibtnDelWBS.Visible = False
      'ElseIf Not CBool(checkString.Substring(1, 1)) Then
      '  'ห้ามแก้
      '  Me.lblWBS.Visible = True
      '  Me.tgWBS.Visible = True
      '  Me.ibtnAddWBS.Visible = True
      '  Me.ibtnDelWBS.Visible = True

      '  Me.tgWBS.Enabled = False
      '  Me.ibtnAddWBS.Enabled = False
      '  Me.ibtnDelWBS.Enabled = False
      'Else
      '  Me.lblWBS.Visible = True
      '  Me.tgWBS.Visible = True
      '  Me.ibtnAddWBS.Visible = True
      '  Me.ibtnDelWBS.Visible = True

      '  Me.tgWBS.Enabled = True
      '  Me.ibtnAddWBS.Enabled = True
      '  Me.ibtnDelWBS.Enabled = True
      'End If
    End Sub
    Public Overrides Sub ClearDetail()
      Me.StatusBarService.SetMessage("")
      For Each ctrl As Control In Me.grbDelivery.Controls
        If ctrl.Name.StartsWith("txt") Then
          ctrl.Text = ""
        End If
      Next
      For Each ctrl As Control In Me.grbReceive.Controls
        If ctrl.Name.StartsWith("txt") Then
          ctrl.Text = ""
        End If
      Next
      For Each ctrl As Control In Me.Controls
        If ctrl.Name.StartsWith("txt") Then
          ctrl.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
      cmbTaxType.SelectedIndex = 1
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblNote}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblItem}")
      Me.grbReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.grbReceive}")
      Me.grbDelivery.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.grbDelivery}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblCode}")

      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Global.DueDate}")

      Me.lblDeliveryCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblDeliveryCode}")
      Me.lblDeliveryDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblDeliveryDocDate}")

      Me.lblInvoiceCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblInvoiceCode}")
      Me.Validator.SetDisplayName(Me.txtInvoiceCode, StringHelper.GetRidOfAtEnd(Me.lblInvoiceCode.Text, ":"))


      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblDocDate}")
      Me.lblPOCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblPOCode}")
      Me.lblPODate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblPODate}")

      Me.lblInvoiceDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblInvoiceDate}")
      Me.Validator.SetDisplayName(Me.txtInvoiceDate, StringHelper.GetRidOfAtEnd(Me.lblInvoiceDate.Text, ":"))

      Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblTaxAmount}")
      Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblAfterTax}")
      Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblDiscountAmount}")
      Me.lblAdvancePay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblAdvancePay}")
      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblBeforeTax}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblGross}")
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblTaxType}")
      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblTaxRate}")
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblTaxBase}")
      Me.lblPercent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblPercent}")

      Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblToCCPerson}")
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, StringHelper.GetRidOfAtEnd(Me.lblToCCPerson.Text, ":"))

      Me.lblToCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblToCostCenter}")
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, StringHelper.GetRidOfAtEnd(Me.lblToCostCenter.Text, ":"))

      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblSupplier}")
      Me.Validator.SetDisplayName(Me.txtSupplierCode, StringHelper.GetRidOfAtEnd(Me.lblSupplier.Text, ":"))

      Me.lblEquipment.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblEquipment}")
      Me.Validator.SetDisplayName(Me.txtEquipmentCode, StringHelper.GetRidOfAtEnd(Me.lblEquipment.Text, ":"))

      Me.lblDeliveryPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblDeliveryPerson}")
      Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblCreditPrd}")
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")

      Me.lblDocType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblDocType}")

      Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.btnApprove}")
      Me.lblWHT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblWHT}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDueDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPrd.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCreditPrd.TextChanged, AddressOf Me.TextHandler

      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtDeliveryCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtDeliveryDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDeliveryDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtPOCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtPOCode.TextChanged, AddressOf Me.TextHandler


      AddHandler txtInvoiceCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtInvoiceDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpInvoiceDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtToCCPersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToCCPersonCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtToCostCenterCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtToCostCenterName.Validated, AddressOf ChangeProperty
      AddHandler txtSupplierName.Validated, AddressOf ChangeProperty

      AddHandler txtDeliveryPerson.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbDocType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtRetention.Validated, AddressOf Me.TextHandler
      AddHandler txtRetention.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealGross.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealGross.Validated, AddressOf Me.TextHandler
    End Sub
    Private toCCPersonCodeChanged As Boolean = False
    Private toCCCodeChanged As Boolean = False
    Private pOCodeChanged As Boolean = False
    Private supplierCodeChanged As Boolean = False
    Private txtcreditprdChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txttoccpersoncode"
          toCCPersonCodeChanged = True
        Case "txttocostcentercode"
          toCCCodeChanged = True
        Case "txtpocode"
          pOCodeChanged = True
        Case "txtsuppliercode"
          supplierCodeChanged = True
        Case "txtcreditprd"
          txtcreditprdChanged = True
        Case "txtretention"
          Dim txt As String = Me.txtRetention.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.Retention = 0
          Else
            Try
              Me.m_entity.Retention = Math.Min(CDec(TextParser.Evaluate(txt)), Me.m_entity.AfterTax + Me.m_entity.Retention)
            Catch ex As Exception
              Me.m_entity.Retention = 0
            End Try
          End If
          Me.txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)
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
          forceUpdateTaxAmount = True
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
      End Select
    End Sub
    Private m_oldInvoiceCode As String = ""
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      Me.Unlock = False
      Me.m_entity.Unlock = False
      oldSupId = Me.m_entity.Supplier.Id
      oldCCId = Me.m_entity.ToCostCenter.Id

      txtCreditPrd.Text = m_entity.CreditPeriod.ToString
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      Me.txtDeliveryCode.Text = Me.m_entity.DeliveryDocCode
      'If Me.txtDeliveryCode.Text.Trim.Length > 0 Then
      txtDeliveryDocDate.Text = MinDateToNull(Me.m_entity.DeliveryDocDate, "")
      dtpDeliveryDocDate.Value = MinDateToNow(Me.m_entity.DeliveryDocDate)
      ' End If

      Dim myVat As Vat = Me.m_entity.Vat
      If Not myVat Is Nothing Then
        If myVat.ItemCollection.Count <= 0 Then      ' No Vat
          VatInputEnabled(True)
          Me.txtInvoiceCode.Text = ""
          Me.txtInvoiceDate.Text = ""
          Me.dtpInvoiceDate.Value = Now
        ElseIf myVat.ItemCollection.Count = 1 Then
          VatInputEnabled(True)
          Dim vi As VatItem
          vi = myVat.ItemCollection(0)
          Me.txtInvoiceCode.Text = vi.Code
          Me.txtInvoiceDate.Text = MinDateToNull(vi.DocDate, "")        'Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          Me.dtpInvoiceDate.Value = MinDateToNow(vi.DocDate)
        Else
          VatInputEnabled(False)
          Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
          Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
          Me.dtpInvoiceDate.Value = Now
        End If
      End If
      m_oldInvoiceCode = Me.txtInvoiceCode.Text

      If Not Me.m_entity.Po Is Nothing AndAlso Me.m_entity.Po.Originated Then
        Me.txtPOCode.Text = Me.m_entity.Po.Code
        Me.txtPODate.Text = MinDateToNull(Me.m_entity.Po.DocDate, "")
      Else
        Me.txtPOCode.Text = ""
        Me.txtPODate.Text = ""
      End If

      If Not Me.m_entity.Asset Is Nothing AndAlso Me.m_entity.Asset.Originated Then
        Me.txtEquipmentCode.Text = Me.m_entity.Asset.Code
        Me.txtEquipmentName.Text = Me.m_entity.Asset.Name
      End If

      dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
      txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
      If m_entity.TaxType.Value = 0 OrElse m_entity.TaxType.Value = 1 Then
        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
      End If
      txtSupplierCode.Text = m_entity.Supplier.Code
      txtSupplierName.Text = m_entity.Supplier.Name

      Me.txtDeliveryPerson.Text = Me.m_entity.DeliveryPerson

      txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
      txtToCostCenterName.Text = m_entity.ToCostCenter.Name

      Me.txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
      txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name

      If Not m_entity.WitholdingTaxCollection Is Nothing Then
        txtWHT.Text = Configuration.FormatToString(m_entity.WitholdingTaxCollection.Amount(), DigitConfig.Price)
      End If

      CodeDescription.ComboSelect(Me.cmbDocType, Me.m_entity.ToAccountType)

      RefreshDocs()

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
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If Me.m_isInitialized AndAlso (e.Name = "ItemChanged" Or e.Name = "QtyChanged") Then
        If e.Name = "QtyChanged" Then
          Me.UpdateAmount()
        End If
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Private oldSupId As Integer
    Private oldCCId As Integer
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtequipmentcode"
          dirtyFlag = Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_entity.Asset)
          If dirtyFlag Then
            ChangeEq()
          End If
        Case "txtrealtaxbase"
          dirtyFlag = True
        Case "txtrealtaxamount"
          dirtyFlag = True
        Case "txtrealgross"
          If IsNumeric(Me.txtRealGross.Text) Then
            Me.m_entity.RealGross = CDec(Me.txtRealGross.Text)
          Else
            Me.m_entity.RealGross = 0
          End If
          'forceUpdateTaxBase = False
          'forceUpdateTaxAmount = False
          forceUpdateGross = False
          dirtyFlag = True
        Case "cmbcode"
          Me.m_entity.Code = cmbCode.Text
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
        Case "txtsuppliername"
          Dim txt As String = txtSupplierName.Text
          Dim reg As New Regex("\[(.*)\]")
          If reg.IsMatch(txt) Then
            Dim sup As Supplier
            Try
              sup = New Supplier(reg.Match(txt).Groups(1).Value)
            Catch ex As Exception
              sup = New Supplier
            End Try
            Dim oldSupplier As Supplier = Me.m_entity.Supplier
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Me.m_entity.Supplier = sup
            If oldSupId <> Me.m_entity.Supplier.Id Then
              If oldSupId = 0 OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeSupplier}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeSupplier}") Then
                oldSupId = Me.m_entity.Supplier.Id
                dirtyFlag = True
                ChangeSupplier()
              Else
                dirtyFlag = False
                Me.m_entity.Supplier = oldSupplier
              End If
            End If
          End If
          m_isInitialized = False
          Me.txtSupplierCode.Text = Me.m_entity.Supplier.Code
          Me.txtSupplierName.Text = Me.m_entity.Supplier.Name
          m_isInitialized = True
        Case "dtpdocdate"
          If Not m_dateSetting Then
            If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
              If Not m_dateSetting Then
                Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                Me.m_entity.DocDate = dtpDocDate.Value
                Me.m_entity.Payment.DocDate = dtpDocDate.Value
                Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
                Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
                If Not Me.m_entity.Originated Then
                  If Me.txtDeliveryCode.Text.Trim.Length > 0 Then
                    'Me.txtDeliveryDocDate.Text = Me.txtDueDate.Text
                    Me.dtpDeliveryDocDate.Value = Me.dtpDueDate.Value
                  End If
                  If Me.txtInvoiceCode.Text.Trim.Length > 0 Then
                    'Me.txtInvoiceDate.Text = Me.txtDueDate.Text
                    Me.dtpInvoiceDate.Value = Me.dtpDueDate.Value
                  End If
                End If
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
              Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
              Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              If Not Me.m_entity.Originated Then
                If Me.txtDeliveryCode.Text.Trim.Length > 0 Then
                  Me.txtDeliveryDocDate.Text = Me.txtDueDate.Text
                  'Me.dtpDeliveryDocDate.Value = Me.dtpDueDate.Value
                End If
                If Me.txtInvoiceCode.Text.Trim.Length > 0 Then
                  Me.txtInvoiceDate.Text = Me.txtDueDate.Text
                  'Me.dtpInvoiceDate.Value = Me.dtpDueDate.Value
                End If
              End If
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            Me.m_entity.Payment.DocDate = Date.MinValue
            If Not Me.m_entity.Originated Then
              If Me.txtDeliveryCode.Text.Trim.Length > 0 Then
                Me.txtDeliveryDocDate.Text = Me.txtDueDate.Text
                'Me.dtpDeliveryDocDate.Value = Me.dtpDueDate.Value
              End If
              If Me.txtInvoiceCode.Text.Trim.Length > 0 Then
                Me.txtInvoiceDate.Text = Me.txtDueDate.Text
                'Me.dtpInvoiceDate.Value = Me.dtpDueDate.Value
              End If
            End If
          End If
          m_dateSetting = False
        Case "dtpduedate"
          If Not m_dateSetting Then
            If Not Me.m_entity.DueDate.Equals(dtpDueDate.Value) Then
              If Not m_dateSetting Then
                Me.txtDueDate.Text = MinDateToNull(dtpDueDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                Me.m_entity.DueDate = dtpDueDate.Value
                'Me.m_entity.Payment.DocDate = dtpDocDate.Value
                'Me.dtpDocDate.Value = MaxDtpDate(Me.m_entity.DocDate)
                Me.txtCreditPrd.Text = Me.m_entity.CreditPeriod
                dirtyFlag = True
              End If
            End If
          End If
        Case "txtduedate"
          m_dateSetting = True
          If Not Me.txtDueDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDueDate.Text)
            If Not Me.m_entity.DueDate.Equals(theDate) Then
              dtpDueDate.Value = theDate
              Me.m_entity.DueDate = dtpDueDate.Value
              'Me.m_entity.Payment.DocDate = dtpDocDate.Value
              'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              Me.txtCreditPrd.Text = Me.m_entity.CreditPeriod
              dirtyFlag = True
            End If
          Else
            dtpDueDate.Value = Me.m_entity.DueDate
            'Me.m_entity.DocDate = Date.MinValue
            'Me.m_entity.Payment.DocDate = Date.MinValue
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
            Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
            Me.dtpDueDate.Value = Me.m_entity.DueDate
            dirtyFlag = True
          End If
        Case "txttaxbase"
          'Todo
        Case "txtretention"
          dirtyFlag = True
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
          UpdateAmount()
          dirtyFlag = True
        Case "txtdeliverycode"
          Me.m_entity.DeliveryDocCode = txtDeliveryCode.Text
          If Not Me.m_entity.Originated Then
            If Me.txtDeliveryCode.Text.Trim.Length > 0 Then
              Me.txtDeliveryDocDate.Text = Me.txtDocDate.Text
              Dim theDate As Date = CDate(Me.txtDeliveryDocDate.Text)
              dtpDeliveryDocDate.Value = theDate
              Me.m_entity.DeliveryDocDate = dtpDeliveryDocDate.Value
            Else
              Me.txtDeliveryDocDate.Text = ""
              Me.m_entity.DeliveryDocDate = Nothing
            End If
          End If
          dirtyFlag = True
        Case "txtdeliverydocdate"
          m_dateSetting = True
          If Not Me.txtDeliveryDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDeliveryDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDeliveryDocDate.Text)
            dtpDeliveryDocDate.Value = theDate
            Me.m_entity.DeliveryDocDate = dtpDeliveryDocDate.Value
            If Not Me.m_entity.DeliveryDocDate.Equals(theDate) Then
              dirtyFlag = True
            End If
            'Else
            'dtpDeliveryDocDate.Value = Date.Now
            'Me.m_entity.DeliveryDocDate = Date.MinValue
          End If
          m_dateSetting = False
        Case "dtpdeliverydocdate"
          'If Not Me.txtDeliveryDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDeliveryDocDate) = "" Then
          If Me.Validator.GetErrorMessage(Me.txtDeliveryDocDate) = "" Then
            If Not m_dateSetting Then
              If Not Me.m_entity.DeliveryDocDate.Equals(dtpDeliveryDocDate.Value) Then
                If Not m_dateSetting Then
                  Me.txtDeliveryDocDate.Text = MinDateToNull(dtpDeliveryDocDate.Value, "")
                  Me.m_entity.DeliveryDocDate = dtpDeliveryDocDate.Value
                  dirtyFlag = True
                End If
              End If
            End If
          End If
        Case "txtpocode"
          If pOCodeChanged Then
            pOCodeChanged = False
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.txtPOCode.TextLength <> 0 Then
              Dim poNeedsApproval As Boolean = False
              poNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
              Dim newPo As New PO(txtPOCode.Text)
              If poNeedsApproval AndAlso newPo.ApproveDate.Equals(Date.MinValue) Then
                msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ThisPOIsNotApproved}", New String() {newPo.Code})
              ElseIf Not newPo.Status Is Nothing AndAlso newPo.Status.Value = 0 Then
                msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ThisPOIsCanceled}", New String() {newPo.Code})
              ElseIf newPo.Closed = True Then
                msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ThisPOIsClosed}", New String() {newPo.Code})
              ElseIf msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangePO}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangePO}") Then
                dirtyFlag = PO.GetPO(txtPOCode, Me.m_entity.Po)
                Me.txtPODate.Text = MinDateToNull(Me.m_entity.Po.DocDate, "")
                Me.txtSupplierCode.Text = Me.m_entity.Supplier.Code
                Me.txtSupplierName.Text = Me.m_entity.Supplier.Name
                Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
                Me.txtToCostCenterName.Text = Me.m_entity.ToCostCenter.Name
                For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
                  vitem.PrintName = Me.m_entity.Supplier.Name
                  vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
                Next
                Me.m_entity.AdvancePayItemCollection.Clear()
                Me.RefreshBlankGrid()
                UpdateAmount()
                txtcreditprdChanged = False
              Else
                Me.txtPOCode.Text = Me.m_entity.Po.Code
                pOCodeChanged = False
              End If
            Else
              Me.m_entity.Po = New PO
              Me.txtPODate.Text = ""
            End If
            Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
            Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
          End If
          RefreshDocs()
        Case "txtinvoicecode"
          If m_oldInvoiceCode <> Me.txtInvoiceCode.Text Then
            Me.m_entity.Vat.CodeChanged(Me.txtInvoiceCode.Text)
            m_oldInvoiceCode = Me.txtInvoiceCode.Text
            If Not Me.m_entity.Originated Then
              If Me.txtInvoiceCode.Text.Trim.Length > 0 Then
                Me.txtInvoiceDate.Text = Me.txtDocDate.Text
              Else
                Me.txtInvoiceDate.Text = ""
              End If
            End If
            dirtyFlag = True
          End If
        Case "txtinvoicedate"
          m_dateSetting = True
          dirtyFlag = Me.m_entity.Vat.DateTextChanged(txtInvoiceDate, dtpInvoiceDate, Me.Validator)
          m_dateSetting = False
        Case "dtpinvoicedate"
          dirtyFlag = Me.m_entity.Vat.DatePickerChanged(dtpInvoiceDate, txtInvoiceDate, m_dateSetting)
        Case "txttoccpersoncode"
          If toCCPersonCodeChanged Then
            dirtyFlag = Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_entity.ToCostCenterPerson)
            toCCPersonCodeChanged = False
          End If
        Case "txttocostcentercode"
          If toCCCodeChanged Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
              If Me.txtToCostCenterCode.TextLength <> 0 Then
                dirtyFlag = CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                If dirtyFlag Then
                  UpdateDestAdmin()
                End If
              Else
                Me.m_entity.ToCostCenter = New CostCenter
                txtToCostCenterName.Text = ""
              End If
              Try
                If oldCCId <> Me.m_entity.ToCostCenter.Id Then
                  Me.WorkbenchWindow.ViewContent.IsDirty = True
                  oldCCId = Me.m_entity.ToCostCenter.Id
                  ChangeCC()
                End If
              Catch ex As Exception

              End Try
              toCCCodeChanged = False
            Else
              Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
              toCCCodeChanged = False
            End If
          End If
        Case "txttocostcentername"
          Dim txt As String = txtToCostCenterName.Text
          Dim reg As New Regex("\[(.*)\]")
          If reg.IsMatch(txt) Then
            Dim cc As CostCenter
            Try
              cc = New CostCenter(reg.Match(txt).Groups(1).Value)
              Me.m_entity.ToCostCenter = cc
              dirtyFlag = True
            Catch ex As Exception
              cc = New CostCenter
            End Try
            If dirtyFlag Then
              UpdateDestAdmin()
            End If
          End If
          m_isInitialized = False
          Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
          Me.txtToCostCenterName.Text = Me.m_entity.ToCostCenter.Name
          m_isInitialized = True
        Case "txtdeliveryperson"
          Me.m_entity.DeliveryPerson = txtDeliveryPerson.Text
          dirtyFlag = True
        Case "cmbdoctype"
          Dim item As IdValuePair = CType(Me.cmbDocType.SelectedItem, IdValuePair)
          Me.m_entity.ToAccountType.Value = item.Id
          dirtyFlag = True
        Case Else
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub ChangeSupplier()
      oldSupId = Me.m_entity.Supplier.Id
      For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
        vitem.PrintName = Me.m_entity.Supplier.Name
        vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
      Next
      If Not Me.m_entity.Po Is Nothing AndAlso Me.m_entity.Po.Originated Then
        Me.txtPOCode.Text = Me.m_entity.Po.Code
        Me.txtPODate.Text = MinDateToNull(Me.m_entity.Po.DocDate, "")
      Else
        Me.txtPOCode.Text = ""
        Me.txtPODate.Text = ""
      End If
      supplierCodeChanged = False
      Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      Me.txtDueDate.Text = MinDateToNow(Me.m_entity.DueDate)
      Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
      txtcreditprdChanged = False
      'พอเปลี่ยน Supplier ให้เคลียร์มัดจำที่เคยเลือกไว้ เพื่อให้เลือกใหม่
      Me.m_entity.AdvancePayItemCollection.Clear()
      Me.UpdateAmount()
      Me.RefreshBlankGrid()
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
      Dim flag As Boolean = m_isInitialized
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
      If m_entity.TaxType.Value = 0 OrElse m_entity.TaxType.Value = 1 Then
        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
      End If
      txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
      txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
      txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
      'If IsNumeric(Me.m_entity.Discount.Rate) Then
      '  If Me.m_entity.Discount.Rate.IndexOf(".") > 0 Then
      '    Dim digit() As String
      '    Dim digit1 As String = 0
      '    digit = m_entity.Discount.Rate.Split(".")
      '    digit1 = digit(0)
      '    digit = Configuration.FormatToString(CDec("0." & digit(1)), DigitConfig.Price).Split(".")
      '    If DigitConfig.Price > 0 Then
      '      txtDiscountRate.Text = digit1 & "." & digit(1)
      '    Else
      '      txtDiscountRate.Text = m_entity.Discount.Rate
      '    End If
      '  Else
      '    txtDiscountRate.Text = m_entity.Discount.Rate
      '  End If
      'Else
      '  txtDiscountRate.Text = m_entity.Discount.Rate
      'End If
      txtDiscountRate.Text = m_entity.Discount.Rate

      txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
      txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)
      CodeDescription.ComboSelect(Me.cmbTaxType, Me.m_entity.TaxType)

      txtRealGross.Text = Configuration.FormatToString(m_entity.RealGross, DigitConfig.Price)
      txtRealTaxAmount.Text = Configuration.FormatToString(m_entity.RealTaxAmount, DigitConfig.Price)
      txtRealTaxBase.Text = Configuration.FormatToString(m_entity.RealTaxBase, DigitConfig.Price)

      Me.txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)

      '--------------NOTE-------------------
      txtNote.Text = m_entity.Note
      '-------------------------------------

      m_isInitialized = flag
      SetVatInputAfterAmountChange()
      'RefreshWBS()
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
    Public Sub SetStatus()
      If m_entity.Canceled Then
        Me.StatusBarService.SetMessage("ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name)
      ElseIf m_entity.Edited Then
        Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name & ",แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name)
      ElseIf Me.m_entity.Originated Then
        Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name)
      Else
        Me.StatusBarService.SetMessage("")
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
        End If
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          If Not Me.m_entity Is Nothing Then
            Me.m_entity.ClearReference()
          End If
          Me.m_entity = Nothing
          Me.m_entity = CType(Value, GoodsReceipt)
        End If
        If Not Me.m_entity Is Nothing Then
          If Me.m_entity.IsReferenced Then
            m_entityRefed = 1
          Else
            m_entityRefed = 0
          End If
          'Hack:
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        Else
        End If
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
      SetTaxTypeComboBox()
      ListType()
      RefreshAutoComplete(10)
      RefreshAutoComplete(87)
    End Sub
    Private Sub ListType()
      Dim oldType As New GoodsReceiptToAcctType(-1)
      If Not Me.m_entity Is Nothing Then
        oldType = Me.m_entity.ToAccountType
      End If
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocType, "GoodsReceiptToAcctType")
      If oldType.Value = -1 Then
        oldType.Value = 1
      End If
      CodeDescription.ComboSelect(Me.cmbDocType, oldType)
    End Sub
    Private Sub SetTaxTypeComboBox()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
      cmbTaxType.SelectedIndex = 1
    End Sub
#End Region

#Region "Event Handler"
    Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As GoodsReceiptItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim view As Integer = 45
      Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      If wsdColl.GetSumPercent >= 100 Then
        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
      ElseIf doc.ItemType.Value = 160 Or doc.ItemType.Value = 162 Then
        msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveWBS}")
      Else
        Dim wbsd As New WBSDistribute
        wbsd.CostCenter = Me.m_entity.ToCostCenter
        wbsd.Percent = 100 - wsdColl.GetSumPercent
        wsdColl.Add(wbsd)
      End If
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view)
      m_wbsdInitialized = True
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim doc As GoodsReceiptItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      If wsdColl.Count > 0 Then
        wsdColl.Remove(wsdColl.Count - 1)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Dim view As Integer = 45
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view)
      m_wbsdInitialized = True
    End Sub
    Private currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      If tgItem.CurrentRowIndex <> currentY Then
        Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
        'RefreshWBS()
        currentY = tgItem.CurrentRowIndex
      End If
    End Sub
    'Private Sub RefreshWBS()
    '  Dim dt As TreeTable = Me.m_treeManager2.Treetable
    '  dt.Clear()
    '  Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
    '  If Me.m_entity.ItemCollection.CurrentItem Is Nothing Then
    '    Return
    '  End If
    '  Dim item As GoodsReceiptItem = Me.m_entity.ItemCollection.CurrentItem
    '  Dim wsdColl As WBSDistributeCollection = item.WBSDistributeCollection
    '  Dim view As Integer = 45
    '  m_wbsdInitialized = False
    '  wsdColl.Populate(dt, item, view)
    '  m_wbsdInitialized = True
    'End Sub
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
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
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
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        'If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
        '  Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
        'End If
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = Me.m_entity.Code
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim doc As GoodsReceiptItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New GoodsReceiptItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAcct)
    End Sub
    Private Sub SetAcct(ByVal acct As ISimpleEntity)
      Me.m_treeManager.SelectedRow("AccountCode") = acct.Code
      Me.m_entity.OnGlChanged() 'ยังหาทาง set ใน item ไม่ได้
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As GoodsReceiptItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New GoodsReceiptItem
        doc.ItemType = New ItemType(0)
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
    Private m_targetType As Integer
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As GoodsReceiptItem = Me.m_entity.ItemCollection.CurrentItem
      m_targetType = -1
      If doc Is Nothing Then
        doc = New GoodsReceiptItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      If doc.ItemType.Value = 19 Or doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
        m_targetType = doc.ItemType.Value
        Dim entities(2) As ISimpleEntity
        entities(0) = New LCIItem
        entities(1) = New LCIForList
        'entities(0) = New Material
        entities(2) = New Tool
        Dim activeIndex As Integer = -1
        If Not doc.ItemType Is Nothing Then
          If doc.ItemType.Value = 19 Then
            activeIndex = 2
          ElseIf doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
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
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As GoodsReceiptItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      If Not doc.POitem Is Nothing Then
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim theItem As New GoodsReceiptItem
      theItem.Entity = newItem
      theItem.ItemType = New ItemType(0)
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc), theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim rowsCount As Integer = 0
      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing Then
          rowsCount += 1
          Dim row As TreeRow = CType(Obj, TreeRow)
          If Not row Is Nothing Then
            If TypeOf row.Tag Is GoodsReceiptItem Then
              Dim doc As GoodsReceiptItem = CType(row.Tag, GoodsReceiptItem)
              If Not doc Is Nothing Then
                Me.m_entity.ItemCollection.Remove(doc)
              End If
            End If
          End If
        End If
      Next

      If rowsCount.Equals(0) Then
        Dim doc As GoodsReceiptItem = Me.m_entity.ItemCollection.CurrentItem
        If doc Is Nothing Then
          Return
        End If
        Me.m_entity.ItemCollection.Remove(doc)
      End If

      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtUnlocker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtUnlocker.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim x As Form
      If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.Message.Unlock}", "${res:Longkong.Pojjaman.Gui.Panels..Caption.Unlock}") Then
        x = New UnlockCommentForm(Me.Entity)
        x.ShowDialog()
        If Me.m_entity.Unlock = True Then
          Me.Unlock = True
          CheckFormEnable()
        End If
      End If
    End Sub

#Region "Comment"
    'Private Sub ibtnGenCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Dim nextCode As String = Me.m_entity.GetNextCode
    '    'If Me.txtCode.Text = "" And Me.m_entity.Code <> Me.m_entity.GetLastCode Then
    '    '    Me.txtCode.Text = nextCode
    '    '    Me.txtCode.Update()
    '    'End If
    'End Sub
    'Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
    '    'Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.POItemAuxDetail(CType(Me.m_entity.Items(e.Row), POItem)))
    '    'myDialog.ShowDialog()
    'End Sub
    'Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
    '    'For Each helper As IHelper In Me.m_helpers
    '    '    helper.HideHelper()
    '    'Next
    '    Dim cellRect As Rectangle = tgItem.GetCellBounds(tgItem.CurrentCell.RowNumber, tgItem.CurrentCell.ColumnNumber)
    '    Dim cellPoint As Point = tgItem.PointToScreen(cellRect.Location)
    '    cellPoint.Y += cellRect.Height
    '    Dim helperRect As New Rectangle(cellPoint, New Size(250, 250))
    '    Dim colName As String = tgItem.TableStyles(0).GridColumnStyles(tgItem.CurrentCell.ColumnNumber).MappingName

    '    Select Case colName.ToLower
    '        Case "description"
    '        Case "unit"
    '    End Select
    'End Sub

    'Private Sub txtRequestor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'End Sub

    'Private Sub ibtnItemSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.POItemSelectionPanel)
    '    myDialog.ShowDialog()
    'End Sub
#End Region

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
		'Equipment
		Private Sub ibtnShowAssetDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEquipmentDiaog.Click
			Dim myEntityPanelService As IEntityPanelService = _
						CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			Dim entities As New ArrayList
			Dim eq As New Asset
			entities.Add(eq)
			myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAsset, entities)
		End Sub
		Private Sub SetAsset(ByVal e As ISimpleEntity)
			Me.txtEquipmentCode.Text = e.Code
			Dim flag As Boolean = Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_entity.Asset)
			If flag Then
				Me.ChangeEq()
			End If
			Me.WorkbenchWindow.ViewContent.IsDirty = _
				Me.WorkbenchWindow.ViewContent.IsDirty _
				Or flag
		End Sub
		Private Sub ChangeEq()
			Dim flag As Boolean = Me.m_isInitialized
			Me.m_isInitialized = False
			txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
			txtToCostCenterName.Text = m_entity.ToCostCenter.Name
			Me.m_isInitialized = flag
		End Sub
		' Supplier
		Private Sub ibtnShowSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplier.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenPanel(New Supplier)
		End Sub
		Private Sub ibtnShowSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplierDialog.Click
			Dim myEntityPanelService As IEntityPanelService = _
			CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
		End Sub
		Private Sub SetSupplier(ByVal e As ISimpleEntity)
			Me.txtSupplierCode.Text = e.Code
			Me.ChangeProperty(txtSupplierCode, Nothing)
		End Sub
		' AdvancePay
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
		'PO
		Private Sub ibtnShowPODialog_click(ByVal sendr As Object, ByVal e As EventArgs) Handles ibtnShowPODialog.Click
			Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
			If Me.m_entity.Po Is Nothing OrElse Not Me.m_entity.Po.Originated OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangePO}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangePO}") Then
				Dim myEntityPanelService As IEntityPanelService = _
				CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
				Dim entities As New ArrayList
				If Me.m_entity.Supplier.Originated Then
					entities.Add(Me.m_entity.Supplier)
				End If
				If Me.m_entity.ToCostCenter.Originated Then
					entities.Add(Me.m_entity.ToCostCenter)
				End If
        Dim poNeedsApproval As Boolean = False
        Dim poExcluded As Object = DBNull.Value
        poNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
        If Not Me.m_entity.Po Is Nothing AndAlso Me.m_entity.Po.Originated Then
          poExcluded = Me.m_entity.Po.Id
        End If
        Dim filters(1) As Filter
        filters(0) = New Filter("poNeedsApproval", poNeedsApproval)
        filters(1) = New Filter("poExcluded", poExcluded)
        'filters(1) = New Filter("excludeCanceled", True)
        'filters(2) = New Filter("excludedepleted", True)
        'filters(3) = New Filter("excludeclosed", True)
        myEntityPanelService.OpenListDialog(New POForGoodsReceipt, AddressOf SetPO, filters, entities)
			End If
		End Sub
		Private Sub SetPO(ByVal e As ISimpleEntity)
			Dim poNeedsApproval As Boolean = False
			poNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
      Dim newPo As PO = CType(e, PO)
			If poNeedsApproval AndAlso newPo.ApproveDate.Equals(Date.MinValue) Then
				Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
				msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ThisPOIsNotApproved}", New String() {newPo.Code})
				Return
			End If
			Me.txtPOCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
       Me.WorkbenchWindow.ViewContent.IsDirty _
       Or PO.GetPO(txtPOCode, Me.m_entity.Po)

      Dim flag As Boolean = m_isInitialized
			m_isInitialized = False
			Me.txtPODate.Text = MinDateToNull(Me.m_entity.Po.DocDate, "")
			Me.txtSupplierCode.Text = Me.m_entity.Supplier.Code
			Me.txtSupplierName.Text = Me.m_entity.Supplier.Name
			Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
			Me.txtToCostCenterName.Text = Me.m_entity.ToCostCenter.Name
			Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
			For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
				vitem.PrintName = Me.m_entity.Supplier.Name
				vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
			Next
			Me.m_entity.AdvancePayItemCollection.Clear()
			m_isInitialized = flag

			RefreshDocs()
      Me.m_entity.OnGlChanged()

			pOCodeChanged = False
		End Sub
		Private Sub ibtnShowToCostCenterDialog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowToCostCenterDialog.Click
			Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
			If Me.m_entity.ToCostCenter Is Nothing OrElse Not Me.m_entity.ToCostCenter.Originated OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
				Dim myEntityPanelService As IEntityPanelService = _
							CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
				myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
			End If
		End Sub
		Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
			Me.txtToCostCenterCode.Text = e.Code
			Me.WorkbenchWindow.ViewContent.IsDirty = _
				Me.WorkbenchWindow.ViewContent.IsDirty _
				Or CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
			UpdateDestAdmin()
			Try
				If oldCCId <> Me.m_entity.ToCostCenter.Id Then
					Me.WorkbenchWindow.ViewContent.IsDirty = True
					oldCCId = Me.m_entity.ToCostCenter.Id
					ChangeCC()
				End If
			Catch ex As Exception

			End Try
			Me.toCCCodeChanged = False
		End Sub
		Private Sub ChangeCC()
			oldCCId = Me.m_entity.ToCostCenter.Id
			'For Each item As GoodsReceiptItem In Me.m_entity.ItemCollection
			'    item.WBSDistributeCollection.Clear()
			'Next
      'RefreshWBS()
		End Sub
		Private Sub UpdateDestAdmin()
			If Me.m_entity Is Nothing Then
				Return
			End If
			Dim flag As Boolean = Me.m_isInitialized
			Me.m_isInitialized = False
			Me.m_entity.ToCostCenterPerson = Me.m_entity.ToCostCenter.Admin
			Me.txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
			txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name
			Me.m_isInitialized = flag
		End Sub
		Private Sub ibtShowToCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtShowToCostCenter.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenPanel(New CostCenter)
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
			Me.toCCPersonCodeChanged = False
		End Sub
		Private Sub ibtnShowToCCPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCCPerson.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenPanel(New Employee)
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
							Me.SetSupplier(entity)
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
					Case Keys.Enter
						If TypeOf Me.ActiveControl Is TextBox Then
							If Me.ActiveControl.Name.ToLower.StartsWith("txt") Then
								If CType(Me.ActiveControl, TextBox).Multiline Then
									Dim tmpIndx As Integer = CType(Me.ActiveControl, TextBox).SelectionStart
									CType(Me.ActiveControl, TextBox).Text = CType(Me.ActiveControl, TextBox).Text.Insert(CType(Me.ActiveControl, TextBox).SelectionStart, vbCrLf)
									CType(Me.ActiveControl, TextBox).SelectionStart = tmpIndx + 2
									Return True
								End If
							End If
						End If
						SendKeys.Send("{tab}")
						Return True
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
			'Me.m_entity.IsEntityDirty = True
		End Sub
#End Region

    Public Sub RefreshAutoComplete(ByVal entityId As Integer) Implements ICanRefreshAutoComplete.RefreshAutoComplete
      Dim a As AutoCompleteStringCollection      
      Select Case entityId
        Case 10
          Me.txtSupplierName.AutoCompleteSource = AutoCompleteSource.CustomSource
          Me.txtSupplierName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
          a = New AutoCompleteStringCollection
          For Each kv As KeyValuePair(Of String, String) In Supplier.InfoList
            a.Add(kv.Value & " [" & kv.Key & "]")
          Next
          For Each kv As KeyValuePair(Of String, String) In Supplier.InfoList
            a.Add("[" & kv.Key & "] " & kv.Value)
          Next
          Me.txtSupplierName.AutoCompleteCustomSource = a
        Case 87
          Me.txtToCostCenterName.AutoCompleteSource = AutoCompleteSource.CustomSource
          Me.txtToCostCenterName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
          a = New AutoCompleteStringCollection
          For Each kv As KeyValuePair(Of String, String) In CostCenter.InfoList
            a.Add(kv.Value & " [" & kv.Key & "]")
          Next
          For Each kv As KeyValuePair(Of String, String) In CostCenter.InfoList
            a.Add("[" & kv.Key & "] " & kv.Value)
          Next
          Me.txtToCostCenterName.AutoCompleteCustomSource = a
      End Select
    End Sub

        Private Sub txtNote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.TextChanged

        End Sub
        Private Sub lblNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNote.Click

        End Sub
    End Class
End Namespace
