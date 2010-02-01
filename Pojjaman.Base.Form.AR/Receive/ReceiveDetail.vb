Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels

  Public Class ReceiveDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable, IAuxTab
    'Inherits UserControl

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
    Friend WithEvents lblBankCharge As System.Windows.Forms.Label
    Friend WithEvents txtBankCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtWHT As System.Windows.Forms.TextBox
    Friend WithEvents lblWHT As System.Windows.Forms.Label
    Friend WithEvents txtOtherExpense As System.Windows.Forms.TextBox
    Friend WithEvents lblOtherExpense As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtDiscountUnit As System.Windows.Forms.Label
    Friend WithEvents txtWHTUnit As System.Windows.Forms.Label
    Friend WithEvents txtBankChargeUnit As System.Windows.Forms.Label
    Friend WithEvents txtOtherExpenseUnit As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents grbRefDoc As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtRefDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblRefDocDate As System.Windows.Forms.Label
    Friend WithEvents dtpRefDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRefDocCode As System.Windows.Forms.TextBox
    Friend WithEvents lblRefDoc As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRefAmount As System.Windows.Forms.Label
    Friend WithEvents lblRefAmountUnit As System.Windows.Forms.Label
    Friend WithEvents txtTotalCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDebitAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblDiscountAmount As System.Windows.Forms.Label
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherRevenue As System.Windows.Forms.TextBox
    Friend WithEvents lblOtherRev As System.Windows.Forms.Label
    Friend WithEvents txtOtherRevUnit As System.Windows.Forms.Label
    Friend WithEvents lblDebitAmount As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents txtInterest As System.Windows.Forms.TextBox
    Friend WithEvents lblInterest As System.Windows.Forms.Label
    Friend WithEvents txtInterestUnit As System.Windows.Forms.Label
    Friend WithEvents lblCreditAmount As System.Windows.Forms.Label
    Friend WithEvents txtCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtGrossUnit As System.Windows.Forms.Label
    Friend WithEvents lblAmountUnit As System.Windows.Forms.Label
    Friend WithEvents txtRefAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbCredit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents grbDebit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ibtnOtherCredit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnOtherDebit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReceiveDetail))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.cmbCode = New System.Windows.Forms.ComboBox
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.grbRefDoc = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtRefAmount = New System.Windows.Forms.TextBox
      Me.txtRefDocDate = New System.Windows.Forms.TextBox
      Me.lblRefAmount = New System.Windows.Forms.Label
      Me.lblRefDocDate = New System.Windows.Forms.Label
      Me.dtpRefDocDate = New System.Windows.Forms.DateTimePicker
      Me.txtRefDocCode = New System.Windows.Forms.TextBox
      Me.lblRefDoc = New System.Windows.Forms.Label
      Me.lblRefAmountUnit = New System.Windows.Forms.Label
      Me.txtTotalCreditAmount = New System.Windows.Forms.TextBox
      Me.txtTotalDebitAmount = New System.Windows.Forms.TextBox
      Me.grbCredit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblDiscountAmount = New System.Windows.Forms.Label
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox
      Me.txtWHT = New System.Windows.Forms.TextBox
      Me.lblWHT = New System.Windows.Forms.Label
      Me.txtDiscountUnit = New System.Windows.Forms.Label
      Me.txtWHTUnit = New System.Windows.Forms.Label
      Me.txtOtherExpenseUnit = New System.Windows.Forms.Label
      Me.txtOtherExpense = New System.Windows.Forms.TextBox
      Me.lblOtherExpense = New System.Windows.Forms.Label
      Me.lblBankCharge = New System.Windows.Forms.Label
      Me.txtBankCharge = New System.Windows.Forms.TextBox
      Me.txtBankChargeUnit = New System.Windows.Forms.Label
      Me.lblCreditAmount = New System.Windows.Forms.Label
      Me.txtCreditAmount = New System.Windows.Forms.TextBox
      Me.ibtnOtherCredit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.lblAmount = New System.Windows.Forms.Label
      Me.txtAmount = New System.Windows.Forms.TextBox
      Me.lblGross = New System.Windows.Forms.Label
      Me.txtGross = New System.Windows.Forms.TextBox
      Me.grbDebit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtInterest = New System.Windows.Forms.TextBox
      Me.lblInterest = New System.Windows.Forms.Label
      Me.txtInterestUnit = New System.Windows.Forms.Label
      Me.txtOtherRevenue = New System.Windows.Forms.TextBox
      Me.lblOtherRev = New System.Windows.Forms.Label
      Me.txtOtherRevUnit = New System.Windows.Forms.Label
      Me.txtDebitAmount = New System.Windows.Forms.TextBox
      Me.ibtnOtherDebit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblDebitAmount = New System.Windows.Forms.Label
      Me.lblItem = New System.Windows.Forms.Label
      Me.txtGrossUnit = New System.Windows.Forms.Label
      Me.lblAmountUnit = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.grbRefDoc.SuspendLayout()
      Me.grbCredit.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDebit.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.grbRefDoc)
      Me.grbDetail.Controls.Add(Me.txtTotalCreditAmount)
      Me.grbDetail.Controls.Add(Me.txtTotalDebitAmount)
      Me.grbDetail.Controls.Add(Me.grbCredit)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblAmount)
      Me.grbDetail.Controls.Add(Me.txtAmount)
      Me.grbDetail.Controls.Add(Me.lblGross)
      Me.grbDetail.Controls.Add(Me.txtGross)
      Me.grbDetail.Controls.Add(Me.grbDebit)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.txtGrossUnit)
      Me.grbDetail.Controls.Add(Me.lblAmountUnit)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.SystemColors.ControlText
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(736, 576)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "บันทึกจ่ายเงิน"
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(88, 24)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 0
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(208, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 331
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(72, 72)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 26
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(96, 72)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 27
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 25)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(72, 18)
      Me.lblCode.TabIndex = 7
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(8, 48)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(80, 18)
      Me.lblDocDate.TabIndex = 8
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 23)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(88, 48)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(124, 21)
      Me.txtDocDate.TabIndex = 2
      Me.txtDocDate.Text = ""
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(96, 48)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpDocDate.TabIndex = 9
      Me.dtpDocDate.TabStop = False
      '
      'grbRefDoc
      '
      Me.grbRefDoc.Controls.Add(Me.txtRefAmount)
      Me.grbRefDoc.Controls.Add(Me.txtRefDocDate)
      Me.grbRefDoc.Controls.Add(Me.lblRefAmount)
      Me.grbRefDoc.Controls.Add(Me.lblRefDocDate)
      Me.grbRefDoc.Controls.Add(Me.dtpRefDocDate)
      Me.grbRefDoc.Controls.Add(Me.txtRefDocCode)
      Me.grbRefDoc.Controls.Add(Me.lblRefDoc)
      Me.grbRefDoc.Controls.Add(Me.lblRefAmountUnit)
      Me.grbRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbRefDoc.Location = New System.Drawing.Point(248, 16)
      Me.grbRefDoc.Name = "grbRefDoc"
      Me.grbRefDoc.Size = New System.Drawing.Size(384, 72)
      Me.grbRefDoc.TabIndex = 0
      Me.grbRefDoc.TabStop = False
      Me.grbRefDoc.Text = "เอกสารอ้างอิง"
      '
      'txtRefAmount
      '
      Me.txtRefAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtRefAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefAmount, "")
      Me.txtRefAmount.Enabled = False
      Me.txtRefAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRefAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRefAmount, System.Drawing.Color.Empty)
      Me.txtRefAmount.Location = New System.Drawing.Point(112, 39)
      Me.Validator.SetMaxValue(Me.txtRefAmount, "")
      Me.Validator.SetMinValue(Me.txtRefAmount, "")
      Me.txtRefAmount.Name = "txtRefAmount"
      Me.Validator.SetRegularExpression(Me.txtRefAmount, "")
      Me.Validator.SetRequired(Me.txtRefAmount, False)
      Me.txtRefAmount.Size = New System.Drawing.Size(104, 21)
      Me.txtRefAmount.TabIndex = 6
      Me.txtRefAmount.TabStop = False
      Me.txtRefAmount.Text = ""
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
      Me.txtRefDocDate.Location = New System.Drawing.Point(256, 16)
      Me.Validator.SetMaxValue(Me.txtRefDocDate, "")
      Me.Validator.SetMinValue(Me.txtRefDocDate, "")
      Me.txtRefDocDate.Name = "txtRefDocDate"
      Me.Validator.SetRegularExpression(Me.txtRefDocDate, "")
      Me.Validator.SetRequired(Me.txtRefDocDate, False)
      Me.txtRefDocDate.Size = New System.Drawing.Size(96, 21)
      Me.txtRefDocDate.TabIndex = 3
      Me.txtRefDocDate.TabStop = False
      Me.txtRefDocDate.Text = ""
      '
      'lblRefAmount
      '
      Me.lblRefAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefAmount.ForeColor = System.Drawing.Color.Black
      Me.lblRefAmount.Location = New System.Drawing.Point(8, 40)
      Me.lblRefAmount.Name = "lblRefAmount"
      Me.lblRefAmount.Size = New System.Drawing.Size(104, 18)
      Me.lblRefAmount.TabIndex = 5
      Me.lblRefAmount.Text = "ยอดเงิน:"
      Me.lblRefAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefDocDate
      '
      Me.lblRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRefDocDate.Location = New System.Drawing.Point(216, 17)
      Me.lblRefDocDate.Name = "lblRefDocDate"
      Me.lblRefDocDate.Size = New System.Drawing.Size(40, 18)
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
      Me.dtpRefDocDate.Location = New System.Drawing.Point(256, 16)
      Me.dtpRefDocDate.Name = "dtpRefDocDate"
      Me.dtpRefDocDate.Size = New System.Drawing.Size(116, 21)
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
      Me.txtRefDocCode.Size = New System.Drawing.Size(104, 21)
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
      'lblRefAmountUnit
      '
      Me.lblRefAmountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefAmountUnit.ForeColor = System.Drawing.Color.Black
      Me.lblRefAmountUnit.Location = New System.Drawing.Point(216, 40)
      Me.lblRefAmountUnit.Name = "lblRefAmountUnit"
      Me.lblRefAmountUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblRefAmountUnit.TabIndex = 7
      Me.lblRefAmountUnit.Text = "บาท"
      Me.lblRefAmountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtTotalCreditAmount
      '
      Me.txtTotalCreditAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtTotalCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtTotalCreditAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalCreditAmount, "")
      Me.txtTotalCreditAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTotalCreditAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalCreditAmount, System.Drawing.Color.Empty)
      Me.txtTotalCreditAmount.Location = New System.Drawing.Point(168, 416)
      Me.Validator.SetMaxValue(Me.txtTotalCreditAmount, "")
      Me.Validator.SetMinValue(Me.txtTotalCreditAmount, "")
      Me.txtTotalCreditAmount.Name = "txtTotalCreditAmount"
      Me.txtTotalCreditAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalCreditAmount, "")
      Me.Validator.SetRequired(Me.txtTotalCreditAmount, False)
      Me.txtTotalCreditAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtTotalCreditAmount.TabIndex = 16
      Me.txtTotalCreditAmount.TabStop = False
      Me.txtTotalCreditAmount.Text = ""
      '
      'txtTotalDebitAmount
      '
      Me.txtTotalDebitAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtTotalDebitAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtTotalDebitAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalDebitAmount, "")
      Me.txtTotalDebitAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTotalDebitAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalDebitAmount, System.Drawing.Color.Empty)
      Me.txtTotalDebitAmount.Location = New System.Drawing.Point(544, 416)
      Me.Validator.SetMaxValue(Me.txtTotalDebitAmount, "")
      Me.Validator.SetMinValue(Me.txtTotalDebitAmount, "")
      Me.txtTotalDebitAmount.Name = "txtTotalDebitAmount"
      Me.txtTotalDebitAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalDebitAmount, "")
      Me.Validator.SetRequired(Me.txtTotalDebitAmount, False)
      Me.txtTotalDebitAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtTotalDebitAmount.TabIndex = 15
      Me.txtTotalDebitAmount.TabStop = False
      Me.txtTotalDebitAmount.Text = ""
      '
      'grbCredit
      '
      Me.grbCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbCredit.Controls.Add(Me.lblDiscountAmount)
      Me.grbCredit.Controls.Add(Me.txtDiscountAmount)
      Me.grbCredit.Controls.Add(Me.txtWHT)
      Me.grbCredit.Controls.Add(Me.lblWHT)
      Me.grbCredit.Controls.Add(Me.txtDiscountUnit)
      Me.grbCredit.Controls.Add(Me.txtWHTUnit)
      Me.grbCredit.Controls.Add(Me.txtOtherExpenseUnit)
      Me.grbCredit.Controls.Add(Me.txtOtherExpense)
      Me.grbCredit.Controls.Add(Me.lblOtherExpense)
      Me.grbCredit.Controls.Add(Me.lblBankCharge)
      Me.grbCredit.Controls.Add(Me.txtBankCharge)
      Me.grbCredit.Controls.Add(Me.txtBankChargeUnit)
      Me.grbCredit.Controls.Add(Me.lblCreditAmount)
      Me.grbCredit.Controls.Add(Me.txtCreditAmount)
      Me.grbCredit.Controls.Add(Me.ibtnOtherCredit)
      Me.grbCredit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbCredit.Location = New System.Drawing.Point(16, 424)
      Me.grbCredit.Name = "grbCredit"
      Me.grbCredit.Size = New System.Drawing.Size(336, 128)
      Me.grbCredit.TabIndex = 5
      Me.grbCredit.TabStop = False
      Me.grbCredit.Text = "ยอดหักจำนวนรับ"
      '
      'lblDiscountAmount
      '
      Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscountAmount.ForeColor = System.Drawing.Color.Black
      Me.lblDiscountAmount.Location = New System.Drawing.Point(16, 16)
      Me.lblDiscountAmount.Name = "lblDiscountAmount"
      Me.lblDiscountAmount.Size = New System.Drawing.Size(128, 18)
      Me.lblDiscountAmount.TabIndex = 2
      Me.lblDiscountAmount.Text = "ส่วนลดจ่าย:"
      Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDiscountAmount
      '
      Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.txtDiscountAmount.Location = New System.Drawing.Point(152, 15)
      Me.Validator.SetMaxValue(Me.txtDiscountAmount, "")
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtDiscountAmount.TabIndex = 0
      Me.txtDiscountAmount.Text = ""
      '
      'txtWHT
      '
      Me.txtWHT.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtWHT, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWHT, "")
      Me.txtWHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtWHT, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWHT, System.Drawing.Color.Empty)
      Me.txtWHT.Location = New System.Drawing.Point(152, 78)
      Me.Validator.SetMaxValue(Me.txtWHT, "")
      Me.Validator.SetMinValue(Me.txtWHT, "")
      Me.txtWHT.Name = "txtWHT"
      Me.txtWHT.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWHT, "")
      Me.Validator.SetRequired(Me.txtWHT, False)
      Me.txtWHT.Size = New System.Drawing.Size(136, 21)
      Me.txtWHT.TabIndex = 5
      Me.txtWHT.TabStop = False
      Me.txtWHT.Text = ""
      '
      'lblWHT
      '
      Me.lblWHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWHT.ForeColor = System.Drawing.Color.Black
      Me.lblWHT.Location = New System.Drawing.Point(16, 79)
      Me.lblWHT.Name = "lblWHT"
      Me.lblWHT.Size = New System.Drawing.Size(128, 18)
      Me.lblWHT.TabIndex = 4
      Me.lblWHT.Text = "ภาษีหัก ณ ที่จ่าย:"
      Me.lblWHT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDiscountUnit
      '
      Me.txtDiscountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtDiscountUnit.ForeColor = System.Drawing.Color.Black
      Me.txtDiscountUnit.Location = New System.Drawing.Point(288, 16)
      Me.txtDiscountUnit.Name = "txtDiscountUnit"
      Me.txtDiscountUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtDiscountUnit.TabIndex = 8
      Me.txtDiscountUnit.Text = "บาท"
      Me.txtDiscountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtWHTUnit
      '
      Me.txtWHTUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtWHTUnit.ForeColor = System.Drawing.Color.Black
      Me.txtWHTUnit.Location = New System.Drawing.Point(288, 79)
      Me.txtWHTUnit.Name = "txtWHTUnit"
      Me.txtWHTUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtWHTUnit.TabIndex = 10
      Me.txtWHTUnit.Text = "บาท"
      Me.txtWHTUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtOtherExpenseUnit
      '
      Me.txtOtherExpenseUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtOtherExpenseUnit.ForeColor = System.Drawing.Color.Black
      Me.txtOtherExpenseUnit.Location = New System.Drawing.Point(288, 58)
      Me.txtOtherExpenseUnit.Name = "txtOtherExpenseUnit"
      Me.txtOtherExpenseUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtOtherExpenseUnit.TabIndex = 8
      Me.txtOtherExpenseUnit.Text = "บาท"
      Me.txtOtherExpenseUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtOtherExpense
      '
      Me.Validator.SetDataType(Me.txtOtherExpense, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtOtherExpense, "")
      Me.txtOtherExpense.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtOtherExpense, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtOtherExpense, System.Drawing.Color.Empty)
      Me.txtOtherExpense.Location = New System.Drawing.Point(152, 57)
      Me.Validator.SetMaxValue(Me.txtOtherExpense, "")
      Me.Validator.SetMinValue(Me.txtOtherExpense, "")
      Me.txtOtherExpense.Name = "txtOtherExpense"
      Me.Validator.SetRegularExpression(Me.txtOtherExpense, "")
      Me.Validator.SetRequired(Me.txtOtherExpense, False)
      Me.txtOtherExpense.Size = New System.Drawing.Size(136, 21)
      Me.txtOtherExpense.TabIndex = 2
      Me.txtOtherExpense.Text = ""
      '
      'lblOtherExpense
      '
      Me.lblOtherExpense.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOtherExpense.ForeColor = System.Drawing.Color.Black
      Me.lblOtherExpense.Location = New System.Drawing.Point(16, 58)
      Me.lblOtherExpense.Name = "lblOtherExpense"
      Me.lblOtherExpense.Size = New System.Drawing.Size(128, 18)
      Me.lblOtherExpense.TabIndex = 7
      Me.lblOtherExpense.Text = "ค่าใช้จ่ายอื่นๆ:"
      Me.lblOtherExpense.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBankCharge
      '
      Me.lblBankCharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankCharge.ForeColor = System.Drawing.Color.Black
      Me.lblBankCharge.Location = New System.Drawing.Point(16, 37)
      Me.lblBankCharge.Name = "lblBankCharge"
      Me.lblBankCharge.Size = New System.Drawing.Size(128, 18)
      Me.lblBankCharge.TabIndex = 5
      Me.lblBankCharge.Text = "ค่าธรรมเนียมธนาคาร:"
      Me.lblBankCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBankCharge
      '
      Me.Validator.SetDataType(Me.txtBankCharge, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankCharge, "")
      Me.txtBankCharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankCharge, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankCharge, System.Drawing.Color.Empty)
      Me.txtBankCharge.Location = New System.Drawing.Point(152, 36)
      Me.Validator.SetMaxValue(Me.txtBankCharge, "")
      Me.Validator.SetMinValue(Me.txtBankCharge, "")
      Me.txtBankCharge.Name = "txtBankCharge"
      Me.Validator.SetRegularExpression(Me.txtBankCharge, "")
      Me.Validator.SetRequired(Me.txtBankCharge, False)
      Me.txtBankCharge.Size = New System.Drawing.Size(136, 21)
      Me.txtBankCharge.TabIndex = 1
      Me.txtBankCharge.Text = ""
      '
      'txtBankChargeUnit
      '
      Me.txtBankChargeUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBankChargeUnit.ForeColor = System.Drawing.Color.Black
      Me.txtBankChargeUnit.Location = New System.Drawing.Point(288, 37)
      Me.txtBankChargeUnit.Name = "txtBankChargeUnit"
      Me.txtBankChargeUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtBankChargeUnit.TabIndex = 6
      Me.txtBankChargeUnit.Text = "บาท"
      Me.txtBankChargeUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblCreditAmount
      '
      Me.lblCreditAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCreditAmount.ForeColor = System.Drawing.Color.Black
      Me.lblCreditAmount.Location = New System.Drawing.Point(8, 100)
      Me.lblCreditAmount.Name = "lblCreditAmount"
      Me.lblCreditAmount.Size = New System.Drawing.Size(136, 18)
      Me.lblCreditAmount.TabIndex = 9
      Me.lblCreditAmount.Text = "ยอดหักจำนวนรับอื่น:"
      Me.lblCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCreditAmount
      '
      Me.Validator.SetDataType(Me.txtCreditAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCreditAmount, "")
      Me.txtCreditAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCreditAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCreditAmount, System.Drawing.Color.Empty)
      Me.txtCreditAmount.Location = New System.Drawing.Point(152, 99)
      Me.Validator.SetMaxValue(Me.txtCreditAmount, "")
      Me.Validator.SetMinValue(Me.txtCreditAmount, "")
      Me.txtCreditAmount.Name = "txtCreditAmount"
      Me.txtCreditAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCreditAmount, "")
      Me.Validator.SetRequired(Me.txtCreditAmount, False)
      Me.txtCreditAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtCreditAmount.TabIndex = 10
      Me.txtCreditAmount.TabStop = False
      Me.txtCreditAmount.Text = ""
      '
      'ibtnOtherCredit
      '
      Me.ibtnOtherCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnOtherCredit.Image = CType(resources.GetObject("ibtnOtherCredit.Image"), System.Drawing.Image)
      Me.ibtnOtherCredit.Location = New System.Drawing.Point(288, 98)
      Me.ibtnOtherCredit.Name = "ibtnOtherCredit"
      Me.ibtnOtherCredit.Size = New System.Drawing.Size(24, 23)
      Me.ibtnOtherCredit.TabIndex = 11
      Me.ibtnOtherCredit.TabStop = False
      Me.ibtnOtherCredit.ThemedImage = CType(resources.GetObject("ibtnOtherCredit.ThemedImage"), System.Drawing.Bitmap)
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
      Me.tgItem.Location = New System.Drawing.Point(16, 96)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(768, 272)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 4
      Me.tgItem.TreeManager = Nothing
      '
      'txtNote
      '
      Me.txtNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(88, 368)
      Me.txtNote.MaxLength = 250
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(264, 42)
      Me.txtNote.TabIndex = 3
      Me.txtNote.TabStop = False
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(16, 368)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(72, 18)
      Me.lblNote.TabIndex = 10
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAmount
      '
      Me.lblAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(440, 527)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(104, 18)
      Me.lblAmount.TabIndex = 17
      Me.lblAmount.Text = "จำนวนเงินที่ต้องรับ:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAmount
      '
      Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtAmount.ForeColor = System.Drawing.Color.Red
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(544, 520)
      Me.Validator.SetMaxValue(Me.txtAmount, "")
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.txtAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, False)
      Me.txtAmount.Size = New System.Drawing.Size(136, 33)
      Me.txtAmount.TabIndex = 18
      Me.txtAmount.TabStop = False
      Me.txtAmount.Text = ""
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.ForeColor = System.Drawing.Color.Black
      Me.lblGross.Location = New System.Drawing.Point(424, 368)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(120, 18)
      Me.lblGross.TabIndex = 12
      Me.lblGross.Text = "รวมยอดเงินรับทั้งสิ้น:"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGross
      '
      Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.txtGross.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(544, 368)
      Me.Validator.SetMaxValue(Me.txtGross, "")
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(136, 33)
      Me.txtGross.TabIndex = 13
      Me.txtGross.TabStop = False
      Me.txtGross.Text = ""
      '
      'grbDebit
      '
      Me.grbDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbDebit.Controls.Add(Me.txtInterest)
      Me.grbDebit.Controls.Add(Me.lblInterest)
      Me.grbDebit.Controls.Add(Me.txtInterestUnit)
      Me.grbDebit.Controls.Add(Me.txtOtherRevenue)
      Me.grbDebit.Controls.Add(Me.lblOtherRev)
      Me.grbDebit.Controls.Add(Me.txtOtherRevUnit)
      Me.grbDebit.Controls.Add(Me.txtDebitAmount)
      Me.grbDebit.Controls.Add(Me.ibtnOtherDebit)
      Me.grbDebit.Controls.Add(Me.lblDebitAmount)
      Me.grbDebit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDebit.Location = New System.Drawing.Point(392, 424)
      Me.grbDebit.Name = "grbDebit"
      Me.grbDebit.Size = New System.Drawing.Size(336, 88)
      Me.grbDebit.TabIndex = 6
      Me.grbDebit.TabStop = False
      Me.grbDebit.Text = "ยอดเพิ่มจำนวนรับ"
      '
      'txtInterest
      '
      Me.Validator.SetDataType(Me.txtInterest, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtInterest, "")
      Me.txtInterest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtInterest, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInterest, System.Drawing.Color.Empty)
      Me.txtInterest.Location = New System.Drawing.Point(152, 15)
      Me.Validator.SetMaxValue(Me.txtInterest, "")
      Me.Validator.SetMinValue(Me.txtInterest, "")
      Me.txtInterest.Name = "txtInterest"
      Me.Validator.SetRegularExpression(Me.txtInterest, "")
      Me.Validator.SetRequired(Me.txtInterest, False)
      Me.txtInterest.Size = New System.Drawing.Size(136, 21)
      Me.txtInterest.TabIndex = 0
      Me.txtInterest.Text = ""
      '
      'lblInterest
      '
      Me.lblInterest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInterest.ForeColor = System.Drawing.Color.Black
      Me.lblInterest.Location = New System.Drawing.Point(16, 16)
      Me.lblInterest.Name = "lblInterest"
      Me.lblInterest.Size = New System.Drawing.Size(136, 18)
      Me.lblInterest.TabIndex = 3
      Me.lblInterest.Text = "ดอกเบี้ยรับ:"
      Me.lblInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtInterestUnit
      '
      Me.txtInterestUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtInterestUnit.ForeColor = System.Drawing.Color.Black
      Me.txtInterestUnit.Location = New System.Drawing.Point(288, 16)
      Me.txtInterestUnit.Name = "txtInterestUnit"
      Me.txtInterestUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtInterestUnit.TabIndex = 4
      Me.txtInterestUnit.Text = "บาท"
      Me.txtInterestUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtOtherRevenue
      '
      Me.Validator.SetDataType(Me.txtOtherRevenue, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtOtherRevenue, "")
      Me.txtOtherRevenue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtOtherRevenue, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtOtherRevenue, System.Drawing.Color.Empty)
      Me.txtOtherRevenue.Location = New System.Drawing.Point(152, 36)
      Me.Validator.SetMaxValue(Me.txtOtherRevenue, "")
      Me.Validator.SetMinValue(Me.txtOtherRevenue, "")
      Me.txtOtherRevenue.Name = "txtOtherRevenue"
      Me.Validator.SetRegularExpression(Me.txtOtherRevenue, "")
      Me.Validator.SetRequired(Me.txtOtherRevenue, False)
      Me.txtOtherRevenue.Size = New System.Drawing.Size(136, 21)
      Me.txtOtherRevenue.TabIndex = 1
      Me.txtOtherRevenue.Text = ""
      '
      'lblOtherRev
      '
      Me.lblOtherRev.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOtherRev.ForeColor = System.Drawing.Color.Black
      Me.lblOtherRev.Location = New System.Drawing.Point(8, 37)
      Me.lblOtherRev.Name = "lblOtherRev"
      Me.lblOtherRev.Size = New System.Drawing.Size(144, 18)
      Me.lblOtherRev.TabIndex = 3
      Me.lblOtherRev.Text = "รายได้อื่น:"
      Me.lblOtherRev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtOtherRevUnit
      '
      Me.txtOtherRevUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtOtherRevUnit.ForeColor = System.Drawing.Color.Black
      Me.txtOtherRevUnit.Location = New System.Drawing.Point(288, 37)
      Me.txtOtherRevUnit.Name = "txtOtherRevUnit"
      Me.txtOtherRevUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtOtherRevUnit.TabIndex = 9
      Me.txtOtherRevUnit.Text = "บาท"
      Me.txtOtherRevUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtDebitAmount
      '
      Me.Validator.SetDataType(Me.txtDebitAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDebitAmount, "")
      Me.txtDebitAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDebitAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDebitAmount, System.Drawing.Color.Empty)
      Me.txtDebitAmount.Location = New System.Drawing.Point(152, 57)
      Me.Validator.SetMaxValue(Me.txtDebitAmount, "")
      Me.Validator.SetMinValue(Me.txtDebitAmount, "")
      Me.txtDebitAmount.Name = "txtDebitAmount"
      Me.txtDebitAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDebitAmount, "")
      Me.Validator.SetRequired(Me.txtDebitAmount, False)
      Me.txtDebitAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtDebitAmount.TabIndex = 7
      Me.txtDebitAmount.TabStop = False
      Me.txtDebitAmount.Text = ""
      '
      'ibtnOtherDebit
      '
      Me.ibtnOtherDebit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnOtherDebit.Image = CType(resources.GetObject("ibtnOtherDebit.Image"), System.Drawing.Image)
      Me.ibtnOtherDebit.Location = New System.Drawing.Point(288, 56)
      Me.ibtnOtherDebit.Name = "ibtnOtherDebit"
      Me.ibtnOtherDebit.Size = New System.Drawing.Size(24, 23)
      Me.ibtnOtherDebit.TabIndex = 11
      Me.ibtnOtherDebit.TabStop = False
      Me.ibtnOtherDebit.ThemedImage = CType(resources.GetObject("ibtnOtherDebit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDebitAmount
      '
      Me.lblDebitAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDebitAmount.ForeColor = System.Drawing.Color.Black
      Me.lblDebitAmount.Location = New System.Drawing.Point(8, 58)
      Me.lblDebitAmount.Name = "lblDebitAmount"
      Me.lblDebitAmount.Size = New System.Drawing.Size(144, 18)
      Me.lblDebitAmount.TabIndex = 6
      Me.lblDebitAmount.Text = "ยอดเพิ่มจำนวนรับอื่น:"
      Me.lblDebitAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(16, 80)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(56, 18)
      Me.lblItem.TabIndex = 11
      Me.lblItem.Text = "รับโดย:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGrossUnit
      '
      Me.txtGrossUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtGrossUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtGrossUnit.ForeColor = System.Drawing.Color.Black
      Me.txtGrossUnit.Location = New System.Drawing.Point(680, 368)
      Me.txtGrossUnit.Name = "txtGrossUnit"
      Me.txtGrossUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtGrossUnit.TabIndex = 14
      Me.txtGrossUnit.Text = "บาท"
      Me.txtGrossUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAmountUnit
      '
      Me.lblAmountUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAmountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmountUnit.ForeColor = System.Drawing.Color.Black
      Me.lblAmountUnit.Location = New System.Drawing.Point(680, 527)
      Me.lblAmountUnit.Name = "lblAmountUnit"
      Me.lblAmountUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblAmountUnit.TabIndex = 19
      Me.lblAmountUnit.Text = "บาท"
      Me.lblAmountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      'ReceiveDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "ReceiveDetail"
      Me.Size = New System.Drawing.Size(744, 592)
      Me.grbDetail.ResumeLayout(False)
      Me.grbRefDoc.ResumeLayout(False)
      Me.grbCredit.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDebit.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabeltext "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblBankCharge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblBankCharge}")
      Me.lblWHT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblWHT}")
      Me.lblOtherExpense.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblOtherExpense}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblNote}")
      Me.txtDiscountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.txtWHTUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.txtBankChargeUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.txtOtherExpenseUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblItem}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.grbDetail}")
      Me.grbRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.grbRefDoc}")
      Me.lblRefDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblRefDocDate}")
      Me.lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblRefDoc}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblCode}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblDocDate}")
      Me.lblRefAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblRefAmount}")
      Me.lblRefAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.grbDebit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.grbDebit}")
      Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblDiscountAmount}")
      Me.lblOtherRev.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblOtherRev}")
      Me.txtOtherRevUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblDebitAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblDebitAmount}")
      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblAmount}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblGross}")
      Me.grbCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.grbCredit}")
      Me.lblInterest.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblInterest}")
      Me.txtInterestUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblCreditAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.lblCreditAmount}")
      Me.txtGrossUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
    End Sub
