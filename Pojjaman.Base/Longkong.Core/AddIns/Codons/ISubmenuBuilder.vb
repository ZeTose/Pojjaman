Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    Public Interface ISubmenuBuilder
        ' Methods
        Function BuildSubmenu(ByVal conditionCollection As ConditionCollection, ByVal owner As Object) As CommandBarItem()
    End Interface
End Namespace

