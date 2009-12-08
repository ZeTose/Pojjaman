Namespace Longkong.Core.Properties
    Public Class UnknownPropertyNodeException
        Inherits Exception

#Region "Constructors"
        Public Sub New(ByVal nodeName As String)
            MyBase.New("unknown XmlNode : " & nodeName)
        End Sub
#End Region

    End Class
End Namespace

