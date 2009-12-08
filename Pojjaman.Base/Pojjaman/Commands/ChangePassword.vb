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
    Public Class ChangePassword
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            'Dim panel As BOQGridPanel = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent.Control, BOQGridPanel)
            Dim dlg As New ChangePasswordDialog
            dlg.ShowDialog()
        End Sub
#End Region

    End Class
End Namespace
