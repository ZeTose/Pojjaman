Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Internal.Parser
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Panels.BusinessForms
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Services
    Public Class DefaultEntityPanelService
        Inherits AbstractService
        Implements IEntityPanelService

#Region "Members"
        Private m_currentFile As String
        Private m_entityUtilityService As EntityUtilityService
        Private m_recentOpen As RecentOpen
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_recentOpen = Nothing
            Me.m_entityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
        End Sub
#End Region

#Region "Methods"

#End Region

#Region "IEntityPanelService"
        Public Function GetOpenPanel(ByVal entity As ISimpleEntity) As Gui.IWorkbenchWindow Implements IEntityPanelService.GetOpenPanel
            Dim view As IViewContent = WorkbenchSingleton.Workbench.GetView(entity)
            If Not view Is Nothing Then
                Return view.WorkbenchWindow
            End If
        End Function
        Public Function IsOpen(ByVal entity As ISimpleEntity) As Boolean Implements IEntityPanelService.IsOpen
            If Not WorkbenchSingleton.Workbench.GetView(entity) Is Nothing Then
                Return True
            End If
        End Function

#Region "Get Filter Panel"
        Public Function GetReportFilterSubPanel(ByVal entity As BusinessLogic.ISimpleEntity) As Gui.Panels.IReportFilterSubPanel Implements IEntityPanelService.GetReportFilterSubPanel
            Dim addInTreePath As String = "/Pojjaman/Workbench/EntityFilterPanels"
            Dim o As Object = AddInTreeSingleton.AddInTree.GetTreeNode(addInTreePath).BuildChildItem(entity.ClassName.ToLower, Nothing)
            If o Is Nothing Then
                'Undone
                Return Nothing
            End If
            Return CType(o, Gui.Panels.IReportFilterSubPanel)
        End Function
        Public Overloads Function GetFilterSubPanel(ByVal entity As BusinessLogic.ISimpleEntity, ByVal entities As System.Collections.ArrayList) As Gui.Panels.IFilterSubPanel Implements IEntityPanelService.GetFilterSubPanel
            Dim addInTreePath As String = "/Pojjaman/Workbench/EntityFilterPanels"
            Dim o As Object = AddInTreeSingleton.AddInTree.GetTreeNode(addInTreePath).BuildChildItem(entity.ClassName.ToLower, Nothing)
            If o Is Nothing Then
                Return New Gui.Panels.DefaultFilterSubPanel
            End If
            CType(o, Gui.Panels.IFilterSubPanel).Entities = entities
            Return CType(o, Gui.Panels.IFilterSubPanel)
        End Function
        Public Overloads Function GetFilterSubPanel(ByVal entity As BusinessLogic.ISimpleEntity) As Gui.Panels.IFilterSubPanel Implements IEntityPanelService.GetFilterSubPanel
            Dim addInTreePath As String = "/Pojjaman/Workbench/EntityFilterPanels"
            Dim tn As IAddInTreeNode = AddInTreeSingleton.AddInTree.GetTreeNode(addInTreePath)
            Dim o As Object = tn.BuildChildItem(entity.ClassName.ToLower, Nothing)
            If o Is Nothing Then
                Return New Gui.Panels.DefaultFilterSubPanel
            End If
            Return CType(o, Gui.Panels.IFilterSubPanel)
        End Function
#End Region

#Region "Get Tabs"
        Public Function GetTabsForEntity(ByVal entity As BusinessLogic.ISimpleEntity) As Gui.SecondaryViewContentCollection Implements IEntityPanelService.GetTabsForEntity
            Dim addInTreePath As String = "/Pojjaman/Workbench/EntityTabs"
            Dim o As Object = AddInTreeSingleton.AddInTree.GetTreeNode(addInTreePath).BuildChildItem(entity.CodonName.ToLower, Nothing)
            Dim tabs As SecondaryViewContentCollection = CType(o, SecondaryViewContentCollection)
            Return tabs
        End Function
#End Region

