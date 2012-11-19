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
Imports System.Threading.Tasks

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
    , IUnlockAble, IGLCheckingBeforeRefresh, IWBSAllocatable, IDuplicable, IAbleHideCostByView, IHasCurrency _
    , ICloseStatusAble, IApproveStatusAble, IShowStatusColorAble, INewGLAble, INewPrintableEntity, IDocStatus _
    , IDocumentPersonAble

#Region "Members"
    Private m_supplier As Supplier
    Private m_deliveryPerson As String

    Private m_docDate As Date
    Private m_olddocDate As Date

    Private m_toCostCenter As CostCenter
    Private m_toCostCenterPerson As Employee

    Private m_deliveryDocCode As String
    Private m_deliveryDocDate As Date

    Private m_po As PO
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
    Private m_oldActualDataSet As DataSet

    Private m_approveDocColl As ApproveDocCollection

    Private m_asset As Asset
    Private m_Unlock As UnlockType

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
        .m_po = New PO
        .m_supplier = New Supplier
        .m_creditPeriod = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_discount = New Discount("")
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        .m_docDate = Now.Date
        .m_olddocDate = Now.Date
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
      m_oldActualDataSet = New DataSet
      m_approveDocColl = New ApproveDocCollection(Me)
      m_Unlock = UnlockType.Non
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
            .m_po = New PO
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
            .m_po = New PO
            .m_po.Id = CInt(dr(aliasPrefix & "stock_refdoc"))
          End If
        End If

        If dr.Table.Columns.Contains("stock_pvrv") AndAlso Not dr.IsNull(aliasPrefix & "stock_pvrv") Then
          .PVRVCODE = CStr(dr(aliasPrefix & "stock_pvrv"))
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
            .m_toCostCenterPerson = Employee.GetEmployeeById(CInt(dr(aliasPrefix & "stock_toccperson")))
            '.m_toCostCenterPerson = New Employee(CInt(dr(aliasPrefix & "stock_toccperson")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "cc_id") Then
          If Not dr.IsNull(aliasPrefix & "cc_id") Then
            .m_toCostCenter = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "cc_id")))
            '.m_toCostCenter = New CostCenter(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains("stock_tocc") AndAlso Not dr.IsNull(aliasPrefix & "stock_tocc") Then
            .m_toCostCenter = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "stock_tocc")))
            '.m_toCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_tocc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stock_tag") AndAlso Not dr.IsNull(aliasPrefix & "stock_tag") Then
          Me.m_toAcctType.Value = CInt(dr(aliasPrefix & "stock_tag"))
        End If

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
          .m_olddocDate = CDate(dr(aliasPrefix & "stock_docDate"))
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

        '.m_vat = New Vat(Me)
        'm_vat.Direction.Value = 1

        ''.m_wht = New WitholdingTax(Me)
        ''.m_wht.Direction.Value = 1

        '.m_whtcol = New WitholdingTaxCollection(Me)
        '.m_whtcol.Direction = New WitholdingTaxDirection(1)

        '.m_payment = New Payment(Me)

        '.m_je = New JournalEntry(Me)

        '.m_advancePayItemColl = New AdvancePayItemCollection(Me)
        '.m_advancePayItemColl = New AdvancePayItemCollection(Me.Id, Me.EntityId)

        If dr.Table.Columns.Contains("stock_asset") AndAlso Not dr.IsNull(aliasPrefix & "stock_asset") Then
          .m_asset = New Asset(CInt(dr(aliasPrefix & "stock_asset")))
        End If
      End With

      MatActualHash = New Hashtable
      LabActualHash = New Hashtable
      EQActualHash = New Hashtable

      Parallel.Invoke(Sub()
                        m_vat = New Vat(Me)
                        m_vat.Direction.Value = 1
                      End Sub,
                      Sub()
                        m_whtcol = New WitholdingTaxCollection(Me)
                        m_whtcol.Direction = New WitholdingTaxDirection(1)
                      End Sub,
                      Sub()
                        m_payment = New Payment(Me)
                      End Sub,
                      Sub()
                        m_je = New JournalEntry(Me)
                      End Sub,
                      Sub()
                        m_advancePayItemColl = New AdvancePayItemCollection(Me.Id, Me.EntityId)
                      End Sub,
                      Sub()

                      End Sub,
                      Sub()
                        m_itemCollection = New GoodsReceiptItemCollection(Me)
                      End Sub,
                      Sub()
                        m_oldActualDataSet = Me.GetOldGRWBSActual
                      End Sub,
                      Sub()
                        m_approveDocColl = New ApproveDocCollection(Me)
                      End Sub,
                      Sub()
                        Me.AutoCodeFormat = New AutoCodeFormat(Me)
                      End Sub)

      ''==============CURRENCY=================================
      'BusinessLogic.Currency.SetCurrencyFromDB(Me)
      ''==============CURRENCY=================================
      m_Unlock = UnlockType.Non

      If poIdArrayList Is Nothing Then
        poIdArrayList = New ArrayList
        poIdArrayList.Add(Me.Po.Id)
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property ApproveDocColl As ApproveDocCollection
      Get
        Return m_approveDocColl
      End Get
      Set(ByVal value As ApproveDocCollection)
        '
      End Set
    End Property
    Public Property TaxBaseDeductedWithoutThisRefDoc As Decimal
    Public Property ViewName As String
    Public ReadOnly Property HideCost As Boolean Implements IAbleHideCostByView.HideCost
      Get
        If Not Me.ViewName Is Nothing Then
          If Me.ViewName.ToLower = "GoodsReceiptForOperationDetail".ToLower Then
            Return True
          End If
        End If

        Return False
      End Get
    End Property
    Public Property DocType As String = ""
    Public Property PVRVCODE As String
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
    Public Property Supplier() As Supplier Implements IAdvancePayItemAble.Supplier, IWBSAllocatable.Supplier
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
    Public Property DocDate() As Date Implements IVatable.Date, IWitholdingTaxable.Date, IPayable.Date, IGLAble.Date, _
                                                 IAdvancePayItemAble.DocDate, ICheckPeriod.DocDate, IWBSAllocatable.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        Me.m_je.DocDate = Value
        Me.Vat.SubmitalDate = Value
      End Set
    End Property
    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocDate
      End Get
    End Property
    Public Property ToCostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter
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
        RefreshWBSAndChangePo()
        OnGlChanged()
      End Set
    End Property
    Private m_forceupdateGross As Boolean = False
    Public Property forceUpdateGross As Boolean
      Get
        Return m_forceupdateGross
      End Get
      Set(ByVal value As Boolean)
        m_forceupdateGross = value
      End Set
    End Property
    Private Sub RefreshWBSAndChangePo()
      For Each item As GoodsReceiptItem In Me.ItemCollection
        RemoveHandler item.WBSDistributeCollection.PropertyChanged, AddressOf item.WBSChangedHandler
        AddHandler item.WBSDistributeCollection.PropertyChanged, AddressOf item.WBSChangedHandler
        For Each wbsd As WBSDistribute In item.WBSDistributeCollection
          Dim oldwbs As New WBS(wbsd.WBS.Id)
          wbsd.WBS = New WBS
          wbsd.WBS = oldwbs

          wbsd.BaseCost = item.Cost
        Next
      Next

      'For Each item As GoodsReceiptItem In arr

      '  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
      '    wbsd.BaseCost = item.Cost
      '    'wbsd.TransferBaseCost = item.Cost
      '    'Me.SetActual(wbsd.WBS, 0, item.Cost * wbsd.Percent / 100, item.ItemType.Value)
      '    'Me.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, item.ItemType.Value)
      '  Next
      'Next
    End Sub
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

        '==============CURRENCY=================================
        Me.Currency = m_po.Currency.Clone
        '==============CURRENCY=================================

        Me.Supplier = Me.m_po.Supplier
        Me.CreditPeriod = Me.m_po.CreditPeriod
        Me.TaxType = Me.m_po.TaxType
        Me.TaxRate = Me.Po.TaxRate
        Me.ToCostCenter = Me.m_po.CostCenter
        'Me.Discount = Me.m_po.Discount
        Me.Discount = Me.m_po.RemainningDiscount
        Me.Retention = Math.Max(Me.m_po.Retention - Me.m_po.GetRetentionDeductedWithoutThisStock(Me.Id), 0)
        Dim oldTable As DataTable = Me.GetOldItemTable(Me.m_po)
        Dim itemsTryToAdd As New List(Of POItem)
        Dim itemsToAdd As New List(Of POItem)
        For Each newPoitem As POItem In Me.m_po.ItemCollection
          For Each row As DataRow In oldTable.Rows
            If CInt(row("poi_linenumber")) = newPoitem.LineNumber Then
              newPoitem.ReceivedQty = CDec(row("poi_receivedqty"))
              Exit For
            End If
          Next
          If newPoitem.ItemType.Value = 160 OrElse newPoitem.ItemType.Value = 162 OrElse newPoitem.ReceivedQty * newPoitem.Conversion < newPoitem.StockQty Then
            itemsTryToAdd.Add(newPoitem)
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
          End If
        Next
        Dim hasRealItem As Boolean = False
        For Each newPOitem As POItem In itemsTryToAdd
          If newPOitem.ItemType.Value <> 160 AndAlso newPOitem.ItemType.Value <> 162 AndAlso newPOitem.ReceivedQty * newPOitem.Conversion < newPOitem.StockQty Then
            hasRealItem = True
          End If
        Next
        If hasRealItem Then
          For Each newPOitem As POItem In itemsTryToAdd
            itemsToAdd.Add(newPOitem)
          Next
        End If
        For Each newPOitem As POItem In itemsToAdd
          Dim item As New GoodsReceiptItem

          item.CopyFromPOItem(newPOitem)
          Me.ItemCollection.Add(item)
          arr.Add(item)
        Next
        If itemsToAdd.Count = 0 Then

          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ThisPOIsClosed}", New String() {m_po.Code})
          m_po = Nothing
        End If
        Me.RefreshTaxBase()
        'For Each item As GoodsReceiptItem In arr

        '  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
        '    wbsd.BaseCost = item.Cost
        '    'wbsd.TransferBaseCost = item.Cost
        '    'Me.SetActual(wbsd.WBS, 0, item.Cost * wbsd.Percent / 100, item.ItemType.Value)
        '    'Me.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, item.ItemType.Value)
        '  Next
        'Next
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
        If forceUpdateGross Then
          Me.RealGross = Me.Gross
        End If
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
            Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetExcludeVATAmount - Me.Retention
          Case 1 '"แยก"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetExcludeVATAmount - Me.Retention
          Case 2 '"รวม"
            Return Me.AfterTax - Me.RealTaxAmount
            'Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetAmount - Me.Retention 'Me.AfterTax - Me.RealTaxAmount
        End Select
      End Get
    End Property
    Public ReadOnly Property AfterTax() As Decimal Implements IApprovAble.AmountToApprove
      Get   'ยอด before tax มันเอา Retention ออกแล้ว
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.BeforeTax '- Me.Retention
          Case 1 '"แยก"
            Return Me.BeforeTax + Me.RealTaxAmount '- Me.Retention
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

    Public Property Unlock() As UnlockType Implements IUnlockAble.Unlock
      Get
        Return m_Unlock
      End Get
      Set(ByVal Value As UnlockType)
        m_Unlock = Value
      End Set
    End Property
    Public Property Locking As Boolean
    Public Overrides ReadOnly Property Columns() As ColumnCollection
      Get
        If m_columns Is Nothing OrElse m_columns.Count <= 0 Then
          m_columns = New ColumnCollection(Me.ClassName, 0)
        End If
        Return m_columns
      End Get
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
    Public Sub RefreshApproveDocCollection() Implements IApproveStatusAble.RefreshApproveDocCollection
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Public Function GetOldGRWBSActual() As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString,
                                                   CommandType.StoredProcedure,
                                                   "GetOldGRWBSActual",
                                                   New SqlParameter("@stock_id", Me.Id)
                                                  )
      Return ds
    End Function
    Private Function GetGRCommandActual() As String
      If Me.m_oldActualDataSet Is Nothing OrElse Me.m_oldActualDataSet.Tables.Count = 0 OrElse Me.m_oldActualDataSet.Tables(0).Rows.Count = 0 Then
        Return ""
      End If
      Dim cmd As String = ""
      Dim cmdList As New ArrayList
      For Each row As DataRow In Me.m_oldActualDataSet.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        cmd = ""
        cmd = "" & _
        " update swang_gr_wbsactual " & _
        " set wbs_matactual = isnull(wbs_matactual,0) - " & drh.GetValue(Of Decimal)("wbsmatactual").ToString() & "" & _
        " ,wbs_labactual = isnull(wbs_labactual,0) - " & drh.GetValue(Of Decimal)("wbslabactual").ToString() & "" & _
        " ,wbs_eqactual = isnull(wbs_eqactual,0) - " & drh.GetValue(Of Decimal)("wbseqactual").ToString() & "" & _
        " ,nonref_matactual = isnull(nonref_matactual,0) - " & drh.GetValue(Of Decimal)("nonrefmatactual").ToString() & "" & _
        " ,nonref_labactual = isnull(nonref_labactual,0) - " & drh.GetValue(Of Decimal)("nonreflabactual").ToString() & "" & _
        " ,nonref_eqactual = isnull(nonref_eqactual,0) - " & drh.GetValue(Of Decimal)("nonrefeqactual").ToString() & "" & _
        " where wbs_id = " & drh.GetValue(Of Long)("stockiw_wbs").ToString & "" & _
        " and isnull(wbs_ismarkup,0) = " & drh.GetValue(Of Integer)("stockiw_isMarkup").ToString
        cmdList.Add(cmd)
      Next
      If cmdList.Count > 0 Then
        Return String.Join(";", cmdList.ToArray)
      End If

      Return ""
    End Function
    Public Sub RefreshWBS()
      For Each itm As GoodsReceiptItem In Me.ItemCollection
        For i As Integer = itm.WBSDistributeCollection.Count - 1 To 0
          itm.WBSDistributeCollection.RemoveAt(i)
        Next
      Next
    End Sub
    ''' <summary>
    ''' คิดส่วนลดเอกสารใหม่
    ''' </summary>
    ''' <param name="decitemamt">มูลค่าที่ลดลง ของ item</param>
    ''' <param name="oldGRamt">มูลค่าของเอกสารรวมเดิม</param>
    ''' <remarks></remarks>
    Public Sub UpdateDiscount(ByVal decitemamt As Decimal, ByVal oldGRamt As Decimal)
      Dim rat As Decimal = 1
      If oldGRamt > 0 Then
        rat = (oldGRamt - decitemamt) / oldGRamt
      End If
      Dim PercentRate As String = Discount.GetRateDiscount(Me.Discount.Rate)
      Dim FixRate As Decimal = Configuration.Format(Discount.GetFixDiscount(Me.Discount.Rate) * rat, DigitConfig.Price)
      Dim rate As New List(Of String)
      If PercentRate.Length > 0 Then
        rate.Add(PercentRate)
      End If
      If FixRate <> 0 Then
        rate.Add(CStr(FixRate))
      End If
      Me.Discount.Rate = String.Join(",", rate)
    End Sub

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
            If Not dr.IsNull("refto_type") AndAlso (CInt(dr("refto_type")) = 31 OrElse CInt(dr("refto_type")) = 352) Then
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
    Public Function IshaveAdvancePayClosed() As Boolean
      Dim advpClosed As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGRChkAdvancePayClosed" _
      , New SqlParameter("@stock_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        Dim row As DataRow = ds.Tables(0).Rows(0)
        Dim deh As New DataRowHelper(row)
        advpClosed = deh.GetValue(Of Decimal)("chkClosed")
      End If
      If advpClosed = 0 Then
        Return False
      Else
        Return True
      End If
    End Function
    Private Function ListWbsId() As String
      Dim idList As New ArrayList
      For Each itm As GoodsReceiptItem In Me.ItemCollection
        For Each iwbsd As WBSDistribute In itm.WBSDistributeCollection
          idList.Add(iwbsd.WBS.Id)
        Next
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
    End Function
    Private Function ValidateOverBudget() As SaveErrorException
      If Me.ToCostCenter.Type.Value <> 2 Then
        Return New SaveErrorException("-1")
      End If
      If Me.ToCostCenter.Boq Is Nothing OrElse Me.ToCostCenter.Boq.Id = 0 Then
        Return New SaveErrorException("-1")
      End If
      'POROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("GROverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If

      'GROverBudgetOnlyWBSAllocate
      config = Configuration.GetConfig("GROverBudgetOnlyWBSAllocate")
      Dim onlyWBSAllocate As Boolean = False
      If Not config Is Nothing Then
        onlyWBSAllocate = CBool(config)
      End If

      '====================
      WBS.ParentBudgetHash = New Hashtable 'ห้ามลืมเด็ดขาด
      '====================
      Dim idList As String = Me.ListWbsId
      Dim dsParentBudget As New DataSet
      dsParentBudget = WBS.GetParentsBudgetList(Me.EntityId, idList)
      Dim currwbsId As Integer
      Dim dt As New DataTable

      If Not onlyCC Then
        For Each item As GoodsReceiptItem In Me.ItemCollection
          If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
            Dim totalBudget As Decimal = 0
            Dim totalActual As Decimal = 0
            Dim totalCurrent As Decimal = 0
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              totalCurrent = (wbsd.Percent / 100) * item.Amount

              If onlyWBSAllocate Then
                If wbsd.OwnerBudgetAmount - totalCurrent < 0 Then
                  Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
                End If
              End If

              'สำหรับ WBS ตัวมันเอง =====>>
              If wbsd.BudgetRemain - totalCurrent < 0 Then
                Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
              End If
              'สำหรับ WBS ตัวมันเอง =====<<

              currwbsId = wbsd.WBS.Id
              For Each drow As DataRow In dsParentBudget.Tables(0).Select("depend_wbs=" & currwbsId)
                Dim drh As New DataRowHelper(drow)

                totalBudget = 0
                totalActual = 0
                Select Case item.ItemType.Value
                  Case 88
                    totalBudget = drh.GetValue(Of Decimal)("labbudget")
                    totalActual = drh.GetValue(Of Decimal)("labactual")
                  Case 89
                    totalBudget = drh.GetValue(Of Decimal)("eqbudget")
                    totalActual = drh.GetValue(Of Decimal)("eqactual")
                  Case Else
                    totalBudget = drh.GetValue(Of Decimal)("matbudget")
                    totalActual = drh.GetValue(Of Decimal)("matactual")
                End Select
                If totalBudget < (totalActual + wbsd.Amount) Then
                  Dim myId As Integer = drh.GetValue(Of Integer)("depend_parent")
                  Dim myWBS As New WBS(myId)
                  Return New SaveErrorException(myWBS.Code & ":" & myWBS.Name)
                End If
              Next

            Next
            If item.WBSDistributeCollection.GetSumPercent = 0 Then
              'สำหรับ Auto จัดสรร
              Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
              Dim tBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
              Dim tActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
              Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.ToCostCenter.Id)
              Dim cActual As Decimal = item.Cost
              Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
              If onlyWBSAllocate Then
                If oBudget < ((tActual - thisActual) + cActual) Then
                  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
                End If
              End If
              If tBudget < ((tActual - thisActual) + cActual) Then
                Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
              End If
            End If
          End If
        Next
      Else
        Dim hCC As New Hashtable
        For Each item As GoodsReceiptItem In Me.ItemCollection
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            If Not hCC.ContainsKey(wbsd.CostCenter.Id) Then
              hCC(wbsd.CostCenter.Id) = wbsd
            End If
          Next
          If item.WBSDistributeCollection.GetSumPercent = 0 Then
            'สำหรับ Auto จัดสรร
            Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
            Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
            Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
            Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.ToCostCenter.Id)
            Dim currentActual As Decimal = item.Cost
            Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
            If onlyWBSAllocate Then
              If oBudget < ((totalActual - thisActual) + currentActual) Then
                Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
              End If
            End If
            If totalBudget < ((totalActual - thisActual) + currentActual) Then
              Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
            End If
          End If
        Next
        For Each wbsd As WBSDistribute In hCC.Values
          Dim rootWBS As New WBS(wbsd.WBS.GetWBSRootId)
          Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
          Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
          Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
          Dim currentActual As Decimal = wbsd.Amount

          Dim tActual As Decimal = (wbsd.WBS.GetActualMat(Me, Me.EntityId) + wbsd.WBS.GetActualLab(Me, Me.EntityId) + wbsd.WBS.GetActualEq(Me, Me.EntityId))
          Dim tcActual As Decimal = wbsd.WBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
          If onlyWBSAllocate Then
            If wbsd.OwnerBudgetAmount < ((tActual - tcActual) + currentActual) Then
              Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
            End If
          End If
          If totalBudget < ((totalActual - thisActual) + currentActual) Then
            Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
          End If
        Next

        'Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
        'Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
        'Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
        'Dim totalCurrentDiff As Decimal = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(0)) + _
        'Me.GetCurrentDiffForWBS(rootWBS, New ItemType(88)) + _
        'Me.GetCurrentDiffForWBS(rootWBS, New ItemType(89))
        'If totalBudget < (totalActual + totalCurrentDiff) Then
        '  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
        'End If
      End If

      Return New SaveErrorException("0")

    End Function

    'Private Function OverBudget() As Boolean
    '  If Me.ToCostCenter.Type.Value <> 2 Then
    '    Return False
    '  End If
    '  If Me.ToCostCenter.Boq Is Nothing OrElse Me.ToCostCenter.Boq.Id = 0 Then
    '    Return False
    '  End If
    '  'GROverBudgetOnlyCC
    '  Dim config As Object = Configuration.GetConfig("GROverBudgetOnlyCC")
    '  Dim onlyCC As Boolean = False
    '  If Not config Is Nothing Then
    '    onlyCC = CBool(config)
    '  End If
    '  If Not onlyCC Then
    '    For Each item As GoodsReceiptItem In Me.ItemCollection
    '      If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
    '        Dim wsdColl As WBSDistributeCollection = item.WBSDistributeCollection
    '        If wsdColl.Count = 0 Then
    '          Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
    '          Dim totalBudget As Decimal = 0
    '          Dim totalActual As Decimal = 0
    '          Dim totalCurrentDiff As Decimal = item.Amount
    '          Select Case item.ItemType.Value
    '            Case 88
    '              totalBudget = rootWBS.GetTotalLabFromDB
    '              totalActual = rootWBS.GetActualLab(Me, 45)
    '            Case 89
    '              totalBudget = rootWBS.GetTotalEQFromDB
    '              totalActual = rootWBS.GetActualEq(Me, 45)
    '            Case Else
    '              totalBudget = rootWBS.GetTotalMatFromDB
    '              totalActual = rootWBS.GetActualMat(Me, 45)
    '          End Select
    '          If totalBudget < (totalActual + totalCurrentDiff) Then
    '            Return True
    '          End If
    '        End If
    '        For Each wbsd As WBSDistribute In wsdColl
    '          If wbsd.AmountOverBudget Then
    '            Return True
    '          End If
    '          Dim rootWBS As New WBS(wbsd.WBS.Id)
    '          Dim totalBudget As Decimal = 0
    '          Dim totalActual As Decimal = 0
    '          Dim totalCurrentDiff As Decimal = 0
    '          Select Case item.ItemType.Value
    '            Case 88
    '              totalCurrentDiff = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(88))
    '            Case 89
    '              totalCurrentDiff = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(89))
    '            Case Else
    '              totalCurrentDiff = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(0))
    '          End Select
    '          For Each row As DataRow In rootWBS.GetParentsBudget(Me.EntityId)
    '            totalBudget = 0
    '            totalActual = 0
    '            Select Case item.ItemType.Value
    '              Case 88
    '                If Not row.IsNull("labbudget") Then
    '                  totalBudget = CDec(row("labbudget"))
    '                End If
    '                If Not row.IsNull("labactual") Then
    '                  totalActual = CDec(row("labactual"))
    '                End If
    '              Case 89
    '                If Not row.IsNull("eqbudget") Then
    '                  totalBudget = CDec(row("eqbudget"))
    '                End If
    '                If Not row.IsNull("eqactual") Then
    '                  totalActual = CDec(row("eqactual"))
    '                End If
    '              Case Else
    '                If Not row.IsNull("matbudget") Then
    '                  totalBudget = CDec(row("matbudget"))
    '                End If
    '                If Not row.IsNull("matactual") Then
    '                  totalActual = CDec(row("matactual"))
    '                End If
    '            End Select
    '            If totalBudget < (totalActual + totalCurrentDiff) Then
    '              Return True
    '            End If
    '          Next
    '        Next
    '      End If
    '    Next
    '  Else
    '    Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
    '    Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
    '    Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
    '    Dim totalCurrentDiff As Decimal = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(0)) + _
    '    Me.GetCurrentDiffForWBS(rootWBS, New ItemType(88)) + _
    '    Me.GetCurrentDiffForWBS(rootWBS, New ItemType(89))
    '    If totalBudget < (totalActual + totalCurrentDiff) Then
    '      Return True
    '    End If
    '  End If
    '  Return False
    'End Function
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
    Private Function ValidateItem() As SaveErrorException
      Dim key As String = ""

      For Each item As GoodsReceiptItem In Me.ItemCollection

        Dim newHash As New Hashtable
        For Each wbitem As WBSDistribute In item.WBSDistributeCollection
          key = wbitem.CostCenter.Code & ":" & wbitem.WBS.Id.ToString
          If Not newHash.Contains(key) Then
            newHash(key) = wbitem
          Else
            Return New SaveErrorException("${res:Global.Error.DupplicateWBS}", New String() {wbitem.WBS.Code})
          End If
          If (wbitem.WBS Is Nothing OrElse wbitem.WBS.Id = 0) AndAlso wbitem.CostCenter.BoqId > 0 Then
            Return New SaveErrorException("${res:Global.Error.WBSMissing}")
          End If
        Next
      Next

      Return New SaveErrorException("0")
    End Function
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
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_payment.Code = oldJecode
      Me.m_payment.AutoGen = oldjeautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    'Public NoItem As Boolean = False
    'Public OnlyPayment As Boolean = False
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      'เนื่องจากตอนบันทึกเอกสาร แล้ว Vat มีการเรียก Implement ตัวนี้แล้วเกิด DeadLock บ่อยมาก ๆ เลยเก็บค่านี้ไว้จังหวะก่อนบันทึก แล้วให้ m_vat.Save เรียกตัวนี้แทน
      Dim sv As New SimpleVat
      sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(Me.Id, Me.EntityId, Me.Id, Me.EntityId)
      Me.TaxBaseDeductedWithoutThisRefDoc = Me.RealTaxBase - sv.TaxBase

      ValidateError = Me.Vat.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.WitholdingTaxCollection.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.Payment.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If




      Return New SaveErrorException("0")

    End Function
    Private m_DocMethod As SaveDocMultiApprovalMethod

    Public Function OnlyGenGlAtom() As SaveErrorException Implements INewGLAble.OnlyGenGLAtom
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      SubSaveJeAtom(conn)
      conn.Close()
    End Function

    Dim poIdArrayList As ArrayList
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException

      With Me

        If Not Me.Originated Then
          m_DocMethod = SaveDocMultiApprovalMethod.Save
        ElseIf Me.Status.Value = 0 Then
          m_DocMethod = SaveDocMultiApprovalMethod.Cancel
          'ElseIf Me.Closed Then
          '  m_DocMethod = SaveDocMultiApprovalMethod.Close
        Else
          m_DocMethod = SaveDocMultiApprovalMethod.Update
        End If

        Me.RefreshTaxBase()

        Dim docValidate As Boolean = True
        If Me.Originated AndAlso Me.Status.Value = 0 Then
          docValidate = False
        End If

        If docValidate Then 'ถ้ายกเลิกเอกสารแล้ว ไม่ต้อง Validate

          If Originated Then
            If Not Supplier Is Nothing Then
              If Supplier.Canceled Then
                Return New SaveErrorException(StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Supplier.Code})
              End If
            End If
          End If
          Dim ValidateError As SaveErrorException = ValidateItem()
          If Not IsNumeric(ValidateError.Message) Then
            Return ValidateError
          End If

          ''สำหรับรับของหน้างาน ไม่ต้อง Validate ====
          If Not HideCost Then
            Dim ValidateOverBudgetError As SaveErrorException
            Dim config As Integer = CInt(Configuration.GetConfig("GROverBudget"))
            Select Case config
              Case 0 'Not allow
                ValidateOverBudgetError = Me.ValidateOverBudget
                If Not IsNumeric(ValidateOverBudgetError.Message) Then
                  Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.OverBudgetCannotSaved}")
                  Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                  msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                  Return New SaveErrorException(msgString & vbCrLf & msgString2)
                End If
              Case 1 'Warn
                ValidateOverBudgetError = Me.ValidateOverBudget
                If Not IsNumeric(ValidateOverBudgetError.Message) Then
                  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                  Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.AcceptOverBudget}")
                  Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                  msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                  If Not msgServ.AskQuestion(msgString2 & vbCrLf & msgString) Then
                    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
                  End If
                End If
              Case 2 'Do Nothing
            End Select

            ''---------------------- เช็คว่ามีมัดจำเหลือหรือป่าว 
            If Me.AdvancePayItemCollection Is Nothing OrElse Me.AdvancePayItemCollection.Count = 0 Then
              If haveAdvancePay() Then
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                If msgServ.AskQuestion("${res:Global.Question.WantAddAdvancePay}") Then
                  RaiseEvent AdvanceClick(Me, Nothing)
                  'Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
                End If
              End If
            End If
            '------------------
          End If

          If Me.ItemCollection.Count <= 0 Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
          End If

          If Not Me.m_po Is Nothing AndAlso Me.m_po.Originated AndAlso Not Me.ValidateItemRefPO Then
            'ไม่มีรายการที่อ้างอิงกับเอกสาร
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowWarning("${res:Global.Error.NoItemRef}" & " " & m_po.Code)
            m_po = Nothing
          End If

        End If

        'If NoItem Then
        '    Return Me.SaveNoItem(currentUserId)
        'ElseIf OnlyPayment Then
        '    Return Me.SaveOnlyPayment(currentUserId)
        'End If

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
        Dim oldcode As String
        Dim oldautogen As Boolean
        Dim oldjecode As String
        Dim oldjeautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
        oldjecode = Me.m_je.Code
        oldjeautogen = Me.m_je.AutoGen

        If Me.m_je.AccountBook Is Nothing OrElse m_je.AccountBook.CodePrefix Is Nothing Then
          Me.m_je.AccountBook = Me.GetDefaultGLFormat.AccountBook
        End If


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
              Me.m_je.DontSave = False
            Case 2
              'ตาม gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
              Me.m_je.DontSave = False
            Case Else
              'แยก
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.m_je.DontSave = False
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


        ''==============================DELETE STOCKCOST=========================================
        ''ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
        If Me.Originated AndAlso Not Me.IsReferenced Then
          Dim transbefore As SqlTransaction = conn.BeginTransaction
          Try
            SqlHelper.ExecuteNonQuery(conn, transbefore, CommandType.StoredProcedure, "DeleteStockiCost", New SqlParameter("@stock_id", Me.Id))

          Catch ex As Exception
            transbefore.Rollback()
            Return New SaveErrorException(ex.InnerException.ToString)
          End Try
          transbefore.Commit()
        End If
        ''==============================DELETE STOCKCOST=========================================

        trans = conn.BeginTransaction()
        Dim oldId As Integer = Me.Id
        Dim oldPaymentId As Integer = Me.m_payment.Id
        Dim oldVatId As Integer = Me.m_vat.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If
        Dim oldJeId As Integer = Me.m_je.Id

        Try

          ''Main Save Block
          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -5
                  trans.Rollback()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case -2 'เอกสารถูกอ้างอิงแล้ว
                  If Me.IsDirty Then 'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
                    trans.Rollback()
                    ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return New SaveErrorException(returnVal.Value.ToString)
                  End If
                Case -69 'ใบส่งของซ้ำ
                  If Me.IsDirty Then 'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
                    trans.Rollback()
                    ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return New SaveErrorException("${res:Global.Error.DeliveryDocCodeDuplicated}", Me.DeliveryDocCode)
                  End If
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If



            Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
            If Not IsNumeric(saveDetailError.Message) Then
              trans.Rollback()
              ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveDetailError
            Else
              Select Case CInt(saveDetailError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveDetailError
                Case Else
              End Select
            End If

            ''==============CURRENCY=================================
            ''Save Currency
            'If Me.Originated Then
            '  BusinessLogic.Currency.SaveCurrency(Me, conn, trans)
            'End If
            '==============CURRENCY=================================



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
              Me.Payment.ResetDetail()
              ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return savePaymentError
            Else
              Select Case CInt(savePaymentError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.Payment.ResetDetail()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
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
                Me.Payment.ResetDetail()
                ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveAdvancePayError
              Else
                Select Case CInt(saveAdvancePayError.Message)
                  Case -1, -2, -5
                    trans.Rollback()
                    Me.Payment.ResetDetail()
                    ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveAdvancePayError
                  Case Else
                End Select
              End If
            End If
            'Dim sv As New SimpleVat
            'sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(Me.Id, Me.EntityId, Me.Id, Me.EntityId, conn, trans)  'เนื่องจากตอนบันทึกเอกสาร แล้ว Vat มีการเรียก Implement ตัวนี้แล้วเกิด DeadLock บ่อยมาก ๆ เลยเก็บค่านี้ไว้จังหวะก่อนบันทึก แล้วให้ m_vat.Save เรียกตัวนี้แทน
            'Me.TaxBaseDeductedWithoutThisRefDoc = Me.RealTaxBase - sv.TaxBase
            Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveVatError.Message) Then
              trans.Rollback()
              Me.Payment.ResetDetail()
              ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveVatError
            Else
              Select Case CInt(saveVatError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.Payment.ResetDetail()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveVatError
                Case Else
              End Select
            End If

            If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
              Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
              If Not IsNumeric(saveWhtError.Message) Then
                trans.Rollback()
                Me.Payment.ResetDetail()
                ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveWhtError
              Else
                Select Case CInt(saveWhtError.Message)
                  Case -1, -2, -5
                    trans.Rollback()
                    Me.Payment.ResetDetail()
                    ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
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
              Me.Payment.ResetDetail()
              ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveJeError
            Else
              Select Case CInt(saveJeError.Message)
                Case -1, -5
                  trans.Rollback()
                  Me.Payment.ResetDetail()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveJeError
                Case -2
                  'Post ไปแล้ว
                  Me.Payment.ResetDetail()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveJeError
                Case Else
              End Select
            End If

            '==============================AUTOGEN==========================================
            Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
            If Not IsNumeric(saveAutoCodeError.Message) Then
              trans.Rollback()
              Me.Payment.ResetDetail()
              ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.Payment.ResetDetail()
                  ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================


            trans.Commit()
            If Not Me.IsDirty AndAlso returnVal.Value.ToString = "-2" Then 'ถ้าเอกสารไม่ถูกแก้ไข --> ให้ save
              Return New SaveErrorException(Me.Id.ToString)
            End If
          Catch ex As SqlException
            trans.Rollback()
            Me.Payment.ResetDetail()
            ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.Payment.ResetDetail()
            ResetId(oldId, oldPaymentId, oldVatId, oldJeId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)

          End Try

          'Sub Save Block ===========================================
          'Try
          '  Dim subsaveerror As SaveErrorException = SubSave(conn)
          '  If Not IsNumeric(subsaveerror.Message) Then
          '    Return New SaveErrorException(" Save Incomplete Please Save Again (1)")
          '  End If
          'Catch ex As Exception
          '  Return New SaveErrorException(ex.ToString)
          'End Try

          poIdArrayList.Add(Me.Po.Id)
          Dim poIdList As String = String.Join(",", poIdArrayList.ToArray)

          Parallel.Invoke(Sub()
                            SubSaveGoodReceiptList(conn)
                          End Sub,
                          Sub()
                            SubSave(conn)
                          End Sub,
                          Sub()
                            SubSavePOReference(conn)
                          End Sub,
                          Sub()
                            SaveWBSActual(conn)
                          End Sub,
                          Sub()
                            SubSaveDocApprove(conn, currentUserId)
                          End Sub,
                          Sub()
                            BusinessLogic.PO.UpdateReferencePOGeneralList(conn, poIdArrayList)
                          End Sub,
                          Sub()
                            BusinessLogic.PO.UpdateGRReferencePOGeneralList(conn, poIdArrayList)
                          End Sub)

          Try
            Dim subsaveerror3 As SaveErrorException = SubSaveJeAtom(conn)
            If Not IsNumeric(subsaveerror3.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again (2)")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          'Try
          '  Dim subsaveerror2 As SaveErrorException = SubSaveDocApprove(conn, currentUserId)
          '  If Not IsNumeric(subsaveerror2.Message) Then
          '    Return New SaveErrorException(" Save Incomplete Please Save Again (3)")
          '  End If
          'Catch ex As Exception
          '  Return New SaveErrorException(ex.ToString)
          'End Try
          'Sub Save Block ===========================================

          Return New SaveErrorException(returnVal.Value.ToString)
          'Complete Save
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function

    Public Shared Function UpdateRemainGoodsReceiptList(ByVal conn As SqlConnection, ByVal grIdList As String) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "UpdateRemainGoodsReceiptList", New SqlParameter("@stockIdList", grIdList))
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Public Shared Function UpdateReferenceGoodsReceiptList(ByVal conn As SqlConnection, ByVal grIdList As String) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "UpdateReferenceGoodsReceiptList", New SqlParameter("@stockIdList", grIdList))
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Private Function SubSaveGoodReceiptList(ByVal conn As SqlConnection) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "UpdateGoodsReceiptList", New SqlParameter("@stock_id", Me.Id))
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Private Function SubSave(ByVal oldconn As SqlConnection) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()
      '==============================STOCKCOST=========================================
      'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut) 
      If Not Me.IsReferenced Then
        Dim trans As SqlTransaction = conn.BeginTransaction
        Try
          'InsertStockiCostFirstFIFO ใช้สำหรับเอกสารตั้งต้น Cost จะได้ลดภาระ database
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertStockiCostFirstFIFO", New SqlParameter("@stock_id", Me.Id))
        Catch ex As Exception
          trans.Rollback()
          conn.Close()
          Return New SaveErrorException(ex.InnerException.ToString)
        End Try

        For Each extender As Object In Me.Extenders
          If TypeOf extender Is IExtender Then
            Dim saveDocError As SaveErrorException = CType(extender, IExtender).Save(conn, trans)
            If Not IsNumeric(saveDocError.Message) Then
              trans.Rollback()
              conn.Close()
              Return saveDocError
            Else
              Select Case CInt(saveDocError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  conn.Close()
                  Return saveDocError
                Case Else
              End Select
            End If
          End If
        Next

        trans.Commit()
        conn.Close()
      End If
      '==============================STOCKCOST=========================================
      Return New SaveErrorException("0")
    End Function

    Private Function SubSavePOReference(ByVal oldconn As SqlConnection) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()
      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePO_GRRef", New SqlParameter("@stock_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSReferencedFromStock", New SqlParameter("@refto_id", Me.Id), New SqlParameter("@refto_type", Me.EntityId))
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGoodsReceiptPVList", New SqlParameter("@stock_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateGRWBSActual")
      Catch ex As Exception
        trans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try
      trans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function

    Private Function SaveWBSActual(ByVal oldconn As SqlConnection) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()

      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        Dim cmd As String = Me.GetGRCommandActual
        If cmd.Length > 0 Then
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, cmd)
        End If
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_OnlyUpdateGRWBSActual", New SqlParameter("@stock_id", Me.Id))

      Catch ex As Exception
        trans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function

    Private Function SubSaveDocApprove(ByVal oldconn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()

      Dim strans As SqlTransaction = conn.BeginTransaction
      Try
        Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.AfterTax, currentUserId, m_DocMethod, Me.ApproveDocColl.GetLastedApproveDoc.Comment, Me.ToCostCenter.Id, Me.Supplier.Id, Me)
        Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, strans)
        If Not IsNumeric(savemldocError.Message) Then
          strans.Rollback()
          conn.Close()
          Return savemldocError
        End If
      Catch ex As Exception
        strans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      strans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function

    Private Function SubSaveJeAtom(ByVal conn As SqlConnection) As SaveErrorException Implements INewGLAble.SubSaveJeAtom
      Me.JournalEntry.RefreshOnlyGLAtom()
      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        Me.JournalEntry.SaveAutoMateDetail(Me.JournalEntry.Id, conn, trans)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try
      trans.Commit()
      Return New SaveErrorException("0")
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

          'Select Case item.ItemType.Value
          '  Case 42
          '    Dim lci As New LCIItem(item.Entity.Id)
          '    If Not lci.Originated Then
          '      Return New SaveErrorException("${res:Global.Error.LCIIsInvalid}", New String() {item.Entity.Name})
          '    ElseIf Not lci.ValidUnit(item.Unit) Then
          '      Return New SaveErrorException("${res:Global.Error.LCIInvalidUnit}", New String() {lci.Code, item.Unit.Name})
          '    End If
          '  Case 19
          '    Dim myTool As New Tool(item.Entity.Id)
          '    If Not myTool.Originated Then
          '      Return New SaveErrorException("${res:Global.Error.ToolIsInvalid}", New String() {item.Entity.Name})
          '    ElseIf myTool.Unit.Id <> item.Unit.Id Then
          '      Return New SaveErrorException("${res:Global.Error.ToolInvalidUnit}", New String() {myTool.Code, item.Unit.Name})
          '    End If
          'End Select

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
              'wbsd.TransferBaseCost = Cost
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
              'childDr("stockiw_transferbaseCost") = wbsd.TransferBaseCost
              'childDr("stockiw_transferamt") = wbsd.TransferAmount
              childDr("stockiw_amt") = wbsd.Amount
              childDr("stockiw_toaccttype") = Me.ToAccountType.Value
              childDr("stockiw_cbs") = wbsd.CBS.Id
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
                'newWbsd.TransferBaseCost = Cost
                Dim childDr As DataRow = dtWbs.NewRow
                childDr("stockiw_wbs") = newWbsd.WBS.Id
                childDr("stockiw_cc") = newWbsd.CostCenter.Id
                childDr("stockiw_percent") = newWbsd.Percent
                childDr("stockiw_sequence") = dr("stocki_sequence")
                childDr("stockiw_ismarkup") = False
                childDr("stockiw_direction") = 0                'in
                childDr("stockiw_baseCost") = newWbsd.BaseCost
                'childDr("stockiw_transferbaseCost") = newWbsd.TransferBaseCost
                'childDr("stockiw_transferamt") = newWbsd.TransferAmount
                childDr("stockiw_amt") = newWbsd.Amount
                childDr("stockiw_toaccttype") = Me.ToAccountType.Value
                childDr("stockiw_cbs") = newWbsd.CBS.Id
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
    Public Shared Function GetListDatatableForEquipment(ByVal ParamArray filters() As Filter) As DataTable

      Dim sqlConString As String = SimpleBusinessEntityBase.ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetGoodsReceiptItemsForEquipmentList", params)

      Return ds.Tables(0)

    End Function
    Public Shared Function GetListDatatableForTool(ByVal ParamArray filters() As Filter) As DataTable

      Dim sqlConString As String = SimpleBusinessEntityBase.ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetGoodsReceiptItemsForToolList", params)

      Return ds.Tables(0)

    End Function
    Private Function haveAdvancePay() As Boolean
      Dim ds As DataSet = SqlHelper.ExecuteDataset( _
               Me.ConnectionString _
               , CommandType.StoredProcedure _
               , "GethaveAdvancepayFromSupandEntity" _
               , New SqlParameter("@supplier_id", Me.Supplier.Id) _
               , New SqlParameter("@entity_type", Me.EntityId) _
               , New SqlParameter("@taxtype", Me.TaxType.Value) _
               )
      If ds.Tables(0).Rows.Count > 0 Then
        Return True
      End If
      Return False
    End Function
    Private Function ValidateItemRefPO() As Boolean
      Dim ret As Boolean = False
      For Each item As GoodsReceiptItem In Me.ItemCollection
        If Not item.POitem Is Nothing AndAlso item.POitem.Po.Id = Me.Po.Id Then
          ret = True
          Return ret
        End If
      Next
      Return ret
    End Function
