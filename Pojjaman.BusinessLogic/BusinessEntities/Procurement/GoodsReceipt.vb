Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class GoodsReceiptStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "goodsreceipt_status"
      End Get
    End Property
#End Region

  End Class
  Public Class GoodsReceiptToAcctType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "GoodsReceiptToAcctType"
      End Get
    End Property
#End Region

  End Class
  Public Class GoodsReceipt
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IVatable, IWitholdingTaxable, IBillAcceptable, IPrintableEntity, IApprovAble _
    , ICancelable, IHasIBillablePerson, IHasToCostCenter, IAdvancePayItemAble, ICanDelayWHT, ICheckPeriod _
   , IUnlockAble, IGLCheckingBeforeRefresh


#Region "Members"
    Private m_supplier As Supplier
    Private m_deliveryPerson As String

    Private m_docDate As Date

    Private m_toCostCenter As CostCenter
    Private m_toCostCenterPerson As Employee

    Private m_deliveryDocCode As String
    Private m_deliveryDocDate As Date

    Private m_po As Po
    Private m_prcode As String

    Private m_vat As Vat
    Private m_whtcol As WitholdingTaxCollection
    Private m_payment As Payment
    Private m_je As JournalEntry

    Private m_note As String
    Private m_creditPeriod As Long

    Private m_discount As Discount
    Private m_taxRate As Decimal
    Private m_taxType As TaxType

    Private m_approvePerson As User
    Private m_approveDate As DateTime
    Private m_status As GoodsReceiptStatus

    Private Shared m_columns As ColumnCollection

    Private m_toAcctType As GoodsReceiptToAcctType

    Private m_retention As Decimal

    Private m_advancePayItemColl As AdvancePayItemCollection

    Private m_realTaxBase As Decimal
    Private m_realGross As Decimal
    Private m_realTaxAmount As Decimal

    Private m_itemCollection As GoodsReceiptItemCollection

    Private m_asset As Asset
    Private m_Unlock As Boolean = False

    Public MatActualHash As Hashtable
    Public LabActualHash As Hashtable
    Public EQActualHash As Hashtable
#End Region


