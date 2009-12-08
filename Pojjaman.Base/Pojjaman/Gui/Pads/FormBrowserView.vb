Imports Longkong.Core.Properties
Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports System.Drawing
Imports System.ComponentModel
Imports System.IO
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui.Pads
    Public Class FormBrowserView
        Inherits TreeView
        Implements IPadContent, IMementoCapable

#Region "Members"
        Public Shared PlainFont As Font

        Private m_boldFont As Font
        Private m_category As String
        Private m_contentPanel As Panel
        Private Shared m_fileUtilityService As FileUtilityService
        Private m_highlightedNode As AbstractBrowserNode
        Private Shared ReadOnly m_nodeBuilderPath As String
        Private Shared m_formBrowserImageIndex As Hashtable
        Private Shared m_formBrowserImageList As ImageList
        Private Shared m_propertyService As PropertyService
        Private Shared m_resourceService As ResourceService
        Private m_shortcut As String()
        Private m_dockAreas As String()
#End Region

#Region "Constructors"
        Shared Sub New()
            FormBrowserView.m_nodeBuilderPath = "/Pojjaman/Views/ProjectBrowser/NodeBuilders"
            FormBrowserView.PlainFont = Nothing
            FormBrowserView.m_resourceService = CType(ServiceManager.Services.GetService(GetType(Longkong.Core.Services.IResourceService)), ResourceService)
            FormBrowserView.m_fileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            FormBrowserView.m_propertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            FormBrowserView.m_formBrowserImageList = Nothing
            FormBrowserView.m_formBrowserImageIndex = New Hashtable
            FormBrowserView.m_formBrowserImageList = New ImageList
            FormBrowserView.m_formBrowserImageList.ColorDepth = ColorDepth.Depth32Bit
        End Sub
        Public Sub New()
            Me.m_highlightedNode = Nothing
            Me.m_boldFont = Nothing
            Me.m_contentPanel = New Panel
            MyBase.LabelEdit = True
            Me.AllowDrop = True
            MyBase.HideSelection = False
            Me.Dock = DockStyle.Fill
            MyBase.ImageList = FormBrowserView.m_formBrowserImageList
            MyBase.LabelEdit = False
            AddHandler WorkbenchSingleton.Workbench.ActiveWorkbenchWindowChanged, New EventHandler(AddressOf Me.ActiveWindowChanged)
            AddHandler WorkbenchSingleton.Workbench.ViewOpened, New ViewContentEventHandler(AddressOf Me.ActiveViewChanged)

            FormBrowserView.PlainFont = New Font(Me.Font, FontStyle.Regular)
            Me.m_boldFont = New Font(Me.Font, FontStyle.Bold)
            Me.Font = Me.m_boldFont
            Me.m_contentPanel.Controls.Add(Me)
        End Sub
#End Region

