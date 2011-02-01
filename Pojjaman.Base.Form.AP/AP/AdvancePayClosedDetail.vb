Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

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
        Friend WithEvents txtADVPNote As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvancePayClosedDetail))
            Me.grbAdvancePay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
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
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.grbHeader = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.btnAdvancePayFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.cmbCode = New System.Windows.Forms.ComboBox()
            Me.chkAutorun = New System.Windows.Forms.CheckBox()
            Me.lblDocDate = New System.Windows.Forms.Label()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.txtRemaining = New System.Windows.Forms.TextBox()
            Me.lblCurrencyUnit1 = New System.Windows.Forms.Label()
            Me.lblRemaining = New System.Windows.Forms.Label()
            Me.txtADVPCode = New System.Windows.Forms.TextBox()
            Me.lblADVPCode = New System.Windows.Forms.Label()
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.txtdocdate = New System.Windows.Forms.TextBox()
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
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
            Me.grbAdvancePay.Location = New System.Drawing.Point(8, 128)
            Me.grbAdvancePay.Name = "grbAdvancePay"
            Me.grbAdvancePay.Size = New System.Drawing.Size(592, 208)
            Me.grbAdvancePay.TabIndex = 1
            Me.grbAdvancePay.TabStop = False
            Me.grbAdvancePay.Text = "รายละเอียดวงเงินที่จะปิด"
            '
            'txtDueDate
            '
            Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDate, "")
            Me.txtDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDueDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
            Me.txtDueDate.Location = New System.Drawing.Point(368, 24)
            Me.Validator.SetMinValue(Me.txtDueDate, "")
            Me.txtDueDate.Name = "txtDueDate"
            Me.Validator.SetRegularExpression(Me.txtDueDate, "")
            Me.Validator.SetRequired(Me.txtDueDate, False)
            Me.txtDueDate.Size = New System.Drawing.Size(101, 21)
            Me.txtDueDate.TabIndex = 217
            '
            'dtpDueDate
            '
            Me.dtpDueDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDueDate.Location = New System.Drawing.Point(368, 24)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.Size = New System.Drawing.Size(128, 21)
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
            Me.grbLocation.Location = New System.Drawing.Point(16, 48)
            Me.grbLocation.Name = "grbLocation"
            Me.grbLocation.Size = New System.Drawing.Size(536, 72)
            Me.grbLocation.TabIndex = 3
            Me.grbLocation.TabStop = False
            Me.grbLocation.Text = "สังกัด"
            '
            'lblCC
            '
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.ForeColor = System.Drawing.Color.Black
            Me.lblCC.Location = New System.Drawing.Point(11, 43)
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
            Me.lblSupplier.Location = New System.Drawing.Point(22, 16)
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
            Me.txtCCCode.Location = New System.Drawing.Point(104, 40)
            Me.txtCCCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtCCCode, "")
            Me.txtCCCode.Name = "txtCCCode"
            Me.Validator.SetRegularExpression(Me.txtCCCode, "")
            Me.Validator.SetRequired(Me.txtCCCode, False)
            Me.txtCCCode.Size = New System.Drawing.Size(128, 21)
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
            Me.txtSupplierCode.Location = New System.Drawing.Point(104, 16)
            Me.txtSupplierCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
            Me.Validator.SetRequired(Me.txtSupplierCode, False)
            Me.txtSupplierCode.Size = New System.Drawing.Size(128, 21)
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
            Me.txtSupplierName.Size = New System.Drawing.Size(296, 21)
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
            Me.txtCCName.Size = New System.Drawing.Size(296, 21)
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
            Me.txtAccountCode.Location = New System.Drawing.Point(120, 152)
            Me.txtAccountCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode, "")
            Me.txtAccountCode.Name = "txtAccountCode"
            Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
            Me.Validator.SetRequired(Me.txtAccountCode, False)
            Me.txtAccountCode.Size = New System.Drawing.Size(128, 21)
            Me.txtAccountCode.TabIndex = 5
            '
            'lblAccount
            '
            Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccount.ForeColor = System.Drawing.Color.Black
            Me.lblAccount.Location = New System.Drawing.Point(8, 152)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.Size = New System.Drawing.Size(104, 18)
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
            Me.txtAccountName.Location = New System.Drawing.Point(248, 152)
            Me.txtAccountName.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtAccountName, "")
            Me.txtAccountName.Name = "txtAccountName"
            Me.txtAccountName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName, "")
            Me.Validator.SetRequired(Me.txtAccountName, False)
            Me.txtAccountName.Size = New System.Drawing.Size(296, 21)
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
            Me.txtAmount.Location = New System.Drawing.Point(120, 128)
            Me.txtAmount.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAmount, "")
            Me.txtAmount.Name = "txtAmount"
            Me.Validator.SetRegularExpression(Me.txtAmount, "")
            Me.Validator.SetRequired(Me.txtAmount, False)
            Me.txtAmount.Size = New System.Drawing.Size(128, 21)
            Me.txtAmount.TabIndex = 4
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblAmount
            '
            Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAmount.ForeColor = System.Drawing.Color.Black
            Me.lblAmount.Location = New System.Drawing.Point(8, 128)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(104, 18)
            Me.lblAmount.TabIndex = 13
            Me.lblAmount.Text = "วงเงิน:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrencyUnit2
            '
            Me.lblCurrencyUnit2.AutoSize = True
            Me.lblCurrencyUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrencyUnit2.ForeColor = System.Drawing.Color.Black
            Me.lblCurrencyUnit2.Location = New System.Drawing.Point(256, 128)
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
            Me.txtADVPNote.Location = New System.Drawing.Point(120, 176)
            Me.txtADVPNote.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtADVPNote, "")
            Me.txtADVPNote.Name = "txtADVPNote"
            Me.Validator.SetRegularExpression(Me.txtADVPNote, "")
            Me.Validator.SetRequired(Me.txtADVPNote, False)
            Me.txtADVPNote.Size = New System.Drawing.Size(424, 21)
            Me.txtADVPNote.TabIndex = 6
            '
            'lblPCNote
            '
            Me.lblPCNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPCNote.ForeColor = System.Drawing.Color.Black
            Me.lblPCNote.Location = New System.Drawing.Point(8, 176)
            Me.lblPCNote.Name = "lblPCNote"
            Me.lblPCNote.Size = New System.Drawing.Size(104, 18)
            Me.lblPCNote.TabIndex = 19
            Me.lblPCNote.Text = "หมายเหตุ:"
            Me.lblPCNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOrgDocDate
            '
            Me.lblOrgDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblOrgDocDate.ForeColor = System.Drawing.Color.Black
            Me.lblOrgDocDate.Location = New System.Drawing.Point(16, 24)
            Me.lblOrgDocDate.Name = "lblOrgDocDate"
            Me.lblOrgDocDate.Size = New System.Drawing.Size(104, 18)
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
            Me.txtADVPDate.Location = New System.Drawing.Point(128, 24)
            Me.txtADVPDate.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtADVPDate, "")
            Me.txtADVPDate.Name = "txtADVPDate"
            Me.Validator.SetRegularExpression(Me.txtADVPDate, "")
            Me.Validator.SetRequired(Me.txtADVPDate, False)
            Me.txtADVPDate.Size = New System.Drawing.Size(101, 21)
            Me.txtADVPDate.TabIndex = 1
            '
            'dtpADVPDate
            '
            Me.dtpADVPDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpADVPDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpADVPDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpADVPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpADVPDate.Location = New System.Drawing.Point(128, 24)
            Me.dtpADVPDate.Name = "dtpADVPDate"
            Me.dtpADVPDate.Size = New System.Drawing.Size(128, 21)
            Me.dtpADVPDate.TabIndex = 11
            Me.dtpADVPDate.TabStop = False
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Location = New System.Drawing.Point(8, 344)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 13)
            Me.lblStatus.TabIndex = 20
            Me.lblStatus.Text = "lblStatus"
            '
            'grbHeader
            '
            Me.grbHeader.Controls.Add(Me.btnAdvancePayFind)
            Me.grbHeader.Controls.Add(Me.cmbCode)
            Me.grbHeader.Controls.Add(Me.chkAutorun)
            Me.grbHeader.Controls.Add(Me.lblDocDate)
            Me.grbHeader.Controls.Add(Me.lblCode)
            Me.grbHeader.Controls.Add(Me.txtRemaining)
            Me.grbHeader.Controls.Add(Me.lblCurrencyUnit1)
            Me.grbHeader.Controls.Add(Me.lblRemaining)
            Me.grbHeader.Controls.Add(Me.txtADVPCode)
            Me.grbHeader.Controls.Add(Me.lblADVPCode)
            Me.grbHeader.Controls.Add(Me.txtNote)
            Me.grbHeader.Controls.Add(Me.lblNote)
            Me.grbHeader.Controls.Add(Me.txtdocdate)
            Me.grbHeader.Controls.Add(Me.dtpDocDate)
            Me.grbHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbHeader.Location = New System.Drawing.Point(8, 8)
            Me.grbHeader.Name = "grbHeader"
            Me.grbHeader.Size = New System.Drawing.Size(592, 120)
            Me.grbHeader.TabIndex = 23
            Me.grbHeader.TabStop = False
            Me.grbHeader.Text = "รายละเอียดการปิด"
            '
            'btnAdvancePayFind
            '
            Me.btnAdvancePayFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAdvancePayFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAdvancePayFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAdvancePayFind.Location = New System.Drawing.Point(240, 37)
            Me.btnAdvancePayFind.Name = "btnAdvancePayFind"
            Me.btnAdvancePayFind.Size = New System.Drawing.Size(24, 23)
            Me.btnAdvancePayFind.TabIndex = 214
            Me.btnAdvancePayFind.TabStop = False
            Me.btnAdvancePayFind.ThemedImage = CType(resources.GetObject("btnAdvancePayFind.ThemedImage"), System.Drawing.Bitmap)
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
            Me.lblDocDate.Location = New System.Drawing.Point(264, 15)
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
            'txtRemaining
            '
            Me.txtRemaining.AcceptsReturn = True
            Me.Validator.SetDataType(Me.txtRemaining, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRemaining, "")
            Me.txtRemaining.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRemaining, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
            Me.txtRemaining.Location = New System.Drawing.Point(112, 62)
            Me.txtRemaining.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtRemaining, "")
            Me.txtRemaining.Name = "txtRemaining"
            Me.txtRemaining.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRemaining, "")
            Me.Validator.SetRequired(Me.txtRemaining, False)
            Me.txtRemaining.Size = New System.Drawing.Size(128, 21)
            Me.txtRemaining.TabIndex = 23
            Me.txtRemaining.TabStop = False
            Me.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblCurrencyUnit1
            '
            Me.lblCurrencyUnit1.AutoSize = True
            Me.lblCurrencyUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrencyUnit1.ForeColor = System.Drawing.Color.Black
            Me.lblCurrencyUnit1.Location = New System.Drawing.Point(248, 62)
            Me.lblCurrencyUnit1.Name = "lblCurrencyUnit1"
            Me.lblCurrencyUnit1.Size = New System.Drawing.Size(27, 13)
            Me.lblCurrencyUnit1.TabIndex = 29
            Me.lblCurrencyUnit1.Text = "บาท"
            Me.lblCurrencyUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRemaining
            '
            Me.lblRemaining.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRemaining.ForeColor = System.Drawing.Color.Black
            Me.lblRemaining.Location = New System.Drawing.Point(24, 62)
            Me.lblRemaining.Name = "lblRemaining"
            Me.lblRemaining.Size = New System.Drawing.Size(88, 18)
            Me.lblRemaining.TabIndex = 32
            Me.lblRemaining.Text = "ยอดคงเหลือ:"
            Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtADVPCode
            '
            Me.Validator.SetDataType(Me.txtADVPCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtADVPCode, "")
            Me.txtADVPCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtADVPCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtADVPCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtADVPCode, System.Drawing.Color.Empty)
            Me.txtADVPCode.Location = New System.Drawing.Point(112, 38)
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
            Me.lblADVPCode.Location = New System.Drawing.Point(24, 38)
            Me.lblADVPCode.Name = "lblADVPCode"
            Me.lblADVPCode.Size = New System.Drawing.Size(88, 18)
            Me.lblADVPCode.TabIndex = 30
            Me.lblADVPCode.Text = "เลขที่มัดจำ:"
            Me.lblADVPCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(112, 86)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(432, 21)
            Me.txtNote.TabIndex = 28
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(48, 86)
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
            Me.txtdocdate.Location = New System.Drawing.Point(368, 14)
            Me.txtdocdate.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtdocdate, "")
            Me.txtdocdate.Name = "txtdocdate"
            Me.Validator.SetRegularExpression(Me.txtdocdate, "")
            Me.Validator.SetRequired(Me.txtdocdate, False)
            Me.txtdocdate.Size = New System.Drawing.Size(101, 21)
            Me.txtdocdate.TabIndex = 26
            '
            'dtpDocDate
            '
            Me.dtpDocDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDocDate.Location = New System.Drawing.Point(368, 14)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(128, 21)
            Me.dtpDocDate.TabIndex = 34
            Me.dtpDocDate.TabStop = False
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
            Me.Name = "AdvancePayClosedDetail"
            Me.Size = New System.Drawing.Size(608, 368)
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

                txtSupplierCode.Enabled = True
                txtSupplierName.Enabled = True

                txtCCCode.Text = Me.m_entity.AdvancePay.CostCenter.Code
                txtCCName.Text = Me.m_entity.AdvancePay.CostCenter.Name

                txtCCCode.Enabled = True
                txtCCName.Enabled = True

                txtAmount.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.AfterTax, DigitConfig.Price)
                txtAccountCode.Text = Me.m_entity.AdvancePay.ToAccount.Code
                txtAccountName.Text = Me.m_entity.AdvancePay.ToAccount.Name
                txtADVPNote.Text = Me.m_entity.AdvancePay.Note

                ' วงเงินคงเหลือ
                Dim remainamt As Decimal = Me.m_entity.AdvancePay.GetRemainingAmount(True)
                Me.m_entity.AdvancePay.ADVPRemainingAmount = remainamt
                Me.m_entity.Amount = Me.m_entity.AdvancePay.AfterTax
                Me.m_entity.RemainAmount = remainamt
                txtRemaining.Text = Configuration.FormatToString(Me.m_entity.AdvancePay.ADVPRemainingAmount, DigitConfig.Price)
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

        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

            AddHandler txtdocdate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtADVPCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
        End Sub
        Private m_dateSetting As Boolean = False
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
                        Me.m_entity.DocDate = Date.Now
                        Me.m_entity.DocDate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False

                Case "txtadvmcode"
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
            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtdocdate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
            txtNote.Text = Me.m_entity.Note

            If Me.m_entity.AdvancePay Is Nothing Then
                txtADVPCode.Text = ""
                'txtADVPName.Text = ""
                txtRemaining.Text = Configuration.FormatToString(0, DigitConfig.Price)
            Else
                txtADVPCode.Text = Me.m_entity.AdvancePay.Code
                'txtADVPName.Text = Me.m_entity.AdvancePay.Name
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
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New AdvancePay).FullClassName) Then
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
            If data.GetDataPresent((New AdvancePay).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New AdvancePay).FullClassName))
                Dim entity As New AdvancePay(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtadvpcode"
                            Me.SetAdvancePayDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

    End Class

End Namespace