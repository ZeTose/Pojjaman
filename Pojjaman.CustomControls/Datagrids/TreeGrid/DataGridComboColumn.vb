Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class DataGridComboColumn
        Inherits DataGridColumnStyle

#Region "Members"
        Private _comboBox As New KeepKeyCombo
        Private _dataTable As DataTable
        Private _displayMember As String
        Private _inEdit As Boolean
        Private _oldValue As String
        Private _valueMember As String
        Private _xMargin As Integer
        Private _yMargin As Integer

        Protected ColorList As ColorCollection
        Protected ForeColorList As ColorCollection
#End Region

#Region "Constructors"
        Public Sub New()
            _comboBox.Visible = False
        End Sub
        Public Sub New(ByVal colName As String, ByVal dataSource As DataTable, ByVal displayMember As String, ByVal valueMember As String)
            Me._xMargin = 2
            Me._yMargin = 1
            Me._oldValue = ""
            Me._inEdit = False
            Me._comboBox.Visible = False
            Me._comboBox.DataSource = dataSource
            Me._dataTable = dataSource
            Me._comboBox.DisplayMember = displayMember
            Me._displayMember = displayMember
            Me._valueMember = valueMember
            Me._comboBox.ValueMember = valueMember
            Me._comboBox.DropDownStyle = ComboBoxStyle.DropDownList
            MyBase.MappingName = colName
            Me.HeaderText = colName
        End Sub
#End Region

#Region "Overrides"
        Protected Overrides Sub Abort(ByVal rowNum As Integer)
            Me._inEdit = False
            RemoveHandler _comboBox.SelectedValueChanged, _
            AddressOf ComboValueChanged
            Invalidate()
        End Sub
        Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean

            _comboBox.Bounds = Rectangle.Empty

            RemoveHandler _comboBox.SelectedValueChanged, _
                AddressOf ComboValueChanged

            If Not _inEdit Then
                Return True
            End If
            _inEdit = False

            Try
                Dim obj As Object = Me._comboBox.SelectedValue
                If obj Is Nothing OrElse Me.NullText.Equals(obj) Then
                    obj = DBNull.Value
                End If
                Me.SetColumnValueAtRow(dataSource, rowNum, obj)
            Catch ex As Exception
                Return False
            End Try
            Invalidate()
            Return True
        End Function
        Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
            Me._comboBox.Text = ""
            Dim rectangle1 As Rectangle = bounds
            Me._oldValue = Me._comboBox.Text
            If cellIsVisible Then
                bounds.Offset(Me._xMargin, Me._yMargin)
                bounds.Width = (bounds.Width - (Me._xMargin * 2))
                bounds.Height = (bounds.Height - Me._yMargin)
                Me._comboBox.Bounds = bounds
                Dim myReadOnly As Boolean = False
                Me._comboBox.Visible = Not Me.ReadOnly
                Me._comboBox.SelectedValue = Me.GetText(Me.GetColumnValueAtRow(source, rowNum))
                If (Not instantText Is Nothing) Then
                    Me._comboBox.SelectedValue = instantText
                    Me._comboBox.Select(Me._comboBox.Text.Length, 0)
                Else
                    Me._comboBox.SelectAll()
                End If
                AddHandler _comboBox.SelectedValueChanged, _
                AddressOf ComboValueChanged
            Else
                Me._comboBox.SelectedValue = Me.GetText(Me.GetColumnValueAtRow(source, rowNum))
                Me._comboBox.Visible = False
            End If

            If _comboBox.Visible Then
                DataGridTableStyle.DataGrid.Invalidate(bounds)
            End If

            _comboBox.Focus()
        End Sub
        Protected Overrides Function GetMinimumHeight() As Integer
            Return (Me._comboBox.PreferredHeight + Me._yMargin)
        End Function
        Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer
            Return (MyBase.FontHeight + Me._yMargin)
        End Function
        Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size
            Dim size1 As Size = Size.Ceiling(g.MeasureString(Me.GetText(value), Me.DataGridTableStyle.DataGrid.Font))
            size1.Width = (size1.Width + (Me._xMargin * 2))
            size1.Height = (size1.Height + Me._yMargin)
            Return size1
        End Function
        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            Dim myFont As Font = Me.DataGridTableStyle.DataGrid.Font
            If TypeOf Me.DataGridTableStyle.DataGrid.DataSource Is TreeTable Then
                If rowNum < CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable).Rows.Count Then
                    PrePareRow(g, rowNum, source, backBrush, foreBrush, myFont)
                End If
            End If
            g.FillRectangle(backBrush, bounds)
            Dim textToShow As String = Me.GetText(Me.GetColumnValueAtRow(source, rowNum))
            For Each row As DataRow In Me._dataTable.Rows
                If (row(Me._valueMember).ToString = textToShow) Then
                    textToShow = row(Me._displayMember).ToString
                    Exit For
                End If
            Next
            Me.PaintText(g, bounds, textToShow, alignToRight, backBrush, foreBrush)
        End Sub
        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer)
            Me.Paint(g, bounds, source, rowNum, False)
        End Sub
        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)
            Paint(g, bounds, [source], rowNum, Brushes.Red, _
                Brushes.Blue, alignToRight)
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
            Dim graphics1 As Graphics = value.CreateGraphics
            Dim w As Single = 10.0!
            Dim ef1 As New SizeF(0.0!, 0.0!)

            For Each row As DataRow In _dataTable.Rows
                ef1 = graphics1.MeasureString(row(_comboBox.DisplayMember).ToString, value.Font)
                If (ef1.Width > w) Then
                    w = ef1.Width
                End If
            Next
            Me._comboBox.DropDownWidth = CType(Math.Ceiling(CType(w, Double)), Integer)
            Me.Width = (Me._comboBox.DropDownWidth + 25)

            If Not (_comboBox.Parent Is Nothing) Then
                _comboBox.Parent.Controls.Remove(_comboBox)
            End If
            If Not (value Is Nothing) Then
                value.Controls.Add(_comboBox)
            End If
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
			ElseIf row.State = RowExpandState.None And row.FixLevel >= 0 Then
				backBrush = New SolidBrush(CType(ColorList((level Mod ColorList.Count)), Color))
				foreBrush = New SolidBrush(CType(ForeColorList((level Mod ColorList.Count)), Color))
			ElseIf row.State = RowExpandState.None Then
				'backBrush = New SolidBrush(dg.BackColor)
				'foreBrush = New SolidBrush(dg.ForeColor)
			Else
				backBrush = New SolidBrush(CType(ColorList((level Mod ColorList.Count)), Color))
				foreBrush = New SolidBrush(CType(ForeColorList((level Mod ColorList.Count)), Color))
			End If

			If row.State <> RowExpandState.None Then
				myFont = New Font("Tahoma", 8, FontStyle.Bold)
			Else
				myFont = dg.Font
			End If

			If Not (row.CustomBackColor.IsEmpty) Then
				backBrush = New SolidBrush(row.CustomBackColor)
			End If
			If Not (row.CustomForeColor.IsEmpty) Then
				foreBrush = New SolidBrush(row.CustomForeColor)
			End If
			If Not (row.CustomFontStyle = Nothing) Then
				myFont = New Font(myFont, row.CustomFontStyle)
			End If

        End Sub
