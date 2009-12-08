Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Core.AddIns
Imports System.IO
Namespace Longkong.Pojjaman.Commands
    Public Class OpenFile
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim myOpenFileDialog As New OpenFileDialog
            myOpenFileDialog.AddExtension = True
            Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
            myOpenFileDialog.Filter = String.Join("|", fileFilters)
            Dim flag1 As Boolean = False
            'Dim service1 As IProjectService = CType(ServiceManager.Services.GetService(GetType(IProjectService)), IProjectService)
            'Dim project1 As IProject = service1.CurrentSelectedProject
            'If ((project1 Is Nothing) AndAlso (Not service1.CurrentOpenCombine Is Nothing)) Then
            '    Dim list1 As ArrayList = Combine.GetAllProjects(service1.CurrentOpenCombine)
            '    If (list1.Count > 0) Then
            '        project1 = CType(list1.Item(0), ProjectCombineEntry).Project
            '    End If
            'End If
            'If (Not project1 Is Nothing) Then
            '    Dim service2 As LanguageBindingService = CType(ServiceManager.Services.GetService(GetType(LanguageBindingService)), LanguageBindingService)
            '    Dim codon1 As LanguageBindingCodon = service2.GetCodonPerLanguageName(project1.ProjectType)
            '    Dim num1 As Integer = 0
            '    Do While (Not flag1 AndAlso (num1 < textArray1.Length))
            '        Dim num2 As Integer = 0
            '        Do While (Not flag1 AndAlso (num2 < codon1.Supportedextensions.Length))
            '            If (textArray1(num1).IndexOf(codon1.Supportedextensions(num2)) >= 0) Then
            '                myOpenFileDialog.FilterIndex = (num1 + 1)
            '                flag1 = True
            '                Exit Do
            '            End If
            '            num2 += 1
            '        Loop
            '        num1 += 1
            '    Loop
            'End If
            If Not flag1 Then
                Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
                If (Not window Is Nothing) Then
                    For i As Integer = 0 To fileFilters.Length - 1
                        Dim contentName As String
                        If window.ViewContent.FileName Is Nothing Then
                            contentName = window.ViewContent.UntitledName
                        Else
                            contentName = window.ViewContent.FileName
                        End If
                        If (fileFilters(i).IndexOf(Path.GetExtension(contentName)) >= 0) Then
                            myOpenFileDialog.FilterIndex = (i + 1)
                            Exit For
                        End If
                    Next
                End If
            End If
            myOpenFileDialog.Multiselect = True
            myOpenFileDialog.CheckFileExists = True
            If (myOpenFileDialog.ShowDialog <> DialogResult.OK) Then
                Return
            End If
            Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            For Each fileName As String In myOpenFileDialog.FileNames
                myFileService.OpenFile(fileName)
            Next
        End Sub
#End Region

    End Class
End Namespace
