Namespace Longkong.AdobeForm
    Public Class RectangleControl
        Inherits VectorControl

#Region "Members"
        Private m_FillColor As Color
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal xmlNode As XmlNode)
            MyBase.New(xmlNode)
            ProcessXmlNode(xmlNode)
        End Sub
        Private Sub ProcessXmlNode(ByVal xmlnode As XmlNode)

        End Sub
#End Region

#Region "Properties"
        Public Property FillColor() As Color
            Get
                Return m_FillColor
            End Get
            Set(ByVal Value As Color)
                m_FillColor = Value
            End Set
        End Property
#End Region

#Region "IDrawable"

        Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim p As New Pen(LineColor)
            Dim br As New SolidBrush(FillColor)
            Dim Rect As New Rectangle(Location.X, Location.Y, Width, Height)

            p.Width = LineThickness
            p.DashStyle = LineStyle
            g.FillRectangle(br, Rect)
            g.DrawRectangle(p, Location.X, Location.Y, Width, Height)
        End Sub

#End Region

    End Class
End Namespace

