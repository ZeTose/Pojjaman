Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Imports System.Text.RegularExpressions

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class WHTDetail
    Inherits AbstractEntityDetailPanelView
    'Inherits UserControl
    Implements IValidatable, IAuxTab, ICanRefreshAutoComplete, ISetNothingEntity

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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtPrintName As System.Windows.Forms.TextBox
    Friend WithEvents lblPrintName As System.Windows.Forms.Label
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPaymentType As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lbltem As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtOtherPaymentType As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents txtIdNo As System.Windows.Forms.TextBox
    Friend WithEvents lblIdNo As System.Windows.Forms.Label
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grbRefDoc As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtRefTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents txtRefDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblDirection As System.Windows.Forms.Label
    Friend WithEvents lblRefTaxBase As System.Windows.Forms.Label
    Friend WithEvents lblRefDocDate As System.Windows.Forms.Label
    Friend WithEvents dtpRefDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRefDocCode As System.Windows.Forms.TextBox
    Friend WithEvents lblRefDoc As System.Windows.Forms.Label
    Friend WithEvents cmbDirection As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTaxId As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxId As System.Windows.Forms.Label
    Friend WithEvents lblRepresentative As System.Windows.Forms.Label
    Friend WithEvents txtRepresentative As System.Windows.Forms.TextBox
    Friend WithEvents lblRepresentIdNo As System.Windows.Forms.Label
    Friend WithEvents txtRepresentIdNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRepresentTaxId As System.Windows.Forms.TextBox
    Friend WithEvents lblRepresentTaxId As System.Windows.Forms.Label
    Friend WithEvents txtEmployerAcct As System.Windows.Forms.TextBox
    Friend WithEvents lblEmployerAcct As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeSSN As System.Windows.Forms.TextBox
    Friend WithEvents lblEmployeeSSN As System.Windows.Forms.Label
    Friend WithEvents txtCompanySupport As System.Windows.Forms.TextBox
    Friend WithEvents lblCompanySupport As System.Windows.Forms.Label
    Friend WithEvents txtLicense As System.Windows.Forms.TextBox
    Friend WithEvents lblLicense As System.Windows.Forms.Label
    Friend WithEvents txtCum As System.Windows.Forms.TextBox
    Friend WithEvents lblCum As System.Windows.Forms.Label
    Friend WithEvents lblRepresentAddress As System.Windows.Forms.Label
    Friend WithEvents txtRepresentAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblBookNo As System.Windows.Forms.Label
    Friend WithEvents txtBookNo As System.Windows.Forms.TextBox
    Friend WithEvents lbWhtList As System.Windows.Forms.ListBox
    Friend WithEvents ibtnAddWht As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelWht As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtSeqId As System.Windows.Forms.TextBox
    Friend WithEvents lblSeqId As System.Windows.Forms.Label
    Friend WithEvents chkWHT As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WHTDetail))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.txtTaxId = New System.Windows.Forms.TextBox()
      Me.lblTaxId = New System.Windows.Forms.Label()
      Me.txtIdNo = New System.Windows.Forms.TextBox()
      Me.lblIdNo = New System.Windows.Forms.Label()
      Me.cmbPaymentType = New System.Windows.Forms.ComboBox()
      Me.lblPaymentType = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lbltem = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtRefDocDate = New System.Windows.Forms.TextBox()
      Me.txtPrintName = New System.Windows.Forms.TextBox()
      Me.txtOtherPaymentType = New System.Windows.Forms.TextBox()
      Me.txtRefTaxBase = New System.Windows.Forms.TextBox()
      Me.txtRefDocCode = New System.Windows.Forms.TextBox()
      Me.cmbDirection = New System.Windows.Forms.ComboBox()
      Me.cmbType = New System.Windows.Forms.ComboBox()
      Me.txtRepresentative = New System.Windows.Forms.TextBox()
      Me.txtRepresentIdNo = New System.Windows.Forms.TextBox()
      Me.txtRepresentTaxId = New System.Windows.Forms.TextBox()
      Me.txtEmployerAcct = New System.Windows.Forms.TextBox()
      Me.txtEmployeeSSN = New System.Windows.Forms.TextBox()
      Me.txtCompanySupport = New System.Windows.Forms.TextBox()
      Me.txtLicense = New System.Windows.Forms.TextBox()
      Me.txtCum = New System.Windows.Forms.TextBox()
      Me.txtRepresentAddress = New System.Windows.Forms.TextBox()
      Me.txtAddress = New System.Windows.Forms.TextBox()
      Me.txtBookNo = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.txtTotalAmount = New System.Windows.Forms.TextBox()
      Me.txtSeqId = New System.Windows.Forms.TextBox()
      Me.lblPrintName = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblRepresentIdNo = New System.Windows.Forms.Label()
      Me.lblAddress = New System.Windows.Forms.Label()
      Me.lblRepresentAddress = New System.Windows.Forms.Label()
      Me.lblType = New System.Windows.Forms.Label()
      Me.lblRepresentative = New System.Windows.Forms.Label()
      Me.lblRepresentTaxId = New System.Windows.Forms.Label()
      Me.lblSeqId = New System.Windows.Forms.Label()
      Me.chkWHT = New System.Windows.Forms.CheckBox()
      Me.lbWhtList = New System.Windows.Forms.ListBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblCompanySupport = New System.Windows.Forms.Label()
      Me.lblLicense = New System.Windows.Forms.Label()
      Me.grbRefDoc = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblDirection = New System.Windows.Forms.Label()
      Me.lblRefTaxBase = New System.Windows.Forms.Label()
      Me.lblRefDocDate = New System.Windows.Forms.Label()
      Me.dtpRefDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblRefDoc = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.lblEmployerAcct = New System.Windows.Forms.Label()
      Me.lblEmployeeSSN = New System.Windows.Forms.Label()
      Me.lblCum = New System.Windows.Forms.Label()
      Me.lblBookNo = New System.Windows.Forms.Label()
      Me.ibtnAddWht = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelWht = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblTotalAmount = New System.Windows.Forms.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.FixedGroupBox1.SuspendLayout()
      Me.grbRefDoc.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(259, 116)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 7
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(339, 116)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(96, 20)
      Me.txtCode.TabIndex = 1
      '
      'txtSupplierName
      '
      Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.txtSupplierName.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(187, 64)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(252, 20)
      Me.txtSupplierName.TabIndex = 12
      '
      'lblSupplier
      '
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(39, 64)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(80, 18)
      Me.lblSupplier.TabIndex = 10
      Me.lblSupplier.Text = "Supplier:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierCode
      '
      Me.txtSupplierCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(119, 64)
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, False)
      Me.txtSupplierCode.Size = New System.Drawing.Size(68, 20)
      Me.txtSupplierCode.TabIndex = 4
      '
      'txtTaxId
      '
      Me.txtTaxId.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtTaxId, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxId, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxId, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtTaxId, -15)
      Me.Validator.SetInvalidBackColor(Me.txtTaxId, System.Drawing.Color.Empty)
      Me.txtTaxId.Location = New System.Drawing.Point(119, 62)
      Me.Validator.SetMinValue(Me.txtTaxId, "")
      Me.txtTaxId.Name = "txtTaxId"
      Me.Validator.SetRegularExpression(Me.txtTaxId, "")
      Me.Validator.SetRequired(Me.txtTaxId, False)
      Me.txtTaxId.Size = New System.Drawing.Size(96, 20)
      Me.txtTaxId.TabIndex = 2
      '
      'lblTaxId
      '
      Me.lblTaxId.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxId.Location = New System.Drawing.Point(-1, 64)
      Me.lblTaxId.Name = "lblTaxId"
      Me.lblTaxId.Size = New System.Drawing.Size(120, 18)
      Me.lblTaxId.TabIndex = 15
      Me.lblTaxId.Text = "เลขประจำตัวผู้เสียภาษี:"
      Me.lblTaxId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtIdNo
      '
      Me.txtIdNo.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtIdNo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtIdNo, "")
      Me.Validator.SetGotFocusBackColor(Me.txtIdNo, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtIdNo, -15)
      Me.Validator.SetInvalidBackColor(Me.txtIdNo, System.Drawing.Color.Empty)
      Me.txtIdNo.Location = New System.Drawing.Point(351, 64)
      Me.Validator.SetMinValue(Me.txtIdNo, "")
      Me.txtIdNo.Name = "txtIdNo"
      Me.Validator.SetRegularExpression(Me.txtIdNo, "")
      Me.Validator.SetRequired(Me.txtIdNo, False)
      Me.txtIdNo.Size = New System.Drawing.Size(88, 20)
      Me.txtIdNo.TabIndex = 18
      '
      'lblIdNo
      '
      Me.lblIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblIdNo.Location = New System.Drawing.Point(215, 64)
      Me.lblIdNo.Name = "lblIdNo"
      Me.lblIdNo.Size = New System.Drawing.Size(136, 18)
      Me.lblIdNo.TabIndex = 17
      Me.lblIdNo.Text = "เลขประจำตัวประชาชน:"
      Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbPaymentType
      '
      Me.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbPaymentType, -15)
      Me.cmbPaymentType.Location = New System.Drawing.Point(119, 136)
      Me.cmbPaymentType.Name = "cmbPaymentType"
      Me.cmbPaymentType.Size = New System.Drawing.Size(144, 21)
      Me.cmbPaymentType.TabIndex = 5
      '
      'lblPaymentType
      '
      Me.lblPaymentType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPaymentType.Location = New System.Drawing.Point(63, 136)
      Me.lblPaymentType.Name = "lblPaymentType"
      Me.lblPaymentType.Size = New System.Drawing.Size(56, 18)
      Me.lblPaymentType.TabIndex = 23
      Me.lblPaymentType.Text = "ผู้จ่ายเงิน:"
      Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgItem
      '
      Me.tgItem.AllowNew = True
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 402)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(752, 100)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 10
      Me.tgItem.TreeManager = Nothing
      '
      'lbltem
      '
      Me.lbltem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lbltem.Location = New System.Drawing.Point(7, 382)
      Me.lbltem.Name = "lbltem"
      Me.lbltem.Size = New System.Drawing.Size(128, 18)
      Me.lbltem.TabIndex = 44
      Me.lbltem.Text = "รายการหัก ณ ที่จ่าย"
      Me.lbltem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(519, 116)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(116, 20)
      Me.txtDocDate.TabIndex = 2
      '
      'txtRefDocDate
      '
      Me.txtRefDocDate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtRefDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocDate, "")
      Me.txtRefDocDate.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRefDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocDate, System.Drawing.Color.Empty)
      Me.txtRefDocDate.Location = New System.Drawing.Point(303, 16)
      Me.Validator.SetMinValue(Me.txtRefDocDate, "")
      Me.txtRefDocDate.Name = "txtRefDocDate"
      Me.Validator.SetRegularExpression(Me.txtRefDocDate, "")
      Me.Validator.SetRequired(Me.txtRefDocDate, False)
      Me.txtRefDocDate.Size = New System.Drawing.Size(116, 20)
      Me.txtRefDocDate.TabIndex = 1
      Me.txtRefDocDate.TabStop = False
      '
      'txtPrintName
      '
      Me.txtPrintName.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtPrintName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPrintName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPrintName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPrintName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPrintName, System.Drawing.Color.Empty)
      Me.txtPrintName.Location = New System.Drawing.Point(119, 40)
      Me.Validator.SetMinValue(Me.txtPrintName, "")
      Me.txtPrintName.Name = "txtPrintName"
      Me.Validator.SetRegularExpression(Me.txtPrintName, "")
      Me.Validator.SetRequired(Me.txtPrintName, True)
      Me.txtPrintName.Size = New System.Drawing.Size(320, 20)
      Me.txtPrintName.TabIndex = 1
      '
      'txtOtherPaymentType
      '
      Me.Validator.SetDataType(Me.txtOtherPaymentType, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtOtherPaymentType, "")
      Me.Validator.SetGotFocusBackColor(Me.txtOtherPaymentType, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtOtherPaymentType, -15)
      Me.Validator.SetInvalidBackColor(Me.txtOtherPaymentType, System.Drawing.Color.Empty)
      Me.txtOtherPaymentType.Location = New System.Drawing.Point(263, 136)
      Me.Validator.SetMinValue(Me.txtOtherPaymentType, "")
      Me.txtOtherPaymentType.Name = "txtOtherPaymentType"
      Me.Validator.SetRegularExpression(Me.txtOtherPaymentType, "")
      Me.Validator.SetRequired(Me.txtOtherPaymentType, False)
      Me.txtOtherPaymentType.Size = New System.Drawing.Size(176, 20)
      Me.txtOtherPaymentType.TabIndex = 25
      '
      'txtRefTaxBase
      '
      Me.txtRefTaxBase.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtRefTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefTaxBase, "")
      Me.txtRefTaxBase.Enabled = False
      Me.txtRefTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRefTaxBase, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRefTaxBase, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRefTaxBase, System.Drawing.Color.Empty)
      Me.txtRefTaxBase.Location = New System.Drawing.Point(303, 39)
      Me.Validator.SetMinValue(Me.txtRefTaxBase, "")
      Me.txtRefTaxBase.Name = "txtRefTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRefTaxBase, "")
      Me.Validator.SetRequired(Me.txtRefTaxBase, False)
      Me.txtRefTaxBase.Size = New System.Drawing.Size(136, 21)
      Me.txtRefTaxBase.TabIndex = 3
      Me.txtRefTaxBase.TabStop = False
      Me.txtRefTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRefDocCode
      '
      Me.txtRefDocCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtRefDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocCode, "")
      Me.txtRefDocCode.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRefDocCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
      Me.txtRefDocCode.Location = New System.Drawing.Point(119, 16)
      Me.Validator.SetMinValue(Me.txtRefDocCode, "")
      Me.txtRefDocCode.Name = "txtRefDocCode"
      Me.Validator.SetRegularExpression(Me.txtRefDocCode, "")
      Me.Validator.SetRequired(Me.txtRefDocCode, False)
      Me.txtRefDocCode.Size = New System.Drawing.Size(144, 20)
      Me.txtRefDocCode.TabIndex = 0
      Me.txtRefDocCode.TabStop = False
      '
      'cmbDirection
      '
      Me.cmbDirection.BackColor = System.Drawing.SystemColors.Control
      Me.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDirection.Enabled = False
      Me.ErrorProvider1.SetIconPadding(Me.cmbDirection, -15)
      Me.cmbDirection.Location = New System.Drawing.Point(119, 39)
      Me.cmbDirection.Name = "cmbDirection"
      Me.cmbDirection.Size = New System.Drawing.Size(128, 21)
      Me.cmbDirection.TabIndex = 2
      Me.cmbDirection.TabStop = False
      '
      'cmbType
      '
      Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbType, -15)
      Me.cmbType.Location = New System.Drawing.Point(119, 112)
      Me.cmbType.Name = "cmbType"
      Me.cmbType.Size = New System.Drawing.Size(144, 21)
      Me.cmbType.TabIndex = 4
      '
      'txtRepresentative
      '
      Me.txtRepresentative.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtRepresentative, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRepresentative, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRepresentative, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRepresentative, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRepresentative, System.Drawing.Color.Empty)
      Me.txtRepresentative.Location = New System.Drawing.Point(119, 160)
      Me.Validator.SetMinValue(Me.txtRepresentative, "")
      Me.txtRepresentative.Name = "txtRepresentative"
      Me.Validator.SetRegularExpression(Me.txtRepresentative, "")
      Me.Validator.SetRequired(Me.txtRepresentative, False)
      Me.txtRepresentative.Size = New System.Drawing.Size(320, 20)
      Me.txtRepresentative.TabIndex = 6
      '
      'txtRepresentIdNo
      '
      Me.txtRepresentIdNo.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtRepresentIdNo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRepresentIdNo, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRepresentIdNo, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRepresentIdNo, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRepresentIdNo, System.Drawing.Color.Empty)
      Me.txtRepresentIdNo.Location = New System.Drawing.Point(351, 184)
      Me.Validator.SetMinValue(Me.txtRepresentIdNo, "")
      Me.txtRepresentIdNo.Name = "txtRepresentIdNo"
      Me.Validator.SetRegularExpression(Me.txtRepresentIdNo, "")
      Me.Validator.SetRequired(Me.txtRepresentIdNo, False)
      Me.txtRepresentIdNo.Size = New System.Drawing.Size(88, 20)
      Me.txtRepresentIdNo.TabIndex = 31
      '
      'txtRepresentTaxId
      '
      Me.txtRepresentTaxId.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtRepresentTaxId, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRepresentTaxId, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRepresentTaxId, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRepresentTaxId, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRepresentTaxId, System.Drawing.Color.Empty)
      Me.txtRepresentTaxId.Location = New System.Drawing.Point(119, 184)
      Me.Validator.SetMinValue(Me.txtRepresentTaxId, "")
      Me.txtRepresentTaxId.Name = "txtRepresentTaxId"
      Me.Validator.SetRegularExpression(Me.txtRepresentTaxId, "")
      Me.Validator.SetRequired(Me.txtRepresentTaxId, False)
      Me.txtRepresentTaxId.Size = New System.Drawing.Size(96, 20)
      Me.txtRepresentTaxId.TabIndex = 7
      '
      'txtEmployerAcct
      '
      Me.txtEmployerAcct.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtEmployerAcct, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmployerAcct, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEmployerAcct, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmployerAcct, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmployerAcct, System.Drawing.Color.Empty)
      Me.txtEmployerAcct.Location = New System.Drawing.Point(576, 151)
      Me.Validator.SetMinValue(Me.txtEmployerAcct, "")
      Me.txtEmployerAcct.Name = "txtEmployerAcct"
      Me.Validator.SetRegularExpression(Me.txtEmployerAcct, "")
      Me.Validator.SetRequired(Me.txtEmployerAcct, False)
      Me.txtEmployerAcct.Size = New System.Drawing.Size(136, 20)
      Me.txtEmployerAcct.TabIndex = 5
      '
      'txtEmployeeSSN
      '
      Me.txtEmployeeSSN.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtEmployeeSSN, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmployeeSSN, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEmployeeSSN, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmployeeSSN, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmployeeSSN, System.Drawing.Color.Empty)
      Me.txtEmployeeSSN.Location = New System.Drawing.Point(576, 175)
      Me.Validator.SetMinValue(Me.txtEmployeeSSN, "")
      Me.txtEmployeeSSN.Name = "txtEmployeeSSN"
      Me.Validator.SetRegularExpression(Me.txtEmployeeSSN, "")
      Me.Validator.SetRequired(Me.txtEmployeeSSN, False)
      Me.txtEmployeeSSN.Size = New System.Drawing.Size(136, 20)
      Me.txtEmployeeSSN.TabIndex = 6
      '
      'txtCompanySupport
      '
      Me.txtCompanySupport.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCompanySupport, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCompanySupport, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCompanySupport, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCompanySupport, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCompanySupport, System.Drawing.Color.Empty)
      Me.txtCompanySupport.Location = New System.Drawing.Point(576, 199)
      Me.Validator.SetMinValue(Me.txtCompanySupport, "")
      Me.txtCompanySupport.Name = "txtCompanySupport"
      Me.Validator.SetRegularExpression(Me.txtCompanySupport, "")
      Me.Validator.SetRequired(Me.txtCompanySupport, False)
      Me.txtCompanySupport.Size = New System.Drawing.Size(136, 20)
      Me.txtCompanySupport.TabIndex = 7
      '
      'txtLicense
      '
      Me.txtLicense.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtLicense, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLicense, "")
      Me.Validator.SetGotFocusBackColor(Me.txtLicense, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtLicense, -15)
      Me.Validator.SetInvalidBackColor(Me.txtLicense, System.Drawing.Color.Empty)
      Me.txtLicense.Location = New System.Drawing.Point(576, 223)
      Me.Validator.SetMinValue(Me.txtLicense, "")
      Me.txtLicense.Name = "txtLicense"
      Me.Validator.SetRegularExpression(Me.txtLicense, "")
      Me.Validator.SetRequired(Me.txtLicense, False)
      Me.txtLicense.Size = New System.Drawing.Size(136, 20)
      Me.txtLicense.TabIndex = 8
      '
      'txtCum
      '
      Me.txtCum.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCum, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCum, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCum, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCum, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCum, System.Drawing.Color.Empty)
      Me.txtCum.Location = New System.Drawing.Point(576, 247)
      Me.Validator.SetMinValue(Me.txtCum, "")
      Me.txtCum.Name = "txtCum"
      Me.Validator.SetRegularExpression(Me.txtCum, "")
      Me.Validator.SetRequired(Me.txtCum, False)
      Me.txtCum.Size = New System.Drawing.Size(136, 20)
      Me.txtCum.TabIndex = 9
      '
      'txtRepresentAddress
      '
      Me.txtRepresentAddress.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtRepresentAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRepresentAddress, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRepresentAddress, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRepresentAddress, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRepresentAddress, System.Drawing.Color.Empty)
      Me.txtRepresentAddress.Location = New System.Drawing.Point(119, 208)
      Me.Validator.SetMinValue(Me.txtRepresentAddress, "")
      Me.txtRepresentAddress.Name = "txtRepresentAddress"
      Me.Validator.SetRegularExpression(Me.txtRepresentAddress, "")
      Me.Validator.SetRequired(Me.txtRepresentAddress, False)
      Me.txtRepresentAddress.Size = New System.Drawing.Size(320, 20)
      Me.txtRepresentAddress.TabIndex = 8
      '
      'txtAddress
      '
      Me.txtAddress.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAddress, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAddress, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.txtAddress.Location = New System.Drawing.Point(119, 88)
      Me.Validator.SetMinValue(Me.txtAddress, "")
      Me.txtAddress.Name = "txtAddress"
      Me.Validator.SetRegularExpression(Me.txtAddress, "")
      Me.Validator.SetRequired(Me.txtAddress, True)
      Me.txtAddress.Size = New System.Drawing.Size(320, 20)
      Me.txtAddress.TabIndex = 3
      '
      'txtBookNo
      '
      Me.Validator.SetDataType(Me.txtBookNo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBookNo, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBookNo, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBookNo, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBookNo, System.Drawing.Color.Empty)
      Me.txtBookNo.Location = New System.Drawing.Point(135, 116)
      Me.Validator.SetMinValue(Me.txtBookNo, "")
      Me.txtBookNo.Name = "txtBookNo"
      Me.Validator.SetRegularExpression(Me.txtBookNo, "")
      Me.Validator.SetRequired(Me.txtBookNo, False)
      Me.txtBookNo.Size = New System.Drawing.Size(128, 20)
      Me.txtBookNo.TabIndex = 0
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
      'txtAmount
      '
      Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.txtAmount.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(645, 353)
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, False)
      Me.txtAmount.Size = New System.Drawing.Size(112, 20)
      Me.txtAmount.TabIndex = 49
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalAmount
      '
      Me.txtTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTotalAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalAmount, "")
      Me.txtTotalAmount.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.txtTotalAmount.Location = New System.Drawing.Point(645, 377)
      Me.Validator.SetMinValue(Me.txtTotalAmount, "")
      Me.txtTotalAmount.Name = "txtTotalAmount"
      Me.Validator.SetRegularExpression(Me.txtTotalAmount, "")
      Me.Validator.SetRequired(Me.txtTotalAmount, False)
      Me.txtTotalAmount.Size = New System.Drawing.Size(112, 20)
      Me.txtTotalAmount.TabIndex = 51
      Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtSeqId
      '
      Me.txtSeqId.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtSeqId, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSeqId, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSeqId, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSeqId, System.Drawing.Color.Empty)
      Me.txtSeqId.Location = New System.Drawing.Point(119, 16)
      Me.Validator.SetMinValue(Me.txtSeqId, "")
      Me.txtSeqId.Name = "txtSeqId"
      Me.Validator.SetRegularExpression(Me.txtSeqId, "")
      Me.Validator.SetRequired(Me.txtSeqId, False)
      Me.txtSeqId.Size = New System.Drawing.Size(144, 20)
      Me.txtSeqId.TabIndex = 0
      '
      'lblPrintName
      '
      Me.lblPrintName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPrintName.Location = New System.Drawing.Point(39, 40)
      Me.lblPrintName.Name = "lblPrintName"
      Me.lblPrintName.Size = New System.Drawing.Size(80, 18)
      Me.lblPrintName.TabIndex = 13
      Me.lblPrintName.Text = "ชื่อหัก ณ ที่จ่าย:"
      Me.lblPrintName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.Button1)
      Me.grbDetail.Controls.Add(Me.FixedGroupBox1)
      Me.grbDetail.Controls.Add(Me.chkWHT)
      Me.grbDetail.Controls.Add(Me.lbWhtList)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.txtCompanySupport)
      Me.grbDetail.Controls.Add(Me.lblCompanySupport)
      Me.grbDetail.Controls.Add(Me.txtLicense)
      Me.grbDetail.Controls.Add(Me.lblLicense)
      Me.grbDetail.Controls.Add(Me.grbRefDoc)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.txtAmount)
      Me.grbDetail.Controls.Add(Me.lblAmount)
      Me.grbDetail.Controls.Add(Me.lbltem)
      Me.grbDetail.Controls.Add(Me.txtEmployerAcct)
      Me.grbDetail.Controls.Add(Me.lblEmployerAcct)
      Me.grbDetail.Controls.Add(Me.txtEmployeeSSN)
      Me.grbDetail.Controls.Add(Me.lblEmployeeSSN)
      Me.grbDetail.Controls.Add(Me.txtCum)
      Me.grbDetail.Controls.Add(Me.lblCum)
      Me.grbDetail.Controls.Add(Me.lblBookNo)
      Me.grbDetail.Controls.Add(Me.txtBookNo)
      Me.grbDetail.Controls.Add(Me.ibtnAddWht)
      Me.grbDetail.Controls.Add(Me.ibtnDelWht)
      Me.grbDetail.Controls.Add(Me.txtTotalAmount)
      Me.grbDetail.Controls.Add(Me.lblTotalAmount)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 2)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(768, 510)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ภาษีหัก ณ ที่จ่าย"
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(25, 132)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(57, 23)
      Me.Button1.TabIndex = 53
      Me.Button1.Text = "Refresh"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'FixedGroupBox1
      '
      Me.FixedGroupBox1.Controls.Add(Me.txtSeqId)
      Me.FixedGroupBox1.Controls.Add(Me.txtPrintName)
      Me.FixedGroupBox1.Controls.Add(Me.lblRepresentIdNo)
      Me.FixedGroupBox1.Controls.Add(Me.txtAddress)
      Me.FixedGroupBox1.Controls.Add(Me.lblAddress)
      Me.FixedGroupBox1.Controls.Add(Me.txtRepresentAddress)
      Me.FixedGroupBox1.Controls.Add(Me.lblRepresentAddress)
      Me.FixedGroupBox1.Controls.Add(Me.txtOtherPaymentType)
      Me.FixedGroupBox1.Controls.Add(Me.lblType)
      Me.FixedGroupBox1.Controls.Add(Me.cmbType)
      Me.FixedGroupBox1.Controls.Add(Me.lblRepresentative)
      Me.FixedGroupBox1.Controls.Add(Me.lblTaxId)
      Me.FixedGroupBox1.Controls.Add(Me.txtRepresentative)
      Me.FixedGroupBox1.Controls.Add(Me.cmbPaymentType)
      Me.FixedGroupBox1.Controls.Add(Me.txtRepresentIdNo)
      Me.FixedGroupBox1.Controls.Add(Me.txtTaxId)
      Me.FixedGroupBox1.Controls.Add(Me.txtRepresentTaxId)
      Me.FixedGroupBox1.Controls.Add(Me.txtIdNo)
      Me.FixedGroupBox1.Controls.Add(Me.lblRepresentTaxId)
      Me.FixedGroupBox1.Controls.Add(Me.lblSeqId)
      Me.FixedGroupBox1.Controls.Add(Me.lblIdNo)
      Me.FixedGroupBox1.Controls.Add(Me.lblPrintName)
      Me.FixedGroupBox1.Controls.Add(Me.lblPaymentType)
      Me.FixedGroupBox1.Location = New System.Drawing.Point(16, 137)
      Me.FixedGroupBox1.Name = "FixedGroupBox1"
      Me.FixedGroupBox1.Size = New System.Drawing.Size(454, 236)
      Me.FixedGroupBox1.TabIndex = 54
      Me.FixedGroupBox1.TabStop = False
      '
      'lblRepresentIdNo
      '
      Me.lblRepresentIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRepresentIdNo.Location = New System.Drawing.Point(215, 184)
      Me.lblRepresentIdNo.Name = "lblRepresentIdNo"
      Me.lblRepresentIdNo.Size = New System.Drawing.Size(136, 18)
      Me.lblRepresentIdNo.TabIndex = 30
      Me.lblRepresentIdNo.Text = "เลขประจำตัวประชาชน:"
      Me.lblRepresentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAddress
      '
      Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAddress.Location = New System.Drawing.Point(23, 88)
      Me.lblAddress.Name = "lblAddress"
      Me.lblAddress.Size = New System.Drawing.Size(96, 18)
      Me.lblAddress.TabIndex = 19
      Me.lblAddress.Text = "ที่อยู่:"
      Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRepresentAddress
      '
      Me.lblRepresentAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRepresentAddress.Location = New System.Drawing.Point(23, 208)
      Me.lblRepresentAddress.Name = "lblRepresentAddress"
      Me.lblRepresentAddress.Size = New System.Drawing.Size(96, 18)
      Me.lblRepresentAddress.TabIndex = 32
      Me.lblRepresentAddress.Text = "ที่อยู่:"
      Me.lblRepresentAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblType
      '
      Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblType.Location = New System.Drawing.Point(39, 112)
      Me.lblType.Name = "lblType"
      Me.lblType.Size = New System.Drawing.Size(80, 18)
      Me.lblType.TabIndex = 21
      Me.lblType.Text = "ประเภท:"
      Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRepresentative
      '
      Me.lblRepresentative.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRepresentative.Location = New System.Drawing.Point(23, 160)
      Me.lblRepresentative.Name = "lblRepresentative"
      Me.lblRepresentative.Size = New System.Drawing.Size(96, 18)
      Me.lblRepresentative.TabIndex = 26
      Me.lblRepresentative.Text = "กระทำการแทนโดย:"
      Me.lblRepresentative.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRepresentTaxId
      '
      Me.lblRepresentTaxId.BackColor = System.Drawing.Color.Transparent
      Me.lblRepresentTaxId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRepresentTaxId.Location = New System.Drawing.Point(-1, 184)
      Me.lblRepresentTaxId.Name = "lblRepresentTaxId"
      Me.lblRepresentTaxId.Size = New System.Drawing.Size(120, 18)
      Me.lblRepresentTaxId.TabIndex = 28
      Me.lblRepresentTaxId.Text = "เลขประจำตัวผู้เสียภาษี:"
      Me.lblRepresentTaxId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSeqId
      '
      Me.lblSeqId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSeqId.Location = New System.Drawing.Point(39, 16)
      Me.lblSeqId.Name = "lblSeqId"
      Me.lblSeqId.Size = New System.Drawing.Size(80, 18)
      Me.lblSeqId.TabIndex = 13
      Me.lblSeqId.Text = "ลำดับที่:"
      Me.lblSeqId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkWHT
      '
      Me.chkWHT.Location = New System.Drawing.Point(512, 19)
      Me.chkWHT.Name = "chkWHT"
      Me.chkWHT.Size = New System.Drawing.Size(200, 24)
      Me.chkWHT.TabIndex = 4
      Me.chkWHT.Text = "คิดภาษีหัก ณ ที่จ่าย ก่อนจ่ายเงิน"
      '
      'lbWhtList
      '
      Me.lbWhtList.Location = New System.Drawing.Point(512, 51)
      Me.lbWhtList.Name = "lbWhtList"
      Me.lbWhtList.ScrollAlwaysVisible = True
      Me.lbWhtList.Size = New System.Drawing.Size(176, 56)
      Me.lbWhtList.TabIndex = 3
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(435, 116)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 9
      '
      'lblCompanySupport
      '
      Me.lblCompanySupport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCompanySupport.Location = New System.Drawing.Point(480, 199)
      Me.lblCompanySupport.Name = "lblCompanySupport"
      Me.lblCompanySupport.Size = New System.Drawing.Size(96, 18)
      Me.lblCompanySupport.TabIndex = 38
      Me.lblCompanySupport.Text = "เงินสมทบฯ:"
      Me.lblCompanySupport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLicense
      '
      Me.lblLicense.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLicense.Location = New System.Drawing.Point(464, 223)
      Me.lblLicense.Name = "lblLicense"
      Me.lblLicense.Size = New System.Drawing.Size(112, 18)
      Me.lblLicense.TabIndex = 40
      Me.lblLicense.Text = "ใบอนุญาตเลขที่:"
      Me.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbRefDoc
      '
      Me.grbRefDoc.Controls.Add(Me.txtRefTaxBase)
      Me.grbRefDoc.Controls.Add(Me.txtRefDocDate)
      Me.grbRefDoc.Controls.Add(Me.lblDirection)
      Me.grbRefDoc.Controls.Add(Me.lblRefTaxBase)
      Me.grbRefDoc.Controls.Add(Me.lblRefDocDate)
      Me.grbRefDoc.Controls.Add(Me.dtpRefDocDate)
      Me.grbRefDoc.Controls.Add(Me.txtRefDocCode)
      Me.grbRefDoc.Controls.Add(Me.lblRefDoc)
      Me.grbRefDoc.Controls.Add(Me.cmbDirection)
      Me.grbRefDoc.Controls.Add(Me.Label2)
      Me.grbRefDoc.Controls.Add(Me.txtSupplierName)
      Me.grbRefDoc.Controls.Add(Me.lblSupplier)
      Me.grbRefDoc.Controls.Add(Me.txtSupplierCode)
      Me.grbRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbRefDoc.Location = New System.Drawing.Point(16, 13)
      Me.grbRefDoc.Name = "grbRefDoc"
      Me.grbRefDoc.Size = New System.Drawing.Size(488, 96)
      Me.grbRefDoc.TabIndex = 0
      Me.grbRefDoc.TabStop = False
      Me.grbRefDoc.Text = "เอกสารอ้างอิง"
      '
      'lblDirection
      '
      Me.lblDirection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDirection.ForeColor = System.Drawing.Color.Black
      Me.lblDirection.Location = New System.Drawing.Point(31, 40)
      Me.lblDirection.Name = "lblDirection"
      Me.lblDirection.Size = New System.Drawing.Size(88, 18)
      Me.lblDirection.TabIndex = 5
      Me.lblDirection.Text = "ประเภทภาษี:"
      Me.lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefTaxBase
      '
      Me.lblRefTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefTaxBase.ForeColor = System.Drawing.Color.Black
      Me.lblRefTaxBase.Location = New System.Drawing.Point(247, 40)
      Me.lblRefTaxBase.Name = "lblRefTaxBase"
      Me.lblRefTaxBase.Size = New System.Drawing.Size(56, 18)
      Me.lblRefTaxBase.TabIndex = 7
      Me.lblRefTaxBase.Text = "ฐานภาษี:"
      Me.lblRefTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefDocDate
      '
      Me.lblRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRefDocDate.Location = New System.Drawing.Point(263, 17)
      Me.lblRefDocDate.Name = "lblRefDocDate"
      Me.lblRefDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblRefDocDate.TabIndex = 2
      Me.lblRefDocDate.Text = "วันที่:"
      Me.lblRefDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpRefDocDate
      '
      Me.dtpRefDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpRefDocDate.Enabled = False
      Me.dtpRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpRefDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpRefDocDate.Location = New System.Drawing.Point(303, 16)
      Me.dtpRefDocDate.Name = "dtpRefDocDate"
      Me.dtpRefDocDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpRefDocDate.TabIndex = 4
      Me.dtpRefDocDate.TabStop = False
      '
      'lblRefDoc
      '
      Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDoc.Location = New System.Drawing.Point(15, 17)
      Me.lblRefDoc.Name = "lblRefDoc"
      Me.lblRefDoc.Size = New System.Drawing.Size(104, 18)
      Me.lblRefDoc.TabIndex = 0
      Me.lblRefDoc.Text = "เลขที่เอกสารอ้างอิง:"
      Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(443, 40)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(32, 18)
      Me.Label2.TabIndex = 9
      Me.Label2.Text = "บาท"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.Location = New System.Drawing.Point(200, 384)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(38, 13)
      Me.lblStatus.TabIndex = 47
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(136, 376)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 45
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(160, 376)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 46
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDocDate.Location = New System.Drawing.Point(479, 116)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblDocDate.TabIndex = 10
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(519, 116)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpDocDate.TabIndex = 12
      Me.dtpDocDate.TabStop = False
      '
      'lblAmount
      '
      Me.lblAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.Location = New System.Drawing.Point(524, 353)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(120, 18)
      Me.lblAmount.TabIndex = 48
      Me.lblAmount.Text = "รวมภาษีหัก ณ ที่จ่าย:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblEmployerAcct
      '
      Me.lblEmployerAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEmployerAcct.Location = New System.Drawing.Point(480, 151)
      Me.lblEmployerAcct.Name = "lblEmployerAcct"
      Me.lblEmployerAcct.Size = New System.Drawing.Size(96, 18)
      Me.lblEmployerAcct.TabIndex = 34
      Me.lblEmployerAcct.Text = "เลขที่บัญชีนายจ้าง:"
      Me.lblEmployerAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblEmployeeSSN
      '
      Me.lblEmployeeSSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEmployeeSSN.Location = New System.Drawing.Point(464, 175)
      Me.lblEmployeeSSN.Name = "lblEmployeeSSN"
      Me.lblEmployeeSSN.Size = New System.Drawing.Size(112, 18)
      Me.lblEmployeeSSN.TabIndex = 36
      Me.lblEmployeeSSN.Text = "เลขที่บัตรประกันสังคม:"
      Me.lblEmployeeSSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCum
      '
      Me.lblCum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCum.Location = New System.Drawing.Point(464, 247)
      Me.lblCum.Name = "lblCum"
      Me.lblCum.Size = New System.Drawing.Size(112, 18)
      Me.lblCum.TabIndex = 42
      Me.lblCum.Text = "เงินสะสมฯ:"
      Me.lblCum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBookNo
      '
      Me.lblBookNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBookNo.Location = New System.Drawing.Point(87, 116)
      Me.lblBookNo.Name = "lblBookNo"
      Me.lblBookNo.Size = New System.Drawing.Size(48, 18)
      Me.lblBookNo.TabIndex = 5
      Me.lblBookNo.Text = "เล่มที่:"
      Me.lblBookNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnAddWht
      '
      Me.ibtnAddWht.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnAddWht.Location = New System.Drawing.Point(688, 51)
      Me.ibtnAddWht.Name = "ibtnAddWht"
      Me.ibtnAddWht.Size = New System.Drawing.Size(24, 24)
      Me.ibtnAddWht.TabIndex = 3
      Me.ibtnAddWht.TabStop = False
      Me.ibtnAddWht.ThemedImage = CType(resources.GetObject("ibtnAddWht.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelWht
      '
      Me.ibtnDelWht.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelWht.Location = New System.Drawing.Point(688, 75)
      Me.ibtnDelWht.Name = "ibtnDelWht"
      Me.ibtnDelWht.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelWht.TabIndex = 4
      Me.ibtnDelWht.TabStop = False
      Me.ibtnDelWht.ThemedImage = CType(resources.GetObject("ibtnDelWht.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblTotalAmount
      '
      Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotalAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalAmount.Location = New System.Drawing.Point(476, 377)
      Me.lblTotalAmount.Name = "lblTotalAmount"
      Me.lblTotalAmount.Size = New System.Drawing.Size(168, 18)
      Me.lblTotalAmount.TabIndex = 50
      Me.lblTotalAmount.Text = "รวมภาษีหัก ณ ที่จ่ายทุกเอกสาร:"
      Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'WHTDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "WHTDetail"
      Me.Size = New System.Drawing.Size(784, 520)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.FixedGroupBox1.ResumeLayout(False)
      Me.FixedGroupBox1.PerformLayout()
      Me.grbRefDoc.ResumeLayout(False)
      Me.grbRefDoc.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblBookNo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblBookNo}")
      Me.Validator.SetDisplayName(txtBookNo, lblBookNo.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblDocDate}")
      Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

      Me.lblPrintName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblPrintName}")
      Me.Validator.SetDisplayName(txtPrintName, lblPrintName.Text)

      Me.lblTaxId.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblCodeTax}")
      Me.Validator.SetDisplayName(txtTaxId, lblTaxId.Text)

      Me.lblIdNo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblIdNo}")
      Me.Validator.SetDisplayName(txtIdNo, lblIdNo.Text)

      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblSupplier}")
      Me.lblPaymentType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblPaymentType}")
      Me.lbltem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lbltem}")
      Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblType}")
      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblAmount}")

      ' Groupbox
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.grbDetail}")

      Me.lblAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblAddress}")
      Me.Validator.SetDisplayName(txtAddress, lblAddress.Text)

      Me.lblRepresentative.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblRepresentative}")
      Me.Validator.SetDisplayName(txtRepresentative, lblRepresentative.Text)

      Me.lblRepresentIdNo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblRepresentIdNo}")
      Me.Validator.SetDisplayName(txtRepresentIdNo, lblRepresentIdNo.Text)

      Me.lblRepresentTaxId.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblRepresentTaxId}")
      Me.Validator.SetDisplayName(txtRepresentTaxId, lblRepresentTaxId.Text)

      Me.lblRepresentAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblRepresentAddress}")
      Me.Validator.SetDisplayName(txtRepresentAddress, lblRepresentAddress.Text)

      Me.lblEmployerAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblEmployerAcct}")
      Me.Validator.SetDisplayName(txtEmployerAcct, lblEmployerAcct.Text)

      Me.lblEmployeeSSN.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblEmployeeSSN}")
      Me.Validator.SetDisplayName(txtEmployeeSSN, lblEmployeeSSN.Text)

      Me.lblCompanySupport.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblCompanySupport}")
      Me.Validator.SetDisplayName(txtCompanySupport, lblCompanySupport.Text)

      Me.lblLicense.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblLicense}")
      Me.Validator.SetDisplayName(txtLicense, lblLicense.Text)

      Me.lblCum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblCum}")
      Me.Validator.SetDisplayName(txtCum, lblCum.Text)

      Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
      Me.chkWHT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.chkWHT}")
      Me.lblSeqId.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.lblSeqId}")
    End Sub
