Imports System.Xml
Namespace Longkong.Core.AddIns.Conditions
    Public Class ConditionFactory

#Region "Members"
        Private m_builders As ConditionBuilderCollection
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_builders = New ConditionBuilderCollection
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Builders() As ConditionBuilderCollection
            Get
                Return Me.m_builders
            End Get
        End Property
#End Region

#Region "Methods"
        Public Function CreateCondition(ByVal addIn As AddIn, ByVal conditionNode As XmlNode) As ICondition
            Dim b1 As ConditionBuilder = Me.m_builders.GetBuilderForCondition(conditionNode)
            If (b1 Is Nothing) Then
                Throw New ConditionNotFoundException("unknown condition found")
            End If
            Return b1.BuildCondition(addIn)
        End Function
#End Region

    End Class
End Namespace
