Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui
    Public Interface IPadContent
        Inherits IDisposable

        ' Events
        Event IconChanged As EventHandler
        Event TitleChanged As EventHandler

        ' Methods
        Sub BringPadToFront()
        Sub RedrawContent()

        ' Properties
        Property Category() As String
        Property DockAreas() As String()
        ReadOnly Property Control() As Control
        ReadOnly Property Icon() As String
        Property Shortcut() As String()
        Property Title() As String
        ReadOnly Property HideOnClose() As Boolean
    End Interface
End Namespace



