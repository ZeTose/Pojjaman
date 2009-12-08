Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.PanelDisplayBinding
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IPanel
        ReadOnly Property Title() As String
        ReadOnly Property Icon() As String
        Property View() As PanelView
        Sub ShowInPad()
    End Interface
End Namespace

