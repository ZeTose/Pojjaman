Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class PettyCashDetail
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
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents grbBillRec As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblBillRecWeek As System.Windows.Forms.Label
    Friend WithEvents lblBillRecDate As System.Windows.Forms.Label
    Friend WithEvents lblBillRecDay As System.Windows.Forms.Label
    Friend WithEvents grbPettyCash As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents grbLocation As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents grbWithdraw As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtlimit As System.Windows.Forms.TextBox
    Friend WithEvents lblBaht1 As System.Windows.Forms.Label
    Friend WithEvents txtNote As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtCCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents txtCCName As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnBillRecDays As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBillRecWeeks As System.Windows.Forms.TextBox
    Friend WithEvents txtBillRecDates As System.Windows.Forms.TextBox
    Friend WithEvents txtBillRecDays As System.Windows.Forms.TextBox
    Friend WithEvents btnBillRecDates As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnBillRecWeeks As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnEmployeeFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnEmployeeEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents rdIsEmployee As System.Windows.Forms.RadioButton
    Friend WithEvents rdIsCC As System.Windows.Forms.RadioButton
    Friend WithEvents rdNotAllow As System.Windows.Forms.RadioButton
    Friend WithEvents rdLimited As System.Windows.Forms.RadioButton
    Friend WithEvents rdAllow As System.Windows.Forms.RadioButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtdocdate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblBaht3 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashDetail))
      Me.btnAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtName = New System.Windows.Forms.TextBox
      Me.lblName = New System.Windows.Forms.Label
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblAccount = New System.Windows.Forms.Label
      Me.txtAccountCode = New System.Windows.Forms.TextBox
      Me.txtAccountName = New System.Windows.Forms.TextBox
      Me.grbPettyCash = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtTotal = New System.Windows.Forms.TextBox
      Me.lblBaht3 = New System.Windows.Forms.Label
      Me.lblTotal = New System.Windows.Forms.Label
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblItem = New System.Windows.Forms.Label
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.txtdocdate = New System.Windows.Forms.TextBox
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.lblStatus = New System.Windows.Forms.Label
      Me.btnAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbBillRec = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnBillRecDays = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtBillRecWeeks = New System.Windows.Forms.TextBox
      Me.txtBillRecDates = New System.Windows.Forms.TextBox
      Me.lblBillRecWeek = New System.Windows.Forms.Label
      Me.lblBillRecDate = New System.Windows.Forms.Label
      Me.lblBillRecDay = New System.Windows.Forms.Label
      Me.txtBillRecDays = New System.Windows.Forms.TextBox
      Me.btnBillRecDates = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnBillRecWeeks = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbLocation = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnEmployeeFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCode = New System.Windows.Forms.TextBox
      Me.rdIsEmployee = New System.Windows.Forms.RadioButton
      Me.btnEmployeeEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEmployeeCode = New System.Windows.Forms.TextBox
      Me.txtEmployeeName = New System.Windows.Forms.TextBox
      Me.rdIsCC = New System.Windows.Forms.RadioButton
      Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCName = New System.Windows.Forms.TextBox
      Me.txtAmount = New System.Windows.Forms.TextBox
      Me.lblAmount = New System.Windows.Forms.Label
      Me.lblBaht = New System.Windows.Forms.Label
      Me.grbWithdraw = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtlimit = New System.Windows.Forms.TextBox
      Me.rdNotAllow = New System.Windows.Forms.RadioButton
      Me.rdLimited = New System.Windows.Forms.RadioButton
      Me.lblBaht1 = New System.Windows.Forms.Label
      Me.rdAllow = New System.Windows.Forms.RadioButton
      Me.txtNote = New Longkong.Pojjaman.Gui.Components.MultiLineTextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.cmbCode = New System.Windows.Forms.ComboBox
      Me.grbPettyCash.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbBillRec.SuspendLayout()
      Me.grbLocation.SuspendLayout()
      Me.grbWithdraw.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAccountEdit
      '
      Me.btnAccountEdit.Image = CType(resources.GetObject("btnAccountEdit.Image"), System.Drawing.Image)
      Me.btnAccountEdit.Location = New System.Drawing.Point(520, 176)
      Me.btnAccountEdit.Name = "btnAccountEdit"
      Me.btnAccountEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnAccountEdit.TabIndex = 16
      Me.btnAccountEdit.TabStop = False
      Me.btnAccountEdit.ThemedImage = CType(resources.GetObject("btnAccountEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(120, 48)
      Me.Validator.SetMaxValue(Me.txtName, "")
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(424, 21)
      Me.txtName.TabIndex = 7
      Me.txtName.Text = ""
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(8, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(104, 18)
      Me.lblName.TabIndex = 6
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAccount
      '
      Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccount.ForeColor = System.Drawing.Color.Black
      Me.lblAccount.Location = New System.Drawing.Point(8, 176)
      Me.lblAccount.Name = "lblAccount"
      Me.lblAccount.Size = New System.Drawing.Size(104, 18)
      Me.lblAccount.TabIndex = 12
      Me.lblAccount.Text = "บัญชี:"
      Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAccountCode
      '
      Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCode, "")
      Me.txtAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.txtAccountCode.Location = New System.Drawing.Point(120, 176)
      Me.Validator.SetMaxValue(Me.txtAccountCode, "")
      Me.Validator.SetMinValue(Me.txtAccountCode, "")
      Me.txtAccountCode.Name = "txtAccountCode"
      Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccountCode, False)
      Me.txtAccountCode.Size = New System.Drawing.Size(128, 21)
      Me.txtAccountCode.TabIndex = 16
      Me.txtAccountCode.Text = ""
      '
      'txtAccountName
      '
      Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountName, "")
      Me.txtAccountName.Enabled = False
      Me.txtAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
      Me.txtAccountName.Location = New System.Drawing.Point(248, 176)
      Me.Validator.SetMaxValue(Me.txtAccountName, "")
      Me.Validator.SetMinValue(Me.txtAccountName, "")
      Me.txtAccountName.Name = "txtAccountName"
      Me.txtAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountName, "")
      Me.Validator.SetRequired(Me.txtAccountName, False)
      Me.txtAccountName.Size = New System.Drawing.Size(248, 21)
      Me.txtAccountName.TabIndex = 17
      Me.txtAccountName.TabStop = False
      Me.txtAccountName.Text = ""
      '
      'grbPettyCash
      '
      Me.grbPettyCash.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPettyCash.Controls.Add(Me.cmbCode)
      Me.grbPettyCash.Controls.Add(Me.txtTotal)
      Me.grbPettyCash.Controls.Add(Me.lblBaht3)
      Me.grbPettyCash.Controls.Add(Me.lblTotal)
      Me.grbPettyCash.Controls.Add(Me.tgItem)
      Me.grbPettyCash.Controls.Add(Me.lblItem)
      Me.grbPettyCash.Controls.Add(Me.chkAutorun)
      Me.grbPettyCash.Controls.Add(Me.txtdocdate)
      Me.grbPettyCash.Controls.Add(Me.dtpDocDate)
      Me.grbPettyCash.Controls.Add(Me.lblStatus)
      Me.grbPettyCash.Controls.Add(Me.btnAccountFind)
      Me.grbPettyCash.Controls.Add(Me.grbBillRec)
      Me.grbPettyCash.Controls.Add(Me.grbLocation)
      Me.grbPettyCash.Controls.Add(Me.txtAccountCode)
      Me.grbPettyCash.Controls.Add(Me.lblAccount)
      Me.grbPettyCash.Controls.Add(Me.txtAccountName)
      Me.grbPettyCash.Controls.Add(Me.txtName)
      Me.grbPettyCash.Controls.Add(Me.btnAccountEdit)
      Me.grbPettyCash.Controls.Add(Me.lblName)
      Me.grbPettyCash.Controls.Add(Me.lblCode)
      Me.grbPettyCash.Controls.Add(Me.txtAmount)
      Me.grbPettyCash.Controls.Add(Me.lblAmount)
      Me.grbPettyCash.Controls.Add(Me.lblBaht)
      Me.grbPettyCash.Controls.Add(Me.grbWithdraw)
      Me.grbPettyCash.Controls.Add(Me.txtNote)
      Me.grbPettyCash.Controls.Add(Me.lblNote)
      Me.grbPettyCash.Controls.Add(Me.lblDocDate)
      Me.grbPettyCash.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbPettyCash.Location = New System.Drawing.Point(8, 8)
      Me.grbPettyCash.Name = "grbPettyCash"
      Me.grbPettyCash.Size = New System.Drawing.Size(584, 536)
      Me.grbPettyCash.TabIndex = 0
      Me.grbPettyCash.TabStop = False
      Me.grbPettyCash.Text = "ตั้งวงเงินสดย่อย"
      '
      'txtTotal
      '
      Me.Validator.SetDataType(Me.txtTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotal, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotal, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotal, System.Drawing.Color.Empty)
      Me.txtTotal.Location = New System.Drawing.Point(360, 331)
      Me.Validator.SetMaxValue(Me.txtTotal, "")
      Me.Validator.SetMinValue(Me.txtTotal, "")
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotal, "")
      Me.Validator.SetRequired(Me.txtTotal, False)
      Me.txtTotal.Size = New System.Drawing.Size(136, 20)
      Me.txtTotal.TabIndex = 206
      Me.txtTotal.Text = ""
      '
      'lblBaht3
      '
      Me.lblBaht3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht3.ForeColor = System.Drawing.Color.Black
      Me.lblBaht3.Location = New System.Drawing.Point(504, 331)
      Me.lblBaht3.Name = "lblBaht3"
      Me.lblBaht3.Size = New System.Drawing.Size(32, 16)
      Me.lblBaht3.TabIndex = 203
      Me.lblBaht3.Text = "บาท"
      Me.lblBaht3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblTotal
      '
      Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotal.Location = New System.Drawing.Point(224, 331)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(128, 18)
      Me.lblTotal.TabIndex = 205
      Me.lblTotal.Text = "ยอดเงินสดย่อยคงเหลือ:"
      Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(16, 355)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(544, 152)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 207
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(16, 339)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(176, 18)
      Me.lblItem.TabIndex = 204
      Me.lblItem.Text = "บันทึกยอดตัดจ่ายเงินสดย่อย"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(248, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 2
      '
      'txtdocdate
      '
      Me.Validator.SetDataType(Me.txtdocdate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtdocdate, "")
      Me.txtdocdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtdocdate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtdocdate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtdocdate, System.Drawing.Color.Empty)
      Me.txtdocdate.Location = New System.Drawing.Point(416, 24)
      Me.Validator.SetMaxValue(Me.txtdocdate, "")
      Me.Validator.SetMinValue(Me.txtdocdate, "")
      Me.txtdocdate.Name = "txtdocdate"
      Me.Validator.SetRegularExpression(Me.txtdocdate, "")
      Me.Validator.SetRequired(Me.txtdocdate, True)
      Me.txtdocdate.Size = New System.Drawing.Size(110, 21)
      Me.txtdocdate.TabIndex = 4
      Me.txtdocdate.Text = ""
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(416, 24)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(128, 21)
      Me.dtpDocDate.TabIndex = 5
      Me.dtpDocDate.TabStop = False
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Location = New System.Drawing.Point(16, 512)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 16)
      Me.lblStatus.TabIndex = 21
      Me.lblStatus.Text = "lblStatus"
      '
      'btnAccountFind
      '
      Me.btnAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountFind.Image = CType(resources.GetObject("btnAccountFind.Image"), System.Drawing.Image)
      Me.btnAccountFind.Location = New System.Drawing.Point(496, 176)
      Me.btnAccountFind.Name = "btnAccountFind"
      Me.btnAccountFind.Size = New System.Drawing.Size(24, 23)
      Me.btnAccountFind.TabIndex = 15
      Me.btnAccountFind.TabStop = False
      Me.btnAccountFind.ThemedImage = CType(resources.GetObject("btnAccountFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbBillRec
      '
      Me.grbBillRec.Controls.Add(Me.btnBillRecDays)
      Me.grbBillRec.Controls.Add(Me.txtBillRecWeeks)
      Me.grbBillRec.Controls.Add(Me.txtBillRecDates)
      Me.grbBillRec.Controls.Add(Me.lblBillRecWeek)
      Me.grbBillRec.Controls.Add(Me.lblBillRecDate)
      Me.grbBillRec.Controls.Add(Me.lblBillRecDay)
      Me.grbBillRec.Controls.Add(Me.txtBillRecDays)
      Me.grbBillRec.Controls.Add(Me.btnBillRecDates)
      Me.grbBillRec.Controls.Add(Me.btnBillRecWeeks)
      Me.grbBillRec.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbBillRec.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbBillRec.Location = New System.Drawing.Point(304, 232)
      Me.grbBillRec.Name = "grbBillRec"
      Me.grbBillRec.Size = New System.Drawing.Size(248, 96)
      Me.grbBillRec.TabIndex = 20
      Me.grbBillRec.TabStop = False
      Me.grbBillRec.Text = "กำหนดเคลมเงินสดย่อย"
      '
      'btnBillRecDays
      '
      Me.btnBillRecDays.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBillRecDays.Image = CType(resources.GetObject("btnBillRecDays.Image"), System.Drawing.Image)
      Me.btnBillRecDays.Location = New System.Drawing.Point(216, 16)
      Me.btnBillRecDays.Name = "btnBillRecDays"
      Me.btnBillRecDays.Size = New System.Drawing.Size(24, 23)
      Me.btnBillRecDays.TabIndex = 2
      Me.btnBillRecDays.TabStop = False
      Me.btnBillRecDays.ThemedImage = CType(resources.GetObject("btnBillRecDays.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBillRecWeeks
      '
      Me.Validator.SetDataType(Me.txtBillRecWeeks, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillRecWeeks, "")
      Me.txtBillRecWeeks.Enabled = False
      Me.txtBillRecWeeks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillRecWeeks, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBillRecWeeks, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBillRecWeeks, System.Drawing.Color.Empty)
      Me.txtBillRecWeeks.Location = New System.Drawing.Point(72, 64)
      Me.Validator.SetMaxValue(Me.txtBillRecWeeks, "")
      Me.Validator.SetMinValue(Me.txtBillRecWeeks, "")
      Me.txtBillRecWeeks.Name = "txtBillRecWeeks"
      Me.txtBillRecWeeks.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBillRecWeeks, "")
      Me.Validator.SetRequired(Me.txtBillRecWeeks, False)
      Me.txtBillRecWeeks.Size = New System.Drawing.Size(144, 21)
      Me.txtBillRecWeeks.TabIndex = 25
      Me.txtBillRecWeeks.TabStop = False
      Me.txtBillRecWeeks.Text = ""
      '
      'txtBillRecDates
      '
      Me.Validator.SetDataType(Me.txtBillRecDates, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillRecDates, "")
      Me.txtBillRecDates.Enabled = False
      Me.txtBillRecDates.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillRecDates, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBillRecDates, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBillRecDates, System.Drawing.Color.Empty)
      Me.txtBillRecDates.Location = New System.Drawing.Point(72, 40)
      Me.Validator.SetMaxValue(Me.txtBillRecDates, "")
      Me.Validator.SetMinValue(Me.txtBillRecDates, "")
      Me.txtBillRecDates.Name = "txtBillRecDates"
      Me.txtBillRecDates.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBillRecDates, "")
      Me.Validator.SetRequired(Me.txtBillRecDates, False)
      Me.txtBillRecDates.Size = New System.Drawing.Size(144, 21)
      Me.txtBillRecDates.TabIndex = 24
      Me.txtBillRecDates.TabStop = False
      Me.txtBillRecDates.Text = ""
      '
      'lblBillRecWeek
      '
      Me.lblBillRecWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillRecWeek.ForeColor = System.Drawing.Color.Black
      Me.lblBillRecWeek.Location = New System.Drawing.Point(8, 64)
      Me.lblBillRecWeek.Name = "lblBillRecWeek"
      Me.lblBillRecWeek.Size = New System.Drawing.Size(56, 18)
      Me.lblBillRecWeek.TabIndex = 6
      Me.lblBillRecWeek.Text = "ทุกสัปดาห์"
      Me.lblBillRecWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBillRecDate
      '
      Me.lblBillRecDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillRecDate.ForeColor = System.Drawing.Color.Black
      Me.lblBillRecDate.Location = New System.Drawing.Point(8, 40)
      Me.lblBillRecDate.Name = "lblBillRecDate"
      Me.lblBillRecDate.Size = New System.Drawing.Size(56, 18)
      Me.lblBillRecDate.TabIndex = 3
      Me.lblBillRecDate.Text = "ทุกวันที่"
      Me.lblBillRecDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBillRecDay
      '
      Me.lblBillRecDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillRecDay.ForeColor = System.Drawing.Color.Black
      Me.lblBillRecDay.Location = New System.Drawing.Point(8, 16)
      Me.lblBillRecDay.Name = "lblBillRecDay"
      Me.lblBillRecDay.Size = New System.Drawing.Size(56, 18)
      Me.lblBillRecDay.TabIndex = 0
      Me.lblBillRecDay.Text = "ทุกวัน"
      Me.lblBillRecDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBillRecDays
      '
      Me.Validator.SetDataType(Me.txtBillRecDays, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillRecDays, "")
      Me.txtBillRecDays.Enabled = False
      Me.txtBillRecDays.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillRecDays, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBillRecDays, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBillRecDays, System.Drawing.Color.Empty)
      Me.txtBillRecDays.Location = New System.Drawing.Point(72, 16)
      Me.Validator.SetMaxValue(Me.txtBillRecDays, "")
      Me.Validator.SetMinValue(Me.txtBillRecDays, "")
      Me.txtBillRecDays.Name = "txtBillRecDays"
      Me.txtBillRecDays.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBillRecDays, "")
      Me.Validator.SetRequired(Me.txtBillRecDays, False)
      Me.txtBillRecDays.Size = New System.Drawing.Size(144, 21)
      Me.txtBillRecDays.TabIndex = 23
      Me.txtBillRecDays.TabStop = False
      Me.txtBillRecDays.Text = ""
      '
      'btnBillRecDates
      '
      Me.btnBillRecDates.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBillRecDates.Image = CType(resources.GetObject("btnBillRecDates.Image"), System.Drawing.Image)
      Me.btnBillRecDates.Location = New System.Drawing.Point(216, 40)
      Me.btnBillRecDates.Name = "btnBillRecDates"
      Me.btnBillRecDates.Size = New System.Drawing.Size(24, 23)
      Me.btnBillRecDates.TabIndex = 5
      Me.btnBillRecDates.TabStop = False
      Me.btnBillRecDates.ThemedImage = CType(resources.GetObject("btnBillRecDates.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnBillRecWeeks
      '
      Me.btnBillRecWeeks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBillRecWeeks.Image = CType(resources.GetObject("btnBillRecWeeks.Image"), System.Drawing.Image)
      Me.btnBillRecWeeks.Location = New System.Drawing.Point(216, 64)
      Me.btnBillRecWeeks.Name = "btnBillRecWeeks"
      Me.btnBillRecWeeks.Size = New System.Drawing.Size(24, 23)
      Me.btnBillRecWeeks.TabIndex = 8
      Me.btnBillRecWeeks.TabStop = False
      Me.btnBillRecWeeks.ThemedImage = CType(resources.GetObject("btnBillRecWeeks.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbLocation
      '
      Me.grbLocation.Controls.Add(Me.btnCCFind)
      Me.grbLocation.Controls.Add(Me.btnEmployeeFind)
      Me.grbLocation.Controls.Add(Me.txtCCCode)
      Me.grbLocation.Controls.Add(Me.rdIsEmployee)
      Me.grbLocation.Controls.Add(Me.btnEmployeeEdit)
      Me.grbLocation.Controls.Add(Me.txtEmployeeCode)
      Me.grbLocation.Controls.Add(Me.txtEmployeeName)
      Me.grbLocation.Controls.Add(Me.rdIsCC)
      Me.grbLocation.Controls.Add(Me.btnCCEdit)
      Me.grbLocation.Controls.Add(Me.txtCCName)
      Me.grbLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbLocation.Location = New System.Drawing.Point(16, 72)
      Me.grbLocation.Name = "grbLocation"
      Me.grbLocation.Size = New System.Drawing.Size(536, 72)
      Me.grbLocation.TabIndex = 8
      Me.grbLocation.TabStop = False
      Me.grbLocation.Text = "สังกัด"
      '
      'btnCCFind
      '
      Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCFind.Image = CType(resources.GetObject("btnCCFind.Image"), System.Drawing.Image)
      Me.btnCCFind.Location = New System.Drawing.Point(480, 40)
      Me.btnCCFind.Name = "btnCCFind"
      Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCCFind.TabIndex = 8
      Me.btnCCFind.TabStop = False
      Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnEmployeeFind
      '
      Me.btnEmployeeFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmployeeFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmployeeFind.Image = CType(resources.GetObject("btnEmployeeFind.Image"), System.Drawing.Image)
      Me.btnEmployeeFind.Location = New System.Drawing.Point(480, 16)
      Me.btnEmployeeFind.Name = "btnEmployeeFind"
      Me.btnEmployeeFind.Size = New System.Drawing.Size(24, 23)
      Me.btnEmployeeFind.TabIndex = 3
      Me.btnEmployeeFind.TabStop = False
      Me.btnEmployeeFind.ThemedImage = CType(resources.GetObject("btnEmployeeFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCode
      '
      Me.Validator.SetDataType(Me.txtCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCode, "")
      Me.txtCCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
      Me.txtCCCode.Location = New System.Drawing.Point(104, 40)
      Me.Validator.SetMaxValue(Me.txtCCCode, "")
      Me.Validator.SetMinValue(Me.txtCCCode, "")
      Me.txtCCCode.Name = "txtCCCode"
      Me.Validator.SetRegularExpression(Me.txtCCCode, "")
      Me.Validator.SetRequired(Me.txtCCCode, False)
      Me.txtCCCode.Size = New System.Drawing.Size(128, 21)
      Me.txtCCCode.TabIndex = 13
      Me.txtCCCode.Text = ""
      '
      'rdIsEmployee
      '
      Me.rdIsEmployee.Checked = True
      Me.rdIsEmployee.Location = New System.Drawing.Point(8, 16)
      Me.rdIsEmployee.Name = "rdIsEmployee"
      Me.rdIsEmployee.Size = New System.Drawing.Size(96, 24)
      Me.rdIsEmployee.TabIndex = 9
      Me.rdIsEmployee.TabStop = True
      Me.rdIsEmployee.Text = "พนักงาน:"
      '
      'btnEmployeeEdit
      '
      Me.btnEmployeeEdit.Image = CType(resources.GetObject("btnEmployeeEdit.Image"), System.Drawing.Image)
      Me.btnEmployeeEdit.Location = New System.Drawing.Point(504, 16)
      Me.btnEmployeeEdit.Name = "btnEmployeeEdit"
      Me.btnEmployeeEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnEmployeeEdit.TabIndex = 4
      Me.btnEmployeeEdit.TabStop = False
      Me.btnEmployeeEdit.ThemedImage = CType(resources.GetObject("btnEmployeeEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEmployeeCode
      '
      Me.Validator.SetDataType(Me.txtEmployeeCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmployeeCode, "")
      Me.txtEmployeeCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmployeeCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmployeeCode, System.Drawing.Color.Empty)
      Me.txtEmployeeCode.Location = New System.Drawing.Point(104, 16)
      Me.Validator.SetMaxValue(Me.txtEmployeeCode, "")
      Me.Validator.SetMinValue(Me.txtEmployeeCode, "")
      Me.txtEmployeeCode.Name = "txtEmployeeCode"
      Me.Validator.SetRegularExpression(Me.txtEmployeeCode, "")
      Me.Validator.SetRequired(Me.txtEmployeeCode, False)
      Me.txtEmployeeCode.Size = New System.Drawing.Size(128, 21)
      Me.txtEmployeeCode.TabIndex = 10
      Me.txtEmployeeCode.Text = ""
      '
      'txtEmployeeName
      '
      Me.Validator.SetDataType(Me.txtEmployeeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmployeeName, "")
      Me.txtEmployeeName.Enabled = False
      Me.txtEmployeeName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmployeeName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
      Me.txtEmployeeName.Location = New System.Drawing.Point(232, 16)
      Me.Validator.SetMaxValue(Me.txtEmployeeName, "")
      Me.Validator.SetMinValue(Me.txtEmployeeName, "")
      Me.txtEmployeeName.Name = "txtEmployeeName"
      Me.txtEmployeeName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEmployeeName, "")
      Me.Validator.SetRequired(Me.txtEmployeeName, False)
      Me.txtEmployeeName.Size = New System.Drawing.Size(248, 21)
      Me.txtEmployeeName.TabIndex = 11
      Me.txtEmployeeName.TabStop = False
      Me.txtEmployeeName.Text = ""
      '
      'rdIsCC
      '
      Me.rdIsCC.Location = New System.Drawing.Point(8, 40)
      Me.rdIsCC.Name = "rdIsCC"
      Me.rdIsCC.Size = New System.Drawing.Size(96, 24)
      Me.rdIsCC.TabIndex = 12
      Me.rdIsCC.Text = "Cost Center:"
      '
      'btnCCEdit
      '
      Me.btnCCEdit.Image = CType(resources.GetObject("btnCCEdit.Image"), System.Drawing.Image)
      Me.btnCCEdit.Location = New System.Drawing.Point(504, 40)
      Me.btnCCEdit.Name = "btnCCEdit"
      Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCCEdit.TabIndex = 9
      Me.btnCCEdit.TabStop = False
      Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCName
      '
      Me.Validator.SetDataType(Me.txtCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCName, "")
      Me.txtCCName.Enabled = False
      Me.txtCCName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCName, System.Drawing.Color.Empty)
      Me.txtCCName.Location = New System.Drawing.Point(232, 40)
      Me.Validator.SetMaxValue(Me.txtCCName, "")
      Me.Validator.SetMinValue(Me.txtCCName, "")
      Me.txtCCName.Name = "txtCCName"
      Me.txtCCName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCCName, "")
      Me.Validator.SetRequired(Me.txtCCName, False)
      Me.txtCCName.Size = New System.Drawing.Size(248, 21)
      Me.txtCCName.TabIndex = 14
      Me.txtCCName.TabStop = False
      Me.txtCCName.Text = ""
      '
      'txtAmount
      '
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(120, 152)
      Me.Validator.SetMaxValue(Me.txtAmount, "")
      Me.Validator.SetMinValue(Me.txtAmount, "0")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(128, 21)
      Me.txtAmount.TabIndex = 15
      Me.txtAmount.Text = ""
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(8, 152)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(104, 18)
      Me.lblAmount.TabIndex = 9
      Me.lblAmount.Text = "วงเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBaht
      '
      Me.lblBaht.AutoSize = True
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.ForeColor = System.Drawing.Color.Black
      Me.lblBaht.Location = New System.Drawing.Point(256, 152)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(25, 17)
      Me.lblBaht.TabIndex = 11
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbWithdraw
      '
      Me.grbWithdraw.Controls.Add(Me.txtlimit)
      Me.grbWithdraw.Controls.Add(Me.rdNotAllow)
      Me.grbWithdraw.Controls.Add(Me.rdLimited)
      Me.grbWithdraw.Controls.Add(Me.lblBaht1)
      Me.grbWithdraw.Controls.Add(Me.rdAllow)
      Me.grbWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbWithdraw.Location = New System.Drawing.Point(16, 232)
      Me.grbWithdraw.Name = "grbWithdraw"
      Me.grbWithdraw.Size = New System.Drawing.Size(280, 96)
      Me.grbWithdraw.TabIndex = 19
      Me.grbWithdraw.TabStop = False
      Me.grbWithdraw.Text = "เบิกเกินวงเงิน"
      '
      'txtlimit
      '
      Me.Validator.SetDataType(Me.txtlimit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtlimit, "")
      Me.txtlimit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtlimit, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtlimit, -15)
      Me.Validator.SetInvalidBackColor(Me.txtlimit, System.Drawing.Color.Empty)
      Me.txtlimit.Location = New System.Drawing.Point(104, 40)
      Me.Validator.SetMaxValue(Me.txtlimit, "")
      Me.Validator.SetMinValue(Me.txtlimit, "0")
      Me.txtlimit.Name = "txtlimit"
      Me.Validator.SetRegularExpression(Me.txtlimit, "")
      Me.Validator.SetRequired(Me.txtlimit, False)
      Me.txtlimit.Size = New System.Drawing.Size(128, 21)
      Me.txtlimit.TabIndex = 21
      Me.txtlimit.Text = ""
      Me.txtlimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'rdNotAllow
      '
      Me.rdNotAllow.Checked = True
      Me.rdNotAllow.Location = New System.Drawing.Point(8, 16)
      Me.rdNotAllow.Name = "rdNotAllow"
      Me.rdNotAllow.Size = New System.Drawing.Size(120, 24)
      Me.rdNotAllow.TabIndex = 19
      Me.rdNotAllow.TabStop = True
      Me.rdNotAllow.Text = "ไม่อนุญาติ"
      '
      'rdLimited
      '
      Me.rdLimited.Location = New System.Drawing.Point(8, 40)
      Me.rdLimited.Name = "rdLimited"
      Me.rdLimited.TabIndex = 20
      Me.rdLimited.Text = "อนุญาติให้ไม่เกิน"
      '
      'lblBaht1
      '
      Me.lblBaht1.AutoSize = True
      Me.lblBaht1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht1.ForeColor = System.Drawing.Color.Black
      Me.lblBaht1.Location = New System.Drawing.Point(240, 40)
      Me.lblBaht1.Name = "lblBaht1"
      Me.lblBaht1.Size = New System.Drawing.Size(25, 17)
      Me.lblBaht1.TabIndex = 3
      Me.lblBaht1.Text = "บาท"
      Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'rdAllow
      '
      Me.rdAllow.Location = New System.Drawing.Point(8, 64)
      Me.rdAllow.Name = "rdAllow"
      Me.rdAllow.Size = New System.Drawing.Size(144, 24)
      Me.rdAllow.TabIndex = 22
      Me.rdAllow.Text = "ไม่จำกัด"
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(120, 200)
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(424, 21)
      Me.txtNote.TabIndex = 18
      Me.txtNote.Text = ""
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(8, 200)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(104, 18)
      Me.lblNote.TabIndex = 17
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(312, 24)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(104, 18)
      Me.lblDocDate.TabIndex = 3
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'cmbCode
      '
      Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
      Me.cmbCode.Location = New System.Drawing.Point(120, 24)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(128, 21)
      Me.cmbCode.TabIndex = 208
      '
      'PettyCashDetail
      '
      Me.Controls.Add(Me.grbPettyCash)
      Me.Name = "PettyCashDetail"
      Me.Size = New System.Drawing.Size(584, 552)
      Me.grbPettyCash.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbBillRec.ResumeLayout(False)
      Me.grbLocation.ResumeLayout(False)
      Me.grbWithdraw.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Setlabeltext "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.lblName}")
      Me.Validator.SetDisplayName(txtName, lblName.Text)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.lblCode}")
      Me.Validator.SetDisplayName(cmbCode, lblCode.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.lblDocDate}")
      Me.Validator.SetDisplayName(txtdocdate, lblDocDate.Text)

      Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.lblAccount}")
      Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

      Me.lblBillRecWeek.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.lblBillRecWeek}")
      Me.Validator.SetDisplayName(txtBillRecWeeks, lblBillRecWeek.Text)

      Me.lblBillRecDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.lblBillRecDate}")
      Me.Validator.SetDisplayName(txtBillRecDates, lblBillRecDate.Text)

      Me.lblBillRecDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.lblBillRecDay}")
      Me.Validator.SetDisplayName(txtBillRecDays, lblBillRecDay.Text)

      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.lblAmount}")
      Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.lblNote}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.rdIsEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.rdIsEmployee}")

      Me.rdIsCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.rdIsCC}")

      Me.rdNotAllow.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.rdNotAllow}")

      Me.rdLimited.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.rdLimited}")

      Me.rdAllow.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.rdAllow}")

      Me.grbPettyCash.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.grbPettyCash}")
      Me.grbLocation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.grbLocation}")
      Me.grbWithdraw.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.grbWithdraw}")
      Me.grbBillRec.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.grbBillRec}")

      Me.Validator.SetDisplayName(txtEmployeeCode, rdIsEmployee.Text)
      Me.Validator.SetDisplayName(txtCCCode, rdIsCC.Text)
      Me.Validator.SetDisplayName(txtlimit, rdLimited.Text)
    End Sub
