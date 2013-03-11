Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports System.Collections.Generic
Imports Longkong.Pojjaman.BusinessLogic

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
  Public Interface IPrintDocumentsList
    ReadOnly Property VatItemWithCustomNoteForPreview() As List(Of VatItemWithCustomNote)
  End Interface
End Namespace

