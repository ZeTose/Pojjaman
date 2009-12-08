Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class SupMatDetail
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
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents ibtnAdd As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress As System.Windows.Forms.TextBox
        Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents lblProvince As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnGroupEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
        Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SupMatDetail))
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnGroupEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblGroup = New System.Windows.Forms.Label
            Me.txtGroupName = New System.Windows.Forms.TextBox
            Me.txtGroupCode = New System.Windows.Forms.TextBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.txtAddress = New System.Windows.Forms.TextBox
            Me.cmbProvince = New System.Windows.Forms.ComboBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtPhone = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblName = New System.Windows.Forms.Label
            Me.lblPhone = New System.Windows.Forms.Label
            Me.lblProvince = New System.Windows.Forms.Label
            Me.lblAddress = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
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
            Me.tgItem.Location = New System.Drawing.Point(8, 128)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(744, 296)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 2
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 112)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(72, 18)
            Me.lblItem.TabIndex = 1
            Me.lblItem.Text = "วัสดุ:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnGroupFind)
            Me.grbDetail.Controls.Add(Me.btnGroupEdit)
            Me.grbDetail.Controls.Add(Me.lblGroup)
            Me.grbDetail.Controls.Add(Me.txtGroupName)
            Me.grbDetail.Controls.Add(Me.txtGroupCode)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.txtAddress)
            Me.grbDetail.Controls.Add(Me.cmbProvince)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.txtPhone)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.lblPhone)
            Me.grbDetail.Controls.Add(Me.lblProvince)
            Me.grbDetail.Controls.Add(Me.lblAddress)
            Me.grbDetail.Enabled = False
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(688, 104)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียด"
            '
            'btnGroupFind
            '
            Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnGroupFind.Image = CType(resources.GetObject("btnGroupFind.Image"), System.Drawing.Image)
            Me.btnGroupFind.Location = New System.Drawing.Point(632, 72)
            Me.btnGroupFind.Name = "btnGroupFind"
            Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
            Me.btnGroupFind.TabIndex = 14
            Me.btnGroupFind.TabStop = False
            Me.btnGroupFind.ThemedImage = CType(resources.GetObject("btnGroupFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnGroupEdit
            '
            Me.btnGroupEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGroupEdit.Image = CType(resources.GetObject("btnGroupEdit.Image"), System.Drawing.Image)
            Me.btnGroupEdit.Location = New System.Drawing.Point(656, 72)
            Me.btnGroupEdit.Name = "btnGroupEdit"
            Me.btnGroupEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnGroupEdit.TabIndex = 0
            Me.btnGroupEdit.TabStop = False
            Me.btnGroupEdit.ThemedImage = CType(resources.GetObject("btnGroupEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblGroup
            '
            Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Black
            Me.lblGroup.Location = New System.Drawing.Point(336, 72)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(88, 18)
            Me.lblGroup.TabIndex = 11
            Me.lblGroup.Text = "กลุ่ม Supplier :"
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtGroupName
            '
            Me.Validator.SetDataType(Me.txtGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroupName, "")
            Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.txtGroupName.Location = New System.Drawing.Point(504, 72)
            Me.Validator.SetMaxValue(Me.txtGroupName, "")
            Me.Validator.SetMinValue(Me.txtGroupName, "")
            Me.txtGroupName.Name = "txtGroupName"
            Me.txtGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGroupName, "")
            Me.Validator.SetRequired(Me.txtGroupName, False)
            Me.txtGroupName.Size = New System.Drawing.Size(128, 21)
            Me.txtGroupName.TabIndex = 13
            Me.txtGroupName.TabStop = False
            Me.txtGroupName.Text = ""
            '
            'txtGroupCode
            '
            Me.Validator.SetDataType(Me.txtGroupCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroupCode, "")
            Me.txtGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
            Me.txtGroupCode.Location = New System.Drawing.Point(424, 72)
            Me.txtGroupCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtGroupCode, "")
            Me.Validator.SetMinValue(Me.txtGroupCode, "")
            Me.txtGroupCode.Name = "txtGroupCode"
            Me.txtGroupCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGroupCode, "")
            Me.Validator.SetRequired(Me.txtGroupCode, False)
            Me.txtGroupCode.Size = New System.Drawing.Size(80, 21)
            Me.txtGroupCode.TabIndex = 12
            Me.txtGroupCode.TabStop = False
            Me.txtGroupCode.Text = ""
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(80, 48)
            Me.txtName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.txtName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(224, 21)
            Me.txtName.TabIndex = 6
            Me.txtName.TabStop = False
            Me.txtName.Text = ""
            '
            'txtAddress
            '
            Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAddress, "")
            Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.txtAddress.Location = New System.Drawing.Point(80, 72)
            Me.txtAddress.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtAddress, "")
            Me.Validator.SetMinValue(Me.txtAddress, "")
            Me.txtAddress.Name = "txtAddress"
            Me.txtAddress.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAddress, "")
            Me.Validator.SetRequired(Me.txtAddress, False)
            Me.txtAddress.Size = New System.Drawing.Size(224, 21)
            Me.txtAddress.TabIndex = 10
            Me.txtAddress.TabStop = False
            Me.txtAddress.Text = ""
            '
            'cmbProvince
            '
            Me.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbProvince.Enabled = False
            Me.cmbProvince.Location = New System.Drawing.Point(424, 24)
            Me.cmbProvince.MaxLength = 255
            Me.cmbProvince.Name = "cmbProvince"
            Me.cmbProvince.Size = New System.Drawing.Size(256, 21)
            Me.cmbProvince.TabIndex = 4
            Me.cmbProvince.TabStop = False
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(80, 24)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.txtCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(224, 21)
            Me.txtCode.TabIndex = 2
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'txtPhone
            '
            Me.Validator.SetDataType(Me.txtPhone, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPhone, "")
            Me.txtPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.txtPhone.Location = New System.Drawing.Point(424, 48)
            Me.txtPhone.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtPhone, "")
            Me.Validator.SetMinValue(Me.txtPhone, "")
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtPhone, "")
            Me.Validator.SetRequired(Me.txtPhone, False)
            Me.txtPhone.Size = New System.Drawing.Size(256, 21)
            Me.txtPhone.TabIndex = 8
            Me.txtPhone.TabStop = False
            Me.txtPhone.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 25)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(64, 18)
            Me.lblCode.TabIndex = 1
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(16, 49)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(64, 18)
            Me.lblName.TabIndex = 5
            Me.lblName.Text = "ชื่อ/ชื่ออื่น:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPhone
            '
            Me.lblPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPhone.ForeColor = System.Drawing.Color.Black
            Me.lblPhone.Location = New System.Drawing.Point(320, 48)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(104, 18)
            Me.lblPhone.TabIndex = 7
            Me.lblPhone.Text = "โทรศัพท์/โทรสาร:"
            Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProvince
            '
            Me.lblProvince.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProvince.ForeColor = System.Drawing.Color.Black
            Me.lblProvince.Location = New System.Drawing.Point(320, 24)
            Me.lblProvince.Name = "lblProvince"
            Me.lblProvince.Size = New System.Drawing.Size(104, 18)
            Me.lblProvince.TabIndex = 3
            Me.lblProvince.Text = "จังหวัด:"
            Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress
            '
            Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAddress.ForeColor = System.Drawing.Color.Black
            Me.lblAddress.Location = New System.Drawing.Point(16, 73)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(64, 18)
            Me.lblAddress.TabIndex = 9
            Me.lblAddress.Text = "ที่อยู่:"
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            'ibtnBlank
            '
            Me.ibtnBlank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(8, 424)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
            Me.ibtnBlank.TabIndex = 208
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(40, 424)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
            Me.ibtnDelRow.TabIndex = 207
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'SupMatDetail
            '
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.lblItem)
            Me.Name = "SupMatDetail"
            Me.Size = New System.Drawing.Size(768, 472)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As Supplier
        Private m_lcislink As SupplierLCICostLink
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = SupplierLCICostLink.GetSchemaTable
            Dim dst As DataGridTableStyle = Me.CreateTableStyle
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
            Dim dst As New DataGridTableStyle
            dst.MappingName = "LciCost"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "lcis_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "lcis_linenumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.CodeHeaderText}")
            csCode.NullText = ""
            'csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""

            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Width = 180
            csName.TextBox.Name = "Name"
            'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
            csName.ReadOnly = True

            Dim csCost As New TreeTextColumn
            csCost.MappingName = "lcis_cost"
            csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.CostHeaderText}")
            csCost.NullText = ""
            csCost.DataAlignment = HorizontalAlignment.Right
            csCost.Format = "#,###.##"
            csCost.TextBox.Name = "lcis_cost"
            'AddHandler csCost.TextBox.TextChanged, AddressOf ChangeProperty

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.UnitHeaderText}")
            csUnit.NullText = ""
            csUnit.TextBox.Name = "Unit"
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csUnitButton As New DataGridButtonColumn
            csUnitButton.MappingName = "UnitButton"
            csUnitButton.HeaderText = ""
            csUnitButton.NullText = ""
            AddHandler csUnitButton.Click, AddressOf ButtonClicked

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "lcis_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.DataAlignment = HorizontalAlignment.Right
            csNote.Format = "#,###.##"
            csNote.TextBox.Name = "lcis_note"
            'AddHandler csCost.TextBox.TextChanged, AddressOf ChangeProperty

            Dim csLeadTime As New TreeTextColumn
            csLeadTime.MappingName = "lcis_leadtime"
            csLeadTime.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.LeadTimeHeaderText}")
            csLeadTime.NullText = ""
            csLeadTime.DataAlignment = HorizontalAlignment.Right
            csLeadTime.Format = "0"
            csLeadTime.TextBox.Name = "lcis_leadtime"
            'AddHandler csCost.TextBox.TextChanged, AddressOf ChangeProperty

            Dim csCostDate As New DataGridTimePickerColumn
            csCostDate.MappingName = "lcis_costdate"
            csCostDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.CostDateHeaderText}")
            csCostDate.NullText = ""


            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csCost)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csUnitButton)
            dst.GridColumnStyles.Add(csNote)
            dst.GridColumnStyles.Add(csLeadTime)
            dst.GridColumnStyles.Add(csCostDate)
            Return dst
        End Function
        Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 2 Then
                Me.LCIButtonClick(e)
            Else
                Me.UnitButtonClick(e)
            End If
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            'If Me.m_entity.Canceled Then
            '    For Each ctrl As Control In grbLCI.Controls
            '        ctrl.Enabled = False
            '    Next
            'Else
            '    For Each ctrl As Control In grbLCI.Controls
            '        ctrl.Enabled = True
            '    Next
            'End If
        End Sub

        Public Overrides Sub ClearDetail()
            'Todo:
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupMatDetail.lblItem}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupMatDetail.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupMatDetail.lblCode}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupMatDetail.lblName}")
            Me.lblPhone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupMatDetail.lblPhone}")
            Me.lblProvince.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupMatDetail.lblProvince}")
            Me.lblAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupMatDetail.lblAddress}")
            Me.lblGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupMatDetail.lblGroup}")
        End Sub
        Protected Overrides Sub EventWiring()
            'ไม่มีการผูกเพราะไม่ต้องแก้ไข
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_lcislink Is Nothing Then
                Return
            End If

            Me.txtAddress.Text = Me.m_entity.Address
            Me.txtCode.Text = m_entity.Code
            Me.txtGroupCode.Text = m_entity.Group.Code
            Me.txtGroupName.Text = Me.m_entity.Group.Name
            Me.txtPhone.Text = Me.m_entity.Phone
            txtName.Text = m_entity.Name


            'Load Items**********************************************************
            Me.m_treeManager.Treetable = Me.m_lcislink.ItemTable
            AddHandler Me.m_lcislink.PropertyChanged, AddressOf PropChanged
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
                If Not Object.ReferenceEquals(Me.m_entity, Value) Then
                    Me.m_entity = Nothing
                    Me.m_entity = CType(Value, Supplier)
                    'If Not m_lcislink Is Nothing Then
                    '    RemoveHandler Me.m_lcislink.PropertyChanged, AddressOf PropChanged
                    '    Me.m_lcislink = Nothing
                    'End If
                    'm_lcislink = m_entity.SupplierLCICostLink
                    'If m_lcislink Is Nothing Then
                    '    m_lcislink = New SupplierLCICostLink
                    '    m_lcislink.Supplier.SupplierLCICostLink = m_lcislink
                    'End If
                    'm_lcislink.Supplier = m_entity
                End If
                'If Not Me.m_lcislink Is Nothing Then
                '    Me.m_lcislink.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                'End If
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()
            'PopulateRequestor()
            'PopulateCostCenter()
        End Sub


