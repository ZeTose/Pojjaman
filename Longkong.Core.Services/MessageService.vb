Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections
Imports System.Threading
Imports System.Resources
Imports System.Drawing
Imports System.Diagnostics
Imports System.Reflection
Imports System.Xml
Imports System.Configuration
Imports System.Globalization
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns
Namespace Longkong.Core.Services
    Public Class MessageService
        Inherits AbstractService
        Implements IMessageService

#Region "Members"
        Private m_stringParserService As StringParserService
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End Sub
#End Region

#Region "Methods"

#End Region

#Region "IMessageService"
        Public Overloads Function AskQuestion(ByVal question As String) As Boolean Implements IMessageService.AskQuestion
            Return Me.AskQuestion(Me.m_stringParserService.Parse(question), Me.m_stringParserService.Parse("${res:Global.QuestionText}"))
        End Function

        Public Overloads Function AskQuestion(ByVal question As String, ByVal caption As String) As Boolean Implements IMessageService.AskQuestion
            Return (MessageBox.Show(Me.m_stringParserService.Parse(question), Me.m_stringParserService.Parse(caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)
        End Function

        Public Overloads Function AskQuestionFormatted(ByVal caption As String, ByVal formatstring As String, ByVal ParamArray formatitems() As String) As Boolean Implements IMessageService.AskQuestionFormatted
            Return Me.AskQuestion(String.Format(Me.m_stringParserService.Parse(formatstring), formatitems), caption)
        End Function

        Public Overloads Function AskQuestionFormatted(ByVal formatstring As String, ByVal ParamArray formatitems() As String) As Boolean Implements IMessageService.AskQuestionFormatted
            Return Me.AskQuestion(String.Format(Me.m_stringParserService.Parse(formatstring), formatitems))
        End Function

        Public Function ShowCustomDialog(ByVal caption As String, ByVal dialogText As String, ByVal ParamArray buttontexts() As String) As Integer Implements IMessageService.ShowCustomDialog
            Return 0
        End Function

        Public Overloads Sub ShowError(ByVal message As String) Implements IMessageService.ShowError
            Me.ShowError(Nothing, message)
        End Sub

        Public Overloads Sub ShowError(ByVal ex As System.Exception) Implements IMessageService.ShowError
            Me.ShowError(ex, Nothing)
        End Sub

        Public Overloads Sub ShowError(ByVal ex As System.Exception, ByVal message As String) Implements IMessageService.ShowError
            Dim msg As String = String.Empty
            If (Not message Is Nothing) Then
                msg = (msg & message)
            End If
            If ((Not message Is Nothing) AndAlso (Not ex Is Nothing)) Then
                msg = (msg & ChrW(10) & ChrW(10))
            End If
            If (Not ex Is Nothing) Then
                msg = (msg & "Exception occurred: " & ex.ToString)
            End If
            MessageBox.Show(Me.m_stringParserService.Parse(msg), Me.m_stringParserService.Parse("${res:Global.ErrorText}"), MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Sub

        Public Sub ShowErrorFormatted(ByVal formatstring As String, ByVal ParamArray formatitems() As String) Implements IMessageService.ShowErrorFormatted
            Me.ShowError(Nothing, String.Format(Me.m_stringParserService.Parse(formatstring), formatitems))
        End Sub

        Public Overloads Sub ShowMessage(ByVal message As String) Implements IMessageService.ShowMessage
            Me.ShowMessage(message, "Pojjaman")
        End Sub

        Public Overloads Sub ShowMessage(ByVal message As String, ByVal caption As String) Implements IMessageService.ShowMessage
            MessageBox.Show(Me.m_stringParserService.Parse(message), Me.m_stringParserService.Parse(caption), MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Sub

        Public Overloads Sub ShowMessageFormatted(ByVal caption As String, ByVal formatstring As String, ByVal ParamArray formatitems() As String) Implements IMessageService.ShowMessageFormatted
            Me.ShowMessage(String.Format(Me.m_stringParserService.Parse(formatstring), formatitems), caption)
        End Sub

        Public Overloads Sub ShowMessageFormatted(ByVal formatstring As String, ByVal ParamArray formatitems() As String) Implements IMessageService.ShowMessageFormatted
            Me.ShowMessage(String.Format(Me.m_stringParserService.Parse(formatstring), formatitems))
        End Sub

        Public Sub ShowWarning(ByVal message As String) Implements IMessageService.ShowWarning
            MessageBox.Show(Me.m_stringParserService.Parse(message), Me.m_stringParserService.Parse("${res:Global.WarningText}"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Sub

        Public Sub ShowWarningFormatted(ByVal formatstring As String, ByVal ParamArray formatitems() As String) Implements IMessageService.ShowWarningFormatted
            Me.ShowWarning(String.Format(Me.m_stringParserService.Parse(formatstring), formatitems))
        End Sub
#End Region

    End Class
End Namespace

