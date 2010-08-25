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
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AssetWriteOffItem
    Inherits EqtItem
#Region "Members"
    Private m_AssetWriteoff As AssetWriteOff
    Private m_lineNumber As Integer

    Private m_unitPrice As Decimal
    'Private m_note As String
    'Private m_CostAmount As Decimal
    Private m_unvatable As Boolean = False
    Private m_discount As New Discount("")

    Private m_assetacct As Account
    Private m_accdepreacct As Account
    Private m_assetplacct As Account

    Private m_conversion As Decimal = 1

    Private m_deprecalc As Double
    Private m_RealRemainQty As Decimal
    Private m_buyUnitPrice As Decimal
    Private m_assetamount As Decimal

    Private m_amount As Decimal
    Private m_writeoffamount As Decimal

    Private m_accdepre As Decimal
    Private m_writeOffDepreAmount As Decimal

    Private m_hasChild As Boolean
    Private m_parent As Integer
    Private m_refSequence As Integer
    Private m_asset As Asset
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal stockid As Integer, ByVal line As Integer)

      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetAssetWriteoffItems" _
      , New SqlParameter("@stock_id", stockid) _
      , New SqlParameter("@stocki_linenumber", line) _
      )
      Me.Construct(ds.Tables(0).Rows(0), "")
    End Sub
    Protected Overrides Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      'MyBase.Construct(dr, aliasPrefix)
      Dim drh As New DataRowHelper(dr)
      With Me

        .Level = drh.GetValue(Of Integer)("eqtstocki_level")
        .m_itemtype = New EqtItemType(drh.GetValue(Of Integer)("eqtstocki_entityType"))

        Dim newItem As IEqtItem
        Select Case Level
          Case 0
            newItem = New Asset(dr, Me.AssetWriteoff)
          Case 1
            If .m_itemtype.Value = 19 Then
              newItem = New ToolLot(dr, Me.AssetWriteoff)
            ElseIf .m_itemtype.Value = 346 Then
              newItem = New EquipmentItem(dr, Me.AssetWriteoff)
            End If
        End Select
        .Entity = newItem
        .Name = newItem.Name

        Trace.WriteLine(newItem.Id.ToString & ":" & newItem.Code & ":" & newItem.Name)

        .m_unit = Unit.GetUnitById(drh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_unit"))
        .m_refSequence = drh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_refsequence")
        .m_RealRemainQty = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_remainbuyqty") 'ปริมาณคงเหลือ 1
        .m_buyUnitPrice = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_buyunitprice") 'ราคาซื้อ/หน่วย 2
        .m_assetamount = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_AssetAmount") 'มูลค่าสินทรัพย์ 3
        .m_accdepre = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_accdepre") 'ค่าเสื่อมสะสม 4
        .m_qty = drh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_qty") 'ปริมาณ 6
        .m_unitPrice = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_unitprice") 'ราคาขาย/หน่วย 7
        .m_amount = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_Amount") 'มูลค่าขาย 8
        .m_writeoffamount = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_writeoffAmt") 'มูลค่า Write Off 9
        .m_writeOffDepreAmount = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_writeoffaccdepre") 'ค่าเสื่อมสะสม Write Off 10

        'dr("eqtstocki_assetremainamount") = Me.AssetRemainAmount 'มูลค่าคงเหลือ 5
        'dr("eqtstocki_costamount") = Me.CostAmount 'ต้นทุนขาย 11
        'dr("eqtstocki_profitloss") = Me.ProfitLoss 'กำไร/ขาดทุน 12

        .m_assetacct = Account.GetAccountById(drh.GetValue(Of Integer)("eqtstocki_acct"))
        .m_accdepreacct = Account.GetAccountById(drh.GetValue(Of Integer)("eqtstocki_depreacct"))
        .m_assetplacct = Account.GetAccountById(drh.GetValue(Of Integer)("eqtstocki_placct"))

        .Note = drh.GetValue(Of String)(aliasPrefix & "eqtstocki_note")
        .m_parent = drh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_parent")
        .m_fromstatus = New EqtStatus(drh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_parent"))
        .m_tostatus = New EqtStatus(drh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_parent"))
        'If dr.Table.Columns.Contains(aliasPrefix & "stocki_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unvatable") Then
        '  .m_unvatable = CBool(dr(aliasPrefix & "stocki_unvatable"))
        'End If

        'If dr.Table.Columns.Contains(aliasPrefix & "stocki_tag") AndAlso Not dr.IsNull(aliasPrefix & "stocki_tag") Then
        '  .m_deprecalc = CDbl(dr(aliasPrefix & "stocki_tag"))
        'End If

        .HasChild = drh.GetValue(Of Integer)("haschilds") > 0
        .Asset = New Asset(dr, Me.AssetWriteoff)

      End With
    End Sub
    Protected Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property AssetAmount As Decimal
      Get
        Return m_assetamount ' Me.RealRemainQty * Me.BuyUnitPrice
      End Get
      Set(ByVal value As Decimal)
        m_assetamount = value
      End Set
    End Property
    Public Property WriteOffDepreAmount As Decimal
      Get
        Dim amt As Decimal
        If TypeOf Me.Entity Is Asset Then
          amt = m_writeOffDepreAmount
        Else
          If Me.RealRemainQty = 0 Then
            amt = 0
          Else
            amt = (Me.AccDepre / Me.RealRemainQty) * Me.Qty
          End If
        End If

        Return amt
      End Get
      Set(ByVal value As Decimal)
        m_writeOffDepreAmount = value
      End Set
    End Property
    Public Property AssetWriteoff() As AssetWriteOff      Get        Return m_AssetWriteoff      End Get      Set(ByVal Value As AssetWriteOff)        m_AssetWriteoff = Value      End Set    End Property    Public ReadOnly Property RemainBuyQty As Decimal
      Get
        Return Me.RealRemainQty 'Me.RemainingQty - Me.Qty 'm_remainbuyqty
      End Get
      'Set(ByVal value As Decimal)
      '  m_remainbuyqty = value
      'End Set
    End Property    Public Property BuyUnitPrice As Decimal 'มูลค่าซื้อต่อหน่วย
      Get
        Return m_buyUnitPrice
      End Get
      Set(ByVal value As Decimal)
        m_buyUnitPrice = value
        m_assetamount = Me.RealRemainQty * m_buyUnitPrice
        m_writeoffamount = Me.Qty * m_buyUnitPrice
      End Set
    End Property    Public ReadOnly Property AssetRemainAmount As Decimal 'มูลค่าสินทรัพย์หักออก      Get
        Return Me.AssetAmount - Me.AccDepre
      End Get
    End Property    Public Property WriteOffAmount As Decimal 'มูลค่าสินทรัพย์ที่จะ write-off ในครั้งนี้ เอาไปลงบัญชี asset
      Get
        Return m_writeoffamount 'Me.Qty * Me.BuyUnitPrice 'm_writeoffamount
      End Get
      Set(ByVal value As Decimal)
        m_writeoffamount = value
      End Set
    End Property    Public Property Parent() As Integer      Get
        Return m_parent
      End Get
      Set(ByVal Value As Integer)
        m_parent = Value
      End Set
    End Property    Public Property HasChild() As Boolean
      Get
        Return m_hasChild
      End Get
      Set(ByVal Value As Boolean)
        m_hasChild = Value
      End Set
    End Property    Public Property UnitPrice() As Decimal 'ราคาที่ขาย      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        m_unitPrice = Value        m_amount = m_unitPrice * Me.Qty      End Set    End Property    Public Property AccDepre As Decimal 'เอาไปลงบัญชี accom depre
      Get
        Return m_accdepre
      End Get
      Set(ByVal value As Decimal)
        m_accdepre = value
      End Set
    End Property    Public ReadOnly Property CostAmount() As Decimal 'ต้นทุนของสินทรัพย์ที่ขาย      Get        Return WriteOffAmount - Me.WriteOffDepreAmount 'm_CostAmount      End Get      'Set(ByVal Value As Decimal)      '  m_Cost = Value      'End Set    End Property    Public Property AssetAccount() As Account      Get
        Return Me.m_assetacct
      End Get
      Set(ByVal Value As Account)
        m_assetacct = Value
      End Set
    End Property    Public Property AccDepreAccount() As Account      Get
        Return m_accdepreacct
      End Get
      Set(ByVal Value As Account)
        m_accdepreacct = Value
      End Set
    End Property    Public Property PLAccount As Account      Get
        Return m_assetplacct
      End Get
      Set(ByVal value As Account)
        m_assetplacct = value
      End Set
    End Property    Public Property DepreCalculation() As Double      Get
        Return m_deprecalc
      End Get
      Set(ByVal Value As Double)
        m_deprecalc = Value
      End Set
    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Me.Conversion * Me.Qty      End Get    End Property    'Public Property Discount() As Discount 'ไม่มีส่วนลดต่อ item    '  Get    '    Return m_discount    '  End Get    '  Set(ByVal Value As Discount)    '    m_discount = Value    '  End Set    'End Property
    Public Overrides Property Amount() As Decimal 'ในที่นี้คือ มูลค่าที่ขาย
      Get
        Return m_amount '(Me.UnitPrice * Me.Qty) 
      End Get
      Set(ByVal value As Decimal)
        m_amount = value
      End Set
    End Property
    Public ReadOnly Property ProfitLoss() As Decimal 'กำไรขาดทุนจากการขายสินทรัพย์
      Get
        Return Me.Amount - Me.CostAmount
      End Get
    End Property
    Public Property UnVatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property
    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
    Public Property RealRemainQty As Decimal
      Get
        Return m_RealRemainQty
      End Get
      Set(ByVal value As Decimal)
        m_RealRemainQty = value
        m_assetamount = m_RealRemainQty * Me.BuyUnitPrice
      End Set
    End Property
    Public Property Level As Integer
    Public Property RemainingQty As Decimal
    Public Overrides Property Qty As Integer
      Get
        Return Me.m_qty
      End Get
      Set(ByVal value As Integer)
        Dim qty As Integer = 0
        If TypeOf Me.Entity Is Asset Then
          If Not Me.HasChild Then
            qty = 1
          End If
        ElseIf TypeOf Me.Entity Is EquipmentItem Then
          qty = 1
        Else
          qty = value
          If qty > Me.RemainingQty Then
            'Dim myPars As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim myMsg As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'myPars.Parse("$res:{Longkong.Pojjaman.BusinessLogic.AssetWriteOffItem.OverWriteOffQty}")
            myMsg.ShowErrorFormatted("${res:Longkong.Pojjaman.BusinessLogic.AssetWriteOffItem.OverWriteOffQty}", _
                                     New String() {Configuration.FormatToString(value, DigitConfig.Price), _
                                                   Configuration.FormatToString(RemainingQty, DigitConfig.Price)})
            Return
          End If
          Me.m_qty = qty
          Me.m_amount = Me.UnitPrice * Me.m_qty
          Me.m_writeoffamount = m_qty * Me.BuyUnitPrice
        End If
      End Set
    End Property
    Public Property RefSequence As Integer
      Get
        Return m_refSequence
      End Get
      Set(ByVal value As Integer)
        m_refSequence = value
      End Set
    End Property
    Public Property Asset As Asset
      Get
        If m_asset Is Nothing Then
          m_asset = New Asset
        End If
        Return m_asset
      End Get
      Set(ByVal value As Asset)
        m_asset = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Overrides Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If
      Me.AssetWriteoff.IsInitialized = False

      If Me.LineNumber = 0 Then
        'row("LineNumber") = ""
      Else
        row("LineNumber") = Me.LineNumber
      End If

      row("Type") = Me.ItemType.Description

      If Not Me.Entity Is Nothing Then
        row("Code") = Me.Entity.Code
        row("Entity") = Me.Entity.Id
        row("EntityType") = Me.ItemType.Value
        row("Description") = Me.Entity.Name
        'row("deprecalcamt") = Me.DepreCalculation
      End If

      If Not Me.Unit Is Nothing Then
        row("UnitId") = Me.Unit.Id
        row("Unit") = Me.Unit.Name
      End If
      Me.Conversion = 1

      If Me.RemainBuyQty <> 0 Then
        row("RemainingQty") = Configuration.FormatToString(Me.RemainBuyQty, DigitConfig.Qty)
      Else
        row("RemainingQty") = ""
      End If

      If Me.BuyUnitPrice <> 0 Then
        row("BuyPrice") = Configuration.FormatToString(Me.BuyUnitPrice, DigitConfig.UnitPrice)
      Else
        row("BuyPrice") = ""
      End If

      If Me.AssetAmount <> 0 Then
        row("AssetAmount") = Configuration.FormatToString(Me.AssetAmount, DigitConfig.Price)
      Else
        row("AssetAmount") = ""
      End If

      If Me.AccDepre <> 0 Then
        row("DepreAmount") = Configuration.FormatToString(Me.AccDepre, DigitConfig.UnitPrice)
      Else
        row("DepreAmount") = ""
      End If

      If Me.AssetRemainAmount <> 0 Then
        row("RemainingAmount") = Configuration.FormatToString(Me.AssetRemainAmount, DigitConfig.UnitPrice)
      Else
        row("RemainingAmount") = ""
      End If

      If Me.Qty <> 0 Then
        row("Qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
      Else
        row("Qty") = ""
      End If

      If Me.UnitPrice <> 0 Then
        row("UnitPrice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
      Else
        row("UnitPrice") = ""
      End If

      If Me.Amount <> 0 Then
        row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      Else
        row("Amount") = ""
      End If

      If Me.WriteOffAmount <> 0 Then
        row("WriteOffAmount") = Configuration.FormatToString(Me.WriteOffAmount, DigitConfig.UnitPrice)
      Else
        row("WriteOffAmount") = ""
      End If

      If Me.WriteOffDepreAmount <> 0 Then
        row("WriteOffDepreAmount") = Configuration.FormatToString(Me.WriteOffDepreAmount, DigitConfig.UnitPrice)
      Else
        row("WriteOffDepreAmount") = ""
      End If

      If Me.CostAmount <> 0 Then
        row("CostAmount") = Configuration.FormatToString(Me.CostAmount, DigitConfig.UnitPrice)
      Else
        row("CostAmount") = ""
      End If

      If Me.ProfitLoss <> 0 Then
        row("P/L") = Configuration.FormatToString(Me.ProfitLoss, DigitConfig.UnitPrice)
      Else
        row("P/L") = ""
      End If

      If Not Me.AssetAccount Is Nothing Then
        row("Account") = Me.AssetAccount.Id
        'row("AccountCode") = Me.AccDepreAccount.Code
        'row("Account") = Me.AccDepreAccount.Name
      End If
      If Not Me.AccDepreAccount Is Nothing Then
        row("DepreAccount") = Me.AccDepreAccount.Id
        'row("AccountCode") = Me.AccDepreAccount.Code
        'row("Account") = Me.AccDepreAccount.Name
      End If
      'If Not Me.PLAccount Is Nothing Then
      '  row("PLAccount") = Me.PLAccount.Id
      '  'row("AccountCode") = Me.AccDepreAccount.Code
      '  'row("Account") = Me.AccDepreAccount.Name
      'End If

      row("Note") = Me.Note
      
      'row("stocki_unvatable") = Me.UnVatable

      Me.AssetWriteoff.IsInitialized = True
    End Sub
    'Public Sub CopyFromDataRow(ByVal row As TreeRow)
    '  If row Is Nothing Then
    '    Return
    '  End If

    '  Try

    '    If Not row.IsNull("stocki_entity") Then
    '      Me.Entity = New Asset(CInt(row("stocki_entity")))
    '    End If

    '    If Not row.IsNull(("stocki_linenumber")) Then
    '      Me.LineNumber = CInt(row("stocki_linenumber"))
    '    End If

    '    If Not row.IsNull(("stocki_unit")) Then
    '      Me.Unit = New Unit(CInt(row("stocki_unit")))
    '    Else
    '      Me.Unit = New Unit
    '    End If

    '    If Not row.IsNull(("stocki_acct")) Then
    '      Me.AccDepreAccount = New Account(CInt(row("stocki_acct")))
    '    Else
    '      Me.AccDepreAccount = New Account
    '    End If


    '    If Not row.IsNull("stocki_entityType") Then
    '      Me.ItemType = New EqtItemType(CInt(row("stocki_entityType")))
    '    End If

    '    If Not row.IsNull("deprecalcamt") AndAlso IsNumeric(row("deprecalcamt")) Then
    '      Me.DepreCalculation = CDbl(row("deprecalcamt"))
    '    End If

    '    If Not row.IsNull(("stocki_note")) Then
    '      Me.Note = CStr(row("stocki_note"))
    '    End If

    '    GetAmountFromRow(row)
    '  Catch ex As Exception
    '    MessageBox.Show(ex.Message & "::" & ex.StackTrace)
    '  End Try

    'End Sub
    Public Sub GetAmountFromRow(ByVal row As TreeRow)
      'เพื่อประหยัด ไม่ต้องสร้าง Entity
      If Not row.IsNull(("eqtstocki_qty")) Then
        If CStr(row("eqtstocki_qty")).Length = 0 Then
          Me.Qty = 0
        Else
          Me.Qty = CInt(row("eqtstocki_qty"))
        End If
      End If
      'If Not row.IsNull(("stocki_discrate")) Then
      '  Me.Discount.Rate = CStr(row("stocki_discrate"))
      'End If
      If Not row.IsNull(("eqtstocki_unitprice")) Then
        If CStr(row("eqtstocki_unitprice")).Length = 0 Then
          Me.UnitPrice = 0
        Else
          Me.UnitPrice = CDec(row("eqtstocki_unitprice"))
        End If
      End If
      'If Not row.IsNull(("cost")) Then
      '  If CStr(row("cost")).Length = 0 Then
      '    Me.m_CostAmount = 0
      '  Else
      '    Me.m_CostAmount = CDec(row("cost"))
      '  End If
      'End If
      'If Not row.IsNull("stocki_unvatable") Then
      '  Me.UnVatable = CBool(row("stocki_unvatable"))
      'End If
    End Sub
    Sub SetItem(ByVal newItem As IEqtItem, ByVal itemType As Integer, ByVal dr As DataRow, ByVal hasChild As Boolean, ByVal level As Integer, ByVal item As EqtBasketItem)
      Dim drh As New DataRowHelper(dr)
      With Me
        .Entity = newItem
        .Name = newItem.Name
        .FromStatus = New EqtStatus(drh.GetValue(Of Integer)("fromStatus"))
        .ToStatus = New EqtStatus(9) 'writeOff
        .ItemType = New EqtItemType(itemType)
        .Unit = newItem.Unit
        Select Case itemType
          Case 28
            If hasChild Then
              .RemainingQty = 0
              .Qty = 0
              .RealRemainQty = 0
              .BuyUnitPrice = 0
              .UnitPrice = 0
            Else
              .RemainingQty = 1
              .Qty = 1
              .RealRemainQty = 1
              .BuyUnitPrice = drh.GetValue(Of Decimal)("asset_buyPrice")
              .UnitPrice = drh.GetValue(Of Decimal)("asset_buyPrice")
            End If
            .m_accdepre = drh.GetValue(Of Decimal)("accdepre")
          Case 19
            .RemainingQty = CInt(item.Qty)
            .Qty = CInt(item.Qty)
            .RealRemainQty = drh.GetValue(Of Decimal)("RealRemainQty")
            .BuyUnitPrice = drh.GetValue(Of Decimal)("eqi_buycost")
            .UnitPrice = drh.GetValue(Of Decimal)("eqi_buycost")
            .m_ownercc = CostCenter.GetCCMinDataById(drh.GetValue(Of Integer)("eqtcc"))
          Case 346
            .RemainingQty = 1
            .Qty = 1
            .RealRemainQty = drh.GetValue(Of Decimal)("RealRemainQty")
            .BuyUnitPrice = drh.GetValue(Of Decimal)("eqi_buycost")
            .UnitPrice = drh.GetValue(Of Decimal)("eqi_buycost")
            .m_ownercc = CostCenter.GetCCMinDataById(drh.GetValue(Of Integer)("eqtcc"))
        End Select
        .HasChild = hasChild
        'If level = 0 Then
        .Level = level
        .AssetAccount = New Account(drh.GetValue(Of Integer)("asset_acct"))
        .AccDepreAccount = New Account(drh.GetValue(Of Integer)("asset_depreopeningacct"))

        .RefSequence = drh.GetValue(Of Integer)("createseq")
        .Asset = New Asset(dr, Me.AssetWriteoff)
        .Parent = .Asset.Id
        .PLAccount = .Asset.PLAccount

        'ElseIf level = 1 Then
        'm_parent = drh.GetValue(Of Integer)("asset")
        'End If


      End With

    End Sub
#End Region

#Region "Shared"
    Public Shared Function GetListDatatable2(ByVal ParamArray filters() As Filter) As TreeTable

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim dt As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetAssetWriteoffItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("AssetWriteoffItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stock_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DueDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDueDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("ToCostcenter", GetType(String)))

      For Each tableRow As DataRow In dt.Rows
        Dim gri As New AssetWriteOffItem(tableRow, "")
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("Code") = tableRow("stock_code")
        row("stock_id") = tableRow("stocki_stock")
        row("Linenumber") = tableRow("stocki_linenumber")
        row("Date") = tableRow("stock_docdate")
        row("DueDate") = tableRow("stock_docdate")

        row("Entity") = tableRow("stocki_entity")
        row("Qty") = gri.Qty
        row("ToCostcenter") = tableRow("toccinfo")
        row.State = RowExpandState.None
      Next
      Return myDatatable
    End Function
#End Region

    

  End Class


  <Serializable(), Reflection.DefaultMember("Item")> _
  Public Class AssetWriteOffItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_AssetWriteoff As AssetWriteOff
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As AssetWriteOff)
      Me.m_AssetWriteoff = owner
      If Not Me.m_AssetWriteoff.Originated Then
        Return
      End If

      Dim sqlConString As String = Services.RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetAssetWriteoffItems" _
      , New SqlParameter("@stock_id", Me.m_AssetWriteoff.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New AssetWriteOffItem(row, "")
        item.AssetWriteoff = m_AssetWriteoff
        Me.Add(item)
        'Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        'item.WBSDistributeCollection = wbsdColl
        'For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & item.Sequence)
        '  Dim wbsd As New WBSDistribute(wbsRow, "")
        '  wbsdColl.Add(wbsd)
        'Next

        'Dim itcColl As New InternalChargeCollection(item)
        'item.InternalChargeCollection = itcColl
        'For Each itcRow As DataRow In ds.Tables(2).Select("itci_refsequence=" & item.Sequence)
        '  Dim itc As New InternalCharge(itcRow, "")
        '  itcColl.Add(itc)
        'Next
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property AssetWriteoff() As AssetWriteOff
      Get
        Return m_AssetWriteoff
      End Get
      Set(ByVal Value As AssetWriteOff)
        m_AssetWriteoff = Value
      End Set
    End Property
    Default Public Property Item(ByVal index As Integer) As AssetWriteOffItem
      Get
        Return CType(MyBase.List.Item(index), AssetWriteOffItem)
      End Get
      Set(ByVal value As AssetWriteOffItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property CurrentItem() As AssetWriteOffItem
    '  Get
    '    Return m_currentItem
    '  End Get
    '  Set(ByVal Value As EqtItem)
    '    m_currentItem = Value
    '  End Set
    'End Property
    Public ReadOnly Property Gross As Decimal
      Get
        Dim ret As Decimal = 0
        For Each Item As AssetWriteOffItem In Me
          ret += Item.Amount
        Next
        Return ret
      End Get
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable, ByVal tg As DataGrid)
      dt.Clear()
      Dim i As Integer = 0

      Dim currItem As AssetWriteOffItem = Me.CurrentItem

      'Dim hashAsset As New Hashtable
      Dim key As Integer = 0
      Dim parrow As TreeRow = Nothing
      For Each gri As AssetWriteOffItem In Me
        If gri.Level = 0 Then
          i += 1
          gri.LineNumber = i
          'key = gri.Entity.Id
          'If Not hashAsset.Contains(key) Then
          parrow = dt.Childs.Add
          parrow.State = RowExpandState.Expanded
          gri.CopyToDataRow(parrow)
          parrow.Tag = gri
          'End If
        Else
          gri.LineNumber = 0
          If Not parrow Is Nothing Then
            Dim childrow As TreeRow = parrow.Childs.Add
            'childrow.State = RowExpandState.Expanded
            gri.CopyToDataRow(childrow)
            childrow.Tag = gri
          End If
        End If

        'Dim newRow As TreeRow = dt.Childs.Add()
        'gri.CopyToDataRow(newRow)
        ''gri.ItemValidateRow(newRow)
        'newRow.Tag = gri
      Next

      dt.AcceptChanges()

      Do Until dt.Rows.Count > tg.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        dt.Childs.Add()
      Loop

      Try
        If (Not dt.Rows(dt.Rows.Count - 1).IsNull("eqtstocki_entityType")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
          '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          dt.Childs.Add()
        End If
      Catch ex As Exception

      End Try

      dt.AcceptChanges()

      Me.CurrentItem = currItem
    End Sub
    Public Sub SetItems(ByVal items As BasketItemCollection)
      Dim currItem As AssetWriteOffItem = Nothing

      For i As Integer = items.Count - 1 To 0 Step -1
        If TypeOf items(i) Is EqtBasketItem Then

          Dim item As EqtBasketItem = CType(items(i), EqtBasketItem)
          Dim dr As DataRow = CType(item.Tag, DataRow)
          Dim drh As New DataRowHelper(dr)

          Dim hasChild As Boolean = item.haschilds
          Dim level As Integer = item.Level
          Dim newItem As IEqtItem
          Dim newType As Integer = -1

          Trace.WriteLine(item.Level.ToString)

          Select Case level
            Case 0
              'newItem = New Asset(dr, Me.m_AssetWriteoff)
              newItem = New Asset(dr, Me.AssetWriteoff)
              'newItem.Id = drh.GetValue(Of Integer)("asset_id")
              'newItem.Name = drh.GetValue(Of String)("asset_name")
              newType = 28
            Case 1
              If drh.GetValue(Of Integer)("type") = 19 Then
                newItem = New ToolLot(dr, Me.AssetWriteoff)
                'newItem.Id = drh.GetValue(Of Integer)("eqtid")
                'newItem.Name = drh.GetValue(Of String)("eqtname")
                newType = drh.GetValue(Of Integer)("type")
              ElseIf drh.GetValue(Of Integer)("type") = 346 Then
                newItem = New EquipmentItem(dr, Me.AssetWriteoff)
                'newItem.Id = drh.GetValue(Of Integer)("eqtid")
                'newItem.Name = drh.GetValue(Of String)("eqtname")
                newType = drh.GetValue(Of Integer)("type")
              End If
              'Case 346
              '  newItem = New EquipmentItem(dr, Me.AssetWriteoff)
              '  'newItem.Id = drh.GetValue(Of Integer)("eqtid")
              '  'newItem.Name = drh.GetValue(Of String)("eqtname")
              '  newType = 346

          End Select

          Dim doc As New AssetWriteOffItem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.ItemType.Value = newType
            Me.CurrentItem = Nothing
            currItem = doc
          Else
            'Me.Add(doc)
            If currItem Is Nothing Then
              'Me.Insert(0, doc)
              Me.Add(doc)
            Else
              Me.Insert(Me.IndexOf(currItem), doc)
            End If
            doc.ItemType = New EqtItemType(newType)
            currItem = doc
          End If

          doc.SetItem(newItem, newType, dr, hasChild, level, item)
          doc.AssetWriteoff = Me.AssetWriteoff

        End If
      Next

    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As AssetWriteOffItem) As Integer
      If Not m_AssetWriteoff Is Nothing Then
        value.AssetWriteoff = m_AssetWriteoff
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As AssetWriteOffItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As AssetWriteOffItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As AssetWriteOffItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As AssetWriteOffItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As AssetWriteOffItemEnumerator
      Return New AssetWriteOffItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As AssetWriteOffItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As AssetWriteOffItem)
      If Not m_AssetWriteoff Is Nothing Then
        value.AssetWriteoff = m_AssetWriteoff
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As AssetWriteOffItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As AssetWriteOffItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class AssetWriteOffItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As AssetWriteOffItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, AssetWriteOffItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class

    'Function EqIdList() As Object
    '  Dim list As New Generic.List(Of String)
    '  For Each i As AssetSoldItem In Me
    '    If TypeOf i.Entity Is EquipmentItem Then
    '      list.Add(i.Entity.Id.ToString)
    '    End If
    '  Next
    '  Return String.Join(",", list)

    'End Function

  End Class


End Namespace

