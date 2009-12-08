Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Core.Properties
Imports System.IO
Imports System.Xml
Namespace Longkong.Pojjaman.Internal.ExternalTool
    Public Class ToolLoader

#Region "Members"
        Private Shared m_tool As ArrayList
        Private Shared TOOLFILE As String
        Private Shared TOOLFILEVERSION As String
#End Region

#Region "Constructors"
        Shared Sub New()
            ToolLoader.TOOLFILE = "Pojjaman-tools.xml"
            ToolLoader.TOOLFILEVERSION = "1"
            ToolLoader.m_tool = New ArrayList
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            If Not ToolLoader.LoadToolsFromStream((myPropertyService.ConfigDirectory & ToolLoader.TOOLFILE)) Then
                Console.WriteLine("Tools: can't load user defaults, reading system defaults")
                Dim fileNames As Object() = New Object() {myPropertyService.DataDirectory, Path.DirectorySeparatorChar, "options", Path.DirectorySeparatorChar, ToolLoader.TOOLFILE}
                If Not ToolLoader.LoadToolsFromStream(String.Concat(fileNames)) Then
                    Dim myResourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
                    Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                    myMessageService.ShowWarning(myResourceService.GetString("Internal.ExternalTool.CantLoadToolConfigWarining"))
                End If
            End If
        End Sub
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Shared Property Tool() As ArrayList
            Get
                Return ToolLoader.Tool
            End Get
            Set(ByVal value As ArrayList)
                ToolLoader.Tool = value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Shared Function LoadToolsFromStream(ByVal filename As String) As Boolean
            If Not File.Exists(filename) Then
                Return False
            End If
            Dim doc As New XmlDocument
            Try
                doc.Load(filename)
                If (Not doc.DocumentElement.Attributes.ItemOf("VERSION").InnerText Is ToolLoader.TOOLFILEVERSION) Then
                    Return False
                End If
                ToolLoader.m_tool = New ArrayList
                For Each el As XmlElement In doc.DocumentElement.ChildNodes
                    ToolLoader.m_tool.Add(New ExternalTool(el))
                Next
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Shared Sub SaveTools()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            ToolLoader.WriteToolsToFile((myPropertyService.ConfigDirectory & ToolLoader.TOOLFILE))
        End Sub
        Private Shared Sub WriteToolsToFile(ByVal fileName As String)
            Dim doc As New XmlDocument
            doc.LoadXml(("<TOOLS VERSION = """ & ToolLoader.TOOLFILEVERSION & """ />"))
            For Each myTool As ExternalTool In ToolLoader.m_tool
                doc.DocumentElement.AppendChild(myTool.ToXmlElement(doc))
            Next
            Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            myFileUtilityService.ObservedSave(New NamedFileOperationDelegate(AddressOf doc.Save), fileName, FileErrorPolicy.ProvideAlternative)
        End Sub
#End Region
    End Class
End Namespace




