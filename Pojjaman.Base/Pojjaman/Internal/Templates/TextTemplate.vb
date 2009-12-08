Imports System.Xml
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Collections.Specialized
Namespace Longkong.Pojjaman.Internal.Templates
    Public Class TextTemplate

#Region "Members"
        Private m_entries As ArrayList
        Private m_name As String
        Public Shared TextTemplates As ArrayList
#End Region

#Region "Constructors"
        Shared Sub New()
            TextTemplate.TextTemplates = New ArrayList
            Dim service1 As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            Dim service2 As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim objArray1 As Object() = New Object() {service2.DataDirectory, Path.DirectorySeparatorChar, "options", Path.DirectorySeparatorChar, "textlib"}
            Dim files As StringCollection = service1.SearchDirectory(String.Concat(objArray1), "*.xml")
            For Each file As String In files
                TextTemplate.LoadTextTemplate(file)
            Next
        End Sub
        Public Sub New(ByVal filename As String)
            Me.m_name = Nothing
            Me.m_entries = New ArrayList
            Try
                Dim doc As New XmlDocument
                doc.Load(filename)
                Me.m_name = doc.DocumentElement.Attributes.ItemOf("name").InnerText
                Dim el As XmlElement
                For Each el In doc.DocumentElement.ChildNodes
                    Me.m_entries.Add(New Entry(el))
                Next
            Catch ex As Exception
                Throw New FileLoadException("Can't load standard sidebar template file", filename, ex)
            End Try
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Entries() As ArrayList
            Get
                Return Me.m_entries
            End Get
        End Property
        Public ReadOnly Property Name() As String
            Get
                Return Me.m_name
            End Get
        End Property
#End Region

#Region "Methods"
        Private Shared Sub LoadTextTemplate(ByVal filename As String)
            TextTemplate.TextTemplates.Add(New TextTemplate(filename))
        End Sub
#End Region


        Public Class Entry

#Region "Members"
            Public Display As String
            Public Value As String
#End Region

#Region "Constructors"
            Public Sub New(ByVal el As XmlElement)
                Me.Display = el.Attributes.ItemOf("display").InnerText
                Me.Value = el.Attributes.ItemOf("value").InnerText
            End Sub
#End Region

#Region "Members"
            Public Overrides Function ToString() As String
                Return Me.Display
            End Function
#End Region

        End Class
    End Class
End Namespace




