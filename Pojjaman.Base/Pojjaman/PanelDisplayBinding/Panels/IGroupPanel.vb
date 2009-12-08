Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IGroupPanel
        Inherits ISimpleListPanel
        Overloads Sub RefreshData(ByVal entity As TreeBaseEntity)
    End Interface
End Namespace

