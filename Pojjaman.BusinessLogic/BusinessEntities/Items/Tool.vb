Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Tool
    Inherits SimpleBusinessEntityBase
    Implements IHasRentalRate, IHasImage, IHasUnit, IHasPrice, IHasGroup, IEqtItem

#Region "Members"
    Private tool_name As String
    Private tool_group As ToolGroup
    Private tool_unit As Unit
    Private m_qty As Integer
    Private tool_fairprice As Decimal
    Private tool_rentalrate As Decimal
    Private m_cc As CostCenter
    'Private m_Itemcollection As EquipmentItemCollection
    Private m_Toollotcollection As ToolLotCollection
    Private m_image As Image
    Private m_toollot As ToolLot
    Private m_equipmentitem As EquipmentItem
    Private m_itemTable As TreeTable

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.tool_group = New ToolGroup
      Me.tool_unit = New Unit
      Me.m_cc = New CostCenter
      Me.m_Toollotcollection = New ToolLotCollection(Me)
    End Sub
    Public Sub New(ByVal Code As String)
      MyBase.New(Code)
    End Sub
    Public Sub New(ByVal Id As Integer)
      MyBase.New(Id)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    'Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
    '  Dim dr As DataRow = ds.Tables(0).Rows(0)
    '  Construct(dr, aliasPrefix)
    '  With Me
    '    .m_Toollotcollection = New ToolLotCollection(Me)
    '    .tool_group = New ToolGroup
    '    .tool_unit = New Unit
    '  End With
    'End Sub

    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
          .tool_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "toolg_id") _
        AndAlso Not dr.IsNull(aliasPrefix & "toolg_id") Then
          .tool_group = New ToolGroup(dr, "")
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_group") _
          AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_group") Then
            .tool_group = New ToolGroup(CInt(dr(aliasPrefix & Me.Prefix & "_group")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "tool_costcenter") _
               AndAlso Not dr.IsNull(aliasPrefix & "tool_costcenter") Then
          '  .m_cc = New CostCenter(dr, "")
          'Else
          '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_costcenter") _
          '  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_costcenter") Then
          '    .m_cc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_costcenter")))
          '  End If

          Dim ccId As Integer = CInt(dr("tool_costcenter"))
          .m_cc = Costcenter.GetCCMinDataById(ccId)
        End If

        If dr.Table.Columns.Contains("tool_unit") _
        AndAlso Not dr.IsNull("tool_unit") Then
          '  .tool_unit = New Unit(dr, "")
          'Else
          '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") _
          '  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
          '    .tool_unit = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_unit")))
          '  End If
          Dim unitId As Integer = CInt(dr("tool_unit"))
          .tool_unit = Unit.GetUnitById(unitId)
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fairprice") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fairprice") Then
          .tool_fairprice = CDec(dr(aliasPrefix & Me.Prefix & "_fairprice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_rentalrate") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_rentalrate") Then
          .tool_rentalrate = CDec(dr(aliasPrefix & Me.Prefix & "_rentalrate"))
        End If
        Me.ItemCollection = New ToolLotCollection(Me)
      End With
      LoadImage()
    End Sub
    Public Sub LoadImage()
      If Id <= 0 Then
        Return
      End If

      Dim sqlConString As String = Me.RealConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select tool_image from toolimage where tool_id = " & Me.Id

      conn.Open()

      Dim cmd As SqlCommand = conn.CreateCommand
      cmd.CommandText = sql

      Dim custReader As SqlDataReader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))
      If custReader.Read Then
        LoadImage(custReader)
      End If
    End Sub
    Public Sub LoadImage(ByVal reader As IDataReader)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      m_image = Field.GetImage(reader, "tool_image")
      Try
        If Image Is Nothing Then
          m_image = Image.FromFile(myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Entity.BlankImage}"))
        End If
      Catch ex As Exception

      End Try
    End Sub
#End Region

