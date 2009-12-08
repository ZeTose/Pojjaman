Imports System.Reflection
Imports System.Collections.Specialized
Namespace Longkong.Core.AddIns.Conditions
    Public Class ConditionBuilder

#Region "Members"
        Private m_assembly As [Assembly]
        Private m_className As String
        Private m_requiredAttributes As StringCollection
#End Region

#Region "Constructors"
        Public Sub New(ByVal className As String, ByVal [assembly] As [Assembly])
            Me.m_requiredAttributes = New StringCollection
            Me.m_assembly = [assembly]
            Me.m_className = className
            Dim myType As Type = [assembly].GetType(className)
            Do While (Not myType Is GetType(Object))
                Dim fieldInfoArray As FieldInfo() = myType.GetFields((BindingFlags.NonPublic Or BindingFlags.Instance))
                For Each myFieldInfo As FieldInfo In fieldInfoArray
                    Dim attribute1 As XmlMemberAttributeAttribute = CType(Attribute.GetCustomAttribute(myFieldInfo, GetType(XmlMemberAttributeAttribute)), XmlMemberAttributeAttribute)
                    If ((Not attribute1 Is Nothing) AndAlso attribute1.IsRequired) Then
                        Me.m_requiredAttributes.Add(attribute1.Name)
                    End If
                Next
                myType = myType.BaseType
            Loop
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property RequiredAttributes() As StringCollection
            Get
                Return Me.m_requiredAttributes
            End Get
        End Property
#End Region

#Region "Methods"
        Public Function BuildCondition(ByVal addIn As AddIn) As ICondition
            Return CType(Me.m_assembly.CreateInstance(Me.m_className, True), ICondition)
        End Function
#End Region

    End Class
End Namespace

