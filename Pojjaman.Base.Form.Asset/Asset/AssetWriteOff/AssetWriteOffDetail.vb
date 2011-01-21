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
  Public Class AssetWriteOffDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

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
    Friend WithEvents grbDelivery As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceCode As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceCode As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
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
    Friend WithEvents ibtnShowCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCreditPrd As System.Windows.Forms.TextBox
    Friend WithEvents lblCreditPrd As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
    Friend WithEvents ibtnShowCustomer As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents chkAutoRunVat As System.Windows.Forms.CheckBox
    Friend WithEvents grbCostCenter As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
    Friend WithEvents ibtnShowFromCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowFromCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents ibtnShowCCPerson As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtAssetRemain As System.Windows.Forms.TextBox
    Friend WithEvents txtWriteOff As System.Windows.Forms.TextBox
    Friend WithEvents lblWriteOffDepre As System.Windows.Forms.Label
    Friend WithEvents lblAssetRemain As System.Windows.Forms.Label
    Friend WithEvents txtWriteOffDepre As System.Windows.Forms.TextBox
    Friend WithEvents txtProfitLoss As System.Windows.Forms.TextBox
    Friend WithEvents txtCost As System.Windows.Forms.TextBox
    Friend WithEvents lblCost As System.Windows.Forms.Label
    Friend WithEvents lblProfitLoss As System.Windows.Forms.Label
    Friend WithEvents lblWriteOff As System.Windows.Forms.Label
    Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssetWriteOffDetail))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbCostCenter = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnShowFromCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowFromCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtFromCCPersonName = New System.Windows.Forms.TextBox()
      Me.ibtnShowCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox()
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox()
      Me.lblFromCCPerson = New System.Windows.Forms.Label()
      Me.lblFromCostCenter = New System.Windows.Forms.Label()
      Me.grbDelivery = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnShowCustomer = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.lblCreditPrd = New System.Windows.Forms.Label()
      Me.lblDay = New System.Windows.Forms.Label()
      Me.txtCreditPrd = New System.Windows.Forms.TextBox()
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDueDate = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblInvoiceCode = New System.Windows.Forms.Label()
      Me.txtInvoiceCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtInvoiceDate = New System.Windows.Forms.TextBox()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
      Me.txtBeforeTax = New System.Windows.Forms.TextBox()
      Me.txtTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtAfterTax = New System.Windows.Forms.TextBox()
      Me.txtDiscountRate = New System.Windows.Forms.TextBox()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.txtCost = New System.Windows.Forms.TextBox()
      Me.txtProfitLoss = New System.Windows.Forms.TextBox()
      Me.txtWriteOffDepre = New System.Windows.Forms.TextBox()
      Me.txtWriteOff = New System.Windows.Forms.TextBox()
      Me.txtAssetRemain = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
      Me.lblInvoiceDate = New System.Windows.Forms.Label()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblTaxAmount = New System.Windows.Forms.Label()
      Me.lblAfterTax = New System.Windows.Forms.Label()
      Me.lblDiscountAmount = New System.Windows.Forms.Label()
      Me.lblBeforeTax = New System.Windows.Forms.Label()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.lblTaxRate = New System.Windows.Forms.Label()
      Me.lblTaxBase = New System.Windows.Forms.Label()
      Me.lblPercent = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.chkAutoRunVat = New System.Windows.Forms.CheckBox()
      Me.lblWriteOff = New System.Windows.Forms.Label()
      Me.lblProfitLoss = New System.Windows.Forms.Label()
      Me.lblCost = New System.Windows.Forms.Label()
      Me.lblAssetRemain = New System.Windows.Forms.Label()
      Me.lblWriteOffDepre = New System.Windows.Forms.Label()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbCostCenter.SuspendLayout()
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
      Me.tgItem.Location = New System.Drawing.Point(8, 138)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(768, 247)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 18)
      Me.lblCode.TabIndex = 13
      Me.lblCode.Text = "เลขที่ใบส่งของ:"
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
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(112, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(232, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(48, 18)
      Me.lblDocDate.TabIndex = 16
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 113)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 28
      Me.lblItem.Text = "รายการส่งของ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbCostCenter
      '
      Me.grbCostCenter.Controls.Add(Me.ibtnShowFromCostCenter)
      Me.grbCostCenter.Controls.Add(Me.ibtnShowFromCostCenterDialog)
      Me.grbCostCenter.Controls.Add(Me.ibtnShowCCPerson)
      Me.grbCostCenter.Controls.Add(Me.txtFromCCPersonName)
      Me.grbCostCenter.Controls.Add(Me.ibtnShowCCPersonDialog)
      Me.grbCostCenter.Controls.Add(Me.txtFromCCPersonCode)
      Me.grbCostCenter.Controls.Add(Me.txtFromCostCenterName)
      Me.grbCostCenter.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbCostCenter.Controls.Add(Me.lblFromCCPerson)
      Me.grbCostCenter.Controls.Add(Me.lblFromCostCenter)
      Me.grbCostCenter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbCostCenter.Location = New System.Drawing.Point(398, 40)
      Me.grbCostCenter.Name = "grbCostCenter"
      Me.grbCostCenter.Size = New System.Drawing.Size(378, 71)
      Me.grbCostCenter.TabIndex = 7
      Me.grbCostCenter.TabStop = False
      Me.grbCostCenter.Text = "Cost Center จ่ายของ"
      '
      'ibtnShowFromCostCenter
      '
      Me.ibtnShowFromCostCenter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenter.Location = New System.Drawing.Point(345, 15)
      Me.ibtnShowFromCostCenter.Name = "ibtnShowFromCostCenter"
      Me.ibtnShowFromCostCenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCostCenter.TabIndex = 8
      Me.ibtnShowFromCostCenter.TabStop = False
      Me.ibtnShowFromCostCenter.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowFromCostCenterDialog
      '
      Me.ibtnShowFromCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowFromCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowFromCostCenterDialog.Location = New System.Drawing.Point(321, 15)
      Me.ibtnShowFromCostCenterDialog.Name = "ibtnShowFromCostCenterDialog"
      Me.ibtnShowFromCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowFromCostCenterDialog.TabIndex = 6
      Me.ibtnShowFromCostCenterDialog.TabStop = False
      Me.ibtnShowFromCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowCCPerson
      '
      Me.ibtnShowCCPerson.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCCPerson.Location = New System.Drawing.Point(345, 39)
      Me.ibtnShowCCPerson.Name = "ibtnShowCCPerson"
      Me.ibtnShowCCPerson.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCCPerson.TabIndex = 9
      Me.ibtnShowCCPerson.TabStop = False
      Me.ibtnShowCCPerson.ThemedImage = CType(resources.GetObject("ibtnShowCCPerson.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtFromCCPersonName
      '
      Me.txtFromCCPersonName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtFromCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(166, 40)
      Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(155, 20)
      Me.txtFromCCPersonName.TabIndex = 5
      Me.txtFromCCPersonName.TabStop = False
      '
      'ibtnShowCCPersonDialog
      '
      Me.ibtnShowCCPersonDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCCPersonDialog.Location = New System.Drawing.Point(321, 39)
      Me.ibtnShowCCPersonDialog.Name = "ibtnShowCCPersonDialog"
      Me.ibtnShowCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCCPersonDialog.TabIndex = 7
      Me.ibtnShowCCPersonDialog.TabStop = False
      Me.ibtnShowCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtFromCCPersonCode
      '
      Me.txtFromCCPersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(74, 40)
      Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonCode, True)
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(91, 20)
      Me.txtFromCCPersonCode.TabIndex = 1
      '
      'txtFromCostCenterName
      '
      Me.txtFromCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(166, 16)
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(155, 20)
      Me.txtFromCostCenterName.TabIndex = 4
      Me.txtFromCostCenterName.TabStop = False
      '
      'txtFromCostCenterCode
      '
      Me.txtFromCostCenterCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(74, 16)
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, True)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(91, 20)
      Me.txtFromCostCenterCode.TabIndex = 0
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.Location = New System.Drawing.Point(5, 40)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(67, 18)
      Me.lblFromCCPerson.TabIndex = 3
      Me.lblFromCCPerson.Text = "ผู้จ่ายของ:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.Location = New System.Drawing.Point(5, 16)
      Me.lblFromCostCenter.Name = "lblFromCostCenter"
      Me.lblFromCostCenter.Size = New System.Drawing.Size(67, 18)
      Me.lblFromCostCenter.TabIndex = 2
      Me.lblFromCostCenter.Text = "จาก CC:"
      Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDelivery
      '
      Me.grbDelivery.Controls.Add(Me.ibtnShowCustomer)
      Me.grbDelivery.Controls.Add(Me.txtCustomerName)
      Me.grbDelivery.Controls.Add(Me.ibtnShowCustomerDialog)
      Me.grbDelivery.Controls.Add(Me.lblCustomer)
      Me.grbDelivery.Controls.Add(Me.txtCustomerCode)
      Me.grbDelivery.Controls.Add(Me.lblCreditPrd)
      Me.grbDelivery.Controls.Add(Me.lblDay)
      Me.grbDelivery.Controls.Add(Me.txtCreditPrd)
      Me.grbDelivery.Controls.Add(Me.dtpDueDate)
      Me.grbDelivery.Controls.Add(Me.lblDueDate)
      Me.grbDelivery.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDelivery.Location = New System.Drawing.Point(8, 40)
      Me.grbDelivery.Name = "grbDelivery"
      Me.grbDelivery.Size = New System.Drawing.Size(384, 71)
      Me.grbDelivery.TabIndex = 6
      Me.grbDelivery.TabStop = False
      Me.grbDelivery.Text = "ส่งของให้"
      '
      'ibtnShowCustomer
      '
      Me.ibtnShowCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomer.Location = New System.Drawing.Point(352, 16)
      Me.ibtnShowCustomer.Name = "ibtnShowCustomer"
      Me.ibtnShowCustomer.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomer.TabIndex = 9
      Me.ibtnShowCustomer.TabStop = False
      Me.ibtnShowCustomer.ThemedImage = CType(resources.GetObject("ibtnShowCustomer.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(180, 16)
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(148, 20)
      Me.txtCustomerName.TabIndex = 5
      Me.txtCustomerName.TabStop = False
      '
      'ibtnShowCustomerDialog
      '
      Me.ibtnShowCustomerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(328, 16)
      Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
      Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomerDialog.TabIndex = 8
      Me.ibtnShowCustomerDialog.TabStop = False
      Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.Location = New System.Drawing.Point(8, 16)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(80, 18)
      Me.lblCustomer.TabIndex = 3
      Me.lblCustomer.Text = "ลูกค้า:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustomerCode
      '
      Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(88, 16)
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      'Me.Validator.SetRequired(Me.txtCustomerCode, True)
      Me.txtCustomerCode.Size = New System.Drawing.Size(91, 20)
      Me.txtCustomerCode.TabIndex = 0
      '
      'lblCreditPrd
      '
      Me.lblCreditPrd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCreditPrd.Location = New System.Drawing.Point(8, 40)
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
      Me.lblDay.Location = New System.Drawing.Point(152, 42)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(19, 13)
      Me.lblDay.TabIndex = 6
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
      Me.txtCreditPrd.Location = New System.Drawing.Point(88, 40)
      Me.Validator.SetMinValue(Me.txtCreditPrd, "0")
      Me.txtCreditPrd.Name = "txtCreditPrd"
      Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
      Me.Validator.SetRequired(Me.txtCreditPrd, False)
      Me.txtCreditPrd.Size = New System.Drawing.Size(64, 20)
      Me.txtCreditPrd.TabIndex = 1
      '
      'dtpDueDate
      '
      Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDueDate.Enabled = False
      Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDueDate.Location = New System.Drawing.Point(279, 40)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDueDate.TabIndex = 2
      Me.dtpDueDate.TabStop = False
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.ForeColor = System.Drawing.Color.Black
      Me.lblDueDate.Location = New System.Drawing.Point(198, 41)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(80, 18)
      Me.lblDueDate.TabIndex = 7
      Me.lblDueDate.Text = "กำหนดชำระ:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(96, 391)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(160, 39)
      Me.txtNote.TabIndex = 9
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(40, 390)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(56, 18)
      Me.lblNote.TabIndex = 26
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInvoiceCode
      '
      Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceCode.Location = New System.Drawing.Point(400, 16)
      Me.lblInvoiceCode.Name = "lblInvoiceCode"
      Me.lblInvoiceCode.Size = New System.Drawing.Size(104, 18)
      Me.lblInvoiceCode.TabIndex = 20
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
      Me.txtInvoiceCode.Location = New System.Drawing.Point(504, 16)
      Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
      Me.txtInvoiceCode.Name = "txtInvoiceCode"
      Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
      Me.Validator.SetRequired(Me.txtInvoiceCode, False)
      Me.txtInvoiceCode.Size = New System.Drawing.Size(112, 21)
      Me.txtInvoiceCode.TabIndex = 4
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
      Me.txtDocDate.Location = New System.Drawing.Point(280, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDocDate.TabIndex = 1
      '
      'txtInvoiceDate
      '
      Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.txtInvoiceDate.Location = New System.Drawing.Point(678, 16)
      Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
      Me.txtInvoiceDate.Name = "txtInvoiceDate"
      Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
      Me.Validator.SetRequired(Me.txtInvoiceDate, False)
      Me.txtInvoiceDate.Size = New System.Drawing.Size(78, 20)
      Me.txtInvoiceDate.TabIndex = 5
      '
      'txtGross
      '
      Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtGross.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(416, 390)
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(114, 20)
      Me.txtGross.TabIndex = 31
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
      Me.txtDiscountAmount.Location = New System.Drawing.Point(416, 410)
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.txtDiscountAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(114, 20)
      Me.txtDiscountAmount.TabIndex = 32
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
      Me.txtBeforeTax.Location = New System.Drawing.Point(416, 430)
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(114, 20)
      Me.txtBeforeTax.TabIndex = 33
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
      Me.txtTaxAmount.Location = New System.Drawing.Point(416, 470)
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(114, 20)
      Me.txtTaxAmount.TabIndex = 35
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
      Me.txtAfterTax.Location = New System.Drawing.Point(416, 490)
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(114, 20)
      Me.txtAfterTax.TabIndex = 36
      Me.txtAfterTax.TabStop = False
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
      Me.txtDiscountRate.Location = New System.Drawing.Point(320, 410)
      Me.Validator.SetMinValue(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Name = "txtDiscountRate"
      Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
      Me.Validator.SetRequired(Me.txtDiscountRate, False)
      Me.txtDiscountRate.Size = New System.Drawing.Size(88, 20)
      Me.txtDiscountRate.TabIndex = 10
      '
      'txtTaxRate
      '
      Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(286, 470)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, True)
      Me.txtTaxRate.Size = New System.Drawing.Size(32, 20)
      Me.txtTaxRate.TabIndex = 40
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
      Me.txtTaxBase.Location = New System.Drawing.Point(416, 450)
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(114, 20)
      Me.txtTaxBase.TabIndex = 34
      Me.txtTaxBase.TabStop = False
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCost
      '
      Me.txtCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCost.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCost, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCost, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCost, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCost, System.Drawing.Color.Empty)
      Me.txtCost.Location = New System.Drawing.Point(660, 451)
      Me.Validator.SetMinValue(Me.txtCost, "")
      Me.txtCost.Name = "txtCost"
      Me.txtCost.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCost, "")
      Me.Validator.SetRequired(Me.txtCost, False)
      Me.txtCost.Size = New System.Drawing.Size(114, 20)
      Me.txtCost.TabIndex = 34
      Me.txtCost.TabStop = False
      Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtProfitLoss
      '
      Me.txtProfitLoss.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtProfitLoss.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtProfitLoss, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProfitLoss, "")
      Me.txtProfitLoss.ForeColor = System.Drawing.Color.Blue
      Me.Validator.SetGotFocusBackColor(Me.txtProfitLoss, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProfitLoss, System.Drawing.Color.Empty)
      Me.txtProfitLoss.Location = New System.Drawing.Point(660, 471)
      Me.Validator.SetMinValue(Me.txtProfitLoss, "")
      Me.txtProfitLoss.Name = "txtProfitLoss"
      Me.txtProfitLoss.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProfitLoss, "")
      Me.Validator.SetRequired(Me.txtProfitLoss, False)
      Me.txtProfitLoss.Size = New System.Drawing.Size(114, 20)
      Me.txtProfitLoss.TabIndex = 35
      Me.txtProfitLoss.TabStop = False
      Me.txtProfitLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtWriteOffDepre
      '
      Me.txtWriteOffDepre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtWriteOffDepre.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtWriteOffDepre, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWriteOffDepre, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWriteOffDepre, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWriteOffDepre, System.Drawing.Color.Empty)
      Me.txtWriteOffDepre.Location = New System.Drawing.Point(660, 431)
      Me.Validator.SetMinValue(Me.txtWriteOffDepre, "")
      Me.txtWriteOffDepre.Name = "txtWriteOffDepre"
      Me.txtWriteOffDepre.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWriteOffDepre, "")
      Me.Validator.SetRequired(Me.txtWriteOffDepre, False)
      Me.txtWriteOffDepre.Size = New System.Drawing.Size(114, 20)
      Me.txtWriteOffDepre.TabIndex = 33
      Me.txtWriteOffDepre.TabStop = False
      Me.txtWriteOffDepre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtWriteOff
      '
      Me.txtWriteOff.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtWriteOff.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtWriteOff, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWriteOff, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWriteOff, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWriteOff, System.Drawing.Color.Empty)
      Me.txtWriteOff.Location = New System.Drawing.Point(660, 411)
      Me.Validator.SetMinValue(Me.txtWriteOff, "")
      Me.txtWriteOff.Name = "txtWriteOff"
      Me.txtWriteOff.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWriteOff, "")
      Me.Validator.SetRequired(Me.txtWriteOff, False)
      Me.txtWriteOff.Size = New System.Drawing.Size(114, 20)
      Me.txtWriteOff.TabIndex = 32
      Me.txtWriteOff.TabStop = False
      Me.txtWriteOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAssetRemain
      '
      Me.txtAssetRemain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAssetRemain.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAssetRemain, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetRemain, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAssetRemain, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAssetRemain, System.Drawing.Color.Empty)
      Me.txtAssetRemain.Location = New System.Drawing.Point(660, 391)
      Me.Validator.SetMinValue(Me.txtAssetRemain, "")
      Me.txtAssetRemain.Name = "txtAssetRemain"
      Me.txtAssetRemain.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAssetRemain, "")
      Me.Validator.SetRequired(Me.txtAssetRemain, False)
      Me.txtAssetRemain.Size = New System.Drawing.Size(114, 20)
      Me.txtAssetRemain.TabIndex = 31
      Me.txtAssetRemain.TabStop = False
      Me.txtAssetRemain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(280, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDocDate.TabIndex = 18
      Me.dtpDocDate.TabStop = False
      '
      'dtpInvoiceDate
      '
      Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpInvoiceDate.Location = New System.Drawing.Point(678, 16)
      Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
      Me.dtpInvoiceDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpInvoiceDate.TabIndex = 23
      Me.dtpInvoiceDate.TabStop = False
      '
      'lblInvoiceDate
      '
      Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceDate.Location = New System.Drawing.Point(646, 16)
      Me.lblInvoiceDate.Name = "lblInvoiceDate"
      Me.lblInvoiceDate.Size = New System.Drawing.Size(32, 18)
      Me.lblInvoiceDate.TabIndex = 22
      Me.lblInvoiceDate.Text = "วันที่:"
      Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(121, 112)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 24
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtnBlank.Visible = False
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(96, 112)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 25
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(336, 471)
      Me.lblTaxAmount.Name = "lblTaxAmount"
      Me.lblTaxAmount.Size = New System.Drawing.Size(80, 18)
      Me.lblTaxAmount.TabIndex = 37
      Me.lblTaxAmount.Text = "ภาษีมูลค่าเพิ่ม :"
      Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAfterTax
      '
      Me.lblAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAfterTax.BackColor = System.Drawing.Color.Transparent
      Me.lblAfterTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAfterTax.Location = New System.Drawing.Point(280, 491)
      Me.lblAfterTax.Name = "lblAfterTax"
      Me.lblAfterTax.Size = New System.Drawing.Size(136, 18)
      Me.lblAfterTax.TabIndex = 41
      Me.lblAfterTax.Text = "ยอดสุทธิ :"
      Me.lblAfterTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDiscountAmount
      '
      Me.lblDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscountAmount.Location = New System.Drawing.Point(262, 411)
      Me.lblDiscountAmount.Name = "lblDiscountAmount"
      Me.lblDiscountAmount.Size = New System.Drawing.Size(58, 18)
      Me.lblDiscountAmount.TabIndex = 29
      Me.lblDiscountAmount.Text = "ส่วนลด :"
      Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(287, 431)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(129, 18)
      Me.lblBeforeTax.TabIndex = 43
      Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
      Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGross.BackColor = System.Drawing.Color.Transparent
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(336, 391)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(80, 18)
      Me.lblGross.TabIndex = 30
      Me.lblGross.Text = "ยอดเงินรวม :"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbTaxType
      '
      Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(168, 470)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(59, 21)
      Me.cmbTaxType.TabIndex = 11
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(80, 471)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(88, 18)
      Me.lblTaxType.TabIndex = 27
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(229, 471)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(58, 18)
      Me.lblTaxRate.TabIndex = 42
      Me.lblTaxRate.Text = "อัตราภาษี :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxBase
      '
      Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.Location = New System.Drawing.Point(283, 451)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(133, 18)
      Me.lblTaxBase.TabIndex = 39
      Me.lblTaxBase.Text = "ฐานภาษี :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPercent
      '
      Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPercent.AutoSize = True
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(319, 475)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(18, 13)
      Me.lblPercent.TabIndex = 38
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(208, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 15
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'chkAutoRunVat
      '
      Me.chkAutoRunVat.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutoRunVat.Image = CType(resources.GetObject("chkAutoRunVat.Image"), System.Drawing.Image)
      Me.chkAutoRunVat.Location = New System.Drawing.Point(616, 16)
      Me.chkAutoRunVat.Name = "chkAutoRunVat"
      Me.chkAutoRunVat.Size = New System.Drawing.Size(21, 21)
      Me.chkAutoRunVat.TabIndex = 21
      '
      'lblWriteOff
      '
      Me.lblWriteOff.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblWriteOff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWriteOff.Location = New System.Drawing.Point(543, 412)
      Me.lblWriteOff.Name = "lblWriteOff"
      Me.lblWriteOff.Size = New System.Drawing.Size(117, 18)
      Me.lblWriteOff.TabIndex = 29
      Me.lblWriteOff.Text = "มูลค่า Write Off :"
      Me.lblWriteOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblProfitLoss
      '
      Me.lblProfitLoss.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblProfitLoss.BackColor = System.Drawing.Color.Transparent
      Me.lblProfitLoss.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProfitLoss.Location = New System.Drawing.Point(580, 472)
      Me.lblProfitLoss.Name = "lblProfitLoss"
      Me.lblProfitLoss.Size = New System.Drawing.Size(80, 18)
      Me.lblProfitLoss.TabIndex = 37
      Me.lblProfitLoss.Text = "กำไร/ขาดทุน :"
      Me.lblProfitLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCost
      '
      Me.lblCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCost.BackColor = System.Drawing.Color.Transparent
      Me.lblCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCost.Location = New System.Drawing.Point(557, 452)
      Me.lblCost.Name = "lblCost"
      Me.lblCost.Size = New System.Drawing.Size(103, 18)
      Me.lblCost.TabIndex = 39
      Me.lblCost.Text = "ต้นทุนขาย :"
      Me.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAssetRemain
      '
      Me.lblAssetRemain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAssetRemain.BackColor = System.Drawing.Color.Transparent
      Me.lblAssetRemain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetRemain.Location = New System.Drawing.Point(543, 392)
      Me.lblAssetRemain.Name = "lblAssetRemain"
      Me.lblAssetRemain.Size = New System.Drawing.Size(117, 18)
      Me.lblAssetRemain.TabIndex = 30
      Me.lblAssetRemain.Text = "มูลค่าสินทรัพย์คงเหลือ :"
      Me.lblAssetRemain.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblWriteOffDepre
      '
      Me.lblWriteOffDepre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblWriteOffDepre.BackColor = System.Drawing.Color.Transparent
      Me.lblWriteOffDepre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWriteOffDepre.Location = New System.Drawing.Point(534, 432)
      Me.lblWriteOffDepre.Name = "lblWriteOffDepre"
      Me.lblWriteOffDepre.Size = New System.Drawing.Size(126, 18)
      Me.lblWriteOffDepre.TabIndex = 43
      Me.lblWriteOffDepre.Text = "ค่าเสื่อมสะสม Write Off :"
      Me.lblWriteOffDepre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'AssetWriteOffDetail
      '
      Me.Controls.Add(Me.chkAutoRunVat)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.lblPercent)
      Me.Controls.Add(Me.txtAssetRemain)
      Me.Controls.Add(Me.txtWriteOff)
      Me.Controls.Add(Me.txtGross)
      Me.Controls.Add(Me.lblWriteOffDepre)
      Me.Controls.Add(Me.txtDiscountAmount)
      Me.Controls.Add(Me.lblAssetRemain)
      Me.Controls.Add(Me.lblBeforeTax)
      Me.Controls.Add(Me.txtWriteOffDepre)
      Me.Controls.Add(Me.lblGross)
      Me.Controls.Add(Me.txtProfitLoss)
      Me.Controls.Add(Me.txtBeforeTax)
      Me.Controls.Add(Me.txtTaxAmount)
      Me.Controls.Add(Me.txtAfterTax)
      Me.Controls.Add(Me.txtDiscountRate)
      Me.Controls.Add(Me.cmbTaxType)
      Me.Controls.Add(Me.lblTaxType)
      Me.Controls.Add(Me.txtTaxRate)
      Me.Controls.Add(Me.txtCost)
      Me.Controls.Add(Me.lblTaxRate)
      Me.Controls.Add(Me.lblCost)
      Me.Controls.Add(Me.txtTaxBase)
      Me.Controls.Add(Me.lblTaxBase)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.lblAfterTax)
      Me.Controls.Add(Me.txtDocDate)
      Me.Controls.Add(Me.dtpDocDate)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.grbCostCenter)
      Me.Controls.Add(Me.grbDelivery)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.txtCode)
      Me.Controls.Add(Me.lblDocDate)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblInvoiceCode)
      Me.Controls.Add(Me.txtInvoiceCode)
      Me.Controls.Add(Me.lblInvoiceDate)
      Me.Controls.Add(Me.txtInvoiceDate)
      Me.Controls.Add(Me.lblProfitLoss)
      Me.Controls.Add(Me.dtpInvoiceDate)
      Me.Controls.Add(Me.lblWriteOff)
      Me.Controls.Add(Me.lblTaxAmount)
      Me.Controls.Add(Me.lblDiscountAmount)
      Me.Name = "AssetWriteOffDetail"
      Me.Size = New System.Drawing.Size(784, 520)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbCostCenter.ResumeLayout(False)
      Me.grbCostCenter.PerformLayout()
      Me.grbDelivery.ResumeLayout(False)
      Me.grbDelivery.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteoffDetail.lblNote}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.lblItem}")
      Me.grbDelivery.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.grbDelivery}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblInvoiceCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblInvoiceCode}")
      Me.Validator.SetDisplayName(txtInvoiceCode, lblInvoiceCode.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblDocDate}")
      Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

      Me.lblInvoiceDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblInvoiceDate}")
      Me.Validator.SetDisplayName(txtInvoiceDate, lblInvoiceDate.Text)

      Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblTaxAmount}")
      Me.Validator.SetDisplayName(txtTaxAmount, lblTaxAmount.Text)

      Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblAfterTax}")
      Me.Validator.SetDisplayName(txtAfterTax, lblAfterTax.Text)

      Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblDiscountAmount}")
      Me.Validator.SetDisplayName(txtDiscountAmount, lblDiscountAmount.Text)

      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblBeforeTax}")
      Me.Validator.SetDisplayName(txtBeforeTax, lblBeforeTax.Text)

      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblGross}")
      Me.Validator.SetDisplayName(txtGross, lblGross.Text)

      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblTaxType}")

      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblTaxRate}")
      Me.Validator.SetDisplayName(txtTaxRate, lblTaxRate.Text)

      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblTaxBase}")
      Me.Validator.SetDisplayName(txtTaxBase, lblTaxBase.Text)

      Me.lblPercent.Text = Me.StringParserService.Parse("${res:Global.PercenText}")
      Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblCreditPrd}")
      Me.Validator.SetDisplayName(txtCreditPrd, lblCreditPrd.Text)

      Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")
      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblFromCostCenter}")
      Me.Validator.SetDisplayName(txtFromCostCenterCode, lblFromCostCenter.Text)

      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblCustomer}")
      Me.Validator.SetDisplayName(txtCustomerCode, lblCustomer.Text)

      Me.grbCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.grbCostCenter}")
      Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblFromCCPerson}")
      Me.Validator.SetDisplayName(txtFromCCPersonCode, lblFromCCPerson.Text)

      'Me.lblPoDocCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblPoDocCode}")
      'Me.Validator.SetDisplayName(txtPoDocCode, lblPoDocCode.Text)

      'Me.lblPoDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblPoDocDate}")
      'Me.Validator.SetDisplayName(txtPoDocDate, lblPoDocDate.Text)

      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblDueDate}")

      Me.lblAssetRemain.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblAssetRemain}")
      Me.lblWriteOff.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblWriteOff}")
      Me.lblWriteOffDepre.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblWriteOffDepre}")
      Me.lblCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblCost}")
      Me.lblProfitLoss.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblProfitLoss}")

    End Sub
