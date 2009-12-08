Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Threading
Imports System.Windows.Forms

Namespace Longkong.Pojjaman.Gui.Components

    Public Class ColumnDragDataGrid
        Inherits DataGrid


#Region " ::::::::::: Private fields ::::::::::::: "
        Private components As System.ComponentModel.Container

        Private m_showColumnWhileDragging As Boolean = True
        Private m_showColumnHeaderWhileDragging As Boolean = True
        Private m_allowColumnDrag As Boolean = True

        Dim m_draggedColumn As DraggedDataGridColumn
        Dim m_mouseOverColumnRect As Rectangle
        Dim m_mouseOverColumnIndex As Integer

#End Region

#Region " ::::::::::: Properties ::::::::::::: "
        Public Property AllowColumnDrag() As Boolean
            Get
                Return m_allowColumnDrag
            End Get
            Set(ByVal Value As Boolean)
                m_allowColumnDrag = Value
            End Set
        End Property
        Public Property ShowColumnWhileDragging() As Boolean
            Get
                Return m_showColumnWhileDragging
            End Get
            Set(ByVal Value As Boolean)
                m_showColumnWhileDragging = Value
            End Set
        End Property

        Public Property ShowColumnHeaderWhileDragging() As Boolean
            Get
                Return m_showColumnHeaderWhileDragging
            End Get
            Set(ByVal Value As Boolean)
                m_showColumnHeaderWhileDragging = Value
            End Set
        End Property

#End Region

#Region " ::::::::::: Parameterless constructor ::::::::::::: "
        Public Sub New()
            InitializeComponent()
            ResetMembersToDefault()
            'Me.SetStyle(ControlStyles.DoubleBuffer, True)
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
            'Me.Anchor = AnchorStyles.None
            'Me.Size = New System.Drawing.Size(500, 300)
            AddHandler Me.MouseDown, AddressOf Me.ColumnDragDataGrid_MouseDown
            AddHandler Me.MouseUp, AddressOf Me.ColumnDragDataGrid_MouseUp
            AddHandler Me.MouseMove, AddressOf Me.ColumnDragDataGrid_MouseMove
        End Sub
#End Region

#Region " ::::::::::: Overridden methods ::::::::::::: "

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            If Not m_draggedColumn Is Nothing Then
                Dim g As Graphics = e.Graphics
                Dim x As Integer = m_draggedColumn.InitialRegion.X
                Dim y As Integer = m_draggedColumn.InitialRegion.Y
                Dim width As Integer = m_draggedColumn.InitialRegion.Width
                Dim height As Integer = m_draggedColumn.InitialRegion.Height
                Dim region As Rectangle = New Rectangle(x, y, width, height)


                ' Color of border
                Dim blackBrush As SolidBrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
                ' Color of the interier of source column
                Dim darkGreyBrush As SolidBrush = New SolidBrush(Color.FromArgb(150, 50, 50, 50))
                ' Draw border around source column
                Dim blackPen As Pen = New Pen(blackBrush, 2.0F)


                g.FillRectangle(darkGreyBrush, m_draggedColumn.InitialRegion)
                g.DrawRectangle(blackPen, region)

                blackBrush.Dispose()
                darkGreyBrush.Dispose()
                blackPen.Dispose()

                If Not Me.m_mouseOverColumnIndex = -1 Then
                    ' Color of target column
                    Dim b As SolidBrush = New SolidBrush(Color.FromArgb(100, 100, 100, 100))
                    g.FillRectangle(b, m_mouseOverColumnRect)
                    b.Dispose()

                End If

                ' draw bitmap image
                If ShowColumnWhileDragging Or ShowColumnHeaderWhileDragging Then
                    g.DrawImage(m_draggedColumn.ColumnImage, m_draggedColumn.CurrentRegion.X, m_draggedColumn.CurrentRegion.Y)
                End If

                ' translucent file
                Dim filmBorder As Pen = New Pen(New SolidBrush(Color.FromArgb(255, 200, 200, 230)), 2.0F)
                Dim filmFill As SolidBrush = New SolidBrush(Color.FromArgb(100, 200, 200, 255))

                g.FillRectangle(filmFill, m_draggedColumn.CurrentRegion.X, m_draggedColumn.CurrentRegion.Y, m_draggedColumn.CurrentRegion.Width, m_draggedColumn.CurrentRegion.Height)
                g.DrawRectangle(filmBorder, New Rectangle(m_draggedColumn.CurrentRegion.X, m_draggedColumn.CurrentRegion.Y + Convert.ToInt16(filmBorder.Width), width, height))

                filmBorder.Dispose()
                filmFill.Dispose()

            End If
        End Sub

        Protected Overrides Sub OnDataSourceChanged(ByVal e As EventArgs)
            MyBase.OnDataSourceChanged(e)

            ' check to see if a style already exists for the mapping name
            Dim doesStyleExist As Boolean = False
            Dim dgts As DataGridTableStyle
            Dim ts As DataGridTableStyle

            For Each ts In Me.TableStyles
                If ts.MappingName.Equals(Me.DataMember) Then
                    doesStyleExist = True
                    Exit For
                End If
            Next

            If doesStyleExist = False Then
                dgts = New DataGridTableStyle
                dgts.MappingName = Me.DataMember
                Me.TableStyles.Add(dgts)
            End If

            Me.TableStyles(Me.DataMember.ToString).RowHeadersVisible = Me.RowHeadersVisible
            Me.TableStyles(Me.DataMember.ToString).ColumnHeadersVisible = Me.ColumnHeadersVisible
            Me.TableStyles(Me.DataMember.ToString).AllowSorting = Me.AllowSorting

        End Sub

