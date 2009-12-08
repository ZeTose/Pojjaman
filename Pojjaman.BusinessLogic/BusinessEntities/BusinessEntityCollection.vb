Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Namespace Longkong.Pojjaman.BusinessLogic
    <Serializable(), DefaultMember("Item")> _
Public Class BusinessEntityCollection
        Inherits CollectionBase

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As BusinessEntity
            Get
                Return CType(MyBase.List.Item(index), BusinessEntity)
            End Get
            Set(ByVal value As BusinessEntity)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overridable Function CreateTableStyle() As DataGridTableStyle

        End Function
        Public Overridable Function GetDataTable() As ExpandableRowDataTable

        End Function
        Public Function Add(ByVal value As BusinessEntity) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As BusinessEntityCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As BusinessEntity())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As BusinessEntity) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As BusinessEntity(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As BusinessEntityEnumerator
            Return New BusinessEntityEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As BusinessEntity) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As BusinessEntity)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As BusinessEntity)
            MyBase.List.Remove(value)
        End Sub
        Public Overridable Function Save() As Integer
            Debug.WriteLine("Implement Me!!! BusinessEntityCollection.Save")
        End Function
#End Region


        Public Class BusinessEntityEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As BusinessEntityCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, BusinessEntity)
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