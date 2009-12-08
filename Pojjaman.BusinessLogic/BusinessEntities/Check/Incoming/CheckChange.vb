Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class CheckChange
        Inherits SimpleBusinessEntityBase
    Implements IGLAble, IHasIBillablePerson, ICheckPeriod


#Region "Member"
        Private m_entitybase As New IncomingCheck
        Private m_issuedate As Date
        Private m_acct As Account
        Private m_cust As Customer
        ' Checktype => IncomingCheck
        ' CheckStatus => เปลี่ยนเช็ครับ

        Private m_otherrevenue As Decimal
        Private m_totalcancel As Decimal

        Private m_cash As Decimal
        Private m_otherexpense As Decimal
        Private m_totalreplace As Decimal

        Private m_note As String
        Private m_status As CheckStatus

        Private m_itemTable As TreeTable
        Private m_itemReplaceTable As TreeTable

        Private m_je As JournalEntry
        Private m_incomingcheckremoved As String
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            ReLoadItems()
            ReLoadReplaceItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged

            AddHandler m_itemReplaceTable.ColumnChanging, AddressOf TreeReplacetable_ColumnChanging
            AddHandler m_itemReplaceTable.ColumnChanged, AddressOf TreeReplacetable_ColumnChanged

        End Sub
        Public Sub New(ByVal Code As String)
            MyBase.New(Code)
            ReLoadItems()
            ReLoadReplaceItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged

            AddHandler m_itemReplaceTable.ColumnChanging, AddressOf TreeReplacetable_ColumnChanging
            AddHandler m_itemReplaceTable.ColumnChanged, AddressOf TreeReplacetable_ColumnChanged

        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
            ReLoadItems()
            ReLoadReplaceItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged

            AddHandler m_itemReplaceTable.ColumnChanging, AddressOf TreeReplacetable_ColumnChanging
            AddHandler m_itemReplaceTable.ColumnChanged, AddressOf TreeReplacetable_ColumnChanged

        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
            ReLoadItems(ds, aliasPrefix)
            ReLoadReplaceItems(ds, aliasPrefix)
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged

            AddHandler m_itemReplaceTable.ColumnChanging, AddressOf TreeReplacetable_ColumnChanging
            AddHandler m_itemReplaceTable.ColumnChanged, AddressOf TreeReplacetable_ColumnChanged

        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
            ReLoadItems()
            ReLoadReplaceItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged

            AddHandler m_itemReplaceTable.ColumnChanging, AddressOf TreeReplacetable_ColumnChanging
            AddHandler m_itemReplaceTable.ColumnChanged, AddressOf TreeReplacetable_ColumnChanged

        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                .m_issuedate = Now.Date
                .m_acct = New Account
                .m_cust = New Customer
                .m_status = New CheckStatus(-1)

                .m_je = New JournalEntry(Me)
                .m_je.DocDate = Me.m_issuedate
            End With
            ReLoadItems()
            ReLoadReplaceItems()
            AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged

            AddHandler m_itemReplaceTable.ColumnChanging, AddressOf TreeReplacetable_ColumnChanging
            AddHandler m_itemReplaceTable.ColumnChanged, AddressOf TreeReplacetable_ColumnChanged

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
                ' account 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_acct") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_acct") Then
                    .m_acct = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_acct")))
                End If
                ' customer 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cust") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cust") Then
                    .m_cust = New Customer(CInt(dr(aliasPrefix & Me.Prefix & "_cust")))
                End If
                ' Cancel 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_otherrevenue") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_otherrevenue") Then
                    .m_otherrevenue = CDec(dr(aliasPrefix & Me.Prefix & "_otherrevenue"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_totalcancel") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_totalcancel") Then
                    .m_totalcancel = CDec(dr(aliasPrefix & Me.Prefix & "_totalcancel"))
                End If
                ' Replace 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_otherexpense") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_otherexpense") Then
                    .m_otherexpense = CDec(dr(aliasPrefix & Me.Prefix & "_otherexpense"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cash") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cash") Then
                    .m_cash = CDec(dr(aliasPrefix & Me.Prefix & "_cash"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_totalreplace") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_totalreplace") Then
                    .m_totalreplace = CDec(dr(aliasPrefix & Me.Prefix & "_totalreplace"))
                End If
                ' note 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If
                ' status
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
                    .m_status = New CheckStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
                End If

                .m_je = New JournalEntry(Me)
            End With
        End Sub

#End Region

#Region "Properties"
        Public ReadOnly Property CheckType() As Integer
            Get
                Return m_entitybase.EntityId
            End Get
        End Property

        Public ReadOnly Property CheckStatus() As Integer
            Get
                Return 6
            End Get
        End Property

        Public ReadOnly Property EntityBase() As IncomingCheck
            Get
                Return m_entitybase
            End Get
        End Property

    Public Property IssueDate() As Date Implements ICheckPeriod.DocDate
      Get
        Return m_issuedate
      End Get
      Set(ByVal Value As Date)
        m_issuedate = Value
      End Set
    End Property

    Public Property Account() As Account
      Get
        Return m_acct
      End Get
      Set(ByVal Value As Account)
        m_acct = Value
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

    Public Property OtherRevenue() As Decimal
      Get
        Return m_otherrevenue
      End Get
      Set(ByVal Value As Decimal)
        m_otherrevenue = Value
      End Set
    End Property

    Public Property TotalCancel() As Decimal
      Get
        Return m_totalcancel
      End Get
      Set(ByVal Value As Decimal)
        m_totalcancel = Value
      End Set
    End Property

    Public Property Cash() As Decimal
      Get
        Return m_cash
      End Get
      Set(ByVal Value As Decimal)
        m_cash = Value
      End Set
    End Property

    Public Property OtherExpense() As Decimal
      Get
        Return m_otherexpense
      End Get
      Set(ByVal Value As Decimal)
        m_otherexpense = Value
      End Set
    End Property

    Public Property TotalReplace() As Decimal
      Get
        Return m_totalreplace
      End Get
      Set(ByVal Value As Decimal)
        m_totalreplace = Value
      End Set
    End Property

    Public Property Note() As String Implements IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property

    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property

    Public Property ItemReplaceTable() As TreeTable      Get        Return m_itemReplaceTable      End Get      Set(ByVal Value As TreeTable)        m_itemReplaceTable = Value      End Set    End Property
    Public ReadOnly Property CheckRemovedInItemTable() As String
      Get
        Return m_incomingcheckremoved   ' จะมีค่าเมื่อ remove item.
      End Get
    End Property
    Public ReadOnly Property CheckInItemTable() As String
      Get
        Dim incomminglist As String
        For Each tr As TreeRow In Me.ItemTable.Childs
          If Me.ValidateRow(tr) Then
            If tr.Table.Columns.Contains("check_id") AndAlso Not tr.IsNull("check_id") Then
              incomminglist += "|" & CInt(tr("check_id")) & "|"
            End If
          End If
        Next
        Return incomminglist
      End Get
    End Property
#End Region

#Region "Overrides"
        Public Overrides Property Status() As CodeDescription
            Get
                Return m_status
            End Get
            Set(ByVal Value As CodeDescription)
                m_status = CType(Value, CheckStatus)
            End Set
        End Property

        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "CheckChange"
            End Get
        End Property

        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "cqChange"
            End Get
        End Property
        Public Overrides ReadOnly Property TableName() As String
            Get
                Return "CheckChange"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.CheckChange.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.CheckChange"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.CheckChange"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.CheckChange.ListLabel}"
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
            Dim myDatatable As TreeTable
            myDatatable = CheckChangeItem.GetSchemaTable
            ' Add columns เพิ่มเติม
            Return myDatatable
        End Function

        Public Shared Function GetSchemaReplaceTable() As TreeTable
            Dim myDatatable As TreeTable
            myDatatable = CheckReplaceItem.GetSchemaTable
            Return myDatatable
        End Function

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
            csCode.MappingName = "check_code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 70
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = False
            csCode.TextBox.Name = "check_code"
            ' Check Find button ...
            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "btnCheck"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf CheckClicked
            ' check docudate ...
            Dim csReceiveDate As New TreeTextColumn
            csReceiveDate.MappingName = "check_receivedate"
            csReceiveDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.DocDateHeaderText}")
            csReceiveDate.NullText = ""
            csReceiveDate.Width = 120
            csReceiveDate.Alignment = HorizontalAlignment.Center
            csReceiveDate.DataAlignment = HorizontalAlignment.Center
            csReceiveDate.ReadOnly = True
            csReceiveDate.Format = "dd/MM/yyyy"
            csReceiveDate.TextBox.Name = "check_receivedate"
            ' CqCode ...
            Dim csCqcode As New TreeTextColumn
            csCqcode.MappingName = "check_cqcode"
            csCqcode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CqCodeHeaderText}")
            csCqcode.NullText = ""
            csCqcode.Width = 100
            csCqcode.Alignment = HorizontalAlignment.Center
            csCqcode.DataAlignment = HorizontalAlignment.Left
            csCqcode.ReadOnly = True
            csCqcode.TextBox.Name = "check_cqcode"
            ' recievepient ...
            Dim csRecipient As New TreeTextColumn
            csRecipient.MappingName = "receivepersonName"
            csRecipient.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.recipientHeaderText}")
            csRecipient.NullText = ""
            csRecipient.Alignment = HorizontalAlignment.Center
            csRecipient.DataAlignment = HorizontalAlignment.Left
            csRecipient.Width = 150
            csRecipient.ReadOnly = True
            csRecipient.TextBox.Name = "receivepersonName"
            
            ' Bank name ...
            Dim csBankName As New TreeTextColumn
            csBankName.MappingName = "bankName"
            csBankName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankNameHeaderText}")
            csBankName.NullText = ""
            csBankName.Alignment = HorizontalAlignment.Center
            csBankName.DataAlignment = HorizontalAlignment.Left
            csBankName.Width = 150
            csBankName.ReadOnly = True
            csBankName.TextBox.Name = "bankName"
            ' Check amount ...
            Dim csCheckAmnt As New TreeTextColumn
            csCheckAmnt.MappingName = "check_amt"
            csCheckAmnt.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CheckAmountHeaderText}")
            csCheckAmnt.NullText = ""
            csCheckAmnt.Width = 80
            csCheckAmnt.Alignment = HorizontalAlignment.Center
            csCheckAmnt.DataAlignment = HorizontalAlignment.Right
            csCheckAmnt.ReadOnly = True
            csCheckAmnt.Format = "#,##0.00"
            csCheckAmnt.TextBox.Name = "check_amt"

            ' Add column style ...
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csCqcode)
            dst.GridColumnStyles.Add(csReceiveDate)
            dst.GridColumnStyles.Add(csRecipient)
            dst.GridColumnStyles.Add(csBankName)
            dst.GridColumnStyles.Add(csCheckAmnt)

            Return dst
        End Function

        Public Shared Function CreateReplaceTableStyle() As DataGridTableStyle
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
            csCode.MappingName = "check_code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 70
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Left
            csCode.ReadOnly = False
            csCode.TextBox.Name = "check_code"

            ' CqCode ...
            Dim csCqcode As New TreeTextColumn
            csCqcode.MappingName = "check_cqcode"
            csCqcode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.CqCodeHeaderText}")
            csCqcode.NullText = ""
            csCqcode.Width = 100
            csCqcode.Alignment = HorizontalAlignment.Center
            csCqcode.DataAlignment = HorizontalAlignment.Left
            csCqcode.ReadOnly = False
            csCqcode.TextBox.Name = "check_cqcode"

            ' check receive date ...
            Dim csReceiveDate As New TreeTextColumn
            csReceiveDate.MappingName = "check_receivedate"
            csReceiveDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.ReceiveDateHeaderText}")
            csReceiveDate.NullText = ""
            csReceiveDate.Width = 100
            csReceiveDate.Alignment = HorizontalAlignment.Center
            csReceiveDate.DataAlignment = HorizontalAlignment.Center
            csReceiveDate.ReadOnly = False
            csReceiveDate.Format = "dd/MM/yyy"
            csReceiveDate.TextBox.Name = "check_receivedate"

            ' check due date ...
            Dim csDueDate As New TreeTextColumn
            csDueDate.MappingName = "check_duedate"
            csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateCheckDetail.DueDateHeaderText}")
            csDueDate.NullText = ""
            csDueDate.Width = 100
            csDueDate.Alignment = HorizontalAlignment.Center
            csDueDate.DataAlignment = HorizontalAlignment.Center
            csDueDate.ReadOnly = False
            csDueDate.Format = "dd/MM/yyy"
            csDueDate.TextBox.Name = "check_duedate"
            
            ' recieve personname ...
            Dim csReceivePerson As New TreeTextColumn
            csReceivePerson.MappingName = "receivepersonName"
            csReceivePerson.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.ReceivePersonHeaderText}")
            csReceivePerson.NullText = ""
            csReceivePerson.Alignment = HorizontalAlignment.Center
            csReceivePerson.DataAlignment = HorizontalAlignment.Left
            csReceivePerson.Width = 150
            csReceivePerson.ReadOnly = False
            csReceivePerson.TextBox.Name = "receivepersonName"
            ' Check Find button ...
            Dim csBtnReceivePerson As New DataGridButtonColumn
            csBtnReceivePerson.MappingName = "btnReceiveperson"
            csBtnReceivePerson.HeaderText = ""
            csBtnReceivePerson.NullText = ""
            'AddHandler csBtnReceivePerson.Click, AddressOf ReplaceCheckClicked

            ' Bank name ...
            Dim csBankName As New TreeTextColumn
            csBankName.MappingName = "bankName"
            csBankName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.BankNameHeaderText}")
            csBankName.NullText = ""
            csBankName.Alignment = HorizontalAlignment.Center
            csBankName.DataAlignment = HorizontalAlignment.Left
            csBankName.Width = 150
            csBankName.ReadOnly = False
            csBankName.TextBox.Name = "bankName"

            ' Check Find button ...
            Dim csBtnBank As New DataGridButtonColumn
            csBtnBank.MappingName = "btnBank"
            csBtnBank.HeaderText = ""
            csBtnBank.NullText = ""
            AddHandler csBtnBank.Click, AddressOf ReplaceCheckClicked

            ' Check amount ...
            Dim csCheckAmnt As New TreeTextColumn
            csCheckAmnt.MappingName = "check_amt"
            csCheckAmnt.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.CheckAmountHeaderText}")
            csCheckAmnt.NullText = ""
            csCheckAmnt.Width = 80
            csCheckAmnt.Alignment = HorizontalAlignment.Center
            csCheckAmnt.DataAlignment = HorizontalAlignment.Right
            csCheckAmnt.ReadOnly = False
            csCheckAmnt.Format = "#,##0.00"
            csCheckAmnt.TextBox.Name = "check_amt"

            ' Note ...
            Dim csNote As New TreeTextColumn
            csNote.MappingName = "check_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RecipientCheckDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 100
            csNote.Alignment = HorizontalAlignment.Center
            csNote.DataAlignment = HorizontalAlignment.Right
            csNote.ReadOnly = False
            csNote.TextBox.Name = "check_note"

            ' Add column style ...
            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csCqcode)
            dst.GridColumnStyles.Add(csReceiveDate)
            dst.GridColumnStyles.Add(csDueDate)

            dst.GridColumnStyles.Add(csReceivePerson)
            dst.GridColumnStyles.Add(csBtnReceivePerson)

            dst.GridColumnStyles.Add(csBankName)
            dst.GridColumnStyles.Add(csBtnBank)

            dst.GridColumnStyles.Add(csCheckAmnt)
            dst.GridColumnStyles.Add(csNote)
            Return dst
        End Function

        Public Shared Event CheckButtonClick As DataGridButtonColumn.ButtonColumnClickHandler

        Public Shared Sub CheckClicked(ByVal e As ButtonColumnEventArgs)
            RaiseEvent CheckButtonClick(e)
        End Sub

        Public Shared Event ReplaceButtonClick As DataGridButtonColumn.ButtonColumnClickHandler

        Public Shared Sub ReplaceCheckClicked(ByVal e As ButtonColumnEventArgs)
            RaiseEvent ReplaceButtonClick(e)
        End Sub