#Region "Properties"
    Public Property Unit() As Unit Implements IEqtItem.Unit
      Get
        If Me.Originated Then
          Return (New Tool(Id)).MemoryUnit
        End If
        Return tool_unit
      End Get
      Set(ByVal Value As Unit)
        tool_unit = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Qty() As Integer
      Get
        Return m_qty
      End Get
      Set(ByVal Value As Integer)
        m_qty = Value
      End Set
    End Property
    Public Property Costcenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Name() As String Implements IHasName.Name      Get
        Return tool_name
      End Get
      Set(ByVal Value As String)
        tool_name = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property EntityId As Integer Implements IEqtItem.EntityId
      Get
        Return MyBase.EntityId
      End Get
    End Property
    Public Property RentalRate() As Decimal Implements IHasRentalRate.RentalRate
      Get
        Return tool_rentalrate
      End Get
      Set(ByVal Value As Decimal)
        tool_rentalrate = Value
      End Set
    End Property
    Public Property Group() As ToolGroup
      Get
        Return tool_group
      End Get
      Set(ByVal Value As ToolGroup)
        tool_group = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property FairPrice() As Decimal
      Get
        Return tool_fairprice
      End Get
      Set(ByVal Value As Decimal)
        tool_fairprice = Value
      End Set
    End Property

    Public Property Image() As System.Drawing.Image Implements IHasImage.Image
      Get
        Return m_image
      End Get
      Set(ByVal Value As System.Drawing.Image)
        m_image = Value
      End Set
    End Property
    Public Property ItemCollection As ToolLotCollection
      Get
        If m_Toollotcollection Is Nothing Then
          m_Toollotcollection = New ToolLotCollection(New Tool)
        End If
        Return m_Toollotcollection
      End Get
      Set(ByVal value As ToolLotCollection)
        m_Toollotcollection = value
      End Set
    End Property
    Public Property ToolLot As ToolLot
      Get
        Return m_toollot
      End Get
      Set(ByVal value As ToolLot)
        m_toollot = value
        If m_toollot.Costcenter Is Nothing Then
          m_toollot.Costcenter = New CostCenter
        End If
        If m_toollot.Unit Is Nothing Then
          m_toollot.Unit = New Unit
        End If
        If m_toollot.Supplier Is Nothing Then
          m_toollot.Supplier = New Supplier
        End If
        If m_toollot.Asset Is Nothing Then
          m_toollot.Asset = New Asset
        End If
        'If m_toollot.CurrentStatus Is Nothing Then
        '  m_toollot.CurrentStatus = New EqtStatus(2)
        'End If
        'If m_toollot.CurrentCostCenter Is Nothing Then
        '  m_toollot.CurrentCostCenter = New CostCenter
        'End If
      End Set
    End Property
    Public Property ItemTable() As TreeTable
      Get
        Return m_itemTable
      End Get
      Set(ByVal Value As TreeTable)
        m_itemTable = Value
      End Set
    End Property

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Tool"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Tool.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Tool"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Tool"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "tool"
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
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Tool.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region
    'Public Sub SetCurrentCostCenter(ByVal cc As CostCenter)
    '  m_cc = cc
    'End Sub
