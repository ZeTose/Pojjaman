Namespace Longkong.Core.AddIns.Conditions
    Public Class AndCondition
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
            Dim valid As Boolean = True
            For Each condition As ICondition In Me.m_conditions
                valid = (valid And condition.IsValid(caller))
            Next
            Return valid
        End Function
#End Region

    End Class
End Namespace