#End Region

#Region "Methods"
        Private Sub ResetID(ByVal oldid As Integer, ByVal oldje As Integer)
            Me.Id = oldid
            Me.m_je.Id = oldje
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me

                If Me.MaxRowIndex < 0 Then
                    Return New SaveErrorException("${res:Global.Error.NoItem}")
                ElseIf Me.MaxRowIndexReplace < 0 Then
                    Return New SaveErrorException("${res:Global.Error.CheckReplaceNoItem}")
                ElseIf Me.TotalCancel <> Me.TotalReplace Then
                    Return New SaveErrorException("${res:Global.Error.NotBalanceCheckChangeItem}")
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

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False

                If Me.m_je.Status.Value = 4 Then
                    Me.Status.Value = 4
                End If
                If Me.Status.Value = -1 Then
                    Me.Status.Value = 2
                End If

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_code", .Code))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_issuedate", IIf(Me.IssueDate.Equals(Date.MinValue), DBNull.Value, Me.IssueDate)))

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_acct", IIf(Me.Account.Originated, Me.Account.Id, DBNull.Value)))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_cust", IIf(Me.Customer.Originated, Me.Customer.Id, DBNull.Value)))

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_Checktype", Me.CheckType))
                'paramArrayList.Add(New SqlParameter("@" & .Prefix & "_Checkdstatus", Me.CheckStatus))

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_otherrevenue", Me.OtherRevenue))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_totalcancel", Me.TotalCancel))

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_cash", Me.Cash))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_otherexpense", Me.OtherExpense))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_totalreplace", Me.TotalReplace))

                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_note", Me.Note))
                paramArrayList.Add(New SqlParameter("@" & .Prefix & "_status", Me.Status.Value))

                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(.ConnectionString)

                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                trans = conn.BeginTransaction()

                Dim oldid As Integer = Me.Id
                Dim oldje As Integer = m_je.Id

                Try
                    .ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                    If IsNumeric(returnVal.Value) Then
                        Select Case CInt(returnVal.Value)
                            Case -1, -2, -5
                                trans.Rollback()
                                Me.ResetID(oldid, oldje)
                                Return New SaveErrorException(returnVal.Value.ToString)
                            Case Else
                        End Select
                    ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                        trans.Rollback()
                        Me.ResetID(oldid, oldje)
                        Return New SaveErrorException(returnVal.Value.ToString)
                    End If

                    Dim saveEx As SaveErrorException
                    ' Save replace ก่อน ...
                    saveEx = SaveReplaceDetail(currentUserId)
                    If Not IsNumeric(saveEx.Message) Then
                        trans.Rollback()
                        Me.ResetID(oldid, oldje)
                        Return saveEx
                    End If
                    ' Save CheckChange ...
                    Dim saveRtn As Integer = SaveDetail(Me.Id, conn, trans, currentUserId)
                    Select Case saveRtn
                        Case -1, -2, -5
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
                            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SQLErrorMissing}"))
                        Case Else
                            ' 
                    End Select
                    ' revert oldstatus 
                    ChangeOldItemStatus(conn, trans)

                    SaveDetail(Me.Id, conn, trans, currentUserId)

                    ' save newstatus
                    ChangeNewItemStatus(conn, trans)

                    ' Save GL

                    If Me.m_je.Status.Value = -1 Then
                        m_je.Status.Value = 3
                    End If
                    Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
                    If Not IsNumeric(saveJeError.Message) Then
                        trans.Rollback()
                        ResetID(oldid, oldje)
                        Return saveJeError
                    Else
                        Select Case CInt(saveJeError.Message)
                            Case -1, -5
                                trans.Rollback()
                                ResetID(oldid, oldje)
                                Return saveJeError
                            Case -2
                                'Post ไปแล้ว
                                Return saveJeError
                            Case Else
                        End Select
                    End If


                    trans.Commit()
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
                    Return New SaveErrorException(ex.ToString)
                Finally
                    conn.Close()
                End Try
            End With
        End Function

        Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
            If Not Me.Originated Then
                Return
            End If
            Dim changedStatus As New IncomingCheckDocStatus(6) ' เปลี่ยนเช็ครับ
            Dim sqlParams(2) As SqlParameter
            sqlParams(0) = New SqlParameter("@cqUpdate_updatedstatus", changedStatus.Value)
            sqlParams(1) = New SqlParameter("@RemoveIncludeIdList", Me.CheckRemovedInItemTable)
            sqlParams(2) = New SqlParameter("@check_bankacct", DBNull.Value)

            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldStatusIncomingCheck", sqlParams)

        End Sub

        Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
            If Not Me.Originated Then
                Return
            End If
            Dim changedStatus As New IncomingCheckDocStatus(6) ' เปลี่ยนเช็ครับ
            Dim sqlParams(2) As SqlParameter
            sqlParams(0) = New SqlParameter("@cqUpdate_updatedstatus", changedStatus.Value)
            sqlParams(1) = New SqlParameter("@IncludeIdList", Me.CheckInItemTable)
            sqlParams(2) = New SqlParameter("@check_bankacct", DBNull.Value)

            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewStatusIncomingCheck", sqlParams)

        End Sub

        Private Function SaveReplaceDetail(ByVal currentUserId As Integer) As SaveErrorException
            Dim saveEx As SaveErrorException
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)

            If conn.State = ConnectionState.Open Then conn.Close()

            Try
                conn.Open()
                trans = conn.BeginTransaction

                For Each row As TreeRow In Me.ItemReplaceTable.Childs
                    If ValidateRowReplace(row) Then
                        Dim incoming As IncomingCheck
                        If Not row.IsNull("Originated") AndAlso CBool(row("Originated")) Then
                            incoming = New IncomingCheck(CInt(row("check_id")))

                            incoming.Code = CStr(row("check_code"))
                            incoming.CqCode = CStr(row("check_cqcode"))
                            incoming.Customer = Me.Customer
                            incoming.ReceiveDate = CDate(row("check_receivedate"))
                            incoming.DueDate = CDate(row("check_duedate"))
                            incoming.ReceivePerson = New Employee(CInt(row("check_receiveperson")))
                            incoming.Bank = New Bank(CInt(row("check_bank")))
                            incoming.Amount = CDec(row("check_amt"))
                            If Not row.IsNull("check_note") Then
                                incoming.Note = CStr(row("check_note"))
                            End If
                        Else
                            incoming = New IncomingCheck
                            incoming.AutoGen = True

                            incoming.Code = ""    'CStr(row("check_code"))
                            incoming.CqCode = CStr(row("check_cqcode"))
                            incoming.Customer = Me.Customer
                            incoming.ReceiveDate = CDate(row("check_receivedate"))
                            incoming.DueDate = CDate(row("check_duedate"))
                            incoming.ReceivePerson = New Employee(CInt(row("check_receiveperson")))
                            incoming.Bank = New Bank(CInt(row("check_bank")))
                            incoming.Amount = CDec(row("check_amt"))
                            If Not row.IsNull("check_note") Then
                                incoming.Note = CStr(row("check_note"))
                            End If
                        End If
                        ' save incomingcheck
                        saveEx = incoming.Save(currentUserId)

                        row("check_id") = incoming.Id


                    End If
                Next
                trans.Commit()
            Catch ex As Exception
                trans.Rollback()
            Catch ex As SqlException
                trans.Rollback()
            Finally
                conn.Close()
            End Try

            Return saveEx
        End Function
        Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal currentUserId As Integer) As Integer
            Dim i As Integer = 0

            Dim da As New SqlDataAdapter("Select * from CheckChangeItem where cqChangei_cqChangeid = " & Me.Id, conn)
            Dim cmdBuilder As New SqlCommandBuilder(da)

            Dim ds As New DataSet

            da.SelectCommand.Transaction = trans

            'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans

            da.Fill(ds, "CheckChangeItem")

            Dim dbCount As Integer = ds.Tables("CheckChangeItem").Rows.Count
            Dim itemCount As Integer = Me.ItemTable.Childs.Count


            Dim theUser As New User(currentUserId)
            With ds.Tables("CheckChangeItem")
                For Each row As DataRow In .Rows
                    row.Delete()
                Next
                For n As Integer = 0 To Me.MaxRowIndex
                    Dim item As TreeRow = Me.m_itemTable.Childs(n)
                    If ValidateRow(item) Then
                        i += 1
                        Dim dr As DataRow = .NewRow
                        dr("cqChangei_cqChangeid") = Me.Id
                        dr("cqChangei_linenumber") = i 'item("pri_linenumber")
                        dr("cqChangei_entity") = item("check_id")
                        dr("cqChangei_IsCancel") = True
                        dr("cqChangei_beforestatus") = Me.CheckStatus
                        .Rows.Add(dr)

                    End If
                Next
                i = 0
                For n As Integer = 0 To Me.MaxRowIndexReplace
                    Dim itemreplace As TreeRow = Me.m_itemReplaceTable.Childs(n)
                    If ValidateRowReplace(itemreplace) Then
                        i += 1
                        Dim dr As DataRow = .NewRow
                        dr("cqChangei_cqChangeid") = Me.Id
                        dr("cqChangei_linenumber") = i 'item("pri_linenumber")
                        dr("cqChangei_entity") = itemreplace("check_id")
                        dr("cqChangei_IsCancel") = False
                        dr("cqChangei_beforestatus") = 1
                        .Rows.Add(dr)
                    End If
                Next

            End With
            Dim saveRtn As Integer
            Dim dt As DataTable = ds.Tables("CheckChangeItem")
            ' First process deletes.
            saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

            Return saveRtn

        End Function
