Namespace Longkong.AdobeForm
    Public Enum CheckState
        Off
        [On]
        Nuetral
    End Enum

    Public Class CheckboxControl
        Inherits BorderyControl

#Region "Members"
        Private m_Checked As CheckState
        Private m_checkCondition As String
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
            Dim foundedNode As xmlnode = xmlnode.SelectSingleNode("value/integer")
            If Not foundedNode Is Nothing Then
                Select Case foundedNode.InnerText
                    Case "0"
                        Me.Checked = CheckState.Off
                    Case "1"
                        Me.Checked = CheckState.On
                    Case Else
                        Me.Checked = CheckState.Nuetral
                End Select
            Else
                Me.Checked = CheckState.Nuetral
            End If
            foundedNode = xmlnode.SelectSingleNode("value/check")
            If Not foundedNode Is Nothing Then
                m_checkCondition = foundedNode.InnerText
            Else
                m_checkCondition = ""
            End If
        End Sub
#End Region

#Region "Properties"
        Property Checked() As CheckState
            Get
                Return m_Checked
            End Get
            Set(ByVal Value As CheckState)
                m_Checked = Value
            End Set
        End Property
        Public Property CheckCondition() As String            Get                Return m_checkCondition            End Get            Set(ByVal Value As String)                m_checkCondition = Value            End Set        End Property
#End Region

#Region "IDrawable"

        Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim p As New Pen(BorderColor)
            Dim fillBr As New SolidBrush(FillColor)
            Dim fontBr As New SolidBrush(CaptionColor)
            Dim sf As New StringFormat
            Dim Rect As New RectangleF(Location.X, Location.Y, Width, Height)
            Dim captionRect As New RectangleF(Location.X + (Width - Reserve), Location.Y, Reserve, Height)
            Dim checkedstate As ButtonState

            Select Case Checked()
                Case CheckState.Off
                    checkedstate = ButtonState.Normal
                Case CheckState.On
                    checkedstate = ButtonState.Checked
                Case CheckState.Nuetral
                    checkedstate = ButtonState.Inactive
            End Select

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
            Dim checkHight As Integer = Math.Max(Height - 6, 0)
            Dim xOffset As Integer = 5
            Dim yOffSet As Integer = CInt((Height / 2) - checkHight / 2)
            If Me.BorderThickness > 0 Then
                g.DrawRectangle(p, Location.X, Location.Y, Width, Height)
            Else
                checkHight = Height
                xOffset = 0
                xOffset = 0
            End If
            g.DrawRectangle(p, Location.X + xOffset, Location.Y + yOffSet, checkHight, checkHight)
            If checkedstate = ButtonState.Checked Then
                ControlPaint.DrawMenuGlyph(g, Location.X + xOffset + 1, Location.Y + yOffSet + 1, checkHight - 2, checkHight - 2, MenuGlyph.Checkmark)
            End If
            'ControlPaint.DrawCheckBox(g, Location.X + 5, Location.Y + CInt((Height / 2) - 15), 30, 30, checkedstate)
            g.DrawString(Caption, CaptionFont, fontBr, captionRect, sf)
        End Sub
#End Region

    End Class
End Namespace

