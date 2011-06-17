Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Telerik.WinControls.UI

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class IncomingCheckDetailView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable, IReversibleEntityProperty

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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblCheckStatus As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grbIncomingCheck As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents dtpReceiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReceiveDate As System.Windows.Forms.Label
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCqCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtReceiveDate As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbCheckStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblCqCode As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents btnCustomerEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnCustomerFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblReceivePerson As System.Windows.Forms.Label
    Friend WithEvents txtReceivePersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivePersonCode As System.Windows.Forms.TextBox
    Friend WithEvents btntxtReceivePersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btntxtReceivePersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnBankFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblBank As System.Windows.Forms.Label
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents btnBankEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents txtCustBankBranch As System.Windows.Forms.TextBox
    Friend WithEvents RadGridView2 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents lblCustBankBranch As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncomingCheckDetailView))
      Me.grbIncomingCheck = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.btnBankFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCustomerFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDueDate = New System.Windows.Forms.TextBox()
      Me.txtReceiveDate = New System.Windows.Forms.TextBox()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.cmbCheckStatus = New System.Windows.Forms.ComboBox()
      Me.dtpReceiveDate = New System.Windows.Forms.DateTimePicker()
      Me.lblCqCode = New System.Windows.Forms.Label()
      Me.txtCqCode = New System.Windows.Forms.TextBox()
      Me.lblReceiveDate = New System.Windows.Forms.Label()
      Me.lblBank = New System.Windows.Forms.Label()
      Me.lblCurrency = New System.Windows.Forms.Label()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblCheckStatus = New System.Windows.Forms.Label()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.btnCustomerEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblDueDate = New System.Windows.Forms.Label()
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.txtBankCode = New System.Windows.Forms.TextBox()
      Me.txtBankName = New System.Windows.Forms.TextBox()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.btnBankEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblReceivePerson = New System.Windows.Forms.Label()
      Me.txtReceivePersonName = New System.Windows.Forms.TextBox()
      Me.txtReceivePersonCode = New System.Windows.Forms.TextBox()
      Me.btntxtReceivePersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btntxtReceivePersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCustBankBranch = New System.Windows.Forms.TextBox()
      Me.lblCustBankBranch = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.RadGridView2 = New Telerik.WinControls.UI.RadGridView()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbIncomingCheck.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbIncomingCheck
      '
      Me.grbIncomingCheck.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbIncomingCheck.Controls.Add(Me.lblItem)
      Me.grbIncomingCheck.Controls.Add(Me.RadGridView2)
      Me.grbIncomingCheck.Controls.Add(Me.chkAutorun)
      Me.grbIncomingCheck.Controls.Add(Me.btnBankFind)
      Me.grbIncomingCheck.Controls.Add(Me.btnCustomerFind)
      Me.grbIncomingCheck.Controls.Add(Me.txtDueDate)
      Me.grbIncomingCheck.Controls.Add(Me.txtReceiveDate)
      Me.grbIncomingCheck.Controls.Add(Me.txtCustomerCode)
      Me.grbIncomingCheck.Controls.Add(Me.cmbCheckStatus)
      Me.grbIncomingCheck.Controls.Add(Me.dtpReceiveDate)
      Me.grbIncomingCheck.Controls.Add(Me.lblCqCode)
      Me.grbIncomingCheck.Controls.Add(Me.txtCqCode)
      Me.grbIncomingCheck.Controls.Add(Me.lblReceiveDate)
      Me.grbIncomingCheck.Controls.Add(Me.lblBank)
      Me.grbIncomingCheck.Controls.Add(Me.lblCurrency)
      Me.grbIncomingCheck.Controls.Add(Me.lblNote)
      Me.grbIncomingCheck.Controls.Add(Me.txtNote)
      Me.grbIncomingCheck.Controls.Add(Me.lblCheckStatus)
      Me.grbIncomingCheck.Controls.Add(Me.lblCustomer)
      Me.grbIncomingCheck.Controls.Add(Me.lblStatus)
      Me.grbIncomingCheck.Controls.Add(Me.btnCustomerEdit)
      Me.grbIncomingCheck.Controls.Add(Me.txtCode)
      Me.grbIncomingCheck.Controls.Add(Me.lblCode)
      Me.grbIncomingCheck.Controls.Add(Me.lblDueDate)
      Me.grbIncomingCheck.Controls.Add(Me.dtpDueDate)
      Me.grbIncomingCheck.Controls.Add(Me.lblAmount)
      Me.grbIncomingCheck.Controls.Add(Me.txtCustomerName)
      Me.grbIncomingCheck.Controls.Add(Me.txtBankCode)
      Me.grbIncomingCheck.Controls.Add(Me.txtBankName)
      Me.grbIncomingCheck.Controls.Add(Me.txtAmount)
      Me.grbIncomingCheck.Controls.Add(Me.btnBankEdit)
      Me.grbIncomingCheck.Controls.Add(Me.lblReceivePerson)
      Me.grbIncomingCheck.Controls.Add(Me.txtReceivePersonName)
      Me.grbIncomingCheck.Controls.Add(Me.txtReceivePersonCode)
      Me.grbIncomingCheck.Controls.Add(Me.btntxtReceivePersonFind)
      Me.grbIncomingCheck.Controls.Add(Me.btntxtReceivePersonEdit)
      Me.grbIncomingCheck.Controls.Add(Me.txtCustBankBranch)
      Me.grbIncomingCheck.Controls.Add(Me.lblCustBankBranch)
      Me.grbIncomingCheck.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbIncomingCheck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbIncomingCheck.ForeColor = System.Drawing.Color.Blue
      Me.grbIncomingCheck.Location = New System.Drawing.Point(8, 8)
      Me.grbIncomingCheck.Name = "grbIncomingCheck"
      Me.grbIncomingCheck.Size = New System.Drawing.Size(616, 428)
      Me.grbIncomingCheck.TabIndex = 0
      Me.grbIncomingCheck.TabStop = False
      Me.grbIncomingCheck.Text = "ข้อมูลเช็ครับ : "
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(272, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 34
      Me.chkAutorun.TabStop = False
      '
      'btnBankFind
      '
      Me.btnBankFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankFind.Location = New System.Drawing.Point(496, 120)
      Me.btnBankFind.Name = "btnBankFind"
      Me.btnBankFind.Size = New System.Drawing.Size(24, 23)
      Me.btnBankFind.TabIndex = 24
      Me.btnBankFind.TabStop = False
      Me.btnBankFind.ThemedImage = CType(resources.GetObject("btnBankFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCustomerFind
      '
      Me.btnCustomerFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCustomerFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustomerFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCustomerFind.Location = New System.Drawing.Point(496, 96)
      Me.btnCustomerFind.Name = "btnCustomerFind"
      Me.btnCustomerFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCustomerFind.TabIndex = 19
      Me.btnCustomerFind.TabStop = False
      Me.btnCustomerFind.ThemedImage = CType(resources.GetObject("btnCustomerFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDueDate
      '
      Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDueDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.txtDueDate.Location = New System.Drawing.Point(424, 48)
      Me.txtDueDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDueDate, "")
      Me.txtDueDate.Name = "txtDueDate"
      Me.Validator.SetRegularExpression(Me.txtDueDate, "")
      Me.Validator.SetRequired(Me.txtDueDate, False)
      Me.txtDueDate.Size = New System.Drawing.Size(96, 21)
      Me.txtDueDate.TabIndex = 9
      '
      'txtReceiveDate
      '
      Me.Validator.SetDataType(Me.txtReceiveDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtReceiveDate, "")
      Me.ErrorProvider1.SetError(Me.txtReceiveDate, "กำหนดวันรับเช็ค")
      Me.Validator.SetGotFocusBackColor(Me.txtReceiveDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtReceiveDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtReceiveDate, System.Drawing.Color.Empty)
      Me.txtReceiveDate.Location = New System.Drawing.Point(424, 24)
      Me.txtReceiveDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtReceiveDate, "")
      Me.txtReceiveDate.Name = "txtReceiveDate"
      Me.Validator.SetRegularExpression(Me.txtReceiveDate, "")
      Me.Validator.SetRequired(Me.txtReceiveDate, True)
      Me.txtReceiveDate.Size = New System.Drawing.Size(96, 21)
      Me.txtReceiveDate.TabIndex = 4
      '
      'txtCustomerCode
      '
      Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCustomerCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(136, 96)
      Me.txtCustomerCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, True)
      Me.txtCustomerCode.Size = New System.Drawing.Size(136, 21)
      Me.txtCustomerCode.TabIndex = 17
      '
      'cmbCheckStatus
      '
      Me.cmbCheckStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
      Me.cmbCheckStatus.Enabled = False
      Me.ErrorProvider1.SetIconPadding(Me.cmbCheckStatus, -15)
      Me.cmbCheckStatus.Location = New System.Drawing.Point(136, 192)
      Me.cmbCheckStatus.MaxLength = 255
      Me.cmbCheckStatus.Name = "cmbCheckStatus"
      Me.cmbCheckStatus.Size = New System.Drawing.Size(136, 21)
      Me.cmbCheckStatus.TabIndex = 30
      Me.cmbCheckStatus.TabStop = False
      '
      'dtpReceiveDate
      '
      Me.dtpReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpReceiveDate.Location = New System.Drawing.Point(424, 24)
      Me.dtpReceiveDate.Name = "dtpReceiveDate"
      Me.dtpReceiveDate.Size = New System.Drawing.Size(120, 21)
      Me.dtpReceiveDate.TabIndex = 5
      Me.dtpReceiveDate.TabStop = False
      '
      'lblCqCode
      '
      Me.lblCqCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCqCode.ForeColor = System.Drawing.Color.Black
      Me.lblCqCode.Location = New System.Drawing.Point(8, 50)
      Me.lblCqCode.Name = "lblCqCode"
      Me.lblCqCode.Size = New System.Drawing.Size(120, 18)
      Me.lblCqCode.TabIndex = 6
      Me.lblCqCode.Text = "เลขที่เช็ค:"
      Me.lblCqCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCqCode
      '
      Me.Validator.SetDataType(Me.txtCqCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCqCode, "")
      Me.txtCqCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCqCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCqCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCqCode, System.Drawing.Color.Empty)
      Me.txtCqCode.Location = New System.Drawing.Point(136, 48)
      Me.txtCqCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCqCode, "")
      Me.txtCqCode.Name = "txtCqCode"
      Me.Validator.SetRegularExpression(Me.txtCqCode, "")
      Me.Validator.SetRequired(Me.txtCqCode, True)
      Me.txtCqCode.Size = New System.Drawing.Size(136, 21)
      Me.txtCqCode.TabIndex = 7
      '
      'lblReceiveDate
      '
      Me.lblReceiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReceiveDate.ForeColor = System.Drawing.Color.Black
      Me.lblReceiveDate.Location = New System.Drawing.Point(296, 25)
      Me.lblReceiveDate.Name = "lblReceiveDate"
      Me.lblReceiveDate.Size = New System.Drawing.Size(120, 18)
      Me.lblReceiveDate.TabIndex = 3
      Me.lblReceiveDate.Text = "วันรับเช็ค:"
      Me.lblReceiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBank
      '
      Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBank.ForeColor = System.Drawing.Color.Black
      Me.lblBank.Location = New System.Drawing.Point(8, 120)
      Me.lblBank.Name = "lblBank"
      Me.lblBank.Size = New System.Drawing.Size(120, 18)
      Me.lblBank.TabIndex = 21
      Me.lblBank.Text = "ธนาคาร:"
      Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrency
      '
      Me.lblCurrency.AutoSize = True
      Me.lblCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency.Location = New System.Drawing.Point(280, 168)
      Me.lblCurrency.Name = "lblCurrency"
      Me.lblCurrency.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrency.TabIndex = 28
      Me.lblCurrency.Text = "บาท"
      Me.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(8, 216)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(120, 18)
      Me.lblNote.TabIndex = 31
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(136, 216)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(408, 21)
      Me.txtNote.TabIndex = 32
      '
      'lblCheckStatus
      '
      Me.lblCheckStatus.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblCheckStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCheckStatus.ForeColor = System.Drawing.Color.Black
      Me.lblCheckStatus.Location = New System.Drawing.Point(8, 192)
      Me.lblCheckStatus.Name = "lblCheckStatus"
      Me.lblCheckStatus.Size = New System.Drawing.Size(120, 16)
      Me.lblCheckStatus.TabIndex = 29
      Me.lblCheckStatus.Text = "สถานะเช็ครับ:"
      Me.lblCheckStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.ForeColor = System.Drawing.Color.Black
      Me.lblCustomer.Location = New System.Drawing.Point(8, 96)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(120, 18)
      Me.lblCustomer.TabIndex = 16
      Me.lblCustomer.Text = "ผู้จ่ายเช็ค:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(239, 250)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(93, 13)
      Me.lblStatus.TabIndex = 33
      Me.lblStatus.Text = "อ่ะ ๆๆ อย่าลืมฉันนะ"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCustomerEdit
      '
      Me.btnCustomerEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCustomerEdit.Location = New System.Drawing.Point(520, 96)
      Me.btnCustomerEdit.Name = "btnCustomerEdit"
      Me.btnCustomerEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCustomerEdit.TabIndex = 20
      Me.btnCustomerEdit.TabStop = False
      Me.btnCustomerEdit.ThemedImage = CType(resources.GetObject("btnCustomerEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.ErrorProvider1.SetError(Me.txtCode, "กำหนดเลขที่เอกสาร")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(136, 24)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(136, 21)
      Me.txtCode.TabIndex = 1
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 26)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(120, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.ForeColor = System.Drawing.Color.Black
      Me.lblDueDate.Location = New System.Drawing.Point(280, 48)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(136, 18)
      Me.lblDueDate.TabIndex = 8
      Me.lblDueDate.Text = "วันที่ครบกำหนด:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDueDate
      '
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDate.Location = New System.Drawing.Point(424, 48)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(120, 21)
      Me.dtpDueDate.TabIndex = 10
      Me.dtpDueDate.TabStop = False
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(8, 168)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(120, 18)
      Me.lblAmount.TabIndex = 26
      Me.lblAmount.Text = "จำนวนเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCustomerName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(272, 96)
      Me.txtCustomerName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(224, 21)
      Me.txtCustomerName.TabIndex = 18
      Me.txtCustomerName.TabStop = False
      '
      'txtBankCode
      '
      Me.txtBankCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtBankCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
      Me.txtBankCode.Location = New System.Drawing.Point(136, 120)
      Me.txtBankCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtBankCode, "")
      Me.txtBankCode.Name = "txtBankCode"
      Me.Validator.SetRegularExpression(Me.txtBankCode, "")
      Me.Validator.SetRequired(Me.txtBankCode, True)
      Me.txtBankCode.Size = New System.Drawing.Size(136, 21)
      Me.txtBankCode.TabIndex = 22
      '
      'txtBankName
      '
      Me.txtBankName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBankName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBankName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankName, System.Drawing.Color.Empty)
      Me.txtBankName.Location = New System.Drawing.Point(272, 120)
      Me.txtBankName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtBankName, "")
      Me.txtBankName.Name = "txtBankName"
      Me.txtBankName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankName, "")
      Me.Validator.SetRequired(Me.txtBankName, False)
      Me.txtBankName.Size = New System.Drawing.Size(224, 21)
      Me.txtBankName.TabIndex = 23
      Me.txtBankName.TabStop = False
      '
      'txtAmount
      '
      Me.txtAmount.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.ErrorProvider1.SetError(Me.txtAmount, "กำหนดจำนวนเงิน")
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(136, 168)
      Me.txtAmount.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtAmount.TabIndex = 27
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnBankEdit
      '
      Me.btnBankEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankEdit.Location = New System.Drawing.Point(520, 120)
      Me.btnBankEdit.Name = "btnBankEdit"
      Me.btnBankEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnBankEdit.TabIndex = 25
      Me.btnBankEdit.TabStop = False
      Me.btnBankEdit.ThemedImage = CType(resources.GetObject("btnBankEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblReceivePerson
      '
      Me.lblReceivePerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReceivePerson.ForeColor = System.Drawing.Color.Black
      Me.lblReceivePerson.Location = New System.Drawing.Point(8, 72)
      Me.lblReceivePerson.Name = "lblReceivePerson"
      Me.lblReceivePerson.Size = New System.Drawing.Size(120, 18)
      Me.lblReceivePerson.TabIndex = 11
      Me.lblReceivePerson.Text = "ผู้รับเช็ค:"
      Me.lblReceivePerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtReceivePersonName
      '
      Me.txtReceivePersonName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtReceivePersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtReceivePersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReceivePersonName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtReceivePersonName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtReceivePersonName, System.Drawing.Color.Empty)
      Me.txtReceivePersonName.Location = New System.Drawing.Point(272, 72)
      Me.txtReceivePersonName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtReceivePersonName, "")
      Me.txtReceivePersonName.Name = "txtReceivePersonName"
      Me.txtReceivePersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtReceivePersonName, "")
      Me.Validator.SetRequired(Me.txtReceivePersonName, False)
      Me.txtReceivePersonName.Size = New System.Drawing.Size(224, 21)
      Me.txtReceivePersonName.TabIndex = 13
      Me.txtReceivePersonName.TabStop = False
      '
      'txtReceivePersonCode
      '
      Me.txtReceivePersonCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtReceivePersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtReceivePersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReceivePersonCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtReceivePersonCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtReceivePersonCode, System.Drawing.Color.Empty)
      Me.txtReceivePersonCode.Location = New System.Drawing.Point(136, 72)
      Me.txtReceivePersonCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtReceivePersonCode, "")
      Me.txtReceivePersonCode.Name = "txtReceivePersonCode"
      Me.Validator.SetRegularExpression(Me.txtReceivePersonCode, "")
      Me.Validator.SetRequired(Me.txtReceivePersonCode, False)
      Me.txtReceivePersonCode.Size = New System.Drawing.Size(136, 21)
      Me.txtReceivePersonCode.TabIndex = 12
      '
      'btntxtReceivePersonFind
      '
      Me.btntxtReceivePersonFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btntxtReceivePersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btntxtReceivePersonFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btntxtReceivePersonFind.Location = New System.Drawing.Point(496, 72)
      Me.btntxtReceivePersonFind.Name = "btntxtReceivePersonFind"
      Me.btntxtReceivePersonFind.Size = New System.Drawing.Size(24, 23)
      Me.btntxtReceivePersonFind.TabIndex = 14
      Me.btntxtReceivePersonFind.TabStop = False
      Me.btntxtReceivePersonFind.ThemedImage = CType(resources.GetObject("btntxtReceivePersonFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btntxtReceivePersonEdit
      '
      Me.btntxtReceivePersonEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btntxtReceivePersonEdit.Location = New System.Drawing.Point(520, 72)
      Me.btntxtReceivePersonEdit.Name = "btntxtReceivePersonEdit"
      Me.btntxtReceivePersonEdit.Size = New System.Drawing.Size(24, 23)
      Me.btntxtReceivePersonEdit.TabIndex = 15
      Me.btntxtReceivePersonEdit.TabStop = False
      Me.btntxtReceivePersonEdit.ThemedImage = CType(resources.GetObject("btntxtReceivePersonEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCustBankBranch
      '
      Me.Validator.SetDataType(Me.txtCustBankBranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustBankBranch, "")
      Me.txtCustBankBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustBankBranch, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCustBankBranch, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCustBankBranch, System.Drawing.Color.Empty)
      Me.txtCustBankBranch.Location = New System.Drawing.Point(136, 144)
      Me.txtCustBankBranch.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtCustBankBranch, "")
      Me.txtCustBankBranch.Name = "txtCustBankBranch"
      Me.Validator.SetRegularExpression(Me.txtCustBankBranch, "")
      Me.Validator.SetRequired(Me.txtCustBankBranch, False)
      Me.txtCustBankBranch.Size = New System.Drawing.Size(408, 21)
      Me.txtCustBankBranch.TabIndex = 32
      '
      'lblCustBankBranch
      '
      Me.lblCustBankBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustBankBranch.ForeColor = System.Drawing.Color.Black
      Me.lblCustBankBranch.Location = New System.Drawing.Point(8, 144)
      Me.lblCustBankBranch.Name = "lblCustBankBranch"
      Me.lblCustBankBranch.Size = New System.Drawing.Size(120, 18)
      Me.lblCustBankBranch.TabIndex = 31
      Me.lblCustBankBranch.Text = "ธนาคารและสาขา:"
      Me.lblCustBankBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'RadGridView2
      '
      Me.RadGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.RadGridView2.Location = New System.Drawing.Point(11, 266)
      Me.RadGridView2.Name = "RadGridView2"
      Me.RadGridView2.Size = New System.Drawing.Size(595, 152)
      Me.RadGridView2.TabIndex = 207
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 247)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(136, 18)
      Me.lblItem.TabIndex = 208
      Me.lblItem.Text = "บันทีกยอดตัดรับเช็ค"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'IncomingCheckDetailView
      '
      Me.Controls.Add(Me.grbIncomingCheck)
      Me.Name = "IncomingCheckDetailView"
      Me.Size = New System.Drawing.Size(632, 444)
      Me.grbIncomingCheck.ResumeLayout(False)
      Me.grbIncomingCheck.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblNote}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.lblCheckStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblCheckStatus}")
      Me.Validator.SetDisplayName(cmbCheckStatus, lblCheckStatus.Text)

      Me.lblReceiveDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblReceiveDate}")
      Me.Validator.SetDisplayName(txtReceiveDate, lblReceiveDate.Text)

      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblDueDate}")
      Me.Validator.SetDisplayName(txtDueDate, lblDueDate.Text)

      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblAmount}")
      Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

      Me.lblCqCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblCqCode}")
      Me.Validator.SetDisplayName(txtCqCode, lblCqCode.Text)

      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblCustomer}")
      Me.Validator.SetDisplayName(txtCustomerCode, lblCustomer.Text)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblCustBankBranch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblCustBankBranch}")
      Me.Validator.SetDisplayName(txtCustBankBranch, lblCustBankBranch.Text)

      Me.lblReceivePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblReceivePerson}")
      Me.Validator.SetDisplayName(txtReceivePersonCode, lblReceivePerson.Text)

      Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblBank}")
      Me.Validator.SetDisplayName(txtBankCode, lblBank.Text)

      Me.lblCurrency.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.grbIncomingCheck.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.grbIncomingCheck}")
    End Sub
