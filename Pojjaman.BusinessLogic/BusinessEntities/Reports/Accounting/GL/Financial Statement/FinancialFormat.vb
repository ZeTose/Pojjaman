Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class FinancialFormat
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
        Private m_name As String
        Private m_note As String
        Private m_isDefault As Boolean
        Private m_linkfinancialtype As LinkFinancialType
        Private m_linkfinancial As LinkFinancial

        Private m_itemTable As TreeTable
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            ReLoadItems()
            Wire()
        End Sub
        Public Sub New(ByVal linktype As LinkFinancialType)
            MyBase.New()
            Me.LinkFinancial = New LinkFinancial
            m_linkfinancialtype = linktype
            ReLoadItems()
            Wire()
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
            ReLoadItems()
            Wire()
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
            ReLoadItems()
            Wire()
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
            ReLoadItems()
            Wire()
        End Sub
        Public Sub UnWire()
            If Not m_itemTable Is Nothing Then
                RemoveHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
                RemoveHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
                RemoveHandler m_itemTable.RowDeleted, AddressOf ItemDelete
            End If
        End Sub
        Public Sub Wire()
            'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
            If Not m_itemTable Is Nothing Then
                AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
                AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
                AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
            End If
        End Sub
        Protected Overloads Overrides Sub Construct()
            With Me
                .m_linkfinancial = New LinkFinancial
                .m_linkfinancialtype = New LinkFinancialType(1)
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' Name
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
                ' Is Defualt 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isdefault") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isdefault") Then
                    .m_isDefault = CBool(dr(aliasPrefix & Me.Prefix & "_isdefault"))
                End If
                ' Report Type
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_reporttype") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_reporttype") Then
                    .m_linkfinancialtype = New LinkFinancialType(CInt(dr(aliasPrefix & Me.Prefix & "_reporttype")))
                End If
                ' Note
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property ItemTable() As TreeTable            Get                Return m_itemTable            End Get            Set(ByVal Value As TreeTable)                m_itemTable = Value            End Set        End Property
        Public Property LinkFinancial() As LinkFinancial            Get                Return m_linkfinancial            End Get            Set(ByVal Value As LinkFinancial)                m_linkfinancial = Value            End Set        End Property
        Public Property IsDefault() As Boolean            Get                Return m_isDefault            End Get            Set(ByVal Value As Boolean)                m_isDefault = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public Property ReportType() As LinkFinancialType            Get                Return m_linkfinancialtype            End Get            Set(ByVal Value As LinkFinancialType)                m_linkfinancialtype = Value            End Set        End Property

        ' Overrides Properties.
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "financialformat"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.FinancialFormat.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.FinancialFormat"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.FinancialFormat"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.FinancialFormat.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "link"
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
            Dim myDatatable As New TreeTable("LinkFinancialItem")

            myDatatable.Columns.Add(New DataColumn("linki_link", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("linki_linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("linki_idention", GetType(Integer)))

            myDatatable.Columns.Add(New DataColumn("linki_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("linki_name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("linki_namestyle", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("btn_namestyle", GetType(String)))

            myDatatable.Columns.Add(New DataColumn("linki_note", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("linki_notestyle", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("btn_notestyle", GetType(String)))

            myDatatable.Columns.Add(New DataColumn("linki_formular", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("linki_formularstyle", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("btn_formularstyle", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("btn_account", GetType(String)))

            myDatatable.Columns.Add(New DataColumn("linki_isnewpage", GetType(Boolean)))
            myDatatable.Columns.Add(New DataColumn("linki_linestyle", GetType(Integer)))

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
                Dim cmd As New SqlCommand("delete linkfinancialitem where linki_link = " & Me.Id)
                cmd.Connection = conn
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()
                cmd.CommandText = "delete linkfinancial where link_id = " & Me.Id
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
        Private Sub ResetID(ByVal oldid As Integer)
            Me.Id = oldid
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                If Me.MaxRowIndex < 0 Then '.ItemTable.Childs.Count = 0 Then
                    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
                End If
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

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_reporttype", Me.ReportType.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isdefault", Me.IsDefault))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))

                ' SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(Me.ConnectionString)
                conn.Open()
                trans = conn.BeginTransaction()

                Dim oldid As Integer = Me.Id

                Try
                    Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

                    ChangeOldItemStatus(conn, trans)
                    SaveDetail(Me.Id, conn, trans)
                    ChangeNewItemStatus(conn, trans)

                    If IsNumeric(returnVal.Value) Then
                        Select Case CInt(returnVal.Value)
                            Case -1, -2, -5
                                trans.Rollback()
                                Me.ResetID(oldid)
                                Return New SaveErrorException(returnVal.Value.ToString)
                            Case Else
                        End Select
                    ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                        trans.Rollback()
                        Me.ResetID(oldid)
                        Return New SaveErrorException(returnVal.Value.ToString)
                    End If
                    trans.Commit()
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Me.ResetID(oldid)
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Me.ResetID(oldid)
                    Return New SaveErrorException(ex.ToString)
                Finally
                    conn.Close()
                End Try
            End With
        End Function
        Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
            If Not Me.Originated Then
                Return
            End If
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldPRItemStatus", New SqlParameter("@po_id", Me.Id))
        End Sub
        Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
            If Not Me.Originated Then
                Return
            End If
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewPRItemStatus", New SqlParameter("@po_id", Me.Id))
        End Sub
        Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

            Dim da As New SqlDataAdapter("Select * from linkfinancialitem where linki_link = " & Me.Id, conn)
            Dim cmdBuilder As New SqlCommandBuilder(da)

            Dim ds As New DataSet

            da.SelectCommand.Transaction = trans

            'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans

            da.Fill(ds, "linkfinancialitem")

            Dim dbCount As Integer = ds.Tables("linkfinancialitem").Rows.Count
            Dim itemCount As Integer = Me.ItemTable.Childs.Count
            Dim i As Integer = 0
            With ds.Tables("linkfinancialitem")
                For Each row As DataRow In .Rows
                    row.Delete()
                Next
                For Each dr As DataRow In Me.m_itemTable.Childs
                    If ValidateRow(CType(dr, TreeRow)) Then
                        Dim item As New LinkFinancialItem
                        item.CopyFromDataRow(dr)
                        i += 1
                        Dim newdr As DataRow = .NewRow
                        If item.BaseEntity Is Nothing Then
                            newdr("linki_link") = DBNull.Value
                        Else
                            newdr("linki_link") = Me.Id
                        End If
                        newdr("linki_linenumber") = i
                        newdr("linki_idention") = item.Indention
                        newdr("linki_code") = item.Code
                        newdr("linki_name") = item.Name
                        newdr("linki_namestyle") = item.NameStyle
                        newdr("linki_note") = item.Note
                        newdr("linki_notestyle") = item.NoteStyle
                        newdr("linki_formular") = item.Formular
                        newdr("linki_formularstyle") = item.FormularStyle
                        newdr("linki_isnewpage") = item.IsNewPage
                        newdr("linki_linestyle") = item.LineStyle

                        .Rows.Add(newdr)
                    End If
                Next
            End With
            Dim dt As DataTable = ds.Tables("linkfinancialitem")
            ' First process deletes.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
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

#Region "Items"
        Public Overloads Sub ReLoadItems()
            Me.IsInitialized = False
            m_itemTable = GetSchemaTable()
            LoadItems()
            Me.IsInitialized = True
        End Sub
        Private Sub LoadItems()
            If Me.Valid Then
                Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetLinkFinancialItems" _
                , New SqlParameter("@linki_link", Me.Id) _
                )
                For Each row As DataRow In ds.Tables(0).Rows
                    Dim item As New FinancialFormatItem(row, "")
                    Me.Add(item)
                Next
            End If
        End Sub
        Public Sub AddBlankRow(ByVal count As Integer)
            For i As Integer = 0 To count - 1
                Dim myItem As New FinancialFormatItem
                Me.ItemTable.AcceptChanges()
                Me.Add(myItem)
                ReIndex(i)
            Next
        End Sub
        Public Function Add(ByVal item As FinancialFormatItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.Add
            item.LineNumber = Me.ItemTable.Childs.Count
            item.FinancialFormat = Me
            item.CopyToDataRow(myRow)
            ReindexCode()
            Return myRow
        End Function
        Private Sub ReIndex()
            ReIndex(0)
        End Sub
        Private Sub ReIndex(ByVal index As Integer)
            If index < 0 OrElse index > Me.ItemTable.Rows.Count - 1 Then
                Return
            End If
            For i As Integer = index To Me.ItemTable.Childs.Count - 1
                Me.ItemTable.Childs(i)("linki_linenumber") = i + 1
            Next

        End Sub
        Private Sub ReindexCode()
            For i As Integer = 0 To Me.MaxRowIndex
                Me.ItemTable.Childs(i)("linki_code") = "R" & (i + 1).ToString
            Next
        End Sub

        Public Function MaxRowIndex() As Integer
            If Me.m_itemTable Is Nothing Then
                Return -1
            End If
            'ให้ค่า index ของแถวสุดท้ายที่มีข้อมูล
            For i As Integer = Me.m_itemTable.Rows.Count - 1 To 0 Step -1
                Dim row As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
                If ValidateRow(row) Then
                    Return i
                End If
            Next
            Return -1 'ไม่มีข้อมูลเลย
        End Function
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If
            'Hack: hard-coded
            'If IsDBNull(e.Row("glfi_fieldtype")) OrElse CInt(e.Row("glfi_fieldtype")) = 2 OrElse CInt(e.Row("glfi_fieldtype")) = 3 Then
            '    Return
            'End If
            Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
                Me.OnPropertyChanged(Me, pe)
                Me.m_itemTable.AcceptChanges()
                Select Case e.Column.ColumnName.ToLower
                    Case "linki_name"
                        ReindexCode()
                    Case Else

                End Select
            End If
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "linki_name"

                    Case "linki_reporttype"

                    Case "linki_idention"

                    Case "acctcode"
                        'Hack: hard-coded
                        If IsDBNull(e.Row("glfi_fieldtype")) OrElse CInt(e.Row("glfi_fieldtype")) = 2 OrElse CInt(e.Row("glfi_fieldtype")) = 3 Then
                            e.ProposedValue = e.Row("acctcode")
                            Return
                        End If
                        SetAccountValue(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            'Dim proposedCode As Object = e.Row("linki_code")
            Dim proposedName As Object = e.Row("linki_name")

            Select Case e.Column.ColumnName.ToLower
                Case "linki_code"
                    'proposedCode = e.ProposedValue
                Case "linki_name"
                    proposedName = e.ProposedValue
                Case Else
                    Return
            End Select

            'If IsDBNull(proposedCode) OrElse CStr(proposedCode).Length = 0 Then
            '    e.Row.SetColumnError("linki_code", Me.StringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            'Else
            '    e.Row.SetColumnError("linki_code", "")
            'End If

            If IsDBNull(proposedName) OrElse CStr(proposedName).Length = 0 Then
                e.Row.SetColumnError("linki_name", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
                e.Row.SetColumnError("linki_name", "")
            End If
        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Dim proposedName As Object = row("linki_name")
            'Dim proposedCode As Object = row("linki_code")

            Dim flag As Boolean = True
            If (IsDBNull(proposedName) OrElse CStr(proposedName).Length = 0) Then
                flag = False
            End If

            Return flag
        End Function
        Public Sub SetLinkName(ByVal e As System.Data.DataColumnChangeEventArgs)

        End Sub
        Public Sub SetAccountValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                Dim item As New GLFormatItem
                'item.CopyFromDataRow(CType(e.Row, TreeRow))
                If Not item.Field Is Nothing And TypeOf item.Field Is GeneralAccount Then
                    Dim acct As Account = CType(item.Field, GeneralAccount).Account
                    acct = New Account(acct.Code)
                    If Not acct Is Nothing AndAlso acct.Originated Then
                        e.Row("glfi_acct") = 0
                        e.ProposedValue = acct.Code
                        e.Row("AcctName") = acct.Name & " <" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                    Else
                        e.Row("glfi_acct") = DBNull.Value
                        e.ProposedValue = DBNull.Value
                        e.Row("AcctName") = DBNull.Value
                    End If
                Else
                    e.Row("glfi_acct") = DBNull.Value
                    e.ProposedValue = DBNull.Value
                    e.Row("AcctName") = DBNull.Value
                End If
                Return
            End If
            Dim entity As New Account(e.ProposedValue.ToString)
            If entity.Originated Then
                e.Row("glfi_acct") = entity.Id
                e.ProposedValue = entity.Code
                e.Row("AcctName") = entity.Name
            Else
                e.Row("glfi_acct") = DBNull.Value
                e.ProposedValue = DBNull.Value
                e.Row("AcctName") = DBNull.Value
            End If
        End Sub
        Private Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
            Try
                If Not Me.IsInitialized Then
                    Return
                End If
                Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
                Me.OnPropertyChanged(Me, pe)
                e.Row.SetColumnError("linki_name", "")
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
            'Dim row As DataRow = e.Row
            'Me.m_itemTable.Childs.Remove(CType(row, TreeRow))
            'Try
            '    If Not Me.Isinitialized Then
            '        Return
            '    End If

            '    Dim index As TreeRow = CType(e.Row, TreeRow)
            '    Me.m_itemTable.Childs.Remove(index)
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString)
            'End Try
        End Sub
#End Region
    End Class

    Public Class FinancialFormatItem

#Region "Members"
        Private m_financialformat As FinancialFormat
        Private m_linenumber As Integer
        Private m_indention As Integer
        Private m_code As String
        Private m_name As String
        Private m_namestyle As String
        Private m_linktype As LinkFinancialTypeList
        Private m_note As String
        Private m_notestyle As String
        Private m_formular As String
        Private m_formularstyle As String
        Private m_isnewpage As Boolean
        Private m_linestype As Integer
#End Region

#Region "Constructors"
        Public Sub New()
            Construct()
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal ds As DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct()
            With Me
                .m_financialformat = New FinancialFormat
                .m_linktype = New LinkFinancialTypeList(0)
            End With
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                ' Entity Base.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_link") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_link") Then
                    .m_financialformat = New FinancialFormat(CInt(dr(aliasPrefix & Me.Prefixi & "_link")))
                End If
                ' Line Number.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_linenumber") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_linenumber") Then
                    .m_linenumber = CInt(dr(aliasPrefix & Me.Prefixi & "_linenumber"))
                End If
                ' Idention.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_indention") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_indention") Then
                    .m_indention = CInt(dr(aliasPrefix & Me.Prefixi & "_indention"))
                End If
                ' Code.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_code") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_code") Then
                    .m_code = CStr(dr(aliasPrefix & Me.Prefixi & "_code"))
                End If
                ' Name.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefixi & "_name"))
                End If
                ' Name Style.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_namestyle") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_namestyle") Then
                    .m_namestyle = CStr(dr(aliasPrefix & Me.Prefixi & "_namestyle"))
                End If
                ' Note.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_note") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefixi & "_note"))
                End If
                ' Note Style.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_notestyle") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_notestyle") Then
                    .m_notestyle = CStr(dr(aliasPrefix & Me.Prefixi & "_notestyle"))
                End If
                ' Formular.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_formular") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_formular") Then
                    .m_formular = CStr(dr(aliasPrefix & Me.Prefixi & "_formular"))
                End If
                ' Formular Style.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_formularstyle") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_formularstyle") Then
                    .m_formularstyle = CStr(dr(aliasPrefix & Me.Prefixi & "_formularstyle"))
                End If
                ' is NewPage.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_isnewpage") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_isnewpage") Then
                    .m_isnewpage = CBool(dr(aliasPrefix & Me.Prefixi & "_isnewpage"))
                End If
                ' line style.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_linestype") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_linestype") Then
                    .m_linestype = CInt(dr(aliasPrefix & Me.Prefixi & "_linestype"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Private ReadOnly Property StandardFont() As Font
            Get
                Return New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            End Get
        End Property
        Public Property FinancialFormat() As FinancialFormat
            Get
                Return m_financialformat
            End Get
            Set(ByVal Value As FinancialFormat)
                m_financialformat = Value
            End Set
        End Property
        Public Property LineNumber() As Integer
            Get
                Return m_linenumber
            End Get
            Set(ByVal Value As Integer)
                m_linenumber = Value
            End Set
        End Property
        Public Property Code() As String
            Get
                Return m_code
            End Get
            Set(ByVal Value As String)
                m_code = Value
            End Set
        End Property
        Public Property Indention() As Integer
            Get
                Return m_indention
            End Get
            Set(ByVal Value As Integer)
                m_indention = Value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property
        Public Property NameStyle() As String
            Get
                Return m_namestyle
            End Get
            Set(ByVal Value As String)
                m_namestyle = Value
            End Set
        End Property
        Public Property LinkType() As LinkFinancialTypeList
            Get
                Return m_linktype
            End Get
            Set(ByVal Value As LinkFinancialTypeList)
                m_linktype = Value
            End Set
        End Property
        Public Property Note() As String
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property
        Public Property NoteStyle() As String
            Get
                Return m_notestyle
            End Get
            Set(ByVal Value As String)
                m_notestyle = Value
            End Set
        End Property
        Public Property Formular() As String
            Get
                Return m_formular
            End Get
            Set(ByVal Value As String)
                m_formular = Value
            End Set
        End Property
        Public Property FormularStyle() As String
            Get
                Return m_formularstyle
            End Get
            Set(ByVal Value As String)
                m_formularstyle = Value
            End Set
        End Property
        Public Property IsNewPage() As Boolean
            Get
                Return m_isnewpage
            End Get
            Set(ByVal Value As Boolean)
                m_isnewpage = Value
            End Set
        End Property
        Public Property LineStyle() As Integer
            Get
                Return m_linestype
            End Get
            Set(ByVal Value As Integer)
                m_linestype = Value
            End Set
        End Property
        Private ReadOnly Property Prefixi() As String
            Get
                Return "linki"
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Me.FinancialFormat.IsInitialized = False

            row("linki_link") = Me.FinancialFormat.Id
            row("linki_linenumber") = Me.LineNumber
            row("linki_idention") = Me.Indention
            row("linki_code") = Me.Code
            row("linki_name") = Me.Name
            row("linki_namestyle") = Me.NameStyle
            row("linki_note") = Me.Note
            row("linki_notestyle") = Me.NoteStyle
            row("linki_formular") = Me.Formular
            row("linki_formularstyle") = Me.FormularStyle
            row("linki_isnewpage") = Me.IsNewPage
            row("linki_linestyle") = Me.LineStyle

            Me.FinancialFormat.IsInitialized = True

        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Try
                If Not row.IsNull("linki_link") Then
                    Me.FinancialFormat = New FinancialFormat
                    Me.FinancialFormat.Id = CInt(row("linki_link"))
                End If
                ' Line number.
                If Not row.IsNull(("linki_linenumber")) Then
                    Me.LineNumber = CInt(row("linki_linenumber"))
                End If
                ' Indention.
                If Not row.IsNull(("linki_idention")) Then
                    Me.Indention = CInt(row("linki_idention"))
                End If
                ' Code.
                If Not row.IsNull(("linki_code")) Then
                    Me.Code = CStr(row("linki_code"))
                End If
                ' Name.
                If Not row.IsNull(("linki_name")) Then
                    Me.Name = CStr(row("linki_name"))
                End If
                ' Name Style.
                If Not row.IsNull(("linki_namestyle")) Then
                    Me.NameStyle = CStr(row("linki_namestyle"))
                End If
                ' Note.
                If Not row.IsNull(("linki_note")) Then
                    Me.Note = CStr(row("linki_note"))
                End If
                ' Note Style.
                If Not row.IsNull(("linki_notestyle")) Then
                    Me.NoteStyle = CStr(row("linki_notestyle"))
                End If
                ' Formular.
                If Not row.IsNull(("linki_formular")) Then
                    Me.Formular = CStr(row("linki_formular"))
                End If
                ' Formular Style.
                If Not row.IsNull(("linki_formularstyle")) Then
                    Me.FormularStyle = CStr(row("linki_formularstyle"))
                End If
                ' Is Newpage.
                If Not row.IsNull(("linki_isnewpage")) Then
                    Me.IsNewPage = CBool(row("linki_isnewpage"))
                End If
                ' Line Style.
                If Not row.IsNull(("linki_linestyle")) Then
                    Me.LineStyle = CInt(row("linki_linestyle"))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

    End Class


    ' ประเภทรายงาน
    Public Class LinkFinancialType
        Inherits CodeDescription

#Region "Construtors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "financialstatement_type"
            End Get
        End Property
#End Region

    End Class
    ' รายงานทั้งหมด
    Public Class LinkFinancialTypeList
        Inherits CodeDescription

#Region "Construtors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "financialstatement_list"
            End Get
        End Property
#End Region

    End Class
End Namespace