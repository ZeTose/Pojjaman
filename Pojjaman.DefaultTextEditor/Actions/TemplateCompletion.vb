Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports ICSharpCode.TextEditor.Actions
Imports Longkong.Pojjaman.DefaultEditor.Gui.Editor
Namespace Longkong.Pojjaman.DefaultEditor.Actions
    Public Class TemplateCompletion
        Inherits AbstractEditAction

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Execute(ByVal services As ICSharpCode.TextEditor.TextArea)
            Dim control1 As PojjamanTextAreaControl = CType(services.MotherTextEditorControl, PojjamanTextAreaControl)
            services.AutoClearSelection = False
            'control1.codeCompletionWindow = CodeCompletionWindow.ShowCompletionWindow(CType(WorkbenchSingleton.Workbench, Form), services.MotherTextEditorControl, services.MotherTextEditorControl.FileName, New TemplateCompletionDataProvider, ChrW(0))
        End Sub
#End Region

    End Class
End Namespace