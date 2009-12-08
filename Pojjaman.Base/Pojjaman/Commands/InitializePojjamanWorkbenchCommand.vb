Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Commands
    Public Class InitializePojjamanWorkbenchCommand
        Inherits AbstractCommand

#Region "Members"
        Private Const WorkbenchMemento As String = "Pojjaman.Workbench.WorkbenchMemento"
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim myWorkBench As New PojjamanWorkbench
            WorkbenchSingleton.Workbench = myWorkBench
            myWorkBench.InitializeWorkspace()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            myWorkBench.SetMemento(CType(myPropertyService.GetProperty(WorkbenchMemento, New WorkbenchMemento), IXmlConvertable))
            myWorkBench.UpdatePadContents(Nothing, Nothing)
            WorkbenchSingleton.CreateWorkspace()
        End Sub
#End Region

    End Class
End Namespace
