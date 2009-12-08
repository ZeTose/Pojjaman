Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IHelperCapable
        Sub LoadHelpers()
        Sub UpdateValue(ByVal value As BusinessLogic.BusinessEntity)
        ReadOnly Property Helpers() As HelperCollection
    End Interface
End Namespace

