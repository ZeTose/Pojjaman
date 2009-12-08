Namespace Longkong.Pojjaman.Internal.Undo
    Public Class UndoStack

#Region "Members"
        Public AcceptChanges As Boolean
        Private m_redostack As Stack
        Private m_undostack As Stack
#End Region

#Region "Events"
        Public Event ActionRedone As EventHandler
        Public Event ActionUndone As EventHandler
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_undostack = New Stack
            Me.m_redostack = New Stack
            Me.AcceptChanges = True
        End Sub
#End Region

#Region "Properties"
        Friend ReadOnly Property UndoStack() As Stack
            Get
                Return Me.m_undostack
            End Get
        End Property
        Public ReadOnly Property CanRedo() As Boolean
            Get
                Return (Me.m_redostack.Count > 0)
            End Get
        End Property
        Public ReadOnly Property CanUndo() As Boolean
            Get
                Return (Me.m_undostack.Count > 0)
            End Get
        End Property

#End Region

#Region "Methods"
        Public Sub ClearAll()
            Me.m_undostack.Clear()
            Me.m_redostack.Clear()
        End Sub
        Public Sub ClearRedoStack()
            Me.m_redostack.Clear()
        End Sub
        Protected Sub OnActionRedone()
            RaiseEvent ActionRedone(Nothing, Nothing)
        End Sub
        Protected Sub OnActionUndone()
            RaiseEvent ActionUndone(Nothing, Nothing)
        End Sub
        Public Sub Push(ByVal operation As IUndoableOperation)
            If (operation Is Nothing) Then
                Throw New ArgumentNullException("UndoStack.Push(UndoableOperation operation) : operation can't be null")
            End If
            If Me.AcceptChanges Then
                Me.m_undostack.Push(operation)
                Me.ClearRedoStack()
            End If
        End Sub
        Public Sub Redo()
            If (Me.m_redostack.Count > 0) Then
                Dim operation As IUndoableOperation = CType(Me.m_redostack.Pop, IUndoableOperation)
                Me.m_undostack.Push(operation)
                operation.Redo()
                Me.OnActionRedone()
            End If
        End Sub
        Public Sub Undo()
            If (Me.m_undostack.Count > 0) Then
                Dim operation As IUndoableOperation = CType(Me.m_undostack.Pop, IUndoableOperation)
                Me.m_redostack.Push(operation)
                operation.Undo()
                Me.OnActionUndone()
            End If
        End Sub
        Public Sub UndoLast(ByVal x As Integer)
            Me.m_undostack.Push(New UndoQueue(Me, x))
        End Sub
#End Region

    End Class
End Namespace
