Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper

Namespace Longkong.Pojjaman.BusinessLogic
    ' ToolOpeningBalance ...
    Public Class ToolOpenningBalance
        Inherits SimpleBusinessEntityBase
    Implements IHasToCostCenter, ICheckPeriod


#Region "Members"
        Private m_docdate As Date
        Private m_note As String

        Private m_cc As CostCenter
        Private m_stockdoctype As StockDocType
        Private m_stockstatus As StockStatus

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
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                .m_cc = New CostCenter
                .m_stockstatus = New StockStatus(-1)
                .m_stockdoctype = New StockDocType(15)
                .m_docdate = Date.Now.Date
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' Costcenter ...
                If dr.Table.Columns.Contains(aliasPrefix & "tocostcenter.cc_id") Then
                    If Not dr.IsNull(aliasPrefix & "tocostcenter.cc_id") Then
                        .m_cc = New CostCenter(dr, "tocostcenter.")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_tocc") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_tocc") Then
                        .m_cc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_tocc")))
                    End If
                End If
                ' DocDate ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docdate") _
                  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docdate") Then
                    .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
                End If
                ' Note ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If
                ' Stockdoctype ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_type") _
                  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_type") Then
                    .m_stockdoctype = New StockDocType(CInt(dr(aliasPrefix & Me.Prefix & "_type")))
                End If
                ' Status ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
                    .m_stockstatus = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
                End If
            End With

        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Property ItemTable() As TreeTable            Get                Return m_itemTable            End Get            Set(ByVal Value As TreeTable)                m_itemTable = Value            End Set        End Property
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate      Get        Return m_docdate      End Get      Set(ByVal Value As Date)        m_docdate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property ToCostCenter() As CostCenter      Get        Return m_cc      End Get      Set(ByVal Value As CostCenter)        m_cc = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property StockDocType() As CodeDescription      Get
        Return m_stockdoctype
      End Get
      Set(ByVal Value As CodeDescription)
        m_stockdoctype = CType(Value, StockDocType)
      End Set
    End Property    Public Overrides Property Status() As CodeDescription
      Get
        Return m_stockstatus
      End Get
      Set(ByVal Value As CodeDescription)
        m_stockstatus = CType(Value, StockStatus)
      End Set
    End Property

    ' Overrides ReadOnly ...
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "Get" & Me.ClassName
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "ToolOpenningBalance"
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

    ' Overrides UI Detail
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ToolOpenningBalance.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.ToolOpenningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.ToolOpenningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ToolOpenningBalance.ListLabel}"
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
            Dim myDatatable As New TreeTable("ToolOpenningBalance")
            myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Group", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("FairPrice", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("ToolButton", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("stocki_qty", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("stocki_stockqty", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("stocki_tocc", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("stocki_cc", GetType(Integer)))
            Return myDatatable
        End Function
#End Region

