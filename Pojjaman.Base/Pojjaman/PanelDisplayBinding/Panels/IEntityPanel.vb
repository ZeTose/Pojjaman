Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IEntityPanel
        Inherits IPanel
        Event EntityPropertyChanged As EventHandler
        Sub SetLabelText()
        Sub UpdateEntityProperties()
        Sub ClearDetail()
        Sub CheckFormEnable()
        Property Entity() As BusinessLogic.BusinessEntity
    End Interface
End Namespace

