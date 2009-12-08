Namespace Longkong.Core.AddIns
    Public Class AddInTreeFormatException
        Inherits Exception

#Region "Constructors"
        Public Sub New(ByVal msg As String)
            MyBase.New("error reading the addin xml : " & msg)
        End Sub
#End Region

    End Class
End Namespace
