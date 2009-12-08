Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Commands
Namespace Longkong.Core.AddIns.Codons
    <CodonName("EntityTab")> _
    Public Class EntityTabCodon
        Inherits AbstractCodon

#Region "Members"
        <XmlMemberAttributeAttribute("view")> _
        Private m_view As String
        <XmlMemberAttributeAttribute("enity")> _
        Private m_entity As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_view = Nothing
            Me.m_entity = Nothing
        End Sub
#End Region

#Region "Properties"
        Public Property View() As String
            Get
                Return Me.m_view
            End Get
            Set(ByVal value As String)
                Me.m_view = value
            End Set
        End Property
        Public Property Entity() As String            Get                Return m_entity            End Get            Set(ByVal Value As String)                m_entity = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            Dim tab As Object = Nothing
            If (Not Me.View Is Nothing) Then
                tab = MyBase.AddIn.CreateObject(Me.View)
            End If
            If tab Is Nothing Then
                Dim tabs As New Pojjaman.Gui.SecondaryViewContentCollection
                If ((Not subItems Is Nothing) AndAlso (subItems.Count > 0)) Then
                    For Each item As Object In subItems
                        If (Not item Is Nothing) Then
                            If TypeOf item Is Pojjaman.Gui.ISecondaryViewContent Then
                                tabs.Add(CType(item, Pojjaman.Gui.ISecondaryViewContent))
                            Else
                                MessageBox.Show("Missing Form:" & item.ToString)
                            End If
                        End If
                    Next
                End If
                Return tabs
            End If
            Return tab
        End Function
#End Region

    End Class
    <CodonName("EntityFilter")> _
    Public Class EntityFilterCodon
        Inherits AbstractCodon

#Region "Members"
        <XmlMemberAttributeAttribute("filter")> _
        Private m_filter As String
        <XmlMemberAttributeAttribute("enity")> _
        Private m_entity As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_filter = Nothing
            Me.m_entity = Nothing
        End Sub
#End Region

#Region "Properties"
        Public Property FilterPanel() As String
            Get
                Return Me.m_filter
            End Get
            Set(ByVal value As String)
                Me.m_filter = value
            End Set
        End Property
        Public Property Entity() As String            Get                Return m_entity            End Get            Set(ByVal Value As String)                m_entity = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            Dim panel As Object = Nothing
            If (Not Me.FilterPanel Is Nothing) Then
                panel = MyBase.AddIn.CreateObject(Me.FilterPanel)
            End If
            Return panel
        End Function
#End Region

    End Class
    <CodonName("PreAddView")> _
 Public Class PreAddViewCodon
        Inherits AbstractCodon

#Region "Members"
        <XmlMemberAttributeAttribute("view")> _
        Private m_view As String
        <XmlMemberAttributeAttribute("enity")> _
        Private m_entity As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_view = Nothing
            Me.m_entity = Nothing
        End Sub
#End Region

#Region "Properties"
        Public Property View() As String
            Get
                Return Me.m_view
            End Get
            Set(ByVal value As String)
                Me.m_view = value
            End Set
        End Property
        Public Property Entity() As String            Get                Return m_entity            End Get            Set(ByVal Value As String)                m_entity = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            Dim panel As Object = Nothing
            If (Not Me.View Is Nothing) Then
                panel = MyBase.AddIn.CreateObject(Me.View)
            End If
            Return panel
        End Function
#End Region


    End Class
    <CodonName("EntityListView")> _
Public Class EntityListViewCodon
        Inherits AbstractCodon

#Region "Members"
        <XmlMemberAttributeAttribute("view")> _
        Private m_view As String
        <XmlMemberAttributeAttribute("enity")> _
        Private m_entity As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_view = Nothing
            Me.m_entity = Nothing
        End Sub
#End Region

#Region "Properties"
        Public Property View() As String
            Get
                Return Me.m_view
            End Get
            Set(ByVal value As String)
                Me.m_view = value
            End Set
        End Property
        Public Property Entity() As String            Get                Return m_entity            End Get            Set(ByVal Value As String)                m_entity = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            Dim panel As Object = Nothing
            If (Not Me.View Is Nothing) Then
                If TypeOf owner Is Object() Then
                    panel = MyBase.AddIn.CreateObject(Me.View, CType(owner, Object()))
                Else
                    panel = MyBase.AddIn.CreateObject(Me.View)
                End If
            End If
            Return panel
        End Function
#End Region

    End Class
End Namespace
