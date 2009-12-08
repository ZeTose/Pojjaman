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
  Public Class PettyCashStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"

    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pc_status"
      End Get
    End Property
#End Region

  End Class
  Public Class PettyCash
    Inherits SimpleBusinessEntityBase
    Implements IPaymentItem, IPayable, IPrintableEntity, IHasToCostCenter, IHasName, ICheckPeriod


#Region "Members"
    Private m_name As String
    Private m_docdate As Date
    Private m_account As Account
    Private m_employee As Employee
    Private m_costcenter As Costcenter
    Private m_amount As Decimal
    Private m_remainingamount As Decimal
    Private m_isforemployee As Boolean
    Private m_allowoverbudget As Boolean
    Private m_limitedoverbudget As Boolean
    Private m_limitedoverbudgetamount As Decimal
    Private m_claimrecweeks As String
    Private m_claimrecdays As String
    Private m_claimrecdates As String
    Private m_note As String
    Private m_remainingwithdraw As Decimal

    Private m_closed As Boolean
    Private m_status As PettyCashStatus
    Private m_itemTable As TreeTable
    Private m_pattycashpayment As Payment
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docdate = Now.Date
        .m_account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.PettyCash).Account
        .m_employee = New Employee
        .m_costcenter = New Costcenter
        .m_docdate = Date.Now

        .m_isforemployee = True
        .m_limitedoverbudget = False
        .m_allowoverbudget = False

        .m_status = New PettyCashStatus(-1)

        .m_pattycashpayment = New Payment(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      MyBase.Construct(ds, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        ' name
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
          .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
        End If
        ' docdate
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docdate") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docdate") Then
          .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
        End If
        ' account
        If dr.Table.Columns.Contains("account.account_id") Then
          If Not dr.IsNull("account.account_id") Then
            .m_account = New Account(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_acct") _
              AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_acct") Then
            .m_account = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_acct")))
          End If
        End If
        ' employee
        'If dr.Table.Columns.Contains("employee.employee_id") Then
        '    If Not dr.IsNull("employee.employee_id") Then
        '        .m_employee = New Employee(dr, "")
        '    End If
        'Else
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_emp") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_emp") Then
          .m_employee = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_emp")))
        End If
        'End If
        ' costcenter
        If dr.Table.Columns.Contains("costcenter.cc_id") Then
          If Not dr.IsNull("costcenter.cc_id") Then
            .m_costcenter = New Costcenter(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cc") _
              AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cc") Then
            .m_costcenter = New Costcenter(CInt(dr(aliasPrefix & Me.Prefix & "_cc")))
          End If
        End If
        ' amount
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_amount") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_amount") Then
          .m_amount = CDec(dr(aliasPrefix & Me.Prefix & "_amount"))
        End If
        ' remainingamount 
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_remainingamount") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_remainingamount") Then
          .m_remainingamount = CDec(dr(aliasPrefix & Me.Prefix & "_remainingamount"))
        End If
        ' allowoverbudget
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_allowoverbudget") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_allowoverbudget") Then
            .m_allowoverbudget = CBool(dr(aliasPrefix & Me.Prefix & "_allowoverbudget"))
          End If
        End If
        ' Is for Employee
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isforemployee") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_isforemployee") Then
            .m_isforemployee = CBool(CInt(dr(aliasPrefix & Me.Prefix & "_isforemployee")))
          End If
        End If
        ' limiteOverBudget
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_limitedoverbudget") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_limitedoverbudget") Then
            .m_limitedoverbudget = CBool(dr(aliasPrefix & Me.Prefix & "_limitedoverbudget"))
          End If
        End If
        ' limitedoverbudgetamount 
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_limiteOverBudgetAmount") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_limiteOverBudgetAmount") Then
          .m_limitedoverbudgetamount = CDec(dr(aliasPrefix & Me.Prefix & "_limiteOverBudgetAmount"))
        End If
        ' claimrecweeks
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_claimrecweeks") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_claimrecweeks") Then
          .m_claimrecweeks = CStr(dr(aliasPrefix & Me.Prefix & "_claimrecweeks"))
        End If
        ' claimrecdays 
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_claimrecdays") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_claimrecdays") Then
          .m_claimrecdays = CStr(dr(aliasPrefix & Me.Prefix & "_claimrecdays"))
        End If
        ' claimrecdates
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_claimrecdates") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_claimrecdates") Then
          .m_claimrecdates = CStr(dr(aliasPrefix & Me.Prefix & "_claimrecdates"))
        End If
        ' note
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_closed") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_closed") Then
          .m_closed = CBool(dr(aliasPrefix & Me.Prefix & "_closed"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .m_status = New PettyCashStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        'GenPettyCashPayment()

      End With
    End Sub
    Public Sub GenPettyCashPayment()
      If Me.Originated Then
        Dim sqlselect As String
        sqlselect = "select payment_id,payment_code,payment_docDate,payment_status from payment where payment_refdoctype = " & Me.EntityId & " and payment_refdoc = " & Me.Id
        Dim ds As DataSet = Me.CreateDataset(sqlselect)
        If ds.Tables(0).Rows.Count = 1 Then
          Dim row As DataRow = ds.Tables(0).Rows(0)

          If row.Table.Columns.Contains("payment_id") AndAlso Not row.IsNull("payment_id") Then
            Me.PettyCashPayment.Id = CInt(row("payment_id"))
          End If
          If row.Table.Columns.Contains("payment_code") AndAlso Not row.IsNull("payment_code") Then
            Me.PettyCashPayment.Code = CStr(row("payment_code"))
          End If
          If row.Table.Columns.Contains("payment_docDate") AndAlso Not row.IsNull("payment_docDate") Then
            Me.PettyCashPayment.DocDate = CDate(row("payment_docDate"))
          End If
          If row.Table.Columns.Contains("payment_status") AndAlso Not row.IsNull("payment_status") Then
            Me.PettyCashPayment.Status = New PaymentStatus(CInt(row("payment_status")))
          End If
        End If
      End If
    End Sub
#End Region

#Region "Properties"

    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property

    Public Property Name() As String Implements IHasName.Name      Get        Return m_name      End Get      Set(ByVal Value As String)        m_name = Value      End Set    End Property    Public Property DocDate() As Date Implements ICheckPeriod.DocDate      Get        Return m_docdate      End Get      Set(ByVal Value As Date)        m_docdate = Value      End Set    End Property    Public Property Account() As Account      Get        Return m_account      End Get      Set(ByVal Value As Account)        m_account = Value      End Set    End Property    Public Property Employee() As Employee      Get        Return m_employee      End Get      Set(ByVal Value As Employee)        m_employee = Value      End Set    End Property    Public Property Costcenter() As Costcenter      Get        Return m_costcenter      End Get      Set(ByVal Value As Costcenter)        m_costcenter = Value      End Set    End Property    Public Property Amount() As Decimal Implements IHasAmount.Amount      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Property RemainingWithdraw() As Decimal      Get        Return m_remainingwithdraw      End Get      Set(ByVal Value As Decimal)        m_remainingwithdraw = Value      End Set    End Property    Public Property RemainingAmount() As Decimal      Get        Return m_remainingamount      End Get      Set(ByVal Value As Decimal)        m_remainingamount = Value      End Set    End Property    Public Property IsForEmployee() As Boolean      Get
        Return m_isforemployee
      End Get
      Set(ByVal Value As Boolean)
        m_isforemployee = Value
      End Set
    End Property    Public Property AllowOverBudget() As Boolean      Get        Return m_allowoverbudget      End Get      Set(ByVal Value As Boolean)        m_allowoverbudget = Value      End Set    End Property    Public Property LimitedOverBudget() As Boolean      Get        Return m_limitedoverbudget      End Get      Set(ByVal Value As Boolean)        m_limitedoverbudget = Value      End Set    End Property    Public Property LimitedOverBudgetAmount() As Decimal      Get        Return m_limitedoverbudgetamount      End Get      Set(ByVal Value As Decimal)        m_limitedoverbudgetamount = Value      End Set    End Property    Public Property ClaimRecWeeks() As String      Get        Return m_claimrecweeks      End Get      Set(ByVal Value As String)        m_claimrecweeks = Value      End Set    End Property    Public Property ClaimRecDays() As String      Get        Return m_claimrecdays      End Get      Set(ByVal Value As String)        m_claimrecdays = Value      End Set    End Property    Public Property ClaimRecDates() As String      Get        Return m_claimrecdates      End Get      Set(ByVal Value As String)        m_claimrecdates = Value      End Set    End Property    Public Property Note() As String Implements IPayable.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Closed() As Boolean      Get
        Return m_closed
      End Get
      Set(ByVal Value As Boolean)
        m_closed = Value
      End Set
    End Property    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, PettyCashStatus)
      End Set
    End Property    Public ReadOnly Property PettyCashPayment() As Payment
      Get
        Return m_pattycashpayment
      End Get
    End Property#End Region

#Region "Methods"
    Public Function GetRemainingAmount() As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetPettyCashAmount" _
                , New SqlParameter("@pc_id", Me.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

    End Function
    Public Function GetRemainingAmount(ByVal paymentId As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetPettyCashAmount" _
                , New SqlParameter("@pc_id", Me.Id) _
                , New SqlParameter("@paymenti_payment", paymentId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function

    Private Function ConvertItemsToValueArray(ByVal list As String) As String
      Dim result As String = ""
      If list Is Nothing OrElse list.Length = 0 Then
        Return Nothing
      Else
        For Each item As String In list.Split(","c)
          result &= CStr(CInt(item) + 1) & ","
        Next
        If result.Length <> 0 Then
          result = result.TrimEnd(","c)
        End If
        Return result
      End If
    End Function
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code 'Entity.GetAutoCodeFormat(Me.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(autoCodeFormat, Me)

      pattern = CodeGenerator.GetPattern(pattern)

      Dim lastCode As String = Me.GetLastCode(pattern)
      Dim newCode As String = _
      CodeGenerator.Generate(autoCodeFormat, lastCode, Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(autoCodeFormat, newCode, Me)
      End While
      Return newCode
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
      , "GetPettyCashPayments" _
      , New SqlParameter("@pc_id", Me.Id) _
      )

      Dim i As Integer = 0
      'Dim amt As Decimal = Me.Amount
      Dim remainingAmt As Decimal = 0
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim dr As TreeRow = m_itemTable.Childs.Add
        dr("pc_linenumber") = i
        If Not row.IsNull("payment_refdocDate") Then
          If IsDate(row("payment_refdocDate")) Then
            dr("Date") = CDate(row("payment_refdocDate")).ToShortDateString
          End If
        End If
        dr("Code") = row("payment_refdocCode")
        dr("pc_note") = row("payment_refdocNote")
        dr("Amount") = Configuration.FormatToString(CDec(row("paymenti_amt")), DigitConfig.Price)
        If remainingAmt = 0 Then
          remainingAmt = CDec(row("claimgross"))
        End If
        remainingAmt -= CDec(row("remainingwithdraw"))

        dr("Remainingwithdraw") = Configuration.FormatToString(CDec(row("remainingwithdraw")), DigitConfig.Price)
        dr("RemainingAmount") = Configuration.FormatToString(remainingAmt, DigitConfig.Price)

      Next
    End Sub
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "pc"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "PettyCash"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "PettyCash"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "Get" & Me.TableName
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PettyCash.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PettyCash"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PettyCash"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PettyCash.ListLabel}"
      End Get
    End Property

    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      'Return New SaveErrorException("Not Yet Implemented")

      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current
      Dim paramArrayList As New ArrayList

      paramArrayList.Add(returnVal)
      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen Then 'And Me.Code.Length = 0 
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      If Me.Status.Value = -1 Then
        Me.Status.Value = 2
        'ElseIf Me.PettyCashPayment.Status.Value >= 3 Then
        '    Me.Status.Value = 3
      End If

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isforemployee", Me.IsForEmployee))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acct", IIf(Me.Account.Originated, Me.Account.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_emp", IIf(Me.Employee.Originated, Me.Employee.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", IIf(Me.Costcenter.Originated, Me.Costcenter.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amount", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_remainingamount", Me.RemainingAmount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_allowoverbudget", Me.AllowOverBudget))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_limitedoverbudget", Me.LimitedOverBudget))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_limiteOverBudgetAmount", Me.LimitedOverBudgetAmount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_claimrecweeks", Me.ClaimRecWeeks))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_claimrecdays", Me.ClaimRecDays))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_claimrecdates", Me.ClaimRecDates))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_closed", Me.Closed))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

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
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1, -2, -5
              trans.Rollback()
              Me.ResetID(oldid)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        '*****************************************************************
        Dim item As New PaymentItem
        Dim newPayment As New Payment
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
        , CommandType.StoredProcedure _
        , "GetPaymentId" _
        , New SqlParameter("@payment_refDoc", Me.Id) _
        , New SqlParameter("@payment_refDocType", Me.EntityId))
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count = 1 Then
          newPayment.Id = CInt(ds.Tables(0).Rows(0)(0))
        End If
        If Not Me.Costcenter Is Nothing Then
          newPayment.CCId = Me.Costcenter.Id
        End If
        newPayment.RefDoc = Me
        newPayment.Code = Me.Code & "|PC|" '
        newPayment.DocDate = Me.DocDate
        newPayment.ItemCollection.Clear()
        newPayment.ItemCollection.Add(item)
        item.EntityType = New PaymentEntityType(Me.EntityId)
        item.Entity = Me
        item.Amount = Me.Amount
        Dim savePaymentError As SaveErrorException = newPayment.Save(currentUserId, conn, trans)
        If Not IsNumeric(savePaymentError.Message) Then
          trans.Rollback()
          Me.ResetID(oldid)
          Return savePaymentError
        Else
          Select Case CInt(savePaymentError.Message)
            Case -1, -2, -5
              trans.Rollback()
              Me.ResetID(oldid)
              Return savePaymentError
            Case Else
          End Select
        End If
        '******************************************************************
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
    End Function
