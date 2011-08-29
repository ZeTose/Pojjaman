Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class UpdateCheckPayment
    Inherits SimpleBusinessEntityBase
    Implements IGLAble

#Region "Member"
    Private m_docdate As Date
    Private m_note As String

    Private m_updatedstatus As OutgoingCheckDocStatus
    Private m_totalamount As Decimal

    'Private m_itemTable As TreeTable

    Private m_je As JournalEntry

    Private m_OldListOfUpdateCheckPaymentItem As List(Of UpdateCheckPaymentItem)
    Private m_listOfUpdateCheckPaymentItem As List(Of UpdateCheckPaymentItem)

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      'ReLoadItems()
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
    End Sub
    Public Sub New(ByVal Code As String)
      MyBase.New(Code)
      'ReLoadItems()
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      'ReLoadItems()
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      'ReLoadItems(ds, aliasPrefix)
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      'ReLoadItems()
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docdate = Now.Date
        .m_updatedstatus = New OutgoingCheckDocStatus(1)
        .Status = New StockStatus(-1)
        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docdate
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      'ReLoadItems()
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged

      m_OldListOfUpdateCheckPaymentItem = New List(Of UpdateCheckPaymentItem)
      m_listOfUpdateCheckPaymentItem = New List(Of UpdateCheckPaymentItem)
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
          .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_issuedate"))
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
        ' check status
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_updatedstatus") _
          AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_updatedstatus") Then
          m_updatedstatus.Value = CInt(dr(aliasPrefix & Me.Prefix & "_updatedstatus"))
        End If
        ' updatecheck status 
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
          AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          Status.Value = CInt(dr(aliasPrefix & Me.Prefix & "_status"))
        End If

        .m_je = New JournalEntry(Me)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)

      m_OldListOfUpdateCheckPaymentItem = New List(Of UpdateCheckPaymentItem)
      m_listOfUpdateCheckPaymentItem = New List(Of UpdateCheckPaymentItem)
      LoadItems()

      Me.LoadNextCheckUpdateStatus()
    End Sub

#End Region

#Region "Properties"
    Public Property CurrentItem() As UpdateCheckPaymentItem
    Public Property ListOfUpdateCheckPaymentItem As List(Of UpdateCheckPaymentItem)
      Get
        Return m_listOfUpdateCheckPaymentItem
      End Get
      Set(ByVal value As List(Of UpdateCheckPaymentItem))
        m_listOfUpdateCheckPaymentItem = value
      End Set
    End Property
    Public ReadOnly Property NextCheckUpdateStatus As Hashtable
      Get
        Return m_hashCheckUpdateStatus
      End Get
    End Property
    Public Property DocDate() As Date
      Get
        Return m_docdate
      End Get
      Set(ByVal Value As Date)
        m_docdate = Value
        Me.m_je.DocDate = Value
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
    Public Property UpdatedStatus() As OutgoingCheckDocStatus
      Get
        Return m_updatedstatus
      End Get
      Set(ByVal Value As OutgoingCheckDocStatus)
        m_updatedstatus = Value
      End Set
    End Property
    'Public Property ItemTable() As TreeTable
    '  Get
    '    Return m_itemTable
    '  End Get
    '  Set(ByVal Value As TreeTable)
    '    m_itemTable = Value
    '  End Set
    'End Property

#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "updatecheckpayment"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckPayment.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.UpdateCheckPayment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.UpdateCheckPayment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckPayment.ListLabel}"
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

      ' Bank Account 
      myDatatable.Columns.Add(New DataColumn("bankacct_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("bankacct_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("bankacct_name", GetType(String)))

      ' Bank
      myDatatable.Columns.Add(New DataColumn("bank_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("bank_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("bank_name", GetType(String)))

      ' Outgoing Check
      myDatatable.Columns.Add(New DataColumn("check_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("check_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("check_cqcode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("check_issuedate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("check_supplier", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("check_recipient", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("check_amt", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("check_amount", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("check_bankcharge", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("check_wht", GetType(Decimal)))

      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private m_hashCheckUpdateStatus As Hashtable
    Private Sub LoadNextCheckUpdateStatus()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, _
                                                  CommandType.StoredProcedure, _
                                                  "GetNextUpdateCheckStatus", _
                                                  New SqlParameter("@cqupdate_id", Me.Id))
      m_hashCheckUpdateStatus = New Hashtable
      For Each row As DataRow In ds.Tables(0).Rows
        m_hashCheckUpdateStatus(CInt(row("cqupdatei_entity"))) = row
      Next
    End Sub
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_je.Id = oldje
    End Sub
    Private Function ValidateBank() As SaveErrorException

      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If (Not item.Entity Is Nothing AndAlso
            (item.Entity.Bankacct Is Nothing OrElse Not item.Entity.Bankacct.Originated)) Then
          Dim str As String = ""
          If Not item.Entity.CqCode.Length = 0 Then
            str = item.Entity.CqCode
          End If

          str = String.Format(StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckPayment.BankIsNotSpecification}"), str)

          Return New SaveErrorException(str)
        End If
      Next

      'For Each row As TreeRow In Me.ItemTable.Childs
      '  If ValidateRow(row) Then
      '    If row.IsNull("bankacct_code") OrElse CStr(row("bankacct_code")).Length = 0 Then
      '      Dim str As String = ""
      '      If Not row.IsNull("cqcode") Then
      '        str = CStr(row("cqcode"))
      '      End If

      '      str = String.Format(StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckPayment.BankIsNotSpecification}"), str)

      '      Return New SaveErrorException(str)
      '    End If
      '  End If

      'Next

      Return New SaveErrorException("0")

    End Function

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
        If .ListOfUpdateCheckPaymentItem.Count < 0 Then '.ItemTable.Childs.Count = 0 Then
          Return New SaveErrorException(.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If

        If Me.UpdatedStatus.Value = 2 Then
          Dim isBankValid As SaveErrorException = Me.ValidateBank
          If Not IsNumeric(isBankValid.Message) Then
            Return New SaveErrorException(isBankValid.Message)
          End If
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
        '---- AutoCode Format --------
        Me.m_je.RefreshGLFormat()
        If Not AutoCodeFormat Is Nothing Then

          Select Case Me.AutoCodeFormat.CodeConfig.Value
            Case 0
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.DontSave = True
              Me.m_je.Code = ""
              Me.m_je.DocDate = Me.DocDate
            Case 1
              'ตาม entity
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.Code = Me.Code
            Case 2
              'ตาม gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
            Case Else
              'แยก
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.RefreshGLFormat()
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.RefreshGLFormat()
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        Me.m_je.DocDate = Me.DocDate
        Me.AutoGen = False
        Me.m_je.AutoGen = False

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_code", .Code))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_issuedate", ValidDateOrDBNull(.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_checktype", (New OutgoingCheck).EntityId))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_totalamount", .TotalAmount))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_note", .Note))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_updatedstatus", .UpdatedStatus.Value))

        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_status", .Status.Value))

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
        Dim oldje As Integer = Me.m_je.Id

        Try

          Try
            .ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
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

            Dim saveDetailError As SaveErrorException = SaveDetail(.Id, conn, trans)
            If Not IsNumeric(saveDetailError.Message) OrElse CInt(saveDetailError.Message) < 0 Then
              trans.Rollback()
              Return saveDetailError
            End If

            ''Me.DeleteRef(conn, trans)
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateCheck_PaymentRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            'If Me.Status.Value = 0 Then
            '  Me.CancelRef(conn, trans)
            'End If

            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            End If
            Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveJeError.Message) Then
              trans.Rollback()
              Return saveJeError
            Else
              Select Case CInt(saveJeError.Message)
                Case -1, -5
                  trans.Rollback()
                  Return saveJeError
                Case -2
                  'Post ไปแล้ว
                  Return saveJeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================
            Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
            If Not IsNumeric(saveAutoCodeError.Message) Then
              trans.Rollback()
              ResetID(oldid, oldje)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid, oldje)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================

            trans.Commit()

          Catch ex As SqlException
            trans.Rollback()
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Return New SaveErrorException(ex.ToString)
            'Finally
            '  conn.Close()
          End Try

          '--Sub Save Block-- ============================================================== 
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If

          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try
          '--Sub Save Block-- ============================================================== 

          Return New SaveErrorException(returnVal.Value.ToString)
          'Complete Save
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try

      End With
    End Function

    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException
      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans As SqlTransaction = conn.BeginTransaction

      Try
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure,
                                  "UpdateCheck_PaymentRef",
                                  New SqlParameter("@refto_id", Me.Id)
                                  )
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure,
                                  "UpdateCheck_ItemsStatus",
                                  New SqlParameter("@listOfIds", Me.GetListIds),
                                  New SqlParameter("@listOfOldIds", Me.GetListOldIds),
                                  New SqlParameter("@docstatus", Me.UpdatedStatus.Value),
                                  New SqlParameter("@cqupdate_id", Me.Id)
                                  )

        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")

    End Function

    Private Function SaveDetail(ByVal parentID As Integer, _
                                ByVal conn As SqlConnection, _
                                ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from CheckUpdateItem where cqupdatei_cqupdateid = " & Me.Id, conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        da.Fill(ds, "CheckUpdateItem")

        'UpdateOldItemStatus(conn, trans)

        Dim i As Integer = 0
        With ds.Tables("CheckUpdateItem")
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          For Each item As UpdateCheckPaymentItem In Me.m_listOfUpdateCheckPaymentItem
            If Not item.Entity Is Nothing Then
              i += 1
              Dim dr As DataRow = .NewRow
              dr("cqupdatei_cqupdateid") = Me.Id
              dr("cqupdatei_linenumber") = i
              dr("cqupdatei_entity") = item.Entity.Id
              dr("cqupdatei_beforestatus") = item.BeforeStatus.Value 'item("cqupdatei_beforestatus")
              .Rows.Add(dr)

              '' update OutgoingCheck or IncomingCheck ...
              'Dim checkid As Integer
              'Dim bankcharge As Decimal
              'Dim wht As Decimal
              'If Not item.IsNull("cqupdatei_entity") Then
              '  checkid = CInt(item("cqupdatei_entity"))
              'End If
              'If Not item.IsNull("check_bankcharge") Then
              '  bankcharge = CDec(item("check_bankcharge"))
              'End If
              'If Not item.IsNull("check_wht") Then
              '  wht = CDec(item("check_wht"))
              'End If

              'If Not Me.ValidateItemByEntityId(CInt(item("cqupdatei_entity"))) Then
              '  UpdateCheckStatus(checkid, bankcharge, wht, conn, trans)
              'End If
            End If
          Next

          'For n As Integer = 0 To Me.MaxRowIndex
          '  Dim item As TreeRow = Me.m_itemTable.Childs(n)
          '  If ValidateRow(item) Then
          '    i += 1
          '    Dim dr As DataRow = .NewRow
          '    dr("cqupdatei_cqupdateid") = Me.Id
          '    dr("cqupdatei_linenumber") = i
          '    dr("cqupdatei_entity") = item("cqupdatei_entity")
          '    dr("cqupdatei_beforestatus") = item("cqupdatei_beforestatus")
          '    .Rows.Add(dr)

          '    ' update OutgoingCheck or IncomingCheck ...
          '    Dim checkid As Integer
          '    Dim bankcharge As Decimal
          '    Dim wht As Decimal
          '    If Not item.IsNull("cqupdatei_entity") Then
          '      checkid = CInt(item("cqupdatei_entity"))
          '    End If
          '    If Not item.IsNull("check_bankcharge") Then
          '      bankcharge = CDec(item("check_bankcharge"))
          '    End If
          '    If Not item.IsNull("check_wht") Then
          '      wht = CDec(item("check_wht"))
          '    End If

          '    If Not Me.ValidateItemByEntityId(CInt(item("cqupdatei_entity"))) Then
          '      UpdateCheckStatus(checkid, bankcharge, wht, conn, trans)
          '    End If

          '  End If

          'Next

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
      'Dim daOldRef As New SqlDataAdapter("select * from outgoingcheck " & _
      '"where check_id in (select cqupdatei_entity from CheckUpdateItem " & _
      '" where cqupdatei_cqupdateid =" & Me.Id & ")" & _
      '" and check_id in (select paymenti_entity from paymentitem " & _
      '" where paymenti_entitytype = 22 and paymenti_status <> 0)" _
      ', conn) '-----> มีใน checkupdate และ payment

      'Dim daOldStatusRef As New SqlDataAdapter("select * from outgoingcheck " & _
      '"where check_id in (select cqupdatei_entity from CheckUpdateItem " & _
      '" where cqupdatei_cqupdateid =" & Me.Id & ")" & _
      '" and check_id not in (select paymenti_entity from paymentitem " & _
      '" where paymenti_entitytype = 22 and paymenti_status <> 0) " _
      ', conn) '-----> มีใน checkupdate ไม่มีใน payment

      'Dim cmdBuilder As SqlCommandBuilder

      'Dim ds As New DataSet

      'cmdBuilder = New SqlCommandBuilder(daOldRef)
      'daOldRef.SelectCommand.Transaction = trans
      'cmdBuilder.GetDeleteCommand.Transaction = trans
      'cmdBuilder.GetInsertCommand.Transaction = trans
      'cmdBuilder.GetUpdateCommand.Transaction = trans
      'cmdBuilder = Nothing
      'daOldRef.Fill(ds, "OldCheck")

      'cmdBuilder = New SqlCommandBuilder(daOldStatusRef)
      'daOldStatusRef.SelectCommand.Transaction = trans
      'cmdBuilder.GetDeleteCommand.Transaction = trans
      'cmdBuilder.GetInsertCommand.Transaction = trans
      'cmdBuilder.GetUpdateCommand.Transaction = trans
      'cmdBuilder = Nothing
      'daOldStatusRef.Fill(ds, "OldCheckStatus")

      'Dim dtOldRef As DataTable = ds.Tables("OldCheck")
      'For Each row As DataRow In dtOldRef.Rows
      '  Dim found As Boolean = False
      '  For n As Integer = 0 To Me.MaxRowIndex
      '    Dim item As TreeRow = Me.m_itemTable.Childs(n)
      '    If ValidateRow(item) Then
      '      If IsNumeric(item("cqupdatei_entity")) AndAlso CInt(item("cqupdatei_entity")) = CInt(row("check_id")) Then
      '        'เจอแล้ว --> 
      '        found = True
      '        Exit For
      '      End If
      '    End If
      '  Next
      '  If (Not found) Or changeAll Then
      '    'ไม่เจอ -- 
      '    'แก้เฉพาะ docstatus เพราะมีอ้างอิงอยู่ที่อื่นด้วย
      '    If Not row.IsNull("check_docstatus") AndAlso IsNumeric(row("check_docstatus")) Then
      '      If CInt(row("check_docstatus")) = 2 Or CInt(row("check_docstatus")) = 0 Then
      '        row("check_docstatus") = 1
      '      End If
      '    End If
      '  End If
      'Next

      'Dim dtOldStatusRef As DataTable = ds.Tables("OldCheckStatus")
      'For Each row As DataRow In dtOldStatusRef.Rows
      '  Dim found As Boolean = False
      '  For n As Integer = 0 To Me.MaxRowIndex
      '    Dim item As TreeRow = Me.m_itemTable.Childs(n)
      '    If ValidateRow(item) Then
      '      If IsNumeric(item("cqupdatei_entity")) AndAlso CInt(item("cqupdatei_entity")) = CInt(row("check_id")) Then
      '        'เจอแล้ว --> 
      '        found = True
      '        Exit For
      '      End If
      '    End If
      '  Next
      '  If (Not found) Or changeAll Then
      '    'ไม่เจอ
      '    'แก้ทั้ง docstatus,status เพราะไม่มีอ้างอิงอยู่ที่อื่นด้วย
      '    If Not row.IsNull("check_status") AndAlso IsNumeric(row("check_status")) Then
      '      If CInt(row("check_status")) = 3 Then
      '        row("check_status") = 2
      '      End If
      '    End If
      '    If Not row.IsNull("check_docstatus") AndAlso IsNumeric(row("check_docstatus")) Then
      '      If CInt(row("check_docstatus")) = 2 Or CInt(row("check_docstatus")) = 0 Or CInt(row("check_docstatus")) = 3 Then
      '        row("check_docstatus") = 1
      '      End If
      '    End If
      '  End If
      'Next
      'daOldRef.Update(dtOldRef.Select(Nothing, Nothing, DataViewRowState.Deleted))
      'daOldRef.Update(dtOldRef.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      'daOldRef.Update(dtOldRef.Select(Nothing, Nothing, DataViewRowState.Added))

      'daOldStatusRef.Update(dtOldStatusRef.Select(Nothing, Nothing, DataViewRowState.Deleted))
      'daOldStatusRef.Update(dtOldStatusRef.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      'daOldStatusRef.Update(dtOldStatusRef.Select(Nothing, Nothing, DataViewRowState.Added))
    End Function
    Private Function UpdateCheckStatus(ByVal checkID As Integer, _
                                        ByVal bankcharge As Decimal, _
                                        ByVal wht As Decimal, _
                                        ByVal conn As SqlConnection, _
                                        ByVal trans As SqlTransaction) As Integer
      Dim sqlSelecttext As String

      sqlSelecttext = "Select * from OutgoingCheck Where check_id = " & checkID

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
          row("check_bankcharge") = bankcharge
          row("check_wht") = wht
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
    Public Function GetListIds() As String
      Dim idList As New ArrayList
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If item.Entity IsNot Nothing Then
          idList.Add(item.Entity.Id)
        End If
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
      Return ""
    End Function
    Public Function GetListOldIds() As String
      Dim idList As New ArrayList
      For Each item As UpdateCheckPaymentItem In Me.m_OldListOfUpdateCheckPaymentItem
        If item.Entity IsNot Nothing Then
          idList.Add(item.Entity.Id)
        End If
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
      Return ""
    End Function
#End Region

#Region "Items"
    Public Overloads Sub ReLoadItems()
      Me.IsInitialized = False
      'm_itemTable = GetSchemaTable()
      LoadItems()
      Me.LoadNextCheckUpdateStatus()
      Me.IsInitialized = True
    End Sub
    Public Overloads Sub ReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.IsInitialized = False
      'm_itemTable = GetSchemaTable()
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
        Dim item As New UpdateCheckPaymentItem(row, "")
        item.UpdateCheckPayment = Me
        ' Hack : Huaneng ...
        'Me.Add(item)
        m_OldListOfUpdateCheckPaymentItem.Add(item)
        m_listOfUpdateCheckPaymentItem.Add(item)
      Next
    End Sub
    Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      For Each dr As DataRow In ds.Tables(1).Rows
        Dim item As New UpdateCheckPaymentItem(dr, aliasPrefix)
        item.UpdateCheckPayment = Me
        'Me.Add(item)
        m_OldListOfUpdateCheckPaymentItem.Add(item)
        m_listOfUpdateCheckPaymentItem.Add(item)
      Next
    End Sub
    'Public Sub AddBlankRow(ByVal count As Integer)
    '  For i As Integer = 0 To count - 1
    '    Dim newItem As New BlankItem("")
    '    Dim mtwItem As New UpdateCheckPaymentItem
    '    Me.ItemTable.AcceptChanges()
    '    Me.Add(mtwItem)
    '  Next
    'End Sub
    'Public Function Add(ByVal item As UpdateCheckPaymentItem) As TreeRow
    '  Dim myRow As TreeRow = Me.ItemTable.Childs.Add
    '  item.LineNumber = Me.ItemTable.Childs.Count
    '  item.UpdateCheckPayment = Me
    '  item.CopyToDataRow(myRow)
    '  Return myRow
    'End Function
    'Public Function Insert(ByVal index As Integer, ByVal item As UpdateCheckPaymentItem) As TreeRow
    '  Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
    '  item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
    '  item.UpdateCheckPayment = Me
    '  item.CopyToDataRow(myRow)
    '  ReIndex(index + 1)
    '  Return myRow
    'End Function
    'Public Function MaxRowIndex() As Integer
    '  If Me.m_itemTable Is Nothing Then
    '    Return -1
    '  End If
    '  'ให้ index ของแถวสุดท้ายที่มีข้อมูล
    '  For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
    '    Dim row As TreeRow = Me.m_itemTable.Childs(i)
    '    If ValidateRow(row) Then
    '      Return i
    '    End If
    '  Next
    '  Return -1 'ไม่มีข้อมูลเลย
    'End Function
    'Public Sub Remove(ByVal index As Integer)
    '  Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  Dim row As TreeRow = Me.ItemTable.Childs(index)
    '  If Not row.IsNull("cqupdatei_entity") Then
    '    Dim entityId As Integer = CInt(row("cqupdatei_entity"))
    '    If Me.ValidateItemByEntityId(entityId) Then
    '      Dim cqCode As String = ""
    '      If Not row.IsNull("code") Then
    '        cqCode = CStr(row("code"))
    '      End If
    '      myMessage.ShowWarningFormatted("${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckPayment.CheckItemReferenced}", New String() {cqCode})
    '      Return
    '    End If
    '  End If

    '  Me.ItemTable.Childs.Remove(Me.ItemTable.Childs(index))
    '  ReIndex()
    'End Sub
    'Private Sub ReIndex()
    '  ReIndex(0)
    'End Sub
    'Private Sub ReIndex(ByVal index As Integer)
    '  If index < 0 OrElse index > Me.ItemTable.Childs.Count - 1 Then
    '    Return
    '  End If
    '  For i As Integer = index To Me.ItemTable.Childs.Count - 1
    '    Me.ItemTable.Childs(i)("linenumber") = i + 1
    '  Next
    'End Sub
#End Region

#Region "TreeTable Handlers"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        item.UpdateCheckPayment = Me
        item.LineNumber = i
        item.CopyToDataRow(newRow)
        'item.ItemValidateRow(newRow)
        newRow.Tag = item
      Next
    End Sub
    Public Sub SetItems(ByVal items As BasketItemCollection, ByVal index As Integer)
      For i As Integer = 0 To items.Count - 1
        If Not TypeOf items(i) Is StockBasketItem Then

          'Dim item As BasketItem = CType(items(i), BasketItem)
          'Dim newItem As IHasName
          'Dim newType As Integer = -1

          Dim newItem As New OutgoingCheck(CType(items(i), BasketItem).Id)

          Dim doc As New UpdateCheckPaymentItem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.Entity = newItem
            doc.BeforeStatus = New OutgoingCheckDocStatus(newItem.DocStatus.Value)
            Me.CurrentItem = Nothing
          Else
            If Me.ListOfUpdateCheckPaymentItem.Count < index Then
              Me.ListOfUpdateCheckPaymentItem.Add(doc)
            Else
              Me.ListOfUpdateCheckPaymentItem.Insert(index, doc)
            End If
            doc.Entity = newItem
            doc.BeforeStatus = New OutgoingCheckDocStatus(newItem.DocStatus.Value)
          End If
        End If
      Next
    End Sub
    'Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '  If Not Me.IsInitialized Then
    '    Return
    '  End If

    '  If Not e.Row.RowState = DataRowState.Detached Then
    '    e.Row.SetColumnError("Code", "")
    '  Else
    '    e.Row.SetColumnError("Code", Me.StringParserService.Parse("${res:Global.Error.GridHasNewLine}"))
    '    'If Not Me.m_validator Is Nothing Then
    '    '    Me.m_validator.HasNewRow = True
    '    'End If
    '  End If
    '  Me.m_itemTable.AcceptChanges()
    '  Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
    '  If index = Me.m_itemTable.Childs.Count - 1 Then

    '  End If
    '  Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
    '  Me.OnPropertyChanged(Me, pe)
    'End Sub
    'Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '  If Not Me.IsInitialized Then
    '    Return
    '  End If

    '  Dim proposedCode As Object = e.Row("Code")

    '  Try
    '    Select Case e.Column.ColumnName.ToLower
    '      Case "code"
    '        proposedCode = e.ProposedValue
    '        If Not proposedCode Is Nothing Then
    '          Dim entity As New OutgoingCheck(CStr(proposedCode))
    '          If entity.DocStatus.Value = 2 Then
    '            Dim msg As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '            msg.ShowWarningFormatted("${res:Global.EntityReferenced}", New String() {entity.Code})
    '            e.ProposedValue = ""
    '            Return
    '          End If
    '        End If

    '        SetEntityValue(e)
    '    End Select
    '    ValidateRow(e)
    '  Catch ex As Exception
    '    MessageBox.Show(ex.ToString)
    '  End Try
    'End Sub
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
      If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 OrElse Not IsNumeric(e.ProposedValue) Then
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
      Dim entity As New OutgoingCheck(e.ProposedValue.ToString)
      m_entitySetting = True
      If entity Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If entity.Originated Then
        e.Row("cqupdatei_entity") = entity.Id
        e.Row("docdate") = entity.IssueDate
        e.Row("cqcode") = entity.CqCode
        e.Row("recipient") = entity.Recipient
        e.Row("bankacct_code") = entity.Bankacct.Code
        e.Row("bankacct_name") = entity.Bankacct.Name
        e.Row("bank_name") = entity.Bankacct.BankBranch.Bank.Name
        e.Row("check_bankcharge") = entity.BankCharge
        e.Row("check_wht") = entity.WHT
        e.Row("check_amount") = entity.Amount
        e.ProposedValue = entity.Code
      Else
        e.Row("cqupdatei_entity") = DBNull.Value
        e.Row("docdate") = DBNull.Value
        e.Row("cqcode") = DBNull.Value
        e.Row("recipient") = DBNull.Value
        e.Row("bankacct_code") = DBNull.Value
        e.Row("bankacct_name") = DBNull.Value
        e.Row("bank_name") = DBNull.Value
        e.Row("check_bankcharge") = DBNull.Value
        e.Row("check_wht") = DBNull.Value
        e.Row("check_amount") = DBNull.Value
        e.ProposedValue = DBNull.Value
      End If
      m_entitySetting = False
    End Sub
#End Region

#Region " IGLAble "
    Public Property [Date]() As Date Implements IGLAble.Date
      Get
        Return Me.DocDate
      End Get
      Set(ByVal Value As Date)
        Me.DocDate = Value
      End Set
    End Property
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      ''Hack เอา Bug #859 เมนูปรับปรุงสถานะเช็คจ่าย หากเป็นเช็คยกเลิก การบันทึกบัญชีไม่ลงตามการเชื่อมบัญชี 
      '' เพราะ เป็นเอกสารที่มีสอง autorun อยู่แล้ว ถ้าต้องแก้จริงๆ คือ 1 Autorun ให้มีผลต่อ สถานะเช็คไปด้วยเลยก็จะยากขึ้น
      'If Me.UpdatedStatus.Value <> 0 Then
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      'End If

      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                  , CommandType.StoredProcedure _
                  , "GetGLFormatForEntity" _
                  , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))

      Dim glf As GLFormat
      If Me.UpdatedStatus.Value = 0 Then
        glf = New GLFormat(ds.Tables(0).Rows(1), "")
      ElseIf Me.UpdatedStatus.Value = 2 Then
        glf = New GLFormat(ds.Tables(0).Rows(0), "")
      Else
        glf = New GLFormat
      End If

      Return glf
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      Dim notCombine As Boolean = False 'ถ้าไม่ต้องการรวมยอดเช็คใน GL
      If Me.TotalAmount > 0 Then
        If notCombine Then
          If Me.UpdatedStatus.Value = 0 Then ' ยกเลิก { H2.3 , H2.4 }
            ' เช็คจ่ายล่วงหน้า {mix} ji.Mapping = "H2.3" สลับกับ เจ้าหนี้การค้า {mix} ji.Mapping = "H2.4"
            SetPassCheckOutgoingAndCreditor(jiColl)
          ElseIf Me.UpdatedStatus.Value = 2 Then ' จ่ายผ่าน  { H2.1 , H2.2 }
            ' เช็คจ่ายล่วงหน้า  {mix} ji.Mapping = "H2.1"  ตามเจ้าหนี้ สลับกับ เงินฝากธนาคาร {dynamic} ji.Mapping = "H2.2"
            SetCancelCheckOutgoingAndBankAcct(jiColl)
          End If
        Else
          If Me.UpdatedStatus.Value = 0 Then       ' ยกเลิก { H2.3 , H2.4 }
            ' เช็คจ่ายล่วงหน้า {mix}           ji.Mapping = "H2.3"
            SetCancelCheckOutgoing(jiColl)
            ' เงินฝากธนาคาร {dynamic}            ji.Mapping = "H2.4"
            'SetCancelBankAcct(jiColl)
            ' เจ้าหนี้การค้า {mix}
            SetCancelCreditor(jiColl)
          ElseIf Me.UpdatedStatus.Value = 2 Then    ' จ่ายผ่าน  { H2.1 , H2.2 }
            ' เช็คจ่ายล่วงหน้า  {mix}         ji.Mapping = "H2.1"  ตามเจ้าหนี้
            SetPassCheckOutgoing(jiColl)
            ' เจ้าหนี้การค้า {mix}       ji.Mapping = "H2.2"
            SetPassCreditor(jiColl)

          End If
        End If
      End If

      Return jiColl
    End Function
    ' เช็คจ่ายล่วงหน้า
    Private Sub SetPassCheckOutgoing(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '  If ValidateRow(trow) Then
      '    Dim bankacct As New BankAccount(CStr(trow("bankacct_code")))
      '    ht(bankacct.Account.Id) = bankacct.Account
      '  End If
      'Next
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If Not item.Entity Is Nothing AndAlso Not item.Entity.Bankacct Is Nothing AndAlso Not item.Entity.Bankacct.Account Is Nothing Then
          ht(item.Entity.Bankacct.Account.Id) = item.Entity.Bankacct.Account
        End If
      Next
      For Each acct As Account In ht.Values
        Dim sumvalue As Decimal = 0
        'For i As Integer = Me.MaxRowIndex To 0 Step -1
        '  Dim row As TreeRow = Me.ItemTable.Childs(i)
        '  If ValidateRow(row) Then
        '    Dim bankacct As New BankAccount(CStr(row("bankacct_code")))
        '    If bankacct.Account.Id = acct.Id Then
        '      sumvalue += CDec(row("check_amount"))
        '    End If
        '  End If
        'Next
        For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
          If Not item.Entity Is Nothing AndAlso Not item.Entity.Bankacct Is Nothing AndAlso Not item.Entity.Bankacct.Account Is Nothing Then
            If item.Entity.Bankacct.Account.Id = acct.Id Then
              sumvalue += item.Entity.Amount
            End If
          End If
        Next
        If sumvalue > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "H2.2"
          ji.Amount = sumvalue
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)
        End If
      Next

      'For i As Integer = Me.MaxRowIndex To 0 Step -1
      '  Dim row As TreeRow = Me.ItemTable.Childs(i)
      '  If ValidateRow(row) Then
      '    Dim bankacct As New BankAccount(CStr(row("bankacct_code")))
      '    ji = New JournalEntryItem
      '    ji.Mapping = "H2.2D"
      '    ji.Amount = CDec(row("check_amount"))
      '    ji.Account = bankacct.Account
      '    ji.Note = "" 'CStr(row("check_cqcode")) & ":" & CStr(row("bankacct_name")) & "/" & CStr(row("check_recipient"))
      '    If Not row.IsNull("check_cqcode") Then
      '      ji.Note &= CStr(row("check_cqcode"))
      '    End If
      '    If Not row.IsNull("bankacct_name") Then
      '      ji.Note &= ":" & CStr(row("bankacct_name"))
      '    End If
      '    If Not row.IsNull("check_recipient") Then
      '      ji.Note &= "/" & CStr(row("check_recipient"))
      '    End If
      '    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '    jiColl.Add(ji)
      '  End If
      'Next

      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If Not item.Entity Is Nothing AndAlso Not item.Entity.Bankacct Is Nothing Then
          'Dim bankacct As New BankAccount(CStr(row("bankacct_code")))
          ji = New JournalEntryItem
          ji.Mapping = "H2.2D"
          ji.Amount = item.Entity.Amount ' CDec(row("check_amount"))
          If Not item.Entity.Bankacct.Account Is Nothing Then
            ji.Account = item.Entity.Bankacct.Account ' bankacct.Account
          End If

          If Not item.Entity.Note Is Nothing AndAlso item.Entity.Note.Length > 0 Then
            ji.Note = item.Entity.Note
          End If
          If Not item.Entity.Bankacct Is Nothing Then
            ji.Note &= ":" & item.Entity.Bankacct.Name
          End If
          If Not item.Entity.Recipient Is Nothing AndAlso item.Entity.Recipient.Length > 0 Then
            ji.Note &= "/" & item.Entity.Recipient
          End If
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)
        End If
      Next

    End Sub
    ' เจ้าหนี้การค้า
    Private Sub SetPassCreditor(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '  If ValidateRow(trow) Then
      '    Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence)
      '    ht(ga.Account.Id) = ga.Account
      '  End If
      'Next
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If Not item.Entity Is Nothing AndAlso Not item.Entity.Bankacct Is Nothing AndAlso Not item.Entity.Bankacct.Account Is Nothing Then
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence)
          ht(ga.Account.Id) = ga.Account
        End If
      Next
      For Each acct As Account In ht.Values
        Dim sumvalue As Decimal = 0
        'For i As Integer = Me.MaxRowIndex To 0 Step -1
        '  Dim row As TreeRow = Me.ItemTable.Childs(i)
        '  If ValidateRow(row) Then
        '    Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence)
        '    If ga.Account.Id = acct.Id Then
        '      sumvalue += CDec(row("check_amount"))
        '    End If
        '    ji = New JournalEntryItem
        '    ji.Mapping = "H2.1D"
        '    ji.Amount = CDec(row("check_amount"))
        '    If acct.Originated Then
        '      ji.Account = acct
        '    End If
        '    ji.Note = "" 'CStr(row("check_cqcode")) & ":" & CStr(row("bankacct_name")) & "/" & CStr(row("check_recipient"))
        '    If Not row.IsNull("check_cqcode") Then
        '      ji.Note &= CStr(row("check_cqcode"))
        '    End If
        '    If Not row.IsNull("bankacct_name") Then
        '      ji.Note &= ":" & CStr(row("bankacct_name"))
        '    End If
        '    If Not row.IsNull("check_recipient") Then
        '      ji.Note &= "/" & CStr(row("check_recipient"))
        '    End If
        '    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        '    jiColl.Add(ji)
        '  End If
        'Next
        For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
          If Not item.Entity Is Nothing Then
            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence)
            If ga.Account.Id = acct.Id Then
              sumvalue += item.Entity.Amount
            End If
            ji = New JournalEntryItem
            ji.Mapping = "H2.1D"
            ji.Amount = item.Entity.Amount
            If acct.Originated Then
              ji.Account = acct
            End If
            ji.Note = ""
            If Not item.Entity.Note Is Nothing AndAlso item.Entity.Note.Length > 0 Then
              ji.Note &= item.Entity.Note
            End If
            If Not item.Entity.Bankacct Is Nothing Then
              ji.Note &= ":" & item.Entity.Bankacct.Name
            End If
            If Not item.Entity.Recipient Is Nothing AndAlso item.Entity.Recipient.Length > 0 Then
              ji.Note &= "/" & item.Entity.Recipient
            End If
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            jiColl.Add(ji)
          End If
        Next
        If sumvalue > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "H2.1"
          ji.Amount = sumvalue
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)

        End If
      Next
    End Sub
    ' เช็คจ่ายล่วงหน้า สลับแถวกับ เจ้าหนี้การค้า
    Private Sub SetPassCheckOutgoingAndCreditor(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If Not item.Entity Is Nothing Then
          'Dim bankacct As New BankAccount(CStr(row("bankacct_code")))
          ji = New JournalEntryItem
          ji.Mapping = "Through"
          ji.IsDebit = False
          ji.Amount = item.Entity.Amount
          If Not item.Entity.Bankacct Is Nothing AndAlso Not item.Entity.Bankacct.Account Is Nothing Then
            ji.Account = item.Entity.Bankacct.Account
          End If
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)

          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence)
          ji = New JournalEntryItem
          ji.Mapping = "Through"
          ji.IsDebit = True
          ji.Amount = item.Entity.Amount
          ji.Account = ga.Account
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)
        End If
      Next

    End Sub
    ' เช็คจ่ายล่วงหน้า กรณียกเลิก
    Private Sub SetCancelCheckOutgoing(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '  If ValidateRow(trow) Then
      '    Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence)
      '    ht(ga.Account.Id) = ga.Account
      '    'Dim bankacct As New BankAccount(CStr(trow("bankacct_code")))
      '    'ht(bankacct.Account.Id) = bankacct.Account
      '  End If
      'Next
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If Not item.Entity Is Nothing AndAlso Not item.Entity.Bankacct Is Nothing AndAlso Not item.Entity.Bankacct.Account Is Nothing Then
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence)
          ht(ga.Account.Id) = ga.Account
        End If
      Next
      For Each acct As Account In ht.Values
        Dim sumvalue As Decimal = 0
        For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
          'Dim row As TreeRow = Me.ItemTable.Childs(i)
          'Dim drh As New DataRowHelper(row)
          If Not item.Entity Is Nothing Then
            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence)
            If ga.Account.Id = acct.Id Then
              sumvalue += item.Entity.Amount 'drh.GetValue(Of Decimal)("check_amount", 0)
            End If
            ji = New JournalEntryItem
            ji.Mapping = "H2.3D"
            ji.Amount = item.Entity.Amount ' drh.GetValue(Of Decimal)("check_amount", 0)
            ji.IsDebit = True
            If acct.Originated Then
              ji.Account = acct
            End If
            ji.Note = item.Entity.CqCode
            If Not item.Entity.Bankacct Is Nothing Then
              ji.Note &= ":" & item.Entity.Bankacct.Name
            End If
            If Not item.Entity.Recipient Is Nothing AndAlso item.Entity.Recipient.Length > 0 Then
              ji.Note &= ":" & item.Entity.Recipient
            End If
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              jiColl.Add(ji)
            End If
        Next
        If sumvalue > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "H2.3"
          ji.Amount = sumvalue
          ji.IsDebit = True
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' เงินฝากธนาคาร
    Private Sub SetCancelBankAcct(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '  If ValidateRow(trow) Then
      '    Dim bankacct As New BankAccount(CStr(trow("bankacct_code")))
      '    ht(bankacct.Account.Id) = bankacct.Account
      '  End If
      'Next
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If Not item.Entity Is Nothing AndAlso Not item.Entity.Bankacct Is Nothing AndAlso Not item.Entity.Bankacct.Account Is Nothing Then
          ht(item.Entity.Bankacct.Account.Id) = item.Entity.Bankacct.Account
        End If
      Next
      For Each acct As Account In ht.Values
        Dim sumvalue As Decimal = 0
        'For i As Integer = Me.MaxRowIndex To 0 Step -1
        '  Dim row As TreeRow = Me.ItemTable.Childs(i)
        '  If ValidateRow(row) Then
        '    Dim bankacct As New BankAccount(CStr(row("bankacct_code")))
        '    If bankacct.Account.Id = acct.Id Then
        '      sumvalue += CDec(row("check_amount"))
        '    End If
        '  End If
        'Next
        For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
          If Not item.Entity Is Nothing Then
            If item.Entity.Bankacct.Account.Id = acct.Id Then
              sumvalue += item.Entity.Amount
            End If
          End If
        Next
        If sumvalue > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "H2.3"
          ji.Amount = sumvalue
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' เจ้าหนี้การค้า
    Private Sub SetCancelCreditor(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      'Dim ht As New Hashtable
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '  If ValidateRow(trow) Then
      '    Dim supplieracct As New Supplier(CInt(trow("check_supplier")))
      '    ht(supplieracct.Account.Id) = supplieracct.Account
      '  End If
      'Next
      'For Each acct As Account In ht.Values
      '  Dim sumvalue As Decimal = 0
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem ' i As Integer = Me.MaxRowIndex To 0 Step -1
        'Dim row As TreeRow = Me.ItemTable.Childs(i)
        'Dim drh As New DataRowHelper(row)
        If Not item.Entity Is Nothing Then
          Dim supplieracct As New Supplier(item.Entity.Supplier.Id) ' New Supplier(CInt(row("check_supplier")))
          Dim acct As Account = supplieracct.Account
          ji = New JournalEntryItem
          ji.Mapping = "H2.4D"
          ji.Amount = item.Entity.Amount ' drh.GetValue(Of Decimal)("check_amount", 0)
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.Note = "ยกเลิกเช็ค "
          If Not item.Entity.CqCode Is Nothing AndAlso item.Entity.CqCode.Length > 0 Then
            ji.Note &= item.Entity.CqCode
          End If
          If Not supplieracct Is Nothing Then
            ji.Note &= "/" & supplieracct.Name
          End If
          'If item.Entity.CqCode.Length & drh.GetValue(Of String)("check_cqcode") & "/" & supplieracct.Name
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)


          ji = New JournalEntryItem
          ji.Mapping = "H2.4"
          ji.Amount = item.Entity.Amount ' drh.GetValue(Of Decimal)("check_amount", 0)
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)
        End If
      Next
      'If sumvalue > 0 Then
      '  ji = New JournalEntryItem
      '  ji.Mapping = "H2.4"
      '  ji.Amount = sumvalue
      '  If acct.Originated Then
      '    ji.Account = acct
      '  End If
      '  ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '  jiColl.Add(ji)
      'End If
      'Next
    End Sub
    ' เช็คจ่ายล่วงหน้า กรณียกเลิก สลับกับ เงินฝากธนาคาร
    Private Sub SetCancelCheckOutgoingAndBankAcct(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If Not item.Entity Is Nothing Then
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence)
          ji = New JournalEntryItem
          ji.Mapping = "Through"
          ji.Amount = item.Entity.Amount ' CDec(row("check_amount"))
          ji.Account = ga.Account
          ji.IsDebit = True
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)

          'Dim bankacct As New BankAccount( CStr(row("bankacct_code")))
          ji = New JournalEntryItem
          ji.Mapping = "Through"
          ji.Amount = item.Entity.Amount 'CDec(row("check_amount"))
          If Not item.Entity.Bankacct Is Nothing AndAlso Not item.Entity.Bankacct.Account Is Nothing Then
            ji.Account = item.Entity.Bankacct.Account ' bankacct.Account
          End If
          ji.IsDebit = False
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)

        End If
      Next
    End Sub

    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property

