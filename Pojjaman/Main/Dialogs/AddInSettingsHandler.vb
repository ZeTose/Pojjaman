Imports System.Configuration
Imports System.Xml
Imports Longkong.Core
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Properties
Imports System.Threading
Namespace Pojjaman
    Public Class AddInSettingsHandler
        Implements IConfigurationSectionHandler

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"

#End Region

#Region "IConfigurationSectionHandler"
        Public Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal section As System.Xml.XmlNode) As Object Implements System.Configuration.IConfigurationSectionHandler.Create
            Dim addInDirectories As New ArrayList
            Dim attr As XmlNode = section.Attributes.GetNamedItem("ignoreDefaultPath")
            If (Not attr Is Nothing) Then
                Try
                    addInDirectories.Add(Convert.ToBoolean(attr.Value))
                Catch ex As InvalidCastException
                    addInDirectories.Add(False)
                End Try
            Else
                addInDirectories.Add(False)
            End If
            Dim addInDirList As XmlNodeList = section.SelectNodes("AddInDirectory")
            For Each addInDir As XmlNode In addInDirList
                Dim path As XmlNode = addInDir.Attributes.GetNamedItem("path")
                If (Not path Is Nothing) Then
                    addInDirectories.Add(path.Value)
                End If
            Next
            Return addInDirectories
        End Function
        Public Shared Function GetAddInDirectories(ByRef ignoreDefaultPath As Boolean) As String()
            Dim addInDirs As ArrayList = CType(ConfigurationSettings.GetConfig("AddInDirectories"), ArrayList)
            If (Not addInDirs Is Nothing) Then
                Dim count As Integer = addInDirs.Count
                If (count <= 1) Then
                    ignoreDefaultPath = False
                    Return Nothing
                End If
                ignoreDefaultPath = CType(addInDirs(0), Boolean)
                Dim directories As String() = New String(count - 1) {}
                For i As Integer = 0 To (count - 1) - 1
                    directories(i) = CType(addInDirs(i + 1), String)
                Next
                Return directories
            End If
            ignoreDefaultPath = False
            Return Nothing
        End Function
#End Region
    End Class
End Namespace