#Region "Methods"
        Private Sub ResetId(ByVal oldid As Integer)
            Me.Id = oldid
        End Sub
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

                If Me.Status.Value = -1 Then
                    Me.Status.Value = 2
                End If

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
                'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", Me.ValidIdOrDBNull(Me.CostCenter)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", Me.ValidIdOrDBNull(Me.ToCostCenter)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))  ' 15 ...

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
                    Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
                    If IsNumeric(returnVal.Value) Then
                        Select Case CInt(returnVal.Value)
                            Case -1, -2
                                trans.Rollback()
                                Me.ResetId(oldid)
                                Return New SaveErrorException(returnVal.Value.ToString)
                            Case Else
                        End Select
                    ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                        trans.Rollback()
                        Me.ResetId(oldid)
                        Return New SaveErrorException(returnVal.Value.ToString)
                    End If

                    SaveDetail(Me.Id, conn, trans)

                    trans.Commit()
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Me.ResetId(oldid)
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Me.ResetId(oldid)
                    Return New SaveErrorException(ex.ToString)
                Finally
                    conn.Close()
                End Try
            End With
        End Function
        Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
            Dim SqlSelect As String
            SqlSelect = "Select * from StockItem where stocki_stock =" & Me.Id
            Dim da As New SqlDataAdapter(SqlSelect, conn)
            Dim cmdBuilder As New SqlCommandBuilder(da)

            Dim ds As New DataSet

            da.SelectCommand.Transaction = trans

            'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans

            da.Fill(ds, "StockItem")

            Dim dbCount As Integer = ds.Tables("StockItem").Rows.Count
            Dim itemCount As Integer = Me.ItemTable.Childs.Count
            Dim i As Integer = 0
            With ds.Tables("StockItem")
                For Each row As DataRow In .Rows
                    row.Delete()
                Next
                For n As Integer = 0 To Me.MaxRowIndex
                    Dim tr As TreeRow = Me.m_itemTable.Childs(n)
                    If ValidateRow(tr) Then
                        i += 1
                        Dim item As New ToolOpenningBalanceItem
                        item.CopyFromDataRow(tr)
                        Dim dr As DataRow = .NewRow
                        dr("stocki_lineNumber") = i
                        dr("stocki_stock") = Me.Id
                        dr("stocki_tocc") = Me.ValidIdOrDBNull(Me.ToCostCenter)
                        dr("stocki_toacctType") = 3
                        dr("stocki_entity") = item.Entity.Id
                        dr("stocki_entityType") = CType(item.Entity, Tool).EntityId
                        dr("stocki_unit") = Me.ValidIdOrDBNull(item.Unit)
                        dr("stocki_qty") = item.Qty
                        dr("stocki_stockqty") = item.StockQty
                        dr("stocki_note") = item.Note
                        dr("stocki_type") = Me.EntityId
                        dr("stocki_status") = Me.Status.Value
                        .Rows.Add(dr)
                    End If
                Next
            End With
            Dim dt As DataTable = ds.Tables("StockItem")
            ' First process deletes.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
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
            , "GetToolOpeningBalanceItems" _
            , New SqlParameter("@stocki_stock", Me.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New ToolOpenningBalanceItem(row, "")
                item.ToolOpenningBalance = Me
                Me.Add(item)
            Next
        End Sub
        Public Sub AddBlankRow(ByVal count As Integer)
            For i As Integer = 0 To count - 1
                Dim newItem As New BlankItem("")
                Dim mydtItem As New ToolOpenningBalanceItem
                mydtItem.Entity = CType(newItem, IHasName)

                'mydtItem.StockDocType = New ItemType(0)
                mydtItem.Unit = New Unit
                Me.ItemTable.AcceptChanges()
                Me.Add(mydtItem)
            Next
        End Sub
        Public Function Add(ByVal item As ToolOpenningBalanceItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.Add
            item.LineNumber = Me.ItemTable.Childs.Count
            item.ToolOpenningBalance = Me
            item.CopyToDataRow(myRow)
            Return myRow
        End Function
        Public Function Insert(ByVal index As Integer, ByVal item As ToolOpenningBalanceItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
            item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
            item.ToolOpenningBalance = Me
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
          Case "stocki_qty"
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
            Dim proposedCode As Object = e.Row("Code")
            Dim proposedQty As Object = e.Row("stocki_qty")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    proposedCode = e.ProposedValue
        Case "stocki_qty"
            proposedQty = e.ProposedValue
        Case Else
            Return
      End Select

            If IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0 Then
                e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.QtyMissing}"))
            Else
                e.Row.SetColumnError("stocki_qty", "")
            End If
        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Dim proposedCode As Object = row("Code")
            Dim proposedQty As Object = row("stocki_qty")

            If (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") _
                And (IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0) Then
                Return False
            End If
            Return True
        End Function
        Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If
      If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
          e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(TextParser.Evaluate(e.ProposedValue.ToString), DigitConfig.Qty)
    End Sub
    Private m_entitySetting As Boolean = False
    Public Sub SetEntityValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      Dim entity As New Tool(e.ProposedValue.ToString)
      m_entitySetting = True
      If entity.Originated Then
        e.ProposedValue = entity.Code
        e.Row("stocki_entity") = entity.Id
        e.Row("Name") = entity.Name
        e.Row("Group") = entity.Group.Name
        e.Row("FairPrice") = entity.FairPrice
        e.Row("stocki_unit") = entity.Unit.Id
        e.Row("Unit") = entity.Unit.Name
        e.Row("stocki_qty") = 1
        e.Row("stocki_note") = ""
      Else
        e.ProposedValue = DBNull.Value
        e.Row("stocki_entity") = DBNull.Value
        e.Row("Name") = DBNull.Value
        e.Row("Group") = DBNull.Value
        e.Row("stocki_unit") = DBNull.Value
        e.Row("Unit") = DBNull.Value
        e.Row("stocki_qty") = DBNull.Value
        e.Row("stocki_note") = DBNull.Value
      End If
      m_entitySetting = False
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

#Region "Delete"
        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                Return Me.Status.Value <= 2
            End Get
        End Property
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("${res:Global.Error.NoIdError}")
            End If
            Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim format(0) As String
            format(0) = Me.Code
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteToolOpenningBalance}", format) Then
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteToolOpenningBalance", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.ToolOpenningBalanceIsReferencedCannotBeDeleted}")
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

    
    End Class

    ' ToolOpenningBalanceItem
    Public Class ToolOpenningBalanceItem

#Region "Members"
        Private m_parent As ToolOpenningBalance
        Private m_tool As Tool
        Private m_lineNumber As Integer
        Private m_stockdoctype As StockDocType
        Private m_entity As IHasName
        Private m_unit As Unit
        Private m_qty As Decimal
        Private m_note As String
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
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                ' Line Number ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.PrefixItem & "_linenumber") _
                  AndAlso Not dr.IsNull(aliasPrefix & Me.PrefixItem & "_linenumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & Me.PrefixItem & "_linenumber"))
                End If
                ' Tool entity ...
                If dr.Table.Columns.Contains(aliasPrefix & "tool_id") _
                    AndAlso Not dr.IsNull(aliasPrefix & "tool_id") Then
                    .m_tool = New Tool(dr, "")
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.PrefixItem & "_entity") _
                        AndAlso Not dr.IsNull(aliasPrefix & Me.PrefixItem & "_entity") Then
                        .m_tool = New Tool(CInt(dr(aliasPrefix & Me.PrefixItem & "_entity")))
                    End If
                End If
                ' Unit ...
                If dr.Table.Columns.Contains(aliasPrefix & "unit_id") _
                    AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
                    .m_unit = New Unit(dr, "")
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.PrefixItem & "_unit") _
                        AndAlso Not dr.IsNull(aliasPrefix & Me.PrefixItem & "_unit") Then
                        .m_unit = New Unit(CInt(dr(aliasPrefix & Me.PrefixItem & "_unit")))
                    End If
                End If
                ' Quitity ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.PrefixItem & "_qty") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.PrefixItem & "_qty") Then
                    .m_qty = CDec(dr(aliasPrefix & Me.PrefixItem & "_qty"))
                End If
                ' Stock Doctype ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.PrefixItem & "_qty") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.PrefixItem & "_qty") Then
                    .m_qty = CDec(dr(aliasPrefix & Me.PrefixItem & "_qty"))
                End If
                ' Stock Doctype ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.PrefixItem & "_note") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.PrefixItem & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.PrefixItem & "_note"))
                End If
            End With
        End Sub

