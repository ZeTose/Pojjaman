Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class ViewTipOfTheDay
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim myTipOfTheDayDialog As TipOfTheDayDialog = New TipOfTheDayDialog
            myTipOfTheDayDialog.Owner = CType(WorkbenchSingleton.Workbench, Form)
            myTipOfTheDayDialog.ShowDialog()
        End Sub
#End Region

    End Class
End Namespace
