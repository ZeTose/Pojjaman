Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Templates
Imports System.Xml
Imports Longkong.Core.AddIns
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PojjamanSideBar
        Inherits VSSideBar
        Implements IOwnerState

#Region "Members"
        Public Shared SideBar As PojjamanSideBar
        Public ClipboardRing As VSSideTab

        Private Shared ReadOnly m_contextMenuPath As String
        Protected m_internalState As SidebarState
        Private m_itemMousePosition As Point
        Private m_mousePosition As Point
        Private Shared ReadOnly m_sideTabContextMenuPath As String
        Private m_standardTabs As Hashtable
#End Region

#Region "Constructors"
        Shared Sub New()
            PojjamanSideBar.m_contextMenuPath = "/Pojjaman/Workbench/PojjamanSideBar/ContextMenu"
            PojjamanSideBar.m_sideTabContextMenuPath = "/Pojjaman/Workbench/PojjamanSideBar/SideTab/ContextMenu"
        End Sub
        Public Sub New()
            Me.ClipboardRing = Nothing
            Me.m_internalState = SidebarState.TabCanBeDeleted
            Me.m_standardTabs = New Hashtable
            PojjamanSideBar.SideBar = Me
            MyBase.SideTabItemFactory = New PojjamanSideTabItemFactory
            AddHandler MyBase.MouseUp, New MouseEventHandler(AddressOf Me.SetContextMenu)
            AddHandler Me.m_sideTabContent.MouseUp, New MouseEventHandler(AddressOf Me.SetItemContextMenu)
            For Each template As TextTemplate In TextTemplate.TextTemplates
                Dim tab As New VSSideTab(Me, template.Name)
                tab.CanSaved = False
                For Each entry As TextTemplate.Entry In template.Entries
                    tab.Items.Add(Me.SideTabItemFactory.CreateSideTabItem(entry.Display, entry.Value))
                Next
                tab.CanDragDrop = False
                tab.CanBeDeleted = False
                Me.m_standardTabs(tab) = True
                Me.Tabs.Add(tab)
            Next
            AddHandler Me.m_sideTabContent.DoubleClick, New EventHandler(AddressOf Me.MyDoubleClick)
        End Sub
        Public Sub New(ByVal el As XmlElement)
            Me.New()
            Me.SetOptions(el)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property ItemMousePosition() As Point
            Get
                Return Me.m_itemMousePosition
            End Get
        End Property
        Public ReadOnly Property SideBarMousePosition() As Point
            Get
                Return Me.m_mousePosition
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub MoveItem(ByVal sender As Object, ByVal e As MouseEventArgs)
            Me.m_itemMousePosition = New Point(e.X, e.Y)
        End Sub
        Public Sub MyDoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            Me.m_mousePosition = New Point(e.X, e.Y)
        End Sub
        Public Sub PutInClipboardRing(ByVal [text] As String)
            For Each tab As VSSideTab In MyBase.Tabs
                If tab.IsClipboardRing Then
                    tab.Items.Add(("Text:" & text.Trim), text)
                    If (tab.Items.Count > 20) Then
                        tab.Items.RemoveAt(0)
                    End If
                    Return
                End If
            Next
        End Sub
        Private Sub SetContextMenu(ByVal sender As Object, ByVal e As MouseEventArgs)
            MyBase.ExitRenameMode()
            Dim index As Integer = Me.GetTabIndexAt(e.X, e.Y)
            If (index >= 0) Then
                Dim tab As VSSideTab = MyBase.Tabs.Item(index)
                Me.SetDeletedState(tab)
                If (index > 0) Then
                    Me.m_internalState = (Me.m_internalState Or SidebarState.CanMoveUp)
                Else
                    Me.m_internalState = (Me.m_internalState And CType(-2, SidebarState))
                End If
                If (index < (MyBase.Tabs.Count - 1)) Then
                    Me.m_internalState = (Me.m_internalState Or SidebarState.CanMoveDown)
                Else
                    Me.m_internalState = (Me.m_internalState And CType(-3, SidebarState))
                End If
                Me.Tabs.DragOverTab = tab
                Me.Refresh()
                Me.Tabs.DragOverTab = Nothing
            End If
            If (e.Button = MouseButtons.Right) Then
                Dim myMenuService As MenuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
                myMenuService.ShowContextMenu(Me, PojjamanSideBar.m_contextMenuPath, Me, e.X, e.Y)
            End If
        End Sub
        Private Sub SetDeletedState(ByVal tab As VSSideTab)
            If tab.CanBeDeleted Then
                Me.m_internalState = (Me.m_internalState Or SidebarState.TabCanBeDeleted)
            Else
                Me.m_internalState = (Me.m_internalState And CType(-5, SidebarState))
            End If
        End Sub
        Private Sub SetItemContextMenu(ByVal sender As Object, ByVal e As MouseEventArgs)
            MyBase.ExitRenameMode()
            If (e.Button = MouseButtons.Right) Then
                Dim index As Integer = MyBase.Tabs.IndexOf(MyBase.ActiveTab)
                If (index > 0) Then
                    Me.m_internalState = (Me.m_internalState Or SidebarState.CanMoveUp)
                Else
                    Me.m_internalState = (Me.m_internalState And CType(-2, SidebarState))
                End If
                If (index < (MyBase.Tabs.Count - 1)) Then
                    Me.m_internalState = (Me.m_internalState Or SidebarState.CanMoveDown)
                Else
                    Me.m_internalState = (Me.m_internalState And CType(-3, SidebarState))
                End If
                MyBase.Tabs.DragOverTab = MyBase.ActiveTab
                Me.Refresh()
                MyBase.Tabs.DragOverTab = Nothing
                'End If
                'If (e.Button = MouseButtons.Right) Then
                Me.SetDeletedState(MyBase.ActiveTab)
                index = MyBase.ActiveTab.Items.IndexOf(MyBase.ActiveTab.SelectedItem)
                If (index > 0) Then
                    Me.m_internalState = (Me.m_internalState Or SidebarState.CanMoveItemUp)
                Else
                    Me.m_internalState = (Me.m_internalState And CType(-9, SidebarState))
                End If
                If (index < (MyBase.ActiveTab.Items.Count - 1)) Then
                    Me.m_internalState = (Me.m_internalState Or SidebarState.CanMoveItemDown)
                Else
                    Me.m_internalState = (Me.m_internalState And CType(-17, SidebarState))
                End If
                Dim myMenuService As MenuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
                myMenuService.ShowContextMenu(Me, PojjamanSideBar.m_sideTabContextMenuPath, Me.m_sideTabContent, e.X, e.Y)
            End If
        End Sub

        Private Sub SetOptions(ByVal el As XmlElement)
            For Each sideTabEl As XmlElement In el.ChildNodes
                Dim tab As New VSSideTab(Me, sideTabEl.GetAttribute("text"))
                If (tab.Name Is el.GetAttribute("activetab")) Then
                    MyBase.ActiveTab = tab
                Else
                    If (MyBase.ActiveTab Is Nothing) Then
                        MyBase.ActiveTab = tab
                    End If
                End If
                For Each sideTabItemEl As XmlElement In sideTabEl.ChildNodes
                    tab.Items.Add(MyBase.SideTabItemFactory.CreateSideTabItem(sideTabItemEl.GetAttribute("text"), sideTabItemEl.GetAttribute("value")))
                Next
                If (sideTabEl.GetAttribute("clipboardring") = "true") Then
                    tab.CanBeDeleted = False
                    tab.CanDragDrop = False
                    tab.Name = "${res:Pojjaman.SideBar.ClipboardRing}"
                    tab.IsClipboardRing = True
                End If
                MyBase.Tabs.Add(tab)
            Next
        End Sub
        Public Function ToXmlElement(ByVal doc As XmlDocument) As XmlElement
            If (doc Is Nothing) Then
                Throw New ArgumentNullException("doc")
            End If
            Dim barEl As XmlElement = doc.CreateElement("SideBar")
            barEl.SetAttribute("activetab", MyBase.ActiveTab.Name)
            Dim tab As VSSideTab
            For Each tab In MyBase.Tabs
                If tab.CanSaved AndAlso Me.m_standardTabs.Item(tab) Is Nothing Then
                    Dim tabEl As XmlElement = doc.CreateElement("SideTab")
                    If tab.IsClipboardRing Then
                        tabEl.SetAttribute("clipboardring", "true")
                    End If
                    tabEl.SetAttribute("text", tab.Name)
                    For Each item As VSSideTabItem In tab.Items
                        Dim itemEl As XmlElement = doc.CreateElement("SideTabItem")
                        itemEl.SetAttribute("text", item.Name)
                        itemEl.SetAttribute("value", item.Tag.ToString)
                        tabEl.AppendChild(itemEl)
                    Next
                    barEl.AppendChild(tabEl)
                End If
            Next
            Return barEl
        End Function
#End Region

#Region "IOwnerState"
        Public ReadOnly Property InternalState() As System.Enum Implements Core.AddIns.IOwnerState.InternalState
            Get
                Return Me.m_internalState
            End Get
        End Property
#End Region

        Public Enum SidebarState
            [Nothing] = 0
            CanMoveUp = 1
            CanMoveDown = 2
            TabCanBeDeleted = 4
            CanMoveItemUp = 8
            CanMoveItemDown = 16
        End Enum

    End Class
End Namespace

