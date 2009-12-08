Imports System.Xml
Namespace Longkong.Core.Properties
    Public Interface IXmlConvertable
        Function FromXmlElement(ByVal element As XmlElement) As Object
        Function ToXmlElement(ByVal doc As XmlDocument) As XmlElement
    End Interface
End Namespace


