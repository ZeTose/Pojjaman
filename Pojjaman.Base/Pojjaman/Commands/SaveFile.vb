Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports System.IO
Imports Longkong.Pojjaman.BusinessLogic

Namespace Longkong.Pojjaman.Commands
  Public Class SaveAndContitune
    Inherits AbstractMenuCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Public Overrides Sub Run()
      Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
      If ((Not window Is Nothing) AndAlso Not window.ViewContent.IsViewOnly) Then
        If TypeOf window.ViewContent Is Longkong.Pojjaman.Gui.Panels.ISimpleListPanel Then
          Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
          myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf window.ViewContent.Save), CType(window.ViewContent, ISimpleListPanel).SelectedEntity)
          If IsEnabledWithChecking Then
            Dim panel As ISimpleListPanel = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel)
            panel.AddNew()
          End If
        End If
      End If
    End Sub
    Public ReadOnly Property IsEnabledWithChecking() As Boolean
      Get
        Dim panel As ISimpleListPanel = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel)
        If Not panel.Entity Is Nothing Then
          'Dim fcn As String = panel.Entity.Namespace & "." & panel.Entity.CodonName
          'If TypeOf panel.Entity Is TreeBaseEntity Then
          '    fcn = panel.Entity.FullClassName
          'End If
          'Dim accessID As Integer = Longkong.Pojjaman.BusinessLogic.Entity.GetAccessIdFromFullClassName(fcn)
          Dim accessID As Integer = Longkong.Pojjaman.BusinessLogic.Entity.GetAccessIdFromFullClassName(panel.Entity.FullClassNameForSecurity)
          If accessID = 0 Then
            Return False 'MyBase.IsEnabled
          End If
          Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
          Dim level As Integer = secSrv.GetAccess(accessID)
          Dim checkString As String = BinaryHelper.DecToBin(level, 5)
          checkString = BinaryHelper.RevertString(checkString)
          Return CBool(checkString.Substring(2, 1)) And MyBase.IsEnabled
        End If
        Return MyBase.IsEnabled
      End Get
    End Property
#End Region
    
    'Icons.16x16.SaveAndContituneIcon
  End Class
  Public Class SaveFile
    Inherits AbstractMenuCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Public Overrides Sub Run()
      Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
      If ((Not window Is Nothing) AndAlso Not window.ViewContent.IsViewOnly) Then
        If TypeOf window.ViewContent Is Longkong.Pojjaman.Gui.Panels.ISimpleListPanel Then
          Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
          myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf window.ViewContent.Save), CType(window.ViewContent, ISimpleListPanel).SelectedEntity)
          Return
        End If
        If TypeOf window.ViewContent Is Longkong.Pojjaman.Gui.Panels.ISimpleListEditablePanel Then
          Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
          myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf window.ViewContent.Save), CType(window.ViewContent, ISimpleListEditablePanel).Entity)
          Return
        End If
        If Not TypeOf window.ViewContent Is Longkong.Pojjaman.Gui.Panels.IListPanel AndAlso (window.ViewContent.FileName Is Nothing) Then
          Dim saveAsCommand As New SaveFileAs
          saveAsCommand.Run()
        ElseIf Not TypeOf window.ViewContent Is Longkong.Pojjaman.Gui.Panels.IListPanel Then
          Dim attributes As FileAttributes = (FileAttributes.Offline Or (FileAttributes.Directory Or (FileAttributes.System Or FileAttributes.ReadOnly)))
          If (File.Exists(window.ViewContent.FileName) AndAlso ((File.GetAttributes(window.ViewContent.FileName) And attributes) <> CType(0, FileAttributes))) Then
            Dim saveAsCommand As New SaveFileAs
            saveAsCommand.Run()
          Else
            'Dim myProjectService As IProjectService = CType(ServiceManager.Services.GetService(GetType(IProjectService)), IProjectService)
            'myProjectService.MarkFileDirty(window.ViewContent.FileName)
            Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            Dim content As IViewContent = window.ViewContent
            myFileUtilityService.ObservedSave(New FileOperationDelegate(AddressOf content.Save), window.ViewContent.FileName)
          End If
        End If
      End If
    End Sub
#End Region

  End Class
End Namespace
