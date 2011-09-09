Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class CloseAccountPeriodStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "closeacctp_status"
      End Get
    End Property
#End Region

  End Class
  Public Class CloseAccountPeriod
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, ICheckPeriod


#Region "Members"
    Private m_docDate As Date
    Private m_olddocDate As Date
    Private m_note As String
    Private m_status As CloseAccountPeriodStatus

    Private m_je As JournalEntry

    Private m_itemTable As TreeTable

    Private m_profitAccount As Account

    Private m_endPeriod As AccountPeriod
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      ReLoadItems()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docDate = Date.Now.Date
        .m_olddocDate = Date.Now.Date
        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate
        .m_status = New CloseAccountPeriodStatus(-1)
        .m_profitAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.AccProfit).Account
        .m_endPeriod = New AccountPeriod
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If Not dr.IsNull(aliasPrefix & "closeacctp_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "closeacctp_docDate"))
          .m_olddocDate = CDate(dr(aliasPrefix & "closeacctp_docDate"))
        End If

        If Not dr.IsNull(aliasPrefix & "closeacctp_note") Then
          .m_note = CStr(dr(aliasPrefix & "closeacctp_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .m_status = New CloseAccountPeriodStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_profitacct") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_profitacct") Then
          .m_profitAccount = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_profitacct")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_endPeriod") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_endPeriod") Then
          .m_endPeriod = New AccountPeriod(CInt(dr(aliasPrefix & Me.Prefix & "_endPeriod")))
        End If
        m_je = New JournalEntry(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property EndPeriod() As AccountPeriod      Get        Return m_endPeriod      End Get      Set(ByVal Value As AccountPeriod)        m_endPeriod = Value      End Set    End Property
    Public Property ProfitAccount() As Account      Get        Return m_profitAccount      End Get      Set(ByVal Value As Account)        m_profitAccount = Value      End Set    End Property
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public ReadOnly Property AccProfit() As Decimal      Get        Dim firstPeriod As AccountPeriod = Me.EndPeriod.GetFirstUnlockedPeriodBefore
        Dim startDate As Date
        Dim endDate As Date
        If Not firstPeriod Is Nothing AndAlso firstPeriod.Originated Then
          startDate = firstPeriod.StartDate
        Else
          startDate = Me.EndPeriod.StartDate
        End If
        If startDate.Equals(Date.MinValue) Then
          Return 0
        End If
        endDate = Me.EndPeriod.EndDate
        'พร้อมแล้ว
        Dim oldProfit As Decimal = Me.ProfitAccount.GetProfitToDate(startDate.AddDays(-1))
        Return oldProfit + Me.Profit      End Get    End Property
    Public Sub RefreshGross()
      Dim sumDebit As Decimal = 0
      For Each row As TreeRow In Me.ItemTable.Childs
        If Not IsDBNull(row("closeacctpi_isdebit")) AndAlso CBool(row("closeacctpi_isdebit")) _
        AndAlso IsNumeric(row("closeacctpi_amt")) Then
          sumDebit += CDec(row("closeacctpi_amt"))
        End If
      Next
      m_debitAmount = sumDebit

      Dim sumCredit As Decimal = 0
      For Each row As TreeRow In Me.ItemTable.Childs
        If Not IsDBNull(row("closeacctpi_isdebit")) AndAlso Not CBool(row("closeacctpi_isdebit")) _
        AndAlso IsNumeric(row("closeacctpi_amt")) Then
          sumCredit += CDec(row("closeacctpi_amt"))
        End If
      Next
      m_creditAmount = sumCredit
    End Sub
    Private m_debitAmount As Decimal = 0
    Public ReadOnly Property DebitAmount() As Decimal
      Get
        Return m_debitAmount
      End Get
    End Property
    Private m_creditAmount As Decimal = 0
    Public ReadOnly Property CreditAmount() As Decimal
      Get
        Return m_creditAmount
      End Get
    End Property
    Public ReadOnly Property Profit() As Decimal
      Get
        Return DebitAmount - CreditAmount
      End Get
    End Property
    Public Property DocDate() As Date Implements IGLAble.Date, ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate      Get
        Return m_olddocDate
      End Get
    End Property    Public Property Note() As String Implements IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, CloseAccountPeriodStatus)      End Set    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "CloseAccountPeriod"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "CloseAccountPeriod"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "closeacctp"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CloseAccountPeriod.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.CloseAccountPeriod"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.CloseAccountPeriod"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CloseAccountPeriod.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt = tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "CloseAccountPeriod"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "closeacctpi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "closeacctpi_linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csDebitAmount As New TreeTextColumn
      csDebitAmount.MappingName = "DebitAmount"
      csDebitAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodDetail.DebitAmountHeaderText}")
      csDebitAmount.NullText = ""
      csDebitAmount.DataAlignment = HorizontalAlignment.Right
      csDebitAmount.Format = "#,###.##"
      csDebitAmount.TextBox.Name = "DebitAmount"
      csDebitAmount.Width = 60
      csDebitAmount.ReadOnly = True

      Dim csCreditAmount As New TreeTextColumn
      csCreditAmount.MappingName = "CreditAmount"
      csCreditAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CloseAccountPeriodDetail.CreditAmountHeaderText}")
      csCreditAmount.NullText = ""
      csCreditAmount.DataAlignment = HorizontalAlignment.Right
      csCreditAmount.Format = "#,###.##"
      csCreditAmount.TextBox.Name = "CreditAmount"
      csCreditAmount.Width = 60
      csCreditAmount.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csDebitAmount)
      dst.GridColumnStyles.Add(csCreditAmount)

      Return dst
    End Function

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("CloseAccountPeriod")
      myDatatable.Columns.Add(New DataColumn("closeacctpi_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("closeacctpi_acct", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("closeacctpi_amt", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("closeacctpi_isdebit", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("DebitAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CreditAmount", GetType(String)))
      Return myDatatable
    End Function

    Public Sub SetReverse4_5GLItems(ByVal startDate As Date, ByVal endDate As Date)
      Me.IsInitialized = False
      Me.ItemTable.Clear()
      Dim ds As DataSet = SqlHelper.ExecuteDataset( _
              Me.ConnectionString _
              , CommandType.StoredProcedure _
              , "GetReverse4_5GLItems" _
              , New SqlParameter("@docdatestart", startDate) _
              , New SqlParameter("@docdateend", endDate) _
              )
      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New CloseAccountPeriodItem(row, "")
        item.CloseAccountPeriod = Me
        Me.Add(item)
      Next
      Me.IsInitialized = True
    End Sub
#End Region

#Region "Methods"
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)

        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@closeacctp_id", Me.Id))
        End If

        Me.m_je.Status.Value = 4 '******************************

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 4 '*******************************
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@closeacctp_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@closeacctp_docDate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))

        paramArrayList.Add(New SqlParameter("@closeacctp_debitamt", Me.DebitAmount))
        paramArrayList.Add(New SqlParameter("@closeacctp_creditamt", Me.CreditAmount))
        paramArrayList.Add(New SqlParameter("@closeacctp_endperiod", Me.ValidIdOrDBNull(Me.EndPeriod)))
        paramArrayList.Add(New SqlParameter("@closeacctp_profitacct", Me.ValidIdOrDBNull(Me.ProfitAccount)))
        paramArrayList.Add(New SqlParameter("@closeacctp_netprofit", Me.Profit))
        paramArrayList.Add(New SqlParameter("@closeacctp_accprofit", Me.AccProfit))
        paramArrayList.Add(New SqlParameter("@closeacctp_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@closeacctp_status", Me.Status.Value))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)

        If conn.State = ConnectionState.Open Then conn.Close()
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

          m_je.DocDate = Me.EndPeriod.EndDate '******************************
          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
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
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer


      Dim da As New SqlDataAdapter("Select * from CloseAccountPerioditem where closeacctpi_closeacctp=" & Me.Id, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "CloseAccountPerioditem")

      Dim dbCount As Integer = ds.Tables("CloseAccountPerioditem").Rows.Count
      Dim itemCount As Integer = Me.ItemTable.Childs.Count
      Dim i As Integer = 0
      With ds.Tables("CloseAccountPerioditem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For n As Integer = 0 To Me.MaxRowIndex
          Dim item As TreeRow = Me.m_itemTable.Childs(n)
          If ValidateRow(item) Then
            i += 1
            Dim dr As DataRow = .NewRow
            dr("closeacctpi_closeacctp") = Me.Id
            dr("closeacctpi_linenumber") = i
            dr("closeacctpi_acct") = item("closeacctpi_acct")
            dr("closeacctpi_isdebit") = item("closeacctpi_isdebit")
            dr("closeacctpi_amt") = item("closeacctpi_amt")
            .Rows.Add(dr)
          End If
        Next
      End With
      Dim dt As DataTable = ds.Tables("CloseAccountPerioditem")
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
      , "GetCloseAccountPerioditems" _
      , New SqlParameter("@closeacctp_id", Me.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New CloseAccountPeriodItem(row, "")
        item.CloseAccountPeriod = Me
        Me.Add(item)
      Next
    End Sub
    Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      For Each dr As DataRow In ds.Tables(1).Rows
        Dim item As New CloseAccountPeriodItem(dr, aliasPrefix)
        item.CloseAccountPeriod = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim myItem As New CloseAccountPeriodItem
        myItem.Account = New Account
        Me.ItemTable.AcceptChanges()
        Me.Add(myItem)
      Next
    End Sub
    Public Function Add(ByVal item As CloseAccountPeriodItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.CloseAccountPeriod = Me
      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As CloseAccountPeriodItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.CloseAccountPeriod = Me
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
        Me.ItemTable.Childs(i)("closeacctpi_linenumber") = i + 1
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
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim proposedAccount As Object = row("closeacctpi_acct")
      Dim proposedCode As Object = row("Code")
      Dim proposedAmount As Object = row("closeacctpi_amt")

      If (IsDBNull(proposedAccount) OrElse CInt(proposedAccount) = 0) _
          And (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") _
          And (IsDBNull(proposedAmount) OrElse CDec(proposedAmount) = 0) _
          Then
        Return False
      End If
      Return True
    End Function
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
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
      Dim ji As New JournalEntryItem
      Dim sumProfit As Decimal = 0
      Dim HQ As CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      For i As Integer = 0 To Me.MaxRowIndex
        Dim item As New CloseAccountPeriodItem
        item.CopyFromDataRow(Me.ItemTable.Childs(i))
        Dim profitDebitMatch As Boolean = False ' J8.1
        Dim opbCreditMatch As Boolean = False ' J8.2
        Dim opbDebitMatch As Boolean = False 'J8.3
        Dim profitCreditMatch As Boolean = False ' J8.4
        For Each addedJi As JournalEntryItem In jiColl
          If item.IsDebit Then
            If Not addedJi.Account Is Nothing _
                AndAlso addedJi.Account.Id = item.Account.Id Then
              If addedJi.Mapping = "J8.3" Then
                opbDebitMatch = True
                addedJi.Amount += item.Amount
                sumProfit += item.Amount
              End If
            End If
          Else
            If Not addedJi.Account Is Nothing _
                AndAlso addedJi.Account.Id = item.Account.Id Then
              If addedJi.Mapping = "J8.2" Then
                opbCreditMatch = True
                addedJi.Amount += item.Amount
                sumProfit -= item.Amount
              End If
            End If
          End If
        Next
        If item.IsDebit Then
          If Not opbDebitMatch Then
            ji = New JournalEntryItem
            ji.Account = item.Account
            ji.Mapping = "J8.3"
            ji.Amount = item.Amount
            ji.CostCenter = HQ
            jiColl.Add(ji)
            sumProfit += item.Amount
          End If
        Else
          If Not opbCreditMatch Then
            ji = New JournalEntryItem
            ji.Account = item.Account
            ji.Mapping = "J8.2"
            ji.Amount = item.Amount
            ji.CostCenter = HQ
            jiColl.Add(ji)
            sumProfit -= item.Amount
          End If
        End If
      Next
      If sumProfit < 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "J8.1"
        ji.Amount = -sumProfit
        ji.CostCenter = HQ
        jiColl.Add(ji)
      ElseIf sumProfit > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "J8.4"
        ji.Amount = sumProfit
        ji.CostCenter = HQ
        jiColl.Add(ji)
      End If
      Return jiColl
    End Function
#End Region


  End Class

  Public Class CloseAccountPeriodItem

#Region "Members"
    Private m_CloseAccountPeriod As CloseAccountPeriod
    Private m_lineNumber As Integer
    Private m_acct As Account
    Private m_amount As Decimal
    Private m_isDebit As Boolean
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
        If dr.Table.Columns.Contains(aliasPrefix & "closeacctpi_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "closeacctpi_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "closeacctpi_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "closeacctpi_amt") AndAlso Not dr.IsNull(aliasPrefix & "closeacctpi_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "closeacctpi_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "closeacctpi_isdebit") AndAlso Not dr.IsNull(aliasPrefix & "closeacctpi_isdebit") Then
          .m_isDebit = CBool(dr(aliasPrefix & "closeacctpi_isdebit"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") AndAlso Not dr.IsNull(aliasPrefix & "acct_id") Then
          If Not dr.IsNull("acct_id") Then
            .m_acct = New Account(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "closeacctpi_acct") AndAlso Not dr.IsNull(aliasPrefix & "closeacctpi_acct") Then
            .m_acct = New Account(CInt(dr(aliasPrefix & "closeacctpi_acct")))
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
    Public Property CloseAccountPeriod() As CloseAccountPeriod      Get        Return m_CloseAccountPeriod      End Get      Set(ByVal Value As CloseAccountPeriod)        m_CloseAccountPeriod = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Account() As Account      Get        Return m_acct      End Get      Set(ByVal Value As Account)        m_acct = Value      End Set    End Property    Public Property Amount() As Decimal      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Property IsDebit() As Boolean      Get        Return m_isDebit      End Get      Set(ByVal Value As Boolean)        m_isDebit = Value      End Set    End Property#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.CloseAccountPeriod.IsInitialized = False
      row("closeacctpi_linenumber") = Me.LineNumber
      row("closeacctpi_isdebit") = Me.IsDebit
      row("closeacctpi_amt") = Me.Amount
      row("DebitAmount") = ""
      row("CreditAmount") = ""
      If Me.Amount <> 0 Then
        If Me.IsDebit Then
          row("DebitAmount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("CreditAmount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        End If
      End If
      If Not Me.Account Is Nothing Then
        row("Code") = Me.Account.Code
        row("Name") = Me.Account.Name
        row("closeacctpi_acct") = Me.Account.Id
      End If
      Me.CloseAccountPeriod.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As DataRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("closeacctpi_linenumber")) Then
          Me.LineNumber = CInt(row("closeacctpi_linenumber"))
        End If
        If Not row.IsNull(("closeacctpi_isdebit")) Then
          Me.IsDebit = CBool(row("closeacctpi_isdebit"))
        End If
        If Not row.IsNull(("closeacctpi_amt")) Then
          Me.Amount = CDec(row("closeacctpi_amt"))
        End If
        If Not row.IsNull(("closeacctpi_acct")) Then
          Me.Account = New Account(CInt(row("closeacctpi_acct")))
        Else
          Me.Account = New Account
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("closeacctpi_linenumber")) Then
          Me.LineNumber = CInt(row("closeacctpi_linenumber"))
        End If
        If Not row.IsNull(("closeacctpi_isdebit")) Then
          Me.IsDebit = CBool(row("closeacctpi_isdebit"))
        End If
        If Not row.IsNull(("closeacctpi_amt")) Then
          Me.Amount = CDec(row("closeacctpi_amt"))
        End If
        If Not row.IsNull(("closeacctpi_acct")) Then
          Me.Account = New Account(CInt(row("closeacctpi_acct")))
        Else
          Me.Account = New Account
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub
#End Region

  End Class
End Namespace
