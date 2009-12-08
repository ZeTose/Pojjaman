Imports Longkong.Core.AddIns
Imports Longkong.Pojjaman.Gui.Panels
Namespace Longkong.Pojjaman.Gui
    Public Delegate Sub ViewContentEventHandler(ByVal sender As Object, ByVal e As ViewContentEventArgs)
    Public Interface IWorkbench
        Inherits IMementoCapable

        ' Events
        Event ActiveWorkbenchWindowChanged As EventHandler
        Event ViewClosed As ViewContentEventHandler
        Event ViewOpened As ViewContentEventHandler
        ' Methods
        Sub CloseAllViews()
        Sub CloseContent(ByVal content As IViewContent)
        Function GetPad(ByVal type As Type) As IPadContent
        Function GetPad(ByVal entityName As String) As IPadContent


        Function GetView(ByVal type As Type) As IViewContent
        Function GetView(ByVal entity As BusinessLogic.ISimpleEntity) As IViewContent
        Function GetView(ByVal entityName As String) As IViewContent
        Sub RedrawAllComponents()
        Sub RedrawEditComponents()
        Sub ShowPad(ByVal content As IPadContent)
        Sub ShowPad(ByVal content As IPadContent, ByVal rect As Rectangle)
        Sub ShowView(ByVal content As IViewContent)

        ' Properties
        ReadOnly Property CommandBarManager() As CommandBarManager
        ReadOnly Property ActiveWorkbenchWindow() As IWorkbenchWindow
        ReadOnly Property PadContentCollection() As PadContentCollection
        Property Title() As String
        Property ApplicationMode() As ApplicationMode
        Property MultiMode() As Boolean
        ReadOnly Property ViewContentCollection() As ViewContentCollection
        Property WorkbenchLayout() As IWorkbenchLayout
    End Interface
End Namespace



