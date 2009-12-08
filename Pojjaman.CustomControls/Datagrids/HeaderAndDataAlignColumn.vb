Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Namespace Longkong.Pojjaman.Gui.Components
    Public Class HeaderAndDataAlignColumn
        Inherits DataGridTextBoxColumn

#Region "Members"
        Private mTxtAlign As HorizontalAlignment = HorizontalAlignment.Left
        Private mDrawTxt As New StringFormat
        Protected Shared ColorList As ArrayList
        Protected Shared ForeColorList As ArrayList
        Private currentRow As Integer = -1
        Private currentColumn As Integer = -1
#End Region

#Region "Events"

#End Region

#Region "Constructors"
        Public Sub New()
            SetColorList()
            AddHandler Me.TextBox.TextChanged, AddressOf OnCellTextChanged
        End Sub
#End Region

#Region "Overrides"
        Protected Overrides Sub ConcedeFocus()
            MyBase.ConcedeFocus()
        End Sub
        Protected Overloads Overrides Sub Edit(ByVal source As _
        System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds _
        As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText _
        As String, ByVal cellIsVisible As Boolean)
            If TypeOf CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum) Is ExpandableDataRow Then
                Dim row As ExpandableDataRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), ExpandableDataRow)
                If row.State = PlusMinusState.UnderParent Then
                    MyBase.Edit(source, rowNum, bounds, [readOnly], instantText, cellIsVisible)
                Else
                    If TextBox.TextLength = 0 Then
                        bounds = Rectangle.Empty
                    End If
                    MyBase.Edit(source, rowNum, bounds, True, instantText, cellIsVisible)
                End If
            Else
                MyBase.Edit(source, rowNum, bounds, [readOnly], instantText, cellIsVisible)
            End If
            MyBase.TextBox.TextAlign = mTxtAlign
        End Sub
        Protected Function GetText(ByVal value As Object) As String
            If TypeOf value Is DBNull Then
                Return Me.NullText
            End If
            If (((Not Me.Format Is Nothing) AndAlso (Me.Format.Length <> 0)) AndAlso TypeOf value Is IFormattable) Then
                Try
                    Return CType(value, IFormattable).ToString(Me.Format, Me.FormatInfo)
                Catch ex As Exception
                    If (value Is Nothing) Then
                        Return ""
                    End If
                    Return value.ToString
                End Try
            End If
            'If ((Not Me.typeConverter Is Nothing) AndAlso Me.typeConverter.CanConvertTo(GetType(String))) Then
            '    Return CType(Me.typeConverter.ConvertTo(value, GetType(String)), String)
            'End If
            If (value Is Nothing) Then
                Return ""
            End If
            Return value.ToString
        End Function
        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, _
        ByVal bounds As System.Drawing.Rectangle, ByVal source As _
        System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal _
        backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, _
        ByVal alignToRight As Boolean)
            Dim myFont As Font
            If TypeOf Me.DataGridTableStyle.DataGrid.DataSource Is ExpandableRowDataTable Then
                PrePareRow(g, rowNum, source, backBrush, foreBrush, myFont)
            Else
                myFont = MyBase.TextBox.Font
            End If
            g.FillRectangle(backBrush, bounds)
            'draw the value
            Dim s As String = Me.GetText(Me.GetColumnValueAtRow([source], rowNum))
            Dim r As Rectangle = bounds
            r.Inflate(0, -1)
            g.DrawString(s, myFont, foreBrush, RectangleF.op_Implicit(r), mDrawTxt)
        End Sub
        Protected Sub PrePareRow(ByVal g As Graphics, ByVal rowNum As Integer, ByVal source As CurrencyManager, ByRef backBrush As Brush, ByRef foreBrush As Brush, ByRef myFont As Font)
            Dim row As ExpandableDataRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), ExpandableDataRow)
            Dim state As PlusMinusState = row.State
            Dim level As Integer = row.Level
            If source.Position = rowNum Then 'selected
                backBrush = SystemBrushes.Highlight
                foreBrush = SystemBrushes.HighlightText
            ElseIf state = PlusMinusState.None Or state = PlusMinusState.UnderParent Then
                backBrush = New SolidBrush(SystemColors.Window)
                foreBrush = New SolidBrush(SystemColors.ControlText)
            Else
                backBrush = New SolidBrush(CType(ColorList((level Mod ColorList.Count)), Color))
                foreBrush = New SolidBrush(CType(ForeColorList((level Mod ColorList.Count)), Color))
            End If

            If row.State = PlusMinusState.Expanded Or row.State = PlusMinusState.Collapsed Then
                myFont = New Font("Tahoma", 8, FontStyle.Bold)
            ElseIf Not row.Font Is Nothing Then
                myFont = row.Font
            Else
                myFont = MyBase.TextBox.Font
            End If
        End Sub
        Protected Overrides Sub SetColumnValueAtRow(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal value As Object)
            MyBase.SetColumnValueAtRow(source, rowNum, value)
            If TypeOf Me.DataGridTableStyle.DataGrid.DataSource Is ExpandableRowDataTable Then
                Dim col As Integer = Me.DataGridTableStyle.GridColumnStyles.IndexOf(Me)
                CType(Me.DataGridTableStyle.DataGrid, PJMDataGrid).ChangeCellValue(New DatagridCellValueChangedEventArgs(rowNum, col, value))
                Dim dt As ExpandableRowDataTable = CType(Me.DataGridTableStyle.DataGrid.DataSource, ExpandableRowDataTable)
                Dim row As ExpandableDataRow = CType(dt.Rows(rowNum), ExpandableDataRow)
                Dim dts As DataGridTableStyle = Me.DataGridTableStyle
                If Not (row.Parent Is Nothing) AndAlso Not dt.AggregateFieldInfo Is Nothing AndAlso dt.AggregateFieldInfo.Count > 0 Then
                    dt.UpdateAggregate(row.Parent, Me.MappingName)
                End If
                If Not dt.GroupbyFieldList Is Nothing AndAlso dt.GroupbyFieldList.IndexOf(Me.MappingName) >= 0 Then
                    dt.UpdateGroupChild(row)
                End If
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property DataAlignment() As HorizontalAlignment
            Get
                Return mTxtAlign
            End Get

            Set(ByVal Value As HorizontalAlignment)
                mTxtAlign = Value
                If mTxtAlign = HorizontalAlignment.Center Then
                    mDrawTxt.Alignment = StringAlignment.Center
                ElseIf mTxtAlign = HorizontalAlignment.Right Then
                    mDrawTxt.Alignment = StringAlignment.Far
                Else
                    mDrawTxt.Alignment = StringAlignment.Near
                End If
            End Set
        End Property
