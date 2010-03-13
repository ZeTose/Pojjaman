Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class WithdrawLoanDetailView
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
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyUnit1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents btnLoanFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnLoanEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtLoanCode As System.Windows.Forms.TextBox
    Friend WithEvents txtLoanName As System.Windows.Forms.TextBox
    Friend WithEvents lblLoan As System.Windows.Forms.Label
    Friend WithEvents lblCreditPeriod As System.Windows.Forms.Label
    Friend WithEvents txtCreditPeriod As System.Windows.Forms.TextBox
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WithdrawLoanDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblDay = New System.Windows.Forms.Label()
      Me.txtCreditPeriod = New System.Windows.Forms.TextBox()
      Me.lblCreditPeriod = New System.Windows.Forms.Label()
      Me.txtDueDate = New System.Windows.Forms.TextBox()
      Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDueDate = New System.Windows.Forms.Label()
      Me.btnLoanFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnLoanEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtLoanCode = New System.Windows.Forms.TextBox()
      Me.txtLoanName = New System.Windows.Forms.TextBox()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.lblLoan = New System.Windows.Forms.Label()
      Me.lblCurrencyUnit1 = New System.Windows.Forms.Label()
      Me.txtDocdate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.lblDay)
      Me.grbDetail.Controls.Add(Me.txtCreditPeriod)
      Me.grbDetail.Controls.Add(Me.lblCreditPeriod)
      Me.grbDetail.Controls.Add(Me.txtDueDate)
      Me.grbDetail.Controls.Add(Me.dtpDueDate)
      Me.grbDetail.Controls.Add(Me.lblDueDate)
      Me.grbDetail.Controls.Add(Me.btnLoanFind)
      Me.grbDetail.Controls.Add(Me.btnLoanEdit)
      Me.grbDetail.Controls.Add(Me.txtLoanCode)
      Me.grbDetail.Controls.Add(Me.txtLoanName)
      Me.grbDetail.Controls.Add(Me.txtAmount)
      Me.grbDetail.Controls.Add(Me.lblAmount)
      Me.grbDetail.Controls.Add(Me.lblLoan)
      Me.grbDetail.Controls.Add(Me.lblCurrencyUnit1)
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
      Me.grbDetail.Size = New System.Drawing.Size(744, 160)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลธนาคาร : "
      '
      'lblDay
      '
      Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDay.ForeColor = System.Drawing.Color.Black
      Me.lblDay.Location = New System.Drawing.Point(468, 76)
      Me.lblDay.Name = "lblDay"
      Me.lblDay.Size = New System.Drawing.Size(25, 18)
      Me.lblDay.TabIndex = 9
      Me.lblDay.Text = "วัน"
      Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtCreditPeriod
      '
      Me.Validator.SetDataType(Me.txtCreditPeriod, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtCreditPeriod, "")
      Me.txtCreditPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCreditPeriod, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCreditPeriod, System.Drawing.Color.Empty)
      Me.txtCreditPeriod.Location = New System.Drawing.Point(419, 75)
      Me.txtCreditPeriod.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtCreditPeriod, "")
      Me.txtCreditPeriod.Name = "txtCreditPeriod"
      Me.Validator.SetRegularExpression(Me.txtCreditPeriod, "")
      Me.Validator.SetRequired(Me.txtCreditPeriod, True)
      Me.txtCreditPeriod.Size = New System.Drawing.Size(38, 21)
      Me.txtCreditPeriod.TabIndex = 8
      Me.txtCreditPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCreditPeriod
      '
      Me.lblCreditPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCreditPeriod.ForeColor = System.Drawing.Color.Black
      Me.lblCreditPeriod.Location = New System.Drawing.Point(325, 76)
      Me.lblCreditPeriod.Name = "lblCreditPeriod"
      Me.lblCreditPeriod.Size = New System.Drawing.Size(88, 18)
      Me.lblCreditPeriod.TabIndex = 7
      Me.lblCreditPeriod.Text = "เครดิต:"
      Me.lblCreditPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDueDate
      '
      Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDate, "")
      Me.txtDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
      Me.txtDueDate.Location = New System.Drawing.Point(593, 75)
      Me.txtDueDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDueDate, "")
      Me.txtDueDate.Name = "txtDueDate"
      Me.Validator.SetRegularExpression(Me.txtDueDate, "")
      Me.Validator.SetRequired(Me.txtDueDate, True)
      Me.txtDueDate.Size = New System.Drawing.Size(115, 21)
      Me.txtDueDate.TabIndex = 11
      '
      'dtpDueDate
      '
      Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDate.Location = New System.Drawing.Point(593, 75)
      Me.dtpDueDate.Name = "dtpDueDate"
      Me.dtpDueDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpDueDate.TabIndex = 12
      Me.dtpDueDate.TabStop = False
      '
      'lblDueDate
      '
      Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDate.ForeColor = System.Drawing.Color.Black
      Me.lblDueDate.Location = New System.Drawing.Point(499, 76)
      Me.lblDueDate.Name = "lblDueDate"
      Me.lblDueDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDueDate.TabIndex = 10
      Me.lblDueDate.Text = "วันที่เอกสาร:"
      Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnLoanFind
      '
      Me.btnLoanFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLoanFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLoanFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLoanFind.Location = New System.Drawing.Point(684, 102)
      Me.btnLoanFind.Name = "btnLoanFind"
      Me.btnLoanFind.Size = New System.Drawing.Size(24, 23)
      Me.btnLoanFind.TabIndex = 16
      Me.btnLoanFind.TabStop = False
      Me.btnLoanFind.ThemedImage = CType(resources.GetObject("btnLoanFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnLoanEdit
      '
      Me.btnLoanEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLoanEdit.Location = New System.Drawing.Point(708, 102)
      Me.btnLoanEdit.Name = "btnLoanEdit"
      Me.btnLoanEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnLoanEdit.TabIndex = 17
      Me.btnLoanEdit.TabStop = False
      Me.btnLoanEdit.ThemedImage = CType(resources.GetObject("btnLoanEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtLoanCode
      '
      Me.Validator.SetDataType(Me.txtLoanCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLoanCode, "")
      Me.txtLoanCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLoanCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLoanCode, System.Drawing.Color.Empty)
      Me.txtLoanCode.Location = New System.Drawing.Point(153, 102)
      Me.txtLoanCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtLoanCode, "")
      Me.txtLoanCode.Name = "txtLoanCode"
      Me.Validator.SetRegularExpression(Me.txtLoanCode, "")
      Me.Validator.SetRequired(Me.txtLoanCode, True)
      Me.txtLoanCode.Size = New System.Drawing.Size(136, 21)
      Me.txtLoanCode.TabIndex = 14
      '
      'txtLoanName
      '
      Me.Validator.SetDataType(Me.txtLoanName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLoanName, "")
      Me.txtLoanName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLoanName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLoanName, System.Drawing.Color.Empty)
      Me.txtLoanName.Location = New System.Drawing.Point(290, 102)
      Me.txtLoanName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtLoanName, "")
      Me.txtLoanName.Name = "txtLoanName"
      Me.txtLoanName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtLoanName, "")
      Me.Validator.SetRequired(Me.txtLoanName, False)
      Me.txtLoanName.Size = New System.Drawing.Size(388, 21)
      Me.txtLoanName.TabIndex = 15
      Me.txtLoanName.TabStop = False
      '
      'txtAmount
      '
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(153, 129)
      Me.txtAmount.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtAmount.TabIndex = 19
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(9, 129)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(136, 18)
      Me.lblAmount.TabIndex = 18
      Me.lblAmount.Text = "จำนวนเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLoan
      '
      Me.lblLoan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLoan.ForeColor = System.Drawing.Color.Black
      Me.lblLoan.Location = New System.Drawing.Point(9, 102)
      Me.lblLoan.Name = "lblLoan"
      Me.lblLoan.Size = New System.Drawing.Size(136, 18)
      Me.lblLoan.TabIndex = 13
      Me.lblLoan.Text = "วงเงินกู้:"
      Me.lblLoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrencyUnit1
      '
      Me.lblCurrencyUnit1.AutoSize = True
      Me.lblCurrencyUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit1.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit1.Location = New System.Drawing.Point(295, 133)
      Me.lblCurrencyUnit1.Name = "lblCurrencyUnit1"
      Me.lblCurrencyUnit1.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrencyUnit1.TabIndex = 20
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
      Me.txtDocdate.Location = New System.Drawing.Point(153, 75)
      Me.txtDocdate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocdate, "")
      Me.txtDocdate.Name = "txtDocdate"
      Me.Validator.SetRegularExpression(Me.txtDocdate, "")
      Me.Validator.SetRequired(Me.txtDocdate, True)
      Me.txtDocdate.Size = New System.Drawing.Size(115, 21)
      Me.txtDocdate.TabIndex = 5
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(153, 75)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpDocDate.TabIndex = 6
      Me.dtpDocDate.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(59, 76)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDate.TabIndex = 4
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
      Me.txtNote.Location = New System.Drawing.Point(153, 48)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, True)
      Me.txtNote.Size = New System.Drawing.Size(579, 22)
      Me.txtNote.TabIndex = 3
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(94, 48)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(48, 18)
      Me.lblNote.TabIndex = 2
      Me.lblNote.Text = "ชื่อ:"
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
      Me.txtCode.Location = New System.Drawing.Point(153, 20)
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
      'WithdrawLoanDetailView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "WithdrawLoanDetailView"
      Me.Size = New System.Drawing.Size(760, 176)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_entity As New WithdrawLoan
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      'Initialize()
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
      AddHandler dtpDueDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDueDate.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCreditPeriod.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCreditPeriod.TextChanged, AddressOf Me.TextHandler

      AddHandler txtLoanCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAmount.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAmount.TextChanged, AddressOf Me.TextHandler

      AddHandler txtLoanCode.Validated, AddressOf Me.ChangeProperty
    End Sub

