Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MatStockCountDetailView
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region "  Windows Form Designer generated code "
        Friend WithEvents lblProjectName As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtCreateDate As System.Windows.Forms.TextBox
        Friend WithEvents txtCreateTime As System.Windows.Forms.TextBox
        Friend WithEvents txtMatendName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnMatendEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnMatendFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblMatend As System.Windows.Forms.Label
        Friend WithEvents txtMatendCode As System.Windows.Forms.TextBox
        Friend WithEvents txtMatstartName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnCCedit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnCCfind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
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
        Friend WithEvents ibtnProcess As System.Windows.Forms.Button
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblProcessDate As System.Windows.Forms.Label
        Friend WithEvents lblProcessTime As System.Windows.Forms.Label
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MatStockCountDetailView))
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtCreateDate = New System.Windows.Forms.TextBox
            Me.txtCreateTime = New System.Windows.Forms.TextBox
            Me.txtMatendName = New System.Windows.Forms.TextBox
            Me.txtMatendCode = New System.Windows.Forms.TextBox
            Me.txtMatstartName = New System.Windows.Forms.TextBox
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtCCcode = New System.Windows.Forms.TextBox
            Me.txtCCname = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtMatstartCode = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.lblProcessDate = New System.Windows.Forms.Label
            Me.lblProcessTime = New System.Windows.Forms.Label
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnProcess = New System.Windows.Forms.Button
            Me.ibtnMatendEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnMatendFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblMatend = New System.Windows.Forms.Label
            Me.ibtnCCedit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnCCfind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.ibtnMatstartEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnMatstartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCC = New System.Windows.Forms.Label
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblMatstart = New System.Windows.Forms.Label
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
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
            Me.tgItem.Location = New System.Drawing.Point(0, 160)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(680, 264)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 164
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 136)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(112, 18)
            Me.lblItem.TabIndex = 163
            Me.lblItem.Text = "รายการตรวจนับ:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            'txtCreateDate
            '
            Me.txtCreateDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtCreateDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtCreateDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCreateDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreateDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreateDate, System.Drawing.Color.Empty)
            Me.txtCreateDate.Location = New System.Drawing.Point(416, 432)
            Me.Validator.SetMaxValue(Me.txtCreateDate, "")
            Me.Validator.SetMinValue(Me.txtCreateDate, "")
            Me.txtCreateDate.Name = "txtCreateDate"
            Me.txtCreateDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCreateDate, "")
            Me.Validator.SetRequired(Me.txtCreateDate, False)
            Me.txtCreateDate.Size = New System.Drawing.Size(120, 21)
            Me.txtCreateDate.TabIndex = 337
            Me.txtCreateDate.Text = ""
            '
            'txtCreateTime
            '
            Me.txtCreateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtCreateTime, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtCreateTime, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCreateTime, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreateTime, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreateTime, System.Drawing.Color.Empty)
            Me.txtCreateTime.Location = New System.Drawing.Point(600, 432)
            Me.Validator.SetMaxValue(Me.txtCreateTime, "")
            Me.Validator.SetMinValue(Me.txtCreateTime, "")
            Me.txtCreateTime.Name = "txtCreateTime"
            Me.txtCreateTime.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCreateTime, "")
            Me.Validator.SetRequired(Me.txtCreateTime, False)
            Me.txtCreateTime.Size = New System.Drawing.Size(72, 21)
            Me.txtCreateTime.TabIndex = 339
            Me.txtCreateTime.Text = ""
            '
            'txtMatendName
            '
            Me.txtMatendName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtMatendName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatendName, "")
            Me.txtMatendName.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtMatendName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMatendName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMatendName, System.Drawing.Color.Empty)
            Me.txtMatendName.Location = New System.Drawing.Point(240, 88)
            Me.Validator.SetMaxValue(Me.txtMatendName, "")
            Me.Validator.SetMinValue(Me.txtMatendName, "")
            Me.txtMatendName.Name = "txtMatendName"
            Me.txtMatendName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMatendName, "")
            Me.Validator.SetRequired(Me.txtMatendName, False)
            Me.txtMatendName.Size = New System.Drawing.Size(240, 21)
            Me.txtMatendName.TabIndex = 356
            Me.txtMatendName.TabStop = False
            Me.txtMatendName.Text = ""
            '
            'txtMatendCode
            '
            Me.txtMatendCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtMatendCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatendCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtMatendCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMatendCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMatendCode, System.Drawing.Color.Empty)
            Me.txtMatendCode.Location = New System.Drawing.Point(120, 88)
            Me.Validator.SetMaxValue(Me.txtMatendCode, "")
            Me.Validator.SetMinValue(Me.txtMatendCode, "")
            Me.txtMatendCode.Name = "txtMatendCode"
            Me.Validator.SetRegularExpression(Me.txtMatendCode, "")
            Me.Validator.SetRequired(Me.txtMatendCode, False)
            Me.txtMatendCode.Size = New System.Drawing.Size(120, 21)
            Me.txtMatendCode.TabIndex = 352
            Me.txtMatendCode.Text = ""
            '
            'txtMatstartName
            '
            Me.txtMatstartName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtMatstartName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatstartName, "")
            Me.txtMatstartName.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtMatstartName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMatstartName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMatstartName, System.Drawing.Color.Empty)
            Me.txtMatstartName.Location = New System.Drawing.Point(240, 64)
            Me.Validator.SetMaxValue(Me.txtMatstartName, "")
            Me.Validator.SetMinValue(Me.txtMatstartName, "")
            Me.txtMatstartName.Name = "txtMatstartName"
            Me.txtMatstartName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMatstartName, "")
            Me.Validator.SetRequired(Me.txtMatstartName, False)
            Me.txtMatstartName.Size = New System.Drawing.Size(240, 21)
            Me.txtMatstartName.TabIndex = 351
            Me.txtMatstartName.TabStop = False
            Me.txtMatstartName.Text = ""
            '
            'txtDocDate
            '
            Me.txtDocDate.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.txtDocDate.Location = New System.Drawing.Point(384, 16)
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(123, 21)
            Me.txtDocDate.TabIndex = 348
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
            Me.txtCCcode.Location = New System.Drawing.Point(120, 40)
            Me.Validator.SetMaxValue(Me.txtCCcode, "")
            Me.Validator.SetMinValue(Me.txtCCcode, "")
            Me.txtCCcode.Name = "txtCCcode"
            Me.Validator.SetRegularExpression(Me.txtCCcode, "")
            Me.Validator.SetRequired(Me.txtCCcode, True)
            Me.txtCCcode.Size = New System.Drawing.Size(120, 21)
            Me.txtCCcode.TabIndex = 344
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
            Me.txtCCname.Location = New System.Drawing.Point(240, 40)
            Me.Validator.SetMaxValue(Me.txtCCname, "")
            Me.Validator.SetMinValue(Me.txtCCname, "")
            Me.txtCCname.Name = "txtCCname"
            Me.txtCCname.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCCname, "")
            Me.Validator.SetRequired(Me.txtCCname, False)
            Me.txtCCname.Size = New System.Drawing.Size(240, 21)
            Me.txtCCname.TabIndex = 343
            Me.txtCCname.TabStop = False
            Me.txtCCname.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(120, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(120, 21)
            Me.txtCode.TabIndex = 336
            Me.txtCode.Text = ""
            '
            'txtMatstartCode
            '
            Me.txtMatstartCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtMatstartCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMatstartCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtMatstartCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMatstartCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMatstartCode, System.Drawing.Color.Empty)
            Me.txtMatstartCode.Location = New System.Drawing.Point(120, 64)
            Me.Validator.SetMaxValue(Me.txtMatstartCode, "")
            Me.Validator.SetMinValue(Me.txtMatstartCode, "")
            Me.txtMatstartCode.Name = "txtMatstartCode"
            Me.Validator.SetRegularExpression(Me.txtMatstartCode, "")
            Me.Validator.SetRequired(Me.txtMatstartCode, False)
            Me.txtMatstartCode.Size = New System.Drawing.Size(120, 21)
            Me.txtMatstartCode.TabIndex = 337
            Me.txtMatstartCode.Text = ""
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'lblProcessDate
            '
            Me.lblProcessDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblProcessDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProcessDate.Location = New System.Drawing.Point(288, 432)
            Me.lblProcessDate.Name = "lblProcessDate"
            Me.lblProcessDate.Size = New System.Drawing.Size(120, 18)
            Me.lblProcessDate.TabIndex = 336
            Me.lblProcessDate.Text = "บันทึกยอด ณ วันที่"
            Me.lblProcessDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProcessTime
            '
            Me.lblProcessTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblProcessTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProcessTime.Location = New System.Drawing.Point(544, 432)
            Me.lblProcessTime.Name = "lblProcessTime"
            Me.lblProcessTime.Size = New System.Drawing.Size(48, 18)
            Me.lblProcessTime.TabIndex = 338
            Me.lblProcessTime.Text = "เวลา"
            Me.lblProcessTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.ibtnProcess)
            Me.grbDetail.Controls.Add(Me.txtMatendName)
            Me.grbDetail.Controls.Add(Me.ibtnMatendEdit)
            Me.grbDetail.Controls.Add(Me.ibtnMatendFind)
            Me.grbDetail.Controls.Add(Me.lblMatend)
            Me.grbDetail.Controls.Add(Me.txtMatendCode)
            Me.grbDetail.Controls.Add(Me.txtMatstartName)
            Me.grbDetail.Controls.Add(Me.ibtnCCedit)
            Me.grbDetail.Controls.Add(Me.ibtnCCfind)
            Me.grbDetail.Controls.Add(Me.txtDocDate)
            Me.grbDetail.Controls.Add(Me.chkAutorun)
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
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(672, 120)
            Me.grbDetail.TabIndex = 340
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'ibtnProcess
            '
            Me.ibtnProcess.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnProcess.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnProcess.Location = New System.Drawing.Point(536, 88)
            Me.ibtnProcess.Name = "ibtnProcess"
            Me.ibtnProcess.TabIndex = 358
            Me.ibtnProcess.Text = "Process"
            '
            'ibtnMatendEdit
            '
            Me.ibtnMatendEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnMatendEdit.Image = CType(resources.GetObject("ibtnMatendEdit.Image"), System.Drawing.Image)
            Me.ibtnMatendEdit.Location = New System.Drawing.Point(504, 88)
            Me.ibtnMatendEdit.Name = "ibtnMatendEdit"
            Me.ibtnMatendEdit.Size = New System.Drawing.Size(24, 23)
            Me.ibtnMatendEdit.TabIndex = 355
            Me.ibtnMatendEdit.TabStop = False
            Me.ibtnMatendEdit.ThemedImage = CType(resources.GetObject("ibtnMatendEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnMatendFind
            '
            Me.ibtnMatendFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnMatendFind.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnMatendFind.Image = CType(resources.GetObject("ibtnMatendFind.Image"), System.Drawing.Image)
            Me.ibtnMatendFind.Location = New System.Drawing.Point(480, 88)
            Me.ibtnMatendFind.Name = "ibtnMatendFind"
            Me.ibtnMatendFind.Size = New System.Drawing.Size(24, 23)
            Me.ibtnMatendFind.TabIndex = 354
            Me.ibtnMatendFind.TabStop = False
            Me.ibtnMatendFind.ThemedImage = CType(resources.GetObject("ibtnMatendFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblMatend
            '
            Me.lblMatend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMatend.Location = New System.Drawing.Point(8, 88)
            Me.lblMatend.Name = "lblMatend"
            Me.lblMatend.Size = New System.Drawing.Size(104, 18)
            Me.lblMatend.TabIndex = 353
            Me.lblMatend.Text = "ถึงวัสดุ"
            Me.lblMatend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnCCedit
            '
            Me.ibtnCCedit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnCCedit.Image = CType(resources.GetObject("ibtnCCedit.Image"), System.Drawing.Image)
            Me.ibtnCCedit.Location = New System.Drawing.Point(504, 40)
            Me.ibtnCCedit.Name = "ibtnCCedit"
            Me.ibtnCCedit.Size = New System.Drawing.Size(24, 23)
            Me.ibtnCCedit.TabIndex = 350
            Me.ibtnCCedit.TabStop = False
            Me.ibtnCCedit.ThemedImage = CType(resources.GetObject("ibtnCCedit.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnCCfind
            '
            Me.ibtnCCfind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnCCfind.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnCCfind.Image = CType(resources.GetObject("ibtnCCfind.Image"), System.Drawing.Image)
            Me.ibtnCCfind.Location = New System.Drawing.Point(480, 40)
            Me.ibtnCCfind.Name = "ibtnCCfind"
            Me.ibtnCCfind.Size = New System.Drawing.Size(24, 23)
            Me.ibtnCCfind.TabIndex = 349
            Me.ibtnCCfind.TabStop = False
            Me.ibtnCCfind.ThemedImage = CType(resources.GetObject("ibtnCCfind.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(240, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 347
            Me.chkAutorun.TabStop = False
            '
            'ibtnMatstartEdit
            '
            Me.ibtnMatstartEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnMatstartEdit.Image = CType(resources.GetObject("ibtnMatstartEdit.Image"), System.Drawing.Image)
            Me.ibtnMatstartEdit.Location = New System.Drawing.Point(504, 64)
            Me.ibtnMatstartEdit.Name = "ibtnMatstartEdit"
            Me.ibtnMatstartEdit.Size = New System.Drawing.Size(24, 23)
            Me.ibtnMatstartEdit.TabIndex = 346
            Me.ibtnMatstartEdit.TabStop = False
            Me.ibtnMatstartEdit.ThemedImage = CType(resources.GetObject("ibtnMatstartEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnMatstartFind
            '
            Me.ibtnMatstartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnMatstartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnMatstartFind.Image = CType(resources.GetObject("ibtnMatstartFind.Image"), System.Drawing.Image)
            Me.ibtnMatstartFind.Location = New System.Drawing.Point(480, 64)
            Me.ibtnMatstartFind.Name = "ibtnMatstartFind"
            Me.ibtnMatstartFind.Size = New System.Drawing.Size(24, 23)
            Me.ibtnMatstartFind.TabIndex = 345
            Me.ibtnMatstartFind.TabStop = False
            Me.ibtnMatstartFind.ThemedImage = CType(resources.GetObject("ibtnMatstartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCC
            '
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.Location = New System.Drawing.Point(8, 40)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(104, 18)
            Me.lblCC.TabIndex = 342
            Me.lblCC.Text = "คลังตรวจนับ:"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDate.Location = New System.Drawing.Point(384, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpDocDate.TabIndex = 338
            Me.dtpDocDate.TabStop = False
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(264, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(112, 18)
            Me.lblDocDate.TabIndex = 341
            Me.lblDocDate.Text = "วันที่เอกสาร"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 340
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMatstart
            '
            Me.lblMatstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMatstart.Location = New System.Drawing.Point(8, 64)
            Me.lblMatstart.Name = "lblMatstart"
            Me.lblMatstart.Size = New System.Drawing.Size(104, 18)
            Me.lblMatstart.TabIndex = 339
            Me.lblMatstart.Text = "จากวัสดุ"
            Me.lblMatstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(176, 128)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
            Me.ibtnBlank.TabIndex = 341
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(208, 128)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
            Me.ibtnDelRow.TabIndex = 342
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'MatStockCountDetailView
            '
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.txtCreateTime)
            Me.Controls.Add(Me.lblProcessTime)
            Me.Controls.Add(Me.txtCreateDate)
            Me.Controls.Add(Me.lblProcessDate)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.lblItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "MatStockCountDetailView"
            Me.Size = New System.Drawing.Size(688, 464)
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

#Region "Members"
        Private m_entity As MatStockCount
        Private m_printDocument As PrintDocument
        Private m_printingStringFormat As StringFormat

        Private m_treeManager As TreeManager
        Private m_tableStyleEnable As Hashtable
        Private m_isInitialized As Boolean = False
#End Region

#Region " SetLabeltext "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
            Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

            Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.lblCC}")
            Me.Validator.SetDisplayName(txtCCcode, lblCC.Text)

            Me.lblMatstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.lblMatstart}")
            Me.Validator.SetDisplayName(txtMatstartCode, lblMatstart.Text)

            Me.lblMatend.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.lblMatend}")
            Me.Validator.SetDisplayName(txtMatendCode, lblMatend.Text)

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.lblItem}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.grbDetail}")
            Me.lblProcessDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.lblProcessDate}")
            Me.lblProcessTime.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.lblProcessTime}")

            Me.ibtnProcess.Text = Me.StringParserService.Parse("${res:Global.ProcessText}")

        End Sub
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

            ' Add style            
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csUnitname)
            dst.GridColumnStyles.Add(csBalanceQty)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next

            Return dst
        End Function
        Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
            'If e.Column = 5 Then
            '    Me.UnitClicked(e)
            'ElseIf e.Column = 2 Then
            '    Me.LCIClicked(e)
            'End If
        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If

            If Me.m_entity.Canceled _
            OrElse Me.m_entity.Status.Value = 0 _
            OrElse Me.m_entity.Status.Value >= 3 _
            Then
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
            Me.dtpDocDate.Value = Now
        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler txtCCcode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtMatstartCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtMatendCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
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

            txtCode.Text = m_entity.Code
            txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            If Not m_entity.CostCenter Is Nothing Then
                txtCCcode.Text = m_entity.CostCenter.Code
                txtCCname.Text = m_entity.CostCenter.Name
            End If

            If Not m_entity.StartEntity Is Nothing Then
                txtMatstartCode.Text = m_entity.StartEntity.Code
                txtMatstartName.Text = CType(m_entity.StartEntity, IHasName).Name
            End If

            If Not m_entity.EndEntity Is Nothing Then
                txtMatendCode.Text = m_entity.EndEntity.Code
                txtMatendName.Text = CType(m_entity.EndEntity, IHasName).Name
            End If

            txtCreateDate.Text = MinDateToNull(m_entity.ProcessTime, "")
            txtCreateTime.Text = m_entity.ProcessTime.ToShortTimeString

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

        Private m_dateSetting As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
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
                        Me.m_entity.DocDate = Date.Now
                        Me.m_entity.DocDate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False

                Case "txtcccode"
                    Dim oldCC As CostCenter = Me.m_entity.CostCenter
                    dirtyFlag = CostCenter.GetCostCenter(txtCCcode, txtCCname, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                    If dirtyFlag Then
                        If oldCC.Originated AndAlso Not oldCC Is Me.m_entity.CostCenter Then
                            Dim myMsgService As IMessageService
                            myMsgService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                            If myMsgService.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.ChangeCostcenter}") Then
                                Me.m_entity.ItemTable.Clear()
                                RefreshBlankGrid()
                            Else
                                Me.m_entity.CostCenter = oldCC
                                txtCCcode.Text = Me.m_entity.CostCenter.Code
                                txtCCname.Text = Me.m_entity.CostCenter.Name
                            End If
                        End If
                    Else
                        If Not oldCC Is Me.m_entity.CostCenter Then
                            Me.m_entity.ItemTable.Clear()
                            RefreshBlankGrid()
                        End If
                    End If

                Case "txtmatstartcode"
                    dirtyFlag = LCIItem.GetLCIItem(txtMatstartCode, txtMatstartName, Me.m_entity.StartEntity)
                Case "txtmatendcode"
                    dirtyFlag = LCIItem.GetLCIItem(txtMatendCode, txtMatendName, Me.m_entity.EndEntity)
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub

        Public Sub SetStatus()

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
                Me.m_entity = CType(Value, MatStockCount)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()

        End Sub
#End Region

#Region "Event Handlers"
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

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Button Events"
        ' Auto run
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
        ' Cost center
        Private Sub ibtnCCedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCCedit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub ibtnCCfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCCfind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterDialog)
        End Sub
        Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
            Dim oldCC As CostCenter = Me.m_entity.CostCenter
            Me.txtCCcode.Text = e.Code
            Dim dirtyFlag As Boolean = CostCenter.GetCostCenter(txtCCcode, txtCCname, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            If dirtyFlag Then
                If oldCC.Originated AndAlso Not oldCC Is Me.m_entity.CostCenter Then
                    Dim myMsgService As IMessageService
                    myMsgService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                    If myMsgService.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.MatStockCountDetailView.ChangeCostcenter}") Then
                        Me.m_entity.ItemTable.Clear()
                        RefreshBlankGrid()
                    Else
                        Me.m_entity.CostCenter = oldCC
                        txtCCcode.Text = Me.m_entity.CostCenter.Code
                        txtCCname.Text = Me.m_entity.CostCenter.Name
                    End If
                End If
            Else
                If Not oldCC Is Me.m_entity.CostCenter Then
                    Me.m_entity.ItemTable.Clear()
                    RefreshBlankGrid()
                End If
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
        End Sub
        ' LCI item 
        Private Sub ibtnMatedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnMatstartEdit.Click, ibtnMatendEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New LCIItem)
        End Sub
        Private Sub ibtnMatfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnMatstartFind.Click, ibtnMatendFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "ibtnmatstartfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetMatStartDialog)
                Case "ibtnmatendfind"
                    myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetMatEndDialog)
                Case Else
            End Select
        End Sub
        Private Sub SetMatStartDialog(ByVal e As ISimpleEntity)
            Me.txtMatstartCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or LCIItem.GetLCIItem(txtMatstartCode, txtMatstartName, Me.m_entity.StartEntity)
        End Sub
        Private Sub SetMatEndDialog(ByVal e As ISimpleEntity)
            Me.txtMatendCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or LCIItem.GetLCIItem(txtMatendCode, txtMatendName, Me.m_entity.EndEntity)
        End Sub
        ' ประมวลผล
        Private Sub ibtnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnProcess.Click

            If Not m_entity Is Nothing Then
                If Not m_entity.CostCenter.Originated Then
                    Dim myMsgService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                    myMsgService.ShowWarning("${res:Global.Error.CostCenterMissing}")
                    txtCCcode.Focus()
                    Return
                End If
                m_entity.ProcessItems()
                RefreshBlankGrid()
                SetProcessTime()
            End If
        End Sub
        Private Sub SetProcessTime()
            Dim protime As Date = Date.Now
            txtCreateDate.Text = MinDateToNull(protime, "")
            txtCreateTime.Text = protime.ToShortTimeString
            Me.m_entity.ProcessTime = protime
        End Sub
#End Region

#Region "Overrides"
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New MatStockCount).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "IPrintable"
        '        Public Overrides ReadOnly Property PrintDocument() As PrintDocument
        '            Get
        '                Dim df As New DocumentForm("C:\Documents and Settings\Administrator\Desktop\Forms\Documents\MW.dfm", Me.m_entity)
        '                Return df.PrintDocument
        '            End Get
        '        End Property
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

