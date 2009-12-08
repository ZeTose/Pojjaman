Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Gui.Panels
Namespace Longkong.Pojjaman.Commands
    Public Class AccessAdmin
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim dlg As New AccessDialog
            dlg.ShowDialog()
        End Sub
#End Region

    End Class
End Namespace
