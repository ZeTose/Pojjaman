Namespace Longkong.AdobeForm
    Public Class TextFieldControl
        Inherits BorderyControl

#Region "Members"
        Private m_Text As String
        Private m_MapText As String
        Private m_TextFont As Font
        Private m_TextColor As Color = SystemColors.ControlText
        Private m_UnderlineColor As Color = SystemColors.ControlText
        Private m_TextHAlignment As HorizontalAlignment
        Private m_TextVAlignment As VerticalAlignment
        Private m_underlined As Boolean
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal xmlNode As XmlNode)
            MyBase.New(xmlNode)
            ProcessXmlNode(xmlNode)
            MapText = Text
        End Sub
        Private Sub ProcessXmlNode(ByVal xmlnode As XmlNode)
            Dim foundedNode As xmlnode = xmlnode.SelectSingleNode("value/text")
            foundedNode = xmlnode.SelectSingleNode("value/text")
            If Not foundedNode Is Nothing Then
                Me.m_Text = foundedNode.InnerText
            End If
            Dim edgeNodes As XmlNodeList = xmlnode.SelectNodes("ui/textEdit/border/edge")
            If Not edgeNodes Is Nothing Then
                Dim cnt As Integer
                For Each edgeNode As xmlnode In edgeNodes
                    If Not edgeNode.Attributes("presence") Is Nothing Then
                        cnt += 1
                    End If
                Next
                If edgeNodes.Count - cnt = 1 Then
                    Me.m_underlined = True
                ElseIf edgeNodes.Count = 1 Then
                    foundedNode = xmlnode.SelectSingleNode("ui/textEdit/border/corner")
                    If foundedNode Is Nothing Then
                        Me.m_underlined = True
                    End If
                End If
            End If
            foundedNode = xmlnode.SelectSingleNode("font")
            If Not foundedNode Is Nothing Then
                Me.m_TextFont = DesignerForm.GetFontFromNode(foundedNode)
            End If
            foundedNode = xmlnode.SelectSingleNode("font/fill/color")
            If Not foundedNode Is Nothing Then
                If Not foundedNode.Attributes("value") Is Nothing Then
                    Dim rgb As String() = foundedNode.Attributes("value").Value.Split(","c)
                    Dim col As Color = Color.FromArgb(CInt(rgb(0)), CInt(rgb(1)), CInt(rgb(2)))
                    Me.m_TextColor = col
                End If
            End If
            foundedNode = xmlnode.SelectSingleNode("para")
            If Not foundedNode Is Nothing Then
                For Each xmlAttr As XmlAttribute In foundedNode.Attributes
                    Select Case xmlAttr.Name.ToLower
                        Case "halign"
                            Select Case xmlAttr.Value.ToLower
                                Case "center"
                                    Me.m_TextHAlignment = HorizontalAlignment.Center
                                Case "right"
                                    Me.m_TextHAlignment = HorizontalAlignment.Right
                            End Select
                        Case "valign"
                            Select Case xmlAttr.Value.ToLower
                                Case "middle"
                                    Me.m_TextVAlignment = VerticalAlignment.Middle
                                Case "bottom"
                                    Me.m_TextVAlignment = VerticalAlignment.Bottom
                            End Select
                    End Select
                Next
            End If
        End Sub
#End Region

#Region "Properties"
        Property MapText() As String
            Get
                Return m_MapText
            End Get
            Set(ByVal Value As String)
                m_MapText = Value
            End Set
        End Property
        Property Text() As String
            Get
                Return m_Text
            End Get
            Set(ByVal Value As String)
                m_Text = Value
            End Set
        End Property
        Property TextFont() As Font
            Get
                Return m_TextFont
            End Get
            Set(ByVal Value As Font)
                m_TextFont = Value
            End Set
        End Property
        Property TextColor() As Color
            Get
                Return m_TextColor
            End Get
            Set(ByVal Value As Color)
                m_TextColor = Value
            End Set
        End Property
        Property UnderLineColor() As Color
            Get
                Return m_UnderlineColor
            End Get
            Set(ByVal Value As Color)
                m_UnderlineColor = Value
            End Set
        End Property
        Public Property Underlined() As Boolean            Get                Return m_underlined            End Get            Set(ByVal Value As Boolean)                m_underlined = Value            End Set        End Property
        Property TextHAlignment() As HorizontalAlignment
            Get
                Return m_TextHAlignment
            End Get
            Set(ByVal Value As HorizontalAlignment)
                m_TextHAlignment = Value
            End Set
        End Property
        Property TextVAlignment() As VerticalAlignment
            Get
                Return m_TextVAlignment
            End Get
            Set(ByVal Value As VerticalAlignment)
                m_TextVAlignment = Value
            End Set
        End Property
