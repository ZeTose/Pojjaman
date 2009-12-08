Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class WBSMilestoneDetail
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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents tvWbs As System.Windows.Forms.TreeView
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents grbSummarize As System.Windows.Forms.GroupBox
        Friend WithEvents lblLevel As System.Windows.Forms.Label
        Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents cmbMilestone As System.Windows.Forms.ComboBox
        Friend WithEvents lblMilestone As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBSMilestoneDetail))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbMilestone = New System.Windows.Forms.ComboBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.lblMilestone = New System.Windows.Forms.Label
            Me.tvWbs = New System.Windows.Forms.TreeView
            Me.lblItem = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbSummarize = New System.Windows.Forms.GroupBox
            Me.lblLevel = New System.Windows.Forms.Label
            Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbDetail.SuspendLayout()
            Me.grbSummarize.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.cmbMilestone)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.txtNote)
            Me.grbDetail.Controls.Add(Me.lblNote)
            Me.grbDetail.Controls.Add(Me.lblMilestone)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(752, 120)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียดหมวดงาน"
            '
            'cmbMilestone
            '
            Me.cmbMilestone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbMilestone.Location = New System.Drawing.Point(72, 88)
            Me.cmbMilestone.Name = "cmbMilestone"
            Me.cmbMilestone.Size = New System.Drawing.Size(664, 21)
            Me.cmbMilestone.TabIndex = 6
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(64, 18)
            Me.lblCode.TabIndex = 5
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(72, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(128, 22)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(72, 40)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(664, 22)
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 40)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(64, 18)
            Me.lblName.TabIndex = 4
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(72, 64)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(664, 22)
            Me.txtNote.TabIndex = 2
            Me.txtNote.Text = ""
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 64)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(64, 18)
            Me.lblNote.TabIndex = 3
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMilestone
            '
            Me.lblMilestone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMilestone.ForeColor = System.Drawing.Color.Black
            Me.lblMilestone.Location = New System.Drawing.Point(8, 88)
            Me.lblMilestone.Name = "lblMilestone"
            Me.lblMilestone.Size = New System.Drawing.Size(64, 18)
            Me.lblMilestone.TabIndex = 3
            Me.lblMilestone.Text = "งวดงาน:"
            Me.lblMilestone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tvWbs
            '
            Me.tvWbs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tvWbs.FullRowSelect = True
            Me.tvWbs.HideSelection = False
            Me.tvWbs.ImageIndex = -1
            Me.tvWbs.Location = New System.Drawing.Point(8, 176)
            Me.tvWbs.Name = "tvWbs"
            Me.tvWbs.SelectedImageIndex = -1
            Me.tvWbs.Size = New System.Drawing.Size(752, 376)
            Me.tvWbs.TabIndex = 1
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 160)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(208, 23)
            Me.lblItem.TabIndex = 9
            Me.lblItem.Text = "BOQ Work Breakdown Structure"
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
            'grbSummarize
            '
            Me.grbSummarize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbSummarize.Controls.Add(Me.lblLevel)
            Me.grbSummarize.Controls.Add(Me.ibtnZoomOut)
            Me.grbSummarize.Controls.Add(Me.ibtnZoomIn)
            Me.grbSummarize.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSummarize.Location = New System.Drawing.Point(240, 128)
            Me.grbSummarize.Name = "grbSummarize"
            Me.grbSummarize.Size = New System.Drawing.Size(112, 48)
            Me.grbSummarize.TabIndex = 15
            Me.grbSummarize.TabStop = False
            Me.grbSummarize.Text = "Summarize"
            '
            'lblLevel
            '
            Me.lblLevel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLevel.Location = New System.Drawing.Point(64, 16)
            Me.lblLevel.Name = "lblLevel"
            Me.lblLevel.Size = New System.Drawing.Size(40, 23)
            Me.lblLevel.TabIndex = 13
            Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ibtnZoomOut
            '
            Me.ibtnZoomOut.Image = CType(resources.GetObject("ibtnZoomOut.Image"), System.Drawing.Image)
            Me.ibtnZoomOut.Location = New System.Drawing.Point(16, 16)
            Me.ibtnZoomOut.Name = "ibtnZoomOut"
            Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
            Me.ibtnZoomOut.TabIndex = 12
            Me.ibtnZoomOut.TabStop = False
            Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnZoomIn
            '
            Me.ibtnZoomIn.Image = CType(resources.GetObject("ibtnZoomIn.Image"), System.Drawing.Image)
            Me.ibtnZoomIn.Location = New System.Drawing.Point(40, 16)
            Me.ibtnZoomIn.Name = "ibtnZoomIn"
            Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
            Me.ibtnZoomIn.TabIndex = 11
            Me.ibtnZoomIn.TabStop = False
            Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
            '
            'WBSMilestoneDetail
            '
            Me.Controls.Add(Me.grbSummarize)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.tvWbs)
            Me.Controls.Add(Me.lblItem)
            Me.Name = "WBSMilestoneDetail"
            Me.Size = New System.Drawing.Size(776, 568)
            Me.grbDetail.ResumeLayout(False)
            Me.grbSummarize.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_wbs As WBS
        Private m_markup As Markup
        Private m_boq As BOQ
        Private m_entity As PaymentApplication
        Private m_isInitialized As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            EventWiring()
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_boq Is Nothing Then
                Return
            End If
            If Me.m_boq.Status.Value >= 3 OrElse Me.m_boq.Status.Value = 0 Then
                grbDetail.Enabled = False
            Else
                grbDetail.Enabled = True
            End If
        End Sub

        Public Overrides Sub ClearDetail()
            For Each crlt As Control In grbDetail.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_wbs Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_wbs.TabPageText)
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSMilestoneDetail.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSMilestoneDetail.lblCode}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSMilestoneDetail.lblItem}")
            Me.lblMilestone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSMilestoneDetail.lblMilestone}")
        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf TextHandler
            AddHandler txtCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
            AddHandler cmbMilestone.SelectedIndexChanged, AddressOf Me.ChangeProperty
        End Sub
        Private txtCodeChanged As Boolean = False
        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    txtCodeChanged = True
            End Select
        End Sub
        ' แสดงค่าข้อมูลของ WBS ลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_boq Is Nothing Then
                Return
            End If
            For Each w As WBS In m_boq.WBSCollection
                w.LoadMileStone()
            Next
            For Each m As Markup In m_boq.MarkupCollection
                m.LoadMileStone()
            Next
            If Me.m_boq.WBSCollection.Count = 0 Then
                Dim newWbs As New WBS
                newWbs.Parent = newWbs
                newWbs.Code = Me.m_boq.Project.Code
                newWbs.Name = Me.m_boq.Project.Name
                newWbs.Note = "<Default>"
                m_boq.WBSCollection.Add(newWbs)
            End If
            m_boq.WBSCollection.Populate(Me.tvWbs, Nothing, True)
            m_boq.MarkupCollection.PopulateAll(tvWbs.Nodes(0), True, True)
            Me.tvWbs.ExpandAll()
            If Me.tvWbs.Nodes.Count > 0 Then
                Me.tvWbs.SelectedNode = Me.tvWbs.Nodes(0)
            End If

            ListMilestone()

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Private Sub ListMilestone()
            Me.cmbMilestone.Items.Clear()
            Me.cmbMilestone.Items.Add(Me.StringParserService.Parse("${res:Global.Unspecified}"))
            Dim g As Graphics = Me.CreateGraphics
            Dim w As Single = 10.0!
            Dim ef1 As New SizeF(0.0!, 0.0!)
            For Each mi As Milestone In Me.m_entity.ItemCollection
                Me.cmbMilestone.Items.Add(mi)
                ef1 = g.MeasureString(mi.ToString, Me.Font)
                If (ef1.Width > w) Then
                    w = ef1.Width
                End If
            Next
            Me.cmbMilestone.DropDownWidth = CType(Math.Ceiling(CType(w, Double)), Integer)
            If cmbMilestone.Items.Count > 0 Then
                Me.cmbMilestone.SelectedIndex = 0
            End If
        End Sub
        Private Sub UpdateWBS()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            txtCode.Text = m_wbs.Code
            txtName.Text = m_wbs.Name
            txtNote.Text = m_wbs.Note
            ToggleEnable(True)
            Me.txtCodeChanged = False
            Dim found As Boolean = False
            For Each item As Object In Me.cmbMilestone.Items
                If TypeOf item Is Milestone Then
                    If m_wbs.Milestone Is item Or (m_wbs.Milestone.Id <> 0 And CType(item, Milestone).Id = m_wbs.Milestone.Id) Then
                        Me.cmbMilestone.SelectedItem = item
                        found = True
                        Exit For
                    End If
                End If
            Next
            If Not found And Me.cmbMilestone.Items.Count > 0 Then
                Me.cmbMilestone.SelectedIndex = 0
            End If
            Me.m_isInitialized = flag
        End Sub
        Private Sub UpdateMarkup()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            txtCode.Text = m_markup.Code
            txtName.Text = m_markup.Name
            txtNote.Text = m_markup.Note
            ToggleEnable(True)
            Me.txtCodeChanged = False
            Dim found As Boolean = False
            For Each item As Object In Me.cmbMilestone.Items
                If TypeOf item Is Milestone Then
                    If m_markup.Milestone Is item Or (m_markup.Milestone.Id <> 0 And CType(item, Milestone).Id = m_markup.Milestone.Id) Then
                        Me.cmbMilestone.SelectedItem = item
                        found = True
                        Exit For
                    End If
                End If
            Next
            If Not found And Me.cmbMilestone.Items.Count > 0 Then
                Me.cmbMilestone.SelectedIndex = 0
            End If
            Me.m_isInitialized = flag
        End Sub
        Private Sub ToggleEnable(ByVal flag As Boolean)
            txtCode.ReadOnly = flag
            txtName.ReadOnly = flag
            txtNote.ReadOnly = flag
        End Sub
        Private Sub UpdateNode(ByVal n As TreeNode)
            If TypeOf n.Tag Is WBS Then
                n.Text = CType(n.Tag, WBS).ToString & ":" & CType(n.Tag, WBS).Milestone.ToString
            ElseIf TypeOf n.Tag Is Markup Then
                n.Text = CType(n.Tag, Markup).ToString & ":" & CType(n.Tag, Markup).Milestone.ToString
            End If
        End Sub
        Private Sub ClearTextDetail()
            ToggleEnable(True)
            txtCode.Text = ""
            txtName.Text = ""
            txtNote.Text = ""
            If Me.cmbMilestone.Items.Count > 0 Then
                Me.cmbMilestone.SelectedIndex = 0
            End If
        End Sub
        Private Function DupCode(ByVal txt As TextBox) As Boolean
            For Each myWBS As WBS In Me.m_boq.WBSCollection
                If Not Me.m_wbs Is myWBS And myWBS.Code = txt.Text Then
                    Return True
                End If
            Next
            Return False
        End Function
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                'Case "txtcode"
                '    If txtCodeChanged Then
                '        txtCodeChanged = False
                '        If Not DupCode(txtCode) Then
                '            Me.m_wbs.Code = txtCode.Text
                '            UpdateNode()
                '            dirtyFlag = True
                '        Else
                '            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                '            msgServ.ShowMessageFormatted("${res:Global.Error.WBSCodeDup}", New String() {txtCode.Text})
                '            txtCode.Text = Me.m_wbs.Code
                '            dirtyFlag = True
                '        End If
                '    End If
                'Case "txtname"
                '    Me.m_wbs.Name = txtName.Text
                '    UpdateNode()
                '    dirtyFlag = True
                'Case "txtnote"
                '    Me.m_wbs.Note = txtNote.Text
                '    UpdateNode()
                '    dirtyFlag = True
            Case "cmbmilestone"
                    If TypeOf cmbMilestone.SelectedItem Is Milestone Then
                        m_selectedMi = CType(cmbMilestone.SelectedItem, Milestone)
                    Else
                        m_selectedMi = Nothing
                    End If
                    Me.tvWbs.BeginUpdate()
                    If Not Me.tvWbs.SelectedNode Is Nothing Then
                        TreeViewHelper.TraverseNode(Me.tvWbs.SelectedNode, AddressOf SetMilestoneToNode)
                    End If
                    Me.tvWbs.EndUpdate()
                    If Not Me.m_wbs Is Nothing Or Not Me.m_markup Is Nothing Then
                        dirtyFlag = True
                    End If
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Private m_selectedMi As Milestone
        Private Sub SetMilestoneToNode(ByVal n As TreeNode)
            If m_selectedMi Is Nothing Then
                Return
            End If
            If TypeOf n.Tag Is WBS Then
                CType(n.Tag, WBS).Milestone = m_selectedMi
            ElseIf TypeOf n.Tag Is Markup Then
                CType(n.Tag, Markup).Milestone = m_selectedMi
            End If
            UpdateNode(n)
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_boq
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = CType(Value, PaymentApplication)
                Me.m_boq = CType(Value, PaymentApplication).Boq
                UpdateEntityProperties()
            End Set
        End Property
        Public Overrides Sub Initialize()
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub tvWbs_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvWbs.BeforeSelect
            'If Me.IsDirty Then
            '    Dim resourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            '    Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.TitleName + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            '    Select Case dr
            '        Case DialogResult.Yes
            '            Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
            '            myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf Me.Save), CType(Me, ISimpleListPanel).SelectedEntity)
            '        Case DialogResult.No
            '            Me.IsDirty = False
            '        Case DialogResult.Cancel
            '            e.Cancel = True
            '            Return
            '    End Select
            'End If
            'If Me.tvWbs.SelectedNode Is Nothing OrElse Not TypeOf Me.tvWbs.SelectedNode.Tag Is IdValuePair Then
            '    Return
            'End If
            'Dim item As IdValuePair = CType(Me.tvWbs.SelectedNode.Tag, IdValuePair)
            'If item.Value = "glformat" And item.Id = 0 Then
            '    Me.tvWbs.SelectedNode.Remove()
            'End If
        End Sub
        Private Sub tvWbs_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvWbs.AfterSelect
            If TypeOf e.Node.Tag Is WBS Then
                Dim myWbs As WBS = CType(e.Node.Tag, WBS)
                Me.m_wbs = myWbs
                Me.m_markup = Nothing
                UpdateWBS()
            ElseIf TypeOf e.Node.Tag Is Markup Then
                Dim myMarkup As Markup = CType(e.Node.Tag, Markup)
                Me.m_markup = myMarkup
                Me.m_wbs = Nothing
                UpdateMarkup()
            Else
                Me.m_wbs = Nothing
                Me.m_markup = Nothing
                ClearTextDetail()
            End If
            WorkbenchSingleton.Workbench.RedrawEditComponents()
        End Sub
        Private nodeWasRef As Boolean = False
        Private Sub CheckNodeStatus(ByVal n As TreeNode)
            If TypeOf n.Tag Is WBS Then
                Dim myWbs As WBS = CType(n.Tag, WBS)
                If myWbs.Status.Value >= 3 Then
                    nodeWasRef = True
                End If
            ElseIf TypeOf n.Tag Is Markup Then
                Dim myMarkup As Markup = CType(n.Tag, Markup)
                If myMarkup.Status.Value >= 3 Then
                    nodeWasRef = True
                End If
            End If
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
                Return (New WBS).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnableCopy() As Boolean
            Get
                Return Me.tvWbs.Focused AndAlso Not Me.tvWbs.SelectedNode Is Nothing
            End Get
        End Property
        Public Overrides ReadOnly Property EnableCut() As Boolean
            Get
                Return False
            End Get
        End Property
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Return Me.tvWbs.Focused AndAlso Not Me.tvWbs.SelectedNode Is Nothing AndAlso Not m_copiedNode Is Nothing
            End Get
        End Property
        Private m_copiedNode As TreeNode
        Public Overrides Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs)
            m_copiedNode = CType(Me.tvWbs.SelectedNode.Clone, TreeNode)
            WorkbenchSingleton.Workbench.RedrawEditComponents()
        End Sub
        Private Sub CopyNode(ByVal n As TreeNode)
            If TypeOf n.Tag Is WBS Then
                Dim myWbs As WBS = CType(n.Tag, WBS)
                Dim newWbs As New WBS
                newWbs.Boq = myWbs.Boq
                newWbs.Code = myWbs.Code & "*"
                newWbs.Name = myWbs.Name
                newWbs.Note = myWbs.Note
                newWbs.AlternateName = myWbs.AlternateName
                n.Tag = newWbs
                n.Text = newWbs.ToString
                If Not n.Parent Is Nothing Then
                    If TypeOf n.Parent.Tag Is WBS Then
                        newWbs.Parent = CType(n.Parent.Tag, WBS)
                        newWbs.Level = newWbs.Parent.Level + 1
                    End If
                ElseIf Not Me.tvWbs.SelectedNode Is Nothing Then
                    If TypeOf Me.tvWbs.SelectedNode.Tag Is WBS Then
                        newWbs.Parent = CType(Me.tvWbs.SelectedNode.Tag, WBS)
                        newWbs.Level = newWbs.Parent.Level + 1
                    End If
                End If
                Me.m_boq.WBSCollection.Add(newWbs)
                For Each item As BoqItem In Me.m_boq.ItemCollection.GetCollectionForWBS(myWbs)
                    Dim newItem As New BoqItem
                    newItem.WBS = newWbs

                    newItem.Entity = item.Entity
                    newItem.EntityName = item.EntityName
                    newItem.ItemType = item.ItemType
                    newItem.Note = item.Note
                    newItem.Qty = item.Qty
                    newItem.UEC = item.UEC
                    newItem.ULC = item.ULC
                    newItem.UMC = item.UMC
                    newItem.Unit = item.Unit

                    Me.m_boq.ItemCollection.Add(newItem)
                Next
            End If
        End Sub
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            TreeViewHelper.TraverseNode(m_copiedNode, AddressOf CopyNode)
            Me.tvWbs.SelectedNode.Nodes.Add(m_copiedNode)
            m_copiedNode = CType(m_copiedNode.Clone, TreeNode)
            WorkbenchSingleton.Workbench.RedrawEditComponents()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
