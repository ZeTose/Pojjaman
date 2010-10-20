Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class DepreDetail
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
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
        Friend WithEvents lblItemCount As System.Windows.Forms.Label
        Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblDepreDate As System.Windows.Forms.Label
        Friend WithEvents dtpDepreDate As System.Windows.Forms.DateTimePicker
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DepreDetail))
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtItemCount = New System.Windows.Forms.TextBox
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblStatus = New System.Windows.Forms.Label
            Me.lblItemCount = New System.Windows.Forms.Label
            Me.lblItemCountUnit = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDepreDate = New System.Windows.Forms.Label
            Me.dtpDepreDate = New System.Windows.Forms.DateTimePicker
            Me.grbMaster.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            Me.txtDocDate.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(120, 20)
            Me.txtDocDate.TabIndex = 4
            Me.txtDocDate.Text = ""
            '
            'txtItemCount
            '
            Me.txtItemCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtItemCount.BackColor = System.Drawing.SystemColors.Control
            Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
            Me.Validator.SetDisplayName(Me.txtItemCount, "")
            Me.txtItemCount.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtItemCount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.txtItemCount.Location = New System.Drawing.Point(616, 376)
            Me.Validator.SetMaxValue(Me.txtItemCount, "")
            Me.Validator.SetMinValue(Me.txtItemCount, "")
            Me.txtItemCount.Name = "txtItemCount"
            Me.txtItemCount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtItemCount, "")
            Me.Validator.SetRequired(Me.txtItemCount, False)
            Me.txtItemCount.Size = New System.Drawing.Size(96, 20)
            Me.txtItemCount.TabIndex = 19
            Me.txtItemCount.TabStop = False
            Me.txtItemCount.Text = ""
            Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(136, 144)
            Me.txtNote.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(384, 20)
            Me.txtNote.TabIndex = 14
            Me.txtNote.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(136, 16)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(120, 20)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
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
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.ibtnBlank)
            Me.grbMaster.Controls.Add(Me.ibtnDelRow)
            Me.grbMaster.Controls.Add(Me.lblStatus)
            Me.grbMaster.Controls.Add(Me.txtItemCount)
            Me.grbMaster.Controls.Add(Me.lblItemCount)
            Me.grbMaster.Controls.Add(Me.lblItemCountUnit)
            Me.grbMaster.Controls.Add(Me.tgItem)
            Me.grbMaster.Controls.Add(Me.lblItem)
            Me.grbMaster.Controls.Add(Me.chkAutorun)
            Me.grbMaster.Controls.Add(Me.txtNote)
            Me.grbMaster.Controls.Add(Me.lblNote)
            Me.grbMaster.Controls.Add(Me.lblDocDate)
            Me.grbMaster.Controls.Add(Me.lblCode)
            Me.grbMaster.Controls.Add(Me.txtCode)
            Me.grbMaster.Controls.Add(Me.txtDocDate)
            Me.grbMaster.Controls.Add(Me.dtpDocDate)
            Me.grbMaster.Controls.Add(Me.lblDepreDate)
            Me.grbMaster.Controls.Add(Me.dtpDepreDate)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(776, 408)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "grbMaster"
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(160, 168)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 15
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(184, 168)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 16
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Location = New System.Drawing.Point(16, 376)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(21, 16)
            Me.lblStatus.TabIndex = 21
            Me.lblStatus.Text = "xxx"
            '
            'lblItemCount
            '
            Me.lblItemCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCount.Location = New System.Drawing.Point(448, 376)
            Me.lblItemCount.Name = "lblItemCount"
            Me.lblItemCount.Size = New System.Drawing.Size(160, 18)
            Me.lblItemCount.TabIndex = 18
            Me.lblItemCount.Text = "จำนวนรายการคืน"
            Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItemCountUnit
            '
            Me.lblItemCountUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblItemCountUnit.AutoSize = True
            Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCountUnit.Location = New System.Drawing.Point(720, 376)
            Me.lblItemCountUnit.Name = "lblItemCountUnit"
            Me.lblItemCountUnit.Size = New System.Drawing.Size(38, 17)
            Me.lblItemCountUnit.TabIndex = 20
            Me.lblItemCountUnit.Text = "รายการ"
            Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.tgItem.Location = New System.Drawing.Point(8, 192)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(760, 176)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 15
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.AutoSize = True
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(16, 176)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(112, 19)
            Me.lblItem.TabIndex = 14
            Me.lblItem.Text = "รายการเครื่องจักร"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(256, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 2
            Me.chkAutorun.TabStop = False
            '
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(8, 144)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(120, 16)
            Me.lblNote.TabIndex = 12
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(296, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(80, 16)
            Me.lblDocDate.TabIndex = 3
            Me.lblDocDate.Text = "วันที่เอกสาร"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(120, 16)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDate.Location = New System.Drawing.Point(384, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(141, 20)
            Me.dtpDocDate.TabIndex = 5
            Me.dtpDocDate.TabStop = False
            '
            'lblDepreDate
            '
            Me.lblDepreDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDepreDate.Location = New System.Drawing.Point(8, 40)
            Me.lblDepreDate.Name = "lblDepreDate"
            Me.lblDepreDate.Size = New System.Drawing.Size(120, 16)
            Me.lblDepreDate.TabIndex = 7
            Me.lblDepreDate.Text = "วันที่โอน"
            Me.lblDepreDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDepreDate
            '
            Me.dtpDepreDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDepreDate.Location = New System.Drawing.Point(136, 40)
            Me.dtpDepreDate.Name = "dtpDepreDate"
            Me.dtpDepreDate.Size = New System.Drawing.Size(141, 20)
            Me.dtpDepreDate.TabIndex = 9
            Me.dtpDepreDate.TabStop = False
            '
            'DepreDetail
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Name = "DepreDetail"
            Me.Size = New System.Drawing.Size(792, 424)
            Me.grbMaster.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.lblDocDate}")
            Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.lblNote}")
            Me.Validator.SetDisplayName(txtNote, lblNote.Text)

            Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.lblItemCountUnit}")
            Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.lblItemCount}")
            Me.Validator.SetDisplayName(txtItemCount, lblItemCount.Text)

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.lblItem}")

            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.grbMaster}")
        End Sub
