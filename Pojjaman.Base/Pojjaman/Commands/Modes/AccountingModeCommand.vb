Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Commands
    Friend Class AccountingModeCommand
        Inherits AbstractModeCommand

#Region "Members"
#End Region

#Region "Constructors"

#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Mode() As Core.AddIns.ApplicationMode
            Get
                Return Core.AddIns.ApplicationMode.Accounting
            End Get
        End Property
#End Region

    End Class
End Namespace
