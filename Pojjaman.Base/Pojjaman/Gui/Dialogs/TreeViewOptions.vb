Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class TreeViewOptions
        Inherits BasePojjamanForm

#Region "Members"
        Protected m_b As Boolean
        Protected m_boldFont As Font
        Protected m_optionPanels As ArrayList
        Protected m_optionsPanelLabel As GradientHeaderPanel 'PojjamanHeaderPanel 
        Protected m_plainFont As Font
        Protected m_properties As IProperties
#End Region

#Region "Constructors"
        Public Sub New(ByVal properties As IProperties, ByVal node As IAddInTreeNode)
            Me.m_optionPanels = New ArrayList
            Me.m_properties = Nothing
            Me.m_plainFont = Nothing
            Me.m_boldFont = Nothing
            Me.m_b = True
            Me.m_properties = properties
            Me.Text = BasePojjamanForm.StringParserService.Parse("${res:Dialog.Options.TreeViewOptions.DialogName}")
            Me.InitializeComponent()
            Me.m_plainFont = New Font(CType(MyBase.ControlDictionary("optionsTreeView"), TreeView).Font, FontStyle.Regular)
            Me.m_boldFont = New Font(CType(MyBase.ControlDictionary("optionsTreeView"), TreeView).Font, FontStyle.Bold)
            Me.InitImageList()
            If (Not node Is Nothing) Then
                Me.AddNodes(properties, CType(MyBase.ControlDictionary("optionsTreeView"), TreeView).Nodes, node.BuildChildItems(Me))
            End If
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Properties() As IProperties
            Get
                Return Me.m_properties
            End Get
        End Property
#End Region

