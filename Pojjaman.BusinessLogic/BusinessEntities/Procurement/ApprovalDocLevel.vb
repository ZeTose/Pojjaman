Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic

  Public Class ApprovalDocLevel

#Region "Members"
    Private m_userId As Integer
    Private m_docId As Integer
    Private m_level As Integer
    Private m_maxAmt As Decimal
#End Region

#Region "Constuctors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow)
      If dr.Table.Columns.Contains("app_user") AndAlso Not dr.IsNull("app_user") Then
        m_userId = CInt(dr("app_user"))
      End If
      If dr.Table.Columns.Contains("app_doc") AndAlso Not dr.IsNull("app_doc") Then
        m_docId = CInt(dr("app_doc"))
      End If
      If dr.Table.Columns.Contains("app_level") AndAlso Not dr.IsNull("app_level") Then
        m_level = CInt(dr("app_level"))
      End If
      If dr.Table.Columns.Contains("app_maxamt") AndAlso Not dr.IsNull("app_maxamt") Then
        m_maxAmt = CDec(dr("app_maxamt"))
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property UserId() As Integer
      Get
        Return m_userId
      End Get
      Set(ByVal Value As Integer)
        m_userId = Value
      End Set
    End Property
    Public Property DocId() As Integer
      Get
        Return m_docId
      End Get
      Set(ByVal Value As Integer)
        m_docId = Value
      End Set
    End Property
    Public Property Level() As Integer
      Get
        Return m_level
      End Get
      Set(ByVal Value As Integer)
        m_level = Value
      End Set
    End Property
    Public Property MaxAmount() As Decimal
      Get
        Return m_maxAmt
      End Get
      Set(ByVal Value As Decimal)
        m_maxAmt = Value
      End Set
    End Property
#End Region

#Region "Methods"

#End Region

  End Class


  <Serializable(), DefaultMember("Item")> _
  Public Class ApprovalDocLevelCollection
    Inherits CollectionBase

#Region "Members"
    Private m_userId As Integer
    Private m_DocId As Integer
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal user As User)
      m_userId = user.Id
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetApprovalDocLevelList" _
      , New SqlParameter("@user_id", m_userId))

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New ApprovalDocLevel(row)
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As ApprovalDocLevel
      Get
        Return CType(MyBase.List.Item(index), ApprovalDocLevel)
      End Get
      Set(ByVal value As ApprovalDocLevel)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetItem(ByVal docId As Integer) As ApprovalDocLevel
      Dim ret As ApprovalDocLevel
      For Each temp As ApprovalDocLevel In Me.List
        If docId = temp.DocId Then
          ret = temp
        End If
      Next
      If ret Is Nothing Then
        ret = New ApprovalDocLevel
        ret.DocId = docId
        Me.Add(ret)
      End If
      Return ret
    End Function
    Public Function Save(ByVal user As User) As SaveErrorException
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "select * from ApprovalDocLevel where app_user=" & user.Id


        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "ApprovalDocLevel")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("ApprovalDocLevel")
        For Each row As DataRow In dt.Rows
          row.Delete()
        Next

        For Each item As ApprovalDocLevel In Me
          Dim dr As DataRow = dt.NewRow
          dr("app_user") = user.Id
          dr("app_doc") = item.DocId
          dr("app_level") = item.Level
          dr("app_maxamt") = item.MaxAmount
          dt.Rows.Add(dr)
        Next

        ' First process deletes.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException("Error Saving:" & ex.ToString)
      End Try
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As ApprovalDocLevel) As Integer
      If Not Me.Contains(value) Then
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As ApprovalDocLevelCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As ApprovalDocLevel())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As ApprovalDocLevel) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As ApprovalDocLevel(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As ApprovalDocLevelEnumerator
      Return New ApprovalDocLevelEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As ApprovalDocLevel) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As ApprovalDocLevel)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As ApprovalDocLevel)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As ApprovalDocLevelCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class ApprovalDocLevelEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As ApprovalDocLevelCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, ApprovalDocLevel)
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



  '===============================================================================================


  Public Class ApproveDoc

#Region "Members"
    Private m_entityId As Integer
    Private m_entityType As Integer
    Private m_lineNumber As Integer
    Private m_comment As String
    Private m_level As Integer
    Private m_originator As Integer
    Private m_originDate As Date
    Private m_lastEditor As Integer
		Private m_lastEditDate As Date
		Private m_reject As Boolean
#End Region

#Region "Constructors"
    Public Sub New()

    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow)
      If dr.Table.Columns.Contains("apvdoc_entityId") AndAlso Not dr.IsNull("apvdoc_entityId") Then
        m_entityId = CInt(dr("apvdoc_entityId"))
      End If
      If dr.Table.Columns.Contains("apvdoc_entitytype") AndAlso Not dr.IsNull("apvdoc_entitytype") Then
        m_entityType = CInt(dr("apvdoc_entitytype"))
      End If
      If dr.Table.Columns.Contains("apvdoc_lineNumber") AndAlso Not dr.IsNull("apvdoc_lineNumber") Then
        Me.m_lineNumber = CInt(dr("apvdoc_lineNumber"))
      End If
      If dr.Table.Columns.Contains("apvdoc_comment") AndAlso Not dr.IsNull("apvdoc_comment") Then
        m_comment = CStr(dr("apvdoc_comment"))
      End If
      If dr.Table.Columns.Contains("apvdoc_level") AndAlso Not dr.IsNull("apvdoc_level") Then
        m_level = CInt(dr("apvdoc_level"))
      End If
      If dr.Table.Columns.Contains("apvdoc_originator") AndAlso Not dr.IsNull("apvdoc_originator") Then
        m_originator = CInt(dr("apvdoc_originator"))
      End If
      If dr.Table.Columns.Contains("apvdoc_originDate") AndAlso Not dr.IsNull("apvdoc_originDate") Then
        m_originDate = CDate(dr("apvdoc_originDate"))
      End If
      If dr.Table.Columns.Contains("apvdoc_lastEditor") AndAlso Not dr.IsNull("apvdoc_lastEditor") Then
        m_lastEditor = CInt(dr("apvdoc_lastEditor"))
      End If
      If dr.Table.Columns.Contains("apvdoc_lastEditDate") AndAlso Not dr.IsNull("apvdoc_lastEditDate") Then
        m_lastEditDate = CDate(dr("apvdoc_lastEditDate"))
			End If
			If dr.Table.Columns.Contains("apvdoc_reject") AndAlso Not dr.IsNull("apvdoc_reject") Then
				m_reject = CBool(dr("apvdoc_reject"))
			End If
		End Sub
