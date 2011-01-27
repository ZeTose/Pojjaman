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
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  'Public Enum CreditType
  '    Cash
  '    Credit
  '    Depends
  'End Enum
  Public Class CreditType
    Inherits CodeDescription

#Region "Construtors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "credit_type"
      End Get
    End Property
#End Region

  End Class

  Public Class Customer
    Inherits PersonEntityBase
    Implements IHasGroup

#Region "Members"
    Private m_creditAmount As Decimal
    Private m_checkAmountOnHand As Decimal

    Private m_lastContactDate As Date
    Private m_lastPayDate As Date
    Private m_coordinator As Employee
    Private m_creditPeriod As Integer
    Private m_creditPeriodFromTransport As Integer

    Private m_group As CustomerGroup
    Private m_authorizeAmount As Decimal
    Private m_birthDate As Date
    Private m_creditType As CreditType
    Private m_receiveDays As String
    Private m_receiveDates As String
    Private m_receiveWeeks As String
    Private m_billrecDays As String
    Private m_billRecDates As String
    Private m_billRecWeeks As String

    Private m_note As String

    Private m_initailized As Boolean
    Public Shared m_CustomerCollection As Hashtable '���� Datarow
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal id As Integer)
      If id = 0 Then
        Return
      End If
      RefreshCustomerCollection(id)
      Dim drow As DataRow = CType(m_CustomerCollection(id), DataRow)
      Me.Construct(drow, "")
      'MyBase.New(id)
    End Sub
    Public Sub New(ByVal code As String)
      If code.Length = 0 Then
        Return
      End If
      RefreshCustomerCollection(Id)
      Dim drow As DataRow = CType(m_CustomerCollection(code.ToLower), DataRow)
      If Not drow Is Nothing Then
        Me.Construct(drow, "")
      End If
      'MyBase.New(code)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      Me.m_group = New CustomerGroup
      Me.m_coordinator = New Employee
      Me.m_creditType = New CreditType(2)
      Me.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.Customer).Account
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_province") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_province") Then
          .Province = CStr(dr(aliasPrefix & Me.Prefix & "_province"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .Note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_authorizeAmount") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_authorizeAmount") Then
          .AuthorizeAmount = CDec(dr(aliasPrefix & Me.Prefix & "_authorizeAmount"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_creditPeriod") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_creditPeriod") Then
          .CreditPeriod = CInt(dr(aliasPrefix & Me.Prefix & "_creditPeriod"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_birthdate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_birthdate") Then
          .BirthDate = CDate(dr(aliasPrefix & Me.Prefix & "_birthdate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_CheckAmountOnHand") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_CheckAmountOnHand") Then
          .CheckAmountOnHand = CDec(dr(aliasPrefix & Me.Prefix & "_CheckAmountOnHand"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_creditAmount") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_creditAmount") Then
          .CreditAmount = CDec(dr(aliasPrefix & Me.Prefix & "_creditAmount"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_creditType") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_creditType") Then
          .CreditType.Value = CInt(dr(aliasPrefix & Me.Prefix & "_creditType"))
        End If
        If dr.Table.Columns.Contains("csg_id") Then
          If Not dr.IsNull("csg_id") Then
            .Group = New CustomerGroup(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_group") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_group") Then
            .Group = New CustomerGroup(CInt(dr(aliasPrefix & Me.Prefix & "_group")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_lastContactDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_lastContactDate") Then
          .LastContactDate = CDate(dr(aliasPrefix & Me.Prefix & "_lastContactDate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_lastPayDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_lastPayDate") Then
          .LastPayDate = CDate(dr(aliasPrefix & Me.Prefix & "_lastPayDate"))
        End If
        If dr.Table.Columns.Contains("coordinator.employee_id") Then
          If Not dr.IsNull("coordinator.employee_id") Then
            .Coordinator = New Employee(dr, "coordinator.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_coordinator") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_coordinator") Then
            .Coordinator = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_coordinator")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_creditPeriodFromTransport") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_creditPeriodFromTransport") Then
            .CreditPeriodFromTransport = CInt(dr(aliasPrefix & Me.Prefix & "_creditPeriodFromTransport"))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_billRecDates") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_billRecDates") Then
            .BillRecDates = CStr(dr(aliasPrefix & Me.Prefix & "_billRecDates"))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_billrecDays") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_billrecDays") Then
            .BillrecDays = CStr(dr(aliasPrefix & Me.Prefix & "_billrecDays"))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_billRecWeeks") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_billRecWeeks") Then
            .BillRecWeeks = CStr(dr(aliasPrefix & Me.Prefix & "_billRecWeeks"))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_receiveDates") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_receiveDates") Then
            .ReceiveDates = CStr(dr(aliasPrefix & Me.Prefix & "_receiveDates"))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_receiveDays") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_receiveDays") Then
            .ReceiveDays = CStr(dr(aliasPrefix & Me.Prefix & "_receiveDays"))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_receiveWeeks") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_receiveWeeks") Then
            .ReceiveWeeks = CStr(dr(aliasPrefix & Me.Prefix & "_receiveWeeks"))
          End If
        End If
      End With

      'Hack เอาออก
      'LoadImage()

    End Sub
    Public Overloads Sub LoadImage(ByVal reader As IDataReader)
      Me.Image = Field.GetImage(reader, "cust_image")
      Me.Map = Field.GetImage(reader, "cust_map")
    End Sub
    Public Overloads Sub LoadImage()
      If Not Me.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select cust_image,cust_map from Customerimage where cust_id=" & Me.Id

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

#Region "Cache Memo"
    Public Shared Sub RefreshCustomerCollection(ByVal Key As Object)
      If IsNumeric(Key) Then
        If CInt(Key) = 0 Then
          Return
        End If
      End If

      If m_CustomerCollection Is Nothing Then
        m_CustomerCollection = New Hashtable

        Dim dt As DataTable = RefreshCustomer(Key)
        For Each row As DataRow In dt.Rows
          Dim drh As New DataRowHelper(row)
          m_CustomerCollection.Add(drh.GetValue(Of Integer)("cust_id"), row)
          m_CustomerCollection.Add(drh.GetValue(Of String)("cust_code").ToLower, row)
        Next
      Else
        If Not m_CustomerCollection.Contains(Key) Then
          Dim dt As DataTable = RefreshCustomer(Key)
          For Each row As DataRow In dt.Rows
            Dim drh As New DataRowHelper(row)
            m_CustomerCollection.Add(drh.GetValue(Of Integer)("cust_id"), row)
            m_CustomerCollection.Add(drh.GetValue(Of String)("cust_code").ToLower, row)
          Next
        Else
          Dim drow As DataRow = CType(m_CustomerCollection(Key), DataRow)
          If Not Sync(drow) Then
            Dim dt As DataTable = RefreshCustomer(Key)
            For Each row As DataRow In dt.Rows
              Dim drh As New DataRowHelper(row)
              m_CustomerCollection(drh.GetValue(Of Integer)("cust_id")) = row
              m_CustomerCollection(drh.GetValue(Of String)("cust_code").ToLower) = row
            Next
          End If
        End If
      End If
    End Sub
    Public Shared Function RefreshCustomer(ByVal Key As Object) As DataTable
      Dim id As Object
      Dim code As Object
      If TypeOf Key Is Integer Then
        id = Key
        code = DBNull.Value
      Else
        id = DBNull.Value
        code = Key
      End If

      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "Getcustomer" _
      , New SqlParameter("@cust_id", id) _
      , New SqlParameter("@cust_code", code) _
      )
      Return ds.Tables(0)
    End Function
    Public Shared Function Sync(ByVal drow As DataRow) As Boolean
      Dim drh As New DataRowHelper(drow)
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.Text _
      , "select cust_lastEditDate from customer where cust_id = " & drh.GetValue(Of Integer)("cust_id") _
      )
      If ds.Tables(0).Rows.Count > 0 Then
        Dim drh2 As New DataRowHelper(ds.Tables(0).Rows(0))
        If drh2.GetValue(Of Date)("cust_lastEditDate").Equals(drh.GetValue(Of Date)("cust_lastEditDate")) Then
          Return True
        End If
      Else
        Return True
      End If

      Return False
    End Function
#End Region

#Region "Properties"
    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property
    Public Property CreditAmount() As Decimal      Get        Return m_creditAmount      End Get      Set(ByVal Value As Decimal)        m_creditAmount = Value      End Set    End Property    Public Property CheckAmountOnHand() As Decimal      Get        Return m_checkAmountOnHand      End Get      Set(ByVal Value As Decimal)        m_checkAmountOnHand = Value      End Set    End Property    Public Property LastContactDate() As Date      Get        Return m_lastContactDate      End Get      Set(ByVal Value As Date)        m_lastContactDate = Value      End Set    End Property    Public Property LastPayDate() As Date      Get        Return m_lastPayDate      End Get      Set(ByVal Value As Date)        m_lastPayDate = Value      End Set    End Property    Public Property Coordinator() As Employee      Get        Return m_coordinator      End Get      Set(ByVal Value As Employee)        m_coordinator = Value      End Set    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        m_creditPeriod = Value      End Set    End Property    Public Property CreditPeriodFromTransport() As Integer      Get        Return m_creditPeriodFromTransport      End Get      Set(ByVal Value As Integer)        m_creditPeriodFromTransport = Value      End Set    End Property    Public Property Group() As CustomerGroup      Get        Return m_group      End Get      Set(ByVal Value As CustomerGroup)        m_group = Value      End Set    End Property    Public Property AuthorizeAmount() As Decimal      Get        Return m_authorizeAmount      End Get      Set(ByVal Value As Decimal)        m_authorizeAmount = Value      End Set    End Property    Public Property BirthDate() As Date      Get        Return m_birthDate      End Get      Set(ByVal Value As Date)        m_birthDate = Value      End Set    End Property    Public Property CreditType() As CreditType      Get        Return m_creditType      End Get      Set(ByVal Value As CreditType)        m_creditType = Value      End Set    End Property    Public Property ReceiveDays() As String      Get        Return m_receiveDays      End Get      Set(ByVal Value As String)        m_receiveDays = Value      End Set    End Property    Public Property ReceiveDates() As String      Get        Return m_receiveDates      End Get      Set(ByVal Value As String)        m_receiveDates = Value      End Set    End Property    Public Property ReceiveWeeks() As String      Get        Return m_receiveWeeks      End Get      Set(ByVal Value As String)        m_receiveWeeks = Value      End Set    End Property    Public Property BillrecDays() As String      Get        Return m_billrecDays      End Get      Set(ByVal Value As String)        m_billrecDays = Value      End Set    End Property    Public Property BillRecDates() As String      Get        Return m_billRecDates      End Get      Set(ByVal Value As String)        m_billRecDates = Value      End Set    End Property    Public Property BillRecWeeks() As String      Get        Return m_billRecWeeks      End Get      Set(ByVal Value As String)        m_billRecWeeks = Value      End Set    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Customer"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Customer.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Customer"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Customer"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Customer.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "cust"
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
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "GetCustomer"
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property Initialized() As Boolean
      Get
        Return Me.m_initailized
      End Get
    End Property
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
        paramArrayList.Add(New SqlParameter("@cust_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen Then 'And Me.Code.Length = 0 
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      paramArrayList.Add(New SqlParameter("@cust_acct", ValidIdOrDBNull(Me.Account)))
      paramArrayList.Add(New SqlParameter("@cust_address", Me.Address))
      paramArrayList.Add(New SqlParameter("@cust_altName", Me.AlternateName))
      paramArrayList.Add(New SqlParameter("@cust_authorizeAmount", Me.AuthorizeAmount))
      paramArrayList.Add(New SqlParameter("@cust_billingAddress", Me.BillingAddress))
      paramArrayList.Add(New SqlParameter("@cust_billRecDates", Me.BillRecDates))
      paramArrayList.Add(New SqlParameter("@cust_billrecDays", Me.BillrecDays))
      paramArrayList.Add(New SqlParameter("@cust_billRecWeeks", Me.BillRecWeeks))
      paramArrayList.Add(New SqlParameter("@cust_birthDate", ValidDateOrDBNull(Me.BirthDate)))

      paramArrayList.Add(New SqlParameter("@cust_checkAmountOnHand", Me.CheckAmountOnHand))
      paramArrayList.Add(New SqlParameter("@cust_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@cust_contact", Me.Contact))
      paramArrayList.Add(New SqlParameter("@cust_coordinator", IIf(Me.Coordinator.Originated, Me.Coordinator.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@cust_creditAmount", Me.CreditAmount))
      paramArrayList.Add(New SqlParameter("@cust_creditPeriod", Me.CreditPeriod))
      paramArrayList.Add(New SqlParameter("@cust_creditPeriodFromTransport", Me.CreditPeriodFromTransport))
      paramArrayList.Add(New SqlParameter("@cust_creditType", CShort(Me.CreditType.Value)))
      paramArrayList.Add(New SqlParameter("@cust_group", ValidIdOrDBNull(Me.Group)))
      paramArrayList.Add(New SqlParameter("@cust_detailDiscount", Me.DetailDiscount.Rate))
      paramArrayList.Add(New SqlParameter("@cust_emailAddress", Me.EmailAddress))
      paramArrayList.Add(New SqlParameter("@cust_fax", Me.Fax))
      paramArrayList.Add(New SqlParameter("@cust_mobile", Me.Mobile))
      paramArrayList.Add(New SqlParameter("@cust_homePage", Me.HomePage))
      'paramArrayList.Add(New SqlParameter("@cust_image", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(Me.Image)))
      paramArrayList.Add(New SqlParameter("@cust_lastContactDate", ValidDateOrDBNull(Me.LastContactDate)))
      paramArrayList.Add(New SqlParameter("@cust_lastPayDate", ValidDateOrDBNull(Me.LastPayDate)))
      paramArrayList.Add(New SqlParameter("@cust_mapPointX", Me.MapPosition.X))
      paramArrayList.Add(New SqlParameter("@cust_mapPointY", Me.MapPosition.Y))
      paramArrayList.Add(New SqlParameter("@cust_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@cust_province", Me.Province))
      paramArrayList.Add(New SqlParameter("@cust_phone", Me.Phone))
      paramArrayList.Add(New SqlParameter("@cust_personType", Me.PersonType.Value))
      paramArrayList.Add(New SqlParameter("@cust_receiveDates", Me.ReceiveDates))
      paramArrayList.Add(New SqlParameter("@cust_receiveDays", Me.ReceiveDays))
      paramArrayList.Add(New SqlParameter("@cust_receiveWeeks", Me.ReceiveWeeks))
      paramArrayList.Add(New SqlParameter("@cust_summaryDiscount", Me.SummaryDiscount.Rate))
      paramArrayList.Add(New SqlParameter("@cust_taxId", Me.TaxId))
      paramArrayList.Add(New SqlParameter("@cust_taxRate", Me.TaxRate))
      paramArrayList.Add(New SqlParameter("@cust_Idno", Me.IdNo))
      paramArrayList.Add(New SqlParameter("@cust_note", Me.Note))

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
      Dim oldjecode As String
      Dim oldjeautogen As Boolean

      oldcode = Me.Code
      oldautogen = Me.AutoGen

      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        ' Update CostcenterImage ...
        If Me.Originated Then
          paramArrayList = New ArrayList
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
          Me.PrepareImageParams(paramArrayList)
          sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "Insert" & Me.TableName & "Image", sqlparams)
        End If
        trans.Commit()
        Try
          RefreshInfoList()
          m_infolistNeedsRefreshing = True
        Catch ex As Exception
          Throw New AfterCommitException("Error After Commit", ex)
        End Try
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
    Public Sub PopulateDPIColl(ByVal dpiColl As DocPrintingItemCollection)
      Dim dpi As DocPrintingItem
      'Customer
      dpi = New DocPrintingItem
      dpi.Mapping = "Customer"
      dpi.Value = Me.Code & ":" & Me.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerInfo
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerInfo"
      dpi.Value = Me.Code & ":" & Me.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerCode
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerName
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerName"
      dpi.Value = Me.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerAddress
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerAddress"
      dpi.Value = Me.BillingAddress
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerCurrentAddress
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerCurrentAddress"
      dpi.Value = Me.Address
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerPhone
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerPhone"
      dpi.Value = Me.Phone
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerFax
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerFax"
      dpi.Value = Me.Fax
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerMobile
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerMobile"
      dpi.Value = Me.Mobile
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerContact
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerContact"
      dpi.Value = Me.Contact
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)
    End Sub
    Public Function GetCCTable() As TreeTable
      Dim dt As TreeTable = Me.GetSchemaTable
      If Not Me.Originated Then
        Return dt
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetCCForCust" _
      , New SqlParameter("@cust_id", Me.Id) _
      )

      Dim i As Integer = 0
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim dr As TreeRow = dt.Childs.Add
        dr("Linenumber") = i
        dr("Code") = row("Code")
        dr("Name") = row("Name")
      Next
      Return dt
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

#Region "Shared"
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "CostCenter"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      ' Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 200
      csName.ReadOnly = True
      csName.TextBox.Name = "Name"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)

      Return dst
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("CostCenter")
      myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      Return myDatatable
    End Function
    Public Shared Function GetCustomer(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldcust As Customer) As Boolean
      Dim newcust As New Customer(txtCode.Text)
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteCustomer}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteCustomer", New SqlParameter() {New SqlParameter("@cust_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.CustomerIsReferencedCannotBeDeleted}")
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

