Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui
Imports Longkong.WinFormsUI
Namespace Longkong.Core.AddIns.Codons
    <CodonName("Pad")> _
    Public Class PadCodon
        Inherits ClassCodon

#Region "Members"
        <XmlMemberAttributeAttribute("category")> _
        Private m_category As String
        <XmlMemberArray("shortcut", Separator:="|"c)> _
        Private m_shortcut As String()
        <XmlMemberArray("dockareas", Separator:="|"c)> _
        Private m_dockAreas As String()
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_category = Nothing
            Me.m_shortcut = Nothing
            Me.m_dockAreas = Nothing
        End Sub
#End Region

#Region "Properties"
        Public Property Category() As String
            Get
                Return Me.m_category
            End Get
            Set(ByVal value As String)
                Me.m_category = value
            End Set
        End Property
        Public Property Shortcut() As String()
            Get
                Return Me.m_shortcut
            End Get
            Set(ByVal value As String())
                Me.m_shortcut = value
            End Set
        End Property
        Public Property DockAreas() As String()
            Get
                Return Me.m_dockAreas
            End Get
            Set(ByVal Value As String())
                m_dockAreas = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As ArrayList, ByVal conditions As ConditionCollection) As Object
            Dim pad As IPadContent = CType(MyBase.BuildItem(owner, subItems, conditions), IPadContent)
            pad.Category = Me.m_category
            pad.Shortcut = Me.m_shortcut
            pad.DockAreas = Me.m_dockAreas
            Return pad
        End Function
#End Region

    End Class
End Namespace
