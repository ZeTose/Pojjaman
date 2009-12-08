Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Commands
    Public Class GotoWebSite
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
            Dim myIFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
            myIFileService.OpenFile(Me.m_site)
        End Sub
#End Region

    End Class
End Namespace