#End Region

#Region " ::::::::::: Event Handlers ::::::::::::: "
        Private Sub ColumnDragDataGrid_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)

            Dim hti As DataGrid.HitTestInfo = Me.HitTest(e.X, e.Y)

            If m_allowColumnDrag AndAlso Not ((hti.Type And DataGrid.HitTestType.ColumnHeader) = 0) AndAlso _
                 ((hti.Type And DataGrid.HitTestType.ColumnResize) = 0) AndAlso Me.m_draggedColumn Is Nothing Then

                ColumnManager(hti, e)

            End If

            Me.Update()

        End Sub

        Private Sub ColumnDragDataGrid_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Try
                Dim hti As DataGrid.HitTestInfo = Me.HitTest(e.X, e.Y)

                If Not m_draggedColumn Is Nothing And e.X >= 0 Then

                    Dim x As Integer = e.X - m_draggedColumn.CurrentLocation.X


                    ' detect the column that the cursor is currently hovering above and
                    ' calculate its region.
                    If hti.Column >= 0 Then

                        If hti.Column <> m_mouseOverColumnIndex Then

                            ' NOTE: moc = mouse over column
                            Dim mocX As Integer = Me.GetLeftmostColumnHeaderXCoordinate(hti.Column)
                            Dim mocWidth As Integer = Me.GetCellBounds(0, hti.Column).Width
                            'Dim mocWidth As Integer = Me.TableStyles(Me.DataMember.ToString).GridColumnStyles(hti.Column).Width

                            '  indicate that we want to invalidate the old rectangle area
                            If Not (m_mouseOverColumnRect.Equals(Rectangle.Empty)) Then
                                Me.Invalidate(m_mouseOverColumnRect, False)
                            End If  ' (m_mouseOverColumnRect = Rectangle.Empty)


                            ' if the mouse is hovering over the original column, we do not want to
                            ' paint anything, so we negate the index.
                            If (hti.Column = m_draggedColumn.Index) Then
                                m_mouseOverColumnIndex = -1
                            Else
                                m_mouseOverColumnIndex = hti.Column
                            End If   '  (hti.Column = m_draggedColumn.Index) 


                            m_mouseOverColumnRect = New Rectangle(mocX, m_draggedColumn.InitialRegion.Y, mocWidth, m_draggedColumn.InitialRegion.Height)

                            ' invalidate this area so it gets painted when OnPaint is called.
                            Me.Invalidate(m_mouseOverColumnRect, False)

                        End If   ' hti.Column <> m_mouseOverColumnIndex


                        Dim oldX As Integer = m_draggedColumn.CurrentRegion.X
                        Dim oldPoint As Point = Point.Empty

                        ' column is being dragged to the right
                        If (oldX < x) Then
                            oldPoint = New Point(oldX - 5, m_draggedColumn.InitialRegion.Y)
                        Else
                            ' to the left
                            oldPoint = New Point(x - 5, m_draggedColumn.InitialRegion.Y)
                        End If   'oldX < x


                        Dim sizeOfRectangleToInvalidate As Size = New Size(Math.Abs(x - oldX) + m_draggedColumn.InitialRegion.Width + (oldPoint.X * 2), m_draggedColumn.InitialRegion.Height)
                        Me.Invalidate(New Rectangle(oldPoint, sizeOfRectangleToInvalidate))

                        m_draggedColumn.CurrentRegion = New Rectangle(x, m_draggedColumn.InitialRegion.Y, m_draggedColumn.InitialRegion.Width, m_draggedColumn.InitialRegion.Height)

                    Else
                        InvalidateColumnArea()
                        ResetMembersToDefault()

                    End If    'hti.Column <= 0

                Else

                    Me.Invalidate(Me.ClientRectangle)
                    Me.Update()

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try

        End Sub

        Private Sub ColumnDragDataGrid_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            Try

                Dim hti As DataGrid.HitTestInfo = Me.HitTest(e.X, e.Y)

                '  is column being dropped above itself? if so, we don't want 
                ' to do anything
                If Not (m_draggedColumn Is Nothing) Then 'And (hti.Column <> m_draggedColumn.Index) Then
                    Dim dgts As DataGridTableStyle = Me.TableStyles(0)
                    Dim columns(dgts.GridColumnStyles.Count - 1) As DataGridColumnStyle
                    dgts.GridColumnStyles.CopyTo(columns, 0)
                    Dim csi As Integer

                    For csi = 0 To dgts.GridColumnStyles.Count - 1
                        If csi <> hti.Column And csi <> m_draggedColumn.Index Then
                            columns(csi) = dgts.GridColumnStyles(csi)
                        ElseIf csi = hti.Column Then 'the target Column
                            columns(csi) = dgts.GridColumnStyles(m_draggedColumn.Index)
                        Else 'the dragged column
                            columns(csi) = dgts.GridColumnStyles(hti.Column)
                        End If
                    Next


                    Try
                        Me.SuspendLayout()
                        Me.TableStyles(0).GridColumnStyles.Clear()
                        Me.TableStyles(0).GridColumnStyles.AddRange(columns)
                        Me.ResumeLayout()
                    Catch ex As Exception
                        MsgBox(ex.Message & Chr(13) & ex.StackTrace)
                    End Try

                Else
                    InvalidateColumnArea()
                End If

                ResetMembersToDefault()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End Sub

        Private Sub ColumnManager(ByVal hti As DataGrid.HitTestInfo, ByVal e As MouseEventArgs)

            'make sure that the user is hovering above a column header and not a column border.
            Dim xCoordinate As Integer = Me.GetLeftmostColumnHeaderXCoordinate(hti.Column)
            Dim yCoordinate As Integer = Me.GetTopmostColumnHeaderYCoordinate(e.X, e.Y)
            Dim columnWidth As Integer = Me.GetCellBounds(0, hti.Column).Width
            'Dim columnWidth As Integer = Me.TableStyles(0).GridColumnStyles(hti.Column).Width
            Dim columnHeight As Integer = Me.GetColumnHeight(yCoordinate)

            Dim columnSize As Size = Size.Empty

            '  check to see if the column is partially hidden (to the right then to the left)
            If ((xCoordinate + columnWidth) > (Me.ClientSize.Width - Me.VertScrollBar.Width)) Then

                Dim num As Integer = columnWidth - (Me.ClientSize.Width - Me.VertScrollBar.Width - xCoordinate) + 2
                Me.MoveHorizScrollBar(num + Me.HorizScrollBar.Value)
                xCoordinate = xCoordinate - num

            ElseIf (Me.TableStyles(0).RowHeadersVisible And xCoordinate < _
                            Me.TableStyles(0).RowHeaderWidth) Then
                Me.MoveHorizScrollBar(-(Me.TableStyles(0).RowHeaderWidth - xCoordinate))
                xCoordinate = columnWidth

            ElseIf (xCoordinate < 0) Then
                Dim numberOfHiddenPixels As Integer = 0
                Dim i As Integer

                For i = 0 To hti.Column - 1
                    numberOfHiddenPixels = numberOfHiddenPixels + columnWidth
                Next

                Me.MoveHorizScrollBar(numberOfHiddenPixels)
                xCoordinate = 0
            End If


            Dim startingLocation As Point = New Point(xCoordinate, yCoordinate)
            Dim columnRegion As Rectangle = New Rectangle(xCoordinate, yCoordinate, columnWidth, columnHeight)
            Dim cursorLocation As Point = New Point(e.X - xCoordinate, e.Y - yCoordinate)

            If ShowColumnWhileDragging Or ShowColumnHeaderWhileDragging Then
                If ShowColumnWhileDragging Then
                    columnSize = New Size(columnWidth, columnHeight)
                Else
                    columnSize = New Size(columnWidth, Me.GetColumnHeaderHeight(e.X, yCoordinate))
                End If

                Dim si As New ScreenImage
                Dim columnImage As Bitmap = CType(si.GetScreenshot(Me.Handle, startingLocation, columnSize), Bitmap)
                m_draggedColumn = New DraggedDataGridColumn(hti.Column, columnRegion, cursorLocation, columnImage)

            Else
                m_draggedColumn = New DraggedDataGridColumn(hti.Column, columnRegion, cursorLocation)
            End If

            m_draggedColumn.CurrentRegion = columnRegion


        End Sub

