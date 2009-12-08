Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports System.IO
Imports System.Windows.Forms
Namespace Longkong.Pojjaman.DefaultEditor.Gui.Editor
    Public Class TextEditorDisplayBinding
        Implements IDisplayBinding

#Region "Constructors"
        Shared Sub New()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim modesDirectory As String = Path.Combine(myPropertyService.ConfigDirectory, "modes")
            If Not Directory.Exists(modesDirectory) Then
                Directory.CreateDirectory(modesDirectory)
            End If
            'HighlightingManager.Manager.AddSyntaxModeFileProvider(New FileSyntaxModeProvider(modesDirectory))
            'HighlightingManager.Manager.AddSyntaxModeFileProvider(New FileSyntaxModeProvider(Path.Combine(myPropertyService.DataDirectory, "modes")))
        End Sub
        Public Sub New()
        End Sub
#End Region

#Region "IDisplayBinding"
        Public Function CanCreateContentForFile(ByVal fileName As String) As Boolean Implements Core.AddIns.Codons.IDisplayBinding.CanCreateContentForFile
            Return True
        End Function
        Public Function CanCreateContentForLanguage(ByVal languageName As String) As Boolean Implements Core.AddIns.Codons.IDisplayBinding.CanCreateContentForLanguage
            Return True
        End Function
        Public Function CreateContentForFile(ByVal fileName As String) As Pojjaman.Gui.IViewContent Implements Core.AddIns.Codons.IDisplayBinding.CreateContentForFile
            Dim wrapper As New TextEditorDisplayBindingWrapper
            wrapper.TextAreaControl.Dock = DockStyle.Fill
            wrapper.Load(fileName)
            'wrapper.TextAreaControl.InitializeFormatter()
            'wrapper.ForceFoldingUpdate(Nothing)
            'wrapper.TextAreaControl.ActivateQuickClassBrowserOnDemand()
            Return wrapper
        End Function
        Public Function CreateContentForLanguage(ByVal languageName As String, ByVal content As String) As Pojjaman.Gui.IViewContent Implements Core.AddIns.Codons.IDisplayBinding.CreateContentForLanguage
            Dim wrapper As New TextEditorDisplayBindingWrapper
            Dim service1 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            wrapper.TextAreaControl.Document.TextContent = service1.Parse(content)
            'wrapper.TextAreaControl.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(language)
            'wrapper.TextAreaControl.InitializeFormatter()
            'wrapper.ForceFoldingUpdate(language)
            'wrapper.TextAreaControl.ActivateQuickClassBrowserOnDemand()
            Return wrapper
        End Function
        Public Function CanCreateContentForPanel(ByVal type As System.Type) As Boolean Implements Core.AddIns.Codons.IDisplayBinding.CanCreateContentForPanel
            Return False
        End Function
        Public Function CreateContentForPanel(ByVal type As System.Type, ByVal args As String) As Pojjaman.Gui.IViewContent Implements Core.AddIns.Codons.IDisplayBinding.CreateContentForPanel
            Return Nothing
        End Function
#End Region

    End Class
End Namespace