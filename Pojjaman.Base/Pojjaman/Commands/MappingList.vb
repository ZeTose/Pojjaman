Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.BusinessLogic
Imports System.IO
Namespace Longkong.Pojjaman.Commands
    Public Class MappingList
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
            If TypeOf window.ActiveViewContent Is Longkong.Pojjaman.Gui.Panels.ISimpleEntityPanel Then
                If TypeOf CType(window.ActiveViewContent, ISimpleEntityPanel).Entity Is ISimpleEntity Then
                    Dim pnl As New MappingListDialog
                    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(pnl)
                    myDialog.ShowInTaskbar = True
                    myDialog.Show()
                End If
            End If
        End Sub
#End Region

    End Class
End Namespace
