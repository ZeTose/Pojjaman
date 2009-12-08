Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports System.IO
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class OwnerStateCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("ownerstate", IsRequired:=True)> _
        Private m_ownerstate As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property OwnerState() As String
            Get
                Return Me.m_ownerstate
            End Get
            Set(ByVal value As String)
                Me.m_ownerstate = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If TypeOf caller Is IOwnerState Then
                Try
                    Dim enum1 As [Enum] = CType(caller, IOwnerState).InternalState
                    Dim enum2 As [Enum] = CType([Enum].Parse(enum1.GetType, Me.m_ownerstate), [Enum])
                    Dim num1 As Integer = Integer.Parse(enum1.ToString("D"))
                    Dim num2 As Integer = Integer.Parse(enum2.ToString("D"))
                    Return ((num1 And num2) > 0)
                Catch ex As Exception
                    Throw New ApplicationException(("can't parse '" & Me.m_ownerstate & "'. Not a valid value."))
                End Try
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
