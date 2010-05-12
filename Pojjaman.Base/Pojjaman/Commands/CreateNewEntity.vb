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
  Public Class CreateNewEntity
    Inherits AbstractEntityAccessCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Public Overrides Sub Run()
      If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty Then
        Dim resourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
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
      Dim panel As ISimpleListPanel = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel)
      panel.AddNew()
    End Sub
    Public Overrides Property IsEnabled() As Boolean
      Get
        If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
          Return MyBase.IsEnabled
        End If
        If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing Then
          Return MyBase.IsEnabled
        End If
        'If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SubViewContents Is Nothing OrElse WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SubViewContents.Count = 1 Then
        '    Return False
        'End If
        If Not TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is ISimpleListPanel Then
          Return MyBase.IsEnabled
        Else
          Dim panel As ISimpleListPanel = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel)
          If TypeOf panel.Entity Is Report Then
            Return False
          End If
        End If
        Return MyBase.IsEnabledWithChecking
      End Get
      Set(ByVal Value As Boolean)
        MyBase.IsEnabled = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ValidLevel() As Integer
      Get
        Return 2
      End Get
    End Property
#End Region


  End Class
End Namespace
