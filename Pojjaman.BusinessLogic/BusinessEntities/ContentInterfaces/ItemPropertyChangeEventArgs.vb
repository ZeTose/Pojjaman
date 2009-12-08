Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class ItemPropertyChangeEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_index As Integer
        Private m_propertyName As String
        Private m_oldValue As Object
        Private m_value As Object
#End Region

#Region "Constructors"
        Public Sub New(ByVal indx As Integer, ByVal name As String, ByVal oldVal As Object, ByVal newVal As Object)
            m_index = indx
            m_propertyName = name
            m_oldValue = oldVal
            m_value = newVal
        End Sub
#End Region

#Region "Properties"
        Public Property Index() As Integer            Get                Return m_index            End Get            Set(ByVal Value As Integer)                m_index = Value            End Set        End Property        Public Property PropertyName() As String            Get                Return m_propertyName            End Get            Set(ByVal Value As String)                m_propertyName = Value            End Set        End Property        Public Property OldValue() As Object            Get                Return m_oldValue            End Get            Set(ByVal Value As Object)                m_oldValue = Value            End Set        End Property        Public Property Value() As Object            Get                Return m_value            End Get            Set(ByVal Value As Object)                m_value = Value            End Set        End Property
#End Region

    End Class
    Public Delegate Sub ItemPropertyChangeHandler(ByVal sender As Object, ByVal e As ItemPropertyChangeEventArgs)

End Namespace