#End Region

#Region "Members"
        Private m_entity As Depre

        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager

        Private m_tableStyleEnable As Hashtable
#End Region

#Region " Constructors "
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = DepreItem.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False
            Me.Validator.DataTable = m_treeManager.Treetable

            AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete

            EventWiring()
        End Sub
#End Region

#Region " Style "
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "DepreItem"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            ' Line number
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "lineNumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.Alignment = HorizontalAlignment.Center
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "lineNumber"

            ' Asset code
            Dim csCode As New TreeTextColumn
            csCode.MappingName = "asset_code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 60
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = False
            csCode.TextBox.Name = "asset_code"

            ' Asset button find
            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "btnAsset"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf GridButton_Click

            ' Asset name
            Dim csName As New TreeTextColumn
            csName.MappingName = "asset_name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Alignment = HorizontalAlignment.Center
            csName.DataAlignment = HorizontalAlignment.Left
            csName.Width = 150
            csName.ReadOnly = True
            csName.TextBox.Name = "asset_name"

            ' Asset name
            Dim csCostCenter As New TreeTextColumn
            csCostCenter.MappingName = "CostCenter"
            csCostCenter.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.CostCenterHeaderText}")
            csCostCenter.NullText = ""
            csCostCenter.Alignment = HorizontalAlignment.Center
            csCostCenter.DataAlignment = HorizontalAlignment.Left
            csCostCenter.Width = 150
            csCostCenter.ReadOnly = True

            ' อายุค่าเสื่อม
            Dim csAge As New TreeTextColumn
            csAge.MappingName = "deprei_age"
            csAge.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.AgeHeaderText}")
            csAge.NullText = ""
            csAge.Alignment = HorizontalAlignment.Center
            csAge.DataAlignment = HorizontalAlignment.Center
            csAge.Width = 60
            csAge.Format = "#,###"
            csAge.ReadOnly = True
            csAge.TextBox.Name = "deprei_age"

            ' วันที่เริ่มคำนวณค่าเสื่อมราคา
            Dim csStartCalcDate As New TreeTextColumn
            csStartCalcDate.MappingName = "asset_startCalcDate"
            csStartCalcDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.StartCalcDateHeaderText}")
            csStartCalcDate.NullText = ""
            csStartCalcDate.Alignment = HorizontalAlignment.Center
            csStartCalcDate.DataAlignment = HorizontalAlignment.Center
            csStartCalcDate.Width = 70
            csStartCalcDate.Format = "dd/MM/yyyy"
            csStartCalcDate.ReadOnly = True
            csStartCalcDate.TextBox.Name = "asset_startCalcDate"

            ' ต้นทุน
            Dim csPrice As New TreeTextColumn
            csPrice.MappingName = "deprei_price"
            csPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.BuyPriceHeaderText}")
            csPrice.NullText = ""
            csPrice.Alignment = HorizontalAlignment.Center
            csPrice.DataAlignment = HorizontalAlignment.Right
            csPrice.Width = 80
            csPrice.Format = "#,##0.00"
            csPrice.ReadOnly = True
            csPrice.TextBox.Name = "deprei_price"

            ' ค่าเสื่อมยกมา
            Dim csDepreOpening As New TreeTextColumn
            csDepreOpening.MappingName = "deprei_depreopening"
            csDepreOpening.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.DepreOpeningHeaderText}")
            csDepreOpening.NullText = ""
            csDepreOpening.Alignment = HorizontalAlignment.Center
            csDepreOpening.DataAlignment = HorizontalAlignment.Right
            csDepreOpening.Width = 90
            csDepreOpening.Format = "#,##0.00"
            csDepreOpening.ReadOnly = True
            csDepreOpening.MappingName = "deprei_depreopening"

            ' ค่าซาก
            Dim csSalvage As New TreeTextColumn
            csSalvage.MappingName = "deprei_salvage"
            csSalvage.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.SalvageHeaderText}")
            csSalvage.NullText = ""
            csSalvage.Alignment = HorizontalAlignment.Center
            csSalvage.DataAlignment = HorizontalAlignment.Right
            csSalvage.Width = 80
            csSalvage.Format = "#,##0.00"
            csSalvage.ReadOnly = True
            csSalvage.TextBox.Name = "deprei_salvage"

            ' ค่าเสื่อมเพิ่มเฉลี่ยต่อวัน
            Dim csAddDepre As New TreeTextColumn
            csAddDepre.MappingName = "deprei_depreamnt"
            csAddDepre.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.DepreCalcHeaderText}")
            csAddDepre.NullText = ""
            csAddDepre.Alignment = HorizontalAlignment.Center
            csAddDepre.DataAlignment = HorizontalAlignment.Right
            csAddDepre.Width = 90
            csAddDepre.Format = "#,##0.00"
            csAddDepre.ReadOnly = True
            csAddDepre.TextBox.Name = "deprei_depreamnt"

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "deprei_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreDetail.NoteHeaderText}")
            csNote.Alignment = HorizontalAlignment.Center
            csNote.DataAlignment = HorizontalAlignment.Right
            csNote.Width = 150
            csNote.ReadOnly = False
            csNote.TextBox.Name = "deprei_note"
            csNote.NullText = ""

            ' Fill Column Style 
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csCostCenter)
            dst.GridColumnStyles.Add(csAge)
            dst.GridColumnStyles.Add(csStartCalcDate)
            dst.GridColumnStyles.Add(csPrice)
            dst.GridColumnStyles.Add(csDepreOpening)
            dst.GridColumnStyles.Add(csSalvage)
            dst.GridColumnStyles.Add(csAddDepre)
            dst.GridColumnStyles.Add(csNote)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next

            Return dst
        End Function

