Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.CustomControl
    Public Class ImageListViewEventArgs
        Inherits EventArgs
        Private m_itemIndex As Integer

        Public ReadOnly Property ItemIndex() As Integer
            Get
                Return m_itemIndex
            End Get
        End Property

#Region "Constructors"
        Public Sub New(ByVal index As Integer)
            m_itemIndex = index
        End Sub
#End Region

    End Class

    Public Delegate Sub ItemClickedEventHandler(ByVal sender As Object, ByVal e As ImageListViewEventArgs)

    <Description("ImageListView Control"), DefaultEvent("ItemClicked"), DefaultProperty("Items"), Designer(GetType(Longkong.CustomControl.CustomControlDesigner.ItemListViewDesigner))> _
    Public Class ImageListView
        Inherits Control

        Private Shared ICON_INTERVAL As Integer = 10

        Private m_topIndex As Integer = 0
        Private m_lastIndex As Integer = 0
        Private m_firstItemLocation As New Point(0, 0)
        Private m_lastItemLocation As New Point(0, 0)
        Private m_bScrollUp As Boolean = False
        Private m_bScrollDown As Boolean = False
        Private m_bLargeIcons As Boolean = True
        Private m_hitIndex As Integer = 0
        Private m_hoverIndex As Integer = -1
        Private m_largeImageList As ImageList = Nothing
        Private m_smallImageList As ImageList = Nothing
        Private m_downScroll As ScrollButton
        Private m_upScroll As ScrollButton
        Private m_items As ListViewItemCollection

        <Description("Event raised when an ImageItem is clicked"), Category("Behavior")> _
        Public Event ItemClicked As ItemClickedEventHandler

#Region "Constructors"
        Public Sub New()
            m_items = New ListViewItemCollection(Me)
            m_downScroll = New ScrollButton(ScrollButtonOrientation.Down)
            m_upScroll = New ScrollButton(ScrollButtonOrientation.Up)
        End Sub
#End Region


#Region "Properties"
        Public Property SideTabItemFactory() As ISideTabItemFactory
            Get
                Return Me.m_items.SideTabItemFactory
            End Get
            Set(ByVal value As ISideTabItemFactory)
                Me.m_items.SideTabItemFactory = value
            End Set
        End Property
        <Description("Large Image List"), Category("Appearance")> _
        Public Property LargeImageList() As ImageList
            Get
                Return m_largeImageList
            End Get
            Set(ByVal Value As ImageList)
                m_largeImageList = Value
                Invalidate()
            End Set
        End Property
        <Description("Small Image List"), Category("Appearance")> _
        Public Property SmallImageList() As ImageList
            Get
                Return m_smallImageList
            End Get
            Set(ByVal Value As ImageList)
                m_smallImageList = Value
                Invalidate()
            End Set
        End Property

        <Description("Image Items Collection"), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
                 Public Property Items() As ListViewItemCollection
            Get
                Return m_items
            End Get
            Set(ByVal Value As ListViewItemCollection)
                m_items = Value
            End Set
        End Property

        <Description("use large images"), Category("Appearance")> _
        Public Property LargeIcons() As Boolean
            Get
                Return m_bLargeIcons
            End Get
            Set(ByVal Value As Boolean)
                m_bLargeIcons = Value
                Recalc()
                Invalidate()
            End Set
        End Property
