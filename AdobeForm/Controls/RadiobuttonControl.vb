Namespace Longkong.AdobeForm
    Public Enum VerticalAlignment
        Top
        Middle
        Bottom
    End Enum

    Public Class RadiobuttonControl
        Inherits BorderyControl

#Region "Members"
        Private m_Checked As Boolean
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal xmlNode As XmlNode)
            MyBase.New(xmlNode)
        End Sub
#End Region

#Region "Properties"
        Property Checked() As Boolean
            Get
                Return m_Checked
            End Get
            Set(ByVal Value As Boolean)
                m_Checked = Value
            End Set
        End Property
#End Region

#Region "IDrawable"

        Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim p As New Pen(BorderColor)
            Dim fillBr As New SolidBrush(FillColor)
            Dim fontBr As New SolidBrush(CaptionColor)
            Dim sf As New StringFormat
            Dim Rect As New RectangleF(Location.X, Location.Y, Width, Height)
            Dim captionRect As New RectangleF(Location.X + (Width - Reserve), Location.Y, Reserve, Height)
            Dim checkedState As ButtonState

            If Checked() Then
                checkedState = ButtonState.Checked
            Else
                checkedState = ButtonState.Normal
            End If

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

            p.Width = BorderThickness
            p.DashStyle = BorderStyle
            g.FillRectangle(fillBr, Rect)
            g.DrawRectangle(p, Location.X, Location.Y, Width, Height)
            ControlPaint.DrawRadioButton(g, Location.X + 5, Location.Y + CInt((Height / 2) - 15), 30, 30, checkedState)
            g.DrawString(Caption, CaptionFont, fontBr, captionRect, sf)
        End Sub

#End Region

    End Class
End Namespace

