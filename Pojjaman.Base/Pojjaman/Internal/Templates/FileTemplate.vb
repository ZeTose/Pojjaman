Imports System.Xml
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Collections.Specialized
Namespace Longkong.Pojjaman.Internal.Templates
    Public Class FileTemplate

#Region "Members"
        Private m_author As String
        Private m_category As String
        Private m_customTypes As ArrayList
        Private m_defaultName As String
        Private m_description As String
        Private m_fileoptions As XmlElement
        Private m_files As ArrayList
        Private m_icon As String
        Private m_languagename As String
        Private m_name As String
        Private m_newFileDialogVisible As Boolean
        Private m_properties As ArrayList
        Private m_scripts As ArrayList
        Private m_wizardpath As String

        Public Shared FileTemplates As ArrayList

#End Region

#Region "Constructors"
        Shared Sub New()
            FileTemplate.FileTemplates = New ArrayList
            Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

            Dim pathArray As Object() = New Object() {myPropertyService.DataDirectory, Path.DirectorySeparatorChar, "templates", Path.DirectorySeparatorChar, "file"}
            Dim templateCollection As StringCollection = myFileUtilityService.SearchDirectory(String.Concat(pathArray), "*.xft")
            For Each fileName As String In templateCollection
                Try
                    If (Path.GetExtension(fileName) = ".xft") Then
                        FileTemplate.LoadFileTemplate(fileName)
                    End If
                Catch ex As Exception
                    myMessageService.ShowError(ex, ("Error loading template file " & fileName & "."))
                End Try
            Next
        End Sub
        Public Sub New(ByVal filename As String)
            Me.m_author = Nothing
            Me.m_name = Nothing
            Me.m_category = Nothing
            Me.m_languagename = Nothing
            Me.m_icon = Nothing
            Me.m_description = Nothing
            Me.m_wizardpath = Nothing
            Me.m_defaultName = Nothing
            Me.m_newFileDialogVisible = True
            Me.m_files = New ArrayList
            Me.m_properties = New ArrayList
            Me.m_scripts = New ArrayList
            Me.m_customTypes = New ArrayList
            Me.m_fileoptions = Nothing
            Dim doc As New XmlDocument
            doc.Load(filename)
            Me.m_author = doc.DocumentElement.GetAttribute("author")
            Dim el As XmlElement = doc.DocumentElement.Item("Config")
            Me.m_name = el.GetAttribute("name")
            Me.m_icon = el.GetAttribute("icon")
            Me.m_category = el.GetAttribute("category")
            Me.m_defaultName = el.GetAttribute("defaultname")
            Me.m_languagename = el.GetAttribute("language")
            Dim newfiledialogvisibleString As String = el.GetAttribute("newfiledialogvisible")
            If (((Not newfiledialogvisibleString Is Nothing) AndAlso (newfiledialogvisibleString.Length <> 0)) AndAlso (newfiledialogvisibleString.ToLower = "false")) Then
                Me.m_newFileDialogVisible = False
            End If
            If (Not doc.DocumentElement.Item("Description") Is Nothing) Then
                Me.m_description = doc.DocumentElement.Item("Description").InnerText
            End If
            If (Not el.Item("Wizard") Is Nothing) Then
                Me.m_wizardpath = el.Item("Wizard").Attributes.ItemOf("path").InnerText
            End If
            If (Not doc.DocumentElement.Item("Properties") Is Nothing) Then
                Dim propertiesList As XmlNodeList = doc.DocumentElement.Item("Properties").SelectNodes("Property")
                For Each element As XmlElement In propertiesList
                    Me.m_properties.Add(New TemplateProperty(element))
                Next
            End If
            If (Not doc.DocumentElement.Item("Types") Is Nothing) Then
                Dim typesList As XmlNodeList = doc.DocumentElement.Item("Types").SelectNodes("Type")
                For Each element As XmlElement In typesList
                    Me.m_customTypes.Add(New TemplateType(element))
                Next
            End If
            Me.m_fileoptions = doc.DocumentElement.Item("AdditionalOptions")
            Dim elFiles As XmlElement = doc.DocumentElement.Item("Files")
            For Each element As XmlElement In elFiles.ChildNodes
                Dim mFileDescriptionTemplate As New FileDescriptionTemplate(element.GetAttribute("name"), element.GetAttribute("language"), element.InnerText)
                Me.m_files.Add(mFileDescriptionTemplate)
            Next
            Dim scriptList As XmlNodeList = doc.DocumentElement.SelectNodes("Script")
            For Each element As XmlElement In scriptList
                Me.m_scripts.Add(New TemplateScript(element))
            Next
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Author() As String
            Get
                Return Me.m_author
            End Get
        End Property
        Public ReadOnly Property Category() As String
            Get
                Return Me.m_category
            End Get
        End Property
        Public ReadOnly Property CustomTypes() As ArrayList
            Get
                Return Me.m_customTypes
            End Get
        End Property
        Public ReadOnly Property DefaultName() As String
            Get
                Return Me.m_defaultName
            End Get
        End Property
        Public ReadOnly Property Description() As String
            Get
                Return Me.m_description
            End Get
        End Property
        Public ReadOnly Property FileDescriptionTemplates() As ArrayList
            Get
                Return Me.m_files
            End Get
        End Property
        Public ReadOnly Property Fileoptions() As XmlElement
            Get
                Return Me.m_fileoptions
            End Get
        End Property
        Public ReadOnly Property HasProperties() As Boolean
            Get
                If (Not Me.m_properties Is Nothing) Then
                    Return (Me.m_Properties.Count > 0)
                End If
                Return False
            End Get
        End Property
        Public ReadOnly Property HasScripts() As Boolean
            Get
                If (Not Me.m_scripts Is Nothing) Then
                    Return (Me.m_scripts.Count > 0)
                End If
                Return False
            End Get
        End Property
        Public ReadOnly Property Icon() As String
            Get
                Return Me.m_icon
            End Get
        End Property
        Public ReadOnly Property LanguageName() As String
            Get
                Return Me.m_languagename
            End Get
        End Property
        Public ReadOnly Property Name() As String
            Get
                Return Me.m_name
            End Get
        End Property
        Public ReadOnly Property NewFileDialogVisible() As Boolean
            Get
                Return Me.m_newFileDialogVisible
            End Get
        End Property
        Public ReadOnly Property Properties() As ArrayList
            Get
                Return Me.m_properties
            End Get
        End Property
        Public ReadOnly Property Scripts() As ArrayList
            Get
                Return Me.m_scripts
            End Get
        End Property
        Public ReadOnly Property WizardPath() As String
            Get
                Return Me.m_wizardpath
            End Get
        End Property
#End Region

#Region "Methods"
        Private Shared Sub LoadFileTemplate(ByVal filename As String)
            FileTemplate.FileTemplates.Add(New FileTemplate(filename))
        End Sub
#End Region

    End Class
End Namespace




