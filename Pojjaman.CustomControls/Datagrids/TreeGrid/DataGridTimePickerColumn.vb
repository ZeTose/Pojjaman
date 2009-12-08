Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class DataGridTimePickerColumn
        Inherits DataGridColumnStyle

        Private customDateTimePicker1 As New CustomDateTimePicker

        ' The isEditing field tracks whether or not the user is
        ' editing data with the hosted control.
        Private isEditing As Boolean
        Protected ColorList As ColorCollection
        Protected ForeColorList As ColorCollection

        Public Sub New()
            customDateTimePicker1.Visible = False
        End Sub

        Protected Overrides Sub Abort(ByVal rowNum As Integer)
            isEditing = False
            RemoveHandler customDateTimePicker1.ValueChanged, _
                AddressOf TimePickerValueChanged
            Invalidate()
        End Sub

        Protected Overrides Function Commit _
            (ByVal dataSource As CurrencyManager, ByVal rowNum As Integer) _
            As Boolean

            customDateTimePicker1.Bounds = Rectangle.Empty

            RemoveHandler customDateTimePicker1.ValueChanged, _
                AddressOf TimePickerValueChanged

            If Not isEditing Then
                Return True
            End If
            isEditing = False

            Try
                Dim value As DateTime = customDateTimePicker1.Value
                SetColumnValueAtRow(dataSource, rowNum, value)
            Catch
            End Try

            Invalidate()
            Return True
        End Function

        Protected Overloads Overrides Sub Edit( _
            ByVal [source] As CurrencyManager, _
            ByVal rowNum As Integer, _
            ByVal bounds As Rectangle, _
            ByVal [readOnly] As Boolean, _
            ByVal displayText As String, _
            ByVal cellIsVisible As Boolean)

            Dim value As DateTime = _
            CType(GetColumnValueAtRow([source], rowNum), DateTime)
            If cellIsVisible Then
                customDateTimePicker1.Bounds = New Rectangle _
                (bounds.X + 2, bounds.Y + 2, bounds.Width - 4, _
                bounds.Height - 4)

                If value.Equals(Date.MinValue) Then
                    value = Date.Now
                End If
                customDateTimePicker1.Value = value
                customDateTimePicker1.Visible = Not Me.ReadOnly
                AddHandler customDateTimePicker1.ValueChanged, _
                AddressOf TimePickerValueChanged
            Else
                If value.Equals(Date.MinValue) Then
                    customDateTimePicker1.Value = customDateTimePicker1.MinDate
                Else
                    customDateTimePicker1.Value = value
                End If
                customDateTimePicker1.Visible = False
            End If

            If customDateTimePicker1.Visible Then
                DataGridTableStyle.DataGrid.Invalidate(bounds)
            End If

            customDateTimePicker1.Focus()

        End Sub

        Protected Overrides Function GetPreferredSize( _
            ByVal g As Graphics, _
            ByVal value As Object) As Size

            Return New Size(100, customDateTimePicker1.PreferredHeight + 2)

        End Function

        Protected Overrides Function GetMinimumHeight() As Integer
            Return customDateTimePicker1.PreferredHeight + 2
        End Function

        Protected Overrides Function GetPreferredHeight( _
            ByVal g As Graphics, ByVal value As Object) As Integer

            Return customDateTimePicker1.PreferredHeight + 2

        End Function

        Protected Overloads Overrides Sub Paint( _
            ByVal g As Graphics, ByVal bounds As Rectangle, _
            ByVal [source] As CurrencyManager, ByVal rowNum As Integer)

            Paint(g, bounds, [source], rowNum, False)

        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As Graphics, _
            ByVal bounds As Rectangle, ByVal [source] As CurrencyManager, _
            ByVal rowNum As Integer, ByVal alignToRight As Boolean)

            Paint(g, bounds, [source], rowNum, Brushes.Red, _
                Brushes.Blue, alignToRight)

        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As Graphics, _
            ByVal bounds As Rectangle, ByVal [source] As CurrencyManager, _
            ByVal rowNum As Integer, ByVal backBrush As Brush, _
            ByVal foreBrush As Brush, ByVal alignToRight As Boolean)

            Dim myFont As Font = Me.DataGridTableStyle.DataGrid.Font
            If TypeOf Me.DataGridTableStyle.DataGrid.DataSource Is TreeTable Then
                If rowNum < CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable).Rows.Count Then
                    PrePareRow(g, rowNum, source, backBrush, foreBrush, myFont)
                End If
            End If

            Dim [date] As DateTime = _
            CType(GetColumnValueAtRow([source], rowNum), DateTime)
            Dim rect As Rectangle = bounds
            g.FillRectangle(backBrush, rect)
            rect.Offset(0, 2)
            rect.Height -= 2
            Dim stringToDraw As String = ""
            If Not [date].Equals(Date.MinValue) Then
                stringToDraw = [date].ToString("d")
            End If
            g.DrawString(stringToDraw, _
                Me.DataGridTableStyle.DataGrid.Font, foreBrush, _
                RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))

        End Sub
        Protected Sub PrePareRow(ByVal g As Graphics, ByVal rowNum As Integer, ByVal source As CurrencyManager, ByRef backBrush As Brush, ByRef foreBrush As Brush, ByRef myFont As Font)
            Dim row As TreeRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), TreeRow)
            Dim table As TreeTable = CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable)
            Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
            Dim state As RowExpandState = row.State
            Dim level As Integer = row.Level
            If source.Position = rowNum Then 'selected
                backBrush = New SolidBrush(dg.SelectionBackColor)
                foreBrush = New SolidBrush(dg.SelectionForeColor)
            ElseIf row.State = RowExpandState.None Then
                'Todo:
            ElseIf row.State = RowExpandState.None Then
                backBrush = New SolidBrush(dg.BackColor)
                foreBrush = New SolidBrush(dg.ForeColor)
            Else
                backBrush = New SolidBrush(CType(ColorList((level Mod ColorList.Count)), Color))
                foreBrush = New SolidBrush(CType(ForeColorList((level Mod ColorList.Count)), Color))
            End If

            If row.State <> RowExpandState.None Then
                myFont = New Font("Tahoma", 8, FontStyle.Bold)
            Else
                myFont = dg.Font
            End If
        End Sub
        Protected Overrides Sub SetDataGridInColumn(ByVal value As DataGrid)
            If Not value Is Nothing AndAlso TypeOf value Is TreeGrid Then
                Dim grid As TreeGrid = CType(value, TreeGrid)
                If grid.ColorList.Count > 0 Then
                    Me.ColorList = grid.ColorList
                Else
                    Me.ColorList = grid.GetDefaultColorList
                End If
                ForeColorList = New ColorCollection                For Each col As Color In ColorList                    If CInt(col.R) + CInt(col.G) + CInt(col.B) > 128 * 3 Then
                        ForeColorList.Add(Color.Black)
                    Else
                        ForeColorList.Add(Color.White)
                    End If
                Next
            End If
            MyBase.SetDataGridInColumn(value)
            If Not (customDateTimePicker1.Parent Is Nothing) Then
                customDateTimePicker1.Parent.Controls.Remove(customDateTimePicker1)
            End If
            If Not (value Is Nothing) Then
                value.Controls.Add(customDateTimePicker1)
            End If
        End Sub

        Private Sub TimePickerValueChanged( _
            ByVal sender As Object, ByVal e As EventArgs)

            ' Remove the handler to prevent it from being called twice in a row.
            RemoveHandler customDateTimePicker1.ValueChanged, _
                AddressOf TimePickerValueChanged
            Me.isEditing = True
            MyBase.ColumnStartedEditing(customDateTimePicker1)

        End Sub

    End Class

    Public Class CustomDateTimePicker
        Inherits DateTimePicker

        Protected Overrides Function ProcessKeyMessage(ByRef m As Message) As Boolean
            ' Keep all the keys for the DateTimePicker.
            Return ProcessKeyEventArgs(m)
        End Function

    End Class
End Namespace

