Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class VSSideTab

#Region "Members"
        Public Hidden As Boolean

        Private m_canBeDeleted As Boolean
        Private m_canDragDrop As Boolean
        Private m_canSaved As Boolean
        Private m_choosedItem As VSSideTabItem
        Private m_isClipboardRing As Boolean
        Private m_items As SideTabItemCollection
        Private m_largeImageList As ImageList
        Private m_name As String
        Private m_scrollIndex As Integer
        Private m_selectedItem As VSSideTabItem
        Private m_sideTabStatus As SideTabStatus
        Private m_smallImageList As ImageList
        Private m_stringParserService As StringParserService
#End Region

#Region "Events"
        Public Event ChoosedItemChanged As EventHandler
#End Region

#Region "Constructors"
        Protected Sub New()
            Me.m_canDragDrop = True
            Me.m_canBeDeleted = True
            Me.m_isClipboardRing = False
            Me.m_items = New SideTabItemCollection
            Me.m_selectedItem = Nothing
            Me.m_choosedItem = Nothing
            Me.m_largeImageList = Nothing
            Me.m_smallImageList = Nothing
            Me.m_scrollIndex = 0
            Me.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.Hidden = False
            Me.m_canSaved = True
        End Sub
        Public Sub New(ByVal sideTabItemFactory As ISideTabItemFactory)
            Me.m_canDragDrop = True
            Me.m_canBeDeleted = True
            Me.m_isClipboardRing = False
            Me.m_items = New SideTabItemCollection
            Me.m_selectedItem = Nothing
            Me.m_choosedItem = Nothing
            Me.m_largeImageList = Nothing
            Me.m_smallImageList = Nothing
            Me.m_scrollIndex = 0
            Me.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.Hidden = False
            Me.m_canSaved = True
            Me.SideTabItemFactory = sideTabItemFactory
        End Sub
        Public Sub New(ByVal name As String)
            Me.m_canDragDrop = True
            Me.m_canBeDeleted = True
            Me.m_isClipboardRing = False
            Me.m_items = New SideTabItemCollection
            Me.m_selectedItem = Nothing
            Me.m_choosedItem = Nothing
            Me.m_largeImageList = Nothing
            Me.m_smallImageList = Nothing
            Me.m_scrollIndex = 0
            Me.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.Hidden = False
            Me.m_canSaved = True
            Me.m_name = name
        End Sub
        Public Sub New(ByVal sideBar As VSSideBar, ByVal name As String)
            Me.New(sideBar.SideTabItemFactory)
            Me.m_name = name
        End Sub
#End Region

