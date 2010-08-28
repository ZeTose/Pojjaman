Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IListDetail
        Inherits IEntityPanel
        Sub Initialize()
        Property Owner() As IListPanel
    End Interface
    Public Interface IAuxTab
    ReadOnly Property AuxEntity() As BusinessLogic.IDirtyAble
  End Interface
  Public Interface IAuxTabItem
    ReadOnly Property AuxEntityItem() As Object
  End Interface
  Public Interface ISetNothingEntity
    Sub SetNothing()
  End Interface
End Namespace

