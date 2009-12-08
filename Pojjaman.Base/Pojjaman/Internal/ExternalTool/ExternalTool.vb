Imports System.Xml

Namespace Longkong.Pojjaman.Internal.ExternalTool
    Public Class ExternalTool

#Region "Members"
        ' Fields
        Private m_arguments As String
        Private m_command As String
        Private m_initialDirectory As String
        Private m_menuCommand As String
        Private m_promptForArguments As Boolean
        Private m_useOutputPad As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_menuCommand = "New Tool"
            Me.m_command = ""
            Me.m_arguments = ""
            Me.m_initialDirectory = ""
            Me.m_promptForArguments = False
            Me.m_useOutputPad = False
        End Sub
        Public Sub New(ByVal el As XmlElement)
            Me.m_menuCommand = "New Tool"
            Me.m_command = ""
            Me.m_arguments = ""
            Me.m_initialDirectory = ""
            Me.m_promptForArguments = False
            Me.m_useOutputPad = False
            If (el Is Nothing) Then
                Throw New ArgumentNullException("ExternalTool(XmlElement el) : el can't be null")
            End If
            If (((el.Item("INITIALDIRECTORY") Is Nothing) OrElse (el.Item("ARGUMENTS") Is Nothing)) OrElse (((el.Item("COMMAND") Is Nothing) OrElse (el.Item("MENUCOMMAND") Is Nothing)) OrElse (el.Item("PROMPTFORARGUMENTS") Is Nothing))) Then
                Throw New Exception("ExternalTool(XmlElement el) : INITIALDIRECTORY and ARGUMENTS and COMMAND and MENUCOMMAND and PROMPTFORARGUMENTS attributes must exist.(check the ExternalTool XML)")
            End If
            Me.m_initialDirectory = el.Item("INITIALDIRECTORY").InnerText
            Me.m_arguments = el.Item("ARGUMENTS").InnerText
            Me.m_command = el.Item("COMMAND").InnerText
            Me.m_menuCommand = el.Item("MENUCOMMAND").InnerText
            Me.m_promptForArguments = Boolean.Parse(el.Item("PROMPTFORARGUMENTS").InnerText)
            If (Not el.Item("USEOUTPUTPAD") Is Nothing) Then
                Me.m_useOutputPad = Boolean.Parse(el.Item("USEOUTPUTPAD").InnerText)
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property Arguments() As String
            Get
                Return Me.m_arguments
            End Get
            Set(ByVal value As String)
                Me.m_arguments = value
            End Set
        End Property
        Public Property Command() As String
            Get
                Return Me.m_command
            End Get
            Set(ByVal value As String)
                Me.m_command = value
            End Set
        End Property
        Public Property InitialDirectory() As String
            Get
                Return Me.m_initialDirectory
            End Get
            Set(ByVal value As String)
                Me.m_initialDirectory = value
            End Set
        End Property
        Public Property MenuCommand() As String
            Get
                Return Me.m_menuCommand
            End Get
            Set(ByVal value As String)
                Me.m_menuCommand = value
            End Set
        End Property
        Public Property PromptForArguments() As Boolean
            Get
                Return Me.m_promptForArguments
            End Get
            Set(ByVal value As Boolean)
                Me.m_promptForArguments = value
            End Set
        End Property
        Public Property UseOutputPad() As Boolean
            Get
                Return Me.m_useOutputPad
            End Get
            Set(ByVal value As Boolean)
                Me.m_useOutputPad = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function ToString() As String
            Return Me.m_menuCommand
        End Function
        Public Function ToXmlElement(ByVal doc As XmlDocument) As XmlElement
            If (doc Is Nothing) Then
                Throw New ArgumentNullException("ExternalTool.ToXmlElement(XmlDocument doc) : doc can't be null")
            End If
            Dim el As XmlElement = doc.CreateElement("TOOL")
            Dim el2 As XmlElement = doc.CreateElement("INITIALDIRECTORY")
            el2.InnerText = Me.InitialDirectory
            el.AppendChild(el2)
            el2 = doc.CreateElement("ARGUMENTS")
            el2.InnerText = Me.Arguments
            el.AppendChild(el2)
            el2 = doc.CreateElement("COMMAND")
            el2.InnerText = Me.m_command
            el.AppendChild(el2)
            el2 = doc.CreateElement("MENUCOMMAND")
            el2.InnerText = Me.MenuCommand
            el.AppendChild(el2)
            el2 = doc.CreateElement("PROMPTFORARGUMENTS")
            el2.InnerText = Me.PromptForArguments.ToString
            el.AppendChild(el2)
            el2 = doc.CreateElement("USEOUTPUTPAD")
            el2.InnerText = Me.UseOutputPad.ToString
            el.AppendChild(el2)
            Return el
        End Function
#End Region

    End Class
End Namespace




