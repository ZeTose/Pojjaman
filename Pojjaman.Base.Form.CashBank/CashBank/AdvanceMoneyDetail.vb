Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AdvanceMoneyDetail
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
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents grbAdvanceMoney As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents txtNote As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents btnAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtdocdate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents btnEmployeeFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnEmployeeEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents lblBaht2 As System.Windows.Forms.Label
    Friend WithEvents lblIsClosed As System.Windows.Forms.Label
    Friend WithEvents txtIsClosed As System.Windows.Forms.TextBox
    Friend WithEvents grbLocation As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCode As System.Windows.Forms.TextBox
    Friend WithEvents rdIsEmployee As System.Windows.Forms.RadioButton
    Friend WithEvents rdIsCC As System.Windows.Forms.RadioButton
    Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCName As System.Windows.Forms.TextBox
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AdvanceMoneyDetail))
      Me.btnAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtName = New System.Windows.Forms.TextBox
      Me.lblName = New System.Windows.Forms.Label
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblAccount = New System.Windows.Forms.Label
      Me.txtAccountCode = New System.Windows.Forms.TextBox
      Me.txtAccountName = New System.Windows.Forms.TextBox
      Me.grbAdvanceMoney = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbLocation = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCode = New System.Windows.Forms.TextBox
      Me.rdIsEmployee = New System.Windows.Forms.RadioButton
      Me.rdIsCC = New System.Windows.Forms.RadioButton
      Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCName = New System.Windows.Forms.TextBox
      Me.btnEmployeeFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnEmployeeEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEmployeeCode = New System.Windows.Forms.TextBox
      Me.txtEmployeeName = New System.Windows.Forms.TextBox
      Me.txtIsClosed = New System.Windows.Forms.TextBox
      Me.lblIsClosed = New System.Windows.Forms.Label
      Me.txtDueDate = New System.Windows.Forms.TextBox
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
      Me.lblDueDate = New System.Windows.Forms.Label
      Me.txtTotal = New System.Windows.Forms.TextBox
      Me.lblBaht2 = New System.Windows.Forms.Label
      Me.lblTotal = New System.Windows.Forms.Label
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblItem = New System.Windows.Forms.Label
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.txtdocdate = New System.Windows.Forms.TextBox
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.lblStatus = New System.Windows.Forms.Label
      Me.btnAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAmount = New System.Windows.Forms.TextBox
      Me.lblAmount = New System.Windows.Forms.Label
      Me.lblBaht = New System.Windows.Forms.Label
      Me.txtNote = New Longkong.Pojjaman.Gui.Components.MultiLineTextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.cmbCode = New System.Windows.Forms.ComboBox
      Me.grbAdvanceMoney.SuspendLayout()
      Me.grbLocation.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnAccountEdit
      '
      Me.btnAccountEdit.Image = CType(resources.GetObject("btnAccountEdit.Image"), System.Drawing.Image)
      Me.btnAccountEdit.Location = New System.Drawing.Point(520, 176)
      Me.btnAccountEdit.Name = "btnAccountEdit"
      Me.btnAccountEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnAccountEdit.TabIndex = 16
      Me.btnAccountEdit.TabStop = False
      Me.btnAccountEdit.ThemedImage = CType(resources.GetObject("btnAccountEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(120, 48)
      Me.Validator.SetMaxValue(Me.txtName, "")
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(128, 21)
      Me.txtName.TabIndex = 7
      Me.txtName.Text = ""
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(16, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(104, 18)
      Me.lblName.TabIndex = 6
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAccount
      '
      Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccount.ForeColor = System.Drawing.Color.Black
      Me.lblAccount.Location = New System.Drawing.Point(16, 176)
      Me.lblAccount.Name = "lblAccount"
      Me.lblAccount.Size = New System.Drawing.Size(104, 18)
      Me.lblAccount.TabIndex = 12
      Me.lblAccount.Text = "บัญชี:"
      Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAccountCode
      '
      Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCode, "")
      Me.txtAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.txtAccountCode.Location = New System.Drawing.Point(120, 176)
      Me.Validator.SetMaxValue(Me.txtAccountCode, "")
      Me.Validator.SetMinValue(Me.txtAccountCode, "")
      Me.txtAccountCode.Name = "txtAccountCode"
      Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccountCode, False)
      Me.txtAccountCode.Size = New System.Drawing.Size(128, 21)
      Me.txtAccountCode.TabIndex = 16
      Me.txtAccountCode.Text = ""
      '
      'txtAccountName
      '
      Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountName, "")
      Me.txtAccountName.Enabled = False
      Me.txtAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.txtAccountName.Location = New System.Drawing.Point(248, 176)
      Me.Validator.SetMaxValue(Me.txtAccountName, "")
      Me.Validator.SetMinValue(Me.txtAccountName, "")
      Me.txtAccountName.Name = "txtAccountName"
      Me.txtAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountName, "")
      Me.Validator.SetRequired(Me.txtAccountName, False)
      Me.txtAccountName.Size = New System.Drawing.Size(248, 21)
      Me.txtAccountName.TabIndex = 17
      Me.txtAccountName.TabStop = False
      Me.txtAccountName.Text = ""
      '
      'grbAdvanceMoney
      '
      Me.grbAdvanceMoney.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbAdvanceMoney.Controls.Add(Me.grbLocation)
      Me.grbAdvanceMoney.Controls.Add(Me.txtIsClosed)
      Me.grbAdvanceMoney.Controls.Add(Me.lblIsClosed)
      Me.grbAdvanceMoney.Controls.Add(Me.txtDueDate)
      Me.grbAdvanceMoney.Controls.Add(Me.dtpDueDate)
      Me.grbAdvanceMoney.Controls.Add(Me.lblDueDate)
      Me.grbAdvanceMoney.Controls.Add(Me.txtTotal)
      Me.grbAdvanceMoney.Controls.Add(Me.lblBaht2)
      Me.grbAdvanceMoney.Controls.Add(Me.lblTotal)
      Me.grbAdvanceMoney.Controls.Add(Me.tgItem)
      Me.grbAdvanceMoney.Controls.Add(Me.lblItem)
      Me.grbAdvanceMoney.Controls.Add(Me.chkAutorun)
      Me.grbAdvanceMoney.Controls.Add(Me.txtdocdate)
      Me.grbAdvanceMoney.Controls.Add(Me.dtpDocDate)
      Me.grbAdvanceMoney.Controls.Add(Me.lblStatus)
      Me.grbAdvanceMoney.Controls.Add(Me.btnAccountFind)
      Me.grbAdvanceMoney.Controls.Add(Me.txtAccountCode)
      Me.grbAdvanceMoney.Controls.Add(Me.lblAccount)
      Me.grbAdvanceMoney.Controls.Add(Me.txtAccountName)
      Me.grbAdvanceMoney.Controls.Add(Me.txtName)
      Me.grbAdvanceMoney.Controls.Add(Me.btnAccountEdit)
      Me.grbAdvanceMoney.Controls.Add(Me.lblName)
      Me.grbAdvanceMoney.Controls.Add(Me.lblCode)
      Me.grbAdvanceMoney.Controls.Add(Me.txtAmount)
      Me.grbAdvanceMoney.Controls.Add(Me.lblAmount)
      Me.grbAdvanceMoney.Controls.Add(Me.lblBaht)
      Me.grbAdvanceMoney.Controls.Add(Me.txtNote)
      Me.grbAdvanceMoney.Controls.Add(Me.lblNote)
      Me.grbAdvanceMoney.Controls.Add(Me.lblDocDate)
      Me.grbAdvanceMoney.Controls.Add(Me.cmbCode)
      Me.grbAdvanceMoney.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbAdvanceMoney.Location = New System.Drawing.Point(8, 8)
      Me.grbAdvanceMoney.Name = "grbAdvanceMoney"
      Me.grbAdvanceMoney.Size = New System.Drawing.Size(568, 616)
      Me.grbAdvanceMoney.TabIndex = 0
      Me.grbAdvanceMoney.TabStop = False
      Me.grbAdvanceMoney.Text = "ตั้งวงเงินทดรองจ่ายคงเหลือ"
      '
      'grbLocation
      '
      Me.grbLocation.Controls.Add(Me.btnCCFind)
      Me.grbLocation.Controls.Add(Me.txtCCCode)
      Me.grbLocation.Controls.Add(Me.rdIsEmployee)
      Me.grbLocation.Controls.Add(Me.rdIsCC)
      Me.grbLocation.Controls.Add(Me.btnCCEdit)
      Me.grbLocation.Controls.Add(Me.txtCCName)
      Me.grbLocation.Controls.Add(Me.btnEmployeeFind)
      Me.grbLocation.Controls.Add(Me.btnEmployeeEdit)
      Me.grbLocation.Controls.Add(Me.txtEmployeeCode)
      Me.grbLocation.Controls.Add(Me.txtEmployeeName)
      Me.grbLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbLocation.Location = New System.Drawing.Point(16, 72)
      Me.grbLocation.Name = "grbLocation"
      Me.grbLocation.Size = New System.Drawing.Size(536, 72)
      Me.grbLocation.TabIndex = 218
      Me.grbLocation.TabStop = False
      Me.grbLocation.Text = "สังกัด"
      '
      'btnCCFind
      '
      Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCFind.Image = CType(resources.GetObject("btnCCFind.Image"), System.Drawing.Image)
      Me.btnCCFind.Location = New System.Drawing.Point(480, 40)
      Me.btnCCFind.Name = "btnCCFind"
      Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCCFind.TabIndex = 8
      Me.btnCCFind.TabStop = False
      Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
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
      Me.Validator.SetMaxValue(Me.txtCCCode, "")
      Me.Validator.SetMinValue(Me.txtCCCode, "")
      Me.txtCCCode.Name = "txtCCCode"
      Me.Validator.SetRegularExpression(Me.txtCCCode, "")
      Me.Validator.SetRequired(Me.txtCCCode, False)
      Me.txtCCCode.Size = New System.Drawing.Size(128, 21)
      Me.txtCCCode.TabIndex = 13
      Me.txtCCCode.Text = ""
      '
      'rdIsEmployee
      '
      Me.rdIsEmployee.Checked = True
      Me.rdIsEmployee.Location = New System.Drawing.Point(8, 16)
      Me.rdIsEmployee.Name = "rdIsEmployee"
      Me.rdIsEmployee.Size = New System.Drawing.Size(96, 24)
      Me.rdIsEmployee.TabIndex = 9
      Me.rdIsEmployee.TabStop = True
      Me.rdIsEmployee.Text = "พนักงาน:"
      '
      'rdIsCC
      '
      Me.rdIsCC.Location = New System.Drawing.Point(8, 40)
      Me.rdIsCC.Name = "rdIsCC"
      Me.rdIsCC.Size = New System.Drawing.Size(96, 24)
      Me.rdIsCC.TabIndex = 12
      Me.rdIsCC.Text = "Cost Center:"
      '
      'btnCCEdit
      '
      Me.btnCCEdit.Image = CType(resources.GetObject("btnCCEdit.Image"), System.Drawing.Image)
      Me.btnCCEdit.Location = New System.Drawing.Point(504, 40)
      Me.btnCCEdit.Name = "btnCCEdit"
      Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCCEdit.TabIndex = 9
      Me.btnCCEdit.TabStop = False
      Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
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
      Me.Validator.SetMaxValue(Me.txtCCName, "")
      Me.Validator.SetMinValue(Me.txtCCName, "")
      Me.txtCCName.Name = "txtCCName"
      Me.txtCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCCName, "")
      Me.Validator.SetRequired(Me.txtCCName, False)
      Me.txtCCName.Size = New System.Drawing.Size(248, 21)
      Me.txtCCName.TabIndex = 14
      Me.txtCCName.TabStop = False
      Me.txtCCName.Text = ""
      '
      'btnEmployeeFind
      '
      Me.btnEmployeeFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmployeeFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmployeeFind.Image = CType(resources.GetObject("btnEmployeeFind.Image"), System.Drawing.Image)
      Me.btnEmployeeFind.Location = New System.Drawing.Point(480, 16)
      Me.btnEmployeeFind.Name = "btnEmployeeFind"
      Me.btnEmployeeFind.Size = New System.Drawing.Size(24, 23)
      Me.btnEmployeeFind.TabIndex = 208
      Me.btnEmployeeFind.TabStop = False
      Me.btnEmployeeFind.ThemedImage = CType(resources.GetObject("btnEmployeeFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnEmployeeEdit
      '
      Me.btnEmployeeEdit.Image = CType(resources.GetObject("btnEmployeeEdit.Image"), System.Drawing.Image)
      Me.btnEmployeeEdit.Location = New System.Drawing.Point(504, 16)
      Me.btnEmployeeEdit.Name = "btnEmployeeEdit"
      Me.btnEmployeeEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnEmployeeEdit.TabIndex = 209
      Me.btnEmployeeEdit.TabStop = False
      Me.btnEmployeeEdit.ThemedImage = CType(resources.GetObject("btnEmployeeEdit.ThemedImage"), System.Drawing.Bitmap)
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
      Me.Validator.SetMaxValue(Me.txtEmployeeCode, "")
      Me.Validator.SetMinValue(Me.txtEmployeeCode, "")
      Me.txtEmployeeCode.Name = "txtEmployeeCode"
      Me.Validator.SetRegularExpression(Me.txtEmployeeCode, "")
      Me.Validator.SetRequired(Me.txtEmployeeCode, False)
      Me.txtEmployeeCode.Size = New System.Drawing.Size(128, 21)
      Me.txtEmployeeCode.TabIndex = 210
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
      Me.Validator.SetMaxValue(Me.txtEmployeeName, "")
      Me.Validator.SetMinValue(Me.txtEmployeeName, "")
      Me.txtEmployeeName.Name = "txtEmployeeName"
      Me.txtEmployeeName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEmployeeName, "")
      Me.Validator.SetRequired(Me.txtEmployeeName, False)
      Me.txtEmployeeName.Size = New System.Drawing.Size(248, 21)
      Me.txtEmployeeName.TabIndex = 211
      Me.txtEmployeeName.TabStop = False
      Me.txtEmployeeName.Text = ""
      '
      'txtIsClosed
      '
      Me.Validator.SetDataType(Me.txtIsClosed, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtIsClosed, "")
      Me.Validator.SetGotFocusBackColor(Me.txtIsClosed, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtIsClosed, System.Drawing.Color.Empty)
      Me.txtIsClosed.Location = New System.Drawing.Point(120, 224)
      Me.Validator.SetMaxValue(Me.txtIsClosed, "")
      Me.Validator.SetMinValue(Me.txtIsClosed, "")
      Me.txtIsClosed.Name = "txtIsClosed"
      Me.txtIsClosed.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtIsClosed, "")
      Me.Validator.SetRequired(Me.txtIsClosed, False)
      Me.txtIsClosed.Size = New System.Drawing.Size(112, 20)
      Me.txtIsClosed.TabIndex = 217
      Me.txtIsClosed.Text = ""
      '
      'lblIsClosed
      '
      Me.lblIsClosed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblIsClosed.ForeColor = System.Drawing.Color.Black
      Me.lblIsClosed.Location = New System.Drawing.Point(16, 224)
      Me.lblIsClosed.Name = "lblIsClosed"
      Me.lblIsClosed.Size = New System.Drawing.Size(104, 18)
      Me.lblIsClosed.TabIndex = 216
      Me.lblIsClosed.Text = "ปิดวงเงิน:"
      Me.lblIsClosed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDueDate
      '
      Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDate, "")
      Me.txtDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDueDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.txtDueDate.Location = New System.Drawing.Point(416, 48)
      Me.Validator.SetMaxValue(Me.txtDueDate, "")
      Me.Validator.SetMinValue(Me.txtDueDate, "")
      Me.txtDueDate.Name = "txtDueDate"
      Me.Validator.SetRegularExpression(Me.txtDueDate, "")
      Me.Validator.SetRequired(Me.txtDueDate, True)
      Me.txtDueDate.Size = New System.Drawing.Size(110, 21)
      Me.txtDueDate.TabIndex = 214
      Me.txtDueDate.Text = ""
      '
      'dtpDueDate
      '
      Me.dtpDueDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDueDate.Location = New System.Drawing.Point(416, 48)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(128, 21)
      Me.dtpDueDate.TabIndex = 215
      Me.dtpDueDate.TabStop = False
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.ForeColor = System.Drawing.Color.Black
      Me.lblDueDate.Location = New System.Drawing.Point(312, 48)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(104, 18)
      Me.lblDueDate.TabIndex = 213
      Me.lblDueDate.Text = "วันกำหนดคืน:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTotal
      '
      Me.Validator.SetDataType(Me.txtTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotal, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotal, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotal, System.Drawing.Color.Empty)
      Me.txtTotal.Location = New System.Drawing.Point(376, 224)
      Me.Validator.SetMaxValue(Me.txtTotal, "")
      Me.Validator.SetMinValue(Me.txtTotal, "")
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotal, "")
      Me.Validator.SetRequired(Me.txtTotal, False)
      Me.txtTotal.Size = New System.Drawing.Size(136, 20)
      Me.txtTotal.TabIndex = 206
      Me.txtTotal.Text = ""
      '
      'lblBaht2
      '
      Me.lblBaht2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht2.ForeColor = System.Drawing.Color.Black
      Me.lblBaht2.Location = New System.Drawing.Point(520, 224)
      Me.lblBaht2.Name = "lblBaht2"
      Me.lblBaht2.Size = New System.Drawing.Size(32, 16)
      Me.lblBaht2.TabIndex = 203
      Me.lblBaht2.Text = "บาท"
      Me.lblBaht2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblTotal
      '
      Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotal.Location = New System.Drawing.Point(232, 224)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(144, 18)
      Me.lblTotal.TabIndex = 205
      Me.lblTotal.Text = "ยอดเงินทดรองจ่ายคงเหลือ:"
      Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.tgItem.Location = New System.Drawing.Point(16, 272)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(536, 312)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 207
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(24, 256)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(200, 18)
      Me.lblItem.TabIndex = 204
      Me.lblItem.Text = "บันทึกยอดตัดจ่ายเงินทดรองจ่าย"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(248, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 2
      '
      'txtdocdate
      '
      Me.Validator.SetDataType(Me.txtdocdate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtdocdate, "")
      Me.txtdocdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtdocdate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtdocdate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtdocdate, System.Drawing.Color.Empty)
      Me.txtdocdate.Location = New System.Drawing.Point(416, 24)
      Me.Validator.SetMaxValue(Me.txtdocdate, "")
      Me.Validator.SetMinValue(Me.txtdocdate, "")
      Me.txtdocdate.Name = "txtdocdate"
      Me.Validator.SetRegularExpression(Me.txtdocdate, "")
      Me.Validator.SetRequired(Me.txtdocdate, True)
      Me.txtdocdate.Size = New System.Drawing.Size(110, 21)
      Me.txtdocdate.TabIndex = 4
      Me.txtdocdate.Text = ""
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(416, 24)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(128, 21)
      Me.dtpDocDate.TabIndex = 5
      Me.dtpDocDate.TabStop = False
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Location = New System.Drawing.Point(16, 592)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 16)
      Me.lblStatus.TabIndex = 21
      Me.lblStatus.Text = "lblStatus"
      '
      'btnAccountFind
      '
      Me.btnAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountFind.Image = CType(resources.GetObject("btnAccountFind.Image"), System.Drawing.Image)
      Me.btnAccountFind.Location = New System.Drawing.Point(496, 176)
      Me.btnAccountFind.Name = "btnAccountFind"
      Me.btnAccountFind.Size = New System.Drawing.Size(24, 23)
      Me.btnAccountFind.TabIndex = 15
      Me.btnAccountFind.TabStop = False
      Me.btnAccountFind.ThemedImage = CType(resources.GetObject("btnAccountFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAmount
      '
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(120, 152)
      Me.Validator.SetMaxValue(Me.txtAmount, "")
      Me.Validator.SetMinValue(Me.txtAmount, "0")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(128, 21)
      Me.txtAmount.TabIndex = 15
      Me.txtAmount.Text = ""
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(16, 152)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(104, 18)
      Me.lblAmount.TabIndex = 9
      Me.lblAmount.Text = "วงเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBaht
      '
      Me.lblBaht.AutoSize = True
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.ForeColor = System.Drawing.Color.Black
      Me.lblBaht.Location = New System.Drawing.Point(256, 152)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(25, 17)
      Me.lblBaht.TabIndex = 11
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(120, 200)
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(424, 21)
      Me.txtNote.TabIndex = 18
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(16, 200)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(104, 18)
      Me.lblNote.TabIndex = 17
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(312, 24)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(104, 18)
      Me.lblDocDate.TabIndex = 3
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.cmbCode.Location = New System.Drawing.Point(120, 24)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(128, 21)
      Me.cmbCode.TabIndex = 212
      '
      'AdvanceMoneyDetail
      '
      Me.Controls.Add(Me.grbAdvanceMoney)
      Me.Name = "AdvanceMoneyDetail"
      Me.Size = New System.Drawing.Size(584, 632)
      Me.grbAdvanceMoney.ResumeLayout(False)
      Me.grbLocation.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Setlabeltext "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.lblName}")
      Me.Validator.SetDisplayName(txtName, lblName.Text)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.lblCode}")
      Me.Validator.SetDisplayName(cmbCode, lblCode.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.lblDocDate}")
      Me.Validator.SetDisplayName(txtdocdate, lblDocDate.Text)

      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.lblDueDate}")
      Me.Validator.SetDisplayName(txtDueDate, lblDueDate.Text)

      Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.lblAccount}")
      Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.lblAmount}")
      Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblBaht2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.lblNote}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.rdIsEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.rdIsEmployee}")
      Me.rdIsCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.rdIsCC}")

      Me.lblIsClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.lblIsClosed}")

      Me.grbAdvanceMoney.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.grbAdvanceMoney}")

    End Sub
