Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Supplier
    Inherits PersonEntityBase
    Implements IPJMUpdatable, IPrintableEntity, IHasGroup, IExportEntityDetail, INewPrintableEntity

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

    Private m_exportentity As ExportEntity
    Private Shared m_allMinData As DataTable
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
      'Me.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.Supplier).Account
      m_contactCollection = New SupplierContactCollection(Me)
            'm_SupplierLCICostLink = New SupplierLCICostLink
            Me.m_branchId = -1
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
                If dr.Table.Columns.Contains("spg_id") Then
                    If Not dr.IsNull("spg_id") Then
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

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_builkid") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_builkid") Then
                    .BuilkID = CStr(dr(aliasPrefix & Me.Prefix & "_builkid"))
                Else
                    .BuilkID = ""
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_branch") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_branch") Then
                    .m_branchId = CInt(dr(aliasPrefix & Me.Prefix & "_branch"))
                Else
                    .m_branchId = -1
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
        Public Shared ReadOnly Property AllMinData As DataTable
            Get
                If m_allMinData Is Nothing Then
                    Supplier.RefreshAllMinData()
                End If
                Return m_allMinData
            End Get
        End Property
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
        Public Property SupplierLCICostLink() As SupplierLCICostLink            Get                Return m_SupplierLCICostLink            End Get            Set(ByVal Value As SupplierLCICostLink)                m_SupplierLCICostLink = Value            End Set        End Property        Public Property CreditAmount() As Decimal            Get                Return m_creditAmount            End Get            Set(ByVal Value As Decimal)                OnPropertyChanged(Me, New PropertyChangedEventArgs("CreditAmount", m_creditAmount, Value))                m_creditAmount = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public Property CheckAmountOnHand() As Decimal            Get                Return m_checkAmountOnHand            End Get            Set(ByVal Value As Decimal)                OnPropertyChanged(Me, New PropertyChangedEventArgs("CheckAmountOnHand", m_checkAmountOnHand, Value))                m_checkAmountOnHand = Value            End Set        End Property        Public Property LastContactDate() As Date            Get                Return m_lastContactDate            End Get            Set(ByVal Value As Date)                OnPropertyChanged(Me, New PropertyChangedEventArgs("LastContactDate", m_lastContactDate, Value))                m_lastContactDate = Value            End Set        End Property        Public Property LastPayDate() As Date            Get                Return m_lastPayDate            End Get            Set(ByVal Value As Date)                OnPropertyChanged(Me, New PropertyChangedEventArgs("LastPayDate", m_lastPayDate, Value))                m_lastPayDate = Value            End Set        End Property        Public Property Coordinator() As Employee            Get                Return m_coordinator            End Get            Set(ByVal Value As Employee)                OnPropertyChanged(Me, New PropertyChangedEventArgs("Coordinator", m_coordinator, Value))                m_coordinator = Value            End Set        End Property        Public Property CreditPeriod() As Integer            Get                Return m_creditPeriod            End Get            Set(ByVal Value As Integer)                OnPropertyChanged(Me, New PropertyChangedEventArgs("CreditPeriod", m_creditPeriod, Value))                m_creditPeriod = Value            End Set        End Property        Public Property CreditPeriodFromTransport() As Integer            Get                Return m_creditPeriodFromTransport            End Get            Set(ByVal Value As Integer)                OnPropertyChanged(Me, New PropertyChangedEventArgs("CreditPeriodFromTransport", m_creditPeriodFromTransport, Value))                m_creditPeriodFromTransport = Value            End Set        End Property        Public Property Group() As SupplierGroup            Get                Return m_group            End Get            Set(ByVal Value As SupplierGroup)                OnPropertyChanged(Me, New PropertyChangedEventArgs("Group", m_group, Value))                m_group = Value            End Set        End Property        Public Property AuthorizeAmount() As Decimal            Get                Return m_authorizeAmount            End Get            Set(ByVal Value As Decimal)                OnPropertyChanged(Me, New PropertyChangedEventArgs("AuthorizeAmount", m_authorizeAmount, Value))                m_authorizeAmount = Value            End Set        End Property        Public Property BirthDate() As Date            Get                Return m_birthDate            End Get            Set(ByVal Value As Date)                OnPropertyChanged(Me, New PropertyChangedEventArgs("BirthDate", m_birthDate, Value))                m_birthDate = Value            End Set        End Property        Public Property CreditType() As CreditType            Get                Return m_creditType            End Get            Set(ByVal Value As CreditType)                OnPropertyChanged(Me, New PropertyChangedEventArgs("CreditType", m_creditType, Value))                m_creditType = Value            End Set        End Property        'Public Property ReceiveDay() As DayOfWeek        '    Get        '        Return m_receiveDay        '    End Get        '    Set(ByVal Value As DayOfWeek)        '        OnPropertyChanged(Me, New PropertyChangedEventArgs("ReceiveDay", m_receiveDay, Value))        '        m_receiveDay = Value        '    End Set        'End Property        Public Property ReceiveDays() As String            Get
                Return m_receiveDays
            End Get
            Set(ByVal Value As String)
                m_receiveDays = Value
            End Set
        End Property        Public Property ReceiveDates() As String            Get
                Return m_receiveDates
            End Get
            Set(ByVal Value As String)
                m_receiveDates = Value
            End Set
        End Property        'Public Property ReceiveDate() As Integer        '    Get        '        Return m_receiveDate        '    End Get        '    Set(ByVal Value As Integer)        '        OnPropertyChanged(Me, New PropertyChangedEventArgs("ReceiveDate", m_receiveDate, Value))        '        m_receiveDate = Value        '    End Set        'End Property        Public Property ReceiveWeeks() As String
            Get
                Return m_receiveWeeks
            End Get
            Set(ByVal Value As String)
                m_receiveWeeks = Value
            End Set
        End Property        Public Property BillrecDays() As String
            Get
                Return m_billrecDays
            End Get
            Set(ByVal Value As String)
                m_billrecDays = Value
            End Set
        End Property        Public Property BillRecDates() As String            Get
                Return m_billRecDates
            End Get
            Set(ByVal Value As String)
                m_billRecDates = Value
            End Set
        End Property        Public Property BillRecWeeks() As String            Get
                Return m_billRecWeeks
            End Get
            Set(ByVal Value As String)
                m_billRecWeeks = Value
            End Set
        End Property        Public Property invisible() As Boolean            Get
                Return Me.m_invisible
            End Get
            Set(ByVal Value As Boolean)
                Me.m_invisible = Value
            End Set
        End Property        Public Property NotGetItems() As Boolean            Get
                Return Me.m_notGetItems
            End Get
            Set(ByVal Value As Boolean)
                Me.m_notGetItems = Value
            End Set
        End Property        Public Overrides ReadOnly Property ClassName() As String
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
        Private m_builkid As String
        Public Property BuilkID() As String
            Get
                Return m_builkid
            End Get
            Set(ByVal value As String)
                m_builkid = value
            End Set
        End Property

        Private m_branchId As Integer
        Public Property BranchId() As Integer            Get                Return m_branchId            End Get            Set(ByVal Value As Integer)                m_branchId = Value            End Set        End Property

