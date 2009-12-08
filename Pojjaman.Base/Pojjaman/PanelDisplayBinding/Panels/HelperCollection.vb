Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Pads

Namespace Longkong.Pojjaman.Gui.Panels
    <Serializable(), DefaultMember("Item")> _
    Public Class HelperCollection
        Inherits CollectionBase

#Region "Members"
        Private m_owner As IHelperCapable
#End Region

#Region "Constructors"
        Public Sub New(ByVal owner As IHelperCapable)
            Me.m_owner = owner
        End Sub
        Public Sub New(ByVal owner As IHelperCapable, ByVal value As HelperCollection)
            Me.New(owner)
            Me.AddRange(value)
        End Sub
        Public Sub New(ByVal owner As IHelperCapable, ByVal value As IHelper())
            Me.New(owner)
            Me.AddRange(value)
        End Sub
#End Region

#Region "Methods"
        Public Function Add(ByVal value As IHelper) As Integer
            value.Owner = Me.m_owner
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As IHelper())
            For i As Integer = 0 To value.Length - 1
                value(i).Owner = Me.m_owner
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As HelperCollection)
            For i As Integer = 0 To value.Count - 1
                value(i).Owner = Me.m_owner
                Me.Add(value.Item(i))
            Next
        End Sub
        Public Function Contains(ByVal value As IHelper) As Boolean
            Return MyBase.List.Contains(value)
        End Function

        Public Sub CopyTo(ByVal array As IHelper(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As IHelperEnumerator
            Return New IHelperEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As IHelper) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As IHelper)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As IHelper)
            MyBase.List.Remove(value)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Owner() As IHelperCapable
            Get
                Return Me.m_owner
            End Get
        End Property
        Default Public ReadOnly Property Item(ByVal className As String) As IHelper
            Get
                For Each content As IHelper In Me
                    If TypeOf content Is IEntityPanel AndAlso (CType(content, IEntityPanel).Entity.ClassName.ToLower = className.ToLower) Then
                        Return content
                    End If
                Next
                Return Nothing
            End Get
        End Property
        Default Public Property Item(ByVal index As Integer) As IHelper
            Get
                Return CType(MyBase.List(index), IHelper)
            End Get
            Set(ByVal value As IHelper)
                MyBase.List(index) = value
            End Set
        End Property
#End Region

        Public Class IHelperEnumerator
            Implements IEnumerator

#Region "Members"
            Private baseEnumerator As IEnumerator
            Private temp As IEnumerable
#End Region

#Region "Constructos"
            Public Sub New(ByVal mappings As HelperCollection)
                Me.temp = mappings
                Me.baseEnumerator = Me.temp.GetEnumerator
            End Sub
#End Region

#Region "IEnumerator"
            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.baseEnumerator.Current, IHelper)
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

