Namespace Longkong.Core.AddIns
    Public Class DuplicateCodonException
        Inherits Exception

#Region "Constructors"
        Public Sub New(ByVal codon As String)
            MyBase.New("there already exists a codon with name : " & codon)
        End Sub
#End Region

    End Class
End Namespace
