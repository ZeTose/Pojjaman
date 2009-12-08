Namespace Longkong.Core.AddIns.Codons
    <CodonName("Icon")> _
    Public Class IconCodon
        Inherits AbstractCodon

#Region "Constructors"
        <XmlMemberArray("extensions")> _
     Private m_extensions As String()
        <XmlMemberAttributeAttribute("language")> _
        Private m_language As String
        <Path(), XmlMemberAttributeAttribute("location")> _
        Private m_location As String
        <XmlMemberAttributeAttribute("resource")> _
        Private m_resource As String
#End Region

#Region "Constuctors"
        Public Sub New()
            Me.m_location = Nothing
            Me.m_language = Nothing
            Me.m_resource = Nothing
            Me.m_extensions = Nothing
        End Sub
#End Region

#Region "Properties"
        Public Property Extensions() As String()
            Get
                Return Me.m_extensions
            End Get
            Set(ByVal value As String())
                Me.m_extensions = value
            End Set
        End Property
        Public Property Language() As String
            Get
                Return Me.m_language
            End Get
            Set(ByVal value As String)
                Me.m_language = value
            End Set
        End Property
        Public Property Location() As String
            Get
                Return Me.m_location
            End Get
            Set(ByVal value As String)
                Me.m_location = value
            End Set
        End Property
        Public Property Resource() As String
            Get
                Return Me.m_resource
            End Get
            Set(ByVal value As String)
                Me.m_resource = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            If (subItems.Count > 0) Then
                Throw New ApplicationException("more than one level of icons don't make sense!")
            End If
            Return Me
        End Function
#End Region

    End Class
End Namespace

