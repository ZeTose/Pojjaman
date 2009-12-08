Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui
    Public Interface IBaseViewContent
        Inherits IDisposable
        ' Methods
        Sub Deselected()
        Sub RedrawContent()
        Sub Selected()
        Sub SwitchedTo()
        ' Properties
        ReadOnly Property Control() As Control
        ReadOnly Property TabPageText() As String
        ReadOnly Property TabPageIcon() As String
        Property WorkbenchWindow() As IWorkbenchWindow
    End Interface
End Namespace



