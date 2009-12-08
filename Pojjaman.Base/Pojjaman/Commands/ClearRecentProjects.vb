Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Commands
    Public Class ClearRecentProjects
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Try
                Dim myFileService As IFileService = CType(ServiceManager.Services.GetService(GetType(IFileService)), IFileService)
                myFileService.RecentOpen.ClearRecentProjects()
            Catch ex As Exception
            End Try
        End Sub
#End Region

    End Class
End Namespace
