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
 
  Public Class PurchaseCNItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_purchaseCN As PurchaseCN
    Private m_lineNumber As Integer

    Private m_refDocLine As Integer
    Private m_refDocId As Integer
    Private m_refDocCode As String

    Private m_itemType As ItemType
    Private m_entity As IHasName
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

    Private m_sequence As Integer

    Private m_wbsdColl As WBSDistributeCollection
    Private m_itemCollectionPrePareCost As StockCostItemCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_wbsdColl = New WBSDistributeCollection
      AddHandler m_wbsdColl.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      m_wbsdColl = New WBSDistributeCollection
      AddHandler m_wbsdColl.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      m_wbsdColl = New WBSDistributeCollection
      AddHandler m_wbsdColl.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Public Sub New(ByVal stockid As Integer, ByVal line As Integer)

      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetPurchaseCNItems" _
      , New SqlParameter("@stock_id", stockid) _
      , New SqlParameter("@stocki_linenumber", line) _
      )
      Me.Construct(ds.Tables(0).Rows(0), "")
      m_wbsdColl = New WBSDistributeCollection
      For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & Me.Sequence)
        Dim wbsd As New WBSDistribute(wbsRow, "")
        m_wbsdColl.Add(wbsd)
        'Me.PurchaseCN.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, False)
      Next
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_refdoc") AndAlso Not dr.IsNull(aliasPrefix & "stocki_refdoc") Then
          .m_refDocId = CInt(dr(aliasPrefix & "stocki_refdoc"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_refdocLineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_refdocLineNumber") Then
          .m_refDocLine = CInt(dr(aliasPrefix & "stocki_refdocLineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_entityType") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entityType") Then
          .m_itemType = New ItemType(CInt(dr(aliasPrefix & "stocki_entityType")))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_entity") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entity") Then
          itemId = CInt(dr(aliasPrefix & "stocki_entity"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_itemName") AndAlso Not dr.IsNull(aliasPrefix & "stocki_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "stocki_itemName"))
        Else
          .m_entityName = ""
        End If
        Select Case .m_itemType.Value
          Case 0, 28, 88, 89, 160, 162
            .m_entity = New BlankItem(.m_entityName)
          Case 42
            If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
              If Not dr.IsNull("lci_id") Then
                .m_entity = New LCIItem(dr, "")
              End If
            Else
              .m_entity = New LCIItem(itemId)
            End If
          Case 19
            If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
              If Not dr.IsNull("tool_id") Then
                .m_entity = New Tool(dr, "")
              End If
            Else
              .m_entity = New Tool(itemId)
            End If
          Case Else
        End Select

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
          End If
        End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Me.Conversion = lci.GetConversion(Me.Unit)
          Else
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

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_sequence") AndAlso Not dr.IsNull(aliasPrefix & "stocki_sequence") Then
          m_sequence = CInt(dr(aliasPrefix & "stocki_sequence"))
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property ItemCollectionPrePareCost As StockCostItemCollection
      Get
        If m_itemCollectionPrePareCost Is Nothing Then
          If Not Me.PurchaseCN Is Nothing AndAlso Not Me.PurchaseCN.FromCostCenter Is Nothing Then            m_itemCollectionPrePareCost = New StockCostItemCollection(m_entity, Me.PurchaseCN.FromCostCenter, Me.StockQty)
          End If
        End If
        Return m_itemCollectionPrePareCost
      End Get
      Set(ByVal value As StockCostItemCollection)
        m_itemCollectionPrePareCost = value
        'm_transferAmount = m_itemCollectionPrePareCost.CostAmount
      End Set
    End Property
    Public Property Sequence() As Integer
      Get
        Return m_sequence
      End Get
      Set(ByVal Value As Integer)
        m_sequence = Value
      End Set
    End Property
    Public Property PurchaseCN() As PurchaseCN
      Get
        Return m_purchaseCN
      End Get
      Set(ByVal Value As PurchaseCN)
        m_purchaseCN = Value
      End Set
    End Property

    Public Property LineNumber() As Integer
      Get
        Return m_lineNumber
      End Get
      Set(ByVal Value As Integer)
        m_lineNumber = Value
      End Set
    End Property
    Public Property RefDocLine() As Integer
      Get
        Return m_refDocLine
      End Get
      Set(ByVal Value As Integer)
        m_refDocLine = Value
      End Set
    End Property
    Public Property RefDocId() As Integer
      Get
        Return m_refDocId
      End Get
      Set(ByVal Value As Integer)
        m_refDocId = Value
      End Set
    End Property
    Public Property RefDocCode() As String
      Get
        Return m_refDocCode
      End Get
      Set(ByVal Value As String)
        m_refDocCode = Value
      End Set
    End Property
    Public Property ItemType() As ItemType
      Get
        Return m_itemType
      End Get
      Set(ByVal Value As ItemType)
        'm_itemType = Value
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If m_itemType Is Nothing Then
          m_itemType = Value
          Me.Clear()
          Return
        End If
        If Not Value Is Nothing AndAlso Value.Value = m_itemType.Value Then
          'ผ่านโลด
          Return
        End If
      End Set
    End Property
    Public Sub SetItemType(ByVal itemType As ItemType)
      m_itemType = itemType
    End Sub
    Public Property Entity() As IHasName
      Get
        Return m_entity
      End Get
      Set(ByVal Value As IHasName)
        m_entity = Value
        If Not Me.PurchaseCN Is Nothing AndAlso Not Me.PurchaseCN.FromCostCenter Is Nothing Then          Me.ItemCollectionPrePareCost = New StockCostItemCollection(m_entity, Me.PurchaseCN.FromCostCenter, Me.StockQty)
        End If
      End Set
    End Property
    Public Property EntityName() As String
      Get
        Return m_entityName
      End Get
      Set(ByVal Value As String)
        'm_entityName = Value
        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        Select Case Me.ItemType.Value
          Case 19, 42
            If Not Me.Entity.Code Is Nothing AndAlso Me.Entity.Code.Length > 0 Then
              'มี Code อยู่ ---> 
              Me.m_entityName = Value
            Else
              msgServ.ShowMessage("${res:Global.Error.ItemCodeMissing}")
            End If
          Case 0, 28, 88, 89
            Me.m_entityName = Value
            Dim gaType As GeneralAccount.DefaultGAType
            Dim ga As GeneralAccount
            Select Case Me.ItemType.Value
              Case 0
                gaType = GeneralAccount.DefaultGAType.ToolAndOther
              Case 28
                gaType = GeneralAccount.DefaultGAType.GeneralAsset
              Case 88
                gaType = GeneralAccount.DefaultGAType.SalaryWage
              Case 89
                gaType = GeneralAccount.DefaultGAType.OtherExpense
            End Select
            If gaType <> GeneralAccount.DefaultGAType.None Then
              ga = GeneralAccount.GetDefaultGA(gaType)
            End If
            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
              Me.m_account = ga.Account
              Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
            Else
              Me.m_account = New Account
            End If
          Case Else '160, 162
            Me.m_entityName = Value
        End Select
      End Set
    End Property
    Public Property Unit() As Unit
      Get
        Return m_unit
      End Get
      Set(ByVal Value As Unit)
        m_unit = Value
      End Set
    End Property
    Public Property Qty() As Decimal
      Get
        Return m_qty
      End Get
      Set(ByVal Value As Decimal)

        If m_qty > 0 AndAlso Value > 0 AndAlso m_qty <> Value Then          If Not Me.PurchaseCN Is Nothing AndAlso Not Me.PurchaseCN.FromCostCenter Is Nothing Then            Me.ItemCollectionPrePareCost.Clear()            Dim myStockQty As Decimal = Value * Me.Conversion            Me.ItemCollectionPrePareCost = New StockCostItemCollection(m_entity, Me.PurchaseCN.FromCostCenter, myStockQty)
          End If
        End If

        m_qty = Value
      End Set
    End Property
    Public Property UnitPrice() As Decimal
      Get
        Return m_unitPrice
      End Get
      Set(ByVal Value As Decimal)
        m_unitPrice = Value
      End Set
    End Property
    Public ReadOnly Property UnitCost() As Decimal
      Get
        Return Me.ItemCollectionPrePareCost.CostAmount

        'Dim tmpCost As Decimal = 0
        'Dim tmpRealGrossNoVat As Decimal = 0
        'tmpRealGrossNoVat = Me.PurchaseCN.RealGross

        'If Me.StockQty = 0 OrElse tmpRealGrossNoVat = 0 Then
        '  Return 0
        'Else
        '  tmpCost = Me.Amount 'Me.AmountWithDefaultUnit

        '  tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.PurchaseCN.Discount.Amount)

        '  If Me.PurchaseCN.TaxType.Value = 2 Then
        '    If Not Me.UnVatable Then
        '      tmpCost = tmpCost * (100 / (100 + Me.PurchaseCN.TaxRate))
        '    End If
        '  End If

        '  tmpCost = tmpCost / Me.StockQty

        '  Return tmpCost
        'End If
        'Return 0
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
    Public Property Account() As Account
      Get
        Return Me.m_account
      End Get
      Set(ByVal Value As Account)
        m_account = Value
      End Set
    End Property
    Public ReadOnly Property StockQty() As Decimal
      Get
        Return Me.Conversion * Me.Qty
      End Get
    End Property
    Public Property Discount() As Discount
      Get
        Return m_discount
      End Get
      Set(ByVal Value As Discount)
        m_discount = Value
      End Set
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = (Me.UnitPrice * Me.Qty)
        Return Configuration.Format((Me.UnitPrice * Me.Qty) - Me.Discount.Amount, DigitConfig.Price)
      End Get
    End Property
    Public ReadOnly Property AmountWithoutFormat() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = (Me.UnitPrice * Me.Qty)
        Return (Me.UnitPrice * Me.Qty) - Me.Discount.Amount
      End Get
    End Property
    Public ReadOnly Property TaxAmount() As Decimal
      Get
        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If
        Return (Me.PurchaseCN.TaxRate * Me.TaxBase) / 100
      End Get
    End Property
    Public ReadOnly Property BeforeTax() As Decimal
      Get
        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.PurchaseCN.Gross
        Dim myDiscount As Decimal = Me.PurchaseCN.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.PurchaseCN.TaxType.Value
          Case 0
            Return (Me.AmountWithoutFormat - _
            ( _
            (Me.AmountWithoutFormat / myGross) * myDiscount) _
            )
          Case 1
            Return (Me.AmountWithoutFormat - _
            ( _
            (Me.AmountWithoutFormat / myGross) * myDiscount) _
            )
          Case 2
            Return Me.AfterTax - Me.TaxAmount
        End Select
      End Get
    End Property
    Public ReadOnly Property AfterTax() As Decimal
      Get
        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.PurchaseCN.Gross
        Dim myDiscount As Decimal = Me.PurchaseCN.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.PurchaseCN.TaxType.Value
          Case 0
            Return Me.BeforeTax
          Case 1
            Return Me.BeforeTax + Me.TaxAmount
          Case 2
            Return (Me.AmountWithoutFormat - _
            ( _
            (Me.AmountWithoutFormat / myGross) * myDiscount) _
            )
        End Select
      End Get
    End Property
    Public ReadOnly Property DiscountFromParent() As Decimal
      Get
        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.PurchaseCN.Gross
        Dim myDiscount As Decimal = Me.PurchaseCN.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Return (Me.AmountWithoutFormat / myGross) * myDiscount
      End Get
    End Property
    Public ReadOnly Property TaxBase() As Decimal
      Get
        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.PurchaseCN.Gross
        Dim myDiscount As Decimal = Me.PurchaseCN.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.PurchaseCN.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1 '"แยก"
            If Not Me.UnVatable Then
              Return (Me.AmountWithoutFormat - _
              ( _
              (Me.AmountWithoutFormat / myGross) * myDiscount) _
              )
            End If
          Case 2 '"รวม"
            If Not Me.UnVatable Then
              Return Vat.GetExcludedVatAmountWithoutRound(Me.Amount, Me.PurchaseCN.TaxRate)
              'Return Vat.GetExcludedVatAmountWithoutRound(Me.AmountWithoutFormat - ((Me.AmountWithoutFormat / myGross) * myDiscount), Me.GoodsReceipt.TaxRate)
            End If
        End Select
      End Get
    End Property
    Public ReadOnly Property CostTaxBase() As Decimal
      Get
        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.PurchaseCN.Gross
        Dim myDiscount As Decimal = Me.PurchaseCN.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.PurchaseCN.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1 '"แยก"
            If Not Me.UnVatable Then
              Return (Me.Cost - _
              ( _
              (Me.Cost / myGross) * myDiscount) _
              )
            End If
          Case 2 '"รวม"
            If Not Me.UnVatable Then
              Return (Me.Cost - ((Me.Cost / myGross) * myDiscount)) * (100 / (Me.PurchaseCN.TaxRate + 100))
            End If
        End Select
      End Get
    End Property
    Public ReadOnly Property Cost() As Decimal
      Get
        Dim tmpCost As Decimal = Me.UnitCost * Me.StockQty
        If tmpCost = 0 Then
          tmpCost = Me.Amount
        End If
        Return tmpCost
      End Get
    End Property
    Public Property UnVatable() As Boolean
      Get
        Return m_unvatable
      End Get
      Set(ByVal Value As Boolean)
        m_unvatable = Value
      End Set
    End Property
    Public Property Conversion() As Decimal
      Get
        Return m_conversion
      End Get
      Set(ByVal Value As Decimal)
        m_conversion = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub CopyFromGRItem(ByVal grItem As GoodsReceiptItem)
      Me.RefDocLine = grItem.LineNumber
      Me.ItemType = grItem.ItemType
      Me.Entity = grItem.Entity
      Me.EntityName = grItem.EntityName
      Me.Unit = grItem.Unit
      Me.UnitPrice = grItem.UnitPrice
      Me.UnVatable = grItem.UnVatable
      Me.Qty = grItem.Qty
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If
      Me.PurchaseCN.IsInitialized = False

      row("stocki_refdoc") = Me.RefDocId
      row("RefDoc_code") = Me.RefDocCode
      row("stocki_refdoclinenumber") = Me.RefDocLine

      row("stocki_linenumber") = Me.LineNumber
      If Not Me.ItemType Is Nothing Then
        row("stocki_entityType") = Me.ItemType.Value
        Select Case Me.ItemType.Value
          Case 19, 42
            If Not Me.Entity Is Nothing Then
              row("stocki_entity") = Me.Entity.Id
              row("stocki_itemName") = Me.Entity.Name
              row("EntityName") = Me.Entity.Name
              row("Code") = Me.Entity.Code
              If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                If Me.Entity.Name <> Me.EntityName Then
                  row("stocki_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
                End If
              End If
            End If
            row("Button") = ""
          Case 0, 28, 88, 89
            row("Button") = "invisible"
            row("stocki_itemName") = Me.EntityName
          Case 160, 162
            row("Button") = "invisible"
            row("AccountButton") = "invisible"
            row("UnitButton") = "invisible"
            row("stocki_itemName") = Me.EntityName
        End Select
      End If

      If Not Me.Unit Is Nothing Then
        row("stocki_unit") = Me.Unit.Id
        row("Unit") = Me.Unit.Name
      End If

      Me.Conversion = 1
      If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
        If TypeOf Me.Entity Is LCIItem Then
          If Not Me.Entity Is Nothing Then
            Dim lci1 As LCIItem = LCIItem.GetLciItemById(Me.Entity.Id)
            Me.Conversion = lci1.GetConversion(Me.Unit)
          Else
            Me.Conversion = 1
          End If
        Else
          Me.Conversion = 1
        End If
      End If

      If Not Me.Account Is Nothing Then
        row("stocki_acct") = Me.Account.Id
        row("AccountCode") = Me.Account.Code
        row("Account") = Me.Account.Name
      End If

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

      Me.PurchaseCN.IsInitialized = True
    End Sub
    Public Sub SetAccountCode(ByVal theCode As String)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.ItemType Is Nothing Then
        'ไม่มี Type
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        Return
      End If
      Dim acct As New Account(theCode)
      If acct.Originated Then
        Select Case Me.ItemType.Value
          Case 160, 162 'Note
            msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveAccount}")
            Return
          Case Else
            Me.m_account = acct
            Return
        End Select
      Else
        Select Case Me.ItemType.Value
          Case 160, 162  'Note
            Me.m_account = New Account
            Return
          Case 0 'อื่นๆ
            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherIncome)
            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
              Me.m_account = ga.Account
              Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
              Return
            End If
            Me.m_account = New Account
            Return
          Case 19, 88, 89, 42 'Tool,Lab,EQ,LCI
            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOtherIncome)
            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
              Me.m_account = ga.Account
              Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
              Return
            End If
            Me.m_account = New Account
            Return
          Case Else
            Me.m_account = acct
            Return
        End Select
      End If
    End Sub
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim unit As Object = row("unit")
      Dim code As Object = row("Code")
      Dim stocki_itemName As Object = row("stocki_itemName")
      Dim stocki_qty As Object = row("stocki_qty")
      Dim stocki_unitprice As Object = row("stocki_unitprice")
      Dim stocki_entitytype As Object = row("stocki_entitytype")
      Dim accountcode As Object = row("accountcode")

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim isBlankRow As Boolean = False
      If IsDBNull(stocki_entitytype) Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        Select Case CInt(stocki_entitytype)
          Case 160, 162 'Note
            row.SetColumnError("stocki_qty", "")
            row.SetColumnError("stocki_unitprice", "")
            row.SetColumnError("stocki_itemname", "")
            row.SetColumnError("code", "")
            row.SetColumnError("accountcode", "")
          Case 0, 88, 89 'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(stocki_itemName) OrElse stocki_itemName.ToString.Length = 0 Then
              row.SetColumnError("stocki_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("stocki_itemName", "")
            End If
            If Not IsNumeric(stocki_qty) Then 'OrElse CDec(stocki_qty) <= 0 Then
              row.SetColumnError("stocki_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("stocki_qty", "")
            End If
            'If Not IsNumeric(stocki_unitprice) Then 'OrElse CDec(stocki_unitprice) <= 0 Then
            '    row.SetColumnError("stocki_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("stocki_unitprice", "")
            'End If
            If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
              row.SetColumnError("accountcode", myStringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
            Else
              row.SetColumnError("accountcode", "")
            End If
            row.SetColumnError("stocki_unitprice", "")
            row.SetColumnError("code", "")
          Case 19 'เครื่องมือ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(stocki_itemName) OrElse stocki_itemName.ToString.Length = 0 Then
              row.SetColumnError("stocki_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("stocki_itemName", "")
            End If
            If Not IsNumeric(stocki_qty) Then 'OrElse CDec(stocki_qty) <= 0 Then
              row.SetColumnError("stocki_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("stocki_qty", "")
            End If
            'If Not IsNumeric(stocki_unitprice) Then 'OrElse CDec(stocki_unitprice) <= 0 Then
            '    row.SetColumnError("stocki_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("stocki_unitprice", "")
            'End If
            If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
              row.SetColumnError("accountcode", myStringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
            Else
              row.SetColumnError("accountcode", "")
            End If
            row.SetColumnError("stocki_unitprice", "")
          Case 42 'LCI
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(stocki_itemName) OrElse stocki_itemName.ToString.Length = 0 Then
              row.SetColumnError("stocki_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("stocki_itemName", "")
            End If
            If Not IsNumeric(stocki_qty) Then 'OrElse CDec(stocki_qty) <= 0 Then
              row.SetColumnError("stocki_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("stocki_qty", "")
            End If
            'If Not IsNumeric(stocki_unitprice) Then ' OrElse CDec(stocki_unitprice) <= 0 Then
            '    row.SetColumnError("stocki_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("stocki_unitprice", "")
            'End If
            If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
              row.SetColumnError("accountcode", myStringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
            Else
              row.SetColumnError("accountcode", "")
            End If
            row.SetColumnError("stocki_unitprice", "")
          Case Else
            Return
        End Select
      End If
    End Sub
    Public Sub SetItemCode(ByVal theCode As String)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim unitPrice As Decimal = 0
      Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyGRPricing"))
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.ItemType Is Nothing Then
        'ไม่มี Type
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        Return
      End If
      If DupCode(theCode) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {Me.ItemType.Description, theCode})
        Return
      End If
      Select Case Me.ItemType.Value
        Case 160, 162 'Note
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveCode}")
          Return
        Case 0    ', 88, 89 'Blank
          msgServ.ShowMessage("${res:Global.Error.BlankItemORLaborOrEQCannotHaveCode}")
          Return
        Case 28    'F/A
          msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
          Return
        Case 19    'Tool
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            If Me.Entity.Code.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {Me.Entity.Code}) Then
                Me.Clear()
              End If
            End If
            Return
          End If
          Dim myTool As New Tool(theCode)
          If Not myTool.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {theCode})
            Return
          ElseIf myTool.Canceled Then
            msgServ.ShowMessageFormatted("${res:Global.Error.ToolIsCanceled}", New String() {theCode})
            Return
          Else
            Select Case pricing
              Case 0
                unitPrice = myTool.FairPrice
              Case 1
                unitPrice = GetAmountFromSproc("GetGRPriceForSupplier" _
                , New SqlParameter("@stock_entity", PurchaseCN.ValidIdOrDBNull(PurchaseCN.Supplier)) _
                , New SqlParameter("@stocki_entity", myTool.Id) _
                , New SqlParameter("@stocki_entitytype", myTool.EntityId) _
                , New SqlParameter("@stock_type", PurchaseCN.EntityId) _
                )
              Case 2
                unitPrice = GetAmountFromSproc("GetGRPriceForSupplier" _
                , New SqlParameter("@stock_entity", DBNull.Value) _
                , New SqlParameter("@stocki_entity", myTool.Id) _
                , New SqlParameter("@stocki_entitytype", myTool.EntityId) _
                , New SqlParameter("@stock_type", PurchaseCN.EntityId) _
                )
            End Select
            Dim myUnit As Unit = myTool.Unit
            Me.m_unit = myUnit
            Me.m_entity = myTool
            If Me.Conversion <> 0 Then
              unitPrice = unitPrice * Conversion
            End If
            Me.UnitPrice = unitPrice
            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOther)
            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
              Me.m_account = ga.Account
              Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
            Else
              Me.m_account = New Account
            End If
          End If
        Case 42, 88, 89    'LCI
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            If Me.Entity.Code.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {Me.Entity.Code}) Then
                Me.Clear()
              End If
            End If
            If Me.ItemType.Value = 42 Then
              Return
            Else
              Exit Select
            End If
          End If
          Dim lci As New LCIItem(theCode)
          If Not lci.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {theCode})
            Return
          ElseIf lci.Canceled Then
            msgServ.ShowMessageFormatted("${res:Global.Error.LCIIsCanceled}", New String() {theCode})
            Return
          Else
            Select Case pricing
              Case 0
                unitPrice = lci.FairPrice
              Case 1
                unitPrice = GetAmountFromSproc("GetGRPriceForSupplier" _
                , New SqlParameter("@stock_entity", PurchaseCN.ValidIdOrDBNull(PurchaseCN.Supplier)) _
                , New SqlParameter("@stocki_entity", lci.Id) _
                , New SqlParameter("@stocki_entitytype", lci.EntityId) _
                , New SqlParameter("@stock_type", PurchaseCN.EntityId) _
                )
              Case 2
                unitPrice = GetAmountFromSproc("GetGRPriceForSupplier" _
                , New SqlParameter("@stock_entity", DBNull.Value) _
                , New SqlParameter("@stocki_entity", lci.Id) _
                , New SqlParameter("@stocki_entitytype", lci.EntityId) _
                , New SqlParameter("@stock_type", PurchaseCN.EntityId) _
                )
            End Select
            Dim myUnit As Unit = lci.DefaultUnit
            Me.m_unit = myUnit
            Me.m_entity = lci
            If Me.Conversion <> 0 Then
              unitPrice = unitPrice * Conversion
            End If
            Me.UnitPrice = unitPrice
            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
              Me.m_account = lci.Account
              Me.m_account.Name = lci.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
            Else
              Me.m_account = New Account
            End If
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
      End Select
      Me.Qty = 1
      Dim myStockQty As Decimal = Me.m_qty * Me.Conversion
      Me.ItemCollectionPrePareCost = New StockCostItemCollection(m_entity, Me.PurchaseCN.FromCostCenter, myStockQty)
      Me.UnitPrice = Me.ItemCollectionPrePareCost.CostAmount
    End Sub
    Public Function DupCode(ByVal myCode As String) As Boolean
      If Me.PurchaseCN Is Nothing Then
        Return False
      End If
      If Me.ItemType Is Nothing Then
        Return False
      End If
      If Me.ItemType.Value = 42 Then
        'Material ใส่ Code เดียวกันได้
        Return False
      End If
      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As PurchaseCNItem In Me.PurchaseCN.ItemCollection
        If Not item Is Me Then
          If item.ItemType.Value = Me.ItemType.Value Then
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
        End If
      Next
      Return False
    End Function
    Public Sub Clear()
      Me.m_entity = New BlankItem("")
      Me.m_entityName = ""
      Me.m_qty = 0
      Me.m_unit = New Unit
      Me.m_unitPrice = 0
      Me.m_note = ""
      Me.m_discount = New Discount("")
      Me.m_unvatable = False
      Me.m_account = New Account
    End Sub
    Private Function GetAmountFromSproc(ByVal sproc As String, ByVal ParamArray filters() As SqlParameter) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                RecentCompanies.CurrentCompany.SiteConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , filters _
                )
        If ds.Tables(0).Rows(0).IsNull(0) Then
          Return 0
        End If
        Return CDec(ds.Tables(0).Rows(0)(0))
      Catch ex As Exception
      End Try
    End Function
    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If TypeOf sender Is WBSDistribute Then
        Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
        Select Case e.Name.ToLower
          Case "percent"
            If Not Me.PurchaseCN Is Nothing Then

              'Me.m_sc.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            End If
          Case "amount"
            If Not Me.PurchaseCN Is Nothing Then

              'Me.m_sc.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            End If
          Case "wbs"
            'Dim oldWBS As WBS = CType(e.OldValue, WBS)
            Dim newWBS As WBS = CType(e.Value, WBS)
            Dim theName As String = Me.EntityName
            If theName Is Nothing Then
              theName = Me.Entity.Name
            End If
            Select Case Me.ItemType.Value
              Case 289
                wbsd.BudgetAmount = newWBS.GetTotalLabFromDB 'GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
              Case 0
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
                'wbsd.BudgetQty = wbsd.BudgetQty - (newWBS.GetActualType0Qty(Me.SC, 6) - Me.SC.GetCurrentTypeQtyForWBS(newWBS, theName, 0))
              Case 19
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = 0        'ไม่มี budget ให้เครื่องมือแน่ๆ
              Case 42
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetTotalMatQtyFromDB(Me.Entity.Id)
              Case 88
                wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
                wbsd.BudgetQty = newWBS.GetTotalLabQtyFromDB(theName)
              Case 89
                wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
                wbsd.BudgetQty = newWBS.GetTotalEQQtyFromDB(theName)
            End Select
            wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.PurchaseCN.Id, Me.PurchaseCN.EntityId, Me.ItemType.Value)
            wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.PurchaseCN.Id, Me.PurchaseCN.EntityId, Me.Entity.Id, _
                                                                        Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
        End Select
      End If
    End Sub
    Public Sub UpdateWBSQty()
      For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
        'Dim bfTax As Decimal = 0
        'Dim oldVal As Decimal = wbsd.TransferAmount
        'Dim transferAmt As Decimal = Me.Amount
        'wbsd.BaseCost = bfTax
        'wbsd.TransferBaseCost = transferAmt
        Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, 42)
        If boqConversion = 0 Then
          wbsd.BaseQty = Me.Qty
        Else
          wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
        End If

        'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
      Next
    End Sub
