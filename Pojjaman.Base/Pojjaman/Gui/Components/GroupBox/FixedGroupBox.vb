Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui.Components
    Public Class FixedGroupBox
        Inherits GroupBox
        Private Const WM_PRINTCLIENT As Integer = &H318
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            If (m.Msg = WM_PRINTCLIENT) Then
                m.Result = IntPtr.op_Explicit(1)
            Else
                MyBase.WndProc(m)
            End If
        End Sub
    End Class
End Namespace