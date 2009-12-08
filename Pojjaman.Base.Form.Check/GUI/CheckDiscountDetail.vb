Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CheckDiscountDetail
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
        Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblBankAccount As System.Windows.Forms.Label
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblBank As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents ImageButton2 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblItem1 As System.Windows.Forms.Label
        Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnBank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtBankAccountCode As System.Windows.Forms.TextBox
        Friend WithEvents txtBankBranch As System.Windows.Forms.TextBox
        Friend WithEvents lblTotalamnt As System.Windows.Forms.Label
        Friend WithEvents txtTotalamnt As System.Windows.Forms.TextBox
        Friend WithEvents txtTotalamntUnit As System.Windows.Forms.Label
        Friend WithEvents lblIssuedate As System.Windows.Forms.Label
        Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
        Friend WithEvents txtIssuedate As System.Windows.Forms.TextBox
        Friend WithEvents TreeGrid1 As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents grpSum As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtSumCheck As System.Windows.Forms.TextBox
        Friend WithEvents TxtSumTotal As System.Windows.Forms.TextBox
        Friend WithEvents lblSumCheck As System.Windows.Forms.Label
        Friend WithEvents lblSumTotal As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents lblBaht As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CheckDiscountDetail))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblItem1 = New System.Windows.Forms.Label
            Me.btnBank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton2 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtBankAccountCode = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker
            Me.lblBankAccount = New System.Windows.Forms.Label
            Me.lblNote = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblBank = New System.Windows.Forms.Label
            Me.txtBankBranch = New System.Windows.Forms.TextBox
            Me.lblTotalamnt = New System.Windows.Forms.Label
            Me.txtTotalamnt = New System.Windows.Forms.TextBox
            Me.txtTotalamntUnit = New System.Windows.Forms.Label
            Me.lblIssuedate = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtBankAccountName = New System.Windows.Forms.TextBox
            Me.TextBox4 = New System.Windows.Forms.TextBox
            Me.txtIssuedate = New System.Windows.Forms.TextBox
            Me.TreeGrid1 = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grpSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtSumCheck = New System.Windows.Forms.TextBox
            Me.TxtSumTotal = New System.Windows.Forms.TextBox
            Me.lblSumCheck = New System.Windows.Forms.Label
            Me.lblSumTotal = New System.Windows.Forms.Label
            Me.lblItem = New System.Windows.Forms.Label
            Me.lblBaht = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.TextBox2 = New System.Windows.Forms.TextBox
            Me.Label4 = New System.Windows.Forms.Label
            Me.lblStatus = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbMaster.SuspendLayout()
            CType(Me.TreeGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpSum.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.lblStatus)
            Me.grbMaster.Controls.Add(Me.grpSum)
            Me.grbMaster.Controls.Add(Me.TreeGrid1)
            Me.grbMaster.Controls.Add(Me.TextBox4)
            Me.grbMaster.Controls.Add(Me.lblItem1)
            Me.grbMaster.Controls.Add(Me.btnBank)
            Me.grbMaster.Controls.Add(Me.ImageButton2)
            Me.grbMaster.Controls.Add(Me.txtBankAccountCode)
            Me.grbMaster.Controls.Add(Me.txtCode)
            Me.grbMaster.Controls.Add(Me.lblCode)
            Me.grbMaster.Controls.Add(Me.lblBankAccount)
            Me.grbMaster.Controls.Add(Me.lblNote)
            Me.grbMaster.Controls.Add(Me.txtNote)
            Me.grbMaster.Controls.Add(Me.lblBank)
            Me.grbMaster.Controls.Add(Me.txtBankBranch)
            Me.grbMaster.Controls.Add(Me.lblTotalamnt)
            Me.grbMaster.Controls.Add(Me.txtTotalamnt)
            Me.grbMaster.Controls.Add(Me.txtTotalamntUnit)
            Me.grbMaster.Controls.Add(Me.lblIssuedate)
            Me.grbMaster.Controls.Add(Me.txtBankAccountName)
            Me.grbMaster.Controls.Add(Me.txtIssuedate)
            Me.grbMaster.Controls.Add(Me.dtpIssueDate)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.ForeColor = System.Drawing.Color.Blue
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(760, 370)
            Me.grbMaster.TabIndex = 3
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ขายลดเช็ค : "
            '
            'lblItem1
            '
            Me.lblItem1.AutoSize = True
            Me.lblItem1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem1.ForeColor = System.Drawing.Color.Black
            Me.lblItem1.Location = New System.Drawing.Point(8, 152)
            Me.lblItem1.Name = "lblItem1"
            Me.lblItem1.Size = New System.Drawing.Size(153, 19)
            Me.lblItem1.TabIndex = 216
            Me.lblItem1.Text = "รายการเช็คที่ต้องขายลด"
            Me.lblItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnBank
            '
            Me.btnBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBank.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBank.Image = CType(resources.GetObject("btnBank.Image"), System.Drawing.Image)
            Me.btnBank.Location = New System.Drawing.Point(536, 48)
            Me.btnBank.Name = "btnBank"
            Me.btnBank.Size = New System.Drawing.Size(24, 23)
            Me.btnBank.TabIndex = 215
            Me.btnBank.TabStop = False
            Me.btnBank.ThemedImage = CType(resources.GetObject("btnBank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton2
            '
            Me.ImageButton2.Image = CType(resources.GetObject("ImageButton2.Image"), System.Drawing.Image)
            Me.ImageButton2.Location = New System.Drawing.Point(560, 48)
            Me.ImageButton2.Name = "ImageButton2"
            Me.ImageButton2.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton2.TabIndex = 214
            Me.ImageButton2.ThemedImage = CType(resources.GetObject("ImageButton2.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtBankAccountCode
            '
            Me.Validator.SetDataType(Me.txtBankAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankAccountCode, "")
            Me.txtBankAccountCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
            Me.txtBankAccountCode.Location = New System.Drawing.Point(144, 48)
            Me.Validator.SetMaxValue(Me.txtBankAccountCode, "")
            Me.Validator.SetMinValue(Me.txtBankAccountCode, "")
            Me.txtBankAccountCode.Name = "txtBankAccountCode"
            Me.Validator.SetRegularExpression(Me.txtBankAccountCode, "")
            Me.Validator.SetRequired(Me.txtBankAccountCode, False)
            Me.txtBankAccountCode.Size = New System.Drawing.Size(144, 22)
            Me.txtBankAccountCode.TabIndex = 188
            Me.txtBankAccountCode.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(144, 24)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(144, 22)
            Me.txtCode.TabIndex = 187
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(128, 18)
            Me.lblCode.TabIndex = 186
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpIssueDate
            '
            Me.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpIssueDate.Location = New System.Drawing.Point(440, 24)
            Me.dtpIssueDate.Name = "dtpIssueDate"
            Me.dtpIssueDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpIssueDate.TabIndex = 13
            '
            'lblBankAccount
            '
            Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
            Me.lblBankAccount.Location = New System.Drawing.Point(8, 48)
            Me.lblBankAccount.Name = "lblBankAccount"
            Me.lblBankAccount.Size = New System.Drawing.Size(128, 18)
            Me.lblBankAccount.TabIndex = 11
            Me.lblBankAccount.Text = "สมุดเงินฝากธนาคาร:"
            Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 120)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(128, 18)
            Me.lblNote.TabIndex = 11
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(144, 120)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(440, 24)
            Me.txtNote.TabIndex = 10
            Me.txtNote.Text = ""
            '
            'lblBank
            '
            Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBank.ForeColor = System.Drawing.Color.Black
            Me.lblBank.Location = New System.Drawing.Point(8, 72)
            Me.lblBank.Name = "lblBank"
            Me.lblBank.Size = New System.Drawing.Size(128, 18)
            Me.lblBank.TabIndex = 11
            Me.lblBank.Text = "ธนาคาร/สาขา:"
            Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBankBranch
            '
            Me.Validator.SetDataType(Me.txtBankBranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankBranch, "")
            Me.txtBankBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBankBranch, System.Drawing.Color.Empty)
            Me.txtBankBranch.Location = New System.Drawing.Point(144, 72)
            Me.Validator.SetMaxValue(Me.txtBankBranch, "")
            Me.Validator.SetMinValue(Me.txtBankBranch, "")
            Me.txtBankBranch.Name = "txtBankBranch"
            Me.txtBankBranch.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankBranch, "")
            Me.Validator.SetRequired(Me.txtBankBranch, False)
            Me.txtBankBranch.Size = New System.Drawing.Size(440, 22)
            Me.txtBankBranch.TabIndex = 10
            Me.txtBankBranch.Text = ""
            '
            'lblTotalamnt
            '
            Me.lblTotalamnt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotalamnt.ForeColor = System.Drawing.Color.Black
            Me.lblTotalamnt.Location = New System.Drawing.Point(8, 96)
            Me.lblTotalamnt.Name = "lblTotalamnt"
            Me.lblTotalamnt.Size = New System.Drawing.Size(128, 18)
            Me.lblTotalamnt.TabIndex = 11
            Me.lblTotalamnt.Text = "ยอดเงินฝากธนาคาร:"
            Me.lblTotalamnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTotalamnt
            '
            Me.Validator.SetDataType(Me.txtTotalamnt, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalamnt, "")
            Me.txtTotalamnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalamnt, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalamnt, System.Drawing.Color.Empty)
            Me.txtTotalamnt.Location = New System.Drawing.Point(144, 96)
            Me.Validator.SetMaxValue(Me.txtTotalamnt, "")
            Me.Validator.SetMinValue(Me.txtTotalamnt, "")
            Me.txtTotalamnt.Name = "txtTotalamnt"
            Me.Validator.SetRegularExpression(Me.txtTotalamnt, "")
            Me.Validator.SetRequired(Me.txtTotalamnt, False)
            Me.txtTotalamnt.Size = New System.Drawing.Size(144, 22)
            Me.txtTotalamnt.TabIndex = 188
            Me.txtTotalamnt.Text = ""
            '
            'txtTotalamntUnit
            '
            Me.txtTotalamntUnit.AutoSize = True
            Me.txtTotalamntUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtTotalamntUnit.ForeColor = System.Drawing.Color.Black
            Me.txtTotalamntUnit.Location = New System.Drawing.Point(296, 96)
            Me.txtTotalamntUnit.Name = "txtTotalamntUnit"
            Me.txtTotalamntUnit.Size = New System.Drawing.Size(25, 17)
            Me.txtTotalamntUnit.TabIndex = 186
            Me.txtTotalamntUnit.Text = "บาท"
            Me.txtTotalamntUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblIssuedate
            '
            Me.lblIssuedate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblIssuedate.ForeColor = System.Drawing.Color.Black
            Me.lblIssuedate.Location = New System.Drawing.Point(328, 24)
            Me.lblIssuedate.Name = "lblIssuedate"
            Me.lblIssuedate.Size = New System.Drawing.Size(104, 18)
            Me.lblIssuedate.TabIndex = 186
            Me.lblIssuedate.Text = "เลขที่เอกสาร:"
            Me.lblIssuedate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Nothing
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'txtBankAccountName
            '
            Me.Validator.SetDataType(Me.txtBankAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankAccountName, "")
            Me.txtBankAccountName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
            Me.txtBankAccountName.Location = New System.Drawing.Point(288, 48)
            Me.Validator.SetMaxValue(Me.txtBankAccountName, "")
            Me.Validator.SetMinValue(Me.txtBankAccountName, "")
            Me.txtBankAccountName.Name = "txtBankAccountName"
            Me.Validator.SetRegularExpression(Me.txtBankAccountName, "")
            Me.Validator.SetRequired(Me.txtBankAccountName, False)
            Me.txtBankAccountName.Size = New System.Drawing.Size(248, 22)
            Me.txtBankAccountName.TabIndex = 188
            Me.txtBankAccountName.Text = ""
            '
            'TextBox4
            '
            Me.Validator.SetDataType(Me.TextBox4, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.TextBox4, "")
            Me.Validator.SetGotFocusBackColor(Me.TextBox4, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.TextBox4, System.Drawing.Color.Empty)
            Me.TextBox4.Location = New System.Drawing.Point(896, 48)
            Me.Validator.SetMaxValue(Me.TextBox4, "")
            Me.Validator.SetMinValue(Me.TextBox4, "")
            Me.TextBox4.Name = "TextBox4"
            Me.Validator.SetRegularExpression(Me.TextBox4, "")
            Me.Validator.SetRequired(Me.TextBox4, False)
            Me.TextBox4.TabIndex = 217
            Me.TextBox4.Text = "TextBox4"
            '
            'txtIssuedate
            '
            Me.Validator.SetDataType(Me.txtIssuedate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtIssuedate, "")
            Me.txtIssuedate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtIssuedate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtIssuedate, System.Drawing.Color.Empty)
            Me.txtIssuedate.Location = New System.Drawing.Point(440, 24)
            Me.Validator.SetMaxValue(Me.txtIssuedate, "")
            Me.Validator.SetMinValue(Me.txtIssuedate, "")
            Me.txtIssuedate.Name = "txtIssuedate"
            Me.Validator.SetRegularExpression(Me.txtIssuedate, "")
            Me.Validator.SetRequired(Me.txtIssuedate, False)
            Me.txtIssuedate.Size = New System.Drawing.Size(122, 22)
            Me.txtIssuedate.TabIndex = 187
            Me.txtIssuedate.Text = ""
            '
            'TreeGrid1
            '
            Me.TreeGrid1.AllowNew = True
            Me.TreeGrid1.AllowSorting = False
            Me.TreeGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TreeGrid1.AutoColumnResize = True
            Me.TreeGrid1.CaptionVisible = False
            Me.TreeGrid1.Cellchanged = False
            Me.TreeGrid1.DataMember = ""
            Me.TreeGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.TreeGrid1.Location = New System.Drawing.Point(8, 176)
            Me.TreeGrid1.Name = "TreeGrid1"
            Me.TreeGrid1.Size = New System.Drawing.Size(584, 58)
            Me.TreeGrid1.SortingArrowColor = System.Drawing.Color.Red
            Me.TreeGrid1.TabIndex = 267
            Me.TreeGrid1.TreeManager = Nothing
            '
            'grpSum
            '
            Me.grpSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.grpSum.Controls.Add(Me.txtSumCheck)
            Me.grpSum.Controls.Add(Me.TxtSumTotal)
            Me.grpSum.Controls.Add(Me.lblSumCheck)
            Me.grpSum.Controls.Add(Me.lblSumTotal)
            Me.grpSum.Controls.Add(Me.lblItem)
            Me.grpSum.Controls.Add(Me.lblBaht)
            Me.grpSum.Controls.Add(Me.Label3)
            Me.grpSum.Controls.Add(Me.TextBox2)
            Me.grpSum.Controls.Add(Me.Label4)
            Me.grpSum.Location = New System.Drawing.Point(248, 240)
            Me.grpSum.Name = "grpSum"
            Me.grpSum.Size = New System.Drawing.Size(344, 96)
            Me.grpSum.TabIndex = 269
            Me.grpSum.TabStop = False
            Me.grpSum.Text = "สรุปรายการเช็คขายลด"
            '
            'txtSumCheck
            '
            Me.txtSumCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtSumCheck, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSumCheck, "")
            Me.txtSumCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSumCheck, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSumCheck, System.Drawing.Color.Empty)
            Me.txtSumCheck.Location = New System.Drawing.Point(152, 14)
            Me.Validator.SetMaxValue(Me.txtSumCheck, "")
            Me.Validator.SetMinValue(Me.txtSumCheck, "")
            Me.txtSumCheck.Name = "txtSumCheck"
            Me.Validator.SetRegularExpression(Me.txtSumCheck, "")
            Me.Validator.SetRequired(Me.txtSumCheck, False)
            Me.txtSumCheck.Size = New System.Drawing.Size(112, 22)
            Me.txtSumCheck.TabIndex = 187
            Me.txtSumCheck.Text = ""
            '
            'TxtSumTotal
            '
            Me.TxtSumTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.TxtSumTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.TxtSumTotal, "")
            Me.TxtSumTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.TxtSumTotal, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.TxtSumTotal, System.Drawing.Color.Empty)
            Me.TxtSumTotal.Location = New System.Drawing.Point(152, 64)
            Me.Validator.SetMaxValue(Me.TxtSumTotal, "")
            Me.Validator.SetMinValue(Me.TxtSumTotal, "")
            Me.TxtSumTotal.Name = "TxtSumTotal"
            Me.Validator.SetRegularExpression(Me.TxtSumTotal, "")
            Me.Validator.SetRequired(Me.TxtSumTotal, False)
            Me.TxtSumTotal.Size = New System.Drawing.Size(112, 22)
            Me.TxtSumTotal.TabIndex = 187
            Me.TxtSumTotal.Text = ""
            '
            'lblSumCheck
            '
            Me.lblSumCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSumCheck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSumCheck.ForeColor = System.Drawing.Color.Black
            Me.lblSumCheck.Location = New System.Drawing.Point(32, 16)
            Me.lblSumCheck.Name = "lblSumCheck"
            Me.lblSumCheck.Size = New System.Drawing.Size(112, 18)
            Me.lblSumCheck.TabIndex = 186
            Me.lblSumCheck.Text = "จำนวนเช็คที่จะขายลด:"
            Me.lblSumCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSumTotal
            '
            Me.lblSumTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSumTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSumTotal.ForeColor = System.Drawing.Color.Black
            Me.lblSumTotal.Location = New System.Drawing.Point(64, 72)
            Me.lblSumTotal.Name = "lblSumTotal"
            Me.lblSumTotal.Size = New System.Drawing.Size(80, 18)
            Me.lblSumTotal.TabIndex = 186
            Me.lblSumTotal.Text = "จำนวนเงินรวม:"
            Me.lblSumTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItem
            '
            Me.lblItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblItem.AutoSize = True
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(272, 16)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(38, 17)
            Me.lblItem.TabIndex = 186
            Me.lblItem.Text = "รายการ"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBaht
            '
            Me.lblBaht.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBaht.AutoSize = True
            Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht.ForeColor = System.Drawing.Color.Black
            Me.lblBaht.Location = New System.Drawing.Point(272, 64)
            Me.lblBaht.Name = "lblBaht"
            Me.lblBaht.Size = New System.Drawing.Size(25, 17)
            Me.lblBaht.TabIndex = 186
            Me.lblBaht.Text = "บาท"
            Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(56, 48)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 18)
            Me.Label3.TabIndex = 186
            Me.Label3.Text = "ภาษีหัก ณ ที่จ่าย:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TextBox2
            '
            Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.TextBox2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.TextBox2, "")
            Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.TextBox2, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.TextBox2, System.Drawing.Color.Empty)
            Me.TextBox2.Location = New System.Drawing.Point(152, 40)
            Me.Validator.SetMaxValue(Me.TextBox2, "")
            Me.Validator.SetMinValue(Me.TextBox2, "")
            Me.TextBox2.Name = "TextBox2"
            Me.Validator.SetRegularExpression(Me.TextBox2, "")
            Me.Validator.SetRequired(Me.TextBox2, False)
            Me.TextBox2.Size = New System.Drawing.Size(112, 22)
            Me.TextBox2.TabIndex = 187
            Me.TextBox2.Text = ""
            '
            'Label4
            '
            Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(272, 40)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(25, 17)
            Me.Label4.TabIndex = 186
            Me.Label4.Text = "บาท"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Black
            Me.lblStatus.Location = New System.Drawing.Point(16, 347)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 270
            Me.lblStatus.Text = "lblStatus"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'CheckDiscountDetail
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Name = "CheckDiscountDetail"
            Me.Size = New System.Drawing.Size(784, 384)
            Me.grbMaster.ResumeLayout(False)
            CType(Me.TreeGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpSum.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Member"
        Private m_isInitialized As Boolean = False
        Private m_entity As CheckDiscount
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            UpdateEntityProperties()
            EventWiring()
        End Sub
#End Region

#Region "Method"

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
        End Sub

#End Region

#Region "ISimpleEntityPanel"

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()

        End Sub

        ' เคลียร์ข้อมูลใน control
        Public Overrides Sub ClearDetail()

        End Sub

        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblBankAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblBankAccount}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblNote}")
            'Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblStatus}")
            Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblBank}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblCode}")
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.grbMaster}")
            Me.grpSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.grpSum}")
            Me.lblItem1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblItem1}")
            Me.lblSumCheck.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblSumCheck}")
            Me.lblSumTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblSumTotal}")
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblItem}")
            Me.lblBaht.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CheckDiscountDetail.lblBaht}")


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
                '.txtName.Text = .m_entity.Name
            End With

            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub

        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = Me.txtCode.Text
                Case "txtname"
                    'Me.m_entity.Name = Me.txtName.Text
            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = True

        End Sub

        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = CType(Value, CheckDiscount)
                'Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
                EventWiring()
            End Set
        End Property

        Public Overrides Sub Initialize()

        End Sub

#End Region

#Region "IReversibleEntityProperty"
        Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties

        End Sub

        Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties

        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

        Private Sub CheckDiscountDetail_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
            AddHandler Me.WorkbenchWindow.ViewContent.Saved, AddressOf EntitySaved
            AddHandler Me.WorkbenchWindow.ViewContent.Saving, AddressOf EntitySaving
        End Sub

        Private Sub EntitySaving(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

        End Sub


        
    End Class

End Namespace
