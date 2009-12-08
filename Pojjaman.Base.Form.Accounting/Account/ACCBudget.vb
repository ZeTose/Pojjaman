Imports Longkong.Pojjaman.DataAccessLayer
'Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic

    Public Class ACCBudget
        Inherits SimpleBusinessEntityBase

#Region "Members"
        Private m_id As Integer
        Private m_code As String
        Private m_name As String
        Private m_startdate As Date
        Private m_enddate As Date
        Private m_budget As Decimal
#End Region

#Region "Constuctors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow)
            Construct(dr)
        End Sub
        Private Overloads Sub Construct(ByVal dr As System.Data.DataRow)
            If dr.Table.Columns.Contains("accid") AndAlso Not dr.IsNull("accid") Then
                Id = CInt(dr("accid"))
            End If
            If dr.Table.Columns.Contains("Code") AndAlso Not dr.IsNull("Code") Then
                Code = CStr(dr("Code"))
            End If

            If dr.Table.Columns.Contains("name") AndAlso Not dr.IsNull("name") Then
                m_name = CStr(dr("name"))
            End If
            If dr.Table.Columns.Contains("startdate") AndAlso Not dr.IsNull("startdate") Then
                m_startdate = CDate(dr("startdate"))
            End If
            If dr.Table.Columns.Contains("enddate") AndAlso Not dr.IsNull("enddate") Then
                m_enddate = CDate(dr("enddate"))
            End If
            If dr.Table.Columns.Contains("budget") AndAlso Not dr.IsNull("budget") Then
                m_budget = CDec(dr("budget"))
            End If
        End Sub
#End Region

#Region "Properties"
        'Public Property Id() As Integer        '    Get        '        Return m_id        '    End Get        '    Set(ByVal Value As Integer)        '        m_id = Value        '    End Set        'End Property        'Public Property Code() As String        '    Get        '        Return m_code        '    End Get        '    Set(ByVal Value As String)        '        m_code = Value        '    End Set        'End Property
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property
        Public Property StartDate() As Date
            Get
                Return m_startdate
            End Get
            Set(ByVal Value As Date)
                m_startdate = Value
            End Set
        End Property
        Public Property EndDate() As Date
            Get
                Return m_enddate
            End Get
            Set(ByVal Value As Date)
                m_enddate = Value
            End Set
        End Property
        Public Property Budget() As Decimal
            Get
                Return m_budget
            End Get
            Set(ByVal Value As Decimal)
                m_budget = Value
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
                Return "ACCBudget"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "accb"
            End Get
        End Property
        'Public Overrides ReadOnly Property DetailPanelTitle() As String
        '    Get
        '        Return "${res:Longkong.Pojjaman.BusinessLogic.ACCBudget.DetailLabel}"
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
                Return "${res:Longkong.Pojjaman.BusinessLogic.ACCBudget.ListLabel}"
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
    Public Class ACCBudgetCollection
        Inherits CollectionBase
        Implements IExtender