#End Region

#Region "Members"
    Private m_entity As ISimpleEntity
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_wht As WitholdingTax
    Private m_whtcol As WitholdingTaxCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = WitholdingTax.GetSchemaTable()
      Dim dst As DataGridTableStyle = WitholdingTax.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      EventWiring()

    End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value >= 4) _
      OrElse (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value = 0) Then
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In grbDetail.Controls
          If Not TypeOf ctrl Is CheckBox Then
            ctrl.Enabled = True
          End If
          tgItem.Enabled = True
          For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
            colStyle.ReadOnly = False
          Next
        Next
        cmbType.Enabled = True
      End If
      If Not Me.m_whtcol Is Nothing AndAlso _
        Not Me.m_whtcol.RefDoc Is Nothing AndAlso _
        TypeOf Me.m_whtcol.RefDoc Is SimpleBusinessEntityBase Then
        If CType(Me.m_whtcol.RefDoc, SimpleBusinessEntityBase).IsReferenced() Then
          'For Each ctrl As Control In grbDetail.Controls
          '  If Not ctrl.Name.ToLower = "fixedgroupbox1" Then
          '    ctrl.Enabled = False
          '  End If
          'Next
          FixedGroupBox1.Enabled = True
          Me.ibtnAddWht.Enabled = False
          Me.ibtnDelWht.Enabled = False
          Me.ibtnBlank.Enabled = False
          Me.ibtnDelRow.Enabled = False
          For Each ctrl As Control In FixedGroupBox1.Controls
            If ctrl.Name.ToLower = "cmbtype" Then
              ctrl.Enabled = False
            Else
              ctrl.Enabled = True
            End If
          Next
          tgItem.Enabled = True
          lbWhtList.Enabled = True
          For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
            If colStyle.MappingName = "whti_note" Then
              colStyle.ReadOnly = False
            Else
              colStyle.ReadOnly = True
            End If
          Next
        End If
      End If
    End Sub

    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Sub RefreshAutoComplete(ByVal entityId As Integer) Implements ICanRefreshAutoComplete.RefreshAutoComplete
      'ย้ายมาไว้ตรงนี้เพื่อให้ Refresh
      Select Case entityId
        Case 10, 2
          Me.txtPrintName.AutoCompleteSource = AutoCompleteSource.CustomSource
          Me.txtPrintName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
          Dim a As New AutoCompleteStringCollection
          For Each kv As Generic.KeyValuePair(Of String, String) In Supplier.InfoList
            a.Add(kv.Value & " [" & kv.Key & "] " & SUPPLIER_TYPE_TEXT)
          Next
          For Each kv As Generic.KeyValuePair(Of String, String) In Supplier.InfoList
            a.Add("[" & kv.Key & "] " & kv.Value & " " & SUPPLIER_TYPE_TEXT)
          Next
          For Each kv As Generic.KeyValuePair(Of String, String) In Customer.InfoList
            a.Add(kv.Value & " [" & kv.Key & "] " & CUSTOMER_TYPE_TEXT)
          Next
          For Each kv As Generic.KeyValuePair(Of String, String) In Customer.InfoList
            a.Add("[" & kv.Key & "] " & kv.Value & " " & CUSTOMER_TYPE_TEXT)
          Next
          Me.txtPrintName.AutoCompleteCustomSource = a
      End Select
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.Validated, AddressOf Me.CodeValidated
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtBookNo.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtIdNo.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtOtherPaymentType.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPrintName.Validated, AddressOf Me.ChangeProperty
      AddHandler txtTaxId.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbPaymentType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtAddress.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRepresentative.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRepresentIdNo.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRepresentTaxId.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRepresentAddress.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtEmployerAcct.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtEmployeeSSN.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCompanySupport.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtLicense.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCum.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtSeqId.TextChanged, AddressOf Me.ChangeProperty
    End Sub

    Dim oldRefDoc As String

    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_wht Is Nothing Then
        Return
      End If

      For Each item As IdValuePair In Me.cmbPaymentType.Items
        If Me.m_wht.PaymentType.Value = item.Id Then
          Me.cmbPaymentType.SelectedItem = item
        End If
      Next

      UpdatePaymentType()

      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_wht.ItemTable
      AddHandler Me.m_wht.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      'txtDocDate.Text = MinDateToNull(Me.m_wht.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      txtDocDate.Text = MinDateToNull(Me.m_wht.DocDate, "")
      dtpDocDate.Value = MinDateToNow(Me.m_wht.DocDate)
      Me.txtBookNo.Text = Me.m_wht.BookNo
      Me.txtCode.Text = Me.m_wht.Code
      Me.txtSeqId.Text = Me.m_wht.SequenceNo

      'UpdateCheckWHT()
      Me.chkWHT.Enabled = Me.m_whtcol.CanBeDelay
      Me.chkWHT.Checked = Me.m_whtcol.IsBeforePay

      If Not Me.m_whtcol.CanBeDelay Then
        'UpdateAutogenStatus()
        Me.chkAutorun.Checked = Me.m_wht.AutoGen
        If Me.chkAutorun.Checked Then
          Me.txtCode.ReadOnly = True
        Else
          Me.txtCode.ReadOnly = False
        End If
      Else
        If Not Me.m_whtcol.IsBeforePay Then
          'UpdateAutogenStatus()
          Me.chkAutorun.Checked = Me.m_wht.AutoGen
          If Me.chkAutorun.Checked Then
            Me.txtCode.ReadOnly = True
          Else
            Me.txtCode.ReadOnly = False
          End If
        Else
          Me.chkAutorun.Enabled = False
          Me.chkAutorun.Checked = False
          Me.txtCode.ReadOnly = True
        End If
      End If

      UpdateAmount()
      UpdateRefDoc()

      RefreshBlankGrid()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdatePaymentType()
      Dim oldStatus As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.txtOtherPaymentType.Text = Me.m_wht.PaymentType.OtherPaymentType
      'Hack Hard-coded
      If Me.m_wht.PaymentType.Value = 4 Then
        Me.txtOtherPaymentType.ReadOnly = False
      Else
        Me.txtOtherPaymentType.ReadOnly = True
      End If
      m_isInitialized = oldStatus
    End Sub
    Private Sub UpdateRefDoc()
      Dim oldStatus As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False

      Me.txtRefDocCode.Text = Me.m_wht.RefDoc.Code
      Me.txtRefDocDate.Text = MinDateToNull(Me.m_wht.RefDoc.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      Me.dtpRefDocDate.Value = MinDateToNow(Me.m_wht.RefDoc.Date)
      Me.txtRefTaxBase.Text = Configuration.FormatToString(Me.m_whtcol.RefDoc.GetMaximumWitholdingTaxBase, DigitConfig.Price)
      For Each item As IdValuePair In Me.cmbDirection.Items
        If Me.m_wht.Direction.Value = item.Id Then
          Me.cmbDirection.SelectedItem = item
        End If
      Next

      Me.txtSupplierCode.Text = Me.m_whtcol.RefDoc.Person.Code
      Me.txtSupplierName.Text = Me.m_whtcol.RefDoc.Person.Name
      Me.m_wht.UpdateRefDoc()

      Me.txtRepresentative.Text = Me.m_wht.RepresentName
      Me.txtRepresentIdNo.Text = Me.m_wht.RepresentIdNo
      Me.txtRepresentTaxId.Text = Me.m_wht.RepresentTaxId
      Me.txtRepresentAddress.Text = Me.m_wht.RepresentAddress
      Me.txtEmployerAcct.Text = Me.m_wht.EmployerAcct
      Me.txtEmployeeSSN.Text = Me.m_wht.EmployeeSSN
      Me.txtCompanySupport.Text = Me.m_wht.CompanySupport
      Me.txtLicense.Text = Me.m_wht.License
      Me.txtCum.Text = Me.m_wht.Cumulative

      UpdatePerson()

      'UpdateCheckWHT()

      m_isInitialized = oldStatus
    End Sub
    Private Sub UpdatePerson()
      Dim oldStatus As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.txtIdNo.Text = Me.m_wht.EntityIdNo
      Me.txtTaxId.Text = Me.m_wht.EntityTaxId
      Me.txtPrintName.Text = Me.m_wht.PrintName
      Me.txtAddress.Text = Me.m_wht.EntityAddress

      For Each item As IdValuePair In Me.cmbType.Items
        If Me.m_wht.Type.Value = item.Id Then
          Me.cmbType.SelectedItem = item
        End If
      Next
      m_isInitialized = oldStatus
    End Sub

    Private Sub UpdateAmount()
      Me.txtAmount.Text = Configuration.FormatToString(Me.m_wht.Amount, DigitConfig.Price)
      Me.txtTotalAmount.Text = Configuration.FormatToString(Me.m_whtcol.Amount, DigitConfig.Price)
      If Me.m_wht.MaxRowIndex = -1 Then
        Me.Validator.SetRequired(txtCode, False)
        Me.Validator.SetRequired(txtDocDate, False)
        Me.Validator.SetRequired(txtPrintName, False)
        Me.Validator.SetRequired(txtAddress, False)
        'Me.txtDocDate.Text = ""
        Me.Validator.SetDataType(txtDocDate, DataTypeConstants.StringType)
        Me.ErrorProvider1.SetError(Me.txtDocDate, "")
        Me.ErrorProvider1.SetError(Me.txtPrintName, "")
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.ErrorProvider1.SetError(Me.txtAddress, "")
      Else
        Me.Validator.SetDataType(txtDocDate, DataTypeConstants.DateTimeType)
        Me.Validator.SetRequired(txtDocDate, True)
        Me.Validator.SetRequired(txtPrintName, True)
        Me.Validator.SetRequired(txtCode, True)
        Me.Validator.SetRequired(txtAddress, True)
      End If
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()
        UpdateRefDoc()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub CodeValidated(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_txtCodeChange Then
        Me.m_wht.Code = txtCode.Text
        m_dontUpdate = True
        UpdateWitholdingList()
        m_dontUpdate = False
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        m_txtCodeChange = False
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Private m_txtCodeChange As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_wht Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtseqid"
          Me.m_wht.SequenceNo = txtSeqId.Text
          dirtyFlag = True
        Case "txtcode"
          m_txtCodeChange = True
          dirtyFlag = True
        Case "txtbookno"
          Me.m_wht.BookNo = txtBookNo.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_wht.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_wht.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_wht.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_wht.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            Me.m_wht.DocDate = Date.Now
            Me.m_wht.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtidno"
          Me.m_wht.EntityIdNo = txtIdNo.Text
          dirtyFlag = True
        Case "txtotherpaymenttype"
          Me.m_wht.PaymentType.OtherPaymentType = txtOtherPaymentType.Text
          dirtyFlag = True
        Case "txtprintname"
          Dim txt As String = txtPrintName.Text
          Dim reg As New Regex("\[(.*)\]")
          If reg.IsMatch(txt) Then
            Dim person As IBillablePerson
            If txt.Contains(CUSTOMER_TYPE_TEXT) Then
              Try
                person = New Customer(reg.Match(txt).Groups(1).Value)
              Catch ex As Exception
              End Try
            ElseIf txt.Contains(SUPPLIER_TYPE_TEXT) Then
              Try
                person = New Supplier(reg.Match(txt).Groups(1).Value)
              Catch ex As Exception
              End Try
            End If
            dirtyFlag = True
            If Not person Is Nothing AndAlso person.Id <> 0 Then
              Me.m_wht.UpdateRefDoc(person, True)
            End If
          Else
            Me.m_wht.PrintName = txt
          End If
          Dim flag As Boolean = m_isInitialized
          m_isInitialized = False
          UpdatePerson()
          m_isInitialized = flag
          dirtyFlag = True
        Case "txttaxid"
          Me.m_wht.EntityTaxId = txtTaxId.Text
          dirtyFlag = True
        Case "cmbtype"
          Dim item As IdValuePair = CType(Me.cmbType.SelectedItem, IdValuePair)
          Me.m_wht.Type.Value = item.Id
          dirtyFlag = True
        Case "cmbpaymenttype"
          Dim item As IdValuePair = CType(Me.cmbPaymentType.SelectedItem, IdValuePair)
          Me.m_wht.PaymentType.Value = item.Id
          UpdatePaymentType()
          dirtyFlag = True
        Case "txtaddress"
          Me.m_wht.EntityAddress = txtAddress.Text
          dirtyFlag = True
          txtAddress.Text = Me.m_wht.EntityAddress
        Case "txtrepresentative"
          Me.m_wht.RepresentName = txtRepresentative.Text
          dirtyFlag = True
        Case "txtrepresentidno"
          Me.m_wht.RepresentIdNo = txtRepresentIdNo.Text
          dirtyFlag = True
        Case "txtrepresenttaxid"
          Me.m_wht.RepresentTaxId = txtRepresentTaxId.Text
          dirtyFlag = True
        Case "txtrepresentaddress"
          Me.m_wht.RepresentAddress = txtRepresentAddress.Text
          dirtyFlag = True
          txtRepresentAddress.Text = Me.m_wht.RepresentAddress
        Case "txtemployeracct"
          Me.m_wht.EmployerAcct = txtEmployerAcct.Text
          dirtyFlag = True
          txtEmployerAcct.Text = Me.m_wht.EmployerAcct
        Case "txtemployeessn"
          Me.m_wht.EmployeeSSN = txtEmployeeSSN.Text
          dirtyFlag = True
          txtEmployeeSSN.Text = Me.m_wht.EmployeeSSN
        Case "txtcompanysupport"
          Me.m_wht.CompanySupport = txtCompanySupport.Text
          dirtyFlag = True
        Case "txtlicense"
          Me.m_wht.License = txtLicense.Text
          dirtyFlag = True
        Case "txtcum"
          Me.m_wht.Cumulative = txtCum.Text
          dirtyFlag = True
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
      'UpdateCheckWHT()
    End Sub
    Public Sub SetStatus()
      If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
        lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name
      ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
        lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name
      ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
        lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
      Else
        lblStatus.Text = ""
      End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = Value

          If Not m_whtcol Is Nothing Then
            Me.m_whtcol = Nothing
          End If
          If Not m_wht Is Nothing Then
            RemoveHandler Me.m_wht.PropertyChanged, AddressOf PropChanged
            Me.m_wht = Nothing
          End If
          If TypeOf m_entity Is IWitholdingTaxable Then
            Dim whtRefDoc As IWitholdingTaxable = CType(m_entity, IWitholdingTaxable)
            Me.m_whtcol = whtRefDoc.WitholdingTaxCollection

            If m_whtcol Is Nothing Then
              m_whtcol = New WitholdingTaxCollection
              m_whtcol.RefDoc.WitholdingTaxCollection = m_whtcol
            End If

            If m_whtcol.Count > 0 Then
              For Each item As WitholdingTax In m_whtcol
                item.RefDoc.WitholdingTaxCollection = m_whtcol
                item.RefDoc = whtRefDoc
                item.Entity = whtRefDoc.Person
              Next
              m_wht = m_whtcol(0)
            Else
              'If whtRefDoc.WitholdingTaxCollection.Count > 0 AndAlso _
              '   Not whtRefDoc.WitholdingTaxCollection.CanBeDelay Then
              m_wht = New WitholdingTax
              m_wht.Code = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_wht.EntityId)
              m_wht.LastestCode = m_wht.Code
              m_wht.RefDoc.WitholdingTaxCollection = m_whtcol
              m_wht.RefDoc = whtRefDoc
              m_wht.Entity = whtRefDoc.Person
              m_whtcol.Add(m_wht)
              'End If
            End If

            If whtRefDoc.WitholdingTaxCollection.Count > 0 AndAlso _
               whtRefDoc.WitholdingTaxCollection.CanBeDelay Then

              Me.m_whtcol = whtRefDoc.WitholdingTaxCollection
            End If

            m_whtcol.RefDoc = whtRefDoc
          End If
        End If
        If Not Me.m_wht Is Nothing Then
          Me.m_wht.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If

        If m_whtcol.Count > 0 Then
          If Not m_whtcol Is Nothing AndAlso m_whtcol.Contains(m_whtcol(0)) Then
            m_wht = m_whtcol(0)
          End If
        Else
          If TypeOf m_entity Is IWitholdingTaxable Then
            Dim whtRefDoc As IWitholdingTaxable = CType(m_entity, IWitholdingTaxable)
            Me.m_whtcol = whtRefDoc.WitholdingTaxCollection

            m_wht = New WitholdingTax
            m_wht.Code = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_wht.EntityId)
            m_wht.LastestCode = m_wht.Code
            m_wht.RefDoc.WitholdingTaxCollection = m_whtcol
            m_wht.RefDoc = whtRefDoc
            m_wht.Entity = whtRefDoc.Person
            m_whtcol.Add(m_wht)
          End If
        End If

        UpdateWitholdingList()

      End Set
    End Property
    Public Const SUPPLIER_TYPE_TEXT As String = "(ผู้ขาย)"
    Public Const CUSTOMER_TYPE_TEXT As String = "(ลูกค้า)"

    Public Overrides Sub Initialize()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDirection, "wht_direction")
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbPaymentType, "wht_paymenttype")
      Me.cmbPaymentType.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "wht_type")
      Me.cmbType.SelectedIndex = 0

      RefreshAutoComplete(10)

    End Sub

    Public Sub UpdateWitholdingList()
      If Not m_whtcol Is Nothing Then
        m_whtcol.CreateListBox(lbWhtList)
        If Not m_wht Is Nothing Then
          Me.lbWhtList.SelectedItem = m_wht
        End If
        If m_wht Is Nothing AndAlso Not m_whtcol Is Nothing Then
          If m_whtcol.Count > 0 Then
            m_wht = m_whtcol(0)
          End If
        End If
      End If
    End Sub