#End Region

#Region "Members"
    Private m_entity As ISimpleEntity
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_receive As Receive

    Private m_tableStyleEnable As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      m_tableStyleEnable = New Hashtable

      Dim dt As TreeTable = Receive.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      EventWiring()

    End Sub
#End Region

#Region "Properties"

#End Region

#Region "Style"
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Receive"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "receivei_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "receivei_linenumber"

      Dim csType As DataGridComboColumn
      If TypeOf Me.m_entity Is PettyCashClosed Then
        csType = New DataGridComboColumn("receivei_entityType", CodeDescription.GetCodeList("receivei_entityType", "not code_value in (27,71)"), "code_description", "code_value")
      ElseIf TypeOf Me.m_entity Is AdvanceReceive Then
        csType = New DataGridComboColumn("receivei_entityType", CodeDescription.GetCodeList("receivei_entityType", "code_value <>" & Me.m_entity.EntityId), "code_description", "code_value")
      ElseIf TypeOf Me.m_entity Is GoodsSold Then
        csType = New DataGridComboColumn("receivei_entityType", CodeDescription.GetCodeList("receivei_entityType", "code_value <> 71"), "code_description", "code_value")
        'ElseIf TypeOf Me.m_entity Is AdvanceMoneyClosed Then
        'csType = New DataGridComboColumn("receivei_entityType", CodeDescription.GetCodeList("receivei_entityType", "not code_value in (27,71)"), "code_description", "code_value")
      Else
        csType = New DataGridComboColumn("receivei_entityType", CodeDescription.GetCodeList("receivei_entityType"), "code_description", "code_value")
      End If

      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.TypeHeaderText}")
      csType.Width = 70
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf ButtonClicked

      Dim csBACode As New TreeTextColumn
      csBACode.MappingName = "BACode"
      csBACode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.BankAccountHeaderText}")
      csBACode.NullText = ""
      csBACode.Width = 80
      csBACode.TextBox.Name = "BACode"

      Dim csBAButton As New DataGridButtonColumn
      csBAButton.MappingName = "BAButton"
      csBAButton.HeaderText = ""
      csBAButton.NullText = ""
      AddHandler csBAButton.Click, AddressOf ButtonClicked

      Dim csBAName As New TreeTextColumn
      csBAName.MappingName = "BAName"
      csBAName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.BANameHeaderText}")
      csBAName.NullText = ""
      csBAName.Width = 180
      csBAName.TextBox.Name = "BAName"
      csBAName.ReadOnly = True

      Dim csDueDate As New DataGridTimePickerColumn
      csDueDate.MappingName = "DueDate"
      csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.DueDateHeaderText}")
      csDueDate.NullText = ""
      csDueDate.Width = 100

      Dim csRealAmount As New TreeTextColumn
      csRealAmount.MappingName = "RealAmount"
      csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.RealAmountHeaderText}")
      csRealAmount.NullText = ""
      csRealAmount.DataAlignment = HorizontalAlignment.Right
      csRealAmount.Format = "#,###.##"
      csRealAmount.TextBox.Name = "RealAmount"
      csRealAmount.Width = 60

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "receivei_amt"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "receivei_amt"
      csAmount.Width = 60

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "receivei_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 100
      csNote.TextBox.Name = "receivei_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csBACode)
      dst.GridColumnStyles.Add(csBAButton)
      dst.GridColumnStyles.Add(csBAName)
      dst.GridColumnStyles.Add(csDueDate)
      dst.GridColumnStyles.Add(csRealAmount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 3 Then
        Dim btnValue As String = Me.m_receive.ItemTable.Rows(e.Row)("Button").ToString.ToLower
        If btnValue = "invisible" Then
          Return
        End If
        Me.ItemButtonClick(e)
      Else
        Dim btnValue As String = Me.m_receive.ItemTable.Rows(e.Row)("BAButton").ToString.ToLower
        If btnValue = "invisible" Then
          Return
        End If
        Me.BAButtonClick(e)
      End If
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value >= 4) OrElse Me.m_entity.Canceled Then
        SetEnabledControls(False)
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        SetEnabledControls(True)
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
    End Sub
    Private Sub SetEnabledControls(ByVal flag As Boolean)
      ' textbox
      cmbCode.Enabled = flag
      txtNote.Enabled = flag
      txtDocDate.Enabled = flag
      dtpDocDate.Enabled = flag
      ' group box
      grbDebit.Enabled = flag
      grbCredit.Enabled = flag
      ' button 
      chkAutorun.Enabled = flag
      ibtnBlank.Enabled = flag
      ibtnDelRow.Enabled = flag

      ' tgItem  Set ตาม Style ที่กำหนดไว้ใน DataTableStyle
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDiscountAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtOtherRevenue.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtInterest.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBankCharge.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtOtherExpense.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_receive Is Nothing Then
        Return
      End If

      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_receive.ItemTable
      If Not Me.m_treeManager.GridTableStyle Is Nothing Then
        If Me.m_treeManager.GridTableStyle.GridColumnStyles.Contains("Button") Then
          Dim btnCol As DataGridButtonColumn = CType(Me.m_treeManager.GridTableStyle.GridColumnStyles("Button"), DataGridButtonColumn)
          RemoveHandler btnCol.Click, AddressOf ButtonClicked
        End If
        If Me.m_treeManager.GridTableStyle.GridColumnStyles.Contains("BAButton") Then
          Dim btnCol As DataGridButtonColumn = CType(Me.m_treeManager.GridTableStyle.GridColumnStyles("BAButton"), DataGridButtonColumn)
          RemoveHandler btnCol.Click, AddressOf ButtonClicked
        End If
      End If
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager.SetTableStyle(dst)
      AddHandler Me.m_receive.PropertyChanged, AddressOf PropChanged
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      cmbCode.Items.Clear()
      cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_receive.Code

      m_oldCode = m_receive.Code
      Me.chkAutorun.Checked = Me.m_receive.AutoGen
      Me.UpdateAutogenStatus()
      txtNote.Text = Me.m_receive.Note
      txtDocDate.Text = MinDateToNull(Me.m_receive.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_receive.DocDate)

      RefreshBlankGrid()

      Me.txtDiscountAmount.Text = Configuration.FormatToString(Me.m_receive.DiscountAmount, DigitConfig.Price)
      Me.txtOtherRevenue.Text = Configuration.FormatToString(Me.m_receive.OtherRevenue, DigitConfig.Price)
      Me.txtWHT.Text = Configuration.FormatToString(Me.m_receive.WitholdingTax, DigitConfig.Price)
      Me.txtOtherExpense.Text = Configuration.FormatToString(Me.m_receive.OtherExpense, DigitConfig.Price)

      Me.txtBankCharge.Text = Configuration.FormatToString(Me.m_receive.BankCharge, DigitConfig.Price)
      Me.txtInterest.Text = Configuration.FormatToString(Me.m_receive.Interest, DigitConfig.Price)

      Me.m_receive.UpdateGross()
      UpdateAmount()
      UpdateRefDoc()

      Me.txtNote.Text = Me.m_receive.Note

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateRefDoc()
      Me.txtRefDocCode.Text = Me.m_receive.RefDoc.Code
      Me.txtRefDocDate.Text = MinDateToNull(Me.m_receive.RefDoc.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      Me.dtpRefDocDate.Value = MinDateToNow(Me.m_receive.RefDoc.Date)
      Me.txtRefAmount.Text = Configuration.FormatToString(m_receive.RefDoc.AmountToReceive, DigitConfig.Price)
    End Sub
    Private Sub UpdateAmount()
      Dim oldFlag As Boolean = m_isInitialized
      m_isInitialized = False
      Me.txtTotalDebitAmount.Text = Configuration.FormatToString(Me.m_receive.SumDebitAmount, DigitConfig.Price)
      Me.txtTotalCreditAmount.Text = Configuration.FormatToString(Me.m_receive.SumCreditAmount, DigitConfig.Price)
      Me.txtGross.Text = Configuration.FormatToString(Me.m_receive.Gross, DigitConfig.Price)
      Me.txtAmount.Text = Configuration.FormatToString(Me.m_receive.Amount, DigitConfig.Price)
      Me.txtDebitAmount.Text = Configuration.FormatToString(Me.m_receive.DebitAmount, DigitConfig.Price)
      Me.txtCreditAmount.Text = Configuration.FormatToString(Me.m_receive.CreditAmount, DigitConfig.Price)
      m_isInitialized = oldFlag
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_receive Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          Me.m_receive.Code = cmbCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_receive.Note = txtNote.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_receive.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_receive.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_receive.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_receive.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            Me.m_receive.DocDate = Date.Now
            Me.m_receive.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtdiscountamount"
          Dim value As Decimal = 0
          If IsNumeric(txtDiscountAmount.Text) Then
            value = CDec(txtDiscountAmount.Text)
          End If
          Me.m_receive.DiscountAmount = value
          'txtDiscountAmount.Text = Configuration.FormatToString(Me.m_receive.DiscountAmount, DigitConfig.Price)
          Me.UpdateAmount()
          dirtyFlag = True
        Case "txtotherrevenue"
          Dim value As Decimal = 0
          If IsNumeric(txtOtherRevenue.Text) Then
            value = CDec(txtOtherRevenue.Text)
          End If
          Me.m_receive.OtherRevenue = value
          'txtOtherRevenue.Text = Configuration.FormatToString(Me.m_receive.OtherRevenue, DigitConfig.Price)
          Me.UpdateAmount()
          dirtyFlag = True
        Case "txtinterest"
          Dim value As Decimal = 0
          If IsNumeric(txtInterest.Text) Then
            value = CDec(txtInterest.Text)
          End If
          Me.m_receive.Interest = value
          'txtInterest.Text = Configuration.FormatToString(Me.m_receive.Interest, DigitConfig.Price)
          Me.UpdateAmount()
          dirtyFlag = True
        Case "txtbankcharge"
          Dim value As Decimal = 0
          If IsNumeric(txtBankCharge.Text) Then
            value = CDec(txtBankCharge.Text)
          End If
          Me.m_receive.BankCharge = value
          'txtBankCharge.Text = Configuration.FormatToString(Me.m_receive.BankCharge, DigitConfig.Price)
          Me.UpdateAmount()
          dirtyFlag = True
        Case "txtotherexpense"
          Dim value As Decimal = 0
          If IsNumeric(txtOtherExpense.Text) Then
            value = CDec(txtOtherExpense.Text)
          End If
          Me.m_receive.OtherExpense = value
          'txtOtherExpense.Text = Configuration.FormatToString(Me.m_receive.OtherExpense, DigitConfig.Price)
          Me.UpdateAmount()
          dirtyFlag = True
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()
      'If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '    " " & m_entity.CancelDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.CancelPerson.Name
      'ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '    " " & m_entity.LastEditDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.LastEditor.Name
      'ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '    " " & m_entity.OriginDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.Originator.Name
      'Else
      '    lblStatus.Text = ""
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = Value
          If Not m_receive Is Nothing Then
            RemoveHandler Me.m_receive.PropertyChanged, AddressOf PropChanged
            Me.m_receive = Nothing
          End If
          If TypeOf m_entity Is IReceivable Then
            Dim receiveRefDoc As IReceivable = CType(m_entity, IReceivable)
            m_receive = receiveRefDoc.Receive
            If m_receive Is Nothing Then
              m_receive = New Receive
              m_receive.RefDoc.Receive = m_receive
            End If
            m_receive.RefDoc = receiveRefDoc
          End If
        End If
        If Not Me.m_receive Is Nothing Then
          Me.m_receive.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
    End Sub
#End Region

#Region "Event Handlers"
    Public Sub BAButtonClick(ByVal e As ButtonColumnEventArgs)
      If Me.m_receive.ItemTable.Rows(e.Row).IsNull("receivei_entityType") Then
        Return
      ElseIf CInt(Me.m_receive.ItemTable.Rows(e.Row)("receivei_entityType")) = 0 Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBA)
    End Sub
    Private Sub SetBA(ByVal ba As ISimpleEntity)
      Me.m_treeManager.SelectedRow("BACode") = ba.Code
    End Sub
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If Me.m_receive.ItemTable.Rows(e.Row).IsNull("receivei_entityType") Then
        If TypeOf Me.m_entity Is AdvanceReceive Then
          Dim filterEntities(0) As ArrayList
          For i As Integer = 0 To 0
            filterEntities(i) = New ArrayList
            If Not Me.m_receive.RefDoc.Payer Is Nothing Then
              If TypeOf Me.m_receive.RefDoc.Payer Is Customer Then
                filterEntities(i).Add(Me.m_receive.RefDoc.Payer)
              End If
            End If
          Next
          Dim filters(0)() As Filter
          filters(0) = New Filter() {New Filter("IDList", GenIDListFromDataTable(27)), New Filter("showOnlyAmountMoreThanZero", True)}
          Dim entities(0) As ISimpleEntity
          entities(0) = New IncomingCheck
          myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
        Else
          Dim filterEntities(1) As ArrayList
          For i As Integer = 0 To 1
            filterEntities(i) = New ArrayList
            If Not Me.m_receive.RefDoc.Payer Is Nothing Then
              If TypeOf Me.m_receive.RefDoc.Payer Is Customer Then
                filterEntities(i).Add(Me.m_receive.RefDoc.Payer)
              End If
            End If
          Next
          Dim filters(1)() As Filter
          filters(0) = New Filter() {New Filter("IDList", GenIDListFromDataTable(27)), New Filter("showOnlyAmountMoreThanZero", True)}
          filters(1) = New Filter() {New Filter("IDList", GenIDListFromDataTable(71))}
          Dim entities(1) As ISimpleEntity
          entities(0) = New IncomingCheck
          entities(1) = New AdvanceReceive
          myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
        End If
      Else
        Select Case CInt(Me.m_receive.ItemTable.Rows(e.Row)("receivei_entityType"))
          Case 0 'สด
            Return
          Case 27 'เช็ค
            Dim entities As New ArrayList
            If Not Me.m_receive.RefDoc.Payer Is Nothing Then
              If TypeOf Me.m_receive.RefDoc.Payer Is Customer Then
                entities.Add(Me.m_receive.RefDoc.Payer)
              End If
            End If
            Dim filters(1) As Filter
            filters(0) = New Filter("IDList", GenIDListFromDataTable(27))
            filters(1) = New Filter("showOnlyAmountMoreThanZero", True)
            myEntityPanelService.OpenListDialog(New IncomingCheck, AddressOf SetItems, filters, entities)
          Case 71 'มัดจำ
            Dim entities As New ArrayList
            If Not Me.m_receive.RefDoc.Payer Is Nothing Then
              If TypeOf Me.m_receive.RefDoc.Payer Is Customer Then
                entities.Add(Me.m_receive.RefDoc.Payer)
              End If
            End If
            Dim filters(0) As Filter
            filters(0) = New Filter("IDList", GenIDListFromDataTable(71))
            myEntityPanelService.OpenListDialog(New AdvanceReceive, AddressOf SetItems, filters, entities)
          Case 72 'โอน
            Return
          Case Else

        End Select
      End If
    End Sub
    Private Function GenIDListFromDataTable(ByVal type As Integer) As String
      Dim idlist As String = ""
      For Each row As TreeRow In Me.m_receive.ItemTable.Rows
        If Not row.IsNull("receivei_entityType") AndAlso IsNumeric(row("receivei_entityType")) Then
          If CInt(row("receivei_entityType")) = type Then
            If Not IsDBNull(row("receivei_entity")) Then
              idlist &= CStr(row("receivei_entity")) & ","
            End If
          End If
        End If
      Next
      Return idlist
    End Function
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim itemCode As String
        itemCode = item.Code
        Dim itemType As Integer
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.incomingcheck"
            itemType = 27
          Case "longkong.pojjaman.businesslogic.advancereceive"
            itemType = 71
        End Select
        If Not itemType = 0 Then
          If i = items.Count - 1 Then
            If Me.m_receive.ItemTable.Childs.Count = 0 Then
              Me.m_receive.AddBlankRow(1)
              Me.m_receive.ItemTable.Childs(0)("receivei_entityType") = itemType
              Me.m_receive.ItemTable.Childs(0)("Code") = itemCode
            Else
              Me.m_receive.ItemTable.Childs(index)("receivei_entityType") = itemType
              Me.m_receive.ItemTable.Childs(index)("Code") = itemCode
            End If
          Else
            Me.m_receive.Insert(index, New ReceiveItem)
            Me.m_receive.ItemTable.Childs(index)("receivei_entityType") = itemType
            Me.m_receive.ItemTable.Childs(index)("Code") = itemCode
          End If
        End If
        Me.m_receive.ItemTable.AcceptChanges()
      Next
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_receive.MaxRowIndex Then
        Return
      End If
      Dim theItem As New ReceiveItem
      Me.m_receive.Insert(index, theItem)
      Me.m_receive.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If index > Me.m_receive.MaxRowIndex Then
        Return
      End If
      Me.m_receive.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
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
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDown
        BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_receive.EntityId)
        m_oldCode = Me.cmbCode.Text
        Me.m_receive.Code = m_oldCode
        Me.m_receive.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_receive.AutoGen = False
      End If
    End Sub
    Private Sub ibtnOtherDebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnOtherDebit.Click
      Dim dlg As New OtherReceive(Me.m_receive, True)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub ibtnTotalCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnOtherCredit.Click
      Dim dlg As New OtherReceive(Me.m_receive, False)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
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
        Return (New Receive).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "IPrintable"
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
        Dim thePath As String = ""

        If Not Me.m_receive Is Nothing Then
          If TypeOf Me.m_receive Is IPrintableEntity Then
            'thePath = Microsoft.VisualBasic.InputBox("เลือกฟอร์ม", "เลือกฟอร์ม", thePath)
            Dim fileName As String = CType(Me.m_receive, IPrintableEntity).GetDefaultForm
            If fileName Is Nothing OrElse fileName.Length = 0 Then
              fileName = m_receive.ClassName
            End If
            thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"

            Dim paths As FormPaths
            Dim nameForPath As String
            nameForPath = m_receive.FullClassName & ".Documents"
            Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, m_receive.ClassName, thePath)), FormPaths)
            Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
            If dlg.ShowDialog() = DialogResult.OK Then
              thePath = dlg.KeyValuePair.Value
            Else
              Return Nothing
            End If

            If File.Exists(thePath) AndAlso thePath.ToLower.EndsWith(".xml") Then
              Dim df As New DesignerForm(thePath, CType(Me.m_receive, IPrintableEntity))
              Return df.PrintDocument
            ElseIf File.Exists(thePath) Then
              Dim df As New DocumentForm(thePath, CType(Me.m_receive, IPrintableEntity))
              Return df.PrintDocument
            End If
          End If
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
      If Me.m_receive Is Nothing Then
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
      Dim maxVisibleCount As Integer
      Dim tgRowHeight As Integer = tgItem.PreferredRowHeight '17
      maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      Do While Me.m_receive.ItemTable.Childs.Count < maxVisibleCount - 1
        'เพิ่มแถวจนเต็ม
        Me.m_receive.AddBlankRow(1)
      Loop
      If Me.m_receive.MaxRowIndex = maxVisibleCount - 2 Then
        If Me.m_receive.ItemTable.Childs.Count < maxVisibleCount - 1 Then
          'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          Me.m_receive.AddBlankRow(1)
        End If
      End If
      Do While Me.m_receive.ItemTable.Childs.Count > maxVisibleCount - 1 And Me.m_receive.ItemTable.Childs.Count - 2 <> Me.m_receive.MaxRowIndex
        'ลบแถวที่ไม่จำเป็น
        Me.m_receive.Remove(Me.m_receive.ItemTable.Childs.Count - 1)
      Loop
      Me.m_receive.ItemTable.AcceptChanges()
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
      'MyBase.NotifyAfterSave(flag)
    End Sub
    Public Overrides Sub NotifyBeforeSave()
      MyBase.NotifyBeforeSave()
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

#Region "IAuxTab"
    Public ReadOnly Property AuxEntity() As IDirtyAble Implements IAuxTab.AuxEntity
      Get
        Return m_receive
      End Get
    End Property
#End Region

  End Class

End Namespace