#Region "Methods"
        Protected Sub AcceptEvent(ByVal sender As Object, ByVal e As EventArgs)
            For Each panel As AbstractOptionPanel In Me.m_optionPanels
                If Not panel.ReceiveDialogMessage(DialogMessage.OK) Then
                    Return
                End If
            Next
            MyBase.DialogResult = DialogResult.OK
        End Sub
        Protected Sub ApplyEvent(ByVal sender As Object, ByVal e As EventArgs)
            For Each panel As AbstractOptionPanel In Me.m_optionPanels
                If Not panel.ReceiveDialogMessage(DialogMessage.OK) Then
                    Return
                End If
            Next
        End Sub
        Protected Sub AddNodes(ByVal customizer As Object, ByVal nodes As TreeNodeCollection, ByVal dialogPanelDescriptors As ArrayList)
            nodes.Clear()
            For Each descriptor As IDialogPanelDescriptor In dialogPanelDescriptors
                If (Not descriptor.DialogPanel Is Nothing) Then
                    descriptor.DialogPanel.CustomizationObject = customizer
                    descriptor.DialogPanel.Control.Dock = DockStyle.Fill
                    Me.m_optionPanels.Add(descriptor.DialogPanel)
                End If
                Dim node As New TreeNode(descriptor.Label)
                node.Tag = descriptor
                node.NodeFont = Me.m_plainFont
                nodes.Add(node)
                If (Not descriptor.DialogPanelDescriptors Is Nothing) Then
                    Me.AddNodes(customizer, node.Nodes, descriptor.DialogPanelDescriptors)
                End If
            Next
        End Sub
        Protected Sub BeforeExpandNode(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
            If Me.m_b Then
                Me.m_b = False
                CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).BeginUpdate()
                Dim node As TreeNode = e.Node.FirstNode
                Do While (node.Nodes.Count > 0)
                    node = node.FirstNode
                Loop
                CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).CollapseAll()
                node.EnsureVisible()
                node.ImageIndex = 3
                CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).EndUpdate()
                Me.SetOptionPanelTo(node)
                Me.m_b = True
            End If
        End Sub
        Protected Sub BeforeSelectNode(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
            Me.ResetImageIndex(CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).Nodes)
            If Me.m_b Then
                Me.CollapseOrExpandNode(e.Node)
            End If
        End Sub
        Private Sub CollapseOrExpandNode(ByVal node As TreeNode)
            If (node.Nodes.Count > 0) Then
                If node.IsExpanded Then
                    node.Collapse()
                Else
                    node.Expand()
                End If
            End If
        End Sub
        Protected Sub HandleClick(ByVal sender As Object, ByVal e As EventArgs)
            If ((CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).GetNodeAt(CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).PointToClient(Control.MousePosition)) Is CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).SelectedNode) AndAlso Me.m_b) Then
                Me.CollapseOrExpandNode(CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).SelectedNode)
            End If
        End Sub
        Protected Sub InitializeComponent()
            MyBase.SetupFromXml(Path.Combine(BasePojjamanForm.PropertyService.DataDirectory, "resources\dialogs\TreeViewOptionsDialog.xfrm"))
            Me.m_optionsPanelLabel = New GradientHeaderPanel 'PojjamanHeaderPanel 
            Me.m_optionsPanelLabel.Font = New Font("Tahoma", 14.0!, FontStyle.Bold, GraphicsUnit.Point, 0)
            'Me.m_optionsPanelLabel.TextAlign = ContentAlignment.MiddleLeft
            Me.m_optionsPanelLabel.BorderStyle = BorderStyle.Fixed3D
            Me.m_optionsPanelLabel.Dock = DockStyle.Fill
            MyBase.ControlDictionary("headerPanel").Controls.Add(Me.m_optionsPanelLabel)
            MyBase.Owner = CType(WorkbenchSingleton.Workbench, Form)
            MyBase.Icon = Nothing
            AddHandler MyBase.ControlDictionary.Item("okButton").Click, New EventHandler(AddressOf Me.AcceptEvent)
            AddHandler MyBase.ControlDictionary.Item("applyButton").Click, New EventHandler(AddressOf Me.ApplyEvent)
            AddHandler CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).Click, New EventHandler(AddressOf Me.HandleClick)
            AddHandler CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).AfterSelect, New TreeViewEventHandler(AddressOf Me.SelectNode)
            AddHandler CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).BeforeSelect, New TreeViewCancelEventHandler(AddressOf Me.BeforeSelectNode)
            AddHandler CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).BeforeExpand, New TreeViewCancelEventHandler(AddressOf Me.BeforeExpandNode)
            AddHandler CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).BeforeExpand, New TreeViewCancelEventHandler(AddressOf Me.ShowOpenFolderIcon)
            AddHandler CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).BeforeCollapse, New TreeViewCancelEventHandler(AddressOf Me.ShowClosedFolderIcon)
            AddHandler CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).MouseDown, New MouseEventHandler(AddressOf Me.TreeMouseDown)
        End Sub
        Protected Sub InitImageList()
            Dim imgList As New ImageList
            imgList.ColorDepth = ColorDepth.Depth32Bit
            imgList.Images.Add(BasePojjamanForm.IconService.GetBitmap("Icons.16x16.ClosedFolderBitmap"))
            imgList.Images.Add(BasePojjamanForm.IconService.GetBitmap("Icons.16x16.OpenFolderBitmap"))
            imgList.Images.Add(New Bitmap(1, 1))
            imgList.Images.Add(BasePojjamanForm.IconService.GetBitmap("Icons.16x16.SelectionArrow"))
            CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).ImageList = imgList
        End Sub
        Protected Sub ResetImageIndex(ByVal nodes As TreeNodeCollection)
            For Each node As TreeNode In nodes
                If (node.Nodes.Count > 0) Then
                    Me.ResetImageIndex(node.Nodes)
                Else
                    node.ImageIndex = 2
                    node.SelectedImageIndex = 3
                End If
            Next
        End Sub
        Protected Sub SelectNode(ByVal sender As Object, ByVal e As TreeViewEventArgs)
            Me.SetOptionPanelTo(CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).SelectedNode)
        End Sub
        Protected Sub SetOptionPanelTo(ByVal node As TreeNode)
            Dim desc As IDialogPanelDescriptor = CType(node.Tag, IDialogPanelDescriptor)
            If (((Not desc Is Nothing) AndAlso (Not desc.DialogPanel Is Nothing)) AndAlso (Not desc.DialogPanel.Control Is Nothing)) Then
                desc.DialogPanel.ReceiveDialogMessage(DialogMessage.Activated)
                MyBase.ControlDictionary("optionControlPanel").Controls.Clear()
                MyBase.ControlDictionary("optionControlPanel").Controls.Add(desc.DialogPanel.Control)
                Me.m_optionsPanelLabel.Text = desc.Label
            End If
        End Sub
        Protected Sub ShowClosedFolderIcon(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
            If (e.Node.Nodes.Count > 0) Then
                Dim indx As Integer = 0
                e.Node.SelectedImageIndex = indx
                e.Node.ImageIndex = indx
            End If
        End Sub
        Protected Sub ShowOpenFolderIcon(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
            If (e.Node.Nodes.Count > 0) Then
                Dim indx As Integer = 1
                e.Node.SelectedImageIndex = indx
                e.Node.ImageIndex = indx
            End If
        End Sub
        Private Sub TreeMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim node As TreeNode = CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).GetNodeAt(CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).PointToClient(Control.MousePosition))
            If ((Not node Is Nothing) AndAlso (node.Nodes.Count = 0)) Then
                CType(MyBase.ControlDictionary.Item("optionsTreeView"), TreeView).SelectedNode = node
            End If
        End Sub

#End Region


    End Class
End Namespace