#End Region

#Region "Properties"
        Public Property Tool() As Tool
            Get
                Return m_tool
            End Get
            Set(ByVal Value As Tool)
                m_tool = Value
            End Set
        End Property
        Public Property Entity() As IHasName
            Get
                Return m_entity
            End Get
            Set(ByVal Value As IHasName)
                m_entity = Value
            End Set
        End Property
        Public ReadOnly Property PrefixItem() As String
            Get
                Return "stocki"
            End Get
        End Property
        Public Property ToolOpenningBalance() As ToolOpenningBalance            Get                Return m_parent            End Get            Set(ByVal Value As ToolOpenningBalance)                m_parent = Value            End Set        End Property        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property Unit() As Unit            Get                Return m_unit            End Get            Set(ByVal Value As Unit)                m_unit = Value            End Set        End Property        Public Property Qty() As Decimal            Get                Return m_qty            End Get            Set(ByVal Value As Decimal)                m_qty = Value            End Set        End Property        Public Property StockQty() As Decimal            Get                Return m_qty            End Get            Set(ByVal Value As Decimal)                m_qty = Value            End Set        End Property
        Public Property Note() As String
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Me.ToolOpenningBalance.IsInitialized = False
            row("stocki_linenumber") = Me.LineNumber
            If Not Me.Tool Is Nothing Then

                row("stocki_entity") = Me.Tool.Id
                row("Code") = Me.Tool.Code
                row("Name") = Me.Tool.Name
                row("Group") = Me.Tool.Group.Name
                If Me.Tool.FairPrice <> 0 Then
                    row("FairPrice") = Configuration.FormatToString(Me.Tool.FairPrice, DigitConfig.Price)
                Else
                    row("FairPrice") = ""
                End If
                row("stocki_unit") = Me.Tool.Unit.Id
                row("Unit") = Me.Tool.Unit.Name
            End If
            If Me.Qty <> 0 Then
                row("stocki_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
            Else
                row("stocki_qty") = ""
            End If
            row("stocki_stockqty") = Me.StockQty
            row("stocki_note") = Me.Note
            Me.ToolOpenningBalance.IsInitialized = True
        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Try
                If Not row.IsNull(("stocki_linenumber")) Then
                    Me.LineNumber = CInt(row("stocki_linenumber"))
                End If

                If Not row.IsNull(("stocki_entity")) Then
                    Me.Entity = New Tool(CInt(row("stocki_entity")))
                End If

                If Not row.IsNull(("stocki_unit")) Then
                    Me.Unit = New Unit(CInt(row("stocki_unit")))
                Else
                    Me.Unit = New Unit
                End If
                If Not row.IsNull(("stocki_qty")) Then
                    Me.m_qty = CDec(row("stocki_qty"))
                End If
                If Not row.IsNull(("stocki_note")) Then
                    Me.Note = CStr(row("stocki_note"))
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

    End Class

  
End Namespace
