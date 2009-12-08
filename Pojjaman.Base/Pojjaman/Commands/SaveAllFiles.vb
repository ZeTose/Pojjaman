Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports System.IO
Imports Longkong.Core.AddIns
Imports Longkong.Core
Namespace Longkong.Pojjaman.Commands
    Public Class SaveAllFiles
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            'Todo : Refactor this
            Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            Dim content As IViewContent
            For Each content In WorkbenchSingleton.Workbench.ViewContentCollection
                If Not content.IsViewOnly Then
                    If TypeOf content Is Longkong.Pojjaman.Gui.Panels.IListPanel And content.IsDirty Then
                        Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
                        myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf content.Save), CType(content, ISimpleListPanel).SelectedEntity)
                    ElseIf Not TypeOf content Is Longkong.Pojjaman.Gui.Panels.IListPanel AndAlso (content.FileName Is Nothing) Then
                        If TypeOf content Is ICustomizedCommands Then
                            If Not CType(content, ICustomizedCommands).SaveAsCommand Then
                            End If
                        Else
                            Dim dialog As SaveFileDialog = New SaveFileDialog
                            dialog.OverwritePrompt = True
                            dialog.AddExtension = True
                            dialog.Filter = String.Join("|", CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String()))
                            If (dialog.ShowDialog = DialogResult.OK) Then
                                Dim dialogFileName As String = dialog.FileName
                                If (Path.GetExtension(dialogFileName).StartsWith("?") OrElse (Path.GetExtension(dialogFileName) Is "*")) Then
                                    dialogFileName = Path.ChangeExtension(dialogFileName, "")
                                End If
                                If (myFileUtilityService.ObservedSave(New NamedFileOperationDelegate(AddressOf content.Save), dialogFileName) = FileOperationResult.OK) Then
                                    Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                                    myMessageService.ShowMessage(dialogFileName, "${res:Longkong.Pojjaman.Commands.SaveFile.FileSaved}")
                                End If
                            End If
                        End If
                    Else
                        myFileUtilityService.ObservedSave(New FileOperationDelegate(AddressOf content.Save), content.FileName)
                    End If
                End If
            Next
        End Sub
#End Region

    End Class
End Namespace
