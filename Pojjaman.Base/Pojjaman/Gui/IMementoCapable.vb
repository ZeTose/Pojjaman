Imports Longkong.Core.Properties
Namespace Longkong.Pojjaman.Gui
    Public Interface IMementoCapable
        ' Methods
        Function CreateMemento() As IXmlConvertable
        Sub SetMemento(ByVal memento As IXmlConvertable)
    End Interface
End Namespace



