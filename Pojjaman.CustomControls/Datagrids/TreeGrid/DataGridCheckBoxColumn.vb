Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class DataGridCheckBoxColumn
        Inherits PJMColumnStyle

#Region "Members"
        Private m_depressedBounds As Rectangle
        Private m_focusRectangle As Rectangle

        Delegate Sub ButtonColumnClickHandler(ByVal e As ButtonColumnEventArgs)
        Public Event Click As ButtonColumnClickHandler

        Protected ColorList As ColorCollection
        Protected ForeColorList As ColorCollection

        Private m_invisible As Boolean = False
        Private m_invisibleWhenUnspcified As Boolean = False
#End Region

#Region "Properties"
        Public Property InvisibleWhenUnspcified() As Boolean            Get                Return m_invisibleWhenUnspcified            End Get            Set(ByVal Value As Boolean)                m_invisibleWhenUnspcified = Value            End Set        End Property
#End Region

#Region "Contructors"
        Private m_col As Integer = -2
        Public Sub New()
            Me.ControlSize = New Size(14, 14)
            Me.Padding.SetPadding(0, 5, 0, 5)
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width
        End Sub
        Public Sub New(ByVal col As Integer)
            Me.New()
            m_col = col
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub RemoveHandlers()
            If Me.DataGridTableStyle Is Nothing Then
                Return
            End If
            If Me.DataGridTableStyle.DataGrid Is Nothing Then
                Return
            End If
            RemoveHandler Me.DataGridTableStyle.DataGrid.MouseDown, AddressOf DataGrid_MouseDown
        End Sub
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

            RemoveHandler grid.MouseDown, AddressOf DataGrid_MouseDown
            AddHandler grid.MouseDown, AddressOf DataGrid_MouseDown
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

            Dim focusBounds As Rectangle = controlBounds
            focusBounds.Inflate(-4, -4)

            Dim fontBoundsF As New System.Drawing.RectangleF( _
                CType(bounds.X, Single), _
                CType(bounds.Y, Single), _
                CType(bounds.Width, Single), _
                CType(bounds.Height, Single))

            fontBoundsF.Inflate(-3, -3)

            If Not m_depressedBounds.Equals(Rectangle.Empty) And m_depressedBounds.Equals(bounds) Then
            Else
                drawFocusRectangle = False
            End If

            Dim rowValue As Boolean = False
            Dim obj As Object
            Try
                obj = Me.GetColumnValueAtRow([source], rowNum)
            Catch ex As Exception
                obj = DBNull.Value
            End Try
            If Not IsDBNull(obj) Then
                If CBool(obj) Then
                    ControlPaint.DrawCheckBox(g, controlBounds, ButtonState.Checked)
                Else
                    ControlPaint.DrawCheckBox(g, controlBounds, ButtonState.Normal)
                End If
            ElseIf Not m_invisibleWhenUnspcified Then
                ControlPaint.DrawCheckBox(g, controlBounds, ButtonState.Inactive Or ButtonState.Checked)
            End If
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
            If e.Button = MouseButtons.Left And hti.Type = DataGrid.HitTestType.Cell AndAlso TypeOf Me.DataGridTableStyle.GridColumnStyles(hti.Column) Is DataGridCheckBoxColumn Then
                If m_col = -2 Or m_col = hti.Column Then
                    Dim cursorRect As New Rectangle(e.X, e.Y, 1, 1)
                    Dim cellBounds As Rectangle = Me.DataGridTableStyle.DataGrid.GetCellBounds(hti.Row, hti.Column)
                    Dim buttonBounds As Rectangle = Me.GetControlBounds(cellBounds)
                    If cursorRect.IntersectsWith(buttonBounds) AndAlso hti.Row < CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable).Rows.Count Then
                        If Me.ReadOnly Then
                            Return
                        End If
                        m_depressedBounds = cellBounds
                        Dim row As DataRow = CType(CType(DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(hti.Row), DataRow)
                        Dim colName As String = Me.DataGridTableStyle.GridColumnStyles(hti.Column).MappingName
                        If IsDBNull(row(colName)) Then
                            If Not m_invisibleWhenUnspcified Then
                                row(colName) = True
                            End If
                        ElseIf CBool(row(colName)) = False Then
                            row(colName) = True
                        Else
                            row(colName) = False
                        End If
                        Me.DataGridTableStyle.DataGrid.Invalidate(cellBounds)
                        RaiseEvent Click(New ButtonColumnEventArgs(hti.Row, hti.Column, ""))
                    End If
                End If
            End If
        End Sub
#End Region

    End Class
End Namespace

