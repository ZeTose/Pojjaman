Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports System.Reflection

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AssetReturn
    Inherits SimpleBusinessEntityBase
    Implements IHasToCostCenter, IHasFromCostCenter, ICancelable, IPrintableEntity, ICheckPeriod, INewPrintableEntity

#Region "Members"
    Private m_isExternal As Boolean
    Private m_docDate As Date
    Private m_olddocDate As Date
    Private m_returnperson As IBillablePerson
    Private m_returncc As CostCenter
    Private m_storeperson As Employee
    Private m_storecc As CostCenter
    Private m_note As String

    Private m_rentalfee As Decimal

    Private m_customer As Customer
    Private m_itemCollection As AssetReturnItemCollection
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
        .m_olddocDate = Now.Date
        .m_note = ""
        .m_returnperson = New Employee
        .m_returncc = New CostCenter

        .m_storeperson = New Employee
        .m_storecc = New CostCenter

        .m_customer = New Customer
      End With
      m_itemCollection = New AssetReturnItemCollection(Me)
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

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isexternal") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isexternal") Then
          .m_isExternal = CBool(dr(aliasPrefix & Me.Prefix & "_isexternal"))
        End If

        If .m_isExternal Then
          ' Customer ...
          If dr.Table.Columns.Contains(aliasPrefix & "returnCustomer.cust_id") Then
            If Not dr.IsNull("returnCustomer.cust_id") Then
              .m_returnperson = New Customer(dr, "returnCustomer.")
            End If
          Else
            If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromCCPerson") Then
              If Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromCCPerson") Then
                .m_returnperson = New Customer(CInt(dr(aliasPrefix & Me.Prefix & "_fromCCPerson")))
              End If
            End If
          End If

        Else
          ' Employee ...
          If dr.Table.Columns.Contains(aliasPrefix & "returnEmployee.employee_id") Then
            If Not dr.IsNull("returnEmployee.employee_id") Then
              .m_returnperson = New Employee(dr, "returnEmployee.")
            End If
          Else
            If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromCCPerson") Then
              If Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromCCPerson") Then
                .m_returnperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_fromCCPerson")))
              End If
            End If
          End If
        End If


        ' Return Costcenter
        If dr.Table.Columns.Contains(aliasPrefix & "returncostcenter.cc_id") Then
          If Not dr.IsNull("returncostcenter.cc_id") Then
            .m_returncc = New CostCenter(dr, "returncostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromcc") Then
            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromcc") Then
              .m_returncc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_fromcc")))
            End If
          End If
        End If
        ' Store Person
        If dr.Table.Columns.Contains(aliasPrefix & "storeperson.employee_id") Then
          If Not dr.IsNull("storeperson.employee_id") Then
            .m_storeperson = New Employee(dr, "storeperson.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_toCCPerson") Then
            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_toCCPerson") Then
              .m_storeperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_toCCPerson")))
            End If
          End If
        End If
        ' Store Costcenter
        If dr.Table.Columns.Contains(aliasPrefix & "storecostcenter.cc_id") Then
          If Not dr.IsNull("storecostcenter.cc_id") Then
            .m_storecc = New CostCenter(dr, "storecostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_tocc") Then
            If Not dr.IsNull(aliasPrefix & Me.Prefix & "_tocc") Then
              .m_storecc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_tocc")))
            End If
          End If
        End If

        ' Rental Free
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_gross") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_gross") Then
          .m_rentalfee = CDec(dr(aliasPrefix & Me.Prefix & "_gross"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          Me.Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

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
      m_itemCollection = New AssetReturnItemCollection(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property Customer() As Customer      Get        Return m_customer      End Get      Set(ByVal Value As Customer)        m_customer = Value      End Set    End Property

    Public Property ItemCollection() As AssetReturnItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As AssetReturnItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property IsExternal() As Boolean
      Get
        Return m_isExternal
      End Get
      Set(ByVal Value As Boolean)
        If Value Then
          ReturnCostcenter = New CostCenter
          ReturnPerson = New Employee
        Else
          Customer = New Customer
        End If

        m_isExternal = Value
      End Set
    End Property
    Public Property RentalFee() As Decimal
      Get
        Return m_rentalfee
      End Get
      Set(ByVal Value As Decimal)
        m_rentalfee = Value
      End Set
    End Property
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
      End Set
    End Property
    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocDate
      End Get
    End Property
    Public Property ReturnPerson() As IBillablePerson      Get
        Return m_returnperson
      End Get      Set(ByVal Value As IBillablePerson)        m_returnperson = Value      End Set    End Property    'Public ReadOnly Property Customer() As Customer    '    Get
    '        If TypeOf Me.ReturnPerson Is Customer Then
    '            Return CType(Me.ReturnPerson, Customer)
    '        End If
    '    End Get
    'End Property    Public Property ReturnCostcenter() As CostCenter      Get        Return m_returncc      End Get      Set(ByVal Value As CostCenter)        m_returncc = Value      End Set    End Property    Public Property Storeperson() As Employee      Get        Return m_storeperson      End Get      Set(ByVal Value As Employee)        m_storeperson = Value      End Set    End Property    Public Property StoreCostcenter() As CostCenter      Get        Return m_storecc      End Get      Set(ByVal Value As CostCenter)        m_storecc = Value      End Set    End Property    Public Property Note() As String
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AssetReturn"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetReturn.DetailLabel}"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetReturn.ListLabel}"
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
      Dim myDatatable As New TreeTable("AssetReturn")
      ' Get from StockItem ...
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Type", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
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

        Dim person As SimpleBusinessEntityBase
        If TypeOf Me.ReturnPerson Is SimpleBusinessEntityBase Then
          person = CType(Me.ReturnPerson, SimpleBusinessEntityBase)
        End If
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromCCPerson", Me.ValidIdOrDBNull(person)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromcc", Me.ValidIdOrDBNull(Me.ReturnCostcenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toCCPerson", Me.ValidIdOrDBNull(Storeperson)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", Me.ValidIdOrDBNull(Me.StoreCostcenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isexternal", Me.IsExternal))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.RentalFee))
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

            'Me.DeleteRef(conn, trans)
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
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
        'Me.DeleteRef(conn, trans)
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetStock_StockRef" _
        , New SqlParameter("@refto_id", Me.Id))
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
      For Each item As AssetReturnItem In Me.ItemCollection
        If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 Then
          ret &= CStr(item.Entity.Id) & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function GetRefSequenceString() As String
      Dim ret As String = ""
      For Each item As AssetReturnItem In Me.ItemCollection
        ret &= CStr(item.RefSequence) & ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException

      Dim da As New SqlDataAdapter("Select * from StockItem Where Stocki_stock = " & Me.Id, conn)
      Dim daOldRef As New SqlDataAdapter("Select * from asset where asset_id in (select stocki_entity from stockitem where stocki_stock =" & Me.Id & ")", conn)
      'Dim daInternalCharge As New SqlDataAdapter("select * from internalcharge where itc_type = 2 and itc_refsequence in (select stocki_refsequence from stockitem where stocki_stock =" & Me.Id & ")", conn)

      Dim daNewRef As SqlDataAdapter
      Dim refIds As String = Me.GetRefIdString
      If refIds.Length > 0 Then
        daNewRef = New SqlDataAdapter("Select * from asset where asset_id in (" & refIds & ")", conn)
      End If

      Dim daOldWBS As SqlDataAdapter
      Dim daNewWBS As SqlDataAdapter
      Dim daIntersectWBS As SqlDataAdapter
      Dim refSeqs As String = Me.GetRefSequenceString
      If refSeqs.Length > 0 Then
        daNewWBS = New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (" & refSeqs & ") and  stockiw_sequence not in (select stocki_refsequence from stockitem where stocki_stock=" & Me.Id & ")", conn)
        daOldWBS = New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence not in (" & refSeqs & ") and stockiw_sequence in (select stocki_refsequence from stockitem where stocki_stock=" & Me.Id & ")", conn)
        daIntersectWBS = New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (" & refSeqs & ") and  stockiw_sequence  in (select stocki_refsequence from stockitem where stocki_stock=" & Me.Id & ")", conn)
      Else
        daOldWBS = New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_refsequence from stockitem where stocki_stock=" & Me.Id & ")", conn)
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
      cmdBuilder = Nothing
      da.FillSchema(ds, SchemaType.Mapped, "stockitem")
      da.Fill(ds, "stockitem")
      Dim dt As DataTable = ds.Tables("stockitem")

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
            If CInt(row("asset_status")) = 2 Then 'เบิกใช้
              row("asset_status") = 1 'ว่าง
            End If
          End If
        Next
      End If


      cmdBuilder = New SqlCommandBuilder(daOldWBS)
      daOldWBS.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans
      cmdBuilder = Nothing
      daOldWBS.FillSchema(ds, SchemaType.Mapped, "oldWBS")
      daOldWBS.Fill(ds, "oldWBS")
      Dim dtOldWBS As DataTable = ds.Tables("oldWBS")
      For Each row As DataRow In dtOldWBS.Rows
        If Not row.IsNull("stockiw_percent") AndAlso IsNumeric(row("stockiw_percent")) Then
          For Each item As AssetReturnItem In Me.ItemCollection
            If item.RefSequence = CInt(row("stockiw_sequence")) Then

              Dim percent As Decimal
              If IsNumeric(row("stockiw_percent")) Then
                percent = CDec(row("stockiw_percent"))
              End If

              Dim baseCost As Decimal
              If IsNumeric(row("stockiw_baseCost")) Then
                baseCost = CDec(row("stockiw_baseCost"))
              End If

              Dim amt As Decimal
              Dim o As Object = dt.Select("stocki_refsequence=" & item.RefSequence)(0)("stocki_amt")
              If Not o Is Nothing AndAlso IsNumeric(o) Then
                amt = CDec(o)
              End If
              row("stockiw_baseCost") = baseCost - amt

              'Dim transferbaseCost As Decimal
              'If IsNumeric(row("stockiw_transferbaseCost")) Then
              '    transferbaseCost = CDec(row("stockiw_transferbaseCost"))
              'End If
              'row("stockiw_transferbaseCost") = transferbaseCost - amt

              'row("stockiw_transferamt") = (transferbaseCost - amt) * percent / 100
              row("stockiw_amt") = (baseCost - amt) * percent / 100
            End If
          Next
        End If
      Next

      Dim dtNewWBS As DataTable
      Dim dtIntersect As DataTable
      If Not daNewWBS Is Nothing Then
        cmdBuilder = New SqlCommandBuilder(daNewWBS)
        daNewWBS.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daNewWBS.FillSchema(ds, SchemaType.Mapped, "newWBS")
        daNewWBS.Fill(ds, "newWBS")
        dtNewWBS = ds.Tables("newWBS")

        cmdBuilder = New SqlCommandBuilder(daIntersectWBS)
        daIntersectWBS.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daIntersectWBS.FillSchema(ds, SchemaType.Mapped, "intersectWBS")
        daIntersectWBS.Fill(ds, "intersectWBS")
        dtIntersect = ds.Tables("intersectWBS")

        For Each row As DataRow In dtNewWBS.Rows
          If Not row.IsNull("stockiw_percent") AndAlso IsNumeric(row("stockiw_percent")) Then
            For Each item As AssetReturnItem In Me.ItemCollection
              If item.RefSequence = CInt(row("stockiw_sequence")) Then

                Dim percent As Decimal
                If IsNumeric(row("stockiw_percent")) Then
                  percent = CDec(row("stockiw_percent"))
                End If

                Dim baseCost As Decimal
                If IsNumeric(row("stockiw_baseCost")) Then
                  baseCost = CDec(row("stockiw_baseCost"))
                End If
                row("stockiw_baseCost") = baseCost + item.Amount

                'Dim transferbaseCost As Decimal
                'If IsNumeric(row("stockiw_transferbaseCost")) Then
                '    transferbaseCost = CDec(row("stockiw_transferbaseCost"))
                'End If
                'row("stockiw_transferbaseCost") = transferbaseCost + item.Amount

                'row("stockiw_transferamt") = (transferbaseCost + item.Amount) * percent / 100
                row("stockiw_amt") = (baseCost + item.Amount) * percent / 100
              End If
            Next
          End If
        Next

        For Each row As DataRow In dtIntersect.Rows
          If Not row.IsNull("stockiw_percent") AndAlso IsNumeric(row("stockiw_percent")) Then
            For Each item As AssetReturnItem In Me.ItemCollection
              If item.RefSequence = CInt(row("stockiw_sequence")) Then

                Dim percent As Decimal
                If IsNumeric(row("stockiw_percent")) Then
                  percent = CDec(row("stockiw_percent"))
                End If

                Dim baseCost As Decimal
                If IsNumeric(row("stockiw_baseCost")) Then
                  baseCost = CDec(row("stockiw_baseCost"))
                End If
                Dim amt As Decimal
                Dim o As Object = dt.Select("stocki_refsequence=" & item.RefSequence)(0)("stocki_amt")
                If Not o Is Nothing AndAlso IsNumeric(o) Then
                  amt = CDec(o)
                End If

                row("stockiw_baseCost") = baseCost + item.Amount - amt

                'Dim transferbaseCost As Decimal
                'If IsNumeric(row("stockiw_transferbaseCost")) Then
                '    transferbaseCost = CDec(row("stockiw_transferbaseCost"))
                'End If
                'row("stockiw_transferbaseCost") = transferbaseCost + item.Amount - amt

                'row("stockiw_transferamt") = (transferbaseCost + item.Amount - amt) * percent / 100
                row("stockiw_amt") = (baseCost + item.Amount - amt) * percent / 100
              End If
            Next
          End If
        Next
      End If

      'cmdBuilder = New SqlCommandBuilder(daInternalCharge)
      'daInternalCharge.SelectCommand.Transaction = trans
      'cmdBuilder.GetDeleteCommand.Transaction = trans
      'cmdBuilder.GetInsertCommand.Transaction = trans
      'cmdBuilder.GetUpdateCommand.Transaction = trans
      'cmdBuilder = Nothing
      'daInternalCharge.FillSchema(ds, SchemaType.Mapped, "internalcharge")
      'daInternalCharge.Fill(ds, "internalcharge")


      Dim dtOldRef As DataTable = ds.Tables("oldAsset")

      'Dim dtInternalCharge As DataTable = ds.Tables("internalcharge")

      For Each row As DataRow In dtOldRef.Rows
        Dim found As Boolean = False
        For Each item As AssetReturnItem In Me.ItemCollection
          If item.Entity.Id = CInt(row("asset_id")) Then
            'เจอแล้ว --> 
            found = True
            Exit For
          End If
        Next
        If Not found Then
          'ไม่เจอ
          If Not row.IsNull("asset_status") AndAlso IsNumeric(row("asset_status")) Then
            If CInt(row("asset_status")) = 1 Then 'ว่าง
              row("asset_status") = 2 'เบิก
            End If
          End If
        End If
      Next

      'Dim hasEnded As Boolean = False
      'If dtInternalCharge.Rows.Count > 0 Then
      '    hasEnded = True
      'End If

      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteStockItem", _
          New SqlParameter("@stocki_stock", Me.Id))

      Dim i As Integer = 0 'Line Running
      With ds.Tables("stockitem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For Each item As AssetReturnItem In Me.ItemCollection
          Dim dr As DataRow = .NewRow

          dr("stocki_stock") = Me.Id
          dr("stocki_linenumber") = i

          dr("stocki_cc") = DBNull.Value
          dr("stocki_fromcc") = Me.ValidIdOrDBNull(Me.ReturnCostcenter)

          dr("stocki_refsequence") = item.RefSequence

          dr("stocki_tocc") = Me.ValidIdOrDBNull(Me.StoreCostcenter)
          dr("stocki_toacct") = DBNull.Value
          dr("stocki_toAcctType") = 3

          dr("stocki_entity") = item.Entity.Id
          dr("stocki_entityType") = item.ItemType.Value
          dr("stocki_itemName") = item.Entity.Name
          dr("stocki_qty") = item.Qty
          dr("stocki_stockqty") = item.Qty

          dr("stocki_note") = item.Note
          dr("stocki_amt") = item.Amount
          dr("stocki_type") = Me.EntityId
          dr("stocki_status") = Me.Status.Value
          .Rows.Add(dr)

          'If Not hasEnded Then
          '    Dim childDr As DataRow = dtInternalCharge.NewRow
          '    childDr("itc_refsequence") = dr("stocki_sequence")
          '    childDr("itc_linenumber") = 1
          '    childDr("itc_rate") = item.Asset.RentalRate
          '    childDr("itc_startdate") = Me.DocDate
          '    childDr("itc_type") = 2 '1=ปกติ 2=หยุด 3=ลดราคา
          '    dtInternalCharge.Rows.Add(childDr)
          'End If
        Next
      End With


      AddHandler da.RowUpdated, AddressOf tmpDa_MyRowUpdated
      AddHandler daOldRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      AddHandler daOldWBS.RowUpdated, AddressOf tmpDa_MyRowUpdated
      If Not daNewRef Is Nothing Then
        AddHandler daNewRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      End If
      If Not daNewWBS Is Nothing Then
        AddHandler daNewWBS.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daIntersectWBS.RowUpdated, AddressOf tmpDa_MyRowUpdated
      End If
      'AddHandler daInternalCharge.RowUpdated, AddressOf tmpDa_MyRowUpdated

      daOldRef.Update(GetDeletedRows(dtOldRef))
      daOldWBS.Update(GetDeletedRows(dtOldWBS))
      da.Update(GetDeletedRows(dt))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(GetDeletedRows(dtNewRef))
      End If
      If Not daNewWBS Is Nothing Then
        daNewWBS.Update(GetDeletedRows(dtNewWBS))
        daIntersectWBS.Update(GetDeletedRows(dtIntersect))
      End If
      'daInternalCharge.Update(GetDeletedRows(dtInternalCharge))

      da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.ModifiedCurrent))
      daOldWBS.Update(dtOldWBS.Select("", "", DataViewRowState.ModifiedCurrent))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(dtNewRef.Select("", "", DataViewRowState.ModifiedCurrent))
      End If
      If Not daNewWBS Is Nothing Then
        daNewWBS.Update(dtNewWBS.Select("", "", DataViewRowState.ModifiedCurrent))
        daIntersectWBS.Update(dtIntersect.Select("", "", DataViewRowState.ModifiedCurrent))
      End If
      'daInternalCharge.Update(dtInternalCharge.Select("", "", DataViewRowState.ModifiedCurrent))

      da.Update(dt.Select("", "", DataViewRowState.Added))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.Added))
      daOldWBS.Update(dtOldWBS.Select("", "", DataViewRowState.Added))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(dtNewRef.Select("", "", DataViewRowState.Added))
      End If
      If Not daNewWBS Is Nothing Then
        daNewWBS.Update(dtNewWBS.Select("", "", DataViewRowState.Added))
        daIntersectWBS.Update(dtIntersect.Select("", "", DataViewRowState.Added))
      End If
      'daInternalCharge.Update(dtInternalCharge.Select("", "", DataViewRowState.Added))

    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
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
        Return Me.m_returncc
      End Get
      Set(ByVal Value As CostCenter)
        m_returncc = Value
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAssetReturn}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAssetReturn", New SqlParameter() {New SqlParameter("@stock_id", Me.Id), returnVal})
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

      dpi = New DocPrintingItem
      dpi.Mapping = "stock_id"
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

      If Not Me.ReturnPerson Is Nothing Then
        'ReturnPerson
        dpi = New DocPrintingItem
        dpi.Mapping = "ReturnPerson"
        dpi.Value = Me.ReturnPerson.Code & ":" & Me.ReturnPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReturnPersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ReturnPersonInfo"
        dpi.Value = Me.ReturnPerson.Code & ":" & Me.ReturnPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReturnPersonName
        dpi = New DocPrintingItem
        dpi.Mapping = "ReturnPersonName"
        dpi.Value = Me.ReturnPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReturnPersonCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ReturnPersonCode"
        dpi.Value = Me.ReturnPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.ReturnCostcenter Is Nothing AndAlso Me.ReturnCostcenter.Originated Then
        'FromCostCenter
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenter"
        dpi.Value = Me.ReturnCostcenter.Code & ":" & Me.ReturnCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenterInfo"
        dpi.Value = Me.ReturnCostcenter.Code & ":" & Me.ReturnCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenterCode"
        dpi.Value = Me.ReturnCostcenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenterName"
        dpi.Value = Me.ReturnCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostCenterPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenterPhone"
        dpi.Value = Me.ReturnCostcenter.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostCenterFax
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenterFax"
        dpi.Value = Me.ReturnCostcenter.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Storeperson Is Nothing AndAlso Me.Storeperson.Originated Then
        'ReceivePerson
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePerson"
        dpi.Value = Me.Storeperson.Code & ":" & Me.Storeperson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReceivePersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePersonInfo"
        dpi.Value = Me.Storeperson.Code & ":" & Me.Storeperson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReceivePersonName
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePersonName"
        dpi.Value = Me.Storeperson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReceivePersonCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePersonCode"
        dpi.Value = Me.Storeperson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.StoreCostcenter Is Nothing AndAlso Me.StoreCostcenter.Originated Then
        'ToCostCenter
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenter"
        dpi.Value = Me.StoreCostcenter.Code & ":" & Me.StoreCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterInfo"
        dpi.Value = Me.StoreCostcenter.Code & ":" & Me.StoreCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterCode"
        dpi.Value = Me.StoreCostcenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterName"
        dpi.Value = Me.StoreCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterPhone"
        dpi.Value = Me.StoreCostcenter.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterFax
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterFax"
        dpi.Value = Me.StoreCostcenter.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Dim n As Integer = 0
      Dim sumQty As Decimal = 0
      Dim sumAmount As Decimal = 0

      For Each item As AssetReturnItem In Me.ItemCollection

        dpi = New DocPrintingItem
        dpi.Mapping = "stocki_stock"
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

        sumQty += item.Qty

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Amount"
        dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        sumAmount += Configuration.Format(item.Amount, DigitConfig.Price)

        n += 1

      Next

      'SumQty
      dpi = New DocPrintingItem
      dpi.Mapping = "SumQty"
      dpi.Value = Configuration.FormatToString(sumQty, DigitConfig.Qty)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SumAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SumAmount"
      dpi.Value = Configuration.FormatToString(sumAmount, DigitConfig.Qty)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'ItemCount
      dpi = New DocPrintingItem
      dpi.Mapping = "ItemCount"
      dpi.Value = Me.ItemCollection.Count
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

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.RelationList.Add("general>stock_id>item>stocki_stock")

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stock_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReturnPerson", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReturnPersonInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReturnPersonName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReturnPersonCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostCenter", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostCenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostCenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostCenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostCenterPhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCostCenterFax", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivePerson", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivePersonInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivePersonName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivePersonCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenter", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterPhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCostCenterFax", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ItemCount", "System.Int32"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SumQty", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SumAmount", "System.Decimal"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stocki_stock", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Type", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Item"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCode", "System.String", "Item"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodePercent", "System.String", "Item"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodeAmount", "System.Decimal", "Item"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainAmount", "System.Decimal", "Item"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainQty", "System.Decimal", "Item"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.DateStart", "System.DateTime", "Item"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.DateEnd", "System.DateTime", "Item"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Details", "System.String", "Item"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Rate", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.Decimal", "Item"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

  End Class

  Public Class AssetReturnItem

#Region "Members"
    Private m_AssetReturn As AssetReturn
    Private m_lineNumber As Integer
    Private m_refsequence As Integer

    Private m_entity As IHasRentalRate

    Private m_note As String

    Private m_itemtype As ItemType

    Private m_qty As Integer = 1

    Private m_amount As Decimal = Decimal.MinValue 'HACK
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
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "stocki_lineNumber"))
        End If

        ' Sequence Refed From ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_refsequence") AndAlso Not dr.IsNull(aliasPrefix & "stocki_refsequence") Then
          .m_refsequence = CInt(dr(aliasPrefix & "stocki_refsequence"))
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

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_amt") AndAlso Not dr.IsNull(aliasPrefix & "stocki_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "stocki_amt"))
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property AssetReturn() As AssetReturn      Get        Return m_AssetReturn      End Get      Set(ByVal Value As AssetReturn)        m_AssetReturn = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property ItemType() As ItemType      Get        Return m_itemtype      End Get      Set(ByVal Value As ItemType)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        End If      End Set    End Property    Public Property RefSequence() As Integer      Get        Return m_refsequence      End Get      Set(ByVal Value As Integer)        m_refsequence = Value      End Set    End Property    Public Function DupCode(ByVal myCode As String) As Boolean      If Me.AssetReturn Is Nothing Then        Return False
      End If      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As AssetReturnItem In Me.AssetReturn.ItemCollection
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
    End Function    Public Sub SetItemCode(ByVal theCode As String)      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'If DupCode(theCode) Then
      '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {"Asset", theCode})
      '    Return
      'End If
      'If theCode Is Nothing OrElse theCode.Length = 0 Then
      '    If Me.Asset.Code.Length <> 0 Then
      '        If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {Me.Asset.Code}) Then
      '            Me.Clear()
      '        End If
      '    End If
      '    Return
      'End If
      'Dim myAsset As New Asset(theCode)
      'If Not myAsset.Originated Then
      '    msgServ.ShowMessageFormatted("${res:Global.Error.NoAsset}", New String() {theCode})
      '    Return
      'Else
      '    Me.m_asset = myAsset
      'End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
    End Sub    Public Property Entity() As IHasRentalRate      Get        Return m_entity      End Get      Set(ByVal Value As IHasRentalRate)        m_entity = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Amount() As Decimal      Get        If m_amount.Equals(Decimal.MinValue) Then          m_amount = Me.GetAmount
        End If        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Function GetAmount() As Decimal      Dim rate As Decimal = Me.m_entity.RentalRate
      Dim itcColl As New InternalChargeCollection(Me.RefSequence)
      Dim ret As Decimal = 0
      Dim docDate As Date = Me.AssetReturn.DocDate
      For Each itc As InternalCharge In itcColl
        If itc.StartDate > Me.AssetReturn.DocDate Then
          Exit For
        End If
        If itc.IsFixed Then
          ret += itc.GetAmount(rate) * Me.m_qty
        Else
          Dim maxDate As Date = itc.EndDate
          If docDate < maxDate Then
            maxDate = docDate
          End If
          Dim ts As TimeSpan = maxDate.Subtract(itc.StartDate)
          ret += itc.GetAmount(rate) * (ts.Days + 1) * Me.m_qty
        End If
      Next
      Return ret
    End Function    Public Function GetRentalDate() As Date      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                SimpleBusinessEntityBase.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetRentalDateFromSequence" _
                , New SqlParameter("@stocki_sequence", Me.m_refsequence) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If Not ds.Tables(0).Rows(0).IsNull(0) Then
            Return CDate(ds.Tables(0).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return Date.MinValue
    End Function    Public Property Qty() As Integer      Get        If Not Me.m_itemtype Is Nothing Then          If Me.m_itemtype.Value = 28 Then
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
        End If        m_qty = CInt(Configuration.Format(Value, DigitConfig.Int))      End Set    End Property#End Region

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
        Me.AssetReturn.IsInitialized = False

        row("Linenumber") = Me.LineNumber
        row("Type") = Me.ItemType.Value
        If Not Me.Entity Is Nothing Then
          row("Code") = Me.Entity.Code
          row("Name") = Me.Entity.Name
        End If
        row("Button") = ""
        If Me.Amount <> 0 Then
          row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("Amount") = ""
        End If

        If Me.Qty <> 0 Then
          row("QTY") = Configuration.FormatToString(Me.Qty, DigitConfig.Int)
        Else
          row("QTY") = ""
        End If

        row("Note") = Me.Note

        Me.AssetReturn.IsInitialized = True
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class AssetReturnItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_AssetReturn As AssetReturn
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As AssetReturn)
      Me.m_AssetReturn = owner
      If Not Me.m_AssetReturn.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetAssetReturnItems" _
      , New SqlParameter("@stock_id", Me.m_AssetReturn.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New AssetReturnItem(row, "")
        item.AssetReturn = m_AssetReturn
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property AssetReturn() As AssetReturn      Get        Return m_AssetReturn      End Get      Set(ByVal Value As AssetReturn)        m_AssetReturn = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As AssetReturnItem
      Get
        Return CType(MyBase.List.Item(index), AssetReturnItem)
      End Get
      Set(ByVal value As AssetReturnItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each gri As AssetReturnItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        gri.CopyToDataRow(newRow)
        gri.ItemValidateRow(newRow)
        newRow.Tag = gri
      Next
      dt.AcceptChanges()
    End Sub
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim ret As Decimal = 0
        For Each ai As AssetReturnItem In Me
          ret += ai.Amount
        Next
        Return ret
      End Get
    End Property
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As AssetReturnItem) As Integer
      If Not m_AssetReturn Is Nothing Then
        value.AssetReturn = m_AssetReturn
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As AssetReturnItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As AssetReturnItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As AssetReturnItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As AssetReturnItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As AssetReturnItemEnumerator
      Return New AssetReturnItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As AssetReturnItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As AssetReturnItem)
      If Not m_AssetReturn Is Nothing Then
        value.AssetReturn = m_AssetReturn
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As AssetReturnItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As AssetReturnItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class AssetReturnItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As AssetReturnItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, AssetReturnItem)
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