#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.Status.Value <= 2 ' บันทึกแล้ว
        Else
          Return False
        End If
      End Get
    End Property
    Public Function ValidateItem() As SaveErrorException
      'For Each row As TreeRow In Me.ItemTable.Childs
      '  If Not row.IsNull("cqupdatei_entity") Then
      '    If Me.NextCheckUpdateStatus.ContainsKey(CInt(row("cqupdatei_entity"))) Then
      '      Dim cqCode As String = ""
      '      If Not row.IsNull("code") Then
      '        cqCode = CStr(row("code"))
      '      End If
      '      Dim messageStr As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckPayment.CheckReferenced}")
      '      messageStr = String.Format(messageStr, Me.Code, cqCode)
      '      Return New SaveErrorException(messageStr)
      '      'Return New SaveErrorException("${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckPayment.CheckReferenced}", New String() {Me.Code, cqCode})
      '    End If
      '  End If
      'Next
      For Each item As UpdateCheckPaymentItem In Me.ListOfUpdateCheckPaymentItem
        If Not item.Entity Is Nothing AndAlso item.Entity.Originated Then
          If Not Me.NextCheckUpdateStatus Is Nothing AndAlso Me.NextCheckUpdateStatus.ContainsKey(item.Entity.Id) Then
            Dim cqCode As String = ""
            If Not item.Entity.CqCode Is Nothing AndAlso item.Entity.CqCode.Length > 0 Then
              cqCode = item.Entity.CqCode
            End If
            Dim messageStr As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckPayment.CheckReferenced}")
            messageStr = String.Format(messageStr, Me.Code, cqCode)
            Return New SaveErrorException(messageStr)
            'Return New SaveErrorException("${res:Longkong.Pojjaman.BusinessLogic.UpdateCheckPayment.CheckReferenced}", New String() {Me.Code, cqCode})
          End If
        End If
      Next
      Return New SaveErrorException("0")
    End Function
    Public Function ValidateItemByEntityId(ByVal entityId As Integer) As Boolean
      If Me.NextCheckUpdateStatus.ContainsKey(entityId) Then
        Return True
      End If
      Return False
    End Function
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteUpdateCheckPayment}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If

      Dim validate As SaveErrorException = Me.ValidateItem
      If Not IsNumeric(validate.Message) Then
        Return New SaveErrorException(validate.Message)
      End If

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try

        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure,
                  "UpdateCheck_PaymentRef",
                  New SqlParameter("@refto_id", Me.Id)
                  )
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure,
                                  "UpdateCheck_ItemsStatus",
                                  New SqlParameter("@listOfIds", Me.GetListIds),
                                  New SqlParameter("@listOfOldIds", Me.GetListOldIds),
                                  New SqlParameter("@docstatus", Me.UpdatedStatus.Value),
                                  New SqlParameter("@cqupdate_id", Me.Id),
                                  New SqlParameter("@isDeletingCase", 1)
                                  )

        'UpdateOldItemStatus(conn, trans, True)

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteUpdateCheckPayment", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.UpdateCheckPaymentIsReferencedCannotBeDeleted}")
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
      End Try
    End Function
