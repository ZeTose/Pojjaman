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
    Public Class SupplierLCICostLink
        Inherits SimpleBusinessEntityBase

#Region "Members"
        Private m_itemTable As TreeTable
        Private m_supplier As Supplier
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
        Public Sub New(ByVal sup As Supplier)
            Me.Supplier = sup
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
        Public Property Supplier() As Supplier            Get                Return m_supplier            End Get            Set(ByVal Value As Supplier)                m_supplier = Value            End Set        End Property
        Public Property ItemTable() As TreeTable            Get                Return m_itemTable            End Get            Set(ByVal Value As TreeTable)                m_itemTable = Value            End Set        End Property
#End Region

#Region "Shared"
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("LciCost")
            myDatatable.Columns.Add(New DataColumn("lcis_linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("lcis_lci", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("lcis_unit", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("lcis_cost", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("lcis_note", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("lcis_leadtime", GetType(String)))
            Dim dateCol As New DataColumn("lcis_costdate", GetType(Date))
            dateCol.DefaultValue = Date.MinValue
            myDatatable.Columns.Add(dateCol)

            'เพื่อให้แสดง error ตามคอลัมน์เป็นภาษาที่ต้องการ
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.CodeHeaderText}")
            myDatatable.Columns("lcis_lci").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.DescriptionHeaderText}")
            myDatatable.Columns("Unit").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.UnitHeaderText}")
            myDatatable.Columns("lcis_cost").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.CostHeaderText}")

            Return myDatatable
        End Function
#End Region