#End Region

#Region "Properties"
    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property
    Public Property Comment() As String      Get        Return m_comment      End Get      Set(ByVal Value As String)        m_comment = Value      End Set    End Property    Public Property Level() As Integer      Get        Return m_level      End Get      Set(ByVal Value As Integer)        m_level = Value      End Set    End Property    Public Property Originator() As Integer      Get        Return m_originator      End Get      Set(ByVal Value As Integer)        m_originator = Value      End Set    End Property    Public Property OriginDate() As Date      Get        Return m_originDate      End Get      Set(ByVal Value As Date)        m_originDate = Value      End Set    End Property    Public Property LastEditor() As Integer      Get        Return m_lastEditor      End Get      Set(ByVal Value As Integer)        m_lastEditor = Value      End Set    End Property    Public Property LastEditDate() As Date      Get        Return m_lastEditDate      End Get      Set(ByVal Value As Date)        m_lastEditDate = Value      End Set    End Property    Public Property EntityId() As Integer      Get        Return m_entityId      End Get      Set(ByVal Value As Integer)        m_entityId = Value      End Set    End Property    Public Property EntityType() As Integer      Get        Return m_entityType      End Get      Set(ByVal Value As Integer)        m_entityType = Value      End Set		End Property		Public Property Reject() As Boolean			Get				Return m_reject			End Get			Set(ByVal Value As Boolean)				m_reject = Value			End Set		End Property
#End Region

#Region "Methods"

#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
Public Class ApproveDocCollection
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
      , "GetApproveDoc" _
      , New SqlParameter("@entity_id", entityId) _
      , New SqlParameter("@entity_type", entityType) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim myApprove As New ApproveDoc(row)
        Me.Add(myApprove)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As ApproveDoc
      Get
        Return CType(MyBase.List.Item(index), ApproveDoc)
      End Get
      Set(ByVal value As ApproveDoc)
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
        cmd.CommandText = "Execute GetApproveDoc " & m_entityId & ", " & m_entityType

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset)
        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables(0)
        For Each dr As DataRow In dt.Rows
          dr.Delete()
        Next
        For Each myApvDoc As ApproveDoc In Me
          Dim drNew As DataRow = dt.NewRow
          drNew("apvdoc_entityId") = m_entityId
          drNew("apvdoc_entitytype") = m_entityType
          drNew("apvdoc_lineNumber") = myApvDoc.LineNumber 'i   'file.LineNumber
          drNew("apvdoc_comment") = myApvDoc.Comment
          drNew("apvdoc_level") = myApvDoc.Level
          drNew("apvdoc_originator") = myApvDoc.Originator
          drNew("apvdoc_originDate") = myApvDoc.OriginDate
          drNew("apvdoc_lastEditor") = myApvDoc.LastEditor
          drNew("apvdoc_lastEditDate") = IIf(myApvDoc.LastEditDate.Equals(Date.MinValue), DBNull.Value, myApvDoc.LastEditDate)
					drNew("apvdoc_reject") = myApvDoc.Reject
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
    Public Function MaxLevel() As Integer
      Dim ret As Integer = 0
			For Each temp As ApproveDoc In Me
				If temp.Reject Then
					ret = 0
				Else
					ret = CInt(IIf(temp.Level > ret, temp.Level, ret))
				End If
			Next
			Return ret
    End Function
    Public Function MaxLevelPersonId() As Integer
      Dim ret As Integer = 0
      Dim retUser As Integer = 0
			For Each temp As ApproveDoc In Me
				If temp.Reject Then
					ret = 0
					retUser = 0
				Else
					If temp.Level > ret Then
						ret = temp.Level
						retUser = temp.Originator
					End If
				End If
			Next
			Return retUser
    End Function
    Private MaximumLevelOfApprove As Integer = -1
    Public Function GetMaxLevel() As Integer
      If MaximumLevelOfApprove = -1 Then
        Select Case m_entityType
          Case 7
            MaximumLevelOfApprove = CInt(Configuration.GetConfig("MaxLevelApprovePR"))
          Case 6
            MaximumLevelOfApprove = CInt(Configuration.GetConfig("MaxLevelApprovePO"))
          Case 45
            MaximumLevelOfApprove = CInt(Configuration.GetConfig("MaxLevelApproveDO"))
        End Select
      End If
      Return MaximumLevelOfApprove
    End Function
    Public Function IsApproved() As Boolean
      Dim Approved As Boolean = False
      If MaxLevel() >= GetMaxLevel() Then
        Approved = True
      End If
      Return Approved
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As ApproveDoc) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As ApproveDocCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As ApproveDoc())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As ApproveDoc) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As ApproveDoc(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As ApproveDocEnumerator
      Return New ApproveDocEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As ApproveDoc) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As ApproveDoc)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As ApproveDoc)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As ApproveDocCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class ApproveDocEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As ApproveDocCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, ApproveDoc)
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
