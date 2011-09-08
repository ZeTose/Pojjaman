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
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class OldNew
    Public OldValue As Decimal
    Public NewValue As Decimal
  End Class
  Public Class PO
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IApprovAble, ICancelable, IHasIBillablePerson, IHasToCostCenter _
      , IDuplicable, ICheckPeriod, IWBSAllocatable _
      , IHasCurrency, IAbleExceptAccountPeriod, ICloseStatusAble, IApproveStatusAble, IShowStatusColorAble

#Region "Members"
    Private m_supplier As Supplier
    Private m_docDate As Date
    Private m_receivingDate As Date
    Private m_note As String
    Private m_creditPeriod As Integer
    Private m_discount As Discount
    Private m_taxRate As Decimal
    Private m_taxType As TaxType

    Private m_approvePerson As User
    Private m_approveDate As DateTime
    Private m_status As POStatus

    Private m_cc As CostCenter
    Private m_requestor As Employee

    Public Group As Boolean = False

    Private m_retention As Decimal
    Private m_retentionNote As String
    Private m_termNote As String
    Private m_deliveryTime As String
    Private m_placeOfDelivery As String
    Private m_contact As String
    Private m_attachment As String
    Private m_specialCondition As String

    Private m_closed As Boolean
    Private m_closedBefor As Boolean
    Private m_useTerm As Boolean

    Private m_realTaxBase As Decimal
    Private m_realGross As Decimal
    Private m_realTaxAmount As Decimal

    Private m_itemCollection As POItemCollection

    Private m_customNoteColl As CustomNoteCollection

    Private m_approveDocColl As ApproveDocCollection

    'Public BOQHASH As Hashtable
    Private m_remainDiscAmt As Discount

    Public MatActualHash As Hashtable
    Public LabActualHash As Hashtable
    Public EQActualHash As Hashtable
    Private m_deliveryAddressColl As Hashtable
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
        .m_approvePerson = New User
        .m_supplier = New Supplier
        .m_requestor = New Employee
        .m_creditPeriod = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_discount = New Discount("")
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        .m_docDate = Now.Date
        .m_receivingDate = Now.Date.AddDays(3).Date
        .m_approveDate = Date.MinValue
        .m_cc = New CostCenter
        .m_status = New POStatus(-1)
        .m_termNote = ""
        .m_deliveryTime = ""
        .m_placeOfDelivery = ""
        .m_useTerm = False
        '.m_attachment = "..............................................................."
        '.m_specialCondition = "..............................................................."
        .m_remainDiscAmt = New Discount("")
        .m_closed = False
        .m_closedBefor = False
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      MatActualHash = New Hashtable
      LabActualHash = New Hashtable
      EQActualHash = New Hashtable
      m_itemCollection = New POItemCollection(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
      m_deliveryAddressColl = GetPOPlaceDelivery()
      'm_itemCollection.RefreshBudget()
      'Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        ' DocDate
        If Not dr.IsNull(aliasPrefix & "po_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "po_docDate"))
        End If
        ' Note
        If Not dr.IsNull(aliasPrefix & "po_note") Then
          .m_note = CStr(dr(aliasPrefix & "po_note"))
        End If

        'TermNote
        If Not dr.IsNull(aliasPrefix & "po_termnote") Then
          .m_termNote = CStr(dr(aliasPrefix & "po_termnote"))
        End If

        'Delivery Time
        If Not dr.IsNull(aliasPrefix & "po_deliverytime") Then
          .m_deliveryTime = CStr(dr(aliasPrefix & "po_deliverytime"))
        End If

        'Place Of Delivery
        If Not dr.IsNull(aliasPrefix & "po_placeofdelivery") Then
          .m_placeOfDelivery = CStr(dr(aliasPrefix & "po_placeofdelivery"))
        End If

        'Discount Rate
        If Not dr.IsNull(aliasPrefix & "po_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "po_discrate")))
        End If
        ' Receiving Date
        If Not dr.IsNull(aliasPrefix & "po_receivingDate") Then
          .m_receivingDate = CDate(dr(aliasPrefix & "po_receivingDate"))
        End If
        ' Approved Date
        If Not dr.IsNull(aliasPrefix & "po_approveDate") Then
          .m_approveDate = CDate(dr(aliasPrefix & "po_approveDate"))
        End If
        'Supplier
        If dr.Table.Columns.Contains("supplier.supplier_id") Then
          If Not dr.IsNull("supplier.supplier_id") Then
            .m_supplier = New Supplier(CInt(dr("supplier.supplier_id")))
            '.m_supplier = New Supplier(CInt(dr("supplier.supplier_id")))
            '.m_supplier = New Supplier(dr, "supplier.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "po_supplier") Then
            .m_supplier = New Supplier(CInt(dr(aliasPrefix & "po_supplier")))
          End If
        End If
        'Delivery Address
        m_deliveryAddressColl = GetPOPlaceDelivery()
        'Cost Center
        If dr.Table.Columns.Contains("cc_id") Then
          If Not dr.IsNull("cc_id") Then
            .m_cc = New CostCenter(dr, "")

            m_deliveryAddressColl(0) = m_cc.Address
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "po_cc") Then
            .m_cc = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "po_cc")))

            m_deliveryAddressColl(0) = m_cc.Address
          End If
        End If

        'Requestor
        If dr.Table.Columns.Contains(aliasPrefix & "requestor.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "requestor.employee_id") Then
            .m_requestor = New Employee(dr, aliasPrefix & "requestor.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "po_employee") AndAlso _
          Not dr.IsNull(aliasPrefix & "po_employee") Then
            .m_requestor = Employee.GetEmployeeById(CInt(dr(aliasPrefix & "po_employee")))
            '.m_requestor = New Employee(CInt(dr(aliasPrefix & "po_employee")))
          End If
        End If

        ' ApprovePerson
        If dr.Table.Columns.Contains("approvePerson.user_id") Then
          If Not dr.IsNull("approvePerson.user_id") Then
            .m_approvePerson = New User(dr, "approvePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "po_approvePerson") Then
            .m_approvePerson = New User(CInt(dr(aliasPrefix & "po_approvePerson")))
          End If
        End If
        'Credit Period
        If dr.Table.Columns.Contains(aliasPrefix & "po_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "po_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "po_creditperiod"))
        End If
        ' PO Status
        If dr.Table.Columns.Contains(aliasPrefix & "po_status") AndAlso Not dr.IsNull(aliasPrefix & "po_status") Then
          .m_status = New POStatus(CInt(dr(aliasPrefix & "po_status")))
        End If
        ' TaxType
        If dr.Table.Columns.Contains(aliasPrefix & "po_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "po_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "po_taxtype")))
        End If
        ' PO Tax Rate
        If Not dr.IsNull(aliasPrefix & "po_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "po_taxrate"))
        End If

        'Retention
        If dr.Table.Columns.Contains(aliasPrefix & "po_retention") AndAlso Not dr.IsNull(aliasPrefix & "po_retention") Then
          .m_retention = CDec(dr(aliasPrefix & "po_retention"))
        End If

        'RetentionNote
        If dr.Table.Columns.Contains(aliasPrefix & "po_retentionnote") AndAlso Not dr.IsNull(aliasPrefix & "po_retentionnote") Then
          .m_retentionNote = CStr(dr(aliasPrefix & "po_retentionnote"))
        End If

        'Contact
        If dr.Table.Columns.Contains(aliasPrefix & "po_contact") AndAlso Not dr.IsNull(aliasPrefix & "po_contact") Then
          .m_contact = CStr(dr(aliasPrefix & "po_contact"))
        End If
        'Special Condition
        If dr.Table.Columns.Contains(aliasPrefix & "po_specialCondition") AndAlso Not dr.IsNull(aliasPrefix & "po_specialCondition") Then
          .m_specialCondition = CStr(dr(aliasPrefix & "po_specialCondition"))
        End If
        'Attachment
        If dr.Table.Columns.Contains(aliasPrefix & "po_attachment") AndAlso Not dr.IsNull(aliasPrefix & "po_attachment") Then
          .m_attachment = CStr(dr(aliasPrefix & "po_attachment"))
        End If

        'Closing Status
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_closed") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_closed") Then
          .m_closed = CBool(dr(aliasPrefix & Me.Prefix & "_closed"))
          .m_closedBefor = .m_closed
        Else
          .m_closed = False
          .m_closedBefor = .m_closed
        End If

        'Use Term
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_useTerm") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_useTerm") Then
          .m_useTerm = CBool(dr(aliasPrefix & Me.Prefix & "_useTerm"))
        End If

        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "po_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "po_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "po_taxbase"))
        End If

        ' Gross
        If dr.Table.Columns.Contains(aliasPrefix & "po_gross") _
        AndAlso Not dr.IsNull(aliasPrefix & "po_gross") Then
          .m_realGross = CDec(dr(aliasPrefix & "po_gross"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "po_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "po_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "po_taxamt"))
        End If

        ' Remainning Discount Amount
        If dr.Table.Columns.Contains(aliasPrefix & "poRemain_discAmt") _
        AndAlso Not dr.IsNull(aliasPrefix & "poRemain_discAmt") Then
          Dim remaindisc As Decimal = 0
          If IsNumeric(dr.IsNull(aliasPrefix & "poRemain_discAmt")) Then
            remaindisc = CDec(dr(aliasPrefix & "poRemain_discAmt"))
          End If
          If remaindisc = 0 Then
            .m_remainDiscAmt = New Discount("")
          Else
            '.m_remainDiscAmt = New Discount(Configuration.FormatToString(remaindisc, DigitConfig.Price))
            .m_remainDiscAmt = New Discount(remaindisc.ToString)
          End If
        End If
        '--------------------END REAL-------------------------

      End With
      MatActualHash = New Hashtable
      LabActualHash = New Hashtable
      EQActualHash = New Hashtable
      m_itemCollection = New POItemCollection(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
      'm_itemCollection.RefreshBudget()

      '==============CURRENCY=================================
      BusinessLogic.Currency.SetCurrencyFromDB(Me)
      '==============CURRENCY=================================
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
    Public ReadOnly Property ExceptAccountPeriod As Boolean Implements IAbleExceptAccountPeriod.ExceptAccountPeriod
      Get
        Return Me.Closed
      End Get
    End Property
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
        m_realGross = Value
      End Set
    End Property
    Public Property RealTaxAmount() As Decimal
      Get
        Return m_realTaxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxAmount = Value
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
    Public Property Closed() As Boolean Implements ICloseStatusAble.Closed
      Get
        Return m_closed
      End Get
      Set(ByVal Value As Boolean)
        m_closed = Value
        'ยกเลิกการปิด
        If m_closedBefor AndAlso Not m_closed Then
          For Each item As POItem In ItemCollection
            item.Qty = item.OriginQty
          Next
        End If
      End Set
    End Property
    Public Property ClosedBefor() As Boolean
      Get
        Return m_closedBefor
      End Get
      Set(ByVal Value As Boolean)
        m_closedBefor = Value
      End Set
    End Property
    Public Property UseTerm() As Boolean
      Get
        Return m_useTerm
      End Get
      Set(ByVal Value As Boolean)
        m_useTerm = Value
      End Set
    End Property
    Public Property Contact() As String
      Get
        Return m_contact
      End Get
      Set(ByVal Value As String)
        m_contact = Value
      End Set
    End Property
    Public Property Attachment() As String
      Get
        Return m_attachment
      End Get
      Set(ByVal Value As String)
        m_attachment = Value
      End Set
    End Property
    Public Property SpecialCondition() As String
      Get
        Return m_specialCondition
      End Get
      Set(ByVal Value As String)
        m_specialCondition = Value
      End Set
    End Property
    Public Property TermNote() As String
      Get
        Return m_termNote
      End Get
      Set(ByVal Value As String)
        m_termNote = Value
      End Set
    End Property
    Public Property DeliveryTime() As String
      Get
        Return m_deliveryTime
      End Get
      Set(ByVal Value As String)
        m_deliveryTime = Value
      End Set
    End Property
    Public Property PlaceOfDelivery() As String
      Get
        Return m_placeOfDelivery
      End Get
      Set(ByVal Value As String)
        m_placeOfDelivery = Value
      End Set
    End Property
    Public Property ItemCollection() As POItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As POItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property Supplier() As Supplier Implements IWBSAllocatable.Supplier
      Get
        Return m_supplier
      End Get
      Set(ByVal Value As Supplier)
        m_supplier = Value
        Me.CreditPeriod = m_supplier.CreditPeriod
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Requestor() As Employee
      Get
        Return m_requestor
      End Get
      Set(ByVal Value As Employee)
        m_requestor = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property CostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
        If Not m_cc Is Nothing AndAlso m_cc.Originated Then
          Dim key As String = m_cc.Address
          m_deliveryAddressColl(0) = key
        End If
      End Set
    End Property
    Public ReadOnly Property DeliveryAddressCollection() As Hashtable
      Get
        Return m_deliveryAddressColl
      End Get
    End Property

    Public Function GetCCFromPR() As CostCenter
      Dim dummyCC As CostCenter = Nothing
      For Each myPr As PR In Me.ItemCollection.PRHASH.Values
        Dim cc As CostCenter = myPr.CostCenter
        If Not dummyCC Is Nothing AndAlso dummyCC.Id <> cc.Id Then
          Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        dummyCC = cc
      Next
      Return dummyCC
    End Function

    '==============CURRENCY=================================
    Public Function GetCurrencyFromPR() As Currency
      Dim dummyCurrency As Currency = BusinessLogic.Currency.DefaultCurrency
      For Each myPr As PR In Me.ItemCollection.PRHASH.Values
        Dim cc As Currency = myPr.Currency
        If Not dummyCurrency Is Nothing AndAlso Not cc.Equals(dummyCurrency) Then
          Return BusinessLogic.Currency.DefaultCurrency
        End If
        dummyCurrency = cc
      Next
      Return dummyCurrency
    End Function
    '==============CURRENCY=================================

    Public Property DocDate() As Date Implements ICheckPeriod.DocDate, IWBSAllocatable.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property ReceivingDate() As Date
      Get
        Return m_receivingDate
      End Get
      Set(ByVal Value As Date)
        m_receivingDate = Value
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
    Public Property CreditPeriod() As Integer
      Get
        Return m_creditPeriod
      End Get
      Set(ByVal Value As Integer)
        m_creditPeriod = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Retention() As Decimal
      Get
        Return m_retention
      End Get
      Set(ByVal Value As Decimal)
        m_retention = Value
      End Set
    End Property
    Public Property RetentionNote() As String
      Get
        Return m_retentionNote
      End Get
      Set(ByVal Value As String)
        m_retentionNote = Value
      End Set
    End Property
    Public ReadOnly Property DueDate() As Date
      Get
        Return Me.ReceivingDate.AddDays(Me.CreditPeriod) ' Me.DocDate.AddDays(Me.CreditPeriod)
      End Get
    End Property
    Private m_gross As Decimal
    Public ReadOnly Property Gross() As Decimal
      Get
        Return m_gross
      End Get
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
    Public Property TaxBase() As Decimal
      Get
        Return m_taxbase
      End Get
      Set(ByVal Value As Decimal)
        m_taxbase = Value
      End Set
    End Property
    Public Property TaxType() As TaxType
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
          Case 0          '"ไม่มี"
            Return 0
          Case 2          'รวม VAT
            Return Me.TaxGross - Me.DiscountWithVat - Me.RealTaxBase
          Case Else         '1 แยก
            Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)
        End Select
      End Get
    End Property
    Public ReadOnly Property BeforeTax() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0          '"ไม่มี"
            Return Me.RealGross - Me.DiscountAmount
          Case 1          '"แยก"
            Return Me.RealGross - Me.DiscountAmount
          Case 2          '"รวม"
            Return Me.AfterTax - Me.RealTaxAmount
        End Select
      End Get
    End Property
    Public ReadOnly Property AfterTax() As Decimal Implements IApprovAble.AmountToApprove
      Get
        Select Case Me.TaxType.Value
          Case 0          '"ไม่มี"
            Return Me.BeforeTax
          Case 1          '"แยก"
            Return Me.BeforeTax + Me.RealTaxAmount
          Case 2          '"รวม"
            Return Me.RealGross - Me.DiscountAmount
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
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, POStatus)
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "PO"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PO.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PO"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PO"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PO.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "po"
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
    Public Property RemainningDiscount() As Discount
      Get
        Return m_remainDiscAmt
      End Get
      Set(ByVal Value As Discount)
        m_remainDiscAmt = Value
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetPO(ByVal txtCode As TextBox, ByRef oldPO As PO) As Boolean
      Dim newPo As New PO(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not newPo.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        newPo = oldPO
        Return False
      End If
      txtCode.Text = newPo.Code
      'If oldPO Is Nothing OrElse oldPO.Id <> newPo.Id Then
      '    oldPO = newPo
      '    Return True
      'End If
      oldPO = newPo
      Return True

    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PO")
      myDatatable.Columns.Add(New DataColumn("pri_pr", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pr_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_linenumber", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("pri_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pri_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("PRItemCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PRItemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PRItemUnit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_qty", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("PRItemRemainingQty", GetType(Decimal)))


      myDatatable.Columns.Add(New DataColumn("poi_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Barrier", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("poi_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_originqty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_discrate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("poi_unvatable", GetType(Boolean)))
      Return myDatatable
    End Function
    Public Shared Function GetPO(ByVal id As Integer, ByVal viewtype As ViewType) As PO
      Dim po As New PO
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetMinPO" _
        , New SqlParameter("@po_id", id) _
          )
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Select Case viewtype
        Case viewtype.GoodsReceiptItem
          SetMinimumPO(po, dr)
      End Select
      Return po
    End Function
    Private Shared Sub SetMinimumPO(ByVal po As PO, ByVal dr As DataRow)
      Dim drh As New DataRowHelper(dr)
      po.Id = drh.GetValue(Of Integer)("po_id")
      po.Code = drh.GetValue(Of String)("po_code")
      po.DocDate = drh.GetValue(Of DateTime)("po_docdate")
      po.Supplier = New Supplier(CInt(dr("po_supplier"))) ' Supplier.GetSupplierbyDataRow(dr)
    End Sub
#End Region

#Region "Methods"
    Public Sub RefreshApproveDocCollection() Implements IApproveStatusAble.RefreshApproveDocCollection
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Public Sub UpdateNoteFromPR()
      Dim obj As Object = Configuration.GetConfig("UpdateNoteFromPR")

      If Not CBool(obj) Then
        Return
      End If

      Dim txtArray As New ArrayList
      Dim NoteSplit() As String
      If Me.Note.Length > 0 Then
        NoteSplit = Me.Note.Split(","c)
        For Each Str As String In NoteSplit
          txtArray.Add(Trim(Str))
        Next
      End If

      Dim hashpr As New Hashtable
      For Each itm As POItem In Me.ItemCollection
        Dim newpr As PR = itm.Pritem.Pr

        If Not newpr Is Nothing AndAlso Not newpr.Note Is Nothing Then
          If Not hashpr.Contains(newpr.Id) Then
            hashpr(newpr.Id) = newpr
            If newpr.Note.Trim.Length > 0 Then
              If Not txtArray.Contains(newpr.Note.Trim) Then
                txtArray.Add(newpr.Note.Trim)
              End If
            End If
          End If
        End If

      Next

      If txtArray.Count > 0 Then
        Me.Note = String.Join(", ", txtArray.ToArray)
      End If
    End Sub
    Public Function GetRetentionDeductedWithoutThisStock(ByVal stockId As Integer) As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetPORetentionDeductedWithoutThisStock" _
      , New SqlParameter("@po_id", Me.Id) _
      , New SqlParameter("@stock_id", stockId) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
    End Function
    Public Function GetPOPlaceDelivery() As Hashtable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.Text _
      , "select * from POPlaceOFDelivery" _
      )
      Dim POPlaceDeliveryArrList As New Hashtable
      ' Dim ccAddress As String = ""
      'If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then
      '  If Me.CostCenter.Address.Length > 0 Then
      '    ccAddress = Me.CostCenter.Address
      '  End If
      'End If
      'If ccAddress.Length > 0 Then
      '  POPlaceDeliveryArrList.Add(ccAddress)
      'End If
      Dim i As Integer = 1
      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        Dim key As String = drh.GetValue(Of String)("poplaceofdelivery_name")
        POPlaceDeliveryArrList(i) = key
        i += 1
      Next
      Return POPlaceDeliveryArrList
    End Function
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
              o_n.OldValue = myWbs.GetActualMat(Me, 6)
            Case 88
              o_n.OldValue = myWbs.GetActualLab(Me, 6)
            Case 89
              o_n.OldValue = myWbs.GetActualEq(Me, 6)
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
      For Each item As POItem In Me.ItemCollection
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
              Dim view As Integer = 6
              Dim transferAmt As Decimal = item.BeforeTax       'item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.Amount, isOut, view, 3)
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
      For Each item As POItem In Me.ItemCollection
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
      For Each item As POItem In Me.ItemCollection
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
              Dim view As Integer = 6
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
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
      For Each item As POItem In Me.ItemCollection
        If Not item.ItemType Is Nothing _
        AndAlso item.ItemType.Value = 42 _
        AndAlso item.Entity.Id = matId Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 6
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
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
      For Each item As POItem In Me.ItemCollection
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
              Dim view As Integer = 6
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
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
      For Each item As POItem In Me.ItemCollection
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
              Dim view As Integer = 6
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Private Function ListWbsId() As String
      Dim idList As New ArrayList
      For Each itm As POItem In Me.ItemCollection
        For Each iwbsd As WBSDistribute In itm.WBSDistributeCollection
          idList.Add(iwbsd.WBS.Id)
        Next
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
    End Function
    Private Function ValidateOverBudget() As SaveErrorException
      If Me.CostCenter.Type.Value <> 2 Then
        Return New SaveErrorException("-1")
      End If
      If Me.CostCenter.Boq Is Nothing OrElse Me.CostCenter.Boq.Id = 0 Then
        Return New SaveErrorException("-1")
      End If
      'POROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("POOverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If

      'POOverBudgetOnlyWBSAllocate
      config = Configuration.GetConfig("POOverBudgetOnlyWBSAllocate")
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
        For Each item As POItem In Me.ItemCollection
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
              Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
              Dim tBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
              Dim tActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
              Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.CostCenter.Id)
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
        For Each item As POItem In Me.ItemCollection
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            If Not hCC.ContainsKey(wbsd.CostCenter.Id) Then
              hCC(wbsd.CostCenter.Id) = wbsd
            End If
          Next
          If item.WBSDistributeCollection.GetSumPercent = 0 Then
            'สำหรับ Auto จัดสรร
            Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
            Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
            Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
            Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.CostCenter.Id)
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

        'Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
        'Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
        'Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 7) + rootWBS.GetActualLab(Me, 7) + rootWBS.GetActualEq(Me, 7))
        'Dim totalCurrentDiff As Decimal = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(0)) + _
        'Me.GetCurrentDiffForWBS(rootWBS, New ItemType(88)) + _
        'Me.GetCurrentDiffForWBS(rootWBS, New ItemType(89))
        'If totalBudget < (totalActual + totalCurrentDiff) Then
        '  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
        'End If
      End If

      Return New SaveErrorException("0")

    End Function
    Private Function ValidateItem() As SaveErrorException
      Dim key As String = ""

      For Each item As POItem In Me.ItemCollection
        If item.ItemType.Value <> 162 AndAlso item.ItemType.Value <> 160 Then
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
        End If
      Next

      Return New SaveErrorException("0")
    End Function
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
    End Sub
    Private m_DocMethod As SaveDocMultiApprovalMethod
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me

        If Not Me.Originated Then
          m_DocMethod = SaveDocMultiApprovalMethod.Save
        ElseIf Me.Status.Value = 0 Then
          m_DocMethod = SaveDocMultiApprovalMethod.Cancel
        ElseIf Me.Closed Then
          m_DocMethod = SaveDocMultiApprovalMethod.Close
        Else
          m_DocMethod = SaveDocMultiApprovalMethod.Update
        End If

        Dim docValidate As Boolean = True
        If (Me.Originated AndAlso Me.Status.Value = 0) OrElse Me.Closed Then
          docValidate = False
        End If

        If docValidate Then

          If Me.Originated Then
            If Not Me.Supplier Is Nothing Then
              If Me.Supplier.Canceled Then
                Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Me.Supplier.Code})
              End If
            End If
          End If

          Dim ValidateError As SaveErrorException = ValidateItem()
          If Not IsNumeric(ValidateError.Message) Then
            Return ValidateError
          End If
          Dim ValidateOverBudgetError As SaveErrorException
          Dim config As Integer = CInt(Configuration.GetConfig("POOverBudget"))
          Select Case config
            Case 0   'Not allow
              ValidateOverBudgetError = Me.ValidateOverBudget
              If Not IsNumeric(ValidateOverBudgetError.Message) Then
                Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.OverBudgetCannotSaved}")
                Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                Return New SaveErrorException(msgString & vbCrLf & msgString2)
              End If
            Case 1   'Warn
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
            Case 2   'Do Nothing
          End Select

        End If

        'Select Case config
        '  Case 0      'Not allow
        '    If OverBudget() Then
        '      Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.POOverBudgetCannotBeSaved}"))
        '    End If
        '  Case 1      'Warn
        '    If OverBudget() Then
        '      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        '      If Not msgServ.AskQuestion("${res:Global.Question.POOverBudgetSaveAnyway}") Then
        '        Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
        '      End If
        '    End If
        '  Case 2      'Do Nothing
        'End Select

        Me.RefreshTaxBase()
        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If
        'Dim tmpBoq As BOQ = Me.CostCenter.Boq
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@po_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)
        Dim oldcode As String

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If
        Me.RefreshTaxBase()
        oldcode = Me.Code
        If Me.AutoGen Then     'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_receivingDate", Me.ValidDateOrDBNull(Me.ReceivingDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_supplier", Me.ValidIdOrDBNull(Me.Supplier)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditperiod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.RealGross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discrate", Me.Discount.Rate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discamt", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforetax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Configuration.GetConfig("CompanyTaxRate")))    'Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_aftertax", Me.AfterTax))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approveperson", Me.ValidIdOrDBNull(Me.ApprovePerson)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approvedate", IIf(Me.ApprovePerson.Valid, theTime, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_termnote", Me.TermNote))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_deliverytime", Me.DeliveryTime))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_placeofdelivery", Me.PlaceOfDelivery))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ValidIdOrDBNull(Me.CostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_employee", ValidIdOrDBNull(Me.Requestor)))
        paramArrayList.Add(New SqlParameter("@" & "po_retention", Me.Retention))
        paramArrayList.Add(New SqlParameter("@" & "po_retentionnote", Me.RetentionNote))
        paramArrayList.Add(New SqlParameter("@" & "po_closed", Me.Closed))
        paramArrayList.Add(New SqlParameter("@" & "po_useterm", Me.UseTerm))
        paramArrayList.Add(New SqlParameter("@" & "po_contact", Me.Contact))
        paramArrayList.Add(New SqlParameter("@" & "po_attachment", Me.Attachment))
        paramArrayList.Add(New SqlParameter("@" & "po_specialcondition", Me.SpecialCondition))


        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        'เตรียมข้อมูล Detail ก่อน save
        If Me.Closed Then
          Me.ItemCollection.GetReceivedQty()
        End If

        '''''===============

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())


        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()


        '======เริ่ม trans แรก ========
        trans = conn.BeginTransaction()
        Dim oldid As Integer = Me.Id
        Dim oldautogen As Boolean
        oldcode = Me.Code
        oldautogen = Me.AutoGen
        Dim arr As New ArrayList

        Try


          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            Select Case CInt(returnVal.Value)
              Case -1, -5
                trans.Rollback()
                ResetID(oldid)
                ResetCode(oldcode, oldautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
            End Select


            '-------------------------------------------------------
            Dim pris As String = GetPritemString()
            Dim sql As String = "select * from pritem where convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) " & _
            "in (select convert(nvarchar,poi_pr) + '|' +  convert(nvarchar,poi_prilinenumber) from poitem " & _
            "where poi_po =" & Me.Id & ") or convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) in " & pris

            Dim ds As DataSet = SqlHelper.ExecuteDataset( _
            RecentCompanies.CurrentCompany.SiteConnectionString _
            , CommandType.Text _
            , sql _
            )
            For Each row As DataRow In ds.Tables(0).Rows
              Dim o As New ValueDisplayPair(row("pri_pr"), row("pri_linenumber"))
              arr.Add(o)
            Next
            '-------------------------------------------------------

            Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
            If Not IsNumeric(saveDetailError.Message) Then
              trans.Rollback()
              ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return saveDetailError
            Else
              Select Case CInt(saveDetailError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid)
                  ResetCode(oldcode, oldautogen)
                  Return saveDetailError
                Case Else
              End Select
            End If

            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid)
                  ResetCode(oldcode, oldautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              Me.ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If

            '==============CURRENCY=================================
            'Save Currency
            If Me.Originated Then
              BusinessLogic.Currency.SaveCurrency(Me, conn, trans)
            End If
            '==============CURRENCY=================================

            '==============================AUTOGEN==========================================
            Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
            If Not IsNumeric(saveAutoCodeError.Message) Then
              trans.Rollback()
              ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid)
                  ResetCode(oldcode, oldautogen)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================
            trans.Commit()

            'Main Save Pass




          Catch ex As SqlException
            trans.Rollback()
            Me.ResetID(oldid)
            ResetCode(oldcode, oldautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.ResetID(oldid)
            ResetCode(oldcode, oldautogen)
            Return New SaveErrorException(ex.ToString)

          End Try

          'Sub Save Block ===============================================================
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn, arr)
            If Not IsNumeric(subsaveerror.Message) Then
              trans.Rollback()
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If

          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          Try
            Dim subsaveerror As SaveErrorException = SubSaveDocApprove(conn, currentUserId)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try
          'Sub Save Block =================================================================

          Return New SaveErrorException(returnVal.Value.ToString)
          'Complete Save
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try

      End With
    End Function
    Private Function SubSave(ByVal conn As SqlConnection, ByVal arr As ArrayList) As SaveErrorException

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans As SqlTransaction = conn.BeginTransaction
      'Save CustomNote จากการ Copy เอกสาร
      If Not Me.m_customNoteColl Is Nothing AndAlso Me.m_customNoteColl.Count > 0 Then
        If Me.Originated Then
          Me.m_customNoteColl.EntityId = Me.Id
          Me.m_customNoteColl.Save()
        End If
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
      Try


        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePR_PORef" _
        , New SqlParameter("@po_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_PORef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_PORef" _
        ', New SqlParameter("@refto_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSReferencedFromPO", New SqlParameter("@refto_id", Me.Id))
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If

        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")

      Catch ex As Exception
        Return New SaveErrorException(ex.InnerException.ToString)

      End Try
      trans.Commit()

      Dim trans2 As SqlTransaction = conn.BeginTransaction

      '--------------------------------------------------------------
      Dim savePRItemsError As SaveErrorException = Me.SavePRItemsDetail(arr, trans2, conn)
      If Not IsNumeric(savePRItemsError.Message) Then
        trans.Rollback()
        Return savePRItemsError
      Else
        Select Case CInt(savePRItemsError.Message)
          Case -1, -5
            trans.Rollback()
            Return savePRItemsError
          Case -2
            'Post ไปแล้ว
            Return savePRItemsError
          Case Else
        End Select
      End If
      '--------------------------------------------------------------
      trans2.Commit()

      Return New SaveErrorException("0")
    End Function
    Private Function SubSaveDocApprove(ByVal conn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException
      Dim strans As SqlTransaction = conn.BeginTransaction

      Try
        Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.AfterTax, currentUserId, m_DocMethod, "", Me.CostCenter.Id, Me.Supplier.Id)
        Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, strans)
        If Not IsNumeric(savemldocError.Message) Then
          strans.Rollback()
          Return savemldocError
        End If
      Catch ex As Exception
        strans.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      strans.Commit()
      Return New SaveErrorException("0")
    End Function
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
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldPRItemStatus", New SqlParameter("@po_id", Me.Id))

    'End Sub
    'Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
    '    If Not Me.Originated Then
    '        Return
    '    End If
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewPRItemStatus", New SqlParameter("@po_id", Me.Id))
    'End Sub
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Dim currWBS As String
      Try
        Dim da As New SqlDataAdapter("Select * from poitem where poi_po=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from poiwbs where poiw_po=" & Me.Id & " and poiw_poilinenumber in (select poi_linenumber from poitem where poi_po=" & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "poitem")
        da.Fill(ds, "poitem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "poiwbs")
        daWbs.Fill(ds, "poiwbs")

        Dim dt As DataTable = ds.Tables("poitem")
        Dim dtWbs As DataTable = ds.Tables("poiwbs")

        For Each row As DataRow In ds.Tables("poiwbs").Rows
          row.Delete()
        Next
        For Each row As DataRow In ds.Tables("poitem").Rows
          row.Delete()
        Next

        Dim i As Integer = 0
        Dim beforeSaveQty As Decimal
        With ds.Tables("poitem")
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          For Each item As POItem In Me.ItemCollection
            beforeSaveQty = item.Qty
            i += 1
            'ควรไปอยู่ที่ validate
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
            Dim dr As DataRow = .NewRow
            If item.Pritem Is Nothing Then
              dr("poi_pr") = DBNull.Value
              dr("poi_prilinenumber") = DBNull.Value
            Else
              dr("poi_pr") = item.Pritem.Pr.Id
              dr("poi_prilinenumber") = item.Pritem.LineNumber
            End If
            dr("poi_po") = Me.Id
            dr("poi_linenumber") = i
            dr("poi_entity") = item.Entity.Id
            dr("poi_entityType") = item.ItemType.Value
            dr("poi_itemName") = item.EntityName
            dr("poi_unit") = item.Unit.Id
            If Not m_closedBefor AndAlso Me.Closed Then
              dr("poi_qty") = item.GetReceivedQty
              dr("poi_originqty") = item.Qty
              dr("poi_originamt") = item.Amount
              item.m_qty = Configuration.Format(item.GetReceivedQty, DigitConfig.Qty)
            ElseIf Not m_closedBefor AndAlso Not Me.Closed Then
              dr("poi_qty") = item.Qty
              dr("poi_originqty") = item.Qty
              dr("poi_originamt") = item.Amount
            ElseIf m_closedBefor AndAlso Not Me.Closed Then
              dr("poi_qty") = item.OriginQty
              dr("poi_originqty") = item.OriginQty
              dr("poi_originamt") = item.OriginAmt
              item.m_qty = Configuration.Format(item.OriginQty, DigitConfig.Qty)
            ElseIf m_closedBefor AndAlso Me.Closed Then
              dr("poi_qty") = item.GetReceivedQty
              dr("poi_originqty") = item.OriginQty
              dr("poi_originamt") = item.OriginAmt
              item.m_qty = Configuration.Format(item.GetReceivedQty, DigitConfig.Qty)
            End If

            dr("poi_stockqty") = item.StockQty
            dr("poi_unitprice") = item.UnitPrice
            dr("poi_amt") = item.Amount
            dr("poi_unitCost") = item.UnitCost

            dr("poi_discrate") = item.Discount.Rate
            dr("poi_discamt") = item.Discount.Amount
            dr("poi_unvatable") = item.UnVatable
            dr("poi_note") = item.Note

            .Rows.Add(dr)
            If item.ItemType.Value <> 160 _
            AndAlso item.ItemType.Value <> 162 Then
              Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
              Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
              Dim currentSum As Decimal = wbsdColl.GetSumPercent
              For Each wbsd As WBSDistribute In wbsdColl
                If currentSum < 100 AndAlso wbsd.WBS.Id = rootWBS.Id Then
                  'ยังไม่เต็ม 100 แต่มีหัวอยู่
                  wbsd.Percent += (100 - currentSum)
                End If
                Dim bfTax As Decimal = 0
                If item.Po.Closed Then
                  bfTax = item.ReceivedBeforeTax
                Else
                  bfTax = item.BeforeTax
                End If
                currWBS = wbsd.WBS.Code & ":" & wbsd.WBS.Name
                wbsd.BaseCost = bfTax
                'wbsd.TransferBaseCost = bfTax
                Dim childDr As DataRow = dtWbs.NewRow
                childDr("poiw_wbs") = wbsd.WBS.Id
                If wbsd.CostCenter Is Nothing Then
                  wbsd.CostCenter = Me.CostCenter
                End If
                childDr("poiw_cc") = wbsd.CostCenter.Id
                childDr("poiw_percent") = wbsd.Percent
                childDr("poiw_po") = Me.Id
                childDr("poiw_poilinenumber") = i
                childDr("poiw_ismarkup") = wbsd.IsMarkup
                childDr("poiw_direction") = 0               'in
                childDr("poiw_baseCost") = wbsd.BaseCost
                'childDr("poiw_transferbaseCost") = wbsd.TransferBaseCost
                'childDr("poiw_transferamt") = wbsd.TransferAmount
                childDr("poiw_amt") = wbsd.Amount
                childDr("poiw_toaccttype") = 3
                childDr("poiw_cbs") = wbsd.CBS.Id
                'Add เข้า poiwbs
                dtWbs.Rows.Add(childDr)
              Next

              currentSum = wbsdColl.GetSumPercent
              'ยังไม่เต็ม 100 และยังไม่มี root
              If currentSum < 100 AndAlso Not rootWBS Is Nothing Then
                Try
                  Dim newWbsd As New WBSDistribute
                  newWbsd.WBS = rootWBS
                  newWbsd.CostCenter = item.Po.CostCenter
                  newWbsd.Percent = 100 - currentSum
                  Dim bfTax As Decimal = 0
                  If item.Po.Closed Then
                    bfTax = item.ReceivedBeforeTax
                  Else
                    bfTax = item.BeforeTax
                  End If
                  newWbsd.BaseCost = bfTax
                  'newWbsd.TransferBaseCost = bfTax
                  Dim childDr As DataRow = dtWbs.NewRow
                  childDr("poiw_wbs") = newWbsd.WBS.Id
                  childDr("poiw_cc") = newWbsd.CostCenter.Id
                  childDr("poiw_percent") = newWbsd.Percent
                  childDr("poiw_po") = Me.Id
                  childDr("poiw_poilinenumber") = i
                  childDr("poiw_ismarkup") = False
                  childDr("poiw_direction") = 0                 'in
                  childDr("poiw_baseCost") = newWbsd.BaseCost
                  'childDr("poiw_transferbaseCost") = newWbsd.TransferBaseCost
                  'childDr("poiw_transferamt") = newWbsd.TransferAmount
                  childDr("poiw_amt") = newWbsd.Amount
                  childDr("poiw_toaccttype") = 3
                  childDr("poiw_cbs") = newWbsd.CBS.Id
                  'Add เข้า poiwbs
                  dtWbs.Rows.Add(childDr)
                Catch ex As Exception
                  Throw New Exception(ex.Message.ToString)
                End Try
              End If
            End If
            item.m_qty = beforeSaveQty
          Next
        End With

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated

        daWbs.Update(GetDeletedRows(dtWbs))
        tmpDa.Update(GetDeletedRows(dt))

        Try
          tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        Catch ex As SqlException
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicatePO}"), New String() {Me.Code})
        End Try
        Try
          daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))
        Catch ex As SqlException
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicatePO}"), New String() {Me.Code})
        End Try

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True

        Return New SaveErrorException("1")

      Catch ex2 As ConstraintException
        Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicateWBS}"), New String() {currWBS})

      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
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
    Private Function GetPritemString() As String
      Dim ret As String = "("
      For Each item As POItem In Me.ItemCollection
        If Not item.Pritem Is Nothing Then
          ret &= "'" & item.Pritem.Pr.Id.ToString & "|" & item.Pritem.LineNumber & "',"
        End If
      Next
      ret &= "'')"
      Return ret
    End Function
    Private Function SavePRItemsDetail(ByVal arr As ArrayList, ByVal trans As SqlTransaction, ByVal conn As SqlConnection) As SaveErrorException
      Try
        For Each o As ValueDisplayPair In arr
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePROrderedQty" _
          , New SqlParameter("@pri_pr", CInt(o.Value)) _
          , New SqlParameter("@pri_linenumber", CInt(o.Display)))
        Next
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
      Return New SaveErrorException("1")
    End Function
    Public Function CloneGroupingItem() As PO
      Dim po1 As New PO
      po1.Id = Me.Id
      po1.Group = True

      po1.ItemCollection = New POItemCollection(po1)
      po1.RefreshTaxBase()
      Return po1
    End Function
#End Region

#Region "RefreshTaxBase"
    Public Sub SetRealGross()
      If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then
        Return
      End If

      Dim sumAmount As Decimal = 0
      For Each item As POItem In Me.ItemCollection
        sumAmount += item.Amount
      Next
      RealGross = sumAmount
    End Sub
    Private m_taxGross As Decimal
    Public Sub RefreshTaxBase()
      m_gross = 0
      m_taxGross = 0
      m_taxbase = 0

      If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then
        Return
      End If

      Dim sumAmountWithVat As Decimal = 0
      For Each item As POItem In Me.ItemCollection
        m_gross += item.Amount
        If Not item.UnVatable Then
          m_taxGross += item.Amount
          sumAmountWithVat += item.Amount
        End If
      Next
      Select Case Me.TaxType.Value
        Case 0     '"ไม่มี"
          m_taxbase = 0
        Case 1     '"แยก"
          m_taxbase = sumAmountWithVat - Me.DiscountWithVat
        Case 2     '"รวม"
          Dim a As Decimal = Vat.GetExcludedVatAmount(sumAmountWithVat, Me.TaxRate)
          Dim b As Decimal = Vat.GetExcludedVatAmount(Me.DiscountWithVat, Me.TaxRate)
          m_taxbase = a - b
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

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PO.dfm"
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

      'ReceivingDate
      dpi = New DocPrintingItem
      dpi.Mapping = "ReceivingDate"
      dpi.Value = Me.ReceivingDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      If Not Me.UseTerm Then
        'CreditPeriod
        dpi = New DocPrintingItem
        dpi.Mapping = "CreditPeriod"
        dpi.Value = Me.CreditPeriod
        dpi.DataType = "System.Int32"
        dpiColl.Add(dpi)
      End If

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'RequestorId
      dpi = New DocPrintingItem
      dpi.Mapping = "RequestorId"
      dpi.Value = Me.Requestor.Id
      dpi.DataType = "System.String"
      dpi.SignatureType = SignatureType.Person
      dpiColl.Add(dpi)

      'RequestorName
      dpi = New DocPrintingItem
      dpi.Mapping = "RequestorName"
      dpi.Value = Me.Requestor.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TermNote
      dpi = New DocPrintingItem
      dpi.Mapping = "TermNote"
      dpi.Value = Me.TermNote
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DeliveryTime
      dpi = New DocPrintingItem
      dpi.Mapping = "DeliveryTime"
      dpi.Value = Me.DeliveryTime
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PlaceOfDelivery
      dpi = New DocPrintingItem
      dpi.Mapping = "PlaceOfDelivery"
      dpi.Value = Me.PlaceOfDelivery
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Attachment
      dpi = New DocPrintingItem
      dpi.Mapping = "Attachment"
      dpi.Value = Me.Attachment
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Special
      dpi = New DocPrintingItem
      dpi.Mapping = "Special"
      dpi.Value = Me.SpecialCondition
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Contact ---> PLE USE THIS
      dpi = New DocPrintingItem
      dpi.Mapping = "Contact"
      dpi.Value = Me.Contact
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TaxRate
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxRate"
      dpi.Value = Configuration.FormatToString(Me.TaxRate, DigitConfig.Int)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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

      If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then
        'CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAddress"
        dpi.Value = Me.CostCenter.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterAdminInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAddress"
        dpi.Value = Me.CostCenter.Admin.Code & " " & Me.CostCenter.Admin.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterAdminInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAdminInfo"
        dpi.Value = Me.CostCenter.Admin.Code & " " & Me.CostCenter.Admin.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterAdminCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAdminCode"
        dpi.Value = Me.CostCenter.Admin.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterAdminName
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAdminName"
        dpi.Value = Me.CostCenter.Admin.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterAdmin
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAdmin"
        dpi.Value = Me.CostCenter.Admin.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterPhone"
        dpi.Value = Me.CostCenter.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterFax
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterFax"
        dpi.Value = Me.CostCenter.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        If Not Me.CostCenter.Customer Is Nothing AndAlso Me.CostCenter.Customer.Originated Then
          'Customer
          dpi = New DocPrintingItem
          dpi.Mapping = "Customer"
          dpi.Value = Me.CostCenter.Customer.Code & ":" & Me.CostCenter.Customer.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'CustomerName
          dpi = New DocPrintingItem
          dpi.Mapping = "CustomerName"
          dpi.Value = Me.CostCenter.Customer.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'CustomerCode
          dpi = New DocPrintingItem
          dpi.Mapping = "CustomerCode"
          dpi.Value = Me.CostCenter.Customer.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        End If

      End If

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.RealGross, DigitConfig.Price)
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

      'TaxBase
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxBase"
      dpi.Value = Configuration.FormatToString(Me.RealTaxBase, DigitConfig.Price)
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


      'Mapping การอนุมัติ #917
      Dim appTable As DataTable = BusinessEntity.GetApprovePersonListfromDoc(Me.Id, Me.EntityId)
      If appTable.Rows.Count > 0 Then
        For Each row As DataRow In appTable.Rows
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

      Dim LastLevelApprove As New Hashtable
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 AndAlso Not ap.Reject Then
          LastLevelApprove(ap.Level) = ap
        End If
      Next
      For Each ap As ApproveDoc In LastLevelApprove.Values
        dpi = New DocPrintingItem
        dpi.Mapping = "ApprovePersonIdLevel " & ap.Level.ToString
        dpi.Value = ap.Originator
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.ApprovePerson
        dpiColl.Add(dpi)
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
      '*************************************LastPage********************************

      Dim n As Integer = 0
      Dim prList As String = ""
      Dim prDateList As String = ""
      Dim prRequestorList As String = ""
      Dim prArr As New ArrayList
      Dim msgService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim noPRText As String = msgService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.BlankPRText}")

      Dim cloned As PO = Me.CloneGroupingItem
      Dim line As Integer = 0
      Dim y As Integer = 0
      Dim prHash As New Hashtable
      Dim totalQty As Decimal = 0
      Dim totalItem As Decimal = 0
      For Each item As POItem In cloned.ItemCollection
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

        'Item.NameWithNote
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.NameWithNote"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName & " (" & item.Note & ")"
        Else
          dpi.Value = item.Entity.Name & " (" & item.Note & ")"
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        '--------------------- WBS Section ------------------
        Dim WBSCode As String = ""
        Dim WBSCodePercent As String = ""
        Dim WBSCodeAmount As String = ""
        Dim WBSRemainAmount As String = ""
        Dim WBSRemainQty As String = ""
        If item.WBSDistributeCollection.Count > 0 Then
          'Populate ให้คำนวณคงเหลือแบบหลอกๆ
          'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
          If item.WBSDistributeCollection.Count = 1 Then
            WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
            WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
            WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price) & ")"
            WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
            WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
          Else
            Dim i As Integer
            For i = 0 To item.WBSDistributeCollection.Count - 1
              WBSCode &= item.WBSDistributeCollection.Item(i).WBS.Code
              WBSCodePercent &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Percent, DigitConfig.Price) & "%)"
              WBSCodeAmount &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Amount, DigitConfig.Price) & ")"
              WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).BudgetRemain, DigitConfig.Price)
              WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).QtyRemain, DigitConfig.Price)
              If i < item.WBSDistributeCollection.Count - 1 Then
                WBSCode &= ", "
                WBSCodePercent &= ", "
                WBSCodeAmount &= ", "
                WBSRemainAmount &= ", "
                WBSRemainQty &= ", "
              End If
            Next
          End If
        End If

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

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.LciNote
        If TypeOf item.Entity Is IHasNote Then
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LciNote"
          dpi.Value = CType(item.Entity, IHasNote).Note
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        End If

        n += 1
        'UNDONE
        'Dim prCode As String = itemRow("PRItemCode").ToString
        'If Trim(prCode) <> Trim(noPRText) Then
        'If Not prArr.Contains(prCode) Then
        '    prArr.Add(prCode)
        '    prList += "," & prCode
        'End If
        'End If
      Next

      ' RefPRCode
      If Not prList Is Nothing AndAlso prList.Length > 0 Then
        'If prList.StartsWith(",") Then prList = prList.Substring(1)
        dpi = New DocPrintingItem
        dpi.Mapping = "RefPRCode"
        dpi.Value = prList
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Ungroup ---------------------------------------------------------------------
      n = 0
      prList = ""
      prArr = New ArrayList
      line = 0
      For Each item As POItem In Me.ItemCollection
        'Item.UngroupCode
        dpi = New DocPrintingItem
        dpi.Mapping = "UngroupItem.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "UngroupItem"
        dpiColl.Add(dpi)

        If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
          line += 1
          'Item.UngroupLineNumber
          '************** เอามาไว้เป็นอันที่ 2
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.LineNumber"
          dpi.Value = line
          dpi.DataType = "System.Int32"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)

          'UngroupItem.UnitCode
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.UnitCode"
          dpi.Value = item.Unit.Code
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)

          'UngroupItem.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.Unit"
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)

          'UngroupItem.UnitInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.UnitInfo"
          dpi.Value = item.Unit.Code & ":" & item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)

          'Item.UngroupQty
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.Qty"
          dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)
          totalQty += item.Qty
          totalItem += 1

          'Item.UngroupUnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)

          'Item.UngroupUnitNet
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.UnitNet"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitNet, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)

          'Item.UngroupDiscountRate
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.DiscountRate"
          dpi.Value = item.Discount.Rate
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)

          'Item.UngroupDiscountAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.DiscountAmount"
          If item.Discount.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.Price)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)

          'Item.UngroupAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.Amount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)

          'Item.UngroupZeroVat
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupItem.ZeroVat"
          dpi.Value = item.UnVatable
          dpi.DataType = "System.Boolean"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)
        End If

        'Item.UngroupName
        dpi = New DocPrintingItem
        dpi.Mapping = "UngroupItem.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "UngroupItem"
        dpiColl.Add(dpi)

        'Item.UngroupNameWithNote
        dpi = New DocPrintingItem
        dpi.Mapping = "UngroupItem.NameWithNote"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName & " (" & item.Note & ")"
        Else
          dpi.Value = item.Entity.Name & " (" & item.Note & ")"
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "UngroupItem"
        dpiColl.Add(dpi)

        '--------------------- WBS Section ------------------
        Dim WBSCode As String = ""
        Dim WBSCodePercent As String = ""
        Dim WBSCodeAmount As String = ""
        Dim WBSRemainAmount As String = ""
        Dim WBSRemainQty As String = ""
        If item.WBSDistributeCollection.Count > 0 Then
          'Populate ให้คำนวณคงเหลือแบบหลอกๆ
          'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
          If item.WBSDistributeCollection.Count = 1 Then
            WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
            WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
            WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price) & ")"
            WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
            WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
          Else
            Dim i As Integer
            For i = 0 To item.WBSDistributeCollection.Count - 1
              WBSCode &= item.WBSDistributeCollection.Item(i).WBS.Code
              WBSCodePercent &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Percent, DigitConfig.Price) & "%)"
              WBSCodeAmount &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Amount, DigitConfig.Price) & ")"
              WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).BudgetRemain, DigitConfig.Price)
              WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).QtyRemain, DigitConfig.Price)
              If i < item.WBSDistributeCollection.Count - 1 Then
                WBSCode &= ", "
                WBSCodePercent &= ", "
                WBSCodeAmount &= ", "
                WBSRemainAmount &= ", "
                WBSRemainQty &= ", "
              End If
            Next
          End If
        End If

        'Item.UngroupWBSCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UngroupWBSCode"
        dpi.Value = WBSCode
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "UngroupItem"
        dpiColl.Add(dpi)

        'Item.UngroupWBSCodePercent
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UngroupWBSCodePercent"
        dpi.Value = WBSCodePercent
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "UngroupItem"
        dpiColl.Add(dpi)

        'Item.UngroupWBSCodeAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UngroupWBSCodeAmount"
        dpi.Value = WBSCodeAmount
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "UngroupItem"
        dpiColl.Add(dpi)

        'Item.UngroupWBSRemainAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UngroupWBSRemainAmount"
        dpi.Value = WBSRemainAmount
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "UngroupItem"
        dpiColl.Add(dpi)

        'Item.UngroupWBSRemainQty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UngroupWBSRemainQty"
        dpi.Value = WBSRemainQty
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "UngroupItem"
        dpiColl.Add(dpi)
        '--------------------- WBS Section ------------------

        'Item.UngroupNote
        dpi = New DocPrintingItem
        dpi.Mapping = "UngroupItem.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "UngroupItem"
        dpiColl.Add(dpi)

        'Item.UngroupLciNote
        If TypeOf item.Entity Is IHasNote Then
          dpi = New DocPrintingItem
          dpi.Mapping = "UngroupLciNote"
          dpi.Value = CType(item.Entity, IHasNote).Note
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "UngroupItem"
          dpiColl.Add(dpi)
        End If

        n += 1

        'UNDONE
        Dim prCode As String = ""

        If Not item.Pritem Is Nothing AndAlso Not item.Pritem.Pr Is Nothing Then
          prCode = item.Pritem.Pr.Code.ToString
        End If
        If Trim(prCode) <> Trim(noPRText) Then
          If Not prArr.Contains(prCode) Then
            prArr.Add(prCode)
            prList += "," & prCode
            If prList.StartsWith(",") Then
              prList = prList.Substring(1)
            End If
          End If
        End If
      Next

      'TotalItem
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalItem"
      dpi.Value = Configuration.FormatToString(totalItem, DigitConfig.Int)
      dpi.DataType = "System.Int"
      dpiColl.Add(dpi)

      'TotalQty
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalQty"
      dpi.Value = Configuration.FormatToString(totalQty, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      ' RefUngroupPRCode
      If Not prList Is Nothing AndAlso prList.Length > 0 Then
        'If prList.StartsWith(",") Then prList = prList.Substring(1)
        dpi = New DocPrintingItem
        dpi.Mapping = "RefUngroupPRCode"
        dpi.Value = prList
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If
      'Ungroup ---------------------------------------------------------------------



      'Ungroup2 ---------------------------------------------------------------------
      Dim prDocDate As Date = Nothing
      Dim curDocDate As Date = Nothing
      n = 0
      prList = ""
      prArr = New ArrayList
      line = 0
      Dim curReq As String = ""
      For Each item As POItem In Me.ItemCollection
        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim HeaderPRCode As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.BlankPRText}")
        If Not item.Pritem Is Nothing _
        AndAlso Not item.Pritem.Pr Is Nothing AndAlso item.Pritem.Pr.Originated Then
          HeaderPRCode = item.Pritem.Pr.Code
        End If
        If Not prHash.Contains(HeaderPRCode) Then
          'Item.Code = PRCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.Code"
          dpi.Value = HeaderPRCode
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          prHash(HeaderPRCode) = HeaderPRCode

          n += 1
          y += 1
        End If

        'Item.Ungroup2Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Ungroup2Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Ungroup2Item"
        dpiColl.Add(dpi)

        If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
          line += 1
          'Item.Ungroup2LineNumber
          '************** เอามาไว้เป็นอันที่ 2
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.LineNumber"
          dpi.Value = line
          dpi.DataType = "System.Int32"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Ungroup2Item.UnitCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.UnitCode"
          dpi.Value = item.Unit.Code
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Ungroup2Item.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.Unit"
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Ungroup2Item.UnitInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.UnitInfo"
          dpi.Value = item.Unit.Code & ":" & item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Item.Ungroup2Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.Qty"
          dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Item.Ungroup2UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Item.Ungroup2UnitNet
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.UnitNet"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitNet, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Item.Ungroup2DiscountRate
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.DiscountRate"
          dpi.Value = item.Discount.Rate
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Item.Ungroup2DiscountAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.DiscountAmount"
          If item.Discount.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.Price)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Item.Ungroup2Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.Amount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)

          'Item.Ungroup2ZeroVat
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2Item.ZeroVat"
          dpi.Value = item.UnVatable
          dpi.DataType = "System.Boolean"
          dpi.Row = n + 1
          dpi.Table = "Ungroup2Item"
          dpiColl.Add(dpi)
        End If

        'Item.Ungroup2Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Ungroup2Item.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Ungroup2Item"
        dpiColl.Add(dpi)

        'Item.Ungroup2NameWithNote
        dpi = New DocPrintingItem
        dpi.Mapping = "Ungroup2Item.NameWithNote"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName & " (" & item.Note & ")"
        Else
          dpi.Value = item.Entity.Name & " (" & item.Note & ")"
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Ungroup2Item"
        dpiColl.Add(dpi)

        '--------------------- WBS Section ------------------
        Dim WBSCode As String = ""
        Dim WBSCodePercent As String = ""
        Dim WBSCodeAmount As String = ""
        Dim WBSRemainAmount As String = ""
        Dim WBSRemainQty As String = ""
        If item.WBSDistributeCollection.Count > 0 Then
          If item.WBSDistributeCollection.Count = 1 Then
            WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
            WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
            WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price) & ")"
            WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
            WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
          Else
            Dim i As Integer
            For i = 0 To item.WBSDistributeCollection.Count - 1
              WBSCode &= item.WBSDistributeCollection.Item(i).WBS.Code
              WBSCodePercent &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Percent, DigitConfig.Price) & "%)"
              WBSCodeAmount &= item.WBSDistributeCollection.Item(i).WBS.Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(i).Amount, DigitConfig.Price) & ")"
              WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).BudgetRemain, DigitConfig.Price)
              WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(i).QtyRemain, DigitConfig.Price)
              If i < item.WBSDistributeCollection.Count - 1 Then
                WBSCode &= ", "
                WBSCodePercent &= ", "
                WBSCodeAmount &= ", "
                WBSRemainAmount &= ", "
                WBSRemainQty &= ", "
              End If
            Next
          End If
        End If

        'Item.Ungroup2WBSCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Ungroup2WBSCode"
        dpi.Value = WBSCode
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Ungroup2Item"
        dpiColl.Add(dpi)

        'Item.Ungroup2WBSCodePercent
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Ungroup2WBSCodePercent"
        dpi.Value = WBSCodePercent
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Ungroup2Item"
        dpiColl.Add(dpi)

        'Item.Ungroup2WBSCodeAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Ungroup2WBSCodeAmount"
        dpi.Value = WBSCodeAmount
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Ungroup2Item"
        dpiColl.Add(dpi)

        'Item.Ungroup2WBSRemainAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Ungroup2WBSRemainAmount"
        dpi.Value = WBSRemainAmount
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Ungroup2Item"
        dpiColl.Add(dpi)

        'Item.Ungroup2WBSRemainQty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Ungroup2WBSRemainQty"
        dpi.Value = WBSRemainQty
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Ungroup2Item"
        dpiColl.Add(dpi)
        '--------------------- WBS Section ------------------

        'Item.Ungroup2Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Ungroup2Item.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Ungroup2Item"
        dpiColl.Add(dpi)

        'Item.Ungroup2LciNote
        If TypeOf item.Entity Is IHasNote Then
          dpi = New DocPrintingItem
          dpi.Mapping = "Ungroup2LciNote"
          dpi.Value = CType(item.Entity, IHasNote).Note
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        End If

        n += 1

        'UNDONE
        Dim prCode As String = ""
        If Not item.Pritem Is Nothing AndAlso Not item.Pritem.Pr Is Nothing Then
          prCode = item.Pritem.Pr.Code.ToString
          If prDocDate = Nothing Then
            prDocDate = item.Pritem.Pr.DocDate
          End If
          If curDocDate <> item.Pritem.Pr.DocDate Then
            curDocDate = item.Pritem.Pr.DocDate
            prDateList += "," & curDocDate.ToString("dd/MM/yyyy")
          End If
          If curReq <> item.Pritem.Pr.Requestor.ToString Then
            curReq = item.Pritem.Pr.Requestor.ToString
            prRequestorList += "," & curReq
          End If
        End If
        If Trim(prCode) <> Trim(noPRText) Then
          If Not prArr.Contains(prCode) Then
            prArr.Add(prCode)
            prList += "," & prCode
            If prList.StartsWith(",") Then
              prList = prList.Substring(1)
            End If
          End If
        End If
      Next

      'RefUngroup2PRDocDate
      If Not prDateList Is Nothing AndAlso prDateList.Length > 0 Then
        If prDateList.StartsWith(",") Then prDateList = prDateList.Substring(1)
        dpi = New DocPrintingItem
        dpi.Mapping = "RefUngroup2PRDocDate"
        dpi.Value = prDateList
        'dpi.Value = Me.DocDate.ToShortDateString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If


      ' RefUngroup2PRCode
      If Not prList Is Nothing AndAlso prList.Length > 0 Then
        'If prList.StartsWith(",") Then prList = prList.Substring(1)
        dpi = New DocPrintingItem
        dpi.Mapping = "RefUngroup2PRCode"
        dpi.Value = prList
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      ' RefUngroup2PRRequestor
      If Not prRequestorList Is Nothing AndAlso prRequestorList.Length > 0 Then
        If prRequestorList.StartsWith(",") Then prRequestorList = prRequestorList.Substring(1)
        dpi = New DocPrintingItem
        dpi.Mapping = "RefUngroup2PRRequestor"
        dpi.Value = prRequestorList
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Ungroup2 ---------------------------------------------------------------------
      'Retention
      dpi = New DocPrintingItem
      dpi.Mapping = "Retention"
      dpi.Value = Configuration.FormatToString(Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Retention Note
      dpi = New DocPrintingItem
      dpi.Mapping = "RetentionNote"
      dpi.Value = Me.RetentionNote
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpiColl.AddRange(GetAllocateDocPrinting)

      Return dpiColl
    End Function

    Public Function GetAllocateDocPrinting() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      For Each item As POItem In Me.ItemCollection
        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        Dim qtyText As String = ""
        If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
          line += 1
          'Item.LineNumber
          '************** เอามาไว้เป็นอันที่ 2
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = line
          dpi.DataType = "System.Int32"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit"
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
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
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.UnitNet
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitNet"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitNet, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.UnitPriceN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitPrice" & (i + 1).ToString
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
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
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.UnitN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit" & (i + 1).ToString
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'Item.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Qty"
          If item.Qty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.QtyN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Qty" & (i + 1).ToString
          dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          qtyText = Configuration.FormatToString(item.Qty, DigitConfig.Qty) & " " & item.Unit.Name
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
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        'Item.NameN
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name" & (i + 1).ToString
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        '--------------------- WBS Section ------------------
        'Dim WBSCostCenter As String = ""
        'Dim WBSCode As String = ""
        'Dim WBSName As String = ""
        'Dim WBSCodePercent As String = ""
        'Dim WBSCodeAmount As String = ""
        'Dim WBSRemainAmount As String = ""
        'Dim WBSRemainQty As String = ""
        'If item.WBSDistributeCollection.Count > 0 Then
        '  'Populate ให้คำนวณคงเหลือแบบหลอกๆ
        '  'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
        '  If item.WBSDistributeCollection.Count = 1 Then
        '    WBSCostCenter = item.WBSDistributeCollection.Item(0).CostCenter.Code & ":" & _
        '    item.WBSDistributeCollection.Item(0).CostCenter.Name 'Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
        '    WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
        '    WBSName = item.WBSDistributeCollection.Item(0).WBS.Name
        '    WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%"
        '    WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price)
        '    WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
        '    WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
        '  Else
        '    Dim j As Integer
        '    For j = 0 To item.WBSDistributeCollection.Count - 1
        '      WBSCostCenter &= item.WBSDistributeCollection.Item(j).CostCenter.Code & ":" & _
        '      item.WBSDistributeCollection.Item(j).CostCenter.Name ' & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
        '      WBSCode &= item.WBSDistributeCollection.Item(j).WBS.Code
        '      WBSName &= item.WBSDistributeCollection.Item(j).WBS.Name
        '      WBSCodePercent &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Percent, DigitConfig.Price)
        '      WBSCodeAmount &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Amount, DigitConfig.Price)
        '      WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).BudgetRemain, DigitConfig.Price)
        '      WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).QtyRemain, DigitConfig.Price)
        '      If j < item.WBSDistributeCollection.Count - 1 Then
        '        WBSCostCenter &= ", "
        '        'WBSCostCentern &= ", "
        '        WBSCode &= ", "
        '        WBSName &= ", "
        '        WBSCodePercent &= ", "
        '        WBSCodeAmount &= ", "
        '        WBSRemainAmount &= ", "
        '        WBSRemainQty &= ", "
        '      End If
        '    Next
        '  End If
        'End If

        For Each dis As WBSDistribute In item.WBSDistributeCollection
          line += 1
          'Item.WBSCostCenter
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCostCenter"
          dpi.Value = dis.CostCenter.Code & ":" & dis.CostCenter.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCode"
          dpi.Value = dis.WBS.Code
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSName"
          dpi.Value = dis.WBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSinfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSInfo"
          dpi.Value = dis.WBS.Code & ":" & dis.WBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSCode"
          dpi.Value = dis.CBS.Code
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSName"
          dpi.Value = dis.CBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSinfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSInfo"
          dpi.Value = dis.CBS.Code & ":" & dis.CBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCodePercent
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodePercent"
          dpi.Value = dis.WBS.Code & ":" & dis.CBS.Code & "=>" & Configuration.FormatToString(dis.Percent, DigitConfig.Price) & "%"
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Percent
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Percent"
          dpi.Value = Configuration.FormatToString(dis.Percent, DigitConfig.Price) & "%"
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCodeAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodeAmount"
          dpi.Value = dis.WBS.Code & ":" & dis.CBS.Code & "=>" & Configuration.FormatToString(dis.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          dpi.Value = Configuration.FormatToString(dis.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.BudgetAmount"
          dpi.Value = dis.BudgetAmount
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainAmount"
          dpi.Value = dis.BudgetRemain
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          ''Item.WBSRemainAmount
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Item.AmountOverBudget"
          'dpi.Value = dis.AmountOverBudget
          'dpi.DataType = "System.String"
          'dpi.Row = i + 1
          'dpi.Table = "Allocate"
          'dpiColl.Add(dpi)

          'Item.WBSRemainQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSBudgetQty"
          dpi.Value = dis.BudgetQty
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainQty"
          dpi.Value = dis.QtyRemain
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          ''Item.WBSRemainAmount
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Item.QtyOverBudget"
          'dpi.Value = dis.QtyRemain
          'dpi.DataType = "System.String"
          'dpi.Row = i + 1
          'dpi.Table = "Allocate"
          'dpiColl.Add(dpi)
          '--------------------- WBS Section ------------------
        Next


        ''Item.Note
        'dpi = New DocPrintingItem
        'dpi.Mapping = "Item.Note"
        'dpi.Value = item.Note
        'dpi.DataType = "System.String"
        'dpi.Row = i + 1
        'dpi.Table = "Allocate"
        'dpiColl.Add(dpi)

        ''Item.LciNote
        'If TypeOf item.Entity Is IHasNote Then
        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "Item.LciNote"
        '  dpi.Value = CType(item.Entity, IHasNote).Note
        '  dpi.DataType = "System.String"
        '  dpi.Row = i + 1
        '  dpi.Table = "Allocate"
        '  dpiColl.Add(dpi)
        'End If

        ''Item.NoteN
        'dpi = New DocPrintingItem
        'dpi.Mapping = "Item.Note" & (i + 1).ToString
        'dpi.Value = item.Note
        'dpi.DataType = "System.String"
        'dpiColl.Add(dpi)


        ''Item.Description '''For Sitem โดยเฉพาะ
        'dpi = New DocPrintingItem
        'dpi.Mapping = "Item.Description"
        'If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
        '  dpi.Value = item.EntityName & vbCrLf & qtyText
        'Else
        '  dpi.Value = item.Entity.Name & vbCrLf & qtyText
        'End If
        'dpi.DataType = "System.String"
        'dpi.Row = i + 1
        'dpi.Table = "Allocate"
        'dpiColl.Add(dpi)

        i += 1

      Next

      Return dpiColl
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
          SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Approve" & Me.TableName, sqlparams)
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
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.CostCenter = Value
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
    Public ReadOnly Property ApproveIcon() As String Implements IApprovAble.ApproveIcon
      Get
        Return "Icons.16x16.Approve"
      End Get
    End Property

    Public ReadOnly Property ShowUnApproveButton() As Boolean Implements IApprovAble.ShowUnApproveButton
      Get
        Return Not (Me.Status.Value = 0 OrElse Me.IsClosed)
      End Get
    End Property

    Public Function UnApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.UnApproveData

    End Function

    Public ReadOnly Property UnApproveIcon() As String Implements IApprovAble.UnApproveIcon
      Get

      End Get
    End Property
    Public ReadOnly Property IsClosed As Boolean
      Get
        Dim ds As DataSet _
          = SqlHelper.ExecuteDataset(Me.ConnectionString, _
            CommandType.Text, _
            "select isnull(po_closed,0) from po where po_id=" & Me.Id)
        If ds.Tables(0).Rows.Count > 0 Then
          If CInt(ds.Tables(0).Rows(0)(0)) = 1 OrElse CBool(ds.Tables(0).Rows(0)(0)) Then
            Return True
          End If
        End If
        Return False
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePO}", format) Then
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

        'Update PROrderedQty
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePROrderedQtyDeletePO" _
        ', New SqlParameter("@po_id", Me.Id))

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePO", New SqlParameter() {New SqlParameter("@po_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.POIsReferencedCannotBeDeleted}")
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

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      'เวลา Copy ให้เอา CustomNote จากอันปัจจุบันมาเก็บไว้ก่อน
      Me.m_customNoteColl = New CustomNoteCollection(Me)

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
      'Me.Closing = False
      Me.Closed = False
      Me.ClearReference()
      Me.ItemCollection.checkPritemsRemain()
      Dim wbsdummy As WBS
      For Each item As POItem In Me.ItemCollection
        If item.ItemType.Value <> 160 Or item.ItemType.Value <> 162 Then
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsdummy = wbsd.WBS
            wbsd.WBS = wbsdummy
          Next
          item.ReceivedQty = 0
        End If
      Next
      Return Me
    End Function
