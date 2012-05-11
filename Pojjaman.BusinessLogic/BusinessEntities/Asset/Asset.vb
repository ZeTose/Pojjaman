Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AssetStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "asset_status"
      End Get
    End Property
#End Region

  End Class

  Public Class AssetCalcType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "asset_calctype"
      End Get
    End Property
#End Region

  End Class

  Public Class AssetType
    Inherits TreeBaseEntity

#Region "Members"
    Private m_unit As Unit
    Private m_fairprice As Decimal

    Private m_account As Account
    Private m_depreopeningacct As Account
    Private m_depreaccount As Account

    Private m_rentalrate As Decimal

    Private m_canBeRented As Boolean
    Private m_depreAble As Boolean
    Private Shared m_assetTypeSet As DataTable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As AssetType)
      MyBase.New(myParent)
      If myParent.Account Is Nothing Then
        myParent = New AssetType(myParent.Id)
      End If
      Me.Account = myParent.Account
      Me.DepreAccount = myParent.DepreAccount
      Me.DepreOpeningAccount = myParent.DepreOpeningAccount
      Me.Unit = myParent.Unit
      Me.DepreAble = myParent.DepreAble
      Me.CanBeRented = myParent.CanBeRented
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
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_unit = New Unit
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") Then
          If Not dr.IsNull(aliasPrefix & "unit_id") Then
            .m_unit = New Unit(dr, aliasPrefix)
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_unit")))
          End If
        End If

        ' Asset Account.
        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") Then
          If Not dr.IsNull(aliasPrefix & "acct_id") Then
            .m_account = New Account(dr, aliasPrefix)
          End If
        ElseIf dr.Table.Columns.Contains("AssetAccount.acct_id") Then  ' Hack :
          If Not dr.IsNull("AssetAccount.acct_id") Then
            .m_account = New Account(dr, "AssetAccount.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_acct") Then
            .m_account = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_acct")))
          End If
        End If
        ' DepreopeningAccount
        If dr.Table.Columns.Contains("DepreopeningAccount.acct_id") Then ' Hack
          If Not dr.IsNull("DepreopeningAccount.acct_id") Then
            .m_depreopeningacct = New Account(dr, "DepreopeningAccount.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_depreopeningacct") Then
            .m_depreopeningacct = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_depreopeningacct")))
          End If
        End If
        ' DepreAccount
        If dr.Table.Columns.Contains("DepreAccount.acct_id") Then  ' Hack
          If Not dr.IsNull("DepreAccount.acct_id") Then
            .m_depreaccount = New Account(dr, "DepreAccount.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_depreacct") Then
            .m_depreaccount = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_depreacct")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_rentalrate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_rentalrate") Then
          .m_rentalrate = CDec(dr(aliasPrefix & Me.Prefix & "_rentalrate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fairprice") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fairprice") Then
          .m_fairprice = CDec(dr(aliasPrefix & Me.Prefix & "_fairprice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_canberented") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_canberented") Then
          .m_canBeRented = CBool(dr(aliasPrefix & Me.Prefix & "_canberented"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_depreable") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_depreable") Then
          .m_depreAble = CBool(dr(aliasPrefix & Me.Prefix & "_depreable"))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Overrides Property Parent() As TreeBaseEntity
      Get
        Return MyBase.Parent
      End Get
      Set(ByVal Value As TreeBaseEntity)
        Dim myParent As AssetType = CType(Value, AssetType)
        If myParent.Account Is Nothing Then
          myParent = New AssetType(myParent.Id)
        End If
        Me.Account = myParent.Account
        Me.DepreAccount = myParent.DepreAccount
        Me.DepreOpeningAccount = myParent.DepreOpeningAccount
        Me.Unit = myParent.Unit
        Me.DepreAble = myParent.DepreAble
        Me.CanBeRented = myParent.CanBeRented
        MyBase.Parent = Value
      End Set
    End Property
    Public Property Unit() As Unit
      Get
        If m_unit Is Nothing Then
          m_unit = New Unit
        End If
        Return m_unit
      End Get
      Set(ByVal Value As Unit)
        m_unit = Value
      End Set
    End Property
    Public Property CanBeRented() As Boolean
      Get
        Return m_canBeRented
      End Get
      Set(ByVal Value As Boolean)
        m_canBeRented = Value
      End Set
    End Property
    Public Property DepreAble() As Boolean
      Get
        Return m_depreAble
      End Get
      Set(ByVal Value As Boolean)
        m_depreAble = Value
      End Set
    End Property
    Public Property Account() As Account
      Get
        If m_account Is Nothing Then
          m_account = New Account
        End If
        Return m_account
      End Get
      Set(ByVal Value As Account)
        m_account = Value
      End Set
    End Property
    Public Property DepreOpeningAccount() As Account
      Get
        If m_depreopeningacct Is Nothing Then
          m_depreopeningacct = New Account
        End If
        Return m_depreopeningacct
      End Get
      Set(ByVal Value As Account)
        m_depreopeningacct = Value
      End Set
    End Property
    Public Property DepreAccount() As Account
      Get
        If m_depreaccount Is Nothing Then
          m_depreaccount = New Account
        End If
        Return m_depreaccount
      End Get
      Set(ByVal Value As Account)
        m_depreaccount = Value
      End Set
    End Property
    Public Property RentalRate() As Decimal
      Get
        Return m_rentalrate
      End Get
      Set(ByVal Value As Decimal)
        m_rentalrate = Value
      End Set
    End Property
    Public Property FairPrice() As Decimal
      Get
        Return m_fairprice
      End Get
      Set(ByVal Value As Decimal)
        m_fairprice = Value
      End Set
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "assettype"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AssetType"
      End Get
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "AssetType"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetType.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AssetType"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AssetType"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetType.ListLabel}"
      End Get
    End Property
#End Region

#Region "Methods"
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New AssetType(parId)
      Else
        Me.Parent = Nothing
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New AssetType
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
          paramArrayList.Add(New SqlParameter("@assettype_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@assettype_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@assettype_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@assettype_altname", Me.AlternateName))
        paramArrayList.Add(New SqlParameter("@assettype_parid", parID))
        paramArrayList.Add(New SqlParameter("@assettype_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@assettype_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@assettype_unit", IIf(Me.Unit.Originated, Me.Unit.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@assettype_control", Me.IsControlGroup))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acct", Me.ValidIdOrDBNull(Me.Account)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_depreopeningacct", Me.ValidIdOrDBNull(Me.DepreOpeningAccount)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_depreacct", Me.ValidIdOrDBNull(Me.DepreAccount)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fairprice", Me.FairPrice))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_rentalrate", Me.RentalRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_canberented", Me.CanBeRented))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_depreable", Me.DepreAble))

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
    Public Shared Function GetAssetType(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldType As AssetType) As Boolean
      Dim myType As New AssetType(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not myType.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        myType = oldType
        'ElseIf myType.IsControlGroup Then
        '    MessageBox.Show(myType.Code & "-" & myType.Name & " เป็นกลุ่มแม่")
        '    myType = oldType
      End If
      txtCode.Text = myType.Code
      txtName.Text = myType.Name
      If oldType.Id <> myType.Id Then
        oldType = myType
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAssetType}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAssetType", New SqlParameter() {New SqlParameter("@assettype_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AssetTypeIsReferencedCannotBeDeleted}")
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

    Public Shared Sub RefreshAllMinData()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetAssetTypeMinDataCollection" _
    , Nothing)
      If ds.Tables(0).Rows.Count >= 1 Then
        m_assetTypeSet = New DataTable
        m_assetTypeSet = ds.Tables(0)
      End If
    End Sub

    Shared Function GetAssetTypeSet() As DataTable
      If m_assetTypeSet Is Nothing Then
        AssetType.RefreshAllMinData()
      End If
      Return m_assetTypeSet
    End Function

  End Class

  ' สินทรัพย์
  Public Class Asset
    Inherits SimpleBusinessEntityBase
    Implements IHasImage, IHasRentalRate, IPrintableEntity, IHasGroup, IHasToCostCenter, IEqtItem, INewPrintableEntity

#Region "Members"
    Private m_refsequence As Integer
    Private m_name As String
    Private m_detail As String
    Private m_unit As Unit

    Private m_account As Account
    Private m_depreopeningacct As Account
    Private m_depreaccount As Account
    Private m_placcount As Account

    Private m_type As AssetType

    Private m_location As String
    Private m_image As Image
    Private m_buyDate As Date

    Private m_buyPrice As Decimal
    Private m_buyDocCode As String
    Private m_buyDocDate As Date
    Private m_buyFrom As String

    Private m_transferDate As Date

    Private m_startCalcDate As Date
    Private m_startCalcAmt As Decimal

    Private m_lastDepreDate As Date

    Private m_calcType As AssetCalcType
    Private m_age As Integer

    Private m_balance As Decimal

    Private m_rentalrate As Decimal
    Private m_dateintervalunit As DateIntervalUnit

    Private m_salvage As Decimal
    Private m_startBalance As Decimal

    Private m_saleDate As Date
    Private m_salePrice As Decimal
    Private m_balanceAtSaleDate As Decimal
    Private m_saleDocCode As String
    Private m_saleDocDate As Date

    Private m_buyer As String
    Private m_InsuranceCode As String

    Private m_saftyCode As String
    Private m_saftyCompany As String

    Private m_insurancePremium As Decimal
    Private m_insuranceAge As Integer
    Private m_insuranceStartDate As Date
    Private m_InsuranceEndDate As Date

    Private m_note As String

    Private m_depreopening As Decimal
    Private m_firstYearRate As Decimal

    Private m_cc As CostCenter
    Private m_project As Project
    Private m_lci As LCIItem
    Private m_status As AssetStatus

    Private m_itemTable As TreeTable
    Private m_VitemTable As TreeTable

    Private m_Deprebase As Decimal
    Private m_writeoffamt As Decimal
    Private m_writeoffaccdepre As Decimal
    Private m_eqt As EquipmentTool

    Private m_depreamnt As Decimal
    Private m_assetremainvalue As Decimal

    Private Shared m_assetSet As DataTable

#End Region

#Region "Constructors"
    Public Sub New(ByVal dr As DataRow)
      'Constructor ที่สร้าง Asset จากการเลือกของที่ซื้อ
      With Me
        If Not dr.IsNull("stocki_itemname") Then
          .m_name = CStr(dr("stocki_itemname"))
        End If
        If Not dr.IsNull("stocki_unit") Then
          .m_unit = New Unit(CInt(dr("stocki_unit")))
        End If
        If Not dr.IsNull("stocki_acct") Then
          .m_account = New Account(CInt(dr("stocki_acct")))
        End If
        If Not dr.IsNull("stocki_sequence") Then
          .m_refsequence = CInt(dr("stocki_sequence"))
        End If

        'If dr.Table.Columns.Contains("depreopening.acct_id") Then
        '    If Not dr.IsNull("depreopening.acct_id") Then
        '        .m_depreopeningacct = New Account(dr, "depreopening.")
        '    End If
        'Else
        '    If Not dr.IsNull("stocki_depreopeningacct") Then
        '        .m_depreopeningacct = New Account(CInt(dr("stocki_depreopeningacct")))
        '    End If
        'End If

        'If dr.Table.Columns.Contains("depre.acct_id") Then
        '    If Not dr.IsNull("depre.acct_id") Then
        '        .m_depreaccount = New Account(dr, "depre.")
        '    End If
        'Else
        '    If Not dr.IsNull("stocki_depreacct") Then
        '        .m_depreaccount = New Account(CInt(dr("stocki_depreacct")))
        '    End If
        'End If

        If Not dr.IsNull("stock_docDate") Then
          .m_buyDate = CDate(dr("stock_docDate"))
          .m_startCalcDate = .m_buyDate
          .m_transferDate = .m_buyDate
        End If
        If dr.Table.Columns.Contains("stocki_unitCost") Then
          If Not dr.IsNull("stocki_unitCost") Then
            .m_buyPrice = CDec(dr("stocki_unitCost"))
            .m_Deprebase = .m_buyPrice
          End If

        End If

        If Not dr.IsNull("stock_Code") Then
          .m_buyDocCode = CStr(dr("stock_Code"))
        End If
        If Not dr.IsNull("stock_docDate") Then
          .m_buyDocDate = CDate(dr("stock_docDate"))
        End If
        If Not dr.IsNull("stock_entity") Then
          .m_buyFrom = (New Supplier(CInt(dr("stock_entity")))).Name
        End If

        'If Not dr.IsNull("stocki_salvage") Then
        '    .m_salvage = CDec(dr("stocki_salvage"))
        'End If

        'If Not dr.IsNull("stocki_rentalrate") Then
        '    .m_rentalrate = CDec(dr("stocki_rentalrate"))
        'End If

        'If Not dr.IsNull("stocki_startCalcAmt") Then
        '    .m_startCalcAmt = CDec(dr("stocki_startCalcAmt"))
        'End If
        'Todo: m_calcType
        'If Not dr.IsNull("stocki_calcType") Then
        '    .m_calcType = New AssetCalcType(CInt(dr("stocki_calcType")))
        'End If
        'If Not dr.IsNull("stocki_calcRate") Then
        '    .m_calcRate = CDec(dr("stocki_calcRate"))
        'End If
        'If Not dr.IsNull("stocki_age") Then
        '    .m_age = CInt(dr("stocki_age"))
        'End If
        'If Not dr.IsNull("stocki_endCalcDate") Then
        '    .m_endCalcDate = CDate(dr("stocki_endCalcDate"))
        'End If
        'If Not dr.IsNull("stocki_balance") Then
        '    .m_balance = CDec(dr("stocki_balance"))
        'End If
        'If Not dr.IsNull("stocki_startBalance") Then
        '    .m_startBalance = CDec(dr("stocki_startBalance"))
        'End If
        'If Not dr.IsNull("stocki_saleDate") Then
        '    .m_saleDate = CDate(dr("stocki_saleDate"))
        'End If
        'If Not dr.IsNull("stocki_salePrice") Then
        '    .m_salePrice = CDec(dr("stocki_salePrice"))
        'End If
        'If Not dr.IsNull("stocki_balanceAtSaleDate") Then
        '    .m_balanceAtSaleDate = CDec(dr("stocki_balanceAtSaleDate"))
        'End If
        'If Not dr.IsNull("stocki_saleDocDate") Then
        '    .m_saleDocDate = CDate(dr("stocki_saleDocDate"))
        'End If
        'If Not dr.IsNull("stocki_saleDocCode") Then
        '    .m_saleDocCode = CStr(dr("stocki_saleDocCode"))
        'End If
        'If Not dr.IsNull("stocki_buyer") Then
        '    .m_buyer = CStr(dr("stocki_buyer"))
        'End If
        'If Not dr.IsNull("stocki_InsuranceCode") Then
        '    .m_InsuranceCode = CStr(dr("stocki_InsuranceCode"))
        'End If
        'If Not dr.IsNull("stocki_saftyCode") Then
        '    .m_saftyCode = CStr(dr("stocki_saftyCode"))
        'End If
        'If Not dr.IsNull("stocki_saftyCompany") Then
        '    .m_saftyCompany = CStr(dr("stocki_saftyCompany"))
        'End If
        'If Not dr.IsNull("stocki_insurancePremium") Then
        '    .m_insurancePremium = CDec(dr("stocki_insurancePremium"))
        'End If
        'If Not dr.IsNull("stocki_insurancePremium") Then
        '    .m_insuranceAge = CInt(dr("stocki_insuranceAge"))
        'End If
        'If Not dr.IsNull("stocki_insuranceStartDate") Then
        '    .m_insuranceStartDate = CDate(dr("stocki_insuranceStartDate"))
        'End If
        'If Not dr.IsNull("stocki_InsuranceEndDate") Then
        '    .m_InsuranceEndDate = CDate(dr("stocki_InsuranceEndDate"))
        'End If
        'If Not dr.IsNull("stocki_note") Then
        '    .m_note = CStr(dr("stocki_note"))
        'End If
        'If Not dr.IsNull("stocki_depreopening") Then
        '    .m_depreopening = CDec(dr("stocki_depreopening"))
        'End If
        'If Not dr.IsNull("stocki_remainValue") Then
        '    .m_remainValue = CDec(dr("stocki_remainValue"))
        'End If
        'If Not dr.IsNull("stocki_firstYearRate") Then
        '    .m_firstYearRate = CDec(dr("stocki_firstYearRate"))
        'End If

        'If Not dr.IsNull("stocki_isEquipment") Then
        '    .m_isEquipment = CBool(dr("stocki_isEquipment"))
        'End If
        'If Not dr.IsNull("stocki_isdepreciated") Then
        '    .m_isdepreciated = CBool(dr("stocki_isdepreciated"))
        'End If


        If Not dr.IsNull("stocki_tocc") Then
          .m_cc = New CostCenter(CInt(dr("stocki_tocc")))
        End If

        'If dr.Table.Columns.Contains(Me.Prefix & "_DateIntervalUnit") Then
        '    If Not dr.IsNull("stocki_DateIntervalUnit") Then
        '        .m_dateintervalunit = New DateinterValUnit(CInt(dr("stocki_DateIntervalUnit")))
        '    End If
        'End If
      End With
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aseetwriteoff As AssetWriteOff)
      MyBase.Construct(dr, "") 'id ,code
      Dim drh As New DataRowHelper(dr)
      With Me
        .m_name = drh.GetValue(Of String)("asset_name")
        .m_unit = Unit.GetUnitById(drh.GetValue(Of Integer)("asset_unit"))
        .m_account = Account.GetAccountById(drh.GetValue(Of Integer)("asset_acct"))
        .m_depreopeningacct = Account.GetAccountById(drh.GetValue(Of Integer)("asset_depreopeningacct"))
      End With
    End Sub
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal assetId As Integer)
      MyBase.New(assetId)
    End Sub
    Public Sub New(ByVal assetCode As String)
      MyBase.New(assetCode)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      If m_constructing Then
        Return
      End If
      With Me
        .m_type = New AssetType

        .m_account = New Account
        .m_depreopeningacct = New Account
        .m_depreaccount = New Account
        .PLAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.AssetProfitLoss).Account

        .m_unit = New Unit
        .m_lci = New LCIItem
        .m_status = New AssetStatus(-1)
        .m_calcType = New AssetCalcType(0)
        .m_dateintervalunit = New DateIntervalUnit(0)
        .m_cc = New CostCenter
        .m_project = New Project

        .m_salvage = 1
        .m_eqt = New EquipmentTool
      End With
    End Sub
    Private m_constructing As Boolean = False
    Private Shared CCHash As New Hashtable
    Private Shared AccountHash As New Hashtable
    Private Shared AssetTypeHash As New Hashtable
    Private Shared ProjectHash As New Hashtable
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      m_constructing = True
      MyBase.Construct(dr, aliasPrefix)
      With Me
        Dim drh As New DataRowHelper(dr)

        .m_name = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_name")
        .m_detail = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_detail")

        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") Then
          If Not dr.IsNull(aliasPrefix & "unit_id") Then
            .m_unit = New Unit(dr, aliasPrefix)
          Else
            .m_unit = New Unit
          End If

        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_unit")))
          Else
            .m_unit = New Unit
          End If
        End If

        ' Asset Account.
        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") Then
          If Not dr.IsNull(aliasPrefix & "acct_id") Then
            If Asset.AccountHash.Count > 20 Then
              Asset.AccountHash = New Hashtable
            End If
            If Asset.AccountHash.Contains(CInt(dr(aliasPrefix & "acct_id"))) Then
              .m_account = CType(Asset.AccountHash(CInt(dr(aliasPrefix & "acct_id"))), Account)
            Else
              .m_account = New Account(dr, aliasPrefix)
              Asset.AccountHash(CInt(dr(aliasPrefix & "acct_id"))) = .m_account
            End If
          Else
            .m_account = New Account
          End If
        ElseIf dr.Table.Columns.Contains("AssetAccount.acct_id") Then       ' Hack :
          If Not dr.IsNull("AssetAccount.acct_id") Then
            If Asset.AccountHash.Count > 20 Then
              Asset.AccountHash = New Hashtable
            End If
            If Asset.AccountHash.Contains(CInt(dr("AssetAccount.acct_id"))) Then
              .m_account = CType(Asset.AccountHash(CInt(dr("AssetAccount.acct_id"))), Account)
            Else
              .m_account = New Account(dr, "AssetAccount.")
              Asset.AccountHash(CInt(dr("AssetAccount.acct_id"))) = .m_account
            End If
          Else
            .m_account = New Account
          End If
        Else
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_acct") Then
            If Asset.AccountHash.Count > 20 Then
              Asset.AccountHash = New Hashtable
            End If
            If Asset.AccountHash.Contains(CInt(dr(aliasPrefix & Me.Prefix & "_acct"))) Then
              .m_account = CType(Asset.AccountHash(CInt(dr(aliasPrefix & Me.Prefix & "_acct"))), Account)
            Else
              .m_account = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_acct")))
              Asset.AccountHash(CInt(dr(aliasPrefix & Me.Prefix & "_acct"))) = .m_account
            End If
          Else
            .m_account = New Account
          End If
        End If
        ' DepreopeningAccount
        If dr.Table.Columns.Contains("DepreopeningAccount.acct_id") Then        ' Hack
          If Not dr.IsNull("DepreopeningAccount.acct_id") Then
            If Asset.AccountHash.Count > 20 Then
              Asset.AccountHash = New Hashtable
            End If
            If Asset.AccountHash.Contains(CInt(dr("DepreopeningAccount.acct_id"))) Then
              .m_depreopeningacct = CType(Asset.AccountHash(CInt(dr("DepreopeningAccount.acct_id"))), Account)
            Else
              .m_depreopeningacct = New Account(dr, "DepreopeningAccount.")
              Asset.AccountHash(CInt(dr("DepreopeningAccount.acct_id"))) = .m_depreopeningacct
            End If
          Else
            .m_depreopeningacct = New Account
          End If
        Else
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_depreopeningacct") Then
            If Asset.AccountHash.Count > 20 Then
              Asset.AccountHash = New Hashtable
            End If
            If Asset.AccountHash.Contains(CInt(dr(aliasPrefix & Me.Prefix & "_depreopeningacct"))) Then
              .m_depreopeningacct = CType(Asset.AccountHash(CInt(dr(aliasPrefix & Me.Prefix & "_depreopeningacct"))), Account)
            Else
              .m_depreopeningacct = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_depreopeningacct")))
              Asset.AccountHash(CInt(dr(aliasPrefix & Me.Prefix & "_depreopeningacct"))) = .m_depreopeningacct
            End If
          Else
            .m_depreopeningacct = New Account
          End If
        End If
        ' DepreAccount
        If dr.Table.Columns.Contains("DepreAccount.acct_id") Then       ' Hack
          If Not dr.IsNull("DepreAccount.acct_id") Then
            If Asset.AccountHash.Count > 20 Then
              Asset.AccountHash = New Hashtable
            End If
            If Asset.AccountHash.Contains(CInt(dr("DepreAccount.acct_id"))) Then
              .m_depreaccount = CType(Asset.AccountHash(CInt(dr("DepreAccount.acct_id"))), Account)
            Else
              .m_depreaccount = New Account(dr, "DepreAccount.")
              Asset.AccountHash(CInt(dr("DepreAccount.acct_id"))) = .m_depreaccount
            End If
          Else
            .m_depreaccount = New Account
          End If
        Else
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_depreacct") Then
            If Asset.AccountHash.Count > 20 Then
              Asset.AccountHash = New Hashtable
            End If
            If Asset.AccountHash.Contains(CInt(dr(aliasPrefix & Me.Prefix & "_depreacct"))) Then
              .m_depreaccount = CType(Asset.AccountHash(CInt(dr(aliasPrefix & Me.Prefix & "_depreacct"))), Account)
            Else
              .m_depreaccount = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_depreacct")))
              Asset.AccountHash(CInt(dr(aliasPrefix & Me.Prefix & "_depreacct"))) = .m_depreaccount
            End If
          Else
            .m_depreaccount = New Account
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "type_id") Then
          If Not dr.IsNull(aliasPrefix & "type_id") Then
            If Asset.AssetTypeHash.Count > 20 Then
              Asset.AssetTypeHash = New Hashtable
            End If
            If Asset.AssetTypeHash.Contains(CInt(dr(aliasPrefix & "type_id"))) Then
              .m_type = CType(Asset.AssetTypeHash(CInt(dr(aliasPrefix & "type_id"))), AssetType)
            Else
              .m_type = New AssetType(dr, aliasPrefix)
              Asset.AssetTypeHash(CInt(dr(aliasPrefix & "type_id"))) = .m_type
            End If
          Else
            .m_type = New AssetType
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_type") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_type") Then
            If Asset.AssetTypeHash.Count > 20 Then
              Asset.AssetTypeHash = New Hashtable
            End If
            If Asset.AssetTypeHash.Contains(CInt(dr(aliasPrefix & Me.Prefix & "_type"))) Then
              .m_type = CType(Asset.AssetTypeHash(CInt(dr(aliasPrefix & Me.Prefix & "_type"))), AssetType)
            Else
              .m_type = New AssetType(CInt(dr(aliasPrefix & Me.Prefix & "_type")))
              Asset.AssetTypeHash(CInt(dr(aliasPrefix & Me.Prefix & "_type"))) = .m_type
            End If
          Else
            .m_type = New AssetType
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
            .m_status = New AssetStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
          Else
            .m_status = New AssetStatus(-1)
          End If
        Else
          .m_status = New AssetStatus(-1)
        End If

        .m_location = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_location")
        .m_buyDate = drh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_buyDate")
        .m_buyPrice = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_buyPrice")
        .m_buyDocCode = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_buyDocCode")
        .m_buyDocDate = drh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_buyDocDate")
        .m_buyFrom = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_buyFrom")
        .m_transferDate = drh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_transferDate")
        .m_startCalcDate = drh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_startCalcDate")
        .m_lastDepreDate = drh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_lastdepredate")
        .m_salvage = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_salvage", 1)
        .m_rentalrate = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_rentalrate")
        .m_startCalcAmt = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_startCalcAmt")
        .m_writeoffamt = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_writeoffamt")
        .m_writeoffaccdepre = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_writeoffaccdepre")
        .m_age = drh.GetValue(Of Integer)(aliasPrefix & Me.Prefix & "_age")
        .m_Deprebase = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_deprebase")

        'If m_status.Value <> 5 Then
        .m_depreopening = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_depreopening")
        'End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_calcType") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_calcType") Then
          .m_calcType = New AssetCalcType(CInt(dr(aliasPrefix & Me.Prefix & "_calcType")))
        Else
          .m_calcType = New AssetCalcType(0)
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_eqtid") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_eqtid") Then
          .m_eqt = New EquipmentTool(CInt(dr(aliasPrefix & Me.Prefix & "_eqtid")), CInt(dr(aliasPrefix & Me.Prefix & "_eqttype")))
        End If


        .m_balance = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_balance")
        .m_startBalance = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_startBalance")
        .m_saleDate = drh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_saleDate")
        .m_salePrice = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_salePrice")
        .m_balanceAtSaleDate = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_balanceAtSaleDate")
        .m_firstYearRate = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_firstYearRate")


        .m_saleDocDate = drh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_saleDocDate")
        .m_saleDocCode = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_saleDocCode")
        .m_buyer = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_buyer")

        .m_InsuranceCode = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_InsuranceCode")
        .m_saftyCode = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_saftyCode")
        .m_saftyCompany = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_saftyCompany")

        .m_insurancePremium = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_insurancePremium")
        .m_insuranceAge = drh.GetValue(Of Integer)(aliasPrefix & Me.Prefix & "_insuranceAge")
        .m_insuranceStartDate = drh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_insuranceStartDate")
        .m_InsuranceEndDate = drh.GetValue(Of Date)(aliasPrefix & Me.Prefix & "_InsuranceEndDate")


        .m_note = drh.GetValue(Of String)(aliasPrefix & Me.Prefix & "_note")



        If dr.Table.Columns.Contains(aliasPrefix & "project_id") Then
          If Not dr.IsNull(aliasPrefix & "project_id") Then
            If Asset.ProjectHash.Count > 20 Then
              Asset.ProjectHash = New Hashtable
            End If
            If Asset.ProjectHash.Contains(CInt(dr(aliasPrefix & "project_id"))) Then
              .m_project = CType(Asset.ProjectHash(CInt(dr(aliasPrefix & "project_id"))), Project)
            Else
              .m_project = New Project(dr, aliasPrefix)
              Asset.ProjectHash(CInt(dr(aliasPrefix & "project_id"))) = .m_project
            End If
          Else
            .m_project = New Project
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_project") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_project") Then
            If Asset.ProjectHash.Count > 20 Then
              Asset.ProjectHash = New Hashtable
            End If
            If Asset.ProjectHash.Contains(CInt(dr(aliasPrefix & Me.Prefix & "_project"))) Then
              .m_project = CType(Asset.ProjectHash(CInt(dr(aliasPrefix & Me.Prefix & "_project"))), Project)
            Else
              .m_project = New Project(CInt(dr(aliasPrefix & Me.Prefix & "_project")))
              Asset.ProjectHash(CInt(dr(aliasPrefix & Me.Prefix & "_project"))) = .m_project
            End If
          Else
            .m_project = New Project
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "cc_id") Then
          If Not dr.IsNull(aliasPrefix & "cc_id") Then
            If Asset.CCHash.Count > 20 Then
              Asset.CCHash = New Hashtable
            End If
            If Asset.CCHash.Contains(CInt(dr(aliasPrefix & "cc_id"))) Then
              .m_cc = CType(Asset.CCHash(CInt(dr(aliasPrefix & "cc_id"))), CostCenter)
            Else
              .m_cc = New CostCenter(dr, aliasPrefix)
              Asset.CCHash(CInt(dr(aliasPrefix & "cc_id"))) = .m_cc
            End If
          Else
            .m_cc = New CostCenter
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cc") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cc") Then
            If Asset.CCHash.Count > 20 Then
              Asset.CCHash = New Hashtable
            End If
            If Asset.CCHash.Contains(CInt(dr(aliasPrefix & Me.Prefix & "_cc"))) Then
              .m_cc = CType(Asset.CCHash(CInt(dr(aliasPrefix & Me.Prefix & "_cc"))), CostCenter)
            Else
              .m_cc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_cc")))
              Asset.CCHash(CInt(dr(aliasPrefix & Me.Prefix & "_cc"))) = .m_cc
            End If
          Else
            .m_cc = New CostCenter
          End If
        End If

        If dr.Table.Columns.Contains("lci_id") Then
          If Not dr.IsNull("lci_id") Then
            .m_lci = New LCIItem(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_lci") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_lci") Then
            .m_lci = New LCIItem(CInt(dr(aliasPrefix & Me.Prefix & "_lci")))
          End If
        End If



        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_DateIntervalUnit") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_DateIntervalUnit") Then
            .m_dateintervalunit = New DateIntervalUnit(CInt(dr(aliasPrefix & Me.Prefix & "_DateIntervalUnit")))
          Else
            .m_dateintervalunit = New DateIntervalUnit(0)
          End If
        Else
          .m_dateintervalunit = New DateIntervalUnit(0)
        End If

        ' ถ้าไม่ดึงจาก Datarow ของ Asset เวลา Edit จะหายไป
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_refsequence") Then
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_refsequence") Then
            .m_refsequence = CInt(dr(aliasPrefix & Me.Prefix & "_refsequence"))
          End If
        End If

      End With

      'LoadImage()    ' Load เฉพาะเวลาใช้แทนครับเพราะจะทำให้ช้า
      m_constructing = False
    End Sub
    Public Overloads Sub LoadImage(ByVal reader As IDataReader)
      Me.Image = Field.GetImage(reader, Me.Prefix & "_image")
    End Sub
    Public Overloads Sub LoadImage()
      If Not Me.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select asset_image  from AssetImage where asset_id = " & Me.Id

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
    Public Property VisInitialized As Boolean
    Public Property VItemTable As TreeTable
      Get
        Return m_VitemTable
      End Get
      Set(ByVal value As TreeTable)
        m_VitemTable = value
      End Set
    End Property
    Public Property ItemTable() As TreeTable
      Get
        Return m_itemTable
      End Get
      Set(ByVal Value As TreeTable)
        m_itemTable = Value
      End Set
    End Property
    Public Property DateinterValUnit() As CodeDescription
      Get
        Return m_dateintervalunit
      End Get
      Set(ByVal Value As CodeDescription)
        m_dateintervalunit = CType(m_dateintervalunit, DateIntervalUnit)
      End Set
    End Property
    Public Property Name() As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Detail() As String
      Get
        Return m_detail
      End Get
      Set(ByVal Value As String)
        m_detail = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Unit() As Unit Implements IEqtItem.Unit
      Get
        Return m_unit
      End Get
      Set(ByVal Value As Unit)
        m_unit = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Account() As Account
      Get
        Return m_account
      End Get
      Set(ByVal Value As Account)
        m_account = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property DepreOpeningAccount() As Account
      Get
        Return m_depreopeningacct
      End Get
      Set(ByVal Value As Account)
        m_depreopeningacct = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property DepreAccount() As Account
      Get
        Return m_depreaccount
      End Get
      Set(ByVal Value As Account)
        m_depreaccount = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property PLAccount() As Account
      Get
        Return m_placcount
      End Get
      Set(ByVal Value As Account)
        m_placcount = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Type() As AssetType
      Get
        Return m_type
      End Get
      Set(ByVal Value As AssetType)
        m_type = Value
        If Not Me.m_type Is Nothing Then
          If Not m_type.Account Is Nothing AndAlso m_type.Account.Originated Then
            Me.Account = m_type.Account
          End If
          If Not m_type.DepreOpeningAccount Is Nothing AndAlso m_type.DepreOpeningAccount.Originated Then
            Me.DepreOpeningAccount = m_type.DepreOpeningAccount
          End If
          If Not m_type.DepreAccount Is Nothing AndAlso m_type.DepreAccount.Originated Then
            Me.DepreAccount = m_type.DepreAccount
          End If
        End If
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property Group() As ISimpleEntity Implements IHasGroup.Group
      Get
        Return Type
      End Get
    End Property
    Public ReadOnly Property LastDepreDate() As Date
      Get
        Return Me.m_lastDepreDate
      End Get
    End Property
    Public Property Location() As String
      Get
        Return m_location
      End Get
      Set(ByVal Value As String)
        m_location = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property Image() As Image Implements IHasImage.Image
      Get
        Return m_image
      End Get
      Set(ByVal Value As Image)
        m_image = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property BuyDate() As Date
      Get
        Return m_buyDate
      End Get
      Set(ByVal Value As Date)
        m_buyDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property BuyDocCode() As String
      Get
        Return m_buyDocCode
      End Get
      Set(ByVal Value As String)
        m_buyDocCode = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property BuyDocDate() As Date
      Get
        Return m_buyDocDate
      End Get
      Set(ByVal Value As Date)
        m_buyDocDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property BuyFrom() As String
      Get
        Return m_buyFrom
      End Get
      Set(ByVal Value As String)
        m_buyFrom = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property TransferDate() As Date 'วันที่ค่าเสื่อมยกมา
      Get
        Return m_transferDate
      End Get
      Set(ByVal Value As Date)
        m_transferDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property StartCalcDate() As Date
      Get
        Return m_startCalcDate
      End Get
      Set(ByVal Value As Date)
        m_startCalcDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property DepreOpening() As Decimal 'ค่าเสื่อมยกมา
      Get
        'If m_writeoffamt > 0 Then
        '  Return 0
        'End If
        Return m_depreopening
      End Get
      Set(ByVal Value As Decimal)
        m_depreopening = Value
      End Set
    End Property
    Public Property BuyPrice() As Decimal 'ราคาซื้อ (ราคาทุน)
      Get
        Return m_buyPrice
      End Get
      Set(ByVal Value As Decimal)
        m_buyPrice = Value
        m_Deprebase = m_buyPrice
      End Set
    End Property
    Public Property Salvage() As Decimal 'ราคาซาก
      Get
        Return m_salvage
      End Get
      Set(ByVal Value As Decimal)
        'ราคาซาก >=1
        'เปลี่ยนตามข้อกำหนดสรรพากรใหม่ ให้เป็น 0 ได้
        If Value >= 0 Then
          m_salvage = Value
        End If
      End Set
    End Property
    Public Property StartCalcAmt() As Decimal 'ค่าเสื่อมเบื้องต้น
      Get
        Return m_startCalcAmt + WriteOffDepreAmount
      End Get
      Set(ByVal Value As Decimal)
        m_startCalcAmt = Value
      End Set
    End Property
    Public ReadOnly Property RemainValue() As Decimal 'มูลค่าคงเหลือยกมา
      Get
        If DepreOpening > 0 Then 'ค่าเสื่อมยกมา รวมค่าเสื่อมเบื้องต้นไปแล้ว คิดมาแล้ว
          Return Math.Max(Me.DepreBase - Me.DepreOpening, 0)
        End If
        'มูลค่าคงเหลือยกมา = ราคาซื้อ - ค่าเสื่อมเบื้องต้น  - ค่าเสื่อมยกมา
        Return Math.Max(Me.DepreBase - Me.StartCalcAmt - Me.DepreOpening - Me.WriteOffAmnt, 0)
      End Get
    End Property
    Public ReadOnly Property CalculatingValue() As Decimal 'มูลค่าคำนวณค่าเสื่อม
      Get
        Return Math.Max(Me.DepreBase - Me.StartCalcAmt - Me.Salvage, 0)
      End Get
    End Property
    Public ReadOnly Property CalculatingValueIgnoreStartCalcAmt() As Decimal 'มูลค่าคำนวณค่าเสื่อมแบบไม่สนใจค่าเสื่อมเบื้องต้น
      Get
        Return Math.Max(Me.DepreBase - Me.Salvage, 0)
      End Get
    End Property
    Public Property Age() As Integer 'อายุสินทรัพย์ (ปี)
      Get
        Return m_age
      End Get
      Set(ByVal Value As Integer)
        m_age = Value
      End Set
    End Property

    Public ReadOnly Property EntityId As Integer Implements IEqtItem.EntityId
      Get
        Return MyBase.EntityId
      End Get
    End Property
    Public Property RentalRate() As Decimal Implements IHasRentalRate.RentalRate
      Get
        Return m_rentalrate
      End Get
      Set(ByVal Value As Decimal)
        m_rentalrate = Value
      End Set
    End Property
    Public Property CalcType() As AssetCalcType
      Get
        Return m_calcType
      End Get
      Set(ByVal Value As AssetCalcType)
        m_calcType = Value
      End Set
    End Property
    Public ReadOnly Property CalcRate() As Decimal
      Get
        If Me.Age > 0 Then
          Select Case Me.CalcType.Value
            Case 0
              Return Math.Round((100D / Me.Age), 4)
            Case 1
              Return 0
            Case 2
              Return Math.Round((2 * (100D / Me.Age)), 4)
          End Select
        End If
        Return 0
      End Get
    End Property
    Public ReadOnly Property EndCalcDate() As Date
      Get
        If Me.Age > 0 Then
          If Date.Equals(Date.MinValue, Me.StartCalcDate) Then
            Return Date.MinValue
          Else
            Dim enddate As Date = DateAdd(DateInterval.DayOfYear, -1, DateAdd(DateInterval.Year, Me.Age, Me.StartCalcDate))
            Return enddate
          End If
        Else
          Return Me.StartCalcDate
        End If
      End Get
    End Property
    Public Property Balance() As Decimal
      Get
        Return m_balance
      End Get
      Set(ByVal Value As Decimal)
        m_balance = Value
      End Set
    End Property

    Public Property DepreBase As Decimal
      Get
        Return m_Deprebase
      End Get
      Set(ByVal value As Decimal)
        If value >= m_buyPrice Then
          m_Deprebase = m_buyPrice
        Else
          m_Deprebase = value
        End If
      End Set
    End Property

    Public ReadOnly Property SystemDepreAmount As Decimal
      Get
        'If m_writeoffamt > 0 Then
        '  Return 0
        'End If
        Return GetDepreAmntfromDB()
      End Get
    End Property
    Public ReadOnly Property DepreAmnt As Decimal
      Get
        Return Me.GetDepreAmntfromDB + Me.DepreOpening
      End Get
    End Property

    Public ReadOnly Property WriteOffAmnt As Decimal
      Get
        Return m_writeoffamt
      End Get
    End Property
    Public ReadOnly Property WriteOffDepreAmount As Decimal
      Get
        If GetWriteOffAmoutfromDB() > 0 Then
          'Return Math.Round((Me.GetDepreAmntfromDB + m_depreopening) - m_writeoffaccdepre, 2)
          Return Math.Round(Me.GetDepreAmntfromDB - GetWriteOffAmoutfromDB(), 2)

          'GetWriteOffAmoutfromDB
        End If
        Return 0
      End Get
    End Property
    Public ReadOnly Property AssetRemainValue As Decimal
      Get
        m_assetremainvalue = DeprebaseBal - Me.DepreAmnt
        Return m_assetremainvalue
      End Get
    End Property

    Public ReadOnly Property DeprebaseBal As Decimal
      Get
        'มูลค่าคงเหลือยกมา = ราคาซื้อ -  ค่าwriteoff (บางส่วน)
        If m_buyPrice > 0 Then
          Return Math.Max((Me.DepreBase * (1 - (m_writeoffamt / m_buyPrice))) - WriteOffDepreAmount, 0)
        Else
          Return 0
        End If
      End Get
    End Property

    Public ReadOnly Property Eqt As EquipmentTool
      Get
        Return m_eqt
      End Get
    End Property
    Public Property StartBalance() As Decimal
      Get
        Return m_startBalance
      End Get
      Set(ByVal Value As Decimal)
        m_startBalance = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property SaleDate() As Date
      Get
        Return m_saleDate
      End Get
      Set(ByVal Value As Date)
        m_saleDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property SalePrice() As Decimal
      Get
        Return m_salePrice
      End Get
      Set(ByVal Value As Decimal)
        m_salePrice = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property BalanceAtSaleDate() As Decimal
      Get
        Return m_balanceAtSaleDate
      End Get
      Set(ByVal Value As Decimal)
        m_balanceAtSaleDate = Value
      End Set
    End Property

    Public Property SaleDocCode() As String
      Get
        Return m_saleDocCode
      End Get
      Set(ByVal Value As String)
        m_saleDocCode = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property SaleDocDate() As Date
      Get
        Return m_saleDocDate
      End Get
      Set(ByVal Value As Date)
        m_saleDocDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property Buyer() As String
      Get
        Return m_buyer
      End Get
      Set(ByVal Value As String)
        m_buyer = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property InsuranceCode() As String
      Get
        Return m_InsuranceCode
      End Get
      Set(ByVal Value As String)
        m_InsuranceCode = Value
      End Set
    End Property

    Public Property SaftyCode() As String
      Get
        Return m_saftyCode
      End Get
      Set(ByVal Value As String)
        m_saftyCode = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property SaftyCompany() As String
      Get
        Return m_saftyCompany
      End Get
      Set(ByVal Value As String)
        m_saftyCompany = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property InsurancePremium() As Decimal
      Get
        Return m_insurancePremium
      End Get
      Set(ByVal Value As Decimal)
        m_insurancePremium = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property InsuranceAge() As Integer
      Get
        Return m_insuranceAge
      End Get
      Set(ByVal Value As Integer)
        m_insuranceAge = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property InsuranceStartDate() As Date
      Get
        Return m_insuranceStartDate
      End Get
      Set(ByVal Value As Date)
        m_insuranceStartDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property InsuranceEndDate() As Date
      Get
        Return m_InsuranceEndDate
      End Get
      Set(ByVal Value As Date)
        m_InsuranceEndDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property Note() As String
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property FirstYearRate() As Decimal
      Get
        Return m_firstYearRate
      End Get
      Set(ByVal Value As Decimal)
        m_firstYearRate = Value
      End Set
    End Property
    Public Property Costcenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

    Public Property Project() As Project
      Get
        Return m_project
      End Get
      Set(ByVal Value As Project)
        m_project = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property LCI() As LCIItem
      Get
        Return m_lci
      End Get
      Set(ByVal Value As LCIItem)
        m_lci = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, AssetStatus)
      End Set
    End Property

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Asset"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Asset.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Asset"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Asset"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Asset.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "asset"
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

