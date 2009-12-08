Imports System.ComponentModel
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class ObjectFactory

#Region "Constructor"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Shared Function GetEntity(ByVal fullClassName As String, ByVal args() As Object) As Object
            Dim newInstance As Object
            newInstance = [Assembly].GetExecutingAssembly.CreateInstance(fullClassName, True, BindingFlags.CreateInstance, Nothing, args, Nothing, Nothing)
            If (newInstance Is Nothing) Then
                Debug.WriteLine("Type not found: " & fullClassName)
                Return Nothing
            End If
            Return newInstance
        End Function
        Public Shared Function CreateEntity(ByVal fullClassName As String, ByVal id As Integer) As Object
            Return GetEntity(fullClassName, New Object() {id})
        End Function
        Public Shared Function CreateEntity(ByVal fullClassName As String, ByVal code As String) As Object
            Return GetEntity(fullClassName, New Object() {code})
        End Function
        Public Shared Function CreateEntity(ByVal fullClassName As String) As Object
            Return GetEntity(fullClassName, Nothing)
        End Function
#End Region

    End Class

End Namespace

