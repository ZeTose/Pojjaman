Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.BusinessLogic

  Public Class EquipmentGroup

  End Class

  Public Interface IHasEquipment
    'ReadOnly Property Equipment As Equipment
    'Property ItemCollection As EquipmentItemCollection
  End Interface

  Public Interface IHasParent
    ReadOnly Property parent As SimpleBusinessEntityBase
  End Interface

  Public Class Equipment
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IHasToCostCenter, IHasEquipment

#Region "Members"
    Private m_name As String
    Private m_group As EquipmentGroup
    Private m_Description As String
    Private m_unit As Unit
    Private m_rentalrate As Decimal
    Private m_itemCollection As EquipmentItemCollection
    Private m_equipmentitem As EquipmentItem
    Private m_buydate As DateTime
    Private m_CompareUnit1 As Unit
    Private m_CompareUnit2 As Unit
    Private m_cc As CostCenter
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
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_group = New EquipmentGroup
        .m_unit = New Unit
        .m_itemCollection = New EquipmentItemCollection(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
          .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
        End If
        'If dr.Table.Columns.Contains(aliasPrefix & "equipmentgroup_id") Then
        '  If Not dr.IsNull(aliasPrefix & "unit_id") Then
        '    .m_group = New EquipmentGroup(dr, aliasPrefix)
        '  Else
        '    .m_group = New EquipmentGroup
        '  End If
        'Else
        '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
        '    .m_group = New EquipmentGroup(CInt(dr(aliasPrefix & Me.Prefix & "_unit")))
        '  Else
        '    .m_group = New EquipmentGroup
        '  End If
        'End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_description") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_description") Then
          .m_Description = CStr(dr(aliasPrefix & Me.Prefix & "_description"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") Then
          If Not dr.IsNull(aliasPrefix & "unit_id") Then
            .m_unit = New Unit(dr, aliasPrefix)
          Else
            .m_unit = New Unit
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_unit")))
          Else
            .m_unit = New Unit
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_rentalrate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_rentalrate") Then
          .m_rentalrate = CDec(dr(aliasPrefix & Me.Prefix & "_rentalrate"))
        End If
      End With

      m_itemCollection = New EquipmentItemCollection(Me)
    End Sub
#End Region

#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Equipment"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "equipment"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Equipment.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Equipment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Equipment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Equipment.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "eq"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        'Return Me.ClassName & ":" & Me.Code
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property
    Public Property Name As String
      Get
        Return m_name
      End Get
      Set(ByVal value As String)
        m_name = value
      End Set
    End Property
    Public Property Group As EquipmentGroup
      Get
        Return m_group
      End Get
      Set(ByVal value As EquipmentGroup)
        m_group = value
      End Set
    End Property
    Public Property Description As String
      Get
        Return m_Description
      End Get
      Set(ByVal value As String)
        m_Description = value
      End Set
    End Property
    Public Property Unit As Unit
      Get
        Return m_unit
      End Get
      Set(ByVal value As Unit)
        m_unit = value
      End Set
    End Property

    Public Property Rentalrate As Decimal
      Get
        Return m_rentalrate
      End Get
      Set(ByVal value As Decimal)
        m_rentalrate = value
      End Set
    End Property
    Public Property ItemCollection As EquipmentItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal value As EquipmentItemCollection)
        m_itemCollection = value
      End Set
    End Property
    Public Property EquipmentItem As EquipmentItem
      Get
        Return m_equipmentitem
      End Get
      Set(ByVal value As EquipmentItem)
        m_equipmentitem = value
        If m_equipmentitem.Costcenter Is Nothing Then
          m_equipmentitem.Costcenter = New CostCenter
        End If
        If m_equipmentitem.Unit Is Nothing Then
          m_equipmentitem.Unit = New Unit
        End If
        If m_equipmentitem.Supplier Is Nothing Then
          m_equipmentitem.Supplier = New Supplier
        End If
        If m_equipmentitem.Asset Is Nothing Then
          m_equipmentitem.Asset = New Asset
        End If
        If m_equipmentitem.CurrentStatus Is Nothing Then
          m_equipmentitem.CurrentStatus = New EqtStatus(10)
        End If
        If m_equipmentitem.CurrentCostCenter Is Nothing Then
          m_equipmentitem.CurrentCostCenter = New CostCenter
        End If
      End Set
    End Property
    Public Property Buydate As DateTime
      Get
        Return m_buydate
      End Get
      Set(ByVal value As DateTime)
        m_buydate = value
      End Set
    End Property
    Public Property MemoryCompareUnit1() As Unit
      Get
        Return Me.m_CompareUnit1
      End Get
      Set(ByVal Value As Unit)
        Me.m_CompareUnit1 = Value
      End Set
    End Property
    Public Property MemoryCompareUnit2() As Unit
      Get
        Return Me.m_CompareUnit2
      End Get
      Set(ByVal Value As Unit)
        Me.m_CompareUnit2 = Value
      End Set
    End Property

  #End Region

#Region "Methods"
    Public Overloads Overrides Function GetDataset(ByVal query As String, ByVal order As String) As System.Data.DataSet
      Dim ds As DataSet = MyBase.GetDataset(query, order)
      Dim rows As DataRow() = ds.Tables(0).Select("asset_isEquipment=1")
      ds.Tables(0).Rows.Clear()
      For Each row As DataRow In rows
        ds.Tables(0).Rows.Add(row)
        Debug.WriteLine(row.Item(0))
      Next
      Return ds
    End Function
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Me.Originated Then
          'If Not Me.Supplier Is Nothing Then
          '  If Me.Supplier.Canceled Then
          '    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Me.Supplier.Code})
          '  End If
          'End If
        End If

        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If

        If Me.ItemCollection.haveEmpty Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.HaveEmpty}"))
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
          paramArrayList.Add(New SqlParameter("@eq_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)


        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If
        'Me.RefreshTaxBase()

        If Me.AutoGen Then     'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False


        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_group", Me.Group))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_Description", Me.Description))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_unit", Me.Unit.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_rentalrate", Me.Rentalrate))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_originator", ValidIdOrDBNull(Me.Originator)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_originDate", ValidDateOrDBNull(Me.OriginDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lastEditor", ValidIdOrDBNull(Me.LastEditor)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lastEditdate", ValidDateOrDBNull(Me.LastEditDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cancelPerson", ValidIdOrDBNull(Me.CancelPerson)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cancelDate", ValidDateOrDBNull(Me.CancelDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_canceled", Me.Canceled))




        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

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
          Select Case CInt(returnVal.Value)
            Case -1, -5
              trans.Rollback()
              ResetID(oldid)
              Return New SaveErrorException(returnVal.Value.ToString)
          End Select

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
          ''-------------------------------------------------------

          Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
          If Not IsNumeric(saveDetailError.Message) Then
            trans.Rollback()
            ResetID(oldid)
            Return saveDetailError
          Else
            Select Case CInt(saveDetailError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid)
                Return saveDetailError
              Case Else
            End Select
          End If

          'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertEqtStockByEquipmentItem", New SqlParameter("@EqtId", Me.Id))

          Dim saveDetailError2 As SaveErrorException = DeleteEqtStockNonRefEquipmentItem(conn, trans)
          If Not IsNumeric(saveDetailError2.Message) Then
            trans.Rollback()
            ResetID(oldid)
            Return saveDetailError2
          Else
            Select Case CInt(saveDetailError2.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid)
                Return saveDetailError2
              Case Else
            End Select
          End If

          Dim saveEqtDetailError As SaveErrorException = SaveEqtStockDetail(Me.Id, conn, trans)
          If Not IsNumeric(saveEqtDetailError.Message) Then
            trans.Rollback()
            ResetID(oldid)
            Return saveEqtDetailError
          Else
            Select Case CInt(saveEqtDetailError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid)
                Return saveEqtDetailError
              Case Else
            End Select
          End If

          ''Save CustomNote จากการ Copy เอกสาร
          'If Not Me.m_customNoteColl Is Nothing AndAlso Me.m_customNoteColl.Count > 0 Then
          '  If Me.Originated Then
          '    Me.m_customNoteColl.EntityId = Me.Id
          '    Me.m_customNoteColl.Save()
          '  End If
          'End If

          'For Each extender As Object In Me.Extenders
          '  If TypeOf extender Is IExtender Then
          '    Dim saveDocError As SaveErrorException = CType(extender, IExtender).Save(conn, trans)
          '    If Not IsNumeric(saveDocError.Message) Then
          '      trans.Rollback()
          '      Return saveDocError
          '    Else
          '      Select Case CInt(saveDocError.Message)
          '        Case -1, -2, -5
          '          trans.Rollback()
          '          Return saveDocError
          '        Case Else
          '      End Select
          '    End If
          '  End If
          'Next

          'Me.DeleteRef(conn, trans)
          'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePR_PORef" _
          ', New SqlParameter("@po_id", Me.Id))
          'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_PORef" _
          ', New SqlParameter("@refto_id", Me.Id))
          'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_PORef" _
          ', New SqlParameter("@refto_id", Me.Id))
          'If Me.Status.Value = 0 Then
          '  Me.CancelRef(conn, trans)
          'End If


          ''==============================AUTOGEN==========================================
          'Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          'If Not IsNumeric(saveAutoCodeError.Message) Then
          '  trans.Rollback()
          '  ResetID(oldid)
          '  Return saveAutoCodeError
          'Else
          '  Select Case CInt(saveAutoCodeError.Message)
          '    Case -1, -2, -5
          '      trans.Rollback()
          '      ResetID(oldid)
          '      Return saveAutoCodeError
          '    Case Else
          '  End Select
          'End If
          ''==============================AUTOGEN==========================================

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
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code
      If Me.AutoCodeFormat.Format.Length > 0 Then
        autoCodeFormat = Me.AutoCodeFormat.Format
      Else
        autoCodeFormat = Me.Code
      End If
      'Entity.GetAutoCodeFormat(Me.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(autoCodeFormat, Me)

      pattern = CodeGenerator.GetPattern(pattern)

      Dim lastCode As String = Me.GetLastCode(pattern)
      Dim newCode As String = _
      CodeGenerator.Generate(autoCodeFormat, lastCode, Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(autoCodeFormat, newCode, Me)
      End While
      Return newCode
    End Function
    Private Function DeleteEqtStockNonRefEquipmentItem(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteEqtStockNonRefEquipmentItem", New SqlParameter("@eqi_eq", Me.Id))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Function RefreshNewEquipmentItem(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(conn, trans, CommandType.Text, "Select * from EquipmentItem where eqi_eq =" & Me.Id)
      Return ds.Tables(0)
    End Function
    'Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
    '    If Not Me.Originated Then
    '        Return
    '    End If
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldPRItemStatus", New SqlParameter("@po_id", Me.Id))

    'End Sub
    'Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
    '    If Not Me.Originated Then
    '        Return
    '    End If
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewPRItemStatus", New SqlParameter("@po_id", Me.Id))
    'End Sub
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Dim currWBS As String
      Try
        Dim da As New SqlDataAdapter("Select * from EquipmentItem where eqi_eq=" & Me.Id, conn)


        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "EquipmentItem")
        da.Fill(ds, "EquipmentItem")



        Dim dt As DataTable = ds.Tables("EquipmentItem")
        'Dim dtWbs As DataTable = ds.Tables("poiwbs")

        'For Each row As DataRow In ds.Tables("poiwbs").Rows
        '  row.Delete()
        'Next


        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As EquipmentItem In Me.ItemCollection
            If testItem.Id = CInt(dr("eqi_id")) Then
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

        Dim i As Integer = 0
        Dim seq As Integer = -1
        With ds.Tables("EquipmentItem")

          For Each item As EquipmentItem In Me.ItemCollection



            '------------Checking if we have to add a new row or just update existing--------------------
            Dim dr As DataRow
            Dim drs As DataRow() = dt.Select("eqi_id=" & item.Id)
            If drs.Length = 0 Then
              dr = dt.NewRow
              'dt.Rows.Add(dr)
              seq = seq + (-1)
              dr("eqi_id") = seq

            Else
              dr = drs(0)
            End If
            '------------End Checking--------------------
            ' Dim thedate As DateTime
            If item.Autogen Then     'And Me.Code.Length = 0 Then
              item.Code = item.GetNextCode
            End If
            item.Autogen = False

            ' thedate = CDate(Me.ValidDateOrDBNull(item.Buydate))

            dr("eqi_eq") = Me.Id
            dr("eqi_code") = item.Code
            dr("eqi_name") = item.Name
            dr("eqi_cc") = Me.ValidIdOrDBNull(item.Costcenter)
            dr("eqi_buydate") = Me.ValidDateOrDBNull(item.Buydate.Date)
            dr("eqi_buydoc") = Me.ValidIdOrDBNull(item.Buydoc)
            dr("eqi_buycost") = item.Buycost
            dr("eqi_buysupplier") = Me.ValidIdOrDBNull(item.Supplier)
            dr("eqi_asset") = Me.ValidIdOrDBNull(item.Asset)
            dr("eqi_acctstatus") = item.Acctstatus
            dr("eqi_serailnumber") = item.Serailnumber
            dr("eqi_brand") = item.Brand
            dr("eqi_license") = item.License
            dr("eqi_description") = item.Description
            dr("eqi_unit") = Me.ValidIdOrDBNull(item.Unit)
            dr("eqi_rentalrate") = item.Rentalrate
            dr("eqi_rentalunit") = Me.ValidIdOrDBNull(item.Rentalunit)
            dr("eqi_lastEditDate") = Me.ValidDateOrDBNull(item.LastEditDate.Date)
            dr("eqi_lastEditor") = Me.ValidIdOrDBNull(item.LastEditor)
            If item.CurrentStatus.Value = 10 Then
              dr("eqi_currentstatus") = 2
            Else
              dr("eqi_currentstatus") = item.CurrentStatus.Value
            End If

            dr("eqi_currentcc") = Me.ValidIdOrDBNull(item.CurrentCostCenter)

            If Not item.Buydoc Is Nothing Then
              dr("eqi_stockisequence") = item.Buydoc.Sequence
            End If


            '------------Checking if we have to add a new row or just update existing--------------------
            If drs.Length = 0 Then
              dt.Rows.Add(dr)
            End If
            '------------End Checking--------------------


          Next


        End With

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated

        'tmpDa.Update(GetDeletedRows(dt))
        tmpDa.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))

        Try
          tmpDa.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        Catch ex As SqlException
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicatePO}"), New String() {Me.Code})
        End Try


        tmpDa.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        Return New SaveErrorException("1")



      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Function SaveEqtStockDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        'Dim da As New SqlDataAdapter("Select * from ToolLot where toollot_tool =" & Me.Id, conn)
        Dim daEqStock As New SqlDataAdapter("select * from EqtStock where eqtstock_refdoctype = 346 and eqtstock_refdoc in (select eqi_id from EquipmentItem where eqi_eq =" & Me.Id & ")", conn)
        Dim daEqStockItem As New SqlDataAdapter("select * from EqtStockItem where eqtstocki_refdoctype = 346 and eqtstocki_refdoc in (select eqi_id from EquipmentItem where eqi_eq =" & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdEqBuilder As New SqlCommandBuilder(daEqStock)
        daEqStock.SelectCommand.Transaction = trans
        daEqStock.DeleteCommand = cmdEqBuilder.GetDeleteCommand
        daEqStock.DeleteCommand.Transaction = trans
        daEqStock.InsertCommand = cmdEqBuilder.GetInsertCommand
        daEqStock.InsertCommand.Transaction = trans
        daEqStock.UpdateCommand = cmdEqBuilder.GetUpdateCommand
        daEqStock.UpdateCommand.Transaction = trans
        daEqStock.InsertCommand.CommandText &= "; Select * From EqtStock Where eqtstock_id = @@IDENTITY"
        daEqStock.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdEqBuilder = Nothing
        daEqStock.FillSchema(ds, SchemaType.Mapped, "EqtStock")
        daEqStock.Fill(ds, "EqtStock")
        'ds.Relations.Add("sequence", ds.Tables("ToolLot").Columns("toollot_id"), ds.Tables("EqtStock").Columns("eqtstock_refdoc"))
        'Trace.WriteLine(ds.Tables(0).TableName)
        'Trace.WriteLine(daEqStock.SelectCommand.CommandText)
        'Trace.WriteLine(ds.Tables(0).Rows.Count.ToString)

        cmdEqBuilder = New SqlCommandBuilder(daEqStockItem)
        daEqStockItem.SelectCommand.Transaction = trans
        cmdEqBuilder.GetDeleteCommand.Transaction = trans
        cmdEqBuilder.GetInsertCommand.Transaction = trans
        cmdEqBuilder.GetUpdateCommand.Transaction = trans
        cmdEqBuilder = Nothing
        daEqStockItem.FillSchema(ds, SchemaType.Mapped, "EqtStockItem")
        daEqStockItem.Fill(ds, "EqtStockItem")
        ds.Relations.Add("sequence", ds.Tables!EqtStock.Columns!eqtstock_id, ds.Tables!EqtStockItem.Columns!eqtstocki_eqtstock)

        Dim dt As DataTable = RefreshNewEquipmentItem(conn, trans)
        Dim dtEqt As DataTable = ds.Tables("EqtStock")
        Dim dtEqti As DataTable = ds.Tables("EqtStockItem")

        Trace.WriteLine("EqtStock : " + dtEqt.Rows.Count.ToString)
        Trace.WriteLine("EqtStockItem : " + dtEqti.Rows.Count.ToString)

        'For Each row As DataRow In ds.Tables("poiwbs").Rows
        '  row.Delete()
        'Next

        '------------Checking if we have to delete some rows--------------------
        Dim rowsToDelete As New ArrayList
        Dim rowsToDeleteItem As New ArrayList
        For Each req As DataRow In dtEqt.Rows
          Dim found As Boolean = False
          For Each rtool As DataRow In dt.Rows
            If CInt(req("eqtstock_refdoc")) = CInt(rtool("eqi_id")) Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            If Not rowsToDelete.Contains(req) Then
              rowsToDelete.Add(req)
            End If
          End If
        Next

        For Each eqirow As DataRow In dtEqti.Rows
          Dim found As Boolean = False
          For Each eqrow As DataRow In dtEqt.Rows
            If CInt(eqrow("eqtstock_id")) = CInt(eqirow("eqtstocki_eqtstock")) Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            If Not rowsToDeleteItem.Contains(eqirow) Then
              rowsToDeleteItem.Add(eqirow)
            End If
          End If
        Next

        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next
        For Each dr As DataRow In rowsToDeleteItem
          dr.Delete()
        Next
        '------------End Checking--------------------

        Dim i As Integer = 0

        For Each row As DataRow In dt.Rows
          i += 1
          Dim drh As New DataRowHelper(row)
          Dim drs As DataRow() = dtEqt.Select("eqtstock_refdoctype=346 and eqtstock_refdoc=" & drh.GetValue(Of Integer)("eqi_id").ToString)

          Dim drEq As DataRow
          Dim drEqi As DataRow
          If drs.Length = 0 Then
            drEq = dtEqt.NewRow
            drEq("eqtstock_id") = (Me.Id + i) * (-1)
            drEqi = dtEqti.NewRow
          Else
            drEq = drs(0)
          End If

          Dim dris As DataRow() = dtEqti.Select("eqtstocki_refdoctype=346 and eqtstocki_refdoc=" & drh.GetValue(Of Integer)("eqi_id").ToString)
          If dris.Length > 0 Then
            drEqi = dris(0)
          End If

          drEq("eqtstock_code") = drh.GetValue(Of String)("eqi_code")
          drEq("eqtstock_type") = 346
          drEq("eqtstock_tocc") = drh.GetValue(Of Integer)("eqi_cc")
          drEq("eqtstock_toCCPerson") = DBNull.Value
          drEq("eqtstock_fromcc") = DBNull.Value
          drEq("eqtstock_fromCCPerson") = DBNull.Value
          drEq("eqtstock_entity") = DBNull.Value
          drEq("eqtstock_entityType") = DBNull.Value
          drEq("eqtstock_entityPerson") = DBNull.Value
          drEq("eqtstock_docdate") = ValidDateOrDBNull(Me.OriginDate)
          drEq("eqtstock_refdoc") = drh.GetValue(Of Integer)("eqi_id")
          drEq("eqtstock_refdoctype") = 346
          drEq("eqtstock_gross") = DBNull.Value
          drEq("eqtstock_discRate") = DBNull.Value
          drEq("eqtstock_discAmt") = DBNull.Value
          drEq("eqtstock_taxType") = DBNull.Value
          drEq("eqtstock_taxbase") = DBNull.Value
          drEq("eqtstock_beforeTax") = DBNull.Value
          drEq("eqtstock_taxRate") = DBNull.Value
          drEq("eqtstock_taxAmt") = DBNull.Value
          drEq("eqtstock_afterTax") = DBNull.Value
          drEq("eqtstock_originator") = ValidIdOrDBNull(Me.Originator)
          drEq("eqtstock_originDate") = ValidDateOrDBNull(Me.OriginDate)
          drEq("eqtstock_lastEditor") = ValidIdOrDBNull(Me.LastEditor)
          drEq("eqtstock_lastEditDate") = ValidDateOrDBNull(Me.LastEditDate)
          drEq("eqtstock_canceled") = Me.Canceled
          drEq("eqtstock_cancelperson") = ValidIdOrDBNull(Me.CancelPerson)
          drEq("eqtstock_canceldate") = ValidDateOrDBNull(Me.CancelDate)
          drEq("eqtstock_approveperson") = DBNull.Value
          drEq("eqtstock_approvedate") = DBNull.Value
          drEq("eqtstock_note") = DBNull.Value

          '------------Checking if we have to add a new row or just update existing--------------------
          If drs.Length = 0 Then
            drEq("eqtstock_docstatus") = 2
            drEq("eqtstock_fromstatus") = 10
            drEq("eqtstock_tostatus") = 2
            dtEqt.Rows.Add(drEq)
          End If
          '------------End Checking--------------------

          'If dris.Length > 0 Then
          'drEqi("eqtstocki_sequence") = DBNull.Value
          drEqi("eqtstocki_eqtstock") = drEq("eqtstock_id")
          drEqi("eqtstocki_linenumber") = i
          drEqi("eqtstocki_entity") = drh.GetValue(Of Integer)("eqi_id")
          drEqi("eqtstocki_entityType") = Me.EntityId
          drEqi("eqtstocki_toollot") = DBNull.Value
          drEqi("eqtstocki_name") = drh.GetValue(Of String)("eqi_name")
          drEqi("eqtstocki_unit") = drh.GetValue(Of Integer)("eqi_unit")
          drEqi("eqtstocki_qty") = 1
          drEqi("eqtstocki_refsequence") = DBNull.Value
          drEqi("eqtstocki_rentalrate") = drh.GetValue(Of Decimal)("eqi_rentalrate")
          drEqi("eqtstocki_rentalunit") = DBNull.Value
          drEqi("eqtstocki_rentalqty") = DBNull.Value
          drEqi("eqtstocki_unitprice") = drh.GetValue(Of Decimal)("eqi_rentalrate")
          drEqi("eqtstocki_Amount") = drh.GetValue(Of Decimal)("eqi_rentalrate") * 1
          drEqi("eqtstocki_remainbuyqty") = 1
          drEqi("eqtstocki_unitAssetAmount") = DBNull.Value
          drEqi("eqtstocki_AssetAmount") = DBNull.Value
          drEqi("eqtstocki_writeoffAmt") = DBNull.Value
          drEqi("eqtstocki_unitaccdepre") = DBNull.Value
          drEqi("eqtstocki_accdepre") = DBNull.Value
          drEqi("eqtstocki_note") = DBNull.Value
          drEqi("eqtstocki_type") = 346
          drEqi("eqtstocki_refdoc") = drh.GetValue(Of Integer)("eqi_id")
          drEqi("eqtstocki_refdoctype") = 346
          drEqi("eqtstocki_refdoclinenumber") = DBNull.Value
          drEqi("eqtstocki_parent") = DBNull.Value
          drEqi("eqtstocki_level") = DBNull.Value

          If dris.Length = 0 Then
            drEqi("eqtstocki_fromstatus") = 10
            drEqi("eqtstocki_tostatus") = 2
            dtEqti.Rows.Add(drEqi)
          End If

          'End If
        Next

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = daEqStock.DeleteCommand
        tmpDa.InsertCommand = daEqStock.InsertCommand
        tmpDa.UpdateCommand = daEqStock.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daEqStockItem.RowUpdated, AddressOf daEqStock_MyRowUpdated

        daEqStockItem.Update(GetDeletedRows(dtEqti))
        tmpDa.Update(GetDeletedRows(dtEqt))

        Try
          tmpDa.Update(dtEqt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
          daEqStockItem.Update(dtEqti.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        Catch ex As SqlException
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicatePO}"), New String() {Me.Code})
        End Try

        tmpDa.Update(dtEqt.Select(Nothing, Nothing, DataViewRowState.Added))
        ds.EnforceConstraints = False
        daEqStockItem.Update(dtEqti.Select(Nothing, Nothing, DataViewRowState.Added))
        ds.EnforceConstraints = True

        Return New SaveErrorException("1")

      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daEqStock_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      'If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      'If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        Dim currentkey As Integer = CInt(e.Row("eqtstocki_eqtstock")) '.GetParentRow("sequence")("paiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!eqtstocki_eqtstock = e.Row.GetParentRow("sequence")("eqtstock_id", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!eqtstocki_eqtstock = currentkey
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

#Region "Shared"
    Public Shared Function GetEquipment(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEntity As Equipment) As Boolean
      Dim entity As New Equipment(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not entity.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        entity = oldEntity
      End If
      txtCode.Text = entity.Code
      txtName.Text = entity.Name
      If oldEntity.Id <> entity.Id Then
        oldEntity = entity
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Equipment")

      myDatatable.Columns.Add(New DataColumn("code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("status", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("costcenter", GetType(String)))


      Return myDatatable
    End Function
#End Region

    Public Property ToCC As CostCenter Implements IHasToCostCenter.ToCC
      Get

      End Get
      Set(ByVal value As CostCenter)

      End Set
    End Property

    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function

    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath

    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries

    End Function

#Region "IHasEquipmentItemCollection"
    'Public Property ItemCollection As EquipmentItemCollection Implements IHasEquipmentItemCollection.ItemCollection
    '  Get
    '    Return m_itemCollection
    '  End Get
    '  Set(ByVal value As EquipmentItemCollection)
    '    m_itemCollection = value
    '  End Set
    'End Property
#End Region

    'Public ReadOnly Property Equipment As Equipment Implements IHasEquipmentItemCollection.Equipment
    '  Get

    '  End Get
    'End Property
  End Class


End Namespace
