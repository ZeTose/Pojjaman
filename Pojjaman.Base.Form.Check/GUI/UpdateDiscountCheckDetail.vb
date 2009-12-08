Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class UpdateDiscountCheckDetail
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
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblBankAccount As System.Windows.Forms.Label
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtBankAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblIssueDate As System.Windows.Forms.Label
        Friend WithEvents lblBankname As System.Windows.Forms.Label
        Friend WithEvents txtBankName As System.Windows.Forms.TextBox
        Friend WithEvents txtBankAcctName As System.Windows.Forms.TextBox
        Friend WithEvents txtIssuedate As System.Windows.Forms.TextBox
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnBankAcctEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnBankAcctFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtTotalAmnt As System.Windows.Forms.TextBox
        Friend WithEvents lblTotalamnt As System.Windows.Forms.Label
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents lblCurrency1 As System.Windows.Forms.Label
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents txtBankCharge As System.Windows.Forms.TextBox
        Friend WithEvents lblBankCharge As System.Windows.Forms.Label
        Friend WithEvents lblCurrency2 As System.Windows.Forms.Label
        Friend WithEvents txtWht As System.Windows.Forms.TextBox
        Friend WithEvents lblWht As System.Windows.Forms.Label
        Friend WithEvents lblCurrency3 As System.Windows.Forms.Label
        Friend WithEvents TxtSumTotal As System.Windows.Forms.TextBox
        Friend WithEvents lblSumTotal As System.Windows.Forms.Label
        Friend WithEvents lblCurrency5 As System.Windows.Forms.Label
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UpdateDiscountCheckDetail))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.txtIssuedate = New System.Windows.Forms.TextBox
            Me.txtBankAcctCode = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker
            Me.lblIssueDate = New System.Windows.Forms.Label
            Me.lblBankAccount = New System.Windows.Forms.Label
            Me.lblNote = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.btnBankAcctEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblBankname = New System.Windows.Forms.Label
            Me.txtBankName = New System.Windows.Forms.TextBox
            Me.btnBankAcctFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtBankAcctName = New System.Windows.Forms.TextBox
            Me.txtTotalAmnt = New System.Windows.Forms.TextBox
            Me.lblTotalamnt = New System.Windows.Forms.Label
            Me.lblCurrency1 = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtBankCharge = New System.Windows.Forms.TextBox
            Me.txtWht = New System.Windows.Forms.TextBox
            Me.TxtSumTotal = New System.Windows.Forms.TextBox
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblStatus = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.lblBankCharge = New System.Windows.Forms.Label
            Me.lblCurrency2 = New System.Windows.Forms.Label
            Me.lblWht = New System.Windows.Forms.Label
            Me.lblCurrency3 = New System.Windows.Forms.Label
            Me.lblSumTotal = New System.Windows.Forms.Label
            Me.lblCurrency5 = New System.Windows.Forms.Label
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.grbMaster.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Controls.Add(Me.chkAutorun)
            Me.grbMaster.Controls.Add(Me.txtIssuedate)
            Me.grbMaster.Controls.Add(Me.txtBankAcctCode)
            Me.grbMaster.Controls.Add(Me.txtCode)
            Me.grbMaster.Controls.Add(Me.lblCode)
            Me.grbMaster.Controls.Add(Me.dtpIssueDate)
            Me.grbMaster.Controls.Add(Me.lblIssueDate)
            Me.grbMaster.Controls.Add(Me.lblBankAccount)
            Me.grbMaster.Controls.Add(Me.lblNote)
            Me.grbMaster.Controls.Add(Me.txtNote)
            Me.grbMaster.Controls.Add(Me.btnBankAcctEdit)
            Me.grbMaster.Controls.Add(Me.lblBankname)
            Me.grbMaster.Controls.Add(Me.txtBankName)
            Me.grbMaster.Controls.Add(Me.btnBankAcctFind)
            Me.grbMaster.Controls.Add(Me.txtBankAcctName)
            Me.grbMaster.Controls.Add(Me.txtTotalAmnt)
            Me.grbMaster.Controls.Add(Me.lblTotalamnt)
            Me.grbMaster.Controls.Add(Me.lblCurrency1)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.ForeColor = System.Drawing.Color.Blue
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(712, 144)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "นำฝากเช็ค : "
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(280, 15)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 2
            Me.chkAutorun.TabStop = False
            '
            'txtIssuedate
            '
            Me.Validator.SetDataType(Me.txtIssuedate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtIssuedate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtIssuedate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtIssuedate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtIssuedate, System.Drawing.Color.Empty)
            Me.txtIssuedate.Location = New System.Drawing.Point(408, 15)
            Me.txtIssuedate.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtIssuedate, "")
            Me.Validator.SetMinValue(Me.txtIssuedate, "")
            Me.txtIssuedate.Name = "txtIssuedate"
            Me.Validator.SetRegularExpression(Me.txtIssuedate, "")
            Me.Validator.SetRequired(Me.txtIssuedate, True)
            Me.txtIssuedate.Size = New System.Drawing.Size(123, 21)
            Me.txtIssuedate.TabIndex = 4
            Me.txtIssuedate.Text = ""
            '
            'txtBankAcctCode
            '
            Me.Validator.SetDataType(Me.txtBankAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankAcctCode, "")
            Me.txtBankAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankAcctCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankAcctCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankAcctCode, System.Drawing.Color.Empty)
            Me.txtBankAcctCode.Location = New System.Drawing.Point(152, 39)
            Me.txtBankAcctCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtBankAcctCode, "")
            Me.Validator.SetMinValue(Me.txtBankAcctCode, "")
            Me.txtBankAcctCode.Name = "txtBankAcctCode"
            Me.Validator.SetRegularExpression(Me.txtBankAcctCode, "")
            Me.Validator.SetRequired(Me.txtBankAcctCode, True)
            Me.txtBankAcctCode.Size = New System.Drawing.Size(128, 21)
            Me.txtBankAcctCode.TabIndex = 7
            Me.txtBankAcctCode.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(152, 15)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(128, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 15)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(136, 18)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpIssueDate
            '
            Me.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpIssueDate.Location = New System.Drawing.Point(408, 15)
            Me.dtpIssueDate.Name = "dtpIssueDate"
            Me.dtpIssueDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpIssueDate.TabIndex = 5
            Me.dtpIssueDate.TabStop = False
            '
            'lblIssueDate
            '
            Me.lblIssueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblIssueDate.ForeColor = System.Drawing.Color.Black
            Me.lblIssueDate.Location = New System.Drawing.Point(304, 15)
            Me.lblIssueDate.Name = "lblIssueDate"
            Me.lblIssueDate.Size = New System.Drawing.Size(96, 18)
            Me.lblIssueDate.TabIndex = 3
            Me.lblIssueDate.Text = "วันที่เอกสาร:"
            Me.lblIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBankAccount
            '
            Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
            Me.lblBankAccount.Location = New System.Drawing.Point(8, 39)
            Me.lblBankAccount.Name = "lblBankAccount"
            Me.lblBankAccount.Size = New System.Drawing.Size(136, 18)
            Me.lblBankAccount.TabIndex = 6
            Me.lblBankAccount.Text = "สมุดเงินฝากธนาคาร:"
            Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 111)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(136, 18)
            Me.lblNote.TabIndex = 16
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
            Me.txtNote.Location = New System.Drawing.Point(152, 111)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(400, 24)
            Me.txtNote.TabIndex = 17
            Me.txtNote.Text = ""
            '
            'btnBankAcctEdit
            '
            Me.btnBankAcctEdit.Image = CType(resources.GetObject("btnBankAcctEdit.Image"), System.Drawing.Image)
            Me.btnBankAcctEdit.Location = New System.Drawing.Point(528, 39)
            Me.btnBankAcctEdit.Name = "btnBankAcctEdit"
            Me.btnBankAcctEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnBankAcctEdit.TabIndex = 10
            Me.btnBankAcctEdit.TabStop = False
            Me.btnBankAcctEdit.ThemedImage = CType(resources.GetObject("btnBankAcctEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblBankname
            '
            Me.lblBankname.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankname.ForeColor = System.Drawing.Color.Black
            Me.lblBankname.Location = New System.Drawing.Point(8, 63)
            Me.lblBankname.Name = "lblBankname"
            Me.lblBankname.Size = New System.Drawing.Size(136, 18)
            Me.lblBankname.TabIndex = 11
            Me.lblBankname.Text = "ธนาคาร/สาขา:"
            Me.lblBankname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBankName
            '
            Me.Validator.SetDataType(Me.txtBankName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankName, "")
            Me.txtBankName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankName, System.Drawing.Color.Empty)
            Me.txtBankName.Location = New System.Drawing.Point(152, 63)
            Me.Validator.SetMaxValue(Me.txtBankName, "")
            Me.Validator.SetMinValue(Me.txtBankName, "")
            Me.txtBankName.Name = "txtBankName"
            Me.txtBankName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankName, "")
            Me.Validator.SetRequired(Me.txtBankName, False)
            Me.txtBankName.Size = New System.Drawing.Size(400, 21)
            Me.txtBankName.TabIndex = 12
            Me.txtBankName.TabStop = False
            Me.txtBankName.Text = ""
            '
            'btnBankAcctFind
            '
            Me.btnBankAcctFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankAcctFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBankAcctFind.Image = CType(resources.GetObject("btnBankAcctFind.Image"), System.Drawing.Image)
            Me.btnBankAcctFind.Location = New System.Drawing.Point(504, 39)
            Me.btnBankAcctFind.Name = "btnBankAcctFind"
            Me.btnBankAcctFind.Size = New System.Drawing.Size(24, 23)
            Me.btnBankAcctFind.TabIndex = 9
            Me.btnBankAcctFind.TabStop = False
            Me.btnBankAcctFind.ThemedImage = CType(resources.GetObject("btnBankAcctFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtBankAcctName
            '
            Me.Validator.SetDataType(Me.txtBankAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankAcctName, "")
            Me.txtBankAcctName.Enabled = False
            Me.txtBankAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankAcctName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankAcctName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankAcctName, System.Drawing.Color.Empty)
            Me.txtBankAcctName.Location = New System.Drawing.Point(280, 39)
            Me.Validator.SetMaxValue(Me.txtBankAcctName, "")
            Me.Validator.SetMinValue(Me.txtBankAcctName, "")
            Me.txtBankAcctName.Name = "txtBankAcctName"
            Me.txtBankAcctName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankAcctName, "")
            Me.Validator.SetRequired(Me.txtBankAcctName, False)
            Me.txtBankAcctName.Size = New System.Drawing.Size(224, 21)
            Me.txtBankAcctName.TabIndex = 8
            Me.txtBankAcctName.TabStop = False
            Me.txtBankAcctName.Text = ""
            '
            'txtTotalAmnt
            '
            Me.Validator.SetDataType(Me.txtTotalAmnt, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtTotalAmnt, "")
            Me.txtTotalAmnt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalAmnt, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtTotalAmnt, -15)
            Me.Validator.SetInvalidBackColor(Me.txtTotalAmnt, System.Drawing.Color.Empty)
            Me.txtTotalAmnt.Location = New System.Drawing.Point(152, 87)
            Me.txtTotalAmnt.MaxLength = 13
            Me.Validator.SetMaxValue(Me.txtTotalAmnt, "")
            Me.Validator.SetMinValue(Me.txtTotalAmnt, "")
            Me.txtTotalAmnt.Name = "txtTotalAmnt"
            Me.Validator.SetRegularExpression(Me.txtTotalAmnt, "")
            Me.Validator.SetRequired(Me.txtTotalAmnt, True)
            Me.txtTotalAmnt.Size = New System.Drawing.Size(128, 21)
            Me.txtTotalAmnt.TabIndex = 14
            Me.txtTotalAmnt.Text = ""
            Me.txtTotalAmnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblTotalamnt
            '
            Me.lblTotalamnt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotalamnt.ForeColor = System.Drawing.Color.Black
            Me.lblTotalamnt.Location = New System.Drawing.Point(8, 87)
            Me.lblTotalamnt.Name = "lblTotalamnt"
            Me.lblTotalamnt.Size = New System.Drawing.Size(136, 18)
            Me.lblTotalamnt.TabIndex = 13
            Me.lblTotalamnt.Text = "จำนวนเงิน"
            Me.lblTotalamnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrency1
            '
            Me.lblCurrency1.AutoSize = True
            Me.lblCurrency1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency1.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency1.Location = New System.Drawing.Point(288, 87)
            Me.lblCurrency1.Name = "lblCurrency1"
            Me.lblCurrency1.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency1.TabIndex = 15
            Me.lblCurrency1.Text = "บาท"
            Me.lblCurrency1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            'txtBankCharge
            '
            Me.txtBankCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtBankCharge, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtBankCharge, "")
            Me.txtBankCharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankCharge, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankCharge, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankCharge, System.Drawing.Color.Empty)
            Me.txtBankCharge.Location = New System.Drawing.Point(560, 336)
            Me.txtBankCharge.MaxLength = 13
            Me.Validator.SetMaxValue(Me.txtBankCharge, "")
            Me.Validator.SetMinValue(Me.txtBankCharge, "")
            Me.txtBankCharge.Name = "txtBankCharge"
            Me.Validator.SetRegularExpression(Me.txtBankCharge, "")
            Me.Validator.SetRequired(Me.txtBankCharge, False)
            Me.txtBankCharge.Size = New System.Drawing.Size(112, 21)
            Me.txtBankCharge.TabIndex = 43
            Me.txtBankCharge.Text = ""
            Me.txtBankCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtWht
            '
            Me.txtWht.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtWht, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtWht, "")
            Me.txtWht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtWht, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtWht, -15)
            Me.Validator.SetInvalidBackColor(Me.txtWht, System.Drawing.Color.Empty)
            Me.txtWht.Location = New System.Drawing.Point(560, 360)
            Me.txtWht.MaxLength = 13
            Me.Validator.SetMaxValue(Me.txtWht, "")
            Me.Validator.SetMinValue(Me.txtWht, "")
            Me.txtWht.Name = "txtWht"
            Me.Validator.SetRegularExpression(Me.txtWht, "")
            Me.Validator.SetRequired(Me.txtWht, False)
            Me.txtWht.Size = New System.Drawing.Size(112, 21)
            Me.txtWht.TabIndex = 44
            Me.txtWht.Text = ""
            Me.txtWht.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'TxtSumTotal
            '
            Me.TxtSumTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.TxtSumTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.TxtSumTotal, "")
            Me.TxtSumTotal.Enabled = False
            Me.TxtSumTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.TxtSumTotal, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.TxtSumTotal, -15)
            Me.Validator.SetInvalidBackColor(Me.TxtSumTotal, System.Drawing.Color.Empty)
            Me.TxtSumTotal.Location = New System.Drawing.Point(560, 384)
            Me.TxtSumTotal.MaxLength = 13
            Me.Validator.SetMaxValue(Me.TxtSumTotal, "")
            Me.Validator.SetMinValue(Me.TxtSumTotal, "")
            Me.TxtSumTotal.Name = "TxtSumTotal"
            Me.TxtSumTotal.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.TxtSumTotal, "")
            Me.Validator.SetRequired(Me.TxtSumTotal, False)
            Me.TxtSumTotal.Size = New System.Drawing.Size(112, 21)
            Me.TxtSumTotal.TabIndex = 41
            Me.TxtSumTotal.TabStop = False
            Me.TxtSumTotal.Text = ""
            Me.TxtSumTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(208, 160)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 29
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(232, 160)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 30
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Black
            Me.lblStatus.Location = New System.Drawing.Point(304, 160)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 32
            Me.lblStatus.Text = "lblStatus"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.tgItem.Location = New System.Drawing.Point(8, 184)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(712, 144)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 28
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.AutoSize = True
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(24, 168)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(180, 19)
            Me.lblItem.TabIndex = 27
            Me.lblItem.Text = "รายการเช็คที่ต้องการนำฝาก:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBankCharge
            '
            Me.lblBankCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBankCharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankCharge.ForeColor = System.Drawing.Color.Black
            Me.lblBankCharge.Location = New System.Drawing.Point(408, 336)
            Me.lblBankCharge.Name = "lblBankCharge"
            Me.lblBankCharge.Size = New System.Drawing.Size(144, 18)
            Me.lblBankCharge.TabIndex = 36
            Me.lblBankCharge.Text = "ค่าธรรมเนียมธนาคาร"
            Me.lblBankCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrency2
            '
            Me.lblCurrency2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency2.AutoSize = True
            Me.lblCurrency2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency2.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency2.Location = New System.Drawing.Point(680, 336)
            Me.lblCurrency2.Name = "lblCurrency2"
            Me.lblCurrency2.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency2.TabIndex = 37
            Me.lblCurrency2.Text = "บาท"
            Me.lblCurrency2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWht
            '
            Me.lblWht.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblWht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblWht.ForeColor = System.Drawing.Color.Black
            Me.lblWht.Location = New System.Drawing.Point(408, 360)
            Me.lblWht.Name = "lblWht"
            Me.lblWht.Size = New System.Drawing.Size(144, 18)
            Me.lblWht.TabIndex = 38
            Me.lblWht.Text = "ภาษีหัก ญ ที่จ่าย"
            Me.lblWht.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrency3
            '
            Me.lblCurrency3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency3.AutoSize = True
            Me.lblCurrency3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency3.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency3.Location = New System.Drawing.Point(680, 360)
            Me.lblCurrency3.Name = "lblCurrency3"
            Me.lblCurrency3.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency3.TabIndex = 40
            Me.lblCurrency3.Text = "บาท"
            Me.lblCurrency3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSumTotal
            '
            Me.lblSumTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSumTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSumTotal.ForeColor = System.Drawing.Color.Black
            Me.lblSumTotal.Location = New System.Drawing.Point(408, 384)
            Me.lblSumTotal.Name = "lblSumTotal"
            Me.lblSumTotal.Size = New System.Drawing.Size(144, 18)
            Me.lblSumTotal.TabIndex = 39
            Me.lblSumTotal.Text = "จำนวนเงินรวม:"
            Me.lblSumTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrency5
            '
            Me.lblCurrency5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency5.AutoSize = True
            Me.lblCurrency5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency5.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency5.Location = New System.Drawing.Point(680, 384)
            Me.lblCurrency5.Name = "lblCurrency5"
            Me.lblCurrency5.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency5.TabIndex = 42
            Me.lblCurrency5.Text = "บาท"
            Me.lblCurrency5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'UpdateDiscountCheckDetail
            '
            Me.Controls.Add(Me.txtBankCharge)
            Me.Controls.Add(Me.lblBankCharge)
            Me.Controls.Add(Me.lblCurrency2)
            Me.Controls.Add(Me.txtWht)
            Me.Controls.Add(Me.lblWht)
            Me.Controls.Add(Me.lblCurrency3)
            Me.Controls.Add(Me.TxtSumTotal)
            Me.Controls.Add(Me.lblSumTotal)
            Me.Controls.Add(Me.lblCurrency5)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.grbMaster)
            Me.Name = "UpdateDiscountCheckDetail"
            Me.Size = New System.Drawing.Size(728, 416)
            Me.grbMaster.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblIssueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblIssueDate}")
            Me.Validator.SetDisplayName(txtIssuedate, lblIssueDate.Text)

            Me.lblBankname.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblBankname}")
            Me.lblBankAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblBankAccount}")
            Me.Validator.SetDisplayName(txtBankAcctCode, lblBankAccount.Text)

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblNote}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblItem}")

            'Me.lblSumCheck.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblSumCheck}")
            'Me.Validator.SetDisplayName(txtSumCheck, lblSumCheck.Text)

            'Me.lblSumCheckUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblSumUnit}")
            Me.lblSumTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblSumTotal}")
            Me.Validator.SetDisplayName(TxtSumTotal, lblSumTotal.Text)

            Me.lblBankCharge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblBankCharge}")
            Me.Validator.SetDisplayName(txtBankCharge, lblBankCharge.Text)

            
            Me.lblTotalamnt.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblTotalamnt}")
            Me.Validator.SetDisplayName(txtTotalAmnt, lblTotalamnt.Text)

            Me.lblWht.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblWht}")
            Me.Validator.SetDisplayName(txtWht, lblWht.Text)

            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.grbMaster}")
            'Me.grbSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.grbSum}")

            Me.lblCurrency1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency3.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency5.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

            Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
        End Sub
