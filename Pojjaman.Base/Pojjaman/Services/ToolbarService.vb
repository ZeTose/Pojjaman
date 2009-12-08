Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Internal.Parser
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Services
    Public Class ToolbarService
        Inherits AbstractService

#Region "Members"
        Private m_node As IAddInTreeNode
        Private Shared ReadOnly m_toolBarPath As String = "/Pojjaman/Workbench/ToolBar"
#End Region

#Region "Constructors"
        Public Sub New()
            Try
                Me.m_node = AddInTreeSingleton.AddInTree.GetTreeNode(ToolbarService.m_toolBarPath)
            Catch ex As TreePathNotFoundException
                Me.m_node = Nothing
            End Try
        End Sub
#End Region

#Region "Methods"
        Public Function CreateToolBarFromCodon(ByVal owner As Object, ByVal codon As ToolbarItemCodon) As CommandBar
            Dim cbManager As CommandBarManager = CType(owner, IWorkbench).CommandBarManager
            Dim tb As New CommandBar(cbManager, CommandBarStyle.ToolBar)
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            If codon.SubItems.Count > 0 Then
                If CType(codon.SubItems(0), ToolbarItemCodon).Label <> "" Then
                    tb.Style = CommandBarStyle.TextToolBar
                End If
            End If
            For Each tbCodon As ToolbarItemCodon In codon.SubItems
                Dim text As String
                If tbCodon.Label <> "" Then
                    text = tbCodon.Label
                Else
                    text = tbCodon.ToolTip
                End If
                Dim item As CommandBarItem = Nothing
                Dim o As Object = Nothing
                If (Not tbCodon.Class Is Nothing) Then
                    o = tbCodon.AddIn.CreateObject(tbCodon.Class)
                    item = Nothing
                End If
                If ((Not o Is Nothing) AndAlso TypeOf o Is IComboBoxCommand) Then
                    item = New PJMMenuComboBox(tbCodon.ID, tbCodon.Conditions, owner, CType(o, ICommand))
                    CType(o, IComboBoxCommand).Owner = item
                ElseIf Not o Is Nothing AndAlso TypeOf o Is ICheckableMenuCommand Then
                    item = New PJMMenuCheckBox(tbCodon.Conditions, owner, text, CType(o, ICheckableMenuCommand))
                    item.Image = myResourceService.GetBitmap(tbCodon.Icon)
                    CType(o, ICheckableMenuCommand).Owner = item
                Else
                    If Not (tbCodon.ToolTip Is Nothing) Then
                        If (tbCodon.ToolTip = "-") Then
                            item = New CommandBarSeparator
                        Else
                            item = New PJMMenuCommand(tbCodon.Conditions, owner, text)
                            item.Image = myResourceService.GetBitmap(tbCodon.Icon)
                        End If
                        If (Not tbCodon.Class Is Nothing) Then
                            CType(item, PJMMenuCommand).Command = CType(tbCodon.AddIn.CreateObject(tbCodon.Class), ICommand)
                        End If
                    End If
                End If
                tb.Items.Add(item)
            Next
            Return tb
        End Function
        Public Function CreateToolbars() As CommandBar()
            If (Me.m_node Is Nothing) Then
                Return New CommandBar(0 - 1) {}
            End If
            Dim tbCodons As ToolbarItemCodon() = CType(Me.m_node.BuildChildItems(Me).ToArray(GetType(ToolbarItemCodon)), ToolbarItemCodon())
            Dim toolBars As CommandBar() = New CommandBar(tbCodons.Length - 1) {}
            For i As Integer = 0 To tbCodons.Length - 1
                toolBars(i) = Me.CreateToolBarFromCodon(WorkbenchSingleton.Workbench, tbCodons(i))
            Next
            Return toolBars
        End Function
        Private Sub ToolBarButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            If TypeOf sender Is CommandBarItem Then
                CType(CType(sender, CommandBarItem).Tag, ICommand).Run()
            End If
        End Sub
#End Region

    End Class
End Namespace



