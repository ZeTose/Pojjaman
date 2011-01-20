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
    Public Class BankBranch
        Inherits SimpleBusinessEntityBase
        Implements IHasName, IBillablePerson

#Region "Members"
        Private m_name As String
        Private m_bank As Bank

        Private m_ibilladdress As String
        Private m_ibillbillingaddress As String
        Private m_ibilldetaildiscount As Discount
        Private m_ibillemailaddress As String
        Private m_ibillfax As String
        Private m_ibillfaxforexport As String
        Private m_ibillhomepage As String
        Private m_ibillidno As String
        Private m_ibillpersontype As BusinessPersonType
        Private m_ibillphone As String
        Private m_ibillprovince As String
        Private m_ibillsummarydiscount As Discount
        Private m_ibilltaxid As String
        Private m_ibilltaxrate As Decimal
        Private m_contact As String
        Private m_mobile As String
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
            Me.m_bank = New Bank
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' Branch Name
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
                ' Bank
                If dr.Table.Columns.Contains(aliasPrefix & "bank_id") AndAlso Not dr.IsNull(aliasPrefix & "bank_id") Then
                    .m_bank = New Bank(dr, aliasPrefix)
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bank") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bank") Then
                        .m_bank = New Bank(CInt(dr(aliasPrefix & Me.Prefix & "_bank")))
                    End If
                End If
                ' Contact Name
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_contact") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_contact") Then
                    .m_contact = CStr(dr(aliasPrefix & Me.Prefix & "_contact"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Name() As String Implements IHasName.Name
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property
        Public Property Bank() As Bank            Get                Return m_bank            End Get            Set(ByVal Value As Bank)                m_bank = Value            End Set        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "BankBranch"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.BankBranch.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.BankBranch"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.BankBranch"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.BankBranch.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "bankbranch"
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
#End Region

#Region "Method"
        Public Overrides Function ToString() As String
            Return Me.ClassName
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

            If Me.AutoGen And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
            End If
            Me.AutoGen = False

            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bank", IIf(Me.Bank.Originated, Me.Bank.Id, DBNull.Value)))

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
        Public Shared Function GetBankBranch(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldbranch As BankBranch) As Boolean
            Dim newbranch As New BankBranch(txtCode.Text)
            If txtCode.TextLength <> 0 AndAlso Not newbranch.Valid Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                newbranch = oldbranch
            End If
            txtCode.Text = newbranch.Code
            txtName.Text = newbranch.Name
            If oldbranch.Id <> newbranch.Id Then
                oldbranch = newbranch
                Return True
            End If
            Return False
        End Function
#End Region

#Region " IBillablePerson "

        Public Property Address() As String Implements IBillablePerson.Address
            Get
                Return m_ibilladdress
            End Get
            Set(ByVal Value As String)
                m_ibilladdress = Value
            End Set
        End Property

        Public Property BillingAddress() As String Implements IBillablePerson.BillingAddress
            Get
                Return m_ibillbillingaddress
            End Get
            Set(ByVal Value As String)
                m_ibillbillingaddress = Value
            End Set
        End Property

        Public Property DetailDiscount() As Discount Implements IBillablePerson.DetailDiscount
            Get
                Return m_ibilldetaildiscount
            End Get
            Set(ByVal Value As Discount)
                m_ibilldetaildiscount = Value
            End Set
        End Property

        Public Property EmailAddress() As String Implements IBillablePerson.EmailAddress
            Get
                Return m_ibillemailaddress
            End Get
            Set(ByVal Value As String)
                m_ibillemailaddress = Value
            End Set
        End Property

        Public Property Fax() As String Implements IBillablePerson.Fax
            Get
                Return m_ibillfax
            End Get
            Set(ByVal Value As String)
                m_ibillfax = Value
            End Set
        End Property
        Public Property FaxforExport() As String Implements IBillablePerson.FaxforExport
            Get
                Return m_ibillfaxforexport
            End Get
            Set(ByVal Value As String)
                m_ibillfaxforexport = Value
            End Set
        End Property

        Public Property HomePage() As String Implements IBillablePerson.HomePage
            Get
                Return m_ibillhomepage
            End Get
            Set(ByVal Value As String)
                m_ibillhomepage = Value
            End Set
        End Property

        Public Property IdNo() As String Implements IBillablePerson.IdNo
            Get
                Return m_ibillidno
            End Get
            Set(ByVal Value As String)
                m_ibillidno = Value
            End Set
        End Property

        Public Property PersonType() As BusinessPersonType Implements IBillablePerson.PersonType
            Get
                Return m_ibillpersontype
            End Get
            Set(ByVal Value As BusinessPersonType)
                m_ibillpersontype = Value
            End Set
        End Property

        Public Property Phone() As String Implements IBillablePerson.Phone
            Get
                Return m_ibillphone
            End Get
            Set(ByVal Value As String)
                m_ibillphone = Value
            End Set
        End Property

        Public Property Province() As String Implements IBillablePerson.Province
            Get
                Return m_ibillprovince
            End Get
            Set(ByVal Value As String)
                m_ibillprovince = Value
            End Set
        End Property

        Public Property SummaryDiscount() As Discount Implements IBillablePerson.SummaryDiscount
            Get
                Return m_ibillsummarydiscount
            End Get
            Set(ByVal Value As Discount)
                m_ibillsummarydiscount = Value
            End Set
        End Property

        Public Property TaxId() As String Implements IBillablePerson.TaxId
            Get
                Return m_ibilltaxid
            End Get
            Set(ByVal Value As String)
                m_ibilltaxid = Value
            End Set
        End Property

        Public Property TaxRate() As Decimal Implements IBillablePerson.TaxRate
            Get
                Return m_ibilltaxrate
            End Get
            Set(ByVal Value As Decimal)
                m_ibilltaxrate = Value
            End Set
        End Property
        Public Property Contact() As String Implements IBillablePerson.Contact
            Get
                Return m_contact
            End Get
            Set(ByVal Value As String)
                m_contact = Value
            End Set
        End Property
        Public Property Mobile() As String Implements IBillablePerson.Mobile
            Get
                Return m_mobile
            End Get
            Set(ByVal Value As String)
                m_mobile = Value
            End Set
        End Property
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
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBankBranch}", format) Then
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBankBranch", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.BankBranchIsReferencedCannotBeDeleted}")
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
