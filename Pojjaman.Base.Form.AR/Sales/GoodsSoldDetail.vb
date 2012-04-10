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
  Public Class GoodsSoldDetail
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
    Friend WithEvents grbDelivery As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblCode As System.Windows.Forms.Label
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
    Friend WithEvents chkShowDiscountInRow As System.Windows.Forms.CheckBox
    Friend WithEvents txtRealGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblAdvanceReceive As System.Windows.Forms.Label
    Friend WithEvents txtAdvanceReceiveAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowAdvanceReceive As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodsSoldDetail))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblCode = New System.Windows.Forms.Label()
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
      Me.lblPoDocCode = New System.Windows.Forms.Label()
      Me.txtPoDocCode = New System.Windows.Forms.TextBox()
      Me.lblPoDocDate = New System.Windows.Forms.Label()
      Me.lblInvoiceCode = New System.Windows.Forms.Label()
      Me.txtInvoiceCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtPoDocDate = New System.Windows.Forms.TextBox()
      Me.txtInvoiceDate = New System.Windows.Forms.TextBox()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
      Me.txtBeforeTax = New System.Windows.Forms.TextBox()
      Me.txtTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtAfterTax = New System.Windows.Forms.TextBox()
      Me.txtDiscountRate = New System.Windows.Forms.TextBox()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.txtTaxBase = New System.Windows.Forms.TextBox()
      Me.txtRealGross = New System.Windows.Forms.TextBox()
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
      Me.txtAdvanceReceiveAmount = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.dtpPoDocDate = New System.Windows.Forms.DateTimePicker()
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
      Me.lblDocStatus = New System.Windows.Forms.Label()
      Me.chkShowDiscountInRow = New System.Windows.Forms.CheckBox()
      Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.lblAdvanceReceive = New System.Windows.Forms.Label()
      Me.ibtnShowAdvanceReceive = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
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
      Me.tgItem.Location = New System.Drawing.Point(8, 160)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(769, 161)
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
      Me.lblCode.TabIndex = 13
      Me.lblCode.Text = "เลขที่ใบส่งของ:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(286, 16)
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
      Me.lblItem.Location = New System.Drawing.Point(8, 137)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(90, 18)
      Me.lblItem.TabIndex = 28
      Me.lblItem.Text = "รายการ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.grbCostCenter.Size = New System.Drawing.Size(377, 68)
      Me.grbCostCenter.TabIndex = 7
      Me.grbCostCenter.TabStop = False
      Me.grbCostCenter.Text = "Cost Center จ่ายของ"
      '
      'ibtnShowFromCostCenter
      '
      Me.ibtnShowFromCostCenter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowFromCostCenter.Location = New System.Drawing.Point(345, 16)
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
      Me.ibtnShowFromCostCenterDialog.Location = New System.Drawing.Point(321, 16)
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
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(154, 40)
      Me.Validator.SetMaxValue(Me.txtFromCCPersonName, "")
      Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(166, 20)
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
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(64, 40)
      Me.Validator.SetMaxValue(Me.txtFromCCPersonCode, "")
      Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonCode, True)
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(89, 20)
      Me.txtFromCCPersonCode.TabIndex = 1
      '
      'txtFromCostCenterName
      '
      Me.txtFromCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(154, 17)
      Me.Validator.SetMaxValue(Me.txtFromCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(166, 20)
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
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(64, 17)
      Me.Validator.SetMaxValue(Me.txtFromCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, True)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(89, 20)
      Me.txtFromCostCenterCode.TabIndex = 0
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.Location = New System.Drawing.Point(8, 38)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(56, 24)
      Me.lblFromCCPerson.TabIndex = 3
      Me.lblFromCCPerson.Text = "From Person:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.Location = New System.Drawing.Point(8, 17)
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
      Me.grbDelivery.Size = New System.Drawing.Size(384, 68)
      Me.grbDelivery.TabIndex = 6
      Me.grbDelivery.TabStop = False
      Me.grbDelivery.Text = "ส่งของให้"
      '
      'ibtnShowCustomer
      '
      Me.ibtnShowCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomer.Location = New System.Drawing.Point(352, 17)
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
      Me.txtCustomerName.Location = New System.Drawing.Point(177, 17)
      Me.Validator.SetMaxValue(Me.txtCustomerName, "")
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(150, 20)
      Me.txtCustomerName.TabIndex = 5
      Me.txtCustomerName.TabStop = False
      '
      'ibtnShowCustomerDialog
      '
      Me.ibtnShowCustomerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(328, 17)
      Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
      Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomerDialog.TabIndex = 8
      Me.ibtnShowCustomerDialog.TabStop = False
      Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.Location = New System.Drawing.Point(8, 17)
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
      Me.txtCustomerCode.Location = New System.Drawing.Point(88, 17)
      Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, True)
      Me.txtCustomerCode.Size = New System.Drawing.Size(89, 20)
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
      Me.lblDay.Location = New System.Drawing.Point(180, 42)
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
      Me.Validator.SetMaxValue(Me.txtCreditPrd, "")
      Me.Validator.SetMinValue(Me.txtCreditPrd, "0")
      Me.txtCreditPrd.Name = "txtCreditPrd"
      Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
      Me.Validator.SetRequired(Me.txtCreditPrd, False)
      Me.txtCreditPrd.Size = New System.Drawing.Size(89, 20)
      Me.txtCreditPrd.TabIndex = 1
      Me.txtCreditPrd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpDueDate
      '
      Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDueDate.Enabled = False
      Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDueDate.Location = New System.Drawing.Point(280, 40)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDueDate.TabIndex = 2
      Me.dtpDueDate.TabStop = False
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.ForeColor = System.Drawing.Color.Black
      Me.lblDueDate.Location = New System.Drawing.Point(200, 41)
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
      Me.txtNote.Location = New System.Drawing.Point(101, 326)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(360, 64)
      Me.txtNote.TabIndex = 9
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(39, 326)
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
      Me.lblPoDocCode.Location = New System.Drawing.Point(8, 39)
      Me.lblPoDocCode.Name = "lblPoDocCode"
      Me.lblPoDocCode.Size = New System.Drawing.Size(88, 22)
      Me.lblPoDocCode.TabIndex = 14
      Me.lblPoDocCode.Text = "PO No. Custumer"
      Me.lblPoDocCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPoDocCode
      '
      Me.Validator.SetDataType(Me.txtPoDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPoDocCode, "")
      Me.txtPoDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPoDocCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPoDocCode, System.Drawing.Color.Empty)
      Me.txtPoDocCode.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMaxValue(Me.txtPoDocCode, "")
      Me.Validator.SetMinValue(Me.txtPoDocCode, "")
      Me.txtPoDocCode.Name = "txtPoDocCode"
      Me.Validator.SetRegularExpression(Me.txtPoDocCode, "")
      Me.Validator.SetRequired(Me.txtPoDocCode, False)
      Me.txtPoDocCode.Size = New System.Drawing.Size(137, 21)
      Me.txtPoDocCode.TabIndex = 2
      Me.txtPoDocCode.TabStop = False
      '
      'lblPoDocDate
      '
      Me.lblPoDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPoDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblPoDocDate.Location = New System.Drawing.Point(236, 40)
      Me.lblPoDocDate.Name = "lblPoDocDate"
      Me.lblPoDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblPoDocDate.TabIndex = 17
      Me.lblPoDocDate.Text = "วันที่:"
      Me.lblPoDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInvoiceCode
      '
      Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceCode.Location = New System.Drawing.Point(387, 40)
      Me.lblInvoiceCode.Name = "lblInvoiceCode"
      Me.lblInvoiceCode.Size = New System.Drawing.Size(96, 18)
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
      Me.txtInvoiceCode.Location = New System.Drawing.Point(483, 40)
      Me.Validator.SetMaxValue(Me.txtInvoiceCode, "")
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
      Me.txtDocDate.Location = New System.Drawing.Point(326, 16)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtDocDate.TabIndex = 1
      '
      'txtPoDocDate
      '
      Me.Validator.SetDataType(Me.txtPoDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtPoDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPoDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPoDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtPoDocDate, System.Drawing.Color.Empty)
      Me.txtPoDocDate.Location = New System.Drawing.Point(276, 40)
      Me.Validator.SetMaxValue(Me.txtPoDocDate, "")
      Me.Validator.SetMinValue(Me.txtPoDocDate, "")
      Me.txtPoDocDate.Name = "txtPoDocDate"
      Me.Validator.SetRegularExpression(Me.txtPoDocDate, "")
      Me.Validator.SetRequired(Me.txtPoDocDate, False)
      Me.txtPoDocDate.Size = New System.Drawing.Size(78, 20)
      Me.txtPoDocDate.TabIndex = 3
      '
      'txtInvoiceDate
      '
      Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.txtInvoiceDate.Location = New System.Drawing.Point(656, 40)
      Me.Validator.SetMaxValue(Me.txtInvoiceDate, "")
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
      Me.txtGross.Location = New System.Drawing.Point(589, 326)
      Me.Validator.SetMaxValue(Me.txtGross, "")
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(81, 20)
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
      Me.txtDiscountAmount.Location = New System.Drawing.Point(589, 350)
      Me.Validator.SetMaxValue(Me.txtDiscountAmount, "")
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.txtDiscountAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(187, 20)
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
      Me.txtBeforeTax.Location = New System.Drawing.Point(590, 398)
      Me.Validator.SetMaxValue(Me.txtBeforeTax, "")
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(187, 20)
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
      Me.txtTaxAmount.Location = New System.Drawing.Point(590, 470)
      Me.Validator.SetMaxValue(Me.txtTaxAmount, "")
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(81, 20)
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
      Me.txtAfterTax.Location = New System.Drawing.Point(590, 494)
      Me.Validator.SetMaxValue(Me.txtAfterTax, "")
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(187, 20)
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
      Me.txtDiscountRate.Location = New System.Drawing.Point(525, 350)
      Me.Validator.SetMaxValue(Me.txtDiscountRate, "")
      Me.Validator.SetMinValue(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Name = "txtDiscountRate"
      Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
      Me.Validator.SetRequired(Me.txtDiscountRate, False)
      Me.txtDiscountRate.Size = New System.Drawing.Size(64, 20)
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
      Me.txtTaxRate.Location = New System.Drawing.Point(722, 446)
      Me.Validator.SetMaxValue(Me.txtTaxRate, "")
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
      Me.txtTaxBase.Location = New System.Drawing.Point(590, 422)
      Me.Validator.SetMaxValue(Me.txtTaxBase, "")
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(81, 20)
      Me.txtTaxBase.TabIndex = 34
      Me.txtTaxBase.TabStop = False
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealGross
      '
      Me.txtRealGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.txtRealGross.Location = New System.Drawing.Point(693, 326)
      Me.Validator.SetMaxValue(Me.txtRealGross, "")
      Me.Validator.SetMinValue(Me.txtRealGross, "")
      Me.txtRealGross.Name = "txtRealGross"
      Me.Validator.SetRegularExpression(Me.txtRealGross, "")
      Me.Validator.SetRequired(Me.txtRealGross, False)
      Me.txtRealGross.Size = New System.Drawing.Size(84, 20)
      Me.txtRealGross.TabIndex = 45
      Me.txtRealGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxAmount
      '
      Me.txtRealTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(693, 470)
      Me.Validator.SetMaxValue(Me.txtRealTaxAmount, "")
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(84, 20)
      Me.txtRealTaxAmount.TabIndex = 47
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxBase
      '
      Me.txtRealTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(693, 422)
      Me.Validator.SetMaxValue(Me.txtRealTaxBase, "")
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(84, 20)
      Me.txtRealTaxBase.TabIndex = 46
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAdvanceReceiveAmount
      '
      Me.txtAdvanceReceiveAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAdvanceReceiveAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAdvanceReceiveAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvanceReceiveAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvanceReceiveAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvanceReceiveAmount, System.Drawing.Color.Empty)
      Me.txtAdvanceReceiveAmount.Location = New System.Drawing.Point(589, 374)
      Me.Validator.SetMaxValue(Me.txtAdvanceReceiveAmount, "")
      Me.Validator.SetMinValue(Me.txtAdvanceReceiveAmount, "")
      Me.txtAdvanceReceiveAmount.Name = "txtAdvanceReceiveAmount"
      Me.txtAdvanceReceiveAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAdvanceReceiveAmount, "")
      Me.Validator.SetRequired(Me.txtAdvanceReceiveAmount, False)
      Me.txtAdvanceReceiveAmount.Size = New System.Drawing.Size(187, 20)
      Me.txtAdvanceReceiveAmount.TabIndex = 52
      Me.txtAdvanceReceiveAmount.TabStop = False
      Me.txtAdvanceReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(326, 16)
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
      Me.dtpPoDocDate.Location = New System.Drawing.Point(276, 40)
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
      Me.dtpInvoiceDate.Location = New System.Drawing.Point(656, 40)
      Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
      Me.dtpInvoiceDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpInvoiceDate.TabIndex = 23
      Me.dtpInvoiceDate.TabStop = False
      '
      'lblInvoiceDate
      '
      Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceDate.Location = New System.Drawing.Point(624, 40)
      Me.lblInvoiceDate.Name = "lblInvoiceDate"
      Me.lblInvoiceDate.Size = New System.Drawing.Size(32, 18)
      Me.lblInvoiceDate.TabIndex = 22
      Me.lblInvoiceDate.Text = "วันที่:"
      Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(95, 135)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 24
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(119, 135)
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
      Me.lblTaxAmount.Location = New System.Drawing.Point(509, 470)
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
      Me.lblAfterTax.Location = New System.Drawing.Point(493, 494)
      Me.lblAfterTax.Name = "lblAfterTax"
      Me.lblAfterTax.Size = New System.Drawing.Size(96, 18)
      Me.lblAfterTax.TabIndex = 41
      Me.lblAfterTax.Text = "ยอดสุทธิ :"
      Me.lblAfterTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDiscountAmount
      '
      Me.lblDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscountAmount.Location = New System.Drawing.Point(469, 350)
      Me.lblDiscountAmount.Name = "lblDiscountAmount"
      Me.lblDiscountAmount.Size = New System.Drawing.Size(56, 18)
      Me.lblDiscountAmount.TabIndex = 29
      Me.lblDiscountAmount.Text = "Discount:"
      Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(469, 398)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(120, 18)
      Me.lblBeforeTax.TabIndex = 43
      Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
      Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGross.BackColor = System.Drawing.Color.Transparent
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.Location = New System.Drawing.Point(509, 326)
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
      Me.cmbTaxType.Location = New System.Drawing.Point(590, 446)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
      Me.cmbTaxType.TabIndex = 11
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(515, 446)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(74, 18)
      Me.lblTaxType.TabIndex = 27
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(660, 446)
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
      Me.lblTaxBase.Location = New System.Drawing.Point(445, 422)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(144, 18)
      Me.lblTaxBase.TabIndex = 39
      Me.lblTaxBase.Text = "Goods/Service Amount :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPercent
      '
      Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(760, 446)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 38
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(232, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 15
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'chkAutoRunVat
      '
      Me.chkAutoRunVat.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutoRunVat.Image = CType(resources.GetObject("chkAutoRunVat.Image"), System.Drawing.Image)
      Me.chkAutoRunVat.Location = New System.Drawing.Point(595, 40)
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
      Me.lblDocStatus.Visible = False
      '
      'chkShowDiscountInRow
      '
      Me.chkShowDiscountInRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowDiscountInRow.Location = New System.Drawing.Point(430, 14)
      Me.chkShowDiscountInRow.Name = "chkShowDiscountInRow"
      Me.chkShowDiscountInRow.Size = New System.Drawing.Size(224, 24)
      Me.chkShowDiscountInRow.TabIndex = 44
      Me.chkShowDiscountInRow.TabStop = False
      Me.chkShowDiscountInRow.Text = "พิมพ์ส่วนลดท้ายบิลในรายการสุดท้าย"
      '
      'ibtnResetGross
      '
      Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetGross.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetGross.Location = New System.Drawing.Point(669, 326)
      Me.ibtnResetGross.Name = "ibtnResetGross"
      Me.ibtnResetGross.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetGross.TabIndex = 48
      Me.ibtnResetGross.TabStop = False
      Me.ibtnResetGross.ThemedImage = CType(resources.GetObject("ibtnResetGross.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxAmount
      '
      Me.ibtnResetTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(669, 470)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 50
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(669, 422)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 49
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(96, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(137, 21)
      Me.cmbCode.TabIndex = 0
      '
      'lblAdvanceReceive
      '
      Me.lblAdvanceReceive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAdvanceReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvanceReceive.Location = New System.Drawing.Point(485, 374)
      Me.lblAdvanceReceive.Name = "lblAdvanceReceive"
      Me.lblAdvanceReceive.Size = New System.Drawing.Size(80, 18)
      Me.lblAdvanceReceive.TabIndex = 51
      Me.lblAdvanceReceive.Text = "มัดจำ :"
      Me.lblAdvanceReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowAdvanceReceive
      '
      Me.ibtnShowAdvanceReceive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnShowAdvanceReceive.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAdvanceReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAdvanceReceive.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAdvanceReceive.Location = New System.Drawing.Point(565, 374)
      Me.ibtnShowAdvanceReceive.Name = "ibtnShowAdvanceReceive"
      Me.ibtnShowAdvanceReceive.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAdvanceReceive.TabIndex = 53
      Me.ibtnShowAdvanceReceive.TabStop = False
      Me.ibtnShowAdvanceReceive.ThemedImage = CType(resources.GetObject("ibtnShowAdvanceReceive.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(252, 16)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 337
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      '
      'GoodsSoldDetail
      '
      Me.Controls.Add(Me.ibtnCopyMe)
      Me.Controls.Add(Me.lblAdvanceReceive)
      Me.Controls.Add(Me.txtAdvanceReceiveAmount)
      Me.Controls.Add(Me.ibtnShowAdvanceReceive)
      Me.Controls.Add(Me.cmbCode)
      Me.Controls.Add(Me.txtRealGross)
      Me.Controls.Add(Me.ibtnResetGross)
      Me.Controls.Add(Me.txtRealTaxAmount)
      Me.Controls.Add(Me.ibtnResetTaxAmount)
      Me.Controls.Add(Me.txtRealTaxBase)
      Me.Controls.Add(Me.ibtnResetTaxBase)
      Me.Controls.Add(Me.chkShowDiscountInRow)
      Me.Controls.Add(Me.chkAutoRunVat)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.txtGross)
      Me.Controls.Add(Me.lblDiscountAmount)
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
      Me.Controls.Add(Me.lblPercent)
      Me.Name = "GoodsSoldDetail"
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

#Region "Members"
    Private m_entity As GoodsSold
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dt As TreeTable = GoodsSold.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf GSItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDelivery.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbCostCenter.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "GoodsSold"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'Stock Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "stocki_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "stocki_linenumber"

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("stocki_entityType" _
      , CodeDescription.GetCodeList("stocki_enitytype" _
      , "code_value not in (28)") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.TypeHeaderText}")
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      Dim csName As New TreeTextColumn
      csName.MappingName = "stocki_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      'AddHandler csUnitButton.Click, AddressOf ButtonClick

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "stocki_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      Dim csStockQty As New TreeTextColumn
      csStockQty.MappingName = "StockQty"
      csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.StockQtyHeaderText}")
      csStockQty.NullText = ""
      csStockQty.DataAlignment = HorizontalAlignment.Right
      csStockQty.Format = "#,###.##"
      csStockQty.ReadOnly = True

      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "stocki_unitprice"
      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.UnitpriceHeaderText}")
      csUnitPRice.NullText = ""
      csUnitPRice.TextBox.Name = "stocki_unitprice"
      csUnitPRice.DataAlignment = HorizontalAlignment.Right
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csDiscount As New TreeTextColumn
      csDiscount.MappingName = "stocki_discrate"
      csDiscount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.DiscountHeaderText}")
      csDiscount.NullText = ""
      csDiscount.TextBox.Name = "stocki_discrate"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"

      Dim csAccountCode As New TreeTextColumn
      csAccountCode.MappingName = "AccountCode"
      csAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.AccountCodeHeaderText}")
      csAccountCode.NullText = ""
      csAccountCode.TextBox.Name = "AccountCode"

      Dim csAccount As New TreeTextColumn
      csAccount.MappingName = "Account"
      csAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.AccountHeaderText}")
      csAccount.NullText = ""
      csAccount.ReadOnly = True
      csAccount.TextBox.Name = "Account"

      Dim csAccountButton As New DataGridButtonColumn
      csAccountButton.MappingName = "AccountButton"
      csAccountButton.HeaderText = ""
      csAccountButton.NullText = ""
      AddHandler csAccountButton.Click, AddressOf ButtonClick

      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "stocki_unvatable"
      csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.UnVatableHeaderText}")
      csVatable.Width = 100
      csVatable.ReadOnly = False
      csVatable.InvisibleWhenUnspcified = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "stocki_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "stocki_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      'dst.GridColumnStyles.Add(csStockQty)
      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csDiscount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csAccountCode)
      dst.GridColumnStyles.Add(csAccountButton)
      dst.GridColumnStyles.Add(csAccount)
      dst.GridColumnStyles.Add(csVatable)
      dst.GridColumnStyles.Add(csNote)

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Public Sub ButtonClick(ByVal e As ButtonColumnEventArgs)
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
    Private ReadOnly Property CurrentItem() As GoodsSoldItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is GoodsSoldItem Then
          Return Nothing
        End If
        Return CType(row.Tag, GoodsSoldItem)
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
      Dim doc As GoodsSoldItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New GoodsSoldItem
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
            If IsNumeric(e.ProposedValue.ToString) Then
              Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              doc.Qty = value
            End If
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
            If IsNumeric(e.ProposedValue.ToString) Then
              Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              doc.UnitPrice = value
            End If
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
    Private Sub GSItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity.Status.Value = 0 _
      OrElse m_entityRefed = 1 _
      OrElse Me.m_entity.Receive.Status.Value = 0 _
      OrElse Me.m_entity.Receive.Status.Value >= 3 _
      Then
        For Each ctrl As Control In Me.grbDelivery.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.grbCostCenter.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          'Bug #1332 เอกสารถึงแม้จะถูกอ้างอิงแล้ว ผังบัญชีให้สามารถแก้ไขผังบัญชีได้ เหมือนหน้าซื้อสินค้า/บริการ ไม่ให้ log ผังบัญชีค่ะ
          If colStyle.MappingName.ToLower = "accountcode" _
          Or colStyle.MappingName.ToLower = "accountbutton" Then
            colStyle.ReadOnly = False
          Else
            colStyle.ReadOnly = True
          End If
        Next
        ibtnShowAdvanceReceive.Enabled = True
      Else
        For Each ctrl As Control In Me.grbDelivery.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.grbCostCenter.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
      Me.chkShowDiscountInRow.Enabled = True
      Me.ibtnCopyMe.Enabled = True
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
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblNote}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblItem}")
      Me.grbDelivery.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.grbDelivery}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblCode}")
      Me.lblInvoiceCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblInvoiceCode}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblDocDate}")
      Me.lblInvoiceDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblInvoiceDate}")
      Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblTaxAmount}")
      Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblAfterTax}")
      Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblDiscountAmount}")
      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblBeforeTax}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblGross}")
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblTaxType}")
      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblTaxRate}")
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblTaxBase}")
      Me.lblPercent.Text = Me.StringParserService.Parse("${res:Global.PercenText}")
      Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblCreditPrd}")
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")
      ''
      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblFromCostCenter}")
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.txtFromCostCenterCodeAlert}"))
      ''
      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblCustomer}")
      Me.Validator.SetDisplayName(Me.txtCustomerCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.txtCustomerCodeAlert}"))

      Me.grbCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.grbCostCenter}")
      ''
      Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblFromCCPerson}")
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.txtFromCCPersonCodeAlert}"))

      Me.lblPoDocCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblPoDocCode}")
      Me.lblPoDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblPoDocDate}")
      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblDueDate}")
      Me.lblAdvanceReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.lblAdvanceReceive}")

      Me.chkShowDiscountInRow.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsSoldDetail.chkShowDiscountInRow}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

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

      AddHandler chkShowDiscountInRow.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealGross.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealGross.Validated, AddressOf Me.TextHandler
    End Sub
    Private m_oldInvoiceCode As String = ""
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

      txtCreditPrd.Text = m_entity.CreditPeriod.ToString
      'm_oldCode = m_entity.Code
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
        'If myVat.ItemCollection.Count <= 0 Then
        '  Me.m_entity.Vat.ItemCollection.Add(New VatItem)
        'End If
        VatInputEnabled(True)
        If myVat.ItemCollection.Count > 0 Then
          myVatitem = myVat.ItemCollection(0)
          If myVat.AutoGen Then
            Me.txtInvoiceCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(myVatitem.EntityId)
          Else
            Me.txtInvoiceCode.Text = myVatitem.Code
          End If
          Me.txtInvoiceDate.Text = MinDateToNull(myVatitem.DocDate, "")
          Me.dtpInvoiceDate.Value = MinDateToNow(myVatitem.DocDate)
        End If
      End If
      m_oldInvoiceCode = Me.txtInvoiceCode.Text
      Me.chkAutoRunVat.Checked = Me.m_entity.Vat.AutoGen
      Me.UpdateVatAutogenStatus()



      txtCustomerCode.Text = m_entity.Customer.Code
      txtCustomerName.Text = m_entity.Customer.Name
      txtNote.Text = m_entity.Note

      Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)

      If m_entity.TaxType.Value = 0 OrElse m_entity.TaxType.Value = 1 Then
        txtAdvanceReceiveAmount.Text = Configuration.FormatToString(m_entity.AdvanceReceiveItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        txtAdvanceReceiveAmount.Text = Configuration.FormatToString(m_entity.AdvanceReceiveItemCollection.GetAmount, DigitConfig.Price)
      End If

      txtFromCostCenterCode.Text = m_entity.FromCostCenter.Code
      txtFromCostCenterName.Text = m_entity.FromCostCenter.Name

      Me.txtFromCCPersonCode.Text = m_entity.FromCostCenterPerson.Code
      txtFromCCPersonName.Text = m_entity.FromCostCenterPerson.Name

      Me.chkShowDiscountInRow.Checked = Me.m_entity.ShowFinalDiscountInRow

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next

      RefreshDocs()

      'If Me.m_entity.NoVat Then
      '  Me.m_entity.Vat.ItemCollection.Clear()
      'End If

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
        'Me.Validator.SetRequired(Me.txtInvoiceCode, True)
        Me.Validator.SetRequired(Me.txtInvoiceCode, False)
        If Me.m_isInitialized Then
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
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount(True)
      Me.m_isInitialized = True
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
        Case "cmbcode"
          Me.m_entity.Code = cmbCode.Text
          'เพิ่ม AutoCode
          If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
            Me.m_entity.OnGlChanged()
          End If
          'MessageBox.Show(Me.m_entity.AutoCodeFormat.GLFormat.Id.ToString)
          dirtyFlag = True
        Case "chkshowdiscountinrow"
          Me.m_entity.ShowFinalDiscountInRow = chkShowDiscountInRow.Checked
          'ไม่ต้อง dirty
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          Me.m_entity.Receive.Note = txtNote.Text
          Me.m_entity.JournalEntry.Note = txtNote.Text
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
            'Dim novat As Boolean = Me.txtInvoiceCode.Text.Length = 0
            'Me.m_entity.SetNoVat(novat)
            If Me.txtInvoiceCode.Text.Trim.Length = 0 Then
              Me.m_entity.SetNoVat(True)
              Me.VatInputSetRequireDate(False)
              Me.txtInvoiceDate.Text = ""
              Me.dtpInvoiceDate.Value = Now
            Else
              Me.VatInputSetRequireDate(True)
              Me.m_entity.SetNoVat()
            End If

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
          dirtyFlag = CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case Else
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub VatInputSetRequireDate(ByVal require As Boolean)
      If require Then
        Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.DateTimeType)
        Me.Validator.SetRequired(Me.txtInvoiceDate, True)
      Else
        Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.StringType)
        Me.Validator.SetRequired(Me.txtInvoiceDate, False)
      End If
    End Sub
    'Private Sub SetVatToNoDoc()
    '  Dim flag As Boolean = Me.m_isInitialized
    '  Me.m_isInitialized = False
    '  Me.m_entity.Vat.ItemCollection.Clear()
    '  Me.txtInvoiceCode.Text = ""
    '  Me.txtInvoiceDate.Text = ""
    '  Me.dtpInvoiceDate.Value = Now
    '  Me.m_isInitialized = flag
    'End Sub
    Private Sub SetVatToOneDoc()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_entity.Vat.SetVatToOneDoc(txtInvoiceCode _
      , txtInvoiceDate _
      , dtpInvoiceDate _
      , AddressOf UpdateVatAutogenStatus)
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
      txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
      txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
      txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
      txtDiscountRate.Text = m_entity.Discount.Rate
      txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
      txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)

      txtRealGross.Text = Configuration.FormatToString(m_entity.RealGross, DigitConfig.Price)
      txtRealTaxAmount.Text = Configuration.FormatToString(m_entity.RealTaxAmount, DigitConfig.Price)
      txtRealTaxBase.Text = Configuration.FormatToString(m_entity.RealTaxBase, DigitConfig.Price)
      'txtAdvanceReceiveAmount.Text = Configuration.FormatToString(m_entity.AdvanceReceiveItemCollection.GetAmount, DigitConfig.Price)

      If m_entity.TaxType.Value = 0 OrElse m_entity.TaxType.Value = 1 Then
        txtAdvanceReceiveAmount.Text = Configuration.FormatToString(m_entity.AdvanceReceiveItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        txtAdvanceReceiveAmount.Text = Configuration.FormatToString(m_entity.AdvanceReceiveItemCollection.GetAmount, DigitConfig.Price)
      End If

      m_isInitialized = True
      SetVatInputAfterAmountChange()
    End Sub
    Private Sub SetVatInputAfterAmountChange()
      If Me.m_entity.TaxType.Value = 0 Then
        'ไม่มี Vat
        'SetVatToNoDoc()
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
        End If
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          If Not Me.m_entity Is Nothing Then
            Me.m_entity.ClearReference()
          End If
          Me.m_entity = Nothing
          Me.m_entity = CType(Value, GoodsSold)
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
    'Private m_oldCode As String = ""
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
        'm_oldCode = Me.cmbCode.Text
        'Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_entity.Code
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

        'Me.txtInvoiceCode.Text = m_oldInvoiceCode
        'Hack: set Code เป็น "" เอง
        'vi.Code = ""
        vi.Code = Me.txtInvoiceCode.Text
        If Me.txtInvoiceDate.Text.Trim.Length = 0 Then
          Me.txtInvoiceDate.Text = Now.ToShortDateString
          Me.dtpInvoiceDate.Value = Now
          vi.DocDate = Now
        Else
          vi.DocDate = Me.dtpInvoiceDate.Value
        End If
        'Hack: set Code เป็น "" เอง
        'vi.Code = ""
        vi.AutoGen = True
        Me.m_entity.Vat.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtInvoiceCode, True)
        Me.Validator.SetRequired(Me.txtInvoiceCode, False)
        Me.txtInvoiceCode.Text = m_oldInvoiceCode
        Me.txtInvoiceCode.ReadOnly = False
        Me.m_entity.Vat.AutoGen = False
        vi.AutoGen = False
      End If
    End Sub
    Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim doc As GoodsSoldItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New GoodsSoldItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAcct)
    End Sub
    Private Sub SetAcct(ByVal acct As ISimpleEntity)
      Me.m_treeManager.SelectedRow("AccountCode") = acct.Code
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As GoodsSoldItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New GoodsSoldItem
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
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As GoodsSoldItem = Me.CurrentItem
      Dim noDoc As Boolean = False
      If doc Is Nothing Then
        doc = New GoodsSoldItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
        noDoc = True
      End If
      If noDoc Then
        Dim entities(3) As ISimpleEntity
        Dim lci As New LCIForSelection
        lci.CC = Me.m_entity.FromCostCenter
        lci.FromWip = False
        entities(0) = lci
        entities(1) = New Labor
        entities(2) = New EqCost
        entities(3) = New Tool
        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems)
      Else
        Select Case doc.ItemType.Value
          Case 0 'Blank
            Return
          Case 19 'Tool
            myEntityPanelService.OpenListDialog(New Tool, AddressOf SetItems)
          Case 88 'Labor
            myEntityPanelService.OpenListDialog(New Labor, AddressOf SetItems)
          Case 89 'EqCost
            myEntityPanelService.OpenListDialog(New EqCost, AddressOf SetItems)
          Case 42 'LCI
            If Me.m_entity Is Nothing Then
              Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity.FromCostCenter Is Nothing OrElse Not Me.m_entity.FromCostCenter.Originated Then
              msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.Message.InputFromCC}")
              Return
            End If
            Dim entity As New LCIForSelection
            entity.CC = Me.m_entity.FromCostCenter
            entity.FromWip = False
            myEntityPanelService.OpenListDialog(entity, AddressOf SetItems)
          Case Else

        End Select
      End If
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As IHasName
        Dim newType As Integer = -1
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.lciitem"
            newItem = New LCIItem(item.Id)
            newType = 42
          Case "longkong.pojjaman.businesslogic.tool"
            newItem = New Tool(item.Id)
            newType = 19
          Case "longkong.pojjaman.businesslogic.labor"
            newItem = New Labor(item.Id)
            newType = 88
          Case "longkong.pojjaman.businesslogic.eqcost"
            newItem = New EqCost(item.Id)
            newType = 89
        End Select
        If i = items.Count - 1 Then
          If Me.m_entity.ItemCollection.Count = 0 Then
            Dim doc As New GoodsSoldItem
            Me.m_entity.ItemCollection.Add(doc)
            doc.ItemType.Value = newType
            doc.Entity = newItem
          Else
            Dim doc As New GoodsSoldItem
            If Not Me.CurrentItem Is Nothing Then
              doc = Me.CurrentItem
            Else
              Me.m_entity.ItemCollection.Add(doc)
            End If
            doc.ItemType.Value = newType
            doc.Entity = newItem
          End If
        Else
          Dim doc As New GoodsSoldItem
          Me.m_entity.ItemCollection.Insert(index, doc)
          doc.ItemType = New ItemType(newType)
          doc.Entity = newItem
        End If
      Next
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As GoodsSoldItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim theItem As New GoodsSoldItem
      theItem.Entity = newItem
      theItem.ItemType = New ItemType(0)
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc), theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim doc As GoodsSoldItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Me.m_entity.ItemCollection.Remove(doc)
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("stocki_linenumber") = i + 1
        i += 1
      Next
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
        Return (New GoodsSold).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      For i As Integer = 2 To Me.WorkbenchWindow.SubViewContents.Count - 1
        If TypeOf Me.WorkbenchWindow.SubViewContents(i) Is AbstractEntityDetailPanelView Then
          If TypeOf Me.WorkbenchWindow.SubViewContents(i) Is ISetNothingEntity Then
            CType(Me.WorkbenchWindow.SubViewContents(i), ISetNothingEntity).SetNothing()
          End If
          'Dim myView As AbstractEntityDetailPanelView = CType(Me.WorkbenchWindow.SubViewContents(i), AbstractEntityDetailPanelView)
          'myView.Entity = newEntity
        End If
      Next
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
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
      Me.txtCreditPrd.Text = Me.m_entity.Customer.CreditPeriod
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
      myEntityPanelService.OpenPanel(New Customer)
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
          Or CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    ' AdvanceReceive
    Private Sub ibtnShowAdvanceReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAdvanceReceive.Click
      Dim dlg As New AdvanceReceiveSelection(Me.m_entity)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        forceUpdateTaxBase = True
        forceUpdateTaxAmount = True
        forceUpdateGross = True
        UpdateAmount(True)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
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

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

  End Class
End Namespace