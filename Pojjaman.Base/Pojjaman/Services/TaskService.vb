Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Imports System.IO
Namespace Longkong.Pojjaman.Services
    Public Class TaskService
        Inherits AbstractService

#Region "Members"
        Private m_comments As Integer
        Private m_commentTasks As ArrayList
        Private m_compilerOutput As String
        Private m_errors As Integer
        Private m_tasks As ArrayList
        Private m_warnings As Integer
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_tasks = New ArrayList
            Me.m_commentTasks = New ArrayList
            Me.m_compilerOutput = String.Empty
            Me.m_warnings = 0
            Me.m_errors = 0
            Me.m_comments = 0
        End Sub
#End Region

#Region "Events"
        Public Event CompilerOutputChanged As EventHandler
        Public Event TasksChanged As EventHandler
#End Region

#Region "Properties"
        Public ReadOnly Property Comments() As Integer
            Get
                Return Me.m_comments
            End Get
        End Property
        Public ReadOnly Property CommentTasks() As ArrayList
            Get
                Return Me.m_commentTasks
            End Get
        End Property
        Public Property CompilerOutput() As String
            Get
                Return Me.m_compilerOutput
            End Get
            Set(ByVal value As String)
                Me.m_compilerOutput = value
                Me.OnCompilerOutputChanged(Nothing)
            End Set
        End Property
        Public ReadOnly Property Errors() As Integer
            Get
                Return Me.m_errors
            End Get
        End Property
        Public ReadOnly Property SomethingWentWrong() As Boolean
            Get
                Return ((Me.m_errors + Me.m_warnings) > 0)
            End Get
        End Property
        Public ReadOnly Property Tasks() As ArrayList
            Get
                Return Me.m_tasks
            End Get
        End Property
        Public ReadOnly Property Warnings() As Integer
            Get
                Return Me.m_warnings
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub CheckFileRemove(ByVal sender As Object, ByVal e As FileEventArgs)
            Dim removed As Boolean = False
            For i As Integer = 0 To Me.m_tasks.Count - 1
                Dim myTask As Task = CType(Me.m_tasks.Item(i), Task)
                Dim flag2 As Boolean = False
                Try
                    flag2 = (Path.GetFullPath(myTask.FileName) Is Path.GetFullPath(e.FileName))
                Catch ex As Exception
                    flag2 = (myTask.FileName Is e.FileName)
                End Try
                If flag2 Then
                    Me.m_tasks.RemoveAt(i)
                    i -= 1
                    removed = True
                End If
            Next
            If removed Then
                Me.NotifyTaskChange()
            End If
        End Sub
        Private Sub CheckFileRename(ByVal sender As Object, ByVal e As FileEventArgs)
            Dim renamed As Boolean = False
            For Each myTask As Task In Me.m_tasks
                If (Path.GetFullPath(myTask.FileName) Is Path.GetFullPath(e.SourceFile)) Then
                    myTask.FileName = Path.GetFullPath(e.TargetFile)
                    renamed = True
                End If
            Next
            For Each myTask As Task In Me.m_commentTasks
                If (Path.GetFullPath(myTask.FileName) Is Path.GetFullPath(e.SourceFile)) Then
                    myTask.FileName = Path.GetFullPath(e.TargetFile)
                    renamed = True
                End If
            Next
            If renamed Then
                Me.NotifyTaskChange()
            End If
        End Sub
        Public Function HasCriticalErrors(ByVal treatWarningsAsErrors As Boolean) As Boolean
            If treatWarningsAsErrors Then
                Return ((Me.m_errors + Me.m_warnings) > 0)
            End If
            Return (Me.m_errors > 0)
        End Function
        Public Overrides Sub InitializeService()
            MyBase.InitializeService()
            Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            AddHandler myFileService.FileRenamed, New FileEventHandler(AddressOf Me.CheckFileRename)
            AddHandler myFileService.FileRemoved, New FileEventHandler(AddressOf Me.CheckFileRemove)
            'Dim myProjectService As IProjectService = CType(ServiceManager.Services.GetService(GetType(IProjectService)), IProjectService)
            'AddHandler myProjectService.CombineClosed, New CombineEventHandler(AddressOf Me.OnCombineClosed)
        End Sub
        Public Sub NotifyTaskChange()
            Dim errNum As Integer = 0
            Me.m_comments = errNum
            Me.m_errors = errNum
            Me.m_warnings = errNum
            For Each myTask As Task In Me.m_tasks
                Select Case myTask.TaskType
                    Case TaskType.Error
                        Me.m_errors += 1
                    Case TaskType.Warning
                        Me.m_warnings += 1
                End Select
                Me.m_comments += 1
            Next
            Me.OnTasksChanged(Nothing)
        End Sub
        Protected Overridable Sub OnCompilerOutputChanged(ByVal e As EventArgs)
            RaiseEvent CompilerOutputChanged(Me, e)
        End Sub
        Protected Overridable Sub OnTasksChanged(ByVal e As EventArgs)
            RaiseEvent TasksChanged(Me, e)
        End Sub
        Public Sub RemoveCommentTasks(ByVal fileName As String)
            Dim flag1 As Boolean = False
            For i As Integer = 0 To Me.m_commentTasks.Count - 1
                Dim myTask As Task = CType(Me.m_commentTasks(i), Task)
                If (Path.GetFullPath(myTask.FileName) Is Path.GetFullPath(fileName)) Then
                    Me.m_commentTasks.RemoveAt(i)
                    flag1 = True
                    i -= 1
                End If
            Next
            If flag1 Then
                Me.NotifyTaskChange()
            End If
        End Sub
#End Region


    End Class
End Namespace