#End Region

#Region "RefreshTaxBase"
    Private m_taxGross As Decimal
    Public Sub SetRealGross()
      If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then
        Return
      End If

      Dim sumAmount As Decimal = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection
        sumAmount += item.Amount
      Next
      RealGross = sumAmount
    End Sub
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
      'If Me.Po IsNot Nothing Then
      '  Dim dis As Decimal = Discount.GetFixDiscount(Me.Discount.Rate, Me.Discount.Amount)
      '  dis = m_gross / m_po.Gross * dis
      '  Me.Discount.Rate = CStr(dis)
      'End If
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
        ji.EntityItem = Me.Id
        ji.EntityItemType = Me.EntityId
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
          ji.EntityItem = Me.Id
          ji.EntityItemType = Me.EntityId
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
          ji.EntityItem = Me.Id
          ji.EntityItemType = Me.EntityId
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
      If (Me.RealTaxAmount * Me.Currency.Conversion) - Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.5.1"
        ji.Amount = Configuration.Format((Me.RealTaxAmount * Me.Currency.Conversion) - Me.Vat.Amount, DigitConfig.Price)
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.EntityItem = Me.Id
        ji.EntityItemType = Me.EntityId
        ji.Note = Me.Code & ":รับสินค้า:" & Me.Supplier.Name
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
          If Not avpi.AdvancePay.CostCenter Is Nothing AndAlso avpi.AdvancePay.CostCenter.Originated Then
            ji.CostCenter = avpi.AdvancePay.CostCenter
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
        Dim advcc As New CostCenter
        If Me.AdvancePayItemCollection.Count = 1 Then
          If Not Me.AdvancePayItemCollection(0).AdvancePay Is Nothing AndAlso Not Me.AdvancePayItemCollection(0).AdvancePay.CostCenter Is Nothing Then
            advcc = Me.AdvancePayItemCollection(0).AdvancePay.CostCenter
          End If
        ElseIf Me.AdvancePayItemCollection.Count > 1 Then
          advcc = Me.ToCostCenter
        End If
        ji = New JournalEntryItem
        ji.Mapping = "PM1.10"
        ji.Amount = Me.AdvancePayItemCollection.GetExcludeVATAmount
        If advcc.Originated Then
          ji.CostCenter = advcc
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

      Dim tmp2 As Object = Configuration.GetConfig("GRGLByPOCC")
      Dim pocc As Integer = -1
      If IsNumeric(tmp2) Then
        pocc = CInt(tmp2)
      End If
      Dim PO_CC As CostCenter
      If Me.Po IsNot Nothing Then
        PO_CC = Po.ToCC
      ElseIf Me.ToCostCenter.Originated Then
        PO_CC = Me.ToCostCenter
      Else
        PO_CC = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      Dim e31 As Integer = 0
      Dim e32 As Integer = 0
      Dim e33 As Integer = 0
      Dim e34 As Integer = 0
      Dim e36 As Integer = 0

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
              Case 0, 88 'Blank  
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
              Case 89 'Blank  
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "E3.6" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    blankMatched = True
                    e36 += 1
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "E3.6" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    blankNoAcctMatched = True
                    e36 += 1
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
            Case 0, 88 'Blank  
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
            Case 89 'Rent Equipment  
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not blankMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.6"
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
                  e36 += 1
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not blankNoAcctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "E3.6"
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
                  e36 += 1
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
                  If pocc = 1 Then
                    ji.CostCenter = PO_CC
                  ElseIf Me.ToCostCenter.Originated Then
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
                  If pocc = 1 Then
                    ji.CostCenter = PO_CC
                  ElseIf Me.ToCostCenter.Originated Then
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
          Case "E3.6"
            tmpJi.Note = "ค่าเช่าเครื่องจักร" & e34 & " รายการ"
        End Select
        tmpJi.Amount = Configuration.Format(tmpJi.Amount * Me.Currency.Conversion, DigitConfig.Price)
      Next
      Return jiColl
    End Function
    Private Function GetItemDetailJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      Dim map As String = ""
      Dim withdrawAccount As Account

      Dim tmp2 As Object = Configuration.GetConfig("GRGLByPOCC")
      Dim pocc As Integer = -1
      If IsNumeric(tmp2) Then
        pocc = CInt(tmp2)
      End If
      Dim PO_CC As CostCenter
      If Me.Po IsNot Nothing Then
        PO_CC = Po.ToCC
      ElseIf Me.ToCostCenter.Originated Then
        PO_CC = Me.ToCostCenter
      Else
        PO_CC = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If

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
            Case 0, 88      'Blank  
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
            Case 89      'Blank  
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not blankMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.6", realAccount, itemAmount, ToCostCenter)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not blankNoAcctMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.6", itemAmount, ToCostCenter)
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
              Dim tmpCC As CostCenter
              If pocc = 1 Then
                tmpCC = PO_CC
              Else
                tmpCC = ToCostCenter
              End If
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
                  SetJournalEntryItem(item, jiColl, "E3.1", realAccount, itemAmount, tmpCC)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not lciToolNoAcctMatched Then
                  SetJournalEntryItem(item, jiColl, "E3.1", itemAmount, tmpCC)
                End If
              End If

              '*********************เบิก*****************************************************
              If Me.ToAccountType.Value = 1 Or Me.ToAccountType.Value = 2 Then
                If Not originMatched Then
                  'ฝั่งต้นทาง
                  SetJournalEntryItem(item, jiColl, "F1.4", realAccount, itemAmount, tmpCC)
                End If
                If Not withdrawAccount Is Nothing AndAlso withdrawAccount.Originated Then
                  If Not withdrawMatched Then
                    SetJournalEntryItem(item, jiColl, map, withdrawAccount, itemAmount, tmpCC)
                  End If
                ElseIf withdrawAccount Is Nothing OrElse Not withdrawAccount.Originated Then
                  If Not withdrawNoAcctMatched Then
                    SetJournalEntryItem(item, jiColl, map, itemAmount, tmpCC)
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

