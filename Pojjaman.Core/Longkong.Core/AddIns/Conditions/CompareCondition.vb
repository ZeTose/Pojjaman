Imports Longkong.Core.Services
Namespace Longkong.Core.AddIns.Conditions
    <Condition()> _
    Public Class CompareCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("string", IsRequired:=True)> _
        Private s1 As String
        <XmlMemberAttributeAttribute("equals", IsRequired:=True)> _
        Private s2 As String
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Return (myStringParserService.Parse(Me.s1) = myStringParserService.Parse(Me.s2))
        End Function
#End Region

    End Class
End Namespace


