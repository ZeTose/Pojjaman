Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Syncfusion.Windows.Forms.Grid

Namespace Longkong.Pojjaman.BusinessLogic
  
  Public Class EquipmentToolWithdraw
    Inherits SimpleBusinessEntityBase
    Implements IHasToCostCenter, IHasFromCostCenter, ICancelable, IPrintableEntity, ICheckPeriod, IWBSAllocatable,  _
    INewPrintableEntity, IDocStatus

#Region "Members"
    Private m_docDate As Date
    Private m_olddocDate As Date
    Private m_withdrawperson As Employee
    Private m_withdrawcc As CostCenter
    Private m_storeperson As Employee
    Private m_storecc As CostCenter
    Private m_note As String
    Private m_tostatus As EqtStatus
    Private m_fromstatus As EqtStatus
    Private m_itemCollection As EquipmentToolWithdrawItemCollection
    Private m_oldCC As CostCenter
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docDate = Now.Date
        .m_olddocDate = Now.Date
        .m_note = ""
        .m_withdrawperson = New Employee
        .m_withdrawcc = New CostCenter

        .m_storeperson = New Employee
        .m_storecc = New CostCenter
        .m_fromstatus = New EqtStatus(2)
        .m_tostatus = New EqtStatus(3)
        .m_oldCC = New CostCenter
      End With
      m_itemCollection = New EquipmentToolWithdrawItemCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        ' Document date
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docDate") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & Me.Prefix & "_docDate"))
          .m_olddocDate = CDate(dr(aliasPrefix & Me.Prefix & "_docDate"))
        End If
        ' note
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If
        ' WithDraw Person

        'If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isexternal") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isexternal") Then
        '  .m_isExternal = CBool(dr(aliasPrefix & Me.Prefix & "_isexternal"))
        'End If

        'If .m_isExternal Then
        '    ' Customer ...
        '    If dr.Table.Columns.Contains(aliasPrefix & "withdrawCustomer.cust_id") Then
        '        If Not dr.IsNull("withdrawCustomer.cust_id") Then
        '            .m_withdrawperson = New Customer(dr, "withdrawCustomer.")
        '        End If
        '    Else
        '        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_toCCPerson") Then
        '            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_toCCPerson") Then
        '                .m_withdrawperson = New Customer(CInt(dr(aliasPrefix & Me.Prefix & "_toCCPerson")))
        '            End If
        '        End If
        '    End If

        'Else
        ' Employee ...
        If dr.Table.Columns.Contains(aliasPrefix & "withdrawEmployee.employee_id") Then
          If Not dr.IsNull("withdrawEmployee.employee_id") Then
            .m_withdrawperson = New Employee(dr, "withdrawEmployee.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_toCCPerson") Then
            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_toCCPerson") Then
              .m_withdrawperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_toCCPerson")))
            End If
          End If
        End If
        'End If


        ' WithDraw Costcenter, Request CostCenter
        If dr.Table.Columns.Contains(aliasPrefix & "withdrawcostcenter.cc_id") Then
          If Not dr.IsNull("withdrawcostcenter.cc_id") Then
            .m_withdrawcc = New CostCenter(dr, "withdrawcostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_tocc") Then
            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_tocc") Then
              .m_withdrawcc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_tocc")))
            End If
          End If
        End If

        .m_oldCC = New CostCenter(.m_withdrawcc.Id)

        ' Store Person
        If dr.Table.Columns.Contains(aliasPrefix & "storeperson.employee_id") Then
          If Not dr.IsNull("storeperson.employee_id") Then
            .m_storeperson = New Employee(dr, "storeperson.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromCCPerson") Then
            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromCCPerson") Then
              .m_storeperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_fromCCPerson")))
            End If
          End If
        End If
        ' Store Costcenter
        If dr.Table.Columns.Contains(aliasPrefix & "storecostcenter.cc_id") Then
          If Not dr.IsNull("storecostcenter.cc_id") Then
            .m_storecc = New CostCenter(dr, "storecostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromcc") Then
            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromcc") Then
              .m_storecc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_fromcc")))
            End If
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docstatus") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docstatus") Then
          Me.Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_docstatus")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromstatus") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromstatus") Then
          Me.FromStatus = New EqtStatus(CInt(dr(aliasPrefix & Me.Prefix & "_fromstatus")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_tostatus") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_tostatus") Then
          Me.ToStatus = New EqtStatus(CInt(dr(aliasPrefix & Me.Prefix & "_tostatus")))
        End If
        ''''
        'If dr.Table.Columns.Contains(aliasPrefix & "stock_entity") Then
        '  If Not dr.IsNull("stock_entity") Then
        '    .m_customer = New Customer(CInt(dr("stock_entity")))
        '  End If
        'Else
        '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") Then
        '    If Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
        '      .m_customer = New Customer(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
        '    End If
        '  End If
        'End If

      End With
      m_itemCollection = New EquipmentToolWithdrawItemCollection(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property ItemCollection() As EquipmentToolWithdrawItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As EquipmentToolWithdrawItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    'Public Property IsExternal() As Boolean
    '  Get
    '    Return m_isExternal
    '  End Get
    '  Set(ByVal Value As Boolean)
    '    m_isExternal = Value
    '  End Set
    'End Property
    Public Property FromStatus As EqtStatus
      Get
        Return m_fromstatus
      End Get
      Set(ByVal value As EqtStatus)
        m_fromstatus = value
      End Set
    End Property
    Public Property ToStatus As EqtStatus
      Get
        Return m_tostatus
      End Get
      Set(ByVal value As EqtStatus)
        m_tostatus = value
      End Set
    End Property
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate, IWBSAllocatable.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate      Get
        Return m_olddocDate
      End Get
    End Property    Public Property Withdrawperson() As Employee
      Get
        Return m_withdrawperson
      End Get      Set(ByVal Value As Employee)
        m_withdrawperson = Value      End Set    End Property    Public Property WithdrawCostcenter() As CostCenter      Get        Return m_withdrawcc      End Get      Set(ByVal Value As CostCenter)        If Not m_withdrawcc Is Nothing AndAlso m_withdrawcc.Id <> Value.Id Then          For Each itm As EquipmentToolWithdrawItem In Me.ItemCollection
            itm.WBSDistributeCollection.Clear()
          Next
        End If        m_withdrawcc = Value      End Set    End Property    Public Property Storeperson() As Employee      Get        Return m_storeperson      End Get      Set(ByVal Value As Employee)        m_storeperson = Value      End Set    End Property    Public Property StoreCostcenter() As CostCenter      Get        Return m_storecc      End Get      Set(ByVal Value As CostCenter)        If m_storecc IsNot Nothing AndAlso Value IsNot Nothing Then          If m_storecc.Id <> Value.Id Then
            Me.ItemCollection.Clear()
          End If
        End If        m_storecc = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    'Public Property Customer() As Customer
    '  Get
    '    Return m_customer
    '  End Get
    '  Set(ByVal Value As Customer)
    '    m_customer = Value
    '  End Set
    'End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "EquipmentToolWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "eqtstock"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "eqtstock"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.EquipmentToolWithdraw.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.EquipmentToolWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.EquipmentToolWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.EquipmentToolWithdraw.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("EqtStockItem")
      ' Get from StockItem ...
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Type", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("eqtstocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RentalRate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RentalPerDay", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim proposedCode As Object = row("code")
      Dim proposedQty As Object = row("qty")

      If (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") _
          And (Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0) _
          Then
        Return False
      End If
      Return True
    End Function
    Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
      Dim ret As Decimal = 0
      For Each item As EquipmentToolWithdrawItem In Me.ItemCollection
        For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
          If Not grWBSD.IsMarkup Then
            Dim isOut As Boolean = False
            Dim view As Integer = 45
            Dim transferAmt As Decimal = item.Amount
            Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.Amount, isOut, view, 3)
            If grWBSD.WBS.IsDescendantOf(myWbs) Then
              ret += (grWBSD.Percent * amt / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Public Function GetCurrentAmountForMarkup(ByVal mk As Markup) As Decimal
      Dim ret As Decimal = 0
      For Each item As EquipmentToolWithdrawItem In Me.ItemCollection
        For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
          If grWBSD.IsMarkup Then
            If grWBSD.WBS.Id = mk.Id And mk.Id <> 0 Then
              ret += (grWBSD.Percent * item.Amount / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Private Sub ResetId(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Private Function ValidateItem() As SaveErrorException
      Dim key As String = ""

      For Each item As EquipmentToolWithdrawItem In Me.ItemCollection

        Dim newHash As New Hashtable
        For Each wbitem As WBSDistribute In item.WBSDistributeCollection
          key = wbitem.WBS.Id.ToString
          If Not newHash.Contains(key) Then
            newHash(key) = wbitem
          Else
            Return New SaveErrorException("${res:Global.Error.DupplicateWBS}", New String() {wbitem.WBS.Code})
          End If
          If (wbitem.WBS Is Nothing OrElse wbitem.WBS.Id = 0) AndAlso wbitem.CostCenter.BoqId > 0 Then
            Return New SaveErrorException("${res:Global.Error.WBSMissing}")
          End If
        Next
      Next

      Return New SaveErrorException("0")
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me

        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If
        Dim ValidateError As SaveErrorException = ValidateItem()
        If Not IsNumeric(ValidateError.Message) Then
          Return ValidateError
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

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromCCPerson", Me.ValidIdOrDBNull(Me.Storeperson)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromcc", Me.ValidIdOrDBNull(Me.StoreCostcenter)))

        Dim person As SimpleBusinessEntityBase
        If TypeOf Me.Withdrawperson Is SimpleBusinessEntityBase Then
          person = CType(Me.Withdrawperson, SimpleBusinessEntityBase)
        End If
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toCCPerson", Me.ValidIdOrDBNull(person)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", Me.ValidIdOrDBNull(Me.WithdrawCostcenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docstatus", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromstatus", Me.FromStatus.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tostatus", Me.ToStatus.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.ItemCollection.Gross))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isexternal", Me.IsExternal))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.ValidIdOrDBNull(Me.Customer)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", 2))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Try
          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldid)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              ResetId(oldid)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If

            '--Clear รายการจัดสรร ของ CC ปลายทางเก่าซะหน่อย (pui)-- ============================
            If Me.Originated Then
              If m_oldCC.Id <> m_storecc.Id Then
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, _
                                                       "DeleteOldAllocateEquipmentItem", _
                                                       New SqlParameter("@eqtstock_id", Me.Id) _
                                          )
              End If
            End If
            '--Clear รายการจัดสรร ของ CC ปลายทางเก่าซะหน่อย-- ============================

            Dim errstr As SaveErrorException = SaveDetail(Me.Id, conn, trans)
            If IsNumeric(errstr.Message) Then
              Select Case CInt(errstr.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldid)
                  Return New SaveErrorException(errstr.Message)
                Case Else
              End Select
            ElseIf IsDBNull(errstr.Message) OrElse Not IsNumeric(errstr.Message) Then
              trans.Rollback()
              ResetId(oldid)
              Return New SaveErrorException(errstr.Message)
            End If

            '==============================eqtSTOCKFIFO=========================================
            'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (Teeraboon)
            If Not Me.IsReferenced Then
              SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertEqtStockiFIFO", New SqlParameter("@eqtstock_id", Me.Id), _
                                                                                                    New SqlParameter("@tostatus", Me.ToStatus.Value), _
                                                                                                    New SqlParameter("@fromstatus", Me.FromStatus.Value) _
                                                                                                    )
            End If
            '==============================eqtSTOCKFIFO=========================================

            'Me.DeleteRef(conn, trans)
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQTStockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            ''SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
            '', New SqlParameter("@refto_id", Me.Id))
            ''SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
            '', New SqlParameter("@refto_id", Me.Id))
            'If Me.Status.Value = 0 Then
            '  Me.CancelRef(conn, trans)
            'End If

            trans.Commit()
            'Return New SaveErrorException(returnVal.Value.ToString)
          Catch ex As SqlException
            trans.Rollback()
            ResetId(oldid)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            ResetId(oldid)
            Return New SaveErrorException(ex.ToString)
            'Finally
            '  conn.Close()
          End Try

          '--Sub Save Block-- ============================================================
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
            Return New SaveErrorException(returnVal.Value.ToString)
            'Complete Save
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try
          '--Sub Save Block-- ============================================================

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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQTStockRef" _
        , New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSReferencedFromEqtStock", New SqlParameter("@refto_id", Me.Id), New SqlParameter("@refto_type", Me.EntityId))
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
    End Function
    Private Function GetRefIdString() As String
      Dim ret As String = ""
      For Each item As EquipmentToolWithdrawItem In Me.ItemCollection
        If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 Then
          ret &= CStr(item.Entity.Id) & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from EqtStockItem Where EqtStocki_eqtstock = " & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from EqtStockiWbs Where EqtStockiw_sequence in ( Select eqtstocki_sequence from EqtStockItem Where EqtStocki_eqtstock = " & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From EqtStockItem Where eqtstocki_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "Eqtstockitem")
        da.Fill(ds, "Eqtstockitem")

        'Dim EqtDt As DataTable = GetEqiLastSequence()

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "EqtStockiWbs")
        daWbs.Fill(ds, "EqtStockiWbs")
        ds.Relations.Add("sequence", ds.Tables!EqtStockItem.Columns!eqtstocki_sequence, ds.Tables!EqtStockiWbs.Columns!EqtStockiw_sequence)

        Dim dt As DataTable = ds.Tables("Eqtstockitem")
        Dim dtWbs As DataTable = ds.Tables("EqtStockiWbs")

        For Each row As DataRow In ds.Tables("EqtStockiWbs").Rows
          row.Delete()
        Next

        '------------Checking if we have to delete some rows--------------------
        Dim rowsToDelete As New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As EquipmentToolWithdrawItem In Me.ItemCollection
            If testItem.Sequence = CInt(dr("eqtstocki_sequence")) Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            If Not rowsToDelete.Contains(dr) Then
              rowsToDelete.Add(dr)
            End If
          End If
        Next
        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next
        '------------End Checking--------------------

        Dim i As Integer = 0 'Line Running
        Dim seq As Integer = -1
        With ds.Tables("Eqtstockitem")
          For Each item As EquipmentToolWithdrawItem In Me.ItemCollection
            'Dim dr As DataRow = .NewRow
            'Dim row() As DataRow = EqtDt.Select("eqtstocki_entity =" & item.Entity.Id.ToString)
            i += 1

            '------------Checking if we have to add a new row or just update existing--------------------
            Dim dr As DataRow
            Dim drs As DataRow() = dt.Select("eqtstocki_sequence=" & item.Sequence)
            If drs.Length = 0 Then
              dr = dt.NewRow
              'dt.Rows.Add(dr)
              seq = (Me.Id + i) * (-1)
              dr("eqtstocki_sequence") = seq
            Else
              dr = drs(0)
            End If
            '------------End Checking--------------------

            'dr("eqtstocki_eqtstock") = Me.Id
            'dr("eqtstocki_linenumber") = i

            'dr("eqtstocki_entity") = item.Entity.Id
            'dr("eqtstocki_entityType") = item.ItemType.Value
            'dr("eqtstocki_Name") = item.Entity.Name
            'dr("eqtstocki_qty") = item.Qty
            'dr("eqtstocki_unit") = item.Unit.Id
            'dr("eqtstocki_rentalrate") = item.RentalPerDay  'คิดจากจำนวนแล้ว
            'dr("eqtstocki_note") = item.Note
            'dr("eqtstocki_type") = Me.EntityId

            dr("eqtstocki_eqtstock") = Me.Id
            dr("eqtstocki_linenumber") = i
            dr("eqtstocki_entity") = item.Entity.Id
            dr("eqtstocki_entityType") = item.ItemType.Value
            dr("eqtstocki_toollot") = DBNull.Value
            dr("eqtstocki_name") = item.Entity.Name
            dr("eqtstocki_unit") = item.Unit.Id
            dr("eqtstocki_qty") = item.Qty
            dr("eqtstocki_refsequence") = DBNull.Value
            dr("eqtstocki_rentalrate") = item.RentalPerDay  'คิดจากจำนวนแล้ว
            dr("eqtstocki_rentalunit") = DBNull.Value
            dr("eqtstocki_rentalqty") = DBNull.Value
            dr("eqtstocki_unitprice") = item.RentalRate
            dr("eqtstocki_Amount") = 0
            dr("eqtstocki_remainbuyqty") = item.LimitQty
            'dr("eqtstocki_unitAssetAmount") = 0
            dr("eqtstocki_AssetAmount") = 0
            dr("eqtstocki_writeoffAmt") = 0
            'dr("eqtstocki_unitaccdepre") = 0
            dr("eqtstocki_accdepre") = 0
            dr("eqtstocki_note") = item.Note
            dr("eqtstocki_type") = Me.EntityId
            dr("eqtstocki_refdoc") = item.PRItem.Pr.Id
            dr("eqtstocki_refdoctype") = item.PRItem.Pr.EntityId
            dr("eqtstocki_refdoclinenumber") = item.PRItem.LineNumber
            dr("eqtstocki_parent") = DBNull.Value
            dr("eqtstocki_level") = DBNull.Value
            dr("eqtstocki_fromstatus") = Me.FromStatus.Value
            dr("eqtstocki_tostatus") = Me.ToStatus.Value
            If drs.Length = 0 Then
              .Rows.Add(dr)
            End If

            Dim rootWBS As New WBS(Me.WithdrawCostcenter.RootWBSId)
            If item.ItemType.Value <> 160 _
            AndAlso item.ItemType.Value <> 162 Then
              Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
              Dim currentSum As Decimal = wbsdColl.GetSumPercent
              For Each wbsd As WBSDistribute In wbsdColl
                If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                  'ยังไม่เต็ม 100 แต่มีหัวอยู่
                  wbsd.Percent += (100 - currentSum)
                End If
                wbsd.BaseCost = 0 'item.ItemAmount
                Dim childDr As DataRow = dtWbs.NewRow
                childDr("eqtstockiw_wbs") = wbsd.WBS.Id
                If wbsd.CostCenter Is Nothing Then
                  wbsd.CostCenter = Me.WithdrawCostcenter
                End If
                childDr("eqtstockiw_cc") = wbsd.CostCenter.Id
                childDr("eqtstockiw_percent") = wbsd.Percent
                childDr("eqtstockiw_sequence") = dr("eqtstocki_sequence")
                childDr("eqtstockiw_ismarkup") = wbsd.IsMarkup
                childDr("eqtstockiw_direction") = 0              'in
                childDr("eqtstockiw_baseCost") = wbsd.BaseCost
                childDr("eqtstockiw_amt") = wbsd.Amount
                childDr("eqtstockiw_toaccttype") = 1
                childDr("eqtstockiw_cbs") = wbsd.CBS.Id
                'Add เข้า stockiwbs
                dtWbs.Rows.Add(childDr)
              Next

              currentSum = wbsdColl.GetSumPercent
              'ยังไม่เต็ม 100 และยังไม่มี root
              If currentSum < 100 Then
                Try
                  Dim newWbsd As New WBSDistribute
                  newWbsd.WBS = rootWBS
                  newWbsd.CostCenter = Me.WithdrawCostcenter
                  newWbsd.Percent = 100 - currentSum
                  newWbsd.BaseCost = item.ItemAmount
                  Dim childDr As DataRow = dtWbs.NewRow
                  childDr("eqtstockiw_wbs") = newWbsd.WBS.Id
                  childDr("eqtstockiw_cc") = newWbsd.CostCenter.Id
                  childDr("eqtstockiw_percent") = newWbsd.Percent
                  childDr("eqtstockiw_sequence") = dr("eqtstocki_sequence")
                  childDr("eqtstockiw_ismarkup") = False
                  childDr("eqtstockiw_direction") = 0                'in
                  childDr("eqtstockiw_baseCost") = newWbsd.BaseCost
                  childDr("eqtstockiw_amt") = newWbsd.Amount
                  childDr("eqtstockiw_toaccttype") = 1
                  childDr("eqtstockiw_cbs") = newWbsd.CBS.Id
                  'Add เข้า stockiwbs
                  dtWbs.Rows.Add(childDr)
                Catch ex As Exception
                  MessageBox.Show(ex.ToString)
                End Try
              End If
            End If

          Next
        End With

        'da.Update(dt.Select("", "", DataViewRowState.Added))

        'ds.EnforceConstraints = False

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

        daWbs.Update(GetDeletedRows(dtWbs))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True

        Return New SaveErrorException("0")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString + vbCrLf + ex.InnerException.ToString)
      End Try


    End Function
    Private Function GetEqiLastSequence() As DataTable
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEqiLastSequence" _
      , New SqlParameter("@IDlist", Me.ItemCollection.EqIdList) _
      )

      Return ds.Tables(0)
    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daWbs_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        Dim currentkey As Integer = CInt(e.Row("eqtstockiw_sequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!eqtstockiw_sequence = e.Row.GetParentRow("sequence")("eqtstocki_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!eqtstockiw_sequence = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daItc_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        Dim currentkey As Integer = CInt(e.Row("itci_refsequence")) '.GetParentRow("sequence")("itci_refsequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!itci_refsequence = e.Row.GetParentRow("sequence_2")("stocki_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!itci_refsequence = currentkey
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

#Region "IHasToCostCenter"
    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC, IWBSAllocatable.ToCostCenter
      Get
        Return Me.m_withdrawcc
      End Get
      Set(ByVal Value As CostCenter)
        m_withdrawcc = Value
      End Set
    End Property
#End Region

#Region "IHasFromCostCenter"
    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC, IWBSAllocatable.FromCostCenter
      Get
        Return Me.m_storecc
      End Get
      Set(ByVal Value As CostCenter)
        m_storecc = Value
      End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.Status.Value <= 2 AndAlso Not Me.IsReferenced
        Else
          Return False
        End If
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAssetWitdraw}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        For Each extender As Object In Me.Extenders
          If TypeOf extender Is IExtender Then
            Dim delDocError As SaveErrorException = CType(extender, IExtender).Delete(conn, trans)
            If Not IsNumeric(delDocError.Message) Then
              trans.Rollback()
              Return delDocError
            Else
              Select Case CInt(delDocError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Return delDocError
                Case Else
              End Select
            End If
          End If
        Next

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteEquipmentToolWithdraw", New SqlParameter() {New SqlParameter("@eqtstock_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AssetWithdrawIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteEqtReference", New SqlParameter("@eqtstock_id", Me.Id), New SqlParameter("@eqtstock_type", Me.EntityId))

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

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return ""
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return ""
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpi = New DocPrintingItem
      dpi.Mapping = "eqt_id"
      dpi.Value = Me.Id
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Code
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      If Not Me.Withdrawperson Is Nothing Then
        'ToPerson
        dpi = New DocPrintingItem
        dpi.Mapping = "ToPerson"
        dpi.Value = Me.Withdrawperson.Code & ":" & Me.Withdrawperson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToPersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToPersonInfo"
        dpi.Value = Me.Withdrawperson.Code & ":" & Me.Withdrawperson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToPersonName
        dpi = New DocPrintingItem
        dpi.Mapping = "ToPersonName"
        dpi.Value = Me.Withdrawperson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToPersonCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ToPersonCode"
        dpi.Value = Me.Withdrawperson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.WithdrawCostcenter Is Nothing AndAlso Me.WithdrawCostcenter.Originated Then
        'ToCostCenter
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenter"
        dpi.Value = Me.WithdrawCostcenter.Code & ":" & Me.WithdrawCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterInfo"
        dpi.Value = Me.WithdrawCostcenter.Code & ":" & Me.WithdrawCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterCode"
        dpi.Value = Me.WithdrawCostcenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterName"
        dpi.Value = Me.WithdrawCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterPhone"
        dpi.Value = Me.WithdrawCostcenter.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterFax
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterFax"
        dpi.Value = Me.WithdrawCostcenter.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Storeperson Is Nothing AndAlso Me.Storeperson.Originated Then
        'FromPerson
        dpi = New DocPrintingItem
        dpi.Mapping = "FromPerson"
        dpi.Value = Me.Storeperson.Code & ":" & Me.Storeperson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromPersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "FromPersonInfo"
        dpi.Value = Me.Storeperson.Code & ":" & Me.Storeperson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromPersonName
        dpi = New DocPrintingItem
        dpi.Mapping = "FromPersonName"
        dpi.Value = Me.Storeperson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromPersonCode
        dpi = New DocPrintingItem
        dpi.Mapping = "FromPersonCode"
        dpi.Value = Me.Storeperson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.StoreCostcenter Is Nothing AndAlso Me.StoreCostcenter.Originated Then
        'FromCostCenter
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenter"
        dpi.Value = Me.StoreCostcenter.Code & ":" & Me.StoreCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostcenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostcenterInfo"
        dpi.Value = Me.StoreCostcenter.Code & ":" & Me.StoreCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostcenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostcenterCode"
        dpi.Value = Me.StoreCostcenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostcenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostcenterName"
        dpi.Value = Me.StoreCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostcenterPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostcenterPhone"
        dpi.Value = Me.StoreCostcenter.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostcenterFax
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostcenterFax"
        dpi.Value = Me.StoreCostcenter.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Dim n As Integer = 0
      For Each item As EquipmentToolWithdrawItem In Me.ItemCollection
        dpi = New DocPrintingItem
        dpi.Mapping = "eqti_eqt"
        dpi.Value = Me.Id
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = n + 1
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ItemType
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ItemType"
        dpi.Value = item.ItemType.Description
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        If TypeOf item.Entity Is IHasGroup Then
          If TypeOf CType(item.Entity, IHasGroup).Group Is TreeBaseEntity Then
            'Item.Type
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Type"
            dpi.Value = CType(CType(item.Entity, IHasGroup).Group, TreeBaseEntity).Name
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          End If
        End If

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        dpi.Value = item.Entity.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        If Not item.Unit Is Nothing Then
          'Item.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit"
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        End If

        'Item.RentalRate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RentalRate"
        dpi.Value = Configuration.FormatToString(item.RentalRate, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty"
        dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.RentalPerDay
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RentalPerDay"
        dpi.Value = Configuration.FormatToString(item.RentalPerDay, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        '--------------------- WBS Section ------------------
        Dim WBSCode As String = ""
        Dim WBSCodePercent As String = ""
        Dim WBSCodeAmount As String = ""
        Dim WBSRemainAmount As String = ""
        Dim WBSRemainQty As String = ""
        If item.WBSDistributeCollection.Count > 0 Then
          'Populate ให้คำนวณคงเหลือแบบหลอกๆ
          item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
          If item.WBSDistributeCollection.Count = 1 Then
            WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
            WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
            WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price) & ")"
            WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
            WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
          Else
            Dim i As Integer
            For i = 0 To item.WBSDistributeCollection.Count - 1
              WBSCode &= item.WBSDistributeCollection.Item(i).WBS.Code
              WBSCodePercent &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Percent, DigitConfig.Price) & "%)"
              WBSCodeAmount &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Amount, DigitConfig.Price) & ")"
              WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).BudgetRemain, DigitConfig.Price)
              WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).QtyRemain, DigitConfig.Price)
              If i < item.WBSDistributeCollection.Count - 1 Then
                WBSCode &= ", "
                WBSCodePercent &= ", "
                WBSCodeAmount &= ", "
                WBSRemainAmount &= ", "
                WBSRemainQty &= ", "
              End If
            Next
          End If
        End If

        'Item.WBSCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCode"
        dpi.Value = WBSCode
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCodePercent
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCodePercent"
        dpi.Value = WBSCodePercent
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCodeAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCodeAmount"
        dpi.Value = WBSCodeAmount
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSRemainAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSRemainAmount"
        dpi.Value = WBSRemainAmount
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSRemainQty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSRemainQty"
        dpi.Value = WBSRemainQty
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        '--------------------- WBS Section ------------------

        'For Each itc As InternalCharge In item.InternalChargeCollection
        '  'Item.DateStart
        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "Item.DateStart"
        '  dpi.Value = itc.StartDate.ToShortDateString
        '  dpi.DataType = "System.String"
        '  dpi.Row = n + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  'Item.DateEnd
        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "Item.DateEnd"
        '  dpi.Value = itc.EndDate.ToShortDateString
        '  dpi.DataType = "System.String"
        '  dpi.Row = n + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  'Item.Details
        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "Item.Details"
        '  dpi.Value = itc.Name
        '  dpi.DataType = "System.String"
        '  dpi.Row = n + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  'Item.Rate
        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "Item.Rate"
        '  Dim rate As String = Configuration.FormatToString(itc.Rate, DigitConfig.Price)
        '  If itc.Ispercent Then
        '    rate &= " %"
        '  End If
        '  dpi.Value = rate
        '  dpi.DataType = "System.String"
        '  dpi.Row = n + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        '  'Item.Amount
        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "Item.Amount"
        '  dpi.Value = Configuration.FormatToString(itc.Amount, DigitConfig.Price)
        '  dpi.DataType = "System.String"
        '  dpi.Row = n + 1
        '  dpi.Table = "Item"
        '  dpiColl.Add(dpi)

        'Next
        'If item.InternalChargeCollection.Count = 0 Then
        '  n += 1
        'End If
        n += 1
      Next

      'ItemCount
      dpi = New DocPrintingItem
      dpi.Mapping = "ItemCount"
      dpi.Value = n
      dpi.DataType = "System.Int32"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region "IWBSAllocatable"
    Public ReadOnly Property AllowWBSAllocateFrom As Boolean Implements IWBSAllocatable.AllowWBSAllocateFrom
      Get
        Return False
      End Get
    End Property

    Public ReadOnly Property AllowWBSAllocateTo As Boolean Implements IWBSAllocatable.AllowWBSAllocateTo
      Get
        Return True
      End Get
    End Property

    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As EquipmentToolWithdrawItem In Me.ItemCollection
        'If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
        item.UpdateWBSQty()

        If Not Me.Originated Then
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsd.ChildAmount = 0
            wbsd.GetChildIdList()
            For Each allItem As EquipmentToolWithdrawItem In Me.ItemCollection
              For Each childWbsd As WBSDistribute In allItem.WBSDistributeCollection
                If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                  wbsd.ChildAmount += childWbsd.Amount
                End If
              Next
            Next
          Next
          'For Each wbsd As WBSDistribute In item.InWbsdColl
          '  wbsd.ChildAmount = 0
          '  wbsd.GetChildIdList()
          '  For Each allItem As MatOperationWithdrawItem In Me.ItemCollection
          '    For Each childWbsd As WBSDistribute In allItem.InWbsdColl
          '      If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
          '        wbsd.ChildAmount += childWbsd.Amount
          '      End If
          '    Next
          '  Next
          'Next
        End If

        coll.Add(item)
        'End If
      Next
      Return coll
    End Function

    Public Property Supplier As Supplier Implements IWBSAllocatable.Supplier
      Get

      End Get
      Set(ByVal value As Supplier)

      End Set
    End Property

#End Region

#Region "IDocStatus"
    Public ReadOnly Property DocStatus As String Implements IDocStatus.DocStatus
      Get
        If Me.Status.Value = 0 Then
          Return "Canceled"
        Else
          'Dim obj As Object = Configuration.GetConfig("ApprovePR")
          'If CBool(obj) Then
          '  If Me.IsAuthorized Then
          '    Return "Authorized"
          '  ElseIf Me.IsLevelApproved Then
          '    Return "Approved"
          '  End If
          'End If
        End If
        Return ""
      End Get
    End Property
#End Region
#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection

      dpiColl.RelationList.Add("general>eqt_id>item>eqti_eqt")

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("eqt_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToPerson", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToPersonInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToPersonName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenter", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterPhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterFax", "System.String"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromPerson", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromPersonInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromPersonCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromPersonName", "System.String"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostCenter", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostcenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostcenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostcenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostcenterPhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostcenterFax", "System.String"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("eqti_eqt", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ItemType", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Type", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.RentalRate", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.RentalPerDay", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Item"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodePercent", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodeAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainQty", "System.String", "Item"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ItemCount", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

  End Class


  

  Public Class EquipmentToolWithdrawforSelection
    Inherits EquipmentToolWithdraw
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "EquipmentToolWithdrawforSelection"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "EquipmentToolWithdrawforSelection"
      End Get
    End Property
  End Class

End Namespace
