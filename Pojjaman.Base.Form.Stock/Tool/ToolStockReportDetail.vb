Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ToolStockReportDetail
        Inherits AbstractEntityDetailPanelView

#Region "  Windows Form Designer generated code "
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ibtnCCedit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnCCfind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents txtCCcode As System.Windows.Forms.TextBox
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents txtCCname As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtCreateDate As System.Windows.Forms.TextBox
        Friend WithEvents txtCreateTime As System.Windows.Forms.TextBox
        Friend WithEvents chkIsCancel As System.Windows.Forms.CheckBox
        Friend WithEvents lblTime As System.Windows.Forms.Label
        Friend WithEvents lblProcessDate As System.Windows.Forms.Label
        Friend WithEvents ibtnAdjDiff As System.Windows.Forms.Button
        Friend WithEvents txtToolendName As System.Windows.Forms.TextBox
        Friend WithEvents txtToolendCode As System.Windows.Forms.TextBox
        Friend WithEvents txtToolstartName As System.Windows.Forms.TextBox
        Friend WithEvents txtToolstartCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnToolendEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnToolendFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblToolend As System.Windows.Forms.Label
        Friend WithEvents ibtnToolstartEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnToolstartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblToolstart As System.Windows.Forms.Label
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ToolStockReportDetail))
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtToolendName = New System.Windows.Forms.TextBox
            Me.txtToolendCode = New System.Windows.Forms.TextBox
            Me.txtToolstartName = New System.Windows.Forms.TextBox
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtCCcode = New System.Windows.Forms.TextBox
            Me.txtCCname = New System.Windows.Forms.TextBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtToolstartCode = New System.Windows.Forms.TextBox
            Me.txtCreateDate = New System.Windows.Forms.TextBox
            Me.txtCreateTime = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.lblItem = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkIsCancel = New System.Windows.Forms.CheckBox
            Me.ibtnToolendEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnToolendFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblToolend = New System.Windows.Forms.Label
            Me.ibtnCCedit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnCCfind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnToolstartEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnToolstartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCC = New System.Windows.Forms.Label
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblToolstart = New System.Windows.Forms.Label
            Me.ibtnAdjDiff = New System.Windows.Forms.Button
            Me.lblTime = New System.Windows.Forms.Label
            Me.lblProcessDate = New System.Windows.Forms.Label
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
            'txtToolendName
            '
            Me.txtToolendName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtToolendName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToolendName, "")
            Me.txtToolendName.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtToolendName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtToolendName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtToolendName, System.Drawing.Color.Empty)
            Me.txtToolendName.Location = New System.Drawing.Point(240, 112)
            Me.txtToolendName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtToolendName, "")
            Me.Validator.SetMinValue(Me.txtToolendName, "")
            Me.txtToolendName.Name = "txtToolendName"
            Me.txtToolendName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtToolendName, "")
            Me.Validator.SetRequired(Me.txtToolendName, False)
            Me.txtToolendName.Size = New System.Drawing.Size(240, 21)
            Me.txtToolendName.TabIndex = 18
            Me.txtToolendName.TabStop = False
            Me.txtToolendName.Text = ""
            '
            'txtToolendCode
            '
            Me.txtToolendCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtToolendCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToolendCode, "")
            Me.txtToolendCode.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtToolendCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtToolendCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtToolendCode, System.Drawing.Color.Empty)
            Me.txtToolendCode.Location = New System.Drawing.Point(120, 112)
            Me.txtToolendCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtToolendCode, "")
            Me.Validator.SetMinValue(Me.txtToolendCode, "")
            Me.txtToolendCode.Name = "txtToolendCode"
            Me.Validator.SetRegularExpression(Me.txtToolendCode, "")
            Me.Validator.SetRequired(Me.txtToolendCode, True)
            Me.txtToolendCode.Size = New System.Drawing.Size(120, 21)
            Me.txtToolendCode.TabIndex = 17
            Me.txtToolendCode.Text = ""
            '
            'txtToolstartName
            '
            Me.txtToolstartName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtToolstartName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToolstartName, "")
            Me.txtToolstartName.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtToolstartName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtToolstartName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtToolstartName, System.Drawing.Color.Empty)
            Me.txtToolstartName.Location = New System.Drawing.Point(240, 88)
            Me.txtToolstartName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtToolstartName, "")
            Me.Validator.SetMinValue(Me.txtToolstartName, "")
            Me.txtToolstartName.Name = "txtToolstartName"
            Me.txtToolstartName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtToolstartName, "")
            Me.Validator.SetRequired(Me.txtToolstartName, False)
            Me.txtToolstartName.Size = New System.Drawing.Size(240, 21)
            Me.txtToolstartName.TabIndex = 13
            Me.txtToolstartName.TabStop = False
            Me.txtToolstartName.Text = ""
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
            Me.txtDocDate.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(124, 21)
            Me.txtDocDate.TabIndex = 3
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
            Me.txtCCcode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCCcode, "")
            Me.Validator.SetMinValue(Me.txtCCcode, "")
            Me.txtCCcode.Name = "txtCCcode"
            Me.Validator.SetRegularExpression(Me.txtCCcode, "")
            Me.Validator.SetRequired(Me.txtCCcode, True)
            Me.txtCCcode.Size = New System.Drawing.Size(120, 21)
            Me.txtCCcode.TabIndex = 7
            Me.txtCCcode.Text = ""
            '
            'txtCCname
            '
            Me.txtCCname.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtCCname, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCname, "")
            Me.txtCCname.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtCCname, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCname, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCname, System.Drawing.Color.Empty)
            Me.txtCCname.Location = New System.Drawing.Point(240, 64)
            Me.txtCCname.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtCCname, "")
            Me.Validator.SetMinValue(Me.txtCCname, "")
            Me.txtCCname.Name = "txtCCname"
            Me.txtCCname.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCCname, "")
            Me.Validator.SetRequired(Me.txtCCname, False)
            Me.txtCCname.Size = New System.Drawing.Size(240, 21)
            Me.txtCCname.TabIndex = 8
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
            Me.dtpDocDate.TabIndex = 4
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
            Me.txtCode.MaxLength = 25
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(120, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'txtToolstartCode
            '
            Me.txtToolstartCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtToolstartCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToolstartCode, "")
            Me.txtToolstartCode.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtToolstartCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtToolstartCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtToolstartCode, System.Drawing.Color.Empty)
            Me.txtToolstartCode.Location = New System.Drawing.Point(120, 88)
            Me.txtToolstartCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtToolstartCode, "")
            Me.Validator.SetMinValue(Me.txtToolstartCode, "")
            Me.txtToolstartCode.Name = "txtToolstartCode"
            Me.Validator.SetRegularExpression(Me.txtToolstartCode, "")
            Me.Validator.SetRequired(Me.txtToolstartCode, True)
            Me.txtToolstartCode.Size = New System.Drawing.Size(120, 21)
            Me.txtToolstartCode.TabIndex = 12
            Me.txtToolstartCode.Text = ""
            '
            'txtCreateDate
            '
            Me.txtCreateDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtCreateDate.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtCreateDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCreateDate, "")
            Me.txtCreateDate.Enabled = False
            Me.txtCreateDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCreateDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreateDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreateDate, System.Drawing.Color.Empty)
            Me.txtCreateDate.Location = New System.Drawing.Point(328, 456)
            Me.txtCreateDate.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtCreateDate, "")
            Me.Validator.SetMinValue(Me.txtCreateDate, "")
            Me.txtCreateDate.Name = "txtCreateDate"
            Me.txtCreateDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCreateDate, "")
            Me.Validator.SetRequired(Me.txtCreateDate, False)
            Me.txtCreateDate.Size = New System.Drawing.Size(120, 21)
            Me.txtCreateDate.TabIndex = 4
            Me.txtCreateDate.TabStop = False
            Me.txtCreateDate.Text = ""
            Me.txtCreateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtCreateTime
            '
            Me.txtCreateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtCreateTime.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtCreateTime, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCreateTime, "")
            Me.txtCreateTime.Enabled = False
            Me.txtCreateTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCreateTime, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreateTime, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreateTime, System.Drawing.Color.Empty)
            Me.txtCreateTime.Location = New System.Drawing.Point(512, 456)
            Me.txtCreateTime.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtCreateTime, "")
            Me.Validator.SetMinValue(Me.txtCreateTime, "")
            Me.txtCreateTime.Name = "txtCreateTime"
            Me.txtCreateTime.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCreateTime, "")
            Me.Validator.SetRequired(Me.txtCreateTime, False)
            Me.txtCreateTime.Size = New System.Drawing.Size(72, 21)
            Me.txtCreateTime.TabIndex = 6
            Me.txtCreateTime.TabStop = False
            Me.txtCreateTime.Text = ""
            Me.txtCreateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
            Me.lblItem.TabIndex = 1
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
            Me.tgItem.TabIndex = 2
            Me.tgItem.TreeManager = Nothing
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.chkIsCancel)
            Me.grbDetail.Controls.Add(Me.txtToolendName)
            Me.grbDetail.Controls.Add(Me.ibtnToolendEdit)
            Me.grbDetail.Controls.Add(Me.ibtnToolendFind)
            Me.grbDetail.Controls.Add(Me.lblToolend)
            Me.grbDetail.Controls.Add(Me.txtToolendCode)
            Me.grbDetail.Controls.Add(Me.txtToolstartName)
            Me.grbDetail.Controls.Add(Me.ibtnCCedit)
            Me.grbDetail.Controls.Add(Me.ibtnCCfind)
            Me.grbDetail.Controls.Add(Me.txtDocDate)
            Me.grbDetail.Controls.Add(Me.ibtnToolstartEdit)
            Me.grbDetail.Controls.Add(Me.ibtnToolstartFind)
            Me.grbDetail.Controls.Add(Me.txtCCcode)
            Me.grbDetail.Controls.Add(Me.lblCC)
            Me.grbDetail.Controls.Add(Me.txtCCname)
            Me.grbDetail.Controls.Add(Me.dtpDocDate)
            Me.grbDetail.Controls.Add(Me.lblDocDate)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblToolstart)
            Me.grbDetail.Controls.Add(Me.txtToolstartCode)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
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
            Me.chkIsCancel.TabIndex = 5
            Me.chkIsCancel.Text = "ยกเลิกเอกสารผลการตรวจนับ"
            '
            'ibtnToolendEdit
            '
            Me.ibtnToolendEdit.Enabled = False
            Me.ibtnToolendEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnToolendEdit.Image = CType(resources.GetObject("ibtnToolendEdit.Image"), System.Drawing.Image)
            Me.ibtnToolendEdit.Location = New System.Drawing.Point(504, 112)
            Me.ibtnToolendEdit.Name = "ibtnToolendEdit"
            Me.ibtnToolendEdit.Size = New System.Drawing.Size(24, 23)
            Me.ibtnToolendEdit.TabIndex = 20
            Me.ibtnToolendEdit.TabStop = False
            Me.ibtnToolendEdit.ThemedImage = CType(resources.GetObject("ibtnToolendEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnToolendFind
            '
            Me.ibtnToolendFind.Enabled = False
            Me.ibtnToolendFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnToolendFind.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnToolendFind.Image = CType(resources.GetObject("ibtnToolendFind.Image"), System.Drawing.Image)
            Me.ibtnToolendFind.Location = New System.Drawing.Point(480, 112)
            Me.ibtnToolendFind.Name = "ibtnToolendFind"
            Me.ibtnToolendFind.Size = New System.Drawing.Size(24, 23)
            Me.ibtnToolendFind.TabIndex = 19
            Me.ibtnToolendFind.TabStop = False
            Me.ibtnToolendFind.ThemedImage = CType(resources.GetObject("ibtnToolendFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblToolend
            '
            Me.lblToolend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToolend.Location = New System.Drawing.Point(8, 112)
            Me.lblToolend.Name = "lblToolend"
            Me.lblToolend.Size = New System.Drawing.Size(104, 18)
            Me.lblToolend.TabIndex = 16
            Me.lblToolend.Text = "ถึงวัสดุ"
            Me.lblToolend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnCCedit
            '
            Me.ibtnCCedit.Enabled = False
            Me.ibtnCCedit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnCCedit.Image = CType(resources.GetObject("ibtnCCedit.Image"), System.Drawing.Image)
            Me.ibtnCCedit.Location = New System.Drawing.Point(504, 64)
            Me.ibtnCCedit.Name = "ibtnCCedit"
            Me.ibtnCCedit.Size = New System.Drawing.Size(24, 23)
            Me.ibtnCCedit.TabIndex = 10
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
            Me.ibtnCCfind.TabIndex = 9
            Me.ibtnCCfind.TabStop = False
            Me.ibtnCCfind.ThemedImage = CType(resources.GetObject("ibtnCCfind.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnToolstartEdit
            '
            Me.ibtnToolstartEdit.Enabled = False
            Me.ibtnToolstartEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnToolstartEdit.Image = CType(resources.GetObject("ibtnToolstartEdit.Image"), System.Drawing.Image)
            Me.ibtnToolstartEdit.Location = New System.Drawing.Point(504, 88)
            Me.ibtnToolstartEdit.Name = "ibtnToolstartEdit"
            Me.ibtnToolstartEdit.Size = New System.Drawing.Size(24, 23)
            Me.ibtnToolstartEdit.TabIndex = 15
            Me.ibtnToolstartEdit.TabStop = False
            Me.ibtnToolstartEdit.ThemedImage = CType(resources.GetObject("ibtnToolstartEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnToolstartFind
            '
            Me.ibtnToolstartFind.Enabled = False
            Me.ibtnToolstartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnToolstartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnToolstartFind.Image = CType(resources.GetObject("ibtnToolstartFind.Image"), System.Drawing.Image)
            Me.ibtnToolstartFind.Location = New System.Drawing.Point(480, 88)
            Me.ibtnToolstartFind.Name = "ibtnToolstartFind"
            Me.ibtnToolstartFind.Size = New System.Drawing.Size(24, 23)
            Me.ibtnToolstartFind.TabIndex = 14
            Me.ibtnToolstartFind.TabStop = False
            Me.ibtnToolstartFind.ThemedImage = CType(resources.GetObject("ibtnToolstartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCC
            '
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.Location = New System.Drawing.Point(8, 64)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(104, 18)
            Me.lblCC.TabIndex = 6
            Me.lblCC.Text = "คลังตรวจนับ:"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(264, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(112, 18)
            Me.lblDocDate.TabIndex = 2
            Me.lblDocDate.Text = "วันที่เอกสาร"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblToolstart
            '
            Me.lblToolstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToolstart.Location = New System.Drawing.Point(8, 88)
            Me.lblToolstart.Name = "lblToolstart"
            Me.lblToolstart.Size = New System.Drawing.Size(104, 18)
            Me.lblToolstart.TabIndex = 11
            Me.lblToolstart.Text = "จากวัสดุ"
            Me.lblToolstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnAdjDiff
            '
            Me.ibtnAdjDiff.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnAdjDiff.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnAdjDiff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnAdjDiff.Location = New System.Drawing.Point(600, 456)
            Me.ibtnAdjDiff.Name = "ibtnAdjDiff"
            Me.ibtnAdjDiff.Size = New System.Drawing.Size(88, 23)
            Me.ibtnAdjDiff.TabIndex = 7
            Me.ibtnAdjDiff.TabStop = False
            Me.ibtnAdjDiff.Text = "ปรับปรุงรายการ"
            '
            'lblTime
            '
            Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTime.Location = New System.Drawing.Point(456, 456)
            Me.lblTime.Name = "lblTime"
            Me.lblTime.Size = New System.Drawing.Size(48, 18)
            Me.lblTime.TabIndex = 5
            Me.lblTime.Text = "เวลา"
            Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblProcessDate
            '
            Me.lblProcessDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblProcessDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProcessDate.Location = New System.Drawing.Point(200, 456)
            Me.lblProcessDate.Name = "lblProcessDate"
            Me.lblProcessDate.Size = New System.Drawing.Size(120, 18)
            Me.lblProcessDate.TabIndex = 3
            Me.lblProcessDate.Text = "บันทึกยอด ณ วันที่"
            Me.lblProcessDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(184, 152)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
            Me.ibtnBlank.TabIndex = 22
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(216, 152)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
            Me.ibtnDelRow.TabIndex = 23
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'ToolStockReportDetail
            '
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.txtCreateTime)
            Me.Controls.Add(Me.txtCreateDate)
            Me.Controls.Add(Me.lblTime)
            Me.Controls.Add(Me.ibtnAdjDiff)
            Me.Controls.Add(Me.lblProcessDate)
            Me.Controls.Add(Me.lblItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "ToolStockReportDetail"
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
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.lblDocDate}")
            Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

            Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.lblCC}")
            Me.Validator.SetDisplayName(txtCCcode, lblCC.Text)

            Me.lblToolend.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.lblToolend}")
            Me.Validator.SetDisplayName(txtToolendCode, lblToolend.Text)

            Me.lblToolstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.lblToolstart}")
            Me.Validator.SetDisplayName(txtToolstartCode, lblToolstart.Text)

            Me.lblProcessDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.lblProcessDate}")
            Me.lblTime.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.lblTime}")

            Me.ibtnAdjDiff.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.ibtnAdjDiff}")

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.lblItem}")
            Me.chkIsCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.chkIsCancel}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.grbDetail}")
        End Sub
#End Region

#Region " Members "
        Private m_entity As ToolStockCount
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

            Dim dt As TreeTable = ToolStockCount.GetSchemaTable()
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
            dst.MappingName = "ToolStockCount"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            ' line number
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "toolci_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 20
            csLineNumber.Alignment = HorizontalAlignment.Center
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "toolci_linenumber"

            ' entity code
            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 80
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csToolButton As New DataGridButtonColumn
            csToolButton.MappingName = "Button"
            csToolButton.HeaderText = ""
            csToolButton.NullText = ""
            AddHandler csToolButton.Click, AddressOf ButtonClicked

            ' entity name
            Dim csName As New TreeTextColumn
            csName.MappingName = "name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Width = 250
            csName.Alignment = HorizontalAlignment.Center
            csName.DataAlignment = HorizontalAlignment.Left
            csName.ReadOnly = True
            csName.TextBox.Name = "name"

            ' entity unitname
            Dim csUnitname As New TreeTextColumn
            csUnitname.MappingName = "unitname"
            csUnitname.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.UnitNameHeaderText}")
            csUnitname.NullText = ""
            csUnitname.Width = 50
            csUnitname.Alignment = HorizontalAlignment.Center
            csUnitname.DataAlignment = HorizontalAlignment.Left
            csUnitname.ReadOnly = True
            csUnitname.TextBox.Name = "unitname"

            ' entity balance qty
            Dim csBalanceQty As New TreeTextColumn
            csBalanceQty.MappingName = "toolci_balanceqty"
            csBalanceQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.BalanceQtyHeaderText}")
            csBalanceQty.NullText = ""
            csBalanceQty.Width = 80
            csBalanceQty.Alignment = HorizontalAlignment.Center
            csBalanceQty.DataAlignment = HorizontalAlignment.Right
            csBalanceQty.ReadOnly = True
            csBalanceQty.TextBox.Name = "toolci_balanceqty"
            csBalanceQty.Format = "#,###.00"

            Dim csAuditQty As New TreeTextColumn
            csAuditQty.MappingName = "toolci_auditqty"
            csAuditQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.AuditQtyHeaderText}")
            csAuditQty.NullText = ""
            csAuditQty.Width = 80
            csAuditQty.Alignment = HorizontalAlignment.Center
            csAuditQty.DataAlignment = HorizontalAlignment.Right
            csAuditQty.ReadOnly = False
            csAuditQty.TextBox.Name = "toolci_auditqty"
            csAuditQty.Format = "#,###.00"

            Dim csDiffQty As New TreeTextColumn
            csDiffQty.MappingName = "toolci_diffqty"
            csDiffQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolStockReportDetail.DiffQtyHeaderText}")
            csDiffQty.NullText = ""
            csDiffQty.Width = 80
            csDiffQty.Alignment = HorizontalAlignment.Center
            csDiffQty.DataAlignment = HorizontalAlignment.Right
            csDiffQty.ReadOnly = True
            csDiffQty.TextBox.Name = "toolci_diffqty"
            csDiffQty.Format = "#,###.00"

            ' Add style            
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csToolButton)
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
                Me.ToolButton_Click(e)
            Else

            End If
        End Sub
