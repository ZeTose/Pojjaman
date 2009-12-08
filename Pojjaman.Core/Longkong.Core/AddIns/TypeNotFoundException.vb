Namespace Longkong.Core.AddIns
    Public Class TypeNotFoundException
        Inherits Exception

#Region "Cionstructors"
        Public Sub New(ByVal typeName As String)
            MyBase.New("Unable to create object from type : " & typeName)
        End Sub
#End Region

    End Class
End Namespace
