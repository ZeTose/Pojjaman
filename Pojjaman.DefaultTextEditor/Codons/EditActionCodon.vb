Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports ICSharpCode.TextEditor.Actions
Imports Longkong.Pojjaman.DefaultEditor.Gui.Editor
Imports System.Windows.Forms
Imports System.Reflection
Namespace Longkong.Pojjaman.DefaultEditor.Codons
    <CodonName("EditAction")> _
    Public Class EditActionCodon
        Inherits AbstractCodon

#Region "Members"
        <XmlMemberArray("keys", IsRequired:=True)> _
        Private m_keys As String()
#End Region

#Region "Constructors"

#End Region

#Region "Properties"

#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Core.AddIns.Conditions.ConditionCollection) As Object
            If (subItems.Count > 0) Then
                Throw New ApplicationException("more than one level of edit actions don't make sense!")
            End If
            Dim action As IEditAction = CType(MyBase.AddIn.CreateObject(MyBase.Class), IEditAction)
            Dim keysArray1 As Keys() = New Keys(Me.m_keys.Length - 1) {}
            For i As Integer = 0 To Me.m_keys.Length - 1
                Dim chArray1 As Char() = New Char() {"|"c}
                Dim textArray1 As String() = Me.m_keys(i).Split(chArray1)
                Dim keys1 As Keys = CType(Keys.Space.GetType.InvokeMember(textArray1(0), BindingFlags.GetField, Nothing, Keys.Space, New Object(0 - 1) {}), Keys)
                Dim num2 As Integer
                For num2 = 1 To textArray1.Length - 1
                    keys1 = (keys1 Or CType(Keys.Space.GetType.InvokeMember(textArray1(num2), BindingFlags.GetField, Nothing, Keys.Space, New Object(0 - 1) {}), Keys))
                Next num2
                keysArray1(i) = keys1
            Next
            action.Keys = keysArray1
            Return action
        End Function
#End Region

    End Class
End Namespace