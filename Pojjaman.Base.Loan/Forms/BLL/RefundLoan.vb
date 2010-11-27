Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.DataAccessLayer

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RefundLoan
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IPaymentItem, IPayable, IWitholdingTaxable, ICancelable



#Region "Members"
    'RFL_id	numeric(18, 0)	
    'RFL_WL	numeric(18, 0)	WL
    'RFL_code	nvarchar(50)	
    'RFL_docdate	smalldatetime	วันที่จ่ายคืน
    'RFL_interest	numeric(18, 4)	มูลค่าดอกเบี้ย
    'RFL_Amount	numeric(18, 4)	รวมจ่าย
    'RFL_refund	numeric(18, 4)	มูลค่าเงินต้น
    'RFL_othercharge	numeric(18, 4)	หักค่าใช้จ่ายอื่นๆ

    Private m_loan As Loan
    Private m_WL As WithdrawLoan
    Private m_docdate As Date
    Private m_note As String

    Private m_refund As Decimal
    Private m_interest As Decimal
    Private m_othercharge As Decimal
    Private m_amount As Decimal
    Private m_statusId As Integer
    Private m_statusText As String

    Private m_bankAccount As BankAccount
    Private m_costCenter As CostCenter
    Private m_typeId As Integer

    Private m_account As Account

    Private m_whtcol As WitholdingTaxCollection
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
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      'สร้างเอกสารใหม่
      MyBase.Construct()
      With Me
        .m_loan = New Loan
        .m_note = ""
        .m_docdate = Date.Now.Date
        .StatusId = -1
        '----------------------------Tab Entities-----------------------------------------
        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docdate

        .m_payment = New Payment(Me)
        .m_payment.DocDate = Me.m_docdate
        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      Dim deh As New DataRowHelper(dr)

      m_note = deh.GetValue(Of String)("RFL_note")
      m_docdate = deh.GetValue(Of Date)("RFL_docdate")
      StatusId = deh.GetValue(Of Integer)("RFL_status")
      Dim WLid As Integer = deh.GetValue(Of Integer)("RFL_WL")
      m_WL = New WithdrawLoan(WLid)

      m_refund = deh.GetValue(Of Decimal)("RFL_refund")
      m_othercharge = deh.GetValue(Of Decimal)("RFL_othercharge")
      m_interest = deh.GetValue(Of Decimal)("RFL_interest")
      m_amount = deh.GetValue(Of Decimal)("RFL_Amount")

      Dim LoanId As Integer = deh.GetValue(Of Integer)("loan_id")
      m_loan = New Loan(LoanId)
      Dim bankAccountId As Integer = deh.GetValue(Of Integer)("loan_entity")
      m_bankAccount = New BankAccount(bankAccountId)
      Dim ccId As Integer = deh.GetValue(Of Integer)("loan_cc")
      m_costCenter = New CostCenter(ccId)
      m_typeId = deh.GetValue(Of Integer)("loan_type")


      Dim LoanAcct As Integer = deh.GetValue(Of Integer)("loan_acct")
      Me.m_account = New Account(LoanAcct)
      m_whtcol = New WitholdingTaxCollection(Me)
      m_whtcol.Direction = New WitholdingTaxDirection(1)

      m_payment = New Payment(Me)

      m_je = New JournalEntry(Me)

    End Sub
#End Region

