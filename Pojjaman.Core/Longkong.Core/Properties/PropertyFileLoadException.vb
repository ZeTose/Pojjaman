Namespace Longkong.Core.Properties
    Public Class PropertyFileLoadException
        Inherits Exception

#Region "Constructors"
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New()
            MyBase.New("couldn't load global property file")
        End Sub
#End Region

    End Class
End Namespace
