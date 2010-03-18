Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class LoanDetailView
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
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDocdate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents btnBankAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnBankAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtBankBranch As System.Windows.Forms.TextBox
    Friend WithEvents lblBank As System.Windows.Forms.Label
    Friend WithEvents lblBankAccount As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyUnit1 As System.Windows.Forms.Label
    Friend WithEvents txtInterest As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
    Friend WithEvents lblInterest As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCode As System.Windows.Forms.TextBox
    Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCName As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents chkClosed As System.Windows.Forms.CheckBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoanDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkClosed = New System.Windows.Forms.CheckBox()
      Me.btnAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.btnAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAccount = New System.Windows.Forms.Label()
      Me.txtCCCode = New System.Windows.Forms.TextBox()
      Me.txtAccountCode = New System.Windows.Forms.TextBox()
      Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAccountName = New System.Windows.Forms.TextBox()
      Me.txtCCName = New System.Windows.Forms.TextBox()
      Me.cmbType = New System.Windows.Forms.ComboBox()
      Me.txtInterest = New Longkong.Pojjaman.Gui.Components.MultiLineTextBox()
      Me.lblInterest = New System.Windows.Forms.Label()
      Me.btnBankAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnBankAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBankAccountCode = New System.Windows.Forms.TextBox()
      Me.txtBankAccountName = New System.Windows.Forms.TextBox()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.txtBankBranch = New System.Windows.Forms.TextBox()
      Me.lblBank = New System.Windows.Forms.Label()
      Me.lblBankAccount = New System.Windows.Forms.Label()
      Me.lblCurrencyUnit1 = New System.Windows.Forms.Label()
      Me.txtDocdate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblName = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.chkClosed)
      Me.grbDetail.Controls.Add(Me.btnAccountEdit)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.btnAccountFind)
      Me.grbDetail.Controls.Add(Me.btnCCFind)
      Me.grbDetail.Controls.Add(Me.lblAccount)
      Me.grbDetail.Controls.Add(Me.txtCCCode)
      Me.grbDetail.Controls.Add(Me.txtAccountCode)
      Me.grbDetail.Controls.Add(Me.btnCCEdit)
      Me.grbDetail.Controls.Add(Me.txtAccountName)
      Me.grbDetail.Controls.Add(Me.txtCCName)
      Me.grbDetail.Controls.Add(Me.cmbType)
      Me.grbDetail.Controls.Add(Me.txtInterest)
      Me.grbDetail.Controls.Add(Me.lblInterest)
      Me.grbDetail.Controls.Add(Me.btnBankAccountFind)
      Me.grbDetail.Controls.Add(Me.btnBankAccountEdit)
      Me.grbDetail.Controls.Add(Me.txtBankAccountCode)
      Me.grbDetail.Controls.Add(Me.txtBankAccountName)
      Me.grbDetail.Controls.Add(Me.txtAmount)
      Me.grbDetail.Controls.Add(Me.lblAmount)
      Me.grbDetail.Controls.Add(Me.txtBankBranch)
      Me.grbDetail.Controls.Add(Me.lblBank)
      Me.grbDetail.Controls.Add(Me.lblBankAccount)
      Me.grbDetail.Controls.Add(Me.lblCurrencyUnit1)
      Me.grbDetail.Controls.Add(Me.txtDocdate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(750, 235)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลธนาคาร : "
      '
      'chkClosed
      '
      Me.chkClosed.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkClosed.Location = New System.Drawing.Point(504, 21)
      Me.chkClosed.Name = "chkClosed"
      Me.chkClosed.Size = New System.Drawing.Size(80, 21)
      Me.chkClosed.TabIndex = 260
      Me.chkClosed.Text = "ปิดวงเงินกู้"
      Me.chkClosed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAccountEdit
      '
      Me.btnAccountEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountEdit.Location = New System.Drawing.Point(520, 198)
      Me.btnAccountEdit.Name = "btnAccountEdit"
      Me.btnAccountEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnAccountEdit.TabIndex = 259
      Me.btnAccountEdit.TabStop = False
      Me.btnAccountEdit.ThemedImage = CType(resources.GetObject("btnAccountEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostCenter.Location = New System.Drawing.Point(8, 174)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(136, 18)
      Me.lblCostCenter.TabIndex = 20
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnAccountFind
      '
      Me.btnAccountFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountFind.Location = New System.Drawing.Point(496, 198)
      Me.btnAccountFind.Name = "btnAccountFind"
      Me.btnAccountFind.Size = New System.Drawing.Size(24, 23)
      Me.btnAccountFind.TabIndex = 258
      Me.btnAccountFind.TabStop = False
      Me.btnAccountFind.ThemedImage = CType(resources.GetObject("btnAccountFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCFind
      '
      Me.btnCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCFind.Location = New System.Drawing.Point(496, 171)
      Me.btnCCFind.Name = "btnCCFind"
      Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCCFind.TabIndex = 23
      Me.btnCCFind.TabStop = False
      Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAccount
      '
      Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccount.ForeColor = System.Drawing.Color.Black
      Me.lblAccount.Location = New System.Drawing.Point(15, 198)
      Me.lblAccount.Name = "lblAccount"
      Me.lblAccount.Size = New System.Drawing.Size(129, 18)
      Me.lblAccount.TabIndex = 257
      Me.lblAccount.Text = "บัญชี:"
      Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCCCode
      '
      Me.Validator.SetDataType(Me.txtCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCode, "")
      Me.txtCCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
      Me.txtCCCode.Location = New System.Drawing.Point(150, 173)
      Me.Validator.SetMinValue(Me.txtCCCode, "")
      Me.txtCCCode.Name = "txtCCCode"
      Me.Validator.SetRegularExpression(Me.txtCCCode, "")
      Me.Validator.SetRequired(Me.txtCCCode, False)
      Me.txtCCCode.Size = New System.Drawing.Size(136, 21)
      Me.txtCCCode.TabIndex = 21
      '
      'txtAccountCode
      '
      Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCode, "")
      Me.txtAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.txtAccountCode.Location = New System.Drawing.Point(150, 198)
      Me.txtAccountCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtAccountCode, "")
      Me.txtAccountCode.Name = "txtAccountCode"
      Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccountCode, True)
      Me.txtAccountCode.Size = New System.Drawing.Size(137, 21)
      Me.txtAccountCode.TabIndex = 255
      '
      'btnCCEdit
      '
      Me.btnCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCEdit.Location = New System.Drawing.Point(520, 171)
      Me.btnCCEdit.Name = "btnCCEdit"
      Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCCEdit.TabIndex = 24
      Me.btnCCEdit.TabStop = False
      Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountName
      '
      Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountName, "")
      Me.txtAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.txtAccountName.Location = New System.Drawing.Point(287, 198)
      Me.Validator.SetMinValue(Me.txtAccountName, "")
      Me.txtAccountName.Name = "txtAccountName"
      Me.txtAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountName, "")
      Me.Validator.SetRequired(Me.txtAccountName, False)
      Me.txtAccountName.Size = New System.Drawing.Size(208, 21)
      Me.txtAccountName.TabIndex = 256
      Me.txtAccountName.TabStop = False
      '
      'txtCCName
      '
      Me.Validator.SetDataType(Me.txtCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCName, "")
      Me.txtCCName.Enabled = False
      Me.txtCCName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCCName, System.Drawing.Color.Empty)
      Me.txtCCName.Location = New System.Drawing.Point(287, 173)
      Me.Validator.SetMinValue(Me.txtCCName, "")
      Me.txtCCName.Name = "txtCCName"
      Me.txtCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCCName, "")
      Me.Validator.SetRequired(Me.txtCCName, False)
      Me.txtCCName.Size = New System.Drawing.Size(208, 21)
      Me.txtCCName.TabIndex = 22
      Me.txtCCName.TabStop = False
      '
      'cmbType
      '
      Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbType.Location = New System.Drawing.Point(370, 72)
      Me.cmbType.Name = "cmbType"
      Me.cmbType.Size = New System.Drawing.Size(128, 21)
      Me.cmbType.TabIndex = 10
      '
      'txtInterest
      '
      Me.Validator.SetDataType(Me.txtInterest, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtInterest, "")
      Me.txtInterest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtInterest, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInterest, System.Drawing.Color.Empty)
      Me.txtInterest.Location = New System.Drawing.Point(150, 97)
      Me.txtInterest.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtInterest, "")
      Me.txtInterest.Name = "txtInterest"
      Me.Validator.SetRegularExpression(Me.txtInterest, "")
      Me.Validator.SetRequired(Me.txtInterest, False)
      Me.txtInterest.Size = New System.Drawing.Size(392, 21)
      Me.txtInterest.TabIndex = 12
      '
      'lblInterest
      '
      Me.lblInterest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInterest.ForeColor = System.Drawing.Color.Black
      Me.lblInterest.Location = New System.Drawing.Point(6, 97)
      Me.lblInterest.Name = "lblInterest"
      Me.lblInterest.Size = New System.Drawing.Size(136, 18)
      Me.lblInterest.TabIndex = 11
      Me.lblInterest.Text = "ดอกเบี้ย:"
      Me.lblInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnBankAccountFind
      '
      Me.btnBankAccountFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAccountFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankAccountFind.Location = New System.Drawing.Point(496, 124)
      Me.btnBankAccountFind.Name = "btnBankAccountFind"
      Me.btnBankAccountFind.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAccountFind.TabIndex = 16
      Me.btnBankAccountFind.TabStop = False
      Me.btnBankAccountFind.ThemedImage = CType(resources.GetObject("btnBankAccountFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnBankAccountEdit
      '
      Me.btnBankAccountEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAccountEdit.Location = New System.Drawing.Point(520, 124)
      Me.btnBankAccountEdit.Name = "btnBankAccountEdit"
      Me.btnBankAccountEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAccountEdit.TabIndex = 17
      Me.btnBankAccountEdit.TabStop = False
      Me.btnBankAccountEdit.ThemedImage = CType(resources.GetObject("btnBankAccountEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankAccountCode
      '
      Me.Validator.SetDataType(Me.txtBankAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAccountCode, "")
      Me.txtBankAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
      Me.txtBankAccountCode.Location = New System.Drawing.Point(150, 124)
      Me.txtBankAccountCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtBankAccountCode, "")
      Me.txtBankAccountCode.Name = "txtBankAccountCode"
      Me.Validator.SetRegularExpression(Me.txtBankAccountCode, "")
      Me.Validator.SetRequired(Me.txtBankAccountCode, True)
      Me.txtBankAccountCode.Size = New System.Drawing.Size(136, 21)
      Me.txtBankAccountCode.TabIndex = 14
      '
      'txtBankAccountName
      '
      Me.Validator.SetDataType(Me.txtBankAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAccountName, "")
      Me.txtBankAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.txtBankAccountName.Location = New System.Drawing.Point(287, 124)
      Me.txtBankAccountName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtBankAccountName, "")
      Me.txtBankAccountName.Name = "txtBankAccountName"
      Me.txtBankAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankAccountName, "")
      Me.Validator.SetRequired(Me.txtBankAccountName, False)
      Me.txtBankAccountName.Size = New System.Drawing.Size(208, 21)
      Me.txtBankAccountName.TabIndex = 15
      Me.txtBankAccountName.TabStop = False
      '
      'txtAmount
      '
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(150, 72)
      Me.txtAmount.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtAmount.TabIndex = 8
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(6, 72)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(136, 18)
      Me.lblAmount.TabIndex = 7
      Me.lblAmount.Text = "จำนวนเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBankBranch
      '
      Me.Validator.SetDataType(Me.txtBankBranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankBranch, "")
      Me.txtBankBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
      Me.txtBankBranch.Location = New System.Drawing.Point(150, 148)
      Me.txtBankBranch.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtBankBranch, "")
      Me.txtBankBranch.Name = "txtBankBranch"
      Me.txtBankBranch.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankBranch, "")
      Me.Validator.SetRequired(Me.txtBankBranch, False)
      Me.txtBankBranch.Size = New System.Drawing.Size(392, 21)
      Me.txtBankBranch.TabIndex = 19
      Me.txtBankBranch.TabStop = False
      '
      'lblBank
      '
      Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBank.ForeColor = System.Drawing.Color.Black
      Me.lblBank.Location = New System.Drawing.Point(6, 148)
      Me.lblBank.Name = "lblBank"
      Me.lblBank.Size = New System.Drawing.Size(136, 18)
      Me.lblBank.TabIndex = 18
      Me.lblBank.Text = "ธนาคาร/สาขา:"
      Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBankAccount
      '
      Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
      Me.lblBankAccount.Location = New System.Drawing.Point(6, 124)
      Me.lblBankAccount.Name = "lblBankAccount"
      Me.lblBankAccount.Size = New System.Drawing.Size(136, 18)
      Me.lblBankAccount.TabIndex = 13
      Me.lblBankAccount.Text = "สมุดเงินฝากธนาคาร:"
      Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrencyUnit1
      '
      Me.lblCurrencyUnit1.AutoSize = True
      Me.lblCurrencyUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit1.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit1.Location = New System.Drawing.Point(294, 72)
      Me.lblCurrencyUnit1.Name = "lblCurrencyUnit1"
      Me.lblCurrencyUnit1.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrencyUnit1.TabIndex = 9
      Me.lblCurrencyUnit1.Text = "บาท"
      Me.lblCurrencyUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtDocdate
      '
      Me.Validator.SetDataType(Me.txtDocdate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocdate, "")
      Me.txtDocdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDocdate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocdate, System.Drawing.Color.Empty)
      Me.txtDocdate.Location = New System.Drawing.Point(362, 21)
      Me.txtDocdate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocdate, "")
      Me.txtDocdate.Name = "txtDocdate"
      Me.Validator.SetRegularExpression(Me.txtDocdate, "")
      Me.Validator.SetRequired(Me.txtDocdate, True)
      Me.txtDocdate.Size = New System.Drawing.Size(115, 21)
      Me.txtDocdate.TabIndex = 3
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(362, 21)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpDocDate.TabIndex = 4
      Me.dtpDocDate.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(268, 22)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDate.TabIndex = 2
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(150, 48)
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(348, 22)
      Me.txtName.TabIndex = 6
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(94, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(48, 18)
      Me.lblName.TabIndex = 5
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(94, 20)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(48, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(150, 20)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(112, 22)
      Me.txtCode.TabIndex = 1
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'lblStatus
      '
      Me.lblStatus.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.DimGray
      Me.lblStatus.Location = New System.Drawing.Point(585, 21)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(159, 21)
      Me.lblStatus.TabIndex = 261
      Me.lblStatus.Text = "สถานะเอกสาร"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'LoanDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "LoanDetailView"
      Me.Size = New System.Drawing.Size(766, 251)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_entity As New Loan
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      UpdateEntityProperties()
      EventWiring()
    End Sub
#End Region

#Region "Method"

    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty

      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocdate.Validated, AddressOf Me.ChangeProperty

      AddHandler txtBankAccountCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAmount.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAmount.TextChanged, AddressOf Me.TextHandler

      AddHandler txtInterest.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtCCCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAccountCode.Validated, AddressOf Me.ChangeProperty
    End Sub

#End Region

#Region "SetTextLabel"
    Public Overrides Sub SetLabelText()
      If Not Me.m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblCode}")
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblName}")
      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblAmount}")
      Me.lblInterest.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblInterest}")
      Me.lblBankAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblBankAccount}")
      Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblBank}")
      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblCostCenter}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblDocDate}")
      Me.lblCurrencyUnit1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblCurrencyUnit1}")

      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.grbDetail}")
      Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblAccount}")
      Me.Validator.SetDisplayName(txtAccountCode, lblAccount.Text)
    End Sub