#Region "Properties"    Public Property Loan As Loan
      Get
        If m_loan Is Nothing Then
          m_loan = New Loan
        End If
        Return m_loan
      End Get
      Set(ByVal Value As Loan)
        m_loan = Value
      End Set
    End Property
    Public Property WithdrawLoan As WithdrawLoan
      Get
        If m_WL Is Nothing Then
          m_WL = New WithdrawLoan
        End If
        Return m_WL
      End Get
      Set(ByVal Value As WithdrawLoan)
        m_WL = Value
      End Set
    End Property
    Public Property Note As String Implements IGLAble.Note, IPayable.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property [DocDate] As Date Implements IGLAble.Date, IPayable.Date, IWitholdingTaxable.Date, IPaymentItem.DueDate, IPayable.DueDate
      Get
        Return m_docdate
      End Get
      Set(ByVal Value As Date)
        m_docdate = Value
      End Set
    End Property
    Public ReadOnly Property CreateDate As Nullable(Of Date) Implements IPaymentItem.CreateDate
      Get
        Return DocDate
      End Get
    End Property
    Public Property BankAccount As BankAccount
      Get
        If m_bankAccount Is Nothing Then
          m_bankAccount = New BankAccount
        End If
        Return m_bankAccount
      End Get
      Set(ByVal Value As BankAccount)
        Dim oldPerson As IBillablePerson = m_bankAccount
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If
        m_bankAccount = Value
      End Set
    End Property
    Public Property Refund As Decimal
      Get
        Return m_refund
      End Get
      Set(ByVal Value As Decimal)
        m_refund = Value
      End Set
    End Property
    Public Property OtherCharge As Decimal
      Get
        Return m_othercharge
      End Get
      Set(ByVal Value As Decimal)
        m_othercharge = Value
      End Set
    End Property
    Public Property Interest As Decimal
      Get
        Return m_interest
      End Get
      Set(ByVal Value As Decimal)
        m_interest = Value
      End Set
    End Property
    Public Property Amount As Decimal Implements IHasAmount.Amount
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property

    Public Property CostCenter As CostCenter
      Get
        If m_costCenter Is Nothing Then
          m_costCenter = New CostCenter
        End If
        Return m_costCenter
      End Get
      Set(ByVal Value As CostCenter)
        m_costCenter = Value
      End Set
    End Property
    Public Property TypeId As Integer
      Get
        Return m_typeId
      End Get
      Set(ByVal Value As Integer)
        m_typeId = Value
      End Set
    End Property
    Public Property StatusId As Integer
      Get
        Return m_statusId
      End Get
      Set(ByVal Value As Integer)
        m_statusId = Value
        Select Case m_statusId
          Case -1
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.New}")
          Case 0
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Cancle}")
          Case 1
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.OnHold}")
          Case 2
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Active}")
          Case 3
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Reference}")
          Case 4
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Post}")
          Case 5
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Close}")
        End Select
        Me.Status.Value = Value
      End Set
    End Property
    Public Property StatusText As String
      Get
        Return m_StatusText
      End Get
      Set(ByVal Value As String)
        m_StatusText = Value
      End Set
    End Property
    Public Property Account() As Account
      Get
        Return m_account
      End Get
      Set(ByVal Value As Account)
        m_account = Value
      End Set
    End Property
#End Region

#Region "Overrides Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RefundLoan"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RefundLoan.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RefundLoan"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RefundLoan"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RefundLoan.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "RFL"
      End Get
    End Property
#End Region

