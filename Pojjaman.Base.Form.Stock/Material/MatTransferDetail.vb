Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MatTransferDetail
        Inherits AbstractEntityDetailPanelView

#Region "Members"
        Private m_entity As AROpeningBalance
        Private m_printDocument As PrintDocument
        Private m_printingStringFormat As StringFormat
        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            UpdateEntityProperties()
            m_isInitialized = True
        End Sub
#End Region

#Region "Initialize"
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblProjectName As System.Windows.Forms.Label
        Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblMatWithdrawTotalAmount As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
        Friend WithEvents lblItemCount As System.Windows.Forms.Label
        Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
        Friend WithEvents lblBaht As System.Windows.Forms.Label
        Friend WithEvents lblReceivePerson As System.Windows.Forms.Label
        Friend WithEvents ibtnShowSite As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtReceivePersonCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowReceivePerson As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton8 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton9 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowProject As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowReturnPerson As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton5 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton7 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtTransferToCC As System.Windows.Forms.TextBox
        Friend WithEvents lblTransferToCC As System.Windows.Forms.Label
        Friend WithEvents txtTransferToCCName As System.Windows.Forms.TextBox
        Friend WithEvents txtTransferFromPerson As System.Windows.Forms.TextBox
        Friend WithEvents lblTransferFromPerson As System.Windows.Forms.Label
        Friend WithEvents lblTransferFromCC As System.Windows.Forms.Label
        Friend WithEvents txtTransferFormCC As System.Windows.Forms.TextBox
        Friend WithEvents txtTransferFromPersonName As System.Windows.Forms.TextBox
        Friend WithEvents txtTransferFromCCName As System.Windows.Forms.TextBox
        Friend WithEvents imbAdd As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents grbReceive As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtTransferToPersonName As System.Windows.Forms.TextBox
        Friend WithEvents grbReturn As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MatTransferDetail))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtItemCount = New System.Windows.Forms.TextBox
            Me.lblItemCount = New System.Windows.Forms.Label
            Me.lblItemCountUnit = New System.Windows.Forms.Label
            Me.lblBaht = New System.Windows.Forms.Label
            Me.txtTotalAmount = New System.Windows.Forms.TextBox
            Me.lblMatWithdrawTotalAmount = New System.Windows.Forms.Label
            Me.grbReceive = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTransferToCC = New System.Windows.Forms.TextBox
            Me.lblReceivePerson = New System.Windows.Forms.Label
            Me.ibtnShowSite = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblTransferToCC = New System.Windows.Forms.Label
            Me.txtReceivePersonCode = New System.Windows.Forms.TextBox
            Me.ibtnShowReceivePerson = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtTransferToPersonName = New System.Windows.Forms.TextBox
            Me.txtTransferToCCName = New System.Windows.Forms.TextBox
            Me.ImageButton8 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton9 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbReturn = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTransferFromPerson = New System.Windows.Forms.TextBox
            Me.lblTransferFromPerson = New System.Windows.Forms.Label
            Me.lblTransferFromCC = New System.Windows.Forms.Label
            Me.ibtnShowProject = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtTransferFormCC = New System.Windows.Forms.TextBox
            Me.ibtnShowReturnPerson = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtTransferFromPersonName = New System.Windows.Forms.TextBox
            Me.txtTransferFromCCName = New System.Windows.Forms.TextBox
            Me.ImageButton5 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton7 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.imbAdd = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbSummary.SuspendLayout()
            Me.grbReceive.SuspendLayout()
            Me.grbReturn.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(24, 9)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 124
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.txtCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(104, 8)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(144, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDate.Location = New System.Drawing.Point(328, 8)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpDocDate.TabIndex = 4
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(248, 9)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(80, 18)
            Me.lblDocDate.TabIndex = 128
            Me.lblDocDate.Text = "วันที่เอกสาร"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 232)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(664, 216)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 164
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 216)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(112, 18)
            Me.lblItem.TabIndex = 163
            Me.lblItem.Text = "รายการโอนย้าย:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbSummary
            '
            Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.grbSummary.Controls.Add(Me.txtItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
            Me.grbSummary.Controls.Add(Me.lblBaht)
            Me.grbSummary.Controls.Add(Me.txtTotalAmount)
            Me.grbSummary.Controls.Add(Me.lblMatWithdrawTotalAmount)
            Me.grbSummary.Location = New System.Drawing.Point(8, 456)
            Me.grbSummary.Name = "grbSummary"
            Me.grbSummary.Size = New System.Drawing.Size(568, 48)
            Me.grbSummary.TabIndex = 174
            Me.grbSummary.TabStop = False
            Me.grbSummary.Text = "สรุปยอดรายการโอนย้าย"
            '
            'txtItemCount
            '
            Me.txtItemCount.BackColor = System.Drawing.SystemColors.Control
            Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtItemCount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.txtItemCount.Location = New System.Drawing.Point(88, 16)
            Me.Validator.SetMaxValue(Me.txtItemCount, "")
            Me.Validator.SetMinValue(Me.txtItemCount, "")
            Me.txtItemCount.Name = "txtItemCount"
            Me.txtItemCount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtItemCount, "")
            Me.Validator.SetRequired(Me.txtItemCount, False)
            Me.txtItemCount.Size = New System.Drawing.Size(64, 21)
            Me.txtItemCount.TabIndex = 0
            Me.txtItemCount.Text = ""
            '
            'lblItemCount
            '
            Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCount.Location = New System.Drawing.Point(8, 17)
            Me.lblItemCount.Name = "lblItemCount"
            Me.lblItemCount.Size = New System.Drawing.Size(72, 18)
            Me.lblItemCount.TabIndex = 124
            Me.lblItemCount.Text = "จำนวนรายการ:"
            Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItemCountUnit
            '
            Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCountUnit.Location = New System.Drawing.Point(152, 17)
            Me.lblItemCountUnit.Name = "lblItemCountUnit"
            Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
            Me.lblItemCountUnit.TabIndex = 124
            Me.lblItemCountUnit.Text = "รายการ"
            Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBaht
            '
            Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht.Location = New System.Drawing.Point(488, 17)
            Me.lblBaht.Name = "lblBaht"
            Me.lblBaht.Size = New System.Drawing.Size(40, 18)
            Me.lblBaht.TabIndex = 124
            Me.lblBaht.Text = "บาท"
            Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTotalAmount
            '
            Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Control
            Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtTotalAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
            Me.txtTotalAmount.Location = New System.Drawing.Point(360, 16)
            Me.Validator.SetMaxValue(Me.txtTotalAmount, "")
            Me.Validator.SetMinValue(Me.txtTotalAmount, "")
            Me.txtTotalAmount.Name = "txtTotalAmount"
            Me.txtTotalAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotalAmount, "")
            Me.Validator.SetRequired(Me.txtTotalAmount, False)
            Me.txtTotalAmount.Size = New System.Drawing.Size(120, 21)
            Me.txtTotalAmount.TabIndex = 0
            Me.txtTotalAmount.Text = ""
            '
            'lblMatWithdrawTotalAmount
            '
            Me.lblMatWithdrawTotalAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMatWithdrawTotalAmount.Location = New System.Drawing.Point(200, 17)
            Me.lblMatWithdrawTotalAmount.Name = "lblMatWithdrawTotalAmount"
            Me.lblMatWithdrawTotalAmount.Size = New System.Drawing.Size(160, 18)
            Me.lblMatWithdrawTotalAmount.TabIndex = 124
            Me.lblMatWithdrawTotalAmount.Text = "มูลค่ารวมของรายการที่โอนย้าย:"
            Me.lblMatWithdrawTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbReceive
            '
            Me.grbReceive.Controls.Add(Me.txtTransferToCC)
            Me.grbReceive.Controls.Add(Me.lblReceivePerson)
            Me.grbReceive.Controls.Add(Me.ibtnShowSite)
            Me.grbReceive.Controls.Add(Me.lblTransferToCC)
            Me.grbReceive.Controls.Add(Me.txtReceivePersonCode)
            Me.grbReceive.Controls.Add(Me.ibtnShowReceivePerson)
            Me.grbReceive.Controls.Add(Me.txtTransferToPersonName)
            Me.grbReceive.Controls.Add(Me.txtTransferToCCName)
            Me.grbReceive.Controls.Add(Me.ImageButton8)
            Me.grbReceive.Controls.Add(Me.ImageButton9)
            Me.grbReceive.Location = New System.Drawing.Point(16, 104)
            Me.grbReceive.Name = "grbReceive"
            Me.grbReceive.Size = New System.Drawing.Size(648, 80)
            Me.grbReceive.TabIndex = 181
            Me.grbReceive.TabStop = False
            Me.grbReceive.Text = "รับโอน"
            '
            'txtTransferToCC
            '
            Me.txtTransferToCC.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtTransferToCC, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTransferToCC, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTransferToCC, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTransferToCC, System.Drawing.Color.Empty)
            Me.txtTransferToCC.Location = New System.Drawing.Point(88, 48)
            Me.Validator.SetMaxValue(Me.txtTransferToCC, "")
            Me.Validator.SetMinValue(Me.txtTransferToCC, "")
            Me.txtTransferToCC.Name = "txtTransferToCC"
            Me.Validator.SetRegularExpression(Me.txtTransferToCC, "")
            Me.Validator.SetRequired(Me.txtTransferToCC, False)
            Me.txtTransferToCC.Size = New System.Drawing.Size(88, 21)
            Me.txtTransferToCC.TabIndex = 175
            Me.txtTransferToCC.Text = ""
            '
            'lblReceivePerson
            '
            Me.lblReceivePerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceivePerson.Location = New System.Drawing.Point(16, 24)
            Me.lblReceivePerson.Name = "lblReceivePerson"
            Me.lblReceivePerson.Size = New System.Drawing.Size(72, 18)
            Me.lblReceivePerson.TabIndex = 124
            Me.lblReceivePerson.Text = "ผู้รับโอน:"
            Me.lblReceivePerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnShowSite
            '
            Me.ibtnShowSite.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowSite.Image = CType(resources.GetObject("ibtnShowSite.Image"), System.Drawing.Image)
            Me.ibtnShowSite.Location = New System.Drawing.Point(608, 48)
            Me.ibtnShowSite.Name = "ibtnShowSite"
            Me.ibtnShowSite.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowSite.TabIndex = 174
            Me.ibtnShowSite.TabStop = False
            Me.ibtnShowSite.ThemedImage = CType(resources.GetObject("ibtnShowSite.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblTransferToCC
            '
            Me.lblTransferToCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTransferToCC.Location = New System.Drawing.Point(16, 48)
            Me.lblTransferToCC.Name = "lblTransferToCC"
            Me.lblTransferToCC.Size = New System.Drawing.Size(72, 18)
            Me.lblTransferToCC.TabIndex = 171
            Me.lblTransferToCC.Text = "คลังรับโอน:"
            Me.lblTransferToCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtReceivePersonCode
            '
            Me.txtReceivePersonCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtReceivePersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReceivePersonCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReceivePersonCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtReceivePersonCode, System.Drawing.Color.Empty)
            Me.txtReceivePersonCode.Location = New System.Drawing.Point(88, 24)
            Me.Validator.SetMaxValue(Me.txtReceivePersonCode, "")
            Me.Validator.SetMinValue(Me.txtReceivePersonCode, "")
            Me.txtReceivePersonCode.Name = "txtReceivePersonCode"
            Me.Validator.SetRegularExpression(Me.txtReceivePersonCode, "")
            Me.Validator.SetRequired(Me.txtReceivePersonCode, False)
            Me.txtReceivePersonCode.Size = New System.Drawing.Size(88, 21)
            Me.txtReceivePersonCode.TabIndex = 175
            Me.txtReceivePersonCode.Text = ""
            '
            'ibtnShowReceivePerson
            '
            Me.ibtnShowReceivePerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowReceivePerson.Image = CType(resources.GetObject("ibtnShowReceivePerson.Image"), System.Drawing.Image)
            Me.ibtnShowReceivePerson.Location = New System.Drawing.Point(608, 24)
            Me.ibtnShowReceivePerson.Name = "ibtnShowReceivePerson"
            Me.ibtnShowReceivePerson.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowReceivePerson.TabIndex = 174
            Me.ibtnShowReceivePerson.TabStop = False
            Me.ibtnShowReceivePerson.ThemedImage = CType(resources.GetObject("ibtnShowReceivePerson.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtTransferToPersonName
            '
            Me.txtTransferToPersonName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtTransferToPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTransferToPersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTransferToPersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTransferToPersonName, System.Drawing.Color.Empty)
            Me.txtTransferToPersonName.Location = New System.Drawing.Point(176, 24)
            Me.Validator.SetMaxValue(Me.txtTransferToPersonName, "")
            Me.Validator.SetMinValue(Me.txtTransferToPersonName, "")
            Me.txtTransferToPersonName.Name = "txtTransferToPersonName"
            Me.Validator.SetRegularExpression(Me.txtTransferToPersonName, "")
            Me.Validator.SetRequired(Me.txtTransferToPersonName, False)
            Me.txtTransferToPersonName.Size = New System.Drawing.Size(408, 21)
            Me.txtTransferToPersonName.TabIndex = 175
            Me.txtTransferToPersonName.Text = ""
            '
            'txtTransferToCCName
            '
            Me.txtTransferToCCName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtTransferToCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTransferToCCName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTransferToCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTransferToCCName, System.Drawing.Color.Empty)
            Me.txtTransferToCCName.Location = New System.Drawing.Point(176, 48)
            Me.Validator.SetMaxValue(Me.txtTransferToCCName, "")
            Me.Validator.SetMinValue(Me.txtTransferToCCName, "")
            Me.txtTransferToCCName.Name = "txtTransferToCCName"
            Me.Validator.SetRegularExpression(Me.txtTransferToCCName, "")
            Me.Validator.SetRequired(Me.txtTransferToCCName, False)
            Me.txtTransferToCCName.Size = New System.Drawing.Size(408, 21)
            Me.txtTransferToCCName.TabIndex = 175
            Me.txtTransferToCCName.Text = ""
            '
            'ImageButton8
            '
            Me.ImageButton8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton8.ForeColor = System.Drawing.SystemColors.Control
            Me.ImageButton8.Image = CType(resources.GetObject("ImageButton8.Image"), System.Drawing.Image)
            Me.ImageButton8.Location = New System.Drawing.Point(584, 24)
            Me.ImageButton8.Name = "ImageButton8"
            Me.ImageButton8.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton8.TabIndex = 174
            Me.ImageButton8.TabStop = False
            Me.ImageButton8.ThemedImage = CType(resources.GetObject("ImageButton8.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton9
            '
            Me.ImageButton9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton9.ForeColor = System.Drawing.SystemColors.Control
            Me.ImageButton9.Image = CType(resources.GetObject("ImageButton9.Image"), System.Drawing.Image)
            Me.ImageButton9.Location = New System.Drawing.Point(584, 48)
            Me.ImageButton9.Name = "ImageButton9"
            Me.ImageButton9.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton9.TabIndex = 174
            Me.ImageButton9.TabStop = False
            Me.ImageButton9.ThemedImage = CType(resources.GetObject("ImageButton9.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbReturn
            '
            Me.grbReturn.Controls.Add(Me.txtTransferFromPerson)
            Me.grbReturn.Controls.Add(Me.lblTransferFromPerson)
            Me.grbReturn.Controls.Add(Me.lblTransferFromCC)
            Me.grbReturn.Controls.Add(Me.ibtnShowProject)
            Me.grbReturn.Controls.Add(Me.txtTransferFormCC)
            Me.grbReturn.Controls.Add(Me.ibtnShowReturnPerson)
            Me.grbReturn.Controls.Add(Me.txtTransferFromPersonName)
            Me.grbReturn.Controls.Add(Me.txtTransferFromCCName)
            Me.grbReturn.Controls.Add(Me.ImageButton5)
            Me.grbReturn.Controls.Add(Me.ImageButton7)
            Me.grbReturn.Location = New System.Drawing.Point(16, 32)
            Me.grbReturn.Name = "grbReturn"
            Me.grbReturn.Size = New System.Drawing.Size(648, 72)
            Me.grbReturn.TabIndex = 180
            Me.grbReturn.TabStop = False
            Me.grbReturn.Text = "โอนจาก"
            '
            'txtTransferFromPerson
            '
            Me.txtTransferFromPerson.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtTransferFromPerson, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTransferFromPerson, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTransferFromPerson, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTransferFromPerson, System.Drawing.Color.Empty)
            Me.txtTransferFromPerson.Location = New System.Drawing.Point(88, 16)
            Me.Validator.SetMaxValue(Me.txtTransferFromPerson, "")
            Me.Validator.SetMinValue(Me.txtTransferFromPerson, "")
            Me.txtTransferFromPerson.Name = "txtTransferFromPerson"
            Me.Validator.SetRegularExpression(Me.txtTransferFromPerson, "")
            Me.Validator.SetRequired(Me.txtTransferFromPerson, False)
            Me.txtTransferFromPerson.Size = New System.Drawing.Size(88, 21)
            Me.txtTransferFromPerson.TabIndex = 175
            Me.txtTransferFromPerson.Text = ""
            '
            'lblTransferFromPerson
            '
            Me.lblTransferFromPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTransferFromPerson.Location = New System.Drawing.Point(8, 16)
            Me.lblTransferFromPerson.Name = "lblTransferFromPerson"
            Me.lblTransferFromPerson.Size = New System.Drawing.Size(72, 18)
            Me.lblTransferFromPerson.TabIndex = 124
            Me.lblTransferFromPerson.Text = "ผู้ทำรายการ:"
            Me.lblTransferFromPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTransferFromCC
            '
            Me.lblTransferFromCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTransferFromCC.Location = New System.Drawing.Point(8, 40)
            Me.lblTransferFromCC.Name = "lblTransferFromCC"
            Me.lblTransferFromCC.Size = New System.Drawing.Size(72, 18)
            Me.lblTransferFromCC.TabIndex = 124
            Me.lblTransferFromCC.Text = "คลังโอน:"
            Me.lblTransferFromCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnShowProject
            '
            Me.ibtnShowProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowProject.Image = CType(resources.GetObject("ibtnShowProject.Image"), System.Drawing.Image)
            Me.ibtnShowProject.Location = New System.Drawing.Point(608, 40)
            Me.ibtnShowProject.Name = "ibtnShowProject"
            Me.ibtnShowProject.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowProject.TabIndex = 174
            Me.ibtnShowProject.TabStop = False
            Me.ibtnShowProject.ThemedImage = CType(resources.GetObject("ibtnShowProject.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtTransferFormCC
            '
            Me.txtTransferFormCC.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtTransferFormCC, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTransferFormCC, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTransferFormCC, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTransferFormCC, System.Drawing.Color.Empty)
            Me.txtTransferFormCC.Location = New System.Drawing.Point(88, 40)
            Me.Validator.SetMaxValue(Me.txtTransferFormCC, "")
            Me.Validator.SetMinValue(Me.txtTransferFormCC, "")
            Me.txtTransferFormCC.Name = "txtTransferFormCC"
            Me.Validator.SetRegularExpression(Me.txtTransferFormCC, "")
            Me.Validator.SetRequired(Me.txtTransferFormCC, False)
            Me.txtTransferFormCC.Size = New System.Drawing.Size(88, 21)
            Me.txtTransferFormCC.TabIndex = 175
            Me.txtTransferFormCC.Text = ""
            '
            'ibtnShowReturnPerson
            '
            Me.ibtnShowReturnPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowReturnPerson.Image = CType(resources.GetObject("ibtnShowReturnPerson.Image"), System.Drawing.Image)
            Me.ibtnShowReturnPerson.Location = New System.Drawing.Point(608, 16)
            Me.ibtnShowReturnPerson.Name = "ibtnShowReturnPerson"
            Me.ibtnShowReturnPerson.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowReturnPerson.TabIndex = 174
            Me.ibtnShowReturnPerson.TabStop = False
            Me.ibtnShowReturnPerson.ThemedImage = CType(resources.GetObject("ibtnShowReturnPerson.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtTransferFromPersonName
            '
            Me.txtTransferFromPersonName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtTransferFromPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTransferFromPersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTransferFromPersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTransferFromPersonName, System.Drawing.Color.Empty)
            Me.txtTransferFromPersonName.Location = New System.Drawing.Point(176, 16)
            Me.Validator.SetMaxValue(Me.txtTransferFromPersonName, "")
            Me.Validator.SetMinValue(Me.txtTransferFromPersonName, "")
            Me.txtTransferFromPersonName.Name = "txtTransferFromPersonName"
            Me.Validator.SetRegularExpression(Me.txtTransferFromPersonName, "")
            Me.Validator.SetRequired(Me.txtTransferFromPersonName, False)
            Me.txtTransferFromPersonName.Size = New System.Drawing.Size(408, 21)
            Me.txtTransferFromPersonName.TabIndex = 175
            Me.txtTransferFromPersonName.Text = ""
            '
            'txtTransferFromCCName
            '
            Me.txtTransferFromCCName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtTransferFromCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTransferFromCCName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTransferFromCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTransferFromCCName, System.Drawing.Color.Empty)
            Me.txtTransferFromCCName.Location = New System.Drawing.Point(176, 40)
            Me.Validator.SetMaxValue(Me.txtTransferFromCCName, "")
            Me.Validator.SetMinValue(Me.txtTransferFromCCName, "")
            Me.txtTransferFromCCName.Name = "txtTransferFromCCName"
            Me.Validator.SetRegularExpression(Me.txtTransferFromCCName, "")
            Me.Validator.SetRequired(Me.txtTransferFromCCName, False)
            Me.txtTransferFromCCName.Size = New System.Drawing.Size(408, 21)
            Me.txtTransferFromCCName.TabIndex = 175
            Me.txtTransferFromCCName.Text = ""
            '
            'ImageButton5
            '
            Me.ImageButton5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton5.ForeColor = System.Drawing.SystemColors.Control
            Me.ImageButton5.Image = CType(resources.GetObject("ImageButton5.Image"), System.Drawing.Image)
            Me.ImageButton5.Location = New System.Drawing.Point(584, 16)
            Me.ImageButton5.Name = "ImageButton5"
            Me.ImageButton5.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton5.TabIndex = 174
            Me.ImageButton5.TabStop = False
            Me.ImageButton5.ThemedImage = CType(resources.GetObject("ImageButton5.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton7
            '
            Me.ImageButton7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton7.ForeColor = System.Drawing.SystemColors.Control
            Me.ImageButton7.Image = CType(resources.GetObject("ImageButton7.Image"), System.Drawing.Image)
            Me.ImageButton7.Location = New System.Drawing.Point(584, 40)
            Me.ImageButton7.Name = "ImageButton7"
            Me.ImageButton7.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton7.TabIndex = 174
            Me.ImageButton7.TabStop = False
            Me.ImageButton7.ThemedImage = CType(resources.GetObject("ImageButton7.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(104, 184)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(496, 21)
            Me.txtNote.TabIndex = 182
            Me.txtNote.Text = ""
            '
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(24, 184)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(72, 18)
            Me.lblNote.TabIndex = 183
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'imbAdd
            '
            Me.imbAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.imbAdd.Image = CType(resources.GetObject("imbAdd.Image"), System.Drawing.Image)
            Me.imbAdd.Location = New System.Drawing.Point(112, 208)
            Me.imbAdd.Name = "imbAdd"
            Me.imbAdd.Size = New System.Drawing.Size(24, 23)
            Me.imbAdd.TabIndex = 184
            Me.imbAdd.TabStop = False
            Me.imbAdd.ThemedImage = CType(resources.GetObject("imbAdd.ThemedImage"), System.Drawing.Bitmap)
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
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'MatTransferDetail
            '
            Me.Controls.Add(Me.imbAdd)
            Me.Controls.Add(Me.txtNote)
            Me.Controls.Add(Me.lblNote)
            Me.Controls.Add(Me.grbReceive)
            Me.Controls.Add(Me.grbReturn)
            Me.Controls.Add(Me.grbSummary)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.dtpDocDate)
            Me.Controls.Add(Me.lblDocDate)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "MatTransferDetail"
            Me.Size = New System.Drawing.Size(680, 512)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbSummary.ResumeLayout(False)
            Me.grbReceive.ResumeLayout(False)
            Me.grbReturn.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
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
#End Region

#Region "Overrides"
        Protected Overrides Sub EventWiring()
            For Each ctrl As Control In Me.Controls
                AddHandler ctrl.Validated, AddressOf Me.ControlValidated
            Next
        End Sub
        Public Overrides Sub Initialize()
        End Sub
        Protected Sub AddBinding(ByVal ctrl As System.Windows.Forms.Control, ByVal ds As Object, ByVal prop As String, ByVal name As String)
            Try
                If Not IsNothing(ctrl.DataBindings(prop)) Then
                    ctrl.DataBindings.Remove(ctrl.DataBindings(prop))
                End If
                Dim b As Binding = ctrl.DataBindings.Add(prop, ds, name)
                'Select Case name
                '    'Hack
                'Case "DiscountAmount", "BeforeTax", "AfterTax", "TaxAmount", "Gross", "TaxRate"
                '        AddHandler b.Format, AddressOf DecimalToCurrencyString
                '        AddHandler b.Parse, AddressOf CurrencyStringToDecimal
                '    Case Else
                '        AddHandler b.Format, AddressOf FormatHandler
                '        AddHandler b.Parse, AddressOf ParseHandler
                'End Select
                ctrl.Tag = Nothing
            Catch ex As Exception

            End Try
        End Sub
        Public Overrides Sub CheckFormEnable()

        End Sub
        Public Overrides Sub ClearDetail()

        End Sub
        Public Overrides Sub UpdateEntityProperties()
            ClearDetail()
            If Me.m_entity Is Nothing Then
                'ClearDetail()
                Return
            End If
            AddBinding(Me.txtCode, Me.m_entity, "Text", "Code")
            AddBinding(Me.dtpDocDate, Me.m_entity, "Value", "DocDate")


            SetLabelText()
        End Sub
        Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, AROpeningBalance)
                UpdateEntityProperties()
            End Set
        End Property
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.lblCode}")
            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
            Me.lblProjectName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.lblProjectName}")
            Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.grbSummary}")
            Me.lblMatWithdrawTotalAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.lblMatWithdrawTotalAmount}")
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.lblItem}")
            Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.lblItemCount}")
            Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Global.ItemCountUnitText}")
            Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblReceivePerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.lblReceivePerson}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.lblTransferToCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.lblTransferToCC}")
            Me.lblTransferFromPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.lblTransferFromPerson}")
            Me.lblTransferFromCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.lblTransferFromCC}")
            Me.grbReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.grbReceive}")
            Me.grbReturn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetail.grbReturn}")

        End Sub
#End Region



        Private Sub txtTransferFromPersonName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransferFromPersonName.TextChanged

        End Sub
    End Class
End Namespace

