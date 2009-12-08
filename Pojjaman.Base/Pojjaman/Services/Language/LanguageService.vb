Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections
Imports System.Threading
Imports System.Resources
Imports System.Drawing
Imports System.Diagnostics
Imports System.Reflection
Imports System.Xml
Imports System.Configuration
Imports System.Globalization
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Services
    Public Class LanguageService
        Inherits AbstractService

#Region "Members"
        Private m_languageImageList As ImageList
        Private m_languagePath As String
        Private m_languages As ArrayList
#End Region

#Region "Costructors"
        Public Sub New()
            Me.m_languageImageList = Nothing
            Me.m_languages = Nothing
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim mylanguagePath As Object() = New Object() {myPropertyService.DataDirectory, Path.DirectorySeparatorChar, "resources", Path.DirectorySeparatorChar, "languages", Path.DirectorySeparatorChar}
            Me.m_languagePath = String.Concat(mylanguagePath)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property LanguageImageList() As ImageList
            Get
                If (Me.m_languageImageList Is Nothing) Then
                    Me.LoadLanguageDefinitions()
                End If
                Return Me.m_languageImageList
            End Get
        End Property
        Public ReadOnly Property Languages() As ArrayList
            Get
                If (Me.m_languages Is Nothing) Then
                    Me.LoadLanguageDefinitions()
                End If
                Return Me.m_languages
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub LoadLanguageDefinitions()
            Me.m_languageImageList = New ImageList
            Me.m_languageImageList.ColorDepth = ColorDepth.Depth32Bit
            Me.m_languages = New ArrayList
            Me.m_languageImageList.ImageSize = New Size(46, 38)
            Dim doc As New XmlDocument
            doc.Load((Me.m_languagePath & "LanguageDefinition.xml"))
            For Each node As XmlNode In doc.DocumentElement.ChildNodes
                Dim el As XmlElement
                Try
                    el = CType(node, XmlElement)
                    If (Not el Is Nothing) Then
                        Me.m_languages.Add(New Language(el.Attributes("name").InnerText, el.Attributes("code").InnerText, Me.m_languageImageList.Images.Count))
                        Me.m_languageImageList.Images.Add(New Bitmap((Me.m_languagePath & el.Attributes("icon").InnerText)))
                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
            Next
        End Sub
#End Region

    End Class
End Namespace

