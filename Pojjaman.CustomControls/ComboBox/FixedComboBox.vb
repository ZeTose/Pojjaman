Namespace Longkong.Pojjaman.Gui.Components
    Public Class FixedComboBox
        Inherits ComboBox

        Implements IMessageFilter

        Private Const WM_PAINT As Integer = &HF

        Private iSelectChangeCommit As Boolean = False

        ''' <summary>
        ''' Fires when a selection change has completed and before the control is
        ''' painted.
        ''' </summary>
        Public Event SelectionChangeCompleted(ByVal sender As Object, ByVal e As System.EventArgs)

        Public Sub New()
            Application.AddMessageFilter(Me)
        End Sub

        Private Sub MyComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectionChangeCommitted
            iSelectChangeCommit = True
        End Sub

        Private Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
            If m.Msg = WM_PAINT AndAlso iSelectChangeCommit Then
                RaiseEvent SelectionChangeCompleted(Me, Nothing)
                Me.SelectionStart = 0
                Me.SelectionLength = Len(Me.Text)
                iSelectChangeCommit = False
            End If
        End Function
    End Class
End Namespace

