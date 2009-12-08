Namespace Longkong.Core.AddIns.Conditions
    Public MustInherit Class AbstractCondition
        Implements ICondition

#Region "Members"
        <XmlMemberAttributeAttribute("action")> _
      Private m_action As ConditionFailedAction
#End Region

#Region "Constructors"
        Protected Sub New()
            Me.m_action = ConditionFailedAction.Exclude
        End Sub
#End Region

#Region "Properties"
        Public Property Action() As ConditionFailedAction Implements ICondition.Action
            Get
                Return Me.m_action
            End Get
            Set(ByVal value As ConditionFailedAction)
                Me.m_action = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public MustOverride Function IsValid(ByVal caller As Object) As Boolean Implements ICondition.IsValid
#End Region

    End Class
End Namespace
