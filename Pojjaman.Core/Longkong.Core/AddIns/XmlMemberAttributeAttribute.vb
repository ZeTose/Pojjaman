Imports System
Imports System.Reflection
Namespace Longkong.Core.AddIns
    <AttributeUsage(AttributeTargets.Field, Inherited:=True)> _
    Public Class XmlMemberAttributeAttribute
        Inherits Attribute

#Region "Members"
        Private m_isRequired As Boolean
        Private m_name As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String)
            Me.m_name = name
            Me.m_isRequired = False
        End Sub
#End Region

#Region "Properties"
        Public Property IsRequired() As Boolean
            Get
                Return Me.m_isRequired
            End Get
            Set(ByVal value As Boolean)
                Me.m_isRequired = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return Me.m_name
            End Get
            Set(ByVal value As String)
                Me.m_name = value
            End Set
        End Property
#End Region

    End Class
End Namespace
