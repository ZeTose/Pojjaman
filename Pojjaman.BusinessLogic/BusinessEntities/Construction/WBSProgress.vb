Imports Longkong.Pojjaman.DataAccessLayer
'Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic

    Public Class WBSProgress
        Inherits SimpleBusinessEntityBase

#Region "Members"
        Private m_boqid As Integer
        Private m_wbsid As Integer
        Private m_progressdate As Date
        Private m_progress As Decimal
#End Region

#Region "Constuctors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow)
            Construct(dr)
        End Sub
        Private Overloads Sub Construct(ByVal dr As System.Data.DataRow)
            If dr.Table.Columns.Contains("wbsp_boq") AndAlso Not dr.IsNull("wbsp_boq") Then
                BOQId = CInt(dr("wbsp_boq"))
            End If
            If dr.Table.Columns.Contains("wbsp_wbs") AndAlso Not dr.IsNull("wbsp_wbs") Then
                WBSId = CInt(dr("wbsp_wbs"))
            End If
            If dr.Table.Columns.Contains("wbsp_progressdate") AndAlso Not dr.IsNull("wbsp_progressdate") Then
                m_progressdate = CDate(dr("wbsp_progressdate"))
            End If
            If dr.Table.Columns.Contains("wbsp_progress") AndAlso Not dr.IsNull("wbsp_progress") Then
                m_progress = CDec(dr("wbsp_progress"))
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property BOQId() As Integer            Get                Return m_boqid            End Get            Set(ByVal Value As Integer)                m_boqid = Value            End Set        End Property
        Public Property WBSId() As Integer            Get                Return m_wbsid            End Get            Set(ByVal Value As Integer)                m_wbsid = Value            End Set        End Property        'Public Property Code() As String        '    Get        '        Return m_code        '    End Get        '    Set(ByVal Value As String)        '        m_code = Value        '    End Set        'End Property
        Public Property ProgressDate() As Date
            Get
                Return m_progressdate
            End Get
            Set(ByVal Value As Date)
                m_progressdate = Value
            End Set
        End Property
        Public Property Progress() As Decimal
            Get
                Return m_progress
            End Get
            Set(ByVal Value As Decimal)
                m_progress = Value
            End Set
        End Property
#End Region

        'Public ReadOnly Property CodonName() As String Implements ISimpleEntity.CodonName
        '    Get
        '        If TypeOf Me Is TreeBaseEntity Then
        '            Return "TreeBaseEntity"
        '        End If
        '        Return "ccbudget" 'Me.ClassName
        '    End Get
        'End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "WBSProgress"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "wbsp"
            End Get
        End Property
        'Public Overrides ReadOnly Property DetailPanelTitle() As String
        '    Get
        '        Return "${res:Longkong.Pojjaman.BusinessLogic.CCBudget.DetailLabel}"
        '    End Get
        'End Property
        'Public Overrides ReadOnly Property DetailPanelIcon() As String
        '    Get
        '        Return "Icons.16x16.PR"
        '    End Get
        'End Property
        'Public Overrides ReadOnly Property ListPanelIcon() As String
        '    Get
        '        Return "Icons.16x16.PR"
        '    End Get
        'End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.WBSProgress.ListLabel}"
            End Get
        End Property
        'Public Overrides ReadOnly Property TabPageText() As String
        '    Get
        '        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        '        Dim blankSuffix As String = "()"
        '        If tpt.EndsWith(blankSuffix) Then
        '            tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        '        End If
        '        Return tpt
        '    End Get
        'End Property

    End Class

    <Serializable(), DefaultMember("Item")> _
    Public Class WBSProgressCollection
        Inherits CollectionBase
        Implements IExtender