#Region "Get PreAddView"
        Public Function GetPreAddViewForEntity(ByVal entity As BusinessLogic.ISimpleEntity) As UserControl Implements IEntityPanelService.GetPreAddViewForEntity
            If entity.ClassName.ToLower = "outgoingcheck" Then
                'HACK!!!
                Dim useRegistration As Boolean = CBool(Configuration.GetConfig("UseCheckRegistration"))
                If Not useRegistration Then
                    Return Nothing
                End If
            End If
            Dim addInTreePath As String = "/Pojjaman/Workbench/PreAddViews"
            Dim theNode As IAddInTreeNode = AddInTreeSingleton.AddInTree.GetTreeNode(addInTreePath)
            Dim o As Object = theNode.BuildChildItem(entity.ClassName.ToLower, Nothing)
            Return CType(o, UserControl)
        End Function
#End Region

#Region "GetView"
        Private Function GetView(ByVal entity As BusinessLogic.ISimpleEntity _
        , ByVal handler As Core.Services.NamedEntityOperationDelegate _
        , ByVal filters() As BusinessLogic.Filter _
        , ByVal entities As System.Collections.ArrayList _
        , Optional ByVal isPanel As Boolean = False) As Object

            If TypeOf entity Is INewReport Then
                Return New GridReportPanelView(entity, handler, New BasketDialog, filters, entities)
            ElseIf TypeOf entity Is Report Then
                Return New ReportPanelView(entity, handler, New BasketDialog, filters, entities)
            End If

            Dim codonName As String = entity.CodonName
            If Not isPanel AndAlso TypeOf entity Is IForceListDialog Then
                codonName = "List"
            End If

            Dim addInTreePath As String = "/Pojjaman/Workbench/EntityListViews"
            Dim tn As IAddInTreeNode = AddInTreeSingleton.AddInTree.GetTreeNode(addInTreePath)
            Dim args As Object = New Object() {entity, handler, New BasketDialog, filters, entities}
            Dim o As Object = tn.BuildChildItem(codonName.ToLower, args)
            If o Is Nothing Then
                Return New ListViewItemSelectionPanelView(entity, handler, New BasketDialog, filters, entities)
            End If
            Return o
        End Function
        Private Function GetView(ByVal entity As BusinessLogic.ISimpleEntity _
        , ByVal handler As Gui.Panels.BasketOperationDelegate _
        , ByVal filters() As BusinessLogic.Filter _
        , ByVal entities As System.Collections.ArrayList _
        , ByVal dlg As BasketDialog _
        , Optional ByVal isPanel As Boolean = False) As Object

            Dim codonName As String = entity.CodonName
            If Not isPanel AndAlso TypeOf entity Is IForceListDialog Then
                codonName = "List"
            End If

            Dim addInTreePath As String = "/Pojjaman/Workbench/EntityListViews"
            Dim tn As IAddInTreeNode = AddInTreeSingleton.AddInTree.GetTreeNode(addInTreePath)
            Dim args As Object = New Object() {entity, handler, New BasketDialog, filters, entities}
            Dim o As Object = tn.BuildChildItem(codonName.ToLower, args)
            If o Is Nothing Then
                Return New ListViewItemSelectionPanelView(entity, handler, dlg, filters, entities)
            End If
            Return o
        End Function
#End Region

#Region "Open Dialog"

#Region "Plain"
        Public Overloads Sub OpenListDialog(ByVal entity As BusinessLogic.ISimpleEntity _
          , ByVal handler As Core.Services.NamedEntityOperationDelegate _
          , ByVal filters() As BusinessLogic.Filter _
          , ByVal entities As System.Collections.ArrayList) Implements IEntityPanelService.OpenListDialog
            Dim view As Object = GetView(entity, handler, filters, entities)
            If Not TypeOf view Is ISimpleListPanel Then
                Return
            End If
            AddHandler CType(view, ISimpleListPanel).EntitySelected, handler
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(CType(view, UserControl))
            myDialog.ShowDialog()
        End Sub
        Public Overloads Sub OpenListDialog(ByVal entity As BusinessLogic.ISimpleEntity _
        , ByVal handler As Core.Services.NamedEntityOperationDelegate _
        , ByVal entities As System.Collections.ArrayList) Implements IEntityPanelService.OpenListDialog
            Dim view As Object = GetView(entity, handler, Nothing, entities)
            OpenListDialog(entity, handler, Nothing, entities)
        End Sub
        Public Overloads Sub OpenListDialog(ByVal entity As BusinessLogic.ISimpleEntity _
        , ByVal handler As Core.Services.NamedEntityOperationDelegate _
        , ByVal filters() As BusinessLogic.Filter) Implements IEntityPanelService.OpenListDialog
            OpenListDialog(entity, handler, filters, Nothing)
        End Sub
        Public Overloads Sub OpenListDialog(ByVal entity As ISimpleEntity _
       , ByVal handler As NamedEntityOperationDelegate) Implements IEntityPanelService.OpenListDialog
            OpenListDialog(entity, handler, Nothing, Nothing)
        End Sub
