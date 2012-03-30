Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptAPPaymentFilterSubPanel
    'Inherits UserControl
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel

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
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
    Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
    Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents lblPaymentType As System.Windows.Forms.Label
    Friend WithEvents cmbPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierGroup As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupStart As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierGroupStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkIncludeSGChildren As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRefDocCodePrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtGLCodeprefix As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderBy As System.Windows.Forms.Label
    Friend WithEvents cmbOrderBy As System.Windows.Forms.ComboBox
    Friend WithEvents grbTypeDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkAdvMoney As System.Windows.Forms.CheckBox
    Friend WithEvents chkChq As System.Windows.Forms.CheckBox
    Friend WithEvents chkPettyCash As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransfer As System.Windows.Forms.CheckBox
    Friend WithEvents chkCash As System.Windows.Forms.CheckBox
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents KeepKeyCombo1 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
    Friend WithEvents txtPayIDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtPayIDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpPayIDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPayIDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPayIDateStart As System.Windows.Forms.Label
        Friend WithEvents lblPayIDateEnd As System.Windows.Forms.Label
        Friend WithEvents KeepKeyCombo2 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
        Friend WithEvents btnBankAcct As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtBankAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblbankacct As System.Windows.Forms.Label
    Friend WithEvents txtBankAcctName As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
    Friend WithEvents btnAccountStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountStart As System.Windows.Forms.Label
    Friend WithEvents chkShowBankDetail As System.Windows.Forms.CheckBox
        Friend WithEvents chkDetail As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptAPPaymentFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.KeepKeyCombo2 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
      Me.KeepKeyCombo1 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnAccountEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAccountCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblAccountEnd = New System.Windows.Forms.Label()
      Me.btnAccountStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAccountCodeStart = New System.Windows.Forms.TextBox()
      Me.lblAccountStart = New System.Windows.Forms.Label()
      Me.btnBankAcct = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBankAcctCode = New System.Windows.Forms.TextBox()
      Me.lblbankacct = New System.Windows.Forms.Label()
      Me.txtBankAcctName = New System.Windows.Forms.TextBox()
      Me.txtPayIDateEnd = New System.Windows.Forms.TextBox()
      Me.txtPayIDateStart = New System.Windows.Forms.TextBox()
      Me.dtpPayIDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpPayIDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblPayIDateStart = New System.Windows.Forms.Label()
      Me.lblPayIDateEnd = New System.Windows.Forms.Label()
      Me.grbTypeDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAdvMoney = New System.Windows.Forms.CheckBox()
      Me.chkChq = New System.Windows.Forms.CheckBox()
      Me.chkPettyCash = New System.Windows.Forms.CheckBox()
      Me.chkTransfer = New System.Windows.Forms.CheckBox()
      Me.chkCash = New System.Windows.Forms.CheckBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.chkDetail = New System.Windows.Forms.CheckBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
      Me.txtRefDocCodePrefix = New System.Windows.Forms.TextBox()
      Me.lblSupplierGroup = New System.Windows.Forms.Label()
      Me.txtGLCodeprefix = New System.Windows.Forms.TextBox()
      Me.txtSupplierGroupStart = New System.Windows.Forms.TextBox()
      Me.lblOrderBy = New System.Windows.Forms.Label()
      Me.btnSupplierGroupStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbOrderBy = New System.Windows.Forms.ComboBox()
      Me.chkIncludeSGChildren = New System.Windows.Forms.CheckBox()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblSuppliEnd = New System.Windows.Forms.Label()
      Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSuppliStart = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.lblPaymentType = New System.Windows.Forms.Label()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.cmbPaymentType = New System.Windows.Forms.ComboBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.chkShowBankDetail = New System.Windows.Forms.CheckBox()
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.grbTypeDisplay.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.KeepKeyCombo2)
      Me.grbMaster.Controls.Add(Me.KeepKeyCombo1)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.lblPaymentType)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 4)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(802, 241)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'KeepKeyCombo2
      '
      Me.KeepKeyCombo2.FormattingEnabled = True
      Me.KeepKeyCombo2.Location = New System.Drawing.Point(230, 244)
      Me.KeepKeyCombo2.Name = "KeepKeyCombo2"
      Me.KeepKeyCombo2.Size = New System.Drawing.Size(121, 21)
      Me.KeepKeyCombo2.TabIndex = 62
      '
      'KeepKeyCombo1
      '
      Me.KeepKeyCombo1.FormattingEnabled = True
      Me.KeepKeyCombo1.Location = New System.Drawing.Point(340, 241)
      Me.KeepKeyCombo1.Name = "KeepKeyCombo1"
      Me.KeepKeyCombo1.Size = New System.Drawing.Size(121, 21)
      Me.KeepKeyCombo1.TabIndex = 56
      Me.KeepKeyCombo1.Visible = False
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnAccountEndFind)
      Me.grbDetail.Controls.Add(Me.txtAccountCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblAccountEnd)
      Me.grbDetail.Controls.Add(Me.btnAccountStartFind)
      Me.grbDetail.Controls.Add(Me.txtAccountCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAccountStart)
      Me.grbDetail.Controls.Add(Me.btnBankAcct)
      Me.grbDetail.Controls.Add(Me.txtBankAcctCode)
      Me.grbDetail.Controls.Add(Me.lblbankacct)
      Me.grbDetail.Controls.Add(Me.txtBankAcctName)
      Me.grbDetail.Controls.Add(Me.txtPayIDateEnd)
      Me.grbDetail.Controls.Add(Me.txtPayIDateStart)
      Me.grbDetail.Controls.Add(Me.dtpPayIDateStart)
      Me.grbDetail.Controls.Add(Me.dtpPayIDateEnd)
      Me.grbDetail.Controls.Add(Me.lblPayIDateStart)
      Me.grbDetail.Controls.Add(Me.lblPayIDateEnd)
      Me.grbDetail.Controls.Add(Me.grbTypeDisplay)
      Me.grbDetail.Controls.Add(Me.Label2)
      Me.grbDetail.Controls.Add(Me.chkShowBankDetail)
      Me.grbDetail.Controls.Add(Me.chkDetail)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
      Me.grbDetail.Controls.Add(Me.txtRefDocCodePrefix)
      Me.grbDetail.Controls.Add(Me.lblSupplierGroup)
      Me.grbDetail.Controls.Add(Me.txtGLCodeprefix)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupStart)
      Me.grbDetail.Controls.Add(Me.lblOrderBy)
      Me.grbDetail.Controls.Add(Me.btnSupplierGroupStart)
      Me.grbDetail.Controls.Add(Me.cmbOrderBy)
      Me.grbDetail.Controls.Add(Me.chkIncludeSGChildren)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
      Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSuppliStart)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(773, 192)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnAccountEndFind
      '
      Me.btnAccountEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountEndFind.Location = New System.Drawing.Point(738, 162)
      Me.btnAccountEndFind.Name = "btnAccountEndFind"
      Me.btnAccountEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAccountEndFind.TabIndex = 69
      Me.btnAccountEndFind.TabStop = False
      Me.btnAccountEndFind.ThemedImage = CType(resources.GetObject("btnAccountEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAccountCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCodeEnd, "")
      Me.txtAccountCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
      Me.txtAccountCodeEnd.Location = New System.Drawing.Point(642, 162)
      Me.Validator.SetMaxValue(Me.txtAccountCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtAccountCodeEnd, "")
      Me.txtAccountCodeEnd.Name = "txtAccountCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAccountCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAccountCodeEnd, False)
      Me.txtAccountCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountCodeEnd.TabIndex = 67
      '
      'lblAccountEnd
      '
      Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAccountEnd.Location = New System.Drawing.Point(610, 162)
      Me.lblAccountEnd.Name = "lblAccountEnd"
      Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAccountEnd.TabIndex = 71
      Me.lblAccountEnd.Text = "ถึง"
      Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAccountStartFind
      '
      Me.btnAccountStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountStartFind.Location = New System.Drawing.Point(578, 162)
      Me.btnAccountStartFind.Name = "btnAccountStartFind"
      Me.btnAccountStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAccountStartFind.TabIndex = 68
      Me.btnAccountStartFind.TabStop = False
      Me.btnAccountStartFind.ThemedImage = CType(resources.GetObject("btnAccountStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountCodeStart
      '
      Me.Validator.SetDataType(Me.txtAccountCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCodeStart, "")
      Me.txtAccountCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
      Me.txtAccountCodeStart.Location = New System.Drawing.Point(482, 162)
      Me.Validator.SetMaxValue(Me.txtAccountCodeStart, "")
      Me.Validator.SetMinValue(Me.txtAccountCodeStart, "")
      Me.txtAccountCodeStart.Name = "txtAccountCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAccountCodeStart, "")
      Me.Validator.SetRequired(Me.txtAccountCodeStart, False)
      Me.txtAccountCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountCodeStart.TabIndex = 66
      '
      'lblAccountStart
      '
      Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
      Me.lblAccountStart.Location = New System.Drawing.Point(386, 162)
      Me.lblAccountStart.Name = "lblAccountStart"
      Me.lblAccountStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAccountStart.TabIndex = 70
      Me.lblAccountStart.Text = "ตั้งแต่สมุดรายวัน"
      Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnBankAcct
      '
      Me.btnBankAcct.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAcct.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankAcct.Location = New System.Drawing.Point(238, 137)
      Me.btnBankAcct.Name = "btnBankAcct"
      Me.btnBankAcct.Size = New System.Drawing.Size(24, 22)
      Me.btnBankAcct.TabIndex = 65
      Me.btnBankAcct.TabStop = False
      Me.btnBankAcct.ThemedImage = CType(resources.GetObject("btnBankAcct.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankAcctCode
      '
      Me.Validator.SetDataType(Me.txtBankAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAcctCode, "")
      Me.txtBankAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAcctCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAcctCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAcctCode, System.Drawing.Color.Empty)
      Me.txtBankAcctCode.Location = New System.Drawing.Point(142, 137)
      Me.txtBankAcctCode.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtBankAcctCode, "")
      Me.Validator.SetMinValue(Me.txtBankAcctCode, "")
      Me.txtBankAcctCode.Name = "txtBankAcctCode"
      Me.Validator.SetRegularExpression(Me.txtBankAcctCode, "")
      Me.Validator.SetRequired(Me.txtBankAcctCode, False)
      Me.txtBankAcctCode.Size = New System.Drawing.Size(96, 21)
      Me.txtBankAcctCode.TabIndex = 64
      '
      'lblbankacct
      '
      Me.lblbankacct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblbankacct.ForeColor = System.Drawing.Color.Black
      Me.lblbankacct.Location = New System.Drawing.Point(66, 137)
      Me.lblbankacct.Name = "lblbankacct"
      Me.lblbankacct.Size = New System.Drawing.Size(68, 18)
      Me.lblbankacct.TabIndex = 62
      Me.lblbankacct.Text = "บัญชีธนาคาร"
      Me.lblbankacct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBankAcctName
      '
      Me.Validator.SetDataType(Me.txtBankAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAcctName, "")
      Me.txtBankAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankAcctName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAcctName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAcctName, System.Drawing.Color.Empty)
      Me.txtBankAcctName.Location = New System.Drawing.Point(262, 137)
      Me.txtBankAcctName.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtBankAcctName, "")
      Me.Validator.SetMinValue(Me.txtBankAcctName, "")
      Me.txtBankAcctName.Name = "txtBankAcctName"
      Me.txtBankAcctName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankAcctName, "")
      Me.Validator.SetRequired(Me.txtBankAcctName, False)
      Me.txtBankAcctName.Size = New System.Drawing.Size(160, 21)
      Me.txtBankAcctName.TabIndex = 63
      '
      'txtPayIDateEnd
      '
      Me.Validator.SetDataType(Me.txtPayIDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtPayIDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPayIDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPayIDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPayIDateEnd, System.Drawing.Color.Empty)
      Me.txtPayIDateEnd.Location = New System.Drawing.Point(302, 41)
      Me.txtPayIDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtPayIDateEnd, "")
      Me.Validator.SetMinValue(Me.txtPayIDateEnd, "")
      Me.txtPayIDateEnd.Name = "txtPayIDateEnd"
      Me.Validator.SetRegularExpression(Me.txtPayIDateEnd, "")
      Me.Validator.SetRequired(Me.txtPayIDateEnd, False)
      Me.txtPayIDateEnd.Size = New System.Drawing.Size(84, 21)
      Me.txtPayIDateEnd.TabIndex = 60
      '
      'txtPayIDateStart
      '
      Me.Validator.SetDataType(Me.txtPayIDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtPayIDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPayIDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPayIDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPayIDateStart, System.Drawing.Color.Empty)
      Me.txtPayIDateStart.Location = New System.Drawing.Point(142, 41)
      Me.txtPayIDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtPayIDateStart, "")
      Me.Validator.SetMinValue(Me.txtPayIDateStart, "")
      Me.txtPayIDateStart.Name = "txtPayIDateStart"
      Me.Validator.SetRegularExpression(Me.txtPayIDateStart, "")
      Me.Validator.SetRequired(Me.txtPayIDateStart, False)
      Me.txtPayIDateStart.Size = New System.Drawing.Size(86, 21)
      Me.txtPayIDateStart.TabIndex = 57
      '
      'dtpPayIDateStart
      '
      Me.dtpPayIDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpPayIDateStart.Location = New System.Drawing.Point(142, 41)
      Me.dtpPayIDateStart.Name = "dtpPayIDateStart"
      Me.dtpPayIDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpPayIDateStart.TabIndex = 58
      Me.dtpPayIDateStart.TabStop = False
      '
      'dtpPayIDateEnd
      '
      Me.dtpPayIDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpPayIDateEnd.Location = New System.Drawing.Point(302, 41)
      Me.dtpPayIDateEnd.Name = "dtpPayIDateEnd"
      Me.dtpPayIDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpPayIDateEnd.TabIndex = 61
      Me.dtpPayIDateEnd.TabStop = False
      '
      'lblPayIDateStart
      '
      Me.lblPayIDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPayIDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblPayIDateStart.Location = New System.Drawing.Point(7, 44)
      Me.lblPayIDateStart.Name = "lblPayIDateStart"
      Me.lblPayIDateStart.Size = New System.Drawing.Size(127, 18)
      Me.lblPayIDateStart.TabIndex = 56
      Me.lblPayIDateStart.Text = "วันที่จ่าย"
      Me.lblPayIDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPayIDateEnd
      '
      Me.lblPayIDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPayIDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblPayIDateEnd.Location = New System.Drawing.Point(270, 41)
      Me.lblPayIDateEnd.Name = "lblPayIDateEnd"
      Me.lblPayIDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblPayIDateEnd.TabIndex = 59
      Me.lblPayIDateEnd.Text = "ถึง"
      Me.lblPayIDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'grbTypeDisplay
      '
      Me.grbTypeDisplay.Controls.Add(Me.chkAdvMoney)
      Me.grbTypeDisplay.Controls.Add(Me.chkChq)
      Me.grbTypeDisplay.Controls.Add(Me.chkPettyCash)
      Me.grbTypeDisplay.Controls.Add(Me.chkTransfer)
      Me.grbTypeDisplay.Controls.Add(Me.chkCash)
      Me.grbTypeDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbTypeDisplay.Location = New System.Drawing.Point(547, 92)
      Me.grbTypeDisplay.Name = "grbTypeDisplay"
      Me.grbTypeDisplay.Size = New System.Drawing.Size(213, 57)
      Me.grbTypeDisplay.TabIndex = 8
      Me.grbTypeDisplay.TabStop = False
      Me.grbTypeDisplay.Text = "ประเภทการจ่าย"
      '
      'chkAdvMoney
      '
      Me.chkAdvMoney.Checked = True
      Me.chkAdvMoney.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkAdvMoney.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkAdvMoney.Location = New System.Drawing.Point(102, 35)
      Me.chkAdvMoney.Name = "chkAdvMoney"
      Me.chkAdvMoney.Size = New System.Drawing.Size(88, 16)
      Me.chkAdvMoney.TabIndex = 16
      Me.chkAdvMoney.Text = "เงินทดรองจ่าย"
      '
      'chkChq
      '
      Me.chkChq.Checked = True
      Me.chkChq.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkChq.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkChq.Location = New System.Drawing.Point(102, 19)
      Me.chkChq.Name = "chkChq"
      Me.chkChq.Size = New System.Drawing.Size(47, 16)
      Me.chkChq.TabIndex = 17
      Me.chkChq.Text = "เช็ค"
      '
      'chkPettyCash
      '
      Me.chkPettyCash.Checked = True
      Me.chkPettyCash.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkPettyCash.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPettyCash.Location = New System.Drawing.Point(8, 35)
      Me.chkPettyCash.Name = "chkPettyCash"
      Me.chkPettyCash.Size = New System.Drawing.Size(88, 16)
      Me.chkPettyCash.TabIndex = 15
      Me.chkPettyCash.Text = "เงินสดย่อย"
      '
      'chkTransfer
      '
      Me.chkTransfer.Checked = True
      Me.chkTransfer.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkTransfer.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkTransfer.Location = New System.Drawing.Point(155, 19)
      Me.chkTransfer.Name = "chkTransfer"
      Me.chkTransfer.Size = New System.Drawing.Size(47, 16)
      Me.chkTransfer.TabIndex = 14
      Me.chkTransfer.Text = "โอน"
      '
      'chkCash
      '
      Me.chkCash.Checked = True
      Me.chkCash.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkCash.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkCash.Location = New System.Drawing.Point(8, 19)
      Me.chkCash.Name = "chkCash"
      Me.chkCash.Size = New System.Drawing.Size(88, 16)
      Me.chkCash.TabIndex = 13
      Me.chkCash.Text = "เงินสด"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(552, 65)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(80, 16)
      Me.Label2.TabIndex = 39
      Me.Label2.Text = "RefCodePrefix"
      '
      'chkDetail
      '
      Me.chkDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkDetail.Location = New System.Drawing.Point(142, 162)
      Me.chkDetail.Name = "chkDetail"
      Me.chkDetail.Size = New System.Drawing.Size(128, 24)
      Me.chkDetail.TabIndex = 55
      Me.chkDetail.Text = "แสดงรายละเอียด"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(552, 41)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(72, 16)
      Me.Label1.TabIndex = 38
      Me.Label1.Text = "GLCodePrefix"
      '
      'txtSupplierGroupName
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.txtSupplierGroupName.Location = New System.Drawing.Point(262, 65)
      Me.txtSupplierGroupName.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtSupplierGroupName, "")
      Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
      Me.txtSupplierGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
      Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
      Me.txtSupplierGroupName.TabIndex = 51
      '
      'txtRefDocCodePrefix
      '
      Me.Validator.SetDataType(Me.txtRefDocCodePrefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
      Me.txtRefDocCodePrefix.Location = New System.Drawing.Point(640, 65)
      Me.Validator.SetMaxValue(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetMinValue(Me.txtRefDocCodePrefix, "")
      Me.txtRefDocCodePrefix.Name = "txtRefDocCodePrefix"
      Me.Validator.SetRegularExpression(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetRequired(Me.txtRefDocCodePrefix, False)
      Me.txtRefDocCodePrefix.Size = New System.Drawing.Size(120, 21)
      Me.txtRefDocCodePrefix.TabIndex = 37
      '
      'lblSupplierGroup
      '
      Me.lblSupplierGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplierGroup.ForeColor = System.Drawing.Color.Black
      Me.lblSupplierGroup.Location = New System.Drawing.Point(9, 65)
      Me.lblSupplierGroup.Name = "lblSupplierGroup"
      Me.lblSupplierGroup.Size = New System.Drawing.Size(125, 18)
      Me.lblSupplierGroup.TabIndex = 50
      Me.lblSupplierGroup.Text = "กลุ่มผู้ขาย:"
      Me.lblSupplierGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGLCodeprefix
      '
      Me.Validator.SetDataType(Me.txtGLCodeprefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGLCodeprefix, "")
      Me.Validator.SetGotFocusBackColor(Me.txtGLCodeprefix, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGLCodeprefix, System.Drawing.Color.Empty)
      Me.txtGLCodeprefix.Location = New System.Drawing.Point(640, 41)
      Me.Validator.SetMaxValue(Me.txtGLCodeprefix, "")
      Me.Validator.SetMinValue(Me.txtGLCodeprefix, "")
      Me.txtGLCodeprefix.Name = "txtGLCodeprefix"
      Me.Validator.SetRegularExpression(Me.txtGLCodeprefix, "")
      Me.Validator.SetRequired(Me.txtGLCodeprefix, False)
      Me.txtGLCodeprefix.Size = New System.Drawing.Size(120, 21)
      Me.txtGLCodeprefix.TabIndex = 36
      '
      'txtSupplierGroupStart
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupStart, "")
      Me.txtSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
      Me.txtSupplierGroupStart.Location = New System.Drawing.Point(142, 65)
      Me.txtSupplierGroupStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtSupplierGroupStart, "")
      Me.Validator.SetMinValue(Me.txtSupplierGroupStart, "")
      Me.txtSupplierGroupStart.Name = "txtSupplierGroupStart"
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupStart, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupStart, False)
      Me.txtSupplierGroupStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSupplierGroupStart.TabIndex = 52
      '
      'lblOrderBy
      '
      Me.lblOrderBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOrderBy.ForeColor = System.Drawing.Color.Black
      Me.lblOrderBy.Location = New System.Drawing.Point(544, 17)
      Me.lblOrderBy.Name = "lblOrderBy"
      Me.lblOrderBy.Size = New System.Drawing.Size(88, 18)
      Me.lblOrderBy.TabIndex = 35
      Me.lblOrderBy.Text = "เรียงตาม"
      Me.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSupplierGroupStart
      '
      Me.btnSupplierGroupStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierGroupStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierGroupStart.Location = New System.Drawing.Point(238, 65)
      Me.btnSupplierGroupStart.Name = "btnSupplierGroupStart"
      Me.btnSupplierGroupStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSupplierGroupStart.TabIndex = 53
      Me.btnSupplierGroupStart.TabStop = False
      Me.btnSupplierGroupStart.ThemedImage = CType(resources.GetObject("btnSupplierGroupStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbOrderBy
      '
      Me.cmbOrderBy.Location = New System.Drawing.Point(640, 17)
      Me.cmbOrderBy.Name = "cmbOrderBy"
      Me.cmbOrderBy.Size = New System.Drawing.Size(120, 21)
      Me.cmbOrderBy.TabIndex = 34
      '
      'chkIncludeSGChildren
      '
      Me.chkIncludeSGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeSGChildren.Location = New System.Drawing.Point(423, 65)
      Me.chkIncludeSGChildren.Name = "chkIncludeSGChildren"
      Me.chkIncludeSGChildren.Size = New System.Drawing.Size(128, 21)
      Me.chkIncludeSGChildren.TabIndex = 54
      Me.chkIncludeSGChildren.Text = "รวมกลุ่มผู้ขายลูก"
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(423, 113)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(144, 24)
      Me.chkIncludeChildren.TabIndex = 23
      Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(238, 113)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 22
      Me.btnCCCodeStart.TabStop = False
      Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(142, 113)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 21
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(66, 113)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(68, 18)
      Me.lblCCStart.TabIndex = 19
      Me.lblCCStart.Text = "Cost Center"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(262, 113)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 20
      '
      'btnSuppliEndFind
      '
      Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliEndFind.Location = New System.Drawing.Point(398, 89)
      Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
      Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliEndFind.TabIndex = 11
      Me.btnSuppliEndFind.TabStop = False
      Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuppliCodeEnd
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(302, 89)
      Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
      Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeEnd.TabIndex = 10
      '
      'lblSuppliEnd
      '
      Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliEnd.Location = New System.Drawing.Point(270, 89)
      Me.lblSuppliEnd.Name = "lblSuppliEnd"
      Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSuppliEnd.TabIndex = 9
      Me.lblSuppliEnd.Text = "ถึง"
      Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSuppliStartFind
      '
      Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliStartFind.Location = New System.Drawing.Point(238, 89)
      Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
      Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliStartFind.TabIndex = 8
      Me.btnSuppliStartFind.TabStop = False
      Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuppliCodeStart
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.txtSuppliCodeStart.Location = New System.Drawing.Point(142, 89)
      Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
      Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
      Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeStart.TabIndex = 7
      '
      'lblSuppliStart
      '
      Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliStart.Location = New System.Drawing.Point(6, 89)
      Me.lblSuppliStart.Name = "lblSuppliStart"
      Me.lblSuppliStart.Size = New System.Drawing.Size(128, 18)
      Me.lblSuppliStart.TabIndex = 6
      Me.lblSuppliStart.Text = "Supplier:"
      Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(302, 17)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(84, 21)
      Me.txtDocDateEnd.TabIndex = 4
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(142, 17)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(86, 21)
      Me.txtDocDateStart.TabIndex = 1
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(142, 17)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(302, 17)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(6, 17)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(128, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(270, 17)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(714, 214)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(634, 214)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'lblPaymentType
      '
      Me.lblPaymentType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPaymentType.ForeColor = System.Drawing.Color.Black
      Me.lblPaymentType.Location = New System.Drawing.Point(708, 160)
      Me.lblPaymentType.Name = "lblPaymentType"
      Me.lblPaymentType.Size = New System.Drawing.Size(80, 18)
      Me.lblPaymentType.TabIndex = 31
      Me.lblPaymentType.Text = "ประเภทการจ่าย"
      Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblPaymentType.Visible = False
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(847, 55)
      Me.Validator.SetMaxValue(Me.txtTemp, "")
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(120, 21)
      Me.txtTemp.TabIndex = 56
      '
      'cmbPaymentType
      '
      Me.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPaymentType.Location = New System.Drawing.Point(849, 164)
      Me.cmbPaymentType.Name = "cmbPaymentType"
      Me.cmbPaymentType.Size = New System.Drawing.Size(120, 21)
      Me.cmbPaymentType.TabIndex = 32
      Me.cmbPaymentType.Visible = False
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
      'chkShowBankDetail
      '
      Me.chkShowBankDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowBankDetail.Location = New System.Drawing.Point(273, 162)
      Me.chkShowBankDetail.Name = "chkShowBankDetail"
      Me.chkShowBankDetail.Size = New System.Drawing.Size(113, 24)
      Me.chkShowBankDetail.TabIndex = 55
      Me.chkShowBankDetail.Text = "Bank Detail"
      '
      'RptAPPaymentFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Controls.Add(Me.txtTemp)
      Me.Controls.Add(Me.cmbPaymentType)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptAPPaymentFilterSubPanel"
      Me.Size = New System.Drawing.Size(822, 257)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbTypeDisplay.ResumeLayout(False)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblSuppliStart}")
            Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

            'SupplierGroup
            Me.lblSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblSupplierGroup}")
            Me.Validator.SetDisplayName(txtSupplierGroupStart, lblSupplierGroup.Text)
            Me.chkIncludeSGChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.chkIncludeSGChildren}")

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)
            Me.lblPayIDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblPayIDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblPayIDateStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblCCStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            ' Global {ถึง}
            Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtSuppliCodeEnd, lblSuppliEnd.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblPayIDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
            Me.Validator.SetDisplayName(txtPayIDateEnd, lblPayIDateEnd.Text)
            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.grbDetail}")
            'Checkbox
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.chkIncludeChildren}")

            Me.lblPaymentType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.lblPaymentType}")
            Me.chkDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPaymentFilterSubPanel.chkDetail}")
        End Sub
