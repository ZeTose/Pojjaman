Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.Pojjaman.Gui.Components
    Public Class VSSideBar
        Inherits UserControl

#Region "Members"
        Private m_activeTab As VSSideTab
        Private m_activeTabMemberArea As Rectangle
        Protected m_doAddTab As Boolean
        Private m_mouseDownTab As VSSideTab
        Private m_mousePosition As Point
        Private m_renameTab As VSSideTab
        Private m_renameTabItem As VSSideTabItem
        Private m_renameTextBox As TextBox
        Private m_scrollBar As scrollBar
        Protected m_sideTabContent As SideTabContent
        Private m_sideTabFactory As ISideTabFactory
        Private m_sideTabItemFactory As ISideTabItemFactory
        Private m_sideTabs As SideTabCollection
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_activeTab = Nothing
            Me.m_sideTabContent = New SideTabContent
            Me.m_renameTab = Nothing
            Me.m_renameTabItem = Nothing
            Me.m_renameTextBox = New TextBox
            Me.m_scrollBar = New VScrollBar
            Me.m_doAddTab = False
            Me.m_sideTabFactory = New DefaultSideTabFactory
            Me.m_sideTabItemFactory = New DefaultSideTabItemFactory
            Me.m_mouseDownTab = Nothing
            MyBase.ResizeRedraw = True
            Me.AllowDrop = True
            Me.m_sideTabs = New SideTabCollection(Me)
            MyBase.SetStyle(ControlStyles.UserPaint, True)
            MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
            MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            MyBase.SetStyle(ControlStyles.CacheText, True)
            Me.m_renameTextBox.Visible = False
            Me.m_renameTextBox.BorderStyle = BorderStyle.None
            MyBase.Controls.Add(Me.m_renameTextBox)
            AddHandler Me.m_scrollBar.Scroll, New ScrollEventHandler(AddressOf Me.ScrollBarScrolled)
            MyBase.Controls.Add(Me.m_scrollBar)
            Me.m_sideTabContent.SideBar = Me
            MyBase.Controls.Add(Me.m_sideTabContent)
        End Sub
#End Region

#Region "Properties"
        Public Property ActiveTab() As VSSideTab
            Get
                Return Me.m_activeTab
            End Get
            Set(ByVal value As VSSideTab)
                If (Not Me.m_activeTab Is value) Then
                    If (Not Me.m_activeTab Is Nothing) Then
                        Me.m_activeTab.ScrollIndex = Me.m_scrollBar.Value
                    End If
                    Me.m_activeTab = value
                    If (Not Me.activeTab Is Nothing) Then
                        Me.m_scrollBar.SmallChange = 1
                        Me.m_scrollBar.LargeChange = CInt(Me.m_sideTabContent.Height / Me.ActiveTab.ItemHeight)
                        Me.m_scrollBar.Maximum = Me.activeTab.Items.Count
                        Me.m_scrollBar.Value = Me.activeTab.ScrollIndex
                    End If
                End If
                Me.Refresh()
            End Set
        End Property
        Public ReadOnly Property Tabs() As SideTabCollection
            Get
                Return Me.m_sideTabs
            End Get
        End Property
        Public Property DoAddTab() As Boolean
            Get
                Return Me.m_doAddTab
            End Get
            Set(ByVal value As Boolean)
                Me.m_doAddTab = value
            End Set
        End Property
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
#End Region