#End Region

    '#Region "Workflow"
    '    Public Overrides ReadOnly Property StatusString As String
    '      Get
    '        If Not Me.Authorized Then
    '          If Me.Status.Value = 0 Then
    '            Return "Cancelled"
    '          End If
    '          Return "Draft"
    '        End If
    '        Return MyBase.StatusString
    '      End Get
    '    End Property
    '    Public ReadOnly Property CanbeUsed As Boolean
    '      Get
    '        Return Authorized
    '      End Get
    '    End Property
    '    Public ReadOnly Property Authorized As Boolean
    '      Get
    '        Try
    '          Dim poNeedsApproval As Boolean = CBool(Configuration.GetConfig("POApproveBeforePrint"))
    '          If poNeedsApproval Then
    '            Dim approveDocColl As New ApproveDocCollection(Me)
    '            If Not approveDocColl.IsApproved Then
    '              Return False
    '            End If
    '          Else
    '            Return True
    '          End If
    '        Catch ex As Exception
    '        End Try
    '        Select Case Me.GetActiveNode.State.Name
    '          Case "Authorized"
    '            Return True
    '        End Select
    '        Return False
    '      End Get
    '    End Property
    '#End Region

#Region "IWBSAllocatable"
    Public Property FromCostCenter As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get

      End Get
      Set(ByVal value As CostCenter)

      End Set
    End Property

    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As POItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0
              wbsd.GetChildIdList()
              For Each allItem As POItem In Me.ItemCollection
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



  End Class
  Public Class POStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "POStatus"
      End Get
    End Property
#End Region

  End Class

  Public Class TaxType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "taxtype"
      End Get
    End Property
#End Region

  End Class

  Public Class POForApprove
    Inherits PO
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "POForApprove"
      End Get
    End Property
  End Class
  Public Class POForGoodsReceipt
    Inherits PO
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "POForGoodsReceipt"
      End Get
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "POForGoodsReceipt"
      End Get
    End Property
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct()
      With Me
        Dim drh As New DataRowHelper(dr)

        .Id = drh.GetValue(Of Integer)("po_id")
        .Code = drh.GetValue(Of String)("po_code")
        .DocDate = drh.GetValue(Of Date)("po_docDate")
        .ApproveDate = drh.GetValue(Of Date)("po_approveDate")

      End With
    End Sub
  End Class
End Namespace