#End Region

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            Recalc()
            If m_items.Count = 0 Then
                Return
            End If

            Dim ClientHeight As Integer = Me.ClientRectangle.Height
            m_lastIndex = m_topIndex
            Dim heightAdjust As Integer
            Dim pt As New Point(0, 10)
            Dim myBrush As Brush = New SolidBrush(Me.ForeColor)

            While pt.Y < ClientHeight And (m_lastIndex < m_items.Count)
                Dim Item As ITabItem = m_items(m_lastIndex)
                m_lastIndex += 1
                heightAdjust = Item.Height

                DrawItem(e.Graphics, myBrush, Item, pt, Longkong.CustomControl.ListViewItemState.Normal)

                pt.Y += heightAdjust + ICON_INTERVAL '25
            End While

            m_lastIndex -= 1
            'Scrolling?
            If m_topIndex > 0 Then
                Me.m_bScrollUp = True
            Else
                Me.m_bScrollUp = False
            End If
            If (m_lastIndex + 1 < m_items.Count) Or (ClientHeight < pt.Y) Then
                Me.m_bScrollDown = True
            Else
                Me.m_bScrollDown = False
            End If

            DrawScrollButtons(e.Graphics)
        End Sub

        Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
            MyBase.OnSizeChanged(e)
            Dim g As Graphics = CreateGraphics()
            Dim T As ITabItem
            For Each T In Items
                T.CalcHeight(g, Font, Me.ClientRectangle.Width, m_bLargeIcons)
            Next
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            Dim pt As New Point(e.X, e.Y)
            Dim g As Graphics = CreateGraphics()
            Dim myBrush As Brush = New SolidBrush(Me.ForeColor)
            Dim bHaveHover As Boolean = False

            If m_hoverIndex <> -1 Then
                Dim Item As ITabItem = m_items(m_hoverIndex)
                If Not Item.HitTest(pt) Then
                    Item.Draw(g, Font, myBrush, Item.Location, Me.ClientRectangle.Width, ListViewItemState.Normal)
                Else
                    g.Dispose()
                    myBrush.Dispose()
                    Return
                End If
            End If

            Dim index As Integer
            If m_items.Count > 0 Then
                For index = Me.m_topIndex To Me.m_lastIndex
                    Dim Item As ITabItem = m_items(index)
                    If Item.HitTest(pt) Then
                        Item.Draw(g, Font, myBrush, Item.Location, Me.ClientRectangle.Width, ListViewItemState.Hover)
                        m_hoverIndex = index
                        bHaveHover = True
                        Exit For
                    End If
                Next
            End If

            If Not bHaveHover Then
                m_hoverIndex = -1
            End If

            g.Dispose()
            myBrush.Dispose()
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Left Then
                Dim pt As New Point(e.X, e.Y)
                Dim g As Graphics = CreateGraphics()

                'Hit test for scrolling
                If (Me.m_bScrollUp) Then
                    If Me.m_upScroll.HitTest(pt) Then
                        m_upScroll.Draw(g, ButtonState.Pushed)
                        g.Dispose()
                        Return
                    End If
                End If
                If (Me.m_bScrollDown) Then
                    If Me.m_downScroll.HitTest(pt) Then
                        m_downScroll.Draw(g, ButtonState.Pushed)
                        g.Dispose()
                        Return
                    End If
                End If

                'Hit Test items
                If m_items.Count > 0 Then
                    For m_hitIndex = m_topIndex To m_lastIndex
                        Dim Item As ITabItem = Items(m_hitIndex)
                        If (Item.HitTest(pt)) Then
                            Dim myBrush As Brush = New SolidBrush(Me.ForeColor)
                            Item.Draw(g, Font, myBrush, Item.Location, Me.ClientRectangle.Width, ListViewItemState.Pushed)
                            myBrush.Dispose()
                            g.Dispose()
                            Return
                        End If
                    Next
                End If

            End If
            m_hitIndex = -1
            MyBase.OnMouseDown(e)
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Left Then
                Dim pt As New Point(e.X, e.Y)
                Dim g As Graphics = CreateGraphics()

                'Hit test for scrolling
                If (Me.m_bScrollUp) Then
                    m_upScroll.Draw(g, ButtonState.Normal)
                    If Me.m_upScroll.HitTest(pt) Then
                        g.Dispose()
                        Me.m_topIndex -= 1
                        Me.Invalidate()
                        Return
                    End If
                End If

                If (Me.m_bScrollDown) Then
                    m_downScroll.Draw(g, ButtonState.Normal)
                    If Me.m_downScroll.HitTest(pt) Then
                        g.Dispose()
                        Me.m_topIndex += 1
                        Me.Invalidate()
                        Return
                    End If
                End If

                'Test Image Items
                If m_items.Count > 0 Then
                    If (m_hitIndex <> -1) Then
                        Dim Item As ITabItem = Items(m_hitIndex)
                        Dim myBrush As Brush = New SolidBrush(Me.ForeColor)
                        Item.Draw(g, Font, myBrush, Item.Location, Me.ClientRectangle.Width, ListViewItemState.Normal)
                        myBrush.Dispose()
                        g.Dispose()
                        If (Item.HitTest(pt)) Then
                            Me.OnItemClicked(New ImageListViewEventArgs(m_hitIndex))
                            m_hitIndex = -1
                        End If
                    End If
                End If
            End If
            MyBase.OnMouseUp(e)
        End Sub

        Protected Sub DrawScrollButtons(ByVal g As Graphics)
            If (m_bScrollUp) Then
                m_upScroll.Location = New Point(Me.ClientRectangle.Width - 20, 5)
                m_upScroll.Draw(g, ButtonState.Normal)
            End If

            If (m_bScrollDown) Then
                m_downScroll.Location = New Point(Me.ClientRectangle.Width - 20, Me.ClientRectangle.Bottom - 20)
                m_downScroll.Draw(g, ButtonState.Normal)
            End If
        End Sub

        Protected Sub DrawItem(ByVal g As Graphics, ByVal brush As Brush, ByVal Item As ITabItem, _
        ByVal pt As Point, ByVal state As ListViewItemState)
            If TypeOf Item Is ImageListViewItem Then
                If (Me.m_bLargeIcons) Then
                    If (Me.m_largeImageList Is Nothing) Then
                        Return
                    End If
                Else
                    If (Me.m_smallImageList Is Nothing) Then
                        Return
                    End If
                End If
            End If
            Item.Draw(g, Font, brush, pt, Me.ClientRectangle.Width, state)
        End Sub

        Protected Sub Recalc()
            Dim g As Graphics = CreateGraphics()
            Dim T As ITabItem
            For Each T In m_items
                T.CalcHeight(g, Font, Me.ClientRectangle.Width, m_bLargeIcons)
            Next
            g.Dispose()
        End Sub

        Protected Overridable Sub OnItemClicked(ByVal e As ImageListViewEventArgs)
            RaiseEvent ItemClicked(Me, e)
        End Sub

        Public Class ListViewItemCollection
            Inherits CollectionBase

