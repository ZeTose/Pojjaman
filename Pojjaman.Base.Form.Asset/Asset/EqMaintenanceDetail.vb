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
  Public Class EqMaintenanceDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable
    'Inherits UserControl

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
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDeliveryCode As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDeliveryDocDate As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceCode As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceCode As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDeliveryDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDeliveryDocDate As System.Windows.Forms.DateTimePicker
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
    Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
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
    Friend WithEvents ibtnShowEquipment As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEquipmentName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowEquipmentDiaog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEquipmentCode As System.Windows.Forms.TextBox
    Friend WithEvents lblEquipment As System.Windows.Forms.Label
    Friend WithEvents tgWBS As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnAddWBS As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelWBS As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblWBS As System.Windows.Forms.Label
    Friend WithEvents txtRealGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblAdvancePay As System.Windows.Forms.Label
    Friend WithEvents txtAdvancePayAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowAdvancePay As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EqMaintenanceDetail))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.lblItem = New System.Windows.Forms.Label
      Me.grbReceive = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.ibtnShowEquipment = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEquipmentName = New System.Windows.Forms.TextBox
      Me.ibtnShowEquipmentDiaog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEquipmentCode = New System.Windows.Forms.TextBox
      Me.lblEquipment = New System.Windows.Forms.Label
      Me.txtToCCPersonName = New System.Windows.Forms.TextBox
      Me.txtToCCPersonCode = New System.Windows.Forms.TextBox
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox
      Me.lblToCCPerson = New System.Windows.Forms.Label
      Me.lblToCostCenter = New System.Windows.Forms.Label
      Me.ibtnShowToCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowToCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbDelivery = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.ibtnShowSupplier = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtSupplierName = New System.Windows.Forms.TextBox
      Me.ibtnShowSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblSupplier = New System.Windows.Forms.Label
      Me.txtSupplierCode = New System.Windows.Forms.TextBox
      Me.lblCreditPrd = New System.Windows.Forms.Label
      Me.lblDay = New System.Windows.Forms.Label
      Me.txtCreditPrd = New System.Windows.Forms.TextBox
      Me.txtDeliveryPerson = New System.Windows.Forms.TextBox
      Me.lblDeliveryPerson = New System.Windows.Forms.Label
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.lblDeliveryCode = New System.Windows.Forms.Label
      Me.txtDeliveryCode = New System.Windows.Forms.TextBox
      Me.lblDeliveryDocDate = New System.Windows.Forms.Label
      Me.lblInvoiceCode = New System.Windows.Forms.Label
      Me.txtInvoiceCode = New System.Windows.Forms.TextBox
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.txtDeliveryDocDate = New System.Windows.Forms.TextBox
      Me.txtInvoiceDate = New System.Windows.Forms.TextBox
      Me.txtGross = New System.Windows.Forms.TextBox
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox
      Me.txtBeforeTax = New System.Windows.Forms.TextBox
      Me.txtTaxAmount = New System.Windows.Forms.TextBox
      Me.txtAfterTax = New System.Windows.Forms.TextBox
      Me.txtDiscountRate = New System.Windows.Forms.TextBox
      Me.txtTaxRate = New System.Windows.Forms.TextBox
      Me.txtTaxBase = New System.Windows.Forms.TextBox
      Me.txtRealGross = New System.Windows.Forms.TextBox
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.dtpDeliveryDocDate = New System.Windows.Forms.DateTimePicker
      Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker
      Me.lblInvoiceDate = New System.Windows.Forms.Label
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblTaxAmount = New System.Windows.Forms.Label
      Me.lblAfterTax = New System.Windows.Forms.Label
      Me.lblDiscountAmount = New System.Windows.Forms.Label
      Me.lblBeforeTax = New System.Windows.Forms.Label
      Me.lblGross = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.cmbTaxType = New System.Windows.Forms.ComboBox
      Me.lblTaxType = New System.Windows.Forms.Label
      Me.lblTaxRate = New System.Windows.Forms.Label
      Me.lblTaxBase = New System.Windows.Forms.Label
      Me.lblPercent = New System.Windows.Forms.Label
      Me.ibtnEnableVatInput = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.tgWBS = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.ibtnAddWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblWBS = New System.Windows.Forms.Label
      Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblAdvancePay = New System.Windows.Forms.Label
      Me.txtAdvancePayAmount = New System.Windows.Forms.TextBox
      Me.ibtnShowAdvancePay = New Longkong.Pojjaman.Gui.Components.ImageButton
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbReceive.SuspendLayout()
      Me.grbDelivery.SuspendLayout()
      CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 192)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 120)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 180
      Me.lblCode.Text = "เลขที่:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(88, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.TabStop = False
      Me.txtCode.Text = ""
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(200, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblDocDate.TabIndex = 179
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 176)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 181
      Me.lblItem.Text = "รายการซ่อมบำรุง:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbReceive
      '
      Me.grbReceive.Controls.Add(Me.ibtnShowEquipment)
      Me.grbReceive.Controls.Add(Me.txtEquipmentName)
      Me.grbReceive.Controls.Add(Me.ibtnShowEquipmentDiaog)
      Me.grbReceive.Controls.Add(Me.txtEquipmentCode)
      Me.grbReceive.Controls.Add(Me.lblEquipment)
      Me.grbReceive.Controls.Add(Me.txtToCCPersonName)
      Me.grbReceive.Controls.Add(Me.txtToCCPersonCode)
      Me.grbReceive.Controls.Add(Me.txtToCostCenterName)
      Me.grbReceive.Controls.Add(Me.txtToCostCenterCode)
      Me.grbReceive.Controls.Add(Me.lblToCCPerson)
      Me.grbReceive.Controls.Add(Me.lblToCostCenter)
      Me.grbReceive.Controls.Add(Me.ibtnShowToCCPerson)
      Me.grbReceive.Controls.Add(Me.ibtnShowToCCPersonDialog)
      Me.grbReceive.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbReceive.Location = New System.Drawing.Point(16, 72)
      Me.grbReceive.Name = "grbReceive"
      Me.grbReceive.Size = New System.Drawing.Size(352, 96)
      Me.grbReceive.TabIndex = 8
      Me.grbReceive.TabStop = False
      Me.grbReceive.Text = "เครื่องจักร"
      '
      'ibtnShowEquipment
      '
      Me.ibtnShowEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEquipment.Image = CType(resources.GetObject("ibtnShowEquipment.Image"), System.Drawing.Image)
      Me.ibtnShowEquipment.Location = New System.Drawing.Point(320, 16)
      Me.ibtnShowEquipment.Name = "ibtnShowEquipment"
      Me.ibtnShowEquipment.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEquipment.TabIndex = 274
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
      Me.txtEquipmentName.Location = New System.Drawing.Point(152, 16)
      Me.Validator.SetMaxValue(Me.txtEquipmentName, "")
      Me.Validator.SetMinValue(Me.txtEquipmentName, "")
      Me.txtEquipmentName.Name = "txtEquipmentName"
      Me.txtEquipmentName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEquipmentName, "")
      Me.Validator.SetRequired(Me.txtEquipmentName, False)
      Me.txtEquipmentName.Size = New System.Drawing.Size(144, 20)
      Me.txtEquipmentName.TabIndex = 275
      Me.txtEquipmentName.TabStop = False
      Me.txtEquipmentName.Text = ""
      '
      'ibtnShowEquipmentDiaog
      '
      Me.ibtnShowEquipmentDiaog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEquipmentDiaog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEquipmentDiaog.Image = CType(resources.GetObject("ibtnShowEquipmentDiaog.Image"), System.Drawing.Image)
      Me.ibtnShowEquipmentDiaog.Location = New System.Drawing.Point(296, 16)
      Me.ibtnShowEquipmentDiaog.Name = "ibtnShowEquipmentDiaog"
      Me.ibtnShowEquipmentDiaog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEquipmentDiaog.TabIndex = 273
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
      Me.txtEquipmentCode.Location = New System.Drawing.Point(88, 16)
      Me.Validator.SetMaxValue(Me.txtEquipmentCode, "")
      Me.Validator.SetMinValue(Me.txtEquipmentCode, "")
      Me.txtEquipmentCode.Name = "txtEquipmentCode"
      Me.Validator.SetRegularExpression(Me.txtEquipmentCode, "")
      Me.Validator.SetRequired(Me.txtEquipmentCode, True)
      Me.txtEquipmentCode.Size = New System.Drawing.Size(64, 20)
      Me.txtEquipmentCode.TabIndex = 271
      Me.txtEquipmentCode.Text = ""
      '
      'lblEquipment
      '
      Me.lblEquipment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEquipment.Location = New System.Drawing.Point(8, 16)
      Me.lblEquipment.Name = "lblEquipment"
      Me.lblEquipment.Size = New System.Drawing.Size(80, 18)
      Me.lblEquipment.TabIndex = 272
      Me.lblEquipment.Text = "เครื่องจักร:"
      Me.lblEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToCCPersonName
      '
      Me.txtToCCPersonName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtToCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.txtToCCPersonName.Location = New System.Drawing.Point(152, 64)
      Me.Validator.SetMaxValue(Me.txtToCCPersonName, "")
      Me.Validator.SetMinValue(Me.txtToCCPersonName, "")
      Me.txtToCCPersonName.Name = "txtToCCPersonName"
      Me.txtToCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCCPersonName, "")
      Me.Validator.SetRequired(Me.txtToCCPersonName, False)
      Me.txtToCCPersonName.Size = New System.Drawing.Size(144, 20)
      Me.txtToCCPersonName.TabIndex = 270
      Me.txtToCCPersonName.TabStop = False
      Me.txtToCCPersonName.Text = ""
      '
      'txtToCCPersonCode
      '
      Me.Validator.SetDataType(Me.txtToCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.txtToCCPersonCode.Location = New System.Drawing.Point(88, 64)
      Me.Validator.SetMaxValue(Me.txtToCCPersonCode, "")
      Me.Validator.SetMinValue(Me.txtToCCPersonCode, "")
      Me.txtToCCPersonCode.Name = "txtToCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtToCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtToCCPersonCode, True)
      Me.txtToCCPersonCode.Size = New System.Drawing.Size(64, 20)
      Me.txtToCCPersonCode.TabIndex = 1
      Me.txtToCCPersonCode.Text = ""
      '
      'txtToCostCenterName
      '
      Me.txtToCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(152, 40)
      Me.Validator.SetMaxValue(Me.txtToCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.txtToCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(192, 20)
      Me.txtToCostCenterName.TabIndex = 266
      Me.txtToCostCenterName.TabStop = False
      Me.txtToCostCenterName.Text = ""
      '
      'txtToCostCenterCode
      '
      Me.txtToCostCenterCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(88, 40)
      Me.Validator.SetMaxValue(Me.txtToCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.txtToCostCenterCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, True)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(64, 20)
      Me.txtToCostCenterCode.TabIndex = 0
      Me.txtToCostCenterCode.TabStop = False
      Me.txtToCostCenterCode.Text = ""
      '
      'lblToCCPerson
      '
      Me.lblToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCPerson.Location = New System.Drawing.Point(8, 64)
      Me.lblToCCPerson.Name = "lblToCCPerson"
      Me.lblToCCPerson.Size = New System.Drawing.Size(80, 18)
      Me.lblToCCPerson.TabIndex = 124
      Me.lblToCCPerson.Text = "ผู้รับ:"
      Me.lblToCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblToCostCenter
      '
      Me.lblToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCostCenter.Location = New System.Drawing.Point(8, 40)
      Me.lblToCostCenter.Name = "lblToCostCenter"
      Me.lblToCostCenter.Size = New System.Drawing.Size(80, 18)
      Me.lblToCostCenter.TabIndex = 171
      Me.lblToCostCenter.Text = "Cost Center:"
      Me.lblToCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowToCCPerson
      '
      Me.ibtnShowToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPerson.Image = CType(resources.GetObject("ibtnShowToCCPerson.Image"), System.Drawing.Image)
      Me.ibtnShowToCCPerson.Location = New System.Drawing.Point(320, 64)
      Me.ibtnShowToCCPerson.Name = "ibtnShowToCCPerson"
      Me.ibtnShowToCCPerson.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPerson.TabIndex = 265
      Me.ibtnShowToCCPerson.TabStop = False
      Me.ibtnShowToCCPerson.ThemedImage = CType(resources.GetObject("ibtnShowToCCPerson.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowToCCPersonDialog
      '
      Me.ibtnShowToCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCCPersonDialog.Image = CType(resources.GetObject("ibtnShowToCCPersonDialog.Image"), System.Drawing.Image)
      Me.ibtnShowToCCPersonDialog.Location = New System.Drawing.Point(296, 64)
      Me.ibtnShowToCCPersonDialog.Name = "ibtnShowToCCPersonDialog"
      Me.ibtnShowToCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPersonDialog.TabIndex = 264
      Me.ibtnShowToCCPersonDialog.TabStop = False
      Me.ibtnShowToCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbDelivery
      '
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
      Me.grbDelivery.Location = New System.Drawing.Point(376, 72)
      Me.grbDelivery.Name = "grbDelivery"
      Me.grbDelivery.Size = New System.Drawing.Size(392, 72)
      Me.grbDelivery.TabIndex = 7
      Me.grbDelivery.TabStop = False
      Me.grbDelivery.Text = "ผู้ขาย"
      '
      'ibtnShowSupplier
      '
      Me.ibtnShowSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplier.Image = CType(resources.GetObject("ibtnShowSupplier.Image"), System.Drawing.Image)
      Me.ibtnShowSupplier.Location = New System.Drawing.Point(360, 16)
      Me.ibtnShowSupplier.Name = "ibtnShowSupplier"
      Me.ibtnShowSupplier.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplier.TabIndex = 257
      Me.ibtnShowSupplier.TabStop = False
      Me.ibtnShowSupplier.ThemedImage = CType(resources.GetObject("ibtnShowSupplier.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSupplierName
      '
      Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(144, 16)
      Me.Validator.SetMaxValue(Me.txtSupplierName, "")
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(192, 20)
      Me.txtSupplierName.TabIndex = 258
      Me.txtSupplierName.TabStop = False
      Me.txtSupplierName.Text = ""
      '
      'ibtnShowSupplierDialog
      '
      Me.ibtnShowSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowSupplierDialog.Image = CType(resources.GetObject("ibtnShowSupplierDialog.Image"), System.Drawing.Image)
      Me.ibtnShowSupplierDialog.Location = New System.Drawing.Point(336, 16)
      Me.ibtnShowSupplierDialog.Name = "ibtnShowSupplierDialog"
      Me.ibtnShowSupplierDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplierDialog.TabIndex = 256
      Me.ibtnShowSupplierDialog.TabStop = False
      Me.ibtnShowSupplierDialog.ThemedImage = CType(resources.GetObject("ibtnShowSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSupplier
      '
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(8, 16)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(72, 18)
      Me.lblSupplier.TabIndex = 124
      Me.lblSupplier.Text = "ผู้ขาย:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierCode
      '
      Me.txtSupplierCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(80, 16)
      Me.Validator.SetMaxValue(Me.txtSupplierCode, "")
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, True)
      Me.txtSupplierCode.Size = New System.Drawing.Size(64, 20)
      Me.txtSupplierCode.TabIndex = 0
      Me.txtSupplierCode.Text = ""
      '
      'lblCreditPrd
      '
      Me.lblCreditPrd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCreditPrd.Location = New System.Drawing.Point(8, 40)
      Me.lblCreditPrd.Name = "lblCreditPrd"
      Me.lblCreditPrd.Size = New System.Drawing.Size(72, 18)
      Me.lblCreditPrd.TabIndex = 320
      Me.lblCreditPrd.Text = "Credit Period:"
      Me.lblCreditPrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDay
      '
      Me.lblDay.AutoSize = True
      Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDay.Location = New System.Drawing.Point(152, 42)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(17, 17)
      Me.lblDay.TabIndex = 319
      Me.lblDay.Text = "วัน"
      Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtCreditPrd
      '
      Me.txtCreditPrd.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCreditPrd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
      Me.Validator.SetDisplayName(Me.txtCreditPrd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
      Me.txtCreditPrd.Location = New System.Drawing.Point(80, 40)
      Me.Validator.SetMaxValue(Me.txtCreditPrd, "")
      Me.Validator.SetMinValue(Me.txtCreditPrd, "0")
      Me.txtCreditPrd.Name = "txtCreditPrd"
      Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
      Me.Validator.SetRequired(Me.txtCreditPrd, False)
      Me.txtCreditPrd.Size = New System.Drawing.Size(64, 20)
      Me.txtCreditPrd.TabIndex = 1
      Me.txtCreditPrd.Text = ""
      '
      'txtDeliveryPerson
      '
      Me.txtDeliveryPerson.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDeliveryPerson, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDeliveryPerson, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDeliveryPerson, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDeliveryPerson, System.Drawing.Color.Empty)
      Me.txtDeliveryPerson.Location = New System.Drawing.Point(256, 40)
      Me.Validator.SetMaxValue(Me.txtDeliveryPerson, "")
      Me.Validator.SetMinValue(Me.txtDeliveryPerson, "")
      Me.txtDeliveryPerson.Name = "txtDeliveryPerson"
      Me.Validator.SetRegularExpression(Me.txtDeliveryPerson, "")
      Me.Validator.SetRequired(Me.txtDeliveryPerson, False)
      Me.txtDeliveryPerson.Size = New System.Drawing.Size(128, 20)
      Me.txtDeliveryPerson.TabIndex = 2
      Me.txtDeliveryPerson.Text = ""
      '
      'lblDeliveryPerson
      '
      Me.lblDeliveryPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDeliveryPerson.Location = New System.Drawing.Point(168, 41)
      Me.lblDeliveryPerson.Name = "lblDeliveryPerson"
      Me.lblDeliveryPerson.Size = New System.Drawing.Size(88, 18)
      Me.lblDeliveryPerson.TabIndex = 320
      Me.lblDeliveryPerson.Text = "Delivery Person:"
      Me.lblDeliveryPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(448, 144)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(320, 42)
      Me.txtNote.TabIndex = 9
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(392, 144)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(56, 18)
      Me.lblNote.TabIndex = 193
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDeliveryCode
      '
      Me.lblDeliveryCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDeliveryCode.ForeColor = System.Drawing.Color.Black
      Me.lblDeliveryCode.Location = New System.Drawing.Point(16, 40)
      Me.lblDeliveryCode.Name = "lblDeliveryCode"
      Me.lblDeliveryCode.Size = New System.Drawing.Size(80, 18)
      Me.lblDeliveryCode.TabIndex = 180
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
      Me.txtDeliveryCode.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMaxValue(Me.txtDeliveryCode, "")
      Me.Validator.SetMinValue(Me.txtDeliveryCode, "")
      Me.txtDeliveryCode.Name = "txtDeliveryCode"
      Me.Validator.SetRegularExpression(Me.txtDeliveryCode, "")
      Me.Validator.SetRequired(Me.txtDeliveryCode, False)
      Me.txtDeliveryCode.Size = New System.Drawing.Size(112, 21)
      Me.txtDeliveryCode.TabIndex = 3
      Me.txtDeliveryCode.TabStop = False
      Me.txtDeliveryCode.Text = ""
      '
      'lblDeliveryDocDate
      '
      Me.lblDeliveryDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDeliveryDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDeliveryDocDate.Location = New System.Drawing.Point(200, 40)
      Me.lblDeliveryDocDate.Name = "lblDeliveryDocDate"
      Me.lblDeliveryDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblDeliveryDocDate.TabIndex = 179
      Me.lblDeliveryDocDate.Text = "วันที่:"
      Me.lblDeliveryDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInvoiceCode
      '
      Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceCode.Location = New System.Drawing.Point(360, 17)
      Me.lblInvoiceCode.Name = "lblInvoiceCode"
      Me.lblInvoiceCode.Size = New System.Drawing.Size(96, 18)
      Me.lblInvoiceCode.TabIndex = 180
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
      Me.txtInvoiceCode.Location = New System.Drawing.Point(456, 16)
      Me.Validator.SetMaxValue(Me.txtInvoiceCode, "")
      Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
      Me.txtInvoiceCode.Name = "txtInvoiceCode"
      Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
      Me.Validator.SetRequired(Me.txtInvoiceCode, False)
      Me.txtInvoiceCode.Size = New System.Drawing.Size(112, 21)
      Me.txtInvoiceCode.TabIndex = 5
      Me.txtInvoiceCode.TabStop = False
      Me.txtInvoiceCode.Text = ""
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
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(240, 16)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDocDate.TabIndex = 1
      Me.txtDocDate.Text = ""
      '
      'txtDeliveryDocDate
      '
      Me.Validator.SetDataType(Me.txtDeliveryDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDeliveryDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDeliveryDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDeliveryDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDeliveryDocDate, System.Drawing.Color.Empty)
      Me.txtDeliveryDocDate.Location = New System.Drawing.Point(240, 40)
      Me.Validator.SetMaxValue(Me.txtDeliveryDocDate, "")
      Me.Validator.SetMinValue(Me.txtDeliveryDocDate, "")
      Me.txtDeliveryDocDate.Name = "txtDeliveryDocDate"
      Me.Validator.SetRegularExpression(Me.txtDeliveryDocDate, "")
      Me.Validator.SetRequired(Me.txtDeliveryDocDate, False)
      Me.txtDeliveryDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDeliveryDocDate.TabIndex = 4
      Me.txtDeliveryDocDate.Text = ""
      '
      'txtInvoiceDate
      '
      Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.txtInvoiceDate.Location = New System.Drawing.Point(624, 16)
      Me.Validator.SetMaxValue(Me.txtInvoiceDate, "")
      Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
      Me.txtInvoiceDate.Name = "txtInvoiceDate"
      Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
      Me.Validator.SetRequired(Me.txtInvoiceDate, False)
      Me.txtInvoiceDate.Size = New System.Drawing.Size(78, 20)
      Me.txtInvoiceDate.TabIndex = 6
      Me.txtInvoiceDate.Text = ""
      '
      'txtGross
      '
      Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtGross.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(576, 320)
      Me.Validator.SetMaxValue(Me.txtGross, "")
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(81, 20)
      Me.txtGross.TabIndex = 299
      Me.txtGross.TabStop = False
      Me.txtGross.Text = ""
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
      Me.txtDiscountAmount.Location = New System.Drawing.Point(576, 344)
      Me.Validator.SetMaxValue(Me.txtDiscountAmount, "")
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.txtDiscountAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(184, 20)
      Me.txtDiscountAmount.TabIndex = 301
      Me.txtDiscountAmount.TabStop = False
      Me.txtDiscountAmount.Text = ""
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
      Me.txtBeforeTax.Location = New System.Drawing.Point(576, 392)
      Me.Validator.SetMaxValue(Me.txtBeforeTax, "")
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(184, 20)
      Me.txtBeforeTax.TabIndex = 302
      Me.txtBeforeTax.TabStop = False
      Me.txtBeforeTax.Text = ""
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
      Me.txtTaxAmount.Location = New System.Drawing.Point(576, 464)
      Me.Validator.SetMaxValue(Me.txtTaxAmount, "")
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(81, 20)
      Me.txtTaxAmount.TabIndex = 307
      Me.txtTaxAmount.TabStop = False
      Me.txtTaxAmount.Text = ""
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
      Me.txtAfterTax.Location = New System.Drawing.Point(576, 488)
      Me.Validator.SetMaxValue(Me.txtAfterTax, "")
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(184, 20)
      Me.txtAfterTax.TabIndex = 308
      Me.txtAfterTax.TabStop = False
      Me.txtAfterTax.Text = ""
      Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDiscountRate
      '
      Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDiscountRate.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.txtDiscountRate.Location = New System.Drawing.Point(496, 344)
      Me.Validator.SetMaxValue(Me.txtDiscountRate, "")
      Me.Validator.SetMinValue(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Name = "txtDiscountRate"
      Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
      Me.Validator.SetRequired(Me.txtDiscountRate, False)
      Me.txtDiscountRate.Size = New System.Drawing.Size(72, 20)
      Me.txtDiscountRate.TabIndex = 10
      Me.txtDiscountRate.Text = ""
      '
      'txtTaxRate
      '
      Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(720, 440)
      Me.Validator.SetMaxValue(Me.txtTaxRate, "")
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, True)
      Me.txtTaxRate.Size = New System.Drawing.Size(40, 20)
      Me.txtTaxRate.TabIndex = 304
      Me.txtTaxRate.Text = ""
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
      Me.txtTaxBase.Location = New System.Drawing.Point(576, 416)
      Me.Validator.SetMaxValue(Me.txtTaxBase, "")
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(81, 20)
      Me.txtTaxBase.TabIndex = 303
      Me.txtTaxBase.TabStop = False
      Me.txtTaxBase.Text = ""
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealGross
      '
      Me.txtRealGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.txtRealGross.Location = New System.Drawing.Point(680, 320)
      Me.Validator.SetMaxValue(Me.txtRealGross, "")
      Me.Validator.SetMinValue(Me.txtRealGross, "")
      Me.txtRealGross.Name = "txtRealGross"
      Me.Validator.SetRegularExpression(Me.txtRealGross, "")
      Me.Validator.SetRequired(Me.txtRealGross, False)
      Me.txtRealGross.Size = New System.Drawing.Size(81, 20)
      Me.txtRealGross.TabIndex = 323
      Me.txtRealGross.Text = ""
      Me.txtRealGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxAmount
      '
      Me.txtRealTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(680, 464)
      Me.Validator.SetMaxValue(Me.txtRealTaxAmount, "")
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(81, 20)
      Me.txtRealTaxAmount.TabIndex = 325
      Me.txtRealTaxAmount.Text = ""
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxBase
      '
      Me.txtRealTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(680, 416)
      Me.Validator.SetMaxValue(Me.txtRealTaxBase, "")
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(81, 20)
      Me.txtRealTaxBase.TabIndex = 324
      Me.txtRealTaxBase.Text = ""
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(240, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDocDate.TabIndex = 278
      Me.dtpDocDate.TabStop = False
      '
      'dtpDeliveryDocDate
      '
      Me.dtpDeliveryDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDeliveryDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDeliveryDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDeliveryDocDate.Location = New System.Drawing.Point(240, 40)
      Me.dtpDeliveryDocDate.Name = "dtpDeliveryDocDate"
      Me.dtpDeliveryDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDeliveryDocDate.TabIndex = 278
      Me.dtpDeliveryDocDate.TabStop = False
      '
      'dtpInvoiceDate
      '
      Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpInvoiceDate.Location = New System.Drawing.Point(624, 16)
      Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
      Me.dtpInvoiceDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpInvoiceDate.TabIndex = 278
      Me.dtpInvoiceDate.TabStop = False
      '
      'lblInvoiceDate
      '
      Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceDate.Location = New System.Drawing.Point(592, 17)
      Me.lblInvoiceDate.Name = "lblInvoiceDate"
      Me.lblInvoiceDate.Size = New System.Drawing.Size(32, 18)
      Me.lblInvoiceDate.TabIndex = 179
      Me.lblInvoiceDate.Text = "วันที่:"
      Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(128, 168)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 298
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(152, 168)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 297
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(556, 532)
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
      Me.lblAfterTax.Location = New System.Drawing.Point(400, 488)
      Me.lblAfterTax.Name = "lblAfterTax"
      Me.lblAfterTax.Size = New System.Drawing.Size(176, 18)
      Me.lblAfterTax.TabIndex = 293
      Me.lblAfterTax.Text = "ยอดสุทธิ :"
      Me.lblAfterTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDiscountAmount
      '
      Me.lblDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscountAmount.Location = New System.Drawing.Point(448, 344)
      Me.lblDiscountAmount.Name = "lblDiscountAmount"
      Me.lblDiscountAmount.Size = New System.Drawing.Size(48, 18)
      Me.lblDiscountAmount.TabIndex = 310
      Me.lblDiscountAmount.Text = "ส่วนลด :"
      Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(400, 392)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(176, 18)
      Me.lblBeforeTax.TabIndex = 311
      Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
      Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGross.BackColor = System.Drawing.Color.Transparent
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(496, 320)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(80, 18)
      Me.lblGross.TabIndex = 309
      Me.lblGross.Text = "ยอดเงินรวม :"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.Location = New System.Drawing.Point(400, 465)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(176, 18)
      Me.Label1.TabIndex = 306
      Me.Label1.Text = "ภาษี :"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbTaxType
      '
      Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(576, 440)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
      Me.cmbTaxType.TabIndex = 11
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(400, 440)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(176, 18)
      Me.lblTaxType.TabIndex = 314
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(648, 440)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
      Me.lblTaxRate.TabIndex = 316
      Me.lblTaxRate.Text = "อัตราภาษี :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxBase
      '
      Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.Location = New System.Drawing.Point(400, 416)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(176, 18)
      Me.lblTaxBase.TabIndex = 312
      Me.lblTaxBase.Text = "ฐานภาษี :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPercent
      '
      Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(760, 440)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 315
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnEnableVatInput
      '
      Me.ibtnEnableVatInput.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnEnableVatInput.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnEnableVatInput.Image = CType(resources.GetObject("ibtnEnableVatInput.Image"), System.Drawing.Image)
      Me.ibtnEnableVatInput.Location = New System.Drawing.Point(720, 14)
      Me.ibtnEnableVatInput.Name = "ibtnEnableVatInput"
      Me.ibtnEnableVatInput.Size = New System.Drawing.Size(24, 24)
      Me.ibtnEnableVatInput.TabIndex = 264
      Me.ibtnEnableVatInput.TabStop = False
      Me.ibtnEnableVatInput.ThemedImage = CType(resources.GetObject("ibtnEnableVatInput.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(184, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 318
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'tgWBS
      '
      Me.tgWBS.AllowNew = False
      Me.tgWBS.AllowSorting = False
      Me.tgWBS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgWBS.AutoColumnResize = True
      Me.tgWBS.CaptionVisible = False
      Me.tgWBS.Cellchanged = False
      Me.tgWBS.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))})
      Me.tgWBS.DataMember = ""
      Me.tgWBS.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgWBS.Location = New System.Drawing.Point(8, 360)
      Me.tgWBS.Name = "tgWBS"
      Me.tgWBS.Size = New System.Drawing.Size(360, 152)
      Me.tgWBS.SortingArrowColor = System.Drawing.Color.Red
      Me.tgWBS.TabIndex = 319
      Me.tgWBS.TreeManager = Nothing
      '
      'ibtnAddWBS
      '
      Me.ibtnAddWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnAddWBS.Image = CType(resources.GetObject("ibtnAddWBS.Image"), System.Drawing.Image)
      Me.ibtnAddWBS.Location = New System.Drawing.Point(368, 360)
      Me.ibtnAddWBS.Name = "ibtnAddWBS"
      Me.ibtnAddWBS.Size = New System.Drawing.Size(24, 24)
      Me.ibtnAddWBS.TabIndex = 321
      Me.ibtnAddWBS.TabStop = False
      Me.ibtnAddWBS.ThemedImage = CType(resources.GetObject("ibtnAddWBS.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelWBS
      '
      Me.ibtnDelWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnDelWBS.Image = CType(resources.GetObject("ibtnDelWBS.Image"), System.Drawing.Image)
      Me.ibtnDelWBS.Location = New System.Drawing.Point(392, 360)
      Me.ibtnDelWBS.Name = "ibtnDelWBS"
      Me.ibtnDelWBS.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelWBS.TabIndex = 322
      Me.ibtnDelWBS.TabStop = False
      Me.ibtnDelWBS.ThemedImage = CType(resources.GetObject("ibtnDelWBS.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblWBS
      '
      Me.lblWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblWBS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWBS.ForeColor = System.Drawing.Color.Black
      Me.lblWBS.Location = New System.Drawing.Point(8, 344)
      Me.lblWBS.Name = "lblWBS"
      Me.lblWBS.Size = New System.Drawing.Size(152, 18)
      Me.lblWBS.TabIndex = 320
      Me.lblWBS.Text = "จัดสรร WBS:"
      Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnResetGross
      '
      Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetGross.Image = CType(resources.GetObject("ibtnResetGross.Image"), System.Drawing.Image)
      Me.ibtnResetGross.Location = New System.Drawing.Point(656, 320)
      Me.ibtnResetGross.Name = "ibtnResetGross"
      Me.ibtnResetGross.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetGross.TabIndex = 326
      Me.ibtnResetGross.TabStop = False
      Me.ibtnResetGross.ThemedImage = CType(resources.GetObject("ibtnResetGross.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxAmount
      '
      Me.ibtnResetTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxAmount.Image = CType(resources.GetObject("ibtnResetTaxAmount.Image"), System.Drawing.Image)
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(656, 464)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 328
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxBase.Image = CType(resources.GetObject("ibtnResetTaxBase.Image"), System.Drawing.Image)
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(656, 416)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 327
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAdvancePay
      '
      Me.lblAdvancePay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAdvancePay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvancePay.Location = New System.Drawing.Point(496, 368)
      Me.lblAdvancePay.Name = "lblAdvancePay"
      Me.lblAdvancePay.Size = New System.Drawing.Size(80, 18)
      Me.lblAdvancePay.TabIndex = 330
      Me.lblAdvancePay.Text = "มัดจำ :"
      Me.lblAdvancePay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAdvancePayAmount
      '
      Me.txtAdvancePayAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAdvancePayAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAdvancePayAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvancePayAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvancePayAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvancePayAmount, System.Drawing.Color.Empty)
      Me.txtAdvancePayAmount.Location = New System.Drawing.Point(600, 368)
      Me.Validator.SetMaxValue(Me.txtAdvancePayAmount, "")
      Me.Validator.SetMinValue(Me.txtAdvancePayAmount, "")
      Me.txtAdvancePayAmount.Name = "txtAdvancePayAmount"
      Me.txtAdvancePayAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAdvancePayAmount, "")
      Me.Validator.SetRequired(Me.txtAdvancePayAmount, False)
      Me.txtAdvancePayAmount.Size = New System.Drawing.Size(160, 20)
      Me.txtAdvancePayAmount.TabIndex = 331
      Me.txtAdvancePayAmount.TabStop = False
      Me.txtAdvancePayAmount.Text = ""
      Me.txtAdvancePayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ibtnShowAdvancePay
      '
      Me.ibtnShowAdvancePay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnShowAdvancePay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAdvancePay.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAdvancePay.Image = CType(resources.GetObject("ibtnShowAdvancePay.Image"), System.Drawing.Image)
      Me.ibtnShowAdvancePay.Location = New System.Drawing.Point(575, 368)
      Me.ibtnShowAdvancePay.Name = "ibtnShowAdvancePay"
      Me.ibtnShowAdvancePay.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAdvancePay.TabIndex = 329
      Me.ibtnShowAdvancePay.TabStop = False
      Me.ibtnShowAdvancePay.ThemedImage = CType(resources.GetObject("ibtnShowAdvancePay.ThemedImage"), System.Drawing.Bitmap)
      '
      'EqMaintenanceDetail
      '
      Me.Controls.Add(Me.lblAdvancePay)
      Me.Controls.Add(Me.txtAdvancePayAmount)
      Me.Controls.Add(Me.ibtnShowAdvancePay)
      Me.Controls.Add(Me.txtRealGross)
      Me.Controls.Add(Me.ibtnResetGross)
      Me.Controls.Add(Me.txtRealTaxAmount)
      Me.Controls.Add(Me.ibtnResetTaxAmount)
      Me.Controls.Add(Me.txtRealTaxBase)
      Me.Controls.Add(Me.ibtnResetTaxBase)
      Me.Controls.Add(Me.tgWBS)
      Me.Controls.Add(Me.ibtnAddWBS)
      Me.Controls.Add(Me.ibtnDelWBS)
      Me.Controls.Add(Me.lblWBS)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.txtGross)
      Me.Controls.Add(Me.lblDiscountAmount)
      Me.Controls.Add(Me.txtDiscountAmount)
      Me.Controls.Add(Me.lblBeforeTax)
      Me.Controls.Add(Me.lblGross)
      Me.Controls.Add(Me.txtBeforeTax)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtTaxAmount)
      Me.Controls.Add(Me.txtAfterTax)
      Me.Controls.Add(Me.txtDiscountRate)
      Me.Controls.Add(Me.cmbTaxType)
      Me.Controls.Add(Me.lblTaxType)
      Me.Controls.Add(Me.txtTaxRate)
      Me.Controls.Add(Me.lblTaxRate)
      Me.Controls.Add(Me.txtTaxBase)
      Me.Controls.Add(Me.lblTaxBase)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.lblTaxAmount)
      Me.Controls.Add(Me.lblAfterTax)
      Me.Controls.Add(Me.txtDocDate)
      Me.Controls.Add(Me.dtpDocDate)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.grbReceive)
      Me.Controls.Add(Me.grbDelivery)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.txtCode)
      Me.Controls.Add(Me.lblDocDate)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblDeliveryCode)
      Me.Controls.Add(Me.txtDeliveryCode)
      Me.Controls.Add(Me.lblDeliveryDocDate)
      Me.Controls.Add(Me.lblInvoiceCode)
      Me.Controls.Add(Me.txtInvoiceCode)
      Me.Controls.Add(Me.txtDeliveryDocDate)
      Me.Controls.Add(Me.dtpDeliveryDocDate)
      Me.Controls.Add(Me.lblInvoiceDate)
      Me.Controls.Add(Me.txtInvoiceDate)
      Me.Controls.Add(Me.dtpInvoiceDate)
      Me.Controls.Add(Me.ibtnEnableVatInput)
      Me.Controls.Add(Me.lblPercent)
      Me.Name = "EqMaintenanceDetail"
      Me.Size = New System.Drawing.Size(784, 520)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbReceive.ResumeLayout(False)
      Me.grbDelivery.ResumeLayout(False)
      CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As EqMaintenance
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable

    Private m_treeManager2 As TreeManager
    Private m_wbsdInitialized As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dt As TreeTable = EqMaintenance.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      Dim dt2 As TreeTable = WBSDistribute.GetSchemaTable()
      Dim dst2 As DataGridTableStyle = Me.CreateTableStyle2()
      m_treeManager2 = New TreeManager(dt2, tgWBS)
      m_treeManager2.SetTableStyle(dst2)
      m_treeManager2.AllowSorting = False
      m_treeManager2.AllowDelete = False

      AddHandler dt2.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt2.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt2.RowDeleted, AddressOf ItemDelete

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
    Public Function CreateTableStyle2() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "WBS"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "LineNumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "LineNumber"

      Dim csWBS As New TreeTextColumn
      csWBS.MappingName = "WBS"
      csWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.WBSHeaderText}")
      csWBS.NullText = ""
      csWBS.Width = 100
      csWBS.ReadOnly = True
      csWBS.TextBox.Name = "WBS"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf WBSButtonClicked

      Dim csPercent As New TreeTextColumn
      csPercent.MappingName = "Percent"
      csPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.PercentHeaderText}")
      csPercent.NullText = ""
      csPercent.DataAlignment = HorizontalAlignment.Right
      csPercent.Format = "#,###.##"
      csPercent.Width = 70
      csPercent.TextBox.Name = "Percent"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmoluntHeaderText}")
      csAmount.NullText = ""
      csAmount.Alignment = HorizontalAlignment.Right
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True

      Dim csBudgetRemain As New TreeTextColumn
      csBudgetRemain.MappingName = "BudgetRemain"
      csBudgetRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.BudgetRemainHeaderText}")
      csBudgetRemain.NullText = ""
      csBudgetRemain.Alignment = HorizontalAlignment.Right
      csBudgetRemain.DataAlignment = HorizontalAlignment.Right
      csBudgetRemain.Format = "#,###.##"
      csBudgetRemain.TextBox.Name = "BudgetRemain"
      csBudgetRemain.ReadOnly = True

      Dim csQtyRemain As New TreeTextColumn
      csQtyRemain.MappingName = "QtyRemain"
      csQtyRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.QtyRemainHeaderText}")
      csQtyRemain.NullText = ""
      csQtyRemain.Alignment = HorizontalAlignment.Right
      csQtyRemain.DataAlignment = HorizontalAlignment.Right
      csQtyRemain.Format = "#,###.##"
      csQtyRemain.TextBox.Name = "QtyRemain"
      csQtyRemain.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csWBS)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csPercent)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csBudgetRemain)
      dst.GridColumnStyles.Add(csQtyRemain)

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Dim m_wbsColl As WBSCollection
    Dim m_mrkColl As MarkupCollection
    Public Sub WBSButtonClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.ToCostCenter Is Nothing Then
        Return
      End If
      If Me.m_entity.ToCostCenter.BoqId = 0 Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New WBS
      Dim filters() As Filter
      If m_wbsColl Is Nothing OrElse m_wbsColl.Boq.Id <> Me.m_entity.ToCostCenter.BoqId Then
        m_wbsColl = New WBSCollection(Me.m_entity.ToCostCenter.BoqId)
      End If
      If m_mrkColl Is Nothing OrElse m_mrkColl.Boq.Id <> Me.m_entity.ToCostCenter.BoqId Then
        m_mrkColl = New MarkupCollection(Me.m_entity.ToCostCenter.BoqId)
      End If
      filters = New Filter() {New Filter("mrkColl", m_mrkColl) _
                              , New Filter("wbsColl", m_wbsColl)}
      Dim entities As New ArrayList
      entities.Add(entity)
      myEntityPanelService.OpenListDialog(entity, AddressOf SetWBS, filters, entities)
    End Sub
    Private Sub SetWBS(ByVal myEntity As ISimpleEntity)
      'Dim tr As TreeRow = Me.m_treeManager.SelectedRow
      'Dim dt As TreeTable = Me.m_treeManager2.Treetable
      'Dim item As New EqMaintenanceItem
      'item.EqMaintenance = Me.m_entity
      'item.CopyFromDataRow(tr)
      'Dim wsdColl As WBSDistributeCollection = CType(tr.Tag, WBSDistributeCollection)
      'Dim row As TreeRow = Me.m_treeManager2.SelectedRow
      'If TypeOf myEntity Is WBS Then
      '    CType(row.Tag, WBSDistribute).WBS = CType(myEntity, WBS)
      '    CType(row.Tag, WBSDistribute).IsMarkup = False
      'ElseIf TypeOf myEntity Is Markup Then
      '    Dim newWBS As New WBS
      '    Dim myMarkup As Markup = CType(myEntity, Markup)
      '    newWBS.Id = myMarkup.Id
      '    newWBS.Code = myMarkup.Code
      '    newWBS.Name = myMarkup.Name
      '    CType(row.Tag, WBSDistribute).WBS = newWBS
      '    CType(row.Tag, WBSDistribute).IsMarkup = True
      'End If
      'Dim view As Integer = 45
      'm_wbsdInitialized = False
      'wsdColl.Populate(dt, item, view)
      'm_wbsdInitialized = True
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private ReadOnly Property CurrentWsbsd() As WBSDistribute
      Get
        Dim row As TreeRow = Me.m_treeManager2.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        Return CType(row.Tag, WBSDistribute)
      End Get
    End Property
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "EqMaintenance"

      'Stock Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "stocki_linenumber"
      csLineNumber.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "stocki_linenumber"

      Dim csName As New TreeTextColumn
      csName.MappingName = "stocki_itemName"
      csName.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf UnitButtonClick

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "stocki_qty"
      csQty.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "stocki_unitprice"
      csUnitPRice.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.UnitpriceHeaderText}")
      csUnitPRice.NullText = ""
      csUnitPRice.DataAlignment = HorizontalAlignment.Right
      csUnitPRice.TextBox.Name = "stocki_unitprice"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csDiscount As New TreeTextColumn
      csDiscount.MappingName = "stocki_discrate"
      csDiscount.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.DiscountHeaderText}")
      csDiscount.NullText = ""
      csDiscount.DataAlignment = HorizontalAlignment.Right
      csDiscount.TextBox.Name = "stocki_discrate"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "stocki_unvatable"
      csVatable.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.UnVatableHeaderText}")
      csVatable.Width = 100
      csVatable.InvisibleWhenUnspcified = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "stocki_note"
      csNote.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "stocki_note"


      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csDiscount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csVatable)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_wbsdInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_treeManager2.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        'UpdateAmount(e)
        Me.m_treeManager2.Treetable.AcceptChanges()
      End If
      RefreshWBS()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
      'Dim item As WBSDistribute = Me.CurrentWsbsd
      'If item Is Nothing Then
      '    Return
      'End If
      'Dim view As Integer = 45
      'Dim tr As TreeRow = Me.m_treeManager.SelectedRow
      'Dim gitem As New EqMaintenanceItem
      'gitem.CopyFromDataRow(tr)
      'e.Row("Amount") = Configuration.FormatToString(item.Percent * gitem.BeforeTax / 100, DigitConfig.Price)
      'If Not item.IsMarkup Then
      '    e.Row("BudgetRemain") = Configuration.FormatToString(item.WBS.GetTotal - item.WBS.GetActualTotal(Me.m_entity, view) + Me.m_entity.GetCurrentAmountForWBS(item.WBS, gitem.ItemType), DigitConfig.Price)
      '    e.Row("QtyRemain") = Configuration.FormatToString(0 - item.WBS.GetActualTotalQty(Me.m_entity, view) - 0, DigitConfig.Price)
      'Else
      '    Dim mk As Markup = Me.m_entity.ToCostCenter.Boq.MarkupCollection.GetMarkupFromId(item.WBS.Id)
      '    If Not mk Is Nothing Then
      '        e.Row("BudgetRemain") = Configuration.FormatToString(mk.TotalAmount - mk.GetActualTotal(Me.m_entity, view) - Me.m_entity.GetCurrentAmountForMarkup(mk), DigitConfig.Price)
      '    End If
      'End If
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_wbsdInitialized Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "wbs"
            SetCode(e)
          Case "percent"
            SetPercent(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim wbs As Object = e.Row("wbs")
      Dim percent As Object = e.Row("percent")

      Select Case e.Column.ColumnName.ToLower
        Case "wbs"
          wbs = e.ProposedValue
        Case "percent"
          percent = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If IsDBNull(wbs) Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
          e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
        Else
          e.Row.SetColumnError("percent", "")
        End If
        If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
          e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
        Else
          e.Row.SetColumnError("wbs", "")
        End If
      End If

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("WBS") Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetPercent(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim item As WBSDistribute = Me.CurrentWsbsd
      If item Is Nothing Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim oldvalue As Decimal = 0
      If Not e.Row.IsNull(e.Column) Then
        oldvalue = CDec(e.Row(e.Column))
      End If
      Dim tr As TreeRow = Me.m_treeManager.SelectedRow
      If tr Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If tr.Tag Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      Dim wsdColl As WBSDistributeCollection = CType(tr.Tag, WBSDistributeCollection)
      If wsdColl.GetSumPercent - oldvalue + value > 100 Then
        e.ProposedValue = e.Row(e.Column)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
        Return
      End If

      m_updating = True
      item.Percent = value
      m_updating = False
    End Sub

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
    Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      'If m_updating Then
      '    Return
      'End If
      'm_updating = True
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'If e.Row.IsNull("stocki_entityType") Then
      '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '    e.ProposedValue = e.Row(e.Column)
      '    m_updating = False
      '    Return
      'End If
      'If DupCode(e) Then
      '    Dim item As New EqMaintenanceItem
      '    item.CopyFromDataRow(CType(e.Row, TreeRow))
      '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
      '    e.ProposedValue = e.Row(e.Column)
      '    m_updating = False
      '    Return
      'End If
      'Select Case CInt(e.Row("stocki_entityType"))
      '    Case 0 'Blank
      '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_updating = False
      '        Return
      '    Case 28 'F/A
      '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_updating = False
      '        Return
      '    Case 19 'Tool
      '        If e.ProposedValue.ToString.Length = 0 Then
      '            If e.Row(e.Column).ToString.Length <> 0 Then
      '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
      '                    ClearRow(e)
      '                Else
      '                    e.ProposedValue = e.Row(e.Column)
      '                End If
      '            End If
      '            m_updating = False
      '            Return
      '        End If
      '        Dim myTool As New Tool(e.ProposedValue.ToString)
      '        If Not myTool.Originated Then
      '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
      '            e.ProposedValue = e.Row(e.Column)
      '            m_updating = False
      '            Return
      '        Else
      '            Dim myUnit As Unit = myTool.Unit
      '            e.Row("stocki_entity") = myTool.Id
      '            e.ProposedValue = myTool.Code
      '            e.Row("stocki_itemName") = myTool.Name
      '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
      '                e.Row("stocki_unit") = myUnit.Id
      '                e.Row("Unit") = myUnit.Name
      '            Else
      '                e.Row("stocki_unit") = DBNull.Value
      '                e.Row("Unit") = DBNull.Value
      '            End If
      '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
      '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
      '                e.Row("stocki_acct") = ga.Account.Id
      '                e.Row("AccountCode") = ga.Account.Code
      '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
      '            Else
      '                e.Row("stocki_acct") = DBNull.Value
      '                e.Row("AccountCode") = DBNull.Value
      '                e.Row("Account") = DBNull.Value
      '            End If
      '        End If
      '    Case 42 'LCI
      '        If e.ProposedValue.ToString.Length = 0 Then
      '            If e.Row(e.Column).ToString.Length <> 0 Then
      '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
      '                    ClearRow(e)
      '                Else
      '                    e.ProposedValue = e.Row(e.Column)
      '                End If
      '            End If
      '            m_updating = False
      '            Return
      '        End If
      '        Dim lci As New LCIItem(e.ProposedValue.ToString)
      '        If Not lci.Originated Then
      '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
      '            e.ProposedValue = e.Row(e.Column)
      '            m_updating = False
      '            Return
      '        Else
      '            Dim myUnit As Unit = lci.DefaultUnit
      '            e.Row("stocki_entity") = lci.Id
      '            e.ProposedValue = lci.Code
      '            e.Row("stocki_itemName") = lci.Name
      '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
      '                e.Row("stocki_unit") = myUnit.Id
      '                e.Row("Unit") = myUnit.Name
      '            Else
      '                e.Row("stocki_unit") = DBNull.Value
      '                e.Row("Unit") = DBNull.Value
      '            End If
      '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
      '                e.Row("stocki_acct") = lci.Account.Id
      '                e.Row("AccountCode") = lci.Account.Code
      '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
      '            Else
      '                e.Row("stocki_acct") = DBNull.Value
      '                e.Row("AccountCode") = DBNull.Value
      '                e.Row("Account") = DBNull.Value
      '            End If
      '        End If
      '    Case Else
      '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_updating = False
      '        Return
      'End Select
      'e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
      'm_updating = False
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
      OrElse m_entityRefed = 1 _
      OrElse Me.m_entity.Payment.Status.Value = 0 _
      OrElse Me.m_entity.Payment.Status.Value >= 3 _
      Then
        Me.Enabled = False
      Else
        Me.Enabled = True
      End If
      CheckWBSRight()
    End Sub
    Private Sub CheckWBSRight()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(256)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      If Not CBool(checkString.Substring(0, 1)) Then
        'ห้ามเห็น
        Me.lblWBS.Visible = False
        Me.tgWBS.Visible = False
        Me.ibtnAddWBS.Visible = False
        Me.ibtnDelWBS.Visible = False
      ElseIf Not CBool(checkString.Substring(1, 1)) Then
        'ห้ามแก้
        Me.lblWBS.Visible = True
        Me.tgWBS.Visible = True
        Me.ibtnAddWBS.Visible = True
        Me.ibtnDelWBS.Visible = True

        Me.tgWBS.Enabled = False
        Me.ibtnAddWBS.Enabled = False
        Me.ibtnDelWBS.Enabled = False
      Else
        Me.lblWBS.Visible = True
        Me.tgWBS.Visible = True
        Me.ibtnAddWBS.Visible = True
        Me.ibtnDelWBS.Visible = True

        Me.tgWBS.Enabled = True
        Me.ibtnAddWBS.Enabled = True
        Me.ibtnDelWBS.Enabled = True
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      Me.StatusBarService.SetMessage("")
      For Each crlt As Control In Me.grbDelivery.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In Me.grbReceive.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
      cmbTaxType.SelectedIndex = 1
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblNote}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblItem}")
      Me.grbReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.grbReceive}")
      Me.grbDelivery.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.grbDelivery}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblCode}")
      Me.Validator.SetDisplayName(Me.txtCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblDeliveryCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblDeliveryCode}")
      Me.lblDeliveryDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblDeliveryDocDate}")

      Me.lblInvoiceCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblInvoiceCode}")
      Me.Validator.SetDisplayName(Me.txtInvoiceCode, StringHelper.GetRidOfAtEnd(Me.lblInvoiceCode.Text, ":"))

      Me.lblEquipment.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblEquipmentCode}")
      Me.Validator.SetDisplayName(Me.txtEquipmentCode, StringHelper.GetRidOfAtEnd(Me.lblEquipment.Text, ":"))

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblDocDate}")

      Me.lblInvoiceDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblInvoiceDate}")
      Me.Validator.SetDisplayName(Me.txtInvoiceDate, StringHelper.GetRidOfAtEnd(Me.lblInvoiceDate.Text, ":"))

      Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblTaxAmount}")
      Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblAfterTax}")
      Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblDiscountAmount}")
      Me.lblAdvancePay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblAdvancePay}")
      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblBeforeTax}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblGross}")
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblTaxType}")
      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblTaxRate}")
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblTaxBase}")
      Me.lblPercent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblPercent}")

      Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblToCCPerson}")
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, StringHelper.GetRidOfAtEnd(Me.lblToCCPerson.Text, ":"))

      Me.lblToCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblToCostCenter}")
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, StringHelper.GetRidOfAtEnd(Me.lblToCostCenter.Text, ":"))

      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblSupplier}")
      Me.Validator.SetDisplayName(Me.txtSupplierCode, StringHelper.GetRidOfAtEnd(Me.lblSupplier.Text, ":"))

      Me.lblDeliveryPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblDeliveryPerson}")
      Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqMaintenanceDetail.lblCreditPrd}")
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler
      AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPrd.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtDeliveryCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtDeliveryDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDeliveryDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtInvoiceCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtInvoiceDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpInvoiceDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtEquipmentCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToCCPersonCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtToCostCenterCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDeliveryPerson.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealGross.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealGross.Validated, AddressOf Me.TextHandler

    End Sub
    Private m_oldInvoiceCode As String = ""
    Private supplierCodeChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
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
          UpdateAmount(True)
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
          UpdateAmount(True)
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
          UpdateAmount(True)
        Case "txtsuppliercode"
          supplierCodeChanged = True
      End Select
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtCode.Text = m_entity.Code
      txtCreditPrd.Text = m_entity.CreditPeriod.ToString
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      Me.txtDeliveryCode.Text = Me.m_entity.DeliveryDocCode
      txtDeliveryDocDate.Text = MinDateToNull(Me.m_entity.DeliveryDocDate, "")
      dtpDeliveryDocDate.Value = MinDateToNow(Me.m_entity.DeliveryDocDate)

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

      txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetAmount, DigitConfig.Price)

      txtSupplierCode.Text = m_entity.Supplier.Code
      txtSupplierName.Text = m_entity.Supplier.Name
      txtNote.Text = m_entity.Note

      Me.txtDeliveryPerson.Text = Me.m_entity.DeliveryPerson

      txtEquipmentCode.Text = m_entity.Equipment.Code
      txtEquipmentName.Text = m_entity.Equipment.Name

      Me.ChangeEq()

      Me.txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
      txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next

      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      UpdateAmount(True)

      RefreshBlankGrid()

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
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If Me.m_isInitialized AndAlso (e.Name = "ItemChanged" Or e.Name = "QtyChanged") Then
        If e.Name = "QtyChanged" Then
          Me.UpdateAmount(False)
        End If
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
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
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtsuppliercode"
          If supplierCodeChanged Then
            supplierCodeChanged = False
            dirtyFlag = Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
            'พอเปลี่ยน Supplier ให้เคลียร์มัดจำที่เคยเลือกไว้ เพื่อให้เลือกใหม่
            Me.m_entity.AdvancePayItemCollection.Clear()
            Me.UpdateAmount(True)
          End If
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
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtcreditprd"
          Dim crd As Integer = 0
          If txtCreditPrd.Text <> "" Then
            crd = CInt(txtCreditPrd.Text)
          End If
          Me.m_entity.CreditPeriod = crd
          dirtyFlag = True
        Case "txttaxbase"
          'Todo
        Case "txtdiscountrate"
          Me.m_entity.Discount.Rate = txtDiscountRate.Text
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount(True)
          dirtyFlag = True
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Me.m_entity.TaxType.Value = item.Id
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          UpdateAmount(True)
          dirtyFlag = True
        Case "txtdeliverycode"
          Me.m_entity.DeliveryDocCode = txtDeliveryCode.Text
          dirtyFlag = True
        Case "txtdeliverydocdate"
          m_dateSetting = True
          If Not Me.txtDeliveryDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDeliveryDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDeliveryDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDeliveryDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDeliveryDocDate.Value
              dirtyFlag = True
            End If
          Else
            dtpDeliveryDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpdeliverydocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDeliveryDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDeliveryDocDate.Text = MinDateToNull(dtpDeliveryDocDate.Value, "")
              Me.m_entity.DocDate = dtpDeliveryDocDate.Value
            End If
            dirtyFlag = True
          End If
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
        Case "txttoccpersoncode"
          dirtyFlag = Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_entity.ToCostCenterPerson)
        Case "txtequipmentcode"
          dirtyFlag = Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_entity.Equipment)
          If dirtyFlag Then
            ChangeEq()
          End If
        Case "txtdeliveryperson"
          Me.m_entity.DeliveryPerson = txtDeliveryPerson.Text
          dirtyFlag = True
        Case Else
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub ChangeEq()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
      txtToCostCenterName.Text = m_entity.ToCostCenter.Name
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
      txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
      txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
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
        End If
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = CType(Value, EqMaintenance)
        End If
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
      cmbTaxType.SelectedIndex = 1
    End Sub