#Region "IHasGroup"
    Public ReadOnly Property Group1() As ISimpleEntity Implements IHasGroup.Group
      Get
        Return Me.Group
      End Get
    End Property
#End Region

    Private Shared m_infolistNeedsRefreshing As Boolean = False
    Private Shared m_InfoList As Dictionary(Of String, String)
    Public Shared ReadOnly Property InfoList As Dictionary(Of String, String)
      Get
        If m_InfoList Is Nothing Then
          RefreshInfoList()
        End If
        If m_infolistNeedsRefreshing Then
          RefreshInfoList()
          m_infolistNeedsRefreshing = False
        End If
        Return m_InfoList
      End Get
    End Property
    Private Shared Sub RefreshInfoList()
      m_InfoList = New Dictionary(Of String, String)
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetCustomerList" _
      )
      For Each row As DataRow In ds.Tables(0).Rows
        Dim deh As New DataRowHelper(row)
        Dim code As String = deh.GetValue(Of String)("cust_code")
        Dim name As String = deh.GetValue(Of String)("cust_name")
        Dim kv As New Generic.KeyValuePair(Of String, String)(code, name)
        m_InfoList.Add(kv.Key, kv.Value)
      Next
    End Sub
    Public Shared Function GetDTCustomer() As DataTable
      Dim newDt As New DataTable

      newDt.Columns.Add("cust_code")
      newDt.Columns.Add("cust_name")
      If InfoList Is Nothing OrElse InfoList.Count = 0 Then
        RefreshInfoList()
      End If

      For Each kv As Generic.KeyValuePair(Of String, String) In InfoList
        Dim dr As DataRow = newDt.NewRow
        dr("cust_code") = kv.Key
        dr("cust_name") = kv.Value
        newDt.Rows.Add(dr)
      Next
      Return newDt
    End Function
  End Class
  Public Class CustomerGroup
    Inherits TreeBaseEntity

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As CustomerGroup)
      MyBase.New(myParent)
    End Sub
    Public Sub New(ByVal gid As Integer)
      MyBase.New(gid)
    End Sub
    Public Sub New(ByVal gcode As String)
      MyBase.New(gcode)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "csg"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "CustomerGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CustomerGroup.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.CustomerGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.CustomerGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CustomerGroup.ListLabel}"
      End Get
    End Property
