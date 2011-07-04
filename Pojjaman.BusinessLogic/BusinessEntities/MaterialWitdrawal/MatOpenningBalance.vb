Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class MatOpenningBalanceStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "check_status"   'Return "MatOpenningBalance_status"
      End Get
    End Property
#End Region

  End Class
  Public Class MatOpenningBalance
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IHasToCostCenter, ICheckPeriod, IPrintableEntity


#Region "Members"

    Private m_docDate As Date
    Private m_toCostCenter As CostCenter
    Private m_note As String
    Private m_status As MatOpenningBalanceStatus

    Private m_je As JournalEntry

    Private m_itemTable As TreeTable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_je = New JournalEntry(Me)
        .m_note = ""
        .m_docDate = Now.Date
        .m_status = New MatOpenningBalanceStatus(-1)
        Me.m_toCostCenter = New CostCenter
        .m_je.DocDate = Me.m_docDate

        'AutoCode
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "tocostcenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "tocostcenter.cc_id") Then
            .m_toCostCenter = New CostCenter(dr, "tocostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_tocc") AndAlso Not dr.IsNull(aliasPrefix & "stock_tocc") Then
            .m_toCostCenter = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "stock_tocc")))
            '.m_toCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_tocc")))
          End If
        End If

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .m_note = CStr(dr(aliasPrefix & "stock_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stock_status") AndAlso Not dr.IsNull(aliasPrefix & "stock_status") Then
          .m_status = New MatOpenningBalanceStatus(CInt(dr(aliasPrefix & "stock_status")))
        End If
        m_je = New JournalEntry(Me)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public Property DocDate() As Date Implements IGLAble.Date, ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        Me.m_je.DocDate = Value      End Set    End Property    Public Property ToCostCenter() As CostCenter      Get        Return m_toCostCenter      End Get      Set(ByVal Value As CostCenter)        m_toCostCenter = Value      End Set    End Property    Public ReadOnly Property ToAccount() As Account      Get        If Not Me.ToCostCenter Is Nothing AndAlso Me.ToCostCenter.Originated Then          Return Me.ToCostCenter.StoreAccount
        End If      End Get    End Property    Private m_gross As Decimal    Public ReadOnly Property Gross() As Decimal      Get        Return m_gross      End Get    End Property    Public Property Note() As String Implements IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, MatOpenningBalanceStatus)      End Set    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "MatOpenningBalance"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatOpenningBalance.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.MatOpenningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.MatOpenningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatOpenningBalance.ListLabel}"
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
      Dim myDatatable As New TreeTable("MatOpenningBalance")

      myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("StockQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub ResetId(ByVal oldid As Integer, ByVal oldjeid As Integer)
      Me.Id = oldid
      Me.m_je.Id = oldjeid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      'If Not Me.m_je.ManualFormat Then
      '  m_je.SetGLFormat(Me.GetDefaultGLFormat)
      'End If

      Return New SaveErrorException("0")

    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Me.MaxRowIndex < 0 Then
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

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        '---- AutoCode Format --------
        Dim oldcode As String
        Dim oldautogen As Boolean
        Dim oldjecode As String
        Dim oldjeautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
        oldjecode = Me.m_je.Code
        oldjeautogen = Me.m_je.AutoGen

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
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        Me.m_je.DocDate = Me.DocDate
        Me.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toAcct", ValidIdOrDBNull(Me.ToAccount)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ""))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_afterTax", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", ValidIdOrDBNull(Me.ToCostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))


        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
        Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
        If Not IsNumeric(ValidateError2.Message) Then
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return ValidateError2
        End If
        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()

        ''==============================DELETE STOCKCOST=========================================
        ''ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
        If Me.Originated AndAlso Not Me.IsReferenced Then
          Dim transbefore As SqlTransaction = conn.BeginTransaction
          Try
            SqlHelper.ExecuteNonQuery(conn, transbefore, CommandType.StoredProcedure, "DeleteStockiCost", New SqlParameter("@stock_id", Me.Id))

          Catch ex As Exception
            transbefore.Rollback()
            Return New SaveErrorException(ex.InnerException.ToString)
          End Try
          transbefore.Commit()
        End If
        ''==============================DELETE STOCKCOST=========================================

        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Dim oldjeid As Integer = Me.m_je.Id
        Try


       
        Try
          Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2
                trans.Rollback()
                Me.ResetId(oldid, oldjeid)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          ''SaveDetail(Me.Id, conn, trans)
          ''==============================DeleteSTOCKCOST=========================================
          ''ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
          'If Me.Originated AndAlso Not Me.IsReferenced Then
          '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteStockiCost", New SqlParameter("@stock_id", Me.Id))
          'End If
          ''==============================DeleteSTOCKCOST=========================================

          Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
          If Not IsNumeric(saveDetailError.Message) Then
            trans.Rollback()
            Me.ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveDetailError
          Else
            Select Case CInt(saveDetailError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetId(oldid, oldjeid)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveDetailError
              Case Else
            End Select
          End If

            ''==============================STOCKCOST=========================================
            ''ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
            'If Not Me.IsReferenced Then
            '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertStockiCost", New SqlParameter("@stock_id", Me.Id))
            'End If
            ''==============================STOCKCOST=========================================

          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            Me.ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1
                trans.Rollback()
                Me.ResetId(oldid, oldjeid)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
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
            ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldid, oldjeid)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================

          trans.Commit()
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetId(oldid, oldjeid)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetId(oldid, oldjeid)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
          End Try

          'Sub Save Block
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
          'Sub Save Block

        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      '==============================STOCKCOST=========================================
      'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut) 
      If Not Me.IsReferenced Then
        Dim transCost As SqlTransaction = conn.BeginTransaction
        Try

          'InsertStockiCostFirstFIFO ใช้สำหรับเอกสารตั้งต้น Cost จะได้ลดภาระ database
          SqlHelper.ExecuteNonQuery(conn, transCost, CommandType.StoredProcedure, "InsertStockiCostFirstFIFO", New SqlParameter("@stock_id", Me.Id))
        Catch ex As Exception
          transCost.Rollback()
          Return New SaveErrorException(ex.InnerException.ToString)
        End Try
        transCost.Commit()
      End If
      '==============================STOCKCOST=========================================

     
      Return New SaveErrorException("0")
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)
        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "stockitem")

        Dim dbCount As Integer = ds.Tables("stockitem").Rows.Count
        Dim itemCount As Integer = Me.ItemTable.Childs.Count
        Dim i As Integer = 0
        With ds.Tables("stockitem")
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          For n As Integer = 0 To Me.MaxRowIndex
            Dim itemRow As TreeRow = CType(Me.m_itemTable.Childs(n), TreeRow)
            If ValidateRow(itemRow) Then
              i += 1
              Dim item As New MatOpenningBalanceItem
              item.CopyFromDataRow(itemRow)
              Dim dr As DataRow = .NewRow
              dr("stocki_linenumber") = i
              dr("stocki_stock") = Me.Id
              dr("stocki_tocc") = Me.ValidIdOrDBNull(Me.ToCostCenter)
              dr("stocki_toacctType") = 3
              dr("stocki_entity") = item.Entity.Id
              dr("stocki_entityType") = CType(item.Entity, LCIItem).EntityId
              dr("stocki_unit") = Me.ValidIdOrDBNull(item.Unit)
              dr("stocki_qty") = item.Qty
              dr("stocki_stockqty") = item.StockQty
              dr("stocki_unitprice") = item.UnitPrice
              dr("stocki_unitcost") = item.UnitCost
              dr("stocki_amt") = item.Amount
              dr("stocki_stockQty") = item.StockQty
              dr("stocki_note") = item.Note
              dr("stocki_iscancelled") = IIf(Me.Canceled, Me.Canceled, DBNull.Value)
              dr("stocki_status") = Me.Status.Value
              dr("stocki_type") = Me.EntityId
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
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
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
      , "GetMatOpenningBalanceItems" _
      , New SqlParameter("@stock_id", Me.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New MatOpenningBalanceItem(row, "")
        item.MatOpenningBalance = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim newItem As New BlankItem("")
        Dim myMatOpenningBalanceItem As New MatOpenningBalanceItem
        myMatOpenningBalanceItem.Entity = newItem

        myMatOpenningBalanceItem.Unit = New Unit
        Me.ItemTable.AcceptChanges()
        Me.Add(myMatOpenningBalanceItem)
      Next
    End Sub
    Public Function Add(ByVal item As MatOpenningBalanceItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.MatOpenningBalance = Me
      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As MatOpenningBalanceItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.MatOpenningBalance = Me
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
        Me.ItemTable.Childs(i)("stocki_linenumber") = i + 1
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
        Dim pe As New PropertyChangedEventArgs
        Select Case e.Column.ColumnName.ToLower
          Case "stocki_unitprice", "stocki_qty", "unit"
            UpdateAmount(e)
            pe.Name = "QtyChanged"
          Case Else
            pe.Name = "ItemChanged"
        End Select
        Me.OnPropertyChanged(Me, pe)
        Me.m_itemTable.AcceptChanges()
      End If
    End Sub
    Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
      Dim item As New MatOpenningBalanceItem
      item.CopyFromDataRow(CType(e.Row, TreeRow))
      e.Row("Amount") = item.Amount
      e.Row("StockQty") = item.StockQty
      RefreshGross()
    End Sub
    Public Sub RefreshGross()
      If Me.ItemTable Is Nothing OrElse Me.ItemTable.Rows.Count = 0 Then        m_gross = 0
      Else
        Dim amt As Decimal = 0        For Each row As TreeRow In Me.ItemTable.Rows
          Dim item As New MatOpenningBalanceItem
          item.GetAmountFromRow(row)
          amt += item.Amount
        Next        m_gross = amt
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
          Case "unit"
            SetUnitValue(e)
          Case "stocki_qty", "stocki_unitprice"
            If Not IsNumeric(e.ProposedValue.ToString) Then
              e.ProposedValue = ""
            Else
              SetQty(e)
            End If
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim proposedUnit As Object = e.Row("stocki_unit")
      Dim proposedCode As Object = e.Row("Code")
      Dim proposedDescription As Object = e.Row("stocki_itemName")
      Dim proposedQty As Object = e.Row("stocki_qty")

      Select Case e.Column.ColumnName.ToLower
        Case "unit"
          proposedUnit = e.ProposedValue
        Case "code"
          proposedCode = e.ProposedValue
        Case "stocki_qty"
          proposedQty = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If (IsDBNull(proposedUnit) OrElse CStr(proposedUnit).Length = 0) _
          And (IsDBNull(proposedCode) OrElse CStr(proposedCode).Length = 0) _
          And (IsDBNull(proposedDescription) OrElse CStr(proposedDescription).Length = 0) _
          And (IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0) _
          Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(proposedUnit) Then
          e.Row.SetColumnError("Unit", Me.StringParserService.Parse("${res:Global.Error.UnitMissing}"))
        Else
          e.Row.SetColumnError("Unit", "")
        End If

        If IsDBNull(proposedDescription) OrElse CStr(proposedDescription).Length = 0 Then
          e.Row.SetColumnError("stocki_itemName", Me.StringParserService.Parse("${res:Global.Error.ItemMissing}"))
        Else
          e.Row.SetColumnError("stocki_itemName", "")
        End If

        If IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0 Then
          e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.QtyMissing}"))
        Else
          e.Row.SetColumnError("stocki_qty", "")
        End If
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim proposedUnit As Object = row("stocki_unit")
      Dim proposedCode As Object = row("Code")
      Dim proposedDescription As Object = row("stocki_itemName")
      Dim proposedQty As Object = row("stocki_qty")

      Dim flag As Boolean = True
      If (IsDBNull(proposedUnit) OrElse CInt(proposedUnit) = 0) _
          And (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") _
          And (IsDBNull(proposedDescription) OrElse CStr(proposedDescription) = "") _
          And (IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0) _
          Then
        flag = False
      End If

      Return flag
    End Function
    Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
      If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(TextParser.Evaluate(e.ProposedValue.ToString), DigitConfig.Qty)
    End Sub
    Private m_entitySetting As Boolean = False
    Public Sub SetEntityValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      Dim entity As New LCIItem(e.ProposedValue.ToString)
      m_entitySetting = True
      If entity.Originated Then
        Dim myUnit As Unit
        myUnit = CType(entity, LCIItem).DefaultUnit
        e.Row("stocki_entity") = entity.Id
        e.ProposedValue = entity.Code
        If TypeOf entity Is IHasName Then
          e.Row("stocki_itemName") = CType(entity, IHasName).Name
        Else
          e.Row("stocki_entity") = DBNull.Value
          e.ProposedValue = DBNull.Value
          e.Row("stocki_itemName") = DBNull.Value
        End If
        If Not myUnit Is Nothing AndAlso myUnit.Originated Then
          e.Row("stocki_unit") = myUnit.Id
          e.Row("Unit") = myUnit.Name
        Else
          e.Row("stocki_unit") = DBNull.Value
          e.Row("Unit") = DBNull.Value
        End If
      Else
        e.Row("stocki_entity") = DBNull.Value
        e.ProposedValue = DBNull.Value
        e.Row("stocki_itemName") = DBNull.Value
      End If
      m_entitySetting = False

      e.Row("stocki_qty") = 1
    End Sub
    Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_entitySetting Then
        Return
      End If
      Dim item As New MatOpenningBalanceItem
      item.CopyFromDataRow(CType(e.Row, TreeRow))
      Dim oldConversion As Decimal = item.Conversion
      Dim newConversion As Decimal = 1
      Dim myUnit As New Unit(e.ProposedValue.ToString)
      Dim err As String = ""
      If Not myUnit Is Nothing AndAlso myUnit.Originated Then
        If TypeOf item.Entity Is LCIItem Then
          If Not CType(item.Entity, LCIItem).ValidUnit(myUnit) Then
            err = "${res:Global.Error.NoUnitConversion}"
          Else
            newConversion = CType(item.Entity, LCIItem).GetConversion(myUnit)
          End If
        End If
      Else
        err = "${res:Global.Error.InvalidUnit}"
      End If

      If err.Length = 0 Then
        e.Row("stocki_unit") = myUnit.Id
        e.ProposedValue = myUnit.Name
        If Not e.Row.IsNull("stocki_qty") AndAlso e.Row("stocki_qty").ToString.Length > 0 Then
          e.Row("stocki_qty") = (oldConversion / newConversion) * CDec(e.Row("stocki_qty"))
        End If
        If Not e.Row.IsNull("stocki_unitprice") AndAlso e.Row("stocki_unitprice").ToString.Length > 0 Then
          e.Row("stocki_unitprice") = (newConversion / oldConversion) * CDec(e.Row("stocki_unitprice"))
        End If
      Else
        e.ProposedValue = e.Row(e.Column)
        MessageBox.Show(Me.StringParserService.Parse(err))
      End If
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
      'Dim row As DataRow = e.Row
      'Me.m_itemTable.Childs.Remove(CType(row, TreeRow))
      'Try
      '    If Not Me.m_isInitialized Then
      '        Return
      '    End If

      '    Dim index As TreeRow = CType(e.Row, TreeRow)
      '    Me.m_itemTable.Childs.Remove(index)
      'Catch ex As Exception
      '    MessageBox.Show(ex.ToString)
      'End Try
    End Sub
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_name", Me.ClassName), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        Me.m_je = Value
      End Set
    End Property
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection

      'สินค้าคงคลัง
      Dim ji As New JournalEntryItem
      For i As Integer = 0 To Me.MaxRowIndex
        Dim item As New MatOpenningBalanceItem
        item.CopyFromDataRow(Me.ItemTable.Childs(i))
        If TypeOf item.Entity Is IHasAccount Then
          Dim acct As Account = CType(item.Entity, IHasAccount).Account
          Dim match As Boolean = False
          For Each addedJi As JournalEntryItem In jiColl
            If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = acct.Id Then
              addedJi.Amount += item.Amount
              match = True
            End If
          Next
          If Not match Then
            ji = New JournalEntryItem
            ji.Account = acct
            ji.Mapping = "F9.1"
            ji.Amount = item.Amount
            ji.CostCenter = Me.ToCostCenter
            jiColl.Add(ji)
          End If
        End If
      Next


      Me.RefreshGross()

      'กำไรขาดทุนสะสม
      Dim ji2 As New JournalEntryItem
      ji2.Mapping = "F9.2"
      ji2.Amount = Me.Gross
      ji2.CostCenter = Me.ToCostCenter
      jiColl.Add(ji2)

      Return jiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return True
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteMatOpenningBalance}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteMatOpenningBalance", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.MatOpenningBalanceIsReferencedCannotBeDeleted}")
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

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.ToCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.ToCostCenter = Value
      End Set
    End Property

#Region "IPrintableEntity"

    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\MOB.dfm"
    End Function

    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

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

      If Not Me.ToCostCenter Is Nothing AndAlso Me.ToCostCenter.Originated Then
        'ToCCInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCInfo"
        dpi.Value = Me.ToCostCenter.Code & ":" & Me.ToCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCCode"
        dpi.Value = Me.ToCostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCName"
        dpi.Value = Me.ToCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim n As Integer = 0
      For Each itemRow As TreeRow In Me.ItemTable.Rows
        If ValidateRow(itemRow) Then

          Dim item As New MatOpenningBalanceItem
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

          'Item.UnitCost
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitCost"
          dpi.Value = Configuration.FormatToString(item.UnitCost, DigitConfig.Price)
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

      'TotalItem
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalItem"
      dpi.Value = Me.MaxRowIndex + 1
      dpi.DataType = "System.Int32"
      dpiColl.Add(dpi)

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function


#End Region

  End Class

  Public Class MatOpenningBalanceItem

#Region "Members"
    Private m_matOpenningBalance As MatOpenningBalance
    Private m_lineNumber As Integer

    Private m_entity As IHasName
    Private m_unit As Unit
    Private m_qty As Decimal
    Private m_unitPrice As Decimal
    Private m_note As String
    Private m_stockQty As Decimal

    Private m_conversion As Decimal = 1
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
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_entity") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entity") Then
          itemId = CInt(dr(aliasPrefix & "stocki_entity"))
        End If
        If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
          If Not dr.IsNull("lci_id") Then
            .m_entity = LCIItem.GetLciitem(itemId)
          End If
        Else
          .m_entity = LCIItem.GetLciitem(itemId)
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "stocki_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_qty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "stocki_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unitprice") Then
          .m_unitPrice = CDec(dr(aliasPrefix & "stocki_unitprice"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_stockqty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stockqty") Then
          .m_stockQty = CDec(dr(aliasPrefix & "stocki_stockqty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_note") AndAlso Not dr.IsNull(aliasPrefix & "stocki_note") Then
          .m_note = CStr(dr(aliasPrefix & "stocki_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_unit") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unit") Then
            .m_unit = Unit.GetUnitById(CInt(dr(aliasPrefix & "stocki_unit")))
            '.m_unit = New Unit(CInt(dr(aliasPrefix & "stocki_unit")))
          End If
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property MatOpenningBalance() As MatOpenningBalance      Get        Return m_matOpenningBalance      End Get      Set(ByVal Value As MatOpenningBalance)        m_matOpenningBalance = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        m_unit = Value      End Set    End Property    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        m_qty = Value      End Set    End Property    Public Property UnitPrice() As Decimal      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        m_unitPrice = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Me.Conversion * Me.Qty      End Get    End Property    Public ReadOnly Property Amount() As Decimal
      Get
        Return (Me.UnitPrice * Me.Qty)
      End Get
    End Property
    Public ReadOnly Property UnitCost() As Decimal
      Get
        If Me.StockQty <> 0 Then
          Return Me.Amount / Me.StockQty
        End If
        Return 0
      End Get
    End Property
    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.MatOpenningBalance.IsInitialized = False

      row("stocki_linenumber") = Me.LineNumber
      If Not Me.Entity Is Nothing Then
        row("stocki_entity") = Me.Entity.Id
        row("Code") = Me.Entity.Code
        row("stocki_itemName") = Me.Entity.Name
      End If

      If Not Me.Unit Is Nothing Then
        row("stocki_unit") = Me.Unit.Id
        row("Unit") = Me.Unit.Name
      End If

      Me.Conversion = 1
      If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
        If TypeOf Me.Entity Is LCIItem Then
          Dim lci As LCIItem = CType(Me.Entity, LCIItem)
          Me.Conversion = lci.GetConversion(Me.Unit)
        Else
          Me.Conversion = 1
        End If
      End If

      If Me.Qty <> 0 Then
        row("stocki_qty") = Me.Qty
      Else
        row("stocki_qty") = ""
      End If

      If Me.UnitPrice <> 0 Then
        row("stocki_unitprice") = Me.Qty
      Else
        row("stocki_unitprice") = ""
      End If

      If Me.Amount <> 0 Then
        row("Amount") = Me.Amount
      Else
        row("Amount") = ""
      End If

      row("stocki_note") = Me.Note
      If Me.UnitPrice <> 0 Then
        row("stocki_unitprice") = Me.UnitPrice
      Else
        row("stocki_unitprice") = ""
      End If
      If Me.StockQty <> 0 Then
        row("StockQty") = Me.StockQty
      Else
        row("StockQty") = ""
      End If

      Me.MatOpenningBalance.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If

      Try
        If Not row.IsNull(("stocki_linenumber")) Then
          Me.LineNumber = CInt(row("stocki_linenumber"))
        End If

        If Not row.IsNull(("stocki_unit")) Then
          Me.Unit = New Unit(CInt(row("stocki_unit")))
        Else
          Me.Unit = New Unit
        End If

        Me.Conversion = 1
        If Not row.IsNull(("stocki_entity")) Then
          Me.Entity = New LCIItem(CInt(row("stocki_entity")))
          Dim lci As LCIItem = CType(Me.Entity, LCIItem)
          Me.Conversion = lci.GetConversion(Me.Unit)
        End If

        If Not row.IsNull(("stocki_note")) Then
          Me.Note = CStr(row("stocki_note"))
        End If

        GetAmountFromRow(row)

      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub
    Public Sub GetAmountFromRow(ByVal row As TreeRow)
      'เพื่อประหยัด ไม่ต้องสร้าง Entity
      If Not row.IsNull(("stocki_qty")) Then
        If CStr(row("stocki_qty")).Length = 0 Then
          Me.Qty = 0
        Else
          Me.Qty = CDec(row("stocki_qty"))
        End If
      End If
      If Not row.IsNull(("stocki_unitprice")) Then
        If CStr(row("stocki_unitprice")).Length = 0 Then
          Me.UnitPrice = 0
        Else
          Me.UnitPrice = CDec(row("stocki_unitprice"))
        End If
      End If
    End Sub
#End Region

  End Class
End Namespace
