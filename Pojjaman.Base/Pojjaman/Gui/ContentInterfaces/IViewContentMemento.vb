Imports Longkong.Core.Properties
Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui
    Public Interface IViewContentMemento
        Inherits IXmlConvertable
        ' Methods
        Function SetViewContentMemento(ByVal memento As IViewContentMemento) As IViewContent
    End Interface
End Namespace