#End Region

#Region "Event Handlers"
        Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
            If m_entity Is Nothing Then
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filters(0) As Filter
            Dim includeFilter As Boolean = False
            Dim row As TreeRow = Me.m_treeManager.Treetable.Childs(e.Row)
            Dim item As New SupplierLCICostLinkItem
            item.CopyFromDataRow(row)
            Dim idList As String = item.Lci.GetUnitIdList
            If idList.Length > 0 Then
                filters(0) = New Filter("includedId", idList)
            Else
                filters(0) = New Filter("includedId", "-1")
            End If
            myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
        End Sub
        Private Sub SetUnit(ByVal unit As ISimpleEntity)
            Me.m_treeManager.SelectedRow("Unit") = unit.Code
        End Sub
        Public Sub LCIButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filters(0) As Filter
            filters(0) = New Filter("IDList", GenIDListFromDataTable())
            myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetItems, filters)
        End Sub
        Private Function GenIDListFromDataTable() As String
            Dim idlist As String = ""
            For Each row As TreeRow In Me.m_lcislink.ItemTable.Rows
                If Not IsDBNull(row("lcis_lci")) Then
                    idlist &= CStr(row("lcis_lci")) & ","
                End If
            Next
            If idlist.EndsWith(",") Then
                idlist = idlist.Remove(idlist.Length - 1, 1)
            End If
            Return idlist
        End Function
        Private Sub SetItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                If i = items.Count - 1 Then
                    If Me.m_lcislink.ItemTable.Childs.Count = 0 Then
                        Me.m_lcislink.AddBlankRow(1)
                        Me.m_lcislink.ItemTable.Childs(0)("Code") = item.Code
                    Else
                        Me.m_lcislink.ItemTable.Childs(index)("Code") = item.Code
                    End If
                Else
                    Me.m_lcislink.Insert(index, New SupplierLCICostLinkItem)
                    Me.m_lcislink.ItemTable.Childs(index)("Code") = item.Code
                End If
                Me.m_lcislink.ItemTable.AcceptChanges()
            Next
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim myItem As New SupplierLCICostLinkItem
            myItem.Lci = New LCIItem
            myItem.Cost = 0
            Me.m_lcislink.Insert(index, myItem)
            Me.m_lcislink.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Me.m_lcislink.Remove(index)
            Me.tgItem.CurrentRowIndex = index
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
                Return (New WitholdingTax).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Grid Resizing"
        Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Me.m_lcislink Is Nothing Then
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
            Do While Me.m_lcislink.ItemTable.Childs.Count < maxVisibleCount - 1
                'เพิ่มแถวจนเต็ม
                Me.m_lcislink.AddBlankRow(1)
            Loop
            If Me.m_lcislink.MaxRowIndex = maxVisibleCount - 2 Then
                If Me.m_lcislink.ItemTable.Childs.Count < maxVisibleCount - 1 Then
                    'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                    Me.m_lcislink.AddBlankRow(1)
                End If
            End If
            Do While Me.m_lcislink.ItemTable.Childs.Count > maxVisibleCount - 1 And Me.m_lcislink.ItemTable.Childs.Count - 2 <> Me.m_lcislink.MaxRowIndex
                'ลบแถวที่ไม่จำเป็น
                Me.m_lcislink.Remove(Me.m_lcislink.ItemTable.Childs.Count - 1)
            Loop
            Me.m_lcislink.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

#Region "After the main entity has been saved"
        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            If Not successful Then
                Return
            End If
            Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
        Public Overrides Sub NotifyBeforeSave()
            MyBase.NotifyBeforeSave()
            Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
#End Region

    End Class
End Namespace