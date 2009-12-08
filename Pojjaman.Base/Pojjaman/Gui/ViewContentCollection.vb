Namespace Longkong.Pojjaman.Gui
    Public Class ViewContentEventArgs
        Inherits EventArgs
        Private m_content As IViewContent
        ' Methods
        Public Sub New(ByVal content As IViewContent)
            Me.m_content = content
        End Sub
        Public Property Content() As IViewContent
            Get
                Return m_content
            End Get
            Set(ByVal Value As IViewContent)
                m_content = Value
            End Set
        End Property
    End Class
    <Serializable()> _
    Public Class ViewContentCollection
        Inherits CollectionBase

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal value As ViewContentCollection)
            Me.AddRange(value)
        End Sub
        Public Sub New(ByVal value As IViewContent())
            Me.AddRange(value)
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As IViewContent
            Get
                Return CType(MyBase.List(index), IViewContent)
            End Get
            Set(ByVal value As IViewContent)
                MyBase.List(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function Add(ByVal value As IViewContent) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As IViewContent())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As ViewContentCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value.Item(i))
            Next
        End Sub
        Public Function Contains(ByVal value As IViewContent) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As IViewContent(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As IViewContentEnumerator
            Return New IViewContentEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As IViewContent) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As IViewContent)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As IViewContent)
            MyBase.List.Remove(value)
        End Sub
#End Region

        Public Class IViewContentEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Constructors"
            Public Sub New(ByVal mappings As ViewContentCollection)
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