#End Region

#Region "Cache Memo"
        Public Shared Sub RefreshSupplierCollection(ByVal Key As Object, ByVal includeInvisible As Boolean, Optional ByVal ForceRefresh As Boolean = False)
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
                    If Not m_SupplierCollection.Contains(drh.GetValue(Of Integer)("supplier_id")) Then
                        m_SupplierCollection.Add(drh.GetValue(Of Integer)("supplier_id"), row)
                        m_SupplierCollection.Add(drh.GetValue(Of String)("supplier_code").ToLower.Trim, row)
                    End If
                Next
            Else
                If Not m_SupplierCollection.Contains(Key) Then
                    Dim dt As DataTable = RefreshSupplier(Key, includeInvisible)
                    For Each row As DataRow In dt.Rows
                        Dim drh As New DataRowHelper(row)
                        m_SupplierCollection.Add(drh.GetValue(Of Integer)("supplier_id"), row)
                        m_SupplierCollection.Add(drh.GetValue(Of String)("supplier_code").ToLower.Trim, row)
                    Next
                Else
                    Dim drow As DataRow = CType(m_SupplierCollection(Key), DataRow)
                    If Not Sync(drow) Or ForceRefresh Then
                        Dim dt As DataTable = RefreshSupplier(Key, includeInvisible)
                        For Each row As DataRow In dt.Rows
                            Dim drh As New DataRowHelper(row)
                            m_SupplierCollection(drh.GetValue(Of Integer)("supplier_id")) = row
                            m_SupplierCollection(drh.GetValue(Of String)("supplier_code").ToLower.Trim) = row
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
    Public Sub SetAccountFromSupplierGroup()

      Me.Account = m_group.Account
      If Me.Account Is Nothing Then
        Me.Account = New Account
      End If

    End Sub
    Public Shared Sub RefreshAllMinData()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
   , CommandType.StoredProcedure _
   , "GetAllSupplierMinDataCollection")
      If ds.Tables(0).Rows.Count > 0 Then
        m_allMinData = ds.Tables(0)
      End If
    End Sub
    Public Sub GetExportEntity()
      If m_exportentity Is Nothing OrElse m_exportentity.IsDirty = False Then
        m_exportentity = New ExportEntity(Me)
      End If
    End Sub
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
            paramArrayList.Add(New SqlParameter("@supplier_builkid", Me.BuilkID))
            paramArrayList.Add(New SqlParameter("@supplier_branch", Me.BranchId))
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
                                Dim ds As DataSet = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure _
                                   , "GetSupplierDupplicate" _
                                   , New SqlParameter("@supplier_branchId", Me.BranchId) _
                                   , New SqlParameter("@supplier_taxId", Me.TaxId) _
                                   , New SqlParameter("@supplier_Id", Me.Id) _
                                   )
                Dim dupcode As String
                If ds.Tables(0).Rows.Count > 0 Then
                  dupcode = CStr(ds.Tables(0).Rows(0)(0))
                End If
                                Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SupplierDupplicateTaxIdBranchId}"), New String() {Me.TaxId.ToString, Me.BranchId.ToString, dupcode})
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
          'If Me.Originated Then
          '  paramArrayList = New ArrayList
          '  paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
          '  Me.PrepareImageParams(paramArrayList)
          '  sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
          '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "Insert" & Me.TableName & "Image", sqlparams)
          'End If

                    trans.Commit()
                    RefreshSupplierCollection(Id, True, True)
          'Try
          '  RefreshInfoList()
          '  m_infolistNeedsRefreshing = True
          'Catch ex As Exception
          '  Throw New AfterCommitException("Error After Commit", ex)
          'End Try
          'Return New SaveErrorException(returnVal.Value.ToString)
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
          'Finally
          '  conn.Close()
        End Try

        '--Sub Save Block-- ============================================================
        Try
          Dim subsaveerror As SaveErrorException = SubSave(conn)
          If Not IsNumeric(subsaveerror.Message) Then
            Return New SaveErrorException(" Save Incomplete Please Save Again")
          End If
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
        'Try
        '  Dim subsaveerror2 As SaveErrorException = SubSave2(conn)
        '  If Not IsNumeric(subsaveerror2.Message) Then
        '    Return New SaveErrorException(" Save Incomplete Please Save Again")
        '  End If
        'Catch ex As Exception
        '  Return New SaveErrorException(ex.ToString)
        'End Try
        '--Sub Save Block-- ============================================================

        Return New SaveErrorException(returnVal.Value.ToString) 'Complete Save
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
    End Function
    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans As SqlTransaction = conn.BeginTransaction

      Try

        If Me.Originated Then
          Dim paramArrayList As New ArrayList
          'paramArrayList = New ArrayList
          Dim sqlparams() As SqlParameter
          sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
          Me.PrepareImageParams(paramArrayList)
          sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "Insert" & Me.TableName & "Image", sqlparams)
        End If

        RefreshInfoList()
        m_infolistNeedsRefreshing = True
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
    End Function
    Private Function SubSave2(ByVal conn As SqlConnection) As SaveErrorException
      If Me.ExportEntity Is Nothing Then
        Return New SaveErrorException("0")
      End If

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans2 As SqlTransaction = conn.BeginTransaction

      Try
        Dim saveerr As SaveErrorException = Me.ExportEntity.Save(conn, trans2)
        Me.ExportEntity = Nothing
        If Not IsNumeric(saveerr.Message) Then
          Return saveerr
        End If
      Catch ex As Exception
        trans2.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans2.Commit()
      Return New SaveErrorException("0")
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

    Public Property ExportEntity As ExportEntity Implements IExportEntityDetail.ExportEntity
      Get
        Return m_exportentity
      End Get
      Set(ByVal value As ExportEntity)
        m_exportentity = value
      End Set
    End Property

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AltName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Address", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CurrentAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Phone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Mobile", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Fax", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Email", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PersonType", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupCatgInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupCatgCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupCatgName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AccountInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AccountCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AccountName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Fund", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TaxID", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ID", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Contact", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

  End Class

  Public Class SupplierGroup
    Inherits TreeBaseEntity

