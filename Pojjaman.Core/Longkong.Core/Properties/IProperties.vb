Namespace Longkong.Core.Properties
    Public Interface IProperties
        Inherits IXmlConvertable

        Event PropertyChanged As PropertyEventHandler

        Function Clone() As IProperties
        Function GetProperty(ByVal key As String) As Object
        Function GetProperty(ByVal key As String, ByVal defaultvalue As Boolean) As Boolean
        Function GetProperty(ByVal key As String, ByVal defaultvalue As Byte) As Byte
        Function GetProperty(ByVal key As String, ByVal defaultvalue As [Enum]) As [Enum]
        Function GetProperty(ByVal key As String, ByVal defaultvalue As Short) As Short
        Function GetProperty(ByVal key As String, ByVal defaultvalue As Integer) As Integer
        Function GetProperty(ByVal key As String, ByVal defaultvalue As Object) As Object
        Function GetProperty(ByVal key As String, ByVal defaultvalue As String) As String
        Sub SetProperty(ByVal key As String, ByVal val As Object)

    End Interface
End Namespace
