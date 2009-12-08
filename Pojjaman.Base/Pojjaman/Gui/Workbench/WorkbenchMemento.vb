Imports Longkong.Core.Properties
Imports System.Xml
Namespace Longkong.Pojjaman.Gui
    Public Class WorkbenchMemento
        Implements IXmlConvertable

#Region "Members"
        Private m_defaultwindowstate As FormWindowState = FormWindowState.Normal
        Private m_windowstate As FormWindowState = FormWindowState.Normal
        Private m_bounds As Rectangle = New Rectangle(0, 0, 640, 480)
        Private m_fullscreen As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_windowstate = FormWindowState.Maximized
            Me.m_bounds = New Rectangle(0, 0, 640, 480)
            Me.m_fullscreen = False
        End Sub
        Private Sub New(ByVal element As XmlElement)
            Me.m_windowstate = FormWindowState.Normal
            Me.m_defaultwindowstate = FormWindowState.Normal
            Me.m_bounds = New Rectangle(0, 0, 640, 480)
            Me.m_fullscreen = False
            Dim boundstr As String() = element.Attributes.ItemOf("bounds").InnerText.Split(New Char() {","c})
            Me.m_bounds = New Rectangle(Integer.Parse(boundstr(0)), Integer.Parse(boundstr(1)), Integer.Parse(boundstr(2)), Integer.Parse(boundstr(3)))
            Me.m_windowstate = CType([Enum].Parse(GetType(FormWindowState), element.Attributes.ItemOf("formwindowstate").InnerText), FormWindowState)
            If (Not element.Attributes.ItemOf("defaultformwindowstate") Is Nothing) Then
                Me.m_defaultwindowstate = CType([Enum].Parse(GetType(FormWindowState), element.Attributes.ItemOf("defaultformwindowstate").InnerText), FormWindowState)
            End If
            Me.m_fullscreen = Boolean.Parse(element.Attributes.ItemOf("fullscreen").InnerText)
        End Sub
#End Region

#Region "Properties"
        Public Property Bounds() As Rectangle
            Get
                Return Me.m_bounds
            End Get
            Set(ByVal value As Rectangle)
                Me.m_bounds = value
            End Set
        End Property
        Public Property DefaultWindowState() As FormWindowState
            Get
                Return Me.m_defaultwindowstate
            End Get
            Set(ByVal value As FormWindowState)
                Me.m_defaultwindowstate = value
            End Set
        End Property
        Public Property FullScreen() As Boolean
            Get
                Return Me.m_fullscreen
            End Get
            Set(ByVal value As Boolean)
                Me.m_fullscreen = value
            End Set
        End Property
        Public Property WindowState() As FormWindowState
            Get
                Return Me.m_windowstate
            End Get
            Set(ByVal value As FormWindowState)
                Me.m_windowstate = value
            End Set
        End Property
#End Region

#Region "IXmlConvertable"
        Public Function FromXmlElement(ByVal element As System.Xml.XmlElement) As Object Implements IXmlConvertable.FromXmlElement
            Return New WorkbenchMemento(element)
        End Function
        Public Function ToXmlElement(ByVal doc As System.Xml.XmlDocument) As System.Xml.XmlElement Implements IXmlConvertable.ToXmlElement
            Dim element As XmlElement = doc.CreateElement("WindowState")
            Dim attr As XmlAttribute

            attr = doc.CreateAttribute("bounds")
            Dim tmpStrings As Object() = New Object() {Me.m_bounds.X, ",", Me.m_bounds.Y, ",", Me.m_bounds.Width, ",", Me.m_bounds.Height}
            attr.InnerText = String.Concat(tmpStrings)
            element.Attributes.Append(attr)

            attr = doc.CreateAttribute("formwindowstate")
            attr.InnerText = Me.m_windowstate.ToString
            element.Attributes.Append(attr)

            attr = doc.CreateAttribute("defaultformwindowstate")
            attr.InnerText = Me.m_defaultwindowstate.ToString
            element.Attributes.Append(attr)

            attr = doc.CreateAttribute("fullscreen")
            attr.InnerText = Me.m_fullscreen.ToString
            element.Attributes.Append(attr)

            Return element
        End Function
#End Region

    End Class
End Namespace