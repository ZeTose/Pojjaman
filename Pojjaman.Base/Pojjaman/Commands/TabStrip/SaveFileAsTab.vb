Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports System.IO
Namespace Longkong.Pojjaman.Commands.TabStrip
    Public Class SaveFileAsTab
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim window As IWorkbenchWindow = CType(Me.Owner, IWorkbenchWindow)
            If ((Not window Is Nothing) AndAlso Not window.ViewContent.IsViewOnly) Then
                SaveFileAsTab.SaveFileAs(window)
            End If
        End Sub
        Public Shared Sub SaveFileAs(ByVal window As IWorkbenchWindow)
            Dim dialog As SaveFileDialog = New SaveFileDialog
            dialog.OverwritePrompt = True
            dialog.AddExtension = True
            dialog.Filter = String.Join("|", CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/FileFilter").BuildChildItems(Nothing).ToArray(GetType(String)), String()))
            Dim textArray1 As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/FileFilter").BuildChildItems(Nothing).ToArray(GetType(String)), String())
            dialog.Filter = String.Join("|", textArray1)
            Dim num1 As Integer
            For num1 = 0 To textArray1.Length - 1
                If (textArray1(num1).IndexOf(Path.GetExtension(CStr(IIf((window.ViewContent.FileName Is Nothing), window.ViewContent.UntitledName, window.ViewContent.FileName)))) >= 0) Then
                    dialog.FilterIndex = (num1 + 1)
                    Exit For
                End If
            Next num1
            If (dialog.ShowDialog <> DialogResult.OK) Then
                Return
            End If
            Dim text1 As String = dialog.FileName
            If (Path.GetExtension(text1).StartsWith("?") OrElse (Path.GetExtension(text1) Is "*")) Then
                text1 = Path.ChangeExtension(text1, "")
            End If
            window.ViewContent.Save(text1)
            Dim service1 As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            service1.ShowMessage(text1, "${res:Longkong.Pojjaman.Commands.SaveFile.FileSaved}")
        End Sub
#End Region

    End Class
End Namespace
