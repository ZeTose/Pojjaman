Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CloseAccountPeriodView
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
    Friend WithEvents txtProfit As System.Windows.Forms.TextBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents grbSum As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtTotalProfit As System.Windows.Forms.TextBox
    Friend WithEvents lblProfit As System.Windows.Forms.Label
    Friend WithEvents lblTotalProfit As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents lblBaht1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDebit As System.Windows.Forms.Label
    Friend WithEvents lblTotalCredit As System.Windows.Forms.Label
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnCompile As System.Windows.Forms.Button
    Friend WithEvents lblLastPeriod As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblAccProfitAccount As System.Windows.Forms.Label
    Friend WithEvents txtAccProfitAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAccProfitAccountName As System.Windows.Forms.TextBox
    Friend WithEvents btnCheckUnpostGL As System.Windows.Forms.Button
    Friend WithEvents ibtnShowPeriodDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEndPeriod As System.Windows.Forms.TextBox
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CloseAccountPeriodView))
      Me.txtProfit = New System.Windows.Forms.TextBox()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.grbSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtTotalProfit = New System.Windows.Forms.TextBox()
      Me.lblProfit = New System.Windows.Forms.Label()
      Me.lblTotalProfit = New System.Windows.Forms.Label()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.lblBaht1 = New System.Windows.Forms.Label()
      Me.lblLastPeriod = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.ibtnShowPeriodDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblAccProfitAccount = New System.Windows.Forms.Label()
      Me.txtAccProfitAccountCode = New System.Windows.Forms.TextBox()
      Me.txtAccProfitAccountName = New System.Windows.Forms.TextBox()
      Me.txtEndPeriod = New System.Windows.Forms.TextBox()
      Me.btnCompile = New System.Windows.Forms.Button()
      Me.txtTotalDebit = New System.Windows.Forms.TextBox()
      Me.lblTotalDebit = New System.Windows.Forms.Label()
      Me.lblTotalCredit = New System.Windows.Forms.Label()
      Me.txtTotalCredit = New System.Windows.Forms.TextBox()
      Me.btnCheckUnpostGL = New System.Windows.Forms.Button()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbSum.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtProfit
      '
      Me.txtProfit.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtProfit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProfit, "")
      Me.txtProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtProfit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProfit, System.Drawing.Color.Empty)
      Me.txtProfit.Location = New System.Drawing.Point(168, 16)
      Me.Validator.SetMinValue(Me.txtProfit, "")
      Me.txtProfit.Name = "txtProfit"
      Me.txtProfit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProfit, "")
      Me.Validator.SetRequired(Me.txtProfit, False)
      Me.txtProfit.Size = New System.Drawing.Size(104, 21)
      Me.txtProfit.TabIndex = 1
      Me.txtProfit.TabStop = False
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 120)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(168, 18)
      Me.lblItem.TabIndex = 2
      Me.lblItem.Text = "รายการจัดการผังบัญชี:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tgItem
      '
      Me.tgItem.AllowNew = True
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 136)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(672, 224)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 1
      Me.tgItem.TreeManager = Nothing
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(128, 64)
      Me.txtNote.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(536, 21)
      Me.txtNote.TabIndex = 3
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(8, 64)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(120, 18)
      Me.lblNote.TabIndex = 6
      Me.lblNote.Text = "คำอธิบาย:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbSum
      '
      Me.grbSum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSum.Controls.Add(Me.txtProfit)
      Me.grbSum.Controls.Add(Me.txtTotalProfit)
      Me.grbSum.Controls.Add(Me.lblProfit)
      Me.grbSum.Controls.Add(Me.lblTotalProfit)
      Me.grbSum.Controls.Add(Me.lblBaht)
      Me.grbSum.Controls.Add(Me.lblBaht1)
      Me.grbSum.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSum.Location = New System.Drawing.Point(8, 360)
      Me.grbSum.Name = "grbSum"
      Me.grbSum.Size = New System.Drawing.Size(672, 48)
      Me.grbSum.TabIndex = 9
      Me.grbSum.TabStop = False
      Me.grbSum.Text = "สรุปกำไรขาดทุน"
      '
      'txtTotalProfit
      '
      Me.txtTotalProfit.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTotalProfit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalProfit, "")
      Me.txtTotalProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTotalProfit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalProfit, System.Drawing.Color.Empty)
      Me.txtTotalProfit.Location = New System.Drawing.Point(520, 16)
      Me.Validator.SetMinValue(Me.txtTotalProfit, "")
      Me.txtTotalProfit.Name = "txtTotalProfit"
      Me.txtTotalProfit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalProfit, "")
      Me.Validator.SetRequired(Me.txtTotalProfit, False)
      Me.txtTotalProfit.Size = New System.Drawing.Size(104, 21)
      Me.txtTotalProfit.TabIndex = 4
      Me.txtTotalProfit.TabStop = False
      '
      'lblProfit
      '
      Me.lblProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProfit.Location = New System.Drawing.Point(8, 16)
      Me.lblProfit.Name = "lblProfit"
      Me.lblProfit.Size = New System.Drawing.Size(160, 18)
      Me.lblProfit.TabIndex = 0
      Me.lblProfit.Text = "กำไร(ขาดทุน)สุทธิ:"
      Me.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTotalProfit
      '
      Me.lblTotalProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalProfit.Location = New System.Drawing.Point(336, 16)
      Me.lblTotalProfit.Name = "lblTotalProfit"
      Me.lblTotalProfit.Size = New System.Drawing.Size(176, 18)
      Me.lblTotalProfit.TabIndex = 3
      Me.lblTotalProfit.Text = "กำไร(ขาดทุน)สะสม"
      Me.lblTotalProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.Location = New System.Drawing.Point(280, 16)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(40, 18)
      Me.lblBaht.TabIndex = 2
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblBaht1
      '
      Me.lblBaht1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht1.Location = New System.Drawing.Point(632, 16)
      Me.lblBaht1.Name = "lblBaht1"
      Me.lblBaht1.Size = New System.Drawing.Size(32, 18)
      Me.lblBaht1.TabIndex = 5
      Me.lblBaht1.Text = "บาท"
      Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblLastPeriod
      '
      Me.lblLastPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLastPeriod.Location = New System.Drawing.Point(8, 40)
      Me.lblLastPeriod.Name = "lblLastPeriod"
      Me.lblLastPeriod.Size = New System.Drawing.Size(120, 18)
      Me.lblLastPeriod.TabIndex = 5
      Me.lblLastPeriod.Text = "ประมวลผลถึงงวดที่:"
      Me.lblLastPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.ibtnShowPeriodDialog)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblLastPeriod)
      Me.grbDetail.Controls.Add(Me.lblAccProfitAccount)
      Me.grbDetail.Controls.Add(Me.txtAccProfitAccountCode)
      Me.grbDetail.Controls.Add(Me.txtAccProfitAccountName)
      Me.grbDetail.Controls.Add(Me.txtEndPeriod)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(672, 96)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลการปิดงวดบัญชี"
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(264, 14)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(24, 23)
      Me.chkAutorun.TabIndex = 14
      '
      'ibtnShowPeriodDialog
      '
      Me.ibtnShowPeriodDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowPeriodDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowPeriodDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowPeriodDialog.Location = New System.Drawing.Point(264, 39)
      Me.ibtnShowPeriodDialog.Name = "ibtnShowPeriodDialog"
      Me.ibtnShowPeriodDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowPeriodDialog.TabIndex = 7
      Me.ibtnShowPeriodDialog.TabStop = False
      Me.ibtnShowPeriodDialog.ThemedImage = CType(resources.GetObject("ibtnShowPeriodDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(120, 18)
      Me.lblCode.TabIndex = 4
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(296, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(144, 18)
      Me.lblDocDate.TabIndex = 9
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(440, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, False)
      Me.txtDocDate.Size = New System.Drawing.Size(124, 20)
      Me.txtDocDate.TabIndex = 1
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(440, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 10
      Me.dtpDocDate.TabStop = False
      '
      'lblAccProfitAccount
      '
      Me.lblAccProfitAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccProfitAccount.Location = New System.Drawing.Point(296, 40)
      Me.lblAccProfitAccount.Name = "lblAccProfitAccount"
      Me.lblAccProfitAccount.Size = New System.Drawing.Size(144, 18)
      Me.lblAccProfitAccount.TabIndex = 8
      Me.lblAccProfitAccount.Text = "บัญชีกำไร(ขาดทุน)สะสม:"
      Me.lblAccProfitAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAccProfitAccountCode
      '
      Me.Validator.SetDataType(Me.txtAccProfitAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccProfitAccountCode, "")
      Me.txtAccProfitAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccProfitAccountCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccProfitAccountCode, System.Drawing.Color.Empty)
      Me.txtAccProfitAccountCode.Location = New System.Drawing.Point(440, 40)
      Me.Validator.SetMinValue(Me.txtAccProfitAccountCode, "")
      Me.txtAccProfitAccountCode.Name = "txtAccProfitAccountCode"
      Me.txtAccProfitAccountCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccProfitAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccProfitAccountCode, False)
      Me.txtAccProfitAccountCode.Size = New System.Drawing.Size(64, 21)
      Me.txtAccProfitAccountCode.TabIndex = 12
      Me.txtAccProfitAccountCode.TabStop = False
      '
      'txtAccProfitAccountName
      '
      Me.Validator.SetDataType(Me.txtAccProfitAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccProfitAccountName, "")
      Me.txtAccProfitAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccProfitAccountName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccProfitAccountName, System.Drawing.Color.Empty)
      Me.txtAccProfitAccountName.Location = New System.Drawing.Point(504, 40)
      Me.Validator.SetMinValue(Me.txtAccProfitAccountName, "")
      Me.txtAccProfitAccountName.Name = "txtAccProfitAccountName"
      Me.txtAccProfitAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccProfitAccountName, "")
      Me.Validator.SetRequired(Me.txtAccProfitAccountName, False)
      Me.txtAccProfitAccountName.Size = New System.Drawing.Size(160, 21)
      Me.txtAccProfitAccountName.TabIndex = 11
      Me.txtAccProfitAccountName.TabStop = False
      '
      'txtEndPeriod
      '
      Me.Validator.SetDataType(Me.txtEndPeriod, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEndPeriod, "")
      Me.txtEndPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEndPeriod, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEndPeriod, System.Drawing.Color.Empty)
      Me.txtEndPeriod.Location = New System.Drawing.Point(128, 40)
      Me.Validator.SetMinValue(Me.txtEndPeriod, "")
      Me.txtEndPeriod.Name = "txtEndPeriod"
      Me.txtEndPeriod.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEndPeriod, "")
      Me.Validator.SetRequired(Me.txtEndPeriod, False)
      Me.txtEndPeriod.Size = New System.Drawing.Size(136, 21)
      Me.txtEndPeriod.TabIndex = 2
      Me.txtEndPeriod.TabStop = False
      '
      'btnCompile
      '
      Me.btnCompile.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCompile.Location = New System.Drawing.Point(160, 112)
      Me.btnCompile.Name = "btnCompile"
      Me.btnCompile.Size = New System.Drawing.Size(72, 23)
      Me.btnCompile.TabIndex = 3
      Me.btnCompile.Text = "ประมวลผล"
      '
      'txtTotalDebit
      '
      Me.txtTotalDebit.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTotalDebit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalDebit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotalDebit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalDebit, System.Drawing.Color.Empty)
      Me.txtTotalDebit.Location = New System.Drawing.Point(400, 112)
      Me.Validator.SetMinValue(Me.txtTotalDebit, "")
      Me.txtTotalDebit.Name = "txtTotalDebit"
      Me.txtTotalDebit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalDebit, "")
      Me.Validator.SetRequired(Me.txtTotalDebit, False)
      Me.txtTotalDebit.Size = New System.Drawing.Size(96, 20)
      Me.txtTotalDebit.TabIndex = 6
      Me.txtTotalDebit.TabStop = False
      '
      'lblTotalDebit
      '
      Me.lblTotalDebit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalDebit.Location = New System.Drawing.Point(320, 112)
      Me.lblTotalDebit.Name = "lblTotalDebit"
      Me.lblTotalDebit.Size = New System.Drawing.Size(72, 18)
      Me.lblTotalDebit.TabIndex = 5
      Me.lblTotalDebit.Text = "Total Debit="
      Me.lblTotalDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTotalCredit
      '
      Me.lblTotalCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalCredit.Location = New System.Drawing.Point(504, 112)
      Me.lblTotalCredit.Name = "lblTotalCredit"
      Me.lblTotalCredit.Size = New System.Drawing.Size(80, 18)
      Me.lblTotalCredit.TabIndex = 7
      Me.lblTotalCredit.Text = "Total Credit="
      Me.lblTotalCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTotalCredit
      '
      Me.txtTotalCredit.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTotalCredit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalCredit, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotalCredit, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalCredit, System.Drawing.Color.Empty)
      Me.txtTotalCredit.Location = New System.Drawing.Point(584, 112)
      Me.Validator.SetMinValue(Me.txtTotalCredit, "")
      Me.txtTotalCredit.Name = "txtTotalCredit"
      Me.txtTotalCredit.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalCredit, "")
      Me.Validator.SetRequired(Me.txtTotalCredit, False)
      Me.txtTotalCredit.Size = New System.Drawing.Size(96, 20)
      Me.txtTotalCredit.TabIndex = 8
      Me.txtTotalCredit.TabStop = False
      '
      'btnCheckUnpostGL
      '
      Me.btnCheckUnpostGL.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCheckUnpostGL.Location = New System.Drawing.Point(232, 112)
      Me.btnCheckUnpostGL.Name = "btnCheckUnpostGL"
      Me.btnCheckUnpostGL.Size = New System.Drawing.Size(80, 23)
      Me.btnCheckUnpostGL.TabIndex = 4
      Me.btnCheckUnpostGL.Text = "GL ยังไม่ผ่าน"
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
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(128, 15)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(136, 21)
      Me.cmbCode.TabIndex = 333
      '
      'CloseAccountPeriodView
      '
      Me.Controls.Add(Me.txtTotalDebit)
      Me.Controls.Add(Me.lblTotalDebit)
      Me.Controls.Add(Me.lblTotalCredit)
      Me.Controls.Add(Me.txtTotalCredit)
      Me.Controls.Add(Me.btnCompile)
      Me.Controls.Add(Me.grbSum)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.btnCheckUnpostGL)
      Me.Name = "CloseAccountPeriodView"
      Me.Size = New System.Drawing.Size(688, 416)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbSum.ResumeLayout(False)
      Me.grbSum.PerformLayout()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As CloseAccountPeriod
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

      Dim dt As TreeTable = CloseAccountPeriod.GetSchemaTable()
      Dim dst As DataGridTableStyle = CloseAccountPeriod.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      EventWiring()

    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      m_enableState.Add(Me.btnCheckUnpostGL, Me.btnCheckUnpostGL.Enabled)
      m_enableState.Add(Me.btnCompile, Me.btnCompile.Enabled)
    End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value >= 3 OrElse Me.m_entity.Status.Value = 0 Then
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = False
        Next
        Me.btnCheckUnpostGL.Enabled = False
        Me.btnCompile.Enabled = False
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In Me.grbDetail.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        Me.btnCheckUnpostGL.Enabled = CBool(m_enableState(Me.btnCheckUnpostGL))
        Me.btnCompile.Enabled = CBool(m_enableState(Me.btnCompile))
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.lblItem}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.grbSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.grbSum}")
      Me.lblProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.lblProfit}")
      Me.lblTotalProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.lblTotalProfit}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.lblCode}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.lblAccProfitAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.lblAccProfitAccount}")
      Me.lblTotalDebit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.lblTotalDebit}")
      Me.lblTotalCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.lblTotalCredit}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.grbDetail}")
      Me.btnCompile.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.btnCompile}")
      Me.btnCheckUnpostGL.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodView.btnCheckUnpostGL}")
      Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
    End Sub
    Protected Overrides Sub EventWiring()
      'AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      'txtCode.Text = m_entity.Code
      cmbCode.Text = m_entity.Code
      txtNote.Text = m_entity.Note
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()


      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      Me.txtAccProfitAccountCode.Text = m_entity.ProfitAccount.Code
      Me.txtAccProfitAccountName.Text = m_entity.ProfitAccount.Name

      Me.txtEndPeriod.Text = m_entity.EndPeriod.ToString

      UpdateAmount(True)

      'Load Items**********************************************************
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      RefreshBlankGrid()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateAmount(ByVal refresh As Boolean)
      m_isInitialized = False
      If refresh Then
        Me.m_entity.RefreshGross()
      End If
      Me.txtTotalCredit.Text = Configuration.FormatToString(Me.m_entity.CreditAmount, DigitConfig.Price)
      Me.txtTotalDebit.Text = Configuration.FormatToString(Me.m_entity.DebitAmount, DigitConfig.Price)
      Me.txtProfit.Text = Configuration.FormatToString(Me.m_entity.Profit, DigitConfig.Price)
      Me.txtTotalProfit.Text = Configuration.FormatToString(Me.m_entity.AccProfit, DigitConfig.Price)
      m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount(True)
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
        'Case "txtcode"
        '  Me.m_entity.Code = txtCode.Text
        '  dirtyFlag = True
        Case "cmbcode"
          Me.m_entity.Code = cmbCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
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
            dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
          End If
          m_dateSetting = False
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
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, CloseAccountPeriod)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
    End Sub


#End Region

#Region "Buttons Event"
#End Region

#Region "Event Handlers"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList
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
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = False
      End If
      'If Me.chkAutorun.Checked Then
      '    Me.Validator.SetRequired(Me.txtCode, False)
      '    Me.ErrorProvider1.SetError(Me.txtCode, "")
      '    Me.txtCode.ReadOnly = True
      '    m_oldCode = Me.txtCode.Text
      '    Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
      '    'Hack: set Code เป็น "" เอง
      '    Me.m_entity.Code = ""
      '    Me.m_entity.AutoGen = True
      'Else
      '    Me.Validator.SetRequired(Me.txtCode, True)
      '    Me.txtCode.Text = m_oldCode
      '    Me.txtCode.ReadOnly = False
      '    Me.m_entity.AutoGen = False
      'End If
    End Sub
    Private Sub btnCompile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompile.Click
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.EndPeriod Is Nothing Then
        msgServ.ShowMessage("${res:Global.Error.SpecifyPeriodFirst}")
        Return
      End If
      If Not Me.m_entity.EndPeriod.Originated Then
        msgServ.ShowMessage("${res:Global.Error.SpecifyPeriodFirst}")
        Return
      End If
      Dim firstPeriod As AccountPeriod = Me.m_entity.EndPeriod.GetFirstUnlockedPeriodBefore
      Dim startDate As Date
      Dim endDate As Date
      If Not firstPeriod Is Nothing AndAlso firstPeriod.Originated Then
        startDate = firstPeriod.StartDate
      Else
        startDate = Me.m_entity.EndPeriod.StartDate
      End If
      endDate = Me.m_entity.EndPeriod.EndDate
      Dim gl As New JournalEntry
      Dim dt As DataTable = gl.GetUnpostListTable(startDate, endDate)
      If dt.Rows.Count > 0 Then
        If msgServ.AskQuestionFormatted("${res:Global.Error.StillHaveUnPostGL}", New String() {dt.Rows.Count.ToString}) Then
          Dim view As New PostGLView(startDate, endDate)
          view.RefreshList()
          Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
          myDialog.ShowDialog()
        End If
        Return
      End If
      'พร้อมแล้ว
      Me.m_entity.SetReverse4_5GLItems(startDate, endDate)
      Me.UpdateAmount(True)
      Me.RefreshBlankGrid()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub btnCheckUnpostGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckUnpostGL.Click
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.EndPeriod Is Nothing Then
        msgServ.ShowMessage("${res:Global.Error.SpecifyPeriodFirst}")
        Return
      End If
      If Not Me.m_entity.EndPeriod.Originated Then
        msgServ.ShowMessage("${res:Global.Error.SpecifyPeriodFirst}")
        Return
      End If
      Dim firstPeriod As AccountPeriod = Me.m_entity.EndPeriod.GetFirstUnlockedPeriodBefore
      Dim startDate As Date
      Dim endDate As Date
      If Not firstPeriod Is Nothing AndAlso firstPeriod.Originated Then
        startDate = firstPeriod.StartDate
      Else
        startDate = Me.m_entity.EndPeriod.StartDate
      End If
      endDate = Me.m_entity.EndPeriod.EndDate
      Dim view As New PostGLView(startDate, endDate)
      view.RefreshList()
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
      myDialog.ShowDialog()
    End Sub
    Private Sub ibtnShowPeriodDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowPeriodDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      filters(0) = New Filter("locked", 0)
      myEntityPanelService.OpenListDialog(New AccountPeriod, AddressOf SetPeriod, filters)
    End Sub
    Private Sub SetPeriod(ByVal e As ISimpleEntity)
      Dim newPeriod As AccountPeriod = CType(e, AccountPeriod)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Not newPeriod.Originated Then
        msgServ.ShowMessage("${res:Global.Error.NoPeriod}")
      ElseIf newPeriod.IsLocked Then
        msgServ.ShowMessageFormatted("${res:Global.Error.PeriodIsLocked}", New String() {newPeriod.ToString})
      Else
        Me.m_entity.ItemTable.Clear()
        Me.m_entity.EndPeriod = newPeriod
        Me.txtEndPeriod.Text = newPeriod.ToString
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        RefreshBlankGrid()
      End If
      Me.UpdateAmount(True)
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
        Return (New CloseAccountPeriod).DetailPanelIcon
      End Get
    End Property
#End Region

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

      Do Until Me.m_entity.ItemTable.Childs.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_entity.AddBlankRow(1)
      Loop

      'MessageBox.Show(tgItem.VisibleRowCount.ToString & ":" & Me.m_entity.ItemTable.Childs.Count.ToString)

      If Me.m_entity.MaxRowIndex = Me.m_entity.ItemTable.Childs.Count - 1 Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_entity.AddBlankRow(1)
      End If
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

  End Class
End Namespace