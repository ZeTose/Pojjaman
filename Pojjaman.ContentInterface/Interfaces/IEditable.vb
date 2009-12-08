Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui
    Public Interface IEditable
        ' Methods
        Sub Redo()
        Sub Undo()

        ' Properties
        ReadOnly Property ClipboardHandler() As IClipboardHandler
        ReadOnly Property EnableRedo() As Boolean
        ReadOnly Property EnableUndo() As Boolean
        Property [Text]() As String
    End Interface
End Namespace



