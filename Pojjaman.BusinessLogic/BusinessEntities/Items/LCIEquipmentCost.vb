Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class LCIEquipmentCostLink
        Inherits SimpleBusinessEntityBase

#Region "Members"
        Private m_itemTable As TreeTable
        Private m_lci As LCIItem
#End Region

#Region "Constructors"
        Public Sub UnWire()
            RemoveHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            RemoveHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
            RemoveHandler m_itemTable.RowDeleted, AddressOf ItemDelete
        End Sub
        Public Sub Wire()
            'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
        End Sub
        Public Sub New()
            MyBase.New()
            ReLoadItems()
            Wire()
        End Sub
        Public Sub New(ByVal lci As LCIItem)
            Me.Lci = lci
            ReLoadItems()
            Wire()
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Lci() As LCIItem            Get                Return m_lci            End Get            Set(ByVal Value As LCIItem)                m_lci = Value            End Set        End Property
        Public Property ItemTable() As TreeTable            Get                Return m_itemTable            End Get            Set(ByVal Value As TreeTable)                m_itemTable = Value            End Set        End Property
        Public Overrides ReadOnly Property UseSiteConnString() As Boolean
            Get
                Return True
            End Get
        End Property
#End Region

#Region "Shared"
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("EquipmentCost")
            myDatatable.Columns.Add(New DataColumn("lcil_linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("lcil_labor", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Cost", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("lcil_note", GetType(String)))
            Dim dateCol As New DataColumn("CostDate", GetType(Date))
            dateCol.DefaultValue = Date.MinValue
            myDatatable.Columns.Add(dateCol)
            Return myDatatable
        End Function
#End Region

#Region "Methods"
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
            Dim da As New SqlDataAdapter("Select * from lcilabor where lcil_lci=" & Me.m_lci.Id & " and lcil_type=2", conn)
            Dim cmdBuilder As New SqlCommandBuilder(da)
            Dim ds As New DataSet

            da.SelectCommand.Transaction = trans

            'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans

            da.Fill(ds, "lcilabor")

            Try
                Dim i As Integer = 0
                With ds.Tables("lcilabor")
                    For Each row As DataRow In .Rows
                        row.Delete()
                    Next
                    For n As Integer = 0 To Me.MaxRowIndex
                        Dim item As TreeRow = Me.m_itemTable.Childs(n)
                        If ValidateRow(item) Then
                            i += 1
                            Dim dr As DataRow = .NewRow
                            dr("lcil_lci") = Me.m_lci.Id
                            dr("lcil_linenumber") = i 'item("pri_linenumber")
                            If Not IsDBNull(item("lcil_labor")) AndAlso CInt(item("lcil_labor")) <> 0 Then
                                dr("lcil_labor") = item("lcil_labor")
                            End If
                            dr("lcil_Note") = item("lcil_Note")
                            dr("lcil_type") = 2
                            .Rows.Add(dr)
                        End If
                    Next
                End With
                Dim dt As DataTable = ds.Tables("lcilabor")
                ' First process deletes.
                da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
                ' Next process updates.
                da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
                ' Finally process inserts.
                da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
                Return New SaveErrorException("0")
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
            LoadItems(ds, aliasPrefix)
            Me.IsInitialized = True
        End Sub
        Private Sub LoadItems()
            If Me.m_lci Is Nothing OrElse Not Me.m_lci.Originated Then
                Return
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
            , CommandType.StoredProcedure _
            , "GetLCILaborEquipmentCosts" _
            , New SqlParameter("@lci_id", Me.m_lci.Id) _
            , New SqlParameter("@lcil_type", "2") _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New LCIEquipmentCostLinkItem(row, "")
                item.LCIEquipmentCostLink = Me
                Me.Add(item)
            Next
        End Sub
        Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            For Each dr As DataRow In ds.Tables(1).Rows
                Dim item As New LCIEquipmentCostLinkItem(dr, aliasPrefix)
                item.LCIEquipmentCostLink = Me
                Me.Add(item)
            Next
        End Sub
        Public Sub AddBlankRow(ByVal count As Integer)
            For i As Integer = 0 To count - 1
                Dim myItem As New LCIEquipmentCostLinkItem
                myItem.EqCost = New EqCost
                Me.ItemTable.AcceptChanges()
                Me.Add(myItem)
            Next
        End Sub
        Public Function Add(ByVal item As LCIEquipmentCostLinkItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.Add
            item.LineNumber = Me.ItemTable.Childs.Count
            item.LCIEquipmentCostLink = Me
            item.CopyToDataRow(myRow)
            Return myRow
        End Function
        Public Function Insert(ByVal index As Integer, ByVal item As LCIEquipmentCostLinkItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
            item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
            item.LCIEquipmentCostLink = Me
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
                Me.ItemTable.Childs(i)("lcil_linenumber") = i + 1
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
                        SetEquipmentValue(e)
                    Case "lcil_cost"
                        SetCost(e)
                    Case "costdate"
                        SetCostDate(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim proposedCode As Object = e.Row("Code")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    proposedCode = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If (IsDBNull(Code) OrElse CStr(Code).Length = 0) _
                Then
                isBlankRow = True
            End If

            If Not isBlankRow Then
                If IsDBNull(Code) Then
                    e.Row.SetColumnError("Code", Me.StringParserService.Parse("${res:Global.Error.ItemMissing}"))
                Else
                    e.Row.SetColumnError("Code", "")
                End If
            End If

        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Dim proposedCode As Object = row("Code")

            If (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") _
                Then
                Return False
            End If
            Return True
        End Function
        Public Sub SetCostDate(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Global.Error.CannotChangeEqCostDate}")
            e.ProposedValue = e.Row(e.Column)
        End Sub
        Public Sub SetCost(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            m_updating = True
            Try
                e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.UnitPrice)
            Catch ex As SyntaxErrorException
                e.ProposedValue = e.Row(e.Column)
            End Try
            m_updating = False
        End Sub
        Private Function DupEquipment(ByVal eq As EqCost) As Boolean
            For Each row As TreeRow In Me.m_itemTable.Childs
                If Not row.IsNull("lcil_labor") AndAlso IsNumeric(row("lcil_labor")) AndAlso CInt(row("lcil_labor")) = eq.Id Then
                    Return True
                End If
            Next
            Return False
        End Function
        Private m_updating As Boolean = False
        Public Sub SetEquipmentValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim myEquipment As New EqCost(e.ProposedValue.ToString)
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If myEquipment.Originated Then
                If DupEquipment(myEquipment) Then
                    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {myEquipment.ListPanelTitle, e.ProposedValue.ToString})
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
                End If
                Dim myUnit As Unit = myEquipment.Unit
                If myUnit Is Nothing OrElse Not myUnit.Originated Then
                    msgServ.ShowMessageFormatted("${res:Global.Error.NoEquipmentUnit}", New String() {e.ProposedValue.ToString})
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
                End If
                If Not Lci.ValidUnit(myUnit) Then
                    msgServ.ShowMessageFormatted("${res:Global.Error.EquipmentLCIUnitNotMatched}", New String() {myUnit.Name, e.ProposedValue.ToString, Me.Lci.Name})
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
                End If
                e.Row("Unit") = myUnit.Name
                e.Row("lcil_labor") = myEquipment.Id
                e.ProposedValue = myEquipment.Code
                e.Row("Name") = myEquipment.Name
                e.Row("Cost") = myEquipment.Cost
                e.Row("CostDate") = myEquipment.CostDate
            End If
            m_updating = False
        End Sub

        Private Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
            Try
                If Not Me.IsInitialized Then
                    Return
                End If
                Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
                Me.OnPropertyChanged(Me, pe)
                e.Row.SetColumnError("Code", "")
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
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

        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "LCIEQCostLink"
            End Get
        End Property
    End Class

    Public Class LCIEquipmentCostLinkItem

#Region "Members"
        Private m_LCIEquipmentCostLink As LCIEquipmentCostLink
        Private m_lineNumber As Integer
        Private m_eq As EqCost
        Private m_note As String = ""
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
                If dr.Table.Columns.Contains(aliasPrefix & "lcil_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "lcil_lineNumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & "lcil_lineNumber"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "lcil_note") AndAlso Not dr.IsNull(aliasPrefix & "lcil_note") Then
                    .m_note = CStr(dr(aliasPrefix & "lcil_note"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "labor_id") AndAlso Not dr.IsNull(aliasPrefix & "labor_id") Then
                    If Not dr.IsNull("labor_id") Then
                        .m_eq = New EqCost(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "lcil_labor") AndAlso Not dr.IsNull(aliasPrefix & "lcil_labor") Then
                        .m_eq = New EqCost(CInt(dr(aliasPrefix & "lcil_labor")))
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
        Public Property LCIEquipmentCostLink() As LCIEquipmentCostLink            Get                Return m_LCIEquipmentCostLink            End Get            Set(ByVal Value As LCIEquipmentCostLink)                m_LCIEquipmentCostLink = Value            End Set        End Property
        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property EqCost() As EqCost            Get                Return m_eq            End Get            Set(ByVal Value As EqCost)                m_eq = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Me.LCIEquipmentCostLink.IsInitialized = False
            row("lcil_linenumber") = Me.LineNumber
            If Not Me.EqCost Is Nothing Then
                row("lcil_labor") = Me.EqCost.Id
                row("Code") = Me.EqCost.Code
                row("Name") = Me.EqCost.Name
                row("Cost") = Me.EqCost.Cost
                If Not Me.EqCost.Unit Is Nothing Then
                    row("Unit") = Me.EqCost.Unit.Name
                End If
                row("CostDate") = Me.EqCost.CostDate
            End If
            If row.IsNull("Cost") OrElse Not IsNumeric(row("Cost")) OrElse CDec(row("Cost")) = 0 Then
                row("Cost") = ""
            End If
            row("lcil_note") = Me.Note
            Me.LCIEquipmentCostLink.IsInitialized = True
        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Try
                If Not row.IsNull(("lcil_linenumber")) Then
                    Me.LineNumber = CInt(row("lcil_linenumber"))
                End If
                If Not row.IsNull(("lcil_labor")) Then
                    Me.EqCost = New EqCost(CInt(row("lcil_labor")))
                End If
                If Not row.IsNull("lcil_note") Then
                    Me.Note = CStr(row("lcil_note"))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

    End Class
End Namespace