#End Region

#Region "IListDetail"

    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.StatusId = 0 _
      OrElse Me.m_entity.StatusId >= 3 _
      Then
        For Each ctl As Control In Me.grbDetail.Controls
          If TypeOf ctl Is TextBox Then
            CType(ctl, TextBox).ReadOnly = True
          Else
            ctl.Enabled = False
          End If
        Next
      Else
        For Each ctl As Control In Me.grbDetail.Controls
          If TypeOf ctl Is TextBox Then
            CType(ctl, TextBox).ReadOnly = False
          Else
            ctl.Enabled = True
          End If
        Next
      End If
    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      txtCode.Text = ""
      txtName.Text = ""
    End Sub
    
    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()

      If m_entity Is Nothing Then
        Return
      End If

      txtCode.Text = m_entity.Code
      txtName.Text = m_entity.Name

      dtpDocDate.Value = MinDateToNow(Me.m_entity.Date)
      txtDocdate.Text = MinDateToNull(Me.m_entity.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)

      For Each item As IdValuePair In cmbType.Items
        If item.Id = m_entity.TypeId Then
          cmbType.SelectedItem = item
          Exit For
        End If
      Next
      If Not Me.m_entity.CostCenter Is Nothing Then
        txtCCCode.Text = Me.m_entity.CostCenter.Code
        txtCCName.Text = Me.m_entity.CostCenter.Name
      End If
      If Not Me.m_entity.BankAccount Is Nothing Then
        txtBankAccountCode.Text = Me.m_entity.BankAccount.Code
        txtBankAccountName.Text = Me.m_entity.BankAccount.Name
        txtBankBranch.Text = Me.m_entity.BankAccount.BankBranchName
      End If
      If Not Me.m_entity.Account Is Nothing Then
        Me.txtAccountCode.Text = Me.m_entity.Account.Code
        Me.txtAccountName.Text = Me.m_entity.Account.Name
      End If
      txtInterest.Text = Me.m_entity.Interest
      lblStatus.Text = m_entity.StatusText
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtamount"
          Dim txt As String = Me.txtAmount.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.Amount = 0
          Else
            Try
              Me.m_entity.Amount = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.Amount = 0
            End Try
          End If
      End Select
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = Me.txtCode.Text
          dirtyFlag = True
        Case "txtcccode"
          dirtyFlag = CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "txtname"
          Me.m_entity.Name = Me.txtName.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_entity.Date.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocdate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.Date = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocdate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocdate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocdate.Text)
            If Not Me.m_entity.Date.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.Date = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDate.Value = Date.Now
            Me.m_entity.Date = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "txtamount"
          dirtyFlag = True
        Case "txtbankaccountcode"
          dirtyFlag = BankAccount.GetBankAccountBankBranch(txtBankAccountCode, txtBankAccountName, txtBankBranch, Me.m_entity.BankAccount)
        Case "txtaccountcode"
          dirtyFlag = Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)

        Case "txtinterest"
          dirtyFlag = True
          Me.m_entity.Interest = txtInterest.Text

        Case "cmbtype"
          If Not cmbType.SelectedItem Is Nothing AndAlso TypeOf cmbType.SelectedItem Is IdValuePair Then
            Me.m_entity.TypeId = CType(cmbType.SelectedItem, IdValuePair).Id
          End If
          dirtyFlag = True
      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, Loan)
        UpdateEntityProperties()
        EventWiring()
      End Set
    End Property

    Public Overrides Sub Initialize()
      CodeDescription.ListCodeDescriptionInComboBox(cmbType, "LoanType")
    End Sub