#Region "Member"
    Private Shared m_allMinData As DataTable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.Supplier).Account
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
    Public Shared ReadOnly Property AllMinData As DataTable
      Get
        If m_allMinData Is Nothing Then
          SupplierGroup.RefreshAllMinData()
        End If
        Return m_allMinData
      End Get
    End Property
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
    Public Shared Sub RefreshAllMinData()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
   , CommandType.StoredProcedure _
   , "GetAllSupplierGroupMinDataCollection")
      If ds.Tables(0).Rows.Count > 0 Then
        m_allMinData = ds.Tables(0)
      End If
    End Sub
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
        paramArrayList.Add(New SqlParameter("@spg_acct", Me.ValidIdOrDBNull(Me.Account)))

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

  Public Class ExportEntity

#Region "Properties"
    Public Property EntityId As Integer
    Public Property EntityType As Integer

    Public Property Address As String
    Public Property BranchId As String
    Public Property BuildingName As String
    Public Property District As String
    Public Property FirstName As String
    Public Property Floor As String
    Public Property Id As String
    Public Property Idno As String
    Public Property LastName As String
    Public Property Moo As String
    Public Property Note As String
    Public Property PhoneNumber As String
    Public Property PostCode As String
    Public Property Province As String
    Public Property RegistrationNo As String
    Public Property RoomNumber As String
    Public Property Street As String
    Public Property SubStreet As String
    Public Property TamBon As String
    Public Property TaxIdNo As String
    Public Property TitleName As String
    'Public Property EntityType As String
    Public Property VillageName As String
    Public Property IsDirty As Boolean

    'Private Property OldDataset As DataSet

    Public Shared Property AutoCompleteOfTitleName As AutoCompleteStringCollection
    Public Shared Property AutoCompleteOfStreet As AutoCompleteStringCollection
    Public Shared Property AutoCompleteOfTambon As AutoCompleteStringCollection
    Public Shared Property AutoCompleteOfDistrict As AutoCompleteStringCollection
    Public Shared Property AutoCompleteOfProvince As AutoCompleteStringCollection
    Public Shared Property AutoCompleteOfPostCode As AutoCompleteStringCollection

