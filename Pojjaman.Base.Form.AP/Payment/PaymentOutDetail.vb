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
Imports Longkong.Core.AddIns

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class PaymentOutDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable, IAuxTab, ISetNothingEntity

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
    Friend WithEvents grbDebit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
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
    Friend WithEvents grbCredit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
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
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents ibtnOtherDebit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnTotalCredit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkOnHold As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaymentOutDetail))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.grbRefDoc = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtRefAmount = New System.Windows.Forms.TextBox()
      Me.txtRefDocDate = New System.Windows.Forms.TextBox()
      Me.lblRefAmount = New System.Windows.Forms.Label()
      Me.lblRefDocDate = New System.Windows.Forms.Label()
      Me.dtpRefDocDate = New System.Windows.Forms.DateTimePicker()
      Me.txtRefDocCode = New System.Windows.Forms.TextBox()
      Me.lblRefDoc = New System.Windows.Forms.Label()
      Me.lblRefAmountUnit = New System.Windows.Forms.Label()
      Me.txtTotalCreditAmount = New System.Windows.Forms.TextBox()
      Me.txtTotalDebitAmount = New System.Windows.Forms.TextBox()
      Me.grbDebit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnOtherDebit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDebitAmount = New System.Windows.Forms.TextBox()
      Me.lblDiscountAmount = New System.Windows.Forms.Label()
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
      Me.txtOtherRevenue = New System.Windows.Forms.TextBox()
      Me.lblOtherRev = New System.Windows.Forms.Label()
      Me.txtWHT = New System.Windows.Forms.TextBox()
      Me.lblWHT = New System.Windows.Forms.Label()
      Me.txtDiscountUnit = New System.Windows.Forms.Label()
      Me.txtOtherRevUnit = New System.Windows.Forms.Label()
      Me.txtWHTUnit = New System.Windows.Forms.Label()
      Me.lblDebitAmount = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblGross = New System.Windows.Forms.Label()
      Me.txtGross = New System.Windows.Forms.TextBox()
      Me.grbCredit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnTotalCredit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtOtherExpense = New System.Windows.Forms.TextBox()
      Me.lblOtherExpense = New System.Windows.Forms.Label()
      Me.lblBankCharge = New System.Windows.Forms.Label()
      Me.txtBankCharge = New System.Windows.Forms.TextBox()
      Me.txtInterest = New System.Windows.Forms.TextBox()
      Me.lblInterest = New System.Windows.Forms.Label()
      Me.txtBankChargeUnit = New System.Windows.Forms.Label()
      Me.txtOtherExpenseUnit = New System.Windows.Forms.Label()
      Me.txtInterestUnit = New System.Windows.Forms.Label()
      Me.lblCreditAmount = New System.Windows.Forms.Label()
      Me.txtCreditAmount = New System.Windows.Forms.TextBox()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.txtGrossUnit = New System.Windows.Forms.Label()
      Me.lblAmountUnit = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.chkOnHold = New System.Windows.Forms.CheckBox()
      Me.grbDetail.SuspendLayout()
      Me.grbRefDoc.SuspendLayout()
      Me.grbDebit.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbCredit.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.grbDetail.Controls.Add(Me.grbDebit)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblAmount)
      Me.grbDetail.Controls.Add(Me.txtAmount)
      Me.grbDetail.Controls.Add(Me.lblGross)
      Me.grbDetail.Controls.Add(Me.txtGross)
      Me.grbDetail.Controls.Add(Me.grbCredit)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.txtGrossUnit)
      Me.grbDetail.Controls.Add(Me.lblAmountUnit)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.SystemColors.ControlText
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(728, 584)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "�ѹ�֡�����Թ"
      '
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(88, 24)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 0
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(208, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 331
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(88, 72)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 26
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(112, 72)
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
      Me.lblCode.Location = New System.Drawing.Point(16, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(72, 18)
      Me.lblCode.TabIndex = 7
      Me.lblCode.Text = "�Ţ����͡���:"
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
      Me.lblDocDate.Text = "�ѹ����͡���:"
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
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(124, 21)
      Me.txtDocDate.TabIndex = 2
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(88, 48)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 9
      Me.dtpDocDate.TabStop = False
      '
      'grbRefDoc
      '
      Me.grbRefDoc.Controls.Add(Me.chkOnHold)
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
      Me.grbRefDoc.Text = "�͡�����ҧ�ԧ"
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
      Me.Validator.SetMinValue(Me.txtRefAmount, "")
      Me.txtRefAmount.Name = "txtRefAmount"
      Me.Validator.SetRegularExpression(Me.txtRefAmount, "")
      Me.Validator.SetRequired(Me.txtRefAmount, False)
      Me.txtRefAmount.Size = New System.Drawing.Size(104, 21)
      Me.txtRefAmount.TabIndex = 6
      Me.txtRefAmount.TabStop = False
      Me.txtRefAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.txtRefDocDate.Location = New System.Drawing.Point(264, 16)
      Me.Validator.SetMinValue(Me.txtRefDocDate, "")
      Me.txtRefDocDate.Name = "txtRefDocDate"
      Me.Validator.SetRegularExpression(Me.txtRefDocDate, "")
      Me.Validator.SetRequired(Me.txtRefDocDate, False)
      Me.txtRefDocDate.Size = New System.Drawing.Size(96, 21)
      Me.txtRefDocDate.TabIndex = 3
      Me.txtRefDocDate.TabStop = False
      '
      'lblRefAmount
      '
      Me.lblRefAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefAmount.ForeColor = System.Drawing.Color.Black
      Me.lblRefAmount.Location = New System.Drawing.Point(8, 40)
      Me.lblRefAmount.Name = "lblRefAmount"
      Me.lblRefAmount.Size = New System.Drawing.Size(104, 18)
      Me.lblRefAmount.TabIndex = 5
      Me.lblRefAmount.Text = "�ʹ�Թ:"
      Me.lblRefAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefDocDate
      '
      Me.lblRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRefDocDate.Location = New System.Drawing.Point(224, 17)
      Me.lblRefDocDate.Name = "lblRefDocDate"
      Me.lblRefDocDate.Size = New System.Drawing.Size(40, 18)
      Me.lblRefDocDate.TabIndex = 2
      Me.lblRefDocDate.Text = "�ѹ���:"
      Me.lblRefDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpRefDocDate
      '
      Me.dtpRefDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpRefDocDate.Enabled = False
      Me.dtpRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpRefDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpRefDocDate.Location = New System.Drawing.Point(264, 16)
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
      Me.Validator.SetMinValue(Me.txtRefDocCode, "")
      Me.txtRefDocCode.Name = "txtRefDocCode"
      Me.Validator.SetRegularExpression(Me.txtRefDocCode, "")
      Me.Validator.SetRequired(Me.txtRefDocCode, False)
      Me.txtRefDocCode.Size = New System.Drawing.Size(104, 21)
      Me.txtRefDocCode.TabIndex = 1
      Me.txtRefDocCode.TabStop = False
      '
      'lblRefDoc
      '
      Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDoc.Location = New System.Drawing.Point(8, 17)
      Me.lblRefDoc.Name = "lblRefDoc"
      Me.lblRefDoc.Size = New System.Drawing.Size(104, 18)
      Me.lblRefDoc.TabIndex = 0
      Me.lblRefDoc.Text = "�Ţ����͡�����ҧ�ԧ:"
      Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRefAmountUnit
      '
      Me.lblRefAmountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefAmountUnit.ForeColor = System.Drawing.Color.Black
      Me.lblRefAmountUnit.Location = New System.Drawing.Point(224, 40)
      Me.lblRefAmountUnit.Name = "lblRefAmountUnit"
      Me.lblRefAmountUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblRefAmountUnit.TabIndex = 7
      Me.lblRefAmountUnit.Text = "�ҷ"
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
      Me.txtTotalCreditAmount.Location = New System.Drawing.Point(520, 424)
      Me.Validator.SetMinValue(Me.txtTotalCreditAmount, "")
      Me.txtTotalCreditAmount.Name = "txtTotalCreditAmount"
      Me.txtTotalCreditAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalCreditAmount, "")
      Me.Validator.SetRequired(Me.txtTotalCreditAmount, False)
      Me.txtTotalCreditAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtTotalCreditAmount.TabIndex = 16
      Me.txtTotalCreditAmount.TabStop = False
      Me.txtTotalCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.txtTotalDebitAmount.Location = New System.Drawing.Point(168, 424)
      Me.Validator.SetMinValue(Me.txtTotalDebitAmount, "")
      Me.txtTotalDebitAmount.Name = "txtTotalDebitAmount"
      Me.txtTotalDebitAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalDebitAmount, "")
      Me.Validator.SetRequired(Me.txtTotalDebitAmount, False)
      Me.txtTotalDebitAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtTotalDebitAmount.TabIndex = 15
      Me.txtTotalDebitAmount.TabStop = False
      Me.txtTotalDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'grbDebit
      '
      Me.grbDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbDebit.Controls.Add(Me.ibtnOtherDebit)
      Me.grbDebit.Controls.Add(Me.txtDebitAmount)
      Me.grbDebit.Controls.Add(Me.lblDiscountAmount)
      Me.grbDebit.Controls.Add(Me.txtDiscountAmount)
      Me.grbDebit.Controls.Add(Me.txtOtherRevenue)
      Me.grbDebit.Controls.Add(Me.lblOtherRev)
      Me.grbDebit.Controls.Add(Me.txtWHT)
      Me.grbDebit.Controls.Add(Me.lblWHT)
      Me.grbDebit.Controls.Add(Me.txtDiscountUnit)
      Me.grbDebit.Controls.Add(Me.txtOtherRevUnit)
      Me.grbDebit.Controls.Add(Me.txtWHTUnit)
      Me.grbDebit.Controls.Add(Me.lblDebitAmount)
      Me.grbDebit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDebit.Location = New System.Drawing.Point(16, 432)
      Me.grbDebit.Name = "grbDebit"
      Me.grbDebit.Size = New System.Drawing.Size(336, 112)
      Me.grbDebit.TabIndex = 5
      Me.grbDebit.TabStop = False
      Me.grbDebit.Text = "�ʹ�ѡ�ӹǹ����"
      '
      'ibtnOtherDebit
      '
      Me.ibtnOtherDebit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnOtherDebit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnOtherDebit.Location = New System.Drawing.Point(288, 76)
      Me.ibtnOtherDebit.Name = "ibtnOtherDebit"
      Me.ibtnOtherDebit.Size = New System.Drawing.Size(24, 24)
      Me.ibtnOtherDebit.TabIndex = 13
      Me.ibtnOtherDebit.TabStop = False
      Me.ibtnOtherDebit.ThemedImage = CType(resources.GetObject("ibtnOtherDebit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDebitAmount
      '
      Me.Validator.SetDataType(Me.txtDebitAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDebitAmount, "")
      Me.txtDebitAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDebitAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDebitAmount, System.Drawing.Color.Empty)
      Me.txtDebitAmount.Location = New System.Drawing.Point(152, 78)
      Me.Validator.SetMinValue(Me.txtDebitAmount, "")
      Me.txtDebitAmount.Name = "txtDebitAmount"
      Me.txtDebitAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDebitAmount, "")
      Me.Validator.SetRequired(Me.txtDebitAmount, False)
      Me.txtDebitAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtDebitAmount.TabIndex = 7
      Me.txtDebitAmount.TabStop = False
      Me.txtDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiscountAmount
      '
      Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscountAmount.ForeColor = System.Drawing.Color.Black
      Me.lblDiscountAmount.Location = New System.Drawing.Point(56, 16)
      Me.lblDiscountAmount.Name = "lblDiscountAmount"
      Me.lblDiscountAmount.Size = New System.Drawing.Size(88, 18)
      Me.lblDiscountAmount.TabIndex = 2
      Me.lblDiscountAmount.Text = "��ǹŴ�Ѻ:"
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
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtDiscountAmount.TabIndex = 0
      Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtOtherRevenue
      '
      Me.Validator.SetDataType(Me.txtOtherRevenue, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtOtherRevenue, "")
      Me.txtOtherRevenue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtOtherRevenue, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtOtherRevenue, System.Drawing.Color.Empty)
      Me.txtOtherRevenue.Location = New System.Drawing.Point(152, 36)
      Me.Validator.SetMinValue(Me.txtOtherRevenue, "")
      Me.txtOtherRevenue.Name = "txtOtherRevenue"
      Me.Validator.SetRegularExpression(Me.txtOtherRevenue, "")
      Me.Validator.SetRequired(Me.txtOtherRevenue, False)
      Me.txtOtherRevenue.Size = New System.Drawing.Size(136, 21)
      Me.txtOtherRevenue.TabIndex = 1
      Me.txtOtherRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblOtherRev
      '
      Me.lblOtherRev.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOtherRev.ForeColor = System.Drawing.Color.Black
      Me.lblOtherRev.Location = New System.Drawing.Point(56, 37)
      Me.lblOtherRev.Name = "lblOtherRev"
      Me.lblOtherRev.Size = New System.Drawing.Size(88, 18)
      Me.lblOtherRev.TabIndex = 3
      Me.lblOtherRev.Text = "��������:"
      Me.lblOtherRev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtWHT
      '
      Me.txtWHT.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtWHT, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWHT, "")
      Me.txtWHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtWHT, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWHT, System.Drawing.Color.Empty)
      Me.txtWHT.Location = New System.Drawing.Point(152, 57)
      Me.Validator.SetMinValue(Me.txtWHT, "")
      Me.txtWHT.Name = "txtWHT"
      Me.txtWHT.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWHT, "")
      Me.Validator.SetRequired(Me.txtWHT, False)
      Me.txtWHT.Size = New System.Drawing.Size(136, 21)
      Me.txtWHT.TabIndex = 5
      Me.txtWHT.TabStop = False
      Me.txtWHT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblWHT
      '
      Me.lblWHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWHT.ForeColor = System.Drawing.Color.Black
      Me.lblWHT.Location = New System.Drawing.Point(32, 58)
      Me.lblWHT.Name = "lblWHT"
      Me.lblWHT.Size = New System.Drawing.Size(112, 18)
      Me.lblWHT.TabIndex = 4
      Me.lblWHT.Text = "�����ѡ � ������:"
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
      Me.txtDiscountUnit.Text = "�ҷ"
      Me.txtDiscountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtOtherRevUnit
      '
      Me.txtOtherRevUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtOtherRevUnit.ForeColor = System.Drawing.Color.Black
      Me.txtOtherRevUnit.Location = New System.Drawing.Point(288, 37)
      Me.txtOtherRevUnit.Name = "txtOtherRevUnit"
      Me.txtOtherRevUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtOtherRevUnit.TabIndex = 9
      Me.txtOtherRevUnit.Text = "�ҷ"
      Me.txtOtherRevUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtWHTUnit
      '
      Me.txtWHTUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtWHTUnit.ForeColor = System.Drawing.Color.Black
      Me.txtWHTUnit.Location = New System.Drawing.Point(288, 58)
      Me.txtWHTUnit.Name = "txtWHTUnit"
      Me.txtWHTUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtWHTUnit.TabIndex = 10
      Me.txtWHTUnit.Text = "�ҷ"
      Me.txtWHTUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblDebitAmount
      '
      Me.lblDebitAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDebitAmount.ForeColor = System.Drawing.Color.Black
      Me.lblDebitAmount.Location = New System.Drawing.Point(8, 79)
      Me.lblDebitAmount.Name = "lblDebitAmount"
      Me.lblDebitAmount.Size = New System.Drawing.Size(136, 18)
      Me.lblDebitAmount.TabIndex = 6
      Me.lblDebitAmount.Text = "�ʹ�ѡ�ӹǹ�������:"
      Me.lblDebitAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.tgItem.Size = New System.Drawing.Size(696, 280)
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
      Me.txtNote.Location = New System.Drawing.Point(88, 376)
      Me.txtNote.MaxLength = 250
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(264, 42)
      Me.txtNote.TabIndex = 3
      Me.txtNote.TabStop = False
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(16, 376)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(72, 18)
      Me.lblNote.TabIndex = 10
      Me.lblNote.Text = "�����˵�:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAmount
      '
      Me.lblAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(416, 552)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(104, 18)
      Me.lblAmount.TabIndex = 17
      Me.lblAmount.Text = "�ӹǹ�Թ����ͧ����:"
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
      Me.txtAmount.Location = New System.Drawing.Point(520, 544)
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.txtAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, False)
      Me.txtAmount.Size = New System.Drawing.Size(136, 33)
      Me.txtAmount.TabIndex = 18
      Me.txtAmount.TabStop = False
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.ForeColor = System.Drawing.Color.Black
      Me.lblGross.Location = New System.Drawing.Point(400, 376)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(120, 18)
      Me.lblGross.TabIndex = 12
      Me.lblGross.Text = "����ʹ�Թ���·�����:"
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
      Me.txtGross.Location = New System.Drawing.Point(520, 376)
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(136, 33)
      Me.txtGross.TabIndex = 13
      Me.txtGross.TabStop = False
      Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'grbCredit
      '
      Me.grbCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbCredit.Controls.Add(Me.ibtnTotalCredit)
      Me.grbCredit.Controls.Add(Me.txtOtherExpense)
      Me.grbCredit.Controls.Add(Me.lblOtherExpense)
      Me.grbCredit.Controls.Add(Me.lblBankCharge)
      Me.grbCredit.Controls.Add(Me.txtBankCharge)
      Me.grbCredit.Controls.Add(Me.txtInterest)
      Me.grbCredit.Controls.Add(Me.lblInterest)
      Me.grbCredit.Controls.Add(Me.txtBankChargeUnit)
      Me.grbCredit.Controls.Add(Me.txtOtherExpenseUnit)
      Me.grbCredit.Controls.Add(Me.txtInterestUnit)
      Me.grbCredit.Controls.Add(Me.lblCreditAmount)
      Me.grbCredit.Controls.Add(Me.txtCreditAmount)
      Me.grbCredit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbCredit.Location = New System.Drawing.Point(368, 432)
      Me.grbCredit.Name = "grbCredit"
      Me.grbCredit.Size = New System.Drawing.Size(336, 112)
      Me.grbCredit.TabIndex = 6
      Me.grbCredit.TabStop = False
      Me.grbCredit.Text = "�ʹ�����ӹǹ����"
      '
      'ibtnTotalCredit
      '
      Me.ibtnTotalCredit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnTotalCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnTotalCredit.Location = New System.Drawing.Point(288, 76)
      Me.ibtnTotalCredit.Name = "ibtnTotalCredit"
      Me.ibtnTotalCredit.Size = New System.Drawing.Size(24, 24)
      Me.ibtnTotalCredit.TabIndex = 12
      Me.ibtnTotalCredit.TabStop = False
      Me.ibtnTotalCredit.ThemedImage = CType(resources.GetObject("ibtnTotalCredit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtOtherExpense
      '
      Me.Validator.SetDataType(Me.txtOtherExpense, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtOtherExpense, "")
      Me.txtOtherExpense.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtOtherExpense, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtOtherExpense, System.Drawing.Color.Empty)
      Me.txtOtherExpense.Location = New System.Drawing.Point(152, 57)
      Me.Validator.SetMinValue(Me.txtOtherExpense, "")
      Me.txtOtherExpense.Name = "txtOtherExpense"
      Me.Validator.SetRegularExpression(Me.txtOtherExpense, "")
      Me.Validator.SetRequired(Me.txtOtherExpense, False)
      Me.txtOtherExpense.Size = New System.Drawing.Size(136, 21)
      Me.txtOtherExpense.TabIndex = 2
      Me.txtOtherExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblOtherExpense
      '
      Me.lblOtherExpense.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOtherExpense.ForeColor = System.Drawing.Color.Black
      Me.lblOtherExpense.Location = New System.Drawing.Point(16, 58)
      Me.lblOtherExpense.Name = "lblOtherExpense"
      Me.lblOtherExpense.Size = New System.Drawing.Size(128, 18)
      Me.lblOtherExpense.TabIndex = 7
      Me.lblOtherExpense.Text = "������������:"
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
      Me.lblBankCharge.Text = "��Ҹ���������Ҥ��:"
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
      Me.Validator.SetMinValue(Me.txtBankCharge, "")
      Me.txtBankCharge.Name = "txtBankCharge"
      Me.Validator.SetRegularExpression(Me.txtBankCharge, "")
      Me.Validator.SetRequired(Me.txtBankCharge, False)
      Me.txtBankCharge.Size = New System.Drawing.Size(136, 21)
      Me.txtBankCharge.TabIndex = 1
      Me.txtBankCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtInterest
      '
      Me.Validator.SetDataType(Me.txtInterest, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtInterest, "")
      Me.txtInterest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtInterest, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInterest, System.Drawing.Color.Empty)
      Me.txtInterest.Location = New System.Drawing.Point(152, 15)
      Me.Validator.SetMinValue(Me.txtInterest, "")
      Me.txtInterest.Name = "txtInterest"
      Me.Validator.SetRegularExpression(Me.txtInterest, "")
      Me.Validator.SetRequired(Me.txtInterest, False)
      Me.txtInterest.Size = New System.Drawing.Size(136, 21)
      Me.txtInterest.TabIndex = 0
      Me.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblInterest
      '
      Me.lblInterest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInterest.ForeColor = System.Drawing.Color.Black
      Me.lblInterest.Location = New System.Drawing.Point(16, 16)
      Me.lblInterest.Name = "lblInterest"
      Me.lblInterest.Size = New System.Drawing.Size(128, 18)
      Me.lblInterest.TabIndex = 3
      Me.lblInterest.Text = "�͡���¨���:"
      Me.lblInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBankChargeUnit
      '
      Me.txtBankChargeUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBankChargeUnit.ForeColor = System.Drawing.Color.Black
      Me.txtBankChargeUnit.Location = New System.Drawing.Point(288, 37)
      Me.txtBankChargeUnit.Name = "txtBankChargeUnit"
      Me.txtBankChargeUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtBankChargeUnit.TabIndex = 6
      Me.txtBankChargeUnit.Text = "�ҷ"
      Me.txtBankChargeUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtOtherExpenseUnit
      '
      Me.txtOtherExpenseUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtOtherExpenseUnit.ForeColor = System.Drawing.Color.Black
      Me.txtOtherExpenseUnit.Location = New System.Drawing.Point(288, 58)
      Me.txtOtherExpenseUnit.Name = "txtOtherExpenseUnit"
      Me.txtOtherExpenseUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtOtherExpenseUnit.TabIndex = 8
      Me.txtOtherExpenseUnit.Text = "�ҷ"
      Me.txtOtherExpenseUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtInterestUnit
      '
      Me.txtInterestUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtInterestUnit.ForeColor = System.Drawing.Color.Black
      Me.txtInterestUnit.Location = New System.Drawing.Point(288, 16)
      Me.txtInterestUnit.Name = "txtInterestUnit"
      Me.txtInterestUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtInterestUnit.TabIndex = 4
      Me.txtInterestUnit.Text = "�ҷ"
      Me.txtInterestUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblCreditAmount
      '
      Me.lblCreditAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCreditAmount.ForeColor = System.Drawing.Color.Black
      Me.lblCreditAmount.Location = New System.Drawing.Point(8, 79)
      Me.lblCreditAmount.Name = "lblCreditAmount"
      Me.lblCreditAmount.Size = New System.Drawing.Size(136, 18)
      Me.lblCreditAmount.TabIndex = 9
      Me.lblCreditAmount.Text = "�ʹ�����ӹǹ�������:"
      Me.lblCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCreditAmount
      '
      Me.Validator.SetDataType(Me.txtCreditAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCreditAmount, "")
      Me.txtCreditAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCreditAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCreditAmount, System.Drawing.Color.Empty)
      Me.txtCreditAmount.Location = New System.Drawing.Point(152, 78)
      Me.Validator.SetMinValue(Me.txtCreditAmount, "")
      Me.txtCreditAmount.Name = "txtCreditAmount"
      Me.txtCreditAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCreditAmount, "")
      Me.Validator.SetRequired(Me.txtCreditAmount, False)
      Me.txtCreditAmount.Size = New System.Drawing.Size(136, 21)
      Me.txtCreditAmount.TabIndex = 10
      Me.txtCreditAmount.TabStop = False
      Me.txtCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(16, 80)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(64, 18)
      Me.lblItem.TabIndex = 11
      Me.lblItem.Text = "������:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGrossUnit
      '
      Me.txtGrossUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtGrossUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtGrossUnit.ForeColor = System.Drawing.Color.Black
      Me.txtGrossUnit.Location = New System.Drawing.Point(656, 376)
      Me.txtGrossUnit.Name = "txtGrossUnit"
      Me.txtGrossUnit.Size = New System.Drawing.Size(32, 18)
      Me.txtGrossUnit.TabIndex = 14
      Me.txtGrossUnit.Text = "�ҷ"
      Me.txtGrossUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAmountUnit
      '
      Me.lblAmountUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAmountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmountUnit.ForeColor = System.Drawing.Color.Black
      Me.lblAmountUnit.Location = New System.Drawing.Point(656, 552)
      Me.lblAmountUnit.Name = "lblAmountUnit"
      Me.lblAmountUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblAmountUnit.TabIndex = 19
      Me.lblAmountUnit.Text = "�ҷ"
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'chkOnHold
      '
      Me.chkOnHold.AutoSize = True
      Me.chkOnHold.Location = New System.Drawing.Point(264, 43)
      Me.chkOnHold.Name = "chkOnHold"
      Me.chkOnHold.Size = New System.Drawing.Size(64, 17)
      Me.chkOnHold.TabIndex = 332
      Me.chkOnHold.Text = "On Hold"
      Me.chkOnHold.UseVisualStyleBackColor = True
      Me.chkOnHold.Enabled = False
      '
      'PaymentOutDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "PaymentOutDetail"
      Me.Size = New System.Drawing.Size(744, 600)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbRefDoc.ResumeLayout(False)
      Me.grbRefDoc.PerformLayout()
      Me.grbDebit.ResumeLayout(False)
      Me.grbDebit.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbCredit.ResumeLayout(False)
      Me.grbCredit.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As ISimpleEntity
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_payment As Payment

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
    Private m_combocodeindex As Integer
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dt As TreeTable = Payment.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf PaymentItemDelete

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
      dst.MappingName = "Payment"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "paymenti_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "paymenti_linenumber"

      Dim csType As DataGridComboColumn
      If TypeOf Me.m_entity Is AdvancePay Then
        csType = New DataGridComboColumn("paymenti_entityType" _
        , CodeDescription.GetCodeList("paymenti_entityType" _
        , "code_value <>" & Me.m_entity.EntityId) _
        , "code_description", "code_value")
      ElseIf TypeOf Me.m_entity Is PettyCashClaim Then
        csType = New DataGridComboColumn("paymenti_entityType" _
        , CodeDescription.GetCodeList("paymenti_entityType" _
        , "code_value not in (36,66,336)") _
        , "code_description", "code_value")
      ElseIf TypeOf Me.m_entity Is SaleCN Then
        csType = New DataGridComboColumn("paymenti_entityType" _
        , CodeDescription.GetCodeList("paymenti_entityType" _
        , "code_value not in (36,59,174,336)") _
        , "code_description", "code_value")
      ElseIf TypeOf Me.m_entity Is AdvanceMoney Then
        csType = New DataGridComboColumn("paymenti_entityType" _
        , CodeDescription.GetCodeList("paymenti_entityType" _
        , "code_value not in (59,174,336)") _
        , "code_description", "code_value")
      ElseIf TypeOf Me.m_entity Is GoodsReceipt OrElse TypeOf Me.m_entity Is EqMaintenance Then
        csType = New DataGridComboColumn("paymenti_entityType" _
        , CodeDescription.GetCodeList("paymenti_entityType" _
        , "code_value not in (59)") _
        , "code_description", "code_value")
      Else
        csType = New DataGridComboColumn("paymenti_entityType" _
        , CodeDescription.GetCodeList("paymenti_entityType") _
        , "code_description", "code_value")
      End If
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.TypeHeaderText}")
      csType.Width = 70
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      Dim csBACode As New TreeTextColumn
      csBACode.MappingName = "BACode"
      csBACode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.BankAccountHeaderText}")
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
      csBAName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.BANameHeaderText}")
      csBAName.NullText = ""
      csBAName.Width = 180
      csBAName.TextBox.Name = "BAName"
      csBAName.ReadOnly = True

      Dim csDueDate As New DataGridTimePickerColumn
      csDueDate.MappingName = "DueDate"
      csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.DueDateHeaderText}")
      csDueDate.NullText = ""
      csDueDate.Width = 100

      Dim csRealAmount As New TreeTextColumn
      csRealAmount.MappingName = "RealAmount"
      csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.RealAmountHeaderText}")
      csRealAmount.NullText = ""
      csRealAmount.DataAlignment = HorizontalAlignment.Right
      csRealAmount.Format = "#,###.##"
      csRealAmount.TextBox.Name = "RealAmount"
      csRealAmount.Width = 100

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "paymenti_amt"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "paymenti_amt"
      csAmount.Width = 100

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "paymenti_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 100
      csNote.TextBox.Name = "paymenti_note"

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

      Return dst
    End Function
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 3 Then
        Dim btnValue As String = Me.m_treeManager.Treetable.Rows(e.Row)("Button").ToString.ToLower
        If btnValue = "invisible" Then
          Return
        End If
        Me.ItemButtonClick(e)
      Else
        Dim btnValue As String = Me.m_treeManager.Treetable.Rows(e.Row)("BAButton").ToString.ToLower
        If btnValue = "invisible" Then
          Return
        End If
        Me.BAButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As PaymentItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is PaymentItem Then
          Return Nothing
        End If
        Return CType(row.Tag, PaymentItem)
      End Get
    End Property
    Private Property ComboCodeIndex() As Integer
      Get
        If m_combocodeindex = -1 Then
          If cmbCode.Items.Count > 0 Then
            m_combocodeindex = 0
          End If
        End If
        Return m_combocodeindex
      End Get
      Set(ByVal Value As Integer)
        m_combocodeindex = Value
      End Set
    End Property
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
        Return
      End If
      Dim doc As PaymentItem = Me.CurrentItem
      If Not doc Is Nothing Then
        doc.ItemValidateRow(e.Row)
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
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As PaymentItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New PaymentItem
        Me.m_payment.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "paymenti_entitytype"
            doc.EntityType = New PaymentEntityType(CInt(e.ProposedValue))
          Case "bacode"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetBankAccount(CStr(e.ProposedValue))
          Case "duedate"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = Date.MinValue
            End If
            Dim value As Date = CDate(e.ProposedValue)
            doc.DueDate = value
          Case "realamount"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            doc.RealAmount = value
          Case "paymenti_amt"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            doc.Amount = value
          Case "paymenti_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub PaymentItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_payment Is Nothing Then
        Return
      End If
      If (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value >= 4) OrElse (Not Me.m_entity Is Nothing AndAlso Me.m_entity.Status.Value = 0) Then

        'grbDetail.Enabled = False
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next

      Else
        'grbDetail.Enabled = True
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = True
        Next
        'tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = False
        Next
      End If

      If TypeOf Me.m_entity Is GoodsReceipt Then
        Dim gr As GoodsReceipt = CType(Me.m_entity, GoodsReceipt)
        If gr.Status.Value = 0 OrElse gr.IsReferenced = True Then
          For Each ctrl As Control In grbDetail.Controls
            ctrl.Enabled = False
          Next
          tgItem.Enabled = True
          For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
            colStyle.ReadOnly = True
          Next
        End If
      End If

      '==Checking for addin
      Dim hasExport As Boolean = False
      For Each a As AddIn In AddInTreeSingleton.AddInTree.AddIns
        If a.FileName.ToLower.Contains("textexport") Then
          hasExport = True
        End If
      Next
      Me.chkOnHold.Visible = hasExport
    End Sub

    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblBankCharge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblBankCharge}")
      Me.lblWHT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblWHT}")
      Me.lblOtherExpense.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblOtherExpense}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblNote}")
      Me.txtDiscountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.txtWHTUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.txtBankChargeUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.txtOtherExpenseUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblItem}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbDetail}")
      Me.grbRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbRefDoc}")
      Me.lblRefDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblRefDocDate}")
      Me.lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblRefDoc}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblCode}")
      Me.Validator.SetDisplayName(Me.cmbCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblDocDate}")
      Me.lblRefAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblRefAmount}")
      Me.lblRefAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.grbDebit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbDebit}")
      Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblDiscountAmount}")
      Me.lblOtherRev.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblOtherRev}")
      Me.txtOtherRevUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblDebitAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblDebitAmount}")
      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblAmount}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblGross}")
      Me.grbCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbCredit}")
      Me.lblInterest.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblInterest}")
      Me.txtInterestUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblCreditAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblCreditAmount}")
      Me.txtGrossUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
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

      AddHandler chkOnHold.CheckedChanged, AddressOf Me.ChangeProperty

    End Sub
    ' �ʴ���Ң����Ţͧ�١���ŧ� control ������躹�����
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_payment Is Nothing Then
        Return
      End If

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

      chkOnHold.Checked = m_payment.OnHold

      RefreshDocs()

      cmbCode.Items.Clear()
      cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_payment.Code

      BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_payment.EntityId)

      m_oldCode = m_payment.Code
      Me.chkAutorun.Checked = Me.m_payment.AutoGen
      Me.UpdateAutogenStatus()
      txtNote.Text = Me.m_payment.Note
      txtDocDate.Text = MinDateToNull(Me.m_payment.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_payment.DocDate)

      Me.txtDiscountAmount.Text = Configuration.FormatToString(Me.m_payment.DiscountAmount, DigitConfig.Price)
      Me.txtOtherRevenue.Text = Configuration.FormatToString(Me.m_payment.OtherRevenue, DigitConfig.Price)
      Me.txtWHT.Text = Configuration.FormatToString(Me.m_payment.WitholdingTax, DigitConfig.Price)

      Me.txtBankCharge.Text = Configuration.FormatToString(Me.m_payment.BankCharge, DigitConfig.Price)
      Me.txtInterest.Text = Configuration.FormatToString(Me.m_payment.Interest, DigitConfig.Price)
      Me.txtOtherExpense.Text = Configuration.FormatToString(Me.m_payment.OtherExpense, DigitConfig.Price)

      UpdateAmount()
      UpdateRefDoc()

      If Not Me.m_payment.Originated Then
        Dim Config As Object = Configuration.GetConfig("TabDetailNoteToOtherTab")
        If CBool(Config) Then
          If Me.m_payment.Note Is Nothing OrElse Me.m_payment.Note.Length = 0 Then
            Me.m_payment.Note = m_payment.RefDoc.Note
          End If
        End If
      End If

      Me.txtNote.Text = Me.m_payment.Note

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_payment.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateRefDoc()
      Me.txtRefDocCode.Text = Me.m_payment.RefDoc.Code
      Me.txtRefDocDate.Text = MinDateToNull(Me.m_payment.RefDoc.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      Me.dtpRefDocDate.Value = MinDateToNow(Me.m_payment.RefDoc.Date)
      Me.txtRefAmount.Text = Configuration.FormatToString(m_payment.AmountToPay, DigitConfig.Price)
    End Sub
    Private Sub UpdateAmount()
      Dim oldFlag As Boolean = m_isInitialized
      m_isInitialized = False
      Dim myGross As Decimal = Me.m_payment.Gross
      Me.txtDebitAmount.Text = Configuration.FormatToString(Me.m_payment.DebitAmount, DigitConfig.Price)
      Me.txtCreditAmount.Text = Configuration.FormatToString(Me.m_payment.CreditAmount, DigitConfig.Price)
      Me.txtTotalDebitAmount.Text = Configuration.FormatToString(Me.m_payment.SumDebitAmount, DigitConfig.Price)
      Me.txtTotalCreditAmount.Text = Configuration.FormatToString(Me.m_payment.SumCreditAmount, DigitConfig.Price)
      Me.txtGross.Text = Configuration.FormatToString(myGross, DigitConfig.Price)
      Me.txtAmount.Text = Configuration.FormatToString(Me.m_payment.Amount, DigitConfig.Price)
      m_isInitialized = oldFlag

      '�������¡�è����Թ ����Ǩ�ͺ�Ţ��� PV ����
      If myGross > 0 Then
        Me.Validator.SetRequired(Me.cmbCode, True)
      Else
        Me.Validator.SetRequired(Me.cmbCode, False)
      End If
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_payment Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "chkonhold"
          Me.m_payment.OnHold = chkOnHold.Checked
        Case "cmbcode"
          Me.m_payment.Code = cmbCode.Text
          ComboCodeIndex = cmbCode.SelectedIndex
          m_oldCode = Me.cmbCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_payment.Note = txtNote.Text
          dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_payment.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_payment.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_payment.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_payment.DocDate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            Me.m_payment.DocDate = Date.Now
            Me.m_payment.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtdiscountamount"
          If IsNumeric(txtDiscountAmount.Text) Then
            Me.m_payment.DiscountAmount = CDec(txtDiscountAmount.Text)
          End If
          Me.UpdateAmount()
          dirtyFlag = True
        Case "txtotherrevenue"
          If IsNumeric(txtOtherRevenue.Text) Then
            Me.m_payment.OtherRevenue = CDec(txtOtherRevenue.Text)
          End If
          Me.UpdateAmount()
          dirtyFlag = True
        Case "txtinterest"
          If IsNumeric(txtInterest.Text) Then
            Me.m_payment.Interest = CDec(txtInterest.Text)
          End If
          Me.UpdateAmount()
          dirtyFlag = True
        Case "txtbankcharge"
          If IsNumeric(txtBankCharge.Text) Then
            Me.m_payment.BankCharge = CDec(txtBankCharge.Text)
          End If
          Me.UpdateAmount()
          dirtyFlag = True
        Case "txtotherexpense"
          If IsNumeric(txtOtherExpense.Text) Then
            Me.m_payment.OtherExpense = CDec(txtOtherExpense.Text)
          End If
          Me.UpdateAmount()
          dirtyFlag = True
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()
      'If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "¡��ԡ: " & m_entity.CancelDate.ToShortDateString & _
      '    " " & m_entity.CancelDate.ToShortTimeString & _
      '    "  ��:" & m_entity.CancelPerson.Name
      'ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "�������ش: " & m_entity.LastEditDate.ToShortDateString & _
      '    " " & m_entity.LastEditDate.ToShortTimeString & _
      '    "  ��:" & m_entity.LastEditor.Name
      'ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "�����������к�: " & m_entity.OriginDate.ToShortDateString & _
      '    " " & m_entity.OriginDate.ToShortTimeString & _
      '    "  ��:" & m_entity.Originator.Name
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
          If Not m_payment Is Nothing Then
            RemoveHandler Me.m_payment.PropertyChanged, AddressOf PropChanged
            Me.m_payment = Nothing
          End If
          If TypeOf m_entity Is IPayable Then
            Dim paymentRefDoc As IPayable = CType(m_entity, IPayable)
            m_payment = paymentRefDoc.Payment
            If m_payment Is Nothing Then
              m_payment = New Payment
              m_payment.RefDoc.Payment = m_payment
            End If
            m_payment.RefDoc = Nothing
            m_payment.RefDoc = paymentRefDoc
            If m_payment.DocDate.Equals(Date.MinValue) Then
              m_payment.DocDate = paymentRefDoc.Date
            End If
          End If
        End If
        If Not Me.m_payment Is Nothing Then
          Me.m_payment.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
    End Sub
#End Region

#Region "Event Handlers"
    Public Sub BAButtonClick(ByVal e As ButtonColumnEventArgs)
      'If Me.m_payment.ItemTable.Rows(e.Row).IsNull("paymenti_entityType") Then
      '    Return
      'ElseIf CInt(Me.m_payment.ItemTable.Rows(e.Row)("paymenti_entityType")) = 0 Then
      '    Return
      'End If
      If Me.CurrentItem.EntityType.Value = 336 Then
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
      'If Me.m_payment.ItemTable.Rows(e.Row).IsNull("paymenti_entityType") Then
      '    If TypeOf Me.m_entity Is AdvancePay Then
      '        Dim filterEntities(1) As ArrayList
      '        For i As Integer = 0 To 1
      '            filterEntities(i) = New ArrayList
      '            If Not Me.m_payment.RefDoc.Recipient Is Nothing Then
      '                If TypeOf Me.m_payment.RefDoc.Recipient Is Supplier Then
      '                    filterEntities(i).Add(Me.m_payment.RefDoc.Recipient)
      '                End If
      '            End If
      '        Next
      '        Dim filters(1)() As Filter
      '        filters(0) = New Filter() {New Filter("IDList", GenIDListFromDataTable(22)), New Filter("showOnlyAmountMoreThanZero", True)}
      '        filters(1) = New Filter() {New Filter("IDList", GenIDListFromDataTable(36))}
      '        Dim entities(1) As ISimpleEntity
      '        entities(0) = New OutgoingCheck
      '        entities(1) = New PettyCash
      '        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
      '    ElseIf TypeOf Me.m_entity Is PettyCashClaim Or TypeOf Me.m_entity Is AdvanceMoney Then
      '        myEntityPanelService.OpenListDialog(New OutgoingCheck, AddressOf SetItems)
      '    Else
      '        Dim filterEntities(2) As ArrayList
      '        For i As Integer = 0 To 2
      '            filterEntities(i) = New ArrayList
      '            If Not Me.m_payment.RefDoc.Recipient Is Nothing Then
      '                If TypeOf Me.m_payment.RefDoc.Recipient Is Supplier Then
      '                    filterEntities(i).Add(Me.m_payment.RefDoc.Recipient)
      '                End If
      '            End If
      '        Next
      '        Dim filters(2)() As Filter
      '        filters(0) = New Filter() {New Filter("IDList", GenIDListFromDataTable(22)), New Filter("showOnlyAmountMoreThanZero", True)}
      '        filters(1) = New Filter() {New Filter("IDList", GenIDListFromDataTable(36))}
      '        filters(2) = New Filter() {New Filter("IDList", GenIDListFromDataTable(59)), New Filter("showOnlyAmountMoreThanZero", True)}
      '        Dim entities(2) As ISimpleEntity
      '        entities(0) = New OutgoingCheck
      '        entities(1) = New PettyCash
      '        entities(2) = New AdvancePay
      '        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
      '    End If
      'Else

      'End If


      If Me.CurrentItem Is Nothing Then
        Return
      End If

      Select Case Me.CurrentItem.EntityType.Value
        Case 0 'ʴ
          Return
        Case 22 '��
          Dim entities As New ArrayList
          If Not TypeOf Me.m_payment.RefDoc Is PettyCashClaim Then
            If Not Me.m_payment.RefDoc.Recipient Is Nothing Then
              If TypeOf Me.m_payment.RefDoc.Recipient Is Supplier Then
                entities.Add(Me.m_payment.RefDoc.Recipient)
              End If
            End If
          End If
          Dim filters(1) As Filter
          filters(0) = New Filter("IDList", GenIDListFromDataTable(22))
          filters(1) = New Filter("showOnlyAmountMoreThanZero", True)
          myEntityPanelService.OpenListDialog(New OutgoingCheck, AddressOf SetItems, filters, entities)
        Case 336 '���������
          Dim entities As New ArrayList
          If Not TypeOf Me.m_payment.RefDoc Is PettyCashClaim Then
            If Not Me.m_payment.RefDoc.Recipient Is Nothing Then
              If TypeOf Me.m_payment.RefDoc.Recipient Is Supplier Then
                entities.Add(Me.m_payment.RefDoc.Recipient)
              End If
            End If
          End If
          Dim filters(1) As Filter
          filters(0) = New Filter("IDList", GenIDListFromDataTable(336))
          filters(1) = New Filter("showOnlyAmountMoreThanZero", True)
          myEntityPanelService.OpenListDialog(New OutgoingAval, AddressOf SetItems, filters, entities)
        Case 36 '�Թʴ����
          Dim entities As New ArrayList
          If Not TypeOf Me.m_payment.RefDoc Is PettyCashClaim Then
            If Not Me.m_payment.RefDoc.Recipient Is Nothing Then
              If TypeOf Me.m_payment.RefDoc.Recipient Is Supplier Then
                entities.Add(Me.m_payment.RefDoc.Recipient)
              End If
            End If
          End If
          Dim filters(1) As Filter
          filters(0) = New Filter("IDList", GenIDListFromDataTable(36))
          filters(1) = New Filter("pc_closed", 0)
          myEntityPanelService.OpenListDialog(New PettyCash, AddressOf SetItems, filters, entities)
        Case 59 '�Ѵ��
          Dim entities As New ArrayList
          If Not TypeOf Me.m_payment.RefDoc Is PettyCashClaim Then
            If Not Me.m_payment.RefDoc.Recipient Is Nothing Then
              If TypeOf Me.m_payment.RefDoc.Recipient Is Supplier Then
                entities.Add(Me.m_payment.RefDoc.Recipient)
              End If
            End If
          End If
          Dim filters(1) As Filter
          filters(0) = New Filter("IDList", GenIDListFromDataTable(59))
          filters(1) = New Filter("showOnlyAmountMoreThanZero", True)
          myEntityPanelService.OpenListDialog(New AdvancePay, AddressOf SetItems, filters, entities)
        Case 174 '���ͧ����
          Dim filters(0) As Filter
          filters(0) = New Filter("IDList", GenIDListFromDataTable(174))
          'filters(1) = New Filter("advm_closed", False)
          Dim entities As New ArrayList
          Dim advm As New AdvanceMoney
          advm.Closed = False
          entities.Add(advm)
          myEntityPanelService.OpenListDialog(New AdvanceMoney, AddressOf SetItems, filters, entities)
        Case 65 '�͹
          Return
        Case Else
      End Select
    End Sub
    Private Function GenIDListFromDataTable(ByVal type As Integer) As String
      Dim idlist As String = ""
      For Each item As PaymentItem In Me.m_payment.ItemCollection
        If Not item.Entity Is Nothing Then
          If item.EntityType.Value = type Then
            idlist &= item.Entity.Id.ToString & ","
          End If
        End If
      Next
      Return idlist
    End Function
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As IPaymentItem
        Dim itemType As Integer
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.outgoingcheck"
            newItem = New OutgoingCheck(item.Id)
            itemType = 22
          Case "longkong.pojjaman.businesslogic.outgoingaval"
            newItem = New OutgoingAval(item.Id)
            itemType = 336
          Case "longkong.pojjaman.businesslogic.pettycash"
            newItem = New PettyCash(item.Id)
            itemType = 36
          Case "longkong.pojjaman.businesslogic.advancepay"
            newItem = New AdvancePay(item.Id)
            itemType = 59
          Case "longkong.pojjaman.businesslogic.advancemoney"
            newItem = New AdvanceMoney(item.Id)
            itemType = 174
        End Select
        If Not itemType = 0 Then
          Dim doc As New PaymentItem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.EntityType.Value = itemType
            Me.m_treeManager.SelectedRow.Tag = Nothing
          Else
            Me.m_payment.ItemCollection.Add(doc)
            doc.EntityType = New PaymentEntityType(itemType)
          End If
          doc.Entity = newItem
        End If
      Next
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_payment.ItemCollection.Count - 1 Then
        Return
      End If
      Dim vItem As New PaymentItem
      Me.m_payment.ItemCollection.Insert(index, vItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If index > Me.m_payment.ItemCollection.Count - 1 Then
        Return
      End If
      Me.m_payment.ItemCollection.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("paymenti_linenumber") = i + 1
        i += 1
      Next
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
        'cmbCode.Items.Clear()
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
        'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_payment.EntityId)
        cmbCode.SelectedIndex = ComboCodeIndex
        m_oldCode = Me.cmbCode.Text
        Me.m_payment.Code = m_oldCode
        Me.m_payment.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        'cmbCode.SelectedIndex = ComboCodeIndex

        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        'Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_payment.AutoGen = False
      End If
    End Sub
    Private Sub ibtnOtherDebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnOtherDebit.Click
      Dim dlg As New OtherPayment(Me.m_payment, True)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub ibtnTotalCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnTotalCredit.Click
      Dim dlg As New OtherPayment(Me.m_payment, False)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New Payment).DetailPanelIcon
      End Get
    End Property
#End Region

    '#Region "IPrintable"
    '        Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
    '            Get
    '                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    '                Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
    '                'Dim thePath As String = FormPath & Path.DirectorySeparatorChar & m_payment.ClassName & ".xml"
    '                Dim thePath As String = FormPath & Path.DirectorySeparatorChar & "PaymentVoucher.xml"
    '                Dim df As New DesignerForm(thePath, CType(Me.m_payment, IPrintableEntity))
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
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
        Dim thePath As String = ""

        If Not Me.m_payment Is Nothing Then
          If TypeOf Me.m_payment Is IPrintableEntity Then
            'thePath = Microsoft.VisualBasic.InputBox("���͡�����", "���͡�����", thePath)
            Dim fileName As String = CType(Me.m_payment, IPrintableEntity).GetDefaultForm
            If fileName Is Nothing OrElse fileName.Length = 0 Then
              fileName = m_payment.ClassName
            End If
            thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"

            Dim paths As FormPaths
            Dim nameForPath As String
            nameForPath = m_payment.FullClassName & ".Documents"
            Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, m_payment.ClassName, thePath)), FormPaths)
            Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
            If dlg.ShowDialog() = DialogResult.OK Then
              thePath = dlg.KeyValuePair.Value
            Else
              Return Nothing
            End If

            If File.Exists(thePath) Then
              'Dim df As New DesignerForm(thePath, CType(Me.m_payment, IPrintableEntity))
              Dim df As New DesignerForm(thePath, New SuperPrintableEntity)
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
      If Me.m_payment Is Nothing Then
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
      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        '�����Ǩ����
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      If Me.m_payment.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        '�����ա 1 �� ����բ����Ũ��֧���ش����
        Me.m_treeManager.Treetable.Childs.Add()
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
        Return m_payment
      End Get
    End Property
#End Region

    Public Sub SetNothing() Implements ISetNothingEntity.SetNothing
      Me.m_entity = Nothing
    End Sub

  End Class

End Namespace
