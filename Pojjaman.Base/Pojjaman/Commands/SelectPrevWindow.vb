Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class SelectPrevWindow
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            If (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing) Then
                Dim index As Integer = WorkbenchSingleton.Workbench.ViewContentCollection.IndexOf(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent)
                WorkbenchSingleton.Workbench.ViewContentCollection.Item((((index + WorkbenchSingleton.Workbench.ViewContentCollection.Count) - 1) Mod WorkbenchSingleton.Workbench.ViewContentCollection.Count)).WorkbenchWindow.SelectWindow()
            End If
        End Sub
#End Region

    End Class
End Namespace
