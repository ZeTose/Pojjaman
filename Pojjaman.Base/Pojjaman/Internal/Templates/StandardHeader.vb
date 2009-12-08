Imports System.Xml
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Collections.Specialized
Namespace Longkong.Pojjaman.Internal.Templates
    Public Class StandardHeader

#Region "Members"
        Private m_header As String
        Private m_name As String
        Private m_propertyService As PropertyService
        Private Shared m_standardHeaders As ArrayList
        Private Shared m_version As String

        Private Shared TemplateFileName As String

#End Region

#Region "Constructors"
        Shared Sub New()
            StandardHeader.m_version = "1.0"
            StandardHeader.TemplateFileName = "StandardHeader.xml"
            StandardHeader.m_standardHeaders = New ArrayList
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            If (Not StandardHeader.LoadHeaders(Path.Combine(myPropertyService.ConfigDirectory, StandardHeader.TemplateFileName)) AndAlso Not StandardHeader.LoadHeaders(Path.Combine((myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "options"), StandardHeader.TemplateFileName))) Then
                Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                myMessageService.ShowWarning("Can not load standard headers")
            End If
        End Sub
        Public Sub New(ByVal el As XmlElement)
            Me.m_propertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Me.m_name = el.GetAttribute("name")
            Me.m_header = el.InnerText
        End Sub
#End Region

#Region "Properties"
        Public Property Header() As String
            Get
                Return Me.m_header
            End Get
            Set(ByVal value As String)
                Me.m_header = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return Me.m_name
            End Get
            Set(ByVal value As String)
                Me.m_name = value
            End Set
        End Property
        Public Shared ReadOnly Property StandardHeaders() As ArrayList
            Get
                Return StandardHeader.m_standardHeaders
            End Get
        End Property
#End Region

#Region "Members'"
        Private Shared Function LoadHeaders(ByVal fileName As String) As Boolean
            If Not File.Exists(fileName) Then
                Return False
            End If
            Dim doc As New XmlDocument
            Try
                doc.Load(fileName)
                If (Not doc.DocumentElement.GetAttribute("version") = StandardHeader.m_version) Then
                    Return False
                End If
                For Each el As XmlElement In doc.DocumentElement.ChildNodes
                    StandardHeader.StandardHeaders.Add(New StandardHeader(el))
                Next
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Shared Sub SetHeaders()
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            For Each myHeader As StandardHeader In StandardHeader.m_standardHeaders
                myStringParserService.Properties(myHeader.Name) = myHeader.Header
            Next
        End Sub
        Public Shared Sub StoreHeaders()
            Dim doc As New XmlDocument
            doc.LoadXml(("<StandardProperties version = """ & StandardHeader.m_version & """ />"))
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            For Each myHeader As StandardHeader In StandardHeader.m_standardHeaders
                Dim el As XmlElement = doc.CreateElement("Property")
                el.SetAttribute("name", myHeader.Name)
                el.InnerText = myHeader.Header
                doc.DocumentElement.AppendChild(el)
            Next
            doc.Save(Path.Combine(myPropertyService.ConfigDirectory, StandardHeader.TemplateFileName))
            StandardHeader.SetHeaders()
        End Sub
        Public Overrides Function ToString() As String
            Return Me.Name.Substring("StandardHeader.".Length)
        End Function
#End Region


    End Class
End Namespace




