Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Delegate Sub CodeDescriptionsEventHandler(ByVal sender As Object, ByVal e As CodeDescriptionsEventArgs)

    Public Class CodeDescriptionsEventArgs

#Region "Members"
        Private m_key As String
        Private m_newValue As Object
        Private m_oldValue As Object
        Private m_codeDescriptions As ICodeDescriptions
#End Region

#Region "Costructors"
        Public Sub New(ByVal codeDescriptions As ICodeDescriptions, ByVal key As String, ByVal oldValue As Object, ByVal newValue As Object)
            Me.m_codeDescriptions = codeDescriptions
            Me.m_key = key
            Me.m_oldValue = oldValue
            Me.m_newValue = newValue
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Key() As String
            Get
                Return Me.m_key
            End Get
        End Property
        Public ReadOnly Property NewValue() As Object
            Get
                Return Me.m_newValue
            End Get
        End Property
        Public ReadOnly Property OldValue() As Object
            Get
                Return Me.m_oldValue
            End Get
        End Property
        Public ReadOnly Property CodeDescriptions() As ICodeDescriptions
            Get
                Return Me.m_codeDescriptions
            End Get
        End Property
#End Region

    End Class
End Namespace