#End Region

#Region "Member"
        Private m_entity As UpdateCheckDiscount

        Private m_treeManager As TreeManager
        Private m_isInitialized As Boolean = False
        Private m_tableStyleEnable As Hashtable
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.Initialize()
            Me.SetLabelText()

            Dim dt As TreeTable = UpdateCheckDiscount.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            EventWiring()
        End Sub
#End Region

#Region " Style "
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "CheckUpdate"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            ' line number ...
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.Alignment = HorizontalAlignment.Center
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "linenumber"
            ' document code ...
            Dim csCode As New TreeTextColumn
            csCode.MappingName = "code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 70
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = False
            csCode.TextBox.Name = "code"
            ' Check Find button ...
            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf CheckButtonClick
            ' check docudate ...
            Dim csDocDate As New TreeTextColumn
            csDocDate.MappingName = "docdate"
            csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.DocDateHeaderText}")
            csDocDate.NullText = ""
            csDocDate.Width = 120
            csDocDate.Alignment = HorizontalAlignment.Center
            csDocDate.DataAlignment = HorizontalAlignment.Center
            csDocDate.ReadOnly = True
            csDocDate.TextBox.Name = "docdate"
            ' CqCode ...
            Dim csCqcode As New TreeTextColumn
            csCqcode.MappingName = "cqcode"
            csCqcode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CqCodeHeaderText}")
            csCqcode.NullText = ""
            csCqcode.Width = 100
            csCqcode.Alignment = HorizontalAlignment.Center
            csCqcode.DataAlignment = HorizontalAlignment.Left
            csCqcode.ReadOnly = True
            csCqcode.TextBox.Name = "cqcode"
            ' recievepient ...
            Dim csRecipient As New TreeTextColumn
            csRecipient.MappingName = "recipient"
            csRecipient.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.recipientHeaderText}")
            csRecipient.NullText = ""
            csRecipient.Alignment = HorizontalAlignment.Center
            csRecipient.DataAlignment = HorizontalAlignment.Left
            csRecipient.Width = 150
            csRecipient.ReadOnly = True
            csRecipient.TextBox.Name = "recipient"
            ' Bank account code ...
            Dim csBankacctCode As New TreeTextColumn
            csBankacctCode.MappingName = "bankacct_code"
            csBankacctCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankacctCodeCheckDetail.BankAcctcodeHeaderText}")
            csBankacctCode.NullText = ""
            csBankacctCode.Alignment = HorizontalAlignment.Center
            csBankacctCode.DataAlignment = HorizontalAlignment.Left
            csBankacctCode.Width = 100
            csBankacctCode.ReadOnly = True
            csBankacctCode.TextBox.Name = "bankacct_code"
            ' Bank account name ...
            Dim csBankacctName As New TreeTextColumn
            csBankacctName.MappingName = "bankacct_name"
            csBankacctName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankacctNameHeaderText}")
            csBankacctName.NullText = ""
            csBankacctName.Alignment = HorizontalAlignment.Center
            csBankacctName.DataAlignment = HorizontalAlignment.Left
            csBankacctName.Width = 120
            csBankacctName.ReadOnly = True
            csBankacctName.TextBox.Name = "bankacct_name"
            ' Bank name ...
            Dim csBankName As New TreeTextColumn
            csBankName.MappingName = "bank_name"
            csBankName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankNameHeaderText}")
            csBankName.NullText = ""
            csBankName.Alignment = HorizontalAlignment.Center
            csBankName.DataAlignment = HorizontalAlignment.Left
            csBankName.Width = 150
            csBankName.ReadOnly = True
            csBankName.TextBox.Name = "bank_name"
            ' Check amount ...
            Dim csCheckAmnt As New TreeTextColumn
            csCheckAmnt.MappingName = "check_amount"
            csCheckAmnt.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CheckAmountHeaderText}")
            csCheckAmnt.NullText = ""
            csCheckAmnt.Width = 80
            csCheckAmnt.Alignment = HorizontalAlignment.Center
            csCheckAmnt.DataAlignment = HorizontalAlignment.Right
            csCheckAmnt.ReadOnly = True
            csCheckAmnt.Format = "#,##0.00"
            csCheckAmnt.TextBox.Name = "check_amount"

            ' Add column style ...
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csCqcode)
            dst.GridColumnStyles.Add(csDocDate)
            dst.GridColumnStyles.Add(csRecipient)
            'dst.GridColumnStyles.Add(csBankacctCode)
            'dst.GridColumnStyles.Add(csBankacctName)
            dst.GridColumnStyles.Add(csBankName)
            dst.GridColumnStyles.Add(csCheckAmnt)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next

            Return dst
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
            OrElse Me.m_entity.Status.Value >= 3 Then
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = False
                Next
                ' DataGrid Configuration
                tgItem.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next
            Else
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = True
                Next
                
                ' DataGrid Configuration
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next
            End If
        End Sub
        Public Overrides Sub ClearDetail()
            lblStatus.Text = ""
            For Each grb As Control In Me.Controls
                If TypeOf grb Is FixedGroupBox Then
                    For Each crlt As Control In grb.Controls
                        If TypeOf crlt Is TextBox Then
                            crlt.Text = ""
                        End If
                    Next
                ElseIf TypeOf grb Is TextBox Then
                    grb.Text = ""
                End If
            Next

            Me.dtpIssueDate.Value = Now

        End Sub

        Protected Overrides Sub EventWiring()

            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtIssuedate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpIssueDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtBankAcctCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtWht.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtTotalAmnt.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtBankCharge.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtWht.Validated, AddressOf Me.NumberTextBoxChange
            AddHandler txtTotalAmnt.Validated, AddressOf Me.NumberTextBoxChange
            AddHandler txtBankCharge.Validated, AddressOf Me.NumberTextBoxChange

        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            txtCode.Text = m_entity.Code
            txtNote.Text = m_entity.Note

            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtIssuedate.Text = MinDateToNull(Me.m_entity.IssueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpIssueDate.Value = MinDateToNow(Me.m_entity.IssueDate)

            txtTotalAmnt.Text = Configuration.FormatToString(Me.m_entity.TotalAmount, DigitConfig.Price)
            txtWht.Text = Configuration.FormatToString(Me.m_entity.WHT, DigitConfig.Price)
            txtBankCharge.Text = Configuration.FormatToString(Me.m_entity.BankCharge, DigitConfig.Price)

            If Not Me.m_entity.BankAccount Is Nothing Then
                txtBankAcctCode.Text = Me.m_entity.BankAccount.Code
                txtBankAcctName.Text = Me.m_entity.BankAccount.Name
                SetBankBranchName()
            End If
            'Load Items**********************************************************
            Me.m_treeManager.Treetable = Me.m_entity.ItemTable
            AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
            Me.Validator.DataTable = m_treeManager.Treetable
            '********************************************************************
            RefreshBlankGrid()

            SetStatus()
            SetSummaryText()
            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True
        End Sub

        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If e.Name = "ItemChanged" Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
            SetSummaryText()
        End Sub

        Private m_dateSetting As Boolean = False
        Public Sub NumberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txttotalamnt"
                    txtTotalAmnt.Text = Configuration.FormatToString(Me.m_entity.TotalAmount, DigitConfig.Price)
                Case "txtsumcheck"
                    '
                Case "txtsumtotal"
                    TxtSumTotal.Text = Configuration.FormatToString(Me.m_entity.TotalAmount, DigitConfig.Price)
                Case "txtwht"
                    txtWht.Text = Configuration.FormatToString(Me.m_entity.WHT, DigitConfig.Price)
                Case "txtbankcharge"
                    txtBankCharge.Text = Configuration.FormatToString(Me.m_entity.BankCharge, DigitConfig.Price)

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
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True

                Case "dtpissuedate"
                    txtIssuedate.Text = MinDateToNull(dtpIssueDate.Value, "")
                    Me.m_entity.IssueDate = dtpIssueDate.Value
                    dirtyFlag = True
                Case "txtissuedate"
                    Dim dt As Date = StringToDate(txtIssuedate, dtpIssueDate)
                    Me.m_entity.IssueDate = dt
                    dirtyFlag = True

                Case "cmbstatus"
                    Me.m_entity.ItemTable.Clear()
                    RefreshBlankGrid()

                    dirtyFlag = True

                Case "cmbchecktype"
                    'registerentitybase()
                    dirtyFlag = True

                Case "txtbankacctcode"
                    dirtyFlag = BankAccount.GetBankAccount(txtBankAcctCode, txtBankAcctName, Me.m_entity.BankAccount)
                    SetBankBranchName()

                Case "txttotalamnt"
                    dirtyFlag = True
                    If txtTotalAmnt.TextLength > 0 Then
                        Me.m_entity.TotalAmount = CDec(txtTotalAmnt.Text)
                    Else
                        Me.m_entity.TotalAmount = Nothing
                    End If

                Case "txtwht"
                    dirtyFlag = True
                    If txtWht.TextLength > 0 Then
                        Me.m_entity.WHT = CDec(txtWht.Text)
                    Else
                        Me.m_entity.WHT = Nothing
                    End If

                Case "txtbankcharge"
                    dirtyFlag = True
                    If txtBankCharge.TextLength > 0 Then
                        Me.m_entity.BankCharge = CDec(txtBankCharge.Text)
                    Else
                        Me.m_entity.BankCharge = Nothing
                    End If

            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

            CheckFormEnable()
            SetStatus()

        End Sub
        Public Sub SetStatus()
            If m_entity.Canceled Then
                lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
                " " & m_entity.CancelDate.ToShortTimeString & _
                "  โดย:" & m_entity.CancelPerson.Name
            ElseIf m_entity.Edited Then
                lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
                " " & m_entity.LastEditDate.ToShortTimeString & _
                "  โดย:" & m_entity.LastEditor.Name
            ElseIf m_entity.Originated Then
                lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
                " " & m_entity.OriginDate.ToShortTimeString & _
                "  โดย:" & m_entity.Originator.Name
            Else
                lblStatus.Text = "ยังไม่ได้บันทึก"
            End If
        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not Me.m_entity Is Nothing Then
                    RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, UpdateCheckDiscount)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

