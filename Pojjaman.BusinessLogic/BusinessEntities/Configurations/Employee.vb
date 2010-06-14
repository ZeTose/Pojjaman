Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class Employee
        Inherits SimpleBusinessEntityBase
        Implements IHasName, IHasImage, IBillablePerson


#Region "Members"
        Private employee_name As String
        Private employee_image As Image
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
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & "employee_name") AndAlso Not dr.IsNull(aliasPrefix & "employee_name") Then
                    .employee_name = CStr(dr(aliasPrefix & "employee_name"))
                End If
            End With
        End Sub

        Public Overloads Sub LoadImage(ByVal reader As IDataReader)
            Me.Image = Field.GetImage(reader, "employee_image")
        End Sub
        Public Overloads Sub LoadImage()
            If Not Me.Originated Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String = "select employee_image from employeeimage where employee_id=" & Me.Id

            conn.Open()

            Dim cmd As SqlCommand = conn.CreateCommand
            cmd.CommandText = sql

            Dim reader As SqlDataReader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))
            If reader.Read Then
                LoadImage(reader)
            End If
            conn.Close()
            reader = Nothing
            conn = Nothing
        End Sub
#End Region

#Region "Properties"        Public Property Name() As String Implements IHasName.Name            Get                Return employee_name            End Get            Set(ByVal Value As String)                employee_name = Value            End Set        End Property        Public Property Image() As Image Implements IHasImage.Image            Get                Return employee_image            End Get            Set(ByVal Value As Image)                employee_image = Value            End Set        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Employee"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Employee.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Employee"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Employee"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Employee.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "employee"
            End Get
        End Property
#End Region

#Region "Method"
        Private Sub ResetID(ByVal oldid As Integer)
            Me.Id = oldid
        End Sub
        Public Overrides Function ToString() As String
            Return Me.employee_name
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
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.employee_name))

            ' Save Originator , LastEditor , CancelPerson ...
            ' SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)
            ' สร้าง SqlParameter จาก ArrayList ...
            Dim sqlparams() As SqlParameter
            sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            trans = conn.BeginTransaction
            Dim oldid As Integer = Me.Id
            Try
                ' Save Processing ...
                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                trans.Commit()
                If Me.Originated Then
                    paramArrayList = New ArrayList
                    paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
                    Me.PrepareImageParams(paramArrayList)
                    sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
                    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "Insert" & Me.TableName & "Image", sqlparams)
                End If
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
        Public Shared Function GetEmployee(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEmp As Employee) As Boolean
            Dim emp As New Employee(txtCode.Text)
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
    Private Shared m_allemployee As Hashtable
    Private Shared Property AllEmployee As Hashtable
      Get
        If m_allemployee Is Nothing Then
          RefreshEmployee()
        End If
        Return m_allemployee
      End Get
      Set(ByVal value As Hashtable)
        m_allemployee = value
      End Set
    End Property
    Public Shared Function GetEmployeeById(ByVal empId As Integer) As Employee
      Dim key As String = empId.ToString
      Dim row As DataRow = CType(AllEmployee(key), DataRow)
      Try
        Dim emp As New Employee(row, "")
        Return emp
      Catch ex As Exception
        Throw New Exception(ex.InnerException.ToString)
      End Try
    End Function
    Private Shared Sub RefreshEmployee()
      Employee.m_allemployee = New Hashtable
      Dim key As String = ""

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetEmployeeCollection" _
    , Nothing)
      If ds.Tables(0).Rows.Count >= 1 Then
        For Each row As DataRow In ds.Tables(0).Rows
          Dim drh As New DataRowHelper(row)
          key = CStr(drh.GetValue(Of Integer)("employee_id"))
          Employee.m_allemployee(key) = row
        Next
      End If
    End Sub
    Public Shared Sub DestroyEmployee()
      m_allemployee = Nothing
    End Sub
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
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteEmployee}", format) Then
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteEmployee", New SqlParameter() {New SqlParameter("@Employee_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.EmployeeIsReferencedCannotBeDeleted}")
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

        Public Property Address() As String Implements IBillablePerson.Address
            Get
                Return CStr(Configuration.GetConfig("CompanyAddress"))
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property BillingAddress() As String Implements IBillablePerson.BillingAddress
            Get
                Return CStr(Configuration.GetConfig("CompanyBillingAddress"))
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property Contact() As String Implements IBillablePerson.Contact
            Get
                Return Me.Name
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property DetailDiscount() As Discount Implements IBillablePerson.DetailDiscount
            Get

            End Get
            Set(ByVal Value As Discount)

            End Set
        End Property

        Public Property EmailAddress() As String Implements IBillablePerson.EmailAddress
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property Fax() As String Implements IBillablePerson.Fax
            Get
                Return CStr(Configuration.GetConfig("CompanyFax"))
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property HomePage() As String Implements IBillablePerson.HomePage
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property IdNo() As String Implements IBillablePerson.IdNo
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property Mobile() As String Implements IBillablePerson.Mobile
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property PersonType() As BusinessPersonType Implements IBillablePerson.PersonType
            Get
                Return New BusinessPersonType(0)
            End Get
            Set(ByVal Value As BusinessPersonType)

            End Set
        End Property

        Public Property Phone() As String Implements IBillablePerson.Phone
            Get
                Return CStr(Configuration.GetConfig("CompanyPhone"))
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property Province() As String Implements IBillablePerson.Province
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property SummaryDiscount() As Discount Implements IBillablePerson.SummaryDiscount
            Get

            End Get
            Set(ByVal Value As Discount)

            End Set
        End Property

        Public Property TaxId() As String Implements IBillablePerson.TaxId
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Property TaxRate() As Decimal Implements IBillablePerson.TaxRate
            Get

            End Get
            Set(ByVal Value As Decimal)

            End Set
        End Property

    

  End Class
End Namespace