#End Region

#Region "ISimpleListPanel"
        Public Overrides Sub CheckFormEnable()

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
                txtToolstartCode.Text = Me.m_entity.StartEntity.Code
                txtToolstartName.Text = CType(Me.m_entity.StartEntity, IHasName).Name
            End If

            If Not Me.m_entity.EndEntity Is Nothing Then
                txtToolendCode.Text = Me.m_entity.EndEntity.Code
                txtToolendName.Text = CType(Me.m_entity.EndEntity, IHasName).Name
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
                Me.m_entity = CType(Value, ToolStockCount)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property
#End Region

#Region " Overrides "
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New ToolStockCount).DetailPanelIcon
            End Get
        End Property
#End Region

#Region " Event Handler "
        Private Function GetIDListed() As String
            Dim codelist As String
            For Each row As TreeRow In Me.m_entity.ItemTable.Childs
                If Me.m_entity.ValidateRow(row) Then
                    codelist += "|" & CStr(row("Code")) & "|"
                End If
            Next
            Return codelist
        End Function
        Public Sub ToolButton_Click(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entities As ISimpleEntity
            entities = New Tool
            Dim filters(0) As Filter
            filters(0) = New Filter("CodeListed", GetIDListed)
            myEntityPanelService.OpenListDialog(entities, AddressOf SetEntityItems, filters)
        End Sub
        Private Sub SetEntityItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            Me.m_entity.IsInitialized = True
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim newItem As Tool
                Dim oItem As New ToolStockCountItem

                newItem = New Tool(item.Id)
                oItem.ToolStockCount = Me.m_entity
                oItem.Entity = newItem
                oItem.Unit = newItem.Unit
                oItem.EntityType = newItem.EntityId
                oItem.BalanceQty = 0
                If i = items.Count - 1 Then
                    If Me.m_entity.ItemTable.Childs.Count = 0 Then
                        Me.m_entity.Add(oItem)
                    Else
                        oItem.LineNumber = CInt(Me.m_entity.ItemTable.Childs(index)("toolci_linenumber"))
                        oItem.ToolStockCount = Me.m_entity
                        oItem.CopyToDataRow(Me.m_entity.ItemTable.Childs(index))
                    End If
                Else
                    Me.m_entity.Insert(index, oItem)
                End If
                Me.m_entity.ItemTable.AcceptChanges()
            Next
            tgItem.CurrentRowIndex = index
            Me.m_entity.IsInitialized = False
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

#Region "Rows Manager Button"
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.MaxRowIndex Then
                Return
            End If
            Dim newItem As New BlankItem("")
            Dim item As New ToolStockCountItem
            item.Entity = newItem
            item.BalanceQty = 0
            Me.m_entity.Insert(index, item)
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            If index > Me.m_entity.MaxRowIndex Then
                Return
            End If
            Me.m_entity.Remove(index)
            Me.tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub

#End Region
    End Class
End Namespace

