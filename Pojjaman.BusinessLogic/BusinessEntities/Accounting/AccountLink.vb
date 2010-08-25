Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AccountLink
    Inherits SimpleBusinessEntityBase

#Region "Members"
    Private m_itemTable As TreeTable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      Wire()
    End Sub
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
#End Region

#Region "Properties"
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AccountLink"
      End Get
    End Property

#End Region

#Region "Shared"
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "AccountLink"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "ga_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountLinkDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "ga_linenumber"

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountLinkDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csAcctCode As New TreeTextColumn
      csAcctCode.MappingName = "AcctCode"
      csAcctCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountLinkDetail.AcctCodeHeaderText}")
      csAcctCode.NullText = ""
      csAcctCode.TextBox.Name = "AcctCode"
      csAcctCode.Width = 60
      csAcctCode.DataAlignment = HorizontalAlignment.Right
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csAcctButton As New DataGridButtonColumn
      csAcctButton.MappingName = "AcctButton"
      csAcctButton.HeaderText = ""
      csAcctButton.NullText = ""
      AddHandler csAcctButton.Click, AddressOf AcctButtonClicked

      Dim csAcctName As New TreeTextColumn
      csAcctName.MappingName = "AcctName"
      csAcctName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountLinkDetail.AcctNameHeaderText}")
      csAcctName.NullText = ""
      csAcctName.TextBox.Name = "AcctName"
      csAcctName.ReadOnly = True
      csAcctName.Width = 180

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csAcctCode)
      dst.GridColumnStyles.Add(csAcctButton)
      dst.GridColumnStyles.Add(csAcctName)

      Return dst
    End Function
    Public Shared Sub AcctButtonClicked(ByVal e As ButtonColumnEventArgs)
      RaiseEvent AcctButtonClick(e)
    End Sub
    Public Shared Event AcctButtonClick As DataGridButtonColumn.ButtonColumnClickHandler

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("AccountLink")
      myDatatable.Columns.Add(New DataColumn("ga_id", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ga_linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Type", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ga_acctType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("ga_acct", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("AcctCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AcctButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AcctName", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Items"
    Public Overloads Sub ReLoadItems()
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      LoadItems()
      Me.IsInitialized = True
    End Sub
    Private Sub LoadItems()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGeneralAccounts")

      m_itemTable.Clear()
      Dim dt As DataTable = CodeDescription.GetCodeList("acct_type")
      For Each row As DataRow In dt.Rows
        Dim parentRow As TreeRow = m_itemTable.Childs.Add
        parentRow("Name") = row("code_value").ToString & "." & row("code_description").ToString
        parentRow("AcctButton") = "invisible"
        Dim i As Integer = 0
        For Each dbRow As DataRow In ds.Tables(0).Select("ga_accttype=" & row("code_value").ToString)
          Dim childRow As TreeRow = parentRow.Childs.Add()
          Dim item As New GeneralAccount(dbRow, "")
          item.AccountLink = Me
          item.LineNumber = i + 1
          item.CopyToDataRow(childRow)
          i += 1
        Next
      Next
    End Sub
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
        Me.OnPropertyChanged(Me, pe)
        Me.ItemTable.AcceptChanges()
      End If
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      If CType(e.Row, TreeRow).Level = 0 Then
        e.ProposedValue = DBNull.Value
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "acctcode"
            SetAccountValue(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim proposedAccount As Object = e.Row("AcctCode")
      Select Case e.Column.ColumnName.ToLower
        Case "acctcode"
          proposedAccount = e.ProposedValue
        Case Else
          Return
      End Select

      If IsDBNull(proposedAccount) Then
        e.Row.SetColumnError("AcctCode", Me.StringParserService.Parse("${res:Global.Error.AccountMissing}"))
      Else
        e.Row.SetColumnError("AcctCode", "")
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Return True
    End Function
    Public Sub SetAccountValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      Dim entity As New Account(e.ProposedValue.ToString)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If entity.Type.Value <> CInt(e.Row("ga_acctType")) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.NotTheNeededAccountType}", New String() {entity.Name, New AccountType(CInt(e.Row("ga_acctType"))).Description})
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      If entity.Originated Then
        e.Row("ga_acct") = entity.Id
        e.ProposedValue = entity.Code
        e.Row("AcctName") = entity.Name
      Else
        e.Row("ga_acct") = DBNull.Value
        e.ProposedValue = DBNull.Value
        e.Row("AcctName") = DBNull.Value
      End If
    End Sub
    Private Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
      Try
        If Not Me.IsInitialized Then
          Return
        End If
        Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
        Me.OnPropertyChanged(Me, pe)
        e.Row.SetColumnError("Name", "")
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

#Region "Saving"
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Dim da As New SqlDataAdapter("Select * from generalaccount", conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)
      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "generalaccount")

      Try
        Dim childRows As New ArrayList
        For Each row As TreeRow In Me.ItemTable.Rows
          If row.Level > 0 Then
            childRows.Add(row)
          End If
        Next
        With ds.Tables("generalaccount")
          For Each childRow As DataRow In childRows
            If Not childRow.IsNull("ga_id") Then
              Dim rows As DataRow() = .Select("ga_id=" & childRow("ga_id").ToString)
              If rows.Length = 1 Then
                rows(0)("ga_acct") = childRow("ga_acct")
              End If
            End If
          Next
        End With
        Dim dt As DataTable = ds.Tables("generalaccount")
        ' First process deletes.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        trans.Commit()
        GeneralAccount.RefreshGATable()
        Return New SaveErrorException("0")
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

    End Function
#End Region

  End Class

  Public Class GeneralAccount
    Implements IHasName

#Region "Members"
    Private m_accountLink As AccountLink
    Private m_id As Integer
    Private m_lineNumber As Integer
    Private m_name As String
    Private m_accountType As AccountType
    Private m_account As Account

    Private Shared m_gaHash As Hashtable
#End Region

#Region "Constructors"
    Shared Sub New()
      RefreshGATable()
    End Sub
    Public Shared Sub RefreshGATable()
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetGeneralAccount" _
      )
      m_gaHash = New Hashtable
      Dim myTable As DataTable = ds.Tables(0)
      For Each row As DataRow In myTable.Rows
        m_gaHash(row("ga_id").ToString) = row
      Next
    End Sub
    Public Sub New()
      Me.m_account = New Account
      m_accountType = New AccountType(1)
    End Sub
    Public Sub New(ByVal id As Integer)
      Dim dr As Object = m_gaHash(id.ToString)
      If TypeOf dr Is DataRow Then
        Construct(CType(dr, DataRow), "")
      End If
    End Sub
    'Public Sub New(ByVal name As String)
    '    Dim drs As DataRow() = m_sharedGATable.Select("ga_name='" & name & "'")
    '    If drs.Length = 1 Then
    '        Construct(drs(0), "")
    '    End If
    'End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "ga_id") AndAlso Not dr.IsNull(aliasPrefix & "ga_id") Then
          .m_id = CInt(dr(aliasPrefix & "ga_id"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "ga_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "ga_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "ga_lineNumber"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") AndAlso Not dr.IsNull(aliasPrefix & "acct_id") Then
          If Not dr.IsNull("acct_id") Then
            .m_account = New Account(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "ga_acct") AndAlso Not dr.IsNull(aliasPrefix & "ga_acct") Then
            .m_account = New Account(CInt(dr(aliasPrefix & "ga_acct")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "ga_acctType") AndAlso Not dr.IsNull(aliasPrefix & "ga_acctType") Then
          .m_accountType = New AccountType(CInt(dr(aliasPrefix & "ga_acctType")))
          .m_accountType.Description = .m_accountType.Value.ToString & "." & .m_accountType.Description
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "ga_name") AndAlso Not dr.IsNull(aliasPrefix & "ga_name") Then
          .m_name = CStr(dr(aliasPrefix & "ga_name"))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property AccountLink() As AccountLink      Get        Return m_accountLink      End Get      Set(ByVal Value As AccountLink)        m_accountLink = Value      End Set    End Property
    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Name() As String Implements IHasName.Name      Get        Return m_name      End Get      Set(ByVal Value As String)        m_name = Value      End Set    End Property    Public Property AccountType() As AccountType      Get        Return m_accountType      End Get      Set(ByVal Value As AccountType)        m_accountType = Value      End Set    End Property    Public Property Account() As Account      Get        Return m_account      End Get      Set(ByVal Value As Account)        m_account = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.AccountLink.IsInitialized = False
      row("ga_id") = Me.Id
      row("ga_linenumber") = Me.LineNumber
      row("Name") = Me.Name
      If Not Me.Account Is Nothing Then
        row("AcctCode") = Me.Account.Code
        row("AcctName") = Me.Account.Name
        row("ga_acct") = Me.Account.Id
      End If
      If Not Me.AccountType Is Nothing Then
        row("ga_acctType") = Me.AccountType.Value
        row("Type") = Me.AccountType.Description
      End If

      Me.AccountLink.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("ga_linenumber")) Then
          Me.LineNumber = CInt(row("ga_linenumber"))
        End If
        If Not row.IsNull(("ga_id")) Then
          Me.Id = CInt(row("ga_id"))
        End If
        If Not row.IsNull(("ga_acct")) Then
          Me.Account = New Account(CInt(row("ga_acct")))
        End If
        If Not row.IsNull(("ga_acctTye")) Then
          Me.AccountType = New AccountType(CInt(row("ga_acctTye")))
        End If
        If Not row.IsNull(("ga_name")) Then
          Me.Name = CStr(row("ga_name"))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub
#End Region

#Region "IIdentifiable"
    Public Property Code() As String Implements IIdentifiable.Code
      Get
        Return ""
      End Get
      Set(ByVal Value As String)

      End Set
    End Property
    Public Property Id() As Integer Implements IIdentifiable.Id
      Get
        Return m_id
      End Get
      Set(ByVal Value As Integer)

      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetDefaultGA(ByVal type As DefaultGAType) As GeneralAccount
      Dim id As Integer = CInt(type)
      Return New GeneralAccount(id)
    End Function
    Public Enum DefaultGAType
      Cash = 1 'เงินสด
      Customer = 2 'ลูกหนี้การค้า
      CheckUnCollected = 3 'เช็ครอเรียกเก็บ
      CheckUnPayin = 4 'เช็ครับรอนำฝาก

      WitholdingTaxOut = 5 ' ภาษีเงินได้ถูกหัก ณ ที่จ่าย
      WitholdingTaxOutWaitng = 57 ' ภาษีเงินได้ถูกหัก ณ ที่จ่าย ยังไม่ถึงกำหนด
      VatIn = 6 'ภาษีซื้อ

      MatInStore = 7 'สินค้า/วัสดุคงคลัง
      Wip = 8 'งานระหว่างทำ
      AdvancePayment = 9 'เงินมัดจำจ่ายล่วงหน้า
      PettyCash = 10
      DepreAccu = 11
      AdvanceReceive = 12
      Supplier = 13
      CheckAdvence = 14 'เช็คจ่ายล่วงหน้า

      VatOut = 15 'ภาษีขาย
      VatOutWaiting = 16 'ภาษีขาย
      VatInWaiting = 54 'ภาษีซื้อ-ยังไม่ถึงกำหนด

      WitholdingTaxInOther = 17 'ภาษีหัก ณ ที่จ่าย ภงด.อื่นๆ
      WitholdingTaxIn3 = 58 'ภาษีหัก ณ ที่จ่าย ภงด.อื่นๆ
      WitholdingTaxIn53 = 59 'ภาษีหัก ณ ที่จ่าย ภงด.อื่นๆ
      WitholdingTaxInWaiting = 56 'ภาษีหัก ณ ที่จ่าย ภงด.อื่นๆ

      AccProfit = 18 'กำไรขาดทุนสะสม
      Income = 19 'รายได้เงินเชื่อ
      InterestIn = 20 'ดอกเบี้ยรับ
      SalesCN = 21 'ลดหนี้ลูกค้า
      OtherIncome = 22
      PayDiscount = 23
      ToolAndOtherReturn = 24
      SalaryWage = 25
      ToolAndOther = 26
      BankCharge = 27 'ค่าธรรมเนียมธนาคาร
      OtherExpense = 28 'ค่าใช้จ่ายอื่นๆ
      BuyMaterial = 29
      InterestOut = 30
      ReceiveDiscount = 31
      Depre = 32
      LostAndBrokenExpense = 33 'ค่าใช้จ่ายสินค้าเสียหาย/สูญหาย
      MaterialCost = 34
      EQMaintenanceExpense = 35
      PurchaseOtherExpense = 44 'ค่าใช้จ่ายอื่นๆ (ซื้อสินค้า)
      ToolAndOtherIncome = 45 'รายได้จากการขายเครื่องมือ/วัสดุสิ้นเปลือง
      ConPenalty = 47 'ค่าปรับงานก่อสร้าง
      ConIncome = 48 'รายได้จากงานก่อสร้าง
      Retention = 49 'เงินประกันผลงาน
      None = 0
      GeneralAsset = 50 'สินทรัพย์ทั่วไป
      AdvanceMoney = 51 'เงินทดรองจ่าย
      RetentionDeduct = 52 'เจ้าหนี้เงินประกันผลงาน
      DiffFromEvaluation = 53 'ส่วนเกิน(ส่วนต่ำ)จากการตีราคาสินค้าคงเหลือ
      DiffFromDecimalPlace = 55 'ส่วนเกิน(ส่วนต่ำ)จากการปัดทศนิยม
      ' TradeDiscount = 56 'ส่วนลดการค้า (หมวด 5)
      'TradeDiscount4 = 57 'ส่วนลดการค้า (หมวด 4)
      SCPenalty = 60 'ค่าปรับผู้รับเหมาจากหน้า หัก DR
      AssetProfitLoss = 61 'กำไร/ขาดทุน จากการจำหน่ายสินทรัพย์
    End Enum
#End Region

  End Class
End Namespace
