Imports System.Xml
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Collections.Specialized
Namespace Longkong.Pojjaman.Internal.Templates
    Public Class FileDescriptionTemplate

#Region "Members"
        Private m_content As String
        Private m_language As String
        Private m_name As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String, ByVal language As String, ByVal content As String)
            Me.m_name = name
            Me.m_language = language
            Me.m_content = content
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Content() As String
            Get
                Return Me.m_content
            End Get
        End Property
        Public ReadOnly Property Language() As String
            Get
                Return Me.m_language
            End Get
        End Property
        Public ReadOnly Property Name() As String
            Get
                Return Me.m_name
            End Get
        End Property
#End Region

    End Class
End Namespace




