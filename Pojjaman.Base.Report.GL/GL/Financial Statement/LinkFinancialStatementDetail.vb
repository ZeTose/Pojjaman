Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class LinkFinancialStatementDetail
        Inherits AbstractEntityPanelViewContent
        Implements IValidatable, ISimpleListPanel

#Region " Members "
        Private m_entity As FinancialFormat

        Private m_tableStyleEnable As Hashtable
        Private m_enableState As Hashtable

        Private m_treeManager As TreeManager
        Private m_isInitialized As Boolean
#End Region

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
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents tvLinkFinancial As System.Windows.Forms.TreeView
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents chkDefault As System.Windows.Forms.CheckBox
        Friend WithEvents lblReportType As System.Windows.Forms.Label
        Friend WithEvents cmbReportType As System.Windows.Forms.ComboBox
        Friend WithEvents grbHeader As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblTreeview As System.Windows.Forms.Label
        Friend WithEvents ibtnItemBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnItemDelrow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents ibtnInsertBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents Button1 As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LinkFinancialStatementDetail))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbHeader = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblReportType = New System.Windows.Forms.Label
            Me.cmbReportType = New System.Windows.Forms.ComboBox
            Me.chkDefault = New System.Windows.Forms.CheckBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.tvLinkFinancial = New System.Windows.Forms.TreeView
            Me.lblTreeview = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ibtnItemBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnItemDelrow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.ibtnInsertBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.Button1 = New System.Windows.Forms.Button
            Me.grbHeader.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(96, 18)
            Me.lblCode.TabIndex = 183
            Me.lblCode.Text = "รหัส"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(112, 21)
            Me.txtCode.TabIndex = 182
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'grbHeader
            '
            Me.grbHeader.Controls.Add(Me.lblReportType)
            Me.grbHeader.Controls.Add(Me.cmbReportType)
            Me.grbHeader.Controls.Add(Me.chkDefault)
            Me.grbHeader.Controls.Add(Me.lblNote)
            Me.grbHeader.Controls.Add(Me.txtNote)
            Me.grbHeader.Controls.Add(Me.lblCode)
            Me.grbHeader.Controls.Add(Me.txtCode)
            Me.grbHeader.Controls.Add(Me.txtName)
            Me.grbHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbHeader.Location = New System.Drawing.Point(240, 8)
            Me.grbHeader.Name = "grbHeader"
            Me.grbHeader.Size = New System.Drawing.Size(488, 96)
            Me.grbHeader.TabIndex = 2
            Me.grbHeader.TabStop = False
            Me.grbHeader.Text = "grbHeader"
            '
            'lblReportType
            '
            Me.lblReportType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReportType.ForeColor = System.Drawing.Color.Black
            Me.lblReportType.Location = New System.Drawing.Point(8, 40)
            Me.lblReportType.Name = "lblReportType"
            Me.lblReportType.Size = New System.Drawing.Size(96, 18)
            Me.lblReportType.TabIndex = 197
            Me.lblReportType.Text = "ประเภทรายงาน"
            Me.lblReportType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbReportType
            '
            Me.cmbReportType.Location = New System.Drawing.Point(112, 40)
            Me.cmbReportType.Name = "cmbReportType"
            Me.cmbReportType.Size = New System.Drawing.Size(200, 21)
            Me.cmbReportType.TabIndex = 196
            '
            'chkDefault
            '
            Me.chkDefault.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkDefault.Location = New System.Drawing.Point(320, 43)
            Me.chkDefault.Name = "chkDefault"
            Me.chkDefault.Size = New System.Drawing.Size(104, 16)
            Me.chkDefault.TabIndex = 195
            Me.chkDefault.Text = "Default"
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 64)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(96, 18)
            Me.lblNote.TabIndex = 185
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(112, 64)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(360, 21)
            Me.txtNote.TabIndex = 184
            Me.txtNote.TabStop = False
            Me.txtNote.Text = ""
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(224, 16)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(248, 21)
            Me.txtName.TabIndex = 182
            Me.txtName.TabStop = False
            Me.txtName.Text = ""
            '
            'tvLinkFinancial
            '
            Me.tvLinkFinancial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tvLinkFinancial.FullRowSelect = True
            Me.tvLinkFinancial.HideSelection = False
            Me.tvLinkFinancial.ImageIndex = -1
            Me.tvLinkFinancial.Location = New System.Drawing.Point(8, 16)
            Me.tvLinkFinancial.Name = "tvLinkFinancial"
            Me.tvLinkFinancial.SelectedImageIndex = -1
            Me.tvLinkFinancial.Size = New System.Drawing.Size(224, 400)
            Me.tvLinkFinancial.TabIndex = 194
            Me.tvLinkFinancial.TabStop = False
            '
            'lblTreeview
            '
            Me.lblTreeview.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTreeview.ForeColor = System.Drawing.Color.Black
            Me.lblTreeview.Location = New System.Drawing.Point(8, 0)
            Me.lblTreeview.Name = "lblTreeview"
            Me.lblTreeview.Size = New System.Drawing.Size(168, 18)
            Me.lblTreeview.TabIndex = 184
            Me.lblTreeview.Text = "lblTreeview"
            Me.lblTreeview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Nothing
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'ibtnItemBlank
            '
            Me.ibtnItemBlank.Image = CType(resources.GetObject("ibtnItemBlank.Image"), System.Drawing.Image)
            Me.ibtnItemBlank.Location = New System.Drawing.Point(360, 112)
            Me.ibtnItemBlank.Name = "ibtnItemBlank"
            Me.ibtnItemBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnItemBlank.TabIndex = 196
            Me.ibtnItemBlank.TabStop = False
            Me.ibtnItemBlank.ThemedImage = CType(resources.GetObject("ibtnItemBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnItemDelrow
            '
            Me.ibtnItemDelrow.Image = CType(resources.GetObject("ibtnItemDelrow.Image"), System.Drawing.Image)
            Me.ibtnItemDelrow.Location = New System.Drawing.Point(408, 112)
            Me.ibtnItemDelrow.Name = "ibtnItemDelrow"
            Me.ibtnItemDelrow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnItemDelrow.TabIndex = 197
            Me.ibtnItemDelrow.TabStop = False
            Me.ibtnItemDelrow.ThemedImage = CType(resources.GetObject("ibtnItemDelrow.ThemedImage"), System.Drawing.Bitmap)
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
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(240, 136)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(584, 280)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 195
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(240, 112)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(112, 18)
            Me.lblItem.TabIndex = 198
            Me.lblItem.Text = "รายการ"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'ibtnInsertBlank
            '
            Me.ibtnInsertBlank.Image = CType(resources.GetObject("ibtnInsertBlank.Image"), System.Drawing.Image)
            Me.ibtnInsertBlank.Location = New System.Drawing.Point(384, 112)
            Me.ibtnInsertBlank.Name = "ibtnInsertBlank"
            Me.ibtnInsertBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnInsertBlank.TabIndex = 200
            Me.ibtnInsertBlank.TabStop = False
            Me.ibtnInsertBlank.ThemedImage = CType(resources.GetObject("ibtnInsertBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(736, 40)
            Me.Button1.Name = "Button1"
            Me.Button1.TabIndex = 201
            Me.Button1.Text = "Button1"
            '
            'LinkFinancialStatementDetail
            '
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.ibtnInsertBlank)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.ibtnItemBlank)
            Me.Controls.Add(Me.ibtnItemDelrow)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.tvLinkFinancial)
            Me.Controls.Add(Me.grbHeader)
            Me.Controls.Add(Me.lblTreeview)
            Me.Name = "LinkFinancialStatementDetail"
            Me.Size = New System.Drawing.Size(832, 424)
            Me.grbHeader.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " Constructors "
        Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
            MyBase.New()
            InitializeComponent()

            m_entity = New FinancialFormat
            SaveEnableState()
            m_tableStyleEnable = New Hashtable

            LinkFinancial.Populate(Me.tvLinkFinancial, filters)


            Dim dt As TreeTable = FinancialFormat.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            EventWiring()
            Initialize()

            'initial entity
            ToggleVisibility(False)
            Me.UpdateEntityProperties()
            Me.TitleName = m_entity.TabPageText
        End Sub
        Private Sub SaveEnableState()
            m_enableState = New Hashtable
            For Each ctrl As Control In Me.grbHeader.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
            'For Each ctrl As Control In Me.grbPostGl.Controls
            '    m_enableState.Add(ctrl, ctrl.Enabled)
            'Next
        End Sub
#End Region

#Region " Style "
        Private Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "LinkFinancialItem"

            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            ' line number 
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "linki_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.GridLineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "linki_linenumber"

            ' itemtype 
            Dim csLinkType As DataGridComboColumn
            'If m_entity Is Nothing Then
            '    csBSType = New DataGridComboColumn("linki_linktype" _
            '    , CodeDescription.GetCodeList("financialstatement_list") _
            '    , "code_description", "code_value")
            'Else
            '    'If m_entity.LinkType.Value = 1 Then
            '    '    csBSType = New DataGridComboColumn("BSType" _
            '    '                    , CodeDescription.GetCodeList("balancesheet_list") _
            '    '                    , "code_description", "code_value")
            '    'Else
            '    '    csBSType = New DataGridComboColumn("BSType" _
            '    '                    , CodeDescription.GetCodeList("profitlost_list") _
            '    '                    , "code_description", "code_value")
            '    'End If
            'End If
            csLinkType = New DataGridComboColumn("linki_linktype" _
                , CodeDescription.GetCodeList("financialstatement_list") _
                , "code_description", "code_value")
            csLinkType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.GridLinkTypeHeaderText}")
            csLinkType.NullText = String.Empty
            csLinkType.ReadOnly = True
            csLinkType.Alignment = HorizontalAlignment.Center

            ' rownum หมายเลข line number
            Dim csCode As New TreeTextColumn
            csCode.MappingName = "linki_code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.GridCodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 45
            csCode.ReadOnly = True
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Center
            csCode.TextBox.Name = "linki_code"

            ' item
            'Dim csItem As New TreeTextColumn
            Dim csName As New TreeTextColumn
            csName.MappingName = "linki_name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.GridNameHeaderText}")
            csName.NullText = ""
            csName.Width = 150
            csName.ReadOnly = False
            csName.Alignment = HorizontalAlignment.Center
            csName.DataAlignment = HorizontalAlignment.Left
            csName.TextBox.Name = "linki_name"

            ' Name style
            Dim csNameStyle As New DataGridButtonColumn
            csNameStyle.MappingName = "btn_namestyle"
            csNameStyle.HeaderText = ""
            csNameStyle.NullText = ""
            AddHandler csNameStyle.Click, AddressOf ButtonClicked

            ' item
            'Dim csItem As New TreeTextColumn
            Dim csNote As New TreeTextColumn
            csNote.MappingName = "linki_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.GridNoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 150
            csNote.ReadOnly = False
            csNote.Alignment = HorizontalAlignment.Center
            csNote.DataAlignment = HorizontalAlignment.Left
            csNote.TextBox.Name = "linki_note"

            ' Note style
            Dim csNoteStyle As New DataGridButtonColumn
            csNoteStyle.MappingName = "btn_notestyle"
            csNoteStyle.HeaderText = ""
            csNoteStyle.NullText = ""
            'AddHandler csNameStyle.Click, AddressOf ButtonClicked

            Dim csFormular As New TreeTextColumn
            csFormular.MappingName = "linki_formular"
            csFormular.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.GridFormularHeaderText}")
            csFormular.NullText = ""
            csFormular.Width = 150
            csFormular.ReadOnly = False
            csFormular.Alignment = HorizontalAlignment.Center
            csFormular.DataAlignment = HorizontalAlignment.Left
            csFormular.TextBox.Name = "linki_formular"

            ' Formular style
            Dim csFormularStyle As New DataGridButtonColumn
            csFormularStyle.MappingName = "btn_formularstyle"
            csFormularStyle.HeaderText = ""
            csFormularStyle.NullText = ""

            Dim csIsNewpage As New DataGridCheckBoxColumn
            csIsNewpage.MappingName = "linki_isnewpage"
            csIsNewpage.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.GridIsNewPageHeaderText}")
            csIsNewpage.Width = 50
            csIsNewpage.InvisibleWhenUnspcified = True

            Dim csLineStyle As DataGridComboColumn
            csLineStyle = New DataGridComboColumn("linki_linestyle" _
                , CodeDescription.GetCodeList("line_style") _
                , "code_description", "code_value")
            csLineStyle.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.GridLineStyleHeaderText}")
            csLineStyle.NullText = String.Empty
            csLineStyle.ReadOnly = False
            csLineStyle.Alignment = HorizontalAlignment.Center

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csNameStyle)
            dst.GridColumnStyles.Add(csLinkType)
            dst.GridColumnStyles.Add(csNote)
            dst.GridColumnStyles.Add(csNoteStyle)
            dst.GridColumnStyles.Add(csFormular)
            dst.GridColumnStyles.Add(csFormularStyle)
            dst.GridColumnStyles.Add(csIsNewpage)
            dst.GridColumnStyles.Add(csLineStyle)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next

            Return dst
        End Function
        Public Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 5 Then
                AccountButtonClicked(e)
            Else
                SetFontStyle(e)
            End If
        End Sub