#Region "Methods"
        Private Sub ActiveWindowChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing) Then
                Dim node As FormNode = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ITreeBrowsableViewContent).Node
                If (Not node Is Nothing) Then
                    node.EnsureVisible()
                    MyBase.SelectedNode = node
                End If
            End If
        End Sub
        Private Sub ActiveViewChanged(ByVal sender As Object, ByVal e As ViewContentEventArgs)
            If TypeOf e.Content Is ITreeBrowsableViewContent Then
                Dim node As FormNode = CType(e.Content, ITreeBrowsableViewContent).Node
                If (Not node Is Nothing) Then
                    node.EnsureVisible()
                    MyBase.SelectedNode = node
                End If
            End If
        End Sub
        Protected Overrides Sub OnAfterSelect(ByVal e As TreeViewEventArgs)
            MyBase.OnAfterSelect(e)
            Dim node As AbstractBrowserNode = CType(e.Node, AbstractBrowserNode)
            PropertyPad.SetDesignableObject(node.UserData)
            Dim myMenuService As MenuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
            Me.ContextMenu = myMenuService.CreateContextMenu(Me, node.ContextmenuAddinTreePath)
            'Actiate it!
            Me.OpenViewForSelectedNode()
        End Sub
        Protected Overrides Sub OnDoubleClick(ByVal e As EventArgs)
            'OpenViewForSelectedNode()
        End Sub
        Private Sub OpenViewForSelectedNode()
            If ((Not MyBase.SelectedNode Is Nothing) AndAlso TypeOf MyBase.SelectedNode Is AbstractBrowserNode) Then
                CType(MyBase.SelectedNode, AbstractBrowserNode).ActivateItem()
            End If
        End Sub
        Protected Overrides Sub OnBeforeCollapse(ByVal e As TreeViewCancelEventArgs)
            MyBase.OnBeforeCollapse(e)
            If ((Not e.Node Is Nothing) AndAlso TypeOf e.Node Is AbstractBrowserNode) Then
                CType(e.Node, AbstractBrowserNode).BeforeCollapse()
            End If
        End Sub
        Protected Overrides Sub OnBeforeExpand(ByVal e As TreeViewCancelEventArgs)
            MyBase.OnBeforeExpand(e)
            If ((Not e.Node Is Nothing) AndAlso TypeOf e.Node Is AbstractBrowserNode) Then
                CType(e.Node, AbstractBrowserNode).BeforeExpand()
            End If
        End Sub
        Protected Overridable Sub OnIconChanged(ByVal e As EventArgs)
            RaiseEvent IconChanged(Me, e)
        End Sub
        Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
            MyBase.OnKeyPress(e)
            If (e.KeyChar = ChrW(13)) Then
                Me.OnDoubleClick(e)
            End If
        End Sub
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            Dim node As AbstractBrowserNode = CType(MyBase.GetNodeAt(e.X, e.Y), AbstractBrowserNode)
            If ((Not node Is Nothing) AndAlso (Not MyBase.SelectedNode Is node)) Then
                MyBase.SelectedNode = node
            End If
        End Sub
        Protected Overridable Sub OnTitleChanged(ByVal e As EventArgs)
            RaiseEvent TitleChanged(Me, e)
        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
            Dim key As Keys = keyData
            If (key = Keys.F2) Then
                'Me.StartLabelEdit()
                Return True
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function
        Public Shared Function GetImageIndexForImage(ByVal icon As Image) As Integer

        End Function
#End Region

#Region "IPadContent"
        Public Event IconChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IPadContent.IconChanged
        Public Event TitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IPadContent.TitleChanged
        Public Sub BringPadToFront() Implements IPadContent.BringPadToFront
            If Not WorkbenchSingleton.Workbench.WorkbenchLayout.IsVisible(Me) Then
                WorkbenchSingleton.Workbench.WorkbenchLayout.ShowPad(Me)
            End If
            WorkbenchSingleton.Workbench.WorkbenchLayout.ActivatePad(Me)
        End Sub
        Public Property Category() As String Implements IPadContent.Category
            Get
                Return Me.m_category
            End Get
            Set(ByVal Value As String)
                Me.m_category = Value
            End Set
        End Property
        Public ReadOnly Property Control() As System.Windows.Forms.Control Implements IPadContent.Control
            Get
                Return Me.m_contentPanel
            End Get
        End Property
        Public Property DockAreas() As String() Implements IPadContent.DockAreas
            Get
                Return Me.m_dockAreas
            End Get
            Set(ByVal Value() As String)
                Me.m_dockAreas = Value
            End Set
        End Property
        Public ReadOnly Property Icon() As String Implements IPadContent.Icon
            Get
                Return "Icons.16x16.CombineIcon"
            End Get
        End Property
        Public Sub RedrawContent() Implements IPadContent.RedrawContent
            MyBase.BeginUpdate()
            AbstractBrowserNode.ShowExtensions = FormBrowserView.m_propertyService.GetProperty("Longkong.Pojjaman.Gui.FormBrowser.ShowExtensions", True)
            Dim node As AbstractBrowserNode
            For Each node In MyBase.Nodes
                node.UpdateNaming()
            Next
            MyBase.EndUpdate()
        End Sub
        Public Property Shortcut() As String() Implements IPadContent.Shortcut
            Get
                Return Me.m_shortcut
            End Get
            Set(ByVal Value() As String)
                Me.m_shortcut = Value
            End Set
        End Property
        Public Property Title() As String Implements IPadContent.Title
            Get
                FormBrowserView.m_resourceService.GetString("MainWindow.Windows.FormBrowserLabel")
            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        Public ReadOnly Property HideOnClose() As Boolean Implements IPadContent.HideOnClose
            Get
                Return True
            End Get
        End Property
#End Region

#Region "IMementoCapable"
        Public Function CreateMemento() As IXmlConvertable Implements IMementoCapable.CreateMemento
            Return New TreeViewMemento(Me)
        End Function
        Public Sub SetMemento(ByVal memento As IXmlConvertable) Implements IMementoCapable.SetMemento
            CType(memento, TreeViewMemento).Restore(Me)
        End Sub
#End Region

    End Class
End Namespace