#Region "INewGLAble"
    Public Function NewGetJournalEntries() As JournalEntryItemCollection Implements INewGLAble.NewGetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem
      Dim tmp As Object = Configuration.GetConfig("APRetentionPoint")

      Dim apRetentionPoint As Integer = 0
      If IsNumeric(tmp) Then
        apRetentionPoint = CInt(tmp)
      End If
      Dim retentionHere As Boolean = (apRetentionPoint = 0)
      'ค่าใช้จ่ายซ่อม มายังไงวะ จะรู้ได้ไงว่าเป็น ค่าซ่อมบำรุงเครื่องจักร
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
        ji.EntityItem = Me.Id
        ji.EntityItemType = 50
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
        ji.EntityItem = Me.Id
        ji.EntityItemType = Entity.GetIdFromClassName("PurchaseRetention")
        ji.table = Me.TableName
        ji.AtomNote = "GR ตั้ง Retention"
        jiColl.Add(ji)
      End If

      'ภาษีซื้อ
      If Me.Vat.Amount > 0 Then
        'ต้อง referrence ถึง TaxInvoice แต่ละใบให้ได้ เพราะใช้กับ สรรพากร แน่ๆ
        For Each vi As VatItem In Me.Vat.ItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "E3.5"
          ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If

          ji.Note = vi.Code & "/" & vi.PrintName & ":" & Me.Recipient.Name
          ji.EntityItem = Me.Vat.Id
          ji.EntityItemType = 97 'ใช้ Incomingvat 
          ji.table = Me.Vat.TableName & "item"
          ji.CustomRefstr = vi.LineNumber.ToString
          ji.CustomRefType = "vati_linenumber"
          ji.AtomNote = "ภาษีซื้อ ได้ tax Invoice"
          jiColl.Add(ji)


        Next

        For Each vi As VatItem In Me.Vat.ItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "I4.2"
          ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = vi.Code & "/" & vi.PrintName
          ji.EntityItem = Me.Vat.Id
          ji.EntityItemType = 97 'ใช้ Incomingvat 
          ji.table = Me.Vat.TableName & "item"
          ji.CustomRefstr = vi.LineNumber.ToString
          ji.CustomRefType = "vati_linenumber"
          ji.AtomNote = "ภาษีซื้อ ได้ tax Invoice"
          jiColl.Add(ji)

        Next

      End If

      'ภาษีซื้อไม่ถึงกำหนด
      If (Me.RealTaxAmount * Me.Currency.Conversion) - Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.5.1"
        ji.Amount = Configuration.Format((Me.RealTaxAmount * Me.Currency.Conversion) - Me.Vat.Amount, DigitConfig.Price)
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If

        ji.Note = Me.Code & ":รับสินค้า:" & Me.Supplier.Name
        'ตอนตั้งกับล้างอ้างอันเดียวกัน
        ji.EntityItem = Me.Id
        ji.EntityItemType = Entity.GetIdFromFullClassName("Longkong.Pojjaman.BusinessLogic.VatInNotDue")
        ji.table = Me.TableName
        ji.CustomRefstr = Me.EntityId.ToString
        ji.CustomRefType = "entity"
        ji.AtomNote = "ตั้ง vat not due GR"
        jiColl.Add(ji)

        ji = New JournalEntryItem
        ji.Mapping = "I4.2.1"
        ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
        If Me.ToCostCenter.Originated Then
          ji.CostCenter = Me.ToCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        'ตอนตั้งกับล้างอ้างอันเดียวกัน
        ji.EntityItem = Me.Id
        ji.EntityItemType = Entity.GetIdFromFullClassName("Longkong.Pojjaman.BusinessLogic.VatInNotDue")
        ji.table = Me.TableName
        ji.CustomRefstr = Me.EntityId.ToString
        ji.CustomRefType = "entity"
        ji.AtomNote = "ตั้ง vat not due GR"
        jiColl.Add(ji)
      End If

      'ภาษีหัก ณ ที่จ่าย
      If Not Me.WitholdingTaxCollection.IsBeforePay Then
        If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
          'ji = New JournalEntryItem
          'ji.Mapping = "E3.15"
          'ji.Amount = Me.WitholdingTaxCollection.Amount
          'If Me.ToCostCenter.Originated Then
          '  ji.CostCenter = Me.ToCostCenter
          'Else
          '  ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          'End If
          'ji.Note = Me.Recipient.Name
          'jiColl.Add(ji)


          'ภาษีหัก ณ ที่จ่าย ภงด.อื่นๆ
          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            ji = New JournalEntryItem
            ji.Mapping = "E3.15"
            ji.Amount = wht.Amount
            If Me.ToCostCenter.Originated Then
              ji.CostCenter = Me.ToCostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = wht.PrintName & "(" & wht.Code & ")"
            ji.EntityItem = wht.Id
            ji.EntityItemType = Entity.GetIdFromClassName("WitholdingTax")
            ji.table = wht.TableName
            jiColl.Add(ji)
          Next



          Dim typeNum As String
          'ภาษีหัก ณ ที่จ่าย
          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            typeNum = CStr(wht.Type.Value)
            If Not (typeNum.Length > 1) Then
              typeNum = "0" & typeNum
            End If
            If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
              ji = New JournalEntryItem
              ji.Mapping = "E3.18"
              ji.Amount = wht.Amount
              ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
              If Me.ToCostCenter.Originated Then
                ji.CostCenter = Me.ToCostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              ji.Note = wht.PrintName & "(" & wht.Code & ")" & wht.Type.Description
              ji.EntityItem = wht.Id
              ji.EntityItemType = Entity.GetIdFromClassName("WitholdingTax")
              ji.table = wht.TableName
              ji.AtomNote = " WHT"
              jiColl.Add(ji)
            End If
          Next


          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            ji = New JournalEntryItem
            ji.Mapping = "I4.4"
            ji.Amount = wht.Amount
            If Me.ToCostCenter.Originated Then
              ji.CostCenter = Me.ToCostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = wht.PrintName & "(" & wht.Code & ")"
            ji.EntityItem = wht.Id
            ji.EntityItemType = Entity.GetIdFromClassName("WitholdingTax")
            ji.table = wht.TableName
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

      'เงินมัดจำจ่ายล่วงหน้า เป็นขาออกของ Advancepay
      If Me.AdvancePayItemCollection.GetExcludeVATAmount > 0 Then
        Dim pm110note As String = ""
        For Each avpi As AdvancePayItem In Me.AdvancePayItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "PM1.10"
          ji.Amount = avpi.AdvancePay.GetRemainExcludeVatAmount(avpi.Amount)
          If Me.ToCostCenter.Originated Then
            ji.CostCenter = Me.ToCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = avpi.AdvancePay.Code & "/" & Me.Recipient.Name

          ji.EntityItem = avpi.AdvancePay.Id
          ji.EntityItemType = avpi.AdvancePay.EntityId
          ji.table = avpi.AdvancePay.TableName
          ji.AtomNote = "ล้างมัดจำด้วย GR"
          jiColl.Add(ji)

          If pm110note = "" Then
            pm110note = "ตัดมัดจำของ " & Me.Recipient.Code & "(" & avpi.AdvancePay.Code & ")"

          Else
            pm110note = pm110note & "," & Me.Recipient.Code & "(" & avpi.AdvancePay.Code & ")"
          End If

        Next

      End If

      If Not Me.Payment Is Nothing Then
        'ส่วนต่างระหว่างยอดจ่ายกับยอดจริง ---> เจ้าหนี้

        Dim pmGross As Decimal = 0


        pmGross = Me.Payment.Gross
        'เจ้าหนี้การค้า
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
          ''===== ใช้ตั้งหนี้ ไปอ้างกับล้างหนี้ =====
          ji.EntityItem = Me.Id
          ji.EntityItemType = Me.EntityId
          ''===== อะไรคือ entity ของ ไอ้นี่ดี ถ้าใช้ Supplier ก็คือ เก็บหนี้ของเจ้านี้ =====
          ji.table = Me.TableName
          ji.AtomNote = "GR ตั้งหนี้"
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
          ''===== อะไรคือ entity ของ ไอ้นี่ดี ถ้าใช้ Supplier ก็คือ เก็บหนี้ของเจ้านี้ =====
          ji.EntityItem = Me.Supplier.Id
          ji.EntityItemType = Me.Supplier.EntityId
          ''===== อะไรคือ entity ของ ไอ้นี่ดี ถ้าใช้ Supplier ก็คือ เก็บหนี้ของเจ้านี้ =====
          ji.table = Me.TableName
          ji.AtomNote = "GR ตั้งหนี้"
          jiColl.Add(ji)
        End If

        jiColl.AddRange(Me.Payment.GetNewJournalEntries)
      End If
      jiColl.AddRange(Me.GetItemNewDetailJournalEntries)
      Return jiColl
    End Function

    Private Function GetItemNewDetailJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      Dim map As String = ""
      Dim withdrawAccount As Account

      Dim tmp2 As Object = Configuration.GetConfig("GRGLByPOCC")
      Dim pocc As Integer = -1
      If IsNumeric(tmp2) Then
        pocc = CInt(tmp2)
      End If
      Dim PO_CC As CostCenter
      If Me.Po IsNot Nothing Then
        PO_CC = Po.ToCC
      ElseIf Me.ToCostCenter.Originated Then
        PO_CC = Me.ToCostCenter
      Else
        PO_CC = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If

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
            Case 0, 88      'Blank  
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not blankMatched Then
                  SetNewJournalEntryItem(item, jiColl, "E3.4", realAccount, itemAmount, ToCostCenter)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not blankNoAcctMatched Then
                  SetNewJournalEntryItem(item, jiColl, "E3.4", itemAmount, ToCostCenter)
                End If
              End If
            Case 89      'Blank  
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not blankMatched Then
                  SetNewJournalEntryItem(item, jiColl, "E3.6", realAccount, itemAmount, ToCostCenter)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not blankNoAcctMatched Then
                  SetNewJournalEntryItem(item, jiColl, "E3.6", itemAmount, ToCostCenter)
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
                  SetNewJournalEntryItem(item, jiColl, "E3.3", realAccount, itemAmount, ToCostCenter)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not assetNoacctMatched Then
                  SetNewJournalEntryItem(item, jiColl, "E3.3", itemAmount, ToCostCenter)
                End If
              End If
            Case 42      'LCI
              Dim realAccount As Account
              Dim entityAcct As Account
              Dim lci As LCIItem = CType(item.Entity, LCIItem)
              Dim tmpCC As CostCenter
              If pocc = 1 Then
                tmpCC = PO_CC
              Else
                tmpCC = ToCostCenter
              End If
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
                  SetNewJournalEntryItem(item, jiColl, "E3.1", realAccount, itemAmount, tmpCC)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not lciToolNoAcctMatched Then
                  SetNewJournalEntryItem(item, jiColl, "E3.1", itemAmount, tmpCC)
                End If
              End If

              '*********************เบิก*****************************************************
              If Me.ToAccountType.Value = 1 Or Me.ToAccountType.Value = 2 Then
                If Not originMatched Then
                  'ฝั่งต้นทาง
                  SetNewJournalEntryItem(item, jiColl, "F1.4", realAccount, itemAmount, tmpCC)
                End If
                If Not withdrawAccount Is Nothing AndAlso withdrawAccount.Originated Then
                  If Not withdrawMatched Then
                    SetNewJournalEntryItem(item, jiColl, map, withdrawAccount, itemAmount, tmpCC)
                  End If
                ElseIf withdrawAccount Is Nothing OrElse Not withdrawAccount.Originated Then
                  If Not withdrawNoAcctMatched Then
                    SetNewJournalEntryItem(item, jiColl, map, itemAmount, tmpCC)
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
                  SetNewJournalEntryItem(item, jiColl, "E3.2", realAccount, itemAmount, ToCostCenter)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not lciToolNoAcctMatched Then
                  SetNewJournalEntryItem(item, jiColl, "E3.2", itemAmount, ToCostCenter)
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

    Private Sub SetNewJournalEntryItem(ByRef item As GoodsReceiptItem, ByRef jiColl As JournalEntryItemCollection, ByVal jiMap As String, ByRef jiAccount As Account, ByVal jiAmount As Decimal, ByRef jiCoscenter As CostCenter)
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

      If item.WBSDistributeCollection.Count > 0 Then
        For Each iwbs As WBSDistribute In item.WBSDistributeCollection
          ji = New JournalEntryItem
          ji.Mapping = jiMap
          ji.Amount = iwbs.Amount     'jiAmount
          ji.Account = jiAccount
          ji.CostCenter = iwbs.CostCenter 'jiCoscenter
          ji.Note = itemname & "(" & Configuration.Format(item.Qty * (iwbs.Percent / 100), DigitConfig.Qty) & unitName & ")" & " " & iwbs.CostCenter.Name & ":" & iwbs.WBS.Name
          ji.EntityItem = item.Sequence
          ji.EntityItemType = item.ItemType.Value
          ji.table = Me.TableName & "item"
          ji.CustomRefstr = iwbs.WBS.Id.ToString
          ji.CustomRefType = "WBS"
          ji.AtomNote = "ใช้เลข sequence จะอ้างไปถึง WBS ได้"
          jiColl.Add(ji)
        Next
      Else
        ji = New JournalEntryItem
        ji.Mapping = jiMap
        ji.Amount = jiAmount
        ji.Account = jiAccount
        ji.CostCenter = jiCoscenter
        ji.Note = itemname & "(" & Configuration.Format(item.Qty, DigitConfig.Qty) & unitName & ")" & " " & jiCoscenter.Name
        ji.EntityItem = item.Sequence
        ji.EntityItemType = item.ItemType.Value
        ji.table = Me.TableName & "item"
        jiColl.Add(ji)
      End If
    End Sub
    Private Sub SetNewJournalEntryItem(ByRef item As GoodsReceiptItem, ByRef jiColl As JournalEntryItemCollection, ByVal jiMap As String, ByVal jiAmount As Decimal, ByRef jiCoscenter As CostCenter)
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

      If item.WBSDistributeCollection.Count > 0 Then
        For Each iwbs As WBSDistribute In item.WBSDistributeCollection
          ji = New JournalEntryItem
          ji.Mapping = jiMap
          ji.Amount = iwbs.Amount     'jiAmount
          ji.CostCenter = iwbs.CostCenter   'jiCoscenter
          ji.Note = itemname & "(" & Configuration.Format(item.Qty * (iwbs.Percent / 100), DigitConfig.Qty) & unitName & ")" & " " & iwbs.CostCenter.Name & ":" & iwbs.WBS.Name
          ji.EntityItem = item.Sequence
          ji.EntityItemType = item.ItemType.Value
          ji.table = Me.TableName & "item"
          ji.CustomRefstr = iwbs.WBS.Id.ToString
          ji.CustomRefType = "WBS"
          ji.AtomNote = "ใช้เลข sequence จะอ้างไปถึง WBS ได้"
          jiColl.Add(ji)
        Next
      Else
        ji = New JournalEntryItem
        ji.Mapping = jiMap
        ji.Amount = jiAmount
        ji.CostCenter = jiCoscenter
        ji.Note = itemname & "(" & Configuration.Format(item.Qty, DigitConfig.Qty) & unitName & ")" & " " & jiCoscenter.Name
        ji.EntityItem = item.Sequence
        ji.EntityItemType = item.ItemType.Value
        ji.table = Me.TableName & "item"
        ji.AtomNote = "ใช้เลข sequence ไม่มี WBS"
        jiColl.Add(ji)
      End If
    End Sub