#Region "Shared"
    Public Shared Function GetTool(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldTool As Tool) As Boolean
      Dim myTool As New Tool(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not myTool.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        myTool = oldTool
      End If
      txtCode.Text = myTool.Code
      txtName.Text = myTool.Name
      If oldTool.Id <> myTool.Id Then
        oldTool = myTool
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetAvailabilityInCC(ByVal filters As Filter()) As DataTable
      'GetRemainToolListForCC
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetNewRemainToolListForCC", params)
      Return ds.Tables(0)
    End Function
#End Region
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("AssetStock")

      myDatatable.Columns.Add(New DataColumn("DocType", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("DocCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("FromCCcode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("FromCCname", GetType(String)))
      Return myDatatable
    End Function

#Region "Method"
    Public Function GetIsReferenced() As Boolean
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "GetToolReferenced" _
        , New SqlParameter("@tool_id", Me.Id))

        If CInt(ds.Tables(0).Rows(0)(0)) > 0 Then
          Return True
        End If
      Catch ex As Exception
      End Try
      Return False
    End Function
    Public Function GetLastWithdrawSequence() As Integer
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "GetLastToolWithdrawSequenceWithNoReturn" _
        , New SqlParameter("@tool_id", Me.Id))

        If ds.Tables(0).Rows.Count > 0 AndAlso IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CInt(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function
    Public Function CheckUnitBeforeSaving() As String
      Dim dt As DataTable = GetRefUnitTable()
      If dt Is Nothing Then
        Return ""
      End If
      For Each row As DataRow In dt.Rows
        Dim drh As New DataRowHelper(row)
        Dim unid As Integer = drh.GetValue(Of Integer)("tool_unit")
        Dim refUnit As Unit = Unit.GetUnitById(unid) ' New Unit(CInt(row("tool_unit")))
        If Me.Unit.Id <> refUnit.Id Then
          Return "ต้องมีหน่วยนับ " & refUnit.Name & " เท่านั้น เนื่องจากมีการอ้างอิงไปยังเอกสารอื่นแล้ว"
        End If
      Next
      Return ""
    End Function
    Public Function GetRefUnitTable() As DataTable
      If Not Me.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, "GetRefUnitForTool", _
      New SqlParameter("@tool_id", Me.Id))
      Return ds.Tables(0)
    End Function
    Public Overrides Function ToString() As String
      Return tool_name
    End Function
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub

    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      'Dim unitError As String = CheckUnitBeforeSaving()
      'If Not unitError Is Nothing AndAlso unitError.Length > 0 Then
      '  Return New SaveErrorException(unitError)
      'End If
      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current

      Dim paramArrayList As New ArrayList

      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      paramArrayList.Add(returnVal)
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_group", Me.Group.Id))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_unit", Me.MemoryUnit.Id))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fairprice", Me.FairPrice))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_rentalrate", Me.RentalRate))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_costcenter", IIf(Me.Costcenter.Originated, Me.Costcenter.Id, DBNull.Value)))

      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      ' สร้าง SqlParameter จาก ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)

      If conn.State = ConnectionState.Open Then conn.Close()
      conn.Open()
      trans = conn.BeginTransaction
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

        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertEqtStockByToolLot", New SqlParameter("@toolId", Me.Id))

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

        Dim saveDetailError2 As SaveErrorException = DeleteEqtStockNonRefToolLot(conn, trans)
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

        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertEqtStockByToolLot", New SqlParameter("@toolId", Me.Id))

        'Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        ' Save Image process 
        If Not Me.Image Is Nothing Then
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertToolimage" _
          , New SqlParameter("@tool_id", Me.Id) _
          , New SqlParameter("@tool_image", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(Me.Image)))
        End If


        trans.Commit()
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(returnVal.Value.ToString)
      Finally
        conn.Close()
      End Try
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
      Me.IsInitialized = True
    End Sub
    Private Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetAssetStocks" _
      , New SqlParameter("@asset_id", Me.Id) _
      )

      Dim i As Integer = 0
      Dim amt As Decimal = 0
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim dr As TreeRow = m_itemTable.Childs.Add
        dr("Linenumber") = i
        dr("DocType") = row("DocType")
        dr("DocCode") = row("DocCode")
        dr("DocName") = row("DocName")
        dr("FromCCcode") = row("FromCCcode")
        dr("FromCCname") = row("FromCCname")
        'If IsNumeric(row("Amount")) Then
        '  dr("Amount") = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
        'End If
      Next
    End Sub
