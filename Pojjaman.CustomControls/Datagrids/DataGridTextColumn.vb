Imports System
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms


Namespace Longkong.Pojjaman.Gui.Components

    Public Class DataGridTextColumn
        Inherits PJMColumnStyle


        Public Sub New()
            Me.ControlSize = New Size(150, 16)
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width
        End Sub


        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)

            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Near
            sf.LineAlignment = StringAlignment.Center
            sf.FormatFlags = StringFormatFlags.FitBlackBox 'StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.FitBlackBox
            g.FillRectangle(backBrush, bounds)

            ' TODO: fix this
            Dim boundsF As New System.Drawing.RectangleF( _
                CType(bounds.X, Single), _
                CType(bounds.Y, Single), _
                CType(bounds.Width, Single), _
                CType(bounds.Height, Single))

            g.DrawString(Me.GetColumnValueAtRow([source], rowNum).ToString(), Me.DataGridTableStyle.DataGrid.Font, foreBrush, boundsF, sf)

        End Sub
    End Class
End Namespace