#End Region

#Region "Members"
    Private m_entity As AdvanceMoney
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_combocodeindex As Integer
#End Region

#Region "Constructs"
    Public Sub New()
      MyBase.New()
      InitializeComponent()

      Initialize()

      Dim dt As TreeTable = AdvanceMoney.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      EventWiring()
    End Sub
#End Region

#Region " Style "
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "AdvanceMoney"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      ' Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "avdm_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 25
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "avdm_linenumber"

      Dim csDate As New TreeTextColumn
      csDate.MappingName = "Date"
      csDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.DateHeaderText}")
      csDate.NullText = ""
      csDate.Width = 50
      csDate.ReadOnly = True
      csDate.TextBox.Name = "Date"

      Dim csDueDate As New TreeTextColumn
      csDueDate.MappingName = "DueDate"
      csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.DueDateHeaderText}")
      csDueDate.NullText = ""
      csDueDate.Width = 50
      csDueDate.ReadOnly = True
      csDueDate.TextBox.Name = "DueDate"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Alignment = HorizontalAlignment.Right
      csAmount.TextBox.Name = "Amount"

      Dim csRemainingAmount As New TreeTextColumn
      csRemainingAmount.MappingName = "RemainingAmount"
      csRemainingAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.RemainingAmountHeaderText}")
      csRemainingAmount.NullText = ""
      csRemainingAmount.ReadOnly = True
      csRemainingAmount.Format = "#,###.##"
      csRemainingAmount.DataAlignment = HorizontalAlignment.Right
      csRemainingAmount.Alignment = HorizontalAlignment.Right
      csRemainingAmount.TextBox.Name = "RemainingAmount"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "avdm_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "avdm_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csRemainingAmount)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function
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
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 _
      OrElse Me.m_entity.Closed _
      OrElse Me.m_entity.Payment.Status.Value = 0 _
      OrElse Me.m_entity.Payment.Status.Value >= 3 _
      Then
        For Each ctl As Control In Me.grbAdvanceMoney.Controls
          If ctl.Name = "tgItem" Then
            ctl.Enabled = True
          Else
            ctl.Enabled = False
          End If
        Next
      Else
        For Each ctl As Control In Me.grbAdvanceMoney.Controls
          If ctl.Name = "tgItem" Then
            ctl.Enabled = True
          Else
            ctl.Enabled = True
          End If
        Next
        SetRequireEntity()

      End If
    End Sub
    Private Sub SetRequireEntity()
      ' Set Validator Require.
      If Me.m_entity.IsForEmployee Then
        Me.Validator.SetRequired(txtEmployeeCode, True)
        Me.Validator.SetRequired(txtCCCode, False)
        txtEmployeeCode.Enabled = True
        btnEmployeeFind.Enabled = True

        Me.ErrorProvider1.SetError(Me.txtCCCode, "")
        txtCCCode.Enabled = False
        btnCCFind.Enabled = False
      Else
        Me.Validator.SetRequired(txtCCCode, True)
        Me.Validator.SetRequired(txtEmployeeCode, False)
        txtCCCode.Enabled = True
        btnCCFind.Enabled = True

        Me.ErrorProvider1.SetError(Me.txtEmployeeCode, "")
        txtEmployeeCode.Enabled = False
        btnEmployeeFind.Enabled = False
      End If
    End Sub
    Public Overrides Sub Initialize()

    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler rdIsEmployee.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler rdIsCC.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtdocdate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDueDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtEmployeeCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAccountCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAmount.Validated, AddressOf Me.NumericChanged

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    Public Sub NumericChanged(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtamount"
          txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
      End Select
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
            Me.m_entity.OnGlChanged()
          End If
          dirtyFlag = True
        Case "txtname"
          dirtyFlag = True
          Me.m_entity.Name = txtName.Text
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

        Case "dtpduedate"
          If Not Me.m_entity.DueDate.Equals(dtpDueDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDate.Text = MinDateToNull(dtpDueDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DueDate = dtpDueDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtduedate"
          m_dateSetting = True
          If Not Me.txtDueDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDueDate.Text)
            If Not Me.m_entity.DueDate.Equals(theDate) Then
              dtpDueDate.Value = theDate
              Me.m_entity.DueDate = dtpDueDate.Value
              dirtyFlag = True
            End If
          Else
            Me.m_entity.DueDate = Date.Now
            Me.m_entity.DueDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "txtemployeecode"
          dirtyFlag = Employee.GetEmployee(txtEmployeeCode, txtEmployeeName, Me.m_entity.Employee)
        Case "txtaccountcode"
          dirtyFlag = Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)
        Case "txtamount"
          dirtyFlag = True
          If txtAmount.TextLength > 0 AndAlso IsNumeric(txtAmount.Text) Then
            Me.m_entity.Amount = CDec(txtAmount.Text)
          Else
            Me.m_entity.Amount = Nothing
          End If

        Case "txtnote"
          dirtyFlag = True
          Me.m_entity.Note = txtNote.Text

        Case "rdisemployee", "rdiscc"
          dirtyFlag = True
          If rdIsEmployee.Checked Then
            Me.m_entity.Costcenter = New CostCenter
            Me.m_entity.IsForEmployee = True
          Else
            Me.m_entity.Employee = New Employee
            Me.m_entity.IsForEmployee = False
          End If
          If Not Me.m_entity.Employee Is Nothing Then
            txtEmployeeCode.Text = Me.m_entity.Employee.Code
            txtEmployeeName.Text = Me.m_entity.Employee.Name
          End If
          If Not Me.m_entity.Costcenter Is Nothing Then
            txtCCCode.Text = Me.m_entity.Costcenter.Code
            txtCCName.Text = Me.m_entity.Costcenter.Name
          End If
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
      txtName.Text = Me.m_entity.Name

      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtdocdate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)

      If Me.m_entity.IsForEmployee Then
        rdIsEmployee.Checked = True
      Else
        rdIsCC.Checked = True
      End If

      If Not Me.m_entity.Employee Is Nothing Then
        txtEmployeeCode.Text = Me.m_entity.Employee.Code
        txtEmployeeName.Text = Me.m_entity.Employee.Name
      End If
      If Not Me.m_entity.Costcenter Is Nothing Then
        txtCCCode.Text = Me.m_entity.Costcenter.Code
        txtCCName.Text = Me.m_entity.Costcenter.Name
      End If

      txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)

      If Not Me.m_entity.Account Is Nothing Then
        txtAccountCode.Text = Me.m_entity.Account.Code
        txtAccountName.Text = Me.m_entity.Account.Name
      End If

      txtNote.Text = Me.m_entity.Note

      Dim closed As String
      If Me.m_entity.Closed = True Then
        closed = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.IsClosedYes}")
      ElseIf Me.m_entity.Closed = False Then
        closed = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceMoneyDetail.IsClosedNo}")
      End If

      txtIsClosed.Text = closed

      Me.m_entity.ReLoadItems()

      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************
      UpdateAmount()

      SetStatus()
      SetLabelText()
      CheckFormEnable()

      m_isInitialized = True
    End Sub

    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbAdvanceMoney.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        End If
      Next

      rdIsEmployee.Checked = True

      dtpDocDate.Value = Date.Now
      txtdocdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      dtpDueDate.Value = Date.Now
      txtDueDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, AdvanceMoney)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Private Sub UpdateAmount()
      txtTotal.Text = Configuration.FormatToString(m_entity.GetRemainingAmount, DigitConfig.Price)
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
        'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        'Me.m_entity.Code = ""
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        ' Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_oldCode
        'Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
#End Region

#Region "Event of Button controls"
    ' Employee
    Private Sub btnEmployeeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnEmployeeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeDialog)
    End Sub
    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtEmployeeCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtEmployeeCode, txtEmployeeName, Me.m_entity.Employee)
    End Sub
    ' Costcenter
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostcenterDialog)
    End Sub
    Private Sub SetCostcenterDialog(ByVal e As ISimpleEntity)
      Me.txtCCCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.m_entity.Costcenter)
    End Sub
    ' Account
    Private Sub btnAccountEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Account)
    End Sub
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountDialog)
    End Sub
    Private Sub SetAccountDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtaccountcode", "txtaccountname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtemployeecode", "txtemployeename"
              Me.SetEmployeeDialog(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New Account).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        Dim entity As New Account(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtaccountcode", "txtaccountname"
              Me.SetAccountDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

    Protected Overrides Sub UpdateDefaultButton()

    End Sub
  End Class
End Namespace