#Region "Shared"
    Public Shared Function GetAsset(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEntity As Asset) As Boolean
      Dim entity As New Asset(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not entity.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        entity = oldEntity
      End If
      txtCode.Text = entity.Code
      txtName.Text = entity.Name
      If oldEntity.Id <> entity.Id Then
        oldEntity = entity
        Return True
      End If
      Return False
    End Function
    Public Shared Sub PopulateUnregisteredTree(ByVal tv As TreeView)

      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetUnregisteredAsset")
      tv.Nodes.Clear()
      For Each row As DataRow In ds.Tables(0).Rows
        Dim NodeNme As String = CStr(row("stocki_itemname")) & " - " & CStr(row("remain"))
        Dim parentNodes As TreeNodeCollection
        Dim parnode As TreeNode = SearchTag(tv, CInt(row("stock_id")))
        If parnode Is Nothing Then
          parnode = tv.Nodes.Add(CStr(row("stock_code")) & "-" & CStr(row("stock_docdate")))
          parnode.Tag = CInt(row("stock_id"))
          parentNodes = parnode.Nodes
        Else
          parentNodes = parnode.Nodes
        End If
        Dim theNode As TreeNode = parentNodes.Add(NodeNme)
        theNode.Tag = row
      Next
    End Sub
    Private Shared Function SearchTag(ByVal tv As TreeView, ByVal id As Integer) As TreeNode
      For Each node As TreeNode In tv.Nodes
        If IsNumeric(node.Tag) AndAlso CInt(node.Tag) = id Then
          Return node
        End If
      Next
    End Function
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "AssetStock"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'Items()
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "Linenumber"

      Dim csType As New TreeTextColumn
      csType.MappingName = "DocType"
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.DocTypeHeaderText}")
      csType.NullText = ""
      csType.ReadOnly = True

      Dim csMCode As New TreeTextColumn
      csMCode.MappingName = "MainCode"
      csMCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.ToolCodeHeaderText}")
      csMCode.NullText = ""
      csMCode.ReadOnly = True

      Dim csMName As New TreeTextColumn
      csMName.MappingName = "MainName"
      csMName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.NameHeaderText}")
      csMName.NullText = ""
      csMName.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "ItemCode"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.ToolCodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True

      Dim csName As New TreeTextColumn
      csName.MappingName = "ItemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.NameHeaderText}")
      csName.NullText = ""
      csName.ReadOnly = True


      Dim csFromCCcode As New TreeTextColumn
      csFromCCcode.MappingName = "FromCCcode"
      csFromCCcode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.CCcodeHeaderText}")
      csFromCCcode.NullText = ""
      csFromCCcode.ReadOnly = True

      Dim csFromCCname As New TreeTextColumn
      csFromCCname.MappingName = "FromCCname"
      csFromCCname.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.CCnameHeaderText}")
      csFromCCname.NullText = ""
      csFromCCname.ReadOnly = True

      'Dim csAmount As New TreeTextColumn
      'csAmount.MappingName = "Amount"
      'csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.AmountHeaderText}")
      'csAmount.NullText = ""
      'csAmount.ReadOnly = True
      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csMCode)
      dst.GridColumnStyles.Add(csMName)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csFromCCcode)
      dst.GridColumnStyles.Add(csFromCCname)
      'dst.GridColumnStyles.Add(csAmount)

      Return dst
    End Function

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("AssetStock")

      myDatatable.Columns.Add(New DataColumn("DocType", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("MainCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("MainName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ItemCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ItemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("FromCCcode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("FromCCname", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("FromCC", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("ToCC", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      Return myDatatable
    End Function
#End Region

    Public Function ValidCostCenter(ByVal cc As CostCenter) As Boolean
      If Not Me.Costcenter Is Nothing AndAlso cc.Id = Me.Costcenter.Id Then
        Return True
      End If
      Return False
    End Function

#Region "Summary Calculations"
    Private m_internalIncomeYTD As Decimal
    Private m_externalIncomeYTD As Decimal
    Private m_maintenanceCostYTD As Decimal
    Private m_depreYTD As Double
    Private m_profitYTD As Double

    Private m_internalIncomeLTD As Decimal
    Private m_externalIncomeLTD As Decimal
    Private m_maintenanceCostLTD As Decimal
    Private m_depreLTD As Double
    Private m_profitLTD As Double
    Public ReadOnly Property InternalIncomeYTD() As Decimal
      Get
        Return m_internalIncomeYTD
      End Get
    End Property

    Public ReadOnly Property ExternalIncomeYTD() As Decimal
      Get
        Return m_externalIncomeYTD
      End Get
    End Property

    Public ReadOnly Property MaintenanceCostYTD() As Decimal
      Get
        Return m_maintenanceCostYTD
      End Get
    End Property
    Public ReadOnly Property DepreYTD() As Double
      Get
        Return m_depreYTD
      End Get
    End Property
    Public ReadOnly Property ProfitYTD() As Double
      Get
        Return m_profitYTD
      End Get
    End Property
    Public ReadOnly Property InternalIncomeLTD() As Decimal
      Get
        Return m_internalIncomeLTD
      End Get
    End Property
    Public ReadOnly Property ExternalIncomeLTD() As Decimal
      Get
        Return m_externalIncomeLTD
      End Get
    End Property
    Public ReadOnly Property MaintenanceCostLTD() As Decimal
      Get
        Return m_maintenanceCostLTD
      End Get
    End Property
    Public ReadOnly Property DepreLTD() As Double
      Get
        Return m_depreLTD
      End Get
    End Property
    Public ReadOnly Property ProfitLTD() As Double
      Get
        Return m_profitLTD
      End Get
    End Property
    Public Sub RefreshSummaryInfo()
      If Not Me.Originated Then
        Return
      End If
      Dim sqlConString As String = Me.RealConnectionString
      Dim ds As DataSet

      ds = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEqManagement" _
      , New SqlParameter("@asset_id", Me.Id))

      For Each row As DataRow In ds.Tables(0).Rows
        ' Year to date
        m_internalIncomeYTD = CDec(row("internalYTD"))
        m_externalIncomeYTD = CDec(row("externalYTD"))
        m_maintenanceCostYTD = CDec(row("maintenanceYTD"))

        ' Life to date
        m_internalIncomeLTD = CDec(row("internalLTD"))
        m_externalIncomeLTD = CDec(row("externalLTD"))
        m_maintenanceCostLTD = CDec(row("maintenanceLTD"))

      Next
    End Sub
    Dim m_assetdepre As New Nullable(Of Decimal)
    'Dim m_lastdepredate As New Nullable(Of Date)

    Public Function GetDepreAmntfromDB() As Decimal
      Dim ds As New DataSet
      Try
        If m_assetdepre.HasValue Then
          Return m_assetdepre.Value
        End If
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        ds = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "GetDepreAmntInprocess" _
        , New SqlParameter("@AssetId", Me.Id))

        If ds.Tables(0).Rows.Count > 0 Then
          m_assetdepre = CDec(ds.Tables(0).Rows(0)("DepreAmnt"))
        Else
          Return 0
        End If
      Catch ex As Exception

      End Try
      Return m_assetdepre.Value
    End Function
    Public Function GetWriteOffAmoutfromDB() As Decimal
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "GetWriteOffAmoutfromDB" _
        , New SqlParameter("@AssetId", Me.Id))

        If ds.Tables(0).Rows.Count > 0 Then
          m_assetdepre = CDec(ds.Tables(0).Rows(0)("WriteOffAmount"))
        Else
          Return 0
        End If
      Catch ex As Exception

      End Try
    End Function
#End Region

#Region "Last Date"
    Private m_lastdateYTD As Date
    Private m_lastdateLTD As Date
    Private m_lastLocation As CostCenter
    Public ReadOnly Property LastdateYTD() As Date
      Get
        Return m_lastdateYTD
      End Get
    End Property
    Public ReadOnly Property LastdateLTD() As Date
      Get
        Return m_lastdateLTD
      End Get
    End Property
    Public ReadOnly Property IsDepreciated() As Boolean
      Get
        RefreshLastModified(Nothing)
        Return Not m_lastdateLTD.Equals(Date.MinValue)
      End Get
    End Property
    Public ReadOnly Property LastLocation() As CostCenter
      Get
        RefreshLastModified(Nothing)
        If m_lastLocation Is Nothing Then
          m_lastLocation = Me.Costcenter
        End If
        Return m_lastLocation
      End Get
    End Property
    Private ReadOnly Property NewYearDate() As Date
      'วันปีใหม่ของปีนี้
      Get
        Return DateSerial(DatePart(DateInterval.Year, Date.Now), 1, 1)
      End Get
    End Property
    Public Function GetLastCalcDate(ByVal depre As DepreciationCal) As Date
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "GetDepreciationCalitemLastCalcDate" _
        , New SqlParameter("@deprei_depre", Me.ValidIdOrDBNull(depre)) _
        , New SqlParameter("@deprei_entity", Me.Id))

        If IsDate(ds.Tables(0).Rows(0)(0)) Then
          Return CDate(ds.Tables(0).Rows(0)(0)).Date
        End If
      Catch ex As Exception

      End Try
      Return Date.MinValue
    End Function
    Public Sub RefreshLastModified(ByVal depre As DepreciationCal)
      If Not Me.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet

      ds = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetDepreciationCalitemLastModified" _
      , New SqlParameter("@deprei_depre", Me.ValidIdOrDBNull(depre)) _
      , New SqlParameter("@deprei_entity", Me.Id))

      For Each row As DataRow In ds.Tables(0).Rows
        If Not row.IsNull("YTDLastDate") Then
          m_lastdateYTD = CDate(row("YTDLastDate"))
        End If
        If Not row.IsNull("LTDLastDate") Then
          m_lastdateLTD = CDate(row("LTDLastDate"))
        End If
      Next

      If ds.Tables.Count > 1 Then
        m_lastLocation = Nothing
        If ds.Tables(1).Rows.Count = 1 Then
          m_lastLocation = New CostCenter(ds.Tables(1).Rows(0), "")
        End If
      End If
    End Sub
