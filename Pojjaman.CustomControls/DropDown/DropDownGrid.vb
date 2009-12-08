Imports System.ComponentModel
Namespace Longkong.Pojjaman.Gui.Components
    Public Class DropDownGrid
        Inherits System.Windows.Forms.UserControl

#Region "Members"
        Private gridLabel As DropDownLabel
        Public Grid As TreeGrid
        Public TreeManager As TreeManager
        Public TreeTable As TreeTable
        Private m_codeColumnName As String

        Private gridMinHeight As Integer
        Private gridMinWidth As Integer

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
            Me.gridMinWidth = 0
            Me.gridMinHeight = 150
            Me.TextValueSet = False
            Me.InitControls()
            Me.SetSizeAndLocation()
            Dim controlArray1 As Control() = New Control() {Me.pnlCombo, Me.Grid}
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

            Me.Grid = New TreeGrid
            Me.Grid.BorderStyle = BorderStyle.FixedSingle
            Me.Grid.AllowSorting = False
            Me.Grid.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.Grid.CaptionVisible = False
            Me.Grid.Cellchanged = False
            Me.Grid.HeaderBackColor = System.Drawing.Color.Khaki
            Me.Grid.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.Grid.Location = New System.Drawing.Point(24, 136)
            Me.Grid.Size = New System.Drawing.Size(680, 224)
            Me.Grid.SortingArrowColor = System.Drawing.Color.Red
            Me.Grid.Visible = False
            AddHandler Me.Grid.DoubleClick, New EventHandler(AddressOf Me.GridRowDoubleClickSelect)
            AddHandler Me.Grid.MouseMove, New MouseEventHandler(AddressOf Me.GridMouseMoveEventHandler)
            AddHandler Me.Grid.LostFocus, New EventHandler(AddressOf Me.LostFocusTimeStart)
            Me.Grid.Size = New Size(Me.gridMinWidth, Me.gridMinHeight)

            Me.gridLabel = New DropDownLabel
            Me.gridLabel.Size = New Size(16, 16)
            Me.gridLabel.BackColor = Color.Transparent
            Me.Grid.Controls.Add(Me.gridLabel)
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
            Dim num1 As Integer = (Me.Grid.Left + Me.Grid.Width)
            Dim num2 As Integer = (Me.Grid.Top + Me.Grid.Height)
            Me.SetHotSpot()
            If (e.Button = MouseButtons.Left) Then
                Me.Margin = 50
                Me.gridLabel.BringToFront()
            Else
                Me.Margin = 4
            End If
            If (Me.is_in_range(e.Y, (num2 - Me.Margin), (num2 + Me.Margin)) AndAlso Me.is_in_range(e.X, (num1 - Me.Margin), (num1 + Me.Margin))) Then
                Me.SetCursor(Cursors.SizeNWSE)
                If (e.Button = MouseButtons.Left) Then
                    Me.Grid.Height = (e.Y - Me.Grid.Top)
                    Me.Grid.Width = (e.X - Me.Grid.Left)
                End If
            Else
                Me.SetCursor(Cursors.Default)
            End If
        End Sub
        Private Sub SetCursor(ByVal crs As Cursor)
            Me.Grid.Cursor = crs
            MyBase.Parent.Cursor = crs
        End Sub
        Private Sub SetHotSpot()
            Me.gridLabel.Top = (Me.Grid.Height - Me.gridLabel.Height)
            Me.gridLabel.Left = (Me.Grid.Width - Me.gridLabel.Width)
        End Sub
        Private Sub SetSizeAndLocation()
            Me.gridMinWidth = MyBase.Width
            If ((Not Me.txtValue Is Nothing) AndAlso (Not Me.btnSelect Is Nothing)) Then
                Me.pnlCombo.Width = MyBase.Width
                Me.btnSelect.Size = New Size(18, Me.txtValue.Height)
                Me.txtValue.Width = ((Me.pnlCombo.Width - Me.btnSelect.Width) - 1)
                Me.txtValue.Location = New Point(0, 0)
                Me.btnSelect.Left = (Me.txtValue.Width - 1)
                Me.SetGridSizeAndLocation()
                MyBase.Height = Me.txtValue.Height + 2
                Me.pnlCombo.Height = MyBase.Height
            End If
        End Sub
        Private Sub SetTextValueToSelectedRow()
            If Me.SelectedRow Is Nothing Then
                Me.TextValueSet = False
            End If
            Me.Value = Me.SelectedRow.Tag
            Me.txtValue.Text = Me.SelectedRow(Me.m_codeColumnName).ToString
            Me.TextValueSet = True
        End Sub
        Public Sub SetGridMinimumSize()
            If ((Me.Grid.Width < MyBase.Width) OrElse (Me.Grid.Height < 150)) Then
                Me.Grid.Width = MyBase.Width + 100
                Me.Grid.Height = 100
            End If
        End Sub
        Private Sub SetGridSizeAndLocation()
            If (Not Me.Grid Is Nothing) Then
                Me.Grid.Location = New Point(MyBase.Left, ((MyBase.Top + MyBase.Height) + 1))
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
            ToggleGrid(sender, e)
        End Sub
        Private Sub TimeTick(ByVal sender As Object, ByVal e As EventArgs)
            aboutToExpand = False
            ToggleGrid(sender, e)
        End Sub
        Private Sub ToggleGrid(ByVal sender As Object, ByVal e As EventArgs)
            If aboutToExpand Then
                Me.SetGridSizeAndLocation()
                Try
                    Me.btnSelect.Text = "-"
                    MyBase.Parent.Controls.Add(Me.Grid)
                    Me.Grid.BringToFront()
                    Me.Grid.Visible = True
                    Me.Grid.Select()
                    AddHandler MyBase.Parent.MouseMove, New MouseEventHandler(AddressOf Me.ParentMouseMoveHandler)
                    If ((Me.Grid.Width >= MyBase.Width) AndAlso (Me.Grid.Height >= MyBase.Height)) Then
                        Return
                    End If
                    Me.Grid.Width = Me.gridMinWidth + 100
                    Me.Grid.Height = 100
                    Me.SetHotSpot()
                Catch ex As Exception
                End Try
            Else
                If Not t Is Nothing Then
                    t.Stop()
                End If
                Try
                    Me.TreeManager.SelectedRow = Nothing
                    Me.btnSelect.Text = "+"
                    Me.Grid.Visible = False
                    MyBase.Parent.Controls.Remove(Me.Grid)
                    RemoveHandler MyBase.Parent.MouseMove, New MouseEventHandler(AddressOf Me.ParentMouseMoveHandler)
                Catch ex As Exception
                    Return
                End Try
            End If
        End Sub
        Private Sub GridMouseMoveEventHandler(ByVal sender As Object, ByVal e As MouseEventArgs)
            Me.parentMouse = e
            Me.SetCursor(Cursors.Default)
        End Sub
        Private Sub GridRowDoubleClickSelect(ByVal sender As Object, ByVal e As EventArgs)
            Me.SetTextValueToSelectedRow()
            If Me.TextValueSet Then
                aboutToExpand = False
                Me.ToggleGrid(sender, Nothing)
            End If
        End Sub
