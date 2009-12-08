Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.Internal.Parser
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Properties
Imports System.IO
Namespace Longkong.Pojjaman.Services
    Public Class DefaultFileService
        Inherits AbstractService
        Implements IFileService

#Region "Members"
        Private m_currentFile As String
        Private m_fileUtilityService As FileUtilityService
        Private m_recentOpen As RecentOpen
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_recentOpen = Nothing
            Me.m_fileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
        End Sub
#End Region

#Region "Members"
        Protected Overridable Sub OnFileRemoved(ByVal e As FileEventArgs)
            RaiseEvent FileRemoved(Me, e)
        End Sub
        'Protected Overridable Sub OnFileRemovedFromProject(ByVal e As FileEventArgs)
        '    RaiseEvent FileRemovedFromProject(Me, e)
        'End Sub
        Protected Overridable Sub OnFileRenamed(ByVal e As FileEventArgs)
            RaiseEvent FileRenamed(Me, e)
        End Sub
#End Region

#Region "IFileService"
        Public Event FileRemoved(ByVal sender As Object, ByVal e As FileEventArgs) Implements IFileService.FileRemoved
        Public Event FileRenamed(ByVal sender As Object, ByVal e As FileEventArgs) Implements IFileService.FileRenamed

        Public Function GetOpenFile(ByVal fileName As String) As Gui.IWorkbenchWindow Implements IFileService.GetOpenFile
            If ((Not fileName Is Nothing) AndAlso (fileName.Length > 0)) Then
                Dim name As String = ""
                If fileName.StartsWith("http://") Then
                    name = fileName.ToLower
                ElseIf Path.IsPathRooted(fileName) Then
                    name = Path.GetFullPath(fileName).ToLower
                Else
                    name = fileName.ToLower
                End If
                For Each content As IViewContent In WorkbenchSingleton.Workbench.ViewContentCollection
                    Dim contentName As String
                    If content.IsUntitled Then
                        contentName = content.UntitledName
                    ElseIf content.FileName Is Nothing Then
                        contentName = ""
                    ElseIf content.FileName.StartsWith("http://") Then
                        contentName = content.FileName
                    Else
                        contentName = Path.GetFullPath(content.FileName)
                    End If
                    contentName = contentName.ToLower
                    Console.WriteLine((contentName & " -- " & name))
                    If (contentName = name) Then
                        Return content.WorkbenchWindow
                    End If
                    If ((Not content.WorkbenchWindow Is Nothing) AndAlso (Not content.WorkbenchWindow.SubViewContents Is Nothing)) Then
                        For Each subContent As IViewContent In content.WorkbenchWindow.SubViewContents
                            If ((Not subContent Is Nothing) AndAlso (Not subContent.FileName Is Nothing)) Then
                                Dim subContentName As String
                                If subContent.IsUntitled Then
                                    subContentName = subContent.UntitledName
                                ElseIf subContent.FileName Is Nothing Then
                                    subContentName = ""
                                ElseIf subContent.FileName.StartsWith("http://") Then
                                    subContentName = subContent.FileName
                                Else
                                    subContentName = Path.GetFullPath(subContent.FileName)
                                End If
                                subContentName = subContentName.ToLower
                                Console.WriteLine((subContentName & " -- " & name))
                                If (subContentName = name) Then
                                    Return content.WorkbenchWindow
                                End If
                            End If
                        Next
                    End If
                Next
            End If
            Return Nothing
        End Function
        Public Function IsOpen(ByVal fileName As String) As Boolean Implements IFileService.IsOpen
            For Each content As IViewContent In WorkbenchSingleton.Workbench.ViewContentCollection
                If content.IsUntitled Then
                    If (content.UntitledName = fileName) Then
                        Return True
                    End If
                Else
                    If (content.FileName = fileName) Then
                        Return True
                    End If
                End If
                If ((Not content.WorkbenchWindow Is Nothing) AndAlso (Not content.WorkbenchWindow.SubViewContents Is Nothing)) Then
                    For Each subContent As IViewContent In content.WorkbenchWindow.SubViewContents
                        If ((Not subContent Is Nothing) AndAlso (Not subContent.FileName Is Nothing)) Then
                            Try
                                If (Not Path.GetFullPath(subContent.FileName.ToUpper) = Path.GetFullPath(fileName.ToUpper)) Then
                                Else
                                    Return True
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                End If
            Next
            Return False
        End Function
        Public Sub JumpToFilePosition(ByVal fileName As String, ByVal line As Integer, ByVal column As Integer) Implements IFileService.JumpToFilePosition
            If ((Not fileName Is Nothing) AndAlso (fileName.Length <> 0)) Then
                Me.OpenFile(fileName)
                Dim window1 As IWorkbenchWindow = Me.GetOpenFile(fileName)
                If (Not window1 Is Nothing) Then
                    Dim content1 As IViewContent = window1.ViewContent
                    If (content1.WorkbenchWindow.SubViewContents Is Nothing) Then
                        If Not TypeOf content1 Is IPositionable Then
                            Return
                        End If
                        window1.SwitchView(0)
                        CType(content1, IPositionable).JumpTo(Math.Max(0, line), Math.Max(0, column))
                    Else
                        Dim num1 As Integer = 0
                        Dim content2 As IViewContent
                        For Each content2 In content1.WorkbenchWindow.SubViewContents
                            If ((Not content2 Is Nothing) AndAlso (Not content2.FileName Is Nothing)) Then
                                Try
                                    If ((Not Path.GetFullPath(content2.FileName.ToUpper) Is Path.GetFullPath(fileName.ToUpper)) OrElse Not TypeOf content2 Is IPositionable) Then
                                        GoTo Label_00E6
                                    End If
                                    window1.SwitchView(num1)
                                    CType(content2, IPositionable).JumpTo(Math.Max(0, line), Math.Max(0, column))
                                Catch exception1 As Exception
                                End Try
                                Return
                            End If
