Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components

Namespace Longkong.Pojjaman.BusinessLogic

    Public Class FinancialStatementFormat
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
        Private m_name As String
        Private m_note As String

        Private m_autorunlinenumber As Integer

        'Private m_linktype As FinancialStatementType
        Private m_status As FinancialStatementStatus

        Private m_isDefault As Boolean
      
        'Private m_itemCollection As BoqItemCollection
        Private m_FinancialStatementItemCollection As FinancialStatementItemCollection

        Private m_itemTable As TreeTable
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        'Public Sub New(ByVal linktype As FinancialStatementType)
        '    MyBase.New()
        '    Me.LinkType = linktype
        '    Select Case linktype.Value
        '        Case 1
        '            Dim rootItem As New FinancialStatementItem
        '            rootItem.Name = linktype.Description
        '            rootItem.Parent = rootItem
        '            rootItem.Level = 0
        '            Me.m_FinancialStatementItemCollection.Add(rootItem)
        '            Dim dt As DataTable = CodeDescription.GetCodeList("financialstatement_list", "code_value <> 0")
        '            For Each row As DataRow In dt.Rows
        '                Dim item As New FinancialStatementItem
        '                item.Name = row("code_description").ToString
        '                item.ItemType = CInt(row("code_value"))
        '                item.Parent = rootItem
        '                item.Level = 1
        '                Me.m_FinancialStatementItemCollection.Add(item)
        '            Next
        '        Case 2
        '            Dim rootItem As New FinancialStatementItem
        '            rootItem.Name = linktype.Description
        '            rootItem.Parent = rootItem
        '            Me.m_FinancialStatementItemCollection.Add(rootItem)
        '            Dim dt As DataTable = CodeDescription.GetCodeList("profitlost_list", "code_value <> 0")
        '            For Each row As DataRow In dt.Rows
        '                Dim item As New FinancialStatementItem
        '                item.Name = row("code_description").ToString
        '                item.ItemType = CInt(row("code_value"))
        '                item.Parent = rootItem
        '                item.Level = 1
        '                Me.m_FinancialStatementItemCollection.Add(item)
        '            Next
        '    End Select
        'End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                '.m_linktype = New FinancialStatementType(-1)
                .m_FinancialStatementItemCollection = New FinancialStatementItemCollection
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_linktype") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_linktype") Then
                    '.m_linktype = New FinancialStatementType(CInt(dr(aliasPrefix & Me.Prefix & "_linktype")))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isdefault") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isdefault") Then
                    .m_isDefault = CBool(dr(aliasPrefix & Me.Prefix & "_isdefault"))
                End If
                .m_FinancialStatementItemCollection = New FinancialStatementItemCollection(Me)
            End With

        End Sub
#End Region

#Region "Properties"
        Public Property ItemTable() As TreeTable            Get                Return m_itemTable            End Get            Set(ByVal Value As TreeTable)                m_itemTable = Value            End Set        End Property

        Public Property FinancialStatementItemCollection() As FinancialStatementItemCollection            Get                Return m_FinancialStatementItemCollection            End Get            Set(ByVal Value As FinancialStatementItemCollection)                m_FinancialStatementItemCollection = Value            End Set        End Property

        'Public Property LinkType() As FinancialStatementType        '    Get        '        Return m_linktype        '    End Get        '    Set(ByVal Value As FinancialStatementType)        '        m_linktype = Value        '    End Set        'End Property
        Public Property IsDefault() As Boolean            Get                Return m_isDefault            End Get            Set(ByVal Value As Boolean)                m_isDefault = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "FinancialStatementFormat"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.FinancialStatementFormat.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.FinancialStatementFormat"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.FinancialStatementFormat"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.FinancialStatementFormat.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "financef"
            End Get
        End Property
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Name & ")"
                If tpt.EndsWith("()") Then
                    tpt = tpt.TrimEnd("()".ToCharArray)
                End If
                Return tpt
            End Get
        End Property
#End Region

