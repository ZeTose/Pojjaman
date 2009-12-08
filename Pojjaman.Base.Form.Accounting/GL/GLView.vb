Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class GLView
		Inherits AbstractEntityDetailPanelView
    Implements IValidatable, IAuxTab

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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkPost As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDebit As System.Windows.Forms.Label
    Friend WithEvents lblTotalCredit As System.Windows.Forms.Label
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblAccountBook As System.Windows.Forms.Label
    Friend WithEvents ibtnShowAccountBook As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowAccountBookDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountBookName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountBookCode As System.Windows.Forms.TextBox
    Friend WithEvents lblGLFormat As System.Windows.Forms.Label
    Friend WithEvents ibtnShowGLFormat As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowGLFormatDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnPost As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grbRefDoc As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtRefDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblRefDocDate As System.Windows.Forms.Label
    Friend WithEvents dtpRefDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRefDocCode As System.Windows.Forms.TextBox
    Friend WithEvents lblRefDoc As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkUseRefCode As System.Windows.Forms.CheckBox
    Friend WithEvents txtFormatName As System.Windows.Forms.TextBox
    Friend WithEvents txtFormatCode As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GLView))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblItem = New System.Windows.Forms.Label
      Me.lblGLFormat = New System.Windows.Forms.Label
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.grbRefDoc = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtRefDocDate = New System.Windows.Forms.TextBox
      Me.lblRefDocDate = New System.Windows.Forms.Label
      Me.dtpRefDocDate = New System.Windows.Forms.DateTimePicker
      Me.txtRefDocCode = New System.Windows.Forms.TextBox
      Me.lblRefDoc = New System.Windows.Forms.Label
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblAccountBook = New System.Windows.Forms.Label
      Me.ibtnShowAccountBook = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowAccountBookDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtAccountBookName = New System.Windows.Forms.TextBox
      Me.txtAccountBookCode = New System.Windows.Forms.TextBox
      Me.chkPost = New System.Windows.Forms.CheckBox
      Me.txtTotalDebit = New System.Windows.Forms.TextBox
      Me.lblTotalDebit = New System.Windows.Forms.Label
      Me.lblTotalCredit = New System.Windows.Forms.Label
      Me.txtTotalCredit = New System.Windows.Forms.TextBox
      Me.lblStatus = New System.Windows.Forms.Label
      Me.ibtnShowGLFormat = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowGLFormatDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnPost = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.chkUseRefCode = New System.Windows.Forms.CheckBox
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.txtFormatName = New System.Windows.Forms.TextBox
      Me.txtFormatCode = New System.Windows.Forms.TextBox
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.grbRefDoc.SuspendLayout()
      Me.SuspendLayout()
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
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 168)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(712, 200)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 2
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 152)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(136, 18)
      Me.lblItem.TabIndex = 190
      Me.lblItem.Text = "ข้อมูลการผ่านบัญชี:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblGLFormat
      '
      Me.lblGLFormat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGLFormat.Location = New System.Drawing.Point(16, 96)
      Me.lblGLFormat.Name = "lblGLFormat"
      Me.lblGLFormat.Size = New System.Drawing.Size(128, 18)
      Me.lblGLFormat.TabIndex = 193
      Me.lblGLFormat.Text = "เลือกรูปแบบการ Post:"
      Me.lblGLFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.txtFormatName)
      Me.grbDetail.Controls.Add(Me.txtFormatCode)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.grbRefDoc)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.lblAccountBook)
      Me.grbDetail.Controls.Add(Me.ibtnShowAccountBook)
      Me.grbDetail.Controls.Add(Me.ibtnShowAccountBookDialog)
      Me.grbDetail.Controls.Add(Me.txtAccountBookName)
      Me.grbDetail.Controls.Add(Me.txtAccountBookCode)
      Me.grbDetail.Controls.Add(Me.chkPost)
      Me.grbDetail.Controls.Add(Me.lblGLFormat)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.txtTotalDebit)
      Me.grbDetail.Controls.Add(Me.lblTotalDebit)
      Me.grbDetail.Controls.Add(Me.lblTotalCredit)
      Me.grbDetail.Controls.Add(Me.txtTotalCredit)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.ibtnShowGLFormat)
      Me.grbDetail.Controls.Add(Me.ibtnShowGLFormatDialog)
      Me.grbDetail.Controls.Add(Me.ibtnPost)
      Me.grbDetail.Controls.Add(Me.chkUseRefCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(728, 424)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "การผ่านบัญชี"
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(240, 72)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(104, 18)
      Me.lblDocDate.TabIndex = 338
      Me.lblDocDate.Text = "Document Date:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 23)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(344, 71)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(124, 20)
      Me.txtDocDate.TabIndex = 337
      Me.txtDocDate.Text = ""
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(344, 71)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 339
      Me.dtpDocDate.TabStop = False
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(192, 71)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 336
      Me.ToolTip1.SetToolTip(Me.chkAutorun, "เลขที่อัตโนมัติ")
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 72)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 334
      Me.lblCode.Text = "Document No.:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, 23)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(88, 71)
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(104, 21)
      Me.txtCode.TabIndex = 332
      Me.txtCode.TabStop = False
      Me.txtCode.Text = ""
      '
      'txtNote
      '
      Me.txtNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(368, 376)
      Me.txtNote.MaxLength = 250
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(344, 42)
      Me.txtNote.TabIndex = 333
      Me.txtNote.TabStop = False
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(264, 376)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(104, 18)
      Me.lblNote.TabIndex = 335
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbRefDoc
      '
      Me.grbRefDoc.Controls.Add(Me.txtRefDocDate)
      Me.grbRefDoc.Controls.Add(Me.lblRefDocDate)
      Me.grbRefDoc.Controls.Add(Me.dtpRefDocDate)
      Me.grbRefDoc.Controls.Add(Me.txtRefDocCode)
      Me.grbRefDoc.Controls.Add(Me.lblRefDoc)
      Me.grbRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbRefDoc.Location = New System.Drawing.Point(16, 16)
      Me.grbRefDoc.Name = "grbRefDoc"
      Me.grbRefDoc.Size = New System.Drawing.Size(480, 48)
      Me.grbRefDoc.TabIndex = 219
      Me.grbRefDoc.TabStop = False
      Me.grbRefDoc.Text = "เอกสารอ้างอิง"
      '
      'txtRefDocDate
      '
      Me.txtRefDocDate.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtRefDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocDate, "")
      Me.txtRefDocDate.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtRefDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocDate, System.Drawing.Color.Empty)
      Me.txtRefDocDate.Location = New System.Drawing.Point(328, 16)
      Me.Validator.SetMaxValue(Me.txtRefDocDate, "")
      Me.Validator.SetMinValue(Me.txtRefDocDate, "")
      Me.txtRefDocDate.Name = "txtRefDocDate"
      Me.Validator.SetRegularExpression(Me.txtRefDocDate, "")
      Me.Validator.SetRequired(Me.txtRefDocDate, False)
      Me.txtRefDocDate.Size = New System.Drawing.Size(124, 20)
      Me.txtRefDocDate.TabIndex = 3
      Me.txtRefDocDate.TabStop = False
      Me.txtRefDocDate.Text = ""
      '
      'lblRefDocDate
      '
      Me.lblRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRefDocDate.Location = New System.Drawing.Point(264, 17)
      Me.lblRefDocDate.Name = "lblRefDocDate"
      Me.lblRefDocDate.Size = New System.Drawing.Size(64, 18)
      Me.lblRefDocDate.TabIndex = 2
      Me.lblRefDocDate.Text = "วันที่:"
      Me.lblRefDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpRefDocDate
      '
      Me.dtpRefDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpRefDocDate.Enabled = False
      Me.dtpRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpRefDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpRefDocDate.Location = New System.Drawing.Point(328, 16)
      Me.dtpRefDocDate.Name = "dtpRefDocDate"
      Me.dtpRefDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpRefDocDate.TabIndex = 4
      Me.dtpRefDocDate.TabStop = False
      '
      'txtRefDocCode
      '
      Me.txtRefDocCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtRefDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocCode, "")
      Me.txtRefDocCode.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
      Me.txtRefDocCode.Location = New System.Drawing.Point(112, 16)
      Me.Validator.SetMaxValue(Me.txtRefDocCode, "")
      Me.Validator.SetMinValue(Me.txtRefDocCode, "")
      Me.txtRefDocCode.Name = "txtRefDocCode"
      Me.Validator.SetRegularExpression(Me.txtRefDocCode, "")
      Me.Validator.SetRequired(Me.txtRefDocCode, False)
      Me.txtRefDocCode.Size = New System.Drawing.Size(144, 20)
      Me.txtRefDocCode.TabIndex = 1
      Me.txtRefDocCode.TabStop = False
      Me.txtRefDocCode.Text = ""
      '
      'lblRefDoc
      '
      Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDoc.Location = New System.Drawing.Point(8, 17)
      Me.lblRefDoc.Name = "lblRefDoc"
      Me.lblRefDoc.Size = New System.Drawing.Size(104, 18)
      Me.lblRefDoc.TabIndex = 0
      Me.lblRefDoc.Text = "เลขที่เอกสารอ้างอิง:"
      Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(136, 144)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 218
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(160, 144)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 217
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAccountBook
      '
      Me.lblAccountBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountBook.ForeColor = System.Drawing.Color.Black
      Me.lblAccountBook.Location = New System.Drawing.Point(16, 120)
      Me.lblAccountBook.Name = "lblAccountBook"
      Me.lblAccountBook.Size = New System.Drawing.Size(128, 18)
      Me.lblAccountBook.TabIndex = 213
      Me.lblAccountBook.Text = "สมุดรายวัน:"
      Me.lblAccountBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowAccountBook
      '
      Me.ibtnShowAccountBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAccountBook.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAccountBook.Image = CType(resources.GetObject("ibtnShowAccountBook.Image"), System.Drawing.Image)
      Me.ibtnShowAccountBook.Location = New System.Drawing.Point(408, 120)
      Me.ibtnShowAccountBook.Name = "ibtnShowAccountBook"
      Me.ibtnShowAccountBook.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAccountBook.TabIndex = 216
      Me.ibtnShowAccountBook.TabStop = False
      Me.ibtnShowAccountBook.ThemedImage = CType(resources.GetObject("ibtnShowAccountBook.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowAccountBookDialog
      '
      Me.ibtnShowAccountBookDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowAccountBookDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowAccountBookDialog.Image = CType(resources.GetObject("ibtnShowAccountBookDialog.Image"), System.Drawing.Image)
      Me.ibtnShowAccountBookDialog.Location = New System.Drawing.Point(384, 120)
      Me.ibtnShowAccountBookDialog.Name = "ibtnShowAccountBookDialog"
      Me.ibtnShowAccountBookDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowAccountBookDialog.TabIndex = 215
      Me.ibtnShowAccountBookDialog.TabStop = False
      Me.ibtnShowAccountBookDialog.ThemedImage = CType(resources.GetObject("ibtnShowAccountBookDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountBookName
      '
      Me.txtAccountBookName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAccountBookName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountBookName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
      Me.txtAccountBookName.Location = New System.Drawing.Point(200, 120)
      Me.Validator.SetMaxValue(Me.txtAccountBookName, "")
      Me.Validator.SetMinValue(Me.txtAccountBookName, "")
      Me.txtAccountBookName.Name = "txtAccountBookName"
      Me.txtAccountBookName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountBookName, "")
      Me.Validator.SetRequired(Me.txtAccountBookName, False)
      Me.txtAccountBookName.Size = New System.Drawing.Size(184, 20)
      Me.txtAccountBookName.TabIndex = 214
      Me.txtAccountBookName.TabStop = False
      Me.txtAccountBookName.Text = ""
      '
      'txtAccountBookCode
      '
      Me.Validator.SetDataType(Me.txtAccountBookCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountBookCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
      Me.txtAccountBookCode.Location = New System.Drawing.Point(144, 120)
      Me.Validator.SetMaxValue(Me.txtAccountBookCode, "")
      Me.Validator.SetMinValue(Me.txtAccountBookCode, "")
      Me.txtAccountBookCode.Name = "txtAccountBookCode"
      Me.Validator.SetRegularExpression(Me.txtAccountBookCode, "")
      Me.Validator.SetRequired(Me.txtAccountBookCode, False)
      Me.txtAccountBookCode.Size = New System.Drawing.Size(56, 20)
      Me.txtAccountBookCode.TabIndex = 1
      Me.txtAccountBookCode.Text = ""
      '
      'chkPost
      '
      Me.chkPost.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPost.Location = New System.Drawing.Point(480, 120)
      Me.chkPost.Name = "chkPost"
      Me.chkPost.Size = New System.Drawing.Size(216, 24)
      Me.chkPost.TabIndex = 197
      Me.chkPost.TabStop = False
      Me.chkPost.Text = "แก้ไขรูปแบบการ Post เอง"
      '
      'txtTotalDebit
      '
      Me.Validator.SetDataType(Me.txtTotalDebit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalDebit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotalDebit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalDebit, System.Drawing.Color.Empty)
      Me.txtTotalDebit.Location = New System.Drawing.Point(296, 144)
      Me.Validator.SetMaxValue(Me.txtTotalDebit, "")
      Me.Validator.SetMinValue(Me.txtTotalDebit, "")
      Me.txtTotalDebit.Name = "txtTotalDebit"
      Me.txtTotalDebit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalDebit, "")
      Me.Validator.SetRequired(Me.txtTotalDebit, False)
      Me.txtTotalDebit.Size = New System.Drawing.Size(112, 20)
      Me.txtTotalDebit.TabIndex = 196
      Me.txtTotalDebit.TabStop = False
      Me.txtTotalDebit.Text = ""
      Me.txtTotalDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalDebit
      '
      Me.lblTotalDebit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalDebit.Location = New System.Drawing.Point(208, 144)
      Me.lblTotalDebit.Name = "lblTotalDebit"
      Me.lblTotalDebit.Size = New System.Drawing.Size(80, 18)
      Me.lblTotalDebit.TabIndex = 193
      Me.lblTotalDebit.Text = "Total Debit:"
      Me.lblTotalDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTotalCredit
      '
      Me.lblTotalCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalCredit.Location = New System.Drawing.Point(416, 144)
      Me.lblTotalCredit.Name = "lblTotalCredit"
      Me.lblTotalCredit.Size = New System.Drawing.Size(88, 18)
      Me.lblTotalCredit.TabIndex = 193
      Me.lblTotalCredit.Text = "Total Credit:"
      Me.lblTotalCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTotalCredit
      '
      Me.Validator.SetDataType(Me.txtTotalCredit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalCredit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotalCredit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalCredit, System.Drawing.Color.Empty)
      Me.txtTotalCredit.Location = New System.Drawing.Point(504, 144)
      Me.Validator.SetMaxValue(Me.txtTotalCredit, "")
      Me.Validator.SetMinValue(Me.txtTotalCredit, "")
      Me.txtTotalCredit.Name = "txtTotalCredit"
      Me.txtTotalCredit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalCredit, "")
      Me.Validator.SetRequired(Me.txtTotalCredit, False)
      Me.txtTotalCredit.Size = New System.Drawing.Size(120, 20)
      Me.txtTotalCredit.TabIndex = 196
      Me.txtTotalCredit.TabStop = False
      Me.txtTotalCredit.Text = ""
      Me.txtTotalCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.Location = New System.Drawing.Point(16, 400)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(35, 17)
      Me.lblStatus.TabIndex = 193
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowGLFormat
      '
      Me.ibtnShowGLFormat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowGLFormat.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowGLFormat.Image = CType(resources.GetObject("ibtnShowGLFormat.Image"), System.Drawing.Image)
      Me.ibtnShowGLFormat.Location = New System.Drawing.Point(552, 96)
      Me.ibtnShowGLFormat.Name = "ibtnShowGLFormat"
      Me.ibtnShowGLFormat.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowGLFormat.TabIndex = 216
      Me.ibtnShowGLFormat.TabStop = False
      Me.ibtnShowGLFormat.ThemedImage = CType(resources.GetObject("ibtnShowGLFormat.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowGLFormatDialog
      '
      Me.ibtnShowGLFormatDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowGLFormatDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowGLFormatDialog.Image = CType(resources.GetObject("ibtnShowGLFormatDialog.Image"), System.Drawing.Image)
      Me.ibtnShowGLFormatDialog.Location = New System.Drawing.Point(528, 96)
      Me.ibtnShowGLFormatDialog.Name = "ibtnShowGLFormatDialog"
      Me.ibtnShowGLFormatDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowGLFormatDialog.TabIndex = 215
      Me.ibtnShowGLFormatDialog.TabStop = False
      Me.ibtnShowGLFormatDialog.ThemedImage = CType(resources.GetObject("ibtnShowGLFormatDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnPost
      '
      Me.ibtnPost.Image = CType(resources.GetObject("ibtnPost.Image"), System.Drawing.Image)
      Me.ibtnPost.Location = New System.Drawing.Point(504, 24)
      Me.ibtnPost.Name = "ibtnPost"
      Me.ibtnPost.Size = New System.Drawing.Size(72, 64)
      Me.ibtnPost.TabIndex = 218
      Me.ibtnPost.TabStop = False
      Me.ibtnPost.ThemedImage = CType(resources.GetObject("ibtnPost.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkUseRefCode
      '
      Me.chkUseRefCode.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkUseRefCode.Image = CType(resources.GetObject("chkUseRefCode.Image"), System.Drawing.Image)
      Me.chkUseRefCode.Location = New System.Drawing.Point(216, 71)
      Me.chkUseRefCode.Name = "chkUseRefCode"
      Me.chkUseRefCode.Size = New System.Drawing.Size(21, 21)
      Me.chkUseRefCode.TabIndex = 336
      Me.ToolTip1.SetToolTip(Me.chkUseRefCode, "ใช้รหัสจากเอกสารอ้างอิง")
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
      'txtFormatName
      '
      Me.Validator.SetDataType(Me.txtFormatName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFormatName, "")
      Me.txtFormatName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFormatName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFormatName, System.Drawing.Color.Empty)
      Me.txtFormatName.Location = New System.Drawing.Point(200, 96)
      Me.Validator.SetMaxValue(Me.txtFormatName, "")
      Me.Validator.SetMinValue(Me.txtFormatName, "")
      Me.txtFormatName.Name = "txtFormatName"
      Me.txtFormatName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFormatName, "")
      Me.Validator.SetRequired(Me.txtFormatName, False)
      Me.txtFormatName.Size = New System.Drawing.Size(328, 21)
      Me.txtFormatName.TabIndex = 341
      Me.txtFormatName.Text = ""
      '
      'txtFormatCode
      '
      Me.txtFormatCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFormatCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFormatCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFormatCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFormatCode, System.Drawing.Color.Empty)
      Me.txtFormatCode.Location = New System.Drawing.Point(144, 96)
      Me.Validator.SetMaxValue(Me.txtFormatCode, "")
      Me.Validator.SetMinValue(Me.txtFormatCode, "")
      Me.txtFormatCode.Name = "txtFormatCode"
      Me.Validator.SetRegularExpression(Me.txtFormatCode, "")
      Me.Validator.SetRequired(Me.txtFormatCode, False)
      Me.txtFormatCode.Size = New System.Drawing.Size(56, 20)
      Me.txtFormatCode.TabIndex = 340
      Me.txtFormatCode.Text = ""
      '
      'GLView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "GLView"
      Me.Size = New System.Drawing.Size(744, 440)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grbRefDoc.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As ISimpleEntity
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_je As JournalEntry

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable

    Private m_format As GLFormat

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
		Private Function CreateTableStyle() As DataGridTableStyle
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
			If Not Me.m_je.ManualFormat Then
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
			If Not Me.m_je.ManualFormat Then
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
				Me.m_je.ItemCollection.Add(doc)
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
			If Me.m_je Is Nothing Then
				Return
			End If
			If Me.m_je.Status.Value >= 4 OrElse Me.m_je.Status.Value = 0 OrElse Me.m_entity.Status.Value = 0 Then
				For Each ctrl As Control In grbDetail.Controls
					ctrl.Enabled = False
				Next
				tgItem.Enabled = True
				For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
					colStyle.ReadOnly = True
				Next
			Else
				For Each ctrl As Control In Me.grbDetail.Controls
					ctrl.Enabled = CBool(m_enableState(ctrl))
				Next
				For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
					colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
				Next
			End If
			If Me.m_je.Status.Value = 1 OrElse Me.m_je.Status.Value = 0 OrElse Me.m_entity.Status.Value = 0 Then		'Me.m_je.Status.Value >= 4
				'Post ไม่ได้
				Me.ibtnPost.Enabled = False
			Else
				Me.ibtnPost.Enabled = True
			End If
			CheckGLRight()
			If Me.m_je.Status.Value = 0 Then
				For Each ctrl As Control In grbDetail.Controls
					ctrl.Enabled = False
				Next
				tgItem.Enabled = True
				For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
					colStyle.ReadOnly = True
				Next
			End If
		End Sub
		Private Sub CheckGLRight()
			Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
			Dim level As Integer = secSrv.GetAccess(96)
			Dim checkString As String = BinaryHelper.DecToBin(level, 5)
			checkString = BinaryHelper.RevertString(checkString)
			If Not CBool(checkString.Substring(0, 1)) Then
				'ห้ามเห็น
				grbDetail.Visible = False
			ElseIf Not CBool(checkString.Substring(1, 1)) Then
				'ห้ามแก้
				For Each ctrl As Control In grbDetail.Controls
					ctrl.Enabled = False
				Next
				tgItem.Enabled = True
				For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
					colStyle.ReadOnly = True
				Next
			Else
				'แก้ได้
				For Each ctrl As Control In Me.grbDetail.Controls
					ctrl.Enabled = CBool(m_enableState(ctrl))
				Next
				For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
					colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
				Next
				Dim level2 As Integer = secSrv.GetAccess(258)
				Dim checkString2 As String = BinaryHelper.DecToBin(level2, 5)
				checkString2 = BinaryHelper.RevertString(checkString2)
				If Me.m_je.Status.Value = 1 OrElse Me.m_je.Status.Value = 0 OrElse Me.m_entity.Status.Value = 0 Then		 'Me.m_je.Status.Value >= 4
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
		End Sub
		Public Overrides Sub ClearDetail()
			lblStatus.Text = ""
			For Each crlt As Control In grbDetail.Controls
				If crlt.Name.StartsWith("txt") Then
					crlt.Text = ""
				End If
			Next
		End Sub
		Public Overrides Sub SetLabelText()
			If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
			Me.lblGLFormat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.lblGLFormat}")
			Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.lblItem}")
			Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.grbDetail}")
			Me.chkPost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.chkPost}")
			Me.lblTotalDebit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.lblTotalDebit}")
			Me.lblTotalCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.lblTotalCredit}")
			Me.lblAccountBook.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.lblAccountBook}")
			Me.ToolTip1.SetToolTip(Me.ibtnPost, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.ibtnPost}"))
			Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}"))		'"เลขที่อัตโนมัติ"
			Me.ToolTip1.SetToolTip(Me.chkUseRefCode, Me.StringParserService.Parse("${res:Global.chkUseRefCode}"))		'"ใช้เลขที่จากเอกสารอ้างอิง")

			Me.Validator.SetDisplayName(Me.txtDocDate, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GLView.txtDocDateAlert}"))

		End Sub
		Protected Overrides Sub EventWiring()
			AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
			AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

			AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
			AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

			AddHandler txtFormatCode.Validated, AddressOf Me.ChangeProperty
			AddHandler txtFormatCode.TextChanged, AddressOf Me.TextHandler

			AddHandler txtAccountBookCode.Validated, AddressOf Me.ChangeProperty
			AddHandler txtAccountBookCode.TextChanged, AddressOf Me.TextHandler
			AddHandler Me.chkPost.Click, AddressOf Me.ChangeProperty
		End Sub
		Private txtAccountBookCodeChanged As Boolean = False
		Private txtFormatCodeChanged As Boolean = False
		Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
			If Me.m_entity Is Nothing Or Not m_isInitialized Then
				Return
			End If
			Select Case CType(sender, Control).Name.ToLower
				Case "txtaccountbookcode"
					txtAccountBookCodeChanged = True
				Case "txtformatcode"
					txtFormatCodeChanged = True
			End Select
		End Sub
		' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
		Public Overrides Sub UpdateEntityProperties()
			m_isInitialized = False
			ClearDetail()
			If m_je Is Nothing Then
				Return
			End If

			'***************************************************************
			'If Not m_je.Originated Then
			'    Me.m_je.SetGLFormat(Me.m_je.RefDoc.GetDefaultGLFormat)
			'End If
			'***************************************************************

			txtCode.Text = Me.m_je.Code
			m_oldCode = m_je.Code
			Me.chkAutorun.Checked = Me.m_je.AutoGen
			Me.UpdateAutogenStatus()
			txtNote.Text = Me.m_je.Note
			txtDocDate.Text = MinDateToNull(Me.m_je.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
			dtpDocDate.Value = MinDateToNow(Me.m_je.DocDate)

			UpdateUsingRefCode()

			Me.chkPost.Checked = Me.m_je.ManualFormat

			txtFormatCode.Text = m_je.GLFormat.Code
			txtFormatName.Text = m_je.GLFormat.Name

			txtAccountBookCode.Text = m_je.AccountBook.Code
			txtAccountBookName.Text = m_je.AccountBook.Name


			UpdateRefDoc()

			RefreshDocs()


			SetStatus()
			SetLabelText()
			CheckFormEnable()
			m_isInitialized = True
		End Sub
		Private Sub RefreshDocs()
			Dim flag As Boolean = Me.m_isInitialized
			Me.m_isInitialized = False
			Me.m_je.ItemCollection.Populate(m_treeManager.Treetable)
			RefreshBlankGrid()
			ReIndex()
			Me.m_treeManager.Treetable.AcceptChanges()
			Me.UpdateAmount()
			Me.m_isInitialized = flag
		End Sub
		Private Sub UpdateRefDoc()
			Me.txtRefDocCode.Text = Me.m_je.RefDoc.Code
			Me.txtRefDocDate.Text = MinDateToNull(Me.m_je.RefDoc.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
			Me.dtpRefDocDate.Value = MinDateToNow(Me.m_je.RefDoc.Date)
		End Sub
		Private Sub UpdateAmount()
			Me.txtTotalCredit.Text = Configuration.FormatToString(Me.m_je.CreditAmount, DigitConfig.Price)
			Me.txtTotalDebit.Text = Configuration.FormatToString(Me.m_je.DebitAmount, DigitConfig.Price)
		End Sub
		Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
			If e.Name = "ItemChanged" Then
				UpdateAmount()
				Me.WorkbenchWindow.ViewContent.IsDirty = True
			End If
		End Sub
		Private m_dateSetting As Boolean = False
		Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
			If Me.m_entity Is Nothing Or Not m_isInitialized Then
				Return
			End If
			Dim dirtyFlag As Boolean = False
			Select Case CType(sender, Control).Name.ToLower
				Case "txtcode"
					Me.m_je.Code = txtCode.Text
					dirtyFlag = True
				Case "txtnote"
					Me.m_je.Note = txtNote.Text
					dirtyFlag = True
				Case "dtpdocdate"
					If Not Me.m_je.DocDate.Equals(dtpDocDate.Value) Then
						If Not m_dateSetting Then
							Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
							Me.m_je.DocDate = dtpDocDate.Value
						End If
						dirtyFlag = True
					End If
				Case "txtdocdate"
					m_dateSetting = True
					If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
						Dim theDate As Date = CDate(Me.txtDocDate.Text)
						If Not Me.m_je.DocDate.Equals(theDate) Then
							dtpDocDate.Value = theDate
							Me.m_je.DocDate = dtpDocDate.Value
							dirtyFlag = True
						End If
					Else
						Me.m_je.DocDate = Date.Now
						Me.m_je.DocDate = Date.MinValue
						dirtyFlag = True
					End If
					m_dateSetting = False
				Case "txtformatcode"
					If txtFormatCodeChanged Then
						dirtyFlag = GLFormat.GetGLFormat(Me.txtFormatCode, Me.txtFormatName, Me.m_je.GLFormat)
						Me.txtAccountBookCode.Text = Me.m_je.GLFormat.AccountBook.Code
						Me.txtAccountBookName.Text = Me.m_je.GLFormat.AccountBook.Name
						Me.m_je.SetGLFormat(Me.m_je.GLFormat)
						Me.chkPost.Checked = False
						txtFormatCodeChanged = False
						'RefreshBlankGrid()
					End If
				Case "txtaccountbookcode"
					If txtAccountBookCodeChanged Then
						dirtyFlag = AccountBook.GetAccountBook(txtAccountBookCode, txtAccountBookName, Me.m_je.AccountBook)
						txtAccountBookCodeChanged = False
					End If
				Case "chkpost"
					If Me.chkPost.Checked Then
						Me.m_je.ManualFormat = True
					Else
						Me.m_je.ManualFormat = False
					End If
					RefreshDocs()
			End Select
			Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
			CheckFormEnable()
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
				lblStatus.Text = ""
			End If
		End Sub
		Public Overrides Property Entity() As ISimpleEntity
			Get
				Return Me.m_entity
			End Get
			Set(ByVal Value As ISimpleEntity)
				If Not Object.ReferenceEquals(Me.m_entity, Value) Then
					Me.m_entity = Nothing
					Me.m_entity = Value
					If Not m_je Is Nothing Then
						RemoveHandler Me.m_je.PropertyChanged, AddressOf PropChanged
						Me.m_je = Nothing
					End If
					If TypeOf m_entity Is IGLAble Then
						Dim glRefDoc As IGLAble = CType(m_entity, IGLAble)
						m_je = glRefDoc.JournalEntry
						If m_je Is Nothing Then
							m_je = New JournalEntry(glRefDoc)
						End If
					End If
				End If
				If Not Me.m_je Is Nothing Then
					Me.m_je.OnTabPageTextChanged(m_entity, EventArgs.Empty)
					If Me.WorkbenchWindow.ActiveViewContent Is Me Then
						m_je.RefreshGLFormat()
					End If
				End If
				UpdateEntityProperties()
			End Set
		End Property

		Public Overrides Sub Initialize()
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
				Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_je.EntityId)
				'Hack: set Code เป็น "" เอง
				Me.m_je.Code = ""
				Me.m_je.AutoGen = True
			Else
				'Me.Validator.SetRequired(Me.txtCode, True)
				Me.txtCode.Text = m_oldCode
				Me.txtCode.ReadOnly = False
				Me.m_je.AutoGen = False
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
					Or AccountBook.GetAccountBook(txtAccountBookCode, txtAccountBookName, Me.m_je.AccountBook)
		End Sub
		Private Sub ibtnShowGLFormatDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowGLFormatDialog.Click
			Dim myEntityPanelService As IEntityPanelService = _
				CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			Dim filters(0) As Filter
			If Me.m_entity Is Nothing Then
				Return
			End If
			filters(0) = New Filter("linkgl_doc", Me.m_entity.EntityId)
			If TypeOf Me.m_entity Is APVatInput Then
				filters(0) = New Filter("linkgl_doc", 73)		 'Payselection
			End If
			myEntityPanelService.OpenListDialog(New LinkGL, AddressOf SetGLFormat, filters)
		End Sub
		Private Sub ibtnShowGLFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowGLFormat.Click
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenPanel(New LinkGL)
		End Sub
		Private Sub SetGLFormat(ByVal e As ISimpleEntity)
			Me.txtFormatCode.Text = e.Code
			Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty _
					Or GLFormat.GetGLFormat(Me.txtFormatCode, Me.txtFormatName, Me.m_je.GLFormat)
			Me.txtAccountBookCode.Text = Me.m_je.GLFormat.AccountBook.Code
			Me.txtAccountBookName.Text = Me.m_je.GLFormat.AccountBook.Name
			Me.m_je.SetGLFormat(Me.m_je.GLFormat)
			'RefreshBlankGrid()
			Me.chkPost.Checked = False
		End Sub
#End Region

#Region "Event Handlers"
		Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
			If Not Me.m_je.ManualFormat Then
				Return
			End If
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAcct)
		End Sub
		Private Sub SetAcct(ByVal acct As ISimpleEntity)
			If TypeOf acct Is Account Then
				If CType(acct, Account).IsControlGroup Then
					Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
					msgServ.ShowMessageFormatted("${res:Global.Error.AccountIsControl}", New String() {acct.Code})
				Else
					Me.m_treeManager.SelectedRow("Code") = acct.Code
				End If
			End If
		End Sub
		Public Sub CCButtonClick(ByVal e As ButtonColumnEventArgs)
			If Not Me.m_je.ManualFormat Then
				Return
			End If
			Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
			myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCC)
		End Sub
		Private Sub SetCC(ByVal cc As ISimpleEntity)
			Me.m_treeManager.SelectedRow("CCCode") = cc.Code
		End Sub
		Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
			If Not Me.m_je.ManualFormat Then
				Return
			End If
			Dim index As Integer = tgItem.CurrentRowIndex
			If index > Me.m_je.ItemCollection.Count - 1 Then
				Return
			End If
			Dim vItem As New JournalEntryItem
			Me.m_je.ItemCollection.Insert(index, vItem)
			RefreshDocs()
			tgItem.CurrentRowIndex = index
		End Sub
		Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
			If Not Me.m_je.ManualFormat Then
				Return
			End If
			Dim index As Integer = Me.tgItem.CurrentRowIndex
			If index > Me.m_je.ItemCollection.Count - 1 Then
				Return
			End If
			Me.m_je.ItemCollection.Remove(index)
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
			Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
			If Me.m_je.Status.Value = 4 Then
				If msgServ.AskQuestion("${res:Global.Question.ConfirmUnPost}") Then
					Me.m_je.GLUnPost()
					CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).CheckFormEnable()
				End If
			Else
				If msgServ.AskQuestion("${res:Global.Question.ConfirmPost}") Then
					If Me.WorkbenchWindow.ViewContent.IsDirty Then
						msgServ.ShowMessage("${res:Global.Info.SaveBeforePost}")
						Exit Sub
					End If
					Me.m_je.GLPost()
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
		'                'Dim thePath As String = FormPath & Path.DirectorySeparatorChar & m_payment.ClassName & ".xml"
		'                Dim thePath As String = FormPath & Path.DirectorySeparatorChar & "GL.xml"
		'                Dim df As New DesignerForm(thePath, CType(Me.m_je, IPrintableEntity))
		'                Return df.PrintDocument
		'            End Get
		'        End Property
		'        Public Overrides ReadOnly Property CanPrint() As Boolean
		'            Get
		'                Return False
		'            End Get
		'        End Property
		'#End Region