#Region "Method"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldpay As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_payment.Id = oldpay
      Me.m_je.Id = oldje
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
    End Sub
    Public Overrides Function ToString() As String
      Return Me.Note
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
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

      If Me.m_je.Status.Value = 4 Then
        Me.StatusId = 4
        Me.m_payment.Status.Value = 4
        Me.m_whtcol.SetStatus(4)
      End If
      If Me.StatusId = 0 Then
        Me.m_payment.Status.Value = 0
        Me.m_whtcol.SetStatus(0)
        Me.m_je.Status.Value = 0
      End If
      If StatusId = -1 Then
        StatusId = 2
      End If

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
        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        If Me.m_je.AutoGen Then
          Me.m_je.Code = m_je.GetNextCode
        End If
      End If
      Me.m_payment.Code = m_je.Code
      Me.m_payment.DocDate = m_je.DocDate
      If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
        Me.m_payment.Code = Me.Code
        Me.m_payment.DocDate = Me.DocDate
      End If
      Me.AutoGen = False
      Me.m_payment.AutoGen = False
      Me.m_je.AutoGen = False

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_WL", Me.WithdrawLoan.Id))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_refund", Me.Refund))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_interest", Me.Interest))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_othercharge", Me.OtherCharge))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amount", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.StatusId))

      ' Save Originator , LastEditor , CancelPerson ...
      ' SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)
      ' สร้าง SqlParameter จาก ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)

      If conn.State = ConnectionState.Open Then conn.Close()
      conn.Open()
      trans = conn.BeginTransaction
      Dim oldid As Integer = Me.Id
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.SaveOldID()
      End If
      Dim oldpay As Integer = Me.m_payment.Id
      Dim oldje As Integer = Me.m_je.Id
      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case -2
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case -5
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid, oldpay, oldje)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        If Not Me.CostCenter Is Nothing Then
          Me.m_payment.CCId = Me.CostCenter.Id
          Me.m_whtcol.SetCCId(Me.CostCenter.Id)
        End If
        
        If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
          Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveWhtError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldpay, oldje)
            Return saveWhtError
          Else
            Select Case CInt(saveWhtError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldpay, oldje)
                Return saveWhtError
              Case -2
                trans.Rollback()
                Me.ResetID(oldid, oldpay, oldje)
                Return saveWhtError
              Case Else
            End Select
          End If
        End If
        Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
        If Not IsNumeric(savePaymentError.Message) Then
          trans.Rollback()
          Me.ResetID(oldid, oldpay, oldje)
          Return savePaymentError
        Else
          Select Case CInt(savePaymentError.Message)
            Case -1, -5
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje)
              Return savePaymentError
            Case -2
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje)
              Return savePaymentError
            Case Else
          End Select
        End If


        If Me.m_je.Status.Value = -1 Then
          m_je.Status.Value = 3
        End If
        Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
        If Not IsNumeric(saveJeError.Message) Then
          trans.Rollback()
          Me.ResetID(oldid, oldpay, oldje)
          Return saveJeError
        Else
          Select Case CInt(saveJeError.Message)
            Case -1, -5
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje)
              Return saveJeError
            Case -2
              'Post ไปแล้ว
              Return saveJeError
            Case Else
          End Select
        End If
        '==============================Reference==========================================
        Me.DeleteRef(conn, trans)
        Me.UpdateRef(Me.WithdrawLoan, conn, trans)
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
        '==============================Reference==========================================
        '==============================AUTOGEN==========================================
        Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
        If Not IsNumeric(saveAutoCodeError.Message) Then
          trans.Rollback()
          ResetID(oldid, oldpay, oldje)
          Return saveAutoCodeError
        Else
          Select Case CInt(saveAutoCodeError.Message)
            Case -1, -2, -5
              trans.Rollback()
              ResetID(oldid, oldpay, oldje)
              Return saveAutoCodeError
            Case Else
          End Select
        End If
        '==============================AUTOGEN==========================================

        trans.Commit()
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Me.ResetID(oldid, oldpay, oldje)
        Return New SaveErrorException(ex.ToString)
      Catch ex As Exception
        trans.Rollback()
        Me.ResetID(oldid, oldpay, oldje)
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetRefundLoan(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEmp As Loan) As Boolean
      Dim emp As New Loan(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not emp.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        emp = oldEmp
      End If
      txtCode.Text = emp.Code
      txtName.Text = emp.Name
      If oldEmp.Id <> emp.Id Then
        oldEmp = emp
        Return True
      End If
      Return False
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        ' Hack :
        Return True
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteLoan}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteRefundLoan", New SqlParameter() {New SqlParameter("@RFL_id", Me.Id), returnVal})
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePaymentItemEntityStatus", New SqlParameter("@payment_id", Me.Payment.Id))
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.RefundLoanIsReferencedCannotBeDeleted}")
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
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.StatusId = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

