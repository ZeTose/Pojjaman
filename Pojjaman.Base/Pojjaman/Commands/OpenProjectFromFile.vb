Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports System.IO
Namespace Longkong.Pojjaman.Commands
    Public Class OpenProjectFromFile
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim dialog As OpenFileDialog = New OpenFileDialog
            Dim ext As String
            dialog.AddExtension = True
            dialog.Filter = String.Join("|", CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Project/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String()))
            dialog.Multiselect = False
            dialog.CheckFileExists = True
            If (dialog.ShowDialog <> DialogResult.OK) Then
                Return
            End If
            ext = Path.GetExtension(dialog.FileName).ToUpper
            If (Not ext Is Nothing) Then
                ext = String.IsInterned(ext)
                If ext = ".PJM" Then
                    'Dim service1 As IProjectService = CType(ServiceManager.Services.GetService(GetType(IProjectService)), IProjectService)
                    'Dim service2 As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
                    'service2.ObservedLoad(New NamedFileOperationDelegate(AddressOf service1.OpenCombine), dialog.FileName)
                    Return
                End If
            End If
            Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim errTexts(,) As String = New String(1 - 1, 2 - 1) {}
            errTexts(0, 0) = "FileName"
            errTexts(0, 1) = dialog.FileName
            myMessageService.ShowError(myStringParserService.Parse("${res:Longkong.Pojjaman.Commands.OpenCombine.InvalidProjectOrCombine}", errTexts))
        End Sub
#End Region

    End Class
End Namespace
