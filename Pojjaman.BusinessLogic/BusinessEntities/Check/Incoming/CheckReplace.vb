Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class CheckReplace
        Inherits SimpleBusinessEntityBase
        Implements IHasIBillablePerson

#Region "Member"
        Private m_cust As Customer
        Private m_bankacct As BankAccount
        Private m_entitybase As IncomingCheck
        Private m_issuedate As Date
        Private m_note As String

        Private m_updatedstatus As IncomingCheckDocStatus
        Private m_totalamount As Decimal

        Private m_itemTable As TreeTable
        Private m_checktype As CheckType
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Public Sub New(ByVal Code As String)
            MyBase.New(Code)
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
            ReLoadItems(ds, aliasPrefix)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                m_cust = New Customer
                m_bankacct = New BankAccount
                m_entitybase = New IncomingCheck
                m_issuedate = Now.Date
                m_updatedstatus = New IncomingCheckDocStatus(6)    ' นำฝาก ...
                m_checktype = New CheckType(m_entitybase.EntityId)
            End With
            ReLoadItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Construct(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' Issuedate ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_issuedate") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_issuedate") Then
                    .m_issuedate = CDate(dr(aliasPrefix & Me.Prefix & "_issuedate"))
                End If
                ' Note ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If
                ' customer
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cust") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cust") Then
                    .m_cust = New Customer(CInt(dr(aliasPrefix & Me.Prefix & "_cust")))
                End If
                ' BankAccount
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankacct") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankacct") Then
                    .m_bankacct = New BankAccount(CInt(dr(aliasPrefix & Me.Prefix & "_bankacct")))
                End If
                ' Check type ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_checktype") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_checktype") Then
                    .m_checktype = New CheckType(CInt(dr(aliasPrefix & Me.Prefix & "_checktype")))
                End If
                ' Total amount ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_totalamount") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_totalamount") Then
                    .m_totalamount = CInt(dr(aliasPrefix & Me.Prefix & "_totalamount"))
                End If
                ' check status มี 2 สถานะ...IncomingCheckStatus , OutgoingCheckStatus
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_updatedstatus") _
                  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_updatedstatus") Then
                    m_updatedstatus = New IncomingCheckDocStatus(CInt(dr(aliasPrefix & Me.Prefix & "_updatedstatus")))
                End If
            End With
        End Sub

#End Region

#Region "Properties"
        Public Property CheckType() As CheckType
            Get
                Return m_checktype
            End Get
            Set(ByVal Value As CheckType)
                m_checktype = Value
            End Set
        End Property

        Public Property EntityBase() As IncomingCheck
            Get
                Return m_entitybase
            End Get
            Set(ByVal Value As IncomingCheck)
                m_entitybase = Value
            End Set
        End Property

        Public Property IssueDate() As Date
            Get
                Return m_issuedate
            End Get
            Set(ByVal Value As Date)
                m_issuedate = Value
            End Set
        End Property

        Public Property Customer() As Customer
            Get
                Return m_cust
            End Get
            Set(ByVal Value As Customer)
                m_cust = Value
            End Set
        End Property

        Public Property BankAccount() As BankAccount
            Get
                Return m_bankacct
            End Get
            Set(ByVal Value As BankAccount)
                m_bankacct = Value
            End Set
        End Property

        Public Property TotalAmount() As Decimal
            Get
                Return m_totalamount
            End Get
            Set(ByVal Value As Decimal)
                m_totalamount = Value
            End Set
        End Property
        Public Property Note() As String
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property

        Public Property UpdatedStatus() As IncomingCheckDocStatus
            Get
                Return m_updatedstatus
            End Get
            Set(ByVal Value As IncomingCheckDocStatus)
                m_updatedstatus = Value
            End Set
        End Property

        Public Property ItemTable() As TreeTable            Get                Return m_itemTable            End Get            Set(ByVal Value As TreeTable)                m_itemTable = Value            End Set        End Property

#End Region

