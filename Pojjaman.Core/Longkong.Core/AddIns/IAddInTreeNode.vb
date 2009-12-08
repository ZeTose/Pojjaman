Imports System.Reflection
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns
    Public Interface IAddInTreeNode
        ' Methods
        Function BuildChildItem(ByVal childItemID As String, ByVal caller As Object) As Object
        Function BuildChildItems(ByVal caller As Object) As ArrayList
        Function GetCurrentConditionFailedAction(ByVal caller As Object) As ConditionFailedAction

        ' Properties
        ReadOnly Property ChildNodes() As Hashtable
        Property Codon() As ICodon
        Property ConditionCollection() As ConditionCollection
    End Interface
End Namespace




