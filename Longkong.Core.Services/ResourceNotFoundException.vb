Namespace Longkong.Core.Services
    Public Class ResourceNotFoundException
        Inherits Exception

#Region "Constructors"
        Public Sub New(ByVal resource As String)
            MyBase.New("Resource not found : " & resource)
        End Sub
#End Region

    End Class
End Namespace

