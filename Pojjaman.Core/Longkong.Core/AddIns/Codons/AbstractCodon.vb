Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    Public MustInherit Class AbstractCodon
        Implements ICodon

#Region "Members"
        Private m_addIn As AddIn
        <XmlMemberAttributeAttribute("id", IsRequired:=True)> _
        Private m_id As String
        <XmlMemberArray("insertafter")> _
        Private m_insertafter As String()
        <XmlMemberArray("insertbefore")> _
        Private m_insertbefore As String()
        <XmlMemberAttributeAttribute("class")> _
        Private [myClass] As String
#End Region

#Region "Constructors"
        Protected Sub New()
            Me.m_id = Nothing
            Me.myClass = Nothing
            Me.m_insertafter = Nothing
            Me.m_insertbefore = Nothing
            Me.m_addIn = Nothing
        End Sub
#End Region

#Region "ICodon"
        Public MustOverride Function BuildItem(ByVal owner As Object, ByVal subItems As ArrayList, ByVal conditions As ConditionCollection) As Object _
        Implements ICodon.BuildItem

        Public Property AddIn() As AddIn Implements ICodon.AddIn
            Get
                Return Me.m_addIn
            End Get
            Set(ByVal value As AddIn)
                Me.m_addIn = value
            End Set
        End Property
        Public ReadOnly Property [Class]() As String Implements ICodon.Class
            Get
                Return Me.[myClass]
            End Get
        End Property

        Public Overridable ReadOnly Property HandleConditions() As Boolean Implements ICodon.HandleConditions
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property ID() As String Implements ICodon.ID
            Get
                Return Me.m_id
            End Get
        End Property

        Public Property InsertAfter() As String() Implements ICodon.InsertAfter
            Get
                Return Me.m_insertafter
            End Get
            Set(ByVal Value() As String)
                Me.m_insertafter = Value
            End Set
        End Property

        Public ReadOnly Property InsertBefore() As String() Implements ICodon.InsertBefore
            Get
                Return Me.m_insertbefore
            End Get
        End Property

        Public ReadOnly Property Name() As String Implements ICodon.Name
            Get
                Dim myName As String = ""
                Dim myCodonNameAttribute As CodonNameAttribute = CType(Attribute.GetCustomAttribute(MyBase.GetType, GetType(CodonNameAttribute)), CodonNameAttribute)
                If (Not myCodonNameAttribute Is Nothing) Then
                    myName = myCodonNameAttribute.Name
                End If
                Return myName
            End Get
        End Property
#End Region

    End Class
End Namespace