#Region "Properties"
        Public Property CanBeDeleted() As Boolean
            Get
                Return Me.m_canBeDeleted
            End Get
            Set(ByVal value As Boolean)
                Me.m_canBeDeleted = value
            End Set
        End Property
        Public Property CanDragDrop() As Boolean
            Get
                Return Me.m_canDragDrop
            End Get
            Set(ByVal value As Boolean)
                Me.m_canDragDrop = value
            End Set
        End Property
        Public Property CanSaved() As Boolean
            Get
                Return Me.m_canSaved
            End Get
            Set(ByVal value As Boolean)
                Me.m_canSaved = value
            End Set
        End Property
        Public Property ChoosedItem() As VSSideTabItem
            Get
                Return Me.m_choosedItem
            End Get
            Set(ByVal value As VSSideTabItem)
                If (Not Me.m_choosedItem Is Nothing) Then
                    Me.m_choosedItem.SideTabItemStatus = SideTabItemStatus.Normal
                End If
                Me.m_choosedItem = value
                If (Not Me.choosedItem Is Nothing) Then
                    Me.m_choosedItem.SideTabItemStatus = SideTabItemStatus.Choosed
                End If
                Me.OnChoosedItemChanged(Nothing)
            End Set
        End Property
        Public ReadOnly Property Height() As Integer
            Get
                Return (Me.m_items.Count * 20)
            End Get
        End Property
        Public Property IsClipboardRing() As Boolean
            Get
                Return Me.m_isClipboardRing
            End Get
            Set(ByVal value As Boolean)
                Me.m_isClipboardRing = value
            End Set
        End Property
        Public ReadOnly Property ItemHeight() As Integer
            Get
                Return 20
            End Get
        End Property
        Public ReadOnly Property Items() As SideTabItemCollection
            Get
                Return Me.m_items
            End Get
        End Property
        Public Property LargeImageList() As ImageList
            Get
                Return Me.m_largeImageList
            End Get
            Set(ByVal value As ImageList)
                Me.m_largeImageList = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return Me.m_name
            End Get
            Set(ByVal value As String)
                Me.m_name = value
            End Set
        End Property
        Public ReadOnly Property ScrollDownButtonActivated() As Boolean
            Get
                Return (Me.m_scrollIndex > 0)
            End Get
        End Property
        Public Property ScrollIndex() As Integer
            Get
                Return Me.m_scrollIndex
            End Get
            Set(ByVal value As Integer)
                Me.m_scrollIndex = value
            End Set
        End Property
        Public ReadOnly Property ScrollUpButtonActivated() As Boolean
            Get
                Return True
            End Get
        End Property
        Public Property SelectedItem() As VSSideTabItem
            Get
                Return Me.m_selectedItem
            End Get
            Set(ByVal value As VSSideTabItem)
                If ((Not Me.m_selectedItem Is Nothing) AndAlso (Not Me.m_selectedItem Is Me.m_choosedItem)) Then
                    Me.m_selectedItem.SideTabItemStatus = SideTabItemStatus.Normal
                End If
                Me.m_selectedItem = value
                If ((Not Me.m_selectedItem Is Nothing) AndAlso (Not Me.m_selectedItem Is Me.m_choosedItem)) Then
                    Me.m_selectedItem.SideTabItemStatus = SideTabItemStatus.Selected
                End If
            End Set
        End Property
        Public Property SideTabItemFactory() As ISideTabItemFactory
            Get
                Return Me.m_items.SideTabItemFactory
            End Get
            Set(ByVal value As ISideTabItemFactory)
                Me.m_items.SideTabItemFactory = value
            End Set
        End Property
        Public Property SideTabStatus() As SideTabStatus
            Get
                Return Me.m_sideTabStatus
            End Get
            Set(ByVal value As SideTabStatus)
                Me.m_sideTabStatus = value
            End Set
        End Property
        Public Property SmallImageList() As ImageList
            Get
                Return Me.m_smallImageList
            End Get
            Set(ByVal value As ImageList)
                Me.m_smallImageList = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Sub DrawTabContent(ByVal g As Graphics, ByVal f As Font, ByVal rectangle As Rectangle)
            Dim i As Integer = 0
            Do While ((i + Me.ScrollIndex) < Me.Items.Count)
                Dim item As VSSideTabItem = Me.Items.Item((Me.ScrollIndex + i))
                If (rectangle.Height < (i * Me.ItemHeight)) Then
                    Return
                End If
                item.DrawItem(g, f, New rectangle(rectangle.X, (rectangle.Y + (i * Me.ItemHeight)), rectangle.Width, Me.ItemHeight))
                i += 1
            Loop
        End Sub
        Public Sub DrawTabHeader(ByVal g As Graphics, ByVal font As Font, ByVal pos As Point, ByVal width As Integer)
            Select Case Me.m_sideTabStatus
                Case SideTabStatus.Normal
                    ControlPaint.DrawBorder3D(g, New Rectangle(0, pos.Y, (width - 4), (font.Height + 4)), Border3DStyle.RaisedInner)
                    g.DrawString(Me.m_stringParserService.Parse(Me.m_name), font, SystemBrushes.ControlText, New RectangleF(1.0!, CType((pos.Y + 1), Single), CType((width - 5), Single), CType((font.Height + 1), Single)))
                    Return
                Case SideTabStatus.Selected
                    ControlPaint.DrawBorder3D(g, New Rectangle(0, pos.Y, (width - 4), (font.Height + 4)), Border3DStyle.Sunken)
                    g.DrawString(Me.m_stringParserService.Parse(Me.m_name), font, SystemBrushes.ControlText, New RectangleF(2.0!, CType((pos.Y + 2), Single), CType((width - 5), Single), CType((font.Height + 2), Single)))
                    Return
                Case SideTabStatus.Dragged
                    Dim rectangle1 As Rectangle
                    rectangle1 = New Rectangle(0, pos.Y, (width - 4), (font.Height + 4))
                    ControlPaint.DrawBorder3D(g, rectangle1, Border3DStyle.RaisedInner)
                    rectangle1.X = (rectangle1.X + 2)
                    rectangle1.Y += 1
                    rectangle1.Width = (rectangle1.Width - 4)
                    rectangle1.Height = (rectangle1.Height - 2)
                    g.FillRectangle(SystemBrushes.ControlDarkDark, rectangle1)
                    g.DrawString(Me.m_stringParserService.Parse(Me.m_name), font, SystemBrushes.HighlightText, New RectangleF(2.0!, CType((pos.Y + 2), Single), CType((width - 5), Single), CType((font.Height + 2), Single)))
                    Return
            End Select
        End Sub
        Public Function GetItemAt(ByVal pos As Point) As VSSideTabItem
            Return Me.GetItemAt(pos.X, pos.Y)
        End Function
        Public Function GetItemAt(ByVal x As Integer, ByVal y As Integer) As VSSideTabItem
            Dim num1 As Integer = CInt((Me.ScrollIndex + (y / 20)))
            If ((num1 >= 0) AndAlso (num1 < Me.Items.Count)) Then
                Return Me.Items.Item(num1)
            End If
            Return Nothing
        End Function
        Public Function GetLocation(ByVal whichItem As VSSideTabItem) As Point
            For i As Integer = 0 To Me.Items.Count - 1
                Dim item1 As VSSideTabItem = Me.Items.Item(i)
                If (item1 Is whichItem) Then
                    Return New Point(0, (i * 20))
                End If
            Next
            Return New Point(-1, -1)
        End Function
        Protected Sub OnChoosedItemChanged(ByVal e As EventArgs)
            RaiseEvent ChoosedItemChanged(Me, e)
        End Sub
