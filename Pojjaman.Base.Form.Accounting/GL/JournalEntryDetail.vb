Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class JournalEntryDetail
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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblAccountBook As System.Windows.Forms.Label
    Friend WithEvents lblRefDate As System.Windows.Forms.Label
    Friend WithEvents lblRefCode As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtSumDebit As System.Windows.Forms.TextBox
    Friend WithEvents lblSumDebit As System.Windows.Forms.Label
    Friend WithEvents lblSumCredit As System.Windows.Forms.Label
    Friend WithEvents txtSumCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtRefDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpRefDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAccountBookName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountBookCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtRefCode As System.Windows.Forms.TextBox
    Friend WithEvents grbDetail As FixedGroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnShowAccountBook As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowAccountBookDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnShowRefDoc As System.Windows.Forms.Button
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnPost As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ibtnRefJVDoc As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JournalEntryDetail))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblAccountBook = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.lblRefDate = New System.Windows.Forms.Label()
      Me.txtRefCode = New System.Windows.Forms.TextBox()
      Me.lblRefCode = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblType = New System.Windows.Forms.Label()
      Me.txtSumDebit = New System.Windows.Forms.TextBox()
      Me.lblSumDebit = New System.Windows.Forms.Label()
      Me.lblSumCredit = New System.Windows.Forms.Label()
      Me.txtSumCredit = New System.Windows.Forms.TextBox()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.txtRefDate = New System.Windows.Forms.TextBox()
      Me.dtpRefDate = New System.Windows.Forms.DateTimePicker()
      Me.txtAccountBookName = New System.Windows.Forms.TextBox()
      Me.txtAccountBookCode = New System.Windows.Forms.TextBox()
      Me.cmbType = New System.Windows.Forms.ComboBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.ibtnRefJVDoc = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnPost = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.ibtnShowAccountBookDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowAccountBook = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnShowRefDoc = New System.Windows.Forms.Button()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(112, 18)
      Me.lblCode.TabIndex = 178
      Me.lblCode.Text = "เลขที่เอกสาร:"
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
      Me.txtCode.Location = New System.Drawing.Point(120, 16)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(160, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(312, 64)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(96, 18)
      Me.lblDocDate.TabIndex = 177
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAccountBook
      '
      Me.lblAccountBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountBook.ForeColor = System.Drawing.Color.Black
      Me.lblAccountBook.Location = New System.Drawing.Point(24, 88)
      Me.lblAccountBook.Name = "lblAccountBook"
      Me.lblAccountBook.Size = New System.Drawing.Size(96, 18)
      Me.lblAccountBook.TabIndex = 124
      Me.lblAccountBook.Text = "สมุดรายวัน:"
      Me.lblAccountBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 184)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(104, 18)
      Me.lblItem.TabIndex = 195
      Me.lblItem.Text = "รายการรายวัน:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblRefDate
      '
      Me.lblRefDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDate.ForeColor = System.Drawing.Color.Black
      Me.lblRefDate.Location = New System.Drawing.Point(312, 88)
      Me.lblRefDate.Name = "lblRefDate"
      Me.lblRefDate.Size = New System.Drawing.Size(96, 18)
      Me.lblRefDate.TabIndex = 177
      Me.lblRefDate.Text = "วันที่เอกสารอ้างอิง:"
      Me.lblRefDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtRefCode
      '
      Me.Validator.SetDataType(Me.txtRefCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefCode, "")
      Me.txtRefCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRefCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRefCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRefCode, System.Drawing.Color.Empty)
      Me.txtRefCode.Location = New System.Drawing.Point(120, 40)
      Me.txtRefCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtRefCode, "")
      Me.txtRefCode.Name = "txtRefCode"
      Me.Validator.SetRegularExpression(Me.txtRefCode, "")
      Me.Validator.SetRequired(Me.txtRefCode, False)
      Me.txtRefCode.Size = New System.Drawing.Size(160, 21)
      Me.txtRefCode.TabIndex = 1
      Me.txtRefCode.TabStop = False
      '
      'lblRefCode
      '
      Me.lblRefCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefCode.ForeColor = System.Drawing.Color.Black
      Me.lblRefCode.Location = New System.Drawing.Point(16, 40)
      Me.lblRefCode.Name = "lblRefCode"
      Me.lblRefCode.Size = New System.Drawing.Size(104, 18)
      Me.lblRefCode.TabIndex = 178
      Me.lblRefCode.Text = "เลขที่เอกสารอ้างอิง:"
      Me.lblRefCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(120, 112)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(520, 42)
      Me.txtNote.TabIndex = 6
      Me.txtNote.TabStop = False
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(48, 112)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(72, 18)
      Me.lblNote.TabIndex = 178
      Me.lblNote.Text = "คำอธิบาย:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblType
      '
      Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblType.ForeColor = System.Drawing.Color.Black
      Me.lblType.Location = New System.Drawing.Point(8, 64)
      Me.lblType.Name = "lblType"
      Me.lblType.Size = New System.Drawing.Size(112, 18)
      Me.lblType.TabIndex = 178
      Me.lblType.Text = "ประเภท:"
      Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSumDebit
      '
      Me.Validator.SetDataType(Me.txtSumDebit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSumDebit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSumDebit, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSumDebit, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSumDebit, System.Drawing.Color.Empty)
      Me.txtSumDebit.Location = New System.Drawing.Point(344, 176)
      Me.Validator.SetMinValue(Me.txtSumDebit, "")
      Me.txtSumDebit.Name = "txtSumDebit"
      Me.txtSumDebit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSumDebit, "")
      Me.Validator.SetRequired(Me.txtSumDebit, False)
      Me.txtSumDebit.Size = New System.Drawing.Size(96, 20)
      Me.txtSumDebit.TabIndex = 8
      Me.txtSumDebit.TabStop = False
      Me.txtSumDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSumDebit
      '
      Me.lblSumDebit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSumDebit.ForeColor = System.Drawing.Color.Black
      Me.lblSumDebit.Location = New System.Drawing.Point(256, 176)
      Me.lblSumDebit.Name = "lblSumDebit"
      Me.lblSumDebit.Size = New System.Drawing.Size(80, 18)
      Me.lblSumDebit.TabIndex = 201
      Me.lblSumDebit.Text = "Total Debit="
      Me.lblSumDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSumCredit
      '
      Me.lblSumCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSumCredit.ForeColor = System.Drawing.Color.Black
      Me.lblSumCredit.Location = New System.Drawing.Point(448, 176)
      Me.lblSumCredit.Name = "lblSumCredit"
      Me.lblSumCredit.Size = New System.Drawing.Size(96, 18)
      Me.lblSumCredit.TabIndex = 200
      Me.lblSumCredit.Text = "Total Credit="
      Me.lblSumCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSumCredit
      '
      Me.Validator.SetDataType(Me.txtSumCredit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSumCredit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSumCredit, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSumCredit, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSumCredit, System.Drawing.Color.Empty)
      Me.txtSumCredit.Location = New System.Drawing.Point(544, 176)
      Me.Validator.SetMinValue(Me.txtSumCredit, "")
      Me.txtSumCredit.Name = "txtSumCredit"
      Me.txtSumCredit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSumCredit, "")
      Me.Validator.SetRequired(Me.txtSumCredit, False)
      Me.txtSumCredit.Size = New System.Drawing.Size(96, 20)
      Me.txtSumCredit.TabIndex = 9
      Me.txtSumCredit.TabStop = False
      Me.txtSumCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(408, 64)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(124, 20)
      Me.txtDocDate.TabIndex = 4
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(408, 64)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 205
      Me.dtpDocDate.TabStop = False
      '
      'txtRefDate
      '
      Me.Validator.SetDataType(Me.txtRefDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtRefDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRefDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRefDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtRefDate, System.Drawing.Color.Empty)
      Me.txtRefDate.Location = New System.Drawing.Point(408, 88)
      Me.Validator.SetMinValue(Me.txtRefDate, "")
      Me.txtRefDate.Name = "txtRefDate"
      Me.Validator.SetRegularExpression(Me.txtRefDate, "")
      Me.Validator.SetRequired(Me.txtRefDate, False)
      Me.txtRefDate.Size = New System.Drawing.Size(124, 20)
      Me.txtRefDate.TabIndex = 5
      '
      'dtpRefDate
      '
      Me.dtpRefDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpRefDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpRefDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpRefDate.Location = New System.Drawing.Point(408, 88)
      Me.dtpRefDate.Name = "dtpRefDate"
      Me.dtpRefDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpRefDate.TabIndex = 207
      Me.dtpRefDate.TabStop = False
      '
      'txtAccountBookName
      '
      Me.txtAccountBookName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAccountBookName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountBookName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountBookName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
      Me.txtAccountBookName.Location = New System.Drawing.Point(168, 88)
      Me.Validator.SetMinValue(Me.txtAccountBookName, "")
      Me.txtAccountBookName.Name = "txtAccountBookName"
      Me.txtAccountBookName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountBookName, "")
      Me.Validator.SetRequired(Me.txtAccountBookName, False)
      Me.txtAccountBookName.Size = New System.Drawing.Size(88, 20)
      Me.txtAccountBookName.TabIndex = 209
      Me.txtAccountBookName.TabStop = False
      '
      'txtAccountBookCode
      '
      Me.Validator.SetDataType(Me.txtAccountBookCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountBookCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountBookCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
      Me.txtAccountBookCode.Location = New System.Drawing.Point(120, 88)
      Me.Validator.SetMinValue(Me.txtAccountBookCode, "")
      Me.txtAccountBookCode.Name = "txtAccountBookCode"
      Me.Validator.SetRegularExpression(Me.txtAccountBookCode, "")
      Me.Validator.SetRequired(Me.txtAccountBookCode, True)
      Me.txtAccountBookCode.Size = New System.Drawing.Size(48, 20)
      Me.txtAccountBookCode.TabIndex = 3
      '
      'cmbType
      '
      Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbType.Enabled = False
      Me.ErrorProvider1.SetIconPadding(Me.cmbType, -15)
      Me.cmbType.Location = New System.Drawing.Point(120, 64)
      Me.cmbType.Name = "cmbType"
      Me.cmbType.Size = New System.Drawing.Size(184, 21)
      Me.cmbType.TabIndex = 2
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
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.ibtnRefJVDoc)
      Me.grbDetail.Controls.Add(Me.ibtnPost)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblAccountBook)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.lblRefDate)
      Me.grbDetail.Controls.Add(Me.txtRefCode)
      Me.grbDetail.Controls.Add(Me.lblRefCode)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblType)
      Me.grbDetail.Controls.Add(Me.txtSumDebit)
      Me.grbDetail.Controls.Add(Me.lblSumDebit)
      Me.grbDetail.Controls.Add(Me.lblSumCredit)
      Me.grbDetail.Controls.Add(Me.txtSumCredit)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.txtRefDate)
      Me.grbDetail.Controls.Add(Me.dtpRefDate)
      Me.grbDetail.Controls.Add(Me.txtAccountBookName)
      Me.grbDetail.Controls.Add(Me.txtAccountBookCode)
      Me.grbDetail.Controls.Add(Me.cmbType)
      Me.grbDetail.Controls.Add(Me.ibtnShowAccountBookDialog)
      Me.grbDetail.Controls.Add(Me.ibtnShowAccountBook)
      Me.grbDetail.Controls.Add(Me.btnShowRefDoc)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(736, 448)
      Me.grbDetail.TabIndex = 216
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด:"
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(280, 16)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 332
      '
      'ibtnRefJVDoc
      '
      Me.ibtnRefJVDoc.Enabled = False
      Me.ibtnRefJVDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnRefJVDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnRefJVDoc.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnRefJVDoc.Location = New System.Drawing.Point(280, 40)
      Me.ibtnRefJVDoc.Name = "ibtnRefJVDoc"
      Me.ibtnRefJVDoc.Size = New System.Drawing.Size(24, 23)
      Me.ibtnRefJVDoc.TabIndex = 224
      Me.ibtnRefJVDoc.TabStop = False
      Me.ibtnRefJVDoc.ThemedImage = CType(resources.GetObject("ibtnRefJVDoc.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnPost
      '
      Me.ibtnPost.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnPost.Location = New System.Drawing.Point(560, 24)
      Me.ibtnPost.Name = "ibtnPost"
      Me.ibtnPost.Size = New System.Drawing.Size(72, 64)
      Me.ibtnPost.TabIndex = 223
      Me.ibtnPost.TabStop = False
      Me.ibtnPost.ThemedImage = CType(resources.GetObject("ibtnPost.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnPost, "ผ่านรายการ")
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(104, 176)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 222
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(128, 176)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 221
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 200)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(712, 240)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 217
      Me.tgItem.TreeManager = Nothing
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblStatus.Location = New System.Drawing.Point(120, 160)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(37, 13)
      Me.lblStatus.TabIndex = 216
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnShowAccountBookDialog
      '
      Me.ibtnShowAccountBookDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAccountBookDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAccountBookDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAccountBookDialog.Location = New System.Drawing.Point(256, 88)
      Me.ibtnShowAccountBookDialog.Name = "ibtnShowAccountBookDialog"
      Me.ibtnShowAccountBookDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAccountBookDialog.TabIndex = 219
      Me.ibtnShowAccountBookDialog.TabStop = False
      Me.ibtnShowAccountBookDialog.ThemedImage = CType(resources.GetObject("ibtnShowAccountBookDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowAccountBook
      '
      Me.ibtnShowAccountBook.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowAccountBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAccountBook.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAccountBook.Location = New System.Drawing.Point(280, 88)
      Me.ibtnShowAccountBook.Name = "ibtnShowAccountBook"
      Me.ibtnShowAccountBook.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAccountBook.TabIndex = 220
      Me.ibtnShowAccountBook.TabStop = False
      Me.ibtnShowAccountBook.ThemedImage = CType(resources.GetObject("ibtnShowAccountBook.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnShowRefDoc
      '
      Me.btnShowRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnShowRefDoc.Location = New System.Drawing.Point(440, 24)
      Me.btnShowRefDoc.Name = "btnShowRefDoc"
      Me.btnShowRefDoc.Size = New System.Drawing.Size(112, 23)
      Me.btnShowRefDoc.TabIndex = 218
      Me.btnShowRefDoc.TabStop = False
      Me.btnShowRefDoc.Text = "Show Ref. Doc"
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(303, 15)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 217
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      '
      'JournalEntryDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "JournalEntryDetail"
      Me.Size = New System.Drawing.Size(752, 464)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As JournalEntry
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dt As TreeTable = JournalEntry.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf JEItemDelete

      EventWiring()

    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "JournalEntry"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "gli_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "gli_linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      csButton.ButtonColor = Color.Lavender

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csDebitAmount As New TreeTextColumn
      csDebitAmount.MappingName = "DebitAmount"
      csDebitAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.DebitAmountHeaderText}")
      csDebitAmount.NullText = ""
      csDebitAmount.DataAlignment = HorizontalAlignment.Right
      csDebitAmount.Format = "#,###.##"
      csDebitAmount.TextBox.Name = "DebitAmount"
      csDebitAmount.Width = 60

      Dim csCreditAmount As New TreeTextColumn
      csCreditAmount.MappingName = "CreditAmount"
      csCreditAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CreditAmountHeaderText}")
      csCreditAmount.NullText = ""
      csCreditAmount.DataAlignment = HorizontalAlignment.Right
      csCreditAmount.Format = "#,###.##"
      csCreditAmount.TextBox.Name = "CreditAmount"
      csCreditAmount.Width = 60

      Dim csCCCode As New TreeTextColumn
      csCCCode.MappingName = "CCCode"
      csCCCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CCCodeHeaderText}")
      csCCCode.NullText = ""
      csCCCode.TextBox.Name = "CCCode"
      csCCCode.Width = 60
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csCCButton As New DataGridButtonColumn
      csCCButton.MappingName = "CCButton"
      csCCButton.HeaderText = ""
      csCCButton.NullText = ""
      AddHandler csCCButton.Click, AddressOf CCClicked

      Dim csCCName As New TreeTextColumn
      csCCName.MappingName = "CCName"
      csCCName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CCNameHeaderText}")
      csCCName.NullText = ""
      csCCName.TextBox.Name = "CCName"
      csCCName.ReadOnly = True
      csCCName.Width = 100

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "gli_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 100
      csNote.TextBox.Name = "gli_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csDebitAmount)
      dst.GridColumnStyles.Add(csCreditAmount)
      dst.GridColumnStyles.Add(csCCCode)
      dst.GridColumnStyles.Add(csCCButton)
      dst.GridColumnStyles.Add(csCCName)
      dst.GridColumnStyles.Add(csNote)

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Public Sub CCClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 2 Then
        AcctButtonClick(e)
      Else
        CCButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As JournalEntryItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is JournalEntryItem Then
          Return Nothing
        End If
        Return CType(row.Tag, JournalEntryItem)
      End Get
    End Property
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
        Return
      End If
      If Not Me.m_entity.ManualFormat Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
        Return
      End If
      If Not Me.m_entity.ManualFormat Then
        'ห้าม key ถ้าไม่ได้ระบุว่าจะ manual
        e.ProposedValue = e.Row(e.Column.ColumnName)
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As JournalEntryItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New JournalEntryItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "cccode"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCCCode(CStr(e.ProposedValue))
          Case "debitamount"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            doc.Amount = value
            doc.IsDebit = True
          Case "creditamount"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            doc.Amount = value
            doc.IsDebit = False
          Case "gli_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub JEItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value >= 3 OrElse Me.m_entity.Status.Value = 0 Then
        If Not Me.m_entity.RefDoctype = 38 Then
          For Each ctrl As Control In grbDetail.Controls
            ctrl.Enabled = False
          Next
        Else
          For Each ctrl As Control In grbDetail.Controls
            If ctrl.Name.ToLower = "chkcancel" Then
              ctrl.Enabled = True
            Else
              ctrl.Enabled = False
            End If
          Next
        End If

        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
        ibtnPost.Enabled = True
      Else
        For Each ctrl As Control In Me.grbDetail.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
        If Me.m_entity.Status.Value >= 4 OrElse Me.m_entity.Status.Value < 2 Then
          'Post ไม่ได้
          Me.ibtnPost.Enabled = False
        Else
          Me.ibtnPost.Enabled = True
        End If
        Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
        Dim level2 As Integer = secSrv.GetAccess(258)
        Dim checkString2 As String = BinaryHelper.DecToBin(level2, 5)
        checkString2 = BinaryHelper.RevertString(checkString2)
        If Me.m_entity.Status.Value >= 4 OrElse Me.m_entity.Status.Value < 2 Then
          'Post ไม่ได้
          Me.ibtnPost.Enabled = False
        Else
          If Not CBool(checkString2.Substring(0, 1)) Then
            'ห้าม เห็น
            Me.ibtnPost.Visible = False
          ElseIf Not CBool(checkString2.Substring(1, 1)) Then
            'ห้ามแก้
            Me.ibtnPost.Visible = True
            Me.ibtnPost.Enabled = False
          Else
            Me.ibtnPost.Visible = True
            Me.ibtnPost.Enabled = True
          End If
        End If
      End If

      btnShowRefDoc.Enabled = True

      If Not Me.m_entity.Originated OrElse Me.m_entity.RefDoc.Id = 0 Then
        ibtnRefJVDoc.Enabled = False
        btnShowRefDoc.Enabled = False
        ibtnCopyMe.Enabled = True
      Else
        ibtnRefJVDoc.Enabled = True
        btnShowRefDoc.Enabled = True
        ibtnCopyMe.Enabled = False
      End If
    End Sub

    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpRefDate.Value = Now
      Me.dtpDocDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.lblCode}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.lblItem}")

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(Me.txtDocDate, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.txtDocDateAlert}"))

      Me.lblAccountBook.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.lblAccountBook}")
      Me.Validator.SetDisplayName(Me.txtAccountBookCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.txtAccountBookCodeAlert}"))

      Me.lblRefDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.lblRefDate}")
      Me.Validator.SetDisplayName(Me.txtRefDate, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.txtRefDateAlert}"))

      Me.lblRefCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.lblRefCode}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.btnShowRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.btnShowRefDoc}")
      Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.lblType}")
      Me.lblSumDebit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.lblSumDebit}")
      Me.lblSumCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.lblSumCredit}")
      Me.ToolTip1.SetToolTip(Me.ibtnPost, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.ibtnPost}"))
      Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler Me.txtRefCode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtRefDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpRefDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtAccountBookCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAccountBookCode.TextChanged, AddressOf Me.TextHandler

    End Sub
    Private txtAccountBookCodeChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtaccountbookcode"
          txtAccountBookCodeChanged = True
      End Select
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      txtCode.Text = m_entity.Code
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()
      txtNote.Text = m_entity.Note

      txtRefCode.Text = m_entity.RefDoc.Code
      txtAccountBookCode.Text = m_entity.AccountBook.Code
      txtAccountBookName.Text = m_entity.AccountBook.Name

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtRefDate.Text = MinDateToNull(Me.m_entity.RefDoc.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpRefDate.Value = MinDateToNow(Me.m_entity.RefDoc.Date)

      If TypeOf Me.m_entity.RefDoc Is ISimpleEntity Then
        Me.m_entity.ManualFormat = False
      Else
        Me.m_entity.ManualFormat = True
      End If

      If Not TypeOf Me.m_entity.RefDoc Is ISimpleEntity Then
        For Each item As IdValuePair In Me.cmbType.Items
          'HAck: hard-coded
          If item.Id = 38 Then
            Me.cmbType.SelectedItem = item
          End If
        Next
        Me.btnShowRefDoc.Enabled = False
      Else
        For Each item As IdValuePair In Me.cmbType.Items
          If CType(Me.m_entity.RefDoc, ISimpleEntity).EntityId = item.Id Then
            Me.cmbType.SelectedItem = item
          End If
        Next
        Me.btnShowRefDoc.Enabled = True
      End If

      RefreshDocs()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateAmount()
      Me.txtSumCredit.Text = Configuration.FormatToString(Me.m_entity.CreditAmount, DigitConfig.Price)
      Me.txtSumDebit.Text = Configuration.FormatToString(Me.m_entity.DebitAmount, DigitConfig.Price)
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.txtSumCredit.Text = Configuration.FormatToString(Me.m_entity.CreditAmount, DigitConfig.Price)
        Me.txtSumDebit.Text = Configuration.FormatToString(Me.m_entity.DebitAmount, DigitConfig.Price)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub RefreshDocs()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = flag
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtrefcode"
          Me.m_entity.RefDoc.Code = txtRefCode.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
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
        Case "dtprefdate"
          If Not Me.m_entity.RefDoc.Date.Equals(dtpRefDate.Value) Then
            If Not m_dateSetting Then
              Me.txtRefDate.Text = MinDateToNull(dtpRefDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.RefDoc.Date = dtpRefDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtrefdate"
          m_dateSetting = True
          If Not Me.txtRefDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtRefDate) = "" Then
            Dim theDate As Date = CDate(Me.txtRefDate.Text)
            If Not Me.m_entity.RefDoc.Date.Equals(theDate) Then
              dtpRefDate.Value = theDate
              Me.m_entity.RefDoc.Date = dtpRefDate.Value
              dirtyFlag = True
            End If
          Else
            Me.m_entity.RefDoc.Date = Date.Now
            Me.m_entity.RefDoc.Date = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "cmbtype"
          Dim item As IdValuePair = CType(Me.cmbType.SelectedItem, IdValuePair)
          'Me.m_entity.Type = New JournalEntryType(item.Id)

        Case "txtaccountbookcode"
          If txtAccountBookCodeChanged Then
            dirtyFlag = AccountBook.GetAccountBook(txtAccountBookCode, txtAccountBookName, Me.m_entity.AccountBook)
            txtAccountBookCodeChanged = False
          End If
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
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
      '  lblStatus.Text = ""
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, JournalEntry)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      JournalEntryType.ListCodeDescriptionInComboBox(Me.cmbType, "gl_type")
    End Sub