#End Region

#Region " ::::::::::: Helper Methods ::::::::::::: "

        ' When a dragged column is dropped on top of its original location, 
        ' whether it’s because the user has decided that they no longer want 
        ' to drag it, or they’ve just happened to release the column in this 
        ' location, we need to invalidate the area where the current drawings 
        ' reside.

        Private Sub InvalidateColumnArea()

            If Not m_draggedColumn Is Nothing Then
                Dim startX As Integer
                If (m_draggedColumn.InitialRegion.X < m_draggedColumn.CurrentRegion.X) Then
                    startX = m_draggedColumn.InitialRegion.X
                Else
                    startX = (m_draggedColumn.CurrentRegion.X - 5)
                End If

                Dim width As Integer = m_draggedColumn.InitialRegion.Width + m_draggedColumn.CurrentRegion.Width + 10
                Dim rectangleToInvalidate As Rectangle = New Rectangle(startX, m_draggedColumn.InitialRegion.Y, width, m_draggedColumn.InitialRegion.Height)
                Me.Invalidate(rectangleToInvalidate)
                Me.Update()
            End If


        End Sub


        ' Resets all of the member fields to their default values.
        Private Sub ResetMembersToDefault()

            If Not m_draggedColumn Is Nothing Then
                m_draggedColumn.Dispose()
            End If

            m_draggedColumn = Nothing
            m_mouseOverColumnRect = Rectangle.Empty
            m_mouseOverColumnIndex = -1

        End Sub

