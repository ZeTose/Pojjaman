Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Imports System.Reflection
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class PurchaseCNStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "purchasecn_status"
      End Get
    End Property
#End Region

  End Class

  Public Class PurchaseCN
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IVatable, IBillAcceptable, IPrintableEntity _
    , IApprovAble, IHasIBillablePerson, IReceivable, IWitholdingTaxable, ICancelable, IWBSAllocatable

#Region "Members"
    Private m_supplier As Supplier

    Private m_docDate As Date

    Private m_fromCostCenter As CostCenter
    Private m_fromCostCenterPerson As Employee

    Private m_vat As Vat
    Private m_whtcol As WitholdingTaxCollection
    Private m_receive As Receive
    Private m_je As JournalEntry

    Private m_note As String
    Private m_creditPeriod As Long

    Private m_discount As Discount
    Private m_taxRate As Decimal
    Private m_taxType As TaxType

    Private m_realTaxBase As Decimal
    Private m_realGross As Decimal
    Private m_realTaxAmount As Decimal

    Private m_status As PurchaseCNStatus

    Private m_refDocCollection As PurchaseCNRefDocCollection

    Private m_itemCollection As PurchaseCNItemCollection

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

        .m_docDate = Now.Date
        .m_supplier = New Supplier
        .m_creditPeriod = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_discount = New Discount("")
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        If .m_taxType.Value = 0 Then
          .m_taxType.Value = 1
        End If
        .m_status = New PurchaseCNStatus(-1)
        Me.m_fromCostCenter = New CostCenter
        .m_refDocCollection = New PurchaseCNRefDocCollection(Me)

        '----------------------------Tab Entities-----------------------------------------
        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 1

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        .m_receive = New Receive(Me)
        .m_receive.DocDate = Me.m_docDate
        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
        .m_itemCollection = New PurchaseCNItemCollection(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("supplier.supplier_id") Then
          If Not dr.IsNull("supplier.supplier_id") Then
            .m_supplier = New Supplier(dr, "supplier.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "stock_entity") Then
            .m_supplier = New Supplier(CInt(dr(aliasPrefix & "stock_entity")))
          End If
        End If
        If Not dr.IsNull(aliasPrefix & "stock_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "stock_discrate")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stock_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "stock_creditperiod"))
        End If

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .m_note = CStr(dr(aliasPrefix & "stock_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "tocostcenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "tocostcenter.cc_id") Then
            .m_fromCostCenter = New CostCenter(dr, "tocostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_fromcc") AndAlso Not dr.IsNull(aliasPrefix & "stock_fromcc") Then
            .m_fromCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_fromcc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "stock_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "stock_taxtype")))
        End If
        ' PO Tax Rate
        If Not dr.IsNull(aliasPrefix & "stock_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "stock_taxrate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stock_status") AndAlso Not dr.IsNull(aliasPrefix & "stock_status") Then
          .m_status = New PurchaseCNStatus(CInt(dr(aliasPrefix & "stock_status")))
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

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_receive = New Receive(Me)

        .m_je = New JournalEntry(Me)
        .m_refDocCollection = New PurchaseCNRefDocCollection(Me)
        .m_itemCollection = New PurchaseCNItemCollection(Me)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property ShowCost As Boolean
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

    Public Property ItemCollection As PurchaseCNItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal value As PurchaseCNItemCollection)
        m_itemCollection = value
      End Set
    End Property
    Public Property RefDocCollection() As PurchaseCNRefDocCollection
      Get
        Return m_refDocCollection
      End Get
      Set(ByVal Value As PurchaseCNRefDocCollection)
        m_refDocCollection = Value
      End Set
    End Property
    Public Property Supplier() As Supplier Implements IWBSAllocatable.Supplier
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
      End Set
    End Property
    Public Property DocDate() As Date Implements IVatable.Date, IPayable.Date, IGLAble.Date, IReceivable.Date, IWitholdingTaxable.Date, IWBSAllocatable.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        Me.m_je.DocDate = Value
      End Set
    End Property
    Public Property FromCostCenter() As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get
        Return m_fromCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        m_fromCostCenter = Value
        'ValidateCCandType()
      End Set
    End Property
    Public ReadOnly Property ToAccount() As Account
      Get
        If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then
          Return Me.FromCostCenter.StoreAccount
        End If
      End Get
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
    Public Property Note() As String Implements IPayable.Note, IGLAble.Note, IReceivable.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
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
        m_status = CType(Value, PurchaseCNStatus)
      End Set
    End Property
    Private m_gross As Decimal
    Public ReadOnly Property Gross() As Decimal
      Get
        Return m_gross + Me.RefDocCollection.Amount
      End Get
    End Property
    Public ReadOnly Property TaxGross() As Decimal
      Get
        Return m_taxGross
      End Get
    End Property
    Public ReadOnly Property GrossWithDoc() As Decimal
      Get
        Return m_gross + Me.RefDocCollection.Amount
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
        Return Me.Discount.Amount
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
        Return (Me.TaxRate * Me.RealTaxBase) / 100
      End Get
    End Property
    Public ReadOnly Property BeforeTax() As Decimal
      Get
        Select Case Me.TaxType.Description.ToLower
          Case "ไม่มี"
            Return Me.RealGross - Me.DiscountAmount
          Case "แยก"
            Return Me.RealGross - Me.DiscountAmount
          Case "รวม"
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax - Me.m_unTaxGross, Me.TaxRate) + Me.m_unTaxGross, DigitConfig.Price)
        End Select
      End Get
    End Property
    Public ReadOnly Property AfterTax() As Decimal
      Get
        Select Case Me.TaxType.Description.ToLower
          Case "ไม่มี"
            Return Me.BeforeTax
          Case "แยก"
            Return Me.BeforeTax + Me.RealTaxAmount
          Case "รวม"
            Return Me.RealGross - Me.DiscountAmount
        End Select
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "PurchaseCN"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.PurchaseCN.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PurchaseCN"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PurchaseCN"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PurchaseCN.ListLabel}"
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
    Public Shared Function GetDocSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PurchaseCNDoc")
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RefDocCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TaxBase", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TaxAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stockstock_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stockstock_note", GetType(String)))
      Return myDatatable
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PurchaseCN")
      myDatatable.Columns.Add(New DataColumn("stocki_refdoc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("RefDoc_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_refdoclinenumber", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Barrier", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("StockQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitcost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_discrate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_acct", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("AccountCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Account", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AccountButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unvatable", GetType(Boolean)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer, ByVal oldvat As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_receive.Id = oldreceive
      Me.m_vat.Id = oldvat
      Me.m_je.Id = oldje
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me

        If Me.ItemCollection.Count <= 0 AndAlso Me.RefDocCollection.Count <= 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If

        If Originated Then
          If Not Supplier Is Nothing Then
            If Supplier.Canceled Then
              Return New SaveErrorException(StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Supplier.Code})
            End If
          End If
        End If

        Me.RefreshTaxBase()
        Dim tmpTaxBase As Decimal = Configuration.Format(Me.TaxBase, DigitConfig.Price)
        Dim tmpVatTaxBase As Decimal = Configuration.Format(Me.Vat.TaxBase, DigitConfig.Price)
        If tmpTaxBase <> tmpVatTaxBase Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.TaxBaseNotEqualRefDocTaxBase}"), _
          New String() {Configuration.FormatToString(tmpVatTaxBase, DigitConfig.Price) _
          , Configuration.FormatToString(tmpTaxBase, DigitConfig.Price)})
        End If
        'If Me.MaxRowIndex < 0 Then
        '    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        'End If

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
          Me.m_receive.Status.Value = 4
          Me.m_whtcol.SetStatus(4)
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = 0 Then
          Me.m_receive.Status.Value = 0
          Me.m_whtcol.SetStatus(0)
          Me.m_vat.Status.Value = 0
          Me.m_je.Status.Value = 0
        End If
        If Me.Status.Value = -1 Then
          Me.Status = New PurchaseCNStatus(2)
        End If

        If Not Me.m_je.ManualFormat Then
          Me.m_je.GLFormat = Me.GetDefaultGLFormat
          Me.m_je.SetGLFormat(Me.m_je.GLFormat)
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
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        If Me.Receive.Gross <> 0 Then
          Me.m_receive.Code = m_je.Code
        End If

        Me.m_je.DocDate = Me.DocDate
        Me.m_receive.DocDate = m_je.DocDate
        If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
          Me.m_receive.Code = Me.Code
          Me.m_receive.DocDate = Me.DocDate
        End If
        Me.AutoGen = False
        Me.m_receive.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.Supplier.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Supplier.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromcc", ValidIdOrDBNull(Me.FromCostCenter)))
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


        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Dim oldreceive As Integer = Me.m_receive.Id
        Dim oldvat As Integer = Me.m_vat.Id
        Dim oldje As Integer = Me.m_je.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -2                         'เอกสารถูกอ้างอิงแล้ว
                If Me.IsDirty Then                              'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                End If
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          Dim saveDocError As SaveErrorException = SaveDoc(Me.Id, conn, trans)
          If Not IsNumeric(saveDocError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveDocError
          Else
            Select Case CInt(saveDocError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveDocError
              Case Else
            End Select
          End If

          ''==============================DELETE STOCKCOST=========================================
          ''ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
          If Me.Originated AndAlso Not Me.IsReferenced Then
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteStockiCost", New SqlParameter("@stock_id", Me.Id))
          End If
          ''==============================DELETE STOCKCOST=========================================
          Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
          If Not IsNumeric(saveDetailError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveDetailError
          Else
            Select Case CInt(saveDetailError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveDetailError
              Case Else
            End Select
          End If

          '==============================STOCKCOSTFIFO=========================================
          'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
          If Not Me.IsReferenced Then
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertStockiCostFIFO", New SqlParameter("@stock_id", Me.Id), _
                                                                                                  New SqlParameter("@stock_cc", Me.FromCostCenter.Id))
          End If
          '==============================STOCKCOSTFIFO=========================================

          If Not Me.FromCostCenter Is Nothing Then
            Me.m_receive.CcId = Me.FromCostCenter.Id
            Me.m_whtcol.SetCCId(Me.FromCostCenter.Id)
            Me.m_vat.SetCCId(Me.FromCostCenter.Id)
          End If
          Dim saveReceiveError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveReceiveError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return saveReceiveError
          Else
            Select Case CInt(saveReceiveError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveReceiveError
              Case Else
            End Select
          End If
          Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveVatError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveVatError
          Else
            Select Case CInt(saveVatError.Message)
              Case -1, -2, -5
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
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveWhtError
            Else
              Select Case CInt(saveWhtError.Message)
                Case -1, -2
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveWhtError
                Case Else
              End Select
            End If
          Else
            WitholdingTax.DeleteFromRefDoc(Me.Id, Me.EntityId, conn, trans)
          End If

          Me.DeleteRef(conn, trans)
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateVat_PCNRef" _
          , New SqlParameter("@stock_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
          , New SqlParameter("@refto_id", Me.Id))
          If Me.Status.Value = 0 Then
            Me.CancelRef(conn, trans)
          End If
          'trans.Commit()
          Try
            'trans = conn.BeginTransaction()


            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            End If
            'Me.m_grouping = False
            'Me.ReLoadItems()
            '********************************************
            If Not Me.JournalEntry.ManualFormat Then
              m_je.SetGLFormat(Me.GetDefaultGLFormat)
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
              ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================

            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateGRWBSActual")

            trans.Commit()
          Catch ex As Exception
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          End Try
          If Not Me.IsDirty AndAlso returnVal.Value.ToString = "-2" Then                  'ถ้าเอกสารไม่ถูกแก้ไข --> ให้ save
            Return New SaveErrorException(Me.Id.ToString)
          End If
          Return New SaveErrorException(returnVal.Value.ToString)
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
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDoc(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try

        Dim da As New SqlDataAdapter("Select * from cndn where cndn_stock=" & Me.Id, conn)


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
        da.FillSchema(ds, SchemaType.Mapped, "cndn")
        da.Fill(ds, "cndn")


        Dim dt As DataTable = ds.Tables("cndn")

        For Each row As DataRow In ds.Tables("cndn").Rows
          row.Delete()
        Next
        Dim i As Integer = 0
        For Each item As PurchaseCNRefDoc In Me.RefDocCollection
          i += 1
          Dim dr As DataRow = dt.NewRow
          dr("cndn_stock") = Me.Id
          dr("cndn_vat") = item.Vatitem.VatId
          dr("cndn_vatilinenumber") = item.Vatitem.LineNumber
          dr("cndn_linenumber") = i
          dr("cndn_amt") = item.Amount
          dt.Rows.Add(dr)
        Next


        da.Update(dt.Select("", "", DataViewRowState.Deleted))

        da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))

        da.Update(dt.Select("", "", DataViewRowState.Added))

        Return New SaveErrorException("0")
      Catch ex As Exception
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ") and stockiw_direction = 1", conn)

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

        Dim dtWbs As DataTable = ds.Tables("stockiwbs")

        For Each row As DataRow In ds.Tables("stockiwbs").Rows
          row.Delete()
        Next

        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As PurchaseCNItem In Me.ItemCollection
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

        Dim i As Integer = 0 'Line Running
        Dim seq As Integer = -1
        For Each item As PurchaseCNItem In Me.ItemCollection
          i += 1

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

          dr("stocki_stock") = Me.Id
          dr("stocki_cc") = DBNull.Value
          dr("stocki_linenumber") = i 'itemRow("stocki_linenumber")
          dr("stocki_entity") = item.Entity.Id
          dr("stocki_entityType") = item.ItemType.Value
          dr("stocki_itemName") = item.EntityName
          dr("stocki_unit") = item.Unit.Id
          dr("stocki_stockqty") = item.StockQty
          dr("stocki_toacct") = Me.ValidIdOrDBNull(Me.ToAccount)
          dr("stocki_acct") = Me.ValidIdOrDBNull(item.Account)
          dr("stocki_toacctType") = DBNull.Value
          dr("stocki_qty") = item.Qty
          dr("stocki_unitprice") = item.UnitPrice
          dr("stocki_unvatable") = item.UnVatable
          dr("stocki_note") = item.Note
          dr("stocki_type") = Me.EntityId
          dr("stocki_tocc") = DBNull.Value
          dr("stocki_status") = Me.Status.Value
          If Not item.Discount Is Nothing Then
            dr("stocki_discrate") = item.Discount.Rate
            dr("stocki_discamt") = item.Discount.Amount
          End If
          dr("stocki_refsequence") = 0

          '------------Checking if we have to add a new row or just update existing--------------------
          If drs.Length = 0 Then
            dt.Rows.Add(dr)
          End If
          '------------End Checking--------------------

          If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then

            'For x As Integer = 0 To 1
            Dim rootWBS As WBS
            Dim wbsdColl As WBSDistributeCollection
            Dim currentSum As Decimal
            Dim currentCostCenter As CostCenter

            '  If x = 0 Then
            '    rootWBS = New WBS(Me.ToCostCenter.RootWBSId)
            '    wbsdColl = item.InWbsdColl
            '    currentSum = wbsdColl.GetSumPercent
            '    currentCostCenter = Me.ToCostCenter
            '  Else
            rootWBS = New WBS(Me.FromCostCenter.RootWBSId)
            wbsdColl = item.WBSDistributeCollection
            currentSum = wbsdColl.GetSumPercent
            currentCostCenter = Me.FromCostCenter
            '  End If

            '  'If (x = 0 AndAlso item.AllowWBSAllocateTo) OrElse (x = 1 AndAlso item.AllowWBSAllocateFrom) Then

            Try
              For Each wbsd As WBSDistribute In wbsdColl
                If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                  'ยังไม่เต็ม 100 แต่มีหัวอยู่
                  wbsd.Percent += (100 - currentSum)
                End If
                Dim bfTax As Decimal = 0
                bfTax = item.CostAmount
                wbsd.BaseCost = bfTax 'item.Amount
                'wbsd.TransferBaseCost = bfTax 'item.Amount
                Dim childDr As DataRow = dtWbs.NewRow
                childDr("stockiw_sequence") = dr("stocki_sequence")
                childDr("stockiw_wbs") = wbsd.WBS.Id
                childDr("stockiw_percent") = wbsd.Percent
                childDr("stockiw_ismarkup") = wbsd.IsMarkup
                childDr("stockiw_direction") = 1
                childDr("stockiw_baseCost") = wbsd.BaseCost
                childDr("stockiw_amt") = wbsd.Amount
                childDr("stockiw_toaccttype") = DBNull.Value   'Me.Type.Value
                If wbsd.CostCenter Is Nothing Then
                  wbsd.CostCenter = currentCostCenter
                End If
                childDr("stockiw_cc") = wbsd.CostCenter.Id
                If Not wbsd.CBS Is Nothing Then
                  childDr("stockiw_cbs") = wbsd.CBS.Id
                End If
                'Add เข้า sciwbs
                dtWbs.Rows.Add(childDr)
              Next
            Catch ex As Exception
              Throw New Exception(ex.Message)
            End Try

            currentSum = wbsdColl.GetSumPercent
            'ยังไม่เต็ม 100 และยังไม่มี root
            If currentSum < 100 Then
              Try
                Dim wbsd As New WBSDistribute
                wbsd.WBS = rootWBS
                wbsd.CostCenter = currentCostCenter
                wbsd.Percent = 100 - currentSum
                Dim bfTax As Decimal = 0
                bfTax = item.CostAmount
                wbsd.BaseCost = bfTax
                'wbsd.TransferBaseCost = bfTax
                Dim childDr As DataRow = dtWbs.NewRow

                childDr("stockiw_sequence") = dr("stocki_sequence")
                childDr("stockiw_wbs") = wbsd.WBS.Id
                childDr("stockiw_percent") = wbsd.Percent
                childDr("stockiw_ismarkup") = wbsd.IsMarkup
                childDr("stockiw_direction") = 1
                childDr("stockiw_baseCost") = wbsd.BaseCost
                childDr("stockiw_amt") = wbsd.Amount
                childDr("stockiw_toaccttype") = DBNull.Value   'Me.Type.Value
                childDr("stockiw_cc") = wbsd.CostCenter.Id
                If Not wbsd.CBS Is Nothing Then
                  childDr("stockiw_cbs") = wbsd.CBS.Id
                End If
                'Add เข้า sciwbs
                dtWbs.Rows.Add(childDr)
              Catch ex As Exception
                Throw New Exception(ex.Message)
              End Try
            End If

          End If '

          'Next
        Next

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

        daWbs.Update(GetDeletedRows(dtWbs))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
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

    Private m_taxGross As Decimal
    Private m_unTaxGross As Decimal
    Public Sub RefreshTaxBase()
      m_gross = 0
      m_taxGross = 0
      m_taxbase = 0
      m_unTaxGross = 0

      Dim sumAmountWithVat As Decimal = 0
      'If Not Me.ItemTable Is Nothing AndAlso Me.ItemTable.Rows.Count > 0 Then
      'For Each row As TreeRow In Me.ItemTable.Rows
      For Each item As PurchaseCNItem In Me.ItemCollection
        'Dim item As New PurchaseCNItem
        item.PurchaseCN = Me
        'item.GetAmountFromRow(row)
        m_gross += item.Amount
        If Not item.UnVatable Then
          m_taxGross += item.Amount
          sumAmountWithVat += item.Amount
        Else
          m_unTaxGross += item.Amount
        End If
      Next
      'End If

      Select Case Me.TaxType.Value
        Case 0 '"ไม่มี"
          m_taxbase = 0
        Case 1 '"แยก"
          m_taxbase = sumAmountWithVat - Me.DiscountWithVat
          m_taxbase += Me.RefDocCollection.Amount
          'm_taxbase -= Me.AdvancePayItemCollection.GetExcludeVATAmountForCalculate 'CDec(IIf(Me.AdvancePay.TaxType.Value = 2, Me.AdvancePay.GetRemainExcludeVatAmount(Me.AdvancePayAmount), 0))
        Case 2 '"รวม"
          Dim a As Decimal = Vat.GetExcludedVatAmount(sumAmountWithVat, Me.TaxRate)
          Dim b As Decimal = Vat.GetExcludedVatAmount(Me.DiscountWithVat, Me.TaxRate)
          m_taxbase = a - b
          m_taxbase += Configuration.Format(Vat.GetExcludedVatAmount(Me.RefDocCollection.Amount), DigitConfig.Price)
          'm_taxbase -= Me.AdvancePayItemCollection.GetExcludeVATAmountForCalculate 'CDec(IIf(Me.AdvancePay.TaxType.Value = 2, Me.AdvancePay.GetRemainExcludeVatAmount(Me.AdvancePayAmount), 0))
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

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem

      'ภาษีซื้อ
      If Me.RealTaxAmount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B6.9"
        ji.Amount = Configuration.Format(Me.RealTaxAmount, DigitConfig.Price)
        If Me.FromCostCenter.Originated Then
          ji.CostCenter = Me.FromCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If


      'ภาษีถูกหัก ณ ที่จ่าย
      If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B6.4"
        ji.Amount = Me.WitholdingTaxCollection.Amount
        If Me.FromCostCenter.Originated Then
          ji.CostCenter = Me.FromCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
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
          If Me.FromCostCenter.Originated Then
            ji.CostCenter = Me.FromCostCenter
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
          If Me.FromCostCenter.Originated Then
            ji.CostCenter = Me.FromCostCenter
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
          If Me.FromCostCenter.Originated Then
            ji.CostCenter = Me.FromCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
        End If
      Next
      '-------------------------------------HACK------------------------------------
      ''ส่วนลดการค้า
      'If Me.DiscountAmount > 0 Then
      'ji = New JournalEntryItem
      'ji.Mapping = "Through"
      'ji.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.TradeDiscount4).Account
      'ji.Note = Me.StringParserService.Parse("${res:Global.TradeDiscount}")
      'ji.Amount = Me.DiscountAmount
      'If Me.FromCostCenter.Originated Then
      'ji.CostCenter = Me.FromCostCenter
      'Else
      'ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      'End If
      'jiColl.Add(ji)
      'End If
      '-------------------------------------HACK------------------------------------

      'ส่วนลดรับ
      Dim refAmt As Decimal = Me.RefDocCollection.Amount
      If refAmt > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B6.10"
        Select Case Me.TaxType.Value
          Case 0 'ไม่มี
            ji.Amount = refAmt
          Case 1 'แยก
            ji.Amount = refAmt
          Case 2 'รวม
            ji.Amount = Vat.GetExcludedVatAmount(refAmt)
        End Select
        If Me.FromCostCenter.Originated Then
          ji.CostCenter = Me.FromCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      If Not Me.Receive Is Nothing Then
        'ส่วนต่างระหว่างยอดรับกับยอดจริง ---> เจ้าหนี้
        Me.Receive.UpdateGross()
        If Configuration.Compare(Me.Receive.Gross, Me.Receive.Amount) < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "B6.3"
          ji.Amount = Me.Receive.Amount - Me.Receive.Gross
          If Not Me.Supplier.Account Is Nothing AndAlso Me.Supplier.Account.Originated Then
            ji.Account = Me.Supplier.Account
          End If
          If Me.FromCostCenter.Originated Then
            ji.CostCenter = Me.FromCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          jiColl.Add(ji)
        End If
        jiColl.AddRange(Me.Receive.GetJournalEntries)
      End If
      jiColl.AddRange(Me.GetItemJournalEntries)
      Return jiColl
    End Function
    Private Function ThereIsUnvatableItems() As Boolean
      'For i As Integer = 0 To Me.MaxRowIndex
      For Each item As PurchaseCNItem In Me.ItemCollection
        'Dim item As New PurchaseCNItem
        item.PurchaseCN = Me
        'item.CopyFromDataRow(CType(Me.ItemTable.Rows(i), TreeRow))
        If item.UnVatable Then
          Return True
        End If
      Next
      Return False
    End Function
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      'For i As Integer = 0 To Me.MaxRowIndex
      For Each item As PurchaseCNItem In Me.ItemCollection
        'Dim item As New PurchaseCNItem
        item.PurchaseCN = Me
        'item.CopyFromDataRow(CType(Me.ItemTable.Rows(i), TreeRow))
        Dim itemType As Integer
        Dim blankMatched As Boolean = False
        Dim blankNoAcctMatched As Boolean = False
        Dim lciToolMatched As Boolean = False
        Dim lciToolNoAcctMatched As Boolean = False
        Dim diffDebitMatched As Boolean = False
        Dim costCreditMatched As Boolean = False
        Dim costCreditNoacctMatched As Boolean = False
        Dim assetMatched As Boolean = False
        Dim assetNoacctMatched As Boolean = False

        Dim itemRemainAmount As Decimal

        If ThereIsUnvatableItems() Then
          Dim itemAmountPerGross As Decimal
          If Me.TaxGross = 0 Then
            itemAmountPerGross = 0
          Else
            itemAmountPerGross = item.Amount / Me.TaxGross
          End If
          itemRemainAmount = (Me.TaxGross - Me.TaxAmount) * itemAmountPerGross
        Else
          itemRemainAmount = item.TaxBase
        End If

        If Me.TaxType.Value = 2 Then
          itemRemainAmount += (item.DiscountFromParent - Vat.GetExcludedVatAmount(item.DiscountFromParent, Me.TaxRate))
        End If

        Dim itemAmount As Decimal = item.Amount

        For Each addedJi As JournalEntryItem In jiColl
          If Not item.ItemType Is Nothing Then
            Select Case item.ItemType.Value
              Case 0, 88, 89  '0 'Blank
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "B6.8" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += item.Amount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    blankMatched = True
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "B6.8" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += item.Amount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    blankNoAcctMatched = True
                  End If
                End If
              Case 42 ' LCI
                Dim realAccount As Account
                Dim entityAcct As Account
                Dim lci As LCIItem = CType(item.Entity, LCIItem)
                If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                  'ใช้ acct ของ LCI
                  entityAcct = lci.Account
                End If
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id Then
                    If addedJi.Mapping = "B6.5" Then
                      addedJi.Amount += item.CostTaxBase
                      lciToolMatched = True
                    End If
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
                    If addedJi.Mapping = "B6.5" Then
                      addedJi.Amount += item.CostTaxBase
                      lciToolNoAcctMatched = True
                    End If
                  End If
                End If

                'ส่วนต่าง***************************
                If addedJi.Mapping = "B6.11" Then
                  Dim tmpAmt As Decimal = 0
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    tmpAmt = item.Amount
                  Else
                    tmpAmt = itemRemainAmount
                  End If
                  addedJi.Amount += tmpAmt - item.CostTaxBase
                  diffDebitMatched = True
                End If
              Case 19  'Tool
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "B6.6" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += item.Amount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    lciToolMatched = True
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "B6.6" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += item.Amount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    lciToolNoAcctMatched = True
                  End If
                End If
              Case 28  'Asset
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "B6.7" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += item.Amount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    assetMatched = True
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "B6.7" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += item.Amount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    assetNoacctMatched = True
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
                  ji.Mapping = "B6.8"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += item.Amount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  ji.Account = realAccount
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not blankNoAcctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "B6.8"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += item.Amount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              End If
            Case 42 'LCI
              Dim realAccount As Account
              Dim entityAcct As Account
              Dim lci As LCIItem = CType(item.Entity, LCIItem)
              If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                'ใช้ acct ของ lci
                entityAcct = lci.Account
              End If
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not lciToolMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "B6.5"
                  'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                  '    ji.Amount += item.Amount
                  'Else
                  '    ji.Amount += itemRemainAmount
                  'End If
                  ji.Amount += item.CostTaxBase
                  ji.Account = realAccount
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not lciToolNoAcctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "B6.5"
                  'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                  '    ji.Amount += item.Amount
                  'Else
                  '    ji.Amount += itemRemainAmount
                  'End If
                  ji.Amount += item.CostTaxBase
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              End If
              'ส่วนต่าง***************************
              If Not diffDebitMatched Then
                ji = New JournalEntryItem
                ji.Mapping = "B6.11"
                Dim tmpAmt As Decimal = 0
                If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                  tmpAmt = item.Amount
                Else
                  tmpAmt = itemRemainAmount
                End If
                ji.Amount += tmpAmt - item.CostTaxBase
                'MessageBox.Show(String.Format("{0}-{1}", tmpAmt, item.CostTaxBase))
                If Me.FromCostCenter.Originated Then
                  ji.CostCenter = Me.FromCostCenter
                Else
                  ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                End If
                jiColl.Add(ji)
              End If
            Case 19 'Tool
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not lciToolMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "B6.6"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += item.Amount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  ji.Account = realAccount
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not lciToolNoAcctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "B6.6"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += item.Amount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
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
                  ji.Mapping = "B6.7"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += item.Amount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  ji.Account = realAccount
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                If Not assetNoacctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "B6.7"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += item.Amount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              End If
          End Select
        End If

      Next
      Return jiColl
    End Function
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
      Return Me.TaxBase
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
        Return False
      End Get
    End Property
#End Region

#Region "IBillAcceptable"
    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      RefreshTaxBase()
      Return Me.AfterTax
    End Function
    Public Property DueDate() As Date Implements IPayable.DueDate, IReceivable.DueDate
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
      End Get
      Set(ByVal Value As Payment)
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
                , "GetUnpaidPurchaseCNAmount" _
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
                , "GetUnpaidPurchaseCNAmount" _
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
                , "GetUnpaidPurchaseCNAmount" _
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
    Private Sub GetHeaderPrintingEntries(ByVal dpiColl As DocPrintingItemCollection)
      Dim dpi As DocPrintingItem

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

      'CostCenterName (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterName"
      dpi.Value = Me.FromCostCenter.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim myVat As Vat = Me.Vat
      If Not myVat Is Nothing Then
        Dim myVatitem As VatItem
        myVatitem = myVat.ItemCollection(0)

        'VatCode (am เพิ่ม)
        dpi = New DocPrintingItem
        dpi.Mapping = "VatCode"
        dpi.Value = myVatitem.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'VatDocDate (am เพิ่ม)
        dpi = New DocPrintingItem
        dpi.Mapping = "VatDocDate"
        dpi.Value = myVatitem.DocDate.ToShortDateString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

      End If


      '################################ITEM#######################'
      'Dim c As Integer = 0
      'Dim n As Integer = 0
      ''For n As Integer = 0 To Me.MaxRowIndex
      'For Each item As PurchaseCNItem In Me.ItemCollection
      '  'Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
      '  'If ValidateRow(itemRow) Then

      '  'If Not itemRow.IsNull("stocki_entity") Then
      '  'itemRow("whti_type") = 0

      '  'If Not itemRow.IsNull("stocki_entitytype") Then
      '  '  If CDec(itemRow("stocki_entitytype")) = 160 Or CDec(itemRow("stocki_entitytype")) = 162 Then
      '  '    c = c + 1
      '  '  End If
      '  'End If
      '  If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
      '    c += 1

      '    'Item.LineNumber (am เพิ่ม)
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.LineNumber"
      '    dpi.Value = c
      '    dpi.DataType = "System.Int32"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    If Not item.Entity Is Nothing Then
      '      'Item.code (am เพิ่ม)
      '      dpi = New DocPrintingItem
      '      dpi.Mapping = "Item.code"
      '      dpi.Value = item.Entity.Code
      '      dpi.DataType = "System.String"
      '      dpi.Row = n + 1
      '      dpi.Table = "Item"
      '      dpiColl.Add(dpi)
      '    End If

      '    'Item.Name (am เพิ่ม)
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Name"
      '    If Not item.Entity Is Nothing Then
      '      If item.Entity.Name.Length > 0 Then
      '        dpi.Value = item.Entity.Name
      '      Else
      '        dpi.Value = item.EntityName
      '      End If
      '    End If
      '    dpi.Value = item.EntityName
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    If Not item.Unit Is Nothing Then
      '      dpi = New DocPrintingItem
      '      dpi.Mapping = "Item.UnitCode"
      '      dpi.Value = item.Unit.Code
      '      dpi.DataType = "System.String"
      '      dpi.Row = n + 1
      '      dpi.Table = "Item"
      '      dpiColl.Add(dpi)

      '      'Item.Unit (am เพิ่ม)
      '      dpi = New DocPrintingItem
      '      dpi.Mapping = "Item.Unit"
      '      dpi.Value = item.Unit.Name
      '      dpi.DataType = "System.String"
      '      dpi.Row = n + 1
      '      dpi.Table = "Item"
      '      dpiColl.Add(dpi)
      '    End If

      '    'Item.UnitPrice (am เพิ่ม)
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.UnitPrice"
      '    dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.Price)
      '    dpi.DataType = "System.Decimal"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Qty (am เพิ่ม)
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Qty"
      '    dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Price)
      '    dpi.DataType = "System.Int32"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.DiscountRate (am เพิ่ม)
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.DiscountRate"
      '    dpi.Value = item.Discount.Rate
      '    dpi.DataType = "System.Decimal"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.DiscountAmount
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.DiscountAmount"
      '    dpi.Value = ""
      '    dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.Price)
      '    dpi.DataType = "System.Decimal"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Amount (am เพิ่ม)
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Amount"
      '    dpi.Value = ""
      '    dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
      '    dpi.DataType = "System.Decimal"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '  Else

      '    'Item.Name (am เพิ่ม)
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Name"
      '    If Not item.Entity Is Nothing Then
      '      If item.Entity.Name.Length > 0 Then
      '        dpi.Value = item.Entity.Name
      '      Else
      '        dpi.Value = item.EntityName
      '      End If
      '    End If
      '    dpi.Value = item.EntityName
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '  End If

      '  'End If

      '  n += 1
      'Next

      '################################ITEM#######################'

      For Each itmRef As PurchaseCNRefDoc In Me.m_refDocCollection
        If itmRef.RefDocType = 45 Then
          Dim gs As New GoodsReceipt(itmRef.RefDocId)
          If Not gs Is Nothing Then
            'ReceivePersonName (am เพิ่ม)
            dpi = New DocPrintingItem
            dpi.Mapping = "ReceivePersonName"
            dpi.Value = gs.ToCostCenterPerson.Name
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)
          End If
        End If

        'DeliveryDocCode (am เพิ่ม)
        dpi = New DocPrintingItem
        dpi.Mapping = "DeliveryDocCode"
        dpi.Value = itmRef.RefDocCode
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'DeliveryDocDate (am เพิ่ม)
        dpi = New DocPrintingItem
        dpi.Mapping = "DeliveryDocDate"
        dpi.Value = itmRef.RefDocDate
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

      Next

      If Not Me.Supplier Is Nothing AndAlso Me.Supplier.Originated Then

        'Supplier
        dpi = New DocPrintingItem
        dpi.Mapping = "Supplier"
        dpi.Value = Me.Supplier.Code & ":" & Me.Supplier.Name
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

      End If
    End Sub

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection

      GetHeaderPrintingEntries(dpiColl)

      Dim dpi As DocPrintingItem
      Me.RefreshTaxBase()

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''CreditPeriod()
      'dpi = New DocPrintingItem
      'dpi.Mapping = "CreditPeriod"
      'dpi.Value = Me.CreditPeriod
      'dpi.DataType = "System.Int32"
      'dpiColl.Add(dpi)

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

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'DiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)


      Dim realAmt As Decimal = Me.RefDocCollection.RealAmount

      'OldTax (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "OldTax"
      dpi.Value = Configuration.FormatToString(realAmt, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)


      'NewTax (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "NewTax"
      dpi.Value = Configuration.FormatToString(realAmt - Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'DifTax (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "DifTax"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
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

      Dim n As Integer = 0
      Dim c As Integer = 0
      'For i As Integer = 0 To Me.MaxRowIndex
      For Each item As PurchaseCNItem In Me.ItemCollection
        If item.ItemType.Value = 160 OrElse item.ItemType.Value = 162 Then
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Name"
          If Not item.Entity Is Nothing Then
            If item.Entity.Name.Length > 0 Then
              dpi.Value = item.Entity.Name
            Else
              dpi.Value = item.EntityName
            End If
          End If
          dpi.Value = item.EntityName
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Else
          c += 1

          'Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
          'If ValidateRow(itemRow) And itemRow.Level <> 0 Then
          '  Dim item As New PurchaseCNItem
          '  item.CopyFromDataRow(itemRow)

          'Item.LineNumber
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = c
          dpi.DataType = "System.Int32"
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

          'Item.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Name"
          If Not item.Entity Is Nothing Then
            If item.Entity.Name.Length > 0 Then
              dpi.Value = item.Entity.Name
            Else
              dpi.Value = item.EntityName
            End If
          End If
          dpi.Value = item.EntityName
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Item.Name"
          'dpi.Value = item.Entity.Name
          'dpi.DataType = "System.String"
          'dpi.Row = n + 1
          'dpi.Table = "Item"
          'dpiColl.Add(dpi)

          'Item.Unit
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Item.Unit"
          'dpi.Value = item.Unit.Name
          'dpi.DataType = "System.String"
          'dpi.Row = n + 1
          'dpi.Table = "Item"
          'dpiColl.Add(dpi)
          If Not item.Unit Is Nothing Then
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.UnitCode"
            dpi.Value = item.Unit.Code
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.Unit (am เพิ่ม)
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Unit"
            dpi.Value = item.Unit.Name
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          End If

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

          'Item.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Note"
          dpi.Value = item.Note
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)


          'End If
        End If
        n += 1
      Next
      Return dpiColl
    End Function
#End Region

#Region " IApprovAble "
    Public Function ApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.ApproveData
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
    Public ReadOnly Property IsApproved() As Boolean Implements IApprovAble.IsApproved
      Get

      End Get
    End Property
    Public ReadOnly Property AmountToApprove() As Decimal Implements IApprovAble.AmountToApprove
      Get

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

#Region "IReceivable"
    Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive
      RefreshTaxBase()
      Return Me.AfterTax
    End Function
    Public ReadOnly Property Payer() As IBillablePerson Implements IReceivable.Payer
      Get
        Return Me.Supplier
      End Get
    End Property
    Public Property Receive() As Receive Implements IReceivable.Receive
      Get
        Return m_receive
      End Get
      Set(ByVal Value As Receive)
        m_receive = Value
      End Set
    End Property
    Public Function ReceiveRemainingAmount() As Decimal Implements IReceivable.RemainingAmount
      Return AmountToReceive()
    End Function
#End Region

#Region "IWitholdingTaxable"
    Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return Me.TaxBase
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePurchaseCN}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePurchaseCN", New SqlParameter() {New SqlParameter("@stock_id", Me.Id), returnVal})
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateReceiveItemEntityStatus", New SqlParameter("@receive_id", Me.ValidIdOrDBNull(Me.Receive)))
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.PurchaseCNIsReferencedCannotBeDeleted}")
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

#Region "IWBSAllocatable"
    Public ReadOnly Property AllowWBSAllocateFrom As Boolean Implements IWBSAllocatable.AllowWBSAllocateFrom
      Get
        Return True
      End Get
    End Property

    Public ReadOnly Property AllowWBSAllocateTo As Boolean Implements IWBSAllocatable.AllowWBSAllocateTo
      Get

      End Get
    End Property

    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As PurchaseCNItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0
              wbsd.GetChildIdList()
              For Each allItem As PurchaseCNItem In Me.ItemCollection
                For Each childWbsd As WBSDistribute In allItem.WBSDistributeCollection
                  If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                    wbsd.ChildAmount += childWbsd.Amount
                  End If
                Next
              Next
            Next
            'For Each wbsd As WBSDistribute In item.InWbsdColl
            '  wbsd.ChildAmount = 0
            '  wbsd.GetChildIdList()
            '  For Each allItem As MatOperationWithdrawItem In Me.ItemCollection
            '    For Each childWbsd As WBSDistribute In allItem.InWbsdColl
            '      If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
            '        wbsd.ChildAmount += childWbsd.Amount
            '      End If
            '    Next
            '  Next
            'Next
          End If

          coll.Add(item)
        End If
      Next
      Return coll
    End Function

    Public Property ToCostCenter As CostCenter Implements IWBSAllocatable.ToCostCenter
      Get

      End Get
      Set(ByVal value As CostCenter)

      End Set
    End Property