#End Region

#Region "IWBSAllocatableItem"
    Public ReadOnly Property AllocationErrorMessage As String Implements IWBSAllocatableItem.AllocationErrorMessage
      Get
        If Me.ItemType Is Nothing Then
          Return "No Item Type"
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            Return "${res:Global.Error.NoteCannotHaveWBS}"
        End Select

        Return ""
      End Get
    End Property

    Public ReadOnly Property AllocationType As String Implements IWBSAllocatableItem.AllocationType
      Get
        Select Case Me.ItemType.Value
          Case 88, 289
            Return "lab"
          Case 89
            Return "eq"
          Case Else
            Return "mat"
        End Select
      End Get
    End Property

    Public ReadOnly Property Description As String Implements IWBSAllocatableItem.Description
      Get
        Dim indent As String = ""
        If Me.Entity.Code.Length = 0 Then
          Return indent & Trim(Me.EntityName)
        End If
        Return indent & Me.Entity.Code & " : " & Trim(Me.Entity.Name)  '  Me.EntityName
      End Get
    End Property

    Public ReadOnly Property CostAmount As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        Return Me.UnitCost * Me.StockQty
      End Get
    End Property

    Public ReadOnly Property Type As String Implements IWBSAllocatableItem.Type
      Get

      End Get
    End Property

    Public Property WBSDistributeCollection As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection
      Get
        Return m_wbsdColl
      End Get
      Set(ByVal value As WBSDistributeCollection)
        m_wbsdColl = value
      End Set
    End Property

    Public Property WBSDistributeCollection2 As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection2
      Get

      End Get
      Set(ByVal value As WBSDistributeCollection)

      End Set
    End Property
