Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IBasketCollectable
        ReadOnly Property ProposedBasketItems() As BasketItemCollection
        ReadOnly Property BasketItems() As BasketItemCollection
        Event EmptyBasket As BasketOperationDelegate
    End Interface
    Public Delegate Sub BasketOperationDelegate(ByVal items As BasketItemCollection)
End Namespace