#End Region

#Region "Member"
    Private m_entity As New IncomingCheck

    Private m_isInitialized As Boolean = False
    Private m_tableInitialized2 As Boolean = False
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.Initialize()
      Me.SetLabelText()

      Me.UpdateEntityProperties()
      Me.EventWiring()
    End Sub
#End Region

#Region "Method"

    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCqCode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDueDate.Validated, AddressOf Me.ChangeProperty
      AddHandler txtReceiveDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDueDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpReceiveDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtReceivePersonCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtBankCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCustBankBranch.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAmount.Validated, AddressOf Me.NumberTextBoxChange

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbCheckStatus.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler RadGridView2.CellDoubleClick, AddressOf CellDoubleClick
    End Sub
    Private Sub CellDoubleClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs)
      If Me.m_entity Is Nothing OrElse e.ColumnIndex = -1 Then
        Return
      End If

      Dim docId As Integer
      Dim docType As Integer

      docId = RadGridView2.Rows(e.RowIndex).Cells("RefId").Value
      docType = RadGridView2.Rows(e.RowIndex).Cells("RefTypeId").Value

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
#End Region

#Region "ISimpleEntityPanel"
    Public Overrides Sub Initialize()
      IncomingCheckDocStatus.ListCodeDescriptionInComboBox(Me.cmbCheckStatus, "incomingcheck_docstatus")
      Me.RadGridView2.MasterGridViewTemplate.AllowAddNewRow = False
      Me.RadGridView2.MasterGridViewTemplate.AllowDragToGroup = False
      Me.RadGridView2.MultiSelect = True
      Me.RadGridView2.ShowGroupPanel = False
      GetColumns(RadGridView2, False)
    End Sub
    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      'For Each ctl As Control In Me.grbIncomingCheck.Controls
      '  Trace.WriteLine(ctl.Name & ":" & ctl.Text)
      'Next    
      If Me.m_entity.Canceled _
          OrElse Me.m_entity.Status.Value = 0 _
          OrElse Me.m_entity.Status.Value > 3 _
          OrElse Me.m_entity.DocStatus.Value = 0 _
          OrElse Me.m_entity.DocStatus.Value = 2 _
          OrElse Me.m_entity.DocStatus.Value > 3 Then
        For Each crlt As Control In grbIncomingCheck.Controls
          crlt.Enabled = False
        Next
        'If Me.m_entity.DocStatus.Value = 3 Then
        '  txtReceivePersonCode.Enabled = True
        '  btntxtReceivePersonFind.Enabled = True
        '  btntxtReceivePersonEdit.Enabled = True
        '  txtBankCode.Enabled = True
        '  btnBankFind.Enabled = True
        '  btnBankEdit.Enabled = True
        '  txtCustBankBranch.Enabled = True
        '  txtNote.Enabled = True
        'End If
      ElseIf Not Me.m_entity.ReceiveList Is Nothing AndAlso Me.m_entity.ReceiveList.Count > 0 Then
        For Each crlt As Control In grbIncomingCheck.Controls
          crlt.Enabled = False
        Next
        txtReceiveDate.Enabled = True
        dtpReceiveDate.Enabled = True
        txtDueDate.Enabled = True
        dtpDueDate.Enabled = True
        txtNote.Enabled = True

      Else
        If Me.m_entity.DocStatus.Value = 3 Then
          txtCode.Enabled = False
          chkAutorun.Enabled = False
          txtReceiveDate.Enabled = False
          dtpReceiveDate.Enabled = False
          txtDueDate.Enabled = False
          dtpDueDate.Enabled = False
          txtCustomerCode.Enabled = False
          btnCustomerFind.Enabled = False
          btnCustomerEdit.Enabled = False
          txtAmount.Enabled = False

          txtReceivePersonCode.Enabled = True
          btntxtReceivePersonFind.Enabled = True
          btntxtReceivePersonEdit.Enabled = True
          txtBankCode.Enabled = True
          btnBankFind.Enabled = True
          btnBankEdit.Enabled = True
          txtCustBankBranch.Enabled = True
          txtNote.Enabled = True
        Else
          For Each crlt As Control In grbIncomingCheck.Controls
            crlt.Enabled = True
          Next
        End If
      End If
      cmbCheckStatus.Enabled = False
      Me.RadGridView2.Enabled = True
    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbIncomingCheck.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        End If
      Next

      txtReceiveDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      txtDueDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      dtpReceiveDate.Value = Date.Now
      dtpDueDate.Value = Date.Now

      cmbCheckStatus.SelectedIndex = 0
      cmbCheckStatus.SelectedIndex = 0

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
        .txtCqCode.Text = .m_entity.CqCode

        ' autogencode 
        Me.m_oldCode = Me.m_entity.Code
        Me.chkAutorun.Checked = Me.m_entity.AutoGen
        Me.UpdateAutogenStatus()

        dtpReceiveDate.Value = MinDateToNow(.m_entity.ReceiveDate)
        txtReceiveDate.Text = MinDateToNull(Me.m_entity.ReceiveDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

        dtpDueDate.Value = MinDateToNow(.m_entity.DueDate)
        If Me.m_entity.Originated Then
          txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
        Else
          txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        End If

        If Not .m_entity.ReceivePerson Is Nothing Then
          .txtReceivePersonCode.Text = .m_entity.ReceivePerson.Code
          .txtReceivePersonName.Text = .m_entity.ReceivePerson.Name
        End If

        If Not .m_entity.Customer Is Nothing Then
          .txtCustomerCode.Text = .m_entity.Customer.Code
          .txtCustomerName.Text = .m_entity.Customer.Name
        End If

        If Not .m_entity.Bank Is Nothing Then
          .txtBankCode.Text = .m_entity.Bank.Code
          .txtBankName.Text = .m_entity.Bank.Name
        End If

        .txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
        .txtCustBankBranch.Text = .m_entity.CustBankBranch
        .txtNote.Text = .m_entity.Note

        Dim index As Integer = -1
        If Not Me.m_entity.DocStatus Is Nothing Then
          index = cmbCheckStatus.FindStringExact(Me.m_entity.DocStatus.Description)
        End If
        If index = -1 Then
          .cmbCheckStatus.SelectedIndex = -1
        Else
          .cmbCheckStatus.SelectedIndex = index
        End If

      End With

      RefreshSelectedItems()

      SetStatus()
      CheckFormEnable()
      SetLabelText()

      m_isInitialized = True
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

    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtcqcode"
          Me.m_entity.CqCode = txtCqCode.Text
          dirtyFlag = True

        Case "txtreceivedate"
          Dim dt As DateTime = StringToDate(txtReceiveDate, dtpReceiveDate)
          Me.m_entity.ReceiveDate = dt
          dirtyFlag = True
        Case "dtpreceivedate"
          txtReceiveDate.Text = MinDateToNull(dtpReceiveDate.Value, "")
          Me.m_entity.ReceiveDate = dtpReceiveDate.Value
          dirtyFlag = True

        Case "txtduedate"
          Dim dt As DateTime = StringToDate(txtDueDate, dtpDueDate)
          Me.m_entity.DueDate = dt
          dirtyFlag = True

        Case "dtpduedate"
          txtDueDate.Text = MinDateToNull(dtpDueDate.Value, "")
          Me.m_entity.DueDate = dtpDueDate.Value
          dirtyFlag = True

        Case "txtreceivepersoncode"
          dirtyFlag = Employee.GetEmployee(txtReceivePersonCode, txtReceivePersonName, Me.m_entity.ReceivePerson)
        Case "txtcustomercode"
          dirtyFlag = Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
        Case "txtbankcode"
          dirtyFlag = Bank.GetBank(txtBankCode, txtBankName, Me.m_entity.Bank)

        Case "txtamount"
          If txtAmount.TextLength > 0 Then
            Me.m_entity.Amount = CDec(txtAmount.Text)
          Else
            Me.m_entity.Amount = Nothing
          End If
          dirtyFlag = True

        Case "cmbcheckstatus"
          Me.m_entity.DocStatus = New IncomingCheckDocStatus(Me.cmbCheckStatus.SelectedIndex)
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = Me.txtNote.Text
          dirtyFlag = True
        Case "txtcustbankbranch"
          Me.m_entity.CustBankBranch = Me.txtCustBankBranch.Text
          dirtyFlag = True

      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      'SetStatus()
      CheckFormEnable()
    End Sub

    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
      'If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
      '  lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '  " " & m_entity.CancelDate.ToShortTimeString & _
      '  "  โดย:" & m_entity.CancelPerson.Name
      'ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
      '  lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '  " " & m_entity.LastEditDate.ToShortTimeString & _
      '  "  โดย:" & m_entity.LastEditor.Name
      'ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
      '  lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '  " " & m_entity.OriginDate.ToShortTimeString & _
      '  "  โดย:" & m_entity.Originator.Name
      'Else
      '  lblStatus.Text = "ยังไม่บันทึก"
      'End If
    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, IncomingCheck)
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
        EventWiring()
      End Set
    End Property

    Dim viewDef As ColumnGroupsViewDefinition
    Private Sub GetColumns(ByVal grid As RadGridView, ByVal istop As Boolean)

      viewDef = New ColumnGroupsViewDefinition
      Dim colNum As Integer = 0
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim gcLineNumber As New GridViewDecimalColumn("Linenumber")
      gcLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.LineNumberHeaderText}")
      gcLineNumber.Width = 45
      gcLineNumber.ReadOnly = True
      gcLineNumber.DecimalPlaces = 0
      gcLineNumber.TextAlignment = ContentAlignment.MiddleCenter
      grid.Columns.Add(gcLineNumber)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcLineNumber)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      'Dim colName As String
      'If istop Then
      '  colName = "Selected"
      'Else
      '  colName = "SelectedForDeleted"
      'End If
      'Dim gcSelected As New GridViewCheckBoxColumn(colName)
      'gcSelected.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
      'gcSelected.Width = 30
      'gcSelected.ReadOnly = False
      'gcSelected.AllowSort = False
      'grid.Columns.Add(gcSelected)
      'viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      'viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      'viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcSelected)
      'viewDef.ColumnGroups(colNum).IsPinned = True
      'colNum += 1

      Dim gcPaymentCode As New GridViewTextBoxColumn("ReceiveCode")
      gcPaymentCode.HeaderText = "เลขที่ RV" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
      gcPaymentCode.Width = 100
      gcPaymentCode.ReadOnly = True
      grid.Columns.Add(gcPaymentCode)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcPaymentCode)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim gcRefCode As New GridViewTextBoxColumn("RefCode")
      gcRefCode.HeaderText = "เอกสารอ้างอิง" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      gcRefCode.Width = 100
      gcRefCode.ReadOnly = True
      grid.Columns.Add(gcRefCode)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefCode)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim gcRefId As New GridViewTextBoxColumn("RefId")
      gcRefId.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      gcRefId.Width = 100
      gcRefId.ReadOnly = True
      gcRefId.IsVisible = False
      grid.Columns.Add(gcRefId)
      'viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      'viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      'viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefId)
      'viewDef.ColumnGroups(colNum).IsPinned = True

      Dim gcRefTypeId As New GridViewTextBoxColumn("RefTypeId")
      gcRefTypeId.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      gcRefTypeId.Width = 100
      gcRefTypeId.ReadOnly = True
      gcRefTypeId.IsVisible = False
      grid.Columns.Add(gcRefTypeId)

      Dim gcRefType As New GridViewTextBoxColumn("RefType")
      gcRefType.HeaderText = "ประเภท" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      gcRefType.Width = 100
      gcRefType.ReadOnly = True
      grid.Columns.Add(gcRefType)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefType)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim gcRefDueDate As New GridViewTextBoxColumn("RefDueDate")
      gcRefDueDate.HeaderText = "วันที่ครบกำหนด" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      gcRefDueDate.Width = 100
      gcRefDueDate.ReadOnly = True
      grid.Columns.Add(gcRefDueDate)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefDueDate)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim csRefAmount As New GridViewTextBoxColumn("RefAmount")
      csRefAmount.HeaderText = "จำนวนเงิน RV" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
      csRefAmount.ReadOnly = True
      csRefAmount.Width = 150
      csRefAmount.TextAlignment = ContentAlignment.MiddleRight
      csRefAmount.ReadOnly = True
      grid.Columns.Add(csRefAmount)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csRefAmount)
      viewDef.ColumnGroups(colNum).IsPinned = True

      Dim csRemain As New GridViewTextBoxColumn("Remain")
      csRemain.HeaderText = "คงเหลือ" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
      csRemain.ReadOnly = True
      csRemain.Width = 150
      csRemain.TextAlignment = ContentAlignment.MiddleRight
      csRemain.ReadOnly = True
      grid.Columns.Add(csRemain)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csRemain)
      viewDef.ColumnGroups(colNum).IsPinned = True

      Dim csAmount As New GridViewTextBoxColumn("Amount")
      csAmount.HeaderText = "จำนวนรับโดยเช็คนี้" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.AmountHeaderText}")
      csAmount.Width = 150
      csAmount.TextAlignment = ContentAlignment.MiddleRight
      csAmount.ReadOnly = True
      grid.Columns.Add(csAmount)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csAmount)
      viewDef.ColumnGroups(colNum).IsPinned = True

      Dim csCheckRemain As New GridViewTextBoxColumn("CheckRemain")
      csCheckRemain.HeaderText = "มูลค่าเช็คคงเหลือ" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
      csCheckRemain.ReadOnly = True
      csCheckRemain.Width = 150
      csCheckRemain.TextAlignment = ContentAlignment.MiddleRight
      csCheckRemain.ReadOnly = True
      grid.Columns.Add(csCheckRemain)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csCheckRemain)
      viewDef.ColumnGroups(colNum).IsPinned = True

      colNum += 1
    End Sub
    Dim CheckRemain As Decimal = 0
    Public Sub PopulateRow(ByVal p As ReceiveForList, ByVal tr As GridViewDataRowInfo)
      If tr Is Nothing Then
        Return
      End If

      If tr.ViewTemplate.Columns.Contains("SelectedForDeleted") Then
        tr.Cells("SelectedForDeleted").Value = p.SelectedForDeleted
      End If
      If tr.ViewTemplate.Columns.Contains("Selected") Then
        tr.Cells("Selected").Value = p.Selected
      End If
      tr.Cells("ReceiveCode").Value = p.Code
      tr.Cells("RefCode").Value = p.RefCode
      tr.Cells("RefId").Value = p.RefId
      tr.Cells("RefTypeId").Value = p.RefTypeId
      tr.Cells("RefType").Value = p.RefType
      tr.Cells("RefDueDate").Value = p.RefDueDate.ToShortDateString
      tr.Cells("RefAmount").Value = Configuration.FormatToString(p.RefAmount, DigitConfig.Price)
      Dim remain As Decimal = p.RefRemain
      If Not p.JustAdded Then
        remain += p.Amount
      End If
      CheckRemain -= p.Amount
      tr.Cells("Remain").Value = Configuration.FormatToString(remain, DigitConfig.Price)
      tr.Cells("Amount").Value = Configuration.FormatToString(p.Amount, DigitConfig.Price)
      tr.Cells("CheckRemain").Value = Configuration.FormatToString(CheckRemain, DigitConfig.Price)

      tr.Tag = p

    End Sub
    Private Sub RefreshSelectedItems()
      m_tableInitialized2 = False
      Me.RadGridView2.GridElement.BeginUpdate()
      Me.RadGridView2.Rows.Clear()
      CheckRemain = m_entity.Amount
      For Each p As ReceiveForList In m_entity.ReceiveList
        Dim row As GridViewDataRowInfo = Me.RadGridView2.Rows.AddNew()
        PopulateRow(p, row)
      Next
      Dim i As Integer = 1
      For Each row As GridViewDataRowInfo In Me.RadGridView2.Rows
        row.Cells("Linenumber").Value = i
        i += 1
      Next
      Me.RadGridView2.GridElement.EndUpdate(True)
      m_tableInitialized2 = True
    End Sub
