Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Commands
    Public Class GotoLink
        Inherits AbstractMenuCommand

#Region "Members"
        Private m_site As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal site As String)
            Me.m_site = site
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim text1 As String
            If Me.m_site.StartsWith("home://") Then
                text1 = String.Concat(New Object(4 - 1) {})
            Else
                text1 = Me.m_site
            End If
            Try
                Process.Start(text1)
            Catch ex As Exception
                Dim myIMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                myIMessageService.ShowError(("Can't execute/view " & text1 & ChrW(10) & " Please check that the file exists and that you can open this file."))
            End Try
        End Sub
#End Region

    End Class
End Namespace