#End Region



#Region "IVatable"
    Public Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal Implements IVatable.GetMaximumTaxBase
      Dim sv As New SimpleVat

      If conn IsNot Nothing AndAlso trans IsNot Nothing Then
        'Todo: ต้อง refresh หรือเปล่า?
        sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(Me.Id, Me.EntityId, Me.Id, Me.Id, conn, trans)
        Return Me.RealTaxBase - sv.TaxBase
      Else
        'Todo: ต้อง refresh หรือเปล่า?
        sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(Me.Id, Me.EntityId, Me.Id, Me.Id)
        Return Me.RealTaxBase - sv.TaxBase
      End If

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

      '--สำหรับไว้สร้าง relation ใน schema--=============
      'stock_id
      dpi = New DocPrintingItem
      dpi.Mapping = "stock_id"
      dpi.Value = Me.Id
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'stock_type
      dpi = New DocPrintingItem
      dpi.Mapping = "stock_type"
      dpi.Value = Me.EntityId
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)
      '--สำหรับไว้สร้าง relation ใน schema--=============

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
        'ReceivePersonId
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePersonId"
        dpi.Value = Me.ToCostCenterPerson.Id
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.Person
        dpiColl.Add(dpi)

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

      'Mapping การอนุมัติ #917
      Dim appIdLevelHs1 As New Hashtable
      Dim appIdLevelHs2 As New Hashtable
      Dim appTable As DataTable = BusinessEntity.GetApprovePersonListfromDoc(Me.Id, Me.EntityId)
      If appTable.Rows.Count > 0 Then
        For Each row As DataRow In appTable.Rows
          Dim deh As New DataRowHelper(row)
          If Not appIdLevelHs1.ContainsKey(deh.GetValue(Of Integer)("apvdoc_level").ToString) Then
            appIdLevelHs1.Add(deh.GetValue(Of Integer)("apvdoc_level").ToString, row)
          Else
            appIdLevelHs1(deh.GetValue(Of Integer)("apvdoc_level").ToString) = row
          End If
        Next

        For Each row As DataRow In appIdLevelHs1.Values 'appTable.Rows
          Dim deh As New DataRowHelper(row)
          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonNameLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_name")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonCodeLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_code")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonInfoLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_name") & ":" & deh.GetValue(Of String)("user_code")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonDateLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of Date)("apvdate").ToShortDateString
          dpi.DataType = "System.DateTime"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonInfoLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("apvdoc_comment").ToString
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        Next

      End If

      Dim LastLevelApprove As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        'If ap.Level > 0 AndAlso Not ap.Reject Then
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso Not LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        For Each ap As ApproveDoc In LastLevelApprove
          If Not ap.Reject Then
            If Not appIdLevelHs2.ContainsKey(ap.Level.ToString) Then
              appIdLevelHs2.Add(ap.Level.ToString, ap)
            Else
              appIdLevelHs2(ap.Level.ToString) = ap
            End If
          End If
        Next
        For Each ap As ApproveDoc In appIdLevelHs2.Values 'LastLevelApprove
          If Not ap.Reject Then
            dpi = New DocPrintingItem
            dpi.Mapping = "ApprovePersonIdLevel " & ap.Level.ToString
            dpi.Value = ap.Originator
            dpi.DataType = "System.String"
            dpi.SignatureType = SignatureType.ApprovePerson
            dpiColl.Add(dpi)
          End If
        Next

        'Authorizeid
        dpi = New DocPrintingItem
        dpi.Mapping = "AuthorizeId"
        If Me.IsApproved Then
          dpi.Value = Me.ApprovePerson.Id
        Else
          dpi.Value = 0
        End If
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.AuthorizedPerson
        dpiColl.Add(dpi)
      End If



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
      dpi.DataType = "System.String"
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
      Dim sequence As Integer = 0
      For Each item As GoodsReceiptItem In Me.ItemCollection

        '--สำหรับไว้สร้าง relation ใน schema--=============
        'stocki_stock
        dpi = New DocPrintingItem
        dpi.Mapping = "stocki_stock"
        dpi.Value = Me.Id
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        '--สำหรับไว้สร้าง relation ใน schema--=============

        'Item.Sequence
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Sequence"
        If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
          sequence += 1
          dpi.Value = sequence
        Else
          dpi.Value = ""
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

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

          'Item.UnitNet
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitNet"
          If item.UnitNet = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitNet, DigitConfig.UnitPrice)
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

          '#########################################REMAIN#################################################
          Dim remainQty As Decimal = 0
          If Not item.POitem Is Nothing Then
            Dim receiveQty As Decimal = 0
            'If Me.POitem.ReceivedQty <> Decimal.MinValue Then
            'receiveQty = Me.POitem.ReceivedQty ' หน่วยตาม PO
            receiveQty = (item.Qty * item.Conversion) / item.POitem.Conversion
            'End If
            If item.POitem.Conversion <> 0 Then
              If item.Conversion <> 0 Then
                Select Case item.POitem.ItemType.Value
                  Case 160, 162
                  Case Else
                    remainQty = (((item.POitem.Qty - item.POitem.ReceivedQty) - receiveQty) * item.POitem.Conversion) / item.Conversion
                End Select
              End If
            End If
          End If
          '##########################################################################################

          'Item.RemainingQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.RemainingQty"
          dpi.Value = Configuration.FormatToString(remainQty, DigitConfig.Price)
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

        Dim hashWBS As New Hashtable
        Dim hashWBSItem As New Hashtable
        Dim key As String = ""
        Dim itemKey As String = ""

        If item.WBSDistributeCollection.Count > 0 Then
          'Populate ให้คำนวณคงเหลือแบบหลอกๆ
          'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
          If item.WBSDistributeCollection.Count = 1 Then

            key = item.WBSDistributeCollection.Item(0).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Id.ToString & ":" & item.AllocationType
            itemKey = item.WBSDistributeCollection.Item(0).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Id.ToString & ":" & item.Description & ":" & item.AllocationType

            'Amount -----------------------------------------------------
            If Not hashWBS.Contains(key) Then
              item.WBSDistributeCollection.Item(0).RemainSummary = item.WBSDistributeCollection.Item(0).BudgetRemain - (item.WBSDistributeCollection.Item(0).Amount + item.WBSDistributeCollection.Item(0).ChildAmount)
              hashWBS(key) = item.WBSDistributeCollection.Item(0)
            Else
              Dim parWBS As WBSDistribute = CType(hashWBS(key), WBSDistribute)
              item.WBSDistributeCollection.Item(0).RemainSummary = parWBS.RemainSummary - (item.WBSDistributeCollection.Item(0).Amount + item.WBSDistributeCollection.Item(0).ChildAmount)
              CType(hashWBS(key), WBSDistribute).RemainSummary = item.WBSDistributeCollection.Item(0).RemainSummary
            End If
            'Qty --------------------------------------------------------
            If Not hashWBSItem.Contains(itemKey) Then
              item.WBSDistributeCollection.Item(0).QtyRemainSummary = item.WBSDistributeCollection.Item(0).QtyRemain - item.WBSDistributeCollection.Item(0).Qty
              hashWBSItem(itemKey) = item.WBSDistributeCollection.Item(0)
            Else
              Dim parWBS As WBSDistribute = CType(hashWBSItem(itemKey), WBSDistribute)
              item.WBSDistributeCollection.Item(0).QtyRemainSummary = parWBS.QtyRemainSummary - item.WBSDistributeCollection.Item(0).Qty
              CType(hashWBSItem(itemKey), WBSDistribute).QtyRemainSummary = item.WBSDistributeCollection.Item(0).QtyRemainSummary
            End If

            WBSCCCode = item.WBSDistributeCollection.Item(0).CostCenter.Code
            WBSCCName = item.WBSDistributeCollection.Item(0).CostCenter.Name
            WBSCCInfo = item.WBSDistributeCollection.Item(0).CostCenter.Code & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Name
            WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
            WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
            WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price) & ")"
            WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).RemainSummary, DigitConfig.Price)
            WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemainSummary, DigitConfig.Price)
          Else
            Dim i As Integer
            For i = 0 To item.WBSDistributeCollection.Count - 1

              key = item.WBSDistributeCollection.Item(i).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(i).CostCenter.Id.ToString & ":" & item.AllocationType
              itemKey = item.WBSDistributeCollection.Item(i).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(i).CostCenter.Id.ToString & ":" & item.Description & ":" & item.AllocationType

              'Amount -----------------------------------------------------
              If Not hashWBS.Contains(key) Then
                item.WBSDistributeCollection.Item(i).RemainSummary = item.WBSDistributeCollection.Item(i).BudgetRemain - (item.WBSDistributeCollection.Item(i).Amount + item.WBSDistributeCollection.Item(i).ChildAmount)
                hashWBS(key) = item.WBSDistributeCollection.Item(i)
              Else
                Dim parWBS As WBSDistribute = CType(hashWBS(key), WBSDistribute)
                item.WBSDistributeCollection.Item(i).RemainSummary = parWBS.RemainSummary - (item.WBSDistributeCollection.Item(i).Amount + item.WBSDistributeCollection.Item(i).ChildAmount)
                CType(hashWBS(key), WBSDistribute).RemainSummary = item.WBSDistributeCollection.Item(i).RemainSummary
              End If
              'Qty --------------------------------------------------------
              If Not hashWBSItem.Contains(itemKey) Then
                item.WBSDistributeCollection.Item(i).QtyRemainSummary = item.WBSDistributeCollection.Item(i).QtyRemain - item.WBSDistributeCollection.Item(i).Qty
                hashWBSItem(itemKey) = item.WBSDistributeCollection.Item(i)
              Else
                Dim parWBS As WBSDistribute = CType(hashWBSItem(itemKey), WBSDistribute)
                item.WBSDistributeCollection.Item(i).QtyRemainSummary = parWBS.QtyRemainSummary - item.WBSDistributeCollection.Item(i).Qty
                CType(hashWBSItem(itemKey), WBSDistribute).QtyRemainSummary = item.WBSDistributeCollection.Item(i).QtyRemainSummary
              End If

              WBSCCCode &= item.WBSDistributeCollection.Item(i).CostCenter.Code
              WBSCCName &= item.WBSDistributeCollection.Item(i).CostCenter.Name
              WBSCCInfo &= item.WBSDistributeCollection.Item(i).CostCenter.Code & ":" & item.WBSDistributeCollection.Item(i).CostCenter.Name
              WBSCode &= item.WBSDistributeCollection.Item(i).WBS.Code
              WBSCodePercent &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Percent, DigitConfig.Price) & "%)"
              WBSCodeAmount &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Amount, DigitConfig.Price) & ")"
              WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).RemainSummary, DigitConfig.Price)
              WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).QtyRemainSummary, DigitConfig.Price)
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

            '--สำหรับไว้สร้าง relation ใน schema--=============
            'wht_refdoc
            dpi = New DocPrintingItem
            dpi.Mapping = "wht_refdoc"
            dpi.Value = Me.Id
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "WHTItem"
            dpiColl.Add(dpi)

            'wht_refdoc
            dpi = New DocPrintingItem
            dpi.Mapping = "wht_refdoctype"
            dpi.Value = Me.EntityId
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "WHTItem"
            dpiColl.Add(dpi)
            '--สำหรับไว้สร้าง relation ใน schema--=============

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
        Return Not Me.Status.Value = 0
      End Get
    End Property

    Public Function UnApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.UnApproveData

    End Function

    Public ReadOnly Property UnApproveIcon() As String Implements IApprovAble.UnApproveIcon
      Get

      End Get
    End Property
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

        Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId)
        mldoc.DocMethod = SaveDocMultiApprovalMethod.Delete
        Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, trans)
        If Not IsNumeric(savemldocError.Message) Then
          trans.Rollback()
          Return savemldocError
        End If

        'Dim cmd As String = Me.GetGRCommandActual
        'If cmd.Length > 0 Then
        '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, cmd)
        '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_OnlyUpdateGRWBSChildActual")
        'End If

        trans.Commit()

        SaveWBSActual(conn)

        'If Me.Po.Originated Then
        Dim poIdList As String = String.Join(",", poIdArrayList.ToArray)
        BusinessLogic.PO.UpdateReferencePOGeneralList(conn, poIdList)
        BusinessLogic.PO.UpdateGRReferencePOGeneralList(conn, poIdList)
        'End If

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

