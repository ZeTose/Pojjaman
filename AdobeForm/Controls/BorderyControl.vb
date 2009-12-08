Namespace Longkong.AdobeForm
    Public Enum CaptionPosition
        Left
        Right
        Top
        Bottom
    End Enum
    Public Enum LeftRightTopBottom
        Left
        Right
        Top
        Bottom
    End Enum
    Public Class Edge

#Region "Members"
        Private m_BorderStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
        Private m_BorderThickness As Integer = 0
        Private m_BorderColor As Color = SystemColors.ControlText
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal borderStyle As Drawing2D.DashStyle, ByVal borderThickness As Integer, ByVal borderColor As Color)
            m_BorderStyle = borderStyle
            m_BorderThickness = borderThickness
            m_BorderColor = borderColor
        End Sub
        Public Sub New(ByVal xmlNode As XmlNode)
            ProcessXmlNode(xmlNode)
        End Sub
        Private Sub ProcessXmlNode(ByVal xmlnode As XmlNode)
            If Not xmlnode.Attributes("thickness") Is Nothing Then
                Me.m_BorderThickness = DesignerForm.AnyThingToPixel(xmlnode.Attributes("thickness").Value)
            Else
                Me.m_BorderThickness = 1
            End If
            If Not xmlnode.Attributes("presence") Is Nothing Then
                If xmlnode.Attributes("presence").Value.ToLower = "hidden" Then
                    Me.m_BorderThickness = 0
                End If
            End If
            If Not xmlnode.Attributes("stroke") Is Nothing Then
                Select Case xmlnode.Attributes("stroke").Value.ToLower
                    Case "dotted"
                        Me.m_BorderStyle = Drawing2D.DashStyle.Dot
                    Case "dashdotdot"
                        Me.m_BorderStyle = Drawing2D.DashStyle.DashDotDot
                    Case "dashdot"
                        Me.m_BorderStyle = Drawing2D.DashStyle.DashDot
                    Case "dashed"
                        Me.m_BorderStyle = Drawing2D.DashStyle.Dash
                End Select
            Else
                Me.m_BorderStyle = Drawing2D.DashStyle.Solid
            End If

            Dim foundedNode As xmlnode
            foundedNode = xmlnode.SelectSingleNode("color")
            If Not foundedNode Is Nothing Then
                If Not foundedNode.Attributes("value") Is Nothing Then
                    Dim rgb As String() = foundedNode.Attributes("value").Value.Split(","c)
                    Dim col As Color = Color.FromArgb(CInt(rgb(0)), CInt(rgb(1)), CInt(rgb(2)))
                    Me.m_BorderColor = col
                End If
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property BorderStyle() As Drawing2D.DashStyle            Get                Return m_BorderStyle            End Get            Set(ByVal Value As Drawing2D.DashStyle)                m_BorderStyle = Value            End Set        End Property        Public Property BorderThickness() As Integer            Get                Return m_BorderThickness            End Get            Set(ByVal Value As Integer)                m_BorderThickness = Value            End Set        End Property        Public Property BorderColor() As Color            Get                Return m_BorderColor            End Get            Set(ByVal Value As Color)                m_BorderColor = Value            End Set        End Property
#End Region

    End Class
    Public Class BorderyControl
        Inherits AdobeControl

