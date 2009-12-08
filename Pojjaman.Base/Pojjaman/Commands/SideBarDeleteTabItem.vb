Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class SideBarDeleteTabItem
        Inherits AbstractMenuCommand

#Region "Costructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim bar1 As PojjamanSideBar = CType(Me.Owner, PojjamanSideBar)
            Dim item1 As VSSideTabItem = bar1.ActiveTab.ChoosedItem
            Dim service1 As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Dim service2 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            If (Not item1 Is Nothing) Then
                Dim textArray1(,) As String = New String(1 - 1, 2 - 1) {}
                textArray1(0, 0) = "TabItem"
                textArray1(0, 1) = item1.Name
                If (MessageBox.Show(service2.Parse(service1.GetString("SideBarComponent.ContextMenu.DeleteTabItemQuestion"), textArray1), service1.GetString("Global.QuestionText"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                    bar1.ActiveTab.Items.Remove(item1)
                    bar1.Refresh()
                End If
            End If

        End Sub
#End Region

    End Class
End Namespace
