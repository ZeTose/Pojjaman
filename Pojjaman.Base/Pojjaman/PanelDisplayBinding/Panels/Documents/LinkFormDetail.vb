Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class LinkFormDetail
        Inherits AbstractEntityPanelViewContent
        Implements IValidatable, ISimpleListPanel

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
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents chkDefault As System.Windows.Forms.CheckBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents tvLinkForm As System.Windows.Forms.TreeView
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblFormat As System.Windows.Forms.Label
        Friend WithEvents txtFormatCode As System.Windows.Forms.TextBox
        Friend WithEvents txtFormatName As System.Windows.Forms.TextBox
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbForm As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbFormFormat As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblForm As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.grbForm = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.chkDefault = New System.Windows.Forms.CheckBox
            Me.lblFormat = New System.Windows.Forms.Label
            Me.txtFormatCode = New System.Windows.Forms.TextBox
            Me.tvLinkForm = New System.Windows.Forms.TreeView
            Me.lblForm = New System.Windows.Forms.Label
            Me.grbFormFormat = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtFormatName = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbForm.SuspendLayout()
            Me.grbFormFormat.SuspendLayout()
            Me.grbItem.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(24, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(72, 18)
            Me.lblCode.TabIndex = 183
            Me.lblCode.Text = "ฟอร์ม:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(96, 24)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.txtCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(56, 21)
            Me.txtCode.TabIndex = 182
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
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
            Me.tgItem.Location = New System.Drawing.Point(16, 24)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(552, 224)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 0
            Me.tgItem.TreeManager = Nothing
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(96, 64)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(472, 21)
            Me.txtNote.TabIndex = 3
            Me.txtNote.TabStop = False
            Me.txtNote.Text = ""
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(24, 64)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(72, 18)
            Me.lblNote.TabIndex = 183
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbForm
            '
            Me.grbForm.Controls.Add(Me.lblCode)
            Me.grbForm.Controls.Add(Me.txtCode)
            Me.grbForm.Controls.Add(Me.txtName)
            Me.grbForm.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbForm.Location = New System.Drawing.Point(240, 8)
            Me.grbForm.Name = "grbForm"
            Me.grbForm.Size = New System.Drawing.Size(576, 56)
            Me.grbForm.TabIndex = 2
            Me.grbForm.TabStop = False
            Me.grbForm.Text = "ฟอร์ม"
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(152, 24)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.txtName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(416, 21)
            Me.txtName.TabIndex = 182
            Me.txtName.TabStop = False
            Me.txtName.Text = ""
            '
            'chkDefault
            '
            Me.chkDefault.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkDefault.Location = New System.Drawing.Point(96, 42)
            Me.chkDefault.Name = "chkDefault"
            Me.chkDefault.Size = New System.Drawing.Size(104, 16)
            Me.chkDefault.TabIndex = 194
            Me.chkDefault.Text = "Default"
            '
            'lblFormat
            '
            Me.lblFormat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFormat.Location = New System.Drawing.Point(8, 16)
            Me.lblFormat.Name = "lblFormat"
            Me.lblFormat.Size = New System.Drawing.Size(88, 18)
            Me.lblFormat.TabIndex = 189
            Me.lblFormat.Text = "รูปแบบฟอร์ม:"
            Me.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtFormatCode
            '
            Me.txtFormatCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtFormatCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFormatCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtFormatCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFormatCode, System.Drawing.Color.Empty)
            Me.txtFormatCode.Location = New System.Drawing.Point(96, 16)
            Me.Validator.SetMaxValue(Me.txtFormatCode, "")
            Me.Validator.SetMinValue(Me.txtFormatCode, "")
            Me.txtFormatCode.Name = "txtFormatCode"
            Me.Validator.SetRegularExpression(Me.txtFormatCode, "")
            Me.Validator.SetRequired(Me.txtFormatCode, True)
            Me.txtFormatCode.Size = New System.Drawing.Size(56, 20)
            Me.txtFormatCode.TabIndex = 0
            Me.txtFormatCode.Text = ""
            '
            'tvLinkForm
            '
            Me.tvLinkForm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tvLinkForm.FullRowSelect = True
            Me.tvLinkForm.HideSelection = False
            Me.tvLinkForm.ImageIndex = -1
            Me.tvLinkForm.Location = New System.Drawing.Point(8, 16)
            Me.tvLinkForm.Name = "tvLinkForm"
            Me.tvLinkForm.SelectedImageIndex = -1
            Me.tvLinkForm.Size = New System.Drawing.Size(224, 408)
            Me.tvLinkForm.TabIndex = 194
            Me.tvLinkForm.TabStop = False
            '
            'lblForm
            '
            Me.lblForm.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblForm.ForeColor = System.Drawing.Color.Black
            Me.lblForm.Location = New System.Drawing.Point(8, 0)
            Me.lblForm.Name = "lblForm"
            Me.lblForm.Size = New System.Drawing.Size(168, 18)
            Me.lblForm.TabIndex = 184
            Me.lblForm.Text = "ฟอร์ม:"
            Me.lblForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbFormFormat
            '
            Me.grbFormFormat.Controls.Add(Me.lblNote)
            Me.grbFormFormat.Controls.Add(Me.txtNote)
            Me.grbFormFormat.Controls.Add(Me.txtFormatName)
            Me.grbFormFormat.Controls.Add(Me.lblFormat)
            Me.grbFormFormat.Controls.Add(Me.chkDefault)
            Me.grbFormFormat.Controls.Add(Me.txtFormatCode)
            Me.grbFormFormat.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbFormFormat.Location = New System.Drawing.Point(240, 64)
            Me.grbFormFormat.Name = "grbFormFormat"
            Me.grbFormFormat.Size = New System.Drawing.Size(576, 96)
            Me.grbFormFormat.TabIndex = 0
            Me.grbFormFormat.TabStop = False
            Me.grbFormFormat.Text = "กำหนดรูปแบบฟอร์ม"
            '
            'txtFormatName
            '
            Me.Validator.SetDataType(Me.txtFormatName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFormatName, "")
            Me.txtFormatName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtFormatName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFormatName, System.Drawing.Color.Empty)
            Me.txtFormatName.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMaxValue(Me.txtFormatName, "")
            Me.Validator.SetMinValue(Me.txtFormatName, "")
            Me.txtFormatName.Name = "txtFormatName"
            Me.Validator.SetRegularExpression(Me.txtFormatName, "")
            Me.Validator.SetRequired(Me.txtFormatName, True)
            Me.txtFormatName.Size = New System.Drawing.Size(416, 21)
            Me.txtFormatName.TabIndex = 1
            Me.txtFormatName.Text = ""
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
            'grbItem
            '
            Me.grbItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbItem.Controls.Add(Me.tgItem)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(240, 168)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(576, 256)
            Me.grbItem.TabIndex = 1
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "grbItem"
            '
            'LinkFormDetail
            '
            Me.Controls.Add(Me.grbItem)
            Me.Controls.Add(Me.tvLinkForm)
            Me.Controls.Add(Me.grbForm)
            Me.Controls.Add(Me.lblForm)
            Me.Controls.Add(Me.grbFormFormat)
            Me.Name = "LinkFormDetail"
            Me.Size = New System.Drawing.Size(832, 432)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbForm.ResumeLayout(False)
            Me.grbFormFormat.ResumeLayout(False)
            Me.grbItem.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