#End Region
#Region "Construct"
    Public Sub New(ByVal entity As IExportEntityDetail)
      If CType(entity, ISimpleEntity).Id = 0 Then
        Return
      End If

      Me.EntityId = CType(entity, ISimpleEntity).Id
      Me.EntityType = CType(entity, ISimpleEntity).EntityId

      Me.IsDirty = False

      'Dim cnstring As String = CType(entity, SimpleBusinessEntityBase).RealConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure,
                                                   "GetExportEntity",
                                                   New SqlParameter("@entityId", Me.EntityId),
                                                   New SqlParameter("@entityType", Me.EntityType)
                                                   )
      If ds.Tables(0).Rows.Count = 0 Then
        If TypeOf entity Is Supplier Then
          Dim newSupplier As Supplier = CType(entity, Supplier)

          Me.FirstName = Mid(newSupplier.Name, 1, 160)
          Me.Idno = Mid(newSupplier.IdNo, 1, 13)
          Me.TaxIdNo = Mid(newSupplier.TaxId, 1, 10)
          Me.Province = Mid(newSupplier.Province, 1, 50)
          Me.PhoneNumber = Mid(newSupplier.Phone, 1, 30)
          Me.Note = Mid(newSupplier.Note, 1, 80)
        End If
        Return
      End If

      Me.Construct(ds.Tables(0).Rows(0))
      'Me.OldDataset = ds

    End Sub
    Private Sub Construct(ByVal dr As DataRow)
      Dim drh As New DataRowHelper(dr)

      Me.Address = drh.GetValue(Of String)("exportentity_address")
      Me.BranchId = drh.GetValue(Of String)("exportentity_branchid")
      Me.BuildingName = drh.GetValue(Of String)("exportentity_buildingname")
      Me.District = drh.GetValue(Of String)("exportentity_district")
      Me.FirstName = drh.GetValue(Of String)("exportentity_firstname")
      Me.Floor = drh.GetValue(Of String)("exportentity_floor")
      Me.Id = drh.GetValue(Of String)("exportentity_id")
      Me.Idno = drh.GetValue(Of String)("exportentity_idno")
      Me.LastName = drh.GetValue(Of String)("exportentity_lastname")
      Me.Moo = drh.GetValue(Of String)("exportentity_moo")
      Me.Note = drh.GetValue(Of String)("exportentity_note")
      Me.PhoneNumber = drh.GetValue(Of String)("exportentity_phonenumber")
      Me.PostCode = drh.GetValue(Of String)("exportentity_postcode")
      Me.Province = drh.GetValue(Of String)("exportentity_province")
      Me.RegistrationNo = drh.GetValue(Of String)("exportentity_registrationno")
      Me.RoomNumber = drh.GetValue(Of String)("exportentity_roomnumber")
      Me.Street = drh.GetValue(Of String)("exportentity_street")
      Me.SubStreet = drh.GetValue(Of String)("exportentity_substreet")
      Me.TamBon = drh.GetValue(Of String)("exportentity_tambon")
      Me.TaxIdNo = drh.GetValue(Of String)("exportentity_taxidno")
      Me.TitleName = drh.GetValue(Of String)("exportentity_titlename")
      'Me.EntityType = drh.GetValue(Of Integer)("exportentity_type")
      Me.VillageName = drh.GetValue(Of String)("exportentity_villagename")
    End Sub
