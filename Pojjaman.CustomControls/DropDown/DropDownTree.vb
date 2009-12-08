Imports System.ComponentModel
Namespace Longkong.Pojjaman.Gui.Components
    Public Class DropDownTree
        Inherits System.Windows.Forms.UserControl

#Region "Members"
        Private treeLabel As DropDownLabel
        Public treeView As treeView

        Private tvMinHeight As Integer
        Private tvMinWidth As Integer

        Private Margin As Integer

        Private parentMouse As MouseEventArgs
        Protected TextValueSet As Boolean

        Public txtValue As System.Windows.Forms.TextBox
        Protected btnSelect As DropDownButton
        Protected pnlCombo As Panel

        Private m_value As Object

        Private m_valueSetting As Boolean

        Public Event ValueChanged As ValueChangedHandler
#End Region

#Region "Constructors"
        Public Sub New()
            Me.Margin = 10
            Me.tvMinWidth = 0
            Me.tvMinHeight = 150
            Me.TextValueSet = False
            Me.InitControls()
            Me.SetSizeAndLocation()
            Dim controlArray1 As Control() = New Control() {Me.pnlCombo, Me.treeView}
            MyBase.Controls.AddRange(controlArray1)
            AddHandler MyBase.Resize, New EventHandler(AddressOf Me.ControlResize)
            AddHandler MyBase.LocationChanged, New EventHandler(AddressOf Me.ControlResize)
        End Sub
        Private Sub InitControls()
            Me.txtValue = New TextBox
            Me.TextReadOnly = True
            Me.btnSelect = New DropDownButton
            AddHandler Me.btnSelect.MouseDown, AddressOf Me.ButtonClicked

            Me.pnlCombo = New Panel
            Me.pnlCombo.BorderStyle = BorderStyle.FixedSingle
            Me.pnlCombo.Controls.Add(Me.txtValue)
            Me.pnlCombo.Controls.Add(Me.btnSelect)

            Me.treeView = New treeView
            Me.treeView.BorderStyle = BorderStyle.FixedSingle
            Me.treeView.Visible = False
            AddHandler Me.treeView.AfterSelect, New TreeViewEventHandler(AddressOf Me.TreeViewNodeSelect)
            AddHandler Me.treeView.DoubleClick, New EventHandler(AddressOf Me.TreeViewNodeDoubleClickSelect)
            AddHandler Me.treeView.MouseMove, New MouseEventHandler(AddressOf Me.TreeViewMouseMoveEventHandler)
            AddHandler Me.treeView.LostFocus, New EventHandler(AddressOf Me.LostFocusTimeStart)
            Me.treeView.Size = New Size(Me.tvMinWidth, Me.tvMinHeight)

            Me.treeLabel = New DropDownLabel
            Me.treeLabel.Size = New Size(16, 16)
            Me.treeLabel.BackColor = Color.Transparent
            Me.treeView.Controls.Add(Me.treeLabel)
            Me.SetHotSpot()


            MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
            MyBase.SetStyle(ControlStyles.ResizeRedraw, True)
        End Sub
#End Region