#End Region

#Region "Event of Button controls"
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
    ' Bank Account
    Private Sub btnBankAccountEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAccountEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New BankAccount)
    End Sub
    Private Sub btnBankAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAccountFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountDialog)
    End Sub
    Private Sub SetBankAccountDialog(ByVal e As ISimpleEntity)
      Me.txtBankAccountCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or BankAccount.GetBankAccountBankBranch(txtBankAccountCode, txtBankAccountName, txtBankBranch, Me.m_entity.BankAccount)
    End Sub

    'CostCenter
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
          Or CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region


#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

    Private Sub LoanDetailView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
      AddHandler Me.WorkbenchWindow.ViewContent.Saved, AddressOf EntitySaved
      AddHandler Me.WorkbenchWindow.ViewContent.Saving, AddressOf EntitySaving
    End Sub

    Private Sub EntitySaving(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

    End Sub

    Private Sub chkClosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClosed.CheckedChanged
      If Not m_isInitialized Then
        Return
      End If
      Me.m_entity.Closed = Me.chkClosed.Checked
      If Me.m_entity.Closed Then
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.chkClosedCancel}")
        m_entity.StatusId = 5
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.chkClosed}")
        If m_entity.IsReferenced Then m_entity.StatusId = 3 Else m_entity.StatusId = 2
      End If
    End Sub
  End Class

End Namespace
