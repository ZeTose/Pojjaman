Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Components
    <Serializable(), DefaultMember("Item")> _
Public Class ColorCollection
        Inherits CollectionBase


#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As Color
            Get
                Return CType(MyBase.List.Item(index), Color)
            End Get
            Set(ByVal value As Color)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function Add(ByVal value As Color) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As ColorCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As Color())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As Color) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As Color(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ColorEnumerator
            Return New ColorEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As Color) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As Color)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As Color)
            MyBase.List.Remove(value)
        End Sub
#End Region


        Public Class ColorEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As ColorCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, Color)
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
