Imports System.Reflection
Namespace Longkong.Pojjaman.Internal.Project.Collections
    <Serializable(), DefaultMember("Item")> _
    Public Class ConfigurationCollection
        Inherits CollectionBase

#Region "Events"
        Public Event ItemAdded As EventHandler
        Public Event ItemRemoved As EventHandler
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal val As IConfiguration())
            Me.AddRange(val)
        End Sub
        Public Sub New(ByVal val As ConfigurationCollection)
            Me.AddRange(val)
            Me.OnItemAdded()
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As IConfiguration
            Get
                Return CType(MyBase.List.Item(index), IConfiguration)
            End Get
            Set(ByVal value As IConfiguration)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function Add(ByVal val As IConfiguration) As Integer
            Dim num1 As Integer = MyBase.List.Add(val)
            Me.OnItemAdded()
            Return num1
        End Function
        Public Sub AddRange(ByVal val As IConfiguration())
            Dim num1 As Integer
            For num1 = 0 To val.Length - 1
                Me.Add(val(num1))
            Next num1
            Me.OnItemAdded()
        End Sub
        Public Sub AddRange(ByVal val As ConfigurationCollection)
            Dim num1 As Integer
            For num1 = 0 To val.Count - 1
                Me.Add(val.Item(num1))
            Next num1
            Me.OnItemAdded()
        End Sub
        Public Function Contains(ByVal val As IConfiguration) As Boolean
            Return MyBase.List.Contains(val)
        End Function
        Public Sub CopyTo(ByVal array As IConfiguration(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As IConfigurationEnumerator
            Return New IConfigurationEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal val As IConfiguration) As Integer
            Return MyBase.List.IndexOf(val)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal val As IConfiguration)
            MyBase.List.Insert(index, val)
            Me.OnItemAdded()
        End Sub
        Protected Sub OnItemAdded()
            RaiseEvent ItemAdded(Me, EventArgs.Empty)
        End Sub
        Protected Sub OnItemRemoved()
            RaiseEvent ItemRemoved(Me, EventArgs.Empty)
        End Sub
        Public Sub Remove(ByVal val As IConfiguration)
            MyBase.List.Remove(val)
            Me.OnItemRemoved()
        End Sub
#End Region


#Region "IConfigurationEnumerator Class"
        Public Class IConfigurationEnumerator
            Implements IEnumerator

#Region "Members"
            Private baseEnumerator As IEnumerator
            Private temp As IEnumerable
#End Region

#Region "Constructors"
            Public Sub New(ByVal mappings As ConfigurationCollection)
                Me.temp = mappings
                Me.baseEnumerator = Me.temp.GetEnumerator
            End Sub
#End Region

#Region "IEnumerator"
            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.baseEnumerator.Current, IConfiguration)
                End Get
            End Property
            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                Return Me.baseEnumerator.MoveNext
            End Function
            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                Me.baseEnumerator.Reset()
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace




