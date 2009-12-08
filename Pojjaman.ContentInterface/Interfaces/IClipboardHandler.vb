Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui
    Public Interface IClipboardHandler
        ' Methods
        Sub Copy(ByVal sender As Object, ByVal e As EventArgs)
        Sub Cut(ByVal sender As Object, ByVal e As EventArgs)
        Sub Delete(ByVal sender As Object, ByVal e As EventArgs)
        Sub Paste(ByVal sender As Object, ByVal e As EventArgs)
        Sub SelectAll(ByVal sender As Object, ByVal e As EventArgs)

        ' Properties
        ReadOnly Property EnableCopy() As Boolean
        ReadOnly Property EnableCut() As Boolean
        ReadOnly Property EnableDelete() As Boolean
        ReadOnly Property EnablePaste() As Boolean
        ReadOnly Property EnableSelectAll() As Boolean
    End Interface
End Namespace



