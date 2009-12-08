Namespace Longkong.Core.AddIns.Conditions
    Public Interface ICondition
        ' Methods
        Function IsValid(ByVal caller As Object) As Boolean

        ' Properties
        Property Action() As ConditionFailedAction
    End Interface
    Public Enum ConditionFailedAction
        [Nothing]
        Exclude
        Disable
    End Enum
End Namespace



