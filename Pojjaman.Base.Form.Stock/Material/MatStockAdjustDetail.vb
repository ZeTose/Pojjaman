Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MatStockAdjustDetail
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
        Friend WithEvents lblProjectName As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ibtnCCfind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtCCcode As System.Windows.Forms.TextBox
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents txtCCname As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblMatstart As System.Windows.Forms.Label
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
        Friend WithEvents lblCurrency1 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency2 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency3 As System.Windows.Forms.Label
        Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MatStockAdjustDetail))
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtCCcode = New System.Windows.Forms.TextBox
            Me.txtCCname = New System.Windows.Forms.TextBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.TextBox1 = New System.Windows.Forms.TextBox
            Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
            Me.TextBox2 = New System.Windows.Forms.TextBox
            Me.TextBox3 = New System.Windows.Forms.TextBox
            Me.TextBox4 = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.lblItem = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.CheckBox1 = New System.Windows.Forms.CheckBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.ibtnCCfind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.lblCC = New System.Windows.Forms.Label
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblMatstart = New System.Windows.Forms.Label
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.Label4 = New System.Windows.Forms.Label
            Me.lblCurrency1 = New System.Windows.Forms.Label
            Me.lblCurrency2 = New System.Windows.Forms.Label
            Me.lblCurrency3 = New System.Windows.Forms.Label
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txtDocDate
            '
            Me.txtDocDate.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDocDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.txtDocDate.Location = New System.Drawing.Point(416, 16)
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, False)
            Me.txtDocDate.Size = New System.Drawing.Size(122, 21)
            Me.txtDocDate.TabIndex = 4
            Me.txtDocDate.Text = ""
            '
            'txtCCcode
            '
            Me.txtCCcode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCCcode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCcode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCCcode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCcode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCcode, System.Drawing.Color.Empty)
            Me.txtCCcode.Location = New System.Drawing.Point(152, 40)
            Me.Validator.SetMaxValue(Me.txtCCcode, "")
            Me.Validator.SetMinValue(Me.txtCCcode, "")
            Me.txtCCcode.Name = "txtCCcode"
            Me.Validator.SetRegularExpression(Me.txtCCcode, "")
            Me.Validator.SetRequired(Me.txtCCcode, False)
            Me.txtCCcode.Size = New System.Drawing.Size(120, 21)
            Me.txtCCcode.TabIndex = 8
            Me.txtCCcode.Text = ""
            '
            'txtCCname
            '
            Me.txtCCname.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCCname, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCname, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCCname, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCname, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCname, System.Drawing.Color.Empty)
            Me.txtCCname.Location = New System.Drawing.Point(152, 64)
            Me.Validator.SetMaxValue(Me.txtCCname, "")
            Me.Validator.SetMinValue(Me.txtCCname, "")
            Me.txtCCname.Name = "txtCCname"
            Me.Validator.SetRegularExpression(Me.txtCCname, "")
            Me.Validator.SetRequired(Me.txtCCname, False)
            Me.txtCCname.Size = New System.Drawing.Size(120, 21)
            Me.txtCCname.TabIndex = 9
            Me.txtCCname.TabStop = False
            Me.txtCCname.Text = ""
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.ErrorProvider1.SetIconPadding(Me.dtpDocDate, -15)
            Me.dtpDocDate.Location = New System.Drawing.Point(416, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpDocDate.TabIndex = 5
            Me.dtpDocDate.TabStop = False
            '
            'txtCode
            '
            Me.txtCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(120, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'TextBox1
            '
            Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.TextBox1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.TextBox1, "")
            Me.Validator.SetGotFocusBackColor(Me.TextBox1, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.TextBox1, -15)
            Me.Validator.SetInvalidBackColor(Me.TextBox1, System.Drawing.Color.Empty)
            Me.TextBox1.Location = New System.Drawing.Point(416, 40)
            Me.Validator.SetMaxValue(Me.TextBox1, "")
            Me.Validator.SetMinValue(Me.TextBox1, "")
            Me.TextBox1.Name = "TextBox1"
            Me.Validator.SetRegularExpression(Me.TextBox1, "")
            Me.Validator.SetRequired(Me.TextBox1, False)
            Me.TextBox1.Size = New System.Drawing.Size(122, 21)
            Me.TextBox1.TabIndex = 23
            Me.TextBox1.Text = ""
            '
            'DateTimePicker1
            '
            Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.ErrorProvider1.SetIconPadding(Me.DateTimePicker1, -15)
            Me.DateTimePicker1.Location = New System.Drawing.Point(416, 40)
            Me.DateTimePicker1.Name = "DateTimePicker1"
            Me.DateTimePicker1.Size = New System.Drawing.Size(144, 21)
            Me.DateTimePicker1.TabIndex = 24
            Me.DateTimePicker1.TabStop = False
            '
            'TextBox2
            '
            Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.TextBox2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.TextBox2, "")
            Me.Validator.SetGotFocusBackColor(Me.TextBox2, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.TextBox2, -15)
            Me.Validator.SetInvalidBackColor(Me.TextBox2, System.Drawing.Color.Empty)
            Me.TextBox2.Location = New System.Drawing.Point(488, 408)
            Me.Validator.SetMaxValue(Me.TextBox2, "")
            Me.Validator.SetMinValue(Me.TextBox2, "")
            Me.TextBox2.Name = "TextBox2"
            Me.Validator.SetRegularExpression(Me.TextBox2, "")
            Me.Validator.SetRequired(Me.TextBox2, False)
            Me.TextBox2.Size = New System.Drawing.Size(120, 21)
            Me.TextBox2.TabIndex = 34
            Me.TextBox2.Text = ""
            Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TextBox3
            '
            Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.TextBox3, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.TextBox3, "")
            Me.Validator.SetGotFocusBackColor(Me.TextBox3, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.TextBox3, -15)
            Me.Validator.SetInvalidBackColor(Me.TextBox3, System.Drawing.Color.Empty)
            Me.TextBox3.Location = New System.Drawing.Point(488, 432)
            Me.Validator.SetMaxValue(Me.TextBox3, "")
            Me.Validator.SetMinValue(Me.TextBox3, "")
            Me.TextBox3.Name = "TextBox3"
            Me.Validator.SetRegularExpression(Me.TextBox3, "")
            Me.Validator.SetRequired(Me.TextBox3, False)
            Me.TextBox3.Size = New System.Drawing.Size(120, 21)
            Me.TextBox3.TabIndex = 35
            Me.TextBox3.Text = ""
            Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TextBox4
            '
            Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.TextBox4.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.TextBox4, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.TextBox4, "")
            Me.Validator.SetGotFocusBackColor(Me.TextBox4, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.TextBox4, -15)
            Me.Validator.SetInvalidBackColor(Me.TextBox4, System.Drawing.Color.Empty)
            Me.TextBox4.Location = New System.Drawing.Point(488, 456)
            Me.Validator.SetMaxValue(Me.TextBox4, "")
            Me.Validator.SetMinValue(Me.TextBox4, "")
            Me.TextBox4.Name = "TextBox4"
            Me.Validator.SetRegularExpression(Me.TextBox4, "")
            Me.Validator.SetRequired(Me.TextBox4, False)
            Me.TextBox4.Size = New System.Drawing.Size(120, 21)
            Me.TextBox4.TabIndex = 36
            Me.TextBox4.Text = ""
            Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
            'lblItem
            '
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(16, 120)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(112, 18)
            Me.lblItem.TabIndex = 22
            Me.lblItem.Text = "รายการตรวจนับ:"
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
            Me.tgItem.Location = New System.Drawing.Point(8, 144)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(680, 256)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 23
            Me.tgItem.TreeManager = Nothing
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.CheckBox1)
            Me.grbDetail.Controls.Add(Me.TextBox1)
            Me.grbDetail.Controls.Add(Me.DateTimePicker1)
            Me.grbDetail.Controls.Add(Me.Label1)
            Me.grbDetail.Controls.Add(Me.ibtnCCfind)
            Me.grbDetail.Controls.Add(Me.txtDocDate)
            Me.grbDetail.Controls.Add(Me.chkAutorun)
            Me.grbDetail.Controls.Add(Me.txtCCcode)
            Me.grbDetail.Controls.Add(Me.lblCC)
            Me.grbDetail.Controls.Add(Me.txtCCname)
            Me.grbDetail.Controls.Add(Me.dtpDocDate)
            Me.grbDetail.Controls.Add(Me.lblDocDate)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblMatstart)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(600, 96)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'CheckBox1
            '
            Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
            Me.CheckBox1.Image = CType(resources.GetObject("CheckBox1.Image"), System.Drawing.Image)
            Me.CheckBox1.Location = New System.Drawing.Point(272, 64)
            Me.CheckBox1.Name = "CheckBox1"
            Me.CheckBox1.Size = New System.Drawing.Size(21, 21)
            Me.CheckBox1.TabIndex = 25
            Me.CheckBox1.TabStop = False
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label1.Location = New System.Drawing.Point(296, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 18)
            Me.Label1.TabIndex = 22
            Me.Label1.Text = "วันที่เอกสารตรวจนับ"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnCCfind
            '
            Me.ibtnCCfind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnCCfind.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnCCfind.Image = CType(resources.GetObject("ibtnCCfind.Image"), System.Drawing.Image)
            Me.ibtnCCfind.Location = New System.Drawing.Point(272, 40)
            Me.ibtnCCfind.Name = "ibtnCCfind"
            Me.ibtnCCfind.Size = New System.Drawing.Size(23, 22)
            Me.ibtnCCfind.TabIndex = 10
            Me.ibtnCCfind.TabStop = False
            Me.ibtnCCfind.ThemedImage = CType(resources.GetObject("ibtnCCfind.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(272, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 2
            Me.chkAutorun.TabStop = False
            '
            'lblCC
            '
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.Location = New System.Drawing.Point(8, 40)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(136, 18)
            Me.lblCC.TabIndex = 7
            Me.lblCC.Text = "เลขที่เอกสารตรวจนับ"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(296, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(112, 18)
            Me.lblDocDate.TabIndex = 3
            Me.lblDocDate.Text = "วันที่เอกสาร"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(136, 18)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลขที่เอกสารปรับปรุงยอด"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMatstart
            '
            Me.lblMatstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMatstart.Location = New System.Drawing.Point(8, 64)
            Me.lblMatstart.Name = "lblMatstart"
            Me.lblMatstart.Size = New System.Drawing.Size(136, 18)
            Me.lblMatstart.TabIndex = 12
            Me.lblMatstart.Text = "จากวัสดุ"
            Me.lblMatstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(152, 112)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 29
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(176, 112)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 30
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'Label2
            '
            Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label2.Location = New System.Drawing.Point(368, 408)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(112, 18)
            Me.Label2.TabIndex = 31
            Me.Label2.Text = "รวมราคาขาย"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label3.Location = New System.Drawing.Point(368, 432)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(112, 18)
            Me.Label3.TabIndex = 32
            Me.Label3.Text = "รวมภาษี"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label4.Location = New System.Drawing.Point(368, 456)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 18)
            Me.Label4.TabIndex = 33
            Me.Label4.Text = "รวมทั้งสิ้น"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrency1
            '
            Me.lblCurrency1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency1.AutoSize = True
            Me.lblCurrency1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency1.Location = New System.Drawing.Point(616, 408)
            Me.lblCurrency1.Name = "lblCurrency1"
            Me.lblCurrency1.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency1.TabIndex = 37
            Me.lblCurrency1.Text = "บาท"
            Me.lblCurrency1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblCurrency2
            '
            Me.lblCurrency2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency2.AutoSize = True
            Me.lblCurrency2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency2.Location = New System.Drawing.Point(616, 432)
            Me.lblCurrency2.Name = "lblCurrency2"
            Me.lblCurrency2.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency2.TabIndex = 38
            Me.lblCurrency2.Text = "บาท"
            Me.lblCurrency2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblCurrency3
            '
            Me.lblCurrency3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblCurrency3.AutoSize = True
            Me.lblCurrency3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency3.Location = New System.Drawing.Point(616, 456)
            Me.lblCurrency3.Name = "lblCurrency3"
            Me.lblCurrency3.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency3.TabIndex = 39
            Me.lblCurrency3.Text = "บาท"
            Me.lblCurrency3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'MatStockAdjustDetail
            '
            Me.Controls.Add(Me.lblCurrency3)
            Me.Controls.Add(Me.lblCurrency2)
            Me.Controls.Add(Me.lblCurrency1)
            Me.Controls.Add(Me.TextBox4)
            Me.Controls.Add(Me.TextBox3)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.lblItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "MatStockAdjustDetail"
            Me.Size = New System.Drawing.Size(696, 488)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbDetail.ResumeLayout(False)
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
                'Me.m_entity = CType(Value, AROpeningBalance)
                UpdateEntityProperties()
            End Set
        End Property
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockAdjustDetail.lblCode}")
            'Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
            'Me.lblProjectName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockAdjustDetail.lblProjectName}")
            

        End Sub
#End Region


    End Class
End Namespace

