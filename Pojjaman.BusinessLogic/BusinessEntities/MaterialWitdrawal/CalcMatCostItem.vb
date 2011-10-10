Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic

  Public Class CalcMatItemType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)

      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "calcmat_itemtype"   'Return "CalcMatCost_status"
      End Get
    End Property
#End Region

  End Class

  Public Enum CalcMatItemTypeEnum
    CostItem = 0
    WIPBalance = 1
    MatBF = 2
    MatBuy = 3
    MatMoveIn = 4
    MatMoveOut = 5
    MatBalance = 6
    WIPBF = 7
    WIPMoveOut = 8
    BuyOth = 9
    WIPCannotCost = 10
    MatSum = 20
    WIPSum = 30
  End Enum
  Public Class SimpleHasName
    Implements IHasName
    Private m_id As Integer
    Private m_code As String
    Private m_name As String

    Sub New()

    End Sub
    Public Property Name As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal value As String)
        m_name = value
      End Set
    End Property

    Public Property Code As String Implements IIdentifiable.Code
      Get
        Return m_code
      End Get
      Set(ByVal value As String)
        m_code = value
      End Set
    End Property

    Public Property Id As Integer Implements IIdentifiable.Id
      Get
        Return m_id
      End Get
      Set(ByVal value As Integer)
        m_id = value
      End Set
    End Property
  End Class
  Public Class CalcMatCostItem

#Region "Members"
    Private m_CalcCost As CalculateCost
    Private m_lineNumber As Integer

    Private m_entity As IHasName
    Private m_entityType As Integer
    Private m_itemdescription As String
    Private m_unitcost As Decimal
    Private m_note As String
    Private m_stockQty As Decimal

    Private m_refdocid As Integer
    Private m_refdoctype As Integer
    Private m_reftypedesc As String

    Private m_ga As GeneralAccount

    Private m_sequence As Long
    Private m_stockicsequence As Long
    Private m_stockisequence As Long

    Private m_calctype As CalcMatItemTypeEnum
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
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Dim drh As New DataRowHelper(dr)
      With Me

        m_entityType = drh.GetValue(Of Integer)("itementityType")

        Dim itemId As Integer = drh.GetValue(Of Integer)("itemEntity")


        If m_entityType = 42 Then
          .m_entity = LCIItem.GetLciitem(itemId)
        Else
          .m_entity = New SimpleHasName
          .m_entity.Id = itemId
          .m_entity.Name = drh.GetValue(Of String)("itemName")
        End If

        .m_refdocid = drh.GetValue(Of Integer)("RefId")
        .m_refdoctype = drh.GetValue(Of Integer)("RefType")
        .m_reftypedesc = drh.GetValue(Of String)("RefTypeDesc")

        .m_unitcost = drh.GetValue(Of Decimal)("itemUnitCost")
        .StockQty = drh.GetValue(Of Decimal)("itemStockQty")

        .m_note = drh.GetValue(Of String)("itemNote")
        .m_ga = New GeneralAccount(drh.GetValue(Of Integer)("itemGA"))

        .m_stockisequence = drh.GetValue(Of Long)("stockisequence")
        .m_stockicsequence = drh.GetValue(Of Long)("stockicsequence")
        .Sort = drh.GetValue(Of String)("sort")
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property Sequence As Long
      Get
        Return m_sequence
      End Get
      Set(ByVal value As Long)
        m_sequence = value
      End Set
    End Property
    Public Property stockicostSequence As Long
      Get
        Return m_stockicsequence
      End Get
      Set(ByVal value As Long)
        m_stockicsequence = value
      End Set
    End Property
    Public Property StockiSequence As Long
      Get
        Return m_stockisequence
      End Get
      Set(ByVal value As Long)
        m_stockisequence = value
      End Set
    End Property
    Public Property CalcMatCost() As CalculateCost      Get        Return m_CalcCost      End Get      Set(ByVal Value As CalculateCost)        m_CalcCost = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value      End Set    End Property    Public Property EntityType() As Integer      Get        Return m_entityType      End Get      Set(ByVal Value As Integer)        m_entityType = Value      End Set    End Property    Public Property UnitCost() As Decimal      Get        Return m_unitcost      End Get      Set(ByVal Value As Decimal)        m_unitcost = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property StockQty() As Decimal      Get        Return m_stockQty      End Get      Set(ByVal value As Decimal)
        m_stockQty = value
      End Set    End Property    Public ReadOnly Property Amount() As Decimal
      Get
        Return (Me.UnitCost * Me.StockQty)
      End Get
    End Property
    Public Property CalcMatType As CalcMatItemTypeEnum
      Get
        Return m_calctype
      End Get
      Set(ByVal value As CalcMatItemTypeEnum)
        m_calctype = value
      End Set
    End Property
    Public Property Sort As String
    Public Property RefDoc As Integer
      Get
        Return m_refdocid
      End Get
      Set(ByVal value As Integer)
        m_refdocid = value
      End Set
    End Property
    Public Property RefType As Integer
      Get
        Return m_refdoctype
      End Get
      Set(ByVal value As Integer)
        m_refdoctype = value
      End Set
    End Property
    Public Property RefTypeDesc As String
      Get
        Return m_reftypedesc
      End Get
      Set(ByVal value As String)
        m_reftypedesc = value
      End Set
    End Property
    Public ReadOnly Property CalcType As CalcMatItemTypeEnum
      Get
        Return m_calctype
      End Get
    End Property
    Public ReadOnly Property ga As GeneralAccount
      Get
        Return m_ga
      End Get
    End Property
