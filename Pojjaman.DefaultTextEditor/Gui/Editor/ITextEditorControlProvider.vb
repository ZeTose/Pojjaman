Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports System.IO
Imports ICSharpCode.TextEditor
Namespace Longkong.Pojjaman.DefaultEditor.Gui.Editor
    Public Interface ITextEditorControlProvider
        ' Properties
        ReadOnly Property TextEditorControl() As TextEditorControl
    End Interface
End Namespace