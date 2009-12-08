Namespace Longkong.Pojjaman.Gui
    Public Interface IWorkbenchWindow
        ' Events
        Event CloseEvent As EventHandler
        Event TitleChanged As EventHandler
        Event WindowDeselected As EventHandler
        Event WindowSelected As EventHandler

        ' Methods
        Sub AttachSecondaryViewContent(ByVal secondaryViewContent As ISecondaryViewContent)
        Function CloseWindow(ByVal force As Boolean) As Boolean
        Sub OnWindowDeselected(ByVal e As EventArgs)
        Sub OnWindowSelected(ByVal e As EventArgs)
        Sub RedrawContent()
        Sub SelectWindow()
        Sub SwitchView(ByVal viewNumber As Integer)

        ' Properties
        ReadOnly Property ActiveViewContent() As IBaseViewContent
        ReadOnly Property SubViewContents() As ArrayList
        Property Title() As String
        Property ViewContent() As IViewContent
    End Interface
End Namespace


