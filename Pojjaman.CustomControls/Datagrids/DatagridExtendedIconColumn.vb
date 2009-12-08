Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class DatagridExtendedIconColumn
        Inherits PJMColumnStyle

#Region "Members"
        Private m_depressedBounds As Rectangle
        Private m_focusRectangle As Rectangle
        Private m_icon As Image

        Delegate Sub ButtonColumnClickHandler(ByVal e As ButtonColumnEventArgs)
        Public Event Click As ButtonColumnClickHandler

        Protected ColorList As ColorCollection
        Protected ForeColorList As ColorCollection
#End Region

#Region "Contructors"
        Public Sub New()
            Me.ControlSize = New Size(16, 16)
            Me.Padding.SetPadding(0, 30, 0, 30)
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width
        End Sub
        Public Sub New(ByVal img As Image)
            Me.New()
            m_icon = img
        End Sub
#End Region

#Region "Methods"
        Protected Overrides Sub SetDataGridInColumn(ByVal value As DataGrid)
            If value Is Nothing OrElse Not TypeOf value Is TreeGrid Then
                Return
            End If
            Dim grid As TreeGrid = CType(value, TreeGrid)
            If grid.ColorList.Count > 0 Then
                Me.ColorList = grid.ColorList
            Else
                Me.ColorList = grid.GetDefaultColorList
            End If
            ForeColorList = New ColorCollection            For Each col As Color In ColorList                If CInt(col.R) + CInt(col.G) + CInt(col.B) > 128 * 3 Then
                    ForeColorList.Add(Color.Black)
                Else
                    ForeColorList.Add(Color.White)
                End If
            Next

            MyBase.SetDataGridInColumn(value)

            ' subscribe to DataGrid events
            AddHandler Me.DataGridTableStyle.DataGrid.MouseDown, AddressOf DataGrid_MouseDown
            AddHandler Me.DataGridTableStyle.DataGrid.MouseUp, AddressOf DataGrid_MouseUp
        End Sub
        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)

            If TypeOf Me.DataGridTableStyle.DataGrid.DataSource Is TreeTable Then
                If rowNum < CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable).Rows.Count Then
                    PrePareRow(g, rowNum, source, backBrush, foreBrush)
                End If
            End If

            g.FillRectangle(backBrush, bounds)

            Dim controlBounds As Rectangle = Me.GetControlBounds(bounds)
            Dim drawFocusRectangle As Boolean = True
            Dim img As Image
            Dim focusBounds As Rectangle = controlBounds
            focusBounds.Inflate(-4, -4)

            Dim fontBoundsF As New System.Drawing.RectangleF( _
                CType(bounds.X, Single), _
                CType(bounds.Y, Single), _
                CType(bounds.Width, Single), _
                CType(bounds.Height, Single))

            fontBoundsF.Inflate(-3, -3)

            Dim bs As ButtonState = ButtonState.Inactive

            If Not m_depressedBounds.Equals(Rectangle.Empty) And m_depressedBounds.Equals(bounds) Then
                bs = ButtonState.Pushed
            Else
                drawFocusRectangle = False
            End If

            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.FitBlackBox
            Dim obj As Object = Me.GetColumnValueAtRow([source], rowNum)
            If Not IsDBNull(obj) Then
                img = CType(obj, Image)
            End If
            If Not m_icon Is Nothing Or Not img Is Nothing Then
                ControlPaint.DrawButton(g, controlBounds, bs)
                Dim imgBound As Rectangle = controlBounds
                imgBound.Inflate(-2, -2)
                If Not img Is Nothing Then
                    g.DrawImage(img, imgBound)
                Else
                    g.DrawImage(m_icon, imgBound)
                End If
            End If

            'g.DrawString(rowValue, Me.DataGridTableStyle.DataGrid.Font, foreBrush, fontBoundsF, sf)

            If drawFocusRectangle Then
                ControlPaint.DrawFocusRectangle(g, m_focusRectangle, Color.Red, Control.DefaultBackColor)
            End If
        End Sub
        Protected Sub PrePareRow(ByVal g As Graphics, ByVal rowNum As Integer, ByVal source As CurrencyManager, ByRef backBrush As Brush, ByRef foreBrush As Brush)
            Dim row As TreeRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), TreeRow)
            Dim table As TreeTable = CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable)
            Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
            Dim state As RowExpandState = row.State
            Dim level As Integer = row.Level
            If source.Position = rowNum Then 'selected
                backBrush = New SolidBrush(dg.SelectionBackColor)
                foreBrush = New SolidBrush(dg.SelectionForeColor)
            ElseIf row.State = RowExpandState.None Then
                backBrush = New SolidBrush(dg.BackColor)
                foreBrush = New SolidBrush(dg.ForeColor)
            Else
                backBrush = New SolidBrush(CType(ColorList((level Mod ColorList.Count)), Color))
                foreBrush = New SolidBrush(CType(ForeColorList((level Mod ColorList.Count)), Color))
            End If
        End Sub
