Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class AdvanceMoneyClosedDetail
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
    Friend WithEvents rdIsEmployee As System.Windows.Forms.RadioButton
    Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents rdIsCC As System.Windows.Forms.RadioButton
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
    Friend WithEvents grbAdvanceMoney As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtADVMDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpADVMDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtADVMCode As System.Windows.Forms.TextBox
    Friend WithEvents lblADVMCode As System.Windows.Forms.Label
    Friend WithEvents txtADVMName As System.Windows.Forms.TextBox
    Friend WithEvents btnAdvanceMoneyFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents lblOrgDocDate As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtADVMNote As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvanceMoneyClosedDetail))
      Me.grbAdvanceMoney = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDueDate = New System.Windows.Forms.TextBox()
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDueDate = New System.Windows.Forms.Label()
      Me.grbLocation = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtCCCode = New System.Windows.Forms.TextBox()
      Me.rdIsEmployee = New System.Windows.Forms.RadioButton()
      Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
      Me.txtEmployeeName = New System.Windows.Forms.TextBox()
      Me.rdIsCC = New System.Windows.Forms.RadioButton()
      Me.txtCCName = New System.Windows.Forms.TextBox()
      Me.txtAccountCode = New System.Windows.Forms.TextBox()
      Me.lblAccount = New System.Windows.Forms.Label()
      Me.txtAccountName = New System.Windows.Forms.TextBox()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.lblCurrencyUnit2 = New System.Windows.Forms.Label()
      Me.txtADVMNote = New Longkong.Pojjaman.Gui.Components.MultiLineTextBox()
      Me.lblPCNote = New System.Windows.Forms.Label()
      Me.lblOrgDocDate = New System.Windows.Forms.Label()
      Me.txtADVMDate = New System.Windows.Forms.TextBox()
      Me.dtpADVMDate = New System.Windows.Forms.DateTimePicker()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.grbHeader = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtRemaining = New System.Windows.Forms.TextBox()
      Me.lblCurrencyUnit1 = New System.Windows.Forms.Label()
      Me.lblRemaining = New System.Windows.Forms.Label()
      Me.txtADVMCode = New System.Windows.Forms.TextBox()
      Me.lblADVMCode = New System.Windows.Forms.Label()
      Me.txtADVMName = New System.Windows.Forms.TextBox()
      Me.btnAdvanceMoneyFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.txtdocdate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.grbAdvanceMoney.SuspendLayout()
      Me.grbLocation.SuspendLayout()
      Me.grbHeader.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbAdvanceMoney
      '
      Me.grbAdvanceMoney.Controls.Add(Me.txtDueDate)
      Me.grbAdvanceMoney.Controls.Add(Me.dtpDueDate)
      Me.grbAdvanceMoney.Controls.Add(Me.lblDueDate)
      Me.grbAdvanceMoney.Controls.Add(Me.grbLocation)
      Me.grbAdvanceMoney.Controls.Add(Me.txtAccountCode)
      Me.grbAdvanceMoney.Controls.Add(Me.lblAccount)
      Me.grbAdvanceMoney.Controls.Add(Me.txtAccountName)
      Me.grbAdvanceMoney.Controls.Add(Me.txtAmount)
      Me.grbAdvanceMoney.Controls.Add(Me.lblAmount)
      Me.grbAdvanceMoney.Controls.Add(Me.lblCurrencyUnit2)
      Me.grbAdvanceMoney.Controls.Add(Me.txtADVMNote)
      Me.grbAdvanceMoney.Controls.Add(Me.lblPCNote)
      Me.grbAdvanceMoney.Controls.Add(Me.lblOrgDocDate)
      Me.grbAdvanceMoney.Controls.Add(Me.txtADVMDate)
      Me.grbAdvanceMoney.Controls.Add(Me.dtpADVMDate)
      Me.grbAdvanceMoney.Enabled = False
      Me.grbAdvanceMoney.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbAdvanceMoney.Location = New System.Drawing.Point(8, 128)
      Me.grbAdvanceMoney.Name = "grbAdvanceMoney"
      Me.grbAdvanceMoney.Size = New System.Drawing.Size(592, 208)
      Me.grbAdvanceMoney.TabIndex = 1
      Me.grbAdvanceMoney.TabStop = False
      Me.grbAdvanceMoney.Text = "รายละเอียดวงเงินที่จะปิด"
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
      Me.txtDueDate.Size = New System.Drawing.Size(110, 21)
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
      Me.grbLocation.Controls.Add(Me.txtCCCode)
      Me.grbLocation.Controls.Add(Me.rdIsEmployee)
      Me.grbLocation.Controls.Add(Me.txtEmployeeCode)
      Me.grbLocation.Controls.Add(Me.txtEmployeeName)
      Me.grbLocation.Controls.Add(Me.rdIsCC)
      Me.grbLocation.Controls.Add(Me.txtCCName)
      Me.grbLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbLocation.Location = New System.Drawing.Point(16, 48)
      Me.grbLocation.Name = "grbLocation"
      Me.grbLocation.Size = New System.Drawing.Size(536, 72)
      Me.grbLocation.TabIndex = 3
      Me.grbLocation.TabStop = False
      Me.grbLocation.Text = "สังกัด"
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
      'rdIsEmployee
      '
      Me.rdIsEmployee.Checked = True
      Me.rdIsEmployee.Location = New System.Drawing.Point(8, 16)
      Me.rdIsEmployee.Name = "rdIsEmployee"
      Me.rdIsEmployee.Size = New System.Drawing.Size(96, 24)
      Me.rdIsEmployee.TabIndex = 2
      Me.rdIsEmployee.TabStop = True
      Me.rdIsEmployee.Text = "พนักงาน:"
      '
      'txtEmployeeCode
      '
      Me.Validator.SetDataType(Me.txtEmployeeCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmployeeCode, "")
      Me.txtEmployeeCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmployeeCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
      Me.txtEmployeeCode.Location = New System.Drawing.Point(104, 16)
      Me.txtEmployeeCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtEmployeeCode, "")
      Me.txtEmployeeCode.Name = "txtEmployeeCode"
      Me.Validator.SetRegularExpression(Me.txtEmployeeCode, "")
      Me.Validator.SetRequired(Me.txtEmployeeCode, False)
      Me.txtEmployeeCode.Size = New System.Drawing.Size(128, 21)
      Me.txtEmployeeCode.TabIndex = 0
      '
      'txtEmployeeName
      '
      Me.Validator.SetDataType(Me.txtEmployeeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmployeeName, "")
      Me.txtEmployeeName.Enabled = False
      Me.txtEmployeeName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmployeeName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
      Me.txtEmployeeName.Location = New System.Drawing.Point(232, 16)
      Me.txtEmployeeName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtEmployeeName, "")
      Me.txtEmployeeName.Name = "txtEmployeeName"
      Me.txtEmployeeName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEmployeeName, "")
      Me.Validator.SetRequired(Me.txtEmployeeName, False)
      Me.txtEmployeeName.Size = New System.Drawing.Size(296, 21)
      Me.txtEmployeeName.TabIndex = 4
      Me.txtEmployeeName.TabStop = False
      '
      'rdIsCC
      '
      Me.rdIsCC.Location = New System.Drawing.Point(8, 40)
      Me.rdIsCC.Name = "rdIsCC"
      Me.rdIsCC.Size = New System.Drawing.Size(96, 24)
      Me.rdIsCC.TabIndex = 3
      Me.rdIsCC.Text = "Cost Center:"
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
      'txtADVMNote
      '
      Me.Validator.SetDataType(Me.txtADVMNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtADVMNote, "")
      Me.txtADVMNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtADVMNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtADVMNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtADVMNote, System.Drawing.Color.Empty)
      Me.txtADVMNote.Location = New System.Drawing.Point(120, 176)
      Me.txtADVMNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtADVMNote, "")
      Me.txtADVMNote.Name = "txtADVMNote"
      Me.Validator.SetRegularExpression(Me.txtADVMNote, "")
      Me.Validator.SetRequired(Me.txtADVMNote, False)
      Me.txtADVMNote.Size = New System.Drawing.Size(424, 21)
      Me.txtADVMNote.TabIndex = 6
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
      'txtADVMDate
      '
      Me.Validator.SetDataType(Me.txtADVMDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtADVMDate, "")
      Me.txtADVMDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtADVMDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtADVMDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtADVMDate, System.Drawing.Color.Empty)
      Me.txtADVMDate.Location = New System.Drawing.Point(128, 24)
      Me.txtADVMDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtADVMDate, "")
      Me.txtADVMDate.Name = "txtADVMDate"
      Me.Validator.SetRegularExpression(Me.txtADVMDate, "")
      Me.Validator.SetRequired(Me.txtADVMDate, False)
      Me.txtADVMDate.Size = New System.Drawing.Size(110, 21)
      Me.txtADVMDate.TabIndex = 1
      '
      'dtpADVMDate
      '
      Me.dtpADVMDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpADVMDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpADVMDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpADVMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpADVMDate.Location = New System.Drawing.Point(128, 24)
      Me.dtpADVMDate.Name = "dtpADVMDate"
      Me.dtpADVMDate.Size = New System.Drawing.Size(128, 21)
      Me.dtpADVMDate.TabIndex = 11
      Me.dtpADVMDate.TabStop = False
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
      Me.grbHeader.Controls.Add(Me.cmbCode)
      Me.grbHeader.Controls.Add(Me.chkAutorun)
      Me.grbHeader.Controls.Add(Me.lblDocDate)
      Me.grbHeader.Controls.Add(Me.lblCode)
      Me.grbHeader.Controls.Add(Me.txtRemaining)
      Me.grbHeader.Controls.Add(Me.lblCurrencyUnit1)
      Me.grbHeader.Controls.Add(Me.lblRemaining)
      Me.grbHeader.Controls.Add(Me.txtADVMCode)
      Me.grbHeader.Controls.Add(Me.lblADVMCode)
      Me.grbHeader.Controls.Add(Me.txtADVMName)
      Me.grbHeader.Controls.Add(Me.btnAdvanceMoneyFind)
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
      Me.lblRemaining.Location = New System.Drawing.Point(32, 62)
      Me.lblRemaining.Name = "lblRemaining"
      Me.lblRemaining.Size = New System.Drawing.Size(80, 18)
      Me.lblRemaining.TabIndex = 32
      Me.lblRemaining.Text = "วงเงินคงเหลือ:"
      Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtADVMCode
      '
      Me.Validator.SetDataType(Me.txtADVMCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtADVMCode, "")
      Me.txtADVMCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtADVMCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtADVMCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtADVMCode, System.Drawing.Color.Empty)
      Me.txtADVMCode.Location = New System.Drawing.Point(112, 38)
      Me.txtADVMCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtADVMCode, "")
      Me.txtADVMCode.Name = "txtADVMCode"
      Me.Validator.SetRegularExpression(Me.txtADVMCode, "")
      Me.Validator.SetRequired(Me.txtADVMCode, False)
      Me.txtADVMCode.Size = New System.Drawing.Size(128, 21)
      Me.txtADVMCode.TabIndex = 24
      '
      'lblADVMCode
      '
      Me.lblADVMCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblADVMCode.ForeColor = System.Drawing.Color.Black
      Me.lblADVMCode.Location = New System.Drawing.Point(24, 38)
      Me.lblADVMCode.Name = "lblADVMCode"
      Me.lblADVMCode.Size = New System.Drawing.Size(88, 18)
      Me.lblADVMCode.TabIndex = 30
      Me.lblADVMCode.Text = "เงินทดรองจ่าย:"
      Me.lblADVMCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtADVMName
      '
      Me.Validator.SetDataType(Me.txtADVMName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtADVMName, "")
      Me.txtADVMName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtADVMName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtADVMName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtADVMName, System.Drawing.Color.Empty)
      Me.txtADVMName.Location = New System.Drawing.Point(240, 38)
      Me.txtADVMName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtADVMName, "")
      Me.txtADVMName.Name = "txtADVMName"
      Me.txtADVMName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtADVMName, "")
      Me.Validator.SetRequired(Me.txtADVMName, False)
      Me.txtADVMName.Size = New System.Drawing.Size(304, 21)
      Me.txtADVMName.TabIndex = 27
      Me.txtADVMName.TabStop = False
      '
      'btnAdvanceMoneyFind
      '
      Me.btnAdvanceMoneyFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAdvanceMoneyFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAdvanceMoneyFind.Image = CType(resources.GetObject("btnAdvanceMoneyFind.Image"), System.Drawing.Image)
      Me.btnAdvanceMoneyFind.Location = New System.Drawing.Point(544, 38)
      Me.btnAdvanceMoneyFind.Name = "btnAdvanceMoneyFind"
      Me.btnAdvanceMoneyFind.Size = New System.Drawing.Size(24, 23)
      Me.btnAdvanceMoneyFind.TabIndex = 35
      Me.btnAdvanceMoneyFind.TabStop = False
      Me.btnAdvanceMoneyFind.ThemedImage = CType(resources.GetObject("btnAdvanceMoneyFind.ThemedImage"), System.Drawing.Bitmap)
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
      Me.txtdocdate.Size = New System.Drawing.Size(110, 21)
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
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(112, 15)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(128, 21)
      Me.cmbCode.TabIndex = 213
      '
      'AdvanceMoneyClosedDetail
      '
      Me.Controls.Add(Me.grbHeader)
      Me.Controls.Add(Me.grbAdvanceMoney)
      Me.Controls.Add(Me.lblStatus)
      Me.Name = "AdvanceMoneyClosedDetail"
      Me.Size = New System.Drawing.Size(608, 368)
      Me.grbAdvanceMoney.ResumeLayout(False)
      Me.grbAdvanceMoney.PerformLayout()
      Me.grbLocation.ResumeLayout(False)
      Me.grbLocation.PerformLayout()
      Me.grbHeader.ResumeLayout(False)
      Me.grbHeader.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()

    End Sub