#Region "Members"
        Private m_entity As FormFormat
        Private m_treeManager As TreeManager

        Private m_isInitialized As Boolean
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
            MyBase.New()
            InitializeComponent()

            m_entity = New FormFormat


            LinkForm.Populate(Me.tvLinkForm, filters)


            Dim dt As TreeTable = FormFormat.GetSchemaTable()
            Dim dst As DataGridTableStyle = FormFormat.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            EventWiring()

            'initial entity
            Me.UpdateEntityProperties()
            Me.TitleName = m_entity.TabPageText
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
            txtFormatCode.Text = ""
            txtFormatName.Text = ""
            txtNote.Text = ""
            chkDefault.Checked = False
        End Sub
        Public Sub SetLabelText() Implements ISimplePanel.SetLabelText
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFormDetail.lblCode}")
            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFormDetail.lblItem}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.grbForm.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFormDetail.grbForm}")
            Me.chkDefault.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFormDetail.chkDefault}")
            Me.lblFormat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFormDetail.lblFormat}")
            Me.lblForm.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFormDetail.lblForm}")
            Me.grbFormFormat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkFormDetail.grbFormFormat}")
        End Sub
        Protected Sub EventWiring()
            AddHandler txtFormatCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtFormatName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
            AddHandler chkDefault.CheckedChanged, AddressOf Me.ChangeProperty
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            txtCode.Text = m_entity.LinkForm.Code
            txtName.Text = m_entity.LinkForm.Name
            txtNote.Text = m_entity.Note


            Me.chkDefault.Checked = Me.m_entity.IsDefault
            Me.chkDefault.Enabled = Not Me.m_entity.IsDefault

            txtFormatCode.Text = m_entity.Code
            txtFormatName.Text = m_entity.Name

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
                Case "txtformatcode"
                    Me.m_entity.Code = txtFormatCode.Text
                    dirtyFlag = True
                Case "txtformatname"
                    Me.m_entity.Name = txtFormatName.Text
                    dirtyFlag = True
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True
                Case "chkdefault"
                    Me.m_entity.IsDefault = Me.chkDefault.Checked
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
            Dim node As TreeNode = Me.tvLinkForm.SelectedNode
            If node Is Nothing Then
                Return
            End If
            If TypeOf node.Tag Is IdValuePair Then
                Dim item As IdValuePair = CType(node.Tag, IdValuePair)
                Select Case item.Value.ToLower
                    Case "linkform"
                        Dim ff As New FormFormat(New LinkForm(item.Id))
                        Dim newNode As TreeNode = node.Nodes.Add("<NEW>")
                        newNode.Tag = New IdValuePair(ff.Id, "formformat")
                        Me.SelectedEntity = ff
                        Me.tvLinkForm.SelectedNode = newNode
                        Return
                    Case "formformat"
                        Dim parentItem As IdValuePair = CType(node.Parent.Tag, IdValuePair)
                        Dim ff As New FormFormat(New LinkForm(parentItem.Id))
                        Dim newNode As TreeNode = node.Parent.Nodes.Add("<NEW>")
                        newNode.Tag = New IdValuePair(ff.Id, "formformat")
                        Me.SelectedEntity = ff
                        Me.tvLinkForm.SelectedNode = newNode
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
                Me.m_entity = CType(Value, FormFormat)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property
        Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
            Get

            End Get
        End Property

        Public Sub Initialize() Implements ISimplePanel.Initialize

        End Sub