#End Region

#Region "ISimpleListPanel"
        Public Sub ChangeTitle(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleListPanel.ChangeTitle

        End Sub
        Public Sub CheckFormEnable() Implements ISimplePanel.CheckFormEnable

        End Sub
        Public Sub ClearDetail() Implements ISimplePanel.ClearDetail
            txtCode.Text = ""
            txtName.Text = ""
            txtNote.Text = ""
            chkDefault.Checked = False
            cmbReportType.SelectedIndex = -1
            cmbReportType.SelectedIndex = -1
        End Sub
        Public Sub SetLabelText() Implements ISimplePanel.SetLabelText
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

            Me.lblTreeview.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.lblTreeview}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.lblCode}")
            Me.lblReportType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.lblReportType}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.chkDefault.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.chkDefault}")
            ' Group box 
            Me.grbHeader.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.grbHeader}")
            'Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFinancialStatementDetail.lblItem}")
        End Sub
        Protected Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
            AddHandler chkDefault.CheckedChanged, AddressOf Me.ChangeProperty

            AddHandler cmbReportType.SelectedValueChanged, AddressOf Me.ChangeProperty
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            txtCode.Text = m_entity.Code
            txtName.Text = m_entity.Name
            txtNote.Text = m_entity.Note

            For Each item As IdValuePair In Me.cmbReportType.Items
                If Me.m_entity.ReportType.Value = item.Id Then    ' แก้ต่อนะ
                    Me.cmbReportType.SelectedItem = item
                End If
            Next

            Me.chkDefault.Checked = Me.m_entity.IsDefault
            Me.chkDefault.Enabled = Not Me.m_entity.IsDefault

            'Load Items**********************************************************
            Me.m_treeManager.Treetable = Me.m_entity.ItemTable
            AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
            Me.Validator.DataTable = m_treeManager.Treetable
            '********************************************************************

            'Hack
            Me.IsDirty = False

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                    dirtyFlag = True
                Case "txtname"
                    Me.m_entity.Name = txtName.Text
                    dirtyFlag = True
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True
                Case "chkdefault"
                    Me.m_entity.IsDefault = Me.chkDefault.Checked
                    dirtyFlag = True
                Case "cmbreporttype"
                    Dim PairId As IdValuePair = CType(Me.cmbReportType.SelectedItem, IdValuePair)
                    Me.m_entity.ReportType = New LinkFinancialType(PairId.Id)
                    dirtyFlag = True
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If e.Name = "ItemChanged" Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

        End Sub

        Public ReadOnly Property Title() As String Implements ISimplePanel.Title
            Get
                If Not m_entity Is Nothing Then
                    Return Me.m_entity.ListPanelTitle
                End If
            End Get
        End Property
        Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)

            End Set
        End Property

        Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

        Public Sub AddNew() Implements ISimpleListPanel.AddNew
            Dim node As TreeNode = Me.tvLinkFinancial.SelectedNode
            If node Is Nothing Then
                Return
            End If
            If TypeOf node.Tag Is IdValuePair Then
                Dim item As IdValuePair = CType(node.Tag, IdValuePair)
                Select Case item.Value.ToLower
                    Case "reporttype"
                        Dim finf As New FinancialFormat(New LinkFinancialType(item.Id))
                        Me.m_entity = finf
                        Me.m_entity.Name = "<NEW>"

                        Dim newNode As TreeNode = node.Nodes.Add("<NEW>")
                        newNode.Tag = New IdValuePair(finf.Id, "financialformat")
                        Me.SelectedEntity = finf
                        Me.tvLinkFinancial.SelectedNode = newNode
                        Me.ToggleVisibility(True)
                        Return
                    Case "financialformat"
                        Dim parentItem As IdValuePair = CType(node.Parent.Tag, IdValuePair)
                        Dim finf As New FinancialFormat(New LinkFinancialType(parentItem.Id))
                        Me.m_entity = finf
                        Me.m_entity.Name = "<NEW>"

                        Dim newNode As TreeNode = node.Parent.Nodes.Add("<NEW>")
                        newNode.Tag = New IdValuePair(finf.Id, "financialformat")
                        Me.SelectedEntity = finf
                        Me.tvLinkFinancial.SelectedNode = newNode
                        Me.ToggleVisibility(True)
                        Return
                End Select
            End If
            ToggleVisibility(False)
        End Sub

        Private Sub OnEntitySelected(ByVal entity As ISimpleEntity)
            RaiseEvent EntitySelected(entity)
        End Sub
        Public Event EntitySelected(ByVal entity As BusinessLogic.ISimpleEntity) Implements ISimpleListPanel.EntitySelected

        Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData

        End Sub

        Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)
                If Not m_entity Is Nothing Then
                    RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
                    Me.m_entity = Nothing
                End If
                If Not Value Is Nothing Then
                    Me.m_entity = CType(Value, FinancialFormat)
                    'Hack:
                    Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                End If
                UpdateEntityProperties()
            End Set
        End Property
        Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
            Get

            End Get
        End Property

        Public Sub Initialize() Implements ISimplePanel.Initialize
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbReportType, "financialstatement_type")
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub ToggleVisibility(ByVal show As Boolean)
            If Not show Then
                For Each ctrl As Control In Me.grbHeader.Controls
                    ctrl.Enabled = False
                Next
                'For Each ctrl As Control In Me.grbItem.Controls
                '    ctrl.Enabled = False
                'Next
                Me.tgItem.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.ErrorProvider1.SetError(Me.txtName, "")
            Else
                For Each ctrl As Control In Me.grbHeader.Controls
                    ctrl.Enabled = CBool(m_enableState(ctrl))
                Next
                'For Each ctrl As Control In Me.grbItem.Controls
                '    ctrl.Enabled = CBool(m_enableState(ctrl))
                'Next
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next

                RefreshBlankGrid()

            End If
        End Sub
        Private Sub tvLinkFinancial_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvLinkFinancial.BeforeSelect
            If Me.IsDirty Then
                Dim resourceService As resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), resourceService)
                Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.TitleName + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case dr
                    Case DialogResult.Yes
                        Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
                        myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf Me.Save), CType(Me, ISimpleListPanel).SelectedEntity)
                    Case DialogResult.No
                        Me.IsDirty = False
                    Case DialogResult.Cancel
                        e.Cancel = True
                        Return
                End Select
            End If
            If Me.tvLinkFinancial.SelectedNode Is Nothing OrElse Not TypeOf Me.tvLinkFinancial.SelectedNode.Tag Is IdValuePair Then
                Return
            End If
            Dim item As IdValuePair = CType(Me.tvLinkFinancial.SelectedNode.Tag, IdValuePair)
            If item.Value = "financialformat" And item.Id = 0 Then
                Me.tvLinkFinancial.SelectedNode.Remove()
            End If
        End Sub
        Private Sub tvLinkFinancial_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvLinkFinancial.AfterSelect
            If TypeOf e.Node.Tag Is IdValuePair Then
                Dim item As IdValuePair = CType(e.Node.Tag, IdValuePair)
                Select Case item.Value.ToLower
                    Case "financialformat"
                        If item.Id > 0 Then
                            Me.SelectedEntity = New FinancialFormat(item.Id)
                        End If
                        If e.Node.Parent.Nodes.IndexOf(e.Node) = 0 Then
                            ToggleVisibility(False)
                        Else
                            ToggleVisibility(True)
                        End If
                    Case "reporttype"
                        Dim finf As New FinancialFormat(New LinkFinancialType(item.Id))
                        Me.SelectedEntity = finf
                        ToggleVisibility(False)
                    Case Else
                        ToggleVisibility(False)
                End Select
            Else
                Me.m_isInitialized = False
                ClearDetail()
                Me.m_isInitialized = True
                Me.SelectedEntity = Nothing
                ToggleVisibility(False)
            End If
            WorkbenchSingleton.Workbench.RedrawAllComponents()
        End Sub
        Private Sub tvLinkFinancial_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvLinkFinancial.DoubleClick
            If SelectedEntity Is Nothing Then
                Return
            End If
            Me.OnEntitySelected(Me.SelectedEntity)
            If Not Me.FindForm Is Nothing AndAlso TypeOf Me.FindForm Is Gui.Dialogs.PanelDialog Then
                Me.FindForm.Close()
            End If
        End Sub
        Private ReadOnly Property StandardFont() As Font
            Get
                Return New Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            End Get
        End Property

        Private Function FontToString(ByVal f As System.Drawing.Font) As String
            If f Is Nothing Then
                Return "Tahoma,8.25,0"
            End If
            Dim strs(2) As String
            strs(0) = f.FontFamily.Name
            strs(1) = f.Size.ToString
            strs(2) = f.Style.GetHashCode.ToString
            Dim str As String = strs(0) & "," & strs(1) & "," & strs(2)
            Return str
        End Function
        Private Function StringToFont(ByVal str As String) As System.Drawing.Font
            If str.Length = 0 Then
                Return New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
            End If
            Dim strs() As String = str.Split(CType(",", Char))
            Dim f As System.Drawing.Font
            Try
                Dim ffamily As String = strs(0)
                Dim fsize As Single = CSng(strs(1))
                Dim fs As FontStyle = CType(strs(2), FontStyle)
                f = New Font(ffamily, fsize, fs)
            Catch ex As Exception
                f = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
            End Try
            Return f
        End Function
        Public Sub SetFontStyle(ByVal e As ButtonColumnEventArgs)
            Dim theRow As TreeRow = m_treeManager.SelectedRow
            If theRow Is Nothing Then
                Return
            End If
            Dim fnt As System.Drawing.Font
            Dim dialog As New FontDialog
            With dialog
                .MinSize = 6
                .MaxSize = 72
                Select Case e.Column
                    Case 3
                        .Font = Me.StringToFont(CStr(IIf(theRow.IsNull("linki_namestyle"), "", theRow("linki_namestyle"))))
                    Case 6
                        .Font = Me.StringToFont(CStr(IIf(theRow.IsNull("linki_notestyle"), "", theRow("linki_notestyle"))))
                    Case 8
                        .Font = Me.StringToFont(CStr(IIf(theRow.IsNull("linki_formularstyle"), "", theRow("linki_formularstyle"))))
                    Case Else
                        .Font = Me.StandardFont
                End Select
                If .ShowDialog = DialogResult.OK Then
                    fnt = .Font
                End If
            End With

            Dim fntstr As String = Me.FontToString(fnt)
            Select Case e.Column
                Case 3
                    theRow("linki_namestyle") = fntstr
                Case 6
                    theRow("linki_notestyle") = fntstr
                Case 8
                    theRow("linki_formularstyle") = fntstr
                Case Else

            End Select
        End Sub
        Public Sub AccountButtonClicked(ByVal e As ButtonColumnEventArgs)
            Dim theRow As TreeRow = m_treeManager.SelectedRow
            Dim item As New FinancialFormatItem(theRow, "")
            If theRow Is Nothing Then
                Return
            Else
                If CStr(theRow("button")).ToLower = "invisible" Then
                    Return
                End If
            End If
            Dim filters(0) As Filter
            filters(0) = New Filter("CodeList", GenIDListFromDataTable(item.LinkType.Value, theRow))

            Dim acct As New Account
            Dim entities As New ArrayList
            acct.Type = New AccountType(item.LinkType.Value)
            entities.Add(acct)
            'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'm_filterSubPanel = myEntityPanelService.GetFilterSubPanel(m_entity, entities)

            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            If Not item Is Nothing AndAlso item.LinkType.Value > 0 Then
                myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccts, filters, entities)
            Else
                myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccts, filters, Nothing)
            End If
        End Sub
        Private Sub SetAccts(ByVal items As BasketItemCollection)
            Dim acctList As String = ""
            For i As Integer = 0 To items.Count - 1
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim myItem As New Account(item.Id)
                If myItem.IsControlGroup Then
                    ' ToDo :
                Else
                    acctList += "|" & myItem.Code & "|"
                End If
            Next
            Dim theRow As TreeRow = m_treeManager.SelectedRow
            theRow("linki_formular") = acctList
            Me.m_treeManager.Treetable.AcceptChanges()
            'RefreshBlankGrid()
        End Sub
        Private Function GenIDListFromDataTable(ByVal itemType As Integer, ByVal theRow As TreeRow) As String
            Dim idlist As String = ""
            Me.m_treeManager.Treetable.AcceptChanges()
            For Each row As TreeRow In Me.m_treeManager.Treetable.Select("linki_linktype = " & itemType.ToString)
                If Not row Is theRow Then
                    If Not row.IsNull("linki_formular") Then
                        Dim formular As String = CStr(row("linki_formular"))
                        idlist += formular
                    End If
                End If
            Next
            Dim des As CodeDescription
            Return idlist
        End Function
        Private Sub LinkfinancialDetail_Saved(ByVal sender As Object, ByVal e As SaveEventArgs) Handles MyBase.Saved
            If Not e.Successful Then
                Return
            End If
            Me.tvLinkFinancial.SelectedNode.Text = Me.m_entity.Code & " - " & Me.m_entity.Name
            Me.tvLinkFinancial.SelectedNode.Tag = New IdValuePair(Me.m_entity.Id, "financialformat")
            Me.chkDefault.Enabled = Not Me.m_entity.IsDefault
        End Sub