#Region "Members"
            Private owner As ImageListView
            Private m_sideTabItemFactory As ISideTabItemFactory
#End Region

#Region "Constructors"
            Public Sub New(ByVal parent As ImageListView)
                owner = parent
            End Sub
#End Region

#Region "Properties"
            Public Property SideTabItemFactory() As ISideTabItemFactory
                Get
                    Return Me.m_sideTabItemFactory
                End Get
                Set(ByVal value As ISideTabItemFactory)
                    Me.m_sideTabItemFactory = value
                End Set
            End Property
            Default Public Property Item(ByVal index As Integer) As ITabItem
                Get
                    Try
                        Return CType(InnerList(index), ITabItem)
                    Catch ex As Exception
                        Return Nothing
                    End Try
                End Get
                Set(ByVal Value As ITabItem)
                    Try
                        InnerList(index) = Value
                        owner.Invalidate()
                    Catch ex As Exception

                    End Try
                End Set
            End Property

#End Region

#Region "Methods"
            Public Function Add(ByVal ilvi As ITabItem) As ITabItem
                Dim index As Integer = InnerList.Count
                Insert(InnerList.Count, ilvi)
                Return ilvi
            End Function
            Public Overridable Function Add(ByVal name As String, ByVal content As Object, ByVal imageIndex As Integer) As ITabItem
                Dim item1 As ITabItem = Me.SideTabItemFactory.CreateSideTabItem(name, imageIndex)
                item1.Tag = content
                Return Me.Add(item1)
            End Function
            Public Sub AddRange(ByVal ilvis As ITabItem())
                Dim T As ITabItem
                For Each T In ilvis
                    Add(T)
                Next
            End Sub

            Public Sub Remove(ByVal ilvi As ITabItem)
                RemoveAt(IndexOf(ilvi))
            End Sub

            Public Shadows Sub RemoveAt(ByVal index As Integer)
                InnerList.RemoveAt(index)
                owner.Invalidate()
            End Sub

            Public Sub Insert(ByVal index As Integer, ByVal ilvi As ITabItem)
                InnerList.Insert(index, ilvi)
                ilvi.Parent = owner
                ilvi.CalcHeight(owner.CreateGraphics(), owner.Font, owner.ClientRectangle.Width, owner.m_bLargeIcons)
                owner.Invalidate()
                owner.Update()
            End Sub

            Public Shadows Sub Clear()
                InnerList.Clear()
                owner.Invalidate()
            End Sub

            Public Function IndexOf(ByVal o As ITabItem) As Integer
                Return InnerList.IndexOf(o)
            End Function
#End Region


        End Class

    End Class

End Namespace