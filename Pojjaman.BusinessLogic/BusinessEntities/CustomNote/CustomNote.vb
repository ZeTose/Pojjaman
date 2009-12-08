Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class CustomNote

#Region "Members"
        Private m_noteName As String
        Private m_note As Object
        Private m_codeDescription As CodeDescription
        Private m_isDropDown As Boolean
        Private m_entityId As Integer
        Private m_entityType As Integer
        Private m_fix As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            m_noteName = ""
            m_note = ""
            m_isDropDown = False
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow)
            If dr.Table.Columns.Contains("cnote_codename") AndAlso Not dr.IsNull("cnote_codename") Then
                Dim codeName As String = ""
                codeName = CStr(dr("cnote_codename"))
            End If
            If dr.Table.Columns.Contains("cnote_noteName") AndAlso Not dr.IsNull("cnote_noteName") Then
                Me.m_noteName = CStr(dr("cnote_noteName"))
            End If
            If dr.Table.Columns.Contains("cnote_type") AndAlso Not dr.IsNull("cnote_type") Then
                Select Case CInt(dr("cnote_type"))
                    Case 0 'คีย์ตรง
                        m_isDropDown = False
                    Case 1 'dropdown
                        m_isDropDown = True
                End Select
            End If
            If dr.Table.Columns.Contains("cnote_note") AndAlso Not dr.IsNull("cnote_note") Then
                Dim noteValue As String = CStr(dr("cnote_note"))
                If m_isDropDown Then
                    m_note = Boolean.Parse(noteValue)
                Else
                    m_note = noteValue
                End If
            End If
            If dr.Table.Columns.Contains("cnote_type") AndAlso Not dr.IsNull("cnote_type") Then
                m_entityId = CInt(dr("cnote_type"))
            End If
            If dr.Table.Columns.Contains("cnote_entityId") AndAlso Not dr.IsNull("cnote_entityId") Then
                m_entityId = CInt(dr("cnote_entityId"))
            End If
            If dr.Table.Columns.Contains("cnote_entitytype") AndAlso Not dr.IsNull("cnote_entitytype") Then
                m_entityType = CInt(dr("cnote_entitytype"))
            End If
            If dr.Table.Columns.Contains("fix") AndAlso Not dr.IsNull("fix") Then
                m_fix = CBool(dr("fix"))
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property NoteName() As String            Get                Return m_noteName            End Get            Set(ByVal Value As String)                m_noteName = Value            End Set        End Property        Public Property Note() As Object            Get                Return m_note            End Get            Set(ByVal Value As Object)                m_note = Value            End Set        End Property        Public Property CodeDescription() As CodeDescription            Get                Return m_codeDescription            End Get            Set(ByVal Value As CodeDescription)                m_codeDescription = Value            End Set        End Property        Public Property IsDropDown() As Boolean            Get                Return m_isDropDown            End Get            Set(ByVal Value As Boolean)                m_isDropDown = Value            End Set        End Property        Public Property Fix() As Boolean            Get                Return m_fix            End Get            Set(ByVal Value As Boolean)                m_fix = Value            End Set        End Property        Public Property EntityId() As Integer            Get                Return m_entityId            End Get            Set(ByVal Value As Integer)                m_entityId = Value            End Set        End Property        Public Property EntityType() As Integer            Get                Return m_entityType            End Get            Set(ByVal Value As Integer)                m_entityType = Value            End Set        End Property
#End Region

#Region "Methods"

#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
Public Class CustomNoteCollection
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
            , "GetCustomNotes" _
            , New SqlParameter("@entity_id", entityId) _
            , New SqlParameter("@entity_type", entityType) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim note As New CustomNote(row)
                Me.Add(note)
            Next
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As CustomNote
            Get
                Return CType(MyBase.List.Item(index), CustomNote)
            End Get
            Set(ByVal value As CustomNote)
                MyBase.List.Item(index) = value
            End Set
        End Property
        Public WriteOnly Property EntityId() As Integer
            Set(ByVal Value As Integer)
                m_entityId = Value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Function Save() As SaveErrorException
            Try
                Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
                Dim conn As New SqlConnection(sqlConString)
                Dim cmd As SqlCommand = conn.CreateCommand
                cmd.CommandText = "Execute GetCustomNotesForSaving " & m_entityId & ", " & m_entityType

                Dim m_dataset As New DataSet
                Dim m_da As New SqlDataAdapter
                m_da.SelectCommand = cmd

                m_da.Fill(m_dataset)
                Dim cmdBuilder As New SqlCommandBuilder(m_da)

                Dim dt As DataTable = m_dataset.Tables(0)
                For Each dr As DataRow In dt.Rows
                    dr.Delete()
                Next
                For Each note As CustomNote In Me
                    Dim drNew As DataRow = dt.NewRow
                    drNew("cnote_entityId") = m_entityId
                    drNew("cnote_entitytype") = m_entityType
                    drNew("cnote_noteName") = note.NoteName
                    drNew("cnote_note") = CStr(note.Note)
                    drNew("cnote_type") = CBool(note.IsDropDown)
                    dt.Rows.Add(drNew)
                Next
                ' First process deletes.
                m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
                ' Next process updates.
                m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
                ' Finally process inserts.
                m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))


                cmd.CommandText = "Execute GetCustomNoteMetaForSaving " & m_entityId & ", " & m_entityType
                m_dataset = New DataSet
                m_da = New SqlDataAdapter
                m_da.SelectCommand = cmd

                m_da.Fill(m_dataset)
                cmdBuilder = New SqlCommandBuilder(m_da)

                Dim dt2 As DataTable = m_dataset.Tables(0)
                For Each dr As DataRow In dt2.Rows
                    dr.Delete()
                Next
                For Each note As CustomNote In Me
                    If note.Fix Then
                        Dim drNew As DataRow = dt2.NewRow
                        drNew("cnote_entitytype") = m_entityType
                        drNew("cnote_noteName") = note.NoteName
                        drNew("cnote_type") = CBool(note.IsDropDown)
                        dt2.Rows.Add(drNew)
                    End If
                Next
                ' First process deletes.
                m_da.Update(dt2.Select(Nothing, Nothing, DataViewRowState.Deleted))
                ' Next process updates.
                m_da.Update(dt2.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
                ' Finally process inserts.
                m_da.Update(dt2.Select(Nothing, Nothing, DataViewRowState.Added))
                Return New SaveErrorException("1")
            Catch ex As Exception
                MessageBox.Show("Error Saving:" & ex.ToString)
            End Try
        End Function
#End Region


#Region "Collection Methods"
        Public Function Add(ByVal value As CustomNote) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As CustomNoteCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As CustomNote())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As CustomNote) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As CustomNote(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As CustomNoteEnumerator
            Return New CustomNoteEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As CustomNote) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As CustomNote)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As CustomNote)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As CustomNoteCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class CustomNoteEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As CustomNoteCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, CustomNote)
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