#Region "Methods"
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
            Dim da As New SqlDataAdapter("Select * from supplierlcicost where lcis_lci=" & Me.m_supplier.Id, conn)
            Dim cmdBuilder As New SqlCommandBuilder(da)
            Dim ds As New DataSet

            da.SelectCommand.Transaction = trans

            'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans

            da.Fill(ds, "supplierlcicost")

            Try
                Dim i As Integer = 0
                With ds.Tables("supplierlcicost")
                    For Each row As DataRow In .Rows
                        row.Delete()
                    Next
                    For n As Integer = 0 To Me.MaxRowIndex
                        Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
                        If ValidateRow(itemRow) Then
                            i += 1
                            Dim item As New SupplierLCICostLinkItem
                            item.CopyFromDataRow(itemRow)
                            Dim dr As DataRow = .NewRow
                            dr("lcis_suppier") = Me.m_supplier.Id
                            dr("lcis_linenumber") = i
                            If item.Lci.Originated Then
                                dr("lcis_lci") = item.Lci.Id
                            End If
                            dr("lcis_cost") = item.Cost
                            dr("lcis_leadTime") = item.LeadTime
                            dr("lcis_Note") = item.Note
                            If item.Unit.Originated Then
                                dr("lcis_unit") = item.Unit.Id
                            End If
                            If Not item.CostDate.Equals(Date.MinValue) Then
                                dr("lcis_costdate") = item.CostDate
                            End If
                            .Rows.Add(dr)
                        End If
                    Next
                End With
                Dim dt As DataTable = ds.Tables("supplierlcicost")
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
            If Me.m_supplier Is Nothing OrElse Not Me.m_supplier.Originated Then
                Return
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.SiteConnectionString _
            , CommandType.StoredProcedure _
            , "GetSupplierLCICosts" _
            , New SqlParameter("@supplier_id", Me.m_supplier.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New SupplierLCICostLinkItem(row, "")
                'item.SupplierLCICostLink = Me
                'Me.Add(item)
            Next
        End Sub
        Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            For Each dr As DataRow In ds.Tables(1).Rows
                Dim item As New SupplierLCICostLinkItem(dr, aliasPrefix)
                item.SupplierLCICostLink = Me
                Me.Add(item)
            Next
        End Sub
        Public Sub AddBlankRow(ByVal count As Integer)
            For i As Integer = 0 To count - 1
                Dim myItem As New SupplierLCICostLinkItem
                myItem.Lci = New LCIItem
                myItem.Unit = New Unit
                Me.ItemTable.AcceptChanges()
                Me.Add(myItem)
            Next
        End Sub
        Public Function Add(ByVal item As SupplierLCICostLinkItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.Add
            item.LineNumber = Me.ItemTable.Childs.Count
            item.SupplierLCICostLink = Me
            item.CopyToDataRow(myRow)
            Return myRow
        End Function
        Public Function Insert(ByVal index As Integer, ByVal item As SupplierLCICostLinkItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
            item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
            item.SupplierLCICostLink = Me
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
                Me.ItemTable.Childs(i)("lcis_linenumber") = i + 1
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
                        SetCode(e)
                    Case "unit"
                        SetUnitValue(e)
                    Case "lcis_cost"
                        SetCost(e)
                    Case "lcis_leadtime"
                        SetLeadTime(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim unit As Object = e.Row("unit")
            Dim Code As Object = e.Row("Code")
            Dim Name As Object = e.Row("Name")
            Dim lcis_cost As Object = e.Row("lcis_cost")
            Dim lcis_leadtime As Object = e.Row("lcis_leadtime")
            Dim lcis_costdate As Object = e.Row("lcis_costdate")

            Select Case e.Column.ColumnName.ToLower
                Case "unit"
                    unit = e.ProposedValue
                Case "code"
                    Code = e.ProposedValue
                Case "lcis_cost"
                    lcis_cost = e.ProposedValue
                Case "lcis_costdate"
                    lcis_costdate = e.ProposedValue
                Case "lcis_leadtime"
                    lcis_leadtime = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If (IsDBNull(unit) OrElse CStr(unit).Length = 0) _
                And (IsDBNull(Code) OrElse CStr(Code).Length = 0) _
                And (IsDBNull(lcis_cost) OrElse Not IsNumeric(lcis_cost) OrElse CDec(lcis_cost) = 0) _
                And (IsDBNull(lcis_costdate) OrElse Not IsDate(lcis_costdate) OrElse CDate(lcis_costdate).Equals(Date.MinValue)) _
                And (IsDBNull(lcis_leadtime) OrElse Not IsNumeric(lcis_leadtime) OrElse CDec(lcis_leadtime) = 0) _
                Then
                isBlankRow = True
            End If

            If Not isBlankRow Then
                If IsDBNull(Name) Then
                    e.Row.SetColumnError("Name", Me.StringParserService.Parse("${res:Global.Error.ItemMissing}"))
                Else
                    e.Row.SetColumnError("Name", "")
                End If

                If IsDBNull(unit) Then
                    e.Row.SetColumnError("Unit", Me.StringParserService.Parse("${res:Global.Error.UnitMissing}"))
                Else
                    e.Row.SetColumnError("Unit", "")
                End If

                If IsDBNull(lcis_cost) OrElse Not IsNumeric(lcis_cost) OrElse CDec(lcis_cost) = 0 Then
                    e.Row.SetColumnError("lcis_cost", Me.StringParserService.Parse("${res:Global.Error.CostMissing}"))
                Else
                    e.Row.SetColumnError("lcis_cost", "")
                End If

                If IsDBNull(lcis_costdate) OrElse Not IsDate(lcis_costdate) OrElse CDate(lcis_costdate).Equals(Date.MinValue) Then
                    e.Row.SetColumnError("lcis_costdate", Me.StringParserService.Parse("${res:Global.Error.CostDateMissing}"))
                Else
                    e.Row.SetColumnError("lcis_costdate", "")
                End If
            End If
        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Dim proposedUnit As Object = row("lcis_unit")
            Dim proposedCode As Object = row("Code")
            Dim proposedCost As Object = row("lcis_cost")
            Dim lcis_costdate As Object = row("lcis_costdate")

            Dim flag As Boolean = True
            If (IsDBNull(proposedUnit) OrElse CInt(proposedUnit) = 0) _
                And (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") _
                And (IsDBNull(proposedCost) OrElse Not IsNumeric(proposedCost) OrElse CDec(proposedCost) = 0) _
                And (IsDBNull(lcis_costdate) OrElse Not IsDate(lcis_costdate) OrElse CDate(lcis_costdate).Equals(Date.MinValue)) _
                Then
                flag = False
            End If

            Return flag
        End Function
        Public Sub SetLeadTime(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            m_updating = True
            Try
                e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Int)
            Catch ex As SyntaxErrorException
                e.ProposedValue = e.Row(e.Column)
            End Try
            m_updating = False
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
        Private Function DupLCI(ByVal lci As LCIItem) As Boolean
            For Each row As TreeRow In Me.m_itemTable.Childs
                If Not row.IsNull("lcis_lci") AndAlso IsNumeric(row("lcis_lci")) AndAlso CInt(row("lcis_lci")) = lci.Id Then
                    Return True
                End If
            Next
            Return False
        End Function
        Private m_updating As Boolean = False
        Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim myLci As New LCIItem(e.ProposedValue.ToString)
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If myLci.Originated Then
                If DupLCI(myLci) Then
                    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {myLci.ListPanelTitle, e.ProposedValue.ToString})
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
                End If
                e.Row("lcis_lci") = myLci.Id
                e.ProposedValue = myLci.Code
                e.Row("Name") = myLci.Name
            End If
            m_updating = False
        End Sub
        Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            Dim err As String = ""
            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
                'If Not Me.Lci.ValidUnit(myUnit) Then
                '    err = "${res:Global.Error.NoUnitConversion}"
                'End If
            Else
                err = "${res:Global.Error.InvalidUnit}"
            End If
            If err.Length = 0 Then
                e.Row("lcis_unit") = myUnit.Id
                e.ProposedValue = myUnit.Name
            Else
                e.ProposedValue = e.Row(e.Column)
                msgServ.ShowMessage(err)
            End If
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
                Return "LCISuplierCostLink"
            End Get
        End Property

    End Class

    Public Class SupplierLCICostLinkItem

#Region "Members"
        Private m_supplierLciCostLink As SupplierLCICostLink
        Private m_lineNumber As Integer
        Private m_lci As LCIItem
        Private m_cost As Decimal
        Private m_note As String = ""
        Private m_leadTime As Integer
        Private m_unit As Unit
        Private m_costDate As Date
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
                If dr.Table.Columns.Contains(aliasPrefix & "lcis_cost") AndAlso Not dr.IsNull(aliasPrefix & "lcis_cost") Then
                    .m_cost = CInt(dr(aliasPrefix & "lcis_cost"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "lcis_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "lcis_lineNumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & "lcis_lineNumber"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
                    If Not dr.IsNull("unit_id") Then
                        .m_unit = New Unit(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "lcis_unit") AndAlso Not dr.IsNull(aliasPrefix & "lcis_unit") Then
                        .m_unit = New Unit(CInt(dr(aliasPrefix & "lcis_unit")))
                    End If
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "lcis_note") AndAlso Not dr.IsNull(aliasPrefix & "lcis_note") Then
                    .m_note = CStr(dr(aliasPrefix & "lcis_note"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "lcis_costDate") AndAlso Not dr.IsNull(aliasPrefix & "lcis_costDate") Then
                    .m_costDate = CDate(dr(aliasPrefix & "lcis_costDate"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "lcis_leadtime") AndAlso Not dr.IsNull(aliasPrefix & "lcis_leadtime") Then
                    .m_leadTime = CInt(dr(aliasPrefix & "lcis_leadtime"))
                End If

                'If dr.Table.Columns.Contains(aliasPrefix & "lcis_lci") AndAlso Not dr.IsNull(aliasPrefix & "lcis_lci") Then
                '    .m_lci = New LCIItem(CInt(dr(aliasPrefix & "lcis_lci")))
                'End If
            End With
        End Sub
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Property SupplierLCICostLink() As SupplierLCICostLink            Get                Return m_supplierLciCostLink            End Get            Set(ByVal Value As SupplierLCICostLink)                m_supplierLciCostLink = Value            End Set        End Property
        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property LeadTime() As Integer            Get                Return m_leadTime            End Get            Set(ByVal Value As Integer)                m_leadTime = Value            End Set        End Property        Public Property Lci() As LCIItem            Get                Return m_lci            End Get            Set(ByVal Value As LCIItem)                m_lci = Value            End Set        End Property        Public Property Unit() As Unit            Get                Return m_unit            End Get            Set(ByVal Value As Unit)                m_unit = Value            End Set        End Property        Public Property Cost() As Decimal            Get                Return m_cost            End Get            Set(ByVal Value As Decimal)                m_cost = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property
        Public Property CostDate() As Date            Get                Return m_costDate            End Get            Set(ByVal Value As Date)                m_costDate = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Me.SupplierLCICostLink.IsInitialized = False
            row("lcis_linenumber") = Me.LineNumber
            If Not Me.Lci Is Nothing Then
                row("lcis_lci") = Me.Lci.Id
                row("Code") = Me.Lci.Code
                row("Name") = Me.Lci.Name
            End If
            If Not Me.Unit Is Nothing Then
                row("lcis_unit") = Me.Unit.Id
                row("Unit") = Me.Unit.Name
            End If
            If Me.Cost <> 0 Then
                row("lcis_cost") = Me.Cost
            Else
                row("lcis_cost") = ""
            End If
            row("lcis_costdate") = Me.CostDate
            row("lcis_note") = Me.Note
            If Me.LeadTime <> 0 Then
                row("lcis_leadtime") = Me.LeadTime
            Else
                row("lcis_leadtime") = ""
            End If
            Me.SupplierLCICostLink.IsInitialized = True
        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Try
                If Not row.IsNull(("lcis_linenumber")) Then
                    Me.LineNumber = CInt(row("lcis_linenumber"))
                End If
                If Not row.IsNull(("lcis_lci")) Then
                    Me.Lci = New LCIItem(CInt(row("lcis_lci")))
                End If

                If Not row.IsNull(("lcis_unit")) Then
                    Me.Unit = New Unit(CInt(row("lcis_unit")))
                End If


                If Not row.IsNull(("lcis_cost")) Then
                    If CStr(row("lcis_cost")).Length = 0 Then
                        Me.Cost = 0
                    Else
                        Me.Cost = CDec(row("lcis_cost"))
                    End If
                End If

                If Not row.IsNull("lcis_leadtime") Then
                    If CStr(row("lcis_leadtime")).Length = 0 Then
                        Me.LeadTime = 0
                    Else
                        Me.LeadTime = CInt(row("lcis_leadtime"))
                    End If
                End If
                If Not row.IsNull("lcis_note") Then
                    Me.Note = CStr(row("lcis_note"))
                End If
                If Not row.IsNull("lcis_costdate") Then
                    Me.CostDate = CDate(row("lcis_costdate"))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

    End Class


End Namespace
