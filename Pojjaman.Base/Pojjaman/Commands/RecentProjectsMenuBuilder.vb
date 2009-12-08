Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports System.Text
Namespace Longkong.Pojjaman.Commands
    Public Class RecentProjectsMenuBuilder
        Implements ISubmenuBuilder

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Private Sub LoadRecentProject(ByVal sender As Object, ByVal e As EventArgs)
            'Dim cmd As PJMMenuCommand = CType(sender, PJMMenuCommand)
            'Dim myIProjectService As IProjectService = CType(ServiceManager.Services.GetService(GetType(IProjectService)), IProjectService)
            'Dim fileName As String = cmd.Tag.ToString
            'Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            'myFileUtilityService.ObservedLoad(New NamedFileOperationDelegate(AddressOf myIProjectService.OpenCombine), fileName)
        End Sub
#End Region

#Region "ISubmenuBuilder"
        Public Function BuildSubmenu(ByVal conditionCollection As Core.AddIns.Conditions.ConditionCollection, ByVal owner As Object) As System.Windows.Forms.CommandBarItem() Implements Core.AddIns.Codons.ISubmenuBuilder.BuildSubmenu
            Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim myRecentOpen As RecentOpen = myFileService.RecentOpen
            If (myRecentOpen.RecentProject.Count > 0) Then
                Dim commandArray1 As PJMMenuCommand() = New PJMMenuCommand(myRecentOpen.RecentProject.Count - 1) {}
                For i As Integer = 0 To myRecentOpen.RecentProject.Count - 1
                    Dim builder1 As New StringBuilder("")
                    If (i < 10) Then
                        builder1.Append("&")
                        Dim index As Integer = ((i + 1) Mod 10)
                        builder1.Append(index.ToString)
                        builder1.Append(" ")
                    End If
                    builder1.Append(myRecentOpen.RecentProject.Item(i).ToString)
                    commandArray1(i) = New PJMMenuCommand(Nothing, Nothing, builder1.ToString, New EventHandler(AddressOf Me.LoadRecentProject))
                    commandArray1(i).Tag = myRecentOpen.RecentProject.Item(i).ToString
                    Dim textArray1(,) As String = New String(1 - 1, 2 - 1) {}
                    textArray1(0, 0) = "PROJECT"
                    textArray1(0, 1) = myRecentOpen.RecentProject.Item(i).ToString
                    commandArray1(i).Description = myStringParserService.Parse(myResourceService.GetString("Dialog.Componnents.RichMenuItem.LoadProjectDescription"), textArray1)
                Next
                Return commandArray1
            End If
            Dim cmd As New PJMMenuCommand(Nothing, Nothing, myResourceService.GetString("Dialog.Componnents.RichMenuItem.NoRecentProjectsString"))
            cmd.IsEnabled = False
            Return New PJMMenuCommand() {cmd}
        End Function
#End Region

    End Class
End Namespace
