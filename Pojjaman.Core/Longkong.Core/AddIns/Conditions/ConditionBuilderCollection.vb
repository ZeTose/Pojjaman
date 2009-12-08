Imports System.Collections.Specialized
Imports System.Xml
Namespace Longkong.Core.AddIns.Conditions
    Public Class ConditionBuilderCollection
        Inherits CollectionBase

#Region "Methods"
        Public Sub Add(ByVal builder As ConditionBuilder)
            Dim b2 As ConditionBuilder
            For Each b2 In Me
                If b2.RequiredAttributes.Equals(builder.RequiredAttributes) Then
                    Throw New DuplicateConditionException(builder.RequiredAttributes)
                End If
            Next b2
            If builder.RequiredAttributes.Count = 0 Then
                Throw New ConditionWithoutRequiredAttributesException
            End If
            List.Add(builder)
        End Sub
        Public Function GetBuilderForCondition(ByVal conditionNode As XmlNode) As ConditionBuilder
            Dim b1 As ConditionBuilder
            For Each b1 In Me
                If Me.MatchAttributes(b1.RequiredAttributes, conditionNode) Then
                    Return b1
                End If
            Next
            Return Nothing
        End Function
        Private Function MatchAttributes(ByVal requiredAttributes As StringCollection, ByVal conditionNode As XmlNode) As Boolean
            For Each Att As String In requiredAttributes
                If (conditionNode.Attributes.ItemOf(Att) Is Nothing) Then
                    Return False
                End If
            Next
            Return True
        End Function
#End Region

    End Class
End Namespace
