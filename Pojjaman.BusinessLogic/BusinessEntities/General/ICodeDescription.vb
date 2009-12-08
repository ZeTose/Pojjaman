Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Interface ICodeDescriptions
        Function GetValue(ByVal key As String) As Object
        Function GetValue(ByVal key As String, ByVal defaultvalue As Boolean) As Boolean
        Function GetValue(ByVal key As String, ByVal defaultvalue As Byte) As Byte
        Function GetValue(ByVal key As String, ByVal defaultvalue As [Enum]) As [Enum]
        Function GetValue(ByVal key As String, ByVal defaultvalue As Short) As Short
        Function GetValue(ByVal key As String, ByVal defaultvalue As Integer) As Integer
        Function GetValue(ByVal key As String, ByVal defaultvalue As Object) As Object
        Function GetValue(ByVal key As String, ByVal defaultvalue As String) As String
        Sub SetCodeDescription(ByVal key As String, ByVal val As Object)
    End Interface
End Namespace
