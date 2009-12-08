Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    Public Interface ICodon
        ' Methods
        Function BuildItem(ByVal owner As Object, ByVal subItems As ArrayList, ByVal conditions As ConditionCollection) As Object

        Property AddIn() As AddIn
        ReadOnly Property [Class]() As String
        ReadOnly Property HandleConditions() As Boolean
        ReadOnly Property ID() As String
        Property InsertAfter() As String()
        ReadOnly Property InsertBefore() As String()
        ReadOnly Property Name() As String
    End Interface
End Namespace