#End Region

#Region "Methods"
        Public Shared Sub SetColorList()
            ColorList = New ArrayList
            ForeColorList = New ArrayList
            Dim myPropertyService As Longkong.Core.Properties.PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim colorListTokens As String = myPropertyService.GetProperty("Pojjaman.ColorList", "0,0,0")
            If Not colorListTokens = "" Then
                Dim colorStringList As String() = colorListTokens.Split(New Char() {";"c})
                For Each colorString As String In colorStringList
                    Dim colorRgb As String() = colorString.Split(New Char() {","c})
                    ColorList.Add(Color.FromArgb(CInt(colorRgb(0)), CInt(colorRgb(1)), CInt(colorRgb(2))))
                    If CInt(colorRgb(0)) + CInt(colorRgb(1)) + CInt(colorRgb(2)) > 128 * 3 Then
                        ForeColorList.Add(Color.Black)
                    Else
                        ForeColorList.Add(Color.White)
                    End If
                Next
            End If
        End Sub
        Public Sub OnCellTextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim dg As PJMDataGrid = CType(Me.DataGridTableStyle.DataGrid, PJMDataGrid)
            If dg.CurrentCell.ColumnNumber <> Me.currentColumn Or dg.CurrentCell.RowNumber <> Me.currentRow Then
                Me.currentColumn = dg.CurrentCell.ColumnNumber
                Me.currentRow = dg.CurrentCell.RowNumber
                Return
            End If
            Dim earg As New DatagridCellTextChangedEventArgs(dg.CurrentCell.RowNumber, dg.CurrentCell.ColumnNumber, Me.TextBox.Text)
            dg.OnCellTextChanged(earg)
        End Sub
#End Region

    End Class
End Namespace