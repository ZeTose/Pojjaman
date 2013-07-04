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
          If item.DocId <> 290 Then
            Dim dr As DataRow = dt.NewRow
            dr("app_user") = user.Id
            dr("app_doc") = item.DocId
            dr("app_level") = item.Level
            dr("app_maxamt") = item.MaxAmount
            dt.Rows.Add(dr)
            If item.DocId = 289 Then ''พอดีใช้ Config เดียวกันกับ 289              
                dr = dt.NewRow
                dr("app_user") = user.Id
                dr("app_doc") = 290
                dr("app_level") = item.Level
                dr("app_maxamt") = item.MaxAmount
                dt.Rows.Add(dr)
              End If
          End If
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

        Dim isMeReject As Boolean = False
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

          '<สำหรับกรณีเคย Reject แล้วมา comment ตามหลัง>
          If myApvDoc.Reject Then
            isMeReject = True
          Else
            If myApvDoc.Level <> 0 Then
              isMeReject = False
            End If
          End If
          '<สำหรับกรณีเคย Reject แล้วมา comment ตามหลัง>
        Next
        ' First process deletes.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        If Me.Count > 0 Then
          Dim m_DocMethod As SaveDocMultiApprovalMethod

          Dim myApvDoc As ApproveDoc = Me(Me.Count - 1)
          If myApvDoc.Reject Then
            m_DocMethod = SaveDocMultiApprovalMethod.Reject
          ElseIf myApvDoc.Level = 0 Then
            m_DocMethod = SaveDocMultiApprovalMethod.Comment
            If isMeReject Then
              m_DocMethod = SaveDocMultiApprovalMethod.Reject
            End If
          Else
            m_DocMethod = SaveDocMultiApprovalMethod.Approve
          End If

          SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "UpdateApproveDoc",
                                    New SqlParameter("@entity_id", m_entityId),
                                    New SqlParameter("@entity_type", m_entityType)
                                    )

          SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "UpdateCommentDocForMultiApproval",
                                    New SqlParameter("@apvdoc_originator", myApvDoc.Originator),
                                    New SqlParameter("@method", m_DocMethod),
                                    New SqlParameter("@apvdoc_comment", myApvDoc.Comment),
                                    New SqlParameter("@apvdoc_entityId", m_entityId),
                                    New SqlParameter("@apvdoc_entityType", m_entityType)
                                    )

          SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "UpdateApproveList",
                                    New SqlParameter("@entity_id", m_entityId),
                                    New SqlParameter("@entity_type", m_entityType)
                                    )

          SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "UpdateCommentList",
                                    New SqlParameter("@entity_id", m_entityId),
                                    New SqlParameter("@entity_type", m_entityType)
                                    )
        End If

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
          Case 324
            MaximumLevelOfApprove = CInt(Configuration.GetConfig("MaxLevelApproveWR"))
          Case 289, 290  'SC,VO
            MaximumLevelOfApprove = CInt(Configuration.GetConfig("MaxLevelApproveSC"))
          Case 291
            MaximumLevelOfApprove = CInt(Configuration.GetConfig("MaxLevelApproveDR"))
          Case 292
            MaximumLevelOfApprove = CInt(Configuration.GetConfig("MaxLevelApprovePA"))

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
    Public Function GetLastedApproveDoc() As ApproveDoc
      If Me.Count > 0 Then
        Dim approveDoc As ApproveDoc = Me(Me.Count - 1)
        If Not approveDoc Is Nothing Then
          Return approveDoc
        End If
      End If
      Return New ApproveDoc
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


  Public Class ApprovalMultiDoc
    Inherits ApproveDoc
    Public Function Save() As SaveErrorException
      Try
        SqlHelper.ExecuteNonQuery(SimpleBusinessEntityBase.ConnectionString, _
                                  CommandType.StoredProcedure, _
                                  "InsertMultiApproval", _
                                  New SqlParameter("@apvdoc_entityId", Me.EntityId), _
                                  New SqlParameter("@apvdoc_entityType", Me.EntityType), _
                                  New SqlParameter("@apvdoc_comment", Me.Comment), _
                                  New SqlParameter("@apvdoc_level", Me.Level), _
                                  New SqlParameter("@apvdoc_originator", Me.Originator), _
                                  New SqlParameter("@apvdoc_reject", Me.Reject)
                                  )

        SqlHelper.ExecuteNonQuery(SimpleBusinessEntityBase.ConnectionString, _
                                  CommandType.StoredProcedure, "UpdateApproveList",
                                  New SqlParameter("@entity_id", Me.EntityId),
                                  New SqlParameter("@entity_type", Me.EntityType)
                                  )

        SqlHelper.ExecuteNonQuery(SimpleBusinessEntityBase.ConnectionString, _
                                  CommandType.StoredProcedure, "UpdateCommentList",
                                  New SqlParameter("@entity_id", Me.EntityId),
                                  New SqlParameter("@entity_type", Me.EntityType)
                                  )

        'New SqlParameter("@apvdoc_linenumber", Me.LineNumber + 1), _

        'Dim mldoc As New DocMultiApproval(Me.EntityId, Me.EntityType)
        'mldoc.UpdateApproveFromDocument()

        Return New SaveErrorException("0")
      Catch ex As Exception
        Return New SaveErrorException(ex.Message & vbCrLf & ex.InnerException.ToString)
      End Try
    End Function
  End Class

  Public Enum SaveDocMultiApprovalMethod
    Reject '0
    Save '1
    Edit '2
    Update '3
    Comment '4
    Approve '5
    Authorize '6
    Delete '7
    Cancel '8
    Close '9
  End Enum

  Public Class DocMultiApproval

    Public Property DocId As Long
    Public Property DocType As Integer
    Public Property DocCode As String
    Public Property DocDate As DateTime
    Public Property DocAmount As Decimal
    Public Property EditorId As Integer
    Public Property DocMethod As SaveDocMultiApprovalMethod
    Public Property EditDate As DateTime
    Public Property DocComment As String
    Public Property DocCCId As Integer
    Public Property DocSupplierId As Integer
    Public Property RefDoc As IApprovAble

    Public Sub New(ByVal docid As Long,
                  ByVal doctype As Integer
                  )
      Me.DocId = docid
      Me.DocType = doctype
    End Sub
    Public Sub New(ByVal docid As Long,
                   ByVal doctype As Integer,
                   ByVal doccode As String,
                   ByVal docdate As DateTime,
                   ByVal docamount As Decimal,
                   ByVal editorid As Integer,
                   ByVal docmethod As SaveDocMultiApprovalMethod,
                   ByVal doccomment As String,
                   ByVal docccid As Integer,
                   ByVal docsupplierid As Integer,
                   ByVal refdoc As IApprovAble
                   )
      Me.DocId = docid
      Me.DocType = doctype
      Me.DocCode = doccode
      Me.DocDate = docdate
      Me.DocAmount = docamount
      Me.EditorId = editorid
      Me.DocMethod = docmethod
      'Me.EditDate = 
      Me.DocComment = doccomment
      Me.DocCCId = docccid
      Me.DocSupplierId = docsupplierid
      Me.RefDoc = refdoc
    End Sub

    Public Function UpdateApprove(ByVal UserId As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        If (Me.DocMethod = SaveDocMultiApprovalMethod.Authorize OrElse
            Me.DocMethod = SaveDocMultiApprovalMethod.Delete OrElse
            Me.DocMethod = SaveDocMultiApprovalMethod.Cancel OrElse
            Me.DocMethod = SaveDocMultiApprovalMethod.Close) Then
          SqlHelper.ExecuteNonQuery(conn,
                                  trans,
                                  CommandType.StoredProcedure,
                                  "DeleteDocForMultiApproval",
                                  New SqlParameter("@DocId", Me.DocId),
                                  New SqlParameter("@DocType", Me.DocType)
                                  )
        Else
          SqlHelper.ExecuteNonQuery(conn,
                                  trans,
                                  CommandType.StoredProcedure,
                                  "UpdateDocForMultiApproval",
                                  New SqlParameter("@DocId", Me.DocId),
                                  New SqlParameter("@DocType", Me.DocType),
                                  New SqlParameter("@DocCode", Me.DocCode),
                                  New SqlParameter("@DocDate", Me.DocDate),
                                  New SqlParameter("@DocAmount", Me.DocAmount),
                                  New SqlParameter("@EditorId", Me.EditorId),
                                  New SqlParameter("@MethodId", Me.DocMethod),
                                  New SqlParameter("@DocComment", Me.DocComment),
                                  New SqlParameter("@DocCCId", Me.DocCCId),
                                  New SqlParameter("@DocSupplierId", Me.DocSupplierId),
                                  New SqlParameter("@IsApproved", Me.RefDoc.IsApproved)
                                  )
        End If

      Catch ex As Exception
        Return New SaveErrorException(ex.Message)
      End Try
      Return New SaveErrorException("0")
    End Function

    'Public Function UpdateApproveFromDocument() As SaveErrorException
    '  Try
    '    SqlHelper.ExecuteNonQuery(SimpleBusinessEntityBase.ConnectionString,
    '                            CommandType.StoredProcedure,
    '                            "UpdateDocForMultiApprovalFromDocument",
    '                            New SqlParameter("@DocId", Me.DocId),
    '                            New SqlParameter("@DocType", Me.DocType)
    '                            )
    '  Catch ex As Exception
    '    Return New SaveErrorException(ex.Message)
    '  End Try
    '  Return New SaveErrorException("0")
    'End Function

  End Class

End Namespace
