Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Drawing.Design
Namespace Longkong.FormTable
    Public Class RoundedRectBoxControl
        Inherits DataBoxControl

#Region "Overides"
        Private Function GetRoundedRect(ByVal baseRect As RectangleF, ByVal radius As Single) As GraphicsPath
            ' if corner radius is less than or equal to zero, 
            ' return the original rectangle 
            If radius <= 0.0F Then
                Dim mPath As New GraphicsPath
                mPath.AddRectangle(baseRect)
                mPath.CloseFigure()
                Return mPath
            End If

            ' if the corner radius is greater than or equal to 
            ' half the width, or height (whichever is shorter) 
            ' then return a capsule instead of a lozenge 
            If radius >= Math.Min(baseRect.Width, baseRect.Height) / 2.0 Then
                Return GetCapsule(baseRect)
            End If
            ' create the arc for the rectangle sides and declare 
            ' a graphics path object for the drawing 
            Dim diameter As Single = radius * 2.0F
            Dim sizeF As New sizeF(diameter, diameter)
            Dim arc As New RectangleF(baseRect.Location, sizeF)
            Dim path As New System.Drawing.Drawing2D.GraphicsPath

            ' top left arc 
            path.AddArc(arc, 180, 90)

            ' top right arc 
            arc.X = baseRect.Right - diameter
            path.AddArc(arc, 270, 90)

            ' bottom right arc 
            arc.Y = baseRect.Bottom - diameter
            path.AddArc(arc, 0, 90)

            ' bottom left arc
            arc.X = baseRect.Left
            path.AddArc(arc, 90, 90)

            path.CloseFigure()
            Return path
        End Function
        Private Function GetCapsule(ByVal baseRect As RectangleF) As GraphicsPath
            Dim diameter As Single
            Dim arc As RectangleF
            Dim path As New System.Drawing.Drawing2D.GraphicsPath
            Try
                If baseRect.Width > baseRect.Height Then
                    ' return horizontal capsule 
                    diameter = baseRect.Height
                    Dim sizeF As New SizeF(diameter, diameter)
                    arc = New RectangleF(baseRect.Location, sizeF)
                    path.AddArc(arc, 90, 180)
                    arc.X = baseRect.Right - diameter
                    path.AddArc(arc, 270, 180)
                Else
                    If baseRect.Width < baseRect.Height Then
                        ' return vertical capsule 
                        diameter = baseRect.Width
                        Dim sizeF As New SizeF(diameter, diameter)
                        arc = New RectangleF(baseRect.Location, sizeF)
                        path.AddArc(arc, 180, 180)
                        arc.Y = baseRect.Bottom - diameter
                        path.AddArc(arc, 0, 180)
                    Else
                        ' return circle 
                        path.AddEllipse(baseRect)
                    End If
                End If
            Catch ex As Exception
                path.AddEllipse(baseRect)
            Finally
                path.CloseFigure()
            End Try
            Return path
        End Function
        Protected Overrides Sub SetOutLine(ByVal loc As System.Drawing.Point)
            m_outline = New GraphicsPath
            Dim baseRect As New RectangleF(loc.X + 1, loc.Y + 1, Me.Width - 2, Me.Height - 2)
            m_outline = GetRoundedRect(baseRect, 10)

            m_regionOutline = New GraphicsPath
            baseRect = New RectangleF(loc.X, loc.Y, Me.Width, Me.Height)
            m_regionOutline = GetRoundedRect(baseRect, 10)
        End Sub
#End Region


    End Class
End Namespace