#End Region

#Region "Members"
    Private m_entity As AssetWriteOff
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_tableStyleEnable As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = AssetWriteOff.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged

      EventWiring()
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As AssetWriteOffItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is AssetWriteOffItem Then
          Return Nothing
        End If
        Return CType(row.Tag, AssetWriteOffItem)
      End Get
    End Property
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "AssetWriteoff"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'Stock Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "LineNumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:#}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 15
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "LineNumber"

      Dim csType As New TreeTextColumn
      csType.MappingName = "Type"
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.TypeHeaderText}")
      csType.NullText = ""
      csType.Width = 60
      csType.ReadOnly = True
      csType.TextBox.Name = "Type"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      csButton.Width = 15
      AddHandler csButton.Click, AddressOf ButtonClick

      Dim csName As New TreeTextColumn
      csName.MappingName = "Description"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 150
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.Width = 40
      csUnit.TextBox.Name = "Unit"
      csUnit.ReadOnly = True
      csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csRemainBuyQty As New TreeTextColumn
      csRemainBuyQty.MappingName = "RemainingQty"
      csRemainBuyQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.RemainingQtyHeaderText}")
      csRemainBuyQty.NullText = ""
      csRemainBuyQty.Format = "#,###"
      csRemainBuyQty.TextBox.Name = "RemainingQty"
      csRemainBuyQty.ReadOnly = True
      csRemainBuyQty.Width = 70
      csRemainBuyQty.DataAlignment = HorizontalAlignment.Right

      Dim csBuyPrice As New TreeTextColumn
      csBuyPrice.MappingName = "BuyPrice"
      'csBuyPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.UnitAsstAmtHeaderText}")
      csBuyPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.BuyPriceHeaderText}")
      csBuyPrice.NullText = ""
      csBuyPrice.TextBox.Name = "BuyPrice"
      csBuyPrice.Format = "#,###.##"
      csBuyPrice.ReadOnly = True
      csBuyPrice.Width = 90
      csBuyPrice.DataAlignment = HorizontalAlignment.Right

      Dim csAssetAmount As New TreeTextColumn
      csAssetAmount.MappingName = "AssetAmount"
      'csaccdepre.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.AccDepreHeaderText}")
      csAssetAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.AssetAmountHeaderText}")
      csAssetAmount.NullText = ""
      csAssetAmount.TextBox.Name = "AssetAmount"
      csAssetAmount.Format = "#,###.##"
      csAssetAmount.ReadOnly = True
      csAssetAmount.Width = 90
      csAssetAmount.DataAlignment = HorizontalAlignment.Right

      Dim csaccdepre As New TreeTextColumn
      csaccdepre.MappingName = "DepreAmount"
      'csaccdepre.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.AccDepreHeaderText}")
      csaccdepre.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.DepreAmountHeaderText}")
      csaccdepre.NullText = ""
      csaccdepre.TextBox.Name = "DepreAmount"
      csaccdepre.Format = "#,###.##"
      csaccdepre.ReadOnly = True
      csaccdepre.Width = 90
      csaccdepre.DataAlignment = HorizontalAlignment.Right

      Dim csAssetRemainAmount As New TreeTextColumn
      csAssetRemainAmount.MappingName = "RemainingAmount"
      'csAssetRemainAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.AssetAmtHeaderText}")
      csAssetRemainAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.RemainingAmountHeaderText}")
      csAssetRemainAmount.NullText = ""
      csAssetRemainAmount.TextBox.Name = "RemainingAmount"
      csAssetRemainAmount.Format = "#,###.##"
      csAssetRemainAmount.ReadOnly = True
      csAssetRemainAmount.Width = 90
      csAssetRemainAmount.DataAlignment = HorizontalAlignment.Right

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "Qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.QtyHeaderText}")
      csQty.NullText = ""
      csQty.Format = "#,###"
      csQty.TextBox.Name = "Qty"
      csQty.Width = 60
      csQty.ReadOnly = False
      csQty.DataAlignment = HorizontalAlignment.Right

      'Dim csStockQty As New TreeTextColumn
      'csStockQty.MappingName = "StockQty"
      'csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.StockQtyHeaderText}")
      'csStockQty.NullText = ""
      'csStockQty.Format = "#,###.##"
      'csStockQty.ReadOnly = True
      'csStockQty.DataAlignment = HorizontalAlignment.Right

      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "UnitPrice"
      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnitpriceHeaderText}")
      csUnitPRice.NullText = ""
      csUnitPRice.TextBox.Name = "UnitPrice"
      csUnitPRice.Format = "#,###.##"
      csUnitPRice.Width = 90
      csUnitPRice.ReadOnly = False
      csUnitPRice.DataAlignment = HorizontalAlignment.Right


      'Dim csDiscount As New TreeTextColumn
      'csDiscount.MappingName = "stocki_discrate"
      'csDiscount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.DiscountHeaderText}")
      'csDiscount.NullText = ""
      'csDiscount.TextBox.Name = "stocki_discrate"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"
      csAmount.Width = 90
      csAmount.DataAlignment = HorizontalAlignment.Right

      Dim cswriteoffamount As New TreeTextColumn
      cswriteoffamount.MappingName = "WriteOffAmount"
      'cswriteoffamount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.WFAmtHeaderText}")
      cswriteoffamount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.WriteOffAmountHeaderText}")
      cswriteoffamount.NullText = ""
      cswriteoffamount.TextBox.Name = "WriteOffAmount"
      cswriteoffamount.Format = "#,###.##"
      'cswriteoffamount.ReadOnly = True
      cswriteoffamount.Width = 90
      cswriteoffamount.DataAlignment = HorizontalAlignment.Right

      Dim csBarrier2 As New DataGridBarrierColumn
      csBarrier2.MappingName = "Barrier2"
      csBarrier2.HeaderText = ""
      csBarrier2.NullText = ""
      csBarrier2.ReadOnly = True

      Dim csWriteOffDepreAmount As New TreeTextColumn
      csWriteOffDepreAmount.MappingName = "WriteOffDepreAmount"
      'csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.CostHeaderText}")
      csWriteOffDepreAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.WriteOffDepreAmountHeaderText}")
      csWriteOffDepreAmount.NullText = ""
      csWriteOffDepreAmount.TextBox.Name = "WriteOffDepreAmount"
      csWriteOffDepreAmount.Format = "#,###.##"
      csWriteOffDepreAmount.ReadOnly = True
      csWriteOffDepreAmount.Width = 90
      csWriteOffDepreAmount.DataAlignment = HorizontalAlignment.Right

      Dim csCost As New TreeTextColumn
      csCost.MappingName = "CostAmount"
      'csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.CostHeaderText}")
      csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.CostAmountHeaderText}")
      csCost.NullText = ""
      csCost.TextBox.Name = "CostAmount"
      csCost.Format = "#,###.##"
      csCost.ReadOnly = True
      csCost.Width = 90
      csCost.DataAlignment = HorizontalAlignment.Right

      Dim csPL As New TreeTextColumn
      csPL.MappingName = "P/L"
      csPL.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWriteOffDetail.PLHeaderText}")
      csPL.NullText = ""
      csPL.TextBox.Name = "P/L"
      csPL.Format = "#,###.##"
      csPL.ReadOnly = True
      csPL.Width = 90
      csPL.DataAlignment = HorizontalAlignment.Right

      'Dim csDepre As New TreeTextColumn
      'csDepre.MappingName = "deprecalcamt"
      'csDepre.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.DeprecalcHeaderText}")
      'csDepre.NullText = ""
      'csDepre.TextBox.Name = "deprecalcamt"
      'csDepre.ReadOnly = True
      'csDepre.Format = "#,###.##"
      'csDepre.DataAlignment = HorizontalAlignment.Right

      'Dim csAccountCode As New TreeTextColumn
      'csAccountCode.MappingName = "AccountCode"
      'csAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AccountCodeHeaderText}")
      'csAccountCode.NullText = ""
      'csAccountCode.TextBox.Name = "AccountCode"

      'Dim csAccount As New TreeTextColumn
      'csAccount.MappingName = "Account"
      'csAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AccountHeaderText}")
      'csAccount.NullText = ""
      'csAccount.ReadOnly = True
      'csAccount.TextBox.Name = "Account"

      'Dim csAccountButton As New DataGridButtonColumn
      'csAccountButton.MappingName = "AccountButton"
      'csAccountButton.HeaderText = ""
      'csAccountButton.NullText = ""
      'AddHandler csAccountButton.Click, AddressOf ButtonClick

      'Dim csVatable As New DataGridCheckBoxColumn
      'csVatable.MappingName = "stocki_unvatable"
      'csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnVatableHeaderText}")
      'csVatable.Width = 100
      'csVatable.ReadOnly = True
      'csVatable.InvisibleWhenUnspcified = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "Note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csRemainBuyQty)
      dst.GridColumnStyles.Add(csBuyPrice)
      dst.GridColumnStyles.Add(csAssetAmount)
      dst.GridColumnStyles.Add(csaccdepre)
      dst.GridColumnStyles.Add(csAssetRemainAmount)

      dst.GridColumnStyles.Add(csBarrier1)

      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csUnitPRice)
      'dst.GridColumnStyles.Add(csDiscount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(cswriteoffamount)

      dst.GridColumnStyles.Add(csBarrier2)
      dst.GridColumnStyles.Add(csWriteOffDepreAmount)
      dst.GridColumnStyles.Add(csCost)
      dst.GridColumnStyles.Add(csPL)
      'dst.GridColumnStyles.Add(csDepre)
      'dst.GridColumnStyles.Add(csAccountCode)
      'dst.GridColumnStyles.Add(csAccountButton)
      'dst.GridColumnStyles.Add(csAccount)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Public Sub ButtonClick(ByVal e As ButtonColumnEventArgs)
      If e.Column = 3 Then
        Me.ItemButtonClick(e)
      Else
        Me.AcctButtonClick(e)
      End If
    End Sub
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
        Return
      End If
      Dim doc As AssetWriteOffItem = Me.CurrentItem
      If Not doc Is Nothing Then
        doc.ItemValidateRow(e.Row)
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" _
        OrElse e.Column.ColumnName.ToLower = "linenumber" Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As AssetWriteOffItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New AssetWriteOffItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          'Case "code"
          '  If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
          '    e.ProposedValue = ""
          '  End If
          '  doc.SetItemCode(CStr(e.ProposedValue))
          Case "writeoffamount"
            If Not doc.HasChild AndAlso doc.ItemType.Value = 28 Then
              Dim value As Decimal = CDec(e.ProposedValue)
              If doc.CalcWriteOffAmt >= value Then
                doc.WriteOffAmount = CDec(e.ProposedValue)
              Else
                e.ProposedValue = doc.CalcWriteOffAmt
              End If
            Else
              e.ProposedValue = doc.WriteOffAmount
            End If
          Case "qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0
            If IsNumeric(e.ProposedValue) Then
              value = Math.Ceiling(CDec(TextParser.Evaluate(e.ProposedValue)))
            End If
            doc.Qty = value
            Me.m_entity.RefreshSummaryParent()
          Case "unitprice"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0
            If IsNumeric(e.ProposedValue) Then
              value = CDec(TextParser.Evaluate(e.ProposedValue))
            End If
            doc.UnitPrice = value
            Me.m_entity.RefreshSummaryParent()
          Case "note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
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
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = True
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
      If Me.m_entity.Itemcollection.Count > 0 Then
        Me.dtpDocDate.Enabled = False
        Me.txtDocDate.ReadOnly = True
      Else
        Me.dtpDocDate.Enabled = True
        Me.txtDocDate.ReadOnly = False
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      Me.StatusBarService.SetMessage("")
      For Each crlt As Control In Me.grbDelivery.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In Me.grbCostCenter.Controls
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

    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPrd.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      'AddHandler txtPoDocCode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtPoDocDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpPoDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtInvoiceCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtInvoiceDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpInvoiceDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtFromCCPersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtFromCostCenterCode.Validated, AddressOf Me.ChangeProperty


    End Sub
    Private m_oldInvoiceCode As String = ""
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

      'Me.txtPoDocCode.Text = Me.m_entity.PoDocCode
      'txtPoDocDate.Text = MinDateToNull(Me.m_entity.PoDocDate, "")
      'dtpPoDocDate.Value = MinDateToNow(Me.m_entity.PoDocDate)

      Dim myVat As Vat = Me.m_entity.Vat
      If Not myVat Is Nothing Then
        Dim myVatitem As VatItem
        If myVat.ItemCollection.Count <= 0 Then
          Me.m_entity.Vat.ItemCollection.Add(New VatItem)
        End If
        VatInputEnabled(True)
        myVatitem = myVat.ItemCollection(0)
        If myVat.AutoGen Then
          Me.txtInvoiceCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(myVatitem.EntityId)
        Else
          Me.txtInvoiceCode.Text = myVatitem.Code
        End If
        Me.txtInvoiceDate.Text = MinDateToNull(myVatitem.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        Me.dtpInvoiceDate.Value = MinDateToNow(myVatitem.DocDate)
      End If
      m_oldInvoiceCode = Me.txtInvoiceCode.Text
      Me.chkAutoRunVat.Checked = Me.m_entity.Vat.AutoGen
      Me.UpdateVatAutogenStatus()

      txtCustomerCode.Text = m_entity.Customer.Code
      txtCustomerName.Text = m_entity.Customer.Name
      txtNote.Text = m_entity.Note

      Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)

      txtFromCostCenterCode.Text = m_entity.FromCostCenter.Code
      txtFromCostCenterName.Text = m_entity.FromCostCenter.Name

      Me.txtFromCCPersonCode.Text = m_entity.FromCostCenterPerson.Code
      txtFromCCPersonName.Text = m_entity.FromCostCenterPerson.Name

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next
      RefreshDocs()
      ''Load Items**********************************************************
      'Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      'AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      'Me.Validator.DataTable = m_treeManager.Treetable
      ''********************************************************************

      'Me.UpdateAmount()

      'RefreshBlankGrid()

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
        Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.DateTimeType)
        Me.Validator.SetRequired(Me.txtInvoiceCode, True)
        If Me.m_isInitialized Then
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
          Me.UpdateAmount()
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtcustomercode"
          dirtyFlag = Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
          If dirtyFlag Then
            UpdateCustomer()
          End If
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
              Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
            End If
            dirtyFlag = True
            'Me.m_entity.ReUpdateDepreciation()  ' คำนวณค่าเสื่อมทั้งหมด เพราะวันที่เปลี่ยน
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
          'Me.m_entity.ReUpdateDepreciation()  ' คำนวณค่าเสื่อมทั้งหมด เพราะวันที่เปลี่ยน
        Case "txtcreditprd"
          If IsNumeric(txtCreditPrd.Text) Then
            Me.m_entity.CreditPeriod = CInt(txtCreditPrd.Text)
            Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
          End If
          dirtyFlag = True
        Case "txttaxbase"
          'Todo
        Case "txtdiscountrate"
          Me.m_entity.Discount.Rate = txtDiscountRate.Text
          UpdateAmount()
          dirtyFlag = True
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Me.m_entity.TaxType.Value = item.Id
          UpdateAmount()
          dirtyFlag = True
          'Case "txtpodoccode"
          '  Me.m_entity.PoDocCode = txtPoDocCode.Text
          '  dirtyFlag = True
          'Case "txtpodocdate"
          '  m_dateSetting = True
          '  If Not Me.txtPoDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtPoDocDate) = "" Then
          '    Dim theDate As Date = CDate(Me.txtPoDocDate.Text)
          '    If Not Me.m_entity.PoDocDate.Equals(theDate) Then
          '      dtpPoDocDate.Value = theDate
          '      Me.m_entity.PoDocDate = dtpPoDocDate.Value
          '      dirtyFlag = True
          '    End If
          '  Else
          '    dtpPoDocDate.Value = Date.Now
          '    Me.m_entity.PoDocDate = Date.MinValue
          '    dirtyFlag = True
          '  End If
          '  m_dateSetting = False
          'Case "dtppodocdate"
          '  If Not Me.m_entity.PoDocDate.Equals(dtpPoDocDate.Value) Then
          '    If Not m_dateSetting Then
          '      Me.txtPoDocDate.Text = MinDateToNull(dtpPoDocDate.Value, "")
          '      Me.m_entity.PoDocDate = dtpPoDocDate.Value
          '    End If
          '    dirtyFlag = True
          '  End If
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
        Case "txtfromccpersoncode"
          dirtyFlag = Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromCostCenterPerson)
        Case "txtfromcostcentercode"
          dirtyFlag = CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter)
          If dirtyFlag Then
            Me.m_entity.FromCostCenterPerson = Me.m_entity.FromCostCenter.Admin
            txtFromCCPersonCode.Text = Me.m_entity.FromCostCenterPerson.Code
            txtFromCCPersonName.Text = Me.m_entity.FromCostCenterPerson.Name
          End If
        Case Else
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
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
      , dtpInvoiceDate _
      , AddressOf UpdateVatAutogenStatus)
      Me.m_isInitialized = flag
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.Itemcollection.Populate(m_treeManager.Treetable, tgItem)

      'RefreshBlankGrid()
      'ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True

    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("LineNumber") = i + 1
        i += 1
      Next
    End Sub
    Private Sub UpdateAmount()
      m_isInitialized = False
      'If refresh Then
      Me.m_entity.RefreshTaxBase()
      'End If
      txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
      txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
      txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
      txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
      txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
      txtDiscountRate.Text = m_entity.Discount.Rate
      txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
      txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)

      Me.m_entity.RefreshAssetSummary()
      txtAssetRemain.Text = Configuration.FormatToString(m_entity.AssetRemain, DigitConfig.Price)
      txtWriteOff.Text = Configuration.FormatToString(m_entity.AssetWriteOff, DigitConfig.Price)
      txtWriteOffDepre.Text = Configuration.FormatToString(m_entity.AssetWriteOffDepre, DigitConfig.Price)
      txtCost.Text = Configuration.FormatToString(m_entity.AssetCost, DigitConfig.Price)
      txtProfitLoss.Text = Configuration.FormatToString(m_entity.AssetProfitLoss, DigitConfig.Price)

      m_isInitialized = True
      SetVatInputAfterAmountChange()
    End Sub
    Private Sub SetVatInputAfterAmountChange()
      If Me.m_entity.TaxType.Value = 0 Then
        'ไม่มี Vat
        SetVatToNoDoc()
        Me.VatInputEnabled(False)
        Me.m_isInitialized = False
        Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.NoTaxText}")
        Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.NoTaxText}")
        Me.dtpInvoiceDate.Value = Now
        Me.m_isInitialized = True
      ElseIf Me.m_entity.Vat.ItemCollection.Count <= 0 Then
        'ไม่มี Vatitem
        Me.m_entity.Vat.ItemCollection().Add(New VatItem)
        Me.VatInputEnabled(True)
      Else
        'มี Vatitem ใบเดียว
        Me.VatInputEnabled(True)
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
          'If Not Me.m_treeManager.GridTableStyle Is Nothing Then
          '    If Me.m_treeManager.GridTableStyle.GridColumnStyles.Contains("Button") Then
          '        Dim btnCol As DataGridButtonColumn = CType(Me.m_treeManager.GridTableStyle.GridColumnStyles("Button"), DataGridButtonColumn)
          '        RemoveHandler btnCol.Click, AddressOf ButtonClick
          '    End If
          'End If
        End If
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = CType(Value, AssetWriteOff)
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
      Dim tt As New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
      CodeDescription.ComboSelect(Me.cmbTaxType, tt)
    End Sub
