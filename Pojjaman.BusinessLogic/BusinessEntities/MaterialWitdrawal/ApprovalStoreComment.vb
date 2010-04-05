Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class ApprovalStoreComment

#Region "Members"
    Private m_entityId As Integer
    Private m_entityType As Integer
    Private m_lineNumber As Integer
    Private m_comment As String
    Private m_approveType As Integer
    Private m_originator As Integer
    Private m_originDate As Date
    Private m_lastEditor As Integer
    Private m_lastEditDate As Date
#End Region

#Region "Constructors"
    Public Sub New()

    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow)
      If dr.Table.Columns.Contains("apvstore_entityId") AndAlso Not dr.IsNull("apvstore_entityId") Then
        m_entityId = CInt(dr("apvstore_entityId"))
      End If
      If dr.Table.Columns.Contains("apvstore_entitytype") AndAlso Not dr.IsNull("apvstore_entitytype") Then
        m_entityType = CInt(dr("apvstore_entitytype"))
      End If
      If dr.Table.Columns.Contains("apvstore_lineNumber") AndAlso Not dr.IsNull("apvstore_lineNumber") Then
        Me.m_lineNumber = CInt(dr("apvstore_lineNumber"))
      End If
      If dr.Table.Columns.Contains("apvstore_comment") AndAlso Not dr.IsNull("apvstore_comment") Then
        m_comment = CStr(dr("apvstore_comment"))
      End If
      If dr.Table.Columns.Contains("apvstore_approveType") AndAlso Not dr.IsNull("apvstore_approveType") Then
        m_approveType = CInt(dr("apvstore_approveType"))
      End If
      If dr.Table.Columns.Contains("apvstore_originator") AndAlso Not dr.IsNull("apvstore_originator") Then
        m_originator = CInt(dr("apvstore_originator"))
      End If
      If dr.Table.Columns.Contains("apvstore_originDate") AndAlso Not dr.IsNull("apvstore_originDate") Then
        m_originDate = CDate(dr("apvstore_originDate"))
      End If
      If dr.Table.Columns.Contains("apvstore_lastEditor") AndAlso Not dr.IsNull("apvstore_lastEditor") Then
        m_lastEditor = CInt(dr("apvstore_lastEditor"))
      End If
      If dr.Table.Columns.Contains("apvstore_lastEditDate") AndAlso Not dr.IsNull("apvstore_lastEditDate") Then
        m_lastEditDate = CDate(dr("apvstore_lastEditDate"))
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property
    Public Property Comment() As String      Get        Return m_comment      End Get      Set(ByVal Value As String)        m_comment = Value      End Set    End Property    Public Property Type() As Integer      Get        Return m_approveType      End Get      Set(ByVal Value As Integer)        m_approveType = Value      End Set    End Property    Public Property Originator() As Integer      Get        Return m_originator      End Get      Set(ByVal Value As Integer)        m_originator = Value      End Set    End Property    Public Property OriginDate() As Date      Get        Return m_originDate      End Get      Set(ByVal Value As Date)        m_originDate = Value      End Set    End Property    Public Property LastEditor() As Integer      Get        Return m_lastEditor      End Get      Set(ByVal Value As Integer)        m_lastEditor = Value      End Set    End Property    Public Property LastEditDate() As Date      Get        Return m_lastEditDate      End Get      Set(ByVal Value As Date)        m_lastEditDate = Value      End Set    End Property    Public Property EntityId() As Integer      Get        Return m_entityId      End Get      Set(ByVal Value As Integer)        m_entityId = Value      End Set    End Property    Public Property EntityType() As Integer      Get        Return m_entityType      End Get      Set(ByVal Value As Integer)        m_entityType = Value      End Set    End Property
#End Region

#Region "Methods"

#End Region

  End Class

  Public Enum ApproveType
    comment
    approved
    reject
  End Enum

  <Serializable(), DefaultMember("Item")> _
  Public Class ApprovalStoreCommentCollection
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
      , "GetApprovalStoreComment" _
      , New SqlParameter("@entity_id", entityId) _
      , New SqlParameter("@entity_type", entityType) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim file As New ApprovalStoreComment(row)
        Me.Add(file)
      Next
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property Approved As ApproveType
      Get
        Dim appType As ApproveType
        appType = ApproveType.comment
        For Each app As ApprovalStoreComment In Me
          If app.Type = 1 Then
            appType = ApproveType.approved
          ElseIf app.Type = 2 Then
            appType = ApproveType.reject
          End If
        Next
        Return appType
      End Get
    End Property
    Default Public Property Item(ByVal index As Integer) As ApprovalStoreComment
      Get
        Return CType(MyBase.List.Item(index), ApprovalStoreComment)
      End Get
      Set(ByVal value As ApprovalStoreComment)
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
        cmd.CommandText = "select * from StockiApprovalStoreComment where (@entity_id = " & m_entityId & ")  and (@entity_type = " & m_entityType & ") "

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset)
        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables(0)
        For Each dr As DataRow In dt.Rows
          dr.Delete()
        Next
        For Each myCom As ApprovalStoreComment In Me
          Dim drNew As DataRow = dt.NewRow
          drNew("apvstore_entityId") = m_entityId
          drNew("apvstore_entitytype") = m_entityType
          drNew("apvstore_lineNumber") = myCom.LineNumber 'i   'file.LineNumber
          drNew("apvstore_comment") = myCom.Comment
          drNew("apvstore_approveType") = myCom.Type
          drNew("apvstore_originator") = myCom.Originator
          drNew("apvstore_originDate") = myCom.OriginDate
          drNew("apvstore_lastEditor") = myCom.LastEditor
          drNew("apvstore_lastEditDate") = IIf(myCom.LastEditDate.Equals(Date.MinValue), DBNull.Value, myCom.LastEditDate)
          dt.Rows.Add(drNew)
        Next
        ' First process deletes.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        Return New SaveErrorException("1")
      Catch ex As Exception
        MessageBox.Show("Error Saving:" & ex.ToString)
      End Try
    End Function
    'Public Function IsApproved() As Boolean
    '  Dim Approved As Boolean = False
    '  For Each myCom As ApprovalStoreComment In Me
    '    If myCom.IsApproveComment Then
    '      Approved = True
    '    End If
    '  Next
    '  Return Approved
    'End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As ApprovalStoreComment) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As ApprovalStoreCommentCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As ApprovalStoreComment())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As ApprovalStoreComment) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As ApprovalStoreComment(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As ApprovalStoreCommentEnumerator
      Return New ApprovalStoreCommentEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As ApprovalStoreComment) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As ApprovalStoreComment)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As ApprovalStoreComment)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As ApprovalStoreCommentCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class ApprovalStoreCommentEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As ApprovalStoreCommentCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, ApprovalStoreComment)
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