#End Region

#Region "Properties"
        Private ReadOnly Property CurrentItem() As DepreItem
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is DepreItem Then
                    Return Nothing
                End If
                Return CType(row.Tag, DepreItem)
            End Get
        End Property
#End Region

#Region "ItemTreeTable Handlers"
        Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            RefreshDocs()
            tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized Then
                Return
            End If
            If Me.m_treeManager.SelectedRow Is Nothing Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity Is Nothing Then
                Return
            End If
            Dim doc As DepreItem = Me.CurrentItem
            If doc Is Nothing Then
                doc = New DepreItem
                Me.m_entity.ItemCollection.Add(doc)
                Me.m_treeManager.SelectedRow.Tag = doc
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
                            e.ProposedValue = ""
                        End If
                        doc.SetItemCode(CStr(e.ProposedValue))
                    Case "pri_note"
                        If IsDBNull(e.ProposedValue) Then
                            e.ProposedValue = ""
                        End If
                        doc.Note = e.ProposedValue.ToString
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        End Sub
#End Region

#Region " IListDetail "
        Public Overrides Sub Initialize()

        End Sub

        ' Check Enable 
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If

            If Me.m_entity.Canceled _
            OrElse Me.m_entity.Status.Value = 0 _
            OrElse Me.m_entity.Status.Value >= 3 Then
                For Each ctrl As Control In Me.grbMaster.Controls
                    ctrl.Enabled = False
                Next
                tgItem.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next
            Else
                For Each ctrl As Control In Me.grbMaster.Controls
                    ctrl.Enabled = True
                Next
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next
            End If

        End Sub
        ' Clear Detail
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In Me.grbMaster.Controls
                If TypeOf crlt Is TextBox Then
                    crlt.Text = ""
                End If
                If TypeOf crlt Is FixedGroupBox Then
                    For Each grbctlt As Control In crlt.Controls
                        If TypeOf grbctlt Is TextBox Then
                            grbctlt.Text = ""
                        End If
                    Next
                End If
            Next

            Me.dtpDocDate.Value = Date.Now
            txtDocDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

            Me.dtpDepreDate.Value = Date.Now

        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            Me.m_isInitialized = False
            ClearDetail()

            If m_entity Is Nothing Then
                Return
            End If

            txtCode.Text = Me.m_entity.Code
            txtNote.Text = Me.m_entity.Note
            ' autogencode
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()
            ' วันที่เอกสาร
            txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
            ' วันที่โอน
            dtpDepreDate.Value = MinDateToNow(Me.m_entity.DepreDate)

            RefreshDocs()

            SetStatus()
            SetLabelText()

            CheckFormEnable()

            Me.m_isInitialized = True
        End Sub
        Private Sub RefreshDocs()
            Me.m_isInitialized = False
            Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
            RefreshBlankGrid()
            ReIndex()
            Me.m_treeManager.Treetable.AcceptChanges()
            UpdateAmount()
            Me.m_isInitialized = True
        End Sub
        ' Addhandler events
        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler dtpDepreDate.ValueChanged, AddressOf Me.ChangeProperty
            ' คำนวณวันค่าใหม่ เมื่อเปลี่ยนวัน
            AddHandler dtpDepreDate.ValueChanged, AddressOf Me.DepredateChanged

        End Sub
        ' คำนวณค่าใหม่เมื่อเปลี่ยนวันที่
        Public Sub DepredateChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim flag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            Me.RefreshDocs()
            Me.WorkbenchWindow.ViewContent.IsDirty = flag
            RefreshBlankGrid()
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

                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True

                Case "txtdocdate"
                    m_dateSetting = True
                    If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDate.Text)
                        If Not Me.m_entity.DocDate.Equals(theDate) Then
                            dtpDocDate.Value = theDate
                            Me.m_entity.DocDate = dtpDocDate.Value
                            Me.dtpDocDate.Value = MaxDtpDate(Me.m_entity.DocDate)
                            dirtyFlag = True
                        End If
                    Else
                        dtpDocDate.Value = Date.Now
                        Me.m_entity.DocDate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False

                Case "dtpdocdate"
                    If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.DocDate = dtpDocDate.Value
                            Me.dtpDocDate.Value = MaxDtpDate(Me.m_entity.DocDate)
                        End If
                        dirtyFlag = True
                    End If
                Case "dtpdepredate"
                    If Not Me.m_entity.DepreDate.Equals(dtpDepreDate.Value) Then
                        If Not m_dateSetting Then
                            Me.m_entity.DepreDate = dtpDepreDate.Value
                            Me.dtpDepreDate.Value = MaxDtpDate(Me.m_entity.DepreDate)
                        End If
                        dirtyFlag = True
                    End If
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            SetStatus()
            CheckFormEnable()
        End Sub
    Public Sub SetStatus()
    MyBase.SetStatusBarMessage()
    End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not m_entity Is Nothing Then
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, Depre)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