#End Region

#Region "Members"
    Private m_entity As PettyCash
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_combocodeindex As Integer
#End Region

#Region "Constructs"
    Public Sub New()
      MyBase.New()
      InitializeComponent()

      Initialize()

      Dim dt As TreeTable = PettyCash.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      EventWiring()
    End Sub
#End Region

#Region " Style "
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "PettyCash"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      ' Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "pc_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 25
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "pc_linenumber"

      Dim csDate As New TreeTextColumn
      csDate.MappingName = "Date"
      csDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.DateHeaderText}")
      csDate.NullText = ""
      csDate.Width = 50
      csDate.ReadOnly = True
      csDate.TextBox.Name = "Date"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Alignment = HorizontalAlignment.Right
      csAmount.TextBox.Name = "Amount"

      Dim csRemainingWithdraw As New TreeTextColumn
      csRemainingWithdraw.MappingName = "RemainingWithdraw"
      csRemainingWithdraw.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.RemainingWithdrawHeaderText}")
      csRemainingWithdraw.NullText = ""
      csRemainingWithdraw.ReadOnly = True
      csRemainingWithdraw.Format = "#,###.##"
      csRemainingWithdraw.DataAlignment = HorizontalAlignment.Right
      csRemainingWithdraw.Alignment = HorizontalAlignment.Right
      csRemainingWithdraw.TextBox.Name = "RemainingWithdraw"

      Dim csRemainingAmount As New TreeTextColumn
      csRemainingAmount.MappingName = "RemainingAmount"
      csRemainingAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.RemainingAmountHeaderText}")
      csRemainingAmount.NullText = ""
      csRemainingAmount.ReadOnly = True
      csRemainingAmount.Format = "#,###.##"
      csRemainingAmount.DataAlignment = HorizontalAlignment.Right
      csRemainingAmount.Alignment = HorizontalAlignment.Right
      csRemainingAmount.TextBox.Name = "RemainingAmount"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "pc_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "pc_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csRemainingWithdraw)
      dst.GridColumnStyles.Add(csRemainingAmount)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function
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

