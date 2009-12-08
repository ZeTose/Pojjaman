Imports System.Xml
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Collections.Specialized
Namespace Longkong.Pojjaman.Internal.Templates
    Public Interface INewFileCreator
        Function IsFilenameAvailable(ByVal fileName As String) As Boolean
        Sub SaveFile(ByVal filename As String, ByVal content As String, ByVal languageName As String, ByVal showFile As Boolean)
    End Interface
End Namespace




