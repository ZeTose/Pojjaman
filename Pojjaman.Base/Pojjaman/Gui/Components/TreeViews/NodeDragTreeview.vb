Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Threading
Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui.Components
    Public Class NodeDragTreeview
        Inherits TreeView

#Region " ::::::::::: Private fields ::::::::::::: "
        Private components As System.ComponentModel.Container
        Private m_showNodeWhileDragging As Boolean = True
        Dim m_draggedNode As DraggedNode
        Dim m_mouseOverNodeRect As Rectangle
        Dim m_mouseOverNodeIndex As Integer
#End Region

#Region " ::::::::::: Properties ::::::::::::: "
        Public Property ShowNodeWhileDragging() As Boolean
            Get
                Return m_showNodeWhileDragging
            End Get
            Set(ByVal Value As Boolean)
                m_showNodeWhileDragging = Value
            End Set
        End Property
#End Region

#Region " ::::::::::: Parameterless constructor ::::::::::::: "
        Public Sub New()
            InitializeComponent()
            ResetMembersToDefault()
            Me.SetStyle(ControlStyles.DoubleBuffer, True)
        End Sub

#End Region

#Region " ::::::::::: Dispose ::::::::::::: "
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
#End Region

#Region " ::::::::::: Component Designer generated code ::::::::::::: "

        Private Sub InitializeComponent()
            Me.Anchor = AnchorStyles.None
            Me.Size = New System.Drawing.Size(500, 300)
            AddHandler Me.MouseDown, AddressOf Me.NodeDragTreeView_MouseDown
            'AddHandler Me.MouseUp, AddressOf Me.NodeDragTreeView_MouseUp
            AddHandler Me.MouseMove, AddressOf Me.NodeDragTreeView_MouseMove
        End Sub
#End Region

#Region " ::::::::::: Overridden methods ::::::::::::: "

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            If Not m_draggedNode Is Nothing Then
                Dim g As Graphics = e.Graphics
                Dim x As Integer = m_draggedNode.InitialRegion.X
                Dim y As Integer = m_draggedNode.InitialRegion.Y
                Dim width As Integer = m_draggedNode.InitialRegion.Width
                Dim height As Integer = m_draggedNode.InitialRegion.Height
                Dim region As Rectangle = New Rectangle(x, y, width, height)


                ' Color of border
                Dim blackBrush As SolidBrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
                ' Color of the interier of source column
                Dim darkGreyBrush As SolidBrush = New SolidBrush(Color.FromArgb(150, 50, 50, 50))
                ' Draw border around source column
                Dim blackPen As Pen = New Pen(blackBrush, 2.0F)


                g.FillRectangle(darkGreyBrush, m_draggedNode.InitialRegion)
                g.DrawRectangle(blackPen, region)

                blackBrush.Dispose()
                darkGreyBrush.Dispose()
                blackPen.Dispose()

                If Not Me.m_mouseOverNodeIndex = -1 Then
                    ' Color of target column
                    Dim b As SolidBrush = New SolidBrush(Color.FromArgb(100, 100, 100, 100))
                    g.FillRectangle(b, m_mouseOverNodeRect)
                    b.Dispose()

                End If

                ' draw bitmap image
                If ShowNodeWhileDragging Then
                    g.DrawImage(m_draggedNode.NodeImage, m_draggedNode.CurrentRegion.X, m_draggedNode.CurrentRegion.Y)
                End If

                ' translucent film
                Dim filmBorder As Pen = New Pen(New SolidBrush(Color.FromArgb(255, 200, 200, 230)), 2.0F)
                Dim filmFill As SolidBrush = New SolidBrush(Color.FromArgb(100, 200, 200, 255))

                g.FillRectangle(filmFill, m_draggedNode.CurrentRegion.X, m_draggedNode.CurrentRegion.Y, m_draggedNode.CurrentRegion.Width, m_draggedNode.CurrentRegion.Height)
                g.DrawRectangle(filmBorder, New Rectangle(m_draggedNode.CurrentRegion.X, m_draggedNode.CurrentRegion.Y + Convert.ToInt16(filmBorder.Width), width, height))

                filmBorder.Dispose()
                filmFill.Dispose()

            End If
        End Sub
#End Region