#End Region

#Region " Depreciation Calculation "
    'YTD = Year to date
    'LTD = Life to date
    Public Sub DepreciationCalc()
      RefreshLastModified(Nothing)

      Me.m_depreYTD = DepreCalcAtDate(Me.LastdateYTD) - DepreCalcAtDate(Me.NewYearDate)
      If Me.DepreYTD < Me.StartCalcAmt Then
        Me.m_depreYTD = Me.StartCalcAmt
      End If

      Me.m_profitYTD = Me.m_internalIncomeYTD + Me.m_externalIncomeYTD - Me.m_maintenanceCostYTD - Me.m_depreYTD

      Me.m_depreLTD = DepreCalcAtDate(Me.m_lastdateLTD)
      Me.m_profitLTD = Me.m_internalIncomeLTD + Me.m_externalIncomeLTD - Me.m_maintenanceCostLTD - Me.m_depreLTD
    End Sub
    Public Function DepreCalcBetweenDateIgnoreStartCalcAmt(ByVal startDate As Date, ByVal endDate As Date) As Double
      If startDate > endDate Then
        Return 0
      End If
      Dim DepreValue As Double
      DepreValue = Me.DepreCalcAtDateIgnoreStartCalcAmt(endDate) - Me.DepreCalcAtDateIgnoreStartCalcAmt(startDate.AddDays(-1))
      'If startDate < Me.TransferDate And startDate > Me.StartCalcDate Then  'ช่วงคาบเกี่ยวระหว่างก่อนย้ายเข้าระบบถึงย้ายเข้าสู่ระบบแล้ว
      '    DepreValue += Me.DepreOpening
      'End If
      'If Me.StartCalcDate <= startDate And Me.StartCalcDate >= endDate And startDate <> endDate Then
      '    DepreValue += Me.StartCalcAmt
      'End If
      Return DepreValue
    End Function
    Public Function DepreCalcAtDateIgnoreStartCalcAmt(ByVal theDate As Date) As Double
      If Me.StartCalcDate.Equals(Date.MinValue) Or Me.TransferDate.Equals(Date.MinValue) Then
        Return 0
      End If
      'ยอมคิดค่าเสื่อมก่อนวันยกมา
      'If theDate < Me.TransferDate And theDate < Me.StartCalcDate Then
      If theDate < Me.StartCalcDate Then
        Return 0
      End If

      Dim Interval As Long = DateDiff(DateInterval.DayOfYear, Me.TransferDate, theDate) 'จำนวนวันตั้งแต่วันที่เริ่มคำนวณจนถึงวันคำนวณ

      Interval = CLng(IIf(Interval < 0, -1, Interval))
      Interval += 1  'ต้องการนับวันเริ่มต้นด้วย
      Dim TotalDays As Long = DateDiff(DateInterval.DayOfYear, Me.StartCalcDate, DateAdd(DateInterval.Year, Me.Age, Me.StartCalcDate).AddDays(-1))
      TotalDays += 1  'ต้องการนับวันเริ่มต้นด้วย


      Dim OpeningInterval As Long = 0
      If Me.TransferDate > Me.StartCalcDate And theDate >= Me.StartCalcDate Then
        OpeningInterval = DateDiff(DateInterval.DayOfYear, Me.StartCalcDate, theDate)  'จำนวนวันตั้งแต่วันที่เริ่มคำนวณจนถึงวันคำนวณ
        OpeningInterval += 1  'ต้องการนับวันเริ่มต้นด้วย
      End If



      Dim DepreValue As Double = 0
      Dim DepreOpeningValue As Double = 0
      Dim DepreOpeningDayRange As Long = 0
      Dim xdays As Integer = 0
      Dim calcDevideAmt As Decimal = 0
      Dim calcMultiAmt As Decimal = 0
      Dim deprePerDayTTE As Double = 0 'ค่าเสื่อมสะสมต่อวัน คิดจากวันคิดค่าเสื่อมยกมาจนถึงวันสุท้าย

      If Me.Age > 0 Then
        'หาวันของการยกมา
        DepreOpeningDayRange = DateDiff(DateInterval.DayOfYear, Me.StartCalcDate, Me.TransferDate)
        'If DepreOpeningDayRange > 0 Then  'หาจำนวนวันที่ค่าเสื่อมสะสมยกมาอาจจะใช้เกิน
        '  calcDevideAmt = Me.CalculatingValueIgnoreStartCalcAmt / TotalDays

        '  'xdays = CInt((Me.DepreOpening / (Me.CalculatingValueIgnoreStartCalcAmt / TotalDays)) - DepreOpeningDayRange)
        '  If calcDevideAmt > 0 Then
        '    xdays = CInt((Me.DepreOpening / calcDevideAmt) - DepreOpeningDayRange)
        '  Else
        '    xdays = CInt((-1) * DepreOpeningDayRange)
        '  End If
        '  DepreOpeningValue += OpeningInterval / DepreOpeningDayRange * Me.DepreOpening
        'End If

        'calcMultiAmt = TotalDays * Me.CalculatingValueIgnoreStartCalcAmt
        'If (calcMultiAmt) > 0 Then
        '  DepreValue = Interval / calcMultiAmt 'ค่าเสื่อมตามจำนวนวันที่ต้องการนับจากวันย้ายเข้าสู่ระบบ
        'End If

        '---------------------------------------------
        If DepreOpeningDayRange > 0 Then  'หาจำนวนวันที่ค่าเสื่อมสะสมยกมาอาจจะใช้เกิน
          Dim div1 As Double
          If TotalDays > 0 Then
            div1 = Me.CalculatingValueIgnoreStartCalcAmt / TotalDays
          End If
          If div1 > 0 Then
            ' xday น่าจะได้วันที่ ที่น่าจะเป็นของ ค่าเสื่อม
            xdays = CInt((Me.DepreOpening / (div1)) - DepreOpeningDayRange)
          End If
          If DepreOpeningDayRange > 0 Then
            DepreOpeningValue += OpeningInterval / DepreOpeningDayRange * Me.DepreOpening
          End If
          If TotalDays > DepreOpeningDayRange Then
            deprePerDayTTE = (Me.CalculatingValueIgnoreStartCalcAmt - Me.DepreOpening) / (TotalDays - DepreOpeningDayRange)
          Else
            deprePerDayTTE = 0
          End If
        ElseIf DepreOpeningDayRange = 0 Then
          deprePerDayTTE = Me.CalculatingValueIgnoreStartCalcAmt / TotalDays

        End If

        If TotalDays > 0 Then
          'DepreValue = Interval / TotalDays * Me.CalculatingValueIgnoreStartCalcAmt 'ค่าเสื่อมตามจำนวนวันที่ต้องการนับจากวันย้ายเข้าสู่ระบบ
          DepreValue = Interval * deprePerDayTTE
        End If
        '---------------------------------------------

        If DepreOpeningDayRange > 0 Then 'ถ้าวันย้ายเข้าระบบกับวันเริ่มคิดค่าซากไม่ตรงกัน ให้บวกค่าซากสะสมเข้าไปด้วย
          DepreValue += Me.DepreOpening
          'DepreValue += CDec(IIf(DepreOpeningValue > Me.DepreOpening, Me.DepreOpening, DepreOpeningValue))
        End If

        If Interval = 0 Then  'แสดงว่า Transfer > thedate
          If DepreOpeningDayRange <> 0 Then
            DepreValue = OpeningInterval * (Me.DepreOpening / DepreOpeningDayRange)
          Else ' ค่า 0 สแดงว่า คิดค่าเสื่อมวันที่โอน และตรงกับวันที่เริ่มด้วย ค่าเป็น 0
            DepreValue = 0
          End If
        End If

        If Interval + DepreOpeningDayRange + xdays >= TotalDays Or theDate > DateAdd(DateInterval.Year, Me.Age, Me.StartCalcDate).AddDays(-2) Then  'ถ้าจำนวนวันมากกว่าเท่ากับวันทั้งหมด ให้ค่าเสื่อมเป็นราคา-ค่าซาก
          DepreValue = Me.BuyPrice - Me.Salvage
        End If
      End If  ' N > 0
      Return DepreValue
    End Function
    Public Function DepreCalcAtDate(ByVal theDate As Date) As Double
      Return DepreCalcAtDateIgnoreStartCalcAmt(theDate)
      'Undone
      If Me.StartCalcDate.Equals(Date.MinValue) Then
        Return 0
      End If
      If theDate < Me.StartCalcDate Then
        Return Me.StartCalcAmt
      End If
      Dim interval As Long = DateDiff(DateInterval.Year, Me.StartCalcDate, theDate) 'จำนวนปีตั้งแต่วันที่เริ่มคำนวณจนถึงวันคำนวณ

      Dim dtCalcDateThisYear As Date = DateAdd(DateInterval.Year, interval, Me.StartCalcDate) 'วันที่เริ่มคำนวณในปีนี้
      Dim dtCalcDateLastYear As Date = DateAdd(DateInterval.Year, -1, dtCalcDateThisYear) 'วันที่เริ่มคำนวณของปีก่อน

      Dim daysThisYear As Long = DateDiff(DateInterval.DayOfYear, dtCalcDateLastYear, dtCalcDateThisYear) 'จำนวนวันของปีนี้
      Dim daysUsingThisYear As Long = 0 'จำนวนวันที่ใช้งานของปีนี้

      If theDate >= dtCalcDateThisYear Then
        daysUsingThisYear = DateDiff(DateInterval.DayOfYear, dtCalcDateThisYear, theDate) + 1
        interval += 1
      Else
        Dim BelowYrs As Integer = theDate.DayOfYear
        daysUsingThisYear = DateDiff(DateInterval.DayOfYear, dtCalcDateLastYear, DateSerial(DatePart(DateInterval.Year, dtCalcDateLastYear), 12, 31)) + 1
        daysUsingThisYear += BelowYrs
        If interval = 0 Then
          If theDate < Me.StartCalcDate Then
            interval = 0
            daysUsingThisYear = 0
          Else
            interval += 1
          End If
        End If
      End If

      ' 2. คำนวณ
      Dim HtRms As New Hashtable
      Dim HtThisYear As New Hashtable
      Dim HtDepre As New Hashtable

      Dim yearRateDiv As Double = 0
      Dim yearRate As Double = 0

      If Me.Age > 0 Then
        Select Case Me.CalcType.Value
          Case 0 'เส้นตรง
            yearRateDiv = 1D / Me.Age
            yearRate = yearRateDiv * Me.CalculatingValue 'ค่าเสื่อมต่อปี
            For i As Long = 0 To interval
              If i = 0 Then 'ตั้งต้น
                HtRms(i) = 0
                HtThisYear(i) = Me.StartCalcAmt
                HtDepre(i) = Me.StartCalcAmt
              Else 'ปีถัดๆมา
                If i > Me.Age Then 'ปีหลังอายุสินทรัพย์ เช่นปีที่ 6 แต่สินทรัพย์มีอายุ 5 ปี
                  HtRms(i) = 0
                  HtThisYear(i) = 0
                  HtDepre(i) = Me.BuyPrice - Me.Salvage
                Else
                  HtRms(i) = yearRateDiv
                  HtThisYear(i) = yearRate
                  HtDepre(i) = CDbl(HtDepre(i - 1)) + yearRate
                End If
              End If
            Next
          Case 1 'ผลรวมจำนวนปี
            For i As Long = 0 To interval
              yearRateDiv = (Me.Age - i + 1) / ((Me.Age * (Me.Age + 1)) / 2D)
              yearRate = yearRateDiv * Me.CalculatingValue
              If i = 0 Then
                HtRms(i) = 0
                HtThisYear(i) = Me.StartCalcAmt
                HtDepre(i) = Me.StartCalcAmt
              Else
                If i > Me.Age Then
                  HtRms(i) = 0
                  HtThisYear(i) = 0
                  HtDepre(i) = Me.BuyPrice - Me.Salvage
                Else
                  HtRms(i) = yearRateDiv
                  HtThisYear(i) = yearRate
                  HtDepre(i) = CDbl(HtDepre(i - 1)) + yearRate
                End If
              End If
            Next
          Case 2 'ลดลงทวีคูณ
            Dim HtBvs As New Hashtable
            Dim Bvms As Double = 0
            yearRateDiv = 2D / Me.Age
            For i As Long = 0 To interval
              Bvms = CDbl(HtBvs(i - 1)) - (yearRateDiv * CDbl(HtBvs(i - 1)))
              yearRate = yearRateDiv * CDbl(HtBvs(i - 1))
              If i = 0 Then
                HtRms(i) = 0
                HtThisYear(i) = Me.StartCalcAmt
                HtDepre(i) = Me.StartCalcAmt
                HtBvs(i) = Me.BuyPrice - Me.StartCalcAmt
              Else
                If i > Me.Age Then
                  HtRms(i) = 0
                  HtThisYear(i) = 0
                  HtDepre(i) = Me.BuyPrice - Me.Salvage
                  HtBvs(i) = Me.Salvage
                Else
                  HtRms(i) = yearRateDiv
                  If Bvms < Me.Salvage Then
                    yearRate = CDbl(HtBvs(i - 1)) - Me.Salvage
                    HtThisYear(i) = yearRate
                    HtDepre(i) = CDbl(HtDepre(i - 1)) + yearRate
                    HtBvs(i) = Me.Salvage
                  Else
                    HtThisYear(i) = yearRate
                    HtDepre(i) = CDbl(HtDepre(i - 1)) + yearRate
                    HtBvs(i) = Bvms
                  End If
                End If
              End If
            Next
        End Select
      End If  ' N > 0

      ' 3. คำนวณค่า
      Dim depreThisYear As Double = 0
      Dim depre As Double = 0
      If daysThisYear <> 0 Then
        Dim fraction As Double = CDbl(daysUsingThisYear) / CDbl(daysThisYear) 'อัตราส่วนการใช้ในปีนี้
        depreThisYear = fraction * CDbl(HtThisYear(interval))
        If interval > 1 Then
          depre = CDbl(HtDepre(interval - 1)) - Me.StartCalcAmt
        Else
          depre = CDbl(HtDepre(interval - 1))
        End If
      End If
      depre += depreThisYear
      Return depre + Me.StartCalcAmt
    End Function
