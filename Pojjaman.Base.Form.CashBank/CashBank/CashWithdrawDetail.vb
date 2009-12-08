Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CashWithdrawDetail
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
        Friend WithEvents lblAmount As System.Windows.Forms.Label
        Friend WithEvents lblBank As System.Windows.Forms.Label
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents lblBankAccount As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents grbMain As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents btnBankAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents btnBankAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtBankAccountCode As System.Windows.Forms.TextBox
        Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtAmount As System.Windows.Forms.TextBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtBankBranch As System.Windows.Forms.TextBox
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents lblCurrencyUnit1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CashWithdrawDetail))
            Me.grbMain = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.btnBankAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.btnBankAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtBankAccountCode = New System.Windows.Forms.TextBox
            Me.txtBankAccountName = New System.Windows.Forms.TextBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.txtAmount = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtBankBranch = New System.Windows.Forms.TextBox
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblAmount = New System.Windows.Forms.Label
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblBank = New System.Windows.Forms.Label
            Me.lblNote = New System.Windows.Forms.Label
            Me.lblBankAccount = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblCurrencyUnit1 = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbMain.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMain
            '
            Me.grbMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMain.Controls.Add(Me.chkAutorun)
            Me.grbMain.Controls.Add(Me.lblStatus)
            Me.grbMain.Controls.Add(Me.btnBankAccountFind)
            Me.grbMain.Controls.Add(Me.txtDocDate)
            Me.grbMain.Controls.Add(Me.btnBankAccountEdit)
            Me.grbMain.Controls.Add(Me.txtBankAccountCode)
            Me.grbMain.Controls.Add(Me.txtBankAccountName)
            Me.grbMain.Controls.Add(Me.dtpDocDate)
            Me.grbMain.Controls.Add(Me.txtAmount)
            Me.grbMain.Controls.Add(Me.txtCode)
            Me.grbMain.Controls.Add(Me.txtBankBranch)
            Me.grbMain.Controls.Add(Me.txtNote)
            Me.grbMain.Controls.Add(Me.lblAmount)
            Me.grbMain.Controls.Add(Me.lblDocDate)
            Me.grbMain.Controls.Add(Me.lblBank)
            Me.grbMain.Controls.Add(Me.lblNote)
            Me.grbMain.Controls.Add(Me.lblBankAccount)
            Me.grbMain.Controls.Add(Me.lblCode)
            Me.grbMain.Controls.Add(Me.lblCurrencyUnit1)
            Me.grbMain.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMain.Location = New System.Drawing.Point(4, 8)
            Me.grbMain.Name = "grbMain"
            Me.grbMain.Size = New System.Drawing.Size(672, 224)
            Me.grbMain.TabIndex = 191
            Me.grbMain.TabStop = False
            Me.grbMain.Text = "ถอนเงินสด"
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(256, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 329
            Me.chkAutorun.TabStop = False
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.Location = New System.Drawing.Point(8, 200)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 231
            Me.lblStatus.Text = "lblStatus"
            '
            'btnBankAccountFind
            '
            Me.btnBankAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankAccountFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBankAccountFind.Image = CType(resources.GetObject("btnBankAccountFind.Image"), System.Drawing.Image)
            Me.btnBankAccountFind.Location = New System.Drawing.Point(472, 72)
            Me.btnBankAccountFind.Name = "btnBankAccountFind"
            Me.btnBankAccountFind.Size = New System.Drawing.Size(24, 23)
            Me.btnBankAccountFind.TabIndex = 208
            Me.btnBankAccountFind.TabStop = False
            Me.btnBankAccountFind.ThemedImage = CType(resources.GetObject("btnBankAccountFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtDocDate
            '
            Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDate, "")
            Me.txtDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.txtDocDate.Location = New System.Drawing.Point(376, 24)
            Me.txtDocDate.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(123, 21)
            Me.txtDocDate.TabIndex = 2
            Me.txtDocDate.TabStop = False
            Me.txtDocDate.Text = ""
            '
            'btnBankAccountEdit
            '
            Me.btnBankAccountEdit.Image = CType(resources.GetObject("btnBankAccountEdit.Image"), System.Drawing.Image)
            Me.btnBankAccountEdit.Location = New System.Drawing.Point(496, 72)
            Me.btnBankAccountEdit.Name = "btnBankAccountEdit"
            Me.btnBankAccountEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnBankAccountEdit.TabIndex = 207
            Me.btnBankAccountEdit.ThemedImage = CType(resources.GetObject("btnBankAccountEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtBankAccountCode
            '
            Me.Validator.SetDataType(Me.txtBankAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankAccountCode, "")
            Me.txtBankAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankAccountCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
            Me.txtBankAccountCode.Location = New System.Drawing.Point(136, 72)
            Me.txtBankAccountCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtBankAccountCode, "")
            Me.Validator.SetMinValue(Me.txtBankAccountCode, "")
            Me.txtBankAccountCode.Name = "txtBankAccountCode"
            Me.Validator.SetRegularExpression(Me.txtBankAccountCode, "")
            Me.Validator.SetRequired(Me.txtBankAccountCode, True)
            Me.txtBankAccountCode.Size = New System.Drawing.Size(120, 21)
            Me.txtBankAccountCode.TabIndex = 4
            Me.txtBankAccountCode.TabStop = False
            Me.txtBankAccountCode.Text = ""
            '
            'txtBankAccountName
            '
            Me.Validator.SetDataType(Me.txtBankAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankAccountName, "")
            Me.txtBankAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankAccountName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
            Me.txtBankAccountName.Location = New System.Drawing.Point(256, 72)
            Me.txtBankAccountName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtBankAccountName, "")
            Me.Validator.SetMinValue(Me.txtBankAccountName, "")
            Me.txtBankAccountName.Name = "txtBankAccountName"
            Me.txtBankAccountName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankAccountName, "")
            Me.Validator.SetRequired(Me.txtBankAccountName, False)
            Me.txtBankAccountName.Size = New System.Drawing.Size(216, 21)
            Me.txtBankAccountName.TabIndex = 5
            Me.txtBankAccountName.Text = ""
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDate.Location = New System.Drawing.Point(376, 24)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(144, 20)
            Me.dtpDocDate.TabIndex = 201
            '
            'txtAmount
            '
            Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtAmount, "")
            Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
            Me.txtAmount.Location = New System.Drawing.Point(136, 48)
            Me.txtAmount.MaxLength = 13
            Me.Validator.SetMaxValue(Me.txtAmount, "")
            Me.Validator.SetMinValue(Me.txtAmount, "")
            Me.txtAmount.Name = "txtAmount"
            Me.Validator.SetRegularExpression(Me.txtAmount, "")
            Me.Validator.SetRequired(Me.txtAmount, True)
            Me.txtAmount.Size = New System.Drawing.Size(120, 21)
            Me.txtAmount.TabIndex = 3
            Me.txtAmount.TabStop = False
            Me.txtAmount.Text = ""
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(136, 24)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(120, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'txtBankBranch
            '
            Me.Validator.SetDataType(Me.txtBankBranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankBranch, "")
            Me.txtBankBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankBranch, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
            Me.txtBankBranch.Location = New System.Drawing.Point(136, 96)
            Me.txtBankBranch.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtBankBranch, "")
            Me.Validator.SetMinValue(Me.txtBankBranch, "")
            Me.txtBankBranch.Name = "txtBankBranch"
            Me.txtBankBranch.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankBranch, "")
            Me.Validator.SetRequired(Me.txtBankBranch, False)
            Me.txtBankBranch.Size = New System.Drawing.Size(384, 21)
            Me.txtBankBranch.TabIndex = 6
            Me.txtBankBranch.Text = ""
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(136, 120)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(384, 21)
            Me.txtNote.TabIndex = 7
            Me.txtNote.Text = ""
            '
            'lblAmount
            '
            Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAmount.ForeColor = System.Drawing.Color.Black
            Me.lblAmount.Location = New System.Drawing.Point(8, 48)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(120, 18)
            Me.lblAmount.TabIndex = 178
            Me.lblAmount.Text = "จำนวนถอน:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.ForeColor = System.Drawing.Color.Black
            Me.lblDocDate.Location = New System.Drawing.Point(280, 24)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDate.TabIndex = 177
            Me.lblDocDate.Text = "วันที่เอกสาร:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBank
            '
            Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBank.ForeColor = System.Drawing.Color.Black
            Me.lblBank.Location = New System.Drawing.Point(8, 96)
            Me.lblBank.Name = "lblBank"
            Me.lblBank.Size = New System.Drawing.Size(120, 18)
            Me.lblBank.TabIndex = 185
            Me.lblBank.Text = "ธนาคาร/สาขา:"
            Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 120)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(120, 18)
            Me.lblNote.TabIndex = 187
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBankAccount
            '
            Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
            Me.lblBankAccount.Location = New System.Drawing.Point(8, 72)
            Me.lblBankAccount.Name = "lblBankAccount"
            Me.lblBankAccount.Size = New System.Drawing.Size(120, 18)
            Me.lblBankAccount.TabIndex = 186
            Me.lblBankAccount.Text = "สมุดเงินฝากธนาคาร:"
            Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(120, 18)
            Me.lblCode.TabIndex = 178
            Me.lblCode.Text = "รหัสเอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrencyUnit1
            '
            Me.lblCurrencyUnit1.AutoSize = True
            Me.lblCurrencyUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrencyUnit1.ForeColor = System.Drawing.Color.Black
            Me.lblCurrencyUnit1.Location = New System.Drawing.Point(264, 48)
            Me.lblCurrencyUnit1.Name = "lblCurrencyUnit1"
            Me.lblCurrencyUnit1.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrencyUnit1.TabIndex = 178
            Me.lblCurrencyUnit1.Text = "บาท"
            Me.lblCurrencyUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            'CashWithdrawDetail
            '
            Me.Controls.Add(Me.grbMain)
            Me.Name = "CashWithdrawDetail"
            Me.Size = New System.Drawing.Size(680, 248)
            Me.grbMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CashWithdrawDetail.lblAmount}")
            Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.lblBankAccount.Text = Me.StringParserService.Parse("${res:Global.BankAccountText}")
            Me.Validator.SetDisplayName(txtBankAccountCode, lblBankAccount.Text)

            Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CashWithdrawDetail.lblBank}")

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CashWithdrawDetail.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
            Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

            Me.grbMain.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CashWithdrawDetail.grbMain}")
            Me.lblCurrencyUnit1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            'Me.lblCurrencyUnit2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
        End Sub
