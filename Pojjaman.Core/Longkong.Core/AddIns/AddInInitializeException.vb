Namespace Longkong.Core.AddIns
    Public Class AddInInitializeException
        Inherits Exception

#Region "Constructors"
        Public Sub New(ByVal fileName As String, ByVal e As Exception)
            MyBase.New("Could not load add-in file : " & fileName & ChrW(10) & " exception got :" & e.ToString)
        End Sub
#End Region

    End Class
End Namespace