#End Region

#Region " Methods "
    Public Function GetLastWithdrawSequence() As Integer
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "GetLastAssetWithdrawSequenceWithNoReturn" _
        , New SqlParameter("@asset_id", Me.Id))

        If ds.Tables(0).Rows.Count > 0 AndAlso IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CInt(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception

      End Try
      Return 0
    End Function
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      'If Me.m_refsequence = 0 Then
      '    Return New SaveErrorException("${res:Global.Error.NoAssetReference}")
      'End If
      If Me.BuyPrice <= 0 Then
        Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", _
        "${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblBuyPrice}")
      ElseIf Me.Age <= 0 AndAlso Me.Type.DepreAble Then
        Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", _
        "${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblAge}")
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
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.Status.Value = -1 Then
        Me.Status.Value = 1 'ว่าง
      End If

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_refsequence", Me.m_refsequence))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_detail", Me.Detail))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_unit", IIf(Me.Unit.Originated, Me.Unit.Id, DBNull.Value)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acct", IIf(Me.Account.Originated, Me.Account.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_depreopeningacct", IIf(Me.DepreOpeningAccount.Originated, Me.DepreOpeningAccount.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_depreacct", IIf(Me.DepreAccount.Originated, Me.DepreAccount.Id, DBNull.Value)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", IIf(Me.Type.Originated, Me.Type.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_location", Me.Location))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buyDate", IIf(Me.BuyDate.Equals(Date.MinValue), DBNull.Value, Me.BuyDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buyPrice", Me.BuyPrice))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buyDocCode", Me.BuyDocCode))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buyDocDate", IIf(Me.BuyDocDate.Equals(Date.MinValue), DBNull.Value, Me.BuyDocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buyFrom", Me.BuyFrom))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_transferDate", IIf(Me.TransferDate.Equals(Date.MinValue), DBNull.Value, Me.TransferDate)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_startCalcDate", IIf(Me.StartCalcDate.Equals(Date.MinValue), DBNull.Value, Me.StartCalcDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_salvage", Me.Salvage))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_startCalcAmt", Me.StartCalcAmt))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_deprebase", Me.DepreBase))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_calcType", Me.CalcType.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_calcRate", Me.CalcRate))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_age", Me.Age))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_rentalrate", Me.RentalRate))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_DateIntervalUnit", Me.DateinterValUnit.Value))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_endCalcDate", IIf(Me.EndCalcDate.Equals(Date.MinValue), DBNull.Value, Me.EndCalcDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_balance", Me.Balance))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_startBalance", Me.StartBalance))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_saleDate", IIf(Me.SaleDate.Equals(Date.MinValue), DBNull.Value, Me.SaleDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_salePrice", Me.SalePrice))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_balanceAtSaleDate", IIf(Me.BalanceAtSaleDate.Equals(Date.MinValue), DBNull.Value, Me.BalanceAtSaleDate)))


      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_saleDocCode", Me.SaleDocCode))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_saleDocDate", IIf(Me.SaleDocDate.Equals(Date.MinValue), DBNull.Value, Me.SaleDocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buyer", Me.Buyer))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_InsuranceCode", Me.InsuranceCode))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_saftyCode", Me.SaftyCode))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_saftyCompany", Me.SaftyCompany))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_insurancePremium", Me.InsurancePremium))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_insuranceAge", Me.InsuranceAge))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_insuranceStartDate", IIf(Me.InsuranceStartDate.Equals(Date.MinValue), DBNull.Value, Me.InsuranceStartDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_InsuranceEndDate", IIf(Me.InsuranceEndDate.Equals(Date.MinValue), DBNull.Value, Me.InsuranceEndDate)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_remainValue", Me.RemainValue))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_depreopening", Me.DepreOpening))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_firstYearRate", Me.FirstYearRate))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_project", IIf(Me.Project.Valid, Me.Project.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

      If Not (Me.LCI Is Nothing) Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lci", IIf(Me.LCI.Originated, Me.LCI.Id, DBNull.Value)))
      End If

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", IIf(Me.Costcenter.Originated, Me.Costcenter.Id, DBNull.Value)))

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

      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

        ' Insert AssetImage ...
        If Me.Originated Then
          paramArrayList = New ArrayList
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
          Me.PrepareImageParams(paramArrayList)
          sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "Insert" & Me.TableName & "Image", sqlparams)
        End If
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_AssetRef", New SqlParameter() {New SqlParameter("@refto_id", Me.Id)})
        trans.Commit()
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Me.ResetID(oldid)
        Return New SaveErrorException(ex.Message)
      Catch ex As Exception
        trans.Rollback()
        Me.ResetID(oldid)
        Return New SaveErrorException(ex.Message)
      Finally
        conn.Close()
      End Try
    End Function

    Public Function GetDrForWithDraw() As DataRow

    End Function