#End Region

#Region "SideTabItemCollection"
        Public Class SideTabItemCollection
            Implements ICollection

#Region "Members"
            Private m_list As ArrayList
            Private m_sideTabItemFactory As ISideTabItemFactory
#End Region

#Region "Consructors"
            Public Sub New()
                Me.m_list = New ArrayList
                Me.m_sideTabItemFactory = New DefaultSideTabItemFactory
            End Sub
#End Region

#Region "Properties"
            Default Public Property Item(ByVal index As Integer) As VSSideTabItem
                Get
                    Return CType(Me.m_list.Item(index), VSSideTabItem)
                End Get
                Set(ByVal value As VSSideTabItem)
                    Me.m_list.Item(index) = value
                End Set
            End Property
            Public ReadOnly Property DraggedIndex() As Integer
                Get
                    For i As Integer = 0 To Me.Count - 1
                        If (Me.Item(i).SideTabItemStatus = SideTabItemStatus.Drag) Then
                            Return i
                        End If
                    Next
                    Return -1
                End Get
            End Property
            Public Property SideTabItemFactory() As ISideTabItemFactory
                Get
                    Return Me.m_sideTabItemFactory
                End Get
                Set(ByVal value As ISideTabItemFactory)
                    Me.m_sideTabItemFactory = value
                End Set
            End Property
#End Region

#Region "Methods"
            Public Overridable Function Add(ByVal item As VSSideTabItem) As VSSideTabItem
                Me.m_list.Add(item)
                Return item
            End Function
            Public Overridable Function Add(ByVal name As String, ByVal content As Object) As VSSideTabItem
                Return Me.Add(name, content, -1)
            End Function
            Public Overridable Function Add(ByVal name As String, ByVal content As Object, ByVal imageIndex As Integer) As VSSideTabItem
                Dim item As VSSideTabItem = Me.m_sideTabItemFactory.CreateSideTabItem(name, imageIndex)
                item.Tag = content
                Return Me.Add(item)
            End Function
            Public Overridable Sub Clear()
                Me.m_list.Clear()
            End Sub
            Public Function Contains(ByVal item As VSSideTabItem) As Boolean
                Return Me.m_list.Contains(item)
            End Function
            Public Function IndexOf(ByVal item As VSSideTabItem) As Integer
                Return Me.m_list.IndexOf(item)
            End Function
            Public Overridable Function Insert(ByVal index As Integer, ByVal item As VSSideTabItem) As VSSideTabItem
                Me.m_list.Insert(index, item)
                Return item
            End Function
            Public Overridable Function Insert(ByVal index As Integer, ByVal name As String, ByVal content As Object) As VSSideTabItem
                Return Me.Insert(index, name, content, -1)
            End Function
            Public Overridable Function Insert(ByVal index As Integer, ByVal name As String, ByVal content As Object, ByVal imageIndex As Integer) As VSSideTabItem
                Dim item As VSSideTabItem = Me.m_sideTabItemFactory.CreateSideTabItem(name, imageIndex)
                item.Tag = content
                Return Me.Insert(index, item)
            End Function
            Public Overridable Sub Remove(ByVal item As VSSideTabItem)
                Me.m_list.Remove(item)
            End Sub
            Public Overridable Sub RemoveAt(ByVal index As Integer)
                Me.m_list.RemoveAt(index)
            End Sub
#End Region

#Region "ICollection"
            Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
                Me.m_list.CopyTo(array, index)
            End Sub
            Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
                Get
                    Return Me.m_list.Count
                End Get
            End Property
            Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
                Get
                    Return False
                End Get
            End Property
            Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
                Get
                    Return Me
                End Get
            End Property
            Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
                Return Me.m_list.GetEnumerator
            End Function
#End Region

        End Class
#End Region

    End Class
    Public Enum SideTabStatus
        Normal
        Selected
        Dragged
    End Enum
End Namespace