#Region "IPrintable"
		Private thePath As String = ""
		Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
			Get
				Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
				Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
				Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")

				If Not File.Exists(thePath) OrElse Not thePath.ToLower.EndsWith(".xml") Then
					Dim fileName As String = CType(Me.m_je, IPrintableEntity).GetDefaultForm
					If fileName Is Nothing OrElse fileName.Length = 0 Then
						fileName = m_je.ClassName
					End If
					thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"
					Dim paths As FormPaths
					Dim nameForPath As String
					nameForPath = m_je.FullClassName & ".Documents"
					Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
					paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, m_je.ClassName, thePath)), FormPaths)
					Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
					If dlg.ShowDialog() = DialogResult.OK Then
						thePath = dlg.KeyValuePair.Value
					Else
						Return Nothing
					End If
				End If
				If File.Exists(thePath) AndAlso thePath.ToLower.EndsWith(".xml") Then
					Dim df As New DesignerForm(thePath, CType(Me.m_je, IPrintableEntity))
					Return df.PrintDocument
				ElseIf File.Exists(thePath) Then
					Dim df As New DocumentForm(thePath, CType(Me.m_je, IPrintableEntity))
					Return df.PrintDocument
				End If
			End Get
		End Property
		Public Overrides ReadOnly Property CanPrint() As Boolean
			Get
				Return True
			End Get
		End Property
