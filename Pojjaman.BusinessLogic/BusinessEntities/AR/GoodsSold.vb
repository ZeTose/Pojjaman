Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.pojjaman.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class GoodsSoldStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "goodssold_status"
      End Get
    End Property
#End Region

  End Class
  Public Class GoodsSold
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IVatable, IWitholdingTaxable, IBillIssuable _
    , IPrintableEntity, IHasIBillablePerson, IHasFromCostCenter, ICancelable, IAdvanceReceiveItemAble, ICheckPeriod, IHasVat

#Region "Members"
    Private m_customer As Customer

    Private m_docDate As Date

    Private m_fromCostCenter As CostCenter
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

    Private m_status As GoodsSoldStatus

    Private m_showFinalDiscountInRow As Boolean = False

    Private m_realTaxBase As Decimal
    Private m_realGross As Decimal
    Private m_realTaxAmount As Decimal

    Private m_diffAmountFIFO As Decimal

    Private m_itemCollection As GoodsSoldItemCollection
    Private m_advanceReceiveItemColl As AdvanceReceiveItemCollection
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
      'SetNoVat()
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
        .m_customer = New Customer
        .m_creditPeriod = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_discount = New Discount("")
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        .m_status = New GoodsSoldStatus(-1)
        Me.m_fromCostCenter = New CostCenter
        Me.m_fromCostCenterPerson = New Employee

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

        .m_advanceReceiveItemColl = New AdvanceReceiveItemCollection(Me)
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      m_itemCollection = New GoodsSoldItemCollection(Me, True)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("supplier.supplier_id") Then
          If Not dr.IsNull("supplier.supplier_id") Then
            .m_customer = New Customer(dr, "supplier.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "stock_entity") Then
            .m_customer = New Customer(CInt(dr(aliasPrefix & "stock_entity")))
          End If
        End If
        If Not dr.IsNull(aliasPrefix & "stock_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "stock_discrate")))
        End If

        If dr.Table.Columns.Contains("stock_otherdoccode") AndAlso Not dr.IsNull(aliasPrefix & "stock_otherdoccode") Then
          .m_poDocCode = CStr(dr(aliasPrefix & "stock_otherdoccode"))
        End If
        If dr.Table.Columns.Contains("stock_otherdocdate") AndAlso Not dr.IsNull(aliasPrefix & "stock_otherdocdate") Then
          .m_poDocDate = CDate(dr(aliasPrefix & "stock_otherdocdate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stock_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "stock_creditperiod"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "tocostcenterperson.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "tocostcenterperson.employee_id") Then
            .m_fromCostCenterPerson = New Employee(dr, "tocostcenterperson.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_fromccperson") AndAlso Not dr.IsNull(aliasPrefix & "stock_fromccperson") Then
            .m_fromCostCenterPerson = New Employee(CInt(dr(aliasPrefix & "stock_fromccperson")))
          End If
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

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .m_note = CStr(dr(aliasPrefix & "stock_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "stock_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "stock_taxtype")))
        End If
        ' PO Tax Rate
        If Not dr.IsNull(aliasPrefix & "stock_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "stock_taxrate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stock_status") AndAlso Not dr.IsNull(aliasPrefix & "stock_status") Then
          .m_status = New GoodsSoldStatus(CInt(dr(aliasPrefix & "stock_status")))
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

        If dr.Table.Columns.Contains("stock_diffAmt") AndAlso Not dr.IsNull(aliasPrefix & "stock_diffAmt") Then
          .m_diffAmountFIFO = CDec(dr(aliasPrefix & "stock_diffAmt"))
        End If

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 0

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_receive = New Receive(Me)

        .m_je = New JournalEntry(Me)
        .m_advanceReceiveItemColl = New AdvanceReceiveItemCollection(Me)

      End With
      m_itemCollection = New GoodsSoldItemCollection(Me, True)
      Me.AutoCodeFormat = New AutoCodeFormat(Me)

      SetNoVat()
    End Sub
#End Region

#Region "Properties"
    Public Property PVRVCode As String
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
    Public Property RealTaxBase() As Decimal      Get        Return m_realTaxBase      End Get      Set(ByVal Value As Decimal)        m_realTaxBase = Value      End Set    End Property
    '--------------------END REAL-------------------------

    Public Property ItemCollection() As GoodsSoldItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As GoodsSoldItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property Customer() As Customer Implements IAdvanceReceiveItemAble.Customer      Get        Return m_customer      End Get      Set(ByVal Value As Customer)        Dim oldPerson As IBillablePerson = m_customer
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If        m_customer = Value      End Set    End Property    Public Property DocDate() As Date Implements IVatable.Date, IWitholdingTaxable.Date, IReceivable.Date, IGLAble.Date, _      IAdvanceReceiveItemAble.DocDate, ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        Me.m_je.DocDate = Value      End Set    End Property    Public Property FromCostCenter() As CostCenter      Get        Return m_fromCostCenter      End Get      Set(ByVal Value As CostCenter)        m_fromCostCenter = Value      End Set    End Property    Public Property FromCostCenterPerson() As Employee      Get        Return m_fromCostCenterPerson      End Get      Set(ByVal Value As Employee)        m_fromCostCenterPerson = Value      End Set    End Property    Public ReadOnly Property ToAccount() As Account      Get        If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then          Return Me.FromCostCenter.StoreAccount
        End If      End Get    End Property    Public Property PoDocCode() As String      Get        Return m_poDocCode      End Get      Set(ByVal Value As String)        m_poDocCode = Value      End Set    End Property    Public Property PoDocDate() As Date      Get        Return m_poDocDate      End Get      Set(ByVal Value As Date)        m_poDocDate = Value      End Set    End Property    Public Property Vat() As Vat Implements IVatable.Vat      Get        Return m_vat      End Get      Set(ByVal Value As Vat)        m_vat = Value      End Set    End Property    Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
      Get
        Return m_whtcol
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_whtcol = Value
      End Set
    End Property    Public Property AdvanceReceiveItemCollection() As AdvanceReceiveItemCollection Implements IAdvanceReceiveItemAble.AdvanceReceiveItemCollection
      Get
        Return m_advanceReceiveItemColl
      End Get
      Set(ByVal Value As AdvanceReceiveItemCollection)
        m_advanceReceiveItemColl = Value
      End Set
    End Property    Public Property Note() As String Implements IReceivable.Note, IGLAble.Note, IAdvanceReceiveItemAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        m_creditPeriod = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, GoodsSoldStatus)      End Set    End Property    Private m_gross As Decimal    Public ReadOnly Property Gross() As Decimal      Get        Return m_gross      End Get    End Property    Public ReadOnly Property TaxGross() As Decimal      Get        Return m_taxGross      End Get    End Property    Public Property Discount() As Discount      Get        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property DiscountAmount() As Decimal      Get        Me.Discount.AmountBeforeDiscount = Me.RealGross        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)      End Get    End Property    Public Property TaxRate() As Decimal Implements IHasVat.Taxrate      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Private m_taxbase As Decimal    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        'Select Case Me.TaxType.Value
        '    Case 0 '"ไม่มี"
        '        Return 0
        '    Case 1 '"แยก"
        '        Return m_taxbase        '    Case 2 '"รวม"
        '        If Me.DiscountAmount = 0 Then 'แบบ basic ไม่มีส่วนลดท้ายบิล
        '            Return Me.BeforeTax
        '        End If
        '        Return m_taxbase        'End Select
        Return m_taxbase
      End Get
      Set(ByVal Value As Decimal)
        m_taxbase = Value
      End Set
    End Property    Public Property TaxType() As TaxType Implements IAdvanceReceiveItemAble.TaxType, IHasVat.Taxtype      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 2 'รวม VAT
            'Return Me.AfterTax - Me.RealTaxBase
            Return Me.TaxGross - Me.DiscountWithVat - Me.RealTaxBase - Me.AdvanceReceiveItemCollection.GetAmountForCalculate '- CDec(IIf(Me.AdvancePay.TaxType.Value = 2, Me.AdvancePayAmount, 0))
            'Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)
          Case Else '1 แยก
            Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)        End Select      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvanceReceiveItemCollection.GetExcludeVATAmount
          Case 1 '"แยก"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvanceReceiveItemCollection.GetExcludeVATAmount
          Case 2 '"รวม"
            Return Me.AfterTax - Me.RealTaxAmount
        End Select      End Get    End Property    Public ReadOnly Property AfterTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.BeforeTax
          Case 1 '"แยก"
            Return Me.BeforeTax + Me.RealTaxAmount
          Case 2 '"รวม"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvanceReceiveItemCollection.GetAmount
        End Select      End Get    End Property    Public Property ShowFinalDiscountInRow() As Boolean      Get
        Return m_showFinalDiscountInRow
      End Get
      Set(ByVal Value As Boolean)
        m_showFinalDiscountInRow = Value
      End Set
    End Property    Public ReadOnly Property DiffAmountFIFO As Decimal
      Get
        Return m_diffAmountFIFO
      End Get
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "GoodsSold"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.GoodsSold.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.GoodsSold"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.GoodsSold"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.GoodsSold.ListLabel}"
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
      Dim myDatatable As New TreeTable("GoodsSold")
      myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemName", GetType(String)))
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
      myDatatable.Columns.Add(New DataColumn("stocki_unvatable", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
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
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException
      Dim ValidateError As SaveErrorException

      Me.RefreshTaxBase()

      '=============================================
      If Me.Vat.ItemCollection.Count > 0 Then
        Dim firstVatItem As VatItem = Me.m_vat.ItemCollection.Item(0)
        If Me.TaxType.Value = 0 OrElse _
          (Not Me.Vat.AutoGen AndAlso String.IsNullOrEmpty(firstVatItem.Code)) Then
          Me.m_vat.ItemCollection.Clear()
        End If
      End If
      '=============================================

      If Not Me.JournalEntry.ManualFormat Then
        'If Not (Me.m_je.GLFormat.Originated) Then
        Dim glf As GLFormat = Me.GetDefaultGLFormat
        If Not glf Is Nothing Then
          m_je.SetGLFormat(Me.GetDefaultGLFormat)
        End If
        'End If
      End If

      ValidateError = Me.Receive.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.Vat.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.WitholdingTaxCollection.BeforeSave(currentUserId)
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
        'Me.RefreshTaxBase()
        'มีเช็คแล้วใน class vat ไม่ต้องมาทำที่นี่ก็ได้
        'Dim tmpTaxBase As Decimal = Configuration.Format(Me.RealTaxBase, DigitConfig.Price) 'ใช้ RealTaxBase แทน TaxBase
        'Dim tmpVatTaxBase As Decimal = Configuration.Format(Me.Vat.TaxBase, DigitConfig.Price)
        'If Me.Vat.TaxBase <> 0 AndAlso tmpTaxBase <> tmpVatTaxBase Then
        '  Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.TaxBaseNotEqualRefDocTaxBase}"), _
        '  New String() {Configuration.FormatToString(tmpVatTaxBase, DigitConfig.Price) _
        '  , Configuration.FormatToString(tmpTaxBase, DigitConfig.Price)})
        'End If


        If Me.ItemCollection.Count <= 0 Then
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
          Me.Status = New GoodsSoldStatus(2)
        End If



        ''เช็ครอบ 1 TODO: ทำไมต้องเช็ค 2 รอบด้วย?
        ''=============================================
        'If Me.Vat.ItemCollection.Count > 0 Then
        '  Dim firstVatItem As VatItem = Me.m_vat.ItemCollection.Item(0)
        '  If Me.TaxType.Value = 0 OrElse _
        '    (Not Me.Vat.AutoGen AndAlso String.IsNullOrEmpty(firstVatItem.Code)) Then
        '    Me.m_vat.ItemCollection.Clear()
        '  End If
        'End If
        ''=============================================

        'If Not Me.m_je.ManualFormat Then
        '  Me.m_je.GLFormat = Me.GetDefaultGLFormat
        '  Me.m_je.SetGLFormat(Me.m_je.GLFormat)
        'End If

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
          'แยก
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
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.Customer.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Customer.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocCode", Me.PoDocCode))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherDocDate", ValidDateOrDBNull(Me.PoDocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toAcct", ValidIdOrDBNull(Me.ToAccount)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ""))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromCCPerson", ValidIdOrDBNull(Me.FromCostCenterPerson)))
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
        Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
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

          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case -2 'เอกสารถูกอ้างอิงแล้ว
                  If Me.IsDirty Then 'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
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

            '==============================DeleteSTOCKCOST=========================================
            'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
            If Me.Originated AndAlso Not Me.IsReferenced Then
              SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteStockiCost", New SqlParameter("@stock_id", Me.Id))
            End If
            '==============================DeleteSTOCKCOST=========================================

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
            If Not Me.FromCostCenter Is Nothing Then
              Me.m_receive.CcId = Me.FromCostCenter.Id
              Me.m_whtcol.SetCCId(Me.FromCostCenter.Id)
              Me.m_vat.SetCCId(Me.FromCostCenter.Id)
            End If

            '==============================STOCKCOSTFIFO=========================================
            'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
            If Not Me.IsReferenced Then
              SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertStockiCostFIFO", New SqlParameter("@stock_id", Me.Id), _
                                                                                                          New SqlParameter("@stock_cc", Me.FromCostCenter.Id))
              'For Each item As GoodsSoldItem In ItemCollection
              '  Dim d As Decimal = item.ItemCollectionPrePareCost(conn, trans).CostAmount
              'Next
              'OnGlChanged()
            End If
            '==============================STOCKCOSTFIFO=========================================

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

            ''เช็ครอบ 2 TODO: ทำไมต้องเช็ค 2 รอบด้วย?
            ''=============================================
            'If Me.Vat.ItemCollection.Count > 0 Then
            '  Dim firstVatItem As VatItem = Me.m_vat.ItemCollection.Item(0)
            '  If Me.TaxType.Value = 0 OrElse _
            '    (Not Me.Vat.AutoGen AndAlso String.IsNullOrEmpty(firstVatItem.Code)) Then
            '    Me.m_vat.ItemCollection.Clear()
            '  End If
            'End If
            ''=============================================

            Me.m_vat.SetRefDocToItem(Me.Id, Me.EntityId)
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

            If Not Me.m_advanceReceiveItemColl Is Nothing AndAlso Me.m_advanceReceiveItemColl.Count >= 0 Then
              For Each advri As AdvanceReceiveItem In m_advanceReceiveItemColl
                advri.Status = Me.Status.Value
              Next
              Dim saveAdrError As SaveErrorException = Me.m_advanceReceiveItemColl.Save(currentUserId, conn, trans)
              If Not IsNumeric(saveAdrError.Message) Then
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveAdrError
              Else
                Select Case CInt(saveAdrError.Message)
                  Case -1, -2
                    trans.Rollback()
                    Me.ResetID(oldid, oldreceive, oldvat, oldje)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveAdrError
                  Case Else
                End Select
              End If
            End If

            'Me.DeleteRef(conn, trans)
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            'If Me.Status.Value = 0 Then
            '  Me.CancelRef(conn, trans)
            'End If
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGoodsSoldRVList", New SqlParameter("@stock_id", Me.Id))

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


            'trans.Commit()
            'Try
            '  trans = conn.BeginTransaction()
            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            End If
            'Me.ItemCollection = New GoodsSoldItemCollection(Me, False)
            '********************************************
            'If Not Me.JournalEntry.ManualFormat Then
            '  'If Not (Me.m_je.GLFormat.Originated) Then
            '  Dim glf As GLFormat = Me.GetDefaultGLFormat
            '  If Not glf Is Nothing Then
            '    m_je.SetGLFormat(Me.GetDefaultGLFormat)
            '  End If
            '  'End If
            'End If
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

            trans.Commit()

            'Catch ex As Exception
            '  trans.Rollback()
            '  Me.ResetID(oldid, oldreceive, oldvat, oldje)
            '  Return New SaveErrorException(ex.ToString)
            'End Try
            'If Not Me.IsDirty AndAlso returnVal.Value.ToString = "-2" Then    'ถ้าเอกสารไม่ถูกแก้ไข --> ให้ save
            '  Return New SaveErrorException(Me.Id.ToString)
            'End If

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
            'Finally
            '  conn.Close()
          End Try

          'Sub Save Block
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
            Return New SaveErrorException(returnVal.Value.ToString)
            'Complete Save
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try
          'Sub Save Block

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
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
        , New SqlParameter("@refto_id", Me.Id))
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGoodsSoldRVList", New SqlParameter("@stock_id", Me.Id))
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
    Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldStockItemStatus", New SqlParameter("@stock_id", Me.Id))
    End Sub
    Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewStockItemStatus", New SqlParameter("@stock_id", Me.Id))
    End Sub
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)
        'Dim daWbs As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ")", conn)

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

        'cmdBuilder = New SqlCommandBuilder(daWbs)
        'daWbs.SelectCommand.Transaction = trans
        'cmdBuilder.GetDeleteCommand.Transaction = trans
        'cmdBuilder.GetInsertCommand.Transaction = trans
        'cmdBuilder.GetUpdateCommand.Transaction = trans
        'cmdBuilder = Nothing
        'daWbs.FillSchema(ds, SchemaType.Mapped, "stockiwbs")
        'daWbs.Fill(ds, "stockiwbs")
        'ds.Relations.Add("sequence", ds.Tables!stockitem.Columns!stocki_sequence, ds.Tables!stockiwbs.Columns!stockiw_sequence)

        Dim dt As DataTable = ds.Tables("stockitem")

        'Dim dtWbs As DataTable = ds.Tables("stockiwbs")

        'For Each row As DataRow In ds.Tables("stockiwbs").Rows
        '  row.Delete()
        'Next

        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As GoodsSoldItem In Me.ItemCollection
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
        For Each item As GoodsSoldItem In Me.ItemCollection
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
          dr("stocki_discrate") = item.Discount.Rate
          dr("stocki_discamt") = item.Discount.Amount
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
          dr("stocki_fromcc") = SimpleBusinessEntityBase.ValidIdOrDBNull(Me.FromCostCenter)
          dr("stocki_status") = Me.Status.Value
          dr("stocki_refsequence") = 0  '0 ไปก่อนเดี๋ยวมี Query Update RefSequence ให้ตามหลัง
          'dt.Rows.Add(dr)

          '------------Checking if we have to add a new row or just update existing--------------------
          If drs.Length = 0 Then
            dt.Rows.Add(dr)
          End If
          '------------End Checking--------------------

          'For x As Integer = 0 To 1
          '  Dim rootWBS As WBS
          '  Dim wbsdColl As WBSDistributeCollection
          '  Dim currentSum As Decimal
          '  Dim currentCostCenter As CostCenter

          '  If x = 0 Then
          '    rootWBS = New WBS(Me.ToCostCenter.RootWBSId)
          '    wbsdColl = item.InWbsdColl
          '    currentSum = wbsdColl.GetSumPercent
          '    currentCostCenter = Me.ToCostCenter
          '  Else
          '    rootWBS = New WBS(Me.FromCostCenter.RootWBSId)
          '    wbsdColl = item.OutWbsdColl
          '    currentSum = wbsdColl.GetSumPercent
          '    currentCostCenter = Me.FromCostCenter
          '  End If

          '  'If (x = 0 AndAlso item.AllowWBSAllocateTo) OrElse (x = 1 AndAlso item.AllowWBSAllocateFrom) Then

          '  Try
          '    For Each wbsd As WBSDistribute In wbsdColl
          '      If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
          '        'ยังไม่เต็ม 100 แต่มีหัวอยู่
          '        wbsd.Percent += (100 - currentSum)
          '      End If
          '      'Dim bfTax As Decimal = 0
          '      'bfTax = item.CostAmount
          '      'wbsd.BaseCost = bfTax 'item.Amount
          '      'wbsd.TransferBaseCost = bfTax 'item.Amount
          '      Dim childDr As DataRow = dtWbs.NewRow
          '      childDr("stockiw_sequence") = dr("stocki_sequence")
          '      childDr("stockiw_wbs") = wbsd.WBS.Id
          '      childDr("stockiw_percent") = wbsd.Percent
          '      childDr("stockiw_ismarkup") = wbsd.IsMarkup
          '      childDr("stockiw_direction") = x
          '      'childDr("stockiw_baseCost") = wbsd.BaseCost
          '      'childDr("stockiw_amt") = wbsd.Amount
          '      childDr("stockiw_toaccttype") = Me.Type.Value
          '      If wbsd.CostCenter Is Nothing Then
          '        wbsd.CostCenter = currentCostCenter
          '      End If
          '      childDr("stockiw_cc") = wbsd.CostCenter.Id
          '      'Add เข้า sciwbs
          '      dtWbs.Rows.Add(childDr)
          '    Next
          '  Catch ex As Exception
          '    Throw New Exception(ex.Message)
          '  End Try

          '  currentSum = wbsdColl.GetSumPercent
          '  'ยังไม่เต็ม 100 และยังไม่มี root
          '  If currentSum < 100 Then
          '    Try
          '      Dim wbsd As New WBSDistribute
          '      wbsd.WBS = rootWBS
          '      wbsd.CostCenter = currentCostCenter
          '      wbsd.Percent = 100 - currentSum
          '      'Dim bfTax As Decimal = 0
          '      'bfTax = item.CostAmount
          '      'wbsd.BaseCost = bfTax 'item.Amount
          '      'wbsd.TransferBaseCost = bfTax 'item.Amount
          '      Dim childDr As DataRow = dtWbs.NewRow

          '      childDr("stockiw_sequence") = dr("stocki_sequence")
          '      childDr("stockiw_wbs") = wbsd.WBS.Id
          '      childDr("stockiw_percent") = wbsd.Percent
          '      childDr("stockiw_ismarkup") = wbsd.IsMarkup
          '      childDr("stockiw_direction") = x
          '      'childDr("stockiw_baseCost") = wbsd.BaseCost
          '      'childDr("stockiw_amt") = wbsd.Amount
          '      childDr("stockiw_toaccttype") = Me.Type.Value
          '      childDr("stockiw_cc") = wbsd.CostCenter.Id

          '      'Add เข้า sciwbs
          '      dtWbs.Rows.Add(childDr)
          '    Catch ex As Exception
          '      Throw New Exception(ex.Message)
          '    End Try
          '  End If

          '  'End If '

          'Next
        Next

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        'AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

        'daWbs.Update(GetDeletedRows(dtWbs))
        'da_aux.Update(GetDeletedRows(dtAux))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        'da_aux.Update(dtAux.Select("", "", DataViewRowState.ModifiedCurrent))
        'daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        'da_aux.Update(dtAux.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        'daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
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
    'Private Sub daWbs_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
    '  ' When the primary key propagates down to the child row's foreign key field, the field
    '  ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
    '  ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
    '  ' on the client tier, instead of being merged with the original row that was added.
    '  If e.StatementType = StatementType.Insert Then
    '    'Don't allow the AcceptChanges to occur on this row.
    '    e.Status = UpdateStatus.SkipCurrentRow
    '    ' Get the Current actual primary key value, so you can plug it back
    '    ' in after you get the correct original value that was generated for the child row.
    '    Dim currentkey As Integer = CInt(e.Row("stockiw_sequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
    '    ' This is where you get a correct original value key stored to the child row. You yank
    '    ' the original pseudo key value from the parent, plug it in as the child row's primary key
    '    ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
    '    e.Row!stockiw_sequence = e.Row.GetParentRow("sequence")("stocki_sequence", DataRowVersion.Original)
    '    e.Row.AcceptChanges()
    '    ' Now store the actual primary key value back into the foreign key column of the child row.
    '    e.Row!stockiw_sequence = currentkey
    '  End If
    '  If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    'End Sub
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
    'Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
    '  Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)
    '  da.SelectCommand.Transaction = trans
    '  Dim cmdInsert As New SqlCommand("Exec [InsertFIFOGoodsSoldItem] " & _
    '  " @stocki_stock " & _
    '  ", @stocki_lineNumber " & _
    '  ", @stocki_cc " & _
    '  ", @stocki_toacct " & _
    '  ", @stocki_toacctType " & _
    '  ", @stocki_acct " & _
    '  ", @stocki_fromcc" & _
    '  ", @stocki_tocc" & _
    '  ", @stocki_tocust" & _
    '  ", @stocki_refDoc" & _
    '  ", @stocki_refDocLinenumber" & _
    '  ", @stocki_refSequence" & _
    '  ", @stocki_entity" & _
    '  ", @stocki_entityType" & _
    '  ", @stocki_itemname" & _
    '  ", @stocki_unit" & _
    '  ", @stocki_unitprice" & _
    '  ", @stocki_discrate" & _
    '  ", @stocki_discamt" & _
    '  ", @stocki_unitCost" & _
    '  ", @stocki_amt" & _
    '  ", @stocki_qty" & _
    '  ", @stocki_stockqty" & _
    '  ", @stocki_unvatable" & _
    '  ", @stocki_iscancelled" & _
    '  ", @stocki_note" & _
    '  ", @stocki_type" & _
    '  ", @stocki_status" & _
    '  ", @stocki_fromAcctType", conn)

    '  cmdInsert.Parameters.Add("@stocki_stock", SqlDbType.Decimal, 18, "stocki_stock")
    '  cmdInsert.Parameters.Add("@stocki_lineNumber", SqlDbType.Decimal, 18, "stocki_lineNumber")
    '  cmdInsert.Parameters.Add("@stocki_cc", SqlDbType.Decimal, 18, "stocki_cc")
    '  cmdInsert.Parameters.Add("@stocki_toacct", SqlDbType.Decimal, 18, "stocki_toacct")
    '  cmdInsert.Parameters.Add("@stocki_toaccttype", SqlDbType.Decimal, 18, "stocki_toaccttype")
    '  cmdInsert.Parameters.Add("@stocki_acct", SqlDbType.Decimal, 18, "stocki_acct")
    '  cmdInsert.Parameters.Add("@stocki_tocc", SqlDbType.Decimal, 18, "stocki_tocc")
    '  cmdInsert.Parameters.Add("@stocki_tocust", SqlDbType.Decimal, 18, "stocki_tocust")
    '  cmdInsert.Parameters.Add("@stocki_refdoc", SqlDbType.Decimal, 18, "stocki_refdoc")
    '  cmdInsert.Parameters.Add("@stocki_refdoclinenumber", SqlDbType.Decimal, 18, "stocki_refdoclinenumber")
    '  cmdInsert.Parameters.Add("@stocki_refSequence", SqlDbType.Decimal, 18, "stocki_refSequence")
    '  cmdInsert.Parameters.Add("@stocki_entity", SqlDbType.Decimal, 18, "stocki_entity")
    '  cmdInsert.Parameters.Add("@stocki_entityType", SqlDbType.Decimal, 18, "stocki_entityType")
    '  cmdInsert.Parameters.Add("@stocki_itemname", SqlDbType.NVarChar, 1000, "stocki_itemname")
    '  cmdInsert.Parameters.Add("@stocki_unit", SqlDbType.Decimal, 18, "stocki_unit")
    '  cmdInsert.Parameters.Add("@stocki_unitprice", SqlDbType.Decimal, 18, "stocki_unitprice")
    '  cmdInsert.Parameters.Add("@stocki_discrate", SqlDbType.NVarChar, 200, "stocki_discrate")
    '  cmdInsert.Parameters.Add("@stocki_discamt", SqlDbType.Decimal, 18, "stocki_discamt")
    '  cmdInsert.Parameters.Add("@stocki_unitcost", SqlDbType.Decimal, 18, "stocki_unitcost")
    '  cmdInsert.Parameters.Add("@stocki_amt", SqlDbType.Decimal, 18, "stocki_amt")
    '  cmdInsert.Parameters.Add("@stocki_qty", SqlDbType.Decimal, 18, "stocki_qty")
    '  cmdInsert.Parameters.Add("@stocki_stockqty", SqlDbType.Decimal, 18, "stocki_stockqty")
    '  cmdInsert.Parameters.Add("@stocki_unvatable", SqlDbType.Bit, 4, "stocki_unvatable")
    '  cmdInsert.Parameters.Add("@stocki_iscancelled", SqlDbType.Bit, 4, "stocki_iscancelled")
    '  cmdInsert.Parameters.Add("@stocki_note", SqlDbType.NVarChar, 2000, "stocki_note")
    '  cmdInsert.Parameters.Add("@stocki_type", SqlDbType.Decimal, 18, "stocki_type")
    '  cmdInsert.Parameters.Add("@stocki_status", SqlDbType.Decimal, 18, "stocki_status")

    '  cmdInsert.Parameters.Add("@stocki_fromcc", Me.ValidIdOrDBNull(Me.FromCostCenter))
    '  cmdInsert.Parameters.Add("@stocki_fromaccttype", 3) '3=Store Account --- เบิกของได้จาก store เท่านั้น

    '  cmdInsert.Transaction = trans
    '  da.InsertCommand = cmdInsert

    '  'Detete
    '  SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "DeleteStockItem", _
    '  New SqlParameter("@stocki_stock", Me.Id))

    '  Dim ds As New DataSet
    '  da.Fill(ds, "stockitem")
    '  Dim i As Integer = 0
    '  With ds.Tables("stockitem")
    '    For Each item As GoodsSoldItem In Me.ItemCollection
    '      i += 1
    '      Dim dr As DataRow = .NewRow
    '      dr("stocki_stock") = Me.Id
    '      dr("stocki_cc") = DBNull.Value
    '      dr("stocki_linenumber") = i 'itemRow("stocki_linenumber")
    '      dr("stocki_entity") = item.Entity.Id
    '      dr("stocki_discrate") = item.Discount.Rate
    '      dr("stocki_discamt") = item.Discount.Amount
    '      dr("stocki_entityType") = item.ItemType.Value
    '      dr("stocki_itemName") = item.EntityName
    '      dr("stocki_unit") = item.Unit.Id
    '      dr("stocki_stockqty") = item.StockQty
    '      dr("stocki_toacct") = Me.ValidIdOrDBNull(Me.ToAccount)
    '      dr("stocki_acct") = Me.ValidIdOrDBNull(item.Account)
    '      dr("stocki_toacctType") = DBNull.Value
    '      dr("stocki_qty") = item.Qty
    '      dr("stocki_unitprice") = item.UnitPrice
    '      dr("stocki_unvatable") = item.UnVatable
    '      dr("stocki_note") = item.Note
    '      dr("stocki_type") = Me.EntityId
    '      dr("stocki_tocc") = DBNull.Value
    '      dr("stocki_status") = Me.Status.Value
    '      .Rows.Add(dr)
    '    Next
    '  End With
    '  Dim dt As DataTable = ds.Tables("stockitem")
    '  ' First process deletes.
    '  da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
    '  ' Next process updates.
    '  da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
    '  ' Finally process inserts.
    '  da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
    '  Return New SaveErrorException("1")
    'End Function
    Public Shared Function GetTaxBase(ByVal id As Integer) As Decimal
      Dim ret As Decimal = 0
      If id <= 0 Then
        Return ret
      End If

      Dim RealConnectionString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(RealConnectionString _
      , CommandType.StoredProcedure _
      , "GetGoodsSold" _
      , New SqlParameter("@" & "stock_id", id) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        If dr.Table.Columns.Contains("stock_taxbase") _
        AndAlso Not dr.IsNull("stock_taxbase") Then
          ret = CDec(dr("stock_taxbase"))
        End If
      End If
      Return ret
    End Function
#End Region

#Region "RefreshTaxBase"
    Private m_taxGross As Decimal
    Public Sub RefreshTaxBase()
      m_gross = 0
      m_taxGross = 0
      m_taxbase = 0

      If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then        Return
      End If

      Dim sumAmountWithVat As Decimal = 0
      For Each item As GoodsSoldItem In Me.ItemCollection
        m_gross += item.Amount
        If Not item.UnVatable Then
          m_taxGross += item.Amount
          sumAmountWithVat += item.Amount
        End If
      Next      Select Case Me.TaxType.Value
        Case 0 '"ไม่มี"
          m_taxbase = 0
        Case 1 '"แยก"
          m_taxbase = sumAmountWithVat - Me.DiscountWithVat
          m_taxbase -= Me.AdvanceReceiveItemCollection.GetExcludeVATAmountForCalculate 'CDec(IIf(Me.AdvancePay.TaxType.Value = 2, Me.AdvancePay.GetRemainExcludeVatAmount(Me.AdvancePayAmount), 0))
        Case 2 '"รวม"
          Dim a As Decimal = Vat.GetExcludedVatAmount(sumAmountWithVat, Me.TaxRate)
          Dim b As Decimal = Vat.GetExcludedVatAmount(Me.DiscountWithVat, Me.TaxRate)
          Dim c As Decimal = Vat.GetExcludedVatAmount(Me.AdvanceReceiveItemCollection.GetAmountForCalculate, Me.TaxRate)
          m_taxbase = (a - b) - c
          '-m_taxbase -= Me.AdvanceReceiveItemCollection.GetExcludeVATAmountForCalculate
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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1) _
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

      'ไม่มีภาษี
      If Me.TaxType.Value <> 0 Then
        'ภาษีขาย
        If Me.Vat.Amount > 0 AndAlso Me.Vat.ItemCollection(0).Code IsNot Nothing AndAlso (Me.Vat.ItemCollection(0).Code.Length > 0 OrElse Me.Vat.AutoGen) Then
          ji = New JournalEntryItem
          ji.Mapping = "C10.5"
          ji.Amount = Configuration.Format(Me.Vat.Amount, DigitConfig.Price)
          If Me.FromCostCenter.Originated Then
            ji.CostCenter = Me.FromCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          jiColl.Add(ji)
        End If
        'ภาษีขาย-ไม่ถึงกำหนด
        If Me.RealTaxAmount - Me.Vat.Amount > 0 OrElse Me.Vat.ItemCollection(0).Code Is Nothing OrElse (Me.Vat.ItemCollection(0).Code.Length = 0 AndAlso Not Me.Vat.AutoGen) Then
          ji = New JournalEntryItem
          ji.Mapping = "C10.5.1"
          If Me.Vat.Code.Length = 0 Then
            ji.Amount = Configuration.Format(Me.RealTaxAmount, DigitConfig.Price)
          Else
            ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
          End If
          If Me.FromCostCenter.Originated Then
            ji.CostCenter = Me.FromCostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          jiColl.Add(ji)
        End If
      End If

      ''ภาษีขาย-ไม่ถึงกำหนด
      'If Me.Vat.ItemCollection.Count = 0 AndAlso Me.RealTaxAmount - Me.Vat.Amount > 0 Then
      '  ji = New JournalEntryItem
      '  ji.Mapping = "C10.5.1"
      '  If Me.Vat.Code.Length = 0 Then
      '    ji.Amount = Configuration.Format(Me.RealTaxAmount, DigitConfig.Price)
      '  Else
      '    ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
      '  End If
      '  If Me.FromCostCenter.Originated Then
      '    ji.CostCenter = Me.FromCostCenter
      '  Else
      '    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '  End If
      '  jiColl.Add(ji)
      'End If


      'ภาษีถูกหัก ณ ที่จ่าย
      If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "C10.7"
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
          jiColl.Add(ji)
        End If
      Next
      '-------------------------------------HACK------------------------------------
      ''ส่วนลดการค้า
      'If Me.DiscountAmount > 0 Then
      'ji = New JournalEntryItem
      'ji.Mapping = "Through"
      'ji.Note = Me.StringParserService.Parse("${res:Global.PayDiscount}")
      'ji.Amount = Me.DiscountAmount
      'If Me.FromCostCenter.Originated Then
      'ji.CostCenter = Me.FromCostCenter
      'Else
      'ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      'End If
      'jiColl.Add(ji)
      'End If
      '-------------------------------------HACK------------------------------------

      'เงินมัดจำรับล่วงหน้า()
      If Me.AdvanceReceiveItemCollection.GetExcludeVATAmount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.9"
        ji.Amount = Me.AdvanceReceiveItemCollection.GetExcludeVATAmount
        If Me.FromCostCenter.Originated Then
          ji.CostCenter = Me.FromCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      If Not Me.Receive Is Nothing Then
        'ส่วนต่างระหว่างยอดรับกับยอดจริง ---> ลูกหนี้
        Me.Receive.UpdateGross()
        If Configuration.Compare(Me.Receive.Gross, Me.Receive.Amount) < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "C10.6"
          ji.Amount = Me.Receive.Amount - Me.Receive.Gross
          If Not Me.Customer.Account Is Nothing AndAlso Me.Customer.Account.Originated Then
            ji.Account = Me.Customer.Account
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
      'ส่วนลดการค้า
      ji = New JournalEntryItem
      ji.Mapping = "C10.7"
      ji.Amount = Me.DiscountAmount
      If Me.FromCostCenter.Originated Then
        ji.CostCenter = Me.FromCostCenter
      Else
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      jiColl.Add(ji)

      jiColl.AddRange(Me.GetItemJournalEntries)
      Return jiColl
    End Function
    Private Function ThereIsUnvatableItems() As Boolean
      For Each item As GoodsSoldItem In Me.ItemCollection
        If item.UnVatable Then
          Return True
        End If
      Next
      Return False
    End Function
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      Dim ji As New JournalEntryItem
      For Each item As GoodsSoldItem In Me.ItemCollection
        Dim itemType As Integer
        Dim blankMatched As Boolean = False
        Dim blankNoAcctMatched As Boolean = False
        Dim lciToolMatched As Boolean = False
        Dim lciToolNoAcctMatched As Boolean = False
        Dim costDebitMatched As Boolean = False
        Dim costCreditMatched As Boolean = False
        Dim costCreditNoacctMatched As Boolean = False

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

        If Me.TaxType.Value = 2 Then
          itemRemainAmount += (item.DiscountFromParent - Vat.GetExcludedVatAmount(item.DiscountFromParent, Me.TaxRate))
        End If

        Dim itemAmount As Decimal = item.Amount - item.DiscountFromParent

        For Each addedJi As JournalEntryItem In jiColl
          If Not item.ItemType Is Nothing Then
            Select Case item.ItemType.Value
              Case 0 'Blank
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "C10.4" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    blankMatched = True
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "C10.4" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
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
                If Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
                  If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = entityAcct.Id Then
                    'ต้นทุน***************************
                    If addedJi.Mapping = "C10.2" Then
                      addedJi.Amount += (item.UnitCost * item.StockQty)
                      costCreditMatched = True
                    End If
                  End If
                ElseIf entityAcct Is Nothing OrElse Not entityAcct.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
                    'ต้นทุน***************************
                    If addedJi.Mapping = "C10.2" Then
                      addedJi.Amount += (item.UnitCost * item.StockQty)
                      costCreditNoacctMatched = True
                    End If
                  End If
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id Then
                    If addedJi.Mapping = "C10.3" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += itemAmount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      lciToolMatched = True
                    End If
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
                    If addedJi.Mapping = "C10.3" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += itemAmount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      lciToolNoAcctMatched = True
                    End If
                  End If
                End If

                'ต้นทุน***************************
                If addedJi.Mapping = "C10.1" Then
                  addedJi.Amount += (item.UnitCost * item.StockQty)
                  costDebitMatched = True
                End If
              Case 19, 88, 89 'Tool
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "C10.4" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    lciToolMatched = True
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "C10.4" Then
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      addedJi.Amount += itemAmount
                    Else
                      addedJi.Amount += itemRemainAmount
                    End If
                    lciToolNoAcctMatched = True
                  End If
                End If
            End Select
          End If
        Next
        If Not item.ItemType Is Nothing Then
          Select Case item.ItemType.Value
            Case 0 'Blank
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not blankMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "C10.4"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
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

                  ji = New JournalEntryItem
                  ji.Mapping = "C10.4.1"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount + item.DiscountFromParent
                  Else
                    ji.Amount += itemRemainAmount + item.DiscountFromParent
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
                  ji.Mapping = "C10.4"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)

                  ji = New JournalEntryItem
                  ji.Mapping = "C10.4.1"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount + item.DiscountFromParent
                  Else
                    ji.Amount += itemRemainAmount + item.DiscountFromParent
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
              If Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
                'ต้นทุน***************************
                If Not costCreditMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "C10.2"
                  ji.Amount = (item.UnitCost * item.StockQty)
                  ji.Account = entityAcct 'realAccount ********
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              ElseIf entityAcct Is Nothing OrElse Not entityAcct.Originated Then
                'ต้นทุน***************************
                If Not lciToolNoAcctMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "C10.2"
                  ji.Amount = (item.UnitCost * item.StockQty)
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not lciToolMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "C10.3"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
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

                  ji = New JournalEntryItem
                  ji.Mapping = "C10.3.1"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount + item.DiscountFromParent
                  Else
                    ji.Amount += itemRemainAmount + item.DiscountFromParent
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
                  ji.Mapping = "C10.3"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
                  Else
                    ji.Amount += itemRemainAmount
                  End If
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)

                  ji = New JournalEntryItem
                  ji.Mapping = "C10.3.1"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount + item.DiscountFromParent
                  Else
                    ji.Amount += itemRemainAmount + item.DiscountFromParent
                  End If
                  If Me.FromCostCenter.Originated Then
                    ji.CostCenter = Me.FromCostCenter
                  Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  End If
                  jiColl.Add(ji)
                End If
              End If

              'ต้นทุน***************************
              If Not costDebitMatched Then
                ji = New JournalEntryItem
                ji.Mapping = "C10.1"
                ji.Amount = (item.UnitCost * item.StockQty)
                If Me.FromCostCenter.Originated Then
                  ji.CostCenter = Me.FromCostCenter
                Else
                  ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                End If
                jiColl.Add(ji)
              End If
            Case 19, 88, 89 'Tool
              Dim realAccount As Account
              If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                'ใช้ acct ในรายการ
                realAccount = item.Account
              End If
              If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                If Not lciToolMatched Then
                  ji = New JournalEntryItem
                  ji.Mapping = "C10.4"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
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
                  ji.Mapping = "C10.4"
                  If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                    ji.Amount += itemAmount
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
      For Each tmpJi As JournalEntryItem In jiColl
        tmpJi.Amount = Configuration.Format(tmpJi.Amount, DigitConfig.Price)
      Next
      'For Each addedJi As JournalEntryItem In jiColl
      'If addedJi.Mapping = "C10.4" OrElse addedJi.Mapping = "C10.3" Then
      'addedJi.Amount -= Me.DiscountAmount
      'End If
      'Next
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

    Public Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal Implements IVatable.GetMaximumTaxBase
      'Todo: ต้อง refresh หรือเปล่า?
      Return Me.RealTaxBase
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
    Private m_novat As Boolean = False
    Private m_RealNoVat As Nullable(Of Boolean)
    Public Property RealNoVat As Boolean
      Get
        If Not m_RealNoVat.HasValue Then
          SetNoVat()
        End If
        Return m_RealNoVat.Value
      End Get
      Set(ByVal value As Boolean)

      End Set
    End Property
    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        Return Me.TaxType.Value = 0 OrElse m_novat OrElse RealNoVat
      End Get
    End Property
    Public Sub SetNoVat(ByVal novat As Boolean)
      m_novat = novat
    End Sub
    Public Sub SetNoVat()
      If Me.TaxType.Value = 0 OrElse Me.RealTaxAmount - Me.Vat.Amount > 0 _
        OrElse Me.Vat.ItemCollection.Count = 0 OrElse Me.Vat.ItemCollection(0).Code Is Nothing _
        OrElse (Me.Vat.ItemCollection(0).Code.Length = 0 AndAlso Not Me.Vat.AutoGen) Then
        m_novat = True
        m_RealNoVat = True
      Else
        m_RealNoVat = False
      End If
    End Sub
