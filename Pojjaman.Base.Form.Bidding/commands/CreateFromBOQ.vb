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
    Public Class CreateFromBOQ
        Inherits AbstractEntityMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            If Me.Entity Is Nothing OrElse Me.Entity.Length <= 0 Then
                Return
            End If
            Dim window As IWorkbenchWindow = myEntityPanelService.GetOpenPanel(New BOQ)
            If window Is Nothing Then
                Return
            End If

            Dim list As ItemListing = CType(window.SubViewContents(1), ItemListing)
            If list.CopiedColl Is Nothing Then
                Return
            End If
            For Each item As BoqItem In list.CopiedColl
                MessageBox.Show(item.EntityName)
            Next
            Dim myEntity As ISimpleEntity = SimpleBusinessEntityBase.GetEntity(Me.Entity)
            If TypeOf myEntity Is PO Then
            ElseIf TypeOf myEntity Is PR Then

            End If
            myEntityPanelService.OpenDetailPanel(myEntity)
        End Sub
#End Region

        Public Overrides Property IsEnabled() As Boolean
            Get
                Return True
            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
    End Class
End Namespace
