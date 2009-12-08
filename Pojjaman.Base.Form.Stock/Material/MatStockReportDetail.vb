Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MatStockReportDetail
        Inherits AbstractEntityDetailPanelView
     
#Region "  Windows Form Designer generated code "
        Friend WithEvents lblProjectName As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents txtMatendName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnMatendEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnMatendFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblMatend As System.Windows.Forms.Label
        Friend WithEvents txtMatendCode As System.Windows.Forms.TextBox
        Friend WithEvents txtMatstartName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnCCedit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnCCfind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents ibtnMatstartEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnMatstartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCcode As System.Windows.Forms.TextBox
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents txtCCname As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblMatstart As System.Windows.Forms.Label
        Friend WithEvents txtMatstartCode As System.Windows.Forms.TextBox
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnAdjDiff As System.Windows.Forms.Button
        Friend WithEvents txtCreateDate As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtCreateTime As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents chkIsCancel As System.Windows.Forms.CheckBox
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MatStockReportDetail))
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtMatendName = New System.Windows.Forms.TextBox
            Me.txtMatendCode = New System.Windows.Forms.TextBox
            Me.txtMatstartName = New System.Windows.Forms.TextBox
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtCCcode = New System.Windows.Forms.TextBox
            Me.txtCCname = New System.Windows.Forms.TextBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtMatstartCode = New System.Windows.Forms.TextBox
            Me.txtCreateDate = New System.Windows.Forms.TextBox
            Me.txtCreateTime = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.lblItem = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkIsCancel = New System.Windows.Forms.CheckBox
            Me.ibtnMatendEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnMatendFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblMatend = New System.Windows.Forms.Label
            Me.ibtnCCedit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnCCfind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnMatstartEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnMatstartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCC = New System.Windows.Forms.Label
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblMatstart = New System.Windows.Forms.Label
            Me.btnAdjDiff = New System.Windows.Forms.Button
            Me.Label3 = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txtMatendName
            '
            Me.txtMatendName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtMatendName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatendName, "")
            Me.txtMatendName.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtMatendName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMatendName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMatendName, System.Drawing.Color.Empty)
            Me.txtMatendName.Location = New System.Drawing.Point(240, 112)
            Me.Validator.SetMaxValue(Me.txtMatendName, "")
            Me.Validator.SetMinValue(Me.txtMatendName, "")
            Me.txtMatendName.Name = "txtMatendName"
            Me.txtMatendName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMatendName, "")
            Me.Validator.SetRequired(Me.txtMatendName, False)
            Me.txtMatendName.Size = New System.Drawing.Size(240, 21)
            Me.txtMatendName.TabIndex = 19
            Me.txtMatendName.TabStop = False
            Me.txtMatendName.Text = ""
            '
            'txtMatendCode
            '
            Me.txtMatendCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtMatendCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatendCode, "")
            Me.txtMatendCode.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtMatendCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMatendCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMatendCode, System.Drawing.Color.Empty)
            Me.txtMatendCode.Location = New System.Drawing.Point(120, 112)
            Me.Validator.SetMaxValue(Me.txtMatendCode, "")
            Me.Validator.SetMinValue(Me.txtMatendCode, "")
            Me.txtMatendCode.Name = "txtMatendCode"
            Me.txtMatendCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMatendCode, "")
            Me.Validator.SetRequired(Me.txtMatendCode, True)
            Me.txtMatendCode.Size = New System.Drawing.Size(120, 21)
            Me.txtMatendCode.TabIndex = 18
            Me.txtMatendCode.Text = ""
            '
            'txtMatstartName
            '
            Me.txtMatstartName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtMatstartName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatstartName, "")
            Me.txtMatstartName.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtMatstartName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMatstartName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMatstartName, System.Drawing.Color.Empty)
            Me.txtMatstartName.Location = New System.Drawing.Point(240, 88)
            Me.Validator.SetMaxValue(Me.txtMatstartName, "")
            Me.Validator.SetMinValue(Me.txtMatstartName, "")
            Me.txtMatstartName.Name = "txtMatstartName"
            Me.txtMatstartName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMatstartName, "")
            Me.Validator.SetRequired(Me.txtMatstartName, False)
            Me.txtMatstartName.Size = New System.Drawing.Size(240, 21)
            Me.txtMatstartName.TabIndex = 14
            Me.txtMatstartName.TabStop = False
            Me.txtMatstartName.Text = ""
            '
            'txtDocDate
            '
            Me.txtDocDate.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDocDate, "")
            Me.txtDocDate.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.txtDocDate.Location = New System.Drawing.Point(384, 16)
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.txtDocDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(122, 21)
            Me.txtDocDate.TabIndex = 4
            Me.txtDocDate.Text = ""
            '
            'txtCCcode
            '
            Me.txtCCcode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCCcode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCcode, "")
            Me.txtCCcode.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtCCcode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCcode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCcode, System.Drawing.Color.Empty)
            Me.txtCCcode.Location = New System.Drawing.Point(120, 64)
            Me.Validator.SetMaxValue(Me.txtCCcode, "")
            Me.Validator.SetMinValue(Me.txtCCcode, "")
            Me.txtCCcode.Name = "txtCCcode"
            Me.txtCCcode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCCcode, "")
            Me.Validator.SetRequired(Me.txtCCcode, True)
            Me.txtCCcode.Size = New System.Drawing.Size(120, 21)
            Me.txtCCcode.TabIndex = 8
            Me.txtCCcode.Text = ""
            '
            'txtCCname
            '
            Me.txtCCname.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCCname, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCname, "")
            Me.txtCCname.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtCCname, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCname, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCname, System.Drawing.Color.Empty)
            Me.txtCCname.Location = New System.Drawing.Point(240, 64)
            Me.Validator.SetMaxValue(Me.txtCCname, "")
            Me.Validator.SetMinValue(Me.txtCCname, "")
            Me.txtCCname.Name = "txtCCname"
            Me.txtCCname.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCCname, "")
            Me.Validator.SetRequired(Me.txtCCname, False)
            Me.txtCCname.Size = New System.Drawing.Size(240, 21)
            Me.txtCCname.TabIndex = 9
            Me.txtCCname.TabStop = False
            Me.txtCCname.Text = ""
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.ErrorProvider1.SetIconPadding(Me.dtpDocDate, -15)
            Me.dtpDocDate.Location = New System.Drawing.Point(384, 16)
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
            Me.txtCode.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(120, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.txtCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(120, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'txtMatstartCode
            '
            Me.txtMatstartCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtMatstartCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatstartCode, "")
            Me.txtMatstartCode.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtMatstartCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMatstartCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMatstartCode, System.Drawing.Color.Empty)
            Me.txtMatstartCode.Location = New System.Drawing.Point(120, 88)
            Me.Validator.SetMaxValue(Me.txtMatstartCode, "")
            Me.Validator.SetMinValue(Me.txtMatstartCode, "")
            Me.txtMatstartCode.Name = "txtMatstartCode"
            Me.txtMatstartCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMatstartCode, "")
            Me.Validator.SetRequired(Me.txtMatstartCode, True)
            Me.txtMatstartCode.Size = New System.Drawing.Size(120, 21)
            Me.txtMatstartCode.TabIndex = 13
            Me.txtMatstartCode.Text = ""
            '
            'txtCreateDate
            '
            Me.txtCreateDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtCreateDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCreateDate, "")
            Me.txtCreateDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCreateDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreateDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreateDate, System.Drawing.Color.Empty)
            Me.txtCreateDate.Location = New System.Drawing.Point(328, 456)
            Me.Validator.SetMaxValue(Me.txtCreateDate, "")
            Me.Validator.SetMinValue(Me.txtCreateDate, "")
            Me.txtCreateDate.Name = "txtCreateDate"
            Me.txtCreateDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCreateDate, "")
            Me.Validator.SetRequired(Me.txtCreateDate, False)
            Me.txtCreateDate.Size = New System.Drawing.Size(120, 21)
            Me.txtCreateDate.TabIndex = 25
            Me.txtCreateDate.TabStop = False
            Me.txtCreateDate.Text = ""
            '
            'txtCreateTime
            '
            Me.txtCreateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtCreateTime, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCreateTime, "")
            Me.txtCreateTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCreateTime, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreateTime, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreateTime, System.Drawing.Color.Empty)
            Me.txtCreateTime.Location = New System.Drawing.Point(512, 456)
            Me.Validator.SetMaxValue(Me.txtCreateTime, "")
            Me.Validator.SetMinValue(Me.txtCreateTime, "")
            Me.txtCreateTime.Name = "txtCreateTime"
            Me.txtCreateTime.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCreateTime, "")
            Me.Validator.SetRequired(Me.txtCreateTime, False)
            Me.txtCreateTime.Size = New System.Drawing.Size(72, 21)
            Me.txtCreateTime.TabIndex = 27
            Me.txtCreateTime.TabStop = False
            Me.txtCreateTime.Text = ""
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
            Me.lblItem.Location = New System.Drawing.Point(16, 160)
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
            Me.tgItem.Location = New System.Drawing.Point(8, 184)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(680, 264)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 23
            Me.tgItem.TreeManager = Nothing
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.chkIsCancel)
            Me.grbDetail.Controls.Add(Me.txtMatendName)
            Me.grbDetail.Controls.Add(Me.ibtnMatendEdit)
            Me.grbDetail.Controls.Add(Me.ibtnMatendFind)
            Me.grbDetail.Controls.Add(Me.lblMatend)
            Me.grbDetail.Controls.Add(Me.txtMatendCode)
            Me.grbDetail.Controls.Add(Me.txtMatstartName)
            Me.grbDetail.Controls.Add(Me.ibtnCCedit)
            Me.grbDetail.Controls.Add(Me.ibtnCCfind)
            Me.grbDetail.Controls.Add(Me.txtDocDate)
            Me.grbDetail.Controls.Add(Me.ibtnMatstartEdit)
            Me.grbDetail.Controls.Add(Me.ibtnMatstartFind)
            Me.grbDetail.Controls.Add(Me.txtCCcode)
            Me.grbDetail.Controls.Add(Me.lblCC)
            Me.grbDetail.Controls.Add(Me.txtCCname)
            Me.grbDetail.Controls.Add(Me.dtpDocDate)
            Me.grbDetail.Controls.Add(Me.lblDocDate)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblMatstart)
            Me.grbDetail.Controls.Add(Me.txtMatstartCode)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 4)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(672, 144)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'chkIsCancel
            '
            Me.chkIsCancel.Location = New System.Drawing.Point(120, 40)
            Me.chkIsCancel.Name = "chkIsCancel"
            Me.chkIsCancel.Size = New System.Drawing.Size(248, 24)
            Me.chkIsCancel.TabIndex = 6
            Me.chkIsCancel.Text = "ยกเลิกเอกสารผลการตรวจนับ"
            '
            'ibtnMatendEdit
            '
            Me.ibtnMatendEdit.Enabled = False
            Me.ibtnMatendEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnMatendEdit.Image = CType(resources.GetObject("ibtnMatendEdit.Image"), System.Drawing.Image)
            Me.ibtnMatendEdit.Location = New System.Drawing.Point(504, 112)
            Me.ibtnMatendEdit.Name = "ibtnMatendEdit"
            Me.ibtnMatendEdit.Size = New System.Drawing.Size(24, 23)
            Me.ibtnMatendEdit.TabIndex = 21
            Me.ibtnMatendEdit.TabStop = False
            Me.ibtnMatendEdit.ThemedImage = CType(resources.GetObject("ibtnMatendEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnMatendFind
            '
            Me.ibtnMatendFind.Enabled = False
            Me.ibtnMatendFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnMatendFind.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnMatendFind.Image = CType(resources.GetObject("ibtnMatendFind.Image"), System.Drawing.Image)
            Me.ibtnMatendFind.Location = New System.Drawing.Point(480, 112)
            Me.ibtnMatendFind.Name = "ibtnMatendFind"
            Me.ibtnMatendFind.Size = New System.Drawing.Size(24, 23)
            Me.ibtnMatendFind.TabIndex = 20
            Me.ibtnMatendFind.TabStop = False
            Me.ibtnMatendFind.ThemedImage = CType(resources.GetObject("ibtnMatendFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblMatend
            '
            Me.lblMatend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMatend.Location = New System.Drawing.Point(16, 112)
            Me.lblMatend.Name = "lblMatend"
            Me.lblMatend.Size = New System.Drawing.Size(96, 18)
            Me.lblMatend.TabIndex = 17
            Me.lblMatend.Text = "ถึงวัสดุ"
            Me.lblMatend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnCCedit
            '
            Me.ibtnCCedit.Enabled = False
            Me.ibtnCCedit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnCCedit.Image = CType(resources.GetObject("ibtnCCedit.Image"), System.Drawing.Image)
            Me.ibtnCCedit.Location = New System.Drawing.Point(504, 64)
            Me.ibtnCCedit.Name = "ibtnCCedit"
            Me.ibtnCCedit.Size = New System.Drawing.Size(24, 23)
            Me.ibtnCCedit.TabIndex = 11
            Me.ibtnCCedit.TabStop = False
            Me.ibtnCCedit.ThemedImage = CType(resources.GetObject("ibtnCCedit.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnCCfind
            '
            Me.ibtnCCfind.Enabled = False
            Me.ibtnCCfind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnCCfind.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnCCfind.Image = CType(resources.GetObject("ibtnCCfind.Image"), System.Drawing.Image)
            Me.ibtnCCfind.Location = New System.Drawing.Point(480, 64)
            Me.ibtnCCfind.Name = "ibtnCCfind"
            Me.ibtnCCfind.Size = New System.Drawing.Size(24, 23)
            Me.ibtnCCfind.TabIndex = 10
            Me.ibtnCCfind.TabStop = False
            Me.ibtnCCfind.ThemedImage = CType(resources.GetObject("ibtnCCfind.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnMatstartEdit
            '
            Me.ibtnMatstartEdit.Enabled = False
            Me.ibtnMatstartEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnMatstartEdit.Image = CType(resources.GetObject("ibtnMatstartEdit.Image"), System.Drawing.Image)
            Me.ibtnMatstartEdit.Location = New System.Drawing.Point(504, 88)
            Me.ibtnMatstartEdit.Name = "ibtnMatstartEdit"
            Me.ibtnMatstartEdit.Size = New System.Drawing.Size(24, 23)
            Me.ibtnMatstartEdit.TabIndex = 16
            Me.ibtnMatstartEdit.TabStop = False
            Me.ibtnMatstartEdit.ThemedImage = CType(resources.GetObject("ibtnMatstartEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnMatstartFind
            '
            Me.ibtnMatstartFind.Enabled = False
            Me.ibtnMatstartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnMatstartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnMatstartFind.Image = CType(resources.GetObject("ibtnMatstartFind.Image"), System.Drawing.Image)
            Me.ibtnMatstartFind.Location = New System.Drawing.Point(480, 88)
            Me.ibtnMatstartFind.Name = "ibtnMatstartFind"
            Me.ibtnMatstartFind.Size = New System.Drawing.Size(24, 23)
            Me.ibtnMatstartFind.TabIndex = 15
            Me.ibtnMatstartFind.TabStop = False
            Me.ibtnMatstartFind.ThemedImage = CType(resources.GetObject("ibtnMatstartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCC
            '
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.Location = New System.Drawing.Point(48, 64)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(72, 18)
            Me.lblCC.TabIndex = 7
            Me.lblCC.Text = "คลังตรวจนับ:"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(264, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(112, 18)
            Me.lblDocDate.TabIndex = 3
            Me.lblDocDate.Text = "วันที่เอกสาร"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(40, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMatstart
            '
            Me.lblMatstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMatstart.Location = New System.Drawing.Point(16, 88)
            Me.lblMatstart.Name = "lblMatstart"
            Me.lblMatstart.Size = New System.Drawing.Size(96, 18)
            Me.lblMatstart.TabIndex = 12
            Me.lblMatstart.Text = "จากวัสดุ"
            Me.lblMatstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnAdjDiff
            '
            Me.btnAdjDiff.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnAdjDiff.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAdjDiff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAdjDiff.Location = New System.Drawing.Point(600, 456)
            Me.btnAdjDiff.Name = "btnAdjDiff"
            Me.btnAdjDiff.Size = New System.Drawing.Size(88, 23)
            Me.btnAdjDiff.TabIndex = 28
            Me.btnAdjDiff.TabStop = False
            Me.btnAdjDiff.Text = "ปรับปรุงรายการ"
            '
            'Label3
            '
            Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label3.Location = New System.Drawing.Point(456, 456)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(48, 18)
            Me.Label3.TabIndex = 26
            Me.Label3.Text = "เวลา"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label2.Location = New System.Drawing.Point(200, 456)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(120, 18)
            Me.Label2.TabIndex = 24
            Me.Label2.Text = "บันทึกยอด ณ วันที่"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(184, 152)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
            Me.ibtnBlank.TabIndex = 343
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(216, 152)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
            Me.ibtnDelRow.TabIndex = 344
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'MatStockReportDetail
            '
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.txtCreateTime)
            Me.Controls.Add(Me.txtCreateDate)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.btnAdjDiff)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.lblItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "MatStockReportDetail"
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

#Region " SetLabeltext "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

        End Sub
#End Region

#Region " Members "
        Private m_entity As MatStockCount
        Private m_printDocument As PrintDocument
        Private m_printingStringFormat As StringFormat

        Private m_treeManager As TreeManager
        Private m_isInitialized As Boolean = False
        Private m_tableStyleEnable As Hashtable
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = MatStockCount.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            EventWiring()
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Return CreateTableStyle(True)
        End Function
        Public Function CreateTableStyle(ByVal group As Boolean) As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "MatStockCount"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            ' line number
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "matci_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 20
            csLineNumber.Alignment = HorizontalAlignment.Center
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "matci_linenumber"

            ' entity code
            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 80
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf ButtonClicked

            ' entity name
            Dim csName As New TreeTextColumn
            csName.MappingName = "name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.NameHeaderText}")
            csName.NullText = ""
            csName.Width = 250
            csName.Alignment = HorizontalAlignment.Center
            csName.DataAlignment = HorizontalAlignment.Left
            csName.ReadOnly = True
            csName.TextBox.Name = "name"

            ' entity unitname
            Dim csUnitname As New TreeTextColumn
            csUnitname.MappingName = "unitname"
            csUnitname.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.UnitNameHeaderText}")
            csUnitname.NullText = ""
            csUnitname.Width = 50
            csUnitname.Alignment = HorizontalAlignment.Center
            csUnitname.DataAlignment = HorizontalAlignment.Left
            csUnitname.ReadOnly = True
            csUnitname.TextBox.Name = "unitname"

            ' entity balance qty
            Dim csBalanceQty As New TreeTextColumn
            csBalanceQty.MappingName = "matci_balanceqty"
            csBalanceQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.BalanceQtyHeaderText}")
            csBalanceQty.NullText = ""
            csBalanceQty.Width = 80
            csBalanceQty.Alignment = HorizontalAlignment.Center
            csBalanceQty.DataAlignment = HorizontalAlignment.Right
            csBalanceQty.ReadOnly = True
            csBalanceQty.TextBox.Name = "matci_balanceqty"
            csBalanceQty.Format = "#,###.00"

            Dim csAuditQty As New TreeTextColumn
            csAuditQty.MappingName = "matci_auditqty"
            csAuditQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.AuditQtyHeaderText}")
            csAuditQty.NullText = ""
            csAuditQty.Width = 80
            csAuditQty.Alignment = HorizontalAlignment.Center
            csAuditQty.DataAlignment = HorizontalAlignment.Right
            csAuditQty.ReadOnly = False
            csAuditQty.TextBox.Name = "matci_auditqty"
            csAuditQty.Format = "#,###.00"

            Dim csDiffQty As New TreeTextColumn
            csDiffQty.MappingName = "matci_diffqty"
            csDiffQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.DiffQtyHeaderText}")
            csDiffQty.NullText = ""
            csDiffQty.Width = 80
            csDiffQty.Alignment = HorizontalAlignment.Center
            csDiffQty.DataAlignment = HorizontalAlignment.Right
            csDiffQty.ReadOnly = True
            csDiffQty.TextBox.Name = "matci_diffqty"
            csDiffQty.Format = "#,###.00"

            ' Add style            
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csUnitname)
            dst.GridColumnStyles.Add(csBalanceQty)
            dst.GridColumnStyles.Add(csAuditQty)
            dst.GridColumnStyles.Add(csDiffQty)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next

            Return dst
        End Function
        Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 2 Then
                Me.lCIButton_Click(e)
            Else

            End If
        End Sub
#End Region

#Region "ISimpleListPanel"
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

                tgItem.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next
            Else
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = True
                Next

                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next
            End If
        End Sub
        Public Overrides Sub ClearDetail()
            For Each grbCrtl As Control In Me.Controls
                If TypeOf grbCrtl Is FixedGroupBox Then
                    For Each Crtl As Control In Me.Controls
                        If TypeOf Crtl Is TextBox Then
                            Crtl.Text = ""
                        End If
                    Next
                ElseIf TypeOf grbCrtl Is TextBox Then
                    grbCrtl.Text = ""
                End If
            Next
        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler chkIsCancel.CheckedChanged, AddressOf Me.ChangeProperty

        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            If m_entity.AutoGen Then
                txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
            Else
                txtCode.Text = m_entity.Code
            End If
            txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

            If Not Me.m_entity.CostCenter Is Nothing Then
                txtCCcode.Text = Me.m_entity.CostCenter.Code
                txtCCname.Text = Me.m_entity.CostCenter.Name
            End If

            If Not Me.m_entity.StartEntity Is Nothing Then
                txtMatstartCode.Text = Me.m_entity.StartEntity.Code
                txtMatstartName.Text = CType(Me.m_entity.StartEntity, IHasName).Name
            End If

            If Not Me.m_entity.EndEntity Is Nothing Then
                txtMatendCode.Text = Me.m_entity.EndEntity.Code
                txtMatendName.Text = CType(Me.m_entity.EndEntity, IHasName).Name
            End If

            chkIsCancel.Checked = Me.m_entity.Canceled

            txtCreateDate.Text = MinDateToNull(Me.m_entity.ProcessTime, "")
            txtCreateTime.Text = Me.m_entity.ProcessTime.ToShortTimeString

            'Hack
            Me.WorkbenchWindow.ViewContent.IsDirty = False

            'Load Items**********************************************************
            Me.m_treeManager.Treetable = Me.m_entity.ItemTable
            AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
            Me.Validator.DataTable = m_treeManager.Treetable
            '********************************************************************

            RefreshBlankGrid()

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If e.Name = "ItemChanged" Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "chkiscancel"
                    dirtyFlag = True
                    If chkIsCancel.Checked Then
                        Me.m_entity.Canceled = True
                    Else
                        Me.m_entity.Canceled = False
                    End If
                Case Else
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Overrides Sub Initialize()

        End Sub
        Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)
                If Not m_entity Is Nothing Then
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, MatStockCount)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property
#End Region

#Region " Overrides "
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New MatStockCount).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub lCIButton_Click(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIItems)
        End Sub
        Private Sub SetLCIItem(ByVal lci As ISimpleEntity)
            Me.m_treeManager.SelectedRow("Code") = lci.Code
        End Sub
        Private Sub SetLCIItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            Me.m_entity.IsInitialized = True

            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim newItem As New LCIItem(item.Id)
                If newItem.Level = 5 Then
                    Dim oItem As New MatStockCountItem
                    oItem.MatStockCount = Me.m_entity
                    oItem.Entity = newItem
                    oItem.Unit = newItem.DefaultUnit
                    oItem.EntityType = newItem.EntityId
                    oItem.BalanceQty = 0
                    oItem.AuditQty = 0
                    oItem.DiffQty = 0

                    If i = items.Count - 1 Then
                        If Me.m_entity.ItemTable.Childs.Count = 0 Then
                            Me.m_entity.Add(oItem)
                        Else
                            oItem.LineNumber = CInt(Me.m_entity.ItemTable.Childs(index)("matci_linenumber"))
                            oItem.MatStockCount = Me.m_entity
                            oItem.CopyToDataRow(Me.m_entity.ItemTable.Childs(index))
                        End If
                    Else
                        Me.m_entity.Insert(index, oItem)
                    End If
                    Me.m_entity.ItemTable.AcceptChanges()
                End If
            Next
            tgItem.CurrentRowIndex = index
            Me.m_entity.IsInitialized = False
            RefreshBlankGrid()
        End Sub
        Public Sub UnitClicked(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filters(0) As Filter
            Dim item As New MatWithdrawItem
            'item.CopyFromDataRow(Me.m_treeManager.SelectedRow)
            Dim includeFilter As Boolean = False
            If TypeOf item.Entity Is LCIItem Then
                Dim idList As String = CType(item.Entity, LCIItem).GetUnitIdList
                If idList.Length > 0 Then
                    filters(0) = New Filter("includedId", idList)
                    includeFilter = True
                End If
            End If
            If includeFilter Then
                myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
            Else
                myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
            End If
        End Sub
        Private Sub SetUnit(ByVal unit As ISimpleEntity)
            Me.m_treeManager.SelectedRow("Unit") = unit.Code
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim newItem As New BlankItem("")
            Dim myItem As New MatStockCountItem
            myItem.Entity = newItem
            myItem.BalanceQty = 0
            Me.m_entity.Insert(index, myItem)
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Me.m_entity.Remove(index)
            Me.tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub

#End Region

#Region "Grid Resizing"
        Private Sub tgItem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.Resize
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

            Do Until Me.m_entity.ItemTable.Rows.Count > tgItem.VisibleRowCount
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