#End Region

#Region "Items"
    Public Overloads Sub ReLoadItems()
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      LoadItems()
      Me.IsInitialized = True
    End Sub
    Public Overloads Sub ReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      Me.IsInitialized = True
    End Sub
    Private Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetAssetStocks" _
      , New SqlParameter("@asset_id", Me.Id) _
      )

      Dim i As Integer = 0
      Dim amt As Decimal = 0
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim dr As TreeRow = m_itemTable.Childs.Add
        dr("Linenumber") = i
        dr("DocType") = row("DocType")
        dr("MainCode") = row("MainCode")
        dr("MainName") = row("MainName")
        dr("ItemCode") = row("ItemCode")
        dr("ItemName") = row("ItemName")
        dr("FromCCcode") = row("FromCCcode")
        dr("FromCCname") = row("FromCCname")
        'If IsNumeric(row("Amount")) Then
        '  dr("Amount") = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
        'End If
      Next
    End Sub
#End Region
#Region "Items VArc Customize"
    Public Overloads Sub VReLoadItems()
      Me.VisInitialized = False
      m_VitemTable = VGetSchemaTable()
      VLoadItems()
      Me.VisInitialized = True
    End Sub
    Public Overloads Sub VReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.VisInitialized = False
      m_VitemTable = VGetSchemaTable()
      Me.VisInitialized = True
    End Sub
    Private Sub VLoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetVAssetStocks" _
      , New SqlParameter("@asset_id", Me.Id) _
      )

      Dim i As Integer = 0
      Dim amt As Decimal = 0
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim dr As TreeRow = m_VitemTable.Childs.Add
        dr("Linenumber") = i
        dr("DocType") = row("DocType")
        dr("DocCode") = row("DocCode")
        dr("DocDate") = row("DocDate")
        dr("FromCC") = row("FromCC")
        dr("ToCC") = row("ToCC")
        If IsNumeric(row("Amount")) Then
          dr("Amount") = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
        End If
      Next
    End Sub
    Public Shared Function VGetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("VAssetStock")

      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("DocType", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocDate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("FromCC", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ToCC", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      Return myDatatable
    End Function
    Public Shared Function VCreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "VAssetStock"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      ' Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "Linenumber"

      Dim csType As New TreeTextColumn
      csType.MappingName = "DocType"
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.DocTypeHeaderText}")
      csType.NullText = ""
      csType.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "DocCode"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True

      Dim csDate As New TreeTextColumn
      csDate.MappingName = "DocDate"
      csDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.DateHeaderText}")
      csDate.NullText = ""
      csDate.ReadOnly = True


      Dim csFromCc As New TreeTextColumn
      csFromCc.MappingName = "FromCC"
      csFromCc.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.FromCCHeaderText}")
      csFromCc.NullText = ""
      csFromCc.ReadOnly = True

      Dim csToCC As New TreeTextColumn
      csToCC.MappingName = "ToCC"
      csToCC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.ToCCHeaderText}")
      csToCC.NullText = ""
      csToCC.ReadOnly = True

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.ReadOnly = True

      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(csFromCc)
      dst.GridColumnStyles.Add(csToCC)
      'dst.GridColumnStyles.Add(csAmount)

      Return dst
    End Function
#End Region


