Namespace Longkong.Core.AddIns.Conditions
    Public Class NegatedCondition
        Inherits AbstractCondition

#Region "Members"
        Private m_conditions As ConditionCollection
#End Region

#Region "Constructors"
        Public Sub New(ByVal conditions As ConditionCollection)
            Me.m_conditions = conditions
        End Sub
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            Return Not Me.m_conditions(0).IsValid(caller)
        End Function
#End Region

    End Class
End Namespace
