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
    Public Class AssetSoldItem
    Inherits EqtItem
#Region "Members"
    Private m_assetSold As AssetSold
    Private m_lineNumber As Integer

    Private m_itemType As Integer
    Private m_entity As Asset
    Private m_entityName As String
    Private m_unit As Unit
    Private m_qty As Decimal
    Private m_unitPrice As Decimal
    Private m_note As String
    Private m_unitCost As Decimal
    Private m_stockQty As Decimal
    Private m_unvatable As Boolean = False
    Private m_discount As New Discount("")
    Private m_account As Account
    Private m_conversion As Decimal = 1

    Private m_deprecalc As Double

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
      , "GetAssetSoldItems" _
      , New SqlParameter("@stock_id", stockid) _
      , New SqlParameter("@stocki_linenumber", line) _
      )
      Me.Construct(ds.Tables(0).Rows(0), "")
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_entityType") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entityType") Then
          .m_itemType = CInt(dr(aliasPrefix & "stocki_entityType"))
        End If

        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_entity") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entity") Then
          .m_entity = New Asset(CInt(dr(aliasPrefix & "stocki_entity")))
        Else
          .m_entity = New Asset
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_itemName") AndAlso Not dr.IsNull(aliasPrefix & "stocki_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "stocki_itemName"))
        Else
          .m_entityName = ""
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "stocki_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_qty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "stocki_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unitprice") Then
          .m_unitPrice = CDec(dr(aliasPrefix & "stocki_unitprice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unitcost") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unitcost") Then
          .m_unitCost = CDec(dr(aliasPrefix & "stocki_unitcost"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_stockqty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stockqty") Then
          .m_stockQty = CDec(dr(aliasPrefix & "stocki_stockqty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_note") AndAlso Not dr.IsNull(aliasPrefix & "stocki_note") Then
          .m_note = CStr(dr(aliasPrefix & "stocki_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_unit") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & "stocki_unit")))
            Me.Conversion = 1
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_discrate") AndAlso Not dr.IsNull(aliasPrefix & "stocki_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "stocki_discrate")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") AndAlso Not dr.IsNull(aliasPrefix & "acct_id") Then
          If Not dr.IsNull("acct_id") Then
            .m_account = New Account(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_acct") AndAlso Not dr.IsNull(aliasPrefix & "stocki_acct") Then
            .m_account = New Account(CInt(dr(aliasPrefix & "stocki_acct")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unvatable") Then
          .m_unvatable = CBool(dr(aliasPrefix & "stocki_unvatable"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_tag") AndAlso Not dr.IsNull(aliasPrefix & "stocki_tag") Then
          .m_deprecalc = CDbl(dr(aliasPrefix & "stocki_tag"))
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property AssetSold() As AssetSold      Get        Return m_assetSold      End Get      Set(ByVal Value As AssetSold)        m_assetSold = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property ItemType() As Integer      Get        Return m_itemType      End Get      Set(ByVal Value As Integer)        m_itemType = Value      End Set    End Property    'Public Property Entity() As Asset    '    Get    '        Return m_entity    '    End Get    '    Set(ByVal Value As Asset)    '        m_entity = Value    '    End Set    'End Property    Public Property EntityName() As String      Get        Return m_entityName      End Get      Set(ByVal Value As String)        m_entityName = Value      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        m_unit = Value      End Set    End Property    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        m_qty = Value      End Set    End Property    Public Property UnitPrice() As Decimal      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        m_unitPrice = Value      End Set    End Property    Public Property UnitCost() As Decimal      Get        Return m_unitCost      End Get      Set(ByVal Value As Decimal)        m_unitCost = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Account() As Account      Get
        Return Me.m_account
      End Get
      Set(ByVal Value As Account)
        m_account = Value
      End Set
    End Property    Public Property DepreCalculation() As Double      Get
        Return m_deprecalc
      End Get
      Set(ByVal Value As Double)
        m_deprecalc = Value
      End Set
    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Me.Conversion * Me.Qty      End Get    End Property    Public Property Discount() As Discount      Get        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value      End Set    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = (Me.UnitPrice * Me.Qty)
        Return (Me.UnitPrice * Me.Qty) - Me.Discount.Amount
      End Get
    End Property
    Public Property UnVatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property
    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If
      Me.AssetSold.IsInitialized = False

      row("stocki_linenumber") = Me.LineNumber

      If Not Me.Entity Is Nothing Then
        row("stocki_entity") = Me.Entity.Id
        row("stocki_entityType") = Me.ItemType
        row("Code") = Me.Entity.Code
        row("stocki_itemName") = Me.Entity.Name
        row("deprecalcamt") = Me.DepreCalculation
      End If

      If Not Me.Unit Is Nothing Then
        row("stocki_unit") = Me.Unit.Id
        row("Unit") = Me.Unit.Name
      End If

      Me.Conversion = 1

      If Not Me.Account Is Nothing Then
        row("stocki_acct") = Me.Account.Id
        row("AccountCode") = Me.Account.Code
        row("Account") = Me.Account.Name
      End If


      If Me.UnitCost <> 0 Then
        row("stocki_unitcost") = Configuration.FormatToString(Me.UnitCost, DigitConfig.Cost)
      Else
        row("stocki_unitcost") = ""
      End If

      row("stocki_discrate") = Me.Discount.Rate
      If Me.Qty <> 0 Then
        row("stocki_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
      Else
        row("stocki_qty") = ""
      End If

      row("stocki_discrate") = Me.Discount.Rate
      If Me.Amount <> 0 Then
        row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      Else
        row("Amount") = ""
      End If

      row("stocki_note") = Me.Note
      If Me.UnitPrice <> 0 Then
        row("stocki_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
      Else
        row("stocki_unitprice") = ""
      End If
      If Me.StockQty <> 0 Then
        row("StockQty") = Configuration.FormatToString(Me.StockQty, DigitConfig.Qty)
      Else
        row("StockQty") = ""
      End If
      row("stocki_unvatable") = Me.UnVatable

      Me.AssetSold.IsInitialized = True
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
          Me.Account = New Account(CInt(row("stocki_acct")))
        Else
          Me.Account = New Account
        End If


        If Not row.IsNull("stocki_entityType") Then
          Me.ItemType = CInt(row("stocki_entityType"))
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
      If Not row.IsNull(("stocki_qty")) Then
        If CStr(row("stocki_qty")).Length = 0 Then
          Me.Qty = 0
        Else
          Me.Qty = CDec(row("stocki_qty"))
        End If
      End If
      If Not row.IsNull(("stocki_discrate")) Then
        Me.Discount.Rate = CStr(row("stocki_discrate"))
      End If
      If Not row.IsNull(("stocki_unitprice")) Then
        If CStr(row("stocki_unitprice")).Length = 0 Then
          Me.UnitPrice = 0
        Else
          Me.UnitPrice = CDec(row("stocki_unitprice"))
        End If
      End If
      If Not row.IsNull(("stocki_unitcost")) Then
        If CStr(row("stocki_unitcost")).Length = 0 Then
          Me.UnitCost = 0
        Else
          Me.UnitCost = CDec(row("stocki_unitcost"))
        End If
      End If
      If Not row.IsNull("stocki_unvatable") Then
        Me.UnVatable = CBool(row("stocki_unvatable"))
      End If
    End Sub
#End Region

#Region "Shared"
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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetAssetSoldItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("AssetSoldItems")
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
        Dim gri As New AssetSoldItem(tableRow, "")
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
  Public Class AssetSoldItemCollection
  Inherits CollectionBase

#Region "Members"
  Private m_AssetSold As AssetSold
#End Region

#Region "Constructors"
  Public Sub New()
  End Sub
  Public Sub New(ByVal owner As AssetSold)
    Me.m_AssetSold = owner
    If Not Me.m_AssetSold.Originated Then
      Return
    End If

    Dim sqlConString As String = Services.RecentCompanies.CurrentCompany.ConnectionString

    Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
    , CommandType.StoredProcedure _
    , "GetAssetSoldItems" _
    , New SqlParameter("@stock_id", Me.m_AssetSold.Id) _
    )

    For Each row As DataRow In ds.Tables(0).Rows
      Dim item As New AssetSoldItem(row, "")
      item.AssetSold = m_AssetSold
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
  Public Property AssetSold() As AssetSold
    Get
      Return m_AssetSold
    End Get
    Set(ByVal Value As AssetSold)
      m_AssetSold = Value
    End Set
  End Property
  Default Public Property Item(ByVal index As Integer) As AssetSoldItem
    Get
      Return CType(MyBase.List.Item(index), AssetSoldItem)
    End Get
    Set(ByVal value As AssetSoldItem)
      MyBase.List.Item(index) = value
    End Set
  End Property
  Public Property CurrentItem() As AssetSoldItem
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
      For Each Item As AssetSoldItem In Me
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
    For Each gri As AssetSoldItem In Me
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
  Public Overridable Function Add(ByVal value As AssetSoldItem) As Integer
    If Not m_AssetSold Is Nothing Then
      value.AssetSold = m_AssetSold
    End If
    Return MyBase.List.Add(value)
  End Function
  Public Sub AddRange(ByVal value As AssetSoldItemCollection)
    For i As Integer = 0 To value.Count - 1
      Me.Add(value(i))
    Next
  End Sub
  Public Sub AddRange(ByVal value As AssetSoldItem())
    For i As Integer = 0 To value.Length - 1
      Me.Add(value(i))
    Next
  End Sub
  Public Function Contains(ByVal value As AssetSoldItem) As Boolean
    Return MyBase.List.Contains(value)
  End Function
  Public Sub CopyTo(ByVal array As AssetSoldItem(), ByVal index As Integer)
    MyBase.List.CopyTo(array, index)
  End Sub
  Public Shadows Function GetEnumerator() As AssetSoldItemEnumerator
    Return New AssetSoldItemEnumerator(Me)
  End Function
  Public Function IndexOf(ByVal value As AssetSoldItem) As Integer
    Return MyBase.List.IndexOf(value)
  End Function
  Public Overridable Sub Insert(ByVal index As Integer, ByVal value As AssetSoldItem)
    If Not m_AssetSold Is Nothing Then
      value.AssetSold = m_AssetSold
    End If
    MyBase.List.Insert(index, value)
  End Sub
  Public Sub Remove(ByVal value As AssetSoldItem)
    MyBase.List.Remove(value)
  End Sub
  Public Sub Remove(ByVal value As AssetSoldItemCollection)
    For i As Integer = 0 To value.Count - 1
      Me.Remove(value(i))
    Next
  End Sub
  Public Sub Remove(ByVal index As Integer)
    MyBase.List.RemoveAt(index)
  End Sub
#End Region

  Public Class AssetSoldItemEnumerator
    Implements IEnumerator

#Region "Members"
    Private m_baseEnumerator As IEnumerator
    Private m_temp As IEnumerable
#End Region

#Region "Construtor"
    Public Sub New(ByVal mappings As AssetSoldItemCollection)
      Me.m_temp = mappings
      Me.m_baseEnumerator = Me.m_temp.GetEnumerator
    End Sub
#End Region

    Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
      Get
        Return CType(Me.m_baseEnumerator.Current, AssetSoldItem)
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

