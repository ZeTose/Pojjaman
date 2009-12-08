Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections

Namespace Longkong.CustomControl
    Public Enum HitTestType
        Tabs
        Client
    End Enum

#Region "OutlookBar EventArgs"
    Public Class OutlookBarSelectedTabChangedEventArgs
        Inherits EventArgs
        Private m_activeTab As OutlookBarTab
        Private m_prevTab As OutlookBarTab

        Public ReadOnly Property ActiveTab() As OutlookBarTab
            Get
                Return m_activeTab
            End Get
        End Property
        Public ReadOnly Property PreviousTab() As OutlookBarTab
            Get
                Return m_prevTab
            End Get
        End Property
        Public Sub New(ByVal active As OutlookBarTab, ByVal prev As OutlookBarTab)
            m_activeTab = active
            m_prevTab = prev
        End Sub
    End Class
    Public Delegate Sub OutlookBarSelectedTabChangedEventHandler(ByVal sender As Object, ByVal e As OutlookBarSelectedTabChangedEventArgs)
#End Region

#Region "OutlookBar"
    <Description("The OutlookBar Control aka Shortcut Bar"), _
  DefaultEvent("SelectedTabChanged"), _
  DefaultProperty("Tabs"), _
  Designer(GetType(Longkong.CustomControl.CustomControlDesigner.OutlookBarDesigner))> _
Public Class OutlookBar
        Inherits Windows.Forms.ContainerControl

#Region "Members"
        Private m_components As System.ComponentModel.Container = Nothing
        Private m_tabCollection As TabCollection
        Private m_activeTabIndex As Integer
        Private m_hitTabIndex As Integer
        Private m_activeClientRect As Rectangle
        Private m_tabHeight As Integer
        Private m_hoverIndex As Integer
        Private m_sideTabFactory As ISideTabFactory
        Private m_sideTabItemFactory As ISideTabItemFactory
#End Region

#Region "Events"
        <Description("Raised when the active outlooktab changes"), Category("Behavior")> _
          Public Event SelectedTabChanged As OutlookBarSelectedTabChangedEventHandler
#End Region

#Region "Property"
        Public Property SideTabFactory() As ISideTabFactory
            Get
                Return Me.m_sideTabFactory
            End Get
            Set(ByVal value As ISideTabFactory)
                Me.m_sideTabFactory = value
            End Set
        End Property
        Public Property SideTabItemFactory() As ISideTabItemFactory
            Get
                Return Me.m_sideTabItemFactory
            End Get
            Set(ByVal value As ISideTabItemFactory)
                Me.m_sideTabItemFactory = value
            End Set
        End Property

        <Description("The collection of OutlookTabs"), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Property Tabs() As TabCollection
            Get
                Return m_tabCollection
            End Get
            Set(ByVal Value As TabCollection)
                m_tabCollection.Clear()
                m_tabCollection = Value
            End Set
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Property ActiveTabIndex() As Integer
            Get
                Return m_activeTabIndex
            End Get
            Set(ByVal Value As Integer)
                ActivateTab(Value)
            End Set
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property ActiveTab() As OutlookBarTab
            Get
                Return CType(m_tabCollection(m_activeTabIndex), OutlookBarTab)
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Shadows ReadOnly Property Controls() As ControlCollection
            Get
                Return MyBase.Controls
            End Get
        End Property
#End Region

#Region "Constructor"
        Public Sub New()
            InitializeComponent()

            'Set default values
            m_tabCollection = New TabCollection(Me)
            m_activeTabIndex = -1
            m_hitTabIndex = -1
            m_activeClientRect = New Rectangle(0, 0, 0, 0)
            m_tabHeight = 24

        End Sub

        'Required for Designer Support
        Private Sub InitializeComponent()
        End Sub

        Public Function HitTest(ByVal testType As HitTestType, ByVal pt As Point, ByRef TabIndex As Integer) As Boolean
            Dim bResult As Boolean = False
            TabIndex = -1
            If testType = HitTestType.Client Then
                bResult = Me.m_activeClientRect.Contains(pt)
            Else
                Dim hitTabCache As Integer = Me.m_hitTabIndex
                bResult = HitTestTabs(pt)
                If bResult Then
                    TabIndex = m_hitTabIndex
                End If
                m_hitTabIndex = hitTabCache
            End If
            Return bResult
        End Function
