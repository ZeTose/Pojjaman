Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RefundLoanDetailView
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
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDocdate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtBankAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtBankBranch As System.Windows.Forms.TextBox
    Friend WithEvents lblBank As System.Windows.Forms.Label
    Friend WithEvents lblBankAccount As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyUnit4 As System.Windows.Forms.Label
    Friend WithEvents txtInterest As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
    Friend WithEvents lblInterest As System.Windows.Forms.Label
    Friend WithEvents txtCCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCCName As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrencyUnit2 As System.Windows.Forms.Label
    Friend WithEvents txtOtherCharge As System.Windows.Forms.TextBox
    Friend WithEvents lblOtherCharge As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyUnit3 As System.Windows.Forms.Label
    Friend WithEvents txtRefund As System.Windows.Forms.TextBox
    Friend WithEvents lblRefund As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyUnit1 As System.Windows.Forms.Label
    Friend WithEvents btnWithdrawLoanFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtWithdrawLoanCode As System.Windows.Forms.TextBox
    Friend WithEvents txtWithdrawLoanName As System.Windows.Forms.TextBox
    Friend WithEvents lblWithdrawLoan As System.Windows.Forms.Label
    Friend WithEvents grbLoan As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtLoanCode As System.Windows.Forms.TextBox
    Friend WithEvents txtLoanName As System.Windows.Forms.TextBox
    Friend WithEvents lblLoan As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RefundLoanDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbLoan = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtLoanCode = New System.Windows.Forms.TextBox()
      Me.txtLoanName = New System.Windows.Forms.TextBox()
      Me.lblLoan = New System.Windows.Forms.Label()
      Me.lblBankAccount = New System.Windows.Forms.Label()
      Me.lblBank = New System.Windows.Forms.Label()
      Me.txtBankBranch = New System.Windows.Forms.TextBox()
      Me.txtBankAccountName = New System.Windows.Forms.TextBox()
      Me.txtBankAccountCode = New System.Windows.Forms.TextBox()
      Me.txtCCName = New System.Windows.Forms.TextBox()
      Me.txtAccountName = New System.Windows.Forms.TextBox()
      Me.txtAccountCode = New System.Windows.Forms.TextBox()
      Me.txtCCCode = New System.Windows.Forms.TextBox()
      Me.lblAccount = New System.Windows.Forms.Label()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.btnWithdrawLoanFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtWithdrawLoanCode = New System.Windows.Forms.TextBox()
      Me.txtWithdrawLoanName = New System.Windows.Forms.TextBox()
      Me.lblWithdrawLoan = New System.Windows.Forms.Label()
      Me.lblCurrencyUnit2 = New System.Windows.Forms.Label()
      Me.txtOtherCharge = New System.Windows.Forms.TextBox()
      Me.lblOtherCharge = New System.Windows.Forms.Label()
      Me.lblCurrencyUnit3 = New System.Windows.Forms.Label()
      Me.txtRefund = New System.Windows.Forms.TextBox()
      Me.lblRefund = New System.Windows.Forms.Label()
      Me.lblCurrencyUnit1 = New System.Windows.Forms.Label()
      Me.txtInterest = New Longkong.Pojjaman.Gui.Components.MultiLineTextBox()
      Me.lblInterest = New System.Windows.Forms.Label()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.lblCurrencyUnit4 = New System.Windows.Forms.Label()
      Me.txtDocdate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.grbDetail.SuspendLayout()
      Me.grbLoan.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.grbLoan)
      Me.grbDetail.Controls.Add(Me.btnWithdrawLoanFind)
      Me.grbDetail.Controls.Add(Me.txtWithdrawLoanCode)
      Me.grbDetail.Controls.Add(Me.txtWithdrawLoanName)
      Me.grbDetail.Controls.Add(Me.lblWithdrawLoan)
      Me.grbDetail.Controls.Add(Me.lblCurrencyUnit2)
      Me.grbDetail.Controls.Add(Me.txtOtherCharge)
      Me.grbDetail.Controls.Add(Me.lblOtherCharge)
      Me.grbDetail.Controls.Add(Me.lblCurrencyUnit3)
      Me.grbDetail.Controls.Add(Me.txtRefund)
      Me.grbDetail.Controls.Add(Me.lblRefund)
      Me.grbDetail.Controls.Add(Me.lblCurrencyUnit1)
      Me.grbDetail.Controls.Add(Me.txtInterest)
      Me.grbDetail.Controls.Add(Me.lblInterest)
      Me.grbDetail.Controls.Add(Me.txtAmount)
      Me.grbDetail.Controls.Add(Me.lblAmount)
      Me.grbDetail.Controls.Add(Me.lblCurrencyUnit4)
      Me.grbDetail.Controls.Add(Me.txtDocdate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(665, 398)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลธนาคาร : "
      '
      'grbLoan
      '
      Me.grbLoan.Controls.Add(Me.txtLoanCode)
      Me.grbLoan.Controls.Add(Me.txtLoanName)
      Me.grbLoan.Controls.Add(Me.lblLoan)
      Me.grbLoan.Controls.Add(Me.lblBankAccount)
      Me.grbLoan.Controls.Add(Me.lblBank)
      Me.grbLoan.Controls.Add(Me.txtBankBranch)
      Me.grbLoan.Controls.Add(Me.txtBankAccountName)
      Me.grbLoan.Controls.Add(Me.txtBankAccountCode)
      Me.grbLoan.Controls.Add(Me.txtCCName)
      Me.grbLoan.Controls.Add(Me.txtAccountName)
      Me.grbLoan.Controls.Add(Me.txtAccountCode)
      Me.grbLoan.Controls.Add(Me.txtCCCode)
      Me.grbLoan.Controls.Add(Me.lblAccount)
      Me.grbLoan.Controls.Add(Me.lblCostCenter)
      Me.grbLoan.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbLoan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbLoan.ForeColor = System.Drawing.Color.Blue
      Me.grbLoan.Location = New System.Drawing.Point(9, 192)
      Me.grbLoan.Name = "grbLoan"
      Me.grbLoan.Size = New System.Drawing.Size(560, 175)
      Me.grbLoan.TabIndex = 271
      Me.grbLoan.TabStop = False
      Me.grbLoan.Text = "ข้อมูลวงเงิน: "
      '
      'txtLoanCode
      '
      Me.Validator.SetDataType(Me.txtLoanCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLoanCode, "")
      Me.txtLoanCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLoanCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLoanCode, System.Drawing.Color.Empty)
      Me.txtLoanCode.Location = New System.Drawing.Point(143, 25)
      Me.txtLoanCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtLoanCode, "")
      Me.txtLoanCode.Name = "txtLoanCode"
      Me.txtLoanCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtLoanCode, "")
      Me.Validator.SetRequired(Me.txtLoanCode, False)
      Me.txtLoanCode.Size = New System.Drawing.Size(114, 21)
      Me.txtLoanCode.TabIndex = 271
      '
      'txtLoanName
      '
      Me.Validator.SetDataType(Me.txtLoanName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLoanName, "")
      Me.txtLoanName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLoanName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLoanName, System.Drawing.Color.Empty)
      Me.txtLoanName.Location = New System.Drawing.Point(257, 25)
      Me.txtLoanName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtLoanName, "")
      Me.txtLoanName.Name = "txtLoanName"
      Me.txtLoanName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtLoanName, "")
      Me.Validator.SetRequired(Me.txtLoanName, False)
      Me.txtLoanName.Size = New System.Drawing.Size(277, 21)
      Me.txtLoanName.TabIndex = 272
      Me.txtLoanName.TabStop = False
      '
      'lblLoan
      '
      Me.lblLoan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLoan.ForeColor = System.Drawing.Color.Black
      Me.lblLoan.Location = New System.Drawing.Point(22, 25)
      Me.lblLoan.Name = "lblLoan"
      Me.lblLoan.Size = New System.Drawing.Size(113, 18)
      Me.lblLoan.TabIndex = 270
      Me.lblLoan.Text = "วงเงินกู้:"
      Me.lblLoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBankAccount
      '
      Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
      Me.lblBankAccount.Location = New System.Drawing.Point(21, 52)
      Me.lblBankAccount.Name = "lblBankAccount"
      Me.lblBankAccount.Size = New System.Drawing.Size(114, 18)
      Me.lblBankAccount.TabIndex = 13
      Me.lblBankAccount.Text = "สมุดเงินฝากธนาคาร:"
      Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBank
      '
      Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBank.ForeColor = System.Drawing.Color.Black
      Me.lblBank.Location = New System.Drawing.Point(21, 76)
      Me.lblBank.Name = "lblBank"
      Me.lblBank.Size = New System.Drawing.Size(114, 18)
      Me.lblBank.TabIndex = 18
      Me.lblBank.Text = "ธนาคาร/สาขา:"
      Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBankBranch
      '
      Me.Validator.SetDataType(Me.txtBankBranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankBranch, "")
      Me.txtBankBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
      Me.txtBankBranch.Location = New System.Drawing.Point(143, 76)
      Me.txtBankBranch.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtBankBranch, "")
      Me.txtBankBranch.Name = "txtBankBranch"
      Me.txtBankBranch.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankBranch, "")
      Me.Validator.SetRequired(Me.txtBankBranch, False)
      Me.txtBankBranch.Size = New System.Drawing.Size(391, 21)
      Me.txtBankBranch.TabIndex = 19
      Me.txtBankBranch.TabStop = False
      '
      'txtBankAccountName
      '
      Me.Validator.SetDataType(Me.txtBankAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAccountName, "")
      Me.txtBankAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.txtBankAccountName.Location = New System.Drawing.Point(257, 52)
      Me.txtBankAccountName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtBankAccountName, "")
      Me.txtBankAccountName.Name = "txtBankAccountName"
      Me.txtBankAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankAccountName, "")
      Me.Validator.SetRequired(Me.txtBankAccountName, False)
      Me.txtBankAccountName.Size = New System.Drawing.Size(277, 21)
      Me.txtBankAccountName.TabIndex = 15
      Me.txtBankAccountName.TabStop = False
      '
      'txtBankAccountCode
      '
      Me.Validator.SetDataType(Me.txtBankAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAccountCode, "")
      Me.txtBankAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
      Me.txtBankAccountCode.Location = New System.Drawing.Point(143, 52)
      Me.txtBankAccountCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtBankAccountCode, "")
      Me.txtBankAccountCode.Name = "txtBankAccountCode"
      Me.txtBankAccountCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankAccountCode, "")
      Me.Validator.SetRequired(Me.txtBankAccountCode, False)
      Me.txtBankAccountCode.Size = New System.Drawing.Size(115, 21)
      Me.txtBankAccountCode.TabIndex = 14
      '
      'txtCCName
      '
      Me.Validator.SetDataType(Me.txtCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCName, "")
      Me.txtCCName.Enabled = False
      Me.txtCCName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCCName, System.Drawing.Color.Empty)
      Me.txtCCName.Location = New System.Drawing.Point(257, 101)
      Me.Validator.SetMinValue(Me.txtCCName, "")
      Me.txtCCName.Name = "txtCCName"
      Me.txtCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCCName, "")
      Me.Validator.SetRequired(Me.txtCCName, False)
      Me.txtCCName.Size = New System.Drawing.Size(277, 21)
      Me.txtCCName.TabIndex = 22
      Me.txtCCName.TabStop = False
      '
      'txtAccountName
      '
      Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountName, "")
      Me.txtAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.txtAccountName.Location = New System.Drawing.Point(257, 126)
      Me.Validator.SetMinValue(Me.txtAccountName, "")
      Me.txtAccountName.Name = "txtAccountName"
      Me.txtAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountName, "")
      Me.Validator.SetRequired(Me.txtAccountName, False)
      Me.txtAccountName.Size = New System.Drawing.Size(277, 21)
      Me.txtAccountName.TabIndex = 256
      Me.txtAccountName.TabStop = False
      '
      'txtAccountCode
      '
      Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCode, "")
      Me.txtAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.txtAccountCode.Location = New System.Drawing.Point(143, 126)
      Me.txtAccountCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtAccountCode, "")
      Me.txtAccountCode.Name = "txtAccountCode"
      Me.txtAccountCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccountCode, False)
      Me.txtAccountCode.Size = New System.Drawing.Size(116, 21)
      Me.txtAccountCode.TabIndex = 255
      '
      'txtCCCode
      '
      Me.Validator.SetDataType(Me.txtCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCode, "")
      Me.txtCCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
      Me.txtCCCode.Location = New System.Drawing.Point(143, 101)
      Me.Validator.SetMinValue(Me.txtCCCode, "")
      Me.txtCCCode.Name = "txtCCCode"
      Me.txtCCCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCCCode, "")
      Me.Validator.SetRequired(Me.txtCCCode, False)
      Me.txtCCCode.Size = New System.Drawing.Size(115, 21)
      Me.txtCCCode.TabIndex = 21
      '
      'lblAccount
      '
      Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccount.ForeColor = System.Drawing.Color.Black
      Me.lblAccount.Location = New System.Drawing.Point(30, 126)
      Me.lblAccount.Name = "lblAccount"
      Me.lblAccount.Size = New System.Drawing.Size(107, 18)
      Me.lblAccount.TabIndex = 257
      Me.lblAccount.Text = "บัญชี:"
      Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostCenter.Location = New System.Drawing.Point(23, 102)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(114, 18)
      Me.lblCostCenter.TabIndex = 20
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnWithdrawLoanFind
      '
      Me.btnWithdrawLoanFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnWithdrawLoanFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnWithdrawLoanFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnWithdrawLoanFind.Location = New System.Drawing.Point(497, 41)
      Me.btnWithdrawLoanFind.Name = "btnWithdrawLoanFind"
      Me.btnWithdrawLoanFind.Size = New System.Drawing.Size(24, 23)
      Me.btnWithdrawLoanFind.TabIndex = 270
      Me.btnWithdrawLoanFind.TabStop = False
      Me.btnWithdrawLoanFind.ThemedImage = CType(resources.GetObject("btnWithdrawLoanFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtWithdrawLoanCode
      '
      Me.Validator.SetDataType(Me.txtWithdrawLoanCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawLoanCode, "")
      Me.txtWithdrawLoanCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawLoanCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawLoanCode, System.Drawing.Color.Empty)
      Me.txtWithdrawLoanCode.Location = New System.Drawing.Point(150, 43)
      Me.txtWithdrawLoanCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtWithdrawLoanCode, "")
      Me.txtWithdrawLoanCode.Name = "txtWithdrawLoanCode"
      Me.Validator.SetRegularExpression(Me.txtWithdrawLoanCode, "")
      Me.Validator.SetRequired(Me.txtWithdrawLoanCode, True)
      Me.txtWithdrawLoanCode.Size = New System.Drawing.Size(137, 21)
      Me.txtWithdrawLoanCode.TabIndex = 268
      '
      'txtWithdrawLoanName
      '
      Me.Validator.SetDataType(Me.txtWithdrawLoanName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWithdrawLoanName, "")
      Me.txtWithdrawLoanName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtWithdrawLoanName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWithdrawLoanName, System.Drawing.Color.Empty)
      Me.txtWithdrawLoanName.Location = New System.Drawing.Point(287, 43)
      Me.txtWithdrawLoanName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtWithdrawLoanName, "")
      Me.txtWithdrawLoanName.Name = "txtWithdrawLoanName"
      Me.txtWithdrawLoanName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWithdrawLoanName, "")
      Me.Validator.SetRequired(Me.txtWithdrawLoanName, False)
      Me.txtWithdrawLoanName.Size = New System.Drawing.Size(208, 21)
      Me.txtWithdrawLoanName.TabIndex = 269
      Me.txtWithdrawLoanName.TabStop = False
      '
      'lblWithdrawLoan
      '
      Me.lblWithdrawLoan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWithdrawLoan.ForeColor = System.Drawing.Color.Black
      Me.lblWithdrawLoan.Location = New System.Drawing.Point(29, 43)
      Me.lblWithdrawLoan.Name = "lblWithdrawLoan"
      Me.lblWithdrawLoan.Size = New System.Drawing.Size(113, 18)
      Me.lblWithdrawLoan.TabIndex = 267
      Me.lblWithdrawLoan.Text = "ตั๋วเงินกู้:"
      Me.lblWithdrawLoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrencyUnit2
      '
      Me.lblCurrencyUnit2.AutoSize = True
      Me.lblCurrencyUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit2.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit2.Location = New System.Drawing.Point(294, 121)
      Me.lblCurrencyUnit2.Name = "lblCurrencyUnit2"
      Me.lblCurrencyUnit2.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrencyUnit2.TabIndex = 266
      Me.lblCurrencyUnit2.Text = "บาท"
      Me.lblCurrencyUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtOtherCharge
      '
      Me.Validator.SetDataType(Me.txtOtherCharge, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtOtherCharge, "")
      Me.txtOtherCharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtOtherCharge, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtOtherCharge, System.Drawing.Color.Empty)
      Me.txtOtherCharge.Location = New System.Drawing.Point(150, 140)
      Me.txtOtherCharge.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtOtherCharge, "")
      Me.txtOtherCharge.Name = "txtOtherCharge"
      Me.Validator.SetRegularExpression(Me.txtOtherCharge, "")
      Me.Validator.SetRequired(Me.txtOtherCharge, True)
      Me.txtOtherCharge.Size = New System.Drawing.Size(136, 21)
      Me.txtOtherCharge.TabIndex = 264
      Me.txtOtherCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblOtherCharge
      '
      Me.lblOtherCharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOtherCharge.ForeColor = System.Drawing.Color.Black
      Me.lblOtherCharge.Location = New System.Drawing.Point(6, 141)
      Me.lblOtherCharge.Name = "lblOtherCharge"
      Me.lblOtherCharge.Size = New System.Drawing.Size(136, 18)
      Me.lblOtherCharge.TabIndex = 263
      Me.lblOtherCharge.Text = "หักค่าใช้จ่ายอื่น:"
      Me.lblOtherCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrencyUnit3
      '
      Me.lblCurrencyUnit3.AutoSize = True
      Me.lblCurrencyUnit3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit3.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit3.Location = New System.Drawing.Point(294, 144)
      Me.lblCurrencyUnit3.Name = "lblCurrencyUnit3"
      Me.lblCurrencyUnit3.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrencyUnit3.TabIndex = 265
      Me.lblCurrencyUnit3.Text = "บาท"
      Me.lblCurrencyUnit3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtRefund
      '
      Me.Validator.SetDataType(Me.txtRefund, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtRefund, "")
      Me.txtRefund.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRefund, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRefund, System.Drawing.Color.Empty)
      Me.txtRefund.Location = New System.Drawing.Point(150, 94)
      Me.txtRefund.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtRefund, "")
      Me.txtRefund.Name = "txtRefund"
      Me.Validator.SetRegularExpression(Me.txtRefund, "")
      Me.Validator.SetRequired(Me.txtRefund, True)
      Me.txtRefund.Size = New System.Drawing.Size(136, 21)
      Me.txtRefund.TabIndex = 261
      Me.txtRefund.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRefund
      '
      Me.lblRefund.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefund.ForeColor = System.Drawing.Color.Black
      Me.lblRefund.Location = New System.Drawing.Point(6, 95)
      Me.lblRefund.Name = "lblRefund"
      Me.lblRefund.Size = New System.Drawing.Size(136, 18)
      Me.lblRefund.TabIndex = 260
      Me.lblRefund.Text = "มูลค่าเงินต้น:"
      Me.lblRefund.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrencyUnit1
      '
      Me.lblCurrencyUnit1.AutoSize = True
      Me.lblCurrencyUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit1.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit1.Location = New System.Drawing.Point(294, 98)
      Me.lblCurrencyUnit1.Name = "lblCurrencyUnit1"
      Me.lblCurrencyUnit1.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrencyUnit1.TabIndex = 262
      Me.lblCurrencyUnit1.Text = "บาท"
      Me.lblCurrencyUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtInterest
      '
      Me.Validator.SetDataType(Me.txtInterest, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtInterest, "")
      Me.txtInterest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtInterest, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInterest, System.Drawing.Color.Empty)
      Me.txtInterest.Location = New System.Drawing.Point(150, 117)
      Me.txtInterest.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtInterest, "")
      Me.txtInterest.Name = "txtInterest"
      Me.Validator.SetRegularExpression(Me.txtInterest, "")
      Me.Validator.SetRequired(Me.txtInterest, True)
      Me.txtInterest.Size = New System.Drawing.Size(136, 21)
      Me.txtInterest.TabIndex = 12
      Me.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblInterest
      '
      Me.lblInterest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInterest.ForeColor = System.Drawing.Color.Black
      Me.lblInterest.Location = New System.Drawing.Point(6, 118)
      Me.lblInterest.Name = "lblInterest"
      Me.lblInterest.Size = New System.Drawing.Size(136, 18)
      Me.lblInterest.TabIndex = 11
      Me.lblInterest.Text = "ดอกเบี้ย:"
      Me.lblInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAmount
      '
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(150, 163)
      Me.txtAmount.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.txtAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(136, 22)
      Me.txtAmount.TabIndex = 8
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(6, 164)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(136, 18)
      Me.lblAmount.TabIndex = 7
      Me.lblAmount.Text = "รวมจ่าย:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrencyUnit4
      '
      Me.lblCurrencyUnit4.AutoSize = True
      Me.lblCurrencyUnit4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit4.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit4.Location = New System.Drawing.Point(294, 167)
      Me.lblCurrencyUnit4.Name = "lblCurrencyUnit4"
      Me.lblCurrencyUnit4.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrencyUnit4.TabIndex = 9
      Me.lblCurrencyUnit4.Text = "บาท"
      Me.lblCurrencyUnit4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtDocdate
      '
      Me.Validator.SetDataType(Me.txtDocdate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocdate, "")
      Me.txtDocdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDocdate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocdate, System.Drawing.Color.Empty)
      Me.txtDocdate.Location = New System.Drawing.Point(359, 22)
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
      Me.dtpDocDate.Location = New System.Drawing.Point(359, 22)
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
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(150, 66)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(345, 22)
      Me.txtNote.TabIndex = 6
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(47, 66)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(95, 18)
      Me.lblNote.TabIndex = 5
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.lblStatus.Location = New System.Drawing.Point(499, 20)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(159, 21)
      Me.lblStatus.TabIndex = 263
      Me.lblStatus.Text = "สถานะเอกสาร"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'RefundLoanDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "RefundLoanDetailView"
      Me.Size = New System.Drawing.Size(688, 414)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbLoan.ResumeLayout(False)
      Me.grbLoan.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_entity As New RefundLoan
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
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocdate.Validated, AddressOf Me.ChangeProperty



      AddHandler txtAmount.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAmount.TextChanged, AddressOf Me.TextHandler

      AddHandler txtRefund.Validated, AddressOf Me.ChangeProperty
      AddHandler txtInterest.Validated, AddressOf Me.ChangeProperty
      AddHandler txtOtherCharge.Validated, AddressOf Me.ChangeProperty



      'AddHandler txtCCCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtBankAccountCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtAccountCode.Validated, AddressOf Me.ChangeProperty
    End Sub

