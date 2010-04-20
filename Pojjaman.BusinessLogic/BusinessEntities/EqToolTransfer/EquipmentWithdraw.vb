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
    Public Interface IHasRentalRate
        Inherits IHasName
    Property RentalRate() As Decimal
    End Interface
    Public Class AssetWithdraw
        Inherits SimpleBusinessEntityBase
    Implements IHasToCostCenter, IHasFromCostCenter, ICancelable, IPrintableEntity, ICheckPeriod


#Region "Members"
        Private m_isExternal As Boolean
        Private m_docDate As Date
        Private m_withdrawperson As IBillablePerson
        Private m_withdrawcc As CostCenter
        Private m_storeperson As Employee
        Private m_storecc As CostCenter
        Private m_note As String
        Private m_customer As Customer

        Private m_itemCollection As AssetWithdrawItemCollection
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
                .m_isExternal = False
                .m_docDate = Now.Date
                .m_note = ""
                .m_withdrawperson = New Employee
                .m_withdrawcc = New CostCenter

                .m_storeperson = New Employee
                .m_storecc = New CostCenter
                .m_customer = New Customer
            End With
            m_itemCollection = New AssetWithdrawItemCollection(Me)
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
                ' WithDraw Person

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isexternal") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isexternal") Then
                    .m_isExternal = CBool(dr(aliasPrefix & Me.Prefix & "_isexternal"))
                End If

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


                ' WithDraw Costcenter
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

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
                    Me.Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
                End If

                ''''
                If dr.Table.Columns.Contains(aliasPrefix & "stock_entity") Then
                    If Not dr.IsNull("stock_entity") Then
                        .m_customer = New Customer(CInt(dr("stock_entity")))
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") Then
                        If Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
                            .m_customer = New Customer(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
                        End If
                    End If
                End If

            End With
            m_itemCollection = New AssetWithdrawItemCollection(Me)
        End Sub
#End Region

#Region "Properties"

        Public Property ItemCollection() As AssetWithdrawItemCollection
            Get
                Return m_itemCollection
            End Get
            Set(ByVal Value As AssetWithdrawItemCollection)
                m_itemCollection = Value
            End Set
        End Property
        Public Property IsExternal() As Boolean
            Get
                Return m_isExternal
            End Get
            Set(ByVal Value As Boolean)
                m_isExternal = Value
            End Set
        End Property
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public Property Withdrawperson() As IBillablePerson      Get
        Return m_withdrawperson
      End Get      Set(ByVal Value As IBillablePerson)        m_withdrawperson = Value      End Set    End Property    Public Property WithdrawCostcenter() As CostCenter      Get        Return m_withdrawcc      End Get      Set(ByVal Value As CostCenter)        m_withdrawcc = Value      End Set    End Property    Public Property Storeperson() As Employee      Get        Return m_storeperson      End Get      Set(ByVal Value As Employee)        m_storeperson = Value      End Set    End Property    Public Property StoreCostcenter() As CostCenter      Get        Return m_storecc      End Get      Set(ByVal Value As CostCenter)        m_storecc = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Customer() As Customer
      Get
        Return m_customer
      End Get
      Set(ByVal Value As Customer)
        m_customer = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AssetWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetWithdraw.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AssetWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AssetWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetWithdraw.ListLabel}"
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
            Dim myDatatable As New TreeTable("AssetWithdraw")
            ' Get from StockItem ...
            myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Type", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))
            Return myDatatable
        End Function
#End Region

#Region "Methods"
        Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
            Dim ret As Decimal = 0
            For Each item As AssetWithdrawItem In Me.ItemCollection
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
            For Each item As AssetWithdrawItem In Me.ItemCollection
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
                If TypeOf Me.Withdrawperson Is SimpleBusinessEntityBase Then
                    person = CType(Me.Withdrawperson, SimpleBusinessEntityBase)
                End If
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toCCPerson", Me.ValidIdOrDBNull(person)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", Me.ValidIdOrDBNull(Me.WithdrawCostcenter)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isexternal", Me.IsExternal))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.ValidIdOrDBNull(Me.Customer)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", 2))

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

                    SaveDetail(Me.Id, conn, trans)

                    Me.DeleteRef(conn, trans)
                    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
                    , New SqlParameter("@refto_id", Me.Id))
                    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
                    , New SqlParameter("@refto_id", Me.Id))
                    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
                    , New SqlParameter("@refto_id", Me.Id))
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
            For Each item As AssetWithdrawItem In Me.ItemCollection
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

            Dim da As New SqlDataAdapter("Select * from StockItem Where Stocki_stock = " & Me.Id, conn)
            Dim daOldRef As New SqlDataAdapter("Select * from asset where asset_id in (select stocki_entity from stockitem where stocki_stock =" & Me.Id & ")", conn)
            Dim daWbs As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ")", conn)
            Dim daItc As New SqlDataAdapter("Select * from internalchargeitem where itci_refsequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ")", conn)

            Dim daNewRef As SqlDataAdapter
            Dim refIds As String = Me.GetRefIdString
            If refIds.Length > 0 Then
                daNewRef = New SqlDataAdapter("Select * from asset where asset_id in (" & refIds & ")", conn)
            End If

            Dim ds As New DataSet

            Dim cmdBuilder As New SqlCommandBuilder(da)
            da.SelectCommand.Transaction = trans
            da.DeleteCommand = cmdBuilder.GetDeleteCommand
            da.DeleteCommand.Transaction = trans
            da.InsertCommand = cmdBuilder.GetInsertCommand
            da.InsertCommand.Transaction = trans
            da.UpdateCommand = cmdBuilder.GetUpdateCommand
            da.UpdateCommand.Transaction = trans
            da.InsertCommand.CommandText &= "; Select * From stockitem Where stocki_sequence = @@IDENTITY"
            da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
            cmdBuilder = Nothing
            da.FillSchema(ds, SchemaType.Mapped, "stockitem")
            da.Fill(ds, "stockitem")

            cmdBuilder = New SqlCommandBuilder(daWbs)
            daWbs.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans
            cmdBuilder = Nothing
            daWbs.FillSchema(ds, SchemaType.Mapped, "stockiwbs")
            daWbs.Fill(ds, "stockiwbs")
            ds.Relations.Add("sequence", ds.Tables!stockitem.Columns!stocki_sequence, ds.Tables!stockiwbs.Columns!stockiw_sequence)

            cmdBuilder = New SqlCommandBuilder(daItc)
            daItc.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans
            cmdBuilder = Nothing
            daItc.FillSchema(ds, SchemaType.Mapped, "internalchargeitem")
            daItc.Fill(ds, "internalchargeitem")
            ds.Relations.Add("sequence_2", ds.Tables!stockitem.Columns!stocki_sequence, ds.Tables!internalchargeitem.Columns!itci_refsequence)

            cmdBuilder = New SqlCommandBuilder(daOldRef)
            daOldRef.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans
            cmdBuilder = Nothing
            daOldRef.FillSchema(ds, SchemaType.Mapped, "oldAsset")
            daOldRef.Fill(ds, "oldAsset")

            Dim dtNewRef As DataTable
            If Not daNewRef Is Nothing Then
                cmdBuilder = New SqlCommandBuilder(daNewRef)
                daNewRef.SelectCommand.Transaction = trans
                cmdBuilder.GetDeleteCommand.Transaction = trans
                cmdBuilder.GetInsertCommand.Transaction = trans
                cmdBuilder.GetUpdateCommand.Transaction = trans
                cmdBuilder = Nothing
                daNewRef.FillSchema(ds, SchemaType.Mapped, "newAsset")
                daNewRef.Fill(ds, "newAsset")
                dtNewRef = ds.Tables("newAsset")
                For Each row As DataRow In dtNewRef.Rows
                    If Not row.IsNull("asset_status") AndAlso IsNumeric(row("asset_status")) Then
                        If CInt(row("asset_status")) = 1 Then 'ว่าง
                            row("asset_status") = 2 'เบิกใช้
                        End If
                    End If
                Next
            End If

            Dim dt As DataTable = ds.Tables("stockitem")
            Dim dc As DataColumn = dt.Columns!stocki_sequence
            dc.AutoIncrement = True
            dc.AutoIncrementSeed = -1
            dc.AutoIncrementStep = -1

            Dim dtWbs As DataTable = ds.Tables("stockiwbs")
            Dim dtItc As DataTable = ds.Tables("internalchargeitem")

            Dim dtOldRef As DataTable = ds.Tables("oldAsset")


            For Each row As DataRow In dtOldRef.Rows
                Dim found As Boolean = False
                For Each item As AssetWithdrawItem In Me.ItemCollection
                    If item.Entity.Id = CInt(row("asset_id")) Then
                        'เจอแล้ว --> 
                        found = True
                        Exit For
                    End If
                Next
                If Not found Then
                    'ไม่เจอ
                    If Not row.IsNull("asset_status") AndAlso IsNumeric(row("asset_status")) Then
                        If CInt(row("asset_status")) = 2 Then 'เบิก
                            row("asset_status") = 1 'ว่าง
                        End If
                    End If
                End If
            Next

            For Each row As DataRow In ds.Tables("stockiwbs").Rows
                row.Delete()
            Next
            For Each row As DataRow In dtItc.Rows
                row.Delete()
            Next

            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteStockItem", _
                New SqlParameter("@stocki_stock", Me.Id))

            Dim i As Integer = 0 'Line Running
            With ds.Tables("stockitem")
                For Each row As DataRow In .Rows
                    row.Delete()
                Next
                For Each item As AssetWithdrawItem In Me.ItemCollection
                    Dim dr As DataRow = .NewRow

                    dr("stocki_stock") = Me.Id
                    dr("stocki_linenumber") = i

                    dr("stocki_cc") = DBNull.Value
                    dr("stocki_fromcc") = Me.ValidIdOrDBNull(Me.StoreCostcenter)

                    dr("stocki_refsequence") = 0

                    dr("stocki_tocc") = Me.ValidIdOrDBNull(Me.WithdrawCostcenter)
                    If Me.IsExternal Then
                        dr("stocki_tocust") = Me.Customer.Id
                    Else
                        dr("stocki_tocust") = DBNull.Value
                    End If
                    dr("stocki_toacct") = DBNull.Value
                    dr("stocki_toAcctType") = 3

                    dr("stocki_entity") = item.Entity.Id
                    dr("stocki_entityType") = item.ItemType.Value
                    dr("stocki_itemName") = item.Entity.Name
                    dr("stocki_qty") = item.Qty
                    dr("stocki_stockqty") = item.Qty

                    dr("stocki_note") = item.Note
                    dr("stocki_type") = Me.EntityId
                    dr("stocki_status") = Me.Status.Value
                    .Rows.Add(dr)

                    Dim itcLine As Integer = 0
                    For Each itc As InternalCharge In item.InternalChargeCollection
                        itcLine += 1
                        Dim childDr As DataRow = dtItc.NewRow
                        childDr("itci_linenumber") = itcLine 'itc.Linenumber
                        childDr("itci_refsequence") = dr("stocki_sequence")
                        childDr("itci_ispercent") = itc.Ispercent
                        childDr("itci_isfixed") = itc.IsFixed
                        childDr("itci_rate") = itc.Rate
                        childDr("itci_startdate") = itc.StartDate
                        childDr("itci_enddate") = itc.EndDate
                        childDr("itci_name") = itc.Name
                        childDr("itci_note") = itc.Note
                        childDr("itci_type") = CInt(itc.Type)
                        dtItc.Rows.Add(childDr)
                    Next

                    If Not Me.WithdrawCostcenter.Boq Is Nothing AndAlso Me.WithdrawCostcenter.Boq.Originated Then
                        Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
                        Dim rootWBS As New WBS(Me.WithdrawCostcenter.RootWBSId)
                        Dim currentSum As Decimal = wbsdColl.GetSumPercent
                        For Each wbsd As WBSDistribute In wbsdColl
                            If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                                'ยังไม่เต็ม 100 แต่มีหัวอยู่
                                wbsd.Percent += (100 - currentSum)
                            End If
                            wbsd.BaseCost = item.Amount
                            wbsd.TransferBaseCost = item.Amount
                            Dim childDr As DataRow = dtWbs.NewRow
                            childDr("stockiw_wbs") = wbsd.WBS.Id
                            If wbsd.CostCenter Is Nothing Then
                                wbsd.CostCenter = Me.WithdrawCostcenter
                            End If
                            childDr("stockiw_cc") = wbsd.CostCenter.Id
                            childDr("stockiw_percent") = wbsd.Percent
                            childDr("stockiw_sequence") = dr("stocki_sequence")
                            childDr("stockiw_ismarkup") = wbsd.IsMarkup
                            childDr("stockiw_direction") = 0 'in
                            'childDr("stockiw_baseCost") = wbsd.BaseCost
                            'childDr("stockiw_transferbaseCost") = wbsd.TransferBaseCost
                            'childDr("stockiw_transferamt") = wbsd.TransferAmount
                            'childDr("stockiw_amt") = wbsd.Amount
                            childDr("stockiw_toaccttype") = 3
                            'Add เข้า stockiwbs
                            dtWbs.Rows.Add(childDr)
                        Next

                        currentSum = wbsdColl.GetSumPercent
                        'ยังไม่เต็ม 100 และยังไม่มี root
                        If currentSum < 100 Then
                            Try
                                Dim newWbsd As New WBSDistribute
                                newWbsd.WBS = rootWBS
                                newWbsd.CostCenter = item.AssetWithdraw.WithdrawCostcenter
                                newWbsd.Percent = 100 - currentSum
                                newWbsd.BaseCost = item.Amount
                                newWbsd.TransferBaseCost = item.Amount
                                Dim childDr As DataRow = dtWbs.NewRow
                                childDr("stockiw_wbs") = newWbsd.WBS.Id
                                childDr("stockiw_cc") = newWbsd.CostCenter.Id
                                childDr("stockiw_percent") = newWbsd.Percent
                                childDr("stockiw_sequence") = dr("stocki_sequence")
                                childDr("stockiw_ismarkup") = False
                                childDr("stockiw_direction") = 0 'in
                                'childDr("stockiw_baseCost") = newWbsd.BaseCost
                                'childDr("stockiw_transferbaseCost") = newWbsd.TransferBaseCost
                                'childDr("stockiw_transferamt") = newWbsd.TransferAmount
                                'childDr("stockiw_amt") = newWbsd.Amount
                                childDr("stockiw_toaccttype") = 3
                                'Add เข้า stockiwbs
                                dtWbs.Rows.Add(childDr)
                            Catch ex As Exception
                                MessageBox.Show(ex.ToString)
                            End Try
                        End If
                    End If
                    'Dim childDr As DataRow = dtitc.NewRow
                    'childDr("itc_refsequence") = dr("stocki_sequence")
                    'childDr("itc_linenumber") = 1
                    'childDr("itc_rate") = item.Asset.RentalRate
                    'childDr("itc_startdate") = Me.DocDate
                    'childDr("itc_type") = 1 '1=ปกติ 2=หยุด 3=ลดราคา
                    'dtitc.Rows.Add(childDr)
                Next
            End With

            Dim tmpDa As New SqlDataAdapter
            tmpDa.DeleteCommand = da.DeleteCommand
            tmpDa.InsertCommand = da.InsertCommand
            tmpDa.UpdateCommand = da.UpdateCommand

            AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
            AddHandler daOldRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
            If Not daNewRef Is Nothing Then
                AddHandler daNewRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
            End If
            AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated
            AddHandler daItc.RowUpdated, AddressOf daItc_MyRowUpdated

            daItc.Update(GetDeletedRows(dtItc))
            daWbs.Update(GetDeletedRows(dtWbs))
            daOldRef.Update(GetDeletedRows(dtOldRef))
            tmpDa.Update(GetDeletedRows(dt))
            If Not daNewRef Is Nothing Then
                daNewRef.Update(GetDeletedRows(dtNewRef))
            End If

            tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
            daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.ModifiedCurrent))
            If Not daNewRef Is Nothing Then
                daNewRef.Update(dtNewRef.Select("", "", DataViewRowState.ModifiedCurrent))
            End If
            daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))
            daItc.Update(dtItc.Select("", "", DataViewRowState.ModifiedCurrent))

            tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
            daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.Added))
            If Not daNewRef Is Nothing Then
                da.Update(dtNewRef.Select("", "", DataViewRowState.Added))
            End If
            ds.EnforceConstraints = False
            daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
            daItc.Update(dtItc.Select("", "", DataViewRowState.Added))
            ds.EnforceConstraints = True

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
                Return Me.m_withdrawcc
            End Get
            Set(ByVal Value As CostCenter)
                m_withdrawcc = Value
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAssetWithdraw", New SqlParameter() {New SqlParameter("@stock_id", Me.Id), returnVal})
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
            For Each item As AssetWithdrawItem In Me.ItemCollection
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

                For Each itc As InternalCharge In item.InternalChargeCollection
                    'Item.DateStart
                    dpi = New DocPrintingItem
                    dpi.Mapping = "Item.DateStart"
                    dpi.Value = itc.StartDate.ToShortDateString
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    'Item.DateEnd
                    dpi = New DocPrintingItem
                    dpi.Mapping = "Item.DateEnd"
                    dpi.Value = itc.EndDate.ToShortDateString
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    'Item.Details
                    dpi = New DocPrintingItem
                    dpi.Mapping = "Item.Details"
                    dpi.Value = itc.Name
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    'Item.Rate
                    dpi = New DocPrintingItem
                    dpi.Mapping = "Item.Rate"
                    Dim rate As String = Configuration.FormatToString(itc.Rate, DigitConfig.Price)
                    If itc.Ispercent Then
                        rate &= " %"
                    End If
                    dpi.Value = rate
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    'Item.Amount
                    dpi = New DocPrintingItem
                    dpi.Mapping = "Item.Amount"
                    dpi.Value = Configuration.FormatToString(itc.Amount, DigitConfig.Price)
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    n += 1
                Next
                If item.InternalChargeCollection.Count = 0 Then
                    n += 1
                End If
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

    Public Class AssetWithdrawItem

#Region "Members"
        Private m_assetWithdraw As AssetWithdraw
        Private m_lineNumber As Integer
        Private m_sequenceRefedto As Integer
        Private m_entity As IHasRentalRate
        Private m_note As String
        Private m_amount As Decimal

        Private m_sequence As Integer

        Private m_itemtype As ItemType

        Private m_qty As Integer = 1

        Private m_WBSDistributeCollection As WBSDistributeCollection
        Private m_internalChargeCollection As InternalChargeCollection
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            m_WBSDistributeCollection = New WBSDistributeCollection
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
                If dr.Table.Columns.Contains(aliasPrefix & "stocki_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_lineNumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & "stocki_lineNumber"))
                End If

                ' Sequence Refed to ...
                If dr.Table.Columns.Contains(aliasPrefix & "refto") AndAlso Not dr.IsNull(aliasPrefix & "refto") Then
                    .m_sequenceRefedto = CInt(dr(aliasPrefix & "refto"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "stocki_entityType") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entityType") Then
                    .m_itemtype = New ItemType(CInt(dr(aliasPrefix & "stocki_entityType")))
                End If

                Dim itemId As Integer

                If dr.Table.Columns.Contains(aliasPrefix & "stocki_entity") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entity") Then
                    itemId = CInt(dr(aliasPrefix & "stocki_entity"))
                End If

                Select Case .m_itemtype.Value
                    Case 19 '"tool"
                        If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
                            If Not dr.IsNull("tool_id") Then
                                .m_entity = New Tool(dr, "")
                            End If
                        Else
                            .m_entity = New Tool(itemId)
                        End If
                    Case 28
                        If dr.Table.Columns.Contains("asset_id") AndAlso Not dr.IsNull("asset_id") Then
                            If Not dr.IsNull("asset_id") Then
                                .m_entity = New Asset(dr, "")
                            End If
                        Else
                            .m_entity = New Asset(itemId)
                        End If
                End Select
                If dr.Table.Columns.Contains(aliasPrefix & "stocki_qty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_qty") Then
                    .m_qty = CInt(dr(aliasPrefix & "stocki_qty"))
                End If
                ' Stock Note ...
                If dr.Table.Columns.Contains(aliasPrefix & "stocki_note") AndAlso Not dr.IsNull(aliasPrefix & "stocki_note") Then
                    .m_note = CStr(dr(aliasPrefix & "stocki_note"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "stocki_sequence") AndAlso Not dr.IsNull(aliasPrefix & "stocki_sequence") Then
                    m_sequence = CInt(dr(aliasPrefix & "stocki_sequence"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "stocki_amt") AndAlso Not dr.IsNull(aliasPrefix & "stocki_amt") Then
                    m_amount = CDec(dr(aliasPrefix & "stocki_amt"))
                End If
            End With
        End Sub
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Property WBSDistributeCollection() As WBSDistributeCollection            Get                Return m_WBSDistributeCollection            End Get            Set(ByVal Value As WBSDistributeCollection)                m_WBSDistributeCollection = Value            End Set        End Property
        Public Property InternalChargeCollection() As InternalChargeCollection            Get                If m_internalChargeCollection Is Nothing Then                    m_internalChargeCollection = New InternalChargeCollection(Me)
                End If                Return m_internalChargeCollection            End Get            Set(ByVal Value As InternalChargeCollection)                m_internalChargeCollection = Value            End Set        End Property
        Public Property ItemType() As ItemType            Get                Return m_itemtype            End Get            Set(ByVal Value As ItemType)                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                If m_itemtype Is Nothing Then
                    m_itemtype = Value
                    Me.Clear()
                    Return
                End If
                If Not Value Is Nothing AndAlso Value.Value = m_itemtype.Value Then
                    'ผ่านโลด
                    Return
                End If
                If m_itemtype Is Nothing OrElse m_itemtype.Value = 0 OrElse msgServ.AskQuestion("${res:Global.Question.ChangeAssetWithdrawEntityType}") Then
                    m_itemtype = Value
                    'Me.Clear()
                End If            End Set        End Property
        Public ReadOnly Property Sequence() As Integer            Get                Return m_sequence            End Get        End Property
        Public ReadOnly Property Amount() As Decimal            Get                Return m_amount            End Get        End Property
        Public Property AssetWithdraw() As AssetWithdraw            Get                Return m_assetWithdraw            End Get            Set(ByVal Value As AssetWithdraw)                m_assetWithdraw = Value            End Set        End Property        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property SequenceRefedto() As Integer            Get                Return m_sequenceRefedto            End Get            Set(ByVal Value As Integer)                m_sequenceRefedto = Value            End Set        End Property        Public Function DupCode(ByVal myCode As String) As Boolean            If Me.AssetWithdraw Is Nothing Then                Return False
            End If            If myCode Is Nothing OrElse myCode.Length = 0 Then
                Return False
            End If
            For Each item As AssetWithdrawItem In Me.AssetWithdraw.ItemCollection
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
        End Function        Public Sub SetItemCode(ByVal theCode As String)            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.ItemType Is Nothing Then
                'ไม่มี Type
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                Return
            End If
            'If DupCode(theCode) Then
            '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {"Asset", theCode})
            '    Return
            'End If
            Select Case Me.ItemType.Value
                Case 28 'F/A
                    If theCode Is Nothing OrElse theCode.Length = 0 Then
                        If Me.Entity.Code.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {Me.Entity.Code}) Then
                                Me.Clear()
                            End If
                        End If
                        Return
                    End If
                    Dim myAsset As New Asset(theCode)
                    If Not myAsset.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoAsset}", New String() {theCode})
                        Return
                    Else
                        Me.m_entity = myAsset
                    End If
                Case 19 'Tool
                    If theCode Is Nothing OrElse theCode.Length = 0 Then
                        If Me.Entity.Code.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {Me.Entity.Code}) Then
                                Me.Clear()
                            End If
                        End If
                        Return
                    End If
                    Dim myTool As New Tool(theCode)
                    If Not myTool.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {theCode})
                        Return
                    Else
                        Me.m_entity = myTool
                    End If
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    Return
            End Select
            Me.m_qty = 1
        End Sub        Public Property Entity() As IHasRentalRate            Get                Return m_entity            End Get            Set(ByVal Value As IHasRentalRate)                m_entity = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public Property Qty() As Integer            Get                If Not Me.m_itemtype Is Nothing Then                    If Me.m_itemtype.Value = 28 Then
                        m_qty = 1
                    End If
                End If                Return m_qty            End Get            Set(ByVal Value As Integer)                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                If Me.ItemType Is Nothing Then
                    'ไม่มี Type
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    Return
                End If
                If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
                    'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
                    msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
                    Return
                End If                m_qty = CInt(Configuration.Format(Value, DigitConfig.Int))            End Set        End Property#End Region

#Region "Methods"
        Public Sub Clear()
            Me.m_entity = New Asset
            Me.m_qty = 0
            Me.m_note = ""
        End Sub
        Public Sub ItemValidateRow(ByVal row As DataRow)
            Dim code As Object = row("Code")
        End Sub
        Public Sub CopyToDataRow(ByVal row As TreeRow)

            If row Is Nothing Then
                Return
            End If
            Try
                Me.AssetWithdraw.IsInitialized = False

                row("Linenumber") = Me.LineNumber
                row("Type") = Me.ItemType.Value
                If Not Me.Entity Is Nothing Then
                    row("Code") = Me.Entity.Code
                    row("Name") = Me.Entity.Name
                End If
                row("Button") = ""

                row("Note") = Me.Note

                If Me.Qty <> 0 Then
                    row("QTY") = Configuration.FormatToString(Me.Qty, DigitConfig.Int)
                Else
                    row("QTY") = ""
                End If

                Me.AssetWithdraw.IsInitialized = True
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try
        End Sub
#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
    Public Class AssetWithdrawItemCollection
        Inherits CollectionBase

#Region "Members"
        Private m_assetWithdraw As AssetWithdraw
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal owner As AssetWithdraw)
            Me.m_assetWithdraw = owner
            If Not Me.m_assetWithdraw.Originated Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetAssetWithdrawItems" _
            , New SqlParameter("@stock_id", Me.m_assetWithdraw.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New AssetWithdrawItem(row, "")
                item.AssetWithdraw = m_assetWithdraw
                Me.Add(item)
                Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
                item.WBSDistributeCollection = wbsdColl
                For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & item.Sequence)
                    Dim wbsd As New WBSDistribute(wbsRow, "")
                    wbsdColl.Add(wbsd)
                Next

                Dim itcColl As New InternalChargeCollection(item)
                item.InternalChargeCollection = itcColl
                For Each itcRow As DataRow In ds.Tables(2).Select("itci_refsequence=" & item.Sequence)
                    Dim itc As New InternalCharge(itcRow, "")
                    itcColl.Add(itc)
                Next
            Next
        End Sub
#End Region

#Region "Properties"
        Public Property AssetWithdraw() As AssetWithdraw            Get                Return m_assetWithdraw            End Get            Set(ByVal Value As AssetWithdraw)                m_assetWithdraw = Value            End Set        End Property        Default Public Property Item(ByVal index As Integer) As AssetWithdrawItem
            Get
                Return CType(MyBase.List.Item(index), AssetWithdrawItem)
            End Get
            Set(ByVal value As AssetWithdrawItem)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Sub Populate(ByVal dt As TreeTable)
            dt.Clear()
            Dim i As Integer = 0
            For Each gri As AssetWithdrawItem In Me
                i += 1
                Dim newRow As TreeRow = dt.Childs.Add()
                gri.CopyToDataRow(newRow)
                gri.ItemValidateRow(newRow)
                newRow.Tag = gri
            Next
            dt.AcceptChanges()
        End Sub
#End Region

#Region "Collection Methods"
        Public Overridable Function Add(ByVal value As AssetWithdrawItem) As Integer
            If Not m_assetWithdraw Is Nothing Then
                value.AssetWithdraw = m_assetWithdraw
            End If
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As AssetWithdrawItemCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As AssetWithdrawItem())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As AssetWithdrawItem) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As AssetWithdrawItem(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As AssetWithdrawItemEnumerator
            Return New AssetWithdrawItemEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As AssetWithdrawItem) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Overridable Sub Insert(ByVal index As Integer, ByVal value As AssetWithdrawItem)
            If Not m_assetWithdraw Is Nothing Then
                value.AssetWithdraw = m_assetWithdraw
            End If
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As AssetWithdrawItem)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As AssetWithdrawItemCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region

        Public Class AssetWithdrawItemEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As AssetWithdrawItemCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, AssetWithdrawItem)
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                Return Me.m_baseEnumerator.MoveNext
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                Me.m_baseEnumerator.Reset()
            End Sub
        End Class
    End Class

    Public Class InternalCharge
        '1=ปกติ 2=หยุด 3=ลดราคา
        Public Enum InternalChargeType
            Normal = 1
            [Stop] = 2
            Discount = 3
        End Enum
#Region "Members"
        Private m_parentitem As AssetWithdrawItem

        Private m_name As String
        Private m_note As String
        Private m_linenumber As Integer
        Private m_startDate As Date
        Private m_endDate As Date
        Private m_type As InternalChargeType
        Private m_rate As Decimal
        Private m_ispercent As Boolean
        Private m_isfixed As Boolean
#End Region

#Region "Constructors"
        Public Sub New()

        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                ' Start date
                If dr.Table.Columns.Contains(aliasPrefix & "itci_startDate") _
                AndAlso Not dr.IsNull(aliasPrefix & "itci_startDate") Then
                    .m_startDate = CDate(dr(aliasPrefix & "itci_startDate"))
                End If

                ' End date
                If dr.Table.Columns.Contains(aliasPrefix & "itci_endDate") _
                AndAlso Not dr.IsNull(aliasPrefix & "itci_endDate") Then
                    .m_endDate = CDate(dr(aliasPrefix & "itci_endDate"))
                End If

                ' Line number ...
                If dr.Table.Columns.Contains(aliasPrefix & "itci_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "itci_lineNumber") Then
                    .m_linenumber = CInt(dr(aliasPrefix & "itci_lineNumber"))
                End If

                ' Name
                If dr.Table.Columns.Contains(aliasPrefix & "itci_name") AndAlso Not dr.IsNull(aliasPrefix & "itci_name") Then
                    .m_name = CStr(dr(aliasPrefix & "itci_name"))
                End If

                ' Note
                If dr.Table.Columns.Contains(aliasPrefix & "itci_note") AndAlso Not dr.IsNull(aliasPrefix & "itci_note") Then
                    .m_note = CStr(dr(aliasPrefix & "itci_note"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "itci_rate") AndAlso Not dr.IsNull(aliasPrefix & "itci_rate") Then
                    m_rate = CDec(dr(aliasPrefix & "itci_rate"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "itci_ispercent") AndAlso Not dr.IsNull(aliasPrefix & "itci_ispercent") Then
                    m_ispercent = CBool(dr(aliasPrefix & "itci_ispercent"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "itci_isfixed") AndAlso Not dr.IsNull(aliasPrefix & "itci_isfixed") Then
                    m_isfixed = CBool(dr(aliasPrefix & "itci_isfixed"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "itci_type") AndAlso Not dr.IsNull(aliasPrefix & "itci_type") Then
                    .m_type = CType([Enum].Parse(GetType(InternalChargeType), CStr(dr(aliasPrefix & "itci_type"))), InternalChargeType)
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Parentitem() As AssetWithdrawItem            Get                Return m_parentitem            End Get            Set(ByVal Value As AssetWithdrawItem)                m_parentitem = Value            End Set        End Property        Public Property Name() As String            Get                Return m_name            End Get            Set(ByVal Value As String)                m_name = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public Property Linenumber() As Integer            Get                Return m_linenumber            End Get            Set(ByVal Value As Integer)                m_linenumber = Value            End Set        End Property        Public Property StartDate() As Date            Get                Return m_startDate            End Get            Set(ByVal Value As Date)                m_startDate = Value            End Set        End Property        Public Property EndDate() As Date            Get                Return m_endDate            End Get            Set(ByVal Value As Date)                m_endDate = Value            End Set        End Property        Public Property Type() As InternalChargeType            Get                Return m_type            End Get            Set(ByVal Value As InternalChargeType)                m_type = Value            End Set        End Property        Public Property Rate() As Decimal            Get                Return m_rate            End Get            Set(ByVal Value As Decimal)                m_rate = Value            End Set        End Property        Public Property Ispercent() As Boolean            Get                Return m_ispercent            End Get            Set(ByVal Value As Boolean)                m_ispercent = Value            End Set        End Property
        Public Property IsFixed() As Boolean            Get                Return m_isfixed            End Get            Set(ByVal Value As Boolean)                m_isfixed = Value            End Set        End Property
        Public ReadOnly Property Amount() As Decimal
            Get
                Try
                    Return GetAmount(Me.Parentitem.Entity.RentalRate * Me.Parentitem.Qty)
                Catch ex As Exception
                    Return 0
                End Try
            End Get
        End Property
        Public Function GetAmount(ByVal assetRate As Decimal) As Decimal
            If Ispercent Then
                Return Me.m_rate * CDec(0.01) * assetRate
            End If
            Return Me.m_rate
        End Function
        Public Function Days() As Integer
            Dim ts As TimeSpan = Me.EndDate.Subtract(Me.StartDate)
            Return ts.Days
        End Function
#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
    Public Class InternalChargeCollection
        Inherits CollectionBase

#Region "Members"
        Private m_parent As AssetWithdrawItem
#End Region

#Region "Constructors"
        Public Sub New(ByVal parent As AssetWithdrawItem)
            m_parent = parent
        End Sub
        Public Sub New(ByVal sequence As Integer)
            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetInternalChargeItemsFromSequence" _
            , New SqlParameter("@stocki_sequence", sequence) _
            )

            For Each itcRow As DataRow In ds.Tables(0).Rows
                Dim itc As New InternalCharge(itcRow, "")
                Me.Add(itc)
            Next
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As InternalCharge
            Get
                Return CType(MyBase.List.Item(index), InternalCharge)
            End Get
            Set(ByVal value As InternalCharge)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Sub Populate(ByVal dt As TreeTable)
            dt.Clear()
            Dim i As Integer = 0
            For Each itc As InternalCharge In Me
                i += 1
                Dim newRow As TreeRow = dt.Childs.Add()
                newRow("Linenumber") = i
                newRow("Name") = itc.Name
                newRow("StartDate") = itc.StartDate
                newRow("EndDate") = itc.EndDate
                newRow("Rate") = Configuration.FormatToString(itc.Rate, DigitConfig.Price)
                newRow("IsPercent") = itc.Ispercent
                newRow("IsFixed") = itc.IsFixed
                newRow("Amount") = Configuration.FormatToString(itc.Amount, DigitConfig.Price)
                newRow("Type") = CInt(itc.Type)
                newRow.Tag = itc
            Next
        End Sub
        Public Sub Populate(ByVal grid As GridControl, ByVal month As Date)

        End Sub
#End Region

#Region "Shared"
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("InternalCharge")
            myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))

            Dim dateCol As New DataColumn("StartDate", GetType(Date))
            dateCol.DefaultValue = Date.MinValue
            myDatatable.Columns.Add(dateCol)

            dateCol = New DataColumn("EndDate", GetType(Date))
            dateCol.DefaultValue = Date.MinValue
            myDatatable.Columns.Add(dateCol)

            myDatatable.Columns.Add(New DataColumn("Rate", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("IsPercent", GetType(Boolean)))
            myDatatable.Columns.Add(New DataColumn("IsFixed", GetType(Boolean)))
            myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Type", GetType(Integer)))
            Return myDatatable
        End Function
#End Region

#Region "Collection Methods"
        Public Overridable Function Add(ByVal value As InternalCharge) As Integer
            value.Parentitem = m_parent
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As InternalChargeCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As InternalCharge())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As InternalCharge) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As InternalCharge(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As InternalChargeEnumerator
            Return New InternalChargeEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As InternalCharge) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Overridable Sub Insert(ByVal index As Integer, ByVal value As InternalCharge)
            value.Parentitem = m_parent
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As InternalCharge)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As InternalChargeCollection)
            For i As Integer = 0 To value.Count - 1
                value(i).Parentitem = Nothing
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            Me(index).Parentitem = Nothing
            MyBase.List.RemoveAt(index)
        End Sub
#End Region

        Public Class InternalChargeEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As InternalChargeCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, InternalCharge)
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                Return Me.m_baseEnumerator.MoveNext
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                Me.m_baseEnumerator.Reset()
            End Sub
        End Class
    End Class
End Namespace
