Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports System.Windows.Forms
Imports System.Collections.Specialized
Imports Longkong.Core.Services
Imports System.Configuration
Namespace Longkong.Core
    Public Enum FileErrorPolicy
        Inform
        ProvideAlternative
    End Enum
    Public Enum FileOperationResult
        OK
        Failed
        SavedAlternatively
    End Enum
End Namespace
Namespace Longkong.Core.Services
    Public Delegate Sub FileOperationDelegate()
    Public Delegate Sub NamedFileOperationDelegate(ByVal fileName As String)

    Public Class FileUtilityService
        Inherits AbstractService

#Region "Members"
        Private Const FILE_NAME_REGEX As String = "^(([a-zA-Z]:)|.)[^:]*$"
        Private Shared ReadOnly m_separators As Char() = New Char() {Path.DirectorySeparatorChar, Path.VolumeSeparatorChar}
        Private m_pojjamanRootPath As String
#End Region

#Region "Constructors"
        Public Sub New()
            Dim mydirectory As String = ConfigurationSettings.AppSettings.Item("DataDirectory")
            If (Not mydirectory Is Nothing AndAlso Not mydirectory.Length = 0) Then
                Me.m_pojjamanRootPath = mydirectory
            Else
                Me.m_pojjamanRootPath = (Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) & Path.DirectorySeparatorChar & "..")
            End If
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property NETFrameworkInstallRoot() As String
            Get
                Dim installRootKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\.NETFramework")
                Dim o As Object = installRootKey.GetValue("InstallRoot")
                If (Not o Is Nothing) Then
                    Return o.ToString
                End If
                Return String.Empty
            End Get
        End Property
        Public ReadOnly Property PojjamanRootPath() As String
            Get
                Return Me.m_pojjamanRootPath
            End Get
        End Property
#End Region

