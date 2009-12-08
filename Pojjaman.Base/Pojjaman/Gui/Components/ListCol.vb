Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.IO
Imports Longkong.Pojjaman.Services
Namespace Pojjaman.UI
    Public Class ListColumn

#Region "Members"
        Private m_name As String
        Private m_alias As String
        Private m_dataType As Type
        Private m_width As Integer
        Private m_alignment As HorizontalAlignment
        Private m_ordinal As Integer
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal row As DataRow)
            Construct(row)
        End Sub
        Public Sub New(ByVal colReader As IDataReader)
            Construct(colReader)
        End Sub
        Private Sub Construct(ByVal colReader As IDataReader)
            With Me
                .m_name = Field.GetString(colReader, "col_name")
                .m_alias = Field.GetString(colReader, "col_alias")
                .m_width = CInt(Field.GetDecimal(colReader, "col_width"))
                .m_alignment = CType(Field.GetDecimal(colReader, "col_align"), HorizontalAlignment)
                .m_ordinal = CInt(Field.GetDecimal(colReader, "col_ordinal"))
            End With
        End Sub
        Private Sub Construct(ByVal row As DataRow)
            With Me
                .m_name = CStr(row("col_name"))
                .m_alias = CStr(row("col_alias"))
                .m_width = CInt(row("col_width"))
                .m_alignment = CType(CStr(row("col_align")), HorizontalAlignment)
                .m_ordinal = CInt(row("col_ordinal"))
            End With
        End Sub
#End Region

#Region "Proprties"
        Public ReadOnly Property Name() As String
            Get
                Return m_name
            End Get
        End Property
        Public Property [Alias]() As String
            Get
                Return m_alias
            End Get
            Set(ByVal Value As String)
                m_alias = Value
            End Set
        End Property
        Public Property DataType() As Type
            Get
                Return m_dataType
            End Get
            Set(ByVal Value As Type)
                m_dataType = Value
            End Set
        End Property
        Public Property Width() As Integer
            Get
                Return m_width
            End Get
            Set(ByVal Value As Integer)
                m_width = Value
            End Set
        End Property
        Public Property Alignment() As HorizontalAlignment
            Get
                Return m_alignment
            End Get
            Set(ByVal Value As HorizontalAlignment)
                m_alignment = Value
            End Set
        End Property
        Public Property Oridnal() As Integer
            Get
                Return m_ordinal
            End Get
            Set(ByVal Value As Integer)
                m_ordinal = Value
            End Set
        End Property
#End Region

    End Class
    Public Class ListColumnList
        Inherits ArrayList
        Private ds As New DataSet
        Public Sub New(ByVal ClassName As String, ByVal user As Integer)

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String
            sql = "select * from columnpreference where col_entity ='" & ClassName & _
            "' and colpref_user =" & user & " order by col_ordinal" & _
            ";select * from [column] where col_isdefault=1 and col_entity ='" & ClassName & "' order by col_ordinal"
            Dim da As SqlDataAdapter
            Dim cn As SqlConnection = New SqlConnection(sqlConString)
            cn.Open()
            da = New SqlDataAdapter(sql, cn)
            da.TableMappings.Add("columnpref1", "column")
            da.Fill(ds, "columnpref")
            Construct()
        End Sub
        Public Sub New()

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String = "select * from col order by col_entity,col_ordinal"

            conn.Open()

            Dim cmd As SqlCommand = conn.CreateCommand
            cmd.CommandText = sql

            Dim colReader As SqlDataReader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))
            Construct(colReader)
            colReader.Close()
        End Sub
        Public Sub New(ByVal colReader As IDataReader)
            Construct(colReader)
            colReader.Close()
        End Sub
        Private Sub Construct(ByVal colReader As IDataReader)
            ' Add Each Customer to the colleciton
            While colReader.Read()
                Dim col As New ListColumn(colReader)
                Add(col)
            End While
        End Sub
        Private Sub Construct()
            Dim row As DataRow
            If ds.Tables(0).Rows.Count = 0 Then
                For Each row In ds.Tables(1).Rows
                    Add(New ListColumn(row))
                Next
            Else
                For Each row In ds.Tables(0).Rows
                    Add(New ListColumn(row))
                Next
            End If
        End Sub
    End Class
End Namespace
