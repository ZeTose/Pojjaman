Namespace Longkong.AdobeForm
    Public Class VectorControl
        Inherits AdobeControl

#Region "Members"
        Private m_LineStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
        Private m_LineColor As Color = SystemColors.ControlText
        Private m_LineThickness As Integer = 1
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal xmlNode As XmlNode)
            MyBase.New(xmlNode)
            ProcessXmlNode(xmlNode)
        End Sub
        Private Sub ProcessXmlNode(ByVal xmlnode As XmlNode)
            'Dim prefix As String = ""
            'Dim foundedNode As XmlNode = xmlnode.SelectSingleNode("caption")
            'If Not foundedNode Is Nothing Then
            '    prefix = "caption/"
            '    If Not foundedNode.Attributes("placement") Is Nothing Then
            '        Select Case foundedNode.Attributes("placement").Value.ToLower
            '            Case "top"
            '                Me.m_CaptionPosition = CaptionPosition.Top
            '            Case "bottom"
            '                Me.m_CaptionPosition = CaptionPosition.Bottom
            '            Case "left"
            '                Me.m_CaptionPosition = CaptionPosition.Left
            '            Case "right"
            '                Me.m_CaptionPosition = CaptionPosition.Right
            '        End Select
            '    End If
            '    If Not foundedNode.Attributes("reserve") Is Nothing Then
            '        Me.m_Reserve = DesignerForm.AnyThingToPixel(foundedNode.Attributes("reserve").Value)
            '    End If
            'End If
            'foundedNode = xmlnode.SelectSingleNode(prefix & "value/text")
            'If Not foundedNode Is Nothing Then
            '    Me.Caption = foundedNode.InnerText
            'Else
            '    foundedNode = xmlnode.SelectSingleNode(prefix & "value/exData/body/p")
            '    If Not foundedNode Is Nothing Then
            '        Dim caps As XmlNodeList = xmlnode.SelectNodes(prefix & "value/exData/body/p")
            '        Dim i As Integer
            '        For Each node As XmlNode In caps
            '            Me.Caption &= node.InnerText
            '            If i < caps.Count - 1 Then
            '                Me.Caption &= vbCrLf
            '            End If
            '            i += 1
            '        Next
            '    End If
            'End If
            'foundedNode = xmlnode.SelectSingleNode(prefix & "font")
            'If Not foundedNode Is Nothing Then
            '    Me.CaptionFont = DesignerForm.GetFontFromNode(foundedNode)
            'End If
            'foundedNode = xmlnode.SelectSingleNode(prefix & "font/fill/color")
            'If Not foundedNode Is Nothing Then
            '    If Not foundedNode.Attributes("value") Is Nothing Then
            '        Dim rgb As String() = foundedNode.Attributes("value").Value.Split(","c)
            '        Dim col As Color = Color.FromArgb(CInt(rgb(0)), CInt(rgb(1)), CInt(rgb(2)))
            '        Me.m_CaptionColor = col
            '    End If
            'End If
            'foundedNode = xmlnode.SelectSingleNode(prefix & "para")
            'If Not foundedNode Is Nothing Then
            '    For Each xmlAttr As XmlAttribute In foundedNode.Attributes
            '        Select Case xmlAttr.Name.ToLower
            '            Case "halign"
            '                Select Case xmlAttr.Value.ToLower
            '                    Case "center"
            '                        Me.HAlignment = HorizontalAlignment.Center
            '                    Case "right"
            '                        Me.HAlignment = HorizontalAlignment.Right
            '                End Select
            '            Case "valign"
            '                Select Case xmlAttr.Value.ToLower
            '                    Case "middle"
            '                        Me.VAlignment = VerticalAlignment.Middle
            '                    Case "bottom"
            '                        Me.VAlignment = VerticalAlignment.Bottom
            '                End Select
            '        End Select
            '    Next
            'End If
            'foundedNode = xmlnode.SelectSingleNode(prefix & "border/fill/color")
            'If Not foundedNode Is Nothing Then
            '    If Not foundedNode.Attributes("value") Is Nothing Then
            '        Dim rgb As String() = foundedNode.Attributes("value").Value.Split(","c)
            '        Dim col As Color = Color.FromArgb(CInt(rgb(0)), CInt(rgb(1)), CInt(rgb(2)))
            '        Me.m_FillColor = col
            '    End If
            'End If

            ''หาเส้นขอบ
            'foundedNode = xmlnode.SelectSingleNode("border/edge")
            'If foundedNode Is Nothing Then
            '    foundedNode = xmlnode.SelectSingleNode("ui/textEdit/border/edge")
            'End If
            'If Not foundedNode Is Nothing Then
            '    If Not foundedNode.Attributes("thickness") Is Nothing Then
            '        Me.m_BorderThickness = DesignerForm.AnyThingToPixel(foundedNode.Attributes("thickness").Value)
            '    Else
            '        Me.m_BorderThickness = 1
            '    End If
            '    If Not foundedNode.Attributes("presence") Is Nothing Then
            '        If foundedNode.Attributes("presence").Value.ToLower = "hidden" Then
            '            Me.m_BorderThickness = 0
            '        End If
            '    End If
            '    If Not foundedNode.Attributes("stroke") Is Nothing Then
            '        Select Case foundedNode.Attributes("stroke").Value.ToLower
            '            Case "dotted"
            '                Me.m_BorderStyle = Drawing2D.DashStyle.Dot
            '            Case "dashdotdot"
            '                Me.m_BorderStyle = Drawing2D.DashStyle.DashDotDot
            '            Case "dashdot"
            '                Me.m_BorderStyle = Drawing2D.DashStyle.DashDot
            '            Case "dashed"
            '                Me.m_BorderStyle = Drawing2D.DashStyle.Dash
            '        End Select
            '    Else
            '        Me.m_BorderStyle = Drawing2D.DashStyle.Solid
            '    End If
            'Else
            '    Me.m_BorderThickness = 0
            'End If
            'foundedNode = xmlnode.SelectSingleNode(prefix & "border/edge/color")
            'If Not foundedNode Is Nothing Then
            '    If Not foundedNode.Attributes("value") Is Nothing Then
            '        Dim rgb As String() = foundedNode.Attributes("value").Value.Split(","c)
            '        Dim col As Color = Color.FromArgb(CInt(rgb(0)), CInt(rgb(1)), CInt(rgb(2)))
            '        Me.m_BorderColor = col
            '    End If
            'End If
        End Sub
#End Region

#Region "properties"
        Public Property LineStyle() As Drawing2D.DashStyle
            Get
                Return m_LineStyle
            End Get
            Set(ByVal Value As Drawing2D.DashStyle)
                If Value <> Drawing2D.DashStyle.Custom Then
                    m_LineStyle = Value
                End If
            End Set
        End Property

        Public Property LineColor() As Color
            Get
                Return m_LineColor
            End Get
            Set(ByVal Value As Color)
                m_LineColor = Value
            End Set
        End Property

        Public Property LineThickness() As Integer
            Get
                Return m_LineThickness
            End Get
            Set(ByVal Value As Integer)
                m_LineThickness = Value
            End Set
        End Property
#End Region

    End Class
End Namespace

