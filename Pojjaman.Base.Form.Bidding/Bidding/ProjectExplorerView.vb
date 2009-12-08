Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ProjectExplorerView
        Inherits AbstractEntityDetailPanelView


#Region "Members"
        Private m_entity As LCIItem
        Private m_owner As IListPanel
        Private m_isInitialized As Boolean = False

#End Region

#Region "Properties"

#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            EventWiring()

        End Sub
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
        Friend WithEvents grbBOQ As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents tvProject As System.Windows.Forms.TreeView
        Friend WithEvents lvBOQ As Longkong.Pojjaman.Gui.Components.PJMListView
        Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Friend WithEvents Code As System.Windows.Forms.ColumnHeader
        Friend WithEvents grbProject As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ImageButton2 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton3 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton4 As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "BOQ001"}, -1)
            Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "BOQ002"}, -1)
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProjectExplorerView))
            Me.grbBOQ = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lvBOQ = New Longkong.Pojjaman.Gui.Components.PJMListView
            Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
            Me.Code = New System.Windows.Forms.ColumnHeader
            Me.grbProject = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.tvProject = New System.Windows.Forms.TreeView
            Me.ImageButton2 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton3 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton4 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbBOQ.SuspendLayout()
            Me.grbProject.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbBOQ
            '
            Me.grbBOQ.Controls.Add(Me.lvBOQ)
            Me.grbBOQ.Controls.Add(Me.ImageButton2)
            Me.grbBOQ.Controls.Add(Me.ImageButton3)
            Me.grbBOQ.Controls.Add(Me.ImageButton4)
            Me.grbBOQ.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbBOQ.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbBOQ.Location = New System.Drawing.Point(336, 16)
            Me.grbBOQ.Name = "grbBOQ"
            Me.grbBOQ.Size = New System.Drawing.Size(424, 416)
            Me.grbBOQ.TabIndex = 125
            Me.grbBOQ.TabStop = False
            Me.grbBOQ.Text = "BOQ"
            '
            'lvBOQ
            '
            Me.lvBOQ.AllowSort = True
            Me.lvBOQ.CheckBoxes = True
            Me.lvBOQ.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.Code})
            Me.lvBOQ.FullRowSelect = True
            Me.lvBOQ.GridLines = True
            Me.lvBOQ.HideSelection = False
            ListViewItem1.StateImageIndex = 0
            ListViewItem2.StateImageIndex = 0
            Me.lvBOQ.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
            Me.lvBOQ.Location = New System.Drawing.Point(8, 48)
            Me.lvBOQ.Name = "lvBOQ"
            Me.lvBOQ.Size = New System.Drawing.Size(408, 360)
            Me.lvBOQ.SortIndex = -1
            Me.lvBOQ.SortOrder = System.Windows.Forms.SortOrder.None
            Me.lvBOQ.TabIndex = 9
            Me.lvBOQ.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader1
            '
            Me.ColumnHeader1.Text = "Submitted"
            Me.ColumnHeader1.Width = 69
            '
            'Code
            '
            Me.Code.Text = "Code"
            Me.Code.Width = 106
            '
            'grbProject
            '
            Me.grbProject.Controls.Add(Me.tvProject)
            Me.grbProject.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbProject.Location = New System.Drawing.Point(16, 16)
            Me.grbProject.Name = "grbProject"
            Me.grbProject.Size = New System.Drawing.Size(312, 416)
            Me.grbProject.TabIndex = 126
            Me.grbProject.TabStop = False
            Me.grbProject.Text = "โครงการ"
            '
            'tvProject
            '
            Me.tvProject.ImageIndex = -1
            Me.tvProject.Location = New System.Drawing.Point(8, 16)
            Me.tvProject.Name = "tvProject"
            Me.tvProject.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Project1", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Addenda")}), New System.Windows.Forms.TreeNode("Project2"), New System.Windows.Forms.TreeNode("Project3")})
            Me.tvProject.SelectedImageIndex = -1
            Me.tvProject.Size = New System.Drawing.Size(296, 392)
            Me.tvProject.TabIndex = 0
            '
            'ImageButton2
            '
            Me.ImageButton2.Image = CType(resources.GetObject("ImageButton2.Image"), System.Drawing.Image)
            Me.ImageButton2.Location = New System.Drawing.Point(104, 16)
            Me.ImageButton2.Name = "ImageButton2"
            Me.ImageButton2.Size = New System.Drawing.Size(24, 24)
            Me.ImageButton2.TabIndex = 8
            Me.ImageButton2.TabStop = False
            Me.ImageButton2.ThemedImage = CType(resources.GetObject("ImageButton2.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton3
            '
            Me.ImageButton3.Image = CType(resources.GetObject("ImageButton3.Image"), System.Drawing.Image)
            Me.ImageButton3.Location = New System.Drawing.Point(128, 16)
            Me.ImageButton3.Name = "ImageButton3"
            Me.ImageButton3.Size = New System.Drawing.Size(24, 24)
            Me.ImageButton3.TabIndex = 8
            Me.ImageButton3.TabStop = False
            Me.ImageButton3.ThemedImage = CType(resources.GetObject("ImageButton3.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton4
            '
            Me.ImageButton4.Image = CType(resources.GetObject("ImageButton4.Image"), System.Drawing.Image)
            Me.ImageButton4.Location = New System.Drawing.Point(152, 16)
            Me.ImageButton4.Name = "ImageButton4"
            Me.ImageButton4.Size = New System.Drawing.Size(24, 24)
            Me.ImageButton4.TabIndex = 9
            Me.ImageButton4.TabStop = False
            Me.ImageButton4.ThemedImage = CType(resources.GetObject("ImageButton4.ThemedImage"), System.Drawing.Bitmap)
            '
            'ProjectExplorerView
            '
            Me.Controls.Add(Me.grbProject)
            Me.Controls.Add(Me.grbBOQ)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "ProjectExplorerView"
            Me.Size = New System.Drawing.Size(768, 440)
            Me.grbBOQ.ResumeLayout(False)
            Me.grbProject.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Methods"

#End Region

#Region "Overrides"
        Public Overrides Sub CheckFormEnable()

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, LCIItem)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property


        Public Overrides Sub ClearDetail()

        End Sub
        Public Overrides Sub Initialize()

        End Sub

        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbBOQ.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectExplorerView.grbBOQ}")
            Me.grbProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectExplorerView.grbProject}")
        End Sub

        Protected Overrides Sub EventWiring()

        End Sub

        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                'Case "txtlv1"
                '    Me.m_entity.Lv1 = txtlv1.Text
                'Case "txtlv2"
                '    Me.m_entity.Lv2 = txtlv2.Text
                'Case "txtlv3"
                '    Me.m_entity.Lv3 = txtlv3.Text
                'Case "txtlv4"
                '    Me.m_entity.Lv4 = txtlv4.Text
                'Case "txtlv5"
                '    Me.m_entity.Lv5 = txtlv5.Text
                'Case "txtname"
                '    Me.m_entity.Name = txtName.Text
                'Case "txtaltname"
                '    Me.m_entity.AlternateName = txtAltName.Text
                'Case "chkcontrol"
                '    Me.m_entity.IsControlGroup = chkControl.Checked
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            CheckFormEnable()
        End Sub
#End Region

        Private Sub lvBOQ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBOQ.SelectedIndexChanged

        End Sub
    End Class
End Namespace