#End Region

#Region " Event Handlers "
        Private Function GenIDListFromDataTable() As String
            Dim idlist As String = ""
            For Each item As DepreItem In Me.m_entity.ItemCollection
                If Not item.Entity Is Nothing AndAlso item.Entity.Originated Then
                    idlist &= "|" & item.Entity.Id.ToString & "|"
                End If
            Next
            Return idlist
        End Function

        Public Sub GridButton_Click(ByVal e As ButtonColumnEventArgs)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            ' ต้องการหนดวันที่โอนก่อน ...
            If Me.m_entity.DepreDate.Equals(Date.MinValue) Then
                msgServ.ShowWarningFormatted("${res:Global.MustDefine}", lblDepreDate.Text)
                dtpDepreDate.Focus()
                Return
            End If
            ' ไม่แสดงรายการใน list ของ detail
            Dim arr(1) As Filter
            arr(0) = New Filter("IDList", GenIDListFromDataTable)
            arr(1) = New Filter("asset_lastdepredate", Me.m_entity.ValidDateOrDBNull(Me.m_entity.DepreDate))
            ' Filter ของ Entity find view
            Dim entities As New ArrayList
            Dim obj As New Asset
            obj.Costcenter = Me.m_entity.FromCostcenter
            entities.Add(obj)

            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetItems, arr, entities)
        End Sub
        Private Sub SetAssetItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim newItem As New Asset(item.Id)
                Dim doc As New DepreItem
                If Not Me.CurrentItem Is Nothing Then
                    doc = Me.CurrentItem
                    Me.m_treeManager.SelectedRow.Tag = Nothing
                Else
                    Me.m_entity.ItemCollection.Add(doc)
                End If
                doc.Entity = newItem
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            Next
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.ItemCollection.Count - 1 Then
                Return
            End If
            Dim myItem As New DepreItem
            Me.m_entity.ItemCollection.Insert(index, myItem)
            Me.RefreshDocs()
            tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Me.m_entity.ItemCollection.Remove(index)
            Me.RefreshDocs()
            Me.tgItem.CurrentRowIndex = index
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ReIndex()
            Dim i As Integer = 0
            For Each row As DataRow In Me.m_treeManager.Treetable.Rows
                row("deprei_linenumber") = i + 1
                i += 1
            Next
        End Sub