#End Region
  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class PurchaseCNItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_PurchaseCN As PurchaseCN
    Private m_currentItem As PurchaseCNItem
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As PurchaseCN)
      Me.m_PurchaseCN = owner
      If Not Me.m_PurchaseCN.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetPurchaseCNItems" _
      , New SqlParameter("@stock_id", Me.m_PurchaseCN.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New PurchaseCNItem(row, "")
        item.PurchaseCN = m_PurchaseCN
        Me.Add(item)
        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        AddHandler wbsdColl.PropertyChanged, AddressOf item.WBSChangedHandler
        item.WBSDistributeCollection = wbsdColl
        For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & item.Sequence)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          wbsdColl.Add(wbsd)
        Next

        Dim icCol As StockCostItemCollection = New StockCostItemCollection
        item.ItemCollectionPrePareCost = icCol
        For Each icRow As DataRow In ds.Tables(2).Select("stockic_stockisequence=" & row("stocki_sequence").ToString)
          Dim itmcost As New StockCostItem(icRow, "")
          icCol.Add(itmcost)
        Next
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property PurchaseCN() As PurchaseCN      Get        Return m_PurchaseCN      End Get      Set(ByVal Value As PurchaseCN)        m_PurchaseCN = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As PurchaseCNItem
      Get
        Return CType(MyBase.List.Item(index), PurchaseCNItem)
      End Get
      Set(ByVal value As PurchaseCNItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property CurrentItem() As PurchaseCNItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As PurchaseCNItem)
        m_currentItem = Value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable, ByVal tg As DataGrid)
      dt.Clear()
      Dim i As Integer = 0
      For Each gi As PurchaseCNItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        gi.CopyToDataRow(newRow)
        gi.ItemValidateRow(newRow)

        If Me.PurchaseCN.ShowCost Then
          For Each mwci As StockCostItem In gi.ItemCollectionPrePareCost
            Dim newCost As TreeRow = newRow.Childs.Add
            newCost("stocki_qty") = Configuration.FormatToString(mwci.StockQty / gi.Conversion, DigitConfig.Qty)
            newCost("stocki_unitprice") = Configuration.FormatToString(mwci.UnitCost, DigitConfig.Cost)
            'newCost("StockQty") = Configuration.FormatToString(mwci.StockQty, DigitConfig.Qty)
            'newCost("stocki_transferUnitPrice") = Configuration.FormatToString(mwci.UnitCost, DigitConfig.UnitPrice)
            'newCost("stocki_transferamt") = Configuration.FormatToString(mwci.UnitCost * mwci.StockQty, DigitConfig.Price)
            If Not mwci.UnitDefault Is Nothing Then
              newCost("unit") = mwci.UnitDefault.Name
            End If
            newCost.FixLevel = -1
            newCost("Button") = "invisible"
            newCost("UnitButton") = "invisible"
            newCost("AccountButton") = "invisible"
          Next
        End If

        newRow.Tag = gi
      Next
      dt.AcceptChanges()

      Do Until dt.Rows.Count > tg.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        dt.Childs.Add()
      Loop

      Try
        If (Not dt.Rows(dt.Rows.Count - 1).IsNull("stocki_enitytype")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
          '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          dt.Childs.Add()
        End If
      Catch ex As Exception

      End Try

      dt.AcceptChanges()

    End Sub
    Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
      For i As Integer = 0 To items.Count - 1
        Dim itemEntityLevel As Integer
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As IHasName
        Dim newType As Integer = -1
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.lciitem", "longkong.pojjaman.businesslogic.lciforlist"
            newItem = New LCIItem(item.Id)
            If targetType > -1 Then
              newType = targetType
            Else
              newType = 42
            End If
            itemEntityLevel = CType(newItem, LCIItem).Level
          Case "longkong.pojjaman.businesslogic.tool"
            newItem = New Tool(item.Id)
            newType = 19
            itemEntityLevel = 5
        End Select
        If itemEntityLevel = 5 Then
          Dim doc As New PurchaseCNItem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.ItemType.Value = newType
            Me.CurrentItem = Nothing
          Else
            Me.Add(doc)
            doc.ItemType = New ItemType(newType)
          End If
          'doc.Entity = newItem   'เดิม Set จากการกดปุ่มเป็นแบบนี้ทำให้รหัสบัญชีไม่ขึ้น จึงไปใช้วิธีเดียวกับการกรอกใน textbox
          doc.SetItemCode(newItem.Code)
        End If
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As PurchaseCNItem) As Integer
      If Not m_PurchaseCN Is Nothing Then
        value.PurchaseCN = m_PurchaseCN
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As PurchaseCNItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As PurchaseCNItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As PurchaseCNItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As PurchaseCNItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As PurchaseCNItemEnumerator
      Return New PurchaseCNItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As PurchaseCNItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As PurchaseCNItem)
      If Not m_PurchaseCN Is Nothing Then
        value.PurchaseCN = m_PurchaseCN
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As PurchaseCNItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As PurchaseCNItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class PurchaseCNItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As PurchaseCNItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, PurchaseCNItem)
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

End Namespace