#Region "Methods"
        Private Sub ControlResize(ByVal sender As Object, ByVal e As EventArgs)
            Me.SetSizeAndLocation()
        End Sub
        Private Function is_in_range(ByVal rvalue As Integer, ByVal start As Integer, ByVal [end] As Integer) As Boolean
            If ((rvalue >= start) AndAlso (rvalue <= [end])) Then
                Return True
            End If
            Return False
        End Function
        Private Sub ParentMouseMoveHandler(ByVal sender As Object, ByVal e As MouseEventArgs)
            Me.parentMouse = e
            Dim num1 As Integer = (Me.treeView.Left + Me.treeView.Width)
            Dim num2 As Integer = (Me.treeView.Top + Me.treeView.Height)
            Me.SetHotSpot()
            If (e.Button = MouseButtons.Left) Then
                Me.Margin = 50
                Me.treeLabel.BringToFront()
            Else
                Me.Margin = 4
            End If
            If (Me.is_in_range(e.Y, (num2 - Me.Margin), (num2 + Me.Margin)) AndAlso Me.is_in_range(e.X, (num1 - Me.Margin), (num1 + Me.Margin))) Then
                Me.SetCursor(Cursors.SizeNWSE)
                If (e.Button = MouseButtons.Left) Then
                    Me.treeView.Height = (e.Y - Me.treeView.Top)
                    Me.treeView.Width = (e.X - Me.treeView.Left)
                End If
            Else
                Me.SetCursor(Cursors.Default)
            End If
        End Sub
        Private Sub SetCursor(ByVal crs As Cursor)
            Me.treeView.Cursor = crs
            MyBase.Parent.Cursor = crs
        End Sub
        Private Sub SetHotSpot()
            Me.treeLabel.Top = (Me.treeView.Height - Me.treeLabel.Height)
            Me.treeLabel.Left = (Me.treeView.Width - Me.treeLabel.Width)
        End Sub
        Private Sub SetTextValueToSelectedNode()
            If Me.SelectedNode Is Nothing Then
                Me.TextValueSet = False
            End If
            Me.Value = Me.SelectedNode.Tag
            If Me.SelectedNode.Text.IndexOf("-"c) < 0 Then
                Me.txtValue.Text = Me.SelectedNode.Text
            Else
                Me.txtValue.Text = Me.SelectedNode.Text.Split("-"c)(1)
                Me.txtValue.Text = Me.txtValue.Text.TrimStart(" "c)
            End If
            Me.TextValueSet = True
        End Sub
        Public Sub SetTreeViewMinimumSize()
            If ((Me.treeView.Width < MyBase.Width) OrElse (Me.treeView.Height < 150)) Then
                Me.treeView.Width = MyBase.Width + 100
                Me.treeView.Height = 100
            End If
        End Sub
        Private Sub SetTreeViewSizeAndLocation()
            If (Not Me.treeView Is Nothing) Then
                Me.treeView.Location = New Point(MyBase.Left, ((MyBase.Top + MyBase.Height) + 1))
            End If
        End Sub
        Private Sub SetSizeAndLocation()
            Me.tvMinWidth = MyBase.Width
            If ((Not Me.txtValue Is Nothing) AndAlso (Not Me.btnSelect Is Nothing)) Then
                Me.pnlCombo.Width = MyBase.Width
                Me.btnSelect.Size = New Size(18, Me.txtValue.Height)
                Me.txtValue.Width = ((Me.pnlCombo.Width - Me.btnSelect.Width) - 1)
                Me.txtValue.Location = New Point(0, 0)
                Me.btnSelect.Left = (Me.txtValue.Width - 1)
                Me.SetTreeViewSizeAndLocation()
                MyBase.Height = Me.txtValue.Height + 2
                Me.pnlCombo.Height = MyBase.Height
            End If
        End Sub
        Private t As Timer
        Private aboutToExpand As Boolean = False
        Private Sub LostFocusTimeStart(ByVal sender As Object, ByVal e As EventArgs)
            t = New Timer
            t.Interval = 100
            AddHandler t.Tick, AddressOf TimeTick
            t.Start()
        End Sub
        Private Sub ButtonClicked(ByVal sender As Object, ByVal e As MouseEventArgs)
            aboutToExpand = True
            ToggleTreeView(sender, e)
        End Sub
        Private Sub TimeTick(ByVal sender As Object, ByVal e As EventArgs)
            aboutToExpand = False
            ToggleTreeView(sender, e)
        End Sub
        Private Sub ToggleTreeView(ByVal sender As Object, ByVal e As EventArgs)
            If aboutToExpand Then
                Me.SetTreeViewSizeAndLocation()
                Try
                    treeView.Visible = True
                    Me.btnSelect.Text = "-"
                    MyBase.Parent.Controls.Add(Me.treeView)
                    Me.treeView.BringToFront()
                    Me.treeView.Visible = True
                    Me.treeView.Select()
                    AddHandler MyBase.Parent.MouseMove, New MouseEventHandler(AddressOf Me.ParentMouseMoveHandler)
                    If ((Me.treeView.Width >= MyBase.Width) AndAlso (Me.treeView.Height >= MyBase.Height)) Then
                        Return
                    End If
                    Me.treeView.Width = Me.tvMinWidth + 100
                    Me.treeView.Height = 100
                    Me.SetHotSpot()
                Catch ex As Exception
                End Try
            Else
                If Not t Is Nothing Then
                    t.Stop()
                End If
                Try
                    Me.treeView.SelectedNode = TreeViewHelper.SearchTag(Me.treeView, CInt(Me.Value))
                    Me.btnSelect.Text = "+"
                    Me.treeView.Visible = False
                    MyBase.Parent.Controls.Remove(Me.treeView)
                    RemoveHandler MyBase.Parent.MouseMove, New MouseEventHandler(AddressOf Me.ParentMouseMoveHandler)
                Catch ex As Exception
                    Return
                End Try
            End If
        End Sub
        Private Sub TreeViewMouseMoveEventHandler(ByVal sender As Object, ByVal e As MouseEventArgs)
            Me.parentMouse = e
            Me.SetCursor(Cursors.Default)
        End Sub
        Private Sub TreeViewNodeDoubleClickSelect(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.SelectedNode.Nodes.Count = 0) Then
                Me.SetTextValueToSelectedNode()
            End If
            If Me.TextValueSet Then
                aboutToExpand = False
                Me.ToggleTreeView(sender, Nothing)
            End If
        End Sub
        Protected Sub TreeViewNodeSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
            'If (Me.SelectedNode.Nodes.Count = 0) Then
            '    Me.SetTextValueToSelectedNode()
            'End If
        End Sub