#End Region

#Region "Event Handlers"
        Public Sub CheckButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entities As New ArrayList
            Dim obj As New IncomingCheck

            obj.DocStatus = New IncomingCheckDocStatus(1)  ' แสดง เช็คในมือ เท่านั้น ...
            entities.Add(obj)

            Dim filters(1) As Filter
            filters(0) = New Filter("IDList", GenIDListFromDataTable())
            filters(1) = New Filter("cqupdate_id", Me.m_entity.Id)

            myEntityPanelService.OpenListDialog(New IncomingCheck, AddressOf SetCheckItems, filters, entities)
        End Sub
        Private Function GenIDListFromDataTable() As String
            Dim idlist As String = ""
            For Each row As TreeRow In Me.m_entity.ItemTable.Rows
                If Not IsDBNull(row("cqupdatei_entity")) Then
                    idlist &= CStr(row("cqupdatei_entity")) & ","
                End If
            Next
            Return idlist
        End Function

        Private Sub SetEntityValue(ByVal check As ISimpleEntity)
            Me.m_treeManager.SelectedRow("Code") = check.Code
            SetSummaryText()
        End Sub
        Private Sub SetCheckItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex

            For i As Integer = items.Count - 1 To 0 Step -1
                Dim newItem As New IncomingCheck(CType(items(i), BasketItem).Id)

                Dim cqtype As New CheckType(newItem.EntityId)

                Dim mtwItem As New UpdateCheckDiscountItem

                mtwItem.Entity = newItem

                Me.m_entity.ItemTable.AcceptChanges()

                If i = items.Count - 1 Then
                    If Me.m_entity.ItemTable.Childs.Count = 0 Then
                        Me.m_entity.Add(mtwItem)
                    Else
                        mtwItem.LineNumber = CInt(Me.m_entity.ItemTable.Childs(index)("linenumber"))
                        mtwItem.UpdateCheckDiscount = Me.m_entity
                        mtwItem.CopyToDataRow(Me.m_entity.ItemTable.Childs(index))
                    End If
                Else
                    Me.m_entity.Insert(index, mtwItem)
                End If
                Me.m_entity.ItemTable.AcceptChanges()
            Next
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
            ' Summary ...
            SetSummaryText()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub

        Private Sub PRPanelView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
            AddHandler Me.WorkbenchWindow.ViewContent.Saved, AddressOf EntitySaved
        End Sub
        Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

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
                Return (New UpdateCheckDiscount).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Rows Manager Button"
        ' Add Item ...
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim newItem As New BlankItem("")
            Dim checkItem As New UpdateCheckDiscountItem

            'checkItem.Entity = CType(newItem, ISimpleEntity)

            Me.m_entity.Insert(index, checkItem)
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        ' Delete Item ...
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Me.m_entity.Remove(index)
            Me.tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
