Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    <CodonName("ToolbarItem")> _
    Public Class ToolbarItemCodon
        Inherits AbstractCodon

#Region "Members"
        Private m_conditions As ConditionCollection
        Private m_enabled As Boolean
        <XmlMemberAttributeAttribute("icon")> _
        Private m_icon As String
        Private m_subItems As ArrayList
        <XmlMemberAttributeAttribute("tooltip")> _
        Private m_toolTip As String
        <XmlMemberAttributeAttribute("label")> _
        Private m_label As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_icon = Nothing
            Me.m_toolTip = Nothing
            Me.m_subItems = Nothing
            Me.m_enabled = True
        End Sub
#End Region

#Region "Properties"
        Public Property Label() As String            Get                Return m_label            End Get            Set(ByVal Value As String)                m_label = Value            End Set        End Property
        Public ReadOnly Property Conditions() As ConditionCollection
            Get
                Return Me.m_conditions
            End Get
        End Property
        Public Property Enabled() As Boolean
            Get
                Return Me.m_enabled
            End Get
            Set(ByVal value As Boolean)
                Me.m_enabled = value
            End Set
        End Property
        Public Overrides ReadOnly Property HandleConditions() As Boolean
            Get
                Return True
            End Get
        End Property
        Public Property Icon() As String
            Get
                Return Me.m_icon
            End Get
            Set(ByVal value As String)
                Me.m_icon = value
            End Set
        End Property
        Public Property SubItems() As ArrayList
            Get
                Return Me.m_subItems
            End Get
            Set(ByVal value As ArrayList)
                Me.m_subItems = value
            End Set
        End Property
        Public Property ToolTip() As String
            Get
                Return Me.m_toolTip
            End Get
            Set(ByVal value As String)
                Me.m_toolTip = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            Me.m_subItems = subItems
            Me.m_enabled = False
            Me.m_conditions = conditions
            Return Me
        End Function
#End Region

    End Class
End Namespace
