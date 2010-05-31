Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui.Components
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class CostCenterType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "cc_type"
      End Get
    End Property
#End Region

  End Class

  Public Class CostCenter
    Inherits TreeBaseEntity
    Implements ILocatable, IHasImage, IPrintableEntity, IHasIBillablePerson

#Region "Members"
    Private cc_address As String
    Private cc_phone As String
    Private cc_fax As String
    Private cc_image As Image
    Private cc_map As Image
    Private cc_mapPosition As Point
    Private cc_admin As Employee
    Private cc_manager As Employee
    Private cc_type As CostCenterType

    Private cc_wipAccount As Account
    Private cc_storeAccount As Account
    Private cc_expenseAccount As Account

    Private cc_cust As Customer

    Private cc_projectId As Integer
    Private cc_boqId As Integer
    Private cc_boqCode As String
    Private cc_projectCode As String
    Private cc_projectName As String

    Private cc_project As Project
    Private cc_boq As BOQ
    Private cc_ccuseraccesscol As CostCenterUserAccessCollection

    Private m_rootWBSId As Integer
    Private cc_isactive As Boolean

#End Region

#Region "Shared Ready CC"
    Private Shared m_AllCCMinData As Hashtable
    Public Shared ReadOnly Property AllCCMinData As Hashtable
      Get
        If m_AllCCMinData Is Nothing Then
          RefreshAllMinData()
        End If
        Return m_AllCCMinData
      End Get
    End Property
    Public Shared Sub RefreshAllMinData()
      CostCenter.m_AllCCMinData = New Hashtable
      Dim key As String = ""

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetCostcenterMinDataCollection" _
    , Nothing)
      If ds.Tables(0).Rows.Count >= 1 Then
        For Each row As DataRow In ds.Tables(0).Rows
          Dim drh As New DataRowHelper(row)
          key = CStr(drh.GetValue(Of Integer)("cc_id"))
          CostCenter.m_AllCCMinData(key) = row
        Next
      End If
    End Sub
    Public Shared Function GetCCMinData(ByVal Id As Integer) As CostCenter
      Dim key As String = Id.ToString
      Dim row As DataRow = CType(AllCCMinData(key), DataRow)
      Dim cc As New CostCenter
      cc = GetCostCenter(row, ViewType.PaySelection) 'teeraboon
      Return cc
    End Function

    Private Shared m_AllCCUsedData As Hashtable
    Public Shared ReadOnly Property AllCCUsedData(ByVal key As Integer) As Hashtable
      Get
        If m_AllCCUsedData Is Nothing Then
          m_AllCCUsedData = New Hashtable
        End If
        If Not m_AllCCUsedData.Contains(key) Then
          m_AllCCUsedData(key) = New CostCenter(key)
        End If
        Return m_AllCCUsedData
      End Get
    End Property
    
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As CostCenter)
      MyBase.New(myParent)
    End Sub
    Public Sub New(ByVal gid As Integer)
      MyBase.New(gid)
    End Sub
    Public Sub New(ByVal gcode As String)
      MyBase.New(gcode)
    End Sub
    Public Sub New(ByVal gcode As String, ByVal userId As Integer)
      If gcode Is Nothing OrElse gcode.Length = 0 Then
        Return
      End If

      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
      , CommandType.StoredProcedure _
      , Me.GetSprocName _
      , New SqlParameter("@" & Me.Prefix & "_code", gcode) _
      , New SqlParameter("@" & Me.Prefix & "_userright", IIf(userId = 0, Nothing, userId)) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Construct(ds.Tables(0).Rows(0), "")
      End If
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .cc_admin = New Employee
        .cc_manager = New Employee
        .cc_expenseAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherExpense).Account
        .cc_wipAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.Wip).Account
        .cc_storeAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.MatInStore).Account
        .cc_type = New CostCenterType(1)       'แผนก
        .cc_cust = New Customer

        .cc_project = New Project
        .cc_boq = New BOQ
        .cc_isactive = True
        'BudgetCollectionForCC = New BudgetCollectionForCC(Me)
        'CostCenterUserAccessCollection = New CostCenterUserAccessCollection(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "cc_isactive") AndAlso Not dr.IsNull(aliasPrefix & "cc_isactive") Then
          .cc_isactive = CBool(dr(aliasPrefix & "cc_isactive"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "cc_address") AndAlso Not dr.IsNull(aliasPrefix & "cc_address") Then
          .cc_address = CStr(dr(aliasPrefix & "cc_address"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "cc_fax") AndAlso Not dr.IsNull(aliasPrefix & "cc_fax") Then
          .cc_fax = CStr(dr(aliasPrefix & "cc_fax"))
        End If

        Dim x, y As Integer

        If dr.Table.Columns.Contains(aliasPrefix & "cc_mapPointX") AndAlso Not dr.IsNull(aliasPrefix & "cc_mapPointX") Then
          x = CInt(dr(aliasPrefix & "cc_mapPointX"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "cc_mapPointy") AndAlso Not dr.IsNull(aliasPrefix & "cc_mapPointX") Then
          y = CInt(dr(aliasPrefix & "cc_mapPointy"))
        End If

        .cc_mapPosition = New Point(x, y)

        If dr.Table.Columns.Contains(aliasPrefix & "cc_phone") AndAlso Not dr.IsNull(aliasPrefix & "cc_phone") Then
          .cc_phone = CStr(dr(aliasPrefix & "cc_phone"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "admin.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "admin.employee_id") Then
            .cc_admin = New Employee(dr, "admin.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "cc_admin") AndAlso Not dr.IsNull(aliasPrefix & "cc_admin") Then
            .cc_admin = New Employee(CInt(dr(aliasPrefix & "cc_admin")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "manager.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "manager.employee_id") Then
            .cc_manager = New Employee(dr, "manager.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "cc_manager") AndAlso Not dr.IsNull(aliasPrefix & "cc_manager") Then
            .cc_manager = New Employee(CInt(dr(aliasPrefix & "cc_manager")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "cc_type") AndAlso Not dr.IsNull("cc_type") Then
          .cc_type = New CostCenterType(CInt(dr(aliasPrefix & "cc_type")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "cc_project") AndAlso Not dr.IsNull(aliasPrefix & "cc_project") Then
          .cc_projectId = CInt(dr(aliasPrefix & "cc_project"))
        End If

        ' Load BOQ.
        If dr.Table.Columns.Contains(aliasPrefix & "cc_boq") AndAlso Not dr.IsNull(aliasPrefix & "cc_boq") Then
          .cc_boqId = CInt(dr(aliasPrefix & "cc_boq"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "BOQ.boq_code") AndAlso Not dr.IsNull(aliasPrefix & "BOQ.boq_code") Then
          .cc_boqCode = CStr(dr(aliasPrefix & "BOQ.boq_code"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "Project.project_code") AndAlso Not dr.IsNull(aliasPrefix & "Project.project_code") Then
          .cc_projectCode = CStr(dr(aliasPrefix & "Project.project_code"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "Project.project_name") AndAlso Not dr.IsNull(aliasPrefix & "Project.project_name") Then
          .cc_projectName = CStr(dr(aliasPrefix & "Project.project_name"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wbs_id") AndAlso Not dr.IsNull(aliasPrefix & "wbs_id") Then
          .m_rootWBSId = CInt(dr(aliasPrefix & "wbs_id"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "customer.cust_id") Then
          If Not dr.IsNull(aliasPrefix & "customer.cust_id") Then
            .cc_cust = New Customer(dr, "customer.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "cc_cust") AndAlso Not dr.IsNull(aliasPrefix & "cc_cust") Then
            .cc_cust = New Customer(CInt(dr(aliasPrefix & "cc_cust")))
          End If
        End If

        '*****************************************
        If dr.Table.Columns.Contains(aliasPrefix & "wipaccount.acct_id") Then
          If Not dr.IsNull(aliasPrefix & "wipaccount.acct_id") Then
            .cc_wipAccount = New Account(dr, "wipaccount.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "cc_wipacct") AndAlso Not dr.IsNull(aliasPrefix & "cc_wipacct") Then
            .cc_wipAccount = New Account(CInt(dr(aliasPrefix & "cc_wipacct")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "storeaccount.acct_id") Then
          If Not dr.IsNull(aliasPrefix & "storeaccount.acct_id") Then
            .cc_storeAccount = New Account(dr, aliasPrefix & "storeaccount.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "cc_storeacct") AndAlso Not dr.IsNull(aliasPrefix & "cc_storeacct") Then
            .cc_storeAccount = New Account(CInt(dr(aliasPrefix & "cc_storeacct")))
          End If
        End If

        If dr.Table.Columns.Contains("expenseAccount.acct_id") Then
          If Not dr.IsNull(aliasPrefix & "expenseaccount.acct_id") Then
            .cc_expenseAccount = New Account(dr, aliasPrefix & "expenseaccount.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "cc_expenseacct") AndAlso Not dr.IsNull(aliasPrefix & "cc_expenseacct") Then
            .cc_expenseAccount = New Account(CInt(dr(aliasPrefix & "cc_expenseacct")))
          End If
        End If

        '*****************************************

        CCUserRole.CreateFor(Me, False)

        'Hack เอาออกไปเพื่อความเร็ว ---> อย่าลืมโหลดใน View
        'Me.LoadImage()
      End With
      'BudgetCollectionForCC = New BudgetCollectionForCC(Me)
      'CostCenterUserAccessCollection = New CostCenterUserAccessCollection(Me)
    End Sub

    Public Sub LoadImage(ByVal reader As IDataReader)
      cc_image = Field.GetImage(reader, "cc_image")
      cc_map = Field.GetImage(reader, "cc_map")
    End Sub
    Public Sub LoadImage()
      If Not Me.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select cc_image,cc_map from costcenterimage where cc_id=" & Me.Id

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

#Region "Roles"
    Public Property Roles As List(Of CCUserRole) = New List(Of CCUserRole)
#End Region

#Region "Properties"
    Dim m_budgetCollectionForCC As BudgetCollectionForCC
    Property BudgetCollectionForCC As BudgetCollectionForCC
      Get
        If m_budgetCollectionForCC Is Nothing Then
          m_budgetCollectionForCC = New BudgetCollectionForCC(Me)
        End If
      End Get
      Set(ByVal value As BudgetCollectionForCC)
        m_budgetCollectionForCC = value
      End Set
    End Property
    Public Property RootWBSId() As Integer      Get
        Return m_rootWBSId
      End Get
      Set(ByVal Value As Integer)
        m_rootWBSId = Value
      End Set
    End Property
    Public Property Project() As Project      Get        If cc_project.Id <> cc_projectId Then          cc_project.Id = cc_projectId
        End If        Return cc_project      End Get      Set(ByVal Value As Project)        cc_project = Value        cc_projectId = cc_project.Id        cc_projectCode = cc_project.Code        cc_projectName = cc_project.Name      End Set    End Property    Public Property Boq() As BOQ      Get        If cc_boq Is Nothing OrElse cc_boq.Id <> cc_boqId Then          cc_boq = Boq.GetBOQ(cc_boqId)
        End If        Return cc_boq      End Get      Set(ByVal Value As BOQ)        cc_boq = Value        Me.cc_boqId = cc_boq.Id        Me.cc_boqCode = cc_boq.Code      End Set    End Property
    Public Property BoqId() As Integer      Get        Return cc_boqId      End Get      Set(ByVal Value As Integer)        cc_boqId = Value      End Set    End Property
    Public Property BoqCode() As String
      Get
        Return cc_boqCode
      End Get
      Set(ByVal Value As String)
        cc_boqCode = Value
      End Set
    End Property
    Public Property ProjectId() As Integer      Get        Return cc_projectId      End Get      Set(ByVal Value As Integer)        cc_projectId = Value      End Set    End Property
    Public Property ProjectCode() As String      Get        Return cc_projectCode      End Get      Set(ByVal Value As String)        cc_projectCode = Value      End Set    End Property
    Public Property ProjectName() As String      Get        Return cc_projectName      End Get      Set(ByVal Value As String)        cc_projectName = Value      End Set    End Property
    Public Property Customer() As Customer      Get        Return cc_cust      End Get      Set(ByVal Value As Customer)        cc_cust = Value      End Set    End Property    Public Property Type() As CostCenterType      Get        Return cc_type      End Get      Set(ByVal Value As CostCenterType)        cc_type = Value      End Set    End Property
    Public Property Address() As String      Get        Return cc_address      End Get      Set(ByVal Value As String)        cc_address = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Phone() As String      Get        Return cc_phone      End Get      Set(ByVal Value As String)        cc_phone = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Fax() As String      Get        Return cc_fax      End Get      Set(ByVal Value As String)        cc_fax = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Image() As Image Implements IHasImage.Image      Get        Return cc_image      End Get      Set(ByVal Value As Image)        cc_image = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Admin() As Employee      Get        Return cc_admin      End Get      Set(ByVal Value As Employee)        cc_admin = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Manager() As Employee      Get        Return cc_manager      End Get      Set(ByVal Value As Employee)        cc_manager = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Function GetUserByRoleCode(ByVal roleCode As String) As User
      For Each ur As CCUserRole In Me.Roles
        If ur.Role.Code.ToLower = roleCode.ToLower Then
          Return ur.User
        End If
      Next
      Return Nothing
    End Function
    Public Property WipAccount() As Account      Get        Return cc_wipAccount      End Get      Set(ByVal Value As Account)        cc_wipAccount = Value      End Set    End Property    Public Property StoreAccount() As Account      Get        Return cc_storeAccount      End Get      Set(ByVal Value As Account)        cc_storeAccount = Value      End Set    End Property    Public Property ExpenseAccount() As Account      Get        Return cc_expenseAccount      End Get      Set(ByVal Value As Account)        cc_expenseAccount = Value      End Set    End Property    Public Property CostCenterUserAccessCollection() As CostCenterUserAccessCollection      Get
        If cc_ccuseraccesscol Is Nothing Then
          cc_ccuseraccesscol = New CostCenterUserAccessCollection(Me)
        End If
        Return cc_ccuseraccesscol
      End Get
      Set(ByVal Value As CostCenterUserAccessCollection)
        cc_ccuseraccesscol = Value
      End Set
    End Property    Public ReadOnly Property HaveAccess(ByVal userid As Integer) As Boolean
      Get
        If Not Me.CostCenterUserAccessCollection Is Nothing Then
          Return Me.CostCenterUserAccessCollection.HaveAccess(Me.Id, userid)
        End If
        Return False
      End Get
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "CostCenter"
      End Get
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "CostCenter"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CostCenter.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.CostCenter"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.CostCenter"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CostCenter.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "cc"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
    Public Property IsActive() As Boolean 'โครงการยัง Active(ยังไม่เสร็จ) เพื่อช่วย Filter
      Get
        Return cc_isactive
      End Get
      Set(ByVal Value As Boolean)
        cc_isactive = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub PopulateDPIColl(ByVal dpiColl As DocPrintingItemCollection)
      Dim dpi As DocPrintingItem
      'CostCenterinfo
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterInfo"
      dpi.Value = Me.Code & ":" & Me.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterCode
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterName
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterName"
      dpi.Value = Me.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)
    End Sub
    Public Function GetMilestones() As MilestoneCollection
      Dim miColl As New MilestoneCollection(Me)
      miColl.PaymentApplication = GetPMA()
      Return miColl
    End Function
    Public Function GetPMA() As PaymentApplication
      If Not Me.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.SiteConnectionString _
      , CommandType.StoredProcedure _
      , "GetPaymentApplicationForCC" _
      , New SqlParameter("@" & Me.Prefix & "_id", Id) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Dim pma As New PaymentApplication(ds.Tables(0).Rows(0), "")
        Return pma
      End If
      Return Nothing
    End Function
    Public Function GetBOQ() As BOQ
      If Not Me.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
      , CommandType.StoredProcedure _
      , "GetBOQForCC" _
      , New SqlParameter("@" & Me.Prefix & "_id", Id) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Dim myBoq As New BOQ(ds.Tables(0).Rows(0), "")
        Return myBoq
      End If
      Return Nothing
    End Function
    Public Function GetProject() As Project
      If Not Me.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
      , CommandType.StoredProcedure _
      , "GetProjectForCC" _
      , New SqlParameter("@" & Me.Prefix & "_id", Id) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Dim prj As New Project(ds.Tables(0).Rows(0), "")
        Return prj
      End If
      Return Nothing
    End Function
    'Public Function GetCustomer() As Customer
    '    If Not Me.Originated Then
    '        Return Nothing
    '    End If
    '    Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
    '    , CommandType.StoredProcedure _
    '    , "GetCustomerForCC" _
    '    , New SqlParameter("@" & Me.Prefix & "_id", Id) _
    '    )
    '    If ds.Tables(0).Rows.Count = 1 Then
    '        Dim cust As New Customer(ds.Tables(0).Rows(0), "")
    '        Return cust
    '    End If
    '    Return Nothing
    'End Function
    Public Function CanChangeType(ByVal newType As Integer) As Boolean
      If (Me.Level = 0 And newType > 0) OrElse (Me.Level > 0 And newType = 0) Then
        Return False
      End If
      Return True
    End Function
    Public Overrides Function ToString() As String
      Return Me.Name
    End Function
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New CostCenter(parId)
      Else
        Me.Parent = Nothing
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New CostCenter
      par.Id = id
      par.Code = code
      par.Name = name
      Me.Parent = par
    End Sub
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
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
          paramArrayList.Add(New SqlParameter("@cc_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        'เช็คเรื่อง Type ของ CostCenter
        If Me.Type.Value <> 2 Then 'ถ้าไม่ใช่โครงการก่อสร้าง          Me.Customer = Nothing
          Me.BoqId = 0
        End If

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        paramArrayList.Add(New SqlParameter("@cc_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@cc_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@cc_expenseAcct", ValidIdOrDBNull(Me.ExpenseAccount)))
        paramArrayList.Add(New SqlParameter("@cc_wipAcct", ValidIdOrDBNull(Me.WipAccount)))
        paramArrayList.Add(New SqlParameter("@cc_storeAcct", ValidIdOrDBNull(Me.StoreAccount)))
        paramArrayList.Add(New SqlParameter("@cc_parid", parID))
        paramArrayList.Add(New SqlParameter("@cc_type", Me.Type.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_project", cc_projectId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cust", Me.ValidIdOrDBNull(Me.Customer)))
        paramArrayList.Add(New SqlParameter("@cc_boq", Me.BoqId))
        paramArrayList.Add(New SqlParameter("@cc_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@cc_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@cc_manager", ValidIdOrDBNull(Me.Manager)))
        paramArrayList.Add(New SqlParameter("@cc_address", Me.Address))
        paramArrayList.Add(New SqlParameter("@cc_mappointX", Me.cc_mapPosition.X))
        paramArrayList.Add(New SqlParameter("@cc_mappointY", Me.cc_mapPosition.Y))
        paramArrayList.Add(New SqlParameter("@cc_admin", ValidIdOrDBNull(Me.Admin)))
        paramArrayList.Add(New SqlParameter("@cc_phone", Me.Phone))
        paramArrayList.Add(New SqlParameter("@cc_fax", Me.Fax))
        paramArrayList.Add(New SqlParameter("@cc_isactive", Me.IsActive))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        trans = conn.BeginTransaction()
        Dim oldid As Integer = Me.Id
        Try
          Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)

          ' Update CostcenterImage ...
          If Me.Originated Then
            paramArrayList = New ArrayList
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
            Me.PrepareImageParams(paramArrayList)
            sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "Insert" & Me.TableName & "Image", sqlparams)

            If Not Me.cc_ccuseraccesscol Is Nothing AndAlso Me.cc_ccuseraccesscol.Count >= 0 Then
              SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, "delete from usercostcenter where usercc_cc=" & Me.Id)

              Me.cc_ccuseraccesscol.Save(Me, conn, trans)

              SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertUserCostCenterFromParentCC", New SqlParameter("@cc_id", Me.Id))
            End If
            If Not Me.BudgetCollectionForCC Is Nothing Then
              Me.BudgetCollectionForCC.Save()
            End If
            '--------------------------SAVING EXTENDERS---------------------
            For Each extender As Object In Me.Extenders
              If TypeOf extender Is IExtender Then
                Dim saveDetailError As SaveErrorException = CType(extender, IExtender).Save(conn, trans)
                If Not IsNumeric(saveDetailError.Message) Then
                  trans.Rollback()
                  ResetID(oldid)
                  Return saveDetailError
                Else
                  Select Case CInt(saveDetailError.Message)
                    Case -1, -2, -5
                      trans.Rollback()
                      ResetID(oldid)
                      Return saveDetailError
                    Case Else
                  End Select
                End If
              End If
            Next
            '--------------------------END SAVING EXTENDERS---------------------
          End If

          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid)
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
#End Region

#Region "ILocatable"
    Public Property Map() As System.Drawing.Image Implements ILocatable.Map
      Get
        Return cc_map
      End Get
      Set(ByVal Value As Image)
        cc_map = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property MapPosition() As System.Drawing.Point Implements ILocatable.MapPosition
      Get
        Return cc_mapPosition
      End Get
      Set(ByVal Value As Point)
        cc_mapPosition = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "Cost Center"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "Cost Center"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'CCCode
      dpi = New DocPrintingItem
      dpi.Mapping = "CCCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CCName
      dpi = New DocPrintingItem
      dpi.Mapping = "CCName"
      dpi.Value = Me.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PMCode
      dpi = New DocPrintingItem
      dpi.Mapping = "PMName"
      dpi.Value = Me.Manager.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PMName
      dpi = New DocPrintingItem
      dpi.Mapping = "PMCode"
      dpi.Value = Me.Manager.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AdminCode
      dpi = New DocPrintingItem
      dpi.Mapping = "AdminCode"
      dpi.Value = Me.Admin.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AdminName
      dpi = New DocPrintingItem
      dpi.Mapping = "AdminName"
      dpi.Value = Me.Admin.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Address
      dpi = New DocPrintingItem
      dpi.Mapping = "Address"
      dpi.Value = Me.Address
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Tel
      dpi = New DocPrintingItem
      dpi.Mapping = "Tel"
      dpi.Value = Me.Phone
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Fax
      dpi = New DocPrintingItem
      dpi.Mapping = "Fax"
      dpi.Value = Me.Fax
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CCParent
      dpi = New DocPrintingItem
      dpi.Mapping = "CCParent"
      dpi.Value = Me.Parent.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CCType
      dpi = New DocPrintingItem
      dpi.Mapping = "CCType"
      dpi.Value = Me.Type
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'RefToBOQ
      dpi = New DocPrintingItem
      dpi.Mapping = "RefToBOQ"
      dpi.Value = Me.Boq
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustCode
      dpi = New DocPrintingItem
      dpi.Mapping = "CustCode"
      dpi.Value = Me.Customer.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustName
      dpi = New DocPrintingItem
      dpi.Mapping = "CustName"
      dpi.Value = Me.Customer.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ExpenseAccount
      If Me.StoreAccount.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "ExpenseAccountInfo"
        dpi.Value = Me.ExpenseAccount.Code & ":" & Me.ExpenseAccount.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ExpenseAccountCode"
        dpi.Value = Me.ExpenseAccount.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ExpenseAccountName"
        dpi.Value = Me.ExpenseAccount.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'StoreAccount
      If Me.StoreAccount.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "StoreAccountInfo"
        dpi.Value = Me.StoreAccount.Code & ":" & Me.StoreAccount.Name
        dpi.DataType = "System.String"

        dpiColl.Add(dpi)
        dpi = New DocPrintingItem
        dpi.Mapping = "StoreAccountCode"
        dpi.Value = Me.StoreAccount.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "StoreAccountName"
        dpi.Value = Me.StoreAccount.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'WIPAccount
      If Me.WipAccount.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "WIPAccountInfo"
        dpi.Value = Me.WipAccount.Code & ":" & Me.WipAccount.Name
        dpi.DataType = "System.String"

        dpiColl.Add(dpi)
        dpi = New DocPrintingItem
        dpi.Mapping = "WIPAccountCode"
        dpi.Value = Me.WipAccount.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "WIPAccountName"
        dpi.Value = Me.WipAccount.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

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

#Region "Shared"
    Public Shared Function GetCostCenterWithoutRight(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldCC As CostCenter) As Boolean
      Dim cc As New CostCenter(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not cc.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        cc = oldCC
      ElseIf cc.IsControlGroup Then
        MessageBox.Show(cc.Code & "-" & cc.Name & " เป็นกลุ่มแม่")
        cc = oldCC
      End If
      txtCode.Text = cc.Code
      txtName.Text = cc.Name
      If oldCC.Id <> cc.Id Then
        oldCC = cc
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetCostCenter(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldCC As CostCenter, Optional ByVal userId As Integer = Nothing) As Boolean
      Dim cc As New CostCenter(txtCode.Text, userId)
      If txtCode.Text.Length <> 0 AndAlso Not cc.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบหรือไม่มีสิทธิ์เข้าถึง")
        cc = oldCC
      ElseIf cc.IsControlGroup Then
        MessageBox.Show(cc.Code & "-" & cc.Name & " เป็นกลุ่มแม่")
        cc = oldCC
      End If
      txtCode.Text = cc.Code
      txtName.Text = cc.Name
      If oldCC.Id <> cc.Id Then
        oldCC = cc
        Return True
      End If
      Return False
    End Function
    Public Shared Sub RefreshDefaultCC()
      Dim HQId As Integer = CInt(Configuration.GetConfig("HQCostCenter"))
      hqCC = New CostCenter(HQId)
    End Sub
    Private Shared hqCC As CostCenter
    Public Shared Function GetDefaultCostCenter(ByVal type As DefaultCostCenterType) As CostCenter
      If hqCC Is Nothing OrElse Not hqCC.Originated Then
        RefreshDefaultCC()
      End If
      Select Case type
        Case DefaultCostCenterType.HQ
          Return hqCC
        Case Else
      End Select
    End Function
    Public Enum DefaultCostCenterType
      HQ

    End Enum
    Public Shared Function GetCostCenter(ByVal dr As DataRow, ByVal viewType As ViewType) As CostCenter
      Dim cc As New CostCenter
      Select Case viewType
        Case viewType.JournalEntryItem
          SetMinimumCC(cc, dr)

      End Select
      Return cc
    End Function
    Public Shared Function GetCostCenter(ByVal id As Integer, ByVal viewType As ViewType) As CostCenter
      Dim cc As New CostCenter
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetMinCostCenter" _
        , New SqlParameter("@cc_id", id) _
          )
      If ds.Tables(0).Rows.Count > 0 Then
        Dim dr As DataRow = ds.Tables(0).Rows(0)

        Select Case viewType
          Case viewType.JournalEntryItem, viewType.Payment, viewType.PaySelection
            SetMinimumCC(cc, dr)
        End Select
      End If

      Return cc
    End Function
    Private Shared Sub SetMinimumCC(ByVal cc As CostCenter, ByVal dr As DataRow)
      Dim drh As New DataRowHelper(dr)
      cc.Id = drh.GetValue(Of Integer)("cc_id")
      cc.Code = drh.GetValue(Of String)("cc_code")
      cc.Name = drh.GetValue(Of String)("cc_name")
    End Sub
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteCC}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        '--------------------------Delete EXTENDERS---------------------
        For Each extender As Object In Me.Extenders
          If TypeOf extender Is IExtender Then
            Dim deleteDetailError As SaveErrorException = CType(extender, IExtender).Delete(conn, trans)
            If Not IsNumeric(deleteDetailError.Message) Then
              trans.Rollback()
              Return deleteDetailError
            Else
              Select Case CInt(deleteDetailError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Return deleteDetailError
                Case Else
              End Select
            End If
          End If
        Next
        '--------------------------Delete SAVING EXTENDERS---------------------

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteCostCenter", New SqlParameter() {New SqlParameter("@cc_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.CostCenterIsReferencedCannotBeDeleted}")
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

#Region "IHasIBillablePerson"
    Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
      Get
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Customer Then
          Me.Customer = CType(Value, Customer)
        End If
      End Set
    End Property
#End Region

    Public Overrides Sub PopulateTree(ByVal tvGroup As System.Windows.Forms.TreeView, ByVal ParamArray filters() As Filter)
      'Dim dt As DataTable = Me.GetTreeDataSet(filters).Tables(0)
      Dim ds As DataSet = Me.GetListDataSet("", filters)
      Dim dt As DataTable = ds.Tables(0)
      tvGroup.BeginUpdate()
      tvGroup.Nodes.Clear()
      'tvGroup.ForeColor = Color.Gray
      For Each row As DataRow In dt.Rows
        Dim NodeTag As String = CStr(row(Prefix & "_id")) & "|" & CStr(row(Prefix & "_type"))
        Dim NodeNme As String = CStr(row(Prefix & "_code")) & " - " & CStr(row(Prefix & "_name"))
        Dim parentNodes As TreeNodeCollection
        If IsDBNull(row(Prefix & "_parid")) OrElse CInt(row(Prefix & "_parid")) = CInt(row(Prefix & "_id")) Then
          parentNodes = tvGroup.Nodes
        Else
          Dim parnode As TreeNode = TreeViewHelper.SearchTagString(tvGroup, CInt(row(Prefix & "_parid")))
          If parnode Is Nothing Then
            parentNodes = tvGroup.Nodes
          Else
            parentNodes = parnode.Nodes
          End If
        End If
        Dim theNode As TreeNode = parentNodes.Add(NodeNme)
        Select Case CInt(row(Prefix & "_type"))
          Case 0
            theNode.ImageIndex = 0
            theNode.SelectedImageIndex = 0
          Case 1
            theNode.ImageIndex = 2
            theNode.SelectedImageIndex = 2
          Case 2
            theNode.ImageIndex = 4
            theNode.SelectedImageIndex = 4
        End Select

        theNode.Tag = NodeTag
      Next
      If ds.Tables.Count = 2 Then
        Dim dt2 As DataTable = ds.Tables(1)
        For Each row As DataRow In dt2.Rows
          Dim node As TreeNode = TreeViewHelper.SearchTagString(tvGroup, CInt(row(Prefix & "_id")))
          TreeViewHelper.HilightNode(node, Color.Blue)
        Next
      End If
      tvGroup.EndUpdate()
    End Sub

    Private Shared m_InfoList As Generic.List(Of Generic.KeyValuePair(Of String, String))
    Public Shared ReadOnly Property InfoList As Generic.List(Of Generic.KeyValuePair(Of String, String))
      Get
        If m_InfoList Is Nothing Then
          m_InfoList = New Generic.List(Of Generic.KeyValuePair(Of String, String))
          Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetCostCenterList" _
          )
          For Each row As DataRow In ds.Tables(0).Rows
            Dim deh As New DataRowHelper(row)
            Dim code As String = deh.GetValue(Of String)("cc_code")
            Dim name As String = deh.GetValue(Of String)("cc_name")
            Dim kv As New Generic.KeyValuePair(Of String, String)(code, name)
            m_InfoList.Add(kv)
          Next
        End If
        Return m_InfoList
      End Get
    End Property

    Public Function GetCashFlow(ByVal dataDate As Date) As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetCashFlow" _
      , New SqlParameter("@DataDate", ValidDateOrDBNull(dataDate)) _
      , New SqlParameter("@cc_id", Me.Id) _
      )
      Return ds
    End Function
  End Class

  Public Class BudgetForCC
    Property Id As Integer
    Property Code As String
    Property Type As String
    Property CostCenter As CostCenter
    ReadOnly Property IsControlled As Boolean
      Get
        Return CostCenter.BoqId = Me.Id
      End Get
    End Property

    Public Overrides Function ToString() As String
      Return Code & ":" & Type & ":" & IsControlled.ToString
    End Function
  End Class
  Public Enum ViewType
    JournalEntryItem
    GoodsReceiptItem
    Payment
    PaySelection
  End Enum
  Public Class BudgetCollectionForCC
    Property CostCenter As CostCenter
    Property Budgets As List(Of BudgetForCC)    
    Public Sub New(ByVal cc As CostCenter)
      Me.CostCenter = cc
      Budgets = New List(Of BudgetForCC)
      If cc.Originated Then
        Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
        , CommandType.StoredProcedure _
        , "GetBudgetCollectionForCC" _
        , New SqlParameter("@cc_id", Me.CostCenter.Id) _
        )
        For Each dr As DataRow In ds.Tables(0).Rows
          Dim deh As New DataRowHelper(dr)
          Dim bg As New BudgetForCC
          bg.CostCenter = Me.CostCenter
          bg.Id = deh.GetValue(Of Integer)("boq_id")
          bg.Code = deh.GetValue(Of String)("boq_code")
          bg.Type = deh.GetValue(Of String)("budget_type")
          Budgets.Add(bg)
        Next
      End If
    End Sub

    Public Function Save() As SaveErrorException
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "select * from budget where budget_cc=" & Me.CostCenter.Id


        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "CCBudget")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("CCBudget")
        Dim dtCCchild As DataTable
        For Each row As DataRow In dt.Rows
          row.Delete()
        Next

        Dim cclist As String = ""

        Dim i As Integer = 1
        For Each item As BudgetForCC In Me.Budgets
          Dim dr As DataRow = dt.NewRow
          dr("budget_boq") = item.Id
          dr("budget_cc") = Me.CostCenter.Id
          dr("budget_type") = item.Type
          dr("budget_linenumber") = i
          dt.Rows.Add(dr)
          i += 1
        Next

        ' First process deletes.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException("Error Saving:" & ex.ToString)
      End Try
    End Function
  End Class

End Namespace