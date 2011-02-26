Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Text.RegularExpressions

Namespace Longkong.Pojjaman.Gui.Panels

    Public Class AdvancePayClosedDetail
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
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents grbLocation As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtCCCode As System.Windows.Forms.TextBox
        Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
        Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
        Friend WithEvents txtCCName As System.Windows.Forms.TextBox
        Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
        Friend WithEvents lblAccount As System.Windows.Forms.Label
        Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
        Friend WithEvents txtAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblAmount As System.Windows.Forms.Label
        Friend WithEvents lblPCNote As System.Windows.Forms.Label
        Friend WithEvents grbHeader As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtRemaining As System.Windows.Forms.TextBox
        Friend WithEvents lblRemaining As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtdocdate As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblCurrencyUnit2 As System.Windows.Forms.Label
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblCurrencyUnit1 As System.Windows.Forms.Label
        Friend WithEvents grbAdvancePay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtADVPDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpADVPDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtADVPCode As System.Windows.Forms.TextBox
        Friend WithEvents lblADVPCode As System.Windows.Forms.Label
        Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDueDate As System.Windows.Forms.Label
        Friend WithEvents lblOrgDocDate As System.Windows.Forms.Label
        Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
        Friend WithEvents CachedCRptMatCountExpandedLciItem1 As CachedCRptMatCountExpandedLciItem
        Friend WithEvents btnAdvancePayFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents CachedCRptMatCountExpandedLciItem2 As CachedCRptMatCountExpandedLciItem
        Friend WithEvents CachedCRptMatCountExpandedLciItem3 As CachedCRptMatCountExpandedLciItem
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents lblSupplier As System.Windows.Forms.Label
        Friend WithEvents CachedCRptMatCountExpandedLciItem4 As CachedCRptMatCountExpandedLciItem
        Friend WithEvents CachedCRptMatCountExpandedLciItem5 As CachedCRptMatCountExpandedLciItem
        Friend WithEvents lblInvoiceCode As System.Windows.Forms.Label
        Friend WithEvents txtADVPInvoiceCode As System.Windows.Forms.TextBox
        Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxBase As System.Windows.Forms.Label
        Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
        Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
        Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblTaxAmount As System.Windows.Forms.Label
        Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxType As System.Windows.Forms.Label
        Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxRate As System.Windows.Forms.Label
        Friend WithEvents lblPercent As System.Windows.Forms.Label
        Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
        Friend WithEvents txtADVPNote As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
        Friend WithEvents lblADVPInvoiceDate As System.Windows.Forms.Label
        Friend WithEvents txtADVPInvoiceDate As System.Windows.Forms.TextBox
        Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
        Friend WithEvents txtInvoiceDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpADVPInvoiceDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblAVPCInvoice As System.Windows.Forms.Label
        Friend WithEvents txtInvoiceCode As System.Windows.Forms.TextBox
        Friend WithEvents chkAVPCAutoRunVat As System.Windows.Forms.CheckBox
        Friend WithEvents chkAutoRunVat As System.Windows.Forms.CheckBox

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvancePayClosedDetail))
            Me.grbAdvancePay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblADVPInvoiceDate = New System.Windows.Forms.Label()
            Me.txtADVPInvoiceDate = New System.Windows.Forms.TextBox()
            Me.dtpADVPInvoiceDate = New System.Windows.Forms.DateTimePicker()
            Me.cmbTaxType = New System.Windows.Forms.ComboBox()
            Me.lblInvoiceCode = New System.Windows.Forms.Label()
            Me.txtADVPInvoiceCode = New System.Windows.Forms.TextBox()
            Me.txtTaxBase = New System.Windows.Forms.TextBox()
            Me.lblTaxBase = New System.Windows.Forms.Label()
            Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
            Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
            Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblTaxAmount = New System.Windows.Forms.Label()
            Me.txtRemaining = New System.Windows.Forms.TextBox()
            Me.txtTaxAmount = New System.Windows.Forms.TextBox()
            Me.lblCurrencyUnit1 = New System.Windows.Forms.Label()
            Me.lblTaxType = New System.Windows.Forms.Label()
            Me.lblRemaining = New System.Windows.Forms.Label()
            Me.txtTaxRate = New System.Windows.Forms.TextBox()
            Me.lblTaxRate = New System.Windows.Forms.Label()
            Me.lblPercent = New System.Windows.Forms.Label()
            Me.txtDueDate = New System.Windows.Forms.TextBox()
            Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
            Me.lblDueDate = New System.Windows.Forms.Label()
            Me.grbLocation = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblCC = New System.Windows.Forms.Label()
            Me.lblSupplier = New System.Windows.Forms.Label()
            Me.txtCCCode = New System.Windows.Forms.TextBox()
            Me.txtSupplierCode = New System.Windows.Forms.TextBox()
            Me.txtSupplierName = New System.Windows.Forms.TextBox()
            Me.txtCCName = New System.Windows.Forms.TextBox()
            Me.txtAccountCode = New System.Windows.Forms.TextBox()
            Me.lblAccount = New System.Windows.Forms.Label()
            Me.txtAccountName = New System.Windows.Forms.TextBox()
            Me.txtAmount = New System.Windows.Forms.TextBox()
            Me.lblAmount = New System.Windows.Forms.Label()
            Me.lblCurrencyUnit2 = New System.Windows.Forms.Label()
            Me.txtADVPNote = New Longkong.Pojjaman.Gui.Components.MultiLineTextBox()
            Me.lblPCNote = New System.Windows.Forms.Label()
            Me.lblOrgDocDate = New System.Windows.Forms.Label()
            Me.txtADVPDate = New System.Windows.Forms.TextBox()
            Me.dtpADVPDate = New System.Windows.Forms.DateTimePicker()
            Me.btnAdvancePayFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtADVPCode = New System.Windows.Forms.TextBox()
            Me.lblADVPCode = New System.Windows.Forms.Label()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.grbHeader = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.chkAVPCAutoRunVat = New System.Windows.Forms.CheckBox()
            Me.lblAVPCInvoice = New System.Windows.Forms.Label()
            Me.txtInvoiceCode = New System.Windows.Forms.TextBox()
            Me.lblInvoiceDate = New System.Windows.Forms.Label()
            Me.txtInvoiceDate = New System.Windows.Forms.TextBox()
            Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
            Me.cmbCode = New System.Windows.Forms.ComboBox()
            Me.chkAutorun = New System.Windows.Forms.CheckBox()
            Me.lblDocDate = New System.Windows.Forms.Label()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.txtdocdate = New System.Windows.Forms.TextBox()
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
            Me.chkAutoRunVat = New System.Windows.Forms.CheckBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.CachedCRptMatCountExpandedLciItem1 = New CachedCRptMatCountExpandedLciItem()
            Me.CachedCRptMatCountExpandedLciItem2 = New CachedCRptMatCountExpandedLciItem()
            Me.CachedCRptMatCountExpandedLciItem3 = New CachedCRptMatCountExpandedLciItem()
            Me.CachedCRptMatCountExpandedLciItem4 = New CachedCRptMatCountExpandedLciItem()
            Me.CachedCRptMatCountExpandedLciItem5 = New CachedCRptMatCountExpandedLciItem()
            Me.grbAdvancePay.SuspendLayout()
            Me.grbLocation.SuspendLayout()
            Me.grbHeader.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbAdvancePay
            '
            Me.grbAdvancePay.Controls.Add(Me.lblADVPInvoiceDate)
            Me.grbAdvancePay.Controls.Add(Me.txtADVPInvoiceDate)
            Me.grbAdvancePay.Controls.Add(Me.dtpADVPInvoiceDate)
            Me.grbAdvancePay.Controls.Add(Me.cmbTaxType)
            Me.grbAdvancePay.Controls.Add(Me.lblInvoiceCode)
            Me.grbAdvancePay.Controls.Add(Me.txtADVPInvoiceCode)
            Me.grbAdvancePay.Controls.Add(Me.txtTaxBase)
            Me.grbAdvancePay.Controls.Add(Me.lblTaxBase)
            Me.grbAdvancePay.Controls.Add(Me.txtRealTaxAmount)
            Me.grbAdvancePay.Controls.Add(Me.ibtnResetTaxAmount)
            Me.grbAdvancePay.Controls.Add(Me.txtRealTaxBase)
            Me.grbAdvancePay.Controls.Add(Me.ibtnResetTaxBase)
            Me.grbAdvancePay.Controls.Add(Me.lblTaxAmount)
            Me.grbAdvancePay.Controls.Add(Me.txtRemaining)
            Me.grbAdvancePay.Controls.Add(Me.txtTaxAmount)
            Me.grbAdvancePay.Controls.Add(Me.lblCurrencyUnit1)
            Me.grbAdvancePay.Controls.Add(Me.lblTaxType)
            Me.grbAdvancePay.Controls.Add(Me.lblRemaining)
            Me.grbAdvancePay.Controls.Add(Me.txtTaxRate)
            Me.grbAdvancePay.Controls.Add(Me.lblTaxRate)
            Me.grbAdvancePay.Controls.Add(Me.lblPercent)
            Me.grbAdvancePay.Controls.Add(Me.txtDueDate)
            Me.grbAdvancePay.Controls.Add(Me.dtpDueDate)
            Me.grbAdvancePay.Controls.Add(Me.lblDueDate)
            Me.grbAdvancePay.Controls.Add(Me.grbLocation)
            Me.grbAdvancePay.Controls.Add(Me.txtAccountCode)
            Me.grbAdvancePay.Controls.Add(Me.lblAccount)
            Me.grbAdvancePay.Controls.Add(Me.txtAccountName)
            Me.grbAdvancePay.Controls.Add(Me.txtAmount)
            Me.grbAdvancePay.Controls.Add(Me.lblAmount)
            Me.grbAdvancePay.Controls.Add(Me.lblCurrencyUnit2)
            Me.grbAdvancePay.Controls.Add(Me.txtADVPNote)
            Me.grbAdvancePay.Controls.Add(Me.lblPCNote)
            Me.grbAdvancePay.Controls.Add(Me.lblOrgDocDate)
            Me.grbAdvancePay.Controls.Add(Me.txtADVPDate)
            Me.grbAdvancePay.Controls.Add(Me.dtpADVPDate)
            Me.grbAdvancePay.Enabled = False
            Me.grbAdvancePay.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbAdvancePay.Location = New System.Drawing.Point(8, 138)
            Me.grbAdvancePay.Name = "grbAdvancePay"
            Me.grbAdvancePay.Size = New System.Drawing.Size(624, 312)
            Me.grbAdvancePay.TabIndex = 1
            Me.grbAdvancePay.TabStop = False
            Me.grbAdvancePay.Text = "รายละเอียดวงเงินที่จะปิด"
            '
            'lblADVPInvoiceDate
            '
            Me.lblADVPInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblADVPInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.lblADVPInvoiceDate.Location = New System.Drawing.Point(280, 49)
            Me.lblADVPInvoiceDate.Name = "lblADVPInvoiceDate"
            Me.lblADVPInvoiceDate.Size = New System.Drawing.Size(88, 18)
            Me.lblADVPInvoiceDate.TabIndex = 386
            Me.lblADVPInvoiceDate.Text = "วันที่:"
            Me.lblADVPInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtADVPInvoiceDate
            '
            Me.Validator.SetDataType(Me.txtADVPInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtADVPInvoiceDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtADVPInvoiceDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtADVPInvoiceDate, 15)
            Me.Validator.SetInvalidBackColor(Me.txtADVPInvoiceDate, System.Drawing.Color.Empty)
            Me.txtADVPInvoiceDate.Location = New System.Drawing.Point(374, 49)
            Me.Validator.SetMinValue(Me.txtADVPInvoiceDate, "")
            Me.txtADVPInvoiceDate.Name = "txtADVPInvoiceDate"
            Me.Validator.SetRegularExpression(Me.txtADVPInvoiceDate, "")
            Me.Validator.SetRequired(Me.txtADVPInvoiceDate, False)
            Me.txtADVPInvoiceDate.Size = New System.Drawing.Size(111, 20)
            Me.txtADVPInvoiceDate.TabIndex = 385
            '
            'dtpADVPInvoiceDate
            '
            Me.dtpADVPInvoiceDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpADVPInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpADVPInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpADVPInvoiceDate.Location = New System.Drawing.Point(374, 49)
            Me.dtpADVPInvoiceDate.Name = "dtpADVPInvoiceDate"
            Me.dtpADVPInvoiceDate.Size = New System.Drawing.Size(138, 21)
            Me.dtpADVPInvoiceDate.TabIndex = 387
            Me.dtpADVPInvoiceDate.TabStop = False
            '
            'cmbTaxType
            '
            Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTaxType.Location = New System.Drawing.Point(115, 230)
            Me.cmbTaxType.Name = "cmbTaxType"
            Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
            Me.cmbTaxType.TabIndex = 384
            '
            'lblInvoiceCode
            '
            Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
            Me.lblInvoiceCode.Location = New System.Drawing.Point(16, 52)
            Me.lblInvoiceCode.Name = "lblInvoiceCode"
            Me.lblInvoiceCode.Size = New System.Drawing.Size(96, 18)
            Me.lblInvoiceCode.TabIndex = 332
            Me.lblInvoiceCode.Text = "เลขที่ใบกำกับภาษี:"
            Me.lblInvoiceCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtADVPInvoiceCode
            '
            Me.Validator.SetDataType(Me.txtADVPInvoiceCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtADVPInvoiceCode, "")
            Me.txtADVPInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtADVPInvoiceCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtADVPInvoiceCode, System.Drawing.Color.Empty)
            Me.txtADVPInvoiceCode.Location = New System.Drawing.Point(113, 49)
            Me.Validator.SetMinValue(Me.txtADVPInvoiceCode, "")
            Me.txtADVPInvoiceCode.Name = "txtADVPInvoiceCode"
            Me.Validator.SetRegularExpression(Me.txtADVPInvoiceCode, "")
            Me.Validator.SetRequired(Me.txtADVPInvoiceCode, False)
            Me.txtADVPInvoiceCode.Size = New System.Drawing.Size(138, 21)
            Me.txtADVPInvoiceCode.TabIndex = 329
            '
            'txtTaxBase
            '
            Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxBase, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
            Me.txtTaxBase.Location = New System.Drawing.Point(360, 230)
            Me.Validator.SetMinValue(Me.txtTaxBase, "")
            Me.txtTaxBase.Name = "txtTaxBase"
            Me.txtTaxBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
            Me.Validator.SetRequired(Me.txtTaxBase, False)
            Me.txtTaxBase.Size = New System.Drawing.Size(88, 20)
            Me.txtTaxBase.TabIndex = 381
            Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblTaxBase
            '
            Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxBase.Location = New System.Drawing.Point(296, 230)
            Me.lblTaxBase.Name = "lblTaxBase"
            Me.lblTaxBase.Size = New System.Drawing.Size(64, 18)
            Me.lblTaxBase.TabIndex = 380
            Me.lblTaxBase.Text = "Tax Base:"
            Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRealTaxAmount
            '
            Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
            Me.txtRealTaxAmount.Location = New System.Drawing.Point(472, 254)
            Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
            Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
            Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
            Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
            Me.txtRealTaxAmount.Size = New System.Drawing.Size(88, 20)
            Me.txtRealTaxAmount.TabIndex = 377
            Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'ibtnResetTaxAmount
            '
            Me.ibtnResetTaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(448, 254)
            Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
            Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
            Me.ibtnResetTaxAmount.TabIndex = 379
            Me.ibtnResetTaxAmount.TabStop = False
            Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtRealTaxBase
            '
            Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
            Me.txtRealTaxBase.Location = New System.Drawing.Point(472, 230)
            Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
            Me.txtRealTaxBase.Name = "txtRealTaxBase"
            Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
            Me.Validator.SetRequired(Me.txtRealTaxBase, False)
            Me.txtRealTaxBase.Size = New System.Drawing.Size(88, 20)
            Me.txtRealTaxBase.TabIndex = 376
            Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'ibtnResetTaxBase
            '
            Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnResetTaxBase.Location = New System.Drawing.Point(448, 230)
            Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
            Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
            Me.ibtnResetTaxBase.TabIndex = 378
            Me.ibtnResetTaxBase.TabStop = False
            Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblTaxAmount
            '
            Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxAmount.Location = New System.Drawing.Point(299, 254)
            Me.lblTaxAmount.Name = "lblTaxAmount"
            Me.lblTaxAmount.Size = New System.Drawing.Size(61, 18)
            Me.lblTaxAmount.TabIndex = 372
            Me.lblTaxAmount.Text = "VAT:"
            Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRemaining
            '
            Me.txtRemaining.AcceptsReturn = True
            Me.Validator.SetDataType(Me.txtRemaining, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRemaining, "")
            Me.txtRemaining.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRemaining, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
            Me.txtRemaining.Location = New System.Drawing.Point(112, 76)
            Me.txtRemaining.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtRemaining, "")
            Me.txtRemaining.Name = "txtRemaining"
            Me.txtRemaining.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRemaining, "")
            Me.Validator.SetRequired(Me.txtRemaining, False)
            Me.txtRemaining.Size = New System.Drawing.Size(139, 21)
            Me.txtRemaining.TabIndex = 23
            Me.txtRemaining.TabStop = False
            Me.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtTaxAmount
            '
            Me.txtTaxAmount.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
            Me.txtTaxAmount.Location = New System.Drawing.Point(360, 254)
            Me.Validator.SetMinValue(Me.txtTaxAmount, "")
            Me.txtTaxAmount.Name = "txtTaxAmount"
            Me.txtTaxAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
            Me.Validator.SetRequired(Me.txtTaxAmount, False)
            Me.txtTaxAmount.Size = New System.Drawing.Size(88, 20)
            Me.txtTaxAmount.TabIndex = 373
            Me.txtTaxAmount.TabStop = False
            Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblCurrencyUnit1
            '
            Me.lblCurrencyUnit1.AutoSize = True
            Me.lblCurrencyUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrencyUnit1.ForeColor = System.Drawing.Color.Black
            Me.lblCurrencyUnit1.Location = New System.Drawing.Point(253, 79)
            Me.lblCurrencyUnit1.Name = "lblCurrencyUnit1"
            Me.lblCurrencyUnit1.Size = New System.Drawing.Size(27, 13)
            Me.lblCurrencyUnit1.TabIndex = 29
            Me.lblCurrencyUnit1.Text = "บาท"
            Me.lblCurrencyUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTaxType
            '
            Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxType.Location = New System.Drawing.Point(10, 230)
            Me.lblTaxType.Name = "lblTaxType"
            Me.lblTaxType.Size = New System.Drawing.Size(96, 18)
            Me.lblTaxType.TabIndex = 374
            Me.lblTaxType.Text = "ประเภทภาษี:"
            Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRemaining
            '
            Me.lblRemaining.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRemaining.ForeColor = System.Drawing.Color.Black
            Me.lblRemaining.Location = New System.Drawing.Point(24, 76)
            Me.lblRemaining.Name = "lblRemaining"
            Me.lblRemaining.Size = New System.Drawing.Size(88, 18)
            Me.lblRemaining.TabIndex = 32
            Me.lblRemaining.Text = "ยอดคงเหลือ:"
            Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTaxRate
            '
            Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtTaxRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.txtTaxRate.Location = New System.Drawing.Point(243, 230)
            Me.Validator.SetMinValue(Me.txtTaxRate, "")
            Me.txtTaxRate.Name = "txtTaxRate"
            Me.txtTaxRate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
            Me.Validator.SetRequired(Me.txtTaxRate, False)
            Me.txtTaxRate.Size = New System.Drawing.Size(40, 20)
            Me.txtTaxRate.TabIndex = 370
            Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblTaxRate
            '
            Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxRate.Location = New System.Drawing.Point(181, 230)
            Me.lblTaxRate.Name = "lblTaxRate"
            Me.lblTaxRate.Size = New System.Drawing.Size(61, 18)
            Me.lblTaxRate.TabIndex = 375
            Me.lblTaxRate.Text = "อัตราภาษี :"
            Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPercent
            '
            Me.lblPercent.BackColor = System.Drawing.Color.Transparent
            Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent.Location = New System.Drawing.Point(283, 230)
            Me.lblPercent.Name = "lblPercent"
            Me.lblPercent.Size = New System.Drawing.Size(16, 18)
            Me.lblPercent.TabIndex = 371
            Me.lblPercent.Text = "%"
            Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDueDate
            '
            Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDate, "")
            Me.txtDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDueDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
            Me.txtDueDate.Location = New System.Drawing.Point(374, 23)
            Me.Validator.SetMinValue(Me.txtDueDate, "")
            Me.txtDueDate.Name = "txtDueDate"
            Me.Validator.SetRegularExpression(Me.txtDueDate, "")
            Me.Validator.SetRequired(Me.txtDueDate, False)
            Me.txtDueDate.Size = New System.Drawing.Size(111, 21)
            Me.txtDueDate.TabIndex = 217
            '
            'dtpDueDate
            '
            Me.dtpDueDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDueDate.Location = New System.Drawing.Point(374, 23)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.Size = New System.Drawing.Size(138, 21)
            Me.dtpDueDate.TabIndex = 218
            Me.dtpDueDate.TabStop = False
            '
            'lblDueDate
            '
            Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDate.ForeColor = System.Drawing.Color.Black
            Me.lblDueDate.Location = New System.Drawing.Point(264, 24)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(104, 18)
            Me.lblDueDate.TabIndex = 216
            Me.lblDueDate.Text = "วันกำหนดจ่าย:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbLocation
            '
            Me.grbLocation.Controls.Add(Me.lblCC)
            Me.grbLocation.Controls.Add(Me.lblSupplier)
            Me.grbLocation.Controls.Add(Me.txtCCCode)
            Me.grbLocation.Controls.Add(Me.txtSupplierCode)
            Me.grbLocation.Controls.Add(Me.txtSupplierName)
            Me.grbLocation.Controls.Add(Me.txtCCName)
            Me.grbLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbLocation.Location = New System.Drawing.Point(13, 103)
            Me.grbLocation.Name = "grbLocation"
            Me.grbLocation.Size = New System.Drawing.Size(552, 72)
            Me.grbLocation.TabIndex = 3
            Me.grbLocation.TabStop = False
            Me.grbLocation.Text = "สังกัด"
            '
            'lblCC
            '
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.ForeColor = System.Drawing.Color.Black
            Me.lblCC.Location = New System.Drawing.Point(9, 40)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(87, 18)
            Me.lblCC.TabIndex = 12
            Me.lblCC.Text = "Cost Center:"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSupplier
            '
            Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplier.ForeColor = System.Drawing.Color.Black
            Me.lblSupplier.Location = New System.Drawing.Point(20, 16)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(76, 18)
            Me.lblSupplier.TabIndex = 11
            Me.lblSupplier.Text = "ผู้ขาย:"
            Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCCCode
            '
            Me.Validator.SetDataType(Me.txtCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCode, "")
            Me.txtCCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
            Me.txtCCCode.Location = New System.Drawing.Point(102, 40)
            Me.txtCCCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtCCCode, "")
            Me.txtCCCode.Name = "txtCCCode"
            Me.Validator.SetRegularExpression(Me.txtCCCode, "")
            Me.Validator.SetRequired(Me.txtCCCode, False)
            Me.txtCCCode.Size = New System.Drawing.Size(130, 21)
            Me.txtCCCode.TabIndex = 1
            '
            'txtSupplierCode
            '
            Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.txtSupplierCode.Location = New System.Drawing.Point(102, 16)
            Me.txtSupplierCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
            Me.Validator.SetRequired(Me.txtSupplierCode, False)
            Me.txtSupplierCode.Size = New System.Drawing.Size(130, 21)
            Me.txtSupplierCode.TabIndex = 0
            '
            'txtSupplierName
            '
            Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierName, "")
            Me.txtSupplierName.Enabled = False
            Me.txtSupplierName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSupplierName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.txtSupplierName.Location = New System.Drawing.Point(232, 16)
            Me.txtSupplierName.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtSupplierName, "")
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.txtSupplierName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
            Me.Validator.SetRequired(Me.txtSupplierName, False)
            Me.txtSupplierName.Size = New System.Drawing.Size(314, 21)
            Me.txtSupplierName.TabIndex = 4
            Me.txtSupplierName.TabStop = False
            '
            'txtCCName
            '
            Me.Validator.SetDataType(Me.txtCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCName, "")
            Me.txtCCName.Enabled = False
            Me.txtCCName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCName, System.Drawing.Color.Empty)
            Me.txtCCName.Location = New System.Drawing.Point(232, 40)
            Me.txtCCName.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtCCName, "")
            Me.txtCCName.Name = "txtCCName"
            Me.txtCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCCName, "")
            Me.Validator.SetRequired(Me.txtCCName, False)
            Me.txtCCName.Size = New System.Drawing.Size(314, 21)
            Me.txtCCName.TabIndex = 5
            Me.txtCCName.TabStop = False
            '
            'txtAccountCode
            '
            Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode, "")
            Me.txtAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
            Me.txtAccountCode.Location = New System.Drawing.Point(115, 205)
            Me.txtAccountCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode, "")
            Me.txtAccountCode.Name = "txtAccountCode"
            Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
            Me.Validator.SetRequired(Me.txtAccountCode, False)
            Me.txtAccountCode.Size = New System.Drawing.Size(130, 21)
            Me.txtAccountCode.TabIndex = 5
            '
            'lblAccount
            '
            Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccount.ForeColor = System.Drawing.Color.Black
            Me.lblAccount.Location = New System.Drawing.Point(11, 205)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.Size = New System.Drawing.Size(95, 18)
            Me.lblAccount.TabIndex = 15
            Me.lblAccount.Text = "บัญชี:"
            Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAccountName
            '
            Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName, "")
            Me.txtAccountName.Enabled = False
            Me.txtAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.txtAccountName.Location = New System.Drawing.Point(243, 205)
            Me.txtAccountName.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtAccountName, "")
            Me.txtAccountName.Name = "txtAccountName"
            Me.txtAccountName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName, "")
            Me.Validator.SetRequired(Me.txtAccountName, False)
            Me.txtAccountName.Size = New System.Drawing.Size(317, 21)
            Me.txtAccountName.TabIndex = 16
            Me.txtAccountName.TabStop = False
            '
            'txtAmount
            '
            Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAmount, "")
            Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
            Me.txtAmount.Location = New System.Drawing.Point(115, 181)
            Me.txtAmount.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAmount, "")
            Me.txtAmount.Name = "txtAmount"
            Me.Validator.SetRegularExpression(Me.txtAmount, "")
            Me.Validator.SetRequired(Me.txtAmount, False)
            Me.txtAmount.Size = New System.Drawing.Size(130, 21)
            Me.txtAmount.TabIndex = 4
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblAmount
            '
            Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAmount.ForeColor = System.Drawing.Color.Black
            Me.lblAmount.Location = New System.Drawing.Point(24, 181)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(82, 18)
            Me.lblAmount.TabIndex = 13
            Me.lblAmount.Text = "วงเงิน:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrencyUnit2
            '
            Me.lblCurrencyUnit2.AutoSize = True
            Me.lblCurrencyUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrencyUnit2.ForeColor = System.Drawing.Color.Black
            Me.lblCurrencyUnit2.Location = New System.Drawing.Point(248, 181)
            Me.lblCurrencyUnit2.Name = "lblCurrencyUnit2"
            Me.lblCurrencyUnit2.Size = New System.Drawing.Size(27, 13)
            Me.lblCurrencyUnit2.TabIndex = 14
            Me.lblCurrencyUnit2.Text = "บาท"
            Me.lblCurrencyUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtADVPNote
            '
            Me.Validator.SetDataType(Me.txtADVPNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtADVPNote, "")
            Me.txtADVPNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtADVPNote, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtADVPNote, -15)
            Me.Validator.SetInvalidBackColor(Me.txtADVPNote, System.Drawing.Color.Empty)
            Me.txtADVPNote.Location = New System.Drawing.Point(115, 278)
            Me.txtADVPNote.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtADVPNote, "")
            Me.txtADVPNote.Name = "txtADVPNote"
            Me.Validator.SetRegularExpression(Me.txtADVPNote, "")
            Me.Validator.SetRequired(Me.txtADVPNote, False)
            Me.txtADVPNote.Size = New System.Drawing.Size(445, 21)
            Me.txtADVPNote.TabIndex = 6
            '
            'lblPCNote
            '
            Me.lblPCNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPCNote.ForeColor = System.Drawing.Color.Black
            Me.lblPCNote.Location = New System.Drawing.Point(24, 278)
            Me.lblPCNote.Name = "lblPCNote"
            Me.lblPCNote.Size = New System.Drawing.Size(82, 18)
            Me.lblPCNote.TabIndex = 19
            Me.lblPCNote.Text = "หมายเหตุ:"
            Me.lblPCNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOrgDocDate
            '
            Me.lblOrgDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblOrgDocDate.ForeColor = System.Drawing.Color.Black
            Me.lblOrgDocDate.Location = New System.Drawing.Point(24, 25)
            Me.lblOrgDocDate.Name = "lblOrgDocDate"
            Me.lblOrgDocDate.Size = New System.Drawing.Size(88, 18)
            Me.lblOrgDocDate.TabIndex = 10
            Me.lblOrgDocDate.Text = "ตั้งเมื่อวันที่:"
            Me.lblOrgDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtADVPDate
            '
            Me.Validator.SetDataType(Me.txtADVPDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtADVPDate, "")
            Me.txtADVPDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtADVPDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtADVPDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtADVPDate, System.Drawing.Color.Empty)
            Me.txtADVPDate.Location = New System.Drawing.Point(113, 24)
            Me.txtADVPDate.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtADVPDate, "")
            Me.txtADVPDate.Name = "txtADVPDate"
            Me.Validator.SetRegularExpression(Me.txtADVPDate, "")
            Me.Validator.SetRequired(Me.txtADVPDate, False)
            Me.txtADVPDate.Size = New System.Drawing.Size(111, 21)
            Me.txtADVPDate.TabIndex = 1
            '
            'dtpADVPDate
            '
            Me.dtpADVPDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpADVPDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpADVPDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpADVPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpADVPDate.Location = New System.Drawing.Point(113, 24)
            Me.dtpADVPDate.Name = "dtpADVPDate"
            Me.dtpADVPDate.Size = New System.Drawing.Size(138, 21)
            Me.dtpADVPDate.TabIndex = 11
            Me.dtpADVPDate.TabStop = False
            '
            'btnAdvancePayFind
            '
            Me.btnAdvancePayFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAdvancePayFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAdvancePayFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAdvancePayFind.Location = New System.Drawing.Point(239, 64)
            Me.btnAdvancePayFind.Name = "btnAdvancePayFind"
            Me.btnAdvancePayFind.Size = New System.Drawing.Size(24, 23)
            Me.btnAdvancePayFind.TabIndex = 214
            Me.btnAdvancePayFind.TabStop = False
            Me.btnAdvancePayFind.ThemedImage = CType(resources.GetObject("btnAdvancePayFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtADVPCode
            '
            Me.Validator.SetDataType(Me.txtADVPCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtADVPCode, "")
            Me.txtADVPCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtADVPCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtADVPCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtADVPCode, System.Drawing.Color.Empty)
            Me.txtADVPCode.Location = New System.Drawing.Point(112, 65)
            Me.txtADVPCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtADVPCode, "")
            Me.txtADVPCode.Name = "txtADVPCode"
            Me.Validator.SetRegularExpression(Me.txtADVPCode, "")
            Me.Validator.SetRequired(Me.txtADVPCode, False)
            Me.txtADVPCode.Size = New System.Drawing.Size(128, 21)
            Me.txtADVPCode.TabIndex = 24
            '
            'lblADVPCode
            '
            Me.lblADVPCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblADVPCode.ForeColor = System.Drawing.Color.Black
            Me.lblADVPCode.Location = New System.Drawing.Point(24, 66)
            Me.lblADVPCode.Name = "lblADVPCode"
            Me.lblADVPCode.Size = New System.Drawing.Size(88, 18)
            Me.lblADVPCode.TabIndex = 30
            Me.lblADVPCode.Text = "เลขที่มัดจำ:"
            Me.lblADVPCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Location = New System.Drawing.Point(8, 455)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 13)
            Me.lblStatus.TabIndex = 20
            Me.lblStatus.Text = "lblStatus"
            '
            'grbHeader
            '
            Me.grbHeader.Controls.Add(Me.chkAVPCAutoRunVat)
            Me.grbHeader.Controls.Add(Me.lblAVPCInvoice)
            Me.grbHeader.Controls.Add(Me.txtInvoiceCode)
            Me.grbHeader.Controls.Add(Me.lblInvoiceDate)
            Me.grbHeader.Controls.Add(Me.txtInvoiceDate)
            Me.grbHeader.Controls.Add(Me.dtpInvoiceDate)
            Me.grbHeader.Controls.Add(Me.btnAdvancePayFind)
            Me.grbHeader.Controls.Add(Me.cmbCode)
            Me.grbHeader.Controls.Add(Me.chkAutorun)
            Me.grbHeader.Controls.Add(Me.lblDocDate)
            Me.grbHeader.Controls.Add(Me.lblCode)
            Me.grbHeader.Controls.Add(Me.txtNote)
            Me.grbHeader.Controls.Add(Me.lblNote)
            Me.grbHeader.Controls.Add(Me.txtdocdate)
            Me.grbHeader.Controls.Add(Me.dtpDocDate)
            Me.grbHeader.Controls.Add(Me.lblADVPCode)
            Me.grbHeader.Controls.Add(Me.txtADVPCode)
            Me.grbHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbHeader.Location = New System.Drawing.Point(8, 8)
            Me.grbHeader.Name = "grbHeader"
            Me.grbHeader.Size = New System.Drawing.Size(624, 124)
            Me.grbHeader.TabIndex = 23
            Me.grbHeader.TabStop = False
            Me.grbHeader.Text = "รายละเอียดการปิด"
            '
            'chkAVPCAutoRunVat
            '
            Me.chkAVPCAutoRunVat.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAVPCAutoRunVat.Image = CType(resources.GetObject("chkAVPCAutoRunVat.Image"), System.Drawing.Image)
            Me.chkAVPCAutoRunVat.Location = New System.Drawing.Point(240, 40)
            Me.chkAVPCAutoRunVat.Name = "chkAVPCAutoRunVat"
            Me.chkAVPCAutoRunVat.Size = New System.Drawing.Size(21, 21)
            Me.chkAVPCAutoRunVat.TabIndex = 394
            '
            'lblAVPCInvoice
            '
            Me.lblAVPCInvoice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAVPCInvoice.ForeColor = System.Drawing.Color.Black
            Me.lblAVPCInvoice.Location = New System.Drawing.Point(16, 41)
            Me.lblAVPCInvoice.Name = "lblAVPCInvoice"
            Me.lblAVPCInvoice.Size = New System.Drawing.Size(96, 18)
            Me.lblAVPCInvoice.TabIndex = 393
            Me.lblAVPCInvoice.Text = "เลขที่ใบกำกับภาษี:"
            Me.lblAVPCInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtInvoiceCode
            '
            Me.Validator.SetDataType(Me.txtInvoiceCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtInvoiceCode, "")
            Me.txtInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
            Me.txtInvoiceCode.Location = New System.Drawing.Point(112, 41)
            Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
            Me.txtInvoiceCode.Name = "txtInvoiceCode"
            Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
            Me.Validator.SetRequired(Me.txtInvoiceCode, False)
            Me.txtInvoiceCode.Size = New System.Drawing.Size(129, 21)
            Me.txtInvoiceCode.TabIndex = 391
            Me.txtInvoiceCode.TabStop = False
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.lblInvoiceDate.Location = New System.Drawing.Point(280, 42)
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            Me.lblInvoiceDate.Size = New System.Drawing.Size(88, 18)
            Me.lblInvoiceDate.TabIndex = 389
            Me.lblInvoiceDate.Text = "วันที่:"
            Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtInvoiceDate
            '
            Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
            Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
            Me.txtInvoiceDate.Location = New System.Drawing.Point(374, 41)
            Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
            Me.txtInvoiceDate.Name = "txtInvoiceDate"
            Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
            Me.Validator.SetRequired(Me.txtInvoiceDate, False)
            Me.txtInvoiceDate.Size = New System.Drawing.Size(111, 20)
            Me.txtInvoiceDate.TabIndex = 388
            '
            'dtpInvoiceDate
            '
            Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(374, 41)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(138, 21)
            Me.dtpInvoiceDate.TabIndex = 390
            Me.dtpInvoiceDate.TabStop = False
            '
            'cmbCode
            '
            Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
            Me.cmbCode.Location = New System.Drawing.Point(112, 15)
            Me.cmbCode.Name = "cmbCode"
            Me.cmbCode.Size = New System.Drawing.Size(128, 21)
            Me.cmbCode.TabIndex = 213
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(240, 14)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 37
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.ForeColor = System.Drawing.Color.Black
            Me.lblDocDate.Location = New System.Drawing.Point(264, 17)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(104, 18)
            Me.lblDocDate.TabIndex = 33
            Me.lblDocDate.Text = "วันที่เอกสาร:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(24, 14)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(88, 18)
            Me.lblCode.TabIndex = 31
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(112, 90)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(397, 21)
            Me.txtNote.TabIndex = 28
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(48, 90)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(64, 18)
            Me.lblNote.TabIndex = 36
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtdocdate
            '
            Me.Validator.SetDataType(Me.txtdocdate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtdocdate, "")
            Me.txtdocdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtdocdate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtdocdate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtdocdate, System.Drawing.Color.Empty)
            Me.txtdocdate.Location = New System.Drawing.Point(374, 15)
            Me.txtdocdate.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtdocdate, "")
            Me.txtdocdate.Name = "txtdocdate"
            Me.Validator.SetRegularExpression(Me.txtdocdate, "")
            Me.Validator.SetRequired(Me.txtdocdate, False)
            Me.txtdocdate.Size = New System.Drawing.Size(111, 21)
            Me.txtdocdate.TabIndex = 26
            '
            'dtpDocDate
            '
            Me.dtpDocDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDocDate.Location = New System.Drawing.Point(374, 15)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(138, 21)
            Me.dtpDocDate.TabIndex = 34
            Me.dtpDocDate.TabStop = False
            '
            'chkAutoRunVat
            '
            Me.chkAutoRunVat.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutoRunVat.Location = New System.Drawing.Point(231, 40)
            Me.chkAutoRunVat.Name = "chkAutoRunVat"
            Me.chkAutoRunVat.Size = New System.Drawing.Size(21, 21)
            Me.chkAutoRunVat.TabIndex = 10
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            'AdvancePayClosedDetail
            '
            Me.Controls.Add(Me.grbHeader)
            Me.Controls.Add(Me.grbAdvancePay)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.chkAutoRunVat)
            Me.Name = "AdvancePayClosedDetail"
            Me.Size = New System.Drawing.Size(641, 479)
            Me.grbAdvancePay.ResumeLayout(False)
            Me.grbAdvancePay.PerformLayout()
            Me.grbLocation.ResumeLayout(False)
            Me.grbLocation.PerformLayout()
            Me.grbHeader.ResumeLayout(False)
            Me.grbHeader.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()

        End Sub
