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
  Public Class GoodsReceiptForOperationDetail
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
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GoodsReceiptForOperationDetail))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.lblItem = New System.Windows.Forms.Label
      Me.grbReceive = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.cmbDocType = New System.Windows.Forms.ComboBox
      Me.lblDocType = New System.Windows.Forms.Label
      Me.txtToCCPersonName = New System.Windows.Forms.TextBox
      Me.txtToCCPersonCode = New System.Windows.Forms.TextBox
      Me.ibtShowToCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox
      Me.ibtnShowToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox
      Me.lblToCCPerson = New System.Windows.Forms.Label
      Me.lblToCostCenter = New System.Windows.Forms.Label
      Me.ibtnShowToCCPerson = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowToCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbDelivery = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
      Me.lblDueDate = New System.Windows.Forms.Label
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
      Me.lblPOCode = New System.Windows.Forms.Label
      Me.lblPODate = New System.Windows.Forms.Label
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
      Me.txtPODate = New System.Windows.Forms.TextBox
      Me.txtInvoiceDate = New System.Windows.Forms.TextBox
      Me.txtPOCode = New System.Windows.Forms.TextBox
      Me.ibtnShowPODialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.dtpDeliveryDocDate = New System.Windows.Forms.DateTimePicker
      Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker
      Me.lblInvoiceDate = New System.Windows.Forms.Label
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblTaxAmount = New System.Windows.Forms.Label
      Me.ibtnEnableVatInput = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.cmbCode = New System.Windows.Forms.ComboBox
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbReceive.SuspendLayout()
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
      Me.tgItem.Location = New System.Drawing.Point(8, 208)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 304)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 19
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
      Me.lblCode.Text = "เลขที่ใบรับของ:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(240, 16)
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
      Me.lblItem.Location = New System.Drawing.Point(8, 192)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 29
      Me.lblItem.Text = "รายการรับของ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbReceive
      '
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
      Me.grbReceive.Location = New System.Drawing.Point(400, 64)
      Me.grbReceive.Name = "grbReceive"
      Me.grbReceive.Size = New System.Drawing.Size(368, 96)
      Me.grbReceive.TabIndex = 9
      Me.grbReceive.TabStop = False
      Me.grbReceive.Text = "รับของ"
      '
      'cmbDocType
      '
      Me.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDocType.Location = New System.Drawing.Point(104, 64)
      Me.cmbDocType.Name = "cmbDocType"
      Me.cmbDocType.Size = New System.Drawing.Size(248, 21)
      Me.cmbDocType.TabIndex = 17
      '
      'lblDocType
      '
      Me.lblDocType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocType.Location = New System.Drawing.Point(8, 64)
      Me.lblDocType.Name = "lblDocType"
      Me.lblDocType.Size = New System.Drawing.Size(96, 18)
      Me.lblDocType.TabIndex = 11
      Me.lblDocType.Text = "ซื้อเพื่อ:"
      Me.lblDocType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToCCPersonName
      '
      Me.txtToCCPersonName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtToCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.txtToCCPersonName.Location = New System.Drawing.Point(176, 40)
      Me.Validator.SetMaxValue(Me.txtToCCPersonName, "")
      Me.Validator.SetMinValue(Me.txtToCCPersonName, "")
      Me.txtToCCPersonName.Name = "txtToCCPersonName"
      Me.txtToCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCCPersonName, "")
      Me.Validator.SetRequired(Me.txtToCCPersonName, False)
      Me.txtToCCPersonName.Size = New System.Drawing.Size(128, 20)
      Me.txtToCCPersonName.TabIndex = 5
      Me.txtToCCPersonName.TabStop = False
      Me.txtToCCPersonName.Text = ""
      '
      'txtToCCPersonCode
      '
      Me.Validator.SetDataType(Me.txtToCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.txtToCCPersonCode.Location = New System.Drawing.Point(104, 40)
      Me.Validator.SetMaxValue(Me.txtToCCPersonCode, "")
      Me.Validator.SetMinValue(Me.txtToCCPersonCode, "")
      Me.txtToCCPersonCode.Name = "txtToCCPersonCode"
      Me.Validator.SetRegularExpression(Me.txtToCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtToCCPersonCode, True)
      Me.txtToCCPersonCode.Size = New System.Drawing.Size(72, 20)
      Me.txtToCCPersonCode.TabIndex = 15
      Me.txtToCCPersonCode.Text = ""
      '
      'ibtShowToCostCenter
      '
      Me.ibtShowToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtShowToCostCenter.Image = CType(resources.GetObject("ibtShowToCostCenter.Image"), System.Drawing.Image)
      Me.ibtShowToCostCenter.Location = New System.Drawing.Point(328, 15)
      Me.ibtShowToCostCenter.Name = "ibtShowToCostCenter"
      Me.ibtShowToCostCenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtShowToCostCenter.TabIndex = 9
      Me.ibtShowToCostCenter.TabStop = False
      Me.ibtShowToCostCenter.ThemedImage = CType(resources.GetObject("ibtShowToCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCostCenterName
      '
      Me.txtToCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(176, 16)
      Me.Validator.SetMaxValue(Me.txtToCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.txtToCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(128, 20)
      Me.txtToCostCenterName.TabIndex = 4
      Me.txtToCostCenterName.TabStop = False
      Me.txtToCostCenterName.Text = ""
      '
      'ibtnShowToCostCenterDialog
      '
      Me.ibtnShowToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCostCenterDialog.Image = CType(resources.GetObject("ibtnShowToCostCenterDialog.Image"), System.Drawing.Image)
      Me.ibtnShowToCostCenterDialog.Location = New System.Drawing.Point(304, 15)
      Me.ibtnShowToCostCenterDialog.Name = "ibtnShowToCostCenterDialog"
      Me.ibtnShowToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCostCenterDialog.TabIndex = 14
      Me.ibtnShowToCostCenterDialog.TabStop = False
      Me.ibtnShowToCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtToCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMaxValue(Me.txtToCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, True)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(72, 20)
      Me.txtToCostCenterCode.TabIndex = 13
      Me.txtToCostCenterCode.Text = ""
      '
      'lblToCCPerson
      '
      Me.lblToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCPerson.Location = New System.Drawing.Point(8, 40)
      Me.lblToCCPerson.Name = "lblToCCPerson"
      Me.lblToCCPerson.Size = New System.Drawing.Size(96, 18)
      Me.lblToCCPerson.TabIndex = 3
      Me.lblToCCPerson.Text = "ผู้รับ:"
      Me.lblToCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblToCostCenter
      '
      Me.lblToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCostCenter.Location = New System.Drawing.Point(8, 16)
      Me.lblToCostCenter.Name = "lblToCostCenter"
      Me.lblToCostCenter.Size = New System.Drawing.Size(96, 18)
      Me.lblToCostCenter.TabIndex = 2
      Me.lblToCostCenter.Text = "คลัง:"
      Me.lblToCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowToCCPerson
      '
      Me.ibtnShowToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPerson.Image = CType(resources.GetObject("ibtnShowToCCPerson.Image"), System.Drawing.Image)
      Me.ibtnShowToCCPerson.Location = New System.Drawing.Point(328, 39)
      Me.ibtnShowToCCPerson.Name = "ibtnShowToCCPerson"
      Me.ibtnShowToCCPerson.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPerson.TabIndex = 8
      Me.ibtnShowToCCPerson.TabStop = False
      Me.ibtnShowToCCPerson.ThemedImage = CType(resources.GetObject("ibtnShowToCCPerson.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowToCCPersonDialog
      '
      Me.ibtnShowToCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowToCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowToCCPersonDialog.Image = CType(resources.GetObject("ibtnShowToCCPersonDialog.Image"), System.Drawing.Image)
      Me.ibtnShowToCCPersonDialog.Location = New System.Drawing.Point(304, 39)
      Me.ibtnShowToCCPersonDialog.Name = "ibtnShowToCCPersonDialog"
      Me.ibtnShowToCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowToCCPersonDialog.TabIndex = 16
      Me.ibtnShowToCCPersonDialog.TabStop = False
      Me.ibtnShowToCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbDelivery
      '
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
      Me.grbDelivery.Location = New System.Drawing.Point(8, 64)
      Me.grbDelivery.Name = "grbDelivery"
      Me.grbDelivery.Size = New System.Drawing.Size(384, 88)
      Me.grbDelivery.TabIndex = 7
      Me.grbDelivery.TabStop = False
      Me.grbDelivery.Text = "ส่งของ"
      '
      'dtpDueDate
      '
      Me.dtpDueDate.Enabled = False
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDueDate.Location = New System.Drawing.Point(216, 40)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(104, 20)
      Me.dtpDueDate.TabIndex = 99
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.ForeColor = System.Drawing.Color.Black
      Me.lblDueDate.Location = New System.Drawing.Point(144, 40)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(72, 18)
      Me.lblDueDate.TabIndex = 16
      Me.lblDueDate.Text = "ครบกำหนด:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowSupplier
      '
      Me.ibtnShowSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplier.Image = CType(resources.GetObject("ibtnShowSupplier.Image"), System.Drawing.Image)
      Me.ibtnShowSupplier.Location = New System.Drawing.Point(344, 16)
      Me.ibtnShowSupplier.Name = "ibtnShowSupplier"
      Me.ibtnShowSupplier.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplier.TabIndex = 0
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
      Me.txtSupplierName.Location = New System.Drawing.Point(152, 16)
      Me.Validator.SetMaxValue(Me.txtSupplierName, "")
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(168, 20)
      Me.txtSupplierName.TabIndex = 8
      Me.txtSupplierName.TabStop = False
      Me.txtSupplierName.Text = ""
      '
      'ibtnShowSupplierDialog
      '
      Me.ibtnShowSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowSupplierDialog.Image = CType(resources.GetObject("ibtnShowSupplierDialog.Image"), System.Drawing.Image)
      Me.ibtnShowSupplierDialog.Location = New System.Drawing.Point(320, 16)
      Me.ibtnShowSupplierDialog.Name = "ibtnShowSupplierDialog"
      Me.ibtnShowSupplierDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowSupplierDialog.TabIndex = 10
      Me.ibtnShowSupplierDialog.TabStop = False
      Me.ibtnShowSupplierDialog.ThemedImage = CType(resources.GetObject("ibtnShowSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSupplier
      '
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(8, 16)
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
      Me.txtSupplierCode.Location = New System.Drawing.Point(96, 16)
      Me.Validator.SetMaxValue(Me.txtSupplierCode, "")
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, True)
      Me.txtSupplierCode.Size = New System.Drawing.Size(56, 20)
      Me.txtSupplierCode.TabIndex = 9
      Me.txtSupplierCode.Text = ""
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
      Me.lblDay.Location = New System.Drawing.Point(128, 42)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(17, 17)
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
      Me.txtCreditPrd.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMaxValue(Me.txtCreditPrd, "")
      Me.Validator.SetMinValue(Me.txtCreditPrd, "0")
      Me.txtCreditPrd.Name = "txtCreditPrd"
      Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
      Me.Validator.SetRequired(Me.txtCreditPrd, False)
      Me.txtCreditPrd.Size = New System.Drawing.Size(32, 20)
      Me.txtCreditPrd.TabIndex = 11
      Me.txtCreditPrd.Text = ""
      '
      'txtDeliveryPerson
      '
      Me.Validator.SetDataType(Me.txtDeliveryPerson, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDeliveryPerson, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDeliveryPerson, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDeliveryPerson, System.Drawing.Color.Empty)
      Me.txtDeliveryPerson.Location = New System.Drawing.Point(96, 64)
      Me.Validator.SetMaxValue(Me.txtDeliveryPerson, "")
      Me.Validator.SetMinValue(Me.txtDeliveryPerson, "")
      Me.txtDeliveryPerson.Name = "txtDeliveryPerson"
      Me.Validator.SetRegularExpression(Me.txtDeliveryPerson, "")
      Me.Validator.SetRequired(Me.txtDeliveryPerson, False)
      Me.txtDeliveryPerson.Size = New System.Drawing.Size(224, 20)
      Me.txtDeliveryPerson.TabIndex = 12
      Me.txtDeliveryPerson.Text = ""
      '
      'lblDeliveryPerson
      '
      Me.lblDeliveryPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDeliveryPerson.Location = New System.Drawing.Point(8, 64)
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
      Me.lblPOCode.Location = New System.Drawing.Point(352, 16)
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
      Me.lblPODate.Location = New System.Drawing.Point(592, 16)
      Me.lblPODate.Name = "lblPODate"
      Me.lblPODate.Size = New System.Drawing.Size(32, 18)
      Me.lblPODate.TabIndex = 23
      Me.lblPODate.Text = "วันที่:"
      Me.lblPODate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(352, 160)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(416, 42)
      Me.txtNote.TabIndex = 18
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(296, 160)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(56, 18)
      Me.lblNote.TabIndex = 32
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
      Me.lblDeliveryDocDate.TabIndex = 17
      Me.lblDeliveryDocDate.Text = "วันที่:"
      Me.lblDeliveryDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInvoiceCode
      '
      Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceCode.Location = New System.Drawing.Point(352, 40)
      Me.lblInvoiceCode.Name = "lblInvoiceCode"
      Me.lblInvoiceCode.Size = New System.Drawing.Size(96, 18)
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
      Me.txtInvoiceCode.Location = New System.Drawing.Point(448, 40)
      Me.Validator.SetMaxValue(Me.txtInvoiceCode, "")
      Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
      Me.txtInvoiceCode.Name = "txtInvoiceCode"
      Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
      Me.Validator.SetRequired(Me.txtInvoiceCode, False)
      Me.txtInvoiceCode.Size = New System.Drawing.Size(112, 21)
      Me.txtInvoiceCode.TabIndex = 7
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
      'txtPODate
      '
      Me.txtPODate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtPODate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtPODate, "")
      Me.txtPODate.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtPODate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPODate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtPODate, System.Drawing.Color.Empty)
      Me.txtPODate.Location = New System.Drawing.Point(624, 16)
      Me.Validator.SetMaxValue(Me.txtPODate, "")
      Me.Validator.SetMinValue(Me.txtPODate, "")
      Me.txtPODate.Name = "txtPODate"
      Me.Validator.SetRegularExpression(Me.txtPODate, "")
      Me.Validator.SetRequired(Me.txtPODate, False)
      Me.txtPODate.Size = New System.Drawing.Size(96, 20)
      Me.txtPODate.TabIndex = 25
      Me.txtPODate.Text = ""
      '
      'txtInvoiceDate
      '
      Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
      Me.txtInvoiceDate.Location = New System.Drawing.Point(624, 40)
      Me.Validator.SetMaxValue(Me.txtInvoiceDate, "")
      Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
      Me.txtInvoiceDate.Name = "txtInvoiceDate"
      Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
      Me.Validator.SetRequired(Me.txtInvoiceDate, False)
      Me.txtInvoiceDate.Size = New System.Drawing.Size(78, 20)
      Me.txtInvoiceDate.TabIndex = 8
      Me.txtInvoiceDate.Text = ""
      '
      'txtPOCode
      '
      Me.Validator.SetDataType(Me.txtPOCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPOCode, "")
      Me.txtPOCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPOCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPOCode, System.Drawing.Color.Empty)
      Me.txtPOCode.Location = New System.Drawing.Point(448, 16)
      Me.Validator.SetMaxValue(Me.txtPOCode, "")
      Me.Validator.SetMinValue(Me.txtPOCode, "")
      Me.txtPOCode.Name = "txtPOCode"
      Me.Validator.SetRegularExpression(Me.txtPOCode, "")
      Me.Validator.SetRequired(Me.txtPOCode, False)
      Me.txtPOCode.Size = New System.Drawing.Size(112, 21)
      Me.txtPOCode.TabIndex = 5
      Me.txtPOCode.TabStop = False
      Me.txtPOCode.Text = ""
      '
      'ibtnShowPODialog
      '
      Me.ibtnShowPODialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowPODialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowPODialog.Image = CType(resources.GetObject("ibtnShowPODialog.Image"), System.Drawing.Image)
      Me.ibtnShowPODialog.Location = New System.Drawing.Point(568, 16)
      Me.ibtnShowPODialog.Name = "ibtnShowPODialog"
      Me.ibtnShowPODialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowPODialog.TabIndex = 6
      Me.ibtnShowPODialog.TabStop = False
      Me.ibtnShowPODialog.ThemedImage = CType(resources.GetObject("ibtnShowPODialog.ThemedImage"), System.Drawing.Bitmap)
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
      'dtpDeliveryDocDate
      '
      Me.dtpDeliveryDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDeliveryDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDeliveryDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDeliveryDocDate.Location = New System.Drawing.Point(240, 40)
      Me.dtpDeliveryDocDate.Name = "dtpDeliveryDocDate"
      Me.dtpDeliveryDocDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpDeliveryDocDate.TabIndex = 19
      Me.dtpDeliveryDocDate.TabStop = False
      '
      'dtpInvoiceDate
      '
      Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpInvoiceDate.Location = New System.Drawing.Point(624, 40)
      Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
      Me.dtpInvoiceDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpInvoiceDate.TabIndex = 28
      Me.dtpInvoiceDate.TabStop = False
      '
      'lblInvoiceDate
      '
      Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
      Me.lblInvoiceDate.Location = New System.Drawing.Point(592, 40)
      Me.lblInvoiceDate.Name = "lblInvoiceDate"
      Me.lblInvoiceDate.Size = New System.Drawing.Size(32, 18)
      Me.lblInvoiceDate.TabIndex = 24
      Me.lblInvoiceDate.Text = "วันที่:"
      Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(112, 184)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 30
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(136, 184)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 31
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(556, 540)
      Me.lblTaxAmount.Name = "lblTaxAmount"
      Me.lblTaxAmount.Size = New System.Drawing.Size(56, 18)
      Me.lblTaxAmount.TabIndex = 286
      Me.lblTaxAmount.Text = "ภาษี :"
      Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnEnableVatInput
      '
      Me.ibtnEnableVatInput.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnEnableVatInput.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnEnableVatInput.Image = CType(resources.GetObject("ibtnEnableVatInput.Image"), System.Drawing.Image)
      Me.ibtnEnableVatInput.Location = New System.Drawing.Point(720, 38)
      Me.ibtnEnableVatInput.Name = "ibtnEnableVatInput"
      Me.ibtnEnableVatInput.Size = New System.Drawing.Size(24, 24)
      Me.ibtnEnableVatInput.TabIndex = 27
      Me.ibtnEnableVatInput.TabStop = False
      Me.ibtnEnableVatInput.ThemedImage = CType(resources.GetObject("ibtnEnableVatInput.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(224, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 15
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(96, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(128, 21)
      Me.cmbCode.TabIndex = 0
      '
      'GoodsReceiptForOperationDetail
      '
      Me.Controls.Add(Me.cmbCode)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.lblTaxAmount)
      Me.Controls.Add(Me.txtDocDate)
      Me.Controls.Add(Me.dtpDocDate)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.lblNote)
      Me.Controls.Add(Me.grbReceive)
      Me.Controls.Add(Me.grbDelivery)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.lblDocDate)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblPOCode)
      Me.Controls.Add(Me.lblPODate)
      Me.Controls.Add(Me.lblDeliveryCode)
      Me.Controls.Add(Me.txtDeliveryCode)
      Me.Controls.Add(Me.lblDeliveryDocDate)
      Me.Controls.Add(Me.lblInvoiceCode)
      Me.Controls.Add(Me.txtInvoiceCode)
      Me.Controls.Add(Me.txtPOCode)
      Me.Controls.Add(Me.ibtnShowPODialog)
      Me.Controls.Add(Me.txtDeliveryDocDate)
      Me.Controls.Add(Me.dtpDeliveryDocDate)
      Me.Controls.Add(Me.txtPODate)
      Me.Controls.Add(Me.lblInvoiceDate)
      Me.Controls.Add(Me.txtInvoiceDate)
      Me.Controls.Add(Me.dtpInvoiceDate)
      Me.Controls.Add(Me.ibtnEnableVatInput)
      Me.Name = "GoodsReceiptForOperationDetail"
      Me.Size = New System.Drawing.Size(784, 528)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbReceive.ResumeLayout(False)
      Me.grbDelivery.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As GoodsReceipt
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
      AddHandler csUnitButton.Click, AddressOf ButtonClicked

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
      dst.GridColumnStyles.Add(csPOItemRemainingQty)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csQuality)
      dst.GridColumnStyles.Add(csNote)

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Public Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 5 Then
        Me.UnitButtonClick(e)
      ElseIf e.Column = 2 Then
        Me.ItemButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As GoodsReceiptItem
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
      Dim doc As GoodsReceiptItem = Me.CurrentItem

      'If tick checkbox that not in the current hilight row
      If e.Column.ColumnName.ToLower = "stocki_unvatable" Then
        Me.m_treeManager.SelectedRow = e.Row
        doc = Me.CurrentItem
      End If

      If doc Is Nothing Then
        doc = New GoodsReceiptItem
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
            Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            doc.Qty = value
            m_entity.OnGlChanged()
          Case "accountcode"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetAccountCode(CStr(e.ProposedValue))
            m_entity.OnGlChanged()
          Case "stocki_entitytype"
            Dim value As ItemType
            If IsNumeric(e.ProposedValue) Then
              value = New ItemType(CInt(e.ProposedValue))
            End If
            doc.ItemType = value
            m_entity.OnGlChanged()
          Case "stocki_unitprice"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
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
          Case "stocki_unvatable"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = False
            End If
            doc.UnVatable = CBool(e.ProposedValue)
          Case "stocki_quality"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Quality = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub GRItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      'จากการอนุมัติเอกสาร
      If CBool(Configuration.GetConfig("ApproveDO")) AndAlso Not Me.m_entity.ApproveDate.Equals(Date.MinValue) Then
        If Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then
          For Each ctrl As Control In Me.Controls
            ctrl.Enabled = False
          Next
          tgItem.Enabled = False
          Return
        Else
          For Each ctrl As Control In Me.Controls
            ctrl.Enabled = True
          Next
          Me.tgItem.Enabled = True
        End If
      End If

      'จาก Status ของเอกสารเอง
      If Me.m_entity.Status.Value = 0 _
      OrElse m_entityRefed = 1 _
      OrElse Me.m_entity.Payment.Status.Value = 0 _
      OrElse Me.m_entity.Payment.Status.Value >= 3 _
      Then
        For Each ctrl As Control In Me.grbDelivery.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.grbReceive.Controls
          ctrl.Enabled = False
        Next
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
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

      Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblToCCPerson}")
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, StringHelper.GetRidOfAtEnd(Me.lblToCCPerson.Text, ":"))

      Me.lblToCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblToCostCenter}")
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, StringHelper.GetRidOfAtEnd(Me.lblToCostCenter.Text, ":"))

      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblSupplier}")
      Me.Validator.SetDisplayName(Me.txtSupplierCode, StringHelper.GetRidOfAtEnd(Me.lblSupplier.Text, ":"))

      Me.lblDeliveryPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblDeliveryPerson}")
      Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblCreditPrd}")
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")

      Me.lblDocType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.lblDocType}")

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPrd.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCreditPrd.TextChanged, AddressOf Me.TextHandler

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

      AddHandler txtDeliveryPerson.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbDocType.SelectedIndexChanged, AddressOf Me.ChangeProperty

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
      End Select
    End Sub
    Private m_oldInvoiceCode As String = ""
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      oldSupId = Me.m_entity.Supplier.Id
      oldCCId = Me.m_entity.ToCostCenter.Id

      'cmbCode.Items.Clear()
      'cmbCode.DropDownStyle = ComboBoxStyle.Simple
      'cmbCode.Text = m_entity.Code

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

      If Not Me.m_entity.Po Is Nothing AndAlso Me.m_entity.Po.Originated Then
        Me.txtPOCode.Text = Me.m_entity.Po.Code
        Me.txtPODate.Text = MinDateToNull(Me.m_entity.Po.DocDate, "")
      Else
        Me.txtPOCode.Text = ""
        Me.txtPODate.Text = ""
      End If

      dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)

      txtSupplierCode.Text = m_entity.Supplier.Code
      txtSupplierName.Text = m_entity.Supplier.Name
      txtNote.Text = m_entity.Note

      Me.txtDeliveryPerson.Text = Me.m_entity.DeliveryPerson

      txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
      txtToCostCenterName.Text = m_entity.ToCostCenter.Name

      Me.txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
      txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name

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
        Case "txtrealtaxbase"
          dirtyFlag = True
        Case "txtrealtaxamount"
          dirtyFlag = True
        Case "txtrealgross"
          dirtyFlag = True
        Case "cmbcode"
          'เพิ่ม AutoCode
          If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
            m_entity.Code = m_entity.AutoCodeFormat.Format
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
              Me.m_entity.OnGlChanged()
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
        Case "dtpdocdate"
          If Not m_dateSetting Then
            If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
              If Not m_dateSetting Then
                Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                Me.m_entity.DocDate = dtpDocDate.Value
                Me.m_entity.Payment.DocDate = dtpDocDate.Value
                Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
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
              Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              dirtyFlag = True
            End If
          Else
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            Me.m_entity.Payment.DocDate = Date.MinValue
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
            Me.dtpDueDate.Value = Me.m_entity.DueDate
            dirtyFlag = True
          End If
        Case "txttaxbase"
          'Todo
        Case "txtretention"
          dirtyFlag = True

        Case "txtdeliverycode"
          Me.m_entity.DeliveryDocCode = txtDeliveryCode.Text
          dirtyFlag = True
        Case "txtdeliverydocdate"
          m_dateSetting = True
          'If Not Me.txtDeliveryDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDeliveryDocDate) = "" Then
          If Me.Validator.GetErrorMessage(Me.txtDeliveryDocDate) = "" AndAlso Me.txtDeliveryDocDate.Text.Length > 0 Then
            Dim theDate As Date = CDate(Me.txtDeliveryDocDate.Text)
            If Not Me.m_entity.DeliveryDocDate.Equals(theDate) Then
              dtpDeliveryDocDate.Value = theDate
              Me.m_entity.DeliveryDocDate = dtpDeliveryDocDate.Value
              dirtyFlag = True
            End If
          Else
            dtpDeliveryDocDate.Value = Date.Now
            Me.m_entity.DeliveryDocDate = Date.MinValue
          End If
          m_dateSetting = False
        Case "dtpdeliverydocdate"
          If Not m_dateSetting Then
            If Not Me.m_entity.DeliveryDocDate.Equals(dtpDeliveryDocDate.Value) Then
              If Not m_dateSetting Then
                Me.txtDeliveryDocDate.Text = MinDateToNull(dtpDeliveryDocDate.Value, "")
                Me.m_entity.DeliveryDocDate = dtpDeliveryDocDate.Value
                dirtyFlag = True
              End If
            End If
          End If
        Case "txtpocode"
          If pOCodeChanged Then
            pOCodeChanged = False
            Me.m_entity.OnGlChanged()
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
            Me.m_entity.OnGlChanged()
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
      Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
      txtcreditprdChanged = False
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
    Private Sub ibtnResetGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity.RealGross <> Me.m_entity.Gross Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealGross = Me.m_entity.Gross
      UpdateAmount()
    End Sub
    Private Sub ibtnResetTaxBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
      UpdateAmount()
    End Sub
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
    Public Sub SetStatus()
      Me.StatusDescription = ""
      If m_entity.Canceled Then
        Me.StatusDescription = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name
      ElseIf m_entity.Edited Then
        Me.StatusDescription = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
        Me.StatusDescription &= ",แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name
      ElseIf Me.m_entity.Originated Then
        Me.StatusDescription = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
      Else
        Me.StatusDescription = ""
      End If
      Me.StatusBarService.SetMessage(Me.StatusDescription)
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
      ListType()
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
#End Region