#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.CalcMatCost.IsInitialized = False

      row("stocki_linenumber") = Me.LineNumber
      If Not Me.Entity Is Nothing Then
        row("stocki_entity") = Me.Entity.Id
        row("Code") = Me.Entity.Code
        row("stocki_itemName") = Me.Entity.Name
      End If






      If Me.UnitCost <> 0 Then
        row("stocki_unitprice") = Configuration.FormatToString(Me.StockQty, DigitConfig.Qty)
      Else
        row("stocki_unitprice") = ""
      End If

      If Me.Amount <> 0 Then
        row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      Else
        row("Amount") = ""
      End If

      row("stocki_note") = Me.Note
      If Me.UnitCost <> 0 Then
        row("stocki_unitprice") = Configuration.FormatToString(Me.UnitCost, DigitConfig.Price)
      Else
        row("stocki_unitprice") = ""
      End If
      If Me.StockQty <> 0 Then
        row("StockQty") = Configuration.FormatToString(Me.StockQty, DigitConfig.Qty)
      Else
        row("StockQty") = ""
      End If

      row("stocki_sequence") = Me.Sequence

      Me.CalcMatCost.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If

      Try
        If Not row.IsNull(("stocki_linenumber")) Then
          Me.LineNumber = CInt(row("stocki_linenumber"))
        End If





        If Not row.IsNull(("stocki_note")) Then
          Me.Note = CStr(row("stocki_note"))
        End If

        If Not row.IsNull(("stocki_sequence")) Then
          Me.Sequence = CLng(row("stocki_sequence"))
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
          Me.StockQty = 0
        Else
          Me.StockQty = CDec(row("stocki_qty"))
        End If
      End If
      If Not row.IsNull(("stocki_unitprice")) Then
        If CStr(row("stocki_unitprice")).Length = 0 Then
          Me.UnitCost = 0
        Else
          Me.UnitCost = CDec(row("stocki_unitprice"))
        End If
      End If
    End Sub
    ''' <summary>
    ''' สามารถเอามาลบกันได้สร้าง wip
    ''' </summary>
    ''' <param name="ci"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CanDecrese(ByVal ci As CalcMatCostItem) As Boolean
      If Me.m_entityType = ci.m_entityType AndAlso Me.m_entity.Id = Me.m_entity.Id AndAlso Me.m_stockicsequence = Me.m_stockicsequence Then
        Return True
      End If
      Return False
    End Function
    Public Function checkQtyCost(ByVal tmpcost As Decimal, ByVal maxCost As Decimal) As Boolean
      If Me.EntityType <> 42 Then
        Return False
      End If
      Dim dif As Decimal = CLng(maxCost - tmpcost) \ CLng(UnitCost) 'ขอจำนวนเต็มเท่านั้น
      If dif > 0 Then
        Return True
      End If
      Return False
    End Function
    Public Function Devideitem(ByVal costitems As CalcMatCostItemCollection, ByVal wipbalitems As CalcMatCostItemCollection, ByVal tmpcost As Decimal, ByVal maxCost As Decimal) As Decimal
      If Me.EntityType <> 42 Then
        Return 0
      End If
      Dim dif As Decimal = CLng(maxCost - tmpcost) \ CLng(UnitCost)
      Dim ci As New CalcMatCostItem
      Dim wi As New CalcMatCostItem
      If dif > 0 Then
        ci.cloneQty(Me, dif)
        wi.cloneQty(Me, StockQty - dif)
        costitems.Add(ci)
        wipbalitems.Add(wi)
      End If
      Return ci.Amount
    End Function
