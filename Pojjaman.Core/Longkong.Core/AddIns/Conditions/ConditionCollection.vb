Imports System.Reflection
Namespace Longkong.Core.AddIns.Conditions
    <Serializable(), DefaultMember("Item")> _
    Public Class ConditionCollection
        Inherits CollectionBase

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal value As ConditionCollection)
            Me.AddRange(value)
        End Sub
        Public Sub New(ByVal value As ICondition())
            Me.AddRange(value)
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As ICondition
            Get
                Return CType(MyBase.List.Item(index), ICondition)
            End Get
            Set(ByVal value As ICondition)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function Add(ByVal value As ICondition) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As ConditionCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As ICondition())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As ICondition) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As ICondition(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Function GetCurrentConditionFailedAction(ByVal caller As Object) As ConditionFailedAction
            Dim action As ConditionFailedAction = ConditionFailedAction.Nothing
            For Each condition As ICondition In Me
                If Not condition.IsValid(caller) Then
                    If (condition.Action = ConditionFailedAction.Disable) Then
                        action = ConditionFailedAction.Disable
                    Else
                        action = ConditionFailedAction.Exclude
                        Return action
                    End If
                End If
            Next
            Return action
        End Function
        Public Shadows Function GetEnumerator() As IConditionEnumerator 'TODO :Shadows?
            Return New IConditionEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As ICondition) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As ICondition)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As ICondition)
            MyBase.List.Remove(value)
        End Sub
#End Region

        Public Class IConditionEnumerator
            Implements IEnumerator

#Region "Membes"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As ConditionCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, ICondition)
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

