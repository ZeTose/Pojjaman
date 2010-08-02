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
    Private m_note As String
    Private m_Cost As Decimal
    Private m_unvatable As Boolean = False
    Private m_discount As New Discount("")

    Private m_assetacct As Account
    Private m_accdepreacct As Account

    Private m_conversion As Decimal = 1


    Private m_deprecalc As Double
    Private m_remainbuyqty As Decimal
    Private m_unitassetamount As Decimal
    Private m_assetamount As Decimal
    Private m_writeoffamount As Decimal

    Private m_accdepre As Decimal
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
      MyBase.Construct(dr, aliasPrefix)
      Dim drh As New DataRowHelper(dr)
      With Me


        .m_unitPrice = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_unitprice")
        .m_remainbuyqty = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_remainbuyqty")
        .m_unit = Unit.GetUnitById(drh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_unit"))
        .m_unitassetamount = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_unitassetamount")
        .m_assetamount = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_assetamount")
        .m_writeoffamount = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_writeoffamount")

        .m_accdepre = drh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_accdepre")
        .m_assetacct = Account.GetAccountById(drh.GetValue(Of Integer)("asset_acct"))
        .m_accdepreacct = Account.GetAccountById(drh.GetValue(Of Integer)("asset_depreopeningacct"))



        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unvatable") Then
          .m_unvatable = CBool(dr(aliasPrefix & "stocki_unvatable"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_tag") AndAlso Not dr.IsNull(aliasPrefix & "stocki_tag") Then
          .m_deprecalc = CDbl(dr(aliasPrefix & "stocki_tag"))
        End If

      End With
    End Sub
    Protected Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property AssetWriteoff() As AssetWriteOff      Get        Return m_AssetWriteoff      End Get      Set(ByVal Value As AssetWriteOff)        m_AssetWriteoff = Value      End Set    End Property    Public Property RemainBuyQty As Decimal
      Get
        Return m_remainbuyqty
      End Get
      Set(ByVal value As Decimal)
        m_remainbuyqty = value
      End Set
    End Property    Public Property UnitAssetAmount As Decimal 'มูลค่าซื้อต่อหน่วย
      Get
        Return m_unitassetamount
      End Get
      Set(ByVal value As Decimal)
        m_unitassetamount = value
      End Set
    End Property    Public Property AssetAmount As Decimal 'มูลค่าสินทรัพย์หักออก      Get
        Return m_assetamount
      End Get
      Set(ByVal value As Decimal)
        m_assetamount = value
      End Set
    End Property    Public Property WriteOffAmount As Decimal 'มูลค่าสินทรัพย์ที่จะ write-off ในครั้งนี้ เอาไปลงบัญชี asset
      Get
        Return m_writeoffamount
      End Get
      Set(ByVal value As Decimal)
        m_writeoffamount = value
      End Set
    End Property    Public Property UnitPrice() As Decimal 'ราคาที่ขาย      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        m_unitPrice = Value      End Set    End Property    Public Property AccDepre As Decimal 'เอาไปลงบัญชี accom depre
      Get
        Return m_accdepre
      End Get
      Set(ByVal value As Decimal)
        m_accdepre = value
      End Set
    End Property
    Public Property Cost() As Decimal 'ต้นทุนของสินทรัพย์ที่ขาย      Get        Return m_Cost      End Get      Set(ByVal Value As Decimal)        m_Cost = Value      End Set    End Property    Public Property AssetAccount() As Account      Get
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
    End Property    Public Property DepreCalculation() As Double      Get
        Return m_deprecalc
      End Get
      Set(ByVal Value As Double)
        m_deprecalc = Value
      End Set
    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Me.Conversion * Me.Qty      End Get    End Property    'Public Property Discount() As Discount 'ไม่มีส่วนลดต่อ item    '  Get    '    Return m_discount    '  End Get    '  Set(ByVal Value As Discount)    '    m_discount = Value    '  End Set    'End Property
    Public ReadOnly Property Amount() As Decimal 'ในที่นี้คือ มูลค่าที่ขาย
      Get
        'Me.Discount.AmountBeforeDiscount = (Me.UnitPrice * Me.Qty)
        Return (Me.UnitPrice * Me.Qty) '- Me.Discount.Amount
      End Get
    End Property
    Public ReadOnly Property ProfitLoss() As Decimal 'กำไรขาดทุนจากการขายสินทรัพย์
      Get
        Return Amount - cost
      End Get
    End Property
    Public Property UnVatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property
    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Overrides Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If
      Me.AssetWriteoff.IsInitialized = False

      row("eqtstocki_linenumber") = Me.LineNumber

      If Not Me.Entity Is Nothing Then
        row("Code") = Me.Entity.Code
        row("eqtstocki_entity") = Me.Entity.Id
        row("eqtstocki_entityType") = Me.ItemType
        row("eqtstocki_Name") = Me.Entity.Name
        'row("deprecalcamt") = Me.DepreCalculation
      End If

      If Not Me.Unit Is Nothing Then
        row("eqtstocki_unit") = Me.Unit.Id
        row("Unit") = Me.Unit.Name
      End If

      If Me.Qty <> 0 Then
        row("eqtstocki_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
      Else
        row("eqtstocki_qty") = ""
      End If

      If Me.UnitPrice <> 0 Then
        row("eqtstocki_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
      Else
        row("eqtstocki_unitprice") = ""
      End If

      If Me.Amount <> 0 Then
        row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      Else
        row("Amount") = ""
      End If
      Me.Conversion = 1

      If Me.RemainBuyQty <> 0 Then
        row("eqtstocki_remainbuyqty") = Configuration.FormatToString(Me.RemainBuyQty, DigitConfig.Qty)
      Else
        row("eqtstocki_remainbuyqty") = ""
      End If

      If Me.UnitAssetAmount <> 0 Then
        row("eqtstocki_unitassetamount") = Configuration.FormatToString(Me.UnitAssetAmount, DigitConfig.Qty)
      Else
        row("eqtstocki_unitassetamount") = ""
      End If

      If Me.AssetAmount <> 0 Then
        row("eqtstocki_assetamount") = Configuration.FormatToString(Me.AssetAmount, DigitConfig.Qty)
      Else
        row("eqtstocki_assetamount") = ""
      End If

      If Me.WriteOffAmount <> 0 Then
        row("eqtstocki_writeoffamount") = Configuration.FormatToString(Me.WriteOffAmount, DigitConfig.Qty)
      Else
        row("eqtstocki_writeoffamount") = ""
      End If

      If Me.AccDepre <> 0 Then
        row("eqtstocki_accdepre") = Configuration.FormatToString(Me.AccDepre, DigitConfig.Qty)
      Else
        row("eqtstocki_accdepre") = ""
      End If

      If Me.Cost <> 0 Then
        row("Cost") = Configuration.FormatToString(Me.Cost, DigitConfig.Qty)
      Else
        row("Cost") = ""
      End If

      If Me.ProfitLoss <> 0 Then
        row("P/L") = Configuration.FormatToString(Me.ProfitLoss, DigitConfig.Qty)
      Else
        row("P/L") = ""
      End If

      If Not Me.AssetAccount Is Nothing Then
        row("asset_acct") = Me.AssetAccount.Id
        'row("AccountCode") = Me.AccDepreAccount.Code
        'row("Account") = Me.AccDepreAccount.Name
      End If

      If Not Me.AccDepreAccount Is Nothing Then
        row("asset_depreopeningacct") = Me.AccDepreAccount.Id
        'row("AccountCode") = Me.AccDepreAccount.Code
        'row("Account") = Me.AccDepreAccount.Name
      End If


      row("eqtstocki_note") = Me.Note
      
      
      'row("stocki_unvatable") = Me.UnVatable

      Me.AssetWriteoff.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If

      Try

        If Not row.IsNull("stocki_entity") Then
          Me.Entity = New Asset(CInt(row("stocki_entity")))
        End If

        If Not row.IsNull(("stocki_linenumber")) Then
          Me.LineNumber = CInt(row("stocki_linenumber"))
        End If

        If Not row.IsNull(("stocki_unit")) Then
          Me.Unit = New Unit(CInt(row("stocki_unit")))
        Else
          Me.Unit = New Unit
        End If

        If Not row.IsNull(("stocki_acct")) Then
          Me.AccDepreAccount = New Account(CInt(row("stocki_acct")))
        Else
          Me.AccDepreAccount = New Account
        End If


        If Not row.IsNull("stocki_entityType") Then
          Me.ItemType = New EqtItemType(CInt(row("stocki_entityType")))
        End If

        If Not row.IsNull("deprecalcamt") AndAlso IsNumeric(row("deprecalcamt")) Then
          Me.DepreCalculation = CDbl(row("deprecalcamt"))
        End If

        If Not row.IsNull(("stocki_note")) Then
          Me.Note = CStr(row("stocki_note"))
        End If

        GetAmountFromRow(row)
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub
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
      If Not row.IsNull(("cost")) Then
        If CStr(row("cost")).Length = 0 Then
          Me.Cost = 0
        Else
          Me.Cost = CDec(row("cost"))
        End If
      End If
      'If Not row.IsNull("stocki_unvatable") Then
      '  Me.UnVatable = CBool(row("stocki_unvatable"))
      'End If
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
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each gri As AssetWriteOffItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        gri.CopyToDataRow(newRow)
        'gri.ItemValidateRow(newRow)
        newRow.Tag = gri
      Next
      dt.AcceptChanges()
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