#End Region

#Region "Items"
        Public Overloads Sub ReLoadItems()
            Me.IsInitialized = False
            m_itemTable = CheckChangeItem.GetSchemaTable()
            LoadItems()
            Me.IsInitialized = True
        End Sub
        Public Overloads Sub ReLoadReplaceItems()
            Me.IsInitialized = False
            m_itemReplaceTable = CheckReplaceItem.GetSchemaTable()
            LoadReplaceItems()
            Me.IsInitialized = True
        End Sub
        Public Overloads Sub ReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.IsInitialized = False
            m_itemTable = CheckChangeItem.GetSchemaTable()
            LoadItems(ds, aliasPrefix)
            Me.IsInitialized = True
        End Sub
        Public Overloads Sub ReloadReplaceItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.IsInitialized = False
            m_itemReplaceTable = CheckReplaceItem.GetSchemaTable()
            LoadReplaceItems(ds, aliasPrefix)
            Me.IsInitialized = True
        End Sub
        Private Sub LoadItems()
            If Not Me.Originated Then
                Return
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
            , CommandType.StoredProcedure _
            , "GetCheckChangeItem" _
            , New SqlParameter("@cqChangei_cqChangeid", Me.Id), New SqlParameter("@cqChangei_IsCancel", True) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New CheckChangeItem(row, "")
                item.CheckChange = Me
                ' Hack : Huaneng ...
                Me.Add(item)
            Next

        End Sub
        Private Sub LoadReplaceItems()
            If Not Me.Originated Then
                Return
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
            , CommandType.StoredProcedure _
            , "GetCheckChangeItem" _
            , New SqlParameter("@cqChangei_cqChangeid", Me.Id), New SqlParameter("@cqChangei_IsCancel", False) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New CheckReplaceItem(row, "")
                item.CheckChange = Me
                ' Hack : Huaneng ...
                Me.Add(item)
            Next

        End Sub
        Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            For Each dr As DataRow In ds.Tables(1).Rows
                Dim item As New CheckChangeItem(dr, aliasPrefix)
                item.CheckChange = Me
                Me.Add(item)
            Next
        End Sub
        Private Sub LoadReplaceItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            For Each dr As DataRow In ds.Tables(1).Rows
                Dim item As New CheckReplaceItem(dr, aliasPrefix)
                item.CheckChange = Me
                Me.Add(item)
            Next
        End Sub
        Public Sub AddBlankRow(ByVal count As Integer)
            For i As Integer = 0 To count - 1
                Dim newItem As New BlankItem("")
                Dim mtwItem As New CheckChangeItem
                Me.ItemTable.AcceptChanges()
                Me.Add(mtwItem)
            Next
        End Sub
        Public Sub AddReplaceBlankRow(ByVal count As Integer)
            For i As Integer = 0 To count - 1
                Dim newItem As New BlankItem("")
                Dim mtwItem As New CheckReplaceItem
                Me.ItemReplaceTable.AcceptChanges()
                Me.Add(mtwItem)
            Next
        End Sub
        Public Function Add(ByVal item As CheckChangeItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.Add
            item.LineNumber = Me.ItemTable.Childs.Count
            item.CheckChange = Me
            item.CopyToDataRow(myRow)
            Return myRow
        End Function
        Public Function Add(ByVal item As CheckReplaceItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemReplaceTable.Childs.Add
            item.LineNumber = Me.ItemReplaceTable.Childs.Count
            item.CheckChange = Me
            item.CopyToDataRow(myRow)
            Return myRow
        End Function
        Public Function Insert(ByVal index As Integer, ByVal item As CheckChangeItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
            item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
            item.CheckChange = Me
            item.CopyToDataRow(myRow)
            ReIndex(index + 1)
            Return myRow
        End Function
        Public Function Insert(ByVal index As Integer, ByVal item As CheckReplaceItem) As TreeRow
            Dim myRow As TreeRow = Me.ItemReplaceTable.Childs.InsertAt(index)
            item.LineNumber = Me.ItemReplaceTable.Childs.IndexOf(myRow) + 1
            item.CheckChange = Me
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
        Public Function MaxRowIndexReplace() As Integer
            'ให้ index ของแถวสุดท้ายที่มีข้อมูล
            For i As Integer = Me.m_itemReplaceTable.Childs.Count - 1 To 0 Step -1
                Dim row As TreeRow = Me.m_itemReplaceTable.Childs(i)
                If ValidateRowReplace(row) Then
                    Return i
                End If
            Next
            Return -1 'ไม่มีข้อมูลเลย
        End Function
        Public Sub Remove(ByVal index As Integer)
            Dim tr As TreeRow = Me.ItemTable.Childs(index)
            ' เก็บค่า Check ที่เคยอยู่ใน list แล้ว remove ออก
            If tr.Table.Columns.Contains("check_id") AndAlso Not tr.IsNull("check_id") Then
                m_incomingcheckremoved += "|" & CStr(tr("check_id")) & "|"
            End If
            Me.ItemTable.Childs.Remove(tr)
            ReIndex()
        End Sub
        Public Sub RemoveReplace(ByVal index As Integer)
            Me.ItemReplaceTable.Childs.Remove(Me.ItemReplaceTable.Childs(index))
            ReIndex()
        End Sub
        Private Sub ReIndex()
            ReIndex(0)
        End Sub
        Private Sub ReIndexReplace()
            ReIndexReplace(0)
        End Sub
        Private Sub ReIndex(ByVal index As Integer)
            If index < 0 OrElse index > Me.ItemTable.Childs.Count - 1 Then
                Return
            End If
            For i As Integer = index To Me.ItemTable.Childs.Count - 1
                Me.ItemTable.Childs(i)("linenumber") = i + 1
            Next
            ' replace
            If index < 0 OrElse index > Me.ItemReplaceTable.Childs.Count - 1 Then
                Return
            End If
            For i As Integer = index To Me.ItemReplaceTable.Childs.Count - 1
                Me.ItemReplaceTable.Childs(i)("linenumber") = i + 1
            Next
        End Sub
        Private Sub ReIndexReplace(ByVal index As Integer)
            If index < 0 OrElse index > Me.ItemReplaceTable.Childs.Count - 1 Then
                Return
            End If
            For i As Integer = index To Me.ItemReplaceTable.Childs.Count - 1
                Me.ItemReplaceTable.Childs(i)("linenumber") = i + 1
            Next
        End Sub
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If

            If Not e.Row.RowState = DataRowState.Detached Then
                e.Row.SetColumnError("check_code", "")
            Else
                e.Row.SetColumnError("check_code", Me.StringParserService.Parse("${res:Global.Error.GridHasNewLine}"))
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
        Private Sub TreeReplacetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                If index = Me.m_itemTable.Childs.Count - 1 Then
                    Me.AddBlankRow(1)
                End If
                Dim pe As New PropertyChangedEventArgs
                pe.Name = "ItemChanged"
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
                    Case "check_code"
                        SetEntityValue(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub

        Private Sub TreeReplacetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.IsInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "check_code"
                        SetEntityReplaceCheck(e)
                    Case "check_cqcode"
                        SetCqCoeCheck(e)
                    Case "check_receivedate", "check_duedate"
                        SetDateColumns(e)
                    Case "receivepersonname"
                        SetRecievePersonValue(e)
                    Case "bankname"
                        SetBankValue(e)
                    Case "check_amt"
                        SetAmount(e)
                End Select
                ValidateRowReplace(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            m_itemReplaceTable.AcceptChanges()

        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim proposedCode As Object = e.Row("check_code")
            Select Case e.Column.ColumnName.ToLower
                Case "check_code"
                    proposedCode = e.ProposedValue
                Case Else
                    Return
            End Select

            If IsDBNull(proposedCode) Then
                e.Row.SetColumnError("check_code", Me.StringParserService.Parse("${res:Global.Error.CodeMissing}"))
            Else
                e.Row.SetColumnError("check_code", "")
            End If
        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Dim proposedcqCode As Object = row("check_cqcode")

            If (IsDBNull(proposedcqCode) OrElse CStr(proposedcqCode) = "") Then
                Return False
            End If
            Return True
        End Function
        ' Replace Zone 
        Public Sub ValidateRowReplace(ByVal e As DataColumnChangeEventArgs)
            Dim proposedCode As Object = e.Row("check_code")
            Dim proposedCqCode As Object = e.Row("check_cqcode")
            Dim proposedReceiveDate As Object = e.Row("check_receivedate")
            Dim proposedReceivePerson As Object = e.Row("receivepersonName")
            Dim proposedBank As Object = e.Row("bankName")
            Dim proposedAmt As Object = e.Row("check_amt")

            Select Case e.Column.ColumnName.ToLower
                Case "check_code"
                    proposedCode = e.ProposedValue
                Case "check_cqcode"
                    proposedCqCode = e.ProposedValue
                Case "check_receivedate"
                    proposedReceiveDate = e.ProposedValue
                Case "receivepersonName"
                    proposedReceivePerson = e.ProposedValue
                Case "bankName"
                    proposedBank = e.ProposedValue
                Case "check_amt"
                    proposedAmt = e.ProposedValue
                Case Else
                    Return
            End Select

            ' Code 

            If IsDBNull(proposedCode) Then
                e.Row.SetColumnError("check_code", Me.StringParserService.Parse("${res:Global.Error.CodeMissing}"))
            Else
                e.Row.SetColumnError("check_code", "")
            End If
            ' cqcode
            If IsDBNull(proposedCqCode) Then
                e.Row.SetColumnError("check_cqcode", Me.StringParserService.Parse("${res:Global.Error.CqCodeMissing}"))
            Else
                e.Row.SetColumnError("check_cqcode", "")
            End If
            ' Receivedate
            If IsDBNull(proposedReceiveDate) Then
                e.Row.SetColumnError("check_receivedate", Me.StringParserService.Parse("${res:Global.Error.ReceiveDateMissing}"))
            Else
                e.Row.SetColumnError("check_receivedate", "")
            End If
            ' receiveperson
            If IsDBNull(proposedReceivePerson) Then
                e.Row.SetColumnError("receivepersonName", Me.StringParserService.Parse("${res:Global.Error.ReceivePersonMissing}"))
            Else
                e.Row.SetColumnError("receivepersonName", "")
            End If
            ' Bank
            If IsDBNull(proposedBank) Then
                e.Row.SetColumnError("bankName", Me.StringParserService.Parse("${res:Global.Error.BankMissing}"))
            Else
                e.Row.SetColumnError("bankName", "")
            End If
            ' Bank
            If IsDBNull(proposedAmt) Then
                e.Row.SetColumnError("check_amt", Me.StringParserService.Parse("${res:Global.Error.AmountMissing}"))
            Else
                e.Row.SetColumnError("check_amt", "")
            End If
        End Sub
        Public Function ValidateRowReplace(ByVal row As TreeRow) As Boolean
            ' Dim proposedCode As Object = row("check_code")
            Dim proposedCqCode As Object = row("check_cqcode")

            If (IsDBNull(proposedCqCode) OrElse CStr(proposedCqCode) = "") Then
                Return False
            End If
            Return True
        End Function

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
            If entity.Originated AndAlso entity.Status.Value = 1 Then
                e.Row("check_id") = entity.Id
                e.ProposedValue = entity.Code
                e.Row("check_cqcode") = entity.CqCode
                e.Row("check_receivedate") = entity.ReceiveDate
                e.Row("check_duedate") = entity.DueDate

                If entity.ReceivePerson.Originated Then
                    e.Row("check_receiveperson") = entity.ReceivePerson.Id
                    e.Row("receivepersonCode") = entity.ReceivePerson.Code
                    e.Row("receivepersonName") = entity.ReceivePerson.Name
                End If

                If entity.Customer.Originated Then
                    e.Row("check_customer") = entity.Customer.Id
                End If

                If entity.Bank.Originated Then
                    e.Row("check_bank") = entity.Bank.Id
                    e.Row("bankCode") = entity.Bank.Code
                    e.Row("bankName") = entity.Bank.Name
                End If

                e.Row("check_amt") = entity.Amount
                e.Row("check_note") = entity.Note
                e.Row("check_status") = Me.CheckStatus
            Else
                If entity.Originated Then
                    MessageBox.Show("สถานะเช็คในมือเท่านั้น")
                End If
                e.Row("check_id") = DBNull.Value
                e.ProposedValue = DBNull.Value
                e.Row("check_cqcode") = DBNull.Value
                e.Row("check_receivedate") = DBNull.Value
                e.Row("check_duedate") = DBNull.Value
                e.Row("check_receiveperson") = DBNull.Value
                e.Row("receivepersonCode") = DBNull.Value
                e.Row("receivepersonName") = DBNull.Value
                e.Row("check_customer") = DBNull.Value
                e.Row("check_bank") = DBNull.Value
                e.Row("bankCode") = DBNull.Value
                e.Row("bankName") = DBNull.Value
                e.Row("check_amt") = DBNull.Value
                e.Row("check_note") = DBNull.Value
                e.Row("check_status") = DBNull.Value
            End If
            m_entitySetting = False
        End Sub
        ' Replace zone 
        Public Sub SetEntityReplaceValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If EntityBase Is Nothing Then
                Return
            End If
            SetEntityReplaceCheck(e)
        End Sub

        Private Sub SetEntityReplaceCheck(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If
            Dim code As String = e.ProposedValue.ToString
            If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = code

        End Sub

        Private Sub SetCqCoeCheck(ByVal e As System.Data.DataColumnChangeEventArgs)
            Dim obj As New IncomingCheck
            m_entitySetting = True
            Dim cqcode As String = e.ProposedValue.ToString

            Dim autocode As String = BusinessLogic.Entity.GetAutoCodeFormat(obj.EntityId)

            If e.Row.IsNull("Originated") OrElse Not CBool(e.Row("Originated")) Then
                e.Row("check_code") = autocode
                e.Row("Originated") = False
            End If
            e.ProposedValue = cqcode
            m_entitySetting = False
        End Sub
        Public Sub SetRecievePersonValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If

            If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
                e.ProposedValue = ""
                Return
            End If

            Dim myEmp As New Employee(e.ProposedValue.ToString)
            Dim err As String = ""
            If Not myEmp.Originated Then
                err = "${res:Global.Error.InvalidEmployee}"
            End If

            If err.Length = 0 Then
                e.Row("check_receiveperson") = myEmp.Id
                e.Row("receivepersonCode") = myEmp.Code
                e.ProposedValue = myEmp.Name
            Else
                e.ProposedValue = e.Row(e.Column)
                MessageBox.Show(Me.StringParserService.Parse(err))
            End If

        End Sub

        Public Sub SetBankValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If

            If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
                e.ProposedValue = ""
                Return
            End If

            Dim myBank As New Bank(e.ProposedValue.ToString)
            Dim err As String = ""
            If Not myBank.Originated Then
                err = "${res:Global.Error.InvalidBank}"
            End If

            If err.Length = 0 Then
                e.Row("check_bank") = myBank.Id
                e.Row("bankCode") = myBank.Code
                e.ProposedValue = myBank.Name
            Else
                e.ProposedValue = e.Row(e.Column)
                MessageBox.Show(Me.StringParserService.Parse(err))
            End If

        End Sub
        Public Sub SetDateColumns(ByVal e As DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If

            If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
        End Sub
        Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
            If m_entitySetting Then
                Return
            End If

            If IsDBNull(e.ProposedValue) _
            OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = 0
                Return
            End If

            e.ProposedValue = Configuration.Format(CDec(e.ProposedValue), DigitConfig.Price)
        End Sub
#End Region

#Region " IGLAble "
        Public Property [Date]() As Date Implements IGLAble.Date
            Get
                Return Me.IssueDate
            End Get
            Set(ByVal Value As Date)
                Me.IssueDate = Value
            End Set
        End Property

        Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                                                        , CommandType.StoredProcedure _
                                                        , "GetGLFormatForEntity" _
                                                        , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))

            Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
            Return glf
        End Function

        Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
            Dim jiColl As New JournalEntryItemCollection
            Dim ji As New JournalEntryItem
            'DR ----------------------
            ' DR. เช็ครับรอนำฝาก      ji.Mapping = "H7.1"
            SetGLH7_1(jiColl)
            ' Dr. เงินสด                  ji.Mapping = "H7.2"
            SetGLH7_2(jiColl)
            ' Dr. ค่าใช้จ่ายอื่น ๆ        ji.Mapping = "H7.3"
            SetGLH7_3(jiColl)
            'CR ----------------------
            ' Cr. เช็ครับรอนำฝาก     ji.Mapping = "H7.4"
            SetGLH7_4(jiColl)
            ' Cr. รายได้อื่น ๆ           ji.Mapping = "H7.5"
            SetGLH7_5(jiColl)

            Return jiColl
        End Function
        ' Dr. เช็ครับรอนำฝาก
        Private Sub SetGLH7_1(ByVal jiColl As JournalEntryItemCollection)
            If Me.TotalReplace > 0 Then
                Dim ji As JournalEntryItem
                ji = New JournalEntryItem
                ji.Mapping = "H7.1"
                ji.Amount = (Me.TotalReplace - Me.Cash - Me.OtherExpense)
                'If Me.Customer.Account.Originated Then
                '    ji.Account = Me.Customer.Account
                'End If
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' Dr. เงินสด
        Private Sub SetGLH7_2(ByVal jiColl As JournalEntryItemCollection)
            If Me.Cash > 0 Then
                Dim ji As JournalEntryItem
                ji = New JournalEntryItem
                ji.Mapping = "H7.2"
                ji.Amount = Me.Cash
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' Dr. ค่าใช้จ่ายอื่น ๆ 
        Private Sub SetGLH7_3(ByVal jiColl As JournalEntryItemCollection)
            If Me.OtherExpense > 0 Then
                Dim ji As JournalEntryItem
                ji = New JournalEntryItem
                ji.Mapping = "H7.3"
                ji.Amount = Me.OtherExpense
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        ' Cr. ลูกหนี้การค้า
        Private Sub SetGLH7_4(ByVal jiColl As JournalEntryItemCollection)
            If Me.TotalCancel - Me.OtherRevenue > 0 Then
                Dim ji As JournalEntryItem
                ji = New JournalEntryItem
                ji.Mapping = "H7.4"
                ji.Amount = Me.TotalCancel - Me.OtherRevenue
                If Me.Customer.Account.Originated Then
                    ji.Account = Me.Customer.Account
                End If
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        Private Sub SetGLH7_5(ByVal jiColl As JournalEntryItemCollection)
            If Me.OtherRevenue > 0 Then
                Dim ji As JournalEntryItem
                ji = New JournalEntryItem
                ji.Mapping = "H7.5"
                ji.Amount = Me.OtherRevenue
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If
        End Sub
        Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
            Get
                Return Me.m_je
            End Get
            Set(ByVal Value As JournalEntry)
                Me.m_je = Value
            End Set
        End Property
#End Region

#Region "Delete"
        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                If Me.Originated Then
                    Return Me.Status.Value <= 2
                Else
                    Return False
                End If
            End Get
        End Property
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("${res:Global.Error.NoIdError}")
            End If
            ' ตรวจสอบ Childs ที่อ้างอิงแล้ว.
            'Dim referedcodelist As String = GetIsChildsReferenced()
            'If referedcodelist.Length > 0 Then
            '    Dim strPare As String = Me.StringParserService.Parse("${res:Global.CheckChangeReferedList}")
            '    Return New SaveErrorException(String.Format(strPare, referedcodelist))
            'End If

            Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim format(0) As String
            format(0) = Me.Code
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteCheckChange}", format) Then
                Return New SaveErrorException("${res:Global.CencelDelete}")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try
                m_incomingcheckremoved = ""
                For Each tr As TreeRow In Me.ItemTable.Childs
                    If Me.ValidateRow(tr) Then
                        If tr.Table.Columns.Contains("check_id") AndAlso Not tr.IsNull("check_id") Then
                            m_incomingcheckremoved += "|" & CInt(tr("check_id")) & "|"
                        End If
                    End If
                Next

                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteCheckChange", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.CheckChangeIsReferencedCannotBeDeleted}")
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Return New SaveErrorException(returnVal.Value.ToString)
                End If

                ChangeOldItemStatus(conn, trans)

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
            m_incomingcheckremoved = ""
        End Function
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

    ' Update check items
    Public Class CheckChangeItem

#Region "Members"
        Private m_CheckChange As CheckChange
        Private m_entity As IncomingCheck
        Private m_lineNumber As Integer
        Private m_iscancel As Boolean = True

        Private m_docstatus As New IncomingCheckDocStatus(6)
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
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_linenumber") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_linenumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & Me.Prefix & "_linenumber"))
                End If
                ' Entity ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
                    .m_entity = New IncomingCheck(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
                End If
                ' before status ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docstatus") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docstatus") Then
                    .m_docstatus = New IncomingCheckDocStatus(CInt(dr(aliasPrefix & Me.Prefix & "_docstatus")))
                End If
            End With
        End Sub
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Private ReadOnly Property Prefix() As String
            Get
                Return "cqchangei"
            End Get
        End Property

        Public Property CheckChange() As CheckChange            Get                Return m_CheckChange            End Get            Set(ByVal Value As CheckChange)                m_CheckChange = Value            End Set        End Property
        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property IsCancel() As Boolean            Get
                Return m_iscancel
            End Get
            Set(ByVal Value As Boolean)
                m_iscancel = Value
            End Set
        End Property        Public Property Entity() As IncomingCheck            Get                Return m_entity            End Get            Set(ByVal Value As IncomingCheck)                m_entity = Value            End Set        End Property        Public Property ChangeStatus() As CodeDescription            Get
                Return m_docstatus
            End Get
            Set(ByVal Value As CodeDescription)
                m_docstatus = CType(Value, IncomingCheckDocStatus)
            End Set
        End Property
#End Region

#Region "Methods"
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Me.CheckChange.IsInitialized = False
            row("linenumber") = Me.LineNumber
            If Not Me.Entity Is Nothing Then
                'row("cqChangei_entity") = Me.Entity.Id
                'row("cqChangei_IsCancel") = Me.IsCancels
                'row("cqChangei_status") = Me.Status.Value 
                row("check_id") = Me.Entity.Id
                row("check_code") = Me.Entity.Code
                row("check_cqcode") = Me.Entity.CqCode

                row("check_receivedate") = Me.Entity.ReceiveDate
                row("check_duedate") = Me.Entity.DueDate

                If Not Me.Entity.ReceivePerson Is Nothing Then
                    row("check_receiveperson") = Me.Entity.ReceivePerson.Id
                    row("receivepersonCode") = Me.Entity.ReceivePerson.Code
                    row("receivepersonName") = Me.Entity.ReceivePerson.Name
                End If

                If Not Me.Entity.Customer Is Nothing Then
                    row("check_customer") = Me.Entity.Customer.Id
                End If

                If Not Me.Entity.Bank Is Nothing Then
                    row("check_bank") = Me.Entity.Bank.Id
                    row("bankCode") = Me.Entity.Bank.Code
                    row("bankName") = Me.Entity.Bank.Name
                    row("bank_id") = Me.Entity.Bank.Id
                    row("bank_code") = Me.Entity.Bank.Code
                    row("bank_name") = Me.Entity.Bank.Name
                End If

                row("check_amt") = Me.Entity.Amount
                row("check_note") = Me.Entity.Note
                row("check_status") = Me.ChangeStatus.Value
            Else
                'row("cqChangei_entity") = DBNull.Value
                'row("cqChangei_IsCancel") = DBNull.Value
                'row("cqChangei_status") = DBNull.Value
                row("check_id") = DBNull.Value
                row("check_code") = DBNull.Value
                row("check_cqcode") = DBNull.Value
                row("check_receivedate") = DBNull.Value
                row("check_duedate") = DBNull.Value
                row("check_receiveperson") = DBNull.Value
                row("receivepersonCode") = DBNull.Value
                row("receivepersonName") = DBNull.Value
                row("check_customer") = DBNull.Value
                row("check_bank") = DBNull.Value
                row("check_amt") = DBNull.Value
                row("check_note") = DBNull.Value
                row("check_status") = DBNull.Value
                ' bank
                row("bankCode") = DBNull.Value
                row("bankName") = DBNull.Value
                row("bank_code") = DBNull.Value
                row("bank_name") = DBNull.Value
            End If

            Me.CheckChange.IsInitialized = True
        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Try
                ' Line number ...
                If Not row.IsNull(("linenumber")) Then
                    Me.LineNumber = CInt(row("linenumber"))
                End If
                ' Entity ...
                If row.Table.Columns.Contains("check_id") _
                    AndAlso Not row.IsNull(("check_id")) Then
                    Me.Entity = New IncomingCheck(CInt(row("check_id")))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

#Region " Shared Methods "
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("CheckUpdate")
            myDatatable.Columns.Add(New DataColumn("linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("btnCheck", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("btnReceiveperson", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("receivepersonCode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("receivepersonName", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("btnBank", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bankCode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bankName", GetType(String)))

            ' bank 
            myDatatable.Columns.Add(New DataColumn("bank_id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("bank_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bank_name", GetType(String)))

            ' Check
            myDatatable.Columns.Add(New DataColumn("check_id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_cqcode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_receivedate", GetType(Date)))
            myDatatable.Columns.Add(New DataColumn("check_duedate", GetType(Date)))
            myDatatable.Columns.Add(New DataColumn("check_receiveperson", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_customer", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_bank", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_amt", GetType(Decimal)))
            myDatatable.Columns.Add(New DataColumn("check_note", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_status", GetType(Integer)))

            Return myDatatable
        End Function
#End Region
    End Class

    ' Replace check item
    Public Class CheckReplaceItem

#Region "Members"
        Private m_CheckChange As CheckChange
        Private m_lineNumber As Integer
        Private m_entity As IncomingCheck
        Private m_iscancel As Boolean = False
        Private m_replacestatus As New IncomingCheckDocStatus(1)

        Private m_Originated As Boolean
        Private m_AutoGen As Boolean
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
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_linenumber") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_linenumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & Me.Prefix & "_linenumber"))
                End If
                ' Entity ...
                If dr.Table.Columns.Contains(aliasPrefix & "check_id") AndAlso Not dr.IsNull(aliasPrefix & "check_id") Then
                    .m_entity = New IncomingCheck(dr, aliasPrefix)
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
                        .m_entity = New IncomingCheck(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
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
        Private ReadOnly Property Prefix() As String
            Get
                Return "cqChangei"
            End Get
        End Property
        Public ReadOnly Property ReplaceStatus() As Integer            Get
                Return 1
            End Get
        End Property

        Public ReadOnly Property IsCancel() As Boolean
            Get
                Return m_iscancel
            End Get
        End Property

        Public Property CheckChange() As CheckChange            Get                Return m_CheckChange            End Get            Set(ByVal Value As CheckChange)                m_CheckChange = Value            End Set        End Property        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property Entity() As IncomingCheck            Get                Return m_entity            End Get            Set(ByVal Value As IncomingCheck)                m_entity = Value            End Set        End Property        Public ReadOnly Property Originated() As Boolean            Get                Return m_entity.Originated            End Get        End Property        Public ReadOnly Property AutoGen() As Boolean            Get                Return m_entity.Originated            End Get        End Property
#End Region

#Region " Methods "
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Me.CheckChange.IsInitialized = False
            row("linenumber") = Me.LineNumber
            If Not Me.Entity Is Nothing Then
                row("check_id") = Entity.Id
                row("check_code") = Entity.Code
                row("check_cqcode") = Entity.CqCode

                row("check_receivedate") = Entity.ReceiveDate
                row("check_duedate") = Entity.DueDate

                If Not Entity.ReceivePerson Is Nothing Then
                    row("check_receiveperson") = Entity.ReceivePerson.Id
                    row("receivepersonCode") = Entity.ReceivePerson.Code
                    row("receivepersonName") = Entity.ReceivePerson.Name
                End If

                If Not Entity.Customer Is Nothing Then
                    row("check_customer") = Entity.Customer.Id
                End If

                If Not Entity.Bank Is Nothing Then
                    row("check_bank") = Entity.Bank.Id
                    row("bankCode") = Entity.Bank.Code
                    row("bankName") = Entity.Bank.Name
                    row("bank_id") = Me.Entity.Bank.Id
                    row("bank_code") = Me.Entity.Bank.Code
                    row("bank_name") = Me.Entity.Bank.Name
                End If

                row("check_amt") = Entity.Amount
                row("check_note") = Entity.Note
                row("check_status") = Me.ReplaceStatus

                row("Originated") = Me.Originated
                row("AutoGen") = Me.AutoGen
            Else
                row("check_id") = DBNull.Value
                row("check_code") = DBNull.Value
                row("check_cqcode") = DBNull.Value

                row("check_receivedate") = Date.MinValue
                row("check_duedate") = Date.MinValue

                row("check_receiveperson") = DBNull.Value
                row("receivepersonCode") = DBNull.Value
                row("receivepersonName") = DBNull.Value
                row("check_customer") = DBNull.Value
                row("check_bank") = DBNull.Value
                row("bankCode") = DBNull.Value
                row("bankName") = DBNull.Value
                row("check_amt") = DBNull.Value
                row("check_note") = DBNull.Value
                row("check_status") = DBNull.Value
                ' bank
                row("bank_id") = DBNull.Value
                row("bank_code") = DBNull.Value
                row("bank_name") = DBNull.Value
                ' other
                row("Originated") = DBNull.Value
                row("AutoGen") = DBNull.Value
            End If

            Me.CheckChange.IsInitialized = True
        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Try
                ' Line number ...
                If Not row.IsNull(("linenumber")) Then
                    Me.LineNumber = CInt(row("linenumber"))
                End If
                ' Entity ...
                If row.Table.Columns.Contains("check_id") _
                    AndAlso Not row.IsNull(("check_id")) Then
                    Me.Entity = New IncomingCheck(CInt(row("check_id")))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

#Region " Shared Methods "
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("CheckUpdate")
            myDatatable.Columns.Add(New DataColumn("linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("btnReceiveperson", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("receivepersonCode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("receivepersonName", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("btnBank", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bankCode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bankName", GetType(String)))
            'bank
            myDatatable.Columns.Add(New DataColumn("bank_id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("bank_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("bank_name", GetType(String)))
            ' check 
            myDatatable.Columns.Add(New DataColumn("check_id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_cqcode", GetType(String)))

            Dim dateCol As New DataColumn("check_receivedate", GetType(Date))
            dateCol.DefaultValue = Date.MinValue
            myDatatable.Columns.Add(dateCol)

            dateCol = New DataColumn("check_duedate", GetType(Date))
            dateCol.DefaultValue = Date.MinValue
            myDatatable.Columns.Add(dateCol)

            myDatatable.Columns.Add(New DataColumn("check_receiveperson", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_customer", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_bank", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("check_amt", GetType(Decimal)))
            myDatatable.Columns.Add(New DataColumn("check_note", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("check_status", GetType(Integer)))
            ' Other
            myDatatable.Columns.Add(New DataColumn("Originated", GetType(Boolean)))
            myDatatable.Columns.Add(New DataColumn("AutoGen", GetType(Boolean)))

            Return myDatatable
        End Function
#End Region

    End Class

    Public Class CheckChangeStatus
        Inherits CodeDescription

#Region " Construtors "
        Public Sub New(ByVal description As String)
            MyBase.New(description)
        End Sub
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region " Properties "
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "checkchange_status"
            End Get
        End Property
#End Region

    End Class
End Namespace