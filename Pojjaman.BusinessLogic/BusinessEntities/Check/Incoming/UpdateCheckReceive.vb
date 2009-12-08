Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class UpdateCheckReceive
        Inherits SimpleBusinessEntityBase
        Implements IGLAble, IWitholdingTaxable

#Region "Member"
        Private m_issuedate As Date
        Private m_note As String

        Private m_updatedstatus As IncomingCheckDocStatus

        Private m_totalamount As Decimal
        Private m_bankcharge As Decimal
        Private m_whtamt As Decimal

        Private m_itemTable As TreeTable

        Private m_je As JournalEntry
        Private m_whtcol As WitholdingTaxCollection
        Private m_ibillableperson As IBillablePerson
        Private m_incomingcheckremoved As String
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Public Sub New(ByVal Code As String)
            MyBase.New(Code)
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
            ReLoadItems(ds, aliasPrefix)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                .m_issuedate = Now.Date
                .m_updatedstatus = New IncomingCheckDocStatus(-1)
                .Status = New CheckStatus(-1)
                .m_je = New JournalEntry(Me)
                .m_je.DocDate = Me.m_issuedate
                .m_whtcol = New WitholdingTaxCollection
                .m_whtcol.Direction = New WitholdingTaxDirection(0)
                .m_incomingcheckremoved = ""
            End With
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Construct(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' Issuedate ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_issuedate") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_issuedate") Then
                    .m_issuedate = CDate(dr(aliasPrefix & Me.Prefix & "_issuedate"))
                End If
                ' bank charge
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankcharge") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankcharge") Then
                    .m_bankcharge = CDec(dr(aliasPrefix & Me.Prefix & "_bankcharge"))
                End If
                ' wht
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_wht") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_wht") Then
                    .m_whtamt = CDec(dr(aliasPrefix & Me.Prefix & "_wht"))
                End If
                ' Note ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If
                ' Total amount ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_totalamount") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_totalamount") Then
                    .m_totalamount = CInt(dr(aliasPrefix & Me.Prefix & "_totalamount"))
                End If
                ' check status มี 2 สถานะ...IncomingCheckStatus , OutgoingCheckStatus
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_updatedstatus") _
                  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_updatedstatus") Then
                    m_updatedstatus.Value = CInt(dr(aliasPrefix & Me.Prefix & "_updatedstatus"))
                End If

                'status
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
                  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
                    Me.Status.Value = CInt(dr(aliasPrefix & Me.Prefix & "_status"))
                End If

                .m_je = New JournalEntry(Me)

                .m_whtcol = New WitholdingTaxCollection(Me)
                .m_whtcol.Direction = New WitholdingTaxDirection(0)
            End With
        End Sub

#End Region

#Region "Properties"
        Public Property [Date]() As Date Implements IGLAble.Date, IWitholdingTaxable.Date
            Get
                Return Me.IssueDate
            End Get
            Set(ByVal Value As Date)
                Me.IssueDate = Value
            End Set
        End Property
        Public Property IssueDate() As Date
            Get
                Return m_issuedate
            End Get
            Set(ByVal Value As Date)
                m_issuedate = Value
            End Set
        End Property
        Public Property TotalAmount() As Decimal
            Get
                m_totalamount = GetTotalAmount()
                Return m_totalamount
            End Get
            Set(ByVal Value As Decimal)
                m_totalamount = Value
            End Set
        End Property
        Public Property BankCharge() As Decimal
            Get
                m_bankcharge = GetBankChargeAmount()
                Return m_bankcharge
            End Get
            Set(ByVal Value As Decimal)
                m_bankcharge = Value
            End Set
        End Property
        Public Property WHT() As Decimal
            Get
                m_whtamt = GetWHTAmount()
                Return m_whtamt
            End Get
            Set(ByVal Value As Decimal)
                m_whtamt = Value
            End Set
        End Property

        Public Property Note() As String Implements IGLAble.Note
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property
        Public Property UpdatedStatus() As IncomingCheckDocStatus
            Get
                Return m_updatedstatus
            End Get
            Set(ByVal Value As IncomingCheckDocStatus)
                m_updatedstatus = Value
            End Set
        End Property
        Public Property ItemTable() As TreeTable            Get                Return m_itemTable            End Get            Set(ByVal Value As TreeTable)                m_itemTable = Value            End Set        End Property

        Public ReadOnly Property CheckRemovedInItemTable() As String
            Get
                Return m_incomingcheckremoved   ' จะมีค่าเมื่อ remove item.
            End Get
        End Property
        Public ReadOnly Property CheckInItemTable() As String
            Get
                Dim incomminglist As String
                For Each tr As TreeRow In Me.ItemTable.Childs
                    If Me.ValidateRow(tr) Then
                        If tr.Table.Columns.Contains("cqupdatei_entity") AndAlso Not tr.IsNull("cqupdatei_entity") Then
                            incomminglist += "|" & CInt(tr("cqupdatei_entity")) & "|"
                        End If
                    End If
                Next
                Return incomminglist
            End Get
        End Property
#End Region

#Region "Overrides"

        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "updatecheckreceive"
            End Get
        End Property

        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "cqupdate"
            End Get
        End Property
        Public Overrides ReadOnly Property TableName() As String
            Get
                Return "CheckUpdate"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.updatecheckreceive.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.updatecheckreceive"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.updatecheckreceive"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.updatecheckreceive.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
                If tpt.EndsWith("()") Then
                    tpt.TrimEnd("()".ToCharArray)
                End If
                Return tpt
            End Get
        End Property
#End Region

