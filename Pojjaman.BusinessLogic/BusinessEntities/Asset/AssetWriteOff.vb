Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic

  Public Class AssetWriteOff
    Inherits SimpleBusinessEntityBase
    Implements IVatable, IWitholdingTaxable, IBillIssuable, IPrintableEntity, IGLAble, IHasIBillablePerson, IHasFromCostCenter, ICancelable, ICheckPeriod


#Region "Members"
    Private m_customer As Customer

    Private m_docDate As Date

    Private m_fromCostCenter As CostCenter  'ไม่มีผลต่อการเลือกสินทรัพย์
    Private m_fromCostCenterPerson As Employee

    Private m_poDocCode As String
    Private m_poDocDate As Date

    Private m_vat As Vat
    Private m_whtcol As WitholdingTaxCollection
    Private m_receive As Receive
    Private m_je As JournalEntry

    Private m_note As String
    Private m_creditPeriod As Integer

    Private m_discount As Discount
    Private m_taxRate As Decimal
    Private m_taxType As TaxType

    'Private m_itemTable As TreeTable
    Private m_itemcollection As AssetWriteOffItemCollection

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      'ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      'AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      'ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      'AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      'ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      'AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      'ReLoadItems(ds, aliasPrefix)
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      'AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      'ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      'AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
      'ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      'AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      'AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      'AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docDate = Now.Date
        .m_customer = New Customer
        .m_creditPeriod = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_discount = New Discount("")
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        Me.m_fromCostCenter = New CostCenter
        Me.m_fromCostCenterPerson = New Employee
        .AutoCodeFormat = New AutoCodeFormat(Me)

        .m_itemcollection = New AssetWriteOffItemCollection
        .Status = New CheckStatus(-1)
        '----------------------------Tab Entities-----------------------------------------
        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 0

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        .m_receive = New Receive(Me)
        .m_receive.DocDate = Me.m_docDate
        '----------------------------End Tab Entities-----------------------------------------
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      Dim drh As New DataRowHelper(dr)
      With Me

        If dr.Table.Columns.Contains("cust_id") Then
          If Not dr.IsNull("cust_id") Then
            .m_customer = New Customer(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "eqtstock_entity") AndAlso Not dr.IsNull(aliasPrefix & "eqtstock_entity") Then
            .m_customer = New Customer(CInt(dr(aliasPrefix & "eqtstock_entity")))
          End If
        End If
        'If Not dr.IsNull(aliasPrefix & "eqtstock_discrate") Then
        '  .m_creditPeriod = CInt(dr(aliasPrefix & "eqtstock_creditPeriod"))
        'End If
        If Not dr.IsNull(aliasPrefix & "eqtstock_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "eqtstock_discrate")))
        End If

        ''==== จำเป็นต้องมีหรือไม่
        'If dr.Table.Columns.Contains("stock_otherdoccode") AndAlso Not dr.IsNull(aliasPrefix & "stock_otherdoccode") Then
        '  .m_poDocCode = CStr(dr(aliasPrefix & "stock_otherdoccode"))
        'End If
        'If dr.Table.Columns.Contains("stock_otherdocdate") AndAlso Not dr.IsNull(aliasPrefix & "stock_otherdocdate") Then
        '  .m_poDocDate = CDate(dr(aliasPrefix & "stock_otherdocdate"))
        'End If
        ''==============
        '======ไม่มี จำเป็นต้องมีหรือป่าว
        If dr.Table.Columns.Contains(aliasPrefix & "eqtstock_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "eqtstock_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "eqtstock_creditperiod"))
        End If
        '======ไม่มี จำเป็นต้องมีหรือป่าว

        If dr.Table.Columns.Contains(aliasPrefix & "tocostcenterperson.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "tocostcenterperson.employee_id") Then
            .m_fromCostCenterPerson = New Employee(dr, "tocostcenterperson.")
          End If
        Else
          If dr.Table.Columns.Contains("eqtstock_fromccperson") AndAlso Not dr.IsNull(aliasPrefix & "eqtstock_fromccperson") Then
            .m_fromCostCenterPerson = New Employee(CInt(dr(aliasPrefix & "eqtstock_fromccperson")))
          End If
        End If

        .m_fromCostCenter = CostCenter.GetCCMinDataById(drh.GetValue(Of Integer)("eqtstock_fromcc"))

        If dr.Table.Columns.Contains("eqtstock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "eqtstock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "eqtstock_docDate"))
        End If

        If dr.Table.Columns.Contains("eqtstock_note") AndAlso Not dr.IsNull(aliasPrefix & "eqtstock_note") Then
          .m_note = CStr(dr(aliasPrefix & "eqtstock_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "eqtstock_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "eqtstock_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "eqtstock_taxtype")))
        End If
        ' PO Tax Rate
        If Not dr.IsNull(aliasPrefix & "eqtstock_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "eqtstock_taxrate"))
        End If

        If Not dr.IsNull(aliasPrefix & "eqtstock_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "eqtstock_discrate")))
        End If

        .m_itemcollection = New AssetWriteOffItemCollection(Me)
        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 0

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_receive = New Receive(Me)

        .m_je = New JournalEntry(Me)
      End With
    End Sub
#End Region

#Region "Properties"
    'Public Property ItemTable() As TreeTable    '  Get    '    Return m_itemTable    '  End Get    '  Set(ByVal Value As TreeTable)    '    m_itemTable = Value    '  End Set    'End Property

    Public Property Customer() As Customer      Get        Return m_customer      End Get      Set(ByVal Value As Customer)        Dim oldPerson As IBillablePerson = m_customer
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If        m_customer = Value      End Set    End Property    Public Property DocDate() As Date Implements IVatable.Date, IWitholdingTaxable.Date, IReceivable.Date, IGLAble.Date, ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public Property FromCostCenter() As CostCenter      Get        Return m_fromCostCenter      End Get      Set(ByVal Value As CostCenter)        m_fromCostCenter = Value      End Set    End Property    Public Property FromCostCenterPerson() As Employee      Get        Return m_fromCostCenterPerson      End Get      Set(ByVal Value As Employee)        m_fromCostCenterPerson = Value      End Set    End Property    Public ReadOnly Property ToAccount() As Account      Get        If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then          Return Me.FromCostCenter.StoreAccount
        End If      End Get    End Property    'Public Property PoDocCode() As String    '  Get    '    Return m_poDocCode    '  End Get    '  Set(ByVal Value As String)    '    m_poDocCode = Value    '  End Set    'End Property    'Public Property PoDocDate() As Date    '  Get    '    Return m_poDocDate    '  End Get    '  Set(ByVal Value As Date)    '    m_poDocDate = Value    '  End Set    'End Property    Public Property Vat() As Vat Implements IVatable.Vat      Get        Return m_vat      End Get      Set(ByVal Value As Vat)        m_vat = Value      End Set    End Property    Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
      Get
        Return m_whtcol
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_whtcol = Value
      End Set
    End Property    Public Property Note() As String Implements IReceivable.Note, IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        m_creditPeriod = Value      End Set    End Property    'Private m_gross As Decimal    Public ReadOnly Property Gross() As Decimal      Get        Dim ret As Decimal = 0        For Each wri As AssetWriteOffItem In Me.Itemcollection          If TypeOf wri.Entity Is Asset Then            ret += wri.Amount
          End If
        Next        Return ret 'm_gross      End Get    End Property    Public Property Discount() As Discount      Get        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property DiscountAmount() As Decimal      Get        Me.Discount.AmountBeforeDiscount = Me.Gross        Return Me.Discount.Amount      End Get    End Property    Public Property TaxRate() As Decimal      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Private m_taxbase As Decimal    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1 '"แยก"
            Return m_taxbase          Case 2 '"รวม"
            If Me.DiscountAmount = 0 Then 'แบบ basic ไม่มีส่วนลดท้ายบิล
              Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
            End If
            Return m_taxbase        End Select
        Return m_taxbase
      End Get
      Set(ByVal Value As Decimal)
        m_taxbase = Value
      End Set
    End Property    Public Property TaxType() As TaxType      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Itemcollection As AssetWriteOffItemCollection      Get
        Return m_itemcollection
      End Get
      Set(ByVal value As AssetWriteOffItemCollection)

      End Set
    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case Else '1,2
            Return (Me.TaxRate * Me.TaxBase) / 100        End Select      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.Gross - Me.DiscountAmount
          Case 1 '"แยก"
            Return Me.Gross - Me.DiscountAmount
          Case 2 '"รวม"
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
        End Select      End Get    End Property    Public ReadOnly Property AfterTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.BeforeTax
          Case 1 '"แยก"
            Return Me.BeforeTax + Me.TaxAmount
          Case 2 '"รวม"
            Return Me.Gross - Me.DiscountAmount
        End Select      End Get    End Property    Public Property AssetRemain As Decimal    Public Property AssetWriteOff As Decimal    Public Property AssetWriteOffDepre As Decimal    Public Property AssetCost As Decimal    Public Property AssetProfitLoss As Decimal    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AssetWriteoff"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "eqtstock"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "eqtstock"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetWriteoff.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AssetWriteoff"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AssetWriteoff"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetWriteoff.ListLabel}"
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
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("AssetWriteoff")
      myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Type", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("EntityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitId", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainingQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("BuyPrice", GetType(String))) 'ราคาสินทรัพย์ตอนซื้อ
      myDatatable.Columns.Add(New DataColumn("AssetAmount", GetType(String))) 'มูลค่าสินทรัพย์
      myDatatable.Columns.Add(New DataColumn("DepreAmount", GetType(String))) 'ค่าเสื่อมสะสม
      myDatatable.Columns.Add(New DataColumn("RemainingAmount", GetType(String))) 'ราคาสินทรัพย์ตอนซื้อ

      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitPrice", GetType(String)))  'ราคาขาย
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String))) 'มูลค่าขาย  
      myDatatable.Columns.Add(New DataColumn("WriteOffAmount", GetType(String))) 'มูลค่าหักค่าสินทรัพย์

      myDatatable.Columns.Add(New DataColumn("Barrier2", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("WriteOffDepreAmount", GetType(String))) 'ค่าเสื่อมสะสม Write Off
      myDatatable.Columns.Add(New DataColumn("CostAmount", GetType(String))) 'ต้นทุนแล้ว
      myDatatable.Columns.Add(New DataColumn("P/L", GetType(String))) 'ต้นทุนแล้ว
      'myDatatable.Columns.Add(New DataColumn("stocki_discrate", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("asset_acct", GetType(Integer)))
      'myDatatable.Columns.Add(New DataColumn("asset_depreopeningacct", GetType(Integer)))
      'myDatatable.Columns.Add(New DataColumn("AccountCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Account", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DepreAccount", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("AccountButton", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("stocki_unvatable", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Parent", GetType(Integer)))

      Return myDatatable
    End Function

    Public Shared Function GetListDatatable(ByVal procName As String, ByVal ParamArray filters() As Filter) As DataSet
      Dim sqlConString As String = ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, procName, params)
      Return ds
    End Function
#End Region

#Region "Methods"
    Public Sub RefreshSummaryParent()
      Dim arrAssParentItm As New ArrayList
      Dim arrAssChildItm As New ArrayList
      For Each itm As AssetWriteOffItem In Me.Itemcollection
        If TypeOf itm.Entity Is Asset AndAlso itm.HasChild Then
          itm.AssetAmount = 0
          itm.Amount = 0
          itm.WriteOffAmount = 0
          itm.WriteOffDepreAmount = 0
          arrAssParentItm.Add(itm)
        ElseIf TypeOf itm.Entity Is Asset AndAlso Not itm.HasChild Then
          arrAssChildItm.Add(itm)
        Else
          itm.AccDepre = 0
          arrAssChildItm.Add(itm)
        End If
      Next
      'Summary จากลูกไปหาแม่
      For Each itm As AssetWriteOffItem In arrAssParentItm
        If TypeOf itm.Entity Is Asset AndAlso itm.HasChild Then
          For Each childItm As AssetWriteOffItem In arrAssChildItm
            If itm.Asset.Id = childItm.Asset.Id AndAlso itm.Asset.Id > 0 Then
              'Summary จากลูกไปหาแม่
              itm.AssetAmount += childItm.AssetAmount
              itm.Amount += childItm.Amount
              itm.WriteOffAmount += childItm.WriteOffAmount
              'itm.WriteOffDepreAmount += childItm.WriteOffDepreAmount
            End If
          Next
        End If
      Next

      'เฉลี่ยจากแม่ไปหาลูก
      For Each childitem As AssetWriteOffItem In arrAssChildItm
        For Each paritem As AssetWriteOffItem In arrAssParentItm
          If childitem.Asset.Id = paritem.Asset.Id AndAlso childitem.Asset.Id > 0 Then
            'เฉลี่ยจากแม่ไปหาลูก
            If paritem.AssetAmount = 0 Then
              childitem.AccDepre = 0
            Else
              childitem.AccDepre = (childitem.AssetAmount / paritem.AssetAmount) * paritem.AccDepre
            End If
          End If
        Next
      Next

      'Summary จากลูกไปหาแม่
      For Each itm As AssetWriteOffItem In arrAssParentItm
        If TypeOf itm.Entity Is Asset AndAlso itm.HasChild Then
          For Each childItm As AssetWriteOffItem In arrAssChildItm
            If itm.Asset.Id = childItm.Asset.Id AndAlso itm.Asset.Id > 0 Then
              'Summary จากลูกไปหาแม่          
              itm.WriteOffDepreAmount += childItm.WriteOffDepreAmount
            End If
          Next
        End If
      Next
    End Sub
    Public Sub RefreshAssetSummary()
      AssetRemain = 0      AssetWriteOff = 0      AssetWriteOffDepre = 0      AssetCost = 0      AssetProfitLoss = 0
      For Each wri As AssetWriteOffItem In Me.Itemcollection
        If TypeOf wri.Entity Is Asset Then
          AssetRemain += wri.AssetRemainAmount          AssetWriteOff += wri.WriteOffAmount          AssetWriteOffDepre += wri.WriteOffDepreAmount          AssetCost += wri.CostAmount          AssetProfitLoss += wri.ProfitLoss
        End If
      Next
    End Sub
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer, ByVal oldvat As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_receive.Id = oldreceive
      Me.m_vat.Id = oldvat
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
      Me.m_je.Id = oldje
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException



      ValidateError = Me.Vat.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.WitholdingTaxCollection.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.Receive.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If




      Return New SaveErrorException("0")

    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Me.RefreshTaxBase()
        If Me.Gross > 0 AndAlso (Me.Customer Is Nothing OrElse Not Me.Customer.Originated) Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoCustomer}"))
        End If

        If Me.Itemcollection.Count <= 0 Then
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

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_receive.Status.Value = 4
          Me.m_whtcol.SetStatus(4)
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = 0 Then
          Me.m_je.Status.Value = 0
          Me.m_receive.Status.Value = 0
          Me.m_whtcol.SetStatus(0)
          Me.m_vat.Status.Value = 0
        End If
        If Me.Status.Value = -1 Then
          Me.Status = New CheckStatus(2)
        End If

        '---- AutoCode Format --------
        Dim oldcode As String
        Dim oldautogen As Boolean
        Dim oldjecode As String
        Dim oldjeautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
        oldjecode = Me.m_je.Code
        oldjeautogen = Me.m_je.AutoGen

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.Customer.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Customer.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocCode", Me.PoDocCode))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocDate", ValidDateOrDBNull(Me.PoDocDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toAcct", ValidIdOrDBNull(Me.ToAccount)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ""))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromCCPerson", ValidIdOrDBNull(Me.FromCostCenterPerson)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromcc", ValidIdOrDBNull(Me.FromCostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discRate", Me.Discount.Rate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discAmt", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.TaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.TaxAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_afterTax", Me.AfterTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docstatus", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
        Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
        If Not IsNumeric(ValidateError2.Message) Then
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return ValidateError2
        End If
        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()


        Dim oldid As Integer = Me.Id
        Dim oldreceive As Integer = m_receive.Id
        Dim oldvat As Integer = m_vat.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If
        Dim oldje As Integer = m_je.Id
        Try
          Try
            '--Generate Check--==================================================
            '--การสร้าง Check ใบใหม่จะได้ Id มาเก็บไว้ที่ Receive ด้วยจึงต้องวาง Code ไว้ก่อน Save Receive
            Dim subsaveerror As SaveErrorException = SubSaveFirst(conn, currentUserId)
            If Not IsNumeric(subsaveerror.Message) Then
              Return subsaveerror
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          trans = conn.BeginTransaction()
          ''Main Save Block
          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2
                  trans.Rollback()
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If

            Dim Assetlist As New List(Of String)

            For Each awi As AssetWriteOffItem In Itemcollection
              If awi.ItemType.Value = 28 Then
                Assetlist.Add(awi.Entity.Id.ToString)
              End If
            Next

            'ChangeOldItemStatus(conn, trans)
            Dim saveItemError As SaveErrorException = Me.SaveDetail(Me.Id, conn, trans, Assetlist)
            If Not IsNumeric(saveItemError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveItemError
            Else
              Select Case CInt(saveItemError.Message)
                Case -1, -2
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveItemError
                Case Else
              End Select
            End If
            If Not Me.FromCostCenter Is Nothing Then
              Me.m_receive.CcId = Me.FromCostCenter.Id
              Me.m_whtcol.SetCCId(Me.FromCostCenter.Id)
              Me.m_vat.SetCCId(Me.FromCostCenter.Id)
            End If

            '----Update Write off amt Asset List ----'
            UpdateAssetWriteOffAmt(Me.Id, Assetlist, conn, trans)
            '----------------------------------------'


            Dim savePaymentError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
            If Not IsNumeric(savePaymentError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return savePaymentError
            Else
              Select Case CInt(savePaymentError.Message)
                Case -1, -2
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return savePaymentError
                Case Else
              End Select

            End If
            Me.m_vat.SetRefDocMaximumTaxBase(Me.GetMaximumTaxBase)
            Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveVatError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveVatError
            Else
              Select Case CInt(saveVatError.Message)
                Case -1, -2
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveVatError
                Case Else
              End Select
            End If

            If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
              Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
              If Not IsNumeric(saveWhtError.Message) Then
                trans.Rollback()
                ResetID(oldid, oldreceive, oldvat, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveWhtError
              Else
                Select Case CInt(saveWhtError.Message)
                  Case -1, -2, -5
                    trans.Rollback()
                    ResetID(oldid, oldreceive, oldvat, oldje)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveWhtError
                  Case Else
                End Select
              End If
            End If

            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            End If

            '********************************************
            If Not Me.JournalEntry.ManualFormat Then
              If Not (Me.m_je.GLFormat.Originated) Then
                Dim glf As GLFormat = Me.GetDefaultGLFormat
                If Not glf Is Nothing Then
                  m_je.SetGLFormat(glf)
                End If
              End If
            End If
            '********************************************
            Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveJeError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveJeError
            Else
              Select Case CInt(saveJeError.Message)
                Case -1, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveJeError
                Case -2
                  'Post ไปแล้ว
                  Return saveJeError
                Case Else
              End Select
            End If

            '==============================AUTOGEN==========================================
            Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
            If Not IsNumeric(saveAutoCodeError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetWriteoffStatus" _
            ', New SqlParameter("@stock_id", Me.Id))

            trans.Commit()
            'Catch ex As Exception
            '  trans.Rollback()
            '  Me.ResetID(oldid, oldreceive, oldvat, oldje)
            '  Return New SaveErrorException(ex.ToString)
            'End Try
          Catch ex As SqlException
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          End Try

          'Sub Save Block
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          Try
            Dim subsaveerror As SaveErrorException = SubSave2(conn, currentUserId)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try
          'Sub Save Block

          Return New SaveErrorException(returnVal.Value.ToString)
          'Complete Save
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function

    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans As SqlTransaction = conn.BeginTransaction


      Try
        '==============================eqtSTOCKFIFO=========================================
        'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (Teeraboon)
        If Not Me.IsReferenced Then
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertEqtStockiFIFO", New SqlParameter("@eqtstock_id", Me.Id), _
                                                                                                New SqlParameter("@tostatus", 9), _
                                                                                                New SqlParameter("@fromstatus", 9) _
                                                                                                )
        End If
        '==============================eqtSTOCKFIFO=========================================

        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAW_DepreRef" _
       , New SqlParameter("@stock_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQTStockRef" _
        , New SqlParameter("@refto_id", Me.Id))
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
    End Function

    Private Function SubSaveFirst(ByVal conn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans2 As SqlTransaction = conn.BeginTransaction
      Try
        Dim subsaveerror As SaveErrorException = m_receive.AutoGenerateCheck(currentUserId, conn, trans2)
        If Not IsNumeric(subsaveerror.Message) Then
          Return subsaveerror
        End If
      Catch ex As Exception
        trans2.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans2.Commit()

      Return New SaveErrorException("0")
    End Function

    Private Function SubSave2(ByVal conn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException

      ''ใช้ connection ใหม่ transaction ใหม่ของ update deposit check เอง
      Dim trans2 As SqlTransaction = conn.BeginTransaction
      Try
        Dim subsaveerror As SaveErrorException = m_receive.AutoGenerateUpdateDepositCheck(currentUserId, conn, trans2)
        If Not IsNumeric(subsaveerror.Message) Then
          Return New SaveErrorException(" Save Incomplete Please Save Again")
        End If
      Catch ex As Exception
        trans2.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans2.Commit()

      Return New SaveErrorException("0")
    End Function

    Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldStockItemStatus", New SqlParameter("@stock_id", Me.Id))
    End Sub
    Private Sub UpdateAssetWriteOffAmt(ByVal Id As Integer, ByVal assetlist As List(Of String), ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetWriteOffAmt", New SqlParameter("@eqtstock_id", Me.Id) _
                                    , New SqlParameter("@AssetList", String.Join(",", assetlist)))
    End Sub

    'Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
    '  If Not Me.Originated Then
    '    Return
    '  End If
    '  For Each tr As TreeRow In Me.m_itemTable.Childs
    '    If ValidateRow(tr) Then

    '    End If
    '  Next
    '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewStockItemStatus", New SqlParameter("@stock_id", Me.Id))
    'End Sub
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal AssetList As List(Of String)) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from EqtStockItem Where EqtStocki_eqtstock = " & Me.Id, conn)
        'Dim daWbs As New SqlDataAdapter("Select * from EqtStockiWbs Where EqtStockiw_sequence in ( Select eqtstocki_sequence from EqtStockItem Where EqtStocki_eqtstock = " & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        'da.InsertCommand.CommandText &= "; Select * From EqtStockItem Where eqtstocki_sequence = @@IDENTITY"
        'da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "Eqtstockitem")
        da.Fill(ds, "Eqtstockitem")

        'Dim EqtDt As DataTable = GetEqiLastSequence()

        'cmdBuilder = New SqlCommandBuilder(daWbs)
        'daWbs.SelectCommand.Transaction = trans
        'cmdBuilder.GetDeleteCommand.Transaction = trans
        'cmdBuilder.GetInsertCommand.Transaction = trans
        'cmdBuilder.GetUpdateCommand.Transaction = trans
        'cmdBuilder = Nothing
        'daWbs.FillSchema(ds, SchemaType.Mapped, "EqtStockiWbs")
        'daWbs.Fill(ds, "EqtStockiWbs")
        'ds.Relations.Add("sequence", ds.Tables!EqtStockItem.Columns!eqtstocki_sequence, ds.Tables!EqtStockiWbs.Columns!EqtStockiw_sequence)

        Dim dt As DataTable = ds.Tables("Eqtstockitem")
        'Dim dtWbs As DataTable = ds.Tables("EqtStockiWbs")

        'For Each row As DataRow In ds.Tables("EqtStockiWbs").Rows
        '  row.Delete()
        'Next

        '------------Checking if we have to delete some rows--------------------
        Dim rowsToDelete As New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As AssetWriteOffItem In Me.Itemcollection
            If testItem.Sequence = CInt(dr("eqtstocki_sequence")) Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            If Not rowsToDelete.Contains(dr) Then
              rowsToDelete.Add(dr)
            End If

          End If
          Dim drh As New DataRowHelper(dr)
          If drh.GetValue(Of Integer)("eqtstocki_entitytype") = 28 AndAlso Not AssetList.Contains(drh.GetValue(Of Integer)("eqtstocki_entity").ToString) Then
            AssetList.Add(drh.GetValue(Of Integer)("eqtstocki_entity").ToString)
          End If
        Next
        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next


        '------------End Checking--------------------

        Dim i As Integer = 0 'Line Running
        Dim seq As Integer = -1
        With ds.Tables("Eqtstockitem")
          For Each item As AssetWriteOffItem In Me.Itemcollection
            'Dim dr As DataRow = .NewRow
            'Dim row() As DataRow = EqtDt.Select("eqtstocki_entity =" & item.Entity.Id.ToString)
            i += 1

            '------------Checking if we have to add a new row or just update existing--------------------
            Dim dr As DataRow
            Dim drs As DataRow() = dt.Select("eqtstocki_sequence=" & item.Sequence)
            If drs.Length = 0 Then
              dr = dt.NewRow
              'dt.Rows.Add(dr)
              seq = (Me.Id + i) * (-1)
              dr("eqtstocki_sequence") = seq
            Else
              dr = drs(0)
            End If
            '------------End Checking--------------------

            dr("eqtstocki_eqtstock") = Me.Id
            dr("eqtstocki_linenumber") = i
            If TypeOf item.Entity Is ToolLot Then
              dr("eqtstocki_entity") = CType(item.Entity, ToolLot).Tool.Id
              dr("eqtstocki_entityType") = 19
              dr("eqtstocki_toollot") = item.Entity.Id
            Else
              dr("eqtstocki_entity") = item.Entity.Id
              dr("eqtstocki_entityType") = item.ItemType.Value
              dr("eqtstocki_toollot") = DBNull.Value
            End If
            dr("eqtstocki_name") = item.Entity.Name
            If Not item.Unit Is Nothing Then
              dr("eqtstocki_unit") = item.Unit.Id
            End If

            dr("eqtstocki_refsequence") = item.RefSequence 'Sequence ของการซืัอ
            dr("eqtstocki_rentalrate") = DBNull.Value 'item.RentalPerDay  'คิดจากจำนวนแล้ว
            dr("eqtstocki_rentalunit") = DBNull.Value
            dr("eqtstocki_rentalqty") = DBNull.Value

            dr("eqtstocki_remainbuyqty") = item.RemainBuyQty 'ปริมาณคงเหลือ 1
            dr("eqtstocki_buyunitprice") = item.BuyUnitPrice 'ราคาซื้อ/หน่วย 2
            dr("eqtstocki_AssetAmount") = item.AssetAmount 'มูลค่าสินทรัพย์ 3
            dr("eqtstocki_accdepre") = item.AccDepre 'ค่าเสื่อมสะสม 4
            dr("eqtstocki_assetremainamount") = item.AssetRemainAmount 'มูลค่าคงเหลือ 5

            dr("eqtstocki_qty") = item.Qty 'ปริมาณ 6
            dr("eqtstocki_unitprice") = item.UnitPrice 'ราคาขาย/หน่วย 7
            dr("eqtstocki_Amount") = item.Amount 'มูลค่าขาย 8
            dr("eqtstocki_writeoffAmt") = item.WriteOffAmount  'มูลค่า Write Off 9

            dr("eqtstocki_writeoffaccdepre") = item.WriteOffDepreAmount 'ค่าเสื่อมสะสม Write Off 10
            dr("eqtstocki_costamount") = item.CostAmount 'ต้นทุนขาย 11
            dr("eqtstocki_profitloss") = item.ProfitLoss 'กำไร/ขาดทุน 12

            dr("eqtstocki_note") = item.Note
            dr("eqtstocki_type") = Me.EntityId
            dr("eqtstocki_refdoc") = DBNull.Value
            dr("eqtstocki_refdoctype") = DBNull.Value
            dr("eqtstocki_refdoclinenumber") = DBNull.Value
            dr("eqtstocki_parent") = item.Parent 'DBNull.Value
            dr("eqtstocki_level") = item.Level
            dr("eqtstocki_fromstatus") = 9
            dr("eqtstocki_tostatus") = 9

            dr("eqtstocki_acct") = item.AssetAccount.Id
            dr("eqtstocki_depreacct") = item.AccDepreAccount.Id
            dr("eqtstocki_placct") = item.PLAccount.Id
            'dr("eqtstocki_asset") = item.Asset.Id

            If drs.Length = 0 Then
              .Rows.Add(dr)
            End If



            'Dim rootWBS As New WBS(Me.WithdrawCostcenter.RootWBSId)
            'If item.ItemType.Value <> 160 _
            'AndAlso item.ItemType.Value <> 162 Then
            '  Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
            '  Dim currentSum As Decimal = wbsdColl.GetSumPercent
            '  For Each wbsd As WBSDistribute In wbsdColl
            '    If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
            '      'ยังไม่เต็ม 100 แต่มีหัวอยู่
            '      wbsd.Percent += (100 - currentSum)
            '    End If
            '    wbsd.BaseCost = 0 'item.ItemAmount
            '    Dim childDr As DataRow = dtWbs.NewRow
            '    childDr("eqtstockiw_wbs") = wbsd.WBS.Id
            '    If wbsd.CostCenter Is Nothing Then
            '      wbsd.CostCenter = Me.WithdrawCostcenter
            '    End If
            '    childDr("eqtstockiw_cc") = wbsd.CostCenter.Id
            '    childDr("eqtstockiw_percent") = wbsd.Percent
            '    childDr("eqtstockiw_sequence") = dr("eqtstocki_sequence")
            '    childDr("eqtstockiw_ismarkup") = wbsd.IsMarkup
            '    childDr("eqtstockiw_direction") = 0              'in
            '    childDr("eqtstockiw_baseCost") = wbsd.BaseCost
            '    childDr("eqtstockiw_amt") = wbsd.Amount
            '    childDr("eqtstockiw_toaccttype") = 1
            '    childDr("eqtstockiw_cbs") = wbsd.CBS.Id
            '    'Add เข้า stockiwbs
            '    dtWbs.Rows.Add(childDr)
            '  Next

            '  currentSum = wbsdColl.GetSumPercent
            '  'ยังไม่เต็ม 100 และยังไม่มี root
            '  If currentSum < 100 Then
            '    Try
            '      Dim newWbsd As New WBSDistribute
            '      newWbsd.WBS = rootWBS
            '      newWbsd.CostCenter = Me.WithdrawCostcenter
            '      newWbsd.Percent = 100 - currentSum
            '      newWbsd.BaseCost = item.ItemAmount
            '      Dim childDr As DataRow = dtWbs.NewRow
            '      childDr("eqtstockiw_wbs") = newWbsd.WBS.Id
            '      childDr("eqtstockiw_cc") = newWbsd.CostCenter.Id
            '      childDr("eqtstockiw_percent") = newWbsd.Percent
            '      childDr("eqtstockiw_sequence") = dr("eqtstocki_sequence")
            '      childDr("eqtstockiw_ismarkup") = False
            '      childDr("eqtstockiw_direction") = 0                'in
            '      childDr("eqtstockiw_baseCost") = newWbsd.BaseCost
            '      childDr("eqtstockiw_amt") = newWbsd.Amount
            '      childDr("eqtstockiw_toaccttype") = 1
            '      childDr("eqtstockiw_cbs") = newWbsd.CBS.Id
            '      'Add เข้า stockiwbs
            '      dtWbs.Rows.Add(childDr)
            '    Catch ex As Exception
            '      MessageBox.Show(ex.ToString)
            '    End Try
            '  End If
            'End If

          Next
        End With

        'da.Update(dt.Select("", "", DataViewRowState.Added))

        'ds.EnforceConstraints = False

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        'AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

        'daWbs.Update(GetDeletedRows(dtWbs))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        'daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        'ds.EnforceConstraints = False
        'daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
        'ds.EnforceConstraints = True




        Return New SaveErrorException("0")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString + vbCrLf + ex.InnerException.ToString)
      End Try

    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daWbs_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        Dim currentkey As Integer = CInt(e.Row("eqtstockiw_sequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!eqtstockiw_sequence = e.Row.GetParentRow("sequence")("eqtstocki_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!eqtstockiw_sequence = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daItc_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        Dim currentkey As Integer = CInt(e.Row("itci_refsequence")) '.GetParentRow("sequence")("itci_refsequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!itci_refsequence = e.Row.GetParentRow("sequence_2")("stocki_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!itci_refsequence = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Function GetDeletedRows(ByVal dt As DataTable) As DataRow()
      Dim Rows() As DataRow
      If dt Is Nothing Then Return Rows
      Rows = dt.Select("", "", DataViewRowState.Deleted)
      If Rows.Length = 0 OrElse Not (Rows(0) Is Nothing) Then Return Rows
      '
      ' Workaround:
      ' With a remoted DataSet, Select returns the array elements
      ' filled with Nothing/null, instead of DataRow objects.
      '
      Dim r As DataRow, I As Integer = 0
      For Each r In dt.Rows
        If r.RowState = DataRowState.Deleted Then
          Rows(I) = r
          I += 1
        End If
      Next
      Return Rows
    End Function
#End Region

#Region "Items"
    'Private m_grouping As Boolean = False
    'Public Overloads Sub ReLoadItems()
    '  Me.IsInitialized = False
    '  m_itemTable = GetSchemaTable()
    '  LoadItems()
    '  Me.IsInitialized = True
    'End Sub
    'Public Overloads Sub ReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
    '  Me.IsInitialized = False
    '  m_itemTable = GetSchemaTable()
    '  Me.IsInitialized = True
    'End Sub
    'Private Sub LoadItems()
    '  If Not Me.Originated Then
    '    Return
    '  End If
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
    '  , CommandType.StoredProcedure _
    '  , "GetAssetWriteoffItems" _
    '  , New SqlParameter("@stock_id", Me.Id) _
    '  , New SqlParameter("@grouping", Me.m_grouping) _
    '  )

    '  For Each row As DataRow In ds.Tables(0).Rows
    '    Dim item As New AssetWriteOffItem(row, "")
    '    item.AssetWriteoff = Me
    '    Me.Add(item)
    '  Next
    'End Sub
    'Public Sub AddBlankRow(ByVal count As Integer)
    '  For i As Integer = 0 To count - 1
    '    Dim myItem As New AssetWriteOffItem
    '    Me.ItemTable.AcceptChanges()
    '    myItem.AssetWriteoff = Me
    '    Me.Add(myItem)
    '  Next
    'End Sub
    'Public Function Add(ByVal item As AssetWriteOffItem) As TreeRow
    '  Dim myRow As TreeRow = Me.ItemTable.Childs.Add
    '  item.LineNumber = Me.ItemTable.Childs.Count
    '  item.AssetWriteoff = Me
    '  item.CopyToDataRow(myRow)
    '  Return myRow
    'End Function
    'Public Function Insert(ByVal index As Integer, ByVal item As AssetWriteOffItem) As TreeRow
    '  Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
    '  item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
    '  item.AssetWriteoff = Me
    '  item.CopyToDataRow(myRow)
    '  ReIndex(index + 1)
    '  Return myRow
    'End Function
    'Public Sub Remove(ByVal index As Integer)
    '  Me.ItemTable.Childs.Remove(Me.ItemTable.Childs(index))
    '  ReIndex()
    'End Sub
    'Private Sub ReIndex()
    '  ReIndex(0)
    'End Sub
    'Private Sub ReIndex(ByVal index As Integer)
    '  If index < 0 OrElse index > Me.ItemTable.Childs.Count - 1 Then
    '    Return
    '  End If
    '  For i As Integer = index To Me.ItemTable.Childs.Count - 1
    '    Me.ItemTable.Childs(i)("stocki_linenumber") = i + 1
    '  Next
    'End Sub
    'Public Function MaxRowIndex() As Integer
    'If Me.m_itemTable Is Nothing Then
    '  Return -1
    'End If
    ''ให้ค่า index ของแถวสุดท้ายที่มีข้อมูล
    'For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
    '  Dim row As TreeRow = Me.m_itemTable.Childs(i)
    '  If ValidateRow(row) Then
    '    Return i
    '  End If
    'Next
    'Return -1 'ไม่มีข้อมูลเลย
    'End Function
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      'If Not Me.IsInitialized Then
      '  Return
      'End If
      ''If CType(e.Row, TreeRow).Level = 0 Then
      ''    Return
      ''End If
      'Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
      'If ValidateRow(CType(e.Row, TreeRow)) Then
      '  If index = Me.m_itemTable.Childs.Count - 1 Then
      '    Me.AddBlankRow(1)
      '  End If
      '  Dim pe As New PropertyChangedEventArgs
      '  Select Case e.Column.ColumnName.ToLower
      '    Case "code"
      '      UpdateDepreciation(e)
      '      pe.Name = "ItemChanged"
      '    Case "stocki_unitprice", "stocki_unvatable", "stocki_discrate", "stocki_qty", "unit"
      '      UpdateAmount(e)
      '      pe.Name = "QtyChanged"
      '    Case Else
      '      pe.Name = "ItemChanged"
      '  End Select
      '  Me.OnPropertyChanged(Me, pe)
      '  Me.m_itemTable.AcceptChanges()
      'End If
    End Sub
    'Public Sub ReUpdateDepreciation()
    '  For Each row As TreeRow In Me.ItemTable.Rows
    '    If ValidateRow(row) Then
    '      Dim assetitem As New Asset(CInt(row("stocki_entity")))
    '      Dim depreopeningamnt As Decimal = 0
    '      Dim depreamntinprocess As Decimal = 0
    '      Dim lastestCalcDate As Date = assetitem.GetLastCalcDate(Nothing)
    '      If lastestCalcDate.Equals(Date.MinValue) Then
    '        depreopeningamnt = assetitem.DepreOpening

    '        'depreamntinprocess = CDec(assetitem.DepreCalcAtDate(Me.DocDate))
    '        'row("deprecalcamt") = Configuration.FormatToString(depreamntinprocess, DigitConfig.Price)
    '        row("deprecalcamt") = Configuration.FormatToString(depreopeningamnt, DigitConfig.Price)
    '      Else
    '        If lastestCalcDate.Date <= Me.DocDate Then
    '          depreopeningamnt = CDec(assetitem.DepreCalcAtDate(lastestCalcDate.Date))
    '        End If

    '        depreamntinprocess = CDec(assetitem.DepreCalcAtDate(Me.DocDate))
    '        Dim depre As Double = depreamntinprocess - depreopeningamnt
    '        row("deprecalcamt") = Configuration.FormatToString(depre, DigitConfig.Price)
    '      End If

    '      'row("deprecalcamt") = Configuration.FormatToString(depre, DigitConfig.Price)

    '      'Dim item As New AssetWriteoffItem
    '      'item.AssetWriteoff = Me
    '      'item.CopyFromDataRow(CType(row, TreeRow))
    '    End If
    '  Next
    'End Sub
    'Private Sub UpdateDepreciation(ByVal e As DataColumnChangeEventArgs)
    '  If Not e.Row.IsNull("stocki_entity") Then
    '    Dim assetItem As New Asset(CInt(e.Row("stocki_entity")))

    '    Dim depreopeningamnt As Double
    '    Dim lastestCalcDate As Date = assetItem.GetLastCalcDate(Nothing)
    '    If lastestCalcDate.Equals(Date.MinValue) Then
    '      depreopeningamnt = assetItem.DepreOpening

    '      If assetItem.Originated Then
    '        Dim item As New AssetWriteOffItem
    '        item.AssetWriteoff = Me

    '        'Dim depre As Double = assetItem.DepreCalcAtDate(Me.DocDate)
    '        item.CopyFromDataRow(CType(e.Row, TreeRow))
    '        'item.DepreCalculation = depre
    '        item.DepreCalculation = depreopeningamnt
    '        e.Row("deprecalcamt") = Configuration.FormatToString(item.DepreCalculation, DigitConfig.Price)
    '      End If
    '    Else
    '      If lastestCalcDate.Date <= Me.DocDate Then
    '        depreopeningamnt = CDec(assetItem.DepreCalcAtDate(lastestCalcDate.Date))
    '      End If

    '      If assetItem.Originated Then
    '        Dim item As New AssetWriteOffItem
    '        item.AssetWriteoff = Me

    '        Dim depre As Double = assetItem.DepreCalcAtDate(Me.DocDate)
    '        item.CopyFromDataRow(CType(e.Row, TreeRow))
    '        item.DepreCalculation = depre - depreopeningamnt
    '        e.Row("deprecalcamt") = Configuration.FormatToString(item.DepreCalculation, DigitConfig.Price)
    '      End If
    '    End If


    '  End If
    'End Sub
    Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
      'Dim item As New AssetWriteOffItem
      'item.AssetWriteoff = Me
      'item.CopyFromDataRow(CType(e.Row, TreeRow))
      'e.Row("Amount") = Configuration.FormatToString(item.Amount, DigitConfig.Price)
      'e.Row("StockQty") = Configuration.FormatToString(item.StockQty, DigitConfig.Qty)
      'RefreshTaxBase()
    End Sub
    Public Sub RefreshTaxBase()
      'If Me.ItemTable Is Nothing OrElse Me.ItemTable.Rows.Count = 0 Then      '  m_gross = 0
      'Else
      '  Dim amt As Decimal = 0      '  For Each row As TreeRow In Me.ItemTable.Rows
      '    Dim item As New AssetWriteOffItem
      '    'item.GetAmountFromRow(row)
      '    amt += item.Amount
      '  Next      '  m_gross = amt
      'End If
      If Me.Gross = 0 Then
        Me.TaxBase = 0
        Return
      End If
      Select Case Me.TaxType.Value
        Case 0 '"ไม่มี"
          Me.TaxBase = 0
        Case 1 '"แยก"
          Dim myGross As Decimal = Me.Gross
          Dim myDiscount As Decimal = Me.DiscountAmount
          Dim sumInItems As Decimal = 0
          For Each item As AssetWriteOffItem In Me.Itemcollection
            If TypeOf item.Entity Is Asset Then
              If Not item.UnVatable Then
                sumInItems += (item.Amount - ((item.Amount / myGross) * myDiscount))
              End If
            End If
          Next
          Me.TaxBase = sumInItems
        Case 2 '"รวม"
          Dim myGross As Decimal = Me.Gross
          Dim myDiscount As Decimal = Me.DiscountAmount
          Dim sumInItems As Decimal = 0
          For Each item As AssetWriteOffItem In Me.Itemcollection
            If TypeOf item.Entity Is Asset Then
              If Not item.UnVatable Then
                sumInItems += (item.Amount - ((item.Amount / myGross) * myDiscount)) * (100 / (Me.TaxRate + 100))
              End If
            End If
          Next
          Me.TaxBase = sumInItems
      End Select
    End Sub
    'Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '  If Not Me.IsInitialized Then
    '    Return
    '  End If
    '  'If CType(e.Row, TreeRow).Level = 0 Then
    '  '    Return
    '  'End If
    '  Try
    '    Select Case e.Column.ColumnName.ToLower
    '      Case "code"
    '        SetCode(e)
    '      Case "stocki_itemname"
    '        SetName(e)
    '      Case "unit"
    '        SetUnitValue(e)
    '      Case "stocki_qty"
    '        SetQty(e)
    '      Case "stocki_unitprice"
    '        SetUnitPrice(e)
    '      Case "accountcode"
    '        SetAccount(e)

    '    End Select
    '    ValidateRow(e)
    '  Catch ex As Exception
    '    MessageBox.Show(ex.ToString)
    '  End Try
    'End Sub
    'Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
    '  Dim code As Object = e.Row("code")
    '  Dim stocki_itemname As Object = e.Row("stocki_itemname")
    '  Dim stocki_entitytype As Object = e.Row("stocki_entitytype")
    '  Dim accountcode As Object = e.Row("accountcode")
    '  Dim unit As Object = e.Row("unit")
    '  Dim stocki_unitprice As Object = e.Row("stocki_unitprice")
    '  Dim stocki_qty As Object = e.Row("stocki_qty")

    '  Select Case e.Column.ColumnName.ToLower
    '    Case "code"
    '      code = e.ProposedValue
    '    Case "stocki_itemname"
    '      stocki_itemname = e.ProposedValue
    '    Case "stocki_entitytype"
    '      stocki_entitytype = e.ProposedValue
    '    Case "accountcode"
    '      accountcode = e.ProposedValue
    '    Case "unit"
    '      unit = e.ProposedValue
    '    Case "stocki_unitprice"
    '      stocki_unitprice = e.ProposedValue
    '    Case "stocki_qty"
    '      stocki_qty = e.ProposedValue
    '    Case Else
    '      Return
    '  End Select

    '  Dim isBlankRow As Boolean = False
    '  If IsDBNull(stocki_entitytype) Then
    '    isBlankRow = True
    '  End If

    '  If Not isBlankRow Then
    '    If IsDBNull(code) OrElse code.ToString.Length = 0 Then
    '      e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
    '    Else
    '      e.Row.SetColumnError("code", "")
    '    End If
    '    If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
    '      e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
    '    Else
    '      e.Row.SetColumnError("stocki_itemname", "")
    '    End If

    '    If IsDBNull(stocki_qty) OrElse (IsNumeric(stocki_qty) AndAlso CDec(stocki_qty) <= 0) Then
    '      e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
    '    Else
    '      e.Row.SetColumnError("stocki_qty", "")
    '    End If
    '    If IsDBNull(stocki_unitprice) OrElse CStr(stocki_unitprice).ToString.Length <= 0 OrElse (IsNumeric(stocki_unitprice) AndAlso CDec(stocki_unitprice) <= 0) Then
    '      e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
    '    Else
    '      e.Row.SetColumnError("stocki_unitprice", "")
    '    End If
    '    If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
    '      e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
    '    Else
    '      e.Row.SetColumnError("accountcode", "")
    '    End If
    '  End If

    'End Sub
    'Public Function ValidateRow(ByVal row As TreeRow) As Boolean
    '  If row.IsNull("eqtstocki_entity") Then
    '    Return False
    '  End If
    '  Return True
    'End Function
    Private m_updating As Boolean = False
    Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("stocki_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("stocki_entityType"))
        Case 0, 19, 28, 42
          'ผ่าน
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Public Sub SetUnitPrice(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.UnitPrice)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("stocki_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("stocki_entityType"))
        Case 0, 19, 28, 42
          'ผ่าน
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub

    Private Sub ClearRow(ByVal e As DataColumnChangeEventArgs)
      e.Row("stocki_entity") = DBNull.Value
      e.Row("stocki_itemname") = DBNull.Value
      e.Row("Amount") = DBNull.Value
      e.Row("stocki_qty") = DBNull.Value
      e.Row("StockQty") = DBNull.Value
      e.Row("stocki_unit") = DBNull.Value
      e.Row("stocki_unitprice") = DBNull.Value
      e.Row("stocki_discrate") = DBNull.Value
      e.Row("Unit") = DBNull.Value
      e.Row("UnitButton") = DBNull.Value
      e.Row("stocki_unvatable") = False
      e.Row("stocki_note") = DBNull.Value
      e.Row("Amount") = DBNull.Value
      e.Row("code") = DBNull.Value
      e.Row("stocki_acct") = DBNull.Value
      e.Row("AccountCode") = DBNull.Value
      e.Row("AccountButton") = ""
      e.Row("Account") = DBNull.Value
      e.Row("Button") = ""
      e.Row("deprecalcamt") = DBNull.Value
    End Sub
    Public Sub SetAccount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("stocki_entity") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim entity As New Account(e.ProposedValue.ToString)
      If entity.Originated Then
        If entity.IsControlGroup Then
          Dim myMsgService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          myMsgService.ShowError(entity.Code & "-" & entity.Name & " เป็นบัญชีคุม")
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherIncome)
          If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
            e.Row("stocki_acct") = ga.Account.Id
            e.ProposedValue = ga.Account.Code
            e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            m_updating = False
            Return
          End If
        Else
          e.Row("stocki_acct") = entity.Id
          e.ProposedValue = entity.Code
          e.Row("Account") = entity.Name
          m_updating = False
          Return
        End If

      Else
        Dim item As New AssetWriteOffItem
        'item.CopyFromDataRow(CType(e.Row, TreeRow))
        If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 Then
          Dim myAsset As IEqtItem = item.Entity
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherIncome)
          If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
            e.Row("stocki_acct") = ga.Account.Id
            e.ProposedValue = ga.Account.Code
            e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            m_updating = False
            Return
          End If
        End If
        e.Row("stocki_acct") = DBNull.Value
        e.ProposedValue = DBNull.Value
        e.Row("Account") = DBNull.Value
        m_updating = False
        Return

      End If
      m_updating = False
    End Sub
    Public Sub SetName(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True

      m_updating = False
    End Sub
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      'If e.Row.IsNull("stocki_entityType") Then
      '  Return False
      'End If
      'If IsDBNull(e.ProposedValue) Then
      '  Return False
      'End If
      'For Each row As TreeRow In Me.ItemTable.Childs
      '  If Not row Is e.Row Then
      '    If Not row.IsNull("stocki_entityType") Then
      '      If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
      '        If Not row.IsNull("code") Then
      '          If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
      '            Return True
      '          End If
      '        End If
      '      End If
      '    End If
      '  End If
      'Next
      'Return False
    End Function
    Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.ProposedValue.ToString.Length = 0 Then
        If e.Row(e.Column).ToString.Length <> 0 Then
          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
            ClearRow(e)
          Else
            e.ProposedValue = e.Row(e.Column)
          End If
        End If
        m_updating = False
        Return
      End If
      Dim myItem As New Asset(e.ProposedValue.ToString)
      If myItem.Status.Value = 5 Then 'ถูกขายไปแล้ว
        msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.BusinessLogic.AssetWriteoff.Sold}", New String() {e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If Not myItem.Originated Then
        msgServ.ShowMessageFormatted("${res:Global.Error.NoAsset}", New String() {e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      Else
        Dim myUnit As Unit = myItem.Unit
        e.Row("stocki_entity") = myItem.Id
        e.ProposedValue = myItem.Code
        e.Row("stocki_itemName") = myItem.Name
        If Not myUnit Is Nothing AndAlso myUnit.Originated Then
          e.Row("stocki_unit") = myUnit.Id
          e.Row("Unit") = myUnit.Name
        Else
          e.Row("stocki_unit") = DBNull.Value
          e.Row("Unit") = DBNull.Value
        End If
        Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherIncome)
        If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
          e.Row("stocki_acct") = ga.Account.Id
          e.Row("AccountCode") = ga.Account.Code
          e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
        Else
          e.Row("stocki_acct") = DBNull.Value
          e.Row("AccountCode") = DBNull.Value
          e.Row("Account") = DBNull.Value
        End If
      End If

      e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
      'e.Row("stocki_stockqty") = Configuration.FormatToString(1D, DigitConfig.Qty)
      m_updating = False
    End Sub
    Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If

    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
      'Dim row As DataRow = e.Row
      'Me.m_itemTable.Childs.Remove(CType(row, TreeRow))
      'Try
      '    If Not Me.m_isInitialized Then
      '        Return
      '    End If

      '    Dim index As TreeRow = CType(e.Row, TreeRow)
      '    Me.m_itemTable.Childs.Remove(index)
      'Catch ex As Exception
      '    MessageBox.Show(ex.ToString)
      'End Try
    End Sub
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    'Dim jiCollSummary As New JournalEntryItemCollection
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      If Me.Amount > 0 Then
        '' DR. ค่าเสื่อมราคา          costcenter เดิม           ji.Mapping = "I6.1"
        'SetGLI8_1(jiColl)
        '' CR. ค่าเสื่อมราคาสะสม  costcenter เดิม           ji.Mapping = "I6.2"
        'SetGLI8_2(jiColl)
        ' dr. ค่าเสื่อราคาสะสมทั้งหมด
        SetGLI8_1(jiColl)
        ' cr. สินทรัพย์ทั้งหมด
        SetGLI8_2(jiColl)
        ' dr.ลูกหนี้การค้า
        SetGLI8_3(jiColl)
        ' cr.กำไรจากการขายสินทรัพย์
        SetGLI7_6(jiColl)
        ' cr.ภาษีขาย
        SetGLI7_7(jiColl)
        ' dr.ภาษีหัก ณ ที่จ่าย
        SetGLI7_8(jiColl)

      End If

      ' ผังบัญชีการขายสินค้า มี มาตรฐานให้ใช้อยู่แล้ว ไม่ต้องหาอีกครั้งนะจ๊ะ
      If Not Me.Receive Is Nothing Then
        jiColl.AddRange(Me.Receive.GetJournalEntries(Me.FromCostCenter))
      End If

      'For Each ji2 As JournalEntryItem In jiColl
      '  If Not ji2.Mapping = "I7.9" Then
      '    jiCollSummary.Add(ji2)
      'Next
      If Me.Amount > 0 Then
        ' Cr.กำไร(ขาดทุน)จากการขายสินทรัพย์
        SetGLI7_9(jiColl)
      End If

      Return jiColl
    End Function
    '' dr. ค่าเสื่อมราคาเพิ่มเติมจนถึงวันที่ขาย
    'Private Sub SetGLI8_1(ByVal jiColl As JournalEntryItemCollection)
    '  Dim ji As New JournalEntryItem
    '  Dim ht As New Hashtable
    '  For Each trow As TreeRow In Me.ItemTable.Childs
    '    If ValidateRow(trow) Then
    '      Dim asset As New Asset(CInt(trow("stocki_entity")))
    '      If Not asset.DepreAccount Is Nothing Then
    '        ht(asset.DepreAccount.Id) = asset.DepreAccount
    '      End If
    '    End If
    '  Next
    '  For Each acct As Account In ht.Values
    '    Dim Intotalamnt As Decimal = 0
    '    For Each row As TreeRow In Me.ItemTable.Childs
    '      If ValidateRow(row) Then
    '        Dim myAsset As New Asset(CInt(row("stocki_entity")))
    '        'myAsset.DepreciationCalc()
    '        If myAsset.DepreAccount.Originated AndAlso myAsset.DepreAccount.Id = acct.Id Then
    '          If Not row.IsNull("deprecalcamt") Then
    '            Intotalamnt += CDec(row("deprecalcamt"))
    '          End If
    '        End If
    '        'Intotalamnt = CDec(myAsset.DepreLTD)
    '      End If
    '    Next
    '    If Intotalamnt > 0 Then
    '      ji = New JournalEntryItem
    '      ji.Mapping = "I8.1"
    '      ji.Amount = Intotalamnt
    '      If acct.Originated Then
    '        ji.Account = acct
    '      End If
    '      ji.CostCenter = Me.FromCostCenter
    '      jiColl.Add(ji)
    '    End If
    '  Next
    'End Sub
    '' cr. ค่าเสื่อมราคาสะสม
    'Private Sub SetGLI8_2(ByVal jiColl As JournalEntryItemCollection)
    '  Dim ji As New JournalEntryItem
    '  Dim ht As New Hashtable
    '  For Each trow As TreeRow In Me.ItemTable.Childs
    '    If ValidateRow(trow) Then
    '      Dim asset As New Asset(CInt(trow("stocki_entity")))
    '      If Not asset.DepreOpeningAccount Is Nothing Then
    '        ht(asset.DepreOpeningAccount.Id) = asset.DepreOpeningAccount
    '      End If
    '    End If
    '  Next
    '  For Each acct As Account In ht.Values
    '    Dim Intotalamnt As Decimal = 0
    '    For Each row As TreeRow In Me.ItemTable.Childs
    '      If ValidateRow(row) Then
    '        Dim myAsset As New Asset(CInt(row("stocki_entity")))
    '        'myAsset.DepreciationCalc()
    '        If myAsset.DepreOpeningAccount.Originated AndAlso myAsset.DepreOpeningAccount.Id = acct.Id Then
    '          If Not row.IsNull("deprecalcamt") Then
    '            Intotalamnt += CDec(row("deprecalcamt"))
    '          End If
    '        End If
    '        'Intotalamnt = CDec(myAsset.DepreLTD)
    '      End If
    '    Next
    '    If Intotalamnt > 0 Then
    '      ji = New JournalEntryItem
    '      ji.Mapping = "I7.2"
    '      ji.Amount = Intotalamnt
    '      If acct.Originated Then
    '        ji.Account = acct
    '      End If
    '      ji.CostCenter = Me.FromCostCenter
    '      jiColl.Add(ji)
    '    End If
    '  Next
    'End Sub
    ' dr. ค่าเสื่อราคาสะสมทั้งหมด
    Private Sub SetGLI8_1(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      'Dim ht As New Hashtable
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '  If ValidateRow(trow) Then
      '    Dim asset As New Asset(CInt(trow("eqtstocki_entity")))
      '    If Not asset.DepreOpeningAccount Is Nothing Then
      '      ht(asset.DepreOpeningAccount.Id) = asset.DepreOpeningAccount
      '    End If
      '  End If
      'Next
      'For Each acct As Account In ht.Values
      '  Dim Intotalamnt As Double = 0 'Decimal = 0
      '  For Each row As TreeRow In Me.ItemTable.Childs
      '    If ValidateRow(row) Then
      '      Dim myAsset As New Asset(CInt(row("eqtstocki_entity")))
      '      If myAsset.DepreOpeningAccount.Id = acct.Id Then
      '        Dim depreamntinprocess As Decimal = 0
      '        Dim lastestCalcDate As Date = myAsset.GetLastCalcDate(Nothing)
      '        If lastestCalcDate.Equals(Date.MinValue) Then
      '          depreamntinprocess = myAsset.DepreOpening
      '        Else
      '          depreamntinprocess = CDec(myAsset.DepreCalcAtDate(Me.DocDate))
      '        End If
      '        Intotalamnt += myAsset.BuyPrice - depreamntinprocess
      '      End If
      '    End If
      '  Next
      '  If Intotalamnt > 0 Then
      '    ji = New JournalEntryItem
      '    ji.Mapping = "I8.1"
      '    ji.Amount = CDec(Intotalamnt)
      '    If acct.Originated Then
      '      ji.Account = acct
      '    End If
      '    ji.CostCenter = Me.FromCostCenter
      '    jiColl.Add(ji)
      '  End If
      'Next
      For Each item As AssetWriteOffItem In Me.Itemcollection
        If item.ItemType.Value = 28 Then
          ji = New JournalEntryItem
          ji.Mapping = "I8.1"
          ji.Amount = item.WriteOffDepreAmount
          ji.Account = item.AccDepreAccount
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)

          ji = New JournalEntryItem
          ji.Mapping = "I8.1D"
          ji.Amount = item.WriteOffDepreAmount
          ji.Account = item.AccDepreAccount
          ji.CostCenter = Me.FromCostCenter
          ji.EntityItem = item.Entity.Id
          ji.EntityItemType = item.Entity.EntityId
          ji.Note = item.Entity.Code & " " & item.Entity.Name
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' cr. สินทรัพย์ทั้งหมด
    Private Sub SetGLI8_2(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      'Dim ht As New Hashtable
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '  If ValidateRow(trow) Then
      '    Dim asset As New Asset(CInt(trow("stocki_entity")))
      '    If Not asset.Account Is Nothing Then
      '      ht(asset.Account.Id) = asset.Account
      '    End If
      '  End If
      'Next
      'For Each acct As Account In ht.Values
      '  Dim Intotalamnt As Decimal = 0
      '  For Each row As TreeRow In Me.ItemTable.Childs
      '    If ValidateRow(row) Then
      '      Dim myAsset As New Asset(CInt(row("stocki_entity")))
      '      If myAsset.Account.Originated AndAlso myAsset.Account.Id = acct.Id Then
      '        Dim depreamntinprocess As Decimal = 0
      '        Dim lastestCalcDate As Date = myAsset.GetLastCalcDate(Nothing)
      '        If lastestCalcDate.Equals(Date.MinValue) Then
      '          depreamntinprocess = myAsset.DepreOpening
      '        Else
      '          depreamntinprocess = CDec(myAsset.DepreCalcAtDate(Me.DocDate))
      '        End If
      '        Intotalamnt += myAsset.BuyPrice - depreamntinprocess
      '      End If
      '    End If
      '  Next
      '  If Intotalamnt > 0 Then
      '    ji = New JournalEntryItem
      '    ji.Mapping = "I7.4"
      '    ji.Amount = Intotalamnt
      '    If acct.Originated Then
      '      ji.Account = acct
      '    End If
      '    ji.CostCenter = Me.FromCostCenter
      '    jiColl.Add(ji)
      '  End If
      'Next
      For Each item As AssetWriteOffItem In Me.Itemcollection
        If item.ItemType.Value = 28 Then
          ji = New JournalEntryItem
          ji.Mapping = "I8.2"
          ji.Amount = item.WriteOffAmount
          ji.Account = item.AssetAccount
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)

          ji = New JournalEntryItem
          ji.Mapping = "I8.2D"
          ji.Amount = item.WriteOffAmount
          ji.Account = item.AssetAccount
          ji.CostCenter = Me.FromCostCenter
          ji.EntityItem = item.Entity.Id
          ji.EntityItemType = item.Entity.EntityId
          ji.Note = item.Entity.Code & " " & item.Entity.Name
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' dr. ลูกหนี้การค้า
    Private Sub SetGLI8_3(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      If Not Me.Receive Is Nothing Then
        'ส่วนต่างระหว่างยอดรับกับยอดจริง ---> ลูกหนี้
        Me.Receive.UpdateGross()
        If Configuration.Compare(Me.Receive.Gross, Me.Receive.Amount) < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "I8.3"
          ji.Amount = Me.Receive.Amount - Me.Receive.Gross
          If Not Me.Customer.Account Is Nothing AndAlso Me.Customer.Account.Originated Then
            ji.Account = Me.Customer.Account
          End If
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)
        End If
      End If
    End Sub
    'cr.กำไรจากการขายสินทรัพย์
    Private Sub SetGLI7_6(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      'Dim acct As New Account
      'Dim ht As New Hashtable
      'For Each item As AssetWriteOffItem In Me.Itemcollection
      'For Each trow As TreeRow In Me.ItemTable.Childs
      '  If ValidateRow(trow) Then
      'Dim acctItem As New Account(CInt(trow("stocki_acct")))
      'If Not acctItem Is Nothing Then
      '  ht(acctItem.Id) = acctItem
      'End If
      '  End If
      'Next
      'For Each acct As Account In ht.Values
      '  Dim Intotalamnt As Decimal = 0
      '  For Each row As TreeRow In Me.ItemTable.Childs
      '    If ValidateRow(row) Then
      '      Dim myAcct As New Account(CInt(row("stocki_acct")))
      '      If myAcct.Originated AndAlso myAcct.Id = acct.Id Then
      '        Dim amt As Decimal
      '        Dim taxBase As Decimal
      '        If Not row.IsNull("Amount") Then
      '          amt = CDec(row("amount"))
      '        Else
      '          amt = 0
      '        End If      '        Select Case Me.TaxType.Value
      '          Case 2 '"รวม"
      '            taxBase = amt * (100 / (Me.TaxRate + 100))
      '          Case Else
      '            taxBase = amt
      '        End Select      '        Intotalamnt += taxBase
      '      End If
      '    End If
      '  Next
      '  If Intotalamnt > 0 Then
      '    ji = New JournalEntryItem
      '    ji.Mapping = "I7.6"
      '    ji.Amount = Intotalamnt
      '    If acct.Originated Then
      '      ji.Account = acct
      '    End If
      '    ji.CostCenter = Me.FromCostCenter
      '    jiColl.Add(ji)
      '  End If
      'Next
      For Each item As AssetWriteOffItem In Me.Itemcollection
        If item.ItemType.Value = 28 Then
          ji = New JournalEntryItem
          ji.Mapping = "I7.6"
          ji.Amount = item.ProfitLoss
          ji.Account = item.PLAccount
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)

          ji = New JournalEntryItem
          ji.Mapping = "I7.6D"
          ji.Amount = item.ProfitLoss
          ji.Account = item.PLAccount
          ji.CostCenter = Me.FromCostCenter
          ji.EntityItem = item.Entity.Id
          ji.EntityItemType = item.Entity.EntityId
          ji.Note = item.Entity.Code & " " & item.Entity.Name
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' cr.ภาษีขาย
    Private Sub SetGLI7_7(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      If Me.TaxAmount > 0 AndAlso Not Me.NoVat Then
        ji = New JournalEntryItem
        ji.Mapping = "I7.7"
        ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
        ji.CostCenter = Me.FromCostCenter
        jiColl.Add(ji)
      End If

      If Me.TaxAmount > 0 AndAlso Me.NoVat Then
        ji = New JournalEntryItem
        ji.Mapping = "I7.7.1"
        ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
        ji.CostCenter = Me.FromCostCenter
        jiColl.Add(ji)
      End If
    End Sub
    'ภาษีหัก ณ ที่จ่าย
    Private Sub SetGLI7_8(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "I7.8"
        ji.Amount = Me.WitholdingTaxCollection.Amount
        ji.CostCenter = Me.FromCostCenter
        jiColl.Add(ji)

        Dim WHTTypeSum As New Hashtable

        For Each wht As WitholdingTax In Me.WitholdingTaxCollection
          If WHTTypeSum.Contains(wht.Type.Value) Then
            WHTTypeSum(wht.Type.Value) = CDec(WHTTypeSum(wht.Type.Value)) + wht.Amount
          Else
            WHTTypeSum(wht.Type.Value) = wht.Amount
          End If
        Next
        Dim typeNum As String
        For Each obj As Object In WHTTypeSum.Keys
          typeNum = CStr(obj)
          If Not (typeNum.Length > 1) Then
            typeNum = "0" & typeNum
          End If
          If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
            ji = New JournalEntryItem
            ji.Mapping = "E3.18"
            ji.Amount = CDec(WHTTypeSum(obj))
            ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
            ji.CostCenter = Me.FromCostCenter
            jiColl.Add(ji)
          End If
        Next
        For Each wht As WitholdingTax In Me.WitholdingTaxCollection
          typeNum = CStr(wht.Type.Value)
          If Not (typeNum.Length > 1) Then
            typeNum = "0" & typeNum
          End If
          If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
            ji = New JournalEntryItem
            ji.Mapping = "E3.18D"
            ji.Amount = wht.Amount
            ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
            ji.CostCenter = Me.FromCostCenter
            jiColl.Add(ji)
          End If
        Next
        For Each wht As WitholdingTax In Me.WitholdingTaxCollection
          typeNum = CStr(wht.Type.Value)
          If Not (typeNum.Length > 1) Then
            typeNum = "0" & typeNum
          End If
          If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
            ji = New JournalEntryItem
            ji.Mapping = "E3.18W"
            ji.Amount = wht.Amount
            ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
            ji.CostCenter = Me.FromCostCenter
            jiColl.Add(ji)
          End If
        Next
      End If
    End Sub
    'กำไร(ขาดทุน)จากการขายสินทรัพย์
    Private Sub SetGLI7_9(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable

      Dim debitAmt As Decimal = 0
      Dim creditAmt As Decimal = 0

      'Dim je As New JournalEntry(Me)
      'For Each jiItem As JournalEntryItem In jiColl
      '  je.ItemCollection.Add(jiItem)
      ''Next
      'For Each jiItem As JournalEntryItem In je.ItemCollection
      '  If jiItem.IsDebit Then
      '    debitAmt += jiItem.Amount
      '  Else
      '    creditAmt += jiItem.Amount
      '  End If
      'Next

      Dim jli As New JournalEntryItemCollection

      For Each glfi As GLFormatItem In Me.JournalEntry.GLFormat.ItemCollection
        If glfi.Mapping.ToLower.IndexOf("sumdebit") < 0 AndAlso glfi.Mapping.ToLower.IndexOf("sumcredit") < 0 Then
          Dim matchItems As JournalEntryItemCollection = jiColl.GetMappingItems(glfi)
          For Each matchItem As JournalEntryItem In matchItems
            If Not matchItem.Mapping = "I7.9" Then
              matchItem.IsDebit = glfi.IsDebit
              jli.Add(matchItem)
            End If
          Next
        End If
      Next

      For Each jiItem As JournalEntryItem In jli
        If jiItem.IsDebit Then
          debitAmt += jiItem.Amount
        Else
          creditAmt += jiItem.Amount
        End If
      Next

      If debitAmt <> creditAmt Then
        ji = New JournalEntryItem
        ji.Mapping = "I7.9"
        ji.Amount = debitAmt - creditAmt
        ji.CostCenter = Me.FromCostCenter
        jiColl.Add(ji)
      End If

    End Sub
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property
#End Region

#Region "IVatable"
    Public Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal Implements IVatable.GetMaximumTaxBase
      'Todo: ต้อง refresh หรือเปล่า?
      Return Me.TaxBase
    End Function
    Public Property Person() As IBillablePerson Implements IVatable.Person, IWitholdingTaxable.Person
      Get
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        Me.Customer = CType(Value, Customer)
      End Set
    End Property
    Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax
      Return Me.AfterTax
    End Function
    Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax
      Return Me.BeforeTax
    End Function
    Private m_NoVat As Nullable(Of Boolean)
    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        If Not m_NoVat.HasValue Then
          SetNoVat()
        End If
        Return m_NoVat.Value
      End Get
    End Property
    Public Sub SetNoVat(ByVal novat As Boolean)
      m_NoVat = novat
    End Sub

    Public Sub SetNoVat()
      If Me.TaxType.Value = 0 OrElse Me.TaxAmount - Me.Vat.Amount > 0 _
        OrElse Me.Vat.ItemCollection(0).Code Is Nothing _
        OrElse (Me.Vat.ItemCollection(0).Code.Length = 0 AndAlso Not Me.Vat.AutoGen) Then
        m_NoVat = True
      Else
        m_NoVat = False
      End If
    End Sub
    Public Shared Function GetTaxBase(ByVal id As Integer) As Decimal
      Dim ret As Decimal = 0
      If id <= 0 Then
        Return ret
      End If

      Dim RealConnectionString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(RealConnectionString _
      , CommandType.StoredProcedure _
      , "GetAssetWriteOff" _
      , New SqlParameter("@" & "eqtstock_id", id) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        If dr.Table.Columns.Contains("eqtstock_taxbase") _
        AndAlso Not dr.IsNull("eqtstock_taxbase") Then
          ret = CDec(dr("eqtstock_taxbase"))
        End If
      End If
      Return ret
    End Function
#End Region

#Region "IWitholdingTaxable"
    Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return Me.TaxBase
    End Function
#End Region

#Region "IBillAcceptable"
    Public Property Amount() As Decimal Implements IHasAmount.Amount
      Get
        RefreshTaxBase()
        Return Me.AfterTax
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property
    Public Property Name() As String Implements IHasName.Name
      Get

      End Get
      Set(ByVal Value As String)

      End Set
    End Property
    Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive
      RefreshTaxBase()
      Return Me.AfterTax
    End Function
    Public Property DueDate() As Date Implements IReceivable.DueDate
      Get
        Try
          Return Me.DocDate.AddDays(Me.CreditPeriod)
        Catch ex As Exception
          Return Me.DocDate
        End Try
      End Get
      Set(ByVal Value As Date)

      End Set
    End Property
    Public Property Receive() As Receive Implements IReceivable.Receive
      Get
        Return m_receive
      End Get
      Set(ByVal Value As Receive)
        m_receive = Value
      End Set
    End Property
    Public Function RemainingAmount() As Decimal Implements IReceivable.RemainingAmount
      'Undone
      Return AmountToReceive()
    End Function
    Public ReadOnly Property Payer() As IBillablePerson Implements IReceivable.Payer
      Get
        Return Me.Customer
      End Get
    End Property
    Public Function GetRemainingAmountWithBillIssue(ByVal billi_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountWithBillIssue
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@salebillii_salebilli", billi_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountReceiveSelection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@receivesi_receives", receives_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer, ByVal billi_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountReceiveSelection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@receivesi_receives", receives_id) _
                , New SqlParameter("@salebillii_salebilli", billi_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\DO.dfm"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Me.RefreshTaxBase()
      'Code
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      ''PoDocCode
      'dpi = New DocPrintingItem
      'dpi.Mapping = "PoDocCode"
      'dpi.Value = Me.PoDocCode
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''PoDocDate
      'dpi = New DocPrintingItem
      'dpi.Mapping = "PoDocDate"
      'dpi.Value = Me.PoDocDate.ToShortDateString
      'dpi.DataType = "System.DateTime"
      'dpiColl.Add(dpi)


      If Not Me.Customer Is Nothing AndAlso Me.Customer.Originated Then
        'Customer
        dpi = New DocPrintingItem
        dpi.Mapping = "Customer"
        dpi.Value = Me.Customer.Code & ":" & Me.Customer.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerAddress"
        dpi.Value = Me.Customer.BillingAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerCurrentAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCurrentAddress"
        dpi.Value = Me.Customer.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then
        'CostCenter
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenter"
        dpi.Value = Me.FromCostCenter.Code & ":" & Me.FromCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.FromCostCenterPerson Is Nothing AndAlso Me.FromCostCenterPerson.Originated Then
        'Requestor
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePerson"
        dpi.Value = Me.FromCostCenterPerson.Code & ":" & Me.FromCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CreditPeriod
      dpi = New DocPrintingItem
      dpi.Mapping = "CreditPeriod"
      dpi.Value = Me.CreditPeriod
      dpi.DataType = "System.Int32"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'DiscountRate
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountRate"
      dpi.Value = Me.Discount.Rate
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      dpi.Value = Configuration.FormatToString(Me.TaxAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'Dim n As Integer = 0
      'For i As Integer = 0 To Me.MaxRowIndex
      '  Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
      '  If ValidateRow(itemRow) Then 'And itemRow.Level <> 0 Then
      '    Dim item As New AssetWriteOffItem
      '    item.CopyFromDataRow(itemRow)
      '    'Item.LineNumber
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.LineNumber"
      '    dpi.Value = n + 1
      '    dpi.DataType = "System.Int32"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Code
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Code"
      '    dpi.Value = item.Entity.Code
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Name
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Name"
      '    dpi.Value = item.Entity.Name
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Unit
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Unit"
      '    dpi.Value = item.Unit.Name
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Qty
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Qty"
      '    dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.UnitPrice
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.UnitPrice"
      '    If item.UnitPrice = 0 Then
      '      dpi.Value = ""
      '    Else
      '      dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
      '    End If
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    ''Item.DiscountRate
      '    'dpi = New DocPrintingItem
      '    'dpi.Mapping = "Item.DiscountRate"
      '    'dpi.Value = item.Discount.Rate
      '    'dpi.DataType = "System.String"
      '    'dpi.Row = n + 1
      '    'dpi.Table = "Item"
      '    'dpiColl.Add(dpi)

      '    ''Item.DiscountAmount
      '    'dpi = New DocPrintingItem
      '    'dpi.Mapping = "Item.DiscountAmount"
      '    'If item.Discount.Amount = 0 Then
      '    '  dpi.Value = ""
      '    'Else
      '    '  dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.Price)
      '    'End If
      '    'dpi.DataType = "System.String"
      '    'dpi.Row = n + 1
      '    'dpi.Table = "Item"
      '    'dpiColl.Add(dpi)

      '    'Item.Amount
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Amount"
      '    If item.Amount = 0 Then
      '      dpi.Value = ""
      '    Else
      '      dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
      '    End If
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Note
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Note"
      '    dpi.Value = item.Note
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.ZeroVat
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.ZeroVat"
      '    dpi.Value = item.UnVatable
      '    dpi.DataType = "System.Boolean"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    n += 1
      '  End If
      'Next
      Return dpiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.Status.Value <= 2 AndAlso Not Me.IsReferenced
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAssetSold}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAssetWriteoff", New SqlParameter() {New SqlParameter("@stock_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AssetWriteoffIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetWriteoffStatus" _
        ', New SqlParameter("@stock_id", Me.Id))
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

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        'Return False
        'UNDONE
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Return Me.Save(currentUserId)
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

    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.FromCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.FromCostCenter = Value
      End Set
    End Property


  End Class

  Public Class AssetSelectionForWriteOff
    Inherits Asset
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "AssetSelectionForWriteOff"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "AssetSelectionForWriteOff"
      End Get
    End Property
  End Class

  Public Class AssetWriteOffSelectionForSaleBillIssue
    Inherits AssetWriteOff
    Public Overrides ReadOnly Property Prefix As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "AssetWriteOffSelectionForSaleBillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "AssetWriteOffSelectionForSaleBillIssue"
      End Get
    End Property
  End Class

  Public Class AssetWriteOffSelectionForReceiveSelection
    Inherits AssetWriteOff
    Public Overrides ReadOnly Property Prefix As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "AssetWriteOffSelectionForReceiveSelection"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "AssetWriteOffSelectionForReceiveSelection"
      End Get
    End Property
  End Class
  '  Public Class AssetSoldItem
  '    Inherits EqtItem
  '#Region "Members"
  '    Private m_AssetSold As AssetSold
  '    Private m_sequenceRefedto As Integer 'อาจไม่ต้องมีแล้ว

  '    Private m_sequence As Integer


  '    Private m_rentalqty As Integer
  '    Private m_rentalperday As Decimal
  '    Private m_rentalAmt As Decimal
  '    'Private m_WBSDistributeCollection As WBSDistributeCollection
  '    'Private m_internalChargeCollection As InternalChargeCollection
  '#End Region

  '#Region "Constructors"
  '    Public Sub New()
  '      MyBase.New()
  '      'm_WBSDistributeCollection = New WBSDistributeCollection
  '    End Sub
  '    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
  '      Me.Construct(ds, aliasPrefix)
  '    End Sub
  '    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
  '      Me.Construct(dr, aliasPrefix)
  '    End Sub
  '    Protected Overrides Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
  '      MyBase.Construct(dr, aliasPrefix)
  '      With Me
  '        Dim deh As New DataRowHelper(dr)

  '        .m_rentalperday = deh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_rentalrate")
  '        .m_rentalqty = deh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_rentalqty")
  '        .m_rentalAmt = deh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_Amount")

  '        '' Sequence Refed to ...
  '        'If dr.Table.Columns.Contains(aliasPrefix & "refto") AndAlso Not dr.IsNull(aliasPrefix & "refto") Then
  '        '  .m_sequenceRefedto = CInt(dr(aliasPrefix & "refto"))
  '        'End If

  '        'If dr.Table.Columns.Contains(aliasPrefix & "stocki_sequence") AndAlso Not dr.IsNull(aliasPrefix & "stocki_sequence") Then
  '        '  m_sequence = CInt(dr(aliasPrefix & "stocki_sequence"))
  '        'End If


  '      End With
  '    End Sub
  '    Protected Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
  '      Dim dr As DataRow = ds.Tables(0).Rows(0)
  '      Me.Construct(dr, aliasPrefix)
  '    End Sub
  '#End Region

  '#Region "Properties"
  '    'Public Property WBSDistributeCollection() As WBSDistributeCollection  '    '  Get  '    '    Return m_WBSDistributeCollection  '    '  End Get  '    '  Set(ByVal Value As WBSDistributeCollection)  '    '    m_WBSDistributeCollection = Value  '    '  End Set  '    'End Property
  '    'Public Property InternalChargeCollection() As InternalChargeCollection  '    '  Get  '    '    If m_internalChargeCollection Is Nothing Then  '    '      m_internalChargeCollection = New InternalChargeCollection(Me)
  '    '    End If  '    '    Return m_internalChargeCollection  '    '  End Get  '    '  Set(ByVal Value As InternalChargeCollection)  '    '    m_internalChargeCollection = Value  '    '  End Set  '    'End Property

  '    'Public ReadOnly Property Sequence() As Integer  '    '  Get  '    '    Return m_sequence  '    '  End Get  '    'End Property
  '    Public Property RentalPerDay() As Decimal  '      Get  '        Return m_rentalperday  '      End Get  '      Set(ByVal value As Decimal)
  '        m_rentalperday = value
  '        m_rentalAmt = m_rentalperday * m_rentalqty
  '      End Set  '    End Property
  '    Public Property RentalQty() As Integer
  '      Get  '        Return m_rentalqty
  '      End Get  '      Set(ByVal value As Integer)
  '        m_rentalqty = value
  '      End Set
  '    End Property
  '    Public Property Amount() As Decimal  '      Get  '        Return m_rentalAmt  '      End Get  '      Set(ByVal value As Decimal)
  '        m_rentalAmt = value
  '        If m_rentalqty > 0 Then
  '          m_rentalperday = m_rentalAmt / m_rentalqty

  '        End If
  '      End Set  '    End Property
  '    Public Property AssetSold() As AssetSold
  '      Get  '        Return m_AssetSold  '      End Get  '      Set(ByVal Value As AssetSold)  '        m_AssetSold = Value  '      End Set  '    End Property
  '    Public Property SequenceRefedto() As Integer  '      Get  '        Return m_sequenceRefedto  '      End Get  '      Set(ByVal Value As Integer)  '        m_sequenceRefedto = Value  '      End Set  '    End Property  '    Public Function DupCode(ByVal myCode As String) As Boolean  '      If Me.AssetSold Is Nothing Then
  '        Return False
  '      End If  '      If myCode Is Nothing OrElse myCode.Length = 0 Then
  '        Return False
  '      End If
  '      For Each item As AssetSoldItem In Me.AssetSold.ItemCollection
  '        If Not item Is Me Then
  '          Dim theCode As String = ""
  '          If Not item.Entity Is Nothing Then
  '            theCode = item.Entity.Code
  '          End If
  '          If Not theCode Is Nothing AndAlso theCode.Length > 0 Then
  '            If myCode.ToLower = theCode.ToLower Then
  '              Return True
  '            End If
  '          End If
  '        End If
  '      Next
  '      Return False
  '    End Function  '    'Public Sub SetItemCode(ByVal theCode As String)  '    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
  '    '  If Me.ItemType Is Nothing Then
  '    '    'ไม่มี Type
  '    '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
  '    '    Return
  '    '  End If
  '    '  'If DupCode(theCode) Then
  '    '  '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {"Asset", theCode})
  '    '  '    Return
  '    '  'End If
  '    '  Select Case Me.ItemType.Value
  '    '    Case 342 'F/A
  '    '      If theCode Is Nothing OrElse theCode.Length = 0 Then
  '    '        If Me.Entity.Code.Length <> 0 Then
  '    '          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {Me.Entity.Code}) Then
  '    '            Me.Clear()
  '    '          End If
  '    '        End If
  '    '        Return
  '    '      End If
  '    '      Dim myEquipment As New EquipmentItem(theCode)
  '    '      If Not myEquipment.Originated Then
  '    '        msgServ.ShowMessageFormatted("${res:Global.Error.NoAsset}", New String() {theCode})
  '    '        Return
  '    '      Else
  '    '        Me.Entity = myEquipment
  '    '      End If
  '    '    Case 19 'Tool
  '    '      If theCode Is Nothing OrElse theCode.Length = 0 Then
  '    '        If Me.Entity.Code.Length <> 0 Then
  '    '          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {Me.Entity.Code}) Then
  '    '            Me.Clear()
  '    '          End If
  '    '        End If
  '    '        Return
  '    '      End If
  '    '      Dim myTool As New Tool(theCode)
  '    '      If Not myTool.Originated Then
  '    '        msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {theCode})
  '    '        Return
  '    '      Else
  '    '        Me.Entity = myTool
  '    '      End If
  '    '    Case Else
  '    '      msgServ.ShowMessage("${res:Global.Error.NoItemType}")
  '    '      Return
  '    '  End Select
  '    '  Me.Qty = 1
  '    'End Sub
  '#End Region

  '#Region "Methods"
  '    'Public Sub Clear()
  '    '  'Me.Entity = New AssetSoldItem
  '    '  Me.Qty = 0
  '    '  Me.Note = ""
  '    'End Sub
  '    Public Overrides Sub ItemValidateRow(ByVal row As DataRow)
  '      MyBase.ItemValidateRow(row)
  '      'Dim code As Object = row("Code")
  '    End Sub
  '    Public Overrides Sub CopyToDataRow(ByVal row As TreeRow)
  '      'MyBase.CopyToDataRow(row)
  '      If row Is Nothing Then
  '        Return
  '      End If
  '      Try
  '        Me.AssetSold.IsInitialized = False
  '        Dim rpd As Decimal = 0
  '        Dim rentrate As Decimal = 0
  '        row("Linenumber") = Me.LineNumber
  '        row("Type") = Me.ItemType.Value
  '        If Not Me.Entity Is Nothing Then
  '          row("eqtstocki_entity") = Me.Entity.Id
  '          row("Code") = Me.Entity.Code
  '          row("Name") = Me.Entity.Name
  '          If Not Me.Entity.Unit Is Nothing Then
  '            Me.Unit = Me.Entity.Unit
  '            row("UnitName") = Me.Entity.Unit.Name
  '          End If
  '          rentrate = Me.Entity.RentalRate
  '        End If

  '        'row("Name") = Me.name

  '        row("Button") = ""

  '        row("Note") = Me.Note

  '        If Me.Qty <> 0 Then
  '          row("QTY") = Configuration.FormatToString(Me.Qty, DigitConfig.Int)
  '        Else
  '          row("QTY") = ""
  '        End If
  '        rpd = rentrate * Me.Qty
  '        If Me.RentalPerDay <> 0 And rpd <> 0 Then
  '          If Me.RentalPerDay <> 0 Then
  '            row("RentalPerDay") = Configuration.FormatToString(Me.RentalPerDay, DigitConfig.Price)
  '          Else
  '            row("RentalPerDay") = Configuration.FormatToString(rpd, DigitConfig.Price)
  '            Me.RentalPerDay = rpd
  '          End If
  '        Else
  '          row("RentalPerDay") = ""
  '        End If

  '        Me.AssetSold.IsInitialized = True
  '      Catch ex As Exception
  '        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
  '      End Try
  '    End Sub
  '#End Region
  '  End Class


End Namespace