#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "AssetInfo"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "AssetInfo"
    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'AssetInfo
      dpi = New DocPrintingItem
      dpi.Mapping = "AssetInfo"
      dpi.Value = Me.Code & ":" & Me.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AssetCode
      dpi = New DocPrintingItem
      dpi.Mapping = "AssetCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AssetName
      dpi = New DocPrintingItem
      dpi.Mapping = "AssetName"
      dpi.Value = Me.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AssetDetail
      dpi = New DocPrintingItem
      dpi.Mapping = "AssetDetail"
      dpi.Value = Me.Detail
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AssetStatus
      Dim statusText As String
      If Me.Canceled And Me.Status.Value = 4 Then 'ยกเลิก
        statusText = "ชำรุด,ยกเลิก"
      ElseIf Me.Status.Value = 4 Then  'ชำรุด
        statusText = "ชำรุด"
      ElseIf Me.Canceled Then
        statusText = "ยกเลิก"
      Else
        statusText = "ปกติ"
      End If
      dpi = New DocPrintingItem
      dpi.Mapping = "AssetStatus"
      dpi.Value = statusText
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'UnitInfo
      If Me.Unit.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "UnitInfo"
        dpi.Value = Me.Unit.Code & ":" & Me.Unit.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "UnitCode"
        dpi.Value = Me.Unit.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "UnitName"
        dpi.Value = Me.Unit.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'AssetTypeInfo
      If Me.Type.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "AssetTypeInfo"
        dpi.Value = Me.Type.Code & ":" & Me.Type.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "AssetTypeCode"
        dpi.Value = Me.Type.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "AssetTypeName"
        dpi.Value = Me.Type.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Dim MyDateinterValUnitText As String = Me.DateinterValUnit.Description
      'RentalRate
      dpi = New DocPrintingItem
      dpi.Mapping = "RentalRate"
      dpi.Value = Configuration.FormatToString(Me.RentalRate, DigitConfig.Price) & " บาท ต่อ " & MyDateinterValUnitText
      dpiColl.Add(dpi)

      'AccountInfo
      If Me.Account.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "AccountInfo"
        dpi.Value = Me.Account.Code & ":" & Me.Account.Name
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

      'DepreOpeningAccountInfo
      If Me.DepreOpeningAccount.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "DepreOpeningAccountInfo"
        dpi.Value = Me.DepreOpeningAccount.Code & ":" & Me.DepreOpeningAccount.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "DepreOpeningAccountCode"
        dpi.Value = Me.DepreOpeningAccount.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "DepreOpeningAccountName"
        dpi.Value = Me.DepreOpeningAccount.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'DepreAccountInfo
      If Me.DepreAccount.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "DepreAccountInfo"
        dpi.Value = Me.DepreAccount.Code & ":" & Me.DepreAccount.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "DepreAccountCode"
        dpi.Value = Me.DepreAccount.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "DepreAccountName"
        dpi.Value = Me.DepreAccount.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CostCenterInfo
      If Me.Costcenter.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "CostcenterInfo"
        dpi.Value = Me.Costcenter.Code & ":" & Me.Costcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CostcenterCode"
        dpi.Value = Me.Costcenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CostcenterName"
        dpi.Value = Me.Costcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Location
      dpi = New DocPrintingItem
      dpi.Mapping = "Location"
      dpi.Value = Me.Location
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.Datetime"
      dpiColl.Add(dpi)

      'CalcType
      dpi = New DocPrintingItem
      dpi.Mapping = "CalcType"
      dpi.Value = Me.CalcType.Description
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'Age
      dpi = New DocPrintingItem
      dpi.Mapping = "Age"
      dpi.Value = Me.Age
      dpi.DataType = "System.Int32"
      dpiColl.Add(dpi)

      'StartCalcDate
      dpi = New DocPrintingItem
      dpi.Mapping = "StartCalcDate"
      dpi.Value = Me.StartCalcDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'EndCalcDate
      dpi = New DocPrintingItem
      dpi.Mapping = "EndCalcDate"
      dpi.Value = Me.EndCalcDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'CalcRate
      dpi = New DocPrintingItem
      dpi.Mapping = "CalcRate"
      dpi.Value = Me.CalcRate
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'StartCalcAmt
      dpi = New DocPrintingItem
      dpi.Mapping = "StartCalcAmt"
      dpi.Value = Configuration.FormatToString(Me.StartCalcAmt, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'Salvage
      dpi = New DocPrintingItem
      dpi.Mapping = "Salvage"
      dpi.Value = Configuration.FormatToString(Me.Salvage, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'DepreOpenningAmt
      dpi = New DocPrintingItem
      dpi.Mapping = "DepreOpenningAmt"
      dpi.Value = Configuration.FormatToString(Me.DepreOpening, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'RemainingValue
      dpi = New DocPrintingItem
      dpi.Mapping = "RemainingValue"
      dpi.Value = Configuration.FormatToString(Me.RemainValue, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'BuyDate
      dpi = New DocPrintingItem
      dpi.Mapping = "BuyDate"
      dpi.Value = Me.BuyDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'BuyPrice
      dpi = New DocPrintingItem
      dpi.Mapping = "BuyPrice"
      dpi.Value = Configuration.FormatToString(Me.BuyPrice, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'BuyFrom
      dpi = New DocPrintingItem
      dpi.Mapping = "BuyFrom"
      dpi.Value = Me.BuyFrom
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'BuyDocCode
      dpi = New DocPrintingItem
      dpi.Mapping = "BuyDocCode"
      dpi.Value = Me.BuyDocCode
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'BuyDocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "BuyDocDate"
      dpi.Value = Me.BuyDocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'TransferDate
      dpi = New DocPrintingItem
      dpi.Mapping = "TransferDate"
      dpi.Value = Me.TransferDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'PicImage
      dpi = New DocPrintingItem
      dpi.Mapping = "PicImage"
      dpi.Value = Me.Image
      dpi.DataType = "System.Image"
      dpiColl.Add(dpi)

      '*********************************AssetSummary************************************
      Me.RefreshSummaryInfo()
      Me.RefreshLastModified(Nothing)
      Me.DepreciationCalc()
      'YTDDate
      dpi = New DocPrintingItem
      dpi.Mapping = "YTDDate"
      dpi.Value = Me.LastdateYTD.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'YTDInnerIncome
      dpi = New DocPrintingItem
      dpi.Mapping = "YTDInnerIncome"
      dpi.Value = Configuration.FormatToString(Me.InternalIncomeYTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'YTDOutterIncome
      dpi = New DocPrintingItem
      dpi.Mapping = "YTDOutterIncome"
      dpi.Value = Configuration.FormatToString(Me.ExternalIncomeYTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'YTDMantTotal
      dpi = New DocPrintingItem
      dpi.Mapping = "YTDMantTotal"
      dpi.Value = Configuration.FormatToString(Me.MaintenanceCostYTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'YTDDepre
      dpi = New DocPrintingItem
      dpi.Mapping = "YTDDepre"
      dpi.Value = Configuration.FormatToString(Me.DepreYTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'YTDProfit
      dpi = New DocPrintingItem
      dpi.Mapping = "YTDProfit"
      dpi.Value = Configuration.FormatToString(Me.ProfitYTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'LTDDate
      dpi = New DocPrintingItem
      dpi.Mapping = "LTDDate"
      dpi.Value = Me.LastdateLTD.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'LTDInnerIncome
      dpi = New DocPrintingItem
      dpi.Mapping = "LTDInnerIncome"
      dpi.Value = Configuration.FormatToString(Me.InternalIncomeLTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'LTDOutterIncome
      dpi = New DocPrintingItem
      dpi.Mapping = "LTDOutterIncome"
      dpi.Value = Configuration.FormatToString(Me.ExternalIncomeLTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'LTDMantTotal
      dpi = New DocPrintingItem
      dpi.Mapping = "LTDMantTotal"
      dpi.Value = Configuration.FormatToString(Me.MaintenanceCostLTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'LTDDepre
      dpi = New DocPrintingItem
      dpi.Mapping = "LTDDepre"
      dpi.Value = Configuration.FormatToString(Me.DepreLTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'LTDProfit
      dpi = New DocPrintingItem
      dpi.Mapping = "LTDProfit"
      dpi.Value = Configuration.FormatToString(Me.ProfitLTD, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)
      '*********************************AssetSummary************************************

      Return dpiColl
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAsset}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAsset", New SqlParameter() {New SqlParameter("@asset_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AssetIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
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

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.Costcenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.Costcenter = Value
      End Set
    End Property

    'Private Shared Sub Items()
    '  Throw New NotImplementedException
    'End Sub

    Public Shared Sub RefreshAllMinData()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetAssetMinDataCollection" _
    , Nothing)
      If ds.Tables(0).Rows.Count >= 1 Then
        m_assetSet = New DataTable
        m_assetSet = ds.Tables(0)
      End If
    End Sub

    Shared Function GetAssetSet() As DataTable
      If m_assetSet Is Nothing Then
        Asset.RefreshAllMinData()
      End If
      Return m_assetSet
    End Function

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AssetInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AssetCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AssetName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AssetDetail", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AssetStatus", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("UnitInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("UnitCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("UnitName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AssetTypeInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AssetTypeCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AssetTypeName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RentalRate", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AccountInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AccountCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AccountName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DepreOpeningAccountInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DepreOpeningAccountCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DepreOpeningAccountName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DepreAccountInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DepreAccountCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DepreAccountName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostcenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostcenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostcenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Location", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CalcType", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Age", "System.Int32"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("StartCalcDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("EndCalcDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CalcRate", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("StartCalcAmt", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Salvage", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DepreOpenningAmt", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RemainingValue", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BuyDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BuyPrice", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BuyFrom", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BuyDocCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BuyDocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransferDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("YTDDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("YTDInnerIncome", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("YTDOutterIncome", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("YTDMantTotal", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("YTDDepre", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("YTDProfit", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LTDDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LTDInnerIncome", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LTDOutterIncome", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LTDMantTotal", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LTDDepre", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LTDProfit", "System.Decimal"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

  End Class

  Public Class AssetForToollotSelection
    Inherits Asset

    Public Sub New()
      MyBase.New()
    End Sub

    Public Sub New(ByVal assetId As Integer)
      MyBase.New(assetId)
    End Sub
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "AssetForToollotSelection"
      End Get
    End Property
  End Class

  Public Class AssetOPB
    Inherits Asset
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetOPB.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetOPB.ListLabel}"
      End Get
    End Property
  End Class

  Public Class Depre
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IPrintableEntity, IHasToCostCenter, IHasFromCostCenter

#Region " Member "
    Private m_docdate As Date
    Private m_depredate As Date

    Private m_fromcc As CostCenter
    Private m_fromperson As Employee

    Private m_tocc As CostCenter
    Private m_toperson As Employee

    Private m_note As String

    Private m_je As JournalEntry

    Private m_itemCollection As DepreItemCollection
#End Region

#Region " Constructors "
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docdate = Now.Date
        .m_fromcc = New CostCenter
        .m_fromperson = New Employee

        .m_tocc = New CostCenter
        .m_toperson = New Employee

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docdate
      End With
      m_itemCollection = New DepreItemCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        ' m_docdate As Date
        'If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docdate") _
        'AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docdate") Then
        '  .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
        'End If
        ' m_depredate As Date
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_depredate") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_depredate") Then
          .m_depredate = CDate(dr(aliasPrefix & Me.Prefix & "_depredate"))
        End If
        ' m_fromcc As CostCenter
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromcc") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromcc") Then
          .m_fromcc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_fromcc")))
        End If
        ' m_fromperson As Employee
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromperson") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromperson") Then
          .m_fromperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_fromperson")))
        End If
        ' m_tocc As CostCenter
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_tocc") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_tocc") Then
          .m_tocc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_tocc")))
        End If
        ' m_toperson As Employee
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_toperson") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_toperson") Then
          .m_toperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_toperson")))
        End If
        ' m_note As String
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          Me.Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        .m_je = New JournalEntry(Me)

        m_itemCollection = New DepreItemCollection(Me)
      End With
    End Sub

#End Region

#Region " Properties "
    Public Property ItemCollection() As DepreItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As DepreItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property DocDate() As Date
      Get
        Return m_docdate
      End Get
      Set(ByVal Value As Date)
        m_docdate = Value
      End Set
    End Property
    Public Property DepreDate() As Date
      Get
        Return m_depredate
      End Get
      Set(ByVal Value As Date)
        m_depredate = Value
      End Set
    End Property

    Public Property FromCostcenter() As CostCenter
      Get
        Return m_fromcc
      End Get
      Set(ByVal Value As CostCenter)
        m_fromcc = Value
      End Set
    End Property
    Public Property FromPerson() As Employee
      Get
        Return m_fromperson
      End Get
      Set(ByVal Value As Employee)
        m_fromperson = Value
      End Set
    End Property

    Public Property ToCostcenter() As CostCenter
      Get
        Return m_tocc
      End Get
      Set(ByVal Value As CostCenter)
        m_tocc = Value
      End Set
    End Property
    Public Property ToPerson() As Employee
      Get
        Return m_toperson
      End Get
      Set(ByVal Value As Employee)
        m_toperson = Value
      End Set
    End Property

    Public Property Note() As String Implements IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
#End Region

#Region " Overrides "
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "depre"
      End Get
    End Property

    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "depre"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "Depre"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Depre.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Depre"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Depre"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Depre.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region

#Region " Shared "
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As TreeTable
      myDatatable = DepreItem.GetSchemaTable
      ' Add columns เพิ่มเติม
      Return myDatatable
    End Function
#End Region

#Region " Methods "
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_je.Id = oldje
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException

      If Me.ItemCollection.Count = 0 Then
        Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
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
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      If Me.m_je.Status.Value = 4 Then
        Me.Status.Value = 4
      End If
      If Me.Status.Value = 0 Then
        Me.m_je.Status.Value = 0
      End If
      If Me.Status.Value = -1 Then
        Me.Status.Value = 2
      End If

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_depredate", IIf(Me.DepreDate.Equals(Date.MinValue), DBNull.Value, Me.DepreDate)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromcc", IIf(Me.FromCostcenter.Originated, Me.FromCostcenter.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromperson", IIf(Me.FromPerson.Originated, Me.FromPerson.Id, DBNull.Value)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", IIf(Me.ToCostcenter.Originated, Me.ToCostcenter.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toperson", IIf(Me.ToPerson.Originated, Me.ToPerson.Id, DBNull.Value)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

      ' กำหนดการบันทึกผู้แก้ไข
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
      Dim oldjeid As Integer = Me.m_je.Id

      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1, -2, -5
              trans.Rollback()
              Me.ResetID(oldid, oldjeid)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid, oldjeid)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If

        SaveDetail(Me.Id, conn, trans, currentUserId)

        ' Save JournalEntry.
        If Me.m_je.Status.Value = -1 Then
          m_je.Status.Value = 3
        End If
        Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
        If Not IsNumeric(saveJeError.Message) Then
          trans.Rollback()
          ResetID(oldid, oldjeid)
          Return saveJeError
        Else
          Select Case CInt(saveJeError.Message)
            Case -1, -5
              trans.Rollback()
              ResetID(oldid, oldjeid)
              Return saveJeError
            Case -2
              'Post ไปแล้ว
              Return saveJeError
            Case Else
          End Select
        End If
        trans.Commit()
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Me.ResetID(oldid, oldjeid)
        Return New SaveErrorException(ex.ToString)
      Catch ex As Exception
        trans.Rollback()
        Me.ResetID(oldid, oldjeid)
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
    End Function
    'private function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal currentUserId As Integer) As Integer
      Dim sqlSelect As String = "Select * From DepreItem Where deprei_depre = " & Me.Id
      Dim da As New SqlDataAdapter(sqlSelect, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "DepreItem")

      Dim oldItems As New ArrayList
      With ds.Tables("DepreItem")
        For Each row As DataRow In .Rows
          oldItems.Add(row("deprei_entity"))
          row.Delete()
        Next
        Dim items As New ArrayList
        'For n As Integer = 0 To Me.MaxRowIndex
        '    Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
        '    If ValidateRow(itemRow) Then
        '        Dim item As New DepreItem
        '        item.Depre = Me
        '        item.CopyFromDataRow(itemRow)
        '        item.Depreculation(item.Entity)
        '        items.Add(item)
        '    End If
        'Next
        For Each oldId As Integer In oldItems
          Dim found As Boolean = False
          For Each item As DepreItem In items
            If oldId = item.Entity.Id Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UnlockLastDeprecalOfAsset" _
            , New SqlParameter("@asset_id", oldId) _
            , New SqlParameter("@depre_id", Me.Id))

            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "RollBackAssetCostCenter" _
            , New SqlParameter("@asset_id", oldId) _
            , New SqlParameter("@deprei_depre", Me.Id))

            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "RollBackAssetLastDepreDate" _
            , New SqlParameter("@asset_id", oldId) _
            , New SqlParameter("@deprei_depre", Me.Id))
          End If
        Next
        Dim i As Integer = 0
        For Each item As DepreItem In items
          i += 1
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "LockLastDeprecalOfAsset" _
          , New SqlParameter("@asset_id", item.Entity.Id) _
          , New SqlParameter("@depre_id", Me.Id))

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetCostCenter" _
          , New SqlParameter("@asset_id", item.Entity.Id) _
          , New SqlParameter("@cc_id", ValidIdOrDBNull(Me.ToCostcenter)))

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetLastDepreDate" _
          , New SqlParameter("@asset_id", item.Entity.Id) _
          , New SqlParameter("@asset_lastdepredate", ValidDateOrDBNull(Me.DepreDate.Date)))

          Dim dr As DataRow = .NewRow
          dr("deprei_depre") = Me.Id
          dr("deprei_linenumber") = i
          dr("deprei_entity") = Me.ValidIdOrDBNull(item.Entity)
          dr("deprei_lastestcalcdate") = Me.ValidDateOrDBNull(item.LastestCalcDate.Date)
          dr("deprei_depredate") = Me.ValidDateOrDBNull(Me.DepreDate.Date)
          dr("deprei_depreamnt") = item.Depreamnt
          dr("deprei_note") = item.Note
          dr("deprei_status") = Me.Status.Value
          dr("deprei_depreopening") = item.DepreOpeningBalanceamnt
          .Rows.Add(dr)
        Next
      End With
      Dim saveRtn As Integer
      Dim dt As DataTable = ds.Tables("DepreItem")
      ' First process deletes.
      saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      ' Next process updates.
      saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      ' Finally process inserts.
      saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
      Return saveRtn
    End Function
#End Region

    '#Region "TreeTable Handlers"
    '        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '            If Not Me.IsInitialized Then
    '                Return
    '            End If
    '            Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
    '            If ValidateRow(CType(e.Row, TreeRow)) Then
    '                If index = Me.m_itemTable.Childs.Count - 1 Then
    '                    Me.AddBlankRow(1)
    '                End If
    '                Dim pe As New PropertyChangedEventArgs
    '                pe.Name = "ItemChanged"
    '                Me.OnPropertyChanged(Me, pe)
    '                Me.m_itemTable.AcceptChanges()
    '            End If

    '        End Sub

    '        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '            If Not Me.IsInitialized Then
    '                Return
    '            End If
    '            Try
    '                Select Case e.Column.ColumnName.ToLower
    '                    Case "asset_code"
    '                        SetEntityValue(e)
    '                    Case Else

    '                End Select
    '                ValidateRow(e)
    '            Catch ex As Exception
    '                MessageBox.Show(ex.ToString)
    '            End Try
    '        End Sub

    '        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
    '            'Dim proposedCode As Object = e.Row("asset_code")
    '            'Select Case e.Column.ColumnName.ToLower
    '            '    Case "asset_code"
    '            '        proposedCode = e.ProposedValue
    '            'End Select
    '            'If IsDBNull(proposedCode) Then
    '            '    e.Row.SetColumnError("asset_code", Me.StringParserService.Parse("${res:Global.Error.CodeMissing}"))
    '            'Else
    '            '    e.Row.SetColumnError("asset_code", "")
    '            'End If
    '        End Sub
    '        ' ตรวจสอบ row ว่ามีค่าไหม
    '        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
    '            Dim proposedcqCode As Object = row("asset_code")
    '            If (IsDBNull(proposedcqCode) OrElse CStr(proposedcqCode) = "") Then
    '                Return False
    '            End If
    '            Return True
    '        End Function

    '        Private m_entitySetting As Boolean = False
    '        Public Sub ReCalculationAll()
    '            m_entitySetting = True
    '            For Each row As TreeRow In Me.ItemTable.Childs
    '                If ValidateRow(row) Then
    '                    ' คำนวณค่าพร้อมเลย ...
    '                    Dim oEntity As New Asset(CInt(row("asset_id")))
    '                    Dim depreItem As New depreItem
    '                    depreItem.Depre = Me
    '                    depreItem.Entity = oEntity
    '                    ' คำนวณค่า
    '                    depreItem.Depreculation(oEntity)
    '                    'Todo
    '                End If
    '            Next
    '            m_entitySetting = False
    '        End Sub
    '        Public Sub SetEntityValue(ByVal e As System.Data.DataColumnChangeEventArgs)
    '            Dim msgWarning As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

    '            m_entitySetting = True
    '            If e.ProposedValue.ToString.Length = 0 Then
    '                If e.Row(e.Column).ToString.Length <> 0 Then
    '                    If msgWarning.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {e.Row(e.Column).ToString}) Then
    '                        ClearRow(e)
    '                    Else
    '                        e.ProposedValue = e.Row(e.Column)
    '                    End If
    '                End If
    '                m_entitySetting = False
    '                Return
    '            End If
    '            Dim oEntity As New Asset(e.ProposedValue.ToString)
    '            If oEntity.Originated Then
    '                If Not oEntity.ValidCostCenter(Me.FromCostcenter) Then
    '                    ' เตือนไม่มีใน costcenter
    '                    e.ProposedValue = e.Row(e.Column)
    '                    msgWarning.ShowWarningFormatted("${res:Global.Error.NoAssetCostcenter}", Me.FromCostcenter.Name)
    '                    m_entitySetting = False
    '                    Return
    '                End If
    '                If oEntity.Status.Value <> 1 Then
    '                    ' เตือนไม่มีใน costcenter
    '                    e.ProposedValue = e.Row(e.Column)
    '                    msgWarning.ShowWarningFormatted("${res:Global.Error.AssetEqNotAvaliable}", oEntity.Code, oEntity.Status.Description)
    '                    m_entitySetting = False
    '                    Return
    '                End If
    '                Dim depreItem As New depreItem
    '                depreItem.Depre = Me
    '                depreItem.Entity = oEntity
    '                depreItem.CopyToDataRow(e)
    '            Else
    '                msgWarning.ShowMessageFormatted("${res:Global.Error.NoEqAsset}", New String() {e.ProposedValue.ToString})
    '                e.ProposedValue = e.Row(e.Column)
    '                m_entitySetting = False
    '                Return
    '            End If
    '            m_entitySetting = False
    '        End Sub
    '        Private Sub ClearRow(ByVal e As DataColumnChangeEventArgs)
    '            e.Row("asset_id") = DBNull.Value
    '            e.Row("asset_name") = DBNull.Value

    '            e.Row("deprei_age") = DBNull.Value
    '            e.Row("asset_startCalcDate") = DBNull.Value
    '            e.Row("deprei_price") = DBNull.Value
    '            e.Row("deprei_depreopening") = DBNull.Value
    '            e.Row("deprei_salvage") = DBNull.Value
    '            e.Row("deprei_depreamnt") = DBNull.Value
    '            e.Row("deprei_note") = DBNull.Value
    '        End Sub
    '#End Region

#Region " IGLAble "
    Private ReadOnly Property GetCurrentDepreOpening() As Decimal
      Get
        Dim currdeprevalue As Decimal

        Return currdeprevalue
      End Get
    End Property
    Private ReadOnly Property GetDepreOpening() As Decimal
      Get
        Dim deprevalue As Decimal

        Return deprevalue
      End Get
    End Property
    Public Property [Date]() As Date Implements IGLAble.Date
      Get
        Return Me.DocDate
      End Get
      Set(ByVal Value As Date)
        Me.DocDate = Value
      End Set
    End Property

    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                                                  , CommandType.StoredProcedure _
                                                  , "GetGLFormatForEntity" _
                                                  , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))

      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function

    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      If GetTotalDeprePriceValue > 0 Then

        jiColl.AddRange(Me.GetItemJournalEntries())

        ' DR. สินทรัพย์ถาวร        costcenter ใหม่           ji.Mapping = "I6.3"
        SetGLI6_3(jiColl)
        ' CR. สินทรัพย์ถาวร        costcenter เดิม           ji.Mapping = "I6.4"
        SetGLI6_4(jiColl)
      End If
      Return jiColl
    End Function

    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        Me.m_je = Value
      End Set
    End Property
    Private ReadOnly Property GetTotalDeprePriceValue() As Decimal
      Get
        Dim totalbuyprice As Decimal
        'For Each row As TreeRow In Me.ItemTable.Childs
        '    If ValidateRow(row) Then
        '        If Not row.IsNull("deprei_price") Then
        '            totalbuyprice += CDec(row("deprei_price"))
        '        End If
        '    End If
        'Next
        Return totalbuyprice
      End Get
    End Property
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      'Dim ji As New JournalEntryItem
      'Dim withdrawAccount As Account
      'For i As Integer = 0 To Me.MaxRowIndex
      '    Dim item As New DepreItem
      '    item.CopyFromDataRow(CType(Me.ItemTable.Rows(i), TreeRow))

      '    item.Depre = Me

      '    item.Depreculation(item.Entity)

      '    Dim depreAcctMatched As Boolean = False
      '    Dim noDepreAcctMatched As Boolean = False

      '    Dim depreOPBAcctMatched As Boolean = False
      '    Dim noDepreOPBAcctMatched As Boolean = False

      '    For Each addedJi As JournalEntryItem In jiColl
      '        If Not item.Entity Is Nothing Then
      '            'I6.2
      '            Dim depreAccount As Account
      '            If Not item.Entity.DepreOpeningAccount Is Nothing AndAlso item.Entity.DepreOpeningAccount.Originated Then
      '                depreAccount = item.Entity.DepreOpeningAccount
      '            End If
      '            If Not depreAccount Is Nothing AndAlso depreAccount.Originated Then
      '                If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = depreAccount.Id) And addedJi.Mapping = "I6.2" Then
      '                    addedJi.Amount += item.Depreamnt
      '                    depreAcctMatched = True
      '                End If
      '            ElseIf depreAccount Is Nothing OrElse Not depreAccount.Originated Then
      '                If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "I6.2" Then
      '                    addedJi.Amount += item.Depreamnt
      '                    noDepreAcctMatched = True
      '                End If
      '            End If

      '            'I6.1
      '            Dim depreOPBAccount As Account
      '            If Not item.Entity.DepreAccount Is Nothing AndAlso item.Entity.DepreAccount.Originated Then
      '                depreOPBAccount = item.Entity.DepreAccount
      '            End If
      '            If Not depreOPBAccount Is Nothing AndAlso depreOPBAccount.Originated Then
      '                If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = depreOPBAccount.Id) And addedJi.Mapping = "I6.1" Then
      '                    addedJi.Amount += item.Depreamnt
      '                    depreAcctMatched = True
      '                End If
      '            ElseIf depreOPBAccount Is Nothing OrElse Not depreOPBAccount.Originated Then
      '                If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "I6.1" Then
      '                    addedJi.Amount += item.Depreamnt
      '                    noDepreAcctMatched = True
      '                End If
      '            End If
      '        End If
      '    Next
      '    If Not item.Entity Is Nothing Then
      '        'I6.2
      '        Dim depreAccount As Account
      '        If Not item.Entity.DepreOpeningAccount Is Nothing AndAlso item.Entity.DepreOpeningAccount.Originated Then
      '            'ใช้ acct ในรายการ
      '            depreAccount = item.Entity.DepreOpeningAccount
      '        End If
      '        If Not depreAccount Is Nothing AndAlso depreAccount.Originated Then
      '            If Not depreAcctMatched Then
      '                ji = New JournalEntryItem
      '                ji.Mapping = "I6.2"
      '                ji.Amount += item.Depreamnt
      '                ji.Account = depreAccount
      '                If Me.FromCostcenter.Originated Then
      '                    ji.CostCenter = Me.FromCostcenter
      '                Else
      '                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '                End If
      '                jiColl.Add(ji)
      '            End If
      '        ElseIf depreAccount Is Nothing OrElse Not depreAccount.Originated Then
      '            If Not noDepreAcctMatched Then
      '                ji = New JournalEntryItem
      '                ji.Mapping = "I6.2"
      '                ji.Amount += item.Depreamnt
      '                If Me.FromCostcenter.Originated Then
      '                    ji.CostCenter = Me.FromCostcenter
      '                Else
      '                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '                End If
      '                jiColl.Add(ji)
      '            End If
      '        End If

      '        'I6.1
      '        Dim depreOPBAccount As Account
      '        If Not item.Entity.DepreAccount Is Nothing AndAlso item.Entity.DepreAccount.Originated Then
      '            'ใช้ acct ในรายการ
      '            depreOPBAccount = item.Entity.DepreAccount
      '        End If
      '        If Not depreOPBAccount Is Nothing AndAlso depreOPBAccount.Originated Then
      '            If Not depreAcctMatched Then
      '                ji = New JournalEntryItem
      '                ji.Mapping = "I6.1"
      '                ji.Amount += item.Depreamnt
      '                ji.Account = depreOPBAccount
      '                If Me.FromCostcenter.Originated Then
      '                    ji.CostCenter = Me.FromCostcenter
      '                Else
      '                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '                End If
      '                jiColl.Add(ji)
      '            End If
      '        ElseIf depreOPBAccount Is Nothing OrElse Not depreOPBAccount.Originated Then
      '            If Not noDepreAcctMatched Then
      '                ji = New JournalEntryItem
      '                ji.Mapping = "I6.1"
      '                ji.Amount += item.Depreamnt
      '                If Me.FromCostcenter.Originated Then
      '                    ji.CostCenter = Me.FromCostcenter
      '                Else
      '                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '                End If
      '                jiColl.Add(ji)
      '            End If
      '        End If
      '    End If

      'Next
      Return jiColl
    End Function
    ' DR. สินทรัพย์ถาวร        costcenter ใหม่           ji.Mapping = "I6.3"
    Private Sub SetGLI6_3(ByVal jiColl As JournalEntryItemCollection)
      'Dim ji As New JournalEntryItem
      'Dim ht As New Hashtable
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '    If ValidateRow(trow) Then
      '        Dim a As New Asset(CInt(trow("asset_id")))
      '        Dim toccacct As Account = a.Account
      '        If Not toccacct Is Nothing Then
      '            ht(toccacct.Id) = toccacct
      '        End If
      '    End If
      'Next
      'For Each acct As Account In ht.Values
      '    Dim Intotalamnt As Decimal = 0
      '    For i As Integer = Me.MaxRowIndex To 0 Step -1
      '        Dim row As TreeRow = Me.ItemTable.Childs(i)
      '        If ValidateRow(row) Then
      '            Dim a As New Asset(CInt(row("asset_id")))
      '            Dim toccacct As Account = a.Account
      '            If toccacct.Originated Then
      '                If Not toccacct Is Nothing _
      '                AndAlso toccacct.Id = acct.Id Then
      '                    If Not row.IsNull("deprei_price") Then
      '                        Intotalamnt += CDec(row("deprei_price"))
      '                    End If
      '                End If
      '            End If
      '        End If
      '    Next
      '    If Intotalamnt > 0 Then
      '        ji = New JournalEntryItem
      '        ji.Mapping = "I6.3"
      '        ji.Amount = Intotalamnt
      '        If acct.Originated Then
      '            ji.Account = acct
      '        End If
      '        ji.CostCenter = Me.ToCostcenter
      '        jiColl.Add(ji)
      '    End If
      'Next
    End Sub
    ' CR. สินทรัพย์ถาวร        costcenter เดิม           ji.Mapping = "I6.4"
    Private Sub SetGLI6_4(ByVal jiColl As JournalEntryItemCollection)
      'Dim ji As New JournalEntryItem
      'Dim ht As New Hashtable
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '    If ValidateRow(trow) Then
      '        Dim a As New Asset(CInt(trow("asset_id")))
      '        Dim toccacct As Account = a.Account
      '        If Not toccacct Is Nothing Then
      '            ht(toccacct.Id) = toccacct
      '        End If
      '    End If
      'Next
      'For Each acct As Account In ht.Values
      '    Dim Intotalamnt As Decimal = 0
      '    For i As Integer = Me.MaxRowIndex To 0 Step -1
      '        Dim row As TreeRow = Me.ItemTable.Childs(i)
      '        If ValidateRow(row) Then
      '            Dim a As New Asset(CInt(row("asset_id")))
      '            Dim toccacct As Account = a.Account
      '            If toccacct.Originated Then
      '                If Not toccacct Is Nothing _
      '                AndAlso toccacct.Id = acct.Id Then
      '                    If Not row.IsNull("deprei_price") Then
      '                        Intotalamnt += CDec(row("deprei_price"))
      '                    End If
      '                End If
      '            End If
      '        End If
      '    Next
      '    If Intotalamnt > 0 Then
      '        ji = New JournalEntryItem
      '        ji.Mapping = "I6.4"
      '        ji.Amount = Intotalamnt
      '        If acct.Originated Then
      '            ji.Account = acct
      '        End If
      '        ji.CostCenter = Me.FromCostcenter
      '        jiColl.Add(ji)
      '    End If
      'Next
    End Sub

#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "AssetTransfer"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "AssetTransfer"
    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      'Dim dpi As DocPrintingItem

      ''Code
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Code"
      'dpi.Value = Me.Code
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''DocDate
      'dpi = New DocPrintingItem
      'dpi.Mapping = "DocDate"
      'dpi.Value = Me.DocDate.ToShortDateString
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''TransferDate
      'dpi = New DocPrintingItem
      'dpi.Mapping = "TransferDate"
      'dpi.Value = Me.DepreDate.ToShortDateString
      'dpi.DataType = "System.DateTime"
      'dpiColl.Add(dpi)

      ''TransOutCCInfo
      'If Me.FromCostcenter.Originated Then
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "TransOutCCInfo"
      '    dpi.Value = FromCostcenter.Code & ":" & FromCostcenter.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "TransOutCCCode"
      '    dpi.Value = FromCostcenter.Code
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "TransOutCCName"
      '    dpi.Value = FromCostcenter.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      ''EmpTransOutInfo
      'If Me.FromPerson.Originated Then
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "EmpTransOutInfo"
      '    dpi.Value = FromPerson.Code & ":" & FromPerson.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "EmpTransOutCode"
      '    dpi.Value = FromPerson.Code
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "EmpTransOutName"
      '    dpi.Value = FromPerson.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      ''TransInCCInfo
      'If Me.ToCostcenter.Originated Then
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "TransInCCInfo"
      '    dpi.Value = Me.ToCostcenter.Code & ":" & Me.ToCostcenter.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "TransInCCCode"
      '    dpi.Value = Me.ToCostcenter.Code
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "TransInCCName"
      '    dpi.Value = Me.ToCostcenter.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      ''EmpTransInInfo
      'If Me.ToPerson.Originated Then
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "EmpTransInInfo"
      '    dpi.Value = Me.ToPerson.Code & ":" & Me.ToPerson.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "EmpTransInCode"
      '    dpi.Value = Me.ToPerson.Code
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "EmpTransInName"
      '    dpi.Value = Me.ToPerson.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      ''Note
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Note"
      'dpi.Value = Me.Note
      'dpi.DataType = "System.Datetime"
      'dpiColl.Add(dpi)

      'Dim sumBuyPrice As Decimal = 0
      'Dim sumDepreOpenning As Decimal = 0
      'Dim sumSalvage As Decimal = 0
      'Dim sumDeprePlus As Decimal = 0

      'Dim n As Integer = 0
      'For i As Integer = 0 To Me.MaxRowIndex
      '    Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
      '    If ValidateRow(itemRow) Then
      '        Dim item As New DepreItem
      '        item.Depre = Me
      '        item.CopyFromDataRow(itemRow)

      '        item.Depre = Me

      '        item.Depreculation(item.Entity)


      '        'Item.LineNumber
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.LineNumber"
      '        dpi.Value = n + 1
      '        dpi.DataType = "System.Int32"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.AssetCode
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.AssetCode"
      '        dpi.Value = item.Entity.Code
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.AssetName
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.AssetName"
      '        dpi.Value = item.Entity.Name
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.Age
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.Age"
      '        dpi.Value = item.Entity.Age
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.StartCalcDate
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.StartCalcDate"
      '        dpi.Value = item.Entity.StartCalcDate
      '        dpi.DataType = "System.DateTime"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.Price
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.Price"
      '        dpi.Value = Configuration.FormatToString(item.Entity.BuyPrice, DigitConfig.Price)
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)
      '        sumBuyPrice += item.Entity.BuyPrice

      '        'Item.DepreOpenning
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.DepreOpenning"
      '        'dpi.Value = Configuration.FormatToString(item.OmValue, DigitConfig.Price)
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)
      '        'sumDepreOpenning += item.OmValue

      '        'Item.Salvage
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.Salvage"
      '        dpi.Value = Configuration.FormatToString(item.Entity.Salvage, DigitConfig.Price)
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)
      '        sumSalvage += item.Entity.Salvage

      '        'Item.DeprePlus
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.DeprePlus"
      '        'dpi.Value = Configuration.FormatToString(item.AveDm, DigitConfig.Price)
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)
      '        'sumDeprePlus += item.AveDm

      '        n += 1
      '    End If
      'Next

      ''TotalPrice
      'dpi = New DocPrintingItem
      'dpi.Mapping = "TotalPrice"
      'dpi.Value = Configuration.FormatToString(sumBuyPrice, DigitConfig.Price)
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''TotalDepreOpenning
      'dpi = New DocPrintingItem
      'dpi.Mapping = "TotalDepreOpenning"
      'dpi.Value = Configuration.FormatToString(sumDepreOpenning, DigitConfig.Price)
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''TotalSalvage
      'dpi = New DocPrintingItem
      'dpi.Mapping = "TotalSalvage"
      'dpi.Value = Configuration.FormatToString(sumSalvage, DigitConfig.Price)
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''TotalDeprePlus
      'dpi = New DocPrintingItem
      'dpi.Mapping = "TotalDeprePlus"
      'dpi.Value = Configuration.FormatToString(sumDeprePlus, DigitConfig.Price)
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return Me.Status.Value <= 2
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteDepre}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try

        Dim sqlSelect As String = "Select * From DepreItem Where deprei_depre = " & Me.Id
        Dim da As New SqlDataAdapter(sqlSelect, conn)
        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "DepreItem")
        Dim oldItems As New ArrayList
        For Each row As DataRow In ds.Tables(0).Rows
          oldItems.Add(row("deprei_entity"))
          row.Delete()
        Next
        For Each oldId As Integer In oldItems
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UnlockLastDeprecalOfAsset" _
          , New SqlParameter("@asset_id", oldId) _
          , New SqlParameter("@depre_id", Me.Id))

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "RollBackAssetCostCenter" _
          , New SqlParameter("@asset_id", oldId) _
          , New SqlParameter("@deprei_depre", Me.Id))

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "RollBackAssetLastDepreDate" _
          , New SqlParameter("@asset_id", oldId) _
          , New SqlParameter("@deprei_depre", Me.Id))
        Next
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteDepre", New SqlParameter() {New SqlParameter("@depre_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.DepreIsReferencedCannotBeDeleted}")
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

    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.FromCostcenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.FromCostcenter = Value
      End Set
    End Property

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.ToCostcenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.ToCostcenter = Value
      End Set
    End Property
  End Class

  Public Class DepreItem