#End Region

#Region "Overrides"
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not m_components Is Nothing Then
                    m_components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
            MyBase.OnFontChanged(e)
            ReCalctabHeight()
            Invalidate()
        End Sub

        Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
            MyBase.OnSizeChanged(e)
            ReCalcClientRect()
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            ''''''''''''''''''
            Exit Sub
            ''''''''''''''''''
            Dim pt As New Point(e.X, e.Y)
            Dim g As Graphics = CreateGraphics()
            Dim bHaveHover As Boolean = False

            If m_hoverIndex <> -1 Then
                Dim tab As OutlookBarTab = m_tabCollection(m_hoverIndex)
                If Not tab.HitTest(pt) Then
                    DrawTab(g, m_hoverIndex, ButtonState.Normal)
                Else
                    g.Dispose()
                    Return
                End If
            End If

            Dim index As Integer
            For index = 0 To m_tabCollection.Count - 1
                Dim tab As OutlookBarTab = m_tabCollection(index)
                If tab.HitTest(pt) Then
                    DrawTab(g, index, ButtonState.Checked)
                    m_hoverIndex = index
                    bHaveHover = True
                    Exit For
                End If
            Next

            If Not bHaveHover Then
                m_hoverIndex = -1
            End If

            g.Dispose()
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Left Then
                If (HitTestTabs(New Point(e.X, e.Y))) Then
                    Dim g As Graphics = CreateGraphics()
                    DrawTab(g, m_hitTabIndex, ButtonState.Pushed)
                    g.Dispose()
                Else
                    MyBase.OnMouseDown(e)
                End If
            Else
                MyBase.OnMouseDown(e)
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Left And m_hitTabIndex <> -1 Then
                Dim g As Graphics = CreateGraphics()
                DrawTab(g, m_hitTabIndex, ButtonState.Normal)
                g.Dispose()
                If CType(m_tabCollection(m_hitTabIndex), OutlookBarTab).HitTest(New Point(e.X, e.Y)) Then
                    Dim activeIndex As Integer = m_hitTabIndex
                    m_hitTabIndex = -1
                    ActivateTab(activeIndex)
                End If
            Else
                MyBase.OnMouseUp(e)
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            DrawBorder(e.Graphics)
            DrawTabs(e.Graphics)
            ActivateChildControl()
        End Sub
#End Region

#Region "Methods"