#End Region

#Region "Properties"
        Public Property DataTable() As DataTable            Get                Return _dataTable            End Get            Set(ByVal Value As DataTable)                _dataTable = Value            End Set        End Property        Public Property DisplayMember() As String            Get                Return _displayMember            End Get            Set(ByVal Value As String)                _displayMember = Value            End Set        End Property        Public Property ValueMember() As String            Get                Return _valueMember            End Get            Set(ByVal Value As String)                _valueMember = Value            End Set        End Property
#End Region

#Region "Handler"
        Private Sub ComboValueChanged( _
        ByVal sender As Object, ByVal e As EventArgs)
            ' Remove the handler to prevent it from being called twice in a row.
            RemoveHandler _comboBox.SelectedValueChanged, _
                AddressOf ComboValueChanged
            Me._inEdit = True
            MyBase.ColumnStartedEditing(_comboBox)
        End Sub
#End Region

#Region "Methods"
        Private Function GetText(ByVal val As Object) As String
            If (val Is DBNull.Value) Then
                Return Me.NullText
            End If
            If (Not val Is Nothing) Then
                Return val.ToString
            End If
            Return String.Empty
        End Function
        Private Sub PaintText(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal [text] As String, ByVal alignToRight As Boolean, ByVal brush1 As Brush, ByVal brush2 As Brush)
            Dim rectangle1 As Rectangle = bounds
            Dim ef1 As RectangleF = RectangleF.op_Implicit(rectangle1)
            Dim format1 As New StringFormat
            If alignToRight Then
                format1.FormatFlags = StringFormatFlags.DirectionRightToLeft
            End If
            Select Case Me.Alignment
                Case HorizontalAlignment.Left
                    format1.Alignment = StringAlignment.Near
                Case HorizontalAlignment.Right
                    format1.Alignment = StringAlignment.Far
                Case HorizontalAlignment.Center
                    format1.Alignment = StringAlignment.Center
            End Select
            format1.FormatFlags = StringFormatFlags.NoWrap
            g.FillRectangle(brush1, rectangle1)
            rectangle1.Offset(0, Me._yMargin)
            rectangle1.Height = (rectangle1.Height - Me._yMargin)
            g.DrawString(text, Me.DataGridTableStyle.DataGrid.Font, brush2, ef1, format1)
            format1.Dispose()
        End Sub
        Private Sub PaintText(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal [text] As String, ByVal alignToRight As Boolean)
            Dim brush1 As New SolidBrush(Me.DataGridTableStyle.BackColor)
            Dim brush2 As New SolidBrush(Me.DataGridTableStyle.ForeColor)
            Dim rectangle1 As Rectangle = bounds
            Dim ef1 As RectangleF = RectangleF.op_Implicit(rectangle1)
            Dim format1 As New StringFormat
            If alignToRight Then
                format1.FormatFlags = StringFormatFlags.DirectionRightToLeft
            End If
            Select Case Me.Alignment
                Case HorizontalAlignment.Left
                    format1.Alignment = StringAlignment.Near
                Case HorizontalAlignment.Right
                    format1.Alignment = StringAlignment.Far
                Case HorizontalAlignment.Center
                    format1.Alignment = StringAlignment.Center
            End Select
            format1.FormatFlags = StringFormatFlags.NoWrap
            g.FillRectangle(brush1, rectangle1)
            rectangle1.Offset(0, Me._yMargin)
            rectangle1.Height = (rectangle1.Height - Me._yMargin)
            g.DrawString(text, Me.DataGridTableStyle.DataGrid.Font, brush2, ef1, format1)
            format1.Dispose()
        End Sub
#End Region

    End Class
    Public Class KeepKeyCombo
        Inherits ComboBox

        Protected Overrides Function ProcessKeyMessage(ByRef m As Message) As Boolean
            ' Keep all the keys for the DateTimePicker.
            Return ProcessKeyEventArgs(m)
        End Function

        Protected Overrides Sub RefreshItem(ByVal index As Integer)
            MyBase.RefreshItem(index)
        End Sub

        Protected Overrides Sub SetItemsCore(ByVal items As System.Collections.IList)
            MyBase.SetItemsCore(items)
        End Sub
    End Class
End Namespace

