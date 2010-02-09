Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.DataAccessLayer

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class WithdrawLoan
    Inherits SimpleBusinessEntityBase

#Region "Members"
    'WL_id	numeric(18, 0)		Unchecked
    'WL_loan	numeric(18, 0)	Loan	Checked
    'WL_code	nvarchar(50)	Code	Checked
    'WL_note	nvarchar(1000)		Checked
    'WL_DocDate	smalldatetime	วันที่รับเงิน	Checked
    'WL_DueDate	smalldatetime	วันที่ครบกำหนดจ่ายคืนนะ	Checked
    'WL_Creditperiod	numeric(18, 0)	ตามนั้น	Checked
    'WL_status	nchar(10)	CodeDescription="WLStatus"	Checked
    'WL_Amount	numeric(18, 4)		Checked

    'WL_refid	numeric(18, 0)	WL หรือ Aval (Check)	Checked
    'WL_refType	numeric(18, 0)	WL หรือ Aval (Check)	Checked

    Private m_loan As Loan
    Private m_note As String
    Private m_docdate As Date
    Private m_duedate As Date
    Private m_creditperiod As Integer
    Private m_amount As Decimal
    Private m_costCenter As CostCenter
    Private m_statusId As Integer
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
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      Dim deh As New DataRowHelper(dr)
      Dim loanId As Integer = deh.GetValue(Of Integer)("wl_loan")
      m_loan = New Loan(loanId)
      m_note = deh.GetValue(Of String)("wl_note")
      m_creditperiod = deh.GetValue(Of Integer)("wl_creditperiod")
      m_docdate = deh.GetValue(Of Date)("wl_docdate")
      m_duedate = deh.GetValue(Of Date)("wl_duedate")

      m_amount = deh.GetValue(Of Decimal)("wl_amount")

      m_statusId = deh.GetValue(Of Integer)("wl_status")

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
    Public Property Note As String
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property DocDate As Date
      Get
        Return m_docdate
      End Get
      Set(ByVal Value As Date)
        m_docdate = Value
      End Set
    End Property
    Public Property DueDate As Date
      Get
        Return m_duedate
      End Get
      Set(ByVal Value As Date)
        m_duedate = Value
      End Set
    End Property
    Public Property CreditPeriod As Integer
      Get
        Return m_creditperiod
      End Get
      Set(ByVal Value As Integer)
        m_creditperiod = Value
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
    Public Property StatusId As Integer
      Get
        Return m_statusId
      End Get
      Set(ByVal Value As Integer)
        m_statusId = Value
      End Set
    End Property
#End Region

#Region "Overrides Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "WithdrawLoan"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WithdrawLoan.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.WithdrawLoan"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.WithdrawLoan"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WithdrawLoan.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "wl"
      End Get
    End Property
#End Region

#Region "Method"
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overrides Function ToString() As String
      Return Me.Code
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
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_loan", ValidIdOrDBNull(Me.Loan)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_duedate", ValidDateOrDBNull(Me.DueDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditperiod", Me.CreditPeriod))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amount", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_costCenter", ValidIdOrDBNull(Me.CostCenter)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_statusId", Me.StatusId))

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
    Public Shared Function GetWithdrawLoan(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEmp As WithdrawLoan) As Boolean
      Dim emp As New WithdrawLoan(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not emp.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        emp = oldEmp
      End If
      txtCode.Text = emp.Code
      txtName.Text = emp.Code
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteWithdrawLoan}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteWithdrawLoan", New SqlParameter() {New SqlParameter("@wl_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.WithdrawLoanIsReferencedCannotBeDeleted}")
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