#End Region

#Region "Basket"
        Public Overloads Sub OpenListDialog(ByVal entity As BusinessLogic.ISimpleEntity _
          , ByVal handler As Gui.Panels.BasketOperationDelegate _
          , ByVal filters() As BusinessLogic.Filter _
          , ByVal entities As ArrayList) Implements IEntityPanelService.OpenListDialog
            Dim dlg As New BasketDialog
            Dim view As Object = GetView(entity, handler, filters, entities, dlg)
            If Not TypeOf view Is UserControl Then
                Return
            End If
            dlg.Lists.Add(view)
            AddHandler dlg.EmptyBasket, handler
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(CType(view, UserControl), dlg)
            myDialog.ShowDialog()
        End Sub
        Public Overloads Sub OpenListDialog(ByVal entity As BusinessLogic.ISimpleEntity _
        , ByVal handler As Gui.Panels.BasketOperationDelegate _
        , ByVal entities As System.Collections.ArrayList) Implements IEntityPanelService.OpenListDialog
            OpenListDialog(entity, handler, Nothing, entities)
        End Sub
        Public Overloads Sub OpenListDialog(ByVal entity As ISimpleEntity _
        , ByVal handler As BasketOperationDelegate) Implements IEntityPanelService.OpenListDialog
            OpenListDialog(entity, handler, Nothing, Nothing)
        End Sub
        Public Overloads Sub OpenListDialog(ByVal entity As BusinessLogic.ISimpleEntity _
        , ByVal handler As Gui.Panels.BasketOperationDelegate _
        , ByVal filters() As BusinessLogic.Filter) Implements IEntityPanelService.OpenListDialog
            OpenListDialog(entity, handler, filters, Nothing)
        End Sub
        Public Overloads Sub OpenListDialog(ByVal entities() As ISimpleEntity _
        , ByVal handler As BasketOperationDelegate _
        , ByVal activeIndex As Integer) Implements IEntityPanelService.OpenListDialog
            Dim dlg As New BasketDialog
            Dim views(entities.Length - 1) As UserControl
            For i As Integer = 0 To entities.Length - 1
                Dim view As Object = GetView(entities(i), handler, Nothing, Nothing, dlg)
                If TypeOf view Is UserControl Then
                    views(i) = CType(view, UserControl)
                End If
                dlg.Lists.Add(views(i))
            Next
            AddHandler dlg.EmptyBasket, handler
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(views, dlg, activeIndex)
            myDialog.ShowDialog()
        End Sub
        Public Overloads Sub OpenListDialog(ByVal entities() As BusinessLogic.ISimpleEntity _
        , ByVal handler As Gui.Panels.BasketOperationDelegate _
        , ByVal filters()() As BusinessLogic.Filter _
        , ByVal filterEntities() As System.Collections.ArrayList _
        , ByVal activeIndex As Integer) Implements IEntityPanelService.OpenListDialog
            Dim dlg As New BasketDialog
            Dim views(entities.Length - 1) As UserControl
            For i As Integer = 0 To entities.Length - 1
                Dim view As Object = GetView(entities(i), handler, filters(i), filterEntities(i), dlg)
                If TypeOf view Is UserControl Then
                    views(i) = CType(view, UserControl)
                End If
                dlg.Lists.Add(views(i))
            Next
            AddHandler dlg.EmptyBasket, handler
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(views, dlg, activeIndex)
            myDialog.ShowDialog()
        End Sub

        Public Overloads Sub OpenListDialog(ByVal entities() As ISimpleEntity _
        , ByVal handler As BasketOperationDelegate) Implements IEntityPanelService.OpenListDialog
            OpenListDialog(entities, handler, -1)
        End Sub
        Public Overloads Sub OpenListDialog(ByVal entities() As BusinessLogic.ISimpleEntity _
        , ByVal handler As Gui.Panels.BasketOperationDelegate _
        , ByVal filters()() As BusinessLogic.Filter _
        , ByVal filterEntities() As System.Collections.ArrayList) Implements IEntityPanelService.OpenListDialog
            OpenListDialog(entities, handler, filters, filterEntities, -1)
        End Sub