#End Region

#Region "IPayable"
    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      Return Me.Amount
    End Function
    Public Property [Date]() As Date Implements IPayable.Date, IPaymentItem.DueDate
      Get
        Return Me.DocDate
      End Get
      Set(ByVal Value As Date)
        Me.DocDate = Value
      End Set
    End Property
    Public Property DueDate() As Date Implements IPayable.DueDate
      Get
      End Get
      Set(ByVal Value As Date)

      End Set
    End Property
    Public Property Payment() As Payment Implements IPayable.Payment
      Get

      End Get
      Set(ByVal Value As Payment)

      End Set
    End Property
    Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
      Get
        Return Supplier.GetDefaultSupplier(Supplier.DefaultSupplierType.PettyCash)
      End Get
    End Property
    Public Function PayableRemainingAmount() As Decimal Implements IPayable.RemainingAmount

    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "PettyCash"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "PettyCash"
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

      'Name
      dpi = New DocPrintingItem
      dpi.Mapping = "Name"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'EmployeeInfo
      If Not Me.Employee Is Nothing AndAlso Me.Employee.Originated Then
        dpi = New DocPrintingItem
        dpi.Mapping = "EmployeeInfo"
        dpi.Value = Me.Employee.Code & ":" & Me.Employee.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CCInfo
      If Not Me.Costcenter Is Nothing AndAlso Me.Costcenter.Originated Then
        dpi = New DocPrintingItem
        dpi.Mapping = "CCInfo"
        dpi.Value = Me.Costcenter.Code & ":" & Me.Costcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Amount
      dpi = New DocPrintingItem
      dpi.Mapping = "Amount"
      dpi.Value = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'AccountInfo
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountInfo"
      dpi.Value = Me.Account.Code & ":" & Me.Account.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Remain
      dpi = New DocPrintingItem
      dpi.Mapping = "Remain"
      dpi.Value = Configuration.FormatToString(Me.GetRemainingAmount(), DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'ClaimRecDays
      dpi = New DocPrintingItem
      dpi.Mapping = "ClaimRecDays"
      dpi.Value = DateTimeService.GetDayStrings(Me.ClaimRecDays, False)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ClaimRecDates
      dpi = New DocPrintingItem
      dpi.Mapping = "ClaimRecDates"
      dpi.Value = ConvertItemsToValueArray(Me.ClaimRecDates)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ClaimRecWeeks
      dpi = New DocPrintingItem
      dpi.Mapping = "ClaimRecWeeks"
      dpi.Value = ConvertItemsToValueArray(Me.ClaimRecWeeks)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Me.AllowOverBudget Then
        dpi = New DocPrintingItem
        dpi.Mapping = "NoLimit"
        dpi.Value = Me.AllowOverBudget
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      ElseIf Me.LimitedOverBudget Then
        dpi = New DocPrintingItem
        dpi.Mapping = "AllowNotOver"
        dpi.Value = Me.AllowOverBudget
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'AllowNotOverAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "AllowNotOverAmount"
        dpi.Value = Configuration.FormatToString(Me.LimitedOverBudgetAmount, DigitConfig.Price)
        dpi.DataType = "System.string"
        dpiColl.Add(dpi)
      Else
        dpi = New DocPrintingItem
        dpi.Mapping = "NotAllow"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Dim n As Integer = 0
      For i As Integer = 0 To Me.m_itemTable.Rows.Count - 1
        Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = itemRow("pc_linenumber")
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.DocDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DocDate"
        dpi.Value = itemRow("Date")
        dpi.DataType = "System.DateTime"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.DocCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DocCode"
        dpi.Value = itemRow("Code")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Amount"
        dpi.Value = itemRow("Amount")
        dpi.DataType = "System.Decimal"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.RemainingWithdraw
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RemainingWithdraw"
        dpi.Value = itemRow("RemainingWithdraw")
        dpi.DataType = "System.Decimal"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.RemainingAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RemainingAmount"
        dpi.Value = itemRow("RemainingAmount")
        dpi.DataType = "System.Decimal"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = itemRow("pc_note")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        n += 1
      Next

      Return dpiColl
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PettyCash")
      myDatatable.Columns.Add(New DataColumn("pc_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainingWithdraw", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainingAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pc_note", GetType(String)))
      Return myDatatable
    End Function

    Public Shared Function GetPettyCash(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldPtc As PettyCash) As Boolean
      Dim ptc As New PettyCash(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not ptc.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        ptc = oldPtc
      End If
      txtCode.Text = ptc.Code
      txtName.Text = ptc.Name
      If oldPtc.Id <> ptc.Id Then
        oldPtc = ptc
        Return True
      End If
      Return False
    End Function
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
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePettyCash}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePettyCash", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.PettyCashIsReferencedCannotBeDeleted}")
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

    Public Property ToCC() As Costcenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.Costcenter
      End Get
      Set(ByVal Value As Costcenter)
        Me.Costcenter = Value
      End Set
    End Property

    
  End Class
End Namespace
