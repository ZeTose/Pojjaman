Namespace Longkong.Core.AddIns.Codons
    <CodonName("Class")> _
    Public Class ClassCodon
        Inherits AbstractCodon
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
            Return MyBase.AddIn.CreateObject(MyBase.Class)
        End Function
    End Class
End Namespace