#End Region

#Region "IReversibleEntityProperty"
    Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties

    End Sub

    Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties

    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Employee).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtreceivepersoncode", "txtreceivepersonname"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New Customer).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcustomercode", "txtcustomername"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New Bank).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtbankcode", "txtbankname"
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
            Case "txtreceivepersoncode", "txtreceivepersonname"
              Me.SetEmployeeDialog(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New Customer).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
        Dim entity As New Customer(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcustomercode", "txtcustomername"
              Me.SetCustomerDialog(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New Bank).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Bank).FullClassName))
        Dim entity As New Bank(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtbankcode", "txtbankname"
              Me.SetBankDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Event of button controls"
    ' ค้นหาผู้รับ 
    Private Sub btntxtReceivePersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntxtReceivePersonEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btntxtReceivePersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntxtReceivePersonFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeDialog)
    End Sub
    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtReceivePersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtReceivePersonCode, txtReceivePersonName, Me.m_entity.ReceivePerson)
    End Sub
    ' ค้นหาลูกค้า
    Private Sub btnCustomerEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Customer)
    End Sub
    Private Sub btnCustomerFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomerDialog)
    End Sub
    Private Sub SetCustomerDialog(ByVal e As ISimpleEntity)
      Me.txtCustomerCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
    End Sub
    ' ค้นหาธนาคาร
    Private Sub btnBankEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Bank)
    End Sub
    Private Sub btnBankFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Bank, AddressOf SetBankDialog)
    End Sub
    Private Sub SetBankDialog(ByVal e As ISimpleEntity)
      Me.txtBankCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Bank.GetBank(txtBankCode, txtBankName, Me.m_entity.Bank)
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