#End Region

#Region "Members"
        Private m_entity As AdvancePayClosed
        Private m_isInitialized As Boolean = False
        Private m_vat As Vat
#End Region

#Region "Constructs"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Initialize()
            EventWiring()
        End Sub
#End Region

#Region "Methods"
        Private Function ConvertItemsToValueArray(ByVal list As String) As String
            Dim result As String = ""
            If list Is Nothing OrElse list.Length = 0 Then
                Return Nothing
            Else
                For Each item As String In list.Split(","c)
                    result &= CStr(CInt(item) + 1) & ","
                Next
                If result.Length <> 0 Then
                    result = result.TrimEnd(","c)
                End If
                Return result
            End If
        End Function
        Public Sub SetAdvancePayData()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.AdvancePay Is Nothing OrElse Not Me.m_entity.AdvancePay.Originated Then
                ClearAdvancePay()
                Me.m_entity.Amount = Nothing
            Else
                txtADVPDate.Text = MinDateToNull(Me.m_entity.AdvancePay.DocDate, "")
                dtpADVPDate.Value = MinDateToNow(Me.m_entity.AdvancePay.DocDate)

                txtDueDate.Text = MinDateToNull(Me.m_entity.AdvancePay.DueDate, "")
                dtpDueDate.Value = MinDateToNow(Me.m_entity.AdvancePay.DueDate)

                txtSupplierCode.Text = Me.m_entity.AdvancePay.Supplier.Code
                txtSupplierName.Text = Me.m_entity.AdvancePay.Supplier.Name

                txtSupplierCode.Enabled = False
                txtSupplierName.Enabled = False

                txtCCCode.Text = Me.m_entity.AdvancePay.CostCenter.Code
                txtCCName.Text = Me.m_entity.AdvancePay.CostCenter.Name

                txtCCCode.Enabled = False
                txtCCName.Enabled = False


                txtTaxRate.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.TaxRate, DigitConfig.Price)
                txtTaxBase.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.TaxBase, DigitConfig.Price)
                txtTaxAmount.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.TaxAmount, DigitConfig.Price)
                txtRealTaxAmount.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.RealTaxAmount, DigitConfig.Price)
                txtRealTaxBase.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.RealTaxBase, DigitConfig.Price)
                txtAmount.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.AfterTax, DigitConfig.Price)
                txtAccountCode.Text = Me.m_entity.AdvancePay.ToAccount.Code
                txtAccountName.Text = Me.m_entity.AdvancePay.ToAccount.Name
                txtADVPNote.Text = Me.m_entity.AdvancePay.Note

                ' วงเงินคงเหลือ
                Me.m_entity.SetremainAVP()

                txtRemaining.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.ADVPRemainingAmount, DigitConfig.Price)

                SetVatToOneDoc()
            End If
        End Sub
        Private Sub ClearAdvancePay()
            For Each grbCrtl As Control In grbAdvancePay.Controls
                If TypeOf grbCrtl Is TextBox Then
                    grbCrtl.Text = ""
                End If
            Next
            For Each grbCrtl As Control In grbLocation.Controls
                If TypeOf grbCrtl Is TextBox Then
                    grbCrtl.Text = ""
                End If
            Next
            dtpADVPDate.Value = Date.Now
            dtpDueDate.Value = Date.Now
            ' วงเงินคงเหลือ
            txtRemaining.Text = Configuration.FormatToString(0, DigitConfig.Price)
        End Sub

