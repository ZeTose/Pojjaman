Imports System.Reflection
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns
    Public Interface IAddInTree
        ' Methods
        Function GetTreeNode(ByVal path As String) As IAddInTreeNode
        Sub InsertAddIn(ByVal addIn As AddIn)
        Function LoadAssembly(ByVal assemblyFile As String) As [Assembly]
        Sub RemoveAddIn(ByVal addIn As AddIn)

        ' Properties
        ReadOnly Property AddIns() As AddInCollection
        ReadOnly Property CodonFactory() As CodonFactory
        ReadOnly Property ConditionFactory() As ConditionFactory
    End Interface
End Namespace




