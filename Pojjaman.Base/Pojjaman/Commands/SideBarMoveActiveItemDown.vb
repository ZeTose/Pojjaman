Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class SideBarMoveActiveItemDown
        Inherits AbstractMenuCommand

#Region "Costructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim bar1 As PojjamanSideBar = CType(Me.Owner, PojjamanSideBar)
            Dim num1 As Integer = bar1.ActiveTab.Items.IndexOf(bar1.ActiveTab.SelectedItem)
            If ((num1 >= 0) AndAlso (num1 < (bar1.ActiveTab.Items.Count - 1))) Then
                Dim item1 As VSSideTabItem = bar1.ActiveTab.Items.Item(num1)
                bar1.ActiveTab.Items.Item(num1) = bar1.ActiveTab.Items.Item((num1 + 1))
                bar1.ActiveTab.Items.Item((num1 + 1)) = item1
                bar1.Refresh()
            End If
        End Sub
#End Region

    End Class
End Namespace
