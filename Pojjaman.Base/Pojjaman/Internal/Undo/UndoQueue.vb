Namespace Longkong.Pojjaman.Internal.Undo
    Public Class UndoQueue
        Implements IUndoableOperation

#Region "Members"
        Private m_undolist As ArrayList
#End Region

#Region "Constructors"
        Public Sub New(ByVal stack As UndoStack, ByVal numops As Integer)
            Me.m_undolist = New ArrayList
            If (stack Is Nothing) Then
                Throw New ArgumentNullException("undo stack cannot be nothing")
            End If
            For i As Integer = 0 To numops - 1
                If (stack.UndoStack.Count > 0) Then
                    Me.m_undolist.Add(stack.UndoStack.Pop)
                End If
            Next
        End Sub
#End Region

#Region "IUndoableOperation"
        Public Sub Redo() Implements IUndoableOperation.Redo
            Dim undoCount As Integer = (Me.m_undolist.Count - 1)
            Do While (undoCount >= 0)
                CType(Me.m_undolist(undoCount), IUndoableOperation).Redo()
                undoCount -= 1
            Loop
        End Sub

        Public Sub Undo() Implements IUndoableOperation.Undo
            Dim undoCount As Integer
            For undoCount = 0 To Me.m_undolist.Count - 1
                CType(Me.m_undolist.Item(undoCount), IUndoableOperation).Undo()
            Next
        End Sub
#End Region

    End Class
End Namespace