#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
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
        .m_po = New Po
        .m_supplier = New Supplier
        .m_creditPeriod = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_discount = New Discount("")
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        .m_docDate = Now.Date
        .m_approvePerson = New User
        .m_approveDate = Date.MinValue
        .m_status = New GoodsReceiptStatus(-1)
        .m_toCostCenter = New CostCenter
        .m_toCostCenterPerson = New Employee
        .m_toAcctType = New GoodsReceiptToAcctType(3) '--- Default = เข้า store

        '----------------------------Tab Entities-----------------------------------------
        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)

        .m_advancePayItemColl = New AdvancePayItemCollection(Me)

        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 1

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate
        '.m_je.AccountBook = New AccountBook

        .m_payment = New Payment(Me)
        .m_payment.DocDate = .m_je.DocDate
        '----------------------------End Tab Entities-----------------------------------------
        .m_asset = New Asset
        .AutoCodeFormat = New AutoCodeFormat(Me)

      End With
      MatActualHash = New Hashtable
      LabActualHash = New Hashtable
      EQActualHash = New Hashtable
      m_itemCollection = New GoodsReceiptItemCollection(Me)
      m_itemCollection.RefreshBudget()
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("supplier_id") Then
          If Not dr.IsNull("supplier_id") Then
            .m_supplier = New Supplier(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "stock_entity") Then
            .m_supplier = New Supplier(CInt(dr(aliasPrefix & "stock_entity")))
          End If
        End If
        If Not dr.IsNull(aliasPrefix & "stock_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "stock_discrate")))
        End If
        If dr.Table.Columns.Contains("po_id") Then
          If Not dr.IsNull("po_id") Then
            .m_po = New Po
            .m_po.Id = CInt(dr(aliasPrefix & "po_id"))
            .m_po.Code = CStr(dr(aliasPrefix & "po_code"))
            .m_po.DocDate = CDate(dr(aliasPrefix & "po_docdate"))
            .m_po.CreditPeriod = CInt(dr(aliasPrefix & "po_creditperiod"))

            If dr.Table.Columns.Contains("prcode") AndAlso Not dr.IsNull("prcode") Then
              .m_prcode = CStr(dr(aliasPrefix & "prcode"))
            End If
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "stock_refdoc") Then
            .m_po = New Po
            .m_po.Id = CInt(dr(aliasPrefix & "stock_refdoc"))
          End If
        End If

        If dr.Table.Columns.Contains("stock_entityPerson") AndAlso Not dr.IsNull(aliasPrefix & "stock_entityPerson") Then
          .m_deliveryPerson = CStr(dr(aliasPrefix & "stock_entityPerson"))
        End If

        If dr.Table.Columns.Contains("stock_otherdoccode") AndAlso Not dr.IsNull(aliasPrefix & "stock_otherdoccode") Then
          .m_deliveryDocCode = CStr(dr(aliasPrefix & "stock_otherdoccode"))
        End If
        If dr.Table.Columns.Contains("stock_otherdocdate") AndAlso Not dr.IsNull(aliasPrefix & "stock_otherdocdate") Then
          .m_deliveryDocDate = CDate(dr(aliasPrefix & "stock_otherdocdate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stock_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "stock_creditperiod"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "tocostcenterperson.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "tocostcenterperson.employee_id") Then
            .m_toCostCenterPerson = New Employee(dr, "tocostcenterperson.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_toccperson") AndAlso Not dr.IsNull(aliasPrefix & "stock_toccperson") Then
            .m_toCostCenterPerson = New Employee(CInt(dr(aliasPrefix & "stock_toccperson")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "cc_id") Then
          If Not dr.IsNull(aliasPrefix & "cc_id") Then
            .m_toCostCenter = New CostCenter(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains("stock_tocc") AndAlso Not dr.IsNull(aliasPrefix & "stock_tocc") Then
            .m_toCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_tocc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stock_tag") AndAlso Not dr.IsNull(aliasPrefix & "stock_tag") Then
          Me.m_toAcctType.Value = CInt(dr(aliasPrefix & "stock_tag"))
        End If

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .m_note = CStr(dr(aliasPrefix & "stock_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "stock_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "stock_taxtype")))
        End If

        ' ApprovePerson
        If dr.Table.Columns.Contains("approvePerson.user_id") Then
          If Not dr.IsNull("approvePerson.user_id") Then
            .m_approvePerson = New User(dr, "approvePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "stock_approvePerson") Then
            .m_approvePerson = New User(CInt(dr(aliasPrefix & "stock_approvePerson")))
          End If
        End If
        ' Approved Date
        If dr.Table.Columns.Contains("stock_approveDate") Then
          If Not dr.IsNull(aliasPrefix & "stock_approveDate") Then
            .m_approveDate = CDate(dr(aliasPrefix & "stock_approveDate"))
          End If
        End If

        ' Tax Rate
        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxrate") Then
          If Not dr.IsNull(aliasPrefix & "stock_taxrate") Then
            .m_taxRate = CDec(dr(aliasPrefix & "stock_taxrate"))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stock_status") AndAlso Not dr.IsNull(aliasPrefix & "stock_status") Then
          .m_status = New GoodsReceiptStatus(CInt(dr(aliasPrefix & "stock_status")))
        End If

        ' Retention Deducted
        If dr.Table.Columns.Contains(aliasPrefix & "stock_retention") AndAlso Not dr.IsNull(aliasPrefix & "stock_retention") Then
          .m_retention = CDec(dr(aliasPrefix & "stock_retention"))
        End If

        ' GROSS!!!
        If dr.Table.Columns.Contains(aliasPrefix & "stock_gross") AndAlso Not dr.IsNull(aliasPrefix & "stock_gross") Then
          .m_gross = CDec(dr(aliasPrefix & "stock_gross"))
        End If

        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "stock_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "stock_taxbase"))
        End If

        ' Gross
        If dr.Table.Columns.Contains(aliasPrefix & "stock_gross") _
        AndAlso Not dr.IsNull(aliasPrefix & "stock_gross") Then
          .m_realGross = CDec(dr(aliasPrefix & "stock_gross"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "stock_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "stock_taxamt"))
        End If
        '--------------------END REAL-------------------------

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 1

        '.m_wht = New WitholdingTax(Me)
        '.m_wht.Direction.Value = 1

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)

        .m_payment = New Payment(Me)

        .m_je = New JournalEntry(Me)

        '.m_advancePayItemColl = New AdvancePayItemCollection(Me)
        .m_advancePayItemColl = New AdvancePayItemCollection(Me.Id, Me.EntityId)

        If dr.Table.Columns.Contains("stock_asset") AndAlso Not dr.IsNull(aliasPrefix & "stock_asset") Then
          .m_asset = New Asset(CInt(dr(aliasPrefix & "stock_asset")))
        End If
      End With
      MatActualHash = New Hashtable
      LabActualHash = New Hashtable
      EQActualHash = New Hashtable
      m_itemCollection = New GoodsReceiptItemCollection(Me)
      m_itemCollection.RefreshBudget()

      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property DocType As String = ""
    '--------------------REAL-------------------------
    Public Property RealGross() As Decimal
      Get
        'HACK
        If m_realGross = 0 AndAlso m_gross <> 0 Then
          m_realGross = m_gross
        End If
        Return m_realGross
      End Get
      Set(ByVal Value As Decimal)
        If m_realGross <> Value Then
          OnGlChanged()
        End If
        m_realGross = Value
      End Set
    End Property
    Public Property RealTaxAmount() As Decimal
      Get
        Return m_realTaxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxAmount = Value
        OnGlChanged()
      End Set
    End Property
    Public Property RealTaxBase() As Decimal
      Get
        Return m_realTaxBase
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxBase = Value
      End Set
    End Property
    '--------------------END REAL-------------------------

    Public Property Asset() As Asset
      Get
        Return Me.m_asset
      End Get
      Set(ByVal Value As Asset)
        m_asset = Value
        ChangeEQ()
      End Set
    End Property
    Private Sub ChangeEQ()
      If Not Me.m_asset Is Nothing AndAlso Me.m_asset.Originated Then
        Me.ToCostCenter = m_asset.Costcenter
      Else
        Me.ToCostCenter = New CostCenter
      End If
    End Sub
    Public Property ItemCollection() As GoodsReceiptItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As GoodsReceiptItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property Supplier() As Supplier Implements IAdvancePayItemAble.Supplier
      Get
        Return m_supplier
      End Get
      Set(ByVal Value As Supplier)
        Dim oldPerson As IBillablePerson = m_supplier
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _
          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then
          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If
        m_supplier = Value
        If Me.m_po Is Nothing Then
          Me.m_creditPeriod = Me.m_supplier.CreditPeriod
          Return
        End If
        If Value.Id <> Me.m_po.Supplier.Id Then
          Me.m_creditPeriod = Me.m_supplier.CreditPeriod
          Me.Po = New PO
        End If
      End Set
    End Property
    Public Property DeliveryPerson() As String
      Get
        Return m_deliveryPerson
      End Get
      Set(ByVal Value As String)
        m_deliveryPerson = Value
      End Set
    End Property
    Public Property DocDate() As Date Implements IVatable.Date, IWitholdingTaxable.Date, IPayable.Date, IGLAble.Date, IAdvancePayItemAble.DocDate, ICheckPeriod.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        Me.m_je.DocDate = Value
        Me.Vat.SubmitalDate = Value
      End Set
    End Property
    Public Property ToCostCenter() As CostCenter
      Get
        Return m_toCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        m_toCostCenter = Value
        OnGlChanged()
      End Set
    End Property
    Public Property ToCostCenterPerson() As Employee
      Get
        Return m_toCostCenterPerson
      End Get
      Set(ByVal Value As Employee)
        m_toCostCenterPerson = Value
      End Set
    End Property
    Public ReadOnly Property ToAccount() As Account
      Get
        If Not Me.ToCostCenter Is Nothing AndAlso Me.ToCostCenter.Originated Then
          Select Case Me.m_toAcctType.Value
            Case 1 'WIP
              Return Me.ToCostCenter.WipAccount
            Case 2 'Expense
              Return Me.ToCostCenter.ExpenseAccount
            Case 3 'Store
              Return Me.ToCostCenter.StoreAccount
          End Select
        End If
      End Get
    End Property
    Public Property ToAccountType() As GoodsReceiptToAcctType
      Get
        Return Me.m_toAcctType
      End Get
      Set(ByVal Value As GoodsReceiptToAcctType)
        Me.m_toAcctType = Value
      End Set
    End Property
    Public Property DeliveryDocCode() As String
      Get
        Return m_deliveryDocCode
      End Get
      Set(ByVal Value As String)
        m_deliveryDocCode = Value
      End Set
    End Property
    Public Property DeliveryDocDate() As Date
      Get
        Return m_deliveryDocDate
      End Get
      Set(ByVal Value As Date)
        m_deliveryDocDate = Value
      End Set
    End Property
    Public Property Po() As PO
      Get
        Return m_po
      End Get
      Set(ByVal Value As PO)
        m_po = Value
        ChangePO()
        OnGlChanged()
      End Set
    End Property
    Private Sub ChangePO()
      'ลบรายการ
      Dim itemsToRemove As New ArrayList
      For Each item As GoodsReceiptItem In Me.ItemCollection
        If Not item.POitem Is Nothing Then
          If Not item.POitem.Po Is Nothing Then
            If item.POitem.Po.Originated Then
              itemsToRemove.Add(item)
            End If
          End If
        End If
      Next
      For Each item As GoodsReceiptItem In itemsToRemove
        Me.ItemCollection.Remove(item)
      Next
      Dim arr As New ArrayList
      If Not Me.m_po Is Nothing AndAlso Me.m_po.Originated Then

        '-----------------------NOTE--------------------------------------
        Dim config As Object = Configuration.GetConfig("PutPONoteInGR")
        Dim putit As Boolean = False
        If Not config Is Nothing Then
          putit = CBool(config)
        End If
        If putit AndAlso Not m_po.Note Is Nothing AndAlso m_po.Note.Length > 0 Then
          Me.Note = m_po.Note
        End If
        '-----------------------NOTE--------------------------------------

        Me.Supplier = Me.m_po.Supplier
        Me.CreditPeriod = Me.m_po.CreditPeriod
        Me.TaxType = Me.m_po.TaxType
        Me.TaxRate = Me.Po.TaxRate
        Me.ToCostCenter = Me.m_po.CostCenter
        'Me.Discount = Me.m_po.Discount
        Me.Discount = Me.m_po.RemainningDiscount
        Me.Retention = Math.Max(Me.m_po.Retention - Me.m_po.GetRetentionDeductedWithoutThisStock(Me.Id), 0)
        Dim oldTable As DataTable = Me.GetOldItemTable(Me.m_po)
        For Each newPoitem As POItem In Me.m_po.ItemCollection
          For Each row As DataRow In oldTable.Rows
            If CInt(row("poi_linenumber")) = newPoitem.LineNumber Then
              newPoitem.ReceivedQty = CDec(row("poi_receivedqty"))
              Exit For
            End If
          Next
          If newPoitem.ItemType.Value = 160 OrElse newPoitem.ItemType.Value = 162 OrElse newPoitem.ReceivedQty * newPoitem.Conversion < newPoitem.StockQty Then
            Dim item As New GoodsReceiptItem
            item.CopyFromPOItem(newPoitem)
            Me.ItemCollection.Add(item)
            'If newPoitem.ItemType.Value <> 160 AndAlso newPoitem.ItemType.Value <> 162 Then
            '  Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
            '                          , CommandType.StoredProcedure _
            '                          , "GetPOItems" _
            '                          , New SqlParameter("@po_id", newPoitem.Po.Id) _
            '                          , New SqlParameter("@poi_linenumber", newPoitem.LineNumber) _
            '                          )
            '  Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
            '  Dim wbsRows As DataRow() = ds.Tables(1).Select("poiw_poilinenumber=" & newPoitem.LineNumber)
            '  For Each wbsRow As DataRow In wbsRows
            '    Dim wbsd As New WBSDistribute(wbsRow, "")
            '    wbsdColl.Add(wbsd)
            'Next
            'End If
            arr.Add(item)
          End If
        Next
        Me.RefreshTaxBase()
        For Each item As GoodsReceiptItem In arr
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            Me.SetActual(wbsd.WBS, 0, item.BeforeTax * wbsd.Percent / 100, item.ItemType.Value)
            'Me.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, item.ItemType.Value)
          Next
        Next
      Else
        If Not Me.m_supplier Is Nothing Then
          Me.CreditPeriod = Me.Supplier.CreditPeriod
        End If
      End If
    End Sub
    Private Function GetOldItemTable(ByVal po As PO) As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGoodsReceiptItemFromPO" _
      , New SqlParameter("@stock_id", Me.Id) _
      , New SqlParameter("@poi_po", po.Id) _
      )
      Return ds.Tables(0)
    End Function
    Public Property Retention() As Decimal
      Get
        Return m_retention
      End Get
      Set(ByVal Value As Decimal)
        m_retention = Value
      End Set
    End Property
    Public Property Vat() As Vat Implements IVatable.Vat
      Get
        Return m_vat
      End Get
      Set(ByVal Value As Vat)
        m_vat = Value
      End Set
    End Property
    Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
      Get
        Return m_whtcol
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_whtcol = Value
      End Set
    End Property
    Public Property Note() As String Implements IPayable.Note, IGLAble.Note, IAdvancePayItemAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
        Dim config As Object = Configuration.GetConfig("PutGRNoteInOtherTabs")
        Dim putit As Boolean = False
        If Not config Is Nothing Then
          putit = CBool(config)
        End If
        If putit Then
          If Not Me.Payment Is Nothing Then
            Me.Payment.Note = m_note
          End If
          If Not Me.JournalEntry Is Nothing Then
            Me.JournalEntry.Note = m_note
          End If
        End If
      End Set
    End Property
    Public Property CreditPeriod() As Long
      Get
        Return m_creditPeriod
      End Get
      Set(ByVal Value As Long)
        m_creditPeriod = Value
      End Set
    End Property
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, GoodsReceiptStatus)
      End Set
    End Property
    Private m_gross As Decimal
    Public Property Gross() As Decimal
      Get
        Return m_gross
      End Get
      Set(ByVal Value As Decimal)
        m_gross = Value
      End Set
    End Property
    Public ReadOnly Property TaxGross() As Decimal
      Get
        Return m_taxGross
      End Get
    End Property
    Public Property Discount() As Discount
      Get
        Return m_discount
      End Get
      Set(ByVal Value As Discount)
        m_discount = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property DiscountAmount() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = Me.RealGross
        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)
      End Get
    End Property
    Public Property TaxRate() As Decimal
      Get
        Return m_taxRate
      End Get
      Set(ByVal Value As Decimal)
        m_taxRate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Private m_taxbase As Decimal
    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Return m_taxbase
      End Get
      Set(ByVal Value As Decimal)
        m_taxbase = Value
      End Set
    End Property
    Public Property TaxType() As TaxType Implements IAdvancePayItemAble.TaxType
      Get
        Return m_taxType
      End Get
      Set(ByVal Value As TaxType)
        m_taxType = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property TaxAmount() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 2 'รวม VAT
            Return Me.TaxGross - Me.DiscountWithVat - Me.RealTaxBase - Me.AdvancePayItemCollection.GetAmountForCalculate '- CDec(IIf(Me.AdvancePay.TaxType.Value = 2, Me.AdvancePayAmount, 0))
          Case Else '1 แยก
            Return Configuration.Format(((Me.TaxRate * Me.RealTaxBase) / 100), DigitConfig.Price)
        End Select
      End Get
    End Property
    Public ReadOnly Property BeforeTax() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetExcludeVATAmount
          Case 1 '"แยก"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetExcludeVATAmount
          Case 2 '"รวม"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetAmount 'Me.AfterTax - Me.RealTaxAmount
        End Select
      End Get
    End Property
    Public ReadOnly Property AfterTax() As Decimal Implements IApprovAble.AmountToApprove
      Get
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.BeforeTax - Me.Retention
          Case 1 '"แยก"
            Return Me.BeforeTax + Me.RealTaxAmount - Me.Retention
          Case 2 '"รวม"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetAmount - Me.Retention
        End Select
      End Get
    End Property
    Public Property ApprovePerson() As User
      Get
        Return m_approvePerson
      End Get
      Set(ByVal Value As User)
        m_approvePerson = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property ApproveDate() As DateTime
      Get
        Return m_approveDate
      End Get
      Set(ByVal Value As DateTime)
        m_approveDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property AdvancePayItemCollection() As AdvancePayItemCollection Implements IAdvancePayItemAble.AdvancePayItemCollection
      Get
        Return m_advancePayItemColl
      End Get
      Set(ByVal Value As AdvancePayItemCollection)
        m_advancePayItemColl = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "GoodsReceipt"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        If Not String.IsNullOrEmpty(MenuLabel) Then
          Return MenuLabel
        End If
        Return "${res:Longkong.Pojjaman.BusinessLogic.GoodsReceipt.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.GoodsReceipt"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.GoodsReceipt"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        If Not String.IsNullOrEmpty(MenuLabel) Then
          Return MenuLabel
        End If
        Return "${res:Longkong.Pojjaman.BusinessLogic.GoodsReceipt.ListLabel}"
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

    Public Property Unlock() As Boolean Implements IUnlockAble.Unlock
      Get
        Return m_Unlock
      End Get
      Set(ByVal Value As Boolean)
        m_Unlock = Value
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("GoodsReceipt")
      myDatatable.Columns.Add(New DataColumn("poi_po", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("po_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_linenumber", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("poi_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("poi_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("POItemCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("POItemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("POItemUnit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_qty", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("POItemRemainingQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_receivedqty", GetType(Decimal)))


      myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Barrier", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("StockQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_discrate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_acct", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("AccountCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Account", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AccountButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_quality", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unvatable", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("AssetString", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Overrides Sub ClearReference()
      If Not Me.Vat Is Nothing Then
        Me.Vat.RefDoc = Nothing
      End If
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.RefDoc = Nothing
      End If
      If Not Me.JournalEntry Is Nothing Then
        Me.JournalEntry.RefDoc = Nothing
      End If
      If Not Me.Payment Is Nothing Then
        Me.Payment.RefDoc = Nothing
      End If
    End Sub
    Public Sub SetActual(ByVal myWbs As WBS, ByVal oldVal As Decimal, ByVal newVal As Decimal, ByVal type As Integer)
      myWbs = New WBS(myWbs.Id)
      Dim o_n As OldNew
      Dim theHash As Hashtable
      Select Case type
        Case 0, 19, 42
          theHash = MatActualHash
        Case 88
          theHash = LabActualHash
        Case 89
          theHash = EQActualHash
      End Select
      If Not theHash Is Nothing Then
        If theHash.Contains(myWbs.Id) Then
          o_n = CType(theHash(myWbs.Id), OldNew)
        Else
          o_n = New OldNew
          Select Case type
            Case 0, 19, 42
              o_n.OldValue = myWbs.GetActualMat(Me, 45)
            Case 88
              o_n.OldValue = myWbs.GetActualLab(Me, 45)
            Case 89
              o_n.OldValue = myWbs.GetActualEq(Me, 45)
          End Select
          o_n.NewValue = o_n.OldValue
          theHash(myWbs.Id) = o_n
        End If
        o_n.NewValue += (newVal - oldVal)

        'ส่งต่อไปยังแม่
        If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
          SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, type)
        End If
      End If
    End Sub
    Public Function GetCurrentDiffForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
      Dim theHash As Hashtable
      Select Case itemType.Value
        Case 0, 19, 42
          theHash = MatActualHash
        Case 88
          theHash = LabActualHash
        Case 89
          theHash = EQActualHash
      End Select
      If Not theHash Is Nothing AndAlso theHash.Contains(myWbs.Id) Then
        Dim o_n As OldNew = CType(theHash(myWbs.Id), OldNew)
        Return o_n.NewValue - o_n.OldValue
      End If
      Return 0
    End Function
    Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
      Dim ret As Decimal = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection
        Dim flag As Boolean = False
        If Not item.ItemType Is Nothing Then
          Select Case itemType.Value
            Case 0, 19, 42
              Select Case item.ItemType.Value
                Case 0, 19, 42
                  flag = True
                Case Else
                  flag = False
              End Select
            Case 88
              Select Case item.ItemType.Value
                Case 88
                  flag = True
                Case Else
                  flag = False
              End Select
            Case 89
              Select Case item.ItemType.Value
                Case 89
                  flag = True
                Case Else
                  flag = False
              End Select
          End Select
        End If
        If flag Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 45
              Dim transferAmt As Decimal = item.BeforeTax 'item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.Amount, isOut, view, Me.ToAccountType.Value)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Public Function GetCurrentAmountForMarkup(ByVal mk As Markup) As Decimal
      Dim ret As Decimal = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection
        For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
          If grWBSD.IsMarkup Then
            If grWBSD.WBS.Id = mk.Id And mk.Id <> 0 Then
              ret += (grWBSD.Percent * item.Amount / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Public Function GetCurrentTypeQtyForWBS(ByVal myWbs As WBS, ByVal name As String, ByVal type As Integer) As Decimal
      Dim ret As Decimal = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection
        Dim theName As String = item.EntityName
        If theName Is Nothing Then
          theName = item.Entity.Name
        End If
        If theName Is Nothing Then
          theName = ""
        End If
        If name Is Nothing Then
          name = ""
        End If
        If Not item.ItemType Is Nothing _
        AndAlso item.ItemType.Value = type _
        AndAlso theName.ToLower = name.ToLower Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 45
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, Me.ToAccountType.Value)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Public Function GetCurrentMatQtyForWBS(ByVal myWbs As WBS, ByVal matId As Integer) As Decimal
      Dim ret As Decimal = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection
        If Not item.ItemType Is Nothing _
            AndAlso item.ItemType.Value = 42 _
            AndAlso item.Entity.Id = matId Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 45
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, Me.ToAccountType.Value)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Public Function GetCurrentLabQtyForWBS(ByVal myWbs As WBS, ByVal name As String) As Decimal
      Dim ret As Decimal = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection
        Dim theName As String = item.EntityName
        If theName Is Nothing Then
          theName = item.Entity.Name
        End If
        If theName Is Nothing Then
          theName = ""
        End If
        If name Is Nothing Then
          name = ""
        End If
        If Not item.ItemType Is Nothing _
        AndAlso item.ItemType.Value = 88 _
        AndAlso theName.ToLower = name.ToLower Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 45
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, Me.ToAccountType.Value)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Public Function GetCurrentEqQtyForWBS(ByVal myWbs As WBS, ByVal name As String) As Decimal
      Dim ret As Decimal = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection
        Dim theName As String = item.EntityName
        If theName Is Nothing Then
          theName = item.Entity.Name
        End If
        If theName Is Nothing Then
          theName = ""
        End If
        If name Is Nothing Then
          name = ""
        End If
        If Not item.ItemType Is Nothing _
        AndAlso item.ItemType.Value = 89 _
        AndAlso theName.ToLower = name.ToLower Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 45
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, Me.ToAccountType.Value)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Public Function IsMathwidthdrawReferenced() As Boolean
      Dim isMatWidthdraw As Boolean = False
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetReferenceDocs" _
                , New SqlParameter("@entity_id", Me.Id) _
                , New SqlParameter("@entity_type", Me.EntityId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If ds.Tables(0).Rows(0).IsNull(0) Then
            Return True
          End If
          For Each dr As DataRow In ds.Tables(0).Rows
            If Not dr.IsNull("refto_type") AndAlso CInt(dr("refto_type")) = 31 Then
              isMatWidthdraw = True
            Else
              isMatWidthdraw = False
            End If
          Next
        End If
      Catch ex As Exception
      End Try
      Return isMatWidthdraw
    End Function
    Private Function OverBudget() As Boolean
      If Me.ToCostCenter.Type.Value <> 2 Then
        Return False
      End If
      If Me.ToCostCenter.Boq Is Nothing OrElse Me.ToCostCenter.Boq.Id = 0 Then
        Return False
      End If
      'GROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("GROverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If
      If Not onlyCC Then
        For Each item As GoodsReceiptItem In Me.ItemCollection
          If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
            Dim wsdColl As WBSDistributeCollection = item.WBSDistributeCollection
            If wsdColl.Count = 0 Then
              Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
              Dim totalBudget As Decimal = 0
              Dim totalActual As Decimal = 0
              Dim totalCurrentDiff As Decimal = item.Amount
              Select Case item.ItemType.Value
                Case 88
                  totalBudget = rootWBS.GetTotalLabFromDB
                  totalActual = rootWBS.GetActualLab(Me, 45)
                Case 89
                  totalBudget = rootWBS.GetTotalEQFromDB
                  totalActual = rootWBS.GetActualEq(Me, 45)
                Case Else
                  totalBudget = rootWBS.GetTotalMatFromDB
                  totalActual = rootWBS.GetActualMat(Me, 45)
              End Select
              If totalBudget < (totalActual + totalCurrentDiff) Then
                Return True
              End If
            End If
            For Each wbsd As WBSDistribute In wsdColl
              If wbsd.AmountOverBudget Then
                Return True
              End If
              Dim rootWBS As New WBS(wbsd.WBS.Id)
              Dim totalBudget As Decimal = 0
              Dim totalActual As Decimal = 0
              Dim totalCurrentDiff As Decimal = 0
              Select Case item.ItemType.Value
                Case 88
                  totalCurrentDiff = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(88))
                Case 89
                  totalCurrentDiff = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(89))
                Case Else
                  totalCurrentDiff = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(0))
              End Select
              For Each row As DataRow In rootWBS.GetParentsBudget(Me.EntityId)
                totalBudget = 0
                totalActual = 0
                Select Case item.ItemType.Value
                  Case 88
                    If Not row.IsNull("labbudget") Then
                      totalBudget = CDec(row("labbudget"))
                    End If
                    If Not row.IsNull("labactual") Then
                      totalActual = CDec(row("labactual"))
                    End If
                  Case 89
                    If Not row.IsNull("eqbudget") Then
                      totalBudget = CDec(row("eqbudget"))
                    End If
                    If Not row.IsNull("eqactual") Then
                      totalActual = CDec(row("eqactual"))
                    End If
                  Case Else
                    If Not row.IsNull("matbudget") Then
                      totalBudget = CDec(row("matbudget"))
                    End If
                    If Not row.IsNull("matactual") Then
                      totalActual = CDec(row("matactual"))
                    End If
                End Select
                If totalBudget < (totalActual + totalCurrentDiff) Then
                  Return True
                End If
              Next
            Next
          End If
        Next
      Else
        Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
        Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
        Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
        Dim totalCurrentDiff As Decimal = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(0)) + _
        Me.GetCurrentDiffForWBS(rootWBS, New ItemType(88)) + _
        Me.GetCurrentDiffForWBS(rootWBS, New ItemType(89))
        If totalBudget < (totalActual + totalCurrentDiff) Then
          Return True
        End If
      End If
      Return False
    End Function
    'Private Sub ResetId(ByVal oldId As Integer, ByVal oldPaymentId As Integer)
    '    Me.Id = oldId
    '    Me.m_payment.Id = oldPaymentId
    'End Sub
    'Public Function SaveNoItem(ByVal currentUserId As Integer) As SaveErrorException
    '    With Me

    '        Dim tmpBoq As BOQ = Me.ToCostCenter.Boq

    '        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
    '        returnVal.ParameterName = "RETURN_VALUE"
    '        returnVal.DbType = DbType.Int32
    '        returnVal.Direction = ParameterDirection.ReturnValue
    '        returnVal.SourceVersion = DataRowVersion.Current

    '        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
    '        Dim paramArrayList As New ArrayList

    '        paramArrayList.Add(returnVal)
    '        If Me.Originated Then
    '            paramArrayList.Add(New SqlParameter("@stock_id", Me.Id))
    '        End If

    '        Dim theTime As Date = Now
    '        Dim theUser As New User(currentUserId)

    '        If Me.Status.Value = 0 Then
    '            Me.m_payment.Status.Value = 0
    '        End If
    '        If Me.Status.Value = -1 Then
    '            Me.Status = New GoodsReceiptStatus(2)
    '        End If

    '        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
    '            Me.Code = Me.GetNextCode
    '        End If
    '        Me.AutoGen = False
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.Supplier.Id))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Supplier.EntityId))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityPerson", Me.DeliveryPerson))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocCode", Me.DeliveryDocCode))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocDate", ValidDateOrDBNull(Me.DeliveryDocDate)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_refDoc", ValidIdOrDBNull(Me.Po)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toAcct", ValidIdOrDBNull(Me.ToAccount)))
    '        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ""))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toCCPerson", ValidIdOrDBNull(Me.ToCostCenterPerson)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", ValidIdOrDBNull(Me.ToCostCenter)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.RealGross))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discRate", Me.Discount.Rate))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discAmt", Me.DiscountAmount))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.BeforeTax))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_afterTax", Me.AfterTax))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tag", Me.ToAccountType.Value))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))

    '        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

    '        ' สร้าง SqlParameter จาก ArrayList ...
    '        Dim sqlparams() As SqlParameter
    '        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
    '        Dim trans As SqlTransaction
    '        Dim conn As New SqlConnection(Me.ConnectionString)
    '        conn.Open()
    '        trans = conn.BeginTransaction()
    '        Dim oldId As Integer = Me.Id
    '        Dim oldPaymentId As Integer = Me.m_payment.Id
    '        Try
    '            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
    '            If IsNumeric(returnVal.Value) Then
    '                Select Case CInt(returnVal.Value)
    '                    Case -1, -5
    '                        trans.Rollback()
    '                        ResetId(oldId, oldPaymentId)
    '                        Return New SaveErrorException(returnVal.Value.ToString)
    '                    Case -2 'เอกสารถูกอ้างอิงแล้ว
    '                        If Me.IsDirty Then 'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
    '                            trans.Rollback()
    '                            ResetId(oldId, oldPaymentId)
    '                            Return New SaveErrorException(returnVal.Value.ToString)
    '                        End If
    '                    Case Else
    '                End Select
    '            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
    '                trans.Rollback()
    '                ResetId(oldId, oldPaymentId)
    '                Return New SaveErrorException(returnVal.Value.ToString)
    '            End If
    '            If Not Me.ToCostCenter Is Nothing Then
    '                Me.m_payment.CCId = Me.ToCostCenter.Id
    '            End If
    '            Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
    '            If Not IsNumeric(savePaymentError.Message) Then
    '                Me.m_payment.Id = oldPaymentId
    '                trans.Rollback()
    '                ResetId(oldId, oldPaymentId)
    '                Return savePaymentError
    '            Else
    '                Select Case CInt(savePaymentError.Message)
    '                    Case -1, -2, -5
    '                        trans.Rollback()
    '                        ResetId(oldId, oldPaymentId)
    '                        Return savePaymentError
    '                    Case Else
    '                End Select
    '            End If

    '            Me.DeleteRef(conn, trans)
    '            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePO_GRRef" _
    '            , New SqlParameter("@stock_id", Me.Id))
    '            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
    '            , New SqlParameter("@refto_id", Me.Id))
    '            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
    '            , New SqlParameter("@refto_id", Me.Id))
    '            If Me.Status.Value = 0 Then
    '                Me.CancelRef(conn, trans)
    '            End If

    '            trans.Commit()
    '            If Not Me.IsDirty AndAlso returnVal.Value.ToString = "-2" Then 'ถ้าเอกสารไม่ถูกแก้ไข --> ให้ save
    '                Return New SaveErrorException(Me.Id.ToString)
    '            End If
    '            Return New SaveErrorException(returnVal.Value.ToString)
    '        Catch ex As SqlException
    '            trans.Rollback()
    '            ResetId(oldId, oldPaymentId)
    '            Return New SaveErrorException(ex.ToString)
    '        Catch ex As Exception
    '            trans.Rollback()
    '            ResetId(oldId, oldPaymentId)
    '            Return New SaveErrorException(ex.ToString)
    '        Finally
    '            conn.Close()
    '        End Try
    '    End With
    'End Function
    'Public Function SaveOnlyPayment(ByVal currentUserId As Integer) As SaveErrorException
    '    With Me

    '        Dim tmpBoq As BOQ = Me.ToCostCenter.Boq

    '        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
    '        returnVal.ParameterName = "RETURN_VALUE"
    '        returnVal.DbType = DbType.Int32
    '        returnVal.Direction = ParameterDirection.ReturnValue
    '        returnVal.SourceVersion = DataRowVersion.Current

    '        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
    '        Dim paramArrayList As New ArrayList

    '        paramArrayList.Add(returnVal)
    '        If Me.Originated Then
    '            paramArrayList.Add(New SqlParameter("@stock_id", Me.Id))
    '        End If

    '        Dim theTime As Date = Now
    '        Dim theUser As New User(currentUserId)

    '        If Me.Status.Value = 0 Then
    '            Me.m_payment.Status.Value = 0
    '        End If
    '        If Me.Status.Value = -1 Then
    '            Me.Status = New GoodsReceiptStatus(2)
    '        End If

    '        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
    '            Me.Code = Me.GetNextCode
    '        End If
    '        Me.AutoGen = False
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.Supplier.Id))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Supplier.EntityId))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityPerson", Me.DeliveryPerson))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocCode", Me.DeliveryDocCode))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocDate", ValidDateOrDBNull(Me.DeliveryDocDate)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_refDoc", ValidIdOrDBNull(Me.Po)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toAcct", ValidIdOrDBNull(Me.ToAccount)))
    '        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ""))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toCCPerson", ValidIdOrDBNull(Me.ToCostCenterPerson)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", ValidIdOrDBNull(Me.ToCostCenter)))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.RealGross))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discRate", Me.Discount.Rate))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discAmt", Me.DiscountAmount))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.BeforeTax))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_afterTax", Me.AfterTax))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tag", Me.ToAccountType.Value))
    '        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))

    '        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

    '        ' สร้าง SqlParameter จาก ArrayList ...
    '        Dim sqlparams() As SqlParameter
    '        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
    '        Dim trans As SqlTransaction
    '        Dim conn As New SqlConnection(Me.ConnectionString)
    '        conn.Open()
    '        trans = conn.BeginTransaction()
    '        Dim oldId As Integer = Me.Id
    '        Dim oldPaymentId As Integer = Me.m_payment.Id
    '        Try
    '            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
    '            If IsNumeric(returnVal.Value) Then
    '                Select Case CInt(returnVal.Value)
    '                    Case -1, -5
    '                        trans.Rollback()
    '                        ResetId(oldId, oldPaymentId)
    '                        Return New SaveErrorException(returnVal.Value.ToString)
    '                    Case -2 'เอกสารถูกอ้างอิงแล้ว
    '                        If Me.IsDirty Then 'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
    '                            trans.Rollback()
    '                            ResetId(oldId, oldPaymentId)
    '                            Return New SaveErrorException(returnVal.Value.ToString)
    '                        End If
    '                    Case Else
    '                End Select
    '            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
    '                trans.Rollback()
    '                ResetId(oldId, oldPaymentId)
    '                Return New SaveErrorException(returnVal.Value.ToString)
    '            End If

    '            Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
    '            If Not IsNumeric(saveDetailError.Message) Then
    '                trans.Rollback()
    '                ResetId(oldId, oldPaymentId)
    '                Return saveDetailError
    '            Else
    '                Select Case CInt(saveDetailError.Message)
    '                    Case -1, -2, -5
    '                        trans.Rollback()
    '                        ResetId(oldId, oldPaymentId)
    '                        Return saveDetailError
    '                    Case Else
    '                End Select
    '            End If

    '            If Not Me.m_advancePayItemColl Is Nothing AndAlso Me.m_advancePayItemColl.Count > 0 Then
    '                If Me.m_advancePayItemColl.RefDoc Is Nothing Then
    '                    Me.m_advancePayItemColl.RefDoc = Me
    '                End If
    '                Dim saveAdvancePayError As SaveErrorException = Me.m_advancePayItemColl.Save(currentUserId, conn, trans)
    '                If Not IsNumeric(saveAdvancePayError.Message) Then
    '                    trans.Rollback()
    '                    ResetId(oldId, oldPaymentId)
    '                    Return saveAdvancePayError
    '                Else
    '                    Select Case CInt(saveAdvancePayError.Message)
    '                        Case -1, -2, -5
    '                            trans.Rollback()
    '                            ResetId(oldId, oldPaymentId)
    '                            Return saveAdvancePayError
    '                        Case Else
    '                    End Select
    '                End If
    '            End If

    '            If Not Me.ToCostCenter Is Nothing Then
    '                Me.m_payment.CCId = Me.ToCostCenter.Id
    '            End If
    '            Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
    '            If Not IsNumeric(savePaymentError.Message) Then
    '                Me.m_payment.Id = oldPaymentId
    '                trans.Rollback()
    '                ResetId(oldId, oldPaymentId)
    '                Return savePaymentError
    '            Else
    '                Select Case CInt(savePaymentError.Message)
    '                    Case -1, -2, -5
    '                        trans.Rollback()
    '                        ResetId(oldId, oldPaymentId)
    '                        Return savePaymentError
    '                    Case Else
    '                End Select
    '            End If

    '            Me.DeleteRef(conn, trans)
    '            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePO_GRRef" _
    '            , New SqlParameter("@stock_id", Me.Id))
    '            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
    '            , New SqlParameter("@refto_id", Me.Id))
    '            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
    '            , New SqlParameter("@refto_id", Me.Id))
    '            If Me.Status.Value = 0 Then
    '                Me.CancelRef(conn, trans)
    '            End If

    '            trans.Commit()
    '            If Not Me.IsDirty AndAlso returnVal.Value.ToString = "-2" Then 'ถ้าเอกสารไม่ถูกแก้ไข --> ให้ save
    '                Return New SaveErrorException(Me.Id.ToString)
    '            End If
    '            Return New SaveErrorException(returnVal.Value.ToString)
    '        Catch ex As SqlException
    '            trans.Rollback()
    '            ResetId(oldId, oldPaymentId)
    '            Return New SaveErrorException(ex.ToString)
    '        Catch ex As Exception
    '            trans.Rollback()
    '            ResetId(oldId, oldPaymentId)
    '            Return New SaveErrorException(ex.ToString)
    '        Finally
    '            conn.Close()
    '        End Try
    '    End With
    'End Function
    Private Sub ResetId(ByVal oldId As Integer, ByVal oldPaymentId As Integer _
    , ByVal oldVatId As Integer, ByVal oldJeId As Integer)
      Me.Id = oldId
      Me.m_payment.Id = oldPaymentId
      Me.m_vat.Id = oldVatId
      Me.m_je.Id = oldJeId
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
      Me.m_vat.SetRefDocToItem(Me.Id, Me.EntityId)
    End Sub
    'Public NoItem As Boolean = False
    'Public OnlyPayment As Boolean = False
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me

        If Originated Then
          If Not Supplier Is Nothing Then
            If Supplier.Canceled Then
              Return New SaveErrorException(StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Supplier.Code})
            End If
          End If
        End If
        Dim config As Integer = CInt(Configuration.GetConfig("GROverBudget"))
        Select Case config
          Case 0 'Not allow
            If OverBudget() Then
              Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.GROverBudgetCannotBeSaved}"))
            End If
          Case 1 'Warn
            If OverBudget() Then
              Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              If Not msgServ.AskQuestion("${res:Global.Question.GROverBudgetSaveAnyway}") Then
                Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
              End If
            End If
          Case 2 'Do Nothing
        End Select
        'If NoItem Then
        '    Return Me.SaveNoItem(currentUserId)
        'ElseIf OnlyPayment Then
        '    Return Me.SaveOnlyPayment(currentUserId)
        'End If
        Me.RefreshTaxBase()
        If Me.ItemCollection.Count <= 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If

        'Dim tmpBoq As BOQ = Me.ToCostCenter.Boq

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@stock_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_payment.Status.Value = 4
          Me.m_whtcol.SetStatus(4)
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = 0 Then
          Me.m_payment.Status.Value = 0
          Me.m_whtcol.SetStatus(0)
          Me.m_vat.Status.Value = 0
          Me.m_je.Status.Value = 0
        End If
        If Me.Status.Value = -1 Then
          Me.Status = New GoodsReceiptStatus(2)
        End If
        '---- AutoCode Format --------
        Me.m_je.RefreshGLFormat()
        If Not AutoCodeFormat Is Nothing Then
          Select Case Me.AutoCodeFormat.CodeConfig.Value
            Case 0
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.DontSave = True
              Me.m_je.Code = ""
              Me.m_je.DocDate = Me.DocDate
            Case 1
              'ตาม entity
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.Code = Me.Code
            Case 2
              'ตาม gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
            Case Else
              'แยก
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          '=====เอาออกได้นะ block นี่้
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        If Me.Payment.Gross <> 0 Then
          Me.m_payment.Code = m_je.Code
        End If

        Me.m_je.DocDate = Me.DocDate
        Me.m_payment.DocDate = m_je.DocDate
        Me.AutoGen = False
        Me.m_payment.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.Supplier.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Supplier.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityPerson", Me.DeliveryPerson))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocCode", Me.DeliveryDocCode))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocDate", ValidDateOrDBNull(Me.DeliveryDocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_refDoc", ValidIdOrDBNull(Me.Po)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toAcct", ValidIdOrDBNull(Me.ToAccount)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ""))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toCCPerson", ValidIdOrDBNull(Me.ToCostCenterPerson)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", ValidIdOrDBNull(Me.ToCostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.RealGross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discRate", Me.Discount.Rate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discAmt", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_afterTax", Me.AfterTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tag", Me.ToAccountType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_asset", ValidIdOrDBNull(Me.Asset)))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Dim oldId As Integer = Me.Id
        Dim oldPaymentId As Integer = Me.m_payment.Id
        Dim oldVatId As Integer = Me.m_vat.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If
        Dim oldJeId As Integer = Me.m_je.Id
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -5
                trans.Rollback()
                ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -2 'เอกสารถูกอ้างอิงแล้ว
                If Me.IsDirty Then 'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
                  trans.Rollback()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  Return New SaveErrorException(returnVal.Value.ToString)
                End If
              Case -69 'ใบส่งของซ้ำ
                If Me.IsDirty Then 'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
                  trans.Rollback()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  Return New SaveErrorException("${res:Global.Error.DeliveryDocCodeDuplicated}", Me.DeliveryDocCode)
                End If
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
          If Not IsNumeric(saveDetailError.Message) Then
            trans.Rollback()
            ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
            Return saveDetailError
          Else
            Select Case CInt(saveDetailError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                Return saveDetailError
              Case Else
            End Select
          End If

          If Not Me.ToCostCenter Is Nothing Then
            Me.m_payment.CCId = Me.ToCostCenter.Id
            Me.m_whtcol.SetCCId(Me.ToCostCenter.Id)
            Me.m_vat.SetCCId(Me.ToCostCenter.Id)
          End If
          Me.m_vat.SetRefDocToItem(Me.Id, Me.EntityId)
          Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
          If Not IsNumeric(savePaymentError.Message) Then
            Me.m_payment.Id = oldPaymentId
            trans.Rollback()
            ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
            Return savePaymentError
          Else
            Select Case CInt(savePaymentError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                Return savePaymentError
              Case Else
            End Select
          End If

          If Not Me.m_advancePayItemColl Is Nothing Then
            If Me.m_advancePayItemColl.RefDoc Is Nothing Then
              Me.m_advancePayItemColl.RefDoc = Me
            End If
            For Each advi As AdvancePayItem In Me.m_advancePayItemColl
              advi.Status = Me.Status.Value
            Next
            Dim saveAdvancePayError As SaveErrorException = Me.m_advancePayItemColl.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveAdvancePayError.Message) Then
              trans.Rollback()
              ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
              Return saveAdvancePayError
            Else
              Select Case CInt(saveAdvancePayError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  Return saveAdvancePayError
                Case Else
              End Select
            End If
          End If

          Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveVatError.Message) Then
            trans.Rollback()
            ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
            Return saveVatError
          Else
            Select Case CInt(saveVatError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                Return saveVatError
              Case Else
            End Select
          End If

          If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
            Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveWhtError.Message) Then
              trans.Rollback()
              ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
              Return saveWhtError
            Else
              Select Case CInt(saveWhtError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  Return saveWhtError
                Case Else
              End Select
            End If
          End If

          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
                ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                Return saveJeError
              Case -2
                'Post ไปแล้ว
                ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                Return saveJeError
              Case Else
            End Select
          End If

          For Each extender As Object In Me.Extenders
            If TypeOf extender Is IExtender Then
              Dim saveDocError As SaveErrorException = CType(extender, IExtender).Save(conn, trans)
              If Not IsNumeric(saveDocError.Message) Then
                trans.Rollback()
                Return saveDocError
              Else
                Select Case CInt(saveDocError.Message)
                  Case -1, -2, -5
                    trans.Rollback()
                    Return saveDocError
                  Case Else
                End Select
              End If
            End If
          Next

          Me.DeleteRef(conn, trans)
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePO_GRRef" _
          , New SqlParameter("@stock_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
          , New SqlParameter("@refto_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
          , New SqlParameter("@refto_id", Me.Id))
          If Me.Status.Value = 0 Then
            Me.CancelRef(conn, trans)
          End If
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGoodsReceiptPVList", New SqlParameter("@stock_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_InsertStockProcedure", New SqlParameter("@stock_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_InsertStock2Procedure", New SqlParameter("@stock_id", Me.Id))

          '==============================AUTOGEN==========================================
          Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          If Not IsNumeric(saveAutoCodeError.Message) Then
            trans.Rollback()
            ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================

          trans.Commit()
          If Not Me.IsDirty AndAlso returnVal.Value.ToString = "-2" Then 'ถ้าเอกสารไม่ถูกแก้ไข --> ให้ save
            Return New SaveErrorException(Me.Id.ToString)
          End If
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code 'Entity.GetAutoCodeFormat(Me.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(autoCodeFormat, Me)

      pattern = CodeGenerator.GetPattern(pattern)

      Dim lastCode As String = Me.GetLastCode(pattern)
      Dim newCode As String = _
      CodeGenerator.Generate(autoCodeFormat, lastCode, Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(autoCodeFormat, newCode, Me)
      End While
      Return newCode
    End Function
    'Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
    '    If Not Me.Originated Then
    '        Return
    '    End If
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSMarkupStatusB4GRSave", New SqlParameter("@stock_id", Me.Id))
    'End Sub
    'Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
    '    If Not Me.Originated Then
    '        Return
    '    End If
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSMarkupStatusAfterGRSave", New SqlParameter("@stock_id", Me.Id))
    'End Sub
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim unitCost As Decimal = 0
        Dim Cost As Decimal = 0

        Dim da_aux As New SqlDataAdapter("Select * from stock_aux where stock_aux_id=" & Me.Id, conn)

        Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ")", conn)


        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From stockitem Where stocki_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "stockitem")
        da.Fill(ds, "stockitem")

        cmdBuilder = New SqlCommandBuilder(da_aux)
        da_aux.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        da_aux.FillSchema(ds, SchemaType.Mapped, "stock_aux")
        da_aux.Fill(ds, "stock_aux")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "stockiwbs")
        daWbs.Fill(ds, "stockiwbs")
        ds.Relations.Add("sequence", ds.Tables!stockitem.Columns!stocki_sequence, ds.Tables!stockiwbs.Columns!stockiw_sequence)

        Dim dt As DataTable = ds.Tables("stockitem")

        Dim dtAux As DataTable = ds.Tables("stock_aux")
        If IsNumeric(Me.DocType) AndAlso Me.DocType <> "0" Then
          Dim drAux As DataRow
          If dtAux.Rows.Count > 0 Then
            drAux = dtAux.Rows(0)
          Else
            drAux = dtAux.NewRow
            drAux("stock_aux_id") = Me.Id
            dtAux.Rows.Add(drAux)
          End If
          If Not drAux Is Nothing Then
            drAux("stock_aux_doctype") = CInt(Me.DocType)
          End If
        End If
        
        Dim dtWbs As DataTable = ds.Tables("stockiwbs")

        For Each row As DataRow In ds.Tables("stockiwbs").Rows
          row.Delete()
        Next

        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As GoodsReceiptItem In Me.ItemCollection
            If testItem.Sequence = CInt(dr("stocki_sequence")) Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            If Not rowsToDelete.Contains(dr) Then
              rowsToDelete.Add(dr)
            End If
          End If
        Next
        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next
        '------------End Checking--------------------

        Dim i As Integer = 0        'Line Running
        Dim seq As Integer = -1
        For Each item As GoodsReceiptItem In Me.ItemCollection
          i += 1
          unitCost = item.UnitCost
          Cost = item.Cost

          Select Case item.ItemType.Value
            Case 42
              Dim lci As New LCIItem(item.Entity.Id)
              If Not lci.Originated Then
                Return New SaveErrorException("${res:Global.Error.LCIIsInvalid}", New String() {item.Entity.Name})
              ElseIf Not lci.ValidUnit(item.Unit) Then
                Return New SaveErrorException("${res:Global.Error.LCIInvalidUnit}", New String() {lci.Code, item.Unit.Name})
              End If
            Case 19
              Dim myTool As New Tool(item.Entity.Id)
              If Not myTool.Originated Then
                Return New SaveErrorException("${res:Global.Error.ToolIsInvalid}", New String() {item.Entity.Name})
              ElseIf myTool.Unit.Id <> item.Unit.Id Then
                Return New SaveErrorException("${res:Global.Error.ToolInvalidUnit}", New String() {myTool.Code, item.Unit.Name})
              End If
          End Select

          '------------Checking if we have to add a new row or just update existing--------------------
          Dim dr As DataRow
          Dim drs As DataRow() = dt.Select("stocki_sequence=" & item.Sequence)
          If drs.Length = 0 Then
            dr = dt.NewRow
            'dt.Rows.Add(dr)
            seq = seq + (-1)
            dr("stocki_sequence") = seq
          Else
            dr = drs(0)
          End If
          '------------End Checking--------------------

          If item.POitem Is Nothing Then
            dr("stocki_refdoc") = DBNull.Value
            dr("stocki_refdoclinenumber") = DBNull.Value
          Else
            dr("stocki_refdoc") = item.POitem.Po.Id
            dr("stocki_refdoclinenumber") = item.POitem.LineNumber
          End If
          dr("stocki_toacct") = Me.ValidIdOrDBNull(Me.ToAccount)
          dr("stocki_toacctType") = Me.ToAccountType.Value          'เมื่อก่อนเป็น 3
          dr("stocki_stock") = Me.Id
          dr("stocki_tocc") = Me.ValidIdOrDBNull(Me.ToCostCenter)
          dr("stocki_acct") = Me.ValidIdOrDBNull(item.Account)
          dr("stocki_linenumber") = i
          dr("stocki_entity") = item.Entity.Id
          dr("stocki_entityType") = item.ItemType.Value
          dr("stocki_itemName") = item.EntityName
          dr("stocki_unit") = item.Unit.Id
          dr("stocki_qty") = item.Qty
          dr("stocki_stockqty") = item.StockQty
          dr("stocki_unitprice") = item.UnitPrice
          dr("stocki_unitcost") = unitCost
          dr("stocki_amt") = item.Amount
          dr("stocki_discrate") = item.Discount.Rate
          dr("stocki_discamt") = item.Discount.Amount
          dr("stocki_unvatable") = item.UnVatable
          dr("stocki_note") = item.Note
          dr("stocki_type") = Me.EntityId
          dr("stocki_iscancelled") = IIf(Me.Canceled, Me.Canceled, DBNull.Value)
          dr("stocki_status") = Me.Status.Value
          dr("stocki_transferunitprice") = unitCost
          dr("stocki_transferamt") = Cost
          dr("stocki_refsequence") = 0
          dr("stocki_asset") = item.AssetString
          dr("stocki_quality") = item.Quality

          '------------Checking if we have to add a new row or just update existing--------------------
          If drs.Length = 0 Then
            dt.Rows.Add(dr)
          End If
          '------------End Checking--------------------

          Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
          If item.ItemType.Value <> 160 _
          AndAlso item.ItemType.Value <> 162 Then
            Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
            Dim currentSum As Decimal = wbsdColl.GetSumPercent
            For Each wbsd As WBSDistribute In wbsdColl
              If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                'ยังไม่เต็ม 100 แต่มีหัวอยู่
                wbsd.Percent += (100 - currentSum)
              End If
              wbsd.BaseCost = Cost
              wbsd.TransferBaseCost = Cost
              Dim childDr As DataRow = dtWbs.NewRow
              childDr("stockiw_wbs") = wbsd.WBS.Id
              If wbsd.CostCenter Is Nothing Then
                wbsd.CostCenter = Me.ToCostCenter
              End If
              childDr("stockiw_cc") = wbsd.CostCenter.Id
              childDr("stockiw_percent") = wbsd.Percent
              childDr("stockiw_sequence") = dr("stocki_sequence")
              childDr("stockiw_ismarkup") = wbsd.IsMarkup
              childDr("stockiw_direction") = 0              'in
              childDr("stockiw_baseCost") = wbsd.BaseCost
              childDr("stockiw_transferbaseCost") = wbsd.TransferBaseCost
              childDr("stockiw_transferamt") = wbsd.TransferAmount
              childDr("stockiw_amt") = wbsd.Amount
              childDr("stockiw_toaccttype") = Me.ToAccountType.Value
              'Add เข้า stockiwbs
              dtWbs.Rows.Add(childDr)
            Next

            currentSum = wbsdColl.GetSumPercent
            'ยังไม่เต็ม 100 และยังไม่มี root
            If currentSum < 100 Then
              Try
                Dim newWbsd As New WBSDistribute
                newWbsd.WBS = rootWBS
                newWbsd.CostCenter = item.GoodsReceipt.ToCostCenter
                newWbsd.Percent = 100 - currentSum
                newWbsd.BaseCost = Cost
                newWbsd.TransferBaseCost = Cost
                Dim childDr As DataRow = dtWbs.NewRow
                childDr("stockiw_wbs") = newWbsd.WBS.Id
                childDr("stockiw_cc") = newWbsd.CostCenter.Id
                childDr("stockiw_percent") = newWbsd.Percent
                childDr("stockiw_sequence") = dr("stocki_sequence")
                childDr("stockiw_ismarkup") = False
                childDr("stockiw_direction") = 0                'in
                childDr("stockiw_baseCost") = newWbsd.BaseCost
                childDr("stockiw_transferbaseCost") = newWbsd.TransferBaseCost
                childDr("stockiw_transferamt") = newWbsd.TransferAmount
                childDr("stockiw_amt") = newWbsd.Amount
                childDr("stockiw_toaccttype") = Me.ToAccountType.Value
                'Add เข้า stockiwbs
                dtWbs.Rows.Add(childDr)
              Catch ex As Exception
                MessageBox.Show(ex.ToString)
              End Try
            End If
          End If
        Next

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

        daWbs.Update(GetDeletedRows(dtWbs))
        da_aux.Update(GetDeletedRows(dtAux))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        da_aux.Update(dtAux.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        da_aux.Update(dtAux.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
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
        Dim currentkey As Integer = CInt(e.Row("stockiw_sequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!stockiw_sequence = e.Row.GetParentRow("sequence")("stocki_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!stockiw_sequence = currentkey
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

#Region "RefreshTaxBase"
    Private m_taxGross As Decimal
    Public Sub RefreshTaxBase()
      m_gross = 0
      m_taxGross = 0
      m_taxbase = 0

      If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then
        Return
      End If

      Dim sumAmountWithVat As Decimal = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection
        m_gross += item.Amount
        If Not item.UnVatable Then
          m_taxGross += item.Amount
          sumAmountWithVat += item.Amount
        End If
      Next
      Select Case Me.TaxType.Value
        Case 0 '"ไม่มี"
          m_taxbase = 0
        Case 1 '"แยก"
          m_taxbase = sumAmountWithVat - Me.DiscountWithVat
          m_taxbase -= Me.AdvancePayItemCollection.GetExcludeVATAmountForCalculate 'CDec(IIf(Me.AdvancePay.TaxType.Value = 2, Me.AdvancePay.GetRemainExcludeVatAmount(Me.AdvancePayAmount), 0))
        Case 2 '"รวม"
          Dim a As Decimal = Vat.GetExcludedVatAmount(sumAmountWithVat, Me.TaxRate)
          Dim b As Decimal = Vat.GetExcludedVatAmount(Me.DiscountWithVat, Me.TaxRate)
          m_taxbase = a - b
          m_taxbase -= Me.AdvancePayItemCollection.GetExcludeVATAmountForCalculate 'CDec(IIf(Me.AdvancePay.TaxType.Value = 2, Me.AdvancePay.GetRemainExcludeVatAmount(Me.AdvancePayAmount), 0))
      End Select
    End Sub
    Public ReadOnly Property DiscountWithVat() As Decimal
      Get
        If Me.Gross = 0 Then
          Return 0
        End If
        Return Configuration.Format(Me.DiscountAmount * Me.TaxGross / Me.Gross, DigitConfig.Price)
      End Get
    End Property
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim entId As Integer = Me.EntityId
      If Not Me.Asset Is Nothing AndAlso Me.Asset.Originated Then
        entId = 50
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", entId), New SqlParameter("@default", 1) _
      , New SqlParameter("@inventoryType", CInt(Configuration.GetConfig("CompanyInventoryMethod"))))
      If ds.Tables(0).Rows.Count > 0 Then
        Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
        Return glf
      End If
      Return New GLFormat
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem
      Dim tmp As Object = Configuration.GetConfig("APRetentionPoint")
      Dim apRetentionPoint As Integer = 0
      If IsNumeric(tmp) Then
        apRetentionPoint = CInt(tmp)
      End If
      Dim retentionHere As Boolean = (apRetentionPoint = 0)
      'ค่าใช้จ่ายซ่อม
      Dim i41 As Decimal = 0
      If Me.TaxType.Value = 2 Then
        i41 = Me.RealTaxBase
        i41 += Me.DiscountAmount
      Else
        i41 = Me.RealGross
      End If
      If i41 > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "I4.1"
        If retentionHere Then
          ji.Amount = i41 + Me.Retention
        Else
          ji.Amount = i41
        End If
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      'Retention
      If (Me.Payment.Amount - Me.Payment.Gross = 0 OrElse retentionHere) AndAlso Me.Retention > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.16"
        ji.Amount = Me.Retention
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.Note = Me.Recipient.Name
        jiColl.Add(ji)
      End If

      'ภาษีซื้อ
      If Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.5"
        ji.Amount = Configuration.Format(Me.Vat.Amount, DigitConfig.Price)
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.Note = Me.Recipient.Name
        jiColl.Add(ji)
        For Each vi As VatItem In Me.Vat.ItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "E3.5D"
          ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = vi.Code & "/" & vi.PrintName
          jiColl.Add(ji)

          ji = New JournalEntryItem
          ji.Mapping = "E3.5W"
          ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = vi.Code & "/" & vi.PrintName
          jiColl.Add(ji)

        Next

        ji = New JournalEntryItem
        ji.Mapping = "I4.2"
        ji.Amount = Configuration.Format(Me.Vat.Amount, DigitConfig.Price)
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)

        For Each vi As VatItem In Me.Vat.ItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "I4.2D"
          ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = vi.Code & "/" & vi.PrintName
          jiColl.Add(ji)

          ji = New JournalEntryItem
          ji.Mapping = "I4.2W"
          ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = vi.Code & "/" & vi.PrintName
          jiColl.Add(ji)

        Next

      End If

      'ภาษีซื้อไม่ถึงกำหนด
      If Me.RealTaxAmount - Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.5.1"
        ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)

        ji = New JournalEntryItem
        ji.Mapping = "I4.2.1"
        ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      'ภาษีหัก ณ ที่จ่าย
      If Not Me.WitholdingTaxCollection.IsBeforePay Then
        If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.15"
          ji.Amount = Me.WitholdingTaxCollection.Amount
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)

          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            ji = New JournalEntryItem
            ji.Mapping = "E3.15D"
            ji.Amount = wht.Amount
            If Me.ToCostCenter.Originated Then
              ji.CostCenter = Me.ToCostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = wht.PrintName & "(" & wht.Code & ")"
            jiColl.Add(ji)
          Next

          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            ji = New JournalEntryItem
            ji.Mapping = "E3.15W"
            ji.Amount = wht.Amount
            If Me.ToCostCenter.Originated Then
              ji.CostCenter = Me.ToCostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = wht.PrintName & "(" & wht.Code & ")"
            jiColl.Add(ji)
          Next

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
              If Me.ToCostCenter.Originated Then
                ji.CostCenter = Me.ToCostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              ji.Note = Me.Recipient.Name
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
              If Me.ToCostCenter.Originated Then
                ji.CostCenter = Me.ToCostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              ji.Note = Me.Recipient.Name
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
              If Me.ToCostCenter.Originated Then
                ji.CostCenter = Me.ToCostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              ji.Note = Me.Recipient.Name
              jiColl.Add(ji)
            End If
          Next
          ji = New JournalEntryItem
          ji.Mapping = "I4.4"
          ji.Amount = Me.WitholdingTaxCollection.Amount
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          jiColl.Add(ji)
          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            ji = New JournalEntryItem
            ji.Mapping = "I4.4D"
            ji.Amount = wht.Amount
            If Me.ToCostCenter.Originated Then
              ji.CostCenter = Me.ToCostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = wht.PrintName & "(" & wht.Code & ")"
            jiColl.Add(ji)
          Next

          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            ji = New JournalEntryItem
            ji.Mapping = "I4.4W"
            ji.Amount = wht.Amount
            If Me.ToCostCenter.Originated Then
              ji.CostCenter = Me.ToCostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = wht.PrintName & "(" & wht.Code & ")"
            jiColl.Add(ji)
          Next

        End If
      End If

      ''-------------------------------------HACK------------------------------------
      ''ส่วนลดการค้า
      'If Me.DiscountAmount > 0 Then
      'ji = New JournalEntryItem
      'ji.Mapping = "Through"
      'ji.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.TradeDiscount).Account
      'ji.Note = Me.StringParserService.Parse("${res:Global.TradeDiscount}")
      'ji.Amount = Me.DiscountAmount
      'If Me.ToCostCenter.Originated Then
      'ji.CostCenter = Me.ToCostCenter
      'Else
      'ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      'End If
      'jiColl.Add(ji)
      'End If
      ''-------------------------------------HACK------------------------------------

      'เงินมัดจำจ่ายล่วงหน้า
      If Me.AdvancePayItemCollection.GetExcludeVATAmount > 0 Then
        Dim pm110note As String = ""
        For Each avpi As AdvancePayItem In Me.AdvancePayItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "PM1.10D"
          ji.Amount = avpi.AdvancePay.GetRemainExcludeVatAmount(avpi.Amount)
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = avpi.AdvancePay.Code & "/" & Me.Recipient.Name
          jiColl.Add(ji)
          If pm110note = "" Then
            pm110note = "ตัดมัดจำของ " & Me.Recipient.Code & "(" & avpi.AdvancePay.Code & ")"

          Else
            pm110note = pm110note & "," & Me.Recipient.Code & "(" & avpi.AdvancePay.Code & ")"
          End If

        Next
        ji = New JournalEntryItem
        ji.Mapping = "PM1.10"
        ji.Amount = Me.AdvancePayItemCollection.GetExcludeVATAmount
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.Note = pm110note
        jiColl.Add(ji)
      End If

      If Not Me.Payment Is Nothing Then
        'ส่วนต่างระหว่างยอดจ่ายกับยอดจริง ---> เจ้าหนี้

        Dim pmGross As Decimal = 0


        pmGross = Me.Payment.Gross

        If Configuration.Compare(pmGross, Me.Payment.Amount) < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.8"

          If retentionHere Then
            ji.Amount = Me.Payment.Amount - pmGross
          Else
            ji.Amount = (Me.Payment.Amount + Me.Retention) - pmGross
          End If
          If Not Me.Supplier.Account Is Nothing AndAlso Me.Supplier.Account.Originated Then
            ji.Account = Me.Supplier.Account
          End If
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
        End If

        'ส่วนต่างระหว่างยอดจ่ายกับยอดจริง ---> เจ้าหนี้
        If Configuration.Compare(pmGross, Me.Payment.Amount) < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "I4.3"
          If retentionHere Then
            ji.Amount = Me.Payment.Amount - pmGross
          Else
            ji.Amount = (Me.Payment.Amount + Me.Retention) - pmGross
          End If
          If Not Me.Supplier.Account Is Nothing AndAlso Me.Supplier.Account.Originated Then
            ji.Account = Me.Supplier.Account
          End If
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          jiColl.Add(ji)
        End If

        jiColl.AddRange(Me.Payment.GetJournalEntries)
      End If
      jiColl.AddRange(Me.GetItemJournalEntries)
      jiColl.AddRange(Me.GetItemDetailJournalEntries)
      Return jiColl
    End Function
    Private Function ThereIsUnvatableItems() As Boolean
      For Each item As GoodsReceiptItem In Me.ItemCollection
        If item.UnVatable Then
          Return True
        End If
      Next
      Return False
    End Function
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      Dim ji As New JournalEntryItem
      Dim map As String = ""
      Dim withdrawAccount As Account

      Dim e31 As Integer = 0
      Dim e32 As Integer = 0
      Dim e33 As Integer = 0
      Dim e34 As Integer = 0

      Select Case Me.ToAccountType.Value
        Case 1 'WIP
          map = "F1.3"
          withdrawAccount = Me.ToCostCenter.WipAccount
        Case 2 'Exp
          map = "F1.2"
          withdrawAccount = Me.ToCostCenter.ExpenseAccount
      End Select
      For Each item As GoodsReceiptItem In Me.ItemCollection
        Dim itemType As Integer
        Dim blankMatched As Boolean = False
        Dim blankNoAcctMatched As Boolean = False
        Dim lciToolMatched As Boolean = False
        Dim lciToolNoAcctMatched As Boolean = False
        Dim assetMatched As Boolean = False
        Dim assetNoacctMatched As Boolean = False

        Dim withdrawMatched As Boolean = False
        Dim withdrawNoAcctMatched As Boolean = False
        Dim originMatched As Boolean = False

        Dim itemRemainAmount As Decimal

        If ThereIsUnvatableItems() Then
          Dim itemAmountPerGross As Decimal
          If Me.TaxGross = 0 Then
            itemAmountPerGross = 0
          Else
            itemAmountPerGross = item.Amount / Me.TaxGross
          End If
          itemRemainAmount = (Me.TaxGross - Me.RealTaxAmount) * itemAmountPerGross
        Else
          itemRemainAmount = item.TaxBase
        End If

        Dim itemAmount As Decimal ' = item.Amount

        'If Me.TaxType.Value = 2 Then
        'itemRemainAmount += (item.DiscountFromParent - Vat.GetExcludedVatAmount(item.DiscountFromParent, Me.TaxRate))
        'End If

        If Me.TaxType.Value = 1 Then    'แยก
          itemAmount = item.TaxBase 'item.Amount
        ElseIf Me.TaxType.Value = 0 Then 'ไม่มี,ไม่มีภาษี
          itemAmount = item.Amount - item.DiscountFromParent
        ElseIf Me.TaxType.Value = 2 Then 'รวม
          itemAmount = itemRemainAmount
        End If

        If item.UnVatable Then
          itemAmount = item.Amount - item.DiscountFromParent
        End If

        For Each addedJi As JournalEntryItem In jiColl
          If Not item.ItemType Is Nothing Then
            Select Case item.ItemType.Value
              Case 0, 88, 89 'Blank  
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "E3.4" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    blankMatched = True
                    e34 += 1
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "E3.4" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    blankNoAcctMatched = True
                    e34 += 1
                  End If
                End If
              Case 28  'Asset
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "E3.3" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    assetMatched = True
                    e33 += 1
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "E3.3" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    assetNoacctMatched = True
                    e33 += 1
                  End If
                End If
              Case 42 ' LCI
                Dim realAccount As Account
                Dim entityAcct As Account
                Dim lci As LCIItem = CType(item.Entity, LCIItem)
                If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                  entityAcct = lci.Account
                End If
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                ElseIf Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
                  'ใช้ acct ของ lci
                  realAccount = entityAcct
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id Then
                    If addedJi.Mapping = "E3.1" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += itemAmount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      lciToolMatched = True
                      e31 += 1
                    End If
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
                    If addedJi.Mapping = "E3.1" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += itemAmount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      lciToolNoAcctMatched = True
                      e31 += 1
                    End If
                  End If
                End If

                '*********************เบิก*****************************************************
                If Me.ToAccountType.Value = 1 Or Me.ToAccountType.Value = 2 Then
                  If Not withdrawAccount Is Nothing AndAlso withdrawAccount.Originated Then
                    If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = withdrawAccount.Id Then
                      If addedJi.Mapping = map Then
                        If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                          addedJi.Amount += itemAmount
                        Else
                          addedJi.Amount += itemRemainAmount
                        End If
                        withdrawMatched = True
                      End If

                      'ต้นทาง
                      If addedJi.Mapping = "F1.4" Then
                        If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                          addedJi.Amount += itemAmount
                        Else
                          addedJi.Amount += itemRemainAmount
                        End If
                        originMatched = True
                      End If
                    End If
                  ElseIf withdrawAccount Is Nothing OrElse Not withdrawAccount.Originated Then
                    If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
                      If addedJi.Mapping = map Then
                        If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                          addedJi.Amount += itemAmount
                        Else
                          addedJi.Amount += itemRemainAmount
                        End If
                        withdrawNoAcctMatched = True
                      End If

                      'ต้นทาง
                      If addedJi.Mapping = "F1.4" Then
                        If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                          addedJi.Amount += itemAmount
                        Else
                          addedJi.Amount += itemRemainAmount
                        End If
                        originMatched = True
                      End If
                    End If
                  End If
                End If
                '*********************เบิก*****************************************************

              Case 19 'Tool
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "E3.2" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    lciToolMatched = True
                    e32 += 1
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "E3.2" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    lciToolNoAcctMatched = True
                    e32 += 1
                  End If
                End If
            End Select
          End If
        Next
        If Not item.ItemType Is Nothing Then
          Select Case item.ItemType.Value
            Case 0, 88, 89 'Blank  
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not blankMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.4"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  ji.Account = realAccount
                  If Me.ToCostCenter.Originated Then
                    ji.CostCenter = Me.ToCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                  e34 += 1
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not blankNoAcctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.4"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  If Me.ToCostCenter.Originated Then
                    ji.CostCenter = Me.ToCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                  e34 += 1
                End If
              End If
            Case 28 'Asset
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not assetMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.3"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  ji.Account = realAccount
                  If Me.ToCostCenter.Originated Then
                    ji.CostCenter = Me.ToCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                  e33 += 1
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not assetNoacctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.3"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  If Me.ToCostCenter.Originated Then
                    ji.CostCenter = Me.ToCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                  e33 += 1
                End If
              End If
            Case 42 'LCI
              Dim realAccount As Account
              Dim entityAcct As Account
              Dim lci As LCIItem = CType(item.Entity, LCIItem)
              If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                entityAcct = lci.Account
              End If
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              ElseIf Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
                'ใช้ acct ของ lci
                realAccount = entityAcct
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not lciToolMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.1"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  ji.Account = realAccount
                  If Me.ToCostCenter.Originated Then
                    ji.CostCenter = Me.ToCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                  e31 += 1
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not lciToolNoAcctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.1"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  If Me.ToCostCenter.Originated Then
                    ji.CostCenter = Me.ToCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                  e31 += 1
                End If
              End If

              '*********************เบิก*****************************************************
              If Me.ToAccountType.Value = 1 Or Me.ToAccountType.Value = 2 Then
                If Not originMatched Then
                  'ฝั่งต้นทาง
                  ji = New JournalEntryItem
                  ji.Mapping = "F1.4"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  ji.Account = realAccount
                  ji.CostCenter = Me.ToCostCenter
                  jiColl.Add(ji)
                  'MessageBox.Show("here1:" & ji.Mapping)
                End If
                If Not withdrawAccount Is Nothing AndAlso withdrawAccount.Originated Then
                  If Not withdrawMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = map
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += itemAmount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.Account = withdrawAccount
                    ji.CostCenter = Me.ToCostCenter
                    jiColl.Add(ji)
                    'MessageBox.Show("here2:" & ji.Mapping)
                  End If
                ElseIf withdrawAccount Is Nothing OrElse Not withdrawAccount.Originated Then
                  If Not withdrawNoAcctMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = map
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += itemAmount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.CostCenter = Me.ToCostCenter
                    jiColl.Add(ji)
                    'MessageBox.Show("here3:" & ji.Mapping)
                  End If
                End If
              End If
              '*********************เบิก*****************************************************

            Case 19 'Tool
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not lciToolMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.2"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  ji.Account = realAccount
                  If Me.ToCostCenter.Originated Then
                    ji.CostCenter = Me.ToCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                  e32 += 1
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not lciToolNoAcctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.2"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  If Me.ToCostCenter.Originated Then
                    ji.CostCenter = Me.ToCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                  e32 += 1
                End If
              End If
          End Select
        End If

      Next

      For Each tmpJi As JournalEntryItem In jiColl
        Select Case tmpJi.Mapping
          Case "E3.1"
            tmpJi.Note = "วัสดุ " & e31 & " รายการ"
          Case "E3.2"
            tmpJi.Note = "เครื่องมือ/วัสดุสิ้นเปลือง " & e32 & " รายการ"
          Case "E3.3"
            tmpJi.Note = "สินทรัพย์ " & e33 & " รายการ"
          Case "E3.4"
            tmpJi.Note = "ค่าใช้จ่ายอื่นๆ " & e34 & " รายการ"
          Case "E3.5"
            tmpJi.Note = Me.Recipient.Name
        End Select
        tmpJi.Amount = Configuration.Format(tmpJi.Amount, DigitConfig.Price)
      Next
      Return jiColl
    End Function
    Private Function GetItemDetailJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      Dim map As String = ""
      Dim withdrawAccount As Account

      Select Case Me.ToAccountType.Value
        Case 1    'WIP
          map = "F1.3"
          withdrawAccount = Me.ToCostCenter.WipAccount
        Case 2    'Exp
          map = "F1.2"
          withdrawAccount = Me.ToCostCenter.ExpenseAccount
      End Select

      Dim ToCostCenter As CostCenter
      If Me.ToCostCenter.Originated Then
        ToCostCenter = Me.ToCostCenter
      Else
        ToCostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      If Me.ToAccountType.Value = 1 Or Me.ToAccountType.Value = 2 Then
        ToCostCenter = Me.ToCostCenter
      End If

      For Each item As GoodsReceiptItem In Me.ItemCollection
        Dim itemType As Integer
        Dim blankMatched As Boolean = False
        Dim blankNoAcctMatched As Boolean = False
        Dim lciToolMatched As Boolean = False
        Dim lciToolNoAcctMatched As Boolean = False
        Dim assetMatched As Boolean = False
        Dim assetNoacctMatched As Boolean = False

        Dim withdrawMatched As Boolean = False
        Dim withdrawNoAcctMatched As Boolean = False
        Dim originMatched As Boolean = False

        Dim itemRemainAmount As Decimal
        Dim itemAmount As Decimal

        If ThereIsUnvatableItems() Then
          Dim itemAmountPerGross As Decimal
          If Me.TaxGross = 0 Then
            itemAmountPerGross = 0
          Else
            itemAmountPerGross = item.Amount / Me.TaxGross
          End If
          itemRemainAmount = (Me.TaxGross - Me.RealTaxAmount) * itemAmountPerGross
        Else
          itemRemainAmount = item.TaxBase
        End If


        'If Me.TaxType.Value = 2 Then
        itemRemainAmount += (item.DiscountFromParent - Vat.GetExcludedVatAmount(item.DiscountFromParent, Me.TaxRate))
        'End If

        If Me.TaxType.Value = 1 Then    'แยก
          itemAmount = item.TaxBase 'item.Amount
        ElseIf Me.TaxType.Value = 0 Then 'ไม่มี,ไม่มีภาษี
          itemAmount = item.Amount - item.DiscountFromParent
        ElseIf Me.TaxType.Value = 2 Then 'รวม
          itemAmount = itemRemainAmount
        End If

        If item.UnVatable Then
          itemAmount = item.Amount - item.DiscountFromParent
        End If
        '------------------------------------------------------------
        If Not item.ItemType Is Nothing Then
          Select Case item.ItemType.Value
            Case 0, 88, 89      'Blank  
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not blankMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.4", realAccount, itemAmount, ToCostCenter)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not blankNoAcctMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.4", itemAmount, ToCostCenter)
                End If
              End If
            Case 28      'Asset
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not assetMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.3", realAccount, itemAmount, ToCostCenter)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not assetNoacctMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.3", itemAmount, ToCostCenter)
                End If
              End If
            Case 42      'LCI
              Dim realAccount As Account
              Dim entityAcct As Account
              Dim lci As LCIItem = CType(item.Entity, LCIItem)
              If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                entityAcct = lci.Account
              End If
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              ElseIf Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
                'ใช้ acct ของ lci
                realAccount = entityAcct
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not lciToolMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.1", realAccount, itemAmount, ToCostCenter)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not lciToolNoAcctMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.1", itemAmount, ToCostCenter)
                End If
              End If

              '*********************เบิก*****************************************************
              If Me.ToAccountType.Value = 1 Or Me.ToAccountType.Value = 2 Then
                If Not originMatched Then
                  'ฝั่งต้นทาง
                  SetJournalEntryItem(item, jiColl, "F1.4", realAccount, itemAmount, ToCostCenter)
                End If
                If Not withdrawAccount Is Nothing AndAlso withdrawAccount.Originated Then
                  If Not withdrawMatched Then
                    SetJournalEntryItem(item, jiColl, map, withdrawAccount, itemAmount, ToCostCenter)
                  End If
                ElseIf withdrawAccount Is Nothing OrElse Not withdrawAccount.Originated Then
                  If Not withdrawNoAcctMatched Then
                    SetJournalEntryItem(item, jiColl, map, itemAmount, ToCostCenter)
                  End If
                End If
              End If
              '*********************เบิก*****************************************************

            Case 19      'Tool
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not lciToolMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.2", realAccount, itemAmount, ToCostCenter)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not lciToolNoAcctMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.2", itemAmount, ToCostCenter)
                End If
              End If
          End Select
        End If

      Next

      For Each tmpJi As JournalEntryItem In jiColl
        tmpJi.Amount = Configuration.Format(tmpJi.Amount, DigitConfig.Price)
      Next
      Return jiColl
    End Function
    Private Sub SetJournalEntryItem(ByRef item As GoodsReceiptItem, ByRef jiColl As JournalEntryItemCollection, ByVal jiMap As String, ByRef jiAccount As Account, ByVal jiAmount As Decimal, ByRef jiCoscenter As CostCenter)
      Dim ji As JournalEntryItem
      Dim unitName As String = ""
      Dim itemname As String = ""
      If item.Unit Is Nothing Then
        unitName = ""
      Else
        unitName = " " & item.Unit.Name
      End If
      itemname = item.Entity.Name
      If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
        If item.Entity.Name <> item.EntityName Then
          itemname = item.EntityName & "<" & item.Entity.Name & ">"
        End If
      End If
      ji = New JournalEntryItem
      ji.Mapping = jiMap & "D"
      ji.Amount = jiAmount
      ji.Account = jiAccount
      ji.CostCenter = jiCoscenter
      ji.Note = itemname & "(" & Configuration.Format(item.Qty, DigitConfig.Qty) & unitName & ")"
      jiColl.Add(ji)
      If item.WBSDistributeCollection.Count > 0 Then
        For Each iwbs As WBSDistribute In item.WBSDistributeCollection
          ji = New JournalEntryItem
          ji.Mapping = jiMap & "W"
          ji.Amount = iwbs.Amount     'jiAmount
          ji.Account = jiAccount
          ji.CostCenter = iwbs.CostCenter 'jiCoscenter
          ji.Note = itemname & "(" & Configuration.Format(item.Qty * (iwbs.Percent / 100), DigitConfig.Qty) & unitName & ")" & " " & iwbs.CostCenter.Name & ":" & iwbs.WBS.Name
          jiColl.Add(ji)
        Next
      Else
        ji = New JournalEntryItem
        ji.Mapping = jiMap & "W"
        ji.Amount = jiAmount
        ji.Account = jiAccount
        ji.CostCenter = jiCoscenter
        ji.Note = itemname & "(" & Configuration.Format(item.Qty, DigitConfig.Qty) & unitName & ")" & " " & jiCoscenter.Name
        jiColl.Add(ji)
      End If
    End Sub
    Private Sub SetJournalEntryItem(ByRef item As GoodsReceiptItem, ByRef jiColl As JournalEntryItemCollection, ByVal jiMap As String, ByVal jiAmount As Decimal, ByRef jiCoscenter As CostCenter)
      Dim ji As JournalEntryItem
      Dim unitName As String = ""
      Dim itemname As String = ""
      If item.Unit Is Nothing Then
        unitName = ""
      Else
        unitName = " " & item.Unit.Name
      End If
      itemname = item.Entity.Name
      If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
        If item.Entity.Name <> item.EntityName Then
          itemname = item.EntityName & "<" & item.Entity.Name & ">"
        End If
      End If
      ji = New JournalEntryItem
      ji.Mapping = jiMap & "D"
      ji.Amount = jiAmount
      ji.CostCenter = jiCoscenter
      ji.Note = itemname & "(" & Configuration.Format(item.Qty, DigitConfig.Qty) & unitName & ")"
      jiColl.Add(ji)
      If item.WBSDistributeCollection.Count > 0 Then
        For Each iwbs As WBSDistribute In item.WBSDistributeCollection
          ji = New JournalEntryItem
          ji.Mapping = jiMap & "W"
          ji.Amount = iwbs.Amount     'jiAmount
          ji.CostCenter = iwbs.CostCenter   'jiCoscenter
          ji.Note = itemname & "(" & Configuration.Format(item.Qty * (iwbs.Percent / 100), DigitConfig.Qty) & unitName & ")" & " " & iwbs.CostCenter.Name & ":" & iwbs.WBS.Name
          jiColl.Add(ji)
        Next
      Else
        ji = New JournalEntryItem
        ji.Mapping = jiMap & "W"
        ji.Amount = jiAmount
        ji.CostCenter = jiCoscenter
        ji.Note = itemname & "(" & Configuration.Format(item.Qty, DigitConfig.Qty) & unitName & ")" & " " & jiCoscenter.Name
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
    Public Function GetMaximumTaxBase() As Decimal Implements IVatable.GetMaximumTaxBase
      'Todo: ต้อง refresh หรือเปล่า?
      Return Me.RealTaxBase
    End Function
    Public Property Person() As IBillablePerson Implements IVatable.Person, IWitholdingTaxable.Person
      Get
        Return Me.Supplier
      End Get
      Set(ByVal Value As IBillablePerson)
        Me.Supplier = CType(Value, Supplier)
      End Set
    End Property
    Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax
      Return Me.AfterTax
    End Function
    Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax
      Return Me.BeforeTax
    End Function
    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        Return Me.TaxType.Value = 0
      End Get
    End Property