#Region "IWBSAllocatable"
    Public Property FromCostCenter As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get

      End Get
      Set(ByVal value As CostCenter)

      End Set
    End Property

    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As GoodsReceiptItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0
              wbsd.GetChildIdList()
              For Each allItem As GoodsReceiptItem In Me.ItemCollection
                For Each childWbsd As WBSDistribute In allItem.WBSDistributeCollection
                  If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                    wbsd.ChildAmount += childWbsd.Amount
                  End If
                Next
              Next
            Next
          End If

          coll.Add(item)
        End If
      Next

      Return coll
    End Function
    Public ReadOnly Property AllowWBSAllocateFrom As Boolean Implements IWBSAllocatable.AllowWBSAllocateFrom
      Get
        Return False
      End Get
    End Property

    Public ReadOnly Property AllowWBSAllocateTo As Boolean Implements IWBSAllocatable.AllowWBSAllocateTo
      Get
        Return True
      End Get
    End Property
#End Region

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      'เวลา Copy ให้เอา CustomNote จากอันปัจจุบันมาเก็บไว้ก่อน
      'Me.m_customNoteColl = New CustomNoteCollection(Me)

      Me.Status.Value = -1
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Code = "Copy of " & Me.Code
      Me.ApproveDate = Date.MinValue
      Me.ApprovePerson = New User
      Me.Canceled = False
      Me.CancelPerson = New User
      Me.DocType = Me.DocType

      'Not Reference PO ============================================
      Me.m_po = New PO

      'Me.Closing = False
      'Me.Closed = False
      MyBase.ClearReference()
      'Me.ClearReference()

      Me.m_whtcol = New WitholdingTaxCollection(Me)
      Me.m_whtcol.Direction = New WitholdingTaxDirection(1)

      Me.m_advancePayItemColl = New AdvancePayItemCollection(Me)

      Me.m_vat = New Vat(Me)
      Me.m_vat.Direction.Value = 1

      Me.m_je = New JournalEntry(Me)
      Me.m_je.DocDate = Me.m_docDate

      Me.m_payment = New Payment(Me)
      Me.m_payment.DocDate = Me.m_je.DocDate
      '----------------------------End Tab Entities-----------------------------------------
      Me.m_asset = New Asset

      Dim wbsdummy As WBS
      For Each item As GoodsReceiptItem In Me.ItemCollection
        If item.ItemType.Value <> 160 Or item.ItemType.Value <> 162 Then
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsdummy = wbsd.WBS
            wbsd.WBS = wbsdummy
          Next

          'Not Reference PO =============================================
          item.POitem = New POItem
          item.POitem = Nothing
        End If
      Next
      Return Me
    End Function
