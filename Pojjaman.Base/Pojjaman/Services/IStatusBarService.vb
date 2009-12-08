Imports System.Drawing
Imports System.Windows.Forms
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Services
    Public Interface IStatusBarService
        ' Methods
        Sub RedrawStatusbar()
        Sub SetCaretPosition(ByVal x As Integer, ByVal y As Integer, ByVal charOffset As Integer)
        Sub SetInsertMode(ByVal insertMode As Boolean)
        Sub SetMessage(ByVal message As String)
        Sub RefreshLanguage()
        Sub SetMessage(ByVal image As Image, ByVal message As String)
        Sub ShowErrorMessage(ByVal message As String)

        ' Properties
        Property CancelEnabled() As Boolean
        ReadOnly Property Control() As Control
        ReadOnly Property ProgressMonitor() As IProgressMonitor
    End Interface
End Namespace