#Region "Methods"
        Public Function AbsoluteToRelativePath(ByVal baseDirectoryPath As String, ByVal absPath As String) As String
            Dim bPath As String() = baseDirectoryPath.Split(FileUtilityService.m_separators)
            Dim aPath As String() = absPath.Split(FileUtilityService.m_separators)
            Dim indx As Integer = 0
            Do While (indx < Math.Min(bPath.Length, aPath.Length))
                If Not bPath(indx).Equals(aPath(indx)) Then
                    Exit Do
                End If
                indx += 1
            Loop
            If (indx = 0) Then
                Return absPath
            End If
            Dim erg As New StringBuilder
            If (indx = absPath.Length) Then
                erg.Append("."c)
                erg.Append(Path.DirectorySeparatorChar)
            Else
                For i As Integer = indx To absPath.Length - 1
                    erg.Append("..")
                    erg.Append(Path.DirectorySeparatorChar)
                Next
            End If
            erg.Append(String.Join(Path.DirectorySeparatorChar.ToString, aPath, indx, (aPath.Length - indx)))
            Return erg.ToString
        End Function
        Public Function GetAvaiableRuntimeVersions() As String()
            Dim installRoot As String = NETFrameworkInstallRoot
            Dim files As String() = Directory.GetDirectories(installRoot)
            Dim runtimes As New ArrayList
            For Each file As String In files
                Dim runtime As String = Path.GetFileName(file)
                If runtime.StartsWith("v") Then
                    runtimes.Add(runtime)
                End If
            Next
            Return CType(runtimes.ToArray(GetType(String)), String())
        End Function
        Public Function GetDirectoryNameWithSeparator(ByVal directoryName As String) As String
            If (directoryName Is Nothing) Then
                Return ""
            End If
            If directoryName.EndsWith(Path.DirectorySeparatorChar.ToString) Then
                Return directoryName
            End If
            Return (directoryName & Path.DirectorySeparatorChar)
        End Function
        Public Overrides Sub InitializeService()
            MyBase.InitializeService()
        End Sub
        Public Function IsDirectory(ByVal filename As String) As Boolean
            If Not Directory.Exists(filename) Then
                Return False
            End If
            Dim attr As FileAttributes = File.GetAttributes(filename)
            Return (attr And FileAttributes.Directory) <> 0
        End Function
        Public Function IsValidFileName(ByVal fileName As String) As Boolean
            'Todo: 260 is the hardcoded maximal length for a path on my Windows XP system
            'I can't find a .NET property or method for determining this variable.
            If (((fileName Is Nothing) OrElse (fileName.Length = 0)) OrElse (fileName.Length >= 260)) Then
                Return False
            End If

            'platform independend : check for invalid path chars
            For Each invalidChar As Char In Path.InvalidPathChars
                If fileName.IndexOf(invalidChar) >= 0 Then
                    Return False
                End If
            Next

            If ((fileName.IndexOf("?"c) >= 0) OrElse (fileName.IndexOf("*"c) >= 0)) Then
                Return False
            End If
            If Not Regex.IsMatch(fileName, "^(([a-zA-Z]:)|.)[^:]*$") Then
                Return False
            End If

            'platform dependend : Check for invalid file names (DOS)
            'this routine checks for follwing bad file names :
            'CON, PRN, AUX, NUL, COM1-9 and LPT1-9

            Dim nameWithoutExtension As String = Path.GetFileNameWithoutExtension(fileName)
            If (Not nameWithoutExtension Is Nothing) Then
                nameWithoutExtension = nameWithoutExtension.ToUpper
            End If
            If (((nameWithoutExtension = "CON") OrElse (nameWithoutExtension = "PRN")) OrElse ((nameWithoutExtension = "AUX") OrElse (nameWithoutExtension = "NUL"))) Then
                Return False
            End If
            If (Not nameWithoutExtension.StartsWith("COM") AndAlso Not nameWithoutExtension.StartsWith("LPT")) Then
                Return True
            End If
            Dim ch As Char = CChar(IIf((nameWithoutExtension.Length = 4), nameWithoutExtension.Chars(3), ChrW(0)))
            Return Not Char.IsDigit(ch)
        End Function
        Public Function ObservedLoad(ByVal saveFile As FileOperationDelegate, ByVal fileName As String) As FileOperationResult
            Return Me.ObservedLoad(saveFile, fileName, FileErrorPolicy.Inform)
        End Function
        Public Function ObservedLoad(ByVal saveFileAs As NamedFileOperationDelegate, ByVal fileName As String) As FileOperationResult
            Return Me.ObservedLoad(saveFileAs, fileName, FileErrorPolicy.Inform)
        End Function
        Public Function ObservedLoad(ByVal saveFile As FileOperationDelegate, ByVal fileName As String, ByVal policy As FileErrorPolicy) As FileOperationResult
            Dim resourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
            Return Me.ObservedLoad(saveFile, fileName, resourceService.GetString("ICSharpCode.Services.FileUtilityService.CantLoadFileStandardText"), policy)
        End Function
        Public Function ObservedLoad(ByVal saveFileAs As NamedFileOperationDelegate, ByVal fileName As String, ByVal policy As FileErrorPolicy) As FileOperationResult
            Dim resourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
            Return Me.ObservedLoad(saveFileAs, fileName, resourceService.GetString("ICSharpCode.Services.FileUtilityService.CantLoadFileStandardText"), policy)
        End Function

        Public Function ObservedLoad(ByVal saveFile As FileOperationDelegate, ByVal fileName As String, ByVal message As String, ByVal policy As FileErrorPolicy) As FileOperationResult
            System.Diagnostics.Debug.Assert(IsValidFileName(fileName))
            Try
                saveFile()
                Return FileOperationResult.OK
            Catch e As Exception
                Select Case policy
                    Case FileErrorPolicy.Inform
                        Dim informDialog As New SaveErrorInformDialog(fileName, message, "${res:FileUtilityService.ErrorWhileLoading}", e)
                        Try
                            informDialog.ShowDialog()
                        Finally
                            informDialog.Dispose()
                        End Try
                    Case FileErrorPolicy.ProvideAlternative
                        Dim chooseDialog As New SaveErrorChooseDialog(fileName, message, "${res:FileUtilityService.ErrorWhileLoading}", e, False)
                        Try
                            Select Case chooseDialog.ShowDialog()
                                Case DialogResult.OK ' choose location (never happens here)
                                Case DialogResult.Retry
                                    Return ObservedLoad(saveFile, fileName, message, policy)
                                Case DialogResult.Ignore
                                    Return FileOperationResult.Failed
                            End Select
                        Finally
                            chooseDialog.Dispose()
                        End Try
                End Select
            End Try
            Return FileOperationResult.Failed
        End Function
        Public Function ObservedLoad(ByVal saveFileAs As NamedFileOperationDelegate, ByVal fileName As String, ByVal message As String, ByVal policy As FileErrorPolicy) As FileOperationResult
            Return Me.ObservedLoad(New FileOperationDelegate(AddressOf New LoadWrapper(saveFileAs, fileName).Invoke), fileName, message, policy)
        End Function
        Public Function ObservedSave(ByVal saveFile As FileOperationDelegate, ByVal fileName As String) As FileOperationResult
            Return Me.ObservedSave(saveFile, fileName, FileErrorPolicy.Inform)
        End Function
        Public Function ObservedSave(ByVal saveFileAs As NamedFileOperationDelegate, ByVal fileName As String) As FileOperationResult
            Return Me.ObservedSave(saveFileAs, fileName, FileErrorPolicy.Inform)
        End Function
        Public Function ObservedSave(ByVal saveFile As FileOperationDelegate, ByVal fileName As String, ByVal policy As FileErrorPolicy) As FileOperationResult
            Dim resourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
            Return Me.ObservedSave(saveFile, fileName, resourceService.GetString("ICSharpCode.Services.FileUtilityService.CantSaveFileStandardText"), policy)
        End Function
        Public Function ObservedSave(ByVal saveFileAs As NamedFileOperationDelegate, ByVal fileName As String, ByVal policy As FileErrorPolicy) As FileOperationResult
            Dim resourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
            Return Me.ObservedSave(saveFileAs, fileName, resourceService.GetString("ICSharpCode.Services.FileUtilityService.CantSaveFileStandardText"), policy)
        End Function
        Public Function ObservedSave(ByVal saveFile As FileOperationDelegate, ByVal fileName As String, ByVal message As String, ByVal policy As FileErrorPolicy) As FileOperationResult
            System.Diagnostics.Debug.Assert(IsValidFileName(fileName))
            Try
                saveFile()
                Return FileOperationResult.OK
            Catch e As Exception
                Select Case policy
                    Case FileErrorPolicy.Inform
                        Dim informDialog As New SaveErrorInformDialog(fileName, message, "${res:FileUtilityService.ErrorWhileSaving}", e)
                        Try
                            informDialog.ShowDialog()
                        Finally
                            informDialog.Dispose()
                        End Try
                    Case FileErrorPolicy.ProvideAlternative
                        Dim chooseDialog As New SaveErrorChooseDialog(fileName, message, "${res:FileUtilityService.ErrorWhileSaving}", e, False)
                        Try
                            Select Case chooseDialog.ShowDialog()
                                Case DialogResult.OK ' choose location (never happens here)
                                Case DialogResult.Retry
                                    Return ObservedSave(saveFile, fileName, message, policy)
                                Case DialogResult.Ignore
                                    Return FileOperationResult.Failed
                            End Select
                        Finally
                            chooseDialog.Dispose()
                        End Try
                End Select
            End Try
            Return FileOperationResult.Failed
        End Function
        Public Function ObservedSave(ByVal saveFileAs As NamedFileOperationDelegate, ByVal fileName As String, ByVal message As String, ByVal policy As FileErrorPolicy) As FileOperationResult
            System.Diagnostics.Debug.Assert(IsValidFileName(fileName))
            Try
                saveFileAs(fileName)
                Return FileOperationResult.OK
            Catch e As Exception
                Select Case policy
                    Case FileErrorPolicy.Inform
                        Dim informDialog As New SaveErrorInformDialog(fileName, message, "${res:FileUtilityService.ErrorWhileSaving}", e)
                        Try
                            informDialog.ShowDialog()
                        Finally
                            informDialog.Dispose()
                        End Try
                    Case FileErrorPolicy.ProvideAlternative
