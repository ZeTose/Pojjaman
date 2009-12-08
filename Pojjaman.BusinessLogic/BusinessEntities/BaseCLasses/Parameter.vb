Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class Parameter

#Region "Members"
        Private m_name As String
        Private m_value As Object
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String, ByVal value As Object)
            Me.m_name = name
            Me.m_value = value
        End Sub
#End Region

#Region "Properties"
        Public Property Name() As String            Get                Return m_name            End Get            Set(ByVal Value As String)                m_name = Value            End Set        End Property        Public Property Value() As Object            Get                Return m_value            End Get            Set(ByVal Value As Object)                m_value = Value            End Set        End Property
#End Region

    End Class

End Namespace
