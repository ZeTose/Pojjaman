Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class SelectPrevTab
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            If (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SubViewContents Is Nothing) Then
                Dim index As Integer = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SubViewContents.IndexOf(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent)
                WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SwitchView(((index + WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SubViewContents.Count) - 1) Mod WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SubViewContents.Count)
            End If
        End Sub
#End Region

    End Class
End Namespace
