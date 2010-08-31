Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic
Imports Longkong.Pojjaman.TextHelper

Imports Microsoft.VisualBasic.a

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class SimpleRefdocItem
    Inherits SimpleBusinessEntityBase
    Public Sub New()
      MyBase.New()
    End Sub
    Public Property Sequence As Integer
    Public Property Entity As IHasName
    Public Property EntityType As Integer
    Public Property Supplier As Supplier
  End Class
  Public Class EquipmentItem
    Inherits SimpleBusinessEntityBase
    Implements IHasRentalRate, IEqtItem, IHasImage, IHasParent
#Region "Members"
    Private m_equipment As Equipment

    'Private m_lineNumber As Integer
    'Private m_itemType As ItemType
    'Private m_entity As IHasName
    'Private m_entityName As String
    'Private m_unit As Unit
    'Public m_qty As Decimal
    'Private m_originQty As Decimal
    'Private m_orderedQty As Decimal
    'Private m_withdrawnQty As Decimal
    'Private m_note As String
    'Private m_conversion As Decimal = 1

    'Private m_unitprice As Decimal

    'Private m_WBSDistributeCollection As WBSDistributeCollection
    Private m_id As Integer
    'Private m_code As String
    Private m_name As String
    Private m_cc As CostCenter
    Private m_buydate As DateTime
    'Private m_buydoc As Decimal
    'Private m_buydoccode As String
    Private m_buydoc As SimpleRefdocItem 'SimpleBusinessEntityBase
    Private m_buycost As Decimal
    Private m_buysupplier As Supplier
    Private m_asset As Asset
    Private m_acctstatus As Integer
    Private m_serialnumber As String
    Private m_brand As String
    Private m_license As String
    Private m_description As String
    Private m_unit As Unit 'Munit
    Private m_rentalrate As Decimal
    Private m_rentalunit As Unit
    Private m_lastEditDate As DateTime
    Private m_autogen As Boolean
    Private m_image As Image
    Private m_currentstatus As EqtStatus
    Private m_currentcc As CostCenter
#End Region

