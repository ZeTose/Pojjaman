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

  Public Class EquipmentToolReturn
    Inherits SimpleBusinessEntityBase
    Implements IHasToCostCenter, IHasFromCostCenter, ICancelable, IPrintableEntity, ICheckPeriod


#Region "Members"
    Private m_docDate As Date
    Private m_Returnperson As Employee
    Private m_Returncc As CostCenter
    Private m_storeperson As Employee
    Private m_storecc As CostCenter
    Private m_note As String
    Private m_tostatus As EqtStatus
    Private m_fromstatus As EqtStatus
    Private m_itemCollection As EquipmentToolReturnItemCollection
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
        .m_Returnperson = New Employee
        .m_Returncc = New CostCenter

        .m_storeperson = New Employee
        .m_storecc = New CostCenter
        .m_fromstatus = New EqtStatus(3)
        .m_tostatus = New EqtStatus(2)
      End With
      m_itemCollection = New EquipmentToolReturnItemCollection(Me)
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
        ' Return Person

        'If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isexternal") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isexternal") Then
        '  .m_isExternal = CBool(dr(aliasPrefix & Me.Prefix & "_isexternal"))
        'End If

        'If .m_isExternal Then
        '    ' Customer ...
        '    If dr.Table.Columns.Contains(aliasPrefix & "ReturnCustomer.cust_id") Then
        '        If Not dr.IsNull("ReturnCustomer.cust_id") Then
        '            .m_Returnperson = New Customer(dr, "ReturnCustomer.")
        '        End If
        '    Else
        '        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_toCCPerson") Then
        '            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_toCCPerson") Then
        '                .m_Returnperson = New Customer(CInt(dr(aliasPrefix & Me.Prefix & "_toCCPerson")))
        '            End If
        '        End If
        '    End If

        'Else
        ' Employee ...
        If dr.Table.Columns.Contains(aliasPrefix & "ReturnEmployee.employee_id") Then
          If Not dr.IsNull("ReturnEmployee.employee_id") Then
            .m_Returnperson = New Employee(dr, "ReturnEmployee.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_toCCPerson") Then
            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_toCCPerson") Then
              .m_Returnperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_toCCPerson")))
            End If
          End If
        End If
        'End If


        ' Return Costcenter
        If dr.Table.Columns.Contains(aliasPrefix & "Returncostcenter.cc_id") Then
          If Not dr.IsNull("Returncostcenter.cc_id") Then
            .m_Returncc = New CostCenter(dr, "Returncostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_tocc") Then
            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_tocc") Then
              .m_Returncc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_tocc")))
            End If
          End If
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
      m_itemCollection = New EquipmentToolReturnItemCollection(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property ItemCollection() As EquipmentToolReturnItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As EquipmentToolReturnItemCollection)
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
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        RefreshRental()      End Set    End Property    Public Property ReturnPerson() As Employee
      Get
        Return m_Returnperson
      End Get      Set(ByVal Value As Employee)
        m_Returnperson = Value      End Set    End Property    Public Property ReturnCostcenter() As CostCenter      Get        Return m_Returncc      End Get      Set(ByVal Value As CostCenter)        m_Returncc = Value      End Set    End Property    Public Property Storeperson() As Employee      Get        Return m_storeperson      End Get      Set(ByVal Value As Employee)        m_storeperson = Value      End Set    End Property    Public Property StoreCostcenter() As CostCenter      Get        Return m_storecc      End Get      Set(ByVal Value As CostCenter)        m_storecc = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    'Public Property Customer() As Customer
    '  Get
    '    Return m_customer
    '  End Get
    '  Set(ByVal Value As Customer)
    '    m_customer = Value
    '  End Set
    'End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "EquipmentToolReturn"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.EqtReturn.DetailLabel}"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.EqtReturn.ListLabel}"
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
      myDatatable.Columns.Add(New DataColumn("Type", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("eqtstocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RentalPerDay", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RentalQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RentalAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Sub RefreshRental()
      For Each item As EquipmentToolReturnItem In Me.ItemCollection
        item.RentalQty = CInt(DateDiff(DateInterval.Day, item.RefDoc.DocDate, Me.DocDate))
      Next
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim proposedCode As Object = row("code")
      Dim proposedQty As Object = row("RentalAmount")

      If (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") _
          Or (Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0) _
          Then
        Return False
      End If
      Return True
    End Function
    Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
      Dim ret As Decimal = 0
      For Each item As EquipmentToolReturnItem In Me.ItemCollection
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
      For Each item As EquipmentToolReturnItem In Me.ItemCollection
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
        If TypeOf Me.ReturnPerson Is SimpleBusinessEntityBase Then
          person = CType(Me.ReturnPerson, SimpleBusinessEntityBase)
        End If
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toCCPerson", Me.ValidIdOrDBNull(person)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", Me.ValidIdOrDBNull(Me.ReturnCostcenter)))
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

          Me.DeleteRef(conn, trans)
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQTStock_Ref" _
          , New SqlParameter("@refto_id", Me.Id))
          'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
          ', New SqlParameter("@refto_id", Me.Id))
          'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
          ', New SqlParameter("@refto_id", Me.Id))
          If Me.Status.Value = 0 Then
            Me.CancelRef(conn, trans)
          End If

          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          ResetId(oldid)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          ResetId(oldid)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function GetRefIdString() As String
      Dim ret As String = ""
      For Each item As EquipmentToolReturnItem In Me.ItemCollection
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


        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        'da.InsertCommand.CommandText &= "; Select * From stockitem Where stocki_sequence = @@IDENTITY"
        'da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "Eqtstockitem")
        da.Fill(ds, "Eqtstockitem")



        Dim dt As DataTable = ds.Tables("Eqtstockitem")

        'Dim EqtDt As DataTable = GetEqiLastSequence()


        Dim i As Integer = 0 'Line Running
        With ds.Tables("Eqtstockitem")
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          For Each item As EquipmentToolReturnItem In Me.ItemCollection
            Dim dr As DataRow = .NewRow
            'Dim row() As DataRow = EqtDt.Select("eqtstocki_entity =" & item.Entity.Id.ToString)
            i += 1
            dr("eqtstocki_eqtstock") = Me.Id
            dr("eqtstocki_linenumber") = i

            dr("eqtstocki_fromstatus") = Me.FromStatus.Value
            dr("eqtstocki_tostatus") = Me.ToStatus.Value

            dr("eqtstocki_entity") = item.Entity.Id
            dr("eqtstocki_entityType") = item.ItemType.Value
            dr("eqtstocki_Name") = item.Entity.Name

            dr("eqtstocki_qty") = item.Qty
            dr("eqtstocki_unit") = item.Unit.Id

            dr("eqtstocki_rentalrate") = item.RentalPerDay  'คิดจากจำนวนแล้ว
            dr("eqtstocki_rentalqty") = item.RentalQty
            dr("eqtstocki_amount") = item.Amount

            'If row.Length > 0 Then
            dr("eqtstocki_refsequence") = item.RefItem.Sequence
            'dr("eqtstocki_refsequence") = row(0)("id")

            'End If
            dr("eqtstocki_note") = item.Note
            dr("eqtstocki_type") = 351

            .Rows.Add(dr)


          Next
        End With

        da.Update(dt.Select("", "", DataViewRowState.Added))

        ds.EnforceConstraints = False

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated


        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))

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
        Dim currentkey As Integer = CInt(e.Row("stockiw_sequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!stockiw_sequence = e.Row.GetParentRow("sequence")("stocki_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!stockiw_sequence = currentkey
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
        Return Me.m_Returncc
      End Get
      Set(ByVal Value As CostCenter)
        m_Returncc = Value
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteEqtReturn", New SqlParameter() {New SqlParameter("@eqtstock_id", Me.Id), returnVal})
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

      If Not Me.ReturnPerson Is Nothing Then
        'ToPerson
        dpi = New DocPrintingItem
        dpi.Mapping = "ToPerson"
        dpi.Value = Me.ReturnPerson.Code & ":" & Me.ReturnPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToPersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToPersonInfo"
        dpi.Value = Me.ReturnPerson.Code & ":" & Me.ReturnPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToPersonName
        dpi = New DocPrintingItem
        dpi.Mapping = "ToPersonName"
        dpi.Value = Me.ReturnPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToPersonCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ToPersonCode"
        dpi.Value = Me.ReturnPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.ReturnCostcenter Is Nothing AndAlso Me.ReturnCostcenter.Originated Then
        'ToCostCenter
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenter"
        dpi.Value = Me.ReturnCostcenter.Code & ":" & Me.ReturnCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterInfo"
        dpi.Value = Me.ReturnCostcenter.Code & ":" & Me.ReturnCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterCode"
        dpi.Value = Me.ReturnCostcenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterName"
        dpi.Value = Me.ReturnCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterPhone"
        dpi.Value = Me.ReturnCostcenter.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterFax
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterFax"
        dpi.Value = Me.ReturnCostcenter.Fax
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
      For Each item As EquipmentToolReturnItem In Me.ItemCollection
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



  Public Class EquipmentToolReturnItem
    Inherits EqtItem

#Region "Members"
    Private m_eqtReturn As EquipmentToolReturn
    Private m_Refsequence As Integer 'อาจไม่ต้องมีแล้ว
    Private m_refdoc As EquipmentToolWithdraw

    Private m_ewi As EquipmentToolWithdrawItem
    Private m_rentalqty As Integer
    Private m_rentalperday As Decimal
    Private m_rentalAmt As Decimal


    '' อ้างอิงใบเบิกเดิม

    'Private m_WBSDistributeCollection As WBSDistributeCollection
    'Private m_internalChargeCollection As InternalChargeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_ewi = New EquipmentToolWithdrawItem

      'm_WBSDistributeCollection = New WBSDistributeCollection
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overrides Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        Dim deh As New DataRowHelper(dr)

        .m_rentalperday = deh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_rentalrate")
        .m_rentalqty = deh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_rentalqty")
        .m_rentalAmt = deh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_Amount")

        ' Sequence Refed to ...
        .m_Refsequence = deh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_refsequence")

        .m_refdoc = New EquipmentToolWithdraw
        .m_refdoc.Id = deh.GetValue(Of Integer)(aliasPrefix & "eqtstock_id")
        .m_refdoc.Code = deh.GetValue(Of String)(aliasPrefix & "eqtstock_code")
        .m_refdoc.DocDate = deh.GetValue(Of Date)(aliasPrefix & "eqtstock_docdate")

        .m_ewi = New EquipmentToolWithdrawItem(dr, "")

      End With
    End Sub
    Protected Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    'Public Property WBSDistributeCollection() As WBSDistributeCollection    '  Get    '    Return m_WBSDistributeCollection    '  End Get    '  Set(ByVal Value As WBSDistributeCollection)    '    m_WBSDistributeCollection = Value    '  End Set    'End Property
    'Public Property InternalChargeCollection() As InternalChargeCollection    '  Get    '    If m_internalChargeCollection Is Nothing Then    '      m_internalChargeCollection = New InternalChargeCollection(Me)
    '    End If    '    Return m_internalChargeCollection    '  End Get    '  Set(ByVal Value As InternalChargeCollection)    '    m_internalChargeCollection = Value    '  End Set    'End Property

    'Public ReadOnly Property Sequence() As Integer    '  Get    '    Return m_sequence    '  End Get    'End Property
    Public Overrides Property Qty() As Integer      Get        If Not Me.m_itemtype Is Nothing Then          If Me.m_itemtype.Value = 342 OrElse Me.m_itemtype.Value = 28 Then
            m_qty = 1
          End If
        End If        Return m_qty      End Get      Set(ByVal Value As Integer)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
          'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
          Return
        End If        m_qty = CInt(Configuration.Format(Value, DigitConfig.Int))        RentalPerDay = m_qty * Entity.RentalRate      End Set    End Property
    Public Property RentalPerDay() As Decimal      Get        Return m_rentalperday      End Get      Set(ByVal value As Decimal)
        m_rentalperday = value
        m_rentalAmt = m_rentalperday * m_rentalqty
      End Set    End Property
    Public Property RentalQty() As Integer
      Get        Return m_rentalqty
      End Get      Set(ByVal value As Integer)
        m_rentalqty = value
        m_rentalAmt = m_rentalperday * m_rentalqty
      End Set
    End Property
    Public Property Amount() As Decimal      Get        Return m_rentalAmt      End Get      Set(ByVal value As Decimal)
        m_rentalAmt = value
        If m_rentalqty > 0 Then
          m_rentalperday = m_rentalAmt / m_rentalqty

        End If
      End Set    End Property
    Public Property EqtReturn() As EquipmentToolReturn
      Get        Return m_eqtReturn      End Get      Set(ByVal Value As EquipmentToolReturn)        m_eqtReturn = Value      End Set    End Property    Public Property RefDoc As EquipmentToolWithdraw
      Get
        Return m_refdoc
      End Get
      Set(ByVal value As EquipmentToolWithdraw)
        m_refdoc = value
      End Set
    End Property

    Public Property RefItem() As EquipmentToolWithdrawItem      Get        Return m_ewi      End Get      Set(ByVal Value As EquipmentToolWithdrawItem)        m_ewi = Value      End Set    End Property

    Public Property RefSequence() As Integer      Get        Return m_Refsequence      End Get      Set(ByVal Value As Integer)        m_Refsequence = Value      End Set    End Property    Public Function DupCode(ByVal myCode As String) As Boolean      If Me.EqtReturn Is Nothing Then
        Return False
      End If      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As EquipmentToolReturnItem In Me.EqtReturn.ItemCollection
        If Not item Is Me Then
          Dim theCode As String = ""
          If Not item.Entity Is Nothing Then
            theCode = item.Entity.Code
          End If
          If Not theCode Is Nothing AndAlso theCode.Length > 0 Then
            If myCode.ToLower = theCode.ToLower Then
              Return True
            End If
          End If
        End If
      Next
      Return False
    End Function    'Public Sub SetItemCode(ByVal theCode As String)    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  If Me.ItemType Is Nothing Then
    '    'ไม่มี Type
    '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '    Return
    '  End If
    '  'If DupCode(theCode) Then
    '  '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {"Asset", theCode})
    '  '    Return
    '  'End If
    '  Select Case Me.ItemType.Value
    '    Case 342 'F/A
    '      If theCode Is Nothing OrElse theCode.Length = 0 Then
    '        If Me.Entity.Code.Length <> 0 Then
    '          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {Me.Entity.Code}) Then
    '            Me.Clear()
    '          End If
    '        End If
    '        Return
    '      End If
    '      Dim myEquipment As New EquipmentItem(theCode)
    '      If Not myEquipment.Originated Then
    '        msgServ.ShowMessageFormatted("${res:Global.Error.NoAsset}", New String() {theCode})
    '        Return
    '      Else
    '        Me.Entity = myEquipment
    '      End If
    '    Case 19 'Tool
    '      If theCode Is Nothing OrElse theCode.Length = 0 Then
    '        If Me.Entity.Code.Length <> 0 Then
    '          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {Me.Entity.Code}) Then
    '            Me.Clear()
    '          End If
    '        End If
    '        Return
    '      End If
    '      Dim myTool As New Tool(theCode)
    '      If Not myTool.Originated Then
    '        msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {theCode})
    '        Return
    '      Else
    '        Me.Entity = myTool
    '      End If
    '    Case Else
    '      msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '      Return
    '  End Select
    '  Me.Qty = 1
    'End Sub
#End Region

#Region "Methods"
    'Public Sub Clear()
    '  'Me.Entity = New EquipmentToolReturnItem
    '  Me.Qty = 0
    '  Me.Note = ""
    'End Sub
    Public Overrides Sub ItemValidateRow(ByVal row As DataRow)
      MyBase.ItemValidateRow(row)
      'Dim code As Object = row("Code")
    End Sub
    Public Overrides Sub CopyToDataRow(ByVal row As TreeRow)
      'MyBase.CopyToDataRow(row)
      If row Is Nothing Then
        Return
      End If
      Try
        Me.EqtReturn.IsInitialized = False
        Dim rpd As Decimal = 0
        Dim rentrate As Decimal = 0
        row("Linenumber") = Me.LineNumber
        row("Type") = Me.ItemType.Value
        If Not Me.Entity Is Nothing Then
          row("eqtstocki_entity") = Me.Entity.Id
          row("Code") = Me.Entity.Code
          row("Name") = Me.Entity.Name
          If Not Me.Entity.Unit Is Nothing Then
            Me.Unit = Me.Entity.Unit
            row("UnitName") = Me.Entity.Unit.Name
          End If
          rentrate = Me.Entity.RentalRate
        End If

        'row("Name") = Me.name

        row("Button") = ""

        row("Note") = Me.Note

        If Me.Qty <> 0 Then
          row("QTY") = Configuration.FormatToString(Me.Qty, DigitConfig.Int)
        Else
          row("QTY") = ""
        End If
        rpd = rentrate * Me.Qty
        If Me.RentalPerDay <> 0 And rpd <> 0 Then
          If Me.RentalPerDay <> 0 Then
            row("RentalPerDay") = Configuration.FormatToString(Me.RentalPerDay, DigitConfig.Price)
          Else
            row("RentalPerDay") = Configuration.FormatToString(rpd, DigitConfig.Price)
            Me.RentalPerDay = rpd
          End If
        Else
          row("RentalPerDay") = ""
        End If
        row("RentalQty") = Me.RentalQty
        row("RentalAmount") = Me.Amount
        Me.EqtReturn.IsInitialized = True
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class EquipmentToolReturnItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_eqtReturn As EquipmentToolReturn
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As EquipmentToolReturn)
      Me.m_eqtReturn = owner
      If Not Me.m_eqtReturn.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEquipmentToolReturnItems" _
      , New SqlParameter("@eqtstock_id", Me.m_eqtReturn.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New EquipmentToolReturnItem(row, "")
        item.EqtReturn = m_eqtReturn
        Me.Add(item)
        'Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        'item.WBSDistributeCollection = wbsdColl
        'For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & item.Sequence)
        '  Dim wbsd As New WBSDistribute(wbsRow, "")
        '  wbsdColl.Add(wbsd)
        'Next

        'Dim itcColl As New InternalChargeCollection(item)
        'item.InternalChargeCollection = itcColl
        'For Each itcRow As DataRow In ds.Tables(2).Select("itci_refsequence=" & item.Sequence)
        '  Dim itc As New InternalCharge(itcRow, "")
        '  itcColl.Add(itc)
        'Next
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property EqtReturn() As EquipmentToolReturn
      Get        Return m_eqtReturn
      End Get      Set(ByVal Value As EquipmentToolReturn)        m_eqtReturn = Value
      End Set    End Property    Default Public Property Item(ByVal index As Integer) As EquipmentToolReturnItem
      Get
        Return CType(MyBase.List.Item(index), EquipmentToolReturnItem)
      End Get
      Set(ByVal value As EquipmentToolReturnItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property CurrentItem() As EquipmentToolReturnItem
    '  Get
    '    Return m_currentItem
    '  End Get
    '  Set(ByVal Value As EqtItem)
    '    m_currentItem = Value
    '  End Set
    'End Property
    Public ReadOnly Property Gross As Decimal
      Get
        Dim ret As Decimal = 0
        For Each Item As EquipmentToolReturnItem In Me
          ret += Item.Amount
        Next
        Return ret
      End Get
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      'Dim i As Integer = 0
      'For Each gri As EquipmentToolReturnItem In Me
      '  i += 1
      '  Dim newRow As TreeRow = dt.Childs.Add()
      '  gri.CopyToDataRow(newRow)
      '  gri.ItemValidateRow(newRow)
      '  newRow.Tag = gri
      'Next
      'dt.AcceptChanges()

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim prRowHash As New Hashtable
      Dim parRow As TreeRow

      For Each eri As EquipmentToolReturnItem In Me
        parRow = Nothing
        If Not eri.RefItem Is Nothing _
         AndAlso eri.RefDoc.Originated Then
          If Not prRowHash.Contains(eri.RefDoc.Id) Then
            parRow = dt.Childs.Add
            parRow("Code") = eri.RefDoc.Code
            parRow("Name") = eri.RefDoc.DocDate.ToString
            parRow("Button") = "invisible"
            parRow.State = RowExpandState.Expanded
            prRowHash(eri.RefDoc.Id) = parRow
          Else
            parRow = CType(prRowHash(eri.RefDoc.Id), TreeRow)
          End If
          'Else ''ต้องมีการอ้างอิงเท่านั้น
          '  'แบบไม่มี PR
          '  If Not prRowHash.Contains(0) Then
          '    parRow = dt.Childs.Add
          '    parRow("PRItemCode") = noPRText
          '    parRow("Button") = "invisible"
          '    parRow("UnitButton") = "invisible"
          '    parRow.State = RowExpandState.Expanded
          '    prRowHash(0) = parRow
          '  Else
          '    parRow = CType(prRowHash(0), TreeRow)
          '  End If
        End If

        Dim newRow As TreeRow = parRow.Childs.Add()
        eri.CopyToDataRow(newRow)
        eri.ItemValidateRow(newRow)
        newRow.Tag = eri
      Next
      dt.AcceptChanges()
    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As EquipmentToolReturnItem) As Integer
      If Not m_eqtReturn Is Nothing Then
        value.EqtReturn = m_eqtReturn
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As EquipmentToolReturnItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As EquipmentToolReturnItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As EquipmentToolReturnItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As EquipmentToolReturnItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As EquipmentToolReturnItemEnumerator
      Return New EquipmentToolReturnItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As EquipmentToolReturnItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As EquipmentToolReturnItem)
      If Not m_eqtReturn Is Nothing Then
        value.EqtReturn = m_eqtReturn
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentToolReturnItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentToolReturnItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class EquipmentToolReturnItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As EquipmentToolReturnItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, EquipmentToolReturnItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class

    Function EqIdList() As Object
      Dim list As New Generic.List(Of String)
      For Each i As EquipmentToolReturnItem In Me
        If TypeOf i.Entity Is EquipmentItem Then
          list.Add(i.Entity.Id.ToString)
        End If
      Next
      Return String.Join(",", list)

    End Function

  End Class

  Public Class ToCostcenter
    Inherits CostCenter
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal Id As Integer)
      MyBase.New(Id)
    End Sub
    Public Sub New(ByVal Code As String)
      MyBase.New(Code)
    End Sub
  End Class

  Public Class fromCostcenter
    Inherits CostCenter
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal Id As Integer)
      MyBase.New(Id)
    End Sub
    Public Sub New(ByVal Code As String)
      MyBase.New(Code)
    End Sub
  End Class
  '  Public Class InternalCharge
  '    '1=ปกติ 2=หยุด 3=ลดราคา
  '    Public Enum InternalChargeType
  '      Normal = 1
  '      [Stop] = 2
  '      Discount = 3
  '    End Enum
  '#Region "Members"
  '    Private m_parentitem As EquipmentToolReturnItem

  '    Private m_name As String
  '    Private m_note As String
  '    Private m_linenumber As Integer
  '    Private m_startDate As Date
  '    Private m_endDate As Date
  '    Private m_type As InternalChargeType
  '    Private m_rate As Decimal
  '    Private m_ispercent As Boolean
  '    Private m_isfixed As Boolean
  '#End Region

  '#Region "Constructors"
  '    Public Sub New()

  '    End Sub
  '    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
  '      With Me
  '        ' Start date
  '        If dr.Table.Columns.Contains(aliasPrefix & "itci_startDate") _
  '        AndAlso Not dr.IsNull(aliasPrefix & "itci_startDate") Then
  '          .m_startDate = CDate(dr(aliasPrefix & "itci_startDate"))
  '        End If

  '        ' End date
  '        If dr.Table.Columns.Contains(aliasPrefix & "itci_endDate") _
  '        AndAlso Not dr.IsNull(aliasPrefix & "itci_endDate") Then
  '          .m_endDate = CDate(dr(aliasPrefix & "itci_endDate"))
  '        End If

  '        ' Line number ...
  '        If dr.Table.Columns.Contains(aliasPrefix & "itci_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "itci_lineNumber") Then
  '          .m_linenumber = CInt(dr(aliasPrefix & "itci_lineNumber"))
  '        End If

  '        ' Name
  '        If dr.Table.Columns.Contains(aliasPrefix & "itci_name") AndAlso Not dr.IsNull(aliasPrefix & "itci_name") Then
  '          .m_name = CStr(dr(aliasPrefix & "itci_name"))
  '        End If

  '        ' Note
  '        If dr.Table.Columns.Contains(aliasPrefix & "itci_note") AndAlso Not dr.IsNull(aliasPrefix & "itci_note") Then
  '          .m_note = CStr(dr(aliasPrefix & "itci_note"))
  '        End If

  '        If dr.Table.Columns.Contains(aliasPrefix & "itci_rate") AndAlso Not dr.IsNull(aliasPrefix & "itci_rate") Then
  '          m_rate = CDec(dr(aliasPrefix & "itci_rate"))
  '        End If

  '        If dr.Table.Columns.Contains(aliasPrefix & "itci_ispercent") AndAlso Not dr.IsNull(aliasPrefix & "itci_ispercent") Then
  '          m_ispercent = CBool(dr(aliasPrefix & "itci_ispercent"))
  '        End If

  '        If dr.Table.Columns.Contains(aliasPrefix & "itci_isfixed") AndAlso Not dr.IsNull(aliasPrefix & "itci_isfixed") Then
  '          m_isfixed = CBool(dr(aliasPrefix & "itci_isfixed"))
  '        End If

  '        If dr.Table.Columns.Contains(aliasPrefix & "itci_type") AndAlso Not dr.IsNull(aliasPrefix & "itci_type") Then
  '          .m_type = CType([Enum].Parse(GetType(InternalChargeType), CStr(dr(aliasPrefix & "itci_type"))), InternalChargeType)
  '        End If
  '      End With
  '    End Sub
  '#End Region

  '#Region "Properties"
  '    Public Property Parentitem() As EquipmentToolReturnItem  '      Get  '        Return m_parentitem  '      End Get  '      Set(ByVal Value As EquipmentToolReturnItem)  '        m_parentitem = Value  '      End Set  '    End Property  '    Public Property Name() As String  '      Get  '        Return m_name  '      End Get  '      Set(ByVal Value As String)  '        m_name = Value  '      End Set  '    End Property  '    Public Property Note() As String  '      Get  '        Return m_note  '      End Get  '      Set(ByVal Value As String)  '        m_note = Value  '      End Set  '    End Property  '    Public Property Linenumber() As Integer  '      Get  '        Return m_linenumber  '      End Get  '      Set(ByVal Value As Integer)  '        m_linenumber = Value  '      End Set  '    End Property  '    Public Property StartDate() As Date  '      Get  '        Return m_startDate  '      End Get  '      Set(ByVal Value As Date)  '        m_startDate = Value  '      End Set  '    End Property  '    Public Property EndDate() As Date  '      Get  '        Return m_endDate  '      End Get  '      Set(ByVal Value As Date)  '        m_endDate = Value  '      End Set  '    End Property  '    Public Property Type() As InternalChargeType  '      Get  '        Return m_type  '      End Get  '      Set(ByVal Value As InternalChargeType)  '        m_type = Value  '      End Set  '    End Property  '    Public Property Rate() As Decimal  '      Get  '        Return m_rate  '      End Get  '      Set(ByVal Value As Decimal)  '        m_rate = Value  '      End Set  '    End Property  '    Public Property Ispercent() As Boolean  '      Get  '        Return m_ispercent  '      End Get  '      Set(ByVal Value As Boolean)  '        m_ispercent = Value  '      End Set  '    End Property
  '    Public Property IsFixed() As Boolean  '      Get  '        Return m_isfixed  '      End Get  '      Set(ByVal Value As Boolean)  '        m_isfixed = Value  '      End Set  '    End Property
  '    Public ReadOnly Property Amount() As Decimal
  '      Get
  '        Try
  '          Return GetAmount(Me.Parentitem.Entity.RentalRate * Me.Parentitem.Qty)
  '        Catch ex As Exception
  '          Return 0
  '        End Try
  '      End Get
  '    End Property
  '    Public Function GetAmount(ByVal assetRate As Decimal) As Decimal
  '      If Ispercent Then
  '        Return Me.m_rate * CDec(0.01) * assetRate
  '      End If
  '      Return Me.m_rate
  '    End Function
  '    Public Function Days() As Integer
  '      Dim ts As TimeSpan = Me.EndDate.Subtract(Me.StartDate)
  '      Return ts.Days
  '    End Function
  '#End Region

  '  End Class

  '<Serializable(), DefaultMember("Item")> _
  '  Public Class InternalChargeCollection
  '    Inherits CollectionBase

  '#Region "Members"
  '    Private m_parent As EquipmentToolReturnItem
  '#End Region

  '#Region "Constructors"
  '    Public Sub New(ByVal parent As EquipmentToolReturnItem)
  '      m_parent = parent
  '    End Sub
  '    Public Sub New(ByVal sequence As Integer)
  '      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

  '      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
  '      , CommandType.StoredProcedure _
  '      , "GetInternalChargeItemsFromSequence" _
  '      , New SqlParameter("@stocki_sequence", sequence) _
  '      )

  '      For Each itcRow As DataRow In ds.Tables(0).Rows
  '        Dim itc As New InternalCharge(itcRow, "")
  '        Me.Add(itc)
  '      Next
  '    End Sub
  '#End Region

  '#Region "Properties"
  '    Default Public Property Item(ByVal index As Integer) As InternalCharge
  '      Get
  '        Return CType(MyBase.List.Item(index), InternalCharge)
  '      End Get
  '      Set(ByVal value As InternalCharge)
  '        MyBase.List.Item(index) = value
  '      End Set
  '    End Property
  '#End Region

  '#Region "Class Methods"
  '    Public Sub Populate(ByVal dt As TreeTable)
  '      dt.Clear()
  '      Dim i As Integer = 0
  '      For Each itc As InternalCharge In Me
  '        i += 1
  '        Dim newRow As TreeRow = dt.Childs.Add()
  '        newRow("Linenumber") = i
  '        newRow("Name") = itc.Name
  '        newRow("StartDate") = itc.StartDate
  '        newRow("EndDate") = itc.EndDate
  '        newRow("Rate") = Configuration.FormatToString(itc.Rate, DigitConfig.Price)
  '        newRow("IsPercent") = itc.Ispercent
  '        newRow("IsFixed") = itc.IsFixed
  '        newRow("Amount") = Configuration.FormatToString(itc.Amount, DigitConfig.Price)
  '        newRow("Type") = CInt(itc.Type)
  '        newRow.Tag = itc
  '      Next
  '    End Sub
  '    Public Sub Populate(ByVal grid As GridControl, ByVal month As Date)

  '    End Sub
  '#End Region

  '#Region "Shared"
  '    Public Shared Function GetSchemaTable() As TreeTable
  '      Dim myDatatable As New TreeTable("InternalCharge")
  '      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
  '      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))

  '      Dim dateCol As New DataColumn("StartDate", GetType(Date))
  '      dateCol.DefaultValue = Date.MinValue
  '      myDatatable.Columns.Add(dateCol)

  '      dateCol = New DataColumn("EndDate", GetType(Date))
  '      dateCol.DefaultValue = Date.MinValue
  '      myDatatable.Columns.Add(dateCol)

  '      myDatatable.Columns.Add(New DataColumn("Rate", GetType(String)))
  '      myDatatable.Columns.Add(New DataColumn("IsPercent", GetType(Boolean)))
  '      myDatatable.Columns.Add(New DataColumn("IsFixed", GetType(Boolean)))
  '      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
  '      myDatatable.Columns.Add(New DataColumn("Type", GetType(Integer)))
  '      Return myDatatable
  '    End Function
  '#End Region

  '#Region "Collection Methods"
  '    Public Overridable Function Add(ByVal value As InternalCharge) As Integer
  '      value.Parentitem = m_parent
  '      Return MyBase.List.Add(value)
  '    End Function
  '    Public Sub AddRange(ByVal value As InternalChargeCollection)
  '      For i As Integer = 0 To value.Count - 1
  '        Me.Add(value(i))
  '      Next
  '    End Sub
  '    Public Sub AddRange(ByVal value As InternalCharge())
  '      For i As Integer = 0 To value.Length - 1
  '        Me.Add(value(i))
  '      Next
  '    End Sub
  '    Public Function Contains(ByVal value As InternalCharge) As Boolean
  '      Return MyBase.List.Contains(value)
  '    End Function
  '    Public Sub CopyTo(ByVal array As InternalCharge(), ByVal index As Integer)
  '      MyBase.List.CopyTo(array, index)
  '    End Sub
  '    Public Shadows Function GetEnumerator() As InternalChargeEnumerator
  '      Return New InternalChargeEnumerator(Me)
  '    End Function
  '    Public Function IndexOf(ByVal value As InternalCharge) As Integer
  '      Return MyBase.List.IndexOf(value)
  '    End Function
  '    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As InternalCharge)
  '      value.Parentitem = m_parent
  '      MyBase.List.Insert(index, value)
  '    End Sub
  '    Public Sub Remove(ByVal value As InternalCharge)
  '      MyBase.List.Remove(value)
  '    End Sub
  '    Public Sub Remove(ByVal value As InternalChargeCollection)
  '      For i As Integer = 0 To value.Count - 1
  '        value(i).Parentitem = Nothing
  '        Me.Remove(value(i))
  '      Next
  '    End Sub
  '    Public Sub Remove(ByVal index As Integer)
  '      Me(index).Parentitem = Nothing
  '      MyBase.List.RemoveAt(index)
  '    End Sub
  '#End Region

  '    Public Class InternalChargeEnumerator
  '      Implements IEnumerator

  '#Region "Members"
  '      Private m_baseEnumerator As IEnumerator
  '      Private m_temp As IEnumerable
  '#End Region

  '#Region "Construtor"
  '      Public Sub New(ByVal mappings As InternalChargeCollection)
  '        Me.m_temp = mappings
  '        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
  '      End Sub
  '#End Region

  '      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
  '        Get
  '          Return CType(Me.m_baseEnumerator.Current, InternalCharge)
  '        End Get
  '      End Property

  '      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
  '        Return Me.m_baseEnumerator.MoveNext
  '      End Function

  '      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
  '        Me.m_baseEnumerator.Reset()
  '      End Sub
  '    End Class
  '  End Class
End Namespace