#End Region

  End Class

  Public Class PurchaseCNRefDoc

#Region "Members"
    Private m_refDocId As Integer
    Private m_refDocCode As String
    Private m_refDocType As Integer
    Private m_refDocDate As Date
    Private m_vatitem As Vatitem
    Private m_linenumber As Integer

    Private m_purchaseCN As PurchaseCn
    Private m_amount As Decimal

    Private m_note As String
#End Region

#Region "Constructor"
    Public Sub New()

    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.m_vatitem = New Vatitem(dr, aliasPrefix)

      If dr.Table.Columns.Contains(aliasPrefix & "vat_refdoc") AndAlso Not dr.IsNull(aliasPrefix & "vat_refdoc") Then
        m_refDocId = CInt(dr(aliasPrefix & "vat_refdoc"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "vat_refdocCode") AndAlso Not dr.IsNull(aliasPrefix & "vat_refdocCode") Then
        m_refDocCode = CStr(dr(aliasPrefix & "vat_refdocCode"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "vat_refdocType") AndAlso Not dr.IsNull(aliasPrefix & "vat_refdocType") Then
        m_refDocType = CInt(dr(aliasPrefix & "vat_refdocType"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "vat_refdocdate") AndAlso Not dr.IsNull(aliasPrefix & "vat_refdocdate") Then
        m_refDocDate = CDate(dr(aliasPrefix & "vat_refdocdate"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "cndn_linenumber") AndAlso Not dr.IsNull(aliasPrefix & "cndn_linenumber") Then
        m_linenumber = CInt(dr(aliasPrefix & "cndn_linenumber"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "cndn_amt") AndAlso Not dr.IsNull(aliasPrefix & "cndn_amt") Then
        m_amount = CDec(dr(aliasPrefix & "cndn_amt"))
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property PurchaseCn() As PurchaseCn
      Get
        Return m_purchaseCN
      End Get
      Set(ByVal Value As PurchaseCn)
        m_purchaseCN = Value
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
    Public Property RefDocType() As Integer
      Get
        Return m_refDocType
      End Get
      Set(ByVal Value As Integer)
        m_refDocType = Value
      End Set
    End Property
    Public Property RefDocDate() As Date
      Get
        Return m_refDocDate
      End Get
      Set(ByVal Value As Date)
        m_refDocDate = Value
      End Set
    End Property
    Public Property Vatitem() As Vatitem
      Get
        Return m_vatitem
      End Get
      Set(ByVal Value As Vatitem)
        m_vatitem = Value
      End Set
    End Property
    Public ReadOnly Property RealAmount() As Decimal
      Get
        Select Case Me.PurchaseCn.TaxType.Value
          Case 0 'ไม่มี
            Return Me.Vatitem.TaxBase
          Case 1 'แยก
            Return Me.Vatitem.TaxBase
          Case 2 'รวม
            Return Me.Vatitem.TaxBase + Me.Vatitem.Amount
        End Select
      End Get
    End Property
    Public Property Amount() As Decimal
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property
    Public Property Note() As String
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property Linenumber() As Integer
      Get
        Return m_linenumber
      End Get
      Set(ByVal Value As Integer)
        m_linenumber = Value
      End Set
    End Property
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class PurchaseCNRefDocCollection
    Inherits CollectionBase

#Region "Members"
    Private m_cn As PurchaseCN
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal cn As PurchaseCN)
      m_cn = cn
      If Not cn.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetCNDNVatItem" _
      , New SqlParameter("@stock_id", cn.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New PurchaseCNRefDoc(row, "")
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property PurchaseCN() As PurchaseCN
      Get
        Return m_cn
      End Get
      Set(ByVal Value As PurchaseCN)
        m_cn = Value
      End Set
    End Property
    Default Public Property Item(ByVal index As Integer) As PurchaseCNRefDoc
      Get
        Return CType(MyBase.List.Item(index), PurchaseCNRefDoc)
      End Get
      Set(ByVal value As PurchaseCNRefDoc)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function RealAmount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As PurchaseCNRefDoc In Me
        ret += Configuration.Format(doc.RealAmount, DigitConfig.Price)
      Next
      Return ret
    End Function
    Public Function Amount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As PurchaseCNRefDoc In Me
        ret += Configuration.Format(doc.Amount, DigitConfig.Price)
      Next
      Return ret
    End Function
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each cndnref As PurchaseCNRefDoc In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        newRow("Code") = cndnref.Vatitem.Code
        newRow("RefDocCode") = cndnref.RefDocCode
        newRow("RealAmount") = Configuration.FormatToString(cndnref.RealAmount, DigitConfig.Price)
        newRow("TaxBase") = Configuration.FormatToString(cndnref.Vatitem.TaxBase, DigitConfig.Price)
        newRow("TaxAmount") = Configuration.FormatToString(cndnref.Vatitem.Amount, DigitConfig.Price)
        newRow("stockstock_amt") = Configuration.FormatToString(cndnref.Amount, DigitConfig.Price)
        newRow("stockstock_note") = cndnref.Note
        newRow("Code") = cndnref.Vatitem.Code
        newRow.Tag = cndnref
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As PurchaseCNRefDoc) As Integer
      value.PurchaseCn = Me.PurchaseCN
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As PurchaseCNRefDocCollection)
      For i As Integer = 0 To value.Count - 1
        value(i).PurchaseCn = Me.PurchaseCN
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As PurchaseCNRefDoc())
      For i As Integer = 0 To value.Length - 1
        value(i).PurchaseCn = Me.PurchaseCN
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As PurchaseCNRefDoc) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As PurchaseCNRefDoc(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As PurchaseCNRefDocEnumerator
      Return New PurchaseCNRefDocEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As PurchaseCNRefDoc) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As PurchaseCNRefDoc)
      value.PurchaseCn = Me.PurchaseCN
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As PurchaseCNRefDoc)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As PurchaseCNRefDocCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class PurchaseCNRefDocEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As PurchaseCNRefDocCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, PurchaseCNRefDoc)
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