#End Region

#Region " IValidatable "
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region " Overrides "
        Public Overrides Sub NotifyBeforeSave()

        End Sub

        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New AssetReturn).DetailPanelIcon
            End Get
        End Property
#End Region

#Region " Event of Button controls "
#End Region

#Region " IClipboardHandler Overrides "
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                ' Person
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Employee).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtpersonincode", "txtpersoninname"
                                Return True
                            Case "txtpersonoutcode", "txtpersonoutname"
                                Return True
                        End Select
                    End If
                End If
                ' Cost center
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtccincode", "txtccinname"
                                Return True
                            Case "txtccoutcode", "txtccoutname"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            ' Person
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                    End Select
                End If
            End If
            ' Cost center
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                    End Select
                End If
            End If
        End Sub
#End Region

#Region " IPrintable "
        'Public Overrides ReadOnly Property PrintDocument() As PrintDocument
        '    Get
        '        Dim pd As New PrintDocument
        '        AddHandler pd.PrintPage, AddressOf PrintPage_Handler
        '        Return pd
        '    End Get
        'End Property
        'Private Sub PrintPage_Handler(ByVal sender As Object, ByVal pe As PrintPageEventArgs)
        '    Dim df As New DocumentForm("C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PR.dfm") '"C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PR.dfm")
        '    For Each entry As DictionaryEntry In df.ControlDictionary.Hashtable
        '        If TypeOf entry.Value Is IDrawable Then
        '            If Not TypeOf entry.Value Is FormTable.FormTable Then
        '                CType(entry.Value, IDrawable).Draw(pe.Graphics, CType(entry.Value, Control).Location)
        '            Else
        '                Dim ft As FormTable.FormTable = CType(df.ControlDictionary("formTable"), FormTable.FormTable)
        '                ft.Draw(pe.Graphics, ft.Location)
        '                Dim colOffset As Integer = 0
        '                Dim verticalInterval As Integer = 5
        '                Dim horizontalInterval As Integer = 5
        '                For Each col As FormTable.Column In ft.Columns
        '                    colOffset = col.Width + colOffset
        '                    If Me.m_entity.ItemTable.Childs.Count > 0 Then
        '                        For i As Integer = 0 To ft.RowsPerPage - 1
        '                            If i > Me.m_entity.ItemTable.Childs.Count - 1 Then
        '                                Exit For
        '                            End If
        '                            Dim row As TreeRow = Me.m_entity.ItemTable.Childs(i)
        '                            If Not IsDBNull(row(col.ReportField)) Then
        '                                Dim data As String = row(col.ReportField).ToString
        '                                Dim textSize As SizeF = pe.Graphics.MeasureString(data, ft.Font)
        '                                Dim startPoint As Integer
        '                                Select Case col.Alignment
        '                                    Case HorizontalAlignment.Center
        '                                        startPoint = CInt((col.Width / 2) - (textSize.Width / 2)) + colOffset - col.Width
        '                                    Case HorizontalAlignment.Left
        '                                        startPoint = colOffset - col.Width + horizontalInterval
        '                                    Case HorizontalAlignment.Right
        '                                        startPoint = CInt(colOffset - textSize.Width - horizontalInterval)
        '                                End Select
        '                                pe.Graphics.DrawString(data, ft.Font, New SolidBrush(ft.ForeColor), ft.Location.X + startPoint, ft.HeaderHeight + ft.Location.Y + i * ft.RowHeight + verticalInterval)
        '                            End If
        '                        Next
        '                    End If
        '                Next
        '            End If
        '        End If
        '    Next
        'End Sub
#End Region

#Region " Grid Resizing "
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
            Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
                'เพิ่มแถวจนเต็ม
                Me.m_treeManager.Treetable.Childs.Add()
            Loop

            If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
                'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                Me.m_treeManager.Treetable.Childs.Add()
            End If

            Me.m_treeManager.Treetable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

#Region " Private Methods "
        Private Sub UpdateAmount()
            txtItemCount.Text = Configuration.FormatToString(Me.m_entity.ItemCollection.Count, DigitConfig.Int)
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