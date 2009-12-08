Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Drawing.Design
Namespace Longkong.FormTable
    Public Class EllipseBoxControl
        Inherits DataBoxControl

#Region "Overrides"
        Protected Overrides Sub SetOutLine(ByVal loc As System.Drawing.Point)
            m_outline = New GraphicsPath
            m_outline.AddEllipse(loc.X + 1, loc.Y + 1, Width - 2, Height - 2)
            m_regionOutline = New GraphicsPath
            m_regionOutline.AddEllipse(New Rectangle(loc.X, loc.Y, Width, Height))
        End Sub
#End Region


    End Class
End Namespace