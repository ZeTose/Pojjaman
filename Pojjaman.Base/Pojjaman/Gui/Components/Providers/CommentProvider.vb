Imports System.ComponentModel
Namespace Longkong.Pojjaman.Gui.Components
    <ProvideProperty("UserRole", GetType(Control))> _
    Public Class CommentProvider
        Inherits System.ComponentModel.Component
        Implements IExtenderProvider


        Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
            If Not TypeOf extendee Is CommentProvider Then
                Return True
            End If
        End Function

        Dim userRoleValues As New Hashtable

        Function GetUserRole(ByVal ctrl As Control) As String
            Dim value As Object = userRoleValues(ctrl)
            If IsNothing(value) Then
                Return ""
            Else
                Return value.ToString
            End If
        End Function

        Sub SetUserRole(ByVal ctrl As Control, ByVal value As String)
            If IsNothing(value) Then
                value = ""
            End If
            If value.Length = 0 And userRoleValues.Contains(ctrl) Then

            End If
        End Sub
    End Class
End Namespace
