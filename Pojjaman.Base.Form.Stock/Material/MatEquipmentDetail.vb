Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MatEquipmentDetail
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
        Friend WithEvents ibtnAdd As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents grbLCI As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblAltName As System.Windows.Forms.Label
        Friend WithEvents txtAltName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtlv1 As System.Windows.Forms.TextBox
        Friend WithEvents lblLCI As System.Windows.Forms.Label
        Friend WithEvents txtlv5 As System.Windows.Forms.TextBox
        Friend WithEvents txtlv4 As System.Windows.Forms.TextBox
        Friend WithEvents txtlv3 As System.Windows.Forms.TextBox
        Friend WithEvents txtlv2 As System.Windows.Forms.TextBox
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MatEquipmentDetail))
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtName = New System.Windows.Forms.TextBox
            Me.txtAltName = New System.Windows.Forms.TextBox
            Me.txtlv1 = New System.Windows.Forms.TextBox
            Me.txtlv5 = New System.Windows.Forms.TextBox
            Me.txtlv4 = New System.Windows.Forms.TextBox
            Me.txtlv3 = New System.Windows.Forms.TextBox
            Me.txtlv2 = New System.Windows.Forms.TextBox
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbLCI = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblAltName = New System.Windows.Forms.Label
            Me.lblName = New System.Windows.Forms.Label
            Me.lblLCI = New System.Windows.Forms.Label
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblItem = New System.Windows.Forms.Label
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbLCI.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = True
            Me.tgItem.BackgroundColor = System.Drawing.Color.DimGray
            Me.tgItem.CaptionBackColor = System.Drawing.Color.SaddleBrown
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.GridLineColor = System.Drawing.Color.Wheat
            Me.tgItem.HeaderBackColor = System.Drawing.Color.Gold
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 152)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(736, 248)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 166
            Me.tgItem.TreeManager = Nothing
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(104, 40)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(248, 21)
            Me.txtName.TabIndex = 2
            Me.txtName.Text = ""
            '
            'txtAltName
            '
            Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAltName, "")
            Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.txtAltName.Location = New System.Drawing.Point(104, 64)
            Me.Validator.SetMaxValue(Me.txtAltName, "")
            Me.Validator.SetMinValue(Me.txtAltName, "")
            Me.txtAltName.Name = "txtAltName"
            Me.Validator.SetRegularExpression(Me.txtAltName, "")
            Me.Validator.SetRequired(Me.txtAltName, False)
            Me.txtAltName.Size = New System.Drawing.Size(248, 21)
            Me.txtAltName.TabIndex = 3
            Me.txtAltName.Text = ""
            '
            'txtlv1
            '
            Me.txtlv1.BackColor = System.Drawing.SystemColors.Info
            Me.Validator.SetDataType(Me.txtlv1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv1, "")
            Me.txtlv1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv1, System.Drawing.Color.Empty)
            Me.txtlv1.Location = New System.Drawing.Point(104, 16)
            Me.txtlv1.MaxLength = 2
            Me.Validator.SetMaxValue(Me.txtlv1, "")
            Me.Validator.SetMinValue(Me.txtlv1, "")
            Me.txtlv1.Name = "txtlv1"
            Me.txtlv1.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtlv1, "")
            Me.Validator.SetRequired(Me.txtlv1, False)
            Me.txtlv1.Size = New System.Drawing.Size(24, 23)
            Me.txtlv1.TabIndex = 163
            Me.txtlv1.Text = ""
            '
            'txtlv5
            '
            Me.txtlv5.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtlv5, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv5, "")
            Me.txtlv5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv5, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv5, System.Drawing.Color.Empty)
            Me.txtlv5.Location = New System.Drawing.Point(200, 16)
            Me.txtlv5.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtlv5, "")
            Me.Validator.SetMinValue(Me.txtlv5, "")
            Me.txtlv5.Name = "txtlv5"
            Me.Validator.SetRegularExpression(Me.txtlv5, "")
            Me.Validator.SetRequired(Me.txtlv5, False)
            Me.txtlv5.Size = New System.Drawing.Size(56, 23)
            Me.txtlv5.TabIndex = 167
            Me.txtlv5.Text = ""
            '
            'txtlv4
            '
            Me.txtlv4.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtlv4, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv4, "")
            Me.txtlv4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv4, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv4, System.Drawing.Color.Empty)
            Me.txtlv4.Location = New System.Drawing.Point(176, 16)
            Me.txtlv4.MaxLength = 2
            Me.Validator.SetMaxValue(Me.txtlv4, "")
            Me.Validator.SetMinValue(Me.txtlv4, "")
            Me.txtlv4.Name = "txtlv4"
            Me.txtlv4.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtlv4, "")
            Me.Validator.SetRequired(Me.txtlv4, False)
            Me.txtlv4.Size = New System.Drawing.Size(24, 23)
            Me.txtlv4.TabIndex = 166
            Me.txtlv4.Text = ""
            '
            'txtlv3
            '
            Me.txtlv3.BackColor = System.Drawing.SystemColors.Info
            Me.Validator.SetDataType(Me.txtlv3, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv3, "")
            Me.txtlv3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv3, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv3, System.Drawing.Color.Empty)
            Me.txtlv3.Location = New System.Drawing.Point(152, 16)
            Me.txtlv3.MaxLength = 2
            Me.Validator.SetMaxValue(Me.txtlv3, "")
            Me.Validator.SetMinValue(Me.txtlv3, "")
            Me.txtlv3.Name = "txtlv3"
            Me.txtlv3.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtlv3, "")
            Me.Validator.SetRequired(Me.txtlv3, False)
            Me.txtlv3.Size = New System.Drawing.Size(24, 23)
            Me.txtlv3.TabIndex = 165
            Me.txtlv3.Text = ""
            '
            'txtlv2
            '
            Me.txtlv2.BackColor = System.Drawing.SystemColors.Info
            Me.Validator.SetDataType(Me.txtlv2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv2, "")
            Me.txtlv2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv2, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv2, System.Drawing.Color.Empty)
            Me.txtlv2.Location = New System.Drawing.Point(128, 16)
            Me.txtlv2.MaxLength = 2
            Me.Validator.SetMaxValue(Me.txtlv2, "")
            Me.Validator.SetMinValue(Me.txtlv2, "")
            Me.txtlv2.Name = "txtlv2"
            Me.txtlv2.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtlv2, "")
            Me.Validator.SetRequired(Me.txtlv2, False)
            Me.txtlv2.Size = New System.Drawing.Size(24, 23)
            Me.txtlv2.TabIndex = 164
            Me.txtlv2.Text = ""
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(8, 400)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
            Me.ibtnBlank.TabIndex = 210
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(40, 400)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
            Me.ibtnDelRow.TabIndex = 209
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
            '
            'grbLCI
            '
            Me.grbLCI.Controls.Add(Me.txtName)
            Me.grbLCI.Controls.Add(Me.lblAltName)
            Me.grbLCI.Controls.Add(Me.txtAltName)
            Me.grbLCI.Controls.Add(Me.lblName)
            Me.grbLCI.Controls.Add(Me.txtlv1)
            Me.grbLCI.Controls.Add(Me.lblLCI)
            Me.grbLCI.Controls.Add(Me.txtlv5)
            Me.grbLCI.Controls.Add(Me.txtlv4)
            Me.grbLCI.Controls.Add(Me.txtlv3)
            Me.grbLCI.Controls.Add(Me.txtlv2)
            Me.grbLCI.Enabled = False
            Me.grbLCI.Location = New System.Drawing.Point(16, 24)
            Me.grbLCI.Name = "grbLCI"
            Me.grbLCI.Size = New System.Drawing.Size(368, 96)
            Me.grbLCI.TabIndex = 178
            Me.grbLCI.TabStop = False
            Me.grbLCI.Text = "LCI"
            '
            'lblAltName
            '
            Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAltName.ForeColor = System.Drawing.Color.Black
            Me.lblAltName.Location = New System.Drawing.Point(8, 64)
            Me.lblAltName.Name = "lblAltName"
            Me.lblAltName.Size = New System.Drawing.Size(96, 18)
            Me.lblAltName.TabIndex = 8
            Me.lblAltName.Text = "ชื่ออื่น:"
            Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 40)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(96, 18)
            Me.lblName.TabIndex = 11
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLCI
            '
            Me.lblLCI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLCI.ForeColor = System.Drawing.Color.Black
            Me.lblLCI.Location = New System.Drawing.Point(16, 16)
            Me.lblLCI.Name = "lblLCI"
            Me.lblLCI.Size = New System.Drawing.Size(88, 20)
            Me.lblLCI.TabIndex = 168
            Me.lblLCI.Text = "LCI Code:"
            Me.lblLCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.ibtnBlank)
            Me.grbDetail.Controls.Add(Me.ibtnDelRow)
            Me.grbDetail.Controls.Add(Me.tgItem)
            Me.grbDetail.Controls.Add(Me.lblItem)
            Me.grbDetail.Controls.Add(Me.grbLCI)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(752, 448)
            Me.grbDetail.TabIndex = 179
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียด"
            '
            'lblItem
            '
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 136)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(168, 18)
            Me.lblItem.TabIndex = 165
            Me.lblItem.Text = "Supplier:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MatEquipmentDetail
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "MatEquipmentDetail"
            Me.Size = New System.Drawing.Size(776, 464)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbLCI.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As LCIItem
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = LCIEquipmentCostLink.GetSchemaTable
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
            dst.MappingName = "EquipmentCost"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)


            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "lcil_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "lcil_linenumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf ButtonClick

            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Width = 180
            csName.TextBox.Name = "Name"
            'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
            csName.ReadOnly = True

            Dim csCost As New TreeTextColumn
            csCost.MappingName = "Cost"
            csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.CostHeaderText}")
            csCost.NullText = ""
            csCost.DataAlignment = HorizontalAlignment.Right
            csCost.Format = "#,###.##"
            csCost.TextBox.Name = "Cost"
            csCost.ReadOnly = True
            'AddHandler csCost.TextBox.TextChanged, AddressOf ChangeProperty

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.UnitHeaderText}")
            csUnit.NullText = ""
            csUnit.TextBox.Name = "Unit"
            csUnit.ReadOnly = True
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "lcil_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.DataAlignment = HorizontalAlignment.Left
            csNote.TextBox.Name = "lcil_note"
            'AddHandler csCost.TextBox.TextChanged, AddressOf ChangeProperty

            Dim csCostDate As New DataGridTimePickerColumn
            csCostDate.MappingName = "CostDate"
            csCostDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.CostDateHeaderText}")
            csCostDate.NullText = ""

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csCost)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csNote)
            dst.GridColumnStyles.Add(csCostDate)
            Return dst
        End Function
        Public Sub ButtonClick(ByVal e As ButtonColumnEventArgs)
            Me.EqCostButtonClick(e)
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
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.lblItem}")
            Me.lblAltName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.lblAltName}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.lblName}")
            Me.grbLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.grbLCI}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatEquipmentDetail.grbDetail}")
        End Sub
        Protected Overrides Sub EventWiring()
            'ไม่มีการผูกเพราะไม่ต้องแก้ไข
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.LCIEquipmentCostLink Is Nothing Then
                Return
            End If

            txtName.Text = m_entity.Name
            txtAltName.Text = m_entity.AlternateName
            txtlv1.Text = m_entity.Lv1
            txtlv2.Text = m_entity.Lv2
            txtlv3.Text = m_entity.Lv3
            txtlv4.Text = m_entity.Lv4
            txtlv5.Text = m_entity.Lv5

            'Load Items**********************************************************
            Me.m_treeManager.Treetable = Nothing
            Me.m_treeManager.Treetable = Me.m_entity.LCIEquipmentCostLink.ItemTable
            AddHandler Me.m_entity.LCIEquipmentCostLink.PropertyChanged, AddressOf PropChanged
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
                    Me.m_entity = CType(Value, LCIItem)
                    If Not Me.m_entity.LCIEquipmentCostLink Is Nothing Then
                        RemoveHandler Me.m_entity.LCIEquipmentCostLink.PropertyChanged, AddressOf PropChanged
                    End If
                End If
                If Not Me.m_entity.LCIEquipmentCostLink Is Nothing Then
                    Me.m_entity.LCIEquipmentCostLink.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                End If
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
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
        End Sub
        Private Sub SetUnit(ByVal unit As ISimpleEntity)
            Me.m_treeManager.SelectedRow("Unit") = unit.Code
        End Sub
        Public Sub EqCostButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New EqCost, AddressOf SetItems)
        End Sub
        Private Sub SetItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim eqc As EqCost
                Dim myItem As New LCIEquipmentCostLinkItem
                eqc = New EqCost(item.Id)
                myItem.EqCost = eqc
                If i = items.Count - 1 Then
                    If Me.m_entity.LCIEquipmentCostLink.ItemTable.Childs.Count = 0 Then
                        Me.m_entity.LCIEquipmentCostLink.Add(myItem)
                    Else
                        myItem.LineNumber = CInt(Me.m_entity.LCIEquipmentCostLink.ItemTable.Childs(index)("lcil_linenumber"))
                        myItem.LCIEquipmentCostLink = Me.m_entity.LCIEquipmentCostLink
                        myItem.CopyToDataRow(Me.m_entity.LCIEquipmentCostLink.ItemTable.Childs(index))
                    End If
                Else
                    Me.m_entity.LCIEquipmentCostLink.Insert(index, myItem)
                End If
                Me.m_entity.LCIEquipmentCostLink.ItemTable.AcceptChanges()
            Next
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim myItem As New LCIEquipmentCostLinkItem
            myItem.EqCost = New EqCost
            Me.m_entity.LCIEquipmentCostLink.Insert(index, myItem)
            Me.m_entity.LCIEquipmentCostLink.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Me.m_entity.LCIEquipmentCostLink.Remove(index)
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
            If Me.m_entity.LCIEquipmentCostLink Is Nothing Then
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

            Do Until Me.m_entity.LCIEquipmentCostLink.ItemTable.Rows.Count > tgItem.VisibleRowCount
                'เพิ่มแถวจนเต็ม
                Me.m_entity.LCIEquipmentCostLink.AddBlankRow(1)
            Loop

            'MessageBox.Show(tgItem.VisibleRowCount.ToString & ":" & Me.m_entity.ItemTable.Childs.Count.ToString)

            If Me.m_entity.LCIEquipmentCostLink.MaxRowIndex = Me.m_entity.LCIEquipmentCostLink.ItemTable.Childs.Count - 1 Then
                'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                Me.m_entity.LCIEquipmentCostLink.AddBlankRow(1)
            End If
            Me.m_entity.LCIEquipmentCostLink.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

#Region "After the main entity has been saved"
        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            'If Not successful Then
            '    Return
            'End If
            'Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
        Public Overrides Sub NotifyBeforeSave()
            '    MyBase.NotifyBeforeSave()
            '    Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
#End Region

    End Class
End Namespace