#Region " ::::::::::: Event Handlers ::::::::::::: "
        Private Sub NodeDragTreeView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim pt As System.Drawing.Point
            pt = Me.PointToClient(Me.MousePosition)
            Dim node As TreeNode = Me.GetNodeAt(pt)
            If (e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right And ((Not IsNothing(node))) AndAlso node.Bounds.Contains(pt)) Then
                Me.SelectedNode = node
            End If

            If Not IsNothing(node) AndAlso Me.m_draggedNode Is Nothing Then
                NodeManager(node, e)
            End If

            Me.Update()
            If ShowNodeWhileDragging Then
                Me.CreateGraphics().DrawImage(m_draggedNode.NodeImage, m_draggedNode.CurrentLocation.X + 50, m_draggedNode.CurrentLocation.Y)
            End If
        End Sub

        Private Sub NodeDragTreeView_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Try
                If e.Button = MouseButtons.None Then Exit Sub
                If Me.m_draggedNode Is Nothing Then Exit Sub
                Dim pt As Point
                pt = Me.PointToClient(New Point(e.X, e.Y))
                Dim targetNode As TreeNode
                If Me.SelectedNode.Bounds.Contains(pt) Then
                    Exit Sub
                End If
                targetNode = Me.GetNodeAt(pt)

                If Not m_draggedNode Is Nothing And e.X >= 0 And Not IsNothing(targetNode) Then

                    Dim x As Integer = e.X - m_draggedNode.CurrentLocation.X
                    Dim y As Integer = e.Y - m_draggedNode.CurrentLocation.Y
                    If Not Me.SelectedNode Is targetNode Then

                        ' NOTE: moc = mouse over node
                        Dim monX As Integer = targetNode.Bounds.X
                        Dim monWidth As Integer = targetNode.Bounds.Width
                        'Dim mocWidth As Integer = Me.TableStyles(Me.DataMember.ToString).GridColumnStyles(hti.Column).Width

                        '  indicate that we want to invalidate the old rectangle area
                        If Not (m_mouseOverNodeRect.Equals(Rectangle.Empty)) Then
                            Me.Invalidate(m_mouseOverNodeRect, False)
                        End If  ' (m_mouseOverColumnRect = Rectangle.Empty)


                        ' if the mouse is hovering over the original column, we do not want to
                        ' paint anything, so we negate the index.
                        If (Me.SelectedNode Is targetNode) Then
                            m_mouseOverNodeIndex = -1
                        Else
                            m_mouseOverNodeIndex = 1333
                        End If   '  (hti.Column = m_draggedColumn.Index) 


                        m_mouseOverNodeRect = targetNode.Bounds 'New Rectangle(monX, m_draggedNode.InitialRegion.Y, monWidth, m_draggedNode.InitialRegion.Height)

                        ' invalidate this area so it gets painted when OnPaint is called.
                        Me.Invalidate(m_mouseOverNodeRect, False)

                    End If

                    Dim oldX As Integer = m_draggedNode.CurrentRegion.X
                    Dim oldY As Integer = m_draggedNode.CurrentLocation.Y
                    Dim oldPoint As Point = Point.Empty

                    ' column is being dragged to the right
                    If (oldX < x) Then
                        oldPoint = New Point(oldX - 5, m_draggedNode.InitialRegion.Y)
                    Else
                        ' to the left
                        oldPoint = New Point(x - 5, m_draggedNode.InitialRegion.Y)
                    End If   'oldX < x
                    'node is being draged down
                    If oldY < y Then
                        oldPoint = New Point(oldPoint.X, oldY - 5)
                    Else 'up
                        oldPoint = New Point(oldPoint.X, y - 5)
                    End If

                    Dim sizeOfRectangleToInvalidate As Size = New Size(Math.Abs(x - oldX) + m_draggedNode.InitialRegion.Width + (oldPoint.X * 2), m_draggedNode.InitialRegion.Height)
                    Me.Invalidate(New Rectangle(oldPoint, sizeOfRectangleToInvalidate))

                    m_draggedNode.CurrentRegion = New Rectangle(x, m_draggedNode.InitialRegion.Y, m_draggedNode.InitialRegion.Width, m_draggedNode.InitialRegion.Height)
                Else
                    Me.Invalidate(Me.ClientRectangle)
                    Me.Update()
                End If
            Catch ex As Exception
                MsgBox(ex.Message & Chr(13) & ex.StackTrace)
            Finally
            End Try

        End Sub

        'Private Sub NodeDragTreeView_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        '    Try

        '        Dim hti As DataGrid.HitTestInfo = Me.HitTest(e.X, e.Y)

        '        '  is column being dropped above itself? if so, we don't want 
        '        ' to do anything
        '        If Not (m_draggedColumn Is Nothing) Then 'And (hti.Column <> m_draggedColumn.Index) Then
        '            Dim dgts As DataGridTableStyle = Me.TableStyles(0)
        '            Dim columns(dgts.GridColumnStyles.Count - 1) As DataGridColumnStyle
        '            dgts.GridColumnStyles.CopyTo(columns, 0)
        '            Dim csi As Integer

        '            For csi = 0 To dgts.GridColumnStyles.Count - 1
        '                If csi <> hti.Column And csi <> m_draggedColumn.Index Then
        '                    columns(csi) = dgts.GridColumnStyles(csi)
        '                ElseIf csi = hti.Column Then
        '                    columns(csi) = dgts.GridColumnStyles(m_draggedColumn.Index)
        '                Else
        '                    columns(csi) = dgts.GridColumnStyles(hti.Column)
        '                End If
        '            Next


        '            Try
        '                Me.SuspendLayout()
        '                Me.TableStyles(0).GridColumnStyles.Clear()
        '                Me.TableStyles(0).GridColumnStyles.AddRange(columns)
        '                Me.ResumeLayout()
        '            Catch ex As Exception
        '                MsgBox(ex.Message & Chr(13) & ex.StackTrace)
        '            End Try

        '        Else
        '            InvalidateColumnArea()
        '        End If

        '        ResetMembersToDefault()

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try


        'End Sub

        Private Sub NodeManager(ByVal node As TreeNode, ByVal e As MouseEventArgs)

            'make sure that the user is hovering above a column header and not a column border.
            Dim xCoordinate As Integer = 0 'Me.GetLeftmostColumnHeaderXCoordinate(hti.Column)
            Dim yCoordinate As Integer = 0 'Me.GetTopmostColumnHeaderYCoordinate(e.X, e.Y)
            Dim nodeWidth As Integer = node.Bounds.Width
            Dim nodeHeight As Integer = node.Bounds.Height

            Dim columnSize As Size = Size.Empty

            '  check to see if the column is partially hidden (to the right then to the left)
            'If ((xCoordinate + nodeWidth) > (Me.ClientSize.Width)) Then

            '    Dim num As Integer = columnWidth - (Me.ClientSize.Width - Me.VertScrollBar.Width - xCoordinate) + 2
            '    Me.MoveHorizScrollBar(num + Me.HorizScrollBar.Value)
            '    xCoordinate = xCoordinate - num

            'ElseIf (Me.TableStyles(0).RowHeadersVisible And xCoordinate < _
            '                Me.TableStyles(0).RowHeaderWidth) Then
            '    Me.MoveHorizScrollBar(-(Me.TableStyles(0).RowHeaderWidth - xCoordinate))
            '    xCoordinate = columnWidth

            'ElseIf (xCoordinate < 0) Then
            '    Dim numberOfHiddenPixels As Integer = 0
            '    Dim i As Integer

            '    For i = 0 To hti.Column - 1
            '        numberOfHiddenPixels = numberOfHiddenPixels + nodeWidth
            '    Next

            '    Me.MoveHorizScrollBar(numberOfHiddenPixels)
            '    xCoordinate = 0
            'End If


            Dim startingLocation As Point = New Point(xCoordinate, yCoordinate)
            Dim nodeRegion As Rectangle = New Rectangle(xCoordinate, yCoordinate, nodeWidth, nodeHeight)
            Dim cursorLocation As Point = New Point(e.X - xCoordinate, e.Y - yCoordinate)

            If ShowNodeWhileDragging Then

                columnSize = New Size(nodeWidth, nodeHeight)

                Dim si As New ScreenImage
                Dim columnImage As Bitmap = CType(si.GetScreenshot(Me.Handle, startingLocation, columnSize), Bitmap)
                m_draggedNode = New DraggedNode(Me.SelectedNode, nodeRegion, cursorLocation, columnImage)

            Else
                m_draggedNode = New DraggedNode(Me.SelectedNode, nodeRegion, cursorLocation)
            End If

            m_draggedNode.CurrentRegion = nodeRegion


        End Sub

