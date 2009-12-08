Namespace Longkong.Pojjaman.Gui
    Public Interface ISecondaryViewContent
        Inherits IBaseViewContent, IDisposable
        ' Methods
        Sub NotifyAfterSave(ByVal successful As Boolean)
        Sub NotifyBeforeSave()
    End Interface
    <Serializable()> _
    Public Class SecondaryViewContentCollection
        Inherits CollectionBase

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal value As SecondaryViewContentCollection)
            Me.AddRange(value)
        End Sub
        Public Sub New(ByVal value As ISecondaryViewContent())
            Me.AddRange(value)
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As ISecondaryViewContent
            Get
                Return CType(MyBase.List(index), ISecondaryViewContent)
            End Get
            Set(ByVal value As ISecondaryViewContent)
                MyBase.List(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function Add(ByVal value As ISecondaryViewContent) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As ISecondaryViewContent())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As SecondaryViewContentCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value.Item(i))
            Next
        End Sub
        Public Function Contains(ByVal value As ISecondaryViewContent) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As ISecondaryViewContent(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ISecondaryViewContentEnumerator
            Return New ISecondaryViewContentEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As ISecondaryViewContent) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As ISecondaryViewContent)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As ISecondaryViewContent)
            MyBase.List.Remove(value)
        End Sub
#End Region

        Public Class ISecondaryViewContentEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Constructors"
            Public Sub New(ByVal mappings As SecondaryViewContentCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

#Region "IEnumerator"
            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return Me.m_baseEnumerator.Current
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                Return Me.m_baseEnumerator.MoveNext
            End Function
            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                Me.m_baseEnumerator.Reset()
            End Sub
#End Region

        End Class
    End Class
End Namespace


