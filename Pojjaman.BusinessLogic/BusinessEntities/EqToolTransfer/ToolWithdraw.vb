Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class ToolWithdraw
        Inherits SimpleBusinessEntityBase
        Implements IPrintableEntity, IHasToCostCenter, IHasFromCostCenter, ICancelable

#Region "Members"
        Private m_docDate As Date
        Private m_withdrawperson As Employee
        Private m_withdrawcc As CostCenter
        Private m_storeperson As Employee
        Private m_storecc As CostCenter
        Private m_note As String

        Private m_itemTable As TreeTable

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            ReLoadItems()
            'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf PRItemAdded)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
            ReLoadItems()
            'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf PRItemAdded)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
            ReLoadItems()
            'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf PRItemAdded)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
            ReLoadItems(ds, aliasPrefix)
            'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf PRItemAdded)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
            ReLoadItems()
            'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf PRItemAdded)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                .m_docDate = Now.Date
                .m_withdrawperson = New Employee
                .m_withdrawcc = New CostCenter
                .m_storeperson = New Employee
                .m_storecc = New CostCenter
            End With
            ReLoadItems()
            'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf PRItemAdded)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
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
                If dr.Table.Columns.Contains(aliasPrefix & "withdrawperson.employee_id") Then
                    If Not dr.IsNull("withdrawperson.employee_id") Then
                        .m_withdrawperson = New Employee(dr, "withdrawperson.")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_toCCPerson") Then
                        If Not dr.IsNull(aliasPrefix & Me.Prefix & "_toCCPerson") Then
                            .m_withdrawperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_toCCPerson")))
                        End If
                    End If
                End If
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
                ' Status
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
                    Me.Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
                End If

            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        ' Properties Base 
        Public Property ItemTable() As TreeTable            Get                Return m_itemTable            End Get            Set(ByVal Value As TreeTable)                m_itemTable = Value            End Set        End Property

        ' General properties
        Public Property DocDate() As Date            Get                Return m_docDate            End Get            Set(ByVal Value As Date)                m_docDate = Value            End Set        End Property        Public Property Withdrawperson() As Employee            Get                Return m_withdrawperson            End Get            Set(ByVal Value As Employee)                m_withdrawperson = Value            End Set        End Property        Public Property WithdrawCostcenter() As CostCenter            Get                Return m_withdrawcc            End Get            Set(ByVal Value As CostCenter)                m_withdrawcc = Value            End Set        End Property        Public Property Storeperson() As Employee            Get                Return m_storeperson            End Get            Set(ByVal Value As Employee)                m_storeperson = Value            End Set        End Property        Public Property StoreCostcenter() As CostCenter            Get                Return m_storecc            End Get            Set(ByVal Value As CostCenter)                m_storecc = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        ' Overrides Properties ...
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "toolwithdraw"
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

        ' Default properties
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.toolwithdraw.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.toolwithdraw"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.toolwithdraw"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.toolwithdraw.ListLabel}"
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
            Dim myDatatable As New TreeTable("StockItem")
            ' Get from StockItem ...
            myDatatable = StockItem.GetSchemaTable

            myDatatable.Columns.Add(New DataColumn("ToolGroup", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("codebutton", GetType(String)))

            Return myDatatable
        End Function
#End Region

#Region "Methods"
        Private Sub ResetId(ByVal oldid As Integer)
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

                If Me.Status.Value = -1 Then
                    Me.Status.Value = 2
                End If

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False

                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromCCPerson", IIf(Me.Storeperson.Originated, Me.Storeperson.Id, DBNull.Value)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromcc", IIf(Me.StoreCostcenter.Originated, Me.StoreCostcenter.Id, DBNull.Value)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toCCPerson", IIf(Me.Withdrawperson.Originated, Me.m_withdrawperson.Id, DBNull.Value)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", IIf(Me.WithdrawCostcenter.Originated, Me.WithdrawCostcenter.Id, DBNull.Value)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

                'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "", Me.)) ' เบิกไปใช้ในโครงการ


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

                    Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
                    If Not IsNumeric(saveDetailError.Message) Then
                        trans.Rollback()
                        ResetId(oldid)
                        Return saveDetailError
                    Else
                        Select Case CInt(saveDetailError.Message)
                            Case -1, -2, -5
                                trans.Rollback()
                                ResetId(oldid)
                                Return saveDetailError
                            Case Else
                        End Select
                    End If

                    Me.DeleteRef(conn, trans)
                    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
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
        Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException

            Dim sqlSelectText As String
            sqlSelectText = "Select * ,0 as [includingCost] From StockItem Where Stocki_stock = " & Me.Id
            Dim da As New SqlDataAdapter(sqlSelectText, conn)

            da.SelectCommand.Transaction = trans
            Dim GenSprocText As String

            GenSprocText = "EXEC [InsertFIFOStockItem] "
            GenSprocText += "@stocki_stock, "
            GenSprocText += "@stocki_lineNumber, "
            GenSprocText += "@stocki_cc, "
            GenSprocText += "@stocki_fromcc, "
            GenSprocText += "@stocki_tocc, "
            GenSprocText += "@stocki_toacct, "
            GenSprocText += "@stocki_toAcctType, "
            GenSprocText += "@stocki_refSequence, "
            GenSprocText += "@stocki_entity, "
            GenSprocText += "@stocki_entityType, "
            GenSprocText += "@stocki_itemname, "
            GenSprocText += "@stocki_unit, "
            GenSprocText += "@stocki_unitcost, "
            GenSprocText += "@stocki_amt, "
            GenSprocText += "@stocki_qty, "
            GenSprocText += "@stocki_stockqty, "
            GenSprocText += "@stocki_iscancelled, "
            GenSprocText += "@stocki_note, "
            GenSprocText += "@stocki_type, "
            GenSprocText += "@stocki_status, "
            GenSprocText += "@includingCost"

            Dim cmdInsert As New SqlCommand(GenSprocText, conn)
            'Dim cmdInsert As New SqlCommand("EXEC [InsertFIFOStockItem] @stocki_stock, @stocki_lineNumber, @stocki_cc, @stocki_tocc, @stocki_refSequence, @stocki_entity, @stocki_entityType, @stocki_itemname, @stocki_unit, @stocki_unitcost, @stocki_amt, @stocki_qty, @stocki_iscancelled, @stocki_note, @stocki_type, @stocki_status, @stocki_toAcctType, @includingCost", conn)

            cmdInsert.Parameters.Add("@stocki_stock", SqlDbType.Decimal, 18, "stocki_stock")
            cmdInsert.Parameters.Add("@stocki_lineNumber", SqlDbType.Decimal, 18, "stocki_lineNumber")

            cmdInsert.Parameters.Add("@stocki_cc", SqlDbType.Decimal, 18, "stocki_cc")
            cmdInsert.Parameters.Add("@stocki_fromcc", SqlDbType.Decimal, 18, "stocki_fromcc")

            cmdInsert.Parameters.Add("@stocki_tocc", SqlDbType.Decimal, 18, "stocki_tocc")
            cmdInsert.Parameters.Add("@stocki_toacct", SqlDbType.Decimal, 18, "stocki_toacct")
            cmdInsert.Parameters.Add("@stocki_toAcctType", SqlDbType.Decimal, 18, "stocki_toAcctType")

            cmdInsert.Parameters.Add("@stocki_refSequence", SqlDbType.Decimal, 18, "stocki_refSequence")

            cmdInsert.Parameters.Add("@stocki_entity", SqlDbType.Decimal, 18, "stocki_entity")
            cmdInsert.Parameters.Add("@stocki_entityType", SqlDbType.Decimal, 18, "stocki_entityType")
            cmdInsert.Parameters.Add("@stocki_itemname", SqlDbType.NVarChar, 1000, "stocki_itemname")

            cmdInsert.Parameters.Add("@stocki_unit", SqlDbType.Decimal, 18, "stocki_unit")
            cmdInsert.Parameters.Add("@stocki_unitcost", SqlDbType.Decimal, 18, "stocki_unitcost")
            cmdInsert.Parameters.Add("@stocki_amt", SqlDbType.Decimal, 18, "stocki_amt")
            cmdInsert.Parameters.Add("@stocki_qty", SqlDbType.Decimal, 18, "stocki_qty")
            cmdInsert.Parameters.Add("@stocki_stockqty", SqlDbType.Decimal, 18, "stocki_stockqty")

            cmdInsert.Parameters.Add("@stocki_iscancelled", SqlDbType.Bit, 4, "stocki_iscancelled")
            cmdInsert.Parameters.Add("@stocki_note", SqlDbType.NVarChar, 2000, "stocki_note")
            cmdInsert.Parameters.Add("@stocki_type", SqlDbType.Decimal, 18, "stocki_type")
            cmdInsert.Parameters.Add("@stocki_status", SqlDbType.Decimal, 18, "stocki_status")

            cmdInsert.Parameters.Add("@includingCost", SqlDbType.Bit, 4, "includingCost")

            cmdInsert.Transaction = trans
            da.InsertCommand = cmdInsert

            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteStockItem", _
            New SqlParameter("@stocki_stock", Me.Id))

            Dim ds As New DataSet
            da.Fill(ds, "stockitem")

            With ds.Tables("stockitem")
                'For Each row As DataRow In .Rows
                '    row.Delete()
                'Next
                For Each row As TreeRow In Me.ItemTable.Childs
                    If ValidateRow(row) Then
                        Dim dr As DataRow = .NewRow
                        Dim item As New StockItem
                        item.CopyFromDataRow(row)

                        dr("stocki_stock") = Me.Id
                        dr("stocki_linenumber") = item.LineNumber 'row("stocki_linenumber")

                        dr("stocki_cc") = DBNull.Value
                        dr("stocki_fromcc") = Me.ValidIdOrDBNull(Me.StoreCostcenter)

                        dr("stocki_tocc") = Me.ValidIdOrDBNull(Me.WithdrawCostcenter)
                        dr("stocki_toacct") = DBNull.Value
                        dr("stocki_toAcctType") = 3

                        dr("stocki_entity") = item.Entity.Id ' row("stocki_entity")
                        dr("stocki_entityType") = item.ItemType.Value 'row("stocki_entityType")
                        dr("stocki_itemName") = item.Itemname 'row("stocki_itemName")

                        dr("stocki_unit") = Me.ValidIdOrDBNull(item.Unit) ' row("stocki_unit")
                        dr("stocki_unitcost") = item.UnitCost ' row("stocki_unitcost")

                        dr("stocki_amt") = item.Amount 'row("stocki_amt")
                        dr("stocki_qty") = item.Qty ' row("stocki_qty")
                        dr("stocki_stockqty") = item.Qty ' row("stocki_qty")

                        dr("stocki_iscancelled") = item.Iscancelled ' row("stocki_iscancelled")
                        dr("stocki_note") = item.Note ' row("stocki_note")
                        dr("stocki_type") = Me.EntityId
                        dr("stocki_status") = Me.Status.Value  ' me.Status.Value 

                        dr("includingCost") = False

                        .Rows.Add(dr)
                    End If
                Next
            End With
            Dim dt As DataTable = ds.Tables("stockitem")
            ' First process deletes.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
            Return New SaveErrorException("1")
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
        Private Overloads Sub LoadItems()
            If Not Me.Originated Then
                Return
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
            , CommandType.StoredProcedure _
            , "GetStockItems" _
            , New SqlParameter("@stock_id", Me.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New StockItem(row, "")
        item.Stock = Me
        Me.Add(item)
      Next
    End Sub
    Private Overloads Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      For Each dr As DataRow In ds.Tables(1).Rows
        Dim item As New StockItem(dr, aliasPrefix)
        item.Stock = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim newItem As New BlankItem("")
        Dim myItem As New StockItem
        Dim newtool As New Tool
        myItem.Entity = newItem

        myItem.CostCenter = Me.StoreCostcenter
        myItem.Unit = New Unit
        myItem.Type = New StockDocType(Me.EntityId)   ' เบิกเครื่องมือ ..
        myItem.ItemType = New ItemType(newtool.EntityId)
        myItem.Status = New StockStatus(1)  ' ทั่วไป

        Me.ItemTable.AcceptChanges()
        Me.Add(myItem)
      Next
    End Sub
    Public Function Add(ByVal item As StockItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.Stock = Me

      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As StockItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.Stock = Me
      item.CopyToDataRow(myRow)
      ReIndex(index + 1)
      Return myRow
    End Function
        Public Sub Remove(ByVal index As Integer)
            Me.ItemTable.Childs.Remove(Me.ItemTable.Childs(index))
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
                Me.ItemTable.Childs(i)("stocki_lineNumber") = i + 1
            Next
        End Sub
        Public Function MaxRowIndex() As Integer
            If Me.m_itemTable Is Nothing Then
                Return -1
            End If
            'ให้ค่า index ของแถวสุดท้ายที่มีข้อมูล
            For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
                Dim row As TreeRow = Me.m_itemTable.Childs(i)
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
            Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                If index = Me.m_itemTable.Childs.Count - 1 Then
                    Me.AddBlankRow(1)
                End If
                Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
                Me.OnPropertyChanged(Me, pe)
                Me.m_itemTable.AcceptChanges()
            End If
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetEntityValue(e)
                    Case "unitcode"
                        SetUnitValue(e)
                    Case "stocki_qty"
                        SetQty(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim proposedUnit As Object = e.Row("unitcode")
            Dim proposedCode As Object = e.Row("Code")
            Dim proposedQty As Object = e.Row("stocki_qty")

            Select Case e.Column.ColumnName.ToLower
                Case "unitcode"
                    proposedUnit = e.ProposedValue
                Case "code"
                    proposedCode = e.ProposedValue
                Case "pri_qty"
                    proposedQty = e.ProposedValue
                Case Else
                    Return
            End Select

            If IsDBNull(proposedUnit) Then
                e.Row.SetColumnError("unitcode", Me.StringParserService.Parse("${res:Global.Error.UnitMissing}"))
            Else
                e.Row.SetColumnError("unitcode", "")
            End If

            If IsDBNull(proposedQty) Then
                e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.QtyMissing}"))
            Else
                e.Row.SetColumnError("stocki_qty", "")
            End If
        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Dim proposedCode As Object = row("code")
            Dim proposedQty As Object = row("stocki_qty")

            If (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") _
                And (Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0) _
                Then
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
        Private m_nameSetting As Boolean
        Public Sub SetEntityName(ByVal e As DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If
            m_nameSetting = True
            e.Row("stocki_entity") = DBNull.Value
            e.Row("stocki_entityType") = 0
            e.Row("Code") = DBNull.Value
            m_nameSetting = False
        End Sub
        Private m_entitySetting As Boolean = False
        Public Sub SetEntityValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            Me.IsInitialized = False

            If m_nameSetting Then
                Return
            End If

            Dim Err As String = ""
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

            Dim entity As New Tool(e.ProposedValue.ToString)

            m_entitySetting = True

            If entity.Originated Then
                Dim myUnit As Unit
                If TypeOf entity Is Tool Then
                    e.Row("stocki_entity") = entity.Id
                    e.Row("Name") = entity.Name
                    myUnit = entity.Unit
                    Dim itemtype As New itemtype(entity.EntityId)
                    e.Row("stocki_entityType") = itemtype.Value
                End If

                e.ProposedValue = entity.Code

                If Not myUnit Is Nothing AndAlso myUnit.Originated Then
                    e.Row("stocki_unit") = myUnit.Id
                    e.Row("UnitCode") = myUnit.Code
                    e.Row("UnitName") = myUnit.Name
                Else
                    e.Row("stocki_unit") = DBNull.Value
                    e.Row("UnitCode") = DBNull.Value
                    e.Row("UnitName") = DBNull.Value
                End If

                e.Row("stocki_qty") = 1
                e.Row("stocki_stockqty") = e.Row("stocki_qty")

            Else
                If e.ProposedValue.ToString.Length > 0 Then
                    Err = "${res:Global.Error.InvalidTool}"
                    msgServ.ShowMessage(Err)
                End If

                e.ProposedValue = DBNull.Value
                e.Row("Name") = DBNull.Value
                e.Row("UnitCode") = DBNull.Value
                e.Row("UnitName") = DBNull.Value
                e.Row("stocki_entity") = DBNull.Value
                e.Row("stocki_entityType") = DBNull.Value
                e.Row("stocki_cc") = DBNull.Value
                e.Row("stocki_unit") = DBNull.Value
                e.Row("stocki_type") = DBNull.Value
                e.Row("stocki_status") = DBNull.Value
                e.Row("stocki_qty") = 0
                e.Row("stocki_stockqty") = DBNull.Value
            End If

            m_entitySetting = False


            Me.IsInitialized = True
        End Sub
        Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If

            Me.IsInitialized = False

            Dim myUnit As New Unit(e.ProposedValue.ToString)
            If Not myUnit Is Nothing AndAlso myUnit.Valid Then
                e.ProposedValue = myUnit.Name
                e.Row("stocki_unit") = myUnit.Id
                e.Row("unitcode") = myUnit.Code
                e.Row("unitname") = myUnit.Name
            Else
                e.ProposedValue = DBNull.Value
                e.Row("stocki_unit") = DBNull.Value
                e.Row("unitcode") = DBNull.Value
                e.Row("unitname") = DBNull.Value
            End If

            Me.IsInitialized = True
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

        End Sub
#End Region

#Region "IPrintableEntity"
        Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
            Return ""
        End Function
        Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
            Return "TW"
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

            If Not Me.Withdrawperson Is Nothing AndAlso Me.Withdrawperson.Originated Then
                'Requestor
                dpi = New DocPrintingItem
                dpi.Mapping = "Requestor"
                dpi.Value = Me.Withdrawperson.Code & ":" & Me.Withdrawperson.Name
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            If Not Me.WithdrawCostcenter Is Nothing AndAlso Me.WithdrawCostcenter.Originated Then
                'DestCC
                dpi = New DocPrintingItem
                dpi.Mapping = "DestCC"
                dpi.Value = Me.WithdrawCostcenter.Code & ":" & Me.WithdrawCostcenter.Name
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            If Not Me.Storeperson Is Nothing AndAlso Me.Storeperson.Originated Then
                'StorePerson
                dpi = New DocPrintingItem
                dpi.Mapping = "StorePerson"
                dpi.Value = Me.Storeperson.Code & ":" & Me.Storeperson.Name
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            If Not Me.StoreCostcenter Is Nothing AndAlso Me.StoreCostcenter.Originated Then
                'OriginCC
                dpi = New DocPrintingItem
                dpi.Mapping = "OriginCC"
                dpi.Value = Me.StoreCostcenter.Code & ":" & Me.StoreCostcenter.Name
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            Dim n As Integer = 0
            For i As Integer = 0 To Me.MaxRowIndex
                Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
                If ValidateRow(itemRow) Then
                    Dim item As New StockItem
                    item.CopyFromDataRow(itemRow)
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

                    'Item.Name
                    dpi = New DocPrintingItem
                    dpi.Mapping = "Item.Name"
                    dpi.Value = item.Entity.Name
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    'Item.Unit
                    dpi = New DocPrintingItem
                    dpi.Mapping = "Item.Unit"
                    dpi.Value = item.Unit.Name
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
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteToolWithdraw}", format) Then
                Return New SaveErrorException("${res:Global.CencelDelete}")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try
                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteToolWithdraw", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.ToolWithdrawIsReferencedCannotBeDeleted}")
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

        Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
            Get
                Return Me.StoreCostcenter
            End Get
            Set(ByVal Value As CostCenter)
                Me.StoreCostcenter = Value
            End Set
        End Property

        Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
            Get
                Return Me.WithdrawCostcenter
            End Get
            Set(ByVal Value As CostCenter)
                Me.WithdrawCostcenter = Value
            End Set
        End Property
    End Class
End Namespace

