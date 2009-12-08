Imports Longkong.Pojjaman.Gui.XmlForms
Imports System.Windows.Forms.Design
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class FolderDialog
        Inherits FolderNameEditor

#Region "Members"
        Private m_path As String
#End Region

#Region "Construcors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Path() As String
            Get
                Return Me.m_path
            End Get
        End Property
#End Region

#Region "Methods"
        Public Function DisplayDialog() As DialogResult
            Return Me.DisplayDialog("Select the directory in which the project will be created.")
        End Function
        Public Function DisplayDialog(ByVal description As String) As DialogResult
            Dim browser As New FolderBrowser
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            browser.Description = myStringParserService.Parse(description)
            Dim result As DialogResult = browser.ShowDialog
            Me.m_path = browser.DirectoryPath
            Return result
        End Function
#End Region

    End Class
End Namespace

