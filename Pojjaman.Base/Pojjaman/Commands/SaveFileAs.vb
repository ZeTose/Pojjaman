Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Core.AddIns
Imports System.IO
Imports Longkong.Core

Namespace Longkong.Pojjaman.Commands
    Public Class SaveFileAs
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim ActiveWindow As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
            If (ActiveWindow Is Nothing) Then
                Return
            End If
            If ActiveWindow.ViewContent.IsViewOnly Then
                Return
            End If
            If (TypeOf ActiveWindow.ViewContent Is ICustomizedCommands AndAlso CType(ActiveWindow.ViewContent, ICustomizedCommands).SaveAsCommand) Then
                Return
            End If
            Dim dialog1 As SaveFileDialog = New SaveFileDialog
            dialog1.OverwritePrompt = True
            dialog1.AddExtension = True
            Dim textArray1 As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
            dialog1.Filter = String.Join("|", textArray1)
            Dim num1 As Integer
            For num1 = 0 To textArray1.Length - 1
                If (textArray1(num1).IndexOf(Path.GetExtension(CStr(IIf((ActiveWindow.ViewContent.FileName Is Nothing), ActiveWindow.ViewContent.UntitledName, ActiveWindow.ViewContent.FileName)))) >= 0) Then
                    dialog1.FilterIndex = (num1 + 1)
                    Exit For
                End If
            Next num1
            If (dialog1.ShowDialog <> DialogResult.OK) Then
                Return
            End If
            Dim text1 As String = dialog1.FileName
            Dim service1 As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            Dim service2 As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
            If Not service2.IsValidFileName(text1) Then
                Dim service3 As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                Dim service4 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                Dim textArray2(,) As String = New String(1 - 1, 2 - 1) {}
                textArray2(0, 0) = "FileName"
                textArray2(0, 1) = text1
                service3.ShowMessage(service4.Parse("${res:Longkong.Pojjaman.Commands.SaveFile.InvalidFileNameError}", textArray2))
            Else
                Dim content1 As IViewContent = ActiveWindow.ViewContent
                If (service2.ObservedSave(New NamedFileOperationDelegate(AddressOf content1.Save), text1) = FileOperationResult.OK) Then
                    service1.RecentOpen.AddLastFile(text1)
                    Dim service5 As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                    service5.ShowMessage(text1, "${res:Longkong.Pojjaman.Commands.SaveFile.FileSaved}")
                    CType(WorkbenchSingleton.Workbench, PojjamanWorkbench).UpdateToolbars()
                End If
            End If


        End Sub
#End Region

    End Class
End Namespace
