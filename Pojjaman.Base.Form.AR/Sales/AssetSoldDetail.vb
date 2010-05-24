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
    Public Class AssetSoldDetail
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
        Friend WithEvents txtPoDocDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpPoDocDate As System.Windows.Forms.DateTimePicker
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
        Friend WithEvents lblPoDocCode As System.Windows.Forms.Label
        Friend WithEvents txtPoDocCode As System.Windows.Forms.TextBox
        Friend WithEvents lblPoDocDate As System.Windows.Forms.Label
        Friend WithEvents ibtnShowFromCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowFromCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDueDate As System.Windows.Forms.Label
        Friend WithEvents ibtnShowCCPerson As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
        Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
        Friend WithEvents lblDocStatus As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssetSoldDetail))
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblItem = New System.Windows.Forms.Label
            Me.grbCostCenter = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnShowFromCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowFromCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtFromCCPersonName = New System.Windows.Forms.TextBox
            Me.ibtnShowCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox
            Me.txtFromCostCenterName = New System.Windows.Forms.TextBox
            Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox
            Me.lblFromCCPerson = New System.Windows.Forms.Label
            Me.lblFromCostCenter = New System.Windows.Forms.Label
            Me.grbDelivery = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnShowCustomer = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.txtCustomerCode = New System.Windows.Forms.TextBox
            Me.lblCreditPrd = New System.Windows.Forms.Label
            Me.lblDay = New System.Windows.Forms.Label
            Me.txtCreditPrd = New System.Windows.Forms.TextBox
            Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
            Me.lblDueDate = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.lblPoDocCode = New System.Windows.Forms.Label
            Me.txtPoDocCode = New System.Windows.Forms.TextBox
            Me.lblPoDocDate = New System.Windows.Forms.Label
            Me.lblInvoiceCode = New System.Windows.Forms.Label
            Me.txtInvoiceCode = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtPoDocDate = New System.Windows.Forms.TextBox
            Me.txtInvoiceDate = New System.Windows.Forms.TextBox
            Me.txtGross = New System.Windows.Forms.TextBox
            Me.txtDiscountAmount = New System.Windows.Forms.TextBox
            Me.txtBeforeTax = New System.Windows.Forms.TextBox
            Me.txtTaxAmount = New System.Windows.Forms.TextBox
            Me.txtAfterTax = New System.Windows.Forms.TextBox
            Me.txtDiscountRate = New System.Windows.Forms.TextBox
            Me.txtTaxRate = New System.Windows.Forms.TextBox
            Me.txtTaxBase = New System.Windows.Forms.TextBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.dtpPoDocDate = New System.Windows.Forms.DateTimePicker
            Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker
            Me.lblInvoiceDate = New System.Windows.Forms.Label
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblTaxAmount = New System.Windows.Forms.Label
            Me.lblAfterTax = New System.Windows.Forms.Label
            Me.lblDiscountAmount = New System.Windows.Forms.Label
            Me.lblBeforeTax = New System.Windows.Forms.Label
            Me.lblGross = New System.Windows.Forms.Label
            Me.cmbTaxType = New System.Windows.Forms.ComboBox
            Me.lblTaxType = New System.Windows.Forms.Label
            Me.lblTaxRate = New System.Windows.Forms.Label
            Me.lblTaxBase = New System.Windows.Forms.Label
            Me.lblPercent = New System.Windows.Forms.Label
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.chkAutoRunVat = New System.Windows.Forms.CheckBox
            Me.lblDocStatus = New System.Windows.Forms.Label
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbCostCenter.SuspendLayout()
            Me.grbDelivery.SuspendLayout()
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
            Me.tgItem.Location = New System.Drawing.Point(8, 152)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(760, 232)
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
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
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
            Me.txtCode.Location = New System.Drawing.Point(112, 16)
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
            Me.lblItem.Location = New System.Drawing.Point(8, 136)
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
            Me.grbCostCenter.Location = New System.Drawing.Point(400, 64)
            Me.grbCostCenter.Name = "grbCostCenter"
            Me.grbCostCenter.Size = New System.Drawing.Size(368, 72)
            Me.grbCostCenter.TabIndex = 7
            Me.grbCostCenter.TabStop = False
            Me.grbCostCenter.Text = "Cost Center จ่ายของ"
            '
            'ibtnShowFromCostCenter
            '
            Me.ibtnShowFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowFromCostCenter.Image = CType(resources.GetObject("ibtnShowFromCostCenter.Image"), System.Drawing.Image)
            Me.ibtnShowFromCostCenter.Location = New System.Drawing.Point(328, 15)
            Me.ibtnShowFromCostCenter.Name = "ibtnShowFromCostCenter"
            Me.ibtnShowFromCostCenter.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowFromCostCenter.TabIndex = 8
            Me.ibtnShowFromCostCenter.TabStop = False
            Me.ibtnShowFromCostCenter.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenter.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowFromCostCenterDialog
            '
            Me.ibtnShowFromCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowFromCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowFromCostCenterDialog.Image = CType(resources.GetObject("ibtnShowFromCostCenterDialog.Image"), System.Drawing.Image)
            Me.ibtnShowFromCostCenterDialog.Location = New System.Drawing.Point(304, 15)
            Me.ibtnShowFromCostCenterDialog.Name = "ibtnShowFromCostCenterDialog"
            Me.ibtnShowFromCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowFromCostCenterDialog.TabIndex = 6
            Me.ibtnShowFromCostCenterDialog.TabStop = False
            Me.ibtnShowFromCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowFromCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowCCPerson
            '
            Me.ibtnShowCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCCPerson.Image = CType(resources.GetObject("ibtnShowCCPerson.Image"), System.Drawing.Image)
            Me.ibtnShowCCPerson.Location = New System.Drawing.Point(328, 39)
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
            Me.txtFromCCPersonName.Location = New System.Drawing.Point(128, 40)
            Me.Validator.SetMaxValue(Me.txtFromCCPersonName, "")
            Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
            Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
            Me.txtFromCCPersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
            Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
            Me.txtFromCCPersonName.Size = New System.Drawing.Size(176, 20)
            Me.txtFromCCPersonName.TabIndex = 5
            Me.txtFromCCPersonName.TabStop = False
            Me.txtFromCCPersonName.Text = ""
            '
            'ibtnShowCCPersonDialog
            '
            Me.ibtnShowCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowCCPersonDialog.Image = CType(resources.GetObject("ibtnShowCCPersonDialog.Image"), System.Drawing.Image)
            Me.ibtnShowCCPersonDialog.Location = New System.Drawing.Point(304, 39)
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
            Me.txtFromCCPersonCode.Location = New System.Drawing.Point(64, 40)
            Me.Validator.SetMaxValue(Me.txtFromCCPersonCode, "")
            Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
            Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
            Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
            Me.Validator.SetRequired(Me.txtFromCCPersonCode, True)
            Me.txtFromCCPersonCode.Size = New System.Drawing.Size(64, 20)
            Me.txtFromCCPersonCode.TabIndex = 1
            Me.txtFromCCPersonCode.Text = ""
            '
            'txtFromCostCenterName
            '
            Me.txtFromCostCenterName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
            Me.txtFromCostCenterName.Location = New System.Drawing.Point(128, 16)
            Me.Validator.SetMaxValue(Me.txtFromCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
            Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
            Me.txtFromCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
            Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
            Me.txtFromCostCenterName.Size = New System.Drawing.Size(176, 20)
            Me.txtFromCostCenterName.TabIndex = 4
            Me.txtFromCostCenterName.TabStop = False
            Me.txtFromCostCenterName.Text = ""
            '
            'txtFromCostCenterCode
            '
            Me.txtFromCostCenterCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
            Me.txtFromCostCenterCode.Location = New System.Drawing.Point(64, 16)
            Me.Validator.SetMaxValue(Me.txtFromCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
            Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtFromCostCenterCode, True)
            Me.txtFromCostCenterCode.Size = New System.Drawing.Size(64, 20)
            Me.txtFromCostCenterCode.TabIndex = 0
            Me.txtFromCostCenterCode.Text = ""
            '
            'lblFromCCPerson
            '
            Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFromCCPerson.Location = New System.Drawing.Point(8, 40)
            Me.lblFromCCPerson.Name = "lblFromCCPerson"
            Me.lblFromCCPerson.Size = New System.Drawing.Size(56, 18)
            Me.lblFromCCPerson.TabIndex = 3
            Me.lblFromCCPerson.Text = "ผู้จ่ายของ:"
            Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFromCostCenter
            '
            Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFromCostCenter.Location = New System.Drawing.Point(8, 16)
            Me.lblFromCostCenter.Name = "lblFromCostCenter"
            Me.lblFromCostCenter.Size = New System.Drawing.Size(56, 18)
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
            Me.grbDelivery.Location = New System.Drawing.Point(8, 64)
            Me.grbDelivery.Name = "grbDelivery"
            Me.grbDelivery.Size = New System.Drawing.Size(384, 72)
            Me.grbDelivery.TabIndex = 6
            Me.grbDelivery.TabStop = False
            Me.grbDelivery.Text = "ส่งของให้"
            '
            'ibtnShowCustomer
            '
            Me.ibtnShowCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCustomer.Image = CType(resources.GetObject("ibtnShowCustomer.Image"), System.Drawing.Image)
            Me.ibtnShowCustomer.Location = New System.Drawing.Point(344, 16)
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
            Me.txtCustomerName.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMaxValue(Me.txtCustomerName, "")
            Me.Validator.SetMinValue(Me.txtCustomerName, "")
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
            Me.Validator.SetRequired(Me.txtCustomerName, False)
            Me.txtCustomerName.Size = New System.Drawing.Size(168, 20)
            Me.txtCustomerName.TabIndex = 5
            Me.txtCustomerName.TabStop = False
            Me.txtCustomerName.Text = ""
            '
            'ibtnShowCustomerDialog
            '
            Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowCustomerDialog.Image = CType(resources.GetObject("ibtnShowCustomerDialog.Image"), System.Drawing.Image)
            Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(320, 16)
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
            Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
            Me.Validator.SetMinValue(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
            Me.Validator.SetRequired(Me.txtCustomerCode, True)
            Me.txtCustomerCode.Size = New System.Drawing.Size(64, 20)
            Me.txtCustomerCode.TabIndex = 0
            Me.txtCustomerCode.Text = ""
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
            Me.lblDay.Size = New System.Drawing.Size(17, 17)
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
            Me.Validator.SetMaxValue(Me.txtCreditPrd, "")
            Me.Validator.SetMinValue(Me.txtCreditPrd, "0")
            Me.txtCreditPrd.Name = "txtCreditPrd"
            Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
            Me.Validator.SetRequired(Me.txtCreditPrd, False)
            Me.txtCreditPrd.Size = New System.Drawing.Size(64, 20)
            Me.txtCreditPrd.TabIndex = 1
            Me.txtCreditPrd.Text = ""
            '
            'dtpDueDate
            '
            Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDueDate.Enabled = False
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDueDate.Location = New System.Drawing.Point(272, 40)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpDueDate.TabIndex = 2
            Me.dtpDueDate.TabStop = False
            '
            'lblDueDate
            '
            Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDate.ForeColor = System.Drawing.Color.Black
            Me.lblDueDate.Location = New System.Drawing.Point(192, 41)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(80, 18)
            Me.lblDueDate.TabIndex = 7
            Me.lblDueDate.Text = "กำหนดชำระ:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.txtNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(136, 392)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(320, 20)
            Me.txtNote.TabIndex = 9
            Me.txtNote.Text = ""
            '
            'lblNote
            '
            Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(80, 392)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(56, 18)
            Me.lblNote.TabIndex = 26
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPoDocCode
            '
            Me.lblPoDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPoDocCode.ForeColor = System.Drawing.Color.Black
            Me.lblPoDocCode.Location = New System.Drawing.Point(8, 40)
            Me.lblPoDocCode.Name = "lblPoDocCode"
            Me.lblPoDocCode.Size = New System.Drawing.Size(104, 18)
            Me.lblPoDocCode.TabIndex = 14
            Me.lblPoDocCode.Text = "Customer PO No.:"
            Me.lblPoDocCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPoDocCode
            '
            Me.Validator.SetDataType(Me.txtPoDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPoDocCode, "")
            Me.txtPoDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPoDocCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPoDocCode, System.Drawing.Color.Empty)
            Me.txtPoDocCode.Location = New System.Drawing.Point(112, 40)
            Me.Validator.SetMaxValue(Me.txtPoDocCode, "")
            Me.Validator.SetMinValue(Me.txtPoDocCode, "")
            Me.txtPoDocCode.Name = "txtPoDocCode"
            Me.Validator.SetRegularExpression(Me.txtPoDocCode, "")
            Me.Validator.SetRequired(Me.txtPoDocCode, False)
            Me.txtPoDocCode.Size = New System.Drawing.Size(112, 21)
            Me.txtPoDocCode.TabIndex = 2
            Me.txtPoDocCode.TabStop = False
            Me.txtPoDocCode.Text = ""
            '
            'lblPoDocDate
            '
            Me.lblPoDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPoDocDate.ForeColor = System.Drawing.Color.Black
            Me.lblPoDocDate.Location = New System.Drawing.Point(232, 40)
            Me.lblPoDocDate.Name = "lblPoDocDate"
            Me.lblPoDocDate.Size = New System.Drawing.Size(48, 18)
            Me.lblPoDocDate.TabIndex = 17
            Me.lblPoDocDate.Text = "วันที่:"
            Me.lblPoDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblInvoiceCode
            '
            Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
            Me.lblInvoiceCode.Location = New System.Drawing.Point(376, 40)
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
            Me.txtInvoiceCode.Location = New System.Drawing.Point(480, 40)
            Me.Validator.SetMaxValue(Me.txtInvoiceCode, "")
            Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
            Me.txtInvoiceCode.Name = "txtInvoiceCode"
            Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
            Me.Validator.SetRequired(Me.txtInvoiceCode, False)
            Me.txtInvoiceCode.Size = New System.Drawing.Size(112, 21)
            Me.txtInvoiceCode.TabIndex = 4
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
            Me.txtDocDate.Location = New System.Drawing.Point(280, 16)
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
            Me.txtDocDate.TabIndex = 1
            Me.txtDocDate.Text = ""
            '
            'txtPoDocDate
            '
            Me.Validator.SetDataType(Me.txtPoDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtPoDocDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtPoDocDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPoDocDate, 15)
            Me.Validator.SetInvalidBackColor(Me.txtPoDocDate, System.Drawing.Color.Empty)
            Me.txtPoDocDate.Location = New System.Drawing.Point(280, 40)
            Me.Validator.SetMaxValue(Me.txtPoDocDate, "")
            Me.Validator.SetMinValue(Me.txtPoDocDate, "")
            Me.txtPoDocDate.Name = "txtPoDocDate"
            Me.Validator.SetRegularExpression(Me.txtPoDocDate, "")
            Me.Validator.SetRequired(Me.txtPoDocDate, False)
            Me.txtPoDocDate.Size = New System.Drawing.Size(78, 20)
            Me.txtPoDocDate.TabIndex = 3
            Me.txtPoDocDate.Text = ""
            '
            'txtInvoiceDate
            '
            Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
            Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
            Me.txtInvoiceDate.Location = New System.Drawing.Point(648, 40)
            Me.Validator.SetMaxValue(Me.txtInvoiceDate, "")
            Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
            Me.txtInvoiceDate.Name = "txtInvoiceDate"
            Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
            Me.Validator.SetRequired(Me.txtInvoiceDate, False)
            Me.txtInvoiceDate.Size = New System.Drawing.Size(78, 20)
            Me.txtInvoiceDate.TabIndex = 5
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
            Me.txtGross.Location = New System.Drawing.Point(616, 384)
            Me.Validator.SetMaxValue(Me.txtGross, "")
            Me.Validator.SetMinValue(Me.txtGross, "")
            Me.txtGross.Name = "txtGross"
            Me.txtGross.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGross, "")
            Me.Validator.SetRequired(Me.txtGross, False)
            Me.txtGross.Size = New System.Drawing.Size(144, 20)
            Me.txtGross.TabIndex = 31
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
            Me.txtDiscountAmount.Location = New System.Drawing.Point(616, 404)
            Me.Validator.SetMaxValue(Me.txtDiscountAmount, "")
            Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
            Me.txtDiscountAmount.Name = "txtDiscountAmount"
            Me.txtDiscountAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
            Me.Validator.SetRequired(Me.txtDiscountAmount, False)
            Me.txtDiscountAmount.Size = New System.Drawing.Size(144, 20)
            Me.txtDiscountAmount.TabIndex = 32
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
            Me.txtBeforeTax.Location = New System.Drawing.Point(616, 424)
            Me.Validator.SetMaxValue(Me.txtBeforeTax, "")
            Me.Validator.SetMinValue(Me.txtBeforeTax, "")
            Me.txtBeforeTax.Name = "txtBeforeTax"
            Me.txtBeforeTax.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
            Me.Validator.SetRequired(Me.txtBeforeTax, False)
            Me.txtBeforeTax.Size = New System.Drawing.Size(144, 20)
            Me.txtBeforeTax.TabIndex = 33
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
            Me.txtTaxAmount.Location = New System.Drawing.Point(616, 464)
            Me.Validator.SetMaxValue(Me.txtTaxAmount, "")
            Me.Validator.SetMinValue(Me.txtTaxAmount, "")
            Me.txtTaxAmount.Name = "txtTaxAmount"
            Me.txtTaxAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
            Me.Validator.SetRequired(Me.txtTaxAmount, False)
            Me.txtTaxAmount.Size = New System.Drawing.Size(144, 20)
            Me.txtTaxAmount.TabIndex = 35
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
            Me.txtAfterTax.Location = New System.Drawing.Point(616, 484)
            Me.Validator.SetMaxValue(Me.txtAfterTax, "")
            Me.Validator.SetMinValue(Me.txtAfterTax, "")
            Me.txtAfterTax.Name = "txtAfterTax"
            Me.txtAfterTax.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
            Me.Validator.SetRequired(Me.txtAfterTax, False)
            Me.txtAfterTax.Size = New System.Drawing.Size(144, 20)
            Me.txtAfterTax.TabIndex = 36
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
            Me.txtDiscountRate.Location = New System.Drawing.Point(520, 404)
            Me.Validator.SetMaxValue(Me.txtDiscountRate, "")
            Me.Validator.SetMinValue(Me.txtDiscountRate, "")
            Me.txtDiscountRate.Name = "txtDiscountRate"
            Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
            Me.Validator.SetRequired(Me.txtDiscountRate, False)
            Me.txtDiscountRate.Size = New System.Drawing.Size(88, 20)
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
            Me.txtTaxRate.Location = New System.Drawing.Point(488, 464)
            Me.Validator.SetMaxValue(Me.txtTaxRate, "")
            Me.Validator.SetMinValue(Me.txtTaxRate, "")
            Me.txtTaxRate.Name = "txtTaxRate"
            Me.txtTaxRate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
            Me.Validator.SetRequired(Me.txtTaxRate, True)
            Me.txtTaxRate.Size = New System.Drawing.Size(32, 20)
            Me.txtTaxRate.TabIndex = 40
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
            Me.txtTaxBase.Location = New System.Drawing.Point(616, 444)
            Me.Validator.SetMaxValue(Me.txtTaxBase, "")
            Me.Validator.SetMinValue(Me.txtTaxBase, "")
            Me.txtTaxBase.Name = "txtTaxBase"
            Me.txtTaxBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
            Me.Validator.SetRequired(Me.txtTaxBase, False)
            Me.txtTaxBase.Size = New System.Drawing.Size(144, 20)
            Me.txtTaxBase.TabIndex = 34
            Me.txtTaxBase.TabStop = False
            Me.txtTaxBase.Text = ""
            Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            'dtpPoDocDate
            '
            Me.dtpPoDocDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpPoDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpPoDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpPoDocDate.Location = New System.Drawing.Point(280, 40)
            Me.dtpPoDocDate.Name = "dtpPoDocDate"
            Me.dtpPoDocDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpPoDocDate.TabIndex = 19
            Me.dtpPoDocDate.TabStop = False
            '
            'dtpInvoiceDate
            '
            Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(648, 40)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpInvoiceDate.TabIndex = 23
            Me.dtpInvoiceDate.TabStop = False
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.lblInvoiceDate.Location = New System.Drawing.Point(616, 40)
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            Me.lblInvoiceDate.Size = New System.Drawing.Size(32, 18)
            Me.lblInvoiceDate.TabIndex = 22
            Me.lblInvoiceDate.Text = "วันที่:"
            Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(8, 384)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
            Me.ibtnBlank.TabIndex = 24
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(40, 384)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
            Me.ibtnDelRow.TabIndex = 25
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblTaxAmount
            '
            Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxAmount.Location = New System.Drawing.Point(536, 465)
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
            Me.lblAfterTax.Location = New System.Drawing.Point(480, 485)
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
            Me.lblDiscountAmount.Location = New System.Drawing.Point(448, 405)
            Me.lblDiscountAmount.Name = "lblDiscountAmount"
            Me.lblDiscountAmount.Size = New System.Drawing.Size(72, 18)
            Me.lblDiscountAmount.TabIndex = 29
            Me.lblDiscountAmount.Text = "ส่วนลด :"
            Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBeforeTax
            '
            Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
            Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBeforeTax.Location = New System.Drawing.Point(408, 425)
            Me.lblBeforeTax.Name = "lblBeforeTax"
            Me.lblBeforeTax.Size = New System.Drawing.Size(208, 18)
            Me.lblBeforeTax.TabIndex = 43
            Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
            Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblGross
            '
            Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblGross.BackColor = System.Drawing.Color.Transparent
            Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGross.Location = New System.Drawing.Point(536, 385)
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
            Me.cmbTaxType.Location = New System.Drawing.Point(368, 464)
            Me.cmbTaxType.Name = "cmbTaxType"
            Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
            Me.cmbTaxType.TabIndex = 11
            '
            'lblTaxType
            '
            Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxType.Location = New System.Drawing.Point(280, 465)
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
            Me.lblTaxRate.Location = New System.Drawing.Point(424, 465)
            Me.lblTaxRate.Name = "lblTaxRate"
            Me.lblTaxRate.Size = New System.Drawing.Size(61, 18)
            Me.lblTaxRate.TabIndex = 42
            Me.lblTaxRate.Text = "อัตราภาษี :"
            Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTaxBase
            '
            Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxBase.Location = New System.Drawing.Point(408, 445)
            Me.lblTaxBase.Name = "lblTaxBase"
            Me.lblTaxBase.Size = New System.Drawing.Size(208, 18)
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
            Me.lblPercent.Location = New System.Drawing.Point(520, 465)
            Me.lblPercent.Name = "lblPercent"
            Me.lblPercent.Size = New System.Drawing.Size(15, 17)
            Me.lblPercent.TabIndex = 38
            Me.lblPercent.Text = "%"
            Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(200, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 15
            Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
            '
            'chkAutoRunVat
            '
            Me.chkAutoRunVat.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutoRunVat.Image = CType(resources.GetObject("chkAutoRunVat.Image"), System.Drawing.Image)
            Me.chkAutoRunVat.Location = New System.Drawing.Point(592, 40)
            Me.chkAutoRunVat.Name = "chkAutoRunVat"
            Me.chkAutoRunVat.Size = New System.Drawing.Size(21, 21)
            Me.chkAutoRunVat.TabIndex = 21
            '
            'lblDocStatus
            '
            Me.lblDocStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblDocStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblDocStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocStatus.Location = New System.Drawing.Point(8, 488)
            Me.lblDocStatus.Name = "lblDocStatus"
            Me.lblDocStatus.Size = New System.Drawing.Size(472, 18)
            Me.lblDocStatus.TabIndex = 12
            Me.lblDocStatus.Text = "Status"
            Me.lblDocStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'AssetSoldDetail
            '
            Me.Controls.Add(Me.chkAutoRunVat)
            Me.Controls.Add(Me.chkAutorun)
            Me.Controls.Add(Me.lblPercent)
            Me.Controls.Add(Me.txtGross)
            Me.Controls.Add(Me.txtDiscountAmount)
            Me.Controls.Add(Me.lblBeforeTax)
            Me.Controls.Add(Me.lblGross)
            Me.Controls.Add(Me.txtBeforeTax)
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
            Me.Controls.Add(Me.lblPoDocCode)
            Me.Controls.Add(Me.txtPoDocCode)
            Me.Controls.Add(Me.lblPoDocDate)
            Me.Controls.Add(Me.lblInvoiceCode)
            Me.Controls.Add(Me.txtInvoiceCode)
            Me.Controls.Add(Me.txtPoDocDate)
            Me.Controls.Add(Me.dtpPoDocDate)
            Me.Controls.Add(Me.lblInvoiceDate)
            Me.Controls.Add(Me.txtInvoiceDate)
            Me.Controls.Add(Me.dtpInvoiceDate)
            Me.Controls.Add(Me.lblTaxAmount)
            Me.Controls.Add(Me.lblDocStatus)
            Me.Controls.Add(Me.lblDiscountAmount)
            Me.Name = "AssetSoldDetail"
            Me.Size = New System.Drawing.Size(784, 520)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbCostCenter.ResumeLayout(False)
            Me.grbDelivery.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblNote}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblItem}")
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

            Me.lblPoDocCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblPoDocCode}")
            Me.Validator.SetDisplayName(txtPoDocCode, lblPoDocCode.Text)

            Me.lblPoDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblPoDocDate}")
            Me.Validator.SetDisplayName(txtPoDocDate, lblPoDocDate.Text)

            Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblDueDate}")

        End Sub