#End Region

#Region "Overrides"
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Return Me.m_entity.ListPanelTitle
            End Get
        End Property
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnableDelete() As Boolean
            Get
                Dim node As TreeNode = Me.tvLinkFinancial.SelectedNode
                If node Is Nothing Then
                    Return False
                End If
                If Not TypeOf node.Tag Is IdValuePair Then
                    Return False
                End If
                Dim item As IdValuePair = CType(node.Tag, IdValuePair)
                If item.Value <> "financialformat" Then
                    Return False
                End If
                If node.Parent.Nodes.IndexOf(node) = 0 Then
                    Return False
                End If
                Return True
            End Get
        End Property
        Public Overrides Sub Delete(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim msg As String = Me.m_entity.Delete.Message
            If Not IsNumeric(msg) Then
                MessageBox.Show(msg)
                Return
            End If
            If Not Me.tvLinkFinancial.SelectedNode Is Nothing Then
                Me.tvLinkFinancial.SelectedNode.Remove()
            End If
            MessageBox.Show("Deleted")
        End Sub
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Account).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "tgitem"
                            Return True
                    End Select
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.ActiveControl Is Nothing Then
                Return
            End If
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Account).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
                Dim entity As New Account(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "tgitem"
                        'Me.SetAccount(entity)
                End Select
            End If
        End Sub
#End Region

#Region "Grid Resizing"
        Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
            If Me.m_entity Is Nothing Then
                Return
            End If
            'RefreshBlankGrid()
        End Sub
        Private Sub RefreshBlankGrid()
            If Me.tgItem.Height = 0 Then
                Return
            End If
            'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim maxVisibleCount As Integer
            Dim tgRowHeight As Integer = 17
            maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
            Do While Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1
                'เพิ่มแถวจนเต็ม
                Me.m_entity.AddBlankRow(1)
            Loop
            If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
                If Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1 Then
                    'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                    Me.m_entity.AddBlankRow(1)
                End If
            End If
            'Do While Me.m_entity.ItemTable.Rows.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Rows.Count - 2 <> Me.m_entity.MaxRowIndex
            '    'ลบแถวที่ไม่จำเป็น
            '    Me.m_entity.Remove(Me.m_entity.ItemTable.Rows.Count - 1)
            'Loop
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

#Region " Button Events "
        Private Sub ibtnItemBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnItemBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.MaxRowIndex Then
                Return
            End If
            'Dim row As TreeRow = CType(Me.m_entity.ItemTable.Rows(index), TreeRow)
            'If row.Level = 0 Then
            '    Return
            'End If
            'Dim parRow As TreeRow = CType(row.Parent, TreeRow)
            'If Not IsDBNull(parRow("poi_po")) AndAlso CStr(parRow("poi_po")).Length > 0 AndAlso CInt(parRow("poi_po")) > 0 Then
            '    Return
            'End If
            Dim theItem As New FinancialFormatItem
            Me.m_entity.Add(theItem)
            'Me.m_entity.Insert(index, theItem)
            Me.m_entity.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = index
            'RefreshBlankGrid()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
#End Region
    End Class
End Namespace