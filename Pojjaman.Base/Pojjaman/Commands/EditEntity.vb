Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.PanelDisplayBinding
Namespace Longkong.Pojjaman.Commands
    Public Class EditEntity
        Inherits AbstractEntityMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
    Property Args As String
    Property Label As String
    Public Overrides Sub Run()
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If Not Me.Entity Is Nothing Then
        myEntityPanelService.OpenPanel(Me.Entity, Me.Args, Me.Label)
      End If
    End Sub
#End Region

  End Class

  Public Class CreateNewEntityFromMenu
    Inherits AbstractEntityMenuCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Property Args As String
    Property Label As String
    Public Overrides Sub Run()
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If Not Me.Entity Is Nothing Then
        myEntityPanelService.OpenPanel(Me.Entity, Me.Args, Me.Label)
        Dim panel As ISimpleListPanel = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel)
        panel.AddNew()
      End If
    End Sub
#End Region

    Public Overrides ReadOnly Property ValidLevel As Integer
      Get
        Return 2
      End Get
    End Property
  End Class

  Public Class MoveToNextEntity
    Inherits AbstractEntityAccessCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Public Overrides Sub Run()
      If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty Then
        Dim resourceService As resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), resourceService)
        Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.TitleName + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        Select Case dr
          Case DialogResult.Yes
            Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
            myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.Save), CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity)
          Case DialogResult.No
            WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty = False
          Case DialogResult.Cancel
            Return
        End Select
      End If
      If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is ICanMove Then
        Dim panel As ICanMove = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ICanMove)
        panel.MoveNext()
      End If
    End Sub
    Public Overrides Property IsEnabled() As Boolean
      Get
        If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
          Return MyBase.IsEnabled
        End If
        If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing Then
          Return MyBase.IsEnabled
        End If
        If Not TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is ICanMove Then
          Return MyBase.IsEnabled
        Else
          Dim panel As ICanMove = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ICanMove)
          Return panel.CanMoveNext And MyBase.IsEnabledWithChecking
        End If
        Return MyBase.IsEnabledWithChecking
      End Get
      Set(ByVal Value As Boolean)
        MyBase.IsEnabled = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ValidLevel() As Integer
      Get
        Return 1
      End Get
    End Property
#End Region


  End Class
  Public Class MoveToPreviousEntity
    Inherits AbstractEntityAccessCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Public Overrides Sub Run()
      If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty Then
        Dim resourceService As resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), resourceService)
        Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.TitleName + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        Select Case dr
          Case DialogResult.Yes
            Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
            myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.Save), CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity)
          Case DialogResult.No
            WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty = False
          Case DialogResult.Cancel
            Return
        End Select
      End If
      If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is ICanMove Then
        Dim panel As ICanMove = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ICanMove)
        panel.MovePrevious()
      End If
    End Sub
    Public Overrides Property IsEnabled() As Boolean
      Get
        If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
          Return MyBase.IsEnabled
        End If
        If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing Then
          Return MyBase.IsEnabled
        End If
        If Not TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is ICanMove Then
          Return MyBase.IsEnabled
        Else
          Dim panel As ICanMove = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ICanMove)
          Return panel.CanMovePrevious And MyBase.IsEnabledWithChecking
        End If
        Return MyBase.IsEnabledWithChecking
      End Get
      Set(ByVal Value As Boolean)
        MyBase.IsEnabled = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ValidLevel() As Integer
      Get
        Return 1
      End Get
    End Property
#End Region


  End Class
End Namespace
