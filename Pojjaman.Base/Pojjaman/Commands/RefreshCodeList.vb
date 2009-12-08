Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Commands
    Public Class RefreshCodeList
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            CodeDescription.RefreshCodeList()
        End Sub
#End Region


    End Class
End Namespace