#Region "Methods"
    Private Function ConvertItemsToValueArray(ByVal list As String) As String
      Dim result As String = ""
      If list Is Nothing OrElse list.Length = 0 Then
        Return Nothing
      Else
        For Each item As String In list.Split(","c)
          result &= CStr(CInt(item) + 1) & ","
        Next
        If result.Length <> 0 Then
          result = result.TrimEnd(","c)
        End If
        Return result
      End If
    End Function
#End Region

#Region "IListDetail"
    Public Overrides Sub Initialize()

    End Sub
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Canceled _
      OrElse Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 _
      OrElse Me.m_entity.PettyCashPayment.Status.Value = 0 _
      OrElse Me.m_entity.PettyCashPayment.Status.Value >= 3 _
      Then
        For Each gui As Control In grbPettyCash.Controls
          gui.Enabled = False
          'If TypeOf gui Is TextBox Then
          '  gui.Enabled = False
          'ElseIf TypeOf gui Is FixedGroupBox Then
          '  gui.Enabled = False
          'Else
          '  gui.Enabled = True
          'End If
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each gui As Control In grbPettyCash.Controls
          gui.Enabled = True
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = False
        Next
        SetRequireEntity()
      End If
    End Sub
    Private Sub SetRequireEntity()
      ' Set Validator Require.
      If Me.m_entity.IsForEmployee Then
        Me.Validator.SetRequired(txtEmployeeCode, True)
        Me.Validator.SetRequired(txtCCCode, False)
        txtEmployeeCode.Enabled = True
        btnEmployeeFind.Enabled = True

        Me.ErrorProvider1.SetError(Me.txtCCCode, "")
        txtCCCode.Enabled = False
        btnCCFind.Enabled = False
      Else
        Me.Validator.SetRequired(txtCCCode, True)
        Me.Validator.SetRequired(txtEmployeeCode, False)
        txtCCCode.Enabled = True
        btnCCFind.Enabled = True

        Me.ErrorProvider1.SetError(Me.txtEmployeeCode, "")
        txtEmployeeCode.Enabled = False
        btnEmployeeFind.Enabled = False
      End If

      If Me.m_entity.LimitedOverBudget Then
        Me.Validator.SetRequired(txtlimit, True)
        txtlimit.Enabled = True
      Else
        Me.Validator.SetRequired(txtlimit, False)
        Me.ErrorProvider1.SetError(Me.txtlimit, "")
        txtlimit.Enabled = False
      End If

    End Sub

    Protected Overrides Sub EventWiring()

      AddHandler rdIsEmployee.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler rdIsCC.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler rdAllow.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler rdNotAllow.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler rdLimited.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtdocdate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtEmployeeCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCCCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAccountCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtlimit.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtAmount.Validated, AddressOf Me.NumericChanged
      AddHandler txtlimit.Validated, AddressOf Me.NumericChanged

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    Public Sub NumericChanged(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtamount"
          txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
        Case "txtlimit"
          txtlimit.Text = Configuration.FormatToString(Me.m_entity.LimitedOverBudgetAmount, DigitConfig.Price)
      End Select
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          Me.m_entity.Code = cmbCode.Text
          ComboCodeIndex = cmbCode.SelectedIndex
          m_oldCode = Me.cmbCode.Text
          dirtyFlag = True
        Case "txtname"
          dirtyFlag = True
          Me.m_entity.Name = txtName.Text

        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtdocdate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtdocdate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtdocdate) = "" Then
            Dim theDate As Date = CDate(Me.txtdocdate.Text)
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

        Case "txtemployeecode"
          dirtyFlag = Employee.GetEmployee(txtEmployeeCode, txtEmployeeName, Me.m_entity.Employee)
        Case "txtcccode"
          dirtyFlag = CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.m_entity.Costcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        Case "txtaccountcode"
          dirtyFlag = Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)

        Case "txtamount"
          dirtyFlag = True
          If txtAmount.TextLength > 0 AndAlso IsNumeric(txtAmount.Text) Then
            Me.m_entity.Amount = CDec(txtAmount.Text)
          Else
            Me.m_entity.Amount = Nothing
          End If

        Case "txtlimit"
          dirtyFlag = True
          If txtlimit.TextLength > 0 AndAlso IsNumeric(txtlimit.Text) Then
            Me.m_entity.LimitedOverBudgetAmount = CDec(txtlimit.Text)
          Else
            Me.m_entity.LimitedOverBudgetAmount = Nothing
          End If

        Case "txtnote"
          dirtyFlag = True
          Me.m_entity.Note = txtNote.Text

        Case "rdisemployee", "rdiscc"
          dirtyFlag = True
          If rdIsEmployee.Checked Then
            Me.m_entity.Costcenter = New CostCenter
            Me.m_entity.IsForEmployee = True
          Else
            Me.m_entity.Employee = New Employee
            Me.m_entity.IsForEmployee = False
          End If
          If Not Me.m_entity.Employee Is Nothing Then
            txtEmployeeCode.Text = Me.m_entity.Employee.Code
            txtEmployeeName.Text = Me.m_entity.Employee.Name
          End If
          If Not Me.m_entity.Costcenter Is Nothing Then
            txtCCCode.Text = Me.m_entity.Costcenter.Code
            txtCCName.Text = Me.m_entity.Costcenter.Name
          End If

        Case "rdallow", "rdnotallow", "rdLimited"
          dirtyFlag = True
          If rdLimited.Checked Then
            Me.m_entity.LimitedOverBudget = True
            Me.m_entity.AllowOverBudget = False
          Else
            Me.m_entity.LimitedOverBudgetAmount = Nothing
            txtlimit.Text = Configuration.FormatToString(Me.m_entity.LimitedOverBudgetAmount, DigitConfig.Price)
            Me.m_entity.LimitedOverBudget = False
            If rdAllow.Checked Then
              Me.m_entity.AllowOverBudget = True
            Else
              Me.m_entity.AllowOverBudget = False
            End If
          End If


      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      CheckFormEnable()
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      cmbCode.Items.Clear()
      cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_entity.Code
      BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
      m_oldCode = m_entity.Code
      txtName.Text = Me.m_entity.Name

      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtdocdate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      If Me.m_entity.IsForEmployee Then
        rdIsEmployee.Checked = True
      Else
        rdIsCC.Checked = True
      End If

      If Not Me.m_entity.Employee Is Nothing Then
        txtEmployeeCode.Text = Me.m_entity.Employee.Code
        txtEmployeeName.Text = Me.m_entity.Employee.Name
      End If
      If Not Me.m_entity.Costcenter Is Nothing Then
        txtCCCode.Text = Me.m_entity.Costcenter.Code
        txtCCName.Text = Me.m_entity.Costcenter.Name
      End If

      If Me.m_entity.LimitedOverBudget Then
        rdLimited.Checked = True
      Else
        If Me.m_entity.AllowOverBudget Then
          rdAllow.Checked = True
        Else
          rdNotAllow.Checked = True
        End If
      End If

      txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)

      If Not Me.m_entity.Account Is Nothing Then
        txtAccountCode.Text = Me.m_entity.Account.Code
        txtAccountName.Text = Me.m_entity.Account.Name
      End If

      txtNote.Text = Me.m_entity.Note

      txtlimit.Text = Configuration.FormatToString(Me.m_entity.LimitedOverBudgetAmount, DigitConfig.Price)

      ' กำหนดการวางบิล
      txtBillRecDays.Text = DateTimeService.GetDayStrings(Me.m_entity.ClaimRecDays, False)
      txtBillRecDates.Text = ConvertItemsToValueArray(Me.m_entity.ClaimRecDates)
      txtBillRecWeeks.Text = ConvertItemsToValueArray(Me.m_entity.ClaimRecWeeks)

      Me.m_entity.ReLoadItems()

      'Load Items**********************************************************
      Me.m_entity.GenPettyCashPayment()
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************
      UpdateAmount()

      SetStatus()
      SetLabelText()
      CheckFormEnable()

      m_isInitialized = True
    End Sub

    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbPettyCash.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        End If
      Next

      rdIsEmployee.Checked = True
      rdNotAllow.Checked = True

      dtpDocDate.Value = Date.Now
      txtdocdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, PettyCash)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Private Sub UpdateAmount()
      txtTotal.Text = Configuration.FormatToString(m_entity.GetRemainingAmount, DigitConfig.Price)
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
        'Me.txtCode.ReadOnly = True
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
        cmbCode.SelectedIndex = ComboCodeIndex
        m_oldCode = Me.cmbCode.Text
        'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        'Me.m_entity.Code = ""
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        ' Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_oldCode
        'Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
