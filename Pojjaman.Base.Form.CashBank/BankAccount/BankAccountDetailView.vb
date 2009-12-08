Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class BankAccountDetailView
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
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblAccount As System.Windows.Forms.Label
        Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
        Friend WithEvents lblBank As System.Windows.Forms.Label
        Friend WithEvents lblBankBranch As System.Windows.Forms.Label
        Friend WithEvents cmbAccountStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblAccountStatus As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
        Friend WithEvents txtBankBranchCode As System.Windows.Forms.TextBox
        Friend WithEvents txtBankBranchName As System.Windows.Forms.TextBox
        Friend WithEvents txtBankName As System.Windows.Forms.TextBox
        Friend WithEvents btnBankBranchEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnBankBranchFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents cmbType As System.Windows.Forms.ComboBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
        Friend WithEvents lblBankCode As System.Windows.Forms.Label
        Friend WithEvents txtBalance As System.Windows.Forms.TextBox
        Friend WithEvents lblBalance As System.Windows.Forms.Label
        Friend WithEvents lblCurrency As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BankAccountDetailView))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.btnBankBranchEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnBankBranchFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblAccountStatus = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblAccount = New System.Windows.Forms.Label
            Me.txtAccountCode = New System.Windows.Forms.TextBox
            Me.txtAccountName = New System.Windows.Forms.TextBox
            Me.txtBankBranchCode = New System.Windows.Forms.TextBox
            Me.lblBank = New System.Windows.Forms.Label
            Me.txtBankBranchName = New System.Windows.Forms.TextBox
            Me.lblBankBranch = New System.Windows.Forms.Label
            Me.txtBankName = New System.Windows.Forms.TextBox
            Me.lblType = New System.Windows.Forms.Label
            Me.cmbType = New System.Windows.Forms.ComboBox
            Me.txtBankCode = New System.Windows.Forms.TextBox
            Me.lblBankCode = New System.Windows.Forms.Label
            Me.cmbAccountStatus = New System.Windows.Forms.ComboBox
            Me.txtBalance = New System.Windows.Forms.TextBox
            Me.lblBalance = New System.Windows.Forms.Label
            Me.lblCurrency = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.chkAutorun)
            Me.grbDetail.Controls.Add(Me.btnBankBranchEdit)
            Me.grbDetail.Controls.Add(Me.btnBankBranchFind)
            Me.grbDetail.Controls.Add(Me.btnAccountEdit)
            Me.grbDetail.Controls.Add(Me.btnAccountFind)
            Me.grbDetail.Controls.Add(Me.lblAccountStatus)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblAccount)
            Me.grbDetail.Controls.Add(Me.txtAccountCode)
            Me.grbDetail.Controls.Add(Me.txtAccountName)
            Me.grbDetail.Controls.Add(Me.txtBankBranchCode)
            Me.grbDetail.Controls.Add(Me.lblBank)
            Me.grbDetail.Controls.Add(Me.txtBankBranchName)
            Me.grbDetail.Controls.Add(Me.lblBankBranch)
            Me.grbDetail.Controls.Add(Me.txtBankName)
            Me.grbDetail.Controls.Add(Me.lblType)
            Me.grbDetail.Controls.Add(Me.cmbType)
            Me.grbDetail.Controls.Add(Me.txtBankCode)
            Me.grbDetail.Controls.Add(Me.lblBankCode)
            Me.grbDetail.Controls.Add(Me.cmbAccountStatus)
            Me.grbDetail.Controls.Add(Me.txtBalance)
            Me.grbDetail.Controls.Add(Me.lblBalance)
            Me.grbDetail.Controls.Add(Me.lblCurrency)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.ForeColor = System.Drawing.Color.Blue
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(728, 224)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลบัญชีธนาคาร : "
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(312, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 327
            Me.chkAutorun.TabStop = False
            '
            'btnBankBranchEdit
            '
            Me.btnBankBranchEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankBranchEdit.Image = CType(resources.GetObject("btnBankBranchEdit.Image"), System.Drawing.Image)
            Me.btnBankBranchEdit.Location = New System.Drawing.Point(560, 144)
            Me.btnBankBranchEdit.Name = "btnBankBranchEdit"
            Me.btnBankBranchEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnBankBranchEdit.TabIndex = 256
            Me.btnBankBranchEdit.TabStop = False
            Me.btnBankBranchEdit.ThemedImage = CType(resources.GetObject("btnBankBranchEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnBankBranchFind
            '
            Me.btnBankBranchFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankBranchFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBankBranchFind.Image = CType(resources.GetObject("btnBankBranchFind.Image"), System.Drawing.Image)
            Me.btnBankBranchFind.Location = New System.Drawing.Point(536, 144)
            Me.btnBankBranchFind.Name = "btnBankBranchFind"
            Me.btnBankBranchFind.Size = New System.Drawing.Size(24, 23)
            Me.btnBankBranchFind.TabIndex = 255
            Me.btnBankBranchFind.TabStop = False
            Me.btnBankBranchFind.ThemedImage = CType(resources.GetObject("btnBankBranchFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit
            '
            Me.btnAccountEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit.Image = CType(resources.GetObject("btnAccountEdit.Image"), System.Drawing.Image)
            Me.btnAccountEdit.Location = New System.Drawing.Point(560, 120)
            Me.btnAccountEdit.Name = "btnAccountEdit"
            Me.btnAccountEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit.TabIndex = 254
            Me.btnAccountEdit.TabStop = False
            Me.btnAccountEdit.ThemedImage = CType(resources.GetObject("btnAccountEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind
            '
            Me.btnAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind.Image = CType(resources.GetObject("btnAccountFind.Image"), System.Drawing.Image)
            Me.btnAccountFind.Location = New System.Drawing.Point(536, 120)
            Me.btnAccountFind.Name = "btnAccountFind"
            Me.btnAccountFind.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind.TabIndex = 253
            Me.btnAccountFind.TabStop = False
            Me.btnAccountFind.ThemedImage = CType(resources.GetObject("btnAccountFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblAccountStatus
            '
            Me.lblAccountStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountStatus.ForeColor = System.Drawing.Color.Black
            Me.lblAccountStatus.Location = New System.Drawing.Point(336, 24)
            Me.lblAccountStatus.Name = "lblAccountStatus"
            Me.lblAccountStatus.Size = New System.Drawing.Size(128, 18)
            Me.lblAccountStatus.TabIndex = 200
            Me.lblAccountStatus.Text = "สถานะสุมดบัญชี:"
            Me.lblAccountStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(168, 72)
            Me.txtName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(416, 21)
            Me.txtName.TabIndex = 4
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 72)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(152, 18)
            Me.lblName.TabIndex = 11
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(152, 18)
            Me.lblCode.TabIndex = 7
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(168, 24)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(144, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'lblAccount
            '
            Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccount.ForeColor = System.Drawing.Color.Black
            Me.lblAccount.Location = New System.Drawing.Point(8, 120)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.Size = New System.Drawing.Size(152, 18)
            Me.lblAccount.TabIndex = 11
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
            Me.txtAccountCode.Location = New System.Drawing.Point(168, 120)
            Me.txtAccountCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtAccountCode, "")
            Me.Validator.SetMinValue(Me.txtAccountCode, "")
            Me.txtAccountCode.Name = "txtAccountCode"
            Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
            Me.Validator.SetRequired(Me.txtAccountCode, True)
            Me.txtAccountCode.Size = New System.Drawing.Size(144, 21)
            Me.txtAccountCode.TabIndex = 6
            Me.txtAccountCode.Text = ""
            '
            'txtAccountName
            '
            Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName, "")
            Me.txtAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.txtAccountName.Location = New System.Drawing.Point(312, 120)
            Me.Validator.SetMaxValue(Me.txtAccountName, "")
            Me.Validator.SetMinValue(Me.txtAccountName, "")
            Me.txtAccountName.Name = "txtAccountName"
            Me.txtAccountName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName, "")
            Me.Validator.SetRequired(Me.txtAccountName, False)
            Me.txtAccountName.Size = New System.Drawing.Size(224, 21)
            Me.txtAccountName.TabIndex = 7
            Me.txtAccountName.TabStop = False
            Me.txtAccountName.Text = ""
            '
            'txtBankBranchCode
            '
            Me.Validator.SetDataType(Me.txtBankBranchCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankBranchCode, "")
            Me.txtBankBranchCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankBranchCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankBranchCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankBranchCode, System.Drawing.Color.Empty)
            Me.txtBankBranchCode.Location = New System.Drawing.Point(168, 144)
            Me.txtBankBranchCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtBankBranchCode, "")
            Me.Validator.SetMinValue(Me.txtBankBranchCode, "")
            Me.txtBankBranchCode.Name = "txtBankBranchCode"
            Me.Validator.SetRegularExpression(Me.txtBankBranchCode, "")
            Me.Validator.SetRequired(Me.txtBankBranchCode, True)
            Me.txtBankBranchCode.Size = New System.Drawing.Size(144, 21)
            Me.txtBankBranchCode.TabIndex = 8
            Me.txtBankBranchCode.Text = ""
            '
            'lblBank
            '
            Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBank.ForeColor = System.Drawing.Color.Black
            Me.lblBank.Location = New System.Drawing.Point(8, 168)
            Me.lblBank.Name = "lblBank"
            Me.lblBank.Size = New System.Drawing.Size(152, 18)
            Me.lblBank.TabIndex = 11
            Me.lblBank.Text = "ธนาคาร:"
            Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBankBranchName
            '
            Me.Validator.SetDataType(Me.txtBankBranchName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankBranchName, "")
            Me.txtBankBranchName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankBranchName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBankBranchName, System.Drawing.Color.Empty)
            Me.txtBankBranchName.Location = New System.Drawing.Point(312, 144)
            Me.Validator.SetMaxValue(Me.txtBankBranchName, "")
            Me.Validator.SetMinValue(Me.txtBankBranchName, "")
            Me.txtBankBranchName.Name = "txtBankBranchName"
            Me.txtBankBranchName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankBranchName, "")
            Me.Validator.SetRequired(Me.txtBankBranchName, False)
            Me.txtBankBranchName.Size = New System.Drawing.Size(224, 21)
            Me.txtBankBranchName.TabIndex = 9
            Me.txtBankBranchName.TabStop = False
            Me.txtBankBranchName.Text = ""
            '
            'lblBankBranch
            '
            Me.lblBankBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankBranch.ForeColor = System.Drawing.Color.Black
            Me.lblBankBranch.Location = New System.Drawing.Point(8, 144)
            Me.lblBankBranch.Name = "lblBankBranch"
            Me.lblBankBranch.Size = New System.Drawing.Size(152, 18)
            Me.lblBankBranch.TabIndex = 11
            Me.lblBankBranch.Text = "สาขา:"
            Me.lblBankBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBankName
            '
            Me.Validator.SetDataType(Me.txtBankName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankName, "")
            Me.txtBankName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBankName, System.Drawing.Color.Empty)
            Me.txtBankName.Location = New System.Drawing.Point(168, 168)
            Me.Validator.SetMaxValue(Me.txtBankName, "")
            Me.Validator.SetMinValue(Me.txtBankName, "")
            Me.txtBankName.Name = "txtBankName"
            Me.txtBankName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankName, "")
            Me.Validator.SetRequired(Me.txtBankName, False)
            Me.txtBankName.Size = New System.Drawing.Size(416, 21)
            Me.txtBankName.TabIndex = 10
            Me.txtBankName.TabStop = False
            Me.txtBankName.Text = ""
            '
            'lblType
            '
            Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblType.ForeColor = System.Drawing.Color.Black
            Me.lblType.Location = New System.Drawing.Point(8, 96)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(152, 18)
            Me.lblType.TabIndex = 200
            Me.lblType.Text = "ประเภทสมุดบัญชี:"
            Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbType
            '
            Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbType.Location = New System.Drawing.Point(168, 96)
            Me.cmbType.Name = "cmbType"
            Me.cmbType.Size = New System.Drawing.Size(144, 21)
            Me.cmbType.TabIndex = 5
            '
            'txtBankCode
            '
            Me.Validator.SetDataType(Me.txtBankCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankCode, "")
            Me.txtBankCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
            Me.txtBankCode.Location = New System.Drawing.Point(168, 48)
            Me.txtBankCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtBankCode, "")
            Me.Validator.SetMinValue(Me.txtBankCode, "")
            Me.txtBankCode.Name = "txtBankCode"
            Me.Validator.SetRegularExpression(Me.txtBankCode, "")
            Me.Validator.SetRequired(Me.txtBankCode, True)
            Me.txtBankCode.Size = New System.Drawing.Size(144, 21)
            Me.txtBankCode.TabIndex = 3
            Me.txtBankCode.Text = ""
            '
            'lblBankCode
            '
            Me.lblBankCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankCode.ForeColor = System.Drawing.Color.Black
            Me.lblBankCode.Location = New System.Drawing.Point(8, 48)
            Me.lblBankCode.Name = "lblBankCode"
            Me.lblBankCode.Size = New System.Drawing.Size(152, 18)
            Me.lblBankCode.TabIndex = 7
            Me.lblBankCode.Text = "รหัส:"
            Me.lblBankCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbAccountStatus
            '
            Me.cmbAccountStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbAccountStatus.Location = New System.Drawing.Point(472, 24)
            Me.cmbAccountStatus.Name = "cmbAccountStatus"
            Me.cmbAccountStatus.Size = New System.Drawing.Size(112, 21)
            Me.cmbAccountStatus.TabIndex = 2
            '
            'txtBalance
            '
            Me.Validator.SetDataType(Me.txtBalance, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtBalance, "")
            Me.txtBalance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBalance, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBalance, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBalance, System.Drawing.Color.Empty)
            Me.txtBalance.Location = New System.Drawing.Point(168, 192)
            Me.txtBalance.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtBalance, "")
            Me.Validator.SetMinValue(Me.txtBalance, "")
            Me.txtBalance.Name = "txtBalance"
            Me.txtBalance.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBalance, "")
            Me.Validator.SetRequired(Me.txtBalance, False)
            Me.txtBalance.Size = New System.Drawing.Size(144, 21)
            Me.txtBalance.TabIndex = 8
            Me.txtBalance.TabStop = False
            Me.txtBalance.Text = ""
            Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblBalance
            '
            Me.lblBalance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBalance.ForeColor = System.Drawing.Color.Black
            Me.lblBalance.Location = New System.Drawing.Point(8, 192)
            Me.lblBalance.Name = "lblBalance"
            Me.lblBalance.Size = New System.Drawing.Size(152, 18)
            Me.lblBalance.TabIndex = 11
            Me.lblBalance.Text = "ยอดเงินคงเหลือ"
            Me.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrency
            '
            Me.lblCurrency.AutoSize = True
            Me.lblCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCurrency.Location = New System.Drawing.Point(320, 192)
            Me.lblCurrency.Name = "lblCurrency"
            Me.lblCurrency.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency.TabIndex = 11
            Me.lblCurrency.Text = "บาท"
            Me.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Nothing
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'BankAccountDetailView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "BankAccountDetailView"
            Me.Size = New System.Drawing.Size(744, 240)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SelLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblName}")
            Me.Validator.SetDisplayName(Me.txtName, lblName.Text)

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblCode}")
            Me.Validator.SetDisplayName(Me.txtCode, lblCode.Text)

            Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblBank}")
            Me.lblBankCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblBankCode}")
            Me.Validator.SetDisplayName(Me.txtBankCode, lblBankCode.Text)

            Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblAccount}")
            Me.Validator.SetDisplayName(txtAccountCode, lblAccount.Text)

            Me.lblBankBranch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblBankBranch}")
            Me.Validator.SetDisplayName(Me.txtBankBranchCode, lblBankBranch.Text)

            Me.lblAccountStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblAccountStatus}")
            Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblType}")

            Me.lblBalance.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankAccountDetailView.lblBalance}")
            Me.lblCurrency.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

        End Sub
