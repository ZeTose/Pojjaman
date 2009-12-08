Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Commands
    Public Class ExitWorkbenchCommand
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim frm As Form = CType(WorkbenchSingleton.Workbench, Form)
            frm.Close()
            Application.Exit()
        End Sub
#End Region

    End Class
End Namespace
