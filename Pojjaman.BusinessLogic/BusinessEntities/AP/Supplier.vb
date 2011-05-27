Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Supplier
    Inherits PersonEntityBase
    Implements IPJMUpdatable, IPrintableEntity, IHasGroup

#Region "Members"
    Private m_creditAmount As Decimal
    Private m_checkAmountOnHand As Decimal
    Private m_lastContactDate As Date
    Private m_lastPayDate As Date
    Private m_coordinator As Employee
    Private m_creditPeriod As Integer
    Private m_creditPeriodFromTransport As Integer
    Private m_group As SupplierGroup
    Private m_authorizeAmount As Decimal
    Private m_birthDate As Date
    Private m_creditType As CreditType
    Private m_receiveDays As String
    Private m_receiveDates As String         ' ���繪ش String
    Private m_receiveWeeks As String
    Private m_billrecDays As String
    Private m_billRecDates As String
    Private m_billRecWeeks As String
    Private m_pjmid As Integer
    Private m_invisible As Boolean = False
    Private m_note As String
    Private m_SupplierLCICostLink As SupplierLCICostLink

    Private m_contactCollection As SupplierContactCollection
    Private m_notGetItems As Boolean = False
    Public Shared m_SupplierCollection As Hashtable '���� Datarow
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal id As Integer, Optional ByVal includeInvisible As Boolean = False)
      If id = 0 Then
        Return
      End If
      RefreshSupplierCollection(id, includeInvisible)
      Dim drow As DataRow = CType(m_SupplierCollection(id), DataRow)
      Me.Construct(drow, "")
      'MyBase.New(id)
    End Sub
    Public Sub New(ByVal code As String, ByVal ParamArray filters() As Filter)
      MyBase.New(code, filters)
    End Sub
    Public Sub New(ByVal id As Integer, ByVal ParamArray filters() As Filter)
      MyBase.New(id, filters)
    End Sub
    Public Sub New(ByVal code As String, Optional ByVal includeInvisible As Boolean = False)
      If code.Length = 0 Then
        Return
      End If
      RefreshSupplierCollection(code.ToLower, includeInvisible)
      Dim drow As DataRow = CType(m_SupplierCollection(code.ToLower), DataRow)
      If Not drow Is Nothing Then
        Me.Construct(drow, "")
      End If
      'MyBase.New(id)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub

    Property DCBank As String

    Property DCAccount As String

    Property MCBank As String

    Property MCAccount As String

    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      Me.m_group = New SupplierGroup
      Me.m_coordinator = New Employee
      Me.m_creditType = New CreditType(2)
      Me.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.Supplier).Account
      m_contactCollection = New SupplierContactCollection(Me)
      'm_SupplierLCICostLink = New SupplierLCICostLink
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
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
            .Group = New SupplierGroup(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_group") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_group") Then
            .Group = New SupplierGroup(CInt(dr(aliasPrefix & Me.Prefix & "_group")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_province") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_province") Then
          .Province = CStr(dr(aliasPrefix & Me.Prefix & "_province"))
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
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_creditPeriodFromTransport") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_creditPeriodFromTransport") Then
          .CreditPeriodFromTransport = CInt(dr(aliasPrefix & Me.Prefix & "_creditPeriodFromTransport"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_billRecDates") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_billRecDates") Then
          .BillRecDates = CStr(dr(aliasPrefix & Me.Prefix & "_billRecDates"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_billrecDays") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_billrecDays") Then
          .BillrecDays = CStr(dr(aliasPrefix & Me.Prefix & "_billrecDays"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_billRecWeeks") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_billRecWeeks") Then
          .BillRecWeeks = CStr(dr(aliasPrefix & Me.Prefix & "_billRecWeeks"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_receiveDates") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_receiveDates") Then
          .ReceiveDates = CStr(dr(aliasPrefix & Me.Prefix & "_receiveDates"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_receiveDays") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_receiveDays") Then
          .ReceiveDays = CType(dr(aliasPrefix & Me.Prefix & "_receiveDays"), String)
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_receiveWeeks") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_receiveWeeks") Then
          .ReceiveWeeks = CStr(dr(aliasPrefix & Me.Prefix & "_receiveWeeks"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_pjmid") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_pjmid") Then
          .PJMID = CInt(dr(aliasPrefix & Me.Prefix & "_pjmid"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_invisible") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_invisible") Then
          .invisible = CBool(dr(aliasPrefix & Me.Prefix & "_invisible"))
        End If
        If dr.Table.Columns.Contains("supplier_notgetitems") Then
          If Not dr.IsNull("supplier_notgetitems") Then
            .NotGetItems = CBool(dr("supplier_notgetitems"))
          End If
        End If
      End With

      Dim deh As New DataRowHelper(dr)
      Me.MCAccount = deh.GetValue(Of String)("supplier_kbankmcaccount")
      Me.MCBank = deh.GetValue(Of String)("supplier_kbankmcbank")
      Me.DCAccount = deh.GetValue(Of String)("supplier_kbankdcaccount")
      Me.DCBank = deh.GetValue(Of String)("supplier_kbankdcbank")

      'If m_contactCollection Is Nothing Then
      m_contactCollection = New SupplierContactCollection(Me)
      'End If

      'm_SupplierLCICostLink = New SupplierLCICostLink(Me)
      'Hack ����͡
      'LoadImage()

    End Sub
    Public Overloads Sub LoadImage(ByVal reader As IDataReader)
      Me.Image = Field.GetImage(reader, "supplier_image")
      Me.Map = Field.GetImage(reader, "supplier_map")
    End Sub
    Public Overloads Sub LoadImage()
      If Not Me.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select supplier_image , supplier_map from SupplierImage where supplier_id = " & Me.Id

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

#Region "Properties"
    Public Property ContactCollection() As SupplierContactCollection
      Get
        'If m_contactCollection Is Nothing Then
        '  m_contactCollection = New SupplierContactCollection(Me)
        'End If
        Return m_contactCollection
      End Get
      Set(ByVal Value As SupplierContactCollection)
        m_contactCollection = Value
      End Set
    End Property
    Public Property SupplierLCICostLink() As SupplierLCICostLink      Get        Return m_SupplierLCICostLink      End Get      Set(ByVal Value As SupplierLCICostLink)        m_SupplierLCICostLink = Value      End Set    End Property    Public Property CreditAmount() As Decimal      Get        Return m_creditAmount      End Get      Set(ByVal Value As Decimal)        OnPropertyChanged(Me, New PropertyChangedEventArgs("CreditAmount", m_creditAmount, Value))        m_creditAmount = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CheckAmountOnHand() As Decimal      Get        Return m_checkAmountOnHand      End Get      Set(ByVal Value As Decimal)        OnPropertyChanged(Me, New PropertyChangedEventArgs("CheckAmountOnHand", m_checkAmountOnHand, Value))        m_checkAmountOnHand = Value      End Set    End Property    Public Property LastContactDate() As Date      Get        Return m_lastContactDate      End Get      Set(ByVal Value As Date)        OnPropertyChanged(Me, New PropertyChangedEventArgs("LastContactDate", m_lastContactDate, Value))        m_lastContactDate = Value      End Set    End Property    Public Property LastPayDate() As Date      Get        Return m_lastPayDate      End Get      Set(ByVal Value As Date)        OnPropertyChanged(Me, New PropertyChangedEventArgs("LastPayDate", m_lastPayDate, Value))        m_lastPayDate = Value      End Set    End Property    Public Property Coordinator() As Employee      Get        Return m_coordinator      End Get      Set(ByVal Value As Employee)        OnPropertyChanged(Me, New PropertyChangedEventArgs("Coordinator", m_coordinator, Value))        m_coordinator = Value      End Set    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        OnPropertyChanged(Me, New PropertyChangedEventArgs("CreditPeriod", m_creditPeriod, Value))        m_creditPeriod = Value      End Set    End Property    Public Property CreditPeriodFromTransport() As Integer      Get        Return m_creditPeriodFromTransport      End Get      Set(ByVal Value As Integer)        OnPropertyChanged(Me, New PropertyChangedEventArgs("CreditPeriodFromTransport", m_creditPeriodFromTransport, Value))        m_creditPeriodFromTransport = Value      End Set    End Property    Public Property Group() As SupplierGroup      Get        Return m_group      End Get      Set(ByVal Value As SupplierGroup)        OnPropertyChanged(Me, New PropertyChangedEventArgs("Group", m_group, Value))        m_group = Value      End Set    End Property    Public Property AuthorizeAmount() As Decimal      Get        Return m_authorizeAmount      End Get      Set(ByVal Value As Decimal)        OnPropertyChanged(Me, New PropertyChangedEventArgs("AuthorizeAmount", m_authorizeAmount, Value))        m_authorizeAmount = Value      End Set    End Property    Public Property BirthDate() As Date      Get        Return m_birthDate      End Get      Set(ByVal Value As Date)        OnPropertyChanged(Me, New PropertyChangedEventArgs("BirthDate", m_birthDate, Value))        m_birthDate = Value      End Set    End Property    Public Property CreditType() As CreditType      Get        Return m_creditType      End Get      Set(ByVal Value As CreditType)        OnPropertyChanged(Me, New PropertyChangedEventArgs("CreditType", m_creditType, Value))        m_creditType = Value      End Set    End Property    'Public Property ReceiveDay() As DayOfWeek    '    Get    '        Return m_receiveDay    '    End Get    '    Set(ByVal Value As DayOfWeek)    '        OnPropertyChanged(Me, New PropertyChangedEventArgs("ReceiveDay", m_receiveDay, Value))    '        m_receiveDay = Value    '    End Set    'End Property    Public Property ReceiveDays() As String      Get
        Return m_receiveDays
      End Get
      Set(ByVal Value As String)
        m_receiveDays = Value
      End Set
    End Property    Public Property ReceiveDates() As String      Get
        Return m_receiveDates
      End Get
      Set(ByVal Value As String)
        m_receiveDates = Value
      End Set
    End Property    'Public Property ReceiveDate() As Integer    '    Get    '        Return m_receiveDate    '    End Get    '    Set(ByVal Value As Integer)    '        OnPropertyChanged(Me, New PropertyChangedEventArgs("ReceiveDate", m_receiveDate, Value))    '        m_receiveDate = Value    '    End Set    'End Property    Public Property ReceiveWeeks() As String
      Get
        Return m_receiveWeeks
      End Get
      Set(ByVal Value As String)
        m_receiveWeeks = Value
      End Set
    End Property    Public Property BillrecDays() As String
      Get
        Return m_billrecDays
      End Get
      Set(ByVal Value As String)
        m_billrecDays = Value
      End Set
    End Property    Public Property BillRecDates() As String      Get
        Return m_billRecDates
      End Get
      Set(ByVal Value As String)
        m_billRecDates = Value
      End Set
    End Property    Public Property BillRecWeeks() As String      Get
        Return m_billRecWeeks
      End Get
      Set(ByVal Value As String)
        m_billRecWeeks = Value
      End Set
    End Property    Public Property invisible() As Boolean      Get
        Return Me.m_invisible
      End Get
      Set(ByVal Value As Boolean)
        Me.m_invisible = Value
      End Set
    End Property    Public Property NotGetItems() As Boolean      Get
        Return Me.m_notGetItems
      End Get
      Set(ByVal Value As Boolean)
        Me.m_notGetItems = Value
      End Set
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Supplier"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Supplier.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Supplier"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Supplier"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Supplier.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "supplier"
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
        Return "GetSupplier"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Cache Memo"
    Public Shared Sub RefreshSupplierCollection(ByVal Key As Object, ByVal includeInvisible As Boolean)
      If IsNumeric(Key) Then
        If CInt(Key) = 0 Then
          Return
        End If
      End If

      If m_SupplierCollection Is Nothing Then
        m_SupplierCollection = New Hashtable

        Dim dt As DataTable = RefreshSupplier(Key, includeInvisible)
        For Each row As DataRow In dt.Rows
          Dim drh As New DataRowHelper(row)
          m_SupplierCollection.Add(drh.GetValue(Of Integer)("supplier_id"), row)
          m_SupplierCollection.Add(drh.GetValue(Of String)("supplier_code").ToLower, row)
        Next
      Else
        If Not m_SupplierCollection.Contains(Key) Then
          Dim dt As DataTable = RefreshSupplier(Key, includeInvisible)
          For Each row As DataRow In dt.Rows
            Dim drh As New DataRowHelper(row)
            m_SupplierCollection.Add(drh.GetValue(Of Integer)("supplier_id"), row)
            m_SupplierCollection.Add(drh.GetValue(Of String)("supplier_code").ToLower, row)
          Next
        Else
          Dim drow As DataRow = CType(m_SupplierCollection(Key), DataRow)
          If Not Sync(drow) Then
            Dim dt As DataTable = RefreshSupplier(Key, includeInvisible)
            For Each row As DataRow In dt.Rows
              Dim drh As New DataRowHelper(row)
              m_SupplierCollection(drh.GetValue(Of Integer)("supplier_id")) = row
              m_SupplierCollection(drh.GetValue(Of String)("supplier_code").ToLower) = row
            Next
          End If
        End If
      End If
    End Sub
    Public Shared Function RefreshSupplier(ByVal Key As Object, ByVal includeInvisible As Boolean) As DataTable
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
      , "GetSupplier" _
      , New SqlParameter("@supplier_id", id) _
      , New SqlParameter("@supplier_code", code) _
      , New SqlParameter("@includeInvisible", includeInvisible) _
      )
      Return ds.Tables(0)
    End Function
    Public Shared Function Sync(ByVal drow As DataRow) As Boolean
      Dim drh As New DataRowHelper(drow)
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.Text _
      , "select supplier_lastEditDate from supplier where supplier_id = " & drh.GetValue(Of Integer)("supplier_id") _
      )
      If ds.Tables(0).Rows.Count > 0 Then
        Dim drh2 As New DataRowHelper(ds.Tables(0).Rows(0))
        If drh2.GetValue(Of Date)("supplier_lastEditDate").Equals(drh.GetValue(Of Date)("supplier_lastEditDate")) Then
          Return True
        End If
      Else
        Return True
      End If

      Return False
    End Function
#End Region

#Region "Methods"
    Public Function IsReferenced() As Boolean
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetSupplierIsReferenced" _
      , New SqlParameter("@supplier_id", Me.Id) _
      )
      If CInt(ds.Tables(0).Rows(0)(0)) > 0 Then
        Return True
      End If
      Return False
    End Function
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
      ' ��˹� SqlParameter ���� return ��ҡ�� Execute procedure ...
      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current

      ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
      Dim paramArrayList As New ArrayList

      paramArrayList.Add(returnVal)
      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@supplier_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen Then 'And Me.Code.Length = 0 
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      paramArrayList.Add(New SqlParameter("@supplier_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@supplier_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@supplier_altName", Me.AlternateName))

      paramArrayList.Add(New SqlParameter("@supplier_acct", Me.Account.Id))
      paramArrayList.Add(New SqlParameter("@supplier_group", Me.Group.Id))

      paramArrayList.Add(New SqlParameter("@supplier_address", Me.Address))
      paramArrayList.Add(New SqlParameter("@supplier_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@supplier_mobile", Me.Mobile))
      paramArrayList.Add(New SqlParameter("@supplier_taxId", Me.TaxId))
      paramArrayList.Add(New SqlParameter("@supplier_idno", Me.IdNo))
      paramArrayList.Add(New SqlParameter("@supplier_taxRate", Me.TaxRate))
      paramArrayList.Add(New SqlParameter("@supplier_province", Me.Province))
      paramArrayList.Add(New SqlParameter("@supplier_phone", Me.Phone))
      paramArrayList.Add(New SqlParameter("@supplier_authorizeAmount", Me.AuthorizeAmount))
      paramArrayList.Add(New SqlParameter("@supplier_billingAddress", Me.BillingAddress))

      paramArrayList.Add(New SqlParameter("@supplier_billRecDates", Me.BillRecDates))
      paramArrayList.Add(New SqlParameter("@supplier_billrecDays", Me.BillrecDays))
      paramArrayList.Add(New SqlParameter("@supplier_billRecWeeks", Me.BillRecWeeks))
      paramArrayList.Add(New SqlParameter("@supplier_receiveDates", Me.ReceiveDates))
      paramArrayList.Add(New SqlParameter("@supplier_receiveDays", Me.ReceiveDays))
      paramArrayList.Add(New SqlParameter("@supplier_receiveWeeks", Me.ReceiveWeeks))

      paramArrayList.Add(New SqlParameter("@supplier_birthDate", IIf(Me.BirthDate.Equals(Date.MinValue), DBNull.Value, Me.BirthDate)))
      paramArrayList.Add(New SqlParameter("@supplier_CheckAmountOnHand", Me.CheckAmountOnHand))

      paramArrayList.Add(New SqlParameter("@supplier_coordinator", IIf(Me.Coordinator.Originated, Me.Coordinator.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@supplier_creditAmount", Me.CreditAmount))
      paramArrayList.Add(New SqlParameter("@supplier_creditPeriod", Me.CreditPeriod))
      paramArrayList.Add(New SqlParameter("@supplier_creditPeriodFromTransport", Me.CreditPeriodFromTransport))
      paramArrayList.Add(New SqlParameter("@supplier_creditType", CShort(Me.CreditType.Value)))

      paramArrayList.Add(New SqlParameter("@supplier_detailDiscount", Me.DetailDiscount.Rate))
      paramArrayList.Add(New SqlParameter("@supplier_emailAddress", Me.EmailAddress))
      paramArrayList.Add(New SqlParameter("@supplier_fax", Me.Fax))
      paramArrayList.Add(New SqlParameter("@supplier_homePage", Me.HomePage))

      'paramArrayList.Add(New SqlParameter("@supplier_image", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(Me.Image)))
      'paramArrayList.Add(New SqlParameter("@supplier_map", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(Me.Map)))
      paramArrayList.Add(New SqlParameter("@supplier_mapPointX", Me.MapPosition.X))
      paramArrayList.Add(New SqlParameter("@supplier_mapPointY", Me.MapPosition.Y))

      paramArrayList.Add(New SqlParameter("@supplier_contact", Me.Contact))
      paramArrayList.Add(New SqlParameter("@supplier_lastContactDate", IIf(Me.LastContactDate.Equals(Date.MinValue), DBNull.Value, Me.LastContactDate)))
      paramArrayList.Add(New SqlParameter("@supplier_lastPayDate", IIf(Me.LastPayDate.Equals(Date.MinValue), DBNull.Value, Me.LastPayDate)))

      paramArrayList.Add(New SqlParameter("@supplier_personType", Me.PersonType.Value))

      paramArrayList.Add(New SqlParameter("@supplier_summaryDiscount", Me.SummaryDiscount.Rate))

      paramArrayList.Add(New SqlParameter("@supplier_pjmid", Me.PJMID))

      paramArrayList.Add(New SqlParameter("@supplier_kbankdcaccount", Me.DCAccount))
      paramArrayList.Add(New SqlParameter("@supplier_kbankdcbank", Me.DCBank))
      paramArrayList.Add(New SqlParameter("@supplier_kbankmcaccount", Me.MCAccount))
            paramArrayList.Add(New SqlParameter("@supplier_kbankmcbank", Me.MCBank))
            paramArrayList.Add(New SqlParameter("@supplier_faxforexport", Me.FaxforExport))

      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      ' ���ҧ SqlParameter �ҡ ArrayList ...
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
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1, -2, -5
              trans.Rollback()
              Me.ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case -11
              trans.Rollback()
              Me.ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicateTaxId}"), New String() {Me.TaxId.ToString})
            Case -13
              trans.Rollback()
              Me.ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicateIdNo}"), New String() {Me.IdNo.ToString})
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid)
          ResetCode(oldcode, oldautogen)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Dim saveContactError As SaveErrorException = SaveContact(Me.Id, conn, trans)
        If Not IsNumeric(saveContactError.Message) Then
          trans.Rollback()
          ResetID(oldid)
          ResetCode(oldcode, oldautogen)
          Return saveContactError
        Else
          Select Case CInt(saveContactError.Message)
            Case -1, -2, -5
              trans.Rollback()
              ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return saveContactError
            Case Else
          End Select
        End If
        'trans.Commit()
        'Return New SaveErrorException(returnVal.Value.ToString)
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
      Catch ex As AfterCommitException
        Return New SaveErrorException(ex.InnerException.ToString)
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
    Private Function SaveContact(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from suppliercontact where suppliercontact_supplier=" & Me.Id, conn)
        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.SelectCommand.Transaction = trans

        '��ͧ�����ͨҡ da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "suppliercontact")


        Dim dt As DataTable = ds.Tables("suppliercontact")

        For Each row As DataRow In ds.Tables("suppliercontact").Rows
          row.Delete()
        Next
        Dim i As Integer = 0 'Line Running
        With dt
          For Each myContact As SupplierContact In Me.ContactCollection
            i += 1
            Dim dr As DataRow = .NewRow
            dr("suppliercontact_supplier") = Me.Id
            dr("suppliercontact_code") = myContact.Code
            dr("suppliercontact_name") = myContact.Name
            dr("suppliercontact_title") = myContact.Title
            dr("suppliercontact_phone") = myContact.Phone
            dr("suppliercontact_email") = myContact.Email
            dr("suppliercontact_isprimary") = myContact.IsPrimary
            .Rows.Add(dr)
          Next
        End With

        ' First process deletes.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetDefaultSupplier(ByVal type As DefaultSupplierType) As Supplier
      Select Case type
        Case DefaultSupplierType.PettyCash
          Dim filters(0) As Filter
          filters(0) = New Filter("includeInvisible", True)
          Dim myId As Integer = CInt(Configuration.GetConfig("PettyCashSupplier"))
          Dim sup As New Supplier(myId, filters)
          Return sup
        Case DefaultSupplierType.AdvanceMoney
          Dim filters(0) As Filter
          filters(0) = New Filter("includeInvisible", True)
          Dim myId As Integer = CInt(Configuration.GetConfig("AdvanceMoneySupplier"))
          Dim sup As New Supplier(myId, filters)
          Return sup
        Case Else
      End Select
    End Function
    Public Shared Function GetSupplier(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldsupplier As Supplier) As Boolean
      Dim newsupplier As New Supplier(txtCode.Text, New Filter("includeInvisible", True))
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If txtCode.Text.Length <> 0 AndAlso Not newsupplier.Valid Then
        'MessageBox.Show(txtCode.Text & " �������к�")
        msgServ.ShowMessageFormatted("${res:Global.Error.NoSupplier}", New String() {txtCode.Text})
        newsupplier = oldsupplier
      End If
      txtCode.Text = newsupplier.Code
      txtName.Text = newsupplier.Name
      If oldsupplier Is Nothing OrElse oldsupplier.Id <> newsupplier.Id Then
        oldsupplier = newsupplier
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetSupplier(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldsupplier As Supplier, ByVal CanceledValidate As Boolean) As Boolean
      Dim newsupplier As New Supplier(txtCode.Text)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If txtCode.Text.Length <> 0 AndAlso Not newsupplier.Valid Then
        'MessageBox.Show(txtCode.Text & " �������к�")
        msgServ.ShowMessageFormatted("${res:Global.Error.NoSupplier}", New String() {txtCode.Text})
        newsupplier = oldsupplier
      End If
      If CanceledValidate Then
        If newsupplier.Canceled Then
          msgServ.ShowMessageFormatted("${res:Global.Error.CanceledSupplier}", New String() {txtCode.Text})
          newsupplier = oldsupplier
        End If
      End If
      txtCode.Text = newsupplier.Code
      txtName.Text = newsupplier.Name
      If oldsupplier Is Nothing OrElse oldsupplier.Id <> newsupplier.Id Then
        oldsupplier = newsupplier
        Return True
      End If
      Return False
    End Function
    'Public Shared Function GetSupplierbyDataRow(ByVal dr As DataRow) As Supplier
    '  Dim sup As New Supplier
    '  SetMinimumSup(sup, dr)
    '  Return sup
    'End Function
    'Public Shared Sub SetMinimumSup(ByVal sup As Supplier, ByVal dr As DataRow)
    '  Dim drh As New DataRowHelper(dr)
    '  sup.Id = drh.GetValue(Of Integer)("supplier_id")
    '  sup.Code = drh.GetValue(Of String)("supplier_code")
    '  sup.Name = drh.GetValue(Of String)("supplier_name")
    '  Dim acctId As Integer = drh.GetValue(Of Integer)("supplier_acct")
    '  sup.Account = New Account(acctId)
    'End Sub
    Public Enum DefaultSupplierType
      PettyCash
      AdvanceMoney
    End Enum
#End Region

#Region "IPJMUpdatable"

    Public Property PJMID() As Integer Implements IPJMUpdatable.PJMID
      Get
        Return m_pjmid
      End Get
      Set(ByVal Value As Integer)
        m_pjmid = Value
      End Set
    End Property
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "�����"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "Supplier"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'SupCode
      dpi = New DocPrintingItem
      dpi.Mapping = "SupCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SupName
      dpi = New DocPrintingItem
      dpi.Mapping = "SupName"
      dpi.Value = Me.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AltName
      dpi = New DocPrintingItem
      dpi.Mapping = "AltName"
      dpi.Value = Me.AlternateName
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocAddress
      dpi = New DocPrintingItem
      dpi.Mapping = "DocAddress"
      dpi.Value = Me.BillingAddress
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Address
      dpi = New DocPrintingItem
      dpi.Mapping = "Address"
      dpi.Value = Me.BillingAddress
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CurrentAddress
      dpi = New DocPrintingItem
      dpi.Mapping = "CurrentAddress"
      dpi.Value = Me.Address
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''Province
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Province"
      'dpi.Value = Me.Province
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'Phone
      dpi = New DocPrintingItem
      dpi.Mapping = "Phone"
      dpi.Value = Me.Phone
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Mobile
      dpi = New DocPrintingItem
      dpi.Mapping = "Mobile"
      dpi.Value = Me.Mobile
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Fax
      dpi = New DocPrintingItem
      dpi.Mapping = "Fax"
      dpi.Value = Me.Fax
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Email
      dpi = New DocPrintingItem
      dpi.Mapping = "Email"
      dpi.Value = Me.EmailAddress
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PersonType
      dpi = New DocPrintingItem
      dpi.Mapping = "PersonType"
      dpi.Value = Me.PersonType.Description
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SupCatg
      If Me.Group.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "SupCatgInfo"
        dpi.Value = Me.Group.Code & ":" & Me.Group.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "SupCatgCode"
        dpi.Value = Me.Group.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "SupCatgName"
        dpi.Value = Me.Group.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Account
      If Me.Account.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "AccountInfo"
        dpi.Value = Me.Account.Code & ":" & Account.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "AccountCode"
        dpi.Value = Me.Account.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "AccountName"
        dpi.Value = Me.Account.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Fund
      dpi = New DocPrintingItem
      dpi.Mapping = "Fund"
      dpi.Value = Me.AuthorizeAmount
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxID
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxID"
      dpi.Value = Me.TaxId
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ID
      dpi = New DocPrintingItem
      dpi.Mapping = "ID"
      dpi.Value = Me.Id
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Contact
      dpi = New DocPrintingItem
      dpi.Mapping = "Contact"
      dpi.Value = Me.Contact
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PicMap
      dpi = New DocPrintingItem
      dpi.Mapping = "PicMap"
      dpi.Value = Me.Map
      dpi.DataType = "System.Drawing.Image"
      dpiColl.Add(dpi)

      'PicImage
      dpi = New DocPrintingItem
      dpi.Mapping = "PicImage"
      dpi.Value = Me.Image
      dpi.DataType = "System.Drawing.Image"
      dpiColl.Add(dpi)

      Return dpiColl
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteSupplier}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteSupplier", New SqlParameter() {New SqlParameter("@supplier_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.SupplierIsReferencedCannotBeDeleted}")
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
    Private Shared m_InfoList As Generic.List(Of Generic.KeyValuePair(Of String, String))
    Public Shared ReadOnly Property InfoList As Generic.List(Of Generic.KeyValuePair(Of String, String))
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
      m_InfoList = New Generic.List(Of Generic.KeyValuePair(Of String, String))
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetSupplierList" _
      )
      For Each row As DataRow In ds.Tables(0).Rows
        Dim deh As New DataRowHelper(row)
        Dim code As String = deh.GetValue(Of String)("supplier_code")
        Dim name As String = deh.GetValue(Of String)("supplier_name")
        Dim kv As New Generic.KeyValuePair(Of String, String)(code, name)
        m_InfoList.Add(kv)
      Next
    End Sub
  End Class

  Public Class SupplierGroup
    Inherits TreeBaseEntity

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As SupplierGroup)
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
        Return "spg"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "SupplierGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.SupplierGroup.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.SupplierGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.SupplierGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.SupplierGroup.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Methods"
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New SupplierGroup(parId)
      Else
        Me.Parent = Nothing
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New SupplierGroup
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
        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@spg_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen Then 'And Me.Code.Length = 0 
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@spg_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@spg_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@spg_altname", Me.AlternateName))
        paramArrayList.Add(New SqlParameter("@spg_parid", parID))
        paramArrayList.Add(New SqlParameter("@spg_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@spg_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@spg_control", Me.IsControlGroup))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)

        ' ��Ǩ�Ѻ Error �ͧ��� Save ...

        Return New SaveErrorException(returnVal.Value.ToString)

      End With
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetSupplierGroup(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldGroup As SupplierGroup, Optional ByVal allowParent As Boolean = False) As Boolean
      Dim group As New SupplierGroup(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not group.Valid Then
        MessageBox.Show(txtCode.Text & " �������к�")
        group = oldGroup
      ElseIf (Not allowParent) And group.IsControlGroup Then
        MessageBox.Show(group.Code & "-" & group.Name & " �ա�ä�� �֧�������ö��������")
        group = oldGroup
      End If
      txtCode.Text = group.Code
      txtName.Text = group.Name
      If oldGroup.Id <> group.Id Then
        oldGroup = group
        Return True
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteSupplierGroup}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteSupplierGroup", New SqlParameter() {New SqlParameter("@spg_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.SupplierGroupIsReferencedCannotBeDeleted}")
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

