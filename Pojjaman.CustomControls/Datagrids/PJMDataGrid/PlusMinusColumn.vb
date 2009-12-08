Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PlusMinusColumn
        Inherits HeaderAndDataAlignColumn
        Private components As System.ComponentModel.IContainer

#Region "Members"
        Protected m_bmpMinus As Bitmap, m_bmpPlus As Bitmap
        Private m_drawTxt As New StringFormat
        Public Shared PlusMinusSize As Size
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            If ServiceManager.Services Is Nothing Then
                Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
                If myResourceService Is Nothing Then
                    m_bmpMinus = New Bitmap("..\Resources\Images\tv_minus.bmp")
                    m_bmpPlus = New Bitmap("..\Resources\Images\tv_plus.bmp")
                Else
                    m_bmpMinus = myResourceService.GetBitmap("TreeGridMinus")
                    m_bmpPlus = myResourceService.GetBitmap("TreeGridPlus")
                End If
            Else
                m_bmpMinus = New Bitmap("..\Resources\Images\tv_minus.bmp")
                m_bmpPlus = New Bitmap("..\Resources\Images\tv_plus.bmp")
            End If
            PlusMinusSize = m_bmpPlus.Size
            If Me.DataAlignment = HorizontalAlignment.Center Then
                m_drawTxt.Alignment = StringAlignment.Center
            ElseIf Me.DataAlignment = HorizontalAlignment.Right Then
                m_drawTxt.Alignment = StringAlignment.Far
            Else
                m_drawTxt.Alignment = StringAlignment.Near
            End If
        End Sub
#End Region

#Region "Overrides"

        Protected Overloads Overrides Sub Edit(ByVal source As _
        System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds _
        As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText _
        As String, ByVal cellIsVisible As Boolean)
            ' get cursor coordinates
            Dim row As ExpandableDataRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), ExpandableDataRow)
            Dim state As PlusMinusState = row.State
            Dim plusminusLocation As Point
            plusminusLocation.X = bounds.X + (row.Level * Me.PlusMinusSize.Width)
            plusminusLocation.Y = bounds.Y + CInt((bounds.Height / 2) - (PlusMinusSize.Height / 2))
            Dim plusMinusRect As New Rectangle(plusminusLocation, PlusMinusSize)
            Dim dt As ExpandableRowDataTable = CType(row.Table, ExpandableRowDataTable)
            bounds.Width -= ((row.Level + 1) * Me.PlusMinusSize.Width)
            bounds.X += ((row.Level + 1) * Me.PlusMinusSize.Width)
            If state = PlusMinusState.None Or state = PlusMinusState.UnderParent Then
                bounds.Width += Me.PlusMinusSize.Width
                bounds.X -= Me.PlusMinusSize.Width
            End If
            If row.State = PlusMinusState.UnderParent Then
                MyBase.Edit(source, rowNum, bounds, [readOnly], instantText, cellIsVisible)
            Else
                If TextBox.TextLength = 0 Then
                    bounds = Rectangle.Empty
                End If
                MyBase.Edit(source, rowNum, bounds, True, instantText, cellIsVisible)
            End If
            'MyBase.TextBox.TextAlign = Me.DataAlignment
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, _
        ByVal bounds As System.Drawing.Rectangle, ByVal source As _
        System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal _
        backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, _
        ByVal alignToRight As Boolean)
            Dim r As Rectangle = bounds
            Dim myFont As Font
            If TypeOf Me.DataGridTableStyle.DataGrid.DataSource Is ExpandableRowDataTable Then
                PrePareRow(g, rowNum, source, backBrush, foreBrush, myFont)

                Dim row As ExpandableDataRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), ExpandableDataRow)
                Dim state As PlusMinusState = row.State
                Dim level As Integer = row.Level
                'clear the cell
                g.FillRectangle(backBrush, bounds)

                DrawPlusMinus(r, g, state, level)
                'draw the value
                r.Width -= (PlusMinusSize.Width + (level * PlusMinusSize.Width))
                r.X += PlusMinusSize.Width + (level * PlusMinusSize.Width)
                Dim s As String = Me.GetText(Me.GetColumnValueAtRow([source], rowNum))
                If state = PlusMinusState.None Or state = PlusMinusState.UnderParent Then
                    r.Width += PlusMinusSize.Width
                    r.X -= PlusMinusSize.Width
                End If
                r.Inflate(0, -1)
                g.DrawString(s, myFont, foreBrush, RectangleF.op_Implicit(r), m_drawTxt)
            Else

            End If
        End Sub
#End Region

#Region "Properties"
#End Region

#Region "Methods"
        Private Sub DrawPlusMinus(ByVal bounds As Rectangle, ByVal g As Graphics, ByVal state As PlusMinusState, ByVal level As Integer)
            Dim plusminusLocation As Point
            plusminusLocation.X = bounds.X + (level * Me.PlusMinusSize.Width)
            plusminusLocation.Y = bounds.Y + CInt((bounds.Height / 2) - (PlusMinusSize.Height / 2))
            Dim plusMinusRect As New Rectangle(plusminusLocation, PlusMinusSize)
            Dim hti As DataGrid.HitTestInfo = Me.DataGridTableStyle.DataGrid.HitTest(New Point(bounds.X, bounds.Y))
            Dim LastRow As ExpandableDataRow
            If hti.Row > 0 Then
                LastRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(hti.Row - 1), ExpandableDataRow)
            End If
            For i As Integer = 0 To level
                If (state = PlusMinusState.None Or state = PlusMinusState.UnderParent) And i = level Then
                    Exit For
                End If
                If (i <> level Or i = 0 Or (Not LastRow Is Nothing AndAlso LastRow.Level >= level)) And hti.Row > 0 Then
                    g.FillRectangle(New SolidBrush(CType(ColorList((i Mod ColorList.Count)), Color)), New Rectangle(bounds.X + i * PlusMinusSize.Width, bounds.Y - 1, Me.PlusMinusSize.Width, bounds.Height + 1))
                Else
                    g.FillRectangle(New SolidBrush(CType(ColorList((i Mod ColorList.Count)), Color)), New Rectangle(bounds.X + i * PlusMinusSize.Width, bounds.Y, Me.PlusMinusSize.Width, bounds.Height))
                End If
            Next
            If state = PlusMinusState.Collapsed Then
                If Not Me.m_bmpPlus Is Nothing Then
                    g.DrawImage(Me.m_bmpPlus, plusminusLocation)
                End If
            ElseIf state = PlusMinusState.Expanded Then
                If Not Me.m_bmpMinus Is Nothing Then
                    g.DrawImage(Me.m_bmpMinus, plusminusLocation)
                End If
            End If
        End Sub
#End Region

    End Class
End Namespace