#End Region

#Region "Buttons Event"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        m_oldCode = Me.txtCode.Text
        Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Private Sub ibtnShowAccountBookDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccountBookDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBook)
    End Sub
    Private Sub ibtnShowAccountBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowAccountBook.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New AccountBook)
    End Sub
    Private Sub SetAccountBook(ByVal e As ISimpleEntity)
      Me.txtAccountBookCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or AccountBook.GetAccountBook(txtAccountBookCode, txtAccountBookName, Me.m_entity.AccountBook)
    End Sub

    ' JV กรณีมีการอ้างอิง
    Private Sub ibtnRefJVDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnRefJVDoc.Click
      If Me.m_entity.Originated OrElse Me.m_entity.RefDoc.Id = 0 Then
        Dim myEntityPanelService As IEntityPanelService = _
        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        myEntityPanelService.OpenListDialog(New JournalEntry, AddressOf SetRefJVDoc)
      End If
    End Sub
    Private Sub SetRefJVDoc(ByVal e As ISimpleEntity)
      Me.txtRefCode.Text = e.Code
      Me.m_entity.RefJVdoc = e
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub btnShowRefDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowRefDoc.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim refEntity As ISimpleEntity = CType(Me.m_entity.RefDoc, ISimpleEntity)
      myEntityPanelService.OpenDetailPanel(refEntity)
    End Sub
    Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccts)
    End Sub
    Private Sub SetAccts(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = 0 To items.Count - 1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim acct As New Account(item.Id)
        Dim doc As New JournalEntryItem
        If Not Me.CurrentItem Is Nothing Then
          doc = Me.CurrentItem
          Me.m_treeManager.SelectedRow.Tag = Nothing
        Else
          Me.m_entity.ItemCollection.Add(doc)
        End If
        doc.Account = acct
      Next
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Public Sub CCButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCC)
    End Sub
    Private Sub SetCC(ByVal cc As ISimpleEntity)
      Me.m_treeManager.SelectedRow("CCCode") = cc.Code
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      If Not Me.m_entity.ManualFormat Then
        Return
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemCollection.Count - 1 Then
        Return
      End If
      Dim vItem As New JournalEntryItem
      Me.m_entity.ItemCollection.Insert(index, vItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemCollection.Count - 1 Then
        Return
      End If
      Me.m_entity.ItemCollection.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("gli_linenumber") = i + 1
        i += 1
      Next
    End Sub
    Private Sub ibtnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnPost.Click
      'If msgServ.AskQuestion("${res:Global.Question.ConfirmPost}") Then
      '  Me.m_entity.Status.Value = 4
      '  Me.WorkbenchWindow.ViewContent.Save()
      'End If
      Dim currentUserId As Integer
      Dim mySecurityService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)

      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

      If mySecurityService.CurrentUser Is Nothing Then
        msgServ.ShowMessage("${res:Global.Error.NoUser}")
        Return
      End If
      currentUserId = mySecurityService.CurrentUser.Id
      If Me.m_entity.Status.Value = 4 Then
        If msgServ.AskQuestion("${res:Global.Question.ConfirmUnPost}") Then
          Me.m_entity.GLUnPost(currentUserId)
          'Me.WorkbenchWindow.ViewContent.Save()
          CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).CheckFormEnable()
        End If
      Else
        If msgServ.AskQuestion("${res:Global.Question.ConfirmPost}") Then
          If Me.WorkbenchWindow.ViewContent.IsDirty Then
            msgServ.ShowMessage("${res:Global.Info.SaveBeforePost}")
            Exit Sub
          End If
          Me.m_entity.GLPost(currentUserId)
          'Me.WorkbenchWindow.ViewContent.Save()
          CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).CheckFormEnable()
        End If
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
    Public Overrides Sub NotifyBeforeSave()

    End Sub
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New JournalEntry).DetailPanelIcon
      End Get
    End Property
#End Region

    '#Region "IPrintable"
    '        Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
    '            Get
    '                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    '                Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
    '                'Dim thePath As String = FormPath & Path.DirectorySeparatorChar & m_entity.ClassName & ".xml"
    '                Dim thePath As String = FormPath & Path.DirectorySeparatorChar & "GL.xml"
    '                Dim df As New DesignerForm(thePath, CType(Me.m_entity, IPrintableEntity))
    '                Return df.PrintDocument
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property CanPrint() As Boolean
    '            Get
    '                Return False
    '            End Get
    '        End Property
    '#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim btnText As String = ""
      If Not Me.m_entity.Editable AndAlso Not Me.m_entity.ManualFormat Then
        btnText = "invisible"
      End If
      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
        row("CCButton") = btnText
        row("Button") = btnText
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
        row("CCButton") = btnText
        row("Button") = btnText
      End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
  End Class
End Namespace