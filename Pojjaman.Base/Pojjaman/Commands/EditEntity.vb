Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.PanelDisplayBinding
Namespace Longkong.Pojjaman.Commands
    Public Class EditEntity
        Inherits AbstractEntityMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
    Property Args As String
    Property Label As String
    Public Overrides Sub Run()
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If Not Me.Entity Is Nothing Then
        myEntityPanelService.OpenPanel(Me.Entity, Me.Args, Me.Label)
      End If
    End Sub
#End Region

    End Class
End Namespace