#End Region

#Region "IKeyReceiver"
        Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
            Select Case keyPressed
                'Case Keys.Insert
                '    ibtnBlank_Click(Nothing, Nothing)
                '    Return True
                'Case Keys.Delete
                '    If Me.tvWbs.Focused Then
                '        ibtnDelRow_Click(Nothing, Nothing)
                '        Return True
                '    Else
                '        Return False
                '    End If
                Case Else
                    Return False
            End Select
        End Function
#End Region

#Region "Summarize"
        Private m_level As Integer
        Private m_affected As Boolean
        Private Sub ibtnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomOut.Click
            If m_level > 0 Then
                m_level -= 1
            End If
            TreeViewHelper.TraverseNode(Me.tvWbs.Nodes(0), AddressOf Summarize, m_level)
            Me.lblLevel.Text = m_level.ToString()
        End Sub
        Private Sub ibtnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomIn.Click
            m_level += 1
            m_affected = False
            TreeViewHelper.TraverseNode(Me.tvWbs.Nodes(0), AddressOf Summarize, m_level)
            If Not m_affected Then
                m_level -= 1
            End If
            Me.lblLevel.Text = m_level.ToString()
        End Sub
        Private Sub Summarize(ByVal n As TreeNode)
            If Not m_affected Then
                m_affected = True
            End If
            n.Collapse()
            n.EnsureVisible()
        End Sub
#End Region

#Region "After the main entity has been saved"
        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            If Not successful Then
                Return
            End If
            Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
#End Region

    End Class
End Namespace