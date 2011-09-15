Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
	Public Interface IUnlockAble
    Property Unlock() As UnlockType
	End Interface
	Public Class UnlockDoc

#Region "Members"
		Private m_entityId As Integer
		Private m_entityType As Integer
		Private m_comment As String
		Private m_person As Integer
    Private m_date As Date
    Private m_unlockType As UnlockType
#End Region

#Region "Constructors"
		Public Sub New()

		End Sub
		Public Sub New(ByVal dr As System.Data.DataRow)
			If dr.Table.Columns.Contains("unlock_entityId") AndAlso Not dr.IsNull("unlock_entityId") Then
				m_entityId = CInt(dr("unlock_entityId"))
			End If
			If dr.Table.Columns.Contains("unlock_entityType") AndAlso Not dr.IsNull("unlock_entityType") Then
				m_entityType = CInt(dr("unlock_entityType"))
			End If
			If dr.Table.Columns.Contains("unlock_comment") AndAlso Not dr.IsNull("unlock_comment") Then
				m_comment = CStr(dr("unlock_comment"))
			End If
			If dr.Table.Columns.Contains("unlock_person") AndAlso Not dr.IsNull("unlock_person") Then
				m_person = CInt(dr("unlock_person"))
			End If
			If dr.Table.Columns.Contains("unlock_date") AndAlso Not dr.IsNull("unlock_date") Then
				m_date = CDate(dr("unlock_date"))
      End If
      If dr.Table.Columns.Contains("unlock_type") AndAlso Not dr.IsNull("unlock_type") Then
        m_unlockType = CType(CInt(dr("unlock_type")), UnlockType)
      End If
		End Sub
#End Region

#Region "Properties"

		Public Property Comment() As String			Get				Return m_comment			End Get			Set(ByVal Value As String)				m_comment = Value			End Set		End Property		Public Property Person() As Integer			Get				Return m_person			End Get			Set(ByVal Value As Integer)				m_person = Value			End Set		End Property		Public Property [Date]() As Date			Get				Return m_date			End Get			Set(ByVal Value As Date)				m_date = Value			End Set		End Property		Public Property EntityId() As Integer			Get				Return m_entityId			End Get			Set(ByVal Value As Integer)				m_entityId = Value			End Set		End Property		Public Property EntityType() As Integer			Get				Return m_entityType			End Get			Set(ByVal Value As Integer)				m_entityType = Value			End Set    End Property    Public Property UnlockType As UnlockType      Get
        Return m_unlockType
      End Get
      Set(ByVal value As UnlockType)
        m_unlockType = value
      End Set
    End Property
#End Region

#Region "Methods"

#End Region

	End Class

	<Serializable(), DefaultMember("Item")> _
	Public Class UnlockDocCollection
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
			, "GetUnlockDoc" _
			, New SqlParameter("@entity_id", entityId) _
			, New SqlParameter("@entity_type", entityType) _
			)

			For Each row As DataRow In ds.Tables(0).Rows
				Dim myUnlockDoc As New UnlockDoc(row)
				Me.Add(myUnlockDoc)
			Next
		End Sub
#End Region

#Region "Properties"
		Default Public Property Item(ByVal index As Integer) As UnlockDoc
			Get
				Return CType(MyBase.List.Item(index), UnlockDoc)
			End Get
			Set(ByVal value As UnlockDoc)
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
				cmd.CommandText = "Execute GetUnlockDoc " & m_entityId & ", " & m_entityType

				Dim m_dataset As New DataSet
				Dim m_da As New SqlDataAdapter
				m_da.SelectCommand = cmd

				m_da.Fill(m_dataset)
				Dim cmdBuilder As New SqlCommandBuilder(m_da)

				Dim dt As DataTable = m_dataset.Tables(0)
				For Each dr As DataRow In dt.Rows
					dr.Delete()
				Next
				For Each myUnlockDoc As UnlockDoc In Me
					Dim drNew As DataRow = dt.NewRow
					drNew("unlock_entityId") = m_entityId
					drNew("unlock_entityType") = m_entityType
					drNew("unlock_comment") = myUnlockDoc.Comment
					drNew("unlock_date") = myUnlockDoc.Date
          drNew("unlock_person") = myUnlockDoc.Person
          drNew("unlock_type") = myUnlockDoc.UnlockType
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
#End Region

#Region "Collection Methods"
		Public Function Add(ByVal value As UnlockDoc) As Integer
			Return MyBase.List.Add(value)
		End Function
		Public Sub AddRange(ByVal value As UnlockDocCollection)
			For i As Integer = 0 To value.Count - 1
				Me.Add(value(i))
			Next
		End Sub
		Public Sub AddRange(ByVal value As UnlockDoc())
			For i As Integer = 0 To value.Length - 1
				Me.Add(value(i))
			Next
		End Sub
		Public Function Contains(ByVal value As UnlockDoc) As Boolean
			Return MyBase.List.Contains(value)
		End Function
		Public Sub CopyTo(ByVal array As UnlockDoc(), ByVal index As Integer)
			MyBase.List.CopyTo(array, index)
		End Sub
		Public Shadows Function GetEnumerator() As UnlockDocEnumerator
			Return New UnlockDocEnumerator(Me)
		End Function
		Public Function IndexOf(ByVal value As UnlockDoc) As Integer
			Return MyBase.List.IndexOf(value)
		End Function
		Public Sub Insert(ByVal index As Integer, ByVal value As UnlockDoc)
			MyBase.List.Insert(index, value)
		End Sub
		Public Sub Remove(ByVal value As UnlockDoc)
			MyBase.List.Remove(value)
		End Sub
		Public Sub Remove(ByVal value As UnlockDocCollection)
			For i As Integer = 0 To value.Count - 1
				Me.Remove(value(i))
			Next
		End Sub
		Public Sub Remove(ByVal index As Integer)
			MyBase.List.RemoveAt(index)
		End Sub
#End Region

		Public Class UnlockDocEnumerator
			Implements IEnumerator

#Region "Members"
			Private m_baseEnumerator As IEnumerator
			Private m_temp As IEnumerable
#End Region

#Region "Construtor"
			Public Sub New(ByVal mappings As UnlockDocCollection)
				Me.m_temp = mappings
				Me.m_baseEnumerator = Me.m_temp.GetEnumerator
			End Sub
#End Region

			Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
				Get
					Return CType(Me.m_baseEnumerator.Current, UnlockDoc)
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