#End Region

#Region "Methods"
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New CustomerGroup(parId)
      Else
        Me.Parent = Me
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New CustomerGroup
      par.Id = id
      par.Code = code
      par.Name = name
      Me.Parent = par
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim parID As Object = 0
        If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
          parID = Me.Parent.Id
        End If

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@csg_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen Then 'And Me.Code.Length = 0 
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@csg_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@csg_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@csg_altname", Me.AlternateName))
        paramArrayList.Add(New SqlParameter("@csg_parid", parID))
        paramArrayList.Add(New SqlParameter("@csg_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@csg_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@csg_control", Me.IsControlGroup))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)

        ' ตรวจจับ Error ของการ Save ...

        Return New SaveErrorException(returnVal.Value.ToString)

      End With
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetCustomerGroup(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldGroup As CustomerGroup, Optional ByVal allowParent As Boolean = False) As Boolean
      Dim group As New CustomerGroup(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not group.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        group = oldGroup
      ElseIf Not allowParent And group.IsControlGroup Then
        MessageBox.Show(group.Code & "-" & group.Name & " เป็นกลุ่มแม่")
        group = oldGroup
      End If
      txtCode.Text = group.Code
      txtName.Text = group.Name
      If Not oldGroup Is Nothing Then
        If oldGroup.Id <> group.Id Then
          oldGroup = group
          Return True
        End If
      End If
      Return False
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return True 'Hack
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteCustomerGroup}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteCustomerGroup", New SqlParameter() {New SqlParameter("@csg_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.CustomerGroupIsReferencedCannotBeDeleted}")
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