#Region "Shared"
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("financialstatementformat")

            myDatatable.Columns.Add(New DataColumn("linenumber", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("rownum", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("item", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("BSType", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("formular", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("button", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("note", GetType(String)))
            Return myDatatable
        End Function
#End Region

#Region "Methods"
        Public Overrides Function ToString() As String
            Return m_name
        End Function
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("Error No id")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try
                Dim cmd As New SqlCommand("delete glformatitem where glfi_glf=" & Me.Id)
                cmd.Connection = conn
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()
                cmd.CommandText = "delete FinancialStatementFormat where financef_id=" & Me.Id
                cmd.ExecuteNonQuery()
                trans.Commit()
                Return New SaveErrorException("1")
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Finally
                conn.Close()
            End Try
        End Function
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me

                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current

                ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
                Dim paramArrayList As New ArrayList

                paramArrayList.Add(returnVal)
                If Me.Originated Then
                    paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                'If Me.m_je.Status.Value = 4 Then
                '    Me.Status.Value = 4
                'End If
                If Me.Status.Value = -1 Then
                    Me.Status = New FinancialStatementStatus(2)
                End If

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False

                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_linenumber", DBNull.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isdefault", IIf(Me.IsDefault, 1, 0)))
                'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_linktype", Me.LinkType.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(Me.ConnectionString)
                conn.Open()
                trans = conn.BeginTransaction()
                Try
                    Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                    If IsNumeric(returnVal.Value) Then
                        Select Case CInt(returnVal.Value)
                            Case -1, -2, -5
                                trans.Rollback()
                                Return New SaveErrorException(returnVal.Value.ToString)
                            Case Else
                        End Select
                    ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                        trans.Rollback()
                        Return New SaveErrorException(returnVal.Value.ToString)
                    End If

                    ' Save item
                    SaveDetail(Me.Id, conn, trans)

                    trans.Commit()
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Return New SaveErrorException(ex.ToString)
                Finally
                    conn.Close()
                End Try
            End With
        End Function
        Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
            Try
                '----------------HACK------------------------------------
                Try
                    Dim cmd As New SqlCommand("delete FinancialStatementFormatwbs where fswbs_financef=" & Me.Id, conn)
                    cmd.Transaction = trans
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Throw New Exception("WBS Deletion Error")
                End Try
                '----------------HACK------------------------------------

                Dim ds As New DataSet

                '***********----WBS ----****************
                Dim da As New SqlDataAdapter("Select * from FinancialStatementFormatwbs where 1=2", conn)
                Dim cb As New SqlCommandBuilder(da)
                da.SelectCommand.Transaction = trans

                da.DeleteCommand = cb.GetDeleteCommand
                da.DeleteCommand.Transaction = trans

                da.InsertCommand = cb.GetInsertCommand
                da.InsertCommand.Transaction = trans

                da.UpdateCommand = cb.GetUpdateCommand
                da.UpdateCommand.Transaction = trans

                da.InsertCommand.CommandText &= ";" & _
                "update FinancialStatementFormatwbs set fswbs_parid = fswbs_id where fswbs_parid is null and fswbs_id=@@IDENTITY;" & _
                "update FinancialStatementFormatwbs set fswbs_path ='|'+convert(nvarchar,fswbs_id)+'|' where fswbs_id = @@IDENTITY and fswbs_parid= @@IDENTITY;" & _
                "update FinancialStatementFormatwbs set FinancialStatementFormatwbs.fswbs_path = (select parent.fswbs_path from FinancialStatementFormatwbs parent where parent.fswbs_id=FinancialStatementFormatwbs.fswbs_parid) + '|'+convert(nvarchar,FinancialStatementFormatwbs.fswbs_id)+'|' where FinancialStatementFormatwbs.fswbs_id = @@IDENTITY and FinancialStatementFormatwbs.fswbs_parid <> @@IDENTITY ;" & _
                " Select * From FinancialStatementFormatwbs Where fswbs_id= @@IDENTITY"
                da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
                cb = Nothing

                da.FillSchema(ds, SchemaType.Mapped, "financialstatementformatwbs")
                da.Fill(ds, "financialstatementformatwbs")
                'ds.Relations.Add("financialfiTree", ds.Tables!FinancialStatementFormat.Columns!financef_id, ds.Tables!FinancialStatementFormatwbs.Columns!fswbs_parid)
                ds.Relations.Add("financialfiTree", ds.Tables!FinancialStatementFormatwbs.Columns!fswbs_id, ds.Tables!FinancialStatementFormatwbs.Columns!fswbs_parid)
                '***********----WBS ----****************


                Dim dtFinancialfi As DataTable
                Dim dc As DataColumn
                dtFinancialfi = ds.Tables("financialstatementformatwbs")
                dc = dtFinancialfi.Columns!fswbs_id
                dc.AutoIncrement = True
                dc.AutoIncrementSeed = -1
                dc.AutoIncrementStep = -1

                Dim tmpDa As New SqlDataAdapter
                tmpDa.DeleteCommand = da.DeleteCommand
                tmpDa.InsertCommand = da.InsertCommand
                tmpDa.UpdateCommand = da.UpdateCommand

                AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated

                For Each dr As DataRow In dtFinancialfi.Rows
                    dr.Delete()
                Next
                Me.m_autorunlinenumber = 1
                Dim rootFi As FinancialStatementItem = Me.FinancialStatementItemCollection.GetRoot
                If Not rootFi Is Nothing Then

                    Dim drFi As DataRow = dtFinancialfi.NewRow
                    'drFi(rootWbs.Prefix & "_id") = ""
                    drFi(rootFi.Prefix & "_linenumber") = Me.m_autorunlinenumber
                    drFi(rootFi.Prefix & "_financef") = Me.Id
                    drFi(rootFi.Prefix & "_code") = "R" & Me.m_autorunlinenumber.ToString
                    drFi(rootFi.Prefix & "_name") = rootFi.Name
                    drFi(rootFi.Prefix & "_altName") = rootFi.AlternateName
                    drFi(rootFi.Prefix & "_level") = 0
                    drFi(rootFi.Prefix & "_parid") = DBNull.Value
                    drFi(rootFi.Prefix & "_path") = ""
                    drFi(rootFi.Prefix & "_note") = rootFi.Note
                    drFi(rootFi.Prefix & "_control") = DBNull.Value
                    'drFi("fswbs_entity") = rootFi.Name
                    drFi(rootFi.Prefix & "_entitytype") = rootFi.ItemType
                    drFi(rootFi.Prefix & "_formular") = rootFi.Formular

                    dtFinancialfi.Rows.Add(drFi)
                    Dim oldParId As Integer = rootFi.Id
                    rootFi.Id = CInt(drFi(rootFi.Prefix & "_id"))
                    Me.FinancialStatementItemCollection.UpdateParentId(oldParId, rootFi.Id)
                    Dim collForRoot As FinancialStatementItemCollection = Me.FinancialStatementItemCollection.GetChildsOf(rootFi)


                    LoopFi(collForRoot, 1, dtFinancialfi)
                End If

                tmpDa.Update(GetDeletedRows(dtFinancialfi))
                tmpDa.Update(dtFinancialfi.Select("", "", DataViewRowState.ModifiedCurrent))

                ds.EnforceConstraints = False

                tmpDa.Update(dtFinancialfi.Select("", "", DataViewRowState.Added))

                ds.EnforceConstraints = True

                Return New SaveErrorException("0")
            Catch ex As Exception
                Return New SaveErrorException(ex.ToString)
            End Try
        End Function
        Private Sub LoopFi(ByVal coll As FinancialStatementItemCollection, ByVal level As Integer, ByVal dtFinancialfi As DataTable)
            Try
                Me.m_autorunlinenumber += 1
                Dim line As Integer = 1
                For Each myFi As FinancialStatementItem In coll
                    'MessageBox.Show(myFi.Name)
                    Dim drFi As DataRow = dtFinancialfi.NewRow
                    'drFi(rootWbs.Prefix & "_id") = ""
                    drFi(myFi.Prefix & "_financef") = Me.Id
                    drFi(myFi.Prefix & "_linenumber") = Me.m_autorunlinenumber 'line

                    drFi(myFi.Prefix & "_code") = "R" & Me.m_autorunlinenumber.ToString
                    drFi(myFi.Prefix & "_name") = myFi.Name
                    drFi(myFi.Prefix & "_altName") = myFi.AlternateName

                    drFi(myFi.Prefix & "_parid") = myFi.Parent.Id
                    drFi(myFi.Prefix & "_level") = level
                    drFi(myFi.Prefix & "_path") = ""

                    drFi(myFi.Prefix & "_control") = DBNull.Value

                    'drFi(myFi.Prefix & "_entity") = ""
                    drFi(myFi.Prefix & "_entitytype") = myFi.ItemType
                    drFi(myFi.Prefix & "_formular") = myFi.Formular
                    drFi(myFi.Prefix & "_note") = myFi.Note

                    dtFinancialfi.Rows.Add(drFi)
                    Dim oldParId As Integer = myFi.Id
                    myFi.Id = CInt(drFi(myFi.Prefix & "_id"))
                    Me.FinancialStatementItemCollection.UpdateParentId(oldParId, myFi.Id)
                    line += 1
                    LoopFi(Me.FinancialStatementItemCollection.GetChildsOf(myFi), level + 1, dtFinancialfi)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
            ' When the primary key propagates down to the child row's foreign key field, the field
            ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
            ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
            ' on the client tier, instead of being merged with the original row that was added.
            If e.StatementType = StatementType.Insert Then
                e.Status = UpdateStatus.SkipCurrentRow
                Dim currentInternalKey As Object = e.Row("fswbs_parid")
                If Not e.Row.GetParentRow("financialfiTree") Is Nothing AndAlso e.Row.GetParentRow("financialfiTree").HasVersion(DataRowVersion.Original) Then
                    e.Row!fswbs_parid = e.Row.GetParentRow("financialfiTree")("fswbs_id", DataRowVersion.Original)
                End If
                'If e.Row.IsNull("fswbs_parid") Then
                '    e.Row!fswbs_parid = e.Row!fswbs_id
                'End If
                e.Row.AcceptChanges()
                e.Row!fswbs_parid = currentInternalKey
            End If
            If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
        End Sub
        Private Function GetDeletedRows(ByVal dt As DataTable) As DataRow()
            Dim Rows() As DataRow
            If dt Is Nothing Then Return Rows
            Rows = dt.Select("", "", DataViewRowState.Deleted)
            If Rows.Length = 0 OrElse Not (Rows(0) Is Nothing) Then Return Rows
            '
            ' Workaround:
            ' With a remoted DataSet, Select returns the array elements
            ' filled with Nothing/null, instead of DataRow objects.
            '
            Dim r As DataRow, I As Integer = 0
            For Each r In dt.Rows
                If r.RowState = DataRowState.Deleted Then
                    Rows(I) = r
                    I += 1
                End If
            Next
            Return Rows
        End Function
#End Region

#Region "IHasName"
        Public Property Name() As String Implements IHasName.Name
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
                OnTabPageTextChanged(Me, New EventArgs)
            End Set
        End Property
#End Region

        '#Region "TreeTable Handlers"
        '        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        '            If Not Me.IsInitialized Then
        '                Return
        '            End If
        '            'Hack: hard-coded
        '            If IsDBNull(e.Row("glfi_fieldtype")) OrElse CInt(e.Row("glfi_fieldtype")) = 2 OrElse CInt(e.Row("glfi_fieldtype")) = 3 Then
        '                Return
        '            End If
        '            Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
        '            If ValidateRow(CType(e.Row, TreeRow)) Then
        '                Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
        '                Me.OnPropertyChanged(Me, pe)
        '                Me.m_itemTable.AcceptChanges()
        '            End If
        '        End Sub
        '        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        '            If Not Me.IsInitialized Then
        '                Return
        '            End If
        '            Try
        '                Select Case e.Column.ColumnName.ToLower
        '                    Case "acctcode"
        '                        'Hack: hard-coded
        '                        If IsDBNull(e.Row("glfi_fieldtype")) OrElse CInt(e.Row("glfi_fieldtype")) = 2 OrElse CInt(e.Row("glfi_fieldtype")) = 3 Then
        '                            e.ProposedValue = e.Row("acctcode")
        '                            Return
        '                        End If
        '                        SetAccountValue(e)
        '                End Select
        '                ValidateRow(e)
        '            Catch ex As Exception
        '                MessageBox.Show(ex.ToString)
        '            End Try
        '        End Sub
        '        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
        '            Dim proposedAccount As Object = e.Row("AcctCode")
        '            Select Case e.Column.ColumnName.ToLower
        '                Case "acctcode"
        '                    proposedAccount = e.ProposedValue
        '                Case Else
        '                    Return
        '            End Select

        '            If IsDBNull(proposedAccount) Then
        '                e.Row.SetColumnError("AcctCode", Me.StringParserService.Parse("${res:Global.Error.AccountMissing}"))
        '            Else
        '                e.Row.SetColumnError("AcctCode", "")
        '            End If
        '        End Sub
        '        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
        '            Return True
        '        End Function
        '        Public Sub SetAccountValue(ByVal e As System.Data.DataColumnChangeEventArgs)
        '            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        '                Dim item As New FinancialStatementFormatItem
        '                item.CopyFromDataRow(CType(e.Row, TreeRow))
        '                If Not item.Field Is Nothing And TypeOf item.Field Is GeneralAccount Then
        '                    Dim acct As Account = CType(item.Field, GeneralAccount).Account
        '                    If Not acct Is Nothing AndAlso acct.Originated Then
        '                        e.Row("glfi_acct") = 0
        '                        e.ProposedValue = acct.Code
        '                        e.Row("AcctName") = acct.Name & " <" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
        '                    Else
        '                        e.Row("glfi_acct") = DBNull.Value
        '                        e.ProposedValue = DBNull.Value
        '                        e.Row("AcctName") = DBNull.Value
        '                    End If
        '                Else
        '                    e.Row("glfi_acct") = DBNull.Value
        '                    e.ProposedValue = DBNull.Value
        '                    e.Row("AcctName") = DBNull.Value
        '                End If
        '                Return
        '            End If
        '            Dim entity As New Account(e.ProposedValue.ToString)
        '            If entity.Originated Then
        '                e.Row("glfi_acct") = entity.Id
        '                e.ProposedValue = entity.Code
        '                e.Row("AcctName") = entity.Name
        '            Else
        '                e.Row("glfi_acct") = DBNull.Value
        '                e.ProposedValue = DBNull.Value
        '                e.Row("AcctName") = DBNull.Value
        '            End If
        '        End Sub
        '        Private Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
        '            Try
        '                If Not Me.IsInitialized Then
        '                    Return
        '                End If
        '                Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
        '                Me.OnPropertyChanged(Me, pe)
        '                e.Row.SetColumnError("Name", "")
        '            Catch ex As Exception
        '                MessageBox.Show(ex.ToString)
        '            End Try
        '        End Sub
        '        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        '            'Dim row As DataRow = e.Row
        '            'Me.m_itemTable.Childs.Remove(CType(row, TreeRow))
        '            'Try
        '            '    If Not Me.Isinitialized Then
        '            '        Return
        '            '    End If

        '            '    Dim index As TreeRow = CType(e.Row, TreeRow)
        '            '    Me.m_itemTable.Childs.Remove(index)
        '            'Catch ex As Exception
        '            '    MessageBox.Show(ex.ToString)
        '            'End Try
        '        End Sub
        '#End Region

#Region "Shared"
        Private Shared Function GetLinkFinancialStatementDataset() As DataSet
            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
                                                        , CommandType.StoredProcedure _
                                                        , "GetFinancialStatementFormatList")
            Return ds
        End Function
        Private Shared Function GetLinkFinancialStatementDataset(ByVal filters() As Filter) As DataSet
            Dim params() As SqlParameter
            If Not filters Is Nothing AndAlso filters.Length > 0 Then
                ReDim params(filters.Length - 1)
                For i As Integer = 0 To filters.Length - 1
                    params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
                Next
            End If

            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
                                                        , CommandType.StoredProcedure _
                                                        , "GetFinancialStatementFormatList", params)
            Return ds
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ds"></param>
        ''' <param name="tvGroup"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Neng]	9/1/2549	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Shared Sub Populate(ByVal ds As DataSet, ByVal tvGroup As TreeView)
            Dim glFormatTable As DataTable = ds.Tables(0)
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode

            Dim dt As DataTable = CodeDescription.GetCodeList("financialstatement_type")
            For Each dr As DataRow In dt.Rows
                If Not dr.IsNull("code_description") Then
                    currentGroupNode = tvGroup.Nodes.Add(CStr(dr("code_description")))
                    currentGroupNode.Tag = New IdValuePair(CInt(dr("code_value")), "type")
                    For Each row As DataRow In glFormatTable.Rows
                        If Not row.IsNull("financef_linktype") Then
                            If CInt(row("financef_linktype")) = CType(currentGroupNode.Tag, IdValuePair).Id Then
                                currentNode = currentGroupNode.Nodes.Add(row("financef_code").ToString & " - " & row("financef_name").ToString)
                                currentNode.Tag = New IdValuePair(CInt(row("financef_id")), "format")
                            End If
                        End If
                    Next
                End If
            Next

        End Sub
        Public Shared Sub Populate(ByVal tvGroup As TreeView, ByVal filters() As Filter)
            Dim ds As DataSet = GetLinkFinancialStatementDataset(filters)
            Populate(ds, tvGroup)
        End Sub
        Public Shared Sub Populate(ByVal tvGroup As TreeView)
            Dim ds As DataSet = GetLinkFinancialStatementDataset()
            Populate(ds, tvGroup)
        End Sub

#End Region

#Region " TreeRow Methods "
        Public Sub PopulateItemListing(ByVal dt As TreeTable)
            dt.Clear()
            Dim i As Integer
            For Each myWbs As FinancialStatementItem In Me.FinancialStatementItemCollection
                i += 1
                Dim parentNodes As TreeRow.TreeRowCollection = Nothing
                If myWbs.Parent Is myWbs Then
                    parentNodes = dt.Childs
                ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
                    parentNodes = dt.Childs
                Else
                    Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, FinancialStatementItem))
                    If Not parentNode Is Nothing Then
                        parentNodes = parentNode.Childs
                    End If
                End If
                If Not parentNodes Is Nothing Then
                    Dim tr As TreeRow = parentNodes.Add
                    'tr("linenumber") = i
                    'tr("rownum") = "R" & i.ToString
                    tr("item") = myWbs.Name
                    tr("bstype") = myWbs.ItemType
                    If myWbs.Level = 0 Then
                        tr("bstype") = DBNull.Value
                        myWbs.ItemType = 0
                    End If
                    
                    tr("formular") = myWbs.Formular ' myWbs.Parent.Id & ":" & myWbs.Parent.Name  'myWbs.Formular
                    tr("note") = myWbs.Note
                    tr.Tag = myWbs
                    tr.State = RowExpandState.Expanded
                End If
            Next
            ReNumber(dt)
            dt.AcceptChanges()
            
        End Sub
        Private Sub ReNumber(ByVal dt As TreeTable)
            Dim i As Integer
            For Each tr As TreeRow In dt.Rows
                i += 1
                tr("linenumber") = i
                tr("rownum") = "R" & i.ToString

                If tr.IsLeafRow Then
                    tr("Button") = ""
                Else
                    tr("Button") = "invisible"
                End If
                'If Not tr.IsNull("bstype") AndAlso CInt(tr("bstype")) = 0 Then
                '    tr("Button") = "invisible"
                'End If
            Next
        End Sub
        Public Function FindRow(ByVal dt As TreeTable, ByVal myWbs As FinancialStatementItem) As TreeRow
            Dim n As TreeRow
            For Each n In dt.Childs
                Dim tr As TreeRow = FindRow(n, myWbs)
                If Not tr Is Nothing Then
                    Return tr
                End If
            Next
        End Function
        Private Function FindRow(ByVal n As TreeRow, ByVal myWbs As FinancialStatementItem) As TreeRow
            If TypeOf n.Tag Is FinancialStatementItem Then
                Dim nodeWbs As FinancialStatementItem = CType(n.Tag, FinancialStatementItem)
                If nodeWbs Is myWbs Then
                    Return n
                End If
                If nodeWbs.Id <> 0 And nodeWbs.Id = myWbs.Id Then
                    Return n
                End If
            End If
            Dim aNode As TreeRow
            For Each aNode In n.Childs
                Dim tr As TreeRow = FindRow(aNode, myWbs)
                If Not tr Is Nothing Then
                    Return tr
                End If
            Next
        End Function
#End Region

#Region "Shared"
        Public Shared Function GetFinancialStatementFormat(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldFsFormat As FinancialStatementFormat) As Boolean
            Dim newFsFormat As New FinancialStatementFormat(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not newFsFormat.Valid Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                newFsFormat = oldFsFormat
            End If
            txtCode.Text = newFsFormat.Code
            txtName.Text = newFsFormat.Name
            If oldFsFormat.Id <> newFsFormat.Id Then
                oldFsFormat = newFsFormat
                Return True
            End If
            Return False
        End Function
#End Region

    End Class

End Namespace
