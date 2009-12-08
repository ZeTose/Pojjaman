Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports System.IO
Namespace Longkong.Pojjaman.Commands
    Public Class ShowFlow
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim fileUtlityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            Dim objArray1 As Object() = New Object() {fileUtlityService.PojjamanRootPath, Path.DirectorySeparatorChar, "doc", Path.DirectorySeparatorChar, "flow", Path.DirectorySeparatorChar, "flow.htm"}
            Dim fileName As String = String.Concat(objArray1)
            If fileUtlityService.TestFileExists(fileName) Then
                Help.ShowHelp(CType(WorkbenchSingleton.Workbench, Form), fileName)
                CType(WorkbenchSingleton.Workbench, Form).Select()
            End If
        End Sub
#End Region

    End Class
End Namespace
