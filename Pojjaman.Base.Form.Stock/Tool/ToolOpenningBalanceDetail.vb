Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ToolOpenningBalanceDetail
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region " Windows Form Designer generated code "
        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtCCcode As System.Windows.Forms.TextBox
        Friend WithEvents txtCCname As System.Windows.Forms.TextBox
        Friend WithEvents lblCoscenter As System.Windows.Forms.Label
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ToolOpenningBalanceDetail))
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtCCcode = New System.Windows.Forms.TextBox
            Me.txtCCname = New System.Windows.Forms.TextBox
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblNote = New System.Windows.Forms.Label
            Me.lblCoscenter = New System.Windows.Forms.Label
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblItem = New System.Windows.Forms.Label
            Me.lblStatus = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.grbMaster.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            'txtDocDate
            '
            Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDate, "")
            Me.txtDocDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconAlignment(Me.txtDocDate, System.Windows.Forms.ErrorIconAlignment.BottomLeft)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.txtDocDate.Location = New System.Drawing.Point(376, 16)
            Me.txtDocDate.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(123, 22)
            Me.txtDocDate.TabIndex = 4
            Me.txtDocDate.Text = ""
            '
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(120, 64)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(400, 22)
            Me.txtNote.TabIndex = 12
            Me.txtNote.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(120, 16)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(120, 22)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'txtCCcode
            '
            Me.txtCCcode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCCcode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCcode, "")
            Me.txtCCcode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCcode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCcode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCcode, System.Drawing.Color.Empty)
            Me.txtCCcode.Location = New System.Drawing.Point(120, 40)
            Me.txtCCcode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCCcode, "")
            Me.Validator.SetMinValue(Me.txtCCcode, "")
            Me.txtCCcode.Name = "txtCCcode"
            Me.Validator.SetRegularExpression(Me.txtCCcode, "")
            Me.Validator.SetRequired(Me.txtCCcode, True)
            Me.txtCCcode.Size = New System.Drawing.Size(120, 22)
            Me.txtCCcode.TabIndex = 7
            Me.txtCCcode.Text = ""
            '
            'txtCCname
            '
            Me.txtCCname.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtCCname, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCname, "")
            Me.txtCCname.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCname, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCname, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCname, System.Drawing.Color.Empty)
            Me.txtCCname.Location = New System.Drawing.Point(240, 40)
            Me.txtCCname.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtCCname, "")
            Me.Validator.SetMinValue(Me.txtCCname, "")
            Me.txtCCname.Name = "txtCCname"
            Me.txtCCname.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCCname, "")
            Me.Validator.SetRequired(Me.txtCCname, False)
            Me.txtCCname.Size = New System.Drawing.Size(232, 22)
            Me.txtCCname.TabIndex = 8
            Me.txtCCname.TabStop = False
            Me.txtCCname.Text = ""
            '
            'grbMaster
            '
            Me.grbMaster.Controls.Add(Me.chkAutorun)
            Me.grbMaster.Controls.Add(Me.btnCCEdit)
            Me.grbMaster.Controls.Add(Me.btnCCFind)
            Me.grbMaster.Controls.Add(Me.txtDocDate)
            Me.grbMaster.Controls.Add(Me.txtNote)
            Me.grbMaster.Controls.Add(Me.dtpDocDate)
            Me.grbMaster.Controls.Add(Me.lblDocDate)
            Me.grbMaster.Controls.Add(Me.lblCode)
            Me.grbMaster.Controls.Add(Me.txtCode)
            Me.grbMaster.Controls.Add(Me.lblNote)
            Me.grbMaster.Controls.Add(Me.txtCCcode)
            Me.grbMaster.Controls.Add(Me.txtCCname)
            Me.grbMaster.Controls.Add(Me.lblCoscenter)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(536, 96)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "รายละเอียดเครื่องมือยกมา"
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(240, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 2
            Me.chkAutorun.TabStop = False
            '
            'btnCCEdit
            '
            Me.btnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCEdit.Image = CType(resources.GetObject("btnCCEdit.Image"), System.Drawing.Image)
            Me.btnCCEdit.Location = New System.Drawing.Point(496, 40)
            Me.btnCCEdit.Name = "btnCCEdit"
            Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnCCEdit.TabIndex = 10
            Me.btnCCEdit.TabStop = False
            Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCCFind
            '
            Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCFind.Image = CType(resources.GetObject("btnCCFind.Image"), System.Drawing.Image)
            Me.btnCCFind.Location = New System.Drawing.Point(472, 40)
            Me.btnCCFind.Name = "btnCCFind"
            Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnCCFind.TabIndex = 9
            Me.btnCCFind.TabStop = False
            Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDate.Location = New System.Drawing.Point(376, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(144, 22)
            Me.dtpDocDate.TabIndex = 5
            Me.dtpDocDate.TabStop = False
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(272, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(96, 18)
            Me.lblDocDate.TabIndex = 3
            Me.lblDocDate.Text = "วันที่เอกสาร:"
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
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(8, 64)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(104, 18)
            Me.lblNote.TabIndex = 11
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCoscenter
            '
            Me.lblCoscenter.BackColor = System.Drawing.Color.Transparent
            Me.lblCoscenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCoscenter.Location = New System.Drawing.Point(8, 40)
            Me.lblCoscenter.Name = "lblCoscenter"
            Me.lblCoscenter.Size = New System.Drawing.Size(104, 18)
            Me.lblCoscenter.TabIndex = 6
            Me.lblCoscenter.Text = "Cost Center:"
            Me.lblCoscenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(232, 112)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(26, 24)
            Me.ibtnBlank.TabIndex = 20
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(256, 112)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(26, 24)
            Me.ibtnDelRow.TabIndex = 21
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(18, 120)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(198, 18)
            Me.lblItem.TabIndex = 18
            Me.lblItem.Text = "รายการเครื่อมือยกมา"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.Location = New System.Drawing.Point(312, 120)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(47, 17)
            Me.lblStatus.TabIndex = 22
            Me.lblStatus.Text = "lblStatus"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.tgItem.Location = New System.Drawing.Point(16, 136)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(528, 168)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 23
            Me.tgItem.TreeManager = Nothing
            '
            'ToolOpenningBalanceDetail
            '
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "ToolOpenningBalanceDetail"
            Me.Size = New System.Drawing.Size(560, 312)
            Me.grbMaster.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        'UserControl overrides dispose to clean up the component list
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
#End Region

#Region "SetLabelText"
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.lblCode}")
            Me.Validator.SetDisplayName(Me.txtCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

            Me.lblCoscenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.lblCCCode}")
            Me.Validator.SetDisplayName(Me.txtCCcode, StringHelper.GetRidOfAtEnd(Me.lblCoscenter.Text, ":"))

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.lblItem}")
            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
            Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

        End Sub
#End Region

#Region "Members"
        Private m_entity As ToolOpenningBalance
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
        Private m_tableStyleEnable As Hashtable
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = ToolOpenningBalance.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False

            EventWiring()
        End Sub
#End Region

#Region " Style "
        Protected Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "ToolOpenningBalance"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            'Stock Items
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "stocki_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "stocki_linenumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.CodeHeaderText}")
            csCode.NullText = ""
            'csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "ToolButton"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf ButtonClicked

            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Width = 180
            csName.TextBox.Name = "Name"
            csName.ReadOnly = True
            'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
            'csDescription.ReadOnly = True

            Dim csGroup As New TreeTextColumn
            csGroup.MappingName = "Group"
            csGroup.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.GroupHeaderText}")
            csGroup.NullText = ""
            csGroup.Width = 120
            csGroup.Alignment = HorizontalAlignment.Center
            csGroup.DataAlignment = HorizontalAlignment.Left
            csGroup.TextBox.Name = "txtGroup"
            csGroup.ReadOnly = True

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.UnitHeaderText}")
            csUnit.NullText = ""
            csUnit.TextBox.Name = "Unit"
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center


            Dim csQty As New TreeTextColumn
            csQty.MappingName = "stocki_qty"
            csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.QtyHeaderText}")
            csQty.NullText = ""
            csQty.DataAlignment = HorizontalAlignment.Right
            csQty.Format = "#,###.##"
            csQty.TextBox.Name = "Qty"
            'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty


            Dim csNote As New TreeTextColumn
            csNote.MappingName = "stocki_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "stocki_note"


            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csGroup)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csQty)
            dst.GridColumnStyles.Add(csNote)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next

            Return dst
        End Function
        Protected Function CreateTableStyle2() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "StockItem"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "stocki_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.Alignment = HorizontalAlignment.Center
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "txtLinenumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 70
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = False
            csCode.TextBox.Name = "txtCode"

            Dim csToolButton As New DataGridButtonColumn
            csToolButton.MappingName = "ToolButton"
            csToolButton.HeaderText = ""
            csToolButton.NullText = ""
            AddHandler csToolButton.Click, AddressOf ButtonClicked

            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Width = 120
            csName.Alignment = HorizontalAlignment.Center
            csName.DataAlignment = HorizontalAlignment.Left
            csName.TextBox.Name = "txtName"
            csName.ReadOnly = True

            Dim csGroup As New TreeTextColumn
            csGroup.MappingName = "Group"
            csGroup.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.GroupHeaderText}")
            csGroup.NullText = ""
            csGroup.Width = 120
            csGroup.Alignment = HorizontalAlignment.Center
            csGroup.DataAlignment = HorizontalAlignment.Left
            csGroup.TextBox.Name = "txtGroup"
            csGroup.ReadOnly = True

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.UnitHeaderText}")
            csUnit.NullText = ""
            csUnit.Width = 80
            csUnit.Alignment = HorizontalAlignment.Center
            csUnit.DataAlignment = HorizontalAlignment.Left
            csUnit.TextBox.Name = "txtUnit"
            csUnit.ReadOnly = True

            Dim csQty As New TreeTextColumn
            csQty.MappingName = "stocki_qty"
            csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.QtyHeaderText}")
            csQty.NullText = ""
            csQty.Width = 100
            csQty.Alignment = HorizontalAlignment.Center
            csQty.DataAlignment = HorizontalAlignment.Right
            csQty.Format = "#,##0.00"
            csQty.TextBox.Name = "txtQty"
            csQty.ReadOnly = False

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "stocki_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolOpenningBalanceDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 120
            csNote.Alignment = HorizontalAlignment.Center
            csNote.DataAlignment = HorizontalAlignment.Left
            csNote.TextBox.Name = "txtNote"
            csNote.ReadOnly = False

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csToolButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csGroup)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csQty)
            dst.GridColumnStyles.Add(csNote)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next

            Return dst
        End Function
        Protected Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 2 Then
                ToolButton_Click(e)
            Else

            End If

        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Canceled _
            OrElse Me.m_entity.Status.Value = 0 _
            OrElse Me.m_entity.Status.Value >= 3 Then
                For Each ctrl As Control In grbMaster.Controls
                    ctrl.Enabled = False
                Next

                tgItem.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next
            Else
                For Each ctrl As Control In grbMaster.Controls
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
            Me.dtpDocDate.Value = Date.Now
        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtCCcode.Validated, AddressOf Me.ChangeProperty
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

            DateToString(Me.m_entity.DocDate, txtDocDate)
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

            If Not Me.m_entity.ToCostCenter Is Nothing Then
                txtCCcode.Text = Me.m_entity.ToCostCenter.Code
                txtCCname.Text = Me.m_entity.ToCostCenter.Name
            End If


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

                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                    dirtyFlag = True
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True


                Case "txtcccode"
                    dirtyFlag = CostCenter.GetCostCenter(txtCCcode, txtCCname, Me.m_entity.ToCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
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
                lblStatus.Text = ""
            End If
        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not Me.m_entity Is Nothing Then
                    RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
                End If
                If Not Object.ReferenceEquals(Me.m_entity, Value) Then
                    Me.m_entity = Nothing
                    Me.m_entity = CType(Value, ToolOpenningBalance)
                End If
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property
        Public Overrides Sub Initialize()
        End Sub
#End Region

#Region "Event Handlers"
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

        Private Sub SetEntityValue(ByVal check As ISimpleEntity)
            Me.m_treeManager.SelectedRow("Code") = check.Code
        End Sub
        Private Sub SetEntityItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            Me.m_entity.IsInitialized = True
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim newItem As Tool
                newItem = New Tool(item.Id)

                If i = items.Count - 1 Then
                    If Me.m_entity.ItemTable.Childs.Count = 0 Then
                        Me.m_entity.AddBlankRow(1)
                        Me.m_entity.ItemTable.Childs(0)("Code") = newItem.Code
                        Me.m_entity.ItemTable.Childs(0)("stocki_qty") = 1
                    Else
                        Me.m_entity.ItemTable.Childs(index)("Code") = newItem.Code
                        Me.m_entity.ItemTable.Childs(index)("stocki_qty") = 1
                    End If
                Else
                    Me.m_entity.Insert(index, New ToolOpenningBalanceItem)
                    Me.m_entity.ItemTable.Childs(index)("Code") = newItem.Code
                    Me.m_entity.ItemTable.Childs(index)("stocki_qty") = 1
                End If
                Me.m_entity.ItemTable.AcceptChanges()
            Next
            tgItem.CurrentRowIndex = index
            Me.m_entity.IsInitialized = False
            RefreshBlankGrid()
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
                Return (New MatWithdraw).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Rows Manager Button"
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.MaxRowIndex Then
                Return
            End If
            Dim newItem As New BlankItem("")
            Dim item As New ToolOpenningBalanceItem
            item.Entity = newItem
            item.Qty = 0
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

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccode", "txtccname"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcccode", "txtccname"
                            Me.SetCostCenter(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region "Event of Button Controls"
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

        Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub

        Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
            'ShowDialogForm(New Unit)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
        End Sub

        Private Sub SetCostCenter(ByVal e As ISimpleEntity)
            Me.txtCCcode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty _
            Or CostCenter.GetCostCenter(txtCCcode, txtCCname, Me.m_entity.ToCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub

#End Region

    End Class
End Namespace