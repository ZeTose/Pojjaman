Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Commands
  Public Class LogOff
    Inherits AbstractMenuCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Public Overrides Sub Run()
      WorkbenchSingleton.Workbench.CloseAllViews()
      Dim mySecurityService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      mySecurityService.LogOff()
      mySecurityService.OpenStartUpPage()
      WorkbenchSingleton.Workbench.RedrawAllComponents()
    End Sub
#End Region

  End Class
End Namespace