#End Region

    Private Sub cloneQty(ByVal cmci As CalcMatCostItem, ByVal qty As Decimal)
      With Me
        m_entityType = cmci.EntityType

        .m_entity = cmci.Entity


        .m_refdocid = cmci.RefDoc
        .m_refdoctype = cmci.RefType
        .m_reftypedesc = cmci.RefTypeDesc


        .m_unitcost = cmci.UnitCost

        .StockQty = qty

        .m_note = cmci.Note
        .m_ga = cmci.m_ga

        .m_stockisequence = cmci.StockiSequence
        .m_stockicsequence = cmci.stockicostSequence
        .Sort = cmci.Sort
      End With
    End Sub

    

  End Class

  Public Class CalcMatCostItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_calccost As CalculateCost
    Private m_calcitemtype As CalcMatItemTypeEnum

    Private CalcDataset As DataSet
    Private KeyIndex As Dictionary(Of String, Integer)

#End Region



#Region "Constructors"
    Public Sub New(ByVal calcitemtype As CalcMatItemTypeEnum)
      m_calcitemtype = calcitemtype
      CalcDataset = New DataSet
      KeyIndex = New Dictionary(Of String, Integer)
    End Sub
    Public Sub New(ByVal owner As CalculateCost, ByVal calcitemtype As CalcMatItemTypeEnum, ByVal calc As Boolean)
      Me.m_calccost = owner
      m_calcitemtype = calcitemtype
      CalcDataset = New DataSet
      KeyIndex = New Dictionary(Of String, Integer)
      If Not Me.m_calccost.Originated OrElse calc Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetCalcMatCostItems" _
      , New SqlParameter("@stock_id", Me.m_calccost.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New CalcMatCostItem(row, "")
        item.CalcMatCost = m_calccost
        Me.Add(item)



      Next
    End Sub
#End Region

#Region "Properties"
    Public Property CalcCost() As CalculateCost      Get        Return m_calccost      End Get      Set(ByVal Value As CalculateCost)        m_calccost = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As CalcMatCostItem
      Get
        Return CType(MyBase.List.Item(index), CalcMatCostItem)
      End Get
      Set(ByVal value As CalcMatCostItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Dim m_amount As Nullable(Of Decimal)
    Public ReadOnly Property Amount(Optional ByVal force As Boolean = False) As Decimal
      Get
        If Not m_amount.HasValue OrElse force Then
          m_amount = 0
          For Each ci As CalcMatCostItem In Me
            m_amount += ci.Amount
          Next
        End If
        Return m_amount.Value
      End Get
    End Property
#End Region

#Region "Class Methods"

    Public Sub CalculateMatSumItems()
      If Me.m_calcitemtype <> CalcMatItemTypeEnum.MatSum OrElse Me.m_calccost.InvMethod.Value <> 1 Then
        Return
      End If
      'สร้าง Item ที่สรุป bf + buy + movein - moveout - bal
      'ถ้าไม่เคยเบิกไปใช้ทำไงได้ อยากปิดโง่ๆ จะทำไง
    End Sub
    Public Sub GetCalculate()
      If Me.m_calcitemtype = CalcMatItemTypeEnum.WIPSum Then
        Return
      End If
      m_amount = Nothing
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      CalcDataset = New DataSet
      Me.Clear()
      Select Case m_calcitemtype
        Case CalcMatItemTypeEnum.MatBF
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcMatBF" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )
        Case CalcMatItemTypeEnum.MatBuy
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcMatBuy" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )
        Case CalcMatItemTypeEnum.MatMoveIn
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcMatMoveIn" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )
        Case CalcMatItemTypeEnum.MatMoveOut
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcMatMoveOut" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )
        Case CalcMatItemTypeEnum.MatBalance
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcMatBal" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )
        Case CalcMatItemTypeEnum.MatSum
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcMatWIPAble" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )
        Case CalcMatItemTypeEnum.WIPBF
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcWIPBF" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )
        Case CalcMatItemTypeEnum.WIPMoveOut
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcWIPOut" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )

        Case CalcMatItemTypeEnum.BuyOth
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcNonMatBuy" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )
        Case CalcMatItemTypeEnum.WIPCannotCost
          CalcDataset = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.StoredProcedure _
                    , "GetNewCalcWIPCannotCost" _
                    , New SqlParameter("@cmc_id", Me.m_calccost.Id) _
                    , New SqlParameter("@startcalcDate", Me.m_calccost.StartCalcDate) _
                    , New SqlParameter("@endcalcDate", Me.m_calccost.EndCalcDate) _
                    , New SqlParameter("@cc", Me.m_calccost.CostCenter.Id) _
                    , New SqlParameter("@calcitemtype", Me.m_calcitemtype) _
                    )
      End Select



      For Each row As DataRow In CalcDataset.Tables(0).Rows
        Dim item As New CalcMatCostItem(row, "")
        item.CalcMatCost = m_calccost
        Me.Add(item)

      Next
    End Sub
    Public Sub SetItems(ByVal items As BasketItemCollection)
      Dim cumWithdrawn As New Hashtable
      For i As Integer = 0 To items.Count - 1
        If TypeOf items(i) Is StockBasketItem Then
          Dim item As StockBasketItem = CType(items(i), StockBasketItem)
          'If Not TypeOf item.Tag Is BoqItem Then
          Dim pri As PRItem = CType(item.Tag, PRItem)
          If pri.ItemType.Value = 42 Then
            Dim p As New PR
            p.Id = item.Id
            p.Code = item.StockCode
            pri.Pr = p
            Dim mwi As New CalcMatCostItem
            Me.Add(mwi)
            If Not (cumWithdrawn.Contains(pri.Entity.Id)) Then
              cumWithdrawn(pri.Entity.Id) = 0
            End If
            'mwi.CopyFromPRItem(pri, CType(cumWithdrawn(pri.Entity.Id), Decimal))

            cumWithdrawn(pri.Entity.Id) = CType(cumWithdrawn(pri.Entity.Id), Decimal) + (pri.Qty * pri.Conversion)

          End If
          'End If
        End If
      Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable, ByVal tg As DataGrid)
      dt.Clear()
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim noPRText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.BlankPRText}")
      Dim prRowHash As New Hashtable
      Dim parRow As TreeRow

      'Dim isgroupping As Boolean = Me.CalcMatCost.Grouping
      'For Each mwi As CalcMatCostItem In Me
      '  parRow = Nothing
      '  If Not mwi.Pritem Is Nothing _
      '  AndAlso Not mwi.Pritem.Pr Is Nothing AndAlso mwi.Pritem.Pr.Originated Then
      '    If Not prRowHash.Contains(mwi.Pritem.Pr.Id) Then
      '      parRow = dt.Childs.Add
      '      parRow("PRItemCode") = mwi.Pritem.Pr.Code
      '      parRow("Button") = "invisible"
      '      parRow("UnitButton") = "invisible"
      '      parRow.State = RowExpandState.Expanded
      '      prRowHash(mwi.Pritem.Pr.Id) = parRow
      '    Else
      '      parRow = CType(prRowHash(mwi.Pritem.Pr.Id), TreeRow)
      '    End If
      '  Else
      '    'แบบไม่มี PR
      '    If Not prRowHash.Contains(0) Then
      '      parRow = dt.Childs.Add
      '      parRow("PRItemCode") = noPRText
      '      parRow("Button") = "invisible"
      '      parRow("UnitButton") = "invisible"
      '      parRow.State = RowExpandState.Expanded
      '      prRowHash(0) = parRow
      '    Else
      '      parRow = CType(prRowHash(0), TreeRow)
      '    End If
      '  End If

      '  Dim newRow As TreeRow = parRow.Childs.Add()
      '  mwi.CopyToDataRow(newRow)
      '  mwi.ItemValidateRow(newRow)
      '  If Not Me.CalcMatCost.Grouping Then
      '    For Each mwci As StockCostItem In mwi.ItemCollectionPrePareCost
      '      Dim newCost As TreeRow = newRow.Childs.Add
      '      newCost("stocki_qty") = Configuration.FormatToString(mwci.StockQty / mwi.Conversion, DigitConfig.Qty)
      '      newCost("stocki_unitcost") = Configuration.FormatToString(mwci.UnitCost, DigitConfig.Cost)
      '      newCost("StockQty") = Configuration.FormatToString(mwci.StockQty, DigitConfig.Qty)
      '      newCost("stocki_transferUnitPrice") = Configuration.FormatToString(mwci.UnitCost, DigitConfig.UnitPrice)
      '      newCost("stocki_transferamt") = Configuration.FormatToString(mwci.UnitCost * mwci.StockQty, DigitConfig.Price)
      '      If Not mwci.UnitDefault Is Nothing Then
      '        newCost("defaultunit") = mwci.UnitDefault.Name
      '      End If
      '      newCost.FixLevel = -1
      '      newCost("Button") = "invisible"
      '      newCost("UnitButton") = "invisible"
      '    Next
      '  End If

      '  newRow.Tag = mwi
      'Next
      'If Not prRowHash.Contains(0) Then
      '  parRow = dt.Childs.Add
      '  parRow("PRItemCode") = noPRText
      '  parRow("Button") = "invisible"
      '  parRow("UnitButton") = "invisible"
      '  parRow.State = RowExpandState.Expanded
      '  prRowHash(0) = parRow
      'End If



      dt.AcceptChanges()

      Do Until dt.Rows.Count > tg.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        dt.Childs.Add()
      Loop

      Try
        If (Not dt.Rows(dt.Rows.Count - 1).IsNull("PRItemCode")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
          '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          dt.Childs.Add()
        End If
      Catch ex As Exception

      End Try

      dt.AcceptChanges()
    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As CalcMatCostItem) As Integer
      If Not m_calccost Is Nothing Then
        value.CalcMatCost = m_calccost
        value.CalcMatType = m_calcitemtype
      End If
      Dim idx As Integer = MyBase.List.Add(value)
      If value.CalcMatType = CalcMatItemTypeEnum.WIPSum Then
        Dim key As String = value.stockicostSequence.ToString & ":" & value.StockiSequence.ToString & ":" & value.Entity.Id.ToString & ":" & value.EntityType.ToString
        KeyIndex.Add(key, idx)
      End If
      Return idx
    End Function
    Public Sub AddRange(ByVal value As CalcMatCostItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As CalcMatCostItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As CalcMatCostItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As CalcMatCostItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As CalcMatCostItemEnumerator
      Return New CalcMatCostItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As CalcMatCostItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As CalcMatCostItem)
      If Not m_calccost Is Nothing Then
        value.CalcMatCost = m_calccost
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As CalcMatCostItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As CalcMatCostItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub DecreaseRange(ByVal Values As CalcMatCostItemCollection)
      For Each vi As CalcMatCostItem In Values
        Me.Decrease(vi)
      Next
    End Sub
    Public Sub Decrease(ByVal value As CalcMatCostItem)
      Dim ValQty As Decimal = value.StockQty
      For Each cci As CalcMatCostItem In Me
        If cci.CanDecrese(value) Then
          If cci.StockQty <= ValQty Then
            ValQty = ValQty - cci.StockQty
            Me.Remove(cci)
          Else
            cci.StockQty = cci.StockQty - ValQty
          End If
          If ValQty <= 0 Then
            Return
          End If
        End If
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
    Protected Overrides Sub OnClear()
      MyBase.OnClear()
      KeyIndex = New Dictionary(Of String, Integer)
      m_amount = Nothing
    End Sub
#End Region

    Public Class CalcMatCostItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As CalcMatCostItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, CalcMatCostItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class

    Public Sub SortCollection()
      Dim mySL As New SortedList(Of String, CalcMatCostItem)

      For Each cmi As CalcMatCostItem In Me
        mySL.Add(cmi.Sort, cmi)
      Next

      Me.Clear()
      For Each kv As KeyValuePair(Of String, CalcMatCostItem) In mySL
        Me.Add(kv.Value)
      Next

    End Sub



  End Class
End Namespace