#End Region

#Region "Properties"
        <Browsable(False)> _
        Public Property ValueSetting() As Boolean            Get                Return m_valueSetting            End Get            Set(ByVal Value As Boolean)                m_valueSetting = Value            End Set        End Property        <Browsable(False)> _        Public Property Value() As Object            Get                Return m_value            End Get            Set(ByVal Value As Object)                Dim e As New ValueChangedEventArgs                e.OldValue = m_value                e.NewValue = Value                m_value = Value                'Me.treeView.SelectedNode = TreeViewHelper.SearchTag(Me.treeView, CInt(Value))                'If Me.treeView.SelectedNode Is Nothing Then                '    Me.txtValue.Text = ""                '    RaiseEvent ValueChanged(Me, e)                '    Return
                'End If                'If Me.SelectedNode.Text.IndexOf("-"c) < 0 Then
                '    Me.txtValue.Text = Me.SelectedNode.Text
                'Else
                '    Me.txtValue.Text = Me.SelectedNode.Text.Split("-"c)(0)
                '    Me.txtValue.Text = Me.txtValue.Text.TrimEnd(" "c)
                'End If                RaiseEvent ValueChanged(Me, e)            End Set        End Property
        <Browsable(False)> _
        Public Property SelectedRow() As TreeRow
            Get
                Return Me.TreeManager.SelectedRow
            End Get
            Set(ByVal value As TreeRow)
                Me.TreeManager.SelectedRow = value
            End Set
        End Property
        <Category("Grid"), Description("Gets or sets the TreeGrid's Code column name")> _
        Public Property CodeColumnName() As String
            Get
                Return Me.m_codeColumnName
            End Get
            Set(ByVal value As String)
                Me.m_codeColumnName = value
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

End Namespace

