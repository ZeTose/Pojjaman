Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Namespace Longkong.Pojjaman.Gui
    Public Class WorkbenchSingleton

#Region "Members"
        Private Const m_uiIconStyle As String = "IconMenuItem.IconMenuStyle"
        Private Const m_uiLanguageProperty As String = "CoreProperties.UILanguage"
        Private Shared m_workbench As IWorkbench
        Private Const m_workbenchMemento As String = "Pojjaman.Workbench.WorkbenchMemento"
#End Region

#Region "Constructors"
        Shared Sub New()
            WorkbenchSingleton.m_workbench = Nothing
            Dim service1 As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            AddHandler service1.PropertyChanged, New PropertyEventHandler(AddressOf WorkbenchSingleton.TrackPropertyChanges)
        End Sub
#End Region

#Region "Events"
        Private Shared WorkbenchCreated As EventHandler
#End Region

#Region "Properties"
        Public Shared Property Workbench() As IWorkbench
            Get
                Return WorkbenchSingleton.m_workbench
            End Get
            Set(ByVal value As IWorkbench)
                WorkbenchSingleton.m_workbench = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Shared Sub CreateWorkspace()
            WorkbenchSingleton.SetWbLayout()
            WorkbenchSingleton.OnWorkbenchCreated()
            WorkbenchSingleton.m_workbench.RedrawAllComponents()
        End Sub
        Protected Shared Sub OnWorkbenchCreated()
            If (Not WorkbenchSingleton.WorkbenchCreated Is Nothing) Then
                WorkbenchSingleton.WorkbenchCreated.Invoke(Nothing, EventArgs.Empty)
            End If
        End Sub
        Private Shared Sub SetWbLayout()
            'WorkbenchSingleton.m_workbench.WorkbenchLayout = New SdiWorkbenchLayout
            WorkbenchSingleton.m_workbench.WorkbenchLayout = New PojjamanWorkbenchLayout
        End Sub
        Private Shared Sub TrackPropertyChanges(ByVal sender As Object, ByVal e As PropertyEventArgs)
            If (e.OldValue Is e.NewValue) Then
                Return
            End If
            Select Case e.Key
                Case "Longkong.Pojjaman.Gui.VisualStyle", "CoreProperties.UILanguage"
                    If e.Key = "CoreProperties.UILanguage" Then
                        WorkbenchSingleton.m_workbench.RedrawAllComponents()
                    End If
                Case "Pojjaman.ColorList"
                    If Not WorkbenchSingleton.m_workbench.ActiveWorkbenchWindow Is Nothing AndAlso TypeOf WorkbenchSingleton.m_workbench.ActiveWorkbenchWindow.ActiveViewContent Is Longkong.Pojjaman.PanelDisplayBinding.PanelView Then
                        Longkong.Pojjaman.Gui.Components.HeaderAndDataAlignColumn.SetColorList()
                    End If
            End Select
        End Sub
#End Region

    End Class
End Namespace
