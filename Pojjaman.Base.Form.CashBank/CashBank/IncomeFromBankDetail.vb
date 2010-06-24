Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class IncomeFromBank
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
    Friend WithEvents grbMain As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtDocdate As System.Windows.Forms.TextBox
    Friend WithEvents btnBankAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnBankAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblBank As System.Windows.Forms.Label
    Friend WithEvents txtNote As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblBankAccount As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblCurrencyUnit1 As System.Windows.Forms.Label
    Friend WithEvents lblWht As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyUnit2 As System.Windows.Forms.Label
    Friend WithEvents txtWht As System.Windows.Forms.TextBox
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtBankBranch As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncomeFromBank))
      Me.grbMain = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.txtDocdate = New System.Windows.Forms.TextBox()
      Me.btnBankAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnBankAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBankAccountCode = New System.Windows.Forms.TextBox()
      Me.txtBankAccountName = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.txtBankBranch = New System.Windows.Forms.TextBox()
      Me.lblBank = New System.Windows.Forms.Label()
      Me.txtNote = New Longkong.Pojjaman.Gui.Components.MultiLineTextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblBankAccount = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblCurrencyUnit1 = New System.Windows.Forms.Label()
      Me.lblWht = New System.Windows.Forms.Label()
      Me.lblCurrencyUnit2 = New System.Windows.Forms.Label()
      Me.txtWht = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.grbMain.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMain
      '
      Me.grbMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMain.Controls.Add(Me.cmbCode)
      Me.grbMain.Controls.Add(Me.chkAutorun)
      Me.grbMain.Controls.Add(Me.lblStatus)
      Me.grbMain.Controls.Add(Me.txtDocdate)
      Me.grbMain.Controls.Add(Me.btnBankAccountFind)
      Me.grbMain.Controls.Add(Me.btnBankAccountEdit)
      Me.grbMain.Controls.Add(Me.txtBankAccountCode)
      Me.grbMain.Controls.Add(Me.txtBankAccountName)
      Me.grbMain.Controls.Add(Me.dtpDocDate)
      Me.grbMain.Controls.Add(Me.txtAmount)
      Me.grbMain.Controls.Add(Me.lblAmount)
      Me.grbMain.Controls.Add(Me.lblDocDate)
      Me.grbMain.Controls.Add(Me.txtBankBranch)
      Me.grbMain.Controls.Add(Me.lblBank)
      Me.grbMain.Controls.Add(Me.txtNote)
      Me.grbMain.Controls.Add(Me.lblNote)
      Me.grbMain.Controls.Add(Me.lblBankAccount)
      Me.grbMain.Controls.Add(Me.lblCode)
      Me.grbMain.Controls.Add(Me.lblCurrencyUnit1)
      Me.grbMain.Controls.Add(Me.lblWht)
      Me.grbMain.Controls.Add(Me.lblCurrencyUnit2)
      Me.grbMain.Controls.Add(Me.txtWht)
      Me.grbMain.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMain.Location = New System.Drawing.Point(8, 8)
      Me.grbMain.Name = "grbMain"
      Me.grbMain.Size = New System.Drawing.Size(664, 232)
      Me.grbMain.TabIndex = 0
      Me.grbMain.TabStop = False
      Me.grbMain.Text = "บันทึกรายได้จากธนาคาร"
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(256, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 2
      Me.chkAutorun.TabStop = False
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.Location = New System.Drawing.Point(8, 208)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 13)
      Me.lblStatus.TabIndex = 0
      Me.lblStatus.Text = "lblStatus"
      '
      'txtDocdate
      '
      Me.Validator.SetDataType(Me.txtDocdate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocdate, "")
      Me.txtDocdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDocdate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocdate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocdate, System.Drawing.Color.Empty)
      Me.txtDocdate.Location = New System.Drawing.Point(376, 24)
      Me.txtDocdate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocdate, "")
      Me.txtDocdate.Name = "txtDocdate"
      Me.Validator.SetRegularExpression(Me.txtDocdate, "")
      Me.Validator.SetRequired(Me.txtDocdate, True)
      Me.txtDocdate.Size = New System.Drawing.Size(115, 21)
      Me.txtDocdate.TabIndex = 4
      '
      'btnBankAccountFind
      '
      Me.btnBankAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAccountFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankAccountFind.Image = CType(resources.GetObject("btnBankAccountFind.Image"), System.Drawing.Image)
      Me.btnBankAccountFind.Location = New System.Drawing.Point(464, 96)
      Me.btnBankAccountFind.Name = "btnBankAccountFind"
      Me.btnBankAccountFind.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAccountFind.TabIndex = 16
      Me.btnBankAccountFind.TabStop = False
      Me.btnBankAccountFind.ThemedImage = CType(resources.GetObject("btnBankAccountFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnBankAccountEdit
      '
      Me.btnBankAccountEdit.Image = CType(resources.GetObject("btnBankAccountEdit.Image"), System.Drawing.Image)
      Me.btnBankAccountEdit.Location = New System.Drawing.Point(488, 96)
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
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAccountCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
      Me.txtBankAccountCode.Location = New System.Drawing.Point(136, 96)
      Me.txtBankAccountCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtBankAccountCode, "")
      Me.txtBankAccountCode.Name = "txtBankAccountCode"
      Me.Validator.SetRegularExpression(Me.txtBankAccountCode, "")
      Me.Validator.SetRequired(Me.txtBankAccountCode, True)
      Me.txtBankAccountCode.Size = New System.Drawing.Size(120, 21)
      Me.txtBankAccountCode.TabIndex = 14
      '
      'txtBankAccountName
      '
      Me.Validator.SetDataType(Me.txtBankAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAccountName, "")
      Me.txtBankAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAccountName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.txtBankAccountName.Location = New System.Drawing.Point(256, 96)
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
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(376, 24)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDate.TabIndex = 5
      Me.dtpDocDate.TabStop = False
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
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(120, 21)
      Me.txtAmount.TabIndex = 7
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(8, 48)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(128, 18)
      Me.lblAmount.TabIndex = 6
      Me.lblAmount.Text = "จำนวนเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(280, 24)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDate.TabIndex = 3
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBankBranch
      '
      Me.Validator.SetDataType(Me.txtBankBranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankBranch, "")
      Me.txtBankBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankBranch, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
      Me.txtBankBranch.Location = New System.Drawing.Point(136, 120)
      Me.txtBankBranch.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtBankBranch, "")
      Me.txtBankBranch.Name = "txtBankBranch"
      Me.txtBankBranch.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankBranch, "")
      Me.Validator.SetRequired(Me.txtBankBranch, False)
      Me.txtBankBranch.Size = New System.Drawing.Size(380, 21)
      Me.txtBankBranch.TabIndex = 19
      Me.txtBankBranch.TabStop = False
      '
      'lblBank
      '
      Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBank.ForeColor = System.Drawing.Color.Black
      Me.lblBank.Location = New System.Drawing.Point(8, 120)
      Me.lblBank.Name = "lblBank"
      Me.lblBank.Size = New System.Drawing.Size(128, 18)
      Me.lblBank.TabIndex = 18
      Me.lblBank.Text = "ธนาคาร/สาขา:"
      Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(136, 144)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(380, 21)
      Me.txtNote.TabIndex = 21
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(8, 144)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(128, 18)
      Me.lblNote.TabIndex = 20
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBankAccount
      '
      Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
      Me.lblBankAccount.Location = New System.Drawing.Point(8, 96)
      Me.lblBankAccount.Name = "lblBankAccount"
      Me.lblBankAccount.Size = New System.Drawing.Size(128, 18)
      Me.lblBankAccount.TabIndex = 13
      Me.lblBankAccount.Text = "สมุดเงินฝากธนาคาร:"
      Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(128, 18)
      Me.lblCode.TabIndex = 0
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
      Me.lblCurrencyUnit1.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrencyUnit1.TabIndex = 8
      Me.lblCurrencyUnit1.Text = "บาท"
      Me.lblCurrencyUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblWht
      '
      Me.lblWht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWht.ForeColor = System.Drawing.Color.Black
      Me.lblWht.Location = New System.Drawing.Point(8, 72)
      Me.lblWht.Name = "lblWht"
      Me.lblWht.Size = New System.Drawing.Size(128, 18)
      Me.lblWht.TabIndex = 10
      Me.lblWht.Text = "จำนวนเงิน:"
      Me.lblWht.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrencyUnit2
      '
      Me.lblCurrencyUnit2.AutoSize = True
      Me.lblCurrencyUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit2.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit2.Location = New System.Drawing.Point(264, 72)
      Me.lblCurrencyUnit2.Name = "lblCurrencyUnit2"
      Me.lblCurrencyUnit2.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrencyUnit2.TabIndex = 12
      Me.lblCurrencyUnit2.Text = "บาท"
      Me.lblCurrencyUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtWht
      '
      Me.Validator.SetDataType(Me.txtWht, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWht, "")
      Me.txtWht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtWht, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtWht, -15)
      Me.Validator.SetInvalidBackColor(Me.txtWht, System.Drawing.Color.Empty)
      Me.txtWht.Location = New System.Drawing.Point(136, 72)
      Me.txtWht.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtWht, "")
      Me.txtWht.Name = "txtWht"
      Me.txtWht.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWht, "")
      Me.Validator.SetRequired(Me.txtWht, True)
      Me.txtWht.Size = New System.Drawing.Size(120, 21)
      Me.txtWht.TabIndex = 11
      Me.txtWht.TabStop = False
      Me.txtWht.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(136, 23)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 214
      '
      'IncomeFromBank
      '
      Me.Controls.Add(Me.grbMain)
      Me.Name = "IncomeFromBank"
      Me.Size = New System.Drawing.Size(688, 248)
      Me.grbMain.ResumeLayout(False)
      Me.grbMain.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomeFromBank.lblAmount}")
      Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

      Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomeFromBank.lblBank}")
      Me.lblBankAccount.Text = Me.StringParserService.Parse("${res:Global.BankAccountText}")
      Me.Validator.SetDisplayName(txtBankAccountCode, lblBankAccount.Text)

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomeFromBank.lblCode}")
      Me.Validator.SetDisplayName(Me.cmbCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblWht.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomeFromBank.lblWht}")
      Me.Validator.SetDisplayName(txtWht, lblWht.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(txtDocdate, lblDocDate.Text)

      Me.grbMain.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomeFromBank.grbMain}")

      Me.lblCurrencyUnit1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblCurrencyUnit2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

    End Sub
