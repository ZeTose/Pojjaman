Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Namespace Longkong.Pojjaman.Services
    Public Class PaneEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_type As Type
        Private m_args As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal type As Type, ByVal args As String)
            Me.m_type = type
        End Sub
#End Region

#Region "Properties"
        Public Property Type() As Type            Get                Return m_type            End Get            Set(ByVal Value As Type)                m_type = Value            End Set        End Property        Public Property Args() As String            Get                Return m_args            End Get            Set(ByVal Value As String)                m_args = Value            End Set        End Property
#End Region
    End Class
End Namespace



