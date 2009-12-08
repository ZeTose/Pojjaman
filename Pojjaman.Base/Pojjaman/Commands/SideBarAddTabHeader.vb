Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class SideBarAddTabHeader
        Inherits AbstractMenuCommand

#Region "Costructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim bar1 As PojjamanSideBar = CType(Me.Owner, PojjamanSideBar)
            Dim tab1 As New VSSideTab(bar1, "New Tab")
            bar1.Tabs.Add(tab1)
            bar1.StartRenamingOf(tab1)
            bar1.DoAddTab = True
            bar1.Refresh()
        End Sub
#End Region

    End Class
End Namespace
