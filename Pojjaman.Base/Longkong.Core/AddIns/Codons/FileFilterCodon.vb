Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    <CodonName("FileFilter")> _
    Public Class FileFilterCodon
        Inherits AbstractCodon

#Region "Members"
        <XmlMemberArray("extensions", IsRequired:=True)> _
        Private m_extensions As String()
        <XmlMemberAttributeAttribute("name", IsRequired:=True)> _
        Private m_filtername As String
#End Region

#Region "Construcors"
        Public Sub New()
            Me.m_filtername = Nothing
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
        Public Property FilterName() As String
            Get
                Return Me.m_filtername
            End Get
            Set(ByVal value As String)
                Me.m_filtername = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            If (subItems.Count > 0) Then
                Throw New ApplicationException("more than one level of file filters don't make sense!")
            End If
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Return (myStringParserService.Parse(Me.m_filtername) & "|" & String.Join(";", Me.m_extensions))
        End Function
#End Region

    End Class
End Namespace