#Region "Event Handler"
    Private currentY As Integer
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      If tgItem.CurrentRowIndex <> currentY Then
        currentY = tgItem.CurrentRowIndex
      End If
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
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDown
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.Code = m_oldCode
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
            m_entity.Code = m_entity.AutoCodeFormat.Format
          End If
        End If
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim doc As GoodsReceiptItem = Me.CurrentItem
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
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As GoodsReceiptItem = Me.CurrentItem
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
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As GoodsReceiptItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New GoodsReceiptItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Dim entities(1) As ISimpleEntity
      entities(0) = New LCIItem
      entities(1) = New Tool
      Dim activeIndex As Integer = -1
      If Not doc.ItemType Is Nothing Then
        If doc.ItemType.Value = 19 Then
          activeIndex = 1
        ElseIf doc.ItemType.Value = 42 Then
          activeIndex = 0
        End If
      End If
      myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, activeIndex)
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim itemEntityLevel As Integer
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As IHasName
        Dim newType As Integer = -1
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.lciitem"
            newItem = New LCIItem(item.Id)
            newType = 42
            itemEntityLevel = CType(newItem, LCIItem).Level
          Case "longkong.pojjaman.businesslogic.tool"
            newItem = New Tool(item.Id)
            newType = 19
            itemEntityLevel = 5
        End Select
        If itemEntityLevel = 5 Then
          Dim doc As New GoodsReceiptItem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.ItemType.Value = newType
            Me.m_treeManager.SelectedRow.Tag = Nothing
          Else
            If Me.m_entity.ItemCollection.Count > 0 Then
              Me.m_entity.ItemCollection.Insert(index, doc)
            Else
              Me.m_entity.ItemCollection.Add(doc)
            End If
            doc.ItemType = New ItemType(newType)
          End If
          'doc.Entity = newItem   'เดิม Set จากการกดปุ่มเป็นแบบนี้ทำให้รหัสบัญชีไม่ขึ้น จึงไปใช้วิธีเดียวกับการกรอกใน textbox
          doc.SetItemCode(newItem.Code)
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
      Dim doc As GoodsReceiptItem = Me.CurrentItem
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
      Dim doc As GoodsReceiptItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Me.m_entity.ItemCollection.Remove(doc)
      RefreshDocs()
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
        Return (New PO).DetailPanelIcon
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
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
    End Sub
    Private Sub SetSupplier(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Me.ChangeProperty(txtSupplierCode, Nothing)
    End Sub
    ' AdvancePay
    Private Sub ibtnShowAdvancePay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
      For Each item As GoodsReceiptItem In Me.m_entity.ItemCollection
        item.WBSDistributeCollection.Clear()
      Next
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

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim x As ApprovalCommentForm = New ApprovalCommentForm(Me.Entity)
      x.ShowDialog()
    End Sub

    Public Overrides Sub NotifyBeforeSave()
      If Not Me.m_entity.JournalEntry Is Nothing AndAlso Not Me.m_entity.JournalEntry.ManualFormat Then
        If Me.m_entity.JournalEntry.GLFormat Is Nothing OrElse Not Me.m_entity.JournalEntry.GLFormat.Originated Then
          Me.m_entity.JournalEntry.GLFormat = Me.m_entity.GetDefaultGLFormat
        End If
        Me.m_entity.JournalEntry.SetGLFormat(Me.m_entity.JournalEntry.GLFormat)
        Me.m_entity.OnGlChanged()
      End If
    End Sub
  End Class
End Namespace
