Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class AboutPojjaman
        Inherits AbstractMenuCommand

#Region "Costructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim aboutDialog As New CommonAboutDialog
            aboutDialog.Owner = CType(WorkbenchSingleton.Workbench, Form)
            aboutDialog.ShowDialog()
        End Sub
#End Region

    End Class
End Namespace