#End Region

#Region "Event"
    Public Event AdvanceClick(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

    '==============CURRENCY=================================
#Region "IHasCurrency"
    Private m_currency As Currency
    Public Property Currency As Currency Implements IHasCurrency.Currency
      Get
        If m_currency Is Nothing Then
          m_currency = Currency.DefaultCurrency.Clone
        End If
        Return m_currency
      End Get
      Set(ByVal value As Currency)
        m_currency = value
      End Set
    End Property
#End Region
    '==============CURRENCY=================================
#Region "IApproveStatusAble"
    Public ReadOnly Property IsAuthorized As Boolean Implements IApproveStatusAble.IsAuthorized
      Get
        Return Me.IsApproved
      End Get
    End Property

    Public ReadOnly Property IsLevelApproved As Boolean Implements IApproveStatusAble.IsLevelApproved
      Get
        If Not Me.ApproveDocColl Is Nothing AndAlso Me.ApproveDocColl.Count > 0 Then
          Dim approveDoc As ApproveDoc = m_approveDocColl(ApproveDocColl.Count - 1)
          If Not approveDoc Is Nothing Then
            If Not approveDoc.Reject AndAlso approveDoc.Level > 0 Then
              Return True
            End If
          End If
        End If

        Return False
      End Get
    End Property

    Public ReadOnly Property IsReject As Boolean Implements IApproveStatusAble.IsReject
      Get
        If Not Me.ApproveDocColl Is Nothing AndAlso Me.ApproveDocColl.Count > 0 Then
          Dim approveDoc As ApproveDoc = m_approveDocColl(ApproveDocColl.Count - 1)
          If Not approveDoc Is Nothing Then
            Return approveDoc.Reject
          End If
        End If

        Return False
      End Get
    End Property
#End Region

#Region "ICloseStatusAble"
    Public Property Closed As Boolean Implements ICloseStatusAble.Closed
      Get

      End Get
      Set(ByVal value As Boolean)

      End Set
    End Property
#End Region

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.RelationList.Add("general>stock_id>item>stocki_stock")

      dpiColl.RelationList.Add("general>stock_id>ApprovePerson>ApprovePersonNo")

      dpiColl.RelationList.Add("general>stock_id>ApproveLastPerson>ApproveLastPersonNo")

      dpiColl.RelationList.Add("general>stock_id>WHTItem>wht_refdoc")
      dpiColl.RelationList.Add("general>stock_type>WHTItem>wht_refdoctype")


      '--สำหรับไว้สร้าง relation ใน schema--=============
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stock_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stock_type", "System.String"))
      '--สำหรับไว้สร้าง relation ใน schema--=============
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DueDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("VatCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("VatDocDate", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DeliveryDocCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DeliveryDocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToAccountType", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PaymentAmount", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PaymentGross", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("POCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PODocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PRCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierPhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierFax", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierContact", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierCurrentAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierNote", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterPhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterFax", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivePersonId", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivePersonInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivePersonCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivePersonName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AuthorizeId", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreditPeriod", "System.Int32"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Gross", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DiscountRate", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AdvancePay", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BeforeTax", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TaxBase", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DiscountAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AfterDiscountAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AdvanceAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AfterAdvanceAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Retention", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AfterRetentionAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TaxAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AfterTax", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastPageGross", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastPageDiscountRate", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastPageDiscountAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastPageAdvancePay", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastPageBeforeTax", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastPageTaxAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastPageAfterTax", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastPageAfterTaxText", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ItemString", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("WHTTotalAmount", "System.String"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonNo", "System.String", "ApprovePerson"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonName", "System.String", "ApprovePerson"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonCode", "System.String", "ApprovePerson"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonInfo", "System.String", "ApprovePerson"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonDate", "System.DateTime", "ApprovePerson"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonInfo", "System.String", "ApprovePerson"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApproveLastPersonNo", "System.String", "ApproveLastPerson"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApproveLastPersonId", "System.String", "ApproveLastPerson"))

      '--สำหรับไว้สร้าง relation ใน schema--=============
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stocki_stock", "System.String", "Item"))
      '--สำหรับไว้สร้าง relation ใน schema--=============
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Sequence", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitInfo", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPrice", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitNet", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.DiscountRate", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.DiscountAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.RemainingQty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ZeroVat", "System.Boolean", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCCCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCCName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCCInfo", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodePercent", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodeAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainQty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Quality", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.AccountCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.AccountName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnVatable", "System.String", "Item"))

      '--สำหรับไว้สร้าง relation ใน schema--=============
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("wht_refdoc", "System.String", "WHTItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("wht_refdoctype", "System.String", "WHTItem"))
      '--สำหรับไว้สร้าง relation ใน schema--=============
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("WHTItem.WHTDate", "System.String", "WHTItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("WHTItem.WHTCode", "System.String", "WHTItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("WHTItem.WHTType", "System.String", "WHTItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("WHTItem.WHTDescription", "System.String", "WHTItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("WHTItem.WHTTaxBase", "System.String", "WHTItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("WHTItem.WHTTaxRate", "System.String", "WHTItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("WHTItem.WHTAmount", "System.String", "WHTItem"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region
#Region "IDocStatus"
    Public ReadOnly Property DocStatus As String Implements IDocStatus.DocStatus
      Get
        If Me.Status.Value = 0 Then
          Return "Canceled"
        Else
          Dim obj As Object = Configuration.GetConfig("ApproveDO")
          If CBool(obj) Then
            If Me.IsAuthorized Then
              Return "Authorized"
            ElseIf Me.IsLevelApproved Then
              Return "Approved"
            ElseIf Me.IsReject Then
              Return "Reject"
            End If
          End If
        End If
        Return ""
      End Get
    End Property
#End Region

#Region "IDocumentPersonAble"

    ReadOnly Property DocumentEditedUser As DocumentEditedUser Implements IDocumentPersonAble.DocumentEditedUser
      Get
        Dim m_documentEditedUser As New DocumentEditedUser

        m_documentEditedUser.ApprovedUserList = Me.GetApprovedUserList
        m_documentEditedUser.ApprovedUser = Me.GetApprovedUser
        m_documentEditedUser.AuthorizedUser = Me.GetAutherizedUser
        m_documentEditedUser.CanceledUser = Me.GetCanceledUser
        m_documentEditedUser.CreatedUser = Me.GetCreatedUser
        m_documentEditedUser.EditedUser = Me.GetEditedUser
        m_documentEditedUser.EditedUser = Me.GetRejectUser
        m_documentEditedUser.Employee = Me.ToCostCenterPerson

        Return m_documentEditedUser
      End Get
    End Property

    Private Function GetApprovedUserList() As List(Of ApproveDoc)
      Dim LastLevelApprove As New List(Of ApproveDoc)
      Dim aProvePerson As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso Not LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        For Each ap As ApproveDoc In LastLevelApprove
          If Not ap.Reject Then
            aProvePerson.Add(ap)
          End If
        Next
      End If

      Return aProvePerson
    End Function

    Public Function GetApprovedUser() As EditedUser
      Dim aplist As List(Of ApproveDoc) = Me.GetApprovedUserList
      Dim editeduser As New EditedUser
      If aplist.Count > 1 Then
        Dim userHs As New Hashtable
        Dim maxLevel As Integer = 0
        For Each doc As ApproveDoc In aplist
          userHs(doc.Level) = doc
          maxLevel = Math.Max(maxLevel, doc.Level)
        Next
        'Return New User(CType(userHs(maxLevel - 1), ApproveDoc).Originator)
        If Not userHs(maxLevel - 1) Is Nothing Then
          editeduser.UserId = CType(userHs(maxLevel - 1), ApproveDoc).Originator
          editeduser.UserName = New User(CType(userHs(maxLevel - 1), ApproveDoc).Originator).Name
          editeduser.EditedDate = CType(userHs(maxLevel - 1), ApproveDoc).OriginDate
          Return editeduser
        End If

      End If
      If aplist.Count > 0 Then
        'Return New User(aplist.Item(aplist.Count - 1).Originator)
        editeduser.UserId = aplist.Item(aplist.Count - 1).Originator
        editeduser.UserName = New User(aplist.Item(aplist.Count - 1).Originator).Name
        editeduser.EditedDate = aplist.Item(aplist.Count - 1).OriginDate
      End If
      Return editeduser
    End Function

    Public Function GetAutherizedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Me.ApprovePerson Is Nothing Then
        editeduser.UserId = Me.ApprovePerson.Id
        editeduser.UserName = Me.ApprovePerson.Name
        editeduser.EditedDate = Me.ApproveDate
      End If
      Return editeduser
    End Function

    Public Function GetCanceledUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Me.CancelPerson Is Nothing Then
        editeduser.UserId = Me.CancelPerson.Id
        editeduser.UserName = Me.CancelPerson.Name
        editeduser.EditedDate = Me.CancelDate
      End If
      Return editeduser
    End Function

    Public Function GetCreatedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Originator Is Nothing Then
        editeduser.UserId = Me.Originator.Id
        editeduser.UserName = Me.Originator.Name
        editeduser.EditedDate = Me.OriginDate
      End If
      Return editeduser
    End Function

    Public Function GetEditedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not LastEditor Is Nothing Then
        editeduser.UserId = Me.LastEditor.Id
        editeduser.UserName = Me.LastEditor.Name
        editeduser.EditedDate = Me.LastEditDate
      End If
      Return editeduser
    End Function

    Public Function GetRejectUser() As EditedUser
      Dim editeduser As New EditedUser
      Dim LastLevelApprove As New List(Of ApproveDoc)
      Dim aProvePerson As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        editeduser.UserId = LastLevelApprove.Item(LastLevelApprove.Count - 1).Originator
        editeduser.UserName = New User(LastLevelApprove.Item(LastLevelApprove.Count - 1).Originator).Name
        editeduser.EditedDate = LastLevelApprove.Item(LastLevelApprove.Count - 1).OriginDate
      End If
      Return editeduser
    End Function

#End Region

  End Class

  Public Class GoodsReceiptForApprove
    Inherits GoodsReceipt
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "GoodsReceiptForApprove"
      End Get
    End Property
  End Class

  Public Class GoodsReceiptForOperation
    Inherits GoodsReceipt
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "GoodsReceiptForOperation"
      End Get
    End Property
    Public Overrides ReadOnly Property FullClassNameForSecurity() As String
      Get
        Return Me.Namespace & "." & Me.CodonName
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

  Public Enum UnlockType
    Non
    UnlockAll
    UnlockLevel1
    Locked
  End Enum

End Namespace

