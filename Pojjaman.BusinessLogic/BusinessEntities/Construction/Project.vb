Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class DateIntervalUnit
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "DateIntervalUnit"
            End Get
        End Property
#End Region

    End Class
    Public Class BOQType
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "BOQType"
            End Get
        End Property
#End Region

    End Class
    Public Class ProjectStatus
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "project_status"
            End Get
        End Property
#End Region

    End Class
    Public Class BiddingType
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "BiddingType"
            End Get
        End Property
#End Region

    End Class
    Public Class BidAS
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "BidAS"
            End Get
        End Property
#End Region

    End Class
    Public Class PenaltyType
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "PenaltyType"
            End Get
        End Property
#End Region

    End Class
    Public Class BidBondType
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "BidBondType"
            End Get
        End Property
#End Region

    End Class
    Public Class Project
        Inherits TreeBaseEntity
    Implements IHasIBillablePerson, IDuplicable

#Region "Members"
        Private m_jobnumber As String
        Private m_bidCode As String
        Private m_bidType As BiddingType
        Private m_bidAs As BidAs
        Private m_hasMaterialCost As Boolean
        Private m_hasLaborCost As Boolean
        Private m_hasEquipmentCost As Boolean
        Private m_bidBond As Decimal
        Private m_bidBondType As BidBondType
        Private m_bidStartDate As Date
        Private m_bidEndDate As Date
        Private m_bidOpenningDate As Date
        Private m_bidLocation As String
        Private m_customer As Customer
        Private m_contact As String
        Private m_engineer As Employee
        Private m_estimator As Employee
        Private m_projectedValue As Decimal
        Private m_address As String
        Private m_province As String
        Private m_completionDate As Date
        Private m_duration As Integer
        Private m_durationUnit As DateIntervalUnit
        Private m_penaltyRate As Decimal
        Private m_penaltyType As PenaltyType
        Private m_penaltyUnit As DateIntervalUnit
        Private m_note As String
        Private m_status As ProjectStatus
        Private m_addendumCode As String

        Private m_contract As Decimal
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal myParent As Project)
            MyBase.New(myParent)
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                .m_hasMaterialCost = True
                .m_hasLaborCost = True
                .m_hasEquipmentCost = True
                .m_bidAs = New BidAs(0)
                .m_bidType = New BiddingType(0)
                .m_customer = New Customer
                .m_engineer = New Employee
                .m_estimator = New Employee
                .m_penaltyType = New PenaltyType(0)
                .m_penaltyUnit = New DateIntervalUnit(0)
                .m_durationUnit = New DateIntervalUnit(0)
                .m_status = New ProjectStatus(1)
                .m_bidBondType = New BidBondType(0)

                Me.BidEndDate = Now.Date
                Me.BidStartDate = Now.Date
                Me.BidOpenningDate = Now.Date
                Me.CompletionDate = Now.Date

            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & "project_address") AndAlso Not dr.IsNull(aliasPrefix & "project_address") Then
                    .m_address = CStr(dr(aliasPrefix & "project_address"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_province") AndAlso Not dr.IsNull(aliasPrefix & "project_province") Then
                    .m_province = CStr(dr(aliasPrefix & "project_province"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_bidCode") AndAlso Not dr.IsNull(aliasPrefix & "project_bidCode") Then
                    .m_bidCode = CStr(dr(aliasPrefix & "project_bidCode"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_jobnumber") AndAlso Not dr.IsNull(aliasPrefix & "project_jobnumber") Then
                    .m_jobnumber = CStr(dr(aliasPrefix & "project_jobnumber"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_bidType") AndAlso Not dr.IsNull(aliasPrefix & "project_bidType") Then
                    .m_bidType = New BiddingType(CInt(dr(aliasPrefix & "project_bidType")))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_hasmaterialcost") AndAlso Not dr.IsNull(aliasPrefix & "project_hasmaterialcost") Then
                    .m_hasMaterialCost = CBool(dr(aliasPrefix & "project_hasmaterialcost"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_haslaborcost") AndAlso Not dr.IsNull(aliasPrefix & "project_haslaborcost") Then
                    .m_hasLaborCost = CBool(dr(aliasPrefix & "project_haslaborcost"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_hasEquipmentCost") AndAlso Not dr.IsNull(aliasPrefix & "project_hasEquipmentCost") Then
                    .m_hasEquipmentCost = CBool(dr(aliasPrefix & "project_hasEquipmentCost"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_bidAs") AndAlso Not dr.IsNull(aliasPrefix & "project_bidAs") Then
                    .m_bidAs = New BidAs(CInt(dr(aliasPrefix & "project_bidAs")))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_bidBond") AndAlso Not dr.IsNull(aliasPrefix & "project_bidBond") Then
                    .m_bidBond = CDec(dr(aliasPrefix & "project_bidBond"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_bidStartDate") AndAlso Not dr.IsNull(aliasPrefix & "project_bidStartDate") Then
                    .m_bidStartDate = CDate(dr(aliasPrefix & "project_bidStartDate"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_bidEndDate") AndAlso Not dr.IsNull(aliasPrefix & "project_bidEndDate") Then
                    .m_bidEndDate = CDate(dr(aliasPrefix & "project_bidEndDate"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_bidOpenningDate") AndAlso Not dr.IsNull(aliasPrefix & "project_bidOpenningDate") Then
                    .m_bidOpenningDate = CDate(dr(aliasPrefix & "project_bidOpenningDate"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_bidLocation") AndAlso Not dr.IsNull(aliasPrefix & "project_bidLocation") Then
                    .m_bidLocation = CStr(dr(aliasPrefix & "project_bidLocation"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "cust_id") Then
                    If Not dr.IsNull(aliasPrefix & "cust_id") Then
                        .m_customer = New Customer(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "project_cust") AndAlso Not dr.IsNull(aliasPrefix & "project_cust") Then
                        .m_customer = New Customer(CInt(dr(aliasPrefix & "project_cust")))
                    End If
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "project_contact") AndAlso Not dr.IsNull(aliasPrefix & "project_contact") Then
                    .m_contact = CStr(dr(aliasPrefix & "project_contact"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "engineer.employee_id") Then
                    If Not dr.IsNull(aliasPrefix & "engineer.employee_id") Then
                        .m_engineer = New Employee(dr, "engineer.")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "project_engineer") AndAlso Not dr.IsNull(aliasPrefix & "project_engineer") Then
                        .m_engineer = New Employee(CInt(dr(aliasPrefix & "project_engineer")))
                    End If
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "estimator.employee_id") Then
                    If Not dr.IsNull(aliasPrefix & "estimator.employee_id") Then
                        .m_estimator = New Employee(dr, "estimator.")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "project_estimator") AndAlso Not dr.IsNull(aliasPrefix & "project_estimator") Then
                        .m_estimator = New Employee(CInt(dr(aliasPrefix & "project_estimator")))
                    End If
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_projectedValue") AndAlso Not dr.IsNull(aliasPrefix & "project_projectedValue") Then
                    .m_projectedValue = CDec(dr(aliasPrefix & "project_projectedValue"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_completionDate") AndAlso Not dr.IsNull(aliasPrefix & "project_completionDate") Then
                    .m_completionDate = CDate(dr(aliasPrefix & "project_completionDate"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_duration") AndAlso Not dr.IsNull(aliasPrefix & "project_duration") Then
                    .m_duration = CInt(dr(aliasPrefix & "project_duration"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_durationUnit") AndAlso Not dr.IsNull(aliasPrefix & "project_durationUnit") Then
                    .m_durationUnit = New DateIntervalUnit(CInt(dr(aliasPrefix & "project_durationUnit")))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_penaltyRate") AndAlso Not dr.IsNull(aliasPrefix & "project_penaltyRate") Then
                    .m_penaltyRate = CDec(dr(aliasPrefix & "project_penaltyRate"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_penaltyType") AndAlso Not dr.IsNull(aliasPrefix & "project_penaltyType") Then
                    .m_penaltyType = New PenaltyType(CInt(dr(aliasPrefix & "project_penaltyType")))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_penaltyUnit") AndAlso Not dr.IsNull(aliasPrefix & "project_penaltyUnit") Then
                    .m_penaltyUnit = New DateIntervalUnit(CInt(dr(aliasPrefix & "project_penaltyUnit")))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_bidBondType") AndAlso Not dr.IsNull(aliasPrefix & "project_bidBondType") Then
                    .m_bidBondType = New BidBondType(CInt(dr(aliasPrefix & "project_bidBondType")))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_note") AndAlso Not dr.IsNull(aliasPrefix & "project_note") Then
                    .m_note = CStr(dr(aliasPrefix & "project_note"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_status") AndAlso Not dr.IsNull(aliasPrefix & "project_status") Then
                    .m_status = New ProjectStatus(CInt(dr(aliasPrefix & "project_status")))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "project_addendumCode") AndAlso Not dr.IsNull(aliasPrefix & "project_addendumCode") Then
                    .m_addendumCode = CStr(dr(aliasPrefix & "project_addendumCode"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "project_contract") AndAlso Not dr.IsNull(aliasPrefix & "project_contract") Then
                    .m_contract = CDec(dr(aliasPrefix & "project_contract"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Jobnumber() As String            Get                Return m_jobnumber            End Get            Set(ByVal Value As String)                m_jobnumber = Value            End Set        End Property
        Public Property BidCode() As String            Get                Return m_bidCode            End Get            Set(ByVal Value As String)                m_bidCode = Value            End Set        End Property        Public Property BidType() As BiddingType            Get                Return m_bidType            End Get            Set(ByVal Value As BiddingType)                m_bidType = Value            End Set        End Property        Public Property HasMaterialCost() As Boolean            Get                Return m_hasMaterialCost            End Get            Set(ByVal Value As Boolean)                m_hasMaterialCost = Value            End Set        End Property        Public Property HasLaborCost() As Boolean            Get                Return m_hasLaborCost            End Get            Set(ByVal Value As Boolean)                m_hasLaborCost = Value            End Set        End Property        Public Property HasEquipmentCost() As Boolean            Get                Return m_hasEquipmentCost            End Get            Set(ByVal Value As Boolean)                m_hasEquipmentCost = Value            End Set        End Property        Public Property Contract() As Decimal
            Get
                Return m_contract
            End Get
            Set(ByVal Value As Decimal)
                m_contract = Value
            End Set
        End Property
        Public Property BidAs() As BidAs            Get                Return m_bidAs            End Get            Set(ByVal Value As BidAs)                m_bidAs = Value            End Set        End Property        Public Property BidBond() As Decimal            Get                Return m_bidBond            End Get            Set(ByVal Value As Decimal)                m_bidBond = Value            End Set        End Property        Public Property BidBondType() As BidBondType            Get                Return m_bidBondType            End Get            Set(ByVal Value As BidBondType)                m_bidBondType = Value            End Set        End Property        Public Property BidStartDate() As Date            Get                Return m_bidStartDate            End Get            Set(ByVal Value As Date)                m_bidStartDate = Value            End Set        End Property        Public Property BidEndDate() As Date            Get                Return m_bidEndDate            End Get            Set(ByVal Value As Date)                m_bidEndDate = Value            End Set        End Property        Public Property BidOpenningDate() As Date            Get                Return m_bidOpenningDate            End Get            Set(ByVal Value As Date)                m_bidOpenningDate = Value            End Set        End Property        Public Property BidLocation() As String            Get                Return m_bidLocation            End Get            Set(ByVal Value As String)                m_bidLocation = Value            End Set        End Property        Public Property Customer() As Customer            Get                Return m_customer            End Get            Set(ByVal Value As Customer)                m_customer = Value            End Set        End Property        Public Property Contact() As String            Get                Return m_contact            End Get            Set(ByVal Value As String)                m_contact = Value            End Set        End Property        Public Property Engineer() As Employee            Get                Return m_engineer            End Get            Set(ByVal Value As Employee)                m_engineer = Value            End Set        End Property        Public Property Estimator() As Employee            Get                Return m_estimator            End Get            Set(ByVal Value As Employee)                m_estimator = Value            End Set        End Property        Public Property ProjectedValue() As Decimal            Get                Return m_projectedValue            End Get            Set(ByVal Value As Decimal)                m_projectedValue = Value            End Set        End Property        Public Property Address() As String            Get                Return m_address            End Get            Set(ByVal Value As String)                m_address = Value            End Set        End Property        Public Property Province() As String            Get                Return m_province            End Get            Set(ByVal Value As String)                m_province = Value            End Set        End Property        Public Property CompletionDate() As Date            Get                Return m_completionDate            End Get            Set(ByVal Value As Date)                m_completionDate = Value            End Set        End Property        Public Property Duration() As Integer            Get                Return m_duration            End Get            Set(ByVal Value As Integer)                m_duration = Value            End Set        End Property        Public Property DurationUnit() As DateIntervalUnit            Get                Return m_durationUnit            End Get            Set(ByVal Value As DateIntervalUnit)                m_durationUnit = Value            End Set        End Property        Public Property PenaltyRate() As Decimal            Get                Return m_penaltyRate            End Get            Set(ByVal Value As Decimal)                m_penaltyRate = Value            End Set        End Property        Public Property PenaltyType() As PenaltyType            Get                Return m_penaltyType            End Get            Set(ByVal Value As PenaltyType)                m_penaltyType = Value            End Set        End Property        Public Property PenaltyUnit() As DateIntervalUnit            Get                Return m_penaltyUnit            End Get            Set(ByVal Value As DateIntervalUnit)                m_penaltyUnit = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public Overrides Property Status() As CodeDescription            Get                Return m_status            End Get            Set(ByVal Value As CodeDescription)                m_status = CType(Value, ProjectStatus)            End Set        End Property        Public Property AddendumCode() As String            Get                Return m_addendumCode            End Get            Set(ByVal Value As String)                m_addendumCode = Value            End Set        End Property        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Project"
            End Get
        End Property
        Public Overrides ReadOnly Property CodonName() As String
            Get
                Return "Project"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "project"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Project.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Project"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Project"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Project.ListLabel}"
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overrides Function ToString() As String
            Return Me.Name
        End Function
        Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
            If parId <> Id Then
                Me.Parent = New Project(parId)
            Else
                Me.Parent = Nothing
            End If
        End Sub
        Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
            Dim par As New Project
            par.Id = id
            par.Code = code
            par.Name = name
            Me.Parent = par
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                If Not Me.HasEquipmentCost AndAlso _
                Not Me.HasLaborCost AndAlso _
                Not Me.HasMaterialCost Then
                    Return New SaveErrorException("${res:Global.Error.ProjectMustHaveAtLeastOneCostType}")
                End If
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
                    paramArrayList.Add(New SqlParameter("@project_id", Me.Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)
                Me.Status.Value = 2

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_jobnumber", Me.Jobnumber))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_parid", parID))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_level", Me.Level))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_path", Me.Path))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bidcode", Me.BidCode))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bidType", Me.BidType.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_hasMaterialCost", Me.HasMaterialCost))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_hasLaborCost", Me.HasLaborCost))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_hasEquipmentCost", Me.HasEquipmentCost))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bidAs", Me.BidAs.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bidBond", Me.BidBond))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bidBondType", Me.BidBondType.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bidStartDate", Me.ValidDateOrDBNull(Me.BidStartDate)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bidEndDate", Me.ValidDateOrDBNull(Me.BidEndDate)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bidOpenningDate", Me.ValidDateOrDBNull(Me.BidOpenningDate)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bidLocation", Me.BidLocation))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cust", Me.ValidIdOrDBNull(Me.Customer)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_contact", Me.Contact))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_engineer", Me.ValidIdOrDBNull(Me.Engineer)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_estimator", Me.ValidIdOrDBNull(Me.Estimator)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_projectedValue", Me.ProjectedValue))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_address", Me.Address))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_province", Me.Province))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_completiondate", Me.ValidDateOrDBNull(Me.CompletionDate)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_duration", Me.Duration))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_durationUnit", Me.DurationUnit.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_penaltyRate", Me.PenaltyRate))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_penaltyType", Me.PenaltyType.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_penaltyUnit", Me.PenaltyUnit.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_addendumCode", Me.AddendumCode))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_contract", Me.Contract))

                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(Me.ConnectionString)
                conn.Open()
                trans = conn.BeginTransaction()
                Try
                    Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                    trans.Commit()
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Return New SaveErrorException(ex.ToString)
                Finally
                    conn.Close()
                End Try
            End With
        End Function
#End Region

#Region "Shared"
        Public Shared Function GetProject(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldPrj As Project) As Boolean
            Dim prj As New Project(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not prj.Originated Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                prj = oldPrj
            End If
            txtCode.Text = prj.Code
            txtName.Text = prj.Name
            If oldPrj Is Nothing OrElse oldPrj.Id <> prj.Id Then
                oldPrj = prj
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteProject}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteProject", New SqlParameter() {New SqlParameter("@project_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.ProjectIsReferencedCannotBeDeleted}")
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

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      'เวลา Copy ให้เอา CustomNote จากอันปัจจุบันมาเก็บไว้ก่อน

      Me.Status.Value = -1
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Code = "Copy of " & Me.Code
      Me.Canceled = False
      Me.CancelPerson = New User
      Me.ClearReference()
      
      Return Me
    End Function
#End Region
  End Class

End Namespace

