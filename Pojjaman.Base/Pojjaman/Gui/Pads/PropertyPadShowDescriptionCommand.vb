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
    Public Class PropertyPadShowDescriptionCommand
        Inherits AbstractCheckableMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Property IsChecked() As Boolean
            Get
                Return PropertyPad.Grid.HelpVisible
            End Get
            Set(ByVal Value As Boolean)
                PropertyPad.Grid.HelpVisible = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            PropertyPad.Grid.HelpVisible = Not PropertyPad.Grid.HelpVisible
        End Sub
#End Region

    End Class
End Namespace