#End Region

#Region "Even Handlers"
        Private Sub DataGrid_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim hti As DataGrid.HitTestInfo = Me.DataGridTableStyle.DataGrid.HitTest(e.X, e.Y)
            ' since the MouseDown event is raised every time a mouse button is
            ' clicked within the grid, ensure that the following conditions are met:
            '		1. the left button was pressed,
            '		2. the cursor is above a cell, and
            '		3. the cell belongs to this column style
            If e.Button = MouseButtons.Left And hti.Type = DataGrid.HitTestType.Cell AndAlso TypeOf Me.DataGridTableStyle.GridColumnStyles(hti.Column) Is DatagridExtendedIconColumn Then
                ' instead of implementing a whole bunch of logic to figure out 
                ' if the cursor position falls within the area where the button 
                ' is painted, a 1 x 1 rectangle is created to represent the 
                ' cursor location. secondly, because the cellBounds
                ' represents the bounds of the entire cell, we need to calculate 
                ' the bounds of the drawn button. finally, with the help of the 
                ' IntersectsWith method, we're able to determine if the two 
                ' rectangles intersect.
                Dim cursorRect As New Rectangle(e.X, e.Y, 1, 1)
                Dim cellBounds As Rectangle = Me.DataGridTableStyle.DataGrid.GetCellBounds(hti.Row, hti.Column)
                Dim buttonBounds As Rectangle = Me.GetControlBounds(cellBounds)
                If cursorRect.IntersectsWith(buttonBounds) Then
                    m_depressedBounds = cellBounds
                    ' since the DataGridColumnStyle's Invalidate method will
                    ' invalidate the entire column region (which is a waste), 
                    ' we instead use the reference to the datagrid made 
                    ' available through the DataGridTableStyle property to
                    ' invalidate a more specific region of the grid.
                    Me.DataGridTableStyle.DataGrid.Invalidate(cellBounds)
                End If
            End If
        End Sub

        Private Sub DataGrid_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim hti As DataGrid.HitTestInfo = Me.DataGridTableStyle.DataGrid.HitTest(e.X, e.Y)
            If Not m_depressedBounds.Equals(Rectangle.Empty) Then
                Dim cellBounds As Rectangle
                If hti.Row >= 0 And hti.Column >= 0 Then
                    cellBounds = Me.DataGridTableStyle.DataGrid.GetCellBounds(hti.Row, hti.Column)
                End If
                If m_depressedBounds.Equals(cellBounds) Then
                    ' cursor has been released within the same cell it was 
                    ' pressed. now, check and see if it was released within 
                    ' the button bounds
                    Dim cursorRect As New Rectangle(e.X, e.Y, 1, 1)
                    Dim buttonBounds As Rectangle = Me.GetControlBounds(cellBounds)

                    Dim ds As Object = Me.DataGridTableStyle.DataGrid.DataSource
                    Dim dataMember As String = Me.DataGridTableStyle.DataGrid.DataMember
                    Dim cm As CurrencyManager = CType(Me.DataGridTableStyle.DataGrid.BindingContext(ds, dataMember), CurrencyManager)
                    Dim obj As Object = Me.GetColumnValueAtRow(cm, hti.Row)
                    Dim img As Image
                    If Not IsDBNull(obj) Then
                        img = CType(obj, Image)
                    End If

                    If cursorRect.IntersectsWith(buttonBounds) And (Not m_icon Is Nothing Or Not img Is Nothing) Then
                        'Dim buttonValue As String = CStr(Me.GetColumnValueAtRow(cm, hti.Row))
                        'Me.SetColumnValueAtRow(cm, hti.Row, buttonValue)
                        RaiseEvent Click(New ButtonColumnEventArgs(hti.Row, hti.Column, "")) 'buttonValue))
                    End If
                End If
                m_depressedBounds = Rectangle.Empty
                Me.DataGridTableStyle.DataGrid.Invalidate(cellBounds)
            End If
        End Sub
#End Region

    End Class
End Namespace

