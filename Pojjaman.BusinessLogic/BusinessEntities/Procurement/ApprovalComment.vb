Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class ApprovalComment

#Region "Members"
        Private m_entityId As Integer
        Private m_entityType As Integer
        Private m_lineNumber As Integer
        Private m_comment As String
        Private m_isApproveComment As Boolean
        Private m_originator As Integer
        Private m_originDate As Date
        Private m_lastEditor As Integer
        Private m_lastEditDate As Date
#End Region

#Region "Constructors"
        Public Sub New()

        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow)
            If dr.Table.Columns.Contains("apvcom_entityId") AndAlso Not dr.IsNull("apvcom_entityId") Then
                m_entityId = CInt(dr("apvcom_entityId"))
            End If
            If dr.Table.Columns.Contains("apvcom_entitytype") AndAlso Not dr.IsNull("apvcom_entitytype") Then
                m_entityType = CInt(dr("apvcom_entitytype"))
            End If
            If dr.Table.Columns.Contains("apvcom_lineNumber") AndAlso Not dr.IsNull("apvcom_lineNumber") Then
                Me.m_lineNumber = CInt(dr("apvcom_lineNumber"))
            End If
            If dr.Table.Columns.Contains("apvcom_comment") AndAlso Not dr.IsNull("apvcom_comment") Then
                m_comment = CStr(dr("apvcom_comment"))
            End If
            If dr.Table.Columns.Contains("apvcom_isapprovecomment") AndAlso Not dr.IsNull("apvcom_isapprovecomment") Then
                m_isApproveComment = CBool(dr("apvcom_isapprovecomment"))
            End If
            If dr.Table.Columns.Contains("apvcom_originator") AndAlso Not dr.IsNull("apvcom_originator") Then
                m_originator = CInt(dr("apvcom_originator"))
            End If
            If dr.Table.Columns.Contains("apvcom_originDate") AndAlso Not dr.IsNull("apvcom_originDate") Then
                m_originDate = CDate(dr("apvcom_originDate"))
            End If
            If dr.Table.Columns.Contains("apvcom_lastEditor") AndAlso Not dr.IsNull("apvcom_lastEditor") Then
                m_lastEditor = CInt(dr("apvcom_lastEditor"))
            End If
            If dr.Table.Columns.Contains("apvcom_lastEditDate") AndAlso Not dr.IsNull("apvcom_lastEditDate") Then
                m_lastEditDate = CDate(dr("apvcom_lastEditDate"))
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property
        Public Property Comment() As String            Get                Return m_comment            End Get            Set(ByVal Value As String)                m_comment = Value            End Set        End Property        Public Property IsApproveComment() As Boolean            Get                Return m_isApproveComment            End Get            Set(ByVal Value As Boolean)                m_isApproveComment = Value            End Set        End Property        Public Property Originator() As Integer            Get                Return m_originator            End Get            Set(ByVal Value As Integer)                m_originator = Value            End Set        End Property        Public Property OriginDate() As Date            Get                Return m_originDate            End Get            Set(ByVal Value As Date)                m_originDate = Value            End Set        End Property        Public Property LastEditor() As Integer            Get                Return m_lastEditor            End Get            Set(ByVal Value As Integer)                m_lastEditor = Value            End Set        End Property        Public Property LastEditDate() As Date            Get                Return m_lastEditDate            End Get            Set(ByVal Value As Date)                m_lastEditDate = Value            End Set        End Property        Public Property EntityId() As Integer            Get                Return m_entityId            End Get            Set(ByVal Value As Integer)                m_entityId = Value            End Set        End Property        Public Property EntityType() As Integer            Get                Return m_entityType            End Get            Set(ByVal Value As Integer)                m_entityType = Value            End Set        End Property
#End Region

#Region "Methods"

#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
Public Class ApprovalCommentCollection
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
            , "GetApprovalComment" _
            , New SqlParameter("@entity_id", entityId) _
            , New SqlParameter("@entity_type", entityType) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim file As New ApprovalComment(row)
                Me.Add(file)
            Next
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As ApprovalComment
            Get
                Return CType(MyBase.List.Item(index), ApprovalComment)
            End Get
            Set(ByVal value As ApprovalComment)
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
                cmd.CommandText = "Execute GetApprovalCommentForSaving " & m_entityId & ", " & m_entityType

                Dim m_dataset As New DataSet
                Dim m_da As New SqlDataAdapter
                m_da.SelectCommand = cmd

                m_da.Fill(m_dataset)
                Dim cmdBuilder As New SqlCommandBuilder(m_da)

                Dim dt As DataTable = m_dataset.Tables(0)
                For Each dr As DataRow In dt.Rows
                    dr.Delete()
                Next
                For Each myCom As ApprovalComment In Me
                    Dim drNew As DataRow = dt.NewRow
                    drNew("apvcom_entityId") = m_entityId
                    drNew("apvcom_entitytype") = m_entityType
                    drNew("apvcom_lineNumber") = myCom.LineNumber 'i   'file.LineNumber
                    drNew("apvcom_comment") = myCom.Comment
                    drNew("apvcom_isapprovecomment") = myCom.IsApproveComment
                    drNew("apvcom_originator") = myCom.Originator
                    drNew("apvcom_originDate") = myCom.OriginDate
                    drNew("apvcom_lastEditor") = myCom.LastEditor
                    drNew("apvcom_lastEditDate") = IIf(myCom.LastEditDate.Equals(Date.MinValue), DBNull.Value, myCom.LastEditDate)
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
        Public Function IsApproved() As Boolean
            Dim Approved As Boolean = False
            For Each myCom As ApprovalComment In Me
                If myCom.IsApproveComment Then
                    Approved = True
                End If
            Next
            Return Approved
        End Function
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As ApprovalComment) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As ApprovalCommentCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As ApprovalComment())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As ApprovalComment) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As ApprovalComment(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ApprovalCommentEnumerator
            Return New ApprovalCommentEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As ApprovalComment) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As ApprovalComment)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As ApprovalComment)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As ApprovalCommentCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class ApprovalCommentEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As ApprovalCommentCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, ApprovalComment)
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