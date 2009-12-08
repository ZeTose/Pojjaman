Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports Longkong.CustomControl

Namespace Longkong.CustomControl.CustomControlDesigner
    Public Class OutlookBarDesigner
        Inherits System.Windows.Forms.Design.ParentControlDesigner
        Private m_designerHost As IDesignerHost = Nothing
        Private m_toolboxService As IToolboxService = Nothing
        Private m_selectionService As ISelectionService = Nothing

        Public Overrides ReadOnly Property AssociatedComponents() As ICollection
            Get
                If TypeOf (MyBase.Control) Is OutlookBar Then
                    Return CType(MyBase.Control, OutlookBar).Tabs
                Else
                    Return MyBase.AssociatedComponents
                End If
            End Get
        End Property
        Public ReadOnly Property DesignerHost() As IDesignerHost
            Get
                If m_designerHost Is Nothing Then
                    m_designerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                End If
                Return m_designerHost
            End Get
        End Property

        Public ReadOnly Property ToolboxService() As IToolboxService
            Get
                If m_toolboxService Is Nothing Then
                    m_toolboxService = CType(GetService(GetType(IToolboxService)), IToolboxService)
                End If
                Return m_toolboxService
            End Get
        End Property

        Public ReadOnly Property SelectionService() As ISelectionService
            Get
                If m_selectionService Is Nothing Then
                    m_selectionService = CType(GetService(GetType(ISelectionService)), ISelectionService)
                End If
                Return m_selectionService
            End Get
        End Property

        Protected Shadows ReadOnly Property DrawGrid() As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Shadows ReadOnly Property CanParent(ByVal control As System.Windows.Forms.Control) As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overrides Sub PostFilterProperties(ByVal Properties As IDictionary)
            MyBase.PostFilterProperties(Properties)
            Dim props As String() = {"BackColor", "AutoScroll", "AutoScrollMargin", "AutoScrollMinSize", "BackgroundImage"}
            Dim prop As String
            For Each prop In props
                Properties.Remove(prop)
            Next
        End Sub

        Protected Overrides Sub OnDragDrop(ByVal de As DragEventArgs)
            Dim toolboxItem As toolboxItem = Me.ToolboxService.DeserializeToolboxItem(de.Data, Me.DesignerHost)
            Dim components As IComponent() = toolboxItem.CreateComponents(Me.DesignerHost)
            Dim ob As OutlookBar = CType(Me.Control, OutlookBar)
            Dim pt As Point = ob.PointToClient(New Point(de.X, de.Y))
            Dim tabIndex As Integer
            If (ob.HitTest(HitTestType.Client, pt, tabIndex)) Then
                'Replace the current control of the active tab
                ' with the newly dropped control
                If ob.ActiveTab Is Nothing Then
                    AddTab(ob, CType(components(0), Control))
                Else
                    If Not ob.ActiveTab.Child Is Nothing Then
                        Me.DesignerHost.DestroyComponent(ob.ActiveTab.Child)
                    End If
                    Dim old As Control = ob.ActiveTab.Child
                    ob.ActiveTab.Child = CType(components(0), Control)
                    RaiseComponentChanged(TypeDescriptor.GetProperties(ob.ActiveTab)("Child"), old, ob.ActiveTab.Child)
                End If

            Else
                AddTab(ob, CType(components(0), Control))
            End If

            'Set the Selection to the newly dropped control
            Me.SelectionService.SetSelectedComponents(components)

            'Inform the Toolbox that the selected item was used; this will reset the mouse to the pointer
            Me.ToolboxService.SelectedToolboxItemUsed()
        End Sub



        Protected Overridable Sub AddTab(ByVal ob As OutlookBar, ByVal myControl As Control)
            'The control was dropped on the Tabs, so
            ' create a new Tab to host the control 
            Dim oldTabs As OutlookBar.TabCollection = ob.Tabs
            Dim T As OutlookBarTab = CType(Me.DesignerHost.CreateComponent(GetType(OutlookBarTab)), OutlookBarTab)
            T.Text = String.Format("outlookBarTab{0} ", oldTabs.Count + 1)
            T.Child = myControl
            ob.Tabs.Add(T)

            'Notify the system that the OutlookBar Component is
            ' changing.  This is necessary for proper serialization of the Tabs 
            ' collection
            Me.RaiseComponentChanged(TypeDescriptor.GetProperties(ob)("Tabs"), ob.Tabs, oldTabs)
        End Sub


        Protected Overrides Sub WndProc(ByRef msg As Message)
            MyBase.WndProc(msg)
            'MessageBox.Show(msg.Msg.ToString)
            If msg.Msg = &H201 Then
                'left mouse down
                Dim ob As OutlookBar = CType(Me.SelectionService.PrimarySelection, OutlookBar)
                If Not ob Is Nothing Then
                    Dim tabIndex As Integer
                    If ob.HitTest(HitTestType.Tabs, New Point(msg.LParam.ToInt32()), tabIndex) Then
                        ob.ActiveTabIndex = tabIndex
                    End If
                End If
            End If
        End Sub

        Private Sub OnComponentRemoving(ByVal sender As Object, ByVal e As ComponentEventArgs)
            'What is being removed?
            If (TypeOf (e.Component) Is OutlookBarTab) Then
                Dim tab As OutlookBarTab = CType(e.Component, OutlookBarTab)
                'Does the Tab belong to the Current Control?
                If CType(Control, OutlookBar).Tabs.Contains(tab) Then
                    CType(Control, OutlookBar).Tabs.Remove(tab)
                    If Not tab.Child Is Nothing Then
                        DesignerHost.DestroyComponent(tab.Child)
                    End If
                End If

            ElseIf (TypeOf (e.Component) Is OutlookBar) Then
                'Destroy all tabs
                Dim bar As OutlookBar = CType(e.Component, OutlookBar)
                Dim tabCount As Integer = bar.Tabs.Count
                Dim index As Integer
                For index = 0 To tabCount
                    DesignerHost.DestroyComponent(bar.Tabs(index))
                Next

            ElseIf (TypeOf (e.Component) Is Control) Then
                Dim myControl As Control = CType(e.Component, Control)
                Dim bar As OutlookBar = CType(myControl, OutlookBar)
                'Do we own the Control?
                If bar.Controls.Contains(myControl) Then
                    'Find the Tab that owns the control
                    Dim tab As OutlookBarTab
                    For Each tab In bar.Tabs
                        If tab.Child Is myControl Then
                            'Found IT!
                            tab.Child = Nothing
                            bar.Controls.Remove(Control)
                            Exit For
                        End If
                    Next
                End If
            End If
        End Sub

        Public Overrides Sub Initialize(ByVal component As IComponent)
            MyBase.Initialize(component)
            Dim changeService As IComponentChangeService = CType(GetService(GetType(IComponentChangeService)), IComponentChangeService)
            RemoveHandler changeService.ComponentRemoving, New ComponentEventHandler(AddressOf OnComponentRemoving)
        End Sub

        Public Overloads Sub Dispose(ByVal disposing As Boolean)
            Dim changeService As IComponentChangeService = CType(GetService(GetType(IComponentChangeService)), IComponentChangeService)
            RemoveHandler changeService.ComponentRemoving, New ComponentEventHandler(AddressOf OnComponentRemoving)
            MyBase.Dispose()
        End Sub

        Public Sub New()
        End Sub
    End Class

    Public Class ItemListViewDesigner
        Inherits ControlDesigner
        Private Sub OnComponentRemoving(ByVal sender As Object, ByVal e As ComponentEventArgs)
            Dim designerHost As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
            'What is being removed?
            If (TypeOf (e.Component) Is ImageListView) Then
                'Destory all Items
                Dim ilv As ImageListView = CType(e.Component, ImageListView)

                While (ilv.Items.Count > 0)
                    designerHost.DestroyComponent(CType(ilv.Items(0), ImageListViewItem))
                    ilv.Items.RemoveAt(0)
                End While
            End If
        End Sub

        Public Overrides Sub Initialize(ByVal component As IComponent)
            MyBase.Initialize(component)

            Dim changeService As IComponentChangeService = CType(GetService(GetType(IComponentChangeService)), IComponentChangeService)
            RemoveHandler changeService.ComponentRemoving, New ComponentEventHandler(AddressOf OnComponentRemoving)
        End Sub

        Public Overloads Sub Dispose(ByVal disposing As Boolean)
            Dim changeService As IComponentChangeService = CType(GetService(GetType(IComponentChangeService)), IComponentChangeService)
            RemoveHandler changeService.ComponentRemoving, New ComponentEventHandler(AddressOf OnComponentRemoving)
            MyBase.Dispose()
        End Sub

        Public Sub New()
        End Sub

    End Class

End Namespace