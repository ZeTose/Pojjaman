Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Namespace Longkong.Pojjaman.Services
    Public Class FileEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_fileName As String
        Private m_isDirectory As Boolean
        Private m_sourceFile As String
        Private m_targetFile As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal fileName As String, ByVal isDirectory As Boolean)
            Me.m_sourceFile = Nothing
            Me.m_targetFile = Nothing
            Me.m_fileName = fileName
            Me.m_isDirectory = isDirectory
        End Sub
        Public Sub New(ByVal sourceFile As String, ByVal targetFile As String, ByVal isDirectory As Boolean)
            Me.m_fileName = Nothing
            Me.m_sourceFile = sourceFile
            Me.m_targetFile = targetFile
            Me.m_isDirectory = isDirectory
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property FileName() As String
            Get
                Return Me.m_fileName
            End Get
        End Property
        Public ReadOnly Property IsDirectory() As Boolean
            Get
                Return Me.m_isDirectory
            End Get
        End Property
        Public ReadOnly Property SourceFile() As String
            Get
                Return Me.m_sourceFile
            End Get
        End Property
        Public ReadOnly Property TargetFile() As String
            Get
                Return Me.m_targetFile
            End Get
        End Property

#End Region

    End Class
End Namespace