#End Region

        Protected Overridable Function HitTestTabs(ByVal pt As Point) As Boolean
            Dim tabIndex As Integer
            For tabIndex = 0 To m_tabCollection.Count - 1
                If CType(m_tabCollection(tabIndex), OutlookBarTab).HitTest(pt) Then
                    m_hitTabIndex = tabIndex
                    Return True
                End If
            Next
            m_hitTabIndex = -1
            Return False
        End Function

        Public Overridable Sub ActivateTab(ByVal tabIndex As Integer)

            If tabIndex = m_activeTabIndex Or tabIndex >= m_tabCollection.Count Then
                Return
            End If

            Dim prevTab As OutlookBarTab = m_tabCollection(m_activeTabIndex)
            Dim activeTab As OutlookBarTab = m_tabCollection(tabIndex)

            DeActivateTab(m_activeTabIndex)

            m_activeTabIndex = tabIndex

            ReCalcClientRect()

            Invalidate()
            Update()
            ActivateChildControl()

            OnSelectedTabIndexChanged(New OutlookBarSelectedTabChangedEventArgs(activeTab, prevTab))
        End Sub

        Protected Overridable Sub DeActivateTab(ByVal tabIndex As Integer)
            Dim T As OutlookBarTab = m_tabCollection(tabIndex)
            If (Not (T Is Nothing) AndAlso Not (T.Child Is Nothing)) Then
                T.Child.Visible = False
            End If
        End Sub

        Protected Overridable Sub ActivateChildControl()
            Dim T As OutlookBarTab = CType(m_tabCollection(m_activeTabIndex), OutlookBarTab)
            If Not (T Is Nothing) AndAlso Not (T.Child Is Nothing) Then
                T.Child.Visible = True
                T.Child.Size = New Size(m_activeClientRect.Width, m_activeClientRect.Height)
                T.Child.Location = New Point(m_activeClientRect.Left, m_activeClientRect.Top)
                T.Child.BringToFront()
            End If
        End Sub

        Protected Overridable Sub ReCalctabHeight()
            Dim g As Graphics = CreateGraphics()
            m_tabHeight = CInt((Font.GetHeight(g) + (2 * OutlookBarTab.EDGE_PADDING)))
            g.Dispose()
        End Sub

        Protected Overridable Sub ReCalcClientRect()
            m_activeClientRect = New Rectangle(1, 1, Width - 2, Height - 2)
            m_activeClientRect.Y += m_tabHeight * (m_activeTabIndex + 1)
            m_activeClientRect.Height -= m_tabCollection.Count * m_tabHeight
        End Sub

        Protected Overridable Sub DrawBorder(ByVal g As Graphics)
            ControlPaint.DrawBorder3D(g, New Rectangle(0, 0, Width, Height), Border3DStyle.Etched, Border3DSide.All)
        End Sub

        Protected Overridable Sub DrawTabs(ByVal g As Graphics)

            If m_tabCollection.Count = 0 Then
                Return
            End If

            Dim tabRect As New Rectangle(1, 1, Width - 2, m_tabHeight)
            Dim tabIndex As Integer
            For tabIndex = 0 To m_tabCollection.Count - 1
                Dim T As OutlookBarTab = CType(m_tabCollection(tabIndex), OutlookBarTab)
                If tabIndex = m_hitTabIndex Then
                    DrawTab(g, T, tabRect, ButtonState.Pushed)
                Else
                    DrawTab(g, T, tabRect, ButtonState.Normal)
                End If
                If (tabIndex = m_activeTabIndex) Then
                    tabRect.Y = m_activeClientRect.Bottom
                Else
                    tabRect.Y += m_tabHeight
                End If
            Next
        End Sub

        Protected Overridable Sub DrawTab(ByVal g As Graphics, ByVal tabIndex As Integer)
            Dim T As OutlookBarTab = CType(m_tabCollection(tabIndex), OutlookBarTab)
            DrawTab(g, T, T.TabRect, T.ButtonState)
        End Sub

        Protected Overridable Sub DrawTab(ByVal g As Graphics, ByVal tabIndex As Integer, ByVal buttonState As ButtonState)
            Dim T As OutlookBarTab = CType(m_tabCollection(tabIndex), OutlookBarTab)
            DrawTab(g, T, T.TabRect, buttonState)
        End Sub

        Protected Overridable Sub DrawTab(ByVal g As Graphics, ByVal tabIndex As Integer, ByVal tabRect As Rectangle, ByVal buttonState As ButtonState)
            DrawTab(g, CType(m_tabCollection(tabIndex), OutlookBarTab), tabRect, buttonState)
        End Sub

        Protected Overridable Sub DrawTab(ByVal g As Graphics, ByVal outlookTab As OutlookBarTab, ByVal tabRect As Rectangle, ByVal buttonState As ButtonState)
            outlookTab.Draw(g, tabRect, Font, buttonState)
        End Sub

        Protected Overridable Sub SubscribeToTabEvents(ByVal tab As OutlookBarTab)
            Dim events() As System.Reflection.EventInfo = tab.GetType.GetEvents
            Dim ei As System.Reflection.EventInfo
            For Each ei In events
                ei.AddEventHandler(tab, New EventHandler(AddressOf Me.OnTabPropertyChanged))
            Next
        End Sub

        Protected Overridable Sub UnSubscribeToTabEvents(ByVal tab As OutlookBarTab)
            Dim events() As System.Reflection.EventInfo = tab.GetType.GetEvents
            Dim ei As System.Reflection.EventInfo
            For Each ei In events
                ei.RemoveEventHandler(tab, New EventHandler(AddressOf Me.OnTabPropertyChanged))
            Next
        End Sub

        Protected Overridable Sub OnTabPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim ctrl As Control = CType(sender, OutlookBarTab).Child

            If Not (ctrl Is Nothing) And Not Controls.Contains(ctrl) Then
                ctrl.Visible = False
                Me.Controls.Add(ctrl)
            End If
            Invalidate()
        End Sub

        Protected Overridable Sub OnSelectedTabIndexChanged(ByVal e As OutlookBarSelectedTabChangedEventArgs)
            RaiseEvent SelectedTabChanged(Me, e)
        End Sub