#End Region
    'Private Function GetEqtStockId(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
    '  Dim ds As DataSet = (SqlHelper.ExecuteDataset(conn, trans, CommandType.StoredProcedure,
    '                                                "GetEqtStockId",
    '                                                New SqlParameter("@docId", Me.Id),
    '                                                New SqlParameter("@docType", Me.EntityId)))
    '  If ds.Tables(0).Rows.Count > 0 Then
    '    Return CInt(ds.Tables(0).Rows(0)(0))
    '  End If
    'End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      'Dim currWBS As String
      Try
        'Dim EqtId As Integer = GetEqtStockId(conn, trans)

        Dim da As New SqlDataAdapter("Select * from ToolLot where toollot_tool =" & Me.Id, conn)
        'Dim daEqStock As New SqlDataAdapter("select * from EqtStock where eqtstock_refdoctype = " & Me.EntityId & " and eqtstock_refdoc in (Select toollot_id from ToolLot where toollot_tool =" & Me.Id & ")", conn)
        'Dim daEqStockItem As New SqlDataAdapter("select * from EqtStockitem where eqtstocki_refdoc = " & Me.Id & " and eqtstocki_refdoctype = " & Me.EntityId, conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        'da.InsertCommand.CommandText &= "; Select * From ToolLot Where toollot_id = @@IDENTITY"
        'da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "ToolLot")
        da.Fill(ds, "ToolLot")

        Trace.WriteLine("ToolLot:" & ds.Tables("ToolLot").Rows.Count.ToString)

        'Dim cmdEqBuilder As New SqlCommandBuilder(daEqStock)
        'daEqStock.SelectCommand.Transaction = trans
        'cmdEqBuilder.GetDeleteCommand.Transaction = trans
        'cmdEqBuilder.GetInsertCommand.Transaction = trans
        'cmdEqBuilder.GetUpdateCommand.Transaction = trans
        'cmdEqBuilder = Nothing
        'daEqStock.FillSchema(ds, SchemaType.Mapped, "EqtStock")
        'daEqStock.Fill(ds, "EqtStock")
        'ds.Relations.Add("sequence", ds.Tables!ToolLot.Columns!toollot_id, ds.Tables!EqtStock.Columns!eqtstock_refdoc)

        'Dim cmdEqiBuilder As New SqlCommandBuilder(daEqStockItem)
        'daEqStockItem.SelectCommand.Transaction = trans
        'daEqStockItem.DeleteCommand = cmdEqiBuilder.GetDeleteCommand
        'daEqStockItem.DeleteCommand.Transaction = trans
        'daEqStockItem.InsertCommand = cmdEqiBuilder.GetInsertCommand
        'daEqStockItem.InsertCommand.Transaction = trans
        'daEqStockItem.UpdateCommand = cmdEqiBuilder.GetUpdateCommand
        'daEqStockItem.UpdateCommand.Transaction = trans
        'cmdEqiBuilder = Nothing
        'daEqStockItem.FillSchema(ds, SchemaType.Mapped, "EqtStockitem")
        'daEqStockItem.Fill(ds, "EqtStockitem")
        'ds.Relations.Add("sequence", ds.Tables("ToolLot").Columns("toollot_toollot"), ds.Tables("EqtStockitem").Columns("eqtstocki_toollot"))
        'ds.Relations.Add("sequence2", ds.Tables("ToolLot").Columns("toollot_id"), ds.Tables("EqtStockitem").Columns("eqtstocki_toollot"))

        'ds.Tables!paitem.Columns!pai_sequence, ds.Tables!paiwbs.Columns!paiw_sequence

        Dim dt As DataTable = ds.Tables("ToolLot")
        'Dim dtEqt As DataTable = ds.Tables("EqtStock")

        'For Each row As DataRow In ds.Tables("poiwbs").Rows
        '  row.Delete()
        'Next

        Dim rowsToDelete As ArrayList

        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As ToolLot In Me.ItemCollection
            If testItem.Id = CInt(dr("toollot_id")) Then
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

        'Dim EqRowsToDelete As New ArrayList
        'For Each eqtRow As DataRow In dtEqt.Rows
        '  Dim eqth As New DataRowHelper(eqtRow)
        '  For Each toolLotRow As DataRow In rowsToDelete
        '    Dim toolLoth As New DataRowHelper(toolLotRow)
        '    If eqth.GetValue(Of Integer)("eqtstock_refdoc") = toolLoth.GetValue(Of Integer)("toollot_id") Then
        '      EqRowsToDelete.Add(eqtRow)
        '    End If
        '  Next
        'Next

        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next
        'For Each dr As DataRow In EqRowsToDelete
        '  dr.Delete()
        'Next
        '------------End Checking--------------------

        Dim i As Integer = 0
        Dim seq As Integer = -1
        With ds.Tables("ToolLot")

          For Each item As ToolLot In Me.ItemCollection
            i += 1

            '------------Checking if we have to add a new row or just update existing--------------------
            Dim dr As DataRow
            Dim drEq As DataRow
            Dim drs As DataRow() = dt.Select("toollot_id=" & item.Id)
            If drs.Length = 0 Then
              dr = dt.NewRow
              'dt.Rows.Add(dr)
              seq = seq + (-1)
              dr("toollot_id") = seq
              'dr("toollot_tool") = Me.Id
              'dt.Rows.Add(dr)

              'drEq = dtEqt.NewRow
              ''drEq("eqtstock_refdoc") = 0
              'dtEqt.Rows.Add(drEq)
            Else
              dr = drs(0)

              'Dim drsEq As DataRow() = dtEqt.Select("eqtstock_refdoc=" & item.Id)
              'If drsEq.Length > 0 Then
              'drEq = drsEq(0)
              '  'dtEqt.Rows.Add(drEq)
              'End If
            End If
            '------------End Checking--------------------
            ' Dim thedate As DateTime
            If item.Autogen Then     'And Me.Code.Length = 0 Then
              item.Code = item.GetNextCode
            End If
            item.Autogen = False

            ' thedate = CDate(Me.ValidDateOrDBNull(item.Buydate))

            dr("toollot_tool") = Me.Id
            dr("toollot_code") = item.Code
            'dr("eqi_name") = item.Name
            dr("toollot_cc") = Me.ValidIdOrDBNull(item.Costcenter)
            dr("toollot_buydate") = Me.ValidDateOrDBNull(item.Buydate.Date)
            dr("toollot_buydoc") = Me.ValidIdOrDBNull(item.Buydoc)
            dr("toollot_buydoccode") = item.Buydoc.Code
            dr("toollot_buycost") = item.Buycost
            dr("toollot_buysupplier") = Me.ValidIdOrDBNull(item.Buydoc.Supplier)
            dr("toollot_asset") = Me.ValidIdOrDBNull(item.Asset)
            'dr("eqi_acctstatus") = item.Acctstatus
            'dr("eqi_serailnumber") = item.Serailnumber
            dr("toollot_brand") = item.Brand
            'dr("eqi_license") = item.License
            dr("toollot_decription") = item.Description
            dr("toollot_unit") = Me.ValidIdOrDBNull(item.Unit)
            dr("toollot_rentrate") = item.Rentalrate
            'dr("eqi_rentalunit") = Me.ValidIdOrDBNull(item.Rentalunit)
            dr("toollot_lastEditDate") = Me.ValidDateOrDBNull(item.LastEditDate.Date)
            dr("toollot_lastEditor") = Me.ValidIdOrDBNull(item.LastEditor)
            'dr("eqi_currentstatus") = item.CurrentStatus.Value
            'dr("eqi_currentcc") = Me.ValidIdOrDBNull(item.CurrentCostCenter)
            dr("toollot_unitcost") = item.UnitCost
            dr("toollot_buyqty") = item.Buyqty
            dr("toollot_remainqty") = item.RemainQTY
            dr("toollot_stockisequence") = item.Buydoc.Sequence

            'If Not drEq Is Nothing Then
            '  'drEq("eqtstock_id") = DBNull.Value
            '  drEq("eqtstock_code") = dr("toollot_code")
            '  drEq("eqtstock_type") = Me.EntityId
            '  drEq("eqtstock_tocc") = ValidIdOrDBNull(item.Costcenter)
            '  drEq("eqtstock_toCCPerson") = DBNull.Value
            '  drEq("eqtstock_fromcc") = DBNull.Value
            '  drEq("eqtstock_fromCCPerson") = DBNull.Value
            '  drEq("eqtstock_entity") = DBNull.Value
            '  drEq("eqtstock_entityType") = DBNull.Value
            '  drEq("eqtstock_entityPerson") = DBNull.Value
            '  drEq("eqtstock_docdate") = Me.OriginDate
            '  'drEq("eqtstock_refdoc") = CInt(dr("toollot_id")) - 1
            '  drEq("eqtstock_refdoctype") = Me.EntityId
            '  drEq("eqtstock_gross") = DBNull.Value
            '  drEq("eqtstock_discRate") = DBNull.Value
            '  drEq("eqtstock_discAmt") = DBNull.Value
            '  drEq("eqtstock_taxType") = DBNull.Value
            '  drEq("eqtstock_taxbase") = DBNull.Value
            '  drEq("eqtstock_beforeTax") = DBNull.Value
            '  drEq("eqtstock_taxRate") = DBNull.Value
            '  drEq("eqtstock_taxAmt") = DBNull.Value
            '  drEq("eqtstock_afterTax") = DBNull.Value
            '  drEq("eqtstock_originator") = ValidIdOrDBNull(Me.Originator)
            '  drEq("eqtstock_originDate") = ValidDateOrDBNull(Me.OriginDate)
            '  drEq("eqtstock_lastEditor") = ValidIdOrDBNull(Me.LastEditor)
            '  drEq("eqtstock_lastEditDate") = ValidDateOrDBNull(Me.LastEditDate)
            '  drEq("eqtstock_canceled") = Me.Canceled
            '  drEq("eqtstock_cancelperson") = ValidIdOrDBNull(Me.CancelPerson)
            '  drEq("eqtstock_canceldate") = ValidDateOrDBNull(Me.CancelDate)
            '  drEq("eqtstock_approveperson") = DBNull.Value
            '  drEq("eqtstock_approvedate") = DBNull.Value
            '  drEq("eqtstock_docstatus") = 2
            '  drEq("eqtstock_fromstatus") = 10
            '  drEq("eqtstock_tostatus") = 2
            '  drEq("eqtstock_note") = DBNull.Value
            'End If

            ''------------Checking if we have to add a new row or just update existing--------------------
            If drs.Length = 0 Then
              dt.Rows.Add(dr)
              'ds.Tables("EqtStockitem").Rows.Add(drEq)
            End If
            ''------------End Checking--------------------

          Next

        End With

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        'AddHandler daEqStock.RowUpdated, AddressOf daEqStock_MyRowUpdated

        'daEqStock.Update(GetDeletedRows(dtEqt))
        tmpDa.Update(GetDeletedRows(dt))

        Try
          tmpDa.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
          'daEqStock.Update(dtEqt.Select("", "", DataViewRowState.ModifiedCurrent))
        Catch ex As SqlException
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicatePO}"), New String() {Me.Code})
        End Try

        tmpDa.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        'ds.EnforceConstraints = False
        'daEqStock.Update(dtEqt.Select("", "", DataViewRowState.Added))
        'ds.EnforceConstraints = True

        Return New SaveErrorException("1")

      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Function DeleteEqtStockNonRefToolLot(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteEqtStockNonRefToolLot", New SqlParameter("@tool_Id", Me.Id))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Function RefreshNewToolLot(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(conn, trans, CommandType.Text, "Select * from ToolLot where toollot_tool =" & Me.Id)
      Return ds.Tables(0)
    End Function
    Private Function SaveEqtStockDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        'Dim da As New SqlDataAdapter("Select * from ToolLot where toollot_tool =" & Me.Id, conn)
        Dim daEqStock As New SqlDataAdapter("select * from EqtStock where eqtstock_refdoctype = 348 and eqtstock_refdoc in (Select toollot_id from ToolLot where toollot_tool =" & Me.Id & ")", conn)
        Dim daEqStockItem As New SqlDataAdapter("select * from EqtStockItem where eqtstocki_refdoctype = 348 and eqtstocki_refdoc in (Select toollot_id from ToolLot where toollot_tool =" & Me.Id & ")", conn)

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

        Dim dt As DataTable = RefreshNewToolLot(conn, trans)
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
            If CInt(req("eqtstock_refdoc")) = CInt(rtool("toollot_id")) Then
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
          Dim drs As DataRow() = dtEqt.Select("eqtstock_refdoctype=348 and eqtstock_refdoc=" & drh.GetValue(Of Integer)("toollot_id").ToString)

          Dim drEq As DataRow
          Dim drEqi As DataRow
          If drs.Length = 0 Then
            drEq = dtEqt.NewRow
            drEq("eqtstock_id") = (Me.Id + i) * (-1)
            drEqi = dtEqti.NewRow
          Else
            drEq = drs(0)
          End If

          Dim dris As DataRow() = dtEqti.Select("eqtstocki_refdoctype=348 and eqtstocki_refdoc=" & drh.GetValue(Of Integer)("toollot_id").ToString)
          If dris.Length > 0 Then
            drEqi = dris(0)
          End If

          drEq("eqtstock_code") = drh.GetValue(Of String)("toollot_code")
          drEq("eqtstock_type") = 348
          drEq("eqtstock_tocc") = drh.GetValue(Of Integer)("toollot_cc")
          drEq("eqtstock_toCCPerson") = DBNull.Value
          drEq("eqtstock_fromcc") = DBNull.Value
          drEq("eqtstock_fromCCPerson") = DBNull.Value
          drEq("eqtstock_entity") = DBNull.Value
          drEq("eqtstock_entityType") = DBNull.Value
          drEq("eqtstock_entityPerson") = DBNull.Value
          drEq("eqtstock_docdate") = ValidDateOrDBNull(Me.OriginDate)
          drEq("eqtstock_refdoc") = drh.GetValue(Of Integer)("toollot_id")
          drEq("eqtstock_refdoctype") = 348
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
          drEqi("eqtstocki_entity") = Me.Id
          drEqi("eqtstocki_entityType") = Me.EntityId
          drEqi("eqtstocki_toollot") = drh.GetValue(Of Integer)("toollot_id")
          drEqi("eqtstocki_name") = Me.Name
          drEqi("eqtstocki_unit") = drh.GetValue(Of Integer)("toollot_unit")
          drEqi("eqtstocki_qty") = drh.GetValue(Of Decimal)("toollot_remainqty")
          drEqi("eqtstocki_refsequence") = DBNull.Value
          drEqi("eqtstocki_rentalrate") = drh.GetValue(Of Decimal)("toollot_rentrate")
          drEqi("eqtstocki_rentalunit") = DBNull.Value
          drEqi("eqtstocki_rentalqty") = DBNull.Value
          drEqi("eqtstocki_unitprice") = drh.GetValue(Of Decimal)("toollot_unitcost")
          drEqi("eqtstocki_Amount") = drh.GetValue(Of Decimal)("toollot_unitcost") * drh.GetValue(Of Decimal)("toollot_remainqty")
          drEqi("eqtstocki_remainbuyqty") = drh.GetValue(Of Decimal)("toollot_buyqty")
          drEqi("eqtstocki_unitAssetAmount") = DBNull.Value
          drEqi("eqtstocki_AssetAmount") = DBNull.Value
          drEqi("eqtstocki_writeoffAmt") = DBNull.Value
          drEqi("eqtstocki_unitaccdepre") = DBNull.Value
          drEqi("eqtstocki_accdepre") = DBNull.Value
          drEqi("eqtstocki_note") = DBNull.Value
          drEqi("eqtstocki_type") = 348
          drEqi("eqtstocki_refdoc") = drh.GetValue(Of Integer)("toollot_id")
          drEqi("eqtstocki_refdoctype") = 348
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

#Region "IHasUnit"
    Public Property DefaultUnit() As Unit Implements IHasUnit.DefaultUnit
      Get
        Return Me.Unit
      End Get
      Set(ByVal Value As Unit)
        Me.Unit = Value
      End Set
    End Property
    Public Property MemoryUnit() As Unit Implements IHasUnit.MemoryUnit
      Get
        Return Me.tool_unit
      End Get
      Set(ByVal Value As Unit)
        Me.tool_unit = Value
      End Set
    End Property

    'Public Property Costcenter() As CostCenter Implements 
    '  Get
    '    Return Me.tool_unit
    '  End Get
    '  Set(ByVal Value As Unit)
    '    Me.tool_unit = Value
    '  End Set
    'End Property

#End Region

#Region "IHasPrice"
    Public Property Price() As Decimal Implements IHasPrice.Price
      Get
        Return Me.FairPrice
      End Get
      Set(ByVal Value As Decimal)
        Me.FairPrice = Value
      End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        ' Hack :
        Return True
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteTool}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteTool", New SqlParameter() {New SqlParameter("@tool_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.ToolIsReferencedCannotBeDeleted}")
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

    Public ReadOnly Property GroupForCode() As ISimpleEntity Implements IHasGroup.Group
      Get
        Return Me.tool_group
      End Get
    End Property
  End Class
  'TODO : เหน่งกลับมาทำ ToolGroup ด้วยนะครับ
  Public Class ToolGroup
    Inherits TreeBaseEntity

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As ToolGroup)
      MyBase.New(myParent)
    End Sub
    Public Sub New(ByVal gid As Integer)
      MyBase.New(gid)
    End Sub
    Public Sub New(ByVal gcode As String)
      MyBase.New(gcode)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"

    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "toolg"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "ToolGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ToolGroup.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.ToolGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.ToolGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ToolGroup.ListLabel}"
      End Get

    End Property
#End Region

#Region "Methods"
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New ToolGroup(parId)
      Else
        Me.Parent = Nothing
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New ToolGroup
      par.Id = id
      par.Code = code
      par.Name = name
      Me.Parent = par
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim parID As Object = 0
        If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
          parID = Me.Parent.Id
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
          paramArrayList.Add(New SqlParameter("@toolg_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@toolg_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@toolg_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@toolg_altname", Me.AlternateName))
        paramArrayList.Add(New SqlParameter("@toolg_parid", parID))
        paramArrayList.Add(New SqlParameter("@toolg_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@toolg_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@toolg_control", Me.IsControlGroup))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)

        ' ตรวจจับ Error ของการ Save ...

        Return New SaveErrorException(returnVal.Value.ToString)

      End With
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetToolGroup(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldGroup As ToolGroup) As Boolean
      Dim group As New ToolGroup(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not group.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        group = oldGroup
      ElseIf group.IsControlGroup Then
        MessageBox.Show(group.Code & "-" & group.Name & " เป็นกลุ่มแม่")
        group = oldGroup
      End If
      txtCode.Text = group.Code
      txtName.Text = group.Name
      If oldGroup.Id <> group.Id Then
        oldGroup = group
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetSchemaTable() As DataTable
      Dim myDatatable As New DataTable("AssetStock")

      myDatatable.Columns.Add(New DataColumn("DocType", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("DocCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("FromCCcode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("FromCCname", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return True 'Hack
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteToolGroup}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteToolGroup", New SqlParameter() {New SqlParameter("@toolg_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.ToolGroupIsReferencedCannotBeDeleted}")
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

  End Class
  Public Class ToolForSelection
    Inherits Tool
    Public CC As New CostCenter
    Public FromWip As Boolean = False
    Public EqtClass As String

#Region "Shared"
    Public Shared Function GetQtyOfToolsInCC(ByVal filters As Filter(), ByVal classname As String) As DataTable
      'GetRemainToolListForCC
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = Nothing 'SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetNewRemainToolListForCC", params)
      Select Case classname.ToLower
        Case "equipmenttoolwithdraw"
          ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetAvaliableToolInCC", params)
        Case "equipmenttoolchangestatus"
          ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetToolInCCFromStatus", params)
      End Select
      If ds IsNot Nothing Then
        Return ds.Tables(0)
      End If
      Return Nothing
    End Function
#End Region

    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "ToolForSelection"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "ToolForSelection"
      End Get
    End Property
  End Class

End Namespace