#Region "Members"
        'Private m_cc As Costcenter
        Private m_boq As BOQ
        Private m_rowcount As Integer
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Private Function CheckExistingOrAddToParent() As Boolean
            For Each ext As IExtender In m_boq.Extenders
                If TypeOf ext Is WBSProgressCollection Then
                    Return True
                End If
            Next
            m_boq.Extenders.Add(Me)
            Return False
        End Function
        Public Sub New(ByVal myBOQ As BOQ)
            If myBOQ Is Nothing Then
                Return
            End If

            m_boq = myBOQ

            If CheckExistingOrAddToParent() Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetWBSProgressList" _
            , New SqlParameter("@wbsp_boq", m_boq.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New WBSProgress(row)
                Me.Add(item)
            Next
        End Sub
#End Region

#Region "Properties"
        Public Property BOQ() As BOQ
            Get
                Return m_boq
            End Get
            Set(ByVal Value As BOQ)
                m_boq = Value
            End Set
        End Property
        Public Property RowCount() As Integer
            Get
                Return m_rowcount
            End Get
            Set(ByVal Value As Integer)
                m_rowcount = Value
            End Set
        End Property
        Default Public Property Item(ByVal index As Integer) As WBSProgressCollection
            Get
                Return CType(MyBase.List.Item(index), WBSProgressCollection)
            End Get
            Set(ByVal value As WBSProgressCollection)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Sub Populate(ByVal dt As TreeTable, ByVal wbsid As Integer)

            dt.Clear()
            Dim i As Integer = 0
            m_rowcount = 0
            For Each myWBS As WBSProgress In Me
                If wbsid.Equals(myWBS.WBSId) Then
                    i += 1
                    m_rowcount += 1
                    Dim newRow As TreeRow = dt.Childs.Add()
                    'newRow.Item("selected") = True
                    newRow.Item("wbsp_linenumber") = i.ToString
                    newRow.Item("wbsp_wbs") = myWBS.WBSId
                    newRow.Item("wbsp_progressdate") = myWBS.ProgressDate
                    newRow.Item("wbsp_progress") = myWBS.Progress
                    newRow.Tag = myWBS
                End If

            Next
            dt.AcceptChanges()
        End Sub
        Public Function Save(ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException Implements IExtender.Save
            Try
                If m_boq Is Nothing OrElse Not m_boq.Originated Then
                    Return New SaveErrorException("0")
                End If

                Dim da As New SqlDataAdapter("Select * from wbsprogress where wbsp_boq = " & m_boq.Id, conn)

                Dim ds As New DataSet

                Dim cmdBuilder As New SqlCommandBuilder(da)
                da.SelectCommand.Transaction = trans
                da.DeleteCommand = cmdBuilder.GetDeleteCommand
                da.DeleteCommand.Transaction = trans
                da.InsertCommand = cmdBuilder.GetInsertCommand
                da.InsertCommand.Transaction = trans
                da.UpdateCommand = cmdBuilder.GetUpdateCommand
                da.UpdateCommand.Transaction = trans
                cmdBuilder = Nothing
                da.FillSchema(ds, SchemaType.Mapped, "wbsprogress")
                da.Fill(ds, "wbsprogress")

                Dim dt As DataTable = ds.Tables("wbsprogress")
                For Each row As DataRow In ds.Tables("wbsprogress").Rows
                    row.Delete()
                Next

                For Each item As WBSProgress In Me
                    Dim dr As DataRow = dt.NewRow

                    'dr("wbsp_id") = item.Id
                    dr("wbsp_wbs") = item.WBSId
                    dr("wbsp_boq") = m_boq.Id
                    dr("wbsp_progressdate") = item.ProgressDate
                    dr("wbsp_progress") = item.Progress
                    dt.Rows.Add(dr)
                Next

                da.Update(dt.Select("", "", DataViewRowState.Deleted))
                da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
                da.Update(dt.Select("", "", DataViewRowState.Added))

                Return New SaveErrorException("1")
            Catch ex As Exception
                Return New SaveErrorException(ex.ToString)
            End Try

        End Function
        Public Function Delete(ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException Implements IExtender.Delete
            If m_boq Is Nothing OrElse Not m_boq.Originated Then
                Return New SaveErrorException("0")
            End If
            Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
            returnVal.ParameterName = "RETURN_VALUE"
            returnVal.DbType = DbType.Int32
            returnVal.Direction = ParameterDirection.ReturnValue
            returnVal.SourceVersion = DataRowVersion.Current
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, _
                                    "DeleteWBSProgress", _
                                    New SqlParameter() { _
                                    New SqlParameter("@boq_id", m_boq.Id) _
                                    , returnVal})

            Return New SaveErrorException(returnVal.Value.ToString)
        End Function
        'Public Shared Function GetBudgetList(ByVal txtCode As TextBox, ByRef cc As CostCenter) As Integer

        '    Dim budgetCollection As New CCBudgetCollection(cc)
        '    For Each bgColl As CCBudget In budgetCollection
        '        If bgColl.Name = txtCode.Text Then
        '            Return bgColl.Id
        '        End If
        '    Next

        '    MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        '    txtCode.Text = ""
        '    Return Nothing
        'End Function
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As WBSProgress) As Integer
            If Not MyBase.List.Contains(value) Then
                Return MyBase.List.Add(value)
            End If
        End Function
        'Public Sub AddRange(ByVal value As CCBudgetBudgetCollection)
        '    For i As Integer = 0 To value.Count - 1
        '        Me.Add(value(i))
        '    Next
        'End Sub
        Public Sub AddRange(ByVal value As WBSProgress())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        'Public Function Contains(ByVal value As CCBudgetbudget) As Boolean
        '    Return MyBase.List.Contains(value)
        'End Function
        'Public Sub CopyTo(ByVal array As CCBudgetbudget(), ByVal index As Integer)
        '    MyBase.List.CopyTo(array, index)
        'End Sub
        'Public Shadows Function GetEnumerator() As CCBudgetBudgetEnumerator
        '    Return New CCBudgetBudgetEnumerator(Me)
        'End Function
        'Public Function IndexOf(ByVal value As CCBudgetbudget) As Integer
        '    Return MyBase.List.IndexOf(value)
        'End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As WBSProgress)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As WBSProgress)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As WBSProgressCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region

    End Class




End Namespace