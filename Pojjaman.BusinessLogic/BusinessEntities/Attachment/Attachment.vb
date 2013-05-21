Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataTransfer

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class Attachment

#Region "Members"
        Private m_entityId As Integer
        Private m_entityType As Integer
        Private m_lineNumber As Integer
        Private m_fileName As String
        Private m_fileNameInServer As String
        Private m_fileSize As Integer
        Private m_CRC32 As String
        Private m_originator As Integer
        Private m_originDate As Date
#End Region

#Region "Constructors"
        Public Sub New()
            m_fileName = ""
            m_fileNameInServer = ""
            m_fileSize = 0
            m_CRC32 = ""
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow)
            If dr.Table.Columns.Contains("attch_entityId") AndAlso Not dr.IsNull("attch_entityId") Then
                m_entityId = CInt(dr("attch_entityId"))
            End If
            If dr.Table.Columns.Contains("attch_entitytype") AndAlso Not dr.IsNull("attch_entitytype") Then
                m_entityType = CInt(dr("attch_entitytype"))
            End If
            If dr.Table.Columns.Contains("attch_lineNumber") AndAlso Not dr.IsNull("attch_lineNumber") Then
                Me.m_lineNumber = CInt(dr("attch_lineNumber"))
            End If
            If dr.Table.Columns.Contains("attch_fileName") AndAlso Not dr.IsNull("attch_fileName") Then
                m_fileName = CStr(dr("attch_fileName"))
            End If
            If dr.Table.Columns.Contains("attch_fileNameInServer") AndAlso Not dr.IsNull("attch_fileNameInServer") Then
                m_fileNameInServer = CStr(dr("attch_fileNameInServer"))
            End If
            If dr.Table.Columns.Contains("attch_fileSize") AndAlso Not dr.IsNull("attch_fileSize") Then
                m_fileSize = CInt(dr("attch_fileSize"))
            End If
            If dr.Table.Columns.Contains("attch_CRC32") AndAlso Not dr.IsNull("attch_CRC32") Then
                m_CRC32 = CStr(dr("attch_CRC32"))
            End If
            If dr.Table.Columns.Contains("attch_originator") AndAlso Not dr.IsNull("attch_originator") Then
                m_originator = CInt(dr("attch_originator"))
            End If
            If dr.Table.Columns.Contains("attch_originDate") AndAlso Not dr.IsNull("attch_originDate") Then
                m_originDate = CDate(dr("attch_originDate"))
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property
        Public Property FileName() As String            Get                Return m_fileName            End Get            Set(ByVal Value As String)                m_fileName = Value            End Set        End Property        Public Property FileNameInServer() As String            Get                Return m_fileNameInServer            End Get            Set(ByVal Value As String)                m_fileNameInServer = Value            End Set        End Property        Public Property FileSize() As Integer            Get                Return m_fileSize            End Get            Set(ByVal Value As Integer)                m_fileSize = Value            End Set        End Property        Public Property CRC32() As String            Get                Return m_CRC32            End Get            Set(ByVal Value As String)                m_CRC32 = Value            End Set        End Property        Public Property Originator() As Integer            Get                Return m_originator            End Get            Set(ByVal Value As Integer)                m_originator = Value            End Set        End Property        Public Property OriginDate() As Date            Get                Return m_originDate            End Get            Set(ByVal Value As Date)                m_originDate = Value            End Set        End Property        Public Property EntityId() As Integer            Get                Return m_entityId            End Get            Set(ByVal Value As Integer)                m_entityId = Value            End Set        End Property        Public Property EntityType() As Integer            Get                Return m_entityType            End Get            Set(ByVal Value As Integer)                m_entityType = Value            End Set        End Property
#End Region

#Region "Methods"

#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
Public Class AttachmentCollection
        Inherits CollectionBase

#Region "Members"
        Private m_entityId As Integer
        Private m_entityType As Integer
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity)
            If Not entity.Originated Then
                Return
            End If
            m_entityId = entity.Id
            m_entityType = entity.EntityId
            Construct(entity.Id, entity.EntityId)
        End Sub
        Private Sub Construct(ByVal entityId As Integer, ByVal entityType As Integer)
            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetAttachment" _
            , New SqlParameter("@entity_id", entityId) _
            , New SqlParameter("@entity_type", entityType) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim file As New Attachment(row)
                Me.Add(file)
            Next
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As Attachment
            Get
                Return CType(MyBase.List.Item(index), Attachment)
            End Get
            Set(ByVal value As Attachment)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
    Public Function Save() As SaveErrorException
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "Execute GetAttachmentForSaving " & m_entityId & ", " & m_entityType

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset)
        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables(0)
        For Each dr As DataRow In dt.Rows
          dr.Delete()
        Next
        Dim i As Integer = 0
        For Each file As Attachment In Me
          i += 1
          Dim drNew As DataRow = dt.NewRow
          drNew("attch_entityId") = m_entityId
          drNew("attch_entitytype") = m_entityType
          drNew("attch_lineNumber") = i   'file.LineNumber
          drNew("attch_fileName") = file.FileName
          drNew("attch_fileNameInServer") = file.FileNameInServer
          drNew("attch_fileSize") = file.FileSize
          drNew("attch_CRC32") = file.CRC32
          drNew("attch_originator") = file.Originator
          drNew("attch_originDate") = file.OriginDate
          dt.Rows.Add(drNew)
        Next
        ' First process deletes.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        UpdateAttachToList(i)

        Return New SaveErrorException("1")
      Catch ex As Exception
        MessageBox.Show("Error Saving:" & ex.ToString)
      End Try
    End Function

    Private Function UpdateAttachToList(ByVal ItemAmount As Integer) As Boolean
      Try
        SqlHelper.ExecuteNonQuery(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "UpdateAttachToList", New SqlParameter("@entityId", m_entityId), New SqlParameter("@entityType", m_entityType), New SqlParameter("@ItemAmount", ItemAmount))
      Catch ex As Exception
        Throw New Exception(ex.Message)
      End Try
    End Function

#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As Attachment) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As AttachmentCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As Attachment())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As Attachment) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As Attachment(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As AttachmentEnumerator
            Return New AttachmentEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As Attachment) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As Attachment)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As Attachment)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As AttachmentCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class AttachmentEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As AttachmentCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, Attachment)
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                Return Me.m_baseEnumerator.MoveNext
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                Me.m_baseEnumerator.Reset()
            End Sub
        End Class
    End Class
End Namespace