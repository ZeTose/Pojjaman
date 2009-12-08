Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Core.AddIns.Codons
    <CodonName("DialogPanel")> _
    Public Class DialogPanelCodon
        Inherits AbstractCodon

#Region "Members"
        <XmlMemberAttributeAttribute("label", IsRequired:=True)> _
        Private m_label As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_label = Nothing
        End Sub
#End Region

#Region "Properties"
        Public Property Label() As String
            Get
                Return Me.m_label
            End Get
            Set(ByVal value As String)
                Me.m_label = value
            End Set
        End Property
#End Region

#Region "Methods"

        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            If ((subItems Is Nothing) OrElse (subItems.Count = 0)) Then
                If (Not MyBase.Class Is Nothing) Then
                    Return New DefaultDialogPanelDescriptor(MyBase.ID, myStringParserService.Parse(Me.Label), CType(MyBase.AddIn.CreateObject(MyBase.Class), IDialogPanel))
                End If
                Return New DefaultDialogPanelDescriptor(MyBase.ID, myStringParserService.Parse(Me.Label))
            End If
            Return New DefaultDialogPanelDescriptor(MyBase.ID, myStringParserService.Parse(Me.Label), subItems)
        End Function
#End Region

    End Class
End Namespace