#End Region

#Region "Properties"
        <Browsable(False)> _
        Public Property ValueSetting() As Boolean            Get                Return m_valueSetting            End Get            Set(ByVal Value As Boolean)                m_valueSetting = Value            End Set        End Property        <Browsable(False)> _        Public Property Value() As Object            Get                Return m_value            End Get            Set(ByVal Value As Object)                Dim e As New ValueChangedEventArgs                e.OldValue = m_value                e.NewValue = Value                m_value = Value                Me.treeView.SelectedNode = TreeViewHelper.SearchTag(Me.treeView, CInt(Value))                If Me.treeView.SelectedNode Is Nothing Then                    Me.txtValue.Text = ""                    RaiseEvent ValueChanged(Me, e)                    Return
                End If                If Me.SelectedNode.Text.IndexOf("-"c) < 0 Then
                    Me.txtValue.Text = Me.SelectedNode.Text
                Else
                    Me.txtValue.Text = Me.SelectedNode.Text.Split("-"c)(1)
                    Me.txtValue.Text = Me.txtValue.Text.TrimStart(" "c)
                End If                RaiseEvent ValueChanged(Me, e)            End Set        End Property
        Public Property Imagelist() As Imagelist
            Get
                Return Me.treeView.ImageList
            End Get
            Set(ByVal value As Imagelist)
                Me.treeView.ImageList = value
            End Set
        End Property
        <Description("Gets the TreeView Nodes collection"), Category("TreeView")> _
        Public ReadOnly Property Nodes() As TreeNodeCollection
            Get
                Return Me.treeView.Nodes
            End Get
        End Property
        <Category("TreeView"), Description("Gets or sets the TreeView's Selected Node")> _
        Public Property SelectedNode() As TreeNode
            Get
                Return Me.treeView.SelectedNode
            End Get
            Set(ByVal value As TreeNode)
                Me.treeView.SelectedNode = value
            End Set
        End Property
        <Category("TextBox"), Description("Gets or sets the TextBox's ReadOnly state")> _
        Public Property TextReadOnly() As Boolean
            Get
                Return Me.txtValue.ReadOnly
            End Get
            Set(ByVal value As Boolean)
                Me.txtValue.ReadOnly = value
            End Set
        End Property
#End Region

    End Class
    Public Delegate Sub ValueChangedHandler(ByVal sender As Object, ByVal e As ValueChangedEventArgs)

    Public Class ValueChangedEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_oldValue As Object
        Private m_newValue As Object
#End Region

#Region "Consructors"

#End Region

#Region "Properties"
        Public Property OldValue() As Object            Get                Return m_oldValue            End Get            Set(ByVal Value As Object)                m_oldValue = Value            End Set        End Property        Public Property NewValue() As Object            Get                Return m_newValue            End Get            Set(ByVal Value As Object)                m_newValue = Value            End Set        End Property
#End Region

    End Class

End Namespace

