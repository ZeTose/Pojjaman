Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Namespace Longkong.Pojjaman.Services
    Public Class Task

#Region "Members"
        Private m_column As Integer
        Private m_description As String
        Private m_fileName As String
        Private m_line As Integer
        'Private project As IProject
        Private m_type As TaskType
#End Region

#Region "Constructors"
        '  Public Sub New(ByVal project As IProject, ByVal [error] As CompilerError)
        '      Me.project = project
        'Me.type = IIf(error.IsWarning, TaskType.Warning, TaskType.Error)
        'Me.column = (error.Column - 1)
        'Me.line = (error.Line - 1)
        'Me.description = (error.ErrorText & "(" & error.ErrorNumber & ")")
        'Me.fileName = error.FileName
        '  End Sub
        Public Sub New(ByVal fileName As String, ByVal description As String, ByVal column As Integer, ByVal line As Integer)
            Me.New(fileName, description, column, line, Longkong.Pojjaman.Services.TaskType.SearchResult)
        End Sub
        Public Sub New(ByVal fileName As String, ByVal description As String, ByVal column As Integer, ByVal line As Integer, ByVal type As TaskType)
            Me.m_type = type
            Me.m_fileName = fileName
            Me.m_description = description.Trim
            Me.m_column = column
            Me.m_line = line
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Column() As Integer
            Get
                Return Me.m_column
            End Get
        End Property
        Public ReadOnly Property Description() As String
            Get
                Return Me.m_description
            End Get
        End Property
        Public Property FileName() As String
            Get
                Return Me.m_fileName
            End Get
            Set(ByVal value As String)
                Me.m_fileName = value
            End Set
        End Property
        Public ReadOnly Property Line() As Integer
            Get
                Return Me.m_line
            End Get
        End Property
        'Public ReadOnly Property Project() As IProject
        '    Get
        '        Return Me.m_project
        '    End Get
        'End Property
        Public ReadOnly Property TaskType() As TaskType
            Get
                Return Me.m_type
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub JumpToPosition()
            Dim service1 As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            service1.JumpToFilePosition(Me.m_fileName, Me.m_line, Me.m_column)
        End Sub
        Public Overrides Function ToString() As String
            Dim objArray1 As Object() = New Object() {Me.m_fileName, Me.m_line, Me.m_column, Me.m_type, Me.m_description}
            Return String.Format("[Task:File={0}, Line={1}, Column={2}, Type={3}, Description={4}", objArray1)
        End Function
#End Region

    End Class

    Public Enum TaskType
        [Error] = 0
        Warning = 1
        Comment = 2
        SearchResult = 3
    End Enum
End Namespace



