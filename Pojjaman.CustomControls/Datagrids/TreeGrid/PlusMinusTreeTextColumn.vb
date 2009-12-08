Imports Longkong.Core.Services
Imports System.Reflection
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PlusMinusTreeTextColumn
        Inherits TreeTextColumn

#Region "Members"
        Protected m_bmpMinus As Bitmap, m_bmpPlus As Bitmap
        Private m_drawTextFormat As New StringFormat
        Public Shared PlusMinusSize As Size
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Dim thePath As String = Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) & Path.DirectorySeparatorChar & ".." & Path.DirectorySeparatorChar & "Resources" & Path.DirectorySeparatorChar & "Images" & Path.DirectorySeparatorChar
            If Not ServiceManager.Services Is Nothing Then
                Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
                If myResourceService Is Nothing Then
                    m_bmpMinus = New Bitmap(thePath & "tv_minus.bmp")
                    m_bmpPlus = New Bitmap(thePath & "tv_plus.bmp")
                Else
                    m_bmpMinus = myResourceService.GetBitmap("TreeGridMinus")
                    m_bmpPlus = myResourceService.GetBitmap("TreeGridPlus")
                End If
            Else
                m_bmpMinus = New Bitmap(thePath & "tv_minus.bmp")
                m_bmpPlus = New Bitmap(thePath & "tv_plus.bmp")
            End If
            PlusMinusSize = m_bmpPlus.Size

            If Me.DataAlignment = HorizontalAlignment.Center Then
                m_drawTextFormat.Alignment = StringAlignment.Center
            ElseIf Me.DataAlignment = HorizontalAlignment.Right Then
                m_drawTextFormat.Alignment = StringAlignment.Far
            Else
                m_drawTextFormat.Alignment = StringAlignment.Near
            End If
        End Sub
#End Region

#Region "Overrides"

        Protected Overloads Overrides Sub Edit(ByVal source As _
        System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds _
        As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText _
        As String, ByVal cellIsVisible As Boolean)
            If TypeOf CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable) Is TreeTable Then
                Dim table As TreeTable = CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable)
                If rowNum < table.Rows.Count Then
                    Dim row As TreeRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), TreeRow)
                    Dim plusminusLocation As Point
                    plusminusLocation.X = bounds.X + (row.Level * Me.PlusMinusSize.Width)
                    plusminusLocation.Y = bounds.Y + CInt((bounds.Height / 2) - (PlusMinusSize.Height / 2))
                    Dim plusMinusRect As New Rectangle(plusminusLocation, PlusMinusSize)
                    bounds.Width -= ((row.Level + 1) * Me.PlusMinusSize.Width)
                    bounds.X += ((row.Level + 1) * Me.PlusMinusSize.Width)
                    If Not row.Readonly Then
                        If row.State = RowExpandState.None Then
                            bounds.Width += Me.PlusMinusSize.Width
                            bounds.X -= Me.PlusMinusSize.Width
                        End If
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
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, _
        ByVal bounds As System.Drawing.Rectangle, ByVal source As _
        System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal _
        backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, _
        ByVal alignToRight As Boolean)
            Dim r As Rectangle = bounds
            Dim myFont As Font = MyBase.TextBox.Font
            If TypeOf CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable) Is TreeTable Then
                Dim table As TreeTable = CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable)
                If rowNum < table.Rows.Count Then
                    PrePareRow(g, rowNum, source, backBrush, foreBrush, myFont)
                    Dim row As TreeRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), TreeRow)
                    Dim state As RowExpandState = row.State
                    'clear the cell
                    g.FillRectangle(backBrush, bounds)
                    DrawPlusMinus(r, g, state, row.Level, table.MaxLevel)
                    'draw the value
                    r.Width -= (PlusMinusSize.Width + (row.Level * PlusMinusSize.Width))
                    r.X += PlusMinusSize.Width + (row.Level * PlusMinusSize.Width)
                    Dim s As String = Me.GetText(Me.GetColumnValueAtRow([source], rowNum))
                    If row.State = RowExpandState.None Then
                        r.Width += PlusMinusSize.Width
                        r.X -= PlusMinusSize.Width
                    End If
                    r.Inflate(0, -1)
                    g.DrawString(s, myFont, foreBrush, RectangleF.op_Implicit(r), m_drawTextFormat)
                Else
                    MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
                End If
            Else
                MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            End If
        End Sub
#End Region

#Region "Methods"
        Private Sub DrawPlusMinus(ByVal bounds As Rectangle, ByVal g As Graphics, ByVal state As RowExpandState, ByVal level As Integer, ByVal maxLevel As Integer)
            Dim plusminusLocation As Point
            plusminusLocation.X = bounds.X + (level * Me.PlusMinusSize.Width)
            plusminusLocation.Y = bounds.Y + CInt((bounds.Height / 2) - (PlusMinusSize.Height / 2))
            Dim plusMinusRect As New Rectangle(plusminusLocation, PlusMinusSize)
            Dim hti As DataGrid.HitTestInfo = Me.DataGridTableStyle.DataGrid.HitTest(New Point(bounds.X, bounds.Y))
            Dim LastRow As TreeRow
            If hti.Row > 0 Then
                LastRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(hti.Row - 1), TreeRow)
            End If
            For i As Integer = 0 To level
                If state = RowExpandState.None And i = level Then
                    Exit For
                End If
                If (i <> level Or i = 0 Or (Not LastRow Is Nothing AndAlso LastRow.Level >= level)) And hti.Row > 0 Then
                    g.FillRectangle(New SolidBrush(CType(ColorList((i Mod ColorList.Count)), Color)), New Rectangle(bounds.X + i * PlusMinusSize.Width, bounds.Y - 1, Me.PlusMinusSize.Width, bounds.Height + 1))
                Else
                    g.FillRectangle(New SolidBrush(CType(ColorList((i Mod ColorList.Count)), Color)), New Rectangle(bounds.X + i * PlusMinusSize.Width, bounds.Y, Me.PlusMinusSize.Width, bounds.Height))
                End If
            Next
            If state = RowExpandState.Collapsed Then
                g.DrawImage(Me.m_bmpPlus, plusminusLocation)
            ElseIf state = RowExpandState.Expanded Then
                g.DrawImage(Me.m_bmpMinus, plusminusLocation)
            End If
        End Sub
#End Region

    End Class
End Namespace