restartlabel:
                        Dim chooseDialog As New SaveErrorChooseDialog(fileName, message, "${res:FileUtilityService.ErrorWhileSaving}", e, True)
                        Try
                            Select Case chooseDialog.ShowDialog()
                                Case DialogResult.OK
                                    Dim fdiag As New SaveFileDialog
                                    Try
                                        fdiag.OverwritePrompt = True
                                        fdiag.AddExtension = True
                                        fdiag.CheckFileExists = False
                                        fdiag.CheckPathExists = True
                                        fdiag.Title = "Choose alternate file name"
                                        fdiag.FileName = fileName
                                        If fdiag.ShowDialog() = DialogResult.OK Then
                                            Return ObservedSave(saveFileAs, fdiag.FileName, message, policy)
                                        Else
                                            GoTo restartlabel
                                        End If
                                    Finally
                                        fdiag.Dispose()
                                    End Try
                                Case DialogResult.Retry
                                    Return ObservedSave(saveFileAs, fileName, message, policy)
                                Case DialogResult.Ignore
                                    Return FileOperationResult.Failed
                            End Select
                        Finally
                            chooseDialog.Dispose()
                        End Try
                End Select
            End Try
            Return FileOperationResult.Failed
        End Function
        Public Function RelativeToAbsolutePath(ByVal baseDirectoryPath As String, ByVal relPath As String) As String
            If ((FileUtilityService.m_separators(0) <> FileUtilityService.m_separators(1)) AndAlso (relPath.IndexOf(FileUtilityService.m_separators(1)) <> -1)) Then
                Return relPath
            End If
            Dim bPath As String() = baseDirectoryPath.Split(m_separators(0))
            Dim rPath As String() = relPath.Split(m_separators(0))

            Dim indx As Integer = 0
            Do While (indx < rPath.Length)
                If Not rPath(indx).Equals("..") Then
                    Exit Do
                End If
                indx += 1
            Loop
            If (indx = 0) Then
                Return (baseDirectoryPath & FileUtilityService.m_separators(0) & String.Join(Path.DirectorySeparatorChar.ToString, rPath, 1, (rPath.Length - 1)))
            End If
            Dim erg As String = String.Join(Path.DirectorySeparatorChar.ToString, bPath, 0, Math.Max(0, CType((bPath.Length - indx), Integer)))
            Return erg & FileUtilityService.m_separators(0) & String.Join(Path.DirectorySeparatorChar.ToString, rPath, indx, (rPath.Length - indx))
        End Function

        Public Function SearchDirectory(ByVal directory As String, ByVal filemask As String) As StringCollection
            Return Me.SearchDirectory(directory, filemask, True, False)
        End Function

        Public Function SearchDirectory(ByVal directory As String, ByVal filemask As String, ByVal searchSubdirectories As Boolean) As StringCollection
            Return Me.SearchDirectory(directory, filemask, searchSubdirectories, False)
        End Function

        Public Function SearchDirectory(ByVal directory As String, ByVal filemask As String, ByVal searchSubdirectories As Boolean, ByVal ignoreHidden As Boolean) As StringCollection
            Dim collection As New StringCollection
            Me.SearchDirectory(directory, filemask, collection, searchSubdirectories, ignoreHidden)
            Return collection
        End Function

        Sub SearchDirectory(ByVal directory As String, ByVal filemask As String, ByVal collection As StringCollection, ByVal searchSubdirectories As Boolean, ByVal ignoreHidden As Boolean)
            Try
                Dim file As String() = System.IO.Directory.GetFiles(directory, filemask)
                Dim f As String
                For Each f In file
                    If ignoreHidden And (System.IO.File.GetAttributes(f) And FileAttributes.Hidden) = FileAttributes.Hidden Then
                        GoTo ContinueForEach1
                    End If
                    collection.Add(f)