#Region "Methods"
        Private Sub ClearDraggings(ByVal tab As VSSideTab)
            For Each item As VSSideTabItem In tab.Items
                If (item.SideTabItemStatus = SideTabItemStatus.Drag) Then
                    item.SideTabItemStatus = SideTabItemStatus.Normal
                End If
            Next
        End Sub
        Public Sub EnsureVisible(ByVal item As VSSideTabItem)
            Dim index As Integer = Me.m_activeTab.Items.IndexOf(item)
            If (index <> -1) Then
                If (index < Me.m_scrollBar.Value) Then
                    Me.m_scrollBar.Value = Math.Max(Me.m_scrollBar.Minimum, Math.Min(Me.m_scrollBar.Maximum, index))
                    Me.ScrollBarScrolled(Nothing, Nothing)
                Else
                    If (index > (Me.m_scrollBar.Value + ((Me.m_sideTabContent.Height - 15) / 20))) Then
                        Me.m_scrollBar.Value = Math.Max(Me.m_scrollBar.Minimum, Math.Min(Me.m_scrollBar.Maximum, CType((index - ((Me.m_sideTabContent.Height - 15) / 20)), Integer)))
                        Me.ScrollBarScrolled(Nothing, Nothing)
                    End If
                End If
            End If
        End Sub
        Protected Sub ExitRenameMode()
            If (Not Me.m_renameTab Is Nothing) Then
                Me.m_renameTextBox.Visible = False
                Me.m_renameTab = Nothing
                Me.m_doAddTab = False
            Else
                If (Not Me.m_renameTabItem Is Nothing) Then
                    Me.m_renameTextBox.Visible = False
                    Me.m_renameTabItem = Nothing
                End If
            End If
        End Sub
        Private Shared Function GetDragDropEffect(ByVal e As DragEventArgs) As DragDropEffects
            If (((e.AllowedEffect And DragDropEffects.Move) > DragDropEffects.None) AndAlso ((e.AllowedEffect And DragDropEffects.Copy) > DragDropEffects.None)) Then
                If ((e.KeyState And 8) <= 0) Then
                    Return DragDropEffects.Move
                End If
                Return DragDropEffects.Copy
            End If
            If ((e.AllowedEffect And DragDropEffects.Move) > DragDropEffects.None) Then
                Return DragDropEffects.Move
            End If
            If ((e.AllowedEffect And DragDropEffects.Copy) > DragDropEffects.None) Then
                Return DragDropEffects.Copy
            End If
            Return DragDropEffects.None
        End Function
        Public Function GetLocation(ByVal whichTab As VSSideTab) As Point
            Dim i As Integer = 0
            Dim lastUpperY As Integer = 0
            Do While (i < Me.m_sideTabs.Count)
                Dim tab As VSSideTab = Me.m_sideTabs.Item(i)
                Dim yPos As Integer = i * (Me.Font.Height + 4 + 1)
                If (tab Is whichTab) Then
                    Return New Point(0, yPos)
                End If
                lastUpperY = yPos + Me.Font.Height + 4
                If (tab Is Me.m_activeTab) Then
                    Exit Do
                End If
                i += 1
            Loop
            Dim bottom As Integer = MyBase.Height
            Dim j As Integer = (Me.m_sideTabs.Count - 1)
            Do While (j > i)
                Dim tab As VSSideTab = Me.m_sideTabs.Item(j)
                Dim yPos As Integer = (MyBase.Height - ((-j + Me.m_sideTabs.Count) * ((Me.Font.Height + 4) + 1)))
                If (yPos < (lastUpperY + ((Me.Font.Height + 4) + 1))) Then
                    Exit Do
                End If
                bottom = yPos
                If (tab Is whichTab) Then
                    Return New Point(0, yPos)
                End If
                j -= 1
            Loop
            Return New Point(-1, -1)
        End Function
        Public Function GetTabAt(ByVal x As Integer, ByVal y As Integer) As VSSideTab
            Dim lastUpperY As Integer = 0
            Dim i As Integer = 0
            Do While (i < Me.m_sideTabs.Count)
                Dim tab As VSSideTab = Me.m_sideTabs.Item(i)
                Dim yPos As Integer = i * (Me.Font.Height + 4 + 1)
                lastUpperY = yPos + Me.Font.Height + 4
                If y >= yPos AndAlso y <= lastUpperY Then
                    Return tab
                End If
                If (tab Is Me.m_activeTab) Then
                    Exit Do
                End If
                i += 1
            Loop
            Dim j As Integer = (Me.m_sideTabs.Count - 1)
            Do While (j > i)
                Dim tab As VSSideTab = Me.m_sideTabs.Item(j)
                Dim yPos As Integer = (MyBase.Height - ((-j + Me.m_sideTabs.Count) * ((Me.Font.Height + 4) + 1)))
                If (yPos < lastUpperY) Then
                    Exit Do
                End If
                If y >= yPos AndAlso y <= yPos + Me.Font.Height + 4 Then
                    Return tab
                End If
                j -= 1
            Loop
            Return Nothing
        End Function
        Public Function GetTabIndexAt(ByVal x As Integer, ByVal y As Integer) As Integer
            Dim num1 As Integer = 0
            Dim num2 As Integer = 0
            Do While (num2 < Me.m_sideTabs.Count)
                Dim tab1 As VSSideTab = Me.m_sideTabs.Item(num2)
                Dim num3 As Integer = (num2 * ((Me.Font.Height + 4) + 1))
                num1 = ((num3 + Me.Font.Height) + 4)
                If ((y >= num3) AndAlso (y <= num1)) Then
                    Return num2
                End If
                If (tab1 Is Me.m_activeTab) Then
                    Exit Do
                End If
                num2 += 1
            Loop
            Dim num4 As Integer = (Me.m_sideTabs.Count - 1)
            Do While (num4 > num2)
                Dim tab2 As VSSideTab = Me.m_sideTabs.Item(num4)
                Dim num5 As Integer = (MyBase.Height - ((-num4 + Me.m_sideTabs.Count) * ((Me.Font.Height + 4) + 1)))
                If (num5 < (num1 + ((Me.Font.Height + 4) + 1))) Then
                    Exit Do
                End If
                If ((y >= num5) AndAlso (y <= ((num5 + Me.Font.Height) + 4))) Then
                    Return num4
                End If
                num4 -= 1
            Loop
            Return -1
        End Function
        Private Sub ItemContextMenuPopup(ByVal sender As Object, ByVal e As EventArgs)
            Me.m_activeTab.ChoosedItem = Me.m_activeTab.SelectedItem
            Me.Refresh()
        End Sub
        Protected Overrides Sub OnDragDrop(ByVal e As DragEventArgs)
            MyBase.OnDragDrop(e)
            Dim point1 As Point = MyBase.PointToClient(New Point(e.X, e.Y))
            If Not e.Data.GetDataPresent(GetType(VSSideTabItem)) Then
                If e.Data.GetDataPresent(GetType(String)) Then
                    If (Not Me.Tabs.DragOverTab Is Nothing) Then
                        Dim text1 As String = CType(e.Data.GetData(GetType(String)), String)
                        Me.Tabs.DragOverTab.Items.Add(("Text:" & text1.Trim), text1)
                    End If
                    Me.Tabs.DragOverTab = Nothing
                    Me.Refresh()
                Else
                    Me.Tabs.DragOverTab = Nothing
                    Me.Refresh()
                End If
            Else
                Dim item1 As VSSideTabItem = CType(e.Data.GetData(GetType(VSSideTabItem)), VSSideTabItem)
                Dim tab1 As VSSideTab = Me.GetTabAt(point1.X, point1.Y)
                If (((Not tab1 Is Nothing) AndAlso (tab1 Is Me.Tabs.DragOverTab)) AndAlso tab1.CanDragDrop) Then
                    Me.Tabs.DragOverTab.SideTabStatus = SideTabStatus.Normal
                    item1.SideTabItemStatus = SideTabItemStatus.Normal
                    Select Case e.Effect
                        Case DragDropEffects.Copy
                            Dim item2 As VSSideTabItem = item1.Clone
                            Me.Tabs.DragOverTab.Items.Add(item2)
                        Case DragDropEffects.Move
                            If (Not Me.Tabs.DragOverTab Is Me.m_activeTab) Then
                                Me.m_activeTab.Items.Remove(item1)
                                Me.Tabs.DragOverTab.Items.Add(item1)
                            End If
                    End Select
                    Me.Tabs.DragOverTab = Nothing
                    Me.Refresh()
                End If
            End If
        End Sub
        Protected Overrides Sub OnDragEnter(ByVal e As DragEventArgs)
            Me.ExitRenameMode()
            MyBase.OnDragEnter(e)
            MyBase.PointToClient(New Point(e.X, e.Y))
            If e.Data.GetDataPresent(GetType(VSSideTabItem)) Then
                If (e.KeyState And 8) > 0 Then
                    e.Effect = DragDropEffects.Copy
                Else
                    e.Effect = DragDropEffects.Move
                End If
            Else
                If e.Data.GetDataPresent(GetType(VSSideTab)) Then
                    Dim tab1 As VSSideTab = CType(e.Data.GetData(GetType(VSSideTab)), VSSideTab)
                    If Me.Tabs.Contains(tab1) Then
                        Me.Tabs.DragOverTab = tab1
                        e.Effect = VSSideBar.GetDragDropEffect(e)
                    Else
                        e.Effect = DragDropEffects.None
                    End If
                Else
                    If e.Data.GetDataPresent(GetType(String)) Then
                        e.Effect = VSSideBar.GetDragDropEffect(e)
                    Else
                        e.Effect = DragDropEffects.None
                    End If
                End If
            End If
        End Sub
        Protected Overrides Sub OnDragLeave(ByVal e As EventArgs)
            MyBase.OnDragLeave(e)
            Me.Tabs.DragOverTab = Nothing
            Me.ClearDraggings(Me.m_activeTab)
            Me.Refresh()
        End Sub
        Protected Overrides Sub OnDragOver(ByVal e As DragEventArgs)
            Me.ExitRenameMode()
            MyBase.OnDragOver(e)
            Dim point1 As Point = MyBase.PointToClient(New Point(e.X, e.Y))
            If e.Data.GetDataPresent(GetType(VSSideTabItem)) Then
                Me.ClearDraggings(Me.m_activeTab)
                Dim tab1 As VSSideTab = Me.GetTabAt(point1.X, point1.Y)
                If ((Not tab1 Is Nothing) AndAlso (Not tab1 Is Me.Tabs.DragOverTab)) Then
                    If tab1.CanDragDrop Then
                        Me.Tabs.DragOverTab = tab1
                    Else
                        Me.Tabs.DragOverTab = Nothing
                    End If
                    Me.Refresh()
                End If
                If ((Not Me.Tabs.DragOverTab Is Nothing) AndAlso Me.Tabs.DragOverTab.CanDragDrop) Then
                    e.Effect = VSSideBar.GetDragDropEffect(e)
                Else
                    e.Effect = DragDropEffects.None
                End If
            Else
                If e.Data.GetDataPresent(GetType(String)) Then
                    Dim tab2 As VSSideTab = Me.Tabs.DragOverTab
                    If Me.m_activeTabMemberArea.Contains(point1.X, point1.Y) Then
                        Me.Tabs.DragOverTab = Me.m_activeTab
                    Else
                        Me.Tabs.DragOverTab = Me.GetTabAt(point1.X, point1.Y)
                    End If
                    If (Not tab2 Is Me.Tabs.DragOverTab) Then
                        Me.Refresh()
                    End If
                Else
                    If e.Data.GetDataPresent(GetType(VSSideTab)) Then
                        Dim num1 As Integer = Me.GetTabIndexAt(point1.X, point1.Y)
                        If (num1 <> -1) Then
                            Dim tab3 As VSSideTab = Me.Tabs.DragOverTab
                            Me.Tabs.Remove(tab3)
                            Me.Tabs.Insert(num1, tab3)
                            Me.Refresh()
                        End If
                        e.Effect = DragDropEffects.Move
                    End If
                End If
            End If
        End Sub
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If (e.Button = MouseButtons.Left) Then
                Dim tab1 As VSSideTab = Me.GetTabAt(e.X, e.Y)
                If (Not tab1 Is Nothing) Then
                    Me.m_mouseDownTab = tab1
                    tab1.SideTabStatus = SideTabStatus.Selected
                    Me.Refresh()
                End If
            End If
        End Sub
        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            Me.m_mousePosition = New Point(e.X, e.Y)
            If (e.Button = MouseButtons.Left) Then
                Dim num1 As Integer = -1
                Dim num2 As Integer
                For num2 = 0 To Me.m_sideTabs.Count - 1
                    If (Me.m_sideTabs.Item(num2).SideTabStatus = SideTabStatus.Selected) Then
                        num1 = num2
                        Exit For
                    End If
                Next num2
                If (num1 <> -1) Then
                    Me.Tabs.DragOverTab = Me.Tabs.Item(num1)
                    MyBase.DoDragDrop(Me.Tabs.DragOverTab, (DragDropEffects.Move Or (DragDropEffects.Copy Or DragDropEffects.Scroll)))
                    Me.Refresh()
                End If
            End If
        End Sub
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            If (Not Me.m_mouseDownTab Is Nothing) Then
                Me.ActiveTab = Me.m_mouseDownTab
                Me.m_mouseDownTab.SideTabStatus = SideTabStatus.Normal
                Me.m_mouseDownTab = Nothing
            End If
            Me.ExitRenameMode()
            Me.Refresh()
            MyBase.OnMouseUp(e)
        End Sub
        Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
            MyBase.OnMouseWheel(e)
            If Me.m_scrollBar.Visible Then
                Dim num1 As Integer
                If (SystemInformation.MouseWheelScrollLines > 0) Then
                    num1 = (Me.m_scrollBar.Value - (Math.Sign(e.Delta) * SystemInformation.MouseWheelScrollLines))
                Else
                    num1 = (Me.m_scrollBar.Value - (Math.Sign(e.Delta) * Me.m_scrollBar.LargeChange))
                End If
                Me.m_scrollBar.Value = Math.Max(Me.m_scrollBar.Minimum, Math.Min(Me.m_scrollBar.Maximum, num1))
                Me.ScrollBarScrolled(Nothing, Nothing)
            End If
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim graphics1 As Graphics = e.Graphics
            Dim num1 As Integer = 0
            Dim num2 As Integer = 0
            Do While (num1 < Me.m_sideTabs.Count)
                Dim tab1 As VSSideTab = Me.m_sideTabs.Item(num1)
                Dim num3 As Integer = (num1 * ((Me.Font.Height + 4) + 1))
                tab1.DrawTabHeader(graphics1, Me.Font, New Point(0, num3), MyBase.Width)
                num2 = ((num3 + Me.Font.Height) + 4)
                If (tab1 Is Me.m_activeTab) Then
                    Exit Do
                End If
                num1 += 1
            Loop
            Dim num4 As Integer = MyBase.Height
            Dim num5 As Integer = (Me.m_sideTabs.Count - 1)
            Do While (num5 > num1)
                Dim tab2 As VSSideTab = Me.m_sideTabs.Item(num5)
                Dim num6 As Integer = (MyBase.Height - ((-num5 + Me.m_sideTabs.Count) * ((Me.Font.Height + 4) + 1)))
                If (num6 < (num2 + ((Me.Font.Height + 4) + 1))) Then
                    Exit Do
                End If
                num4 = num6
                tab2.DrawTabHeader(graphics1, Me.Font, New Point(0, num6), MyBase.Width)
                num5 -= 1
            Loop
            If (Not Me.m_activeTab Is Nothing) Then
                Dim flag1 As Boolean = ((Me.m_scrollBar.Maximum > ((num4 - num2) / 20)) OrElse (Me.m_scrollBar.Value <> 0))
                Me.m_scrollBar.Visible = flag1
                Me.m_activeTabMemberArea = New Rectangle(0, num2, ((MyBase.Width - CInt(IIf(Me.m_scrollBar.Visible, SystemInformation.VerticalScrollBarWidth, 0))) - 4), (num4 - num2))
                Me.m_sideTabContent.Bounds = Me.m_activeTabMemberArea
                Me.m_scrollBar.Location = New Point(((MyBase.Width - SystemInformation.VerticalScrollBarWidth) - 4), num2)
                Me.m_scrollBar.Width = SystemInformation.VerticalScrollBarWidth
                Me.m_scrollBar.Height = Me.m_activeTabMemberArea.Height
            End If
        End Sub
        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)
            Me.m_scrollBar.LargeChange = CInt(Me.m_sideTabContent.Height / Me.m_activeTab.ItemHeight)
        End Sub
        Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
            Dim num1 As Integer
            If MyBase.ProcessCmdKey(msg, keyData) Then
                Return True
            End If
            Dim flag1 As Boolean = ((Not Me.m_renameTab Is Nothing) OrElse (Not Me.m_renameTabItem Is Nothing))
            Dim keys1 As Keys = keyData
            If (keys1 <= Keys.Escape) Then
                If (keys1 = Keys.Return) Then
                    If (Not Me.m_renameTab Is Nothing) Then
                        Me.m_renameTab.Name = Me.m_renameTextBox.Text
                        Me.ExitRenameMode()
                    Else
                        If (Not Me.m_renameTabItem Is Nothing) Then
                            Me.m_renameTabItem.Name = Me.m_renameTextBox.Text
                            Me.ExitRenameMode()
                        End If
                    End If
                    Return True
                End If
                If (keys1 = Keys.Escape) Then
                    If (Not Me.m_renameTab Is Nothing) Then
                        If Me.m_doAddTab Then
                            Me.Tabs.RemoveAt((Me.Tabs.Count - 1))
                            Me.m_renameTab = Nothing
                            Me.m_renameTextBox.Visible = False
                            Me.m_doAddTab = False
                            Me.Refresh()
                        Else
                            Me.ExitRenameMode()
                        End If
                    Else
                        If (Not Me.m_renameTabItem Is Nothing) Then
                            Me.ExitRenameMode()
                        End If
                    End If
                    Return True
                End If
                GoTo Label_04D7
            End If
            Select Case keys1
                Case Keys.Prior
                    If ((Me.m_activeTab.Items.Count > 0) AndAlso Not flag1) Then
                        num1 = Math.Max(0, CType((Me.m_activeTab.Items.IndexOf(Me.m_activeTab.ChoosedItem) - Me.m_scrollBar.LargeChange), Integer))
                        Me.m_activeTab.ChoosedItem = Me.m_activeTab.Items.Item(num1)
                        Me.EnsureVisible(Me.m_activeTab.ChoosedItem)
                        Me.Refresh()
                    End If
                    GoTo Label_04D7
                Case Keys.Next
                    If ((Me.m_activeTab.Items.Count > 0) AndAlso Not flag1) Then
                        num1 = Math.Min(CType((Me.m_activeTab.Items.Count - 1), Integer), CType((Me.m_activeTab.Items.IndexOf(Me.m_activeTab.ChoosedItem) + Me.m_scrollBar.LargeChange), Integer))
                        Me.m_activeTab.ChoosedItem = Me.m_activeTab.Items.Item(num1)
                        Me.EnsureVisible(Me.m_activeTab.ChoosedItem)
                        Me.Refresh()
                    End If
                    GoTo Label_04D7
                Case Keys.End
                    If ((Me.m_activeTab.Items.Count > 0) AndAlso Not flag1) Then
                        Me.m_activeTab.ChoosedItem = Me.m_activeTab.Items.Item((Me.m_activeTab.Items.Count - 1))
                        Me.EnsureVisible(Me.m_activeTab.ChoosedItem)
                        Me.Refresh()
                    End If
                    GoTo Label_04D7
                Case Keys.Home
                    If ((Me.m_activeTab.Items.Count > 0) AndAlso Not flag1) Then
                        Me.m_activeTab.ChoosedItem = Me.m_activeTab.Items.Item(0)
                        Me.EnsureVisible(Me.m_activeTab.ChoosedItem)
                        Me.Refresh()
                    End If
                    GoTo Label_04D7
                Case Keys.Left, Keys.Right, (Keys.Control Or Keys.Right)
                    GoTo Label_04D7
                Case Keys.Up
                    If ((Me.m_activeTab.Items.Count <= 0) OrElse flag1) Then
                        GoTo Label_03B7
                    End If
                    If (Me.m_activeTab.ChoosedItem Is Nothing) Then
                        Me.m_activeTab.ChoosedItem = Me.m_activeTab.Items.Item(0)
                        GoTo Label_0394
                    End If
                    Me.m_activeTab.ChoosedItem = Me.m_activeTab.Items.Item(Math.Max(0, CType((Me.m_activeTab.Items.IndexOf(Me.m_activeTab.ChoosedItem) - 1), Integer)))
                    GoTo Label_0394
                Case Keys.Down
                    If ((Me.m_activeTab.Items.Count <= 0) OrElse flag1) Then
                        GoTo Label_030D
                    End If
                    If (Me.m_activeTab.ChoosedItem Is Nothing) Then
                        Me.m_activeTab.ChoosedItem = Me.m_activeTab.Items.Item(0)
                    Else
                        Me.m_activeTab.ChoosedItem = Me.m_activeTab.Items.Item(Math.Min(CType((Me.m_activeTab.Items.Count - 1), Integer), CType((Me.m_activeTab.Items.IndexOf(Me.m_activeTab.ChoosedItem) + 1), Integer)))
                    End If
                Case (Keys.Control Or Keys.Up)
                    Me.ActiveTab = Me.Tabs.Item(Math.Max(0, CType((Me.Tabs.IndexOf(Me.ActiveTab) - 1), Integer)))
                    Me.Refresh()
                    Return True
                Case (Keys.Control Or Keys.Down)
                    Me.ActiveTab = Me.Tabs.Item(Math.Min(CType((Me.Tabs.Count - 1), Integer), CType((Me.Tabs.IndexOf(Me.ActiveTab) + 1), Integer)))
                    Me.Refresh()
                    Return True
                Case Else
                    GoTo Label_04D7
            End Select
            Me.m_activeTab.SelectedItem = Nothing
            Me.EnsureVisible(Me.m_activeTab.ChoosedItem)
            Me.Refresh()
