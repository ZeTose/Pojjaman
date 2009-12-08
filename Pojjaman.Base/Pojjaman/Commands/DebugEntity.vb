Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports System.IO
Namespace Longkong.Pojjaman.Commands
    Public Class DebugEntity
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
            If TypeOf window.ActiveViewContent Is Longkong.Pojjaman.Gui.Panels.ISimpleEntityPanel Then
                Dim pnl As New EntityDebugPanel(CType(window.ActiveViewContent, ISimpleEntityPanel).Entity)
                Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(pnl)
                myDialog.ShowInTaskbar = True
                myDialog.Show()
            End If
        End Sub
#End Region

    End Class
    Public Class ShowCodeDescription
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim pnl As New CodeDescriptionDialog
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(pnl)
            myDialog.ShowInTaskbar = True
            myDialog.Show()
        End Sub
#End Region

    End Class
End Namespace