#Region "Constructors"
    'Public Sub New()
    '  MyBase.New()
    '  m_WBSDistributeCollection = New WBSDistributeCollection
    '  AddHandler m_WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
    'End Sub
    'Public Sub New(ByVal id As Integer, ByVal line As Integer)
    '  Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
    '  , CommandType.StoredProcedure _
    '  , "GetEquipmentItems" _
    '  , New SqlParameter("@pr_id", id) _
    '  , New SqlParameter("@pri_linenumber", line) _
    '  )
    '  Me.Construct(ds.Tables(0).Rows(0), "")
    '  Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
    '  AddHandler wbsdColl.PropertyChanged, AddressOf Me.WBSChangedHandler
    '  m_WBSDistributeCollection = wbsdColl
    '  If ds.Tables.Count > 1 Then
    '    For Each wbsRow As DataRow In ds.Tables(1).Select("priw_prilinenumber=" & Me.LineNumber)
    '      Dim wbsd As New WBSDistribute(wbsRow, "")
    '      wbsdColl.Add(wbsd)
    '    Next
    '  End If
    'End Sub
    Public Sub New()
      MyBase.New()
      Me.m_cc = New CostCenter
      Me.m_buydate = Date.MinValue
      ' Me.m_buydoc = New ISimpleEntity
      Me.m_buydoc = New SimpleRefdocItem 'SimpleBusinessEntityBase
      Me.m_buysupplier = New Supplier
      Me.m_asset = New Asset
      Me.m_unit = New Unit
      Me.m_rentalunit = New Unit
      Me.m_currentcc = New CostCenter
      Me.m_currentstatus = New EqtStatus(2)
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal assetwriteoff As AssetWriteOff)
      MyBase.Construct(dr, "")
      Dim drh As New DataRowHelper(dr)
      With Me
        .Id = drh.GetValue(Of Integer)("eqtid")
        .Code = drh.GetValue(Of String)("eqtcode")
        .m_name = drh.GetValue(Of String)("eqtname")
        .m_cc = Costcenter.GetCCMinDataById(drh.GetValue(Of Integer)("eqtcc"))
        .m_unit = Unit.GetUnitById(drh.GetValue(Of Integer)("eqtunit"))
      End With
    End Sub
    Public Sub New(ByVal thecode As String)
      MyBase.New(thecode)

    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)

    End Sub
    Public Sub LoadImage()
      If Id <= 0 Then
        Return
      End If

      Dim sqlConString As String = Me.RealConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select eqi_image from Equipmentimage where eqi_id = " & Me.Id

      conn.Open()

      Dim cmd As SqlCommand = conn.CreateCommand
      cmd.CommandText = sql

      Dim custReader As SqlDataReader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))
      If custReader.Read Then
        LoadImage(custReader)
      End If
    End Sub
    Public Sub LoadImage(ByVal reader As IDataReader)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      m_image = Field.GetImage(reader, "eqi_image")
      Try
        If Image Is Nothing Then
          m_image = Image.FromFile(myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Entity.BlankImage}"))
        End If
      Catch ex As Exception

      End Try
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        Dim drh As New DataRowHelper(dr)

        'Dim eqid As Integer = drh.GetValue(Of Integer)("eqi_id")
        'm_equipment = New Equipment(eqid)

        'm_id = drh.GetValue(Of Integer)("eqi_id")
        'm_code = drh.GetValue(Of String)("eqi_code")
        m_name = drh.GetValue(Of String)("eqi_name")

        Dim ccid As Integer = drh.GetValue(Of Integer)("eqi_cc")
        m_cc = New CostCenter(ccid)

        m_buydate = drh.GetValue(Of DateTime)("eqi_buydate")
        m_lastEditDate = drh.GetValue(Of DateTime)("eqi_lastEditDate")
        m_buydoc = New SimpleRefdocItem 'SimpleBusinessEntityBase
        m_buydoc.Id = drh.GetValue(Of Integer)("eqi_buydoc")
        m_buydoc.Code = drh.GetValue(Of String)("eqi_buydoccode")

        m_buycost = drh.GetValue(Of Decimal)("eqi_buycost")

        Dim supplierid As Integer = drh.GetValue(Of Integer)("eqi_buysupplier")
        m_buysupplier = New Supplier(supplierid)

        Dim assetid As Integer = drh.GetValue(Of Integer)("eqi_asset")
        m_asset = New Asset(assetid)

        m_acctstatus = drh.GetValue(Of Integer)("eqi_acctstatus")

        m_serialnumber = drh.GetValue(Of String)("eqi_serialnumber")

        m_brand = drh.GetValue(Of String)("eqi_brand")

        m_license = drh.GetValue(Of String)("eqi_license")

        m_description = drh.GetValue(Of String)("eqi_description")

        Dim unitid As Integer = drh.GetValue(Of Integer)("eqi_unit")
        m_unit = New Unit(unitid)

        m_rentalrate = drh.GetValue(Of Decimal)("eqi_rentalrate")

        Dim unitid2 As Integer = drh.GetValue(Of Integer)("eqi_rentalunit")
        m_rentalunit = New Unit(unitid2)

        Dim currstatus As Integer = drh.GetValue(Of Integer)("eqi_currentstatus")
        m_currentstatus = New EqtStatus(currstatus)

        Dim currCCId As Integer = drh.GetValue(Of Integer)("eqi_currentcc")
        m_currentcc = New CostCenter(currCCId)

        Me.IsReferenced = drh.GetValue(Of Boolean)("isreferenced")
        LoadImage()
      End With
    End Sub
    Protected Overloads Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Shares"
    Public Shared Function GetEquipmentItem(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEntity As EquipmentItem) As Boolean
      Dim entity As New EquipmentItem(txtCode.Text)
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
    Public Shared Function GetListDatatable(ByVal ParamArray filters() As Filter) As TreeTable

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim dt As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetEqiForSelectionList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("EqItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("EqCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("m_eq", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("m_eqi_id", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RentalRate", GetType(Decimal)))
      'myDatatable.Columns.Add(New DataColumn("OrderedQty", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      'myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
      'myDatatable.Columns.Add(New DataColumn("ReceivingDate", GetType(Date)))
      'myDatatable.Columns.Add(New DataColumn("DummyReceivingDate", GetType(Date)))
      'myDatatable.Columns.Add(New DataColumn("Requestor", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CurrentStatus", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("CurrentCostCenter", GetType(Decimal)))

      'Dim inValidIds As ArrayList = GetEqIdWithOnlyNoteItem(dt)
      For Each tableRow As DataRow In dt.Rows
        'If Not inValidIds.Contains(CInt(tableRow("eqi_id"))) Then
        Dim eqi As New EquipmentItem(tableRow, "")
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("EqCode") = tableRow("eq_code")
        row("Code") = tableRow("eqi_code")
        row("m_eq") = tableRow("eqi_eq")
        row("CurrentStatus") = tableRow("eqi_currentstatus")
        row("CurrentCostCenter") = tableRow("eqi_currentcc")


        Dim eqId As Integer
        If Not row.IsNull("m_eq") Then
          eqId = CInt(row("m_eq"))
        End If

        row("m_eqi_id") = tableRow("eqi_id")
        row("RentalRate") = tableRow("eqi_rentalrate")
        row("Name") = tableRow("eq_name")

        row("Entity") = eqi.Name
        row("Qty") = 1

        If Not tableRow.IsNull("ccinfo") Then
          row("CostCenter") = tableRow("ccinfo")
        End If
        row.State = RowExpandState.None


        row.Tag = eqi
      Next
      Return myDatatable
    End Function
    Private Shared Function GetEqIdWithOnlyNoteItem(ByVal dt As DataTable) As ArrayList
      Dim arr As New ArrayList
      Dim tmpId As Integer = 0
      For Each tableRow As DataRow In dt.Rows
        If tmpId <> CInt(tableRow("eqi_id")) Then
          tmpId = CInt(tableRow("eqi_id"))
          If Not arr.Contains(tmpId) Then
            arr.Add(tmpId)
          End If
        End If
      Next
      Dim realArr As New ArrayList
      For Each id As Integer In arr
        Dim rows As DataRow() = dt.Select("eqi_id = " & id)
        Dim found As Boolean = False
        'For Each row As DataRow In rows
        '  Dim eqi As New EquipmentItem(row, "")
        '  If eqi.OrderedQty <> 0 Or eqi.Qty <> 0 Then
        '    found = True
        '    Exit For
        '  End If
        'Next
        If Not found Then
          If Not realArr.Contains(id) Then
            realArr.Add(id)
          End If
        End If
      Next
      Return realArr
    End Function

    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current

      Dim paramArrayList As New ArrayList

      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.Autogen Then
        Me.Code = Me.GetNextCode
      End If
      Me.Autogen = False

      paramArrayList.Add(returnVal)

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_eq", Me.ValidIdOrDBNull(Me.equipment)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", Me.ValidIdOrDBNull(Me.Costcenter)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buydate", Me.ValidDateOrDBNull(Me.Buydate.Date)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buydoc", Me.ValidIdOrDBNull(Me.Buydoc)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buydoccode", Me.Buydoc.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buycost", Me.Buycost))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buysupplier", Me.ValidIdOrDBNull(Me.Buydoc.Supplier)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_asset", Me.ValidIdOrDBNull(Me.Asset)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acctstatus", Me.Acctstatus))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_serialnumber", Me.Serailnumber))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_brand", Me.Brand))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_license", Me.License))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_description", Me.Description))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_unit", Me.ValidIdOrDBNull(Me.Unit)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_rentalrate", Me.Rentalrate))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_rentalunit", Me.ValidIdOrDBNull(Me.Rentalunit)))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_originator", Me.Code))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_originDate", Me.Code))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lastEditDate", Me.Code))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lastEditor", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_currentstatus", Me.CurrentStatus.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_currentcc", Me.ValidIdOrDBNull(Me.CurrentCostCenter)))

      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      ' สร้าง SqlParameter จาก ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim oldid As Integer = Me.Id
      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        Select Case CInt(returnVal.Value)
          Case -1, -5
            ResetID(oldid)
            Return New SaveErrorException(returnVal.Value.ToString)
        End Select

        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1, -2, -5
              Me.ResetID(oldid)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          Me.ResetID(oldid)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If

        ' Save Image process 
        'If Not Me.Image Is Nothing Then
        If Me.IsImageDirty Then
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertEquipmentItemimage" _
                   , New SqlParameter("@eqi_id", Me.Id) _
                   , New SqlParameter("@eqi_image", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(Me.Image)))
        End If
        'End If

        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        Me.ResetID(oldid)
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As Exception
        Me.ResetID(oldid)
        Return New SaveErrorException(returnVal.Value.ToString)
      End Try
    End Function
