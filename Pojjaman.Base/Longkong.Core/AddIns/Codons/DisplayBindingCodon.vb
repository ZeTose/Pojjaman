Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    <CodonName("DisplayBinding")> _
    Public Class DisplayBindingCodon
        Inherits AbstractCodon

#Region "Members"
        Private m_displayBinding As IDisplayBinding
        Private m_secondaryDisplayBinding As ISecondaryDisplayBinding
        <XmlMemberArray("supportedformats")> _
        Private m_supportedFormats As String()
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_displayBinding = Nothing
            Me.m_secondaryDisplayBinding = Nothing
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property DisplayBinding() As IDisplayBinding
            Get
                Return Me.m_displayBinding
            End Get
        End Property
        Public ReadOnly Property SecondaryDisplayBinding() As ISecondaryDisplayBinding
            Get
                Return Me.m_secondaryDisplayBinding
            End Get
        End Property
        Public Property SupportedFormats() As String()
            Get
                Return Me.m_supportedFormats
            End Get
            Set(ByVal value As String())
                Me.m_supportedFormats = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            Dim o As Object = MyBase.AddIn.CreateObject(MyBase.Class)
            Try
                Me.m_displayBinding = CType(o, IDisplayBinding)
                Me.m_secondaryDisplayBinding = CType(o, ISecondaryDisplayBinding)
            Catch ex As Exception
            End Try
            Return Me
        End Function
#End Region

    End Class
End Namespace