Label_030D:
            Return True
Label_0394:
            Me.m_activeTab.SelectedItem = Nothing
            Me.EnsureVisible(Me.m_activeTab.ChoosedItem)
            Me.Refresh()
Label_03B7:
            Return True
Label_04D7:
            Return False
        End Function
        Private Sub ScrollBarScrolled(ByVal sender As Object, ByVal e As ScrollEventArgs)
            Me.m_activeTab.ScrollIndex = Me.m_scrollBar.Value
            Me.m_sideTabContent.Refresh()
        End Sub
        Public Sub StartRenamingOf(ByVal tab As VSSideTab)
            Dim num1 As Integer = Me.Tabs.IndexOf(tab)
            Me.m_renameTab = Me.Tabs.Item(num1)
            Dim point1 As Point = Me.GetLocation(Me.m_renameTab)
            point1.X = (point1.X + 3)
            point1.Y += 1
            Me.m_renameTextBox.Location = point1
            Me.m_renameTextBox.Width = (MyBase.Width - 10)
            Me.m_renameTextBox.Height = (Me.Font.Height - 2)
            Me.m_renameTextBox.Text = Me.m_renameTab.Name
            Me.m_renameTextBox.Visible = True
            Me.m_renameTextBox.Focus()
        End Sub
        Public Sub StartRenamingOf(ByVal item As VSSideTabItem)
            Me.EnsureVisible(item)
            Me.m_renameTabItem = item
            Dim point1 As Point = Me.m_activeTab.GetLocation(item)
            point1.X = (point1.X + (((MyBase.Bounds.X + 5) + Me.m_sideTabContent.Location.X) + 16))
            point1.Y = (point1.Y + (((MyBase.Bounds.Y + 3) + Me.m_sideTabContent.Location.Y) - (Me.m_scrollBar.Value * 20)))
            Me.m_renameTextBox.Location = point1
            Me.m_renameTextBox.Width = (MyBase.Width - 10)
            Me.m_renameTextBox.Height = (Me.Font.Height - 2)
            Me.m_renameTextBox.Text = item.Name
            Me.m_renameTextBox.Visible = True
            Me.m_renameTextBox.Focus()
        End Sub
#End Region

#Region "SideTabCollection Class"
        Public Class SideTabCollection
            Implements ICollection

#Region "Members"
            Private m_dragOverTab As VSSideTab
            Private m_list As ArrayList
            Private m_sideBar As VSSideBar
#End Region

#Region "Construcors"
            Public Sub New(ByVal sideBar As VSSideBar)
                Me.m_list = New ArrayList
                Me.m_sideBar = sideBar
            End Sub
#End Region

#Region "Properties"
            Public Property DragOverTab() As VSSideTab
                Get
                    Return Me.m_dragOverTab
                End Get
                Set(ByVal value As VSSideTab)
                    If (Not Me.m_dragOverTab Is Nothing) Then
                        Me.m_dragOverTab.SideTabStatus = SideTabStatus.Normal
                    End If
                    Me.m_dragOverTab = value
                    If (Not Me.m_dragOverTab Is Nothing) Then
                        Me.m_dragOverTab.SideTabStatus = SideTabStatus.Dragged
                    End If
                End Set
            End Property
            Default Public Property Item(ByVal index As Integer) As VSSideTab
                Get
                    Return CType(Me.m_list.Item(index), VSSideTab)
                End Get
                Set(ByVal value As VSSideTab)
                    Me.m_list.Item(index) = value
                End Set
            End Property