#End Region

#Region "Properties"
    Public Property IsImageDirty As Boolean
    Public Property IsDirty As Boolean
    Public Property IsReferenced As Boolean
    Public Property oldcode As String
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Equipmentitem"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "eqi"
      End Get
    End Property
    Public Property equipment As Equipment
      Get
        Return m_equipment
      End Get
      Set(ByVal value As Equipment)
        m_equipment = value
      End Set
    End Property
    Public ReadOnly Property parent As SimpleBusinessEntityBase Implements IHasParent.parent
      Get
        Return CType(m_equipment, SimpleBusinessEntityBase)
      End Get
    End Property

    Public ReadOnly Property EntityId As Integer Implements IEqtItem.EntityId
      Get
        Return MyBase.EntityId
      End Get
    End Property

    'Public Overrides Property Id As Integer Implements IHasName.Id
    '  Get
    '    Return m_id
    '  End Get
    '  Set(ByVal value As Integer)
    '    m_id = value
    '  End Set
    'End Property
    Public Property Autogen As Boolean
      Get
        Return m_autogen
      End Get
      Set(ByVal value As Boolean)
        m_autogen = value
      End Set
    End Property
    'Public Overrides Property Code As String Implements IHasName.Code
    '  Get
    '    Return m_code
    '  End Get
    '  Set(ByVal value As String)
    '    m_code = value
    '  End Set
    'End Property
    Public Property Name As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal value As String)
        m_name = value
      End Set
    End Property
    Public Property Costcenter As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal value As CostCenter)
        m_cc = value
      End Set
    End Property

    Public Property Buydate As Date
      Get
        Return m_buydate
      End Get
      Set(ByVal value As Date)
        m_buydate = value
      End Set
    End Property
    Public Property LastEditDate As Date
      Get
        Return m_lastEditDate
      End Get
      Set(ByVal value As Date)
        m_lastEditDate = value
      End Set
    End Property
    Public Property Buydoc As SimpleRefdocItem
      Get
        Return m_buydoc
      End Get
      Set(ByVal value As SimpleRefdocItem)
        m_buydoc = value
      End Set
    End Property

    Public Property Buycost As Decimal
      Get
        Return m_buycost
      End Get
      Set(ByVal value As Decimal)
        m_buycost = value
      End Set
    End Property
    Public Property Supplier As Supplier
      Get
        Return m_buysupplier
      End Get
      Set(ByVal value As Supplier)
        m_buysupplier = value
      End Set
    End Property
    Public Property Asset As Asset
      Get
        Return m_asset
      End Get
      Set(ByVal value As Asset)
        m_asset = value
      End Set
    End Property

    Public Property Acctstatus As Integer
      Get
        Return m_acctstatus
      End Get
      Set(ByVal value As Integer)
        m_acctstatus = value
      End Set
    End Property
    Public Property Serailnumber As String
      Get
        Return m_serialnumber
      End Get
      Set(ByVal value As String)
        m_serialnumber = value
      End Set
    End Property
    Public Property Brand As String
      Get
        Return m_brand
      End Get
      Set(ByVal value As String)
        m_brand = value
      End Set
    End Property
    Public Property License As String
      Get
        Return m_license
      End Get
      Set(ByVal value As String)
        m_license = value
      End Set
    End Property
    Public Property Description As String
      Get
        Return m_description
      End Get
      Set(ByVal value As String)
        m_description = value
      End Set
    End Property
    Public Property Unit As Unit Implements IEqtItem.Unit
      Get
        Return m_unit
      End Get
      Set(ByVal value As Unit)
        m_unit = value
      End Set
    End Property
    Public Property Rentalrate As Decimal Implements IHasRentalRate.RentalRate
      Get
        Return m_rentalrate
      End Get
      Set(ByVal value As Decimal)
        m_rentalrate = value
      End Set
    End Property
    Public Property Rentalunit As Unit
      Get
        Return m_rentalunit
      End Get
      Set(ByVal value As Unit)
        m_rentalunit = value
      End Set
    End Property
    Public Property Image() As Image Implements IHasImage.Image
      Get
        Return m_image
      End Get
      Set(ByVal Value As Image)
        m_image = Value
        'OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property CurrentStatus As EqtStatus
      Get
        Return m_currentstatus
      End Get
      Set(ByVal value As EqtStatus)
        m_currentstatus = value
      End Set
    End Property
    Public Property CurrentCostCenter As CostCenter
      Get
        Return m_currentcc
      End Get
      Set(ByVal value As CostCenter)
        m_currentcc = value
      End Set
    End Property

