Imports System.Collections.Specialized
Namespace Longkong.Core.AddIns
    Public Class ConditionWithoutRequiredAttributesException
        Inherits Exception

#Region "Constructors"
        Public Sub New()
            MyBase.New("conditions need at least one required attribute to be identified.")
        End Sub
#End Region

    End Class
End Namespace