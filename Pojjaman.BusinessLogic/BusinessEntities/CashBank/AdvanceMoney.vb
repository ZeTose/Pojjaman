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
  Public Class AdvanceMoneyStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal description As String)
      MyBase.New(description)
    End Sub
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"

    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "advm_status"
      End Get
    End Property
#End Region

  End Class
  Public Class AdvanceMoney
    Inherits SimpleBusinessEntityBase
    Implements IPaymentItem, IPayable, IPrintableEntity, IHasName, IGLAble, ICancelable, ICheckPeriod


#Region "Members"
    Private m_name As String
    Private m_docdate As Date
    Private m_olddocdate As Date
    Private m_account As Account
    Private m_employee As Employee
    Private m_costcenter As Costcenter
    Private m_isforemployee As Boolean
    Private m_amount As Decimal
    Private m_remainingamount As Decimal
    Private m_note As String
    Private m_duedate As Date

    Private m_closed As Boolean
    Private m_status As AdvanceMoneyStatus
    Private m_itemTable As TreeTable

    Private m_payment As Payment
    Private m_je As JournalEntry
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
        .m_account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.AdvanceMoney).Account
        .m_employee = New Employee
        .m_costcenter = New Costcenter
        .m_isforemployee = True
        .m_docdate = Date.Now
        .m_olddocdate = Date.Now
        .m_duedate = Date.Now
        .m_payment = New Payment
        .m_payment.DocDate = Me.m_docdate
        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docdate
        .m_status = New AdvanceMoneyStatus(-1)
        .AutoCodeFormat = New AutoCodeFormat(Me)
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
          .m_olddocdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
        End If
        ' duedate
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_duedate") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_duedate") Then
          .m_duedate = CDate(dr(aliasPrefix & Me.Prefix & "_duedate"))
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
        ' Is for Employee
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isforemployee") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_isforemployee") Then
            .m_isforemployee = CBool(CInt(dr(aliasPrefix & Me.Prefix & "_isforemployee")))
          End If
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
          .m_status = New AdvanceMoneyStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        .m_payment = New Payment(Me)
        .m_je = New JournalEntry(Me)

      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub

#End Region