#End Region

        ' Returns the height of the column. The height is defined as the area 
        ' between the bottom portion of the caption area and either the 
        ' bottom of the client rectangle, or the top of the horizontal scroll 
        ' bar if it’s visible.
        Private Function GetColumnHeight(ByVal topmostYCoordinate As Integer) As Integer
            Dim height As Integer = Me.ClientSize.Height

            If Me.HorizScrollBar.Visible Then
                height = height - Me.HorizScrollBar.Height
            End If

            Return height - topmostYCoordinate
        End Function

        ' Returns the height of the column header. In order to make this 
        ' calculation, you  need to pass in the topmost y-coordinate of the 
        ' header. This method will then invoke the 
        ' GetBottommostColumnHeaderYCoordinate, which is a recursive method 
        ' that is invoked repeatedly until the DataGrid hit test determines 
        ' that the current coordinates no longer lie within the boundaries 
        ' of a ColumnHeader.
        Private Function GetColumnHeaderHeight(ByVal x As Integer, ByVal y As Integer) As Integer
            Return GetBottommostColumnHeaderYCoordinate(x, y) - y

        End Function

        ' Calculates the leftmost x coordinate for the column corresponding 
        ' to the parameterized column index. By accessing the GridColumnStyle 
        ' style – which is discussed in the article -- we’re able to get the 
        ' current column widths (this changes when you resize columns) for 
        ' the columns that precede the current column. 
        Private Function GetBottommostColumnHeaderYCoordinate(ByVal x As Integer, ByVal currentY As Integer) As Integer
            Dim hti As DataGrid.HitTestInfo = Me.HitTest(x, currentY)
            Dim yCoordinate As Integer = currentY

            If hti.Type = DataGrid.HitTestType.ColumnHeader Then
                yCoordinate = Me.GetBottommostColumnHeaderYCoordinate(x, currentY + 1)
            End If
            Return yCoordinate

        End Function

        ' Calculates the leftmost x coordinate for the column corresponding 
        ' to the parameterized column index. By accessing the 
        ' GridColumnStyle style, which is discussed in detail in the article,
        ' we’re able to get the current column widths (this changes when you 
        ' resize columns) for the columns that precede the current column. 		
        Private Function GetLeftmostColumnHeaderXCoordinate(ByVal columnIndex As Integer) As Integer
            Dim xCoordinate As Integer
            If Me.RowHeadersVisible Then
                xCoordinate = Me.RowHeaderWidth
            Else
                xCoordinate = 0
            End If

            Return Me.GetCellBounds(0, columnIndex).X

            'Dim i As Integer
            'For i = 0 To columnIndex - 1

            '    Dim dgcs As DataGridColumnStyle = Me.TableStyles(Me.DataMember.ToString).GridColumnStyles(i)
            '    xCoordinate = xCoordinate + dgcs.Width
            'Next

            Return (xCoordinate - Me.HorizScrollBar.Value + 2)

        End Function

        ' This is another recursive method that returns the Y-coordinate of 
        ' the topmost portion of the column header. First, a check is 
        ' performed to see if the DataGrid caption is visible. If not, the 
        ' Y-coordinate is set to zero and the method returns. Otherwise, a 
        ' recursion is performed until the DataGrid hit test determines that 
        ' the current Y-coordinate value does not fall within the boundaries 
        ' of a ColumnHeader. 
        Private Function GetTopmostColumnHeaderYCoordinate(ByVal currentX As Integer, ByVal currentY As Integer) As Integer
            Dim hti As DataGrid.HitTestInfo = Me.HitTest(currentX, currentY)
            Dim yCoordinate As Integer = currentY

            If Me.ColumnHeadersVisible = False Then
                yCoordinate = 0
            ElseIf hti.Type = DataGrid.HitTestType.ColumnHeader Then
                yCoordinate = Me.GetTopmostColumnHeaderYCoordinate(currentX, currentY - 1)
            Else
                yCoordinate = yCoordinate + 1
            End If

            Return yCoordinate

        End Function

        ' Positions the horizontal scroll bar and invalidates the grid.
        Public Sub MoveHorizScrollBar(ByVal amount As Integer)
            Me.GridHScrolled(Me, New ScrollEventArgs(ScrollEventType.ThumbPosition, amount))
            Me.Update()
        End Sub

    End Class

End Namespace