#End Region

#Region "Member"
        Private m_supplierstart As Supplier
        Private m_supplierend As Supplier
        Private m_sg As SupplierGroup

        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date

        Private m_PayIDateEnd As Date
        Private m_PayIDateStart As Date

        Private m_cc As CostCenter

    Private m_bankacct As BankAccount
    Private m_AccountBookStart As AccountBook
    Private m_AccountBookEnd As AccountBook
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Public Property SupplierStart() As Supplier
            Get
                Return m_supplierstart
            End Get
            Set(ByVal Value As Supplier)
                m_supplierstart = Value
            End Set
        End Property
        Public Property SupplierEnd() As Supplier
            Get
                Return m_supplierend
            End Get
            Set(ByVal Value As Supplier)
                m_supplierend = Value
            End Set
        End Property
        Public Property SupplierGroup() As SupplierGroup
            Get
                Return m_sg
            End Get
            Set(ByVal Value As SupplierGroup)
                m_sg = Value
            End Set
        End Property
        Public Property BankAcct() As BankAccount
            Get
                Return m_bankacct
            End Get
            Set(ByVal Value As BankAccount)
                m_bankacct = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property

        Public Property PayIDateStart As Date
            Get
                Return m_PayIDateStart
            End Get
            Set(ByVal value As Date)
                m_PayIDateStart = value
            End Set
        End Property
        Public Property PayIDateEnd As Date
            Get
                Return m_PayIDateEnd
            End Get
            Set(ByVal value As Date)
                m_PayIDateEnd = value
            End Set
        End Property
        Public Property Costcenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
    End Property
    Public Property AccountBookStart() As AccountBook
      Get
        Return m_AccountBookStart
      End Get
      Set(ByVal Value As AccountBook)
        m_AccountBookStart = Value
      End Set
    End Property
    Public Property AccountBookEnd() As AccountBook
      Get
        Return m_AccountBookEnd
      End Get
      Set(ByVal Value As AccountBook)
        m_AccountBookEnd = Value
      End Set
    End Property
