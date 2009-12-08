Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Panels
Namespace Longkong.Pojjaman.PanelDisplayBinding
    '    Public MustInherit Class AbstractEntityDetailDisplayBinding
    '        Implements IEntityDetailDisplayBinding

    '#Region "IEntityDetailDisplayBinding"
    '        Public Function CanAttachTo(ByVal viewContent As Gui.IViewContent) As Boolean Implements IEntityDetailDisplayBinding.CanAttachTo
    '            'If TypeOf viewContent Is ITextEditorControlProvider Then
    '            '    Dim provider1 As ITextEditorControlProvider = CType(viewContent, ITextEditorControlProvider)
    '            '    Dim text1 As String = String.Empty
    '            '    Dim text2 As String = IIf(viewContent.IsUntitled, viewContent.UntitledName, viewContent.FileName)
    '            '    Try
    '            '        text1 = Path.GetExtension(text2).ToLower
    '            '    Catch exception1 As Exception
    '            '        Console.WriteLine(exception1)
    '            '    End Try
    '            '    If (text1 Is Me.Extension) Then
    '            '        Dim service1 As IParserService = ServiceManager.get_Services.GetService(GetType(IParserService))
    '            '        Dim information1 As IParseInformation = IIf(viewContent.IsUntitled, Nothing, service1.GetParseInformation(text2))
    '            '        If (information1 Is Nothing) Then
    '            '            information1 = service1.ParseFile(text2, provider1.get_TextEditorControl.get_Document.get_TextContent, False)
    '            '        End If
    '            '        If (Not information1 Is Nothing) Then
    '            '            Dim unit1 As ICompilationUnit = CType(information1.BestCompilationUnit, ICompilationUnit)
    '            '            Dim class1 As IClass
    '            '            For Each class1 In unit1.Classes
    '            '                If Not AbstractFormDesignerSecondaryDisplayBinding.BaseClassIsFormOrControl(class1) Then
    '            '                    Continue()
    '            '                End If
    '            '                Dim method1 As IMethod = Me.GetInitializeComponents(class1)
    '            '                If (Not method1 Is Nothing) Then
    '            '                    Return True
    '            '                End If
    '            '            Next
    '            '        End If
    '            '    End If
    '            'End If
    '            'Return False
    '            Return True
    '        End Function
    '        Public MustOverride Function CreateSecondaryViewContent(ByVal viewContent As Gui.IViewContent) As Gui.ISecondaryViewContent() Implements Core.AddIns.Codons.IEntityDetailDisplayBinding.CreateSecondaryViewContent
    '#End Region

    '    End Class
End Namespace