#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Status.Value = 0 _
            OrElse Me.m_entity.Status.Value >= 3 _
            Then
                Me.Enabled = False
            Else
                Me.Enabled = True
            End If
        End Sub
        Public Overrides Sub Initialize()
            SetTaxTypeComboBox()
        End Sub
        Private Sub SetTaxTypeComboBox()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType", "code_Value <> 1")
            cmbTaxType.SelectedIndex = 1
        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
            AddHandler txtdocdate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtADVPCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtInvoiceCode.TextChanged, AddressOf Me.TextHandler
            AddHandler txtInvoiceCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtInvoiceDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpInvoiceDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler
            AddHandler txtSupplierName.Validated, AddressOf ChangeProperty

        End Sub
        Private supplierCodeChanged As Boolean = False

        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtsuppliercode"
                    supplierCodeChanged = True
                Case "txtinvoicecode"
                    m_invoicecodechange = True
            End Select
        End Sub
        Private m_dateSetting As Boolean = False
        Private m_invoicecodechange As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "cmbcode"
                    'เพิ่ม AutoCode
                    If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
                        Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
                        Me.m_entity.Code = m_entity.AutoCodeFormat.Format
                        Me.m_entity.OnGlChanged()
                    End If
                    dirtyFlag = True
                Case "dtpdocdate"
                    If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtdocdate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.DocDate = dtpDocDate.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdate"
                    m_dateSetting = True
                    If Not Me.txtdocdate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtdocdate) = "" Then
                        Dim theDate As Date = CDate(Me.txtdocdate.Text)
                        If Not Me.m_entity.DocDate.Equals(theDate) Then
                            dtpDocDate.Value = theDate
                            Me.m_entity.DocDate = dtpDocDate.Value
                            dirtyFlag = True
                        End If
                    Else
                        dtpDocDate.Value = Date.Now
                        Me.m_entity.DocDate = Date.MinValue
                        Me.m_entity.DocDate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False

                Case "txtadvpcode"
                    Dim OldAdvancePay As AdvancePay = Me.m_entity.AdvancePay

                    dirtyFlag = AdvancePay.GetAdvancePay(txtADVPCode, Me.m_entity.AdvancePay)
                    If dirtyFlag AndAlso (OldAdvancePay.Id <> Me.m_entity.AdvancePay.Id AndAlso Me.m_entity.AdvancePay.Closed) Then
                        Dim myMsgService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                        myMsgService.ShowWarningFormatted("${res:Global.Error.AdvancePayIsClosed}", Me.m_entity.AdvancePay.Code)
                        Me.m_entity.AdvancePay = OldAdvancePay
                        txtADVPCode.Text = OldAdvancePay.Code
                        'txtADVPName.Text = OldAdvancePay.Name
                    End If
                    SetAdvancePayData()

                Case "txtnote"
                    dirtyFlag = True
                    Me.m_entity.Note = txtNote.Text
                Case "txtsuppliercode"
                    If supplierCodeChanged Then
                        supplierCodeChanged = False
                        dirtyFlag = Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
                        If dirtyFlag Then
                            For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
                                vitem.PrintName = Me.m_entity.Supplier.Name
                                vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
                            Next
                        End If
                    End If
                Case "txtsuppliername"
                    Dim txt As String = txtSupplierName.Text
                    Dim reg As New Regex("\[(.*)\]")
                    If reg.IsMatch(txt) Then
                        Dim sup As Supplier
                        Try
                            sup = New Supplier(reg.Match(txt).Groups(1).Value)
                            dirtyFlag = True
                        Catch ex As Exception
                            sup = New Supplier
                        End Try
                        Me.m_entity.Supplier = sup
                        If dirtyFlag Then
                            For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
                                vitem.PrintName = Me.m_entity.Supplier.Name
                                vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
                            Next
                        End If
                    End If
                    m_isInitialized = False
                    Me.txtSupplierCode.Text = Me.m_entity.Supplier.Code
                    Me.txtSupplierName.Text = Me.m_entity.Supplier.Name
                    m_isInitialized = True

                Case "txtinvoicecode"
                    If m_invoicecodechange AndAlso m_oldInvoiceCode <> Me.txtInvoiceCode.Text Then
                        Me.m_entity.Vat.CodeChanged(Me.txtInvoiceCode.Text)
                        Me.m_entity.SetNoVat()
                        Me.m_entity.GenVatAmount(True)
                        m_oldInvoiceCode = Me.txtInvoiceCode.Text
                        dirtyFlag = True
                        m_invoicecodechange = False
                    End If
                Case "txtinvoicedate"
                    m_dateSetting = True
                    dirtyFlag = Me.m_entity.Vat.DateTextChanged(txtInvoiceDate, dtpInvoiceDate, Me.Validator)
                    m_dateSetting = False
                Case "dtpinvoicedate"
                    dirtyFlag = Me.m_entity.Vat.DatePickerChanged(dtpInvoiceDate, txtInvoiceDate, m_dateSetting)
            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Private m_oldInvoiceCode As String = ""
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            cmbCode.Text = m_entity.Code
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtdocdate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

            txtNote.Text = Me.m_entity.Note

            ' vatcode ของ ปิดมัดจำจ่าย
            Dim myVat As Vat = Me.m_entity.Vat
            If Not myVat Is Nothing Then
                Dim myVatitem As VatItem
                If myVat.ItemCollection.Count <= 0 Then
                    Me.m_entity.Vat.ItemCollection.Add(New VatItem)
                End If
                VatInputEnabled(True)
                myVatitem = myVat.ItemCollection(0)
                myVat.AutoGen = False
                If myVat.AutoGen Then
                    Me.txtInvoiceCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(myVatitem.EntityId)
                Else
                    Me.txtInvoiceCode.Text = myVatitem.Code
                End If
                Me.txtInvoiceDate.Text = MinDateToNull(myVatitem.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                Me.dtpInvoiceDate.Value = MinDateToNow(myVatitem.DocDate)
            End If
            '-----------------------------
            ' vatcode ของมัดจำจ่าย 
            Me.m_entity.Vat.Direction.Value = 1
            Dim ds As DataSet = Me.m_entity.GetVatForADVPC(Me.m_entity.AdvancePay)
            If ds.Tables(0).Rows.Count <= 0 Then
                VatInputEnabled(True)
                Me.txtADVPInvoiceCode.Text = ""
                Me.txtADVPInvoiceDate.Text = ""
                Me.dtpADVPInvoiceDate.Value = Now
            ElseIf ds.Tables(0).Rows.Count = 1 Then
                For Each row As DataRow In ds.Tables(0).Rows
                    VatInputEnabled(True)
                    If Not row.IsNull("vati_code") Then
                        Me.txtADVPInvoiceCode.Text = row("vati_code").ToString
                        txtADVPInvoiceCode.Enabled = False
                    End If
                    If Not row.IsNull("vati_docdate") And IsDate(row("vati_docdate")) Then
                        If Not row("vati_docdate").Equals(Date.MinValue) Then
                            Me.txtADVPInvoiceDate.Text = CDate(row("vati_docdate")).ToShortDateString
                            Me.dtpADVPInvoiceDate.Value = CDate(row("vati_docdate"))
                            txtADVPInvoiceDate.Enabled = False
                            dtpADVPInvoiceDate.Enabled = False
                        End If
                    End If
                Next
            Else
                VatInputEnabled(False)
                Me.txtADVPInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
                Me.txtADVPInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
                Me.dtpADVPInvoiceDate.Value = Now
            End If

            m_oldInvoiceCode = Me.txtInvoiceCode.Text
            Me.chkAVPCAutoRunVat.Checked = Me.m_entity.Vat.AutoGen
            Me.UpdateVatAutogenStatus()

            For Each item As IdValuePair In Me.cmbTaxType.Items
                If Me.m_entity.TaxType.Value = item.Id Then
                    Me.cmbTaxType.SelectedItem = item
                End If
            Next

            If Me.m_entity.AdvancePay Is Nothing Then
                txtADVPCode.Text = ""
                txtRemaining.Text = Configuration.FormatToString(0, DigitConfig.Price)
            Else
                txtADVPCode.Text = Me.m_entity.AdvancePay.Code
                txtRemaining.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.GetRemainingAmount, DigitConfig.Price)
            End If

            SetAdvancePayData()
            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub

        Public Overrides Sub ClearDetail()
            For Each crlt As Control In grbHeader.Controls
                If TypeOf crlt Is TextBox Then
                    crlt.Text = ""
                End If
            Next

            SetAdvancePayData()

            dtpDocDate.Value = Date.Now
            txtdocdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, AdvancePayClosed)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

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
                lblStatus.Text = "ยังไม่ได้บันทึก"
            End If
        End Sub
        Private Sub VatInputEnabled(ByVal enable As Boolean)
            Me.txtInvoiceCode.Enabled = enable
            Me.txtInvoiceDate.Enabled = enable
            Me.dtpInvoiceDate.Enabled = enable
            If enable Then
                Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.DateTimeType)
                Me.Validator.SetRequired(Me.txtInvoiceCode, False)
                If Me.m_isInitialized Then
                    SetVatToOneDoc()
                End If
            Else
                Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.StringType)
                Me.Validator.SetRequired(Me.txtInvoiceCode, False)
            End If
        End Sub
        Private Sub SetVatToNoDoc()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            Me.m_entity.AdvancePay.Vat.ItemCollection.Clear()
            Me.txtInvoiceCode.Text = ""
            Me.txtInvoiceDate.Text = ""
            Me.dtpInvoiceDate.Value = Now
            Me.m_isInitialized = flag
        End Sub
        Private Sub SetVatToOneDoc()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            If txtInvoiceCode.Text.Length > 0 Then
                Me.m_entity.Vat.SetVatToOneDoc(txtInvoiceCode _
              , txtInvoiceDate _
              , dtpInvoiceDate _
              , AddressOf UpdateVatAutogenStatus)
            Else
                txtInvoiceDate.Text = txtdocdate.Text
                dtpInvoiceDate.Value = dtpDocDate.Value
            End If
            m_entity.GenVatAmount()
            Me.m_isInitialized = flag
        End Sub
        Private Sub chkAutoRunVat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAVPCAutoRunVat.CheckedChanged
            UpdateVatAutogenStatus()
        End Sub
        Private Sub UpdateVatAutogenStatus()
            If Me.m_entity.Vat Is Nothing Then
                Return
            End If
            Dim vi As New VatItem
            If Me.m_entity.Vat.ItemCollection.Count <= 0 Then
                Me.m_entity.Vat.ItemCollection.Add(New VatItem)
            End If

            vi = Me.m_entity.Vat.ItemCollection(0)
            If Me.chkAVPCAutoRunVat.Checked Then
                Me.Validator.SetRequired(Me.txtInvoiceCode, False)
                Me.ErrorProvider1.SetError(Me.txtInvoiceCode, "")
                Me.txtInvoiceCode.ReadOnly = True
                m_oldInvoiceCode = Me.txtInvoiceCode.Text
                Me.txtInvoiceCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(vi.EntityId)
                'Me.txtInvoiceCode.Text = m_oldInvoiceCode
                'Hack: set Code เป็น "" เอง
                vi.Code = ""
                Me.m_entity.Vat.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtInvoiceCode, False)
                Me.txtInvoiceCode.Text = m_oldInvoiceCode
                Me.txtInvoiceCode.ReadOnly = False
                Me.m_entity.Vat.AutoGen = False
            End If
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
                Return (New AdvancePayClosed).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_oldCode As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
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
                Me.m_entity.Code = m_oldCode
                Me.m_entity.AutoGen = True
            Else
                Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
                Me.cmbCode.Text = m_oldCode
                Me.m_entity.AutoGen = False
            End If
        End Sub
#End Region

#Region "Event of Button controls"
        ' Employee
        Private Sub btnAdvancePayEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New AdvancePay)
        End Sub
        Private Sub btnAdvancePayFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvancePayFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entity As New ArrayList
            Dim advp As New AdvancePay
            advp.Closed = False
            entity.Add(advp)
            myEntityPanelService.OpenListDialog(New AdvancePayForClosed, AddressOf SetAdvancePayDialog, entity)
        End Sub
        Private Sub SetAdvancePayDialog(ByVal e As ISimpleEntity)
            Me.txtADVPCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or AdvancePay.GetAdvancePay(txtADVPCode, Me.m_entity.AdvancePay)
            SetAdvancePayData()
            UpdateEntityProperties()
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New AdvancePayClosed).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtadvpcode"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New AdvancePayClosed).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New AdvancePayClosed).FullClassName))
                Dim entity As New AdvancePayClosed(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtadvpcode"
                            Me.SetAdvancePayDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region
        Private Sub txtInvoiceCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
    End Class

End Namespace