#End Region

#Region "Event Handler"
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
    Private Sub chkAutoRunVat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoRunVat.CheckedChanged
      UpdateVatAutogenStatus()
    End Sub
    Private Sub UpdateVatAutogenStatus()
      If Me.m_entity.Vat Is Nothing Then
        Return
      End If
      Dim vi As VatItem
      If Me.m_entity.Vat.ItemCollection.Count <= 0 Then
        Me.m_entity.Vat.ItemCollection.Add(New VatItem)
      End If

      vi = Me.m_entity.Vat.ItemCollection(0)
      If Me.chkAutoRunVat.Checked Then
        Me.Validator.SetRequired(Me.txtInvoiceCode, False)
        Me.ErrorProvider1.SetError(Me.txtInvoiceCode, "")
        Me.txtInvoiceCode.ReadOnly = True
        m_oldInvoiceCode = Me.txtInvoiceCode.Text
        Me.txtInvoiceCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(vi.EntityId)
        'Hack: set Code เป็น "" เอง
        vi.Code = ""
        Me.m_entity.Vat.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtInvoiceCode, True)
        Me.txtInvoiceCode.Text = m_oldInvoiceCode
        Me.txtInvoiceCode.ReadOnly = False
        Me.m_entity.Vat.AutoGen = False
      End If
    End Sub
    Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim acct As New Account
      Dim entities As New ArrayList
      acct.Type = New AccountType(4) ' รายได้
      entities.Add(acct)

      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAcct, Nothing, entities)
    End Sub
    Private Sub SetAcct(ByVal acct As ISimpleEntity)
      Me.m_treeManager.SelectedRow("AccountCode") = acct.Code
    End Sub

    Private Function GetToolIdList() As String
      'Dim idlist As String
      'Me.m_entity.ItemTable.AcceptChanges()
      'For Each row As TreeRow In Me.m_entity.ItemTable.Rows
      '  If Me.m_entity.ValidateRow(row) Then
      '    If Not row.IsNull("eqtstocki_entity") Then
      '      idlist &= "|" & CStr(row("eqtstocki_entity")) & "|"
      '    End If
      '  End If
      'Next
      'Return idlist
    End Function
    Private Function GetItemAndTypeList() As String
      Dim arrString As New ArrayList
      For Each awi As AssetWriteOffItem In m_entity.Itemcollection
        If TypeOf awi.Entity Is Asset AndAlso Not awi.HasChild Then
          arrString.Add(awi.Entity.Id.ToString & ":" & awi.ItemType.Value.ToString)
        Else
          If awi.Qty > 0 Then
            arrString.Add(awi.Entity.Id.ToString & ":" & awi.ItemType.Value.ToString)
          End If
        End If
      Next
      Return String.Join(",", arrString.ToArray)
    End Function
    Private Function GetIdList() As String
      Dim arrString As New ArrayList
      For Each awi As AssetWriteOffItem In m_entity.Itemcollection
        If TypeOf awi.Entity Is Asset Then
          If Not arrString.Contains(awi.Entity.Id) Then
            arrString.Add(awi.Entity.Id)
          End If
        End If
      Next
      Return String.Join(",", arrString.ToArray)
    End Function
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity.FromCostCenter Is Nothing OrElse Not Me.m_entity.FromCostCenter.Originated Then
        Dim myMsgService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        myMsgService.ShowWarning("${res:Global.Error.SpecifyCC}")
        txtFromCostCenterCode.Focus()
        Return
      End If
      'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      'Dim filters(0) As Filter
      'filters(0) = New Filter("idlist", GetToolIdList())

      'Dim entities As New ArrayList
      'Dim obj As New Asset
      'obj.Costcenter = Me.m_entity.FromCostCenter
      'entities.Add(obj)

      'myEntityPanelService.OpenListDialog(New Asset, AddressOf SetItems, filters, entities)

      Dim dlg As New BasketDialog
      AddHandler dlg.EmptyBasket, AddressOf SetItems

      Dim filters(0) As Filter

      'filters(0) = New Filter("idandTypelist", GetItemAndTypeList())
      filters(0) = New Filter("Idlist", GetIdList())

      Dim Entities As New ArrayList
      If Not Me.m_entity.FromCC Is Nothing AndAlso Me.m_entity.FromCC.Originated Then
        Dim fromcc As New fromCostcenter
        fromcc.Id = m_entity.FromCC.Id
        fromcc.Code = m_entity.FromCC.Code
        fromcc.Name = m_entity.FromCC.Name
        Entities.Add(fromcc)
      End If
      Entities.Add(m_entity)
      Dim view As AbstractEntityPanelViewContent = New AssetSelectionForWriteOffView(New AssetSelectionForWriteOff, New BasketDialog, filters, Entities)
      dlg.Lists.Add(view)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
      myDialog.ShowDialog()
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      m_entity.Itemcollection.AssetWriteoff = m_entity
      Me.m_entity.Itemcollection.SetItems(items)
      Me.m_entity.RefreshSummaryParent()

      'For i As Integer = items.Count - 1 To 0 Step -1
      '  Dim item As EqtBasketItem = CType(items(i), EqtBasketItem)
      '  Dim newItem As IEqtItem
      '  Dim newType As Integer = -1

      '  newItem = New Asset(item.Id)
      '  newType = newItem.EntityId

      '  If i = items.Count - 1 Then
      '    If Me.m_entity.ItemTable.Childs.Count = 0 Then
      '      Me.m_entity.AddBlankRow(1)
      '      Me.m_entity.ItemTable.Rows(index)("eqtstocki_entityType") = newType
      '      Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
      '    Else
      '      Me.m_entity.ItemTable.Rows(index)("eqtstocki_entityType") = newType
      '      Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
      '    End If
      '  Else
      '    Dim mySolditem As New AssetWriteOffItem
      '    mySolditem.AssetWriteoff = Me.m_entity
      '    mySolditem.Entity = newItem

      '    Me.m_entity.Insert(index, mySolditem)
      '    Me.m_entity.ItemTable.Rows(index)("eqtstocki_entityType") = newType
      '    Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
      '  End If
      '  Me.m_entity.ItemTable.AcceptChanges()
      'Next
      tgItem.CurrentRowIndex = index
      RefreshDocs()
      CheckFormEnable()
      'RefreshBlankGrid()
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      'Dim index As Integer = tgItem.CurrentRowIndex
      'If index > Me.m_entity.MaxRowIndex Then
      '  Return
      'End If
      'Dim item As New AssetWriteOffItem
      'Me.m_entity.Insert(index, item)
      'Me.m_entity.ItemTable.AcceptChanges()
      'tgItem.CurrentRowIndex = index
      'RefreshBlankGrid()
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click

      Dim doc As AssetWriteOffItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      If Not Me.m_entity.Itemcollection.Contains(doc) Then
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
            If row.Level = 1 Then
              For Each childRow As TreeRow In row.Parent.Childs
                If Not arrList.Contains(childRow) Then
                  arrList.Add(childRow)
                End If
              Next
              If row.Parent.Childs.Count > 0 Then
                If Not arrList.Contains(row.Parent) Then
                  arrList.Add(row.Parent)
                End If
              End If
            End If
            If Not arrList.Contains(row) Then
              arrList.Add(row)
            End If
          End If
        End If
      Next

      For Each row As TreeRow In arrList
        If Not row Is Nothing AndAlso TypeOf row.Tag Is AssetWriteOffItem Then

          Dim itm As AssetWriteOffItem = CType(row.Tag, AssetWriteOffItem)
          If Not itm Is Nothing Then
            If Me.m_entity.Itemcollection.Contains(itm) Then
              Me.m_entity.Itemcollection.Remove(itm)
              Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
          End If
        End If
      Next

      'forceUpdateTaxBase = True
      'forceUpdateTaxAmount = True
      'forceUpdateGross = True
      RefreshDocs()


      If index > 0 Then
        If Me.m_entity.Itemcollection.Count = 0 Then
          tgItem.CurrentRowIndex = 0
        Else
          If index > Me.m_entity.Itemcollection.Count Then
            tgItem.CurrentRowIndex = Me.m_entity.Itemcollection.Count - 1
          Else
            tgItem.CurrentRowIndex = index - 1
          End If
        End If
      Else
        tgItem.CurrentRowIndex = 0
      End If


      'Dim index As Integer = Me.tgItem.CurrentRowIndex
      'If index > Me.m_entity.MaxRowIndex Then
      '  Return
      'End If
      'Me.m_entity.Remove(index)
      'Me.tgItem.CurrentRowIndex = index
      ''RefreshBlankGrid()
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
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
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New AssetWriteOff).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Customer
    Private Sub ibtnShowCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomer.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Customer)
    End Sub
    Private Sub ibtnShowCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomerDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomerDialog)
    End Sub
    Private Sub SetCustomerDialog(ByVal e As ISimpleEntity)
      Me.txtCustomerCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
      UpdateCustomer()
    End Sub
    Private Sub UpdateCustomer()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Customer Is Nothing Then
        Return
      End If
      Dim myVat As Vat = Me.m_entity.Vat
      If Not myVat Is Nothing Then
        If myVat.ItemCollection.Count <= 0 Then
          Me.m_entity.Vat.ItemCollection.Add(New VatItem)
        End If
        VatInputEnabled(True)
        Dim myVatitem As VatItem
        myVatitem = Me.m_entity.Vat.ItemCollection(0)
        myVatitem.PrintAddress = Me.m_entity.Customer.BillingAddress
        myVatitem.PrintName = Me.m_entity.Customer.Name
      End If
    End Sub
    'Cost Center
    Private Sub ibtnShowFromCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCostCenter.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub ibtnShowFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowFromCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCostCenter)
    End Sub
    Private Sub SetFromCostCenter(ByVal e As ISimpleEntity)
      Me.txtFromCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter)
      If Me.WorkbenchWindow.ViewContent.IsDirty Then
        Me.m_entity.FromCostCenterPerson = Me.m_entity.FromCostCenter.Admin
        txtFromCCPersonCode.Text = Me.m_entity.FromCostCenterPerson.Code
        txtFromCCPersonName.Text = Me.m_entity.FromCostCenterPerson.Name
      End If
    End Sub

    'Cost Person
    Private Sub ibtnShowCCPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCCPerson.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub ibtnShowCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetCCPerson)
    End Sub
    Private Sub SetCCPerson(ByVal e As ISimpleEntity)
      Me.txtFromCCPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromCostCenterPerson)
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

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
      'RefreshBlankGrid()
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
      'Do While Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1
      '  'เพิ่มแถวจนเต็ม
      '  Me.m_entity.AddBlankRow(1)
      'Loop
      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop
      'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
      '  If Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1 Then
      '    'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '    Me.m_entity.AddBlankRow(1)
      '  End If
      'End If
      'Do While Me.m_entity.ItemTable.Rows.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Rows.Count - 2 <> Me.m_entity.MaxRowIndex
      '    'ลบแถวที่ไม่จำเป็น
      '    Me.m_entity.Remove(Me.m_entity.ItemTable.Rows.Count - 1)
      'Loop
      'Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

  End Class
End Namespace