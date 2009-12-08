Namespace Longkong.Pojjaman.Gui
    Public Interface IWorkbenchLayout
        ' Events
        Event ActiveWorkbenchWindowChanged As EventHandler

        ' Methods
        Sub ActivatePad(ByVal content As IPadContent)
        Sub ActivatePad(ByVal content As IPadContent, ByVal rect As Rectangle)
        Sub Attach(ByVal workbench As IWorkbench)
        Sub Detach()
        Sub HidePad(ByVal content As IPadContent)
        Sub ClosePad(ByVal content As IPadContent)
        Function IsVisible(ByVal padContent As IPadContent) As Boolean
        Sub OnActiveWorkbenchWindowChanged(ByVal e As EventArgs)
        Sub RedrawAllComponents()
        Sub ShowPad(ByVal content As IPadContent)
        Sub ShowPad(ByVal content As IPadContent, ByVal rect As Rectangle)
        Function ShowView(ByVal content As IViewContent) As IWorkbenchWindow

        ' Properties
        ReadOnly Property ActiveWorkbenchwindow() As IWorkbenchWindow
    End Interface
End Namespace



