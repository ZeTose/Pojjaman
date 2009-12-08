Imports System.Xml
Namespace Longkong.AdobeForm
    Public Class AdobeControl
        Implements IDrawable

#Region "members"
        Public m_Location As Point
        Public m_Width As Integer
        Public m_Height As Integer
#End Region

#Region "Construtor"
        Public Sub New()
        End Sub
        Public Sub New(ByVal xmlNode As Xml.XmlNode)
            ProcessXmlNode(xmlNode)
        End Sub
        Private Sub ProcessXmlNode(ByVal xmlnode As XmlNode)
            If xmlnode.Attributes.Count > 0 Then
                Dim x As Integer = 0
                Dim y As Integer = 0
                If Not xmlnode.Attributes("x") Is Nothing Then
                    x = DesignerForm.AnyThingToPixel(xmlnode.Attributes("x").Value)
                End If
                If Not xmlnode.Attributes("y") Is Nothing Then
                    y = DesignerForm.AnyThingToPixel(xmlnode.Attributes("y").Value)
                End If
                Me.m_Location = New Point(x, y)
                If Not xmlnode.Attributes("w") Is Nothing Then
                    m_Width = DesignerForm.AnyThingToPixel(xmlnode.Attributes("w").Value)
                End If
                If Not xmlnode.Attributes("h") Is Nothing Then
                    m_Height = DesignerForm.AnyThingToPixel(xmlnode.Attributes("h").Value)
                End If
            End If
            If Not xmlnode.Attributes("name") Is Nothing Then
                Me.Name = xmlnode.Attributes("name").Value
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property Location() As Point
            Get
                Return m_Location
            End Get
            Set(ByVal Value As Point)
                m_Location = Value
            End Set
        End Property

        Public Overridable Property Width() As Integer
            Get
                Return m_Width
            End Get
            Set(ByVal Value As Integer)
                m_Width = Value
            End Set
        End Property

        Public Overridable Property Height() As Integer
            Get
                Return m_Height
            End Get
            Set(ByVal Value As Integer)
                m_Height = Value
            End Set
        End Property
        Private m_name As String
        Public Overridable Property Name() As String            Get                Return m_name            End Get            Set(ByVal Value As String)                m_name = Value            End Set        End Property
#End Region


        Public Overridable Property Data() As String Implements IDrawable.Data
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Overridable Overloads Sub Draw(ByVal g As System.Drawing.Graphics) Implements IDrawable.Draw

        End Sub

        Public Overridable Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point) Implements IDrawable.Draw

        End Sub

        Public Overridable Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal data As String) Implements IDrawable.Draw

        End Sub

        Public Overridable Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal image As System.Drawing.Image) Implements IDrawable.Draw

        End Sub
    End Class
End Namespace

