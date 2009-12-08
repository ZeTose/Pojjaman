Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BrowserDisplayBinding
Namespace Longkong.Pojjaman.PanelDisplayBinding
    Public Class PanelDisplayBinding
        Implements IDisplayBinding

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "IDisplayBinding"
        Public Function CanCreateContentForFile(ByVal fileName As String) As Boolean Implements Core.AddIns.Codons.IDisplayBinding.CanCreateContentForFile
            Return False
        End Function
        Public Function CanCreateContentForLanguage(ByVal languageName As String) As Boolean Implements Core.AddIns.Codons.IDisplayBinding.CanCreateContentForLanguage
            Return False
        End Function
        Public Function CreateContentForFile(ByVal fileName As String) As Gui.IViewContent Implements Core.AddIns.Codons.IDisplayBinding.CreateContentForFile
            Return Nothing
        End Function
        Public Function CreateContentForLanguage(ByVal languageName As String, ByVal content As String) As Gui.IViewContent Implements Core.AddIns.Codons.IDisplayBinding.CreateContentForLanguage
            Return Nothing
        End Function
        Public Function CanCreateContentForPanel(ByVal type As Type) As Boolean Implements Core.AddIns.Codons.IDisplayBinding.CanCreateContentForPanel

        End Function
        Public Function CreateContentForPanel(ByVal type As Type, ByVal args As String) As Gui.IViewContent Implements Core.AddIns.Codons.IDisplayBinding.CreateContentForPanel

        End Function
#End Region

    End Class
End Namespace