#End Region

    Private Sub UpdateCheckPayment_PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Handles MyBase.PropertyChanged

    End Sub
  End Class

  ' Update check items
  Public Class UpdateCheckPaymentItem

#Region "Members"
    Private m_updatecheckpayment As UpdateCheckPayment
    Private m_lineNumber As Integer
    Private m_entity As OutgoingCheck

    Private m_amount As Decimal
    Private m_bankcharge As Decimal
    Private m_wht As Decimal

    Private m_beforestatus As OutgoingCheckDocStatus
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
          .m_entity = New OutgoingCheck(dr, aliasPrefix)
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
          AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
            .m_entity = New OutgoingCheck(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
          End If
        End If

        ' before status ...
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_beforestatus") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_beforestatus") Then
          .m_beforestatus = New OutgoingCheckDocStatus(CInt(dr(aliasPrefix & Me.Prefix & "_beforestatus")))
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

    Public Property UpdateCheckPayment() As UpdateCheckPayment
      Get
        Return m_updatecheckpayment
      End Get
      Set(ByVal Value As UpdateCheckPayment)
        m_updatecheckpayment = Value
      End Set
    End Property

    Public Property BeforeStatus() As CodeDescription
      Get
        Return m_beforestatus
      End Get
      Set(ByVal Value As CodeDescription)
        m_beforestatus = CType(Value, OutgoingCheckDocStatus)
      End Set
    End Property
    Public Property LineNumber() As Integer
      Get
        Return m_lineNumber
      End Get
      Set(ByVal Value As Integer)
        m_lineNumber = Value
      End Set
    End Property

    Public Property Amount() As Decimal
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property

    Public Property BankCharge() As Decimal
      Get
        Return m_bankcharge
      End Get
      Set(ByVal Value As Decimal)
        m_bankcharge = Value
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

    Public Property Entity() As OutgoingCheck
      Get
        Return m_entity
      End Get
      Set(ByVal Value As OutgoingCheck)
        m_entity = Value
      End Set
    End Property

