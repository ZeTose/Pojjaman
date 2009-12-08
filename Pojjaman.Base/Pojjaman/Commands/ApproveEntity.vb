Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Commands
    Public Class ApproveEntity
        Inherits AbstractEntityMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim myEntity As ISimpleEntity = BusinessLogic.SimpleBusinessEntityBase.GetEntity(Me.Entity)
            Dim myContent As New ListViewApproveItemPanelView(myEntity, Nothing, Nothing, Nothing, Nothing)
            WorkbenchSingleton.Workbench.ShowView(myContent)
            Dim tabs As SecondaryViewContentCollection = GetTabsForEntity(myEntity)
            If Not tabs Is Nothing AndAlso tabs.Count > 0 Then
                For Each tab As ISecondaryViewContent In tabs
                    myContent.WorkbenchWindow.AttachSecondaryViewContent(tab)
                Next
            End If
        End Sub
        Private Function GetTabsForEntity(ByVal entity As BusinessLogic.ISimpleEntity) As Gui.SecondaryViewContentCollection
            Dim addInTreePath As String = "/Pojjaman/Workbench/EntityTabs"
            Dim o As Object = AddInTreeSingleton.AddInTree.GetTreeNode(addInTreePath).BuildChildItem("approve" & entity.ClassName.ToLower, Nothing)
            Dim tabs As SecondaryViewContentCollection = CType(o, SecondaryViewContentCollection)
            Return tabs
        End Function
#End Region

    End Class
End Namespace