#End Region

#Region "Methods"
            Public Overridable Function Add(ByVal item As VSSideTab) As VSSideTab
                Me.m_list.Add(item)
                Return item
            End Function
            Public Overridable Function Add(ByVal name As String) As VSSideTab
                Return Me.Add(Me.m_sideBar.SideTabFactory.CreateSideTab(Me.m_sideBar, name))
            End Function
            Public Overridable Sub Clear()
                Me.m_list.Clear()
            End Sub
            Public Function Contains(ByVal item As VSSideTab) As Boolean
                Return Me.m_list.Contains(item)
            End Function
            Public Function IndexOf(ByVal item As VSSideTab) As Integer
                Return Me.m_list.IndexOf(item)
            End Function
            Public Overridable Function Insert(ByVal index As Integer, ByVal item As VSSideTab) As VSSideTab
                Me.m_list.Insert(index, item)
                Return item
            End Function
            Public Overridable Function Insert(ByVal index As Integer, ByVal name As String) As VSSideTab
                Return Me.Insert(index, Me.m_sideBar.SideTabFactory.CreateSideTab(Me.m_sideBar, name))
            End Function
            Public Overridable Sub Remove(ByVal item As VSSideTab)
                If (item Is Me.m_sideBar.ActiveTab) Then
                    Dim indx As Integer = Me.IndexOf(item)
                    If (indx > 0) Then
                        Me.m_sideBar.ActiveTab = Me.Item((indx - 1))
                    Else
                        If (indx < (Me.Count - 1)) Then
                            Me.m_sideBar.ActiveTab = Me.Item((indx + 1))
                        Else
                            Me.m_sideBar.ActiveTab = Nothing
                        End If
                    End If
                End If
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