#Region "Properties"

    Public Property ItemTable() As TreeTable
      Get
        Return m_itemTable
      End Get
      Set(ByVal Value As TreeTable)
        m_itemTable = Value
      End Set
    End Property

    Public Property Name() As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
      End Set
    End Property

    Public Property DocDate() As Date Implements ICheckPeriod.DocDate
      Get
        Return m_docdate
      End Get
      Set(ByVal Value As Date)
        m_docdate = Value
        Me.m_je.DocDate = Value
      End Set
    End Property
    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocdate
      End Get
    End Property

    Public ReadOnly Property CreateDate As Nullable(Of Date) Implements IPaymentItem.CreateDate
      Get
        Return DocDate
      End Get
    End Property

    Public Property Account() As Account
      Get
        Return m_account
      End Get
      Set(ByVal Value As Account)
        m_account = Value
      End Set
    End Property

    Public Property Employee() As Employee
      Get
        Return m_employee
      End Get
      Set(ByVal Value As Employee)
        m_employee = Value
      End Set
    End Property
    Public Property Costcenter() As CostCenter
      Get
        Return m_costcenter
      End Get
      Set(ByVal Value As CostCenter)
        m_costcenter = Value
      End Set
    End Property
    Public Property IsForEmployee() As Boolean
      Get
        Return m_isforemployee
      End Get
      Set(ByVal Value As Boolean)
        m_isforemployee = Value
      End Set
    End Property

    Public Property Amount() As Decimal Implements IHasAmount.Amount
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property
    Public Property RemainingAmount() As Decimal
      Get
        Return m_remainingamount
      End Get
      Set(ByVal Value As Decimal)
        m_remainingamount = Value
      End Set
    End Property

    Public Property Note() As String Implements IPayable.Note, IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property Closed() As Boolean
      Get
        Return m_closed
      End Get
      Set(ByVal Value As Boolean)
        m_closed = Value
      End Set
    End Property
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, AdvanceMoneyStatus)
      End Set
    End Property
    Public Property DueDate() As Date
      Get
        Return m_duedate
      End Get
      Set(ByVal Value As Date)
        m_duedate = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Function GetRemainingAmount(Optional ByVal notIncludedMe As Boolean = False) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAdvanceMoneyAmount" _
                , New SqlParameter("@advm_id", Me.Id) _
                , New SqlParameter("@notIncludedMe", notIncludedMe) _
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
                , "GetAdvanceMoneyAmount" _
                , New SqlParameter("@advm_id", Me.Id) _
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
      Dim autoCodeFormat As String
      If Me.AutoCodeFormat.Format.Length > 0 Then
        autoCodeFormat = Me.AutoCodeFormat.Format
      Else
        autoCodeFormat = Me.Code
      End If
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
      , "GetAdvanceMoneyPayments" _
      , New SqlParameter("@advm_id", Me.Id) _
      )

      Dim i As Integer = 0
      Dim amt As Decimal = Me.Amount
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim dr As TreeRow = m_itemTable.Childs.Add
        dr("advm_linenumber") = i
        dr("Date") = IIf(IsDate(row("payment_refdocDate")), CDate(row("payment_refdocDate")).ToShortDateString, "")
        dr("Code") = row("payment_refdocCode")
        dr("advm_note") = row("payment_refdocNote")
        If IsNumeric(row("paymenti_amt")) Then
          dr("Amount") = row("paymenti_amt")
          Dim rowAmt As Decimal = CDec(row("paymenti_amt"))
          dr("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
          amt -= rowAmt
        End If
        dr("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
        dr("refDocId") = row("payment_refDoc")
        dr("refDocType") = row("payment_refDocType")
      Next
    End Sub
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "advm"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AdvanceMoney"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "AdvanceMoney"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "Get" & Me.TableName
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AdvanceMoney.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AdvanceMoney"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AdvanceMoney"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AdvanceMoney.ListLabel}"
      End Get
    End Property

    Private Sub ResetID(ByVal oldid As Integer, ByVal oldpay As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_payment.Id = oldpay
      Me.m_je.Id = oldje
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_payment.Code = oldJecode
      Me.m_payment.AutoGen = oldjeautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub

    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException



      ValidateError = Me.Payment.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If


      Return New SaveErrorException("0")

    End Function
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

      Dim oldcode As String
      Dim oldautogen As Boolean
      Dim oldjecode As String
      Dim oldjeautogen As Boolean

      oldcode = Me.Code
      oldautogen = Me.AutoGen
      oldjecode = Me.m_je.Code
      oldjeautogen = Me.m_je.AutoGen

      If Me.AutoGen Then 'And Me.Code.Length = 0 
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      '---- AutoCode Format --------
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
        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_payment.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If
        If Me.m_je.AutoGen Then
          Me.m_je.Code = m_je.GetNextCode
        End If
      End If
      Me.m_je.DocDate = Me.DocDate
      Me.m_payment.Code = m_je.Code
      Me.m_payment.DocDate = m_je.DocDate
      If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
        Me.m_payment.Code = Me.Code
        Me.m_payment.DocDate = Me.DocDate
      End If
      Me.AutoGen = False
      Me.m_payment.AutoGen = False
      Me.m_je.AutoGen = False
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isforemployee", Me.IsForEmployee))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_duedate", IIf(Me.DueDate.Equals(Date.MinValue), DBNull.Value, Me.DueDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acct", IIf(Me.Account.Originated, Me.Account.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_emp", IIf(Me.Employee.Originated, Me.Employee.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", IIf(Me.Costcenter.Originated, Me.Costcenter.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amount", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_closed", Me.Closed))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

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
      trans = conn.BeginTransaction()

      Dim oldid As Integer = Me.Id
      Dim oldpay As Integer = Me.m_payment.Id
      Dim oldje As Integer = Me.m_je.Id


      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1, -2, -5
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid, oldpay, oldje)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
        If Not IsNumeric(savePaymentError.Message) Then
          trans.Rollback()
          Me.Payment.ResetDetail()
          Me.ResetID(oldid, oldpay, oldje)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return savePaymentError
        Else
          Select Case CInt(savePaymentError.Message)
            Case -1, -5
              trans.Rollback()
              Me.Payment.ResetDetail()
              Me.ResetID(oldid, oldpay, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return savePaymentError
            Case -2
              trans.Rollback()
              Me.Payment.ResetDetail()
              Me.ResetID(oldid, oldpay, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return savePaymentError
            Case Else
          End Select
        End If
        '==============================AUTOGEN==========================================
        Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
        If Not IsNumeric(saveAutoCodeError.Message) Then
          trans.Rollback()
          Me.Payment.ResetDetail()
          ResetID(oldid, oldpay, oldje)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return saveAutoCodeError
        Else
          Select Case CInt(saveAutoCodeError.Message)
            Case -1, -2, -5
              trans.Rollback()
              Me.Payment.ResetDetail()
              ResetID(oldid, oldpay, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveAutoCodeError
            Case Else
          End Select
        End If
        '==============================AUTOGEN==========================================

        If Me.m_je.Status.Value = -1 Then
          m_je.Status.Value = 3
        End If
        Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
        If Not IsNumeric(saveJeError.Message) Then
          trans.Rollback()
          Me.Payment.ResetDetail()
          Me.ResetID(oldid, oldpay, oldje)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return saveJeError
        Else
          Select Case CInt(saveJeError.Message)
            Case -1, -5
              trans.Rollback()
              Me.Payment.ResetDetail()
              Me.ResetID(oldid, oldpay, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
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
        Me.Payment.ResetDetail()
        Me.ResetID(oldid, oldpay, oldje)
        ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
        Return New SaveErrorException(ex.ToString)
      Catch ex As Exception
        trans.Rollback()
        Me.Payment.ResetDetail()
        Me.ResetID(oldid, oldpay, oldje)
        ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
    End Function
#End Region

#Region "IPayable"
    Public Property PaymentDueDate() As Date Implements IPayable.DueDate
      Get
        Return m_duedate
      End Get
      Set(ByVal Value As Date)

      End Set
    End Property
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
    Public Property Payment() As Payment Implements IPayable.Payment
      Get
        Return m_payment
      End Get
      Set(ByVal Value As Payment)
        m_payment = Value
      End Set
    End Property
    Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
      Get
        Return Supplier.GetDefaultSupplier(Supplier.DefaultSupplierType.AdvanceMoney)
      End Get
    End Property
    Public Function PayableRemainingAmount() As Decimal Implements IPayable.RemainingAmount
      Return 0
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "AdvanceMoney"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "AdvanceMoney"
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

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'Name
      dpi = New DocPrintingItem
      dpi.Mapping = "Name"
      dpi.Value = Me.Name
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

      Dim TotalAmount As Decimal = 0

      Dim n As Integer = 0
      For i As Integer = 0 To Me.m_itemTable.Rows.Count - 1
        Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = itemRow("advm_linenumber")
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
        dpi.Value = itemRow("advm_note")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        If Not itemRow.IsNull("Amount") Then
          TotalAmount += CDec(itemRow("Amount"))
        End If

        n += 1
      Next

      'TotalAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalAmount"
      dpi.Value = Configuration.FormatToString(TotalAmount, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("AdvanceMoney")

      myDatatable.Columns.Add(New DataColumn("advm_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainingAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("advm_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("refDocId", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("refDocType", GetType(Integer)))

      Return myDatatable
    End Function

    Public Shared Function GetAdvanceMoney(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldam As AdvanceMoney) As Boolean
      Dim am As New AdvanceMoney(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not am.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        am = oldam
      End If
      txtCode.Text = am.Code
      txtName.Text = am.Name
      If oldam.Id <> am.Id Then
        oldam = am
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAdvanceMoney}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAdvanceMoney", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AdvanceMoneyIsReferencedCannotBeDeleted}")
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

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        If (Me.Status.Value = 1 OrElse Me.Status.Value = 2) AndAlso IsCancelable() Then
          Return True
        Else
          Return False
        End If
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Me.Payment.Status.Value = 0
      Me.JournalEntry.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

#Region "IGLAble"
    Public Property Date1() As Date Implements IGLAble.Date
      Get
        Return Me.DocDate
      End Get
      Set(ByVal Value As Date)
        Me.DocDate = Value
      End Set
    End Property

    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function

    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem

      If Me.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "G9.1"
        ji.Account = Me.Account
        ji.Amount = Me.Amount
        If Me.Costcenter IsNot Nothing Then
          ji.CostCenter = Me.Costcenter
        Else
          ji.CostCenter = Costcenter.GetDefaultCostCenter(Costcenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      If Not Me.Payment Is Nothing Then
        jiColl.AddRange(Me.Payment.GetJournalEntries)
      End If
      Return jiColl
    End Function

    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        Me.m_je = Value
      End Set
    End Property
#End Region


  End Class
End Namespace