#End Region

#Region "Members"
    Private m_entity As BankInterest
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
      If Me.m_entity.Status Is Nothing Then
        Return
      End If
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
      ' TODO : Register BankingType "banking_type"
    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocdate.Validated, AddressOf Me.ChangeProperty

      AddHandler txtBankAccountCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAmount.Validated, AddressOf Me.NumberTextBoxChange

      AddHandler txtWht.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtWht.Validated, AddressOf Me.NumberTextBoxChange

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    Public Sub NumberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtamount"
          txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
        Case "txtwht"
          txtWht.Text = Configuration.FormatToString(Me.m_entity.WHT, DigitConfig.Price)
      End Select
    End Sub
    Private m_dateSetting As Boolean
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
          If Not Me.m_entity.Docdate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocdate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.Docdate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocdate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocdate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocdate.Text)
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
      SetStatus()
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

      dtpDocDate.Value = MinDateToNow(Me.m_entity.Docdate)
      txtDocdate.Text = MinDateToNull(Me.m_entity.Docdate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
      txtWht.Text = Configuration.FormatToString(Me.m_entity.WHT, DigitConfig.Price)

      If Not Me.m_entity.Bankacct Is Nothing Then
        txtBankAccountCode.Text = Me.m_entity.Bankacct.Code
        txtBankAccountName.Text = Me.m_entity.Bankacct.Name
        txtBankBranch.Text = Me.m_entity.Bankacct.BankBranchName
      End If

      txtNote.Text = Me.m_entity.Note
      m_isInitialized = True

      SetStatus()
      SetLabelText()
      CheckFormEnable()
    End Sub
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbMain.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        End If
      Next

      txtDocdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      dtpDocDate.Value = Date.Now

    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, BankInterest)
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
    'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
    'If Not successful Then
    'Return
    'End If
    'If Me.m_entity.Canceled Then
    'Me.m_entity.CancelPerson = Me.SecurityService.CurrentUser
    'Me.m_entity.CancelDate = Now
    'Else
    'Me.m_entity.CancelPerson = New User
    'Me.m_entity.CancelDate = Date.MinValue
    'Me.m_entity.LastEditor = Me.SecurityService.CurrentUser
    'Me.m_entity.LastEditDate = Now
    'End If
    'SetStatus()
    'CheckFormEnable()
    'End Sub

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

  End Class
End Namespace