#End Region

#Region "Tree Dialog"
        Public Overloads Sub OpenTreeDialog(ByVal entity As TreeBaseEntity, ByVal handler As NamedEntityOperationDelegate) Implements IEntityPanelService.OpenTreeDialog
            OpenTreeDialog(entity, handler, Nothing, Nothing)
        End Sub
        Public Overloads Sub OpenTreeDialog(ByVal entity As BusinessLogic.TreeBaseEntity _
        , ByVal handler As Core.Services.NamedEntityOperationDelegate _
        , ByVal filters() As BusinessLogic.Filter) Implements IEntityPanelService.OpenTreeDialog
            OpenTreeDialog(entity, handler, filters, Nothing)
        End Sub
    Public Overloads Sub OpenTreeDialog(ByVal entity As BusinessLogic.TreeBaseEntity _
    , ByVal handler As Core.Services.NamedEntityOperationDelegate _
    , ByVal filters() As BusinessLogic.Filter _
    , ByVal entities As System.Collections.ArrayList) Implements IEntityPanelService.OpenTreeDialog
      If TypeOf entity Is CostCenter Then
        Dim view As New CostCenterPanelView(entity, handler, Nothing, filters, entities)
        view.CanDrag = False
        view.grbDragging.Visible = False
        AddHandler view.EntitySelected, handler
        Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
        myDialog.ShowDialog()
      Else
        Dim view As New GroupPanelView(entity, handler, Nothing, filters, entities)
        view.CanDrag = False
        view.grbDragging.Visible = False
        AddHandler view.EntitySelected, handler
        Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(view)
        myDialog.ShowDialog()
      End If
    End Sub

    Public Overloads Sub OpenTreeDialog(ByVal entity As TreeBaseEntity _
    , ByVal handler As BasketOperationDelegate) Implements IEntityPanelService.OpenTreeDialog
      OpenTreeDialog(entity, handler, Nothing, Nothing)
    End Sub
    Public Overloads Sub OpenTreeDialog(ByVal entity As TreeBaseEntity _
    , ByVal handler As BasketOperationDelegate _
    , ByVal filters() As BusinessLogic.Filter _
    , ByVal entities As ArrayList) Implements IEntityPanelService.OpenTreeDialog
      If TypeOf entity Is CostCenter Then
        Dim dlg As New BasketDialog
        Dim view As New CostCenterPanelView(entity, handler, dlg, filters, entities)
        view.CanDrag = False
        view.grbDragging.Visible = False
        AddHandler dlg.EmptyBasket, handler
        dlg.Lists.Add(view)
        Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
        myDialog.ShowDialog()
      Else
        Dim dlg As New BasketDialog
        Dim view As New GroupPanelView(entity, handler, dlg, filters, entities)
        view.CanDrag = False
        view.grbDragging.Visible = False
        AddHandler dlg.EmptyBasket, handler
        dlg.Lists.Add(view)
        Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
        myDialog.ShowDialog()
      End If
    End Sub
#End Region

#End Region

