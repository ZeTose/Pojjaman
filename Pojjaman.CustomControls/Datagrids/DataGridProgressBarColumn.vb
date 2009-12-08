Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection


Namespace Longkong.Pojjaman.Gui.Components

    Public Class DataGridProgressBarColumn
        Inherits PJMColumnStyle

        Private m_stretchToFit As Boolean


        Public Property StretchToFit() As Boolean
            Get
                Return m_stretchToFit
            End Get
            Set(ByVal Value As Boolean)
                m_stretchToFit = Value
            End Set
        End Property

        Public Sub New()

            Me.Padding.SetPadding(0, 2, 0, 2)
            Me.ControlSize = New Size(80, 10)
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width
            m_stretchToFit = True
        End Sub


        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)

            g.FillRectangle(backBrush, bounds)
            Dim controlBounds As Rectangle = Me.GetControlBounds(bounds)

            If m_stretchToFit Then
                controlBounds.Width = bounds.Width - (Me.Padding.Left + Me.Padding.Right)
                controlBounds.X = bounds.X + Me.Padding.Left
            End If

            Dim fillRect As New Rectangle(controlBounds.X + 2, controlBounds.Y + 2, controlBounds.Width - 3, controlBounds.Height - 3)

            Dim maxWidth As Integer = fillRect.Width
            Dim indexWidth As Double = CDbl(fillRect.Width) / 100 ' determines the width of each index.
            If IsDBNull(Me.GetColumnValueAtRow([source], rowNum)) Then
                fillRect.Width = 0
            Else
                fillRect.Width = CInt(CInt(Me.GetColumnValueAtRow([source], rowNum)) * indexWidth)
            End If

            If fillRect.Width > maxWidth Then
                fillRect.Width = maxWidth
            End If

            Dim p As New Pen(New SolidBrush(Color.Black))
            Try
                g.DrawRectangle(p, controlBounds)
            Finally
                p.Dispose()
            End Try

            Dim sb As New SolidBrush(Color.Red)
            Try
                g.FillRectangle(sb, fillRect)
            Finally
                sb.Dispose()
            End Try
        End Sub
    End Class
End Namespace