#Region "SideTabContent Class"
        Protected Class SideTabContent
            Inherits UserControl

#Region "Membes"
            Private m_mousePosition As Point
            Private m_sideBar As VSSideBar
#End Region

#Region "Construtors"
            Public Sub New()
                Me.m_sideBar = Nothing
                MyBase.ResizeRedraw = True
                Me.AllowDrop = True
                MyBase.SetStyle(ControlStyles.UserPaint, True)
                MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
                MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
                MyBase.SetStyle(ControlStyles.CacheText, True)
            End Sub
#End Region

#Region "Properties"
            Public Property SideBar() As VSSideBar
                Get
                    Return Me.m_sideBar
                End Get
                Set(ByVal value As VSSideBar)
                    Me.m_sideBar = value
                End Set
            End Property
#End Region

#Region "Methods"
            Private Sub ClearDraggings(ByVal tab As VSSideTab)
                Dim item1 As VSSideTabItem
                For Each item1 In tab.Items
                    If (item1.SideTabItemStatus = SideTabItemStatus.Drag) Then
                        item1.SideTabItemStatus = SideTabItemStatus.Normal
                    End If
                Next
            End Sub
            Protected Overrides Sub OnDragDrop(ByVal e As DragEventArgs)
                MyBase.OnDragDrop(e)
                Dim point1 As Point = MyBase.PointToClient(New Point(e.X, e.Y))
                If Not e.Data.GetDataPresent(GetType(VSSideTabItem)) Then
                    If e.Data.GetDataPresent(GetType(String)) Then
                        If (Not Me.m_sideBar.Tabs.DragOverTab Is Nothing) Then
                            Dim text1 As String = CType(e.Data.GetData(GetType(String)), String)
                            Me.m_sideBar.Tabs.DragOverTab.Items.Add(("Text:" & text1.Trim), text1)
                        End If
                        Me.m_sideBar.Tabs.DragOverTab = Nothing
                        Me.Refresh()
                    Else
                        Me.m_sideBar.Tabs.DragOverTab = Nothing
                        Me.m_sideBar.Refresh()
                    End If
                Else
                    Dim item1 As VSSideTabItem = CType(e.Data.GetData(GetType(VSSideTabItem)), VSSideTabItem)
                    Select Case e.Effect
                        Case DragDropEffects.Copy
                            Dim item3 As VSSideTabItem = item1.Clone
                            item3.SideTabItemStatus = SideTabItemStatus.Normal
                            Me.m_sideBar.ActiveTab.Items.Add(item3)
                        Case DragDropEffects.Move
                            Dim item2 As VSSideTabItem = Me.m_sideBar.ActiveTab.GetItemAt(point1.X, point1.Y)
                            If (Not item2 Is Me.m_sideBar.ActiveTab.ChoosedItem) Then
                                Dim num1 As Integer = Me.m_sideBar.ActiveTab.Items.DraggedIndex
                                If (num1 <> -1) Then
                                    Me.m_sideBar.ActiveTab.Items.Remove(item1)
                                    Me.m_sideBar.ActiveTab.Items.Insert(num1, item1)
                                End If
                            End If
                    End Select
                    Me.m_sideBar.ClearDraggings(Me.m_sideBar.ActiveTab)
                    Me.m_sideBar.Tabs.DragOverTab = Nothing
                    Me.m_sideBar.Refresh()
                End If
            End Sub
            Protected Overrides Sub OnDragEnter(ByVal e As DragEventArgs)
                MyBase.OnDragEnter(e)
                Me.m_sideBar.ExitRenameMode()
                If Me.m_sideBar.ActiveTab.CanDragDrop Then
                    If (e.Data.GetDataPresent(GetType(String)) OrElse e.Data.GetDataPresent(GetType(VSSideTabItem))) Then
                        e.Effect = VSSideBar.GetDragDropEffect(e)
                    Else
                        e.Effect = DragDropEffects.None
                    End If
                Else
                    e.Effect = DragDropEffects.None
                End If
            End Sub
            Protected Overrides Sub OnDragLeave(ByVal e As EventArgs)
                MyBase.OnDragLeave(e)
                Me.m_sideBar.Tabs.DragOverTab = Nothing
                Me.m_sideBar.ClearDraggings(Me.m_sideBar.ActiveTab)
                Me.Refresh()
            End Sub
            Protected Overrides Sub OnDragOver(ByVal e As DragEventArgs)
                MyBase.OnDragOver(e)
                Me.m_sideBar.ExitRenameMode()
                Dim point1 As Point = MyBase.PointToClient(New Point(e.X, e.Y))
                If e.Data.GetDataPresent(GetType(VSSideTabItem)) Then
                    If Me.m_sideBar.ActiveTab.CanDragDrop Then
                        Dim item1 As VSSideTabItem = Me.m_sideBar.ActiveTab.GetItemAt(point1.X, point1.Y)
                        If (item1 Is Nothing) Then
                            Me.m_sideBar.ClearDraggings(Me.m_sideBar.ActiveTab)
                            Me.m_sideBar.Refresh()
                        Else
                            If (Not item1 Is Me.m_sideBar.ActiveTab.ChoosedItem) Then
                                If (item1.SideTabItemStatus <> SideTabItemStatus.Drag) Then
                                    Me.m_sideBar.ClearDraggings(Me.m_sideBar.ActiveTab)
                                    item1.SideTabItemStatus = SideTabItemStatus.Drag
                                    Me.m_sideBar.Tabs.DragOverTab = Me.m_sideBar.ActiveTab
                                    Me.m_sideBar.Refresh()
                                End If
                            Else
                                Me.m_sideBar.ClearDraggings(Me.m_sideBar.ActiveTab)
                                Me.m_sideBar.ActiveTab.SideTabStatus = SideTabStatus.Dragged
                                Me.m_sideBar.Refresh()
                            End If
                        End If
                        e.Effect = VSSideBar.GetDragDropEffect(e)
                    Else
                        e.Effect = DragDropEffects.None
                    End If
                Else
                    If (e.Data.GetDataPresent(GetType(String)) AndAlso (Not Me.m_sideBar.ActiveTab Is Me.m_sideBar.Tabs.DragOverTab)) Then
                        Me.m_sideBar.Tabs.DragOverTab = Me.m_sideBar.ActiveTab
                        Me.m_sideBar.Refresh()
                    End If
                End If
            End Sub
            Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
                MyBase.OnMouseDown(e)
                Me.m_sideBar.ActiveTab.ChoosedItem = Me.m_sideBar.ActiveTab.SelectedItem
                Me.Refresh()
            End Sub
            Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
                MyBase.OnMouseLeave(e)
                Me.m_sideBar.ActiveTab.SelectedItem = Nothing
                Me.Refresh()
            End Sub
            Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
                MyBase.OnMouseMove(e)
                If (e.Button = MouseButtons.Left) Then
                    Dim item1 As VSSideTabItem = Me.m_sideBar.ActiveTab.GetItemAt(e.X, e.Y)
                    If (item1 Is Nothing) Then
                        Return
                    End If
                    Me.m_sideBar.Tabs.DragOverTab = Me.m_sideBar.ActiveTab
                    Dim obj1 As New SpecialDataObject
                    obj1.SetData(item1.Tag)
                    obj1.SetData(item1)
                    If Me.m_sideBar.ActiveTab.CanDragDrop Then
                        MyBase.DoDragDrop(obj1, DragDropEffects.Move Or DragDropEffects.Copy Or DragDropEffects.Scroll)
                    Else
                        MyBase.DoDragDrop(obj1, DragDropEffects.Copy)
                    End If
                    Me.Refresh()
                Else
                    Dim item2 As VSSideTabItem = Me.m_sideBar.ActiveTab.SelectedItem
                    Me.m_sideBar.ActiveTab.SelectedItem = Nothing
                    Me.m_mousePosition = New Point(e.X, e.Y)
                    Dim item3 As VSSideTabItem = Me.m_sideBar.ActiveTab.GetItemAt(e.X, e.Y)
                    If (Not item3 Is Nothing) Then
                        Me.m_sideBar.ActiveTab.SelectedItem = item3
                    End If
                    If (Not item2 Is Me.m_sideBar.ActiveTab.SelectedItem) Then
                        Me.m_sideBar.Refresh()
                    End If
                End If
            End Sub
            Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
                If (Not Me.m_sideBar Is Nothing) Then
                    Me.m_sideBar.ExitRenameMode()
                    Me.Refresh()
                End If
                MyBase.OnMouseUp(e)
            End Sub
            Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
                If (Not Me.m_sideBar Is Nothing) Then
                    Me.m_sideBar.ActiveTab.DrawTabContent(e.Graphics, Me.Font, New Rectangle(0, 0, MyBase.Width, MyBase.Height))
                End If
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace