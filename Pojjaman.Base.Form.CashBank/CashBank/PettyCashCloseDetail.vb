Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels

Public Class PettyCashCloseDetail
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
    Friend WithEvents grbPettyCash As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grbBillRec As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtBillRecWeeks As System.Windows.Forms.TextBox
    Friend WithEvents txtBillRecDates As System.Windows.Forms.TextBox
    Friend WithEvents lblBillRecWeek As System.Windows.Forms.Label
    Friend WithEvents lblBillRecDate As System.Windows.Forms.Label
    Friend WithEvents lblBillRecDay As System.Windows.Forms.Label
    Friend WithEvents txtBillRecDays As System.Windows.Forms.TextBox
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
        Friend WithEvents grbWithdraw As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtlimit As System.Windows.Forms.TextBox
    Friend WithEvents rdNotAllow As System.Windows.Forms.RadioButton
    Friend WithEvents rdLimited As System.Windows.Forms.RadioButton
        Friend WithEvents rdAllow As System.Windows.Forms.RadioButton
    Friend WithEvents txtPCNote As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
    Friend WithEvents lblPCNote As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dtpPCDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPCDate As System.Windows.Forms.TextBox
        Friend WithEvents grbHeader As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtRemaining As System.Windows.Forms.TextBox
        Friend WithEvents lblRemaining As System.Windows.Forms.Label
        Friend WithEvents txtPCCode As System.Windows.Forms.TextBox
        Friend WithEvents lblPCCode As System.Windows.Forms.Label
        Friend WithEvents txtPCName As System.Windows.Forms.TextBox
        Friend WithEvents btnPettyCashFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtdocdate As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblCurrencyUnit2 As System.Windows.Forms.Label
        Friend WithEvents lblCurrencyUnit3 As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblCurrencyUnit1 As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashCloseDetail))
      Me.grbPettyCash = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbBillRec = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtBillRecWeeks = New System.Windows.Forms.TextBox
      Me.txtBillRecDates = New System.Windows.Forms.TextBox
      Me.lblBillRecWeek = New System.Windows.Forms.Label
      Me.lblBillRecDate = New System.Windows.Forms.Label
      Me.lblBillRecDay = New System.Windows.Forms.Label
      Me.txtBillRecDays = New System.Windows.Forms.TextBox
      Me.grbLocation = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtCCCode = New System.Windows.Forms.TextBox
      Me.rdIsEmployee = New System.Windows.Forms.RadioButton
      Me.txtEmployeeCode = New System.Windows.Forms.TextBox
      Me.txtEmployeeName = New System.Windows.Forms.TextBox
      Me.rdIsCC = New System.Windows.Forms.RadioButton
      Me.txtCCName = New System.Windows.Forms.TextBox
      Me.txtAccountCode = New System.Windows.Forms.TextBox
      Me.lblAccount = New System.Windows.Forms.Label
      Me.txtAccountName = New System.Windows.Forms.TextBox
      Me.txtAmount = New System.Windows.Forms.TextBox
      Me.lblAmount = New System.Windows.Forms.Label
      Me.lblCurrencyUnit2 = New System.Windows.Forms.Label
      Me.grbWithdraw = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtlimit = New System.Windows.Forms.TextBox
      Me.rdNotAllow = New System.Windows.Forms.RadioButton
      Me.rdLimited = New System.Windows.Forms.RadioButton
      Me.lblCurrencyUnit3 = New System.Windows.Forms.Label
      Me.rdAllow = New System.Windows.Forms.RadioButton
      Me.txtPCNote = New Longkong.Pojjaman.Gui.Components.MultiLineTextBox
      Me.lblPCNote = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtPCDate = New System.Windows.Forms.TextBox
      Me.dtpPCDate = New System.Windows.Forms.DateTimePicker
      Me.lblStatus = New System.Windows.Forms.Label
      Me.grbHeader = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtRemaining = New System.Windows.Forms.TextBox
      Me.lblCurrencyUnit1 = New System.Windows.Forms.Label
      Me.lblRemaining = New System.Windows.Forms.Label
      Me.txtPCCode = New System.Windows.Forms.TextBox
      Me.lblPCCode = New System.Windows.Forms.Label
      Me.txtPCName = New System.Windows.Forms.TextBox
      Me.btnPettyCashFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.txtdocdate = New System.Windows.Forms.TextBox
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.cmbCode = New System.Windows.Forms.ComboBox
      Me.grbPettyCash.SuspendLayout()
      Me.grbBillRec.SuspendLayout()
      Me.grbLocation.SuspendLayout()
      Me.grbWithdraw.SuspendLayout()
      Me.grbHeader.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbPettyCash
      '
      Me.grbPettyCash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbPettyCash.Controls.Add(Me.grbBillRec)
      Me.grbPettyCash.Controls.Add(Me.grbLocation)
      Me.grbPettyCash.Controls.Add(Me.txtAccountCode)
      Me.grbPettyCash.Controls.Add(Me.lblAccount)
      Me.grbPettyCash.Controls.Add(Me.txtAccountName)
      Me.grbPettyCash.Controls.Add(Me.txtAmount)
      Me.grbPettyCash.Controls.Add(Me.lblAmount)
      Me.grbPettyCash.Controls.Add(Me.lblCurrencyUnit2)
      Me.grbPettyCash.Controls.Add(Me.grbWithdraw)
      Me.grbPettyCash.Controls.Add(Me.txtPCNote)
      Me.grbPettyCash.Controls.Add(Me.lblPCNote)
      Me.grbPettyCash.Controls.Add(Me.Label1)
      Me.grbPettyCash.Controls.Add(Me.txtPCDate)
      Me.grbPettyCash.Controls.Add(Me.dtpPCDate)
      Me.grbPettyCash.Enabled = False
      Me.grbPettyCash.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbPettyCash.Location = New System.Drawing.Point(8, 128)
      Me.grbPettyCash.Name = "grbPettyCash"
      Me.grbPettyCash.Size = New System.Drawing.Size(592, 312)
      Me.grbPettyCash.TabIndex = 1
      Me.grbPettyCash.TabStop = False
      Me.grbPettyCash.Text = "รายละเอียดวงเงินที่จะยกเลิก"
      '
      'grbBillRec
      '
      Me.grbBillRec.Controls.Add(Me.txtBillRecWeeks)
      Me.grbBillRec.Controls.Add(Me.txtBillRecDates)
      Me.grbBillRec.Controls.Add(Me.lblBillRecWeek)
      Me.grbBillRec.Controls.Add(Me.lblBillRecDate)
      Me.grbBillRec.Controls.Add(Me.lblBillRecDay)
      Me.grbBillRec.Controls.Add(Me.txtBillRecDays)
      Me.grbBillRec.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbBillRec.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbBillRec.Location = New System.Drawing.Point(304, 208)
      Me.grbBillRec.Name = "grbBillRec"
      Me.grbBillRec.Size = New System.Drawing.Size(248, 96)
      Me.grbBillRec.TabIndex = 8
      Me.grbBillRec.TabStop = False
      Me.grbBillRec.Text = "กำหนดเคลมเงินสดย่อย"
      '
      'txtBillRecWeeks
      '
      Me.Validator.SetDataType(Me.txtBillRecWeeks, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillRecWeeks, "")
      Me.txtBillRecWeeks.Enabled = False
      Me.txtBillRecWeeks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillRecWeeks, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBillRecWeeks, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBillRecWeeks, System.Drawing.Color.Empty)
      Me.txtBillRecWeeks.Location = New System.Drawing.Point(72, 64)
      Me.txtBillRecWeeks.MaxLength = 100
      Me.Validator.SetMaxValue(Me.txtBillRecWeeks, "")
      Me.Validator.SetMinValue(Me.txtBillRecWeeks, "")
      Me.txtBillRecWeeks.Name = "txtBillRecWeeks"
      Me.txtBillRecWeeks.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBillRecWeeks, "")
      Me.Validator.SetRequired(Me.txtBillRecWeeks, False)
      Me.txtBillRecWeeks.Size = New System.Drawing.Size(168, 21)
      Me.txtBillRecWeeks.TabIndex = 7
      Me.txtBillRecWeeks.TabStop = False
      Me.txtBillRecWeeks.Text = ""
      '
      'txtBillRecDates
      '
      Me.Validator.SetDataType(Me.txtBillRecDates, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillRecDates, "")
      Me.txtBillRecDates.Enabled = False
      Me.txtBillRecDates.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillRecDates, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBillRecDates, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBillRecDates, System.Drawing.Color.Empty)
      Me.txtBillRecDates.Location = New System.Drawing.Point(72, 40)
      Me.txtBillRecDates.MaxLength = 100
      Me.Validator.SetMaxValue(Me.txtBillRecDates, "")
      Me.Validator.SetMinValue(Me.txtBillRecDates, "")
      Me.txtBillRecDates.Name = "txtBillRecDates"
      Me.txtBillRecDates.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBillRecDates, "")
      Me.Validator.SetRequired(Me.txtBillRecDates, False)
      Me.txtBillRecDates.Size = New System.Drawing.Size(168, 21)
      Me.txtBillRecDates.TabIndex = 4
      Me.txtBillRecDates.TabStop = False
      Me.txtBillRecDates.Text = ""
      '
      'lblBillRecWeek
      '
      Me.lblBillRecWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillRecWeek.ForeColor = System.Drawing.Color.Black
      Me.lblBillRecWeek.Location = New System.Drawing.Point(8, 64)
      Me.lblBillRecWeek.Name = "lblBillRecWeek"
      Me.lblBillRecWeek.Size = New System.Drawing.Size(56, 18)
      Me.lblBillRecWeek.TabIndex = 6
      Me.lblBillRecWeek.Text = "ทุกสัปดาห์"
      Me.lblBillRecWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBillRecDate
      '
      Me.lblBillRecDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillRecDate.ForeColor = System.Drawing.Color.Black
      Me.lblBillRecDate.Location = New System.Drawing.Point(8, 40)
      Me.lblBillRecDate.Name = "lblBillRecDate"
      Me.lblBillRecDate.Size = New System.Drawing.Size(56, 18)
      Me.lblBillRecDate.TabIndex = 3
      Me.lblBillRecDate.Text = "ทุกวันที่"
      Me.lblBillRecDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBillRecDay
      '
      Me.lblBillRecDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillRecDay.ForeColor = System.Drawing.Color.Black
      Me.lblBillRecDay.Location = New System.Drawing.Point(8, 16)
      Me.lblBillRecDay.Name = "lblBillRecDay"
      Me.lblBillRecDay.Size = New System.Drawing.Size(56, 18)
      Me.lblBillRecDay.TabIndex = 0
      Me.lblBillRecDay.Text = "ทุกวัน"
      Me.lblBillRecDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBillRecDays
      '
      Me.Validator.SetDataType(Me.txtBillRecDays, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillRecDays, "")
      Me.txtBillRecDays.Enabled = False
      Me.txtBillRecDays.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillRecDays, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBillRecDays, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBillRecDays, System.Drawing.Color.Empty)
      Me.txtBillRecDays.Location = New System.Drawing.Point(72, 16)
      Me.txtBillRecDays.MaxLength = 100
      Me.Validator.SetMaxValue(Me.txtBillRecDays, "")
      Me.Validator.SetMinValue(Me.txtBillRecDays, "")
      Me.txtBillRecDays.Name = "txtBillRecDays"
      Me.txtBillRecDays.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBillRecDays, "")
      Me.Validator.SetRequired(Me.txtBillRecDays, False)
      Me.txtBillRecDays.Size = New System.Drawing.Size(168, 21)
      Me.txtBillRecDays.TabIndex = 1
      Me.txtBillRecDays.TabStop = False
      Me.txtBillRecDays.Text = ""
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
      Me.Validator.SetMaxValue(Me.txtCCCode, "")
      Me.Validator.SetMinValue(Me.txtCCCode, "")
      Me.txtCCCode.Name = "txtCCCode"
      Me.Validator.SetRegularExpression(Me.txtCCCode, "")
      Me.Validator.SetRequired(Me.txtCCCode, False)
      Me.txtCCCode.Size = New System.Drawing.Size(128, 21)
      Me.txtCCCode.TabIndex = 1
      Me.txtCCCode.Text = ""
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
      Me.Validator.SetMaxValue(Me.txtEmployeeCode, "")
      Me.Validator.SetMinValue(Me.txtEmployeeCode, "")
      Me.txtEmployeeCode.Name = "txtEmployeeCode"
      Me.Validator.SetRegularExpression(Me.txtEmployeeCode, "")
      Me.Validator.SetRequired(Me.txtEmployeeCode, False)
      Me.txtEmployeeCode.Size = New System.Drawing.Size(128, 21)
      Me.txtEmployeeCode.TabIndex = 0
      Me.txtEmployeeCode.Text = ""
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
      Me.Validator.SetMaxValue(Me.txtEmployeeName, "")
      Me.Validator.SetMinValue(Me.txtEmployeeName, "")
      Me.txtEmployeeName.Name = "txtEmployeeName"
      Me.txtEmployeeName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEmployeeName, "")
      Me.Validator.SetRequired(Me.txtEmployeeName, False)
      Me.txtEmployeeName.Size = New System.Drawing.Size(296, 21)
      Me.txtEmployeeName.TabIndex = 4
      Me.txtEmployeeName.TabStop = False
      Me.txtEmployeeName.Text = ""
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
      Me.Validator.SetMaxValue(Me.txtCCName, "")
      Me.Validator.SetMinValue(Me.txtCCName, "")
      Me.txtCCName.Name = "txtCCName"
      Me.txtCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCCName, "")
      Me.Validator.SetRequired(Me.txtCCName, False)
      Me.txtCCName.Size = New System.Drawing.Size(296, 21)
      Me.txtCCName.TabIndex = 5
      Me.txtCCName.TabStop = False
      Me.txtCCName.Text = ""
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
      Me.Validator.SetMaxValue(Me.txtAccountCode, "")
      Me.Validator.SetMinValue(Me.txtAccountCode, "")
      Me.txtAccountCode.Name = "txtAccountCode"
      Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccountCode, False)
      Me.txtAccountCode.Size = New System.Drawing.Size(128, 21)
      Me.txtAccountCode.TabIndex = 5
      Me.txtAccountCode.Text = ""
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
      Me.Validator.SetMaxValue(Me.txtAccountName, "")
      Me.Validator.SetMinValue(Me.txtAccountName, "")
      Me.txtAccountName.Name = "txtAccountName"
      Me.txtAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountName, "")
      Me.Validator.SetRequired(Me.txtAccountName, False)
      Me.txtAccountName.Size = New System.Drawing.Size(296, 21)
      Me.txtAccountName.TabIndex = 16
      Me.txtAccountName.TabStop = False
      Me.txtAccountName.Text = ""
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
      Me.Validator.SetMaxValue(Me.txtAmount, "")
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, False)
      Me.txtAmount.Size = New System.Drawing.Size(128, 21)
      Me.txtAmount.TabIndex = 4
      Me.txtAmount.Text = ""
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
      Me.lblCurrencyUnit2.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrencyUnit2.TabIndex = 14
      Me.lblCurrencyUnit2.Text = "บาท"
      Me.lblCurrencyUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbWithdraw
      '
      Me.grbWithdraw.Controls.Add(Me.txtlimit)
      Me.grbWithdraw.Controls.Add(Me.rdNotAllow)
      Me.grbWithdraw.Controls.Add(Me.rdLimited)
      Me.grbWithdraw.Controls.Add(Me.lblCurrencyUnit3)
      Me.grbWithdraw.Controls.Add(Me.rdAllow)
      Me.grbWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbWithdraw.Location = New System.Drawing.Point(16, 208)
      Me.grbWithdraw.Name = "grbWithdraw"
      Me.grbWithdraw.Size = New System.Drawing.Size(280, 96)
      Me.grbWithdraw.TabIndex = 7
      Me.grbWithdraw.TabStop = False
      Me.grbWithdraw.Text = "เบิกเกินวงเงิน"
      '
      'txtlimit
      '
      Me.Validator.SetDataType(Me.txtlimit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtlimit, "")
      Me.txtlimit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtlimit, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtlimit, -15)
      Me.Validator.SetInvalidBackColor(Me.txtlimit, System.Drawing.Color.Empty)
      Me.txtlimit.Location = New System.Drawing.Point(104, 40)
      Me.txtlimit.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtlimit, "")
      Me.Validator.SetMinValue(Me.txtlimit, "")
      Me.txtlimit.Name = "txtlimit"
      Me.Validator.SetRegularExpression(Me.txtlimit, "")
      Me.Validator.SetRequired(Me.txtlimit, False)
      Me.txtlimit.Size = New System.Drawing.Size(128, 21)
      Me.txtlimit.TabIndex = 0
      Me.txtlimit.Text = ""
      Me.txtlimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'rdNotAllow
      '
      Me.rdNotAllow.Checked = True
      Me.rdNotAllow.Location = New System.Drawing.Point(8, 16)
      Me.rdNotAllow.Name = "rdNotAllow"
      Me.rdNotAllow.Size = New System.Drawing.Size(120, 24)
      Me.rdNotAllow.TabIndex = 1
      Me.rdNotAllow.TabStop = True
      Me.rdNotAllow.Text = "ไม่อนุญาติ"
      '
      'rdLimited
      '
      Me.rdLimited.Location = New System.Drawing.Point(8, 40)
      Me.rdLimited.Name = "rdLimited"
      Me.rdLimited.TabIndex = 2
      Me.rdLimited.Text = "อนุญาติให้ไม่เกิน"
      '
      'lblCurrencyUnit3
      '
      Me.lblCurrencyUnit3.AutoSize = True
      Me.lblCurrencyUnit3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit3.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit3.Location = New System.Drawing.Point(240, 40)
      Me.lblCurrencyUnit3.Name = "lblCurrencyUnit3"
      Me.lblCurrencyUnit3.Size = New System.Drawing.Size(25, 17)
      Me.lblCurrencyUnit3.TabIndex = 4
      Me.lblCurrencyUnit3.Text = "บาท"
      Me.lblCurrencyUnit3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'rdAllow
      '
      Me.rdAllow.Location = New System.Drawing.Point(8, 64)
      Me.rdAllow.Name = "rdAllow"
      Me.rdAllow.Size = New System.Drawing.Size(64, 24)
      Me.rdAllow.TabIndex = 3
      Me.rdAllow.Text = "ไม่จำกัด"
      '
      'txtPCNote
      '
      Me.Validator.SetDataType(Me.txtPCNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPCNote, "")
      Me.txtPCNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPCNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPCNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPCNote, System.Drawing.Color.Empty)
      Me.txtPCNote.Location = New System.Drawing.Point(120, 176)
      Me.txtPCNote.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtPCNote, "")
      Me.Validator.SetMinValue(Me.txtPCNote, "")
      Me.txtPCNote.Name = "txtPCNote"
      Me.Validator.SetRegularExpression(Me.txtPCNote, "")
      Me.Validator.SetRequired(Me.txtPCNote, False)
      Me.txtPCNote.Size = New System.Drawing.Size(424, 21)
      Me.txtPCNote.TabIndex = 6
      Me.txtPCNote.Text = ""
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
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 24)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(104, 18)
      Me.Label1.TabIndex = 10
      Me.Label1.Text = "ตั้งเมื่อวันที่:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPCDate
      '
      Me.Validator.SetDataType(Me.txtPCDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPCDate, "")
      Me.txtPCDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPCDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPCDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPCDate, System.Drawing.Color.Empty)
      Me.txtPCDate.Location = New System.Drawing.Point(128, 24)
      Me.txtPCDate.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtPCDate, "")
      Me.Validator.SetMinValue(Me.txtPCDate, "")
      Me.txtPCDate.Name = "txtPCDate"
      Me.Validator.SetRegularExpression(Me.txtPCDate, "")
      Me.Validator.SetRequired(Me.txtPCDate, False)
      Me.txtPCDate.Size = New System.Drawing.Size(110, 21)
      Me.txtPCDate.TabIndex = 1
      Me.txtPCDate.Text = ""
      '
      'dtpPCDate
      '
      Me.dtpPCDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpPCDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpPCDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpPCDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPCDate.Location = New System.Drawing.Point(128, 24)
      Me.dtpPCDate.Name = "dtpPCDate"
      Me.dtpPCDate.Size = New System.Drawing.Size(128, 21)
      Me.dtpPCDate.TabIndex = 11
      Me.dtpPCDate.TabStop = False
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Location = New System.Drawing.Point(8, 448)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 16)
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
      Me.grbHeader.Controls.Add(Me.txtPCCode)
      Me.grbHeader.Controls.Add(Me.lblPCCode)
      Me.grbHeader.Controls.Add(Me.txtPCName)
      Me.grbHeader.Controls.Add(Me.btnPettyCashFind)
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
      Me.grbHeader.Text = "รายละเอียดการยกเลิก"
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
      Me.lblDocDate.Location = New System.Drawing.Point(248, 15)
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
      Me.Validator.SetMaxValue(Me.txtRemaining, "")
      Me.Validator.SetMinValue(Me.txtRemaining, "")
      Me.txtRemaining.Name = "txtRemaining"
      Me.txtRemaining.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRemaining, "")
      Me.Validator.SetRequired(Me.txtRemaining, False)
      Me.txtRemaining.Size = New System.Drawing.Size(128, 21)
      Me.txtRemaining.TabIndex = 23
      Me.txtRemaining.TabStop = False
      Me.txtRemaining.Text = ""
      Me.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCurrencyUnit1
      '
      Me.lblCurrencyUnit1.AutoSize = True
      Me.lblCurrencyUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit1.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit1.Location = New System.Drawing.Point(248, 62)
      Me.lblCurrencyUnit1.Name = "lblCurrencyUnit1"
      Me.lblCurrencyUnit1.Size = New System.Drawing.Size(25, 17)
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
      'txtPCCode
      '
      Me.Validator.SetDataType(Me.txtPCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPCCode, "")
      Me.txtPCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPCCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPCCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPCCode, System.Drawing.Color.Empty)
      Me.txtPCCode.Location = New System.Drawing.Point(112, 38)
      Me.txtPCCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtPCCode, "")
      Me.Validator.SetMinValue(Me.txtPCCode, "")
      Me.txtPCCode.Name = "txtPCCode"
      Me.Validator.SetRegularExpression(Me.txtPCCode, "")
      Me.Validator.SetRequired(Me.txtPCCode, False)
      Me.txtPCCode.Size = New System.Drawing.Size(128, 21)
      Me.txtPCCode.TabIndex = 24
      Me.txtPCCode.Text = ""
      '
      'lblPCCode
      '
      Me.lblPCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPCCode.ForeColor = System.Drawing.Color.Black
      Me.lblPCCode.Location = New System.Drawing.Point(40, 38)
      Me.lblPCCode.Name = "lblPCCode"
      Me.lblPCCode.Size = New System.Drawing.Size(72, 18)
      Me.lblPCCode.TabIndex = 30
      Me.lblPCCode.Text = "วงเงินสดย่อย:"
      Me.lblPCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPCName
      '
      Me.Validator.SetDataType(Me.txtPCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPCName, "")
      Me.txtPCName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPCName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPCName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPCName, System.Drawing.Color.Empty)
      Me.txtPCName.Location = New System.Drawing.Point(240, 38)
      Me.txtPCName.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtPCName, "")
      Me.Validator.SetMinValue(Me.txtPCName, "")
      Me.txtPCName.Name = "txtPCName"
      Me.txtPCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtPCName, "")
      Me.Validator.SetRequired(Me.txtPCName, False)
      Me.txtPCName.Size = New System.Drawing.Size(304, 21)
      Me.txtPCName.TabIndex = 27
      Me.txtPCName.TabStop = False
      Me.txtPCName.Text = ""
      '
      'btnPettyCashFind
      '
      Me.btnPettyCashFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPettyCashFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPettyCashFind.Image = CType(resources.GetObject("btnPettyCashFind.Image"), System.Drawing.Image)
      Me.btnPettyCashFind.Location = New System.Drawing.Point(544, 38)
      Me.btnPettyCashFind.Name = "btnPettyCashFind"
      Me.btnPettyCashFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPettyCashFind.TabIndex = 35
      Me.btnPettyCashFind.TabStop = False
      Me.btnPettyCashFind.ThemedImage = CType(resources.GetObject("btnPettyCashFind.ThemedImage"), System.Drawing.Bitmap)
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
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(432, 21)
      Me.txtNote.TabIndex = 28
      Me.txtNote.Text = ""
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
      Me.txtdocdate.Location = New System.Drawing.Point(352, 14)
      Me.txtdocdate.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtdocdate, "")
      Me.Validator.SetMinValue(Me.txtdocdate, "")
      Me.txtdocdate.Name = "txtdocdate"
      Me.Validator.SetRegularExpression(Me.txtdocdate, "")
      Me.Validator.SetRequired(Me.txtdocdate, False)
      Me.txtdocdate.Size = New System.Drawing.Size(110, 21)
      Me.txtdocdate.TabIndex = 26
      Me.txtdocdate.Text = ""
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(352, 14)
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(112, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(128, 21)
      Me.cmbCode.TabIndex = 38
      '
      'PettyCashCloseDetail
      '
      Me.Controls.Add(Me.grbHeader)
      Me.Controls.Add(Me.grbPettyCash)
      Me.Controls.Add(Me.lblStatus)
      Me.Name = "PettyCashCloseDetail"
      Me.Size = New System.Drawing.Size(608, 472)
      Me.grbPettyCash.ResumeLayout(False)
      Me.grbBillRec.ResumeLayout(False)
      Me.grbLocation.ResumeLayout(False)
      Me.grbWithdraw.ResumeLayout(False)
      Me.grbHeader.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()

    End Sub
#End Region

#Region "Members"
        Private m_entity As PettyCashClosed
    Private m_combocodeindex As Integer
        Private m_isInitialized As Boolean = False
#End Region

#Region "Property"
    Private Property ComboCodeIndex() As Integer
      Get
        If m_combocodeindex = -1 Then
          If cmbCode.Items.Count > 0 Then
            m_combocodeindex = 0
          End If
        End If
        Return m_combocodeindex
      End Get
      Set(ByVal Value As Integer)
        m_combocodeindex = Value
      End Set
    End Property
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
    Public Sub SetPettyCashData()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.PettyCash Is Nothing OrElse Not Me.m_entity.PettyCash.Originated Then
        ClearPettyCash()
        Me.m_entity.Amount = Nothing
      Else
        txtPCDate.Text = MinDateToNull(Me.m_entity.PettyCash.DocDate, "")
        dtpPCDate.Value = MinDateToNow(Me.m_entity.PettyCash.DocDate)

        rdIsEmployee.Checked = Me.m_entity.PettyCash.IsForEmployee
        rdIsCC.Checked = Not Me.m_entity.PettyCash.IsForEmployee

        If Me.m_entity.PettyCash.IsForEmployee Then
          txtEmployeeCode.Text = Me.m_entity.PettyCash.Employee.Code
          txtEmployeeName.Text = Me.m_entity.PettyCash.Employee.Name
          txtCCCode.Text = ""
          txtCCName.Text = ""

          txtEmployeeCode.Enabled = True
          txtEmployeeName.Enabled = True
          txtCCCode.Enabled = False
          txtCCName.Enabled = False
        Else
          txtCCCode.Text = Me.m_entity.PettyCash.Costcenter.Code
          txtCCName.Text = Me.m_entity.PettyCash.Costcenter.Name
          txtEmployeeCode.Text = ""
          txtEmployeeName.Text = ""

          txtCCCode.Enabled = True
          txtCCName.Enabled = True
          txtEmployeeCode.Enabled = False
          txtEmployeeName.Enabled = False
        End If

        txtAmount.Text = Configuration.FormatToString(Me.m_entity.PettyCash.Amount, DigitConfig.Price)
        txtAccountCode.Text = Me.m_entity.PettyCash.Account.Code
        txtAccountName.Text = Me.m_entity.PettyCash.Account.Name
        txtPCNote.Text = Me.m_entity.PettyCash.Note

        rdNotAllow.Checked = Not Me.m_entity.PettyCash.AllowOverBudget
        rdAllow.Checked = Me.m_entity.PettyCash.AllowOverBudget
        rdLimited.Checked = Me.m_entity.PettyCash.LimitedOverBudget
        txtlimit.Text = Configuration.FormatToString(Me.m_entity.PettyCash.LimitedOverBudgetAmount, DigitConfig.Price)

        txtBillRecDays.Text = DateTimeService.GetDayStrings(Me.m_entity.PettyCash.ClaimRecDays, False)
        txtBillRecDates.Text = ConvertItemsToValueArray(Me.m_entity.PettyCash.ClaimRecDates)
        txtBillRecWeeks.Text = ConvertItemsToValueArray(Me.m_entity.PettyCash.ClaimRecWeeks)

        ' วงเงินคงเหลือ
        Dim remainamt As Decimal = Me.m_entity.PettyCash.GetRemainingAmount
        Me.m_entity.PettyCash.RemainingAmount = remainamt
        Me.m_entity.Amount = Me.m_entity.PettyCash.Amount
        Me.m_entity.RemainAmount = remainamt
        txtRemaining.Text = Configuration.FormatToString(Me.m_entity.PettyCash.RemainingAmount, DigitConfig.Price)
      End If
    End Sub
    Private Sub ClearPettyCash()
      For Each grbCrtl As Control In grbPettyCash.Controls
        If TypeOf grbCrtl Is TextBox Then
          grbCrtl.Text = ""
        End If
      Next
      For Each grbCrtl As Control In grbLocation.Controls
        If TypeOf grbCrtl Is TextBox Then
          grbCrtl.Text = ""
        End If
      Next
      For Each grbCrtl As Control In grbWithdraw.Controls
        If TypeOf grbCrtl Is TextBox Then
          grbCrtl.Text = ""
        End If
      Next
      For Each grbCrtl As Control In grbBillRec.Controls
        If TypeOf grbCrtl Is TextBox Then
          grbCrtl.Text = ""
        End If
      Next
      rdIsEmployee.Checked = True
      rdNotAllow.Checked = True
      dtpPCDate.Value = Date.Now
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

      AddHandler txtPCCode.Validated, AddressOf Me.ChangeProperty
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
          Me.m_entity.Code = cmbCode.Text
          'เพิ่ม AutoCode
          If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
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

        Case "txtpccode"
          Dim OldPettycash As PettyCash = Me.m_entity.PettyCash

          dirtyFlag = PettyCash.GetPettyCash(txtPCCode, txtPCName, Me.m_entity.PettyCash)
          If dirtyFlag AndAlso (OldPettycash.Id <> Me.m_entity.PettyCash.Id AndAlso Me.m_entity.PettyCash.Closed) Then
            Dim myMsgService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            myMsgService.ShowWarningFormatted("${res:Global.Error.PettyCashClosed}", Me.m_entity.PettyCash.Code)
            Me.m_entity.PettyCash = OldPettycash
            txtPCCode.Text = OldPettycash.Code
            txtPCName.Text = OldPettycash.Name
          End If
          SetPettyCashData()

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

      If Me.m_entity.PettyCash Is Nothing Then
        txtPCCode.Text = ""
        txtPCName.Text = ""
        txtRemaining.Text = Configuration.FormatToString(0, DigitConfig.Price)
      Else
        txtPCCode.Text = Me.m_entity.PettyCash.Code
        txtPCName.Text = Me.m_entity.PettyCash.Name
        txtRemaining.Text = Configuration.FormatToString(Me.m_entity.PettyCash.RemainingAmount, DigitConfig.Price)
      End If

      SetPettyCashData()

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

      SetPettyCashData()

      dtpDocDate.Value = Date.Now
      txtdocdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, PettyCashClosed)
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
        Return (New PettyCashClosed).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
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
        'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        'Me.m_entity.Code = ""
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_oldCode
        'Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
#End Region

#Region "Event of Button controls"
    ' Employee
    Private Sub btnPettyCashEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New PettyCash)
    End Sub
    Private Sub btnPettyCashFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPettyCashFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      filters(0) = New Filter("pc_closed", 0)
      myEntityPanelService.OpenListDialog(New PettyCash, AddressOf SetPettyCashDialog, filters)
    End Sub
    Private Sub SetPettyCashDialog(ByVal e As ISimpleEntity)
      Me.txtPCCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or PettyCash.GetPettyCash(txtPCCode, txtPCName, Me.m_entity.PettyCash)
      SetPettyCashData()
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New PettyCash).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtpccode", "txtpcname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New PettyCash).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New PettyCash).FullClassName))
        Dim entity As New PettyCash(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtpccode", "txtpcname"
              Me.SetPettyCashDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region


    
  End Class

End Namespace