#End Region

#Region "Members"
    Private m_entity As AdvanceMoneyClosed
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
    Public Sub SetAdvanceMoneyData()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.AdvanceMoney Is Nothing OrElse Not Me.m_entity.AdvanceMoney.Originated Then
        ClearAdvanceMoney()
        Me.m_entity.Amount = Nothing
      Else
        txtADVMDate.Text = MinDateToNull(Me.m_entity.AdvanceMoney.DocDate, "")
        dtpADVMDate.Value = MinDateToNow(Me.m_entity.AdvanceMoney.DocDate)

        txtDueDate.Text = MinDateToNull(Me.m_entity.AdvanceMoney.DueDate, "")
        dtpDueDate.Value = MinDateToNow(Me.m_entity.AdvanceMoney.DueDate)

        rdIsEmployee.Checked = Me.m_entity.AdvanceMoney.IsForEmployee
        rdIsCC.Checked = Not Me.m_entity.AdvanceMoney.IsForEmployee

        If Me.m_entity.AdvanceMoney.IsForEmployee Then
          txtEmployeeCode.Text = Me.m_entity.AdvanceMoney.Employee.Code
          txtEmployeeName.Text = Me.m_entity.AdvanceMoney.Employee.Name
          txtCCCode.Text = ""
          txtCCName.Text = ""

          txtEmployeeCode.Enabled = True
          txtEmployeeName.Enabled = True
          txtCCCode.Enabled = False
          txtCCName.Enabled = False
        Else
          txtCCCode.Text = Me.m_entity.AdvanceMoney.Costcenter.Code
          txtCCName.Text = Me.m_entity.AdvanceMoney.Costcenter.Name
          txtEmployeeCode.Text = ""
          txtEmployeeName.Text = ""

          txtCCCode.Enabled = True
          txtCCName.Enabled = True
          txtEmployeeCode.Enabled = False
          txtEmployeeName.Enabled = False
        End If

        txtAmount.Text = Configuration.FormatToString(Me.m_entity.AdvanceMoney.Amount, DigitConfig.Price)
        txtAccountCode.Text = Me.m_entity.AdvanceMoney.Account.Code
        txtAccountName.Text = Me.m_entity.AdvanceMoney.Account.Name
        txtADVMNote.Text = Me.m_entity.AdvanceMoney.Note

        ' วงเงินคงเหลือ
        Dim remainamt As Decimal = Me.m_entity.AdvanceMoney.GetRemainingAmount(True)
        Me.m_entity.AdvanceMoney.RemainingAmount = remainamt
        Me.m_entity.Amount = Me.m_entity.AdvanceMoney.Amount
        Me.m_entity.RemainAmount = remainamt
        txtRemaining.Text = Configuration.FormatToString(Me.m_entity.AdvanceMoney.RemainingAmount, DigitConfig.Price)
      End If
    End Sub
    Private Sub ClearAdvanceMoney()
      For Each grbCrtl As Control In grbAdvanceMoney.Controls
        If TypeOf grbCrtl Is TextBox Then
          grbCrtl.Text = ""
        End If
      Next
      For Each grbCrtl As Control In grbLocation.Controls
        If TypeOf grbCrtl Is TextBox Then
          grbCrtl.Text = ""
        End If
      Next
      rdIsEmployee.Checked = True
      dtpADVMDate.Value = Date.Now
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

      AddHandler txtADVMCode.Validated, AddressOf Me.ChangeProperty
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
          Dim OldAdvanceMoney As AdvanceMoney = Me.m_entity.AdvanceMoney

          dirtyFlag = AdvanceMoney.GetAdvanceMoney(txtADVMCode, txtADVMName, Me.m_entity.AdvanceMoney)
          If dirtyFlag AndAlso (OldAdvanceMoney.Id <> Me.m_entity.AdvanceMoney.Id AndAlso Me.m_entity.AdvanceMoney.Closed) Then
            Dim myMsgService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            myMsgService.ShowWarningFormatted("${res:Global.Error.AdvanceMoneyIsClosed}", Me.m_entity.AdvanceMoney.Code)
            Me.m_entity.AdvanceMoney = OldAdvanceMoney
            txtADVMCode.Text = OldAdvanceMoney.Code
            txtADVMName.Text = OldAdvanceMoney.Name
          End If
          SetAdvanceMoneyData()

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

      If Me.m_entity.AdvanceMoney Is Nothing Then
        txtADVMCode.Text = ""
        txtADVMName.Text = ""
        txtRemaining.Text = Configuration.FormatToString(0, DigitConfig.Price)
      Else
        txtADVMCode.Text = Me.m_entity.AdvanceMoney.Code
        txtADVMName.Text = Me.m_entity.AdvanceMoney.Name
        txtRemaining.Text = Configuration.FormatToString(Me.m_entity.AdvanceMoney.GetRemainingAmount, DigitConfig.Price)
      End If

      SetAdvanceMoneyData()

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

      SetAdvanceMoneyData()

      dtpDocDate.Value = Date.Now
      txtdocdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, AdvanceMoneyClosed)
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
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New AdvanceMoneyClosed).DetailPanelIcon
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
    Private Sub btnAdvanceMoneyEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New AdvanceMoney)
    End Sub
    Private Sub btnAdvanceMoneyFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvanceMoneyFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New ArrayList
      Dim advm As New AdvanceMoney
      advm.Closed = False
      entity.Add(advm)
      myEntityPanelService.OpenListDialog(New AdvanceMoney, AddressOf SetAdvanceMoneyDialog, entity)
    End Sub
    Private Sub SetAdvanceMoneyDialog(ByVal e As ISimpleEntity)
      Me.txtADVMCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or AdvanceMoney.GetAdvanceMoney(txtADVMCode, txtADVMName, Me.m_entity.AdvanceMoney)
      SetAdvanceMoneyData()
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New AdvanceMoney).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtadvmcode", "txtadvmname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New AdvanceMoney).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New AdvanceMoney).FullClassName))
        Dim entity As New AdvanceMoney(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtadvmcode", "txtadvmname"
              Me.SetAdvanceMoneyDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

  End Class

End Namespace