#End Region

#Region "Members"
        Private m_entity As AssetSold
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

            Dim dt As TreeTable = AssetSold.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False

            EventWiring()
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "AssetSold"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            'Stock Items
            Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "eqtstocki_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "eqtstocki_linenumber"


            Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 80
            csCode.ReadOnly = False
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf ButtonClick

            Dim csName As New TreeTextColumn
      csName.MappingName = "eqtstocki_itemName"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.DescriptionHeaderText}")
            csName.NullText = ""
            csName.Width = 180
            csName.TextBox.Name = "Description"
            csName.ReadOnly = True
         
            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnitHeaderText}")
            csUnit.NullText = ""
            csUnit.Width = 30
            csUnit.TextBox.Name = "Unit"
            csUnit.ReadOnly = True
            csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csQty As New TreeTextColumn
      csQty.MappingName = "eqtstocki_qty"
            csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.QtyHeaderText}")
            csQty.NullText = ""
            csQty.Format = "#,###.##"
            csQty.TextBox.Name = "Qty"
            csQty.ReadOnly = True
            csQty.DataAlignment = HorizontalAlignment.Right

            Dim csStockQty As New TreeTextColumn
            csStockQty.MappingName = "StockQty"
            csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.StockQtyHeaderText}")
            csStockQty.NullText = ""
            csStockQty.Format = "#,###.##"
            csStockQty.ReadOnly = True
            csStockQty.DataAlignment = HorizontalAlignment.Right

            Dim csUnitPRice As New TreeTextColumn
            csUnitPRice.MappingName = "stocki_unitprice"
            csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnitpriceHeaderText}")
            csUnitPRice.NullText = ""
            csUnitPRice.TextBox.Name = "stocki_unitprice"
            csStockQty.Format = "#,###.##"
            csStockQty.ReadOnly = False
            csUnitPRice.DataAlignment = HorizontalAlignment.Right

            Dim csDiscount As New TreeTextColumn
            csDiscount.MappingName = "stocki_discrate"
            csDiscount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.DiscountHeaderText}")
            csDiscount.NullText = ""
            csDiscount.TextBox.Name = "stocki_discrate"

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "Amount"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AmountHeaderText}")
            csAmount.NullText = ""
            csAmount.TextBox.Name = "Amount"
            csAmount.ReadOnly = True
            csAmount.Format = "#,###.##"
            csAmount.DataAlignment = HorizontalAlignment.Right

            Dim csDepre As New TreeTextColumn
            csDepre.MappingName = "deprecalcamt"
            csDepre.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.DeprecalcHeaderText}")
            csDepre.NullText = ""
            csDepre.TextBox.Name = "deprecalcamt"
            csDepre.ReadOnly = True
            csDepre.Format = "#,###.##"
            csDepre.DataAlignment = HorizontalAlignment.Right

            Dim csAccountCode As New TreeTextColumn
            csAccountCode.MappingName = "AccountCode"
            csAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AccountCodeHeaderText}")
            csAccountCode.NullText = ""
            csAccountCode.TextBox.Name = "AccountCode"

            Dim csAccount As New TreeTextColumn
            csAccount.MappingName = "Account"
            csAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AccountHeaderText}")
            csAccount.NullText = ""
            csAccount.ReadOnly = True
            csAccount.TextBox.Name = "Account"

            Dim csAccountButton As New DataGridButtonColumn
            csAccountButton.MappingName = "AccountButton"
            csAccountButton.HeaderText = ""
            csAccountButton.NullText = ""
            'AddHandler csAccountButton.Click, AddressOf ButtonClick

            Dim csVatable As New DataGridCheckBoxColumn
            csVatable.MappingName = "stocki_unvatable"
            csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnVatableHeaderText}")
            csVatable.Width = 100
            csVatable.ReadOnly = True
            csVatable.InvisibleWhenUnspcified = True

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "stocki_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "stocki_note"

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csQty)
            dst.GridColumnStyles.Add(csUnitPRice)
            dst.GridColumnStyles.Add(csDiscount)
            dst.GridColumnStyles.Add(csAmount)
            dst.GridColumnStyles.Add(csDepre)
            dst.GridColumnStyles.Add(csAccountCode)
            dst.GridColumnStyles.Add(csAccountButton)
            dst.GridColumnStyles.Add(csAccount)
            dst.GridColumnStyles.Add(csNote)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next

            Return dst
        End Function
        Public Sub ButtonClick(ByVal e As ButtonColumnEventArgs)
            If e.Column = 2 Then
                Me.ItemButtonClick(e)
            Else
                Me.AcctButtonClick(e)
            End If
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

            AddHandler txtPoDocCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtPoDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpPoDocDate.ValueChanged, AddressOf Me.ChangeProperty

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

            Me.txtPoDocCode.Text = Me.m_entity.PoDocCode
            txtPoDocDate.Text = MinDateToNull(Me.m_entity.PoDocDate, "")
            dtpPoDocDate.Value = MinDateToNow(Me.m_entity.PoDocDate)

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

      'UpdateAmount(True)

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
                    Me.UpdateAmount(False)
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
                        Me.m_entity.ReUpdateDepreciation()  ' คำนวณค่าเสื่อมทั้งหมด เพราะวันที่เปลี่ยน
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
                    Me.m_entity.ReUpdateDepreciation()  ' คำนวณค่าเสื่อมทั้งหมด เพราะวันที่เปลี่ยน

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
                    UpdateAmount(True)
                    dirtyFlag = True
                Case "cmbtaxtype"
                    Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
                    Me.m_entity.TaxType.Value = item.Id
                    UpdateAmount(True)
                    dirtyFlag = True
                Case "txtpodoccode"
                    Me.m_entity.PoDocCode = txtPoDocCode.Text
                    dirtyFlag = True
                Case "txtpodocdate"
                    m_dateSetting = True
                    If Not Me.txtPoDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtPoDocDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtPoDocDate.Text)
                        If Not Me.m_entity.PoDocDate.Equals(theDate) Then
                            dtpPoDocDate.Value = theDate
                            Me.m_entity.PoDocDate = dtpPoDocDate.Value
                            dirtyFlag = True
                        End If
                    Else
                        dtpPoDocDate.Value = Date.Now
                        Me.m_entity.PoDocDate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtppodocdate"
                    If Not Me.m_entity.PoDocDate.Equals(dtpPoDocDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtPoDocDate.Text = MinDateToNull(dtpPoDocDate.Value, "")
                            Me.m_entity.PoDocDate = dtpPoDocDate.Value
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
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount(True)
      Me.m_isInitialized = True

    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("Linenumber") = i + 1
        i += 1
      Next
    End Sub
        Private Sub UpdateAmount(ByVal refresh As Boolean)
            m_isInitialized = False
            If refresh Then
                Me.m_entity.RefreshTaxBase()
            End If
            txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
            txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
            txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
            txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
            txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
            txtDiscountRate.Text = m_entity.Discount.Rate
            txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
            txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)
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
            Dim docDate As Date
            Dim docPerson As New User
            If Not Me.m_entity.LastEditDate = Nothing AndAlso Not Me.m_entity.LastEditDate.Equals(Date.MinValue) Then
                docDate = Me.m_entity.LastEditDate
                docPerson = Me.m_entity.LastEditor
            ElseIf Not Me.m_entity.OriginDate = Nothing AndAlso Not Me.m_entity.OriginDate.Equals(Date.MinValue) Then
                docDate = Me.m_entity.OriginDate
                docPerson = Me.m_entity.Originator
            End If

            Select Case m_entity.Status.Value
                Case -1
                    Me.lblDocStatus.Text = "ยังไม่บันทึก"
                Case 0
                    Me.lblDocStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
                                    " " & m_entity.CancelDate.ToShortTimeString & _
                                    "  โดย:" & docPerson.Name
                Case 1
                    Me.lblDocStatus.Text = ""
                Case 2
                    Me.lblDocStatus.Text = "แก้ไขล่าสุด: " & docDate.ToShortDateString & _
                " " & docDate.ToShortTimeString & _
                "  โดย:" & docPerson.Name
                Case 3
                    Me.lblDocStatus.Text = "ถูกอ้างอิง"
                Case 4
                    Me.lblDocStatus.Text = "ผ่านรายการ: " & docDate.ToShortDateString & _
                 " " & docDate.ToShortTimeString & _
                 "  โดย:" & docPerson.Name
            End Select
            'If m_entity.Canceled Then
            '    Me.StatusBarService.SetMessage("ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
            '    " " & m_entity.CancelDate.ToShortTimeString & _
            '    "  โดย:" & m_entity.CancelPerson.Name)
            'ElseIf m_entity.Edited Then
            '    Me.StatusBarService.SetMessage("แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
            '    " " & m_entity.LastEditDate.ToShortTimeString & _
            '    "  โดย:" & m_entity.LastEditor.Name)
            'ElseIf Me.m_entity.Originated Then
            '    Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
            '    " " & m_entity.OriginDate.ToShortTimeString & _
            '    "  โดย:" & m_entity.Originator.Name)
            'Else
            '    Me.StatusBarService.SetMessage("")
            'End If
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
                    Me.m_entity = CType(Value, AssetSold)
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
            Dim idlist As String
            Me.m_entity.ItemTable.AcceptChanges()
            For Each row As TreeRow In Me.m_entity.ItemTable.Rows
                If Me.m_entity.ValidateRow(row) Then
                    If Not row.IsNull("stocki_entity") Then
                        idlist &= "|" & CStr(row("stocki_entity")) & "|"
                    End If
                End If
            Next
            Return idlist
        End Function
        Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
            If Me.m_entity.FromCostCenter Is Nothing OrElse Not Me.m_entity.FromCostCenter.Originated Then
                Dim myMsgService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                myMsgService.ShowWarning("${res:Global.Error.SpecifyCC}")
                txtFromCostCenterCode.Focus()
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filters(0) As Filter
            filters(0) = New Filter("idlist", GetToolIdList())

            Dim entities As New ArrayList
            Dim obj As New Asset
            obj.Costcenter = Me.m_entity.FromCostCenter
            entities.Add(obj)

            myEntityPanelService.OpenListDialog(New Asset, AddressOf SetItems, filters, entities)
        End Sub
        Private Sub SetItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim newItem As Asset
                Dim newType As Integer = -1

                newItem = New Asset(item.Id)
                newType = newItem.EntityId

                If i = items.Count - 1 Then
                    If Me.m_entity.ItemTable.Childs.Count = 0 Then
                        Me.m_entity.AddBlankRow(1)
                        Me.m_entity.ItemTable.Rows(index)("stocki_entityType") = newType
                        Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
                    Else
                        Me.m_entity.ItemTable.Rows(index)("stocki_entityType") = newType
                        Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
                    End If
                Else
                    Dim mySolditem As New AssetSoldItem
                    mySolditem.AssetSold = Me.m_entity
                    mySolditem.Entity = newItem

                    Me.m_entity.Insert(index, mySolditem)
                    Me.m_entity.ItemTable.Rows(index)("stocki_entityType") = newType
                    Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
                End If
                Me.m_entity.ItemTable.AcceptChanges()
            Next
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.MaxRowIndex Then
                Return
            End If
            Dim item As New AssetSoldItem
            Me.m_entity.Insert(index, item)
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            If index > Me.m_entity.MaxRowIndex Then
                Return
            End If
            Me.m_entity.Remove(index)
            Me.tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
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
                Return (New AssetSold).DetailPanelIcon
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
            Do While Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1
                'เพิ่มแถวจนเต็ม
                Me.m_entity.AddBlankRow(1)
            Loop
            If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
                If Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1 Then
                    'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                    Me.m_entity.AddBlankRow(1)
                End If
            End If
            'Do While Me.m_entity.ItemTable.Rows.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Rows.Count - 2 <> Me.m_entity.MaxRowIndex
            '    'ลบแถวที่ไม่จำเป็น
            '    Me.m_entity.Remove(Me.m_entity.ItemTable.Rows.Count - 1)
            'Loop
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

    End Class
End Namespace