#Region "Overrides"

        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "CheckReplace"
            End Get
        End Property

        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "cqupdate"
            End Get
        End Property
        Public Overrides ReadOnly Property TableName() As String
            Get
                Return "CheckUpdate"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.CheckReplace.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.CheckReplace"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.CheckReplace"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.CheckReplace.ListLabel}"
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
        Public Shared Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "CheckUpdate"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            ' line number ...
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.Alignment = HorizontalAlignment.Center
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "linenumber"
            ' document code ...
            Dim csCode As New TreeTextColumn
            csCode.MappingName = "code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 70
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = False
            csCode.TextBox.Name = "code"
            ' Check Find button ...
            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf CheckClicked
            ' check docudate ...
            Dim csDocDate As New TreeTextColumn
            csDocDate.MappingName = "docdate"
            csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.DocDateHeaderText}")
            csDocDate.NullText = ""
            csDocDate.Width = 120
            csDocDate.Alignment = HorizontalAlignment.Center
            csDocDate.DataAlignment = HorizontalAlignment.Center
            csDocDate.ReadOnly = True
            csDocDate.TextBox.Name = "docdate"
            ' CqCode ...
            Dim csCqcode As New TreeTextColumn
            csCqcode.MappingName = "cqcode"
            csCqcode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CqCodeHeaderText}")
            csCqcode.NullText = ""
            csCqcode.Width = 100
            csCqcode.Alignment = HorizontalAlignment.Center
            csCqcode.DataAlignment = HorizontalAlignment.Left
            csCqcode.ReadOnly = True
            csCqcode.TextBox.Name = "cqcode"
            ' recievepient ...
            Dim csRecipient As New TreeTextColumn
            csRecipient.MappingName = "recipient"
            csRecipient.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.recipientHeaderText}")
            csRecipient.NullText = ""
            csRecipient.Alignment = HorizontalAlignment.Center
            csRecipient.DataAlignment = HorizontalAlignment.Left
            csRecipient.Width = 150
            csRecipient.ReadOnly = True
            csRecipient.TextBox.Name = "recipient"
            ' Bank account code ...
            Dim csBankacctCode As New TreeTextColumn
            csBankacctCode.MappingName = "bankacct_code"
            csBankacctCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankacctCodeCheckDetail.BankAcctcodeHeaderText}")
            csBankacctCode.NullText = ""
            csBankacctCode.Alignment = HorizontalAlignment.Center
            csBankacctCode.DataAlignment = HorizontalAlignment.Left
            csBankacctCode.Width = 100
            csBankacctCode.ReadOnly = True
            csBankacctCode.TextBox.Name = "bankacct_code"
            ' Bank account name ...
            Dim csBankacctName As New TreeTextColumn
            csBankacctName.MappingName = "bankacct_name"
            csBankacctName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankacctNameHeaderText}")
            csBankacctName.NullText = ""
            csBankacctName.Alignment = HorizontalAlignment.Center
            csBankacctName.DataAlignment = HorizontalAlignment.Left
            csBankacctName.Width = 120
            csBankacctName.ReadOnly = True
            csBankacctName.TextBox.Name = "bankacct_name"
            ' Bank name ...
            Dim csBankName As New TreeTextColumn
            csBankName.MappingName = "bank_name"
            csBankName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankNameHeaderText}")
            csBankName.NullText = ""
            csBankName.Alignment = HorizontalAlignment.Center
            csBankName.DataAlignment = HorizontalAlignment.Left
            csBankName.Width = 150
            csBankName.ReadOnly = True
            csBankName.TextBox.Name = "bank_name"
            ' Check amount ...
            Dim csCheckAmnt As New TreeTextColumn
            csCheckAmnt.MappingName = "check_amount"
            csCheckAmnt.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CheckAmountHeaderText}")
            csCheckAmnt.NullText = ""
            csCheckAmnt.Width = 80
            csCheckAmnt.Alignment = HorizontalAlignment.Center
            csCheckAmnt.DataAlignment = HorizontalAlignment.Right
            csCheckAmnt.ReadOnly = True
            csCheckAmnt.Format = "#,##0.00"
            csCheckAmnt.TextBox.Name = "check_amount"

            ' Add column style ...
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csCqcode)
            dst.GridColumnStyles.Add(csDocDate)
            dst.GridColumnStyles.Add(csRecipient)
            'dst.GridColumnStyles.Add(csBankacctCode)
            'dst.GridColumnStyles.Add(csBankacctName)
            dst.GridColumnStyles.Add(csBankName)
            dst.GridColumnStyles.Add(csCheckAmnt)

            Return dst
        End Function

        Public Shared Event CheckButtonClick As DataGridButtonColumn.ButtonColumnClickHandler

        Public Shared Sub CheckClicked(ByVal e As ButtonColumnEventArgs)
            RaiseEvent CheckButtonClick(e)
        End Sub

        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("CheckUpdate")
            myDatatable.Columns.Add(New DataColumn("linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("cqcode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("docdate", GetType(Date)))
            myDatatable.Columns.Add(New DataColumn("recipient", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bankacct_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bankacct_name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bank_name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_amount", GetType(Decimal)))
            myDatatable.Columns.Add(New DataColumn("cqupdatei_entity", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("cqupdatei_beforestatus", GetType(Integer)))
            Return myDatatable
        End Function
#End Region

#Region "Methods"
        Public Overloads Overrides Sub ExecuteSaveSproc(ByVal returnVal As SqlParameter, ByVal sqlparams As SqlParameter(), ByVal theTime As Date, ByVal theUser As User)
            ' Execute Store Procedure ...
            If Not Me.Originated Then
                SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Insert" & Me.TableName & "Type3456", sqlparams)
                If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) > 0 Then
                    Me.Id = CInt(returnVal.Value)
                    Me.OriginDate = theTime
                    Me.Originator = theUser
                    If Me.Canceled Then
                        'สร้างแล้ว cancel ทันที --> เป็นไปได้
                        Me.CancelPerson = theUser
                        Me.CancelDate = theTime
                    End If
                End If
            Else
                SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Update" & Me.TableName & "Type3456", sqlparams)
                If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) > 0 Then
                    Me.LastEditDate = theTime
                    Me.LastEditor = theUser
                    Me.Edited = True
                    If Me.Canceled Then
                        'cancel!!
                        Me.CancelPerson = theUser
                        Me.CancelDate = theTime
                    Else
                        'ยกเลิกการ Canceled
                        Me.CancelPerson = Nothing
                        Me.CancelDate = Date.MinValue
                    End If
                End If
            End If
        End Sub

        Private Sub ResetID(ByVal oldid As Integer)
            Me.Id = oldid
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                If .MaxRowIndex < 0 Then '.ItemTable.Childs.Count = 0 Then
                    Return New SaveErrorException(.StringParserService.Parse("${res:Global.Error.NoItem}"))
                End If

                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current

                ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
                Dim paramArrayList As New ArrayList

                paramArrayList.Add(returnVal)
                If .Originated Then
                    paramArrayList.Add(New SqlParameter("@" & .Prefix & "_id", .Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_code", .Code))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_issuedate", IIf(.IssueDate.Equals(Date.MinValue), DBNull.Value, .IssueDate)))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_checktype", .CheckType.Value))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_totalamount", .TotalAmount))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_note", .Note))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_updatedstatus", .UpdatedStatus.Value))

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_bankacct", IIf(Me.BankAccount.Originated, Me.BankAccount.Id, DBNull.Value)))

                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(.ConnectionString)
                conn.Open()
                trans = conn.BeginTransaction()

                Dim oldid As Integer = Me.Id

                Try
                    .ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
                    If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) > 0 Then
                        SaveDetail(.Id, conn, trans)
                    End If
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
        Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
            Dim da As New SqlDataAdapter("Select * from CheckUpdateItem where cqupdatei_cqupdateid = " & Me.Id, conn)
            Dim cmdBuilder As New SqlCommandBuilder(da)

            Dim ds As New DataSet

            da.SelectCommand.Transaction = trans

            'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans

            da.Fill(ds, "CheckUpdateItem")

            Dim dbCount As Integer = ds.Tables("CheckUpdateItem").Rows.Count
            Dim itemCount As Integer = Me.ItemTable.Childs.Count
            Dim i As Integer = 0
            With ds.Tables("CheckUpdateItem")
                For Each row As DataRow In .Rows
                    row.Delete()
                Next
                For n As Integer = 0 To Me.MaxRowIndex
                    Dim item As TreeRow = Me.m_itemTable.Childs(n)
                    If ValidateRow(item) Then
                        i += 1
                        Dim dr As DataRow = .NewRow
                        dr("cqupdatei_cqupdateid") = Me.Id
                        dr("cqupdatei_linenumber") = i 'item("pri_linenumber")
                        dr("cqupdatei_entity") = item("cqupdatei_entity")
                        dr("cqupdatei_beforestatus") = item("cqupdatei_beforestatus")
                        .Rows.Add(dr)

                        ' update OutgoingCheck or IncomingCheck ...
                        UpdateCheckStatus(CInt(item("cqupdatei_entity")), conn, trans)

                    End If

                Next

            End With
            Dim dt As DataTable = ds.Tables("CheckUpdateItem")
            ' First process deletes.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        End Function

        Private Function UpdateCheckStatus(ByVal checkID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
            Dim sqlSelecttext As String

            sqlSelecttext = "Select * from IncomingCheck Where check_id = " & checkID

            Dim da As New SqlDataAdapter(sqlSelecttext, conn)
            Dim cmdBuilder As New SqlCommandBuilder(da)

            Dim ds As New DataSet

            da.SelectCommand.Transaction = trans

            'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans

            da.Fill(ds)
            With ds.Tables(0)
                For Each row As DataRow In .Rows
                    'MessageBox.Show(Me.UpdatedStatus.Description, "CheckReplace")
                    row("check_status") = Me.UpdatedStatus.Value
                Next
            End With
            Dim dt As DataTable = ds.Tables(0)
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
            LoadItems(ds, aliasPrefix)
            Me.IsInitialized = True
        End Sub
        Private Sub LoadItems()
            If Not Me.Originated Then
                Return
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
            , CommandType.StoredProcedure _
            , "GetCheckUpdateItem" _
            , New SqlParameter("@cqupdatei_cqupdateid", Me.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New CheckReplaceItem(row, "")
                ' Hack : Huaneng ...
                Me.Add(item)
            Next
        End Sub
        Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            For Each dr As DataRow In ds.Tables(1).Rows
                Dim item As New CheckReplaceItem(dr, aliasPrefix)
                'item.CheckReplace = Me
                Me.Add(item)
            Next
        End Sub
        Public Sub AddBlankRow(ByVal count As Integer)
            For i As Integer = 0 To count - 1
                Dim newItem As New BlankItem("")
                Dim mtwItem As New CheckReplaceItem
                Me.ItemTable.AcceptChanges()
                Me.Add(mtwItem)
            Next
        End Sub
        Public Function Add(ByVal item As CheckReplaceItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.Add
            item.LineNumber = Me.ItemTable.Childs.Count
            'item.CheckReplace = Me
            item.CopyToDataRow(myRow)
            Return myRow
        End Function
        Public Function Insert(ByVal index As Integer, ByVal item As CheckReplaceItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
            item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
            'item.CheckReplace = Me
            item.CopyToDataRow(myRow)
            ReIndex(index + 1)
            Return myRow
        End Function
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
                Me.ItemTable.Childs(i)("linenumber") = i + 1
            Next
        End Sub
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If

            If Not e.Row.RowState = DataRowState.Detached Then
                e.Row.SetColumnError("Code", "")
            Else
                e.Row.SetColumnError("Code", Me.StringParserService.Parse("${res:Global.Error.GridHasNewLine}"))
                'If Not Me.m_validator Is Nothing Then
                '    Me.m_validator.HasNewRow = True
                'End If
            End If
            Me.m_itemTable.AcceptChanges()
            Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
            If index = Me.m_itemTable.Childs.Count - 1 Then

            End If
            Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
            Me.OnPropertyChanged(Me, pe)
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetEntityValue(e)
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

            If IsDBNull(proposedCode) Then
                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.CodeMissing}"))
            Else
                e.Row.SetColumnError("code", "")
            End If

        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Dim proposedCode As Object = row("Code")

            If (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") Then
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
        Public Sub SetEntityName(ByVal e As DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If
            e.Row("Code") = DBNull.Value
        End Sub
        Private m_entitySetting As Boolean = False
        Public Sub SetEntityValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If EntityBase Is Nothing Then
                Return
            End If

            SetEntityIncomingCheck(e)

        End Sub
        Private Sub SetEntityIncomingCheck(ByVal e As System.Data.DataColumnChangeEventArgs)
            Dim entity As New IncomingCheck(e.ProposedValue.ToString)
            m_entitySetting = True
            If entity Is Nothing Then
                Debug.Assert(Not IsNothing(entity), "Entity nothing...")
                Return
            End If
            If entity.Originated Then
                e.Row("cqupdatei_entity") = entity.Id
                e.Row("docdate") = entity.ReceiveDate
                e.Row("cqcode") = entity.CqCode
                e.Row("recipient") = entity.ReceivePerson.Name
                e.Row("bank_name") = entity.Bank.Name
                e.Row("check_amount") = entity.Amount
                e.ProposedValue = entity.Code
            Else
                e.Row("cqupdatei_entity") = DBNull.Value
                e.Row("docdate") = DBNull.Value
                e.Row("cqcode") = DBNull.Value
                e.Row("recipient") = DBNull.Value
                e.Row("bank_name") = DBNull.Value
                e.Row("check_amount") = DBNull.Value
                e.ProposedValue = DBNull.Value
            End If
            m_entitySetting = False
        End Sub

#End Region

#Region "IHasIBillablePerson"
        Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
            Get
                Return Me.Customer
            End Get
            Set(ByVal Value As IBillablePerson)
                If TypeOf Value Is Customer Then
                    Me.Customer = CType(Value, Customer)
                End If
            End Set
        End Property
#End Region
    End Class
End Namespace