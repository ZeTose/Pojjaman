Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class SideBarRenameTabHeader
        Inherits AbstractMenuCommand

#Region "Costructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim bar1 As PojjamanSideBar = CType(Me.Owner, PojjamanSideBar)
            bar1.StartRenamingOf(bar1.GetTabAt(bar1.SideBarMousePosition.X, bar1.SideBarMousePosition.Y))
        End Sub
#End Region

    End Class
End Namespace