#End Region

#Region "Member"
        Private m_entity As New BankAccount
        Private m_owner As IListPanel
        Private m_isInitialized As Boolean = False

#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Initialize()
            SetLabelText()
            UpdateEntityProperties()
            EventWiring()
        End Sub
#End Region

#Region "Method"
        Private Sub SetBankName()
            If m_entity.BankBranch.Bank Is Nothing Then
                txtBankName.Text = ""
            Else
                txtBankName.Text = Me.m_entity.BankBranch.Bank.Name
            End If
        End Sub
        Public Overrides Sub Initialize()
            BankAccoutStatus.ListCodeDescriptionInComboBox(cmbAccountStatus, "bankacct_status")
            CodeDescription.ListCodeDescriptionInComboBox(cmbType, "bankacct_type")
        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtBankCode.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtAccountCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtBankBranchCode.Validated, AddressOf Me.ChangeProperty

            AddHandler cmbAccountStatus.SelectedIndexChanged, AddressOf Me.ChangeProperty
            AddHandler cmbType.SelectedIndexChanged, AddressOf Me.ChangeProperty
        End Sub

#End Region

#Region "IListDetail"

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()

        End Sub

        ' เคลียร์ข้อมูลใน control
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In grbDetail.Controls
                If TypeOf crlt Is TextBox Then
                    crlt.Text = ""
                End If
            Next

            cmbAccountStatus.SelectedIndex = 0
            cmbType.SelectedIndex = 0
        End Sub

        ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            ' ทำการผูก Property ต่าง ๆ เข้ากับ control
            With Me
                .txtCode.Text = .m_entity.Code
                .txtName.Text = .m_entity.Name
                .txtBankCode.Text = .m_entity.BankCode
                ' autogencode
                m_oldCodeBankacct = m_entity.Code
                Me.chkAutorun.Checked = Me.m_entity.AutoGen
                Me.UpdateAutogenStatus()

                If Not .m_entity.Account Is Nothing Then
                    .txtAccountCode.Text = .m_entity.Account.Code
                    .txtAccountName.Text = .m_entity.Account.Name
                End If

                If Not .m_entity.BankBranch Is Nothing Then
                    .txtBankBranchCode.Text = .m_entity.BankBranch.Code
                    .txtBankBranchName.Text = .m_entity.BankBranch.Name
                    If m_entity.BankBranch.Bank Is Nothing Then
                        txtBankName.Text = ""
                    Else
                        txtBankName.Text = Me.m_entity.BankBranch.Bank.Name
                    End If
                End If
                For Each item As IdValuePair In Me.cmbAccountStatus.Items
                    If item.Id = .m_entity.Status.Value Then
                        .cmbAccountStatus.SelectedItem = item
                    End If
                Next
                For Each item As IdValuePair In Me.cmbType.Items
                    If item.Id = .m_entity.Type.Value Then
                        .cmbType.SelectedItem = item
                    End If
                Next
                ' ยอดเงินในบัญชี readonly
                txtBalance.Text = Configuration.FormatToString(Me.m_entity.BankBalance, DigitConfig.Price)

            End With

            CheckFormEnable()
            SetLabelText()
            m_isInitialized = True
        End Sub

        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    dirtyFlag = True
                    Me.m_entity.Code = Me.txtCode.Text

                Case "txtbankcode"
                    dirtyFlag = True
                    Me.m_entity.BankCode = Me.txtBankCode.Text

                Case "txtname"
                    dirtyFlag = True
                    Me.m_entity.Name = Me.txtName.Text

                Case "cmbtype"
                    Dim item As IdValuePair = CType(cmbType.SelectedItem, IdValuePair)
                    Me.m_entity.Type.Value = item.Id
                    dirtyFlag = True

                Case "cmbaccountstatus"
                    Dim item As IdValuePair = CType(cmbAccountStatus.SelectedItem, IdValuePair)
                    Me.m_entity.Status.Value = item.Id
                    dirtyFlag = True

                Case "txtaccountcode"
                    dirtyFlag = Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)
                Case "txtbankbranchcode"
                    dirtyFlag = BankBranch.GetBankBranch(txtBankBranchCode, txtBankBranchName, Me.m_entity.BankBranch)
                    SetBankName()
            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub

        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                m_entity = Nothing
                Me.m_entity = CType(Value, BankAccount)
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

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
        ' BankBranch
        Private Sub btnBankBranchEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankBranchEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New BankBranch)
        End Sub
        Private Sub btnBankBranchFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankBranchFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New BankBranch, AddressOf SetBankBranchDialog)
        End Sub
        Private Sub SetBankBranchDialog(ByVal e As ISimpleEntity)
            Me.txtBankBranchCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or BankBranch.GetBankBranch(txtBankBranchCode, txtBankBranchName, Me.m_entity.BankBranch)
            SetBankName()
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
                If data.GetDataPresent((New BankBranch).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtbankbranchcode", "txtbankbranchname"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
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
            If data.GetDataPresent((New BankBranch).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New BankBranch).FullClassName))
                Dim entity As New BankBranch(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtbankbranchcode", "txtbankbranchname"
                            Me.SetBankBranchDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Autogencode "
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_oldCodeBankacct As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
                Me.Validator.SetRequired(Me.txtCode, False)
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.txtCode.ReadOnly = True
                m_oldCodeBankacct = Me.txtCode.Text
                Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
                'Hack: set Code เป็น "" เอง
                Me.m_entity.Code = ""
                Me.m_entity.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtCode, True)
                Me.txtCode.Text = m_oldCodeBankacct
                Me.txtCode.ReadOnly = False
                Me.m_entity.AutoGen = False
            End If
        End Sub
#End Region
    End Class

End Namespace
