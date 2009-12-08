Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports System.Text
Namespace Longkong.Pojjaman.Commands
    Public Class RecentFilesMenuBuilder
        Implements ISubmenuBuilder

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Private Sub LoadRecentFile(ByVal sender As Object, ByVal e As EventArgs)
            Dim command As PJMMenuCommand = CType(sender, PJMMenuCommand)
            Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            myFileService.OpenFile(command.Tag.ToString)
        End Sub
#End Region

#Region "ISubMenuBuilder"
        Public Function BuildSubmenu(ByVal conditionCollection As Core.AddIns.Conditions.ConditionCollection, ByVal owner As Object) As System.Windows.Forms.CommandBarItem() Implements Core.AddIns.Codons.ISubmenuBuilder.BuildSubmenu
            Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim myRecentOpen As RecentOpen = myFileService.RecentOpen
            If (myRecentOpen.RecentFile.Count > 0) Then
                Dim commands As PJMMenuCommand() = New PJMMenuCommand(myRecentOpen.RecentFile.Count - 1) {}
                For i As Integer = 0 To myRecentOpen.RecentFile.Count - 1
                    Dim myStringBuilder As New StringBuilder("")
                    If (i < 10) Then
                        myStringBuilder.Append("&")
                        Dim index As Integer = ((i + 1) Mod 10)
                        myStringBuilder.Append(index.ToString)
                        myStringBuilder.Append(" ")
                    End If
                    myStringBuilder.Append(myRecentOpen.RecentFile(i).ToString)
                    commands(i) = New PJMMenuCommand(Nothing, Nothing, myStringBuilder.ToString, New EventHandler(AddressOf Me.LoadRecentFile))
                    commands(i).Tag = (myRecentOpen.RecentFile(i).ToString)
                    Dim textArray1(,) As String = New String(1 - 1, 2 - 1) {}
                    textArray1(0, 0) = "FILE"
                    textArray1(0, 1) = myRecentOpen.RecentFile.Item(i).ToString
                    commands(i).Description = myStringParserService.Parse(myResourceService.GetString("Dialog.Componnents.RichMenuItem.LoadFileDescription"), textArray1)
                Next
                Return commands
            End If
            'RecentOpens not found:
            Dim blankCommand As New PJMMenuCommand(Nothing, Nothing, myResourceService.GetString("Dialog.Componnents.RichMenuItem.NoRecentFilesString"))
            blankCommand.IsEnabled = False
            Return New PJMMenuCommand() {blankCommand}
        End Function
#End Region

    End Class
End Namespace
