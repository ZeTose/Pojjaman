Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.DataAccessLayer

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Loan
    Inherits SimpleBusinessEntityBase
    Implements IHasName

#Region "Members"
    'loan_id	numeric(18, 0)		Unchecked
    'loan_code	nvarchar(50)	code	Checked
    'loan_name	nvarchar(100)	ชื่อวงเงิน	Checked
    'loan_date	smalldatetime	วันที่ในสัญญา	Checked
    'loan_entity	numeric(18, 0)	**ธนาคาร** และรองรับอื่นๆเช่น พนักงาน ผู้ขาย	Checked
    'loan_entityType	numeric(18, 0)	**ธนาคาร** และรองรับอื่นๆเช่น พนักงาน ผู้ขาย	Checked
    'loan_amount	numeric(18, 4)		Checked
    'loan_interest	nvarchar(500)	อัตราดอกเบี้ย (แค่หมายเหตุไว้เป็นข้อมูล)	Checked
    'loan_cc	numeric(18, 0)		Checked
    'loan_type	numeric(18, 0)	CodeDescription="LoanType"	Checked
    'loan_status	numeric(18, 0)	CodeDescription="LoanStatus"	Checked
    'loan_direction	bit	0=กู้มา,1=ให้กู้	Checked
    Private m_name As String
    Private m_date As Date
    Private m_bankAccount As BankAccount
    Private m_amount As Decimal
    Private m_interest As String
    Private m_costCenter As CostCenter
    Private m_typeId As Integer
    Private m_statusId As Integer
    Private m_account As Account
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
      MyBase.Construct()
      Me.m_account = New Account
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      Dim deh As New DataRowHelper(dr)

      m_name = deh.GetValue(Of String)("loan_name")
      m_date = deh.GetValue(Of Date)("loan_date")

      Dim bankAccountId As Integer = deh.GetValue(Of Integer)("loan_entity")
      m_bankAccount = New BankAccount(bankAccountId)

      m_amount = deh.GetValue(Of Decimal)("loan_amount")
      m_interest = deh.GetValue(Of String)("loan_interest")

      Dim ccId As Integer = deh.GetValue(Of Integer)("loan_cc")
      m_costCenter = New CostCenter(ccId)

      m_typeId = deh.GetValue(Of Integer)("loan_type")
      m_statusId = deh.GetValue(Of Integer)("loan_status")

      Dim LoanAcct As Integer = deh.GetValue(Of Integer)("loan_acct")
      Me.m_account = New Account(LoanAcct)

    End Sub
#End Region

#Region "Properties"    Public Property Name As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
      End Set
    End Property
    Public Property [Date] As Date
      Get
        Return m_date
      End Get
      Set(ByVal Value As Date)
        m_date = Value
      End Set
    End Property
    Public Property BankAccount As BankAccount
      Get
        If m_bankAccount Is Nothing Then
          m_bankAccount = New BankAccount
        End If
        Return m_bankAccount
      End Get
      Set(ByVal Value As BankAccount)
        m_bankAccount = Value
      End Set
    End Property
    Public Property Amount As Decimal
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property
    Public Property Interest As String
      Get
        Return m_interest
      End Get
      Set(ByVal Value As String)
        m_interest = Value
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
        Return "Loan"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Loan.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Loan"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Loan"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Loan.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "loan"
      End Get
    End Property
#End Region

#Region "Method"
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overrides Function ToString() As String
      Return Me.Name
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

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_date", ValidDateOrDBNull(Me.Date)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", ValidIdOrDBNull(Me.BankAccount)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entitytype", 23))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amount", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_interest", Me.Interest))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_CC", ValidIdOrDBNull(Me.CostCenter)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.TypeId))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.StatusId))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acct", IIf(Me.Account.Originated, Me.Account.Id, DBNull.Value)))

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
      Try
        ' Save Processing ...
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        trans.Commit()
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Me.ResetID(oldid)
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As Exception
        trans.Rollback()
        Me.ResetID(oldid)
        Return New SaveErrorException(returnVal.Value.ToString)
      Finally
        conn.Close()
      End Try
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetLoan(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEmp As Loan) As Boolean
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteLoan", New SqlParameter() {New SqlParameter("@Loan_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.LoanIsReferencedCannotBeDeleted}")
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

  End Class
End Namespace