Label_00E6:
                            num1 += 1
                        Next
                    End If
                End If
            End If
        End Sub
        Public Sub NewFile(ByVal defaultName As String, ByVal language As String, ByVal content As String) Implements IFileService.NewFile
            Dim myDisplayBindingService As DisplayBindingService = CType(ServiceManager.Services.GetService(GetType(DisplayBindingService)), DisplayBindingService)
            Dim myDisplayBinding As IDisplayBinding = myDisplayBindingService.GetBindingPerLanguageName(language)
            If (myDisplayBinding Is Nothing) Then
                Throw New ApplicationException(("Can't create display binding for language " & language))
            End If
            Dim myContent As IViewContent = myDisplayBinding.CreateContentForLanguage(language, content)
            If (myContent Is Nothing) Then
                Dim errorArr As Object() = New Object() {defaultName, language, content, Environment.NewLine}
                Throw New ApplicationException(String.Format("Created view content was null{3}DefaultName:{0}{3}Language:{1}{3}Content:{2}", errorArr))
            End If
            myContent.UntitledName = defaultName
            myContent.IsDirty = False
            WorkbenchSingleton.Workbench.ShowView(myContent)
            myDisplayBindingService.AttachSubWindows(myContent.WorkbenchWindow)
        End Sub
        Public Sub OpenFile(ByVal fileName As String) Implements IFileService.OpenFile
            If Not fileName.StartsWith("http://") Then
                If Not Path.IsPathRooted(fileName) Then
                    For Each content As IViewContent In WorkbenchSingleton.Workbench.ViewContentCollection
                        If (content.IsUntitled AndAlso (content.UntitledName = fileName)) Then
                            content.WorkbenchWindow.SelectWindow()
                            Return
                        End If
                    Next
                Else
                    If Not Me.m_fileUtilityService.TestFileExists(fileName) Then
                        Return
                    End If
                End If
            End If

            For Each content As IViewContent In WorkbenchSingleton.Workbench.ViewContentCollection
                If (Not content.FileName Is Nothing) Then
                    Try
                        Dim flag As Boolean
                        If fileName.StartsWith("http://") Then
                            flag = (content.FileName = fileName)
                        Else
                            flag = ((Path.GetFullPath(content.FileName.ToUpper) = Path.GetFullPath(fileName.ToUpper)))
                        End If
                        If Not flag Then
                            GoTo Label_00F7
                        End If
                        content.WorkbenchWindow.SelectWindow()
                    Catch ex As Exception
                    End Try
                    Return
                End If

Label_00F7:
                If ((Not content.WorkbenchWindow Is Nothing) AndAlso (Not content.WorkbenchWindow.SubViewContents Is Nothing)) Then
                    For Each subContent As IBaseViewContent In content.WorkbenchWindow.SubViewContents
                        If (Not subContent Is Nothing) AndAlso (TypeOf subContent Is IViewContent) AndAlso (Not CType(subContent, IViewContent).FileName Is Nothing) Then
                            Try
                                Dim flag As Boolean
                                If fileName.StartsWith("http://") Then
                                    flag = (CType(subContent, IViewContent).FileName = fileName)
                                Else
                                    flag = ((Path.GetFullPath(CType(subContent, IViewContent).FileName.ToUpper) = Path.GetFullPath(fileName.ToUpper)))
                                End If
                                If Not flag Then
                                Else
                                    subContent.WorkbenchWindow.SelectWindow()
                                    Return
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                End If
            Next

            Dim myDisplayBindingService As DisplayBindingService = CType(ServiceManager.Services.GetService(GetType(DisplayBindingService)), DisplayBindingService)
            Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            Dim myBinding As IDisplayBinding = myDisplayBindingService.GetBindingPerFileName(fileName)
            If (myBinding Is Nothing) Then
                Throw New ApplicationException(("Can't open " & fileName & ", no display codon found."))
            End If
            If (Me.m_fileUtilityService.ObservedLoad(New NamedFileOperationDelegate(AddressOf New LoadFileWrapper(myBinding).Invoke), fileName) = FileOperationResult.OK) Then
                myFileService.RecentOpen.AddLastFile(fileName)
            End If
        End Sub
        Public ReadOnly Property RecentOpen() As RecentOpen Implements IFileService.RecentOpen
            Get
                If (Me.m_recentOpen Is Nothing) Then
                    Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                    Me.m_recentOpen = CType(myPropertyService.GetProperty("Longkong.Pojjaman.Gui.MainWindow.RecentOpen", New RecentOpen), RecentOpen)
                End If
                Return Me.m_recentOpen
            End Get
        End Property
        Public Sub RemoveFile(ByVal fileName As String) Implements IFileService.RemoveFile

        End Sub
        Public Sub RenameFile(ByVal oldName As String, ByVal newName As String) Implements IFileService.RenameFile

        End Sub
#End Region

#Region "LoadFileWrapper"
        Private Class LoadFileWrapper

#Region "Members"
            Private m_binding As IDisplayBinding
#End Region

#Region "Constructors"
            Public Sub New(ByVal binding As IDisplayBinding)
                Me.m_binding = binding
            End Sub
#End Region

#Region "Methods"
            Public Sub Invoke(ByVal fileName As String)
                Dim content As IViewContent = Me.m_binding.CreateContentForFile(fileName)
                WorkbenchSingleton.Workbench.ShowView(content)
                Dim myDisplayBindingService As DisplayBindingService = CType(ServiceManager.Services.GetService(GetType(DisplayBindingService)), DisplayBindingService)
                myDisplayBindingService.AttachSubWindows(content.WorkbenchWindow)
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace



