Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class MatStockAdjust
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IHasToCostCenter

#Region "Members"
    Private m_docdate As Date
    Private m_cc As CostCenter
    Private m_startentity As LCIItem
    Private m_endentity As LCIItem
    Private m_processtime As Date
    Private m_note As String

    Private m_itemTable As TreeTable
    Private m_isinitialized As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf PRItemDelete
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf PRItemDelete
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf PRItemDelete
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf PRItemDelete
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf PRItemDelete
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docdate = Now.Date
        .m_cc = New CostCenter
        .m_startentity = New LCIItem
        .m_endentity = New LCIItem
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        ' Doc date.
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docdate") _
           AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docdate") Then
          .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
        End If
        ' Cost center.
        If dr.Table.Columns.Contains(aliasPrefix & "costcenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "costcenter.cc_id") Then
            .m_cc = New CostCenter(dr, "costcenter.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cc") _
          AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cc") Then
            .m_cc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_cc")))
          End If
        End If
        ' Start entity.
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_startentity") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_startentity") Then
          .m_startentity = New LCIItem(CInt(dr(aliasPrefix & Me.Prefix & "_startentity")))
        End If
        ' End entity.
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_endentity") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_endentity") Then
          .m_endentity = New LCIItem(CInt(dr(aliasPrefix & Me.Prefix & "_endentity")))
        End If
        ' Process time.
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_processtime") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_processtime") Then
          .m_processtime = CDate(dr(aliasPrefix & Me.Prefix & "_processtime"))
        End If
        ' Note.
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If


      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public Property DocDate() As Date      Get        Return m_docdate      End Get      Set(ByVal Value As Date)        m_docdate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property CostCenter() As CostCenter      Get        Return m_cc      End Get      Set(ByVal Value As CostCenter)        m_cc = Value      End Set    End Property    Public Property StartEntity() As LCIItem      Get        Return m_startentity      End Get      Set(ByVal Value As LCIItem)        m_startentity = Value      End Set    End Property    Public Property EndEntity() As LCIItem      Get        Return m_endentity      End Get      Set(ByVal Value As LCIItem)        m_endentity = Value      End Set    End Property    Public Property ProcessTime() As Date      Get        Return m_processtime      End Get      Set(ByVal Value As Date)        m_processtime = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property#End Region#Region " Overrides Properties "    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "matstockcount"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "matc"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "matstockcount"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatStockAdjust.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.MatStockAdjust"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.MatStockAdjust"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatStockAdjust.ListLabel}"
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

#Region "Methods"
    Public Sub ProcessItems()
      Me.ItemTable.Rows.Clear()
      Me.ItemTable.Childs.Clear()
      Dim ds As DataSet
      ds = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetRemainLCIItemListForCCall" _
      , New SqlParameter("@cc_id", IIf(Me.CostCenter.Originated, Me.CostCenter.Id, DBNull.Value)) _
      , New SqlParameter("@lci_codeStart", IIf(Me.StartEntity.Originated, Me.StartEntity.Code, DBNull.Value)) _
      , New SqlParameter("@lci_codeEnd", IIf(Me.EndEntity.Originated, Me.EndEntity.Code, DBNull.Value)) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New MatStockAdjustItem(row)
        item.MatStockAdjust = Me
        Me.Add(item)
      Next
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

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.Status.Value = -1 Then
          Me.Status = New StockStatus(2)
        End If

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
        End If
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", IIf(Me.CostCenter.Originated, Me.CostCenter.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_startentity", IIf(Me.StartEntity.Originated, Me.StartEntity.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_endentity", IIf(Me.EndEntity.Originated, Me.EndEntity.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_processtime", IIf(Me.ProcessTime.Equals(Date.MinValue), DBNull.Value, Me.ProcessTime)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
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

          SaveDetail(Me.Id, conn, trans)

          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        '----------------HACK------------------------------------
        Try
          Dim cmd As New SqlCommand("delete MatStockAdjustItem where matci_matc = " & Me.Id, conn)
          cmd.Transaction = trans
          cmd.ExecuteNonQuery()
        Catch ex As Exception
          Throw New Exception(ex.ToString)
        End Try
        '----------------HACK------------------------------------

        Dim ds As New DataSet

        '***********----WBS ----****************
        Dim da As New SqlDataAdapter("Select * from MatStockAdjustItem where 1=2", conn)
        Dim cb As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans

        da.DeleteCommand = cb.GetDeleteCommand
        da.DeleteCommand.Transaction = trans

        da.InsertCommand = cb.GetInsertCommand
        da.InsertCommand.Transaction = trans

        da.UpdateCommand = cb.GetUpdateCommand
        da.UpdateCommand.Transaction = trans

        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cb = Nothing

        da.FillSchema(ds, SchemaType.Mapped, "MatStockAdjustItem")
        da.Fill(ds, "MatStockAdjustItem")

        Dim dtMatCounti As DataTable
        Dim dc As DataColumn
        dtMatCounti = ds.Tables("MatStockAdjustItem")


        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        'AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated

        For Each dr As DataRow In dtMatCounti.Rows
          dr.Delete()
        Next
        For Each tr As TreeRow In Me.m_itemTable.Childs
          If ValidateRow(tr) Then
            Dim drFi As DataRow = dtMatCounti.NewRow
            drFi("matci_matc") = Me.Id
            drFi("matci_linenumber") = tr("matci_linenumber")
            drFi("matci_entity") = tr("matci_entity")
            drFi("matci_entityType") = tr("matci_entityType")
            drFi("matci_unit") = tr("matci_unit")
            drFi("matci_balanceqty") = tr("matci_balanceqty")
            drFi("matci_auditqty") = tr("matci_auditqty")
            drFi("matci_diffqty") = tr("matci_diffqty")
            drFi("matci_note") = tr("matci_note")

            dtMatCounti.Rows.Add(drFi)

          End If
        Next

        tmpDa.Update(GetDeletedRows(dtMatCounti))
        tmpDa.Update(dtMatCounti.Select("", "", DataViewRowState.ModifiedCurrent))

        ds.EnforceConstraints = False

        tmpDa.Update(dtMatCounti.Select("", "", DataViewRowState.Added))

        ds.EnforceConstraints = True

        Return New SaveErrorException("0")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function

    Private Function GetDeletedRows(ByVal dt As DataTable) As DataRow()
      Dim Rows() As DataRow
      If dt Is Nothing Then Return Rows
      Rows = dt.Select("", "", DataViewRowState.Deleted)
      If Rows.Length = 0 OrElse Not (Rows(0) Is Nothing) Then Return Rows

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
    Private Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet
      ds = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetMatStockAdjustItems" _
      , New SqlParameter("@matci_matc", Me.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New MatStockAdjustItem(row, "")
        item.MatStockAdjust = Me
        Me.Add(item)
      Next
    End Sub
    Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      For Each dr As DataRow In ds.Tables(0).Rows
        Dim item As New MatStockAdjustItem(dr, aliasPrefix)
        item.MatStockAdjust = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim newItem As New BlankItem("")
        Dim mtwItem As New MatStockAdjustItem
        mtwItem.Entity = newItem
        mtwItem.Unit = New Unit
        Me.ItemTable.AcceptChanges()
        Me.Add(mtwItem)
      Next
    End Sub
    Public Function Add(ByVal item As MatStockAdjustItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.MatStockAdjust = Me
      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As MatStockAdjustItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.MatStockAdjust = Me
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
        Me.ItemTable.Childs(i)("matci_linenumber") = i + 1
      Next
    End Sub
    Public Function MaxRowIndex() As Integer
      If Me.m_itemTable Is Nothing Then
        Return -1
      End If
      'ให้ index ของแถวสุดท้ายที่มีข้อมูล
      For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
        Dim row As TreeRow = Me.m_itemTable.Childs(i)
        If ValidateRow(row) Then
          Return i
        End If
      Next
      Return -1 'ไม่มีข้อมูลเลย
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("MatStockAdjust")
      myDatatable.Columns.Add(New DataColumn("matci_matc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("matci_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("matci_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("matci_entitytype", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("unitcode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("unitname", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("matci_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("matci_balanceqty", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("matci_auditqty", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("matci_diffqty", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("matci_note", GetType(String)))
      Return myDatatable
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
          Case "code"
          Case "matci_auditqty"
          Case "matci_unit"

          Case Else
            pe.Name = "ItemChanged"
        End Select
        Me.OnPropertyChanged(Me, pe)
        Me.m_itemTable.AcceptChanges()
      End If
    End Sub
    Private Sub SetEntity(ByVal e As DataColumnChangeEventArgs)
      Dim item As New MatStockAdjustItem
      item.CopyFromDataRow(CType(e.Row, TreeRow))
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "unitcode"
          Case "matci_auditqty"
            SetQty(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim proposedUnit As Object = e.Row("matci_unit")
      Dim proposedCode As Object = e.Row("Code")
      Dim proposedName As Object = e.Row("Name")

      Select Case e.Column.ColumnName.ToLower
        Case "matci_unit"
          proposedUnit = e.ProposedValue
        Case "code"
          proposedCode = e.ProposedValue
        Case "name"
          proposedName = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If (IsDBNull(proposedUnit) OrElse CStr(proposedUnit).Length = 0) _
          And (IsDBNull(proposedCode) OrElse CStr(proposedCode).Length = 0) _
          And (IsDBNull(proposedName) OrElse CStr(proposedName).Length = 0) Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        ' Entity Code
        If IsDBNull(proposedCode) Then
          e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.ItemMissing}"))
        Else
          e.Row.SetColumnError("code", "")
        End If
        ' Entity Name
        If IsDBNull(proposedName) OrElse CStr(proposedName).Length = 0 Then
          e.Row.SetColumnError("name", Me.StringParserService.Parse("${res:Global.Error.ItemMissing}"))
        Else
          e.Row.SetColumnError("name", "")
        End If
        ' Entity Unit
        If IsDBNull(proposedUnit) Then
          e.Row.SetColumnError("Unit", Me.StringParserService.Parse("${res:Global.Error.UnitMissing}"))
        Else
          e.Row.SetColumnError("Unit", "")
        End If
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim proposedCode As Object = row("Code")
      Dim flag As Boolean = True
      If IsDBNull(proposedCode) OrElse CStr(proposedCode) = "" Then
        flag = False
      End If
      Return flag
    End Function
    Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
      If ValidateRow(CType(e.Row, TreeRow)) Then
        If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
          e.ProposedValue = ""
          Return
        End If
        e.ProposedValue = Configuration.FormatToString(TextParser.Evaluate(e.ProposedValue.ToString), DigitConfig.Qty)

        Dim balanceQty As Decimal
        Dim auditQty As Decimal
        Dim diffQty As Decimal

        If Not IsDBNull(e.Row("matci_balanceqty")) Then
          balanceQty = CDec(e.Row("matci_balanceqty"))
        End If
        If Not IsDBNull(e.ProposedValue) Then
          auditQty = CDec(e.ProposedValue)
        End If
        diffQty = balanceQty - auditQty

        e.Row("matci_diffqty") = Configuration.FormatToString(diffQty, DigitConfig.Price)
      Else
        e.ProposedValue = e.Row(e.Column)
      End If
    End Sub
    Private m_updating As Boolean = False
    Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      Dim entity As SimpleBusinessEntityBase = New LCIItem(e.ProposedValue.ToString)

      m_updating = True
      If entity.Originated Then
        e.ProposedValue = entity.Code
        e.Row("matci_entity") = entity.Id
        e.Row("name") = CType(entity, LCIItem).Name
        e.Row("matci_entityType") = CType(entity, LCIItem).EntityId

        If CType(entity, LCIItem).DefaultUnit.Originated Then
          e.Row("matci_unit") = CType(entity, LCIItem).DefaultUnit.Id
          e.Row("unitcode") = CType(entity, LCIItem).DefaultUnit.Id
          e.Row("unitname") = CType(entity, LCIItem).DefaultUnit.Id
        End If
        'e.Row("matci_balanceqty") = DBNull.Value
        'e.Row("matci_auditqty") = DBNull.Value
        'e.Row("matci_diffqty") = DBNull.Value
        'e.Row("matci_note") = DBNull.Value

      Else
        e.ProposedValue = DBNull.Value
        e.Row("matci_entity") = DBNull.Value
        e.Row("name") = DBNull.Value
        e.Row("matci_entityType") = DBNull.Value
        e.Row("matci_unit") = DBNull.Value
        e.Row("unitcode") = DBNull.Value
        e.Row("unitname") = DBNull.Value
        e.Row("matci_balanceqty") = DBNull.Value
        e.Row("matci_auditqty") = DBNull.Value
        e.Row("matci_diffqty") = DBNull.Value
        e.Row("matci_note") = DBNull.Value
      End If
      m_updating = False
    End Sub

    Private Sub PRItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    End Sub
#End Region

#Region "IGLAble"
    'Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
    '    Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
    '    , CommandType.StoredProcedure _
    '    , "GetGLFormatForEntity" _
    '    , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
    '    Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
    '    Return glf
    'End Function
    'Private Function GetJournalTable() As TreeTable
    '    If Not Me.Originated Then
    '        Return Nothing
    '    End If
    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(Me.ConnectionString _
    '    , CommandType.StoredProcedure _
    '    , "GetMatStockAdjustItems" _
    '    , New SqlParameter("@stock_id", Me.Id) _
    '    , New SqlParameter("@grouping", False) _
    '    )

    '    Dim tt As TreeTable = GetSchemaTable()
    '    For Each row As DataRow In ds.Tables(0).Rows
    '        Dim item As New MatStockAdjustItem(row, "")
    '        Dim myRow As TreeRow = tt.Childs.Add
    '        item.LineNumber = Me.ItemTable.Childs.Count
    '        item.MatStockAdjust = Me
    '        item.CopyToDataRow(myRow)
    '    Next
    '    Return tt
    'End Function
    'Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
    '    Dim jiColl As New JournalEntryItemCollection
    '    jiColl.AddRange(Me.GetItemJournalEntries)
    '    Return jiColl
    'End Function
    'Private Function GetItemJournalEntries() As JournalEntryItemCollection
    '    Dim jiColl As New JournalEntryItemCollection
    '    Dim tt As TreeTable = GetJournalTable()
    '    If tt Is Nothing Then
    '        Return jiColl
    '    End If
    '    Dim ji As New JournalEntryItem
    '    Dim map As String = ""
    '    Select Case Me.Type.Value
    '        Case 1 'Store
    '            map = "F1.1"
    '        Case 2 'WIP
    '            map = "F1.2"
    '        Case 3 'Exp
    '            map = "F1.3"
    '    End Select
    '    For i As Integer = 0 To tt.Childs.Count - 1
    '        Dim item As New MatStockAdjustItem
    '        item.CopyFromDataRow(tt.Childs(i))
    '        Dim lciMatched As Boolean = False
    '        Dim lciNoAcctMatched As Boolean = False
    '        Dim originMatched As Boolean = False
    '        For Each addedJi As JournalEntryItem In jiColl
    '            Dim newRealAccount As Account
    '            Dim newEntityAcct As Account
    '            Dim newLci As LCIItem = CType(item.Entity, LCIItem)
    '            If Not newLci.Account Is Nothing AndAlso newLci.Account.Originated Then
    '                newEntityAcct = newLci.Account
    '            End If
    '            If Not newEntityAcct Is Nothing AndAlso newEntityAcct.Originated Then
    '                'ใช้ acct ของ newLci
    '                newRealAccount = newEntityAcct
    '            End If
    '            If Not newRealAccount Is Nothing AndAlso newRealAccount.Originated Then
    '                If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = newRealAccount.Id Then
    '                    If addedJi.Mapping = map Then
    '                        addedJi.Amount += item.Amount
    '                        lciMatched = True
    '                    End If

    '                    'ต้นทาง
    '                    If addedJi.Mapping = "F1.4" Then
    '                        addedJi.Amount += item.Amount
    '                        originMatched = True
    '                    End If
    '                End If
    '            ElseIf newRealAccount Is Nothing OrElse Not newRealAccount.Originated Then
    '                If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
    '                    If addedJi.Mapping = map Then
    '                        addedJi.Amount += item.Amount
    '                        lciNoAcctMatched = True
    '                    End If

    '                    'ต้นทาง
    '                    If addedJi.Mapping = "F1.4" Then
    '                        addedJi.Amount += item.Amount
    '                        originMatched = True
    '                    End If
    '                End If
    '            End If
    '        Next
    '        Dim realAccount As Account
    '        Dim entityAcct As Account
    '        Dim lci As LCIItem = CType(item.Entity, LCIItem)
    '        If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
    '            entityAcct = lci.Account
    '        End If
    '        If Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
    '            'ใช้ acct ของ lci
    '            realAccount = entityAcct
    '        End If
    '        If Not originMatched Then
    '            'ฝั่งต้นทาง
    '            ji = New JournalEntryItem
    '            ji.Mapping = "F1.4"
    '            ji.Amount += item.Amount
    '            ji.Account = Me.FromCostCenter.StoreAccount
    '            ji.CostCenter = Me.FromCostCenter
    '            jiColl.Add(ji)
    '        End If
    '        If Not realAccount Is Nothing AndAlso realAccount.Originated Then
    '            If Not lciMatched Then
    '                ji = New JournalEntryItem
    '                ji.Mapping = map
    '                ji.Amount += item.Amount
    '                ji.Account = realAccount
    '                ji.CostCenter = Me.ToCostCenter
    '                jiColl.Add(ji)
    '            End If
    '        ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
    '            If Not lciNoAcctMatched Then
    '                ji = New JournalEntryItem
    '                ji.Mapping = map
    '                ji.Amount += item.Amount
    '                ji.CostCenter = Me.ToCostCenter
    '                jiColl.Add(ji)
    '            End If
    '        End If
    '    Next
    '    Return jiColl
    'End Function
    'Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
    '    Get
    '        Return m_je
    '    End Get
    '    Set(ByVal Value As JournalEntry)
    '        m_je = Value
    '    End Set
    'End Property
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\MW.dfm"
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

      'If Not Me.ToCostCenterPerson Is Nothing AndAlso Me.ToCostCenterPerson.Originated Then
      '    'Requestor
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Requestor"
      '    dpi.Value = Me.ToCostCenterPerson.Code & ":" & Me.ToCostCenterPerson.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      'If Not Me.ToCostCenter Is Nothing AndAlso Me.ToCostCenter.Originated Then
      '    'DestCC
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "DestCC"
      '    dpi.Value = Me.ToCostCenter.Code & ":" & Me.ToCostCenter.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      'If Not Me.FromCostCenterPerson Is Nothing AndAlso Me.FromCostCenterPerson.Originated Then
      '    'StorePerson
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "StorePerson"
      '    dpi.Value = Me.FromCostCenterPerson.Code & ":" & Me.FromCostCenterPerson.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      'If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then
      '    'OriginCC
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "OriginCC"
      '    dpi.Value = Me.FromCostCenter.Code & ":" & Me.FromCostCenter.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      ''Type
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Type"
      'dpi.Value = Me.Type.Description
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      Dim n As Integer = 0
      For i As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        If ValidateRow(itemRow) And itemRow.Level <> 0 Then
          Dim item As New MatStockAdjustItem
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
          'dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
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
      Return dpiColl
    End Function
#End Region

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.CostCenter = Value
      End Set
    End Property
  End Class
End Namespace