ContinueForEach1:
                Next f

                If searchSubdirectories Then
                    Dim dir As String() = System.IO.Directory.GetDirectories(directory)
                    Dim d As String
                    For Each d In dir
                        If ignoreHidden And (System.IO.File.GetAttributes(d) And FileAttributes.Hidden) = FileAttributes.Hidden Then
                            GoTo ContinueForEach2
                        End If
                        SearchDirectory(d, filemask, collection, searchSubdirectories, ignoreHidden)
ContinueForEach2:
                    Next d
                End If
            Catch e As Exception
                Dim messageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                ' don't translate this error (core messages generally can't be translated.)
                messageService.ShowError(e, "Can't access directory " + directory)
            End Try
        End Sub
        Public Function TestFileExists(ByVal filename As String) As Boolean
            If Not File.Exists(filename) Then
                Dim resourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
                Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                myMessageService.ShowWarning(myStringParserService.Parse(resourceService.GetString("Fileutility.CantFindFileError"), New String(,) {{"FILE", filename}}))
                Return False
            End If
            Return True
        End Function
        Public Overrides Sub UnloadService()
            MyBase.UnloadService()
        End Sub
#End Region

#Region "LoadWrapper Class"
        Private Class LoadWrapper

#Region "Members"
            Private m_fileName As String
            Private m_saveFileAs As NamedFileOperationDelegate
#End Region

#Region "Constructors"
            Public Sub New(ByVal saveFileAs As NamedFileOperationDelegate, ByVal fileName As String)
                Me.m_saveFileAs = saveFileAs
                Me.m_fileName = fileName
            End Sub
#End Region

#Region "Methods"
            Public Sub Invoke()
                Me.m_saveFileAs.Invoke(Me.m_fileName)
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace

