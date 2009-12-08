Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class SideBarDeleteTabHeader
        Inherits AbstractMenuCommand

#Region "Costructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim bar1 As PojjamanSideBar = CType(Me.Owner, PojjamanSideBar)
            Dim tab1 As VSSideTab = bar1.GetTabAt(bar1.SideBarMousePosition.X, bar1.SideBarMousePosition.Y)
            Dim service1 As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Dim service2 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim textArray1(,) As String = New String(1 - 1, 2 - 1) {}
            textArray1(0, 0) = "TabHeader"
            textArray1(0, 1) = tab1.Name
            If (MessageBox.Show(service2.Parse(service1.GetString("SideBarComponent.ContextMenu.DeleteTabHeaderQuestion"), textArray1), service1.GetString("Global.QuestionText"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                bar1.Tabs.Remove(tab1)
                bar1.Refresh()
            End If
        End Sub
#End Region

    End Class
End Namespace
