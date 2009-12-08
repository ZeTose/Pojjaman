Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports System.ComponentModel
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Core.AddIns.Codons
Namespace Longkong.Pojjaman.Gui.Pads
    Public Class PropertyPadResetCommand
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Try
                PropertyPad.Grid.ResetSelectedProperty()
            Catch ex As Exception
                Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                myMessageService.ShowError(ex, "${res:Longkong.Pojjaman.Gui.Pads.PropertyPadResetCommand}")
            End Try
        End Sub
#End Region

    End Class
End Namespace