#End Region

#Region "Event of Button controls"
    ' Employee
    Private Sub btnEmployeeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub btnBankAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeDialog)
    End Sub
    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtEmployeeCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtEmployeeCode, txtEmployeeName, Me.m_entity.Employee)
    End Sub
    ' Costcenter
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostcenterDialog)
    End Sub
    Private Sub SetCostcenterDialog(ByVal e As ISimpleEntity)
      Me.txtCCCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.m_entity.Costcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    ' Account
    Private Sub btnAccountEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Account)
    End Sub
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountDialog)
    End Sub
    Private Sub SetAccountDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Employee).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtemployeecode", "txtemployeename"
                Return rdIsEmployee.Checked
            End Select
          End If
        End If
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcccode", "txtccname"
                Return rdIsCC.Checked
            End Select
          End If
        End If
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtaccountcode", "txtaccountname"
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
            Case "txtemployeecode", "txtemployeename"
              Me.SetEmployeeDialog(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcccode", "txtccname"
              Me.SetCostcenterDialog(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New Account).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        Dim entity As New Account(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtaccountcode", "txtaccountname"
              Me.SetAccountDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Days Dates Weeks"
    ' ทุกวัน
    Private Sub btnBillRecDays_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBillRecDays.Click
      Dim days As Object() = Me.DateTimeService.GetDays(False).ToArray
      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(days, Me.m_entity.ClaimRecDays)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtBillRecDays.Text = chkdlg.CheckedItemsString
        Me.m_entity.ClaimRecDays = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    ' ทุกวันที่
    Private Sub btnBillRecDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBillRecDates.Click
      Dim dates(30) As Object
      For i As Integer = 1 To 31
        dates(i - 1) = i
      Next
      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(dates, Me.m_entity.ClaimRecDates)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtBillRecDates.Text = chkdlg.CheckedItemsString
        Me.m_entity.ClaimRecDates = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    ' ทุกสัปดาห์ที่
    Private Sub btnBillRecWeeks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBillRecWeeks.Click
      Dim weeks(3) As Object
      For i As Integer = 1 To 4
        weeks(i - 1) = i
      Next
      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(weeks, Me.m_entity.ClaimRecWeeks)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtBillRecWeeks.Text = chkdlg.CheckedItemsString
        Me.m_entity.ClaimRecWeeks = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
#End Region

    Private Sub lblItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblItem.Click

    End Sub

    Protected Overrides Sub UpdateDefaultButton()

    End Sub
  End Class
End Namespace