#End Region

#Region "IDrawable"

        Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim textBr As New SolidBrush(TextColor)
            Dim captionBr As New SolidBrush(CaptionColor)
            Dim fillBr As New SolidBrush(FillColor)
            Dim sf As New StringFormat

            Dim Rect As New RectangleF(Location.X, Location.Y, Width, Height)
            Dim CaptionRect As RectangleF
            Dim textRect As RectangleF
            Dim lp1 As Point
            Dim lp2 As Point
            Dim lp0 As Point
            Select Case CaptionPosition
                Case CaptionPosition.Left
                    CaptionRect = New RectangleF(Location.X, Location.Y, Reserve, Height)
                    textRect = New RectangleF(Location.X + Reserve, Location.Y, Width - Reserve, Height)
                    lp1 = New Point(Location.X + Reserve, Location.Y + (Height - 5))
                    lp2 = New Point(Location.X + (Width - 5), Location.Y + (Height - 5))
                Case CaptionPosition.Right
                    CaptionRect = New RectangleF(Location.X + (Width - Reserve), Location.Y, Reserve, Height)
                    textRect = New RectangleF(Location.X, Location.Y, Width - Reserve, Height)
                    lp1 = New Point(Location.X, Location.Y + (Height - 5))
                    lp2 = New Point(Location.X + ((Width - Reserve) - 5), Location.Y + (Height - 5))
                Case CaptionPosition.Top
                    CaptionRect = New RectangleF(Location.X, Location.Y, Width, Reserve)
                    textRect = New RectangleF(Location.X, Location.Y + Reserve, Width, Height - Reserve)
                    lp1 = New Point(Location.X + 5, CInt(Location.Y + ((Height - Reserve) / 2) + Reserve + g.MeasureString(Text, TextFont).Height / 2))
                    lp2 = New Point(Location.X + (Width - 5), CInt(Location.Y + ((Height - Reserve) / 2) + Reserve + g.MeasureString(Text, TextFont).Height / 2))
                Case CaptionPosition.Bottom
                    CaptionRect = New RectangleF(Location.X, Location.Y + (Height - Reserve), Width, Reserve)
                    textRect = New RectangleF(Location.X, Location.Y, Width, Height - Reserve)
                    lp1 = New Point(Location.X + 5, CInt(Location.Y + ((Height - Reserve) / 2) + g.MeasureString(Text, TextFont).Height / 2))
                    lp2 = New Point(Location.X + (Width - 5), CInt(Location.Y + ((Height - Reserve) / 2) + g.MeasureString(Text, TextFont).Height / 2))
            End Select

            g.FillRectangle(fillBr, Rect)

            If BorderThickness <> 0 Then
                Dim borderPen As New Pen(BorderColor)
                borderPen.Width = BorderThickness
                borderPen.DashStyle = BorderStyle
                g.DrawRectangle(borderPen, Location.X, Location.Y, Width, Height)
            End If

            If Underlined Then
                Dim underlinePen As New Pen(UnderLineColor)
                g.DrawLine(underlinePen, lp1, lp2)
                underlinePen.Dispose()
            End If

            sf.FormatFlags = StringFormatFlags.NoClip Or StringFormatFlags.NoWrap
            sf.Trimming = StringTrimming.None
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

            g.DrawString(Caption, CaptionFont, captionBr, CaptionRect, sf)

            Select Case TextHAlignment()
                Case HorizontalAlignment.Center
                    sf.Alignment = StringAlignment.Center
                Case HorizontalAlignment.Left
                    sf.Alignment = StringAlignment.Near
                Case HorizontalAlignment.Right
                    sf.Alignment = StringAlignment.Far
            End Select

            Select Case TextVAlignment()
                Case VerticalAlignment.Middle
                    sf.LineAlignment = StringAlignment.Center
                Case VerticalAlignment.Top
                    sf.LineAlignment = StringAlignment.Near
                Case VerticalAlignment.Bottom
                    sf.LineAlignment = StringAlignment.Far
            End Select

            g.DrawString(Text, TextFont, textBr, textRect, sf)
        End Sub
#End Region

    End Class
End Namespace

