Namespace Longkong.AdobeForm
    Public Class LineControl
        Inherits VectorControl

#Region "Constructor"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal xmlNode As XmlNode)
            MyBase.New(xmlNode)
        End Sub
#End Region

#Region "IDrawable"

        Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim p As New Pen(LineColor)
            p.DashStyle = LineStyle
            p.Width = LineThickness
            g.DrawLine(p, Location.X, Location.Y, Location.X + Width, Location.Y + Height)
        End Sub
#End Region

    End Class
End Namespace