#End Region

#Region "Event Handler"
    Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddWBS.Click
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'If Me.m_entity Is Nothing Then
      '    Return
      'End If
      'If Me.m_entity.ToCostCenter Is Nothing Then
      '    msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
      '    Return
      'End If
      'If Me.m_entity.ToCostCenter.BoqId = 0 Then
      '    msgServ.ShowMessage("${res:Global.Error.SpecifyCCWithBOQ}")
      '    Return
      'End If
      'Dim tr As TreeRow = Me.m_treeManager.SelectedRow
      'Dim dt As TreeTable = Me.m_treeManager2.Treetable
      'dt.Clear()
      'If tr Is Nothing Then
      '    Return
      'End If
      'If tr.Tag Is Nothing Then
      '    Return
      'End If
      'Dim view As Integer = 45
      'Dim item As New EqMaintenanceItem
      'item.EqMaintenance = Me.m_entity
      'item.CopyFromDataRow(tr)
      'Dim wsdColl As WBSDistributeCollection = CType(tr.Tag, WBSDistributeCollection)
      'If wsdColl.GetSumPercent >= 100 Then
      '    msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
      'ElseIf item.ItemType.Value = 160 Or item.ItemType.Value = 162 Then
      '    msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveWBS}")
      'Else
      '    Dim wbsd As New WBSDistribute
      '    wsdColl.Add(wbsd)
      'End If
      'm_wbsdInitialized = False
      'wsdColl.Populate(dt, item, view)
      'm_wbsdInitialized = True
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelWBS.Click
      'Dim tr As TreeRow = Me.m_treeManager.SelectedRow
      'Dim dt As TreeTable = Me.m_treeManager2.Treetable
      'dt.Clear()
      'If tr Is Nothing Then
      '    Return
      'End If
      'If tr.Tag Is Nothing Then
      '    Return
      'End If
      'Dim item As New EqMaintenanceItem
      'item.EqMaintenance = Me.m_entity
      'item.CopyFromDataRow(tr)
      'Dim wsdColl As WBSDistributeCollection = CType(tr.Tag, WBSDistributeCollection)
      'If wsdColl.Count > 0 Then
      '    wsdColl.Remove(wsdColl.Count - 1)
      '    Me.WorkbenchWindow.ViewContent.IsDirty = True
      'End If
      'Dim view As Integer = 45
      'm_wbsdInitialized = False
      'wsdColl.Populate(dt, item, view)
      'm_wbsdInitialized = True
    End Sub
    Private currentY As Integer
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      If tgItem.CurrentRowIndex <> currentY Then
        RefreshWBS()
        currentY = tgItem.CurrentRowIndex
      End If
    End Sub
    Private Sub RefreshWBS()
      'Dim tr As TreeRow = Me.m_treeManager.SelectedRow
      'Dim dt As TreeTable = Me.m_treeManager2.Treetable
      'dt.Clear()
      'If tr Is Nothing Then
      '    Return
      'End If
      'If tr.Tag Is Nothing Then
      '    Return
      'End If
      'Dim item As New EqMaintenanceItem
      'item.EqMaintenance = Me.m_entity
      'item.CopyFromDataRow(tr)
      'Dim wsdColl As WBSDistributeCollection = CType(tr.Tag, WBSDistributeCollection)
      'Dim view As Integer = 45
      'm_wbsdInitialized = False
      'wsdColl.Populate(dt, item, view)
      'm_wbsdInitialized = True
    End Sub
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
        Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        m_oldCode = Me.txtCode.Text
        Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.MaxRowIndex Then
        Return
      End If
      Dim myItem As New EqMaintenanceItem
      Me.m_entity.Insert(index, myItem)
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If index > Me.m_entity.MaxRowIndex Then
        Return
      End If
      Me.m_entity.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
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
        Return (New EqMaintenance).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Supplier
    Private Sub ibtnShowSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplier.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    Private Sub ibtnShowSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplierDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    End Sub
    Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      'พอเปลี่ยน Supplier ให้เคลียร์มัดจำที่เคยเลือกไว้ เพื่อให้เลือกใหม่
      Me.m_entity.AdvancePayItemCollection.Clear()
      Me.UpdateAmount(True)
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
    End Sub
    ' AdvancePay
    Private Sub ibtnShowAdvancePay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAdvancePay.Click
      Dim dlg As New AdvancePaySelection(Me.m_entity)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        forceUpdateTaxBase = True
        forceUpdateTaxAmount = True
        forceUpdateGross = True
        UpdateAmount(True)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    'Equipment
    Private Sub ibtnShowEquipentDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEquipmentDiaog.Click
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entities As New ArrayList
      Dim eq As New Asset
      entities.Add(eq)
      myEntityPanelService.OpenListDialog(New Asset, AddressOf SetEquipment, entities)
    End Sub
    Private Sub SetEquipment(ByVal e As ISimpleEntity)
      Me.txtEquipmentCode.Text = e.Code
      Dim flag As Boolean = Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_entity.Equipment)
      If flag Then
        Me.ChangeEq()
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or flag
    End Sub
    Private Sub ibtShowEquipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEquipment.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Asset)
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
    End Sub
    Private Sub ibtnShowToCCPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCCPerson.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
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
      Dim maxVisibleCount As Integer
      Dim tgRowHeight As Integer = 17
      maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      Do While Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1
        'เพิ่มแถวจนเต็ม
        Me.m_entity.AddBlankRow(1)
      Loop
      If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
        If Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1 Then
          'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          Me.m_entity.AddBlankRow(1)
        End If
      End If
      Do While Me.m_entity.ItemTable.Childs.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Childs.Count - 2 <> Me.m_entity.MaxRowIndex
        'ลบแถวที่ไม่จำเป็น
        Me.m_entity.Remove(Me.m_entity.ItemTable.Childs.Count - 1)
      Loop
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

  End Class
End Namespace