Namespace Longkong.AdobeForm
    Public Class TextControl
        Inherits BorderyControl

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

#Region "IDrawable"
        Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim fontBr As New SolidBrush(CaptionColor)
            Dim fillBr As New SolidBrush(FillColor)
            Dim sf As New StringFormat
            Dim Rect As New RectangleF(Location.X, Location.Y, Width, Height)

            Select Case HAlignment()
                Case HorizontalAlignment.Center
                    sf.Alignment = StringAlignment.Center
                Case HorizontalAlignment.Left
                    sf.Alignment = StringAlignment.Near
                Case HorizontalAlignment.Right
                    sf.Alignment = StringAlignment.Far
            End Select

            Select Case VAlignment()
                Case VerticalAlignment.Middle
                    sf.LineAlignment = StringAlignment.Center
                Case VerticalAlignment.Top
                    sf.LineAlignment = StringAlignment.Near
                Case VerticalAlignment.Bottom
                    sf.LineAlignment = StringAlignment.Far
            End Select

            g.FillRectangle(fillBr, Rect)

            DrawEdge(g, Me.LeftEdge, LeftRightTopBottom.Left)
            DrawEdge(g, Me.RightEdge, LeftRightTopBottom.Right)
            DrawEdge(g, Me.TopEdge, LeftRightTopBottom.Top)
            DrawEdge(g, Me.BottomEdge, LeftRightTopBottom.Bottom)

            If Not Me.MapCaption Is Nothing AndAlso (Me.MapCaption.ToLower = "=refprcode" OrElse Me.MapCaption.ToLower = "=refungroupprcode") Then
                sf.FormatFlags = StringFormatFlags.NoClip
            Else
                sf.FormatFlags = StringFormatFlags.NoClip Or StringFormatFlags.NoWrap
            End If
            sf.Trimming = StringTrimming.None
            g.DrawString(Caption, CaptionFont, fontBr, Rect, sf)
        End Sub
#End Region

    End Class
End Namespace

