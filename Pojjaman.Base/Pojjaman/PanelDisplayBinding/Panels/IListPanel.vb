Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IListPanel
        Inherits IEntityPanel

        Sub AddNew()
        Sub RefreshData(ByVal id As String)
        ReadOnly Property DetailPanel() As IListDetail
        Property SelectedEntity() As BusinessLogic.BusinessEntity
    End Interface
End Namespace