#Region "Members"
        Private m_acc As Account
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Private Function CheckExistingOrAddToParent() As Boolean
            For Each ext As IExtender In m_acc.Extenders
                If TypeOf ext Is ACCBudgetCollection Then
                    Return True
                End If
            Next
            m_acc.Extenders.Add(Me)
            Return False
        End Function
        Public Sub New(ByVal mycc As Account)
            If mycc Is Nothing Then
                Return
            End If

            m_acc = mycc

            If CheckExistingOrAddToParent() Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetACCBudgetList" _
            , New SqlParameter("@acct_id", m_acc.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New ACCBudget(row)
                Me.Add(item)
            Next
        End Sub
#End Region

#Region "Properties"
        Public Property Costcenter() As Account
            Get
                Return m_acc
            End Get
            Set(ByVal Value As Account)
                m_acc = Value
            End Set
        End Property
        Default Public Property Item(ByVal index As Integer) As ACCBudgetCollection
            Get
                Return CType(MyBase.List.Item(index), ACCBudgetCollection)
            End Get
            Set(ByVal value As ACCBudgetCollection)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Sub Populate(ByVal dt As TreeTable)

            dt.Clear()
            Dim i As Integer = 0
            For Each mybudget As ACCBudget In Me
                i += 1
                Dim newRow As TreeRow = dt.Childs.Add()

                'newRow.Item("selected") = True
                newRow.Item("linenumber") = i.ToString
                newRow.Item("Name") = mybudget.Name
                newRow.Item("StartDate") = mybudget.StartDate.ToShortDateString
                newRow.Item("EndDate") = mybudget.EndDate.ToShortDateString
                newRow.Item("Budget") = Configuration.FormatToString(mybudget.Budget, DigitConfig.Price)
                newRow.Tag = mybudget
            Next
            dt.AcceptChanges()
        End Sub
        Public Function Save(ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException Implements IExtender.Save
            Try
                If m_acc Is Nothing OrElse Not m_acc.Originated Then
                    Return New SaveErrorException("0")
                End If

                Dim da As New SqlDataAdapter("Select * from ACCBudget where accb_acctid=" & m_acc.Id, conn)

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
                da.FillSchema(ds, SchemaType.Mapped, "ACCBudget")
                da.Fill(ds, "ACCBudget")

                Dim dt As DataTable = ds.Tables("ACCBudget")
                For Each row As DataRow In ds.Tables("ACCBudget").Rows
                    row.Delete()
                Next

                For Each item As ACCBudget In Me
                    Dim dr As DataRow = dt.NewRow

                    dr("accb_acctid") = m_acc.Id
                    dr("accb_name") = item.Name
                    dr("accb_startdate") = item.StartDate
                    dr("accb_enddate") = item.EndDate
                    dr("accb_budget") = item.Budget
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
            'If m_acc Is Nothing OrElse Not m_acc.Originated Then
            '    Return New SaveErrorException("0")
            'End If
            'Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
            'returnVal.ParameterName = "RETURN_VALUE"
            'returnVal.DbType = DbType.Int32
            'returnVal.Direction = ParameterDirection.ReturnValue
            'returnVal.SourceVersion = DataRowVersion.Current
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, _
            '                        "DeleteACCBudgetList", _
            '                        New SqlParameter() { _
            '                        New SqlParameter("@acct_id", m_acc.Id) _
            '                        , returnVal})

            'Return New SaveErrorException(returnVal.Value.ToString)
        End Function
        Public Shared Function GetBudgetList(ByVal txtCode As TextBox, ByRef cc As Account) As Integer

            Dim budgetCollection As New ACCBudgetCollection(cc)
            For Each bgColl As ACCBudget In budgetCollection
                If bgColl.Name = txtCode.Text Then
                    Return bgColl.Id
                End If
            Next

            MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
            txtCode.Text = ""
            Return Nothing
        End Function
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As ACCBudget) As Integer
            If Not MyBase.List.Contains(value) Then
                Return MyBase.List.Add(value)
            End If
        End Function
        'Public Sub AddRange(ByVal value As ACCBudgetBudgetCollection)
        '    For i As Integer = 0 To value.Count - 1
        '        Me.Add(value(i))
        '    Next
        'End Sub
        Public Sub AddRange(ByVal value As ACCBudget())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        'Public Function Contains(ByVal value As ACCBudgetbudget) As Boolean
        '    Return MyBase.List.Contains(value)
        'End Function
        'Public Sub CopyTo(ByVal array As ACCBudgetbudget(), ByVal index As Integer)
        '    MyBase.List.CopyTo(array, index)
        'End Sub
        'Public Shadows Function GetEnumerator() As ACCBudgetBudgetEnumerator
        '    Return New ACCBudgetBudgetEnumerator(Me)
        'End Function
        'Public Function IndexOf(ByVal value As ACCBudgetbudget) As Integer
        '    Return MyBase.List.IndexOf(value)
        'End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As ACCBudget)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As ACCBudget)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As ACCBudgetCollection)
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