#End Region

#Region "Grid Resizing"
        Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
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
            Dim maxVisibleCount As Integer
            Dim tgRowHeight As Integer = 17
            maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
            Do While Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1
                'เพิ่มแถวจนเต็ม
                Me.m_entity.AddBlankRow(1)
            Loop
            If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
                If Me.m_entity.ItemTable.Childs.Count < maxVisibleCount - 1 Then
                    'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                    Me.m_entity.AddBlankRow(1)
                End If
            End If
            'Do While Me.m_entity.ItemTable.Childs.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Childs.Count - 2 <> Me.m_entity.MaxRowIndex
            '    'ลบแถวที่ไม่จำเป็น
            '    MessageBox.Show(Me.m_entity.ItemTable.Childs.Count.ToString & ":" & maxVisibleCount.ToString & ":" & Me.m_entity.MaxRowIndex.ToString)
            '    Me.m_entity.Remove(Me.m_entity.ItemTable.Childs.Count - 1)
            'Loop
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

#Region "Private Methods"
        Private Sub SetSummaryText()
            TxtSumTotal.Text = Configuration.FormatToString(Me.m_entity.TotalItemTableAmount, DigitConfig.Price)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New BankAccount).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtbankacctcode", "txtbankacctname"
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
                        Case "txtbankacctcode", "txtbankacctname"
                            Me.SetBankAccountDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region "Event of button controls"
        ' Bank Account 
        Private Sub btnBankAcctEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAcctEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New BankAccount)
        End Sub
        Private Sub btnBankAcctFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAcctFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountDialog)
        End Sub
        Private Sub SetBankAccountDialog(ByVal e As ISimpleEntity)
            Me.txtBankAcctCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or BankAccount.GetBankAccount(txtBankAcctCode, txtBankAcctName, Me.m_entity.BankAccount)
            SetBankBranchName()
        End Sub
        Private Sub SetBankBranchName()
            Dim oldstatus As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            If Not Me.m_entity.BankAccount Is Nothing AndAlso Me.m_entity.BankAccount.Originated Then
                txtBankName.Text = Me.m_entity.BankAccount.BankBranch.Bank.Name & " / " & _
                                    Me.m_entity.BankAccount.BankBranch.Name
            Else
                txtBankName.Text = ""
            End If
            Me.m_isInitialized = oldstatus
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
