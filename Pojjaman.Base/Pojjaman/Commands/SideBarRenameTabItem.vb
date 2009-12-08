Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class SideBarRenameTabItem
        Inherits AbstractMenuCommand

#Region "Costructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim bar1 As PojjamanSideBar = CType(Me.Owner, PojjamanSideBar)
            Dim item1 As VSSideTabItem = bar1.ActiveTab.ChoosedItem
            If (Not item1 Is Nothing) Then
                bar1.StartRenamingOf(item1)
            End If
        End Sub
#End Region

    End Class
End Namespace
