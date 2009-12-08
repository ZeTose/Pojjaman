Imports System.Windows.Forms
Imports Longkong.Pojjaman.Gui.Pads
Namespace Longkong.Pojjaman.Gui
    Public Interface ITreeBrowsableViewContent
        Inherits IBaseViewContent
        'Can be Browsed by the FormBrowser

        ' Properties
        Property Node() As FormNode
        Property Parent() As ITreeBrowsableViewContent
        Property Child() As ITreeBrowsableViewContent
        Property IsDiry() As Boolean

    End Interface
End Namespace



