Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.CustomControl
    Public Enum ScrollButtonOrientation
        Up
        Down
    End Enum

    Public Class ScrollButton

        Private Shared SIZE As Integer = 16
        Private Shared PADDING As Integer = 5
        Private m_btnRect As Rectangle
        Private m_orientation As ScrollButtonOrientation

        Public Property Location() As Point
            Get
                Return New Point(m_btnRect.X, m_btnRect.Y)
            End Get
            Set(ByVal Value As Point)
                m_btnRect = New Rectangle(Value.X, Value.Y, SIZE, SIZE)
            End Set
        End Property

        Public Sub ScrollButton(ByVal sbo As ScrollButtonOrientation)
            m_orientation = sbo
        End Sub

        Public Function HitTest(ByVal pt As Point) As Boolean
            Return m_btnRect.Contains(pt)
        End Function

        Public Sub Draw(ByVal g As Graphics, ByVal state As ButtonState)
            DrawButton(g, state)
            DrawArrow(g, state)
        End Sub

        Private Sub DrawButton(ByVal g As Graphics, ByVal state As ButtonState)
            If m_btnRect.IsEmpty Then
                Return
            End If
            ControlPaint.DrawButton(g, m_btnRect, state)
        End Sub

        Private Sub DrawArrow(ByVal g As Graphics, ByVal state As ButtonState)
            If m_orientation = ScrollButtonOrientation.Up Then
                DrawUpArrow(g, state)
            Else
                DrawDownArrow(g, state)
            End If
        End Sub

        Private Sub DrawUpArrow(ByVal g As Graphics, ByVal state As ButtonState)
            Dim pts() As Point = New Point(2) {}
            Dim n As Integer
            If state = ButtonState.Pushed Then
                n = 1
            Else
                n = 0
            End If
            pts(0).X = CInt(m_btnRect.Left + (m_btnRect.Width / 2) + n)
            pts(0).Y = m_btnRect.Top + PADDING + n

            pts(1).X = m_btnRect.Left + 2 + n
            pts(1).Y = m_btnRect.Bottom - PADDING + n

            pts(2).X = m_btnRect.Right - 2 + n
            pts(2).Y = m_btnRect.Bottom - PADDING + n

            RenderArrow(g, pts)
        End Sub

        Private Sub DrawDownArrow(ByVal g As Graphics, ByVal state As ButtonState)
            Dim pts() As Point = New Point(2) {}
            Dim n As Integer
            If state = ButtonState.Pushed Then
                n = 1
            Else
                n = 0
            End If
            pts(0).X = CInt(m_btnRect.Left + (m_btnRect.Width / 2) + n)
            pts(0).Y = m_btnRect.Bottom - PADDING + n

            pts(1).X = m_btnRect.Left + 2 + n
            pts(1).Y = m_btnRect.Top + PADDING + n

            pts(2).X = m_btnRect.Right - 2 + n
            pts(2).Y = m_btnRect.Top + PADDING + n

            RenderArrow(g, pts)
        End Sub

        Private Sub RenderArrow(ByVal g As Graphics, ByVal pts As Point())
            Dim path As New System.Drawing.Drawing2D.GraphicsPath
            path.AddLines(pts)
            path.CloseFigure()
            Dim blackBrush As Brush = New SolidBrush(System.Drawing.Color.Black)
            g.FillPath(blackBrush, path)
            blackBrush.Dispose()
        End Sub

        Public Sub New(ByVal sbo As ScrollButtonOrientation)
            m_orientation = sbo
        End Sub
    End Class

End Namespace
