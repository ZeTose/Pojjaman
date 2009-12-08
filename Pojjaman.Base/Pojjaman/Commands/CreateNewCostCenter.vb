Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard
Imports System.IO
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Commands
    Public Class CreateNewCostCenter
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim myNewCC As New CostCenter
            myNewCC.Type.Value = 2
            myNewCC.Parent = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim dialog As WizardDialog = New WizardDialog(myStringParserService.Parse("${res:Dialog.Wizards.NewCostCenterWizard.DialogName}"), myNewCC, "/Pojjaman/NewCostCenterWizard")
            dialog.ControlBox = False
            dialog.ShowInTaskbar = True
            dialog.ShowDialog()
        End Sub
#End Region

    End Class
End Namespace