#Region "TabCollection"
        Public Class TabCollection
            Inherits CollectionBase


#Region "Members"
            Private m_owner As OutlookBar = Nothing
#End Region

#Region "Constructors"
            Public Sub New(ByVal parent As OutlookBar)
                m_owner = parent
            End Sub
#End Region

#Region "Properties"
            Default Public Property Item(ByVal index As Integer) As OutlookBarTab
                Get
                    If index < 0 Then Return Nothing
                    Return CType(InnerList.Item(index), OutlookBarTab)
                End Get
                Set(ByVal Value As OutlookBarTab)
                    InnerList.Item(index) = Value
                End Set
            End Property
            Default Public ReadOnly Property Item(ByVal _item As OutlookBarTab) As Integer
                Get
                    Return InnerList.IndexOf(_item)
                End Get
            End Property
#End Region

#Region "Methods"
            Public Overridable Function Add(ByVal tab As OutlookBarTab) As OutlookBarTab
                m_owner.SubscribeToTabEvents(tab)
                Dim idx As Integer = InnerList.Add(tab)
                If Not tab.Child Is Nothing Then
                    m_owner.Controls.Add(tab.Child)
                End If
                m_owner.ActivateTab(idx)
                Return tab
            End Function
            Public Overridable Function Add(ByVal name As String) As OutlookBarTab
                Return Me.Add(Me.m_owner.SideTabFactory.CreateSideTab(Me.m_owner, name))
            End Function
#End Region

            Public Shadows Sub Clear()
                Dim tab As OutlookBarTab
                For Each tab In InnerList
                    m_owner.UnSubscribeToTabEvents(tab)
                Next
                m_owner.Controls.Clear()
                InnerList.Clear()
                m_owner.ActiveTabIndex = -1
                m_owner.Invalidate()
            End Sub

            Public Sub AddRange(ByVal tabs As OutlookBarTab())
                Dim T As OutlookBarTab
                For Each T In tabs
                    Add(T)
                Next
            End Sub

            Public Function IndexOf(ByVal item As OutlookBarTab) As Integer
                Return InnerList.IndexOf(item)
            End Function

            Public Sub Remove(ByVal value As OutlookBarTab)
                InnerList.Remove(value)
            End Sub

            Public Shadows Sub RemoveAt(ByVal index As Integer)
                Dim T As OutlookBarTab = Item(index)
                m_owner.Controls.Remove(T.Child)
                InnerList.Remove(T)
                m_owner.UnSubscribeToTabEvents(T)

                If (InnerList.Count > 0) Then
                    'Was this the active Tab?
                    If (index = m_owner.m_activeTabIndex) Then
                        index += 1
                        index = index Mod (Count + 1)
                    End If
                End If
                m_owner.Invalidate()
            End Sub

            Public Function Contains(ByVal value As OutlookBarTab) As Boolean
                Return InnerList.Contains(value)
            End Function
        End Class
#End Region

    End Class
#End Region

End Namespace