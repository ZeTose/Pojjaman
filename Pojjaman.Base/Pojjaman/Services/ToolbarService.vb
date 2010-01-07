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
    Public Function CreateToolBarFromCodon(ByVal owner As Object, ByVal codon As ToolbarItemCodon) As ToolStrip
      Dim tb As New ToolStrip
      tb.Size = New System.Drawing.Size(705, 31)
      tb.ImageScalingSize = New System.Drawing.Size(24, 24)
      Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
      If codon.SubItems.Count > 0 Then
        If CType(codon.SubItems(0), ToolbarItemCodon).Label <> "" Then
          'tb.Style = CommandBarStyle.TextToolBar
        End If
      End If
      For Each tbCodon As ToolbarItemCodon In codon.SubItems
        Dim text As String
        If tbCodon.Label <> "" Then
          text = tbCodon.Label
        Else
          text = tbCodon.ToolTip
        End If
        Dim item As ToolStripItem = Nothing
        Dim o As Object = Nothing
        If (Not tbCodon.Class Is Nothing) Then
          o = tbCodon.AddIn.CreateObject(tbCodon.Class)
          item = Nothing
        End If
        If ((Not o Is Nothing) AndAlso TypeOf o Is IComboBoxCommand) Then
          'item = New PJMToolStripMenuItem(tbCodon.ID, tbCodon.Conditions, owner, CType(o, ICommand))
          'CType(o, IComboBoxCommand).Owner = item
        ElseIf Not o Is Nothing AndAlso TypeOf o Is ICheckableMenuCommand Then
          'item = New PJMMenuCheckBox(tbCodon.Conditions, owner, text, CType(o, ICheckableMenuCommand))
          'item.Image = myResourceService.GetBitmap(tbCodon.Icon)
          'CType(o, ICheckableMenuCommand).Owner = item
        Else
          If Not (tbCodon.ToolTip Is Nothing) Then
            If (tbCodon.ToolTip = "-") Then
              item = New PJMToolStripSeparator
            Else
              item = New PJMToolStripMenuItem(tbCodon.Conditions, owner, text)
              item.Image = myResourceService.GetBitmap(tbCodon.Icon)
            End If
            If (Not tbCodon.Class Is Nothing) Then
              CType(item, PJMToolStripMenuItem).Command = CType(tbCodon.AddIn.CreateObject(tbCodon.Class), ICommand)
            End If
          End If
          If ((Not tbCodon.Shortcut Is Nothing) AndAlso TypeOf item Is Pojjaman.Gui.Components.PJMToolStripMenuItem) Then
            Try
              Dim newItem As PJMToolStripMenuItem = CType(item, PJMToolStripMenuItem)
              Dim textArray1 As String() = tbCodon.Shortcut
              Dim allKeys As Keys = Keys.None
              For Each key As String In tbCodon.Shortcut
                Dim thisKey As Keys = CType([Enum].Parse(GetType(Keys), key), Keys)
                allKeys = allKeys Or thisKey
              Next
              newItem.ShortcutKeys = allKeys
              newItem.ShowShortcutKeys = True
            Catch ex As Exception
              CType(item, Pojjaman.Gui.Components.PJMToolStripMenuItem).ShortcutKeys = Keys.None
            End Try
          End If
        End If
        If Not item Is Nothing Then
          item.DisplayStyle = ToolStripItemDisplayStyle.Image
          tb.Items.Add(item)
        End If
      Next
      Return tb
    End Function
    Public Function CreateToolbars() As ToolStrip()
            If (Me.m_node Is Nothing) Then
        Return New ToolStrip(0 - 1) {}
            End If
            Dim tbCodons As ToolbarItemCodon() = CType(Me.m_node.BuildChildItems(Me).ToArray(GetType(ToolbarItemCodon)), ToolbarItemCodon())
      Dim toolBars As ToolStrip() = New ToolStrip(tbCodons.Length - 1) {}
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



