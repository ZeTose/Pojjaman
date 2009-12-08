Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Commands
    Public Class MainViewMenuBuilder
        Inherits ViewMenuBuilder

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Protected Overrides ReadOnly Property Category() As String
            Get
                Return "Main"
            End Get
        End Property
#End Region

    End Class
End Namespace