#End Region
    Public Sub SetCurrentCostCenter(ByVal cc As CostCenter)
      m_currentcc = cc
    End Sub
    Public Sub Clear()
      'Me.m_entity = New BlankItem("")
      'Me.m_entityName = ""
      'Me.m_qty = 0
      'Me.m_originQty = 0
      'Me.m_orderedQty = 0
      'Me.m_unit = New Unit
      'Me.m_unitprice = 0
      'Me.m_note = ""
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If

      Try
        '    Me.Pr.IsInitialized = False
        row("code") = Me.Code
        row("name") = Me.Name
        row("status") = "ว่างเสมอ"
        row("costcenter") = Me.Costcenter.Code
        '    Me.Pr.IsInitialized = True
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub

    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code
      If Me.AutoCodeFormat.Format.Length > 0 Then
        autoCodeFormat = Me.AutoCodeFormat.Format
      Else
        autoCodeFormat = Me.Code
      End If
      'Entity.GetAutoCodeFormat(Me.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(autoCodeFormat, Me)

      pattern = CodeGenerator.GetPattern(pattern)

      Dim lastCode As String
      lastCode = Me.GetLastCode(pattern)
      Dim newCode As String = _
      CodeGenerator.Generate(autoCodeFormat, lastCode, Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(autoCodeFormat, newCode, Me)
      End While
      Return newCode
    End Function
    Public Overrides Function DuplicateCode(ByVal newCode As String) As Boolean
      If MyBase.DuplicateCode(newCode) Then
        Return True
      End If
      Return Me.equipment.ItemCollection.DupCodeInCollection(newCode)
    End Function
  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class EquipmentItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_equipment As Equipment
    Private m_currentItem As EquipmentItem
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As Equipment)
      Me.m_equipment = owner
      If Not Me.m_equipment.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEquipmentItems" _
      , New SqlParameter("@equipment_id", Me.m_equipment.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New EquipmentItem(row, "")
        item.equipment = m_equipment
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As EquipmentItem
      Get
        Return CType(MyBase.List.Item(index), EquipmentItem)
      End Get
      Set(ByVal value As EquipmentItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    'Public ReadOnly Property Amount() As Decimal
    '  Get
    '    Dim amt As Decimal = 0    '    For Each item As EquipmentItem In Me
    '      amt += Configuration.Format(item.Amount, DigitConfig.Price)
    '    Next
    '    Return amt
    '  End Get
    'End Property
    Public Property CurrentItem() As EquipmentItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As EquipmentItem)
        m_currentItem = Value
      End Set
    End Property

    Public Property AutocodeFormats As List(Of AutoCodeFormat)
    Public ReadOnly Property haveEmpty As Boolean
      Get
        Dim isemp As Boolean = False
        For Each eqi As EquipmentItem In Me
          If eqi.Name.Length = 0 Or eqi.Code.Length = 0 Then
            isemp = True
            Exit For
          End If
        Next
        Return isemp
      End Get
    End Property
#End Region

#Region "Shared"
    'Public Shared Function CreateListTableStyle() As DataGridTableStyle
    '  Dim dst As New DataGridTableStyle
    '  dst.MappingName = "EquipmentItems"

    '  Dim csSelected As New DataGridCheckBoxColumn
    '  csSelected.MappingName = "Selected"
    '  csSelected.HeaderText = ""

    '  Dim csDescription As New PlusMinusTreeTextColumn
    '  csDescription.MappingName = "Entity"
    '  csDescription.HeaderText = "Entity"
    '  csDescription.NullText = ""
    '  csDescription.Width = 180
    '  csDescription.ReadOnly = True

    '  Dim csQty As New TreeTextColumn
    '  csQty.MappingName = "Qty"
    '  csQty.HeaderText = "Qty"
    '  csQty.NullText = ""
    '  csQty.ReadOnly = True

    '  Dim csOrderedQty As New TreeTextColumn
    '  csOrderedQty.MappingName = "OrderedQty"
    '  csOrderedQty.HeaderText = "OrderedQty"
    '  csOrderedQty.NullText = ""
    '  csOrderedQty.ReadOnly = True

    '  Dim csDate As New TreeTextColumn
    '  csDate.MappingName = "DummyDate"
    '  csDate.HeaderText = "Date"
    '  csDate.NullText = ""
    '  csDate.DataAlignment = HorizontalAlignment.Center
    '  csDate.Width = 100
    '  csDate.Format = "d"
    '  csDate.ReadOnly = True

    '  Dim csReceivingDate As New TreeTextColumn
    '  csReceivingDate.MappingName = "DummyReceivingDate"
    '  csReceivingDate.HeaderText = "ReceivingDate"
    '  csReceivingDate.NullText = ""
    '  csReceivingDate.DataAlignment = HorizontalAlignment.Center
    '  csReceivingDate.Width = 100
    '  csReceivingDate.Format = "d"
    '  csReceivingDate.ReadOnly = True

    '  Dim csRequestor As New TreeTextColumn
    '  csRequestor.MappingName = "Requestor"
    '  csRequestor.HeaderText = "Requestor"
    '  csRequestor.NullText = ""
    '  csRequestor.DataAlignment = HorizontalAlignment.Center
    '  csRequestor.Width = 100
    '  csRequestor.ReadOnly = True

    '  Dim csCostCenter As New TreeTextColumn
    '  csCostCenter.MappingName = "CostCenter"
    '  csCostCenter.HeaderText = "CostCenter"
    '  csCostCenter.NullText = ""
    '  csCostCenter.DataAlignment = HorizontalAlignment.Center
    '  csCostCenter.Width = 100
    '  csCostCenter.ReadOnly = True

    '  dst.GridColumnStyles.Add(csSelected)
    '  dst.GridColumnStyles.Add(csDescription)
    '  dst.GridColumnStyles.Add(csQty)
    '  dst.GridColumnStyles.Add(csOrderedQty)
    '  dst.GridColumnStyles.Add(csDate)
    '  dst.GridColumnStyles.Add(csReceivingDate)
    '  'dst.GridColumnStyles.Add(csRequestor)
    '  'dst.GridColumnStyles.Add(csCostCenter)
    '  Return dst
    'End Function
    'Public Shared Function GetListDatatable(ByVal ParamArray filters() As Filter) As TreeTable

    '  Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
    '  Dim params() As SqlParameter
    '  If Not filters Is Nothing AndAlso filters.Length > 0 Then
    '    ReDim params(filters.Length - 1)
    '    For i As Integer = 0 To filters.Length - 1
    '      params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
    '    Next
    '  End If
    '  Dim dt As DataTable
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetEquipmentItemsList", params)
    '  dt = ds.Tables(0)

    '  Dim myDatatable As New TreeTable("EquipmentItems")
    '  myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
    '  myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("m_pr", GetType(Integer)))
    '  myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("OrderedQty", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("ReceivingDate", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("DummyReceivingDate", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("Requestor", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))

    '  For Each tableRow As DataRow In dt.Rows
    '    Dim pri As New EquipmentItem(tableRow, "")
    '    Dim row As TreeRow = myDatatable.Childs.Add
    '    row("Selected") = False
    '    row("Code") = tableRow("pr_code")
    '    row("m_pr") = tableRow("pri_pr")
    '    row("Linenumber") = tableRow("pri_linenumber")
    '    row("Date") = tableRow("pr_docdate")
    '    row("ReceivingDate") = tableRow("pr_receivingdate")

    '    Dim entityText As String = ""
    '    If Not pri.ItemType Is Nothing Then
    '      entityText &= pri.ItemType.Description & ":"
    '    End If
    '    If Not pri.Entity.Code Is Nothing AndAlso pri.Entity.Code.Length > 0 Then
    '      entityText &= pri.Entity.Code & ":"
    '    End If
    '    If Not pri.Entity.Name Is Nothing AndAlso pri.Entity.Name.Length > 0 Then
    '      entityText &= pri.Entity.Name
    '    End If
    '    row("Entity") = entityText
    '    row("Qty") = pri.Qty
    '    row("OrderedQty") = pri.OrderedQty
    '    row("Requestor") = tableRow("requestorinfo")
    '    row("CostCenter") = tableRow("ccinfo")
    '    row.State = RowExpandState.None
    '  Next
    '  Return myDatatable
    'End Function
#End Region

#Region "Class Methods"

    Public Sub SetItems(ByVal items As BasketItemCollection, ByVal newCode As String, ByVal userId As Integer, Optional ByVal targetType As Integer = -1)
      For i As Integer = 0 To items.Count - 1
        If Not items(i).Tag Is Nothing AndAlso TypeOf items(i).Tag Is TreeRow Then
          '      '-----------------LCI Items--------------------

          Dim item As StockBasketItem = CType(items(i), StockBasketItem)
          Dim drh As New DataRowHelper(CType(item.Tag, TreeRow))
          Dim childrow As TreeRow = CType(item.Tag, TreeRow)
          Dim neweqitem As New EquipmentItem

          If Me.AutocodeFormats Is Nothing Then
            Me.AutocodeFormats = New List(Of AutoCodeFormat)
            Me.AutocodeFormats = Entity.GetNewAutoCodeFormats(346, userId)
          End If
          neweqitem.Code = Me.AutocodeFormats(0).Format
          neweqitem.Autogen = True
          neweqitem.Name = childrow("Description").ToString
          neweqitem.Costcenter = CostCenter.GetCCMinDataById(CInt(childrow("ccId")))
          neweqitem.Unit = Unit.GetUnitById(drh.GetValue(Of Integer)("UnitId"))
          neweqitem.Buycost = drh.GetValue(Of Decimal)("UnitCost")
          neweqitem.Buydoc = New SimpleRefdocItem

          neweqitem.Buydoc.Id = drh.GetValue(Of Integer)("Id")
          neweqitem.Buydoc.Code = drh.GetValue(Of String)("Code")
          neweqitem.Buydoc.Sequence = drh.GetValue(Of Integer)("Sequence")

          neweqitem.Buydate = drh.GetValue(Of DateTime)("DocDate")
          neweqitem.CurrentStatus = New EqtStatus(10)

          Trace.WriteLine(drh.GetValue(Of String)("Code").ToString)
          Trace.WriteLine(drh.GetValue(Of String)("DocDate").ToString)
          Trace.WriteLine(drh.GetValue(Of Integer)("Sequence").ToString)

          Me.Add(neweqitem)

        End If
      Next
      '  RefreshBudget()
    End Sub

    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each eqi As EquipmentItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        eqi.CopyToDataRow(newRow)
        'eqi.ItemValidateRow(newRow)
        newRow.Tag = eqi
      Next
    End Sub
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "EquipmentItems"

      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Selected"
      csSelected.HeaderText = ""

      Dim csDescription As New PlusMinusColumn
      csDescription.MappingName = "Entity"
      csDescription.HeaderText = "Entity"
      csDescription.NullText = ""
      csDescription.Width = 180

      Dim csQty As New HeaderAndDataAlignColumn
      csQty.MappingName = "Qty"
      csQty.HeaderText = "Qty"
      csQty.NullText = ""

      Dim csDate As New HeaderAndDataAlignColumn
      csDate.MappingName = "Date"
      csDate.HeaderText = "Date"
      csDate.NullText = ""
      csDate.DataAlignment = HorizontalAlignment.Center
      csDate.Width = 100
      csDate.Format = "d"


      Dim csRequestor As New HeaderAndDataAlignColumn
      csRequestor.MappingName = "Requestor"
      csRequestor.HeaderText = "Requestor"
      csRequestor.NullText = ""
      csRequestor.DataAlignment = HorizontalAlignment.Center
      csRequestor.Width = 100

      Dim csCostCenter As New HeaderAndDataAlignColumn
      csCostCenter.MappingName = "CostCenter"
      csCostCenter.HeaderText = "CostCenter"
      csCostCenter.NullText = ""
      csCostCenter.DataAlignment = HorizontalAlignment.Center
      csCostCenter.Width = 100


      dst.GridColumnStyles.Add(csSelected)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(csRequestor)
      dst.GridColumnStyles.Add(csCostCenter)
      Return dst
    End Function
    'Public Function GetDataTable() As ExpandableRowDataTable
    '  Dim myDatatable As New ExpandableRowDataTable("EquipmentItems")
    '  myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
    '  myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("m_pr", GetType(Integer)))
    '  myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Qty", GetType(Decimal)))
    '  myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("Requestor", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("SortIndex", GetType(Decimal)))

    '  For Each item As EquipmentItem In Me.List
    '    Dim row As ExpandableDataRow = myDatatable.Add(item.Pr.Code & item.LineNumber)
    '    row("Selected") = False
    '    row("Code") = item.Pr.Code
    '    row("m_pr") = item.Pr.Id
    '    row("Linenumber") = item.LineNumber
    '    row("Date") = item.Pr.DocDate
    '    Dim entityText As String = ""
    '    If Not item.ItemType Is Nothing Then
    '      entityText &= item.ItemType.Description & ":"
    '    End If
    '    If Not item.Entity.Code Is Nothing AndAlso item.Entity.Code.Length > 0 Then
    '      entityText &= item.Entity.Code & ":"
    '    End If
    '    If Not item.Entity.Name Is Nothing AndAlso item.Entity.Name.Length > 0 Then
    '      entityText &= item.Entity.Name
    '    End If
    '    row("Entity") = entityText
    '    row("Qty") = item.Qty
    '    row("Requestor") = item.Pr.Requestor.Code & ":" & item.Pr.Requestor.Name
    '    row("CostCenter") = item.Pr.CostCenter.Code & ":" & item.Pr.CostCenter.Name
    '    row.State = PlusMinusState.UnderParent
    '  Next
    '  Return myDatatable
    'End Function

#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As EquipmentItem) As Integer
      If Not m_equipment Is Nothing Then
        value.equipment = m_equipment
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As EquipmentItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As EquipmentItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As EquipmentItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As EquipmentItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    'Public Shadows Function GetEnumerator() As PRItemEnumerator
    '  Return New PRItemEnumerator(Me)
    'End Function
    Public Function IndexOf(ByVal value As EquipmentItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As EquipmentItem)
      If Not m_equipment Is Nothing Then
        value.equipment = m_equipment
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentItem)
      'For Each wbsd As WBSDistribute In value.WBSDistributeCollection
      '  value.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      'Next
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      'For Each wbsd As WBSDistribute In Me(index).WBSDistributeCollection
      '  Me(index).WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      'Next
      MyBase.List.RemoveAt(index)
    End Sub
    Public Function Count() As Integer
      Dim i As Integer
      For Each Item As EquipmentItem In Me
        i += 1
      Next
      Return i
    End Function
    Public Function DupCodeInCollection(ByVal newCode As String) As Boolean
      For Each eqi As EquipmentItem In Me
        If eqi.Code = newCode Then
          Return True
        End If
      Next
      Return False
    End Function
#End Region


    Public Class PRItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As PRItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, PRItem)
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

  Public Class EqItemForSelection
    Inherits EquipmentItem
    Public CC As New CostCenter
    Public entityId As Integer

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "EqItemForSelection"
      End Get
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "EqItemForSelection"
      End Get
    End Property
  End Class


End Namespace