#Region "Shared"
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("CheckUpdate")
            myDatatable.Columns.Add(New DataColumn("linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("cqcode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("docdate", GetType(Date)))
            myDatatable.Columns.Add(New DataColumn("recipient", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_amount", GetType(Decimal)))

            myDatatable.Columns.Add(New DataColumn("cqupdatei_entity", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("cqupdatei_beforestatus", GetType(Integer)))
            ' Bank account 
            myDatatable.Columns.Add(New DataColumn("bankacct_id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("bankacct_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bankacct_name", GetType(String)))

            ' Bank
            myDatatable.Columns.Add(New DataColumn("bank_id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("bank_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bank_name", GetType(String)))

            ' IncomingCheck
            myDatatable.Columns.Add(New DataColumn("check_id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_cqcode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_receivedate", GetType(Date)))
            myDatatable.Columns.Add(New DataColumn("check_duedate", GetType(Date)))
            myDatatable.Columns.Add(New DataColumn("check_receiveperson", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_customer", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_payer", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_bankacct", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_bank", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_bankcharge", GetType(Decimal)))
            myDatatable.Columns.Add(New DataColumn("check_wht", GetType(Decimal)))
            myDatatable.Columns.Add(New DataColumn("check_amt", GetType(Decimal)))
            myDatatable.Columns.Add(New DataColumn("check_note", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_docstatus", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_status", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_lastestdocstatus", GetType(String)))

            Return myDatatable
        End Function
#End Region

#Region "Methods"
        Private Sub ResetID(ByVal oldid As Integer, ByVal oldje As Integer)
            Me.Id = oldid
            If Not Me.WitholdingTaxCollection Is Nothing Then
                Me.WitholdingTaxCollection.ResetId()
            End If
            Me.m_je.Id = oldje
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                If .MaxRowIndex < 0 Then '.ItemTable.Childs.Count = 0 Then
                    Return New SaveErrorException(.StringParserService.Parse("${res:Global.Error.NoItem}"))
                End If
                If .WHT <> .m_whtcol.Amount Then
                    Return New SaveErrorException(.StringParserService.Parse("${res:Global.Error.WhtMissing}"), _
                    Configuration.FormatToString(WHT, DigitConfig.Price), _
                    Configuration.FormatToString(m_whtcol.Amount, DigitConfig.Price))
                End If

                Dim tmpPerson As IBillablePerson = Me.Person
                m_saving = True 'กันเรื่องเรียก Person ใน Check


                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current

                ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
                Dim paramArrayList As New ArrayList

                paramArrayList.Add(returnVal)
                If .Originated Then
                    paramArrayList.Add(New SqlParameter("@" & .Prefix & "_id", .Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False

                If Me.m_je.Status.Value = 4 Then
                    Me.Status.Value = 4
                    Me.m_whtcol.SetStatus(4)
                End If
                If Me.Status.Value = -1 Then
                    Me.Status.Value = 2
                End If

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_code", .Code))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_issuedate", ValidDateOrDBNull(.IssueDate)))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_checktype", (New IncomingCheck).EntityId))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_totalamount", .TotalAmount))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_note", .Note))

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_status", .Status.Value))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_updatedstatus", .UpdatedStatus.Value))

                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(.ConnectionString)

                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                trans = conn.BeginTransaction()

                Dim oldid As Integer = Me.Id
                If Not Me.WitholdingTaxCollection Is Nothing Then
                    Me.WitholdingTaxCollection.SaveOldID()
                End If
                Dim oldje As Integer = m_je.Id

                Try
                    .ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                    If IsNumeric(returnVal.Value) Then
                        Select Case CInt(returnVal.Value)
                            Case -1, -2, -5
                                trans.Rollback()
                                Me.ResetID(oldid, oldje)
                                m_saving = False
                                Return New SaveErrorException(returnVal.Value.ToString)
                            Case Else
                        End Select
                    ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                        trans.Rollback()
                        Me.ResetID(oldid, oldje)
                        m_saving = False
                        Return New SaveErrorException(returnVal.Value.ToString)
                    End If

                    Dim saveDetailError As SaveErrorException = SaveDetail(.Id, conn, trans)
                    If Not IsNumeric(saveDetailError.Message) OrElse CInt(saveDetailError.Message) < 0 Then
                        trans.Rollback()
                        m_saving = False
                        Return saveDetailError
                    End If

                    Dim cc As CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    If Not cc Is Nothing Then
                        Me.m_whtcol.SetCCId(cc.Id)
                    End If

                    If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
                        Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
                        If Not IsNumeric(saveWhtError.Message) Then
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
                            m_saving = False
                            Return saveWhtError
                        Else
                            Select Case CInt(saveWhtError.Message)
                                Case -1, -2, -5
                                    trans.Rollback()
                                    Me.ResetID(oldid, oldje)
                                    m_saving = False
                                    Return saveWhtError
                                Case Else
                            End Select
                        End If
                    End If


                    ' Save GL


                    If Me.m_je.Status.Value = -1 Then
                        m_je.Status.Value = 3
                    End If
                    Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
                    If Not IsNumeric(saveJeError.Message) Then
                        trans.Rollback()
                        Me.ResetID(oldid, oldje)
                        m_saving = False
                        Return saveJeError
                    Else
                        Select Case CInt(saveJeError.Message)
                            Case -1, -5
                                trans.Rollback()
                                Me.ResetID(oldid, oldje)
                                m_saving = False
                                Return saveJeError
                            Case -2
                                'Post ไปแล้ว
                                m_saving = False
                                Return saveJeError
                            Case Else
                        End Select
                    End If

                    trans.Commit()
                    m_saving = False
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
                    m_saving = False
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
                    m_saving = False
                    Return New SaveErrorException(ex.ToString)
                Finally
                    m_saving = False
                    conn.Close()
                End Try
            End With

        End Function
        Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
            Try
                Dim da As New SqlDataAdapter("Select * from CheckUpdateItem where cqupdatei_cqupdateid = " & Me.Id, conn)
                Dim cmdBuilder As New SqlCommandBuilder(da)

                Dim ds As New DataSet

                da.SelectCommand.Transaction = trans

                'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
                cmdBuilder.GetDeleteCommand.Transaction = trans
                cmdBuilder.GetInsertCommand.Transaction = trans
                cmdBuilder.GetUpdateCommand.Transaction = trans

                da.Fill(ds, "CheckUpdateItem")

                UpdateOldItemStatus(conn, trans)

                Dim dbCount As Integer = ds.Tables("CheckUpdateItem").Rows.Count
                Dim itemCount As Integer = Me.ItemTable.Childs.Count
                Dim i As Integer = 0
                With ds.Tables("CheckUpdateItem")
                    For Each row As DataRow In .Rows
                        row.Delete()
                    Next
                    For n As Integer = 0 To Me.MaxRowIndex
                        Dim row As TreeRow = Me.m_itemTable.Childs(n)
                        If ValidateRow(row) Then
                            i += 1
                            Dim itemEntity As New UpdateCheckReceiveItem
                            itemEntity.CopyFromDataRow(row)
                            Dim dr As DataRow = .NewRow
                            dr("cqupdatei_cqupdateid") = Me.Id
                            dr("cqupdatei_linenumber") = i 'item("pri_linenumber")
                            dr("cqupdatei_entity") = itemEntity.Entity.Id
                            dr("cqupdatei_beforestatus") = itemEntity.BeforeStatus.Value
                            .Rows.Add(dr)

                            UpdateCheckStatus(itemEntity.Entity.Id, conn, trans)
                        End If

                    Next

                End With
                Dim dt As DataTable = ds.Tables("CheckUpdateItem")
                ' First process deletes.
                da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
                ' Next process updates.
                da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
                ' Finally process inserts.
                da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
                Return New SaveErrorException("1")
            Catch ex As Exception
                Return New SaveErrorException(ex.ToString)
            End Try
        End Function
        Private Function UpdateOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, Optional ByVal changeAll As Boolean = False) As SaveErrorException
            Dim daOldRef As New SqlDataAdapter("select * from incomingcheck " & _
            "where check_id in (select cqupdatei_entity from CheckUpdateItem " & _
            " where cqupdatei_cqupdateid =" & Me.Id & ")" & _
            " and check_id in (select receivei_entity from receiveitem " & _
            " where receivei_entitytype = 27 and receivei_status <> 0)" _
            , conn) '-----> มีใน checkupdate และ receive

            Dim daOldStatusRef As New SqlDataAdapter("select * from incomingcheck " & _
            "where check_id in (select cqupdatei_entity from CheckUpdateItem " & _
            " where cqupdatei_cqupdateid =" & Me.Id & ")" & _
            " and check_id not in (select receivei_entity from receiveitem " & _
            " where receivei_entitytype = 27 and receivei_status <> 0)" _
            , conn) '-----> มีใน checkupdate ไม่มีใน receive

            Dim cmdBuilder As SqlCommandBuilder

            Dim ds As New DataSet

            cmdBuilder = New SqlCommandBuilder(daOldRef)
            daOldRef.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans
            cmdBuilder = Nothing
            daOldRef.Fill(ds, "OldCheck")

            cmdBuilder = New SqlCommandBuilder(daOldStatusRef)
            daOldStatusRef.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans
            cmdBuilder = Nothing
            daOldStatusRef.Fill(ds, "OldCheckStatus")

            Dim dtOldRef As DataTable = ds.Tables("OldCheck")
            For Each row As DataRow In dtOldRef.Rows
                Dim found As Boolean = False
                For n As Integer = 0 To Me.MaxRowIndex
                    Dim item As TreeRow = Me.m_itemTable.Childs(n)
                    If ValidateRow(item) Then
                        If IsNumeric(item("cqupdatei_entity")) AndAlso CInt(item("cqupdatei_entity")) = CInt(row("check_id")) Then
                            'เจอแล้ว --> 
                            found = True
                            Exit For
                        End If
                    End If
                Next
                If (Not found) Or changeAll Then
                    'ไม่เจอ -- 
                    'แก้เฉพาะ docstatus เพราะมีอ้างอิงอยู่ที่อื่นด้วย
                    If Not row.IsNull("check_docstatus") AndAlso IsNumeric(row("check_docstatus")) Then
                        Select Case CInt(row("check_docstatus"))
                            Case 3 'นำฝาก --> ในมือ
                                row("check_docstatus") = 1
                            Case 2 'ผ่าน --> กลับเป็นนำฝาก
                                row("check_docstatus") = 3
                            Case 0 'ยกเลิก --> กลับเป็น นำฝาก หรือ ในมือ
                                Dim checkId As Integer = CInt(row("check_id"))
                                Dim oldStatus As Integer = GetOldStatusFromId(checkId)
                                If oldStatus = -1 Then
                                    'ไม่เจอ status --> แก้เป็นในมือ
                                    row("check_docstatus") = 1
                                Else
                                    row("check_docstatus") = oldStatus
                                End If
                        End Select
                    End If
                End If
            Next

            Dim dtOldStatusRef As DataTable = ds.Tables("OldCheckStatus")
            For Each row As DataRow In dtOldStatusRef.Rows
                Dim found As Boolean = False
                For n As Integer = 0 To Me.MaxRowIndex
                    Dim item As TreeRow = Me.m_itemTable.Childs(n)
                    If ValidateRow(item) Then
                        If IsNumeric(item("cqupdatei_entity")) AndAlso CInt(item("cqupdatei_entity")) = CInt(row("check_id")) Then
                            'เจอแล้ว --> 
                            found = True
                            Exit For
                        End If
                    End If
                Next
                If (Not found) Or changeAll Then
                    'ไม่เจอ
                    'แก้ทั้ง docstatus,status เพราะไม่มีอ้างอิงอยู่ที่อื่นด้วย
                    If Not row.IsNull("check_status") AndAlso IsNumeric(row("check_status")) Then
                        If CInt(row("check_status")) = 3 Then
                            row("check_status") = 2
                        End If
                    End If
                    If Not row.IsNull("check_docstatus") AndAlso IsNumeric(row("check_docstatus")) Then
                        Select Case CInt(row("check_docstatus"))
                            Case 3 'นำฝาก --> ในมือ
                                row("check_docstatus") = 1
                            Case 2 'ผ่าน --> กลับเป็นนำฝาก
                                row("check_docstatus") = 3
                            Case 0 'ยกเลิก --> กลับเป็น นำฝาก หรือ ในมือ
                                Dim checkId As Integer = CInt(row("check_id"))
                                Dim oldStatus As Integer = GetOldStatusFromId(checkId)
                                If oldStatus = -1 Then
                                    'ไม่เจอ status --> แก้เป็นในมือ
                                    row("check_docstatus") = 1
                                Else
                                    row("check_docstatus") = oldStatus
                                End If
                        End Select
                    End If
                End If
            Next
            daOldRef.Update(dtOldRef.Select(Nothing, Nothing, DataViewRowState.Deleted))
            daOldRef.Update(dtOldRef.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            daOldRef.Update(dtOldRef.Select(Nothing, Nothing, DataViewRowState.Added))

            daOldStatusRef.Update(dtOldStatusRef.Select(Nothing, Nothing, DataViewRowState.Deleted))
            daOldStatusRef.Update(dtOldStatusRef.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            daOldStatusRef.Update(dtOldStatusRef.Select(Nothing, Nothing, DataViewRowState.Added))
        End Function
        Private Function GetOldStatusFromId(ByVal checkId As Integer) As Integer
            Try
                Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                        Me.ConnectionString _
                        , CommandType.StoredProcedure _
                        , "GetIncomingCheckOldStatus" _
                        , New SqlParameter("@cqupdatei_cqupdateid", Me.Id) _
                        , New SqlParameter("@cqupdatei_entity", checkId) _
                        )
                If ds.Tables(0).Rows.Count > 0 Then
                    Return CInt(ds.Tables(0).Rows(0)(0))
                End If
            Catch ex As Exception
                Return -1
            End Try
        End Function
        Private Function UpdateCheckStatus(ByVal checkID As Integer, _
                                    ByVal conn As SqlConnection, _
                                    ByVal trans As SqlTransaction) As Integer
            Dim sqlSelecttext As String

            sqlSelecttext = "Select * from IncomingCheck Where check_id = " & checkID

            Dim da As New SqlDataAdapter(sqlSelecttext, conn)
            Dim cmdBuilder As New SqlCommandBuilder(da)

            Dim ds As New DataSet

            da.SelectCommand.Transaction = trans

            'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans

            da.Fill(ds)
            With ds.Tables(0)
                For Each row As DataRow In .Rows
                    row("check_docstatus") = Me.UpdatedStatus.Value
                    If Not IsNumeric(row("check_status")) OrElse CInt(row("check_status")) <> 0 Then
                        row("check_status") = 3
                    End If

                    For n As Integer = 0 To Me.MaxRowIndex
                        Dim rowx As TreeRow = Me.m_itemTable.Childs(n)
                        If ValidateRow(rowx) Then
                            Dim itemEntity As New IncomingCheck(rowx, "")
                            If CInt(row("check_id")) = itemEntity.Id Then
                                row("check_bankcharge") = itemEntity.BankCharge
                                row("check_wht") = itemEntity.WHT
                            End If
                        End If
                    Next

                Next
            End With
            Dim dt As DataTable = ds.Tables(0)
            ' First process deletes.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        End Function
#End Region

#Region "Items"
        Public Overloads Sub ReLoadItems()
            Me.IsInitialized = False
            m_itemTable = GetSchemaTable()
            LoadItems()
            Me.IsInitialized = True
        End Sub
        Public Overloads Sub ReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.IsInitialized = False
            m_itemTable = GetSchemaTable()
            LoadItems(ds, aliasPrefix)
            Me.IsInitialized = True
        End Sub
        Private Sub LoadItems()
            If Not Me.Originated Then
                Return
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
            , CommandType.StoredProcedure _
            , "GetCheckUpdateItem" _
            , New SqlParameter("@cqupdatei_cqupdateid", Me.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New UpdateCheckReceiveItem(row, "")
                item.UpdateCheckReceive = Me
                ' Hack : Huaneng ...
                Me.Add(item)
            Next
        End Sub
        Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            For Each dr As DataRow In ds.Tables(1).Rows
                Dim item As New UpdateCheckReceiveItem(dr, aliasPrefix)
                item.UpdateCheckReceive = Me
                Me.Add(item)
            Next
        End Sub
        Public Sub AddBlankRow(ByVal count As Integer)
            For i As Integer = 0 To count - 1
                Dim newItem As New BlankItem("")
                Dim mtwItem As New UpdateCheckReceiveItem
                Me.ItemTable.AcceptChanges()
                Me.Add(mtwItem)
            Next
        End Sub
        Public Function Add(ByVal item As UpdateCheckReceiveItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.Add
            item.LineNumber = Me.ItemTable.Childs.Count
            item.UpdateCheckReceive = Me
            item.CopyToDataRow(myRow)
            Return myRow
        End Function
        Public Function Insert(ByVal index As Integer, ByVal item As UpdateCheckReceiveItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
            item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
            item.UpdateCheckReceive = Me
            item.CopyToDataRow(myRow)
            ReIndex(index + 1)
            Return myRow
        End Function
        Public Function MaxRowIndex() As Integer
            If Me.m_itemTable Is Nothing Then
                Return -1
            End If
            'ให้ index ของแถวสุดท้ายที่มีข้อมูล
            For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
                Dim row As TreeRow = Me.m_itemTable.Childs(i)
                If ValidateRow(row) Then
                    Return i
                End If
            Next
            Return -1 'ไม่มีข้อมูลเลย
        End Function
        Public Sub Remove(ByVal index As Integer)
            Dim row As TreeRow = Me.ItemTable.Childs(index)
            Dim item As New UpdateCheckReceiveItem
            item.CopyFromDataRow(row)
            Dim referenced As Boolean = CheckEntityReferenced(row)
            If referenced Then
                Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                myMessage.ShowErrorFormatted("${res:Global.EntityReferenced}", item.Entity.Code)
            Else
                ' เก็บค่า Check ที่เคยอยู่ใน list แล้ว remove ออก
                If row.Table.Columns.Contains("cqupdatei_entity") AndAlso Not row.IsNull("cqupdatei_entity") Then
                    m_incomingcheckremoved += "|" & CInt(row("cqupdatei_entity")) & "|"
                End If
                Me.ItemTable.Childs.Remove(row)
            End If
            ReIndex()
        End Sub
        Private Sub ReIndex()
            ReIndex(0)
        End Sub
        Private Sub ReIndex(ByVal index As Integer)
            If index < 0 OrElse index > Me.ItemTable.Childs.Count - 1 Then
                Return
            End If
            For i As Integer = index To Me.ItemTable.Childs.Count - 1
                Me.ItemTable.Childs(i)("linenumber") = i + 1
            Next
        End Sub
        Public Function CheckEntityReferenced(ByVal row As TreeRow) As Boolean
            Dim item As New UpdateCheckReceiveItem
            item.CopyFromDataRow(row)
            If Not item.Entity Is Nothing AndAlso Not item.Entity.DocStatus Is Nothing Then
                Select Case Me.UpdatedStatus.Value
                    Case 0  ' ยกเลิก {ในมือ-นำฝาก}
                        Select Case item.Entity.DocStatus.Value
                            Case 0, 1, 2
                                Return False
                            Case Else
                                Return True
                        End Select
                    Case 1, 2   ' ในมือ {นำฝาก} , ' ผ่าน {นำฝาก}
                        Select Case item.Entity.DocStatus.Value
                            Case 3, 1, 2
                                Return False
                            Case Else
                                Return True
                        End Select
                    Case Else
                End Select
            End If
            Return False
        End Function
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If


            If Not e.Row.RowState = DataRowState.Detached Then
                e.Row.SetColumnError("Code", "")
            Else
                e.Row.SetColumnError("Code", Me.StringParserService.Parse("${res:Global.Error.GridHasNewLine}"))
                'If Not Me.m_validator Is Nothing Then
                '    Me.m_validator.HasNewRow = True
                'End If
            End If
            Me.m_itemTable.AcceptChanges()
            Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
            If index = Me.m_itemTable.Childs.Count - 1 Then

            End If
            Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
            Me.OnPropertyChanged(Me, pe)
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If

            Dim proposedCode As Object = e.Row("Code")
           
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        proposedCode = e.ProposedValue
                        If Not proposedCode Is Nothing Then
                            Dim entity As New IncomingCheck(CStr(proposedCode))
                            If entity.DocStatus.Value = 2 Then
                                Dim msg As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                                msg.ShowWarningFormatted("${res:Global.EntityReferenced}", New String() {entity.Code})
                                e.ProposedValue = ""
                                Return
                            End If
                        End If

                        SetEntityValue(e)
                    Case "check_wht"
                        SetWhtValue(e)
                    Case "check_bankcharge"
                        SetBankChargeValue(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim proposedCode As Object = e.Row("Code")
            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    proposedCode = e.ProposedValue

                Case Else
                    Return
            End Select

            If IsDBNull(proposedCode) Then
                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.CodeMissing}"))
            Else
                e.Row.SetColumnError("code", "")
            End If

        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Dim proposedCode As Object = row("Code")

            If (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") Then
                Return False
            End If
            Return True
        End Function
        Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
            If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(TextParser.Evaluate(e.ProposedValue.ToString), DigitConfig.Qty)
        End Sub
        Public Sub SetEntityName(ByVal e As DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If
            e.Row("Code") = DBNull.Value
        End Sub
        Private m_entitySetting As Boolean = False
        Public Sub SetEntityValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            Dim entity As New IncomingCheck(e.ProposedValue.ToString)
            m_entitySetting = True
            If entity Is Nothing Then
                Debug.Assert(Not IsNothing(entity), "Entity nothing...")
                Return
            End If
            If entity.Originated Then
                e.Row("cqupdatei_entity") = entity.Id
                e.Row("docdate") = entity.ReceiveDate
                e.Row("cqcode") = entity.CqCode
                e.Row("recipient") = entity.ReceivePerson.Name
                If Not entity.Customer Is Nothing Then
                    e.Row("check_customer") = entity.Customer.Id
                End If
                e.Row("bank_name") = entity.Bank.Name
                If Not entity.BankAccount Is Nothing Then
                    e.Row("check_bankacct") = entity.BankAccount.Id
                    e.Row("bankacct_code") = entity.BankAccount.Code
                    e.Row("bankacct_name") = entity.BankAccount.Name
                    e.Row("bank_name") = entity.BankAccount.BankBranch.Bank.Name
                End If
                e.Row("check_bankcharge") = entity.BankCharge
                e.Row("check_wht") = entity.WHT
                e.Row("check_amount") = entity.Amount

                e.Row("cqupdatei_beforestatus") = entity.DocStatus.Value

                e.ProposedValue = entity.Code
            Else
                e.Row("cqupdatei_entity") = DBNull.Value
                e.Row("docdate") = DBNull.Value
                e.Row("cqcode") = DBNull.Value
                e.Row("recipient") = DBNull.Value
                e.Row("check_customer") = DBNull.Value
                e.Row("bank_name") = DBNull.Value
                e.Row("check_bankacct") = DBNull.Value
                e.Row("bankacct_code") = DBNull.Value
                e.Row("bankacct_name") = DBNull.Value
                e.Row("bank_name") = DBNull.Value
                e.Row("check_bankcharge") = DBNull.Value
                e.Row("check_wht") = DBNull.Value
                e.Row("check_amount") = DBNull.Value
                e.Row("cqupdatei_beforestatus") = DBNull.Value

                e.ProposedValue = DBNull.Value
            End If
            m_entitySetting = False
        End Sub
        Private Sub SetWhtValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            m_entitySetting = True
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)

            If e.Row.IsNull("code") Then
                e.ProposedValue = e.Row(e.Column)
                Return
            Else
                Dim proposedBankAcct As Object = e.Row("bankacct_code")
                If (IsDBNull(proposedBankAcct) OrElse CStr(proposedBankAcct) = "") Then
                    e.ProposedValue = e.Row(e.Column)
                    Return
                End If
            End If
            m_entitySetting = False
        End Sub
        Private Sub SetBankChargeValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            m_entitySetting = True
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)

            If e.Row.IsNull("code") Then
                e.ProposedValue = e.Row(e.Column)
                Return
            Else
                Dim proposedBankAcct As Object = e.Row("bankacct_code")
                If (IsDBNull(proposedBankAcct) OrElse CStr(proposedBankAcct) = "") Then
                    e.ProposedValue = e.Row(e.Column)
                    Return
                End If
            End If
            m_entitySetting = False
        End Sub
#End Region

#Region " IGLAble "

        Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                                  , CommandType.StoredProcedure _
                                  , "GetGLFormatForEntity" _
                                  , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))

            Dim glf As GLFormat
            If Me.UpdatedStatus.Value = 0 Then  ' ยกเลิก
                glf = New GLFormat(ds.Tables(0).Rows(1), "") ' ยกเลิก
            ElseIf Me.UpdatedStatus.Value = 2 Then
                glf = New GLFormat(ds.Tables(0).Rows(0), "") ' ผ่าน
            ElseIf Me.UpdatedStatus.Value = 1 Then
                glf = New GLFormat(ds.Tables(0).Rows(2), "") ' รับในมือ
            Else
                glf = New GLFormat
            End If

            Return glf
        End Function

        Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
            Dim jiColl As New JournalEntryItemCollection
            Dim ji As New JournalEntryItem
            Dim notCombine As Boolean = True 'ถ้าไม่ต้องการรวมยอดเช็คใน GL
            If Me.TotalAmount > 0 Then
                If notCombine Then
                    If Me.UpdatedStatus.Value = 2 Then ' จ่ายผ่าน  { H2.2 , H2.4 }
                        ' DR. เงินฝากธนาคาร              ji.Mapping = "H5.1"
                        ' DR. ค่าธรรมเนียมธนาคาร       ji.Mapping = "H5.2"
                        ' CR. เช็ครอเรียกเก็บ              ji.Mapping = "H5.3"
                        ' CR. ภาษีหัก ณ ที่จ่าย            ji.Mapping = "H5.4"
                        SetGLH5_1_5_4(jiColl)
                    ElseIf Me.UpdatedStatus.Value = 0 Then ' ยกเลิก { H2.1 , H2.3 }
                        ' DR. ลกหนี้การค้า                  ji.Mapping = "H5.5"
                        ' Cr. เช็ครอเรียกเก็บ              ji.Mapping = "H5.6" -- นำฝากเท่านั้น
                        ' Cr. ภาษีหัก ณ ที่จ่าย            ji.Mapping = "H5.7"
                        ' Cr. เช็ครับรอนำฝาก             ji.Mapping = "H5.8" -- ในมือเท่านั้น 
                        SetGLH5_5_5_8(jiColl)
                    ElseIf Me.UpdatedStatus.Value = 1 Then
                        ' Dr. เช็ครับรอนำฝาก               ji.Mapping = "H5.9" 
                        ' Cr. เช็ครอเรียกเก็บ                      ji.Mapping = "H5.10" 
                        SetGLH5_9_5_10(jiColl)
                    End If
                Else
                    If Me.UpdatedStatus.Value = 2 Then ' จ่ายผ่าน  { H2.2 , H2.4 }
                        ' DR. เงินฝากธนาคาร              ji.Mapping = "H5.1"
                        SetGLH5_1(jiColl)
                        ' DR. ค่าธรรมเนียมธนาคาร       ji.Mapping = "H5.2"
                        SetGLH5_2(jiColl)

                        ' CR. เช็ครอเรียกเก็บ              ji.Mapping = "H5.3"
                        SetGLH5_3(jiColl)
                        ' CR. ภาษีหัก ณ ที่จ่าย            ji.Mapping = "H5.4"
                        SetGLH5_4(jiColl)
                    ElseIf Me.UpdatedStatus.Value = 0 Then ' ยกเลิก { H2.1 , H2.3 }
                        ' DR. ลกหนี้การค้า                  ji.Mapping = "H5.5"
                        SetGLH5_5(jiColl)

                        ' Cr. เช็ครอเรียกเก็บ              ji.Mapping = "H5.6" -- นำฝากเท่านั้น
                        SetGLH5_6(jiColl)
                        ' Cr. ภาษีหัก ณ ที่จ่าย            ji.Mapping = "H5.7"
                        SetGLH5_7(jiColl)
                        ' Cr. เช็ครับรอนำฝาก             ji.Mapping = "H5.8" -- ในมือเท่านั้น 
                        SetGLH5_8(jiColl)
                    ElseIf Me.UpdatedStatus.Value = 1 Then
                        ' Dr. เช็ครับรอนำฝาก               ji.Mapping = "H5.9" 
                        SetGLH5_9(jiColl)

                        ' Cr. เช็ครอเรียกเก็บ                      ji.Mapping = "H5.10" 
                        SetGLH5_10(jiColl)
                    End If
                End If
            End If

            Return jiColl
        End Function
        ' Dr. สมุกเงินฝากธนาคาร H5.1 
        Private Sub SetGLH5_1(ByVal jiColl As JournalEntryItemCollection)
            If Me.TotalAmount > 0 Then
                Dim ji As New JournalEntryItem
                Dim ht As New Hashtable
                For Each trow As TreeRow In Me.ItemTable.Childs
                    If ValidateRow(trow) Then
                        If Not trow.IsNull("check_bankacct") Then
                            Dim bankacct As New BankAccount(CInt(trow("check_bankacct")))
                            If Not bankacct.Account Is Nothing Then
                                ht(bankacct.Account.Id) = bankacct.Account
                            End If
                        End If
                    End If
                Next

                For Each acct As Account In ht.Values
                    Dim Intotalamnt As Decimal = 0
                    Dim IntotalBankcharge As Decimal = 0
                    Dim IntotalWht As Decimal = 0
                    For i As Integer = Me.MaxRowIndex To 0 Step -1
                        Dim row As TreeRow = Me.ItemTable.Childs(i)
                        If ValidateRow(row) Then
                            Dim bankacct As New BankAccount(CInt(row("check_bankacct")))
                            If bankacct.Originated Then
                                If Not bankacct.Account Is Nothing _
                                AndAlso bankacct.Account.Id = acct.Id Then
                                    Intotalamnt += CDec(row("check_amount"))
                                    If Not row.IsNull("check_bankcharge") Then IntotalBankcharge += CDec(row("check_bankcharge"))
                                    If Not row.IsNull("check_wht") Then IntotalWht += CDec(row("check_wht"))
                                End If
                            End If
                        End If
                    Next
                    If Intotalamnt > 0 Then
                        ji = New JournalEntryItem
                        ji.Mapping = "H5.1"
                        ji.Amount = (Intotalamnt - IntotalBankcharge) + IntotalWht
                        If acct.Originated Then
                            ji.Account = acct
                        End If
                        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                        jiColl.Add(ji)
                    End If
                Next
                ' กรณ๊ไม่มี account 
                Dim Extotalamnt As Decimal = 0
                Dim ExtotalBankcharge As Decimal = 0
                Dim ExtotalWht As Decimal = 0

                For i As Integer = Me.MaxRowIndex To 0 Step -1
                    Dim row As TreeRow = Me.ItemTable.Childs(i)
                    If ValidateRow(row) Then
                        Dim bankacct As BankAccount
                        If Not row.IsNull("check_bankacct") Then bankacct = New BankAccount(CInt(row("check_bankacct")))
                        If row.IsNull("check_bankacct") OrElse Not bankacct.Originated Then
                            Extotalamnt += CDec(row("check_amount"))
                            If Not row.IsNull("check_bankcharge") Then ExtotalBankcharge += CDec(row("check_bankcharge"))
                            If Not row.IsNull("check_wht") Then ExtotalWht += CDec(row("check_wht"))
                        End If
                    End If
                Next
                If Extotalamnt > 0 Then
                    ji = New JournalEntryItem
                    ji.Mapping = "H5.1"
                    ji.Amount = (Extotalamnt - ExtotalBankcharge) + ExtotalWht
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    jiColl.Add(ji)
                End If
            End If
        End Sub
        ' Dr. ค่าธรรมเนียมธนาคาร H5.2
        Private Sub SetGLH5_2(ByVal jiColl As JournalEntryItemCollection)
            Dim ji As New JournalEntryItem
            If Me.BankCharge > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "H5.2"
                ji.Amount = Me.BankCharge
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' Cr. เช็ครอเรียกเก็บ H5.3
        Private Sub SetGLH5_3(ByVal jiColl As JournalEntryItemCollection)
            Dim ji As New JournalEntryItem
            If Me.TotalAmount > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "H5.3"
                ji.Amount = Me.TotalAmount
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' CR. ภาษีหัก ณ ที่จ่าย H5.4
        Private Sub SetGLH5_4(ByVal jiColl As JournalEntryItemCollection)
            Dim ji As New JournalEntryItem
            If Me.WHT > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "H5.4"
                ji.Amount = Me.WHT
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' Dr. สมุกเงินฝากธนาคาร H5.1 
        ' Dr. ค่าธรรมเนียมธนาคาร H5.2
        ' Cr. เช็ครอเรียกเก็บ H5.3
        ' CR. ภาษีหัก ณ ที่จ่าย H5.4
        Private Sub SetGLH5_1_5_4(ByVal jiColl As JournalEntryItemCollection)
            If Me.TotalAmount > 0 Then
                Dim ji As New JournalEntryItem
                For Each row As TreeRow In Me.ItemTable.Childs
                    Dim Totalamnt As Decimal = 0
                    Dim TotalBankcharge As Decimal = 0
                    Dim TotalWht As Decimal = 0
                    If ValidateRow(row) Then
                        Dim bankacct As BankAccount
                        If Not row.IsNull("check_bankacct") Then
                            bankacct = New BankAccount(CInt(row("check_bankacct")))
                        End If
                        Totalamnt = CDec(row("check_amount"))
                        If Not row.IsNull("check_bankcharge") Then TotalBankcharge = CDec(row("check_bankcharge"))
                        If Not row.IsNull("check_wht") Then TotalWht = CDec(row("check_wht"))

                        'สุมดเงินฝากธนาคาร
                        If Totalamnt > 0 Then
                            ji = New JournalEntryItem
                            ji.Mapping = "Through"
                            ji.IsDebit = True
                            ji.Amount = (Totalamnt - TotalBankcharge) + TotalWht
                            If Not row.IsNull("check_bankacct") AndAlso bankacct.Originated Then
                                ji.Account = bankacct.Account
                            End If
                            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                            jiColl.Add(ji)
                        End If

                        'ค่าธรรมเนียมธนาคาร
                        If TotalBankcharge > 0 Then
                            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.BankCharge)
                            ji = New JournalEntryItem
                            ji.Mapping = "Through"
                            ji.IsDebit = True
                            ji.Amount = TotalBankcharge
                            ji.Account = ga.Account
                            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                            jiColl.Add(ji)
                        End If

                        'เช็ครอเรียกเก็บ
                        If Totalamnt > 0 Then
                            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckUnCollected)
                            ji = New JournalEntryItem
                            ji.Mapping = "Through"
                            ji.IsDebit = False
                            ji.Amount = Totalamnt
                            ji.Account = ga.Account
                            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                            jiColl.Add(ji)
                        End If

                        'ภาษีหัก ณ ที่จ่าย
                        If TotalWht > 0 Then
                            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.WitholdingTaxOut)
                            ji = New JournalEntryItem
                            ji.Mapping = "Through"
                            ji.IsDebit = False
                            ji.Amount = TotalWht
                            ji.Account = ga.Account
                            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                            jiColl.Add(ji)
                        End If
                    End If
                Next
            End If
        End Sub
        ' DR. ลกหนี้การค้า H5.5
        Private Sub SetGLH5_5(ByVal jiColl As JournalEntryItemCollection)
            Dim ji As New JournalEntryItem
            Dim ht As New Hashtable
            For Each trow As TreeRow In Me.ItemTable.Childs
                If ValidateRow(trow) Then
                    Dim cust As New Customer(CInt(trow("check_customer")))
                    ht(cust.Account.Id) = cust.Account
                End If
            Next

            Dim sumvalNoneAcct As Decimal = 0

            For Each acct As Account In ht.Values
                Dim sumvalInAcct As Decimal = 0
                For i As Integer = Me.MaxRowIndex To 0 Step -1
                    Dim row As TreeRow = Me.ItemTable.Childs(i)
                    If ValidateRow(row) Then
                        Dim cust As New Customer(CInt(row("check_customer")))
                        If cust.Account Is Nothing Then
                            sumvalNoneAcct += CDec(row("check_amount"))
                        Else
                            If cust.Account.Id = acct.Id Then
                                sumvalInAcct += CDec(row("check_amount"))
                            End If
                        End If
                    End If
                Next
                If sumvalInAcct > 0 Then
                    ji = New JournalEntryItem
                    ji.Mapping = "H5.5"
                    ji.Amount = sumvalInAcct
                    If acct.Originated Then
                        ji.Account = acct
                    End If
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    jiColl.Add(ji)
                End If
            Next
            If sumvalNoneAcct > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "H5.5"
                ji.Amount = sumvalNoneAcct
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' Cr. เช็ครอเรียกเก็บ H5.6   -- นำฝากเท่านั้น
        Private Sub SetGLH5_6(ByVal jiColl As JournalEntryItemCollection)

            Dim ji As New JournalEntryItem
            Dim ht As New Hashtable
            Dim totalamnt As Decimal
            Dim whtamnt As Decimal
            For Each trow As TreeRow In Me.ItemTable.Childs
                If ValidateRow(trow) Then
                    If Not trow.IsNull("cqupdatei_beforestatus") _
                    AndAlso CInt(trow("cqupdatei_beforestatus")) = 3 Then
                        totalamnt += CDec(trow("check_amount"))
                        If Not trow.IsNull("check_wht") Then whtamnt += CDec(trow("check_wht"))
                    End If
                End If
            Next
            If totalamnt > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "H5.6"
                ji.Amount = totalamnt - whtamnt
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' Cr. ภาษีหัก ณ ที่จ่าย H5.7 
        Private Sub SetGLH5_7(ByVal jiColl As JournalEntryItemCollection)
            Dim whtamnt As Decimal
            For Each trow As TreeRow In Me.ItemTable.Childs
                If ValidateRow(trow) Then
                    If Not trow.IsNull("check_wht") _
                    AndAlso CInt(trow("check_wht")) > 0 Then
                        whtamnt += CDec(trow("check_wht"))
                    End If
                End If
            Next
            Me.WHT = whtamnt
            Dim ji As New JournalEntryItem
            If Me.WHT > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "H5.7"
                ji.Amount = Me.WHT
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' Cr. เช็ครับรอนำฝาก H5.8  -- ในมือเท่านั้น
        Private Sub SetGLH5_8(ByVal jiColl As JournalEntryItemCollection)
            Dim ji As New JournalEntryItem
            Dim ht As New Hashtable
            Dim totalamnt As Decimal
            Dim whtamnt As Decimal
            For Each trow As TreeRow In Me.ItemTable.Childs
                If ValidateRow(trow) Then
                    If Not trow.IsNull("cqupdatei_beforestatus") _
                    AndAlso CInt(trow("cqupdatei_beforestatus")) = 1 Then
                        totalamnt += CDec(trow("check_amount"))
                        If Not trow.IsNull("check_wht") Then whtamnt += CDec(trow("check_wht"))
                    End If
                End If
            Next
            If totalamnt > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "H5.8"
                ji.Amount = totalamnt - whtamnt
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' DR. ลกหนี้การค้า H5.5
        ' Cr. เช็ครอเรียกเก็บ H5.6   -- นำฝากเท่านั้น
        ' Cr. ภาษีหัก ณ ที่จ่าย H5.7 
        ' Cr. เช็ครับรอนำฝาก H5.8  -- ในมือเท่านั้น
        Private Sub SetGLH5_5_5_8(ByVal jiColl As JournalEntryItemCollection)
            Dim ji As New JournalEntryItem
            For Each row As TreeRow In Me.ItemTable.Childs
                Dim sumvalNoneAcct As Decimal = 0
                Dim sumvalInAcct As Decimal = 0
                If ValidateRow(row) Then
                    ' DR. ลกหนี้การค้า H5.5
                    Dim cust As New Customer(CInt(row("check_customer")))
                    ji = New JournalEntryItem
                    ji.Mapping = "Through"
                    ji.IsDebit = True
                    ji.Amount = CDec(row("check_amount"))
                    If Not cust.Account Is Nothing AndAlso cust.Account.Originated Then
                        ji.Account = cust.Account
                    End If
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    jiColl.Add(ji)

                    ' Cr. เช็ครอเรียกเก็บ H5.6   -- นำฝากเท่านั้น
                    If Not row.IsNull("cqupdatei_beforestatus") AndAlso CInt(row("cqupdatei_beforestatus")) = 3 Then
                        Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckUnCollected)
                        ji = New JournalEntryItem
                        ji.Mapping = "Through"
                        ji.IsDebit = False
                        ji.Amount = CDec(row("check_amount"))
                        If Not row.IsNull("check_wht") Then
                            ji.Amount -= CDec(row("check_wht"))
                        End If
                        ji.Account = ga.Account
                        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                        jiColl.Add(ji)
                    End If

                    ' Cr. ภาษีหัก ณ ที่จ่าย H5.7 
                    If Not row.IsNull("check_wht") AndAlso CInt(row("check_wht")) > 0 Then
                        Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.WitholdingTaxOut)
                        ji = New JournalEntryItem
                        ji.Mapping = "Through"
                        ji.IsDebit = False
                        ji.Amount = CDec(row("check_wht"))
                        ji.Account = ga.Account
                        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                        jiColl.Add(ji)
                    End If

                    ' Cr. เช็ครับรอนำฝาก H5.8  -- ในมือเท่านั้น
                    If Not row.IsNull("cqupdatei_beforestatus") AndAlso CInt(row("cqupdatei_beforestatus")) = 1 Then
                        Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckUnPayin)
                        ji = New JournalEntryItem
                        ji.Mapping = "Through"
                        ji.IsDebit = False
                        ji.Amount = CDec(row("check_amount"))
                        If Not row.IsNull("check_wht") Then
                            ji.Amount -= CDec(row("check_wht"))
                        End If
                        ji.Account = ga.Account
                        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                        jiColl.Add(ji)
                    End If
                End If
            Next

        End Sub
        ' Dr. เช็ครับรอนำฝาก H5.9
        Private Sub SetGLH5_9(ByVal jiColl As JournalEntryItemCollection)
            Dim ji As New JournalEntryItem
            ji = New JournalEntryItem
            ji.Mapping = "H5.9"
            ji.Amount = Me.TotalAmount
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            jiColl.Add(ji)
        End Sub
        ' Cr. เช็ครอเรียกเก็บ H5.10
        Private Sub SetGLH5_10(ByVal jiColl As JournalEntryItemCollection)
            Dim ji As New JournalEntryItem
            ji = New JournalEntryItem
            ji.Mapping = "H5.10"
            ji.Amount = Me.TotalAmount
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            jiColl.Add(ji)
        End Sub
        ' Dr. เช็ครับรอนำฝาก H5.9
        ' Cr. เช็ครอเรียกเก็บ H5.10
        Private Sub SetGLH5_9_5_10(ByVal jiColl As JournalEntryItemCollection)
            Dim ji As New JournalEntryItem
            For Each row As TreeRow In Me.ItemTable.Childs
                Dim sumvalNoneAcct As Decimal = 0
                Dim sumvalInAcct As Decimal = 0
                If ValidateRow(row) Then
                    Dim ga As GeneralAccount
                    If Not row.IsNull("check_amount") Then
                        ' Dr. เช็ครับรอนำฝาก H5.9
                        ga = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckUnPayin)
                        ji = New JournalEntryItem
                        ji.Mapping = "Through"
                        ji.IsDebit = True
                        ji.Amount = CDec(row("check_amount"))
                        ji.Account = ga.Account
                        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                        jiColl.Add(ji)

                        ' Cr. เช็ครอเรียกเก็บ H5.10
                        ga = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckUnCollected)
                        ji = New JournalEntryItem
                        ji.Mapping = "Through"
                        ji.IsDebit = False
                        ji.Amount = CDec(row("check_amount"))
                        ji.Account = ga.Account
                        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                        jiColl.Add(ji)
                    End If
                End If
            Next

        End Sub

        Private Function GetTotalAmount() As Decimal
            Dim totalamnt As Decimal
            For Each row As TreeRow In Me.ItemTable.Childs
                If ValidateRow(row) Then
                    If Not row.IsNull("check_amount") Then
                        totalamnt += CDec(row("check_amount"))
                    End If
                End If
            Next
            Return totalamnt
        End Function

        Private Function GetBankChargeAmount() As Decimal
            Dim bankcharge As Decimal
            For Each row As TreeRow In Me.ItemTable.Childs
                If ValidateRow(row) Then
                    If Not row.IsNull("check_bankcharge") Then
                        bankcharge += CDec(row("check_bankcharge"))
                    End If
                End If
            Next
            Return bankcharge
        End Function

        Private Function GetWHTAmount() As Decimal
            Dim wht As Decimal
            For Each row As TreeRow In Me.ItemTable.Childs
                If ValidateRow(row) Then
                    If Not row.IsNull("check_wht") Then
                        wht += CDec(row("check_wht"))
                    End If
                End If
            Next
            Return wht
        End Function

        Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
            Get
                Return Me.m_je
            End Get
            Set(ByVal Value As JournalEntry)
                Me.m_je = Value
            End Set
        End Property


#End Region

#Region " IWitholdingTaxable "
        Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
            Return Me.TotalAmount
        End Function

        Private m_saving As Boolean = False
        Public Property Person() As IBillablePerson Implements IWitholdingTaxable.Person
            Get
                If Not m_saving Then
                    m_ibillableperson = GetPersonItem()
                End If
                Return m_ibillableperson
            End Get
            Set(ByVal Value As IBillablePerson)
                m_ibillableperson = Value
            End Set
        End Property

        Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
            Get
                Return m_whtcol
            End Get
            Set(ByVal Value As WitholdingTaxCollection)
                m_whtcol = Value
            End Set
        End Property

        Private Function GetPersonItem() As IBillablePerson
            Dim totalamnt As Decimal
            For Each row As TreeRow In Me.ItemTable.Childs
                If ValidateRow(row) Then
                    If Not row.IsNull("bankacct_name") _
                    AndAlso Not row.IsNull("check_wht") Then
                        Dim incomCHK As New IncomingCheck(CInt(row("cqupdatei_entity")))
                        Dim ba As New Bank
                        If incomCHK.BankAccount Is Nothing Then
                            Return New BankBranch
                        Else
                            Return incomCHK.BankAccount.BankBranch
                        End If
                    End If
                End If
            Next
            Return New BankBranch
        End Function
#End Region

#Region "Delete"
        Public ReadOnly Property GetIsChildsReferenced() As String
            Get
                If Me.Originated Then
                    Dim Referenced As String = ""
                    For Each row As TreeRow In Me.m_itemTable.Childs
                        If Me.ValidateRow(row) Then
                            Dim item As New UpdateCheckReceiveItem
                            item.CopyFromDataRow(row)
                            '0=ยกเลิก , 1=เช็คในมือ , 2=เช็คผ่าน , 3=เช็คนำฝาก , 4=เช็คขายลด , 5=เช็คคืน , 6=เปลี่ยนเช็ครับ
                            If Not item.Entity Is Nothing AndAlso item.Entity.DocStatus.Value <> Me.UpdatedStatus.Value Then
                                If Referenced.Length > 0 Then
                                    Referenced += "," & item.Entity.Code
                                Else
                                    Referenced = item.Entity.Code
                                End If
                            End If
                        End If
                    Next
                    Return Referenced
                End If
            End Get
        End Property

        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                If Me.Originated Then
                    Return Me.Status.Value <= 2
                Else
                    Return False
                End If
            End Get
        End Property
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("${res:Global.Error.NoIdError}")
            End If
            ' ตรวจสอบ Childs ที่อ้างอิงแล้ว.
            Dim referedcodelist As String = GetIsChildsReferenced()
            If referedcodelist.Length > 0 Then
                Dim strPare As String = Me.StringParserService.Parse("${res:Global.UpdateCheckReceiveReferedList}")
                Return New SaveErrorException(String.Format(strPare, referedcodelist))
            End If

            Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim format(0) As String
            format(0) = Me.Code
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteUpdateCheckReceive}", format) Then
                Return New SaveErrorException("${res:Global.CencelDelete}")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try

                UpdateOldItemStatus(conn, trans, True)

                m_incomingcheckremoved = ""
                For Each tr As TreeRow In Me.ItemTable.Childs
                    If Me.ValidateRow(tr) Then
                        If tr.Table.Columns.Contains("cqupdatei_entity") AndAlso Not tr.IsNull("cqupdatei_entity") Then
                            m_incomingcheckremoved += "|" & CInt(tr("cqupdatei_entity")) & "|"
                        End If
                    End If
                Next

                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteUpdateCheckReceive", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.UpdateCheckReceiveIsReferencedCannotBeDeleted}")
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Return New SaveErrorException(returnVal.Value.ToString)
                End If

                trans.Commit()
                m_incomingcheckremoved = ""
                Return New SaveErrorException("1")
            Catch ex As SqlException
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Finally
                conn.Close()
            End Try
        End Function
#End Region

    End Class

    ' Update check items
    Public Class UpdateCheckReceiveItem

#Region "Members"
        Private m_updatecheckReceive As UpdateCheckReceive
        Private m_lineNumber As Integer
        Private m_entity As IncomingCheck
        Private m_beforestatus As IncomingCheckDocStatus
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                ' Line number ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_linenumber") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_linenumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & Me.Prefix & "_linenumber"))
                End If
                ' Entity ...
                If dr.Table.Columns.Contains(aliasPrefix & "check_id") AndAlso Not dr.IsNull(aliasPrefix & "check_id") Then
                    .m_entity = New IncomingCheck(dr, aliasPrefix)
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
                        .m_entity = New IncomingCheck(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
                    End If
                End If
                ' before status ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_beforestatus") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_beforestatus") Then
                    .m_beforestatus = New IncomingCheckDocStatus(CInt(dr(aliasPrefix & Me.Prefix & "_beforestatus")))
                End If
            End With
        End Sub
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Private ReadOnly Property Prefix() As String
            Get
                Return "cqupdatei"
            End Get
        End Property

        Public Property UpdateCheckReceive() As UpdateCheckReceive            Get                Return m_updatecheckReceive            End Get            Set(ByVal Value As UpdateCheckReceive)                m_updatecheckReceive = Value            End Set        End Property
        Public Property BeforeStatus() As IncomingCheckDocStatus            Get
                Return m_beforestatus
            End Get
            Set(ByVal Value As IncomingCheckDocStatus)
                m_beforestatus = Value
            End Set
        End Property        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property Entity() As IncomingCheck            Get                Return m_entity            End Get            Set(ByVal Value As IncomingCheck)                m_entity = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Me.UpdateCheckReceive.IsInitialized = False
            row("linenumber") = Me.LineNumber
            If Not Me.Entity Is Nothing Then

                row("cqupdatei_entity") = Me.Entity.Id
                row("code") = Me.Entity.Code
                row("cqcode") = Me.Entity.CqCode
                row("docdate") = Me.Entity.ReceiveDate

                row("check_id") = Me.Entity.Id
                row("check_code") = Me.Entity.Code
                row("check_cqcode") = Me.Entity.CqCode
                row("check_receivedate") = Me.Entity.ReceiveDate
                row("check_duedate") = Me.Entity.DueDate

                If Not Me.Entity.ReceivePerson Is Nothing Then
                    row("recipient") = Me.Entity.ReceivePerson.Name
                    row("check_receiveperson") = Me.Entity.ReceivePerson.Id
                End If

                If Not Me.Entity.Customer Is Nothing Then row("check_customer") = Me.Entity.Customer.Id

                If Not Me.Entity.Bank Is Nothing Then
                    row("bank_id") = Me.Entity.Bank.Id
                    row("bank_code") = Me.Entity.Bank.Code
                    row("bank_name") = Me.Entity.Bank.Name
                    row("check_bank") = Me.Entity.Bank.Id
                End If

                If Not Me.Entity.BankAccount Is Nothing Then
                    row("bankacct_id") = Me.Entity.BankAccount.Id
                    row("check_bankacct") = Me.Entity.BankAccount.Id
                    row("bankacct_code") = Me.Entity.BankAccount.Code
                    row("bankacct_name") = Me.Entity.BankAccount.Name
                End If

                row("check_amount") = Me.Entity.Amount
                row("cqupdatei_beforestatus") = Me.BeforeStatus.Value
                row("check_lastestdocstatus") = Me.Entity.DocStatus.Description

                '---------------------------------------------------------
                'เหน่งลืมพวกนี้นะ !!!
                'row("check_payer") = ???
                row("check_docstatus") = Me.Entity.DocStatus.Value
                row("check_status") = Me.Entity.Status.Value
                '-----------------------------------------------------------------

                row("check_bankcharge") = Me.Entity.BankCharge
                row("check_wht") = Me.Entity.WHT
                row("check_amt") = Me.Entity.Amount
                row("check_note") = Me.Entity.Note
            Else
                row("cqupdatei_entity") = DBNull.Value
                row("code") = DBNull.Value
                row("cqcode") = DBNull.Value
                row("docdate") = DBNull.Value
                row("recipient") = DBNull.Value

                row("bankacct_id") = DBNull.Value
                row("bankacct_code") = DBNull.Value
                row("bankacct_name") = DBNull.Value

                row("bank_id") = DBNull.Value
                row("bank_code") = DBNull.Value
                row("bank_name") = DBNull.Value

                row("check_amount") = DBNull.Value
                row("cqupdatei_beforestatus") = DBNull.Value
                row("check_lastestdocstatus") = DBNull.Value
                ' ---
                row("check_id") = DBNull.Value
                row("check_code") = DBNull.Value
                row("check_cqcode") = DBNull.Value
                row("check_receivedate") = DBNull.Value
                row("check_duedate") = DBNull.Value
                row("check_receiveperson") = DBNull.Value
                row("check_customer") = DBNull.Value
                row("check_payer") = DBNull.Value
                row("check_bankacct") = DBNull.Value
                row("check_bank") = DBNull.Value
                row("check_bankcharge") = DBNull.Value
                row("check_wht") = DBNull.Value
                row("check_amt") = DBNull.Value
                row("check_note") = DBNull.Value
                row("check_docstatus") = DBNull.Value
                row("check_status") = DBNull.Value

            End If

            Me.UpdateCheckReceive.IsInitialized = True
        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Try
                ' Line number ...
                If Not row.IsNull(("linenumber")) Then
                    Me.LineNumber = CInt(row("linenumber"))
                End If
                ' Entity ...
                If row.Table.Columns.Contains("check_id") AndAlso Not row.IsNull("check_id") Then
                    Me.Entity = New IncomingCheck(row, "")
                Else
                    If row.Table.Columns.Contains("cqupdatei_entity") AndAlso Not row.IsNull(("cqupdatei_entity")) Then
                        Me.Entity = New IncomingCheck(CInt(row("cqupdatei_entity")))
                    End If
                End If

                If row.Table.Columns.Contains("cqupdatei_beforestatus") _
                    AndAlso Not row.IsNull(("cqupdatei_beforestatus")) Then
                    Me.BeforeStatus = New IncomingCheckDocStatus(CInt(row("cqupdatei_beforestatus")))
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

    End Class

End Namespace
