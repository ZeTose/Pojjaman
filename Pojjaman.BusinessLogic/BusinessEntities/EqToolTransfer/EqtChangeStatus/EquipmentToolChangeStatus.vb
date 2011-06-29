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
  'Public Interface IHasRentalRate
  '    Inherits IHasName
  '    Property RentalRate() As Decimal
  'End Interface
  Public Class EquipmentToolChangeStatus
    Inherits SimpleBusinessEntityBase
    Implements IHasToCostCenter, IHasFromCostCenter, ICancelable, IPrintableEntity, ICheckPeriod


#Region "Members"
    Private m_docDate As Date
    Private m_storeperson As Employee
    Private m_storecc As CostCenter
    Private m_note As String
    Private m_tostatus As EqtStatus
    Private m_fromstatus As EqtStatus
    Private m_itemCollection As EquipmentToolChangeStatusItemCollection
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
        .m_note = ""

        .m_storeperson = New Employee
        .m_storecc = New CostCenter
        .m_fromstatus = New EqtStatus(-1)
        .m_tostatus = New EqtStatus(5)
      End With
      m_itemCollection = New EquipmentToolChangeStatusItemCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        ' Document date
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docDate") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & Me.Prefix & "_docDate"))
        End If
        ' note
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If
        
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
      m_itemCollection = New EquipmentToolChangeStatusItemCollection(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property ItemCollection() As EquipmentToolChangeStatusItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As EquipmentToolChangeStatusItemCollection)
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
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public Property Storeperson() As Employee      Get        Return m_storeperson      End Get      Set(ByVal Value As Employee)        m_storeperson = Value      End Set    End Property    Public Property StoreCostcenter() As CostCenter      Get        Return m_storecc      End Get      Set(ByVal Value As CostCenter)        m_storecc = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public ReadOnly Property Gross As Decimal
      Get
        Return ItemCollection.Gross
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "EquipmentToolChangeStatus"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.EqtChangeStatus.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AssetReturn"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AssetReturn"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.EqtChangeStatus.ListLabel}"
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
      ' Get from EqtStockItem ...
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Type", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("eqtstocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("FromStatus", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))
      Return myDatatable
    End Function
    Public Shared Function GetSchemaExpTable() As TreeTable
      Dim myDatatable As New TreeTable("EqtExpItem")
      ' Get from StockItem ...
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ItemType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("TypeName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("eqtstocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("StockQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
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
    'Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
    '  Dim ret As Decimal = 0
    '  For Each item As EquipmentToolChangeStatusItem In Me.ItemCollection
    '    For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
    '      If Not grWBSD.IsMarkup Then
    '        Dim isOut As Boolean = False
    '        Dim view As Integer = 45
    '        Dim transferAmt As Decimal = item.Amount
    '        Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.Amount, isOut, view, 3)
    '        If grWBSD.WBS.IsDescendantOf(myWbs) Then
    '          ret += (grWBSD.Percent * amt / 100)
    '        End If
    '      End If
    '    Next
    '  Next
    '  Return ret
    'End Function
    'Public Function GetCurrentAmountForMarkup(ByVal mk As Markup) As Decimal
    '  Dim ret As Decimal = 0
    '  For Each item As EquipmentToolChangeStatusItem In Me.ItemCollection
    '    For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
    '      If grWBSD.IsMarkup Then
    '        If grWBSD.WBS.Id = mk.Id And mk.Id <> 0 Then
    '          ret += (grWBSD.Percent * item.Amount / 100)
    '        End If
    '      End If
    '    Next
    '  Next
    '  Return ret
    'End Function
    Private Sub ResetId(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me

        If Me.ItemCollection.Count = 0 Then
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

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromCCPerson", Me.ValidIdOrDBNull(Me.Storeperson)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromcc", Me.ValidIdOrDBNull(Me.StoreCostcenter)))

        Dim person As SimpleBusinessEntityBase
        If TypeOf Me.Storeperson Is SimpleBusinessEntityBase Then
          person = CType(Me.Storeperson, SimpleBusinessEntityBase)
        End If
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toCCPerson", Me.ValidIdOrDBNull(person)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", Me.ValidIdOrDBNull(Me.StoreCostcenter)))
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
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQTStock_StockRef" _
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQTStock_StockRef" _
        , New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
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
    Private Function GetRefIdString() As String
      Dim ret As String = ""
      For Each item As EquipmentToolChangeStatusItem In Me.ItemCollection
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
        Dim daWbs As New SqlDataAdapter("select * from Eqtstock_Stock where es_eqtstockisequence in (select eqtstocki_sequence from EqtStockitem where eqtstocki_eqtstock=" & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From EqtStockitem Where eqtstocki_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "Eqtstockitem")
        da.Fill(ds, "Eqtstockitem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "Eqtstock_Stock")
        daWbs.Fill(ds, "Eqtstock_Stock")
        ds.Relations.Add("sequence", ds.Tables!EqtStockitem.Columns!eqtstocki_sequence, ds.Tables!Eqtstock_Stock.Columns!es_eqtstockisequence)

        Dim dt As DataTable = ds.Tables("Eqtstockitem")

        Dim dtExp As DataTable = ds.Tables("Eqtstock_Stock")

        For Each row As DataRow In ds.Tables("Eqtstock_Stock").Rows
          row.Delete()
        Next

        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As EquipmentToolChangeStatusItem In Me.ItemCollection
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
        'Dim EqtDt As DataTable = GetEqiLastSequence()


        Dim i As Integer = 0 'Line Running
        Dim seq As Integer
        With ds.Tables("Eqtstockitem")
          'For Each row As DataRow In .Rows
          '  row.Delete()
          'Next
          For Each item As EquipmentToolChangeStatusItem In Me.ItemCollection
            'Dim dr As DataRow = .NewRow
            '------------Checking if we have to add a new row or just update existing--------------------
            Dim dr As DataRow
            Dim drs As DataRow() = dt.Select("eqtstocki_sequence=" & item.Sequence)
            If drs.Length = 0 Then
              dr = dt.NewRow
              'dt.Rows.Add(dr)
              seq = seq + (-1)
              dr("eqtstocki_sequence") = seq
            Else
              dr = drs(0)
            End If
            '------------End Checking--------------------
            'Dim row() As DataRow = EqtDt.Select("eqtstocki_sequence =" & item.Entity.Id.ToString)
            i += 1
            dr("eqtstocki_eqtstock") = Me.Id
            dr("eqtstocki_linenumber") = i
            dr("eqtstocki_fromstatus") = Me.FromStatus.Value
            dr("eqtstocki_tostatus") = Me.ToStatus.Value
            dr("eqtstocki_type") = Me.EntityId
            dr("eqtstocki_entity") = item.Entity.Id
            dr("eqtstocki_entityType") = item.ItemType.Value
            dr("eqtstocki_Name") = item.Entity.Name
            dr("eqtstocki_qty") = item.Qty
            dr("eqtstocki_remainbuyqty") = item.LimitQty
            dr("eqtstocki_unit") = item.Unit.Id
            dr("eqtstocki_amount") = item.Amount
            dr("eqtstocki_note") = item.Note
            'dr("eqtstocki_rentalrate") = item.RentalPerDay  'คิดจากจำนวนแล้ว
            'dr("eqtstocki_rentalqty") = item.
            'If row.Length > 0 Then
            '  dr("eqtstocki_refsequence") = row(0)("id")
            'End If
            '------------Checking if we have to add a new row or just update existing--------------------
            If drs.Length = 0 Then
              dt.Rows.Add(dr)
            End If
            '------------End Checking--------------------
            If Not item.ExpItemCollection Is Nothing Then
              For Each expItem As StockItem In item.ExpItemCollection
                Dim childDr As DataRow = dtExp.NewRow
                'childDr("es_sequence") = 
                childDr("es_eqtstockisequence") = dr("eqtstocki_sequence")
                childDr("es_stockisequence") = expItem.Sequence
                childDr("es_stockqty") = expItem.Stockqty
                childDr("es_unitcost") = expItem.UnitCost
                childDr("es_note") = expItem.Note

                dtExp.Rows.Add(childDr)
              Next
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
        AddHandler daWbs.RowUpdated, AddressOf daExp_MyRowUpdated

        daWbs.Update(GetDeletedRows(dtExp))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtExp.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWbs.Update(dtExp.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True

        'ds.EnforceConstraints = True
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
    Private Sub daExp_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        Dim currentkey As Integer = CInt(e.Row("es_eqtstockisequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!es_eqtstockisequence = e.Row.GetParentRow("sequence")("eqtstocki_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!es_eqtstockisequence = currentkey
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
    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.m_storecc
      End Get
      Set(ByVal Value As CostCenter)
        m_storecc = Value
      End Set
    End Property
#End Region

#Region "IHasFromCostCenter"
    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteEqtChangeStatus", New SqlParameter() {New SqlParameter("@eqtstock_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AssetReturnIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
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
      For Each item As EquipmentToolChangeStatusItem In Me.ItemCollection
        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = n + 1
        dpi.DataType = "System.Int32"
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

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty"
        dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
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
        'If item.WBSDistributeCollection.Count > 0 Then
        '  'Populate ให้คำนวณคงเหลือแบบหลอกๆ
        '  item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
        '  If item.WBSDistributeCollection.Count = 1 Then
        '    WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
        '    WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
        '    WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price) & ")"
        '    WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
        '    WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
        '  Else
        '    Dim i As Integer
        '    For i = 0 To item.WBSDistributeCollection.Count - 1
        '      WBSCode &= item.WBSDistributeCollection.Item(i).WBS.Code
        '      WBSCodePercent &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Percent, DigitConfig.Price) & "%)"
        '      WBSCodeAmount &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Amount, DigitConfig.Price) & ")"
        '      WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).BudgetRemain, DigitConfig.Price)
        '      WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).QtyRemain, DigitConfig.Price)
        '      If i < item.WBSDistributeCollection.Count - 1 Then
        '        WBSCode &= ", "
        '        WBSCodePercent &= ", "
        '        WBSCodeAmount &= ", "
        '        WBSRemainAmount &= ", "
        '        WBSRemainQty &= ", "
        '      End If
        '    Next
        '  End If
        'End If

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

        '  n += 1
        'Next
        'If item.InternalChargeCollection.Count = 0 Then
        '  n += 1
        'End If
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


  End Class



End Namespace
