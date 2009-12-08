Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Commands
    Public Class NewBoq
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'Dim myBOQ As New BusinessLogic.BOQ(1)
            'myEntityPanelService.OpenPanel(myBOQ)
        End Sub
#End Region

    End Class
End Namespace
