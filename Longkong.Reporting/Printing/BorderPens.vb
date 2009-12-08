Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class BorderPens

#Region "Enums"
        Private Enum RectSide
            Bottom = 2
            Left = 3
            Right = 1
            Top = 0
        End Enum
#End Region

#Region "Members"
        Public Bottom As Pen
        Public Left As Pen
        Public Right As Pen
        Public Top As Pen
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property BottomWidth() As Single
            Get
                Dim w As Single = 0.0!
                If (Not Me.Bottom Is Nothing) Then
                    w = Me.Bottom.Width
                End If
                Return w
            End Get
        End Property
        Public ReadOnly Property LeftWidth() As Single
            Get
                Dim w As Single = 0.0!
                If (Not Me.Left Is Nothing) Then
                    w = Me.Left.Width
                End If
                Return w
            End Get
        End Property
        Public ReadOnly Property RightWidth() As Single
            Get
                Dim w As Single = 0.0!
                If (Not Me.Right Is Nothing) Then
                    w = Me.Right.Width
                End If
                Return w
            End Get
        End Property
        Public ReadOnly Property TopWidth() As Single
            Get
                Dim w As Single = 0.0!
                If (Not Me.Top Is Nothing) Then
                    w = Me.Top.Width
                End If
                Return w
            End Get
        End Property
#End Region

#Region "Methods"
        Public Function AddBorderSize(ByVal size As SizeF) As SizeF
            If (Not Me.Top Is Nothing) Then
                size.Height = (size.Height + Me.Top.Width)
            End If
            If (Not Me.Right Is Nothing) Then
                size.Width = (size.Width + Me.Right.Width)
            End If
            If (Not Me.Bottom Is Nothing) Then
                size.Height = (size.Height + Me.Bottom.Width)
            End If
            If (Not Me.Left Is Nothing) Then
                size.Width = (size.Width + Me.Left.Width)
            End If
            Return size
        End Function
        Public Sub DrawBorder(ByVal g As Graphics, ByVal bounds As Bounds)
            Dim ef1 As RectangleF = bounds.GetRectangleF
            Me.DrawBorder(g, ef1)
        End Sub
        Public Sub DrawBorder(ByVal g As Graphics, ByVal rect As RectangleF)
            Me.DrawLine(g, Me.Top, rect, RectSide.Top)
            Me.DrawLine(g, Me.Right, rect, RectSide.Right)
            Me.DrawLine(g, Me.Bottom, rect, RectSide.Bottom)
            Me.DrawLine(g, Me.Left, rect, RectSide.Left)
        End Sub
        Public Sub DrawBottom(ByVal g As Graphics, ByVal rect As RectangleF)
            Me.DrawLine(g, Me.Bottom, rect, RectSide.Bottom)
        End Sub
        Public Sub DrawLeft(ByVal g As Graphics, ByVal rect As RectangleF)
            Me.DrawLine(g, Me.Left, rect, RectSide.Left)
        End Sub
        Public Sub DrawRight(ByVal g As Graphics, ByVal rect As RectangleF)
            Me.DrawLine(g, Me.Right, rect, RectSide.Right)
        End Sub
        Public Sub DrawTop(ByVal g As Graphics, ByVal rect As RectangleF)
            Me.DrawLine(g, Me.Top, rect, RectSide.Top)
        End Sub
        Public Function GetInnerBounds(ByVal bounds As Bounds) As Bounds
            If (Not Me.Top Is Nothing) Then
                bounds.Position.Y = (bounds.Position.Y + Me.Top.Width)
            End If
            If (Not Me.Right Is Nothing) Then
                bounds.Limit.X = (bounds.Limit.X - Me.Right.Width)
            End If
            If (Not Me.Bottom Is Nothing) Then
                bounds.Limit.Y = (bounds.Limit.Y - Me.Bottom.Width)
            End If
            If (Not Me.Left Is Nothing) Then
                bounds.Position.X = (bounds.Position.X + Me.Left.Width)
            End If
            Return bounds
        End Function
        Private Sub DrawLine(ByVal g As Graphics, ByVal pen As Pen, ByVal rect As RectangleF, ByVal side As RectSide)
            Dim x1 As Single = 0.0!
            Dim y1 As Single = 0.0!
            Dim x2 As Single = 0.0!
            Dim y2 As Single = 0.0!
            If (Not pen Is Nothing) Then
                Select Case side
                    Case RectSide.Top
                        x1 = rect.Left
                        x2 = rect.Right
                        y2 = (rect.Top + (pen.Width / 2.0!))
                        y1 = y2
                    Case RectSide.Right
                        x2 = (rect.Right - (pen.Width / 2.0!))
                        x1 = x2
                        y1 = rect.Top
                        y2 = rect.Bottom
                    Case RectSide.Bottom
                        x1 = rect.Left
                        x2 = rect.Right
                        y2 = (rect.Bottom - (pen.Width / 2.0!))
                        y1 = y2
                    Case RectSide.Left
                        x2 = (rect.Left + (pen.Width / 2.0!))
                        x1 = x2
                        y1 = rect.Top
                        y2 = rect.Bottom
                End Select
                g.DrawLine(pen, x1, y1, x2, y2)
            End If
        End Sub
#End Region

    End Class
End Namespace