#Region "Members"
    Private m_depre As Depre

    Private m_entity As Asset
    Private m_lineNumber As Integer

    Private m_note As String
    Private m_lastestCalcDate As Date

    Private m_cc As CostCenter
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.Construct()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct()
      With Me
        .m_entity = New Asset
        m_cc = New CostCenter
        m_note = ""
      End With
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct()
      With Me
        ' m_entity As Asset
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
          .m_entity = New Asset(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
        End If
        ' m_lineNumber As Integer
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_linenumber") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_linenumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & Me.Prefix & "_linenumber"))
        End If
        ' m_note As String
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_lastestcalcdate") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_lastestcalcdate") Then
          .m_lastestCalcDate = CDate(dr(aliasPrefix & Me.Prefix & "_lastestcalcdate"))
        End If

        ' m_entity As Asset
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cc") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cc") Then
          .m_cc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_cc")))
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property Prefix() As String
      Get
        Return "deprei"
      End Get
    End Property

    Public Property LineNumber() As Integer
      Get
        Return m_lineNumber
      End Get
      Set(ByVal Value As Integer)
        m_lineNumber = Value
      End Set
    End Property
    Public Property Depre() As Depre
      Get
        Return m_depre
      End Get
      Set(ByVal Value As Depre)
        m_depre = Value
      End Set
    End Property
    Public Property Entity() As Asset
      Get
        Return m_entity
      End Get
      Set(ByVal Value As Asset)
        m_entity = Value
      End Set
    End Property
    Public Property CostCenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
      End Set
    End Property
    Public ReadOnly Property LastestCalcDate() As Date
      Get
        If m_lastestCalcDate.Equals(Date.MinValue) Then
          m_lastestCalcDate = Me.Entity.LastDepreDate
        End If
        Return m_lastestCalcDate
      End Get
    End Property
    ' หาจำนวนวันทั้งหมดในปีนั้น ๆ
    Private ReadOnly Property GetTotalOfYear(ByVal datevalue As Date) As Integer
      Get
        Dim dt As Date
        dt = DateSerial(datevalue.Year, 12, 31)
        Return dt.DayOfYear
      End Get
    End Property
    Public Property Note() As String
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim code As Object = row("code")
      Dim pri_itemname As Object = row("pri_itemname")
      Dim pri_entitytype As Object = row("pri_entitytype")
      Dim unit As Object = row("unit")
      Dim pri_qty As Object = row("pri_qty")

      Dim isBlankRow As Boolean = False
      If IsDBNull(pri_entitytype) Then
        isBlankRow = True
      End If
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Not isBlankRow Then
        Select Case CInt(pri_entitytype)
          Case 160, 162
            row.SetColumnError("pri_qty", "")
            row.SetColumnError("pri_itemname", "")
            row.SetColumnError("code", "")
          Case 0, 88, 89 'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(pri_itemname) OrElse pri_itemname.ToString.Length = 0 Then
              row.SetColumnError("pri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pri_itemname", "")
            End If
            If IsDBNull(pri_qty) OrElse Not IsNumeric(pri_qty) OrElse CDec(pri_qty) <= 0 Then
              row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("pri_qty", "")
            End If
            row.SetColumnError("code", "")
          Case 19 'เครื่องมือ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(pri_itemname) OrElse pri_itemname.ToString.Length = 0 Then
              row.SetColumnError("pri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pri_itemname", "")
            End If
            If IsDBNull(pri_qty) OrElse Not IsNumeric(pri_qty) OrElse CDec(pri_qty) <= 0 Then
              row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("pri_qty", "")
            End If
          Case 28 'F/A
            If IsDBNull(pri_itemname) OrElse pri_itemname.ToString.Length = 0 Then
              row.SetColumnError("pri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pri_itemname", "")
            End If
            If IsDBNull(pri_qty) OrElse Not IsNumeric(pri_qty) OrElse CDec(pri_qty) <= 0 Then
              row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("pri_qty", "")
            End If
            row.SetColumnError("code", "")
          Case 42 'LCI
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(pri_itemname) OrElse pri_itemname.ToString.Length = 0 Then
              row.SetColumnError("pri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pri_itemname", "")
            End If
            If IsDBNull(pri_qty) OrElse Not IsNumeric(pri_qty) OrElse CDec(pri_qty) <= 0 Then
              row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("pri_qty", "")
            End If
          Case Else
            Return
        End Select
      End If
    End Sub
    Public Function DupCode(ByVal myCode As String) As Boolean
      If Me.Depre Is Nothing Then
        Return False
      End If
      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As DepreItem In Me.Depre.ItemCollection
        If Not item Is Me Then
          Dim theCode As String = ""
          If Not item.Entity Is Nothing Then
            theCode = item.Entity.Code
          End If
          If Not theCode Is Nothing AndAlso theCode.Length > 0 Then
            If myCode.ToLower = theCode.ToString.ToLower Then
              Return True
            End If
          End If
        End If
      Next
      Return False
    End Function
    Public Sub Clear()
      Me.m_entity = New Asset
      Me.m_note = ""
    End Sub
    Public Sub SetItemCode(ByVal theCode As String)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If DupCode(theCode) Then
        Dim parserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {parserService.Parse("${res:Global.Entity.28}"), theCode})
        Return
      End If
      If theCode Is Nothing OrElse theCode.Length = 0 Then
        If Me.Entity.Code.Length <> 0 Then
          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {Me.Entity.Code}) Then
            Me.Clear()
          End If
        End If
        Return
      End If
      Dim a As New Asset(theCode)
      If Not a.Originated Then
        msgServ.ShowMessageFormatted("${res:Global.Error.NoAsset}", New String() {theCode})
        Return
      Else
        Me.m_entity = a
      End If
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.Depre.IsInitialized = False
      row("deprei_linenumber") = Me.LineNumber
      If Not Me.Entity Is Nothing AndAlso Me.Entity.Originated Then
        Me.DepreCalculation()
        row("asset_code") = Me.Entity.Code
        row("asset_name") = Me.Entity.Name
        row("asset_startCalcDate") = Me.Depre.ValidDateOrDBNull(Me.Entity.StartCalcDate)
        row("deprei_note") = Me.Note
        row("deprei_depreopening") = Configuration.FormatToString(Me.DepreOpeningBalanceamnt, DigitConfig.Price)
        row("deprei_depreamnt") = Configuration.FormatToString(Me.Depreamnt, DigitConfig.Price)
        row("deprei_price") = Configuration.FormatToString(Me.Entity.BuyPrice, DigitConfig.Price)
        row("deprei_salvage") = Configuration.FormatToString(Me.Entity.Salvage, DigitConfig.Price)
        row("deprei_age") = Configuration.FormatToString(Me.Entity.Age, DigitConfig.Int)
      Else
        row("asset_code") = DBNull.Value
        row("asset_name") = DBNull.Value
        row("asset_startCalcDate") = DBNull.Value
        row("deprei_price") = DBNull.Value
        row("deprei_salvage") = DBNull.Value
        row("deprei_age") = DBNull.Value
        row("deprei_depreopening") = DBNull.Value
        row("deprei_depreamnt") = DBNull.Value
        row("deprei_note") = DBNull.Value
      End If
      Me.Depre.IsInitialized = True
    End Sub
