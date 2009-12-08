Namespace Longkong.Core.AddIns
    Public Class TreePathNotFoundException
        Inherits Exception
#Region "Constructors"
        Public Sub New(ByVal path As String)
            MyBase.New("Treepath not found : " & path)
        End Sub
#End Region
    End Class
End Namespace
