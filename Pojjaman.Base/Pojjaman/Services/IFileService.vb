Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Services
    Public Delegate Sub FileEventHandler(ByVal sender As Object, ByVal e As FileEventArgs)
    Public Interface IFileService
        ' Events
        Event FileRemoved As FileEventHandler
        Event FileRenamed As FileEventHandler

        ' Methods
        Function GetOpenFile(ByVal fileName As String) As IWorkbenchWindow
        Function IsOpen(ByVal fileName As String) As Boolean
        Sub JumpToFilePosition(ByVal fileName As String, ByVal line As Integer, ByVal column As Integer)
        Sub NewFile(ByVal defaultName As String, ByVal language As String, ByVal content As String)
        Sub OpenFile(ByVal fileName As String)
        Sub RemoveFile(ByVal fileName As String)
        Sub RenameFile(ByVal oldName As String, ByVal newName As String)

        ' Properties
        ReadOnly Property RecentOpen() As RecentOpen
    End Interface
End Namespace



