Imports System
Imports System.Data
Imports System.IO
Imports System.Drawing
Namespace Longkong.Pojjaman.DataAccessLayer
    _
    Public Class Field

        ' Disallow Construction
        Private Sub New()
        End Sub

        ' By Number
        Public Overloads Shared Function GetImage(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Image
            If rec.IsDBNull(fldnum) Then
                Return Nothing
            End If
            Dim bytBLOBData(CInt(rec.GetBytes(fldnum, 0, Nothing, 0, Integer.MaxValue) - 1)) As Byte
            rec.GetBytes(fldnum, 0, bytBLOBData, 0, bytBLOBData.Length)
            Dim stmBLOBData As New MemoryStream(bytBLOBData)
            Return Image.FromStream(stmBLOBData)
        End Function
        Public Overloads Shared Function GetString(ByVal rec As IDataRecord, ByVal fldnum As Integer) As String
            If rec.IsDBNull(fldnum) Then
                Return ""
            End If
            Return rec.GetString(fldnum)
        End Function


        Public Overloads Shared Function GetDecimal(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Decimal
            If rec.IsDBNull(fldnum) Then
                Return 0
            End If
            Return rec.GetDecimal(fldnum)
        End Function


        Public Overloads Shared Function GetInt(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Integer
            If rec.IsDBNull(fldnum) Then
                Return 0
            End If
            Return rec.GetInt32(fldnum)
        End Function


        Public Overloads Shared Function GetBoolean(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Boolean
            If rec.IsDBNull(fldnum) Then
                Return False
            End If
            Return rec.GetBoolean(fldnum)
        End Function


        Public Overloads Shared Function GetByte(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Byte
            If rec.IsDBNull(fldnum) Then
                Return 0
            End If
            Return rec.GetByte(fldnum)
        End Function


        Public Overloads Shared Function GetDateTime(ByVal rec As IDataRecord, ByVal fldnum As Integer) As DateTime
            If rec.IsDBNull(fldnum) Then
                Return New DateTime(0)
            End If
            Return rec.GetDateTime(fldnum)
        End Function


        Public Overloads Shared Function GetDouble(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Double
            If rec.IsDBNull(fldnum) Then
                Return 0
            End If
            Return rec.GetDouble(fldnum)
        End Function


        Public Overloads Shared Function GetFloat(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Single
            If rec.IsDBNull(fldnum) Then
                Return 0
            End If
            Return rec.GetFloat(fldnum)
        End Function


        Public Overloads Shared Function GetGuid(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Guid
            If rec.IsDBNull(fldnum) Then
                Return Guid.Empty
            End If
            Return rec.GetGuid(fldnum)
        End Function


        Public Overloads Shared Function GetInt32(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Int32
            If rec.IsDBNull(fldnum) Then
                Return 0
            End If
            Return rec.GetInt32(fldnum)
        End Function


        Public Overloads Shared Function GetInt16(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Int16
            If rec.IsDBNull(fldnum) Then
                Return 0
            End If
            Return rec.GetInt16(fldnum)
        End Function


        Public Overloads Shared Function GetInt64(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Int64
            If rec.IsDBNull(fldnum) Then
                Return 0
            End If
            Return rec.GetInt64(fldnum)
        End Function


        ' By Name
        Public Overloads Shared Function GetImage(ByVal rec As IDataRecord, ByVal fldname As String) As Image
            Try
                Return GetImage(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Overloads Shared Function GetString(ByVal rec As IDataRecord, ByVal fldname As String) As String
            Try
                Return GetString(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Overloads Shared Function GetDecimal(ByVal rec As IDataRecord, ByVal fldname As String) As Decimal
            Try
                Return GetDecimal(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return 0
            End Try

        End Function

        Public Overloads Shared Function GetInt(ByVal rec As IDataRecord, ByVal fldname As String) As Integer
            Try
                Return GetInt(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
                Return 0
            End Try
        End Function


        Public Overloads Shared Function GetBoolean(ByVal rec As IDataRecord, ByVal fldname As String) As Boolean
            Try
                Return GetBoolean(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Overloads Shared Function GetByte(ByVal rec As IDataRecord, ByVal fldname As String) As Byte
            Try
                Return GetByte(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overloads Shared Function GetDateTime(ByVal rec As IDataRecord, ByVal fldname As String) As DateTime
            Try
                Return GetDateTime(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Overloads Shared Function GetDouble(ByVal rec As IDataRecord, ByVal fldname As String) As Double
            Try
                Return GetDouble(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overloads Shared Function GetFloat(ByVal rec As IDataRecord, ByVal fldname As String) As Single
            Try
                Return GetFloat(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return 0
            End Try
        End Function


        Public Overloads Shared Function GetGuid(ByVal rec As IDataRecord, ByVal fldname As String) As Guid
            Try
                Return GetGuid(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Overloads Shared Function GetInt32(ByVal rec As IDataRecord, ByVal fldname As String) As Int32
            Try
                Return GetInt32(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overloads Shared Function GetInt16(ByVal rec As IDataRecord, ByVal fldname As String) As Int16
            Try
                Return GetInt16(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Overloads Shared Function GetInt64(ByVal rec As IDataRecord, ByVal fldname As String) As Int64
            Try
                Return GetInt64(rec, rec.GetOrdinal(fldname))
            Catch ex As Exception
                Return 0
            End Try
        End Function
    End Class
End Namespace