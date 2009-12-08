Namespace Longkong.Core.Services
    Public Interface IStringTagProvider
        Function [Convert](ByVal tag As String) As String
        ReadOnly Property Tags() As String()
    End Interface
End Namespace