#End Region

#Region "Buttons Event"
    Private m_dontUpdate As Boolean = False
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      If Me.m_wht Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      UpdateAutogenStatus()
      m_dontUpdate = True
      UpdateWitholdingList()
      m_dontUpdate = False
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        Me.m_wht.LastestCode = Me.txtCode.Text
        Me.m_wht.Code = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_wht.EntityId)
        Me.txtCode.Text = Me.m_wht.Code
        Me.m_wht.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.m_wht.Code = Me.m_wht.LastestCode
        Me.txtCode.Text = Me.m_wht.Code
        Me.txtCode.ReadOnly = False
        Me.m_wht.AutoGen = False
      End If
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_wht.MaxRowIndex Then
        Return
      End If
      Dim theItem As New WitholdingTaxItem
      Me.m_wht.Insert(index, theItem)
      Me.m_wht.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If index > Me.m_wht.MaxRowIndex Then
        Return
      End If
      Me.m_wht.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnAddWht_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddWht.Click
      m_wht = New WitholdingTax
      m_wht.RefDoc = m_whtcol.RefDoc
      m_wht.Entity = m_whtcol.RefDoc.Person

      If Not Me.m_whtcol.IsBeforePay Then
        m_wht.Code = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_wht.EntityId)
        m_wht.AutoGen = True
      Else
        m_wht.Code = WitholdingTaxCollection.fixCodeWHT
        m_wht.AutoGen = False
      End If

      m_wht.LastestCode = m_wht.Code
      m_whtcol.Add(m_wht)
      UpdateWitholdingList()
    End Sub
    Private Sub ibtnDelWht_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelWht.Click
      If m_whtcol.Count >= 1 Then
        Dim index As Integer = m_whtcol.IndexOf(m_wht)
        m_whtcol.Remove(m_wht)
        If m_whtcol.Count <= 0 Then
          m_wht = New WitholdingTax
          m_wht.RefDoc = m_whtcol.RefDoc
          m_wht.Entity = m_whtcol.RefDoc.Person

          If Not Me.m_whtcol.IsBeforePay Then
            m_wht.Code = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_wht.EntityId)
            m_wht.AutoGen = True
          Else
            m_wht.Code = WitholdingTaxCollection.fixCodeWHT
            m_wht.AutoGen = False
          End If

          m_wht.LastestCode = m_wht.Code
          m_whtcol.Add(m_wht)
        End If
        If m_whtcol.Count > index Then
          m_wht = m_whtcol(index)
        Else
          m_wht = m_whtcol(index - 1)
        End If
        UpdateWitholdingList()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub lbWhtList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbWhtList.SelectedIndexChanged
      If lbWhtList.SelectedItems.Count <= 0 Then
        Return
      End If
      m_wht = CType(lbWhtList.SelectedItem, WitholdingTax)
      If m_dontUpdate Then
        Return
      End If
      UpdateEntityProperties()
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
        Return (New WitholdingTax).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "IPrintable"
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
        Dim thePath As String = ""

        If Not Me.m_wht Is Nothing Then
          If TypeOf Me.m_wht Is IPrintableEntity Then
            'thePath = Microsoft.VisualBasic.InputBox("เลือกฟอร์ม", "เลือกฟอร์ม", thePath)
            Dim fileName As String = CType(Me.m_wht, IPrintableEntity).GetDefaultForm
            If fileName Is Nothing OrElse fileName.Length = 0 Then
              fileName = m_wht.ClassName
            End If
            thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"

            Dim paths As FormPaths
            Dim nameForPath As String
            nameForPath = m_wht.FullClassName & ".Documents"
            Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, m_wht.ClassName, thePath)), FormPaths)
            Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
            If dlg.ShowDialog() = DialogResult.OK Then
              thePath = dlg.KeyValuePair.Value
            Else
              Return Nothing
            End If

            If File.Exists(thePath) Then
              'Dim df As New DesignerForm(thePath, CType(Me.m_wht, IPrintableEntity))
              Dim df As New DesignerForm(thePath, New SuperPrintableEntity)
              Return df.PrintDocument
            End If
          End If
        End If
      End Get
    End Property
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_wht Is Nothing Then
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
        Me.m_wht.AddBlankRow(1)
      Loop

      If Me.m_wht.MaxRowIndex = Me.m_treeManager.Treetable.Rows.Count - 1 Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
      'MyBase.NotifyAfterSave(flag)
    End Sub
    Public Overrides Sub NotifyBeforeSave()
      MyBase.NotifyBeforeSave()
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