#Region "IGLable"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function

    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem
      'เจ้าหนี้เงินกู้(ยอดคืนเงินต้น:Refund)
      If Me.Refund > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RFL1" 'ตั้งใหม่
        ji.Amount = Configuration.Format(Me.Refund, DigitConfig.Price)
        ji.Account = Me.Loan.Account
        If Me.Loan.CostCenter.Originated Then 'เอกสารเคยมีใน DB หรือไม่
          ji.CostCenter = Me.Loan.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
      'ดอกเบี้ย(Interest)
      If Me.Interest > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RFL2" 'ตั้งใหม่
        ji.Amount = Configuration.Format(Me.Interest, DigitConfig.Price)
        If Me.Loan.CostCenter.Originated Then 'เอกสารเคยมีใน DB หรือไม่
          ji.CostCenter = Me.Loan.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
      'ค่าธรรมเนียม(OtherCharge)
      If Me.OtherCharge > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RFL3" 'ตั้งใหม่
        ji.Amount = Configuration.Format(Me.OtherCharge, DigitConfig.Price)
        If Me.Loan.CostCenter.Originated Then 'เอกสารเคยมีใน DB หรือไม่
          ji.CostCenter = Me.Loan.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
      'ภาษีหัก ณ ที่จ่าย
      If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B4.10"
        ji.Amount = Me.WitholdingTaxCollection.Amount
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
      Dim WHTTypeSum As New Hashtable

      For Each wht As WitholdingTax In Me.WitholdingTaxCollection
        If WHTTypeSum.Contains(wht.Type.Value) Then
          WHTTypeSum(wht.Type.Value) = CDec(WHTTypeSum(wht.Type.Value)) + wht.Amount
        Else
          WHTTypeSum(wht.Type.Value) = wht.Amount
        End If
      Next
      Dim typeNum As String
      For Each obj As Object In WHTTypeSum.Keys
        typeNum = CStr(obj)
        If Not (typeNum.Length > 1) Then
          typeNum = "0" & typeNum
        End If
        If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.18"
          ji.Amount = CDec(WHTTypeSum(obj))
          ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Loan.Name
          jiColl.Add(ji)
        End If
      Next
      For Each wht As WitholdingTax In Me.WitholdingTaxCollection
        typeNum = CStr(wht.Type.Value)
        If Not (typeNum.Length > 1) Then
          typeNum = "0" & typeNum
        End If
        If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.18D"
          ji.Amount = wht.Amount
          ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Loan.Name

          jiColl.Add(ji)
        End If
      Next
      For Each wht As WitholdingTax In Me.WitholdingTaxCollection
        typeNum = CStr(wht.Type.Value)
        If Not (typeNum.Length > 1) Then
          typeNum = "0" & typeNum
        End If
        If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.18W"
          ji.Amount = wht.Amount
          ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Loan.Name
          jiColl.Add(ji)
        End If
      Next
      If Not Me.Payment Is Nothing Then
        jiColl.AddRange(Me.Payment.GetJournalEntries)
      End If
      Return jiColl
    End Function

    Public Property JournalEntry As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property


#End Region

#Region "IPayable"
    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      Return Me.Amount
    End Function

    Public Property Payment As Payment Implements IPayable.Payment
      Get
        Return m_payment
      End Get
      Set(ByVal Value As Payment)
        m_payment = Value
      End Set
    End Property

    Public ReadOnly Property Recipient As IBillablePerson Implements IPayable.Recipient
      Get
        Return Loan.BankAccount
      End Get
    End Property

    Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount
      Return 0
    End Function

#End Region

#Region "IWitholdingTaxable"
    Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return (Me.OtherCharge + Me.Interest)
    End Function

    Public Property Person As IBillablePerson Implements IWitholdingTaxable.Person
      Get
        Return Me.BankAccount
      End Get
      Set(ByVal value As IBillablePerson)
        Me.BankAccount = CType(value, BankAccount)
      End Set
    End Property

    Public Property WitholdingTaxCollection As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
      Get
        Return m_whtcol
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_whtcol = Value
      End Set
    End Property
#End Region

  End Class
End Namespace