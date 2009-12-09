Namespace Longkong.Pojjaman.Gui
    Public Interface IWorkbenchLayout
        ' Events
        Event ActiveWorkbenchWindowChanged As EventHandler

        ' Methods
        Sub Attach(ByVal workbench As IWorkbench)
        Sub Detach()
        Sub OnActiveWorkbenchWindowChanged(ByVal e As EventArgs)
        Function ShowView(ByVal content As IViewContent) As IWorkbenchWindow

        ' Properties
        ReadOnly Property ActiveWorkbenchwindow() As IWorkbenchWindow
    End Interface
End Namespace



