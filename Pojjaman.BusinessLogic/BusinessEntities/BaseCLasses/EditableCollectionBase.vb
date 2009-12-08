Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class EditableCollectionBase
        Inherits CollectionBase
        Implements IListEditableCollection

#Region "Members"
        Private m_dataset As Dataset
        Private m_da As SqlDataAdapter
        Private m_owner As ISimpleEntity
#End Region

#Region "Properties"
        Public Overridable ReadOnly Property SprocName() As String Implements IListEditableCollection.SprocName
            Get
                Return ""
            End Get
        End Property
        Public Overridable ReadOnly Property TableName() As String Implements IListEditableCollection.TableName
            Get
                Return ""
            End Get
        End Property
#End Region

#Region "Methods"
        Protected Function GetParamsString(ByVal filters() As Filter) As String
            Dim ret As String = ""
            If Not filters Is Nothing AndAlso filters.Length > 0 Then
                For i As Integer = 0 To filters.Length - 1
                    ret &= "@" & filters(i).Name & ","
                Next
            End If
            ret = ret.TrimEnd(","c)
            Return ret
        End Function
#End Region

#Region "IListEditableCollection"
        Public Overridable Function CreateTableStyle() As DataGridTableStyle Implements IListEditableCollection.CreateTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = Me.TableName
            For Each col As Column In Owner.Columns
                Dim cs As New TreeTextColumn
                cs.MappingName = col.Name
                Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                cs.HeaderText = myStringParserService.Parse(col.Alias)
                cs.Width = col.Width
                cs.NullText = ""
                dst.GridColumnStyles.Add(cs)
            Next
            Return dst
        End Function
        Public Property Owner() As ISimpleEntity Implements IListEditableCollection.Owner
            Get
                Return m_owner
            End Get
            Set(ByVal Value As ISimpleEntity)
                m_owner = Value
            End Set
        End Property
        Public ReadOnly Property Dataset() As System.Data.DataSet Implements IListEditableCollection.Dataset
            Get
                Return m_dataset
            End Get
        End Property

        Public Overridable Sub RefreshDataSet(ByVal filters() As Filter) Implements IListEditableCollection.RefreshDataSet

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim cmd As SqlCommand = conn.CreateCommand
            cmd.CommandText = "Execute " & SprocName & " " & GetParamsString(filters)
            If Not filters Is Nothing AndAlso filters.Length > 0 Then
                For i As Integer = 0 To filters.Length - 1
                    cmd.Parameters.Add(New SqlParameter("@" & filters(i).Name, filters(i).Value))
                Next
            End If
            m_dataset = New Dataset
            m_da = New SqlDataAdapter
            m_da.SelectCommand = cmd

            m_da.Fill(m_dataset, Me.TableName)

            Dim cmdBuilder As New SqlCommandBuilder(m_da)
        End Sub
        Public Overridable Function Save(ByVal currentUserId As Integer) As SaveErrorException Implements IListEditableCollection.Save
            Try
                Dim dt As DataTable = m_dataset.Tables(Me.TableName)
                ' First process deletes.
                m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
                ' Next process updates.
                m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
                ' Finally process inserts.
                m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
                Return New SaveErrorException("1")
            Catch ex As Exception
                Return New SaveErrorException("Error Saving")
            End Try
        End Function
        Public Overridable Sub ColumnChanged(ByVal sende As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Implements IListEditableCollection.ColumnChanged

        End Sub

        Public Overridable Sub ColumnChanging(ByVal sende As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Implements IListEditableCollection.ColumnChanging

        End Sub

        Public Overridable Sub RowDeleted(ByVal sende As Object, ByVal e As System.Data.DataRowChangeEventArgs) Implements IListEditableCollection.RowDeleted

        End Sub
        Public Overridable Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs) Implements IListEditableCollection.ItemAdded

        End Sub
#End Region

    End Class
End Namespace
