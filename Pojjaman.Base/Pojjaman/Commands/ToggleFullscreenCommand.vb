Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class ToggleFullscreenCommand
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            CType(WorkbenchSingleton.Workbench, PojjamanWorkbench).FullScreen = Not CType(WorkbenchSingleton.Workbench, PojjamanWorkbench).FullScreen
        End Sub
#End Region
    End Class
End Namespace
