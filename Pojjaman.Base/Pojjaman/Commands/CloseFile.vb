Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Commands
    Public Class CloseFile
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            If (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing) Then
                WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.CloseWindow(False)
            End If
        End Sub
#End Region

    End Class
End Namespace
