Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports System.IO
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class ConfigurationCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("configuration", IsRequired:=True)> _
        Private m_configuration As String
        <XmlMemberAttributeAttribute("configvalue", IsRequired:=True)> _
        Private m_value As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            Dim configValue As Object = Longkong.Pojjaman.BusinessLogic.Configuration.GetConfig(m_configuration)
            If Not configValue Is Nothing AndAlso configValue.ToString = m_value Then
                Return True
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
