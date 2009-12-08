Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Gui.Panels
Imports System.IO
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Commands
    Public Class Test
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            'Dim dlg As New BasketDialog
            ''AddHandler View.EmptyBasket, handler
            'Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(New PRItemSelectionView(New PR, New BasketDialog), dlg)
            'myDialog.ShowDialog()


            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New ResourceVerifier)
            myDialog.ShowDialog()
        End Sub
#End Region

    End Class
    Public Class FormTester
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New ReportTestPreviewPanel)
            myDialog.ShowDialog()
        End Sub
#End Region

    End Class
End Namespace