#End Region

#Region "Grid Resizing"
		Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
			If Me.m_je Is Nothing Then
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
			If Not Me.m_je.Editable AndAlso Not Me.m_je.ManualFormat Then
				btnText = "invisible"
			End If
			Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
				'เพิ่มแถวจนเต็ม
				Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
				row("CCButton") = btnText
				row("Button") = btnText
			Loop

			If Me.m_je.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
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

#Region "After the main entity has been saved"
		Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
			If Not successful Then
				Return
			End If
			Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
		End Sub
		Public Overrides Sub NotifyBeforeSave()
			MyBase.NotifyBeforeSave()
			Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
			If Me.chkUseRefCode.Checked Then
				Me.m_je.Code = Me.m_entity.Code
			End If
		End Sub
#End Region

#Region "IAuxTab"
		Public ReadOnly Property AuxEntity() As IDirtyAble Implements IAuxTab.AuxEntity
			Get
				Return m_je
			End Get
		End Property
#End Region

		Private Sub chkUseRefCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseRefCode.CheckedChanged
			UpdateUsingRefCode()
			Me.WorkbenchWindow.ViewContent.IsDirty = True
		End Sub
		Private Sub UpdateUsingRefCode()
			If Me.chkUseRefCode.Checked Then
				Dim refCode As String = ""
				If Not Me.m_entity Is Nothing AndAlso Not Me.m_entity.Code Is Nothing _
				AndAlso Me.m_entity.Code.Length > 0 Then
					refCode = Me.m_entity.Code
				End If
				'Me.Validator.SetRequired(Me.txtCode, False)
				Me.ErrorProvider1.SetError(Me.txtCode, "")
				Me.txtCode.ReadOnly = True
				m_oldCode = Me.txtCode.Text
				Me.txtCode.Text = refCode
				'Hack: set Code เป็น "" เอง
				Me.m_je.Code = refCode
				Me.chkAutorun.Enabled = False
			Else
				Me.txtCode.Text = m_oldCode
				Me.txtCode.ReadOnly = False
				Me.chkAutorun.Enabled = True
				UpdateAutogenStatus()
			End If
		End Sub
	End Class
End Namespace
