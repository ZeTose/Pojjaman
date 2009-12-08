Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Gui

Namespace Longkong.Pojjaman.Commands
    Public Class CreateNewFile
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim myNewFileDialog As New NewFileDialog(Nothing)
            myNewFileDialog.Owner = CType(WorkbenchSingleton.Workbench, Form)
            myNewFileDialog.ShowDialog()
            If (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing) Then
                WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SelectWindow()
            End If
        End Sub
#End Region

    End Class
End Namespace