#End Region

#Region "IWitholdingTaxable"
    Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return Me.RealTaxBase
    End Function
#End Region

#Region "IBillIssuable"
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

      'PoDocCode
      dpi = New DocPrintingItem
      dpi.Mapping = "PoDocCode"
      dpi.Value = Me.PoDocCode
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PoDocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "PoDocDate"
      dpi.Value = Me.PoDocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'InvoiceCode
      dpi = New DocPrintingItem
      dpi.Mapping = "InvoiceCode"
      dpi.Value = Me.Vat.GetVatItemCodes
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'InvoiceDate
      dpi = New DocPrintingItem
      dpi.Mapping = "InvoiceDate"
      dpi.Value = Me.Vat.GetVatItemDates
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Not Me.Customer Is Nothing AndAlso Me.Customer.Originated Then
        'CustomerInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerInfo"
        dpi.Value = Me.Customer.Code & ":" & Me.Customer.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCode"
        dpi.Value = Me.Customer.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerName
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerName"
        dpi.Value = Me.Customer.Name
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

        'CustomerPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerPhone"
        dpi.Value = Me.Customer.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerFax
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerFax"
        dpi.Value = Me.Customer.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerMobile
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerMobile"
        dpi.Value = Me.Customer.Mobile
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerContact
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerContact"
        dpi.Value = Me.Customer.Contact
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

      End If

      If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then
        'CostCenterinfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.FromCostCenter.Code & ":" & Me.FromCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.FromCostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.FromCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.FromCostCenterPerson Is Nothing AndAlso Me.FromCostCenterPerson.Originated Then
        'RequestorInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "StorePersonInfo"
        dpi.Value = Me.FromCostCenterPerson.Code & ":" & Me.FromCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Requestor code
        dpi = New DocPrintingItem
        dpi.Mapping = "StorePersonCode"
        dpi.Value = Me.FromCostCenterPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Requestor name
        dpi = New DocPrintingItem
        dpi.Mapping = "StorePersonName"
        dpi.Value = Me.FromCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CreditPeriod
      dpi = New DocPrintingItem
      dpi.Mapping = "CreditPeriod"
      dpi.Value = Me.CreditPeriod
      dpi.DataType = "System.Int32"
      dpiColl.Add(dpi)

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.String"
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
      dpi.Value = Configuration.FormatToString(Me.RealGross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AutoGross
      dpi = New DocPrintingItem
      dpi.Mapping = "AutoGross"
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

      'AdvanceReceive
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceReceive"
      dpi.Value = Configuration.FormatToString(Me.AdvanceReceiveItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceAmount"
      If Me.TaxType.Value = 0 OrElse Me.TaxType.Value = 1 Then
        dpi.Value = Configuration.FormatToString(Me.AdvanceReceiveItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.AdvanceReceiveItemCollection.GetAmount, DigitConfig.Price)
      End If
      'dpi.Value = Configuration.FormatToString(Me.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)


      'AfterAdvanceAmount 
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterAdvanceAmount"
      If Me.TaxType.Value = 0 OrElse Me.TaxType.Value = 1 Then
        dpi.Value = Configuration.FormatToString((Me.RealGross - Me.DiscountAmount) - Me.AdvanceReceiveItemCollection.GetExcludeVATAmount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString((Me.RealGross - Me.DiscountAmount) - Me.AdvanceReceiveItemCollection.GetAmount, DigitConfig.Price)
      End If
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxRate
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxRate"
      dpi.Value = Configuration.FormatToString(Me.TaxRate, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      dpi.Value = Configuration.FormatToString(Me.RealTaxAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AutoTaxAmount
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
      Dim line As Integer = 0
      For Each item As GoodsSoldItem In Me.ItemCollection
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

          'Item.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit"
          dpi.Value = item.Unit.Name
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

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        n += 1
      Next

      If ShowFinalDiscountInRow AndAlso Me.DiscountAmount <> 0 Then
        Dim parser As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        'in-row Final Discount!!!
        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        dpi.Value = parser.Parse("${res:Global.FinalDiscount}")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.UnitPrice
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UnitPrice"
        dpi.Value = Me.Discount.Rate
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Amount"
        dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
      End If

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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteGoodsSold}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteGoodsSold", New SqlParameter() {New SqlParameter("@stock_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.GoodsSoldIsReferencedCannotBeDeleted}")
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
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Customer Then
          Me.Customer = CType(Value, Customer)
        End If
      End Set
    End Property
#End Region

#Region "IHasFromCostCenter"
    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.FromCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.FromCostCenter = Value
      End Set
    End Property
#End Region

  End Class
End Namespace