#End Region

#Region "IWitholdingTaxable"
    Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return Me.RealTaxBase
    End Function
#End Region

#Region "IBillAcceptable"
    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      'If Not Me.NoItem Then
      RefreshTaxBase()
      'End If
      Return Me.AfterTax
    End Function
    Public Property DueDate() As Date Implements IPayable.DueDate
      Get
        Try
          Return Me.DocDate.AddDays(Me.CreditPeriod)
        Catch ex As Exception
          Return Me.DocDate
        End Try
      End Get
      Set(ByVal Value As Date)
        Try
          m_creditPeriod = DateDiff(DateInterval.Day, DocDate, Value)
        Catch ex As Exception

        End Try
      End Set
    End Property
    Public Property Payment() As Payment Implements IPayable.Payment
      Get
        Return m_payment
      End Get
      Set(ByVal Value As Payment)
        m_payment = Value
      End Set
    End Property
    Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount
      'Undone
      Return AmountToPay()
    End Function
    Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
      Get
        Return Me.Supplier
      End Get
    End Property
    Public Function GetRemainingAmountWithBillAcceptance(ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountWithBillAcceptance
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@billai_billa", billa_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer, ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                , New SqlParameter("@billai_billa", billa_id) _
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

    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\DO.dfm"
    End Function

    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

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

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'VatCode
      dpi = New DocPrintingItem
      dpi.Mapping = "VatCode"
      dpi.Value = Me.Vat.GetVatItemCodes
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'VatDocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "VatDocDate"
      dpi.Value = Me.Vat.GetVatItemDates
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DeliveryDocCode
      dpi = New DocPrintingItem
      dpi.Mapping = "DeliveryDocCode"
      dpi.Value = Me.DeliveryDocCode
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DeliveryDocDate
      If Not Me.DeliveryDocDate = Date.MinValue Then
        dpi = New DocPrintingItem
        dpi.Mapping = "DeliveryDocDate"
        dpi.Value = Me.DeliveryDocDate.ToShortDateString
        dpi.DataType = "System.DateTime"
        dpiColl.Add(dpi)
      End If

      'ToAccountType
      dpi = New DocPrintingItem
      dpi.Mapping = "ToAccountType"
      dpi.Value = Me.ToAccountType.Description
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Not Payment Is Nothing Then
        'Payment Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "PaymentAmount"
        dpi.Value = Configuration.FormatToString(Payment.Amount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Payment Gross
        dpi = New DocPrintingItem
        dpi.Mapping = "PaymentGross"
        dpi.Value = Configuration.FormatToString(Payment.Gross, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Po Is Nothing AndAlso Me.Po.Originated Then
        'POCode
        dpi = New DocPrintingItem
        dpi.Mapping = "POCode"
        dpi.Value = Me.Po.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'PODocDate
        dpi = New DocPrintingItem
        dpi.Mapping = "PODocDate"
        dpi.Value = Me.Po.DocDate.ToShortDateString
        dpi.DataType = "System.DateTime"
        dpiColl.Add(dpi)

        'PRCode
        dpi = New DocPrintingItem
        dpi.Mapping = "PRCode"
        dpi.Value = Me.m_prcode
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      Else
        'POCode
        dpi = New DocPrintingItem
        dpi.Mapping = "POCode"
        dpi.Value = ""
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'PODocDate
        dpi = New DocPrintingItem
        dpi.Mapping = "PODocDate"
        dpi.Value = ""
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'PRCode
        dpi = New DocPrintingItem
        dpi.Mapping = "PRCode"
        dpi.Value = ""
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Supplier Is Nothing AndAlso Me.Supplier.Originated Then
        'SupplierInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierInfo"
        dpi.Value = Me.Supplier.Code & ":" & Me.Supplier.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierCode"
        dpi.Value = Me.Supplier.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierName
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierName"
        dpi.Value = Me.Supplier.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierPhone"
        dpi.Value = Me.Supplier.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierFax
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierFax"
        dpi.Value = Me.Supplier.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierContact
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierContact"
        dpi.Value = Me.Supplier.Contact
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierAddress"
        dpi.Value = Me.Supplier.BillingAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierCurrentAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierCurrentAddress"
        dpi.Value = Me.Supplier.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierNote
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierNote"
        dpi.Value = Me.Supplier.Note
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.ToCostCenter Is Nothing AndAlso Me.ToCostCenter.Originated Then
        'CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.ToCostCenter.Code & ":" & Me.ToCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.ToCostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.ToCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterPhone"
        dpi.Value = Me.ToCostCenter.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterFax
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterFax"
        dpi.Value = Me.ToCostCenter.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.ToCostCenterPerson Is Nothing AndAlso Me.ToCostCenterPerson.Originated Then
        'ReceivePersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePersonInfo"
        dpi.Value = Me.ToCostCenterPerson.Code & ":" & Me.ToCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReceivePersonCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePersonCode"
        dpi.Value = Me.ToCostCenterPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReceivePersonName
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePersonName"
        dpi.Value = Me.ToCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CreditPeriod
      dpi = New DocPrintingItem
      dpi.Mapping = "CreditPeriod"
      dpi.Value = Configuration.FormatToString(Me.CreditPeriod, DigitConfig.Int)
      dpi.DataType = "System.Int32"
      dpiColl.Add(dpi)

      'Gross (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.RealGross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'DiscountRate (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountRate"
      dpi.Value = Me.Discount.Rate
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscountRate
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvancePay"
      dpi.Value = Configuration.FormatToString(Me.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxBase
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxBase"
      dpi.Value = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'DiscountAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)



      'AfterDiscountAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterDiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.RealGross - Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AdvanceAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceAmount"
      If Me.TaxType.Value = 0 OrElse Me.TaxType.Value = 1 Then
        dpi.Value = Configuration.FormatToString(Me.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
      End If
      'dpi.Value = Configuration.FormatToString(Me.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)


      'AfterAdvanceAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterAdvanceAmount"
      If Me.TaxType.Value = 0 OrElse Me.TaxType.Value = 1 Then
        dpi.Value = Configuration.FormatToString((Me.RealGross - Me.DiscountAmount) - Me.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString((Me.RealGross - Me.DiscountAmount) - Me.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
      End If
      'dpi.Value = Configuration.FormatToString((Me.RealGross - Me.DiscountAmount) - Me.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)


      'Retention
      dpi = New DocPrintingItem
      dpi.Mapping = "Retention"
      dpi.Value = Configuration.FormatToString(Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AfterRetentionAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterRetentionAmount"
      If Me.TaxType.Value = 0 OrElse Me.TaxType.Value = 1 Then
        dpi.Value = Configuration.FormatToString(((Me.RealGross - Me.DiscountAmount) - Me.AdvancePayItemCollection.GetExcludeVATAmount) - Me.Retention, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(((Me.RealGross - Me.DiscountAmount) - Me.AdvancePayItemCollection.GetAmount) - Me.Retention, DigitConfig.Price)
      End If
      'dpi.Value = Configuration.FormatToString(((Me.RealGross - Me.DiscountAmount) - Me.AdvancePayItemCollection.GetAmount) - Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)



      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      dpi.Value = Configuration.FormatToString(Me.RealTaxAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      '*************************************LastPage********************************
      'LastPageGross
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageGross"
      dpi.Value = Configuration.FormatToString(Me.RealGross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageDiscountRate
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageDiscountRate"
      dpi.Value = Me.Discount.Rate
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageDiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageDiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageDiscountRate
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageAdvancePay"
      If Me.TaxType.Value = 0 OrElse Me.TaxType.Value = 1 Then
        dpi.Value = Configuration.FormatToString(Me.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
      End If
      'dpi.Value = Configuration.FormatToString(Me.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageBeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageBeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageTaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageTaxAmount"
      dpi.Value = Configuration.FormatToString(Me.RealTaxAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageAfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageAfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageAfterTaxText
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageAfterTaxText"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.CurrencyText)
      dpi.DataType = "System.Decimal"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      '*************************************LastPage********************************

      'ItemString
      dpi = New DocPrintingItem
      dpi.Mapping = "ItemString"
      dpi.Value = Me.GetItemsString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim n As Integer = 0
      Dim line As Integer = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection
        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
          line += 1
          'Item.LineNumber
          '************** เอามาไว้เป็นอันที่ 2
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = line
          dpi.DataType = "System.Int32"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.UnitCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitCode"
          dpi.Value = item.Unit.Code
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit"
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.UnitInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitInfo"
          dpi.Value = item.Unit.Code & ":" & item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Qty"
          dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.DiscountRate
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.DiscountRate"
          dpi.Value = item.Discount.Rate
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.DiscountAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.DiscountAmount"
          If item.Discount.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.Price)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ZeroVat
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ZeroVat"
          dpi.Value = item.UnVatable
          dpi.DataType = "System.Boolean"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        End If

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        '--------------------- WBS Section ------------------
        Dim WBSCCCode As String = ""
        Dim WBSCCName As String = ""
        Dim WBSCCInfo As String = ""
        Dim WBSCode As String = ""
        Dim WBSCodePercent As String = ""
        Dim WBSCodeAmount As String = ""
        Dim WBSRemainAmount As String = ""
        Dim WBSRemainQty As String = ""
        If item.WBSDistributeCollection.Count > 0 Then
          'Populate ให้คำนวณคงเหลือแบบหลอกๆ
          'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
          If item.WBSDistributeCollection.Count = 1 Then
            WBSCCCode = item.WBSDistributeCollection.Item(0).CostCenter.Code
            WBSCCName = item.WBSDistributeCollection.Item(0).CostCenter.Name
            WBSCCInfo = item.WBSDistributeCollection.Item(0).CostCenter.Code & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Name
            WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
            WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
            WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price) & ")"
            WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
            WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
          Else
            Dim i As Integer
            For i = 0 To item.WBSDistributeCollection.Count - 1
              WBSCCCode &= item.WBSDistributeCollection.Item(i).CostCenter.Code
              WBSCCName &= item.WBSDistributeCollection.Item(i).CostCenter.Name
              WBSCCInfo &= item.WBSDistributeCollection.Item(i).CostCenter.Code & ":" & item.WBSDistributeCollection.Item(i).CostCenter.Name
              WBSCode &= item.WBSDistributeCollection.Item(i).WBS.Code
              WBSCodePercent &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Percent, DigitConfig.Price) & "%)"
              WBSCodeAmount &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Amount, DigitConfig.Price) & ")"
              WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).BudgetRemain, DigitConfig.Price)
              WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).QtyRemain, DigitConfig.Price)
              If i < item.WBSDistributeCollection.Count - 1 Then
                WBSCCCode &= ", "
                WBSCCName &= ", "
                WBSCCInfo &= ", "
                WBSCode &= ", "
                WBSCodePercent &= ", "
                WBSCodeAmount &= ", "
                WBSRemainAmount &= ", "
                WBSRemainQty &= ", "
              End If
            Next
          End If
        End If

        'Item.WBSCCCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCCCode"
        dpi.Value = WBSCCCode
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCCName
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCCName"
        dpi.Value = WBSCCName
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCCInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCCInfo"
        dpi.Value = WBSCCInfo
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCode"
        dpi.Value = WBSCode
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCodePercent
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCodePercent"
        dpi.Value = WBSCodePercent
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCodeAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCodeAmount"
        dpi.Value = WBSCodeAmount
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSRemainAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSRemainAmount"
        dpi.Value = WBSRemainAmount
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSRemainQty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSRemainQty"
        dpi.Value = WBSRemainQty
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        '--------------------- WBS Section ------------------

        'Item.Quality
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Quality"
        dpi.Value = item.Quality
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.AccountCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.AccountCode"
        If Not item.Account Is Nothing Then
          dpi.Value = item.Account.Code
        Else
          dpi.Value = ""
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.AccountName
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.AccountName"
        If Not item.Account Is Nothing Then
          dpi.Value = item.Account.Name
        Else
          dpi.Value = ""
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.UnVatable
        If item.UnVatable = True Then
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnVatable"
          dpi.Value = ""
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        End If
        n += 1
      Next

      n = 0
      Dim whtAmount As Decimal = 0
      For Each col As WitholdingTax In Me.m_whtcol
        For Each item As TreeRow In col.ItemTable.Childs
          If Not item.IsNull("whti_type") Then

            'WHTItem.WHTDate
            dpi = New DocPrintingItem
            dpi.Mapping = "WHTItem.WHTDate"
            dpi.Value = col.DocDate.ToShortDateString
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "WHTItem"
            dpiColl.Add(dpi)

            'WHTItem.WHTCode
            dpi = New DocPrintingItem
            dpi.Mapping = "WHTItem.WHTCode"
            dpi.Value = col.Code
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "WHTItem"
            dpiColl.Add(dpi)

            'WHTItem.WHTType
            dpi = New DocPrintingItem
            dpi.Mapping = "WHTItem.WHTType"
            dpi.Value = CodeDescription.GetDescription("whti_type", CInt(item("whti_type")))
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "WHTItem"
            dpiColl.Add(dpi)

            'WHTItem.WHTDescription
            dpi = New DocPrintingItem
            dpi.Mapping = "WHTItem.WHTDescription"
            dpi.Value = item("whti_description")
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "WHTItem"
            dpiColl.Add(dpi)

            'WHTItem.WHTTaxBase
            dpi = New DocPrintingItem
            dpi.Mapping = "WHTItem.WHTTaxBase"
            dpi.Value = item("whti_taxbase")
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "WHTItem"
            dpiColl.Add(dpi)

            'WHTItem.WHTTaxRate
            dpi = New DocPrintingItem
            dpi.Mapping = "WHTItem.WHTTaxRate"
            dpi.Value = item("whti_taxrate")
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "WHTItem"
            dpiColl.Add(dpi)

            'WHTItem.WHTAmount
            dpi = New DocPrintingItem
            dpi.Mapping = "WHTItem.WHTAmount"
            dpi.Value = item("Amount")
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "WHTItem"
            dpiColl.Add(dpi)

            If IsNumeric(item("Amount")) Then
              whtAmount += CDec(item("Amount"))
            End If

            n += 1
          End If
        Next
      Next

      'WHTItem.WHTTotalAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "WHTTotalAmount"
      dpi.Value = Configuration.FormatToString(whtAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "WHTItem"
      dpiColl.Add(dpi)


      Return dpiColl
    End Function

    Public Function GetItemsString() As String
      Dim ret As String = ""
      For Each item As GoodsReceiptItem In Me.ItemCollection
        Dim entityName As String
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          entityName = item.EntityName
        Else
          entityName = item.Entity.Name
        End If
        Dim unitName As String = item.Unit.Name
        Dim qtyString As String = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
        Dim priceString As String = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
        ret &= entityName & " จำนวน " & qtyString & " @ " & priceString & " " & unitName
        ret &= ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function

#End Region

#Region " IApprovAble "
    Public Function ApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.ApproveData
      'เปลี่ยนไปใช้ Trigger แทน
      Return New SaveErrorException("0")

      With Me
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", DocID))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approveperson", currentUserId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approvedate", theTime))

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        ' ให้ Transaction ควบคุมที่ส่วนของ Client เพราะอาจมีหลาย loop ได้
        Try
          SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Approve" & Me.ClassName, sqlparams)
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.ToCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.ToCostCenter = Value
      End Set
    End Property
    Public ReadOnly Property IsApproved() As Boolean Implements IApprovAble.IsApproved
      Get
        If Not (Me.ApprovePerson Is Nothing) AndAlso Me.ApprovePerson.Originated Then
          Return True
        End If
        Return False
      End Get
    End Property

    Public ReadOnly Property ApproveIcon() As String Implements IApprovAble.ApproveIcon
      Get

      End Get
    End Property

    Public ReadOnly Property ShowUnApproveButton() As Boolean Implements IApprovAble.ShowUnApproveButton
      Get

      End Get
    End Property

    Public Function UnApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.UnApproveData

    End Function

    Public ReadOnly Property UnApproveIcon() As String Implements IApprovAble.UnApproveIcon
      Get

      End Get
    End Property
#End Region

    Public Overrides ReadOnly Property Columns() As ColumnCollection
      Get
        If m_columns Is Nothing OrElse m_columns.Count <= 0 Then
          m_columns = New ColumnCollection(Me.ClassName, 0)
        End If
        Return m_columns
      End Get
    End Property

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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteGoodsReceipt}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        For Each extender As Object In Me.Extenders
          If TypeOf extender Is IExtender Then
            Dim delDocError As SaveErrorException = CType(extender, IExtender).Delete(conn, trans)
            If Not IsNumeric(delDocError.Message) Then
              trans.Rollback()
              Return delDocError
            Else
              Select Case CInt(delDocError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Return delDocError
                Case Else
              End Select
            End If
          End If
        Next

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteGoodsReceipt", New SqlParameter() {New SqlParameter("@stock_id", Me.Id), returnVal})
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePaymentItemEntityStatus", New SqlParameter("@payment_id", Me.Payment.Id))
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.GoodsReceiptIsReferencedCannotBeDeleted}")
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

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
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
        Return Me.Supplier
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Supplier Then
          Me.Supplier = CType(Value, Supplier)
        End If
      End Set
    End Property
#End Region


  End Class

  Public Class GoodsReceiptForApprove
    Inherits GoodsReceipt
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "GoodsReceiptForApprove"
      End Get
    End Property
  End Class
  Public Class GoodsReceiptForOperation
    Inherits GoodsReceipt
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "GoodsReceiptForOperation"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.GoodsReceiptForOperation.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.GoodsReceiptForOperation"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.GoodsReceiptForOperation"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.GoodsReceiptForOperation.ListLabel}"
      End Get
    End Property
  End Class
  Public Class GoodsReceiptNoItem
    Inherits GoodsReceipt
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "GoodsReceiptNoItem"
      End Get
    End Property
    Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldPOItemStatus", New SqlParameter("@stock_id", Me.Id))
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSMarkupStatusB4GRSave", New SqlParameter("@stock_id", Me.Id))
    End Sub
    Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewPOItemStatus", New SqlParameter("@stock_id", Me.Id))
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSMarkupStatusAfterGRSave", New SqlParameter("@stock_id", Me.Id))
    End Sub
  End Class
End Namespace