#End Region

#Region "Members"
        Private m_entity As CashWithdraw
        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructs"
        Public Sub New()
            MyBase.New()
            InitializeComponent()

            Initialize()
            EventWiring()
            SetLabelText()
        End Sub
#End Region

#Region "Methods"
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity.Canceled _
            OrElse Me.m_entity.Status.Value = 0 _
            OrElse Me.m_entity.Status.Value >= 3 Then
                For Each ctrl As Control In grbMain.Controls
                    ctrl.Enabled = False
                Next
            Else
                For Each ctrl As Control In grbMain.Controls
                    ctrl.Enabled = True
                Next
            End If
        End Sub

        Public Overrides Sub Initialize()

        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtAmount.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtAmount.Validated, AddressOf Me.NumberTextBoxChange

            AddHandler txtBankAccountCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
        End Sub
        Public Sub NumberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtamount"
                    txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
            End Select
        End Sub
        Private m_dateSetting As Boolean
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    dirtyFlag = True
                    Me.m_entity.Code = txtCode.Text

                Case "dtpdocdate"
                    If Not Me.m_entity.Docdate.Equals(dtpDocDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.Docdate = dtpDocDate.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdate"
                    m_dateSetting = True
                    If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDate.Text)
                        If Not Me.m_entity.Docdate.Equals(theDate) Then
                            dtpDocDate.Value = theDate
                            Me.m_entity.Docdate = dtpDocDate.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDate.Value = Date.Now
                        Me.m_entity.Docdate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False

                Case "txtamount"
                    dirtyFlag = True
                    If txtAmount.TextLength > 0 Then
                        Me.m_entity.Amount = CDec(txtAmount.Text)
                    Else
                        Me.m_entity.Amount = Nothing
                    End If

                Case "txtbankaccountcode"
                    dirtyFlag = BankAccount.GetBankAccountBankBranch(txtBankAccountCode, txtBankAccountName, txtBankBranch, Me.m_entity.Bankacct)

                Case "txtnote"
                    dirtyFlag = True
                    Me.m_entity.Note = txtNote.Text

                Case "cmbtype"
                    dirtyFlag = True

            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

            CheckFormEnable()
            SetStatus()
        End Sub
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            txtCode.Text = Me.m_entity.Code
            ' autogencode
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()


            dtpDocDate.Value = MinDateToNow(Me.m_entity.Docdate)
            txtDocDate.Text = MinDateToNull(Me.m_entity.Docdate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

            txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)

            If Not Me.m_entity.Bankacct Is Nothing Then
                txtBankAccountCode.Text = Me.m_entity.Bankacct.Code
                txtBankAccountName.Text = Me.m_entity.Bankacct.Name
                txtBankBranch.Text = Me.m_entity.Bankacct.BankBranchName
            End If

            txtNote.Text = Me.m_entity.Note

            SetStatus()
            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True
        End Sub
        Public Overrides Sub ClearDetail()
            lblStatus.Text = ""
            For Each crlt As Control In grbMain.Controls
                If TypeOf crlt Is TextBox Then
                    crlt.Text = ""
                End If
            Next

            txtDocDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            dtpDocDate.Value = Date.Now

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, CashWithdraw)
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
        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            If Not successful Then
                Return
            End If
            If Me.m_entity.Canceled Then
                Me.m_entity.CancelPerson = Me.SecurityService.CurrentUser
                Me.m_entity.CancelDate = Now
            Else
                Me.m_entity.CancelPerson = New User
                Me.m_entity.CancelDate = Date.MinValue
                Me.m_entity.LastEditor = Me.SecurityService.CurrentUser
                Me.m_entity.LastEditDate = Now
            End If
            SetStatus()
            CheckFormEnable()
        End Sub

#End Region

#Region "Event of Button controls"
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
                Or BankAccount.GetBankAccountBankBranch(txtBankAccountCode, txtBankAccountName, txtBankBranch, Me.m_entity.Bankacct)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New BankAccount).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtbankaccountcode", "txtbankaccountname"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New BankAccount).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New BankAccount).FullClassName))
                Dim entity As New BankAccount(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtbankaccountcode", "txtbankaccountname"
                            Me.SetBankAccountDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Autogencode "
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_oldCode As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
                Me.Validator.SetRequired(Me.txtCode, False)
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.txtCode.ReadOnly = True
                m_oldCode = Me.txtCode.Text
                Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
                'Hack: set Code เป็น "" เอง
                Me.m_entity.Code = ""
                Me.m_entity.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtCode, True)
                Me.txtCode.Text = m_oldCode
                Me.txtCode.ReadOnly = False
                Me.m_entity.AutoGen = False
            End If
        End Sub
#End Region

    End Class
End Namespace