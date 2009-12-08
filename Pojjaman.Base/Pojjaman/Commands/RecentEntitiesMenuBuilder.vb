Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports System.Text
Namespace Longkong.Pojjaman.Commands
    Public Class RecentEntitiesMenuBuilder
        Implements ISubmenuBuilder

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Private Sub LoadRecentEntity(ByVal sender As Object, ByVal e As EventArgs)
            Dim command As PJMMenuCommand = CType(sender, PJMMenuCommand)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(CType(command.Tag, BusinessLogic.ISimpleEntity))
        End Sub
#End Region

#Region "ISubMenuBuilder"
        Public Function BuildSubmenu(ByVal conditionCollection As Core.AddIns.Conditions.ConditionCollection, ByVal owner As Object) As System.Windows.Forms.CommandBarItem() Implements Core.AddIns.Codons.ISubmenuBuilder.BuildSubmenu
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim myRecentOpen As RecentOpen = myEntityPanelService.RecentOpen
            If (myRecentOpen.RecentEntity.Count > 0) Then
                Dim commands As PJMMenuCommand() = New PJMMenuCommand(myRecentOpen.RecentEntity.Count - 1) {}
                For i As Integer = 0 To myRecentOpen.RecentEntity.Count - 1
                    Dim myStringBuilder As New StringBuilder("")
                    If (i < 10) Then
                        myStringBuilder.Append("&")
                        Dim index As Integer = ((i + 1) Mod 10)
                        myStringBuilder.Append(index.ToString)
                        myStringBuilder.Append(" ")
                    End If
                    Dim myEntity As BusinessLogic.ISimpleEntity = CType(myRecentOpen.RecentEntity.Item(i), BusinessLogic.ISimpleEntity)
                    myStringBuilder.Append(myEntity.TabPageText)
                    commands(i) = New PJMMenuCommand(Nothing, Nothing, myStringBuilder.ToString, New EventHandler(AddressOf Me.LoadRecentEntity))
                    commands(i).Tag = Nothing
                    commands(i).Tag = myEntity
                    Dim textArray1(,) As String = New String(1 - 1, 2 - 1) {}
                    textArray1(0, 0) = "ENTITY"
                    textArray1(0, 1) = myEntity.TabPageText
                    commands(i).Description = myStringParserService.Parse(myResourceService.GetString("Dialog.Componnents.RichMenuItem.LoadEntityDescription"), textArray1)
                Next
                Return commands
            End If
            'RecentOpens not found:
            Dim blankCommand As New PJMMenuCommand(Nothing, Nothing, myResourceService.GetString("Dialog.Componnents.RichMenuItem.NoRecentEntitiesString"))
            blankCommand.IsEnabled = False
            Return New PJMMenuCommand() {blankCommand}
        End Function
#End Region

    End Class
End Namespace