#End Region

#Region " Depreciation Calculation "

    Private m_depreamntinprocess As Decimal     ' ค่าเสื่อมถึงวันที่คำนวณ
    Private m_depreopeningamnt As Decimal       ' ค่าเสื่อมสะสมยกมา
    Private m_depreamnt As Decimal              ' ค่าเสื่อมสะสมที่ต้องการ
    Private m_remainingamnt As Decimal          ' ยอดคงเหลือ

    Public ReadOnly Property DepreamntInProcess() As Decimal
      Get
        Return m_depreamntinprocess
      End Get
    End Property
    Public ReadOnly Property DepreOpeningBalanceamnt() As Decimal
      Get
        Return m_depreopeningamnt
      End Get
    End Property
    Public ReadOnly Property Depreamnt() As Decimal
      Get
        Return m_depreamnt
      End Get
    End Property
    Public ReadOnly Property DepreRemainingamnt() As Decimal
      Get
        Return m_remainingamnt
      End Get
    End Property
    Public Sub DepreCalculation()
      If Me.Entity Is Nothing OrElse Not Me.Entity.Originated Then
        Return
      End If

      m_depreamntinprocess = 0
      m_depreopeningamnt = 0
      m_depreamnt = 0
      m_remainingamnt = 0

      If Not Me.LastestCalcDate.Equals(Date.MinValue) AndAlso Me.LastestCalcDate.Date < Me.Depre.DepreDate.Date Then
        m_depreopeningamnt = CDec(Me.Entity.DepreCalcAtDate(Me.LastestCalcDate.Date))
      End If
      m_depreamntinprocess = CDec(Me.Entity.DepreCalcAtDate(Me.Depre.DepreDate.Date))

      m_depreamnt = m_depreamntinprocess - m_depreopeningamnt

      Dim depreval As Decimal = Me.Entity.RemainValue
      m_remainingamnt = depreval - m_depreamntinprocess
    End Sub
#End Region

#Region " Shared Methods "
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("DepreItem")
      myDatatable.Columns.Add(New DataColumn("deprei_linenumber", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("asset_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("btnAsset", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("asset_name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("deprei_age", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("asset_startCalcDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("deprei_price", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("deprei_depreopening", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("deprei_salvage", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("deprei_depreamnt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("deprei_note", GetType(String)))

      Return myDatatable
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class DepreItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_depre As Depre
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As Depre)
      Me.m_depre = owner
      If Not Me.m_depre.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetDepreItems" _
      , New SqlParameter("@depre_id", Me.m_depre.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New DepreItem(row, "")
        item.Depre = m_depre
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As DepreItem
      Get
        Return CType(MyBase.List.Item(index), DepreItem)
      End Get
      Set(ByVal value As DepreItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim amt As Decimal = 0
        'For Each item As DepreItem In Me
        '    amt += Configuration.Format(item.Amount, DigitConfig.Price)
        'Next
        Return amt
      End Get
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each deprei As DepreItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        deprei.CopyToDataRow(newRow)
        deprei.ItemValidateRow(newRow)
        newRow.Tag = deprei
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As DepreItem) As Integer
      If Not m_depre Is Nothing Then
        value.Depre = m_depre
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As DepreItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As DepreItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As DepreItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As DepreItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As DepreItemEnumerator
      Return New DepreItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As DepreItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As DepreItem)
      If Not m_depre Is Nothing Then
        value.Depre = m_depre
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As DepreItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class DepreItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As DepreItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, DepreItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub

    End Class
  End Class

  Public Class EquipmentTool
#Region "members"
    Public EqtId As Integer
    Public EqtCode As String
    Public EqtName As String
    Public EqtType As Integer
    Public ItemId As Integer
    Public ItemCode As String
    Public ItemName As String
#End Region

#Region "Properties"

#End Region

    Sub New(ByVal pitemId As Integer, ByVal pitemType As Integer)
      ' TODO: Complete member initialization 
      ItemId = pitemId
      EqtType = pitemType

    End Sub

    Sub New()
      ' TODO: Complete member initialization 
    End Sub

  End Class
End Namespace
