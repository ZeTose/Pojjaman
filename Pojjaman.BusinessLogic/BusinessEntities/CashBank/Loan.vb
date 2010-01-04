Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Loan
    Inherits SimpleBusinessEntityBase
    Implements IHasBankAccount, IHasName

#Region "Members"
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
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
      m_name = deh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_name", "")
      Dim entityTypeId As Integer = deh.GetValue(Of Integer)(aliasPrefix & Me.Prefix & "_entityType", 0)
      Dim entityId As Integer = deh.GetValue(Of Integer)(aliasPrefix & Me.Prefix & "_entity", 0)
      If entityTypeId = 23 Then
        m_bankAccount = New BankAccount(entityId)
      End If

      m_docdate = deh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_date")

      m_amount = deh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_amount", 0)
      m_interest = deh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_interest", "")
      m_loanTypeId = deh.GetValue(Of Integer)(aliasPrefix & Me.Prefix & "_type", 1)
      m_loanStatusId = deh.GetValue(Of Integer)(aliasPrefix & Me.Prefix & "_status", -1)
      m_isOut = deh.GetValue(Of Boolean)(aliasPrefix & Me.Prefix & "_direction", False)
      Dim ccId As Integer = deh.GetValue(Of Integer)(aliasPrefix & Me.Prefix & "_cc", 0)
      m_cc = New CostCenter(ccId)
    End Sub
#End Region

#Region "Properties"
    Private m_cc As CostCenter
    Public Property CostCenter As CostCenter
      Get
        If m_cc Is Nothing Then
          m_cc = New CostCenter
        End If
        Return m_cc
      End Get
      Set(ByVal value As CostCenter)
        m_cc = value
      End Set
    End Property
    Private m_isOut As Boolean
    Public Property IsOut As Boolean
      Get
        Return m_isOut
      End Get
      Set(ByVal value As Boolean)
        m_isOut = value
      End Set
    End Property
    Private m_loanTypeId As Integer
    Public Property LoanTypeId As Integer
      Get
        Return m_loanTypeId
      End Get
      Set(ByVal value As Integer)
        m_loanTypeId = value
      End Set
    End Property
    Private m_loanStatusId As Integer
    Public Property LoanStatusId As Integer
      Get
        Return m_loanStatusId
      End Get
      Set(ByVal value As Integer)
        m_loanStatusId = value
      End Set
    End Property
    Private m_interest As String
    Public Property Interest As String
      Get
        Return m_interest
      End Get
      Set(ByVal value As String)
        m_interest = value
      End Set
    End Property
    Private m_amount As Decimal
    Public Property Amount As Decimal
      Get
        Return m_amount
      End Get
      Set(ByVal value As Decimal)
        m_amount = value
      End Set
    End Property

    Private m_docdate As Date
    Public Property DocDate As Date
      Get
        Return m_docdate
      End Get
      Set(ByVal value As Date)
        m_docdate = value
      End Set
    End Property
    Private m_name As String
    Public Property Name As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal value As String)
        m_name = value
      End Set
    End Property
    Private m_bankAccount As BankAccount
    Public Property BankAccount As BankAccount Implements IHasBankAccount.BankAccount
      Get
        If m_bankAccount Is Nothing Then
          m_bankAccount = New BankAccount
        End If
        Return m_bankAccount
      End Get
      Set(ByVal value As BankAccount)
        m_bankAccount = value
      End Set
    End Property
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
#End Region

#Region "Method"
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current
      Dim paramArrayList As New ArrayList

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      paramArrayList.Add(returnVal)
      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@loan_id", Me.Id))
      End If
      paramArrayList.Add(New SqlParameter("@loan_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@loan_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@loan_date", SimpleBusinessEntityBase.ValidDateOrDBNull(Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@loan_entity", SimpleBusinessEntityBase.ValidIdOrDBNull(Me.BankAccount)))
      paramArrayList.Add(New SqlParameter("@loan_entityType", 23))
      paramArrayList.Add(New SqlParameter("@loan_amount", Me.Amount))
      paramArrayList.Add(New SqlParameter("@loan_interest", Me.Interest))
      paramArrayList.Add(New SqlParameter("@loan_cc", SimpleBusinessEntityBase.ValidIdOrDBNull(Me.CostCenter)))
      paramArrayList.Add(New SqlParameter("@loan_type", Me.LoanTypeId))
      paramArrayList.Add(New SqlParameter("@loan_status", Me.LoanStatusId))
      paramArrayList.Add(New SqlParameter("@loan_direction", Me.IsOut))

      'SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

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
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        trans.Commit()
        ' ตรวจจับ Error ของการ Save ...
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
#End Region

    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "loan"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property
  End Class
End Namespace