#End Region

#Region "IListDetail"
    Private txtCreditPeriodChanged As Boolean = False
    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()

    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      txtCode.Text = ""
      txtNote.Text = ""
    End Sub

    Public Overrides Sub SetLabelText()
      If Not Me.m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WithdrawLoanDetailView.lblCode}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WithdrawLoanDetailView.lblName}")
      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WithdrawLoanDetailView.lblAmount}")
      Me.lblLoan.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WithdrawLoanDetailView.lblLoan}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WithdrawLoanDetailView.lblDocDate}")
      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WithdrawLoanDetailView.lblDueDate}")
      Me.lblCurrencyUnit1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WithdrawLoanDetailView.lblCurrencyUnit1}")

      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WithdrawLoanDetailView.grbDetail}")
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

      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
      txtDocdate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
      txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
      txtCreditPeriod.Text = Configuration.FormatToString(m_entity.CreditPeriod, DigitConfig.Int)

      If Not Me.m_entity.Loan Is Nothing Then
        txtLoanCode.Text = Me.m_entity.Loan.Code
        txtLoanName.Text = Me.m_entity.Loan.Name
      End If

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
        Case "txtcreditperiod"
          txtCreditPeriodChanged = True
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
        Case "txtloancode"
          dirtyFlag = Loan.GetLoan(txtLoanCode, txtLoanName, Me.m_entity.Loan)

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

        Case "txtamount"
          dirtyFlag = True
        Case "dtpduedate"
          If Not Me.m_entity.DueDate.Equals(dtpDueDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDate.Text = MinDateToNull(dtpDueDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DueDate = dtpDueDate.Value
            End If
            dirtyFlag = True
            Me.txtCreditPeriod.Text = Configuration.FormatToString(m_entity.CreditPeriod, DigitConfig.Int)
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
            dtpDueDate.Value = Me.m_entity.DueDate 
            dirtyFlag = True
          End If
          Me.txtCreditPeriod.Text = Configuration.FormatToString(m_entity.CreditPeriod, DigitConfig.Int)
          m_dateSetting = False
        Case "txtcreditperiod"
          If txtCreditPeriodChanged Then
            txtCreditPeriodChanged = False
            Dim txt As String = Me.txtCreditPeriod.Text
            If txt.Length > 0 AndAlso IsNumeric(txt) Then
              Me.m_entity.CreditPeriod = CInt(txt)
            Else
              Me.m_entity.CreditPeriod = 0
            End If
            txtCreditPeriod.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
            Me.txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, "")
            Me.dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
            dirtyFlag = True
          End If
      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, WithdrawLoan)
        UpdateEntityProperties()
        EventWiring()
      End Set
    End Property

#End Region

#Region "Event of Button controls"
    ' Loan
    Private Sub btnLoanFindEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoanEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Loan)
    End Sub
    Private Sub btnLoanFindFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoanFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Loan, AddressOf SetLoanDialog)
    End Sub
    Private Sub SetLoanDialog(ByVal e As ISimpleEntity)
      Me.txtLoanCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Loan.GetLoan(txtLoanCode, txtLoanName, Me.m_entity.Loan)
    End Sub
#End Region


#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

    Private Sub WithdrawLoanDetailView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
      AddHandler Me.WorkbenchWindow.ViewContent.Saved, AddressOf EntitySaved
      AddHandler Me.WorkbenchWindow.ViewContent.Saving, AddressOf EntitySaving
    End Sub

    Private Sub EntitySaving(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

    End Sub

  End Class

End Namespace
