Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class SideBarMoveActiveItemUp
        Inherits AbstractMenuCommand

#Region "Costructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim bar1 As PojjamanSideBar = CType(Me.Owner, PojjamanSideBar)
            Dim num1 As Integer = bar1.Tabs.IndexOf(bar1.ActiveTab)
            If ((num1 >= 0) AndAlso (num1 < (bar1.Tabs.Count - 1))) Then
                Dim tab1 As VSSideTab = bar1.Tabs.Item(num1)
                bar1.Tabs.Item(num1) = bar1.Tabs.Item((num1 + 1))
                bar1.Tabs.Item((num1 + 1)) = tab1
                bar1.Refresh()
            End If

        End Sub
#End Region

    End Class
End Namespace
