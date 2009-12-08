Imports System.Reflection
Namespace Longkong.Core.AddIns.Codons
    Public Class CodonBuilder

#Region "Members"
        Private m_assembly As [Assembly]
        Private m_className As String
        Private m_codonName As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal className As String, ByVal [assembly] As [Assembly])
            Me.m_assembly = [assembly]
            Me.m_className = className
            Dim myCodonNameAttribute As CodonNameAttribute = CType(Attribute.GetCustomAttribute([assembly].GetType(Me.m_className), GetType(CodonNameAttribute)), CodonNameAttribute)
            Me.m_codonName = myCodonNameAttribute.Name
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property ClassName() As String
            Get
                Return Me.m_className
            End Get
        End Property
        Public ReadOnly Property CodonName() As String
            Get
                Return Me.m_codonName
            End Get
        End Property
#End Region

#Region "Methods"
        Public Function BuildCodon(ByVal addIn As AddIn) As ICodon
            Dim myCodon As ICodon
            Try
                myCodon = CType(Me.m_assembly.CreateInstance(Me.m_className, True), ICodon)
                myCodon.AddIn = addIn
            Catch ex As Exception
                myCodon = Nothing
            End Try
            Return myCodon
        End Function
#End Region

    End Class
End Namespace

