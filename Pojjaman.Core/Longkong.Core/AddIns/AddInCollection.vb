Imports System.Reflection
Namespace Longkong.Core.AddIns
    <Serializable()> _
    Public Class AddInCollection
        Inherits CollectionBase

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As AddIn
            Get
                Return CType(MyBase.List(index), AddIn)
            End Get
            Set(ByVal value As AddIn)
                MyBase.List(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function Add(ByVal value As AddIn) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Function Contains(ByVal value As AddIn) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Shadows Function GetEnumerator() As AddInEnumerator 'TODO: Shadows?
            Return New AddInEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As AddIn) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Remove(ByVal value As AddIn)
            MyBase.List.Remove(value)
        End Sub
#End Region

        Public Class AddInEnumerator
            Implements IEnumerator

#Region "Membes"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As AddInCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, AddIn)
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                Return Me.m_baseEnumerator.MoveNext
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                Me.m_baseEnumerator.Reset()
            End Sub

        End Class
    End Class
End Namespace

