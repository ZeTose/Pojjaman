Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui.Panels.BusinessForms
Namespace Longkong.Pojjaman.Commands
    Public Class AddBusinessItem
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            'Dim panel As IBusinessFormPanel = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent.Control, IBusinessFormPanel)

            'Dim tvItemDatabase As New GroupListDialog(New MaterialGroup, New Material)
            'tvItemDatabase.FormBorderStyle = FormBorderStyle.FixedDialog
            'tvItemDatabase.Owner = CType(WorkbenchSingleton.Workbench, Form)
            'If tvItemDatabase.ShowDialog() = DialogResult.OK Then
            '    For Each tag As Integer In tvItemDatabase.SelectedTags
            '        If TypeOf panel Is BOQGridPanel Then
            '            Dim item As New BoqItem(tag)
            '            panel.InsertItem(item)
            '        ElseIf TypeOf panel Is PRPanelView Then
            '            Dim item As New PRItem(tag, tvItemDatabase.ListEntity.FullClassName)
            '            Dim items As PRItemCollection = CType(panel.Items, PRItemCollection)
            '            If items Is Nothing OrElse items.IndexOf(item.Entity.Id) < 0 Then
            '                panel.InsertItem(item) 'Todo:
            '            End If
            '        ElseIf TypeOf panel Is POPanelView Then
            '            Dim item As New POItem(tag, tvItemDatabase.ListEntity.ClassName)
            '            Dim items As PoItemCollection = CType(panel.Items, PoItemCollection)
            '            If items Is Nothing OrElse items.IndexOf(item.Entity.Id) < 0 Then
            '                panel.InsertItem(item) 'Todo:
            '            End If
            '        End If
            '    Next
            'End If
        End Sub
#End Region

    End Class
End Namespace
