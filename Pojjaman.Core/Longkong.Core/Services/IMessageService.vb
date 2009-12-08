Namespace Longkong.Core.Services
    Public Interface IMessageService
        Function AskQuestion(ByVal question As String) As Boolean
        Function AskQuestion(ByVal question As String, ByVal caption As String) As Boolean
        Function AskQuestionFormatted(ByVal formatstring As String, ByVal ParamArray formatitems As String()) As Boolean
        Function AskQuestionFormatted(ByVal caption As String, ByVal formatstring As String, ByVal ParamArray formatitems As String()) As Boolean
        Function ShowCustomDialog(ByVal caption As String, ByVal dialogText As String, ByVal ParamArray buttontexts As String()) As Integer
        Sub ShowError(ByVal ex As Exception)
        Sub ShowError(ByVal message As String)
        Sub ShowError(ByVal ex As Exception, ByVal message As String)
        Sub ShowErrorFormatted(ByVal formatstring As String, ByVal ParamArray formatitems As String())
        Sub ShowMessage(ByVal message As String)
        Sub ShowMessage(ByVal message As String, ByVal caption As String)
        Sub ShowMessageFormatted(ByVal formatstring As String, ByVal ParamArray formatitems As String())
        Sub ShowMessageFormatted(ByVal caption As String, ByVal formatstring As String, ByVal ParamArray formatitems As String())
        Sub ShowWarning(ByVal message As String)
        Sub ShowWarningFormatted(ByVal formatstring As String, ByVal ParamArray formatitems As String())
    End Interface
End Namespace

