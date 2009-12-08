Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Components
    Public Class MultiLineTextBox
        Inherits TextBox

#Region "Overrides"
        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            Dim keyCode As Keys = CType((msg.WParam.ToInt32), Keys)
            Select Case keyCode
                Case Keys.Enter
                    Return True
            End Select
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function
#End Region

    End Class
End Namespace

