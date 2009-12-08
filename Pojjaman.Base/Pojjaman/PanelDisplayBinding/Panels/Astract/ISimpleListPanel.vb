Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface ISimpleListPanel
        Inherits ISimpleEntityPanel
        Sub AddNew()
        Sub RefreshData(ByVal id As String)
        Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs)
        Property SelectedEntity() As BusinessLogic.ISimpleEntity
        Event EntitySelected As NamedEntityOperationDelegate
    End Interface
End Namespace