#End Region
#Region "Method"
    Public Sub ReverseEntity()
      'Dim dr As DataRow = Me.OldDataset.Tables(0).Rows(0)
      'Me.Construct(dr)
    End Sub
    Public Function Save(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        SqlHelper.ExecuteNonQuery(conn,
                                  trans,
                                  CommandType.StoredProcedure,
                                  "InsertExportEntity",
                                  New SqlParameter("@exportentity_entityid", Me.EntityId),
                                  New SqlParameter("@exportentity_type", Me.EntityType),
                                  New SqlParameter("@exportentity_address", Me.Address),
                                  New SqlParameter("@exportentity_branchid", Me.BranchId),
                                  New SqlParameter("@exportentity_buildingname", Me.BuildingName),
                                  New SqlParameter("@exportentity_district", Me.District),
                                  New SqlParameter("@exportentity_firstname", Me.FirstName),
                                  New SqlParameter("@exportentity_floor", Me.Floor),
                                  New SqlParameter("@exportentity_idno", Me.Idno),
                                  New SqlParameter("@exportentity_lastname", Me.LastName),
                                  New SqlParameter("@exportentity_moo", Me.Moo),
                                  New SqlParameter("@exportentity_note", Me.Note),
                                  New SqlParameter("@exportentity_phonenumber", Me.PhoneNumber),
                                  New SqlParameter("@exportentity_postcode", Me.PostCode),
                                  New SqlParameter("@exportentity_province", Me.Province),
                                  New SqlParameter("@exportentity_registrationno", Me.RegistrationNo),
                                  New SqlParameter("@exportentity_roomnumber", Me.RoomNumber),
                                  New SqlParameter("@exportentity_street", Me.Street),
                                  New SqlParameter("@exportentity_substreet", Me.SubStreet),
                                  New SqlParameter("@exportentity_tambon", Me.TamBon),
                                  New SqlParameter("@exportentity_taxidno", Me.TaxIdNo),
                                  New SqlParameter("@exportentity_titlename", Me.TitleName),
                                  New SqlParameter("@exportentity_villagename", Me.VillageName)
                                )
      Catch ex As Exception
        Return New SaveErrorException(ex.Message & vbCrLf & ex.InnerException.ToString)
      End Try

      Return New SaveErrorException("0")
    End Function
    Public Shared Sub GetCompleteCode()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString,
                                                   CommandType.Text,
                                                  "select distinct exportentity_street From exportentity where len(isnull(exportentity_street,'')) > 0; " & _
                                                  "select distinct exportentity_titlename From exportentity where len(isnull(exportentity_titlename,'')) > 0; " & _
                                                  "select distinct exportentity_district From exportentity where len(isnull(exportentity_district,'')) > 0; " & _
                                                  "select distinct exportentity_province From exportentity where len(isnull(exportentity_province,'')) > 0 union select province_name from province where len(isnull(province_name,'')) > 0; " & _
                                                  "select exportentity_postcode From exportentity where len(isnull(exportentity_postcode,'')) > 0; "
                                                   )

      AutoCompleteOfTitleName = New AutoCompleteStringCollection
      AutoCompleteOfStreet = New AutoCompleteStringCollection
      AutoCompleteOfTambon = New AutoCompleteStringCollection
      AutoCompleteOfDistrict = New AutoCompleteStringCollection
      AutoCompleteOfProvince = New AutoCompleteStringCollection
      AutoCompleteOfPostCode = New AutoCompleteStringCollection

      AutoCompleteOfTitleName.Add("นาย")
      AutoCompleteOfTitleName.Add("นาง")
      AutoCompleteOfTitleName.Add("นางสาว")

      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        AutoCompleteOfStreet.Add(drh.GetValue(Of String)("exportentity_street"))
      Next

      For Each row As DataRow In ds.Tables(1).Rows
        Dim drh As New DataRowHelper(row)
        AutoCompleteOfTambon.Add(drh.GetValue(Of String)("exportentity_titlename"))
      Next

      For Each row As DataRow In ds.Tables(2).Rows
        Dim drh As New DataRowHelper(row)
        AutoCompleteOfDistrict.Add(drh.GetValue(Of String)("exportentity_district"))
      Next

      For Each row As DataRow In ds.Tables(3).Rows
        Dim drh As New DataRowHelper(row)
        AutoCompleteOfProvince.Add(drh.GetValue(Of String)("exportentity_province"))
      Next

      For Each row As DataRow In ds.Tables(4).Rows
        Dim drh As New DataRowHelper(row)
        AutoCompleteOfPostCode.Add(drh.GetValue(Of String)("exportentity_postcode"))
      Next

    End Sub
#End Region

  End Class
End Namespace

