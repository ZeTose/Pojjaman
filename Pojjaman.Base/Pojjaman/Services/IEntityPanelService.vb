Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Services
    Public Delegate Sub PanelEventHandler(ByVal sender As Object, ByVal e As PaneEventArgs)
    Public Interface IEntityPanelService

        ' Methods
        Function GetFilterSubPanel(ByVal entity As ISimpleEntity, ByVal filters() As Filter, ByVal entities As ArrayList) As IFilterSubPanel
        Function GetFilterSubPanel(ByVal entity As ISimpleEntity, ByVal entities As ArrayList) As IFilterSubPanel
        Function GetFilterSubPanel(ByVal entity As ISimpleEntity) As IFilterSubPanel
        Function GetReportFilterSubPanel(ByVal entity As ISimpleEntity) As IReportFilterSubPanel
        Function GetOpenPanel(ByVal entity As ISimpleEntity) As IWorkbenchWindow
        Function GetTabsForEntity(ByVal entity As ISimpleEntity) As SecondaryViewContentCollection
        Function GetPreAddViewForEntity(ByVal entity As ISimpleEntity) As UserControl
        Function IsOpen(ByVal entity As ISimpleEntity) As Boolean
        Function OpenPanel(ByVal entity As ISimpleEntity) As IWorkbenchWindow
    Function OpenPanel(ByVal entityName As String) As IWorkbenchWindow
    Function OpenPanel(ByVal entityName As String, ByVal args As String, ByVal label As String) As IWorkbenchWindow
        Function OpenDetailPanel(ByVal entity As ISimpleEntity) As IWorkbenchWindow


        Sub OpenListDialog(ByVal entity As BusinessLogic.ISimpleEntity, ByVal handler As Gui.Panels.BasketOperationDelegate, ByVal filters() As BusinessLogic.Filter, ByVal entities As ArrayList)
        Sub OpenListDialog(ByVal entity As ISimpleEntity, ByVal handler As NamedEntityOperationDelegate)
        Sub OpenListDialog(ByVal entity As BusinessLogic.ISimpleEntity, ByVal handler As NamedEntityOperationDelegate, ByVal entities As ArrayList)
        Sub OpenListDialog(ByVal entity As ISimpleEntity, ByVal handler As NamedEntityOperationDelegate, ByVal filters() As Filter)
        Sub OpenListDialog(ByVal entity As BusinessLogic.ISimpleEntity, ByVal handler As NamedEntityOperationDelegate, ByVal filters() As BusinessLogic.Filter, ByVal entities As ArrayList)
        Sub OpenListDialog(ByVal entities() As ISimpleEntity, ByVal handler As BasketOperationDelegate, ByVal activeIndex As Integer)
        Sub OpenListDialog(ByVal entities() As ISimpleEntity, ByVal handler As BasketOperationDelegate, ByVal filters()() As BusinessLogic.Filter, ByVal filterEntities() As ArrayList)
        Sub OpenListDialog(ByVal entities() As ISimpleEntity, ByVal handler As BasketOperationDelegate)
        Sub OpenListDialog(ByVal entities() As ISimpleEntity, ByVal handler As BasketOperationDelegate, ByVal filters()() As BusinessLogic.Filter, ByVal filterEntities() As ArrayList, ByVal activeIndex As Integer)
        Sub OpenListDialog(ByVal entity As ISimpleEntity, ByVal handler As BasketOperationDelegate)
        Sub OpenListDialog(ByVal entity As ISimpleEntity, ByVal handler As BasketOperationDelegate, ByVal entities As ArrayList)
        Sub OpenListDialog(ByVal entity As ISimpleEntity, ByVal handler As BasketOperationDelegate, ByVal filters As Filter())
        Sub OpenTreeDialog(ByVal entity As TreeBaseEntity, ByVal handler As NamedEntityOperationDelegate, ByVal filters As Filter(), ByVal entities As ArrayList)
        Sub OpenTreeDialog(ByVal entity As TreeBaseEntity, ByVal handler As NamedEntityOperationDelegate, ByVal filters As Filter())
        Sub OpenTreeDialog(ByVal entity As TreeBaseEntity, ByVal handler As NamedEntityOperationDelegate)
        Sub OpenTreeDialog(ByVal entity As TreeBaseEntity, ByVal handler As BasketOperationDelegate)
        Sub OpenTreeDialog(ByVal entity As TreeBaseEntity, ByVal handler As BasketOperationDelegate, ByVal filters() As BusinessLogic.Filter, ByVal entities As ArrayList)
        ' Properties
        ReadOnly Property RecentOpen() As RecentOpen
    End Interface
End Namespace