#End Region

#Region " ::::::::::: Helper Methods ::::::::::::: "

        ' When a dragged column is dropped on top of its original location, 
        ' whether it’s because the user has decided that they no longer want 
        ' to drag it, or they’ve just happened to release the column in this 
        ' location, we need to invalidate the area where the current drawings 
        ' reside.

        Private Sub InvalidateColumnArea()

            If Not m_draggedNode Is Nothing Then
                Dim startX As Integer
                If (m_draggedNode.InitialRegion.X < m_draggedNode.CurrentRegion.X) Then
                    startX = m_draggedNode.InitialRegion.X
                Else
                    startX = (m_draggedNode.CurrentRegion.X - 5)
                End If

                Dim width As Integer = m_draggedNode.InitialRegion.Width + m_draggedNode.CurrentRegion.Width + 10
                Dim rectangleToInvalidate As Rectangle = New Rectangle(startX, m_draggedNode.InitialRegion.Y, width, m_draggedNode.InitialRegion.Height)
                Me.Invalidate(rectangleToInvalidate)
                Me.Update()
            End If


        End Sub


        ' Resets all of the member fields to their default values.
        Private Sub ResetMembersToDefault()

            If Not m_draggedNode Is Nothing Then
                m_draggedNode.Dispose()
            End If

            m_draggedNode = Nothing
            m_mouseOverNodeRect = Rectangle.Empty
            m_mouseOverNodeIndex = -1

        End Sub

#End Region

        ' Returns the height of the column. The height is defined as the area 
        ' between the bottom portion of the caption area and either the 
        ' bottom of the client rectangle, or the top of the horizontal scroll 
        ' bar if it’s visible.
        'Private Function GetColumnHeight(ByVal topmostYCoordinate As Integer) As Integer
        '    Dim height As Integer = Me.ClientSize.Height

        '    If Me.HorizScrollBar.Visible Then
        '        height = height - Me.HorizScrollBar.Height
        '    End If

        '    Return height - topmostYCoordinate
        'End Function





    End Class
End Namespace