#End Region
#Region "SetTextLabel"
    Public Overrides Sub SetLabelText()
      If Not Me.m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanDetailView.lblCode}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.lblWithdrawLoan.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RefundLoanDetailView.lblWithdrawLoan}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      
      Me.lblRefund.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RefundLoanDetailView.lblRefund}")
      Me.lblInterest.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RefundLoanDetailView.lblInterest}")
      Me.lblOtherCharge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RefundLoanDetailView.lblOtherCharge}")
      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RefundLoanDetailView.lblAmount}")

      Me.lblLoan.Text = Me.StringParserService.Parse("${res:MainMenu.CashBankMenu.Loan}")
      Me.lblBankAccount.Text = Me.StringParserService.Parse("${res:Global.Entity.23}")
      Me.lblBank.Text = Me.StringParserService.Parse("${res:Global.Entity.16}")
      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Global.CostCenterText}")

      Me.lblCurrencyUnit1.Text = Me.StringParserService.Parse("${res:Global.CurrencyText}")
      Me.lblCurrencyUnit2.Text = Me.StringParserService.Parse("${res:Global.CurrencyText}")
      Me.lblCurrencyUnit3.Text = Me.StringParserService.Parse("${res:Global.CurrencyText}")
      Me.lblCurrencyUnit4.Text = Me.StringParserService.Parse("${res:Global.CurrencyText}")

      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RefundLoanDetailView.grbDetail}")
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
      txtNote.Text = ""
    End Sub

    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()

      If m_entity Is Nothing Then
        Return
      End If

      txtCode.Text = m_entity.Code
      txtNote.Text = m_entity.Note
      txtWithdrawLoanCode.Text = m_entity.WithdrawLoan.Code
      txtWithdrawLoanName.Text = m_entity.WithdrawLoan.Note

      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
      txtDocdate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      txtRefund.Text = Configuration.FormatToString(Me.m_entity.Refund, DigitConfig.Price)
      txtInterest.Text = Configuration.FormatToString(Me.m_entity.Interest, DigitConfig.Price)
      txtOtherCharge.Text = Configuration.FormatToString(Me.m_entity.OtherCharge, DigitConfig.Price)
      txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
      lblStatus.Text = m_entity.StatusText
      UpdateWLInfo()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateWLInfo()
      If Not Me.m_entity.Loan Is Nothing Then
        txtLoanCode.Text = Me.m_entity.WithdrawLoan.Loan.Code
        txtLoanName.Text = Me.m_entity.WithdrawLoan.Loan.Name
      End If
      If Not Me.m_entity.CostCenter Is Nothing Then
        txtCCCode.Text = Me.m_entity.WithdrawLoan.Loan.CostCenter.Code
        txtCCName.Text = Me.m_entity.WithdrawLoan.Loan.CostCenter.Name
      End If
      If Not Me.m_entity.BankAccount Is Nothing Then
        txtBankAccountCode.Text = Me.m_entity.WithdrawLoan.Loan.BankAccount.Code
        txtBankAccountName.Text = Me.m_entity.WithdrawLoan.Loan.BankAccount.Name
        txtBankBranch.Text = Me.m_entity.WithdrawLoan.Loan.BankAccount.BankBranchName
      End If
      If Not Me.m_entity.Account Is Nothing Then
        Me.txtAccountCode.Text = Me.m_entity.WithdrawLoan.Loan.Account.Code
        Me.txtAccountName.Text = Me.m_entity.WithdrawLoan.Loan.Account.Name
      End If
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
        Case "txtWLCode"
          dirtyFlag = WithdrawLoan.GetWithdrawLoan(txtWithdrawLoanCode, txtWithdrawLoanName, Me.m_entity.WithdrawLoan)
        Case "txtnote"
          Me.m_entity.Note = Me.txtNote.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocdate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocdate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocdate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocdate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtrefund"
          m_entity.Refund = CDec(Me.txtRefund.Text)
          Me.txtRefund.Text = Configuration.FormatToString(Me.m_entity.Refund, DigitConfig.Price)
          m_entity.Amount = m_entity.Refund + m_entity.Interest + m_entity.OtherCharge
          Me.txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
          dirtyFlag = True

        Case "txtinterest"
          m_entity.Interest = CDec(Me.txtInterest.Text)
          Me.txtInterest.Text = Configuration.FormatToString(Me.m_entity.Interest, DigitConfig.Price)
          m_entity.Amount = m_entity.Refund + m_entity.Interest + m_entity.OtherCharge
          Me.txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
          dirtyFlag = True
        Case "othercharge"
          m_entity.OtherCharge = CDec(Me.txtOtherCharge.Text)
          Me.txtOtherCharge.Text = Configuration.FormatToString(Me.m_entity.OtherCharge, DigitConfig.Price)
          m_entity.Amount = m_entity.Refund + m_entity.Interest + m_entity.OtherCharge
          dirtyFlag = True
        Case "txtamount"
          dirtyFlag = True
        Case "txtbankaccountcode"
          dirtyFlag = BankAccount.GetBankAccountBankBranch(txtBankAccountCode, txtBankAccountName, txtBankBranch, Me.m_entity.BankAccount)
        Case "txtaccountcode"
          dirtyFlag = Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)
        Case "txtcccode"
          dirtyFlag = CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)



      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, RefundLoan)
        UpdateEntityProperties()
        EventWiring()
      End Set
    End Property

#End Region

#Region "Event of Button controls"
    
    'WL
    Private Sub btnWithdrawLoanFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdrawLoanFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New WithdrawLoan, AddressOf SetWLDialog)
      UpdateWLInfo()
    End Sub
    Private Sub SetWLDialog(ByVal e As ISimpleEntity)
      Me.txtWithdrawLoanCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty _
          Or WithdrawLoan.GetWithdrawLoan(txtWithdrawLoanCode, txtWithdrawLoanName, Me.m_entity.WithdrawLoan)
      UpdateWLInfo()
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



  End Class

End Namespace
