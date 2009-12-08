Namespace Longkong.Core.AddIns.Codons
    <AttributeUsage(AttributeTargets.Class, Inherited:=False, AllowMultiple:=False)> _
    Public Class CodonNameAttribute
        Inherits Attribute

#Region "Members"
        Private m_name As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String)
            Me.m_name = name
        End Sub
#End Region

#Region "Properties"
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



