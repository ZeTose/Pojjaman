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
    ' BankAccount
    Public Class BankAccount
        Inherits SimpleBusinessEntityBase

#Region "Members"
        Private m_bankcode As String
        Private m_name As String
        Private m_account As Account
        Private m_bankbranch As BankBranch
        Private m_bankbranchname As String
        Private m_status As BankAccoutStatus
        Private m_type As BankAccountType

        Private m_bankbalance As Decimal
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
            MyBase.Construct(dr, aliasPrefix)
            Construct(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            Me.m_account = New Account
            Me.m_bankbranch = New BankBranch

            Me.m_status = New BankAccoutStatus(1)
            Me.m_type = New BankAccountType(1)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' BankAccount Name ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankcode") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankcode") Then
                    .m_bankcode = CStr(dr(aliasPrefix & Me.Prefix & "_bankcode"))
                End If
                ' BankAccount Name ...
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
                ' BankAccount BankBranch ...
                If dr.Table.Columns.Contains(aliasPrefix & "bankbranch_id") _
                    AndAlso Not dr.IsNull(aliasPrefix & "bankbranch_id") Then
                    .m_bankbranch = New BankBranch(dr, aliasPrefix)
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankbranch") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankbranch") Then
                        .m_bankbranch = New BankBranch(CInt(aliasPrefix & Me.Prefix & "_bankbranch"))
                    End If
                End If
                ' Accout
                If dr.Table.Columns.Contains("acct_id") _
                   AndAlso Not dr.IsNull("acct_id") Then
                    .m_account = New Account(dr, "")
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_acct") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_acct") Then
                        .m_account = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_acct")))
                    End If
                End If
                ' Status
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
                    .m_status = New BankAccoutStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_type") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_type") Then
                    .m_type = New BankAccountType(CInt(dr(aliasPrefix & Me.Prefix & "_type")))
                End If
                ' Bank Balance 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_balance") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_balance") Then
                    .m_bankbalance = CDec(dr(aliasPrefix & Me.Prefix & "_balance"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property BankBalance() As Decimal
            Get
                Return Configuration.Format(m_bankbalance, DigitConfig.Price)
            End Get
        End Property
        Public Property BankCode() As String 'เลขที่บัญชี
            Get
                Return m_bankcode
            End Get
            Set(ByVal Value As String)
                m_bankcode = Value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
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

        Public Property BankBranch() As BankBranch
            Get
                Return m_bankbranch
            End Get
            Set(ByVal Value As BankBranch)
                m_bankbranch = Value
            End Set
        End Property
        Public Property BankBranchName() As String
            Get
                If Me.BankBranch Is Nothing OrElse Not Me.BankBranch.Originated Then
                    Return ""
                Else
                    Return Me.BankBranch.Bank.Name & " / " & Me.BankBranch.Name
                End If
            End Get
            Set(ByVal Value As String)
                m_bankbranchname = Value
            End Set
        End Property
        Public Property Type() As BankAccountType            Get                Return m_type            End Get            Set(ByVal Value As BankAccountType)                m_type = Value            End Set        End Property        Public Overrides Property Status() As CodeDescription
            Get
                Return m_status
            End Get
            Set(ByVal Value As CodeDescription)
                m_status = CType(Value, BankAccoutStatus)
            End Set
        End Property
#End Region

#Region "Overrides"
        Public Overrides ReadOnly Property GetSprocName() As String
            Get
                Return "Get" & Me.ClassName
            End Get
        End Property

        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "bankacct"
            End Get
        End Property

        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "BankAccount"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.BankAccount.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.BankAccount"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.BankAccount"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.BankAccount.ListLabel}"
            End Get
        End Property
#End Region

#Region "Method"

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

            Dim theTime As Date = Now
            Dim theUser As New User(currentUserId)

            If Me.AutoGen And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
            End If
            Me.AutoGen = False

            paramArrayList.Add(returnVal)
            If Me.Originated Then
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
            End If
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankcode", Me.BankCode))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acct", IIf(Me.Account.Originated, Me.Account.Id, DBNull.Value)))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankbranch", IIf(Me.BankBranch.Originated, Me.BankBranch.Id, DBNull.Value)))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.Type.Value))

            'SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

            ' สร้าง SqlParameter จาก ArrayList ...
            Dim sqlparams() As SqlParameter
            sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            trans = conn.BeginTransaction

            Try
                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                trans.Commit()
                ' ตรวจจับ Error ของการ Save ...
                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As SqlException
                trans.Rollback()
                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(returnVal.Value.ToString)
            Finally
                conn.Close()
            End Try

        End Function

#End Region

#Region "Shared"
        Public Shared Function GetBankAccount(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldbankaccount As BankAccount) As Boolean
            Dim newbankaccount As New BankAccount(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not newbankaccount.Valid Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                newbankaccount = oldbankaccount
            End If
            txtCode.Text = newbankaccount.Code
            txtName.Text = newbankaccount.Name
            If oldbankaccount.Id <> newbankaccount.Id Then
                oldbankaccount = newbankaccount
                Return True
            End If
            Return False
        End Function
        Public Shared Function GetBankAccountBankCode(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldbankaccount As BankAccount) As Boolean
            Dim newbankaccount As New BankAccount(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not newbankaccount.Valid Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                newbankaccount = oldbankaccount
            End If
            txtCode.Text = newbankaccount.Code
            txtName.Text = newbankaccount.BankCode
            If oldbankaccount.Id <> newbankaccount.Id Then
                oldbankaccount = newbankaccount
                Return True
            End If
            Return False
        End Function
        Public Shared Function GetBankAccountBankBranch(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByVal txtBankBranch As TextBox, ByRef oldbankaccount As BankAccount) As Boolean
            Dim newbankaccount As New BankAccount(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not newbankaccount.Valid Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                newbankaccount = oldbankaccount
            End If
            txtCode.Text = newbankaccount.Code
            txtName.Text = newbankaccount.Name
            If newbankaccount.BankBranch Is Nothing OrElse Not newbankaccount.BankBranch.Originated Then
                txtBankBranch.Text = ""
            Else
                txtBankBranch.Text = newbankaccount.BankBranch.Bank.Name & " / " & newbankaccount.BankBranch.Name
            End If
            If oldbankaccount.Id <> newbankaccount.Id Then
                oldbankaccount = newbankaccount
                Return True
            End If
            Return False
        End Function
#End Region

#Region "Delete"
        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                If Me.Originated Then
                    Return True
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
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBankAccount}", format) Then
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBankAccount", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.BankAccountIsReferencedCannotBeDeleted}")
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

    ' BankAccoutStatus
    Public Class BankAccoutStatus
        Inherits CodeDescription

#Region "Construtors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "bankacct_status"
            End Get
        End Property
#End Region

    End Class

    Public Class BankAccountType
        Inherits CodeDescription

#Region "Construtors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "bankacct_type"
            End Get
        End Property
#End Region

    End Class
End Namespace