#Region "Members"
        Private m_Caption As String
        Private m_MapCaption As String
        Private m_CaptionFont As Font
        Private m_CaptionColor As Color = SystemColors.ControlText
        Private m_Reserve As Integer
        Private m_FillColor As Color = SystemColors.Window
        Private m_BorderStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
        Private m_BorderThickness As Integer = 0
        Private m_BorderColor As Color = SystemColors.ControlText
        Private m_CaptionPosition As CaptionPosition
        Private m_HAlignment As HorizontalAlignment = HorizontalAlignment.Left
        Private m_VAlignment As VerticalAlignment = VerticalAlignment.Top

        Private m_topEdge As New Edge
        Private m_rightEdge As New Edge
        Private m_bottomEdge As New Edge
        Private m_leftEdge As New Edge
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal xmlNode As XmlNode)
            MyBase.New(xmlNode)
            ProcessXmlNode(xmlNode)
            Me.MapCaption = Me.Caption
        End Sub
        Private Sub ProcessXmlNode(ByVal xmlnode As XmlNode)
            Dim prefix As String = ""
            Dim foundedNode As xmlnode = xmlnode.SelectSingleNode("caption")
            If Not foundedNode Is Nothing Then
                prefix = "caption/"
                If Not foundedNode.Attributes("placement") Is Nothing Then
                    Select Case foundedNode.Attributes("placement").Value.ToLower
                        Case "top"
                            Me.m_CaptionPosition = CaptionPosition.Top
                        Case "bottom"
                            Me.m_CaptionPosition = CaptionPosition.Bottom
                        Case "left"
                            Me.m_CaptionPosition = CaptionPosition.Left
                        Case "right"
                            Me.m_CaptionPosition = CaptionPosition.Right
                    End Select
                End If
                If Not foundedNode.Attributes("reserve") Is Nothing Then
                    Me.m_Reserve = DesignerForm.AnyThingToPixel(foundedNode.Attributes("reserve").Value)
                End If
            End If
            foundedNode = xmlnode.SelectSingleNode(prefix & "value/text")
            If Not foundedNode Is Nothing Then
                Me.Caption = foundedNode.InnerText
            Else
                foundedNode = xmlnode.SelectSingleNode(prefix & "value/exData/body/p")
                If Not foundedNode Is Nothing Then
                    Dim caps As XmlNodeList = xmlnode.SelectNodes(prefix & "value/exData/body/p")
                    Dim i As Integer
                    For Each node As xmlnode In caps
                        Me.Caption &= node.InnerText
                        If i < caps.Count - 1 Then
                            Me.Caption &= vbCrLf
                        End If
                        i += 1
                    Next
                End If
            End If
            foundedNode = xmlnode.SelectSingleNode(prefix & "font")
            If Not foundedNode Is Nothing Then
                Me.CaptionFont = DesignerForm.GetFontFromNode(foundedNode)
            End If
            foundedNode = xmlnode.SelectSingleNode(prefix & "font/fill/color")
            If Not foundedNode Is Nothing Then
                If Not foundedNode.Attributes("value") Is Nothing Then
                    Dim rgb As String() = foundedNode.Attributes("value").Value.Split(","c)
                    Dim col As Color = Color.FromArgb(CInt(rgb(0)), CInt(rgb(1)), CInt(rgb(2)))
                    Me.m_CaptionColor = col
                End If
            End If
            foundedNode = xmlnode.SelectSingleNode(prefix & "para")
            If Not foundedNode Is Nothing Then
                For Each xmlAttr As XmlAttribute In foundedNode.Attributes
                    Select Case xmlAttr.Name.ToLower
                        Case "halign"
                            Select Case xmlAttr.Value.ToLower
                                Case "center"
                                    Me.HAlignment = HorizontalAlignment.Center
                                Case "right"
                                    Me.HAlignment = HorizontalAlignment.Right
                            End Select
                        Case "valign"
                            Select Case xmlAttr.Value.ToLower
                                Case "middle"
                                    Me.VAlignment = VerticalAlignment.Middle
                                Case "bottom"
                                    Me.VAlignment = VerticalAlignment.Bottom
                            End Select
                    End Select
                Next
            End If
            foundedNode = xmlnode.SelectSingleNode(prefix & "border/fill/color")
            If Not foundedNode Is Nothing Then
                If Not foundedNode.Attributes("value") Is Nothing Then
                    Dim rgb As String() = foundedNode.Attributes("value").Value.Split(","c)
                    Dim col As Color = Color.FromArgb(CInt(rgb(0)), CInt(rgb(1)), CInt(rgb(2)))
                    Me.m_FillColor = col
                End If
            End If

            'หาเส้นขอบ
            ProcessBorderFromXMLNode(xmlnode, prefix)
        End Sub
        Private Sub ProcessBorderFromXMLNode(ByVal xmlnode As XmlNode, ByVal prefix As String)
            Dim foundedNode As xmlnode
            foundedNode = xmlnode.SelectSingleNode("border/edge")
            If foundedNode Is Nothing Then
                foundedNode = xmlnode.SelectSingleNode("ui/textEdit/border/edge")
            End If
            If Not foundedNode Is Nothing Then
                If Not foundedNode.Attributes("thickness") Is Nothing Then
                    Me.m_BorderThickness = DesignerForm.AnyThingToPixel(foundedNode.Attributes("thickness").Value)
                Else
                    Me.m_BorderThickness = 1
                End If
                If Not foundedNode.Attributes("presence") Is Nothing Then
                    If foundedNode.Attributes("presence").Value.ToLower = "hidden" Then
                        Me.m_BorderThickness = 0
                    End If
                End If
                If Not foundedNode.Attributes("stroke") Is Nothing Then
                    Select Case foundedNode.Attributes("stroke").Value.ToLower
                        Case "dotted"
                            Me.m_BorderStyle = Drawing2D.DashStyle.Dot
                        Case "dashdotdot"
                            Me.m_BorderStyle = Drawing2D.DashStyle.DashDotDot
                        Case "dashdot"
                            Me.m_BorderStyle = Drawing2D.DashStyle.DashDot
                        Case "dashed"
                            Me.m_BorderStyle = Drawing2D.DashStyle.Dash
                    End Select
                Else
                    Me.m_BorderStyle = Drawing2D.DashStyle.Solid
                End If
            Else
                Me.m_BorderThickness = 0
            End If
            foundedNode = xmlnode.SelectSingleNode(prefix & "border/edge/color")
            If Not foundedNode Is Nothing Then
                If Not foundedNode.Attributes("value") Is Nothing Then
                    Dim rgb As String() = foundedNode.Attributes("value").Value.Split(","c)
                    Dim col As Color = Color.FromArgb(CInt(rgb(0)), CInt(rgb(1)), CInt(rgb(2)))
                    Me.m_BorderColor = col
                End If
            End If

            '********************************************************************************
            Dim foundedNodes As XmlNodeList
            foundedNode = xmlnode.SelectSingleNode("border/edge")
            If Not foundedNode Is Nothing Then
                foundedNodes = xmlnode.SelectNodes("border/edge")
            Else
                foundedNodes = xmlnode.SelectNodes("ui/textEdit/border/edge")
            End If
            If Not foundedNodes Is Nothing Then
                If foundedNodes.Count = 1 Then
                    m_topEdge = New Edge(foundedNodes(0))
                    m_rightEdge = New Edge(foundedNodes(0))
                    m_bottomEdge = New Edge(foundedNodes(0))
                    m_leftEdge = New Edge(foundedNodes(0))
                ElseIf foundedNodes.Count = 2 Then
                    m_topEdge = New Edge(foundedNodes(0))
                    m_rightEdge = New Edge(foundedNodes(1))
                    m_bottomEdge = New Edge(foundedNodes(1))
                    m_leftEdge = New Edge(foundedNodes(1))
                ElseIf foundedNodes.Count = 3 Then
                    m_topEdge = New Edge(foundedNodes(0))
                    m_rightEdge = New Edge(foundedNodes(1))
                    m_bottomEdge = New Edge(foundedNodes(2))
                    m_leftEdge = New Edge(foundedNodes(2))
                ElseIf foundedNodes.Count = 4 Then
                    m_topEdge = New Edge(foundedNodes(0))
                    m_rightEdge = New Edge(foundedNodes(1))
                    m_bottomEdge = New Edge(foundedNodes(2))
                    m_leftEdge = New Edge(foundedNodes(3))
                End If
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property TopEdge() As Edge            Get                Return m_topEdge            End Get            Set(ByVal Value As Edge)                m_topEdge = Value            End Set        End Property        Public Property RightEdge() As Edge            Get                Return m_rightEdge            End Get            Set(ByVal Value As Edge)                m_rightEdge = Value            End Set        End Property        Public Property BottomEdge() As Edge            Get                Return m_bottomEdge            End Get            Set(ByVal Value As Edge)                m_bottomEdge = Value            End Set        End Property        Public Property LeftEdge() As Edge            Get                Return m_leftEdge            End Get            Set(ByVal Value As Edge)                m_leftEdge = Value            End Set        End Property
        Public Property MapCaption() As String
            Get
                Return m_MapCaption
            End Get
            Set(ByVal Value As String)
                m_MapCaption = Value
            End Set
        End Property
        Public Property Caption() As String
            Get
                Return m_Caption
            End Get
            Set(ByVal Value As String)
                m_Caption = Value
            End Set
        End Property
        Property CaptionPosition() As CaptionPosition
            Get
                Return m_CaptionPosition
            End Get
            Set(ByVal Value As CaptionPosition)
                m_CaptionPosition = Value
            End Set
        End Property
        Property Reserve() As Integer
            Get
                Return m_Reserve
            End Get
            Set(ByVal Value As Integer)
                m_Reserve = Value
            End Set
        End Property
        Public Property CaptionFont() As Font
            Get
                Return m_CaptionFont
            End Get
            Set(ByVal Value As Font)
                m_CaptionFont = Value
            End Set
        End Property

        Public Property CaptionColor() As Color
            Get
                Return m_CaptionColor
            End Get
            Set(ByVal Value As Color)
                m_CaptionColor = Value
            End Set
        End Property
        Property HAlignment() As HorizontalAlignment
            Get
                Return m_HAlignment
            End Get
            Set(ByVal Value As HorizontalAlignment)
                m_HAlignment = Value
            End Set
        End Property
        Property VAlignment() As VerticalAlignment
            Get
                Return m_VAlignment
            End Get
            Set(ByVal Value As VerticalAlignment)
                m_VAlignment = Value
            End Set
        End Property
        Public Property FillColor() As Color
            Get
                Return m_FillColor
            End Get
            Set(ByVal Value As Color)
                m_FillColor = Value
            End Set
        End Property

        Public Property BorderStyle() As Drawing2D.DashStyle
            Get
                Return m_BorderStyle
            End Get
            Set(ByVal Value As Drawing2D.DashStyle)
                m_BorderStyle = Value
            End Set
        End Property

        Public Property BorderColor() As Color
            Get
                Return m_BorderColor
            End Get
            Set(ByVal Value As Color)
                m_BorderColor = Value
            End Set
        End Property

        Public Property BorderThickness() As Integer
            Get
                Return m_BorderThickness
            End Get
            Set(ByVal Value As Integer)
                m_BorderThickness = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Sub DrawEdge(ByVal g As Graphics, ByVal e As Edge, ByVal direction As LeftRightTopBottom)
            If e.BorderThickness <> 0 Then
                Dim p As New Pen(e.BorderColor)
                p.Width = e.BorderThickness
                p.DashStyle = e.BorderStyle
                Dim tl As New Point(Location.X, Location.Y)
                Dim tr As New Point(Location.X + Width, Location.Y)
                Dim bl As New Point(Location.X, Location.Y + Height)
                Dim br As New Point(Location.X + Width, Location.Y + Height)
                Select Case direction
                    Case LeftRightTopBottom.Bottom
                        g.DrawLine(p, bl, br)
                    Case LeftRightTopBottom.Left
                        g.DrawLine(p, tl, bl)
                    Case LeftRightTopBottom.Right
                        g.DrawLine(p, tr, br)
                    Case LeftRightTopBottom.Top
                        g.DrawLine(p, tl, tr)
                End Select
                p.Dispose()
            End If
        End Sub
#End Region

    End Class
End Namespace