#End Region

#Region "Event Handlers"
        Private Sub ToggleVisibility(ByVal show As Boolean)
            If Me.SecurityService.CurrentUser.Id = 1 Then
                show = True
            End If
            Me.grbFormFormat.Enabled = show
            Me.grbItem.Enabled = show
            If Not show Then
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.ErrorProvider1.SetError(Me.txtName, "")
            End If
        End Sub
        Private Sub tvLinkForm_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvLinkForm.BeforeSelect
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
            If Me.tvLinkForm.SelectedNode Is Nothing OrElse Not TypeOf Me.tvLinkForm.SelectedNode.Tag Is IdValuePair Then
                Return
            End If
            Dim item As IdValuePair = CType(Me.tvLinkForm.SelectedNode.Tag, IdValuePair)
            If item.Value = "formformat" And item.Id = 0 Then
                Me.tvLinkForm.SelectedNode.Remove()
            End If
        End Sub
        Private Sub tvLinkForm_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvLinkForm.AfterSelect
            If TypeOf e.Node.Tag Is IdValuePair Then
                Dim item As IdValuePair = CType(e.Node.Tag, IdValuePair)
                Select Case item.Value.ToLower
                    Case "formformat"
                        If item.Id > 0 Then
                            Me.SelectedEntity = New FormFormat(item.Id)
                        End If
                        If e.Node.Parent.Nodes.IndexOf(e.Node) = 0 Then
                            ToggleVisibility(False)
                        Else
                            ToggleVisibility(True)
                        End If
                    Case "linkform"
                        Dim ff As New FormFormat(New LinkForm(item.Id))
                        Me.SelectedEntity = ff
                        ToggleVisibility(False)
                    Case Else
                        ToggleVisibility(False)
                End Select
            Else
                ClearDetail()
                ToggleVisibility(False)
            End If
            WorkbenchSingleton.Workbench.RedrawAllComponents()
        End Sub
        Private Sub tvLinkForm_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvLinkForm.DoubleClick
            If SelectedEntity Is Nothing Then
                Return
            End If
            Me.OnEntitySelected(Me.SelectedEntity)
            If Not Me.FindForm Is Nothing AndAlso TypeOf Me.FindForm Is Gui.Dialogs.PanelDialog Then
                Me.FindForm.Close()
            End If
        End Sub
        Private Sub LinkFormDetail_Saved(ByVal sender As Object, ByVal e As SaveEventArgs) Handles MyBase.Saved
            If Not e.Successful Then
                Return
            End If
            Me.tvLinkForm.SelectedNode.Text = Me.m_entity.Code & " - " & Me.m_entity.Name
            Me.tvLinkForm.SelectedNode.Tag = New IdValuePair(Me.m_entity.Id, "formformat")
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
                Dim node As TreeNode = Me.tvLinkForm.SelectedNode
                If node Is Nothing Then
                    Return False
                End If
                If Not TypeOf node.Tag Is IdValuePair Then
                    Return False
                End If
                Dim item As IdValuePair = CType(node.Tag, IdValuePair)
                If item.Value <> "formformat" Then
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
            If Not Me.tvLinkForm.SelectedNode Is Nothing Then
                Me.tvLinkForm.SelectedNode.Remove()
            End If
            MessageBox.Show("Deleted")
        End Sub
#End Region

    End Class
End Namespace