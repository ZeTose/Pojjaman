Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class CustomerContact
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
        Private customercontact_name As String
        Private customercontact_title As String
        Private customercontact_phone As String
        Private customercontact_email As String
        Private customercontact_isPrimary As Boolean
        Private customercontact_customer As Customer

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
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Construct(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            Me.customercontact_customer = New Customer
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .customercontact_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_title") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_title") Then
                    .customercontact_title = CStr(dr(aliasPrefix & Me.Prefix & "_title"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_email") _
               AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_email") Then
                    .customercontact_email = CStr(dr(aliasPrefix & Me.Prefix & "_email"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_phone") _
               AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_phone") Then
                    .customercontact_phone = CStr(dr(aliasPrefix & Me.Prefix & "_phone"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isPrimary") _
               AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isPrimary") Then
                    .customercontact_isPrimary = CBool(dr(aliasPrefix & Me.Prefix & "_isPrimary"))
                End If

                If dr.Table.Columns.Contains("customer_id") Then
                    If Not dr.IsNull("customer_id") Then
                        .customercontact_customer = New Customer(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_customer") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_customer") Then
                        .customercontact_customer = New Customer(CInt(dr(aliasPrefix & Me.Prefix & "_customer")))
                    End If
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Customer() As Customer            Get                Return customercontact_customer            End Get            Set(ByVal Value As Customer)                customercontact_customer = Value            End Set        End Property
        Public Property IsPrimary() As Boolean            Get                Return customercontact_isPrimary            End Get            Set(ByVal Value As Boolean)                customercontact_isPrimary = Value            End Set        End Property
        Public Property Name() As String Implements IHasName.Name            Get                Return customercontact_name            End Get            Set(ByVal Value As String)                customercontact_name = Value            End Set        End Property        Public Property Title() As String            Get                Return customercontact_title            End Get            Set(ByVal Value As String)                customercontact_title = Value            End Set        End Property        Public Property Phone() As String            Get                Return customercontact_phone            End Get            Set(ByVal Value As String)                customercontact_phone = Value            End Set        End Property        Public Property Email() As String            Get                Return customercontact_email            End Get            Set(ByVal Value As String)                customercontact_email = Value            End Set        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "CustomerContact"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.CustomerContact.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.CustomerContact"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.CustomerContact"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.CustomerContact.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "customercontact"
            End Get
        End Property
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Name & ")"
                If tpt.EndsWith("()") Then
                    tpt.TrimEnd("()".ToCharArray)
                End If
                Return tpt
            End Get
        End Property
        'Public Overrides ReadOnly Property GetSprocName() As String
        '    Get
        '        Return "GetCustomerContact"
        '    End Get
        'End Property
#End Region

#Region "Overrides"
        Public Overrides Function ToString() As String
            Return Me.Name
        End Function
        Private Sub ResetID(ByVal oldid As Integer)
            Me.Id = oldid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
    End Sub
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
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_title", Me.Title))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_email", Me.Email))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_phone", Me.Phone))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isPrimary", Me.IsPrimary))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_customer", ValidIdOrDBNull(Me.Customer)))

            SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

            ' สร้าง SqlParameter จาก ArrayList ...
            Dim sqlparams() As SqlParameter
            sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            trans = conn.BeginTransaction

      Dim oldid As Integer = Me.Id

      Dim oldcode As String
      Dim oldautogen As Boolean

      oldcode = Me.Code
      oldautogen = Me.AutoGen

            Try
                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

                trans.Commit()
                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As Exception
                trans.Rollback()
                Me.ResetID(oldid)
        ResetCode(oldcode, oldautogen)
        Return New SaveErrorException(ex.ToString)
            Catch ex As SqlException
                trans.Rollback()
                Me.ResetID(oldid)
        ResetCode(oldcode, oldautogen)
        Return New SaveErrorException(ex.ToString)
            Finally
                conn.Close()
            End Try

        End Function
#End Region

#Region "Methods"

#End Region

#Region "Shared"
        Public Shared Function GetCustomerContact(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldcust As CustomerContact) As Boolean
            Dim newcust As New CustomerContact(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not newcust.Valid Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                newcust = oldcust
            End If
            txtCode.Text = newcust.Code
            txtName.Text = newcust.Name
            If oldcust.Id <> newcust.Id Then
                oldcust = newcust
                Return True
            End If
            Return False
        End Function
#End Region

        '#Region "Delete"
        '        Public Overrides ReadOnly Property CanDelete() As Boolean
        '            Get
        '                ' Hack :
        '                Return True
        '            End Get
        '        End Property
        '        Public Overrides Function Delete() As SaveErrorException
        '            If Not Me.Originated Then
        '                Return New SaveErrorException("${res:Global.Error.NoIdError}")
        '            End If
        '            Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        '            Dim format(0) As String
        '            format(0) = Me.Code
        '            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteCustomerContact}", format) Then
        '                Return New SaveErrorException("${res:Global.CencelDelete}")
        '            End If
        '            Dim trans As SqlTransaction
        '            Dim conn As New SqlConnection(Me.ConnectionString)
        '            conn.Open()
        '            trans = conn.BeginTransaction()
        '            Try
        '                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        '                returnVal.ParameterName = "RETURN_VALUE"
        '                returnVal.DbType = DbType.Int32
        '                returnVal.Direction = ParameterDirection.ReturnValue
        '                returnVal.SourceVersion = DataRowVersion.Current
        '                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteCustomerContact", New SqlParameter() {New SqlParameter("@cust_id", Me.Id), returnVal})
        '                If IsNumeric(returnVal.Value) Then
        '                    Select Case CInt(returnVal.Value)
        '                        Case -1
        '                            trans.Rollback()
        '                            Return New SaveErrorException("${res:Global.CustomerContactIsReferencedCannotBeDeleted}")
        '                        Case Else
        '                    End Select
        '                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
        '                    trans.Rollback()
        '                    Return New SaveErrorException(returnVal.Value.ToString)
        '                End If
        '                trans.Commit()
        '                Return New SaveErrorException("1")
        '            Catch ex As SqlException
        '                trans.Rollback()
        '                Return New SaveErrorException(ex.Message)
        '            Catch ex As Exception
        '                trans.Rollback()
        '                Return New SaveErrorException(ex.Message)
        '            Finally
        '                conn.Close()
        '            End Try
        '        End Function
        '#End Region

    End Class

End Namespace