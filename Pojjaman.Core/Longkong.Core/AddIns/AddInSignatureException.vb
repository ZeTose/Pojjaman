Namespace Longkong.Core.AddIns
    Public Class AddInSignatureException
        Inherits Exception

#Region "Constructors"
        Public Sub New(ByVal msg As String)
            MyBase.New("signature failure : " & msg)
        End Sub
#End Region

    End Class
End Namespace
