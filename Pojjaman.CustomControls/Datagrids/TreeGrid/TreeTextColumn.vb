Namespace Longkong.Pojjaman.Gui.Components
  Public Class TreeTextColumn
    Inherits DataGridTextBoxColumn

#Region "Members"
    Private m_textAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private m_drawTextFormat As New StringFormat
    Protected ColorList As ColorCollection
    Protected ForeColorList As ColorCollection
    Private currentRow As Integer = -1
    Private currentColumn As Integer = -1

    Private m_fillRow As Boolean = True
    Private m_hilightColor As Color
    Private m_redTextColor As Color
#End Region

    Public Property HilightColor() As Color      Get        Return m_hilightColor      End Get      Set(ByVal Value As Color)        m_hilightColor = Value      End Set    End Property    Public Property RedTextColor() As Color      Get        Return m_redTextColor      End Get      Set(ByVal Value As Color)        m_redTextColor = Value      End Set    End Property
#Region "Events"
    Public Delegate Sub EnableCellEventHandler(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
    Public Event CheckCellHilighted As EnableCellEventHandler
#End Region

#Region "Constructors"
    Public Sub New()
      If Me.DataAlignment = HorizontalAlignment.Center Then
        m_drawTextFormat.Alignment = StringAlignment.Center
      ElseIf Me.DataAlignment = HorizontalAlignment.Right Then
        m_drawTextFormat.Alignment = StringAlignment.Far
      Else
        m_drawTextFormat.Alignment = StringAlignment.Near
      End If
      AddHandler Me.TextBox.TextChanged, AddressOf OnCellTextChanged
    End Sub
    Public Sub New(ByVal col As Integer, ByVal fill As Boolean)
      Me.New(col, fill, Color.Yellow)
    End Sub
    Public Sub New(ByVal col As Integer, ByVal fill As Boolean, ByVal hilightColor As Color)
      Me.New(col, fill, hilightColor, Color.Red)
    End Sub
    Public Sub New(ByVal col As Integer, ByVal fill As Boolean, ByVal hilightColor As Color, ByVal redTextColor As Color)
      Me.New()
      currentColumn = col
      m_fillRow = fill
      m_hilightColor = hilightColor
      m_redTextColor = redTextColor
    End Sub
#End Region

#Region "Overrides"
    Protected m_grid As TreeGrid
    Protected Overrides Sub SetDataGridInColumn(ByVal value As System.Windows.Forms.DataGrid)
      If value Is Nothing OrElse Not TypeOf value Is TreeGrid Then
        Return
      End If
      m_grid = CType(value, TreeGrid)
      If m_grid.ColorList.Count > 0 Then
        Me.ColorList = m_grid.ColorList
      Else
        Me.ColorList = m_grid.GetDefaultColorList
      End If
      ForeColorList = New ColorCollection      For Each col As Color In ColorList        If CInt(col.R) + CInt(col.G) + CInt(col.B) > 128 * 3 Then
          ForeColorList.Add(Color.Black)
        Else
          ForeColorList.Add(Color.White)
        End If
      Next
      MyBase.SetDataGridInColumn(value)
    End Sub
    Protected Overrides Sub ConcedeFocus()
      MyBase.ConcedeFocus()
    End Sub
    Protected Overloads Overrides Sub Edit(ByVal source As  _
    System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds _
    As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText _
    As String, ByVal cellIsVisible As Boolean)
      If TypeOf CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable) Is TreeTable Then
        Dim table As TreeTable = CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable)
        If rowNum < table.Rows.Count Then
          Dim row As TreeRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), TreeRow)
          If Not row.Readonly Then
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
      Else
        MyBase.Edit(source, rowNum, bounds, [readOnly], instantText, cellIsVisible)
      End If
      MyBase.TextBox.TextAlign = m_textAlign
    End Sub
    Protected Function GetText(ByVal value As Object) As String
      If value Is DBNull.Value Then
        If Me.NullText Is Nothing Then
          Return ""
        End If
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
      If (value Is Nothing) Then
        Return ""
      End If
      Return value.ToString
    End Function
    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, _
    ByVal bounds As System.Drawing.Rectangle, ByVal source As  _
    System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal _
    backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, _
    ByVal alignToRight As Boolean)
      Dim myFont As Font = MyBase.TextBox.Font
      If TypeOf Me.DataGridTableStyle.DataGrid.DataSource Is TreeTable Then
        If m_fillRow AndAlso rowNum < CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable).Rows.Count Then
          PrePareRow(g, rowNum, source, backBrush, foreBrush, myFont)
        End If
      End If
      g.FillRectangle(backBrush, bounds)
      'draw the value
      Dim obj As Object
      Try
        obj = Me.GetColumnValueAtRow([source], rowNum)
      Catch ex As Exception
        obj = DBNull.Value
      End Try
      Dim s As String = Me.GetText(obj)
      Dim r As Rectangle = bounds
      r.Inflate(0, -1)
      g.DrawString(s, myFont, foreBrush, RectangleF.op_Implicit(r), m_drawTextFormat)
    End Sub
    Private Function CheckRowSelected(ByVal rowNum As Integer) As Boolean
      If m_grid Is Nothing Then
        Return False
      End If
      If m_grid.IsSelected(rowNum) Then
        Return True
      End If
      Return False
    End Function
    Protected Sub PrePareRow(ByVal g As Graphics, ByVal rowNum As Integer, ByVal source As CurrencyManager, ByRef backBrush As Brush, ByRef foreBrush As Brush, ByRef myFont As Font)
      Dim row As TreeRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), TreeRow)
      Dim table As TreeTable = CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable)
      Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
      Dim state As RowExpandState = row.State
      Dim level As Integer = row.Level
      If source.Position = rowNum OrElse CheckRowSelected(rowNum) Then 'selected
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
        myFont = New Font(MyBase.TextBox.Font, FontStyle.Bold)
      Else
        myFont = MyBase.TextBox.Font
      End If

      Dim hilighted As Boolean
      hilighted = False
      Dim e As DataGridHilightEventArgs
      e = New DataGridHilightEventArgs(rowNum, currentColumn, hilighted)
      RaiseEvent CheckCellHilighted(Me, e)
      If e.HilightValue Then
        backBrush = New SolidBrush(m_hilightColor)
        If CInt(m_hilightColor.R) + CInt(m_hilightColor.G) + CInt(m_hilightColor.B) > 128 * 3 Then
          foreBrush = New SolidBrush(Color.Black)
        Else
          foreBrush = New SolidBrush(Color.White)
        End If
        myFont = New Font(myFont, FontStyle.Bold)
      End If
      If e.RedText Then
        foreBrush = New SolidBrush(m_redTextColor)
        myFont = New Font(myFont, FontStyle.Bold)
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
    Protected Overrides Sub SetColumnValueAtRow(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal value As Object)
      MyBase.SetColumnValueAtRow(source, rowNum, value)
    End Sub