#Region "IAuxTab"
    Public ReadOnly Property AuxEntity() As IDirtyAble Implements IAuxTab.AuxEntity
      Get
        Return m_wht
      End Get
    End Property
#End Region

    Private Sub chkWHT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWHT.CheckedChanged
      If Not Me.m_isInitialized Then
        Return
      End If
      Me.m_whtcol.IsBeforePay = chkWHT.Checked

      If Me.m_whtcol.IsBeforePay Then

        Dim i As Integer = 0
        For Each wht As WitholdingTax In Me.m_whtcol
          If Not wht.Originated Then
            Me.m_whtcol(i).Code = WitholdingTaxCollection.fixCodeWHT
            Me.m_whtcol(i).AutoGen = False
          End If
          i += 1
        Next
        For Each row As TreeRow In Me.m_treeManager.Treetable.Rows

        Next
        If Not m_wht.Originated Then
          m_wht.Code = WitholdingTaxCollection.fixCodeWHT
          m_wht.AutoGen = False
        End If
        UpdateWitholdingList()
        chkAutorun.Enabled = False
        txtCode.ReadOnly = True
      Else

        Dim i As Integer = 0
        For Each wht As WitholdingTax In Me.m_whtcol
          Me.m_whtcol(i).Code = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_wht.EntityId)
          Me.m_whtcol(i).AutoGen = True
          i += 1
        Next
        m_wht.Code = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_wht.EntityId)
        m_wht.AutoGen = True
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        chkAutorun.Enabled = True
        Me.txtCode.ReadOnly = False
        UpdateWitholdingList()
      End If

      Me.WorkbenchWindow.ViewContent.IsDirty = True

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      Try
        Me.m_wht.UpdateRefDoc(Me.m_wht.RefDoc.Person, True)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        UpdatePerson()
      Catch ex As Exception

      End Try
    End Sub

    Public Sub SetNothing() Implements ISetNothingEntity.SetNothing
      Me.m_entity = Nothing
    End Sub

  End Class
End Namespace