#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.UpdateCheckPayment.IsInitialized = False
      row("linenumber") = Me.LineNumber
      If Not Me.Entity Is Nothing Then
        row("cqupdatei_entity") = Me.Entity.Id
        row("code") = Me.Entity.Code
        row("cqcode") = Entity.CqCode
        row("docdate") = Entity.IssueDate
        row("recipient") = Entity.Recipient

        row("check_id") = Me.Entity.Id
        row("check_code") = Entity.Code
        row("check_cqcode") = Entity.CqCode
        row("check_issuedate") = Entity.IssueDate
        row("check_recipient") = Entity.Recipient

        If Not Entity.Supplier Is Nothing Then
          row("check_supplier") = Entity.Supplier.Id
        End If

        If Not Entity.Bankacct Is Nothing Then
          row("bankacct_id") = Entity.Bankacct.Id
          row("bankacct_code") = Entity.Bankacct.Code
          row("bankacct_name") = Entity.Bankacct.Name
          row("bank_id") = Entity.Bankacct.BankBranch.Bank.Id
          row("bank_code") = Entity.Bankacct.BankBranch.Bank.Code
          row("bank_name") = Entity.Bankacct.BankBranch.Bank.Name
        End If

        row("check_bankcharge") = Entity.BankCharge
        row("check_wht") = Entity.WHT
        row("check_amt") = Entity.Amount
        row("check_amount") = Entity.Amount

        row("cqupdatei_beforestatus") = Entity.DocStatus.Value
      Else
        row("cqupdatei_entity") = DBNull.Value
        row("code") = "" 'DBNull.Value
        row("cqcode") = "" 'DBNull.Value
        row("docdate") = DBNull.Value
        row("check_id") = DBNull.Value
        row("check_code") = "" 'DBNull.Value
        row("check_cqcode") = "" 'DBNull.Value
        row("check_issuedate") = DBNull.Value

        row("recipient") = "" 'DBNull.Value
        row("check_recipient") = DBNull.Value
        row("check_supplier") = DBNull.Value

        row("bankacct_id") = DBNull.Value
        row("bankacct_code") = "" 'DBNull.Value
        row("bankacct_name") = "" 'DBNull.Value

        row("bank_id") = DBNull.Value
        row("bank_code") = "" 'DBNull.Value
        row("bank_name") = "" 'DBNull.Value

        row("check_bankcharge") = DBNull.Value
        row("check_wht") = DBNull.Value
        row("check_amount") = DBNull.Value
        row("check_amt") = DBNull.Value

        row("cqupdatei_beforestatus") = DBNull.Value
      End If

      Me.UpdateCheckPayment.IsInitialized = True
    End Sub
    'Public Sub CopyFromDataRow(ByVal row As TreeRow)
    '  If row Is Nothing Then
    '    Return
    '  End If
    '  Try
    '    ' Line number ...
    '    If Not row.IsNull(("linenumber")) Then
    '      Me.LineNumber = CInt(row("linenumber"))
    '    End If
    '    ' Entity ...
    '    If row.Table.Columns.Contains("check_id") AndAlso Not row.IsNull("check_id") Then
    '      Me.Entity = New OutgoingCheck(row, "")
    '    Else
    '      If row.Table.Columns.Contains("cqupdatei_entity") _
    '      AndAlso Not row.IsNull(("cqupdatei_entity")) Then
    '        Me.Entity = New OutgoingCheck(CInt(row("cqupdatei_entity")))
    '      End If
    '    End If

    '    If row.Table.Columns.Contains("check_amount") _
    '        AndAlso Not row.IsNull(("check_amount")) Then
    '      Me.Amount = CDec(row("check_amount"))
    '    End If

    '    If row.Table.Columns.Contains("check_bankcharge") _
    '        AndAlso Not row.IsNull(("check_bankcharge")) Then
    '      Me.BankCharge = CDec(row("check_bankcharge"))
    '    End If

    '    If row.Table.Columns.Contains("check_wht") _
    '        AndAlso Not row.IsNull(("check_wht")) Then
    '      Me.WHT = CDec(row("check_wht"))
    '    End If

    '    If row.Table.Columns.Contains("cqupdatei_beforestatus") _
    '        AndAlso Not row.IsNull(("cqupdatei_beforestatus")) Then
    '      Me.BeforeStatus = New OutgoingCheckDocStatus(CInt(row("cqupdatei_beforestatus")))
    '    End If
    '  Catch ex As Exception
    '    MessageBox.Show(ex.Message & "::" & ex.StackTrace)
    '  End Try

    'End Sub
#End Region

  End Class
End Namespace