#End Region

#Region "Properties"
    Public Property DataAlignment() As HorizontalAlignment
      Get
        Return m_textAlign
      End Get

      Set(ByVal Value As HorizontalAlignment)
        m_textAlign = Value
        If m_textAlign = HorizontalAlignment.Center Then
          m_drawTextFormat.Alignment = StringAlignment.Center
        ElseIf m_textAlign = HorizontalAlignment.Right Then
          m_drawTextFormat.Alignment = StringAlignment.Far
        Else
          m_drawTextFormat.Alignment = StringAlignment.Near
        End If
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub OnCellTextChanged(ByVal sender As Object, ByVal e As EventArgs)
      'Todo
    End Sub
#End Region

  End Class
  Public Class DataGridHilightEventArgs
    Inherits EventArgs
    Private _column As Integer
    Private _row As Integer
    Private _hilightValue As Boolean
    Private _redText As Boolean
    Public Sub New(ByVal row As Integer, ByVal col As Integer, ByVal val As Boolean)
      MyBase.New()
      _row = row
      _column = col
      _hilightValue = val
      _redText = False
    End Sub
    Public Property Column() As Integer
      Get
        Return _column
      End Get
      Set(ByVal Value As Integer)
        _column = Value
      End Set
    End Property
    Public Property Row() As Integer
      Get
        Return _row
      End Get
      Set(ByVal Value As Integer)
        _row = Value
      End Set
    End Property
    Public Property HilightValue() As Boolean
      Get
        Return _hilightValue
      End Get
      Set(ByVal Value As Boolean)
        _hilightValue = Value
      End Set
    End Property
    Public Property RedText() As Boolean
      Get
        Return _redText
      End Get
      Set(ByVal Value As Boolean)
        _redText = Value
      End Set
    End Property
  End Class
End Namespace