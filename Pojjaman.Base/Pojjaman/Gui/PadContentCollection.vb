Imports System.Reflection
Namespace Longkong.Pojjaman.Gui
    <Serializable(), DefaultMember("Item")> _
    Public Class PadContentCollection
        Inherits CollectionBase

#Region "Constructors"
        Public Sub New(ByVal value As PadContentCollection)
            Me.AddRange(value)
        End Sub
        Public Sub New(ByVal value As IPadContent())
            Me.AddRange(value)
        End Sub
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Function Add(ByVal value As IPadContent) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As IPadContent())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As PadContentCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value.Item(i))
            Next
        End Sub
        Public Function Contains(ByVal value As IPadContent) As Boolean
            Return MyBase.List.Contains(value)
        End Function

        Public Sub CopyTo(ByVal array As IPadContent(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As IPadContentEnumerator
            Return New IPadContentEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As IPadContent) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As IPadContent)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As IPadContent)
            MyBase.List.Remove(value)
        End Sub
#End Region

#Region "Properties"
        Default Public ReadOnly Property Item(ByVal typeName As String) As IPadContent
            Get
                For Each content As IPadContent In Me
                    If (CType(content, Object).GetType.FullName Is typeName) Then
                        Return content
                    End If
                Next
                Return Nothing
            End Get
        End Property
        Default Public Property Item(ByVal index As Integer) As IPadContent
            Get
                Return CType(MyBase.List(index), IPadContent)
            End Get
            Set(ByVal value As IPadContent)
                MyBase.List(index) = value
            End Set
        End Property
#End Region

        Public Class IPadContentEnumerator
            Implements IEnumerator

#Region "Members"
            Private baseEnumerator As IEnumerator
            Private temp As IEnumerable
#End Region

#Region "Constructos"
            Public Sub New(ByVal mappings As PadContentCollection)
                Me.temp = mappings
                Me.baseEnumerator = Me.temp.GetEnumerator
            End Sub
#End Region

#Region "IEnumerator"
            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.baseEnumerator.Current, IPadContent)
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
    End Class
End Namespace