#End Region

#Region "Methods"

        Private Sub Initialize()
            RegisterDropdown()
            ClearCriterias()
        End Sub
        Private Sub RegisterDropdown()
            ' ประเภทการจ่าย
            CodeDescription.ListCodeDescriptionInComboBox(cmbPaymentType, "paymenti_entityType", True)
            Dim cmbOrderbyOption(3) As String
            cmbPaymentType.SelectedIndex = 0
            cmbOrderBy.Items.Clear()
            cmbOrderbyOption(0) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.ReciveDate}")
            cmbOrderbyOption(1) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.DocCode}")
            cmbOrderbyOption(2) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.RefDocCode}")
            cmbOrderbyOption(3) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.SupplierCode}")
            cmbOrderBy.Items.Add(cmbOrderbyOption(0))
            cmbOrderBy.Items.Add(cmbOrderbyOption(1))
            cmbOrderBy.Items.Add(cmbOrderbyOption(2))
            cmbOrderBy.Items.Add(cmbOrderbyOption(3))
            cmbOrderBy.SelectedIndex = 0

        End Sub

        Private Sub ClearCriterias()
            For Each grbCtrl As Control In grbMaster.Controls
                If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next

      Me.Costcenter = New CostCenter

      Me.AccountBookStart = New AccountBook
      Me.AccountBookEnd = New AccountBook

            Me.SupplierGroup = New SupplierGroup
            Me.SupplierStart = New Supplier
            Me.SupplierEnd = New Supplier

            Me.PayIDateStart = Date.MinValue
            Me.PayIDateEnd = Date.MinValue

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.txtPayIDateStart.Text = MinDateToNull(Me.PayIDateStart, "")
            Me.dtpPayIDateStart.Value = MinDateToNow(Me.PayIDateStart)

            cmbOrderBy.SelectedIndex = 0
            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.txtPayIDateEnd.Text = MinDateToNull(Me.PayIDateEnd, "")
            Me.dtpPayIDateEnd.Value = MinDateToNow(Me.PayIDateEnd)

            Me.chkDetail.Checked = False
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
      Dim arr(20) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("sg_id", Me.ValidIdOrDBNull(m_sg))
            arr(5) = New Filter("IncludeChildSG", Me.chkIncludeSGChildren.Checked)
            arr(6) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(7) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(8) = New Filter("PaymentType", CType(cmbPaymentType.SelectedItem, IdValuePair).Id)
            arr(9) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(10) = New Filter("ShowDetail", IIf(Me.chkDetail.Checked, 1, 0))
            arr(11) = New Filter("OrderBy", Me.cmbOrderBy.SelectedIndex)
            arr(12) = New Filter("GLCodeprefix", IIf(txtGLCodeprefix.TextLength > 0, txtGLCodeprefix.Text, DBNull.Value))
            arr(13) = New Filter("RefDocCodePrefix", IIf(txtRefDocCodePrefix.TextLength > 0, txtRefDocCodePrefix.Text, DBNull.Value))
            arr(14) = New Filter("Type", GetChekType())
            arr(15) = New Filter("PayIDateStart", IIf(Me.PayIDateStart.Equals(Date.MinValue), DBNull.Value, Me.PayIDateStart))
            arr(16) = New Filter("PayIDateEnd", IIf(Me.PayIDateEnd.Equals(Date.MinValue), DBNull.Value, Me.PayIDateEnd))
      arr(17) = New Filter("BankAcctCode", IIf(txtBankAcctCode.TextLength > 0, txtBankAcctCode.Text, DBNull.Value))
      arr(18) = New Filter("accountbookfrom", IIf(txtAccountCodeStart.TextLength > 0, txtAccountCodeStart.Text, DBNull.Value))
      arr(19) = New Filter("accountbookend", IIf(txtAccountCodeEnd.TextLength > 0, txtAccountCodeEnd.Text, DBNull.Value))
      arr(20) = New Filter("ShowBankDetail", IIf(Me.chkShowBankDetail.Checked, 1, 0))
            Return arr
        End Function
        Private Function GetChekType() As String
            Dim type As String = ""
            If Me.chkCash.Checked = False And Me.chkChq.Checked = False And Me.chkTransfer.Checked = False And Me.chkPettyCash.Checked = False And Me.chkAdvMoney.Checked = False Then
                type = Nothing
            Else

                If Me.chkCash.Checked Then
                    type &= "0"
                End If
                If Me.chkChq.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "22,336"
                End If

                If Me.chkTransfer.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "65"
                End If
                If Me.chkPettyCash.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "36"
                End If
                If Me.chkAdvMoney.Checked Then
                    If Len(type) > 0 Then
                        type &= ","
                    End If
                    type &= "174"
                End If
            End If
            Return type
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region " IReportFilterSubPanel "
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'costcenter start
            dpi = New DocPrintingItem
            dpi.Mapping = "costcenterstart"
            dpi.Value = Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Payment Type
            dpi = New DocPrintingItem
            dpi.Mapping = "paymenttype"
            dpi.Value = CType(Me.cmbPaymentType.SelectedItem, IdValuePair).Value
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'SupplierGroup
            dpi = New DocPrintingItem
            dpi.Mapping = "SupplierGroup"
            dpi.Value = Me.txtSupplierGroupName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler btnSupplierGroupStart.Click, AddressOf Me.btnSupplierGroupFind_Click
            AddHandler txtSupplierGroupStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnBankAcct.Click, AddressOf Me.btnBankAcctFind_Click
            AddHandler txtBankAcctCode.Validated, AddressOf Me.ChangeProperty

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtPayIDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtPayIDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpPayIDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpPayIDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler btnAccountStartFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnAccountEndFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeEnd.Validated, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

                Case "txtsuppliergroupstart"
                    SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, Me.txtSupplierGroupName, m_sg)

                Case "txtbankacctcode"
                    BankAccount.GetBankAccount(txtBankAcctCode, Me.txtBankAcctName, m_bankacct)

                Case "dtpdocdatestart"
                    If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    End If
                Case "dtppayidatestart"
                    If Not Me.DocDateStart.Equals(dtpPayIDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtPayIDateStart.Text = MinDateToNull(dtpPayIDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.PayIDateStart = dtpPayIDateStart.Value
                        End If
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.DocDateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.DocDateStart = Date.MinValue
                    End If
                    m_dateSetting = False
                Case "txtpayidatestart"
                    m_dateSetting = True
                    If Not Me.txtPayIDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtPayIDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtPayIDateStart.Text)
                        If Not Me.PayIDateStart.Equals(theDate) Then
                            dtpPayIDateStart.Value = theDate
                            Me.PayIDateStart = dtpPayIDateStart.Value
                        End If
                    Else
                        Me.dtpPayIDateStart.Value = Date.Now
                        Me.PayIDateStart = Date.MinValue
                    End If
                    m_dateSetting = False
                Case "dtpdocdateend"
                    If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.DocDateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.DocDateEnd = Date.MinValue
                    End If
                    m_dateSetting = False
                Case "dtppayidateend"
                    If Not Me.PayIDateEnd.Equals(dtpPayIDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtPayIDateEnd.Text = MinDateToNull(dtpPayIDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.PayIDateEnd = dtpPayIDateEnd.Value
                        End If
                    End If
                Case "txtpayidateend"
                    m_dateSetting = True
                    If Not Me.txtPayIDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtPayIDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.PayIDateEnd.Equals(theDate) Then
                            dtpPayIDateEnd.Value = theDate
                            Me.PayIDateEnd = dtpPayIDateEnd.Value
                        End If
                    Else
                        Me.dtpPayIDateEnd.Value = Date.Now
                        Me.PayIDateEnd = Date.MinValue
                    End If
          m_dateSetting = False
        Case "txtaccountcodestart"
          AccountBook.GetAccountBook(txtAccountCodeStart, txtTemp, Me.m_AccountBookStart)
        Case "txtaccountcodeend"
          AccountBook.GetAccountBook(txtAccountCodeEnd, txtTemp, Me.m_AccountBookEnd)
                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtsupplicodestart", "txtsupplicodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Costcenter
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccodestart", "txtcccodeend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtsupplicodestart"
                            Me.SetSupplierStartDialog(entity)

                        Case "txtsupplicodeend"
                            Me.SetSupplierEndDialog(entity)

                    End Select
                End If
            End If
            ' Costcenter
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercodestart"
                            Me.SetCCCodeStartDialog(entity)

                        Case "txtcostcentercodeend"
                            Me.SetCCCodeStartDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsupplistartfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

                Case "btnsuppliendfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

            End Select
        End Sub
        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsuppliergroupstart"
                    myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSupplierGroupStartDialog)
            End Select
        End Sub
        Private Sub btnBankAcctFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnbankacct"
                    myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAcctDialog)
            End Select
        End Sub
        Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeStart.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)
        End Sub
        Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeEnd.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)
        End Sub
        Private Sub SetSupplierGroupStartDialog(ByVal e As ISimpleEntity)
            Me.txtSupplierGroupStart.Text = e.Code
            SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, txtSupplierGroupName, m_sg)
        End Sub
        Private Sub SetBankAcctDialog(ByVal e As ISimpleEntity)
            Me.txtBankAcctCode.Text = e.Code
            BankAccount.GetBankAccount(txtBankAcctCode, txtBankAcctName, m_bankacct)
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnaccountstartfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookStartDialog)

        Case "btnaccountendfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookEndDialog)

      End Select
    End Sub
    Private Sub SetAcctBookStartDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCodeStart.Text = e.Code
      AccountBook.GetAccountBook(txtAccountCodeStart, txtTemp, Me.m_AccountBookStart)
    End Sub
    Private Sub SetAcctBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCodeEnd.Text = e.Code
      AccountBook.GetAccountBook(txtAccountCodeEnd, txtTemp, Me.m_AccountBookEnd)
    End Sub
#End Region

        Private Sub grbMaster_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbMaster.Enter

        End Sub
    End Class
End Namespace