#Region "Open Panel"
        Public Overloads Function OpenPanel(ByVal entityName As String) As IWorkbenchWindow Implements IEntityPanelService.OpenPanel
            Return OpenPanel(SimpleBusinessEntityBase.GetEntity(entityName))
        End Function
        Private Sub Dummy(ByVal entity As ISimpleEntity)

        End Sub
        Public Overloads Function OpenPanel(ByVal entity As ISimpleEntity) As IWorkbenchWindow Implements IEntityPanelService.OpenPanel
            If Me.IsOpen(entity) Then
                Dim view As IViewContent = WorkbenchSingleton.Workbench.GetView(entity)
                view.WorkbenchWindow.SelectWindow()
                Return view.WorkbenchWindow
            End If
            Dim myView As Object = GetView(entity, New NamedEntityOperationDelegate(AddressOf Dummy), Nothing, Nothing, True)
            If Not TypeOf myView Is IViewContent Then
                Throw New ApplicationException(String.Format("View created for {0} was empty", entity.TabPageText))
            End If
            Dim myContent As IViewContent = CType(myView, IViewContent)
            If (myContent Is Nothing) Then
                Throw New ApplicationException(String.Format("View created for {0} was empty", entity.TabPageText))
            End If
            myContent.UntitledName = entity.TabPageText
            Me.m_entityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)

            Dim wrapper As New LoadEntityWrapper(myContent)
            Dim neod As New NamedEntityOperationDelegate(AddressOf wrapper.Invoke)

            If Me.m_entityUtilityService.ObservedLoad(neod, entity) = EntityOperationResult.OK Then
                Dim tabs As SecondaryViewContentCollection = GetTabsForEntity(entity)
                If Not tabs Is Nothing AndAlso tabs.Count > 0 Then
                    For Each tab As ISecondaryViewContent In tabs
                        myContent.WorkbenchWindow.AttachSecondaryViewContent(tab)
                    Next
                ElseIf tabs Is Nothing OrElse tabs.Count = 0 Then
                    If TypeOf entity Is TreeBaseEntity Then
                        myContent.WorkbenchWindow.AttachSecondaryViewContent(New GroupDetailView)
                    End If
                End If
                myEntityPanelService.RecentOpen.AddLastEntity(entity)
                Return myContent.WorkbenchWindow
            End If
        End Function
        Public Function OpenDetailPanel(ByVal entity As BusinessLogic.ISimpleEntity) As IWorkbenchWindow Implements IEntityPanelService.OpenDetailPanel
            Dim window As IWorkbenchWindow = OpenPanel(entity)
            If Not window Is Nothing AndAlso Not window.SubViewContents Is Nothing AndAlso window.SubViewContents.Count > 1 Then
                If TypeOf window.SubViewContents(0) Is ListViewItemSelectionPanelView Then
          CType(window.SubViewContents(0), ListViewItemSelectionPanelView).SelectedID = entity.Id
          If window.ActiveViewContent Is window.SubViewContents(1) Then
            CType(window.SubViewContents(0), ListViewItemSelectionPanelView).SelectedEntity = entity
            'CType(window.SubViewContents(0), ListViewItemSelectionPanelView).RefreshSelectedEntity()
            CType(window.SubViewContents(1), IBaseViewContent).Selected()
            CType(window.SubViewContents(0), ListViewItemSelectionPanelView).ChangeTitle(Nothing, Nothing)
          Else
            CType(window.SubViewContents(0), ListViewItemSelectionPanelView).RefreshSelectedEntity()
          End If
                ElseIf TypeOf window.SubViewContents(0) Is GroupPanelView Then
                    CType(window.SubViewContents(0), GroupPanelView).SelectedEntity = entity
                End If
        window.SwitchView(1)
      End If
      Return window
        End Function
#End Region

        Public ReadOnly Property RecentOpen() As RecentOpen Implements IEntityPanelService.RecentOpen
            Get
                If (Me.m_recentOpen Is Nothing) Then
                    Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                    Me.m_recentOpen = CType(myPropertyService.GetProperty("Longkong.Pojjaman.Gui.MainWindow.RecentOpen", New RecentOpen), RecentOpen)
                End If
                Return Me.m_recentOpen
            End Get
        End Property
#End Region

#Region "LoadEntityWrapper"
        Public Class LoadEntityWrapper

#Region "Members"
            Private m_content As IViewContent
#End Region

#Region "Constructors"
            Public Sub New(ByVal content As IViewContent)
                Me.m_content = content
            End Sub
#End Region

#Region "Methods"
            Public Sub Invoke(ByVal entity As ISimpleEntity)
                WorkbenchSingleton.Workbench.ShowView(m_content)
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace



