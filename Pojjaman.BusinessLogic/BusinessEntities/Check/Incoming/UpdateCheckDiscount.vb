Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class UpdateCheckDiscount
        Inherits SimpleBusinessEntityBase
    Implements IGLAble, ICheckPeriod



#Region "Member"
        Private m_totalamount As Decimal
        Private m_gross As Decimal
        Private m_wht As Decimal
        Private m_bankcharge As Decimal

        Private m_bankacct As BankAccount
        Private m_issuedate As Date
        Private m_note As String

        Private m_updatedstatus As IncomingCheckDocStatus

        Private m_itemTable As TreeTable

        Private m_je As JournalEntry
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
                .m_bankacct = New BankAccount
                .m_updatedstatus = New IncomingCheckDocStatus(4)    ' เช็คขายลด ...
                .Status = New CheckStatus(-1)
                .m_je = New JournalEntry(Me)
                .m_je.DocDate = Me.m_issuedate
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
                ' bank charge ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankcharge") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankcharge") Then
                    .m_bankcharge = CDec(dr(aliasPrefix & Me.Prefix & "_bankcharge"))
                End If
                ' gross ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_gross") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_gross") Then
                    .m_gross = CDec(dr(aliasPrefix & Me.Prefix & "_gross"))
                End If
                ' tax amount ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_wht") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_wht") Then
                    .m_wht = CDec(dr(aliasPrefix & Me.Prefix & "_wht"))
                End If

                ' Issuedate ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_issuedate") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_issuedate") Then
                    .m_issuedate = CDate(dr(aliasPrefix & Me.Prefix & "_issuedate"))
                End If
                ' Note ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If
                ' BankAccount
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankacct") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankacct") Then
                    .m_bankacct = New BankAccount(CInt(dr(aliasPrefix & Me.Prefix & "_bankacct")))
                End If
                ' Total amount ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_totalamount") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_totalamount") Then
                    .m_totalamount = CInt(dr(aliasPrefix & Me.Prefix & "_totalamount"))
                End If
                ' check status 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_updatedstatus") _
                  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_updatedstatus") Then
                    m_updatedstatus.Value = CInt(dr(aliasPrefix & Me.Prefix & "_updatedstatus"))
                End If

                ' Status 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
                  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
                    Me.Status.Value = CInt(dr(aliasPrefix & Me.Prefix & "_status"))
                End If

                .m_je = New JournalEntry(Me)
            End With
        End Sub

#End Region

#Region "Properties"
        Public Property BankCharge() As Decimal
            Get
                Return m_bankcharge
            End Get
            Set(ByVal Value As Decimal)
                m_bankcharge = Value
            End Set
        End Property
        Public Property GrossAmount() As Decimal
            Get
                Return m_gross
            End Get
            Set(ByVal Value As Decimal)
                m_gross = Value
            End Set
        End Property
        Public Property WHT() As Decimal
            Get
                Return m_wht
            End Get
            Set(ByVal Value As Decimal)
                m_wht = Value
            End Set
        End Property
    Public Property IssueDate() As Date Implements ICheckPeriod.DocDate
      Get
        Return m_issuedate
      End Get
      Set(ByVal Value As Date)
        m_issuedate = Value
      End Set
    End Property
    Public Property BankAccount() As BankAccount
      Get
        Return m_bankacct
      End Get
      Set(ByVal Value As BankAccount)
        m_bankacct = Value
      End Set
    End Property
    Public Property TotalAmount() As Decimal
      Get
        Return m_totalamount
      End Get
      Set(ByVal Value As Decimal)
        m_totalamount = Value
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
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public ReadOnly Property CheckRemovedInItemTable() As String
      Get
        Return m_incomingcheckremoved
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
                Return "UpdateCheckDiscount"
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
                Return "${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckDiscount.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.UpdateCheckDiscount"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.UpdateCheckDiscount"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckDiscount.ListLabel}"
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
            
            myDatatable.Columns.Add(New DataColumn("cqupdatei_entity", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("cqupdatei_beforestatus", GetType(Integer)))

            ' bank
            myDatatable.Columns.Add(New DataColumn("bank_id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("bank_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bank_name", GetType(String)))

            ' bank account
            myDatatable.Columns.Add(New DataColumn("bankacct_id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("bankacct_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bankacct_name", GetType(String)))

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
            myDatatable.Columns.Add(New DataColumn("check_amount", GetType(Decimal)))
            myDatatable.Columns.Add(New DataColumn("check_note", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_docstatus", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_status", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_lastestdocstatus", GetType(String)))

            Return myDatatable
        End Function
#End Region

#Region "Methods"
        Public Function TotalItemTableAmount() As Decimal
            Dim totalamt As Decimal = 0
            For Each tr As TreeRow In Me.ItemTable.Childs
                If Me.ValidateRow(tr) AndAlso Not tr.IsNull("check_amount") Then
                    totalamt += CDec(tr("check_amount"))
                End If
            Next
            m_gross = totalamt
            Return totalamt
        End Function
        Private Sub ResetID(ByVal oldid As Integer, ByVal oldje As Integer)
            Me.Id = oldid
            Me.m_je.Id = oldje
    End Sub

    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException
      Dim ValidateError As SaveErrorException

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      Return New SaveErrorException("0")

    End Function

        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                If .MaxRowIndex < 0 Then 'ItemTable.Childs.Count = 0 Then
                    Return New SaveErrorException(.StringParserService.Parse("${res:Global.Error.NoItem}"))
                End If
                If Me.TotalAmount <= 0 Then  ' ยอดเป็นศูนย์
                    Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", _
                    "${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblTotalamnt}")
                End If
                If Me.TotalAmount > Me.GrossAmount Then  ' ยอดรับเกินกำหนด
                    Return New SaveErrorException("${res:Global.Error.BalanceError}", _
                    "${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblTotalamnt}", Me.TotalAmount.ToString, _
                    "${res:Longkong.Pojjaman.Gui.Panels.UpdateDiscountCheckDetail.lblSumTotal}", Me.GrossAmount.ToString)
                End If


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

                If Me.m_je.Status.Value = 4 Then
                    Me.Status.Value = 4
                End If

                If Me.Status.Value = -1 Then
                    Me.Status.Value = 2
                End If

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_code", .Code))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_issuedate", ValidDateOrDBNull(.IssueDate)))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_checktype", (New IncomingCheck).EntityId))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_note", .Note))

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_updatedstatus", .UpdatedStatus.Value))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_status", .Status.Value))

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_bankacct", ValidIdOrDBNull(Me.BankAccount)))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_bankcharge", Me.BankCharge))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_gross", Me.GrossAmount))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_wht", Me.WHT))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_totalamount", Me.TotalAmount))


                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
        Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
        If Not IsNumeric(ValidateError2.Message) Then
          Return ValidateError2
        End If
        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(.ConnectionString)

                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                trans = conn.BeginTransaction()

                Dim oldid As Integer = Me.Id
                Dim oldje As Integer = m_je.Id

                Try
                    .ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

                    If IsNumeric(returnVal.Value) Then
                        Select Case CInt(returnVal.Value)
                            Case -1, -2, -5
                                trans.Rollback()
                                Me.ResetID(oldid, oldje)
                                Return New SaveErrorException(returnVal.Value.ToString)
                            Case Else
                        End Select
                    ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                        trans.Rollback()
                        Me.ResetID(oldid, oldje)
                        Return New SaveErrorException(returnVal.Value.ToString)
                    End If

                    Dim saveDetailError As SaveErrorException = SaveDetail(.Id, conn, trans)
                    If Not IsNumeric(saveDetailError.Message) OrElse CInt(saveDetailError.Message) < 0 Then
                        trans.Rollback()
                        Return saveDetailError
                    End If

                    ' Save GL

                    If Me.m_je.Status.Value = -1 Then
                        m_je.Status.Value = 3
                    End If
                    Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
                    If Not IsNumeric(saveJeError.Message) Then
                        trans.Rollback()
                        ResetID(oldid, oldje)
                        Return saveJeError
                    Else
                        Select Case CInt(saveJeError.Message)
                            Case -1, -5
                                trans.Rollback()
                                ResetID(oldid, oldje)
                                Return saveJeError
                            Case -2
                                'Post ไปแล้ว
                                Return saveJeError
                            Case Else
                        End Select
                    End If

                    trans.Commit()
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
                    Return New SaveErrorException(ex.ToString)
                Finally
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
                        Dim item As TreeRow = Me.m_itemTable.Childs(n)
                        If ValidateRow(item) Then
                            i += 1
                            Dim dr As DataRow = .NewRow
                            dr("cqupdatei_cqupdateid") = Me.Id
                            dr("cqupdatei_linenumber") = i 'item("pri_linenumber")
                            dr("cqupdatei_entity") = item("cqupdatei_entity")
                            dr("cqupdatei_beforestatus") = item("cqupdatei_beforestatus")
                            .Rows.Add(dr)

                            ' update IncomingCheck ...
                            Dim checkid As Integer
                            If Not item.IsNull("cqupdatei_entity") Then
                                checkid = CInt(item("cqupdatei_entity"))
                            End If
                            UpdateCheckStatus(checkid, conn, trans)
                        End If
                    Next

                End With
                Dim dt As DataTable = ds.Tables("CheckUpdateItem")
                da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
                da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
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
                        If CInt(row("check_docstatus")) = 4 Then
                            row("check_docstatus") = 1
                        End If
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
                        If CInt(row("check_docstatus")) = 4 Then
                            row("check_docstatus") = 1
                        End If
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
                Dim item As New UpdateCheckDiscountItem(row, "")
                item.UpdateCheckDiscount = Me
                ' Hack : Huaneng ...
                Me.Add(item)
            Next
        End Sub
        Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            For Each dr As DataRow In ds.Tables(1).Rows
                Dim item As New UpdateCheckDiscountItem(dr, aliasPrefix)
                item.UpdateCheckDiscount = Me
                Me.Add(item)
            Next
        End Sub
        Public Sub AddBlankRow(ByVal count As Integer)
            For i As Integer = 0 To count - 1
                Dim newItem As New BlankItem("")
                Dim mtwItem As New UpdateCheckDiscountItem
                Me.ItemTable.AcceptChanges()
                Me.Add(mtwItem)
            Next
        End Sub
        Public Function Add(ByVal item As UpdateCheckDiscountItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.Add
            item.LineNumber = Me.ItemTable.Childs.Count
            item.UpdateCheckDiscount = Me
            item.CopyToDataRow(myRow)
            Return myRow
        End Function
        Public Function Insert(ByVal index As Integer, ByVal item As UpdateCheckDiscountItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
            item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
            item.UpdateCheckDiscount = Me
            item.CopyToDataRow(myRow)
            ReIndex(index + 1)
            ' Entity Dirty
            Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
            Me.OnPropertyChanged(Me, pe)
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
            Dim tr As TreeRow = Me.ItemTable.Childs(index)

            ' เก็บค่า Check ที่เคยอยู่ใน list แล้ว remove ออก
            If tr.Table.Columns.Contains("cqupdatei_entity") AndAlso Not tr.IsNull("cqupdatei_entity") Then
                m_incomingcheckremoved += "|" & CInt(tr("cqupdatei_entity")) & "|"
            End If

            Me.ItemTable.Childs.Remove(tr)
            ReIndex()
            ' Entity Dirty
            Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
            Me.OnPropertyChanged(Me, pe)

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
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetEntityValue(e)
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
                e.Row("bank_name") = entity.Bank.Name
                e.Row("check_amount") = entity.Amount
                e.ProposedValue = entity.Code
            Else
                e.Row("cqupdatei_entity") = DBNull.Value
                e.Row("docdate") = DBNull.Value
                e.Row("cqcode") = DBNull.Value
                e.Row("recipient") = DBNull.Value
                e.Row("bank_name") = DBNull.Value
                e.Row("check_amount") = DBNull.Value
                e.ProposedValue = DBNull.Value
            End If
            m_entitySetting = False
        End Sub
#End Region

#Region " IGLAble "
        Public Property [Date]() As Date Implements IGLAble.Date
            Get
                Return Me.IssueDate
            End Get
            Set(ByVal Value As Date)
                Me.IssueDate = Value
            End Set
        End Property

        Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                                                         , CommandType.StoredProcedure _
                                                         , "GetGLFormatForEntity" _
                                                         , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))

            Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
            Return glf
        End Function

        Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
            Dim jiColl As New JournalEntryItemCollection
            Dim ji As New JournalEntryItem

            If Me.TotalAmount > 0 Then
                ' Dr. เงินฝากธนาคาร    ji.Mapping = "H6.1"
                ji = New JournalEntryItem
                ji.Mapping = "H6.1"
                ji.Amount = Me.TotalAmount - Me.BankCharge
                If Me.BankAccount.Account.Originated Then
                    ji.Account = Me.BankAccount.Account
                End If
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
                ' Dr. ส่วนลดจ่าย
                If (Me.GrossAmount - Me.TotalAmount) > 0 Then
                    ji = New JournalEntryItem
                    ji.Mapping = "H6.2"
                    ji.Amount = Me.GrossAmount - Me.TotalAmount
                    'If Me.BankAccount.Account.Originated Then
                    '    ji.Account = Me.BankAccount.Account
                    'End If
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    jiColl.Add(ji)
                End If
                ' Dr. ค่าธรรมเนียมธนาคาร
                If Me.BankCharge > 0 Then
                    ji = New JournalEntryItem
                    ji.Mapping = "H6.3"
                    ji.Amount = Me.BankCharge
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    jiColl.Add(ji)
                End If
                ' CR. เช็ครับรอนำฝาก
                ji = New JournalEntryItem
                ji.Mapping = "H6.4"
                ji.Amount = Me.GrossAmount - Me.WHT
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
                ' CR. ภาษีหัก ณ ที่จ่าย
                If Me.WHT > 0 Then
                    ji = New JournalEntryItem
                    ji.Mapping = "H6.5"
                    ji.Amount = Me.WHT
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    jiColl.Add(ji)
                End If
            End If

            Return jiColl
        End Function
        Private Sub SetDrBankAccount(ByVal jiColl As JournalEntryItemCollection)

        End Sub
        Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
            Get
                Return Me.m_je
            End Get
            Set(ByVal Value As JournalEntry)
                Me.m_je = Value
            End Set
        End Property
#End Region

#Region "Delete"
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


            Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim format(0) As String
            format(0) = Me.Code
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteUpdateCheckDiscount}", format) Then
                Return New SaveErrorException("${res:Global.CencelDelete}")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try

                UpdateOldItemStatus(conn, trans, True)

                ' update item ที่อยู่ใน list ให้กลับเป็นสถานะเดิม
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteUpdateCheckDiscount", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.UpdateCheckDiscountIsReferencedCannotBeDeleted}")
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Return New SaveErrorException(returnVal.Value.ToString)
                End If



                trans.Commit()
                Return New SaveErrorException("1")
            Catch ex As SqlException
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Finally
                conn.Close()
                m_incomingcheckremoved = ""
            End Try
        End Function
#End Region

    
    End Class

    ' Update check items
    Public Class UpdateCheckDiscountItem

#Region "Members"
        Private m_UpdateCheckDiscount As UpdateCheckDiscount
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

        Public Property UpdateCheckDiscount() As UpdateCheckDiscount            Get                Return m_UpdateCheckDiscount            End Get            Set(ByVal Value As UpdateCheckDiscount)                m_UpdateCheckDiscount = Value            End Set        End Property
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
            Me.UpdateCheckDiscount.IsInitialized = False
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

                If Not Me.Entity.BankAccount Is Nothing Then
                    row("check_bankacct") = Me.Entity.BankAccount.Id
                    row("bankacct_id") = Me.Entity.BankAccount.Id
                    row("bankacct_code") = Me.Entity.BankAccount.Code
                    row("bankacct_name") = Me.Entity.BankAccount.Name
                End If


                If Not Me.Entity.Bank Is Nothing Then
                    row("check_bank") = Me.Entity.BankAccount.Id
                    row("bank_id") = Me.Entity.Bank.Id
                    row("bank_code") = Me.Entity.Bank.Code
                    row("bank_name") = Me.Entity.Bank.Name
                End If

                row("check_bankcharge") = Me.Entity.BankCharge
                row("check_wht") = Me.Entity.WHT
                row("check_amt") = Me.Entity.Amount
                row("check_amount") = Me.Entity.Amount
                row("check_note") = Me.Entity.Note

                row("check_docstatus") = Me.Entity.DocStatus.Value
                row("cqupdatei_beforestatus") = Me.Entity.DocStatus.Value

                row("check_status") = Me.Entity.Status.Value
            Else
                row("cqupdatei_entity") = DBNull.Value
                row("code") = DBNull.Value
                row("cqcode") = DBNull.Value
                row("docdate") = DBNull.Value
                row("recipient") = DBNull.Value
                row("cqupdatei_beforestatus") = DBNull.Value
                ' bank account
                row("bankacct_id") = DBNull.Value
                row("bankacct_code") = DBNull.Value
                row("bankacct_name") = DBNull.Value
                ' bank
                row("bank_id") = DBNull.Value
                row("bank_code") = DBNull.Value
                row("bank_name") = DBNull.Value
                ' incomingcheck
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
                row("check_amount") = DBNull.Value
                row("check_note") = DBNull.Value
                row("check_docstatus") = DBNull.Value
                row("check_status") = DBNull.Value
                row("check_lastestdocstatus") = DBNull.Value

            End If

            Me.UpdateCheckDiscount.IsInitialized = True
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
                    If row.Table.Columns.Contains("cqupdatei_entity") _
                        AndAlso Not row.IsNull(("cqupdatei_entity")) Then
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